using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ExperinceController : Controller
    {
        private readonly IExperinceService _experinceService;
        private readonly IPositionService _positionService; 
        public ExperinceController(IExperinceService experinceService,IPositionService positionService)
        {
                _experinceService = experinceService;
                _positionService = positionService;
        }
        public IActionResult Index()
        {
           var data= _experinceService.GetAll().Data;    
            return View(data);
        }
            
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Positions"] = _positionService.GetAll().Data;
            return View();  
        }

        [HttpPost]
        public IActionResult Add(Experience experience)
        {
            _experinceService.Add(experience);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ViewData["Positions"] = _positionService.GetAll().Data;
            var dataid=_experinceService.GetById(id).Data;
            return View(dataid);
        }

        [HttpPost]
        public IActionResult Edit(Experience experience)
        {
            _experinceService.Update(experience);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var experincedata = _experinceService.GetById(id).Data;
            experincedata.Deleted = experincedata.ID;
            _experinceService.Delete(experincedata);
            return RedirectToAction("Index");
        }
    }
}
