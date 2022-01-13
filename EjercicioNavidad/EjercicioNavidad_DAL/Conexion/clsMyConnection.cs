using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

// Esta clase contiene los métodos necesarios para trabajar con el acceso a una base de datos SQL Server
//PROPIEDADES
//   server: cadena 
//   database: cadena, básica. Consultable/modificable.
//   user: cadena, básica. Consultable/modificable.
//   pass: cadena, básica. Consultable/modificable.

// MÉTODOS
//   Function getConnection() As SqlConnection
//       Este método abre una conexión con la base de datos. Lanza excepciones de tipo: SqlExcepion, InvalidOperationException y Exception.
//   
//   Sub closeConnection()
//       Este método cierra una conexión con la base de datos. Lanza excepciones de tipo: SqlExcepion, InvalidOperationException y Exception.
//

namespace EjercicioNavidad_DAL.Conexion
{
    public class clsMyConnection
    {
        //Atributos
        public string server { get; set; }
        public string dataBase { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
        public SqlConnection Connection { get; set; }

        //Constructores

        public clsMyConnection()
        {
            this.server = "localhost";
            this.dataBase = "FrayGuillermo";
            this.user = "prueba";
            this.pass = "123";
            this.Connection = new SqlConnection();
        }
        //Con parámetros por si quisiera cambiar las conexiones
        public clsMyConnection(string server, string database, string user, string pass)
        {
            this.server = server;
            this.dataBase = database;
            this.user = user;
            this.pass = pass;
            this.Connection = new SqlConnection();
        }

        //METODOS

        /// <summary>
        /// Método que abre una conexión con la base de datos
        /// </summary>
        /// <returns>Una conexión abierta con la base de datos</returns>
        public void openConnection()
        {
            try
            {
                this.Connection.ConnectionString = $"server={server};database={dataBase};uid={user};pwd={pass};";
                this.Connection.Open();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        /// <summary>
        /// Este metodo cierra una conexión con la Base de datos
        /// </summary>
        /// <post>La conexion es cerrada</post>
        public void closeConnection()
        {
            try
            {
                this.Connection.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
