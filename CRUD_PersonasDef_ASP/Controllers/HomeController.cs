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
            return View(viewModelPersonas.ListaPersonasVMconDepartamento);
        }

        public IActionResult Delete(int id) {
            return View();
        }
        

             public IActionResult DeleteAction(int id)
        {
            ViewModelPersonas viewModelPersonas = new ViewModelPersonas();
            //tienes que pasarle la persona a borrar
            viewModelPersonas.DeletePersona(id);
            viewModelPersonas = new ViewModelPersonas();
            return View("Index", viewModelPersonas.ListaPersonasVMconDepartamento);
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
