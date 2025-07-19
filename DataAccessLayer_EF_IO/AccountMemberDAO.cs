using BusinessObjects_EF_IO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_EF_IO
{
    public class AccountMemberDAO
    {
        MyStoreContext context = new MyStoreContext();
        public AccountMember Login(string email, string pwd)
        {
            return context.AccountMembers
                .FirstOrDefault(acc => acc.EmailAddress == email && acc.MemberPassword == pwd);
        }
    }
}
