
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
    /// Hace la funcionalidad de modificado, borrado y añadido de personas en la base de datos
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
        /// Ejecuta la consulta que se le pase por parametros con la persona tambien. Hace la funcionalidad de actualizado o añadido de la persona en la base de datos
        /// </summary>
        /// <param name="clsPersona"></param>
        /// <param name="textComando"></param>
        /// <returns></returns>
        private int  nuevaOEditadaPersona(clsPersona clsPersona, String textComando) {
            int resultado;
            miComando = new SqlCommand();
            miComando.CommandText = textComando;
            miComando.Parameters.AddWithValue("@nombre", clsPersona.Nombre);
            miComando.Parameters.AddWithValue("@apellidos", clsPersona.Apellidos);
            miComando.Parameters.AddWithValue("@direccion", clsPersona.Direccion);
            miComando.Parameters.AddWithValue("@fechaNacimiento", clsPersona.FechaNacimiento); // ave que talf
            miComando.Parameters.AddWithValue("@IDPersona", clsPersona.Id);
            if (clsPersona.Telefono != null)
            {
                miComando.Parameters.AddWithValue("@telefono", clsPersona.Telefono);
            }
            miComando.Parameters.AddWithValue("@foto", clsPersona.Foto);
            miComando.Parameters.AddWithValue("@IDDepartamento", clsPersona.IDDepartamento);
            miConexion.getConnection();
            miComando.Connection = miConexion.MiConexion;
            resultado = miComando.ExecuteNonQuery();
            miConexion.closeConnection();

            return resultado;
        }


        /// <summary>
        /// Llama a nuevaOEditada persona para que la añada en la bse de datos
        /// </summary>
        /// <param name="personaNueva"></param>
        /// <returns></returns>

        public int insertPersona(clsPersona personaNueva)
        {
          String comandoInsertar = "INSERT INTO Personas(nombrePersona,apellidosPersona,direccion,fechaNacimiento, telefono,Foto,IDDepartamento ) values( @nombre, @apellidos, @direccion, @fechaNacimiento, @telefono, @foto, @IDDepartamento)";
          return  nuevaOEditadaPersona(personaNueva, comandoInsertar);

        }

        /// <summary>
        /// Va a actualizar la persona al completo con los datos pasados( clase persona)
        /// </summary>
        /// <returns></returns>
        public int UpdatePersona(clsPersona personaActualizar)
        {
            String comandoActualizar = "UPDATE Personas set nombrePersona = @nombre, apellidosPersona = @apellidos, direccion = @direccion, fechaNacimiento = @fechaNacimiento, telefono = @telefono, Foto = @foto, IDDepartamento = @IDDepartamento WHERE IDPersona =@IDPersona " ;
            return nuevaOEditadaPersona(personaActualizar, comandoActualizar);
        }


        /// <summary>
        /// Borra de la base de datos la persona del id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
