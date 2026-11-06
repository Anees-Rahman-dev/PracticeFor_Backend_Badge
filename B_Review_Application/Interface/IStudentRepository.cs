using B_Review_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Review_Application.Interface
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();

        Student? GetStudentById(int id);

        Student AddStudent(Student student);

        bool UpdateStudent(int id, Student student);

        bool UpdateStudentSpecific(int id, StudentPatchDto patchDto);

        bool DeleteStudent(int id);

    }
}
