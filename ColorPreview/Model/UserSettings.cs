using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorPreview.Properties;

namespace ColorPreview.Model
{
    internal static class UserSettings
    {
        public static Color GetUserColor()
        {
            return new Color
            {
                R = (byte) Settings.Default.R,
                G = (byte) Settings.Default.G,
                B = (byte) Settings.Default.B,
            };
        }

        public static void SaveColor(Color color)
        {
            Settings.Default.R = color.R;
            Settings.Default.G = color.G;
            Settings.Default.B = color.B; 

            Settings.Default.Save();
        }
    }
}
