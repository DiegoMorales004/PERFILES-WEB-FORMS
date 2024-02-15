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
    public partial class _Default : Page
    {

        EmployeeBL _EmployeeBL = new EmployeeBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowEmployees();
        }

        private void ShowEmployees()
        {
            List<Employee> employees = _EmployeeBL.GetEmployees();

            GVEmployees.DataSource = employees;
            GVEmployees.DataBind();
        }

        protected void New_Employee_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Contact.aspx?id=0");
        }

        protected void Edit_Employee_Click(object sender, EventArgs e)
        {

            LinkButton button = (LinkButton)sender;
            string id = button.CommandArgument;

            Response.Redirect($"~/Contact.aspx?id={id}");
        }

        protected void Delete_Employee_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            string id = button.CommandArgument;

            bool deleted = _EmployeeBL.DeleteEmployee( Convert.ToInt32(id) );

            if(deleted )
                ShowEmployees();
            
        }

    }
}