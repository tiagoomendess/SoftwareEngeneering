using BusinessLayer.Controllers;
using BusinessObjects;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ApplicationLayer.Views
{
    /// <summary>
    /// Interação lógica para Avarias.xam
    /// </summary>
    public partial class Avarias : Page
    {
        public Avarias()
        {
            InitializeComponent();
            List<Avaria> avarias = AvariaController.Index();
            ListaAvarias.ItemsSource = avarias;
        }

        private void NovaP_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Avaria_Publica());
        }

        private void NovaD_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Avaria_Domestica());
        }

        private void Voltar_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new User());
        }

        private void Resolver_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new User());
        }
    }
}
