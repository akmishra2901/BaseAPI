using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text;
using System.Data.SqlClient;

namespace BaseAPI.DataAccess
{
    public class DBAccess
    {
        private static IsolationLevel m_isoLevel = IsolationLevel.ReadUncommitted;

         #region "DB Access Functions"
        /// <summary>
        /// define IsolationLevel
        /// </summary>
        /// <value></value>
        /// <returns>IsolationLevel</returns>
        /// <remarks></remarks>
        public static IsolationLevel IsolationLevel
        {
            get { return m_isoLevel; }
        }
        /// <summary>
        /// Gets Connection out of Web.config
        /// </summary>
        /// <returns>Returns SqlConnection</returns>
        /// <remarks></remarks>
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString());
            conn.Open();
            return conn;

        }


        public static DataTable GetData(SqlCommand cmd)
        {
            DataSet ds = null;

            if (cmd.Connection != null)
            {
                using (ds = new DataSet())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.Fill(ds);

                    }
                }
            }
            else
            {
                using (SqlConnection conn = GetConnection())
                {
                    try
                    {
                        using (ds = new DataSet())
                        {
                            using (SqlDataAdapter da = new SqlDataAdapter())
                            {
                                da.SelectCommand = cmd;
                                da.SelectCommand.Connection = conn;
                                da.Fill(ds);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                    }
                }
            }
            return ds.Tables[0];
        }

        public static DataSet GetDatainDS(string sql)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlTransaction trans = conn.BeginTransaction(m_isoLevel))
                    {
                        try
                        {
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.Transaction = trans;
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = sql;
                                using (DataSet ds = new DataSet())
                                {
                                    using (SqlDataAdapter da = new SqlDataAdapter())
                                    {
                                        da.SelectCommand = cmd;
                                        da.SelectCommand.Connection = conn;
                                        da.Fill(ds);
                                        trans.Commit();
                                        return ds;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            return new DataSet();
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }
            finally
            {

            }
        }

        public static DataTable GetData(string sql)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    try
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = sql;
                            using (DataSet ds = new DataSet())
                            {
                                using (SqlDataAdapter da = new SqlDataAdapter())
                                {
                                    da.SelectCommand = cmd;
                                    da.SelectCommand.Connection = conn;
                                    da.Fill(ds);
                                    return ds.Tables[0];
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return new DataTable();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            finally
            {

            }
        }
        /// <summary>
        /// Executes a NonQuery
        /// </summary>
        /// <param name="cmd">NonQuery to execute</param>
        public static void ExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {

                    using (SqlTransaction trans = conn.BeginTransaction(m_isoLevel))
                    {
                        try
                        {
                            cmd.Connection = conn;
                            cmd.Transaction = trans;
                            cmd.ExecuteNonQuery();
                            trans.Commit();
                        }
                        catch
                        {
                            trans.Rollback();
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }

            finally
            {

            }
        }
        /// <summary>
        /// Executes a NonQuery string
        /// </summary>
        /// <param name="cmd">NonQuery to execute</param>
        public static void ExecuteNonQuery(string str)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlTransaction trans = conn.BeginTransaction(m_isoLevel))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = str;
                        cmd.Connection = conn;
                        cmd.Transaction = trans;
                        cmd.ExecuteNonQuery();
                        trans.Commit();
                    }
                    conn.Close();
                }
            }
            finally
            {

            }
        }
        /// <summary>
        /// Executes a Scalar Query
        /// </summary>
        /// <param name="cmd">Scalar to execute</param>
        public static object ExecuteScalar(SqlCommand cmd)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlTransaction trans = conn.BeginTransaction(m_isoLevel))
                    {
                        cmd.Connection = conn;
                        cmd.Transaction = trans;
                        object res = cmd.ExecuteScalar();
                        trans.Commit();
                        conn.Close();
                        return res;
                    }

                }
            }
            finally
            {

            }
        }
        /// <summary>
        /// Gets data out of the database
        /// </summary>
        /// <param name="cmd">The SQL Command</param>
        /// <returns>DataSet with the results</returns>
        public static DataSet GetDataSet(SqlCommand cmd)
        {
            try
            {
                if (cmd.Connection != null)
                {
                    using (DataSet ds = new DataSet())
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = cmd;
                            da.Fill(ds);
                            return ds;
                        }
                    }
                }
                else
                {
                    using (SqlConnection conn = GetConnection())
                    {
                        using (SqlTransaction trans = conn.BeginTransaction(m_isoLevel))
                        {
                            try
                            {
                                cmd.Transaction = trans;
                                using (DataSet ds = new DataSet())
                                {
                                    using (SqlDataAdapter da = new SqlDataAdapter())
                                    {
                                        da.SelectCommand = cmd;
                                        da.SelectCommand.Connection = conn;
                                        da.Fill(ds);
                                        trans.Commit();
                                        return ds;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                trans.Rollback();
                                return new DataSet();
                            }
                            finally
                            {
                                conn.Close();
                            }
                        }
                    }

                }
            }
            finally
            {

            }
        }
        #endregion
    }
}