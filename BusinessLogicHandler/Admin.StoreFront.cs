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

namespace BCL.Admin.StoreFrontMgr
{
    public class StoreFront : BaseData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public DataSet GetLoginUser(string UserName, string Password)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserName", "@Password" };

                paramValues = new object[] { UserName, Password };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_LOGIN_USER_STORE_FRONT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetHomePageServices(int UserType)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserType" };

                paramValues = new object[] { UserType };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_HOME_PAGE_SERVICES, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PetType"></param>
        /// <returns></returns>
        public DataSet GetServicePageServices(int UserType, int PetType)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserType", "@PetType" };

                paramValues = new object[] { UserType, PetType };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_SERVICE_PAGE_SERVICES, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetAllServicePageServices(int UserType)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserType" };

                paramValues = new object[] { UserType };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_SERVICE_PAGE_SERVICES, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetFleaPageServices()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_FLEA_PAGE_SERVICES, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #region "ContactUS"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Email"></param>
        /// <param name="Mobile"></param>
        /// <param name="Message"></param>
        public void AddContactus(string FirstName, string LastName, string Email, string Mobile, string Message)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@FirstName", "@LastName", "@Email", "@Mobile", "@Message", };

                paramValues = new object[] { FirstName, LastName, Email, Mobile, Message };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.InsertData(StoreProcedure.ADD_CONTACT_US, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetAllContactus(string SearchFor, string SearchText)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@SearchFor", "@SearchText" };

                paramValues = new object[] { SearchFor, SearchText };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_CONTACT_US, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="ContactID"></param>
        public void DeleteContactUs(string ContactID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@ContactID" };

                paramValues = new object[] { ContactID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.DELETE_CONTACT_US, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetAllContactUsExport(DateTime StartDate, DateTime EndDate)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@StartDate", "@EndDate" };

                paramValues = new object[] { StartDate, EndDate };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_CONTACT_US_EXPORT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #endregion

        #region Service Page

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllDogService()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_DOG_SERVICE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetAllCatService()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_CAT_SERVICE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetAllCatDogService()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_CAT_DOG_SERVICE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="Page"></param>
        /// <returns></returns>
        public DataSet GetServiceDetailFront(int ServiceID, int Page)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@ServiceID", "@Page" };

                paramValues = new object[] { ServiceID, Page };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_SERVICE_DETAIL_FRONT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #endregion

        #region "Baner"

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetBanerPages()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_BANER_PAGES, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="BanerID"></param>
        /// <returns></returns>
        public DataSet GetBanerImage(int BanerID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@BanerID" };

                paramValues = new object[] { BanerID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_BANER_IMAGE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="BanerID"></param>
        /// <param name="ImageName"></param>
        public void UpdateBanerImage(int BanerID, string ImageName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@BanerID", "@ImageName" };

                paramValues = new object[] { BanerID, ImageName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.UPDATE_BANER_IMAGE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public int CheckPET(int PetID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PetID" };

                paramValues = new object[] { PetID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.UpdateData(StoreProcedure.CHECK_PET, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="BannerID"></param>
        public void DeleteBanner(string BannerID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@BannerID" };

                paramValues = new object[] { BannerID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.DELETE_BANNER, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PetType"></param>
        /// <param name="ImageName"></param>
        public void AddBanner(int PetType, string ImageName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PetType", "@ImageName" };

                paramValues = new object[] { PetType, ImageName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.InsertData(StoreProcedure.ADD_BANNER_INSERT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="Count"></param>
        /// <param name="PageName"></param>
        /// <returns></returns>
        public DataSet GetBanerID(int Count, string PageName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@Count", "@PageName" };

                paramValues = new object[] { Count, PageName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_BANER_ID, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #endregion

        #region "Additional Services"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SearchFor"></param>
        /// <param name="SearchText"></param>
        /// <returns></returns>
        public DataSet GetAdditionalServices(string SearchFor, string SearchText)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@SearchFor", "@SearchText" };

                paramValues = new object[] { SearchFor, SearchText };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ADDITIONAL_SERVICES, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetAdditionalServicesExport()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ADDITIONAL_SERVICES_EXPORT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="AdditionalServiceID"></param>
        /// <returns></returns>
        public int DeleteAdditionalServices(string AdditionalServiceID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AdditionalServiceID" };

                paramValues = new object[] { AdditionalServiceID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.UpdateData(StoreProcedure.DELETE_ADDITIONAL_SERVICES, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="AdditionalServiceID"></param>
        /// <returns></returns>
        public DataSet UpdateAdditionalServiceStatus(string AdditionalServiceID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AdditionalServiceID" };

                paramValues = new object[] { AdditionalServiceID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.UPDATE_ADDITIONAL_SERVICE_STATUS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="AdditionalServiceID"></param>
        /// <param name="ServiceName"></param>
        /// <returns></returns>
        public int UpdateAdditionalServices(int AdditionalServiceID, string ServiceName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AdditionalServiceID", "@ServiceName" };

                paramValues = new object[] { AdditionalServiceID, ServiceName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.UpdateData(StoreProcedure.UPDATE_ADDITIONAL_SERVICES, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="ServiceName"></param>
        /// <returns></returns>
        public int AddAdditionalService(string ServiceName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@ServiceName" };

                paramValues = new object[] { ServiceName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.ADD_ADDITIONAL_SERVICES, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="ServiceName"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public int AddAdditionalServiceExcel(string ServiceName, int Status)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@ServiceName", "@Status" };

                paramValues = new object[] { ServiceName, Status };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.ADD_ADDITIONAL_SERVICES_EXCEL, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #endregion

        #region "Breed"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PetTypeID"></param>
        /// <param name="SearchFor"></param>
        /// <param name="SearchText"></param>
        /// <returns></returns>
        public DataSet GetBreed(string PetTypeID, string SearchFor, string SearchText)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PetTypeID", "@SearchFor", "@SearchText" };

                paramValues = new object[] { PetTypeID, SearchFor, SearchText };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_BREED, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetBreedExport()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_BREED_EXPORT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="BreedID"></param>
        /// <returns></returns>
        public int DeleteBreed(string BreedID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@BreedID" };

                paramValues = new object[] { BreedID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.UpdateData(StoreProcedure.DELETE_BREED, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="BreedID"></param>
        /// <returns></returns>
        public DataSet UpdateBreedStatus(string BreedID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@BreedID" };

                paramValues = new object[] { BreedID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.UPDATE_BREED_STATUS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="BreedID"></param>
        /// <param name="BreedName"></param>
        /// <returns></returns>
        public int UpdateBreed(int BreedID, string BreedName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@BreedID", "@BreedName" };

                paramValues = new object[] { BreedID, BreedName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.UpdateData(StoreProcedure.UPDATE_BREED, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="BreedName"></param>
        /// <param name="PetType"></param>
        /// <returns></returns>
        public int AddBreed(string BreedName, int PetType)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@BreedName", "@PetType" };

                paramValues = new object[] { BreedName, PetType };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.ADD_BREED_INSERT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="BreedName"></param>
        /// <param name="PetType"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public int AddBreedExcel(string BreedName, int PetType, int Status)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@BreedName", "@PetType", "@Status" };

                paramValues = new object[] { BreedName, PetType, Status };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.ADD_BREED_EXCEL_INSERT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #endregion

        #region "Style"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SearchFor"></param>
        /// <param name="SearchText"></param>
        /// <returns></returns>
        public DataSet GetStyle(string SearchFor, string SearchText)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@SearchFor", "@SearchText" };

                paramValues = new object[] { SearchFor, SearchText };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_STYLE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetStyleExport()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_STYLE_EXPORT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="StyleID"></param>
        /// <returns></returns>
        public int DeleteStyle(string StyleID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@StyleID" };

                paramValues = new object[] { StyleID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.DELETE_STYLE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="StyleID"></param>
        /// <returns></returns>
        public DataSet UpdateStyleStatus(string StyleID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@StyleID" };

                paramValues = new object[] { StyleID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.UPDATE_STYLE_STATUS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="StyleID"></param>
        /// <param name="StyleName"></param>
        /// <returns></returns>
        public int UpdateStyle(int StyleID, string StyleName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@StyleID", "@StyleName" };

                paramValues = new object[] { StyleID, StyleName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.UpdateData(StoreProcedure.UPDATE_STYLE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="StyleName"></param>
        /// <returns></returns>
        public int AddStyle(string StyleName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@StyleName" };

                paramValues = new object[] { StyleName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.ADD_STYLE_INSERT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="StyleName"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public int AddStyleExcel(string StyleName, int Status)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@StyleName", "@Status" };

                paramValues = new object[] { StyleName, Status };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.ADD_STYLE_EXCEL_INSERT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #endregion

        #region "ReferalSource"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SearchFor"></param>
        /// <param name="SearchText"></param>
        /// <returns></returns>
        public DataSet GetReferalSource(string SearchFor, string SearchText)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@SearchFor", "@SearchText" };

                paramValues = new object[] { SearchFor, SearchText };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_REFERAL_SOURCE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="ReferalID"></param>
        /// <returns></returns>
        public int DeleteReferalSource(string ReferalID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@ReferalID" };

                paramValues = new object[] { ReferalID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.UpdateData(StoreProcedure.DELETE_REFERAL_SOURCE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="ReferalID"></param>
        /// <returns></returns>
        public DataSet UpdateReferalSourceStatus(string ReferalID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@ReferalID" };

                paramValues = new object[] { ReferalID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.UPDATE_REFERAL_SOURCE_STATUS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="ReferalID"></param>
        /// <param name="ReferalName"></param>
        /// <returns></returns>
        public int UpdateReferalSource(int ReferalID, string ReferalName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@ReferalID", "@ReferalName" };

                paramValues = new object[] { ReferalID, ReferalName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.UPDATE_REFERAL_SOURCE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="ReferalName"></param>
        /// <returns></returns>
        public int AddReferalSource(string ReferalName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@ReferalName" };

                paramValues = new object[] { ReferalName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.ADD_REFERAL_SOURCE_INSERT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        #endregion "Additional Services"

        #region News

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public DataSet GetNewsFront(int NewsID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@NewsID" };

                paramValues = new object[] { NewsID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_NEWS_FRONT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="Key"></param>
        /// <returns></returns>
        public DataSet GetServiceSearch(string Key)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@KeyWord" };

                paramValues = new object[] { Key };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SP_GET_SERVICES_BY_SEARCH, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="Key"></param>
        /// <returns></returns>
        public DataSet GetProductSearch(string Key)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@KeyWord" };

                paramValues = new object[] { Key };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SP_GET_PRODUCT_BY_SEARCH, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="Key"></param>
        /// <returns></returns>
        public DataSet GetFriendSearch(string Key)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@KeyWord" };

                paramValues = new object[] { Key };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SP_GET_FRIEND_SEARCH, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetFleaandTickServices(int UserType)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserType" };

                paramValues = new object[] { UserType };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_FLEA_AND_TICK_SERVICES, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        public DataSet GetAppInfoforPayment(string UserName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserName" };

                paramValues = new object[] { UserName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_APPT_INFO_FOR_PAYMENT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        public IDataReader CheckOrderRefNo(string OrdNumber)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@OrderNo" };

                paramValues = new object[] { OrdNumber };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataReader(StoreProcedure.SP_CHECK_ORDER_REF, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        public void GetShopperInfo(int GId, string FirstName, string LastName, string Address1, string Address2, string City, string State, string Zip, string Country, string Phone, string Email
        , string CardType, string CreditCardNo, string ValidYear, string ValidMonth, string VerificationCode, decimal Payment_Amount, decimal SandH, decimal Tax, string ordno)
        {
            string card = CreditCardNo;

            string cardno = card.Substring(card.Length - 4);

            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GID" ,"@FirstName" ,"@LastName" ,"@Address1","@Address2","@City" ,"@State","@Zip","@Country","@Phone","@Email","@Cardtype" ,"@CreditCardNo","@ValidYear","@ValidMonth","@VerificationCode","@Payment_Amount" ,"@SandH","@Tax","@OrdRefNo" };

                paramValues = new object[] { GId, FirstName, LastName, Address1, Address2, City, State, Zip, Country, Phone, Email, CardType, cardno, ValidYear, ValidMonth, VerificationCode, Payment_Amount, SandH, Tax, ordno };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.InsertData(StoreProcedure.GET_SHOPPER_INFO, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        public void UpdatePGResponseDetails(string result, string dailylogid, string responseid, string PayID, string Response, string BillTxnRefNumber, string AuthCode)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@Result", "@DailyLogID", "@ResponseID", "@PaymentID", "@Response", "@BillTxnRefno", "@Authcode", "@IsSucceded" };

                paramValues = new object[] { result, dailylogid, responseid, PayID, Response, BillTxnRefNumber, AuthCode };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.UPDATE_SHOPPER_RESPONSE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        public DataSet UpdateSyncAppStatus(int syncid, string pstatus, int payid, decimal tip)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@syncid", "@pstatus", "@payid", "@tipamt" };

                paramValues = new object[] { syncid, pstatus, payid, tip };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.UPDATE_STATUS_IN_SYNC_APP, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        public void InsertAppointmentPrePayment(int UserID, decimal RevenueCost, decimal PriorRevenueCost, decimal TipCost, decimal TotalAmt, string Description, int PayID, int apptID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserId", "@RevAmt", "@PriorAmt", "@TipAmt", "@TotalAmt", "@payDescription", "@PaymentId", "@AppointmentID", "@Addedon" };

                paramValues = new object[] { UserID, RevenueCost, PriorRevenueCost, TipCost, TotalAmt, Description, PayID, apptID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.InsertData(StoreProcedure.INSERT_APPOINTMENT_PRE_PAYMENT, Enumerations.Command_Type.StoredProcedure, paramList);
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
