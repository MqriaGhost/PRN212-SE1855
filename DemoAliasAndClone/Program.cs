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