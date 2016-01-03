using System;
using System.Text;

namespace BCL.Common.StoreProcedure
{
    public class StoreProcedure
    {

        #region Misc Store Procedure

        public const string GET_LOGIN_USER = "GetLoginUser";

        public const string FORGOT_PASSWORD_FRONT = "ForgotPasswordFront";

        public const string ADD_SUGGESTION_INSERT = "AddSuggestion";

        public const string FORGOT_PASSWORD = "ForgotPassword";

        public const string GET_EMAIL_SUBJECT = "GetEmailSubject";

        public const string CHANGE_USER_NAME = "ChangeUserName";

        public const string DELETE_SUGGESTION = "DeleteSuggestion";

        public const string GET_ALL_SUGGESTION = "GetAllSuggestion";

        public const string SUGGESTION_GET_BY_ID = "GetSuggestion";

        public const string GET_ALL_SUGGESTION_EXPORT = "GetAllSuggestionExport";

        public const string GET_TOP_SUGGESTION = "GetTopSuggestion";

        public const string GET_ALL_NEWS = "GetAllNews";

        public const string GET_NEWS_ON_STORE_FRONT = "GetNewsOnStoreFront";

        public const string ADD_NEWS = "AddNews";

        public const string UPDATE_NEWS = "UpdateNews";

        public const string DELETE_NEWS = "DeleteNews";

        public const string UPDATE_NEWS_STATUS = "UpdateNewsStatus";

        public const string GET_NEWS = "GetNews";

        public const string NEWS_DOWN = "NewsDown";

        public const string NEWS_UP = "NewsUp";

        public const string GET_ALL_FRIEND = "GetAllFriend";

        public const string ADD_FRIEND_INSERT = "AddFriend";

        public const string UPDATE_FRIENDS = "UpdateFriends";

        public const string DELETE_FRIEND = "DeleteFriend";

        public const string UPDATE_FRIEND_STATUS = "UpdateFriendStatus";

        public const string GET_FRIEND = "GetFriend";

        public const string FRIEND_DOWN = "FriendDown";

        public const string FRIEND_UP = "FriendUp";

        public const string FRIEND_POSITION = "FriendPosition";

        public const string GET_ALL_FRIEND_FRONT = "GetAllFriendFront";

        public const string GET_ZIP_CODE_FRONT = "GetZipCodeFront";

        public const string GET_SERVICE_LOCATIONS = "GetServiceLocations";

        public const string GET_SERVICE_LOCATIONS_EXPORT = "GetServiceLocationsExport";

        public const string CHANGE_SERVICE_LOCATION_STATUS = "ChangeServiceLocationStatus";

        public const string CHANGE_SERVICE_LOCATION_AVAILABLE = "ChangeServiceLocationAvailable";

        public const string DELETE_SERVICE_LOCATION = "DeleteServiceLocation";

        public const string ADD_ZIP_CODE_INSERT = "AddZipCode";

        public const string GET_CONTACT_INFO = "GetContactInfo";

        public const string GET_ALL_USER_FRONT = "GetAllUserFront";

        public const string DELETE_USERS = "DeleteUsers";

        public const string GET_USER_INFO = "GetUserInfo";

        public const string GET_ALL_USER_FRONT_EXPORT = "GetAllUserFrontExport";

        public const string GET_PET_SERVICES = "GetPetServices";

        public const string GET_TOP_USER_FRONT = "GetTopUserFront";

        public const string GET_TOP_CONTACT_US = "GetTopContactUS";

        public const string GET_TOP_APPOINTMENT = "GetTopAppointment";

        public const string DELETE_USER_PET = "DeleteUserPet";

        public const string GET_ALL_STATE = "GetAllState";

        public const string ADD_ADMIN_USER_ACCESS = "AddAdminUserAccess";

        public const string GET_ALL_USER_TYPE = "GetAllUserType";

        public const string DELETE_USER_ACCESS = "DeleteUserAccess";

        public const string GET_CURRENT_PAGE = "GetCurrentPage";

        public const string CHANGE_USER_ACCESS = "ChangeUserAccess";

