using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace CRUD_PersonasDef_Entidades
{
    public class clsPersona 
    {
        #region atributos privados
        private int id;
        private string nombre;
        private string apellidos;
        private int telefono;
        private string direccion;
        private string urlFoto;
        //foto
        //Para añadir foto a bdd poner url d una foto que esté subida a un servidor
        // Tanmbien se puede añadir mediante un array de bytes. Consultar
        //Datetime
        private DateTime fechaNacimiento;
        private int iDDepartamento;

        #endregion
        #region propiedades publicas
        public int Id { get => id; set => id = value; }


        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name ="Nombre")]
        [MaxLength(50)]
        public String Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Apellidos")]
        [MaxLength(50)]
        public string Apellidos
        {
            get
            {
                return apellidos;
            }
            set
            {
                apellidos = value;
            }
        }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Direccion")]
        [MaxLength(100)]
        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        [Required(ErrorMessage = "Campo obligatorio")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        [DataType(DataType.PhoneNumber)]
        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Foto { get => urlFoto; set => urlFoto = value; }

        public int IDDepartamento { get => iDDepartamento; set => iDDepartamento = value; }
        #endregion
        #region constructores
        //Constructor por defecto

        public clsPersona(int id, string nombre, string apellidos, string direccion, DateTime fecha, int tel, int idDepartamento, String urlFoto) {
            this.id = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Direccion = direccion;
            this.FechaNacimiento = fecha;
            this.Telefono = tel;
            this.IDDepartamento = idDepartamento;
            this.urlFoto = urlFoto;
        }

        public clsPersona(string nombre, string apellidos, string direccion, DateTime fecha, int tel, int idDepartamento, String urlFoto)
        {
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Direccion = direccion;
            this.FechaNacimiento = fecha;
            this.Telefono = tel;
            this.IDDepartamento = idDepartamento;
            this.urlFoto = urlFoto;
        }
        public clsPersona() {
           
        }
        #endregion
        
    
    }
}

