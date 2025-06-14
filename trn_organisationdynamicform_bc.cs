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
   public class trn_organisationdynamicform_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_organisationdynamicform_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_organisationdynamicform_bc( IGxContext context )
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
         ReadRow1H89( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1H89( ) ;
         standaloneModal( ) ;
         AddRow1H89( ) ;
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
               Z509OrganisationDynamicFormId = A509OrganisationDynamicFormId;
               Z11OrganisationId = A11OrganisationId;
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

      protected void CONFIRM_1H0( )
      {
         BeforeValidate1H89( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1H89( ) ;
            }
            else
            {
               CheckExtendedTable1H89( ) ;
               if ( AnyError == 0 )
               {
                  ZM1H89( 6) ;
                  ZM1H89( 7) ;
               }
               CloseExtendedTableCursors1H89( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1H89( short GX_JID )
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
            Z509OrganisationDynamicFormId = A509OrganisationDynamicFormId;
            Z11OrganisationId = A11OrganisationId;
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
         if ( IsIns( )  && (Guid.Empty==A509OrganisationDynamicFormId) )
         {
            A509OrganisationDynamicFormId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1H89( )
      {
         /* Using cursor BC001H6 */
         pr_default.execute(4, new Object[] {A509OrganisationDynamicFormId, A11OrganisationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound89 = 1;
            A208WWPFormReferenceName = BC001H6_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001H6_A209WWPFormTitle[0];
            A231WWPFormDate = BC001H6_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001H6_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001H6_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001H6_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001H6_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001H6_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001H6_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001H6_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001H6_A242WWPFormIsForDynamicValidations[0];
            A206WWPFormId = BC001H6_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001H6_A207WWPFormVersionNumber[0];
            ZM1H89( -5) ;
         }
         pr_default.close(4);
         OnLoadActions1H89( ) ;
      }

      protected void OnLoadActions1H89( )
      {
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
      }

      protected void CheckExtendedTable1H89( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001H4 */
         pr_default.execute(2, new Object[] {A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC001H5 */
         pr_default.execute(3, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Dynamic Form", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
            AnyError = 1;
         }
         A208WWPFormReferenceName = BC001H5_A208WWPFormReferenceName[0];
         A209WWPFormTitle = BC001H5_A209WWPFormTitle[0];
         A231WWPFormDate = BC001H5_A231WWPFormDate[0];
         A232WWPFormIsWizard = BC001H5_A232WWPFormIsWizard[0];
         A216WWPFormResume = BC001H5_A216WWPFormResume[0];
         A235WWPFormResumeMessage = BC001H5_A235WWPFormResumeMessage[0];
         A233WWPFormValidations = BC001H5_A233WWPFormValidations[0];
         A234WWPFormInstantiated = BC001H5_A234WWPFormInstantiated[0];
         A240WWPFormType = BC001H5_A240WWPFormType[0];
         A241WWPFormSectionRefElements = BC001H5_A241WWPFormSectionRefElements[0];
         A242WWPFormIsForDynamicValidations = BC001H5_A242WWPFormIsForDynamicValidations[0];
         pr_default.close(3);
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
      }

      protected void CloseExtendedTableCursors1H89( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1H89( )
      {
         /* Using cursor BC001H7 */
         pr_default.execute(5, new Object[] {A509OrganisationDynamicFormId, A11OrganisationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound89 = 1;
         }
         else
         {
            RcdFound89 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001H3 */
         pr_default.execute(1, new Object[] {A509OrganisationDynamicFormId, A11OrganisationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1H89( 5) ;
            RcdFound89 = 1;
            A509OrganisationDynamicFormId = BC001H3_A509OrganisationDynamicFormId[0];
            A11OrganisationId = BC001H3_A11OrganisationId[0];
            A206WWPFormId = BC001H3_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001H3_A207WWPFormVersionNumber[0];
            Z509OrganisationDynamicFormId = A509OrganisationDynamicFormId;
            Z11OrganisationId = A11OrganisationId;
            sMode89 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1H89( ) ;
            if ( AnyError == 1 )
            {
               RcdFound89 = 0;
               InitializeNonKey1H89( ) ;
            }
            Gx_mode = sMode89;
         }
         else
         {
            RcdFound89 = 0;
            InitializeNonKey1H89( ) ;
            sMode89 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode89;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1H89( ) ;
         if ( RcdFound89 == 0 )
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
         CONFIRM_1H0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1H89( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001H2 */
            pr_default.execute(0, new Object[] {A509OrganisationDynamicFormId, A11OrganisationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_OrganisationDynamicForm"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z206WWPFormId != BC001H2_A206WWPFormId[0] ) || ( Z207WWPFormVersionNumber != BC001H2_A207WWPFormVersionNumber[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_OrganisationDynamicForm"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1H89( )
      {
         BeforeValidate1H89( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1H89( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1H89( 0) ;
            CheckOptimisticConcurrency1H89( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1H89( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1H89( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001H8 */
                     pr_default.execute(6, new Object[] {A509OrganisationDynamicFormId, A11OrganisationId, A206WWPFormId, A207WWPFormVersionNumber});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationDynamicForm");
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
               Load1H89( ) ;
            }
            EndLevel1H89( ) ;
         }
         CloseExtendedTableCursors1H89( ) ;
      }

      protected void Update1H89( )
      {
         BeforeValidate1H89( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1H89( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1H89( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1H89( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1H89( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001H9 */
                     pr_default.execute(7, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A509OrganisationDynamicFormId, A11OrganisationId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationDynamicForm");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_OrganisationDynamicForm"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1H89( ) ;
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
            EndLevel1H89( ) ;
         }
         CloseExtendedTableCursors1H89( ) ;
      }

      protected void DeferredUpdate1H89( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1H89( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1H89( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1H89( ) ;
            AfterConfirm1H89( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1H89( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001H10 */
                  pr_default.execute(8, new Object[] {A509OrganisationDynamicFormId, A11OrganisationId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationDynamicForm");
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
         sMode89 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1H89( ) ;
         Gx_mode = sMode89;
      }

      protected void OnDeleteControls1H89( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
            /* Using cursor BC001H11 */
            pr_default.execute(9, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            A208WWPFormReferenceName = BC001H11_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001H11_A209WWPFormTitle[0];
            A231WWPFormDate = BC001H11_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001H11_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001H11_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001H11_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001H11_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001H11_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001H11_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001H11_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001H11_A242WWPFormIsForDynamicValidations[0];
            pr_default.close(9);
         }
      }

      protected void EndLevel1H89( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1H89( ) ;
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

      public void ScanKeyStart1H89( )
      {
         /* Using cursor BC001H12 */
         pr_default.execute(10, new Object[] {A509OrganisationDynamicFormId, A11OrganisationId});
         RcdFound89 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound89 = 1;
            A509OrganisationDynamicFormId = BC001H12_A509OrganisationDynamicFormId[0];
            A208WWPFormReferenceName = BC001H12_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001H12_A209WWPFormTitle[0];
            A231WWPFormDate = BC001H12_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001H12_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001H12_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001H12_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001H12_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001H12_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001H12_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001H12_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001H12_A242WWPFormIsForDynamicValidations[0];
            A11OrganisationId = BC001H12_A11OrganisationId[0];
            A206WWPFormId = BC001H12_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001H12_A207WWPFormVersionNumber[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1H89( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound89 = 0;
         ScanKeyLoad1H89( ) ;
      }

      protected void ScanKeyLoad1H89( )
      {
         sMode89 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound89 = 1;
            A509OrganisationDynamicFormId = BC001H12_A509OrganisationDynamicFormId[0];
            A208WWPFormReferenceName = BC001H12_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001H12_A209WWPFormTitle[0];
            A231WWPFormDate = BC001H12_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001H12_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001H12_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001H12_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001H12_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001H12_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001H12_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001H12_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001H12_A242WWPFormIsForDynamicValidations[0];
            A11OrganisationId = BC001H12_A11OrganisationId[0];
            A206WWPFormId = BC001H12_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001H12_A207WWPFormVersionNumber[0];
         }
         Gx_mode = sMode89;
      }

      protected void ScanKeyEnd1H89( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1H89( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1H89( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1H89( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1H89( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1H89( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1H89( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1H89( )
      {
      }

      protected void send_integrity_lvl_hashes1H89( )
      {
      }

      protected void AddRow1H89( )
      {
         VarsToRow89( bcTrn_OrganisationDynamicForm) ;
      }

      protected void ReadRow1H89( )
      {
         RowToVars89( bcTrn_OrganisationDynamicForm, 1) ;
      }

      protected void InitializeNonKey1H89( )
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

      protected void InitAll1H89( )
      {
         A509OrganisationDynamicFormId = Guid.NewGuid( );
         A11OrganisationId = Guid.Empty;
         InitializeNonKey1H89( ) ;
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

      public void VarsToRow89( SdtTrn_OrganisationDynamicForm obj89 )
      {
         obj89.gxTpr_Mode = Gx_mode;
         obj89.gxTpr_Wwpformlatestversionnumber = A219WWPFormLatestVersionNumber;
         obj89.gxTpr_Wwpformid = A206WWPFormId;
         obj89.gxTpr_Wwpformversionnumber = A207WWPFormVersionNumber;
         obj89.gxTpr_Wwpformreferencename = A208WWPFormReferenceName;
         obj89.gxTpr_Wwpformtitle = A209WWPFormTitle;
         obj89.gxTpr_Wwpformdate = A231WWPFormDate;
         obj89.gxTpr_Wwpformiswizard = A232WWPFormIsWizard;
         obj89.gxTpr_Wwpformresume = A216WWPFormResume;
         obj89.gxTpr_Wwpformresumemessage = A235WWPFormResumeMessage;
         obj89.gxTpr_Wwpformvalidations = A233WWPFormValidations;
         obj89.gxTpr_Wwpforminstantiated = A234WWPFormInstantiated;
         obj89.gxTpr_Wwpformtype = A240WWPFormType;
         obj89.gxTpr_Wwpformsectionrefelements = A241WWPFormSectionRefElements;
         obj89.gxTpr_Wwpformisfordynamicvalidations = A242WWPFormIsForDynamicValidations;
         obj89.gxTpr_Organisationdynamicformid = A509OrganisationDynamicFormId;
         obj89.gxTpr_Organisationid = A11OrganisationId;
         obj89.gxTpr_Organisationdynamicformid_Z = Z509OrganisationDynamicFormId;
         obj89.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj89.gxTpr_Wwpformid_Z = Z206WWPFormId;
         obj89.gxTpr_Wwpformversionnumber_Z = Z207WWPFormVersionNumber;
         obj89.gxTpr_Wwpformreferencename_Z = Z208WWPFormReferenceName;
         obj89.gxTpr_Wwpformtitle_Z = Z209WWPFormTitle;
         obj89.gxTpr_Wwpformdate_Z = Z231WWPFormDate;
         obj89.gxTpr_Wwpformiswizard_Z = Z232WWPFormIsWizard;
         obj89.gxTpr_Wwpformresume_Z = Z216WWPFormResume;
         obj89.gxTpr_Wwpforminstantiated_Z = Z234WWPFormInstantiated;
         obj89.gxTpr_Wwpformlatestversionnumber_Z = Z219WWPFormLatestVersionNumber;
         obj89.gxTpr_Wwpformtype_Z = Z240WWPFormType;
         obj89.gxTpr_Wwpformsectionrefelements_Z = Z241WWPFormSectionRefElements;
         obj89.gxTpr_Wwpformisfordynamicvalidations_Z = Z242WWPFormIsForDynamicValidations;
         obj89.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow89( SdtTrn_OrganisationDynamicForm obj89 )
      {
         obj89.gxTpr_Organisationdynamicformid = A509OrganisationDynamicFormId;
         obj89.gxTpr_Organisationid = A11OrganisationId;
         return  ;
      }

      public void RowToVars89( SdtTrn_OrganisationDynamicForm obj89 ,
                               int forceLoad )
      {
         Gx_mode = obj89.gxTpr_Mode;
         A219WWPFormLatestVersionNumber = obj89.gxTpr_Wwpformlatestversionnumber;
         A206WWPFormId = obj89.gxTpr_Wwpformid;
         A207WWPFormVersionNumber = obj89.gxTpr_Wwpformversionnumber;
         A208WWPFormReferenceName = obj89.gxTpr_Wwpformreferencename;
         A209WWPFormTitle = obj89.gxTpr_Wwpformtitle;
         A231WWPFormDate = obj89.gxTpr_Wwpformdate;
         A232WWPFormIsWizard = obj89.gxTpr_Wwpformiswizard;
         A216WWPFormResume = obj89.gxTpr_Wwpformresume;
         A235WWPFormResumeMessage = obj89.gxTpr_Wwpformresumemessage;
         A233WWPFormValidations = obj89.gxTpr_Wwpformvalidations;
         A234WWPFormInstantiated = obj89.gxTpr_Wwpforminstantiated;
         A240WWPFormType = obj89.gxTpr_Wwpformtype;
         A241WWPFormSectionRefElements = obj89.gxTpr_Wwpformsectionrefelements;
         A242WWPFormIsForDynamicValidations = obj89.gxTpr_Wwpformisfordynamicvalidations;
         A509OrganisationDynamicFormId = obj89.gxTpr_Organisationdynamicformid;
         A11OrganisationId = obj89.gxTpr_Organisationid;
         Z509OrganisationDynamicFormId = obj89.gxTpr_Organisationdynamicformid_Z;
         Z11OrganisationId = obj89.gxTpr_Organisationid_Z;
         Z206WWPFormId = obj89.gxTpr_Wwpformid_Z;
         Z207WWPFormVersionNumber = obj89.gxTpr_Wwpformversionnumber_Z;
         Z208WWPFormReferenceName = obj89.gxTpr_Wwpformreferencename_Z;
         Z209WWPFormTitle = obj89.gxTpr_Wwpformtitle_Z;
         Z231WWPFormDate = obj89.gxTpr_Wwpformdate_Z;
         Z232WWPFormIsWizard = obj89.gxTpr_Wwpformiswizard_Z;
         Z216WWPFormResume = obj89.gxTpr_Wwpformresume_Z;
         Z234WWPFormInstantiated = obj89.gxTpr_Wwpforminstantiated_Z;
         Z219WWPFormLatestVersionNumber = obj89.gxTpr_Wwpformlatestversionnumber_Z;
         Z240WWPFormType = obj89.gxTpr_Wwpformtype_Z;
         Z241WWPFormSectionRefElements = obj89.gxTpr_Wwpformsectionrefelements_Z;
         Z242WWPFormIsForDynamicValidations = obj89.gxTpr_Wwpformisfordynamicvalidations_Z;
         Gx_mode = obj89.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A509OrganisationDynamicFormId = (Guid)getParm(obj,0);
         A11OrganisationId = (Guid)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1H89( ) ;
         ScanKeyStart1H89( ) ;
         if ( RcdFound89 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001H13 */
            pr_default.execute(11, new Object[] {A11OrganisationId});
            if ( (pr_default.getStatus(11) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(11);
         }
         else
         {
            Gx_mode = "UPD";
            Z509OrganisationDynamicFormId = A509OrganisationDynamicFormId;
            Z11OrganisationId = A11OrganisationId;
         }
         ZM1H89( -5) ;
         OnLoadActions1H89( ) ;
         AddRow1H89( ) ;
         ScanKeyEnd1H89( ) ;
         if ( RcdFound89 == 0 )
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
         RowToVars89( bcTrn_OrganisationDynamicForm, 0) ;
         ScanKeyStart1H89( ) ;
         if ( RcdFound89 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001H13 */
            pr_default.execute(11, new Object[] {A11OrganisationId});
            if ( (pr_default.getStatus(11) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(11);
         }
         else
         {
            Gx_mode = "UPD";
            Z509OrganisationDynamicFormId = A509OrganisationDynamicFormId;
            Z11OrganisationId = A11OrganisationId;
         }
         ZM1H89( -5) ;
         OnLoadActions1H89( ) ;
         AddRow1H89( ) ;
         ScanKeyEnd1H89( ) ;
         if ( RcdFound89 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1H89( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1H89( ) ;
         }
         else
         {
            if ( RcdFound89 == 1 )
            {
               if ( ( A509OrganisationDynamicFormId != Z509OrganisationDynamicFormId ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  A509OrganisationDynamicFormId = Z509OrganisationDynamicFormId;
                  A11OrganisationId = Z11OrganisationId;
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
                  Update1H89( ) ;
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
                  if ( ( A509OrganisationDynamicFormId != Z509OrganisationDynamicFormId ) || ( A11OrganisationId != Z11OrganisationId ) )
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
                        Insert1H89( ) ;
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
                        Insert1H89( ) ;
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
         RowToVars89( bcTrn_OrganisationDynamicForm, 1) ;
         SaveImpl( ) ;
         VarsToRow89( bcTrn_OrganisationDynamicForm) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars89( bcTrn_OrganisationDynamicForm, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1H89( ) ;
         AfterTrn( ) ;
         VarsToRow89( bcTrn_OrganisationDynamicForm) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow89( bcTrn_OrganisationDynamicForm) ;
         }
         else
         {
            SdtTrn_OrganisationDynamicForm auxBC = new SdtTrn_OrganisationDynamicForm(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A509OrganisationDynamicFormId, A11OrganisationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_OrganisationDynamicForm);
               auxBC.Save();
               bcTrn_OrganisationDynamicForm.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars89( bcTrn_OrganisationDynamicForm, 1) ;
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
         RowToVars89( bcTrn_OrganisationDynamicForm, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1H89( ) ;
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
               VarsToRow89( bcTrn_OrganisationDynamicForm) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow89( bcTrn_OrganisationDynamicForm) ;
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
         RowToVars89( bcTrn_OrganisationDynamicForm, 0) ;
         GetKey1H89( ) ;
         if ( RcdFound89 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A509OrganisationDynamicFormId != Z509OrganisationDynamicFormId ) || ( A11OrganisationId != Z11OrganisationId ) )
            {
               A509OrganisationDynamicFormId = Z509OrganisationDynamicFormId;
               A11OrganisationId = Z11OrganisationId;
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
            if ( ( A509OrganisationDynamicFormId != Z509OrganisationDynamicFormId ) || ( A11OrganisationId != Z11OrganisationId ) )
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
         context.RollbackDataStores("trn_organisationdynamicform_bc",pr_default);
         VarsToRow89( bcTrn_OrganisationDynamicForm) ;
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
         Gx_mode = bcTrn_OrganisationDynamicForm.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_OrganisationDynamicForm.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_OrganisationDynamicForm )
         {
            bcTrn_OrganisationDynamicForm = (SdtTrn_OrganisationDynamicForm)(sdt);
            if ( StringUtil.StrCmp(bcTrn_OrganisationDynamicForm.gxTpr_Mode, "") == 0 )
            {
               bcTrn_OrganisationDynamicForm.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow89( bcTrn_OrganisationDynamicForm) ;
            }
            else
            {
               RowToVars89( bcTrn_OrganisationDynamicForm, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_OrganisationDynamicForm.gxTpr_Mode, "") == 0 )
            {
               bcTrn_OrganisationDynamicForm.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars89( bcTrn_OrganisationDynamicForm, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_OrganisationDynamicForm Trn_OrganisationDynamicForm_BC
      {
         get {
            return bcTrn_OrganisationDynamicForm ;
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
            return "trn_organisationdynamicform_Execute" ;
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
         Z509OrganisationDynamicFormId = Guid.Empty;
         A509OrganisationDynamicFormId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
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
         BC001H6_A509OrganisationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001H6_A208WWPFormReferenceName = new string[] {""} ;
         BC001H6_A209WWPFormTitle = new string[] {""} ;
         BC001H6_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001H6_A232WWPFormIsWizard = new bool[] {false} ;
         BC001H6_A216WWPFormResume = new short[1] ;
         BC001H6_A235WWPFormResumeMessage = new string[] {""} ;
         BC001H6_A233WWPFormValidations = new string[] {""} ;
         BC001H6_A234WWPFormInstantiated = new bool[] {false} ;
         BC001H6_A240WWPFormType = new short[1] ;
         BC001H6_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001H6_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001H6_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001H6_A206WWPFormId = new short[1] ;
         BC001H6_A207WWPFormVersionNumber = new short[1] ;
         BC001H4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001H5_A208WWPFormReferenceName = new string[] {""} ;
         BC001H5_A209WWPFormTitle = new string[] {""} ;
         BC001H5_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001H5_A232WWPFormIsWizard = new bool[] {false} ;
         BC001H5_A216WWPFormResume = new short[1] ;
         BC001H5_A235WWPFormResumeMessage = new string[] {""} ;
         BC001H5_A233WWPFormValidations = new string[] {""} ;
         BC001H5_A234WWPFormInstantiated = new bool[] {false} ;
         BC001H5_A240WWPFormType = new short[1] ;
         BC001H5_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001H5_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001H7_A509OrganisationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001H7_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001H3_A509OrganisationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001H3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001H3_A206WWPFormId = new short[1] ;
         BC001H3_A207WWPFormVersionNumber = new short[1] ;
         sMode89 = "";
         BC001H2_A509OrganisationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001H2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001H2_A206WWPFormId = new short[1] ;
         BC001H2_A207WWPFormVersionNumber = new short[1] ;
         BC001H11_A208WWPFormReferenceName = new string[] {""} ;
         BC001H11_A209WWPFormTitle = new string[] {""} ;
         BC001H11_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001H11_A232WWPFormIsWizard = new bool[] {false} ;
         BC001H11_A216WWPFormResume = new short[1] ;
         BC001H11_A235WWPFormResumeMessage = new string[] {""} ;
         BC001H11_A233WWPFormValidations = new string[] {""} ;
         BC001H11_A234WWPFormInstantiated = new bool[] {false} ;
         BC001H11_A240WWPFormType = new short[1] ;
         BC001H11_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001H11_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001H12_A509OrganisationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001H12_A208WWPFormReferenceName = new string[] {""} ;
         BC001H12_A209WWPFormTitle = new string[] {""} ;
         BC001H12_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001H12_A232WWPFormIsWizard = new bool[] {false} ;
         BC001H12_A216WWPFormResume = new short[1] ;
         BC001H12_A235WWPFormResumeMessage = new string[] {""} ;
         BC001H12_A233WWPFormValidations = new string[] {""} ;
         BC001H12_A234WWPFormInstantiated = new bool[] {false} ;
         BC001H12_A240WWPFormType = new short[1] ;
         BC001H12_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001H12_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001H12_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001H12_A206WWPFormId = new short[1] ;
         BC001H12_A207WWPFormVersionNumber = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC001H13_A11OrganisationId = new Guid[] {Guid.Empty} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationdynamicform_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationdynamicform_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationdynamicform_bc__default(),
            new Object[][] {
                new Object[] {
               BC001H2_A509OrganisationDynamicFormId, BC001H2_A11OrganisationId, BC001H2_A206WWPFormId, BC001H2_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC001H3_A509OrganisationDynamicFormId, BC001H3_A11OrganisationId, BC001H3_A206WWPFormId, BC001H3_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC001H4_A11OrganisationId
               }
               , new Object[] {
               BC001H5_A208WWPFormReferenceName, BC001H5_A209WWPFormTitle, BC001H5_A231WWPFormDate, BC001H5_A232WWPFormIsWizard, BC001H5_A216WWPFormResume, BC001H5_A235WWPFormResumeMessage, BC001H5_A233WWPFormValidations, BC001H5_A234WWPFormInstantiated, BC001H5_A240WWPFormType, BC001H5_A241WWPFormSectionRefElements,
               BC001H5_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               BC001H6_A509OrganisationDynamicFormId, BC001H6_A208WWPFormReferenceName, BC001H6_A209WWPFormTitle, BC001H6_A231WWPFormDate, BC001H6_A232WWPFormIsWizard, BC001H6_A216WWPFormResume, BC001H6_A235WWPFormResumeMessage, BC001H6_A233WWPFormValidations, BC001H6_A234WWPFormInstantiated, BC001H6_A240WWPFormType,
               BC001H6_A241WWPFormSectionRefElements, BC001H6_A242WWPFormIsForDynamicValidations, BC001H6_A11OrganisationId, BC001H6_A206WWPFormId, BC001H6_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC001H7_A509OrganisationDynamicFormId, BC001H7_A11OrganisationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001H11_A208WWPFormReferenceName, BC001H11_A209WWPFormTitle, BC001H11_A231WWPFormDate, BC001H11_A232WWPFormIsWizard, BC001H11_A216WWPFormResume, BC001H11_A235WWPFormResumeMessage, BC001H11_A233WWPFormValidations, BC001H11_A234WWPFormInstantiated, BC001H11_A240WWPFormType, BC001H11_A241WWPFormSectionRefElements,
               BC001H11_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               BC001H12_A509OrganisationDynamicFormId, BC001H12_A208WWPFormReferenceName, BC001H12_A209WWPFormTitle, BC001H12_A231WWPFormDate, BC001H12_A232WWPFormIsWizard, BC001H12_A216WWPFormResume, BC001H12_A235WWPFormResumeMessage, BC001H12_A233WWPFormValidations, BC001H12_A234WWPFormInstantiated, BC001H12_A240WWPFormType,
               BC001H12_A241WWPFormSectionRefElements, BC001H12_A242WWPFormIsForDynamicValidations, BC001H12_A11OrganisationId, BC001H12_A206WWPFormId, BC001H12_A207WWPFormVersionNumber
               }
               , new Object[] {
               BC001H13_A11OrganisationId
               }
            }
         );
         Z509OrganisationDynamicFormId = Guid.NewGuid( );
         A509OrganisationDynamicFormId = Guid.NewGuid( );
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
      private short RcdFound89 ;
      private short GXt_int1 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode89 ;
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
      private Guid Z509OrganisationDynamicFormId ;
      private Guid A509OrganisationDynamicFormId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001H6_A509OrganisationDynamicFormId ;
      private string[] BC001H6_A208WWPFormReferenceName ;
      private string[] BC001H6_A209WWPFormTitle ;
      private DateTime[] BC001H6_A231WWPFormDate ;
      private bool[] BC001H6_A232WWPFormIsWizard ;
      private short[] BC001H6_A216WWPFormResume ;
      private string[] BC001H6_A235WWPFormResumeMessage ;
      private string[] BC001H6_A233WWPFormValidations ;
      private bool[] BC001H6_A234WWPFormInstantiated ;
      private short[] BC001H6_A240WWPFormType ;
      private string[] BC001H6_A241WWPFormSectionRefElements ;
      private bool[] BC001H6_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001H6_A11OrganisationId ;
      private short[] BC001H6_A206WWPFormId ;
      private short[] BC001H6_A207WWPFormVersionNumber ;
      private Guid[] BC001H4_A11OrganisationId ;
      private string[] BC001H5_A208WWPFormReferenceName ;
      private string[] BC001H5_A209WWPFormTitle ;
      private DateTime[] BC001H5_A231WWPFormDate ;
      private bool[] BC001H5_A232WWPFormIsWizard ;
      private short[] BC001H5_A216WWPFormResume ;
      private string[] BC001H5_A235WWPFormResumeMessage ;
      private string[] BC001H5_A233WWPFormValidations ;
      private bool[] BC001H5_A234WWPFormInstantiated ;
      private short[] BC001H5_A240WWPFormType ;
      private string[] BC001H5_A241WWPFormSectionRefElements ;
      private bool[] BC001H5_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001H7_A509OrganisationDynamicFormId ;
      private Guid[] BC001H7_A11OrganisationId ;
      private Guid[] BC001H3_A509OrganisationDynamicFormId ;
      private Guid[] BC001H3_A11OrganisationId ;
      private short[] BC001H3_A206WWPFormId ;
      private short[] BC001H3_A207WWPFormVersionNumber ;
      private Guid[] BC001H2_A509OrganisationDynamicFormId ;
      private Guid[] BC001H2_A11OrganisationId ;
      private short[] BC001H2_A206WWPFormId ;
      private short[] BC001H2_A207WWPFormVersionNumber ;
      private string[] BC001H11_A208WWPFormReferenceName ;
      private string[] BC001H11_A209WWPFormTitle ;
      private DateTime[] BC001H11_A231WWPFormDate ;
      private bool[] BC001H11_A232WWPFormIsWizard ;
      private short[] BC001H11_A216WWPFormResume ;
      private string[] BC001H11_A235WWPFormResumeMessage ;
      private string[] BC001H11_A233WWPFormValidations ;
      private bool[] BC001H11_A234WWPFormInstantiated ;
      private short[] BC001H11_A240WWPFormType ;
      private string[] BC001H11_A241WWPFormSectionRefElements ;
      private bool[] BC001H11_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001H12_A509OrganisationDynamicFormId ;
      private string[] BC001H12_A208WWPFormReferenceName ;
      private string[] BC001H12_A209WWPFormTitle ;
      private DateTime[] BC001H12_A231WWPFormDate ;
      private bool[] BC001H12_A232WWPFormIsWizard ;
      private short[] BC001H12_A216WWPFormResume ;
      private string[] BC001H12_A235WWPFormResumeMessage ;
      private string[] BC001H12_A233WWPFormValidations ;
      private bool[] BC001H12_A234WWPFormInstantiated ;
      private short[] BC001H12_A240WWPFormType ;
      private string[] BC001H12_A241WWPFormSectionRefElements ;
      private bool[] BC001H12_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001H12_A11OrganisationId ;
      private short[] BC001H12_A206WWPFormId ;
      private short[] BC001H12_A207WWPFormVersionNumber ;
      private SdtTrn_OrganisationDynamicForm bcTrn_OrganisationDynamicForm ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid[] BC001H13_A11OrganisationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_organisationdynamicform_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_organisationdynamicform_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_organisationdynamicform_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC001H2;
       prmBC001H2 = new Object[] {
       new ParDef("OrganisationDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001H3;
       prmBC001H3 = new Object[] {
       new ParDef("OrganisationDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001H4;
       prmBC001H4 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001H5;
       prmBC001H5 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001H6;
       prmBC001H6 = new Object[] {
       new ParDef("OrganisationDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001H7;
       prmBC001H7 = new Object[] {
       new ParDef("OrganisationDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001H8;
       prmBC001H8 = new Object[] {
       new ParDef("OrganisationDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001H9;
       prmBC001H9 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("OrganisationDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001H10;
       prmBC001H10 = new Object[] {
       new ParDef("OrganisationDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001H11;
       prmBC001H11 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001H12;
       prmBC001H12 = new Object[] {
       new ParDef("OrganisationDynamicFormId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001H13;
       prmBC001H13 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001H2", "SELECT OrganisationDynamicFormId, OrganisationId, WWPFormId, WWPFormVersionNumber FROM Trn_OrganisationDynamicForm WHERE OrganisationDynamicFormId = :OrganisationDynamicFormId AND OrganisationId = :OrganisationId  FOR UPDATE OF Trn_OrganisationDynamicForm",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001H3", "SELECT OrganisationDynamicFormId, OrganisationId, WWPFormId, WWPFormVersionNumber FROM Trn_OrganisationDynamicForm WHERE OrganisationDynamicFormId = :OrganisationDynamicFormId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001H4", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001H5", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001H6", "SELECT TM1.OrganisationDynamicFormId, T2.WWPFormReferenceName, T2.WWPFormTitle, T2.WWPFormDate, T2.WWPFormIsWizard, T2.WWPFormResume, T2.WWPFormResumeMessage, T2.WWPFormValidations, T2.WWPFormInstantiated, T2.WWPFormType, T2.WWPFormSectionRefElements, T2.WWPFormIsForDynamicValidations, TM1.OrganisationId, TM1.WWPFormId, TM1.WWPFormVersionNumber FROM (Trn_OrganisationDynamicForm TM1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = TM1.WWPFormId AND T2.WWPFormVersionNumber = TM1.WWPFormVersionNumber) WHERE TM1.OrganisationDynamicFormId = :OrganisationDynamicFormId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.OrganisationDynamicFormId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H6,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001H7", "SELECT OrganisationDynamicFormId, OrganisationId FROM Trn_OrganisationDynamicForm WHERE OrganisationDynamicFormId = :OrganisationDynamicFormId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001H8", "SAVEPOINT gxupdate;INSERT INTO Trn_OrganisationDynamicForm(OrganisationDynamicFormId, OrganisationId, WWPFormId, WWPFormVersionNumber) VALUES(:OrganisationDynamicFormId, :OrganisationId, :WWPFormId, :WWPFormVersionNumber);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001H8)
          ,new CursorDef("BC001H9", "SAVEPOINT gxupdate;UPDATE Trn_OrganisationDynamicForm SET WWPFormId=:WWPFormId, WWPFormVersionNumber=:WWPFormVersionNumber  WHERE OrganisationDynamicFormId = :OrganisationDynamicFormId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001H9)
          ,new CursorDef("BC001H10", "SAVEPOINT gxupdate;DELETE FROM Trn_OrganisationDynamicForm  WHERE OrganisationDynamicFormId = :OrganisationDynamicFormId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001H10)
          ,new CursorDef("BC001H11", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H11,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001H12", "SELECT TM1.OrganisationDynamicFormId, T2.WWPFormReferenceName, T2.WWPFormTitle, T2.WWPFormDate, T2.WWPFormIsWizard, T2.WWPFormResume, T2.WWPFormResumeMessage, T2.WWPFormValidations, T2.WWPFormInstantiated, T2.WWPFormType, T2.WWPFormSectionRefElements, T2.WWPFormIsForDynamicValidations, TM1.OrganisationId, TM1.WWPFormId, TM1.WWPFormVersionNumber FROM (Trn_OrganisationDynamicForm TM1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = TM1.WWPFormId AND T2.WWPFormVersionNumber = TM1.WWPFormVersionNumber) WHERE TM1.OrganisationDynamicFormId = :OrganisationDynamicFormId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.OrganisationDynamicFormId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H12,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001H13", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H13,1, GxCacheFrequency.OFF ,true,false )
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
