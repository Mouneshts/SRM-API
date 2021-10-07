using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SRM_API.Repositories;
using SRM_API.Models;
using SRM_API.Context;

namespace SRM_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IGenericRepository<Student> _repository = null;

        public StudentController()
        {
            this._repository = new GenericRepository<Student>();
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var students = _repository.GetAll();
            if (students != null)
            {
                return Ok(students);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var student = _repository.GetById(id);
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
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(Student student)
        {
            try
            {
                _repository.Insert(student);
                _repository.Save();
                return Ok();
            }
            catch (Exception ex)
            {

                return Content(ex.InnerException.Message);
            }
        }
        [HttpPut]
        [Route("Edit")]
        public IActionResult Update(Student student)
        {
            try
            {
                _repository.Update(student);
                return Ok();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                _repository.Save();
                return Ok();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetResult")]
        public IActionResult GetResult(int StudentId,int semester)
        {
            try
            {
                MyContext dB = new MyContext();
               
                var studentResult = dB.results.Where(i=>i.SId == StudentId && i.Rsemester.semester == semester.ToString());
                if (studentResult != null)
                    return Ok(studentResult);
                else
                    return Content("Invalid Id");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }


    }
}