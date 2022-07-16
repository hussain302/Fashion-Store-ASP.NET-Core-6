using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStore.Data.Products
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        //navigation property
        public virtual ICollection<Product> Products { get; set; }


        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
