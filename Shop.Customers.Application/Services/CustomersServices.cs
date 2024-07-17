using Shop.Customers.Application.Core;
using Shop.Customers.Application.Dtos.CustomersDtos;
using Shop.Customers.Application.Interfaces;
using Shop.Customers.Application.Extentions;
using Shop.Modules.Domain.Interfaces;
using Shop.Modules.Domain.Entities;
using Shop.Infrastructure.Logger.Interfaces;
using static Shop.Customers.Application.Extentions.ValidatorCUser;

namespace Shop.Customers.Application.Services
{
    public class CustomersServices : ICustomersService
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly ILoggerService<CustomersServices> _logger;

        public CustomersServices(ICustomersRepository customersRepository, ILoggerService<CustomersServices> logger)
        {
            _customersRepository = customersRepository;
            _logger = logger;
        }

        public ServiceResult GetCustomers()
        {
            var result = new ServiceResult();

            try
            {
                result.Data = _customersRepository.GetAll();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los datos de los clientes";
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetCustomersById(int id)
        {
            var result = new ServiceResult();

            try
            {
                if (id <= 0)
                {
                    result.Success = false;
                    result.Message = "ID del cliente inválido";
                    return result;
                }

                var customer = _customersRepository.GetEntityById(id);

                if (customer == null)
                {
                    result.Success = false;
                    result.Message = "Cliente no encontrado";
                    return result;
                }

                result.Data = customer;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el cliente";
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveCustomers(CustomersRemoveDto customersRemove)
        {
            var result = new ServiceResult();

            try
            {
                if (customersRemove == null)
                {
                    result.Success = false;
                    result.Message = "Datos del cliente son requeridos";
                    return result;
                }

                var customers = customersRemove.ToEntityRemove();

                _customersRepository.Remove(customers);
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

        public ServiceResult SaveCustomers(CustomersSaveDto customersSave)
        {
            var result = new ServiceResult();

            try
            {
                result = EntityValidator<CustomersSaveDto>.Validate(customersSave);
                if (!result.Success)
                {
                    return result;
                }

                var customers = customersSave.SaveToCustomersEntity();
                _customersRepository.Save(customers);
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

        public ServiceResult UpdateCustomers(CustomersUpdateDto customersUpdate)
        {
            var result = new ServiceResult();

            try
            {
                result = EntityValidator<CustomersUpdateDto>.Validate(customersUpdate);
                if (!result.Success)
                {
                    return result;
                }

                var customer = _customersRepository.GetEntityById(customersUpdate.custid);

                if (customer == null)
                {
                    result.Success = false;
                    result.Message = "Cliente no encontrado";
                    return result;
                }

                customer.UpdateFromModels(customersUpdate);
                _customersRepository.Update(customer);
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
