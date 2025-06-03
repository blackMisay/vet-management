using System;
using System.Data;
using System.Collections.Generic;
using MySqlConnector;
using System.Security.Cryptography;
using System.Windows.Forms;


namespace Core
{
    internal class UpgradeFile
    {
        internal MySqlConnection connection;
        private string connectionString;


        /// <summary>
        /// This constructor initializes the UpgradeManager object with default connection parameters.
        /// </summary>
        /// <returns>None</returns>
        public UpgradeFile()
        {
            string server = "localhost";
            string userid = "root";
            string password = "";
            string database = "vcms";
            this.connectionString = String.Format("server={0};database={1};userid={2};password={3};Allow Zero Datetime=True",
                server, database, userid, password);
        }


        /// <summary>
        /// This constructor allows the user to specify a custom connection string.
        /// </summary>
        /// <param name="connectionString">String represents the connection string</param>
        /// <returns>None</returns>
        public UpgradeFile(string connectionString)
        {
            this.connectionString = connectionString;
        }


        /// <summary>
        /// This method is responsible for establishing a connection to the database using the provided connection string
        /// </summary>
        /// <param>None</param>
        /// <returns>None</returns>
        /// <exception cref="Exception">It catches any exceptions that occur during the execution of the query and rethrows them with a new exception containing the error message.</exception>
        public void Connect()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch (MySqlException ex)
            {
                // Log or handle specific MySql errors here
                throw new Exception($"Error executing query: {ex.Message}");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
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
                this.Connect();
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
            catch (MySqlException ex)
            {
                // Log or handle specific MySql errors here
                throw new Exception($"Error executing query: {ex.Message}");
            }
            catch (Exception e)
            {
                throw new Exception($"Unexpected error: {e.Message}");
            }
            finally { this.connection.Close(); }
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
                this.Connect();
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
            catch (MySqlException ex)
            {
                // Log or handle specific MySql errors here
                MessageBox.Show($"Error executing query: {ex.Message}");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Unexpected error: {e.Message}");
            }
            finally { this.connection.Close(); }
            return null;
        }

        public List<KeyValuePair<int, string>> Populate(string query)
        {
            return Populate(query, null);
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
        public List<KeyValuePair<int, string>> Populate(string query, Dictionary<string, string> parameters)
        {
            List<KeyValuePair<int, string>> keyValueList;
            try
            {
                this.Connect();
                using (MySqlCommand cmd = new MySqlCommand(query, this.connection))
                {
                    if (parameters != null)
                    {
                        foreach (KeyValuePair<string, string> kvp in parameters)
                        {
                            cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
                        }
                    }
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

                        dr.Dispose();
                        cmd.Dispose();
                        return keyValueList;
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Log or handle specific MySql errors here
                throw new Exception($"Error executing query: {ex.Message}");
            }
            catch (Exception e)
            {
                throw new Exception($"Unexpected error: {e.Message}");
            }
            finally { this.connection.Close(); }
        }

        private int id = 0;

        public int Id
        {
            get { return id; }
            private set { id = value; }
        }
        public bool Save(string query, Dictionary<string, object> parameters)
        {
            try
            {
                this.Connect();
                using (MySqlCommand cmd = new MySqlCommand(query, this.connection))
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("ExecuteQuery MySqlException: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ExecuteQuery Exception: " + ex.Message);
                return false;
            }
            finally
            {
                this.connection.Close();
            }
        }

        public int ExecuteScalar(string sql, Dictionary<string, object> parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    foreach (var param in parameters)
                        cmd.Parameters.AddWithValue(param.Key, param.Value);

                    object result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }

        public int ExecuteInsertWithId(string sql, Dictionary<string, object> parameters)
        {
            try
            {
                this.Connect(); // <- Ensure the connection is opened
                using (var cmd = new MySqlCommand(sql, connection))
                {
                    foreach (var p in parameters)
                        cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);

                    object result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public bool ExecuteNonQuery(string sql, Dictionary<string, object> parameters)
        {
            try
            {
                connection.Open();
                using (var cmd = new MySqlCommand(sql, connection))
                {
                    foreach (var p in parameters)
                        cmd.Parameters.AddWithValue(p.Key, p.Value);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public Dictionary<string, object> QuerySingle(string sql, Dictionary<string, object> parameters)
        {
            try
            {
                this.Connect();
                using (var cmd = new MySqlCommand(sql, connection))
                {
                    foreach (var p in parameters)
                        cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                            }
                            return row;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Dictionary<string, object>> Query(string sql, Dictionary<string, object> parameters)
        {
            var results = new List<Dictionary<string, object>>();
            try
            {
                this.Connect();
                using (var cmd = new MySqlCommand(sql, connection))
                {
                    foreach (var p in parameters)
                        cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                            }
                            results.Add(row);
                        }
                    }
                }
            }
            finally
            {
                connection.Close();
            }
            return results;
        }


    }
}
