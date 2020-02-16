using ClientApp.Model;
using ClientApp.Service;
using ClientApp.View;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ClientApp.ViewModel
{
    public class PlatosVM : INotifyPropertyChanged
    {
        public ObservableCollection<Plato> platos;

        public event PropertyChangedEventHandler PropertyChanged;

        public Pedido Pedidoa { get; set; }

        public PlatosVM(Pedido pedido)
        {
            this.Pedidoa = pedido;
        }

        public List<Tile> InicializarPlatos(Categoria categoria)
        {
            platos = BBDDService.GetPlatosFromCategoria(categoria);
            List<Tile> tiles = new List<Tile>();
            int index = 0;
            foreach (Plato item in platos)
            {
                Tile t = new Tile();
                t.Background = Brushes.Red;
                t.Height = 289;
                t.Width = 289;
                t.Margin = new Thickness(15);
                t.Command = CustomCommands.CargarInfoPlato;
                StackPanel sp = new StackPanel();
                Image i = new Image();
                i.Source = ImageConverter.LoadImage(item.imagenPlato);
                i.Width = 200;
                TextBlock tb = new TextBlock();
                tb.Text = item.nombrePlato;
                tb.Style = Application.Current.FindResource("FuenteYTamano") as Style;
                sp.Children.Add(i);
                sp.Children.Add(tb);
                t.Content = sp;
                t.Tag = index;
                tiles.Add(t);
                index++;
            }
            return tiles;
        }

        public void CargarCuenta()
        {
            Cuenta c = new Cuenta(Pedidoa);
            c.Show();
        }

        public void CargarInfoPlato(int index)
        {
            InfoPlato iP;
            if (platos.Count > 0)
                iP = new InfoPlato(platos[index], Pedidoa);
            else
                iP = new InfoPlato(new Plato(), Pedidoa);
            iP.Show();
        }

        public Pedido GetPedido()
        {
            return Pedidoa;
        }
    }
}
