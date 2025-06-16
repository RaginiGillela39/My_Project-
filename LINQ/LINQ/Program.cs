//var names = new List<int> { 45, 55, 65, 75, 85 };
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;

List<int> scores = [95, 105, 65, 75, 85];
//LINQ query Expression
IEnumerable<int> scoreQuery= from score in scores where score > 80 orderby score descending select score;
foreach (int score in scoreQuery) Console.WriteLine($"Found a score over 80 {score}");
//instead of foreach
IEnumerable<string> scoreQuery2 = from score in scores where score > 80 orderby score descending select $"Found a score over 80 {score}";
//for (int i = 0; i < scores.Count; i++)
//{
//    if (scores[i] > 80)
//    {
//        Console.WriteLine($"Found a score over 80 {scores[i]}");
//    }
//}

// LINQ..
//Methos syntax
IEnumerable<int> highScores = scores.Where(score => score > 80).OrderByDescending(s=>s);

foreach (var score in highScores)
{
    Console.WriteLine($"Found a score over 80 {score}");
}

//String..
string s1 = "firstFriend";
string s2 = "secondFriend";
Console.WriteLine($"string concatenation {s1.Trim()} and {s2.Trim()}");
string s3 = $"string concatenation {s1.Trim()} and {s2.Trim()}";
Console.WriteLine(s3.Replace("firstFriend", "thirdFriend"));
Console.WriteLine(s3.Contains("secondFriend"));

//integer..
int a = 2100000000;
int b = 2100000000;
long c = (long)a + b;
//long d = checked(a + b);
Console.WriteLine(c);
//double & float
double e = 43.2;
float f = 32.1f;
double g= e+f;
Console.WriteLine(g);
//decimal
decimal h = 43.2M;
decimal i = 32.1M;
decimal j = h + i;
Console.WriteLine(j);

//If statements
int sum = 5+8;
bool cond = sum > 10;
//if ((a + b) > 10)
if (cond)
    Console.WriteLine("If Statement, The answer is greater than 10");
//while loop
int counter = 0;
while (counter < 3)
{
    Console.WriteLine(counter);
    counter++;
}
//do while
int counter1 = 0;
do
{
    Console.WriteLine(counter1);
    counter1++;
}
while (counter1 < 3);

//var -- is local variable type inferences
//List size is dynamic, by default use list 
var names = new List<string> { "apple", "banana", "mango" };
names.Add("strawberry");
for (int k = 0; k < names.Count; k++)
{
    Console.WriteLine($"List of the fruits {names[k].ToUpper()}");
}

foreach (var name in names) Console.WriteLine($"List of the fruits {name.ToLower()}");

//array size is fixed, used in case of fixed memory.
var array1 =new  string[] {"test1","test2","test3"};
array1 = [..array1,"test4"];
foreach (var name in array1) Console.WriteLine($"List of the array {name.ToLower()}");
//Both array & list can be indexing, search, sort and use foreach but can be used incase of 
//fixed memory..

//OOPs 

Console.WriteLine("C# with OOPs Concepts");
var p1 = new Person("testF1", "test1", "test1");
var p2 = new Person("second1", "seocn23", "sfer34");

List<Person> people= [p1,p2];

p1.Pets.Add(new Dog("teddy"));
p1.Pets.Add(new Cat("Moejgjhgh"));

p2.Pets.Add(new Dog("mdfdfgf"));
p2.Pets.Add(new Cat("yiuyiuo"));


Console.WriteLine($"Count of the people {people.Count}");

foreach (var person in people)
{
    Console.WriteLine($"{person.ToString()}");
    foreach(var pet in person.Pets) Console.WriteLine($"        {pet.ToString()}");
}
public class Person(string firstName,string lastName,string name)
{
    private  string First { get; set; } = firstName;
    private  string Last { get; set; }= lastName;
    private string Name { get; set; }= name;
    
    public List<Pet> Pets { get; } = new ();

    public override string ToString()
    {
        return $"Person: {First} {Last}";
    }
}


//Base & Derived Classes

public abstract class Pet(string firstName)
{
    public string FirstName { get; set; }= firstName;
    public abstract string MakeNoise();

    public override string ToString()
    {
        return $"Pet: {FirstName} I am a {GetType().Name} I can make {MakeNoise()}";
    }
}

public class Cat(string firstName):Pet(firstName)
{
    public string FirstNmae { get; set; } = firstName;
    public override string MakeNoise() => "Meow..";
}

public class Dog(string firstName) : Pet(firstName)
{
    public string FirstNmae { get; set; } = firstName;
    public override string MakeNoise() => "Bark..";
}

