using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ColorPreview.Model;

namespace ColorPreview.ViewModel
{
    public class SaveColorCommand : ICommand
    {
        public ColorViewModel ColorViewModel { get; }

        public SaveColorCommand(ColorViewModel colorViewModel)
        {
            ColorViewModel = colorViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            UserSettings.SaveColor(this.ColorViewModel.Color);
        }

        public event EventHandler CanExecuteChanged;
    }
}
