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

      
        public int UpdateDepartamentoBL(clsDepartamento departamentoSeleccionado)
        {
            return gestoraDepartamentos.UpdateDepartamento(departamentoSeleccionado);
        }

        public int  InsertDepartamento(string nombreDepartamento)
        {
            return gestoraDepartamentos.InsertDepartamento(nombreDepartamento);
        }

        public int BorrarDepartamentoBL(int idDepartamento)
        {
            return gestoraDepartamentos.DeleteDepartamento(idDepartamento); // se puede hacer que las personas se queden en la base de datos, incluso desde aqui, tienes que mirar que personas tienen x departamento e insertarlo en otro// o simplemente borrarlo y dejarlo en null en la bbdd( MIRARLO)
        }
    }
}
