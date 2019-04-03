using Microsoft.AspNetCore.Mvc;
using Task2.Infrastructure.ReposInterfaces;

namespace Task2.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class CommentController : Controller
    {
        public CommentController(ICommentRepository repository)
        {
            _repository = repository;
        }
        
        private readonly ICommentRepository _repository;
    }
}