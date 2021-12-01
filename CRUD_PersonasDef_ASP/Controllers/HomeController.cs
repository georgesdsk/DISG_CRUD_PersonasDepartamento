using CRUD_PersonasDef_ASP.Models;
using CRUD_PersonasDef_Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;




namespace CRUD_PersonasDef_ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private String MENSAJE_ERROR = "Ha habido un error en la conexión, reinicie la pagina";
        private String MENSAJE_EXITO = "La acción se ha completado correctamente";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
 
    /**TODO :
     *  LISTA DESPLEGABLE 
     *  ARREGLAR LA VISTA
     *  El viewBag no funcion con el RedirectToAction por lo que 
     * 
     * */

        /// <summary>
        /// Muestra toda la lista de personas
        /// </summary>
        /// <returns></returns>

        public IActionResult Index()
        {
            ViewModelPersonas viewModelPersonas = new ViewModelPersonas();
            List<clsPersonaConDepartamento> listaPersonas = viewModelPersonas.VmListaPersonasConDepartamento;
            
            if (listaPersonas == null)
            {
                ViewBag.mensajesNegativo = MENSAJE_ERROR;
            }
            return View(listaPersonas);

        }


        public IActionResult Delete(int id) {
            ViewModelPersonas viewModelPersonas = new ViewModelPersonas();
            Models.clsPersonaConDepartamento personaAuxiliar = viewModelPersonas.getPersona(id);
            if (personaAuxiliar == null) // si ha dado excepcion
            {
                ViewBag.mensajeNegativo = MENSAJE_ERROR;
                return RedirectToAction(nameof(Index));
            }
            else {
                
                return View(personaAuxiliar);
            }
        }


        [HttpPost]
        public IActionResult Delete(int id, clsPersonaConDepartamento)
        {
            ViewModelPersonas viewModelPersonas = new ViewModelPersonas();
            accionaRealizada(viewModelPersonas.DeletePersona(id));
            
        
        }


        public IActionResult Update(int id) {
            ViewModelPersonas viewModelPersonas = new ViewModelPersonas();
            clsPersonaTodosDepartamentos personaAuxiliar = viewModelPersonas.getPersonaConDepartamentos(id);
            if (personaAuxiliar == null) // si ha dado excepcion
            {
                ViewBag.mensajenNegativo = MENSAJE_ERROR;
                return View("Index", new List<clsPersonaConDepartamento>() );
            }
            else {
                
                return View(personaAuxiliar);
            }
        }


        [HttpPost]
        public IActionResult Update(int id, clsPersonaConDepartamento persona) {
            ViewModelPersonas viewModelPersonas = new ViewModelPersonas();
            accionaRealizada(viewModelPersonas.UpdatePersona(persona));
            return View(viewModelPersonas.getPersonaConDepartamentos(id)); //return RedirectToAction(nameof(Index));//

        }


        public IActionResult Create() {
            ViewModelPersonas viewModelPersonas = new ViewModelPersonas();
            return View(viewModelPersonas.newPersona());
        }
        /// <summary>
        /// Analisis: la lista collection se convierte en atributos de persona y es enviada para añadirla para la base de datos, aqui necesitaria una persona normal, sin nombre departamento
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Create(IFormCollection collection) {
            ViewModelPersonas viewModelPersonas = new ViewModelPersonas();
            accionaRealizada(viewModelPersonas.create(construirPersona(collection)));
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Analisis: Muestra los detalles de la persona pasada por paramtros
        /// Precondiciones: id > 0 y menor o igual que el id de la ultima persona 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 

        public IActionResult Details(int id) {
            ViewModelPersonas viewModelPersonas = new ViewModelPersonas();
            clsPersonaConDepartamento personaAuxiliar;
            personaAuxiliar = viewModelPersonas.getPersona(id);
            if (personaAuxiliar == null)
            {
                ViewBag.mensajeNegativo = MENSAJE_ERROR;
                return View("Index");
            }
            else {
                return View(personaAuxiliar);
            }  
        }
        /// <summary>
        /// Recibe una coleccion de datos de la vista y la convierte en una personal, se utiliiza en el metodo de actualizar persona y anhadir persona
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        /// 

        private clsPersona construirPersona(IFormCollection collection) {
            
            string nombre, apellidos, direccion, urlFoto, idCondicion;
            int id, tel, idDepartamento;
            DateTime fecha;
            if ( (idCondicion=collection["id"]) == null )
            {
                id = 0; //Se utiliza para que el metodo no de error a la hora de crear una persona, que tiene el id a null ya que se tiene que autogenerar
            }
            else {
                 id = Int32.Parse(collection["id"]);
            }
            nombre = collection["Nombre"];
            apellidos = collection["Apellidos"];
            direccion = collection["Direccion"];
            fecha = DateTime.Parse(collection["FechaNacimiento"]);
            tel = Int32.Parse(collection["Telefono"]);
            idDepartamento = Int32.Parse(collection["IDDepartamento"]);
            urlFoto  = collection["Foto"];

            return new clsPersona(id, nombre, apellidos, direccion, fecha, tel, idDepartamento, urlFoto);

        }

        // se puede hacer un recurso no estatico?


        /// <summary>
        /// Analisis: Mostrara un mensaje en la pantalla principal que indicara si la accion realizada ha sido satisfactoria(x>0), si ha fallado la base de datos(x-1), o si no se ha modificado nada 
        /// </summary>
        /// <param name="resultado"></param>
        private void accionaRealizada(int resultado) {
            if (resultado > 0)
            {
                ViewBag.mensajePositivo = "Accion realizada con exito";
            }
            else if(resultado == -1)
            {
                ViewBag.mensajeNegativo = MENSAJE_ERROR;
            }else 
            {
                ViewBag.mensajeNegativo = "Error, no se ha modificado la informacion";
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
