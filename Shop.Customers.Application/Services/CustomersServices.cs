using Shop.Customers.Application.Core;
using Shop.Customers.Application.Dtos.CustomersDtos;
using Shop.Customers.Application.Interfaces;
using Shop.Customers.Application.Extentions;
using Shop.Modules.Domain.Interfaces;
using Shop.Infrastructure.Logger.Interfaces;
using Shop.Customers.Application.Exceptions;
using Shop.Modules.Domain.Entities;

namespace Shop.Customers.Application.Services
{
    public class CustomersServices : ICustomersService
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly ILoggerService _logger;

        public CustomersServices(ICustomersRepository customersRepository, ILoggerService logger)
        {
            _customersRepository = customersRepository;
            _logger = logger;
        }

        public ILoggerService Logger { get; }

        public ServiceResult GetCustomers()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var customers = _customersRepository.GetAll();
                if (customers == null || !customers.Any())
                {
                    result.Success = false;
                    result.Message = "No se encontraron clientes.";
                    return result;
                }
                result.Data = customers;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los datos de los clientes.";
                _logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult GetCustomersById(int custid)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var customer = _customersRepository.GetEntityBy(custid);
                if (customer == null)
                {
                    result.Success = false;
                    result.Message = $"No se encontró el cliente con ID {custid}.";
                    return result;
                }
                result.Data = customer;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los datos del cliente.";
                _logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult RemoveCustomers(CustomersRemoveDto customersRemove)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (customersRemove is null)
                    throw new CustomersServicesExceptions("No se ha encontrado el cliente");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error eliminando los datos del cliente";
                _logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult SaveCustomers(CustomersSaveDto customersSave)
        {
            ServiceResult result = ValidatorCustomers<CustomersSaveDto>.Validate(customersSave, 50);
            if (!result.Success)
            {
                return result;
            }

            try
            {
                var customers = new Modules.Domain.Entities.Customers 
                {
                   custid = customersSave.custid, 
                    companyname = customersSave.companyname,
                    contactname = customersSave.contactname,
                    contacttitle = customersSave.contacttitle,
                    address = customersSave.address,
                    email = customersSave.email,
                    city = customersSave.city,
                    region = customersSave.region,
                    postalcode = customersSave.postalcode,
                    country = customersSave.country,
                    phone = customersSave.phone,
                    fax = customersSave.fax

                };
                _customersRepository.Save(customers);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error guardando los datos del cliente";
                _logger.LogError(ex, result.Message);           }
            return result;
        }

        public ServiceResult UpdateCustomers(CustomersUpdateDto customersUpdate)
        {
            ServiceResult result = ValidatorCustomers<CustomersUpdateDto>.Validate(customersUpdate, 50);
            if (!result.Success)
            {
                return result;
            }

            try
            {
                var existingCustomers = _customersRepository.GetEntityBy(customersUpdate.custid);

                existingCustomers.custid = customersUpdate.custid;
                existingCustomers.companyname = customersUpdate.companyname;
                existingCustomers.contactname = customersUpdate.contactname;
                existingCustomers.contacttitle = customersUpdate.contacttitle;
                existingCustomers.address = customersUpdate.address;
                existingCustomers.email = customersUpdate.email;
                existingCustomers.city = customersUpdate.city;
                existingCustomers.region = customersUpdate.region;
                existingCustomers.postalcode = customersUpdate.postalcode;
                existingCustomers.country = customersUpdate.country;
                existingCustomers.phone = customersUpdate.phone;
                existingCustomers.fax = customersUpdate.fax;
                _customersRepository.Update(existingCustomers);
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