        public const string GET_PAGES = "GetPages";

        public const string GET_META = "GetMeta";

        public const string GET_PAGE_LIST = "GetPageList";

        public const string DELETE_META_TAG = "DeleteMetaTag";

        public const string GET_META_DETAIL = "GetMetaDetail";

        public const string UPDATE_META = "UpdateMeta";

        public const string GET_META_FRONT = "GetMetaFront";

        public const string UPDATE_TITLE = "UpdateTitle";

        public const string GET_ADDITIONAL_SERVICES_ADMIN = "GetAdditionalServicesAdmin";

        public const string GET_ALL_MAIL = "GetAllMail";

        public const string UPDATE_SUBJECT = "UpdateSubject";

        public const string GET_PET_INFO = "getPetInfo";

        public const string UPDATE_PET_ADMIN = "UpdatePetAdmin";

        public const string DELETE_ALL_BANNER_NOW = "DeleteAllBannerNow";

        public const string DELETE_ALL_ROW = "DeleteAllRow";

        public const string SP_BACKUP = "sp_BackUp";

        public const string ADD_APPOINTMENT_SLOTS = "AddAppointmentslots";

        public const string GET_APPOINTMENT_SLOTS = "GetAppointmentslots";

        public const string GET_APPOINTMENT_SLOTS_BY_TIME = "GetAppointmentslotsByTime";

        public const string GET_APPOINTMENT_SLOTS_TO_EDIT = "GetAppointmentslotsToEdit";

        public const string GET_APPOINTMENTSET_DATE = "GetAppointmentsetDate";

        public const string GET_APPOINTMENT_TIME = "GetAppointmentTime";

        public const string DELETE_APPOINTMENT_SLOTS = "DeleteAppointmentslots";

        public const string GET_APPOINTMENT_SLOTS_BY_DATE = "GetAppointmentslotsByDate";

        public const string ADD_APPOINTMENT_DATE = "AddAppointmentDate";

        public const string GET_APPOINTMENT_DATE = "GetAppointmentDate";

        public const string UPDATE_APPOINTMENTDATE_STATUS = "UpdateAppointmentdateStatus";

        public const string DELETE_APPOINTMENTS_DATE = "DeleteAppointmentsDate";

        public const string SP_GET_BANNER_ORDER_LIST = "sp_GetBannerOrderList";

        #endregion

        ///BannerMngmt

        #region Banner SPs

        public const string GET_USER_TYPE_ID = "GetUserTypeID";

        public const string GET_DEFAULT_COUPON_NAME = "GetDefaultCouponName";

        public const string UPDATE_DEFAULT_BANNER_COUPON_NAME = "UpdateDefaultBannerCouponName";

        public const string ADD_BANNER = "AddBanner";

        public const string GET_MAX_BANNER_ID = "GetMaxBannerId";

        public const string GET_MAX_MOBILE_BANNER_ID = "GetMaxMobileBannerId";

        public const string INSERT_IN_BANNER_LIST = "InsertInBannerList";

        public const string GET_BANNER_LIST = "GetBannerList";

        public const string INSERT_IN_SET_BANNER = "InsertInSetBanner";

        public const string GET_FREQUENCY_FROM_SET_BANNER = "GetFrequencyFromSetBanner";

        public const string GET_USER_TYPE_LIST = "GetUserTypeList";

        public const string GET_PAGE_TITLE_LIST = "GetPageTitleList";

        public const string DELETE_PREVIOUS_SET_BANNER = "DeletePreviousSetBanner";

        public const string SP_INSERT_IMAGE = "spInsertImage";

        public const string SP_SELECT_Images = "spSelectImages";

        public const string SP_DELETE_IMAGE = "SpDeleteImage";

        public const string PROC_XML_Images = "proc_XMLImages";

        public const string SP_SELECT_Images_CATEGORY = "spSelectImagescategory";

        public const string GET_BANNER_ID_FREQUENCY_FROM_SET_BANNER = "GetBannerIdFrequencyFromSetBanner";

        public const string GET_BANNER_IMAGE_NAME_AND_PATH = "GetBannerImageNameandpath";

