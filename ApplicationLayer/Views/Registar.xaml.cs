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
    /// Interação lógica para Registar.xam
    /// </summary>
    public partial class Registar : Page
    {
        public Registar()
        {
            InitializeComponent();
        }

        private void PedirAcesso(object sender, RoutedEventArgs e)
        {
            if (UtilizadorController.PedirAcesso(nif.Text, email.Text))
            {
                MessageBox.Show("Pedido com sucesso", "Quiosque", MessageBoxButton.OK);
                this.NavigationService.Navigate(new Main());
            }
            else
            {
                MessageBox.Show("Erro no pedido", "Quiosque", MessageBoxButton.OK);
                this.NavigationService.Navigate(new Registar());
            }
        }

        private void RegistaDados(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Registar_Dados());
        }
    }
}
