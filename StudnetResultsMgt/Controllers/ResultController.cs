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
    public class ResultController : ControllerBase
    {
        private IGenericRepository<Result> _repository = null;

        public ResultController()
        {
            this._repository = new GenericRepository<Result>();
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var results = _repository.GetAll();
            if (results!= null)

            {
                return Ok(results);
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
                var result = _repository.GetById(id);
                if (result != null)
                    return Ok(result);
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
        public IActionResult Add(Result result)
        {
            try
            {
                _repository.Insert(result);
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
        public IActionResult Update(Result result)
        {
            try
            {
                _repository.Update(result);
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
    }
}
