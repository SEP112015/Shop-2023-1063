using Shop.Customers.Application.Core;
using Shop.Customers.Application.Dtos.CustomersDtos;
using Shop.Customers.Application.Dtos.UsersDtos;
using Shop.Customers.Application.Exceptions;
using Shop.Customers.Application.Extentions;
using Shop.Customers.Application.Interfaces;
using Shop.Infrastructure.Logger.Interfaces;
using Shop.Modules.Domain.Interfaces;
using static Shop.Customers.Application.Extentions.ValidatorCUser;


namespace Shop.Customers.Application.Services
{
    public class UsersServices : IUsersServices
    {

        private readonly IUsersRepository _usersRepository;
        private readonly ILoggerService<UsersServices> _logger;

        public UsersServices(IUsersRepository usersRepository, ILoggerService<UsersServices> logger)
        {
            _usersRepository = usersRepository;
            _logger = logger;
        }


        public ServiceResult GetUsers()
        {
            var result = new ServiceResult();
            try
            {               
                    result.Data = _usersRepository.GetAll();
                    result.Success = true;
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los datos de los usuarios.";
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetUsersById(int id)
        {
            var result = new ServiceResult();

            try
            {
                if (id <= 0)
                {
                    result.Success = false;
                    result.Message = "ID del usuario inválido";
                    return result;
                }

                var customer = _usersRepository.GetEntityById(id);

                if (customer == null)
                {
                    result.Success = false;
                    result.Message = "Usuario no encontrado";
                    return result;
                }

                result.Data = customer;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el usuario";
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveUsers(UsersRemoveDto usersRemove)
        {
            var result = new ServiceResult();
            try
            {
                if (usersRemove == null)
                {
                    result.Success = false;
                    result.Message = "Este campo es requerido. ";
                    return result;
                }

                var users = usersRemove.ToEntityRemove();

                _usersRepository.Remove(users);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error eliminando los datos.";
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult SaveUsers(UsersSaveDto usersSave)
        {
            var result = new ServiceResult();

            try
            {
                result = EntityValidator<UsersSaveDto>.Validate(usersSave);
                if (!result.Success)
                {
                    return result;
                }

                var users = usersSave.SaveToUsersEntity();
                _usersRepository.Save(users);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error guardando los datos";
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult UpdateUsers(UsersUpdateDto usersUpdate)
        {
            var result = new ServiceResult();

            try
            {
                result = EntityValidator<UsersUpdateDto>.Validate(usersUpdate);
                if (!result.Success)
                {
                    return result;
                }

                var users = _usersRepository.GetEntityById(usersUpdate.UserId);

                if (users == null)
                {
                    result.Success = false;
                    result.Message = "Usuario no encontrado";
                    return result;
                }

                users.UpdateFromModel(usersUpdate);
                _usersRepository.Update(users);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando los datos.";
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
