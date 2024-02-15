using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PERFILES.DataLayer;
using PERFILES.EntityLayer;

namespace PERFILES.BusinessLayer
{
    public class DepartmentBL
    {
        DepartmentDL DepartmentDL = new DepartmentDL();

        //Get one department
        public Department GetOneDepartment(int id)
        {
            try
            {

                return DepartmentDL.GetDepartment(id);

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        //Get list of Department
        public List<Department> DepartmentList()
        {
            try
            {

                return DepartmentDL.DepartmentsList();

            }catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
