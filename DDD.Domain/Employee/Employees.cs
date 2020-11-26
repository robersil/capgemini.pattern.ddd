using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.Employee
{
    public class Employees
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Position { get; set; }

        public Employees()
        {
        }
        public Employees(string name, string lastName, string position)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Position = position;
        }
    }
}
