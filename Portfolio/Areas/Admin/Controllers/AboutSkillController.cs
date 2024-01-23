using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AboutSkillController : Controller
    {
       
        private readonly IAboutSkillService _aboutSkillService;
        private readonly ISkillService _skillService;
        public AboutSkillController(IAboutSkillService aboutSkillService, ISkillService skillService)
        {
                _aboutSkillService = aboutSkillService;
                _skillService = skillService;
        }
        public IActionResult Index()
        {
           var data= _aboutSkillService.GetAll().Data;
           return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Skill"] = _skillService.GetAll().Data;
            return View();  
        }
        [HttpPost]
        public IActionResult Add(AboutSkill aboutSkill)
        {
            _aboutSkillService.Add(aboutSkill);
            return RedirectToAction("Index");   
        }

        public IActionResult Edit(int id)
        {
            ViewData["Skill"] = _skillService.GetAll().Data;
            var dataid= _aboutSkillService.GetById(id).Data;
            return View(dataid);
        }

        [HttpPost]
        public IActionResult Edit(AboutSkill aboutSkill)
        {
            _aboutSkillService.Update(aboutSkill);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var dataid=_aboutSkillService.GetById(id).Data;
            dataid.Deleted = dataid.ID;
            _aboutSkillService.Update(dataid);
            return RedirectToAction("Index");   
        }
    }
}
