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
using Windows.UI.Xaml.Controls;

namespace CRUD_PersonasDef_UWP.ViewModel
{
    /// <summary>
    /// va a trabajar con todas las propiedasdses que necesita la vista Personas, es decir llamara a las clases 
    /// que trabajan con la base de datos y devolver las listas preparadas para la vista

    ///     
    /// </summary>


    public class DepartamentosVM : INotifyPropertyChanged
    {

        ListadoDepartamentosBL listadoDepartamentosBL;
        GestoraDepartamentoBL gestoraDepartamentoBL;
        clsDepartamento departamentoSeleccionado;

        List<clsDepartamento> vmListaDepartamentos; // para conseguir el nombre segun el id

        DelegateCommand vmDCEliminarDepartamento;
        DelegateCommand vmDCActualizarDepartamento;
        DelegateCommand vmDCMenuAnhadirDepartamento;
        DelegateCommand vmDCGuardarNuevaDepartamento;

        /// <summary>
        /// Variables que controlan la visibilidad de diferentes objetos
        /// </summary>

        String visibilidadMenuInfo;
        String visibilidadMenuEdicion;
        String visibilidadError;


        #region constructor
        /// <summary>
        /// Hacemos la llamada en el constructor ya que para hacer la vista hay que mostrar la lista 
        /// </summary>
        public DepartamentosVM()
        {

            listadoDepartamentosBL = new ListadoDepartamentosBL();

            try
            {
                vmListaDepartamentos = listadoDepartamentosBL.ListaDepartamentosBL;
                visibilidadError = "Collapsed";

            }
            catch (Exception e)
            {
                mensajeError();
                visibilidadError = "Visible";
            }

            NotifyPropertyChanged("VisibilidadError");

            gestoraDepartamentoBL = new GestoraDepartamentoBL();

            vmDCActualizarDepartamento = new DelegateCommand(dcActionActualizarDepartamento, dcCanExecuteActualizarDepartamento);
            vmDCEliminarDepartamento = new DelegateCommand(dcActionEliminarDepartamentoAsync, dcCanExecuteEliminarDepartamento);
            vmDCMenuAnhadirDepartamento = new DelegateCommand(dcActionAnhadirDepartamento, dcCanExecuteAnhadirDepartamento);
            vmDCGuardarNuevaDepartamento = new DelegateCommand(dcActionGuardarNuevaDepartamento, dcCanExecuteGuardarNuevaDepartamento);

            visibilidadMenuInfo = "Visible";
            visibilidadMenuEdicion = "Collapsed";

        }

        #endregion
        #region commands

        /// <summary>
        /// Siempre se podrá hacer
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool dcCanExecuteAnhadirDepartamento()
        {
            return true;
        }

        /// <summary>
        /// Mostrara el menu de edicion de la Departamento
        /// 
        /// </summary>
        private void dcActionAnhadirDepartamento()
        {
            departamentoSeleccionado = new clsDepartamento();
            visibilidadMenuInfo = "Collapsed";
            visibilidadMenuEdicion = "Visible";

            NotifyPropertyChanged("VisibilidadMenuInfo");
            NotifyPropertyChanged("VisibilidadMenuEdicion");
            NotifyPropertyChanged("DepartamentoSeleccionadavm");

        }

        private bool dcCanExecuteEliminarDepartamento()
        {
            return !(departamentoSeleccionado == null);
        }


