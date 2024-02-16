using PERFILES.BusinessLayer;
using PERFILES.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PERFILES
{
    public partial class Departments : System.Web.UI.Page
    {
        DepartmentBL _DepartmentBL = new DepartmentBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowDepartments();
        }

        private void ShowDepartments()
        {
            List<Department> departments = _DepartmentBL.DepartmentList();

            GVDepartment.DataSource = departments;
            GVDepartment.DataBind();
        }

        protected void Edit_Department_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            string id = button.CommandArgument;

            Response.Redirect($"~/ActionDepartment.aspx?id={id}");
        }

        protected void New_Department_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ActionDepartment.aspx?id=0");
        }

    }
}