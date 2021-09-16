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
                    con.Open();

                    if (con.State == ConnectionState.Open)
                    {
                        Console.WriteLine("Connected");
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
