using BusinessLayer.Controllers;
using BusinessObjects;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ApplicationLayer.Views
{
    /// <summary>
    /// Interação lógica para Facturas.xam
    /// </summary>
    public partial class Facturas : Page
    {
        public Facturas()
        {
            InitializeComponent();
            List<Fatura> list = FaturaController.Index();
            ListaFaturas.ItemsSource = list;
        }

        private void Nova_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new FacturaView());
        }
    }
}
