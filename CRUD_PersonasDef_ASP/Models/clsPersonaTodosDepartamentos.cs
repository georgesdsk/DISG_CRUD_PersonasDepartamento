using CRUD_PersonasDef_Entidades;
using System;
using System.Collections.Generic;

namespace CRUD_PersonasDef_ASP.Models
{

    /// <summary>
    /// Este modelo esta hecho para almacenar la informacion necesaria para la vista de edicion de la persona, asi que el usuario tendra la posibilidad de eligir entre todos los departamentos
    /// </summary>
    public class clsPersonaTodosDepartamentos : clsPersonaConDepartamento
    {

        List<clsDepartamento> departamentos;

        public clsPersonaTodosDepartamentos(int id, string nombre, string apellidos, string direccion, DateTime fecha, int tel, int idDepartamento, string urlFoto, string nombreDepartamento, List<clsDepartamento> departamentos) :
            base(id, nombre, apellidos, direccion, fecha, tel, idDepartamento, urlFoto, nombreDepartamento)
        {
            this.Departamentos = departamentos;
        }

        public clsPersonaTodosDepartamentos( clsPersonaConDepartamento cclsPersonaConDepartamento, List<clsDepartamento> departamentos) : base(cclsPersonaConDepartamento.Id, cclsPersonaConDepartamento.Nombre, cclsPersonaConDepartamento.Apellidos,
        cclsPersonaConDepartamento.Direccion, cclsPersonaConDepartamento.FechaNacimiento, cclsPersonaConDepartamento.Telefono, cclsPersonaConDepartamento.IDDepartamento, cclsPersonaConDepartamento.Foto, cclsPersonaConDepartamento.NombreDepartamento)
        {
            this.departamentos = departamentos;
        }

        /// <summary>
        /// Constructor para el modelo de la vista donde se crea una nueva persona
        /// </summary>
        /// <param name="departamentos"></param>
        public clsPersonaTodosDepartamentos(List<clsDepartamento> departamentos)
        {
            this.departamentos= departamentos;
        }

        public List<clsDepartamento> Departamentos { get => departamentos; set => departamentos = value; }
    }
}
