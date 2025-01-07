List<Student> students = new List<Student>
{
    new Student { Id = 1, Name = "Alice", DateOfBirth = new DateTime(2000, 5, 15) },
    new Student { Id = 2, Name = "Bob", DateOfBirth = new DateTime(1999, 8, 25) },
    new Student { Id = 3, Name = "Charlie", DateOfBirth = new DateTime(2001, 3, 10) }
};


List<Course> courses = new List<Course>
{
    new Course { Id = 101, Title = "Mathematics", Credits = 4 },
    new Course { Id = 102, Title = "Computer Science", Credits = 3 },
    new Course { Id = 103, Title = "Physics", Credits = 4 }
};


List<Enrollment> enrollments = new List<Enrollment>
{
    new Enrollment { Id = 1, StudentId = 1, CourseId = 101, EnrollmentDate = new DateTime(2023, 1, 15) },
    new Enrollment { Id = 2, StudentId = 1, CourseId = 102, EnrollmentDate = new DateTime(2023, 1, 20) },
    new Enrollment { Id = 3, StudentId = 2, CourseId = 101, EnrollmentDate = new DateTime(2023, 1, 18) },
    new Enrollment { Id = 4, StudentId = 3, CourseId = 103, EnrollmentDate = new DateTime(2023, 1, 22) },
    new Enrollment { Id = 5, StudentId = 3, CourseId = 101, EnrollmentDate = new DateTime(2023, 1, 25) },
    new Enrollment { Id = 6, StudentId = 3, CourseId = 102, EnrollmentDate = new DateTime(2023, 1, 30) }
};

//task1
// var task1Method = students.Join(enrollments.Join(courses.Where(c=>c.Title=="Mathematics"),e=>e.CourseId,c=>c.Id, (e, c) =>e), s => s.Id, e => e.StudentId, (s, e) => s).ToList();
// foreach (var item in task1Method)
// {
//     Console.WriteLine(item.Name);
// }
//task2
// var task2Method = courses.Join(enrollments.Join(students.Where(s=>s.Name=="Charlie"),e=>e.StudentId,s=>s.Id,(e,s)=>e),c=>c.Id,e=>e.CourseId,(c,e)=>c).ToList();
// foreach (var item in task2Method)
// {
//     Console.WriteLine(item.Title);
// }
//task3
// var task3Method = students.Join(enrollments, s => s.Id, e => e.StudentId, (s, e) => s)
//     .Where(s => enrollments.Count(e => e.StudentId == s.Id) > 1)
//     .GroupBy(s => s)
//     .SelectMany(s => s).ToList();
// foreach (var item in task3Method)
// {
//     Console.WriteLine(item.Name+" "+item.Id);
// }
//task4
// task5
// var task5Method = students.Join(enrollments.Join(courses, e => e.CourseId, c => c.Id, (e, c) => new
//         {
//             StudentId=e.StudentId,
//             CourseTitle = c.Title, 
//             Credits = c.Credits, 
//             EnrollmentDate = e.EnrollmentDate 
//         }).ToList(),
//         s => s.Id, e => e.StudentId, (s, e) => new
//         {
//             StudentName = s.Name, 
//             CourseTitle = e.CourseTitle, 
//             Credits = e.Credits, 
//             EnrollmentDate = e.EnrollmentDate
//         })
//     .Where(s=>s.EnrollmentDate>=new DateTime(2020,01,01) && s.Credits>2).ToList();
// foreach (var item in task5Method)
// {
//     Console.WriteLine(item.StudentName+" "+item.EnrollmentDate+" "+item.Credits);
// }
//6
// var task6Method = enrollments
//      .Join(students, 
//            enrollment => enrollment.StudentId, 
//            student => student.Id, 
//            (enrollment, student) => new { enrollment, student })
//      .Join(courses, 
//            combined => combined.enrollment.CourseId, 
//            course => course.Id, 
//            (combined, course) => new 
//            { 
//                StudentName = combined.student.Name, 
//                Credits = course.Credits 
//            })
//      .GroupBy(data => data.StudentName)
//      .Select(group => new
//      {
//          StudentName = group.Key,
//          TotalCredits = group.Sum(data => data.Credits)
//      });
//
// foreach (var item in task6Method)
// {
//     Console.WriteLine(item.TotalCredits);
// }
//task7
// var task7Method = courses.Join(enrollments, c => c.Id, e => e.CourseId, (c, e) => new { c, e }).Join(students,
//         e => e.e.StudentId, s => s.Id,
//         (e, s) => new
//         {
//             CourseTitle = e.c.Title,
//             StudentName = s.Name
//         })
//     .GroupBy(e => e.CourseTitle)
//     .Select(e => new
//     {
//         CourseTitle = e.Key,
//         CountOfStudent =e.Count() 
//     }).ToList();
// foreach (var item in task7Method)
// {
//     Console.WriteLine(item.CourseTitle+" "+item.CountOfStudent);
// }
//task8
var task8Method = courses.Join(enrollments, c => c.Id, e => e.CourseId, (c, e) => new { c, e })
    .Join(students, e => e.e.StudentId, s => s.Id, (e, s) => new
    {
        CourseTitle = e.c.Title,
        StudentName = s.Name
    }).Where(e => e.StudentName != "Bob").GroupBy(e=>e.CourseTitle).Select(e=>e.Key).ToList();
foreach (var item in task8Method)
{
    Console.WriteLine(item);
}
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
}

class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Credits { get; set; }
}

class Enrollment
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime EnrollmentDate { get; set; }

}
 