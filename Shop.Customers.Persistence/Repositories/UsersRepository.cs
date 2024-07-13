using Shop.Common.Data.Respository;
using Shop.Modules.Domain.Entities;
using Shop.Modules.Domain.Interfaces;
using System.Linq.Expressions;

namespace Shop.Customers.Persistence.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public bool Exists(Expression<Func<Modules.Domain.Entities.Users, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Modules.Domain.Entities.Users> GetAll()
        {
            throw new NotImplementedException();
        }

        public Modules.Domain.Entities.Users GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }

        public List<Modules.Domain.Entities.Users> GetUsersByUsersId(int UserId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Modules.Domain.Entities.Users entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Modules.Domain.Entities.Users entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Modules.Domain.Entities.Users entity)
        {
            throw new NotImplementedException();
        }
    }
}
