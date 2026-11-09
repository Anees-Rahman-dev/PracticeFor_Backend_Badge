using B_Review_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Review_Application.Interface
{
    public interface IEmployeesRepository
    {
        public Task<List<Employee>> GetAllEmployee();

        public Task<Employee?> GetEmployeeById(int id);

        public Task AddEmployee(Employee employee);

        public Task<bool> UpdateEmployee(int id, Employee employee);

        public Task<bool> DeleteEmployee(int id);

    }
}
