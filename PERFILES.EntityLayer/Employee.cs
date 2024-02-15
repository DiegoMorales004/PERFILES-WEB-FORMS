using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PERFILES.EntityLayer
{
    public class Employee
    {
        public int Id { get; set; }
        public string Names{ get; set; }
        public int DPI { get; set; }
        public string BirthDate {  get; set; }
        public char Gender {  get; set; }
        public string Admission { get; set; }
        public int Age {  get; set; }
        public string HomeAddress {  get; set; }
        public int NIT {  get; set; }
        public Department Department { get; set; }
    }
}
