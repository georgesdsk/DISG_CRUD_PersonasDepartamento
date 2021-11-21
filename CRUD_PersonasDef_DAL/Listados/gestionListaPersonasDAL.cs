using CRUD_Personas_DAL.Conexion;
using CRUD_PersonasDef_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_PersonasDef_DAL.Listados
{
   public class GestionListaPersonasDAL
    {

        #region propiedadesPrivadas
        clsMyConnection miConexion;
        SqlDataReader miLector; // Es mejor poner un datareader por cada metodo o uno comun para todos (Si se pueden ejecutar varios a la vez)
        SqlCommand miComando;
        
        public GestionListaPersonasDAL()
        {
            miConexion = new clsMyConnection();
        }
        #endregion

        #region metodos
        /// Este metodo deberia devolver un data reader cargado con la info y la clsListado generara la lista
        public List<clsPersona> GetListadoPersonas()
        {
            miComando = new SqlCommand();
            List<clsPersona> nuestroPueblo = new List<clsPersona>();
            clsPersona nuestraPersona;
            miComando.CommandText = CONSULTA_PERSONAS;
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

        public int RemovePersona(int id) {
            
            miComando = new SqlCommand();
            miComando.CommandText = "DELETE FROM Persona Where IDPersona =@id" + id; // funciona el @id
            miConexion.getConnection();
            miComando.Connection = miConexion;
            return miComando.ExecuteNonQuery();
        }


        #endregion

        


    }
}
