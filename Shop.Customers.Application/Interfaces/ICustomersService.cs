using Shop.Customers.Application.Core;
using Shop.Customers.Application.Dtos.CustomersDtos;
using Shop.Infrastructure.Logger.Interfaces;


namespace Shop.Customers.Application.Interfaces
{
    public interface ICustomersService

    { 
        ServiceResult SaveCustomers(CustomersSaveDto customersSave);
        ServiceResult UpdateCustomers(CustomersUpdateDto customersUpdate);
        ServiceResult RemoveCustomers(CustomersRemoveDto customersRemove);
        ServiceResult GetCustomers();
        ServiceResult GetCustomersById(int id);
       
    }
}
