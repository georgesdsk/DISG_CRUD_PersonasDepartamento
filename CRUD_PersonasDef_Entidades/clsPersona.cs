using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Ejercicios_UD10.Models
{
    public class clsPersona :INotifyPropertyChanged
    {
        #region atributos privados
        private string nombre;
        private string apellidos;
        private int telefono;
        private string direccion;
        private byte[] foto;
        //foto
        //Para añadir foto a bdd poner url d una foto que esté subida a un servidor
        // Tanmbien se puede añadir mediante un array de bytes. Consultar
        //Datetime
        private string fechaNacimiento;
        private int IDDepartamento;
        
        #endregion
        #region propiedades publicas
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

        public string Apellido
        {
            get
            {
                return apellido;
            }
            set
            {
                apellido = value;
            }
        }

        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public String FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        #endregion
        #region constructores
        //Constructor por defecto

        public clsPersona(string nombre, string apellido, string direccion, string fecha, int tel) {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Direccion = direccion;
            this.FechaNacimiento = fecha;
            this.Telefono = tel;
        }
        public clsPersona() {
           
        }
        #endregion
        #region metodos
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}

