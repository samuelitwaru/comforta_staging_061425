using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class api_residentservice : GXProcedure
   {
      public api_residentservice( )
      {
         context = new GxContext(  );
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         IsApiObject = true;
         initialize();
      }

      public api_residentservice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         IsApiObject = true;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         initialize();
         if ( context.HttpContext != null )
         {
            Gx_restmethod = (string)(context.HttpContext.Request.Method);
         }
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         cleanup();
      }

      public void InitLocation( )
      {
         restLocation = new GxLocation();
         restLocation.Host = "localhost";
         restLocation.Port = 8082;
         restLocation.BaseUrl = "Comforta_version2DevelopmentNETPostgreSQL/api";
         gxProperties = new GxObjectProperties();
      }

      public GxObjectProperties ObjProperties
      {
         get {
            return gxProperties ;
         }

         set {
            gxProperties = value ;
         }

      }

      public void SetObjectProperties( GxObjectProperties gxobjppt )
      {
         gxProperties = gxobjppt ;
         restLocation = gxobjppt.Location ;
      }

      public void gxep_loginwithqrcode( string aP0_secretKey ,
                                        out SdtSDT_LoginResidentResponse aP1_loginResult )
      {
         restCliLoginWithQrCode = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/auth/resident-login";
         restCliLoginWithQrCode.Location = restLocation;
         restCliLoginWithQrCode.HttpMethod = "POST";
         restCliLoginWithQrCode.AddBodyVar("secretKey", (string)(aP0_secretKey));
         restCliLoginWithQrCode.RestExecute();
         if ( restCliLoginWithQrCode.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliLoginWithQrCode.ErrorCode;
            gxProperties.ErrorMessage = restCliLoginWithQrCode.ErrorMessage;
            gxProperties.StatusCode = restCliLoginWithQrCode.StatusCode;
            aP1_loginResult = new SdtSDT_LoginResidentResponse();
         }
         else
         {
            aP1_loginResult = restCliLoginWithQrCode.GetBodySdt<SdtSDT_LoginResidentResponse>("loginResult");
         }
         /* LoginWithQrCode Constructor */
      }

      public void gxep_loginwithusernamepassword( string aP0_username ,
                                                  string aP1_password ,
                                                  out SdtSDT_LoginResidentResponse aP2_loginResult )
      {
         restCliLoginWithUsernamePassword = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/auth/resident-login-username-password";
         restCliLoginWithUsernamePassword.Location = restLocation;
         restCliLoginWithUsernamePassword.HttpMethod = "POST";
         restCliLoginWithUsernamePassword.AddBodyVar("username", (string)(aP0_username));
         restCliLoginWithUsernamePassword.AddBodyVar("password", (string)(aP1_password));
         restCliLoginWithUsernamePassword.RestExecute();
         if ( restCliLoginWithUsernamePassword.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliLoginWithUsernamePassword.ErrorCode;
            gxProperties.ErrorMessage = restCliLoginWithUsernamePassword.ErrorMessage;
            gxProperties.StatusCode = restCliLoginWithUsernamePassword.StatusCode;
            aP2_loginResult = new SdtSDT_LoginResidentResponse();
         }
         else
         {
            aP2_loginResult = restCliLoginWithUsernamePassword.GetBodySdt<SdtSDT_LoginResidentResponse>("loginResult");
         }
         /* LoginWithUsernamePassword Constructor */
      }

      public void gxep_recoverpasswordstep1( string aP0_username ,
                                             out SdtSDT_RecoverPasswordStep1 aP1_RecoverPasswordStep1Result )
      {
         restCliRecoverPasswordStep1 = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/auth/resident-recover-password-step1";
         restCliRecoverPasswordStep1.Location = restLocation;
         restCliRecoverPasswordStep1.HttpMethod = "POST";
         restCliRecoverPasswordStep1.AddBodyVar("username", (string)(aP0_username));
         restCliRecoverPasswordStep1.RestExecute();
         if ( restCliRecoverPasswordStep1.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliRecoverPasswordStep1.ErrorCode;
            gxProperties.ErrorMessage = restCliRecoverPasswordStep1.ErrorMessage;
            gxProperties.StatusCode = restCliRecoverPasswordStep1.StatusCode;
            aP1_RecoverPasswordStep1Result = new SdtSDT_RecoverPasswordStep1();
         }
         else
         {
            aP1_RecoverPasswordStep1Result = restCliRecoverPasswordStep1.GetBodySdt<SdtSDT_RecoverPasswordStep1>("RecoverPasswordStep1Result");
         }
         /* RecoverPasswordStep1 Constructor */
      }

      public void gxep_changeuserpassword( string aP0_userId ,
                                           string aP1_password ,
                                           string aP2_passwordNew ,
                                           out SdtSDT_ChangeYourPassword aP3_ChangeYourPasswordResult )
      {
         restCliChangeUserPassword = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/auth/resident-change-password";
         restCliChangeUserPassword.Location = restLocation;
         restCliChangeUserPassword.HttpMethod = "POST";
         restCliChangeUserPassword.AddBodyVar("userId", (string)(aP0_userId));
         restCliChangeUserPassword.AddBodyVar("password", (string)(aP1_password));
         restCliChangeUserPassword.AddBodyVar("passwordNew", (string)(aP2_passwordNew));
         restCliChangeUserPassword.RestExecute();
         if ( restCliChangeUserPassword.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliChangeUserPassword.ErrorCode;
            gxProperties.ErrorMessage = restCliChangeUserPassword.ErrorMessage;
            gxProperties.StatusCode = restCliChangeUserPassword.StatusCode;
            aP3_ChangeYourPasswordResult = new SdtSDT_ChangeYourPassword();
         }
         else
         {
            aP3_ChangeYourPasswordResult = restCliChangeUserPassword.GetBodySdt<SdtSDT_ChangeYourPassword>("ChangeYourPasswordResult");
         }
         /* ChangeUserPassword Constructor */
      }

      public void gxep_refreshauthtoken( string aP0_refreshToken ,
                                         out SdtSDT_LoginResidentResponse aP1_loginResult )
      {
         restCliRefreshAuthToken = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/auth/refresh-token";
         restCliRefreshAuthToken.Location = restLocation;
         restCliRefreshAuthToken.HttpMethod = "POST";
         restCliRefreshAuthToken.AddBodyVar("refreshToken", (string)(aP0_refreshToken));
         restCliRefreshAuthToken.RestExecute();
         if ( restCliRefreshAuthToken.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliRefreshAuthToken.ErrorCode;
            gxProperties.ErrorMessage = restCliRefreshAuthToken.ErrorMessage;
            gxProperties.StatusCode = restCliRefreshAuthToken.StatusCode;
            aP1_loginResult = new SdtSDT_LoginResidentResponse();
         }
         else
         {
            aP1_loginResult = restCliRefreshAuthToken.GetBodySdt<SdtSDT_LoginResidentResponse>("loginResult");
         }
         /* RefreshAuthToken Constructor */
      }

      public void gxep_getresidentinformation( string aP0_userId ,
                                               out SdtSDT_Resident aP1_SDT_Resident )
      {
         restCliGetResidentInformation = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/auth/resident";
         restCliGetResidentInformation.Location = restLocation;
         restCliGetResidentInformation.HttpMethod = "GET";
         restCliGetResidentInformation.AddQueryVar("Userid", (string)(aP0_userId));
         restCliGetResidentInformation.RestExecute();
         if ( restCliGetResidentInformation.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetResidentInformation.ErrorCode;
            gxProperties.ErrorMessage = restCliGetResidentInformation.ErrorMessage;
            gxProperties.StatusCode = restCliGetResidentInformation.StatusCode;
            aP1_SDT_Resident = new SdtSDT_Resident();
         }
         else
         {
            aP1_SDT_Resident = restCliGetResidentInformation.GetBodySdt<SdtSDT_Resident>("SDT_Resident");
         }
         /* GetResidentInformation Constructor */
      }

      public void gxep_getorganisationinformation( Guid aP0_organisationId ,
                                                   out SdtSDT_Organisation aP1_SDT_Organisation )
      {
         restCliGetOrganisationInformation = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/resident/organisation";
         restCliGetOrganisationInformation.Location = restLocation;
         restCliGetOrganisationInformation.HttpMethod = "GET";
         restCliGetOrganisationInformation.AddQueryVar("Organisationid", (Guid)(aP0_organisationId));
         restCliGetOrganisationInformation.RestExecute();
         if ( restCliGetOrganisationInformation.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetOrganisationInformation.ErrorCode;
            gxProperties.ErrorMessage = restCliGetOrganisationInformation.ErrorMessage;
            gxProperties.StatusCode = restCliGetOrganisationInformation.StatusCode;
            aP1_SDT_Organisation = new SdtSDT_Organisation();
         }
         else
         {
            aP1_SDT_Organisation = restCliGetOrganisationInformation.GetBodySdt<SdtSDT_Organisation>("SDT_Organisation");
         }
         /* GetOrganisationInformation Constructor */
      }

      public void gxep_getlocationinformation( Guid aP0_locationId ,
                                               out SdtSDT_Location aP1_SDT_Location )
      {
         restCliGetLocationInformation = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/resident/location";
         restCliGetLocationInformation.Location = restLocation;
         restCliGetLocationInformation.HttpMethod = "GET";
         restCliGetLocationInformation.AddQueryVar("Locationid", (Guid)(aP0_locationId));
         restCliGetLocationInformation.RestExecute();
         if ( restCliGetLocationInformation.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetLocationInformation.ErrorCode;
            gxProperties.ErrorMessage = restCliGetLocationInformation.ErrorMessage;
            gxProperties.StatusCode = restCliGetLocationInformation.StatusCode;
            aP1_SDT_Location = new SdtSDT_Location();
         }
         else
         {
            aP1_SDT_Location = restCliGetLocationInformation.GetBodySdt<SdtSDT_Location>("SDT_Location");
         }
         /* GetLocationInformation Constructor */
      }

      public void gxep_getresidentnotificationhistory( string aP0_ResidentId ,
                                                       short aP1_PageSize ,
                                                       short aP2_PageNumber ,
                                                       out SdtSDT_ApiListResponse aP3_SDT_ApiListResponse )
      {
         restCliGetResidentNotificationHistory = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/resident/notification-history";
         restCliGetResidentNotificationHistory.Location = restLocation;
         restCliGetResidentNotificationHistory.HttpMethod = "GET";
         restCliGetResidentNotificationHistory.AddQueryVar("Residentid", (string)(aP0_ResidentId));
         restCliGetResidentNotificationHistory.AddQueryVar("Pagesize", (short)(aP1_PageSize));
         restCliGetResidentNotificationHistory.AddQueryVar("Pagenumber", (short)(aP2_PageNumber));
         restCliGetResidentNotificationHistory.RestExecute();
         if ( restCliGetResidentNotificationHistory.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetResidentNotificationHistory.ErrorCode;
            gxProperties.ErrorMessage = restCliGetResidentNotificationHistory.ErrorMessage;
            gxProperties.StatusCode = restCliGetResidentNotificationHistory.StatusCode;
            aP3_SDT_ApiListResponse = new SdtSDT_ApiListResponse();
         }
         else
         {
            aP3_SDT_ApiListResponse = restCliGetResidentNotificationHistory.GetBodySdt<SdtSDT_ApiListResponse>("SDT_ApiListResponse");
         }
         /* GetResidentNotificationHistory Constructor */
      }

      public void gxep_getresidentfilledforms( string aP0_ResidentId ,
                                               short aP1_PageSize ,
                                               short aP2_PageNumber ,
                                               out SdtSDT_ApiListResponse aP3_SDT_ApiListResponse )
      {
         restCliGetResidentFilledForms = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/resident/filled-forms";
         restCliGetResidentFilledForms.Location = restLocation;
         restCliGetResidentFilledForms.HttpMethod = "GET";
         restCliGetResidentFilledForms.AddQueryVar("Residentid", (string)(aP0_ResidentId));
         restCliGetResidentFilledForms.AddQueryVar("Pagesize", (short)(aP1_PageSize));
         restCliGetResidentFilledForms.AddQueryVar("Pagenumber", (short)(aP2_PageNumber));
         restCliGetResidentFilledForms.RestExecute();
         if ( restCliGetResidentFilledForms.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetResidentFilledForms.ErrorCode;
            gxProperties.ErrorMessage = restCliGetResidentFilledForms.ErrorMessage;
            gxProperties.StatusCode = restCliGetResidentFilledForms.StatusCode;
            aP3_SDT_ApiListResponse = new SdtSDT_ApiListResponse();
         }
         else
         {
            aP3_SDT_ApiListResponse = restCliGetResidentFilledForms.GetBodySdt<SdtSDT_ApiListResponse>("SDT_ApiListResponse");
         }
         /* GetResidentFilledForms Constructor */
      }

      public void gxep_updateresidentavatar( string aP0_Base64Image ,
                                             string aP1_ResidentId ,
                                             out string aP2_result )
      {
         restCliUpdateResidentAvatar = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/resident/update-avatar";
         restCliUpdateResidentAvatar.Location = restLocation;
         restCliUpdateResidentAvatar.HttpMethod = "POST";
         restCliUpdateResidentAvatar.AddBodyVar("Base64Image", (string)(aP0_Base64Image));
         restCliUpdateResidentAvatar.AddBodyVar("ResidentId", (string)(aP1_ResidentId));
         restCliUpdateResidentAvatar.RestExecute();
         if ( restCliUpdateResidentAvatar.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUpdateResidentAvatar.ErrorCode;
            gxProperties.ErrorMessage = restCliUpdateResidentAvatar.ErrorMessage;
            gxProperties.StatusCode = restCliUpdateResidentAvatar.StatusCode;
            aP2_result = "";
         }
         else
         {
            aP2_result = restCliUpdateResidentAvatar.GetBodyString("result");
         }
         /* UpdateResidentAvatar Constructor */
      }

      public void gxep_registerdevice( string aP0_DeviceToken ,
                                       string aP1_DeviceID ,
                                       short aP2_DeviceType ,
                                       string aP3_NotificationPlatform ,
                                       string aP4_NotificationPlatformId ,
                                       string aP5_userId ,
                                       out string aP6_result )
      {
         restCliRegisterDevice = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/mobile/register-device";
         restCliRegisterDevice.Location = restLocation;
         restCliRegisterDevice.HttpMethod = "POST";
         restCliRegisterDevice.AddBodyVar("DeviceToken", (string)(aP0_DeviceToken));
         restCliRegisterDevice.AddBodyVar("DeviceID", (string)(aP1_DeviceID));
         restCliRegisterDevice.AddBodyVar("DeviceType", (short)(aP2_DeviceType));
         restCliRegisterDevice.AddBodyVar("NotificationPlatform", (string)(aP3_NotificationPlatform));
         restCliRegisterDevice.AddBodyVar("NotificationPlatformId", (string)(aP4_NotificationPlatformId));
         restCliRegisterDevice.AddBodyVar("userId", (string)(aP5_userId));
         restCliRegisterDevice.RestExecute();
         if ( restCliRegisterDevice.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliRegisterDevice.ErrorCode;
            gxProperties.ErrorMessage = restCliRegisterDevice.ErrorMessage;
            gxProperties.StatusCode = restCliRegisterDevice.StatusCode;
            aP6_result = "";
         }
         else
         {
            aP6_result = restCliRegisterDevice.GetBodyString("result");
         }
         /* RegisterDevice Constructor */
      }

      public void gxep_setresidentlanguage( string aP0_ResidentId ,
                                            string aP1_Language ,
                                            out string aP2_result )
      {
         restCliSetResidentLanguage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/mobile/set-language";
         restCliSetResidentLanguage.Location = restLocation;
         restCliSetResidentLanguage.HttpMethod = "POST";
         restCliSetResidentLanguage.AddBodyVar("ResidentId", (string)(aP0_ResidentId));
         restCliSetResidentLanguage.AddBodyVar("Language", (string)(aP1_Language));
         restCliSetResidentLanguage.RestExecute();
         if ( restCliSetResidentLanguage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliSetResidentLanguage.ErrorCode;
            gxProperties.ErrorMessage = restCliSetResidentLanguage.ErrorMessage;
            gxProperties.StatusCode = restCliSetResidentLanguage.StatusCode;
            aP2_result = "";
         }
         else
         {
            aP2_result = restCliSetResidentLanguage.GetBodyString("result");
         }
         /* SetResidentLanguage Constructor */
      }

      public void gxep_sendnotification( string aP0_title ,
                                         string aP1_message ,
                                         string aP2_userId ,
                                         out string aP3_result )
      {
         restCliSendNotification = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/mobile/send-notification";
         restCliSendNotification.Location = restLocation;
         restCliSendNotification.HttpMethod = "POST";
         restCliSendNotification.AddBodyVar("title", (string)(aP0_title));
         restCliSendNotification.AddBodyVar("message", (string)(aP1_message));
         restCliSendNotification.AddBodyVar("userId", (string)(aP2_userId));
         restCliSendNotification.RestExecute();
         if ( restCliSendNotification.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliSendNotification.ErrorCode;
            gxProperties.ErrorMessage = restCliSendNotification.ErrorMessage;
            gxProperties.StatusCode = restCliSendNotification.StatusCode;
            aP3_result = "";
         }
         else
         {
            aP3_result = restCliSendNotification.GetBodyString("result");
         }
         /* SendNotification Constructor */
      }

      public void gxep_agendalocation( string aP0_ResidentId ,
                                       string aP1_StartDate ,
                                       string aP2_EndDate ,
                                       out GXBaseCollection<SdtSDT_AgendaLocation> aP3_SDT_AgendaLocation )
      {
         restCliAgendaLocation = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/resident/agenda-events";
         restCliAgendaLocation.Location = restLocation;
         restCliAgendaLocation.HttpMethod = "GET";
         restCliAgendaLocation.AddQueryVar("Residentid", (string)(aP0_ResidentId));
         restCliAgendaLocation.AddQueryVar("Startdate", (string)(aP1_StartDate));
         restCliAgendaLocation.AddQueryVar("Enddate", (string)(aP2_EndDate));
         restCliAgendaLocation.RestExecute();
         if ( restCliAgendaLocation.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliAgendaLocation.ErrorCode;
            gxProperties.ErrorMessage = restCliAgendaLocation.ErrorMessage;
            gxProperties.StatusCode = restCliAgendaLocation.StatusCode;
            aP3_SDT_AgendaLocation = new GXBaseCollection<SdtSDT_AgendaLocation>();
         }
         else
         {
            aP3_SDT_AgendaLocation = restCliAgendaLocation.GetBodySdtCollection<SdtSDT_AgendaLocation>("SDT_AgendaLocation");
         }
         /* AgendaLocation Constructor */
      }

      public void gxep_senddynamicform( out string aP0_result )
      {
         restCliSendDynamicForm = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/form/dynamic-form";
         restCliSendDynamicForm.Location = restLocation;
         restCliSendDynamicForm.HttpMethod = "GET";
         restCliSendDynamicForm.RestExecute();
         if ( restCliSendDynamicForm.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliSendDynamicForm.ErrorCode;
            gxProperties.ErrorMessage = restCliSendDynamicForm.ErrorMessage;
            gxProperties.StatusCode = restCliSendDynamicForm.StatusCode;
            aP0_result = "";
         }
         else
         {
            aP0_result = restCliSendDynamicForm.GetBodyString("result");
         }
         /* SendDynamicForm Constructor */
      }

      public void gxep_uploadmedia( string aP0_MediaName ,
                                    string aP1_MediaImageData ,
                                    int aP2_MediaSize ,
                                    string aP3_MediaType ,
                                    out SdtTrn_Media aP4_BC_Trn_Media ,
                                    out SdtSDT_Error aP5_error )
      {
         restCliUploadMedia = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/media/upload";
         restCliUploadMedia.Location = restLocation;
         restCliUploadMedia.HttpMethod = "POST";
         restCliUploadMedia.AddBodyVar("MediaName", (string)(aP0_MediaName));
         restCliUploadMedia.AddBodyVar("MediaImageData", (string)(aP1_MediaImageData));
         restCliUploadMedia.AddBodyVar("MediaSize", (int)(aP2_MediaSize));
         restCliUploadMedia.AddBodyVar("MediaType", (string)(aP3_MediaType));
         restCliUploadMedia.RestExecute();
         if ( restCliUploadMedia.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUploadMedia.ErrorCode;
            gxProperties.ErrorMessage = restCliUploadMedia.ErrorMessage;
            gxProperties.StatusCode = restCliUploadMedia.StatusCode;
            aP4_BC_Trn_Media = new SdtTrn_Media();
            aP5_error = new SdtSDT_Error();
         }
         else
         {
            aP4_BC_Trn_Media = restCliUploadMedia.GetBodySdt<SdtTrn_Media>("BC_Trn_Media");
            aP5_error = restCliUploadMedia.GetBodySdt<SdtSDT_Error>("error");
         }
         /* UploadMedia Constructor */
      }

      public void gxep_uploadcroppedmedia( string aP0_MediaName ,
                                           string aP1_MediaImageData ,
                                           int aP2_MediaSize ,
                                           string aP3_MediaType ,
                                           Guid aP4_CroppedOriginalMediaId ,
                                           out SdtTrn_Media aP5_BC_Trn_Media ,
                                           out SdtSDT_Error aP6_error )
      {
         restCliUploadCroppedMedia = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/media/upload/cropped";
         restCliUploadCroppedMedia.Location = restLocation;
         restCliUploadCroppedMedia.HttpMethod = "POST";
         restCliUploadCroppedMedia.AddBodyVar("MediaName", (string)(aP0_MediaName));
         restCliUploadCroppedMedia.AddBodyVar("MediaImageData", (string)(aP1_MediaImageData));
         restCliUploadCroppedMedia.AddBodyVar("MediaSize", (int)(aP2_MediaSize));
         restCliUploadCroppedMedia.AddBodyVar("MediaType", (string)(aP3_MediaType));
         restCliUploadCroppedMedia.AddBodyVar("CroppedOriginalMediaId", (Guid)(aP4_CroppedOriginalMediaId));
         restCliUploadCroppedMedia.RestExecute();
         if ( restCliUploadCroppedMedia.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUploadCroppedMedia.ErrorCode;
            gxProperties.ErrorMessage = restCliUploadCroppedMedia.ErrorMessage;
            gxProperties.StatusCode = restCliUploadCroppedMedia.StatusCode;
            aP5_BC_Trn_Media = new SdtTrn_Media();
            aP6_error = new SdtSDT_Error();
         }
         else
         {
            aP5_BC_Trn_Media = restCliUploadCroppedMedia.GetBodySdt<SdtTrn_Media>("BC_Trn_Media");
            aP6_error = restCliUploadCroppedMedia.GetBodySdt<SdtSDT_Error>("error");
         }
         /* UploadCroppedMedia Constructor */
      }

      public void gxep_deletemedia( Guid aP0_MediaId ,
                                    out string aP1_result ,
                                    out SdtSDT_Error aP2_error )
      {
         restCliDeleteMedia = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/media/delete";
         restCliDeleteMedia.Location = restLocation;
         restCliDeleteMedia.HttpMethod = "GET";
         restCliDeleteMedia.AddQueryVar("Mediaid", (Guid)(aP0_MediaId));
         restCliDeleteMedia.RestExecute();
         if ( restCliDeleteMedia.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliDeleteMedia.ErrorCode;
            gxProperties.ErrorMessage = restCliDeleteMedia.ErrorMessage;
            gxProperties.StatusCode = restCliDeleteMedia.StatusCode;
            aP1_result = "";
            aP2_error = new SdtSDT_Error();
         }
         else
         {
            aP1_result = restCliDeleteMedia.GetBodyString("result");
            aP2_error = restCliDeleteMedia.GetBodySdt<SdtSDT_Error>("error");
         }
         /* DeleteMedia Constructor */
      }

      public void gxep_getmedia( out GXBaseCollection<SdtSDT_Media> aP0_SDT_MediaCollection ,
                                 out SdtSDT_Error aP1_error )
      {
         restCliGetMedia = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/media";
         restCliGetMedia.Location = restLocation;
         restCliGetMedia.HttpMethod = "GET";
         restCliGetMedia.RestExecute();
         if ( restCliGetMedia.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetMedia.ErrorCode;
            gxProperties.ErrorMessage = restCliGetMedia.ErrorMessage;
            gxProperties.StatusCode = restCliGetMedia.StatusCode;
            aP0_SDT_MediaCollection = new GXBaseCollection<SdtSDT_Media>();
            aP1_error = new SdtSDT_Error();
         }
         else
         {
            aP0_SDT_MediaCollection = restCliGetMedia.GetBodySdtCollection<SdtSDT_Media>("SDT_MediaCollection");
            aP1_error = restCliGetMedia.GetBodySdt<SdtSDT_Error>("error");
         }
         /* GetMedia Constructor */
      }

      public void gxep_uploadlogo( string aP0_LogoUrl ,
                                   out SdtSDT_Error aP1_error )
      {
         restCliUploadLogo = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/media/upload/logo";
         restCliUploadLogo.Location = restLocation;
         restCliUploadLogo.HttpMethod = "POST";
         restCliUploadLogo.AddBodyVar("LogoUrl", (string)(aP0_LogoUrl));
         restCliUploadLogo.RestExecute();
         if ( restCliUploadLogo.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUploadLogo.ErrorCode;
            gxProperties.ErrorMessage = restCliUploadLogo.ErrorMessage;
            gxProperties.StatusCode = restCliUploadLogo.StatusCode;
            aP1_error = new SdtSDT_Error();
         }
         else
         {
            aP1_error = restCliUploadLogo.GetBodySdt<SdtSDT_Error>("error");
         }
         /* UploadLogo Constructor */
      }

      public void gxep_uploadprofileimage( string aP0_ProfileImageUrl ,
                                           out SdtSDT_Error aP1_error )
      {
         restCliUploadProfileImage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/media/upload/profile";
         restCliUploadProfileImage.Location = restLocation;
         restCliUploadProfileImage.HttpMethod = "POST";
         restCliUploadProfileImage.AddBodyVar("ProfileImageUrl", (string)(aP0_ProfileImageUrl));
         restCliUploadProfileImage.RestExecute();
         if ( restCliUploadProfileImage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUploadProfileImage.ErrorCode;
            gxProperties.ErrorMessage = restCliUploadProfileImage.ErrorMessage;
            gxProperties.StatusCode = restCliUploadProfileImage.StatusCode;
            aP1_error = new SdtSDT_Error();
         }
         else
         {
            aP1_error = restCliUploadProfileImage.GetBodySdt<SdtSDT_Error>("error");
         }
         /* UploadProfileImage Constructor */
      }

      public void gxep_getpages( out GXBaseCollection<SdtSDT_Page> aP0_SDT_PageCollection ,
                                 out SdtSDT_Error aP1_error )
      {
         restCliGetPages = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/pages/list";
         restCliGetPages.Location = restLocation;
         restCliGetPages.HttpMethod = "GET";
         restCliGetPages.RestExecute();
         if ( restCliGetPages.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetPages.ErrorCode;
            gxProperties.ErrorMessage = restCliGetPages.ErrorMessage;
            gxProperties.StatusCode = restCliGetPages.StatusCode;
            aP0_SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>();
            aP1_error = new SdtSDT_Error();
         }
         else
         {
            aP0_SDT_PageCollection = restCliGetPages.GetBodySdtCollection<SdtSDT_Page>("SDT_PageCollection");
            aP1_error = restCliGetPages.GetBodySdt<SdtSDT_Error>("error");
         }
         /* GetPages Constructor */
      }

      public void gxep_pagesapi( Guid aP0_locationId ,
                                 Guid aP1_organisationId ,
                                 string aP2_userId ,
                                 out GXBaseCollection<SdtSDT_MobilePage> aP3_SDT_MobilePageCollection )
      {
         restCliPagesAPI = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/pages";
         restCliPagesAPI.Location = restLocation;
         restCliPagesAPI.HttpMethod = "GET";
         restCliPagesAPI.AddQueryVar("Locationid", (Guid)(aP0_locationId));
         restCliPagesAPI.AddQueryVar("Organisationid", (Guid)(aP1_organisationId));
         restCliPagesAPI.AddQueryVar("Userid", (string)(aP2_userId));
         restCliPagesAPI.RestExecute();
         if ( restCliPagesAPI.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliPagesAPI.ErrorCode;
            gxProperties.ErrorMessage = restCliPagesAPI.ErrorMessage;
            gxProperties.StatusCode = restCliPagesAPI.StatusCode;
            aP3_SDT_MobilePageCollection = new GXBaseCollection<SdtSDT_MobilePage>();
         }
         else
         {
            aP3_SDT_MobilePageCollection = restCliPagesAPI.GetBodySdtCollection<SdtSDT_MobilePage>("SDT_MobilePageCollection");
         }
         /* PagesAPI Constructor */
      }

      public void gxep_homepageapi( Guid aP0_locationId ,
                                    Guid aP1_organisationId ,
                                    string aP2_userId ,
                                    out SdtSDT_InfoPage aP3_SDT_InfoPage )
      {
         restCliHomePageAPI = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/home-page";
         restCliHomePageAPI.Location = restLocation;
         restCliHomePageAPI.HttpMethod = "GET";
         restCliHomePageAPI.AddQueryVar("Locationid", (Guid)(aP0_locationId));
         restCliHomePageAPI.AddQueryVar("Organisationid", (Guid)(aP1_organisationId));
         restCliHomePageAPI.AddQueryVar("Userid", (string)(aP2_userId));
         restCliHomePageAPI.RestExecute();
         if ( restCliHomePageAPI.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliHomePageAPI.ErrorCode;
            gxProperties.ErrorMessage = restCliHomePageAPI.ErrorMessage;
            gxProperties.StatusCode = restCliHomePageAPI.StatusCode;
            aP3_SDT_InfoPage = new SdtSDT_InfoPage();
         }
         else
         {
            aP3_SDT_InfoPage = restCliHomePageAPI.GetBodySdt<SdtSDT_InfoPage>("SDT_InfoPage");
         }
         /* HomePageAPI Constructor */
      }

      public void gxep_pageapi( Guid aP0_PageId ,
                                Guid aP1_locationId ,
                                Guid aP2_organisationId ,
                                string aP3_userId ,
                                out SdtSDT_MobilePage aP4_SDT_MobilePage )
      {
         restCliPageAPI = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/page";
         restCliPageAPI.Location = restLocation;
         restCliPageAPI.HttpMethod = "GET";
         restCliPageAPI.AddQueryVar("Pageid", (Guid)(aP0_PageId));
         restCliPageAPI.AddQueryVar("Locationid", (Guid)(aP1_locationId));
         restCliPageAPI.AddQueryVar("Organisationid", (Guid)(aP2_organisationId));
         restCliPageAPI.AddQueryVar("Userid", (string)(aP3_userId));
         restCliPageAPI.RestExecute();
         if ( restCliPageAPI.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliPageAPI.ErrorCode;
            gxProperties.ErrorMessage = restCliPageAPI.ErrorMessage;
            gxProperties.StatusCode = restCliPageAPI.StatusCode;
            aP4_SDT_MobilePage = new SdtSDT_MobilePage();
         }
         else
         {
            aP4_SDT_MobilePage = restCliPageAPI.GetBodySdt<SdtSDT_MobilePage>("SDT_MobilePage");
         }
         /* PageAPI Constructor */
      }

      public void gxep_infopageapi( Guid aP0_PageId ,
                                    Guid aP1_locationId ,
                                    Guid aP2_organisationId ,
                                    string aP3_userId ,
                                    out SdtSDT_InfoPage aP4_SDT_InfoPage )
      {
         restCliInfoPageAPI = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/info-page";
         restCliInfoPageAPI.Location = restLocation;
         restCliInfoPageAPI.HttpMethod = "GET";
         restCliInfoPageAPI.AddQueryVar("Pageid", (Guid)(aP0_PageId));
         restCliInfoPageAPI.AddQueryVar("Locationid", (Guid)(aP1_locationId));
         restCliInfoPageAPI.AddQueryVar("Organisationid", (Guid)(aP2_organisationId));
         restCliInfoPageAPI.AddQueryVar("Userid", (string)(aP3_userId));
         restCliInfoPageAPI.RestExecute();
         if ( restCliInfoPageAPI.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliInfoPageAPI.ErrorCode;
            gxProperties.ErrorMessage = restCliInfoPageAPI.ErrorMessage;
            gxProperties.StatusCode = restCliInfoPageAPI.StatusCode;
            aP4_SDT_InfoPage = new SdtSDT_InfoPage();
         }
         else
         {
            aP4_SDT_InfoPage = restCliInfoPageAPI.GetBodySdt<SdtSDT_InfoPage>("SDT_InfoPage");
         }
         /* InfoPageAPI Constructor */
      }

      public void gxep_contentpagesapi( Guid aP0_locationId ,
                                        Guid aP1_organisationId ,
                                        out GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection )
      {
         restCliContentPagesAPI = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/content-pages";
         restCliContentPagesAPI.Location = restLocation;
         restCliContentPagesAPI.HttpMethod = "GET";
         restCliContentPagesAPI.AddQueryVar("Locationid", (Guid)(aP0_locationId));
         restCliContentPagesAPI.AddQueryVar("Organisationid", (Guid)(aP1_organisationId));
         restCliContentPagesAPI.RestExecute();
         if ( restCliContentPagesAPI.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliContentPagesAPI.ErrorCode;
            gxProperties.ErrorMessage = restCliContentPagesAPI.ErrorMessage;
            gxProperties.StatusCode = restCliContentPagesAPI.StatusCode;
            aP2_SDT_ContentPageCollection = new GXBaseCollection<SdtSDT_ContentPage>();
         }
         else
         {
            aP2_SDT_ContentPageCollection = restCliContentPagesAPI.GetBodySdtCollection<SdtSDT_ContentPage>("SDT_ContentPageCollection");
         }
         /* ContentPagesAPI Constructor */
      }

      public void gxep_getsinglepage( Guid aP0_PageId ,
                                      out SdtSDT_Page aP1_SDT_Page ,
                                      out SdtSDT_Error aP2_error )
      {
         restCliGetSinglePage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/singlepage";
         restCliGetSinglePage.Location = restLocation;
         restCliGetSinglePage.HttpMethod = "GET";
         restCliGetSinglePage.AddQueryVar("Pageid", (Guid)(aP0_PageId));
         restCliGetSinglePage.RestExecute();
         if ( restCliGetSinglePage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetSinglePage.ErrorCode;
            gxProperties.ErrorMessage = restCliGetSinglePage.ErrorMessage;
            gxProperties.StatusCode = restCliGetSinglePage.StatusCode;
            aP1_SDT_Page = new SdtSDT_Page();
            aP2_error = new SdtSDT_Error();
         }
         else
         {
            aP1_SDT_Page = restCliGetSinglePage.GetBodySdt<SdtSDT_Page>("SDT_Page");
            aP2_error = restCliGetSinglePage.GetBodySdt<SdtSDT_Error>("error");
         }
         /* GetSinglePage Constructor */
      }

      public void gxep_deletepage( Guid aP0_PageId ,
                                   out SdtSDT_Error aP1_error )
      {
         restCliDeletePage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/deletepage";
         restCliDeletePage.Location = restLocation;
         restCliDeletePage.HttpMethod = "GET";
         restCliDeletePage.AddQueryVar("Pageid", (Guid)(aP0_PageId));
         restCliDeletePage.RestExecute();
         if ( restCliDeletePage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliDeletePage.ErrorCode;
            gxProperties.ErrorMessage = restCliDeletePage.ErrorMessage;
            gxProperties.StatusCode = restCliDeletePage.StatusCode;
            aP1_error = new SdtSDT_Error();
         }
         else
         {
            aP1_error = restCliDeletePage.GetBodySdt<SdtSDT_Error>("error");
         }
         /* DeletePage Constructor */
      }

      public void gxep_listpages( out GXBaseCollection<SdtSDT_PageStructure> aP0_SDT_PageStructureCollection ,
                                  out SdtSDT_Error aP1_error )
      {
         restCliListPages = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/pages/tree";
         restCliListPages.Location = restLocation;
         restCliListPages.HttpMethod = "GET";
         restCliListPages.RestExecute();
         if ( restCliListPages.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliListPages.ErrorCode;
            gxProperties.ErrorMessage = restCliListPages.ErrorMessage;
            gxProperties.StatusCode = restCliListPages.StatusCode;
            aP0_SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>();
            aP1_error = new SdtSDT_Error();
         }
         else
         {
            aP0_SDT_PageStructureCollection = restCliListPages.GetBodySdtCollection<SdtSDT_PageStructure>("SDT_PageStructureCollection");
            aP1_error = restCliListPages.GetBodySdt<SdtSDT_Error>("error");
         }
         /* ListPages Constructor */
      }

      public void gxep_createpage( string aP0_PageName ,
                                   string aP1_PageJsonContent ,
                                   out string aP2_result ,
                                   out SdtSDT_Error aP3_error )
      {
         restCliCreatePage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/create-page";
         restCliCreatePage.Location = restLocation;
         restCliCreatePage.HttpMethod = "POST";
         restCliCreatePage.AddBodyVar("PageName", (string)(aP0_PageName));
         restCliCreatePage.AddBodyVar("PageJsonContent", (string)(aP1_PageJsonContent));
         restCliCreatePage.RestExecute();
         if ( restCliCreatePage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliCreatePage.ErrorCode;
            gxProperties.ErrorMessage = restCliCreatePage.ErrorMessage;
            gxProperties.StatusCode = restCliCreatePage.StatusCode;
            aP2_result = "";
            aP3_error = new SdtSDT_Error();
         }
         else
         {
            aP2_result = restCliCreatePage.GetBodyString("result");
            aP3_error = restCliCreatePage.GetBodySdt<SdtSDT_Error>("error");
         }
         /* CreatePage Constructor */
      }

      public void gxep_createcontentpage( Guid aP0_PageId ,
                                          out string aP1_result ,
                                          out SdtSDT_Error aP2_error )
      {
         restCliCreateContentPage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/create-content-page";
         restCliCreateContentPage.Location = restLocation;
         restCliCreateContentPage.HttpMethod = "POST";
         restCliCreateContentPage.AddBodyVar("PageId", (Guid)(aP0_PageId));
         restCliCreateContentPage.RestExecute();
         if ( restCliCreateContentPage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliCreateContentPage.ErrorCode;
            gxProperties.ErrorMessage = restCliCreateContentPage.ErrorMessage;
            gxProperties.StatusCode = restCliCreateContentPage.StatusCode;
            aP1_result = "";
            aP2_error = new SdtSDT_Error();
         }
         else
         {
            aP1_result = restCliCreateContentPage.GetBodyString("result");
            aP2_error = restCliCreateContentPage.GetBodySdt<SdtSDT_Error>("error");
         }
         /* CreateContentPage Constructor */
      }

      public void gxep_createdynamicformpage( Guid aP0_FormId ,
                                              string aP1_PageName ,
                                              out SdtSDT_Page aP2_SDT_Page ,
                                              out SdtSDT_Error aP3_error )
      {
         restCliCreateDynamicFormPage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/create-dynamic-form-page";
         restCliCreateDynamicFormPage.Location = restLocation;
         restCliCreateDynamicFormPage.HttpMethod = "POST";
         restCliCreateDynamicFormPage.AddBodyVar("FormId", (Guid)(aP0_FormId));
         restCliCreateDynamicFormPage.AddBodyVar("PageName", (string)(aP1_PageName));
         restCliCreateDynamicFormPage.RestExecute();
         if ( restCliCreateDynamicFormPage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliCreateDynamicFormPage.ErrorCode;
            gxProperties.ErrorMessage = restCliCreateDynamicFormPage.ErrorMessage;
            gxProperties.StatusCode = restCliCreateDynamicFormPage.StatusCode;
            aP2_SDT_Page = new SdtSDT_Page();
            aP3_error = new SdtSDT_Error();
         }
         else
         {
            aP2_SDT_Page = restCliCreateDynamicFormPage.GetBodySdt<SdtSDT_Page>("SDT_Page");
            aP3_error = restCliCreateDynamicFormPage.GetBodySdt<SdtSDT_Error>("error");
         }
         /* CreateDynamicFormPage Constructor */
      }

      public void gxep_savepage( Guid aP0_PageId ,
                                 string aP1_PageJsonContent ,
                                 string aP2_PageGJSHtml ,
                                 string aP3_PageGJSJson ,
                                 SdtSDT_Page aP4_SDT_Page ,
                                 out string aP5_result )
      {
         restCliSavePage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/save-page";
         restCliSavePage.Location = restLocation;
         restCliSavePage.HttpMethod = "POST";
         restCliSavePage.AddBodyVar("PageId", (Guid)(aP0_PageId));
         restCliSavePage.AddBodyVar("PageJsonContent", (string)(aP1_PageJsonContent));
         restCliSavePage.AddBodyVar("PageGJSHtml", (string)(aP2_PageGJSHtml));
         restCliSavePage.AddBodyVar("PageGJSJson", (string)(aP3_PageGJSJson));
         restCliSavePage.AddBodyVar("SDT_Page", aP4_SDT_Page);
         restCliSavePage.RestExecute();
         if ( restCliSavePage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliSavePage.ErrorCode;
            gxProperties.ErrorMessage = restCliSavePage.ErrorMessage;
            gxProperties.StatusCode = restCliSavePage.StatusCode;
            aP5_result = "";
         }
         else
         {
            aP5_result = restCliSavePage.GetBodyString("result");
         }
         /* SavePage Constructor */
      }

      public void gxep_updatepage( Guid aP0_PageId ,
                                   string aP1_PageName ,
                                   string aP2_PageJsonContent ,
                                   string aP3_PageGJSHtml ,
                                   string aP4_PageGJSJson ,
                                   bool aP5_PageIsPublished ,
                                   bool aP6_IsNotifyResidents ,
                                   out string aP7_result ,
                                   out SdtSDT_Error aP8_error )
      {
         restCliUpdatePage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/update-page";
         restCliUpdatePage.Location = restLocation;
         restCliUpdatePage.HttpMethod = "POST";
         restCliUpdatePage.AddBodyVar("PageId", (Guid)(aP0_PageId));
         restCliUpdatePage.AddBodyVar("PageName", (string)(aP1_PageName));
         restCliUpdatePage.AddBodyVar("PageJsonContent", (string)(aP2_PageJsonContent));
         restCliUpdatePage.AddBodyVar("PageGJSHtml", (string)(aP3_PageGJSHtml));
         restCliUpdatePage.AddBodyVar("PageGJSJson", (string)(aP4_PageGJSJson));
         restCliUpdatePage.AddBodyVar("PageIsPublished", aP5_PageIsPublished);
         restCliUpdatePage.AddBodyVar("IsNotifyResidents", aP6_IsNotifyResidents);
         restCliUpdatePage.RestExecute();
         if ( restCliUpdatePage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUpdatePage.ErrorCode;
            gxProperties.ErrorMessage = restCliUpdatePage.ErrorMessage;
            gxProperties.StatusCode = restCliUpdatePage.StatusCode;
            aP7_result = "";
            aP8_error = new SdtSDT_Error();
         }
         else
         {
            aP7_result = restCliUpdatePage.GetBodyString("result");
            aP8_error = restCliUpdatePage.GetBodySdt<SdtSDT_Error>("error");
         }
         /* UpdatePage Constructor */
      }

      public void gxep_updatepagebatch( GXBaseCollection<SdtSDT_PublishPage> aP0_PagesList ,
                                        bool aP1_IsNotifyResidents ,
                                        out string aP2_result ,
                                        out SdtSDT_Error aP3_error )
      {
         restCliUpdatePageBatch = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/update-pages-batch";
         restCliUpdatePageBatch.Location = restLocation;
         restCliUpdatePageBatch.HttpMethod = "POST";
         restCliUpdatePageBatch.AddBodyVar("PagesList", aP0_PagesList);
         restCliUpdatePageBatch.AddBodyVar("IsNotifyResidents", aP1_IsNotifyResidents);
         restCliUpdatePageBatch.RestExecute();
         if ( restCliUpdatePageBatch.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUpdatePageBatch.ErrorCode;
            gxProperties.ErrorMessage = restCliUpdatePageBatch.ErrorMessage;
            gxProperties.StatusCode = restCliUpdatePageBatch.StatusCode;
            aP2_result = "";
            aP3_error = new SdtSDT_Error();
         }
         else
         {
            aP2_result = restCliUpdatePageBatch.GetBodyString("result");
            aP3_error = restCliUpdatePageBatch.GetBodySdt<SdtSDT_Error>("error");
         }
         /* UpdatePageBatch Constructor */
      }

      public void gxep_addpagecildren( Guid aP0_ParentPageId ,
                                       Guid aP1_ChildPageId ,
                                       out string aP2_result ,
                                       out SdtSDT_Error aP3_error )
      {
         restCliAddPageCildren = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/add-page-children";
         restCliAddPageCildren.Location = restLocation;
         restCliAddPageCildren.HttpMethod = "POST";
         restCliAddPageCildren.AddBodyVar("ParentPageId", (Guid)(aP0_ParentPageId));
         restCliAddPageCildren.AddBodyVar("ChildPageId", (Guid)(aP1_ChildPageId));
         restCliAddPageCildren.RestExecute();
         if ( restCliAddPageCildren.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliAddPageCildren.ErrorCode;
            gxProperties.ErrorMessage = restCliAddPageCildren.ErrorMessage;
            gxProperties.StatusCode = restCliAddPageCildren.StatusCode;
            aP2_result = "";
            aP3_error = new SdtSDT_Error();
         }
         else
         {
            aP2_result = restCliAddPageCildren.GetBodyString("result");
            aP3_error = restCliAddPageCildren.GetBodySdt<SdtSDT_Error>("error");
         }
         /* AddPageCildren Constructor */
      }

      public void gxep_productserviceapi( Guid aP0_ProductServiceId ,
                                          out SdtSDT_ProductService aP1_SDT_ProductService ,
                                          out SdtSDT_Error aP2_error )
      {
         restCliProductServiceAPI = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/productservice/";
         restCliProductServiceAPI.Location = restLocation;
         restCliProductServiceAPI.HttpMethod = "GET";
         restCliProductServiceAPI.AddQueryVar("Productserviceid", (Guid)(aP0_ProductServiceId));
         restCliProductServiceAPI.RestExecute();
         if ( restCliProductServiceAPI.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliProductServiceAPI.ErrorCode;
            gxProperties.ErrorMessage = restCliProductServiceAPI.ErrorMessage;
            gxProperties.StatusCode = restCliProductServiceAPI.StatusCode;
            aP1_SDT_ProductService = new SdtSDT_ProductService();
            aP2_error = new SdtSDT_Error();
         }
         else
         {
            aP1_SDT_ProductService = restCliProductServiceAPI.GetBodySdt<SdtSDT_ProductService>("SDT_ProductService");
            aP2_error = restCliProductServiceAPI.GetBodySdt<SdtSDT_Error>("error");
         }
         /* ProductServiceAPI Constructor */
      }

      public void gxep_getservices( out GXBaseCollection<SdtSDT_ProductService> aP0_SDT_ProductServiceCollection ,
                                    out SdtSDT_Error aP1_error )
      {
         restCliGetServices = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/services";
         restCliGetServices.Location = restLocation;
         restCliGetServices.HttpMethod = "GET";
         restCliGetServices.RestExecute();
         if ( restCliGetServices.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetServices.ErrorCode;
            gxProperties.ErrorMessage = restCliGetServices.ErrorMessage;
            gxProperties.StatusCode = restCliGetServices.StatusCode;
            aP0_SDT_ProductServiceCollection = new GXBaseCollection<SdtSDT_ProductService>();
            aP1_error = new SdtSDT_Error();
         }
         else
         {
            aP0_SDT_ProductServiceCollection = restCliGetServices.GetBodySdtCollection<SdtSDT_ProductService>("SDT_ProductServiceCollection");
            aP1_error = restCliGetServices.GetBodySdt<SdtSDT_Error>("error");
         }
         /* GetServices Constructor */
      }

      public void gxep_getlocationtheme( Guid aP0_locationId ,
                                         Guid aP1_organisationId ,
                                         out SdtSDT_Theme aP2_SDT_Theme )
      {
         restCliGetLocationTheme = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/location-theme/";
         restCliGetLocationTheme.Location = restLocation;
         restCliGetLocationTheme.HttpMethod = "GET";
         restCliGetLocationTheme.AddQueryVar("Locationid", (Guid)(aP0_locationId));
         restCliGetLocationTheme.AddQueryVar("Organisationid", (Guid)(aP1_organisationId));
         restCliGetLocationTheme.RestExecute();
         if ( restCliGetLocationTheme.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetLocationTheme.ErrorCode;
            gxProperties.ErrorMessage = restCliGetLocationTheme.ErrorMessage;
            gxProperties.StatusCode = restCliGetLocationTheme.StatusCode;
            aP2_SDT_Theme = new SdtSDT_Theme();
         }
         else
         {
            aP2_SDT_Theme = restCliGetLocationTheme.GetBodySdt<SdtSDT_Theme>("SDT_Theme");
         }
         /* GetLocationTheme Constructor */
      }

      public void gxep_toolboxgetlocationtheme( out SdtSDT_LocationTheme aP0_SDT_LocationTheme ,
                                                out SdtSDT_Error aP1_error )
      {
         restCliToolboxGetLocationTheme = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/location-theme/";
         restCliToolboxGetLocationTheme.Location = restLocation;
         restCliToolboxGetLocationTheme.HttpMethod = "GET";
         restCliToolboxGetLocationTheme.RestExecute();
         if ( restCliToolboxGetLocationTheme.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliToolboxGetLocationTheme.ErrorCode;
            gxProperties.ErrorMessage = restCliToolboxGetLocationTheme.ErrorMessage;
            gxProperties.StatusCode = restCliToolboxGetLocationTheme.StatusCode;
            aP0_SDT_LocationTheme = new SdtSDT_LocationTheme();
            aP1_error = new SdtSDT_Error();
         }
         else
         {
            aP0_SDT_LocationTheme = restCliToolboxGetLocationTheme.GetBodySdt<SdtSDT_LocationTheme>("SDT_LocationTheme");
            aP1_error = restCliToolboxGetLocationTheme.GetBodySdt<SdtSDT_Error>("error");
         }
         /* ToolboxGetLocationTheme Constructor */
      }

      public void gxep_getthemes( out GXBaseCollection<SdtSDT_Theme> aP0_SDT_ThemeCollection ,
                                  out SdtSDT_Error aP1_error )
      {
         restCliGetThemes = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/themes";
         restCliGetThemes.Location = restLocation;
         restCliGetThemes.HttpMethod = "GET";
         restCliGetThemes.RestExecute();
         if ( restCliGetThemes.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetThemes.ErrorCode;
            gxProperties.ErrorMessage = restCliGetThemes.ErrorMessage;
            gxProperties.StatusCode = restCliGetThemes.StatusCode;
            aP0_SDT_ThemeCollection = new GXBaseCollection<SdtSDT_Theme>();
            aP1_error = new SdtSDT_Error();
         }
         else
         {
            aP0_SDT_ThemeCollection = restCliGetThemes.GetBodySdtCollection<SdtSDT_Theme>("SDT_ThemeCollection");
            aP1_error = restCliGetThemes.GetBodySdt<SdtSDT_Error>("error");
         }
         /* GetThemes Constructor */
      }

      public void gxep_getatrashitems( out GXBaseCollection<SdtSDT_TrashItem> aP0_TrashItems ,
                                       out SdtSDT_Error aP1_error )
      {
         restCliGetATrashItems = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "toolbox/v2/get-trash";
         restCliGetATrashItems.Location = restLocation;
         restCliGetATrashItems.HttpMethod = "GET";
         restCliGetATrashItems.RestExecute();
         if ( restCliGetATrashItems.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetATrashItems.ErrorCode;
            gxProperties.ErrorMessage = restCliGetATrashItems.ErrorMessage;
            gxProperties.StatusCode = restCliGetATrashItems.StatusCode;
            aP0_TrashItems = new GXBaseCollection<SdtSDT_TrashItem>();
            aP1_error = new SdtSDT_Error();
         }
         else
         {
            aP0_TrashItems = restCliGetATrashItems.GetBodySdtCollection<SdtSDT_TrashItem>("TrashItems");
            aP1_error = restCliGetATrashItems.GetBodySdt<SdtSDT_Error>("error");
         }
         /* GetATrashItems Constructor */
      }

      public void gxep_restoretrash( string aP0_Type ,
                                     Guid aP1_TrashId ,
                                     out SdtSDT_Error aP2_error )
      {
         restCliRestoreTrash = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "toolbox/v2/restore-trash";
         restCliRestoreTrash.Location = restLocation;
         restCliRestoreTrash.HttpMethod = "POST";
         restCliRestoreTrash.AddBodyVar("Type", (string)(aP0_Type));
         restCliRestoreTrash.AddBodyVar("TrashId", (Guid)(aP1_TrashId));
         restCliRestoreTrash.RestExecute();
         if ( restCliRestoreTrash.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliRestoreTrash.ErrorCode;
            gxProperties.ErrorMessage = restCliRestoreTrash.ErrorMessage;
            gxProperties.StatusCode = restCliRestoreTrash.StatusCode;
            aP2_error = new SdtSDT_Error();
         }
         else
         {
            aP2_error = restCliRestoreTrash.GetBodySdt<SdtSDT_Error>("error");
         }
         /* RestoreTrash Constructor */
      }

      public void gxep_deletetrash( string aP0_Type ,
                                    Guid aP1_TrashId ,
                                    out SdtSDT_Error aP2_error )
      {
         restCliDeleteTrash = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "toolbox/v2/delete-trash";
         restCliDeleteTrash.Location = restLocation;
         restCliDeleteTrash.HttpMethod = "POST";
         restCliDeleteTrash.AddBodyVar("Type", (string)(aP0_Type));
         restCliDeleteTrash.AddBodyVar("TrashId", (Guid)(aP1_TrashId));
         restCliDeleteTrash.RestExecute();
         if ( restCliDeleteTrash.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliDeleteTrash.ErrorCode;
            gxProperties.ErrorMessage = restCliDeleteTrash.ErrorMessage;
            gxProperties.StatusCode = restCliDeleteTrash.StatusCode;
            aP2_error = new SdtSDT_Error();
         }
         else
         {
            aP2_error = restCliDeleteTrash.GetBodySdt<SdtSDT_Error>("error");
         }
         /* DeleteTrash Constructor */
      }

      public void gxep_getappversions( out GXBaseCollection<SdtSDT_AppVersion> aP0_AppVersions ,
                                       out SdtSDT_Error aP1_error )
      {
         restCliGetAppVersions = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/appversions";
         restCliGetAppVersions.Location = restLocation;
         restCliGetAppVersions.HttpMethod = "GET";
         restCliGetAppVersions.RestExecute();
         if ( restCliGetAppVersions.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetAppVersions.ErrorCode;
            gxProperties.ErrorMessage = restCliGetAppVersions.ErrorMessage;
            gxProperties.StatusCode = restCliGetAppVersions.StatusCode;
            aP0_AppVersions = new GXBaseCollection<SdtSDT_AppVersion>();
            aP1_error = new SdtSDT_Error();
         }
         else
         {
            aP0_AppVersions = restCliGetAppVersions.GetBodySdtCollection<SdtSDT_AppVersion>("AppVersions");
            aP1_error = restCliGetAppVersions.GetBodySdt<SdtSDT_Error>("error");
         }
         /* GetAppVersions Constructor */
      }

      public void gxep_getappversion( out SdtSDT_AppVersion aP0_AppVersion ,
                                      out SdtSDT_Error aP1_error )
      {
         restCliGetAppVersion = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/appversion";
         restCliGetAppVersion.Location = restLocation;
         restCliGetAppVersion.HttpMethod = "GET";
         restCliGetAppVersion.RestExecute();
         if ( restCliGetAppVersion.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetAppVersion.ErrorCode;
            gxProperties.ErrorMessage = restCliGetAppVersion.ErrorMessage;
            gxProperties.StatusCode = restCliGetAppVersion.StatusCode;
            aP0_AppVersion = new SdtSDT_AppVersion();
            aP1_error = new SdtSDT_Error();
         }
         else
         {
            aP0_AppVersion = restCliGetAppVersion.GetBodySdt<SdtSDT_AppVersion>("AppVersion");
            aP1_error = restCliGetAppVersion.GetBodySdt<SdtSDT_Error>("error");
         }
         /* GetAppVersion Constructor */
      }

      public void gxep_createappversion( string aP0_AppVersionName ,
                                         string aP1_AppVersionLanguage ,
                                         bool aP2_IsActive ,
                                         out SdtSDT_AppVersion aP3_AppVersion ,
                                         out SdtSDT_Error aP4_error )
      {
         restCliCreateAppVersion = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/create-appversion";
         restCliCreateAppVersion.Location = restLocation;
         restCliCreateAppVersion.HttpMethod = "POST";
         restCliCreateAppVersion.AddBodyVar("AppVersionName", (string)(aP0_AppVersionName));
         restCliCreateAppVersion.AddBodyVar("AppVersionLanguage", (string)(aP1_AppVersionLanguage));
         restCliCreateAppVersion.AddBodyVar("IsActive", aP2_IsActive);
         restCliCreateAppVersion.RestExecute();
         if ( restCliCreateAppVersion.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliCreateAppVersion.ErrorCode;
            gxProperties.ErrorMessage = restCliCreateAppVersion.ErrorMessage;
            gxProperties.StatusCode = restCliCreateAppVersion.StatusCode;
            aP3_AppVersion = new SdtSDT_AppVersion();
            aP4_error = new SdtSDT_Error();
         }
         else
         {
            aP3_AppVersion = restCliCreateAppVersion.GetBodySdt<SdtSDT_AppVersion>("AppVersion");
            aP4_error = restCliCreateAppVersion.GetBodySdt<SdtSDT_Error>("error");
         }
         /* CreateAppVersion Constructor */
      }

      public void gxep_copyappversion( Guid aP0_AppVersionId ,
                                       string aP1_AppVersionName ,
                                       out SdtSDT_AppVersion aP2_AppVersion ,
                                       out SdtSDT_Error aP3_error )
      {
         restCliCopyAppVersion = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/copy-appversion";
         restCliCopyAppVersion.Location = restLocation;
         restCliCopyAppVersion.HttpMethod = "POST";
         restCliCopyAppVersion.AddBodyVar("AppVersionId", (Guid)(aP0_AppVersionId));
         restCliCopyAppVersion.AddBodyVar("AppVersionName", (string)(aP1_AppVersionName));
         restCliCopyAppVersion.RestExecute();
         if ( restCliCopyAppVersion.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliCopyAppVersion.ErrorCode;
            gxProperties.ErrorMessage = restCliCopyAppVersion.ErrorMessage;
            gxProperties.StatusCode = restCliCopyAppVersion.StatusCode;
            aP2_AppVersion = new SdtSDT_AppVersion();
            aP3_error = new SdtSDT_Error();
         }
         else
         {
            aP2_AppVersion = restCliCopyAppVersion.GetBodySdt<SdtSDT_AppVersion>("AppVersion");
            aP3_error = restCliCopyAppVersion.GetBodySdt<SdtSDT_Error>("error");
         }
         /* CopyAppVersion Constructor */
      }

      public void gxep_updateappversion( Guid aP0_AppVersionId ,
                                         string aP1_AppVersionName ,
                                         out SdtSDT_AppVersion aP2_AppVersion ,
                                         out SdtSDT_Error aP3_error )
      {
         restCliUpdateAppVersion = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/update-appversion";
         restCliUpdateAppVersion.Location = restLocation;
         restCliUpdateAppVersion.HttpMethod = "POST";
         restCliUpdateAppVersion.AddBodyVar("AppVersionId", (Guid)(aP0_AppVersionId));
         restCliUpdateAppVersion.AddBodyVar("AppVersionName", (string)(aP1_AppVersionName));
         restCliUpdateAppVersion.RestExecute();
         if ( restCliUpdateAppVersion.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUpdateAppVersion.ErrorCode;
            gxProperties.ErrorMessage = restCliUpdateAppVersion.ErrorMessage;
            gxProperties.StatusCode = restCliUpdateAppVersion.StatusCode;
            aP2_AppVersion = new SdtSDT_AppVersion();
            aP3_error = new SdtSDT_Error();
         }
         else
         {
            aP2_AppVersion = restCliUpdateAppVersion.GetBodySdt<SdtSDT_AppVersion>("AppVersion");
            aP3_error = restCliUpdateAppVersion.GetBodySdt<SdtSDT_Error>("error");
         }
         /* UpdateAppVersion Constructor */
      }

      public void gxep_updateappversiontheme( Guid aP0_AppVersionId ,
                                              Guid aP1_ThemeId ,
                                              out SdtSDT_Theme aP2_SDT_Theme ,
                                              out SdtSDT_Error aP3_error )
      {
         restCliUpdateAppVersionTheme = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "toolbox/update-appversion-theme/";
         restCliUpdateAppVersionTheme.Location = restLocation;
         restCliUpdateAppVersionTheme.HttpMethod = "POST";
         restCliUpdateAppVersionTheme.AddBodyVar("AppVersionId", (Guid)(aP0_AppVersionId));
         restCliUpdateAppVersionTheme.AddBodyVar("ThemeId", (Guid)(aP1_ThemeId));
         restCliUpdateAppVersionTheme.RestExecute();
         if ( restCliUpdateAppVersionTheme.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUpdateAppVersionTheme.ErrorCode;
            gxProperties.ErrorMessage = restCliUpdateAppVersionTheme.ErrorMessage;
            gxProperties.StatusCode = restCliUpdateAppVersionTheme.StatusCode;
            aP2_SDT_Theme = new SdtSDT_Theme();
            aP3_error = new SdtSDT_Error();
         }
         else
         {
            aP2_SDT_Theme = restCliUpdateAppVersionTheme.GetBodySdt<SdtSDT_Theme>("SDT_Theme");
            aP3_error = restCliUpdateAppVersionTheme.GetBodySdt<SdtSDT_Error>("error");
         }
         /* UpdateAppVersionTheme Constructor */
      }

      public void gxep_activateappversion( Guid aP0_AppVersionId ,
                                           out SdtSDT_AppVersion aP1_AppVersion ,
                                           out SdtSDT_Error aP2_error )
      {
         restCliActivateAppVersion = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/activate-appversion";
         restCliActivateAppVersion.Location = restLocation;
         restCliActivateAppVersion.HttpMethod = "POST";
         restCliActivateAppVersion.AddBodyVar("AppVersionId", (Guid)(aP0_AppVersionId));
         restCliActivateAppVersion.RestExecute();
         if ( restCliActivateAppVersion.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliActivateAppVersion.ErrorCode;
            gxProperties.ErrorMessage = restCliActivateAppVersion.ErrorMessage;
            gxProperties.StatusCode = restCliActivateAppVersion.StatusCode;
            aP1_AppVersion = new SdtSDT_AppVersion();
            aP2_error = new SdtSDT_Error();
         }
         else
         {
            aP1_AppVersion = restCliActivateAppVersion.GetBodySdt<SdtSDT_AppVersion>("AppVersion");
            aP2_error = restCliActivateAppVersion.GetBodySdt<SdtSDT_Error>("error");
         }
         /* ActivateAppVersion Constructor */
      }

      public void gxep_deleteappversion( Guid aP0_AppVersionId ,
                                         out string aP1_result ,
                                         out SdtSDT_Error aP2_error )
      {
         restCliDeleteAppVersion = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/delete-version";
         restCliDeleteAppVersion.Location = restLocation;
         restCliDeleteAppVersion.HttpMethod = "POST";
         restCliDeleteAppVersion.AddBodyVar("AppVersionId", (Guid)(aP0_AppVersionId));
         restCliDeleteAppVersion.RestExecute();
         if ( restCliDeleteAppVersion.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliDeleteAppVersion.ErrorCode;
            gxProperties.ErrorMessage = restCliDeleteAppVersion.ErrorMessage;
            gxProperties.StatusCode = restCliDeleteAppVersion.StatusCode;
            aP1_result = "";
            aP2_error = new SdtSDT_Error();
         }
         else
         {
            aP1_result = restCliDeleteAppVersion.GetBodyString("result");
            aP2_error = restCliDeleteAppVersion.GetBodySdt<SdtSDT_Error>("error");
         }
         /* DeleteAppVersion Constructor */
      }

      public void gxep_translateappversion( Guid aP0_AppVersionId ,
                                            Guid aP1_ActivePageId ,
                                            string aP2_languageFrom ,
                                            GxSimpleCollection<string> aP3_LanguageToCollection ,
                                            out SdtSDT_Error aP4_error )
      {
         restCliTranslateAppVersion = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "toolbox/translate-appversion/";
         restCliTranslateAppVersion.Location = restLocation;
         restCliTranslateAppVersion.HttpMethod = "POST";
         restCliTranslateAppVersion.AddBodyVar("AppVersionId", (Guid)(aP0_AppVersionId));
         restCliTranslateAppVersion.AddBodyVar("ActivePageId", (Guid)(aP1_ActivePageId));
         restCliTranslateAppVersion.AddBodyVar("languageFrom", (string)(aP2_languageFrom));
         restCliTranslateAppVersion.AddBodyVar("LanguageToCollection", aP3_LanguageToCollection);
         restCliTranslateAppVersion.RestExecute();
         if ( restCliTranslateAppVersion.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliTranslateAppVersion.ErrorCode;
            gxProperties.ErrorMessage = restCliTranslateAppVersion.ErrorMessage;
            gxProperties.StatusCode = restCliTranslateAppVersion.StatusCode;
            aP4_error = new SdtSDT_Error();
         }
         else
         {
            aP4_error = restCliTranslateAppVersion.GetBodySdt<SdtSDT_Error>("error");
         }
         /* TranslateAppVersion Constructor */
      }

      public void gxep_savepagev2( Guid aP0_AppVersionId ,
                                   Guid aP1_PageId ,
                                   string aP2_PageName ,
                                   string aP3_PageType ,
                                   string aP4_PageStructure ,
                                   out SdtSDT_Error aP5_error )
      {
         restCliSavePageV2 = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/save-page";
         restCliSavePageV2.Location = restLocation;
         restCliSavePageV2.HttpMethod = "POST";
         restCliSavePageV2.AddBodyVar("AppVersionId", (Guid)(aP0_AppVersionId));
         restCliSavePageV2.AddBodyVar("PageId", (Guid)(aP1_PageId));
         restCliSavePageV2.AddBodyVar("PageName", (string)(aP2_PageName));
         restCliSavePageV2.AddBodyVar("PageType", (string)(aP3_PageType));
         restCliSavePageV2.AddBodyVar("PageStructure", (string)(aP4_PageStructure));
         restCliSavePageV2.RestExecute();
         if ( restCliSavePageV2.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliSavePageV2.ErrorCode;
            gxProperties.ErrorMessage = restCliSavePageV2.ErrorMessage;
            gxProperties.StatusCode = restCliSavePageV2.StatusCode;
            aP5_error = new SdtSDT_Error();
         }
         else
         {
            aP5_error = restCliSavePageV2.GetBodySdt<SdtSDT_Error>("error");
         }
         /* SavePageV2 Constructor */
      }

      public void gxep_savepagethumbnail( Guid aP0_PageId ,
                                          string aP1_PageThumbnailData ,
                                          out SdtSDT_Error aP2_error )
      {
         restCliSavePageThumbnail = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/save-page-thumbnail";
         restCliSavePageThumbnail.Location = restLocation;
         restCliSavePageThumbnail.HttpMethod = "POST";
         restCliSavePageThumbnail.AddBodyVar("PageId", (Guid)(aP0_PageId));
         restCliSavePageThumbnail.AddBodyVar("PageThumbnailData", (string)(aP1_PageThumbnailData));
         restCliSavePageThumbnail.RestExecute();
         if ( restCliSavePageThumbnail.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliSavePageThumbnail.ErrorCode;
            gxProperties.ErrorMessage = restCliSavePageThumbnail.ErrorMessage;
            gxProperties.StatusCode = restCliSavePageThumbnail.StatusCode;
            aP2_error = new SdtSDT_Error();
         }
         else
         {
            aP2_error = restCliSavePageThumbnail.GetBodySdt<SdtSDT_Error>("error");
         }
         /* SavePageThumbnail Constructor */
      }

      public void gxep_publishappversion( Guid aP0_AppVersionId ,
                                          bool aP1_Notify ,
                                          out SdtSDT_Error aP2_error )
      {
         restCliPublishAppVersion = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/publish-appversion";
         restCliPublishAppVersion.Location = restLocation;
         restCliPublishAppVersion.HttpMethod = "POST";
         restCliPublishAppVersion.AddBodyVar("AppVersionId", (Guid)(aP0_AppVersionId));
         restCliPublishAppVersion.AddBodyVar("Notify", aP1_Notify);
         restCliPublishAppVersion.RestExecute();
         if ( restCliPublishAppVersion.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliPublishAppVersion.ErrorCode;
            gxProperties.ErrorMessage = restCliPublishAppVersion.ErrorMessage;
            gxProperties.StatusCode = restCliPublishAppVersion.StatusCode;
            aP2_error = new SdtSDT_Error();
         }
         else
         {
            aP2_error = restCliPublishAppVersion.GetBodySdt<SdtSDT_Error>("error");
         }
         /* PublishAppVersion Constructor */
      }

      public void gxep_createmenupage( Guid aP0_AppVersionId ,
                                       string aP1_PageName ,
                                       out SdtSDT_AppVersion_PagesItem aP2_MenuPage ,
                                       out SdtSDT_Error aP3_error )
      {
         restCliCreateMenuPage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/create-menu-page";
         restCliCreateMenuPage.Location = restLocation;
         restCliCreateMenuPage.HttpMethod = "POST";
         restCliCreateMenuPage.AddBodyVar("AppVersionId", (Guid)(aP0_AppVersionId));
         restCliCreateMenuPage.AddBodyVar("PageName", (string)(aP1_PageName));
         restCliCreateMenuPage.RestExecute();
         if ( restCliCreateMenuPage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliCreateMenuPage.ErrorCode;
            gxProperties.ErrorMessage = restCliCreateMenuPage.ErrorMessage;
            gxProperties.StatusCode = restCliCreateMenuPage.StatusCode;
            aP2_MenuPage = new SdtSDT_AppVersion_PagesItem();
            aP3_error = new SdtSDT_Error();
         }
         else
         {
            aP2_MenuPage = restCliCreateMenuPage.GetBodySdt<SdtSDT_AppVersion_PagesItem>("MenuPage");
            aP3_error = restCliCreateMenuPage.GetBodySdt<SdtSDT_Error>("error");
         }
         /* CreateMenuPage Constructor */
      }

      public void gxep_createinfopage( Guid aP0_AppVersionId ,
                                       string aP1_PageName ,
                                       out SdtSDT_AppVersion_PagesItem aP2_MenuPage ,
                                       out SdtSDT_Error aP3_error )
      {
         restCliCreateInfoPage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/create-info-page";
         restCliCreateInfoPage.Location = restLocation;
         restCliCreateInfoPage.HttpMethod = "POST";
         restCliCreateInfoPage.AddBodyVar("AppVersionId", (Guid)(aP0_AppVersionId));
         restCliCreateInfoPage.AddBodyVar("PageName", (string)(aP1_PageName));
         restCliCreateInfoPage.RestExecute();
         if ( restCliCreateInfoPage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliCreateInfoPage.ErrorCode;
            gxProperties.ErrorMessage = restCliCreateInfoPage.ErrorMessage;
            gxProperties.StatusCode = restCliCreateInfoPage.StatusCode;
            aP2_MenuPage = new SdtSDT_AppVersion_PagesItem();
            aP3_error = new SdtSDT_Error();
         }
         else
         {
            aP2_MenuPage = restCliCreateInfoPage.GetBodySdt<SdtSDT_AppVersion_PagesItem>("MenuPage");
            aP3_error = restCliCreateInfoPage.GetBodySdt<SdtSDT_Error>("error");
         }
         /* CreateInfoPage Constructor */
      }

      public void gxep_getpagetranslation( Guid aP0_DynamicTranslationPrimaryKey ,
                                           string aP1_Language ,
                                           out SdtSDT_InfoContent aP2_SDT_InfoContent ,
                                           out SdtSDT_Error aP3_error )
      {
         restCliGetPageTranslation = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/get-translated-page";
         restCliGetPageTranslation.Location = restLocation;
         restCliGetPageTranslation.HttpMethod = "POST";
         restCliGetPageTranslation.AddBodyVar("DynamicTranslationPrimaryKey", (Guid)(aP0_DynamicTranslationPrimaryKey));
         restCliGetPageTranslation.AddBodyVar("Language", (string)(aP1_Language));
         restCliGetPageTranslation.RestExecute();
         if ( restCliGetPageTranslation.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetPageTranslation.ErrorCode;
            gxProperties.ErrorMessage = restCliGetPageTranslation.ErrorMessage;
            gxProperties.StatusCode = restCliGetPageTranslation.StatusCode;
            aP2_SDT_InfoContent = new SdtSDT_InfoContent();
            aP3_error = new SdtSDT_Error();
         }
         else
         {
            aP2_SDT_InfoContent = restCliGetPageTranslation.GetBodySdt<SdtSDT_InfoContent>("SDT_InfoContent");
            aP3_error = restCliGetPageTranslation.GetBodySdt<SdtSDT_Error>("error");
         }
         /* GetPageTranslation Constructor */
      }

      public void gxep_updatepagetranslation( Guid aP0_DynamicTranslationPrimaryKey ,
                                              string aP1_Language ,
                                              SdtSDT_InfoContent aP2_SDT_InfoContent ,
                                              out SdtSDT_Error aP3_error )
      {
         restCliUpdatePageTranslation = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/update-translated-page";
         restCliUpdatePageTranslation.Location = restLocation;
         restCliUpdatePageTranslation.HttpMethod = "POST";
         restCliUpdatePageTranslation.AddBodyVar("DynamicTranslationPrimaryKey", (Guid)(aP0_DynamicTranslationPrimaryKey));
         restCliUpdatePageTranslation.AddBodyVar("Language", (string)(aP1_Language));
         restCliUpdatePageTranslation.AddBodyVar("SDT_InfoContent", aP2_SDT_InfoContent);
         restCliUpdatePageTranslation.RestExecute();
         if ( restCliUpdatePageTranslation.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUpdatePageTranslation.ErrorCode;
            gxProperties.ErrorMessage = restCliUpdatePageTranslation.ErrorMessage;
            gxProperties.StatusCode = restCliUpdatePageTranslation.StatusCode;
            aP3_error = new SdtSDT_Error();
         }
         else
         {
            aP3_error = restCliUpdatePageTranslation.GetBodySdt<SdtSDT_Error>("error");
         }
         /* UpdatePageTranslation Constructor */
      }

      public void gxep_createlinkpage( Guid aP0_AppVersionId ,
                                       string aP1_PageName ,
                                       string aP2_Url ,
                                       short aP3_WWPFormId ,
                                       string aP4_WWPFormReferenceName ,
                                       out SdtSDT_AppVersion_PagesItem aP5_MenuPage ,
                                       out SdtSDT_Error aP6_error )
      {
         restCliCreateLinkPage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/create-link-page";
         restCliCreateLinkPage.Location = restLocation;
         restCliCreateLinkPage.HttpMethod = "POST";
         restCliCreateLinkPage.AddBodyVar("AppVersionId", (Guid)(aP0_AppVersionId));
         restCliCreateLinkPage.AddBodyVar("PageName", (string)(aP1_PageName));
         restCliCreateLinkPage.AddBodyVar("Url", (string)(aP2_Url));
         restCliCreateLinkPage.AddBodyVar("WWPFormId", (short)(aP3_WWPFormId));
         restCliCreateLinkPage.AddBodyVar("WWPFormReferenceName", (string)(aP4_WWPFormReferenceName));
         restCliCreateLinkPage.RestExecute();
         if ( restCliCreateLinkPage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliCreateLinkPage.ErrorCode;
            gxProperties.ErrorMessage = restCliCreateLinkPage.ErrorMessage;
            gxProperties.StatusCode = restCliCreateLinkPage.StatusCode;
            aP5_MenuPage = new SdtSDT_AppVersion_PagesItem();
            aP6_error = new SdtSDT_Error();
         }
         else
         {
            aP5_MenuPage = restCliCreateLinkPage.GetBodySdt<SdtSDT_AppVersion_PagesItem>("MenuPage");
            aP6_error = restCliCreateLinkPage.GetBodySdt<SdtSDT_Error>("error");
         }
         /* CreateLinkPage Constructor */
      }

      public void gxep_createservicepage( Guid aP0_AppVersionId ,
                                          Guid aP1_ProductServiceId ,
                                          out SdtSDT_AppVersion_PagesItem aP2_ContentPage ,
                                          out SdtSDT_Error aP3_error )
      {
         restCliCreateServicePage = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/create-service-page";
         restCliCreateServicePage.Location = restLocation;
         restCliCreateServicePage.HttpMethod = "POST";
         restCliCreateServicePage.AddBodyVar("AppVersionId", (Guid)(aP0_AppVersionId));
         restCliCreateServicePage.AddBodyVar("ProductServiceId", (Guid)(aP1_ProductServiceId));
         restCliCreateServicePage.RestExecute();
         if ( restCliCreateServicePage.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliCreateServicePage.ErrorCode;
            gxProperties.ErrorMessage = restCliCreateServicePage.ErrorMessage;
            gxProperties.StatusCode = restCliCreateServicePage.StatusCode;
            aP2_ContentPage = new SdtSDT_AppVersion_PagesItem();
            aP3_error = new SdtSDT_Error();
         }
         else
         {
            aP2_ContentPage = restCliCreateServicePage.GetBodySdt<SdtSDT_AppVersion_PagesItem>("ContentPage");
            aP3_error = restCliCreateServicePage.GetBodySdt<SdtSDT_Error>("error");
         }
         /* CreateServicePage Constructor */
      }

      public void gxep_deletepagev2( Guid aP0_AppVersionId ,
                                     Guid aP1_PageId ,
                                     out SdtSDT_AppVersion aP2_AppVersion ,
                                     out SdtSDT_Error aP3_error )
      {
         restCliDeletePageV2 = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/delete-page";
         restCliDeletePageV2.Location = restLocation;
         restCliDeletePageV2.HttpMethod = "POST";
         restCliDeletePageV2.AddBodyVar("AppVersionId", (Guid)(aP0_AppVersionId));
         restCliDeletePageV2.AddBodyVar("PageId", (Guid)(aP1_PageId));
         restCliDeletePageV2.RestExecute();
         if ( restCliDeletePageV2.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliDeletePageV2.ErrorCode;
            gxProperties.ErrorMessage = restCliDeletePageV2.ErrorMessage;
            gxProperties.StatusCode = restCliDeletePageV2.StatusCode;
            aP2_AppVersion = new SdtSDT_AppVersion();
            aP3_error = new SdtSDT_Error();
         }
         else
         {
            aP2_AppVersion = restCliDeletePageV2.GetBodySdt<SdtSDT_AppVersion>("AppVersion");
            aP3_error = restCliDeletePageV2.GetBodySdt<SdtSDT_Error>("error");
         }
         /* DeletePageV2 Constructor */
      }

      public void gxep_updatepagetitle( Guid aP0_AppVersionId ,
                                        Guid aP1_PageId ,
                                        string aP2_PageName ,
                                        out SdtSDT_Error aP3_error )
      {
         restCliUpdatePageTitle = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/update-page-title";
         restCliUpdatePageTitle.Location = restLocation;
         restCliUpdatePageTitle.HttpMethod = "POST";
         restCliUpdatePageTitle.AddBodyVar("AppVersionId", (Guid)(aP0_AppVersionId));
         restCliUpdatePageTitle.AddBodyVar("PageId", (Guid)(aP1_PageId));
         restCliUpdatePageTitle.AddBodyVar("PageName", (string)(aP2_PageName));
         restCliUpdatePageTitle.RestExecute();
         if ( restCliUpdatePageTitle.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUpdatePageTitle.ErrorCode;
            gxProperties.ErrorMessage = restCliUpdatePageTitle.ErrorMessage;
            gxProperties.StatusCode = restCliUpdatePageTitle.StatusCode;
            aP3_error = new SdtSDT_Error();
         }
         else
         {
            aP3_error = restCliUpdatePageTitle.GetBodySdt<SdtSDT_Error>("error");
         }
         /* UpdatePageTitle Constructor */
      }

      public void gxep_appdebug( GXBaseCollection<SdtSDT_PageUrl> aP0_PageUrlList ,
                                 out SdtSDT_AppDebugResults aP1_SDT_DebugResults ,
                                 out SdtSDT_Error aP2_error )
      {
         restCliAppDebug = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/debug";
         restCliAppDebug.Location = restLocation;
         restCliAppDebug.HttpMethod = "POST";
         restCliAppDebug.AddBodyVar("PageUrlList", aP0_PageUrlList);
         restCliAppDebug.RestExecute();
         if ( restCliAppDebug.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliAppDebug.ErrorCode;
            gxProperties.ErrorMessage = restCliAppDebug.ErrorMessage;
            gxProperties.StatusCode = restCliAppDebug.StatusCode;
            aP1_SDT_DebugResults = new SdtSDT_AppDebugResults();
            aP2_error = new SdtSDT_Error();
         }
         else
         {
            aP1_SDT_DebugResults = restCliAppDebug.GetBodySdt<SdtSDT_AppDebugResults>("SDT_DebugResults");
            aP2_error = restCliAppDebug.GetBodySdt<SdtSDT_Error>("error");
         }
         /* AppDebug Constructor */
      }

      public void gxep_updateproductserviceapi( Guid aP0_ProductServiceId ,
                                                string aP1_ProductServiceDescription ,
                                                string aP2_ProductServiceImageBase64 ,
                                                out SdtSDT_Error aP3_error )
      {
         restCliUpdateProductServiceAPI = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/update-service";
         restCliUpdateProductServiceAPI.Location = restLocation;
         restCliUpdateProductServiceAPI.HttpMethod = "POST";
         restCliUpdateProductServiceAPI.AddBodyVar("ProductServiceId", (Guid)(aP0_ProductServiceId));
         restCliUpdateProductServiceAPI.AddBodyVar("ProductServiceDescription", (string)(aP1_ProductServiceDescription));
         restCliUpdateProductServiceAPI.AddBodyVar("ProductServiceImageBase64", (string)(aP2_ProductServiceImageBase64));
         restCliUpdateProductServiceAPI.RestExecute();
         if ( restCliUpdateProductServiceAPI.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUpdateProductServiceAPI.ErrorCode;
            gxProperties.ErrorMessage = restCliUpdateProductServiceAPI.ErrorMessage;
            gxProperties.StatusCode = restCliUpdateProductServiceAPI.StatusCode;
            aP3_error = new SdtSDT_Error();
         }
         else
         {
            aP3_error = restCliUpdateProductServiceAPI.GetBodySdt<SdtSDT_Error>("error");
         }
         /* UpdateProductServiceAPI Constructor */
      }

      public void gxep_deleteproductserviceimageapi( Guid aP0_ProductServiceId ,
                                                     out SdtSDT_Error aP1_error )
      {
         restCliDeleteProductServiceImageAPI = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/delete-service-image";
         restCliDeleteProductServiceImageAPI.Location = restLocation;
         restCliDeleteProductServiceImageAPI.HttpMethod = "POST";
         restCliDeleteProductServiceImageAPI.AddBodyVar("ProductServiceId", (Guid)(aP0_ProductServiceId));
         restCliDeleteProductServiceImageAPI.RestExecute();
         if ( restCliDeleteProductServiceImageAPI.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliDeleteProductServiceImageAPI.ErrorCode;
            gxProperties.ErrorMessage = restCliDeleteProductServiceImageAPI.ErrorMessage;
            gxProperties.StatusCode = restCliDeleteProductServiceImageAPI.StatusCode;
            aP1_error = new SdtSDT_Error();
         }
         else
         {
            aP1_error = restCliDeleteProductServiceImageAPI.GetBodySdt<SdtSDT_Error>("error");
         }
         /* DeleteProductServiceImageAPI Constructor */
      }

      public void gxep_updatelocationapi__get( out SdtTrn_Location aP0_BC_Trn_Location ,
                                               out SdtSDT_Error aP1_error )
      {
         restCliUpdateLocationAPI__get = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/get-location";
         restCliUpdateLocationAPI__get.Location = restLocation;
         restCliUpdateLocationAPI__get.HttpMethod = "GET";
         restCliUpdateLocationAPI__get.RestExecute();
         if ( restCliUpdateLocationAPI__get.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUpdateLocationAPI__get.ErrorCode;
            gxProperties.ErrorMessage = restCliUpdateLocationAPI__get.ErrorMessage;
            gxProperties.StatusCode = restCliUpdateLocationAPI__get.StatusCode;
            aP0_BC_Trn_Location = new SdtTrn_Location();
            aP1_error = new SdtSDT_Error();
         }
         else
         {
            aP0_BC_Trn_Location = restCliUpdateLocationAPI__get.GetBodySdt<SdtTrn_Location>("BC_Trn_Location");
            aP1_error = restCliUpdateLocationAPI__get.GetBodySdt<SdtSDT_Error>("error");
         }
         /* UpdateLocationAPI__get Constructor */
      }

      public void gxep_updatelocationapi__post( string aP0_LocationDescription ,
                                                string aP1_LocationImageBase64 ,
                                                string aP2_ReceptionDescription ,
                                                string aP3_ReceptionImageBase64 ,
                                                out SdtSDT_Error aP4_error )
      {
         restCliUpdateLocationAPI__post = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/toolbox/v2/update-location";
         restCliUpdateLocationAPI__post.Location = restLocation;
         restCliUpdateLocationAPI__post.HttpMethod = "POST";
         restCliUpdateLocationAPI__post.AddBodyVar("LocationDescription", (string)(aP0_LocationDescription));
         restCliUpdateLocationAPI__post.AddBodyVar("LocationImageBase64", (string)(aP1_LocationImageBase64));
         restCliUpdateLocationAPI__post.AddBodyVar("ReceptionDescription", (string)(aP2_ReceptionDescription));
         restCliUpdateLocationAPI__post.AddBodyVar("ReceptionImageBase64", (string)(aP3_ReceptionImageBase64));
         restCliUpdateLocationAPI__post.RestExecute();
         if ( restCliUpdateLocationAPI__post.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliUpdateLocationAPI__post.ErrorCode;
            gxProperties.ErrorMessage = restCliUpdateLocationAPI__post.ErrorMessage;
            gxProperties.StatusCode = restCliUpdateLocationAPI__post.StatusCode;
            aP4_error = new SdtSDT_Error();
         }
         else
         {
            aP4_error = restCliUpdateLocationAPI__post.GetBodySdt<SdtSDT_Error>("error");
         }
         /* UpdateLocationAPI__post Constructor */
      }

      public void gxep_getmemocategories( out GXBaseCollection<SdtSDT_MemoCategory> aP0_SDT_MemoCategories )
      {
         restCliGetMemoCategories = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/bulletin-board/memo-categories";
         restCliGetMemoCategories.Location = restLocation;
         restCliGetMemoCategories.HttpMethod = "GET";
         restCliGetMemoCategories.RestExecute();
         if ( restCliGetMemoCategories.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetMemoCategories.ErrorCode;
            gxProperties.ErrorMessage = restCliGetMemoCategories.ErrorMessage;
            gxProperties.StatusCode = restCliGetMemoCategories.StatusCode;
            aP0_SDT_MemoCategories = new GXBaseCollection<SdtSDT_MemoCategory>();
         }
         else
         {
            aP0_SDT_MemoCategories = restCliGetMemoCategories.GetBodySdtCollection<SdtSDT_MemoCategory>("SDT_MemoCategories");
         }
         /* GetMemoCategories Constructor */
      }

      public void gxep_getmemocategory( Guid aP0_MemoCategoryId ,
                                        out SdtSDT_MemoCategory aP1_SDT_MemoCategory )
      {
         restCliGetMemoCategory = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/bulletin-board/memo-category";
         restCliGetMemoCategory.Location = restLocation;
         restCliGetMemoCategory.HttpMethod = "GET";
         restCliGetMemoCategory.AddQueryVar("Memocategoryid", (Guid)(aP0_MemoCategoryId));
         restCliGetMemoCategory.RestExecute();
         if ( restCliGetMemoCategory.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetMemoCategory.ErrorCode;
            gxProperties.ErrorMessage = restCliGetMemoCategory.ErrorMessage;
            gxProperties.StatusCode = restCliGetMemoCategory.StatusCode;
            aP1_SDT_MemoCategory = new SdtSDT_MemoCategory();
         }
         else
         {
            aP1_SDT_MemoCategory = restCliGetMemoCategory.GetBodySdt<SdtSDT_MemoCategory>("SDT_MemoCategory");
         }
         /* GetMemoCategory Constructor */
      }

      public void gxep_creatememo( string aP0_ResidentId ,
                                   string aP1_MemoTitle ,
                                   string aP2_MemoDescription ,
                                   string aP3_MemoImage ,
                                   string aP4_MemoDocument ,
                                   [GxJsonFormat("yyyy-MM-dd'T'HH:mm:ss")] DateTime aP5_MemoStartDateTime ,
                                   [GxJsonFormat("yyyy-MM-dd'T'HH:mm:ss")] DateTime aP6_MemoEndDateTime ,
                                   decimal aP7_MemoDuration ,
                                   [GxJsonFormat("yyyy-MM-dd")] DateTime aP8_MemoRemoveDate ,
                                   string aP9_MemoBgColorCode ,
                                   string aP10_MemoForm ,
                                   string aP11_MemoType ,
                                   string aP12_MemoName ,
                                   decimal aP13_MemoLeftOffset ,
                                   decimal aP14_MemoTopOffset ,
                                   decimal aP15_MemoTitleAngle ,
                                   decimal aP16_MemoTitleScale ,
                                   string aP17_MemoTextFontName ,
                                   string aP18_MemoTextAlignment ,
                                   bool aP19_MemoIsBold ,
                                   bool aP20_MemoIsItalic ,
                                   bool aP21_MemoIsCapitalized ,
                                   string aP22_MemoTextColor ,
                                   out SdtSDT_Error aP23_error )
      {
         restCliCreateMemo = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/bulletin-board/create-memo";
         restCliCreateMemo.Location = restLocation;
         restCliCreateMemo.HttpMethod = "POST";
         restCliCreateMemo.AddBodyVar("ResidentId", (string)(aP0_ResidentId));
         restCliCreateMemo.AddBodyVar("MemoTitle", (string)(aP1_MemoTitle));
         restCliCreateMemo.AddBodyVar("MemoDescription", (string)(aP2_MemoDescription));
         restCliCreateMemo.AddBodyVar("MemoImage", (string)(aP3_MemoImage));
         restCliCreateMemo.AddBodyVar("MemoDocument", (string)(aP4_MemoDocument));
         restCliCreateMemo.AddBodyVar("MemoStartDateTime", (DateTime)(aP5_MemoStartDateTime), false);
         restCliCreateMemo.AddBodyVar("MemoEndDateTime", (DateTime)(aP6_MemoEndDateTime), false);
         restCliCreateMemo.AddBodyVar("MemoDuration", (decimal)(aP7_MemoDuration));
         restCliCreateMemo.AddBodyVar("MemoRemoveDate", (DateTime)(aP8_MemoRemoveDate));
         restCliCreateMemo.AddBodyVar("MemoBgColorCode", (string)(aP9_MemoBgColorCode));
         restCliCreateMemo.AddBodyVar("MemoForm", (string)(aP10_MemoForm));
         restCliCreateMemo.AddBodyVar("MemoType", (string)(aP11_MemoType));
         restCliCreateMemo.AddBodyVar("MemoName", (string)(aP12_MemoName));
         restCliCreateMemo.AddBodyVar("MemoLeftOffset", (decimal)(aP13_MemoLeftOffset));
         restCliCreateMemo.AddBodyVar("MemoTopOffset", (decimal)(aP14_MemoTopOffset));
         restCliCreateMemo.AddBodyVar("MemoTitleAngle", (decimal)(aP15_MemoTitleAngle));
         restCliCreateMemo.AddBodyVar("MemoTitleScale", (decimal)(aP16_MemoTitleScale));
         restCliCreateMemo.AddBodyVar("MemoTextFontName", (string)(aP17_MemoTextFontName));
         restCliCreateMemo.AddBodyVar("MemoTextAlignment", (string)(aP18_MemoTextAlignment));
         restCliCreateMemo.AddBodyVar("MemoIsBold", aP19_MemoIsBold);
         restCliCreateMemo.AddBodyVar("MemoIsItalic", aP20_MemoIsItalic);
         restCliCreateMemo.AddBodyVar("MemoIsCapitalized", aP21_MemoIsCapitalized);
         restCliCreateMemo.AddBodyVar("MemoTextColor", (string)(aP22_MemoTextColor));
         restCliCreateMemo.RestExecute();
         if ( restCliCreateMemo.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliCreateMemo.ErrorCode;
            gxProperties.ErrorMessage = restCliCreateMemo.ErrorMessage;
            gxProperties.StatusCode = restCliCreateMemo.StatusCode;
            aP23_error = new SdtSDT_Error();
         }
         else
         {
            aP23_error = restCliCreateMemo.GetBodySdt<SdtSDT_Error>("error");
         }
         /* CreateMemo Constructor */
      }

      public void gxep_updatememo( Guid aP0_MemoId ,
                                   string aP1_ResidentId ,
                                   string aP2_MemoTitle ,
                                   string aP3_MemoDescription ,
                                   string aP4_MemoImage ,
                                   string aP5_MemoDocument ,
                                   [GxJsonFormat("yyyy-MM-dd'T'HH:mm:ss")] DateTime aP6_MemoStartDateTime ,
                                   [GxJsonFormat("yyyy-MM-dd'T'HH:mm:ss")] DateTime aP7_MemoEndDateTime ,
                                   decimal aP8_MemoDuration ,
                                   [GxJsonFormat("yyyy-MM-dd")] DateTime aP9_MemoRemoveDate ,
                                   string aP10_MemoBgColorCode ,
                                   string aP11_MemoForm ,
                                   string aP12_MemoType ,
                                   string aP13_MemoName ,
                                   decimal aP14_MemoLeftOffset ,
                                   decimal aP15_MemoTopOffset ,
                                   decimal aP16_MemoTitleAngle ,
                                   decimal aP17_MemoTitleScale ,
                                   string aP18_MemoTextFontName ,
                                   string aP19_MemoTextAlignment ,
                                   bool aP20_MemoIsBold ,
                                   bool aP21_MemoIsItalic ,
                                   bool aP22_MemoIsCapitalized ,
                                   string aP23_MemoTextColor ,
                                   out SdtSDT_Error aP24_error )
      {
         restCliupdateMemo = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/bulletin-board/update-memo";
         restCliupdateMemo.Location = restLocation;
         restCliupdateMemo.HttpMethod = "POST";
         restCliupdateMemo.AddBodyVar("MemoId", (Guid)(aP0_MemoId));
         restCliupdateMemo.AddBodyVar("ResidentId", (string)(aP1_ResidentId));
         restCliupdateMemo.AddBodyVar("MemoTitle", (string)(aP2_MemoTitle));
         restCliupdateMemo.AddBodyVar("MemoDescription", (string)(aP3_MemoDescription));
         restCliupdateMemo.AddBodyVar("MemoImage", (string)(aP4_MemoImage));
         restCliupdateMemo.AddBodyVar("MemoDocument", (string)(aP5_MemoDocument));
         restCliupdateMemo.AddBodyVar("MemoStartDateTime", (DateTime)(aP6_MemoStartDateTime), false);
         restCliupdateMemo.AddBodyVar("MemoEndDateTime", (DateTime)(aP7_MemoEndDateTime), false);
         restCliupdateMemo.AddBodyVar("MemoDuration", (decimal)(aP8_MemoDuration));
         restCliupdateMemo.AddBodyVar("MemoRemoveDate", (DateTime)(aP9_MemoRemoveDate));
         restCliupdateMemo.AddBodyVar("MemoBgColorCode", (string)(aP10_MemoBgColorCode));
         restCliupdateMemo.AddBodyVar("MemoForm", (string)(aP11_MemoForm));
         restCliupdateMemo.AddBodyVar("MemoType", (string)(aP12_MemoType));
         restCliupdateMemo.AddBodyVar("MemoName", (string)(aP13_MemoName));
         restCliupdateMemo.AddBodyVar("MemoLeftOffset", (decimal)(aP14_MemoLeftOffset));
         restCliupdateMemo.AddBodyVar("MemoTopOffset", (decimal)(aP15_MemoTopOffset));
         restCliupdateMemo.AddBodyVar("MemoTitleAngle", (decimal)(aP16_MemoTitleAngle));
         restCliupdateMemo.AddBodyVar("MemoTitleScale", (decimal)(aP17_MemoTitleScale));
         restCliupdateMemo.AddBodyVar("MemoTextFontName", (string)(aP18_MemoTextFontName));
         restCliupdateMemo.AddBodyVar("MemoTextAlignment", (string)(aP19_MemoTextAlignment));
         restCliupdateMemo.AddBodyVar("MemoIsBold", aP20_MemoIsBold);
         restCliupdateMemo.AddBodyVar("MemoIsItalic", aP21_MemoIsItalic);
         restCliupdateMemo.AddBodyVar("MemoIsCapitalized", aP22_MemoIsCapitalized);
         restCliupdateMemo.AddBodyVar("MemoTextColor", (string)(aP23_MemoTextColor));
         restCliupdateMemo.RestExecute();
         if ( restCliupdateMemo.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliupdateMemo.ErrorCode;
            gxProperties.ErrorMessage = restCliupdateMemo.ErrorMessage;
            gxProperties.StatusCode = restCliupdateMemo.StatusCode;
            aP24_error = new SdtSDT_Error();
         }
         else
         {
            aP24_error = restCliupdateMemo.GetBodySdt<SdtSDT_Error>("error");
         }
         /* updateMemo Constructor */
      }

      public void gxep_getmemo( Guid aP0_MemoId ,
                                out SdtSDT_Memo aP1_SDT_Memo )
      {
         restCliGetMemo = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/bulletin-board/memo";
         restCliGetMemo.Location = restLocation;
         restCliGetMemo.HttpMethod = "GET";
         restCliGetMemo.AddQueryVar("Memoid", (Guid)(aP0_MemoId));
         restCliGetMemo.RestExecute();
         if ( restCliGetMemo.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetMemo.ErrorCode;
            gxProperties.ErrorMessage = restCliGetMemo.ErrorMessage;
            gxProperties.StatusCode = restCliGetMemo.StatusCode;
            aP1_SDT_Memo = new SdtSDT_Memo();
         }
         else
         {
            aP1_SDT_Memo = restCliGetMemo.GetBodySdt<SdtSDT_Memo>("SDT_Memo");
         }
         /* GetMemo Constructor */
      }

      public void gxep_getresidentmemos( string aP0_ResidentId ,
                                         short aP1_PageSize ,
                                         short aP2_PageNumber ,
                                         out SdtSDT_ApiListResponse aP3_SDT_ApiListResponse )
      {
         restCliGetResidentMemos = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/bulletin-board/resident-memos";
         restCliGetResidentMemos.Location = restLocation;
         restCliGetResidentMemos.HttpMethod = "GET";
         restCliGetResidentMemos.AddQueryVar("Residentid", (string)(aP0_ResidentId));
         restCliGetResidentMemos.AddQueryVar("Pagesize", (short)(aP1_PageSize));
         restCliGetResidentMemos.AddQueryVar("Pagenumber", (short)(aP2_PageNumber));
         restCliGetResidentMemos.RestExecute();
         if ( restCliGetResidentMemos.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetResidentMemos.ErrorCode;
            gxProperties.ErrorMessage = restCliGetResidentMemos.ErrorMessage;
            gxProperties.StatusCode = restCliGetResidentMemos.StatusCode;
            aP3_SDT_ApiListResponse = new SdtSDT_ApiListResponse();
         }
         else
         {
            aP3_SDT_ApiListResponse = restCliGetResidentMemos.GetBodySdt<SdtSDT_ApiListResponse>("SDT_ApiListResponse");
         }
         /* GetResidentMemos Constructor */
      }

      public void gxep_getlocationmemos( string aP0_ResidentId ,
                                         short aP1_PageSize ,
                                         short aP2_PageNumber ,
                                         out SdtSDT_ApiListResponse aP3_SDT_ApiListResponse )
      {
         restCliGetLocationMemos = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/bulletin-board/location-memos";
         restCliGetLocationMemos.Location = restLocation;
         restCliGetLocationMemos.HttpMethod = "GET";
         restCliGetLocationMemos.AddQueryVar("Residentid", (string)(aP0_ResidentId));
         restCliGetLocationMemos.AddQueryVar("Pagesize", (short)(aP1_PageSize));
         restCliGetLocationMemos.AddQueryVar("Pagenumber", (short)(aP2_PageNumber));
         restCliGetLocationMemos.RestExecute();
         if ( restCliGetLocationMemos.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliGetLocationMemos.ErrorCode;
            gxProperties.ErrorMessage = restCliGetLocationMemos.ErrorMessage;
            gxProperties.StatusCode = restCliGetLocationMemos.StatusCode;
            aP3_SDT_ApiListResponse = new SdtSDT_ApiListResponse();
         }
         else
         {
            aP3_SDT_ApiListResponse = restCliGetLocationMemos.GetBodySdt<SdtSDT_ApiListResponse>("SDT_ApiListResponse");
         }
         /* GetLocationMemos Constructor */
      }

      public void gxep_deletememo( Guid aP0_MemoId ,
                                   out SdtSDT_Error aP1_error )
      {
         restCliDeleteMemo = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "/bulletin-board/delete-memo";
         restCliDeleteMemo.Location = restLocation;
         restCliDeleteMemo.HttpMethod = "GET";
         restCliDeleteMemo.AddQueryVar("Memoid", (Guid)(aP0_MemoId));
         restCliDeleteMemo.RestExecute();
         if ( restCliDeleteMemo.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restCliDeleteMemo.ErrorCode;
            gxProperties.ErrorMessage = restCliDeleteMemo.ErrorMessage;
            gxProperties.StatusCode = restCliDeleteMemo.StatusCode;
            aP1_error = new SdtSDT_Error();
         }
         else
         {
            aP1_error = restCliDeleteMemo.GetBodySdt<SdtSDT_Error>("error");
         }
         /* DeleteMemo Constructor */
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         gxProperties = new GxObjectProperties();
         restCliLoginWithQrCode = new GXRestAPIClient();
         aP1_loginResult = new SdtSDT_LoginResidentResponse();
         restCliLoginWithUsernamePassword = new GXRestAPIClient();
         aP2_loginResult = new SdtSDT_LoginResidentResponse();
         restCliRecoverPasswordStep1 = new GXRestAPIClient();
         aP1_RecoverPasswordStep1Result = new SdtSDT_RecoverPasswordStep1();
         restCliChangeUserPassword = new GXRestAPIClient();
         aP3_ChangeYourPasswordResult = new SdtSDT_ChangeYourPassword();
         restCliRefreshAuthToken = new GXRestAPIClient();
         restCliGetResidentInformation = new GXRestAPIClient();
         aP1_SDT_Resident = new SdtSDT_Resident();
         restCliGetOrganisationInformation = new GXRestAPIClient();
         aP1_SDT_Organisation = new SdtSDT_Organisation();
         restCliGetLocationInformation = new GXRestAPIClient();
         aP1_SDT_Location = new SdtSDT_Location();
         restCliGetResidentNotificationHistory = new GXRestAPIClient();
         aP3_SDT_ApiListResponse = new SdtSDT_ApiListResponse();
         restCliGetResidentFilledForms = new GXRestAPIClient();
         restCliUpdateResidentAvatar = new GXRestAPIClient();
         aP2_result = "";
         restCliRegisterDevice = new GXRestAPIClient();
         aP6_result = "";
         restCliSetResidentLanguage = new GXRestAPIClient();
         restCliSendNotification = new GXRestAPIClient();
         aP3_result = "";
         restCliAgendaLocation = new GXRestAPIClient();
         aP3_SDT_AgendaLocation = new GXBaseCollection<SdtSDT_AgendaLocation>();
         restCliSendDynamicForm = new GXRestAPIClient();
         aP0_result = "";
         restCliUploadMedia = new GXRestAPIClient();
         aP4_BC_Trn_Media = new SdtTrn_Media();
         aP5_error = new SdtSDT_Error();
         restCliUploadCroppedMedia = new GXRestAPIClient();
         aP5_BC_Trn_Media = new SdtTrn_Media();
         aP6_error = new SdtSDT_Error();
         restCliDeleteMedia = new GXRestAPIClient();
         aP1_result = "";
         aP2_error = new SdtSDT_Error();
         restCliGetMedia = new GXRestAPIClient();
         aP0_SDT_MediaCollection = new GXBaseCollection<SdtSDT_Media>();
         aP1_error = new SdtSDT_Error();
         restCliUploadLogo = new GXRestAPIClient();
         restCliUploadProfileImage = new GXRestAPIClient();
         restCliGetPages = new GXRestAPIClient();
         aP0_SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>();
         restCliPagesAPI = new GXRestAPIClient();
         aP3_SDT_MobilePageCollection = new GXBaseCollection<SdtSDT_MobilePage>();
         restCliHomePageAPI = new GXRestAPIClient();
         aP3_SDT_InfoPage = new SdtSDT_InfoPage();
         restCliPageAPI = new GXRestAPIClient();
         aP4_SDT_MobilePage = new SdtSDT_MobilePage();
         restCliInfoPageAPI = new GXRestAPIClient();
         aP4_SDT_InfoPage = new SdtSDT_InfoPage();
         restCliContentPagesAPI = new GXRestAPIClient();
         aP2_SDT_ContentPageCollection = new GXBaseCollection<SdtSDT_ContentPage>();
         restCliGetSinglePage = new GXRestAPIClient();
         aP1_SDT_Page = new SdtSDT_Page();
         restCliDeletePage = new GXRestAPIClient();
         restCliListPages = new GXRestAPIClient();
         aP0_SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>();
         restCliCreatePage = new GXRestAPIClient();
         aP3_error = new SdtSDT_Error();
         restCliCreateContentPage = new GXRestAPIClient();
         restCliCreateDynamicFormPage = new GXRestAPIClient();
         aP2_SDT_Page = new SdtSDT_Page();
         restCliSavePage = new GXRestAPIClient();
         aP5_result = "";
         restCliUpdatePage = new GXRestAPIClient();
         aP7_result = "";
         aP8_error = new SdtSDT_Error();
         restCliUpdatePageBatch = new GXRestAPIClient();
         restCliAddPageCildren = new GXRestAPIClient();
         restCliProductServiceAPI = new GXRestAPIClient();
         aP1_SDT_ProductService = new SdtSDT_ProductService();
         restCliGetServices = new GXRestAPIClient();
         aP0_SDT_ProductServiceCollection = new GXBaseCollection<SdtSDT_ProductService>();
         restCliGetLocationTheme = new GXRestAPIClient();
         aP2_SDT_Theme = new SdtSDT_Theme();
         restCliToolboxGetLocationTheme = new GXRestAPIClient();
         aP0_SDT_LocationTheme = new SdtSDT_LocationTheme();
         restCliGetThemes = new GXRestAPIClient();
         aP0_SDT_ThemeCollection = new GXBaseCollection<SdtSDT_Theme>();
         restCliGetATrashItems = new GXRestAPIClient();
         aP0_TrashItems = new GXBaseCollection<SdtSDT_TrashItem>();
         restCliRestoreTrash = new GXRestAPIClient();
         restCliDeleteTrash = new GXRestAPIClient();
         restCliGetAppVersions = new GXRestAPIClient();
         aP0_AppVersions = new GXBaseCollection<SdtSDT_AppVersion>();
         restCliGetAppVersion = new GXRestAPIClient();
         aP0_AppVersion = new SdtSDT_AppVersion();
         restCliCreateAppVersion = new GXRestAPIClient();
         aP3_AppVersion = new SdtSDT_AppVersion();
         aP4_error = new SdtSDT_Error();
         restCliCopyAppVersion = new GXRestAPIClient();
         aP2_AppVersion = new SdtSDT_AppVersion();
         restCliUpdateAppVersion = new GXRestAPIClient();
         restCliUpdateAppVersionTheme = new GXRestAPIClient();
         restCliActivateAppVersion = new GXRestAPIClient();
         aP1_AppVersion = new SdtSDT_AppVersion();
         restCliDeleteAppVersion = new GXRestAPIClient();
         restCliTranslateAppVersion = new GXRestAPIClient();
         restCliSavePageV2 = new GXRestAPIClient();
         restCliSavePageThumbnail = new GXRestAPIClient();
         restCliPublishAppVersion = new GXRestAPIClient();
         restCliCreateMenuPage = new GXRestAPIClient();
         aP2_MenuPage = new SdtSDT_AppVersion_PagesItem();
         restCliCreateInfoPage = new GXRestAPIClient();
         restCliGetPageTranslation = new GXRestAPIClient();
         aP2_SDT_InfoContent = new SdtSDT_InfoContent();
         restCliUpdatePageTranslation = new GXRestAPIClient();
         restCliCreateLinkPage = new GXRestAPIClient();
         aP5_MenuPage = new SdtSDT_AppVersion_PagesItem();
         restCliCreateServicePage = new GXRestAPIClient();
         aP2_ContentPage = new SdtSDT_AppVersion_PagesItem();
         restCliDeletePageV2 = new GXRestAPIClient();
         restCliUpdatePageTitle = new GXRestAPIClient();
         restCliAppDebug = new GXRestAPIClient();
         aP1_SDT_DebugResults = new SdtSDT_AppDebugResults();
         restCliUpdateProductServiceAPI = new GXRestAPIClient();
         restCliDeleteProductServiceImageAPI = new GXRestAPIClient();
         restCliUpdateLocationAPI__get = new GXRestAPIClient();
         aP0_BC_Trn_Location = new SdtTrn_Location();
         restCliUpdateLocationAPI__post = new GXRestAPIClient();
         restCliGetMemoCategories = new GXRestAPIClient();
         aP0_SDT_MemoCategories = new GXBaseCollection<SdtSDT_MemoCategory>();
         restCliGetMemoCategory = new GXRestAPIClient();
         aP1_SDT_MemoCategory = new SdtSDT_MemoCategory();
         restCliCreateMemo = new GXRestAPIClient();
         aP23_error = new SdtSDT_Error();
         restCliupdateMemo = new GXRestAPIClient();
         aP24_error = new SdtSDT_Error();
         restCliGetMemo = new GXRestAPIClient();
         aP1_SDT_Memo = new SdtSDT_Memo();
         restCliGetResidentMemos = new GXRestAPIClient();
         restCliGetLocationMemos = new GXRestAPIClient();
         restCliDeleteMemo = new GXRestAPIClient();
         /* GeneXus formulas. */
      }

      protected string Gx_restmethod ;
      protected GXRestAPIClient restCliLoginWithQrCode ;
      protected GXRestAPIClient restCliLoginWithUsernamePassword ;
      protected GXRestAPIClient restCliRecoverPasswordStep1 ;
      protected GXRestAPIClient restCliChangeUserPassword ;
      protected GXRestAPIClient restCliRefreshAuthToken ;
      protected GXRestAPIClient restCliGetResidentInformation ;
      protected GXRestAPIClient restCliGetOrganisationInformation ;
      protected GXRestAPIClient restCliGetLocationInformation ;
      protected GXRestAPIClient restCliGetResidentNotificationHistory ;
      protected GXRestAPIClient restCliGetResidentFilledForms ;
      protected GXRestAPIClient restCliUpdateResidentAvatar ;
      protected GXRestAPIClient restCliRegisterDevice ;
      protected GXRestAPIClient restCliSetResidentLanguage ;
      protected GXRestAPIClient restCliSendNotification ;
      protected GXRestAPIClient restCliAgendaLocation ;
      protected GXRestAPIClient restCliSendDynamicForm ;
      protected GXRestAPIClient restCliUploadMedia ;
      protected GXRestAPIClient restCliUploadCroppedMedia ;
      protected GXRestAPIClient restCliDeleteMedia ;
      protected GXRestAPIClient restCliGetMedia ;
      protected GXRestAPIClient restCliUploadLogo ;
      protected GXRestAPIClient restCliUploadProfileImage ;
      protected GXRestAPIClient restCliGetPages ;
      protected GXRestAPIClient restCliPagesAPI ;
      protected GXRestAPIClient restCliHomePageAPI ;
      protected GXRestAPIClient restCliPageAPI ;
      protected GXRestAPIClient restCliInfoPageAPI ;
      protected GXRestAPIClient restCliContentPagesAPI ;
      protected GXRestAPIClient restCliGetSinglePage ;
      protected GXRestAPIClient restCliDeletePage ;
      protected GXRestAPIClient restCliListPages ;
      protected GXRestAPIClient restCliCreatePage ;
      protected GXRestAPIClient restCliCreateContentPage ;
      protected GXRestAPIClient restCliCreateDynamicFormPage ;
      protected GXRestAPIClient restCliSavePage ;
      protected GXRestAPIClient restCliUpdatePage ;
      protected GXRestAPIClient restCliUpdatePageBatch ;
      protected GXRestAPIClient restCliAddPageCildren ;
      protected GXRestAPIClient restCliProductServiceAPI ;
      protected GXRestAPIClient restCliGetServices ;
      protected GXRestAPIClient restCliGetLocationTheme ;
      protected GXRestAPIClient restCliToolboxGetLocationTheme ;
      protected GXRestAPIClient restCliGetThemes ;
      protected GXRestAPIClient restCliGetATrashItems ;
      protected GXRestAPIClient restCliRestoreTrash ;
      protected GXRestAPIClient restCliDeleteTrash ;
      protected GXRestAPIClient restCliGetAppVersions ;
      protected GXRestAPIClient restCliGetAppVersion ;
      protected GXRestAPIClient restCliCreateAppVersion ;
      protected GXRestAPIClient restCliCopyAppVersion ;
      protected GXRestAPIClient restCliUpdateAppVersion ;
      protected GXRestAPIClient restCliUpdateAppVersionTheme ;
      protected GXRestAPIClient restCliActivateAppVersion ;
      protected GXRestAPIClient restCliDeleteAppVersion ;
      protected GXRestAPIClient restCliTranslateAppVersion ;
      protected GXRestAPIClient restCliSavePageV2 ;
      protected GXRestAPIClient restCliSavePageThumbnail ;
      protected GXRestAPIClient restCliPublishAppVersion ;
      protected GXRestAPIClient restCliCreateMenuPage ;
      protected GXRestAPIClient restCliCreateInfoPage ;
      protected GXRestAPIClient restCliGetPageTranslation ;
      protected GXRestAPIClient restCliUpdatePageTranslation ;
      protected GXRestAPIClient restCliCreateLinkPage ;
      protected GXRestAPIClient restCliCreateServicePage ;
      protected GXRestAPIClient restCliDeletePageV2 ;
      protected GXRestAPIClient restCliUpdatePageTitle ;
      protected GXRestAPIClient restCliAppDebug ;
      protected GXRestAPIClient restCliUpdateProductServiceAPI ;
      protected GXRestAPIClient restCliDeleteProductServiceImageAPI ;
      protected GXRestAPIClient restCliUpdateLocationAPI__get ;
      protected GXRestAPIClient restCliUpdateLocationAPI__post ;
      protected GXRestAPIClient restCliGetMemoCategories ;
      protected GXRestAPIClient restCliGetMemoCategory ;
      protected GXRestAPIClient restCliCreateMemo ;
      protected GXRestAPIClient restCliupdateMemo ;
      protected GXRestAPIClient restCliGetMemo ;
      protected GXRestAPIClient restCliGetResidentMemos ;
      protected GXRestAPIClient restCliGetLocationMemos ;
      protected GXRestAPIClient restCliDeleteMemo ;
      protected GxLocation restLocation ;
      protected GxObjectProperties gxProperties ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected SdtSDT_LoginResidentResponse aP1_loginResult ;
      protected SdtSDT_LoginResidentResponse aP2_loginResult ;
      protected SdtSDT_RecoverPasswordStep1 aP1_RecoverPasswordStep1Result ;
      protected SdtSDT_ChangeYourPassword aP3_ChangeYourPasswordResult ;
      protected SdtSDT_Resident aP1_SDT_Resident ;
      protected SdtSDT_Organisation aP1_SDT_Organisation ;
      protected SdtSDT_Location aP1_SDT_Location ;
      protected SdtSDT_ApiListResponse aP3_SDT_ApiListResponse ;
      protected string aP2_result ;
      protected string aP6_result ;
      protected string aP3_result ;
      protected GXBaseCollection<SdtSDT_AgendaLocation> aP3_SDT_AgendaLocation ;
      protected string aP0_result ;
      protected SdtTrn_Media aP4_BC_Trn_Media ;
      protected SdtSDT_Error aP5_error ;
      protected SdtTrn_Media aP5_BC_Trn_Media ;
      protected SdtSDT_Error aP6_error ;
      protected string aP1_result ;
      protected SdtSDT_Error aP2_error ;
      protected GXBaseCollection<SdtSDT_Media> aP0_SDT_MediaCollection ;
      protected SdtSDT_Error aP1_error ;
      protected GXBaseCollection<SdtSDT_Page> aP0_SDT_PageCollection ;
      protected GXBaseCollection<SdtSDT_MobilePage> aP3_SDT_MobilePageCollection ;
      protected SdtSDT_InfoPage aP3_SDT_InfoPage ;
      protected SdtSDT_MobilePage aP4_SDT_MobilePage ;
      protected SdtSDT_InfoPage aP4_SDT_InfoPage ;
      protected GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection ;
      protected SdtSDT_Page aP1_SDT_Page ;
      protected GXBaseCollection<SdtSDT_PageStructure> aP0_SDT_PageStructureCollection ;
      protected SdtSDT_Error aP3_error ;
      protected SdtSDT_Page aP2_SDT_Page ;
      protected string aP5_result ;
      protected string aP7_result ;
      protected SdtSDT_Error aP8_error ;
      protected SdtSDT_ProductService aP1_SDT_ProductService ;
      protected GXBaseCollection<SdtSDT_ProductService> aP0_SDT_ProductServiceCollection ;
      protected SdtSDT_Theme aP2_SDT_Theme ;
      protected SdtSDT_LocationTheme aP0_SDT_LocationTheme ;
      protected GXBaseCollection<SdtSDT_Theme> aP0_SDT_ThemeCollection ;
      protected GXBaseCollection<SdtSDT_TrashItem> aP0_TrashItems ;
      protected GXBaseCollection<SdtSDT_AppVersion> aP0_AppVersions ;
      protected SdtSDT_AppVersion aP0_AppVersion ;
      protected SdtSDT_AppVersion aP3_AppVersion ;
      protected SdtSDT_Error aP4_error ;
      protected SdtSDT_AppVersion aP2_AppVersion ;
      protected SdtSDT_AppVersion aP1_AppVersion ;
      protected SdtSDT_AppVersion_PagesItem aP2_MenuPage ;
      protected SdtSDT_InfoContent aP2_SDT_InfoContent ;
      protected SdtSDT_AppVersion_PagesItem aP5_MenuPage ;
      protected SdtSDT_AppVersion_PagesItem aP2_ContentPage ;
      protected SdtSDT_AppDebugResults aP1_SDT_DebugResults ;
      protected SdtTrn_Location aP0_BC_Trn_Location ;
      protected GXBaseCollection<SdtSDT_MemoCategory> aP0_SDT_MemoCategories ;
      protected SdtSDT_MemoCategory aP1_SDT_MemoCategory ;
      protected SdtSDT_Error aP23_error ;
      protected SdtSDT_Error aP24_error ;
      protected SdtSDT_Memo aP1_SDT_Memo ;
   }

}
