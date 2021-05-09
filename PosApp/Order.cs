using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosApp
{
    public class Order : INotifyPropertyChanged
    {
        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                NotifyPropertyChanged("Quantity");
            }
        }

        private float subtotal;
        public float Subtotal
        {
            get { return subtotal; }
            set
            {
                subtotal = value;
                NotifyPropertyChanged("Subtotal");
            }
        }
        public Product Product { set; get; }

        public Order(Product product)
        {
            Quantity = 1;
            Product = product;
            Subtotal = CalcSubtotal();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public float CalcSubtotal()
        {
            return Product.Price * Quantity;
        }

    }
}
