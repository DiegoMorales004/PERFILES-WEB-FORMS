
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;
using Microsoft.SqlServer.Server;

using PERFILES.DataLayer;
using PERFILES.EntityLayer;


namespace PERFILES.BusinessLayer
{
    public class EmployeeBL
    {

        EmployeeDL EmployeeDL = new EmployeeDL();
        DepartmentDL DepartmentDL = new DepartmentDL();

        //Create employee
        public bool CreateEmployee(Employee employee)
        {
            try
            {
                CheckParametersEmployee(employee);

                employee.Age = CalculateAge(employee.BirthDate);

                return EmployeeDL.CreateEmployee(employee);

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        //Get one employee by id
        public Employee GetEmployee(int id)
        {
            try
            {

                Employee employee = EmployeeDL.GetEmployee(id);
                if(employee == null || employee.Id == 0)
                {
                    throw new OperationCanceledException("The employee does not exist.");
                }

                return employee;

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        //Get list of employees
        public List<Employee> GetEmployees()
        {
            try
            {
                return EmployeeDL.EmployeesList();

            }catch(Exception ex) {
                throw ex;
            }
        }

        //Update employee
        public bool UpdateEmployee(Employee employee)
        {
            try
            {

                Employee validEmployee = GetEmployee(employee.Id);

                CheckParametersEmployee(employee);
                
                employee.Age = CalculateAge(employee.BirthDate);

                return EmployeeDL.UpdateEmployee(employee);

            }catch(Exception ex)
            {
                throw ex;
            }
        }
        
        //Delete employee by id
        public bool DeleteEmployee(int id)
        {
            try
            {
                Employee validEmployee = GetEmployee(id);
                return EmployeeDL.DeleteEmployee(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //Check parameters for employee
        private void CheckParametersEmployee(Employee employee)
        {
            DateTime date;

            if (employee == null) 
                throw new OperationCanceledException("The employee cannot be null.");

            if (employee.Names == "" || employee.Names == null) 
                throw new OperationCanceledException("The names cannot be void.");

            if (employee.DPI.GetType() != typeof( System.Int32 ) || employee.DPI.ToString().Length != 13) 
                throw new OperationCanceledException("The parameter DPI must have 13 numbers.");

            if ( CheckFormateDate( employee.BirthDate, out date ) ) 
                throw new OperationCanceledException("Invalid format to birthdate");

            if (employee.Gender != 'M' || employee.Gender != 'F') 
                throw new OperationCanceledException("Invalid gender");

            if( CheckFormateDate( employee.Admission, out date ) ) 
                throw new OperationCanceledException("Invalid format to birthdate");

            if (employee.HomeAddress == "" || employee.HomeAddress == null)
                throw new OperationCanceledException("The home address cannot be void.");

            if ( employee.NIT.ToString().Length > 9) 
                throw new OperationCanceledException("The parameter NIT must have 9 numbers.");

            if (CheckDepartment(employee.Department.Id))
                throw new OperationCanceledException("The Department does not exist");
        }

        //Check format yyyy-MM-dd
        public bool CheckFormateDate(string date, out DateTime outDate)
        {
            bool valid = DateTime.TryParseExact(date, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out outDate);
            return valid;
        }

        //Verify that the department exists
        public bool CheckDepartment(int idDepartment)
        {
            try
            {

                Department department = DepartmentDL.GetDepartment(idDepartment);
                return true;

            }catch(Exception ex)
            {
                return false;
            }
        }

        //Calculate age by birthDate
        private int CalculateAge(string BirthDate)
        {
            DateTime today = DateTime.Today;

            //Convert string BirthDate to type DateTime 
            DateTime NewBirthDate = DateTime.ParseExact(BirthDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            int age = today.Year - NewBirthDate.Year;

            return age;

        }

    }
}
