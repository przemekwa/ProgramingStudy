using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ColorPreview.Model;

namespace ColorPreview.ViewModel
{
    public class ResetCommand : ICommand
    {

        public ColorViewModel ColorViewModel { get;}

        public ResetCommand(ColorViewModel colorViewModel)
        {
            ColorViewModel = colorViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (ColorViewModel != null)
            {
                ColorViewModel.Color.B = 0;
                ColorViewModel.Color.G = 0;
                ColorViewModel.Color.R = 0;
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
