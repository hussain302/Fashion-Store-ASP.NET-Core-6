using FashionStore.Data.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStore.Data.Users
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }
        public string? ImageURL { get; set; }

        [StringLength(255)]
        public string? Address { get; set; }


        //Role of this user like (IsAdmin, IsGuest)
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }



        public virtual ICollection<Order> Orders { get; set; }

        public bool? IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }


    }
}
