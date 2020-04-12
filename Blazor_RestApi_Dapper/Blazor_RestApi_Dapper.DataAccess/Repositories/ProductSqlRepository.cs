﻿using Blazor_RestApi_Dapper.DataAccess.Enums;
using Blazor_RestApi_Dapper.DataAccess.IRepositories;
using Blazor_RestApi_Dapper.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_RestApi_Dapper.DataAccess.Repositories
{
    public class ProductSqlRepository : IProductRepository
    {
        private readonly IDataAccess _sqlDataAccess;
        private readonly string _connectionString;
        public ProductSqlRepository(string connectionString, IDataAccess sqlDataAccess)
        {
            this._connectionString = connectionString;
            this._sqlDataAccess = sqlDataAccess;
        }
        public async Task<Product> AddProduct(Product product)
        {
            DynamicParameters param = GetDynamicParameters(product);
            return await _sqlDataAccess.GetSingle<Product>(UspProducts.uspInsertProduct.ToString(),_connectionString,param);
           
        }

        public async Task<Product> DeleteProduct(int productId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ProductId", productId);
           return await _sqlDataAccess.GetSingle<Product>(UspProducts.uspDeleteProduct.ToString(), _connectionString, parameters);
            
        }

        public async Task<Product> GetProduct(int productId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ProductId", productId);
           return await _sqlDataAccess.GetSingle<Product>(UspProducts.uspGetProducts.ToString(), _connectionString, parameters);
        }

        public async Task<Product> GetProductByName(string name)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", name);
            return await _sqlDataAccess.GetSingle<Product>(UspProducts.uspGetProducts.ToString(), _connectionString, parameters);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _sqlDataAccess.GetList<Product>(UspProducts.uspGetProducts.ToString(),_connectionString);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            DynamicParameters param = GetDynamicParameters(product);
           return await _sqlDataAccess.GetSingle<Product>(UspProducts.uspUpdateProduct.ToString(), _connectionString, param);
        }

        #region Generate DynamicParameters for Products
        /// <summary>
        /// DynamicParameters for Products
        /// </summary>
        /// <typeparam name="T">Product model type</typeparam>
        /// <param name="product">the product</param>
        /// <returns></returns>
        private DynamicParameters GetDynamicParameters<T>(T product)where T : Product
        {
            DynamicParameters dynamicParameters = new DynamicParameters
            {
                RemoveUnused = true
            };

            if (product?.ProductId!=null && product?.ProductId>0)
            {
                dynamicParameters.Add("@ProductId", product.ProductId);
            }
            if (!string.IsNullOrWhiteSpace(product?.Name))
            {
                dynamicParameters.Add("@Name",product.Name);
            }
            if (product?.Quantity!=null)
            {
                dynamicParameters.Add("@Quantity", product.Quantity);
            }
            if (product?.Price!=null && product?.Price>0M)
            {
                dynamicParameters.Add("@Price", product.Price);
            }
            return dynamicParameters;
        }
        #endregion
    }
}
