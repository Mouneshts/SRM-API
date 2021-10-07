using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SRM_MVC.Services;
using SRM_MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SRM_MVC.Controllers
{
    public class StudentController : Controller
    {
        public static string FirstName_Regex = "^[A-Z]{1}[A-Za-z]{4,}$";
        public static string LastName_Regex = "^[A-Z]{1}[A-Za-z]{4,}$";

        public static string MoblieNumber_Regex = "^[6-9]{1}[0-9]{9}$";
        public static string Email_Regex = "^[0-9a-zA-Z]+[.+-_]{0,4}[0-9a-zA-Z]+[@][a-zA-Z]+[.][a-zA-Z]{2,3}$";
        public static string Password_Regex = "^[a-zA-Z0-9]{5,}";


        private readonly IStudentService _service = null;
        private readonly ISemesterService _sservice = null;
        private readonly ICoursesService _csservice = null;
        private readonly IBranchService _bservice = null;
        private readonly ISubjectService _subservice = null;
        public StudentController(IStudentService service, ISemesterService semester,ICoursesService course,IBranchService branch, ISubjectService subjectService,IResultService resultService)
        {
            _service = service;_sservice = semester;_csservice = course;_bservice = branch;_subservice = subjectService;
        }
        [HttpGet]
        public IActionResult AddStudent()
        {

            List<SelectListItem> courseslist = _csservice.GetCourses().Select(n => new SelectListItem { Value = n.CourseId.ToString(), Text = n.CourseName }).ToList(); ;

            var courseTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select Course ---"
            };
            List<SelectListItem> semlist = _sservice.GetSemesters().Select(n => new SelectListItem { Value = n.SemesterId.ToString(), Text = n.semester }).ToList(); ;

            var semTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select Semester ---"
            };
            List<SelectListItem> brlist = _bservice.GetBranchs().Select(n => new SelectListItem { Value = n.BId.ToString(), Text = n.Name }).ToList(); ;

            var brTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select Branch ---"
            };

            courseslist.Insert(0, courseTip);
            semlist.Insert(0, semTip);
            brlist.Insert(0, brTip);
            ViewBag.courseslist = new SelectList(courseslist, "Value", "Text");
            ViewBag.semlist = new SelectList(semlist, "Value", "Text");
           ViewBag.brlist = new SelectList(brlist, "Value", "Text");
            return View();
        }
          [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            try
            {
                if (student == null)
                {
                    ViewBag.Error = "Fileds Can Not Be Empty";
                    return View();
                }
                if (ModelState.IsValid)
                //{
                    List<SelectListItem> courseslist = _csservice.GetCourses().Select(n => new SelectListItem { Value = n.CourseId.ToString(), Text = n.CourseName }).ToList(); ;

                    var courseTip = new SelectListItem()
                    {
                        Value = null,
                        Text = "--- Select Course ---"
                    };
                    List<SelectListItem> semlist = _sservice.GetSemesters().Select(n => new SelectListItem { Value = n.SemesterId.ToString(), Text = n.semester }).ToList(); ;

                    var semTip = new SelectListItem()
                    {
                        Value = null,
                        Text = "--- Select Semester ---"
                    };
                    List<SelectListItem> brlist = _bservice.GetBranchs().Select(n => new SelectListItem { Value = n.BId.ToString(), Text = n.Name }).ToList(); ;

                    var brTip = new SelectListItem()
                    {
                        Value = null,
                        Text = "--- Select Branch ---"
                    };

                    courseslist.Insert(0, courseTip);
                    semlist.Insert(0, semTip);
                    brlist.Insert(0, brTip);
                    ViewBag.courseslist = new SelectList(courseslist, "Value", "Text");
                    ViewBag.semlist = new SelectList(semlist, "Value", "Text");
                    ViewBag.brlist = new SelectList(brlist, "Value", "Text");

                    _service.AddStudent(student);
                    return RedirectToAction("GetStudents");
                    //if (student.FirstName.Equals(FirstName_Regex) && student.LastName.Equals(LastName_Regex) && student.PhoneNumber.Equals(MoblieNumber_Regex))
                    //{
                        
                    //}
                    //else 
                    //{
                    //    return View();
                //    //}
                //}
                //else 
                //{
                //    return View();
                //}            
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Student Added Successfully " + e.Message;
                return RedirectToAction("AddStudent");
            }
        }
        [HttpGet]
        public IActionResult GetStudents()
        {

            return View(_service.GetStudents());
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                var student = _service.GetStudent(id);
                if (student != null)
                    return Ok(student);
                else
                    return Content("Invalid Id");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student students = _service.GetStudent(id);
            return View(students);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            try
            {
                _service.UpdateStudent(student);

                return RedirectToAction("GetStudents");
            }
            catch (Exception e)
            { 
            
            }
            return View();
        }
        [HttpGet]

        public IActionResult Delete(int id)
        {
            Student student = _service.GetStudent(id);

            return View(student);
        }
        [HttpPost]
        public IActionResult Delete(Student student)
        {
            // _service.DeleteBranch(student.);
            _service.DeleteStudent(student.StudentId);
            return RedirectToAction("GetStudents");
        }
        //public IActionResult GetStudentResult(int id, int semid)
        //{
        //    List<SelectListItem> semLiIst = _sservice.GetSemesters().Select(n => new SelectListItem { Value = n.SemesterId.ToString(), Text = n.semester }).ToList(); ;

        //    var SemTip = new SelectListItem()
        //    {
        //        Value = null,
        //        Text = "--- select Semester ---"
        //    };

        //    //var s = new StudentResultView();
        //    //var name = s.FirstName + s.LastName;

        //    //var st = _service.GetStudent(id);
        //    //var br = _subservice.GetSubjects().Where(n => n.bId == st.BId);
        //    //var sm = _sservice.GetSemesters().Where(n => n.CourseId == st.Cid);



        //    semLiIst.Insert(0, SemTip);
        //    ViewBag.semLiIst = new SelectList(semLiIst, "Value", "Text");
        //    Result result = _service.GetResult(id, semid);


        //    return View(result);
        //}

        public IActionResult Index()
        {
            List<SelectListItem> semLiIst = _sservice.GetSemesters().Select(n => new SelectListItem { Value = n.SemesterId.ToString(), Text = n.semester }).ToList(); ;



            var SemTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select Semester ---"
            };
            semLiIst.Insert(0, SemTip);
            ViewBag.semLiIst = new SelectList(semLiIst, "Value", "Text");
            return View();
        }

        //Thing done by Dileep 
        //public IActionResult GetStudentResult(Student student)
        //{
        //    var resultView = new StudentResultView();

        //    List<SelectListItem> semLiIst = _sservice.GetSemesters().Select(n => new SelectListItem { Value = n.SemesterId.ToString(), Text = n.semester }).ToList(); ;
        //    var SemTip = new SelectListItem()
        //    {
        //        Value = null,
        //        Text = "--- select Semester ---"
        //    };
        //    semLiIst.Insert(0, SemTip);
        //    ViewBag.semLiIst = new SelectList(semLiIst, "Value", "Text");
        //   List<Result> result = _service.GetResult(student.StudentId, student.Semester);
        //    //resultView. = result;

        //    return View(result);
        //}

        //Thing By Mounesh
        public IActionResult GetStudentResult(Student student)
        {
            var resultView = new StudentResultView();

            List<SelectListItem> semLiIst = _sservice.GetSemesters().Select(n => new SelectListItem { Value = n.SemesterId.ToString(), Text = n.semester }).ToList(); ;
            var SemTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select Semester ---"
            };
            semLiIst.Insert(0, SemTip);
            ViewBag.semLiIst = new SelectList(semLiIst, "Value", "Text");

            //List<Result> result = _service.GetResult(student.StudentId, student.Semester);
            resultView.Result = _service.GetResult(student.StudentId, student.Semester);
            resultView.Student = _service.GetStudent(student.StudentId);
            resultView.subjects = _subservice.GetSubjects().Where(n => n.bId == resultView.Student.BId).ToList();
            return View(resultView);
        }


    }
}
