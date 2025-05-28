using OOP2;
using System.Text;
Console.OutputEncoding = Encoding.UTF8;
FullTimeEmployee binladen = new FullTimeEmployee()
{
    Id = 1,
    IdCard = "123",
    Name = "Binladen Osama",
    Birthday = new DateTime(1960, 11, 25)
};
Console.WriteLine("---BINLADEN'S INFORMATION---");
Console.WriteLine($"Id={binladen.Id}");
Console.WriteLine("Name= " + binladen.Name);
Console.WriteLine("IdCard=" + binladen.IdCard);
Console.WriteLine("DOB =" + binladen.Birthday.ToString("dd/MM/yyyy"));
Console.WriteLine("The salary binladen receive = " + binladen.calSalary());

PartTimeEmployee trump = new PartTimeEmployee()
{
    Id = 2,
    IdCard = "123",
    Name = "Donald Trump",
    Birthday = new DateTime(2005, 11, 25),
    WorkingHour = 10
};
Console.WriteLine("---TRUMP'S INFORMATION---");
Console.WriteLine($"Id={trump.Id}");
Console.WriteLine("Name= " + trump.Name);
Console.WriteLine("IdCard=" + trump.IdCard);
Console.WriteLine("DOB =" + trump.Birthday.ToString("dd/MM/yyyy"));
Console.WriteLine("The salary Trump receive = " + trump.calSalary());

Console.WriteLine("--------USE TOSTRING()------");
Console.WriteLine(binladen);
Console.WriteLine(trump);
