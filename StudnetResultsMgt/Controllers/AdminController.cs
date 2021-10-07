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
    public class AdminController : ControllerBase
    {
     
          private IGenericRepository<Admin> _repository = null;

            public AdminController()
            {
                this._repository = new GenericRepository<Admin>();
            }

            [HttpGet]
            [Route("GetAll")]
            public IActionResult GetAll()
            {
                var admins = _repository.GetAll();
                if (admins != null)
                {
                    return Ok(admins);
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
                    var admin = _repository.GetById(id);
                    if (admin != null)
                        return Ok(admin);
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
            public IActionResult Add(Admin admin)
            {
                try
                {
                    _repository.Insert(admin);
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
            public IActionResult Update(Admin admin)
            {
                try
                {
                    _repository.Update(admin);
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
