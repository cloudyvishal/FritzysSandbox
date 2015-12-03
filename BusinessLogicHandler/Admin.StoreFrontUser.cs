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
    public class StoreFrontUser : BaseData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Street"></param>
        /// <param name="City"></param>
        /// <param name="State"></param>
        /// <param name="Zip"></param>
        /// <param name="Phone"></param>
        /// <param name="ReferralID"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public int AddUserBasic(string FirstName, string LastName, string Street, string City, string State, string Zip, string Phone, int ReferralID, string UserName, string Password, int Status)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@FirstName", "@LastName", "@Street", "@City", "@State", "@Zipcode", "@Phone", "@ReferralID", "@UserName", "@Password", "@Status" };

                paramValues = new object[] { FirstName, LastName, Street, City, State, Zip, Phone, ReferralID, UserName, Password, Status };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.ADD_USER_BASIC_INSERT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="Street"></param>
        /// <param name="City"></param>
        /// <param name="State"></param>
        /// <param name="Zip"></param>
        /// <param name="Phone"></param>
        /// <param name="ReferralID"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="AltMobile"></param>
        /// <param name="AltContact"></param>
        /// <param name="AltStreet"></param>
        /// <param name="AltCity"></param>
        /// <param name="AltState"></param>
        /// <param name="AltZip"></param>
        /// <param name="AltPhone"></param>
        /// <param name="PreferredGroomer"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public int AddUserFull(string FirstName, string LastName, string Street, string City, string State, string Zip, string Phone, int ReferralID, string UserName, string Password, string AltMobile, string AltContact, string AltStreet, string AltCity, string AltState, string AltZip, string AltPhone, string PreferredGroomer, int Status)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@FirstName", "@LastName", "@Street", "@City", "@State", "@Zipcode", "@Phone", "@ReferralID", "@UserName", "@Password", "@AltMobile", "@AltContact", "@AltStreet", "@AltCity", "@AltState", "@AltZipcode", "@AltPhone", "@PreferredGroomer", "@Status" };

                paramValues = new object[] { FirstName, LastName, Street, City, State, Zip, Phone, ReferralID, UserName, Password, AltMobile, AltContact, AltStreet, AltState, AltZip, AltPhone, PreferredGroomer, Status };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.ADD_USER_FULL_INSERT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="Street"></param>
        /// <param name="City"></param>
        /// <param name="State"></param>
        /// <param name="Zip"></param>
        /// <param name="Phone"></param>
        /// <param name="ReferralID"></param>
        /// <param name="AltMobile"></param>
        /// <param name="AltContact"></param>
        /// <param name="AltStreet"></param>
        /// <param name="AltCity"></param>
        /// <param name="AltState"></param>
        /// <param name="AltZip"></param>
        /// <param name="AltPhone"></param>
        /// <param name="PreferredGroomer"></param>
        /// <param name="Status"></param>
        /// <param name="Email"></param>
        /// <returns></returns>
        public int UpdateUser(int UserID, string FirstName, string LastName, string Street, string City, string State, string Zip, string Phone, int ReferralID, string AltMobile, string AltContact, string AltStreet, string AltCity, string AltState, string AltZip, string AltPhone, string PreferredGroomer, int Status, string Email)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserID", "@FirstName", "@LastName", "@Street", "@City", "@State", "@Zipcode", "@Phone", "@ReferralID", "@AltMobile", "@AltContact", "@AltStreet", "@AltCity", "@AltState", "@AltZipcode", "@AltPhone", "@PreferredGroomer", "@Status", "@Email" };

                paramValues = new object[] { UserID, FirstName, LastName, Street, City, State, Zip, Phone, ReferralID, AltMobile, AltContact, AltStreet,AltCity, AltState, AltZip, AltPhone, PreferredGroomer, Status, Email };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.UPDATE_USER, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="Pettype"></param>
        /// <param name="PetName"></param>
        /// <param name="BreedID"></param>
        /// <param name="Years"></param>
        /// <param name="Weight"></param>
        /// <param name="Length"></param>
        /// <param name="Spa"></param>
        /// <param name="StyleID"></param>
        /// <param name="OtherServices"></param>
        /// <returns></returns>
        public string AddPetFull(int UserID, int Pettype, string PetName, int BreedID, int Years, decimal Weight, decimal Length, int Spa, int StyleID, string OtherServices)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                string TempName = string.Empty;
                if (Pettype == 0) TempName = "Cat";
                else TempName = "dog";
                string str = "Pet = " + TempName + "<br>Pet Name = " + PetName + "<br> Breed Name = BreedID " +
                              "<br>Years = " + Years + "<br>Weight = " + Weight + "<br> Fur Length = " + Length + "<br>" +
                              "Spa = IsSpa <br> Style = StyleID <br> Additional Services = AdditionalService" +
                              "<br><br>";

                paramNames = new string[] { "@UserID", "@Pettype", "@PetName", "@BreedID", "@Year", "@Weight", "@Length", "@Spa", "@StyleID", "@OtherServiceID" };

                paramValues = new object[] { UserID, Pettype, PetName, BreedID, Years, Weight, Length, Spa, StyleID, OtherServices };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.InsertData(StoreProcedure.ADD_PET_FULL, Enumerations.Command_Type.StoredProcedure, paramList);

                return str;
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
        /// <param name="Pettype"></param>
        /// <param name="PetName"></param>
        /// <param name="BreedID"></param>
        /// <param name="Years"></param>
        /// <param name="Weight"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public string AddPet(int UserID, int Pettype, string PetName, int BreedID, int Years, decimal Weight, decimal Length)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                string TempName = string.Empty;

                if (Pettype == 0) TempName = "Cat";

                else TempName = "dog";

                string str = "Pet = " + TempName + "<br>Pet Name = " + PetName + "<br> Breed Name = BreedID " +
                              "<br>Years = " + Years + "<br>Weight = " + Weight + "<br> Fur Length = " + Length + "<br><br><br>";

                paramNames = new string[] { "@UserID", "@Pettype", "@PetName", "@BreedID", "@Year", "@Weight", "@Length" };

                paramValues = new object[] { UserID, Pettype, PetName, BreedID, Years, Weight, Length };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.InsertData(StoreProcedure.ADD_PET_INSERT, Enumerations.Command_Type.StoredProcedure, paramList);

                return str;
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
        /// <returns></returns>
        public DataSet GetBreedFront(string PetType)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PetTypeID" };

                paramValues = new object[] { PetType };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_BREED_FRONT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetBreedFrontAll()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_BREED_FRONT_ALL, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetReferalSourceFront()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_REFERAL_SOURCE_FRONT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetUser(int UserID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserID" };

                paramValues = new object[] { UserID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_USER_FRONT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetAllPetFront(int UserID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserID" };

                paramValues = new object[] { UserID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_PET_FRONT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet DeleteAllPet(int UserID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserID" };

                paramValues = new object[] { UserID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.DELETE_ALL_PET, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet IsFullProfile(int UserID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserID" };

                paramValues = new object[] { UserID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.IS_FULL_PROFILE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetStyleFront()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_STYLE_FRONT, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public DataSet GetAllFlexible()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_ALL_FLEXIBLE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="UserID"></param>
        /// <param name="Pettype"></param>
        /// <param name="PetName"></param>
        /// <param name="BreedID"></param>
        /// <param name="Years"></param>
        /// <param name="Weight"></param>
        /// <param name="Length"></param>
        public void UpdatePet(int PetID, int UserID, int Pettype, string PetName, int BreedID, int Years, decimal Weight, decimal Length)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PetID", "@UserID", "@Pettype", "@PetName", "@BreedID", "@Year", "@Weight", "@Length" };

                paramValues = new object[] { PetID, UserID, Pettype, PetName, BreedID, Years, Weight, Length };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.UPDATE_PET, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="UserID"></param>
        /// <param name="Pettype"></param>
        /// <param name="PetName"></param>
        /// <param name="BreedID"></param>
        /// <param name="Years"></param>
        /// <param name="Weight"></param>
        /// <param name="Length"></param>
        /// <param name="Spa"></param>
        /// <param name="StyleID"></param>
        /// <param name="OtherServices"></param>
        public void UpdatePetFull(int PetID, int UserID, int Pettype, string PetName, int BreedID, int Years, decimal Weight, decimal Length, int Spa, int StyleID, string OtherServices)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PetID", "@UserID", "@Pettype", "@PetName", "@BreedID", "@Year", "@Weight", "@Length", "@Spa", "@StyleID", "@OtherServiceID" };

                paramValues = new object[] { PetID, UserID, Pettype, PetName, BreedID, Years, Weight, Length, Spa, StyleID, OtherServices };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.UPDATE_PET_FULL, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="Status"></param>
        public void UpdateUserType(int UserID, int Status)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserID", "@Status" };

                paramValues = new object[] { UserID, Status };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.UPDATE_USER_TYPE, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="Status"></param>
        public void DeletePet(int PetID, int Status)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PetID", "@Status" };

                paramValues = new object[] { PetID, Status };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.DELETE_PET, Enumerations.Command_Type.StoredProcedure, paramList);
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
        public void DeletePet(int PetID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@PetID" };

                paramValues = new object[] { PetID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.DELETE_PET, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="Street"></param>
        /// <param name="City"></param>
        /// <param name="State"></param>
        /// <param name="Zip"></param>
        /// <param name="Phone"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="AltMobile"></param>
        /// <param name="AltContact"></param>
        /// <param name="AltStreet"></param>
        /// <param name="AltCity"></param>
        /// <param name="AltState"></param>
        /// <param name="AltZip"></param>
        /// <param name="AltPhone"></param>
        /// <param name="PreferredGroomer"></param>
        /// <param name="UserType"></param>
        /// <returns></returns>
        public int AddUserExcel(string FirstName, string LastName, string Street, string City, string State, string Zip, string Phone,
        string UserName, string Password, string AltMobile, string AltContact, string AltStreet, string AltCity, string AltState,
        string AltZip, string AltPhone, string PreferredGroomer, int UserType)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@LastName", "@Street", "@City", "@State", "@Zipcode", "@Phone", "@UserName", "@Password", "@AltMobile", "@AltContact", "@AltStreet", "@AltCity", "@AltState", "@AltZipcode", "@AltPhone", "@PreferredGroomer", "@UserType" };

                paramValues = new object[] { LastName, Street, City, State, Zip, Phone, UserName, Password, AltMobile, AltContact, AltStreet, AltCity, AltState, AltZip, AltPhone, PreferredGroomer, UserType, };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.ADD_USER_EXCEL, Enumerations.Command_Type.StoredProcedure, paramList);
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
        /// <param name="Street"></param>
        /// <param name="City"></param>
        /// <param name="State"></param>
        /// <param name="Zip"></param>
        /// <param name="Phone"></param>
        /// <param name="AltMobile"></param>
        /// <param name="AltContact"></param>
        /// <param name="AltStreet"></param>
        /// <param name="AltCity"></param>
        /// <param name="AltState"></param>
        /// <param name="AltZip"></param>
        /// <param name="AltPhone"></param>
        /// <param name="ReferalSource"></param>
        /// <param name="PreferredGroomer"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int UpdateMember(int UserID, string FirstName, string LastName, string Street, string City, string State, string Zip,
        string Phone, string AltMobile, string AltContact, string AltStreet, string AltCity, string AltState, string AltZip,
        string AltPhone, int ReferalSource, string PreferredGroomer, string UserName, string Password)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserID", "@FirstName", "@LastName", "@Street", "@City", "@State", "@Zipcode", "@Phone", "@AltMobile", "@AltContact", "@AltStreet", "@AltCity", "@AltState", "@AltZipcode", "@AltPhone", "@ReferalSource", "@PreferredGroomer", "@UserName", "@Password" };

                paramValues = new object[] { UserID, FirstName, LastName, Street, City, State, Zip, Phone, AltMobile, AltContact, AltStreet, AltCity, AltState, AltZip, AltPhone, ReferalSource, PreferredGroomer, UserName, Password };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.UPDATE_MEMBER, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        public DataSet BindLoginUserDetails(int UserId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserId" };

                paramValues = new object[] { UserId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.REGISTER_LOGIN_USER_INFO_GET_BY_ID, Enumerations.Command_Type.StoredProcedure, paramList);
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
