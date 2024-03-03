using System;
using System.Data;
using System.Collections.Generic;

using MySqlConnector;


namespace app.Core.Repository
{
    internal class DBConnection : IDisposable
    {
        internal MySqlConnection connection;
        private string connectionString;


        /// <summary>
        /// This constructor initializes the DBConnection object with default connection parameters.
        /// </summary>
        /// <returns>None</returns>
        public DBConnection()
        {
            string server = "localhost";
            string userid = "root";
            string password = "";
            string database = "vetclinic";
            this.connectionString = String.Format("server={0};database={1};userid={2};password={3};",
                server, database, userid, password);
            this.Connect();
        }


        /// <summary>
        /// This constructor allows the user to specify a custom connection string.
        /// </summary>
        /// <param name="connectionString">String represents the connection string</param>
        /// <returns>None</returns>
        public DBConnection(string connectionString)
        {
            this.connectionString = connectionString;
            this.Connect();
        }


        /// <summary>
        /// This method is responsible for establishing a connection to the database using the provided connection string
        /// </summary>
        /// <param>None</param>
        /// <returns>None</returns>
        /// <exception cref="Exception">It catches any exceptions that occur during the execution of the query and rethrows them with a new exception containing the error message.</exception>
        private protected void Connect()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        /// <summary>
        /// This method executes a parameterized query and returns the result in the form of boolean.
        /// </summary>
        /// <param name="query">A string representing the SQL query to execute.</param>
        /// <param name="parameters">A dictionary containing parameter names and their corresponding values.</param>
        /// <returns>True if the query execution is successful, otherwise false.</returns>
        /// <exception cref="Exception">It catches any exceptions that occur during the execution of the query and rethrows them with a new exception containing the error message.</exception>
        public bool ExecuteQuery(string query, Dictionary<string, string> parameters)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, this.connection))
                {
                    foreach (KeyValuePair<string, string> kvp in parameters)
                    {
                        cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }


        /// <summary>
        /// This method executes a query against the database and returns the result in the form of a DataTable
        /// </summary>
        /// <param name="query">A string representing the SQL query to execute.</param>
        /// <returns>It returns the populated <see cref="System.Data.DataTable"/> containing the result of the query.</returns>
        /// <exception cref="Exception">
        /// It catches any exceptions that occur during the execution of the query and rethrows them with
        /// a new exception containing the error message.</exception>
        public DataTable Load(string query)
        {
            return this.Load(query, null);
        }


        /// <summary>
        /// This method executes a parameterized query against the database and returns the result in the form of a DataTable
        /// </summary>
        /// <param name="query">A string representing the SQL query to execute.</param>
        /// <param name="param">A dictionary containing parameter names and their corresponding values.</param>
        /// <returns>It returns the populated <see cref="System.Data.DataTable"/> containing the result of the query.</returns>
        /// <exception cref="Exception">It catches any exceptions that occur during the execution of the query and rethrows them with
        /// a new exception containing the error message.</exception>
        public DataTable Load(string query, Dictionary<string, string> param)
        {
            try
            {
                DataTable dt;
                using (MySqlCommand cmd = new MySqlCommand(query, this.connection))
                {
                    if (param != null)
                    {
                        foreach (KeyValuePair<string, string> kvp in param)
                        {
                            cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
                        }
                    }
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        dt = new DataTable();
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        /// <summary>
        /// This method executes a query against the database and populates a list of key-value pairs.
        /// </summary>
        /// <param name="query">A string representing the SQL query to execute.</param>
        /// <returns>A list of key-value pairs.</returns>
        /// <exception cref="Exception">
        /// It catches any exceptions that occur during the execution of the query and rethrows them 
        /// with a new exception containing the error message.
        /// </exception>
        public List<KeyValuePair<int, string>> Populate(string query)
        {
            List<KeyValuePair<int, string>> keyValueList;
            try
            {
                using (DBConnection db = new DBConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, db.connection))
                    {
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            keyValueList = new List<KeyValuePair<int, string>>();
                            while (dr.Read())
                            {
                                int Id = dr.GetInt32(0);
                                string Description = dr.GetString(1);

                                KeyValuePair<int, string> category = new KeyValuePair<int, string>(Id, Description);
                                keyValueList.Add(category);
                            }

                            dr.Close();
                            return keyValueList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        /// <summary>
        /// This method is typically used to release resources held by an object.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}