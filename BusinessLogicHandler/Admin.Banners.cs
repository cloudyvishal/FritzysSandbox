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

namespace BCL.Admin.BannerMgr
{
    /// <summary>
    /// 
    /// </summary>
    public class Banners : BaseData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PageID"></param>
        /// <returns></returns>
        public DataSet GetUserTypeID(int PageID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PageID" };

                paramValues = new object[] { PageID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_USER_TYPE_ID, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetDefaultCouponName()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_DEFAULT_COUPON_NAME, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="CouponName"></param>
        /// <returns></returns>
        public DataSet UpdateDefaultBannerCouponName(string CouponName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@CouponName" };

                paramValues = new object[] { CouponName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.UPDATE_DEFAULT_BANNER_COUPON_NAME, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PageType"></param>
        /// <param name="UserType"></param>
        /// <param name="BannerName"></param>
        /// <param name="ImagePath"></param>
        /// <param name="CouponLink"></param>
        /// <param name="MaxPosition"></param>
        /// <param name="NumberOfRepeation"></param>
        /// <returns></returns>
        public int AddBanner(int PageType, int UserType, string BannerName, string ImagePath, string CouponLink, string MaxPosition, string NumberOfRepeation)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PageType", "@UserType", "@BannerName", "@ImagePath", "@CouponLink", "@MaxPosition", "@NumberOfRepeation" };

                paramValues = new object[] { PageType, UserType, BannerName, ImagePath, CouponLink, MaxPosition, NumberOfRepeation };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.ADD_BANNER, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public int GetMaxBannerId()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.GET_MAX_BANNER_ID, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public int getMaxMobileId()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.GET_MAX_MOBILE_BANNER_ID, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="BannerName"></param>
        /// <param name="bannerpath"></param>
        /// <param name="BId"></param>
        /// <param name="virtualmobilepath"></param>
        public void InsertInBannerList(string BannerName, string bannerpath, int BId, string virtualmobilepath)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@BannerName", "@bannerpath", "@BId", "@virtualmobilepath" };

                paramValues = new object[] { BannerName, bannerpath, BId, virtualmobilepath };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataReader(StoreProcedure.INSERT_IN_BANNER_LIST, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetBannerList()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_BANNER_LIST, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PageId"></param>
        /// <param name="UserId"></param>
        /// <param name="BannerId"></param>
        /// <param name="Frequency"></param>
        /// <param name="IsCoupon"></param>
        /// <param name="PageName"></param>
        /// <param name="BannerOrder"></param>
        /// <returns></returns>
        public int InsertInSetBanner(int PageId, int UserId, int BannerId, int Frequency, bool IsCoupon, string PageName, int BannerOrder)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PageId", "@UserId", "@BannerId", "@Frequency", "@IsCoupon", "@PageName", "@BannerOrder" };

                paramValues = new object[] { PageId, UserId, BannerId, Frequency, IsCoupon, PageName, BannerOrder };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.INSERT_IN_SET_BANNER, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="BannerId"></param>
        /// <param name="UserId"></param>
        /// <param name="PageId"></param>
        /// <returns></returns>
        public DataSet GetFrequencyFromSetBanner(int BannerId, int UserId, int PageId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@BannerId", "@UserId", "@PageId" };

                paramValues = new object[] { BannerId, UserId, PageId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_FREQUENCY_FROM_SET_BANNER, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetUserTypeList()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_USER_TYPE_LIST, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetPageTitleList()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_PAGE_TITLE_LIST, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PageId"></param>
        /// <param name="UserId"></param>
        public void DeletePreviousSetBanner(int PageId, int UserId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PageId", "@UserId" };

                paramValues = new object[] { PageId, UserId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.DELETE_PREVIOUS_SET_BANNER, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="ImagePath"></param>
        public void InsertImage(string ImagePath)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@ImagePath" };

                paramValues = new object[] { ImagePath };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.SP_INSERT_IMAGE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetUploadImage()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SP_SELECT_Images, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="MobileBannerId"></param>
        /// <param name="BannerId"></param>
        public void DeleteImage(int MobileBannerId, int BannerId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@MobileBannerId", "@BannerId" };

                paramValues = new object[] { MobileBannerId, BannerId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.SP_DELETE_IMAGE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetXML()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.PROC_XML_Images, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataSet GetCategoryImages(string UserId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserId" };

                paramValues = new object[] { UserId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SP_SELECT_Images_CATEGORY, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="UserId"></param>
        /// <param name="PageId"></param>
        /// <returns></returns>
        public DataSet GetBannerIdFrequencyFromSetBanner(int UserId, int PageId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserId", "@PageId" };

                paramValues = new object[] { UserId, PageId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_BANNER_ID_FREQUENCY_FROM_SET_BANNER, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="BannerId"></param>
        /// <returns></returns>
        public DataSet GetBannerImageNameandpath(int BannerId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@BannerId" };

                paramValues = new object[] { BannerId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_BANNER_IMAGE_NAME_AND_PATH, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataSet GetPagesNameFromSetBanners(int Id)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@Id" };

                paramValues = new object[] { Id };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_PAGES_NAME_FROM_SET_BANNERS, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PageId"></param>
        /// <param name="UserCount"></param>
        /// <returns></returns>
        public DataSet GetPageanduserTypes(int PageId, int UserCount)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PageId", "@UserCount" };

                paramValues = new object[] { PageId, UserCount };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_PAGE_AND_USER_TYPES, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PageId"></param>
        /// <param name="UserId"></param>
        /// <param name="BannerId"></param>
        /// <returns></returns>
        public DataSet CheckIsCoupon(int PageId, int UserId, int BannerId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PageId", "@UserId", "@BannerId" };

                paramValues = new object[] { PageId, UserId, BannerId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.CHECK_IS_COUPON, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PageId"></param>
        /// <param name="UserId"></param>
        /// <param name="BannerId"></param>
        /// <returns></returns>
        public DataSet GetDefaultBanner(int PageId, int UserId, int BannerId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PageId", "@UserId", "@BannerId" };

                paramValues = new object[] { PageId, UserId, BannerId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_DEFAULT_BANNER, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="BannerId"></param>
        /// <param name="PageId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public int InsertInDefaultBanner(int BannerId, int PageId, int UserId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@BannerId", "@PageId", "@UserId" };

                paramValues = new object[] { BannerId, PageId, UserId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.INSERT_IN_DEFAULT_BANNER, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PageId"></param>
        /// <param name="UserId"></param>
        public void DeleteDefaultBanner(int PageId, int UserId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PageId", "@UserId" };

                paramValues = new object[] { PageId, UserId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.DELETE_DEFAULT_BANNER, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PageId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataSet GetPageIdandUserId(int PageId, int UserId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PageId", "@UserId" };

                paramValues = new object[] { PageId, UserId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_PAGE_ID_AND_USER_ID, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="BannerId"></param>
        /// <returns></returns>
        public DataSet CheckUsedDefaultBanner(int BannerId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@BannerId" };

                paramValues = new object[] { BannerId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.CHECK_USED_DEFAULT_BANNER, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="BannerId"></param>
        /// <returns></returns>
        public DataSet CheckUsedBannerList(int BannerId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@BannerId" };

                paramValues = new object[] { BannerId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.CHECK_USED_BANNER_LIST, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="BannerId"></param>
        public void DeleteUnusedBanner(int BannerId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@BannerId" };

                paramValues = new object[] { BannerId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.DELETE_UNUSED_BANNER, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="MobileBannerId"></param>
        public void DeleteMobileBanner(int MobileBannerId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@MobileBannerId" };

                paramValues = new object[] { MobileBannerId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.DELETE_MOBILE_BANNER, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="BannerId"></param>
        /// <param name="PageId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public int InsertInDefaultCopon(int BannerId, int PageId, int UserId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@BannerId", "@PageId", "@UserId" };

                paramValues = new object[] { BannerId, PageId, UserId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.INSERT_IN_DEFAULT_COPON, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PageId"></param>
        /// <param name="UserId"></param>
        public void DeleteDefaultCopon(int PageId, int UserId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PageId", "@UserId" };

                paramValues = new object[] { PageId, UserId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.DELETE_DEFAULT_COPON, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PageId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataSet GetDefaultCopon(int PageId, int UserId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PageId", "@UserId" };

                paramValues = new object[] { PageId, UserId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_DEFAULT_COPON, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PageId"></param>
        /// <param name="UserId"></param>
        /// <param name="BannerId"></param>
        /// <returns></returns>
        public DataSet GetDefaultCoponForBanId(int PageId, int UserId, int BannerId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PageId", "@UserId", "@BannerId" };

                paramValues = new object[] { PageId, UserId, BannerId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_DEFAULT_COPON_FOR_BAN_ID, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PageId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataSet GetOrderOfBannerId(int PageId, int UserId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PageId", "@UserId" };

                paramValues = new object[] { PageId, UserId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ORDER_OF_BANNER_ID, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PageId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataSet GetoneDefaultBanner(int PageId, int UserId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PageId", "@UserId" };

                paramValues = new object[] { PageId, UserId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ONE_DEFAULT_BANNER, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="PageId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataSet GetoneDefaultCoupon(int PageId, int UserId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PageId", "@UserId" };

                paramValues = new object[] { PageId, UserId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ONE_DEFAULT_COUPON, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetPagenamefromSetBanner()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_PAGE_NAME_FROM_SET_BANNER, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="BannerId"></param>
        /// <returns></returns>
        public DataSet GetNotPageanduserTypes(string BannerId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@BannerId" };

                paramValues = new object[] { BannerId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_NOT_PAGE_AND_USER_TYPES, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="img_id"></param>
        /// <param name="priority"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public int newbannerupdate(int img_id, int priority, string category)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@BannerId", "@PageId", "@UserId" };

                paramValues = new object[] { img_id, priority, category };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.NEW_BANNER_UPDATE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        public DataSet CheckUsedMobileBanner(int MobileBannerId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@MobileBannerId" };

                paramValues = new object[] { MobileBannerId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.CHECK_USED_MOBILE_BANNER_LIST, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="MobileBannerId"></param>
        public void DeleteUnusedMobileBanner(int MobileBannerId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@MobileBannerId" };

                paramValues = new object[] { MobileBannerId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.DELETE_UNUSED_MOBILE_BANNER, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="BannerId"></param>
        /// <returns></returns>
        public DataSet CheckUsedMobileBannerList(int BannerId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@BannerId" };

                paramValues = new object[] { BannerId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.CHECK_USED_MOBILE_DEFAULT_BANNER, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetXMLNewMobile()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.PROC_XML_Images_MOBILE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="Id"></param>
        /// <param name="Priority"></param>
        /// <param name="Category"></param>
        /// <param name="boolIscoupon"></param>
        public void UpdateImagePriority(int Id, int Priority, string Category, int boolIscoupon)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@MobileBannerId", "@priority", "@category", "@IsCoupon" };

                paramValues = new object[] { Id, Priority, Category, boolIscoupon };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.SP_UPDATE_IMAGE_PRIORITY, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="BannerId"></param>
        /// <param name="BannerOrder"></param>
        /// <param name="UserID"></param>
        /// <param name="boolIscoupon"></param>
        public void UpdateImagePriority(int BannerId, int BannerOrder, int UserID, int boolIscoupon)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@BannerId", "@BannerOrder", "@UserId", "@IsCoupon" };

                paramValues = new object[] { BannerId, BannerOrder, UserID, boolIscoupon };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.UPDATE_IMAGE_PRIORITY_TO_MOBILE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="BannerId"></param>
        /// <param name="BannerOrder"></param>
        /// <param name="UserID"></param>
        /// <param name="boolIscoupon"></param>
        public void UpdateImagePriorityToMobile(int BannerId, string BannerOrder, string UserID, int boolIscoupon)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@BannerId", "@BannerOrder", "@UserId", "@IsCoupon" };

                paramValues = new object[] { BannerId, BannerOrder, UserID, boolIscoupon };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.GetDataSet(StoreProcedure.UPDATE_IMAGE_PRIORITY_TO_MOBILE, Enumerations.Command_Type.StoredProcedure, paramList);
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
