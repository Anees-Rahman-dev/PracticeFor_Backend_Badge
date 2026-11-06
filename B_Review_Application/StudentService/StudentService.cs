using B_Review_Application.Interface;
using B_Review_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Review_Application.StudentService
{

    public class StudentService 
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService (IStudentRepository studentRepository)
        {
            studentRepository = _studentRepository;
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }

        public Student? GetStudent(int id)
        {
            return _studentRepository.GetStudentById(id);
        }

        public Student AddStudent(Student student)
        {
            return _studentRepository.AddStudent(student);
        }

        public bool UpdateStudent(int id, Student student)
        {
            return _studentRepository.UpdateStudent(id,student);
        }

        public bool UpdateSpecificStudent(int id, StudentPatchDto student)
        {
            return _studentRepository.UpdateStudentSpecific(id, student);
        }

        public bool DeleteStudent(int id)
        {
            return _studentRepository.DeleteStudent(id);
        }
    }
}
