using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SQLCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.connection();
            Console.ReadKey();
        }

       static void connection()
        {
            
    
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection con = null;

            

            try
            {
                using (con=new SqlConnection(cs) )
                {
                    string query = "select * from Students";
                    SqlCommand cmd = new SqlCommand(query,con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Console.WriteLine($"Id: {dr["Id"]} Name: {dr["Name"]} DateOfBirth: {dr ["DateOfbirth"]} CGPA: {dr["CGPA"]}");
                    }
                    
                }
               
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }

            finally
            {
                con.Close();
            }

           
        }
    }
}
