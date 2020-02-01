using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.Model
{
    public class INotifyModelo
    {
        public partial class Categoria : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
        }

        public partial class Plato : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
        }

        public partial class Ingrediente : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
        }

        public partial class Pedido : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
}
