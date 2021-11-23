using CRUD_PersonasDef_ASP.Models;
using CRUD_PersonasDef_BL;
using CRUD_PersonasDef_BL.Gestoras;
using CRUD_PersonasDef_BL.Listas;
using CRUD_PersonasDef_Entidades;
using System;
using System.Collections.Generic;

namespace CRUD_PersonasDef_ASP
{
    public class ViewModelPersonas
    {

        List<clsPersonaModel> listaPersonasVMconDepartamento;
        List<clsPersona> listaPersonasVMOriginal;
        List<clsDepartamento> listaDepartamento;
        GestionListaPersonasBL gestionListaPersonasBL;
        GestionDepartamentosBL gestionDepartamentosBL;
        GestoraPersonaBL gestoraPersonaBL;


        public ViewModelPersonas()
        {
            this.listaPersonasVMconDepartamento = new List<clsPersonaModel>();
            listaDepartamento= new List<clsDepartamento>(); 

            gestionListaPersonasBL = new GestionListaPersonasBL(); 
            gestionDepartamentosBL = new GestionDepartamentosBL();
            gestoraPersonaBL = new GestoraPersonaBL();
            listaPersonasVMOriginal = gestionListaPersonasBL.ListaPersonasBL;
            listaDepartamento = gestionDepartamentosBL.ListaDepartamentosBL;
        }

        public List<clsPersonaModel> ListaPersonasVMconDepartamento
        { 
            get {

                int id;
                String nombreDepartamento;
                clsPersona personaAuxiliar;
                //recorrer la lista original, y hacerle el get del id del departamento,  hacerle el get a la lista de departamentos con el find
                foreach (clsPersona persona in listaPersonasVMOriginal)
                {
                    nombreDepartamento = listaDepartamento.Find(x=> x.ID == persona.IDDepartamento).Nombre;
                    listaPersonasVMconDepartamento.Add(new clsPersonaModel(nombreDepartamento,persona));
                }
                return listaPersonasVMconDepartamento;
            } 
        }

        public int DeletePersona(int idPersona) {
           return gestoraPersonaBL.BorrarPersonaBL(idPersona);   
        }

       

    }
}
