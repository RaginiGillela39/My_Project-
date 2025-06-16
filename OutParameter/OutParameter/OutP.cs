namespace OutParameter
{
    public class OutP
    {
        public void Show(out int val)
        {
            val = 100;
            Console.WriteLine("Value inside the show method " + val);
        }

        public  int fact(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        public static void fibonacci(int n)
        {
            int a = 0,b= 1;
            Console.WriteLine($"a  ");
            Console.WriteLine($"b ");
            int c ;
            for(int i=3; i <= n; i++)
            {
                c = a + b;
                Console.WriteLine(c);
                a = b;
                b = c;
            }

        }

        public int divide()
        {
            int a = 10;
            int b = 0;
            int c = 0;
            try
            {
               c= a / b;
            }
            catch (DivideByZeroException ex)
            {
                //throw e;
                throw new Exception("An error occurred while loading data", ex);

            }
            return c;
        }
    }
}
