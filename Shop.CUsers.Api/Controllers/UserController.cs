using Microsoft.AspNetCore.Mvc;
using Shop.Customers.Application.Dtos.UsersDtos;
using Shop.Customers.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.CUsers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersServices _usersServices;

        public UserController(IUsersServices usersServices)
        {

            _usersServices = usersServices;
        }


        [HttpGet("GetUser")]
        public IActionResult Get()
        {
            var result = _usersServices.GetUsers();

            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }

        }

        [HttpGet("GetUsersBy{id}")]
        public IActionResult Get(int id)
        {
            var result = _usersServices.GetUsersById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }

        }



        [HttpPost("SaveUser")]
        public IActionResult Post([FromBody] UsersSaveDto usersSave)
        {
            var result = _usersServices.SaveUsers(usersSave);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost("UpdateUser")]
        public IActionResult Put(UsersUpdateDto usersUpdate)
        {
            var result = _usersServices.UpdateUsers(usersUpdate);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost("RemoveUser")]
        public IActionResult Delete(UsersRemoveDto usersRemove)
        {
            var result = _usersServices.RemoveUsers(usersRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
