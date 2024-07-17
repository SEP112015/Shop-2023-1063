using Microsoft.AspNetCore.Mvc;
using Shop.Customers.Application.Dtos.UsersDtos;
using Shop.Customers.Application.Interfaces;
using Shop.Customers.Application.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.CUser.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersServices _usersServices;

        public UsersController(IUsersServices usersServices)
        {

            _usersServices = usersServices;
        }


        [HttpGet("GetUser")]
        public IActionResult Get()
        {
            var result = _usersServices.GetUsers();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);

        }

        [HttpGet("GetUsersBy{id}")]
        public IActionResult Get(int id)
        {
            var result = _usersServices.GetUsersById(id);

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);

        }



        [HttpPost("SaveUser")]
        public IActionResult Post([FromBody] UsersSaveDto usersSave)
        {
            if (usersSave == null)
            {
                return BadRequest(new { success = false, message = "Datos del usuario son requeridos" });
            }

            var result = _usersServices.SaveUsers(usersSave);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateUser")]
        public IActionResult Put(UsersUpdateDto usersUpdate)
        {
            if (usersUpdate == null)
            {
                return BadRequest(new { success = false, message = "Datos del usuario son requeridos" });
            }

            var result = _usersServices.UpdateUsers(usersUpdate);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("RemoveUser")]
        public IActionResult Delete(UsersRemoveDto usersRemove)
        {
            if (usersRemove == null)
            {
                return BadRequest(new { success = false, message = "Datos del usuario son requeridos" });
            }

            var result = _usersServices.RemoveUsers(usersRemove);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
