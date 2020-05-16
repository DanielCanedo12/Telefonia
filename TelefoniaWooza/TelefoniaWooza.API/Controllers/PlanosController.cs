using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelefoniaWooza.Application;
using TelefoniaWooza.Domain.Entities;

namespace TelefoniaWooza.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PlanosController : ControllerBase
    {
        private readonly PlanoApplication _planoApplication;
        public PlanosController(PlanoApplication planoApplication)
        {
            _planoApplication = planoApplication;
        }

        [HttpPost]
        public IActionResult Post([FromForm] Plano item)
        {
            try
            {
                _planoApplication.Add(item);

                return new ObjectResult(item.Id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(_planoApplication.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /*
        public IActionResult Put([FromBody] Plano item)
        {
            try
            {
                service.Put<PlanoValidator>(item);

                return new ObjectResult(item);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);

                return new NoContentResult();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

       
        public IActionResult Get(int id)
        {
            try
            {
                return new ObjectResult(service.Get(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult GetByOperadora(string operadora)
        {
            try
            {
                return new ObjectResult(service.SearchByOperadora(operadora));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult GetByTipo(string tipo)
        {
            try
            {
                return new ObjectResult(service.SearchByTipo(tipo));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult GetByCodigo(string codigo)
        {
            try
            {
                return new ObjectResult(service.SearchByCodigo(codigo));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }*/
    }
}
