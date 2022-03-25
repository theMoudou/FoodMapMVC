using FoodMapMVC.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodMapMVC.Managers
{
    public class AccountManager
    {
        public List<Account> GetAccountList()
        {
            using (ContextModel contextModel = new ContextModel())
            {
                var query = contextModel.Accounts.AsQueryable();

                var list = query.ToList();
                return list;
            }
        }

        public Account GetAccount(string account)
        {
            using (ContextModel contextModel = new ContextModel())
            {
                var query = contextModel.Accounts.Where(item => item.Account1 == account);

                var obj = query.FirstOrDefault();
                return obj;
            }
        }

        public Account GetAccount(Guid id)
        {
            using (ContextModel contextModel = new ContextModel())
            {
                var query = contextModel.Accounts.Where(item => item.ID == id);

                var obj = query.FirstOrDefault();
                return obj;
            }
        }
    }
}