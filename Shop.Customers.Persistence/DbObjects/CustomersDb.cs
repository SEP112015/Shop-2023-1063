using Shop.Customers.Persistence.Context;
using Shop.Customers.Persistence.Model;
using Shop.Customers.Persistence.Models;
using Shop.Customers.Persistence.Extentions;

namespace Shop.Customers.Persistence.DbObjects
{
    public class CustomersDb : ICustomersDb
    {
        private readonly ShopContext _shopContext;

        public CustomersDb(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public CustomersModel GetCustomers(int custid)
        {
            var customers = _shopContext.Customers.Find(custid).ConvertCustEntityCustomersModel();
            return customers;
        }

        public List<CustomersModel> GetCustomers()
        {
            return _shopContext.Customers
               .Select(customers => customers.ConvertCustEntityToCustomersModel())
               .ToList();
        }

        public void SaveCustomers(CustomersSaveModel customersSave)
        {
            Modules.Domain.Entities.Customers customerEntity = customersSave.ConvertCustomersSaveModelToCustomersEntity();
            _shopContext.Customers.Add(customerEntity);
            _shopContext.SaveChanges();
        }

        public void UpdateCustomers(CustomersUpdateModel updateModel)
        {
            var updatedCustomer = _shopContext.Customers.FirstOrDefault(c => c.custid == updateModel.custid);

            if (updatedCustomer != null)
            {
                updatedCustomer.UpdateFromModels(updateModel);
                _shopContext.Customers.Update(updatedCustomer);
                _shopContext.SaveChanges();
            }
        }

        public void RemoveCustomers(CustomersRemoveModel removeModel)
        {
            Modules.Domain.Entities.Customers customers = _shopContext.Customers.Find(removeModel.custid);

            var customer = _shopContext.ValidateCustomerExists(removeModel.custid);
            _shopContext.Customers.Remove(customer);
            _shopContext.SaveChanges();
        }
    }
}
