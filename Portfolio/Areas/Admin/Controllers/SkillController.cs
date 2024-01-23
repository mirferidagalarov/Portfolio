using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("admin")]
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;
        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }
        public IActionResult Index()
        {
            var data = _skillService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Skill skill) 
        { 
            _skillService.Add(skill);
            return RedirectToAction("Index");   
        }

        public IActionResult Edit(int id)
        {
           var skill= _skillService.GetById(id).Data;
            return View(skill);
        }
        [HttpPost]
        public IActionResult Edit(Skill skill)
        {
            _skillService.Update(skill);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var skill = _skillService.GetById(id).Data;
            skill.Deleted = skill.ID;
            _skillService.Update(skill);
            return RedirectToAction("Index");
        }
    }
}
