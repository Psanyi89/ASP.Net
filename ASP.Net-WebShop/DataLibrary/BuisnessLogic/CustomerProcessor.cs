using Dapper;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
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
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Username", username);
            parameters.Add("@Password", password);
            string sql = $@"exec dbo.spDeleteUser @Username, @Password";
            return GetData<int>(sql,parameters);
        }

        public static int LoginCustomer(string Username, string Password)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Username", Username);
            parameters.Add("@Password", Password);
            string sql = $@"exec dbo.spLogin @Username, @Password";

            return GetData<int>(sql,parameters);
        }

        public static int CheckEmailorUserName(string text)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Text", text);
          
            string sql = $@"exec dbo.uspCheckEmailorUsername @Text";

            return GetData<int>(sql,parameters);
        }

        public static string SHA512(string password)
        {
            using (SHA512CryptoServiceProvider sHA512 = new SHA512CryptoServiceProvider())
            {
                sHA512.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
                byte[] data = sHA512.Hash;
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    stringBuilder.Append(data[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }

        public static List<Country> LoadCountries()
        {
            string sql = @"exec dbo.uspGetCountries";
            return LoadData<Country>(sql);
        }

        public static List<State> LoadStates(int Id)
        {
            string sql = $@"exec dbo.uspChooseStates {Id}";
            return LoadData<State>(sql);
        }

        public static List<City> LoadCities(int StateId)
        {
            string sql = $@"exec dbo.uspChooseCities {StateId}";
            return LoadData<City>(sql);
        }

        public static string GetCountryName(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            
            string sql = $@"exec dbo.uspGetCountry @Id";
            return GetData<string>(sql,parameters);
        }

        public static string GetStateName(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            string sql = $@"exec dbo.uspGetState @Id";
            return GetData<string>(sql,parameters);
        }

        public static string GetCityName(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            string sql = $@"exec dbo.uspGetCity @Id";
            return GetData<string>(sql,parameters);
        }
    }
}