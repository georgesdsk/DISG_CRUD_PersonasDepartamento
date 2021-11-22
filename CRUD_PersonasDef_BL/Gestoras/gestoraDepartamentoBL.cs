using CRUD_PersonasDef_DAL.Gestora;
using CRUD_PersonasDef_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_PersonasDef_BL.Gestoras
{
   public class GestoraDepartamentoBL
    {
        gestoraDepartamentos gestoraDepartamentos;

        public GestoraDepartamentoBL()
        {
            gestoraDepartamentos = new gestoraDepartamentos() ;
        }

        public int UpdateDepartamento(clsDepartamento departamento) {
            return gestoraDepartamentos.UpdateDepartamento(departamento);
        }
    }
}
