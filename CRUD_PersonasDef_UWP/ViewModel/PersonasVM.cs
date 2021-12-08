using CRUD_PersonasDef_BL;
using CRUD_PersonasDef_Entidades;
using CRUD_PersonasDef_UWP.Models;
using CRUD_PersonasDef_UWP.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_PersonasDef_BL.Listas;
using CRUD_PersonasDef_BL.Gestoras;
using System.ComponentModel;
using System.Windows.Input;

namespace CRUD_PersonasDef_UWP.ViewModel
{
    /// <summary>
    /// va a trabajar con todas las propiedasdses que necesita la vista Personas

    ///     la fecha en anadir persona
    ///     los textboxese cambiarse de color al no estar rellenos, 
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
        DelegateCommand vmDCMenuAnhadirPersona;
        DelegateCommand vmDCGuardarNuevaPersona;

        String visibilidadMenuInfo;
        String visibilidadMenuEdicion;
        String visibilidadError;


        #region constructor
        /// <summary>
        /// Hacemos la llamada en el constructor ya que para hacer la vista hay que mostrar la lista 
        /// </summary>
        public PersonasVM()
        {
            listadoPersonasBL = new ListadoPersonasBL();
            listadoDepartamentosBL = new ListadoDepartamentosBL();
            try
            {
                vmListaDepartamentos = listadoDepartamentosBL.ListaDepartamentosBL;
            }
            catch (Exception e)
            {
                visibilidadError = "Visible";
            }
            
            NotifyPropertyChanged("VisibilidadError");

            gestoraDepartamentoBL = new GestoraDepartamentoBL();
            gestoraPersonaBL = new GestoraPersonaBL();

            vmDCActualizarPersona = new DelegateCommand(dcActionActualizarPersona, dcCanExecuteActualizarPersona);
            vmDCEliminarPersona = new DelegateCommand(dcActionEliminarPersona, dcCanExecuteEliminarPersona);
            vmDCMenuAnhadirPersona = new DelegateCommand(dcActionAnhadirPersona, dcCanExecuteAnhadirPersona);
            vmDCGuardarNuevaPersona = new DelegateCommand(dcActionGuardarNuevaPersona, dcCanExecuteGuardarNuevaPersona);

            visibilidadMenuInfo = "Visible";
            visibilidadMenuEdicion = "Collapsed";
            visibilidadError = "Collapsed";
        }

        #region commands

        /// <summary>
        /// Siempre se podrá hacer
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool dcCanExecuteAnhadirPersona()
        {
            return true;
        }

        /// <summary>
        /// Mostrara el menu de edicion de la persona
        /// 
        /// </summary>
        private void dcActionAnhadirPersona()
        {
            personaSeleccionadavm = new clsPersonaConDepartamento();
            visibilidadMenuInfo = "Collapsed";
            visibilidadMenuEdicion = "Visible";

            NotifyPropertyChanged("VisibilidadMenuInfo");
            NotifyPropertyChanged("VisibilidadMenuEdicion");
            NotifyPropertyChanged("PersonaSeleccionadavm");

        }

        private bool dcCanExecuteEliminarPersona()
        {
            return !(personaSeleccionadavm == null);
        }


        /// <summary>
        /// analisis:Borra a una persona de la capa bl que este seleccionada en ese momento
        /// Precondiciones: una perssonaSeleccionada
        /// </summary>ddd
        /// <returns></returns>
        private void dcActionEliminarPersona()
        {

            try
            {
                gestoraPersonaBL.BorrarPersonaBL(personaSeleccionadavm.Id); // mensaje de si seguro desea 
                visibilidadError = "Collapsed";

            }
            catch (Exception ex) {
                visibilidadError = "Visible";
            }
            
            NotifyPropertyChanged("VmListaPersonasConDepartamento");
            NotifyPropertyChanged("VisibilidadError");
            NotifyPropertyChanged("PersonaSeleccionadavm");
        }
        #endregion
        private bool dcCanExecuteGuardarNuevaPersona()
        {
            return true;//!(String.IsNullOrEmpty(personaSeleccionadavm.Apellidos)  &&  String.IsNullOrEmpty(personaSeleccionadavm.Nombre)); // el nombre y el apellido(amhadir funcion behind de cambio de color) tienen que estar rellenos, el departamento lo va a estar. 
        }

