namespace DelegateTest
{

    public delegate int MathOperation(int x, int y);

    //A delegate is a type that represents references to methods.
    //When you instantiate a delegate, you can associate its instance
    //with any method that has a compatible signature and return type.

    //Delegates are type-safe, meaning the method signature must match the delegate signature.

    //Delegates encapsulate a method, allowing methods to be passed as parameters.

    //Delegates can hold references to multiple methods, allowing multiple methods to
    //be called on a single event.

    //Type-Safe: This means that the types of the inputs and outputs are checked at compile time,
    //ensuring that they match the expected types.

    public class calculation
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Subtract(int x, int y)
        {
            return x - y;
        }
        public int Multiply(int x, int y) { return x * y; }
    }

    public class program
    {
        public static void Main()
        {
            calculation _calculation = new calculation();
            MathOperation _mathOperation = new MathOperation(_calculation.Add);
            int res;

            res = _mathOperation(7, 8);
            Console.WriteLine("Addition is" + res);
            _mathOperation = new MathOperation(_calculation.Subtract);

            res = _mathOperation(17, 8);
            Console.WriteLine("Substraction is" + res);
            _mathOperation = new MathOperation(_calculation.Multiply);

            res = _mathOperation(7, 8);
            Console.WriteLine("Multiplication is" + res);

            //callback method
            LongRunningOperation operation = new LongRunningOperation();

            // Define the callback method
            OperationCompletedCallback callback = OperationCompleted;

            // Perform the operation and pass the callback
            operation.PerformOperation(callback);

            //LINQ using delegate
            List<Student> students = new List<Student>
            {
                new Student { Name = "Alice", Age = 20 },
                new Student { Name = "Bob", Age = 22 },
                new Student { Name = "Charlie", Age = 23 },
                new Student { Name = "David", Age = 21 }
            };

            //Where method: Uses a delegate (Func<Student, bool>) to filter students who are 21 or older.
            //Select method: Uses a delegate (Func<Student, string>) to select the names of the filtered students.

            var adultStudents = students.Where(s => s.Age >= 21).Select(s => s.Name);

            foreach (var name in adultStudents)
            {
                Console.WriteLine(name);
            }

            //Where Method: The Where method takes a delegate of type Func<Student, bool>.
            //This delegate represents a method that takes a Student object and returns a bool.
            //In this case, the lambda expression s => s.Age >= 21 is used, which returns true
            //if the student's age is 21 or older.

            //Select Method: The Select method takes a delegate of type Func<Student, string>.
            //This delegate represents a method that takes a Student object and returns a string.
            //The lambda expression s => s.Name is used to select the Name property of each student.
        }
            // Callback method
        private static void OperationCompleted(string message)
            {
                Console.WriteLine(message);
            }
        }
        //example on  Delegates are commonly used in event handling.Events in C# are based on delegates.
        public delegate void ButtonClickHandler(object sender, EventArgs e);
        public class Button
        {
        // Declare the event using the delegate
        public event ButtonClickHandler Click;

        // Method to simulate a button click
            public void OnClick()
            {
                // Check if there are any subscribers
                if (Click != null)
                {
                    // Raise the event
                    Click(this, EventArgs.Empty);
                }
            }
        }

    //Callback methods are a common use case for delegates in C#.
    //A callback method is a method that is passed as an argument to another method and
    //is invoked after a certain operation is completed. This is particularly useful for asynchronous operations.

    public delegate void OperationCompletedCallback(string message);
    public class LongRunningOperation
    {
        public void PerformOperation(OperationCompletedCallback callback)
        {
            // Simulate a long-running operation
            System.Threading.Thread.Sleep(3000); // Sleep for 3 seconds

            // Operation completed, invoke the callback
            callback("Operation completed successfully!");
        }
    }
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}


