using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace PrismMefPluginManager.ViewModels
{               
    public class MainWindowViewModel : BindableBase 
    {
        private string imie;

        public string Imie
        {
            get { return imie; }
            set { SetProperty(ref imie, value); }
        }
        
        public string Nazwisko { get; set; }

        private int ileRazy;

        public int IleRazy
        {
            get { return ileRazy; }
            set { SetProperty(ref ileRazy, value); }
        }

        public ICommand DialogCommand { get; set; }
        public ICommand GrajCommand { get; set; }

        public InteractionRequest<CustomMsgBoxViewModel> MsgBox { get; set; }

        public MainWindowViewModel()
        {
          

            this.MsgBox = new InteractionRequest<CustomMsgBoxViewModel>();

            this.imie = "Przemek";
            this.Nazwisko = "Walkowski";
            this.IleRazy = 10;
            this.GrajCommand = new Prism.Commands.DelegateCommand(() => this.IleRazy++);
            this.DialogCommand = new Prism.Commands.DelegateCommand(MagEvent);
        }

        public void MagEvent()
        {
           // MsgBox.Raise(
           //new CustomMsgBoxViewModel
           //{
           //    Title = "Coś222",
           //    Content = "Kontent",
           //    Fff = "sdsa"
           //   }, MsgRise);

         


            


             
            


            
         
          
         

             

            Console.WriteLine("Po zamknięciu");

        }




        


        public void MsgRise(INotification c)
        {
            Console.WriteLine("Działa");
        }

    }
}
