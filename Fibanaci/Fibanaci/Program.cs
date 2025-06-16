public class Progarm
{
    public static void Main()
    {
        //Console.Write("Please enter the number: ");
        //int n = int.Parse(Console.ReadLine());

        //// Call the Fibonacci function and display the result
        //int result = FibSeries(n);
        //Console.WriteLine($"Fibonacci number at position {n} is: {result}");
        int num=20;
        string text="test";
        Console.WriteLine($"Number: {num}, Text: {text}");
        GetValue(out num, out text);
        int number = 10;
        string text1 = "Hello, World!";
        Console.WriteLine($"Number: {number}, Text: {text1}");
        ModifyValues(ref number, ref text1);
        
    }
    public static int FibSeries(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
      return FibSeries(n - 1) + FibSeries(n - 2);
    }

    public static void GetValue(out int x, out string y)
    {
        x = 10;
        y = "Hello";
        Console.WriteLine($"Number: {x}, Text: {y}");
    }
                     
  public static void ModifyValues(ref int number, ref string text)
    {
        number = 20;
        text = "Modified!";
        Console.WriteLine($"Number: {number}, Text: {text}");
    }
}

