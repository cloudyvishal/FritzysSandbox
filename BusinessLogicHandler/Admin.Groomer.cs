using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Drawing;
using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;

using DataBaseHandler35;

using BCL.Common.StoreProcedure;
using BCL.Common.BasseDataAccess;

namespace BCL.Admin.GroomerMngmt
{
    public class Groomer : BaseData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SearchFor"></param>
        /// <param name="SearchText"></param>
        /// <returns></returns>
        public DataSet GetAllGroomers(string SearchFor, string SearchText)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@SearchFor", "@SearchText" };

                paramValues = new object[] { SearchFor, SearchText };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.Groomers_Get_All, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GID"></param>
        /// <returns></returns>
        public DataSet DeleteGroomer(string GID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GID" };

                paramValues = new object[] { GID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.DELETE_GROOMER, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="Name"></param>
        /// <param name="Address"></param>
        /// <param name="HomePhone"></param>
        /// <param name="PersonalCellPhone"></param>
        /// <param name="ZipCode"></param>
        /// <param name="SheetName"></param>
        /// <param name="BaseCity"></param>
        /// <param name="State"></param>
        /// <param name="GTimeZone"></param>
        /// <returns></returns>
        public int AddGroomer(string UserName, string Password, string Name, string Address, string HomePhone, string PersonalCellPhone, string ZipCode, string SheetName,
        string BaseCity, string State, string GTimeZone)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserName", "@Password", "@Name", "@Address", "@HomePhone", "@PersonalCellPhone", "@ZipCode", "@SheetName", "@BaseCity", "@State", "@GTimeZone" };

                paramValues = new object[] { UserName, Password, Name, Address, HomePhone, PersonalCellPhone, ZipCode, SheetName, BaseCity, State, GTimeZone };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.ADD_GROOMER_INSERT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GID"></param>
        /// <returns></returns>
        public DataSet GetGroomer(int GID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GID" };

                paramValues = new object[] { GID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GROOMER_GET_BY_ID, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groomer"></param>
        /// <returns></returns>
        public DataSet GetGroomername(string groomer)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@Groomername" };

                paramValues = new object[] { groomer };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_GROOMER_ID_BY_NAME, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int DeleteFutureAppointments()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.DeleteData(StoreProcedure.FUTURE_APPOINTMENTS_DELETE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GID"></param>
        /// <param name="aptdate"></param>
        /// <param name="aptdatetime"></param>
        /// <returns></returns>
        public int CheckApptExists(int GID, string aptdate, string aptdatetime)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GID", "@Date", "@DateTime" };

                paramValues = new object[] { GID, aptdate, aptdatetime };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetCount(StoreProcedure.IS_APPT_EXISTS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GID"></param>
        /// <param name="AppointmentDate"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="ExpectedTotalRevenue"></param>
        /// <param name="Others"></param>
        /// <param name="DateTimeFormat"></param>
        /// <param name="SequenceNo"></param>
        /// <param name="ExpPetTime"></param>
        /// <param name="ZipCode"></param>
        /// <param name="ApptStart_Time"></param>
        /// <param name="NameofCustomer"></param>
        /// <param name="ExpEndTime"></param>
        /// <returns></returns>
        public int InsertGroomerAppointment(int GID, string AppointmentDate, string StartTime, string EndTime, string ExpectedTotalRevenue, string Others, string DateTimeFormat, int SequenceNo, decimal ExpPetTime, string ZipCode, string ApptStart_Time, string NameofCustomer, string ExpEndTime)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GID", "@AppointmentDate", "@StartTime", "@EndTime", "@ExpectedTotalRevenue", "@Others", "@DateTimeFormat", "@SequenceNo", "@ExpPetTime", "@ExpStartTime", "@CustomerName", "@Zipcode", "@ExpEndTime" };

                paramValues = new object[] { GID, AppointmentDate, StartTime, EndTime, ExpectedTotalRevenue, Others, DateTimeFormat, SequenceNo, ExpPetTime, ApptStart_Time, NameofCustomer, ZipCode, ExpEndTime };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.INSERT_GROOMER_APPOINTMENT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GID"></param>
        /// <param name="Apptdate"></param>
        /// <returns></returns>
        public DataSet GetAppts(int GID, string Apptdate)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GID", "@ApptDate" };

                paramValues = new object[] { GID, Apptdate };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_GROOMER_DATEWISE_APPTS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groomer"></param>
        /// <returns></returns>
        public bool IsGroomerExists(int groomer)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            bool isAvail = false;

            try
            {
                paramNames = new string[] { "@Groomername" };

                paramValues = new object[] { groomer };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                DataSet ds = databaseObj.GetDataSet(StoreProcedure.GET_GROOMER_DATEWISE_APPTS, Enumerations.Command_Type.StoredProcedure, paramList);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!(ds.Tables[0].Rows[0]["NAME"].ToString().Equals("")))
                    {
                        isAvail = true;
                    }
                }

                return isAvail;
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GID"></param>
        /// <param name="UserName"></param>
        /// <param name="Name"></param>
        /// <param name="Address"></param>
        /// <param name="HomePhone"></param>
        /// <param name="PersonalCellPhone"></param>
        /// <param name="ZipCode"></param>
        /// <param name="BaseCity"></param>
        /// <param name="State"></param>
        /// <param name="SheetName"></param>
        /// <param name="GTimeZone"></param>
        /// <returns></returns>
        public int UpdateGroomer(int GID, string UserName, string Name, string Address, string HomePhone, string PersonalCellPhone, string ZipCode, string BaseCity, string State, string SheetName, string GTimeZone)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GID", "@UserName", "@Name", "@Address", "@HomePhone", "@PersonalCellPhone", "@ZipCode", "@BaseCity", "@State", "@SheetName", "@GTimeZone" };

                paramValues = new object[] { GID, UserName, Name, Address, HomePhone, PersonalCellPhone, ZipCode, BaseCity, State, SheetName, GTimeZone };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.UpdateData(StoreProcedure.GROOMER_DETAILS_UPDATE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AppointmentDate"></param>
        /// <returns></returns>
        public DataSet GetGroomersAppointment(DateTime AppointmentDate)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppointmentDate" };

                paramValues = new object[] { AppointmentDate };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_GROOMERS_APPOINTMENT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GID"></param>
        /// <param name="AppointmentDate"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="ExpectedTotalRevenue"></param>
        /// <param name="Others"></param>
        /// <param name="DateTimeFormat"></param>
        /// <param name="SequenceNo"></param>
        /// <param name="ExpPetTime"></param>
        /// <returns></returns>
        public int AddGroomerAppointment(int GID, string AppointmentDate, string StartTime, string EndTime, string ExpectedTotalRevenue, string Others, string DateTimeFormat, int SequenceNo, decimal ExpPetTime, string custemail, string expectStartTime, int UserAppID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GID", "@AppointmentDate", "@StartTime", "@EndTime", "@ExpectedTotalRevenue", "@Others", "@DateTimeFormat", "@SequenceNo", "@ExpPetTime", "@custEmail" };

                paramValues = new object[] { GID, Convert.ToDateTime(AppointmentDate), StartTime, EndTime, ExpectedTotalRevenue, Others, DateTimeFormat, SequenceNo, ExpPetTime, custemail };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.ADD_GROOMER_APPOINTMENT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GID"></param>
        /// <param name="Date"></param>
        /// <returns></returns>
        public DataSet GetGroomerDailyLogData(int GID, string Date)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GID", "@Date" };

                paramValues = new object[] { GID, Date };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_GROOMER_DAILY_LOG_DATA, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GId"></param>
        /// <param name="VanId"></param>
        /// <param name="BeginningMileage"></param>
        /// <param name="TotlaHours"></param>
        /// <param name="EndingMileage"></param>
        /// <param name="FuelPurchased"></param>
        /// <param name="PricePerGallon"></param>
        /// <param name="CustomerName"></param>
        /// <param name="Job"></param>
        /// <param name="ZipCode"></param>
        /// <param name="Pets"></param>
        /// <param name="Rebook"></param>
        /// <param name="FromRebook"></param>
        /// <param name="New"></param>
        /// <param name="TimeIn"></param>
        /// <param name="TimeOut"></param>
        /// <param name="PetTime"></param>
        /// <param name="ExtraServices"></param>
        /// <param name="FleaandTick22"></param>
        /// <param name="FleaandTick44"></param>
        /// <param name="FleaandTick88"></param>
        /// <param name="FleaandTick132"></param>
        /// <param name="FleaandTickCat"></param>
        /// <param name="TB"></param>
        /// <param name="Wham"></param>
        /// <param name="RevenueCreditCard"></param>
        /// <param name="RevenueCheck"></param>
        /// <param name="RevenueCash"></param>
        /// <param name="RevenueInvoice"></param>
        /// <param name="TipCreditCard"></param>
        /// <param name="TipCheck"></param>
        /// <param name="TipCash"></param>
        /// <param name="TipInvoice"></param>
        /// <param name="PriorCreditCard"></param>
        /// <param name="PriorCheck"></param>
        /// <param name="PriorCash"></param>
        /// <param name="NextAppointmentDate"></param>
        /// <param name="NextAppointmentTime"></param>
        /// <param name="ServicesForPet1"></param>
        /// <param name="ServicesForPet2"></param>
        /// <param name="ServicesForPet3"></param>
        /// <param name="ServicesForPet4"></param>
        /// <param name="ServicesForPet5"></param>
        /// <param name="ServicesForPet6"></param>
        /// <param name="Addedon"></param>
        /// <returns></returns>
        public int UpdateGroomerDailyOperationsLog(int GId, string VanId, int BeginningMileage, string TotlaHours, int EndingMileage, double FuelPurchased,
    double PricePerGallon, string CustomerName, string Job, string ZipCode, int Pets, int Rebook, int FromRebook, int New, string TimeIn, string TimeOut,
    string PetTime, string ExtraServices, int FleaandTick22, int FleaandTick44, int FleaandTick88, int FleaandTick132, int FleaandTickCat,
    int TB, int Wham, double RevenueCreditCard, double RevenueCheck, double RevenueCash, double RevenueInvoice, double TipCreditCard, double TipCheck,
    double TipCash, double TipInvoice, double PriorCreditCard, double PriorCheck, double PriorCash, DateTime NextAppointmentDate, string NextAppointmentTime,
    string ServicesForPet1, string ServicesForPet2, string ServicesForPet3, string ServicesForPet4, string ServicesForPet5, string ServicesForPet6, string Addedon)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GId", "@VanId", "@BeginningMileage", "@TotlaHours", "@EndingMileage", "@FuelPurchased", "@PricePerGallon", "@CustomerName", "@Job", "@ZipCode", "@Pets", "@Rebook", "@FromRebook", "@New", "@TimeIn", "@TimeOut", "@PetTime", "@ExtraServices", "@FleaandTick22", "@FleaandTick44", "@FleaandTick88", "@FleaandTick132", "@FleaandTickCat", "@TB", "@Wham", "@RevenueCreditCard", "@RevenueCheck", "@RevenueCash", "@RevenueInvoice", "@TipCreditCard", "@TipCheck", "@TipCash", "@TipInvoice", "@PriorCreditCard", "@PriorCheck", "@PriorCash", "@NextAppointmentDate", "@NextAppointmentTime", "@ServicesForPet1", "@ServicesForPet2", "@ServicesForPet3", "@ServicesForPet4", "@ServicesForPet5", "@ServicesForPet6", "@Addedon", };

                paramValues = new object[] { GId, VanId, BeginningMileage, TotlaHours, EndingMileage, FuelPurchased, PricePerGallon, CustomerName, Job, ZipCode, Pets, Rebook, FromRebook, New, TimeIn, TimeOut, PetTime, ExtraServices, FleaandTick22, FleaandTick44, FleaandTick88, FleaandTick132, FleaandTickCat, TB, Wham, RevenueCreditCard, RevenueCheck, RevenueCash, RevenueInvoice, TipCreditCard, TipCheck, TipCash, TipInvoice, PriorCreditCard, PriorCheck, PriorCash, NextAppointmentDate, NextAppointmentTime, ServicesForPet1, ServicesForPet2, ServicesForPet3, ServicesForPet4, ServicesForPet5, ServicesForPet6, Addedon };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.UpdateData(StoreProcedure.UPDATE_GROOMER_DAILY_OPERATIONS_LOG, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GID"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public DataSet GetGroomerMonthlyLogData(int GID, string StartDate, string EndDate)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GID", "@StartDate", "@EndDate" };

                paramValues = new object[] { GID, StartDate, EndDate };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_GROOMER_MONTHLY_LOG_DATA, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet BindGroomers()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.Bind_Groomers, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AppointmentId"></param>
        /// <returns></returns>
        public DataSet GetGroomersdateappointment(int AppointmentId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppointmentId" };

                paramValues = new object[] { AppointmentId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_GROOMERS_DATE_APPOINTMENT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AppointmentID"></param>
        /// <param name="GId"></param>
        /// <param name="AppointmentDate"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="ExpectedTotalRevenue"></param>
        /// <param name="Others"></param>
        /// <param name="SequenceNo"></param>
        /// <param name="DateTimeFormat"></param>
        /// <param name="Astatus"></param>
        /// <param name="ExpPetTime"></param>
        /// <param name="Pstatus"></param>
        /// <param name="PresentedTime"></param>
        /// <returns></returns>
        public int UpdateGroomerAppointment(int AppointmentID, int GId, string AppointmentDate, string StartTime, string EndTime, string ExpectedTotalRevenue, string Others, int SequenceNo, string DateTimeFormat, int Astatus, decimal ExpPetTime, bool Pstatus, string PresentedTime)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppointmentID", "@GId", "@AppointmentDate", "@StartTime", "@EndTime", "@ExpectedTotalRevenue", "@Others", "@SequenceNo", "@DateTimeFormat", "@Astatus", "@ExpPetTime", "@Pstatus", "@PresentedTime" };

                paramValues = new object[] { AppointmentID, GId, AppointmentDate, StartTime, EndTime, ExpectedTotalRevenue, Others, SequenceNo, DateTimeFormat, Astatus, ExpPetTime, Pstatus, PresentedTime };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.UpdateData(StoreProcedure.UPDATE_GROOMER_APPOINTMENT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AppointmentDate"></param>
        /// <param name="AppointmentId"></param>
        /// <param name="GId"></param>
        /// <returns></returns>
        public DataSet GetGroomersSequence(string AppointmentDate, int AppointmentId, int GId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppointmentDate", "@AppointmentId", "@GId" };

                paramValues = new object[] { AppointmentDate, AppointmentId, GId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_GROOMERS_SEQUENCE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AppointmentId"></param>
        /// <returns></returns>
        public DataSet DeleteGroomerAppointment(int AppointmentId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppointmentId" };

                paramValues = new object[] { AppointmentId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.DELETE_GROOMER_APPOINTMENT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GID"></param>
        /// <param name="AppointmentDate"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="ExpectedTotalRevenue"></param>
        /// <param name="Others"></param>
        /// <param name="DateTimeFormat"></param>
        /// <param name="SequenceNo"></param>
        /// <param name="ExpPetTime"></param>
        /// <returns></returns>
        public int AssignGroomerAppointment(int GID, string AppointmentDate, string StartTime, string EndTime, string ExpectedTotalRevenue, string Others, string DateTimeFormat, int SequenceNo, decimal ExpPetTime)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GID", "@AppointmentDate", "@StartTime", "@EndTime", "@ExpectedTotalRevenue", "@Others", "@DateTimeFormat", "@SequenceNo", "@ExpPetTime" };

                paramValues = new object[] { GID, AppointmentDate, StartTime, EndTime, ExpectedTotalRevenue, Others, DateTimeFormat, SequenceNo, ExpPetTime };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.ASSIGN_GROOMER_APPOINTMENT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GId"></param>
        /// <param name="AppointmentDate"></param>
        /// <returns></returns>
        public DataSet GetGroomersSequenceforUpdate(int GId, string AppointmentDate)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GID", "@AppointmentDate" };

                paramValues = new object[] { GId, AppointmentDate };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_GROOMERS_SEQUENCE_FOR_UPDATE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GID"></param>
        /// <param name="AppointmentDate"></param>
        /// <param name="SequenceNo"></param>
        /// <param name="AppointmentId"></param>
        /// <returns></returns>
        public DataSet UpdateGroomerSequence(int GID, string AppointmentDate, int SequenceNo, int AppointmentId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GID", "@AppointmentDate", "@SequenceNo", "@AppointmentId" };

                paramValues = new object[] { GID, AppointmentDate, SequenceNo, AppointmentId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.UPDATE_GROOMER_SEQUENCE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GId"></param>
        /// <param name="AppointmentDate"></param>
        /// <returns></returns>
        public DataSet GetPreviousGroomersSequenceforUpdate(int GId, string AppointmentDate)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GID", "@AppointmentDate" };

                paramValues = new object[] { GId, AppointmentDate };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_PREVIOUS_GROOMERS_SEQUENCE_FOR_UPDATE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GId"></param>
        /// <param name="AppointmentDate"></param>
        /// <returns></returns>
        public DataSet GetPreviousGroomersSequenceforUpdate1(int GId, string AppointmentDate)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GID", "@AppointmentDate" };

                paramValues = new object[] { GId, AppointmentDate };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_PREVIOUS_GROOMERS_SEQUENCE_FOR_UPDATE_ONE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GId"></param>
        /// <param name="AppointmentDate"></param>
        /// <returns></returns>
        public DataSet GetMaxSequencenoOfGroomer(int GId, string AppointmentDate)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GID", "@AppointmentDate" };

                paramValues = new object[] { GId, AppointmentDate };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_MAX_SEQUENCENO_OF_GROOMER, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GId"></param>
        /// <param name="AppointmentDate"></param>
        /// <param name="Sequence"></param>
        /// <returns></returns>
        public DataSet GetGroomerNextsequenceForupdate(int GId, string AppointmentDate, int Sequence)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GID", "@AppointmentDate", "@Sequence" };

                paramValues = new object[] { GId, AppointmentDate, Sequence };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_GROOMER_NEXT_SEQUENCE_FOR_UPDATE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AppointmentId"></param>
        public void ChangeGroomerAppointmentStatus(string AppointmentId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppointmentId" };

                paramValues = new object[] { AppointmentId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.CHANGE_GROOMER_APPOINTMENT_STATUS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="VanId"></param>
        /// <param name="BeginningMileage"></param>
        /// <param name="TotlaHours"></param>
        /// <param name="EndingMileage"></param>
        /// <param name="FuelPurchased"></param>
        /// <param name="PricePerGallon"></param>
        /// <param name="CustomerName"></param>
        /// <param name="Job"></param>
        /// <param name="ZipCode"></param>
        /// <param name="Pets"></param>
        /// <param name="Rebook"></param>
        /// <param name="FromRebook"></param>
        /// <param name="New"></param>
        /// <param name="TimeIn"></param>
        /// <param name="TimeOut"></param>
        /// <param name="PetTime"></param>
        /// <param name="ExtraServices"></param>
        /// <param name="comments"></param>
        /// <param name="FleaandTick22"></param>
        /// <param name="FleaandTick44"></param>
        /// <param name="FleaandTick88"></param>
        /// <param name="FleaandTick132"></param>
        /// <param name="FleaandTickCat"></param>
        /// <param name="TB"></param>
        /// <param name="Wham"></param>
        /// <param name="RevenueCreditCard"></param>
        /// <param name="RevenueCheck"></param>
        /// <param name="RevenueCash"></param>
        /// <param name="RevenueInvoice"></param>
        /// <param name="TipCreditCard"></param>
        /// <param name="TipCheck"></param>
        /// <param name="TipCash"></param>
        /// <param name="TipInvoice"></param>
        /// <param name="PriorCreditCard"></param>
        /// <param name="PriorCheck"></param>
        /// <param name="PriorCash"></param>
        /// <param name="NextAppointmentDate"></param>
        /// <param name="NextAppointmentTime"></param>
        /// <param name="ServicesForPet"></param>
        /// <param name="Addedon"></param>
        /// <param name="FleaTick22"></param>
        /// <param name="FleaTick44"></param>
        /// <param name="FleaTick88"></param>
        /// <param name="FleaTick132"></param>
        /// <param name="FleaTickcAT"></param>
        /// <param name="Toothbrushes"></param>
        /// <param name="WhamInv"></param>
        /// <param name="Towels"></param>
        /// <param name="CottonPads"></param>
        /// <param name="CottonSwabs"></param>
        /// <param name="PaperTowels"></param>
        /// <param name="GarbageBags"></param>
        /// <param name="Treats"></param>
        /// <param name="VetWrap"></param>
        /// <param name="Wipes"></param>
        /// <param name="QuickStop"></param>
        /// <param name="LiquidBandaid"></param>
        /// <param name="Envelopes"></param>
        /// <param name="Receipts"></param>
        /// <param name="BusinessCards"></param>
        /// <param name="BladesSharpened"></param>
        /// <param name="ScissorsSharpened"></param>
        /// <param name="SunGuard"></param>
        /// <param name="EZShed"></param>
        /// <param name="EZDematt"></param>
        /// <param name="SkunkKit"></param>
        /// <param name="Other"></param>
        /// <param name="ProductPrice"></param>
        /// <param name="SalesTax"></param>
        /// <param name="Rev01"></param>
        /// <param name="CreditCardNo"></param>
        /// <param name="CreditCardExpir"></param>
        /// <param name="CreditCardName"></param>
        /// <param name="CreditCardAddr"></param>
        /// <param name="SecurityCode"></param>
        /// <param name="Other1"></param>
        /// <param name="Other2"></param>
        /// <param name="Other3"></param>
        /// <param name="Other4"></param>
        /// <param name="Other5"></param>
        /// <param name="Marketing1"></param>
        /// <param name="Marketing2"></param>
        /// <param name="Marketing3"></param>
        /// <param name="Marketing4"></param>
        /// <param name="Marketing5"></param>
        /// <param name="Liquid1"></param>
        /// <param name="Liquid2"></param>
        /// <param name="Liquid3"></param>
        /// <param name="Liquid4"></param>
        /// <param name="Liquid5"></param>
        /// <param name="Liquid6"></param>
        /// <param name="Liquid7"></param>
        /// <param name="Liquid8"></param>
        /// <param name="Liquid9"></param>
        /// <param name="Liquid10"></param>
        /// <param name="Liquid11"></param>
        /// <param name="Liquid12"></param>
        /// <param name="Liquid13"></param>
        /// <param name="Liquid14"></param>
        /// <param name="Liquid15"></param>
        /// <param name="Liquid16"></param>
        /// <param name="Liquid17"></param>
        /// <param name="Liquid18"></param>
        /// <param name="Liquid19"></param>
        /// <param name="Liquid20"></param>
        /// <param name="Liquid21"></param>
        /// <param name="Liquid22"></param>
        /// <param name="Liquid23"></param>
        /// <param name="Liquid24"></param>
        /// <param name="Liquid25"></param>
        public void EditExcel(string password, string VanId, string BeginningMileage, string TotlaHours, string EndingMileage, string FuelPurchased, string PricePerGallon, string CustomerName, string Job, string ZipCode, string Pets, string Rebook, string FromRebook, string New, string TimeIn, string TimeOut, string PetTime, string ExtraServices, string comments, string FleaandTick22, string FleaandTick44, string FleaandTick88, string FleaandTick132, string FleaandTickCat, string TB, string Wham, string RevenueCreditCard, string RevenueCheck, string RevenueCash, string RevenueInvoice, string TipCreditCard, string TipCheck, string TipCash, string TipInvoice, string PriorCreditCard, string PriorCheck, string PriorCash, string NextAppointmentDate, string NextAppointmentTime, string ServicesForPet, string Addedon, string FleaTick22, string FleaTick44, string FleaTick88, string FleaTick132, string FleaTickcAT, string Toothbrushes, string WhamInv, string Towels, string CottonPads, string CottonSwabs, string PaperTowels, string GarbageBags, string Treats, string VetWrap, string Wipes, string QuickStop, string LiquidBandaid, string Envelopes, string Receipts, string BusinessCards, string BladesSharpened, string ScissorsSharpened, string SunGuard, string EZShed, string EZDematt, string SkunkKit, string Other, string ProductPrice, string SalesTax, string Rev01, string CreditCardNo, string CreditCardExpir, string CreditCardName, string CreditCardAddr, string SecurityCode, string Other1,
        string Other2, string Other3, string Other4, string Other5, string Marketing1, string Marketing2, string Marketing3, string Marketing4, string Marketing5, string Liquid1, string Liquid2, string Liquid3, string Liquid4, string Liquid5, string Liquid6, string Liquid7, string Liquid8, string Liquid9, string Liquid10, string Liquid11, string Liquid12, string Liquid13, string Liquid14, string Liquid15, string Liquid16, string Liquid17, string Liquid18, string Liquid19, string Liquid20, string Liquid21, string Liquid22, string Liquid23, string Liquid24, string Liquid25)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@VanId", "@BeginningMileage", "@TotlaHours", "@EndingMileage", "@FuelPurchased", "@PricePerGallon", "@CustomerName", "@Job", "@ZipCode", "@Pets", "@Rebook", "@FromRebook", "@New", "@TimeIn", "@TimeOut", "@PetTime", "@ExtraServices", "@Comments", "@FleaandTick22", "@FleaandTick44", "@FleaandTick88", "@FleaandTick132", "@FleaandTickCat", "@TB", "@Wham", "@RevenueCreditCard", "@RevenueCheck", "@RevenueCash", "@RevenueInvoice", "@TipCreditCard", "@TipCheck", "@TipCash", "@TipInvoice", "@PriorCreditCard", "@PriorCheck", "@PriorCash", "@NextAppointmentDate", "@NextAppointmentTime", "@ServicesForPet", "@Addedon", "@FleaTick22", "@FleaTick44", "@FleaTick88", "@FleaTick132", "@FleaTickcAT", "@Toothbrushes", "@WhamInv", "@Towels", "@CottonPads", "@CottonSwabs", "@PaperTowels", "@GarbageBags", "@Treats", "@VetWrap", "@Wipes", "@QuickStop", "@LiquidBandaid", "@Envelopes", "@Receipts", "@BusinessCards", "@BladesSharpened", "@ScissorsSharpened", "@SunGuard", "@EZShed", "@EZDematt", "@SkunkKit", "@Other", "@ProductPrice", "@SalesTax", "@Rev01", "@CreditCardNo", "@CreditCardExpir", "@CreditCardName", "@CreditCardAddr", "@SecurityCode", "@Other1", "@Other2", "@Other3", "@Other4", "@Other5", "@Marketing1", "@Marketing2", "@Marketing3", "@Marketing4", "@Marketing5", "@Liquid1", "@Liquid2", "@Liquid3", "@Liquid4", "@Liquid5", "@Liquid6", "@Liquid7", "@Liquid8", "@Liquid9", "@Liquid10", "@Liquid11", "@Liquid12", "@Liquid13", "@Liquid14", "@Liquid15", "@Liquid16", "@Liquid17", "@Liquid18", "@Liquid19", "@Liquid20", "@Liquid21", "@Liquid22", "@Liquid23", "@Liquid24", "@Liquid25", "@Password" };

                paramValues = new object[] { VanId, BeginningMileage, TotlaHours, EndingMileage, FuelPurchased, PricePerGallon, CustomerName, Job, ZipCode, Pets, Rebook, FromRebook, New, TimeIn, TimeOut, PetTime, ExtraServices, comments, FleaandTick22, FleaandTick44, FleaandTick88, FleaandTick132, FleaandTickCat, TB, Wham, RevenueCreditCard, RevenueCheck, RevenueCash, RevenueInvoice, TipCreditCard, TipCheck, TipCash, TipInvoice, PriorCreditCard, PriorCheck, PriorCash, NextAppointmentDate, NextAppointmentTime, ServicesForPet, Addedon, FleaTick22, FleaTick44, FleaTick88, FleaTick132, FleaTickcAT, Toothbrushes, WhamInv, Towels, CottonPads, CottonSwabs, PaperTowels, GarbageBags, Treats, VetWrap, Wipes, QuickStop, LiquidBandaid, Envelopes, Receipts, BusinessCards, BladesSharpened, ScissorsSharpened, SunGuard, EZShed, EZDematt, SkunkKit, Other, ProductPrice, SalesTax, Rev01, CreditCardNo, CreditCardExpir, CreditCardName, CreditCardAddr, SecurityCode, Other1, Other2, Other3, Other4, Other5, Marketing1, Marketing2, Marketing3, Marketing4, Marketing5, Liquid1, Liquid2, Liquid3, Liquid4, Liquid5, Liquid6, Liquid7, Liquid8, Liquid9, Liquid10, Liquid11, Liquid12, Liquid13, Liquid14, Liquid15, Liquid16, Liquid17, Liquid18, Liquid19, Liquid20, Liquid21, Liquid22, Liquid23, Liquid24, Liquid25, password };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.SP_MANAGE_EXCEL, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet getExcelData()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            string logId = string.Empty;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SP_GET_EXCEL_DATA, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GID"></param>
        /// <param name="DailyLogID"></param>
        /// <returns></returns>
        public DataSet getDailyOperatrionLog(string GID, string DailyLogID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@Gid", "@DailyLogID" };

                paramValues = new object[] { GID, DailyLogID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SP_GET_DAILY_OPERATRION_LOG, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DailylogId"></param>
        /// <param name="ExcelRowId"></param>
        public void ModifyExportFlag(string DailylogId, int ExcelRowId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@DailylogId", "@ExcelRowId" };

                paramValues = new object[] { DailylogId, ExcelRowId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.SP_UPDATE_EXPORT_TO_EXCEL_FLAG, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Gid"></param>
        /// <returns></returns>
        public DataSet GroomerOperationToExport(string Gid)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@Gid" };

                paramValues = new object[] { Gid };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SP_GROOMER_OPERATION_TO_EXPORT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DailyLogID"></param>
        /// <returns></returns>
        public DataSet GetGroomerAppointmentDetails(int DailyLogID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@DailyLogID" };

                paramValues = new object[] { DailyLogID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_GROOMER_APPOINTMENT_DETAILS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AppointmentDate"></param>
        /// <param name="Enddate"></param>
        /// <returns></returns>
        public DataSet DeleteOldGroomerAppointment(DateTime AppointmentDate, DateTime Enddate)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppointmentDate", "@Enddate" };

                paramValues = new object[] { AppointmentDate, Enddate };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.DELETE_OLD_GROOMER_APPOINTMENT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FID"></param>
        public void UpdateExcelFileStatus(string FID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@FID" };

                paramValues = new object[] { FID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.UPDATE_EXCEL_FILE_STATUS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetExcelFileName()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_EXCEL_FILE_NAME, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetUnlockExcelFileName()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_UNLOCK_EXCEL_FILE_NAME, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName"></param>
        public void AddExcelFile(string FileName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@FileName" };

                paramValues = new object[] { FileName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.InsertData(StoreProcedure.ADD_EXCEL_FILE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName"></param>
        public void DeleteExcelFile(string FileName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@FileName" };

                paramValues = new object[] { FileName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.DELETE_EXCEL_FILE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FID"></param>
        public void UpdateExcelFileStatusUnlock(string FID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@FID" };

                paramValues = new object[] { FID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.UPDATE_EXCEL_FILE_STATUS_UNLOCK, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DailyLogId"></param>
        /// <param name="Flag"></param>
        public void updateExcelExported(int DailyLogId, int Flag)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@DailyLogId", "@Flag" };

                paramValues = new object[] { DailyLogId, Flag };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.UPDATE_EXCEL_EXPORTED, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DailyLogId"></param>
        /// <param name="Flag"></param>
        public void updateExcelExportedEndingMileage(int DailyLogId, int Flag)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@DailyLogId", "@Flag" };

                paramValues = new object[] { DailyLogId, Flag };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.UPDATE_EXCEL_EXPORTED_ENDING_MILEAGE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetUuExportedgroomerlogdata()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_UU_EXPORTED_GROOMER_LOG_DATA, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetUnExportedgroomerInventorydata()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_UN_EXPORTED_GROOMER_INVENTORY_DATA, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetUuExportedgroomerlogdataEndingM()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_UU_EXPORTED_GROOMER_LOG_DATA_ENDING_M, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="InvId"></param>
        /// <param name="Flag"></param>
        public void updateExcelExportedInventory(int InvId, int Flag)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@InvId", "@Flag" };

                paramValues = new object[] { InvId, Flag };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.UPDATE_EXCEL_EXPORTED_INVENTORY, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="strNewPassword"></param>
        public void AddPasswordLog(string FileName, string strNewPassword)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@FileName", "@Password" };

                paramValues = new object[] { FileName, strNewPassword };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.InsertData(StoreProcedure.INSERT_SP_SHEET_PWD_LOG, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public DataSet getExcelPasswordLog(string filename)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@FileName" };

                paramValues = new object[] { filename };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_SPREAD_SHEET_PASSWORD_LOG, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetFutureAppointmentID()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            DataTable dt = new DataTable();

            DataSet ds = new DataSet();

            IDataReader dr = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                dr = databaseObj.GetDataReader(StoreProcedure.GET_ALL_USER_FUTURE_APP_ID, Enumerations.Command_Type.StoredProcedure, paramList);

                dt.Load(dr);

                ds.Tables.Add(dt);

                return ds;
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllPreAppointmentID()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_PREPAY_APP_ID, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataSet GetFutureAppointment(int userID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@userId" };

                paramValues = new object[] { userID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_USER_FUTURE_APP, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="custUserName"></param>
        /// <returns></returns>
        public DataSet GetPastAppointment(string custUserName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@custEmail" };

                paramValues = new object[] { custUserName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_PAST_APPOINTMENTS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AppointmentId"></param>
        public void DeleteCustomerAppointment(int AppointmentId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppointmentId" };

                paramValues = new object[] { AppointmentId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.DELETE_CUSTOMER_FUTURE_APPOINTMENT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appid"></param>
        /// <returns></returns>
        public DataSet GetCustAppointmentbyID(int appid)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@appid" };

                paramValues = new object[] { appid };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_CUSTAPPOINTMENT_BY_ID, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetPrePaymentData()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_PREPAYMENT_DATA_LOG, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prePayId"></param>
        public void updatePrepaymentExcelExported(int prePayId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@prePayId" };

                paramValues = new object[] { prePayId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.UPDATE_PREPAYMENT_EXCEL_EXPORTED, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="liq1"></param>
        /// <param name="liq2"></param>
        /// <param name="liq3"></param>
        /// <param name="liq4"></param>
        /// <param name="liq5"></param>
        /// <param name="liq6"></param>
        /// <param name="liq7"></param>
        /// <param name="liq8"></param>
        /// <param name="liq9"></param>
        /// <param name="liq10"></param>
        /// <param name="liq11"></param>
        /// <param name="liq12"></param>
        /// <param name="liq13"></param>
        /// <param name="liq14"></param>
        /// <param name="liq15"></param>
        /// <param name="liq16"></param>
        /// <param name="liq17"></param>
        /// <param name="liq18"></param>
        /// <param name="liq19"></param>
        /// <param name="liq20"></param>
        /// <param name="liq21"></param>
        /// <param name="liq22"></param>
        /// <param name="liq23"></param>
        /// <param name="liq24"></param>
        /// <param name="liq25"></param>
        /// <param name="FleaTick22"></param>
        /// <param name="FleaTick44"></param>
        /// <param name="FleaTick88"></param>
        /// <param name="FleaTick132"></param>
        /// <param name="FleaTickCat"></param>
        /// <param name="Toothbrushes"></param>
        /// <param name="Wham"></param>
        /// <param name="Towels"></param>
        /// <param name="Treats"></param>
        /// <param name="Wipes"></param>
        /// <param name="CottonSwabs"></param>
        /// <param name="VetWrap"></param>
        /// <param name="PaperTowels"></param>
        /// <param name="GarbageBags"></param>
        /// <param name="Receipts"></param>
        /// <param name="Envelopes"></param>
        /// <param name="BusinessCards"></param>
        /// <param name="Other1"></param>
        /// <param name="Other2"></param>
        /// <param name="Other3"></param>
        /// <param name="Other4"></param>
        /// <param name="Other5"></param>
        /// <param name="Marketing1"></param>
        /// <param name="Marketing2"></param>
        /// <param name="Marketing3"></param>
        /// <param name="Marketing4"></param>
        /// <param name="Marketing5"></param>
        public void updateLabels(string liq1, string liq2, string liq3, string liq4, string liq5, string liq6, string liq7, string liq8,
        string liq9, string liq10, string liq11, string liq12, string liq13, string liq14, string liq15, string liq16, string liq17, string liq18,
        string liq19, string liq20, string liq21, string liq22, string liq23, string liq24, string liq25,
        string FleaTick22, string FleaTick44, string FleaTick88, string FleaTick132, string FleaTickCat, string Toothbrushes,
        string Wham, string Towels, string Treats, string Wipes, string CottonSwabs, string VetWrap, string PaperTowels,
        string GarbageBags, string Receipts, string Envelopes, string BusinessCards, string Other1, string Other2, string Other3, string Other4, string Other5,
        string Marketing1, string Marketing2, string Marketing3, string Marketing4, string Marketing5
        )
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@liq1", "@liq2", "@liq3", "@liq4", "@liq5", "@liq6", "@liq7", "@liq8", "@liq9", "@liq10", "@liq11", "@liq12", "@liq13", "@liq14", "@liq15", "@liq16", "@liq17", "@liq18", "@liq19", "@liq20", "@liq21", "@liq22", "@liq23", "@liq24", "@liq25", "@FleaTick22", "@FleaTick44", "@FleaTick88", "@FleaTick132", "@FleaTickCat", "@Toothbrushes", "@Wham", "@Towels", "@Treats", "@Wipes", "@CottonSwabs", "@VetWrap", "@PaperTowels", "@GarbageBags", "@Receipts", "@Envelopes", "@BusinessCards", "@Other1", "@Other2", "@Other3", "@Other4", "@Other5", "@Marketing1", "@Marketing2", "@Marketing3", "@Marketing4", "@Marketing5", "@liqId" };

                paramValues = new object[] { liq1, liq2, liq3, liq4, liq5, liq6, liq7, liq8, liq9, liq10, liq11, liq12, liq13, liq14, liq15, liq16, liq17, liq18, liq19, liq20, liq21, liq22, liq23, liq24, liq25, FleaTick22, FleaTick44, FleaTick88, FleaTick132, FleaTickCat, Toothbrushes, Wham, Towels, Treats, Wipes, CottonSwabs, VetWrap, PaperTowels, GarbageBags, Receipts, Envelopes, BusinessCards, Other1, Other2, Other3, Other4, Other5, Marketing1, Marketing2, Marketing3, Marketing4, Marketing5, 1 };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.UPDATE_LABELS, Enumerations.Command_Type.StoredProcedure, paramList);


            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet getInventoryLabels()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.INVENTORY_LIQUIDS_GET_ALL, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NameofCustomer"></param>
        /// <returns></returns>
        public int findCustomerInList(string NameofCustomer)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@EmailId" };

                paramValues = new object[] { NameofCustomer };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetCount(StoreProcedure.GROOMER_CUSTOMER_EMAIL_EXISTS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Apptdate"></param>
        /// <param name="ApptStart_Time"></param>
        /// <param name="ApptString"></param>
        /// <param name="ExpApptTime"></param>
        /// <param name="NameofCustomer"></param>
        /// <param name="customerEmail"></param>
        /// <param name="scheduledBy"></param>
        /// <param name="gid"></param>
        public void InsertFailedAppointments(string Apptdate, string ApptStart_Time, string ApptString, string ExpApptTime, string NameofCustomer, string customerEmail, string scheduledBy, int gid)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppointmentDate", "@AppointmentTime", "@Duration", "@CustomerName", "@CustomerEmail", "@AppointmentString", "@ScheduleBy", "@GroomerId" };

                paramValues = new object[] { Convert.ToDateTime(Apptdate), ApptStart_Time, ExpApptTime, NameofCustomer, customerEmail, ApptString, scheduledBy, gid };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.InsertData(StoreProcedure.INSERT_GROOMER_FAILED_APPOINTMENT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetFailedAppointments()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GROOMERS_GET_ALL_FAILED_APPOINTMENTS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AppointmentID"></param>
        public void ResetGroomerAppointmentStatus(string AppointmentID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.RESET_GROOMER_APPOINTMENT_STATUS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }
    }
}
