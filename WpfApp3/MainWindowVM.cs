using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp3
{
    public class MainWindowVM:ViewModelBase
    {
        protected IDialogService DialogService { get { return this.GetService<IDialogService>(); } }

        public DelegateCommand GosterCommand => new DelegateCommand(OnGoster);


      
        private void OnGoster()
        {

            DetailViewModel vm = new DetailViewModel();
            vm.CustomerName = "musa";

            UICommand registerCommand = new UICommand(
               id: null,
               caption: "Register",
               command: new DelegateCommand<CancelEventArgs>(
                   cancelArgs => {
                       try
                       {
                           if (vm.HataVarMi())
                           {
                               cancelArgs.Cancel = true;
                               return;
                           }
                           myExecuteMethod();
                       }
                       catch (Exception e)
                       {
                           this.GetService<IMessageBoxService>().ShowMessage(e.Message, "Error", MessageButton.OK);
                           cancelArgs.Cancel = true;
                       }
                   }
                  
               ),
               isDefault: true,
               isCancel: false
           );

            UICommand cancelCommand = new UICommand(
                id: MessageBoxResult.Cancel,
                caption: "Cancel",
                command: null,
                isDefault: false,
                isCancel: true
            );


         

            IDialogService service = this.GetService<IDialogService>("DialogService");
            UICommand result = service.ShowDialog(
                dialogCommands: new[] { registerCommand, cancelCommand },
                title: "Registration Dialog",
                viewModel: vm
            );


        }

        private void myExecuteMethod()
        {
             

            
        }
    }


    public class DetailViewModel
    {
        public string CustomerName { get; set; }

        public bool HataVarMi()
        {
            var hata = "";

            if (CustomerName == "") hata="Boş Geçme";

            if(hata.Length>0)
            MessageBox.Show(hata);

            return hata.Length > 0;

        }

    }
}
