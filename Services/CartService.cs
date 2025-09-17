using First_Project.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Project.Services
{
    internal class CartService
    {
        public List<(Product product,int quantity)> cartItems;
        public ProductService productService;
        public OrderService orderService;
        public Customer customer;
        public CartService()
        {
            cartItems = new List<(Product, int)>();

        }
        public void addToCart()
        {
            Console.WriteLine("Enter Product Id:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Quantity:");
            int quantity = int.Parse(Console.ReadLine());
            var product =productService.products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                Console.WriteLine("This Product Dosen't Exist");
                return;
            }
            if (product.Quantity < quantity && product.Quantity > 0)
            {
                Console.WriteLine("This Quantity Is Not Available");
                return;
            }
            var existInCart=cartItems.FirstOrDefault(x => x.product.Id == product.Id);
            if (existInCart.product == null)
            {
                cartItems.Add((product,quantity));
                Console.WriteLine($"{quantity} {product.Name} Added To Cart");
            }
            else
            {
                int newQuantity = existInCart.quantity + quantity;
                if (product.Quantity >= newQuantity)
                {
                    cartItems.Remove(existInCart);
                    cartItems.Add((product, newQuantity));
                    Console.WriteLine($"Updated {product.Name} Quantity To {newQuantity}");
                }
                else
                {
                    Console.WriteLine("This Quantity Is Not Available");
                    return;
                }
                
            }
        }

        public void removeFromeCart()
        {
            Console.WriteLine("Enter Product Id:");
            int id = int.Parse(Console.ReadLine());
            var item=cartItems.FirstOrDefault(x=>x.product.Id == id);
            if (item.product == null)
            {
                Console.WriteLine("This Product Not Exist");
                return;
            }
            else
            {
                productService.updateQuantity(item.product.Id, -item.quantity);
                Console.WriteLine($"Product {item.product.Name} Removed From Cart");
                cartItems.Remove(item);
            }
        }
        public void showCart()
        {
            if (cartItems.Count > 0)
            {
                Console.WriteLine("Cart Items");
                for (int i = 0; i < cartItems.Count; i++)
                {
                    Console.WriteLine($"#{i+1} {cartItems[i].product.Name}   {cartItems[i].quantity}   {cartItems[i].product.Price}");
                }
            }
            else
            {
                Console.WriteLine("This Cart Is Empty");
            }
        }
        public void confirmOrder()
        {
            if (cartItems.Count > 0)
            {
                orderService.createOrder(customer,cartItems);
                for (int i = 0; i < cartItems.Count; i++)
                {
                    productService.updateQuantity(cartItems[i].product.Id, cartItems[i].quantity);
                }
                Console.WriteLine("The Order Placed Successfully");
            }
            else
            {
                Console.WriteLine("Cart Is Empty");
                return;
            }
        }
    }
}