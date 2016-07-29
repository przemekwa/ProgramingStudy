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
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var vm = parameter as ColorViewModel;
            
            if (vm != null)
            {
                vm.Color.B = 0;
                vm.Color.G = 0;
                vm.Color.R = 0;
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
