using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace Buzzword
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Coachella.SingleMinded _dataProvider;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            String connString = ConfigurationManager.ConnectionStrings["VadiKars"].ConnectionString;
            String provider = ConfigurationManager.ConnectionStrings["VadiKars"].ProviderName;

            _dataProvider = new Coachella.SingleMinded();
            _dataProvider.OpenConnection(provider, connString);
        }

        private void populateSimpleButton_Click(object sender, RoutedEventArgs e)
        {
            this.gridControl.ItemsSource = _dataProvider.GetAllRecords(TableNameTextEdit.Text);
        }

        private void GetDataViaReader()
        {
            
        }


        private void GetDataViaAdapter()
        {
            
        }

        private void connInfoSimpleButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
