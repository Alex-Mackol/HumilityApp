using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DiplomaApp.Data.Data;
using DiplomaApp.Data.Models;
using DiplomaApp.Repositories.Interfaces;
using DiplomaApp.Repositories.Models;
using DiplomaApp.Services.Interfaces;
using DiplomaApp.Services.Models;

namespace DiplomaApp.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IProductUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OrderService(ApplicationContext context, IMapper mapper)
        {
            unitOfWork = new ProductUnitOfWork(context);
            this.mapper = mapper;
        }

        public void AddToCart(OrderDto order)
        {
            Order data = mapper.Map<Order>(order);

            ProductDto dto = order.ProductDto;
            Product product = new Product
            {
                Name = dto.Name,
                ImageUrl = dto.ImageUrl,
                IsAvailable = dto.IsAvailable,
                Price = dto.Price
            };
            

            data.ProductId = order.ProductDto.Id;

            unitOfWork.Orders.Create(data);
            unitOfWork.Save();
        }

        public void Delete(ushort id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDto> GetOrders(string id)
        {
            var data= unitOfWork.Orders.GetAll();

            var items = data.Where(x => x.CartId == id);

            List<Order> orders = new List<Order>(items);

            List<OrderDto> ordersDtos = new List<OrderDto>();

            for (int i = 0; i < orders.Count; i++)
            {
                ProductDto productDto = new ProductDto
                {
                    Name = orders[i].Product.Name,
                    ImageUrl = orders[i].Product.ImageUrl,
                    IsAvailable = orders[i].Product.IsAvailable,
                    Price = orders[i].Product.Price
                };

                ordersDtos.Add(mapper.Map<OrderDto>(orders[i]));

                ordersDtos[i].ProductDto = productDto;
            }
            
            return ordersDtos;
        }
    }
}
