using EjercicioNavidad_DAL.Gestora;
using EjercicioNavidad_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioNavidad_BL
{
    public class clsGestoraPlantaBL
    {
        /// <summary>
        /// Metodo publico que llama a la capa DAL para editar el precio de una planta.
        /// La planta no debe ser nula.
        /// </summary>
        /// <param name="planta"></param>
        public static void editPrecioPlantaBL(clsPlanta planta) { clsGestoraPlantaDAL.editPrecioPlantaDAL(planta); }
    }
}
