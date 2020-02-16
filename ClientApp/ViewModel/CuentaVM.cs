using ClientApp.Model;
using ClientApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.ViewModel
{
    class CuentaVM : INotifyPropertyChanged
    {
        public CuentaVM(Pedido pedido)
        {
            Pedidoa = pedido;
        }

        public Pedido Pedidoa { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void GuardarPedido()
        {
            BBDDService.AddPedido(Pedidoa);
        }
    }
}
