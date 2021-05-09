using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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


namespace PosApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged, INotifyCollectionChanged
    {
        Invoice invoice = new();
        private ObservableCollection<Product> myproducts = new();
        private ObservableCollection<Order> myorder = new();

        public string BaseDir = Directory.GetCurrentDirectory();
        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        int menuId = 1;

        public MainWindow()
        {

            InitializeComponent();
            DataContext = invoice;
            
            myproducts = GetProducts();

            using (AppDbContext db = new())
            {
                ListViewCategory.ItemsSource = db.Categories.ToList();
            }
            
            ListViewProducts.ItemsSource = myproducts;
            ListViewOrder.ItemsSource = myorder;
            tbDate.Text = invoice.Date;

            calcInvoice();
        }

        private ObservableCollection<Product> GetProducts()
        {
            AppDbContext db = new();
            foreach (Product p in db.Products.Where(x => x.Category == menuId).ToList())
            {
                p.Image = BaseDir + "/Assets/" + p.Image;
                myproducts.Add(p);
            }
            return myproducts;
        }

        private void Btn_Product_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Product selectedProduct = btn.DataContext as Product;

            bool canInsert = !myorder.Any(i => i.Product.Id == selectedProduct.Id);
            Order order = new(selectedProduct);
            if(canInsert) myorder.Add(order);
            calcInvoice();
        }

        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Order selectedOrder = btn.DataContext as Order;
            if (selectedOrder.Quantity > 1)
            {
                selectedOrder.Quantity -= 1;
                selectedOrder.Subtotal = selectedOrder.CalcSubtotal();
            }
            calcInvoice();
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Order selectedOrder = btn.DataContext as Order;
            if (selectedOrder.Quantity < 99)
            {
                selectedOrder.Quantity += 1;
                selectedOrder.Subtotal = selectedOrder.CalcSubtotal();
            }
            calcInvoice();
        }

        private void BtnRemoveOrder_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Order selectedOrder = btn.DataContext as Order;
            myorder.Remove(myorder.Where(i => i.Product.Equals(selectedOrder.Product)).Single());
            calcInvoice();
        }

        private void calcInvoice()
        {
            float total = 0;
            foreach(Order order in myorder){
                total += order.Subtotal;
            }
            invoice.Total = total;
            invoice.Tax = 0.1f * total;
            invoice.TotalTax = invoice.Total + invoice.Tax;
            //Debug.WriteLine(invoice.TotalTax.ToString());
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            int count = myorder.Count;
            for (int i=0; i < count; i++)
            {
                myorder.RemoveAt(0);
            }
            calcInvoice();
        }

        private void btnPayment_Click(object sender, RoutedEventArgs e)
        {
            PaymentWindow paymentWindow = new(myorder.ToList());
            paymentWindow.Show();
        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Category selectedCategory = btn.DataContext as Category;
            menuId = selectedCategory.Id;

            int count = myproducts.Count;
            for (int i = 0; i < count; i++)
            {
                myproducts.RemoveAt(0);
            }
            ObservableCollection<Product> temp = GetProducts();
        }
    }
}
