using CRUD_PersonasDef_ASP.Models;
using CRUD_PersonasDef_Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
         *  Validar en el servidor???
         *  Cargar la imagen
         *  Excepciones en la vista de edit 
            Validar fecha?
         * */

        /// <summary>
        /// Muestra toda la lista de personas
        /// </summary>
        /// <returns></returns>

        public IActionResult Index()
        {
            ViewModelPersonas viewModelPersonas = new ViewModelPersonas();
            List<clsPersonaConDepartamento> listaPersonas = viewModelPersonas.VmListaPersonasConDepartamento;
            if (listaPersonas == null) // si la llamada a lista de la bl a dado error
            {
                ViewBag.mensajeNegativo = MENSAJE_ERROR;
                listaPersonas = new List<clsPersonaConDepartamento>();// para que se me muestre la lista vacia y no de un null pointer en la vista principal
            }
            else if (TempData["resultado"] != null) { // si se ha ejecutado algun cambio anteriormente

                if ((int)TempData["resultado"] > 0)
                {
                    ViewBag.mensajePositivo = MENSAJE_EXITO;
                }
                else {
                    ViewBag.mensajeNeggativo = MENSAJE_ERROR;
                }

            }

            return View(listaPersonas);

        }


        public IActionResult Delete(int id)
        {
            ViewModelPersonas viewModelPersonas = new ViewModelPersonas();
            IActionResult vista;
            Models.clsPersonaConDepartamento personaAuxiliar = viewModelPersonas.getPersona(id);
            if (personaAuxiliar == null) // si ha dado excepcion
            {
                vista = RedirectToAction(nameof(Index));
            }
            else
            {
                vista = View(personaAuxiliar);
            }
            return vista;
        }


        [HttpPost]
        [ActionName ("Delete")]
        public IActionResult DeleteBoton(int id)
        {
            ViewModelPersonas viewModelPersonas = new ViewModelPersonas();
            TempData["resultado"] = viewModelPersonas.DeletePersona(id);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int id)
        {
            ViewModelPersonas viewModelPersonas = new ViewModelPersonas();
            clsPersonaTodosDepartamentos personaAuxiliar = viewModelPersonas.getPersonaConDepartamentos(id);
            IActionResult vista;
            if (personaAuxiliar == null) // si ha dado excepcion
            {
                TempData["resultado"] = -1;
                vista = RedirectToAction(nameof(Index));
            }
            else
            {
                vista = View(personaAuxiliar);
            }
            return vista;
        }


        [HttpPost]
        public IActionResult Update(int id, clsPersonaConDepartamento persona)
        {
            ViewModelPersonas viewModelPersonas = new ViewModelPersonas();
            TempData["resultado"] = viewModelPersonas.UpdatePersona(persona);
            return RedirectToAction(nameof(Index)); //return RedirectToAction(nameof(Index));
        }


        public IActionResult Create()
        {
            ViewModelPersonas viewModelPersonas = new ViewModelPersonas();
            clsPersonaTodosDepartamentos personaAuxiliar = viewModelPersonas.newPersona();
            IActionResult vista;
            if (personaAuxiliar == null) // si ha dado excepcion
            {
                TempData["resultado"] = -1;
                vista = RedirectToAction(nameof(Index));
            }
            else
            {
                vista = View(personaAuxiliar);
            }
            return vista;
        }
        /// <summary>
        /// Analisis: la lista collection se convierte en atributos de persona y es enviada para añadirla para la base de datos, aqui necesitaria una persona normal, sin nombre departamento
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Create(clsPersonaConDepartamento persona)
        {
            ViewModelPersonas viewModelPersonas = new ViewModelPersonas();
            TempData["resultado"] = viewModelPersonas.create(persona);
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Analisis: Muestra los detalles de la persona pasada por paramtros
        /// Precondiciones: id > 0 y menor o igual que el id de la ultima persona 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 

        public IActionResult Details(int id)
        {
            ViewModelPersonas viewModelPersonas = new ViewModelPersonas();
            clsPersonaConDepartamento personaAuxiliar;
            personaAuxiliar = viewModelPersonas.getPersona(id); // si da una excepcion en el viewmodel, devolvera un null;
            IActionResult vista;
            if (personaAuxiliar == null)
            {
                TempData["resultado"] = -1;
                vista= RedirectToAction(nameof(Index));
            }
            else
            {
                vista = View(personaAuxiliar);
            }

            return vista;
        }


        /**
        /// <summary>
        /// Recibe una coleccion de datos de la vista y la convierte en una personal, se utiliiza en el metodo de actualizar persona y anhadir persona
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        /// 

        private clsPersona construirPersona(IFormCollection collection)
        {

            string nombre, apellidos, direccion, urlFoto, idCondicion;
            int id, tel, idDepartamento;
            DateTime fecha;
            if ((idCondicion = collection["id"]) == null)
            {
                id = 0; //Se utiliza para que el metodo no de error a la hora de crear una persona, que tiene el id a null ya que se tiene que autogenerar
            }
            else
            {
                id = Int32.Parse(collection["id"]);
            }
            nombre = collection["Nombre"];
            apellidos = collection["Apellidos"];
            direccion = collection["Direccion"];
            fecha = DateTime.Parse(collection["FechaNacimiento"]);
            tel = Int32.Parse(collection["Telefono"]);
            idDepartamento = Int32.Parse(collection["IDDepartamento"]);
            urlFoto = collection["Foto"];

            return new clsPersona(id, nombre, apellidos, direccion, fecha, tel, idDepartamento, urlFoto);

        }
        */

        // se puede hacer un recurso no estatico?


        /// <summary>
        /// Analisis: Mostrara un mensaje en la pantalla principal que indicara si la accion realizada ha sido satisfactoria(x>0), si ha fallado la base de datos(x-1), o si no se ha modificado nada 
        /// </summary>
        /// <param name="resultado"></param>


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
