using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welenda.lk.Models;
using static Welenda.lk.Models.AuthErrorCodes;

namespace Welenda.lk.Database
{
    class ExecuteQueries
    {
        private SqlConnection getConnection()
        {
            var database = Connection.getDbInstance();
            return database.GetDBConnection();
        }

        public ErrorCodes CreateUser(string email, string password, string name)
        {
            if (!this.CheckEmailExist(email))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = getConnection();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT into [user] (email, password, name, uid) VALUES (@email, @password, @name, @uid)";
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@uid", Guid.NewGuid());

                    try
                    {
                        lock (this)
                        {
                            if (command.Connection.State == ConnectionState.Closed)
                            {
                                command.Connection.Open();
                            }
                        }

                        int recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        var msg = e.Message;
                        return ErrorCodes.exception;
                    }
                    finally
                    {
                        command.Connection.Close();
                    }
                }

                return ErrorCodes.success;
            }
            else
            {
                return ErrorCodes.emailExist;
            }
        }

        private bool CheckEmailExist(string email)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = getConnection();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT COUNT(*) FROM [user] WHERE email = @email";
                command.Parameters.AddWithValue("@email", email);

                try
                {
                    if (command.Connection.State == ConnectionState.Closed)
                    {
                        command.Connection.Open();
                    }

                    lock (this)
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<string> str = new List<string>();

                            while (reader.Read())
                            {
                                str.Add(reader.GetValue(0).ToString());
                            }

                            if (str[0].Equals("1"))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                            if (!reader.IsClosed)
                            {
                                reader.Close();
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    var msg = e.Message;
                    return false;
                }
                finally
                {
                    command.Connection.Close();
                }
            }            
        }

        public ResultModel LoginUser(string email, string password)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = getConnection();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM [user] WHERE email = @email AND password = @password";
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);

                try
                {
                    if (command.Connection.State == ConnectionState.Closed)
                    {
                        command.Connection.Open();
                    }

                    lock (this)
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<string> str = new List<string>();

                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    str.Add(reader.GetValue(i).ToString().Trim());
                                }
                            }

                            if (str.Count == 0)
                            {
                                return new ResultModel { errorCode = ErrorCodes.nouserinfo, result = null };
                            }
                            else
                            {
                                return new ResultModel { errorCode = ErrorCodes.success, result = str };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    var msg = e.Message;
                    return new ResultModel { errorCode = ErrorCodes.exception, result = null };
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }

        public ResultModel GetHotProducts()
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = getConnection();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM [products] where ishotproduct = 1";

                try
                {
                    if (command.Connection.State == ConnectionState.Closed)
                    {
                        command.Connection.Open();
                    }

                    lock (this)
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Dictionary<string, List<string>> str = new Dictionary<string, List<string>>();

                            while (reader.Read())
                            {
                                var data = new List<string>();
                                var id = string.Empty;

                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    if (i % 9 == 0)
                                    {
                                        id = reader.GetValue(i).ToString().Trim();
                                        data = new List<string>();
                                    }
                                    else if (i % 9 == 8)
                                    {
                                        data.Add(reader.GetValue(i).ToString().Trim());
                                        str.Add(id, data);
                                    }
                                    else
                                    {
                                        data.Add(reader.GetValue(i).ToString().Trim());
                                    }
                                }
                            }

                            if (str.Count != 0)
                            {
                                return new ResultModel { errorCode = ErrorCodes.success, hotProducts = str };
                            }

                            if (!reader.IsClosed)
                            {
                                reader.Close();
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    var msg = e.Message;
                    return new ResultModel { errorCode = ErrorCodes.exception };
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return new ResultModel { errorCode = ErrorCodes.success };
        }

        public ResultModel GetElectronicsProducts()
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = getConnection();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM [products] where isinhomepage = 1";

                try
                {
                    if (command.Connection.State == ConnectionState.Closed)
                    {
                        command.Connection.Open();
                    }

                    lock (this)
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Dictionary<string, List<string>> str = new Dictionary<string, List<string>>();
                            
                            while (reader.Read())
                            {
                                var data = new List<string>();
                                var id = string.Empty;

                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    if (i % 9 == 0)
                                    {
                                        id = reader.GetValue(i).ToString().Trim();
                                        data = new List<string>();
                                    }
                                    else if (i % 9 == 8)
                                    {
                                        data.Add(reader.GetValue(i).ToString().Trim());
                                        str.Add(id, data);
                                    }
                                    else
                                    {
                                        data.Add(reader.GetValue(i).ToString().Trim());
                                    }
                                }
                            }

                            if (!reader.IsClosed)
                            {
                                reader.Close();
                            }

                            if (str.Count != 0)
                            {
                                return new ResultModel { errorCode = ErrorCodes.success, ElectornicsProducts = str };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    var msg = e.Message;
                    return new ResultModel { errorCode = ErrorCodes.exception };
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return new ResultModel { errorCode = ErrorCodes.success };
        }

        public ResultModel GetProductDetails(string productId)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = getConnection();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM [productdetail] where productid = @productId";
                command.Parameters.AddWithValue("@productId", Convert.ToInt32(productId));

                try
                {
                    if (command.Connection.State == ConnectionState.Closed)
                    {
                        command.Connection.Open();
                    }

                    lock (this)
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<string> str = new List<string>();

                            while (reader.Read())
                            {
                                var id = string.Empty;

                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    if (i % 5 == 0)
                                    {
                                        id = reader.GetValue(i).ToString().Trim();
                                    }
                                    else if (i % 5 == 4)
                                    {
                                        str.Add(reader.GetValue(i).ToString().Trim());
                                    }
                                    else
                                    {
                                        str.Add(reader.GetValue(i).ToString().Trim());
                                    }
                                }
                            }

                            if (!reader.IsClosed)
                            {
                                reader.Close();
                            }

                            if (str.Count != 0)
                            {
                                return new ResultModel { errorCode = ErrorCodes.success, result = str };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    var msg = e.Message;
                    return new ResultModel { errorCode = ErrorCodes.exception };
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return new ResultModel { errorCode = ErrorCodes.success };
        }

        public ResultModel GetProductInfo(string productId)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = getConnection();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM [products] where id = @productId";
                command.Parameters.AddWithValue("@productId", Convert.ToInt32(productId));

                try
                {
                    if (command.Connection.State == ConnectionState.Closed)
                    {
                        command.Connection.Open();
                    }

                    lock (this)
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<string> str = new List<string>();

                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    if (i % 8 != 0)
                                    {
                                        str.Add(reader.GetValue(i).ToString().Trim());
                                    }
                                }
                            }

                            if (!reader.IsClosed)
                            {
                                reader.Close();
                            }

                            if (str.Count != 0)
                            {
                                return new ResultModel { errorCode = ErrorCodes.success, result = str };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    var msg = e.Message;
                    return new ResultModel { errorCode = ErrorCodes.exception };
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return new ResultModel { errorCode = ErrorCodes.success };
        }
    }
}
