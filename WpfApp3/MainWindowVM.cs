using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            IDialogService service = this.GetService<IDialogService>("DialogService");
            MessageResult result = service.ShowDialog(
                dialogButtons: MessageButton.OKCancel,
                title: "Registration Dialog",
                viewModel: vm
            );


        }

  
    }


    public class DetailViewModel
    {
        public string CustomerName { get; set; }
    }
}
