using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using student_management_backend.Data;
using student_management_backend.Models.Dto;
using student_management_backend.Models.Entities;

namespace student_management_backend.Controllers
{
    //localhost:xxxx/api/students
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDBContext dBContext;
        public StudentController(ApplicationDBContext dBContext) 
        { 
            this.dBContext = dBContext;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var allStudents = dBContext.Students.ToList();

            return Ok(allStudents);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetStudentById(Guid id)
        {
            var student = dBContext.Students.Find(id);

            if(student is null)
            {
                return NotFound("Student not exists with provided id: " + id);
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult SaveStudent(StudentDto addStudentDto)
        {
            var studentEntity = new Student()
            {
                Name = addStudentDto.Name,
                Email = addStudentDto.Email,
                Phone = addStudentDto.Phone,
                Address = addStudentDto.Address,
                Age = addStudentDto.Age
            };

            dBContext.Students.Add(studentEntity);
            dBContext.SaveChanges();

            return Ok(studentEntity);
        }

        [HttpPut]
        [Route("{id=guid}")]
        public IActionResult UpdateStudent(StudentDto addStudentDto, Guid id)
        {
            var student = dBContext.Students.Find(id);
            if (student is null)
            {
                return NotFound("Student not exists with provided id: " + id);
            }

            student.Email = addStudentDto.Email;
            student.Phone = addStudentDto.Phone;    
            student.Address = addStudentDto.Address;
            student.Age = addStudentDto.Age;
            student.Name = addStudentDto.Name;

            dBContext.SaveChanges();
            return Ok(student);
        }

        [HttpDelete]
        [Route("{id=guid}")]
        public IActionResult DeleteStudent(Guid id) 
        {
            var student = dBContext.Students.Find(id);
            if (student is null)
            {
                return NotFound("Student not exists with provided id: " + id);
            }

            dBContext.Students.Remove(student);
            dBContext.SaveChanges();

            return NoContent();
        }
    }
}
