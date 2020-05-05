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
    public class CustomerController : ApiController
    {
        // GET api/<controller>
        private SqlConnection conn = new SqlConnection("Server=tcp:myservereasj.database.windows.net,1433;Initial Catalog=mydatabase;Persist Security Info=False;User ID=Serveradmin;Password=Test12345; Connection Timeout=30;");



        //GET api/Customer
        [ActionName("GetAllCustomer")]
        public List<Customer> GetAllCustomer()
        {
            var list = new List<Customer>();
            var query = "SELECT * FROM Customer";
            conn.Open();

            using (var command = new SqlCommand(query, conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Customer
                    {
                        CustomerId = reader.GetInt32(0),
                        Cpr = reader.GetString(1),
                        Name = reader.GetString(2),
                        BankId = reader.GetInt32(3)

                    });
                }
                reader.Close();
            }
            return list;
        }

        // GET api/Customer/<cprnummer>
        [ActionName("GetCusomterByCPR")]
        public Customer GetCusomterByCPR(int cpr)
        {
            Customer customer = new Customer();
            var query = "SELECT * FROM Customer";
            conn.Open();
            using (var command = new SqlCommand(query, conn))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                   if(cpr == reader.GetInt32(1))
                    {
                        Customer customer1 = new Customer()
                        {
                            CustomerId = reader.GetInt32(0),
                            Cpr = reader.GetString(1),
                            Name = reader.GetString(2),
                            BankId = reader.GetInt32(3)

                        };
                        customer = customer1;
                    }
                }
                reader.Close();
            }
            return customer;
        }

        // POST api/<controller>
        public void Post([FromBody]Customer customer)
        {
            var query = "INSERT INTO Customer (Cpr, Name, BankId) VALUES(@Cpr, @Name, @BankId)";

            SqlCommand inserCommand = new SqlCommand(query, conn);
            inserCommand.Parameters.AddWithValue("@Cpr", customer.Cpr);
            inserCommand.Parameters.AddWithValue("@Name", customer.Name);
            inserCommand.Parameters.AddWithValue("@BankId", customer.BankId);
 
            conn.Open();
            inserCommand.ExecuteNonQuery();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
           
        }

        // DELETE api/<controller>/5
        [ActionName("DeleteCustomer")]
        public void Delete(int customerId)
        {
            var query = $"DELETE FROM Customer FROM Account AS Customer WHERE customerId = '{customerId}';" + 
                $"DELETE FROM Customer WHERE customerId = '{customerId}'";

            SqlCommand inserCommand = new SqlCommand(query, conn);

            conn.Open();
            inserCommand.ExecuteNonQuery();
        }
    }
}