using CodingSoldier.Models;
using CodingSoldier.Core.UnitOfWork;
using AutoMapper;
using System.Collections.Generic;
using CodingSoldier.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace CodingSoldier.ApiControllers
{
    [Route("api/[controller]")]
    public class StudiesController : BaseApiController<Study, StudyApiEntity>
    {
        public StudiesController(IUnitOfWork uow) : base(uow)
        {

        }               
    }
}