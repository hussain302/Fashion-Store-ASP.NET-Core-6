using FashionStore.Data;
using FashionStore.Data.Users;
using FashionStore.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FashionStore.Repositories.Repositores
{
    public class UserRepository : IUserRepository
    {
        private readonly FashionContext context;
        public UserRepository(FashionContext context)
        {
            this.context = context;
        }
        public void AddUser(User user)
        {
            user.CreatedBy = user.FirstName;
            user.CreatedAt = DateTime.Now;

            context.Users.Add(user);
            context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var find = GetUser(id);
            context.Users.Remove(find);
        }

        public List<User> GetUsers()
        {
            return context.Users.Include(x => x.Role).OrderBy(x => x.Id).ToList();
        }
        public User GetUser(int id)
        {
            return context.Users.Include(x => x.Role).Where(x => x.Id == id).FirstOrDefault();
        }

        public User GetUser(string name)
        {
            return context.Users
                .Where(x => x.FirstName == name).FirstOrDefault();
        }

        public void UpdateUser(User user)
        {
            context.Update(user);
            context.SaveChanges();
        }

        public User VerifyUser(User user)
        {
            try{
                var found = context.Users.Where(x => x.Email == user.Email && x.Password == user.Password).First();

                if (found != null) return found;
                else return null;
            }
            catch{
                return null;
            }
        }
    }
}
