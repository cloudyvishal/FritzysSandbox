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

namespace BCL.Custom.BannerOrderMgr
{
    public class BannerOrder : BaseData
    {
        public const string BannerXml = "banners_Cat1.xml";

        public DataSet GetBannerList(int PageId, int UserId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PageId", "@UserId" };

                paramValues = new object[] { PageId, UserId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SP_GET_BANNER_ORDER_LIST, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        public DataSet UpdateBannerSequence(int Id, int BannerId, int IsCoupon)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@Id", "@BannerId", "@IsCoupon" };

                paramValues = new object[] { Id, BannerId, IsCoupon };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.UPDATE_BANNER_SEQUENCE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        public DataSet UpdateBannerSequenceByPage(string PageName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PageName" };

                paramValues = new object[] { PageName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.UPDATE_BANNER_SEQUENCE_BY_PAGE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        public DataSet GetPagesNames()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_PAGES_NAMES, Enumerations.Command_Type.StoredProcedure, paramList);
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
