using OnlineShopping11.Models;
using System;
using System.Collections.Generic;


namespace OnlineShopping11.Models
{
    public class Garments
    {

   
        public int Id { get; set; }
       
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public int Status { get; set; }

       
    }
}
