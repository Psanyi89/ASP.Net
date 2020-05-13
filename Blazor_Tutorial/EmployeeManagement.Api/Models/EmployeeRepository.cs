using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            try
            {
                var result = await _appDbContext.Employees.AddAsync(employee);
                await _appDbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var result = await _appDbContext.Employees.FirstOrDefaultAsync(
                e => e.EmployeeId == employeeId);
            if (result!=null)
            {
                _appDbContext.Employees.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
           return await _appDbContext.Employees
                .Include(e=>e.Department)
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
           
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await _appDbContext.Employees.FirstOrDefaultAsync(
                  e => e.Email == email);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _appDbContext.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = _appDbContext.Employees;
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name));
            }
            if (gender!=null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result= await _appDbContext.Employees.FirstOrDefaultAsync(
                 e => e.EmployeeId == employee.EmployeeId);
            if (result!=null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.DepartmentId = employee.DepartmentId;
                result.DateOfBirth = employee.DateOfBirth;
                result.Email = employee.Email;
                result.Gender = employee.Gender;
                result.PhotoPath = employee.PhotoPath;
                
                await _appDbContext.SaveChangesAsync();
                
                return result;
            }
            return null;
        }
    }
}
