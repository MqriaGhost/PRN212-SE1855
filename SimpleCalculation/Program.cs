using System.Text;
Console.OutputEncoding = Encoding.UTF8;

void doCalculate(double a, double b, string op)
{
    switch (op)
    {
        case "+":
            Console.WriteLine("{0} + {1} = {2}", a, b, a+b);
            break;
        case "-":
            Console.WriteLine("{0} + {1} = {2}", a, b, a - b);
            break;
        case "*":
            Console.WriteLine("{0} + {1} = {2}", a, b, a * b);
            break;
        case "/":
            Console.WriteLine("{0} + {1} = {2}", a, b, a / b);
            break;
        default:
            Console.WriteLine("(>_<)mooh!");
            break;
    }
}
Console.WriteLine("SIMPLE CALCULATION GO BRUH BRUH");
Console.WriteLine("Ara Ara~, enter numbers for mommy");
Console.WriteLine("Enter a: ");
double a = Double.Parse(Console.ReadLine());
Console.WriteLine("Enter b: ");
double b = Double.Parse(Console.ReadLine());
Console.WriteLine("Enter operator: [+] [-] [*] [/] ");
String op = Console.ReadLine();
doCalculate(a, b, op);
Console.ReadLine();

