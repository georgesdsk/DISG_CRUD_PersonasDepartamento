using CRUD_PersonasDef_ASP.Models;
using CRUD_PersonasDef_Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_PersonasDef_ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //VIEWMODEL


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Muerta toda la lista de personas
        /// </summary>
        /// <returns></returns>

        public IActionResult Index()
        {
            ViewModelPersonas viewModelPersonas = new ViewModelPersonas();  
            return View(viewModelPersonas.VmListaPersonasConDepartamento);
        }

        public IActionResult Delete(int id) {
            ViewModelPersonas viewModelPersonas = new ViewModelPersonas();
            return View(viewModelPersonas.getPersona(id));
        }
        public IActionResult DeleteAction(int id)
        {
            ViewModelPersonas viewModelPersonas = new ViewModelPersonas();
            accionaRealizada(viewModelPersonas.DeletePersona(id));
            return View("Index", viewModelPersonas.VmListaPersonasConDepartamento);
        }
        public IActionResult Update(int id) {
            ViewModelPersonas viewModelPersonas = new ViewModelPersonas();
            return View("Update", viewModelPersonas.getPersona(id));
        }

        [HttpPost]
        public IActionResult Update(clsPersona clsPersona) {
            ViewModelPersonas viewModelPersonas = new ViewModelPersonas();
            accionaRealizada(viewModelPersonas.UpdatePersona(clsPersona));
            viewModelPersonas = new ViewModelPersonas(); //actualizamos la lista, TODO METODO PARA ACTULZARLA Y NO LLAMAR AL CONSTRUCTOR
            return View("Index", viewModelPersonas.VmListaPersonasConDepartamento);
        }

      

        /// <summary>
        /// Analisis: 
        /// </summary>
        /// <param name="resultado"></param>
        public void accionaRealizada(int resultado) {
            if (resultado > 0)
            {
                ViewBag.mensaje = "Accion realizada con exito";
            }
            else
            {
                ViewBag.mensaje = "Ha habido un fallo";
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
