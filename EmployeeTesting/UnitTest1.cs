using NUnit.Framework;
using Emp_Payroll_Multitherading;
using System;

namespace EmployeeTesting
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            EmployeePayroll employeePayroll;
            
        }

        [Test]
        public void AddEmpDetails()
        {
            Employee emp = new Employee();
            EmployeePayroll employeePayroll = new EmployeePayroll();
            emp.Emp_Id = 101;
            emp.Emp_Name = "Sumathi";
            emp.Salary = 70000;
            string JD = "2022-04-26";
            System.DateTime Joindate = Convert.ToDateTime(JD);
            emp.Joining_Date = Joindate;
            emp.Gender = "F";
            emp.Department = "Sales";
            emp.Address = "tamilnadu";
            emp.Deductions = 10000;
            emp.Taxable_Pay = 1000;
            emp.Income_Tax = 2000;
            emp.Net_Pay = 50000;
            var res = employeePayroll.Add_Contact(emp);
            Assert.AreEqual(true, true);
        }
        public void AddempDetailsUseThreades()
        {
            Employee emp = new Employee();
           
        }
    }
}