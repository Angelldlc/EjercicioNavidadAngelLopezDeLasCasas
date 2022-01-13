using EjercicioNavidad_DAL.Listados;
using EjercicioNavidad_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioNavidad_BL
{
    public class clsListadosPlantaBL
    {
        /// <summary>
        /// Metodo que pide una lista de plantas a la capa DAL.
        /// </summary>
        /// <returns>La lista de plantas obtenida</returns>
        public static List<clsPlanta> getListadoCompletoPlantasBL() { return clsListadosPlantaDAL.getListadoCompletoPlantasDAL(); }

        /// <summary>
        /// Metodo que pide una plantas asociada a un id a la capa DAL.
        /// El id debe ser mayor que 0.        
        /// </summary>
        /// <param name="id"></param>
        /// <returns>La planta obtenida</returns>
        public static clsPlanta getPlanta(int id) { return clsListadosPlantaDAL.getPlantaDAL(id); }

        /// <summary>
        /// Metodo que pide una lista de plantas de una categoria a la capa DAL.
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>La lista de plantas obtenida</returns>
        public static List<clsPlanta> getListadoPlantasPorCategoriaBL(int categoria)
        {
            return clsListadosPlantaDAL.getListadoPlantasPorCategoriaDAL(categoria);
        }
    }
}
