
using OnlineShopping11.Models;
using System;
using System.Collections.Generic;



namespace OnlineShopping11.Models
{
    public partial class OrderedItems
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Clothesid { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Garments Clothes { get; set; }
        public virtual Orders Order { get; set; }
    }
}
