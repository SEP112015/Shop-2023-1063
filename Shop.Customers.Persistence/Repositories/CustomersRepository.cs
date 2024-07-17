using Shop.CUser.Persistence.Context;
using Shop.CUser.Persistence.Exception;
using Shop.CUser.Persistence.Extentions;
using Shop.Customers.Application.Exceptions;
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
            return _shopContext.Customers.ToList();
        }

        public List<Modules.Domain.Entities.Customers> GetCustomersByCustomersId(int custid)
        {
            var customers = _shopContext.ValidateCustomerExists(custid);

            if (customers is null)
            {
                throw new CustomersDbException($"No se pudo encontrar el cliente con el id {custid}");
            }
            var customersList = new List<Modules.Domain.Entities.Customers> { customers };

            return customersList;
        }

        public Modules.Domain.Entities.Customers GetEntityById(int id)
        {
            var customers = _shopContext.ValidateCustomerExists(id);
            if (customers == null)
            {
                throw new CustomersDbException($"ID no encontrado, {id}");
            }

            return customers;
            

        }


        public void Remove(Modules.Domain.Entities.Customers entity)
        {
            var exitstingCustomers = _shopContext.ValidateCustomerExists(entity.Id);
            if (exitstingCustomers != null)
            {
                _shopContext.Customers.Remove(exitstingCustomers);
                _shopContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("El cliente no existe.");
            }
        }

     

        public void Save(Modules.Domain.Entities.Customers entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");
                }

                _shopContext.Customers.Add(entity);
                _shopContext.SaveChanges();
            }
            catch
            {
                throw new CustomersServicesExceptions("Error al guardar el cliente.");
            }
        }

      

        public void Update(Modules.Domain.Entities.Customers entity)
        {


            try
            {
                Modules.Domain.Entities.Customers customersUpdate = GetEntityById(entity.Id);

                if (entity == null)
                {
                    _shopContext.Customers.Update(entity);
                    _shopContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentException(nameof(entity), "La entidad no puede ser nula");

                }
              
            }
            catch (System.Exception)
            {

                throw new CustomersDbException("Error al actualizar el cliente");
            }
            
        }


    }
}
