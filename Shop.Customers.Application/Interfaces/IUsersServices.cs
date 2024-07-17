using Shop.Customers.Application.Core;
using Shop.Customers.Application.Dtos.UsersDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Customers.Application.Interfaces
{
    public interface IUsersServices
    {
        ServiceResult SaveUsers(UsersSaveDto usersSave);
        ServiceResult UpdateUsers(UsersUpdateDto usersUpdate);
        ServiceResult RemoveUsers(UsersRemoveDto usersRemove);
        ServiceResult GetUsers();
        ServiceResult GetUsersById(int id);

    }
}
