using FashionStore.Data;
using FashionStore.Data.Users;
using FashionStore.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStore.Repositories.Repositores
{
    public class RoleRepository : IRoleRepository
    {
        private readonly FashionContext context;

        public RoleRepository(FashionContext context)
        {
            this.context = context;
        }

        public void AddRole(Role role)
        {
            context.Roles.Add(role);
            context.SaveChanges();
        }

        public void DeleteRole(int id)
        {
            var find = GetRole(id);
            context.Remove<Role>(find);
            context.SaveChanges();
        }

        public Role GetRole(int id)
        {
            return context.Find<Role>(id);
        }

        public List<Role> GetRoles()
        {
            return context.Roles.ToList();
        }

        public void UpdateRole(Role role)
        {
            context.Update(role);
            context.SaveChanges();
        }
    }
}
