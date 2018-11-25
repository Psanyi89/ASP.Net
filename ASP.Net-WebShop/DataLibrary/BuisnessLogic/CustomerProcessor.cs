﻿using Dapper;
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
                Passwd = SHA512(passWd),
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
                var p = new DynamicParameters();
                p.Add("@Username", Username);
                p.Add("@Password", SHA512(Password));
                p.Add("@selection", dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spLogin", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("@selection");
                return newID;
            }
        }
        public static int CheckEmailorUserName(string text)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString("Shop")))
            {

                var p = new DynamicParameters();
                p.Add("@text", text);
                p.Add("@selection", dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.uspCheckEmailorUserName", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("@selection");
                return newID;
            }
        }
        public static string SHA512(string password)
        {
            var crypt = new SHA512Managed();
            var hash = new StringBuilder();
            byte[] code = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(code);
        }
    }
}
