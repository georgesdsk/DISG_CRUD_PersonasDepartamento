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

        public ListadoPersonasBL()
        {
            listaPersonasDAL = new ListadoPersonasDAL();
        }

        #region metodos

        public List<clsPersona> ListaPersonasBL { get {

                return listaPersonasDAL.GetListadoPersonas();
            } 
        }

        public int BorrarPersonaBL(clsPersona personaSeleccionadavm)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
