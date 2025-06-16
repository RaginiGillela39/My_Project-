// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public class MySingletonClass
{
    //ReadOnly: Prevents _instance from being reassigned after it is has been intialized.
    //Static Feild: it belongs to the class itself, not to any object of the class.
    //This makes it globally accessible.

    private static readonly Lazy<MySingletonClass> _instance =
        new Lazy<MySingletonClass>(() => new MySingletonClass());

    // Private constructor prevents direct instantiation.
    //which no external code can directly create an instance of MySingletonClass
    //using new keyword
    private MySingletonClass()
    {
    }

    public static MySingletonClass Instance
    {
        get { return _instance.Value; } 

   //- The first time Instance is accessed, _instance.Value initializes the Singleton instance
  //    using the lambda function () => new MySingletonClass().
 //-Subsequent calls to Instance simply return the already-created instance stored in _instance.Value.
//- Since the constructor of MySingletonClass is private, no other code can create a second instance.
    }

// Add any necessary methods or properties here.
public string GetMessage() => "Hello from the Singleton!";
}