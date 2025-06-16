using LINQ_2;
using System.Diagnostics.Metrics;

public enum GradeLevel
{
    FirstYear = 1,
    SecondYear,
    ThirdYear,
    FourthYear
}

public class Student
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    //By default, a string is not nullable(it can never be null), but by adding?, 
    //it explicitly allows the property to be set to null.
    public int ID { get; set; }
    public GradeLevel Year { get; set; }
    public List<int> Scores { get; set; }=default!;
    //default is a keyword that represents the default value for the type. For a List<int>, the default value
    //would be null. However, the ! at the end is a null-forgiving operator,
    //which is used to tell the compiler "I know this could be null, but I'm confident it won't be null here."
    public int DepartmentID { get; set; }
}

public class Teacher
{
    public string? First { get; set; }
    public string? Last { get; set; }
    public int ID { get; set; }
    public string? City { get; set; }
}

public class Department
{
    public string? Name { get; set; }
    public int? Id { get; set; }
    public int TeacherId { get; set; }
}

public class Customer
{
    public int CustomerID { get; set; }
    public string CustomerName { get; set; }
}

public class Order
{
    public int OrderID { get; set; }
    public int CustomerID { get; set; }
    public int OrderAmount { get; set; }
}
public class Program
{
    public static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student
            {
                FirstName = "John",
                LastName = "Doe",
                ID = 1,
                Year = GradeLevel.FirstYear,
                Scores = new List<int> { 85, 90, 78 },
                DepartmentID = 1
            },
            new Student
            {
                FirstName = "Jane",
                LastName = "Smith",
                ID = 2,
                Year = GradeLevel.SecondYear,
                Scores = new List<int> { 88, 92, 81 },
                DepartmentID = 2
            }
        };

        List<Teacher> teacher = new List<Teacher>
        {
            new Teacher { First = "James", Last = "Smith", ID = 1, City = "Chicago" },
            new Teacher { First = "Mary", Last = "Jones", ID = 2, City = "New York" }
        };

        List<Department> departments = new List<Department>
        {
            new Department { Id = 1, Name = "Computer Science", TeacherId = 1 },
            new Department { Id = 2, Name = "Mathematics", TeacherId = 2 },
             new Department { Id = 1, Name = "English", TeacherId = 1 },
            new Department { Id = 3, Name = "Telugu", TeacherId = 2 }
        };
        var newList = departments.ToDictionary(a => a.Id);


        var query = students.Join(departments,
                                  student => student.DepartmentID,
                                  department => department.Id,
                                  (student, department) => new { student.FirstName, student.LastName, Department = department.Name });

        foreach (var item in query)
        {
            Console.WriteLine($"Student: {item.FirstName} {item.LastName} - {item.Department}");
        }

        var query2 = teacher.Join(departments,
                                  teacher => teacher.ID,
                                  department => department.TeacherId,
                                  (teacher, department) => new { teacher.First, teacher.Last, Department = department.Name });
        foreach (var item in query2)
        {
            Console.WriteLine($"Teacher: {item.First} {item.Last} - {item.Department}");
        }

        //left join
        var query3 =
        from student in students
        join department in departments on student.DepartmentID equals department.Id into gj
        from subgroup in gj.DefaultIfEmpty()
        select new
        {
            student.FirstName,
            student.LastName,
            Department = subgroup?.Name ?? string.Empty
        };

        foreach (var v in query3)
        {
            Console.WriteLine($"Left join: {v.FirstName:-15} {v.LastName:-15}: {v.Department}");
        }

        //left join method syntax

        var query4 = students
        .GroupJoin(
            departments,
            student => student.DepartmentID,
            department => department.Id,
            (student, departmentList) => new { student, subgroup = departmentList })
        .SelectMany(
            joinedSet => joinedSet.subgroup.DefaultIfEmpty(),
            (student, department) => new
            {
                student.student.FirstName,
                student.student.LastName,
                Department = department.Name ?? string.Empty
            });

        foreach (var v in query4)
        {
            Console.WriteLine($"{v.FirstName:-15} {v.LastName:-15}: {v.Department}");
        }

        //multiple join 
        var query5 = students
    .Join(departments, student => student.DepartmentID, department => department.Id,
        (student, department) => new { student, department })
    .Join(teacher, commonDepartment => commonDepartment.department.TeacherId, teacher => teacher.ID,
        (commonDepartment, teacher) => new
        {
            StudentName = $"{commonDepartment.student.FirstName} {commonDepartment.student.LastName}",
            DepartmentName = commonDepartment.department.Name,
            TeacherName = $"{teacher.First} {teacher.Last}"
        });

        foreach (var obj in query5)
        {
            Console.WriteLine($"""The student "{obj.StudentName}" studies in the department run by "{obj.DepartmentName}". Teacher Name{obj.TeacherName}""");
        }
        //Multiple join query syntax
        //Method syntax......
        var query7 = students.Join(departments,
           student => student.DepartmentID, department => department.Id,
           (student, department) => new
           {
               student,
               department
           })
          .Join(teacher, commonDeprt => commonDeprt.department.TeacherId, teacher => teacher.ID, (commonDeprt, teacher) => new
          {
              StudentName = $"{commonDeprt.student.FirstName} {commonDeprt.student.LastName}",
              DepartmentName = commonDeprt.department.Name,
              TeacherName = $"{teacher.First} {teacher.Last}"
          });
        //Query syntax.....
        var query8 = from Student in students
                     join Department in departments
                     on Student.DepartmentID equals Department.Id
                     join Teacher in teacher
                     on Department.TeacherId equals Teacher.ID
                     select new
                     {
                         StudentName = $"{Student.FirstName} {Student.LastName}",
                         DepartmentName = Department.Name,
                         TeacherName = $"{Teacher.First} {Teacher.Last}"
                     };
        //Composite key join
        //Query syntax
        var query9 = from student in students
                     join Teacher in teacher
                    on new
                    {
                        student.FirstName,
                        student.LastName,

                    } equals new
                    {
                        FirstName = Teacher.First,
                        LastName = Teacher.Last
                    }
                     select new
                     {
                         StudentName = $"{student.FirstName} {student.LastName}",
                         TeacherName = $"{Teacher.First} {Teacher.Last}"
                     };
        //Method syntax
        var query10 = students.Join(teacher,
            student => new { student.FirstName, student.LastName },
            teacher => new { FirstName = teacher.First, LastName = teacher.Last },
            (student, teacher) => new
            {
                StudentName = $"{student.FirstName} {student.LastName}",
                TeacherName = $"{teacher.First} {teacher.Last}"
            });

        var customers = new List<Customer>
        {
            new Customer { CustomerID = 1, CustomerName = "Alice" },
            new Customer { CustomerID = 2, CustomerName = "Bob" },
            new Customer { CustomerID = 3, CustomerName = "Charlie" }
        };

        var orders = new List<Order>
        {
            new Order { OrderID = 101, CustomerID = 1, OrderAmount = 250 },
            new Order { OrderID = 102, CustomerID = 1, OrderAmount = 450 },
            new Order { OrderID = 103, CustomerID = 2, OrderAmount = 300 },
            new Order { OrderID = 104, CustomerID = 3, OrderAmount = 150 }
        };

        var query12 = from customer in customers
                      join order in orders
                      on customer.CustomerID equals order.CustomerID into orderGroup
                      select new
                      {
                          customer.CustomerName,
                          orderAmount = orderGroup.Sum(o => o.OrderAmount)
                      };


        var query11 = customers.GroupJoin(orders,
            customer => customer.CustomerID,
            order => order.CustomerID,
            (customer, orderGroup) => new
            {
                customer.CustomerName,
                Orders = orderGroup.Sum(o => o.OrderAmount)
            });

        foreach (var item in query11)
        {
            Console.WriteLine($"Customer: {item.CustomerName} - Orders: {item.Orders}");

        }
        //Left join in query syntax

        var query13 = from customer in customers
                      join order in orders
                      on customer.CustomerID equals order.CustomerID into lfcustomer
                      from order in lfcustomer.DefaultIfEmpty(new Order { OrderAmount = 0 })
                      select new
                      {
                          customer.CustomerName,
                          order.OrderAmount
                      };
        Console.WriteLine("Left join in query syntax");
        foreach (var item in query13)
        {

            Console.WriteLine($"Customer: {item.CustomerName} - Orders: {item.OrderAmount}");
        }

        var query14 = from Student in students
                      join Department in departments
                      on Student.DepartmentID equals Department.Id into gj
                      from subgroup in gj.DefaultIfEmpty()
                      select new
                      {
                          Student.FirstName,
                          Student.LastName,
                          Department = subgroup?.Name ?? string.Empty
                      };
        Console.WriteLine("Left join in query syntax Students");
        foreach (var item in query14)
        {
            Console.WriteLine($"Student: {item.FirstName} {item.LastName} - {item.Department}");
        }

        var query15 = students.GroupJoin(departments,
            student => student.DepartmentID,
            department => department.Id,
            (student, departmentList) => new { student, subgroup = departmentList })
            .SelectMany(joinedSet => joinedSet.subgroup.DefaultIfEmpty(),
                (student, department) => new
                {
                    student.student.FirstName,
                    student.student.LastName,
                    Department = department.Name ?? string.Empty
                });

    }
}