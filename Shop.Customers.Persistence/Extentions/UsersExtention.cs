using Shop.Customers.Persistence.Context;
using Shop.Customers.Persistence.Exception;
using Shop.Customers.Persistence.Models;
using Shop.Modules.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Customers.Persistence.Extentions
{
    public static class UsersExtentions
    {
        public static UsersModel ConvertUsersEntityUsersModel(this Users users)
        {
            UsersModel usersModel = new UsersModel()
            {
                UserId = users.UserId,
                Email = users.Email,
                Password = users.Password,
                Name = users.Name
            };
            return usersModel;

        }

        public static UsersModel ConvertUsersEntityToUsersModel(this Users user)
        {
            return new UsersModel
            {
                UserId = user.UserId,
                Email = user.Email,
                Password = user.Password,
                Name = user.Name
            };
        }

        public static Users ConvertUsersSaveModelToUsersEntity(this UsersSaveModel usersSave)
        {
            return new Users
            {
                UserId = usersSave.UserId,
                Email = usersSave.Email,
                Password = usersSave.Password,
                Name = usersSave.Name
            };
        }

        public static void UpdateFromModel(this Users user, UsersUpdateModel model)
        {
            user.UserId = model.UserId;
            user.Email = model.Email;
            user.Password = model.Password;
            user.Name = model.Name;
        }

        public static Users ValidateUserExists(this ShopContext context, int UserId)
        {
            var users = context.Users.Find(UserId);
            if (users == null)
            {
                throw new UsersDbException("El usuario no está registrado");
            }
            return users;
        }


    }
}
