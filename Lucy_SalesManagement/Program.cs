using Lucy_SalesManagement;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
string connectionString = @"server=GODIVA\PHUOCAN;database=Lucy_SalesData;uid=sa;pwd=12345";
Lucy_SalesDataDataContext context = 
    new Lucy_SalesDataDataContext(connectionString);
int mkh = 1;
Customer cust=context.Customers.FirstOrDefault(c => c.CustomerID == mkh);
if (cust != null)
{
    Console.WriteLine($"Mã khách hàng: {cust.CustomerID} + {cust.ContactName}");
}

//Câu 2: Lọc ra danh sách các hoá đơn của khách hàng tim thấy
if(cust!= null)
{
    Console.WriteLine("Danh sách hoá đơn của khách hàng: ");
    foreach(Order od in cust.Orders)
    {
        Console.WriteLine(od.OrderID+"\t"+od.OrderDate.ToString("dd/MM/yyyy"));    
    }
}
//Câu 3: Nâng cấp câu 2
// bổ sung thêm 1 cột hiển hị Trị giá của hoá đơn
if (cust != null)
{
    Console.WriteLine("Danh sách hoá đơn của khách hàng: ");
    foreach (Order od in cust.Orders)
    {
        var total = od.Order_Details.Sum(odt => odt.UnitPrice * odt.Quantity - (odt.UnitPrice * odt.Quantity*odt.Discount));
        Console.WriteLine(od.OrderID + "\t" + od.OrderDate.ToString("dd/MM/yyyy"));e
    }
}
