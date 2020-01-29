using ClientApp.Model;
using ClientApp.ViewModel;
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
            this.DataContext = new InfoPlatoVM(plato,pedido);
            ListaIngredientes.DataContext = (this.DataContext as InfoPlatoVM).listaIngredientes;
            PrecioPlatoTextBlock.DataContext = (this.DataContext as InfoPlatoVM).plato;
        }

        private void AñadirPlato_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            (this.DataContext as InfoPlatoVM).AñadirPlatoAPedido();
            Close();
        }

        private void AñadirPlato_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
           e.CanExecute = int.Parse(CantidadTextBox.Text) > 0;
        }

        private void RetrocederCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void RetrocederCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
