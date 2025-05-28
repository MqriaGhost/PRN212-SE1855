using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    public class Employee
    {
        private int _id;
        private string _name;
        private string _email;
        private string _phone;
        private string _id_card;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }

        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string IdCard
        {
            get { return _id_card; }
            set { _id_card = value; }
        }

        public void PrintInfor()
        {
            string msg = $"{Id}\t{IdCard}\t{Name}\t{Email}\t{Phone}";
            Console.WriteLine(msg);
        }
    }
}
