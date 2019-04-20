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
        private readonly UserDomainService _repository;

        public UserController(UserDomainService repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            var response = _repository.Add(user.Login, user.Password, user.Role);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult ChangeRole(Guid userId, Roles newRole)
        {
            _repository.ChangeRole(userId, newRole);
            return Ok(true);
        }

        [HttpGet]
        public IActionResult ContainsUser([FromQuery] string login)
        {
            var response = _repository.ContainUser(login);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult Check(User user)
        {
            var response = _repository.CheckPassword(user.Login, user.Password);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string login)
        {
            var user = _repository.Get(login);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Delete(string login)
        {
            var user = _repository.Get(login);
            var response = _repository.Delete(user);
            return Ok(response);

        }
    }
}