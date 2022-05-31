using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaApp.Services.Models
{
    public class OrderDto
    {
        public int Id { get; set; }

        public ProductDto ProductDto { get; set; }

        public ushort Count { get; set; } = 1;

        public string CartId { get; set; }

        public bool IsCheckout { get; set; } = false;

        public decimal TotalPrice { get; set; }
    }
}
