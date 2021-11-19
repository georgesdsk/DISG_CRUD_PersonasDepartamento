using CRUD_PersonasDef_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_PersonasDef_UWP.Models
{

    /*Me tiene que venir la lista de clsPersona y cuando la reciba en el ViewModel la convierto en clModelsPersonadfsfdsfd
     */
   public class clsModelsPersona: clsPersona
    {
        private String nombreDepartamento;

        public clsModelsPersona(string nombreDepartamento)
        {
            this.nombreDepartamento = nombreDepartamento;
        }

        public string NombreDepartamento { get => nombreDepartamento; set => nombreDepartamento = value; }
    }
}
