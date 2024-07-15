using Shop.Common.Data.Respository;
using Shop.CUser.Persistence.Context;
using Shop.CUser.Persistence.Exception;
using Shop.Modules.Domain.Entities;
using Shop.Modules.Domain.Interfaces;
using System.Linq.Expressions;

namespace Shop.Customers.Persistence.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ShopContext _shopContext;
        public UsersRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public bool Exists(Expression<Func<Modules.Domain.Entities.Users, bool>> filter)
        {
            return _shopContext.Users.Any(filter);
        }

        public List<Modules.Domain.Entities.Users> GetAll()
        {
            return _shopContext.Users
                        .OrderByDescending(c => c.UserId)
                        .ToList();
        }

        public Modules.Domain.Entities.Users GetEntityBy(int id)
        {
            var users = _shopContext.Users.Find(id);
            if (users == null)
            {
                throw new UsersDbException($"ID no encontrado, {id}");
            }

            return users;
        }

        public List<Modules.Domain.Entities.Users> GetUsersByUsersId(int UserId)
        {
            var users = _shopContext.Users.Find(UserId);
            if (users == null)
            {
                throw new UsersDbException($"ID no encontrado, {UserId}");
            }
            var UsersList = new List<Users> { users };

            return UsersList;
        }

        public void Remove(Modules.Domain.Entities.Users entity)
        {
            var users = _shopContext.Users.Find(entity.custid);
            users = ValidarExistencia(entity.UserId);
            _shopContext.Users.Remove(users);
            _shopContext.SaveChanges();
        }

        public void Save(Modules.Domain.Entities.Users entity)
        {
            if (entity == null)
            {
                throw new UsersDbException(nameof(entity));
            }

            _shopContext.Users.Add(entity);
            _shopContext.SaveChanges();
        }

        public void Update(Modules.Domain.Entities.Users entity)
        {
            if (entity == null)
            {
                throw new UsersDbException(nameof(entity));
            }

            var category = _shopContext.Users.Find(entity.UserId);

            if (category == null)
            {
                throw new UsersDbException($"ID no encontrado, {entity.UserId}");
            }

            category.UserId = entity.UserId;
            category.Email = entity.Email;
            category.Password = entity.Password;
            category.Name = entity.Name;

            _shopContext.Users.Update(category);
            _shopContext.SaveChanges();
        }


        private Modules.Domain.Entities.Users ValidarExistencia(int UserId)
        {
            var users = _shopContext.Users.Find(UserId);
            return users;
        }
    }
}
