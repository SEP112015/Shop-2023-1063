

using Shop.Modules.Domain.Interfaces;
using System.Linq.Expressions;


namespace Shop.Customers.Persistence.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        public bool Exists(Expression<Func<Modules.Domain.Entities.Customers, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Modules.Domain.Entities.Customers> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Modules.Domain.Entities.Customers> GetCustomerssByCustomersId(int custid)
        {
            throw new NotImplementedException();
        }

        public Modules.Domain.Entities.Customers GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Modules.Domain.Entities.Customers entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Modules.Domain.Entities.Customers entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Modules.Domain.Entities.Customers entity)
        {
            throw new NotImplementedException();
        }
    }
}
