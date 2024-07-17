using Shop.Common.Data.Respository;
using Shop.CUser.Persistence.Context;
using Shop.CUser.Persistence.Exception;
using Shop.CUser.Persistence.Extentions;
using Shop.Customers.Application.Exceptions;
using Shop.Modules.Domain.Entities;
using Shop.Modules.Domain.Interfaces;
using System.Linq.Expressions;

namespace Shop.CUser.Persistence.Repositories
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
            return _shopContext.Users.ToList();
        }


        public Users GetEntityById(int id)
        {
            var users = _shopContext.ValidateUserExists(id);
            if (users == null)
            {
                throw new UsersDbException($"ID no encontrado, {id}");
            }

            return users;

        }

        public List<Modules.Domain.Entities.Users> GetUsersByUsersId(int UserId)
        {
            var users = _shopContext.ValidateUserExists(UserId);

            if (users is null)
            {
                throw new CustomersDbException($"No se pudo encontrar el cliente con el id {UserId}");
            }
            var userList = new List<Modules.Domain.Entities.Users> { users };

            return userList;
        }

        public void Remove(Modules.Domain.Entities.Users entity)
        {
            var existingUser = _shopContext.ValidateUserExists(entity.Id);
            if (existingUser != null)
            {
                _shopContext.Users.Remove(existingUser);
                _shopContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("El usuario no existe.");
            }
        }

        public void Save(Modules.Domain.Entities.Users entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");
                }

                _shopContext.Users.Add(entity);
                _shopContext.SaveChanges();
            }
            catch
            {
                throw new CustomersServicesExceptions("Error al guardar el usuario.");
            }
        }

        public void Update(Modules.Domain.Entities.Users entity)
        {
            try
            {
                Modules.Domain.Entities.Users userUpdate = GetEntityById(entity.Id);

                if (entity == null)
                {
                    _shopContext.Users.Update(entity);
                    _shopContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentException(nameof(entity), "La entidad no puede ser nula");

                }

            }
            catch (System.Exception)
            {

                throw new CustomersDbException("Error al actualizar el usuario");
            }
        }


    }
}
