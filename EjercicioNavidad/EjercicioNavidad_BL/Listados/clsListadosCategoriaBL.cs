using EjercicioNavidad_DAL.Listados;
using EjercicioNavidad_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioNavidad_BL.Listados
{
    public class clsListadosCategoriaBL
    {
        /// <summary>
        /// Metodo que pide una lista de categorias a la capa DAL.
        /// </summary>
        /// <returns>La lista de categorias obtenida</returns>
        public static List<clsCategoria> getListadoCompletoCategoriasBL() { return clsListadosCategoriaDAL.getListadoCompletoCategoriasDAL(); }

    }
}
