using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Project.Models
{
    internal class Employee : User
    {
        public int salary { get; set; }
        public override Role access()
        {
            return Role.Employee;
        }

    }
}
