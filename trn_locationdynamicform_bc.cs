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
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class trn_locationdynamicform_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_locationdynamicform_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_locationdynamicform_bc( IGxContext context )
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
         ReadRow1470( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1470( ) ;
         standaloneModal( ) ;
         AddRow1470( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z366LocationDynamicFormId = A366LocationDynamicFormId;
               Z11OrganisationId = A11OrganisationId;
               Z29LocationId = A29LocationId;
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

      protected void CONFIRM_140( )
      {
         BeforeValidate1470( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1470( ) ;
            }
            else
            {
               CheckExtendedTable1470( ) ;
               if ( AnyError == 0 )
               {
                  ZM1470( 8) ;
                  ZM1470( 9) ;
               }
               CloseExtendedTableCursors1470( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1470( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z619FormPageName = A619FormPageName;
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            Z219WWPFormLatestVersionNumber = A219WWPFormLatestVersionNumber;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z219WWPFormLatestVersionNumber = A219WWPFormLatestVersionNumber;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
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
         if ( GX_JID == -7 )
         {
            Z366LocationDynamicFormId = A366LocationDynamicFormId;
            Z619FormPageName = A619FormPageName;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
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
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A366LocationDynamicFormId) )
         {
            A366LocationDynamicFormId = Guid.NewGuid( );
            n366LocationDynamicFormId = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1470( )
      {
         /* Using cursor BC00146 */
         pr_default.execute(4, new Object[] {n366LocationDynamicFormId, A366LocationDynamicFormId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound70 = 1;
            A619FormPageName = BC00146_A619FormPageName[0];
            A208WWPFormReferenceName = BC00146_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC00146_A209WWPFormTitle[0];
            A231WWPFormDate = BC00146_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC00146_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC00146_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC00146_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC00146_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC00146_A234WWPFormInstantiated[0];
            A240WWPFormType = BC00146_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC00146_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC00146_A242WWPFormIsForDynamicValidations[0];
            A206WWPFormId = BC00146_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC00146_A207WWPFormVersionNumber[0];
            ZM1470( -7) ;
         }
         pr_default.close(4);
         OnLoadActions1470( ) ;
      }

      protected void OnLoadActions1470( )
      {
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A619FormPageName)) && ( Gx_BScreen == 0 ) )
         {
            A619FormPageName = A209WWPFormTitle;
         }
      }

      protected void CheckExtendedTable1470( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00144 */
         pr_default.execute(2, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC00145 */
         pr_default.execute(3, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Dynamic Form", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
            AnyError = 1;
         }
         A208WWPFormReferenceName = BC00145_A208WWPFormReferenceName[0];
         A209WWPFormTitle = BC00145_A209WWPFormTitle[0];
         A231WWPFormDate = BC00145_A231WWPFormDate[0];
         A232WWPFormIsWizard = BC00145_A232WWPFormIsWizard[0];
         A216WWPFormResume = BC00145_A216WWPFormResume[0];
         A235WWPFormResumeMessage = BC00145_A235WWPFormResumeMessage[0];
         A233WWPFormValidations = BC00145_A233WWPFormValidations[0];
         A234WWPFormInstantiated = BC00145_A234WWPFormInstantiated[0];
         A240WWPFormType = BC00145_A240WWPFormType[0];
         A241WWPFormSectionRefElements = BC00145_A241WWPFormSectionRefElements[0];
         A242WWPFormIsForDynamicValidations = BC00145_A242WWPFormIsForDynamicValidations[0];
         pr_default.close(3);
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A619FormPageName)) && ( Gx_BScreen == 0 ) )
         {
            A619FormPageName = A209WWPFormTitle;
         }
      }

      protected void CloseExtendedTableCursors1470( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1470( )
      {
         /* Using cursor BC00147 */
         pr_default.execute(5, new Object[] {n366LocationDynamicFormId, A366LocationDynamicFormId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound70 = 1;
         }
         else
         {
            RcdFound70 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00143 */
         pr_default.execute(1, new Object[] {n366LocationDynamicFormId, A366LocationDynamicFormId, A11OrganisationId, A29LocationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1470( 7) ;
            RcdFound70 = 1;
            A366LocationDynamicFormId = BC00143_A366LocationDynamicFormId[0];
            n366LocationDynamicFormId = BC00143_n366LocationDynamicFormId[0];
            A619FormPageName = BC00143_A619FormPageName[0];
            A11OrganisationId = BC00143_A11OrganisationId[0];
            A29LocationId = BC00143_A29LocationId[0];
            A206WWPFormId = BC00143_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC00143_A207WWPFormVersionNumber[0];
            Z366LocationDynamicFormId = A366LocationDynamicFormId;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
            sMode70 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1470( ) ;
            if ( AnyError == 1 )
            {
               RcdFound70 = 0;
               InitializeNonKey1470( ) ;
            }
            Gx_mode = sMode70;
         }
         else
         {
            RcdFound70 = 0;
            InitializeNonKey1470( ) ;
            sMode70 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode70;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1470( ) ;
         if ( RcdFound70 == 0 )
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
         CONFIRM_140( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1470( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00142 */
            pr_default.execute(0, new Object[] {n366LocationDynamicFormId, A366LocationDynamicFormId, A11OrganisationId, A29LocationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_LocationDynamicForm"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z619FormPageName, BC00142_A619FormPageName[0]) != 0 ) || ( Z206WWPFormId != BC00142_A206WWPFormId[0] ) || ( Z207WWPFormVersionNumber != BC00142_A207WWPFormVersionNumber[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_LocationDynamicForm"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1470( )
      {
         BeforeValidate1470( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1470( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1470( 0) ;
            CheckOptimisticConcurrency1470( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1470( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1470( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00148 */
                     pr_default.execute(6, new Object[] {n366LocationDynamicFormId, A366LocationDynamicFormId, A619FormPageName, A11OrganisationId, A29LocationId, A206WWPFormId, A207WWPFormVersionNumber});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_LocationDynamicForm");
                     if ( (pr_default.getStatus(6) == 1) )
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
               Load1470( ) ;
            }
            EndLevel1470( ) ;
         }
         CloseExtendedTableCursors1470( ) ;
      }

      protected void Update1470( )
      {
         BeforeValidate1470( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1470( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1470( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1470( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1470( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00149 */
                     pr_default.execute(7, new Object[] {A619FormPageName, A206WWPFormId, A207WWPFormVersionNumber, n366LocationDynamicFormId, A366LocationDynamicFormId, A11OrganisationId, A29LocationId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_LocationDynamicForm");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_LocationDynamicForm"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1470( ) ;
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
            EndLevel1470( ) ;
         }
         CloseExtendedTableCursors1470( ) ;
      }

      protected void DeferredUpdate1470( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1470( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1470( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1470( ) ;
            AfterConfirm1470( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1470( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001410 */
                  pr_default.execute(8, new Object[] {n366LocationDynamicFormId, A366LocationDynamicFormId, A11OrganisationId, A29LocationId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_LocationDynamicForm");
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
         sMode70 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1470( ) ;
         Gx_mode = sMode70;
      }

      protected void OnDeleteControls1470( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            /* Using cursor BC001411 */
            pr_default.execute(9, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            A208WWPFormReferenceName = BC001411_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001411_A209WWPFormTitle[0];
            A231WWPFormDate = BC001411_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001411_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001411_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001411_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001411_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001411_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001411_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001411_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001411_A242WWPFormIsForDynamicValidations[0];
            pr_default.close(9);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001412 */
            pr_default.execute(10, new Object[] {n366LocationDynamicFormId, A366LocationDynamicFormId, A11OrganisationId, A29LocationId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Call To Actions", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel1470( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1470( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
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

      public void ScanKeyStart1470( )
      {
         /* Using cursor BC001413 */
         pr_default.execute(11, new Object[] {n366LocationDynamicFormId, A366LocationDynamicFormId, A11OrganisationId, A29LocationId});
         RcdFound70 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound70 = 1;
            A366LocationDynamicFormId = BC001413_A366LocationDynamicFormId[0];
            n366LocationDynamicFormId = BC001413_n366LocationDynamicFormId[0];
            A619FormPageName = BC001413_A619FormPageName[0];
            A208WWPFormReferenceName = BC001413_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001413_A209WWPFormTitle[0];
            A231WWPFormDate = BC001413_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001413_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001413_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001413_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001413_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001413_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001413_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001413_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001413_A242WWPFormIsForDynamicValidations[0];
            A11OrganisationId = BC001413_A11OrganisationId[0];
            A29LocationId = BC001413_A29LocationId[0];
            A206WWPFormId = BC001413_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001413_A207WWPFormVersionNumber[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1470( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound70 = 0;
         ScanKeyLoad1470( ) ;
      }

      protected void ScanKeyLoad1470( )
      {
         sMode70 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound70 = 1;
            A366LocationDynamicFormId = BC001413_A366LocationDynamicFormId[0];
            n366LocationDynamicFormId = BC001413_n366LocationDynamicFormId[0];
            A619FormPageName = BC001413_A619FormPageName[0];
            A208WWPFormReferenceName = BC001413_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001413_A209WWPFormTitle[0];
            A231WWPFormDate = BC001413_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001413_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001413_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001413_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001413_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001413_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001413_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001413_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001413_A242WWPFormIsForDynamicValidations[0];
            A11OrganisationId = BC001413_A11OrganisationId[0];
            A29LocationId = BC001413_A29LocationId[0];
            A206WWPFormId = BC001413_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001413_A207WWPFormVersionNumber[0];
         }
         Gx_mode = sMode70;
      }

      protected void ScanKeyEnd1470( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm1470( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1470( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1470( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1470( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1470( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1470( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1470( )
      {
      }

      protected void send_integrity_lvl_hashes1470( )
      {
      }

      protected void AddRow1470( )
      {
         VarsToRow70( bcTrn_LocationDynamicForm) ;
      }

      protected void ReadRow1470( )
      {
         RowToVars70( bcTrn_LocationDynamicForm, 1) ;
      }

      protected void InitializeNonKey1470( )
      {
         A219WWPFormLatestVersionNumber = 0;
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
         A619FormPageName = "";
         Z619FormPageName = "";
         Z206WWPFormId = 0;
         Z207WWPFormVersionNumber = 0;
      }

      protected void InitAll1470( )
      {
         A366LocationDynamicFormId = Guid.NewGuid( );
         n366LocationDynamicFormId = false;
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         InitializeNonKey1470( ) ;
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

      public void VarsToRow70( SdtTrn_LocationDynamicForm obj70 )
      {
         obj70.gxTpr_Mode = Gx_mode;
         obj70.gxTpr_Wwpformlatestversionnumber = A219WWPFormLatestVersionNumber;
         obj70.gxTpr_Wwpformid = A206WWPFormId;
         obj70.gxTpr_Wwpformversionnumber = A207WWPFormVersionNumber;
         obj70.gxTpr_Wwpformreferencename = A208WWPFormReferenceName;
         obj70.gxTpr_Wwpformtitle = A209WWPFormTitle;
         obj70.gxTpr_Wwpformdate = A231WWPFormDate;
         obj70.gxTpr_Wwpformiswizard = A232WWPFormIsWizard;
         obj70.gxTpr_Wwpformresume = A216WWPFormResume;
         obj70.gxTpr_Wwpformresumemessage = A235WWPFormResumeMessage;
         obj70.gxTpr_Wwpformvalidations = A233WWPFormValidations;
         obj70.gxTpr_Wwpforminstantiated = A234WWPFormInstantiated;
         obj70.gxTpr_Wwpformtype = A240WWPFormType;
         obj70.gxTpr_Wwpformsectionrefelements = A241WWPFormSectionRefElements;
         obj70.gxTpr_Wwpformisfordynamicvalidations = A242WWPFormIsForDynamicValidations;
         obj70.gxTpr_Formpagename = A619FormPageName;
         obj70.gxTpr_Locationdynamicformid = A366LocationDynamicFormId;
         obj70.gxTpr_Organisationid = A11OrganisationId;
         obj70.gxTpr_Locationid = A29LocationId;
         obj70.gxTpr_Locationdynamicformid_Z = Z366LocationDynamicFormId;
         obj70.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj70.gxTpr_Locationid_Z = Z29LocationId;
         obj70.gxTpr_Formpagename_Z = Z619FormPageName;
         obj70.gxTpr_Wwpformid_Z = Z206WWPFormId;
         obj70.gxTpr_Wwpformversionnumber_Z = Z207WWPFormVersionNumber;
         obj70.gxTpr_Wwpformreferencename_Z = Z208WWPFormReferenceName;
         obj70.gxTpr_Wwpformtitle_Z = Z209WWPFormTitle;
         obj70.gxTpr_Wwpformdate_Z = Z231WWPFormDate;
         obj70.gxTpr_Wwpformiswizard_Z = Z232WWPFormIsWizard;
         obj70.gxTpr_Wwpformresume_Z = Z216WWPFormResume;
         obj70.gxTpr_Wwpforminstantiated_Z = Z234WWPFormInstantiated;
         obj70.gxTpr_Wwpformlatestversionnumber_Z = Z219WWPFormLatestVersionNumber;
         obj70.gxTpr_Wwpformtype_Z = Z240WWPFormType;
         obj70.gxTpr_Wwpformsectionrefelements_Z = Z241WWPFormSectionRefElements;
         obj70.gxTpr_Wwpformisfordynamicvalidations_Z = Z242WWPFormIsForDynamicValidations;
         obj70.gxTpr_Locationdynamicformid_N = (short)(Convert.ToInt16(n366LocationDynamicFormId));
         obj70.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow70( SdtTrn_LocationDynamicForm obj70 )
      {
         obj70.gxTpr_Locationdynamicformid = A366LocationDynamicFormId;
         obj70.gxTpr_Organisationid = A11OrganisationId;
         obj70.gxTpr_Locationid = A29LocationId;
         return  ;
      }

      public void RowToVars70( SdtTrn_LocationDynamicForm obj70 ,
                               int forceLoad )
      {
         Gx_mode = obj70.gxTpr_Mode;
         A219WWPFormLatestVersionNumber = obj70.gxTpr_Wwpformlatestversionnumber;
         A206WWPFormId = obj70.gxTpr_Wwpformid;
         A207WWPFormVersionNumber = obj70.gxTpr_Wwpformversionnumber;
         A208WWPFormReferenceName = obj70.gxTpr_Wwpformreferencename;
         A209WWPFormTitle = obj70.gxTpr_Wwpformtitle;
         A231WWPFormDate = obj70.gxTpr_Wwpformdate;
         A232WWPFormIsWizard = obj70.gxTpr_Wwpformiswizard;
         A216WWPFormResume = obj70.gxTpr_Wwpformresume;
         A235WWPFormResumeMessage = obj70.gxTpr_Wwpformresumemessage;
         A233WWPFormValidations = obj70.gxTpr_Wwpformvalidations;
         A234WWPFormInstantiated = obj70.gxTpr_Wwpforminstantiated;
         A240WWPFormType = obj70.gxTpr_Wwpformtype;
         A241WWPFormSectionRefElements = obj70.gxTpr_Wwpformsectionrefelements;
         A242WWPFormIsForDynamicValidations = obj70.gxTpr_Wwpformisfordynamicvalidations;
         A619FormPageName = obj70.gxTpr_Formpagename;
         A366LocationDynamicFormId = obj70.gxTpr_Locationdynamicformid;
         n366LocationDynamicFormId = false;
         A11OrganisationId = obj70.gxTpr_Organisationid;
         A29LocationId = obj70.gxTpr_Locationid;
         Z366LocationDynamicFormId = obj70.gxTpr_Locationdynamicformid_Z;
         Z11OrganisationId = obj70.gxTpr_Organisationid_Z;
         Z29LocationId = obj70.gxTpr_Locationid_Z;
         Z619FormPageName = obj70.gxTpr_Formpagename_Z;
         Z206WWPFormId = obj70.gxTpr_Wwpformid_Z;
         Z207WWPFormVersionNumber = obj70.gxTpr_Wwpformversionnumber_Z;
         Z208WWPFormReferenceName = obj70.gxTpr_Wwpformreferencename_Z;
         Z209WWPFormTitle = obj70.gxTpr_Wwpformtitle_Z;
         Z231WWPFormDate = obj70.gxTpr_Wwpformdate_Z;
         Z232WWPFormIsWizard = obj70.gxTpr_Wwpformiswizard_Z;
         Z216WWPFormResume = obj70.gxTpr_Wwpformresume_Z;
         Z234WWPFormInstantiated = obj70.gxTpr_Wwpforminstantiated_Z;
         Z219WWPFormLatestVersionNumber = obj70.gxTpr_Wwpformlatestversionnumber_Z;
         Z240WWPFormType = obj70.gxTpr_Wwpformtype_Z;
         Z241WWPFormSectionRefElements = obj70.gxTpr_Wwpformsectionrefelements_Z;
         Z242WWPFormIsForDynamicValidations = obj70.gxTpr_Wwpformisfordynamicvalidations_Z;
         n366LocationDynamicFormId = (bool)(Convert.ToBoolean(obj70.gxTpr_Locationdynamicformid_N));
         Gx_mode = obj70.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A366LocationDynamicFormId = (Guid)getParm(obj,0);
         n366LocationDynamicFormId = false;
         A11OrganisationId = (Guid)getParm(obj,1);
         A29LocationId = (Guid)getParm(obj,2);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1470( ) ;
         ScanKeyStart1470( ) ;
         if ( RcdFound70 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001414 */
            pr_default.execute(12, new Object[] {A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(12) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(12);
         }
         else
         {
            Gx_mode = "UPD";
            Z366LocationDynamicFormId = A366LocationDynamicFormId;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
         }
         ZM1470( -7) ;
         OnLoadActions1470( ) ;
         AddRow1470( ) ;
         ScanKeyEnd1470( ) ;
         if ( RcdFound70 == 0 )
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
         RowToVars70( bcTrn_LocationDynamicForm, 0) ;
         ScanKeyStart1470( ) ;
         if ( RcdFound70 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001414 */
            pr_default.execute(12, new Object[] {A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(12) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(12);
         }
         else
         {
            Gx_mode = "UPD";
            Z366LocationDynamicFormId = A366LocationDynamicFormId;
            Z11OrganisationId = A11OrganisationId;
            Z29LocationId = A29LocationId;
         }
         ZM1470( -7) ;
         OnLoadActions1470( ) ;
         AddRow1470( ) ;
         ScanKeyEnd1470( ) ;
         if ( RcdFound70 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1470( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1470( ) ;
         }
         else
         {
            if ( RcdFound70 == 1 )
            {
               if ( ( A366LocationDynamicFormId != Z366LocationDynamicFormId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) )
               {
                  A366LocationDynamicFormId = Z366LocationDynamicFormId;
                  n366LocationDynamicFormId = false;
                  A11OrganisationId = Z11OrganisationId;
                  A29LocationId = Z29LocationId;
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
                  Update1470( ) ;
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
                  if ( ( A366LocationDynamicFormId != Z366LocationDynamicFormId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) )
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
                        Insert1470( ) ;
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
                        Insert1470( ) ;
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
         RowToVars70( bcTrn_LocationDynamicForm, 1) ;
         SaveImpl( ) ;
         VarsToRow70( bcTrn_LocationDynamicForm) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars70( bcTrn_LocationDynamicForm, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1470( ) ;
         AfterTrn( ) ;
         VarsToRow70( bcTrn_LocationDynamicForm) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow70( bcTrn_LocationDynamicForm) ;
         }
         else
         {
            SdtTrn_LocationDynamicForm auxBC = new SdtTrn_LocationDynamicForm(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A366LocationDynamicFormId, A11OrganisationId, A29LocationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_LocationDynamicForm);
               auxBC.Save();
               bcTrn_LocationDynamicForm.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars70( bcTrn_LocationDynamicForm, 1) ;
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
         RowToVars70( bcTrn_LocationDynamicForm, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1470( ) ;
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
               VarsToRow70( bcTrn_LocationDynamicForm) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow70( bcTrn_LocationDynamicForm) ;
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
         RowToVars70( bcTrn_LocationDynamicForm, 0) ;
         GetKey1470( ) ;
         if ( RcdFound70 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A366LocationDynamicFormId != Z366LocationDynamicFormId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) )
            {
               A366LocationDynamicFormId = Z366LocationDynamicFormId;
               n366LocationDynamicFormId = false;
               A11OrganisationId = Z11OrganisationId;
               A29LocationId = Z29LocationId;
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
            if ( ( A366LocationDynamicFormId != Z366LocationDynamicFormId ) || ( A11OrganisationId != Z11OrganisationId ) || ( A29LocationId != Z29LocationId ) )
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
         context.RollbackDataStores("trn_locationdynamicform_bc",pr_default);
         VarsToRow70( bcTrn_LocationDynamicForm) ;
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
         Gx_mode = bcTrn_LocationDynamicForm.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_LocationDynamicForm.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_LocationDynamicForm )
         {
            bcTrn_LocationDynamicForm = (SdtTrn_LocationDynamicForm)(sdt);
            if ( StringUtil.StrCmp(bcTrn_LocationDynamicForm.gxTpr_Mode, "") == 0 )
            {
               bcTrn_LocationDynamicForm.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow70( bcTrn_LocationDynamicForm) ;
            }
            else
            {
               RowToVars70( bcTrn_LocationDynamicForm, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_LocationDynamicForm.gxTpr_Mode, "") == 0 )
            {
               bcTrn_LocationDynamicForm.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars70( bcTrn_LocationDynamicForm, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_LocationDynamicForm Trn_LocationDynamicForm_BC
      {
         get {
            return bcTrn_LocationDynamicForm ;
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
            return "trn_loacationdynamicform_Execute" ;
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
         pr_default.close(12);
         pr_default.close(9);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z366LocationDynamicFormId = Guid.Empty;
         A366LocationDynamicFormId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z619FormPageName = "";
         A619FormPageName = "";
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
         BC00146_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC00146_n366LocationDynamicFormId = new bool[] {false} ;
         BC00146_A619FormPageName = new string[] {""} ;
         BC00146_A208WWPFormReferenceName = new string[] {""} ;
         BC00146_A209WWPFormTitle = new string[] {""} ;
         BC00146_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC00146_A232WWPFormIsWizard = new bool[] {false} ;
         BC00146_A216WWPFormResume = new short[1] ;
         BC00146_A235WWPFormResumeMessage = new string[] {""} ;
         BC00146_A233WWPFormValidations = new string[] {""} ;
         BC00146_A234WWPFormInstantiated = new bool[] {false} ;
         BC00146_A240WWPFormType = new short[1] ;
         BC00146_A241WWPFormSectionRefElements = new string[] {""} ;
         BC00146_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC00146_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00146_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00146_A206WWPFormId = new short[1] ;
         BC00146_A207WWPFormVersionNumber = new short[1] ;
         BC00144_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00145_A208WWPFormReferenceName = new string[] {""} ;
         BC00145_A209WWPFormTitle = new string[] {""} ;
         BC00145_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC00145_A232WWPFormIsWizard = new bool[] {false} ;
         BC00145_A216WWPFormResume = new short[1] ;
         BC00145_A235WWPFormResumeMessage = new string[] {""} ;
         BC00145_A233WWPFormValidations = new string[] {""} ;
         BC00145_A234WWPFormInstantiated = new bool[] {false} ;
         BC00145_A240WWPFormType = new short[1] ;
         BC00145_A241WWPFormSectionRefElements = new string[] {""} ;
         BC00145_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC00147_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC00147_n366LocationDynamicFormId = new bool[] {false} ;
         BC00147_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00147_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00143_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC00143_n366LocationDynamicFormId = new bool[] {false} ;
         BC00143_A619FormPageName = new string[] {""} ;
         BC00143_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00143_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00143_A206WWPFormId = new short[1] ;
         BC00143_A207WWPFormVersionNumber = new short[1] ;
         sMode70 = "";
         BC00142_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC00142_n366LocationDynamicFormId = new bool[] {false} ;
         BC00142_A619FormPageName = new string[] {""} ;
         BC00142_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00142_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00142_A206WWPFormId = new short[1] ;
         BC00142_A207WWPFormVersionNumber = new short[1] ;
         BC001411_A208WWPFormReferenceName = new string[] {""} ;
         BC001411_A209WWPFormTitle = new string[] {""} ;
         BC001411_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001411_A232WWPFormIsWizard = new bool[] {false} ;
         BC001411_A216WWPFormResume = new short[1] ;
         BC001411_A235WWPFormResumeMessage = new string[] {""} ;
         BC001411_A233WWPFormValidations = new string[] {""} ;
         BC001411_A234WWPFormInstantiated = new bool[] {false} ;
         BC001411_A240WWPFormType = new short[1] ;
         BC001411_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001411_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001412_A339CallToActionId = new Guid[] {Guid.Empty} ;
         BC001413_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001413_n366LocationDynamicFormId = new bool[] {false} ;
         BC001413_A619FormPageName = new string[] {""} ;
         BC001413_A208WWPFormReferenceName = new string[] {""} ;
         BC001413_A209WWPFormTitle = new string[] {""} ;
         BC001413_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001413_A232WWPFormIsWizard = new bool[] {false} ;
         BC001413_A216WWPFormResume = new short[1] ;
         BC001413_A235WWPFormResumeMessage = new string[] {""} ;
         BC001413_A233WWPFormValidations = new string[] {""} ;
         BC001413_A234WWPFormInstantiated = new bool[] {false} ;
         BC001413_A240WWPFormType = new short[1] ;
         BC001413_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001413_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001413_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001413_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001413_A206WWPFormId = new short[1] ;
         BC001413_A207WWPFormVersionNumber = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC001414_A29LocationId = new Guid[] {Guid.Empty} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_locationdynamicform_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_locationdynamicform_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_locationdynamicform_bc__default(),
            new Object[][] {
                new Object[] {
               BC00142_A366LocationDynamicFormId, BC00142_A619FormPageName, BC00142_A11OrganisationId, BC00142_A29LocationId, BC00142_A206WWPFormId, BC00142_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC00143_A366LocationDynamicFormId, BC00143_A619FormPageName, BC00143_A11OrganisationId, BC00143_A29LocationId, BC00143_A206WWPFormId, BC00143_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC00144_A29LocationId
               }
               , new Object[] {
               BC00145_A208WWPFormReferenceName, BC00145_A209WWPFormTitle, BC00145_A231WWPFormDate, BC00145_A232WWPFormIsWizard, BC00145_A216WWPFormResume, BC00145_A235WWPFormResumeMessage, BC00145_A233WWPFormValidations, BC00145_A234WWPFormInstantiated, BC00145_A240WWPFormType, BC00145_A241WWPFormSectionRefElements,
               BC00145_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               BC00146_A366LocationDynamicFormId, BC00146_A619FormPageName, BC00146_A208WWPFormReferenceName, BC00146_A209WWPFormTitle, BC00146_A231WWPFormDate, BC00146_A232WWPFormIsWizard, BC00146_A216WWPFormResume, BC00146_A235WWPFormResumeMessage, BC00146_A233WWPFormValidations, BC00146_A234WWPFormInstantiated,
               BC00146_A240WWPFormType, BC00146_A241WWPFormSectionRefElements, BC00146_A242WWPFormIsForDynamicValidations, BC00146_A11OrganisationId, BC00146_A29LocationId, BC00146_A206WWPFormId, BC00146_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC00147_A366LocationDynamicFormId, BC00147_A11OrganisationId, BC00147_A29LocationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001411_A208WWPFormReferenceName, BC001411_A209WWPFormTitle, BC001411_A231WWPFormDate, BC001411_A232WWPFormIsWizard, BC001411_A216WWPFormResume, BC001411_A235WWPFormResumeMessage, BC001411_A233WWPFormValidations, BC001411_A234WWPFormInstantiated, BC001411_A240WWPFormType, BC001411_A241WWPFormSectionRefElements,
               BC001411_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               BC001412_A339CallToActionId
               }
               , new Object[] {
               BC001413_A366LocationDynamicFormId, BC001413_A619FormPageName, BC001413_A208WWPFormReferenceName, BC001413_A209WWPFormTitle, BC001413_A231WWPFormDate, BC001413_A232WWPFormIsWizard, BC001413_A216WWPFormResume, BC001413_A235WWPFormResumeMessage, BC001413_A233WWPFormValidations, BC001413_A234WWPFormInstantiated,
               BC001413_A240WWPFormType, BC001413_A241WWPFormSectionRefElements, BC001413_A242WWPFormIsForDynamicValidations, BC001413_A11OrganisationId, BC001413_A29LocationId, BC001413_A206WWPFormId, BC001413_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC001414_A29LocationId
               }
            }
         );
         Z366LocationDynamicFormId = Guid.NewGuid( );
         n366LocationDynamicFormId = false;
         A366LocationDynamicFormId = Guid.NewGuid( );
         n366LocationDynamicFormId = false;
         Z619FormPageName = "";
         A619FormPageName = "";
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z206WWPFormId ;
      private short A206WWPFormId ;
      private short Z207WWPFormVersionNumber ;
      private short A207WWPFormVersionNumber ;
      private short Z219WWPFormLatestVersionNumber ;
      private short A219WWPFormLatestVersionNumber ;
      private short Z216WWPFormResume ;
      private short A216WWPFormResume ;
      private short Z240WWPFormType ;
      private short A240WWPFormType ;
      private short Gx_BScreen ;
      private short RcdFound70 ;
      private short GXt_int1 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode70 ;
      private DateTime Z231WWPFormDate ;
      private DateTime A231WWPFormDate ;
      private bool Z232WWPFormIsWizard ;
      private bool A232WWPFormIsWizard ;
      private bool Z234WWPFormInstantiated ;
      private bool A234WWPFormInstantiated ;
      private bool Z242WWPFormIsForDynamicValidations ;
      private bool A242WWPFormIsForDynamicValidations ;
      private bool n366LocationDynamicFormId ;
      private string Z235WWPFormResumeMessage ;
      private string A235WWPFormResumeMessage ;
      private string Z233WWPFormValidations ;
      private string A233WWPFormValidations ;
      private string Z619FormPageName ;
      private string A619FormPageName ;
      private string Z208WWPFormReferenceName ;
      private string A208WWPFormReferenceName ;
      private string Z209WWPFormTitle ;
      private string A209WWPFormTitle ;
      private string Z241WWPFormSectionRefElements ;
      private string A241WWPFormSectionRefElements ;
      private Guid Z366LocationDynamicFormId ;
      private Guid A366LocationDynamicFormId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00146_A366LocationDynamicFormId ;
      private bool[] BC00146_n366LocationDynamicFormId ;
      private string[] BC00146_A619FormPageName ;
      private string[] BC00146_A208WWPFormReferenceName ;
      private string[] BC00146_A209WWPFormTitle ;
      private DateTime[] BC00146_A231WWPFormDate ;
      private bool[] BC00146_A232WWPFormIsWizard ;
      private short[] BC00146_A216WWPFormResume ;
      private string[] BC00146_A235WWPFormResumeMessage ;
      private string[] BC00146_A233WWPFormValidations ;
      private bool[] BC00146_A234WWPFormInstantiated ;
      private short[] BC00146_A240WWPFormType ;
      private string[] BC00146_A241WWPFormSectionRefElements ;
      private bool[] BC00146_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC00146_A11OrganisationId ;
      private Guid[] BC00146_A29LocationId ;
      private short[] BC00146_A206WWPFormId ;
      private short[] BC00146_A207WWPFormVersionNumber ;
      private Guid[] BC00144_A29LocationId ;
      private string[] BC00145_A208WWPFormReferenceName ;
      private string[] BC00145_A209WWPFormTitle ;
      private DateTime[] BC00145_A231WWPFormDate ;
      private bool[] BC00145_A232WWPFormIsWizard ;
      private short[] BC00145_A216WWPFormResume ;
      private string[] BC00145_A235WWPFormResumeMessage ;
      private string[] BC00145_A233WWPFormValidations ;
      private bool[] BC00145_A234WWPFormInstantiated ;
      private short[] BC00145_A240WWPFormType ;
      private string[] BC00145_A241WWPFormSectionRefElements ;
      private bool[] BC00145_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC00147_A366LocationDynamicFormId ;
      private bool[] BC00147_n366LocationDynamicFormId ;
      private Guid[] BC00147_A11OrganisationId ;
      private Guid[] BC00147_A29LocationId ;
      private Guid[] BC00143_A366LocationDynamicFormId ;
      private bool[] BC00143_n366LocationDynamicFormId ;
      private string[] BC00143_A619FormPageName ;
      private Guid[] BC00143_A11OrganisationId ;
      private Guid[] BC00143_A29LocationId ;
      private short[] BC00143_A206WWPFormId ;
      private short[] BC00143_A207WWPFormVersionNumber ;
      private Guid[] BC00142_A366LocationDynamicFormId ;
      private bool[] BC00142_n366LocationDynamicFormId ;
      private string[] BC00142_A619FormPageName ;
      private Guid[] BC00142_A11OrganisationId ;
      private Guid[] BC00142_A29LocationId ;
      private short[] BC00142_A206WWPFormId ;
      private short[] BC00142_A207WWPFormVersionNumber ;
      private string[] BC001411_A208WWPFormReferenceName ;
      private string[] BC001411_A209WWPFormTitle ;
      private DateTime[] BC001411_A231WWPFormDate ;
      private bool[] BC001411_A232WWPFormIsWizard ;
      private short[] BC001411_A216WWPFormResume ;
      private string[] BC001411_A235WWPFormResumeMessage ;
      private string[] BC001411_A233WWPFormValidations ;
      private bool[] BC001411_A234WWPFormInstantiated ;
      private short[] BC001411_A240WWPFormType ;
      private string[] BC001411_A241WWPFormSectionRefElements ;
      private bool[] BC001411_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001412_A339CallToActionId ;
      private Guid[] BC001413_A366LocationDynamicFormId ;
      private bool[] BC001413_n366LocationDynamicFormId ;
      private string[] BC001413_A619FormPageName ;
      private string[] BC001413_A208WWPFormReferenceName ;
      private string[] BC001413_A209WWPFormTitle ;
      private DateTime[] BC001413_A231WWPFormDate ;
      private bool[] BC001413_A232WWPFormIsWizard ;
      private short[] BC001413_A216WWPFormResume ;
      private string[] BC001413_A235WWPFormResumeMessage ;
      private string[] BC001413_A233WWPFormValidations ;
      private bool[] BC001413_A234WWPFormInstantiated ;
      private short[] BC001413_A240WWPFormType ;
      private string[] BC001413_A241WWPFormSectionRefElements ;
      private bool[] BC001413_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001413_A11OrganisationId ;
      private Guid[] BC001413_A29LocationId ;
      private short[] BC001413_A206WWPFormId ;
      private short[] BC001413_A207WWPFormVersionNumber ;
      private SdtTrn_LocationDynamicForm bcTrn_LocationDynamicForm ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid[] BC001414_A29LocationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_locationdynamicform_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_locationdynamicform_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_locationdynamicform_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[6])
      ,new UpdateCursor(def[7])
      ,new UpdateCursor(def[8])
      ,new ForEachCursor(def[9])
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
       Object[] prmBC00142;
       prmBC00142 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00143;
       prmBC00143 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00144;
       prmBC00144 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00145;
       prmBC00145 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC00146;
       prmBC00146 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00147;
       prmBC00147 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00148;
       prmBC00148 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("FormPageName",GXType.VarChar,100,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC00149;
       prmBC00149 = new Object[] {
       new ParDef("FormPageName",GXType.VarChar,100,0) ,
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001410;
       prmBC001410 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001411;
       prmBC001411 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001412;
       prmBC001412 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001413;
       prmBC001413 = new Object[] {
       new ParDef("LocationDynamicFormId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001414;
       prmBC001414 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC00142", "SELECT LocationDynamicFormId, FormPageName, OrganisationId, LocationId, WWPFormId, WWPFormVersionNumber FROM Trn_LocationDynamicForm WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId  FOR UPDATE OF Trn_LocationDynamicForm",true, GxErrorMask.GX_NOMASK, false, this,prmBC00142,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00143", "SELECT LocationDynamicFormId, FormPageName, OrganisationId, LocationId, WWPFormId, WWPFormVersionNumber FROM Trn_LocationDynamicForm WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00143,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00144", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00144,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00145", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00145,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00146", "SELECT TM1.LocationDynamicFormId, TM1.FormPageName, T2.WWPFormReferenceName, T2.WWPFormTitle, T2.WWPFormDate, T2.WWPFormIsWizard, T2.WWPFormResume, T2.WWPFormResumeMessage, T2.WWPFormValidations, T2.WWPFormInstantiated, T2.WWPFormType, T2.WWPFormSectionRefElements, T2.WWPFormIsForDynamicValidations, TM1.OrganisationId, TM1.LocationId, TM1.WWPFormId, TM1.WWPFormVersionNumber FROM (Trn_LocationDynamicForm TM1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = TM1.WWPFormId AND T2.WWPFormVersionNumber = TM1.WWPFormVersionNumber) WHERE TM1.LocationDynamicFormId = :LocationDynamicFormId and TM1.OrganisationId = :OrganisationId and TM1.LocationId = :LocationId ORDER BY TM1.LocationDynamicFormId, TM1.OrganisationId, TM1.LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00146,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00147", "SELECT LocationDynamicFormId, OrganisationId, LocationId FROM Trn_LocationDynamicForm WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00147,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00148", "SAVEPOINT gxupdate;INSERT INTO Trn_LocationDynamicForm(LocationDynamicFormId, FormPageName, OrganisationId, LocationId, WWPFormId, WWPFormVersionNumber) VALUES(:LocationDynamicFormId, :FormPageName, :OrganisationId, :LocationId, :WWPFormId, :WWPFormVersionNumber);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00148)
          ,new CursorDef("BC00149", "SAVEPOINT gxupdate;UPDATE Trn_LocationDynamicForm SET FormPageName=:FormPageName, WWPFormId=:WWPFormId, WWPFormVersionNumber=:WWPFormVersionNumber  WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00149)
          ,new CursorDef("BC001410", "SAVEPOINT gxupdate;DELETE FROM Trn_LocationDynamicForm  WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001410)
          ,new CursorDef("BC001411", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001411,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001412", "SELECT CallToActionId FROM Trn_CallToAction WHERE LocationDynamicFormId = :LocationDynamicFormId AND OrganisationId = :OrganisationId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001412,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC001413", "SELECT TM1.LocationDynamicFormId, TM1.FormPageName, T2.WWPFormReferenceName, T2.WWPFormTitle, T2.WWPFormDate, T2.WWPFormIsWizard, T2.WWPFormResume, T2.WWPFormResumeMessage, T2.WWPFormValidations, T2.WWPFormInstantiated, T2.WWPFormType, T2.WWPFormSectionRefElements, T2.WWPFormIsForDynamicValidations, TM1.OrganisationId, TM1.LocationId, TM1.WWPFormId, TM1.WWPFormVersionNumber FROM (Trn_LocationDynamicForm TM1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = TM1.WWPFormId AND T2.WWPFormVersionNumber = TM1.WWPFormVersionNumber) WHERE TM1.LocationDynamicFormId = :LocationDynamicFormId and TM1.OrganisationId = :OrganisationId and TM1.LocationId = :LocationId ORDER BY TM1.LocationDynamicFormId, TM1.OrganisationId, TM1.LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001413,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001414", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001414,1, GxCacheFrequency.OFF ,true,false )
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
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
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
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
             ((bool[]) buf[5])[0] = rslt.getBool(6);
             ((short[]) buf[6])[0] = rslt.getShort(7);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
             ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((short[]) buf[10])[0] = rslt.getShort(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((bool[]) buf[12])[0] = rslt.getBool(13);
             ((Guid[]) buf[13])[0] = rslt.getGuid(14);
             ((Guid[]) buf[14])[0] = rslt.getGuid(15);
             ((short[]) buf[15])[0] = rslt.getShort(16);
             ((short[]) buf[16])[0] = rslt.getShort(17);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 9 :
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
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
             ((bool[]) buf[5])[0] = rslt.getBool(6);
             ((short[]) buf[6])[0] = rslt.getShort(7);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
             ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((short[]) buf[10])[0] = rslt.getShort(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((bool[]) buf[12])[0] = rslt.getBool(13);
             ((Guid[]) buf[13])[0] = rslt.getGuid(14);
             ((Guid[]) buf[14])[0] = rslt.getGuid(15);
             ((short[]) buf[15])[0] = rslt.getShort(16);
             ((short[]) buf[16])[0] = rslt.getShort(17);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
