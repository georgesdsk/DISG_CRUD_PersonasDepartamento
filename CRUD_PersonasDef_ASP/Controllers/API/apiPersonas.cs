using CRUD_PersonasDef_BL;
using CRUD_PersonasDef_BL.Gestoras;
using CRUD_PersonasDef_Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
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
            /*
            if (personas == null || personas.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }
            */

            return personas;
        }

        // GET api/<apiPersonas>/5
        [HttpGet("{id}")]
        public clsPersona Get(int id)
        {

            GestoraPersonaBL bl = new GestoraPersonaBL();
            clsPersona persona = new clsPersona();

            try
            {
                persona = bl.getPersona(id);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }


            return persona ;
        }

        // POST api/<apiPersonas>
        [HttpPost]
        public void Post([Microsoft.AspNetCore.Mvc.FromBody] clsPersona persona)
        {
            GestoraPersonaBL bl = new GestoraPersonaBL();
            

            try
            {
               bl.InsertPersona(persona);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }

        }

        // PUT api/<apiPersonas>/5
        [HttpPut("{id}")]
        public void Put(int id, [Microsoft.AspNetCore.Mvc.FromBody] clsPersona value)
        {

            GestoraPersonaBL bl = new GestoraPersonaBL();
            

            try
            {
                bl.UpdatePersonaBL(value);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }


        }

        // DELETE api/<apiPersonas>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            GestoraPersonaBL bl = new GestoraPersonaBL();

            try
            {
                bl.BorrarPersonaBL(id);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }

        }
    }
}
