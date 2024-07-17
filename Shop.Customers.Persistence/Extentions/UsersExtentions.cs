using Shop.CUser.Persistence.Context;
using Shop.CUser.Persistence.Exception;
using Shop.Customers.Application.Dtos.UsersDtos;



namespace Shop.CUser.Persistence.Extentions
{
    public static class UsersExtentions
    {


        public static void UpdateFromModel(this Modules.Domain.Entities.Users user, UsersUpdateDto model)
        {

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
