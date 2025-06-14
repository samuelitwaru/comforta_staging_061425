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
   public class uform_bc : GxSilentTrn, IGxSilentTrn
   {
      public uform_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public uform_bc( IGxContext context )
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
         ReadRow1G40( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1G40( ) ;
         standaloneModal( ) ;
         AddRow1G40( ) ;
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
            E111G2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z206WWPFormId = A206WWPFormId;
               Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
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

      protected void CONFIRM_1G0( )
      {
         BeforeValidate1G40( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1G40( ) ;
            }
            else
            {
               CheckExtendedTable1G40( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1G40( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode40 = Gx_mode;
            CONFIRM_1G41( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode40;
            }
            /* Restore parent mode. */
            Gx_mode = sMode40;
         }
      }

      protected void CONFIRM_1G41( )
      {
         nGXsfl_41_idx = 0;
         while ( nGXsfl_41_idx < bcUForm.gxTpr_Element.Count )
         {
            ReadRow1G41( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound41 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_41 != 0 ) )
            {
               GetKey1G41( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound41 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate1G41( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1G41( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM1G41( 12) ;
                        }
                        CloseExtendedTableCursors1G41( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound41 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey1G41( ) ;
                        Load1G41( ) ;
                        BeforeValidate1G41( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1G41( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_41 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate1G41( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1G41( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM1G41( 12) ;
                              }
                              CloseExtendedTableCursors1G41( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow41( ((SdtUForm_Element)bcUForm.gxTpr_Element.Item(nGXsfl_41_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E121G2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E111G2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1G40( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
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
         if ( GX_JID == -10 )
         {
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
      }

      protected void Load1G40( )
      {
         /* Using cursor BC001G7 */
         pr_default.execute(5, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound40 = 1;
            A208WWPFormReferenceName = BC001G7_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001G7_A209WWPFormTitle[0];
            A231WWPFormDate = BC001G7_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001G7_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001G7_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001G7_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001G7_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001G7_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001G7_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001G7_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001G7_A242WWPFormIsForDynamicValidations[0];
            ZM1G40( -10) ;
         }
         pr_default.close(5);
         OnLoadActions1G40( ) ;
      }

      protected void OnLoadActions1G40( )
      {
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
      }

      protected void CheckExtendedTable1G40( )
      {
         standaloneModal( ) ;
         GXt_int1 = A219WWPFormLatestVersionNumber;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
         A219WWPFormLatestVersionNumber = GXt_int1;
         if ( ! new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validateuniquereferencename(context).executeUdp(  A206WWPFormId,  A208WWPFormReferenceName) )
         {
            GX_msglist.addItem(context.GetMessage( "WWP_DF_ReferenceMustBeUnique", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( ( A216WWPFormResume == 0 ) || ( A216WWPFormResume == 1 ) || ( A216WWPFormResume == 2 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "WWPForm Resume", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( A240WWPFormType == 0 ) || ( A240WWPFormType == 1 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "WWPForm Type", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1G40( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1G40( )
      {
         /* Using cursor BC001G8 */
         pr_default.execute(6, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound40 = 1;
         }
         else
         {
            RcdFound40 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001G6 */
         pr_default.execute(4, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM1G40( 10) ;
            RcdFound40 = 1;
            A206WWPFormId = BC001G6_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001G6_A207WWPFormVersionNumber[0];
            A208WWPFormReferenceName = BC001G6_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001G6_A209WWPFormTitle[0];
            A231WWPFormDate = BC001G6_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001G6_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001G6_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001G6_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001G6_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001G6_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001G6_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001G6_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001G6_A242WWPFormIsForDynamicValidations[0];
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            sMode40 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1G40( ) ;
            if ( AnyError == 1 )
            {
               RcdFound40 = 0;
               InitializeNonKey1G40( ) ;
            }
            Gx_mode = sMode40;
         }
         else
         {
            RcdFound40 = 0;
            InitializeNonKey1G40( ) ;
            sMode40 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode40;
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey1G40( ) ;
         if ( RcdFound40 == 0 )
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
         CONFIRM_1G0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1G40( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001G5 */
            pr_default.execute(3, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Form"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z208WWPFormReferenceName, BC001G5_A208WWPFormReferenceName[0]) != 0 ) || ( StringUtil.StrCmp(Z209WWPFormTitle, BC001G5_A209WWPFormTitle[0]) != 0 ) || ( Z231WWPFormDate != BC001G5_A231WWPFormDate[0] ) || ( Z232WWPFormIsWizard != BC001G5_A232WWPFormIsWizard[0] ) || ( Z216WWPFormResume != BC001G5_A216WWPFormResume[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z234WWPFormInstantiated != BC001G5_A234WWPFormInstantiated[0] ) || ( Z240WWPFormType != BC001G5_A240WWPFormType[0] ) || ( StringUtil.StrCmp(Z241WWPFormSectionRefElements, BC001G5_A241WWPFormSectionRefElements[0]) != 0 ) || ( Z242WWPFormIsForDynamicValidations != BC001G5_A242WWPFormIsForDynamicValidations[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Form"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1G40( )
      {
         BeforeValidate1G40( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G40( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1G40( 0) ;
            CheckOptimisticConcurrency1G40( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G40( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1G40( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001G9 */
                     pr_default.execute(7, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A208WWPFormReferenceName, A209WWPFormTitle, A231WWPFormDate, A232WWPFormIsWizard, A216WWPFormResume, A235WWPFormResumeMessage, A233WWPFormValidations, A234WWPFormInstantiated, A240WWPFormType, A241WWPFormSectionRefElements, A242WWPFormIsForDynamicValidations});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Form");
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
                           ProcessLevel1G40( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
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
               Load1G40( ) ;
            }
            EndLevel1G40( ) ;
         }
         CloseExtendedTableCursors1G40( ) ;
      }

      protected void Update1G40( )
      {
         BeforeValidate1G40( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G40( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G40( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G40( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1G40( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001G10 */
                     pr_default.execute(8, new Object[] {A208WWPFormReferenceName, A209WWPFormTitle, A231WWPFormDate, A232WWPFormIsWizard, A216WWPFormResume, A235WWPFormResumeMessage, A233WWPFormValidations, A234WWPFormInstantiated, A240WWPFormType, A241WWPFormSectionRefElements, A242WWPFormIsForDynamicValidations, A206WWPFormId, A207WWPFormVersionNumber});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Form");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Form"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1G40( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1G40( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
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
            }
            EndLevel1G40( ) ;
         }
         CloseExtendedTableCursors1G40( ) ;
      }

      protected void DeferredUpdate1G40( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1G40( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G40( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1G40( ) ;
            AfterConfirm1G40( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1G40( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart1G41( ) ;
                  while ( RcdFound41 != 0 )
                  {
                     getByPrimaryKey1G41( ) ;
                     Delete1G41( ) ;
                     ScanKeyNext1G41( ) ;
                  }
                  ScanKeyEnd1G41( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001G11 */
                     pr_default.execute(9, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Form");
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
         }
         sMode40 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1G40( ) ;
         Gx_mode = sMode40;
      }

      protected void OnDeleteControls1G40( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXt_int1 = A219WWPFormLatestVersionNumber;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
            A219WWPFormLatestVersionNumber = GXt_int1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001G12 */
            pr_default.execute(10, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_SupplierDynamicForm", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC001G13 */
            pr_default.execute(11, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_OrganisationDynamicForm", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC001G14 */
            pr_default.execute(12, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Location Dynamic Forms", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC001G15 */
            pr_default.execute(13, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWPForm Instance", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor BC001G16 */
            pr_default.execute(14, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Element", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void ProcessNestedLevel1G41( )
      {
         nGXsfl_41_idx = 0;
         while ( nGXsfl_41_idx < bcUForm.gxTpr_Element.Count )
         {
            ReadRow1G41( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound41 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_41 != 0 ) )
            {
               standaloneNotModal1G41( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert1G41( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete1G41( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update1G41( ) ;
                  }
               }
            }
            KeyVarsToRow41( ((SdtUForm_Element)bcUForm.gxTpr_Element.Item(nGXsfl_41_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_41_idx = 0;
            while ( nGXsfl_41_idx < bcUForm.gxTpr_Element.Count )
            {
               ReadRow1G41( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound41 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcUForm.gxTpr_Element.RemoveElement(nGXsfl_41_idx);
                  nGXsfl_41_idx = (int)(nGXsfl_41_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey1G41( ) ;
                  VarsToRow41( ((SdtUForm_Element)bcUForm.gxTpr_Element.Item(nGXsfl_41_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1G41( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_41 = 0;
         nIsMod_41 = 0;
      }

      protected void ProcessLevel1G40( )
      {
         /* Save parent mode. */
         sMode40 = Gx_mode;
         ProcessNestedLevel1G41( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode40;
         /* ' Update level parameters */
      }

      protected void EndLevel1G40( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1G40( ) ;
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

      public void ScanKeyStart1G40( )
      {
         /* Scan By routine */
         /* Using cursor BC001G17 */
         pr_default.execute(15, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         RcdFound40 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound40 = 1;
            A206WWPFormId = BC001G17_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001G17_A207WWPFormVersionNumber[0];
            A208WWPFormReferenceName = BC001G17_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001G17_A209WWPFormTitle[0];
            A231WWPFormDate = BC001G17_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001G17_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001G17_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001G17_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001G17_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001G17_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001G17_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001G17_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001G17_A242WWPFormIsForDynamicValidations[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1G40( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound40 = 0;
         ScanKeyLoad1G40( ) ;
      }

      protected void ScanKeyLoad1G40( )
      {
         sMode40 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound40 = 1;
            A206WWPFormId = BC001G17_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC001G17_A207WWPFormVersionNumber[0];
            A208WWPFormReferenceName = BC001G17_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC001G17_A209WWPFormTitle[0];
            A231WWPFormDate = BC001G17_A231WWPFormDate[0];
            A232WWPFormIsWizard = BC001G17_A232WWPFormIsWizard[0];
            A216WWPFormResume = BC001G17_A216WWPFormResume[0];
            A235WWPFormResumeMessage = BC001G17_A235WWPFormResumeMessage[0];
            A233WWPFormValidations = BC001G17_A233WWPFormValidations[0];
            A234WWPFormInstantiated = BC001G17_A234WWPFormInstantiated[0];
            A240WWPFormType = BC001G17_A240WWPFormType[0];
            A241WWPFormSectionRefElements = BC001G17_A241WWPFormSectionRefElements[0];
            A242WWPFormIsForDynamicValidations = BC001G17_A242WWPFormIsForDynamicValidations[0];
         }
         Gx_mode = sMode40;
      }

      protected void ScanKeyEnd1G40( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm1G40( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1G40( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1G40( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1G40( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1G40( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1G40( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1G40( )
      {
      }

      protected void ZM1G41( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z237WWPFormElementCaption = A237WWPFormElementCaption;
            Z217WWPFormElementType = A217WWPFormElementType;
            Z212WWPFormElementOrderIndex = A212WWPFormElementOrderIndex;
            Z218WWPFormElementDataType = A218WWPFormElementDataType;
            Z213WWPFormElementReferenceId = A213WWPFormElementReferenceId;
            Z238WWPFormElementExcludeFromExpor = A238WWPFormElementExcludeFromExpor;
            Z211WWPFormElementParentId = A211WWPFormElementParentId;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z230WWPFormElementParentType = A230WWPFormElementParentType;
         }
         if ( GX_JID == -11 )
         {
            Z210WWPFormElementId = A210WWPFormElementId;
            Z237WWPFormElementCaption = A237WWPFormElementCaption;
            Z229WWPFormElementTitle = A229WWPFormElementTitle;
            Z217WWPFormElementType = A217WWPFormElementType;
            Z212WWPFormElementOrderIndex = A212WWPFormElementOrderIndex;
            Z218WWPFormElementDataType = A218WWPFormElementDataType;
            Z236WWPFormElementMetadata = A236WWPFormElementMetadata;
            Z213WWPFormElementReferenceId = A213WWPFormElementReferenceId;
            Z238WWPFormElementExcludeFromExpor = A238WWPFormElementExcludeFromExpor;
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            Z211WWPFormElementParentId = A211WWPFormElementParentId;
            Z228WWPFormElementParentName = A228WWPFormElementParentName;
            Z230WWPFormElementParentType = A230WWPFormElementParentType;
         }
      }

      protected void standaloneNotModal1G41( )
      {
      }

      protected void standaloneModal1G41( )
      {
         if ( IsIns( )  && (0==A237WWPFormElementCaption) && ( Gx_BScreen == 0 ) )
         {
            A237WWPFormElementCaption = 1;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1G41( )
      {
         /* Using cursor BC001G18 */
         pr_default.execute(16, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound41 = 1;
            A237WWPFormElementCaption = BC001G18_A237WWPFormElementCaption[0];
            A229WWPFormElementTitle = BC001G18_A229WWPFormElementTitle[0];
            A217WWPFormElementType = BC001G18_A217WWPFormElementType[0];
            A212WWPFormElementOrderIndex = BC001G18_A212WWPFormElementOrderIndex[0];
            A218WWPFormElementDataType = BC001G18_A218WWPFormElementDataType[0];
            A228WWPFormElementParentName = BC001G18_A228WWPFormElementParentName[0];
            A230WWPFormElementParentType = BC001G18_A230WWPFormElementParentType[0];
            A236WWPFormElementMetadata = BC001G18_A236WWPFormElementMetadata[0];
            A213WWPFormElementReferenceId = BC001G18_A213WWPFormElementReferenceId[0];
            A238WWPFormElementExcludeFromExpor = BC001G18_A238WWPFormElementExcludeFromExpor[0];
            A211WWPFormElementParentId = BC001G18_A211WWPFormElementParentId[0];
            n211WWPFormElementParentId = BC001G18_n211WWPFormElementParentId[0];
            ZM1G41( -11) ;
         }
         pr_default.close(16);
         OnLoadActions1G41( ) ;
      }

      protected void OnLoadActions1G41( )
      {
      }

      protected void CheckExtendedTable1G41( )
      {
         Gx_BScreen = 1;
         standaloneModal1G41( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC001G4 */
         pr_default.execute(2, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, n211WWPFormElementParentId, A211WWPFormElementParentId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A206WWPFormId) || (0==A207WWPFormVersionNumber) || (0==A211WWPFormElementParentId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWPForm Element Parent", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMELEMENTPARENTID");
               AnyError = 1;
            }
         }
         A228WWPFormElementParentName = BC001G4_A228WWPFormElementParentName[0];
         A230WWPFormElementParentType = BC001G4_A230WWPFormElementParentType[0];
         pr_default.close(2);
         if ( ! ( ( A217WWPFormElementType == 1 ) || ( A217WWPFormElementType == 2 ) || ( A217WWPFormElementType == 3 ) || ( A217WWPFormElementType == 4 ) || ( A217WWPFormElementType == 5 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "WWPForm Element Type", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( A218WWPFormElementDataType == 1 ) || ( A218WWPFormElementDataType == 2 ) || ( A218WWPFormElementDataType == 3 ) || ( A218WWPFormElementDataType == 4 ) || ( A218WWPFormElementDataType == 5 ) || ( A218WWPFormElementDataType == 6 ) || ( A218WWPFormElementDataType == 7 ) || ( A218WWPFormElementDataType == 8 ) || ( A218WWPFormElementDataType == 9 ) || ( A218WWPFormElementDataType == 10 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "WWPForm Element Data Type", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( A237WWPFormElementCaption == 1 ) || ( A237WWPFormElementCaption == 2 ) || ( A237WWPFormElementCaption == 3 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "WWPForm Element Caption", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1G41( )
      {
         pr_default.close(2);
      }

      protected void enableDisable1G41( )
      {
      }

      protected void GetKey1G41( )
      {
         /* Using cursor BC001G19 */
         pr_default.execute(17, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound41 = 1;
         }
         else
         {
            RcdFound41 = 0;
         }
         pr_default.close(17);
      }

      protected void getByPrimaryKey1G41( )
      {
         /* Using cursor BC001G3 */
         pr_default.execute(1, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1G41( 11) ;
            RcdFound41 = 1;
            InitializeNonKey1G41( ) ;
            A210WWPFormElementId = BC001G3_A210WWPFormElementId[0];
            A237WWPFormElementCaption = BC001G3_A237WWPFormElementCaption[0];
            A229WWPFormElementTitle = BC001G3_A229WWPFormElementTitle[0];
            A217WWPFormElementType = BC001G3_A217WWPFormElementType[0];
            A212WWPFormElementOrderIndex = BC001G3_A212WWPFormElementOrderIndex[0];
            A218WWPFormElementDataType = BC001G3_A218WWPFormElementDataType[0];
            A236WWPFormElementMetadata = BC001G3_A236WWPFormElementMetadata[0];
            A213WWPFormElementReferenceId = BC001G3_A213WWPFormElementReferenceId[0];
            A238WWPFormElementExcludeFromExpor = BC001G3_A238WWPFormElementExcludeFromExpor[0];
            A211WWPFormElementParentId = BC001G3_A211WWPFormElementParentId[0];
            n211WWPFormElementParentId = BC001G3_n211WWPFormElementParentId[0];
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            Z210WWPFormElementId = A210WWPFormElementId;
            sMode41 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1G41( ) ;
            Load1G41( ) ;
            Gx_mode = sMode41;
         }
         else
         {
            RcdFound41 = 0;
            InitializeNonKey1G41( ) ;
            sMode41 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1G41( ) ;
            Gx_mode = sMode41;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1G41( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1G41( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001G2 */
            pr_default.execute(0, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormElement"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z237WWPFormElementCaption != BC001G2_A237WWPFormElementCaption[0] ) || ( Z217WWPFormElementType != BC001G2_A217WWPFormElementType[0] ) || ( Z212WWPFormElementOrderIndex != BC001G2_A212WWPFormElementOrderIndex[0] ) || ( Z218WWPFormElementDataType != BC001G2_A218WWPFormElementDataType[0] ) || ( StringUtil.StrCmp(Z213WWPFormElementReferenceId, BC001G2_A213WWPFormElementReferenceId[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z238WWPFormElementExcludeFromExpor != BC001G2_A238WWPFormElementExcludeFromExpor[0] ) || ( Z211WWPFormElementParentId != BC001G2_A211WWPFormElementParentId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_FormElement"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1G41( )
      {
         BeforeValidate1G41( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G41( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1G41( 0) ;
            CheckOptimisticConcurrency1G41( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G41( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1G41( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001G20 */
                     pr_default.execute(18, new Object[] {A210WWPFormElementId, A237WWPFormElementCaption, A229WWPFormElementTitle, A217WWPFormElementType, A212WWPFormElementOrderIndex, A218WWPFormElementDataType, A236WWPFormElementMetadata, A213WWPFormElementReferenceId, A238WWPFormElementExcludeFromExpor, A206WWPFormId, A207WWPFormVersionNumber, n211WWPFormElementParentId, A211WWPFormElementParentId});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormElement");
                     if ( (pr_default.getStatus(18) == 1) )
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
               Load1G41( ) ;
            }
            EndLevel1G41( ) ;
         }
         CloseExtendedTableCursors1G41( ) ;
      }

      protected void Update1G41( )
      {
         BeforeValidate1G41( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G41( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G41( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G41( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1G41( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001G21 */
                     pr_default.execute(19, new Object[] {A237WWPFormElementCaption, A229WWPFormElementTitle, A217WWPFormElementType, A212WWPFormElementOrderIndex, A218WWPFormElementDataType, A236WWPFormElementMetadata, A213WWPFormElementReferenceId, A238WWPFormElementExcludeFromExpor, n211WWPFormElementParentId, A211WWPFormElementParentId, A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormElement");
                     if ( (pr_default.getStatus(19) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormElement"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1G41( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey1G41( ) ;
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
            EndLevel1G41( ) ;
         }
         CloseExtendedTableCursors1G41( ) ;
      }

      protected void DeferredUpdate1G41( )
      {
      }

      protected void Delete1G41( )
      {
         Gx_mode = "DLT";
         BeforeValidate1G41( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G41( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1G41( ) ;
            AfterConfirm1G41( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1G41( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001G22 */
                  pr_default.execute(20, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
                  pr_default.close(20);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_FormElement");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode41 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1G41( ) ;
         Gx_mode = sMode41;
      }

      protected void OnDeleteControls1G41( )
      {
         standaloneModal1G41( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001G23 */
            pr_default.execute(21, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, n211WWPFormElementParentId, A211WWPFormElementParentId});
            A228WWPFormElementParentName = BC001G23_A228WWPFormElementParentName[0];
            A230WWPFormElementParentType = BC001G23_A230WWPFormElementParentType[0];
            pr_default.close(21);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001G24 */
            pr_default.execute(22, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Element", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
         }
      }

      protected void EndLevel1G41( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart1G41( )
      {
         /* Scan By routine */
         /* Using cursor BC001G25 */
         pr_default.execute(23, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         RcdFound41 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound41 = 1;
            A210WWPFormElementId = BC001G25_A210WWPFormElementId[0];
            A237WWPFormElementCaption = BC001G25_A237WWPFormElementCaption[0];
            A229WWPFormElementTitle = BC001G25_A229WWPFormElementTitle[0];
            A217WWPFormElementType = BC001G25_A217WWPFormElementType[0];
            A212WWPFormElementOrderIndex = BC001G25_A212WWPFormElementOrderIndex[0];
            A218WWPFormElementDataType = BC001G25_A218WWPFormElementDataType[0];
            A228WWPFormElementParentName = BC001G25_A228WWPFormElementParentName[0];
            A230WWPFormElementParentType = BC001G25_A230WWPFormElementParentType[0];
            A236WWPFormElementMetadata = BC001G25_A236WWPFormElementMetadata[0];
            A213WWPFormElementReferenceId = BC001G25_A213WWPFormElementReferenceId[0];
            A238WWPFormElementExcludeFromExpor = BC001G25_A238WWPFormElementExcludeFromExpor[0];
            A211WWPFormElementParentId = BC001G25_A211WWPFormElementParentId[0];
            n211WWPFormElementParentId = BC001G25_n211WWPFormElementParentId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1G41( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound41 = 0;
         ScanKeyLoad1G41( ) ;
      }

      protected void ScanKeyLoad1G41( )
      {
         sMode41 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound41 = 1;
            A210WWPFormElementId = BC001G25_A210WWPFormElementId[0];
            A237WWPFormElementCaption = BC001G25_A237WWPFormElementCaption[0];
            A229WWPFormElementTitle = BC001G25_A229WWPFormElementTitle[0];
            A217WWPFormElementType = BC001G25_A217WWPFormElementType[0];
            A212WWPFormElementOrderIndex = BC001G25_A212WWPFormElementOrderIndex[0];
            A218WWPFormElementDataType = BC001G25_A218WWPFormElementDataType[0];
            A228WWPFormElementParentName = BC001G25_A228WWPFormElementParentName[0];
            A230WWPFormElementParentType = BC001G25_A230WWPFormElementParentType[0];
            A236WWPFormElementMetadata = BC001G25_A236WWPFormElementMetadata[0];
            A213WWPFormElementReferenceId = BC001G25_A213WWPFormElementReferenceId[0];
            A238WWPFormElementExcludeFromExpor = BC001G25_A238WWPFormElementExcludeFromExpor[0];
            A211WWPFormElementParentId = BC001G25_A211WWPFormElementParentId[0];
            n211WWPFormElementParentId = BC001G25_n211WWPFormElementParentId[0];
         }
         Gx_mode = sMode41;
      }

      protected void ScanKeyEnd1G41( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm1G41( )
      {
         /* After Confirm Rules */
         if ( (0==A211WWPFormElementParentId) )
         {
            A211WWPFormElementParentId = 0;
            n211WWPFormElementParentId = false;
            n211WWPFormElementParentId = true;
         }
      }

      protected void BeforeInsert1G41( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1G41( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1G41( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1G41( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1G41( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1G41( )
      {
      }

      protected void send_integrity_lvl_hashes1G41( )
      {
      }

      protected void send_integrity_lvl_hashes1G40( )
      {
      }

      protected void AddRow1G40( )
      {
         VarsToRow40( bcUForm) ;
      }

      protected void ReadRow1G40( )
      {
         RowToVars40( bcUForm, 1) ;
      }

      protected void AddRow1G41( )
      {
         SdtUForm_Element obj41;
         obj41 = new SdtUForm_Element(context);
         VarsToRow41( obj41) ;
         bcUForm.gxTpr_Element.Add(obj41, 0);
         obj41.gxTpr_Mode = "UPD";
         obj41.gxTpr_Modified = 0;
      }

      protected void ReadRow1G41( )
      {
         nGXsfl_41_idx = (int)(nGXsfl_41_idx+1);
         RowToVars41( ((SdtUForm_Element)bcUForm.gxTpr_Element.Item(nGXsfl_41_idx)), 1) ;
      }

      protected void InitializeNonKey1G40( )
      {
         A219WWPFormLatestVersionNumber = 0;
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
         Z208WWPFormReferenceName = "";
         Z209WWPFormTitle = "";
         Z231WWPFormDate = (DateTime)(DateTime.MinValue);
         Z232WWPFormIsWizard = false;
         Z216WWPFormResume = 0;
         Z234WWPFormInstantiated = false;
         Z240WWPFormType = 0;
         Z241WWPFormSectionRefElements = "";
         Z242WWPFormIsForDynamicValidations = false;
      }

      protected void InitAll1G40( )
      {
         A206WWPFormId = 0;
         A207WWPFormVersionNumber = 0;
         InitializeNonKey1G40( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey1G41( )
      {
         A229WWPFormElementTitle = "";
         A217WWPFormElementType = 0;
         A212WWPFormElementOrderIndex = 0;
         A218WWPFormElementDataType = 0;
         A211WWPFormElementParentId = 0;
         n211WWPFormElementParentId = false;
         A228WWPFormElementParentName = "";
         A230WWPFormElementParentType = 0;
         A236WWPFormElementMetadata = "";
         A213WWPFormElementReferenceId = "";
         A238WWPFormElementExcludeFromExpor = false;
         A237WWPFormElementCaption = 1;
         Z237WWPFormElementCaption = 0;
         Z217WWPFormElementType = 0;
         Z212WWPFormElementOrderIndex = 0;
         Z218WWPFormElementDataType = 0;
         Z213WWPFormElementReferenceId = "";
         Z238WWPFormElementExcludeFromExpor = false;
         Z211WWPFormElementParentId = 0;
      }

      protected void InitAll1G41( )
      {
         A210WWPFormElementId = 0;
         InitializeNonKey1G41( ) ;
      }

      protected void StandaloneModalInsert1G41( )
      {
         A237WWPFormElementCaption = i237WWPFormElementCaption;
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

      public void VarsToRow40( SdtUForm obj40 )
      {
         obj40.gxTpr_Mode = Gx_mode;
         obj40.gxTpr_Wwpformlatestversionnumber = A219WWPFormLatestVersionNumber;
         obj40.gxTpr_Wwpformreferencename = A208WWPFormReferenceName;
         obj40.gxTpr_Wwpformtitle = A209WWPFormTitle;
         obj40.gxTpr_Wwpformdate = A231WWPFormDate;
         obj40.gxTpr_Wwpformiswizard = A232WWPFormIsWizard;
         obj40.gxTpr_Wwpformresume = A216WWPFormResume;
         obj40.gxTpr_Wwpformresumemessage = A235WWPFormResumeMessage;
         obj40.gxTpr_Wwpformvalidations = A233WWPFormValidations;
         obj40.gxTpr_Wwpforminstantiated = A234WWPFormInstantiated;
         obj40.gxTpr_Wwpformtype = A240WWPFormType;
         obj40.gxTpr_Wwpformsectionrefelements = A241WWPFormSectionRefElements;
         obj40.gxTpr_Wwpformisfordynamicvalidations = A242WWPFormIsForDynamicValidations;
         obj40.gxTpr_Wwpformid = A206WWPFormId;
         obj40.gxTpr_Wwpformversionnumber = A207WWPFormVersionNumber;
         obj40.gxTpr_Wwpformid_Z = Z206WWPFormId;
         obj40.gxTpr_Wwpformversionnumber_Z = Z207WWPFormVersionNumber;
         obj40.gxTpr_Wwpformreferencename_Z = Z208WWPFormReferenceName;
         obj40.gxTpr_Wwpformtitle_Z = Z209WWPFormTitle;
         obj40.gxTpr_Wwpformdate_Z = Z231WWPFormDate;
         obj40.gxTpr_Wwpformiswizard_Z = Z232WWPFormIsWizard;
         obj40.gxTpr_Wwpformresume_Z = Z216WWPFormResume;
         obj40.gxTpr_Wwpforminstantiated_Z = Z234WWPFormInstantiated;
         obj40.gxTpr_Wwpformlatestversionnumber_Z = Z219WWPFormLatestVersionNumber;
         obj40.gxTpr_Wwpformtype_Z = Z240WWPFormType;
         obj40.gxTpr_Wwpformsectionrefelements_Z = Z241WWPFormSectionRefElements;
         obj40.gxTpr_Wwpformisfordynamicvalidations_Z = Z242WWPFormIsForDynamicValidations;
         obj40.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow40( SdtUForm obj40 )
      {
         obj40.gxTpr_Wwpformid = A206WWPFormId;
         obj40.gxTpr_Wwpformversionnumber = A207WWPFormVersionNumber;
         return  ;
      }

      public void RowToVars40( SdtUForm obj40 ,
                               int forceLoad )
      {
         Gx_mode = obj40.gxTpr_Mode;
         A219WWPFormLatestVersionNumber = obj40.gxTpr_Wwpformlatestversionnumber;
         A208WWPFormReferenceName = obj40.gxTpr_Wwpformreferencename;
         A209WWPFormTitle = obj40.gxTpr_Wwpformtitle;
         A231WWPFormDate = obj40.gxTpr_Wwpformdate;
         A232WWPFormIsWizard = obj40.gxTpr_Wwpformiswizard;
         A216WWPFormResume = obj40.gxTpr_Wwpformresume;
         A235WWPFormResumeMessage = obj40.gxTpr_Wwpformresumemessage;
         A233WWPFormValidations = obj40.gxTpr_Wwpformvalidations;
         A234WWPFormInstantiated = obj40.gxTpr_Wwpforminstantiated;
         A240WWPFormType = obj40.gxTpr_Wwpformtype;
         A241WWPFormSectionRefElements = obj40.gxTpr_Wwpformsectionrefelements;
         A242WWPFormIsForDynamicValidations = obj40.gxTpr_Wwpformisfordynamicvalidations;
         A206WWPFormId = obj40.gxTpr_Wwpformid;
         A207WWPFormVersionNumber = obj40.gxTpr_Wwpformversionnumber;
         Z206WWPFormId = obj40.gxTpr_Wwpformid_Z;
         Z207WWPFormVersionNumber = obj40.gxTpr_Wwpformversionnumber_Z;
         Z208WWPFormReferenceName = obj40.gxTpr_Wwpformreferencename_Z;
         Z209WWPFormTitle = obj40.gxTpr_Wwpformtitle_Z;
         Z231WWPFormDate = obj40.gxTpr_Wwpformdate_Z;
         Z232WWPFormIsWizard = obj40.gxTpr_Wwpformiswizard_Z;
         Z216WWPFormResume = obj40.gxTpr_Wwpformresume_Z;
         Z234WWPFormInstantiated = obj40.gxTpr_Wwpforminstantiated_Z;
         Z219WWPFormLatestVersionNumber = obj40.gxTpr_Wwpformlatestversionnumber_Z;
         Z240WWPFormType = obj40.gxTpr_Wwpformtype_Z;
         Z241WWPFormSectionRefElements = obj40.gxTpr_Wwpformsectionrefelements_Z;
         Z242WWPFormIsForDynamicValidations = obj40.gxTpr_Wwpformisfordynamicvalidations_Z;
         Gx_mode = obj40.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow41( SdtUForm_Element obj41 )
      {
         obj41.gxTpr_Mode = Gx_mode;
         obj41.gxTpr_Wwpformelementtitle = A229WWPFormElementTitle;
         obj41.gxTpr_Wwpformelementtype = A217WWPFormElementType;
         obj41.gxTpr_Wwpformelementorderindex = A212WWPFormElementOrderIndex;
         obj41.gxTpr_Wwpformelementdatatype = A218WWPFormElementDataType;
         obj41.gxTpr_Wwpformelementparentid = A211WWPFormElementParentId;
         obj41.gxTpr_Wwpformelementparentname = A228WWPFormElementParentName;
         obj41.gxTpr_Wwpformelementparenttype = A230WWPFormElementParentType;
         obj41.gxTpr_Wwpformelementmetadata = A236WWPFormElementMetadata;
         obj41.gxTpr_Wwpformelementreferenceid = A213WWPFormElementReferenceId;
         obj41.gxTpr_Wwpformelementexcludefromexport = A238WWPFormElementExcludeFromExpor;
         obj41.gxTpr_Wwpformelementcaption = A237WWPFormElementCaption;
         obj41.gxTpr_Wwpformelementid = A210WWPFormElementId;
         obj41.gxTpr_Wwpformelementid_Z = Z210WWPFormElementId;
         obj41.gxTpr_Wwpformelementtype_Z = Z217WWPFormElementType;
         obj41.gxTpr_Wwpformelementorderindex_Z = Z212WWPFormElementOrderIndex;
         obj41.gxTpr_Wwpformelementdatatype_Z = Z218WWPFormElementDataType;
         obj41.gxTpr_Wwpformelementparentid_Z = Z211WWPFormElementParentId;
         obj41.gxTpr_Wwpformelementparenttype_Z = Z230WWPFormElementParentType;
         obj41.gxTpr_Wwpformelementcaption_Z = Z237WWPFormElementCaption;
         obj41.gxTpr_Wwpformelementreferenceid_Z = Z213WWPFormElementReferenceId;
         obj41.gxTpr_Wwpformelementexcludefromexport_Z = Z238WWPFormElementExcludeFromExpor;
         obj41.gxTpr_Wwpformelementparentid_N = (short)(Convert.ToInt16(n211WWPFormElementParentId));
         obj41.gxTpr_Modified = nIsMod_41;
         return  ;
      }

      public void KeyVarsToRow41( SdtUForm_Element obj41 )
      {
         obj41.gxTpr_Wwpformelementid = A210WWPFormElementId;
         return  ;
      }

      public void RowToVars41( SdtUForm_Element obj41 ,
                               int forceLoad )
      {
         Gx_mode = obj41.gxTpr_Mode;
         A229WWPFormElementTitle = obj41.gxTpr_Wwpformelementtitle;
         A217WWPFormElementType = obj41.gxTpr_Wwpformelementtype;
         A212WWPFormElementOrderIndex = obj41.gxTpr_Wwpformelementorderindex;
         A218WWPFormElementDataType = obj41.gxTpr_Wwpformelementdatatype;
         A211WWPFormElementParentId = obj41.gxTpr_Wwpformelementparentid;
         n211WWPFormElementParentId = false;
         A228WWPFormElementParentName = obj41.gxTpr_Wwpformelementparentname;
         A230WWPFormElementParentType = obj41.gxTpr_Wwpformelementparenttype;
         A236WWPFormElementMetadata = obj41.gxTpr_Wwpformelementmetadata;
         A213WWPFormElementReferenceId = obj41.gxTpr_Wwpformelementreferenceid;
         A238WWPFormElementExcludeFromExpor = obj41.gxTpr_Wwpformelementexcludefromexport;
         A237WWPFormElementCaption = obj41.gxTpr_Wwpformelementcaption;
         A210WWPFormElementId = obj41.gxTpr_Wwpformelementid;
         Z210WWPFormElementId = obj41.gxTpr_Wwpformelementid_Z;
         Z217WWPFormElementType = obj41.gxTpr_Wwpformelementtype_Z;
         Z212WWPFormElementOrderIndex = obj41.gxTpr_Wwpformelementorderindex_Z;
         Z218WWPFormElementDataType = obj41.gxTpr_Wwpformelementdatatype_Z;
         Z211WWPFormElementParentId = obj41.gxTpr_Wwpformelementparentid_Z;
         Z230WWPFormElementParentType = obj41.gxTpr_Wwpformelementparenttype_Z;
         Z237WWPFormElementCaption = obj41.gxTpr_Wwpformelementcaption_Z;
         Z213WWPFormElementReferenceId = obj41.gxTpr_Wwpformelementreferenceid_Z;
         Z238WWPFormElementExcludeFromExpor = obj41.gxTpr_Wwpformelementexcludefromexport_Z;
         n211WWPFormElementParentId = (bool)(Convert.ToBoolean(obj41.gxTpr_Wwpformelementparentid_N));
         nIsMod_41 = obj41.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A206WWPFormId = (short)getParm(obj,0);
         A207WWPFormVersionNumber = (short)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1G40( ) ;
         ScanKeyStart1G40( ) ;
         if ( RcdFound40 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
         }
         ZM1G40( -10) ;
         OnLoadActions1G40( ) ;
         AddRow1G40( ) ;
         bcUForm.gxTpr_Element.ClearCollection();
         if ( RcdFound40 == 1 )
         {
            ScanKeyStart1G41( ) ;
            nGXsfl_41_idx = 1;
            while ( RcdFound41 != 0 )
            {
               Z206WWPFormId = A206WWPFormId;
               Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
               Z210WWPFormElementId = A210WWPFormElementId;
               ZM1G41( -11) ;
               OnLoadActions1G41( ) ;
               nRcdExists_41 = 1;
               nIsMod_41 = 0;
               AddRow1G41( ) ;
               nGXsfl_41_idx = (int)(nGXsfl_41_idx+1);
               ScanKeyNext1G41( ) ;
            }
            ScanKeyEnd1G41( ) ;
         }
         ScanKeyEnd1G40( ) ;
         if ( RcdFound40 == 0 )
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
         RowToVars40( bcUForm, 0) ;
         ScanKeyStart1G40( ) ;
         if ( RcdFound40 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
         }
         ZM1G40( -10) ;
         OnLoadActions1G40( ) ;
         AddRow1G40( ) ;
         bcUForm.gxTpr_Element.ClearCollection();
         if ( RcdFound40 == 1 )
         {
            ScanKeyStart1G41( ) ;
            nGXsfl_41_idx = 1;
            while ( RcdFound41 != 0 )
            {
               Z206WWPFormId = A206WWPFormId;
               Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
               Z210WWPFormElementId = A210WWPFormElementId;
               ZM1G41( -11) ;
               OnLoadActions1G41( ) ;
               nRcdExists_41 = 1;
               nIsMod_41 = 0;
               AddRow1G41( ) ;
               nGXsfl_41_idx = (int)(nGXsfl_41_idx+1);
               ScanKeyNext1G41( ) ;
            }
            ScanKeyEnd1G41( ) ;
         }
         ScanKeyEnd1G40( ) ;
         if ( RcdFound40 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1G40( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1G40( ) ;
         }
         else
         {
            if ( RcdFound40 == 1 )
            {
               if ( ( A206WWPFormId != Z206WWPFormId ) || ( A207WWPFormVersionNumber != Z207WWPFormVersionNumber ) )
               {
                  A206WWPFormId = Z206WWPFormId;
                  A207WWPFormVersionNumber = Z207WWPFormVersionNumber;
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
                  Update1G40( ) ;
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
                  if ( ( A206WWPFormId != Z206WWPFormId ) || ( A207WWPFormVersionNumber != Z207WWPFormVersionNumber ) )
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
                        Insert1G40( ) ;
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
                        Insert1G40( ) ;
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
         RowToVars40( bcUForm, 1) ;
         SaveImpl( ) ;
         VarsToRow40( bcUForm) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars40( bcUForm, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1G40( ) ;
         AfterTrn( ) ;
         VarsToRow40( bcUForm) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow40( bcUForm) ;
         }
         else
         {
            SdtUForm auxBC = new SdtUForm(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A206WWPFormId, A207WWPFormVersionNumber);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcUForm);
               auxBC.Save();
               bcUForm.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars40( bcUForm, 1) ;
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
         RowToVars40( bcUForm, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1G40( ) ;
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
               VarsToRow40( bcUForm) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow40( bcUForm) ;
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
         RowToVars40( bcUForm, 0) ;
         GetKey1G40( ) ;
         if ( RcdFound40 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A206WWPFormId != Z206WWPFormId ) || ( A207WWPFormVersionNumber != Z207WWPFormVersionNumber ) )
            {
               A206WWPFormId = Z206WWPFormId;
               A207WWPFormVersionNumber = Z207WWPFormVersionNumber;
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
            if ( ( A206WWPFormId != Z206WWPFormId ) || ( A207WWPFormVersionNumber != Z207WWPFormVersionNumber ) )
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
         context.RollbackDataStores("uform_bc",pr_default);
         VarsToRow40( bcUForm) ;
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
         Gx_mode = bcUForm.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcUForm.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcUForm )
         {
            bcUForm = (SdtUForm)(sdt);
            if ( StringUtil.StrCmp(bcUForm.gxTpr_Mode, "") == 0 )
            {
               bcUForm.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow40( bcUForm) ;
            }
            else
            {
               RowToVars40( bcUForm, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcUForm.gxTpr_Mode, "") == 0 )
            {
               bcUForm.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars40( bcUForm, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtUForm UForm_BC
      {
         get {
            return bcUForm ;
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
            return "uform_Execute" ;
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
         pr_default.close(21);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode40 = "";
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
         BC001G7_A206WWPFormId = new short[1] ;
         BC001G7_A207WWPFormVersionNumber = new short[1] ;
         BC001G7_A208WWPFormReferenceName = new string[] {""} ;
         BC001G7_A209WWPFormTitle = new string[] {""} ;
         BC001G7_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001G7_A232WWPFormIsWizard = new bool[] {false} ;
         BC001G7_A216WWPFormResume = new short[1] ;
         BC001G7_A235WWPFormResumeMessage = new string[] {""} ;
         BC001G7_A233WWPFormValidations = new string[] {""} ;
         BC001G7_A234WWPFormInstantiated = new bool[] {false} ;
         BC001G7_A240WWPFormType = new short[1] ;
         BC001G7_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001G7_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001G8_A206WWPFormId = new short[1] ;
         BC001G8_A207WWPFormVersionNumber = new short[1] ;
         BC001G6_A206WWPFormId = new short[1] ;
         BC001G6_A207WWPFormVersionNumber = new short[1] ;
         BC001G6_A208WWPFormReferenceName = new string[] {""} ;
         BC001G6_A209WWPFormTitle = new string[] {""} ;
         BC001G6_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001G6_A232WWPFormIsWizard = new bool[] {false} ;
         BC001G6_A216WWPFormResume = new short[1] ;
         BC001G6_A235WWPFormResumeMessage = new string[] {""} ;
         BC001G6_A233WWPFormValidations = new string[] {""} ;
         BC001G6_A234WWPFormInstantiated = new bool[] {false} ;
         BC001G6_A240WWPFormType = new short[1] ;
         BC001G6_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001G6_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001G5_A206WWPFormId = new short[1] ;
         BC001G5_A207WWPFormVersionNumber = new short[1] ;
         BC001G5_A208WWPFormReferenceName = new string[] {""} ;
         BC001G5_A209WWPFormTitle = new string[] {""} ;
         BC001G5_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001G5_A232WWPFormIsWizard = new bool[] {false} ;
         BC001G5_A216WWPFormResume = new short[1] ;
         BC001G5_A235WWPFormResumeMessage = new string[] {""} ;
         BC001G5_A233WWPFormValidations = new string[] {""} ;
         BC001G5_A234WWPFormInstantiated = new bool[] {false} ;
         BC001G5_A240WWPFormType = new short[1] ;
         BC001G5_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001G5_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         BC001G12_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001G12_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC001G13_A509OrganisationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001G13_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001G14_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         BC001G14_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001G14_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001G15_A214WWPFormInstanceId = new int[1] ;
         BC001G16_A206WWPFormId = new short[1] ;
         BC001G16_A207WWPFormVersionNumber = new short[1] ;
         BC001G16_A211WWPFormElementParentId = new short[1] ;
         BC001G16_n211WWPFormElementParentId = new bool[] {false} ;
         BC001G17_A206WWPFormId = new short[1] ;
         BC001G17_A207WWPFormVersionNumber = new short[1] ;
         BC001G17_A208WWPFormReferenceName = new string[] {""} ;
         BC001G17_A209WWPFormTitle = new string[] {""} ;
         BC001G17_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         BC001G17_A232WWPFormIsWizard = new bool[] {false} ;
         BC001G17_A216WWPFormResume = new short[1] ;
         BC001G17_A235WWPFormResumeMessage = new string[] {""} ;
         BC001G17_A233WWPFormValidations = new string[] {""} ;
         BC001G17_A234WWPFormInstantiated = new bool[] {false} ;
         BC001G17_A240WWPFormType = new short[1] ;
         BC001G17_A241WWPFormSectionRefElements = new string[] {""} ;
         BC001G17_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         Z213WWPFormElementReferenceId = "";
         A213WWPFormElementReferenceId = "";
         Z229WWPFormElementTitle = "";
         A229WWPFormElementTitle = "";
         Z236WWPFormElementMetadata = "";
         A236WWPFormElementMetadata = "";
         Z228WWPFormElementParentName = "";
         A228WWPFormElementParentName = "";
         BC001G18_A210WWPFormElementId = new short[1] ;
         BC001G18_A237WWPFormElementCaption = new short[1] ;
         BC001G18_A229WWPFormElementTitle = new string[] {""} ;
         BC001G18_A217WWPFormElementType = new short[1] ;
         BC001G18_A212WWPFormElementOrderIndex = new short[1] ;
         BC001G18_A218WWPFormElementDataType = new short[1] ;
         BC001G18_A228WWPFormElementParentName = new string[] {""} ;
         BC001G18_A230WWPFormElementParentType = new short[1] ;
         BC001G18_A236WWPFormElementMetadata = new string[] {""} ;
         BC001G18_A213WWPFormElementReferenceId = new string[] {""} ;
         BC001G18_A238WWPFormElementExcludeFromExpor = new bool[] {false} ;
         BC001G18_A206WWPFormId = new short[1] ;
         BC001G18_A207WWPFormVersionNumber = new short[1] ;
         BC001G18_A211WWPFormElementParentId = new short[1] ;
         BC001G18_n211WWPFormElementParentId = new bool[] {false} ;
         BC001G4_A228WWPFormElementParentName = new string[] {""} ;
         BC001G4_A230WWPFormElementParentType = new short[1] ;
         BC001G19_A206WWPFormId = new short[1] ;
         BC001G19_A207WWPFormVersionNumber = new short[1] ;
         BC001G19_A210WWPFormElementId = new short[1] ;
         BC001G3_A210WWPFormElementId = new short[1] ;
         BC001G3_A237WWPFormElementCaption = new short[1] ;
         BC001G3_A229WWPFormElementTitle = new string[] {""} ;
         BC001G3_A217WWPFormElementType = new short[1] ;
         BC001G3_A212WWPFormElementOrderIndex = new short[1] ;
         BC001G3_A218WWPFormElementDataType = new short[1] ;
         BC001G3_A236WWPFormElementMetadata = new string[] {""} ;
         BC001G3_A213WWPFormElementReferenceId = new string[] {""} ;
         BC001G3_A238WWPFormElementExcludeFromExpor = new bool[] {false} ;
         BC001G3_A206WWPFormId = new short[1] ;
         BC001G3_A207WWPFormVersionNumber = new short[1] ;
         BC001G3_A211WWPFormElementParentId = new short[1] ;
         BC001G3_n211WWPFormElementParentId = new bool[] {false} ;
         sMode41 = "";
         BC001G2_A210WWPFormElementId = new short[1] ;
         BC001G2_A237WWPFormElementCaption = new short[1] ;
         BC001G2_A229WWPFormElementTitle = new string[] {""} ;
         BC001G2_A217WWPFormElementType = new short[1] ;
         BC001G2_A212WWPFormElementOrderIndex = new short[1] ;
         BC001G2_A218WWPFormElementDataType = new short[1] ;
         BC001G2_A236WWPFormElementMetadata = new string[] {""} ;
         BC001G2_A213WWPFormElementReferenceId = new string[] {""} ;
         BC001G2_A238WWPFormElementExcludeFromExpor = new bool[] {false} ;
         BC001G2_A206WWPFormId = new short[1] ;
         BC001G2_A207WWPFormVersionNumber = new short[1] ;
         BC001G2_A211WWPFormElementParentId = new short[1] ;
         BC001G2_n211WWPFormElementParentId = new bool[] {false} ;
         BC001G23_A228WWPFormElementParentName = new string[] {""} ;
         BC001G23_A230WWPFormElementParentType = new short[1] ;
         BC001G24_A206WWPFormId = new short[1] ;
         BC001G24_A207WWPFormVersionNumber = new short[1] ;
         BC001G24_A211WWPFormElementParentId = new short[1] ;
         BC001G24_n211WWPFormElementParentId = new bool[] {false} ;
         BC001G25_A210WWPFormElementId = new short[1] ;
         BC001G25_A237WWPFormElementCaption = new short[1] ;
         BC001G25_A229WWPFormElementTitle = new string[] {""} ;
         BC001G25_A217WWPFormElementType = new short[1] ;
         BC001G25_A212WWPFormElementOrderIndex = new short[1] ;
         BC001G25_A218WWPFormElementDataType = new short[1] ;
         BC001G25_A228WWPFormElementParentName = new string[] {""} ;
         BC001G25_A230WWPFormElementParentType = new short[1] ;
         BC001G25_A236WWPFormElementMetadata = new string[] {""} ;
         BC001G25_A213WWPFormElementReferenceId = new string[] {""} ;
         BC001G25_A238WWPFormElementExcludeFromExpor = new bool[] {false} ;
         BC001G25_A206WWPFormId = new short[1] ;
         BC001G25_A207WWPFormVersionNumber = new short[1] ;
         BC001G25_A211WWPFormElementParentId = new short[1] ;
         BC001G25_n211WWPFormElementParentId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.uform_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.uform_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.uform_bc__default(),
            new Object[][] {
                new Object[] {
               BC001G2_A210WWPFormElementId, BC001G2_A237WWPFormElementCaption, BC001G2_A229WWPFormElementTitle, BC001G2_A217WWPFormElementType, BC001G2_A212WWPFormElementOrderIndex, BC001G2_A218WWPFormElementDataType, BC001G2_A236WWPFormElementMetadata, BC001G2_A213WWPFormElementReferenceId, BC001G2_A238WWPFormElementExcludeFromExpor, BC001G2_A206WWPFormId,
               BC001G2_A207WWPFormVersionNumber, BC001G2_A211WWPFormElementParentId, BC001G2_n211WWPFormElementParentId
               }
               , new Object[] {
               BC001G3_A210WWPFormElementId, BC001G3_A237WWPFormElementCaption, BC001G3_A229WWPFormElementTitle, BC001G3_A217WWPFormElementType, BC001G3_A212WWPFormElementOrderIndex, BC001G3_A218WWPFormElementDataType, BC001G3_A236WWPFormElementMetadata, BC001G3_A213WWPFormElementReferenceId, BC001G3_A238WWPFormElementExcludeFromExpor, BC001G3_A206WWPFormId,
               BC001G3_A207WWPFormVersionNumber, BC001G3_A211WWPFormElementParentId, BC001G3_n211WWPFormElementParentId
               }
               , new Object[] {
               BC001G4_A228WWPFormElementParentName, BC001G4_A230WWPFormElementParentType
               }
               , new Object[] {
               BC001G5_A206WWPFormId, BC001G5_A207WWPFormVersionNumber, BC001G5_A208WWPFormReferenceName, BC001G5_A209WWPFormTitle, BC001G5_A231WWPFormDate, BC001G5_A232WWPFormIsWizard, BC001G5_A216WWPFormResume, BC001G5_A235WWPFormResumeMessage, BC001G5_A233WWPFormValidations, BC001G5_A234WWPFormInstantiated,
               BC001G5_A240WWPFormType, BC001G5_A241WWPFormSectionRefElements, BC001G5_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               BC001G6_A206WWPFormId, BC001G6_A207WWPFormVersionNumber, BC001G6_A208WWPFormReferenceName, BC001G6_A209WWPFormTitle, BC001G6_A231WWPFormDate, BC001G6_A232WWPFormIsWizard, BC001G6_A216WWPFormResume, BC001G6_A235WWPFormResumeMessage, BC001G6_A233WWPFormValidations, BC001G6_A234WWPFormInstantiated,
               BC001G6_A240WWPFormType, BC001G6_A241WWPFormSectionRefElements, BC001G6_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               BC001G7_A206WWPFormId, BC001G7_A207WWPFormVersionNumber, BC001G7_A208WWPFormReferenceName, BC001G7_A209WWPFormTitle, BC001G7_A231WWPFormDate, BC001G7_A232WWPFormIsWizard, BC001G7_A216WWPFormResume, BC001G7_A235WWPFormResumeMessage, BC001G7_A233WWPFormValidations, BC001G7_A234WWPFormInstantiated,
               BC001G7_A240WWPFormType, BC001G7_A241WWPFormSectionRefElements, BC001G7_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               BC001G8_A206WWPFormId, BC001G8_A207WWPFormVersionNumber
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001G12_A616SupplierDynamicFormId, BC001G12_A42SupplierGenId
               }
               , new Object[] {
               BC001G13_A509OrganisationDynamicFormId, BC001G13_A11OrganisationId
               }
               , new Object[] {
               BC001G14_A366LocationDynamicFormId, BC001G14_A11OrganisationId, BC001G14_A29LocationId
               }
               , new Object[] {
               BC001G15_A214WWPFormInstanceId
               }
               , new Object[] {
               BC001G16_A206WWPFormId, BC001G16_A207WWPFormVersionNumber, BC001G16_A211WWPFormElementParentId
               }
               , new Object[] {
               BC001G17_A206WWPFormId, BC001G17_A207WWPFormVersionNumber, BC001G17_A208WWPFormReferenceName, BC001G17_A209WWPFormTitle, BC001G17_A231WWPFormDate, BC001G17_A232WWPFormIsWizard, BC001G17_A216WWPFormResume, BC001G17_A235WWPFormResumeMessage, BC001G17_A233WWPFormValidations, BC001G17_A234WWPFormInstantiated,
               BC001G17_A240WWPFormType, BC001G17_A241WWPFormSectionRefElements, BC001G17_A242WWPFormIsForDynamicValidations
               }
               , new Object[] {
               BC001G18_A210WWPFormElementId, BC001G18_A237WWPFormElementCaption, BC001G18_A229WWPFormElementTitle, BC001G18_A217WWPFormElementType, BC001G18_A212WWPFormElementOrderIndex, BC001G18_A218WWPFormElementDataType, BC001G18_A228WWPFormElementParentName, BC001G18_A230WWPFormElementParentType, BC001G18_A236WWPFormElementMetadata, BC001G18_A213WWPFormElementReferenceId,
               BC001G18_A238WWPFormElementExcludeFromExpor, BC001G18_A206WWPFormId, BC001G18_A207WWPFormVersionNumber, BC001G18_A211WWPFormElementParentId, BC001G18_n211WWPFormElementParentId
               }
               , new Object[] {
               BC001G19_A206WWPFormId, BC001G19_A207WWPFormVersionNumber, BC001G19_A210WWPFormElementId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001G23_A228WWPFormElementParentName, BC001G23_A230WWPFormElementParentType
               }
               , new Object[] {
               BC001G24_A206WWPFormId, BC001G24_A207WWPFormVersionNumber, BC001G24_A211WWPFormElementParentId
               }
               , new Object[] {
               BC001G25_A210WWPFormElementId, BC001G25_A237WWPFormElementCaption, BC001G25_A229WWPFormElementTitle, BC001G25_A217WWPFormElementType, BC001G25_A212WWPFormElementOrderIndex, BC001G25_A218WWPFormElementDataType, BC001G25_A228WWPFormElementParentName, BC001G25_A230WWPFormElementParentType, BC001G25_A236WWPFormElementMetadata, BC001G25_A213WWPFormElementReferenceId,
               BC001G25_A238WWPFormElementExcludeFromExpor, BC001G25_A206WWPFormId, BC001G25_A207WWPFormVersionNumber, BC001G25_A211WWPFormElementParentId, BC001G25_n211WWPFormElementParentId
               }
            }
         );
         Z237WWPFormElementCaption = 1;
         A237WWPFormElementCaption = 1;
         i237WWPFormElementCaption = 1;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121G2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z206WWPFormId ;
      private short A206WWPFormId ;
      private short Z207WWPFormVersionNumber ;
      private short A207WWPFormVersionNumber ;
      private short nIsMod_41 ;
      private short RcdFound41 ;
      private short Z216WWPFormResume ;
      private short A216WWPFormResume ;
      private short Z240WWPFormType ;
      private short A240WWPFormType ;
      private short Z219WWPFormLatestVersionNumber ;
      private short A219WWPFormLatestVersionNumber ;
      private short Gx_BScreen ;
      private short RcdFound40 ;
      private short GXt_int1 ;
      private short nRcdExists_41 ;
      private short Z237WWPFormElementCaption ;
      private short A237WWPFormElementCaption ;
      private short Z217WWPFormElementType ;
      private short A217WWPFormElementType ;
      private short Z212WWPFormElementOrderIndex ;
      private short A212WWPFormElementOrderIndex ;
      private short Z218WWPFormElementDataType ;
      private short A218WWPFormElementDataType ;
      private short Z211WWPFormElementParentId ;
      private short A211WWPFormElementParentId ;
      private short Z230WWPFormElementParentType ;
      private short A230WWPFormElementParentType ;
      private short Z210WWPFormElementId ;
      private short A210WWPFormElementId ;
      private short Gxremove41 ;
      private short i237WWPFormElementCaption ;
      private int trnEnded ;
      private int nGXsfl_41_idx=1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode40 ;
      private string sMode41 ;
      private DateTime Z231WWPFormDate ;
      private DateTime A231WWPFormDate ;
      private bool returnInSub ;
      private bool Z232WWPFormIsWizard ;
      private bool A232WWPFormIsWizard ;
      private bool Z234WWPFormInstantiated ;
      private bool A234WWPFormInstantiated ;
      private bool Z242WWPFormIsForDynamicValidations ;
      private bool A242WWPFormIsForDynamicValidations ;
      private bool Gx_longc ;
      private bool Z238WWPFormElementExcludeFromExpor ;
      private bool A238WWPFormElementExcludeFromExpor ;
      private bool n211WWPFormElementParentId ;
      private string Z235WWPFormResumeMessage ;
      private string A235WWPFormResumeMessage ;
      private string Z233WWPFormValidations ;
      private string A233WWPFormValidations ;
      private string Z229WWPFormElementTitle ;
      private string A229WWPFormElementTitle ;
      private string Z236WWPFormElementMetadata ;
      private string A236WWPFormElementMetadata ;
      private string Z228WWPFormElementParentName ;
      private string A228WWPFormElementParentName ;
      private string Z208WWPFormReferenceName ;
      private string A208WWPFormReferenceName ;
      private string Z209WWPFormTitle ;
      private string A209WWPFormTitle ;
      private string Z241WWPFormSectionRefElements ;
      private string A241WWPFormSectionRefElements ;
      private string Z213WWPFormElementReferenceId ;
      private string A213WWPFormElementReferenceId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtUForm bcUForm ;
      private IDataStoreProvider pr_default ;
      private short[] BC001G7_A206WWPFormId ;
      private short[] BC001G7_A207WWPFormVersionNumber ;
      private string[] BC001G7_A208WWPFormReferenceName ;
      private string[] BC001G7_A209WWPFormTitle ;
      private DateTime[] BC001G7_A231WWPFormDate ;
      private bool[] BC001G7_A232WWPFormIsWizard ;
      private short[] BC001G7_A216WWPFormResume ;
      private string[] BC001G7_A235WWPFormResumeMessage ;
      private string[] BC001G7_A233WWPFormValidations ;
      private bool[] BC001G7_A234WWPFormInstantiated ;
      private short[] BC001G7_A240WWPFormType ;
      private string[] BC001G7_A241WWPFormSectionRefElements ;
      private bool[] BC001G7_A242WWPFormIsForDynamicValidations ;
      private short[] BC001G8_A206WWPFormId ;
      private short[] BC001G8_A207WWPFormVersionNumber ;
      private short[] BC001G6_A206WWPFormId ;
      private short[] BC001G6_A207WWPFormVersionNumber ;
      private string[] BC001G6_A208WWPFormReferenceName ;
      private string[] BC001G6_A209WWPFormTitle ;
      private DateTime[] BC001G6_A231WWPFormDate ;
      private bool[] BC001G6_A232WWPFormIsWizard ;
      private short[] BC001G6_A216WWPFormResume ;
      private string[] BC001G6_A235WWPFormResumeMessage ;
      private string[] BC001G6_A233WWPFormValidations ;
      private bool[] BC001G6_A234WWPFormInstantiated ;
      private short[] BC001G6_A240WWPFormType ;
      private string[] BC001G6_A241WWPFormSectionRefElements ;
      private bool[] BC001G6_A242WWPFormIsForDynamicValidations ;
      private short[] BC001G5_A206WWPFormId ;
      private short[] BC001G5_A207WWPFormVersionNumber ;
      private string[] BC001G5_A208WWPFormReferenceName ;
      private string[] BC001G5_A209WWPFormTitle ;
      private DateTime[] BC001G5_A231WWPFormDate ;
      private bool[] BC001G5_A232WWPFormIsWizard ;
      private short[] BC001G5_A216WWPFormResume ;
      private string[] BC001G5_A235WWPFormResumeMessage ;
      private string[] BC001G5_A233WWPFormValidations ;
      private bool[] BC001G5_A234WWPFormInstantiated ;
      private short[] BC001G5_A240WWPFormType ;
      private string[] BC001G5_A241WWPFormSectionRefElements ;
      private bool[] BC001G5_A242WWPFormIsForDynamicValidations ;
      private Guid[] BC001G12_A616SupplierDynamicFormId ;
      private Guid[] BC001G12_A42SupplierGenId ;
      private Guid[] BC001G13_A509OrganisationDynamicFormId ;
      private Guid[] BC001G13_A11OrganisationId ;
      private Guid[] BC001G14_A366LocationDynamicFormId ;
      private Guid[] BC001G14_A11OrganisationId ;
      private Guid[] BC001G14_A29LocationId ;
      private int[] BC001G15_A214WWPFormInstanceId ;
      private short[] BC001G16_A206WWPFormId ;
      private short[] BC001G16_A207WWPFormVersionNumber ;
      private short[] BC001G16_A211WWPFormElementParentId ;
      private bool[] BC001G16_n211WWPFormElementParentId ;
      private short[] BC001G17_A206WWPFormId ;
      private short[] BC001G17_A207WWPFormVersionNumber ;
      private string[] BC001G17_A208WWPFormReferenceName ;
      private string[] BC001G17_A209WWPFormTitle ;
      private DateTime[] BC001G17_A231WWPFormDate ;
      private bool[] BC001G17_A232WWPFormIsWizard ;
      private short[] BC001G17_A216WWPFormResume ;
      private string[] BC001G17_A235WWPFormResumeMessage ;
      private string[] BC001G17_A233WWPFormValidations ;
      private bool[] BC001G17_A234WWPFormInstantiated ;
      private short[] BC001G17_A240WWPFormType ;
      private string[] BC001G17_A241WWPFormSectionRefElements ;
      private bool[] BC001G17_A242WWPFormIsForDynamicValidations ;
      private short[] BC001G18_A210WWPFormElementId ;
      private short[] BC001G18_A237WWPFormElementCaption ;
      private string[] BC001G18_A229WWPFormElementTitle ;
      private short[] BC001G18_A217WWPFormElementType ;
      private short[] BC001G18_A212WWPFormElementOrderIndex ;
      private short[] BC001G18_A218WWPFormElementDataType ;
      private string[] BC001G18_A228WWPFormElementParentName ;
      private short[] BC001G18_A230WWPFormElementParentType ;
      private string[] BC001G18_A236WWPFormElementMetadata ;
      private string[] BC001G18_A213WWPFormElementReferenceId ;
      private bool[] BC001G18_A238WWPFormElementExcludeFromExpor ;
      private short[] BC001G18_A206WWPFormId ;
      private short[] BC001G18_A207WWPFormVersionNumber ;
      private short[] BC001G18_A211WWPFormElementParentId ;
      private bool[] BC001G18_n211WWPFormElementParentId ;
      private string[] BC001G4_A228WWPFormElementParentName ;
      private short[] BC001G4_A230WWPFormElementParentType ;
      private short[] BC001G19_A206WWPFormId ;
      private short[] BC001G19_A207WWPFormVersionNumber ;
      private short[] BC001G19_A210WWPFormElementId ;
      private short[] BC001G3_A210WWPFormElementId ;
      private short[] BC001G3_A237WWPFormElementCaption ;
      private string[] BC001G3_A229WWPFormElementTitle ;
      private short[] BC001G3_A217WWPFormElementType ;
      private short[] BC001G3_A212WWPFormElementOrderIndex ;
      private short[] BC001G3_A218WWPFormElementDataType ;
      private string[] BC001G3_A236WWPFormElementMetadata ;
      private string[] BC001G3_A213WWPFormElementReferenceId ;
      private bool[] BC001G3_A238WWPFormElementExcludeFromExpor ;
      private short[] BC001G3_A206WWPFormId ;
      private short[] BC001G3_A207WWPFormVersionNumber ;
      private short[] BC001G3_A211WWPFormElementParentId ;
      private bool[] BC001G3_n211WWPFormElementParentId ;
      private short[] BC001G2_A210WWPFormElementId ;
      private short[] BC001G2_A237WWPFormElementCaption ;
      private string[] BC001G2_A229WWPFormElementTitle ;
      private short[] BC001G2_A217WWPFormElementType ;
      private short[] BC001G2_A212WWPFormElementOrderIndex ;
      private short[] BC001G2_A218WWPFormElementDataType ;
      private string[] BC001G2_A236WWPFormElementMetadata ;
      private string[] BC001G2_A213WWPFormElementReferenceId ;
      private bool[] BC001G2_A238WWPFormElementExcludeFromExpor ;
      private short[] BC001G2_A206WWPFormId ;
      private short[] BC001G2_A207WWPFormVersionNumber ;
      private short[] BC001G2_A211WWPFormElementParentId ;
      private bool[] BC001G2_n211WWPFormElementParentId ;
      private string[] BC001G23_A228WWPFormElementParentName ;
      private short[] BC001G23_A230WWPFormElementParentType ;
      private short[] BC001G24_A206WWPFormId ;
      private short[] BC001G24_A207WWPFormVersionNumber ;
      private short[] BC001G24_A211WWPFormElementParentId ;
      private bool[] BC001G24_n211WWPFormElementParentId ;
      private short[] BC001G25_A210WWPFormElementId ;
      private short[] BC001G25_A237WWPFormElementCaption ;
      private string[] BC001G25_A229WWPFormElementTitle ;
      private short[] BC001G25_A217WWPFormElementType ;
      private short[] BC001G25_A212WWPFormElementOrderIndex ;
      private short[] BC001G25_A218WWPFormElementDataType ;
      private string[] BC001G25_A228WWPFormElementParentName ;
      private short[] BC001G25_A230WWPFormElementParentType ;
      private string[] BC001G25_A236WWPFormElementMetadata ;
      private string[] BC001G25_A213WWPFormElementReferenceId ;
      private bool[] BC001G25_A238WWPFormElementExcludeFromExpor ;
      private short[] BC001G25_A206WWPFormId ;
      private short[] BC001G25_A207WWPFormVersionNumber ;
      private short[] BC001G25_A211WWPFormElementParentId ;
      private bool[] BC001G25_n211WWPFormElementParentId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class uform_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class uform_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class uform_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
      ,new ForEachCursor(def[16])
      ,new ForEachCursor(def[17])
      ,new UpdateCursor(def[18])
      ,new UpdateCursor(def[19])
      ,new UpdateCursor(def[20])
      ,new ForEachCursor(def[21])
      ,new ForEachCursor(def[22])
      ,new ForEachCursor(def[23])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC001G2;
       prmBC001G2 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmBC001G3;
       prmBC001G3 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmBC001G4;
       prmBC001G4 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmBC001G5;
       prmBC001G5 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001G6;
       prmBC001G6 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001G7;
       prmBC001G7 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001G8;
       prmBC001G8 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001G9;
       prmBC001G9 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormReferenceName",GXType.VarChar,100,0) ,
       new ParDef("WWPFormTitle",GXType.VarChar,100,0) ,
       new ParDef("WWPFormDate",GXType.DateTime,8,5) ,
       new ParDef("WWPFormIsWizard",GXType.Boolean,4,0) ,
       new ParDef("WWPFormResume",GXType.Int16,1,0) ,
       new ParDef("WWPFormResumeMessage",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPFormValidations",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPFormInstantiated",GXType.Boolean,4,0) ,
       new ParDef("WWPFormType",GXType.Int16,1,0) ,
       new ParDef("WWPFormSectionRefElements",GXType.VarChar,400,0) ,
       new ParDef("WWPFormIsForDynamicValidations",GXType.Boolean,4,0)
       };
       Object[] prmBC001G10;
       prmBC001G10 = new Object[] {
       new ParDef("WWPFormReferenceName",GXType.VarChar,100,0) ,
       new ParDef("WWPFormTitle",GXType.VarChar,100,0) ,
       new ParDef("WWPFormDate",GXType.DateTime,8,5) ,
       new ParDef("WWPFormIsWizard",GXType.Boolean,4,0) ,
       new ParDef("WWPFormResume",GXType.Int16,1,0) ,
       new ParDef("WWPFormResumeMessage",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPFormValidations",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPFormInstantiated",GXType.Boolean,4,0) ,
       new ParDef("WWPFormType",GXType.Int16,1,0) ,
       new ParDef("WWPFormSectionRefElements",GXType.VarChar,400,0) ,
       new ParDef("WWPFormIsForDynamicValidations",GXType.Boolean,4,0) ,
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001G11;
       prmBC001G11 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001G12;
       prmBC001G12 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001G13;
       prmBC001G13 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001G14;
       prmBC001G14 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001G15;
       prmBC001G15 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001G16;
       prmBC001G16 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001G17;
       prmBC001G17 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC001G18;
       prmBC001G18 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmBC001G19;
       prmBC001G19 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmBC001G20;
       prmBC001G20 = new Object[] {
       new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementCaption",GXType.Int16,1,0) ,
       new ParDef("WWPFormElementTitle",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPFormElementType",GXType.Int16,1,0) ,
       new ParDef("WWPFormElementOrderIndex",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementDataType",GXType.Int16,2,0) ,
       new ParDef("WWPFormElementMetadata",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPFormElementReferenceId",GXType.VarChar,100,0) ,
       new ParDef("WWPFormElementExcludeFromExpor",GXType.Boolean,4,0) ,
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmBC001G21;
       prmBC001G21 = new Object[] {
       new ParDef("WWPFormElementCaption",GXType.Int16,1,0) ,
       new ParDef("WWPFormElementTitle",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPFormElementType",GXType.Int16,1,0) ,
       new ParDef("WWPFormElementOrderIndex",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementDataType",GXType.Int16,2,0) ,
       new ParDef("WWPFormElementMetadata",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPFormElementReferenceId",GXType.VarChar,100,0) ,
       new ParDef("WWPFormElementExcludeFromExpor",GXType.Boolean,4,0) ,
       new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true} ,
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmBC001G22;
       prmBC001G22 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmBC001G23;
       prmBC001G23 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmBC001G24;
       prmBC001G24 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmBC001G25;
       prmBC001G25 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001G2", "SELECT WWPFormElementId, WWPFormElementCaption, WWPFormElementTitle, WWPFormElementType, WWPFormElementOrderIndex, WWPFormElementDataType, WWPFormElementMetadata, WWPFormElementReferenceId, WWPFormElementExcludeFromExpor, WWPFormId, WWPFormVersionNumber, WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId  FOR UPDATE OF WWP_FormElement",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G3", "SELECT WWPFormElementId, WWPFormElementCaption, WWPFormElementTitle, WWPFormElementType, WWPFormElementOrderIndex, WWPFormElementDataType, WWPFormElementMetadata, WWPFormElementReferenceId, WWPFormElementExcludeFromExpor, WWPFormId, WWPFormVersionNumber, WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G4", "SELECT WWPFormElementTitle AS WWPFormElementParentName, WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G5", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber  FOR UPDATE OF WWP_Form",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G6", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G7", "SELECT TM1.WWPFormId, TM1.WWPFormVersionNumber, TM1.WWPFormReferenceName, TM1.WWPFormTitle, TM1.WWPFormDate, TM1.WWPFormIsWizard, TM1.WWPFormResume, TM1.WWPFormResumeMessage, TM1.WWPFormValidations, TM1.WWPFormInstantiated, TM1.WWPFormType, TM1.WWPFormSectionRefElements, TM1.WWPFormIsForDynamicValidations FROM WWP_Form TM1 WHERE TM1.WWPFormId = :WWPFormId and TM1.WWPFormVersionNumber = :WWPFormVersionNumber ORDER BY TM1.WWPFormId, TM1.WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G7,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G8", "SELECT WWPFormId, WWPFormVersionNumber FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G9", "SAVEPOINT gxupdate;INSERT INTO WWP_Form(WWPFormId, WWPFormVersionNumber, WWPFormReferenceName, WWPFormTitle, WWPFormDate, WWPFormIsWizard, WWPFormResume, WWPFormResumeMessage, WWPFormValidations, WWPFormInstantiated, WWPFormType, WWPFormSectionRefElements, WWPFormIsForDynamicValidations) VALUES(:WWPFormId, :WWPFormVersionNumber, :WWPFormReferenceName, :WWPFormTitle, :WWPFormDate, :WWPFormIsWizard, :WWPFormResume, :WWPFormResumeMessage, :WWPFormValidations, :WWPFormInstantiated, :WWPFormType, :WWPFormSectionRefElements, :WWPFormIsForDynamicValidations);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001G9)
          ,new CursorDef("BC001G10", "SAVEPOINT gxupdate;UPDATE WWP_Form SET WWPFormReferenceName=:WWPFormReferenceName, WWPFormTitle=:WWPFormTitle, WWPFormDate=:WWPFormDate, WWPFormIsWizard=:WWPFormIsWizard, WWPFormResume=:WWPFormResume, WWPFormResumeMessage=:WWPFormResumeMessage, WWPFormValidations=:WWPFormValidations, WWPFormInstantiated=:WWPFormInstantiated, WWPFormType=:WWPFormType, WWPFormSectionRefElements=:WWPFormSectionRefElements, WWPFormIsForDynamicValidations=:WWPFormIsForDynamicValidations  WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001G10)
          ,new CursorDef("BC001G11", "SAVEPOINT gxupdate;DELETE FROM WWP_Form  WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001G11)
          ,new CursorDef("BC001G12", "SELECT SupplierDynamicFormId, SupplierGenId FROM Trn_SupplierDynamicForm WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G12,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC001G13", "SELECT OrganisationDynamicFormId, OrganisationId FROM Trn_OrganisationDynamicForm WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G13,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC001G14", "SELECT LocationDynamicFormId, OrganisationId, LocationId FROM Trn_LocationDynamicForm WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G14,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC001G15", "SELECT WWPFormInstanceId FROM WWP_FormInstance WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G15,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC001G16", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementId AS WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G16,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC001G17", "SELECT TM1.WWPFormId, TM1.WWPFormVersionNumber, TM1.WWPFormReferenceName, TM1.WWPFormTitle, TM1.WWPFormDate, TM1.WWPFormIsWizard, TM1.WWPFormResume, TM1.WWPFormResumeMessage, TM1.WWPFormValidations, TM1.WWPFormInstantiated, TM1.WWPFormType, TM1.WWPFormSectionRefElements, TM1.WWPFormIsForDynamicValidations FROM WWP_Form TM1 WHERE TM1.WWPFormId = :WWPFormId and TM1.WWPFormVersionNumber = :WWPFormVersionNumber ORDER BY TM1.WWPFormId, TM1.WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G17,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G18", "SELECT T1.WWPFormElementId, T1.WWPFormElementCaption, T1.WWPFormElementTitle, T1.WWPFormElementType, T1.WWPFormElementOrderIndex, T1.WWPFormElementDataType, T2.WWPFormElementTitle AS WWPFormElementParentName, T2.WWPFormElementType AS WWPFormElementParentType, T1.WWPFormElementMetadata, T1.WWPFormElementReferenceId, T1.WWPFormElementExcludeFromExpor, T1.WWPFormId, T1.WWPFormVersionNumber, T1.WWPFormElementParentId AS WWPFormElementParentId FROM (WWP_FormElement T1 LEFT JOIN WWP_FormElement T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber AND T2.WWPFormElementId = T1.WWPFormElementParentId) WHERE T1.WWPFormId = :WWPFormId and T1.WWPFormVersionNumber = :WWPFormVersionNumber and T1.WWPFormElementId = :WWPFormElementId ORDER BY T1.WWPFormId, T1.WWPFormVersionNumber, T1.WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G18,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G19", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G19,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G20", "SAVEPOINT gxupdate;INSERT INTO WWP_FormElement(WWPFormElementId, WWPFormElementCaption, WWPFormElementTitle, WWPFormElementType, WWPFormElementOrderIndex, WWPFormElementDataType, WWPFormElementMetadata, WWPFormElementReferenceId, WWPFormElementExcludeFromExpor, WWPFormId, WWPFormVersionNumber, WWPFormElementParentId) VALUES(:WWPFormElementId, :WWPFormElementCaption, :WWPFormElementTitle, :WWPFormElementType, :WWPFormElementOrderIndex, :WWPFormElementDataType, :WWPFormElementMetadata, :WWPFormElementReferenceId, :WWPFormElementExcludeFromExpor, :WWPFormId, :WWPFormVersionNumber, :WWPFormElementParentId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001G20)
          ,new CursorDef("BC001G21", "SAVEPOINT gxupdate;UPDATE WWP_FormElement SET WWPFormElementCaption=:WWPFormElementCaption, WWPFormElementTitle=:WWPFormElementTitle, WWPFormElementType=:WWPFormElementType, WWPFormElementOrderIndex=:WWPFormElementOrderIndex, WWPFormElementDataType=:WWPFormElementDataType, WWPFormElementMetadata=:WWPFormElementMetadata, WWPFormElementReferenceId=:WWPFormElementReferenceId, WWPFormElementExcludeFromExpor=:WWPFormElementExcludeFromExpor, WWPFormElementParentId=:WWPFormElementParentId  WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001G21)
          ,new CursorDef("BC001G22", "SAVEPOINT gxupdate;DELETE FROM WWP_FormElement  WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001G22)
          ,new CursorDef("BC001G23", "SELECT WWPFormElementTitle AS WWPFormElementParentName, WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G23,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001G24", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementId AS WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementParentId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G24,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC001G25", "SELECT T1.WWPFormElementId, T1.WWPFormElementCaption, T1.WWPFormElementTitle, T1.WWPFormElementType, T1.WWPFormElementOrderIndex, T1.WWPFormElementDataType, T2.WWPFormElementTitle AS WWPFormElementParentName, T2.WWPFormElementType AS WWPFormElementParentType, T1.WWPFormElementMetadata, T1.WWPFormElementReferenceId, T1.WWPFormElementExcludeFromExpor, T1.WWPFormId, T1.WWPFormVersionNumber, T1.WWPFormElementParentId AS WWPFormElementParentId FROM (WWP_FormElement T1 LEFT JOIN WWP_FormElement T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber AND T2.WWPFormElementId = T1.WWPFormElementParentId) WHERE T1.WWPFormId = :WWPFormId and T1.WWPFormVersionNumber = :WWPFormVersionNumber ORDER BY T1.WWPFormId, T1.WWPFormVersionNumber, T1.WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G25,11, GxCacheFrequency.OFF ,true,false )
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
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((short[]) buf[9])[0] = rslt.getShort(10);
             ((short[]) buf[10])[0] = rslt.getShort(11);
             ((short[]) buf[11])[0] = rslt.getShort(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             return;
          case 1 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((short[]) buf[9])[0] = rslt.getShort(10);
             ((short[]) buf[10])[0] = rslt.getShort(11);
             ((short[]) buf[11])[0] = rslt.getShort(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 3 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
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
             return;
          case 4 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
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
             return;
          case 5 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
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
             return;
          case 6 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 13 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             return;
          case 14 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             return;
          case 15 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
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
             return;
          case 16 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((short[]) buf[7])[0] = rslt.getShort(8);
             ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             ((short[]) buf[11])[0] = rslt.getShort(12);
             ((short[]) buf[12])[0] = rslt.getShort(13);
             ((short[]) buf[13])[0] = rslt.getShort(14);
             ((bool[]) buf[14])[0] = rslt.wasNull(14);
             return;
          case 17 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             return;
          case 21 :
             ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 22 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             return;
          case 23 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((short[]) buf[7])[0] = rslt.getShort(8);
             ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             ((short[]) buf[11])[0] = rslt.getShort(12);
             ((short[]) buf[12])[0] = rslt.getShort(13);
             ((short[]) buf[13])[0] = rslt.getShort(14);
             ((bool[]) buf[14])[0] = rslt.wasNull(14);
             return;
    }
 }

}

}