        public const string GET_PAGES_NAME_FROM_SET_BANNERS = "GetPagesNameFromSetBanners";

        public const string GET_PAGE_AND_USER_TYPES = "GetPageanduserTypes";

        public const string CHECK_IS_COUPON = "CheckIsCoupon";

        public const string GET_DEFAULT_BANNER = "GetDefaultBanner";

        public const string INSERT_IN_DEFAULT_BANNER = "InsertInDefaultBanner";

        public const string DELETE_DEFAULT_BANNER = "DeleteDefaultBanner";

        public const string GET_PAGE_ID_AND_USER_ID = "GetPageIdandUserId";

        public const string CHECK_USED_DEFAULT_BANNER = "CheckUsedDefaultBanner";

        public const string CHECK_USED_BANNER_LIST = "CheckUsedBannerList";

        public const string DELETE_UNUSED_BANNER = "DeleteUnusedBanner";

        public const string DELETE_MOBILE_BANNER = "DeleteMobileBanner";

        public const string INSERT_IN_DEFAULT_COPON = "InsertInDefaultCopon";

        public const string DELETE_DEFAULT_COPON = "DeleteDefaultCopon";

        public const string GET_DEFAULT_COPON = "GetDefaultCopon";

        public const string GET_DEFAULT_COPON_FOR_BAN_ID = "GetDefaultCoponForBanId";

        public const string GET_ORDER_OF_BANNER_ID = "GetOrderOfBannerId";

        public const string GET_ONE_DEFAULT_BANNER = "GetoneDefaultBanner";

        public const string GET_ONE_DEFAULT_COUPON = "GetoneDefaultCoupon";

        public const string GET_PAGE_NAME_FROM_SET_BANNER = "GetPagenamefromSetBanner";

        public const string GET_NOT_PAGE_AND_USER_TYPES = "GetNotPageanduserTypes";

        public const string NEW_BANNER_UPDATE = "newbannerupdate";

        public const string CHECK_USED_MOBILE_BANNER_LIST = "CheckUsedMobileBannerList";

        public const string DELETE_UNUSED_MOBILE_BANNER = "DeleteUnusedMobileBanner";

        public const string CHECK_USED_MOBILE_DEFAULT_BANNER = "CheckUsedMobileDefaultBanner";

        public const string PROC_XML_Images_MOBILE = "proc_XMLImagesMobile";

        public const string SP_UPDATE_IMAGE_PRIORITY = "sp_updateimagepriority";

        public const string UPDATE_IMAGE_PRIORITY_TO_MOBILE = "UpdateImagePriorityToMobile";

        #endregion

        ///Groomer Management Store Procedures (Admin.Groomer.cs)
        #region Groomer SPs

        public const string Groomers_Get_All = "GetAllGroomers";

        public const string DELETE_GROOMER = "DeleteGroomer";

        public const string ADD_GROOMER_INSERT = "AddGroomer";

        public const string GROOMER_GET_BY_ID = "GetGroomer";

        public const string GET_GROOMER_ID_BY_NAME = "GetGroomerIDbyname";

        public const string FUTURE_APPOINTMENTS_DELETE = "DeleteFutureAppointments";

        public const string IS_APPT_EXISTS = "IsApptExists";

        public const string INSERT_GROOMER_APPOINTMENT = "InsertGroomerAppointment";

        public const string GET_GROOMER_DATEWISE_APPTS = "GetgroomerdatewiseAppts";

        public const string GROOMER_DETAILS_UPDATE = "UpdateGroomer";

        public const string GET_GROOMERS_APPOINTMENT = "GetGroomersAppointment";

        public const string ADD_GROOMER_APPOINTMENT = "AddGroomerAppointment";

        public const string GET_GROOMER_DAILY_LOG_DATA = "GetGroomerDailyLogData";

        public const string UPDATE_GROOMER_DAILY_OPERATIONS_LOG = "UpdateGroomerDailyOperationsLog";

        public const string GET_GROOMER_MONTHLY_LOG_DATA = "GetGroomerMonthlyLogData";

        public const string Bind_Groomers = "BindGroomers";

