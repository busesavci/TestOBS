using System;    
using System.Collections.Generic;    
using System.Data;    
using System.Data.SqlClient;    
using System.Linq;    
using System.Threading.Tasks;    
    
namespace _1._3.Models    
{    
    public class EmployeeDataAccessLayer    
    {    
        string connectionString = "Data Source=DESKTOP-IAP563V;" + "Database=Employee;" + "Trusted_Connection=true;";    
    
        //To View all Employees details      
        public IEnumerable<Employee> GetAllEmployees()    
        {    
            List<Employee> lstEmployee = new List<Employee>();    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                con.Open();    
                SqlDataReader rdr = cmd.ExecuteReader();    
    
                while (rdr.Read())    
                {    
                    Employee Employee = new Employee();    
    
                    Employee.ID = Convert.ToInt32(rdr["EmployeeID"]);    
                    Employee.Name = rdr["Name"].ToString();    
                    Employee.Gender = rdr["Gender"].ToString();    
                    Employee.Department = rdr["Department"].ToString();    
                    Employee.City = rdr["City"].ToString();    
    
                    lstEmployee.Add(Employee);    
                }    
                con.Close();    
            }    
            return lstEmployee;    
        }    
    
        //To Add new Employee record      
        public void AddEmployee(Employee Employee)    
        {    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@Name", Employee.Name);    
                cmd.Parameters.AddWithValue("@Gender", Employee.Gender);    
                cmd.Parameters.AddWithValue("@Department", Employee.Department);    
                cmd.Parameters.AddWithValue("@City", Employee.City);    
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }    
    
        //To Update the records of a particluar Employee    
        public void UpdateEmployee(Employee Employee)    
        {    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@EmpId", Employee.ID);    
                cmd.Parameters.AddWithValue("@Name", Employee.Name);    
                cmd.Parameters.AddWithValue("@Gender", Employee.Gender);    
                cmd.Parameters.AddWithValue("@Department", Employee.Department);    
                cmd.Parameters.AddWithValue("@City", Employee.City);    
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }    
    
        //Get the details of a particular Employee    
        public Employee GetEmployeeData(int? id)    
        {    
            Employee Employee = new Employee();    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                string sqlQuery = "SELECT * FROM tblEmployee WHERE EmployeeID= " + id;    
                SqlCommand cmd = new SqlCommand(sqlQuery, con);    
    
                con.Open();    
                SqlDataReader rdr = cmd.ExecuteReader();    
    
                while (rdr.Read())    
                {    
                    Employee.ID = Convert.ToInt32(rdr["EmployeeID"]);    
                    Employee.Name = rdr["Name"].ToString();    
                    Employee.Gender = rdr["Gender"].ToString();    
                    Employee.Department = rdr["Department"].ToString();    
                    Employee.City = rdr["City"].ToString();    
                }    
            }    
            return Employee;    
        }    
    
        //To Delete the record on a particular Employee    
        public void DeleteEmployee(int? id)    
        {    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@EmpId", id);    
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }    
    }    
}