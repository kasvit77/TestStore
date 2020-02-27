using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stock.Models
{
    public class Storage
    {
        public int Id { get; set; }
        public string Name { get; set; } // имя склада
        public string Address { get; set; } // адрес 
        public string Phone { get; set; }
        public string Manager { get; set;}
        public string description { get; set;}

        
    }
}
