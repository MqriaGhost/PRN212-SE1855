using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
namespace DataAccessLayer
{
    public class CustomerDAO
    {
        static List<Customer> customers=new List<Customer>();
        public void GenerateSampleDataset()
        {
            customers.Add(new Customer() { Id=1,Name="Obama",Phone="0981234567"});
            customers.Add(new Customer() { Id = 2, Name = "Putin", Phone = "0982309090" });
            customers.Add(new Customer() { Id = 3, Name = "Trump", Phone = "0902345321" });
            customers.Add(new Customer() { Id = 4, Name = "Kim", Phone = "0981873631" });
            customers.Add(new Customer() { Id = 5, Name = "Jong", Phone = "0987654321" });
        }
        public List<Customer> GetCustomers() { 
            return customers;
        }
    }
}
