using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stock.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int StorageId { get; set;} //id склада
        public string Name { get; set; } // наименование товара 
        public string Quantity { get; set; } // количество товара 
        public string Typequantity { get; set; } // тип кг шт литр т 
        public string description { get; set;} //описание товара 
        public Storage Storage { set; get; }


    }
}
