

using Shop.Modules.Domain.Entities;
using Shop.Modules.Domain.Interfaces;
using System.Linq.Expressions;

namespace Shop.Customers.Persistence.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public bool Exists(Expression<Func<Users, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetAll()
        {
            throw new NotImplementedException();
        }

        public Users GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetUsersByUsersId(int UserId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Users entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Users entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Users entity)
        {
            throw new NotImplementedException();
        }
    }
}
