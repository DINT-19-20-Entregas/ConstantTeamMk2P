using ClientApp.Model;
using ClientApp.Service;
using ClientApp.View;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ClientApp.ViewModel
{
    public class PlatosVM
    {
        private Pedido pedido;
        public ObservableCollection<Plato> platos;

        public PlatosVM(Pedido pedido)
        {
            this.pedido = pedido;
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

        public void CargarInfoPlato(int index)
        {
            InfoPlato iP;
            if (platos.Count > 0)
                iP = new InfoPlato(platos[index], pedido);
            else
                iP = new InfoPlato(new Plato(), pedido);
            iP.Show();
        }
    }
}
