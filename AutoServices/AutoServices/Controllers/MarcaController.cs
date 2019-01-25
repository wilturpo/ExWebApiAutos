using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoServices.Models.Repositories;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutoServices.Controllers
{
    [Route("api/[controller]")]
    public class MarcaController : Controller
    {
        private IMarcaRepository repositorio;
        public MarcaController(IMarcaRepository repo)
        {
            repositorio = repo;
        }

        // GET: api/<controller>
        [HttpGet]
        public IQueryable<TMarca> Get()
        {
            return repositorio.Items;
        }

        // GET api/<controller>/5
        [HttpGet("{MarcaId}")]
        public TMarca Get(Guid MarcaId)
        {
            return repositorio.Items.Where(p => p.MarcaId == MarcaId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TMarca marca)
        {
            await repositorio.Save(marca);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{MarcaId}")]
        public async Task<IActionResult> Put(Guid MarcaId, [FromBody]TMarca marca)
        {
            marca.MarcaId = MarcaId;
            await repositorio.Save(marca);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{MarcaId}")]
        public IActionResult Delete(Guid MarcaId)
        {
            repositorio.Delete(MarcaId);
            return Ok(true);
        }
    }
}
