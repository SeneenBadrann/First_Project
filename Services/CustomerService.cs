using First_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Project.Services
{
    internal class CustomerService
    {
        public List<Customer>customers;
        public CustomerService()
        {
            customers = new List<Customer>();
        }
        public void addCustomer(Customer customer)
        {
            customers.Add(customer);
        }
        public Customer signin()
        {
            Console.WriteLine("Please Enter Your Name");
            String name=Console.ReadLine();
            Console.WriteLine("Please Enter Your Email");
            String email=Console.ReadLine();
            var customer=customers.FirstOrDefault(x=>x.Email==email);
            if (customer != null && customer.Name.ToLower() == name.ToLower())
            {
                Console.WriteLine($"Your Name Is : {name} \n Your Id : {customer.Id}");
                return customer;
            }
           else
            {
                Console.WriteLine("You Must Signup");
                return null;
            }
        }
        public Customer signup()
        {
            Console.WriteLine("Please Enter Your Name");
            String name = Console.ReadLine();
            Console.WriteLine("Please Enter Your Email");
            String email = Console.ReadLine();
            Console.WriteLine("Please Enter Your Password");
            String password = Console.ReadLine();
            Customer customer = new Customer();
            customer.Email = email;
            customer.Name = name;
            customer.Password = password;
            customers.Add(customer);
            Console.WriteLine($"Your Name Is : {name} \n Your Id : {customer.Id}");
            return customer;
        }
        public Customer checkCustomer()
        {
            Console.WriteLine($"<<< Welcome To Shopping World >>>");
            Console.WriteLine();
            Console.WriteLine("Are You a New Customer ? (YES/NO)");
            String answer=Console.ReadLine();
            if (answer.ToUpper() == "YES") {
                    return signup();
            }
            else if (answer.ToUpper() == "NO")
            {
                return signin();
            }
            else
            {
                Console.WriteLine("Invalid Choice");
                return null;
            }
        }
    }
}
