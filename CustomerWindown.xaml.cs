using AppHondaDuyDuc.Database;
using AppHondaDuyDuc.Model;
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
using System.Windows.Shapes;

namespace AppHondaDuyDuc
{
    /// <summary>
    /// Interaction logic for CustomerWindown.xaml
    /// </summary>
    public partial class CustomerWindown : Window
    {
        private Customer customer;
        private List<String> Villages { get; set; }
        private List<String> Wards { get; set; }
        private List<String> Provinces { get; set; }
        public CustomerWindown(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            this.txtName.Text = customer.Name;
            this.txtPhone.Text = customer.PhoneNumber;
            this.cbbProvinces.SelectedValue = customer.Address.Province;
            this.cbbWards.SelectedValue = customer.Address.Wards;
            this.cbbVillages.SelectedValue = customer.Address.Village;
            InitCBB();
        }

        private void InitCBB()
        {
            Villages = new List<string>
            {
                "Phú Hương",
                "Phương Trung",
                "Hoà Thạch",
                "Phước Lộc"
            };
            Wards = new List<string>
            {
                "Đại Đồng",
                "Đại Quang",
                "Đại Hồng",

            };
            Provinces = new List<string>
            {
                "Đại Lộc"
            };

            cbbVillages.ItemsSource = Villages;
            cbbWards.ItemsSource = Wards;
            cbbProvinces.ItemsSource = Provinces;
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string phone = txtPhone.Text;
            Address address = new Address(cbbVillages.Text, cbbWards.Text, cbbProvinces.Text);

            customer.Name = name;
            customer.PhoneNumber = phone;
            customer.Address = address;
            using(var customerRepos = new CustomerRepos())
            {
                await customerRepos.UpdateCustomer(customer);
            }
            MessageBox.Show("Cập nhật thông tin khách hàng thành công!");
        }
    }
}
