using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace connecting
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = GetConnectionString();
            string query1 = "select * from empdetails where ccode= 'C001' ";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd1 = new SqlCommand(query1, cn); cn.Open();
                using (SqlDataReader dr1 = cmd1.ExecuteReader())
                {
                    while (dr1.Read())
                    {
                        string query2 = "UPDATE empdetails SET cname='Maguire' where ccode= 'C001'";
                        SqlCommand cmd2 = new SqlCommand(query2, cn);
                        cmd2.ExecuteNonQuery();
                        Console.WriteLine("Data has been update");

                    }
                }
            }
            Console.ReadLine();
        }

        private static string GetConnectionString()
        {
            return "data source = DESKTOP-E0JBM6N\\EGY;database=HR;MultipleActiveResultSets=True;User ID=sa;Password=egyputradbncr78 ";
        }
    }
}
