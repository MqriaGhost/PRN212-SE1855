using OOP1;
using System.Text;

Console.OutputEncoding=Encoding.UTF8;
Category c1 = new Category();
c1.Id = 1;
c1.Name = "Fishsauce";
c1.PrintInfor();

//Khoi tao 1 nhan vien
Employee em = new Employee();
em.Id = 1;
em.IdCard = "00123";
em.Name = "Mon";
em.Email = "mon@gmail.com";
em.Phone = "123456";
// goi ham xuat thong tin
em.PrintInfor();
// ta  co the truy suat theo tung property de lay gia tri cua thuoc tinh
Console.WriteLine("-----------------");
Console.WriteLine("Id cua em =" + em.Id);
Console.WriteLine($"Employee's name is: {em.Name}"); //goi getter propert name

//Ta cung co the khoi tao doi tuong va cac gia tri cua thuoc tinh nhu sau
Employee em2 = new Employee()
{
    Id = 2,
    IdCard = "00321",
    Name = "HEHE",
    Email = "emplus@gmail.com",
    Phone = "13123123"
};
Console.WriteLine("----E2----");
em2.PrintInfor();



