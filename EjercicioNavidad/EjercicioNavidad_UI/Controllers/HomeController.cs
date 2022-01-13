using EjercicioNavidad_BL;
using EjercicioNavidad_BL.Listados;
using EjercicioNavidad_Entities;
using EjercicioNavidad_UI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EjercicioNavidad_UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            ActionResult result;
            ListadoPlantasConListadoCategorias listaPlantasConListaCategorias;
            try
            {
                List<clsPlanta> plantas = clsListadosPlantaBL.getListadoCompletoPlantasBL();
                List<clsCategoria> categorias = clsListadosCategoriaBL.getListadoCompletoCategoriasBL();

                listaPlantasConListaCategorias = new ListadoPlantasConListadoCategorias(plantas, categorias);
                result = View(listaPlantasConListaCategorias);
            }
            catch
            {
                result = View("Error");
            }
            return result;
        }

        [HttpPost]
        public ActionResult Index(int categoriaSeleccionada)
        {
            ActionResult result;
            ListadoPlantasConListadoCategorias listadoPlantasConListadoCategorias;
            try
            {
                listadoPlantasConListadoCategorias = new ListadoPlantasConListadoCategorias(clsListadosPlantaBL.getListadoPlantasPorCategoriaBL(categoriaSeleccionada)
                                                                                            , clsListadosCategoriaBL.getListadoCompletoCategoriasBL()
                                                                                            , categoriaSeleccionada);
                result = View(listadoPlantasConListadoCategorias);
            }
            catch 
            {
                result = View("Error");
            }

            return result;
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            ActionResult result;
            clsPlanta plantaAEditar;
            try
            {
                plantaAEditar = clsListadosPlantaBL.getPlanta(id);
                result = View(plantaAEditar);
            }
            catch 
            { 
                result = View("Error"); 
            }

            return result;
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(clsPlanta planta)
        {
            ActionResult result;
            try
            {
                if (ModelState.IsValid)
                {
                    clsGestoraPlantaBL.editPrecioPlantaBL(planta);

                    return RedirectToAction(nameof(Index));
                }
                else 
                {
                    result = View(planta);
                }
            }
            catch
            {
                result = View("Error");
            }
            return result;
        }
    }
}