        private void dcActionGuardarNuevaPersona()
        {

            try { 
                gestoraPersonaBL.InsertPersona(personaSeleccionadavm);
                visibilidadError = "Collapsed";
            }catch (Exception ex) {
                visibilidadError = "Visible";
            }
            NotifyPropertyChanged("VisibilidadError");
            NotifyPropertyChanged("VmListaPersonasConDepartamento");
        }



        


        private bool dcCanExecuteActualizarPersona()
        {
            return !(personaSeleccionadavm == null);
        }

        /// <summary>
        /// estara bindeado a la persona seleccionada
        /// </summary>
        /// <returns></returns>

        private void dcActionActualizarPersona()
        {
            gestoraPersonaBL.UpdatePersonaBL(personaSeleccionadavm);
            NotifyPropertyChanged("PersonaSeleccionadavm");
            NotifyPropertyChanged("VisibilidadError");
            NotifyPropertyChanged("VmListaPersonasConDepartamento");
        }

        #endregion


        public ObservableCollection<clsPersonaConDepartamento> VmListaPersonasConDepartamento//todo ponerlo en el constructor
        {
            get
            {
                vmListaPersonasConDepartamento = new ObservableCollection<clsPersonaConDepartamento>();
                try
                {
                    visibilidadError = "Collapsed";
                    // para que se actalicen los cambios
                    vmListaPersonasOrginal = listadoPersonasBL.ListaPersonasBL; // gsfdgsfdgsdfg

                    
                    int id;
                    String nombreDepartamento;
                    clsPersonaConDepartamento clsPersona;
                    //recorrer la lista original, y hacerle el get del id del departamento,  hacerle el get a la lista de departamentos con el find
                    foreach (clsPersona persona in vmListaPersonasOrginal)
                    {
                        id = persona.IDDepartamento;
                        nombreDepartamento = VmListaDepartamentos.Find(x => x.ID == id).Nombre;
                        clsPersona = new clsPersonaConDepartamento(persona.Id, persona.Nombre, persona.Apellidos, persona.Direccion, persona.FechaNacimiento, persona.Telefono, persona.IDDepartamento, persona.Foto, nombreDepartamento
                            );
                        clsPersona.NombreDepartamento = nombreDepartamento;
                        vmListaPersonasConDepartamento.Add(clsPersona);
                    }
                }

                catch (Exception ex) {
                    visibilidadError = "Visible";
                }
                NotifyPropertyChanged("VisibilidadError");

                return vmListaPersonasConDepartamento;
            }
        }

        public clsPersonaConDepartamento PersonaSeleccionadavm
        {
            get => personaSeleccionadavm;
            set
            {
                personaSeleccionadavm = value;
                visibilidadMenuEdicion = "Collapsed";
                visibilidadMenuInfo = "Visible";
                NotifyPropertyChanged("PersonaSeleccionadavm");
                NotifyPropertyChanged("VisibilidadMenuInfo");
                NotifyPropertyChanged("VisibilidadMenuEdicion");
                vmDCEliminarPersona.RaiseCanExecuteChanged();
                vmDCActualizarPersona.RaiseCanExecuteChanged();
            }
        }


        public DelegateCommand VmDCEliminarPersona { get => vmDCEliminarPersona; }
        public DelegateCommand VmDCActualizarPersona { get => vmDCActualizarPersona; }
        public DelegateCommand VmDCAnhadirPersona { get => vmDCMenuAnhadirPersona; }
        public List<clsDepartamento> VmListaDepartamentos { get => vmListaDepartamentos; set => vmListaDepartamentos = value; }
        public string VisibilidadMenuInfo { get => visibilidadMenuInfo; }
        public string VisibilidadMenuEdicion { get => visibilidadMenuEdicion; }
        public DelegateCommand VmDCGuardarNuevaPersona { get => vmDCGuardarNuevaPersona;}
        public string VisibilidadError { get => visibilidadError; set => visibilidadError = value; }

        public String cambiosRealizados(int i)
        { // que salte un mensaje en la pantallla
            String devolucion = personaSeleccionadavm.Nombre + " " + personaSeleccionadavm.Apellidos;
            if (i > 0)
            {
                devolucion += " ha sido cambiada";
            }
            else
            {
                devolucion += " el cambio ha dado ERROR";
            }
            return devolucion;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged(String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}



