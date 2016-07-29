using System;
using System.Collections.Generic;using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using ColorPreview.Annotations;

namespace ColorPreview.Model
{
    public class ClockModel : INotifyPropertyChanged
    {
        public ClockModel()
        {
            Action<object, EventArgs> refreshView = (o, args) =>
            {
                OnPropertyChanged();
            };

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(refreshView);
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(refresh);
            dispatcherTimer.Start();
            refreshView(this.ActualDateTime, EventArgs.Empty);
        }


        public DateTime ActualDateTime
        {
            get { return DateTime.Now; }
        }

        private DateTime beforeDateTime;

        private const int refresh = 250;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged()
        {
            if (ActualDateTime - beforeDateTime < TimeSpan.FromSeconds(1) &&
                ActualDateTime.Second == beforeDateTime.Second)
            {
                return;
            }

            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(ActualDateTime)));
        }
    }
}
