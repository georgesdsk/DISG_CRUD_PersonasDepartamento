using CRUD_PersonasDef_ASP.Models;
using CRUD_PersonasDef_BL;
using CRUD_PersonasDef_BL.Gestoras;
using CRUD_PersonasDef_BL.Listas;
using CRUD_PersonasDef_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


/**
 *  Esta clase funciona como el intermediario entre el controller y las  bases de datos, es decir le da todos los listados y/o personas necesitados al controller, para que asi el codigo del controller sea lo mas simple
 *  posible. Ademas de ello hace el control de excepciones, porque algunos metodos salen repetidos en el controller, como el getListado o getPersona, y para evitar redundancia de try-catchs, he decidido ponerlos aqui.
 *  Funcionan de manera que si todo ha ido bien devuelven el objeto de manera correcta, pero si ha habido algun problema, devuelven un null. Posteriormente, si el controller ve un null, devuelve el mensaje del error.
 * 
 * 
 */
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
        /// Recorrer la lista original de personas y dependiendo del id del departamanto que posea, metera esa persona con con el nombre del departamento conveniente
        /// 
        /// return: List <personaConDepartamento>
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


        /// <summary>
        /// Hace la peticion de actualizar la persona a la BL
        /// </summary>
        /// <param name="clsPersona"></param>
        /// <returns></returns>
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
        /// <returns> int resultado de la consulta</returns>

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
                /**
                for (int i = 0; i < vmListaPersonasConDepartamento.Count && !encontrado; i++)
                {
                    if (vmListaPersonasConDepartamento[i].Id == id)
                    {
                        personaConDepartamento = vmListaPersonasConDepartamento[i];
                        encontrado = true;
                    }
                }
                */
                personaConDepartamento = vmListaPersonasConDepartamento.First(x=> x.Id == id);

            }
            catch (SqlException ex)
            {
                // luego hay que controlar que esa persona no este a null
            }
            return personaConDepartamento;
        }


        /// <summary>
        /// Crea una nueva persona y se la pasa a BL para su posterior creacion
        /// </summary>
        /// <returns></returns>
        public clsPersonaTodosDepartamentos newPersona() {
            listaDepartamento = new List<clsDepartamento>();
            clsPersonaTodosDepartamentos persona = null;
            try
            {
                listaDepartamento = gestionDepartamentosBL.ListaDepartamentosBL;
                persona = new clsPersonaTodosDepartamentos(listaDepartamento);
            }
            catch (SqlException ex) {
            }
            return (persona);
        }

        /// <summary>
        /// Devuelve le persona con toda la lista de departamentos segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsPersonaTodosDepartamentos getPersonaConDepartamentos(int id)
        {
            listaDepartamento = new List<clsDepartamento>();
            clsPersonaTodosDepartamentos persona = null;
            try
            {
                listaDepartamento = gestionDepartamentosBL.ListaDepartamentosBL;
                persona = new clsPersonaTodosDepartamentos(getPersona(id), listaDepartamento);
            }
            catch (SqlException ex)
            {
            }
            return (persona);
        }

        /// <summary>
        /// Pasa la persona de los parametros a la bl para que la cree, si da excepcion, devuelve valor negativo
        /// </summary>
        /// <param name="clsPersona"></param>
        /// <returns></returns>
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
