using Microsoft.AspNetCore.Mvc;
using SRM_MVC.Models;
using SRM_MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SRM_MVC.Controllers
{
    public class AdminController : Controller
    {
        public static string FirstName_Regex = "^[A-Za-z]{4,50}$";
        public static string LastName_Regex = "^[A-Za-z]{4,50}$";

        public static string MoblieNumber_Regex = "^[6-9]{1}[0-9]{9}$";
        public static string Email_Regex = "^[0-9a-zA-Z]+[.+-_]{0,4}[0-9a-zA-Z]+[@][a-zA-Z]+[.][a-zA-Z]{2,3}$";
        public static string Password_Regex = "^[a-zA-Z0-9]{4,10}";
        //public static string Password_Regex = "^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[]:;<>,.?/~_+-=|]).{5,32}$";
        private IAdminService _service = null;

        public AdminController(IAdminService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAdmin(Admin admin)
        {

            try
            {
                if (admin == null)
                {
                    ViewBag.Error = "Fileds Can Not Be Empty";
                    return View();
                }
                if (ModelState.IsValid)
                {
                    if (admin.AdminFirstName.Equals(FirstName_Regex) && admin.AdminLastName.Equals(LastName_Regex) && admin.AdminEmail.Equals(Email_Regex))
                    {

                        _service.AddAdmin(admin);
                        return RedirectToAction("GetAdmins");

                    }
                    else
                    {
                        return View();
                    }
                }
                else 
                {
                    return View();
                }

               
            }
            catch (Exception e)
            {
                return View(e.Message);
            }

        }
        [HttpGet]
        public IActionResult GetAdmins()
        {

            return View(_service.GetAdmins());
        }

        [HttpGet]

        public IActionResult Get(int id)
        {
            try
            {
                var admins = _service.GetAdmin(id);
                if (admins != null)
                    return Ok(admins);
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
            Admin admin = _service.GetAdmin(id);
            return View(admin);
        }
        [HttpPost]

        public IActionResult Edit(Admin admin)
        {
            _service.UpdateAdmin(admin);

            return RedirectToAction("GetAdmins");
        }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            Admin admin = _service.GetAdmin(id);

            return View(admin);
        }

        [HttpPost]
        public IActionResult Delete(Admin admin)
        {
            _service.DeleteAdmin(admin.AdminId);

            return RedirectToAction("GetAdmins");
        }

        //-----------------------------------Login and Logout----------------------------------------------------

        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel() { Message = ex.Message, Controller = "Admin", Action = "Login" });
            }
        }

        [HttpGet]
        [Route("LogOff")]
        public IActionResult LogOff()
        {
            try
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel() { Message = ex.Message, Controller = "Admin", Action = "LogOff" });
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string Id, string Password)
        {

            try
            {
                if (Id != null && Password != null)
                {

                    if (Id == "Admin12" && Password == "Admin@12")
                    {
                        return RedirectToAction("DashBoard", "Admin");
                    }

                    //else
                    //{

                    //    User user = _service.UserLogin(Id, Password);
                    //    if (user != null)
                    //    {
                    //        HttpContext.Session.SetInt32("UserId", user.UserID);
                    //        HttpContext.Session.SetString("UserName", user.UserName);
                    //        return RedirectToAction("UserHomePage", "User");
                    //    }
                    //    else
                    //    {
                    //        ViewBag.Error = "Invalid Credentials";
                    //        return View();
                    //    }

                    //}

                    else
                    {
                        //viewbag.error = "please give input";
                        //return view();
                        return View();
                    }
                }

                else
                {
                    // return 1;
                    ViewBag.Error = "Please give input";
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel() { Message = ex.Message, Controller = "Admin", Action = "Login" });
            }
        }

        [HttpGet]
        [Route("AdminDashBoard")]
        public IActionResult DashBoard()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel() { Message = ex.Message, Controller = "Admin", Action = "DashBoard" });
            }
        }
    }
}
