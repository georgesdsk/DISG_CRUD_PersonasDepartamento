using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace CRUD_PersonasDef_UWP.ViewModel.Utilidades
{
    public class clsConverterDate: IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime fecha = (DateTime)value <= DateTime.MinValue ? DateTime.Now : (DateTime)value;

            DateTimeOffset date = fecha;

            return date;
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ((DateTimeOffset)value).Date;
        }
    }
}
