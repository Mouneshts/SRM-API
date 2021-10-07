using Microsoft.AspNetCore.Mvc;
using SRM_API.Models;
using SRM_API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {

        private IGenericRepository<Branch> _repository = null;

        public BranchController()
        {
            this._repository = new GenericRepository<Branch>();
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var branches = _repository.GetAll();
            if (branches != null)

            {
                return Ok(branches);
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
                var branch = _repository.GetById(id);
                if (branch != null)
                    return Ok(branch);
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
        public IActionResult Add(Branch branch)
        {
            try
            {
                _repository.Insert(branch);
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
        public IActionResult Update(Branch branch)
        {
            try
            {
                _repository.Update(branch);
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
