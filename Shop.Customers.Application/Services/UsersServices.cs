using Shop.Customers.Application.Core;
using Shop.Customers.Application.Dtos.CustomersDtos;
using Shop.Customers.Application.Dtos.UsersDtos;
using Shop.Customers.Application.Exceptions;
using Shop.Customers.Application.Extentions;
using Shop.Customers.Application.Interfaces;
using Shop.Infrastructure.Logger.Interfaces;
using Shop.Modules.Domain.Entities;
using Shop.Modules.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Customers.Application.Services
{
    public class UsersServices : IUsersServices
    {

        private readonly IUsersRepository _usersRepository;
        private readonly ILoggerService _logger;

        public UsersServices(IUsersRepository usersRepository, ILoggerService logger)
        {
            _usersRepository = usersRepository;
            _logger = logger;
        }


        public ServiceResult GetUsers()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var users = _usersRepository.GetAll();
                if (users == null || !users.Any())
                {
                    result.Success = false;
                    result.Message = "No se encontraron usuarios.";
                    return result;
                }
                result.Data = users;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los datos de los usuarios.";
                _logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult GetUsersById(int UserId)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var user = _usersRepository.GetEntityBy(UserId);
                if (user == null)
                {
                    result.Success = false;
                    result.Message = $"No se encontró el usuario con ID {UserId}.";
                    return result;
                }
                result.Data = user;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los datos del usuario.";
                _logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult RemoveUsers(UsersRemoveDto usersRemove)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (usersRemove is null)
                    throw new UsersServicesExceptions("No se ha encontrado el usuario");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error eliminando los datos del usuario";
                _logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult SaveUsers(UsersSaveDto usersSave)
        {
            ServiceResult result = ValidatorCustomers<CustomersSaveDto>.Validate(usersSave, 50);
            if (!result.Success)
            {
                return result;
            }

            try
            {
                var users = new Modules.Domain.Entities.Users
                {
                    UserId = usersSave.UserId,
                    Email = usersSave.Email,
                    Password = usersSave.Password,
                    Name = usersSave.Name


                };
                _usersRepository.Save(users);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error guardando los datos del cliente";
                _logger.LogError(ex, result.Message);
            }
            return result;

        }

        public ServiceResult UpdateUsers(UsersUpdateDto usersUpdate)
        {
            ServiceResult result = ValidatorUsers<UsersUpdateDto>.Validate(usersUpdate, 50);
            if (!result.Success)
            {
                return result;
            }

            try
            {
                var existingUsers = _usersRepository.GetEntityBy(usersUpdate.UserId);

                existingUsers.UserId = usersUpdate.UserId;
                existingUsers.Email = usersUpdate.Email;
                existingUsers.Password = usersUpdate.Password;
                existingUsers.Name = usersUpdate.Name;
                _usersRepository.Update(existingUsers);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando los datos del cliente";
                _logger.LogError(ex, result.Message);
            }
            return result;
        }
    }
}
