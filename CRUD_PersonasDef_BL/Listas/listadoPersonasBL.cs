using CRUD_PersonasDef_DAL.Gestora;
using CRUD_PersonasDef_DAL.Listados;
using CRUD_PersonasDef_Entidades;
using System;
using System.Collections.Generic;
using System.Text;


// esto puede fallar
namespace CRUD_PersonasDef_BL
{
   public class ListadoPersonasBL
    {

        ListadoPersonasDAL listaPersonasDAL;
        GestoraPersonasDAL gestoraPersonasDAL;

        public ListadoPersonasBL()
        {
            listaPersonasDAL = new ListadoPersonasDAL();
            gestoraPersonasDAL = new GestoraPersonasDAL();
        }

        #region metodos

        public List<clsPersona> ListaPersonasBL { get {

                return listaPersonasDAL.GetListadoPersonas();
            } 
        }

        public int BorrarPersonaBL(clsPersona personaSeleccionadavm)
        {
            return gestoraPersonasDAL.RemovePersona(personaSeleccionadavm.Id);

        }

#endregion
    }
}
