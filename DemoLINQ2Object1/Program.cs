using System.Text;

Console.OutputEncoding = Encoding.UTF8;
int[] arr = { 20, 10, 30, 15, 40, 17, 73, 19, 50, 15 };
/* Câu 1: Lọc ra các số chẵn
 */
//cách 1: dùng extension method - method syntax
var ar_chan = arr.Where(x => x % 2 == 0);
Console.WriteLine("Các số chẵn trong mảng là - Method Syntax: ");
ar_chan.ToList().ForEach(x => Console.Write(x + " "));
//Cách 2: dùng query syntax
var ar_chan2 = from x in arr
               where x % 2 == 0
               select x;
Console.WriteLine("\nCác số chẵn trong mảng là - Query Syntax: ");
ar_chan2.ToList().ForEach(x => Console.Write(x + " "));
/* Câu 2: Tăng các phần tử lẻ lên 2 đơn vị
 * 
 */
var arr2 = arr.Where(x => x % 2 != 0)
               .Select(x => x + 2);

Console.WriteLine("\nOriginal Array");
arr.ToList().ForEach(x => Console.Write(x + " "));
Console.WriteLine("\nLọc ra các số lẻ trong mảng và tăng lên 2 đơn vị là: ");
arr2.ToList().ForEach(x => Console.Write(x + " "));

/* Câu 3: Sắp xếp các phần tử tăng dần:
 */
var arr4 = arr.OrderBy(x => x);

var arr5 = from x in arr
           orderby x
           select x;
Console.WriteLine("\nSắp xếp các phần tử tăng dần - Method Syntax: ");
foreach (var x in arr4)
{
    Console.Write(x + " ");
}

/*
 * Câu 4: Sắp xếp giảm dần
 */
var arr6 = arr.OrderByDescending(x => x);
var arr7 = from x in arr
           orderby x descending
           select x;
/*
 * Câu 5: Đếm các phân tử lẻ
 */
Console.WriteLine("\nSố lẻ là = "+ arr.Where(x => x % 2 != 0).Count());
int sole = (from x in arr
            where x % 2 != 0
            select x).Count();                      