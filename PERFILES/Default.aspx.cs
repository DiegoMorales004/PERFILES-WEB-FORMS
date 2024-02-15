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

        }
    }
}