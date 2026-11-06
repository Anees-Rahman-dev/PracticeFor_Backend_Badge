using B_Review_Application.Interface;
using B_Review_Application.StudentService;
using B_Review_Domain.Entities;
using B_Review_Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace PracticeFor_B_Review.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController (IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _studentRepository.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _studentRepository.GetStudentById(id);
            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            var AddedStudent = _studentRepository.AddStudent(student);
            return Ok(AddedStudent);
        }

        [HttpPut("WholeField/{id}")]
        public IActionResult UpdatedStudent( [FromRoute] int id, [FromBody] Student student)
        {
            var isUpdated = _studentRepository.UpdateStudent(id, student);

            if (!isUpdated)
                return NotFound("Student not found");

            return Ok("Student updated successfully");
        }

        [HttpPatch("OneField/{id}")]
        public IActionResult UpdatedStudentOne(int id, [FromBody] StudentPatchDto patchDto)
        {
            var isUpdated = _studentRepository.UpdateStudentSpecific(id, patchDto);

            if (!isUpdated)
                return NotFound("Student not found");

            return Ok("Student updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var DeletedStudent = _studentRepository.DeleteStudent(id);

            if (!DeletedStudent)
                return NotFound("Student not found");

            return Ok("Student Deleted successfully");
        }

    }
}
