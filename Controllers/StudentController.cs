using BisniessLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_API.Controllers
{
    [Route("api/[controller]")] // prefiks putanje za ceo kontroler (sve metode), gde je [controller] tzv. Route token, koji uzima za vrednost naziv klase gde je ruta definisana
    [ApiController]

    public class StudentController : ControllerBase
    {
        private IStudentBusiness studentBusiness;

        public StudentController(IStudentBusiness studentBusiness)
        {
            this.studentBusiness = studentBusiness;
            this.studentBusiness.GetConnectionString(Startup.ConnectionString);
        }

        // metoda koja vraća listu svih studenata
        // GET: api/student
        [HttpGet]
        public List<Student> GetAllStudents()
        {
            return this.studentBusiness.GetAllStudents();
        }

        // GET: api/student/5
        [HttpGet("{id}")]
        public Student GetById(int id)
        {
            return this.studentBusiness.GetStudentById(id);
        }

        // metoda koja vrši unos jednog studenta, vraća broj redova koji je izmenjen
        // POST: api/student/insert

        [Route("insert")]
        [HttpPost]
        public bool InsertStudent([FromBody] Student s)
        {
            return this.studentBusiness.InsertStudent(s);
        }

        // metoda koja vrši unos liste studenata
        // POST: api/student/insert-list

        [Route("insert-list")]
        [HttpPost]
        public bool InsertStudents([FromBody] List<Student> students)
        {
            return this.studentBusiness.InsertListOfStudents(students);
        }

        // metoda koja vrši izmenu studenta
        // PUT: api/student/update
        [Route("update")]
        [HttpPut]
        public bool UpdateStudent([FromBody] Student s)
        {
            return this.studentBusiness.UpdateStudent(s);
        }


        // DELETE: api/student/5
        [HttpDelete("{id}")]
        public bool DeleteStudent(int id)
        {
            return this.studentBusiness.DeleteStudent(id);
        }



    }
}
