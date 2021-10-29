using DataLayer;
using Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmpleadosApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AreaController : ControllerBase
        {
            // GET: api/<AreaController>
            [HttpGet]
            [Authorize]
            public IEnumerable<Area> Get()
            {
                return new AreaDAL().SelectCommand();
            }

            // GET api/<AreaController>/5
        [HttpGet("{id}")]
        [Authorize]
        public Area Get(int id)
            {
                
                return new AreaDAL().SelectCommandBy_IdArea(id);
            }

            // POST api/<AreaController>
        [HttpPost]
        [Authorize]
        public void Post([FromBody] Area value)
            {
                new AreaDAL().InsertCommand(value);
            }

            // PUT api/<AreaController>/5
        [HttpPut]
        [Authorize]
        public void Put([FromBody] Area value)
            {
                new AreaDAL().UpdateCommand(value);
            }

            // DELETE api/<AreaController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
            {
            new AreaDAL().DeleteCommand(id);
        }
        }
}
