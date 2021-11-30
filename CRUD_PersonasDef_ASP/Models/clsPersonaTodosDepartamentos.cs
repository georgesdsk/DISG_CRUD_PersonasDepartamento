using CRUD_PersonasDef_Entidades;
using System;
using System.Collections.Generic;

namespace CRUD_PersonasDef_ASP.Models
{
    public class clsPersonaTodosDepartamentos : clsPersonaConDepartamento
    {

        List<clsDepartamento> departamentos;

        public clsPersonaTodosDepartamentos(int id, string nombre, string apellidos, string direccion, DateTime fecha, int tel, int idDepartamento, string urlFoto, string nombreDepartamento, List<clsDepartamento> departamentos) :
            base(id, nombre, apellidos, direccion, fecha, tel, idDepartamento, urlFoto, nombreDepartamento)
        {
            this.Departamentos = departamentos;
        }

        public clsPersonaTodosDepartamentos( clsPersonaConDepartamento cclsPersonaConDepartamento, List<clsDepartamento> departamentos) : base(cclsPersonaConDepartamnto.Id, cclsPersonaConDepartamnto.Nombre, cclsPersonaConDepartamnto.Apellidos,
        cclsPersonaConDepartamnto.Direccion, cclsPersonaConDepartamnto.FechaNacimiento, cclsPersonaConDepartamnto.Telefono, cclsPersonaConDepartamnto.IDDepartamento, cclsPersonaConDepartamnto.Foto)
        {
            NombreDepartamento = nombreDepartamento; 
        }


        public List<clsDepartamento> Departamentos { get => departamentos; set => departamentos = value; }
    }
}
