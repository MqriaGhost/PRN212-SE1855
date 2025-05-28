using System.Text;
void ham1(int n)
{
    n = 8;
    Console.WriteLine($"n trong hàm = {n}");
}
Console.OutputEncoding = Encoding.UTF8;
int n = 5;
Console.WriteLine($"n before going to ham = {n}");
ham1(n);
Console.WriteLine($"n after going to ham = {n}");

void ham2(ref int n)
{
    n = 8;
    Console.WriteLine($"n trong ham = {n}");
}
Console.WriteLine("------REF------");
n = 5;
Console.WriteLine($"n truoc khi vao ham = {n}");
ham2(ref n);
Console.WriteLine($"n sau khi vao ham = {n}");

//ref: Phải khởi tạo giá trị cho biến trước khi gọi
//int m;
//ham2(ref m);

void ham3(out int n)
{
    n = 8;

}