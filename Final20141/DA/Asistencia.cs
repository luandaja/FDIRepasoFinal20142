//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DA
{
    using System;
    using System.Collections.Generic;
    
    public partial class Asistencia
    {
        public int id { get; set; }
        public System.DateTime ingreso { get; set; }
        public Nullable<System.DateTime> salida { get; set; }
        public Nullable<int> horastrabajadas { get; set; }
        public int FK_Empleado { get; set; }
    
        public virtual Empleado Empleado { get; set; }
    }
}
