using Shop.Customers.Application.Core;
using Shop.Customers.Application.Dtos.CustomersDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Customers.Application.Interfaces
{
    public interface ICustomersService
    {
        ServiceResult SaveCustomers(CustomersSaveDto customersSave);
        ServiceResult UpdateCustomers(CustomersUpdateDto customersUpdate);
        ServiceResult RemoveCustomers(CustomersRemoveDto customersRemove);
        ServiceResult GetCustomers();
        ServiceResult GetCustomersById(int custid);
    }
}
