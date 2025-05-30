using OOP5_Dictionary;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Category c1 = new Category();
c1.Id = 1;
c1.Name = "Fizzy drink";

Product p1 = new Product();
p1.Id = 1;
p1.Name = "Coca";
p1.Quantity = 15;
p1.Price = 15;
c1.AddProduct(p1);

Product p2 = new Product();
p2.Id = 2;
p2.Name = "Pepsi";
p2.Quantity = 30;
p2.Price = 15;
c1.AddProduct(p2);

Product p3 = new Product();
p3.Id = 3;
p3.Name = "7UP";
p3.Quantity = 10;
p3.Price = 20;
c1.AddProduct(p3);

Product p4 = new Product();
p4.Id = 4;
p4.Name = "RedCat";
p4.Quantity = 30;
p4.Price = 15;
c1.AddProduct(p4);

Product p5 = new Product();
p5.Id = 5;
p5.Name = "Soda";
p5.Quantity = 50;
p5.Price = 5;
c1.AddProduct(p5);

//Xuát toàn bộ sản phẩm của danh mục:
Console.WriteLine("---All fizzy products----");
c1.PrintAllProducts();

Dictionary<int, Product> filters = c1.FilterProductsByPrice(10, 15);
Console.WriteLine("---Products with price from 10 to 15----");
foreach (KeyValuePair<int, Product> item in filters)
{
    Product p = item.Value;
    Console.WriteLine(p);
}

Dictionary<int, Product> sort_result = c1.SortProductByPrice();
Console.WriteLine("---Product list after sort ascending by price---");
foreach (KeyValuePair<int, Product> item in sort_result)
{
    Product p = item.Value;
    Console.WriteLine(p);
}

Dictionary<int, Product> complex_sort = c1.ComplexSort();
Console.WriteLine("---Product list after complex sort---");
foreach (KeyValuePair<int, Product> item in complex_sort)
{
    Product p = item.Value;
    Console.WriteLine(p);
}