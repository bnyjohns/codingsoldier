using AutoMapper;
using CodingSoldier.Core.Entities;
using CodingSoldier.Models;
using CodingSoldier.Core.Repository;
using CodingSoldier.Core.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingSoldier.Controllers
{
    [Authorize]
    public abstract class BaseController<Model, ViewModel> : Controller 
                                                                where Model : class, IModel
                                                                where ViewModel : BaseViewModel, new()
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IRepository<Model> _modelRepository;
        protected readonly IRepository<Category> _categoryRepository;
        protected readonly IMapper _mapper;

        public BaseController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));

            _modelRepository = _uow.Repository<Model>();
            _categoryRepository = _uow.Repository<Category>();

            _mapper = mapper;
        }        

        [AllowAnonymous]
        public async virtual Task<ActionResult> Index(int page = 1, int pageSize = 2, string header = null)
        {            
            var modelList = await _modelRepository.GetAllAsync();
            modelList = modelList.OrderByDescending(m => m.Id);
            var model = new PaginatedList<Model>(modelList, page, pageSize);
            var viewModel = _mapper.Map<PaginatedList<ViewModel>>(model);
            viewModel.PageIndex = model.PageIndex;
            viewModel.TotalPages = model.TotalPages;
            return View(viewModel);
        }

        [AllowAnonymous]
        public virtual Task<ActionResult> Search(string title)
        {
            throw new NotImplementedException();
        }

        private async Task<IEnumerable<SelectListItem>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(s => new SelectListItem { Text = s.CategoryName, Value = s.CategoryName });
        }

        public async virtual Task<ActionResult> Create()
        {
            var viewModel = new ViewModel { Categories = await GetAllCategories() };
            return View(viewModel);
        }

        [HttpPost]
        public async virtual Task<ActionResult> Create(ViewModel viewModel)
        {
            if (viewModel != null)
                viewModel.Categories = await GetAllCategories();

            if (ModelState.IsValid)
            {
                var model = _mapper.Map<Model>(viewModel);
                await _modelRepository.AddAsync(model);
            }
            return View(viewModel);
        }

        public async virtual Task<ActionResult> Edit(int id)
        {
            var model = await _modelRepository.GetAsync(m => m.Id == id);
            var viewModel = _mapper.Map<ViewModel>(model);
            viewModel.Categories = await GetAllCategories();
            return View(viewModel);
        }       
        

        [HttpPost]
        public async virtual Task<ActionResult> Edit(ViewModel viewModel)
        {
            if (viewModel != null)
                viewModel.Categories = await GetAllCategories();

            if (ModelState.IsValid)
            {
                var model = _mapper.Map<Model>(viewModel);
                await _modelRepository.UpdateAsync(model);
            }
            return View(viewModel);
        }

        public async virtual Task<ActionResult> Delete(int id)
        {
            await _modelRepository.RemoveAsync(m => m.Id == id);
            return RedirectToAction("index");
        }

        protected override void Dispose(bool disposing)
        {
            _uow.Dispose();
            base.Dispose(disposing);
        }        
    }
}