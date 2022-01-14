
using CRUD_PersonasDef_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_PersonasDef_DAL.Gestora
{

  public class gestoraDepartamentos
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
        private clsMyConnection miConexion;
        private SqlDataReader miLector;

        public int DeleteDepartamento(int idDepartamento)
        {

            int resultado;
            miComando = new SqlCommand();
            miConexion = new clsMyConnection();
            miComando.CommandText = "DELETE FROM Departamentos where IDDepartamento = @idDepartamento";
            miComando.Parameters.AddWithValue("IDDepartamento", idDepartamento);
            miConexion.getConnection();
            miComando.Connection = miConexion.MiConexion;
            resultado = miComando.ExecuteNonQuery();
            miConexion.closeConnection();
            return resultado;
        }

        // Es mejor poner un datareader por cada metodo o uno comun para todos (Si se pueden ejecutar varios a la vez)
        private SqlCommand miComando;

        public int InsertDepartamento(String nombre)
        {

            int resultado;
            miComando = new SqlCommand();
            miConexion = new clsMyConnection();
            miComando.CommandText = "insert into Departamento(nombreDepartamento) values (@nombre)";
            miComando.Parameters.AddWithValue("@nombre", nombre);
            miConexion.getConnection();
            miComando.Connection = miConexion.MiConexion;
            resultado = miComando.ExecuteNonQuery();
            miConexion.closeConnection();
            return resultado;

        }

        public int UpdateDepartamento(clsDepartamento departamento)
    {
            int resultado;
            miComando.CommandText = "update Departamento set nombreDepartamento=@nombre where idDepartamento =@id";
            miComando.Parameters.AddWithValue("@nombre", departamento.Nombre);
            miComando.Parameters.AddWithValue("@id", departamento.ID);
            miConexion.getConnection();
            miComando.Connection = miConexion.MiConexion;
            resultado = miComando.ExecuteNonQuery();
            miConexion.closeConnection();
            return resultado;
    }


    }

   
}
