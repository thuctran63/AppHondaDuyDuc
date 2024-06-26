using AppHondaDuyDuc.Model;
using System.Collections.ObjectModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Collections.Specialized;
using System.Diagnostics;
using AppHondaDuyDuc.Database;
using System.Windows.Media;


namespace AppHondaDuyDuc
{
    /// <summary>
    /// Interaction logic for AddCustomerWindown.xaml
    /// </summary>
    public partial class AddCustomerWindown : Window
    {
        private ObservableCollection<Product> Products { get; set; }

        private List<String> Villages { get; set; }
        private List<String> Wards { get; set; }
        private List<String> Provinces { get; set; }

        public AddCustomerWindown()
        {
            InitializeComponent();
            InitDataGridView();
            InitCBB();
        }

        private void InitDataGridView()
        {
            Products = new ObservableCollection<Product>
            {
                new Product()
            };
            dgvProducts.ItemsSource = Products;
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

        private void dgvProducts_LostFocus(object sender, RoutedEventArgs e)
        {
            // Cập nhập sum
            double sum = 0;
            foreach (Product p in Products)
            {
                if(p != null)
                {
                    sum += p.Price * p.Quantity;
                }
            }
            lbSum.Content = $"{sum} VND";
            
        }

        private double CalcSumOrder()
        {
            double sum = 0;
            foreach (Product p in Products)
            {
                if (p != null)
                {
                    sum += p.Price * p.Quantity;
                }
            }

            return sum;

        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var customerRepos = new CustomerRepos();

                string name = txtName.Text;
                string phone = txtPhone.Text;
                Address address = new Address(cbbVillages.Text, cbbWards.Text, cbbProvinces.Text);

                Customer c = new Customer();
                c.Address = address;
                c.Name = name;
                c.PhoneNumber = phone;

                

                if (CalcSumOrder() > 0)
                {
                    var orderRepos = new OrderRepos();

                    Order o = new Order();
                    o.Desciption = txtDescription.Text;
                    o.LicensePlates = txtlicensePlates.Text;
                    o.Products = Products.ToList();
                    o.UserId = c.Id;
                    o.Debt =  (Double.Parse(txtPay.Text) - CalcSumOrder()) < 0 ? Double.Parse(txtPay.Text) - CalcSumOrder() : 0;
                    o.Sum = CalcSumOrder();
                    o.NameOrder = txtNameOrder.Text;
                    o.Time = cbIsToday.IsChecked == true ? DateTime.Now.Date : datepicker.SelectedDate ?? DateTime.Now.Date;
                    
                    c.OrderIds.Add(o.Id.ToString());
                    await orderRepos.AddOrderAsync(o);
                }
                await customerRepos.AddCustomerAsync(c);
                
                MessageBox.Show($"Đã thêm thành công khách hàng: {name}");

                txtName.Clear();
                txtPhone.Clear();
                Products = new ObservableCollection<Product>
                {
                   new Product()
                };
            }
            catch(Exception ex) {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }
        }

        private void cbIsToday_Click(object sender, RoutedEventArgs e)
        {
            if(cbIsToday.IsChecked == true)
            {
                datepicker.SelectedDate = DateTime.Today;
                datepicker.Visibility = Visibility.Hidden;
            }
            else
            {
                datepicker.Visibility = Visibility.Visible;
            }
        }

        private void txtPay_lostFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void txtPay_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double debt = (Double.Parse(txtPay.Text) - CalcSumOrder());
                if (debt > 0)
                {
                    tbDebtOrChange.Content = "Tiền thừa: ";
                    tbValueDebtOrChange.Content = $"{debt} VND";
                    tbValueDebtOrChange.Foreground = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    tbDebtOrChange.Content = "Tiền nợ: ";
                    tbValueDebtOrChange.Content = $"{debt} VND";
                    tbValueDebtOrChange.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
            catch {
                tbValueDebtOrChange.Content = "0";
            }
            
        }
    }
}
