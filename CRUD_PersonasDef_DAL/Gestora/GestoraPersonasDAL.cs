using CRUD_Personas_DAL.Conexion;
using CRUD_PersonasDef_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_PersonasDef_DAL.Gestora
{
    /// <summary>
    /// GESTORA se encarga de una sola persona mientras que los listados dobre los listados
    /// </summary>
    
    public class GestoraPersonasDAL
    {
        private clsMyConnection miConexion;
        private SqlDataReader miLector;
        // Es mejor poner un datareader por cada metodo o uno comun para todos (Si se pueden ejecutar varios a la vez)
        private SqlCommand miComando;
   
        
        public GestoraPersonasDAL()
        {
            miConexion = new clsMyConnection();
           
        }

        public int insertPersona(clsPersona personaNueva) {

            miComando.CommandText = "INSERT INTO Personas(nombre,apellidos,direccion,fechaNacimiento, telefono,Foto) values( @nombre, @apellidos, @direccion, @fechaNacimiento, @telefono, @foto WHERE IDPersona = @IDPersona" ;
            miComando.Parameters.AddWithValue("@nombre", personaNueva.Nombre);
            miComando.Parameters.AddWithValue("@apellidos", personaNueva.Apellidos);
            miComando.Parameters.AddWithValue("@direccion", personaNueva.Direccion);
            miComando.Parameters.AddWithValue("@fechaNacimiento", personaNueva.FechaNacimiento);
            if (personaNueva.Telefono != null)
            {
                miComando.Parameters.AddWithValue("@telefono", personaNueva.Telefono);
            }
            miComando.Parameters.AddWithValue("@Foto", personaNueva.Telefono);
            miComando.Parameters.AddWithValue("@IDPersona", personaNueva.Id);

            return miComando.ExecuteNonQuery(); 

        }

        /// <summary>
        /// Va a actualizar la persona al completo con los datos pasados( clase persona)
        /// </summary>
        /// <returns></returns>
        public int UpdatePersona(clsPersona personaActualizar)
        {
            int resultado;
            miComando = new SqlCommand();
            miComando.CommandText = "UPDATE Personas set nombrePersona = @nombre, apellidosPersona = @apellidos, direccion = @direccion," +
                " fechaNacimiento = @fechaNacimiento, telefono = @telefono, IDDepartamento = @IDDepartamento, Foto = @foto  WHERE IDPersona =@IDPersona " ;
            miComando.Parameters.AddWithValue("@nombre", personaActualizar.Nombre);
            miComando.Parameters.AddWithValue("@apellidos", personaActualizar.Apellidos);
            miComando.Parameters.AddWithValue("@direccion", personaActualizar.Direccion);
            miComando.Parameters.AddWithValue("@fechaNacimiento", personaActualizar.FechaNacimiento); // ave que tal
            miComando.Parameters.AddWithValue("@IDDepartamento", personaActualizar.IDDepartamento);
            miComando.Parameters.AddWithValue("@IDPersona", personaActualizar.Id);
            if (personaActualizar.Telefono != null)
            {
                miComando.Parameters.AddWithValue("@telefono", personaActualizar.Telefono);
            }
            miComando.Parameters.AddWithValue("@foto", personaActualizar.Foto);
            miConexion.getConnection();
            miComando.Connection = miConexion.MiConexion;
            resultado = miComando.ExecuteNonQuery();
            miConexion.closeConnection();   
            return resultado;
        }

        public int RemovePersona(int id)
        {
            int resultado;
            miComando = new SqlCommand();
            miComando.CommandText = "DELETE FROM Personas Where IDPersona =@id"; // funciona el @id
            miComando.Parameters.AddWithValue("@id", id);
            miConexion.getConnection();
            miComando.Connection = miConexion.MiConexion;
            resultado = miComando.ExecuteNonQuery();
            miConexion.closeConnection();
            return resultado;
        }








    }
}
