using B_Review_Application.Interface;
using B_Review_Domain.Entities;
using B_Review_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Review_Infrastructure.Repository
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly ApplicationDBContext _dBContext;

        public EmployeesRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<List<Employee>> GetAllEmployee()
        {
            return await _dBContext.Employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await _dBContext.Employees.FirstOrDefaultAsync(F => F.Id == id);
        }

        public async Task AddEmployee(Employee employee)
        {
             await _dBContext.Employees.AddAsync(employee);
            await _dBContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateEmployee(int id, Employee employee)
        {
            var Exist = await _dBContext.Employees.FirstOrDefaultAsync(F => F.Id == id);

            if(Exist == null)
            {
                return false;
            }
            else
            {
                Exist.Name = employee.Name;
                Exist.Email = employee.Email;
                Exist.Age = employee.Age;
                Exist.Salary = employee.Salary;
                Exist.Department = employee.Department;
                await _dBContext.SaveChangesAsync();

                return true;
            }   
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var Exist = await _dBContext.Employees.FirstOrDefaultAsync(F => F.Id == id);

            if(Exist != null)
            {
               _dBContext.Employees.Remove(Exist);

                await _dBContext.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
