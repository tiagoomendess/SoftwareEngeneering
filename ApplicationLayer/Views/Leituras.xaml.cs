using BusinessLayer.Controllers;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using BusinessObjects;

namespace ApplicationLayer.Views
{
    /// <summary>
    /// Interação lógica para Leituras.xam
    /// </summary>
    public partial class Leituras : Page
    {
        public Leituras()
        {
            InitializeComponent();
            List<BusinessObjects.Leitura> leituras = LeituraController.TodasLeituras();
            ListaLeituras.ItemsSource = leituras;

        }

        private void Nova(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Leitura());
        }
        private void Voltar(object sender, RoutedEventArgs e)
        {
            ListaLeituras.ItemsSource = null;
            this.NavigationService.Navigate(new User());
        }
    }
}
