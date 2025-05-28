/* Đề tài
 * Nhập vào 1 số >=0, nếu nhập sai quy tắc
 * thì yêu cầu nhập lại khi nào đúng mới dừng
 * Nếu nhập đúng thì tính giai thừa của số này
 */
int n = -1; //giả sử nhập sai
while (n < 0 ) //bắt nhập lại cho tới khi nào n >=0
{
    Console.Write("Enter your mom age (>= 0): ");
    string input = Console.ReadLine();
    if (int.TryParse(input, out n) == true)
    { //khi vào đây thì n là số, nhưng có thể < 0
        if (n >= 0) //nhập đúng
        {
            break; //không bắt nhập nữa
        }
        else
        {
            Console.WriteLine("Your mom is gay");
        }

    }
    else
    {
        Console.WriteLine("Your father is sus");
    }
}
int gt = 1;
for(int i = 1; i <= n; i++)
{
    gt = gt * i;
}
Console.WriteLine($"{n}! = {gt}");