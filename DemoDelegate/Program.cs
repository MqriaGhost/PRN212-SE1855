using System.Text;

class Program
{
    public delegate int MyDelegate1(int x, int y);
    static int Add(int x, int y)
    {
        return x + y;
    }
    static int Minus(int x, int y)
    {
        return x - y;
    }
    public delegate int[] MyDelegate2(int n);
    static int[]EvenNumberList(int n)
    {
        List<int> list = new List<int>();
        for(int i = 2; i <= n; i += 2)
        {
            list.Add(i);
        }
        return list.ToArray();
    }

    static int[]PrimeNumberList(int n)
    {
        List<int> list = new List<int>();
        for(int i = 2; i <= n; i++)
        {
            int count = 0;
            for(int j =1; j <= i; j++)
            {
                if (i % j == 0)
                {
                    count++;
                }
            }
            if (count == 2)
            {
                list.Add(i);
            }
        }
        return list.ToArray();
    }
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        MyDelegate1 d1 = new MyDelegate1(Add);
        MyDelegate1 d2 = new MyDelegate1(Minus);
        Console.WriteLine("Sum of 5 and 8  = " + d1(5, 8));
        Console.WriteLine("Subtract of 5 and 8  = " + d2(5, 8));
        MyDelegate2 de2 = new MyDelegate2(EvenNumberList);
        int[] arr = de2(10);
        Console.WriteLine("Even number list: ");
        foreach(int i in arr)
        {
            Console.Write(i + " ");
        }
        de2 = new MyDelegate2(PrimeNumberList);
        arr = de2(10);
        Console.WriteLine("\nPrime number list: ");
        foreach (int i in arr)
        {
            Console.Write(i + " ");
        }
    }
    

}