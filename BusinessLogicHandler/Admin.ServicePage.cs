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

namespace BCL.Admin.ServicePageMgr
{
    public class ServicePage : BaseData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserType"></param>
        /// <returns></returns>
        public DataSet GetServicePageAdmin(int UserType)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserType" };

                paramValues = new object[] { UserType };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_SERVICE_PAGE_ADMIN, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="ServiceID"></param>
        /// <param name="Title"></param>
        /// <param name="Description"></param>
        /// <param name="ImageName"></param>
        public void UpdateServicePageServices(int ServiceID, string Title, string Description, string ImageName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@ServiceID", "@Title", "@Description", "@ImageName" };

                paramValues = new object[] { ServiceID, Title, Description, ImageName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.UPDATE_SERVICE_PAGE_SERVICES, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="ServiceID"></param>
        /// <returns></returns>
        public DataSet GetServicePageServiceDetail(int ServiceID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@ServiceID" };

                paramValues = new object[] { ServiceID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_SERVICE_PAGE_SERVICE_DETAIL, Enumerations.Command_Type.StoredProcedure, paramList);
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
