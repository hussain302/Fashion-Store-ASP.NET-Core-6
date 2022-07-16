using FashionStore.Data.Users;

namespace FashionStore.Repositories.IRepositories
{
    public interface IUserRepository
    {

        public List<User> GetUsers();
        public User GetUser(int id);
        public User GetUser(string name);
        public void AddUser(User user);
        public void DeleteUser(int id);
        public void UpdateUser(User user);
        public User VerifyUser(User user);
    }
}
