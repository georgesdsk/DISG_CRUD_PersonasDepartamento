using CRUD_PersonasDef_DAL.Listados;
using CRUD_PersonasDef_Entidades;
using System;
using System.Collections.Generic;
using System.Text;


// esto puede fallar
namespace CRUD_PersonasDef_BL
{
   public class listadoPersonasBL
    {

        ListadoPersonasDAL gestionListaPersonasDAL;

        public listadoPersonasBL()
        {
            gestionListaPersonasDAL = new ListadoPersonasDAL();
        }

        #region metodos

        public List<clsPersona> ListaPersonasBL { get {

                return gestionListaPersonasDAL.GetListadoPersonas();
            } 
        }

        #endregion
    }
}
