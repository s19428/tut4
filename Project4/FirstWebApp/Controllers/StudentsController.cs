using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebApp.DAL;

namespace FirstWebApp.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        /*
        [HttpGet]
        public string GetStudent()
        {
            return "Student1, Student2, Student3";
        }
        */

        /*
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id == 1)
            {
                return Ok("Student1");
            }
            else if (id == 2)
            {
                return Ok("Student2");
            }

            return NotFound("Student not found");
        }
        */

        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            //return $"Student1, Student2, Student3 orderBy = {orderBy}";
            return Ok(_dbService.GetStudents());
        }

        [HttpPost]
        public IActionResult CreteStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(0, 20000)}";
            return Ok(student);
        }

        [HttpPut]
        public IActionResult PutStudent(int id)
        {
            Student s = new Student();
            s.StudentID = id;
            //.......... Perform update of sth

            return Ok($"UpdateCompleted {id}");
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            // ............. delete student with wtis id

            return Ok($"Student deleted {id}");
        }
    }
}