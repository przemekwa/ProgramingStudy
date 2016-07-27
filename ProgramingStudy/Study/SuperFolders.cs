using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public static class SuperFolder
    {
        public static string GetSuperFolderPath(string guid)
        {
            IntPtr path;

            var token = IntPtr.Zero;
            var g = new Guid(guid);

            var result = SHGetKnownFolderPath(g, 1024, token, out path);

            return Marshal.PtrToStringUni(path);
        }

        [DllImport("Shell32.dll")]
        private static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)]Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr ppszPath);
    }

    class SuperFolders : IStudyTest
    {
        public void Study()
        {
            const string documentGUID = "{FDD39AD0-238F-46AF-ADB4-6C85480369C7}";

            Console.WriteLine("Jaka jest ściezka do dokumentów?");

            Console.WriteLine(SuperFolder.GetSuperFolderPath(documentGUID));
        }
    }
}
