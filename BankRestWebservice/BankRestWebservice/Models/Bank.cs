using Contract.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankRestWebservice.Models
{
    public class Bank
    {
        private string cvr;
        private string name;
        private int bankId;
        private static List<IAccount> accounts = new List<IAccount>();

        public Bank()
        {

        }
        public Bank(string cvr, string name)
        {
            this.cvr = cvr;
            this.name = name;
        }

        public List<IAccount> GetAccounts(ICustomer customer)
        {
            return accounts;
        }

        public void AddAccount(IAccount account)
        {
            accounts.Add(account);
        }

        public IAccount GetAccount(string id)
        {
            bool found = false;
            foreach (var item in accounts)
            {
                if (item.Number == id)
                {
                    found = true;
                    return item;
                }
            }
            if (found == false)
            {
                throw new ArgumentException("Account not found");
            }
            return null;
        }

        public string Cvr
        {
            get { return cvr; }
            set { cvr = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int BankId
        {
            get { return bankId; }
            set { bankId = value; }
        }

    }
}