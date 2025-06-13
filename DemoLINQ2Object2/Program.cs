using DemoLINQ2Object2;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
ListProduct lp = new ListProduct();
lp.gen_products();
/*
 * Lọc ra các sản phẩm có giá trị từ a tới b
 * sử dụng Method Syntax và Querry Syntax
 */
var result1 = lp.FilterProductsByPrice(200, 300);
Console.WriteLine("Danh sách sản phẩm có giá từ 200-300:");
result1.ForEach(p => Console.WriteLine(p));
//Câu 2: Sắp xếp các sản phẩm theo đơn giá giảm dần
// sử dụng Method Syntax và Querry Syntax
var rersult2 = lp.SortProductsByPriceDescending();
Console.WriteLine("Danh sách sản phẩm sắp xếp theo đơn giá giảm dần:");
rersult2.ForEach(p => Console.WriteLine(p));
//Câu 3: Tính tổng giá trị của các sản phẩm
double totalValue = lp.SumOfValue();
Console.WriteLine($"Tổng giá trị của các sản phẩm: {totalValue}");
