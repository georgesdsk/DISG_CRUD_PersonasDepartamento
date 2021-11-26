﻿using CRUD_PersonasDef_BL;
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
using System.ComponentModel;

namespace CRUD_PersonasDef_UWP.ViewModel
{
    /// <summary>
    /// va a trabajar con todas las propiedasdses que necesita la vista Personas
    /// </summary>

    public class PersonasVM : INotifyPropertyChanged
    {

        // tengo que coger toda la lista de personas y la lista de departamentos con su ID y vincular persona.ID -> nombre departamento
        ListadoPersonasBL listadoPersonasBL;
        ListadoDepartamentosBL listadoDepartamentosBL;
        GestoraDepartamentoBL gestoraDepartamentoBL;
        GestoraPersonaBL gestoraPersonaBL;

        ObservableCollection<clsPersonaConDepartamento> vmListaPersonasConDepartamento;
        List<clsPersona> vmListaPersonasOrginal;
        List<clsDepartamento> vmListaDepartamentos; // para conseguir el nombre segun el id
        clsPersonaConDepartamento personaSeleccionadavm;

        DelegateCommand vmDCEliminarPersona;
        DelegateCommand vmDCActualizarPersona;
        DelegateCommand vmDCAnhadirPersona;


        #region constructor
        /// <summary>
        /// Hacemos la llamada en el constructor ya que para hacer la vista hay que mostrar la lista 
        /// </summary>
        public PersonasVM()
        {
            listadoPersonasBL = new ListadoPersonasBL();
            listadoDepartamentosBL = new ListadoDepartamentosBL();
            gestoraDepartamentoBL = new GestoraDepartamentoBL();
            gestoraPersonaBL = new GestoraPersonaBL();

            vmDCActualizarPersona = new DelegateCommand(dcActionActualizarPersona, dcCanExecuteActualizarPersona);
            vmDCEliminarPersona = new DelegateCommand(dcActionEliminarPersona, dcCanExecuteEliminarPersona);
            vmDCAnhadirPersona = new DelegateCommand(dcActionAnhadirPersona, dcCanExecuteAnhadirPersona);

            actualizarListas();
            
        }



        private void actualizarListas() {
            vmListaDepartamentos = listadoDepartamentosBL.ListaDepartamentosBL;
            vmListaPersonasOrginal = listadoPersonasBL.ListaPersonasBL;
        }

        #region commands
        /// <summary>
        /// Tiene que estar en otra pantalla
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool dcCanExecuteAnhadirPersona()
        {
            return ! (personaSeleccionadavm == null);
        }

        private void dcActionAnhadirPersona()
        {
            throw new NotImplementedException();
        }
    
        private bool dcCanExecuteEliminarPersona()
        {
            return !(personaSeleccionadavm == null);
        }

        private void dcActionEliminarPersona()
        {
            cambiosRealizados(listadoPersonasBL.BorrarPersonaBL((clsPersona)personaSeleccionadavm)); // mensaje de si seguro desea eliminar)
            personaSeleccionadavm = null;
            actualizarListas();
            NotifyPropertyChanged("VmListaPersonasConDepartamento"); // si la notifica, tiene que sal
            NotifyPropertyChanged("personaSeleccionadavm"); 
            
        }
        #endregion

        
        private bool dcCanExecuteActualizarPersona()
        {
            return !(personaSeleccionadavm == null);
        }

        private void dcActionActualizarPersona()
        {
            cambiosRealizados( gestoraPersonaBL.UpdatePersonaBL(personaSeleccionadavm));
            actualizarListas();
            NotifyPropertyChanged("VmListaPersonasConDepartamento"); // si la notifica, tiene que sal
            NotifyPropertyChanged("personaSeleccionadavm");

        }

      
        #endregion


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
                NotifyPropertyChanged("PersonaSeleccionadavm");
                vmDCEliminarPersona.RaiseCanExecuteChanged();
                VmDCActualizarPersona.RaiseCanExecuteChanged();
            }
        }

        
        public DelegateCommand VmDCEliminarPersona { get => vmDCEliminarPersona; }
        public DelegateCommand VmDCActualizarPersona { get => vmDCActualizarPersona;}
        public DelegateCommand VmDCAnhadirPersona { get => vmDCAnhadirPersona; }
        public List<clsDepartamento> VmListaDepartamentos { get => vmListaDepartamentos; set => vmListaDepartamentos = value; }
        

        /// <summary>
        /// analisis:Borra a una persona de la capa bl que este seleccionada en ese momento
        /// Precondiciones: una perssonaSeleccionada
        /// </summary>
        /// <returns></returns>
     
        public void cambiosRealizados(int i) {
            String devolucion = personaSeleccionadavm.Nombre + " " + personaSeleccionadavm.Apellidos;
            if (i > 0)
            {
                devolucion += " ha sido cambiada";
            }
            else {
                devolucion += " el cambio ha dado ERROR";
            }
           //TODO MOSTRAR EL MENSAJE


        }


        public event PropertyChangedEventHandler PropertyChanged;
 
        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged( String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




    }
}
