using System;
using System.Collections.Generic;
using System.Text;

namespace MachineTest.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
