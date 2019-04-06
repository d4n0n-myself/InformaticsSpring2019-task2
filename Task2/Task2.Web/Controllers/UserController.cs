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
        public IActionResult Add()
        {
            try
            {
                var form = HttpContext.Request.Form;
                var login = form["login"];
                var role = (Roles) Enum.Parse(typeof(Roles), form["role"], false);
                var password = form["password"];
                var response = _repository.Add(login, password, role);
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.ToString()); //
            }
        }

        [HttpPost]
        public IActionResult ChangeRole()
        {
            try
            {
                var form = HttpContext.Request.Form;
                var userId = Guid.Parse(form["user_id"]);
                var role = (Roles) Enum.Parse(typeof(Roles), form["role"], false);
                _repository.ChangeRole(userId, role);
                return Ok();
            }
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
        public IActionResult Delete()
        {
            try
            {
                var form = HttpContext.Request.Form;
                var login = form["login"];
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