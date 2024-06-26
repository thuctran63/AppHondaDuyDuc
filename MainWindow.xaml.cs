using AppHondaDuyDuc.Database;
using AppHondaDuyDuc.Model;
using MongoDB.Bson.Serialization.Serializers;
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
            InitCBB();
        }

        private void InitCBB()
        {
            var options = new List<string>
            {
                "Tên",
                "Số điện thoại",
                "Địa chỉ"
            };

            cbbOptions.ItemsSource = options;
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

        private async void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCustomer = dgvCustomer.SelectedItem as Customer;
            if (selectedCustomer != null)
            {
                txtNameView2.Text = selectedCustomer.Name;
                txtPhoneView2.Text = selectedCustomer.PhoneNumber;
                using (var orderRepos = new OrderRepos())
                {
                    var orders = await orderRepos.GetAllOrderOfCustomer(selectedCustomer.Id);

                    dgvOrder.ItemsSource = orders.ToList();

                }
            }
        }

        private void dgvOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var order = dgvOrder.SelectedItem as Order;

            if (order != null)
            {
                OrderDetailWindown orderDetailWindown = new OrderDetailWindown(order);
                orderDetailWindown.Show();
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var option = cbbOptions.Text;

            if (option != null)
            {
                if (option == "Tên")
                {
                    using (var customerRepos = new CustomerRepos())
                    {
                        var listCustomer = await customerRepos.GetCustomerByName(txtSearch.Text);
                        dgvCustomer.ItemsSource = listCustomer.ToList();
                    }
                }

                if (option == "Số điện thoại")
                {
                    using (var customerRepos = new CustomerRepos())
                    {
                        var listCustomer = await customerRepos.GetCustomerByPhoneNumber(txtSearch.Text);
                        dgvCustomer.ItemsSource = listCustomer.ToList();
                    }
                }

                if (option == "Địa chỉ")
                {
                    using (var customerRepos = new CustomerRepos())
                    {
                        var listCustomer = await customerRepos.GetCustomerByAddress(txtSearch.Text);
                        dgvCustomer.ItemsSource = listCustomer.ToList();
                    }
                }
            }
        }
    }
}