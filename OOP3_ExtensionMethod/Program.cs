using OOP3_ExtensionMethod;
using System.Text;
Console.OutputEncoding = Encoding.UTF8;

int n1 = 5;
Console.WriteLine("Tổng từ 1 tới 5 = "+n1.SumFrom1ToN());
int n2 = 10;
Console.WriteLine("Tổng từ 1 tới 10 = " + n2.SumFrom1ToN());
Console.WriteLine("Tổng từ 1 tới 100 = " + 100.SumFrom1ToN());

Console.WriteLine("10 + 20 = " + 10.Sum(20));

int[] arr = new int[8];
arr.TaoMang();
Console.WriteLine("-----Array before sort--------");
arr.XuatMang();
arr.SapXepTangDan();
Console.WriteLine("-----Array after ascending sort------");
arr.XuatMang();