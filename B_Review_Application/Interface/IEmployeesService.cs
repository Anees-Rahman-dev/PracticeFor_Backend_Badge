using B_Review_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Review_Application.Interface
{
    public interface IEmployeesService 
    {
        public Task<List<Employee>> GetAll();

        public Task<Employee?> GetById(int id);

        public Task Add(Employee employee);

        public Task<bool> Update(int id, Employee employee);

        public Task<bool> Delete(int id);
    }
}
