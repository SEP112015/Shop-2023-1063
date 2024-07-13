using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Customers.Application.Exceptions
{
    public class UsersServicesExceptions(string message) : Exception(message)
    {
        

    }
}
