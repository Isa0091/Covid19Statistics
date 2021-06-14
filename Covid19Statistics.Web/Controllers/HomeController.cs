using Covid19Statistics.Dto.Region;
using Covid19Statistics.Dto.Stadistics;
using Covid19Statistics.Service;
using Covid19Statistics.Web.Models;
using Covid19Statistics.Web.Models.Report;
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
        private readonly IRegionsService _regionsService;

        public HomeController(
            ICovid19StatisticsService covid19StatisticsService,
            IRegionsService regionsService)
        {
            _covid19StatisticsService = covid19StatisticsService;
            _regionsService = regionsService;
        }

        public async Task<IActionResult> Index(string Iso)
        {
            ReportDetailOutput reportDetailOutput = new ReportDetailOutput()
            {
                 RegionIso= Iso
            };

            List<RegionOutputDto>  listRegionOutputDto = await _regionsService.GetRegionsAsync();
            List<RegionOutput> regionOutputs = listRegionOutputDto.Select(z => new RegionOutput()
            {
                 Iso=z.Code,
                 Name= z.Name

            }).ToList();

            reportDetailOutput.ListRegion = regionOutputs;

            if (string.IsNullOrEmpty(Iso))
            {
                List<RegionStadisticsOutputDto> regionStadistics = await _covid19StatisticsService.GetTopCasesCovidByRegions();

                reportDetailOutput.ReportDataOutput= regionStadistics.Select(z => new ReportDataOutput()
                {
                     Name= z.Name,
                     Cases= z.Confirmed,
                     Deaths= z.Deaths
                }).ToList();
            }

            if (string.IsNullOrEmpty(Iso)==false)
            {
                List<ProvincesStadisticsOutputDto> provincesStadisticsOutputs = 
                    await _covid19StatisticsService.GetTopCasesCovidFilter(new FilterCovid19Statistics(){ 
                       RegionIsoCode= Iso
                });
                reportDetailOutput.ReportDataOutput = provincesStadisticsOutputs.Select(z => new ReportDataOutput()
                {
                    Name = z.Name,
                    Cases = z.Confirmed,
                    Deaths = z.Deaths
                }).ToList();
            }

            return View(reportDetailOutput);
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
