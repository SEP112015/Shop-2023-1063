using Shop.CUser.Persistence.Context;
using Shop.CUser.Persistence.Exception;
using Shop.CUser.Persistence.Models;


namespace Shop.CUser.Persistence.Extentions
{
    public static class UsersExtentions
    {
        public static UsersModel ConvertUsersEntityUsersModel(this Modules.Domain.Entities.Users users)
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

        public static UsersModel ConvertUsersEntityToUsersModel(this Modules.Domain.Entities.Users user)
        {
            return new UsersModel
            {
                UserId = user.UserId,
                Email = user.Email,
                Password = user.Password,
                Name = user.Name
            };
        }

        public static Modules.Domain.Entities.Users ConvertUsersSaveModelToUsersEntity(this UsersSaveModel usersSave)
        {
            return new Modules.Domain.Entities.Users
            {
                UserId = usersSave.UserId,
                Email = usersSave.Email,
                Password = usersSave.Password,
                Name = usersSave.Name
            };
        }

        public static void UpdateFromModel(this Modules.Domain.Entities.Users user, UsersUpdateModel model)
        {
            user.UserId = model.UserId;
            user.Email = model.Email;
            user.Password = model.Password;
            user.Name = model.Name;
        }

        public static Modules.Domain.Entities.Users ValidateUserExists(this ShopContext context, int UserId)
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
