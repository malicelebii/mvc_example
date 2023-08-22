using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;



public class StudentController : Controller
{
    public static List<Student> studentList = new List<Student>() {
         new Student { Id = 1, FirstName = "John", LastName = "Doe", Email = "JohnDoe@gmail.com", Age = 22 },
         new Student { Id = 2, FirstName = "Merry", LastName = "Dalton", Email = "JohnDoe@gmail.com",Age = 24 },
         new Student { Id=3,FirstName="Danny",LastName="Rock",Email = "JohnDoe@gmail.com",Age=55}
         };

    public IActionResult List()
    {
        return View(studentList);
    }

    public IActionResult Detail(int id)
    {
        Student student = new Student();
        student = studentList.Find(student => student.Id == id);

        return View(student);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(string firstname, string lastname, string email, int age)
    {
        Student newStudent = new Student() { Id = studentList[studentList.Count - 1].Id + 1, FirstName = firstname, LastName = lastname, Email = email, Age = age };

        studentList.Add(newStudent);

        return View("List", studentList);
    }

    public IActionResult Edit(int id)
    {
        Student student = studentList.Find(student => student.Id == id);
        return View(student);
    }

    [HttpPost]
    public IActionResult Edit(int id, string firstname, string lastname, string email, int age)
    {
        var student = from stu in studentList
                      where stu.Id == id
                      select stu;

        Student newStudent = student.ToList()[0];

        newStudent.Id = id;
        newStudent.FirstName = firstname;
        newStudent.LastName = lastname;
        newStudent.Email = email;
        newStudent.Age = age;


        return View("Detail", newStudent);
    }

    public IActionResult Delete(int id)
    {
        Student student = studentList.Find(student => student.Id == id);

        studentList.Remove(student);

        return RedirectToAction("List", studentList);
    }

}