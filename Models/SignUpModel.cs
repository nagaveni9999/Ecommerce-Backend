
    using System;
    using System.Collections.Generic;

   
    namespace OnlineShopping11.Models
    {
        public partial class SignUpModel
        {
            /*public SignUpModel()
            {
                Orders = new HashSet<Orders>();
            }*/

    
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            

           // public virtual ICollection<Orders> Orders { get; set; }
        }
    }
