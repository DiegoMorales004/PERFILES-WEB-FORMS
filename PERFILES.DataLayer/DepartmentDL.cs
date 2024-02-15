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
    public class DepartmentDL
    {

        //Create department
        public bool CreateDepartment(Department department)
        {
            using(SqlConnection localConnection =  new SqlConnection(Connection.connection))
            {

                SqlCommand cmd = new SqlCommand("SP_CreateDepartment", localConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddWithValue(ref cmd, department, false);

                try
                {

                    bool Created = CheckRowsAffected(localConnection, ref cmd);
                    return Created;

                }catch(Exception ex)
                {
                    throw ex;
                }

            }
        }

        //Get one department
        public Department GetDepartment(int id)
        {
            Department Department = new Department();

            using(SqlConnection localConnection = new SqlConnection(Connection.connection))
            {
                SqlCommand cmd = new SqlCommand("SP_ReadOneDepartment", localConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    
                    localConnection.Open();

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Department.Id = Convert.ToInt32(reader["id"].ToString());
                            Department.Name = reader["name"].ToString();
                            Department.Description = reader["description"].ToString();

                        }
                    }

                    return Department;

                }
                catch(Exception e)
                {
                    throw e;
                }

            }

        }

        //Get all departments
        public List<Department> DepartmentsList()
        {

            List<Department> list = new List<Department>();

            using (SqlConnection localConnection = new SqlConnection(Connection.connection))
            {
                SqlCommand cmd = new SqlCommand("SP_ReadDepartment", localConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                try {
                    localConnection.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(
                                new Department()
                                {
                                    Id = Convert.ToInt32(reader["id"].ToString()),
                                    Name = reader["name"].ToString(),
                                    Description = reader["description"].ToString()
                                });
                        }
                    }

                    return list;

                } catch(Exception e) {
                    throw e;
                }
            }

        }

        //Update department
        public bool UpdateDepartment(Department department)
        {
            using(SqlConnection localConnection = new SqlConnection())
            {
                
                SqlCommand cmd = new SqlCommand("SP_UpdateDepartment", localConnection);

                AddWithValue(ref cmd, department, true);

                try
                {

                    bool Updated = CheckRowsAffected(localConnection, ref cmd);
                    return Updated;

                }catch(Exception e)
                {
                    throw e;
                }

            }
        }

        //Delete department
        public bool DeleteDeparment(int id)
        {
            using (SqlConnection localConnection = new SqlConnection(Connection.connection))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteDepartment", localConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    bool Deleted = CheckRowsAffected(localConnection, ref cmd);
                    return Deleted;
                }catch(Exception ex)
                {
                    throw ex;
                }

            }
        }

        // Process of adding information to the stored procedure
        private void AddWithValue(ref SqlCommand cmd, Department department, bool update)
        {

            if (update) cmd.Parameters.AddWithValue("@id", department.Id);

            cmd.Parameters.AddWithValue("@name", department.Name);
            cmd.Parameters.AddWithValue("@description", department.Description);

        }

        //Open the connection to the database and verify if the command was executed successfully
        public static bool CheckRowsAffected(SqlConnection localConnection, ref SqlCommand cmd)
        {
            localConnection.Open();

            int RowsAffected = cmd.ExecuteNonQuery();
            if (RowsAffected > 0) return true;

            return false;
        }

    }
}
