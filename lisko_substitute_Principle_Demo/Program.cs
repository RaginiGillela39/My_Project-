// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
Bird bird = new Penguin();
bird.Move();

//No, you cannot use abstract and virtual together on the same method in C#. Here’s why:
//Abstract Methods: These are declared in an abstract class and do not have an implementation.
//They must be overridden in derived classes.
//Virtual Methods: These have an implementation in the base class but can be overridden in derived classes.
//Yes, we can inheritant abstract class.

public abstract class Bird
{
    public abstract void Move();
}
public class Sparrow : Bird
{
    public override void Move()
    {
        Console.WriteLine("Sparrow can fly");
    }
}
public class Penguin : Bird
{
    public override void Move()
    {
        Console.WriteLine("Penguin can Swim");
    }
}
