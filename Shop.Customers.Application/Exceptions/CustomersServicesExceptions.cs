using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Customers.Application.Exceptions
{
    public class CustomersServicesExceptions(string message) : Exception(message)
    {
    }
}
