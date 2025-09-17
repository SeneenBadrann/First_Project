using First_Project.Models;
using First_Project.Services;

namespace First_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductService productService = new ProductService();
            CustomerService customerService = new CustomerService();

            productService.addProduct(new Product { Id = 1, Name = "Laptop", Price = 1000, Quantity = 4 });
            productService.addProduct(new Product { Id = 2, Name = "Phone", Price = 500, Quantity = 10 });
            productService.addProduct(new Product { Id = 3, Name = "Tablet", Price = 300, Quantity = 7 });

            Customer customer1= new Customer("Ali","ali@gmail.com",CustomerType.Vip);
            Customer customer2 = new Customer("Ahmad", "ahmad@gmail.com", CustomerType.Vip);

            customerService.addCustomer(customer1);
            customerService.addCustomer(customer2);

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;

            Customer customer = customerService.checkCustomer();

            CartService cartService = new CartService();
            OrderService orderService = new OrderService(cartService,productService);
            cartService.customer = customer;
            cartService.productService = productService;
            cartService.orderService = orderService;

            Order order = new Order(customer,cartService.cartItems);
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Choose from option");
                Console.WriteLine("1. Show All Product");
                Console.WriteLine("2. Add Item To Cart");
                Console.WriteLine("3. Remove Item From Cart");
                Console.WriteLine("4. Show Cart Items");
                Console.WriteLine("5. Confirm Order");
                Console.WriteLine("6. Show Your Order");
                Console.WriteLine("7. Cancel Order");
                Console.WriteLine("8. Print Bell");
                Console.WriteLine("9. Exist");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        productService.showAllProduct();
                        break;

                    case "2":
                            cartService.addToCart();
                        break;

                    case "3":
                        cartService.removeFromeCart();
                        break;

                    case "4":
                        cartService.showCart();
                        break;

                    case "5":
                        cartService.confirmOrder();
                        break;

                    case "6":
                        orderService.showOrder();
                        break;

                    case "7":
                        orderService.cancelOrder();
                        break;

                    case "8":
                        order.getBell();
                        break; ;

                    case "9":
                        return;

                    default:
                        Console.WriteLine("Invalid choice, try again!");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
