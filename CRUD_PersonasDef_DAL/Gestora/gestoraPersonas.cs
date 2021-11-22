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
    
    public class GestoraPersonas
    {
        private clsMyConnection miConexion;
        private SqlDataReader miLector;
        // Es mejor poner un datareader por cada metodo o uno comun para todos (Si se pueden ejecutar varios a la vez)
        private SqlCommand miComando;
   
        
        public GestoraPersonas()
        {
            miConexion = new clsMyConnection();
           
        }

        /// <summary>
        /// Va a actualizar la persona al completo con los datos pasados( clase persona)
        /// </summary>
        /// <returns></returns>
        public int UpdatePersona(clsPersona personaActualizar)
        {
            miComando.CommandText = "UPDATE Personas set nombrePersona = @nombre, apellidosPersona = @apellidos, direccion = @direccion, fechaNacimiento = @fechaNacimiento, telefono = @telefono, Foto = @foto WHERE IDPersona = " + personaActualizar.Id;
            miComando.Parameters.AddWithValue("@nombre", personaActualizar.Nombre);
            miComando.Parameters.AddWithValue("@apellidos", personaActualizar.Apellidos);
            miComando.Parameters.AddWithValue("@direccion", personaActualizar.Direccion);
            miComando.Parameters.AddWithValue("@fechaNacimiento", personaActualizar.FechaNacimiento); // ave que tal

            if (personaActualizar.Telefono != null)
            {
                miComando.Parameters.AddWithValue("@telefono", personaActualizar.Telefono);
            }
            miComando.Parameters.AddWithValue("@foto", personaActualizar.Foto);
            return miComando.ExecuteNonQuery();
        }






    }
}
