using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Models;

namespace StudentInformationSystem.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>();
        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.StudentId = students.Count + 1;
                students.Add(student);
                return RedirectToAction("Create");
            }
            return View(students);
        }

        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id);
            if (student == null)
                return NotFound();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.StudentId)
                return NotFound();
            if (ModelState.IsValid)
            {
                var existingStudent = students.FirstOrDefault(s => s.StudentId == id);
                if (existingStudent == null)
                    return NotFound();

                existingStudent.FirstName = student.FirstName;
                existingStudent.MiddleName = student.MiddleName;
                existingStudent.LastName = student.LastName;
                existingStudent.YearLevel = student.YearLevel;
                existingStudent.Course = student.Course;
                existingStudent.DateOfBirth = student.DateOfBirth;

                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentId ==id);
            if (student == null)
                return NotFound();
            return View(student);
        }

        [HttpPost,  ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentId==id);
            if(student != null)
            {
                students.Remove(student);
            }
            return RedirectToAction("Index");
        }
    }
}
