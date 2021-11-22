using CRUD_PersonasDef_DAL.Gestora;
using CRUD_PersonasDef_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_PersonasDef_BL.Gestoras
{
   public  class GestoraPersonaBL
    {


        GestoraPersonas gestoraPersonaDAL;

        public GestoraPersonaBL()
        {
            gestoraPersonaDAL = new GestoraPersonas();
        }

        public int UpdatePersonaBL(clsPersona clsPersona)
        {
            return gestoraPersonaDAL.UpdatePersona(clsPersona);
        }


    }
}
