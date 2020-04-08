using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _appDbContext;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public Department GetDepartment(int departmentId)
        {
            return  _appDbContext.Departments
                .FirstOrDefault(d=>d.DepartmentId==departmentId);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _appDbContext.Departments;
        }
    }
}
