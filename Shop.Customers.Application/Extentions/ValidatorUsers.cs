using Shop.Customers.Application.Core;
using Shop.Customers.Application.Dtos.CustomersDtos;
using Shop.Customers.Application.Dtos.UsersDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Customers.Application.Extentions
{
    public static class ValidatorUsers
    {
        public static UsersDto ConvertUsersEntityUsersModel(this Modules.Domain.Entities.Users users)
        {
            UsersDto usersModel = new UsersDto()
            {
                
                Email = users.Email,
                Password = users.Password,
                Name = users.Name
            };
            return usersModel;

        }

        public static UsersDto ConvertUsersEntityToUsersModel(this Modules.Domain.Entities.Users user)
        {
            return new UsersDto
            {
               
                Email = user.Email,
                Password = user.Password,
                Name = user.Name
            };
        }

        public static Modules.Domain.Entities.Users SaveToUsersEntity(this UsersSaveDto usersSave)
        {
            return new Modules.Domain.Entities.Users
            {
                
                Email = usersSave.Email,
                Password = usersSave.Password,
                Name = usersSave.Name
            };
        }

        public static void UpdateFromModel(this Modules.Domain.Entities.Users user, UsersUpdateDto model)
        {
           
            user.Email = model.Email;
            user.Password = model.Password;
            user.Name = model.Name;
        }



        public static Modules.Domain.Entities.Users ToEntityRemove(this UsersRemoveDto usersRemove)
        {
            return new Modules.Domain.Entities.Users
            {
               
                Email = usersRemove.Email,
                Password = usersRemove.Password,
                Name = usersRemove.Name
            };
        }


    }
}
