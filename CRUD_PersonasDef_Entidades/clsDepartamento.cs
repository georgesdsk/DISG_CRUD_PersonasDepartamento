using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_PersonasDef_Entidades
{
    public class clsDepartamento
    {

        #region propiedades públicas
        // Prop --> propiedad autoimplementada. No existe una propiedad privada visible, pero se genera automáticamente y allí es donde se almacena 
        // el valor. No crear una prop privada y una publica autoimplementada
        // Propfull --> Crea privada y pública
        public int ID { get; set; }
        public String  Nombre { get; set; }
        #endregion
    }
}
