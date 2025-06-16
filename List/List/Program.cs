using System.Net.NetworkInformation;

class Program
{
    static void Main()
    {
        List<int> num = new List<int> { 1, 2, 3, 4, 5 };

        //A Func delegate represents a method that returns a value.It's often used in LINQ queries 
        //for projections and filtering.

        Func<int, bool> isEven = x => x % 2 == 0;

        Func<int, bool> isOdd = y=> y % 3== 0;

        List<int> evenNumber = num.Where(isEven).ToList();
        foreach (var item in evenNumber)
        {
            Console.WriteLine($"Data from List: {item}");
        }
        List<int> primeNUmber = num.Where(isOdd).ToList();
        foreach (var item in primeNUmber)
        {
            Console.WriteLine($"Data from List: {item}");
        }

        //A Predicate delegate represents a method that defines a set of criteria and determines whether the specified 
        //object meets those criteria.It's similar to Func, but specifically returns a bool.
        Predicate<int> IsGreaterthan3 = x => x >3;
        evenNumber = num.FindAll(IsGreaterthan3);

        Console.WriteLine("NUmber greater than 3");
        foreach (var item in evenNumber)
        {
            Console.WriteLine($"Data from List: {item}");
        }

        //An Action delegate represents a method that performs an action but does not return a value.
        //It's often used for operations like printing or modifying elements.
        // Using Action to define an operation
        Action<int> printNumber = x => Console.WriteLine($"Number: {x}");

        // LINQ query with Action
        num.ForEach(printNumber);
    }

}