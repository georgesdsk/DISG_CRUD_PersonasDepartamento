
using CRUD_PersonasDef_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_PersonasDef_DAL.Listados
{
    /// <summary>
    /// Clase con la funcionalidad de consulta sobre la lista de departamentos
    /// </summary>
   public class GestionListaDepartamentosDAL
    {
        #region propiedadesPrivadas
        string CONSULTA_DEPARTAMENTOS = "SELECT * FROM Departamentos";
        clsMyConnection miConexion;
        SqlDataReader miLector; // Es mejor poner un datareader por cada metodo o uno comun para todos (Si se pueden ejecutar varios a la vez)
        SqlCommand miComando;
        #endregion

        public GestionListaDepartamentosDAL()
        {
            miConexion = new clsMyConnection();
        }


        /// <summary>
        /// Devuelve la lista completa de departamentos
        /// </summary>
        /// <returns></returns>
        public List<clsDepartamento> ListadoDepartamentosDAL() {
            List<clsDepartamento> listaDepartamentos = new List<clsDepartamento>();
            clsDepartamento departamentoManejado;
            miComando = new SqlCommand();
            miComando.CommandText = CONSULTA_DEPARTAMENTOS;
            miConexion.getConnection();
            miComando.Connection = miConexion.MiConexion;
            miLector = miComando.ExecuteReader();
            if (miLector != null)
            {
                while (miLector.Read())
                {
                    departamentoManejado = new clsDepartamento();
                    departamentoManejado.Nombre = (String)miLector["nombreDepartamento"];
                    departamentoManejado.ID = (int)miLector["IDDepartamento"];
                    listaDepartamentos.Add(departamentoManejado);
                }
            }
            return listaDepartamentos;
        } 

    }
}
