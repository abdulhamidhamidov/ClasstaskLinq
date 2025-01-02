var employees = new List<Employee>()
{
   new Employee(1,"Muhammad","Safarov",17,1,12),
   new Employee(2,"Husain","Dilbarshozoda",14,50000,100),
   new Employee(1,"Said","Boboev",20,200000,150),
   new Employee(1,"Dilshod","Abdusalomov",24,10000000,200)
};

////////////////1///////////////////
// var salaries = employees.Select(x=>x.Salary);
var salaries = from e in employees
    select e.Salary;
foreach (var item in salaries)
{
    Console.WriteLine(item);
}

//2
//var emploeeswhichnamehassixlaters = employees.Where(x => x.FirstName.Length > 6);
var emploeeswhichnamehassixlaters = from e in employees
               where e.FirstName.Length>6
                   select e;
foreach (var item in emploeeswhichnamehassixlaters)
{
    Console.WriteLine(item);
}

//3

//var fullname = employees.Where(x => x.Age > employees[0].Age)
  // .Select(x => x.FirstName + " " + x.LastName);


var fullnames = from e in employees
        where e.Age>employees[0].Age
            select e.FirstName+" "+e.LastName;
foreach (var item in fullnames)
{
    Console.WriteLine(item);
}
//4

// var employeesAgeExperience = employees.Where(x=>x.Age/2>x.Experience);
var employeesAgeExperience = from e in employees
        where e.Age/2>e.Experience 
            select e;
//5
// var treeEmployee = employees.Where(x=>x.Salary>5000).OrderBy(x => x.Experience).Take(3);
var treeEmployee = (from e in employees
    where e.Salary>5000
    orderby e.Experience
    select e).Take(3);
foreach (var item in treeEmployee)
{
    Console.WriteLine(item);
}
//
class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public decimal Salary { get; set; }
    public int Experience { get; set; }
    // Id (int)
    // FirstName (string)
    // LastName (string)
    // Age (int)
    // Salary (decimal)
    // Experience (int)
    public Employee(int id, string firstName, string lastName, int age, decimal salary, int experience)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Salary = salary;
        Experience = experience;
    }
}