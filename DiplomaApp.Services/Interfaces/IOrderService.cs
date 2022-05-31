using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomaApp.Services.Models;

namespace DiplomaApp.Services.Interfaces
{
    public interface IOrderService
    {
        void AddToCart(OrderDto order);

        IEnumerable<OrderDto> GetOrders(string id);

        void Delete(ushort id);
    }
}
