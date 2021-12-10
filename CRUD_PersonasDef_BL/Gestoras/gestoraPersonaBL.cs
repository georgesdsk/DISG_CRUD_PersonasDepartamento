using CRUD_PersonasDef_DAL.Gestora;
using CRUD_PersonasDef_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_PersonasDef_BL.Gestoras
{
   public  class GestoraPersonaBL
    {
        /// <summary>
        ///  funcionalidad de intermediario con la base de datos
        /// </summary>

        GestoraPersonas gestoraPersonaDAL;

        public GestoraPersonaBL()
        {
            gestoraPersonaDAL = new GestoraPersonas();
        }

        public int UpdatePersonaBL(clsPersona clsPersona)
        {
            return gestoraPersonaDAL.UpdatePersona(clsPersona);
        }

        public int BorrarPersonaBL(int id)
        {
            return gestoraPersonaDAL.RemovePersona(id);
        }

        public int InsertPersona(clsPersona clsPersona) {
        
            return gestoraPersonaDAL.insertPersona(clsPersona);
        
        }



    }
}
