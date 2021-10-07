using Microsoft.AspNetCore.Mvc;
using System;
using SRM_API.Models;
using SRM_API.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private IGenericRepository<Courses> _repository = null;

        public CourseController()
        {
            this._repository = new GenericRepository<Courses>();
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var courses = _repository.GetAll();
            if (courses != null)

            {
                return Ok(courses);
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
                var course = _repository.GetById(id);
                if (course != null)
                    return Ok(course);
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
        public IActionResult Add(Courses course)
        {
            try
            {
                _repository.Insert(course);
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
        public IActionResult Update(Courses course)
        {
            try
            {
                _repository.Update(course);
                return Ok();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
        [HttpDelete]
        [Route("Delete")]
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
    }
}
