using FashionStore.Data.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStore.Data.Products
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
        public double  TotalPrice { get; set; }


        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }

        public int? UserId { get; set; }
        public virtual User? User { get; set; }

    }
}
