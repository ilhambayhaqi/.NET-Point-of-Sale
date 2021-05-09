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

namespace PosApp
{
    /// <summary>
    /// Interaction logic for PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        List<Order> myorder = new();
        Invoice invoice = new();

        public PaymentWindow(List<Order> order)
        {
            InitializeComponent();

            myorder = order;
            calcInvoice();
            TbTotal.Text = invoice.TotalTax.ToString("C2");
        }
        private void btnCash_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TbAmount.Text)){
                MessageBox.Show("Amount Empty");
            } else
            {
                float amount = float.Parse(TbAmount.Text);
                float change = amount - invoice.TotalTax;

                if (change < 0) MessageBox.Show("Invalid Amound");
                else TbChange.Text= change.ToString("C2");
            }            
        }

        private void calcInvoice()
        {
            float total = 0;
            foreach (Order order in myorder)
            {
                total += order.Subtotal;
            }
            invoice.Total = total;
            invoice.Tax = 0.1f * total;
            invoice.TotalTax = invoice.Total + invoice.Tax;
        }
    }
}
