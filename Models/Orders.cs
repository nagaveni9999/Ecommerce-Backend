using OnlineShopping11.Models;
using System;
using System.Collections.Generic;


namespace OnlineShopping11.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderedItems = new HashSet<OrderedItems>();
        }

        public int OrderId { get; set; }
        public int Id { get; set; }
        public int CartId { get; set; }
        public int Clothesid { get; set; }
        public string OrderNo { get; set; }
        public decimal OrderTotal { get; set; }
        public string OrderStatus { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Garments Clothes { get; set; }
        public virtual SignUpModel IdNavigation { get; set; }
        public virtual ICollection<OrderedItems> OrderedItems { get; set; }
    }
}
