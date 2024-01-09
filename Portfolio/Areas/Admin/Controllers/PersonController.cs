using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IPositionService _positionService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PersonController(IPersonService personService,IPositionService positionService, IWebHostEnvironment webHostEnvironment)
        {
            _personService = personService;
            _positionService = positionService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var data=_personService.GetAll().Data; 
            return View(data);
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Persons"]= _positionService.GetAll().Data;

            return View();
        }
        [HttpPost]
        public IActionResult Add(Person person)
        {
            string fileName = Guid.NewGuid().ToString() + "_" + person.ImageFile.FileName;
            if (person.ImageFile != null)
            {
                string folder = "Image/";
                folder += fileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                 person.ImageFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
            }
            _personService.Add(person,fileName);
            return RedirectToAction("Index");
        }

      
        public IActionResult Edit(int id)
        {
             var dataid=_personService.GetById(id);
            return View(dataid);
        }
        public IActionResult Edit(Person person)
        {
            _personService.Update(person);
            return RedirectToAction("Index");
        }
    }
}
