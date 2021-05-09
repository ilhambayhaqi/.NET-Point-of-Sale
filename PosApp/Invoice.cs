using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosApp
{
    class Invoice
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public float Subtotal { get; set; }
        public float Tax { get; set; }
        public float Total { get; set; }

        public Invoice()
        {
            Date = DateTime.Now.ToString("dddd, D");
            Tax = 0;
            Total = 0;
        }

    }
}
