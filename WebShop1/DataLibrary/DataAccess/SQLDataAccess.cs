using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataLibrary.DataAccess
{
    public class SQLDataAccess
    {
        public static string GetConnectionString(string connectionName="Shop")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }
        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString("Shop")))
            {
                return connection.Query<T>(sql).ToList();
            }
        }
        public static int SaveData<T>(string sql, T data)
        {
            using(IDbConnection cnn=new SqlConnection(GetConnectionString("Shop")))
            {
                return cnn.Execute(sql, data);
            }
        }
        public static int Deletedata(string sql)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString("Shop")))
            {
                return connection.Execute(sql);
            }
        }
       
    }
}
