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

namespace ApplicationLayer.Views
{
    /// <summary>
    /// Interação lógica para Main.xam
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Registar_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Registar());
        }

        private void Login_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Login());
        }

        private void Log(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Loger());
        }
    }
}
