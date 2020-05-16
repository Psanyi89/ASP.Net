using AutoMapper;
using EmployeeManagement.Api.Models;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string name,Gender? gender)
        {
            try
            {
              var result= await  _employeeRepository.Search(name, gender);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError
                 , "Error retrieving data from the database");
            }
        }

        // GET: api/employees
        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {

            try
            {
                return Ok(await _employeeRepository.GetEmployees());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError
                    , $"Error retrieving data from the database \n{ex.Message}\n{ex.StackTrace}");

            }
        }

        // GET: api/employees/id
       [HttpGet("{id:int}")]
       
       public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var result = await _employeeRepository.GetEmployee(id);
                if (result==null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError
                   , "Error retrieving data from the database");
            }
        }

        //POST: api/employees
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {           
            try
            {
                if (employee==null)
                {
                    return BadRequest();
                }
                var emp = await _employeeRepository.GetEmployeeByEmail(employee.Email);
                if (emp!=null)
                {
                    ModelState.AddModelError("email", "Employee email already in use");
                    return BadRequest(ModelState);
                }
                employee.Department = null;
            var createdEmployee= await _employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployee),new { id=createdEmployee.EmployeeId},createdEmployee);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError
                 , "Error retrieving data from the database");
            }
        }

        //PUT: api/employees
        [HttpPut()]
        public async Task<ActionResult<Employee>> UpdateEmployee( Employee employee)
        {
            try
            {
                var employeeToUpdate = await _employeeRepository.GetEmployee(employee.EmployeeId);
                if (employeeToUpdate==null)
                {
                    return NotFound($"Employee with Id = {employee.EmployeeId} not found");
                }

               return await _employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError
               , "Error updating data");
            }
          
        }
    
        // DELETE: api/employees/id
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var employeeToDelete = await _employeeRepository.GetEmployee(id);

                if (employeeToDelete==null)
                {
                    return NotFound($"Employee with Id= {id} not found");
                }

                return await _employeeRepository.DeleteEmployee(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError
              , "Error deleting data");
            }
        }
    }
}
