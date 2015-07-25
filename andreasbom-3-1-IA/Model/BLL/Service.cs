using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using andreasbom_3_1_IA.App_Infrastructure;
using andreasbom_3_1_IA.Model.DAL;

namespace andreasbom_3_1_IA.Model.BLL
{
    public class Service
    {
        #region Fields and Properties
        private EmployeeDAL _employeeDAL;
        private ShiftDAL _shiftDAL;

        public EmployeeDAL EmployeeDAL
        {
            get { return _employeeDAL ?? (_employeeDAL = new EmployeeDAL()); }
        }

        public ShiftDAL ShiftDAL
        {
            get { return _shiftDAL ?? (_shiftDAL = new ShiftDAL()); }
        }

        #endregion


        #region Employee
        //Returns data from one employee
        public Employee GetEmpolyee(int employeeId)
        {
            return EmployeeDAL.GetEmployeeById(employeeId);
        }

        //Returns a List with all employees 
        public IEnumerable<Employee> GetAllEmployees()
        {
            return EmployeeDAL.GetAllEmployees();
        }

        //Deletes one employee
        public void DeleteEmployee(int empId)
        {
            EmployeeDAL.DeleteEmployee(empId);
        }

        //Saves one employee
        public void SaveEmployee(Employee employee)
        {
            //Valididation in BLL
            ICollection<ValidationResult> validationResults;
            if (!employee.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte validerinen");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }


            if (employee.EmpID == 0)
            {
                EmployeeDAL.InsertEmployee(employee);
            }
            else
            {
                EmployeeDAL.UpdateEmployee(employee);
            }
        }

        #endregion 


        #region Shift

        //Returns a sorted lit with shifts
        public IEnumerable<ShiftsAndEmployees> GetAllShifts()
        {
            var shiftList = ShiftDAL.GetAllShifts();
            //Sorterara Listan i fallande datum
            var sortedList = shiftList.OrderByDescending<ShiftsAndEmployees, DateTime>(date => date.Date);
            return sortedList;
        }

        //Returns a list with TypeOfShift
        public IEnumerable<TypeOfShift> GetTypeOfShift()
        {
            return ShiftDAL.GetTypeofShifts();
        }

        //Inserts one shift
        public void InsertShift(Shift shift)
        {
            //Validation in BLL
            ICollection<ValidationResult> validationResults;
            if (!shift.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte validerinen");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            ShiftDAL.InsertShift(shift);
        }

        //Deletes one shift
        public void DeleteShift(int id)
        {
            ShiftDAL.DeleteShift(id);
        }

        //Returns a list with sum of all shifts for each employee
        public IEnumerable<TimeReport> GetTotalTime(DateTime fromDate, DateTime toDate)
        {
            return ShiftDAL.GetTotalTime(fromDate, toDate);
        }

        #endregion


        #region Cached data

        //Cache typeOfShift for 30min
        public IEnumerable<TypeOfShift> GetCachedTypeOfShift()
        {

            var typeOfShift = HttpContext.Current.Cache["typeOfShifts"] as IEnumerable<TypeOfShift>;

            if (typeOfShift == null)
            {
                typeOfShift = GetTypeOfShift();
                HttpContext.Current.Cache.Insert("typeOfShifts", typeOfShift, null, DateTime.Now.AddMinutes(30),
                    TimeSpan.Zero);
            }
            return typeOfShift;
        }

        //Cached employees for 1min
        public IEnumerable<Employee> GetCachedAllEmployees()
        {

            var allEmployees = HttpContext.Current.Cache["allEmployees"] as IEnumerable<Employee>;

            if (allEmployees == null)
            {
                allEmployees = GetAllEmployees();
                HttpContext.Current.Cache.Insert("typeOfShifts", allEmployees, null, DateTime.Now.AddMinutes(1),
                    TimeSpan.Zero);
            }
            return allEmployees;
        }

        //Cached shifts for 7 days
        public IEnumerable<ShiftsAndEmployees> GetCachedShifts()
        {

            var shifts = HttpContext.Current.Cache["Shifts"] as IEnumerable<ShiftsAndEmployees>;

            if (shifts == null)
            {
                shifts = GetAllShifts();
                HttpContext.Current.Cache.Insert("Shifts", shifts, null, DateTime.Now.AddDays(7),
                    TimeSpan.Zero);
            }
            return shifts;
        }

        #endregion

    }
}