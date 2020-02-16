using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientApp.Model
{
    public static class CustomCommands
    {
        //Comandos implementados
        public static readonly RoutedUICommand CargarCategorias = new RoutedUICommand
        (
            "CargarCategorias",
            "CargarCategorias",
            typeof(CustomCommands),
            null
        );

        public static readonly RoutedUICommand CargarPlatos = new RoutedUICommand
        (
            "CargarPlatos",
            "CargarPlatos",
            typeof(CustomCommands),
            null
        );

        public static readonly RoutedUICommand CargarInfoPlato = new RoutedUICommand
        (
            "CargarInfoPlato",
            "CargarInfoPlato",
            typeof(CustomCommands),
            null
        );

        public static readonly RoutedUICommand Retroceder = new RoutedUICommand
        (
            "Retroceder",
            "Retroceder",
            typeof(CustomCommands),
            null
        );

        public static readonly RoutedUICommand AñadirPlato = new RoutedUICommand
            (
                "AñadirPlato",
                "AñadirPlato",
                typeof(CustomCommands)
            );

        public static readonly RoutedUICommand CargarCuenta = new RoutedUICommand
        (
            "CargarCuenta",
            "CargarCuenta",
            typeof(CustomCommands),
            null
        );

        public static readonly RoutedUICommand ConfirmarCuenta = new RoutedUICommand
        (
            "ConfirmarCuenta",
            "ConfirmarCuenta",
            typeof(CustomCommands),
            null
        );

        //Commandos no implementados
        public static readonly RoutedUICommand SeleccionarCategoria = new RoutedUICommand
        (
            "SeleccionarCategoria",
            "SeleccionarCategoria",
            typeof(CustomCommands),
            null
        );

        public static readonly RoutedUICommand SeleccionarPlato = new RoutedUICommand
        (
            "SeleccionarPlato",
            "SeleccionarPlato",
            typeof(CustomCommands),
            null
        );        

        
    }
}
