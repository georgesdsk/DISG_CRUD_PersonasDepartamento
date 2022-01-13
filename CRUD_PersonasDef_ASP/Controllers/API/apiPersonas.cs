using CRUD_PersonasDef_BL;
using CRUD_PersonasDef_Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD_PersonasDef_ASP.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class apiPersonas : ControllerBase
    {
        // GET: api/<apiPersonas>
        [HttpGet]
        public List<clsPersona> Get()
        {
            ListadoPersonasBL bl = new ListadoPersonasBL();
            List<clsPersona> personas = new List<clsPersona>();

            try
            {
                personas = bl.ListaPersonasBL;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }

            if (personas == null || personas.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return personas;
        }

        // GET api/<apiPersonas>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return ;
        }

        // POST api/<apiPersonas>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<apiPersonas>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<apiPersonas>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
