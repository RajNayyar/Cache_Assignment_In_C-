using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cacheAssignment
{
    class DBRepository : IRepository
    {
        public List<Product> GetAllProducts()
        {
            List<Product> CarList = new List<Product>();
            SqlConnection sqlConnection = null;
            try
            {
                Console.WriteLine("Retrieving from Database");
                sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = @"Data Source=TAVDESK154;Initial Catalog=BookingDB;User Id=sa; Password=test123!@#";
                string query = "SELECT * FROM Car";
                SqlCommand command = new SqlCommand(query, sqlConnection)
                {
                    CommandType = CommandType.Text
                };
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                sqlConnection.Open();
                da.Fill(dt);
                sqlConnection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    CarList.Add(
                        new Product
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Name = Convert.ToString(dr["Name"]),
                            Price = (int)Convert.ToInt32(dr["Price"])
                        }
                    );

                }
                return CarList;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                sqlConnection.Close();
            }
            return CarList;
        }

        public Product GetProductById(int id)
        {
            Console.WriteLine("Retrieving from Database");
            SqlConnection sqlConnection = null;
            List<Product> CarList = new List<Product>();
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Data Source=TAVDESK154;Initial Catalog=BookingDB;User Id=sa; Password=test123!@#";

            string query = "SELECT * FROM Car where Id=" + id;
            SqlCommand command = new SqlCommand(query, sqlConnection)
            {
                CommandType = CommandType.Text
            };
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            da.Fill(dt);
            sqlConnection.Close();
           
            foreach (DataRow dr in dt.Rows)
            {
                CarList.Add(
                    new Product
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Price = (float)Convert.ToDouble(dr["Price"])
                    }
                );

            }
            return CarList[0];
        }
    }
}
