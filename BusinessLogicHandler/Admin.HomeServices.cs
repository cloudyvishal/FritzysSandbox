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

namespace BCL.Admin.HomeServices
{
    public class HomeServices : BaseData
    {
        public DataSet GetAllHomeServiceAdmin(int UserType)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserType" };

                paramValues = new object[] { UserType };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_HOME_SERVICE_ADMIN, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        public void UpdateService(int ServiceID, string Title, string Description, string ImageName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@ServiceID", "@Title", "@Description", "@ImageName" };

                paramValues = new object[] { ServiceID, Title, Description, ImageName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.UPDATE_HOME_SERVICE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        public DataSet GetHomeServiceDetail(int ServiceID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@ServiceID" };

                paramValues = new object[] { ServiceID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_HOME_SERVICE_DETAIL, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        public DataSet GetAllFleaTickServiceAdmin(int UserType)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserType" };

                paramValues = new object[] { UserType };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_FLEA_AND_TICK_SERVICE_ADMIN, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        public void UpdateFleaandTickServices(int ServiceID, string Title, string Description, string ImageName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@ServiceID", "@Title", "@Description", "@ImageName" };

                paramValues = new object[] { ServiceID, Title, Description, ImageName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.UPDATE_FLEA_AND_TICK_SERVICES, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        public DataSet GetFleatickServiceDetail(int ServiceID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@ServiceID" };

                paramValues = new object[] { ServiceID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_FLEA_TICK_SERVICE_DETAIL_BY_SERVICE_ID, Enumerations.Command_Type.StoredProcedure, paramList);
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
