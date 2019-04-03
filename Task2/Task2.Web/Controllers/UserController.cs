using Microsoft.AspNetCore.Mvc;
using Task2.Infrastructure.ReposInterfaces;

namespace Task2.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Test()
        {
            return Ok("12345");
        }
        
        private readonly IUserRepository _repository;
    }
}