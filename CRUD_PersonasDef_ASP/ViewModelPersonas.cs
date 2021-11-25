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

        List<clsPersonaConDepartamento> vmListaPersonasConDepartamento;
        List<clsPersona> vmListaPersonasOriginal;
        List<clsDepartamento> listaDepartamento;
        ListadoPersonasBL gestionListaPersonasBL;
        ListadoDepartamentosBL gestionDepartamentosBL;
        GestoraPersonaBL gestoraPersonaBL;
        clsPersona personaSeleccionada;



        public ViewModelPersonas()
        {
            gestionDepartamentosBL = new ListadoDepartamentosBL();
            gestoraPersonaBL = new GestoraPersonaBL();
            gestionListaPersonasBL = new ListadoPersonasBL();
            vmListaPersonasOriginal = gestionListaPersonasBL.ListaPersonasBL;
            listaDepartamento = gestionDepartamentosBL.ListaDepartamentosBL;
            vmListaPersonasConDepartamento = new List<clsPersonaConDepartamento>();
            vmListaPersonasConDepartamento = VmListaPersonasConDepartamento;
            
        }

        /// <summary>
        /// Recorrer la lista original, y hacerle el get del id del departamento,  hacerle el get a la lista de departamentos con el find
        /// </summary>

        public List<clsPersonaConDepartamento> VmListaPersonasConDepartamento
        {
            get {
                vmListaPersonasOriginal.ForEach(x => vmListaPersonasConDepartamento.Add(
                    new clsPersonaConDepartamento(listaDepartamento.Find(y => y.ID == x.IDDepartamento).Nombre, x))
                );
                /*
                 * Sin lambda
                String nombreDepartamento;
                foreach (clsPersona persona in vmListaPersonasOriginal)
                {  
                    nombreDepartamento = listaDepartamento.Find(x => x.ID == persona.IDDepartamento).Nombre;
                    vmListaPersonasConDepartamento.Add(new clsPersonaConDepartamento(nombreDepartamento, persona));
                }
                */
                return vmListaPersonasConDepartamento;
            }
        }

        public clsPersona PersonaSeleccionada { get => personaSeleccionada; set => personaSeleccionada = value; }

        public int UpdatePersona(clsPersona clsPersona)
        {
            return gestoraPersonaBL.UpdatePersonaBL(clsPersona);
        }

        public int DeletePersona(int idPersona) {
            return gestoraPersonaBL.BorrarPersonaBL(idPersona);
        }



        /// <summary>
        /// Analisis: devolver el objeto de persona con departamento segun el id pasado
        /// Precondiciones: id>0
        /// Postcondiciones: Devolvera una persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public clsPersonaConDepartamento getPersona(int id) {
            
            clsPersonaConDepartamento personaConDepartamento = null;
            bool encontrado = false;

            for (int i = 0; i < vmListaPersonasConDepartamento.Count && !encontrado; i++)
            {
                if (vmListaPersonasConDepartamento[i].Id == id)
                {
                    personaConDepartamento = vmListaPersonasConDepartamento[i];
                    encontrado = true;
                }
            }
            return personaConDepartamento;
        }

       

    }
}
