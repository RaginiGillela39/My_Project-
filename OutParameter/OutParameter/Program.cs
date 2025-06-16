using OutParameter;

Console.WriteLine("Hello, World!");

/*OUT-Paramters C# provides out keyword to pass arguments as out-type. It is like reference-type,
 * except that it does not require variable to initialize before passing. 
 * We must use out keyword to pass argument as out-type. 
 * It is useful when we want a function to return multiple values.*/



//int val = 50;
OutP outP = new OutP(); // Creating Object  
//Console.WriteLine("Value before passing out variable " + val);//50
//outP.Show(out val); // Passing out argument  //100
//Console.WriteLine("Value after recieving the out variable " + val);//100
//int x=5;
//Console.WriteLine($"Factorial of n is {outP.fact(x)}");
Console.WriteLine($"Division is {outP.divide()}");

    static void ModifyValue(ref int number)
    {
        number *= 2; // Modify the original value
    }

    static void Main()
    {
        int value = 10;
        Console.WriteLine($"Before: {value}");

        ModifyValue(ref value);

        Console.WriteLine($"After: {value}");
    }
