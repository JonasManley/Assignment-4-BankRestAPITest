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
    public class BankController : ApiController
    {
        private SqlConnection conn = new SqlConnection("Server=tcp:myservereasj.database.windows.net,1433;Initial Catalog=mydatabase;Persist Security Info=False;User ID=Serveradmin;Password=Test12345; Connection Timeout=30;");

        // GET api/<controller>
        [ActionName("GetAllBanks")]
        public List<Bank> GetAllBanks()
        {
            var list = new List<Bank>();
            var query = "SELECT * FROM Customer";
            conn.Open();

            using (var command = new SqlCommand(query, conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Bank
                    {
                        BankId = reader.GetInt32(0),
                        Cvr = reader.GetString(1),
                        Name = reader.GetString(2)
                    });
                }
                reader.Close();
            }
            return list;
        }

        // GET api/<controller>/5
        [ActionName("GetBankByCVR")]
        public Bank GetBankByCVR(int cvr)
        {
            Bank bank = new Bank();
            var query = "SELECT * FROM Bank";
            conn.Open();
            using (var command = new SqlCommand(query, conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (cvr == reader.GetInt32(0))
                    {
                        Bank bankHolder = new Bank()
                        {
                        BankId = reader.GetInt32(0),
                        Cvr = reader.GetString(1),
                        Name = reader.GetString(2)
                        };
                        bank = bankHolder;
                    }
                }
                reader.Close();
            }
            return bank;
        }

        // POST api/<controller>
        public void Post([FromBody]Bank bank)
        {
            var query = "INSERT INTO Bank (Cvr, Name) VALUES(@Cpv, @Name)";

            SqlCommand inserCommand = new SqlCommand(query, conn);
            inserCommand.Parameters.AddWithValue("@Cpv", bank.Cvr);
            inserCommand.Parameters.AddWithValue("@Name", bank.Name);

            conn.Open();
            inserCommand.ExecuteNonQuery();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [ActionName("DeleteBank")]
        public void DeleteBank(int bankId)
        {
            var query = $"DELETE FROM Bank WHERE bankId = '{bankId}';";

            SqlCommand inserCommand = new SqlCommand(query, conn);

            conn.Open();
            inserCommand.ExecuteNonQuery();
        }
    }
}