using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ProgramingStudy.Study
{
    /// <summary>
    /// Klasa pokazuje informacje z systermu. W szczególności wersje framework-a
    /// </summary>
    internal class InformationsFromSystem : IStudyTest
    {
        public void Study()
        {
            this.ShowAllInformation();
        }

        public void ShowAllInformation()
        {
            Console.WriteLine(Environment.GetEnvironmentVariable("USERPROFILE"));
            Console.WriteLine(Environment.GetEnvironmentVariable("USERNAME"));
            Console.WriteLine(Environment.GetEnvironmentVariable("USERDOMAIN"));
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            System.Reflection.Assembly CurrentAssembly = Assembly.GetExecutingAssembly();
            var fileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(CurrentAssembly.Location);
            Console.WriteLine(fileVersionInfo.FileVersion);
            Console.WriteLine(CurrentAssembly.GetName().Version);
            GetVersionFromRegistry();
        }


        private static void GetVersionFromRegistry()
        {
            using (var ndpKey =
                RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "").
                    OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
            {
                foreach (string versionKeyName in ndpKey.GetSubKeyNames())
                {
                    if (versionKeyName.StartsWith("v"))
                    {
                        var versionKey = ndpKey.OpenSubKey(versionKeyName);
                        var name = (string) versionKey.GetValue("Version", "");
                        var sp = versionKey.GetValue("SP", "").ToString();
                        var install = versionKey.GetValue("Install", "").ToString();

                        if (string.IsNullOrEmpty(install))
                            Console.WriteLine(versionKeyName + "  " + name);
                        else
                        {
                            if (sp != "" && install == "1")
                            {
                                Console.WriteLine(versionKeyName + "  " + name + "  SP" + sp);
                            }

                        }
                        if (name != "")
                        {
                            continue;
                        }
                        foreach (string subKeyName in versionKey.GetSubKeyNames())
                        {
                            var subKey = versionKey.OpenSubKey(subKeyName);

                            name = (string) subKey.GetValue("Version", "");

                            if (name != "")
                                sp = subKey.GetValue("SP", "").ToString();
                            install = subKey.GetValue("Install", "").ToString();
                            if (install == "") //no install info, must be later.
                                Console.WriteLine(versionKeyName + "  " + name);
                            else
                            {
                                if (sp != "" && install == "1")
                                {
                                    Console.WriteLine("  " + subKeyName + "  " + name + "  SP" + sp);
                                }
                                else if (install == "1")
                                {
                                    Console.WriteLine("  " + subKeyName + "  " + name);
                                }
                            }
                        }
                    }
                }
            }
        }


    }


}
