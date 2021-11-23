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
using CRUD_PersonasDef_BL.Gestoras;

namespace CRUD_PersonasDef_UWP.ViewModel
{
    /// <summary>
    /// va a trabajar con todas las propiedasdses que necesita la vista Personas
    /// </summary>

    public class PersonasVM
    {

        // tengo que coger toda la lista de personas y la lista de departamentos con su ID y vincular persona.ID -> nombre departamento
        ListadoPersonasBL gestionListaPersonasBL;
        ListadoDepartamentosBL gestionDepartamentosBL;
        GestoraDepartamentoBL gestoraDepartamentoBL;
        GestoraPersonaBL gestoraPersonaBL;

        ObservableCollection<clsPersonaConDepartamento> vmListaPersonasConDepartamento;
        List<clsPersona> vmListaPersonasOrginal;
        List<clsDepartamento> vmListaDepartamentos; // para conseguir el nombre segun el id
        clsPersonaConDepartamento personaSeleccionadavm;

        

        /// <summary>
        /// Hacemos la llamada en el constructor ya que para hacer la vista hay que mostrar la lista 
        /// </summary>
        public PersonasVM()
        {
            gestionListaPersonasBL = new ListadoPersonasBL();
            gestionDepartamentosBL = new ListadoDepartamentosBL();
            gestoraDepartamentoBL = new GestoraDepartamentoBL();
            gestoraPersonaBL = new GestoraPersonaBL();

            vmListaDepartamentos = gestionDepartamentosBL.ListaDepartamentosBL;
            vmListaPersonasOrginal = gestionListaPersonasBL.ListaPersonasBL;

        }

        public ObservableCollection<clsPersonaConDepartamento> VmListaPersonasConDepartamento {
            get {
                vmListaPersonasConDepartamento = new ObservableCollection<clsPersonaConDepartamento>();
                int id;
                String nombreDepartamento;
                clsPersonaConDepartamento clsPersona;
                //recorrer la lista original, y hacerle el get del id del departamento,  hacerle el get a la lista de departamentos con el find
                foreach (clsPersona persona in vmListaPersonasOrginal) {
                    id = persona.IDDepartamento;
                    nombreDepartamento = vmListaDepartamentos.Find(x => x.ID == id).Nombre;
                    clsPersona =  new clsPersonaConDepartamento(persona.Id, persona.Nombre, persona.Apellidos, persona.Direccion, persona.FechaNacimiento, persona.Telefono, persona.IDDepartamento, persona.Foto, nombreDepartamento
                        );
                    clsPersona.NombreDepartamento = nombreDepartamento;
                    vmListaPersonasConDepartamento.Add(clsPersona);
                }
                return vmListaPersonasConDepartamento;
            }
        }

        public clsPersonaConDepartamento PersonaSeleccionadavm { get => personaSeleccionadavm;
            set {

                personaSeleccionadavm = value;
                // hay que poner el notifyProperty?;
            }
        }


        public String BorrarPersona() {

            return cambiosRealizados(
                gestionListaPersonasBL.BorrarPersonaBL((clsPersona)personaSeleccionadavm)
                );
        }

        public String cambiosRealizados(int i) {
            String devolucion = personaSeleccionadavm.Nombre + " " + personaSeleccionadavm.Apellidos;
            if (i > 0)
            {
                devolucion += " ha sido cambiada";
            }
            else {
                devolucion += " el cambio ha dado ERROR";
            }
            return devolucion;
        }

        /// <summary>
        /// estara bindeado a la persona seleccionada
        /// </summary>
        /// <returns></returns>
        public String ActualizarPersona() {

            return cambiosRealizados(
                gestoraPersonaBL.UpdatePersonaBL((clsPersona)personaSeleccionadavm)
                );
        }



        public String AnhadirPersona() { //
            return null;
        }


    }
}
