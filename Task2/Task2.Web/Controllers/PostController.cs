using Microsoft.AspNetCore.Mvc;
using Task2.Infrastructure.ReposInterfaces;

namespace Task2.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class PostController : Controller
    {
        public PostController(IPostRepository repository)
        {
            _repository = repository;
        }
        
        private readonly IPostRepository _repository;
    }
}