using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SRM_API.Models;
using SRM_API.Repositories;
namespace SRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private IGenericRepository<Semester> _repository = null;

        public SemesterController()
        {
            this._repository = new GenericRepository<Semester>();
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var semesters = _repository.GetAll();
            if (semesters != null)

            {
                return Ok(semesters);
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
                var semester = _repository.GetById(id);
                if (semester != null)
                    return Ok(semester);
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
        public IActionResult Add(Semester semester)
        {
            try
            {
                _repository.Insert(semester);
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
        public IActionResult Update(Semester semester)
        {
            try
            {
                _repository.Update(semester);
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
