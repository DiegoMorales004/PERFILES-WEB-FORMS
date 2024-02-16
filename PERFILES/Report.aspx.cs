using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PERFILES.EntityLayer;
using PERFILES.BusinessLayer;

namespace PERFILES
{
    public partial class Report : System.Web.UI.Page
    {

        EmployeeBL _EmployeeBL = new EmployeeBL();
        DepartmentBL DepartmentBL = new DepartmentBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowEmployees();
                LoadDepartment();
            }
        }

        //Load all employees
        private void ShowEmployees()
        {
            List<Employee> employees = _EmployeeBL.GetEmployees();

            GVEmployees.DataSource = employees;
            GVEmployees.DataBind();
        }

        //Load departments
        private void LoadDepartment()
        {
            List<Department> departments = DepartmentBL.DepartmentList();
            departments.Insert(0, new Department()
            {
                Name = "Seleccionar..."
            });

            //Show value
            ddlDepartment.DataTextField = "Name";
            //Save value
            ddlDepartment.DataValueField = "Id";

            ddlDepartment.DataSource = departments;
            ddlDepartment.DataBind();

        }

        //Execute filters
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            List<Employee> employees = _EmployeeBL.GetEmployees();

            //Filter by department
            if (ddlDepartment.SelectedValue != "0")
            {
                employees = FilterByDepartment( Convert.ToInt32(ddlDepartment.SelectedValue));
            }
                GVEmployees.DataSource = employees;
                GVEmployees.DataBind();


        }

        //Filter by Department
        private List<Employee> FilterByDepartment(int departmentId)
        {
            List<Employee> employeesByDepartment = _EmployeeBL.GetEmployeesByDepartment(departmentId);

            return employeesByDepartment;
        }

    }
}