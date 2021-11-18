using _07_CRUD_Personas_DAL.Conexion;
using Ejercicios_UD10.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_PersonasDef_DAL.Gestora
{
    class gestoraPersonas
    {
        string CONSULTA_PERSONAS = "SELECT * FROM Personas";
        private clsMyConnection miConexion;
        private SqlConnection conexionAbierta;
        private SqlDataReader miLector;
        // Es mejor poner un datareader por cada metodo o uno comun para todos (Si se pueden ejecutar varios a la vez)
        private SqlCommand miComando;
        
        public gestoraPersonas()
        {
            miConexion = new clsMyConnection();
        }
        #region metodos
        // Este metodo deberia devolver un data reader cargado con la info y la clsListado generara la lista
        public List<clsPersona> getListadoPersonas()
        {
            List<clsPersona> nuestroPueblo = new List<clsPersona>();
            miComando.CommandText = CONSULTA_PERSONAS;
            SqlConnection c = miConexion.getConnection();
            miComando.Connection = c;
            miLector = miComando.ExecuteReader();
            clsPersona nuestraPersona;
            
            if (miLector.HasRows)
            {
                while (miLector.Read())
                {
                    nuestraPersona = new clsPersona();
                    nuestraPersona.Id = (int) miLector["IDPersona"];
                    nuestraPersona.Nombre = (String) miLector["nombrePersona"];
                    nuestraPersona.Apellidos = (String) miLector["apellidosPersona"];
                    nuestraPersona.FechaNacimiento = (DateTime) miLector["fechaNacimiento"];
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
