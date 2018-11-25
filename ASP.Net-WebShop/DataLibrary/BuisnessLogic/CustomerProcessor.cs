using Dapper;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using static DataLibrary.DataAccess.SQLDataAccess;
namespace DataLibrary.BuisnessLogic
{
    public static class CustomerProcessor
    {
        public static int CreateCustomer(string userName, string firstName, string lastName,
            string phoneNumber, string eMail, string passWd, DateTime birthDate, string country,
            string states, string zipCode, string settlement, string addresses)
        {
            Customer data = new Customer
            {
                Username = userName,
                Firstname = firstName,
                Lastname = lastName,
                Phonenumber = phoneNumber,
                Email = eMail,
                Passwd = Sha256(passWd),
                Birthdate = birthDate,
                Country = country,
                States = states,
                Zipcode = zipCode,
                Settlement = settlement,
                Addresses = addresses
            };
            string sql = @"exec dbo.spInsertCustomer @Username, @Firstname, @Lastname,
@Phonenumber, @Email, @Passwd, @Birthdate, @Country, @States, @Zipcode, @Settlement, @Addresses";
            return SaveData(sql, data);
        }
        public static List<Customer> LoadCustomers()
        {
            string sql = @"exec dbo.spGetAllCustomers";
            return LoadData<Customer>(sql);
        }
        public static int DeleteCustomer(string username, string password)
        {
            string sql = @"exec dbo.spDeleteUser '@username', '@password'";
            return Deletedata(sql);
        }
        public static int LoginCustomer(string Username, string Password)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString("Shop")))
            {
                string jelszo = Sha256(Password);
                var p = new DynamicParameters();
                p.Add("@Username", Username);
                p.Add("@Password", jelszo);
                p.Add("@selection", dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spLogin", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("@selection");
                return newID;
            }
        }
        public static int CheckUsername(string Username)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString("Shop")))
            {

                var p = new DynamicParameters();
                p.Add("@Username", Username);
                p.Add("@selection", dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.uspCheckUsername", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("@selection");
                return newID;
            }
        }
        public static int CheckEmail(string Email)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString("Shop")))
            {

                var p = new DynamicParameters();
                p.Add("@Email", Email);
                p.Add("@selection", dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.uspCheckEmail", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("@selection");
                return newID;
            }
        }
        public static string Encryptor(string passWord)
        {
            using (MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding uTF8 = new UTF8Encoding();
                byte[] data = mD5.ComputeHash(uTF8.GetBytes(passWord));
                return Convert.ToBase64String(data);
            }
        }
        public static string Sha256(string password)
        {
            var crypt = new SHA512Managed();
            var hash = new StringBuilder();
            byte[] code = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(code);
        }
    }
}
