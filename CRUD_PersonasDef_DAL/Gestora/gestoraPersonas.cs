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
        string CONSULTA_PERSONAS = "SELECT * FROM Personas";
        private clsMyConnection miConexion;
        private SqlDataReader miLector;
        // Es mejor poner un datareader por cada metodo o uno comun para todos (Si se pueden ejecutar varios a la vez)
        private SqlCommand miComando;
        ObservableCollection<clsPersona> nuestraGente;
        
        public GestoraPersonas()
        {
            miConexion = new clsMyConnection();
           
        }





    }
}
