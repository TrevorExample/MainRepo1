using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnovativeRecoveryReports.Data;
using InnovativeRecoveryReports.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InnovativeRecoveryReports.Controllers
{

    [Route("[controller]/[action]")]
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            PlacementContext context = new PlacementContext();

            var students = context.Placements;

                return View();
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        //[Authorize(Policy = "OnlyAdminAccess")]

        public string getPlacementReport(string input)
        {
            var _placements = new List<Placement>();
 
            using (PlacementContext context = new PlacementContext())
            {
                var placements = (from s in context.Placements
                                //orderby s.ClientNumber
                                .Take(100)
                                select s).ToList<Placement>();
                _placements = placements;
            }


            var catt = JsonConvert.SerializeObject(_placements);
            return catt;

        }

        [HttpPost]
        public string getAvgDaysLapsedReport(string input)
        {
            var _placements = new List<Placement>();
            var _placements2 = new List<string>();
            var _placements3 = new double();
            var _placements4 = new List<string>();
            var _placements5 = new List<Placement>();
            var _placements6 = new List<int>();
            
            using (PlacementContext context = new PlacementContext())
            {
                var placements = (from s in context.Placements
                                 //.OrderBy(s=> s.DaysLapsed)       
                                .Take(500)
                                .Where(c => c.MoveInDate !=null && c.MoveOutDate !=null && c.ListedDate !=null)
                                  select s).ToList<Placement>();
  
                _placements = placements;
                _placements4 = _placements.Select(c => c.Community).ToList();
                _placements6 = _placements.Select(c => c.DaysLapsed).ToList();
                _placements3 = _placements.Where(c => c.MoveInDate == null).Select(x => x.DaysLapsed).DefaultIfEmpty().Average();
                var car = placements.GroupBy(p => p.Community);
                //_placements3 = _placements.Where(c => c.MoveInDate == null).Average(c => c.DaysLapsed);
                
                //placements.GroupBy(p => p.CreditorCLID)
                //.Select(g => new CreditorStatistics(g.FirstOrDefault()?.CreditorName, g.ToList()))
                //.ToList();
                _placements4 = placements.GroupBy(p => p.Community).Select(g => g.FirstOrDefault()?.Community).ToList();

                //_placements5 = _placements4.Where(c=>)
            }
            var dagg = _placements.Select(c => new { c.Community, c.DaysLapsed }).ToList();

            //  public static double? GetAvgDaysLeased(this StatisticsGroup group)
            //=> group.PlacementsStatistics.Where(ps => ps.HasValidMoveInOutDates && ps.DaysLeased != null).Average(ps => ps.DaysLeased);

            //     return placements.GroupBy(p => p.CreditorCLID)
            //.Select(g => new CreditorStatistics(g.FirstOrDefault()?.CreditorName, g.ToList()))
            //.ToList();

            //    public int DaysLapsed => MoveOutValue.HasValue ? ListedDateValue.Value.Subtract(MoveOutValue.Value).Days : 0;


            var catt = JsonConvert.SerializeObject(_placements4);
            return catt;

        }

        public string getAvgDaysLapsedReport2(string input)
        {
            var _placements = new List<Placement>();
            var _placements6 = new List<int>();

            using (PlacementContext context = new PlacementContext())
            {
                var placements = (from s in context.Placements
                                 //.OrderBy(s => s.DaysLapsed)
                                .Take(5000)
                                .Where(c => c.MoveInDate != null && c.MoveOutDate != null && c.ListedDate != null)
                                  select s).ToList<Placement>();

                _placements = placements;
                _placements6 = _placements.Select(c => c.DaysLapsed).ToList();
            }
            var catt = JsonConvert.SerializeObject(_placements6);
            return catt;

        }


    }
}
