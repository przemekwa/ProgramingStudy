using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismMefPluginManager.ViewModels 
{
    public class CustomMsgBoxViewModel: BindableBase,  INotification, IInteractionRequestAware
    {
        public CustomMsgBoxViewModel()
        {

        }

        private object content;

        public object Content
        {
            get { return content; }
            set { this.SetProperty<object>(ref content, value); }
        }

        private string fff;

        public string Fff
        {
            get { return fff; }
            set { this.SetProperty<string>(ref fff, value); }
        }


        public Action FinishInteraction { get; set; }

        public INotification Notification { get; set; }

        public string Title
        {
            get; set;
        }
    }
}
