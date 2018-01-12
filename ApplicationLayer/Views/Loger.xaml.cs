using BusinessLayer.Controllers;
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
    /// Interação lógica para Loger.xam
    /// </summary>
    public partial class Loger : Page
    {
        public Loger()
        {
            InitializeComponent();
            List<string> list = UtilizadorController.GetLog();
            ListaLog.ItemsSource = list;
        }

        private void Voltar(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Main());
        }
    }
}
