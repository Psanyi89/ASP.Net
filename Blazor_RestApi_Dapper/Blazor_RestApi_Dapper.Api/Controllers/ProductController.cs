using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor_RestApi_Dapper.DataAccess.IRepositories;
using Blazor_RestApi_Dapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor_RestApi_Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            try
            {
                return Ok(await _productRepository.GetProducts());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError
                    , "Error retrieving data from the database");
            }
        }
    
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var result = await _productRepository.GetProduct(id);
                if (result==null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError
                   , "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody]Product product)
        {
            try
            {
                if(product.Name==null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var prod = await _productRepository.GetProductByName(product.Name);
                    if (prod!=default)
                    {
                        ModelState.AddModelError("Name", "Product name already in use");
                        return BadRequest(ModelState);
                    }
                    var createdProduct = await _productRepository.AddProduct(product);
                    if (createdProduct != null)
                    {
                        return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.ProductId },createdProduct);
                    }
                }
                return null;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError
                  , "Error retrieving data from the database");
            }
        }
    
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id,[FromBody]Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id != product.ProductId)
                    {
                        return BadRequest("Product ID mistmatch");
                    }
                    var productToUpdate = await _productRepository.GetProduct(id);
                    if (productToUpdate == null)
                    {
                        return NotFound($"Product with Id = {id} not found");
                    }
                   return await _productRepository.UpdateProduct(product);
                  
                }
                return null;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError
               , "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            try
            {
                var productToDelete = await _productRepository.GetProduct(id);
                if (productToDelete==null)
                {
                    return NotFound($"Product with Id = {id} not found");
                }
               return await _productRepository.DeleteProduct(id);          
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError
              , "Error deleting data");
            }
        }
    }
}