        public const string GET_GROOMERS_DATE_APPOINTMENT = "GetGroomersdateappointment";

        public const string UPDATE_GROOMER_APPOINTMENT = "UpdateGroomerAppointment";

        public const string GET_GROOMERS_SEQUENCE = "GetGroomersSequence";

        public const string DELETE_GROOMER_APPOINTMENT = "DeleteGroomerAppointment";

        public const string ASSIGN_GROOMER_APPOINTMENT = "AssignGroomerAppointment";

        public const string GET_GROOMERS_SEQUENCE_FOR_UPDATE = "GetGroomersSequenceforUpdate";

        public const string UPDATE_GROOMER_SEQUENCE = "UpdateGroomerSequence";

        public const string GET_PREVIOUS_GROOMERS_SEQUENCE_FOR_UPDATE = "GetPreviousGroomersSequenceforUpdate";

        public const string GET_PREVIOUS_GROOMERS_SEQUENCE_FOR_UPDATE_ONE = "GetPreviousGroomersSequenceforUpdate1";

        public const string GET_MAX_SEQUENCENO_OF_GROOMER = "GetMaxSequencenoOfGroomer";

        public const string GET_GROOMER_NEXT_SEQUENCE_FOR_UPDATE = "GetGroomerNextsequenceForupdate";

        public const string CHANGE_GROOMER_APPOINTMENT_STATUS = "ChangeGroomerAppointmentStatus";

        public const string SP_MANAGE_EXCEL = "sp_ManageExcel";

        public const string SP_GET_EXCEL_DATA = "sp_getExcelData";

        public const string SP_GET_DAILY_OPERATRION_LOG = "sp_getDailyOperatrionLog";

        public const string SP_UPDATE_EXPORT_TO_EXCEL_FLAG = "sp_UpdateExportToExcelFlag";

        public const string SP_GROOMER_OPERATION_TO_EXPORT = "sp_GroomerOperationToExport";

        public const string GET_GROOMER_APPOINTMENT_DETAILS = "GetGroomerAppointmentDetails";

        public const string DELETE_OLD_GROOMER_APPOINTMENT = "DeleteOldGroomerAppointment";

        public const string UPDATE_EXCEL_FILE_STATUS = "UpdateExcelFileStatus";

        public const string GET_EXCEL_FILE_NAME = "GetExcelFileName";

        public const string GET_UNLOCK_EXCEL_FILE_NAME = "GetUnlockExcelFileName";

        public const string ADD_EXCEL_FILE = "AddExcelFile";

        public const string DELETE_EXCEL_FILE = "DeleteExcelFile";

        public const string UPDATE_EXCEL_FILE_STATUS_UNLOCK = "UpdateExcelFileStatusUnlock";

        public const string UPDATE_EXCEL_EXPORTED = "updateExcelExported";

        public const string UPDATE_EXCEL_EXPORTED_ENDING_MILEAGE = "updateExcelExportedEndingMileage";

        public const string GET_UU_EXPORTED_GROOMER_LOG_DATA = "GetUuExportedgroomerlogdata";

        public const string GET_UN_EXPORTED_GROOMER_INVENTORY_DATA = "GetUnExportedgroomerInventorydata";

        public const string GET_UU_EXPORTED_GROOMER_LOG_DATA_ENDING_M = "GetUuExportedgroomerlogdataEndingM";

        public const string UPDATE_EXCEL_EXPORTED_INVENTORY = "updateExcelExportedInventory";

        public const string INSERT_SP_SHEET_PWD_LOG = "InsertSPSheetPWDLog";

        public const string GET_SPREAD_SHEET_PASSWORD_LOG = "GetSpreadSheetPasswordLog";

        #endregion

        //Home Services Store Procedures

        #region Home Service SPs

        public const string GET_ALL_HOME_SERVICE_ADMIN = "GetAllHomeServiceAdmin";

        public const string UPDATE_HOME_SERVICE = "UpdateHomeService";

        public const string GET_HOME_SERVICE_DETAIL = "GetHomeServiceDetail";

        public const string GET_ALL_FLEA_AND_TICK_SERVICE_ADMIN = "GetAllFlea&TickServiceAdmin";

