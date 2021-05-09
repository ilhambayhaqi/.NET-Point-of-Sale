using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        ObservableCollection<Product> myproducts = new();
        ObservableCollection<Order> myorder = new();

        public string BaseDir = Directory.GetCurrentDirectory();
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            myproducts = GetProducts();
            ListViewOrder.ItemsSource = myorder;
            ListViewProducts.ItemsSource = myproducts;

        }

        private ObservableCollection<Product> GetProducts()
        {
            ObservableCollection<Product> myproducts = new();
            AppDbContext db = new();

            foreach (Product p in db.Products.ToList())
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

            bool canInsert = !myorder.Any(i => i.Product.Equals(selectedProduct));
            Order order = new(selectedProduct);
            if(canInsert) myorder.Add(order);
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
        }

        private void BtnRemoveOrder_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Order selectedOrder = btn.DataContext as Order;
            myorder.Remove(myorder.Where(i => i.Product.Equals(selectedOrder.Product)).Single());
        }
    }
}
