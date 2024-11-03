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
    /// Lógica de interacción para Historialexistente.xaml
    /// </summary>
    public partial class Historialexistente : Window
    {
        public Historialexistente()
        {
            InitializeComponent();
        }

        private void historialexiste(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cerrado(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
