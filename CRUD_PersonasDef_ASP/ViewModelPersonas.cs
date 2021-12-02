using CRUD_PersonasDef_ASP.Models;
using CRUD_PersonasDef_BL;
using CRUD_PersonasDef_BL.Gestoras;
using CRUD_PersonasDef_BL.Listas;
using CRUD_PersonasDef_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CRUD_PersonasDef_ASP
{
    public class ViewModelPersonas
    {
        List<Models.clsPersonaConDepartamento> vmListaPersonasConDepartamento;
        List<CRUD_PersonasDef_Entidades.clsPersona> vmListaPersonasOriginal;
        List<clsDepartamento> listaDepartamento;

        ListadoPersonasBL gestionListaPersonasBL;
        ListadoDepartamentosBL gestionDepartamentosBL;
        GestoraPersonaBL gestoraPersonaBL;
      

        public ViewModelPersonas()
        {
            listaDepartamento = new List<clsDepartamento>();    
            gestionDepartamentosBL = new ListadoDepartamentosBL();
            gestoraPersonaBL = new GestoraPersonaBL();
            gestionListaPersonasBL = new ListadoPersonasBL();
            vmListaPersonasConDepartamento = new List<clsPersonaConDepartamento>();
           
        }

        /// <summary>
        /// Recorrer la lista original, y hacerle el get del id del departamento,  hacerle el get a la lista de departamentos con el find
        /// </summary>

        public List<Models.clsPersonaConDepartamento> VmListaPersonasConDepartamento
        {
            get
            {
                try
                {
                    listaDepartamento = gestionDepartamentosBL.ListaDepartamentosBL;
                    vmListaPersonasOriginal = gestionListaPersonasBL.ListaPersonasBL;

                    vmListaPersonasOriginal.ForEach(x => vmListaPersonasConDepartamento.Add(
                        new clsPersonaConDepartamento(listaDepartamento.First(y => y.ID == x.IDDepartamento).Nombre, x))
                    );
                }
                catch (SqlException ex)
                {
                    vmListaPersonasConDepartamento = null;
                }
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


        //TODO Hacer que devuelva  una string
        public int UpdatePersona(CRUD_PersonasDef_Entidades.clsPersona clsPersona)
        {
            int resultado = -1;
            try
            {
                resultado = gestoraPersonaBL.UpdatePersonaBL(clsPersona);
            }
            catch (SqlException ex)
            {
            }
            return resultado;

        }

        /// <summary>
        /// Borra la persona indicada por el id, si me da una excepcion devuelve un -1, y si ninguna fila queda afectada un 0
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns></returns>

        public int DeletePersona(int idPersona)
        {
            int resultado = -1;
            try
            {
                resultado = gestoraPersonaBL.BorrarPersonaBL(idPersona);
            }
            catch (SqlException ex)
            {
            }
            return resultado;
        }

        /// <summary>
        /// Analisis: devolver el objeto de persona con departamento segun el id pasado
        /// Precondiciones: id>0
        /// Postcondiciones: Devolvera una persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public clsPersonaConDepartamento getPersona(int id)
        {
            clsPersonaConDepartamento personaConDepartamento = null;
            bool encontrado = false;

            try
            {
                vmListaPersonasOriginal = gestionListaPersonasBL.ListaPersonasBL;
                vmListaPersonasConDepartamento = VmListaPersonasConDepartamento;
                for (int i = 0; i < vmListaPersonasConDepartamento.Count && !encontrado; i++)
                {
                    if (vmListaPersonasConDepartamento[i].Id == id)
                    {
                        personaConDepartamento = vmListaPersonasConDepartamento[i];
                        encontrado = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                // luego hay que controlar que esa persona no este a null
            }
            return personaConDepartamento;
        }

        public clsPersonaTodosDepartamentos newPersona() {
            listaDepartamento = gestionDepartamentosBL.ListaDepartamentosBL;
            return new clsPersonaTodosDepartamentos(listaDepartamento);
        }

        /// <summary>
        /// Devuelve le persona con toda la lista de departamentos segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsPersonaTodosDepartamentos getPersonaConDepartamentos(int id)
        {

            return new clsPersonaTodosDepartamentos(getPersona(id), listaDepartamento);
        }

        public int create(clsPersona clsPersona)
        {
            int resultado = -1;
            try
            {
                resultado = gestoraPersonaBL.InsertPersona(clsPersona);
            }
            catch (Exception ex)
            {
            }
            return resultado;


        }
    }
}
