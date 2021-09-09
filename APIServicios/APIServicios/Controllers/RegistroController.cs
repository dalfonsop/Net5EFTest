using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {


        [HttpGet]
        public IEnumerable<Object> Get()
        {
            var rng = new Random();
            return new List<Object>() ;
        }
    }
}
