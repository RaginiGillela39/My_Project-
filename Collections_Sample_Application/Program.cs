// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var list = new List<int> { 1, 2, 3 };
list.Add(4);  // Add an element
Console.WriteLine(list[3]);  // Access element by index

List<int> num = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

List<int> result = num.Where(x => x % 2 == 0).Select(x => x).ToList();
int sum = 0;
foreach (var item in result)
    sum = sum + item;
Console.WriteLine(sum);

var dictionary = new Dictionary<string, int>();
dictionary["Apple"] = 10;  // Add key-value pair
Console.WriteLine(dictionary["Apple"]);  // Access value by key

var queue = new Queue<int>();
queue.Enqueue(1);  // Add to the queue
queue.Enqueue(2);
Console.WriteLine(queue.Dequeue());  // Remove and return the front element (1)