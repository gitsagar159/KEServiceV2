using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace KEServiceV2.Models.Data
{
    public class BaseMySQLDAL : MySQLConnection
    {
        public DataTable GetResultDataTable(string strQuery, CommandType SqlcommandType, List<MySqlParameter> lstParams)
        {
            var staticConnection = StaticSqlConnection;

            var command = new MySqlCommand
            {
                CommandText = strQuery,
                CommandType = SqlcommandType,
                Connection = staticConnection,
            };

            if (lstParams != null)
                command.Parameters.AddRange(lstParams.ToArray());


            var objDataAdapter = new MySqlDataAdapter();
            var dt = new DataTable();
            try
            {
                staticConnection.Open();
                objDataAdapter.SelectCommand = command;
                objDataAdapter.Fill(dt);
                staticConnection.Close();
                return dt;
            }
            catch
            {
                throw;
            }
            finally
            {
                dt.Dispose();
                objDataAdapter.Dispose();
                staticConnection.Close();
                command.Dispose();
            }
        }

        public DataSet GetResultDataSet(string strQuery, CommandType SqlcommandType, List<MySqlParameter> lstParams)
        {
            var staticConnection = StaticSqlConnection;

            var command = new MySqlCommand
            {
                CommandText = strQuery,
                CommandType = SqlcommandType,
                Connection = staticConnection,
            };

            if (lstParams != null)
                command.Parameters.AddRange(lstParams.ToArray());


            var objDataAdapter = new MySqlDataAdapter();
            var ds = new DataSet();
            try
            {
                staticConnection.Open();
                objDataAdapter.SelectCommand = command;
                objDataAdapter.Fill(ds);
                staticConnection.Close();
                return ds;
            }
            catch
            {
                throw;
            }
            finally
            {
                ds.Dispose();
                objDataAdapter.Dispose();
                staticConnection.Close();
                command.Dispose();
            }
        }

        public int ExeccuteStoreCommand(string strQuery, CommandType SqlcommandType, List<MySqlParameter> lstParams, bool blnLastId = false)
        {
            int intLastId = 0;

            var staticConnection = StaticSqlConnection;

            var command = new MySqlCommand
            {
                CommandText = strQuery,
                CommandType = SqlcommandType,
                Connection = staticConnection,
            };

            if (lstParams != null)
                command.Parameters.AddRange(lstParams.ToArray());

            try
            {
                staticConnection.Open();
                command.ExecuteNonQuery();

                if (blnLastId)
                {
                    string stQuery2 = "Select last_insert_id() AS id";
                    command.CommandText = stQuery2;
                    intLastId = (int)command.ExecuteScalar();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                staticConnection.Close();
                command.Dispose();
            }

            return intLastId;
        }
    }
}