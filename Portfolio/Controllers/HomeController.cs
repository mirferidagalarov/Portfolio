using Business.Abstract;
using Entities.Concrete.TableModels;
using Entities.Concrete.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Portfolio.Models;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonService _personService;
        private readonly IServiceService _serviceService;
        private readonly IExperinceService _experinceService;
        private readonly IAboutSkillService _aboutSkillService;
        private readonly IPortfolioService _portfolioService;
        private readonly IPositionService _positionService;
        public HomeController(ILogger<HomeController> logger, IPersonService personService, IServiceService serviceService, IExperinceService experinceService, IAboutSkillService aboutSkillService, IPortfolioService portfolioService, IPositionService positionService)
        {
            _logger = logger;
            _personService = personService;
            _serviceService = serviceService;
            _experinceService = experinceService;
            _aboutSkillService = aboutSkillService;
            _portfolioService = portfolioService;
            _positionService = positionService;
        }

        public IActionResult Index()
        {
            var dataService = _serviceService.GetAll().Data;
            var dataPerson = _personService.GetAll().Data[0];
            var dataexperince = _experinceService.GetAll().Data;
            var dataAbouskill = _aboutSkillService.GetAll().Data;
            var dataPortfoli = _portfolioService.GetAll().Data;
            var datapositions=_positionService.GetAll().Data;
            HomeViewModel homeViewModel = new()
            {
                Services = dataService,
                People = dataPerson,
                Experience = dataexperince,
                AboutSkills = dataAbouskill,
                Portfolis = dataPortfoli,
                Positions = datapositions
            };

            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}