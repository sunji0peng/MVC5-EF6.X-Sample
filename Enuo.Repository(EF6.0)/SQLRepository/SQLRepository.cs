using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enuo.Repository
{
    /// <summary>
    /// 功能：Enuo.Repository.SQL功能
    /// 描述：采用最底层的ADO.NET中的数据库连接方式，实现对数据库脚本的执行
    /// 作者：孙继鹏
    /// 日期：2016-3-29
    /// </summary>
    public class SQLRepository : IDisposable
    {
        #region Fields
        /// <summary>
        /// 数据库连接字符串
        /// TODO：这里可以通过读取配置文件信息
        /// </summary>
        private string ConncetionString;
        #endregion

        #region Ctors
        public SQLRepository(string connStr)
        {
            ConncetionString = connStr;
        }
        #endregion

        #region
        /// <summary>
        /// 执行返回受影响的数据行数，包括Update、Insert、Delete
        /// </summary>
        /// <param name="sqltxt">执行sql脚本，包含参数</param>
        /// <param name="parDict">参数集合</param>
        public bool ExecuteNonQuery(string sqltxt, Dictionary<string, object> parDict = null)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConncetionString))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandText = sqltxt;
                cmd.CommandType = System.Data.CommandType.Text;
                if (parDict != null)
                {
                    foreach (var item in parDict.Keys)
                    {
                        cmd.Parameters.Add(new SqlParameter(item, parDict[item]));
                    }
                }
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        /// <summary>
        /// 执行返回受影响的数据行数，包括Update、Insert、Delete
        /// </summary>
        /// <param name="sqltxt">执行sql脚本，包含参数</param>
        /// <param name="parDict">参数集合</param>
        public bool ExecuteNonQuery(string sqltxt, params SqlParameter[] parDict)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConncetionString))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandText = sqltxt;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddRange(parDict);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        /// <summary>
        /// 执行返回DataSet集合,包含多张表
        /// </summary>
        /// <param name="sqltxt">执行sql脚本，包含参数</param>
        /// <param name="parDict">参数集合</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string sqltxt, Dictionary<string, object> parDict = null)
        {
            DataSet ds = new DataSet();
            using (SqlConnection sqlConnection = new SqlConnection(ConncetionString))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandText = sqltxt;
                cmd.CommandType = System.Data.CommandType.Text;
                if (parDict != null)
                {
                    foreach (var item in parDict.Keys)
                    {
                        cmd.Parameters.Add(new SqlParameter(item, parDict[item]));
                    }
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(ds);
            }
            return ds;
        }
        /// <summary>
        /// 执行返回DataTable集合,包含多张表
        /// </summary>
        /// <param name="sqltxt">执行sql脚本，包含参数</param>
        /// <param name="parDict">参数集合</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sqltxt, Dictionary<string, object> parDict = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConncetionString))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandText = sqltxt;
                cmd.CommandType = System.Data.CommandType.Text;
                if (parDict != null)
                {
                    foreach (var item in parDict.Keys)
                    {
                        cmd.Parameters.Add(new SqlParameter(item, parDict[item]));
                    }
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
            }
            return dt;
        }
        /// <summary>
        /// 执行查询，并返回一个DateReader对象，可以通过reader.Reader进行逐个读取
        /// </summary>
        /// <param name="sqltxt">执行sql脚本，包含参数</param>
        /// <param name="parDict">参数集合</param>
        public SqlDataReader ExecuteReader(string sqltxt, Dictionary<string, object> parDict = null)
        {
            SqlDataReader rdr = null;
            using (SqlConnection sqlConnection = new SqlConnection(ConncetionString))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandText = sqltxt;
                cmd.CommandType = System.Data.CommandType.Text;
                if (parDict != null)
                {
                    foreach (var item in parDict.Keys)
                    {
                        cmd.Parameters.Add(new SqlParameter(item, parDict[item]));
                    }
                }
                rdr = cmd.ExecuteReader();
            }
            return rdr;
        }
        /// <summary>
        /// 执行查询，并返回查询结果中第一行的第一列，若找不到第一行的第一列则返回null
        /// </summary>
        /// <param name="sqltxt">执行sql脚本，包含参数</param>
        /// <param name="parDict">参数集合</param>
        public T ExecuteScalar<T>(string sqltxt, Dictionary<string, object> parDict = null) where T : class
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConncetionString))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandText = sqltxt;
                cmd.CommandType = System.Data.CommandType.Text;
                if (parDict != null)
                {
                    foreach (var item in parDict.Keys)
                    {
                        cmd.Parameters.Add(new SqlParameter(item, parDict[item]));
                    }
                }
                object rdr = cmd.ExecuteScalar();
                return rdr != null ? (T)rdr : default(T);
            }
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public void Disposed(bool isDisposing)
        {

        }

        #endregion
    }

}
