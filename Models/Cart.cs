using OnlineShopping11.Models;
using System;
using System.Collections.Generic;



namespace OnlineShopping11.Models
{
    public partial class Cart
    {
        /*public Cart()
        {
            Orders = new HashSet<Orders>();
        }*/

        public int Id { get; set; }
        public int UserId { get; set; }
        public int GarmentPrice { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        //public virtual ICollection<Orders> Orders { get; set; }
    }
}
