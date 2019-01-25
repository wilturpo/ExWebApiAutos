using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.IServices;
using AutoServices.Models.Repositories;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutoServices.Controllers
{
    [Route("api/[controller]")]
    public class MarcaController : Controller
    {
        private IMarcaService Service;
        public MarcaController(IMarcaService service)
        {
            Service = service;
        }
        // GET: api/<controller>
        [HttpGet]
        public IList<MarcaDTO> Get()
        {
            return Service.GetAll();
        }
        // GET api/<controller>/5
        [HttpGet("{MarcaId}")]
        
        public MarcaDTO Get(Guid MarcaId)
        {

            return Service.GetAll().Where(p => p.MarcaId == MarcaId).FirstOrDefault();
        }
        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]MarcaDTO marca)
        {
            await Service.Insert(marca);
            return Ok(true);
        }
        // PUT api/<controller>/5
        [HttpPut("{MarcaId}")]
        public async Task<IActionResult> Put(Guid MarcaId, [FromBody]MarcaDTO marca)
        {
            marca.MarcaId = MarcaId;
            await Service.Insert(marca);
            return Ok(true);
        }
        // DELETE api/<controller>/5
        [HttpDelete("{MarcaId}")]
        public IActionResult Delete(Guid MarcaId)
        {
            Service.Delete(MarcaId);
            return Ok(true);
        }
    }
}
