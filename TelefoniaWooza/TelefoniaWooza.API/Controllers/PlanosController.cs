using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelefoniaWooza.Application;
using TelefoniaWooza.Domain.Entities;
using TelefoniaWooza.Domain.Enumerators;

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

        [HttpGet("{ddd}/tipo/{tipo}")]
        public IActionResult GetTipo(string ddd, TipoPlano tipo)
        {
            try
            {
                var planos = _planoApplication.GetByTipo(ddd, tipo);
                if(planos is null)
                {
                    return NotFound();
                }
                return new ObjectResult(planos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{ddd}/operadora/{operadora}")]
        public IActionResult GetOperadora(string ddd, string operadora)
        {
            try
            {
                var planos = _planoApplication.GetByOperadora(ddd, operadora);
                if (planos is null)
                {
                    return NotFound();
                }
                return new ObjectResult(planos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{ddd}/plano/{plano}")]
        public IActionResult GetPlano(string ddd, string plano)
        {
            try
            {
                var planos = _planoApplication.GetByPlano(ddd, plano);
                if (planos is null)
                {
                    return NotFound();
                }
                return new ObjectResult(planos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromQuery]int id,[FromBody] Plano item)
        {
            try
            {
               _planoApplication.Update(item);

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

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _planoApplication.Delete(id);

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
        
        
    }
}
