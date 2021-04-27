using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.shopCart = shopCart;
            this.appDBContent = appDBContent;
        }


        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDBContent.Orders.Add(order);
            appDBContent.SaveChanges();

            var items = shopCart.ListShopItems;

            foreach (var item in items)
            {
                var orderDetails = new OrderDetail()
                {
                    CarId = item.Car.Id,
                    OrderId = item.Id,
                    Price = item.Price
                };

                appDBContent.OrderDetails.Add(orderDetails);
            }

            appDBContent.SaveChanges();
        }
    }
}