        public const string UPDATE_FLEA_AND_TICK_SERVICES = "UpdateFleaandTickServices";

        public const string GET_FLEA_TICK_SERVICE_DETAIL_BY_SERVICE_ID = "GetFleatickServiceDetail";

        #endregion

        //Service Page Store Procedures

        #region Service Page SPs

        public const string GET_SERVICE_PAGE_ADMIN = "GetServicePageAdmin";

        public const string UPDATE_SERVICE_PAGE_SERVICES = "UpdateServicePageServices";

        public const string GET_SERVICE_PAGE_SERVICE_DETAIL = "GetServicePageServiceDetail";

        #endregion

        //User Management Store Procedures

        #region User Mngmt SPs

        public const string GET_USER_LOGIN = "GetUserLogin";

        public const string GET_ALL_USER = "GetAllUser";

        public const string CHANGE_USER_STATUS = "ChangeUserStatus";

        public const string DELETE_USER = "DeleteUser";

        public const string ADD_ADMIN_USER_INSERT = "AddAdminUser";

        public const string GET_USER_DETAIL = "GetUserDetail";

        public const string UPDATE_ADMIN_USER = "UpdateAdminUser";

        #endregion

        //Services Store Procedures

        #region Services SPs

        public const string IS_SERVICE_EXIST = "IsServiceExist";

        public const string DELETE_SERVICE = "DeleteService";

        public const string GET_ALL_SERVICES = "GetAllServices";

        public const string GET_SERVICE_DETAIL = "GetServiceDetail";

        public const string ADD_SERVICE_INSERT = "AddService";

        public const string UPDATE_STATUS = "UpdateStatus";

        public const string SET_IS_FLEA = "SetIsFlea";

        public const string SET_IS_HOME = "SetIsHome";

        public const string UPDATE_SERVICE = "UpdateService";

        public const string UPDATE_IS_HOME = "UpdateIsHome";

        public const string GET_ALL_HOME_SERVICES = "GetAllHomeServices";

        public const string GET_FLEA_SERVICES = "GetFleaServices";

        public const string SET_SERVICE = "SetService";

        public const string SET_SERVICE_FLEA = "SetServiceFlea";

        public const string UPDATE_IS_FLEA = "UpdateIsFlea";

        public const string UPDATE_ORDER = "UpdateOrder";

        public const string SET_POSITION_DOWN = "SetPositionDown";

        public const string SET_POSITION_UP = "SetPositionUp";

        public const string SET_POSITION = "SetPosition";

        #endregion

        //StoreFront Store Procedure

        #region StoreFront SPs

        public const string GET_LOGIN_USER_STORE_FRONT = "GetLoginUser";

        public const string GET_HOME_PAGE_SERVICES = "GetHomePageServices";

        public const string GET_SERVICE_PAGE_SERVICES = "GetServicePageServices";

        public const string GET_ALL_SERVICE_PAGE_SERVICES = "GetAllServicePageServices";

        public const string GET_FLEA_PAGE_SERVICES = "GetFleaPageServices";

        public const string ADD_CONTACT_US = "AddContactus";

        public const string GET_ALL_CONTACT_US = "GetAllContactus";

        public const string DELETE_CONTACT_US = "DeleteContactUs";

        public const string GET_ALL_CONTACT_US_EXPORT = "GetAllContactUsExport";

        public const string GET_ALL_DOG_SERVICE = "GetAllDogService";

        public const string GET_ALL_CAT_SERVICE = "GetAllCatService";

        public const string GET_ALL_CAT_DOG_SERVICE = "GetAllCatDogService";

        public const string GET_SERVICE_DETAIL_FRONT = "GetServiceDetailFront";

        public const string GET_BANER_PAGES = "GetBanerPages";

        public const string GET_BANER_IMAGE = "GetBanerImage";

        public const string UPDATE_BANER_IMAGE = "UpdateBanerImage";

        public const string CHECK_PET = "CheckPET";

        public const string DELETE_BANNER = "DeleteBanner";

        public const string ADD_BANNER_INSERT = "AddBanner";

