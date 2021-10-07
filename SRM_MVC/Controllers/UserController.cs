using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SRM_MVC.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
 using SRM_MVC.Models;

namespace SRM_MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IStudentService _studentService = null;
        private readonly ISemesterService _semservice = null;
        private readonly IBranchService _branchService = null;

        public UserController(ISemesterService sservice, IBranchService bservice, IStudentService stservice)
        {
            _semservice = sservice;
            _branchService = bservice;
            _studentService = stservice;
        }
        [HttpGet]
        public IActionResult GetStudentResult()
        {

            List<SelectListItem> semLiIst = _semservice.GetSemesters().Select(n => new SelectListItem { Value = n.SemesterId.ToString(), Text = n.semester }).ToList(); ;

            var SemTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select Semester ---"
            };

            //var s = new StudentResultView();
           // var name = s.FirstName + s.LastName;



            semLiIst.Insert(0, SemTip);
            ViewBag.semLiIst = new SelectList(semLiIst, "Value", "Text");
            //Result result = _service.GetResult(id, semid);


            return View();
        }
        public IActionResult ViewStudentResult()
        {

            List<SelectListItem> semLiIst = _semservice.GetSemesters().Select(n => new SelectListItem { Value = n.SemesterId.ToString(), Text = n.semester }).ToList(); ;

            var SemTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select Semester ---"
            };

            var s = new StudentResultView();
           // var name = s.FirstName + s.LastName;



            semLiIst.Insert(0, SemTip);
            ViewBag.semLiIst = new SelectList(semLiIst, "Value", "Text");


            return View();
        }
        [HttpPost]
        public IActionResult DetailsResult(int id, int brid, int semid)
        {
            return View();            
        }
             
    }
}
