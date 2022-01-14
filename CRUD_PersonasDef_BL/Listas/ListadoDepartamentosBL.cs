using CRUD_PersonasDef_DAL.Listados;
using CRUD_PersonasDef_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_PersonasDef_BL.Listas
{

    /// <summary>
    ///  funcionalidad de intermediario con la base de datos
    /// </summary>
    public class ListadoDepartamentosBL
    {
        List<clsDepartamento> listaDepartamentosBL;
        GestionListaDepartamentosDAL gestionListaDepartamentosDAL;

        public ListadoDepartamentosBL()
        {
            gestionListaDepartamentosDAL = new GestionListaDepartamentosDAL();
        }

        public List<clsDepartamento> ListaDepartamentosBL { get {

              return  gestionListaDepartamentosDAL.ListadoDepartamentosDAL();

            }
        }
        // el getDepartamento



    }
}
