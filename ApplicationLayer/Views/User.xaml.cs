using BusinessLayer.Controllers;
using BusinessObjects;
using System.Windows;
using System.Windows.Controls;


namespace ApplicationLayer.Views
{
    /// <summary>
    /// Interação lógica para User.xam
    /// </summary>
    public partial class User : Page
    {
        Utilizador uti = UtilizadorController.Autencicado();

        public User()
        {
            InitializeComponent();           
            userName.Text = uti.Nome;
            nif.Text = uti.Nif;
        }

        private void Leitura_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Leituras());
        }

        private void Avaria_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Avarias());
        }

        private void Fatura_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Facturas());
        }

        private void Terminar(object sender, RoutedEventArgs e)
        {
            if (UtilizadorController.Logout(uti))
            {
                MessageBox.Show("Até já", "Quiosque");
                this.NavigationService.Navigate(new Main());
            }
            else
            {
                MessageBox.Show("Erro ao sair", "Quiosque", MessageBoxButton.OK);
                this.NavigationService.Navigate(new User());
            }
        }

        Utilizador GetInfo(string nif)
        {
            {
                Utilizador n = new Utilizador();

                return n;
            }
        }
    }
}