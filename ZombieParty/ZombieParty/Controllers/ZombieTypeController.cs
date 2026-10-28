using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZombieParty.Models;
using ZombieParty.Models.Data;
using ZombieParty.Services;
using ZombieParty.Utility;
using ZombieParty.ViewModels;

namespace ZombieParty.Controllers
{
    public class ZombieTypeController : Controller
    {
        private IZombieTypeService _serviceZT { get; set; }

        public ZombieTypeController(IZombieTypeService serviceZT)
        {
            _serviceZT = serviceZT;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ZombieType> zombieTypesList = await _serviceZT.GetAllAsync();

            return View(zombieTypesList);
        }

        //public async Task<IActionResult> Details(int id)
        //{
        //    var zombies = await _baseDonnees.Zombies.Where(z => z.ZombieTypeId == id).ToListAsync();

        //    ZombieTypeVM zombieTypeVM = new()
        //    {
        //        ZombieType = new(),
        //        ZombiesList = zombies,
        //        ZombiesCount = zombies.Count(),
        //        PointsAverage = zombies.Average(p => p.Point)
        //    };

        //    zombieTypeVM.ZombieType = await _baseDonnees.ZombieTypes.FirstOrDefaultAsync(zt => zt.Id == id);
        //    return View(zombieTypeVM);
        //}


        ////GET CREATE
        //public IActionResult Create()
        //{
        //    //ici pas grand intérêt à la mettre async
        //    return View();
        //}

        ////POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(ZombieType zombieType)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Ajouter à la BD
        //       await  _baseDonnees.ZombieTypes.AddAsync(zombieType);
        //        _baseDonnees.SaveChanges();
        //        TempData[AppConstants.Success] = $"{zombieType.TypeName} zombie type added";
        //        return this.RedirectToAction("Index");
        //    }

        //    return this.View(zombieType);
        //}

        //public async Task<IActionResult> Edit(int id)
        //{
        //    ZombieType? zombieType = await _baseDonnees.ZombieTypes.FindAsync(id);
            
        //    return View(zombieType);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(ZombieType zombieType)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _baseDonnees.ZombieTypes.Update(zombieType);
        //       await _baseDonnees.SaveChangesAsync();
        //        TempData[AppConstants.Success] = $"ZombieType {zombieType.TypeName} has been modified";
        //        return this.RedirectToAction("Index");
        //    }

        //    return View(zombieType);
        //}

        //public async Task<IActionResult> Delete(int id)
        //{
        //    ZombieType? zombieType = await _baseDonnees.ZombieTypes.FindAsync(id);
        //    if (zombieType == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(zombieType);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeletePost(int id)
        //{
        //    ZombieType? zombieType = await _baseDonnees.ZombieTypes.FindAsync(id);
        //    if (zombieType == null)
        //    {
        //        return NotFound();
        //    }

        //    _baseDonnees.ZombieTypes.Remove(zombieType);
        //     await _baseDonnees.SaveChangesAsync();
        //    TempData[AppConstants.Success] = $"ZombieType {zombieType.TypeName} has been removed";
        //    return RedirectToAction("Index");
        //}
    }
}
