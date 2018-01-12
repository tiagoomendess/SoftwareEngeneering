using BusinessLayer.Controllers;
using BusinessObjects;
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
    /// Interação lógica para Avaria_Publica.xam
    /// </summary>
    public partial class Avaria_Publica : Page
    {
        TipoAvaria tipo;

        public Avaria_Publica()
        {
            InitializeComponent();
            List<TipoAvaria> tipos = AvariaController.Tipos();
            ListaTipos.ItemsSource = tipos;

        }

        private void ListaContratos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListaTipos.SelectedItem != null)
                tipo = (ListaTipos.SelectedItem as TipoAvaria);
        }

        private void Registar_button(object sender, RoutedEventArgs e)
        {
            if (AvariaController.Add(descricao.Text, localDes.Text, tipo))
                this.NavigationService.Navigate(new Registar_Dados());
        }
    }
}
