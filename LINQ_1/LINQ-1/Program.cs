using LINQ_1;


// Create a data source by using a collection initializer.
IEnumerable<Student> students =
[
    new Student(First: "Svetlana", Last: "Omelchenko", ID: 111, Scores: [97, 92, 81, 60]),
    new Student(First: "Claire",   Last: "O'Donnell",  ID: 112, Scores: [75, 84, 91, 39]),
    new Student(First: "Sven",     Last: "Mortensen",  ID: 113, Scores: [88, 94, 65, 91]),
    new Student(First: "Cesar",    Last: "Garcia",     ID: 114, Scores: [97, 89, 85, 82]),
    new Student(First: "Debra",    Last: "Garcia",     ID: 115, Scores: [35, 72, 91, 70]),
    new Student(First: "Fadi",     Last: "Fakhouri",   ID: 116, Scores: [99, 86, 90, 94]),
    new Student(First: "Hanying",  Last: "Feng",       ID: 117, Scores: [93, 92, 80, 87]),
    new Student(First: "Hugo",     Last: "Garcia",     ID: 118, Scores: [92, 90, 83, 78]),

    new Student("Lance",   "Tucker",      119, [68, 79, 88, 92]),
    new Student("Terry",   "Adams",       120, [99, 82, 81, 79]),
    new Student("Eugene",  "Zabokritski", 121, [96, 85, 91, 60]),
    new Student("Michael", "Tucker",      122, [94, 92, 91, 91])
];




//Create the query
IEnumerable<Student> studentsQuery=from  Student in students
                                   where Student.Scores[0]>90 && Student.Scores[3]<80
                                   orderby Student.Last ascending
                                   orderby Student.Scores[0] descending
                                   select Student;
//Run the query
foreach(Student student in studentsQuery)
{
    Console.WriteLine($"Student scored more than 90: Name: {student.Last}  {student.First} Score: {student.Scores[0]} ");
}

//Group
IEnumerable<IGrouping<char, Student>> studentQuery =
    from student in students
    group student by student.Last[0];

foreach(IGrouping<char, Student> studentgrp in studentQuery)
{
    Console.WriteLine($"Student Name First Letter:{studentgrp.Key}");
    foreach (Student student in studentgrp)
    {
        Console.WriteLine($"Student: Name: {student.Last}  {student.First} ");
    }
}

//Using implicity type 

var studentQueryGr=from student in students
                   group student by student.Last[0] into studentgrp
                   orderby studentgrp.Key
                   select studentgrp;
foreach(var item in studentQueryGr)
{
    Console.WriteLine($"{item.Key}");
    foreach (Student student in item)
    {
        Console.WriteLine($"Student: Name: {student.Last}  {student.First} ");
    }
}

// This query returns those students whose
// first test score was higher than their
// average score.
var studentQuery5 =
    from student in students
    let totalScore = student.Scores[0] + student.Scores[1] +
        student.Scores[2] + student.Scores[3]
    where totalScore / 4 < student.Scores[0]
    select $"{student.Last}, {student.First} total score{totalScore}";

foreach (string s in studentQuery5)
{
    Console.WriteLine(s);
}

    



