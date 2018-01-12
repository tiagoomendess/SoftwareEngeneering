using BusinessLayer.Controllers;
using System.Windows;
using System.Windows.Controls;


namespace ApplicationLayer.Views
{
    /// <summary>
    /// Interação lógica para Registar_Dados.xam
    /// </summary>
    public partial class Registar_Dados : Page
    {
        public Registar_Dados()
        {
            InitializeComponent();
        }

        private void Registar(object sender, RoutedEventArgs e)
        {
            if (UtilizadorController.DefinirPass(codigo.Text, pass1.Password.ToString(), pass2.Password.ToString()))
            {
                MessageBox.Show("Registo com sucesso", "Quiosque", MessageBoxButton.OK);
                this.NavigationService.Navigate(new Login());
            }
            else
            {
                MessageBox.Show("Erro no registo", "Quiosque", MessageBoxButton.OK);
                this.NavigationService.Navigate(new Main());
            }

            this.NavigationService.Navigate(new Registar_Dados());
        }

        private void Facebook(object sender, RoutedEventArgs e)
        {
            if (UtilizadorController.DefinirPass(codigo.Text,pass1.Password.ToString(), pass2.Password.ToString()))
            {
                MessageBox.Show("Registo com sucesso", "Quiosque", MessageBoxButton.OK);
                this.NavigationService.Navigate(new Login());
            }
            else
            {
                MessageBox.Show("Erro no registo", "Quiosque", MessageBoxButton.OK);
                this.NavigationService.Navigate(new Main());
            }

            this.NavigationService.Navigate(new Registar_Dados());
        }
    }
}
