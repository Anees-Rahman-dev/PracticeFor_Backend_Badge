using B_Review_Application.Interface;
using B_Review_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Review_Application.Service
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepo;

        public EmployeesService(IEmployeesRepository employeesRepo)
        {
            _employeesRepo = employeesRepo;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _employeesRepo.GetAllEmployee();
        }

        public async Task<Employee?> GetById(int id)
        {
            return await _employeesRepo.GetEmployeeById(id);
        }

        public Task Add(Employee employee)
        {
             return _employeesRepo.AddEmployee(employee);
        }

        public async Task<bool> Update(int id, Employee employee)
        {
            return await _employeesRepo.UpdateEmployee(id, employee);
        }

        public async Task<bool> Delete(int id)
        {
            return await _employeesRepo.DeleteEmployee(id);
        }


    }
}
