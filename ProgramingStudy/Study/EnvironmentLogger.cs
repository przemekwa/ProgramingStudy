using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    
    using Microsoft.Win32;
    using System;
    using System.Configuration;
    using System.Reflection;
    using NLog;
    using NLog.Internal;
    using ConfigurationManager = System.Configuration.ConfigurationManager;

    internal class EnvironmentLogger : IStudyTest
    {
        private static ILogger logger;

        static EnvironmentLogger()
        {
            logger = LogManager.GetLogger("EnvironmentLogger");
        }

        public void Study()
        {
            Log();
        }

        public static object CurrentAssembly { get; private set; }

        public static void Log()
        {
            try
            {
                GetLogs();
            }
            catch (Exception e)
            {
                logger.Debug("Wystapił błąd podczas pobierania informacji o systemie" + e.Message);
            }
        }

        private static void GetLogs()
        {
            logger.Debug($"Ścieżka do profilu: {Environment.GetEnvironmentVariable("USERPROFILE")}");
            logger.Debug($"Nazwa użytkownika: {Environment.GetEnvironmentVariable("USERNAME")}");
            logger.Debug($"Nazwa domeny: {Environment.GetEnvironmentVariable("USERDOMAIN")}");
            logger.Debug($"Ścieżka do aplikacji: {AppDomain.CurrentDomain.BaseDirectory}");

            LogAssemblyVersion();

            LogNetFrameworkVersions();

            LogAppSettings();
        }

        private static void LogAppSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    logger.Debug($"AppSettings jest pusty.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        logger.Debug($"Klucz: {key} Wartość: {appSettings[key] }");
                    }
                }
            }
            catch (ConfigurationErrorsException e)
            {
                logger.Debug($"Błąd podczas odczytu pliku AppSettings" + e.Message);
            }
        }

        private static void LogAssemblyVersion()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var fileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(currentAssembly.Location);

            logger.Debug($"Wersja pliku: {fileVersionInfo.FileVersion}");
            logger.Debug($"Wersja modułu: {currentAssembly.GetName().Version}");
        }

        private static void LogNetFrameworkVersions()
        {
            try
            {
                using (var ndpKey =
               RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, string.Empty).
               OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
                {
                    foreach (string versionKeyName in ndpKey.GetSubKeyNames())
                    {
                        if (versionKeyName.StartsWith("v"))
                        {
                            var versionKey = ndpKey.OpenSubKey(versionKeyName);
                            var name = (string)versionKey.GetValue("Version", string.Empty);
                            var sp = versionKey.GetValue("SP", string.Empty).ToString();
                            var install = versionKey.GetValue("Install", string.Empty).ToString();

                            if (string.IsNullOrEmpty(install))
                            {
                                logger.Debug($"Wersja .Net {versionKeyName} {name}");
                            }
                            else
                            {
                                if (sp != string.Empty && install == "1")
                                {
                                    logger.Debug($"Wersja .Net {versionKeyName} {name} SP: {sp}");
                                }
                            }

                            if (name != string.Empty)
                            {
                                continue;
                            }

                            foreach (string subKeyName in versionKey.GetSubKeyNames())
                            {
                                var subKey = versionKey.OpenSubKey(subKeyName);

                                name = (string)subKey.GetValue("Version", string.Empty);

                                if (name != string.Empty)
                                {
                                    sp = subKey.GetValue("SP", string.Empty).ToString();
                                }

                                install = subKey.GetValue("Install", string.Empty).ToString();
                                if (install == string.Empty) //no install info, must be later.
                                {
                                    logger.Debug($"Wersja .Net {versionKeyName} {name}");
                                }
                                else
                                {
                                    if (sp != string.Empty && install == "1")
                                    {
                                        logger.Debug($"Wersja .Net {versionKeyName} {name} SP: {sp}");
                                    }
                                    else if (install == "1")
                                    {
                                        logger.Debug($"Wersja .Net {versionKeyName} {name}");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.Debug($"Błąd podczas wersji .NET-a" + e.Message);
            }
        }

       
    }

}
