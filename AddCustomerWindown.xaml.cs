using AppHondaDuyDuc.Data;
using AppHondaDuyDuc.Model;
using System.Windows;


namespace AppHondaDuyDuc
{
    /// <summary>
    /// Interaction logic for AddCustomerWindown.xaml
    /// </summary>
    public partial class AddCustomerWindown : Window
    {
        public AddCustomerWindown()
        {
            InitializeComponent();
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var customerRepos = new CustomerRepos();
                /*
                string name = txtName.Text;
                string phone = txtPhone.Text;
                Address address = new Address(cbbVillage.Text, cbbWard.Text, cbbProvince.Text);

                Customer c = new Customer();
                c.Address = address;
                c.Name = name;
                c.PhoneNumber = phone;

                await customerRepos.AddCustomerAsync(c);

                MessageBox.Show($"Đã thêm thành công khách hàng: {name}");

                txtName.Clear();
                txtPhone.Clear();*/
            }
            catch { }
            finally
            {

            }
        }
    }
}
