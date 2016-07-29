using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ColorPreview.Annotations;

namespace ColorPreview.Model
{
    public class Color : INotifyPropertyChanged
    {

        private byte r;
        private byte g;
        private byte b;

        public byte R
        {
            get
            {
                return r;
            }

            set
            {
                r = value;
                OnPropertyChanged("R");
            }
        }


        public byte G
        {
            get
            {
                return g;
            }

            set
            {
                g = value;
                OnPropertyChanged("G");
            }
        }

        public byte B
        {
            get
            {
                return b;
            }

            set
            {
                b = value;
                OnPropertyChanged("B");
            }
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
