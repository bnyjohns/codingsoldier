using CodingSoldier.Core.Entities;
using CodingSoldier.Models;
using CodingSoldier.Core.UnitOfWork;

namespace CodingSoldier.Controllers
{
    public class PostsController : BaseController<Post, PostViewModel>
    {
        public PostsController(IUnitOfWork uow) : base(uow)
        {            

        }        
    }
}