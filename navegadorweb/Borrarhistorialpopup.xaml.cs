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
    /// Lógica de interacción para Borrarhistorialpopup.xaml
    /// </summary>
    public partial class Borrarhistorialpopup : Window
    {
        public Borrarhistorialpopup()
        {
            InitializeComponent();
           
        }

        private void borradores(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cerrado(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
