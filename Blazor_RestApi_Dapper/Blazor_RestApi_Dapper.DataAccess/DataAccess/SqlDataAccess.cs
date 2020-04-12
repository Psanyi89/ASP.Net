using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_RestApi_Dapper.DataAccess
{
    public class SqlDataAccess : IDataAccess
    {
        private IDbConnection GetDbConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
        #region Get IEnumerable of T type
        /// <summary>
        /// Loads a list of T type from a SQL database \n Only stored procedures can be used
        /// </summary>
        /// <typeparam name="T">Data model type</typeparam>
        /// <param name="sqlCommand">name of the storedprocedure</param>
        /// <param name="connectionString">SQL connectionstring</param>
        /// <param name="parameters">DynamicParameter for the query</param>
        /// <returns>Returns a list of T</returns>
        public async Task<IEnumerable<T>> GetList<T>(string sqlCommand, string connectionString, DynamicParameters parameters = null) where T : class
        {
            using (IDbConnection connection = GetDbConnection(connectionString))
            {
                return await connection.QueryAsync<T>(sqlCommand, parameters, commandType: CommandType.StoredProcedure);
            }
        }
        #endregion

        #region  Single Line Query
        /// <summary>
        ///  Single object or value query
        /// </summary>
        /// <typeparam name="T">Data model type</typeparam>
        /// <param name="sqlCommand">name of the storedprocedure</param>
        /// <param name="connectionString">SQL connectionstring</param>
        /// <param name="parameters">DynamicParameter for the query</param>
        /// <returns>Returns a single object or variable</returns>
        public async Task<T> GetSingle<T>(string sqlCommand, string connectionString, DynamicParameters parameters = null)where T : class
        {
            using (IDbConnection connection = GetDbConnection(connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<T>(sqlCommand, parameters, commandType: CommandType.StoredProcedure);
            }
        }
        #endregion

        #region Executes non-query sql commands
        /// <summary>
        /// Executes non-query sql commands
        /// </summary>
        /// <param name="sqlCommand">name of the storedprocedure</param>
        /// <param name="connectionString">SQL connectionstring</param>
        /// <param name="parameters">DynamicParameter for the query</param>
        /// <returns>returns number of rows were affected</returns>
        public async Task<int> CmdExecute(string sqlCommand, string connectionString, DynamicParameters parameters = null)
        {
            using (IDbConnection connection = GetDbConnection(connectionString))
            {
               return await connection.ExecuteScalarAsync<int>(sqlCommand, parameters, commandType: CommandType.StoredProcedure);
               
            }
        }
        #endregion

    }
}
