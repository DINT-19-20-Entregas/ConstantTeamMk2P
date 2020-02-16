using ClientApp.Model;
using ClientApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace ClientApp.ViewModel
{
    class CuentaVM : INotifyPropertyChanged
    {
        public CuentaVM(Pedido pedido)
        {
            Pedidoa = pedido;
            ObtenerIVADeApiRest();
            Iva = 10;
        }

        public Pedido Pedidoa { get; set; }
        public int Iva { get; set; }
        public double PrecioConIva { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void GuardarPedido()
        {
            BBDDService.AddPedido(Pedidoa);
        }

        public void ObtenerIVADeApiRest()
        {
            string url = "https://apidint1920.azurewebsites.net/api/iva";
            string json = new WebClient().DownloadString(url);
            dynamic m = JsonConvert.DeserializeObject(json);
            if (m != null)
            {
                foreach (var i in m)
                {
                    try
                    {
                        Iva = i.iva;
                    }
                    catch (Exception e)
                    {

                    }                           
                }
            }
            else
                Iva = 10;
        }

        public void ObtenerPrecioCOnIva()
        {
            double sumaDeIva = Pedidoa.precioTotal * Iva / 100;
            PrecioConIva = Pedidoa.precioTotal + sumaDeIva ;
        }
    }
}
