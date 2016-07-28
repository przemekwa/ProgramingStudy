using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorPreview.Model;

namespace ColorPreview.ViewModel
{
    public class ColorViewModel
    {
        public Color Color { get; set; }

        

        public ColorViewModel()
        {
            this.Color = UserSettings.GetUserColor();
        }
    }
}
