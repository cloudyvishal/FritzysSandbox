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

namespace BCL.Users.Management
{
    public class User : BaseData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LoginID"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public DataSet GetUser(string LoginID, string Password)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@Username", "@PassWord" };

                paramValues = new object[] { LoginID, Password };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_USER_LOGIN, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="SearchFor"></param>
        /// <param name="SearchText"></param>
        /// <returns></returns>
        public DataSet GetAllUser(string SearchFor, string SearchText,string UserType)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@SearchFor", "@SearchText" };

                paramValues = new object[] { SearchFor, SearchText };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_USER, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="UserID"></param>
        public void ChangeUserStatus(string UserID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserID" };

                paramValues = new object[] { UserID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.CHANGE_USER_STATUS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="UserID"></param>
        public void DeleteUser(string UserID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserID" };

                paramValues = new object[] { UserID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.DELETE_USER, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="Email"></param>
        /// <param name="Mobile"></param>
        /// <param name="Add1"></param>
        /// <param name="Add2"></param>
        /// <param name="UserType"></param>
        /// <returns></returns>
        public int AddAdminUser(string FirstName, string LastName, string Username, string Password, string Email, string Mobile, string Add1, string Add2, int UserType)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@FirstName", "@LastName", "@Username", "@Password", "@Email", "@Phone", "@Add1", "@Add2", "@UserType" };

                paramValues = new object[] { FirstName, LastName, Username, Password, Email, Mobile, Add1, Add2, UserType };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.ADD_ADMIN_USER_INSERT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataSet GetUserDetail(int UserID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserID" };

                paramValues = new object[] { UserID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_USER_DETAIL, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="UserID"></param>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="Email"></param>
        /// <param name="Mobile"></param>
        /// <param name="Add1"></param>
        /// <param name="Add2"></param>
        /// <param name="UserType"></param>
        /// <returns></returns>
        public int UpdateAdminUser(int UserID, string FirstName, string LastName, string Username, string Password, string Email, string Mobile, string Add1, string Add2, int UserType)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserID", "@FirstName", "@LastName", "@Username", "@Password", "@Email", "@Phone", "@Add1", "@Add2", "@UserType" };

                paramValues = new object[] { UserID, FirstName, LastName, Username, Password, Email, Mobile, Add1, Add2, UserType };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.UpdateData(StoreProcedure.UPDATE_ADMIN_USER, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="SearchFor"></param>
        /// <param name="SearchText"></param>
        /// <returns></returns>
        public DataSet GetAllAgent(string SearchFor, string SearchText)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@SearchFor", "@SearchText" };

                paramValues = new object[] { SearchFor, SearchText };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_AGENTS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="SearchFor"></param>
        /// <param name="SearchText"></param>
        /// <returns></returns>
        public DataSet GetAllManager(string SearchFor, string SearchText)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@SearchFor", "@SearchText" };

                paramValues = new object[] { SearchFor, SearchText };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_MANAGER, Enumerations.Command_Type.StoredProcedure, paramList);
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
