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
    public class AutoController : Controller
    {
        private IAutoService Service;
        public AutoController(IAutoService service)
        {
            Service = service;
        }
        // GET: api/<controller>
        [HttpGet]
        public IList<AutoDTO> Get()
        {
            return Service.GetAll();
        }
        // GET api/<controller>/5
        [HttpGet("{AutoId}")]

        public AutoDTO Get(Guid AutoId)
        {

            return Service.GetAll().Where(p => p.AutoId == AutoId).FirstOrDefault();
        }
        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AutoDTO auto)
        {
            await Service.Insert(auto);
            return Ok(true);
        }
        // PUT api/<controller>/5
        [HttpPut("{AutoId}")]
        public async Task<IActionResult> Put(Guid AutoId, [FromBody]AutoDTO auto)
        {
            auto.AutoId = AutoId;
            await Service.Insert(auto);
            return Ok(true);
        }
        // DELETE api/<controller>/5
        [HttpDelete("{AutoId}")]
        public IActionResult Delete(Guid AutoId)
        {
            Service.Delete(AutoId);
            return Ok(true);
        }
    }
}
