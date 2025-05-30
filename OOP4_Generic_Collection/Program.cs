using OOP2;
using System.Text;
Console.OutputEncoding = Encoding.UTF8;

/*
 * Sử dụng generic list để quản lý nhân sự
 * thực hiện đầy đủ tính năng CRUD
 * C - create => thêm mới nhân sự
 * Read/Retrieve => Đọc: Truy vấn, tìm kiếm,...
 * Update => Chỉnh sửa dữ liệu
 * Delete => Xoá dữ liệu
 */

/*
 * Câu 1 - C (create)
 * Dùng list tạo ra 5 employee, trong đó 4 Employee là chính thức
 * và 1 employee là thời vụ
 */

List<Employee> employees = new List<Employee>();
FullTimeEmployee em1 = new FullTimeEmployee();
em1.Id = 1;
em1.Name = "Hung";
em1.IdCard = "Card1";
em1.Birthday = new DateTime(1993, 12, 09);
employees.Add(em1);

FullTimeEmployee em2 = new FullTimeEmployee();
em2.Id = 2;
em2.Name = "Mon";
em2.IdCard = "Card2";
em2.Birthday = new DateTime(2000, 12, 24);
employees.Add(em2);

FullTimeEmployee em3 = new FullTimeEmployee();
em3.Id = 3;
em3.Name = "Doraemon";
em3.IdCard = "Card3";
em3.Birthday = new DateTime(1999, 05, 29);
employees.Add(em3);

FullTimeEmployee em4 = new FullTimeEmployee();
em4.Id = 4;
em4.Name = "Shin-chan";
em4.IdCard = "Card4";
em4.Birthday = new DateTime(1998, 11, 29);
employees.Add(em4);

PartTimeEmployee em5 = new PartTimeEmployee();
em5.Id = 5;
em5.Name = "Sasageyo";
em5.IdCard = "Card5";
em5.WorkingHour = 2;
em5.Birthday = new DateTime(1993, 11, 29);
employees.Add(em5);

/*
 * R --> Xuất toàn bộ nhân sự
 * Cách xuất 1:
 */
Console.WriteLine("----Employee's list--Method 1---");
employees.ForEach(e => { 
    Console.WriteLine(e); 
});
Console.WriteLine("----Employee's list--Method 2---");
foreach (var employee in employees)
    Console.WriteLine(employee);

/*
 * Lọc ra nhân sự chính thức và tính tổng lương わからない
 */
List<FullTimeEmployee> fe_list = employees.OfType<FullTimeEmployee>().ToList();
Console.WriteLine("----OFFICIAL EMPLOYEE----");
Console.WriteLine("----METHOD 1----");
fe_list.ForEach(e => Console.WriteLine(e));
//cách 2, dùng cách thông thường
Console.WriteLine("----METHOD 2----");
List<FullTimeEmployee> fe_list2 = new List<FullTimeEmployee>();
foreach(var e in employees)
{
    if(e is FullTimeEmployee)
        fe_list2.Add(e as FullTimeEmployee);
}
Console.WriteLine("----OFFICIAL EMPLOYEE LIST-----");
fe_list2.ForEach(e => Console.WriteLine(e));

//Total salary
double sum_salary = fe_list2.Sum(e => e.calSalary());
Console.WriteLine("Total salary = " + sum_salary);

//Câu 4: R --> Sắp xếp danh sách nhân sự theo ngày tháng năm sinh
for(int i = 0; i < employees.Count; i++)
{
    for(int j = i+1; j<employees.Count; j++)
    {
        Employee ei = employees[i];
        Employee ej = employees[j];
        if(ei.Birthday > ej.Birthday)
        {
            employees[i] = ej;
            employees[j] = ei;
        }
    }
}
Console.WriteLine("EMPLOYEE LIST AFTER SORT");
employees.ForEach(e => Console.WriteLine(e));

//Update
Console.WriteLine("----UPDATE EMPLOYEE----");
Console.Write("Enter the ID of the employee you want to update: ");
int id = int.Parse(Console.ReadLine());
var updateEmployee = employees.FirstOrDefault(e => e.Id == id);
if(updateEmployee != null)
{
    string updateOption="";
    Console.WriteLine("Select the field you want to update: ");
    Console.WriteLine("1: Name");
    Console.WriteLine("2: ID Card");
    updateOption = Console.ReadLine();
    switch (updateOption)
    {
        case "1":
            Console.Write("Enter new name: ");
            updateEmployee.Name = Console.ReadLine();
            break;
        case "2":
            Console.Write("Enter new ID Card: ");
            updateEmployee.IdCard = Console.ReadLine();
            break;
        default:
            Console.WriteLine("Invalid option!");
            break;
    }
}
else
{
    Console.WriteLine("Employee not found!");
}
//Display updated list
Console.WriteLine("----EMPLOYEE LIST AFTER UPDATE----");
employees.ForEach(e => Console.WriteLine(e));

//Delete
Console.WriteLine("----DELETE EMPLOYEE----");
Console.Write("Enter the ID of the employee you want to delete: ");
int deleteEmployee = int.Parse(Console.ReadLine());
var deleteId = employees.FirstOrDefault(e => e.Id == deleteEmployee);
if(deleteId != null)
{
    employees.Remove(deleteId);
    Console.WriteLine("Employee deleted successfully!");
}
else
{
    Console.WriteLine("Employee not found!");
}
Console.WriteLine("----EMPLOYEE LIST AFTER DELETE----");
employees.ForEach(e => Console.WriteLine(e));