//var StuList = Student.GetStudents().Select(x => new Student()
//{
//    Name = x.Name,
//    Branch = x.Branch,
//}).ToList();

//foreach (var item in Student.GetStudents())
//{
//    Console.WriteLine("name is " + item.Name);
//    Console.WriteLine("Branch is " + item.Branch);
//    Console.WriteLine("Sem is " + item.Sem);
//    Console.WriteLine("CPI is " + item.CPI);
//    Console.Write("language is ");

//    foreach (var i in item.progLanguage)
//    {
//        Console.Write(i + ", ");
//    }
//    Console.WriteLine("\n");
//}

//public class Student
//{
//    public int Rno { get; set; }
//    public string Name { get; set; }
//    public string Branch { get; set; }
//    public List<string> progLanguage { get; set; }
//    public int Sem { get; set; }
//    public double CPI { get; set; }

//    public static List<Student> GetStudents()
//    {
//        List<Student> student = new List<Student>
//        {
//            new Student { Rno = 1,Name="sachin",Branch="CE",Sem=6,CPI=9,progLanguage=new List<string>(){"JAVA","C"} },
//            new Student { Rno = 2,Name="mehul",Branch="CE",Sem=6,CPI=9.1,progLanguage=new List<string>(){"JAVA","C#"}},
//            new Student { Rno = 3,Name="krish",Branch="CE",Sem=6,CPI=9.2,progLanguage=new List<string>(){"JAVA","C++"}},
//            new Student { Rno = 4,Name="sandi",Branch="CE",Sem=6,CPI=9.3,progLanguage=new List<string>(){"C","java"}},
//        };

//        return student;
//    }
//}

//var empList = Employee.GetEmp().Select(x => new Employee()
//{
//    EmpID = x.EmpID,
//    Name = x.Name,
//    Age = x.Age,
//    Email = x.Email,
//    Gender = x.Gender,
//    Salary = x.Salary,
//}).Where(s => s.Gender == "Male").ToList();

//var empList = Employee.GetEmp().Select(x => new Employee()
//{
//    EmpID = x.EmpID,
//    Name = x.Name,
//    Age = x.Age,
//    Email = x.Email,
//    Gender = x.Gender,
//    Salary = x.Salary,
//}).Where(s => s.Age > 25 && s.Age < 30).ToList();

//var empList = Employee.GetEmp().Select(x => new Employee()
//{
//    EmpID = x.EmpID,
//    Name = x.Name,
//    Age = x.Age,
//    Email = x.Email,
//    Gender = x.Gender,
//    Salary = x.Salary,
//}).Where(s => s.EmpID > 1 && s.EmpID< 10).ToList();


//var empList = Employee.GetEmp().Select(x => new Employee()
//{
//    EmpID = x.EmpID,
//    Name = x.Name,
//    Age = x.Age,
//    Email = x.Email,
//    Gender = x.Gender,
//    Salary = x.Salary,
//}).Where(s => s.Name == "sachin" && s.Name=="mehul").ToList();


//var empList = Employee.GetEmp().Select(x => new Employee()
//{
//    EmpID = x.EmpID,
//    Name = x.Name,
//    Age = x.Age,
//    Email = x.Email,
//    Gender = x.Gender,
//    Salary = x.Salary,
//}).Where(s => s.Age>30).ToList();


//var empList = Employee.GetEmp().Select(x => new Employee()
//{
//    EmpID = x.EmpID,
//    Name = x.Name,
//    Age = x.Age,
//    Email = x.Email,
//    Gender = x.Gender,
//    Salary = x.Salary,
//}).Where(s => s.Name.StartsWith("s")).ToList();


//var empList = Employee.GetEmp().Select(x => new Employee()
//{
//    EmpID = x.EmpID,
//    Name = x.Name,
//    Age = x.Age,
//    Email = x.Email,
//    Gender = x.Gender,
//    Salary = x.Salary,
//}).Where(s => s.Email.Contains("xyz")).ToList();


//var empList = Employee.GetEmp().Select(x => new Employee()
//{
//    EmpID = x.EmpID,
//    Name = x.Name,
//    Age = x.Age,
//    Email = x.Email,
//    Gender = x.Gender,
//    Salary = x.Salary,
//}).Where(s => s.Name.Contains("sachin")).ToList();


//var empList = Employee.GetEmp().Select(x => new Employee()
//{
//    EmpID = x.EmpID,
//    Name = x.Name,
//    Age = x.Age,
//    Email = x.Email,
//    Gender = x.Gender,
//    Salary = x.Salary,
//}).Where(s => s.Name.Contains("me")).ToList();


var empList = Employee.GetEmp().Select(x => new Employee()
{
    EmpID = x.EmpID,
    Name = x.Name,
    Age = x.Age,
    Email = x.Email,
    Gender = x.Gender,
    Salary = x.Salary,
}).Where(s => s.Age == 20 || s.Age == 30 || s.Age == 35).ToList();


foreach (var item in empList)
{
    Console.WriteLine("EmpID is " + item.EmpID);
    Console.WriteLine("name is " + item.Name);
    Console.WriteLine("Age is " + item.Age);
    Console.WriteLine("Email is " + item.Email);
    Console.WriteLine("Gender is " + item.Gender);
    Console.WriteLine("Salary is " + item.Salary);
    Console.WriteLine("\n");
}

public class Employee
{
    public int EmpID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    //    public list<string> proglanguage { get; set; }
    public String Email { get; set; }
    public String Gender { get; set; }
    public double Salary { get; set; }

    public static List<Employee> GetEmp()
    {
        List<Employee> emp = new List<Employee>
        {
            new Employee { EmpID = 1,Name="sachin",Age=20,Email="xyz@gmail.com",Gender="Male",Salary=1000},
            new Employee { EmpID = 2,Name="mehul" ,Age=20,Email="xyz@gmail.com",Gender="Male",Salary=1000 },
            new Employee { EmpID = 3,Name="krish" ,Age=20,Email="xyz@gmail.com",Gender="Male",Salary=1000 },
            new Employee { EmpID = 4,Name="sandi" ,Age=20,Email="xyz@gmail.com",Gender="Male",Salary=1000},
        };

        return emp;
    }
}