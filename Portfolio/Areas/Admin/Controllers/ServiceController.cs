using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceService  _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        public IActionResult Index()
        {
            var data=_serviceService.GetAll().Data;  
            return View(data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Service service)
        {
            _serviceService.Add(service);   
            return RedirectToAction("Index");   
        }

        public IActionResult Edit(int id)
        {
            var dataid= _serviceService.GetById(id).Data;
            return View(dataid);
        }
        [HttpPost]
        public IActionResult Edit(Service service)
        {
            _serviceService.Update(service);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var dataid = _serviceService.GetById(id).Data;
            dataid.Deleted = dataid.ID;
            _serviceService.Update(dataid);
            return RedirectToAction("Index");
        }
    }
}
