﻿using CRUD_Personas_DAL.Conexion;
using CRUD_PersonasDef_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_PersonasDef_DAL.Gestora
{

   
    public class gestoraDepartamentos
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
        private clsMyConnection miConexion;
        private SqlDataReader miLector;
        // Es mejor poner un datareader por cada metodo o uno comun para todos (Si se pueden ejecutar varios a la vez)
        private SqlCommand miComando;


        public int UpdateDepartamento(clsDepartamento departamento)
    {
        miComando = "update Departamento set nombreDepartamento=@nombre where idDepartamento ="+ departamento.ID;
        miComando.Parameters.AddWithValue("@nombre", departamento.Nombre);
        miComando.Connection =  mi
        return miComando.ExecuteNonQuery();
    }



    }

   
}
