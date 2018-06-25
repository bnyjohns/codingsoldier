using AutoMapper;
using CodingSoldier.Core.Entities;
using CodingSoldier.Core.Repository;
using CodingSoldier.Core.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CodingSoldier.ApiControllers
{
    [Authorize]
    [EnableCors("MyPolicy")]
    public abstract class BaseApiController<TModel, TEntity> : Controller
                                                               where TModel : class, IModel
                                                               where TEntity: IApiEntity
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IRepository<TModel> _modelRepository;

        public BaseApiController(IUnitOfWork uow)
        {
            if (uow == null)
                throw new ArgumentNullException(nameof(uow));
            _uow = uow;

            _modelRepository = _uow.Repository<TModel>();
        }

        [AllowAnonymous]
        public async virtual Task<List<TEntity>> GetAll()
        {
            var entities = await _modelRepository.GetAllAsync();
            return Mapper.Map<List<TEntity>>(entities);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async virtual Task<IActionResult> Get(int id)
        {
            var model = await _modelRepository.GetAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            var modelEntity = Mapper.Map<TEntity>(model);
            return Ok(modelEntity);
        }

        [HttpPost]
        protected async virtual Task<IActionResult> UpdateModel(TModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.Id == 0)
            {
                return BadRequest();
            }

            try
            {                
                await _modelRepository.UpdateAsync(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                var modelExists = await ModelExistsAsync(model.Id);
                if (!modelExists)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode((int)HttpStatusCode.NoContent);
        }

        [HttpPost]
        protected async virtual Task<IActionResult> PostModel(TModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }            
            await _modelRepository.AddAsync(model);
            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        protected async virtual Task<IActionResult> DeleteModel(int id)
        {
            var post = await _modelRepository.GetAsync(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            await _modelRepository.RemoveAsync(p => p.Id == id);
            return Ok(post);
        }

        protected override void Dispose(bool disposing)
        {
            _uow.Dispose();
            base.Dispose(disposing);
        }

        private async Task<bool> ModelExistsAsync(int id)
        {
            var model = await _modelRepository.GetAsync(m => m.Id == id);
            return model != null;
        }
    }
}