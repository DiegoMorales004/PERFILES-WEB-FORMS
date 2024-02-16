using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PERFILES.BusinessLayer;
using PERFILES.EntityLayer;

namespace PERFILES
{
    public partial class ActionDepartment : Page
    {

        DepartmentBL _DepartmentBL = new DepartmentBL();
        private static int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    id = Convert.ToInt32(Request.QueryString["id"]);
                    if(id != 0)
                    {
                        lblTitle.Text = "Editar Departamento";
                        btnSubmit.Text = "Editar";

                        //Search department
                        Department department = _DepartmentBL.GetOneDepartment(id);

                        //Fill text area with old data
                        txtName.Text = department.Name;
                        txtDescription.Text = department.Description;

                    }else
                    {
                        lblTitle.Text = "Registrar Departamento";
                        btnSubmit.Text = "Guardar";
                    }
                }
                else
                {
                    //Redirect if the parameter not exist
                    Response.Redirect("~/Departments.aspx");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool update = false;
            if (id != 0) update = true;
            bool validTextAreas = CheckParameters(update);

            if (!validTextAreas) return;

            Department department = new Department()
            {
                Id = id,
                Name = txtName.Text,
                Description = txtDescription.Text,
            };

            bool response;

            //Save or update department
            if(id != 0)
                response = _DepartmentBL.UpdateDepartment(department);
            else 
                response = _DepartmentBL.CreateDepartment(department);

            //Verify operatioin
            if (response)
                Response.Redirect("~/Departments.aspx");
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se pudo realizar la operacion')", true);

        }

        //Validate params
        private bool CheckParameters(bool update)
        {

            if (
                string.IsNullOrEmpty(txtName.Text) ||
                string.IsNullOrEmpty(txtDescription.Text)
                )
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Ningun campo puede estar vacio.')", true);
                return false;
            }

            bool validName = ValidDepartmentName(txtName.Text, id, update);
            if( !validName ) {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('El nombre del departamento ya esta en uso.')", true);
                return false;
            }

            return true;

        }

        //Check if the name is already in use
        protected bool ValidDepartmentName(string name, int oldId, bool update)
        {
            try
            {
                Department valid = _DepartmentBL.GetOneDepartmentByName(name);
                
                if (valid.Id != 0 && valid.Id != oldId) return false;
                

                return true;
            }catch (Exception ex) {
                throw ex;
            }
        }
    }
}