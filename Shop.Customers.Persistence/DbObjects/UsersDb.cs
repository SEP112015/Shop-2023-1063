using Shop.Customers.Persistence.Context;
using Shop.Customers.Persistence.Model;
using Shop.Customers.Persistence.Models;
using Shop.Customers.Persistence.Extentions;

namespace Shop.Customers.Persistence.DbObjects
{
    public class UsersDb : IUsersDb
    {
        private readonly ShopContext _shopContext;

        public UsersDb(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public UsersModel GetUsers(int UserId)
        {
            var user = _shopContext.Users.Find(UserId).ConvertUsersEntityUsersModel();
            return user;
        }

        public List<UsersModel> GetUsers()
        {
            return _shopContext.Users
                .Select(user => user.ConvertUsersEntityUsersModel())
                .ToList();
        }

        public void RemoveUser()
        {
            throw new NotImplementedException();
        }

        public void SaveUser(UsersSaveModel usersSave)
        {
            Modules.Domain.Entities.Users userEntity = usersSave.ConvertUsersSaveModelToUsersEntity();
            _shopContext.Users.Add(userEntity);
            _shopContext.SaveChanges();
        }

        public void UpdateUser(UsersUpdateModel usersModel)
        {
            Modules.Domain.Entities.Users userToUpdate = _shopContext.Users.Find(usersModel.UserId);

            if (userToUpdate != null)
            {
                userToUpdate.UpdateFromModel(usersModel);
                _shopContext.Users.Update(userToUpdate);
                _shopContext.SaveChanges();
            }
        }
    }
}
