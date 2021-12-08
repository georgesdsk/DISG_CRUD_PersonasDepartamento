using CRUD_PersonasDef_Entidades;
using System;

namespace CRUD_PersonasDef_UWP.Models
{

    /*Me tiene que venir la lista de clsPersona y cuando la reciba en el ViewModel la convierto en clModelsPersonadfsfdsfd
     */
    public class clsPersonaConDepartamento : clsPersona
    {
        String nombreDepartamento; // esto se tiene que rellenar en el viewModel


        public clsPersonaConDepartamento(int id, string nombre, string apellidos, string direccion, DateTime fecha, int tel, int idDepartamento, string urlFoto, string nombreDepartamento)
           : base(id, nombre, apellidos, direccion, fecha, tel, idDepartamento, urlFoto)
        {
            this.NombreDepartamento = nombreDepartamento;
        }

        public clsPersonaConDepartamento()
        {


            this.Nombre = "";
            this.Apellidos = "";
            this.Direccion = "";
            this.FechaNacimiento = DateTime.Now;
            this.Telefono = 34;
            this.IDDepartamento = 1;
            this.Foto = "1";

        }



        public string NombreDepartamento { get => nombreDepartamento; set => nombreDepartamento = value; }
    }



}
