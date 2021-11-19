using CRUD_Personas_DAL.Conexion;
using Ejercicios_UD10.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_PersonasDef_DAL.Gestora
{
    public class GestoraPersonas
    {
        string CONSULTA_PERSONAS = "SELECT * FROM Personas";
        private clsMyConnection miConexion;
        private SqlDataReader miLector;
        // Es mejor poner un datareader por cada metodo o uno comun para todos (Si se pueden ejecutar varios a la vez)
        private SqlCommand miComando;
        ObservableCollection<clsPersona> nuestraGente;
        
        public GestoraPersonas()
        {
            miConexion = new clsMyConnection();
            nuestraGente = GetListadoPersonas();
        }

        public ObservableCollection<clsPersona> NuestraGente { get => nuestraGente; set => nuestraGente = value; }

        #region metodos
        // Este metodo deberia devolver un data reader cargado con la info y la clsListado generara la lista
        public ObservableCollection<clsPersona> GetListadoPersonas()
        {
            miComando = new SqlCommand();
            ObservableCollection<clsPersona> nuestroPueblo = new ObservableCollection<clsPersona>();
            clsPersona nuestraPersona;
            miComando.CommandText = CONSULTA_PERSONAS;
            SqlConnection c = miConexion.getConnection(); // referenciamos la conexion a una variable para luego cerrarla
            miComando.Connection = c;
            miLector = miComando.ExecuteReader();
            
            
            if (miLector.HasRows)
            {
                while (miLector.Read())
                {
                    nuestraPersona = new clsPersona();
                    nuestraPersona.Id = (int) miLector["IDPersona"];
                    nuestraPersona.Nombre = (String) miLector["nombrePersona"];
                    nuestraPersona.Apellidos = (String) miLector["apellidosPersona"];
                    nuestraPersona.FechaNacimiento = (DateTime) miLector["fechaNacimiento"];
                    if (miLector["telefono"] == System.DBNull.Value)
                    {
                        nuestraPersona.Telefono = 0;
                    }
                    else {
                        // telefono es un string en  bdd
                        nuestraPersona.Telefono = (int)miLector["telefono"];
                    }
                    nuestraPersona.Telefono = (int) miLector["telefono"];
                    nuestraPersona.Direccion = (String) miLector["direccion"];
                    nuestraPersona.IDDepartamento = (int)miLector["IDDepartamento"];
                    nuestraPersona.Foto = (String) miLector["Foto"];
                    nuestroPueblo.Add(nuestraPersona);
                }
            }
            miLector.Close();
            miConexion.closeConnection(ref c);
            return nuestroPueblo;
        }
        #endregion




    }
}
