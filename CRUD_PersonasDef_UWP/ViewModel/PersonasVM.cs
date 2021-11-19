using CRUD_PersonasDef_BL;
using CRUD_PersonasDef_DAL.Listados;
using CRUD_PersonasDef_Entidades;
using CRUD_PersonasDef_UWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_PersonasDef_UWP.ViewModel
{
    /// <summary>
    /// va a trabajar con todas las propiedasdses que necesita la vista Personas
    /// </summary>
    
   public class PersonasVM
    {

        // tengo que coger toda la lista de personas y la lista de departamentos con su ID y vincular persona.ID -> nombre departamento
        
        ObservableCollection<clsPersonaModel> vmListaPersonasConDepartamento;
        List<clsPersona> vmListaPersonasOrginal;
        List<clsDepartamento> clsDepartamentos; // para conseguir el nombre segun el id
        GestionListaPersonasBL gestionListaPersonasBL;
        GestionListaDepartamentosDAL gestionListaDepartamentosBL;


        /// <summary>
        /// Hacemos la llamada en el constructor ya que para hacer la vista hay que mostrar la lista 
        /// </summary>
        public PersonasVM()
        {
            gestionListaPersonasBL = new GestionListaPersonasBL();
            gestionListaDepartamentosBL = new Gestion();
            vmListaPersonasOrginal = gestionListaPersonasBL.ListaPersonasBL;



        
        }
    }
}
