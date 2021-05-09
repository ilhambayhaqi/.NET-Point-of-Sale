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
    /// Interaction logic for InvoiceWindow.xaml
    /// </summary>
    public partial class InvoiceWindow : Window
    {
        public InvoiceWindow(List<Order> order, float subtotal, float tax, float total, string amount, string charge)
        {
            InitializeComponent();

            ListViewInvoice.ItemsSource = order;
            tbDate.Text = new Invoice().Date;
            tbSubtotal.Text = subtotal.ToString("C");
            tbTax.Text = tax.ToString("C");
            tbTotal.Text = total.ToString("C");
            tbAmount.Text = float.Parse(amount).ToString("C");
            tbChange.Text = charge;

            this.IsEnabled = false;
            PrintDialog printDialog = new();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(print, "Invoice");
            }
        }
    }
}
