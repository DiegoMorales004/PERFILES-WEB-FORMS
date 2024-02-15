using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PERFILES.DataLayer
{
    public class Connection
    {
        public static string connection = ConfigurationManager.ConnectionStrings["StringSQL"].ToString();
    }
}
