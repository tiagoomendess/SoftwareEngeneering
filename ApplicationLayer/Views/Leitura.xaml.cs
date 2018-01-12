using BusinessLayer.Controllers;
using BusinessObjects;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace ApplicationLayer.Views
{
    /// <summary>
    /// Interação lógica para Leitura.xam
    /// </summary>
    public partial class Leitura : Page
    {
        Contrato contrato;

        public Leitura()
        {
            InitializeComponent();

            Utilizador uti = UtilizadorController.Autencicado();
            List<Contrato> items = ContratoController.TodasLeituras();
            ListaContratos.ItemsSource = items;
        }

        private void ListaContratos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListaContratos.SelectedItem != null)
                contrato = (ListaContratos.SelectedItem as Contrato);
        }

        private void Gravar_Button(object sender, RoutedEventArgs e)
        {
            if (LeituraController.Add(int.Parse(valor.Text), contrato) != null)
            {
                MessageBox.Show("Leitura realizada com sucesso", "Quiosque", MessageBoxButton.OK);
                this.NavigationService.Navigate(new Leituras());
            } else
            {
                MessageBox.Show("Ocorreu um erro, tente novamente", "Quiosque", MessageBoxButton.OK);
                this.NavigationService.Navigate(new Leituras());
            }                     
        }
    }

    
}
