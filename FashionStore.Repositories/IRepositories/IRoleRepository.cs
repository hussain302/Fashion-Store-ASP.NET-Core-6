
using FashionStore.Data.Users;

namespace FashionStore.Repositories.IRepositories
{
    public interface IRoleRepository
    {
        public List<Role> GetRoles();
        public Role GetRole(int id);
        public void AddRole(Role role);
        public void DeleteRole(int id);
        public void UpdateRole(Role role);

    }
}
