using AppHondaDuyDuc.Database;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppHondaDuyDuc
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      GetAllData();
    }

    private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
    {
      AddCustomerWindown addCustomerWindown = new AddCustomerWindown();

      addCustomerWindown.Activate();
      addCustomerWindown.Show();
    }

    private async void GetAllData()
    {
        using (var customerRepos = new CustomerRepos())
        {
            var customers = await customerRepos.GetAllCustomersAsync();
            dgvCustomer.ItemsSource = customers;

        }

    }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetAllData();
        }
    }
}