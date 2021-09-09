using APIServicios.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        private readonly ISheetsReaderBusiness _sheetsReaderBusiness;
        public RegistroController(ISheetsReaderBusiness sheetsReaderBusiness)
        {
            this._sheetsReaderBusiness = sheetsReaderBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var a = await _sheetsReaderBusiness.startExec();
            return Ok(JsonConvert.SerializeObject(a)) ;
        }
    }
}
