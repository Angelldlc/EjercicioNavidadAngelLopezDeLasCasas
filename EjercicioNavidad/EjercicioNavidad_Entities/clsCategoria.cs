using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioNavidad_Entities
{
    public class clsCategoria
    {
        #region constructores
        public clsCategoria()
        {
        }
        public clsCategoria(int idCategoria, string nombreCategoria)
        {
            IdCategoria = idCategoria;
            NombreCategoria = nombreCategoria;
        }
        #endregion

        #region propiedades publicas
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        #endregion
    }
}
