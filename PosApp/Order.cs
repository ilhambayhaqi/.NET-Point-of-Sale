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
        public int Quantity { get; set; }


        public float Subtotal { set; get; }
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