        public const string GET_BANER_ID = "GetBanerID";

        public const string GET_ADDITIONAL_SERVICES = "GetAdditionalServices";

        public const string GET_ADDITIONAL_SERVICES_EXPORT = "GetAdditionalServicesExport";

        public const string DELETE_ADDITIONAL_SERVICES = "DeleteAdditionalServices";

        public const string UPDATE_ADDITIONAL_SERVICE_STATUS = "UpdateAdditionalServiceStatus";

        public const string UPDATE_ADDITIONAL_SERVICES = "UpdateAdditionalServices";

        public const string ADD_ADDITIONAL_SERVICES = "AddAdditionalServices";

        public const string ADD_ADDITIONAL_SERVICES_EXCEL = "AddAdditionalServicesExcel";

        public const string GET_BREED = "GetBreed";

        public const string GET_BREED_EXPORT = "GetBreedExport";

        public const string DELETE_BREED = "DeleteBreed";

        public const string UPDATE_BREED_STATUS = "UpdateBreedStatus";

        public const string UPDATE_BREED = "UpdateBreed";

        public const string ADD_BREED_INSERT = "AddBreed";

        public const string ADD_BREED_EXCEL_INSERT = "AddBreedExcel";

        public const string GET_STYLE = "GetStyle";

        public const string GET_STYLE_EXPORT = "GetStyleExport";

        public const string DELETE_STYLE = "DeleteStyle";

        public const string UPDATE_STYLE_STATUS = "UpdateStyleStatus";

        public const string UPDATE_STYLE = "UpdateStyle";

        public const string ADD_STYLE_INSERT = "AddStyle";

        public const string ADD_STYLE_EXCEL_INSERT = "AddStyleExcel";

        public const string ADD_REFERAL_SOURCE_INSERT = "AddReferalSource";

        public const string UPDATE_REFERAL_SOURCE = "UpdateReferalSource";

        public const string UPDATE_REFERAL_SOURCE_STATUS = "UpdateReferalSourceStatus";

        public const string DELETE_REFERAL_SOURCE = "DeleteReferalSource";

        public const string GET_REFERAL_SOURCE = "GetReferalSource";

        public const string GET_NEWS_FRONT = "GetNewsFront";

        public const string SP_GET_SERVICES_BY_SEARCH = "sp_GetServicesBySearch";

        public const string SP_GET_PRODUCT_BY_SEARCH = "sp_GetProductBySearch";

        public const string SP_GET_FRIEND_SEARCH = "sp_GetFriendSearch";

        public const string GET_FLEA_AND_TICK_SERVICES = "GetFleaandTickServices";

        #endregion

        public const string ADD_USER_BASIC_INSERT = "AddUser_Basic";

        public const string ADD_USER_FULL_INSERT = "AddUser_Full";

        public const string UPDATE_USER = "UpdateUser";

        public const string GET_BREED_FRONT = "GetBreedFront";

        public const string GET_BREED_FRONT_ALL = "GetBreedFrontAll";

        public const string GET_REFERAL_SOURCE_FRONT = "GetReferalSourceFront";

        public const string GET_USER_FRONT = "GetUserFront";

        public const string GET_ALL_PET_FRONT = "GetAllPetFront";

        public const string DELETE_ALL_PET = "DeleteAllPet";

        public const string IS_FULL_PROFILE = "IsFullProfile";

        public const string GET_STYLE_FRONT = "GetStyleFront";

        public const string GET_ALL_FLEXIBLE = "GetAllFlexible";

        public const string UPDATE_PET = "UpdatePet";

        public const string UPDATE_PET_FULL = "UpdatePetFull";

        public const string UPDATE_USER_TYPE = "UpdateUserType";

        public const string DELETE_PET = "DeletePet";

        public const string ADD_USER_EXCEL = "AddUserExcel";

        public const string UPDATE_MEMBER = "UpdateMember";

        public const string GET_ALL_PRODUCTS = "GetAllProducts";

        public const string DELETE_PRODUCTS = "DeleteProducts";

        public const string ADD_PRODUCTS_INSERT = "AddProducts";

