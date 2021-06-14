using Covid19Statistics.Dto.Stadistics;
using Covid19Statistics.Service;
using Covid19Statistics.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Statistics.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ICovid19StatisticsService _covid19StatisticsService;

        public HomeController(ILogger<HomeController> logger, ICovid19StatisticsService covid19StatisticsService)
        {
            _logger = logger;
            _covid19StatisticsService = covid19StatisticsService;
        }

        public async Task<IActionResult> Index()
        {

            List<RegionStadisticsOutputDto> lst=await  _covid19StatisticsService.GetTopCasesCovidByRegions();
            return View();
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
