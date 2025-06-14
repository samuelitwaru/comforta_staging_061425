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
   public class trn_supplierdynamicform_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_supplierdynamicform_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_supplierdynamicform_bc( IGxContext context )
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
         ReadRow1V106( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1V106( ) ;
         standaloneModal( ) ;
         AddRow1V106( ) ;
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
               Z616SupplierDynamicFormId = A616SupplierDynamicFormId;
               Z42SupplierGenId = A42SupplierGenId;
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

      protected void CONFIRM_1V0( )
      {
         BeforeValidate1V106( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1V106( ) ;
            }
            else
            {
               CheckExtendedTable1V106( ) ;
               if ( AnyError == 0 )
               {
                  ZM1V106( 6) ;
                  ZM1V106( 7) ;
               }
               CloseExtendedTableCursors1V106( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1V106( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            Z219WWPFormLatestVersionNumber = A219WWPFormLatestVersionNumber;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z219WWPFormLatestVersionNumber = A219WWPFormLatestVersionNumber;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
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
         if ( GX_JID == -5 )
         {
            Z616SupplierDynamicFormId = A616SupplierDynamicFormId;
            Z42SupplierGenId = A42SupplierGenId;
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
         if ( IsIns( )  && (Guid.Empty==A616SupplierDynamicFormId) )
         {
            A616SupplierDynamicFormId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1V106( )
      {
         /* Using cursor BC001V6 */
         pr_default.execute(4, new Object[] {A616SupplierDynamicFormId, A42SupplierGenId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound106 = 1;
            A208WWPFormReferenceName = BC001V6_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001V6_A209WWPFormTitle[0];
            A231WWPFormDate = BC001V6_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001V6_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001V6_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001V6_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001V6_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001V6_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001V6_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001V6_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001V6_A242WWPFormIsForDynamicValidations[0];
            A206WWPFormId = BC001V6_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001V6_A207WWPFormVersionNumber[0];
            ZM1V106( -5) ;
         }
         pr_default.close(4);
         OnLoadActions1V106( ) ;
      }

      protected void OnLoadActions1V106( )
      {
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
      }

      protected void CheckExtendedTable1V106( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001V4 */
         pr_default.execute(2, new Object[] {A42SupplierGenId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "General Suppliers", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERGENID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC001V5 */
         pr_default.execute(3, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Dynamic Form", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
            AnyError = 1;
         }
         A208WWPFormReferenceName = BC001V5_A208WWPFormReferenceName[0];
         A209WWPFormTitle = BC001V5_A209WWPFormTitle[0];
         A231WWPFormDate = BC001V5_A231WWPFormDate[0];
         A232WWPFormIsWizard = BC001V5_A232WWPFormIsWizard[0];
         A216WWPFormResume = BC001V5_A216WWPFormResume[0];
         A235WWPFormResumeMessage = BC001V5_A235WWPFormResumeMessage[0];
         A233WWPFormValidations = BC001V5_A233WWPFormValidations[0];
         A234WWPFormInstantiated = BC001V5_A234WWPFormInstantiated[0];
         A240WWPFormType = BC001V5_A240WWPFormType[0];
         A241WWPFormSectionRefElements = BC001V5_A241WWPFormSectionRefElements[0];
         A242WWPFormIsForDynamicValidations = BC001V5_A242WWPFormIsForDynamicValidations[0];
         pr_default.close(3);
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
      }

      protected void CloseExtendedTableCursors1V106( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1V106( )
      {
         /* Using cursor BC001V7 */
         pr_default.execute(5, new Object[] {A616SupplierDynamicFormId, A42SupplierGenId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound106 = 1;
         }
         else
         {
            RcdFound106 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001V3 */
         pr_default.execute(1, new Object[] {A616SupplierDynamicFormId, A42SupplierGenId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1V106( 5) ;
            RcdFound106 = 1;
            A616SupplierDynamicFormId = BC001V3_A616SupplierDynamicFormId[0];
            A42SupplierGenId = BC001V3_A42SupplierGenId[0];
            A206WWPFormId = BC001V3_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001V3_A207WWPFormVersionNumber[0];
            Z616SupplierDynamicFormId = A616SupplierDynamicFormId;
            Z42SupplierGenId = A42SupplierGenId;
            sMode106 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1V106( ) ;
            if ( AnyError == 1 )
            {
               RcdFound106 = 0;
               InitializeNonKey1V106( ) ;
            }
            Gx_mode = sMode106;
         }
         else
         {
            RcdFound106 = 0;
            InitializeNonKey1V106( ) ;
            sMode106 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode106;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1V106( ) ;
         if ( RcdFound106 == 0 )
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
         CONFIRM_1V0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1V106( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001V2 */
            pr_default.execute(0, new Object[] {A616SupplierDynamicFormId, A42SupplierGenId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierDynamicForm"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z206WWPFormId != BC001V2_A206WWPFormId[0] ) || ( Z207WWPFormVersionNumber != BC001V2_A207WWPFormVersionNumber[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_SupplierDynamicForm"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1V106( )
      {
         BeforeValidate1V106( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1V106( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1V106( 0) ;
            CheckOptimisticConcurrency1V106( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1V106( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1V106( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001V8 */
                     pr_default.execute(6, new Object[] {A616SupplierDynamicFormId, A42SupplierGenId, A206WWPFormId, A207WWPFormVersionNumber});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierDynamicForm");
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
               Load1V106( ) ;
            }
            EndLevel1V106( ) ;
         }
         CloseExtendedTableCursors1V106( ) ;
      }

      protected void Update1V106( )
      {
         BeforeValidate1V106( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1V106( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1V106( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1V106( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1V106( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001V9 */
                     pr_default.execute(7, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A616SupplierDynamicFormId, A42SupplierGenId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierDynamicForm");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierDynamicForm"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1V106( ) ;
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
            EndLevel1V106( ) ;
         }
         CloseExtendedTableCursors1V106( ) ;
      }

      protected void DeferredUpdate1V106( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1V106( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1V106( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1V106( ) ;
            AfterConfirm1V106( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1V106( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001V10 */
                  pr_default.execute(8, new Object[] {A616SupplierDynamicFormId, A42SupplierGenId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierDynamicForm");
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
         sMode106 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1V106( ) ;
         Gx_mode = sMode106;
      }

      protected void OnDeleteControls1V106( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            /* Using cursor BC001V11 */
            pr_default.execute(9, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            A208WWPFormReferenceName = BC001V11_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001V11_A209WWPFormTitle[0];
            A231WWPFormDate = BC001V11_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001V11_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001V11_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001V11_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001V11_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001V11_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001V11_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001V11_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001V11_A242WWPFormIsForDynamicValidations[0];
            pr_default.close(9);
         }
      }

      protected void EndLevel1V106( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1V106( ) ;
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

      public void ScanKeyStart1V106( )
      {
         /* Using cursor BC001V12 */
         pr_default.execute(10, new Object[] {A616SupplierDynamicFormId, A42SupplierGenId});
         RcdFound106 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound106 = 1;
            A616SupplierDynamicFormId = BC001V12_A616SupplierDynamicFormId[0];
            A208WWPFormReferenceName = BC001V12_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001V12_A209WWPFormTitle[0];
            A231WWPFormDate = BC001V12_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001V12_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001V12_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001V12_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001V12_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001V12_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001V12_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001V12_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001V12_A242WWPFormIsForDynamicValidations[0];
            A42SupplierGenId = BC001V12_A42SupplierGenId[0];
            A206WWPFormId = BC001V12_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001V12_A207WWPFormVersionNumber[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1V106( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound106 = 0;
         ScanKeyLoad1V106( ) ;
      }

      protected void ScanKeyLoad1V106( )
      {
         sMode106 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound106 = 1;
            A616SupplierDynamicFormId = BC001V12_A616SupplierDynamicFormId[0];
            A208WWPFormReferenceName = BC001V12_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001V12_A209WWPFormTitle[0];
            A231WWPFormDate = BC001V12_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001V12_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001V12_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001V12_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001V12_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001V12_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001V12_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001V12_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001V12_A242WWPFormIsForDynamicValidations[0];
            A42SupplierGenId = BC001V12_A42SupplierGenId[0];
            A206WWPFormId = BC001V12_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001V12_A207WWPFormVersionNumber[0];
         }
         Gx_mode = sMode106;
      }

      protected void ScanKeyEnd1V106( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1V106( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1V106( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1V106( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1V106( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1V106( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1V106( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1V106( )
      {
      }

      protected void send_integrity_lvl_hashes1V106( )
      {
      }

      protected void AddRow1V106( )
      {
         VarsToRow106( bcTrn_SupplierDynamicForm) ;
      }

      protected void ReadRow1V106( )
      {
         RowToVars106( bcTrn_SupplierDynamicForm, 1) ;
      }

      protected void InitializeNonKey1V106( )
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
         Z206WWPFormId = 0;
         Z207WWPFormVersionNumber = 0;
      }

      protected void InitAll1V106( )
      {
         A616SupplierDynamicFormId = Guid.NewGuid( );
         A42SupplierGenId = Guid.Empty;
         InitializeNonKey1V106( ) ;
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

      public void VarsToRow106( SdtTrn_SupplierDynamicForm obj106 )
      {
         obj106.gxTpr_Mode = Gx_mode;
         obj106.gxTpr_Wwpformlatestversionnumber = A219WWPFormLatestVersionNumber;
         obj106.gxTpr_Wwpformid = A206WWPFormId;
         obj106.gxTpr_Wwpformversionnumber = A207WWPFormVersionNumber;
         obj106.gxTpr_Wwpformreferencename = A208WWPFormReferenceName;
         obj106.gxTpr_Wwpformtitle = A209WWPFormTitle;
         obj106.gxTpr_Wwpformdate = A231WWPFormDate;
         obj106.gxTpr_Wwpformiswizard = A232WWPFormIsWizard;
         obj106.gxTpr_Wwpformresume = A216WWPFormResume;
         obj106.gxTpr_Wwpformresumemessage = A235WWPFormResumeMessage;
         obj106.gxTpr_Wwpformvalidations = A233WWPFormValidations;
         obj106.gxTpr_Wwpforminstantiated = A234WWPFormInstantiated;
         obj106.gxTpr_Wwpformtype = A240WWPFormType;
         obj106.gxTpr_Wwpformsectionrefelements = A241WWPFormSectionRefElements;
         obj106.gxTpr_Wwpformisfordynamicvalidations = A242WWPFormIsForDynamicValidations;
         obj106.gxTpr_Supplierdynamicformid = A616SupplierDynamicFormId;
         obj106.gxTpr_Suppliergenid = A42SupplierGenId;
         obj106.gxTpr_Supplierdynamicformid_Z = Z616SupplierDynamicFormId;
         obj106.gxTpr_Suppliergenid_Z = Z42SupplierGenId;
         obj106.gxTpr_Wwpformid_Z = Z206WWPFormId;
         obj106.gxTpr_Wwpformversionnumber_Z = Z207WWPFormVersionNumber;
         obj106.gxTpr_Wwpformreferencename_Z = Z208WWPFormReferenceName;
         obj106.gxTpr_Wwpformtitle_Z = Z209WWPFormTitle;
         obj106.gxTpr_Wwpformdate_Z = Z231WWPFormDate;
         obj106.gxTpr_Wwpformiswizard_Z = Z232WWPFormIsWizard;
         obj106.gxTpr_Wwpformresume_Z = Z216WWPFormResume;
         obj106.gxTpr_Wwpforminstantiated_Z = Z234WWPFormInstantiated;
         obj106.gxTpr_Wwpformlatestversionnumber_Z = Z219WWPFormLatestVersionNumber;
         obj106.gxTpr_Wwpformtype_Z = Z240WWPFormType;
         obj106.gxTpr_Wwpformsectionrefelements_Z = Z241WWPFormSectionRefElements;
         obj106.gxTpr_Wwpformisfordynamicvalidations_Z = Z242WWPFormIsForDynamicValidations;
         obj106.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow106( SdtTrn_SupplierDynamicForm obj106 )
      {
         obj106.gxTpr_Supplierdynamicformid = A616SupplierDynamicFormId;
         obj106.gxTpr_Suppliergenid = A42SupplierGenId;
         return  ;
      }

      public void RowToVars106( SdtTrn_SupplierDynamicForm obj106 ,
                                int forceLoad )
      {
         Gx_mode = obj106.gxTpr_Mode;
         A219WWPFormLatestVersionNumber = obj106.gxTpr_Wwpformlatestversionnumber;
         A206WWPFormId = obj106.gxTpr_Wwpformid;
         A207WWPFormVersionNumber = obj106.gxTpr_Wwpformversionnumber;
         A208WWPFormReferenceName = obj106.gxTpr_Wwpformreferencename;
         A209WWPFormTitle = obj106.gxTpr_Wwpformtitle;
         A231WWPFormDate = obj106.gxTpr_Wwpformdate;
         A232WWPFormIsWizard = obj106.gxTpr_Wwpformiswizard;
         A216WWPFormResume = obj106.gxTpr_Wwpformresume;
         A235WWPFormResumeMessage = obj106.gxTpr_Wwpformresumemessage;
         A233WWPFormValidations = obj106.gxTpr_Wwpformvalidations;
         A234WWPFormInstantiated = obj106.gxTpr_Wwpforminstantiated;
         A240WWPFormType = obj106.gxTpr_Wwpformtype;
         A241WWPFormSectionRefElements = obj106.gxTpr_Wwpformsectionrefelements;
         A242WWPFormIsForDynamicValidations = obj106.gxTpr_Wwpformisfordynamicvalidations;
         A616SupplierDynamicFormId = obj106.gxTpr_Supplierdynamicformid;
         A42SupplierGenId = obj106.gxTpr_Suppliergenid;
         Z616SupplierDynamicFormId = obj106.gxTpr_Supplierdynamicformid_Z;
         Z42SupplierGenId = obj106.gxTpr_Suppliergenid_Z;
         Z206WWPFormId = obj106.gxTpr_Wwpformid_Z;
         Z207WWPFormVersionNumber = obj106.gxTpr_Wwpformversionnumber_Z;
         Z208WWPFormReferenceName = obj106.gxTpr_Wwpformreferencename_Z;
         Z209WWPFormTitle = obj106.gxTpr_Wwpformtitle_Z;
         Z231WWPFormDate = obj106.gxTpr_Wwpformdate_Z;
         Z232WWPFormIsWizard = obj106.gxTpr_Wwpformiswizard_Z;
         Z216WWPFormResume = obj106.gxTpr_Wwpformresume_Z;
         Z234WWPFormInstantiated = obj106.gxTpr_Wwpforminstantiated_Z;
         Z219WWPFormLatestVersionNumber = obj106.gxTpr_Wwpformlatestversionnumber_Z;
         Z240WWPFormType = obj106.gxTpr_Wwpformtype_Z;
         Z241WWPFormSectionRefElements = obj106.gxTpr_Wwpformsectionrefelements_Z;
         Z242WWPFormIsForDynamicValidations = obj106.gxTpr_Wwpformisfordynamicvalidations_Z;
         Gx_mode = obj106.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A616SupplierDynamicFormId = (Guid)getParm(obj,0);
         A42SupplierGenId = (Guid)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1V106( ) ;
         ScanKeyStart1V106( ) ;
         if ( RcdFound106 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001V13 */
            pr_default.execute(11, new Object[] {A42SupplierGenId});
            if ( (pr_default.getStatus(11) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "General Suppliers", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERGENID");
               AnyError = 1;
            }
            pr_default.close(11);
         }
         else
         {
            Gx_mode = "UPD";
            Z616SupplierDynamicFormId = A616SupplierDynamicFormId;
            Z42SupplierGenId = A42SupplierGenId;
         }
         ZM1V106( -5) ;
         OnLoadActions1V106( ) ;
         AddRow1V106( ) ;
         ScanKeyEnd1V106( ) ;
         if ( RcdFound106 == 0 )
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
         RowToVars106( bcTrn_SupplierDynamicForm, 0) ;
         ScanKeyStart1V106( ) ;
         if ( RcdFound106 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001V13 */
            pr_default.execute(11, new Object[] {A42SupplierGenId});
            if ( (pr_default.getStatus(11) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "General Suppliers", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERGENID");
               AnyError = 1;
            }
            pr_default.close(11);
         }
         else
         {
            Gx_mode = "UPD";
            Z616SupplierDynamicFormId = A616SupplierDynamicFormId;
            Z42SupplierGenId = A42SupplierGenId;
         }
         ZM1V106( -5) ;
         OnLoadActions1V106( ) ;
         AddRow1V106( ) ;
         ScanKeyEnd1V106( ) ;
         if ( RcdFound106 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1V106( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1V106( ) ;
         }
         else
         {
            if ( RcdFound106 == 1 )
            {
               if ( ( A616SupplierDynamicFormId != Z616SupplierDynamicFormId ) || ( A42SupplierGenId != Z42SupplierGenId ) )
               {
                  A616SupplierDynamicFormId = Z616SupplierDynamicFormId;
                  A42SupplierGenId = Z42SupplierGenId;
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
                  Update1V106( ) ;
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
                  if ( ( A616SupplierDynamicFormId != Z616SupplierDynamicFormId ) || ( A42SupplierGenId != Z42SupplierGenId ) )
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
                        Insert1V106( ) ;
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
                        Insert1V106( ) ;
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
         RowToVars106( bcTrn_SupplierDynamicForm, 1) ;
         SaveImpl( ) ;
         VarsToRow106( bcTrn_SupplierDynamicForm) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars106( bcTrn_SupplierDynamicForm, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1V106( ) ;
         AfterTrn( ) ;
         VarsToRow106( bcTrn_SupplierDynamicForm) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow106( bcTrn_SupplierDynamicForm) ;
         }
         else
         {
            SdtTrn_SupplierDynamicForm auxBC = new SdtTrn_SupplierDynamicForm(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A616SupplierDynamicFormId, A42SupplierGenId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_SupplierDynamicForm);
               auxBC.Save();
               bcTrn_SupplierDynamicForm.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars106( bcTrn_SupplierDynamicForm, 1) ;
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
         RowToVars106( bcTrn_SupplierDynamicForm, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1V106( ) ;
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
               VarsToRow106( bcTrn_SupplierDynamicForm) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow106( bcTrn_SupplierDynamicForm) ;
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
         RowToVars106( bcTrn_SupplierDynamicForm, 0) ;
         GetKey1V106( ) ;
         if ( RcdFound106 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A616SupplierDynamicFormId != Z616SupplierDynamicFormId ) || ( A42SupplierGenId != Z42SupplierGenId ) )
            {
               A616SupplierDynamicFormId = Z616SupplierDynamicFormId;
               A42SupplierGenId = Z42SupplierGenId;
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
            if ( ( A616SupplierDynamicFormId != Z616SupplierDynamicFormId ) || ( A42SupplierGenId != Z42SupplierGenId ) )
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
         context.RollbackDataStores("trn_supplierdynamicform_bc",pr_default);
         VarsToRow106( bcTrn_SupplierDynamicForm) ;
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
         Gx_mode = bcTrn_SupplierDynamicForm.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_SupplierDynamicForm.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_SupplierDynamicForm )
         {
            bcTrn_SupplierDynamicForm = (SdtTrn_SupplierDynamicForm)(sdt);
            if ( StringUtil.StrCmp(bcTrn_SupplierDynamicForm.gxTpr_Mode, "") == 0 )
            {
               bcTrn_SupplierDynamicForm.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow106( bcTrn_SupplierDynamicForm) ;
            }
            else
            {
               RowToVars106( bcTrn_SupplierDynamicForm, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_SupplierDynamicForm.gxTpr_Mode, "") == 0 )
            {
               bcTrn_SupplierDynamicForm.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars106( bcTrn_SupplierDynamicForm, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_SupplierDynamicForm Trn_SupplierDynamicForm_BC
      {
         get {
            return bcTrn_SupplierDynamicForm ;
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
            return "trn_supplierdynamicform_Execute" ;
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
         pr_default.close(11);
         pr_default.close(9);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z616SupplierDynamicFormId = Guid.Empty;
         A616SupplierDynamicFormId = Guid.Empty;
         Z42SupplierGenId = Guid.Empty;
         A42SupplierGenId = Guid.Empty;
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
         BC001V6_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001V6_A208WWPFormReferenceName = new string[] {""} ;
         BC001V6_A209WWPFormTitle = new string[] {""} ;
         BC001V6_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001V6_A232WWPFormIsWizard = new bool[] {false} ;
         BC001V6_A216WWPFormResume = new short[1] ;
         BC001V6_A235WWPFormResumeMessage = new string[] {""} ;
         BC001V6_A233WWPFormValidations = new string[] {""} ;
         BC001V6_A234WWPFormInstantiated = new bool[] {false} ;
         BC001V6_A240WWPFormType = new short[1] ;
         BC001V6_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001V6_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001V6_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC001V6_A206WWPFormId = new short[1] ;
         BC001V6_A207WWPFormVersionNumber = new short[1] ;
         BC001V4_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC001V5_A208WWPFormReferenceName = new string[] {""} ;
         BC001V5_A209WWPFormTitle = new string[] {""} ;
         BC001V5_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001V5_A232WWPFormIsWizard = new bool[] {false} ;
         BC001V5_A216WWPFormResume = new short[1] ;
         BC001V5_A235WWPFormResumeMessage = new string[] {""} ;
         BC001V5_A233WWPFormValidations = new string[] {""} ;
         BC001V5_A234WWPFormInstantiated = new bool[] {false} ;
         BC001V5_A240WWPFormType = new short[1] ;
         BC001V5_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001V5_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001V7_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001V7_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC001V3_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001V3_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC001V3_A206WWPFormId = new short[1] ;
         BC001V3_A207WWPFormVersionNumber = new short[1] ;
         sMode106 = "";
         BC001V2_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001V2_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC001V2_A206WWPFormId = new short[1] ;
         BC001V2_A207WWPFormVersionNumber = new short[1] ;
         BC001V11_A208WWPFormReferenceName = new string[] {""} ;
         BC001V11_A209WWPFormTitle = new string[] {""} ;
         BC001V11_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001V11_A232WWPFormIsWizard = new bool[] {false} ;
         BC001V11_A216WWPFormResume = new short[1] ;
         BC001V11_A235WWPFormResumeMessage = new string[] {""} ;
         BC001V11_A233WWPFormValidations = new string[] {""} ;
         BC001V11_A234WWPFormInstantiated = new bool[] {false} ;
         BC001V11_A240WWPFormType = new short[1] ;
         BC001V11_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001V11_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001V12_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001V12_A208WWPFormReferenceName = new string[] {""} ;
         BC001V12_A209WWPFormTitle = new string[] {""} ;
         BC001V12_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001V12_A232WWPFormIsWizard = new bool[] {false} ;
         BC001V12_A216WWPFormResume = new short[1] ;
         BC001V12_A235WWPFormResumeMessage = new string[] {""} ;
         BC001V12_A233WWPFormValidations = new string[] {""} ;
         BC001V12_A234WWPFormInstantiated = new bool[] {false} ;
         BC001V12_A240WWPFormType = new short[1] ;
         BC001V12_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001V12_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001V12_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC001V12_A206WWPFormId = new short[1] ;
         BC001V12_A207WWPFormVersionNumber = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC001V13_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_supplierdynamicform_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_supplierdynamicform_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_supplierdynamicform_bc__default(),
            new Object[][] {
                new Object[] {
               BC001V2_A616SupplierDynamicFormId, BC001V2_A42SupplierGenId, BC001V2_A206WWPFormId, BC001V2_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC001V3_A616SupplierDynamicFormId, BC001V3_A42SupplierGenId, BC001V3_A206WWPFormId, BC001V3_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC001V4_A42SupplierGenId
               }
               , new Object[] {
               BC001V5_A208WWPFormReferenceName, BC001V5_A209WWPFormTitle, BC001V5_A231WWPFormDate, BC001V5_A232WWPFormIsWizard, BC001V5_A216WWPFormResume, BC001V5_A235WWPFormResumeMessage, BC001V5_A233WWPFormValidations, BC001V5_A234WWPFormInstantiated, BC001V5_A240WWPFormType, BC001V5_A241WWPFormSectionRefElements,
               BC001V5_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               BC001V6_A616SupplierDynamicFormId, BC001V6_A208WWPFormReferenceName, BC001V6_A209WWPFormTitle, BC001V6_A231WWPFormDate, BC001V6_A232WWPFormIsWizard, BC001V6_A216WWPFormResume, BC001V6_A235WWPFormResumeMessage, BC001V6_A233WWPFormValidations, BC001V6_A234WWPFormInstantiated, BC001V6_A240WWPFormType,
               BC001V6_A241WWPFormSectionRefElements, BC001V6_A242WWPFormIsForDynamicValidations, BC001V6_A42SupplierGenId, BC001V6_A206WWPFormId, BC001V6_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC001V7_A616SupplierDynamicFormId, BC001V7_A42SupplierGenId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001V11_A208WWPFormReferenceName, BC001V11_A209WWPFormTitle, BC001V11_A231WWPFormDate, BC001V11_A232WWPFormIsWizard, BC001V11_A216WWPFormResume, BC001V11_A235WWPFormResumeMessage, BC001V11_A233WWPFormValidations, BC001V11_A234WWPFormInstantiated, BC001V11_A240WWPFormType, BC001V11_A241WWPFormSectionRefElements,
               BC001V11_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               BC001V12_A616SupplierDynamicFormId, BC001V12_A208WWPFormReferenceName, BC001V12_A209WWPFormTitle, BC001V12_A231WWPFormDate, BC001V12_A232WWPFormIsWizard, BC001V12_A216WWPFormResume, BC001V12_A235WWPFormResumeMessage, BC001V12_A233WWPFormValidations, BC001V12_A234WWPFormInstantiated, BC001V12_A240WWPFormType,
               BC001V12_A241WWPFormSectionRefElements, BC001V12_A242WWPFormIsForDynamicValidations, BC001V12_A42SupplierGenId, BC001V12_A206WWPFormId, BC001V12_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC001V13_A42SupplierGenId
               }
            }
         );
         Z616SupplierDynamicFormId = Guid.NewGuid( );
         A616SupplierDynamicFormId = Guid.NewGuid( );
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
      private short RcdFound106 ;
      private short GXt_int1 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode106 ;
      private DateTime Z231WWPFormDate ;
      private DateTime A231WWPFormDate ;
      private bool Z232WWPFormIsWizard ;
      private bool A232WWPFormIsWizard ;
      private bool Z234WWPFormInstantiated ;
      private bool A234WWPFormInstantiated ;
      private bool Z242WWPFormIsForDynamicValidations ;
      private bool A242WWPFormIsForDynamicValidations ;
      private string Z235WWPFormResumeMessage ;
      private string A235WWPFormResumeMessage ;
      private string Z233WWPFormValidations ;
      private string A233WWPFormValidations ;
      private string Z208WWPFormReferenceName ;
      private string A208WWPFormReferenceName ;
      private string Z209WWPFormTitle ;
      private string A209WWPFormTitle ;
      private string Z241WWPFormSectionRefElements ;
      private string A241WWPFormSectionRefElements ;
      private Guid Z616SupplierDynamicFormId ;
      private Guid A616SupplierDynamicFormId ;
      private Guid Z42SupplierGenId ;
      private Guid A42SupplierGenId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001V6_A616SupplierDynamicFormId ;
      private string[] BC001V6_A208WWPFormReferenceName ;
      private string[] BC001V6_A209WWPFormTitle ;
      private DateTime[] BC001V6_A231WWPFormDate ;
      private bool[] BC001V6_A232WWPFormIsWizard ;
      private short[] BC001V6_A216WWPFormResume ;
      private string[] BC001V6_A235WWPFormResumeMessage ;
      private string[] BC001V6_A233WWPFormValidations ;
      private bool[] BC001V6_A234WWPFormInstantiated ;
      private short[] BC001V6_A240WWPFormType ;
      private string[] BC001V6_A241WWPFormSectionRefElements ;
      private bool[] BC001V6_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001V6_A42SupplierGenId ;
      private short[] BC001V6_A206WWPFormId ;
      private short[] BC001V6_A207WWPFormVersionNumber ;
      private Guid[] BC001V4_A42SupplierGenId ;
      private string[] BC001V5_A208WWPFormReferenceName ;
      private string[] BC001V5_A209WWPFormTitle ;
      private DateTime[] BC001V5_A231WWPFormDate ;
      private bool[] BC001V5_A232WWPFormIsWizard ;
      private short[] BC001V5_A216WWPFormResume ;
      private string[] BC001V5_A235WWPFormResumeMessage ;
      private string[] BC001V5_A233WWPFormValidations ;
      private bool[] BC001V5_A234WWPFormInstantiated ;
      private short[] BC001V5_A240WWPFormType ;
      private string[] BC001V5_A241WWPFormSectionRefElements ;
      private bool[] BC001V5_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001V7_A616SupplierDynamicFormId ;
      private Guid[] BC001V7_A42SupplierGenId ;
      private Guid[] BC001V3_A616SupplierDynamicFormId ;
      private Guid[] BC001V3_A42SupplierGenId ;
      private short[] BC001V3_A206WWPFormId ;
      private short[] BC001V3_A207WWPFormVersionNumber ;
      private Guid[] BC001V2_A616SupplierDynamicFormId ;
      private Guid[] BC001V2_A42SupplierGenId ;
      private short[] BC001V2_A206WWPFormId ;
      private short[] BC001V2_A207WWPFormVersionNumber ;
      private string[] BC001V11_A208WWPFormReferenceName ;
      private string[] BC001V11_A209WWPFormTitle ;
      private DateTime[] BC001V11_A231WWPFormDate ;
      private bool[] BC001V11_A232WWPFormIsWizard ;
      private short[] BC001V11_A216WWPFormResume ;
      private string[] BC001V11_A235WWPFormResumeMessage ;
      private string[] BC001V11_A233WWPFormValidations ;
      private bool[] BC001V11_A234WWPFormInstantiated ;
      private short[] BC001V11_A240WWPFormType ;
      private string[] BC001V11_A241WWPFormSectionRefElements ;
      private bool[] BC001V11_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001V12_A616SupplierDynamicFormId ;
      private string[] BC001V12_A208WWPFormReferenceName ;
      private string[] BC001V12_A209WWPFormTitle ;
      private DateTime[] BC001V12_A231WWPFormDate ;
      private bool[] BC001V12_A232WWPFormIsWizard ;
      private short[] BC001V12_A216WWPFormResume ;
      private string[] BC001V12_A235WWPFormResumeMessage ;
      private string[] BC001V12_A233WWPFormValidations ;
      private bool[] BC001V12_A234WWPFormInstantiated ;
      private short[] BC001V12_A240WWPFormType ;
      private string[] BC001V12_A241WWPFormSectionRefElements ;
      private bool[] BC001V12_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001V12_A42SupplierGenId ;
      private short[] BC001V12_A206WWPFormId ;
      private short[] BC001V12_A207WWPFormVersionNumber ;
      private SdtTrn_SupplierDynamicForm bcTrn_SupplierDynamicForm ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid[] BC001V13_A42SupplierGenId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_supplierdynamicform_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_supplierdynamicform_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_supplierdynamicform_bc__default : DataStoreHelperBase, IDataStoreHelper
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
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC001V2;
       prmBC001V2 = new Object[] {
       new ParDef("SupplierDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001V3;
       prmBC001V3 = new Object[] {
       new ParDef("SupplierDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001V4;
       prmBC001V4 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001V5;
       prmBC001V5 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001V6;
       prmBC001V6 = new Object[] {
       new ParDef("SupplierDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001V7;
       prmBC001V7 = new Object[] {
       new ParDef("SupplierDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001V8;
       prmBC001V8 = new Object[] {
       new ParDef("SupplierDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001V9;
       prmBC001V9 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("SupplierDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001V10;
       prmBC001V10 = new Object[] {
       new ParDef("SupplierDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001V11;
       prmBC001V11 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001V12;
       prmBC001V12 = new Object[] {
       new ParDef("SupplierDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001V13;
       prmBC001V13 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001V2", "SELECT SupplierDynamicFormId, SupplierGenId, WWPFormId, WWPFormVersionNumber FROM Trn_SupplierDynamicForm WHERE SupplierDynamicFormId = :SupplierDynamicFormId AND SupplierGenId = :SupplierGenId  FOR UPDATE OF Trn_SupplierDynamicForm",true, GxErrorMask.GX_NOMASK, false, this,prmBC001V2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001V3", "SELECT SupplierDynamicFormId, SupplierGenId, WWPFormId, WWPFormVersionNumber FROM Trn_SupplierDynamicForm WHERE SupplierDynamicFormId = :SupplierDynamicFormId AND SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001V3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001V4", "SELECT SupplierGenId FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001V4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001V5", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001V5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001V6", "SELECT TM1.SupplierDynamicFormId, T2.WWPFormReferenceName, T2.WWPFormTitle, T2.WWPFormDate, T2.WWPFormIsWizard, T2.WWPFormResume, T2.WWPFormResumeMessage, T2.WWPFormValidations, T2.WWPFormInstantiated, T2.WWPFormType, T2.WWPFormSectionRefElements, T2.WWPFormIsForDynamicValidations, TM1.SupplierGenId, TM1.WWPFormId, TM1.WWPFormVersionNumber FROM (Trn_SupplierDynamicForm TM1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = TM1.WWPFormId AND T2.WWPFormVersionNumber = TM1.WWPFormVersionNumber) WHERE TM1.SupplierDynamicFormId = :SupplierDynamicFormId and TM1.SupplierGenId = :SupplierGenId ORDER BY TM1.SupplierDynamicFormId, TM1.SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001V6,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001V7", "SELECT SupplierDynamicFormId, SupplierGenId FROM Trn_SupplierDynamicForm WHERE SupplierDynamicFormId = :SupplierDynamicFormId AND SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001V7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001V8", "SAVEPOINT gxupdate;INSERT INTO Trn_SupplierDynamicForm(SupplierDynamicFormId, SupplierGenId, WWPFormId, WWPFormVersionNumber) VALUES(:SupplierDynamicFormId, :SupplierGenId, :WWPFormId, :WWPFormVersionNumber);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001V8)
          ,new CursorDef("BC001V9", "SAVEPOINT gxupdate;UPDATE Trn_SupplierDynamicForm SET WWPFormId=:WWPFormId, WWPFormVersionNumber=:WWPFormVersionNumber  WHERE SupplierDynamicFormId = :SupplierDynamicFormId AND SupplierGenId = :SupplierGenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001V9)
          ,new CursorDef("BC001V10", "SAVEPOINT gxupdate;DELETE FROM Trn_SupplierDynamicForm  WHERE SupplierDynamicFormId = :SupplierDynamicFormId AND SupplierGenId = :SupplierGenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001V10)
          ,new CursorDef("BC001V11", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001V11,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001V12", "SELECT TM1.SupplierDynamicFormId, T2.WWPFormReferenceName, T2.WWPFormTitle, T2.WWPFormDate, T2.WWPFormIsWizard, T2.WWPFormResume, T2.WWPFormResumeMessage, T2.WWPFormValidations, T2.WWPFormInstantiated, T2.WWPFormType, T2.WWPFormSectionRefElements, T2.WWPFormIsForDynamicValidations, TM1.SupplierGenId, TM1.WWPFormId, TM1.WWPFormVersionNumber FROM (Trn_SupplierDynamicForm TM1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = TM1.WWPFormId AND T2.WWPFormVersionNumber = TM1.WWPFormVersionNumber) WHERE TM1.SupplierDynamicFormId = :SupplierDynamicFormId and TM1.SupplierGenId = :SupplierGenId ORDER BY TM1.SupplierDynamicFormId, TM1.SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001V12,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001V13", "SELECT SupplierGenId FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001V13,1, GxCacheFrequency.OFF ,true,false )
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
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
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
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((bool[]) buf[4])[0] = rslt.getBool(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((short[]) buf[9])[0] = rslt.getShort(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((bool[]) buf[11])[0] = rslt.getBool(12);
             ((Guid[]) buf[12])[0] = rslt.getGuid(13);
             ((short[]) buf[13])[0] = rslt.getShort(14);
             ((short[]) buf[14])[0] = rslt.getShort(15);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
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
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((bool[]) buf[4])[0] = rslt.getBool(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((short[]) buf[9])[0] = rslt.getShort(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((bool[]) buf[11])[0] = rslt.getBool(12);
             ((Guid[]) buf[12])[0] = rslt.getGuid(13);
             ((short[]) buf[13])[0] = rslt.getShort(14);
             ((short[]) buf[14])[0] = rslt.getShort(15);
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
