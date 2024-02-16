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

        //Create department
        public bool CreateDepartment(Department department)
        {
            try
            {
                CheckParametersDepartment(department);
                return DepartmentDL.CreateDepartment(department);
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        //Get one department
        public Department GetOneDepartment(int id)
        {
            try
            {

                Department find = DepartmentDL.GetDepartment(id);
                if(find == null || find.Id == 0)
                {
                    throw new OperationCanceledException("The department does not exist.");
                }

                return find;

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

        //Update department
        public bool UpdateDepartment(Department department)
        {
            try
            {
                this.GetOneDepartment(department.Id);
                CheckParametersDepartment(department);

                return DepartmentDL.UpdateDepartment(department);

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        //Check params of the department
        private void CheckParametersDepartment(Department department)
        {
            if (department.Name == "" || department.Name == null)
                throw new OperationCanceledException("The name cannot be void.");

            if (department.Description == "" || department.Description == null)
                throw new OperationCanceledException("The Description cannot be void.");
        }

    }
}
