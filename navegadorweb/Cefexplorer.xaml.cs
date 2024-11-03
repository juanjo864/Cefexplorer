using CefSharp.Wpf;
using CefSharp;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.ComponentModel;
using System.Drawing.Printing;
using CefSharp.DevTools.Network;
using System.Security.Policy;
using System.IO;
using System.Net;
using CefSharp.DevTools.Storage;
using System.Drawing;



namespace navegadorweb
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Cefexplorer : Window
    {
        private List<string> direccion = new List<string>();

        private string urlss;
        private MenuItem paginasweb;
        private String directorio;
        public Cefexplorer()
        {
            InitializeComponent();
            inicializar();


            histo.ItemsSource = direccion;
            urlss = buscador.Address;
            paginasweb = new MenuItem { Header = urlss };
            paginasweb.StaysOpenOnClick = true;
            cargarfavoritos();
            menuboton();


        }






        private async void inicializar()
        {
            try
            {

                if (!Cef.IsInitialized)
                {
                    CefSettings inicializacion = new CefSettings();


                    await Task.Run(() =>
                    {
                        Cef.Initialize(inicializacion);
                    });

                }

            }
            catch (InvalidOperationException ex)
            {

                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (DllNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        private void recargar(object sender, RoutedEventArgs e)
        {
            buscador.Reload(true);
        }
        //inicio
        private void inicio_click(object sender, RoutedEventArgs e)
        {
            buscador.Load("www.google.es");
        }
        private void buscarenter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                buscador.Load(urls.Text);
            }
        }


        private void adelante_click(object sender, RoutedEventArgs e)
        {
            if (buscador.CanGoForward)
            {
                buscador.Forward();
            }
        }

        private void atras_click(object sender, RoutedEventArgs e)
        {
            if (buscador.CanGoBack)
            {
                buscador.Back();
            }
        }





        private void history_click(object sender, RoutedEventArgs e)
        {
            if (histo.Visibility == Visibility.Visible)
            {

                histo.Visibility = Visibility.Collapsed;
            }
            else
            {
                histo.Visibility = Visibility.Visible;
            }
        }

        private void cargarurl(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading)
            {
                Dispatcher.BeginInvoke(new Action(() =>
                    {
                        if (!direccion.Contains(buscador.Address))
                        {
                            direccion.Add(buscador.Address);
                        }

                    }));
            }
        }

        private async void borrarhistrial(object sender, RoutedEventArgs e)
        {

            var cookies = Cef.GetGlobalCookieManager();
            cookies.DeleteCookies("", "");
            var caches = buscador.GetDevToolsClient();
            await caches.Storage.ClearDataForOriginAsync("*", "cache,local_storage");
           
           
           Borrarhistorialpopup borrado=new Borrarhistorialpopup();
            borrado.Show();

      
            direccion.Clear();
        }
      
        private void imprimir_click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (buscador != null)
                {
                    PrintDialog printDialog = new PrintDialog();
                    if (printDialog.ShowDialog() == true)
                    {
                        printDialog.PrintVisual(buscador, "impresion");
                    }

                }
            }
            catch (PrintDialogException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidPrinterException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void urltexbox(object sender, DependencyPropertyChangedEventArgs e)
        {
            urls.Text = buscador.Address;
        }

        private void acercade_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("este es un navegador web con cefshrpbrowser y xaml");
        }

        private void favoritos_click(object sender, RoutedEventArgs e)
        {
            try
            {
            
                histo.ItemsSource = direccion;
                urlss = buscador.Address;
                //cambia el item a menutiem que hay en favoritoss y con el lambda verifica si es verdad no
                bool existe = favoritoss.Items.Cast<MenuItem>().Any(item => item.Header.ToString() == urlss);
                if (!existe)
                {
                    paginasweb = new MenuItem { Header = urlss };
                    paginasweb.Click += (s, args) => navegar(urlss);
                    paginasweb.ContextMenu = (ContextMenu)this.FindResource("menus");
                    favoritoss.Items.Add(paginasweb);
                    guardar();
                    //MessageBox.Show("guardado a favoritos", "guardar historial", MessageBoxButton.OK, MessageBoxImage.Information);
                    Guardadodehistorialpopup guardadohis=new Guardadodehistorialpopup();
                    guardadohis.Show();
                }
                else
                {
                   Historialexistente existes=new Historialexistente();
                    existes.Show();
                }
            
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

           
        }
        private void menuboton()
        {
            foreach (var item in favoritoss.Items)
            {
                if (item is MenuItem menuItem)
                {

                    menute(menuItem);
                }
            }
        }
        private void menute(MenuItem menusa)
        {
            menusa.PreviewMouseRightButtonDown += menuses;
        }
        private void menuses(object sender, MouseButtonEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;

            if (menuItem != null)
            {
                ContextMenu contextMenu = new ContextMenu();
                MenuItem eliminarItem = new MenuItem { Header = "eliminar" };
                eliminarItem.Click += eliminare;
                contextMenu.Items.Add(eliminarItem);
                menuItem.ContextMenu = contextMenu;
                contextMenu.PlacementTarget = menuItem;
                contextMenu.IsOpen = true;
            }

        }
        private void eliminare(object sender, RoutedEventArgs e)
        {
            try
            {
                MenuItem subitem = sender as MenuItem;
                if (subitem != null)
                {
                    ContextMenu submenu = subitem.Parent as ContextMenu;
                    if (submenu != null)
                    {
                        MenuItem itemprincipal = submenu.PlacementTarget as MenuItem;
                        if (itemprincipal != null)
                        {
                            string url = itemprincipal.Header.ToString();
                            favoritoss.Items.Remove(itemprincipal);
                            directorio = Directory.GetCurrentDirectory() + "/favoritos.csv";
                            List<string> celdas = File.ReadAllLines(directorio).ToList();
                            if (celdas.Remove(url))
                            {
                                File.WriteAllLines(directorio, celdas);
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void navegar(string urlss)
        {
            if (!string.IsNullOrEmpty(urlss))
            {
                buscador.Address = urlss;
            }
        }

        private void stop(object sender, RoutedEventArgs e)
        {
            buscador.Stop();
        }


        private void cargarfavoritos()
        {
            try
            {
                directorio = Directory.GetCurrentDirectory() + "/favoritos.csv";
                if (File.Exists(directorio))
                {
                    using (StreamReader leer = new StreamReader(directorio))
                    {
                        while (leer.Peek() >= 0)
                        {
                            urlss = leer.ReadLine();
                            paginasweb = new MenuItem { Header = urlss };

                            favoritoss.Items.Add(paginasweb);
                            paginasweb.Click += (s, args) => navegar(urlss);

                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void guardar()
        {
            try
            {
                directorio = Directory.GetCurrentDirectory() + "/favoritos.csv";
                using (StreamWriter escribir = new StreamWriter(directorio))
                {
                    foreach (MenuItem favo in favoritoss.Items)
                    {
                        escribir.WriteLine(favo.Header.ToString());
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
        private void codigofuentes(object sender, RoutedEventArgs e)
        {
            buscador.ShowDevTools();
        }


    }
}
