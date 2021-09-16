using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SqlCommand_ExecuteNonQuery
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
                using (con = new SqlConnection(cs))
                {
                  

                    Console.WriteLine("Enter a Employee Name: ");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter CGPA : ");
                   string cgpa =  Console.ReadLine();



                    string query = "insert into Students values(@name; @cgpa)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@cgpa", cgpa);

                    con.Open();
                    var a= cmd.ExecuteNonQuery();
                    if (a>0)
                    {
                        Console.WriteLine("Data has been inserted Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Failed");
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
