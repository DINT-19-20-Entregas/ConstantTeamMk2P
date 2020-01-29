using ClientApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClientApp.View
{
    /// <summary>
    /// Lógica de interacción para InfoPlato.xaml
    /// </summary>
    public partial class InfoPlato : Window
    {
        public InfoPlato(Plato plato, Pedido pedido)
        {
            InitializeComponent();
        }
    }
}
