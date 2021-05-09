using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosApp
{
    class Invoice : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Date { get; set; }

        private float total;
        public float Total 
        {
            get { return total; }
            set
            {
                total = value;
                NotifyPropertyChanged("Total");
            }
        }
        public float tax;
        public float Tax
        {
            get { return tax; }
            set
            {
                tax = value;
                NotifyPropertyChanged("Tax");
            }
        }

        private float totaltax;
        public float TotalTax 
        {
            get { return totaltax; }
            set
            {
                totaltax = value;
                NotifyPropertyChanged("TotalTax");
            }
        }

        public Invoice()
        {
            Date = DateTime.Now.ToString("dddd, D");
            Total = 0;
            Tax = 0;
            TotalTax = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }
}
