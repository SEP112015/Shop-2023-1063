using Microsoft.AspNetCore.Mvc;
using Shop.Customers.Application.Dtos.CustomersDtos;
using Shop.Customers.Application.Interfaces;

namespace Shop.CUser.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        /// <summary>
        /// Obtiene la lista de clientes.
        /// </summary>
        /// <returns>La lista de clientes.</returns>
        [HttpGet("GetCustomers")]
        public IActionResult Get()
        {
            var result = _customersService.GetCustomers();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Obtiene los detalles de un cliente por su ID.
        /// </summary>
        /// <param name="id">El ID del cliente.</param>
        /// <returns>Los detalles del cliente.</returns>
        [HttpGet("GetCustomersById")]
        public IActionResult Get(int id)
        {
         
            var result = _customersService.GetCustomersById(id);

            if (!result.Success)
                return BadRequest(result);
            else
            return Ok(result);
        }

        /// <summary>
        /// Guarda un nuevo cliente.
        /// </summary>
        /// <param name="customersSave">Los datos del nuevo cliente.</param>
        /// <returns>El resultado de la operación.</returns>
        [HttpPost("SaveCustomer")]
        public IActionResult SaveCustomer([FromBody] CustomersSaveDto customersSave)
        {
            if (customersSave == null)
            {
                return BadRequest(new { success = false, message = "Datos del cliente son requeridos" });
            }

            var result = _customersService.SaveCustomers(customersSave);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Actualiza los datos de un cliente.
        /// </summary>
        /// <param name="customersUpdate">Los datos actualizados del cliente.</param>
        /// <returns>El resultado de la operación.</returns>
        [HttpPut("UpdateCustomers")]
        public IActionResult UpdateCustomer([FromBody] CustomersUpdateDto customersUpdate)
        {
            if (customersUpdate == null)
            {
                return BadRequest(new { success = false, message = "Datos del cliente son requeridos" });
            }

            var result = _customersService.UpdateCustomers(customersUpdate);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Elimina un cliente.
        /// </summary>
        /// <param name="customersRemove">Los datos del cliente a eliminar.</param>
        /// <returns>El resultado de la operación.</returns>
        [HttpDelete("RemoveCustomers")]
        public IActionResult RemoveCustomer([FromBody] CustomersRemoveDto customersRemove)
        {
            if (customersRemove == null)
            {
                return BadRequest(new { success = false, message = "Datos del cliente son requeridos" });
            }

            var result = _customersService.RemoveCustomers(customersRemove);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
