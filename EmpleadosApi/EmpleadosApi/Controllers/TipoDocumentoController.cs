using DataLayer;
using Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleadosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TipoDocumentoController : ControllerBase
    {
        // GET: api/<EmpleadosController>
        [HttpGet]
        [Authorize]
        public IEnumerable<TipoDocumento> Get()
        {
            List<TipoDocumento> result = new TipoDocumentoDAL().SelectCommand();
            return result;
        }
    }
}
