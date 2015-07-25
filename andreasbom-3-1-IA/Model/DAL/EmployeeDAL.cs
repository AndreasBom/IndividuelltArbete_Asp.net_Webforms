using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using andreasbom_3_1_IA.Model.BLL;

namespace andreasbom_3_1_IA.Model.DAL
{
    public class EmployeeDAL : DALBase
    {

        //Returns employee
        public Employee GetEmployeeById(int empId)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    //Sql command, using a stored procedure with one parameter
                    var cmd = new SqlCommand("IA.uspGetEmployeeById", conn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.Add("@EmpID", SqlDbType.Int, 4).Value = empId;

                    conn.Open();

                    //Creating new object with data from database
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Get index for columns
                            int empIdIndex = reader.GetOrdinal("EmpID");
                            int empCodeIndex = reader.GetOrdinal("EmpCode");
                            int firstNameIndex = reader.GetOrdinal("FirstName");
                            int lastNameIndex = reader.GetOrdinal("LastName");
                            int birthNoIndex = reader.GetOrdinal("BirthNo");
                            int streetIndex = reader.GetOrdinal("Street");
                            int postNoIndex = reader.GetOrdinal("PostNo");
                            int cityIndex = reader.GetOrdinal("City");
                            int phoneNoIndex = reader.GetOrdinal("PhoneNo");

                            return new Employee
                            {
                                EmpID = reader.GetInt32(empIdIndex),
                                EmpCode = reader.GetString(empCodeIndex),
                                FirstName = reader.GetString(firstNameIndex),
                                LastName = reader.GetString(lastNameIndex),
                                BirthNo = reader.GetString(birthNoIndex),
                                Street = reader.GetString(streetIndex),
                                PostNo = reader.GetString(postNoIndex),
                                City = reader.GetString(cityIndex),
                                PhoneNo = reader.GetString(phoneNoIndex)
                            };
                        }
                    }
                    //Returns null if no Employee is found 
                    return null;
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data layer while fetching Employee");
                }

            }
        }

        //Returns all employees
        public IEnumerable<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>(100);
            try
            {
                using (var conn = CreateConnection())
                {
                    var cmd = new SqlCommand("IA.uspGetAllEmployees", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Get index for columns
                            int empIdIndex = reader.GetOrdinal("EmpID");
                            int empCodeIndex = reader.GetOrdinal("EmpCode");
                            int firstNameIndex = reader.GetOrdinal("FirstName");
                            int lastNameIndex = reader.GetOrdinal("LastName");
                            int birthNoIndex = reader.GetOrdinal("BirthNo");
                            int streetIndex = reader.GetOrdinal("Street");
                            int postNoIndex = reader.GetOrdinal("PostNo");
                            int cityIndex = reader.GetOrdinal("City");
                            int phoneNoIndex = reader.GetOrdinal("PhoneNo");

                            employees.Add(new Employee
                            {
                                EmpID = reader.GetInt32(empIdIndex),
                                EmpCode = reader.GetString(empCodeIndex),
                                FirstName = reader.GetString(firstNameIndex),
                                LastName = reader.GetString(lastNameIndex),
                                BirthNo = reader.GetString(birthNoIndex),
                                Street = reader.GetString(streetIndex),
                                PostNo = reader.GetString(postNoIndex),
                                City = reader.GetString(cityIndex),
                                PhoneNo = reader.GetString(phoneNoIndex)
                            });
                        }
                    }

                    employees.TrimExcess();

                    return employees;
                }

            }
            catch (Exception)
            {
                throw new ApplicationException("An error occured in the data layer while fetching employees");
            }
        }


        //Delete employee
        public void DeleteEmployee(int empId)
        {
            //Exception handling is done in presentation layer
            using (var conn = CreateConnection())
            {
                var cmd = new SqlCommand("IA.uspDeleteEmployee", conn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.Add("@EmpID", SqlDbType.Int, 4).Value = empId;

                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }


        //Insert employee
        public void InsertEmployee(Employee employee)
        {
            try
            {
                using (var conn = CreateConnection())
                {
                    var cmd = new SqlCommand("IA.uspInsertEmployeeDetails", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //Parameters
                    cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 6).Value = employee.EmpCode;
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 20).Value = employee.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 20).Value = employee.LastName;
                    cmd.Parameters.Add("@BirthNo", SqlDbType.VarChar, 11).Value = employee.BirthNo;
                    cmd.Parameters.Add("@Street", SqlDbType.VarChar, 25).Value = employee.Street;
                    cmd.Parameters.Add("@PostNo", SqlDbType.VarChar, 5).Value = employee.PostNo;
                    cmd.Parameters.Add("@City", SqlDbType.VarChar, 20).Value = employee.City;
                    cmd.Parameters.Add("@PhoneNo", SqlDbType.VarChar, 15).Value = employee.PhoneNo;
                    cmd.Parameters.Add("@EmpID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    
                    conn.Open();

                    cmd.ExecuteNonQuery();

                    employee.EmpID = (int)cmd.Parameters["@EmpID"].Value;
                }
            }
            catch
            {
                throw new ApplicationException("An error occured in the data layer while inserting employee");
            }
        }

        //Update employee
        public void UpdateEmployee(Employee employee)
        {
            try
            {
                using (var conn = CreateConnection())
                {
                    var cmd = new SqlCommand("IA.uspUpdateEmployee", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    //Parameters
                    cmd.Parameters.Add("@EmpID", SqlDbType.Int, 4).Value = employee.EmpID;
                    cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 6).Value = employee.EmpCode;
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 20).Value = employee.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 20).Value = employee.LastName;
                    cmd.Parameters.Add("@BirthNo", SqlDbType.VarChar, 11).Value = employee.BirthNo;
                    cmd.Parameters.Add("@Street", SqlDbType.VarChar, 25).Value = employee.Street;
                    cmd.Parameters.Add("@PostNo", SqlDbType.VarChar, 5).Value = employee.PostNo;
                    cmd.Parameters.Add("@City", SqlDbType.VarChar, 20).Value = employee.City;
                    cmd.Parameters.Add("@PhoneNo", SqlDbType.VarChar, 15).Value = employee.PhoneNo;
                    
                    

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new ApplicationException("An error occured in the data layer while updating employee");
            }

        }


    }//
}//