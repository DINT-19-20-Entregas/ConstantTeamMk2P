using System;
using ClientApp.View;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.ViewModel
{
    public class MainWindowVM
    {
        public static void CargarCategorias()
        {
            Categorias ip = new Categorias();
            ip.Show();
        }
    }
}
