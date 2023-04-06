using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Vista.DatabaseConnector
{
    /// <summary>
    /// Static class that contains Load and Save methods for MS SQL Server
    /// </summary>
    public static class SqlServerDb
    {
        /// <summary>
        /// Method used to load data from a MS SQL Server database
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// <typeparam name="U">Type dynamic</typeparam>
        /// <param name="sqlQuery">The sql query to execute</param>
        /// <param name="parameters">An instance of a dynamic class that contains zero or more named parameter datamembers</param>
        /// <param name="connectionString">The connectionstring to connect to the database</param>
        /// <returns></returns>
        public static List<T> LoadData<T, U>(string sqlQuery, U parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(sqlQuery, parameters).ToList();
                return rows;
            }
        }

        /// <summary>
        /// Method used to save data to a MS SQL Server database
        /// </summary>
        /// <typeparam name="T">The type to save to the database</typeparam>
        /// <param name="sqlQuery">The sql query used to save the object to the database</param>
        /// <param name="parameters">An object of type T to be saved to the database</param>
        /// <param name="connectionString">The connectionstring to connect to the database</param>
        public static void SaveData<T>(string sqlQuery, T parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(sqlQuery, parameters);
            }
        }
    }
}
