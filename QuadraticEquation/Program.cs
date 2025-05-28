using System.Text;

void firstDegreeSolution(double a, double b)
{
    if (a == 0 && b == 0)
    {
        Console.WriteLine("Infinite Solutions");
    }
    else if (a == 0 && b != 0)
    {
        Console.WriteLine("No solution");
    }
    else
    {
        Console.WriteLine("X = {0}", -b/a);
    }
}

void quadraticEquationSolution(double a, double b, double c)
{
    if (a == 0)
    {
        firstDegreeSolution(b, c);
    }
    else
    {
        var delta = Math.Pow(b, 2) - 4 * a * c;
        if (delta < 0) {
            Console.WriteLine("No solution");
        }else if (delta == 0){
            Console.WriteLine("Equation has 1 solution");
            Console.WriteLine("X1 = X2 = {0}", -b/(2*a));
        }
        else
        {
            var x1 = (-b - Math.Sqrt(delta)/(2*a));
            var x2 = (-b + Math.Sqrt(delta) / (2 * a));
            Console.WriteLine("Equation has 2 distinct solutions");
            Console.WriteLine("X1 = {0}\nX2 = {1}", x1, x2);
        }
    }
}

Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Quadratic Equation: ax^2 + bx + c = 0");
Console.Write("Parameter a: ");
var a = Double.Parse(Console.ReadLine());
Console.Write("Parameter b: ");
var b = Double.Parse(Console.ReadLine());
Console.Write("Parameter c: ");
var c = Double.Parse(Console.ReadLine());
quadraticEquationSolution(a, b, c);
Console.ReadLine();