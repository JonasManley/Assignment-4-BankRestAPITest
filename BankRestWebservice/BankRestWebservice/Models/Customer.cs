using Contract.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankRestWebservice.Models
{
    public class Customer
    {
        private int customerId;
        private string cpr;
        private string name;
        private int bankId;

        public Customer()
        {

        }

        public Customer(int customerId, string cpr, string name, int bankId)
        {
            this.cpr = cpr;
            this.name = name;
            this.customerId = customerId;
            this.bankId = bankId;
        }

        public void transfer(int amount, IAccount account, ICustomer target)
        {
            // _Hvad skal den gøre? 
        }

        public int getId()
        {
            return customerId;
        }

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        public string Cpr
        {
            get { return cpr; }
            set { cpr = value; }
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