using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PERFILES.EntityLayer;
using PERFILES.BusinessLayer;
using System.Globalization;

namespace PERFILES
{
    public partial class Contact : Page
    {

        private static int id = 0;
        DepartmentBL DepartmentBL = new DepartmentBL();
        EmployeeBL EmployeeBL = new EmployeeBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {

                    id = Convert.ToInt32(Request.QueryString["id"]);

                    if(id != 0)
                    {

                        lblTitle.Text = "Editar empleado";
                        btnSubmit.Text = "Editar";

                        //Search employee
                        Employee employee = EmployeeBL.GetEmployee(id);

                        //Fill text area with old data
                        txtNames.Text = employee.Names;
                        txtDPI.Text = employee.DPI;
                        txtBirthDate.Text = Convert.ToDateTime(employee.BirthDate, new CultureInfo("es-GT")).ToString("yyyy-MM-dd");
                        txtAdmission.Text = Convert.ToDateTime(employee.Admission, new CultureInfo("es-GT")).ToString("yyyy-MM-dd");
                        txtHomeAddress.Text = employee.HomeAddress;
                        txtNIT.Text = employee.NIT.ToString();

                        //Fill the DropDownLists
                        LoadGender(employee.Gender.ToString());
                        LoadDepartment(employee.Department.Id.ToString());

                    }else
                    {
                        lblTitle.Text = "Registrar empleado";
                        btnSubmit.Text = "Guardar";

                        //Fill DropDownList
                        LoadDepartment("");
                        LoadGender("");

                    }
                }
                else
                {
                    //Redirect if the parameter not exist
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        private void LoadDepartment(string idDepartment)
        {
            List<Department> departments = DepartmentBL.DepartmentList();

            //Show value
            ddlDepartment.DataTextField = "name";
            //Save value
            ddlDepartment.DataValueField = "id";

            ddlDepartment.DataSource = departments; 
            ddlDepartment.DataBind();

            //Default value
            if( idDepartment != null )
            {
                ddlDepartment.SelectedValue = idDepartment;
            }

        }

        private void LoadGender(string gender)
        {

            List<char> genders = new List<char>() { 'M', 'F' };

            ddlGenders.DataSource = genders;
            ddlGenders.DataBind();

            if( genders != null )
            {
                ddlGenders.SelectedValue = gender;
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            Employee employee = new Employee()
            {
                Id = id,
                Names = txtNames.Text,
                DPI = txtDPI.Text,
                BirthDate = txtBirthDate.Text,
                Gender = Convert.ToChar(ddlGenders.SelectedValue),
                Admission = txtAdmission.Text,
                HomeAddress = txtHomeAddress.Text,
                NIT = txtNIT.Text,
                Department = new Department()
                {
                    Id = Convert.ToInt32(ddlDepartment.SelectedValue),
                }
        };

            bool response;

            //Save or Update employee
            if (id != 0)
                response = EmployeeBL.UpdateEmployee(employee);
            else
                response = EmployeeBL.CreateEmployee(employee);

            //Verify operation
            if (response)
                Response.Redirect("~/Default.aspx");
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se pudo realizar la operacion')", true);

        }
    }
}