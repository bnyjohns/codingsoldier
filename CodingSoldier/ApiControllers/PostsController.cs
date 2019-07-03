using AutoMapper;
using CodingSoldier.Core.Entities;
using CodingSoldier.Models;
using CodingSoldier.Core.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodingSoldier.ApiControllers
{
    [Route("api/[controller]")]
    public class PostsController : BaseApiController<Post, PostApiEntity>
    {
        public PostsController(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
           
        }
    }
}
