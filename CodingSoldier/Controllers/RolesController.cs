using CodingSoldier.Core.Repository;
using CodingSoldier.Core.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CodingSoldier.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RolesController : Controller
    {
        IRepository<IdentityRole> _roleRepository;
        
        public RolesController(IUnitOfWork uow)
        {
            if (uow == null)
                throw new ArgumentNullException(nameof(uow));

            _roleRepository = uow.Repository<IdentityRole>();
        }

        public async Task<ActionResult> Index()
        {            
            var roles = await _roleRepository.GetAllAsync();
            return View(roles);
        }

        // GET: /Roles/Create
        public ActionResult Create()
        {
            var role = new IdentityRole();
            return View(role);
        }

        //
        // POST: /Roles/Create
        [HttpPost]
        public async Task<ActionResult> Create(IdentityRole role)
        {
            await _roleRepository.AddAsync(role);
            return RedirectToAction("Index");
        }
    }
}