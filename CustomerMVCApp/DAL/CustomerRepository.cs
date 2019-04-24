using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CustomerMVCApp.Models;

namespace CustomerMVCApp.DAL
{
    public class CustomerRepository
    {
        private static string _conStr = @"Server=DESKTOP-QM2HHBJ\SQLEXPRESS; Database=SHOPDB; Integrated Security=true";
        static SqlConnection sqlConnection = new SqlConnection(_conStr);
        SqlCommand sqlCommand = new SqlCommand("", sqlConnection);

        public bool AddCustomer(Customer customer)
        {
            bool isSave=false;
            string query = @"insert into Customers (Name,Code,Address,Email,Contact,Age,LoyalityPoint)
                    values('" + customer.Name + "'," + customer.Code + ",'" + customer.Address + "','" + customer.Email + "'," +
                           "'" + customer.Contact + "'," + customer.Age + "," + customer.LoyalityPoint + ")";
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            int ext = sqlCommand.ExecuteNonQuery();
            if (ext > 0)
            {
                isSave = true;
            }
            else
            {
                isSave = false;
            }
            sqlConnection.Close();
            return isSave;
        }
        public bool DeleteCustomer(int code)
        {
            bool isDelete = false;
            string query = @"delete from Customers where Code='"+code+"'";
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            int ext = sqlCommand.ExecuteNonQuery();
            if (ext > 0)
            {
                isDelete = true;
            }
            else
            {
                isDelete = false;
            }
            sqlConnection.Close();
            return isDelete;
        }
        public bool UpdateCustomer(Customer customer)
        {
            bool isUpdate = false;
            string query = @"update Customers set Name='" + customer.Name + "',Code=" + customer.Code + ",Address=" +
                           "'" + customer.Address + "',Email='" + customer.Email + "',Contact='" + customer.Contact +
                           "',Age=" + customer.Age + ",LoyalityPoint=" + customer.LoyalityPoint + " where Code=" +
                           customer.Code + "";
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            int ext = sqlCommand.ExecuteNonQuery();
            if (ext > 0)
            {
                isUpdate = true;
            }
            else
            {
                isUpdate = false;
            }
            sqlConnection.Close();
            return isUpdate;
        }
        public DataTable ShowCustomer()
        {
            DataTable data=new DataTable();
            string query = @"Select * from Customers";
            SqlDataAdapter sqlDataAdapter=new SqlDataAdapter(query,sqlConnection);
            sqlDataAdapter.Fill(data);
            sqlConnection.Close();
            return data;
        }
    }
}