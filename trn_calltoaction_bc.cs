using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class trn_calltoaction_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_calltoaction_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_calltoaction_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow1572( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1572( ) ;
         standaloneModal( ) ;
         AddRow1572( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E11152 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z339CallToActionId = A339CallToActionId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_150( )
      {
         BeforeValidate1572( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1572( ) ;
            }
            else
            {
               CheckExtendedTable1572( ) ;
               if ( AnyError == 0 )
               {
                  ZM1572( 16) ;
                  ZM1572( 17) ;
                  ZM1572( 18) ;
               }
               CloseExtendedTableCursors1572( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12152( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11152( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1572( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            Z367CallToActionUrl = A367CallToActionUrl;
            Z368CallToActionName = A368CallToActionName;
            Z340CallToActionType = A340CallToActionType;
            Z342CallToActionPhone = A342CallToActionPhone;
            Z499CallToActionPhoneCode = A499CallToActionPhoneCode;
            Z500CallToActionPhoneNumber = A500CallToActionPhoneNumber;
            Z341CallToActionEmail = A341CallToActionEmail;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
            Z58ProductServiceId = A58ProductServiceId;
            Z366LocationDynamicFormId = A366LocationDynamicFormId;
            Z219WWPFormLatestVersionNumber = A219WWPFormLatestVersionNumber;
         }
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z219WWPFormLatestVersionNumber = A219WWPFormLatestVersionNumber;
         }
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            Z219WWPFormLatestVersionNumber = A219WWPFormLatestVersionNumber;
         }
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            Z208WWPFormReferenceName = A208WWPFormReferenceName;
            Z209WWPFormTitle = A209WWPFormTitle;
            Z231WWPFormDate = A231WWPFormDate;
            Z232WWPFormIsWizard = A232WWPFormIsWizard;
            Z216WWPFormResume = A216WWPFormResume;
            Z234WWPFormInstantiated = A234WWPFormInstantiated;
            Z240WWPFormType = A240WWPFormType;
            Z241WWPFormSectionRefElements = A241WWPFormSectionRefElements;
            Z242WWPFormIsForDynamicValidations = A242WWPFormIsForDynamicValidations;
            Z219WWPFormLatestVersionNumber = A219WWPFormLatestVersionNumber;
         }
         if ( GX_JID == -15 )
         {
            Z339CallToActionId = A339CallToActionId;
            Z367CallToActionUrl = A367CallToActionUrl;
            Z368CallToActionName = A368CallToActionName;
            Z340CallToActionType = A340CallToActionType;
            Z342CallToActionPhone = A342CallToActionPhone;
            Z499CallToActionPhoneCode = A499CallToActionPhoneCode;
            Z500CallToActionPhoneNumber = A500CallToActionPhoneNumber;
            Z341CallToActionEmail = A341CallToActionEmail;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
            Z58ProductServiceId = A58ProductServiceId;
            Z366LocationDynamicFormId = A366LocationDynamicFormId;
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            Z208WWPFormReferenceName = A208WWPFormReferenceName;
            Z209WWPFormTitle = A209WWPFormTitle;
            Z231WWPFormDate = A231WWPFormDate;
            Z232WWPFormIsWizard = A232WWPFormIsWizard;
            Z216WWPFormResume = A216WWPFormResume;
            Z235WWPFormResumeMessage = A235WWPFormResumeMessage;
            Z233WWPFormValidations = A233WWPFormValidations;
            Z234WWPFormInstantiated = A234WWPFormInstantiated;
            Z240WWPFormType = A240WWPFormType;
            Z241WWPFormSectionRefElements = A241WWPFormSectionRefElements;
            Z242WWPFormIsForDynamicValidations = A242WWPFormIsForDynamicValidations;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A339CallToActionId) )
         {
            A339CallToActionId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1572( )
      {
         /* Using cursor BC00157 */
         pr_default.execute(5, new Object[] {A339CallToActionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound72 = 1;
            A367CallToActionUrl = BC00157_A367CallToActionUrl[0];
            A368CallToActionName = BC00157_A368CallToActionName[0];
            A340CallToActionType = BC00157_A340CallToActionType[0];
            A342CallToActionPhone = BC00157_A342CallToActionPhone[0];
            A499CallToActionPhoneCode = BC00157_A499CallToActionPhoneCode[0];
            A500CallToActionPhoneNumber = BC00157_A500CallToActionPhoneNumber[0];
            A341CallToActionEmail = BC00157_A341CallToActionEmail[0];
            A208WWPFormReferenceName = BC00157_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC00157_A209WWPFormTitle[0];
            A231WWPFormDate = BC00157_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC00157_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC00157_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC00157_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC00157_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC00157_A234WWPFormInstantiated[0];
            A240WWPFormType = BC00157_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC00157_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC00157_A242WWPFormIsForDynamicValidations[0];
            A11OrganisationId = BC00157_A11OrganisationId[0];
            A29LocationId = BC00157_A29LocationId[0];
            A58ProductServiceId = BC00157_A58ProductServiceId[0];
            A366LocationDynamicFormId = BC00157_A366LocationDynamicFormId[0];
            n366LocationDynamicFormId = BC00157_n366LocationDynamicFormId[0];
            A206WWPFormId = BC00157_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC00157_A207WWPFormVersionNumber[0];
            ZM1572( -15) ;
         }
         pr_default.close(5);
         OnLoadActions1572( ) ;
      }

      protected void OnLoadActions1572( )
      {
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         if ( StringUtil.StrCmp(A340CallToActionType, "Form") == 0 )
         {
            GXt_char2 = A367CallToActionUrl;
            new prc_getcalltoactionformurl(context ).execute( ref  A340CallToActionType, ref  A208WWPFormReferenceName, out  GXt_char2) ;
            A367CallToActionUrl = GXt_char2;
         }
      }

      protected void CheckExtendedTable1572( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00154 */
         pr_default.execute(2, new Object[] {A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Services", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC00155 */
         pr_default.execute(3, new Object[] {n366LocationDynamicFormId, A366LocationDynamicFormId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A366LocationDynamicFormId) || (Guid.Empty==A11OrganisationId) || (Guid.Empty==A29LocationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Location Dynamic Forms", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "LOCATIONID");
               AnyError = 1;
            }
         }
         A206WWPFormId = BC00155_A206WWPFormId[0];
         A207WWPFormVersionNumber = BC00155_A207WWPFormVersionNumber[0];
         pr_default.close(3);
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         /* Using cursor BC00156 */
         pr_default.execute(4, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A206WWPFormId) || (0==A207WWPFormVersionNumber) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Dynamic Form", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
               AnyError = 1;
            }
         }
         A208WWPFormReferenceName = BC00156_A208WWPFormReferenceName[0];
         A209WWPFormTitle = BC00156_A209WWPFormTitle[0];
         A231WWPFormDate = BC00156_A231WWPFormDate[0];
         A232WWPFormIsWizard = BC00156_A232WWPFormIsWizard[0];
         A216WWPFormResume = BC00156_A216WWPFormResume[0];
         A235WWPFormResumeMessage = BC00156_A235WWPFormResumeMessage[0];
         A233WWPFormValidations = BC00156_A233WWPFormValidations[0];
         A234WWPFormInstantiated = BC00156_A234WWPFormInstantiated[0];
         A240WWPFormType = BC00156_A240WWPFormType[0];
         A241WWPFormSectionRefElements = BC00156_A241WWPFormSectionRefElements[0];
         A242WWPFormIsForDynamicValidations = BC00156_A242WWPFormIsForDynamicValidations[0];
         pr_default.close(4);
         if ( StringUtil.StrCmp(A340CallToActionType, "Form") == 0 )
         {
            GXt_char2 = A367CallToActionUrl;
            new prc_getcalltoactionformurl(context ).execute( ref  A340CallToActionType, ref  A208WWPFormReferenceName, out  GXt_char2) ;
            A367CallToActionUrl = GXt_char2;
         }
         if ( ! ( ( StringUtil.StrCmp(A340CallToActionType, "Phone") == 0 ) || ( StringUtil.StrCmp(A340CallToActionType, "Email") == 0 ) || ( StringUtil.StrCmp(A340CallToActionType, "Form") == 0 ) || ( StringUtil.StrCmp(A340CallToActionType, "SiteUrl") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Call To Action Type", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A500CallToActionPhoneNumber)) && ! GxRegex.IsMatch(A500CallToActionPhoneNumber,context.GetMessage( "^\\d{9}$", "")) )
         {
            GX_msglist.addItem(context.GetMessage( "Phone should contain 9 digits", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A367CallToActionUrl,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Call To Action Url", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A341CallToActionEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "Invalid email pattern", ""), context.GetMessage( "Call To Action Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1572( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1572( )
      {
         /* Using cursor BC00158 */
         pr_default.execute(6, new Object[] {A339CallToActionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound72 = 1;
         }
         else
         {
            RcdFound72 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00153 */
         pr_default.execute(1, new Object[] {A339CallToActionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1572( 15) ;
            RcdFound72 = 1;
            A339CallToActionId = BC00153_A339CallToActionId[0];
            A367CallToActionUrl = BC00153_A367CallToActionUrl[0];
            A368CallToActionName = BC00153_A368CallToActionName[0];
            A340CallToActionType = BC00153_A340CallToActionType[0];
            A342CallToActionPhone = BC00153_A342CallToActionPhone[0];
            A499CallToActionPhoneCode = BC00153_A499CallToActionPhoneCode[0];
            A500CallToActionPhoneNumber = BC00153_A500CallToActionPhoneNumber[0];
            A341CallToActionEmail = BC00153_A341CallToActionEmail[0];
            A11OrganisationId = BC00153_A11OrganisationId[0];
            A29LocationId = BC00153_A29LocationId[0];
            A58ProductServiceId = BC00153_A58ProductServiceId[0];
            A366LocationDynamicFormId = BC00153_A366LocationDynamicFormId[0];
            n366LocationDynamicFormId = BC00153_n366LocationDynamicFormId[0];
            Z339CallToActionId = A339CallToActionId;
            sMode72 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1572( ) ;
            if ( AnyError == 1 )
            {
               RcdFound72 = 0;
               InitializeNonKey1572( ) ;
            }
            Gx_mode = sMode72;
         }
         else
         {
            RcdFound72 = 0;
            InitializeNonKey1572( ) ;
            sMode72 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode72;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1572( ) ;
         if ( RcdFound72 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_150( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1572( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00152 */
            pr_default.execute(0, new Object[] {A339CallToActionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_CallToAction"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z367CallToActionUrl, BC00152_A367CallToActionUrl[0]) != 0 ) || ( StringUtil.StrCmp(Z368CallToActionName, BC00152_A368CallToActionName[0]) != 0 ) || ( StringUtil.StrCmp(Z340CallToActionType, BC00152_A340CallToActionType[0]) != 0 ) || ( StringUtil.StrCmp(Z342CallToActionPhone, BC00152_A342CallToActionPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z499CallToActionPhoneCode, BC00152_A499CallToActionPhoneCode[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z500CallToActionPhoneNumber, BC00152_A500CallToActionPhoneNumber[0]) != 0 ) || ( StringUtil.StrCmp(Z341CallToActionEmail, BC00152_A341CallToActionEmail[0]) != 0 ) || ( Z11OrganisationId != BC00152_A11OrganisationId[0] ) || ( Z29LocationId != BC00152_A29LocationId[0] ) || ( Z58ProductServiceId != BC00152_A58ProductServiceId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z366LocationDynamicFormId != BC00152_A366LocationDynamicFormId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_CallToAction"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1572( )
      {
         BeforeValidate1572( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1572( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1572( 0) ;
            CheckOptimisticConcurrency1572( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1572( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1572( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00159 */
                     pr_default.execute(7, new Object[] {A339CallToActionId, A367CallToActionUrl, A368CallToActionName, A340CallToActionType, A342CallToActionPhone, A499CallToActionPhoneCode, A500CallToActionPhoneNumber, A341CallToActionEmail, A11OrganisationId, A29LocationId, A58ProductServiceId, n366LocationDynamicFormId, A366LocationDynamicFormId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_CallToAction");
                     if ( (pr_default.getStatus(7) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load1572( ) ;
            }
            EndLevel1572( ) ;
         }
         CloseExtendedTableCursors1572( ) ;
      }

      protected void Update1572( )
      {
         BeforeValidate1572( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1572( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1572( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1572( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1572( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001510 */
                     pr_default.execute(8, new Object[] {A367CallToActionUrl, A368CallToActionName, A340CallToActionType, A342CallToActionPhone, A499CallToActionPhoneCode, A500CallToActionPhoneNumber, A341CallToActionEmail, A11OrganisationId, A29LocationId, A58ProductServiceId, n366LocationDynamicFormId, A366LocationDynamicFormId, A339CallToActionId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_CallToAction");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_CallToAction"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1572( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel1572( ) ;
         }
         CloseExtendedTableCursors1572( ) ;
      }

      protected void DeferredUpdate1572( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1572( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1572( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1572( ) ;
            AfterConfirm1572( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1572( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001511 */
                  pr_default.execute(9, new Object[] {A339CallToActionId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_CallToAction");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode72 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1572( ) ;
         Gx_mode = sMode72;
      }

      protected void OnDeleteControls1572( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001512 */
            pr_default.execute(10, new Object[] {n366LocationDynamicFormId, A366LocationDynamicFormId, A11OrganisationId, A29LocationId});
            A206WWPFormId = BC001512_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001512_A207WWPFormVersionNumber[0];
            pr_default.close(10);
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            /* Using cursor BC001513 */
            pr_default.execute(11, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            A208WWPFormReferenceName = BC001513_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001513_A209WWPFormTitle[0];
            A231WWPFormDate = BC001513_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001513_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001513_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001513_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001513_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001513_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001513_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001513_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001513_A242WWPFormIsForDynamicValidations[0];
            pr_default.close(11);
         }
      }

      protected void EndLevel1572( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1572( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            new prc_addtodynamictransalation(context ).execute(  AV27SDT_TrnAttributes) ;
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart1572( )
      {
         /* Scan By routine */
         /* Using cursor BC001514 */
         pr_default.execute(12, new Object[] {A339CallToActionId});
         RcdFound72 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound72 = 1;
            A339CallToActionId = BC001514_A339CallToActionId[0];
            A367CallToActionUrl = BC001514_A367CallToActionUrl[0];
            A368CallToActionName = BC001514_A368CallToActionName[0];
            A340CallToActionType = BC001514_A340CallToActionType[0];
            A342CallToActionPhone = BC001514_A342CallToActionPhone[0];
            A499CallToActionPhoneCode = BC001514_A499CallToActionPhoneCode[0];
            A500CallToActionPhoneNumber = BC001514_A500CallToActionPhoneNumber[0];
            A341CallToActionEmail = BC001514_A341CallToActionEmail[0];
            A208WWPFormReferenceName = BC001514_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001514_A209WWPFormTitle[0];
            A231WWPFormDate = BC001514_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001514_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001514_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001514_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001514_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001514_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001514_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001514_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001514_A242WWPFormIsForDynamicValidations[0];
            A11OrganisationId = BC001514_A11OrganisationId[0];
            A29LocationId = BC001514_A29LocationId[0];
            A58ProductServiceId = BC001514_A58ProductServiceId[0];
            A366LocationDynamicFormId = BC001514_A366LocationDynamicFormId[0];
            n366LocationDynamicFormId = BC001514_n366LocationDynamicFormId[0];
            A206WWPFormId = BC001514_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001514_A207WWPFormVersionNumber[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1572( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound72 = 0;
         ScanKeyLoad1572( ) ;
      }

      protected void ScanKeyLoad1572( )
      {
         sMode72 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound72 = 1;
            A339CallToActionId = BC001514_A339CallToActionId[0];
            A367CallToActionUrl = BC001514_A367CallToActionUrl[0];
            A368CallToActionName = BC001514_A368CallToActionName[0];
            A340CallToActionType = BC001514_A340CallToActionType[0];
            A342CallToActionPhone = BC001514_A342CallToActionPhone[0];
            A499CallToActionPhoneCode = BC001514_A499CallToActionPhoneCode[0];
            A500CallToActionPhoneNumber = BC001514_A500CallToActionPhoneNumber[0];
            A341CallToActionEmail = BC001514_A341CallToActionEmail[0];
            A208WWPFormReferenceName = BC001514_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001514_A209WWPFormTitle[0];
            A231WWPFormDate = BC001514_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001514_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001514_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001514_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001514_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001514_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001514_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001514_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001514_A242WWPFormIsForDynamicValidations[0];
            A11OrganisationId = BC001514_A11OrganisationId[0];
            A29LocationId = BC001514_A29LocationId[0];
            A58ProductServiceId = BC001514_A58ProductServiceId[0];
            A366LocationDynamicFormId = BC001514_A366LocationDynamicFormId[0];
            n366LocationDynamicFormId = BC001514_n366LocationDynamicFormId[0];
            A206WWPFormId = BC001514_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001514_A207WWPFormVersionNumber[0];
         }
         Gx_mode = sMode72;
      }

      protected void ScanKeyEnd1572( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1572( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1572( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1572( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1572( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1572( )
      {
         /* Before Complete Rules */
         GXt_SdtSDT_TrnAttributes3 = AV27SDT_TrnAttributes;
         new prc_addcalltoactionattributestosdt(context ).execute(  A339CallToActionId, out  GXt_SdtSDT_TrnAttributes3) ;
         AV27SDT_TrnAttributes = GXt_SdtSDT_TrnAttributes3;
      }

      protected void BeforeValidate1572( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1572( )
      {
      }

      protected void send_integrity_lvl_hashes1572( )
      {
      }

      protected void AddRow1572( )
      {
         VarsToRow72( bcTrn_CallToAction) ;
      }

      protected void ReadRow1572( )
      {
         RowToVars72( bcTrn_CallToAction, 1) ;
      }

      protected void InitializeNonKey1572( )
      {
         A367CallToActionUrl = "";
         AV27SDT_TrnAttributes = new SdtSDT_TrnAttributes(context);
         A219WWPFormLatestVersionNumber = 0;
         A58ProductServiceId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A368CallToActionName = "";
         A340CallToActionType = "";
         A342CallToActionPhone = "";
         A499CallToActionPhoneCode = "";
         A500CallToActionPhoneNumber = "";
         A341CallToActionEmail = "";
         A366LocationDynamicFormId = Guid.Empty;
         n366LocationDynamicFormId = false;
         A206WWPFormId = 0;
         A207WWPFormVersionNumber = 0;
         A208WWPFormReferenceName = "";
         A209WWPFormTitle = "";
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         A232WWPFormIsWizard = false;
         A216WWPFormResume = 0;
         A235WWPFormResumeMessage = "";
         A233WWPFormValidations = "";
         A234WWPFormInstantiated = false;
         A240WWPFormType = 0;
         A241WWPFormSectionRefElements = "";
         A242WWPFormIsForDynamicValidations = false;
         Z367CallToActionUrl = "";
         Z368CallToActionName = "";
         Z340CallToActionType = "";
         Z342CallToActionPhone = "";
         Z499CallToActionPhoneCode = "";
         Z500CallToActionPhoneNumber = "";
         Z341CallToActionEmail = "";
         Z11OrganisationId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         Z58ProductServiceId = Guid.Empty;
         Z366LocationDynamicFormId = Guid.Empty;
      }

      protected void InitAll1572( )
      {
         A339CallToActionId = Guid.NewGuid( );
         InitializeNonKey1572( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow72( SdtTrn_CallToAction obj72 )
      {
         obj72.gxTpr_Mode = Gx_mode;
         obj72.gxTpr_Calltoactionurl = A367CallToActionUrl;
         obj72.gxTpr_Wwpformlatestversionnumber = A219WWPFormLatestVersionNumber;
         obj72.gxTpr_Productserviceid = A58ProductServiceId;
         obj72.gxTpr_Organisationid = A11OrganisationId;
         obj72.gxTpr_Locationid = A29LocationId;
         obj72.gxTpr_Calltoactionname = A368CallToActionName;
         obj72.gxTpr_Calltoactiontype = A340CallToActionType;
         obj72.gxTpr_Calltoactionphone = A342CallToActionPhone;
         obj72.gxTpr_Calltoactionphonecode = A499CallToActionPhoneCode;
         obj72.gxTpr_Calltoactionphonenumber = A500CallToActionPhoneNumber;
         obj72.gxTpr_Calltoactionemail = A341CallToActionEmail;
         obj72.gxTpr_Locationdynamicformid = A366LocationDynamicFormId;
         obj72.gxTpr_Wwpformid = A206WWPFormId;
         obj72.gxTpr_Wwpformversionnumber = A207WWPFormVersionNumber;
         obj72.gxTpr_Wwpformreferencename = A208WWPFormReferenceName;
         obj72.gxTpr_Wwpformtitle = A209WWPFormTitle;
         obj72.gxTpr_Wwpformdate = A231WWPFormDate;
         obj72.gxTpr_Wwpformiswizard = A232WWPFormIsWizard;
         obj72.gxTpr_Wwpformresume = A216WWPFormResume;
         obj72.gxTpr_Wwpformresumemessage = A235WWPFormResumeMessage;
         obj72.gxTpr_Wwpformvalidations = A233WWPFormValidations;
         obj72.gxTpr_Wwpforminstantiated = A234WWPFormInstantiated;
         obj72.gxTpr_Wwpformtype = A240WWPFormType;
         obj72.gxTpr_Wwpformsectionrefelements = A241WWPFormSectionRefElements;
         obj72.gxTpr_Wwpformisfordynamicvalidations = A242WWPFormIsForDynamicValidations;
         obj72.gxTpr_Calltoactionid = A339CallToActionId;
         obj72.gxTpr_Calltoactionid_Z = Z339CallToActionId;
         obj72.gxTpr_Productserviceid_Z = Z58ProductServiceId;
         obj72.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj72.gxTpr_Locationid_Z = Z29LocationId;
         obj72.gxTpr_Calltoactionname_Z = Z368CallToActionName;
         obj72.gxTpr_Calltoactiontype_Z = Z340CallToActionType;
         obj72.gxTpr_Calltoactionphone_Z = Z342CallToActionPhone;
         obj72.gxTpr_Calltoactionphonecode_Z = Z499CallToActionPhoneCode;
         obj72.gxTpr_Calltoactionphonenumber_Z = Z500CallToActionPhoneNumber;
         obj72.gxTpr_Calltoactionurl_Z = Z367CallToActionUrl;
         obj72.gxTpr_Calltoactionemail_Z = Z341CallToActionEmail;
         obj72.gxTpr_Locationdynamicformid_Z = Z366LocationDynamicFormId;
         obj72.gxTpr_Wwpformid_Z = Z206WWPFormId;
         obj72.gxTpr_Wwpformversionnumber_Z = Z207WWPFormVersionNumber;
         obj72.gxTpr_Wwpformreferencename_Z = Z208WWPFormReferenceName;
         obj72.gxTpr_Wwpformtitle_Z = Z209WWPFormTitle;
         obj72.gxTpr_Wwpformdate_Z = Z231WWPFormDate;
         obj72.gxTpr_Wwpformiswizard_Z = Z232WWPFormIsWizard;
         obj72.gxTpr_Wwpformresume_Z = Z216WWPFormResume;
         obj72.gxTpr_Wwpforminstantiated_Z = Z234WWPFormInstantiated;
         obj72.gxTpr_Wwpformlatestversionnumber_Z = Z219WWPFormLatestVersionNumber;
         obj72.gxTpr_Wwpformtype_Z = Z240WWPFormType;
         obj72.gxTpr_Wwpformsectionrefelements_Z = Z241WWPFormSectionRefElements;
         obj72.gxTpr_Wwpformisfordynamicvalidations_Z = Z242WWPFormIsForDynamicValidations;
         obj72.gxTpr_Locationdynamicformid_N = (short)(Convert.ToInt16(n366LocationDynamicFormId));
         obj72.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow72( SdtTrn_CallToAction obj72 )
      {
         obj72.gxTpr_Calltoactionid = A339CallToActionId;
         return  ;
      }

      public void RowToVars72( SdtTrn_CallToAction obj72 ,
                               int forceLoad )
      {
         Gx_mode = obj72.gxTpr_Mode;
         A367CallToActionUrl = obj72.gxTpr_Calltoactionurl;
         A219WWPFormLatestVersionNumber = obj72.gxTpr_Wwpformlatestversionnumber;
         A58ProductServiceId = obj72.gxTpr_Productserviceid;
         A11OrganisationId = obj72.gxTpr_Organisationid;
         A29LocationId = obj72.gxTpr_Locationid;
         A368CallToActionName = obj72.gxTpr_Calltoactionname;
         A340CallToActionType = obj72.gxTpr_Calltoactiontype;
         A342CallToActionPhone = obj72.gxTpr_Calltoactionphone;
         A499CallToActionPhoneCode = obj72.gxTpr_Calltoactionphonecode;
         A500CallToActionPhoneNumber = obj72.gxTpr_Calltoactionphonenumber;
         A341CallToActionEmail = obj72.gxTpr_Calltoactionemail;
         A366LocationDynamicFormId = obj72.gxTpr_Locationdynamicformid;
         n366LocationDynamicFormId = false;
         A206WWPFormId = obj72.gxTpr_Wwpformid;
         A207WWPFormVersionNumber = obj72.gxTpr_Wwpformversionnumber;
         A208WWPFormReferenceName = obj72.gxTpr_Wwpformreferencename;
         A209WWPFormTitle = obj72.gxTpr_Wwpformtitle;
         A231WWPFormDate = obj72.gxTpr_Wwpformdate;
         A232WWPFormIsWizard = obj72.gxTpr_Wwpformiswizard;
         A216WWPFormResume = obj72.gxTpr_Wwpformresume;
         A235WWPFormResumeMessage = obj72.gxTpr_Wwpformresumemessage;
         A233WWPFormValidations = obj72.gxTpr_Wwpformvalidations;
         A234WWPFormInstantiated = obj72.gxTpr_Wwpforminstantiated;
         A240WWPFormType = obj72.gxTpr_Wwpformtype;
         A241WWPFormSectionRefElements = obj72.gxTpr_Wwpformsectionrefelements;
         A242WWPFormIsForDynamicValidations = obj72.gxTpr_Wwpformisfordynamicvalidations;
         A339CallToActionId = obj72.gxTpr_Calltoactionid;
         Z339CallToActionId = obj72.gxTpr_Calltoactionid_Z;
         Z58ProductServiceId = obj72.gxTpr_Productserviceid_Z;
         Z11OrganisationId = obj72.gxTpr_Organisationid_Z;
         Z29LocationId = obj72.gxTpr_Locationid_Z;
         Z368CallToActionName = obj72.gxTpr_Calltoactionname_Z;
         Z340CallToActionType = obj72.gxTpr_Calltoactiontype_Z;
         Z342CallToActionPhone = obj72.gxTpr_Calltoactionphone_Z;
         Z499CallToActionPhoneCode = obj72.gxTpr_Calltoactionphonecode_Z;
         Z500CallToActionPhoneNumber = obj72.gxTpr_Calltoactionphonenumber_Z;
         Z367CallToActionUrl = obj72.gxTpr_Calltoactionurl_Z;
         Z341CallToActionEmail = obj72.gxTpr_Calltoactionemail_Z;
         Z366LocationDynamicFormId = obj72.gxTpr_Locationdynamicformid_Z;
         Z206WWPFormId = obj72.gxTpr_Wwpformid_Z;
         Z207WWPFormVersionNumber = obj72.gxTpr_Wwpformversionnumber_Z;
         Z208WWPFormReferenceName = obj72.gxTpr_Wwpformreferencename_Z;
         Z209WWPFormTitle = obj72.gxTpr_Wwpformtitle_Z;
         Z231WWPFormDate = obj72.gxTpr_Wwpformdate_Z;
         Z232WWPFormIsWizard = obj72.gxTpr_Wwpformiswizard_Z;
         Z216WWPFormResume = obj72.gxTpr_Wwpformresume_Z;
         Z234WWPFormInstantiated = obj72.gxTpr_Wwpforminstantiated_Z;
         Z219WWPFormLatestVersionNumber = obj72.gxTpr_Wwpformlatestversionnumber_Z;
         Z240WWPFormType = obj72.gxTpr_Wwpformtype_Z;
         Z241WWPFormSectionRefElements = obj72.gxTpr_Wwpformsectionrefelements_Z;
         Z242WWPFormIsForDynamicValidations = obj72.gxTpr_Wwpformisfordynamicvalidations_Z;
         n366LocationDynamicFormId = (bool)(Convert.ToBoolean(obj72.gxTpr_Locationdynamicformid_N));
         Gx_mode = obj72.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A339CallToActionId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1572( ) ;
         ScanKeyStart1572( ) ;
         if ( RcdFound72 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z339CallToActionId = A339CallToActionId;
         }
         ZM1572( -15) ;
         OnLoadActions1572( ) ;
         AddRow1572( ) ;
         ScanKeyEnd1572( ) ;
         if ( RcdFound72 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars72( bcTrn_CallToAction, 0) ;
         ScanKeyStart1572( ) ;
         if ( RcdFound72 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z339CallToActionId = A339CallToActionId;
         }
         ZM1572( -15) ;
         OnLoadActions1572( ) ;
         AddRow1572( ) ;
         ScanKeyEnd1572( ) ;
         if ( RcdFound72 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1572( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1572( ) ;
         }
         else
         {
            if ( RcdFound72 == 1 )
            {
               if ( A339CallToActionId != Z339CallToActionId )
               {
                  A339CallToActionId = Z339CallToActionId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update1572( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A339CallToActionId != Z339CallToActionId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert1572( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert1572( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars72( bcTrn_CallToAction, 1) ;
         SaveImpl( ) ;
         VarsToRow72( bcTrn_CallToAction) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars72( bcTrn_CallToAction, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1572( ) ;
         AfterTrn( ) ;
         VarsToRow72( bcTrn_CallToAction) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow72( bcTrn_CallToAction) ;
         }
         else
         {
            SdtTrn_CallToAction auxBC = new SdtTrn_CallToAction(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A339CallToActionId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_CallToAction);
               auxBC.Save();
               bcTrn_CallToAction.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars72( bcTrn_CallToAction, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars72( bcTrn_CallToAction, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1572( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow72( bcTrn_CallToAction) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow72( bcTrn_CallToAction) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars72( bcTrn_CallToAction, 0) ;
         GetKey1572( ) ;
         if ( RcdFound72 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A339CallToActionId != Z339CallToActionId )
            {
               A339CallToActionId = Z339CallToActionId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A339CallToActionId != Z339CallToActionId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         context.RollbackDataStores("trn_calltoaction_bc",pr_default);
         VarsToRow72( bcTrn_CallToAction) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcTrn_CallToAction.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_CallToAction.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_CallToAction )
         {
            bcTrn_CallToAction = (SdtTrn_CallToAction)(sdt);
            if ( StringUtil.StrCmp(bcTrn_CallToAction.gxTpr_Mode, "") == 0 )
            {
               bcTrn_CallToAction.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow72( bcTrn_CallToAction) ;
            }
            else
            {
               RowToVars72( bcTrn_CallToAction, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_CallToAction.gxTpr_Mode, "") == 0 )
            {
               bcTrn_CallToAction.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars72( bcTrn_CallToAction, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_CallToAction Trn_CallToAction_BC
      {
         get {
            return bcTrn_CallToAction ;
         }

      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "trn_calltoaction_Execute" ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(10);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z339CallToActionId = Guid.Empty;
         A339CallToActionId = Guid.Empty;
         Z367CallToActionUrl = "";
         A367CallToActionUrl = "";
         Z368CallToActionName = "";
         A368CallToActionName = "";
         Z340CallToActionType = "";
         A340CallToActionType = "";
         Z342CallToActionPhone = "";
         A342CallToActionPhone = "";
         Z499CallToActionPhoneCode = "";
         A499CallToActionPhoneCode = "";
         Z500CallToActionPhoneNumber = "";
         A500CallToActionPhoneNumber = "";
         Z341CallToActionEmail = "";
         A341CallToActionEmail = "";
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z58ProductServiceId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         Z366LocationDynamicFormId = Guid.Empty;
         A366LocationDynamicFormId = Guid.Empty;
         Z208WWPFormReferenceName = "";
         A208WWPFormReferenceName = "";
         Z209WWPFormTitle = "";
         A209WWPFormTitle = "";
         Z231WWPFormDate = (DateTime)(DateTime.MinValue);
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         Z241WWPFormSectionRefElements = "";
         A241WWPFormSectionRefElements = "";
         Z235WWPFormResumeMessage = "";
         A235WWPFormResumeMessage = "";
         Z233WWPFormValidations = "";
         A233WWPFormValidations = "";
         BC00157_A339CallToActionId = new Guid[] {Guid.Empty} ;
         BC00157_A367CallToActionUrl = new string[] {""} ;
         BC00157_A368CallToActionName = new string[] {""} ;
         BC00157_A340CallToActionType = new string[] {""} ;
         BC00157_A342CallToActionPhone = new string[] {""} ;
         BC00157_A499CallToActionPhoneCode = new string[] {""} ;
         BC00157_A500CallToActionPhoneNumber = new string[] {""} ;
         BC00157_A341CallToActionEmail = new string[] {""} ;
         BC00157_A208WWPFormReferenceName = new string[] {""} ;
         BC00157_A209WWPFormTitle = new string[] {""} ;
         BC00157_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC00157_A232WWPFormIsWizard = new bool[] {false} ;
         BC00157_A216WWPFormResume = new short[1] ;
         BC00157_A235WWPFormResumeMessage = new string[] {""} ;
         BC00157_A233WWPFormValidations = new string[] {""} ;
         BC00157_A234WWPFormInstantiated = new bool[] {false} ;
         BC00157_A240WWPFormType = new short[1] ;
         BC00157_A241WWPFormSectionRefElements = new string[] {""} ;
         BC00157_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC00157_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00157_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00157_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC00157_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC00157_n366LocationDynamicFormId = new bool[] {false} ;
         BC00157_A206WWPFormId = new short[1] ;
         BC00157_A207WWPFormVersionNumber = new short[1] ;
         BC00154_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC00155_A206WWPFormId = new short[1] ;
         BC00155_A207WWPFormVersionNumber = new short[1] ;
         BC00156_A208WWPFormReferenceName = new string[] {""} ;
         BC00156_A209WWPFormTitle = new string[] {""} ;
         BC00156_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC00156_A232WWPFormIsWizard = new bool[] {false} ;
         BC00156_A216WWPFormResume = new short[1] ;
         BC00156_A235WWPFormResumeMessage = new string[] {""} ;
         BC00156_A233WWPFormValidations = new string[] {""} ;
         BC00156_A234WWPFormInstantiated = new bool[] {false} ;
         BC00156_A240WWPFormType = new short[1] ;
         BC00156_A241WWPFormSectionRefElements = new string[] {""} ;
         BC00156_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         GXt_char2 = "";
         BC00158_A339CallToActionId = new Guid[] {Guid.Empty} ;
         BC00153_A339CallToActionId = new Guid[] {Guid.Empty} ;
         BC00153_A367CallToActionUrl = new string[] {""} ;
         BC00153_A368CallToActionName = new string[] {""} ;
         BC00153_A340CallToActionType = new string[] {""} ;
         BC00153_A342CallToActionPhone = new string[] {""} ;
         BC00153_A499CallToActionPhoneCode = new string[] {""} ;
         BC00153_A500CallToActionPhoneNumber = new string[] {""} ;
         BC00153_A341CallToActionEmail = new string[] {""} ;
         BC00153_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00153_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00153_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC00153_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC00153_n366LocationDynamicFormId = new bool[] {false} ;
         sMode72 = "";
         BC00152_A339CallToActionId = new Guid[] {Guid.Empty} ;
         BC00152_A367CallToActionUrl = new string[] {""} ;
         BC00152_A368CallToActionName = new string[] {""} ;
         BC00152_A340CallToActionType = new string[] {""} ;
         BC00152_A342CallToActionPhone = new string[] {""} ;
         BC00152_A499CallToActionPhoneCode = new string[] {""} ;
         BC00152_A500CallToActionPhoneNumber = new string[] {""} ;
         BC00152_A341CallToActionEmail = new string[] {""} ;
         BC00152_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00152_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00152_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC00152_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC00152_n366LocationDynamicFormId = new bool[] {false} ;
         BC001512_A206WWPFormId = new short[1] ;
         BC001512_A207WWPFormVersionNumber = new short[1] ;
         BC001513_A208WWPFormReferenceName = new string[] {""} ;
         BC001513_A209WWPFormTitle = new string[] {""} ;
         BC001513_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001513_A232WWPFormIsWizard = new bool[] {false} ;
         BC001513_A216WWPFormResume = new short[1] ;
         BC001513_A235WWPFormResumeMessage = new string[] {""} ;
         BC001513_A233WWPFormValidations = new string[] {""} ;
         BC001513_A234WWPFormInstantiated = new bool[] {false} ;
         BC001513_A240WWPFormType = new short[1] ;
         BC001513_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001513_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         AV27SDT_TrnAttributes = new SdtSDT_TrnAttributes(context);
         BC001514_A339CallToActionId = new Guid[] {Guid.Empty} ;
         BC001514_A367CallToActionUrl = new string[] {""} ;
         BC001514_A368CallToActionName = new string[] {""} ;
         BC001514_A340CallToActionType = new string[] {""} ;
         BC001514_A342CallToActionPhone = new string[] {""} ;
         BC001514_A499CallToActionPhoneCode = new string[] {""} ;
         BC001514_A500CallToActionPhoneNumber = new string[] {""} ;
         BC001514_A341CallToActionEmail = new string[] {""} ;
         BC001514_A208WWPFormReferenceName = new string[] {""} ;
         BC001514_A209WWPFormTitle = new string[] {""} ;
         BC001514_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001514_A232WWPFormIsWizard = new bool[] {false} ;
         BC001514_A216WWPFormResume = new short[1] ;
         BC001514_A235WWPFormResumeMessage = new string[] {""} ;
         BC001514_A233WWPFormValidations = new string[] {""} ;
         BC001514_A234WWPFormInstantiated = new bool[] {false} ;
         BC001514_A240WWPFormType = new short[1] ;
         BC001514_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001514_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001514_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001514_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001514_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC001514_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001514_n366LocationDynamicFormId = new bool[] {false} ;
         BC001514_A206WWPFormId = new short[1] ;
         BC001514_A207WWPFormVersionNumber = new short[1] ;
         GXt_SdtSDT_TrnAttributes3 = new SdtSDT_TrnAttributes(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_calltoaction_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_calltoaction_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_calltoaction_bc__default(),
            new Object[][] {
                new Object[] {
               BC00152_A339CallToActionId, BC00152_A367CallToActionUrl, BC00152_A368CallToActionName, BC00152_A340CallToActionType, BC00152_A342CallToActionPhone, BC00152_A499CallToActionPhoneCode, BC00152_A500CallToActionPhoneNumber, BC00152_A341CallToActionEmail, BC00152_A11OrganisationId, BC00152_A29LocationId,
               BC00152_A58ProductServiceId, BC00152_A366LocationDynamicFormId, BC00152_n366LocationDynamicFormId
               }
               , new Object[] {
               BC00153_A339CallToActionId, BC00153_A367CallToActionUrl, BC00153_A368CallToActionName, BC00153_A340CallToActionType, BC00153_A342CallToActionPhone, BC00153_A499CallToActionPhoneCode, BC00153_A500CallToActionPhoneNumber, BC00153_A341CallToActionEmail, BC00153_A11OrganisationId, BC00153_A29LocationId,
               BC00153_A58ProductServiceId, BC00153_A366LocationDynamicFormId, BC00153_n366LocationDynamicFormId
               }
               , new Object[] {
               BC00154_A58ProductServiceId
               }
               , new Object[] {
               BC00155_A206WWPFormId, BC00155_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC00156_A208WWPFormReferenceName, BC00156_A209WWPFormTitle, BC00156_A231WWPFormDate, BC00156_A232WWPFormIsWizard, BC00156_A216WWPFormResume, BC00156_A235WWPFormResumeMessage, BC00156_A233WWPFormValidations, BC00156_A234WWPFormInstantiated, BC00156_A240WWPFormType, BC00156_A241WWPFormSectionRefElements,
               BC00156_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               BC00157_A339CallToActionId, BC00157_A367CallToActionUrl, BC00157_A368CallToActionName, BC00157_A340CallToActionType, BC00157_A342CallToActionPhone, BC00157_A499CallToActionPhoneCode, BC00157_A500CallToActionPhoneNumber, BC00157_A341CallToActionEmail, BC00157_A208WWPFormReferenceName, BC00157_A209WWPFormTitle,
               BC00157_A231WWPFormDate, BC00157_A232WWPFormIsWizard, BC00157_A216WWPFormResume, BC00157_A235WWPFormResumeMessage, BC00157_A233WWPFormValidations, BC00157_A234WWPFormInstantiated, BC00157_A240WWPFormType, BC00157_A241WWPFormSectionRefElements, BC00157_A242WWPFormIsForDynamicValidations, BC00157_A11OrganisationId,
               BC00157_A29LocationId, BC00157_A58ProductServiceId, BC00157_A366LocationDynamicFormId, BC00157_n366LocationDynamicFormId, BC00157_A206WWPFormId, BC00157_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC00158_A339CallToActionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001512_A206WWPFormId, BC001512_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC001513_A208WWPFormReferenceName, BC001513_A209WWPFormTitle, BC001513_A231WWPFormDate, BC001513_A232WWPFormIsWizard, BC001513_A216WWPFormResume, BC001513_A235WWPFormResumeMessage, BC001513_A233WWPFormValidations, BC001513_A234WWPFormInstantiated, BC001513_A240WWPFormType, BC001513_A241WWPFormSectionRefElements,
               BC001513_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               BC001514_A339CallToActionId, BC001514_A367CallToActionUrl, BC001514_A368CallToActionName, BC001514_A340CallToActionType, BC001514_A342CallToActionPhone, BC001514_A499CallToActionPhoneCode, BC001514_A500CallToActionPhoneNumber, BC001514_A341CallToActionEmail, BC001514_A208WWPFormReferenceName, BC001514_A209WWPFormTitle,
               BC001514_A231WWPFormDate, BC001514_A232WWPFormIsWizard, BC001514_A216WWPFormResume, BC001514_A235WWPFormResumeMessage, BC001514_A233WWPFormValidations, BC001514_A234WWPFormInstantiated, BC001514_A240WWPFormType, BC001514_A241WWPFormSectionRefElements, BC001514_A242WWPFormIsForDynamicValidations, BC001514_A11OrganisationId,
               BC001514_A29LocationId, BC001514_A58ProductServiceId, BC001514_A366LocationDynamicFormId, BC001514_n366LocationDynamicFormId, BC001514_A206WWPFormId, BC001514_A207WWPFormVersionNumber
               }
            }
         );
         Z339CallToActionId = Guid.NewGuid( );
         A339CallToActionId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12152 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z219WWPFormLatestVersionNumber ;
      private short A219WWPFormLatestVersionNumber ;
      private short Z206WWPFormId ;
      private short A206WWPFormId ;
      private short Z207WWPFormVersionNumber ;
      private short A207WWPFormVersionNumber ;
      private short Z216WWPFormResume ;
      private short A216WWPFormResume ;
      private short Z240WWPFormType ;
      private short A240WWPFormType ;
      private short Gx_BScreen ;
      private short RcdFound72 ;
      private short GXt_int1 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z342CallToActionPhone ;
      private string A342CallToActionPhone ;
      private string GXt_char2 ;
      private string sMode72 ;
      private DateTime Z231WWPFormDate ;
      private DateTime A231WWPFormDate ;
      private bool returnInSub ;
      private bool Z232WWPFormIsWizard ;
      private bool A232WWPFormIsWizard ;
      private bool Z234WWPFormInstantiated ;
      private bool A234WWPFormInstantiated ;
      private bool Z242WWPFormIsForDynamicValidations ;
      private bool A242WWPFormIsForDynamicValidations ;
      private bool n366LocationDynamicFormId ;
      private bool Gx_longc ;
      private string Z235WWPFormResumeMessage ;
      private string A235WWPFormResumeMessage ;
      private string Z233WWPFormValidations ;
      private string A233WWPFormValidations ;
      private string Z367CallToActionUrl ;
      private string A367CallToActionUrl ;
      private string Z368CallToActionName ;
      private string A368CallToActionName ;
      private string Z340CallToActionType ;
      private string A340CallToActionType ;
      private string Z499CallToActionPhoneCode ;
      private string A499CallToActionPhoneCode ;
      private string Z500CallToActionPhoneNumber ;
      private string A500CallToActionPhoneNumber ;
      private string Z341CallToActionEmail ;
      private string A341CallToActionEmail ;
      private string Z208WWPFormReferenceName ;
      private string A208WWPFormReferenceName ;
      private string Z209WWPFormTitle ;
      private string A209WWPFormTitle ;
      private string Z241WWPFormSectionRefElements ;
      private string A241WWPFormSectionRefElements ;
      private Guid Z339CallToActionId ;
      private Guid A339CallToActionId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid Z58ProductServiceId ;
      private Guid A58ProductServiceId ;
      private Guid Z366LocationDynamicFormId ;
      private Guid A366LocationDynamicFormId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00157_A339CallToActionId ;
      private string[] BC00157_A367CallToActionUrl ;
      private string[] BC00157_A368CallToActionName ;
      private string[] BC00157_A340CallToActionType ;
      private string[] BC00157_A342CallToActionPhone ;
      private string[] BC00157_A499CallToActionPhoneCode ;
      private string[] BC00157_A500CallToActionPhoneNumber ;
      private string[] BC00157_A341CallToActionEmail ;
      private string[] BC00157_A208WWPFormReferenceName ;
      private string[] BC00157_A209WWPFormTitle ;
      private DateTime[] BC00157_A231WWPFormDate ;
      private bool[] BC00157_A232WWPFormIsWizard ;
      private short[] BC00157_A216WWPFormResume ;
      private string[] BC00157_A235WWPFormResumeMessage ;
      private string[] BC00157_A233WWPFormValidations ;
      private bool[] BC00157_A234WWPFormInstantiated ;
      private short[] BC00157_A240WWPFormType ;
      private string[] BC00157_A241WWPFormSectionRefElements ;
      private bool[] BC00157_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC00157_A11OrganisationId ;
      private Guid[] BC00157_A29LocationId ;
      private Guid[] BC00157_A58ProductServiceId ;
      private Guid[] BC00157_A366LocationDynamicFormId ;
      private bool[] BC00157_n366LocationDynamicFormId ;
      private short[] BC00157_A206WWPFormId ;
      private short[] BC00157_A207WWPFormVersionNumber ;
      private Guid[] BC00154_A58ProductServiceId ;
      private short[] BC00155_A206WWPFormId ;
      private short[] BC00155_A207WWPFormVersionNumber ;
      private string[] BC00156_A208WWPFormReferenceName ;
      private string[] BC00156_A209WWPFormTitle ;
      private DateTime[] BC00156_A231WWPFormDate ;
      private bool[] BC00156_A232WWPFormIsWizard ;
      private short[] BC00156_A216WWPFormResume ;
      private string[] BC00156_A235WWPFormResumeMessage ;
      private string[] BC00156_A233WWPFormValidations ;
      private bool[] BC00156_A234WWPFormInstantiated ;
      private short[] BC00156_A240WWPFormType ;
      private string[] BC00156_A241WWPFormSectionRefElements ;
      private bool[] BC00156_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC00158_A339CallToActionId ;
      private Guid[] BC00153_A339CallToActionId ;
      private string[] BC00153_A367CallToActionUrl ;
      private string[] BC00153_A368CallToActionName ;
      private string[] BC00153_A340CallToActionType ;
      private string[] BC00153_A342CallToActionPhone ;
      private string[] BC00153_A499CallToActionPhoneCode ;
      private string[] BC00153_A500CallToActionPhoneNumber ;
      private string[] BC00153_A341CallToActionEmail ;
      private Guid[] BC00153_A11OrganisationId ;
      private Guid[] BC00153_A29LocationId ;
      private Guid[] BC00153_A58ProductServiceId ;
      private Guid[] BC00153_A366LocationDynamicFormId ;
      private bool[] BC00153_n366LocationDynamicFormId ;
      private Guid[] BC00152_A339CallToActionId ;
      private string[] BC00152_A367CallToActionUrl ;
      private string[] BC00152_A368CallToActionName ;
      private string[] BC00152_A340CallToActionType ;
      private string[] BC00152_A342CallToActionPhone ;
      private string[] BC00152_A499CallToActionPhoneCode ;
      private string[] BC00152_A500CallToActionPhoneNumber ;
      private string[] BC00152_A341CallToActionEmail ;
      private Guid[] BC00152_A11OrganisationId ;
      private Guid[] BC00152_A29LocationId ;
      private Guid[] BC00152_A58ProductServiceId ;
      private Guid[] BC00152_A366LocationDynamicFormId ;
      private bool[] BC00152_n366LocationDynamicFormId ;
      private short[] BC001512_A206WWPFormId ;
      private short[] BC001512_A207WWPFormVersionNumber ;
      private string[] BC001513_A208WWPFormReferenceName ;
      private string[] BC001513_A209WWPFormTitle ;
      private DateTime[] BC001513_A231WWPFormDate ;
      private bool[] BC001513_A232WWPFormIsWizard ;
      private short[] BC001513_A216WWPFormResume ;
      private string[] BC001513_A235WWPFormResumeMessage ;
      private string[] BC001513_A233WWPFormValidations ;
      private bool[] BC001513_A234WWPFormInstantiated ;
      private short[] BC001513_A240WWPFormType ;
      private string[] BC001513_A241WWPFormSectionRefElements ;
      private bool[] BC001513_A242WWPFormIsForDynamicValidations ;
      private SdtSDT_TrnAttributes AV27SDT_TrnAttributes ;
      private Guid[] BC001514_A339CallToActionId ;
      private string[] BC001514_A367CallToActionUrl ;
      private string[] BC001514_A368CallToActionName ;
      private string[] BC001514_A340CallToActionType ;
      private string[] BC001514_A342CallToActionPhone ;
      private string[] BC001514_A499CallToActionPhoneCode ;
      private string[] BC001514_A500CallToActionPhoneNumber ;
      private string[] BC001514_A341CallToActionEmail ;
      private string[] BC001514_A208WWPFormReferenceName ;
      private string[] BC001514_A209WWPFormTitle ;
      private DateTime[] BC001514_A231WWPFormDate ;
      private bool[] BC001514_A232WWPFormIsWizard ;
      private short[] BC001514_A216WWPFormResume ;
      private string[] BC001514_A235WWPFormResumeMessage ;
      private string[] BC001514_A233WWPFormValidations ;
      private bool[] BC001514_A234WWPFormInstantiated ;
      private short[] BC001514_A240WWPFormType ;
      private string[] BC001514_A241WWPFormSectionRefElements ;
      private bool[] BC001514_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001514_A11OrganisationId ;
      private Guid[] BC001514_A29LocationId ;
      private Guid[] BC001514_A58ProductServiceId ;
      private Guid[] BC001514_A366LocationDynamicFormId ;
      private bool[] BC001514_n366LocationDynamicFormId ;
      private short[] BC001514_A206WWPFormId ;
      private short[] BC001514_A207WWPFormVersionNumber ;
      private SdtSDT_TrnAttributes GXt_SdtSDT_TrnAttributes3 ;
      private SdtTrn_CallToAction bcTrn_CallToAction ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_calltoaction_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class trn_calltoaction_bc__gam : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class trn_calltoaction_bc__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new ForEachCursor(def[3])
      ,new ForEachCursor(def[4])
      ,new ForEachCursor(def[5])
      ,new ForEachCursor(def[6])
      ,new UpdateCursor(def[7])
      ,new UpdateCursor(def[8])
      ,new UpdateCursor(def[9])
      ,new ForEachCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new ForEachCursor(def[12])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC00152;
       prmBC00152 = new Object[] {
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00153;
       prmBC00153 = new Object[] {
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00154;
       prmBC00154 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00155;
       prmBC00155 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00156;
       prmBC00156 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC00157;
       prmBC00157 = new Object[] {
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00158;
       prmBC00158 = new Object[] {
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00159;
       prmBC00159 = new Object[] {
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CallToActionUrl",GXType.VarChar,1000,0) ,
       new ParDef("CallToActionName",GXType.VarChar,100,0) ,
       new ParDef("CallToActionType",GXType.VarChar,100,0) ,
       new ParDef("CallToActionPhone",GXType.Char,20,0) ,
       new ParDef("CallToActionPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("CallToActionPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("CallToActionEmail",GXType.VarChar,100,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001510;
       prmBC001510 = new Object[] {
       new ParDef("CallToActionUrl",GXType.VarChar,1000,0) ,
       new ParDef("CallToActionName",GXType.VarChar,100,0) ,
       new ParDef("CallToActionType",GXType.VarChar,100,0) ,
       new ParDef("CallToActionPhone",GXType.Char,20,0) ,
       new ParDef("CallToActionPhoneCode",GXType.VarChar,40,0) ,
       new ParDef("CallToActionPhoneNumber",GXType.VarChar,9,0) ,
       new ParDef("CallToActionEmail",GXType.VarChar,100,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001511;
       prmBC001511 = new Object[] {
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001512;
       prmBC001512 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001513;
       prmBC001513 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001514;
       prmBC001514 = new Object[] {
       new ParDef("CallToActionId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC00152", "SELECT CallToActionId, CallToActionUrl, CallToActionName, CallToActionType, CallToActionPhone, CallToActionPhoneCode, CallToActionPhoneNumber, CallToActionEmail, OrganisationId, LocationId, ProductServiceId, LocationDynamicFormId FROM Trn_CallToAction WHERE CallToActionId = :CallToActionId  FOR UPDATE OF Trn_CallToAction",true, GxErrorMask.GX_NOMASK, false, this,prmBC00152,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00153", "SELECT CallToActionId, CallToActionUrl, CallToActionName, CallToActionType, CallToActionPhone, CallToActionPhoneCode, CallToActionPhoneNumber, CallToActionEmail, OrganisationId, LocationId, ProductServiceId, LocationDynamicFormId FROM Trn_CallToAction WHERE CallToActionId = :CallToActionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00153,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00154", "SELECT ProductServiceId FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00154,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00155", "SELECT WWPFormId, WWPFormVersionNumber FROM Trn_LocationDynamicForm WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00155,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00156", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00156,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00157", "SELECT TM1.CallToActionId, TM1.CallToActionUrl, TM1.CallToActionName, TM1.CallToActionType, TM1.CallToActionPhone, TM1.CallToActionPhoneCode, TM1.CallToActionPhoneNumber, TM1.CallToActionEmail, T3.WWPFormReferenceName, T3.WWPFormTitle, T3.WWPFormDate, T3.WWPFormIsWizard, T3.WWPFormResume, T3.WWPFormResumeMessage, T3.WWPFormValidations, T3.WWPFormInstantiated, T3.WWPFormType, T3.WWPFormSectionRefElements, T3.WWPFormIsForDynamicValidations, TM1.OrganisationId, TM1.LocationId, TM1.ProductServiceId, TM1.LocationDynamicFormId, T2.WWPFormId, T2.WWPFormVersionNumber FROM ((Trn_CallToAction TM1 LEFT JOIN Trn_LocationDynamicForm T2 ON T2.LocationDynamicFormId = TM1.LocationDynamicFormId AND T2.OrganisationId = TM1.OrganisationId AND T2.LocationId = TM1.LocationId) LEFT JOIN WWP_Form T3 ON T3.WWPFormId = T2.WWPFormId AND T3.WWPFormVersionNumber = T2.WWPFormVersionNumber) WHERE TM1.CallToActionId = :CallToActionId ORDER BY TM1.CallToActionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00157,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00158", "SELECT CallToActionId FROM Trn_CallToAction WHERE CallToActionId = :CallToActionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00158,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00159", "SAVEPOINT gxupdate;INSERT INTO Trn_CallToAction(CallToActionId, CallToActionUrl, CallToActionName, CallToActionType, CallToActionPhone, CallToActionPhoneCode, CallToActionPhoneNumber, CallToActionEmail, OrganisationId, LocationId, ProductServiceId, LocationDynamicFormId) VALUES(:CallToActionId, :CallToActionUrl, :CallToActionName, :CallToActionType, :CallToActionPhone, :CallToActionPhoneCode, :CallToActionPhoneNumber, :CallToActionEmail, :OrganisationId, :LocationId, :ProductServiceId, :LocationDynamicFormId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00159)
          ,new CursorDef("BC001510", "SAVEPOINT gxupdate;UPDATE Trn_CallToAction SET CallToActionUrl=:CallToActionUrl, CallToActionName=:CallToActionName, CallToActionType=:CallToActionType, CallToActionPhone=:CallToActionPhone, CallToActionPhoneCode=:CallToActionPhoneCode, CallToActionPhoneNumber=:CallToActionPhoneNumber, CallToActionEmail=:CallToActionEmail, OrganisationId=:OrganisationId, LocationId=:LocationId, ProductServiceId=:ProductServiceId, LocationDynamicFormId=:LocationDynamicFormId  WHERE CallToActionId = :CallToActionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001510)
          ,new CursorDef("BC001511", "SAVEPOINT gxupdate;DELETE FROM Trn_CallToAction  WHERE CallToActionId = :CallToActionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001511)
          ,new CursorDef("BC001512", "SELECT WWPFormId, WWPFormVersionNumber FROM Trn_LocationDynamicForm WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001512,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001513", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001513,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001514", "SELECT TM1.CallToActionId, TM1.CallToActionUrl, TM1.CallToActionName, TM1.CallToActionType, TM1.CallToActionPhone, TM1.CallToActionPhoneCode, TM1.CallToActionPhoneNumber, TM1.CallToActionEmail, T3.WWPFormReferenceName, T3.WWPFormTitle, T3.WWPFormDate, T3.WWPFormIsWizard, T3.WWPFormResume, T3.WWPFormResumeMessage, T3.WWPFormValidations, T3.WWPFormInstantiated, T3.WWPFormType, T3.WWPFormSectionRefElements, T3.WWPFormIsForDynamicValidations, TM1.OrganisationId, TM1.LocationId, TM1.ProductServiceId, TM1.LocationDynamicFormId, T2.WWPFormId, T2.WWPFormVersionNumber FROM ((Trn_CallToAction TM1 LEFT JOIN Trn_LocationDynamicForm T2 ON T2.LocationDynamicFormId = TM1.LocationDynamicFormId AND T2.OrganisationId = TM1.OrganisationId AND T2.LocationId = TM1.LocationId) LEFT JOIN WWP_Form T3 ON T3.WWPFormId = T2.WWPFormId AND T3.WWPFormVersionNumber = T2.WWPFormVersionNumber) WHERE TM1.CallToActionId = :CallToActionId ORDER BY TM1.CallToActionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001514,100, GxCacheFrequency.OFF ,true,false )
       };
    }
 }

 public void getResults( int cursor ,
                         IFieldGetter rslt ,
                         Object[] buf )
 {
    switch ( cursor )
    {
          case 0 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((Guid[]) buf[8])[0] = rslt.getGuid(9);
             ((Guid[]) buf[9])[0] = rslt.getGuid(10);
             ((Guid[]) buf[10])[0] = rslt.getGuid(11);
             ((Guid[]) buf[11])[0] = rslt.getGuid(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((Guid[]) buf[8])[0] = rslt.getGuid(9);
             ((Guid[]) buf[9])[0] = rslt.getGuid(10);
             ((Guid[]) buf[10])[0] = rslt.getGuid(11);
             ((Guid[]) buf[11])[0] = rslt.getGuid(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 4 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((short[]) buf[8])[0] = rslt.getShort(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
             ((bool[]) buf[11])[0] = rslt.getBool(12);
             ((short[]) buf[12])[0] = rslt.getShort(13);
             ((string[]) buf[13])[0] = rslt.getLongVarchar(14);
             ((string[]) buf[14])[0] = rslt.getLongVarchar(15);
             ((bool[]) buf[15])[0] = rslt.getBool(16);
             ((short[]) buf[16])[0] = rslt.getShort(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             ((bool[]) buf[18])[0] = rslt.getBool(19);
             ((Guid[]) buf[19])[0] = rslt.getGuid(20);
             ((Guid[]) buf[20])[0] = rslt.getGuid(21);
             ((Guid[]) buf[21])[0] = rslt.getGuid(22);
             ((Guid[]) buf[22])[0] = rslt.getGuid(23);
             ((bool[]) buf[23])[0] = rslt.wasNull(23);
             ((short[]) buf[24])[0] = rslt.getShort(24);
             ((short[]) buf[25])[0] = rslt.getShort(25);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 10 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 11 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((short[]) buf[8])[0] = rslt.getShort(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
             ((bool[]) buf[11])[0] = rslt.getBool(12);
             ((short[]) buf[12])[0] = rslt.getShort(13);
             ((string[]) buf[13])[0] = rslt.getLongVarchar(14);
             ((string[]) buf[14])[0] = rslt.getLongVarchar(15);
             ((bool[]) buf[15])[0] = rslt.getBool(16);
             ((short[]) buf[16])[0] = rslt.getShort(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             ((bool[]) buf[18])[0] = rslt.getBool(19);
             ((Guid[]) buf[19])[0] = rslt.getGuid(20);
             ((Guid[]) buf[20])[0] = rslt.getGuid(21);
             ((Guid[]) buf[21])[0] = rslt.getGuid(22);
             ((Guid[]) buf[22])[0] = rslt.getGuid(23);
             ((bool[]) buf[23])[0] = rslt.wasNull(23);
             ((short[]) buf[24])[0] = rslt.getShort(24);
             ((short[]) buf[25])[0] = rslt.getShort(25);
             return;
    }
 }

}

}
