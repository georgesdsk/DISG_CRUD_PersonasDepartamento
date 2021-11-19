using CRUD_PersonasDef_DAL.Listados;
using CRUD_PersonasDef_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_PersonasDef_BL.Listas
{
   public class gestionDepartamentosBL
    {
        List<clsDepartamento> listaDepartamentosBL;
        GestionListaDepartamentosDAL gestionListaDepartamentosDAL;

        public gestionDepartamentosBL()
        {
            gestionListaDepartamentosDAL = new GestionListaDepartamentosDAL();
        }

        public List<clsDepartamento> ListaDepartamentosBL { get {

              return  gestionListaDepartamentosDAL.ListadoDepartamentosDAL();

            }
        }
    }
}
