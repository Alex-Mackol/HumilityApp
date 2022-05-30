using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaApp.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public ushort Count { get; set; }

        public string CartId { get; set; }

        public bool IsCheckout { get; set; } = false;

        public decimal TotalPrice { get; set; }

    }
}
