using System;
using System.ComponentModel.DataAnnotations;

namespace EjercicioNavidad_Entities
{
    public class clsPlanta
    {
        #region constructores
        public clsPlanta()
        {
        }
        public clsPlanta(int id, string nombre, string descripcion, int idCategoria, double precio)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            IdCategoria = idCategoria;
            Precio = precio;
        }
        #endregion

        #region propiedades publicas
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public double Precio { get; set; }
        #endregion
    }
}
