using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using andreasbom_3_1_IA.Model.BLL;

namespace andreasbom_3_1_IA.Model.DAL
{
    public class ShiftDAL :DALBase
    {

        //List of all shifts
        public IEnumerable<ShiftsAndEmployees> GetAllShifts()
        {
            var shifts = new List<ShiftsAndEmployees>(100);
            try
            {
                using (var conn = CreateConnection())
                {
                    var cmd = new SqlCommand("IA.uspGetTimeForAllEmployees", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Get index for columns
                            int shiftIdIndex = reader.GetOrdinal("ShiftID");
                            int empIdIndex = reader.GetOrdinal("EmpID");
                            int empCodeIndex = reader.GetOrdinal("EmpCode");
                            int firstNameIndex = reader.GetOrdinal("FirstName");
                            int lastNameIndex = reader.GetOrdinal("LastName");
                            int dateIndex = reader.GetOrdinal("Date");
                            int tosIdIndex = reader.GetOrdinal("TOSID");
                            int descriptionIndex = reader.GetOrdinal("Description");
                            int startTimeIndex = reader.GetOrdinal("StartTime");
                            int endTimeIndex = reader.GetOrdinal("EndTime");
                            int minutesIndex = reader.GetOrdinal("Minutes");


                            shifts.Add(new ShiftsAndEmployees
                            {
                                ShiftID = reader.GetInt32(shiftIdIndex),
                                EmpID = reader.GetInt32(empIdIndex),
                                EmpCode = reader.GetString(empCodeIndex),
                                FirstName = reader.GetString(firstNameIndex),
                                LastName = reader.GetString(lastNameIndex),
                                Date = reader.GetDateTime(dateIndex),
                                TOSID = reader.GetInt32(tosIdIndex),
                                Description = reader.GetString(descriptionIndex),
                                StartTime = reader.GetTimeSpan(startTimeIndex),
                                EndTime = reader.GetTimeSpan(endTimeIndex),
                                Minutes = reader.GetInt32(minutesIndex)
                            });
                            
                        }
                    }

                    shifts.TrimExcess();
                    return shifts;
                }

            }
            catch (Exception)
            {
                throw new ApplicationException("An error occured in the data layer while fetching shifts");
            }
        }

        //Returns a list with the TypeOfShifts
        public IEnumerable<TypeOfShift> GetTypeofShifts()
        {
            var typeOfShiftList = new List<TypeOfShift>(20);

            try
            {
                using (var conn = CreateConnection())
                {
                    var cmd = new SqlCommand("IA.uspGetTypeOfShifts", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            var tosidIndex = reader.GetOrdinal("TOSID");
                            var descriptionIndex = reader.GetOrdinal("Description");
                            var startTimeIndex = reader.GetOrdinal("StartTime");
                            var endTimeIndex = reader.GetOrdinal("EndTime");
                            var minutesIndex = reader.GetOrdinal("Minutes");

                            typeOfShiftList.Add(new TypeOfShift
                            {
                                TOSID = reader.GetInt32(tosidIndex),
                                Description = reader.GetString(descriptionIndex),
                                StartTime = reader.GetTimeSpan(startTimeIndex),
                                EndTime = reader.GetTimeSpan(endTimeIndex),
                                Minutes = reader.GetInt32(minutesIndex)
                            });
                        }
                    }

                    typeOfShiftList.TrimExcess();
                    return typeOfShiftList;
                }
            }
            catch
            {

                throw new ApplicationException("An error occured in the data layer while fetching shifts");
            }
        }

        //Insert new shift
        public void InsertShift(Shift shift)
        {
            try
            {
                using (var conn = CreateConnection())
                {
                    var cmd = new SqlCommand("IA.uspInsertShift", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.Add("@Date", SqlDbType.DateTime, 8).Value = shift.Date;
                    cmd.Parameters.Add("@EmpID", SqlDbType.Int, 4).Value = shift.EmpID;
                    cmd.Parameters.Add("@TOSID", SqlDbType.Int, 4).Value = shift.TOSID;
                    cmd.Parameters.Add("@ShiftID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    shift.EmpID = (int) cmd.Parameters["@ShiftID"].Value;
                }
            }
            catch
            {

                throw new ApplicationException("An error occured in the data layer while inserting shift");
            }
        }

        //Delete shift
        public void DeleteShift(int id)
        {
            try
            {
                using (var conn = CreateConnection())
                {
                    var cmd = new SqlCommand("IA.uspDeleteShift", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ShiftID", SqlDbType.Int, 4).Value = id;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("An error occured in the data layer while deleting shift");
            }
        }

        //Get sum of all shifts
        public IEnumerable<TimeReport> GetTotalTime(DateTime fromDate, DateTime toDate)
        {
            var totalTimeList = new List<TimeReport>(50);
            try
            {
                using (var conn = CreateConnection())
                {
                    var cmd = new SqlCommand("IA.uspGetTotalTime", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FromDate", SqlDbType.DateTime, 8).Value = fromDate;
                    cmd.Parameters.Add("@ToDate", SqlDbType.DateTime, 8).Value = toDate;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var empIdIndex = reader.GetOrdinal("EmpID");
                            var empCodeIndex = reader.GetOrdinal("EmpCode");
                            var firstNameIndex = reader.GetOrdinal("FirstName");
                            var lastNameIndex = reader.GetOrdinal("LastName");
                            var totalIndex = reader.GetOrdinal("Total");

                            totalTimeList.Add(new TimeReport
                            {
                                EmpID = reader.GetInt32(empIdIndex),
                                EmpCode = reader.GetString(empCodeIndex),
                                FirstName = reader.GetString(firstNameIndex),
                                LastName = reader.GetString(lastNameIndex),
                                Total = reader.GetInt32(totalIndex)
                            });
                        }
                        totalTimeList.TrimExcess();

                        return totalTimeList;
                    }

                    
                }
            }
            catch
            {
                throw new ApplicationException("An error occured in the data layer while fetching totalTime");
            }
        }
    }
}