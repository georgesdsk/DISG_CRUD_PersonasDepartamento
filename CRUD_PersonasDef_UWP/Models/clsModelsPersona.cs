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
    public class clsPersonaModel : clsPersona
    {
        String nombreDepartamento; // esto se tiene que rellenar en el viewModel


        public clsPersonaModel(string nombre, string apellidos, string direccion, DateTime fecha, int tel, int idDepartamento, string urlFoto, string nombreDepartamento)
           : base(nombre, apellidos, direccion, fecha, tel, idDepartamento, urlFoto)
        {
            this.NombreDepartamento = nombreDepartamento;

        }

        public string NombreDepartamento { get => nombreDepartamento; set => nombreDepartamento = value; }
    }
}
