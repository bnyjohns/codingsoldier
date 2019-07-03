using CodingSoldier.Core.Entities;
using CodingSoldier.Models;
using CodingSoldier.Core.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;

namespace CodingSoldier.Controllers
{
    public class PostsController : BaseController<Post, PostViewModel>
    {
        public PostsController(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {            

        }
        public override Task<ActionResult> Index(int page = 1, int pageSize = 3, string header = null)
        {
            return base.Index(page, pageSize, header);
        }

    }
}