using DemoLINGQ2SQL;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
string connectionString = @"server=GODIVA\PHUOCAN;database=MyStore;uid=sa;pwd=12345";
MyStoreDataContext context = new MyStoreDataContext(connectionString);
/* Câu 1: Truy vấn toàn bộ danh mục
 */
var cl = context.Categories.ToList();
Console.WriteLine("Category List:");
cl.ForEach(dm =>
{
    Console.WriteLine($"ID: {dm.CategoryID}, Name: {dm.CategoryName}");
});
/*
 * Câu 2: Dùng query syntax để lọc ra toàn bộ sản phẩm
 */
var dsp = from p in context.Products
          select p;
Console.WriteLine("\nProduct List:");
foreach (var sp in dsp)
{
    Console.WriteLine($"ID: {sp.ProductID}, Name: {sp.ProductName}, Price: {sp.UnitPrice}");
}
/*
 * Câu 3: Tìm danh mục khi biết mã danh mục
 */
int dmd = 3;
Category cate = context.Categories.FirstOrDefault(x => x.CategoryID==dmd);
if(cate == null)
{
    Console.WriteLine("Không tìm thấy danh mục có mã: " + dmd);
}
else
{
    Console.WriteLine("Đã tìm thấy danh mục có mã: " + dmd);
    Console.WriteLine(cate.CategoryID + "\t" + cate.CategoryName);
}
/*
 * Câu 4: Lọc ra top 3 sản phẩm có giá lớn nhất
 */
var top3Products = context.Products
    .OrderByDescending(p => p.UnitPrice)
    .Take(3)
    .ToList();
Console.WriteLine("\nTop 3 Products with Highest Price:");
foreach (var product in top3Products)
{
    Console.WriteLine($"ID: {product.ProductID}, Name: {product.ProductName}, Price: {product.UnitPrice}");
}
/*
 * Câu 5: Add new product
 */
/*Category c1 = new Category();
c1.CategoryName = "Hàng điện tử hhhhhhhhhhhhhhhheeeeeeeeeeeeeeeee";
context.Categories.InsertOnSubmit(c1);
context.SubmitChanges();
*/
/**Câu 6: Sửa tên danh mục
 * Bước 1: Tìm tên danh mục
 * Bước 2: Tìm thấy thì sửa*/

Category c13 = context.Categories.FirstOrDefault(c => c.CategoryID == 8);
if(c13 != null)
{
    c13.CategoryName = "Hàng sách";
    context.SubmitChanges();
}

/*
 * Câu 7: Xoá danh mục khi biết mã danh mục
 */
Category c12 = context.Categories.FirstOrDefault(c => c.CategoryID == 5);
if(c12 != null)
{
    context.Categories.DeleteOnSubmit(c12);
    context.SubmitChanges();
    Console.WriteLine("Đã xoá danh mục có mã: " + c12.CategoryID);
}

/*
 * Câu 8: Xoá tất cả danh mục khi chưa có sản phẩm nào:
 */
var dssp_empty_product = context.Categories
    .Where(c => c.Products.Count() == 0).ToList();
context.Categories.DeleteAllOnSubmit(dssp_empty_product);
context.SubmitChanges();

/*
 * Câu 9: Thêm nhiều danh mục cùng một lúc
 */
List<Category> dsdm = new List<Category>();
dsdm.Add(new Category { CategoryName = "Hài dáng" });
dsdm.Add(new Category { CategoryName = "Hài hảng" });
dsdm.Add(new Category { CategoryName = "Hàng hoá" });
context.Categories.InsertAllOnSubmit(dsdm);
context.SubmitChanges();



