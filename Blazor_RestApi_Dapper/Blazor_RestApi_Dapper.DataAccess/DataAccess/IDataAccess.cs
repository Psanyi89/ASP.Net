using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor_RestApi_Dapper.DataAccess
{
    public interface IDataAccess
    {
     
        Task<int> CmdExecute(string sqlCommand, string connectionString, DynamicParameters parameters = null);

        Task<IEnumerable<T>> GetList<T>(string sqlCommand, string connectionString, DynamicParameters parameters = null) where T : class;

        Task<T> GetSingle<T>(string sqlCommand, string connectionString, DynamicParameters parameters = null) where T : class;
   
    }
}