public class Program()
{
    public static void Main(string[] args)
    {
        //Console.WriteLine("Enter a word to check if it is a palindrome");
        //string? word=Console.ReadLine();
        //if(word != null)
        //    Checkpalindrome(word);
       
        

        Console.WriteLine("Enter factorial number");
        int n = int.Parse(Console.ReadLine());

        // Ensure n is not 0 before proceeding
        if (n != 0)
        {
            int x = factorial(n);  // Correct way to declare within the if block
            Console.WriteLine($"Factorial of {n} is {x}");
        }
        else
        {
            Console.WriteLine("Please enter a non-zero number for factorial calculation.");
        }
    }
    public static void Checkpalindrome(string palindrome)
    {
        string? reverse = palindrome.Trim().ToLower().Reverse().ToString();
        if (reverse == palindrome.Trim().ToLower())
            Console.WriteLine("This is a palindrome");
        else
            Console.WriteLine("This is not a palindrome");
    }

    public static int factorial(int n)
    {
        if (n == 0)
            return 1;
        else
            return n * factorial(n - 1);
    }

}

