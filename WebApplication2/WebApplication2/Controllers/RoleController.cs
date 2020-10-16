using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RoleController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        
        private RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> roleMgr)
        {
            roleManager = roleMgr;
        }

        public ViewResult Index() => View(roleManager.Roles);

        public IActionResult Create() => View();

        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CreateRole(string input)
        {
            IdentityResult result = await roleManager.CreateAsync(new IdentityRole(input));


            //if (ModelState.IsValid)
            //{
            //     if (result.Succeeded)
            //        return RedirectToAction("Index");
            //    //else
            //        //Errors(result);
            //}
            return View(input);
            //var users = new Questions { Answer = "asdfasdf", QuestionNumber = 1, Question = "what is your name", AnswerChoice = "man" };
            //var catt = JsonConvert.SerializeObject(users);
            //return catt;
        }
    }
}
