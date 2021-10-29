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
    public class EmpleadosController : ControllerBase
    {
        // GET: api/<EmpleadosController>
        [HttpGet]
        [Authorize]
        public IEnumerable<Empleado> Get(string filtro)
        {
            List<Empleado> result = new EmpleadoDAL().SelectCommand();
            
            if (!String.IsNullOrEmpty(filtro))
            {
                result = result.Where(x => x.NumeroDocumento.Contains(filtro) || x.Nombre.Contains(filtro)).ToList();
            }

            return result;
        }

        // GET api/<EmpleadosController>/5
        [HttpGet("{id}")]
        [Authorize]
        public Empleado Get(int id)
        {
            return new EmpleadoDAL().SelectCommandBy_IdEmpleado(id);
        }

        // POST api/<EmpleadosController>
        [HttpPost]
        [Authorize]
        public void Post([FromBody] Empleado empleado)
        {
            new EmpleadoDAL().InsertCommand(empleado);
        }

        // PUT api/<EmpleadosController>/5
        [HttpPut]
        [Authorize]
        public void Put([FromBody] Empleado empleado)
        {
            new EmpleadoDAL().UpdateCommand(empleado);
        }

        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
            new EmpleadoDAL().DeleteCommand(id);
        }
    }
}
