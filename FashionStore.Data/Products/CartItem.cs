using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStore.Data.Products
{
    public class CartItem
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public double ItemPrice { get; set; }
        public int? Quantity { get; set; }


    }
}
