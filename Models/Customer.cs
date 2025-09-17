using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Project.Models
{
    public enum CustomerType { Vip, Normal }
    internal class Customer :User
    {
        static int idcount=0;
        public Customer(CustomerType customerType = CustomerType.Normal)
        {
            type = customerType;
            createAt = DateTime.Now;
            Id = idcount++;
            orders = new List<Order>();
        }
        public Customer(string name,String email,CustomerType customerType = CustomerType.Normal)
        {
            Email = email;
            Name = name;
            type = customerType;
            createAt = DateTime.Now;
            Id = idcount++;
            orders = new List<Order>();
        }
        public DateTime createAt { get; set; }
        public List<Order> orders { get; set; }
        public CustomerType type { get; set; }
        public override Role access()
        {
            return Role.Customer;
        }
    }
}
