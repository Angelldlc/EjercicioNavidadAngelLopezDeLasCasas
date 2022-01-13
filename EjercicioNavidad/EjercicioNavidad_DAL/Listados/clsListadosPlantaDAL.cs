using EjercicioNavidad_DAL.Conexion;
using EjercicioNavidad_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EjercicioNavidad_DAL.Listados
{
    public class clsListadosPlantaDAL
    {
        private static clsMyConnection myConnection = new clsMyConnection();

        /// <summary>
        /// Metodo publico que devuelve un listado completo de plantas de una base de datos.
        /// </summary>
        /// <returns>La lista de plantas obtenida</returns>
        public static List<clsPlanta> getListadoCompletoPlantasDAL()
        {

            List<clsPlanta> listPlantas = new List<clsPlanta>();
            clsPlanta planta;
            SqlDataReader reader;
            SqlCommand command = new SqlCommand("SELECT * FROM plantas");
            try
            {
                myConnection.openConnection();
                command.Connection = myConnection.Connection;
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        planta = constructPlanta(reader);
                        listPlantas.Add(planta);
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
            return listPlantas;
        }

        /// <summary>
        /// Metodo publico que devuelve una sola planta asociado a un id de una base de datos.
        /// El id debe ser mayor que 0.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>La planta obtenida</returns>
        public static clsPlanta getPlantaDAL(int id)
        {
            clsPlanta planta = null;
            SqlDataReader reader;
            SqlCommand command = new SqlCommand("SELECT * FROM plantas WHERE idPlanta = @idPlanta ");
            command.Parameters.AddWithValue("@idPlanta", id);
            try
            {
                myConnection.openConnection();
                command.Connection = myConnection.Connection;
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    planta = constructPlanta(reader);
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
            return planta;
        }

        /// <summary>
        /// Metodo publico que devuelve un listado de plantas segun su categoria de una base de datos.
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        public static List<clsPlanta> getListadoPlantasPorCategoriaDAL(int categoria)
        {
            List<clsPlanta> listPlantas = new List<clsPlanta>();
            clsPlanta planta;
            SqlDataReader reader;
            SqlCommand command = new SqlCommand("SELECT * FROM plantas" +
                                                " WHERE idCategoria = @idCategoria");
            command.Parameters.AddWithValue("@idCategoria", categoria);
            try
            {
                myConnection.openConnection();
                command.Connection = myConnection.Connection;
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        planta = constructPlanta(reader);
                        listPlantas.Add(planta);
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
            return listPlantas;
        }

        /// <summary>
        /// Metodo privado que construye una planta a partir de los campos leidos por un SQLDataReader de una base de datos.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>La planta construida</returns>
        private static clsPlanta constructPlanta(SqlDataReader reader)
        {
            clsPlanta constructedPlanta = new clsPlanta();

            constructedPlanta.Id = (int)reader["idPlanta"];
            constructedPlanta.Nombre = (string)reader["nombrePlanta"];
            constructedPlanta.Descripcion = (string)reader["descripcion"];
            constructedPlanta.IdCategoria = (int)reader["idCategoria"];
            constructedPlanta.Precio = reader["precio"] != DBNull.Value ? (double)reader["precio"] : 0;

            return constructedPlanta;
        }

    }
}
