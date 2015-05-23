using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Drawing;
using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;

using DataBaseHandler35;
using BCL.Common.StoreProcedure;
using BCL.Common.BasseDataAccess;

namespace BCL.User.UserAppointmentMgr
{
    public class UserAppointment : BaseData
    {
        public int AddAppointment(int UserID, DateTime Date1, string Time1, string Time2, int IsFlexible, int FlexID, string FlexDay, string FlexHr, int IsPrimery, string Address, int ConfirmBy, string Note)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserID", "@Date", "@Time1", "@Time2", "@IsFlexible", "@FlexID", "@FlexDay", "@FlexHr", "@IsPrimery", "@Address", "@ConfirmBy ", "@Note" };

                paramValues = new object[] { UserID, Date1, Time1, Time2, IsFlexible, FlexID, FlexDay, FlexHr, IsPrimery, Address, ConfirmBy, Note };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.ADD_APPOINTMENT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        public DataSet GetAllAppointment()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_APPOINTMENT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        public DataSet DeleteAppointment(string AppointmentID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppointmentID" };

                paramValues = new object[] { AppointmentID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.DELETE_APPOINTMENT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        public DataSet GetAppointment(int AppointmentID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppointmentID" };

                paramValues = new object[] { AppointmentID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_APPOINTMENT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        public DataSet GetAllAppointmentExport(DateTime StartDate, DateTime EndDate)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@StartDate", "@EndDate" };

                paramValues = new object[] { StartDate, EndDate };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_APPOINTMENT_EXPORT, Enumerations.Command_Type.StoredProcedure, paramList);
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
