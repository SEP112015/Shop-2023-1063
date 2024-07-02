using Shop.Common.Data.Respository;
using Shop.Modules.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Modules.Domain.Interfaces
{
    public interface ICustomersRepository : IBaseRepository<Customers, int>
    {
        List<Users> GetCustomersByCustomersId(int custid);
    }
}
