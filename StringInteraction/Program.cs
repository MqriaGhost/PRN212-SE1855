using System.Text;
string ho = "Waku Waku";
string tenlot = "Hehe";
string ten = "beo";
string fullname = ho  + " " + tenlot + " " + ten;
Console.WriteLine( fullname );

StringBuilder sb  = new StringBuilder();
sb.Append( ho );
sb.Append(" ");
sb.Append( tenlot );
sb.Append(" ");
sb.Append( ten );
sb.Append(" ");
Console.WriteLine(sb.ToString());