        public const string UPDATE_PRODUCT_STATUS = "UpdateProductStatus";

        public const string GET_PRODUCT_DETAIL_BY_ID = "GetProductDetail";

        public const string UPDATE_PRODUCT = "UpdateProduct";

        public const string UPDATE_HOME_PRODUCT = "UpdateHomeProduct";

        public const string UPDATE_FLEA_PRODUCT = "UpdateFleaProduct";

        public const string GET_ALL_PRODUCTS_FRONT = "GetAllProductsFront";

        public const string GET_ALL_PRODUCTS_HOME_FRONT = "GetAllProductsHomeFront";

        public const string GET_ALL_PRODUCTS_FLEA_FRONT = "GetAllProductsFleaFront";

        public const string PRODUCT_DOWN = "ProductDown";

        public const string PRODUCT_UP = "ProductUp";

        public const string PRODUCT_POSITION = "ProductPosition";

        public const string ADD_PET_INSERT = "AddPet";

        public const string DELETE_APPOINTMENT = "DeleteAppointment";

        public const string GET_APPOINTMENT = "GetAppointment";

        public const string GET_ALL_APPOINTMENT_EXPORT = "GetAllAppointmentExport";

        public const string GET_ALL_APPOINTMENT = "GetAllAppointment";

        public const string UPDATE_BANNER_SEQUENCE = "UpdateBannerSequence";

        public const string UPDATE_BANNER_SEQUENCE_BY_PAGE = "UpdateBannerSequenceByPage";

        public const string GET_PAGES_NAMES = "GetPagesNames";

        public const string GET_ALL_MANAGER = "GetAllManager";

        public const string GET_ALL_AGENTS = "GetAllAgents";

        public const string GET_APPT_INFO_FOR_PAYMENT = "GetApptInfoforPayment";

        public const string SP_CHECK_ORDER_REF = "sp_CheckOrderRef";

        public const string GET_SHOPPER_INFO = "GetShopperInfo";

        public const string UPDATE_STATUS_IN_SYNC_APP = "UpdateStatusInSyncApp";

        public const string UPDATE_SHOPPER_RESPONSE = "UpdateShopperResponse";

        public const string INSERT_APPOINTMENT_PRE_PAYMENT = "InsertAppointmentPrePayment";

        public const string GET_ALL_USER_FUTURE_APP_ID = "GetAllUserFutureAppID";

        public const string GET_ALL_PREPAY_APP_ID = "GetAllPrepayAppID";

        public const string GET_ALL_USER_FUTURE_APP = "GetAllUserFutureApp";

        public const string GET_PAST_APPOINTMENTS = "GetPastAppointments";

        public const string DELETE_CUSTOMER_FUTURE_APPOINTMENT = "DeleteCustomerFutureAppointment";

        public const string GET_CUSTAPPOINTMENT_BY_ID = "GetCustAppointmentbyId";

        public const string GET_PREPAYMENT_DATA_LOG = "GetPrePaymentDataLog";

        public const string UPDATE_PREPAYMENT_EXCEL_EXPORTED = "UpdatePrepaymentExcelExported";

        public const string ADD_PET_FULL = "AddPetFull";

        public const string ADD_APPOINTMENT = "AddAppointment";

        public const string REGISTER_LOGIN_USER_INFO_GET_BY_ID = "sp_RegisterLoginUserInfo_GetById";

        public const string NEWS_POSITION = "NewsPosition";

        public const string INVENTORY_LIQUIDS_GET_ALL = "InventoryLiquids_GetAll";

        public const string GROOMER_CUSTOMER_EMAIL_EXISTS = "Groomer_CustomerEmail_Exits";

        public const string INSERT_GROOMER_FAILED_APPOINTMENT = "Groomer_Failed_Appointment_Insert";

        public const string GROOMERS_GET_ALL_FAILED_APPOINTMENTS = "Groomers_Failed_Appointments_Get_All";

        public const string UPDATE_LABELS = "sp_Update_Labels";

        public const string RESET_GROOMER_APPOINTMENT_STATUS = "ResetGroomerAppointmentStatus";
    }
}
