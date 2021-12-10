using CRUD_PersonasDef_DAL.Gestora;
using CRUD_PersonasDef_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_PersonasDef_BL.Gestoras
{

    /// <summary>
    ///  funcionalidad de intermediario con la base de datos
    /// </summary>
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

        public void UpdateDepartamentoBL(clsDepartamento departamentoSeleccionado)
        {
            throw new NotImplementedException();
        }

        public void InsertDepartamento(clsDepartamento departamentoSeleccionado)
        {
            throw new NotImplementedException();
        }

        public void BorrarDepartamentoBL(object id)
        {
            throw new NotImplementedException();
        }
    }
}
