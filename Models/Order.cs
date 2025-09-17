using First_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Project.Models
{
    internal class Order
    {
        Dictionary<CustomerType, double> customerDiscount = new Dictionary<CustomerType, double>
        {
            { CustomerType.Normal,0.2},
            { CustomerType.Vip,0.3 }
        };
        static int counter = 0;
        public Order(Customer customer, List<(Product, int)> cartItems) {
            createAt = DateTime.Now;
            Id =counter++;
            this.customer = customer;
            this.carts = cartItems;
        }
        public List<(Product product, int quantity)> carts;
        public int Id = 0;
        public string Name { get; set; }
        public string Description { get; set; }
        public Customer customer { get; set; }
        public DateTime createAt { get; set; }
        public void getBell()
        {
            double total = 0;
            CustomerType type = customer.type;
            double discount = customerDiscount[type];
            int i = 0;
            Console.WriteLine($"The Bill For Customer {customer.Name}  : ");
            foreach (var cart in carts)
            {
                Console.WriteLine($"{++i}.Product With Name {cart.product.Name} With Id {cart.product.Id} With Price {cart.product.Price} With Quantity {cart.quantity}");
                total += (cart.product.Price * cart.quantity);
            }
            double totalAfterDiscount=total-(total*discount);
            Console.WriteLine($"Total Price : {total}");
            Console.WriteLine($"Your Dicount : {discount}");
            Console.WriteLine($"Your Final Total After Discount Is : {totalAfterDiscount}");
        }
    }
}
