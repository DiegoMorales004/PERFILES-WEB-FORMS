using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PERFILES.EntityLayer;
using System.Data;
using System.Data.SqlClient;

namespace PERFILES.DataLayer
{
    public class EmployeeDL
    {

        //Create employee
        public bool CreateEmployee(Employee employee)
        {

            using (SqlConnection localConnection = new SqlConnection(Connection.connection))
            {
                SqlCommand cmd = new SqlCommand("SP_CreateEmployee", localConnection);

                AddWithValue(ref cmd, employee, false);

                try
                {
                    bool Created = DepartmentDL.CheckRowsAffected(localConnection, ref cmd);
                    return Created;

                }
                catch (Exception e)
                {
                    throw e;
                }

            }

        }

        //Get one employee
        public Employee GetEmployee(int Id) {  
            Employee employee = new Employee();

            using (SqlConnection localConnection = new SqlConnection(Connection.connection))
            {
                SqlCommand cmd = new SqlCommand("SP_ReadOneEmployee", localConnection);
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    localConnection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if( reader.Read())
                        {
                            employee.Id = Convert.ToInt32(reader["ID"].ToString());
                            employee.Names = reader["names"].ToString();
                            employee.DPI = reader["DPI"].ToString();
                            employee.BirthDate = reader["birthDate"].ToString();
                            employee.Gender = Convert.ToChar(reader["gender"].ToString());
                            employee.Admission = reader["admission"].ToString();
                            employee.Age = Convert.ToInt32(reader["age"].ToString());
                            employee.HomeAddress = reader["homeAddress"].ToString();
                            employee.NIT = reader["NIT"].ToString();

                            employee.Department = new Department()
                            {
                                Id = Convert.ToInt32(reader["idDepartament"].ToString()),
                                Name = reader["departmentName"].ToString(),
                                Description = reader["departmentDescription"].ToString()
                            };

                        }
                    }

                    return employee;

                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }

        //Get all employees
        public List<Employee> EmployeesList()
        {

            List<Employee> list = new List<Employee>();

            using (SqlConnection localConnection = new SqlConnection(Connection.connection))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM viewEmployeesAndDepartment", localConnection);
                cmd.CommandType = CommandType.Text;
                try
                {
                    localConnection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(
                                new Employee
                                {
                                    Id = Convert.ToInt32(reader["id"].ToString()),
                                    Names = reader["names"].ToString(),
                                    DPI = reader["DPI"].ToString(),
                                    BirthDate = reader["birthDate"].ToString(),
                                    Gender = Convert.ToChar(reader["gender"].ToString()),
                                    Admission = reader["admission"].ToString(),
                                    Age = Convert.ToInt32(reader["age"].ToString()),
                                    HomeAddress = reader["homeAddress"].ToString(),
                                    NIT = reader["NIT"].ToString(),
                                    Department = new Department()
                                    {
                                        Id = Convert.ToInt32(reader["id"].ToString()),
                                        Name = reader["departmentName"].ToString(),
                                        Description = reader["departmentDescription"].ToString()
                                    }
                                });
                        }
                    }

                    return list;

                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }

        public List<Employee> EmployeesListByDepartment(int idDepartment)
        {

            List<Employee> list = new List<Employee>();

            using (SqlConnection localConnection = new SqlConnection(Connection.connection))
            {
                SqlCommand cmd = new SqlCommand("SP_ReadEmployeesByDepartment", localConnection);

                cmd.Parameters.AddWithValue("@idDepartment", idDepartment);

                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    localConnection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(
                                new Employee
                                {
                                    Id = Convert.ToInt32(reader["id"].ToString()),
                                    Names = reader["names"].ToString(),
                                    DPI = reader["DPI"].ToString(),
                                    BirthDate = reader["birthDate"].ToString(),
                                    Gender = Convert.ToChar(reader["gender"].ToString()),
                                    Admission = reader["admission"].ToString(),
                                    Age = Convert.ToInt32(reader["age"].ToString()),
                                    HomeAddress = reader["homeAddress"].ToString(),
                                    NIT = reader["NIT"].ToString(),
                                    Department = new Department()
                                    {
                                        Id = Convert.ToInt32(reader["id"].ToString()),
                                        Name = reader["departmentName"].ToString(),
                                        Description = reader["departmentDescription"].ToString()
                                    }
                                });
                        }
                    }

                    return list;

                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }

        //Update employee
        public bool UpdateEmployee(Employee employee)
        {


            using (SqlConnection localConnection = new SqlConnection(Connection.connection))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateEmployee", localConnection);

                AddWithValue(ref cmd, employee, true);


                try
                {
                    bool Updated = DepartmentDL.CheckRowsAffected(localConnection, ref cmd);
                    return Updated;

                }
                catch (Exception e)
                {
                    throw e;
                }

            }

        }

        //Delete employee
        public bool DeleteEmployee(int id)
        {

            using (SqlConnection localConnection = new SqlConnection(Connection.connection))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteEmployee", localConnection);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    bool Deleted = DepartmentDL.CheckRowsAffected( localConnection, ref cmd);
                    return Deleted;

                }
                catch(Exception e)
                {
                    throw e;
                }

            }
        }

        // Process of adding information to the stored procedure
        private void AddWithValue(ref SqlCommand cmd, Employee employee, bool update)
        {

            if (update) cmd.Parameters.AddWithValue("@id", employee.Id);

            cmd.Parameters.AddWithValue("@names", employee.Names);
            cmd.Parameters.AddWithValue("@DPI", employee.DPI);
            cmd.Parameters.AddWithValue("@birthDate", employee.BirthDate);
            cmd.Parameters.AddWithValue("@gender", employee.Gender);
            cmd.Parameters.AddWithValue("@admission", employee.Admission);
            cmd.Parameters.AddWithValue("@age", employee.Age);
            cmd.Parameters.AddWithValue("@homeAddress", employee.HomeAddress);
            cmd.Parameters.AddWithValue("@NIT", employee.NIT);
            cmd.Parameters.AddWithValue("@department", employee.Department.Id);

            cmd.CommandType = CommandType.StoredProcedure;

        }

    }
}
