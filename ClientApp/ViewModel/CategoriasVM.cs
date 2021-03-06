﻿using System;
using ClientApp.Model;
using ClientApp.Service;
using ClientApp.View;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.ComponentModel;


namespace ClientApp.ViewModel
{
    public class CategoriasVM : INotifyPropertyChanged
    {
        public Pedido Pedidoa { get; set; }
        public ObservableCollection<Categoria> categorias;

        public event PropertyChangedEventHandler PropertyChanged;

        public CategoriasVM()
        {                        
        }

        public void Inicializacion()
        {
            Pedidoa = new Pedido();            
        }

        public List<Tile> InicializarCategorias()
        {
            categorias = BBDDService.GetCategorias();
            List<Tile> tiles = new List<Tile>();
            int index = 0;
            foreach (Categoria item in categorias)
            {
                Tile t = new Tile();
                t.Background = Brushes.Red;
                t.Height = 289;
                t.Width = 289;
                t.Margin = new Thickness(15);
                t.Command = CustomCommands.CargarPlatos;
                StackPanel sp = new StackPanel();
                Image i = new Image();
                i.Width = 200;
                i.Source = ImageConverter.LoadImage(item.imagenCategoria);
                TextBlock tb = new TextBlock();
                tb.Text = item.nombreCategoria;
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

        public void CargarPlatos(int index)
        {

            //Pasar la categoria seleccionada
            //categorias[index]
            Platos p;
            if (categorias.Count > 0)
            {
                p = new Platos(categorias[index], Pedidoa);
            }
            else
                p = new Platos(new Categoria(), Pedidoa);            
            p.Show();
        }

        public void CargarCuenta()
        {
            Cuenta c = new Cuenta(Pedidoa);
            c.Show();
        }

        public Pedido GetPedido()
        {
            return Pedidoa;
        }
    }
}
