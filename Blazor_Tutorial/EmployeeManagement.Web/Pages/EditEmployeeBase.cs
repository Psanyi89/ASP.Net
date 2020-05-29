using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Psanyi89.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeBase :ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        public string PageHeaderText { get; set; }

        public List<Department> Departments { get; set; } = new List<Department>();
        private Employee Employee { get; set; } = new Employee();
        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();
        [Parameter]
        public string Id { get; set; }

        protected ConfirmBase DeleteConfirmation { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }
        [Inject]
       public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int employeeId);
            if (employeeId!=0)
            {
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
                PageHeaderText = "Edit Employee";
            }
            else
            {
                PageHeaderText = "Create Employee";
                Employee = new Employee
                {
                    
                    Department=await DepartmentService.GetDepartment(1),
                    FirstName=string.Empty,
                    LastName=string.Empty,
                    Email=string.Empty,
                    DepartmentId = 1,
                    DateOfBirth = DateTime.Now,
                    PhotoPath = "images/profile.png"
                };
            }

            Departments = (await DepartmentService.GetDepartments()).ToList();
            Mapper.Map(Employee, EditEmployeeModel);
        }
        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                NavigationManager.NavigateTo("/");
            }
        }
    

        protected async Task HandleValidSubmit()
        {
            Mapper.Map(EditEmployeeModel, Employee);
            Employee result;
            if (Employee.EmployeeId!=0)
            {
                  result = await  EmployeeService.UpdateEmployee(Employee);

            }
            else
            {
                result = await EmployeeService.CreateEmployee(Employee);
            }
            if (result!=null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
