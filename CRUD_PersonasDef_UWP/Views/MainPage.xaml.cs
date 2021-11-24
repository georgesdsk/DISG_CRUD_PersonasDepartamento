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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CRUD_PersonasDef_UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

           
        }

        private void navigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {

            NavigationViewItem itemSeleccionado = (NavigationViewItem)sender.SelectedItem;
            if (itemSeleccionado.Tag.Equals("Personas"))
            {
                contentFrame.Navigate(typeof(People));
            }
            else {
                
                contentFrame.Navigate(typeof(Departments));

            }


        }

        private void AnhadirClick(object sender, RoutedEventArgs e)
        {
            

        }
    }
}
