using System;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal;
using Microsoft.AspNetCore.Mvc;
using Task2.Core.Entities;
using Task2.Infrastructure.ReposInterfaces;

namespace Task2.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }
        
        [HttpPost]
        public IActionResult Add(User user)
        {
            try
            {
                var response = _repository.Add(user.Login, user.Password, user.Role);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.ToString()); 
            }
        }

        [HttpPost]
        public IActionResult ChangeRole()
        {
            try
            {
                _repository.ChangeRole(userId, newRole);
                return Ok(true);
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.ToString());
            }
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
            try
            {
                var user = _repository.Get(login);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        public IActionResult Delete(string login)
        {
            try
            {
                var user = _repository.Get(login);
                var response = _repository.Delete(user);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.ToString());
            }
        }
    }
}