using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ColorPreview.Annotations;
using ColorPreview.Model;

namespace ColorPreview.ViewModel
{
    public class ColorViewModel : INotifyPropertyChanged
    {
        private Color color;

        public Color Color
        {
            get { return color; }
            set
            {
                color = value;
                this.OnPropertyChanged("Color");
            }
        }


        public int IncrementValue { get; set; } = 23;

        public ColorViewModel()
        {
            this.Color = UserSettings.GetUserColor();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(params string[] propertyName)
        {
            if (PropertyChanged != null)
            {
                foreach (var p in propertyName)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(p));
                }
            }
        }
    }
}
