using OOP2;
using OOP2_Reuse_As_Library;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

FullTimeEmployee em1 = new FullTimeEmployee();
em1.Id = 1;
em1.Name = "Hung";
em1.IdCard = "123";
em1.Birthday = new DateTime(1990, 12, 25);
Console.WriteLine("----EM1'S INFORMATION----");
Console.WriteLine(em1);
Console.WriteLine("===>AGE = " + em1.TinhTuoi());