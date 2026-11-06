using B_Review_Application.Interface;
using B_Review_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Review_Infrastructure.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private static List<Student> students = new List<Student>();

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public Student? GetStudentById(int id)
        {
            var student = students.FirstOrDefault(F => F.Id == id);
            return student;
        }

        public Student AddStudent(Student student)
        {
            student.Id = students.Count == 0 ? 1 : students.Max(s => s.Id) + 1;

            students.Add(student);

            return student;
        }

        public bool UpdateStudent(int id, Student student)
        {
            var ExistingStudent = students.FirstOrDefault(F => F.Id == id);

            try
            {
                if (ExistingStudent == null)
                {
                    return false;
                }
                else
                {
                    ExistingStudent.Name = student.Name;
                    ExistingStudent.Age = student.Age;
                    ExistingStudent.Email = student.Email;
                    ExistingStudent.Course = student.Course;
                }
                return true;

            }
            catch(Exception ex)
            {
                throw new Exception($"Updating student with {id} : {ex.Message}");
            }
        }
        public bool UpdateStudentSpecific(int id, StudentPatchDto studentPatchDto)
        {
            var ExistingStudent = students.FirstOrDefault(F => F.Id == id);

            try
            {
                if(ExistingStudent == null)
                {
                    return false;

                }
                else
                {
                    if(studentPatchDto.Name != null) //if we send any value that feild will be getting the updated value
                                                    //if (!string.IsNullOrEmpty(ExistingStudent.Name))
                        ExistingStudent.Name = studentPatchDto.Name;
                    
                    if(studentPatchDto.Age.HasValue)

                        ExistingStudent.Age = studentPatchDto.Age.Value;

                    if(studentPatchDto.Email != null)

                        ExistingStudent.Email = studentPatchDto.Email;

                    if(studentPatchDto.Course != null)

                        ExistingStudent.Course = studentPatchDto.Course;
                }

                return true;
            }
            catch(Exception ex)
            {
                throw new Exception($"Updating Specific Detail Of Student With {id} : {ex.Message}");
            }
        }

        public bool DeleteStudent(int id)
        {
            var ExistingStudent = students.FirstOrDefault(F => F.Id == id);

            if (ExistingStudent == null)
            {
                return false;
            }
            else
            {
                students.Remove(ExistingStudent);
                return true;

            }
            
        }

    }
}
