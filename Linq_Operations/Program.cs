// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int[] ary1 = { 1, 2, 4, 6 };
int[] ary2 = { 1, 3, 4, 5 };

int[] res = ary1.Intersect(ary2).ToArray();
Console.WriteLine("Common Elements in the List");
foreach (var item in res)
{
    Console.WriteLine(item);
}

int[] res1=ary1.Where(x=>ary2.Contains(x)).Concat(ary2.Where(x=>ary1.Contains(x))).ToArray();

int[] allres=ary1.Concat(ary2).Distinct().OrderBy(x=>x).ToArray();

Console.WriteLine("All Elements in the List");
foreach (var item in allres)
{
    Console.WriteLine(item);
}

List<int> numbers = new List<int> { 10, 20, 30, 40, 50, 60, 70, 80, 90 };

Console.WriteLine($"{numbers.Count / 2}");
for (int i = 0; i < numbers.Count / 2; i++)
{
    if (i == numbers.Count / 2 - 1)
    {
        Console.Write($"{numbers[i]},{numbers[numbers.Count - 1 - i]}");
        break;
    }
    Console.Write($"{numbers[i]},{numbers[numbers.Count - 1 - i]},");
}

