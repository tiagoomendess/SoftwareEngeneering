using BusinessLayer.Controllers;
using System.Windows;
using System.Windows.Controls;

namespace ApplicationLayer.Views
{
    /// <summary>
    /// Interação lógica para Login.xam
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Button(object sender, RoutedEventArgs e)
        {
            if (UtilizadorController.Login(nif.Text, pass.Password.ToString()))
            {
                this.NavigationService.Navigate(new User());
            } else
            {
                MessageBox.Show("Login Incorrecto", "Quiosque", MessageBoxButton.OK);
                this.NavigationService.Navigate(new Login());
            }
            
        }
    }
}
