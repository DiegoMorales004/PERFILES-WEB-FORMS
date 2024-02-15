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
    internal class DepartmentDL
    {

        //Get all departments
        public List<Department> DepartmentsList()
        {

            List<Department> list = new List<Department>();

            using (SqlConnection localConnection = new SqlConnection(Connection.connection))
            {
                SqlCommand cmd = new SqlCommand("exec SP_ReadDepartment", localConnection);
                cmd.CommandType = CommandType.Text;
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

    }
}
