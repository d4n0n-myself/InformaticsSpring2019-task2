using System;
using Microsoft.AspNetCore.Mvc;
using Task2.Core.Entities;
using Task2.Domain;
using Task2.Web.Filters;

namespace Task2.Web.Controllers
{
    [InternalErrorFilter]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly UserDomainService _service;

        public UserController(UserDomainService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            _service.Add(user.Login, user.Password, user.Role);
            return Ok();
        }

        [HttpPost]
        public IActionResult ChangeRole(Guid userId, Roles newRole)
        {
            _service.ChangeRole(userId, newRole);
            return Ok(true);
        }

        [HttpGet]
        public IActionResult ContainsUser([FromQuery] string login)
        {
            var response = _service.ContainUser(login);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult Check(User user)
        {
            var response = _service.CheckPassword(user.Login, user.Password);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string login)
        {
            var user = _service.Get(login);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Delete(string login)
        {
            var user = _service.Get(login);
            _service.Delete(user);
            return Ok();
        }
    }
}