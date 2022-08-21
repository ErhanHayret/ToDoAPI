using Business;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = UserBusiness.Instance.GetAllUser();
            return StatusCode(result.StatusCode, result.Data);
        }

        [HttpPost]
        public IActionResult AddUser(UserModel user)
        {
            var result = UserBusiness.Instance.AddUser(user);
            return StatusCode(result.StatusCode, result.Message);
        }
    }
}
