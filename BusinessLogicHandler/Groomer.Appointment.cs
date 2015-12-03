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

namespace BCL.Groomer.AppointmentMgr
{
    public class Appointment: BaseData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="ds"></param>
        /// <param name="valueField"></param>
        /// <param name="textField"></param>
        public static void FillDropDownList(System.Web.UI.WebControls.DropDownList ddl, System.Data.DataSet ds, string valueField, string textField)
        {
            ddl.Items.Clear();

            ddl.DataTextField = textField;

            ddl.DataValueField = valueField;

            ddl.DataSource = ds;

            ddl.DataBind();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AppDate"></param>
        /// <param name="APTId"></param>
        public void AddAppointmentslots(DateTime AppDate, int APTId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppDate", "@APTId" };

                paramValues = new object[] { AppDate, APTId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.ADD_APPOINTMENT_SLOTS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="AppDate"></param>
        /// <returns></returns>
        public DataSet GetAppointmentslots(DateTime AppDate)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppDate" };

                paramValues = new object[] { AppDate };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_APPOINTMENT_SLOTS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="AppDate"></param>
        /// <param name="APTId"></param>
        /// <returns></returns>
        public DataSet GetAppointmentslotsByTime(DateTime AppDate, int APTId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppDate", "@APTId" };

                paramValues = new object[] { AppDate, APTId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_APPOINTMENT_SLOTS_BY_TIME, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="AppDate"></param>
        /// <returns></returns>
        public DataSet GetAppointmentslotsToEdit(DateTime AppDate)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppDate" };

                paramValues = new object[] { AppDate };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_APPOINTMENT_SLOTS_TO_EDIT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetAppointmentsetDate()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_APPOINTMENTSET_DATE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetAppointmentTime()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_APPOINTMENT_TIME, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="AppDate"></param>
        public void DeleteAppointmentslots(DateTime AppDate)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppDate" };

                paramValues = new object[] { AppDate };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.DELETE_APPOINTMENT_SLOTS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="AppDate"></param>
        /// <returns></returns>
        public DataSet GetAppointmentslotsByDate(DateTime AppDate)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppDate" };

                paramValues = new object[] { AppDate };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_APPOINTMENT_SLOTS_BY_DATE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="AppDate"></param>
        public void AddAppointmentDate(DateTime AppDate)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppDate" };

                paramValues = new object[] { AppDate };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.ADD_APPOINTMENT_DATE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetAppointmentDate()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_APPOINTMENT_DATE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="AdId"></param>
        /// <returns></returns>
        public DataSet UpdateAppointmentdateStatus(string AdId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AdId" };

                paramValues = new object[] { AdId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.UPDATE_APPOINTMENTDATE_STATUS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="AppDate"></param>
        public void DeleteAppointmentsDate(DateTime AppDate)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppDate" };

                paramValues = new object[] { AppDate };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.DELETE_APPOINTMENTS_DATE, Enumerations.Command_Type.StoredProcedure, paramList);
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
