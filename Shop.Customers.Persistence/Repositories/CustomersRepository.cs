using Shop.CUser.Persistence.Context;
using Shop.CUser.Persistence.Exception;
using Shop.Modules.Domain.Entities;
using Shop.Modules.Domain.Interfaces;
using System.Linq.Expressions;


namespace Shop.CUser.Persistence.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly ShopContext _shopContext;
        public CustomersRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }
        public bool Exists(Expression<Func<Modules.Domain.Entities.Customers, bool>> filter)
        {
            return _shopContext.Customers.Any(filter);
        }

        public List<Modules.Domain.Entities.Customers> GetAll()
        {
            return _shopContext.Customers
                         .OrderByDescending(c => c.Id)
                         .ToList();
        }

        public List<Modules.Domain.Entities.Customers> GetCustomersByCustomersId(int custid)
        {
            var customers = _shopContext.Customers.Find(custid);
            if (customers == null)
            {
                throw new CustomersDbException($"ID no encontrado, {custid}");
            }
            var customersList = new List<Modules.Domain.Entities.Customers> { customers };

            return customersList;
        }

        public Modules.Domain.Entities.Customers GetEntityBy(int Id)
        {
            var customers = _shopContext.Customers.Find(Id);
            if (customers == null)
            {
                throw new CustomersDbException($"ID no encontrado, {Id}");
            }

            return customers;

        }

        public void Remove(Modules.Domain.Entities.Customers entity)
        {
            var customers = _shopContext.Customers.Find(entity.Id);
            customers = ValidarExistencia(entity.Id);
            _shopContext.Customers.Remove(customers);
            _shopContext.SaveChanges();
        }

        public void Save(Modules.Domain.Entities.Customers entity)
        {
            if (entity == null)
            {
                throw new CustomersDbException(nameof(entity));
            }

            _shopContext.Customers.Add(entity);
            _shopContext.SaveChanges();
        }

        public void Update(Modules.Domain.Entities.Customers entity)
        {
            if (entity == null)
            {
                throw new CustomersDbException(nameof(entity));
            }

            var customers = _shopContext.Customers.Find(entity.Id);

            if (customers == null)
            {
                throw new CustomersDbException($"ID no encontrado, {entity.Id}");
            }

            customers.custid = entity.custid;
            customers.companyname = entity.companyname;
            customers.contactname = entity.contactname;
            customers.contacttitle = entity.contacttitle;
            customers.address = entity.address;
            customers.email = entity.email;
            customers.city = entity.city;
            customers.region = entity.region;
            customers.postalcode = entity.postalcode;
            customers.country = entity.country;
            customers.phone = entity.phone;
            customers.fax = entity.fax;

            _shopContext.Customers.Update(customers);
            _shopContext.SaveChanges();
        }

        private Modules.Domain.Entities.Customers ValidarExistencia(int custid)
        {
            var customers = _shopContext.Customers.Find(custid);
            return customers;
        }

    }
}
