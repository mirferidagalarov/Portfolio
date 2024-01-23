using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("admin")]
    public class WorkCategoryController : Controller
    {
        private readonly IWorkCategoryService _workCategoryService;
        public WorkCategoryController(IWorkCategoryService workCategoryService)
        {
                _workCategoryService = workCategoryService;
        }
        public IActionResult Index()
        {
            var workdata=_workCategoryService.GetAll().Data;
            return View(workdata);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Add(WorkCategory workCategory)
        {
            _workCategoryService.Add(workCategory);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var dataid=_workCategoryService.GetById(id).Data;
            return View(dataid);
        }
        [HttpPost]
        public IActionResult Edit(WorkCategory workCategory)
        {
            _workCategoryService.Update(workCategory);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var datadelete = _workCategoryService.GetById(id).Data;
            datadelete.Deleted = datadelete.ID;
            _workCategoryService.Update(datadelete);  
            return RedirectToAction("Index");

        }
    }
}