        /// <summary>
        /// analisis:Borra a una Departamento de la capa bl que este seleccionada en ese momento
        /// Precondiciones: una perssonaSeleccionada
        /// </summary>ddd
        /// <returns></returns>
        private async void dcActionEliminarDepartamentoAsync()
        {
            ContentDialog deleteFileDialog = new ContentDialog
            {
                Title = "Eliminar esta Departamento?",
                Content = "Eliminar esta Departamento?",
                PrimaryButtonText = "Delete",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await deleteFileDialog.ShowAsync();


            if (result == ContentDialogResult.Primary)
            {
                try
                {
                    gestoraDepartamentoBL.BorrarDepartamentoBL(departamentoSeleccionado.ID); // mensaje de si seguro desea 
                    visibilidadError = "Collapsed";

                }
                catch (Exception ex)
                {
                    mensajeError();
                    visibilidadError = "Visible";
                }
                NotifyPropertyChanged("VmListaDepartamentosConDepartamento");
                NotifyPropertyChanged("VisibilidadError");
                NotifyPropertyChanged("DepartamentoSeleccionadavm");

            }
            else
            { }

        }

        #endregion
        private bool dcCanExecuteGuardarNuevaDepartamento()
        {
            return true;//!(String.IsNullOrEmpty(DepartamentoSeleccionadavm.Apellidos)  &&  String.IsNullOrEmpty(DepartamentoSeleccionadavm.Nombre)); // el nombre y el apellido(amhadir funcion behind de cambio de color) tienen que estar rellenos, el departamento lo va a estar. 
        }


        /// <summary>
        /// Metodo que lanza un content dialog de simple aviso
        /// </summary>

        private async void mensajeError()
        {

            ContentDialog deleteFileDialog = new ContentDialog
            {
                Title = "Fatal ERROR",
                Content = "Ha habido un error con la base de datos",
                CloseButtonText = "Ok"
            };

            await deleteFileDialog.ShowAsync();

        }

        /// <summary>
        /// Muestra mensaje en la pantalla si se desea o no borrar a la Departamento, si es asi, la borra si no sigue
        /// </summary>
        private async void dcActionGuardarNuevaDepartamento()
        {

            ContentDialog deleteFileDialog = new ContentDialog
            {
                Title = "Guardar nueva Departamento?",
                Content = "Guardar nueva Departamento?",
                PrimaryButtonText = "Save",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await deleteFileDialog.ShowAsync();

            // Delete the file if the user clicked the primary button.
            /// Otherwise, do nothing.
            if (result == ContentDialogResult.Primary)
            {
                try
                {
                    gestoraDepartamentoBL.InsertDepartamento(departamentoSeleccionado);
                    visibilidadError = "Collapsed";
                }
                catch (Exception ex)
                {
                    mensajeError();
                    visibilidadError = "Visible";
                }
                NotifyPropertyChanged("VisibilidadError");
                NotifyPropertyChanged("VmListaDepartamentosConDepartamento");
            }
            else
            {
            }

        }


        private bool dcCanExecuteActualizarDepartamento()
        {
            return !(departamentoSeleccionado == null);
        }

        /// <summary>
        /// estara bindeado a la Departamento seleccionada
        /// </summary>
        /// <returns></returns>

        private async void dcActionActualizarDepartamento()
        {

            ContentDialog deleteFileDialog = new ContentDialog
            {
                Title = "Actualizar la siguente Departamento?",
                Content = "Actualizar la siguente Departamento",
                PrimaryButtonText = "Save",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await deleteFileDialog.ShowAsync();

            // Delete the file if the user clicked the primary button.
            /// Otherwise, do nothing.
            if (result == ContentDialogResult.Primary)
            {
                try
                {
                    gestoraDepartamentoBL.UpdateDepartamentoBL(departamentoSeleccionado);
                    visibilidadError = "Collapsed";
                }
                catch (Exception ex)
                {
                    mensajeError();
                    visibilidadError = "Visible";
                }


                NotifyPropertyChanged("DepartamentoSeleccionadavm");
                NotifyPropertyChanged("VisibilidadError");
                NotifyPropertyChanged("VmListaDepartamentosConDepartamento");
            }
            else
            {
            }
        }

        public DelegateCommand VmDCEliminarDepartamento { get => vmDCEliminarDepartamento; }
        public DelegateCommand VmDCActualizarDepartamento { get => vmDCActualizarDepartamento; }
        public DelegateCommand VmDCAnhadirDepartamento { get => vmDCMenuAnhadirDepartamento; }
        public List<clsDepartamento> VmListaDepartamentos { get => vmListaDepartamentos; set => vmListaDepartamentos = value; }
        public string VisibilidadMenuInfo { get => visibilidadMenuInfo; }
        public string VisibilidadMenuEdicion { get => visibilidadMenuEdicion; }
        public DelegateCommand VmDCGuardarNuevaDepartamento { get => vmDCGuardarNuevaDepartamento; }
        public string VisibilidadError { get => visibilidadError; set => visibilidadError = value; }


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


