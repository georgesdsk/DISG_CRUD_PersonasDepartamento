using CRUD_PersonasDef_BL;
using CRUD_PersonasDef_Entidades;
using CRUD_PersonasDef_UWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_PersonasDef_BL.Listas;

namespace CRUD_PersonasDef_UWP.ViewModel
{
    /// <summary>
    /// va a trabajar con todas las propiedasdses que necesita la vista Personas
    /// </summary>

    public class PersonasVM
    {

        // tengo que coger toda la lista de personas y la lista de departamentos con su ID y vincular persona.ID -> nombre departamento

        ObservableCollection<clsPersonaModel> vmListaPersonasConDepartamento;
        List<clsPersona> vmListaPersonasOrginal;
        List<clsDepartamento> vmListaDepartamentos; // para conseguir el nombre segun el id
        GestionListaPersonasBL gestionListaPersonasBL;
        GestionDepartamentosBL gestionDepartamentosBL;
        clsPersonaModel personaSeleccionadavm;



        /// <summary>
        /// Hacemos la llamada en el constructor ya que para hacer la vista hay que mostrar la lista 
        /// </summary>
        public PersonasVM()
        {
            gestionListaPersonasBL = new GestionListaPersonasBL();
            gestionDepartamentosBL = new GestionDepartamentosBL();
            vmListaDepartamentos = gestionDepartamentosBL.ListaDepartamentosBL;
            vmListaPersonasOrginal = gestionListaPersonasBL.ListaPersonasBL;

        }

        public ObservableCollection<clsPersonaModel> VmListaPersonasConDepartamento {
            get {
                vmListaPersonasConDepartamento = new ObservableCollection<clsPersonaModel>();
                int id;
                String nombreDepartamento;
                clsPersonaModel clsPersona;
                //recorrer la lista original, y hacerle el get del id del departamento,  hacerle el get a la lista de departamentos con el find
                foreach (clsPersona persona in vmListaPersonasOrginal) {
                    id = persona.IDDepartamento;
                    nombreDepartamento = vmListaDepartamentos.Find(x => x.ID == id).Nombre;
                    clsPersona = (clsPersonaModel)persona;
                    clsPersona.NombreDepartamento = nombreDepartamento;
                    vmListaPersonasConDepartamento.Add(clsPersona);
                }
                return vmListaPersonasConDepartamento;
            }
        }

        public clsPersonaModel PersonaSeleccionadavm { get => personaSeleccionadavm;
            set {

                personaSeleccionadavm = value;
                // hay que poner el notifyProperty?;
            }
        }


        public int BorrarPersonaEjemplo() {

           return gestionListaPersonasBL.BorrarPersonaBL((clsPersona)personaSeleccionadavm);
        
        }

    }
}
