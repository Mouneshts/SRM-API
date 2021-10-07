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
    public class SubjectController : ControllerBase
    {
        private IGenericRepository<Subjects> _repository = null;

        public SubjectController()
        {
            this._repository = new GenericRepository<Subjects>();
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var subjects = _repository.GetAll();
            if (subjects != null)

            {
                return Ok(subjects);
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
                var subject = _repository.GetById(id);
                if (subject != null)
                    return Ok(subject);
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
        public IActionResult Add(Subjects subject)
        {
            try
            {
                _repository.Insert(subject);
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
        public IActionResult Update(Subjects subject)
        {
            try
            {
                _repository.Update(subject);
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
