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

    }
}