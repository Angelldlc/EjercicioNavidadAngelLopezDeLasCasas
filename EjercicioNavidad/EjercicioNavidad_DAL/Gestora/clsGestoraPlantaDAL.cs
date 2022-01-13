using EjercicioNavidad_DAL.Conexion;
using EjercicioNavidad_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EjercicioNavidad_DAL.Gestora
{
    public class clsGestoraPlantaDAL
    {
        private static clsMyConnection myConnection = new clsMyConnection();

        /// <summary>
        /// Metodo publico que edita una planta en una base de datos.
        /// La planta no debe ser nula.
        /// </summary>
        /// <param name="planta"></param>
        public static void editPrecioPlantaDAL(clsPlanta planta)
        {
            SqlCommand command = new SqlCommand("UPDATE plantas " +
                                            "SET nombrePlanta = @nombrePlanta " +
                                                ",descripcion = @descripcion " +
                                                ",idCategoria = @idCategoria " +
                                                ",precio = @precio " +
                                            "WHERE idPlanta = @idPlanta");

            command.Parameters.AddWithValue("@idPlanta", planta.Id);
            command.Parameters.AddWithValue("@nombrePlanta", planta.Nombre);
            command.Parameters.AddWithValue("@descripcion", planta.Descripcion);
            command.Parameters.AddWithValue("@idCategoria", planta.IdCategoria);
            command.Parameters.AddWithValue("@precio", planta.Precio);

            try
            {
                myConnection.openConnection();
                command.Connection = myConnection.Connection;
                command.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                myConnection.closeConnection();

            }
        }
    }
}
