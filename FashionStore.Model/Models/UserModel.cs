
namespace FashionStore.Model.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string? LastName { get; set; }
      
        public string Email { get; set; }
   
        public string Password { get; set; }
        public string? ImageURL { get; set; }

        public string? Address { get; set; }
        public string Phone { get; set; }


        //Role of this user like (IsAdmin, IsGuest)
        public int RoleId { get; set; }
        public virtual RoleModel Role { get; set; }



        public virtual ICollection<OrderModel> Orders { get; set; }

        public bool? IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }


    }
}
