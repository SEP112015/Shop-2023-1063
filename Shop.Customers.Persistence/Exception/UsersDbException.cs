using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Customers.Persistence.Exception
{
    public class UsersDbException : IOException
    {
        public UsersDbException(string message) : base(message)
        {

        }
    }
}
