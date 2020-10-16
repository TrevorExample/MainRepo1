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
    public class PlacementController : Controller
    {
        public IActionResult Index()
        {
            PlacementContext context = new PlacementContext();

            var students = context.Placements;


                return View();
        }

        [HttpPost()]
        [Authorize(Roles = "Admin")]
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



    }
}
