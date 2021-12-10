using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace CRUD_PersonasDef_UWP.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class People : Page
    {
        public People()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Si el sender es nulo se pone le border en rojo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>

        private void tbNombre_Changing(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            if (sender.Text == "")
            {

                sender.BorderThickness = new Thickness(3);
                sender.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                sender.PlaceholderForeground = new SolidColorBrush(Windows.UI.Colors.Red);

            }
            else
            {
                sender.BorderThickness = new Thickness(0);
            }

        }

       
    }
}
