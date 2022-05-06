using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Emp_Payroll_Multitherading
{
    public class EmployeePayroll
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Employee_payroll; Integrated Security=SSPI;";
        static SqlConnection connection = new SqlConnection(connectionString);
        public bool Add_Contact(Employee emp)
        {
            List<Employee> employees = new List<Employee>();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string spname = "dbo.AddEmployee";
                    SqlCommand Command = new SqlCommand(spname, connection);
                    Command.Parameters.AddWithValue("@Emp_Id", emp.Emp_Id);
                    Command.Parameters.AddWithValue("@Emp_Name", emp.Emp_Name);
                    Command.Parameters.AddWithValue("@Salary", emp.Salary);
                    Command.Parameters.AddWithValue("@Joining_Date", emp.Joining_Date);
                    Command.Parameters.AddWithValue("@Gender", emp.Gender);
                    Command.Parameters.AddWithValue("@Department", emp.Department);
                    Command.Parameters.AddWithValue("@Address", emp.Address);
                    Command.Parameters.AddWithValue("@Pnone_number", emp.Phone_number);
                    Command.Parameters.AddWithValue("@Deductions", emp.Deductions);
                    Command.Parameters.AddWithValue("@Taxable_Pay", emp.Taxable_Pay);
                    Command.Parameters.AddWithValue("@Income_Tax", emp.Income_Tax);
                    Command.Parameters.AddWithValue("@Net_Pay", emp.Net_Pay);
                    Console.WriteLine(emp.Emp_Name + "," + emp.Salary + "," + emp.Joining_Date +
                                "," + emp.Gender + "," + emp.Department + emp.Address + "," + emp.Deductions + "," + emp.Taxable_Pay +
                                "," + emp.Income_Tax + "," + emp.Net_Pay);

                    connection.Open();
                    var result = Command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;

                }
                connection.Close();
            }
            catch (EmployeeException)
            {
                throw new EmployeeException(EmployeeException.ExceptionType.No_Data_Found, "Contact not added...");
            }



        }
    }
}