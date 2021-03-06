using CRUD_PersonasDef_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_PersonasDef_DAL.Listados
{

    /// <summary>
    /// Clase que trabajo con el listado completo de personas, lo unico que hace es el select de todas las personas
    /// </summary>
   public class ListadoPersonasDAL
    {

        #region propiedadesPrivadas
        clsMyConnection miConexion;
        SqlDataReader miLector; // Es mejor poner un datareader por cada metodo o uno comun para todos (Si se pueden ejecutar varios a la vez)
        SqlCommand miComando;
        
        public ListadoPersonasDAL()
        {
            miConexion = new clsMyConnection();
        }
        #endregion

        #region metodos
        /// Este metodo deberia devolver un data reader cargado con la info y la clsListado generara la lista
        /// 
        public List<clsPersona> GetListadoPersonas()
        {
            miComando = new SqlCommand();
            List<clsPersona> nuestroPueblo = new List<clsPersona>();
            clsPersona nuestraPersona;
            miComando.CommandText = "SELECT * FROM Personas";
            miConexion.getConnection();
            miComando.Connection = miConexion.MiConexion; // el getter de la conexion
            miLector = miComando.ExecuteReader();

            // a partir de aqui seria lo mejor hacerlo en otro metodo aunque tengo que cerrar la conexion y el comando

            if (miLector.HasRows)
            {
                while (miLector.Read())
                {
                    nuestraPersona = new clsPersona();
                    nuestraPersona.Id = (int)miLector["IDPersona"];
                    nuestraPersona.Nombre = (String)miLector["nombrePersona"];
                    nuestraPersona.Apellidos = (String)miLector["apellidosPersona"];
                    nuestraPersona.FechaNacimiento = (DateTime)miLector["fechaNacimiento"];
                    if (miLector["telefono"] == System.DBNull.Value)
                    {
                        nuestraPersona.Telefono = 0;
                    }
                    else
                    {
                        // telefono es un string en  bdd
                        nuestraPersona.Telefono = (int)miLector["telefono"];
                    }
                    nuestraPersona.Telefono = (int)miLector["telefono"];
                    nuestraPersona.Direccion = (String)miLector["direccion"];
                    nuestraPersona.IDDepartamento = (int)miLector["IDDepartamento"];
                    nuestraPersona.Foto = (String)miLector["Foto"];
                    nuestroPueblo.Add(nuestraPersona);
                }
            }
            
            miLector.Close();
            miConexion.closeConnection();
            return nuestroPueblo;
        }

   
        #endregion

        


    }
}
