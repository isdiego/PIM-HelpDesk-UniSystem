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
using UniSystemHelpDeskWPF.WebServiceUS;

namespace UniSystemHelpDeskWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                WebServiceUSSoapClient client = new WebServiceUSSoapClient();
                grid.ItemsSource = client.ConsultarChamado();
            }
            catch (Exception)
            {
                MessageBox.Show("Webservice Indisponivel");
            }
        }
        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "ExtensionData")
            {
                e.Column = null;
            }
            if (e.PropertyName == "DATA_FINALIZACAO_CHAMADO")
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
            if (e.PropertyName == "DATA_CRIACAO_CHAMADO")
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
        }
    }
}
