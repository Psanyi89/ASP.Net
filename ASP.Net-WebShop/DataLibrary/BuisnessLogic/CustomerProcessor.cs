using DataLibrary.Models;
using System;
using System.Collections.Generic;
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
            string sql = $@"exec dbo.spDeleteUser '{username}', '{password}'";
            return IntData(sql);
        }

        public static int LoginCustomer(string Username, string Password)
        {
            string sql = $@"exec dbo.spLogin '{Username}', '{Password}'";

            return IntData(sql);
        }

        public static int CheckEmailorUserName(string text)
        {
            string sql = $@"exec dbo.uspCheckEmailorUsername '{text}'";

            return IntData(sql);
        }

        public static string SHA512(string password)
        {
            using (SHA512CryptoServiceProvider crypt = new SHA512CryptoServiceProvider())
            {
                StringBuilder hash = new StringBuilder();
                byte[] code = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(code);
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
            string sql = $@"exec dbo.uspGetCountry {Id}";
            return GetData(sql);
        }

        public static string GetStateName(int Id)
        {
            string sql = $@"exec dbo.uspGetState {Id}";
            return GetData(sql);
        }

        public static string GetCityName(int Id)
        {
            string sql = $@"exec dbo.uspGetCity {Id}";
            return GetData(sql);
        }
    }
}