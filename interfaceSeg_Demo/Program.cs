// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
IPrinter printer = new Printer();
printer.Print();
IScanner scanner = new Scanner();
scanner.Scan();
IFax fax = new Fax();
fax.Fax();
Multifunction multifunction=new Multifunction();
multifunction.Fax();
multifunction.Print();
multifunction.Scan();

//By default, the methods in an interface are abstract and public.
//This means they do not have any implementation and must be implemented by any class that inherits the interface.
//Additionally, they are implicitly public, so you do not need to specify the access modifier.
public interface IPrinter
{
    void Print();
}

public interface IScanner
{
    void Scan();
}

public interface IFax
{
    void Fax();
}

public class Multifunction : IPrinter, IScanner, IFax
{
    public void Fax()
    {
        Console.WriteLine("Fax from Multifunction");
    }

    public void Print()
    {
        Console.WriteLine("Print from Multifunction");
    }

    public void Scan()
    {
        Console.WriteLine("Scan from Multifunction");
    }
}
public class Scanner : IScanner
{
    public void Scan()
    {
        Console.WriteLine("Scan from Scanner");
    }
}

public class Printer : IPrinter
{
    public void Print()
    {
        Console.WriteLine("Print from Printer");
    }
}

public class Fax : IFax
{
    void IFax.Fax()
    {
        Console.WriteLine("Fax from Fax");
    }
}
