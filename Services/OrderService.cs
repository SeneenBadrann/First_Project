using First_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace First_Project.Services
{
    internal class OrderService
    {
        public List<Order> orders;
        public ProductService productService;
        public CartService cartService { get; set; }
        public OrderService(CartService cartService,ProductService productService) {
            orders = new List<Order>();
            this.cartService = cartService;
            this.productService = productService;
        }
        
        public void createOrder(Customer customer,List<(Product,int)> cartItems)
        {
            if (cartItems.Count != 0)
            {
                Order order = new Order(customer,cartItems);
                order.customer = customer;
                order.carts = cartItems;
                order.createAt = DateTime.Now;
                orders.Add(order);
                customer.orders.Add(order);
                Console.WriteLine($"Order {order.Id} created for {customer.Name}");
            }
            else
                Console.WriteLine("No Items To Make Order");
        }
        public List<Order> getCustomerOrders(Customer customer)
        {
            return orders.Where(x=>x.customer.Id==customer.Id).ToList();
        }
        public void showOrder()
        {
            if (orders.Count > 0)
            {
                Console.WriteLine("Order List");
                for (int i = 0; i < orders.Count; i++)
                {
                    Console.WriteLine($"Order Name {orders[i].Name} & Order Id {orders[i].Id}");
                }
            }
            else
                Console.WriteLine("No Order To Show");
        }
        public void cancelOrder()
        {
            Console.WriteLine("Enter Order Id:");
            int id = int.Parse(Console.ReadLine());
            var order=orders.FirstOrDefault(x=>x.Id==id);
            if (order == null)
            {
                Console.WriteLine("This Order Not Found");
                return;
            }
            else
            {
                for (int i = 0; i < cartService.cartItems.Count; i++)
                {
                    productService.updateQuantity(cartService.cartItems[i].product.Id, -cartService.cartItems[i].quantity);
                }
                orders.Remove(order);
                cartService.cartItems.Clear();
                Console.WriteLine($"The order {order.Name} has been cancelled");
            }
        }
    }
}
