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

namespace BCL.Utility.GlobalFunctions
{
    public class Global : BaseData
    {
        #region Manage Password For User

        /// <summary>
        /// Get Admin Password
        /// </summary>
        /// <param name="forgotUserName"></param>
        /// <returns></returns>
        public DataSet GetPasswordAdmin(string forgotUserName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserName" };

                paramValues = new object[] { forgotUserName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.FORGOT_PASSWORD_FRONT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <returns></returns>
        public DataSet GetPassword(string UserName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserName" };

                paramValues = new object[] { UserName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.FORGOT_PASSWORD, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="CurrentPassword"></param>
        /// <param name="NewPassword"></param>
        /// <returns></returns>
        public int ChangeUserName(int UserID, string CurrentPassword, string NewPassword)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserID", "@CurrentPassword", "@NewPassword" };

                paramValues = new object[] { UserID, CurrentPassword, NewPassword };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.CHANGE_USER_NAME, Enumerations.Command_Type.StoredProcedure, paramList);

            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #endregion

        #region Manage Suggestions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Email"></param>
        /// <param name="Phone"></param>
        /// <param name="Comment"></param>
        public void AddSuggestion(string Name, string Email, string Phone, string Comment)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@Name", "@Email", "@Phone", "@Comment" };

                paramValues = new object[] { Name, Email, Phone, Comment };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.ADD_SUGGESTION_INSERT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="SuggestionID"></param>
        public void DeleteSuggestion(string SuggestionID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@SuggestionID" };

                paramValues = new object[] { SuggestionID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.DELETE_SUGGESTION, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetAllSuggestion(string SearchFor, string SearchText)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@SearchFor", "@SearchText" };

                paramValues = new object[] { SearchFor, SearchText };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_SUGGESTION, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="SuggestionID"></param>
        /// <returns></returns>
        public DataSet GetSuggestion(int SuggestionID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@SuggestionID" };

                paramValues = new object[] { SuggestionID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SUGGESTION_GET_BY_ID, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public DataSet GetAllSuggestionExport(DateTime StartDate, DateTime EndDate)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@StartDate", "@EndDate" };

                paramValues = new object[] { StartDate, EndDate };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_SUGGESTION_EXPORT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetTopSuggestion()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_TOP_SUGGESTION, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #endregion

        #region News Management

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SearchFor"></param>
        /// <param name="SearchText"></param>
        /// <returns></returns>
        public DataSet GetAllNews(string SearchFor, string SearchText)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@SearchFor", "@SearchText" };

                paramValues = new object[] { SearchFor, SearchText };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_NEWS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetNewsOnStoreFront()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_NEWS_ON_STORE_FRONT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="NewsTitle"></param>
        /// <param name="ShortDescription"></param>
        /// <param name="Description"></param>
        public void AddNews(string NewsTitle, string ShortDescription, string Description)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@NewsTitle", "@ShortDescription", "@Description" };

                paramValues = new object[] { NewsTitle, ShortDescription, Description };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.ADD_NEWS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="NewsID"></param>
        /// <param name="NewsTitle"></param>
        /// <param name="ShortDescription"></param>
        /// <param name="Description"></param>
        public void UpdateNews(int NewsID, string NewsTitle, string ShortDescription, string Description)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@NewsID", "@NewsTitle", "@ShortDescription", "@Description" };

                paramValues = new object[] { NewsID, NewsTitle, ShortDescription, Description };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.UPDATE_NEWS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="NewsID"></param>
        public void DeleteNews(string NewsID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@NewsID" };

                paramValues = new object[] { NewsID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.DELETE_NEWS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="NewsID"></param>
        public void UpdateNewsStatus(string NewsID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@NewsID" };

                paramValues = new object[] { NewsID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.UPDATE_NEWS_STATUS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public DataSet GetNews(int NewsID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@NewsID" };

                paramValues = new object[] { NewsID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_NEWS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="Position"></param>
        public void NewsDown(int Position)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@Position" };

                paramValues = new object[] { Position };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.NEWS_DOWN, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="Position"></param>
        public void NewsUp(int Position)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@Position" };

                paramValues = new object[] { Position };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.NEWS_UP, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="NewsID"></param>
        /// <param name="Position"></param>
        public void NewsPosition(int NewsID, int Position)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@NewsID", "@Position" };

                paramValues = new object[] { NewsID, Position };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.NEWS_POSITION, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #endregion

        #region Friend

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SearchFor"></param>
        /// <param name="SearchText"></param>
        /// <returns></returns>
        public DataSet GetAllFriend(string SearchFor, string SearchText)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@SearchFor", "@SearchText" };

                paramValues = new object[] { SearchFor, SearchText };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_FRIEND, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="Title"></param>
        /// <param name="Description"></param>
        /// <param name="Logo"></param>
        /// <param name="RefLink"></param>
        public void AddFriend(string Title, string Description, string Logo, string RefLink)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@Title", "@Description", "@Logo", "@RefLink" };

                paramValues = new object[] { Title, Description, Logo, RefLink };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.ADD_FRIEND_INSERT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="FriendID"></param>
        /// <param name="Title"></param>
        /// <param name="Description"></param>
        /// <param name="Logo"></param>
        /// <param name="RefLink"></param>
        public void UpdateFriends(int FriendID, string Title, string Description, string Logo, string RefLink)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@FriendID", "@Title", "@Description", "@Logo", "@RefLink" };

                paramValues = new object[] { FriendID, Title, Description, Logo, RefLink };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.UPDATE_FRIENDS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="FriendID"></param>
        public void DeleteFriend(string FriendID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@FriendID" };

                paramValues = new object[] { FriendID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.DELETE_FRIEND, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="FriendID"></param>
        public void UpdateFriendStatus(string FriendID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@FriendID" };

                paramValues = new object[] { FriendID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.UPDATE_FRIEND_STATUS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="FriendID"></param>
        /// <returns></returns>
        public DataSet GetFriend(int FriendID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@FriendID" };

                paramValues = new object[] { FriendID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_FRIEND, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="Position"></param>
        public void FriendDown(int Position)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@Position" };

                paramValues = new object[] { Position };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.FRIEND_DOWN, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="Position"></param>
        public void FriendUp(int Position)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@Position" };

                paramValues = new object[] { Position };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.FRIEND_UP, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="FriendID"></param>
        /// <param name="Position"></param>
        public void FriendPosition(int FriendID, int Position)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@FriendID", "@Position" };

                paramValues = new object[] { FriendID, Position };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.FRIEND_POSITION, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllFriendFront()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_FRIEND_FRONT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #region Service Location

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Zipcode"></param>
        /// <returns></returns>
        public DataSet GetZipCodeFront(string Zipcode)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@Zipcode" };

                paramValues = new object[] { Zipcode };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ZIP_CODE_FRONT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetServiceLocations(string SearchFor, string SearchText)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@SearchFor", "@SearchText" };

                paramValues = new object[] { SearchFor, SearchText };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_SERVICE_LOCATIONS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetServiceLocationsExport()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_SERVICE_LOCATIONS_EXPORT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="ZipCodeID"></param>
        public void ChangeServiceLocationStatus(string ZipCodeID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@ZipCodeID" };

                paramValues = new object[] { ZipCodeID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.CHANGE_SERVICE_LOCATION_STATUS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="ZipCodeID"></param>
        public void ChangeServiceLocationAvailable(string ZipCodeID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@ZipCodeID" };

                paramValues = new object[] { ZipCodeID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.CHANGE_SERVICE_LOCATION_AVAILABLE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="ZipCodeID"></param>
        public void DeleteServiceLocation(string ZipCodeID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@ZipCodeID" };

                paramValues = new object[] { ZipCodeID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.DELETE_SERVICE_LOCATION, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="ZipCode"></param>
        /// <param name="City"></param>
        /// <param name="State"></param>
        /// <param name="Status"></param>
        /// <param name="ZipType"></param>
        /// <returns></returns>
        public int AddZipCode(string ZipCode, string City, string State, int Status, string ZipType)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@ZipCode", "@City", "@State", "@Status", "@ZipType" };

                paramValues = new object[] { ZipCode, City, State, Status, ZipType };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.ADD_ZIP_CODE_INSERT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #endregion

        #region "Image Functions"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lcFilename"></param>
        /// <param name="lnWidth"></param>
        /// <param name="lnHeight"></param>
        /// <returns></returns>
        public static Bitmap CreateThumbnail(System.Drawing.Image lcFilename, int lnWidth, int lnHeight)
        {
            Bitmap bmpOut = null;

            try
            {
                Bitmap loBMP = new Bitmap(lcFilename);

                ImageFormat loFormat = loBMP.RawFormat;
                decimal lnRatio;
                int lnNewWidth = 0;
                int lnNewHeight = 0;

                //*** If the image is smaller than a thumbnail just return it

                if (loBMP.Width < lnWidth && loBMP.Height < lnHeight)

                    return loBMP;

                if (loBMP.Width > loBMP.Height)
                {
                    lnRatio = (decimal)lnWidth / loBMP.Width;

                    lnNewWidth = lnWidth;

                    decimal lnTemp = loBMP.Height * lnRatio;

                    lnNewHeight = (int)lnTemp;

                }

                else
                {
                    lnRatio = (decimal)lnHeight / loBMP.Height;

                    lnNewHeight = lnHeight;

                    decimal lnTemp = loBMP.Width * lnRatio;

                    lnNewWidth = (int)lnTemp;
                }

                bmpOut = new Bitmap(lnNewWidth, lnNewHeight);

                Graphics g = Graphics.FromImage(bmpOut);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                g.FillRectangle(Brushes.White, 0, 0, lnNewWidth, lnNewHeight);

                g.DrawImage(loBMP, 0, 0, lnNewWidth, lnNewHeight);

                loBMP.Dispose();

                return bmpOut;
            }
            finally
            { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lcFilename"></param>
        /// <returns></returns>
        public static Bitmap CheckImageAspectRatio(System.Drawing.Image lcFilename)
        {
            int lnWidth = 80;

            System.Drawing.Bitmap bmpOut = null;

            try
            {
                Bitmap loBMP = new Bitmap(lcFilename);

                ImageFormat loFormat = loBMP.RawFormat;

                decimal lnRatio;

                int lnNewWidth = 0;

                int lnNewHeight = 0;

                if (loBMP.Width < lnWidth)
                {
                    return loBMP;
                }
                if (loBMP.Width > loBMP.Height)
                {
                    lnRatio = (decimal)lnWidth / loBMP.Width;

                    lnNewWidth = lnWidth;

                    decimal lnTemp = loBMP.Height * lnRatio;

                    lnNewHeight = (int)lnTemp;
                }
                else
                {
                    lnRatio = (decimal)lnWidth / loBMP.Height;

                    lnNewHeight = lnWidth;

                    decimal lnTemp = loBMP.Width * lnRatio;

                    lnNewWidth = (int)lnTemp;
                }

                bmpOut = new Bitmap(lnNewWidth, lnNewHeight);

                Graphics g = Graphics.FromImage(bmpOut);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                g.FillRectangle(Brushes.White, 0, 0, lnNewWidth, lnNewHeight);

                g.DrawImage(loBMP, 0, 0, lnNewWidth, lnNewHeight);

                loBMP.Dispose();

                return bmpOut;
            }
            finally
            { }
        }

        #endregion

        #region ContactUs

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ContactID"></param>
        /// <returns></returns>
        public DataSet GetContactInfo(int ContactID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@ContactID" };

                paramValues = new object[] { ContactID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_CONTACT_INFO, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #endregion

        #region Users

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SearchFor"></param>
        /// <param name="SearchText"></param>
        /// <returns></returns>
        public DataSet GetAllUserFront(string SearchFor, string SearchText)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@SearchFor", "@SearchText" };

                paramValues = new object[] { SearchFor, SearchText };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_USER_FRONT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet DeleteUsers(string UserID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserID" };

                paramValues = new object[] { UserID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.DELETE_USERS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetUserInfo(int UserID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserID" };

                paramValues = new object[] { UserID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_USER_INFO, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public DataSet GetAllUserFrontExport(string StartDate, string EndDate)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@StartDate", "@EndDate" };

                paramValues = new object[] { StartDate, EndDate };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_USER_FRONT_EXPORT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PetID"></param>
        /// <returns></returns>
        public DataSet GetPetServices(int PetID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PetID" };

                paramValues = new object[] { PetID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_PET_SERVICES, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetTopUserFront()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_TOP_USER_FRONT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetTopContactUS()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_TOP_CONTACT_US, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetTopAppointment()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_TOP_APPOINTMENT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PetID"></param>
        public void DeleteUserPet(int PetID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PetID" };

                paramValues = new object[] { PetID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.DELETE_USER_PET, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #endregion

        #region State

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllState()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_STATE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #endregion

        #region User Access

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserType"></param>
        /// <param name="PageName"></param>
        /// <param name="Module"></param>
        /// <returns></returns>
        public int AddUserAccess(int UserType, string PageName, string Module)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserType", "@PageName", "@Module" };

                paramValues = new object[] { UserType, PageName, Module };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.ADD_ADMIN_USER_ACCESS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetAllUserType()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_USER_TYPE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="AccessID"></param>
        /// <returns></returns>
        public DataSet DeleteUserAccess(string AccessID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AccessID" };

                paramValues = new object[] { AccessID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.DELETE_USER_ACCESS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="UserType"></param>
        /// <returns></returns>
        public DataSet GetPageName(int UserType)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserType" };

                paramValues = new object[] { UserType };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_CURRENT_PAGE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="AccessID"></param>
        /// <returns></returns>
        public DataSet ChangeUserAccess(string AccessID, int UserType)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AccessID", "@UserTypeId" };

                paramValues = new object[] { AccessID, UserType };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.CHANGE_USER_ACCESS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #endregion

        #region Pages

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllPages()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_PAGES, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #endregion

        #region Meta

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SearchFor"></param>
        /// <param name="SearchText"></param>
        /// <param name="PageID"></param>
        /// <returns></returns>
        public DataSet GetMeta(string SearchFor, string SearchText, int PageID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@SearchFor", "@SearchText", "@PageID" };

                paramValues = new object[] { SearchFor, SearchText, PageID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_META, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetPageList()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_PAGE_LIST, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="MetaID"></param>
        public void DeleteMetaTag(string MetaID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@MetaID" };

                paramValues = new object[] { MetaID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.DELETE_META_TAG, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PageID"></param>
        /// <param name="MetaName"></param>
        /// <param name="MetaContent"></param>
        /// <param name="keywords"></param>
        /// <returns></returns>
        public DataSet AddMeta(int PageID, string MetaName, string MetaContent, string keywords)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PageID", "@MetaName", "@MetaContent", "@Keywords" };

                paramValues = new object[] { PageID, MetaName, MetaContent, keywords };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.DELETE_META_TAG, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="MetaID"></param>
        /// <returns></returns>
        public DataSet GetMetaDetail(int MetaID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@MetaID" };

                paramValues = new object[] { MetaID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_META_DETAIL, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="MetaID"></param>
        /// <param name="MetaName"></param>
        /// <param name="MetaContent"></param>
        /// <param name="Keywords"></param>
        public void UpdateMeta(int MetaID, string MetaName, string MetaContent, string Keywords)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@MetaID", "@MetaName", "@MetaContent", "@Keywords" };

                paramValues = new object[] { MetaID, MetaName, MetaContent, Keywords };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.UPDATE_META, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PageName"></param>
        /// <returns></returns>
        public DataSet GetMetaFront(String PageName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PageName" };

                paramValues = new object[] { PageName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_META_FRONT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PageID"></param>
        /// <param name="PageTitle"></param>
        /// <returns></returns>
        public DataSet UpdateTitle(int PageID, string PageTitle)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PageID", "@PageTitle" };

                paramValues = new object[] { PageID, PageTitle };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.UPDATE_TITLE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #endregion

        #region AddmitionalServices

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllAdditionalServicesAdmin()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ADDITIONAL_SERVICES_ADMIN, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #endregion

        #region Email

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllMail()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_MAIL, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PageName"></param>
        /// <param name="Subject"></param>
        /// <returns></returns>
        public DataSet UpdateSubject(string PageName, string Subject)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PageName", "@Subject" };

                paramValues = new object[] { PageName, Subject };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.UPDATE_SUBJECT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PageName"></param>
        /// <returns></returns>
        public DataSet GetEmailSubject(string PageName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PageName" };

                paramValues = new object[] { PageName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_EMAIL_SUBJECT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #endregion

        #region Pet

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PetID"></param>
        /// <returns></returns>
        public DataSet getPetInfo(int PetID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PetID" };

                paramValues = new object[] { PetID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_PET_INFO, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PetID"></param>
        /// <param name="PetType"></param>
        /// <param name="PetName"></param>
        /// <param name="BreedID"></param>
        /// <param name="Years"></param>
        /// <param name="Weight"></param>
        /// <param name="Length"></param>
        /// <param name="Spa"></param>
        /// <param name="StyleID"></param>
        /// <param name="AdditionalService"></param>
        public void UpdatePetAdmin(int PetID, int PetType, string PetName, int BreedID, int Years, decimal Weight, decimal Length, int Spa, int StyleID, string AdditionalService)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PetID", "@PetType", "@PetName", "@BreedID", "@Years", "@Weight", "@Length", "@Spa", "@StyleID", "@AdditionalService" };

                paramValues = new object[] { PetID, PetType, PetName, BreedID, Years, Weight, Length, Spa, StyleID, AdditionalService };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.UPDATE_PET_ADMIN, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet DeleteAllBannerNow()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.DELETE_ALL_BANNER_NOW, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet DeleteAllRow()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.DELETE_ALL_ROW, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetBackup()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SP_BACKUP, Enumerations.Command_Type.StoredProcedure, paramList);
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
