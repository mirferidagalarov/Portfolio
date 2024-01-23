using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("admin")]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;
        private readonly IWorkCategoryService _workCategoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PortfolioController(IPortfolioService portfolioService, IWebHostEnvironment webHostEnvironment, IWorkCategoryService workCategoryService)
        {
            _portfolioService = portfolioService;
            _webHostEnvironment = webHostEnvironment;
            _workCategoryService = workCategoryService;
        }

        public IActionResult Index()
        {
            var data = _portfolioService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["WorkCategory"] = _workCategoryService.GetAll().Data;
            return View();

        }

        [HttpPost]
        public IActionResult Add(Portfoli portfolio)
        {
            string filename = "";
            filename = Upload(portfolio,filename);
            _portfolioService.Add(portfolio,filename);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ViewData["WorkCategory"] = _workCategoryService.GetAll().Data;
            var dataid = _portfolioService.GetById(id).Data;
            return View(dataid);
        }
        [HttpPost]
        public IActionResult Edit(Portfoli portfoli)
        {
            var exsistingProfile = _portfolioService.GetById(portfoli.ID).Data;
            string filename = exsistingProfile.WorkImagePath;
            if (portfoli.ImageFile == null)
            {
                portfoli.WorkImagePath = exsistingProfile.WorkImagePath;
            }
            else
            {

                filename = Upload(portfoli, filename);
            }
            _portfolioService.Update(portfoli,filename);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var dataid = _portfolioService.GetById(id).Data;
            string filename = dataid.WorkImagePath;
             dataid.Deleted = dataid.ID;
            _portfolioService.Update(dataid,filename);
            return RedirectToAction("Index");
        }

        public string Upload(Portfoli portfolio, string filename)
        {
            string fileName = Guid.NewGuid().ToString() + "_" + portfolio.ImageFile.FileName;

            if (portfolio.ImageFile != null)
            {
                string folder = "WorkImage/";
                folder += fileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                portfolio.ImageFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
            }

            return fileName;
        }
    }
}
