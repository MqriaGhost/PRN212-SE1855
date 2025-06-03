using DemoAliasAndClone;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Student s1 = new Student();
s1.Id = 1;
s1.Name = "Hehe";
Student s2 = new Student();
s2.Id = 1;
s2.Name = "Hihi";

/* Lúc này trên thanh RAM sẽ cấp phát 2 ô nhớ
   cho s1 và s2 quản lý
==> s1 đổi giá trị k liên quan gì tới s2 vì
s1 và s2 đang quản lý 2 ô nhớ khác nhau
nếu ta viết lệnh s1 = s2
về bản chất nó hoạt động như sau: s1 trỏ tới vùng nhớ mà s2 đang quản lý
chứ không phải s1 = s2.
 */
s1 = s2; //pass by reference
/*
 * khi s1 = s2
 * sẽ có 2 tình huống xảy ra
 * (1) ô nhớ bên s2 giờ có thêm s1 quản lý => alias (>=2 đối tượng quản lý 1 ô nhớ)
 * chỉ cần 1 đối tượng đổi thì các đối tượng khác đều bị đổi
 * (2) ô nhớ bên s1 sẽ bị thu hồi (Gảbage collection) vì s1 sẽ trỏ tới ô nhớ mà s2 đang quản lý
 * ta không thể lấy lại giá trị s1 có id=1 và tên là haha vì đã bị thu hồi
 */

Product p1 = new Product() 
{
    Id = 1, Name = "Persona 1 Innocent Sin", Quantity = 10, Price = 20 
};
Product p2 = new Product()
{
    Id = 2,
    Name = "Persona 2 Shin MegamiTensei",
    Quantity = 20,
    Price = 15
};

p1 = p2;
p2.Name = "Talking bread";
p2.Price = 80;
Console.WriteLine("P1 information");
Console.WriteLine(p1);

Product p3 = new Product()
{
    Id = 3,
    Name = "Persona 3 Reload",
    Quantity = 30,
    Price = 50
};
Product p4 = new Product()
{
    Id = 4,
    Name = "Persona 4 Golden",
    Quantity = 40,
    Price = 90
};
Product p5 = p3;
p3 = p4;
//Hỏi ô nhớ cấp phát cho p3 có bị thu hồi không
//Hem

Product p6 = p4.clone();
//p6 sao chép toàn bộ dữ liệu trong ô nhớ mà p4 đang quản lý sang ô nhớ mới 
//và giao cho p6 quản lý.
/* Lúc này không phải là alias vì p4 và p6 quản lý 2 ô nhớ khác nhau
 */
Console.WriteLine("P6 Information: ");
Console.WriteLine(p6);
Console.WriteLine("P4 Information: ");
Console.WriteLine(p4);
p4.Name = "Persona 4 Golden Deluxe";
Console.WriteLine("P6 Information: ");
Console.WriteLine(p6);
Console.WriteLine("P4 Information: ");
Console.WriteLine(p4);