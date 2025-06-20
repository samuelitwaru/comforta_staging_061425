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
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel ApiIntegratedSecurityLevel( string permissionMethod )
      {
         if ( StringUtil.StrCmp(permissionMethod, "gxep_loginwithqrcode") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_loginwithusernamepassword") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_recoverpasswordstep1") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_changeuserpassword") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_refreshauthtoken") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getresidentinformation") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getorganisationinformation") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getlocationinformation") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getresidentnotificationhistory") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getresidentfilledforms") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_updateresidentavatar") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_registerdevice") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_setresidentlanguage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_sendnotification") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_agendalocation") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_senddynamicform") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_uploadmedia") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_uploadcroppedmedia") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_deletemedia") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getmedia") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_uploadlogo") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_uploadprofileimage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getpages") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_pagesapi") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_homepageapi") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_pageapi") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_infopageapi") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_contentpagesapi") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getsinglepage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_deletepage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_listpages") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_createpage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_createcontentpage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_createdynamicformpage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_savepage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_updatepage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_updatepagebatch") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_addpagecildren") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_productserviceapi") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getservices") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getlocationtheme") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_toolboxgetlocationtheme") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getthemes") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getatrashitems") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_restoretrash") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_deletetrash") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getappversions") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getappversion") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_createappversion") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_copyappversion") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_updateappversion") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_updateappversiontheme") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_activateappversion") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_deleteappversion") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_savepagev2") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_savepagethumbnail") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_publishappversion") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_createmenupage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_createinfopage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_createlinkpage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_createservicepage") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_deletepagev2") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_updatepagetitle") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_updateproductserviceapi") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_deleteproductserviceimageapi") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_updatelocationapi__get") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_updatelocationapi__post") == 0 )
         {
            return GAMSecurityLevel.SecurityNone ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getmemocategories") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getmemocategory") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_creatememo") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_updatememo") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getmemo") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getresidentmemos") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_getlocationmemos") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         else if ( StringUtil.StrCmp(permissionMethod, "gxep_deletememo") == 0 )
         {
            return GAMSecurityLevel.SecurityLow ;
         }
         return GAMSecurityLevel.SecurityLow ;
      }

      protected override string ApiExecutePermissionPrefix( string permissionMethod )
      {
         return "" ;
      }

      public api_residentservice( )
      {
         context = new GxContext(  );
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         IsApiObject = true;
      }

      public api_residentservice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         IsApiObject = true;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
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

      protected void E11012( )
      {
         /* Loginwithqrcode_After Routine */
         returnInSub = false;
         if ( AV20SDT_LoginResidentResponse.FromJSonString(AV17result, null) )
         {
            AV21loginResult = AV20SDT_LoginResidentResponse;
         }
      }

      protected void E12012( )
      {
         /* Loginwithusernamepassword_After Routine */
         returnInSub = false;
         if ( AV20SDT_LoginResidentResponse.FromJSonString(AV17result, null) )
         {
            AV21loginResult = AV20SDT_LoginResidentResponse;
         }
      }

      protected void E13012( )
      {
         /* Changeuserpassword_After Routine */
         returnInSub = false;
         if ( AV75SDT_ChangeYourPassword.FromJSonString(AV17result, null) )
         {
            AV76ChangeYourPasswordResult = AV75SDT_ChangeYourPassword;
         }
      }

      protected void E14012( )
      {
         /* Recoverpasswordstep1_After Routine */
         returnInSub = false;
         if ( AV79SDT_RecoverPasswordStep1.FromJSonString(AV17result, null) )
         {
            AV80RecoverPasswordStep1Result = AV79SDT_RecoverPasswordStep1;
         }
      }

      protected void E15012( )
      {
         /* Refreshauthtoken_After Routine */
         returnInSub = false;
         if ( AV20SDT_LoginResidentResponse.FromJSonString(AV17result, null) )
         {
            AV21loginResult = AV20SDT_LoginResidentResponse;
         }
      }

      protected void E16012( )
      {
         /* Getresidentinformation_After Routine */
         returnInSub = false;
         if ( AV22SDT_Resident.FromJSonString(AV17result, null) )
         {
         }
      }

      protected void E17012( )
      {
         /* Getorganisationinformation_After Routine */
         returnInSub = false;
         if ( AV23SDT_Organisation.FromJSonString(AV17result, null) )
         {
         }
      }

      protected void E18012( )
      {
         /* Getlocationinformation_After Routine */
         returnInSub = false;
         if ( AV19SDT_Location.FromJSonString(AV17result, null) )
         {
         }
      }

      protected void E19012( )
      {
         /* Agendalocation_After Routine */
         returnInSub = false;
         if ( AV42SDT_AgendaLocation.FromJSonString(AV17result, null) )
         {
         }
         else
         {
         }
      }

      protected void E20012( )
      {
         /* Getresidentnotificationhistory_After Routine */
         returnInSub = false;
         AV87SDT_ApiListResponse = new SdtSDT_ApiListResponse(context);
         if ( AV87SDT_ApiListResponse.FromJSonString(AV17result, null) )
         {
         }
         else
         {
         }
      }

      protected void E21012( )
      {
         /* Getresidentfilledforms_After Routine */
         returnInSub = false;
         AV87SDT_ApiListResponse = new SdtSDT_ApiListResponse(context);
         if ( AV87SDT_ApiListResponse.FromJSonString(AV17result, null) )
         {
         }
         else
         {
         }
      }

      protected void E22012( )
      {
         /* Getlocationmemos_After Routine */
         returnInSub = false;
         AV87SDT_ApiListResponse = new SdtSDT_ApiListResponse(context);
         if ( ! AV87SDT_ApiListResponse.FromJSonString(AV17result, null) )
         {
            new prc_logtofile(context ).execute(  context.GetMessage( "Loc Memos API Response: ", "")+AV17result) ;
         }
      }

      protected void E23012( )
      {
         /* Getresidentmemos_After Routine */
         returnInSub = false;
         AV87SDT_ApiListResponse = new SdtSDT_ApiListResponse(context);
         if ( ! AV87SDT_ApiListResponse.FromJSonString(AV17result, null) )
         {
         }
      }

      protected void E24012( )
      {
         /* Createappversion_Before Routine */
         returnInSub = false;
         AV156EmptyGUID = Guid.Empty;
      }

      protected void E25012( )
      {
         /* Activateappversion_Before Routine */
         returnInSub = false;
         AV156EmptyGUID = Guid.Empty;
      }

      protected void E26012( )
      {
         /* Getappversion_Before Routine */
         returnInSub = false;
         AV156EmptyGUID = Guid.Empty;
      }

      public void gxep_loginwithqrcode( string aP0_secretKey ,
                                        out SdtSDT_LoginResidentResponse aP1_loginResult )
      {
         this.AV7secretKey = aP0_secretKey;
         AV21loginResult = new SdtSDT_LoginResidentResponse(context);
         initialize();
         /* LoginWithQrCode Constructor */
         new prc_loginresident(context ).execute(  AV7secretKey, out  AV17result) ;
         /* Execute user event: Loginwithqrcode.After */
         E11012 ();
         if ( returnInSub )
         {
            aP1_loginResult=this.AV21loginResult;
            return;
         }
         aP1_loginResult=this.AV21loginResult;
      }

      public void gxep_loginwithusernamepassword( string aP0_username ,
                                                  string aP1_password ,
                                                  out SdtSDT_LoginResidentResponse aP2_loginResult )
      {
         this.AV71username = aP0_username;
         this.AV72password = aP1_password;
         AV21loginResult = new SdtSDT_LoginResidentResponse(context);
         initialize();
         /* LoginWithUsernamePassword Constructor */
         new prc_loginresident2(context ).execute(  AV71username,  AV72password, out  AV17result) ;
         /* Execute user event: Loginwithusernamepassword.After */
         E12012 ();
         if ( returnInSub )
         {
            aP2_loginResult=this.AV21loginResult;
            return;
         }
         aP2_loginResult=this.AV21loginResult;
      }

      public void gxep_recoverpasswordstep1( string aP0_username ,
                                             out SdtSDT_RecoverPasswordStep1 aP1_RecoverPasswordStep1Result )
      {
         this.AV71username = aP0_username;
         AV80RecoverPasswordStep1Result = new SdtSDT_RecoverPasswordStep1(context);
         initialize();
         /* RecoverPasswordStep1 Constructor */
         new prc_recoverpasswordstep1(context ).execute(  AV71username, out  AV17result) ;
         /* Execute user event: Recoverpasswordstep1.After */
         E14012 ();
         if ( returnInSub )
         {
            aP1_RecoverPasswordStep1Result=this.AV80RecoverPasswordStep1Result;
            return;
         }
         aP1_RecoverPasswordStep1Result=this.AV80RecoverPasswordStep1Result;
      }

      public void gxep_changeuserpassword( string aP0_userId ,
                                           string aP1_password ,
                                           string aP2_passwordNew ,
                                           out SdtSDT_ChangeYourPassword aP3_ChangeYourPasswordResult )
      {
         this.AV8userId = aP0_userId;
         this.AV72password = aP1_password;
         this.AV74passwordNew = aP2_passwordNew;
         AV76ChangeYourPasswordResult = new SdtSDT_ChangeYourPassword(context);
         initialize();
         /* ChangeUserPassword Constructor */
         new prc_changeuserpassword(context ).execute(  AV8userId,  AV72password,  AV74passwordNew, out  AV17result) ;
         /* Execute user event: Changeuserpassword.After */
         E13012 ();
         if ( returnInSub )
         {
            aP3_ChangeYourPasswordResult=this.AV76ChangeYourPasswordResult;
            return;
         }
         aP3_ChangeYourPasswordResult=this.AV76ChangeYourPasswordResult;
      }

      public void gxep_refreshauthtoken( string aP0_refreshToken ,
                                         out SdtSDT_LoginResidentResponse aP1_loginResult )
      {
         this.AV67refreshToken = aP0_refreshToken;
         AV21loginResult = new SdtSDT_LoginResidentResponse(context);
         initialize();
         /* RefreshAuthToken Constructor */
         new prc_refreshauthtoken(context ).execute(  AV67refreshToken, out  AV17result) ;
         /* Execute user event: Refreshauthtoken.After */
         E15012 ();
         if ( returnInSub )
         {
            aP1_loginResult=this.AV21loginResult;
            return;
         }
         aP1_loginResult=this.AV21loginResult;
      }

      public void gxep_getresidentinformation( string aP0_userId ,
                                               out SdtSDT_Resident aP1_SDT_Resident )
      {
         this.AV8userId = aP0_userId;
         AV22SDT_Resident = new SdtSDT_Resident(context);
         initialize();
         /* GetResidentInformation Constructor */
         new prc_getresidentinformation(context ).execute(  AV8userId, out  AV17result) ;
         /* Execute user event: Getresidentinformation.After */
         E16012 ();
         if ( returnInSub )
         {
            aP1_SDT_Resident=this.AV22SDT_Resident;
            return;
         }
         aP1_SDT_Resident=this.AV22SDT_Resident;
      }

      public void gxep_getorganisationinformation( Guid aP0_organisationId ,
                                                   out SdtSDT_Organisation aP1_SDT_Organisation )
      {
         this.AV16organisationId = aP0_organisationId;
         AV23SDT_Organisation = new SdtSDT_Organisation(context);
         initialize();
         /* GetOrganisationInformation Constructor */
         new prc_getorganisationinformation(context ).execute(  AV16organisationId, out  AV17result) ;
         /* Execute user event: Getorganisationinformation.After */
         E17012 ();
         if ( returnInSub )
         {
            aP1_SDT_Organisation=this.AV23SDT_Organisation;
            return;
         }
         aP1_SDT_Organisation=this.AV23SDT_Organisation;
      }

      public void gxep_getlocationinformation( Guid aP0_locationId ,
                                               out SdtSDT_Location aP1_SDT_Location )
      {
         this.AV12locationId = aP0_locationId;
         AV19SDT_Location = new SdtSDT_Location(context);
         initialize();
         /* GetLocationInformation Constructor */
         new prc_getlocationinformation(context ).execute(  AV12locationId, out  AV17result) ;
         /* Execute user event: Getlocationinformation.After */
         E18012 ();
         if ( returnInSub )
         {
            aP1_SDT_Location=this.AV19SDT_Location;
            return;
         }
         aP1_SDT_Location=this.AV19SDT_Location;
      }

      public void gxep_getresidentnotificationhistory( string aP0_ResidentId ,
                                                       short aP1_PageSize ,
                                                       short aP2_PageNumber ,
                                                       out SdtSDT_ApiListResponse aP3_SDT_ApiListResponse )
      {
         this.AV55ResidentId = aP0_ResidentId;
         this.AV86PageSize = aP1_PageSize;
         this.AV85PageNumber = aP2_PageNumber;
         AV87SDT_ApiListResponse = new SdtSDT_ApiListResponse(context);
         initialize();
         /* GetResidentNotificationHistory Constructor */
         new prc_getresidentnotificationhistory(context ).execute(  AV55ResidentId,  AV86PageSize,  AV85PageNumber, out  AV17result) ;
         /* Execute user event: Getresidentnotificationhistory.After */
         E20012 ();
         if ( returnInSub )
         {
            aP3_SDT_ApiListResponse=this.AV87SDT_ApiListResponse;
            return;
         }
         aP3_SDT_ApiListResponse=this.AV87SDT_ApiListResponse;
      }

      public void gxep_getresidentfilledforms( string aP0_ResidentId ,
                                               short aP1_PageSize ,
                                               short aP2_PageNumber ,
                                               out SdtSDT_ApiListResponse aP3_SDT_ApiListResponse )
      {
         this.AV55ResidentId = aP0_ResidentId;
         this.AV86PageSize = aP1_PageSize;
         this.AV85PageNumber = aP2_PageNumber;
         AV87SDT_ApiListResponse = new SdtSDT_ApiListResponse(context);
         initialize();
         /* GetResidentFilledForms Constructor */
         new prc_getresidentfilledforms(context ).execute(  AV55ResidentId,  AV86PageSize,  AV85PageNumber, out  AV17result) ;
         /* Execute user event: Getresidentfilledforms.After */
         E21012 ();
         if ( returnInSub )
         {
            aP3_SDT_ApiListResponse=this.AV87SDT_ApiListResponse;
            return;
         }
         aP3_SDT_ApiListResponse=this.AV87SDT_ApiListResponse;
      }

      public void gxep_updateresidentavatar( string aP0_Base64Image ,
                                             string aP1_ResidentId ,
                                             out string aP2_result )
      {
         this.AV65Base64Image = aP0_Base64Image;
         this.AV55ResidentId = aP1_ResidentId;
         initialize();
         /* UpdateResidentAvatar Constructor */
         new prc_updateresidentavatar(context ).execute(  AV65Base64Image,  AV55ResidentId, out  AV17result) ;
         aP2_result=this.AV17result;
      }

      public void gxep_registerdevice( string aP0_DeviceToken ,
                                       string aP1_DeviceID ,
                                       short aP2_DeviceType ,
                                       string aP3_NotificationPlatform ,
                                       string aP4_NotificationPlatformId ,
                                       string aP5_userId ,
                                       out string aP6_result )
      {
         this.AV10DeviceToken = aP0_DeviceToken;
         this.AV9DeviceID = aP1_DeviceID;
         this.AV11DeviceType = aP2_DeviceType;
         this.AV14NotificationPlatform = aP3_NotificationPlatform;
         this.AV15NotificationPlatformId = aP4_NotificationPlatformId;
         this.AV8userId = aP5_userId;
         initialize();
         /* RegisterDevice Constructor */
         new prc_registermobiledevice(context ).execute(  AV10DeviceToken,  AV9DeviceID,  AV11DeviceType,  AV14NotificationPlatform,  AV15NotificationPlatformId,  AV8userId, out  AV17result) ;
         aP6_result=this.AV17result;
      }

      public void gxep_setresidentlanguage( string aP0_ResidentId ,
                                            string aP1_Language ,
                                            out string aP2_result )
      {
         this.AV55ResidentId = aP0_ResidentId;
         this.AV131Language = aP1_Language;
         initialize();
         /* SetResidentLanguage Constructor */
         new prc_registerresidentlanguage(context ).execute(  AV55ResidentId,  AV131Language, out  AV17result) ;
         aP2_result=this.AV17result;
      }

      public void gxep_sendnotification( string aP0_title ,
                                         string aP1_message ,
                                         string aP2_userId ,
                                         out string aP3_result )
      {
         this.AV18title = aP0_title;
         this.AV13message = aP1_message;
         this.AV8userId = aP2_userId;
         initialize();
         /* SendNotification Constructor */
         new prc_sendnotification(context ).execute(  AV18title,  AV13message,  AV8userId, out  AV17result) ;
         aP3_result=this.AV17result;
      }

      public void gxep_agendalocation( string aP0_ResidentId ,
                                       string aP1_StartDate ,
                                       string aP2_EndDate ,
                                       out GXBaseCollection<SdtSDT_AgendaLocation> aP3_SDT_AgendaLocation )
      {
         this.AV55ResidentId = aP0_ResidentId;
         this.AV60StartDate = aP1_StartDate;
         this.AV58EndDate = aP2_EndDate;
         AV42SDT_AgendaLocation = new GXBaseCollection<SdtSDT_AgendaLocation>( context, "SDT_AgendaLocation", "Comforta_version2");
         initialize();
         /* AgendaLocation Constructor */
         new prc_agendalocationapi(context ).execute(  AV55ResidentId,  AV60StartDate,  AV58EndDate, out  AV17result) ;
         /* Execute user event: Agendalocation.After */
         E19012 ();
         if ( returnInSub )
         {
            aP3_SDT_AgendaLocation=this.AV42SDT_AgendaLocation;
            return;
         }
         aP3_SDT_AgendaLocation=this.AV42SDT_AgendaLocation;
      }

      public void gxep_senddynamicform( out string aP0_result )
      {
         initialize();
         /* SendDynamicForm Constructor */
         new prc_dynamicformapi(context ).execute( out  AV17result) ;
         aP0_result=this.AV17result;
      }

      public void gxep_uploadmedia( string aP0_MediaName ,
                                    string aP1_MediaImageData ,
                                    int aP2_MediaSize ,
                                    string aP3_MediaType ,
                                    out SdtTrn_Media aP4_BC_Trn_Media ,
                                    out SdtSDT_Error aP5_error )
      {
         this.AV30MediaName = aP0_MediaName;
         this.AV32MediaImageData = aP1_MediaImageData;
         this.AV34MediaSize = aP2_MediaSize;
         this.AV35MediaType = aP3_MediaType;
         initialize();
         /* UploadMedia Constructor */
         new prc_uploadmedia(context ).execute(  AV30MediaName,  AV32MediaImageData,  AV34MediaSize,  AV35MediaType, out  AV33BC_Trn_Media, out  AV69error) ;
         aP4_BC_Trn_Media=this.AV33BC_Trn_Media;
         aP5_error=this.AV69error;
      }

      public void gxep_uploadcroppedmedia( string aP0_MediaName ,
                                           string aP1_MediaImageData ,
                                           int aP2_MediaSize ,
                                           string aP3_MediaType ,
                                           Guid aP4_CroppedOriginalMediaId ,
                                           out SdtTrn_Media aP5_BC_Trn_Media ,
                                           out SdtSDT_Error aP6_error )
      {
         this.AV30MediaName = aP0_MediaName;
         this.AV32MediaImageData = aP1_MediaImageData;
         this.AV34MediaSize = aP2_MediaSize;
         this.AV35MediaType = aP3_MediaType;
         this.AV157CroppedOriginalMediaId = aP4_CroppedOriginalMediaId;
         AV33BC_Trn_Media = new SdtTrn_Media(context);
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* UploadCroppedMedia Constructor */
         new prc_uploadcroppedmedia(context ).execute(  AV30MediaName,  AV32MediaImageData,  AV34MediaSize,  AV35MediaType,  AV157CroppedOriginalMediaId, out  AV33BC_Trn_Media, out  AV69error) ;
         aP5_BC_Trn_Media=this.AV33BC_Trn_Media;
         aP6_error=this.AV69error;
      }

      public void gxep_deletemedia( Guid aP0_MediaId ,
                                    out string aP1_result ,
                                    out SdtSDT_Error aP2_error )
      {
         this.AV29MediaId = aP0_MediaId;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* DeleteMedia Constructor */
         new prc_deletemedia(context ).execute(  AV29MediaId, out  AV17result, out  AV69error) ;
         aP1_result=this.AV17result;
         aP2_error=this.AV69error;
      }

      public void gxep_getmedia( out GXBaseCollection<SdtSDT_Media> aP0_SDT_MediaCollection ,
                                 out SdtSDT_Error aP1_error )
      {
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* GetMedia Constructor */
         new prc_getmedia(context ).execute( out  AV64SDT_MediaCollection) ;
         aP0_SDT_MediaCollection=this.AV64SDT_MediaCollection;
         aP1_error=this.AV69error;
      }

      public void gxep_uploadlogo( string aP0_LogoUrl ,
                                   out SdtSDT_Error aP1_error )
      {
         this.AV82LogoUrl = aP0_LogoUrl;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* UploadLogo Constructor */
         new prc_uploadlogo(context ).execute(  AV82LogoUrl, out  AV69error) ;
         aP1_error=this.AV69error;
      }

      public void gxep_uploadprofileimage( string aP0_ProfileImageUrl ,
                                           out SdtSDT_Error aP1_error )
      {
         this.AV81ProfileImageUrl = aP0_ProfileImageUrl;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* UploadProfileImage Constructor */
         new prc_uploadprofileimage(context ).execute(  AV81ProfileImageUrl, out  AV69error) ;
         aP1_error=this.AV69error;
      }

      public void gxep_getpages( out GXBaseCollection<SdtSDT_Page> aP0_SDT_PageCollection ,
                                 out SdtSDT_Error aP1_error )
      {
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* GetPages Constructor */
         new prc_getpages(context ).execute( out  AV27SDT_PageCollection, out  AV69error) ;
         aP0_SDT_PageCollection=this.AV27SDT_PageCollection;
         aP1_error=this.AV69error;
      }

      public void gxep_pagesapi( Guid aP0_locationId ,
                                 Guid aP1_organisationId ,
                                 string aP2_userId ,
                                 out GXBaseCollection<SdtSDT_MobilePage> aP3_SDT_MobilePageCollection )
      {
         this.AV12locationId = aP0_locationId;
         this.AV16organisationId = aP1_organisationId;
         this.AV8userId = aP2_userId;
         initialize();
         /* PagesAPI Constructor */
         new prc_pagesapiv2(context ).execute(  AV12locationId,  AV16organisationId,  AV8userId, out  AV52SDT_MobilePageCollection) ;
         aP3_SDT_MobilePageCollection=this.AV52SDT_MobilePageCollection;
      }

      public void gxep_homepageapi( Guid aP0_locationId ,
                                    Guid aP1_organisationId ,
                                    string aP2_userId ,
                                    out SdtSDT_InfoPage aP3_SDT_InfoPage )
      {
         this.AV12locationId = aP0_locationId;
         this.AV16organisationId = aP1_organisationId;
         this.AV8userId = aP2_userId;
         initialize();
         /* HomePageAPI Constructor */
         new prc_homepageapi(context ).execute(  AV12locationId,  AV16organisationId,  AV8userId, out  AV136SDT_InfoPage) ;
         aP3_SDT_InfoPage=this.AV136SDT_InfoPage;
      }

      public void gxep_pageapi( Guid aP0_PageId ,
                                Guid aP1_locationId ,
                                Guid aP2_organisationId ,
                                string aP3_userId ,
                                out SdtSDT_MobilePage aP4_SDT_MobilePage )
      {
         this.AV37PageId = aP0_PageId;
         this.AV12locationId = aP1_locationId;
         this.AV16organisationId = aP2_organisationId;
         this.AV8userId = aP3_userId;
         initialize();
         /* PageAPI Constructor */
         new prc_pageapiv2(context ).execute(  AV37PageId,  AV12locationId,  AV16organisationId,  AV8userId, out  AV158SDT_MobilePage) ;
         aP4_SDT_MobilePage=this.AV158SDT_MobilePage;
      }

      public void gxep_infopageapi( Guid aP0_PageId ,
                                    Guid aP1_locationId ,
                                    Guid aP2_organisationId ,
                                    string aP3_userId ,
                                    out SdtSDT_InfoPage aP4_SDT_InfoPage )
      {
         this.AV37PageId = aP0_PageId;
         this.AV12locationId = aP1_locationId;
         this.AV16organisationId = aP2_organisationId;
         this.AV8userId = aP3_userId;
         AV136SDT_InfoPage = new SdtSDT_InfoPage(context);
         initialize();
         /* InfoPageAPI Constructor */
         new prc_infopageapi(context ).execute(  AV37PageId,  AV12locationId,  AV16organisationId,  AV8userId, out  AV136SDT_InfoPage) ;
         aP4_SDT_InfoPage=this.AV136SDT_InfoPage;
      }

      public void gxep_contentpagesapi( Guid aP0_locationId ,
                                        Guid aP1_organisationId ,
                                        out GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection )
      {
         this.AV12locationId = aP0_locationId;
         this.AV16organisationId = aP1_organisationId;
         initialize();
         /* ContentPagesAPI Constructor */
         new prc_contentpagesapiv2(context ).execute(  AV12locationId,  AV16organisationId, out  AV51SDT_ContentPageCollection) ;
         aP2_SDT_ContentPageCollection=this.AV51SDT_ContentPageCollection;
      }

      public void gxep_getsinglepage( Guid aP0_PageId ,
                                      out SdtSDT_Page aP1_SDT_Page ,
                                      out SdtSDT_Error aP2_error )
      {
         this.AV37PageId = aP0_PageId;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* GetSinglePage Constructor */
         new prc_getsinglepageapi(context ).execute(  AV37PageId, out  AV38SDT_Page, out  AV69error) ;
         aP1_SDT_Page=this.AV38SDT_Page;
         aP2_error=this.AV69error;
      }

      public void gxep_deletepage( Guid aP0_PageId ,
                                   out SdtSDT_Error aP1_error )
      {
         this.AV37PageId = aP0_PageId;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* DeletePage Constructor */
         new prc_deletepageapi(context ).execute(  AV37PageId, out  AV69error) ;
         aP1_error=this.AV69error;
      }

      public void gxep_listpages( out GXBaseCollection<SdtSDT_PageStructure> aP0_SDT_PageStructureCollection ,
                                  out SdtSDT_Error aP1_error )
      {
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* ListPages Constructor */
         new prc_listpages(context ).execute( out  AV47SDT_PageStructureCollection, out  AV69error) ;
         aP0_SDT_PageStructureCollection=this.AV47SDT_PageStructureCollection;
         aP1_error=this.AV69error;
      }

      public void gxep_createpage( string aP0_PageName ,
                                   string aP1_PageJsonContent ,
                                   out string aP2_result ,
                                   out SdtSDT_Error aP3_error )
      {
         this.AV43PageName = aP0_PageName;
         this.AV41PageJsonContent = aP1_PageJsonContent;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* CreatePage Constructor */
         new prc_createpage(context ).execute(  AV43PageName,  AV41PageJsonContent, ref  AV17result, out  AV69error) ;
         aP2_result=this.AV17result;
         aP3_error=this.AV69error;
      }

      public void gxep_createcontentpage( Guid aP0_PageId ,
                                          out string aP1_result ,
                                          out SdtSDT_Error aP2_error )
      {
         this.AV37PageId = aP0_PageId;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* CreateContentPage Constructor */
         new prc_createcontentpage(context ).execute(  AV37PageId, out  AV17result, out  AV69error) ;
         aP1_result=this.AV17result;
         aP2_error=this.AV69error;
      }

      public void gxep_createdynamicformpage( Guid aP0_FormId ,
                                              string aP1_PageName ,
                                              out SdtSDT_Page aP2_SDT_Page ,
                                              out SdtSDT_Error aP3_error )
      {
         this.AV77FormId = aP0_FormId;
         this.AV43PageName = aP1_PageName;
         AV38SDT_Page = new SdtSDT_Page(context);
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* CreateDynamicFormPage Constructor */
         new prc_createdynamicformpage(context ).execute(  AV77FormId,  AV43PageName, out  AV38SDT_Page, out  AV69error) ;
         aP2_SDT_Page=this.AV38SDT_Page;
         aP3_error=this.AV69error;
      }

      public void gxep_savepage( Guid aP0_PageId ,
                                 string aP1_PageJsonContent ,
                                 string aP2_PageGJSHtml ,
                                 string aP3_PageGJSJson ,
                                 SdtSDT_Page aP4_SDT_Page ,
                                 out string aP5_result )
      {
         this.AV37PageId = aP0_PageId;
         this.AV41PageJsonContent = aP1_PageJsonContent;
         this.AV39PageGJSHtml = aP2_PageGJSHtml;
         this.AV40PageGJSJson = aP3_PageGJSJson;
         this.AV38SDT_Page = aP4_SDT_Page;
         initialize();
         /* SavePage Constructor */
         new prc_savepage(context ).execute(  AV37PageId,  AV41PageJsonContent,  AV39PageGJSHtml,  AV40PageGJSJson,  AV38SDT_Page, ref  AV17result) ;
         aP5_result=this.AV17result;
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
         this.AV37PageId = aP0_PageId;
         this.AV43PageName = aP1_PageName;
         this.AV41PageJsonContent = aP2_PageJsonContent;
         this.AV39PageGJSHtml = aP3_PageGJSHtml;
         this.AV40PageGJSJson = aP4_PageGJSJson;
         this.AV48PageIsPublished = aP5_PageIsPublished;
         this.AV159IsNotifyResidents = aP6_IsNotifyResidents;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* UpdatePage Constructor */
         new prc_updatepage(context ).execute( ref  AV37PageId, ref  AV43PageName, ref  AV41PageJsonContent, ref  AV39PageGJSHtml, ref  AV40PageGJSJson, ref  AV48PageIsPublished, ref  AV159IsNotifyResidents, out  AV17result, out  AV69error) ;
         aP7_result=this.AV17result;
         aP8_error=this.AV69error;
      }

      public void gxep_updatepagebatch( GXBaseCollection<SdtSDT_PublishPage> aP0_PagesList ,
                                        bool aP1_IsNotifyResidents ,
                                        out string aP2_result ,
                                        out SdtSDT_Error aP3_error )
      {
         this.AV70PagesList = aP0_PagesList;
         this.AV159IsNotifyResidents = aP1_IsNotifyResidents;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* UpdatePageBatch Constructor */
         new prc_updatepagebatch(context ).execute( ref  AV70PagesList, ref  AV159IsNotifyResidents, out  AV17result, out  AV69error) ;
         aP2_result=this.AV17result;
         aP3_error=this.AV69error;
      }

      public void gxep_addpagecildren( Guid aP0_ParentPageId ,
                                       Guid aP1_ChildPageId ,
                                       out string aP2_result ,
                                       out SdtSDT_Error aP3_error )
      {
         this.AV160ParentPageId = aP0_ParentPageId;
         this.AV161ChildPageId = aP1_ChildPageId;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* AddPageCildren Constructor */
         new prc_addpagechildren(context ).execute(  AV160ParentPageId,  AV161ChildPageId, out  AV17result, out  AV69error) ;
         aP2_result=this.AV17result;
         aP3_error=this.AV69error;
      }

      public void gxep_productserviceapi( Guid aP0_ProductServiceId ,
                                          out SdtSDT_ProductService aP1_SDT_ProductService ,
                                          out SdtSDT_Error aP2_error )
      {
         this.AV49ProductServiceId = aP0_ProductServiceId;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* ProductServiceAPI Constructor */
         new prc_productserviceapi(context ).execute(  AV49ProductServiceId, out  AV50SDT_ProductService, out  AV69error) ;
         aP1_SDT_ProductService=this.AV50SDT_ProductService;
         aP2_error=this.AV69error;
      }

      public void gxep_getservices( out GXBaseCollection<SdtSDT_ProductService> aP0_SDT_ProductServiceCollection ,
                                    out SdtSDT_Error aP1_error )
      {
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* GetServices Constructor */
         new prc_getservices(context ).execute(  AV78SDT_ProductServiceCollection, out  AV69error) ;
         aP0_SDT_ProductServiceCollection=this.AV78SDT_ProductServiceCollection;
         aP1_error=this.AV69error;
      }

      public void gxep_getlocationtheme( Guid aP0_locationId ,
                                         Guid aP1_organisationId ,
                                         out SdtSDT_Theme aP2_SDT_Theme )
      {
         this.AV12locationId = aP0_locationId;
         this.AV16organisationId = aP1_organisationId;
         initialize();
         /* GetLocationTheme Constructor */
         new prc_getlocationtheme(context ).execute( ref  AV12locationId, ref  AV16organisationId, out  AV162SDT_Theme) ;
         aP2_SDT_Theme=this.AV162SDT_Theme;
      }

      public void gxep_toolboxgetlocationtheme( out SdtSDT_LocationTheme aP0_SDT_LocationTheme ,
                                                out SdtSDT_Error aP1_error )
      {
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* ToolboxGetLocationTheme Constructor */
         new prc_toolboxgetlocationtheme(context ).execute( out  AV62SDT_LocationTheme, out  AV69error) ;
         aP0_SDT_LocationTheme=this.AV62SDT_LocationTheme;
         aP1_error=this.AV69error;
      }

      public void gxep_getthemes( out GXBaseCollection<SdtSDT_Theme> aP0_SDT_ThemeCollection ,
                                  out SdtSDT_Error aP1_error )
      {
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* GetThemes Constructor */
         new prc_getthemes(context ).execute( out  AV163SDT_ThemeCollection, out  AV69error) ;
         aP0_SDT_ThemeCollection=this.AV163SDT_ThemeCollection;
         aP1_error=this.AV69error;
      }

      public void gxep_getatrashitems( out GXBaseCollection<SdtSDT_TrashItem> aP0_TrashItems ,
                                       out SdtSDT_Error aP1_error )
      {
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* GetATrashItems Constructor */
         new prc_gettrashitems(context ).execute( out  AV140TrashItems, out  AV69error) ;
         aP0_TrashItems=this.AV140TrashItems;
         aP1_error=this.AV69error;
      }

      public void gxep_restoretrash( string aP0_Type ,
                                     Guid aP1_TrashId ,
                                     out SdtSDT_Error aP2_error )
      {
         this.AV142Type = aP0_Type;
         this.AV141TrashId = aP1_TrashId;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* RestoreTrash Constructor */
         new prc_restoretrash(context ).execute(  AV142Type,  AV141TrashId, out  AV69error) ;
         aP2_error=this.AV69error;
      }

      public void gxep_deletetrash( string aP0_Type ,
                                    Guid aP1_TrashId ,
                                    out SdtSDT_Error aP2_error )
      {
         this.AV142Type = aP0_Type;
         this.AV141TrashId = aP1_TrashId;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* DeleteTrash Constructor */
         new prc_deletetrash(context ).execute(  AV142Type,  AV141TrashId, out  AV69error) ;
         aP2_error=this.AV69error;
      }

      public void gxep_getappversions( out GXBaseCollection<SdtSDT_AppVersion> aP0_AppVersions ,
                                       out SdtSDT_Error aP1_error )
      {
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* GetAppVersions Constructor */
         new prc_getappversions(context ).execute( ref  AV96AppVersions, ref  AV69error) ;
         aP0_AppVersions=this.AV96AppVersions;
         aP1_error=this.AV69error;
      }

      public void gxep_getappversion( out SdtSDT_AppVersion aP0_AppVersion ,
                                      out SdtSDT_Error aP1_error )
      {
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* Execute user event: Getappversion.Before */
         E26012 ();
         if ( returnInSub )
         {
            if ( this.AV98AppVersion == null )
            {
               this.AV98AppVersion=new SdtSDT_AppVersion();
            }
            aP0_AppVersion=this.AV98AppVersion;
            if ( this.AV69error == null )
            {
               this.AV69error=new SdtSDT_Error();
            }
            aP1_error=this.AV69error;
            return;
         }
         /* GetAppVersion Constructor */
         new prc_getappversion(context ).execute( out  AV98AppVersion, out  AV69error,  AV156EmptyGUID) ;
         aP0_AppVersion=this.AV98AppVersion;
         aP1_error=this.AV69error;
      }

      public void gxep_createappversion( string aP0_AppVersionName ,
                                         bool aP1_IsActive ,
                                         out SdtSDT_AppVersion aP2_AppVersion ,
                                         out SdtSDT_Error aP3_error )
      {
         this.AV99AppVersionName = aP0_AppVersionName;
         this.AV100IsActive = aP1_IsActive;
         AV98AppVersion = new SdtSDT_AppVersion(context);
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* Execute user event: Createappversion.Before */
         E24012 ();
         if ( returnInSub )
         {
            if ( this.AV98AppVersion == null )
            {
               this.AV98AppVersion=new SdtSDT_AppVersion();
            }
            aP2_AppVersion=this.AV98AppVersion;
            if ( this.AV69error == null )
            {
               this.AV69error=new SdtSDT_Error();
            }
            aP3_error=this.AV69error;
            return;
         }
         /* CreateAppVersion Constructor */
         new prc_createappversion(context ).execute(  AV99AppVersionName,  AV100IsActive, out  AV98AppVersion, out  AV69error,  AV156EmptyGUID,  AV156EmptyGUID) ;
         aP2_AppVersion=this.AV98AppVersion;
         aP3_error=this.AV69error;
      }

      public void gxep_copyappversion( Guid aP0_AppVersionId ,
                                       string aP1_AppVersionName ,
                                       out SdtSDT_AppVersion aP2_AppVersion ,
                                       out SdtSDT_Error aP3_error )
      {
         this.AV92AppVersionId = aP0_AppVersionId;
         this.AV99AppVersionName = aP1_AppVersionName;
         AV98AppVersion = new SdtSDT_AppVersion(context);
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* CopyAppVersion Constructor */
         new prc_copyappversion(context ).execute(  AV92AppVersionId,  AV99AppVersionName, out  AV98AppVersion, out  AV69error) ;
         aP2_AppVersion=this.AV98AppVersion;
         aP3_error=this.AV69error;
      }

      public void gxep_updateappversion( Guid aP0_AppVersionId ,
                                         string aP1_AppVersionName ,
                                         out SdtSDT_AppVersion aP2_AppVersion ,
                                         out SdtSDT_Error aP3_error )
      {
         this.AV92AppVersionId = aP0_AppVersionId;
         this.AV99AppVersionName = aP1_AppVersionName;
         AV98AppVersion = new SdtSDT_AppVersion(context);
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* UpdateAppVersion Constructor */
         new prc_updateappversion(context ).execute(  AV92AppVersionId,  AV99AppVersionName, out  AV98AppVersion, out  AV69error) ;
         aP2_AppVersion=this.AV98AppVersion;
         aP3_error=this.AV69error;
      }

      public void gxep_updateappversiontheme( Guid aP0_AppVersionId ,
                                              Guid aP1_ThemeId ,
                                              out SdtSDT_Theme aP2_SDT_Theme ,
                                              out SdtSDT_Error aP3_error )
      {
         this.AV92AppVersionId = aP0_AppVersionId;
         this.AV164ThemeId = aP1_ThemeId;
         AV162SDT_Theme = new SdtSDT_Theme(context);
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* UpdateAppVersionTheme Constructor */
         new prc_updateappversiontheme(context ).execute(  AV92AppVersionId,  AV164ThemeId, out  AV162SDT_Theme, out  AV69error) ;
         aP2_SDT_Theme=this.AV162SDT_Theme;
         aP3_error=this.AV69error;
      }

      public void gxep_activateappversion( Guid aP0_AppVersionId ,
                                           out SdtSDT_AppVersion aP1_AppVersion ,
                                           out SdtSDT_Error aP2_error )
      {
         this.AV92AppVersionId = aP0_AppVersionId;
         AV98AppVersion = new SdtSDT_AppVersion(context);
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* Execute user event: Activateappversion.Before */
         E25012 ();
         if ( returnInSub )
         {
            if ( this.AV98AppVersion == null )
            {
               this.AV98AppVersion=new SdtSDT_AppVersion();
            }
            aP1_AppVersion=this.AV98AppVersion;
            if ( this.AV69error == null )
            {
               this.AV69error=new SdtSDT_Error();
            }
            aP2_error=this.AV69error;
            return;
         }
         /* ActivateAppVersion Constructor */
         new prc_activateappversion(context ).execute(  AV92AppVersionId, out  AV98AppVersion, out  AV69error,  AV156EmptyGUID) ;
         aP1_AppVersion=this.AV98AppVersion;
         aP2_error=this.AV69error;
      }

      public void gxep_deleteappversion( Guid aP0_AppVersionId ,
                                         out string aP1_result ,
                                         out SdtSDT_Error aP2_error )
      {
         this.AV92AppVersionId = aP0_AppVersionId;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* DeleteAppVersion Constructor */
         new prc_deleteappversion(context ).execute(  AV92AppVersionId, out  AV17result, out  AV69error) ;
         aP1_result=this.AV17result;
         aP2_error=this.AV69error;
      }

      public void gxep_savepagev2( Guid aP0_AppVersionId ,
                                   Guid aP1_PageId ,
                                   string aP2_PageName ,
                                   string aP3_PageType ,
                                   string aP4_PageStructure ,
                                   out SdtSDT_Error aP5_error )
      {
         this.AV92AppVersionId = aP0_AppVersionId;
         this.AV37PageId = aP1_PageId;
         this.AV43PageName = aP2_PageName;
         this.AV165PageType = aP3_PageType;
         this.AV166PageStructure = aP4_PageStructure;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* SavePageV2 Constructor */
         new prc_savepagev2(context ).execute(  AV92AppVersionId,  AV37PageId,  AV43PageName,  AV165PageType,  AV166PageStructure, out  AV69error) ;
         aP5_error=this.AV69error;
      }

      public void gxep_savepagethumbnail( Guid aP0_PageId ,
                                          string aP1_PageThumbnailData ,
                                          out SdtSDT_Error aP2_error )
      {
         this.AV37PageId = aP0_PageId;
         this.AV139PageThumbnailData = aP1_PageThumbnailData;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* SavePageThumbnail Constructor */
         new prc_savepagethumbnail(context ).execute(  AV37PageId,  AV139PageThumbnailData, out  AV69error) ;
         aP2_error=this.AV69error;
      }

      public void gxep_publishappversion( Guid aP0_AppVersionId ,
                                          bool aP1_Notify ,
                                          out SdtSDT_Error aP2_error )
      {
         this.AV92AppVersionId = aP0_AppVersionId;
         this.AV130Notify = aP1_Notify;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* PublishAppVersion Constructor */
         new prc_publishappversion(context ).execute(  AV92AppVersionId,  AV130Notify, out  AV69error) ;
         aP2_error=this.AV69error;
      }

      public void gxep_createmenupage( Guid aP0_AppVersionId ,
                                       string aP1_PageName ,
                                       out SdtSDT_AppVersion_PagesItem aP2_MenuPage ,
                                       out SdtSDT_Error aP3_error )
      {
         this.AV92AppVersionId = aP0_AppVersionId;
         this.AV43PageName = aP1_PageName;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* CreateMenuPage Constructor */
         new prc_createmenupage(context ).execute(  AV92AppVersionId,  AV43PageName, out  AV97MenuPage, out  AV69error) ;
         aP2_MenuPage=this.AV97MenuPage;
         aP3_error=this.AV69error;
      }

      public void gxep_createinfopage( Guid aP0_AppVersionId ,
                                       string aP1_PageName ,
                                       out SdtSDT_AppVersion_PagesItem aP2_MenuPage ,
                                       out SdtSDT_Error aP3_error )
      {
         this.AV92AppVersionId = aP0_AppVersionId;
         this.AV43PageName = aP1_PageName;
         AV97MenuPage = new SdtSDT_AppVersion_PagesItem(context);
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* CreateInfoPage Constructor */
         new prc_createinfopage(context ).execute(  AV92AppVersionId,  AV43PageName, out  AV97MenuPage, out  AV69error) ;
         aP2_MenuPage=this.AV97MenuPage;
         aP3_error=this.AV69error;
      }

      public void gxep_createlinkpage( Guid aP0_AppVersionId ,
                                       string aP1_PageName ,
                                       string aP2_Url ,
                                       short aP3_WWPFormId ,
                                       string aP4_WWPFormReferenceName ,
                                       out SdtSDT_AppVersion_PagesItem aP5_MenuPage ,
                                       out SdtSDT_Error aP6_error )
      {
         this.AV92AppVersionId = aP0_AppVersionId;
         this.AV43PageName = aP1_PageName;
         this.AV137Url = aP2_Url;
         this.AV138WWPFormId = aP3_WWPFormId;
         this.AV167WWPFormReferenceName = aP4_WWPFormReferenceName;
         AV97MenuPage = new SdtSDT_AppVersion_PagesItem(context);
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* CreateLinkPage Constructor */
         new prc_createlinkpage(context ).execute(  AV92AppVersionId,  AV43PageName,  AV137Url,  AV138WWPFormId,  AV167WWPFormReferenceName, out  AV97MenuPage, out  AV69error) ;
         aP5_MenuPage=this.AV97MenuPage;
         aP6_error=this.AV69error;
      }

      public void gxep_createservicepage( Guid aP0_AppVersionId ,
                                          Guid aP1_ProductServiceId ,
                                          out SdtSDT_AppVersion_PagesItem aP2_ContentPage ,
                                          out SdtSDT_Error aP3_error )
      {
         this.AV92AppVersionId = aP0_AppVersionId;
         this.AV49ProductServiceId = aP1_ProductServiceId;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* CreateServicePage Constructor */
         new prc_createservicepage(context ).execute(  AV92AppVersionId,  AV49ProductServiceId, out  AV95ContentPage, out  AV69error) ;
         aP2_ContentPage=this.AV95ContentPage;
         aP3_error=this.AV69error;
      }

      public void gxep_deletepagev2( Guid aP0_AppVersionId ,
                                     Guid aP1_PageId ,
                                     out SdtSDT_AppVersion aP2_AppVersion ,
                                     out SdtSDT_Error aP3_error )
      {
         this.AV92AppVersionId = aP0_AppVersionId;
         this.AV37PageId = aP1_PageId;
         AV98AppVersion = new SdtSDT_AppVersion(context);
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* DeletePageV2 Constructor */
         new prc_deletepage(context ).execute(  AV92AppVersionId,  AV37PageId, out  AV98AppVersion, out  AV69error) ;
         aP2_AppVersion=this.AV98AppVersion;
         aP3_error=this.AV69error;
      }

      public void gxep_updatepagetitle( Guid aP0_AppVersionId ,
                                        Guid aP1_PageId ,
                                        string aP2_PageName ,
                                        out SdtSDT_Error aP3_error )
      {
         this.AV92AppVersionId = aP0_AppVersionId;
         this.AV37PageId = aP1_PageId;
         this.AV43PageName = aP2_PageName;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* UpdatePageTitle Constructor */
         new prc_updatepagetitle(context ).execute(  AV92AppVersionId,  AV37PageId,  AV43PageName, out  AV69error) ;
         aP3_error=this.AV69error;
      }

      public void gxep_updateproductserviceapi( Guid aP0_ProductServiceId ,
                                                string aP1_ProductServiceDescription ,
                                                string aP2_ProductServiceImageBase64 ,
                                                out SdtSDT_Error aP3_error )
      {
         this.AV49ProductServiceId = aP0_ProductServiceId;
         this.AV103ProductServiceDescription = aP1_ProductServiceDescription;
         this.AV105ProductServiceImageBase64 = aP2_ProductServiceImageBase64;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* UpdateProductServiceAPI Constructor */
         new prc_updateproductserviceapi(context ).execute(  AV49ProductServiceId,  AV103ProductServiceDescription,  AV105ProductServiceImageBase64, out  AV69error) ;
         aP3_error=this.AV69error;
      }

      public void gxep_deleteproductserviceimageapi( Guid aP0_ProductServiceId ,
                                                     out SdtSDT_Error aP1_error )
      {
         this.AV49ProductServiceId = aP0_ProductServiceId;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* DeleteProductServiceImageAPI Constructor */
         new prc_deleteproductserviceimageapi(context ).execute(  AV49ProductServiceId, out  AV69error) ;
         aP1_error=this.AV69error;
      }

      public void gxep_updatelocationapi__get( out SdtTrn_Location aP0_BC_Trn_Location ,
                                               out SdtSDT_Error aP1_error )
      {
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* UpdateLocationAPI__get Constructor */
         new prc_getlocationapi(context ).execute( out  AV129BC_Trn_Location, out  AV69error) ;
         aP0_BC_Trn_Location=this.AV129BC_Trn_Location;
         aP1_error=this.AV69error;
      }

      public void gxep_updatelocationapi__post( string aP0_LocationDescription ,
                                                string aP1_LocationImageBase64 ,
                                                string aP2_ReceptionDescription ,
                                                string aP3_ReceptionImageBase64 ,
                                                out SdtSDT_Error aP4_error )
      {
         this.AV123LocationDescription = aP0_LocationDescription;
         this.AV124LocationImageBase64 = aP1_LocationImageBase64;
         this.AV127ReceptionDescription = aP2_ReceptionDescription;
         this.AV128ReceptionImageBase64 = aP3_ReceptionImageBase64;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* UpdateLocationAPI__post Constructor */
         new prc_updatelocationapi(context ).execute(  AV123LocationDescription,  AV124LocationImageBase64,  AV127ReceptionDescription,  AV128ReceptionImageBase64, out  AV69error) ;
         aP4_error=this.AV69error;
      }

      public void gxep_getmemocategories( out GXBaseCollection<SdtSDT_MemoCategory> aP0_SDT_MemoCategories )
      {
         initialize();
         /* GetMemoCategories Constructor */
         new prc_getmemocategories(context ).execute( out  AV121SDT_MemoCategories) ;
         aP0_SDT_MemoCategories=this.AV121SDT_MemoCategories;
      }

      public void gxep_getmemocategory( Guid aP0_MemoCategoryId ,
                                        out SdtSDT_MemoCategory aP1_SDT_MemoCategory )
      {
         this.AV107MemoCategoryId = aP0_MemoCategoryId;
         initialize();
         /* GetMemoCategory Constructor */
         new prc_getmemocategory(context ).execute(  AV107MemoCategoryId, out  AV122SDT_MemoCategory) ;
         aP1_SDT_MemoCategory=this.AV122SDT_MemoCategory;
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
         this.AV55ResidentId = aP0_ResidentId;
         this.AV116MemoTitle = aP1_MemoTitle;
         this.AV108MemoDescription = aP2_MemoDescription;
         this.AV113MemoImage = aP3_MemoImage;
         this.AV109MemoDocument = aP4_MemoDocument;
         this.AV115MemoStartDateTime = aP5_MemoStartDateTime;
         this.AV111MemoEndDateTime = aP6_MemoEndDateTime;
         this.AV110MemoDuration = aP7_MemoDuration;
         this.AV114MemoRemoveDate = aP8_MemoRemoveDate;
         this.AV168MemoBgColorCode = aP9_MemoBgColorCode;
         this.AV169MemoForm = aP10_MemoForm;
         this.AV170MemoType = aP11_MemoType;
         this.AV171MemoName = aP12_MemoName;
         this.AV172MemoLeftOffset = aP13_MemoLeftOffset;
         this.AV173MemoTopOffset = aP14_MemoTopOffset;
         this.AV174MemoTitleAngle = aP15_MemoTitleAngle;
         this.AV175MemoTitleScale = aP16_MemoTitleScale;
         this.AV155MemoTextFontName = aP17_MemoTextFontName;
         this.AV153MemoTextAlignment = aP18_MemoTextAlignment;
         this.AV150MemoIsBold = aP19_MemoIsBold;
         this.AV152MemoIsItalic = aP20_MemoIsItalic;
         this.AV151MemoIsCapitalized = aP21_MemoIsCapitalized;
         this.AV154MemoTextColor = aP22_MemoTextColor;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* CreateMemo Constructor */
         new prc_creatememo(context ).execute(  AV55ResidentId,  AV116MemoTitle,  AV108MemoDescription,  AV113MemoImage,  AV109MemoDocument,  AV115MemoStartDateTime,  AV111MemoEndDateTime,  AV110MemoDuration,  AV114MemoRemoveDate,  AV168MemoBgColorCode,  AV169MemoForm,  AV170MemoType,  AV171MemoName,  AV172MemoLeftOffset,  AV173MemoTopOffset,  AV174MemoTitleAngle,  AV175MemoTitleScale,  AV155MemoTextFontName,  AV153MemoTextAlignment,  AV150MemoIsBold,  AV152MemoIsItalic,  AV151MemoIsCapitalized,  AV154MemoTextColor, out  AV69error) ;
         aP23_error=this.AV69error;
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
         this.AV112MemoId = aP0_MemoId;
         this.AV55ResidentId = aP1_ResidentId;
         this.AV116MemoTitle = aP2_MemoTitle;
         this.AV108MemoDescription = aP3_MemoDescription;
         this.AV113MemoImage = aP4_MemoImage;
         this.AV109MemoDocument = aP5_MemoDocument;
         this.AV115MemoStartDateTime = aP6_MemoStartDateTime;
         this.AV111MemoEndDateTime = aP7_MemoEndDateTime;
         this.AV110MemoDuration = aP8_MemoDuration;
         this.AV114MemoRemoveDate = aP9_MemoRemoveDate;
         this.AV168MemoBgColorCode = aP10_MemoBgColorCode;
         this.AV169MemoForm = aP11_MemoForm;
         this.AV170MemoType = aP12_MemoType;
         this.AV171MemoName = aP13_MemoName;
         this.AV172MemoLeftOffset = aP14_MemoLeftOffset;
         this.AV173MemoTopOffset = aP15_MemoTopOffset;
         this.AV174MemoTitleAngle = aP16_MemoTitleAngle;
         this.AV175MemoTitleScale = aP17_MemoTitleScale;
         this.AV155MemoTextFontName = aP18_MemoTextFontName;
         this.AV153MemoTextAlignment = aP19_MemoTextAlignment;
         this.AV150MemoIsBold = aP20_MemoIsBold;
         this.AV152MemoIsItalic = aP21_MemoIsItalic;
         this.AV151MemoIsCapitalized = aP22_MemoIsCapitalized;
         this.AV154MemoTextColor = aP23_MemoTextColor;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* updateMemo Constructor */
         new prc_updatememo(context ).execute(  AV112MemoId,  AV55ResidentId,  AV116MemoTitle,  AV108MemoDescription,  AV113MemoImage,  AV109MemoDocument,  AV115MemoStartDateTime,  AV111MemoEndDateTime,  AV110MemoDuration,  AV114MemoRemoveDate,  AV168MemoBgColorCode,  AV169MemoForm,  AV170MemoType,  AV171MemoName,  AV172MemoLeftOffset,  AV173MemoTopOffset,  AV174MemoTitleAngle,  AV175MemoTitleScale,  AV155MemoTextFontName,  AV153MemoTextAlignment,  AV150MemoIsBold,  AV152MemoIsItalic,  AV151MemoIsCapitalized,  AV154MemoTextColor, out  AV69error) ;
         aP24_error=this.AV69error;
      }

      public void gxep_getmemo( Guid aP0_MemoId ,
                                out SdtSDT_Memo aP1_SDT_Memo )
      {
         this.AV112MemoId = aP0_MemoId;
         initialize();
         /* GetMemo Constructor */
         new prc_getmemo(context ).execute(  AV112MemoId, out  AV120SDT_Memo) ;
         aP1_SDT_Memo=this.AV120SDT_Memo;
      }

      public void gxep_getresidentmemos( string aP0_ResidentId ,
                                         short aP1_PageSize ,
                                         short aP2_PageNumber ,
                                         out SdtSDT_ApiListResponse aP3_SDT_ApiListResponse )
      {
         this.AV55ResidentId = aP0_ResidentId;
         this.AV86PageSize = aP1_PageSize;
         this.AV85PageNumber = aP2_PageNumber;
         AV87SDT_ApiListResponse = new SdtSDT_ApiListResponse(context);
         initialize();
         /* GetResidentMemos Constructor */
         new prc_getresidentmemos(context ).execute(  AV55ResidentId,  AV86PageSize,  AV85PageNumber, out  AV17result) ;
         /* Execute user event: Getresidentmemos.After */
         E23012 ();
         if ( returnInSub )
         {
            aP3_SDT_ApiListResponse=this.AV87SDT_ApiListResponse;
            return;
         }
         aP3_SDT_ApiListResponse=this.AV87SDT_ApiListResponse;
      }

      public void gxep_getlocationmemos( string aP0_ResidentId ,
                                         short aP1_PageSize ,
                                         short aP2_PageNumber ,
                                         out SdtSDT_ApiListResponse aP3_SDT_ApiListResponse )
      {
         this.AV55ResidentId = aP0_ResidentId;
         this.AV86PageSize = aP1_PageSize;
         this.AV85PageNumber = aP2_PageNumber;
         AV87SDT_ApiListResponse = new SdtSDT_ApiListResponse(context);
         initialize();
         /* GetLocationMemos Constructor */
         new prc_getlocationmemos(context ).execute(  AV55ResidentId,  AV86PageSize,  AV85PageNumber, out  AV17result) ;
         /* Execute user event: Getlocationmemos.After */
         E22012 ();
         if ( returnInSub )
         {
            aP3_SDT_ApiListResponse=this.AV87SDT_ApiListResponse;
            return;
         }
         aP3_SDT_ApiListResponse=this.AV87SDT_ApiListResponse;
      }

      public void gxep_deletememo( Guid aP0_MemoId ,
                                   out SdtSDT_Error aP1_error )
      {
         this.AV112MemoId = aP0_MemoId;
         AV69error = new SdtSDT_Error(context);
         initialize();
         /* DeleteMemo Constructor */
         new prc_deletememo(context ).execute(  AV112MemoId, out  AV69error) ;
         aP1_error=this.AV69error;
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         AV17result = "";
         AV20SDT_LoginResidentResponse = new SdtSDT_LoginResidentResponse(context);
         AV21loginResult = new SdtSDT_LoginResidentResponse(context);
         AV75SDT_ChangeYourPassword = new SdtSDT_ChangeYourPassword(context);
         AV76ChangeYourPasswordResult = new SdtSDT_ChangeYourPassword(context);
         AV79SDT_RecoverPasswordStep1 = new SdtSDT_RecoverPasswordStep1(context);
         AV80RecoverPasswordStep1Result = new SdtSDT_RecoverPasswordStep1(context);
         AV22SDT_Resident = new SdtSDT_Resident(context);
         AV23SDT_Organisation = new SdtSDT_Organisation(context);
         AV19SDT_Location = new SdtSDT_Location(context);
         AV42SDT_AgendaLocation = new GXBaseCollection<SdtSDT_AgendaLocation>( context, "SDT_AgendaLocation", "Comforta_version2");
         AV87SDT_ApiListResponse = new SdtSDT_ApiListResponse(context);
         AV156EmptyGUID = Guid.Empty;
         AV33BC_Trn_Media = new SdtTrn_Media(context);
         AV69error = new SdtSDT_Error(context);
         AV64SDT_MediaCollection = new GXBaseCollection<SdtSDT_Media>( context, "SDT_Media", "Comforta_version2");
         AV27SDT_PageCollection = new GXBaseCollection<SdtSDT_Page>( context, "SDT_Page", "Comforta_version2");
         AV52SDT_MobilePageCollection = new GXBaseCollection<SdtSDT_MobilePage>( context, "SDT_MobilePage", "Comforta_version2");
         AV136SDT_InfoPage = new SdtSDT_InfoPage(context);
         AV158SDT_MobilePage = new SdtSDT_MobilePage(context);
         AV51SDT_ContentPageCollection = new GXBaseCollection<SdtSDT_ContentPage>( context, "SDT_ContentPage", "Comforta_version2");
         AV47SDT_PageStructureCollection = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2");
         AV50SDT_ProductService = new SdtSDT_ProductService(context);
         AV78SDT_ProductServiceCollection = new GXBaseCollection<SdtSDT_ProductService>( context, "SDT_ProductService", "Comforta_version2");
         AV162SDT_Theme = new SdtSDT_Theme(context);
         AV62SDT_LocationTheme = new SdtSDT_LocationTheme(context);
         AV163SDT_ThemeCollection = new GXBaseCollection<SdtSDT_Theme>( context, "SDT_Theme", "Comforta_version2");
         AV140TrashItems = new GXBaseCollection<SdtSDT_TrashItem>( context, "SDT_TrashItem", "Comforta_version2");
         AV96AppVersions = new GXBaseCollection<SdtSDT_AppVersion>( context, "SDT_AppVersion", "Comforta_version2");
         AV98AppVersion = new SdtSDT_AppVersion(context);
         AV97MenuPage = new SdtSDT_AppVersion_PagesItem(context);
         AV95ContentPage = new SdtSDT_AppVersion_PagesItem(context);
         AV129BC_Trn_Location = new SdtTrn_Location(context);
         AV121SDT_MemoCategories = new GXBaseCollection<SdtSDT_MemoCategory>( context, "SDT_MemoCategory", "Comforta_version2");
         AV122SDT_MemoCategory = new SdtSDT_MemoCategory(context);
         AV120SDT_Memo = new SdtSDT_Memo(context);
         /* GeneXus formulas. */
      }

      protected short AV86PageSize ;
      protected short AV85PageNumber ;
      protected short AV11DeviceType ;
      protected short AV138WWPFormId ;
      protected int AV34MediaSize ;
      protected decimal AV110MemoDuration ;
      protected decimal AV172MemoLeftOffset ;
      protected decimal AV173MemoTopOffset ;
      protected decimal AV174MemoTitleAngle ;
      protected decimal AV175MemoTitleScale ;
      protected string Gx_restmethod ;
      protected string AV10DeviceToken ;
      protected string AV9DeviceID ;
      protected string AV131Language ;
      protected string AV35MediaType ;
      protected string AV169MemoForm ;
      protected string AV153MemoTextAlignment ;
      protected DateTime AV115MemoStartDateTime ;
      protected DateTime AV111MemoEndDateTime ;
      protected DateTime AV114MemoRemoveDate ;
      protected bool returnInSub ;
      protected bool AV48PageIsPublished ;
      protected bool AV159IsNotifyResidents ;
      protected bool AV100IsActive ;
      protected bool AV130Notify ;
      protected bool AV150MemoIsBold ;
      protected bool AV152MemoIsItalic ;
      protected bool AV151MemoIsCapitalized ;
      protected string AV17result ;
      protected string AV7secretKey ;
      protected string AV67refreshToken ;
      protected string AV65Base64Image ;
      protected string AV32MediaImageData ;
      protected string AV41PageJsonContent ;
      protected string AV39PageGJSHtml ;
      protected string AV40PageGJSJson ;
      protected string AV166PageStructure ;
      protected string AV139PageThumbnailData ;
      protected string AV103ProductServiceDescription ;
      protected string AV105ProductServiceImageBase64 ;
      protected string AV123LocationDescription ;
      protected string AV124LocationImageBase64 ;
      protected string AV127ReceptionDescription ;
      protected string AV128ReceptionImageBase64 ;
      protected string AV113MemoImage ;
      protected string AV71username ;
      protected string AV72password ;
      protected string AV8userId ;
      protected string AV74passwordNew ;
      protected string AV55ResidentId ;
      protected string AV14NotificationPlatform ;
      protected string AV15NotificationPlatformId ;
      protected string AV18title ;
      protected string AV13message ;
      protected string AV60StartDate ;
      protected string AV58EndDate ;
      protected string AV30MediaName ;
      protected string AV82LogoUrl ;
      protected string AV81ProfileImageUrl ;
      protected string AV43PageName ;
      protected string AV142Type ;
      protected string AV99AppVersionName ;
      protected string AV165PageType ;
      protected string AV137Url ;
      protected string AV167WWPFormReferenceName ;
      protected string AV116MemoTitle ;
      protected string AV108MemoDescription ;
      protected string AV109MemoDocument ;
      protected string AV168MemoBgColorCode ;
      protected string AV170MemoType ;
      protected string AV171MemoName ;
      protected string AV155MemoTextFontName ;
      protected string AV154MemoTextColor ;
      protected Guid AV156EmptyGUID ;
      protected Guid AV16organisationId ;
      protected Guid AV12locationId ;
      protected Guid AV157CroppedOriginalMediaId ;
      protected Guid AV29MediaId ;
      protected Guid AV37PageId ;
      protected Guid AV77FormId ;
      protected Guid AV160ParentPageId ;
      protected Guid AV161ChildPageId ;
      protected Guid AV49ProductServiceId ;
      protected Guid AV141TrashId ;
      protected Guid AV92AppVersionId ;
      protected Guid AV164ThemeId ;
      protected Guid AV107MemoCategoryId ;
      protected Guid AV112MemoId ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected SdtSDT_LoginResidentResponse AV20SDT_LoginResidentResponse ;
      protected SdtSDT_LoginResidentResponse AV21loginResult ;
      protected SdtSDT_ChangeYourPassword AV75SDT_ChangeYourPassword ;
      protected SdtSDT_ChangeYourPassword AV76ChangeYourPasswordResult ;
      protected SdtSDT_RecoverPasswordStep1 AV79SDT_RecoverPasswordStep1 ;
      protected SdtSDT_RecoverPasswordStep1 AV80RecoverPasswordStep1Result ;
      protected SdtSDT_Resident AV22SDT_Resident ;
      protected SdtSDT_Organisation AV23SDT_Organisation ;
      protected SdtSDT_Location AV19SDT_Location ;
      protected GXBaseCollection<SdtSDT_AgendaLocation> AV42SDT_AgendaLocation ;
      protected SdtSDT_ApiListResponse AV87SDT_ApiListResponse ;
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
      protected SdtTrn_Media AV33BC_Trn_Media ;
      protected SdtTrn_Media aP4_BC_Trn_Media ;
      protected SdtSDT_Error AV69error ;
      protected SdtSDT_Error aP5_error ;
      protected SdtTrn_Media aP5_BC_Trn_Media ;
      protected SdtSDT_Error aP6_error ;
      protected string aP1_result ;
      protected SdtSDT_Error aP2_error ;
      protected GXBaseCollection<SdtSDT_Media> AV64SDT_MediaCollection ;
      protected GXBaseCollection<SdtSDT_Media> aP0_SDT_MediaCollection ;
      protected SdtSDT_Error aP1_error ;
      protected GXBaseCollection<SdtSDT_Page> AV27SDT_PageCollection ;
      protected GXBaseCollection<SdtSDT_Page> aP0_SDT_PageCollection ;
      protected GXBaseCollection<SdtSDT_MobilePage> AV52SDT_MobilePageCollection ;
      protected GXBaseCollection<SdtSDT_MobilePage> aP3_SDT_MobilePageCollection ;
      protected SdtSDT_InfoPage AV136SDT_InfoPage ;
      protected SdtSDT_InfoPage aP3_SDT_InfoPage ;
      protected SdtSDT_MobilePage AV158SDT_MobilePage ;
      protected SdtSDT_MobilePage aP4_SDT_MobilePage ;
      protected SdtSDT_InfoPage aP4_SDT_InfoPage ;
      protected GXBaseCollection<SdtSDT_ContentPage> AV51SDT_ContentPageCollection ;
      protected GXBaseCollection<SdtSDT_ContentPage> aP2_SDT_ContentPageCollection ;
      protected SdtSDT_Page AV38SDT_Page ;
      protected SdtSDT_Page aP1_SDT_Page ;
      protected GXBaseCollection<SdtSDT_PageStructure> AV47SDT_PageStructureCollection ;
      protected GXBaseCollection<SdtSDT_PageStructure> aP0_SDT_PageStructureCollection ;
      protected SdtSDT_Error aP3_error ;
      protected SdtSDT_Page aP2_SDT_Page ;
      protected string aP5_result ;
      protected string aP7_result ;
      protected SdtSDT_Error aP8_error ;
      protected GXBaseCollection<SdtSDT_PublishPage> AV70PagesList ;
      protected SdtSDT_ProductService AV50SDT_ProductService ;
      protected SdtSDT_ProductService aP1_SDT_ProductService ;
      protected GXBaseCollection<SdtSDT_ProductService> AV78SDT_ProductServiceCollection ;
      protected GXBaseCollection<SdtSDT_ProductService> aP0_SDT_ProductServiceCollection ;
      protected SdtSDT_Theme AV162SDT_Theme ;
      protected SdtSDT_Theme aP2_SDT_Theme ;
      protected SdtSDT_LocationTheme AV62SDT_LocationTheme ;
      protected SdtSDT_LocationTheme aP0_SDT_LocationTheme ;
      protected GXBaseCollection<SdtSDT_Theme> AV163SDT_ThemeCollection ;
      protected GXBaseCollection<SdtSDT_Theme> aP0_SDT_ThemeCollection ;
      protected GXBaseCollection<SdtSDT_TrashItem> AV140TrashItems ;
      protected GXBaseCollection<SdtSDT_TrashItem> aP0_TrashItems ;
      protected GXBaseCollection<SdtSDT_AppVersion> AV96AppVersions ;
      protected GXBaseCollection<SdtSDT_AppVersion> aP0_AppVersions ;
      protected SdtSDT_AppVersion AV98AppVersion ;
      protected SdtSDT_AppVersion aP0_AppVersion ;
      protected SdtSDT_AppVersion aP2_AppVersion ;
      protected SdtSDT_AppVersion aP1_AppVersion ;
      protected SdtSDT_AppVersion_PagesItem AV97MenuPage ;
      protected SdtSDT_AppVersion_PagesItem aP2_MenuPage ;
      protected SdtSDT_AppVersion_PagesItem aP5_MenuPage ;
      protected SdtSDT_AppVersion_PagesItem AV95ContentPage ;
      protected SdtSDT_AppVersion_PagesItem aP2_ContentPage ;
      protected SdtTrn_Location AV129BC_Trn_Location ;
      protected SdtTrn_Location aP0_BC_Trn_Location ;
      protected SdtSDT_Error aP4_error ;
      protected GXBaseCollection<SdtSDT_MemoCategory> AV121SDT_MemoCategories ;
      protected GXBaseCollection<SdtSDT_MemoCategory> aP0_SDT_MemoCategories ;
      protected SdtSDT_MemoCategory AV122SDT_MemoCategory ;
      protected SdtSDT_MemoCategory aP1_SDT_MemoCategory ;
      protected SdtSDT_Error aP23_error ;
      protected SdtSDT_Error aP24_error ;
      protected SdtSDT_Memo AV120SDT_Memo ;
      protected SdtSDT_Memo aP1_SDT_Memo ;
   }

}
