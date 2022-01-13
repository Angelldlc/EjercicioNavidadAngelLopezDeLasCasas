using EjercicioNavidad_Entities;
using System.Collections.Generic;

namespace EjercicioNavidad_UI.Models.ViewModels
{
    public class ListadoPlantasConListadoCategorias
    {
        private List<clsPlanta> listaPlantas;
        private List<clsCategoria> listaCategorias;
        private int idCategoriaSeleccionada;

        public ListadoPlantasConListadoCategorias()
        {

        }

        public ListadoPlantasConListadoCategorias(List<clsPlanta> listaPlantas, List<clsCategoria> listaCategorias)
        {
            ListaPlantas = listaPlantas;
            ListaCategorias = listaCategorias;
        }

        public ListadoPlantasConListadoCategorias(List<clsPlanta> listaPlantas, List<clsCategoria> listaCategorias, int idCategoriaSeleccionada) : this(listaPlantas, listaCategorias)
        {
            IdCategoriaSeleccionada = idCategoriaSeleccionada;
        }

        public List<clsPlanta> ListaPlantas { get => listaPlantas; set => listaPlantas = value; }
        public List<clsCategoria> ListaCategorias { get => listaCategorias; set => listaCategorias = value; }
        public int IdCategoriaSeleccionada { get => idCategoriaSeleccionada; set => idCategoriaSeleccionada = value; }
    }
}
