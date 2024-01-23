using Business.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("admin")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IPositionService _positionService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PersonController(IPersonService personService, IPositionService positionService, IWebHostEnvironment webHostEnvironment)
        {
            _personService = personService;
            _positionService = positionService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var data = _personService.GetAll().Data;
            return View(data);
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Positions"] = _positionService.GetAll().Data;

            return View();
        }
        [HttpPost]
        public IActionResult Add(Person person)
        {
            string filename="";
            string download="";
           filename= Upload(person,filename);
           download = Download(person,download);
           
            _personService.Add(person, filename, download);
            return RedirectToAction("Index");
        }

        //public async Task<IActionResult> DownloadFileFromFileSystem(int id)
        //{
        //    var file = await _personService.GetById(id);
        //    if (file == null) return null;
        //    var memory = new MemoryStream();
        //    using (var stream = new FileStream(file.FilePath, FileMode.Open))
        //    {
        //        await stream.CopyToAsync(memory);
        //    }
        //    memory.Position = 0;
        //    return File(memory, file.FileType, file.Name + file.Extension);
        //}


        //[HttpGet()]
        //public IActionResult Download(int cvId)
        //{
        //    var cv = _portfolioDbContext.People.Find(cvId);

        //    if (cv == null)
        //        return NotFound();

        //    // Retrieve the file content from Cloudinary using the URL
        //    using (var webClient = new WebClient())
        //    {
        //        var fileContent = webClient.DownloadData(cv.CvPath);
        //        var contentType = GetContentType(cv.CvPath);
        //        return File(fileContent, contentType, cv.CvPath);
        //    }
        //}

        //private string GetContentType(string fileName)
        //{
        //    var extension = Path.GetExtension(fileName).ToLowerInvariant();

        //    switch (extension)
        //    {
        //        case ".pdf":
        //            return "application/pdf";
        //        case ".doc":
        //            return "application/msword";
        //        case ".docx":
        //            return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        //        default:
        //            return "application/octet-stream";
        //    }
        //}
        public IActionResult Edit(int id)
        {

            ViewData["Positions"] = _positionService.GetAll().Data;
            var data = _personService.GetById(id).Data;
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Person person)
        {
            var exsistingProfile = _personService.GetById(person.ID).Data;
            string filename = exsistingProfile.ProfilPath;
            if (person.ImageFile == null)
            {
                person.ProfilPath = exsistingProfile.ProfilPath;
            }
            else
            {
               
                filename = Upload(person, filename);
            }
            string download = exsistingProfile.CvPath;
            if (person.CvFile == null)
            {
                person.CvPath = exsistingProfile.CvPath;
            }
            else
            {
                download = Download(person, download);
            }
            _personService.Update(person, filename, download);
            return RedirectToAction("Index");
        }

  

        public string Upload(Person person,string filename)
        {
            string fileName = Guid.NewGuid().ToString() + "_" + person.ImageFile.FileName;
           
            if (person.ImageFile != null)
            {
                string folder = "Image/";
                folder += fileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                person.ImageFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
            }

            return fileName;
        }

        public string Download(Person person, string filename)
        {
            string download = Guid.NewGuid().ToString() + "_" + person.CvFile.FileName;
            if (person.CvFile != null)
            {
                string folder = "Cv/";
                folder += download;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                person.CvFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
            }

            return download;
        }
    }
}
