using DataAccessLayer_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_EF
{
    public class AccountMemberRepository : IAccountMemberRepository
    {
        AccountMemberDAO account = new AccountMemberDAO();
        public AccountMember Login(string email, string pwd)
        {
            return account.Login(email, pwd);
        }
    }
}
