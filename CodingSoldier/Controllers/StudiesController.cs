using CodingSoldier.Core.Entities;
using CodingSoldier.Models;
using CodingSoldier.Core.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using CodingSoldier.Core.Repository;
using System.Threading.Tasks;
using System.Linq;

namespace CodingSoldier.Controllers
{
    public class StudiesController : BaseController<Study, StudyViewModel>
    {
        public StudiesController(IUnitOfWork uow, IMapper mapper) :
            base(uow, mapper)
        {

        }

        public async override Task<ActionResult> Index(int page = 1, int pageSize = 2, string studyHeader = null)
        {
            if (studyHeader != null)
            {
                var studies = await _modelRepository.GetAllAsync();
                var result = studies.Where(m => m.StudyHeader == studyHeader);
                var paginatedResult = new PaginatedList<Study>(result, page, pageSize);
                var viewModel = _mapper.Map<PaginatedList<StudyViewModel>>(result);
                viewModel.PageIndex = paginatedResult.PageIndex;
                viewModel.TotalPages = paginatedResult.TotalPages;
                return View(viewModel);
            }
            else
            {
                return await base.Index(page, pageSize);
            }
        }

        public async override Task<ActionResult> Search(string title)
        {
            title = title ?? string.Empty;
            ViewBag.SearchText = title;
            var studies = _modelRepository as IRepository<Study>;
            var searchedStudies = await studies.GetAllAsync();
            var result = searchedStudies.Where(s => s.StudyHeader.Contains(title) || s.StudyContent.Contains(title));
            var viewModel = _mapper.Map<List<StudyViewModel>>(result);
            return View(viewModel);
        }
    }
}