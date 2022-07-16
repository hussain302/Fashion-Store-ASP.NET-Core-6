using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStore.Data.Products
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public bool? IsFeatured { get; set; }
        public string? ImageURL { get; set; }
        [Required]
        public double Price { get; set; }
        public string Fabric { get; set; }


        //Navigation property
        public virtual ICollection<Cart>  Carts { get; set; }


        //forigen key category of product like, men women etc
        public int CategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }


        //forigen key Type of product frock, shalwar kameez etc
        public int TypeId { get; set; }
        public virtual ProductType ProductType { get; set; }





        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }


    }
}
