using BookShop.DataAccess.Repository.IRepository;
using BookShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookShop2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CovertypeController : Controller
    {
        private readonly IUnitofwork _unitofwork;
        public CovertypeController(IUnitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region Apis
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitofwork.Covertype.GetAll() });
        }
        #endregion
        public IActionResult Upsert(int? id)
        {
            Covertype covertype = new Covertype();
            if(id ==  0) return View(covertype);
            covertype = _unitofwork.Covertype.Get(id.GetValueOrDefault());
            if (covertype == null) return NotFound();
            return View(covertype);

        }

    }
}
