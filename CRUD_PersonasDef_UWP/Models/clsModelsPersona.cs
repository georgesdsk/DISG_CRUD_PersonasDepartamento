using CRUD_PersonasDef_Entidades;
using System;

namespace CRUD_PersonasDef_UWP.Models
{

    /// <summary>
    /// clase que ayuda al viewmodel a guardar toda la informacion de la persona en una variable
    /// </summary>
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
            this.Foto = "https://i.pinimg.com/236x/f1/f5/15/f1f5153cabe32239c85842fb4d0ba3c8--ps.jpg";

        }



        public string NombreDepartamento { get => nombreDepartamento; set => nombreDepartamento = value; }
    }



}
