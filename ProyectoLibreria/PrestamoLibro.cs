//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoLibreria
{
    using System;
    using System.Collections.Generic;
    
    public partial class PrestamoLibro
    {
        public int id_prestamolibro { get; set; }
        public int dias_prestamolibro { get; set; }
        public Nullable<System.DateTime> fecha_prestamolibro { get; set; }
        public int id_usuario { get; set; }
        public int id_libro { get; set; }
    
        public virtual Libro Libro { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}