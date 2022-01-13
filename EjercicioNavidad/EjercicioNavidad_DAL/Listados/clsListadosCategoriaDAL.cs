using EjercicioNavidad_DAL.Conexion;
using EjercicioNavidad_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EjercicioNavidad_DAL.Listados
{
    public class clsListadosCategoriaDAL
    {
        private static clsMyConnection myConnection = new clsMyConnection();

        /// <summary>
        /// Metodo publico que devuelve un listado completo de categorias de una base de datos.
        /// </summary>
        /// <returns>La lista de categorias obtenida</returns>
        public static List<clsCategoria> getListadoCompletoCategoriasDAL()
        {

            List<clsCategoria> listCategorias = new List<clsCategoria>();
            clsCategoria categoria;
            SqlDataReader reader;
            SqlCommand command = new SqlCommand("SELECT * FROM categorias");
            try
            {
                myConnection.openConnection();
                command.Connection = myConnection.Connection;
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        categoria = constructCategoria(reader);
                        listCategorias.Add(categoria);
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                myConnection.closeConnection();
            }
            return listCategorias;
        }

        /// <summary>
        /// Metodo publico que devuelve una sola categoria asociada a un id de una base de datos.
        /// El id debe ser mayor que 0.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>La categoria obtenida</returns>
        public static clsCategoria getCategoriaDAL(int id)
        {
            clsCategoria categoria = null;
            SqlDataReader reader;
            SqlCommand command = new SqlCommand("SELECT * FROM categorias WHERE idCategoria = @idCategoria ");
            command.Parameters.AddWithValue("@idCategoria", id);
            try
            {
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    categoria = constructCategoria(reader);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                myConnection.closeConnection();
            }
            return categoria;
        }

        /// <summary>
        /// Metodo privado que construye una categoria a partir de los campos leidos por un SQLDataReader de una base de datos.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>La categoria construida</returns>
        private static clsCategoria constructCategoria(SqlDataReader reader)
        {
            clsCategoria constructedCategoria = new clsCategoria();

            constructedCategoria.IdCategoria = (int)reader["idCategoria"];
            constructedCategoria.NombreCategoria = (string)reader["nombreCategoria"];

            return constructedCategoria;

        }
    }
}
