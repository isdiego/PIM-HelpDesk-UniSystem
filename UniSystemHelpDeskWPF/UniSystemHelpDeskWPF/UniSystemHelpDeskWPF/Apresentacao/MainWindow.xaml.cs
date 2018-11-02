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

            //Alterar Nome das colunas datagridviewer
            if (e.PropertyName.StartsWith("TECNICO"))
                {
                    e.Column.Header = "Técnico";
                }
            if (e.PropertyName.StartsWith("STATUS_CHAMADO"))
            {
                e.Column.Header = "Status";
            }
            if (e.PropertyName.StartsWith("DATA_FINALIZACAO"))
            {
                e.Column.Header = "Data finalização";
            }
            if (e.PropertyName.StartsWith("DATA_CRIACAO_CHAMADO"))
            {
                e.Column.Header = "Data abertura";
            }
            if (e.PropertyName.StartsWith("CHAMADO"))
            {
                e.Column.Header = "Descrição de chamado";
            }
            if (e.PropertyName.StartsWith("ID_CHAMADO"))
            {
                e.Column.Header = "Cód chamado";
            }
            if (e.PropertyName.StartsWith("NOME_USUARIO"))
            {
                e.Column.Header = "Usuário";
            }
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal_Loaded(sender, e);
        }
    }
}
