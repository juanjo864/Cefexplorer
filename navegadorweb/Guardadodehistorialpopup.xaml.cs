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

namespace navegadorweb
{
    /// <summary>
    /// Lógica de interacción para Guardadodehistorialpopup.xaml
    /// </summary>
    public partial class Guardadodehistorialpopup : Window
    {
        public Guardadodehistorialpopup()
        {
            InitializeComponent();
        }

        private void guardadohistorial(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
