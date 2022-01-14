using CRUD_PersonasDef_BL.Gestoras;
using CRUD_PersonasDef_BL.Listas;
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
    public class apiDepartamentos : ControllerBase
    {
        // GET: api/<apiDepartamentos>
        [HttpGet]
        public List<clsDepartamento> Get()
        {
            ListadoDepartamentosBL bl = new ListadoDepartamentosBL();
            List<clsDepartamento> lista;


            try
            {
                lista = bl.ListaDepartamentosBL;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }

            /*
            if (lista == null || lista.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }
            */

            return lista;
        }

        // GET api/<apiDepartamentos>/5
        [HttpGet("{id}")]
        public clsDepartamento Get(int id)
        {
            GestoraDepartamentoBL bl = new GestoraDepartamentoBL();
            clsDepartamento departamento = null;

            try
            {
                // todo
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }

            return departamento;
        }

        // POST api/<apiDepartamentos>
        [HttpPost]
        public void Post([Microsoft.AspNetCore.Mvc.FromBody] clsDepartamento departamento)
        {
            GestoraDepartamentoBL bl = new GestoraDepartamentoBL();
            

            try
            {
                // todo
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }

        }

        // PUT api/<apiDepartamentos>/5
        [HttpPut("{id}")]
        public void Put(int id, [Microsoft.AspNetCore.Mvc.FromBody] clsDepartamento departamento)
        {

            GestoraDepartamentoBL bl = new GestoraDepartamentoBL();
           

            try
            {
                // todo
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }


        }

        // DELETE api/<apiDepartamentos>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            GestoraDepartamentoBL bl = new GestoraDepartamentoBL();

            try
            {
                // todo
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }

        }
    }
}
