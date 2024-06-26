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
    /// Interaction logic for OrderDetailWindown.xaml
    /// </summary>
    public partial class OrderDetailWindown : Window
    {
        private Order Order;
        public OrderDetailWindown(Order order)
        {
            this.Order = order;
            InitializeComponent();
            InitDataGridView();
        }

        private void InitDataGridView()
        {
            txtNameOrder.Text = Order.NameOrder;
            txtDate.Text = Order.Time.ToString();
            txtDebt.Text = Order.Debt.ToString();
            txtBienSoXe.Text = Order.LicensePlates.ToString();
            txtSum.Text = Order.Sum.ToString();
            txtDescription.Text = Order.Desciption.ToString();

            dgv.ItemsSource = Order.Products.ToList();
        }
    }
}
