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
    public class SubAreaController : ControllerBase
    {
        // GET: api/<SubAreaController>
        [HttpGet]
        [Authorize]
        public IEnumerable<SubArea> Get()
        {
            return new SubAreaDAL().SelectCommand();
        }

        // GET api/<SubAreaController>/5
        [HttpGet("{id}")]
        [Authorize]
        public SubArea Get(int id)
        {
            return new SubAreaDAL().SelectCommandBy_IdArea(id);
        }

        // POST api/<SubAreaController>
        [HttpPost]
        [Authorize]
        public void Post([FromBody] SubArea value)
        {
            new SubAreaDAL().InsertCommand(value);
        }

        // PUT api/<SubAreaController>/5
        [HttpPut]
        [Authorize]
        public void Put([FromBody] SubArea value)
        {
            new SubAreaDAL().UpdateCommand(value);
        }

        // DELETE api/<SubAreaController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
            new SubAreaDAL().DeleteCommand(id);
        }
    }
}
