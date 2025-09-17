using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Project.Models
{
    internal class Cart
    {
        public int Id { get; set; }                  
        public Customer customer { get; set; }              
        public List<Product> products { get; set; } 
        public DateTime CreatedAt { get; set; }
    }
}
