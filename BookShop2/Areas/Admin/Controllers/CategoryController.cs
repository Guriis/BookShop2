using BookShop.DataAccess.Repository.IRepository;
using BookShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookShop2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitofwork _unitofwork;
        public CategoryController(IUnitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            Category category = new Category();
            if (id == null) return View(category);
            category = _unitofwork.Category.Get(id.GetValueOrDefault());
            if (category == null) return NotFound();
            return View(category);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category, int? id)
        {
            if (category == null) return NotFound();
            if (category.Id == 0)
                _unitofwork.Category.Add(category);
            else
                _unitofwork.Category.Update(category);
            _unitofwork.Save();
            return RedirectToAction("Index");
        }
        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitofwork.Category.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var categoryindb = _unitofwork.Category.Get(id);
            if (categoryindb == null)
                return Json(new
                {
                    success = false,
                    massage = "Something went wrong while deleting data!!!"
                });
            _unitofwork.Category.Remove(categoryindb);
            _unitofwork.Save();
            return Json(new { success = true, massage = "Data successfuly deleted!!!" });
        }
        #endregion

    }
}
