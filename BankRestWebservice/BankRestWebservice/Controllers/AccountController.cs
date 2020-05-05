using BankRestWebservice.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BankRestWebservice.Controllers
{
    public class AccountController : ApiController
    {
        // GET api/<controller>
        private SqlConnection conn = new SqlConnection("Server=tcp:myservereasj.database.windows.net,1433;Initial Catalog=mydatabase;Persist Security Info=False;User ID=Serveradmin;Password=Test12345; Connection Timeout=30;");



        //GET api/Customer
        [ActionName("GetAllCustomer")]
        public List<Account> GetAllAccounts()
        {
            var list = new List<Account>();
            var query = "SELECT * FROM Account";
            conn.Open();

            using (var command = new SqlCommand(query, conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Account
                    {
                        Number = reader.GetString(1),
                        Balance = reader.GetInt32(2),
                    });
                }
                reader.Close();
            }
            return list;
        }

        // GET api/Customer/<cprnummer>
        [ActionName("GetAccountById")]
        public Account GetAccountById(int id)
        {
            Account account = new Account();
            var query = "SELECT * FROM Account";
            conn.Open();
            using (var command = new SqlCommand(query, conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (id == reader.GetInt32(0))
                    {
                        Account accountHolder  = new Account
                        {
                            Number = reader.GetString(1),
                            Balance = reader.GetInt32(2),
                        });
                        account = accountHolder;
                    }
                }
                reader.Close();
            }
            return account;
        }

        // POST api/<controller>
        public void Post([FromBody]Account account)
        {
            var query = "INSERT INTO Customer (number, balance) VALUES(@number, @balance)";

            SqlCommand inserCommand = new SqlCommand(query, conn);
            inserCommand.Parameters.AddWithValue("@number", account.Number);
            inserCommand.Parameters.AddWithValue("@balance", account.Balance);

            conn.Open();
            inserCommand.ExecuteNonQuery();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/<controller>/5
        [ActionName("DeleteAccount")]
        public void DeleteAccount(int AccountId)
        {
            var query = $"DELETE FROM Account WHERE accountId = {AccountId};";

            SqlCommand inserCommand = new SqlCommand(query, conn);

            conn.Open();
            inserCommand.ExecuteNonQuery();
        }
    }
}