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
namespace GeneXus.Programs.workwithplus {
   public class wwp_parameter_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_parameter_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_parameter_bc( IGxContext context )
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
         ReadRow0H27( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0H27( ) ;
         standaloneModal( ) ;
         AddRow0H27( ) ;
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
            E110H2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z106WWPParameterKey = A106WWPParameterKey;
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

      protected void CONFIRM_0H0( )
      {
         BeforeValidate0H27( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0H27( ) ;
            }
            else
            {
               CheckExtendedTable0H27( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0H27( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120H2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110H2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0H27( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z108WWPParameterCategory = A108WWPParameterCategory;
            Z109WWPParameterDescription = A109WWPParameterDescription;
            Z110WWPParameterDisableDelete = A110WWPParameterDisableDelete;
            Z111WWPParameterValueTrimmed = A111WWPParameterValueTrimmed;
         }
         if ( GX_JID == -3 )
         {
            Z106WWPParameterKey = A106WWPParameterKey;
            Z108WWPParameterCategory = A108WWPParameterCategory;
            Z109WWPParameterDescription = A109WWPParameterDescription;
            Z107WWPParameterValue = A107WWPParameterValue;
            Z110WWPParameterDisableDelete = A110WWPParameterDisableDelete;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0H27( )
      {
         /* Using cursor BC000H4 */
         pr_default.execute(2, new Object[] {A106WWPParameterKey});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound27 = 1;
            A108WWPParameterCategory = BC000H4_A108WWPParameterCategory[0];
            A109WWPParameterDescription = BC000H4_A109WWPParameterDescription[0];
            A107WWPParameterValue = BC000H4_A107WWPParameterValue[0];
            A110WWPParameterDisableDelete = BC000H4_A110WWPParameterDisableDelete[0];
            ZM0H27( -3) ;
         }
         pr_default.close(2);
         OnLoadActions0H27( ) ;
      }

      protected void OnLoadActions0H27( )
      {
         if ( StringUtil.Len( A107WWPParameterValue) <= 30 )
         {
            A111WWPParameterValueTrimmed = A107WWPParameterValue;
         }
         else
         {
            A111WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A107WWPParameterValue, 1, 27)) + "...";
         }
      }

      protected void CheckExtendedTable0H27( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A106WWPParameterKey)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_ParameterKey_Attribute_Description", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( StringUtil.Len( A107WWPParameterValue) <= 30 )
         {
            A111WWPParameterValueTrimmed = A107WWPParameterValue;
         }
         else
         {
            A111WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A107WWPParameterValue, 1, 27)) + "...";
         }
      }

      protected void CloseExtendedTableCursors0H27( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0H27( )
      {
         /* Using cursor BC000H5 */
         pr_default.execute(3, new Object[] {A106WWPParameterKey});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound27 = 1;
         }
         else
         {
            RcdFound27 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000H3 */
         pr_default.execute(1, new Object[] {A106WWPParameterKey});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0H27( 3) ;
            RcdFound27 = 1;
            A106WWPParameterKey = BC000H3_A106WWPParameterKey[0];
            A108WWPParameterCategory = BC000H3_A108WWPParameterCategory[0];
            A109WWPParameterDescription = BC000H3_A109WWPParameterDescription[0];
            A107WWPParameterValue = BC000H3_A107WWPParameterValue[0];
            A110WWPParameterDisableDelete = BC000H3_A110WWPParameterDisableDelete[0];
            Z106WWPParameterKey = A106WWPParameterKey;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0H27( ) ;
            if ( AnyError == 1 )
            {
               RcdFound27 = 0;
               InitializeNonKey0H27( ) ;
            }
            Gx_mode = sMode27;
         }
         else
         {
            RcdFound27 = 0;
            InitializeNonKey0H27( ) ;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode27;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0H27( ) ;
         if ( RcdFound27 == 0 )
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
         CONFIRM_0H0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0H27( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000H2 */
            pr_default.execute(0, new Object[] {A106WWPParameterKey});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Parameter"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z108WWPParameterCategory, BC000H2_A108WWPParameterCategory[0]) != 0 ) || ( StringUtil.StrCmp(Z109WWPParameterDescription, BC000H2_A109WWPParameterDescription[0]) != 0 ) || ( Z110WWPParameterDisableDelete != BC000H2_A110WWPParameterDisableDelete[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Parameter"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0H27( )
      {
         BeforeValidate0H27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H27( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0H27( 0) ;
            CheckOptimisticConcurrency0H27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0H27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000H6 */
                     pr_default.execute(4, new Object[] {A106WWPParameterKey, A108WWPParameterCategory, A109WWPParameterDescription, A107WWPParameterValue, A110WWPParameterDisableDelete});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Parameter");
                     if ( (pr_default.getStatus(4) == 1) )
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
               Load0H27( ) ;
            }
            EndLevel0H27( ) ;
         }
         CloseExtendedTableCursors0H27( ) ;
      }

      protected void Update0H27( )
      {
         BeforeValidate0H27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H27( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0H27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000H7 */
                     pr_default.execute(5, new Object[] {A108WWPParameterCategory, A109WWPParameterDescription, A107WWPParameterValue, A110WWPParameterDisableDelete, A106WWPParameterKey});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Parameter");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Parameter"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0H27( ) ;
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
            EndLevel0H27( ) ;
         }
         CloseExtendedTableCursors0H27( ) ;
      }

      protected void DeferredUpdate0H27( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0H27( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H27( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0H27( ) ;
            AfterConfirm0H27( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0H27( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000H8 */
                  pr_default.execute(6, new Object[] {A106WWPParameterKey});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Parameter");
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
         sMode27 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0H27( ) ;
         Gx_mode = sMode27;
      }

      protected void OnDeleteControls0H27( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( StringUtil.Len( A107WWPParameterValue) <= 30 )
            {
               A111WWPParameterValueTrimmed = A107WWPParameterValue;
            }
            else
            {
               A111WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A107WWPParameterValue, 1, 27)) + "...";
            }
         }
      }

      protected void EndLevel0H27( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0H27( ) ;
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

      public void ScanKeyStart0H27( )
      {
         /* Scan By routine */
         /* Using cursor BC000H9 */
         pr_default.execute(7, new Object[] {A106WWPParameterKey});
         RcdFound27 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound27 = 1;
            A106WWPParameterKey = BC000H9_A106WWPParameterKey[0];
            A108WWPParameterCategory = BC000H9_A108WWPParameterCategory[0];
            A109WWPParameterDescription = BC000H9_A109WWPParameterDescription[0];
            A107WWPParameterValue = BC000H9_A107WWPParameterValue[0];
            A110WWPParameterDisableDelete = BC000H9_A110WWPParameterDisableDelete[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0H27( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound27 = 0;
         ScanKeyLoad0H27( ) ;
      }

      protected void ScanKeyLoad0H27( )
      {
         sMode27 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound27 = 1;
            A106WWPParameterKey = BC000H9_A106WWPParameterKey[0];
            A108WWPParameterCategory = BC000H9_A108WWPParameterCategory[0];
            A109WWPParameterDescription = BC000H9_A109WWPParameterDescription[0];
            A107WWPParameterValue = BC000H9_A107WWPParameterValue[0];
            A110WWPParameterDisableDelete = BC000H9_A110WWPParameterDisableDelete[0];
         }
         Gx_mode = sMode27;
      }

      protected void ScanKeyEnd0H27( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm0H27( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0H27( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0H27( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0H27( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0H27( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0H27( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0H27( )
      {
      }

      protected void send_integrity_lvl_hashes0H27( )
      {
      }

      protected void AddRow0H27( )
      {
         VarsToRow27( bcworkwithplus_WWP_Parameter) ;
      }

      protected void ReadRow0H27( )
      {
         RowToVars27( bcworkwithplus_WWP_Parameter, 1) ;
      }

      protected void InitializeNonKey0H27( )
      {
         A111WWPParameterValueTrimmed = "";
         A108WWPParameterCategory = "";
         A109WWPParameterDescription = "";
         A107WWPParameterValue = "";
         A110WWPParameterDisableDelete = false;
         Z108WWPParameterCategory = "";
         Z109WWPParameterDescription = "";
         Z110WWPParameterDisableDelete = false;
      }

      protected void InitAll0H27( )
      {
         A106WWPParameterKey = "";
         InitializeNonKey0H27( ) ;
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

      public void VarsToRow27( GeneXus.Programs.workwithplus.SdtWWP_Parameter obj27 )
      {
         obj27.gxTpr_Mode = Gx_mode;
         obj27.gxTpr_Wwpparametervaluetrimmed = A111WWPParameterValueTrimmed;
         obj27.gxTpr_Wwpparametercategory = A108WWPParameterCategory;
         obj27.gxTpr_Wwpparameterdescription = A109WWPParameterDescription;
         obj27.gxTpr_Wwpparametervalue = A107WWPParameterValue;
         obj27.gxTpr_Wwpparameterdisabledelete = A110WWPParameterDisableDelete;
         obj27.gxTpr_Wwpparameterkey = A106WWPParameterKey;
         obj27.gxTpr_Wwpparameterkey_Z = Z106WWPParameterKey;
         obj27.gxTpr_Wwpparametercategory_Z = Z108WWPParameterCategory;
         obj27.gxTpr_Wwpparameterdescription_Z = Z109WWPParameterDescription;
         obj27.gxTpr_Wwpparametervaluetrimmed_Z = Z111WWPParameterValueTrimmed;
         obj27.gxTpr_Wwpparameterdisabledelete_Z = Z110WWPParameterDisableDelete;
         obj27.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow27( GeneXus.Programs.workwithplus.SdtWWP_Parameter obj27 )
      {
         obj27.gxTpr_Wwpparameterkey = A106WWPParameterKey;
         return  ;
      }

      public void RowToVars27( GeneXus.Programs.workwithplus.SdtWWP_Parameter obj27 ,
                               int forceLoad )
      {
         Gx_mode = obj27.gxTpr_Mode;
         A111WWPParameterValueTrimmed = obj27.gxTpr_Wwpparametervaluetrimmed;
         A108WWPParameterCategory = obj27.gxTpr_Wwpparametercategory;
         A109WWPParameterDescription = obj27.gxTpr_Wwpparameterdescription;
         A107WWPParameterValue = obj27.gxTpr_Wwpparametervalue;
         A110WWPParameterDisableDelete = obj27.gxTpr_Wwpparameterdisabledelete;
         A106WWPParameterKey = obj27.gxTpr_Wwpparameterkey;
         Z106WWPParameterKey = obj27.gxTpr_Wwpparameterkey_Z;
         Z108WWPParameterCategory = obj27.gxTpr_Wwpparametercategory_Z;
         Z109WWPParameterDescription = obj27.gxTpr_Wwpparameterdescription_Z;
         Z111WWPParameterValueTrimmed = obj27.gxTpr_Wwpparametervaluetrimmed_Z;
         Z110WWPParameterDisableDelete = obj27.gxTpr_Wwpparameterdisabledelete_Z;
         Gx_mode = obj27.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A106WWPParameterKey = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0H27( ) ;
         ScanKeyStart0H27( ) ;
         if ( RcdFound27 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z106WWPParameterKey = A106WWPParameterKey;
         }
         ZM0H27( -3) ;
         OnLoadActions0H27( ) ;
         AddRow0H27( ) ;
         ScanKeyEnd0H27( ) ;
         if ( RcdFound27 == 0 )
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
         RowToVars27( bcworkwithplus_WWP_Parameter, 0) ;
         ScanKeyStart0H27( ) ;
         if ( RcdFound27 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z106WWPParameterKey = A106WWPParameterKey;
         }
         ZM0H27( -3) ;
         OnLoadActions0H27( ) ;
         AddRow0H27( ) ;
         ScanKeyEnd0H27( ) ;
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0H27( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0H27( ) ;
         }
         else
         {
            if ( RcdFound27 == 1 )
            {
               if ( StringUtil.StrCmp(A106WWPParameterKey, Z106WWPParameterKey) != 0 )
               {
                  A106WWPParameterKey = Z106WWPParameterKey;
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
                  Update0H27( ) ;
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
                  if ( StringUtil.StrCmp(A106WWPParameterKey, Z106WWPParameterKey) != 0 )
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
                        Insert0H27( ) ;
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
                        Insert0H27( ) ;
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
         RowToVars27( bcworkwithplus_WWP_Parameter, 1) ;
         SaveImpl( ) ;
         VarsToRow27( bcworkwithplus_WWP_Parameter) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars27( bcworkwithplus_WWP_Parameter, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0H27( ) ;
         AfterTrn( ) ;
         VarsToRow27( bcworkwithplus_WWP_Parameter) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow27( bcworkwithplus_WWP_Parameter) ;
         }
         else
         {
            GeneXus.Programs.workwithplus.SdtWWP_Parameter auxBC = new GeneXus.Programs.workwithplus.SdtWWP_Parameter(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A106WWPParameterKey);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcworkwithplus_WWP_Parameter);
               auxBC.Save();
               bcworkwithplus_WWP_Parameter.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars27( bcworkwithplus_WWP_Parameter, 1) ;
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
         RowToVars27( bcworkwithplus_WWP_Parameter, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0H27( ) ;
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
               VarsToRow27( bcworkwithplus_WWP_Parameter) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow27( bcworkwithplus_WWP_Parameter) ;
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
         RowToVars27( bcworkwithplus_WWP_Parameter, 0) ;
         GetKey0H27( ) ;
         if ( RcdFound27 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A106WWPParameterKey, Z106WWPParameterKey) != 0 )
            {
               A106WWPParameterKey = Z106WWPParameterKey;
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
            if ( StringUtil.StrCmp(A106WWPParameterKey, Z106WWPParameterKey) != 0 )
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
         context.RollbackDataStores("workwithplus.wwp_parameter_bc",pr_default);
         VarsToRow27( bcworkwithplus_WWP_Parameter) ;
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
         Gx_mode = bcworkwithplus_WWP_Parameter.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcworkwithplus_WWP_Parameter.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcworkwithplus_WWP_Parameter )
         {
            bcworkwithplus_WWP_Parameter = (GeneXus.Programs.workwithplus.SdtWWP_Parameter)(sdt);
            if ( StringUtil.StrCmp(bcworkwithplus_WWP_Parameter.gxTpr_Mode, "") == 0 )
            {
               bcworkwithplus_WWP_Parameter.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow27( bcworkwithplus_WWP_Parameter) ;
            }
            else
            {
               RowToVars27( bcworkwithplus_WWP_Parameter, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcworkwithplus_WWP_Parameter.gxTpr_Mode, "") == 0 )
            {
               bcworkwithplus_WWP_Parameter.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars27( bcworkwithplus_WWP_Parameter, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_Parameter WWP_Parameter_BC
      {
         get {
            return bcworkwithplus_WWP_Parameter ;
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
            return "wwp_parameter_Execute" ;
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z106WWPParameterKey = "";
         A106WWPParameterKey = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z108WWPParameterCategory = "";
         A108WWPParameterCategory = "";
         Z109WWPParameterDescription = "";
         A109WWPParameterDescription = "";
         Z111WWPParameterValueTrimmed = "";
         A111WWPParameterValueTrimmed = "";
         Z107WWPParameterValue = "";
         A107WWPParameterValue = "";
         BC000H4_A106WWPParameterKey = new string[] {""} ;
         BC000H4_A108WWPParameterCategory = new string[] {""} ;
         BC000H4_A109WWPParameterDescription = new string[] {""} ;
         BC000H4_A107WWPParameterValue = new string[] {""} ;
         BC000H4_A110WWPParameterDisableDelete = new bool[] {false} ;
         BC000H5_A106WWPParameterKey = new string[] {""} ;
         BC000H3_A106WWPParameterKey = new string[] {""} ;
         BC000H3_A108WWPParameterCategory = new string[] {""} ;
         BC000H3_A109WWPParameterDescription = new string[] {""} ;
         BC000H3_A107WWPParameterValue = new string[] {""} ;
         BC000H3_A110WWPParameterDisableDelete = new bool[] {false} ;
         sMode27 = "";
         BC000H2_A106WWPParameterKey = new string[] {""} ;
         BC000H2_A108WWPParameterCategory = new string[] {""} ;
         BC000H2_A109WWPParameterDescription = new string[] {""} ;
         BC000H2_A107WWPParameterValue = new string[] {""} ;
         BC000H2_A110WWPParameterDisableDelete = new bool[] {false} ;
         BC000H9_A106WWPParameterKey = new string[] {""} ;
         BC000H9_A108WWPParameterCategory = new string[] {""} ;
         BC000H9_A109WWPParameterDescription = new string[] {""} ;
         BC000H9_A107WWPParameterValue = new string[] {""} ;
         BC000H9_A110WWPParameterDisableDelete = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_parameter_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_parameter_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_parameter_bc__default(),
            new Object[][] {
                new Object[] {
               BC000H2_A106WWPParameterKey, BC000H2_A108WWPParameterCategory, BC000H2_A109WWPParameterDescription, BC000H2_A107WWPParameterValue, BC000H2_A110WWPParameterDisableDelete
               }
               , new Object[] {
               BC000H3_A106WWPParameterKey, BC000H3_A108WWPParameterCategory, BC000H3_A109WWPParameterDescription, BC000H3_A107WWPParameterValue, BC000H3_A110WWPParameterDisableDelete
               }
               , new Object[] {
               BC000H4_A106WWPParameterKey, BC000H4_A108WWPParameterCategory, BC000H4_A109WWPParameterDescription, BC000H4_A107WWPParameterValue, BC000H4_A110WWPParameterDisableDelete
               }
               , new Object[] {
               BC000H5_A106WWPParameterKey
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000H9_A106WWPParameterKey, BC000H9_A108WWPParameterCategory, BC000H9_A109WWPParameterDescription, BC000H9_A107WWPParameterValue, BC000H9_A110WWPParameterDisableDelete
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120H2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound27 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode27 ;
      private bool returnInSub ;
      private bool Z110WWPParameterDisableDelete ;
      private bool A110WWPParameterDisableDelete ;
      private string Z107WWPParameterValue ;
      private string A107WWPParameterValue ;
      private string Z106WWPParameterKey ;
      private string A106WWPParameterKey ;
      private string Z108WWPParameterCategory ;
      private string A108WWPParameterCategory ;
      private string Z109WWPParameterDescription ;
      private string A109WWPParameterDescription ;
      private string Z111WWPParameterValueTrimmed ;
      private string A111WWPParameterValueTrimmed ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private string[] BC000H4_A106WWPParameterKey ;
      private string[] BC000H4_A108WWPParameterCategory ;
      private string[] BC000H4_A109WWPParameterDescription ;
      private string[] BC000H4_A107WWPParameterValue ;
      private bool[] BC000H4_A110WWPParameterDisableDelete ;
      private string[] BC000H5_A106WWPParameterKey ;
      private string[] BC000H3_A106WWPParameterKey ;
      private string[] BC000H3_A108WWPParameterCategory ;
      private string[] BC000H3_A109WWPParameterDescription ;
      private string[] BC000H3_A107WWPParameterValue ;
      private bool[] BC000H3_A110WWPParameterDisableDelete ;
      private string[] BC000H2_A106WWPParameterKey ;
      private string[] BC000H2_A108WWPParameterCategory ;
      private string[] BC000H2_A109WWPParameterDescription ;
      private string[] BC000H2_A107WWPParameterValue ;
      private bool[] BC000H2_A110WWPParameterDisableDelete ;
      private string[] BC000H9_A106WWPParameterKey ;
      private string[] BC000H9_A108WWPParameterCategory ;
      private string[] BC000H9_A109WWPParameterDescription ;
      private string[] BC000H9_A107WWPParameterValue ;
      private bool[] BC000H9_A110WWPParameterDisableDelete ;
      private GeneXus.Programs.workwithplus.SdtWWP_Parameter bcworkwithplus_WWP_Parameter ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_parameter_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_parameter_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_parameter_bc__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new ForEachCursor(def[3])
      ,new UpdateCursor(def[4])
      ,new UpdateCursor(def[5])
      ,new UpdateCursor(def[6])
      ,new ForEachCursor(def[7])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000H2;
       prmBC000H2 = new Object[] {
       new ParDef("WWPParameterKey",GXType.VarChar,300,0)
       };
       Object[] prmBC000H3;
       prmBC000H3 = new Object[] {
       new ParDef("WWPParameterKey",GXType.VarChar,300,0)
       };
       Object[] prmBC000H4;
       prmBC000H4 = new Object[] {
       new ParDef("WWPParameterKey",GXType.VarChar,300,0)
       };
       Object[] prmBC000H5;
       prmBC000H5 = new Object[] {
       new ParDef("WWPParameterKey",GXType.VarChar,300,0)
       };
       Object[] prmBC000H6;
       prmBC000H6 = new Object[] {
       new ParDef("WWPParameterKey",GXType.VarChar,300,0) ,
       new ParDef("WWPParameterCategory",GXType.VarChar,200,0) ,
       new ParDef("WWPParameterDescription",GXType.VarChar,200,0) ,
       new ParDef("WWPParameterValue",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPParameterDisableDelete",GXType.Boolean,4,0)
       };
       Object[] prmBC000H7;
       prmBC000H7 = new Object[] {
       new ParDef("WWPParameterCategory",GXType.VarChar,200,0) ,
       new ParDef("WWPParameterDescription",GXType.VarChar,200,0) ,
       new ParDef("WWPParameterValue",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPParameterDisableDelete",GXType.Boolean,4,0) ,
       new ParDef("WWPParameterKey",GXType.VarChar,300,0)
       };
       Object[] prmBC000H8;
       prmBC000H8 = new Object[] {
       new ParDef("WWPParameterKey",GXType.VarChar,300,0)
       };
       Object[] prmBC000H9;
       prmBC000H9 = new Object[] {
       new ParDef("WWPParameterKey",GXType.VarChar,300,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC000H2", "SELECT WWPParameterKey, WWPParameterCategory, WWPParameterDescription, WWPParameterValue, WWPParameterDisableDelete FROM WWP_Parameter WHERE WWPParameterKey = :WWPParameterKey  FOR UPDATE OF WWP_Parameter",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000H3", "SELECT WWPParameterKey, WWPParameterCategory, WWPParameterDescription, WWPParameterValue, WWPParameterDisableDelete FROM WWP_Parameter WHERE WWPParameterKey = :WWPParameterKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000H4", "SELECT TM1.WWPParameterKey, TM1.WWPParameterCategory, TM1.WWPParameterDescription, TM1.WWPParameterValue, TM1.WWPParameterDisableDelete FROM WWP_Parameter TM1 WHERE TM1.WWPParameterKey = ( :WWPParameterKey) ORDER BY TM1.WWPParameterKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000H5", "SELECT WWPParameterKey FROM WWP_Parameter WHERE WWPParameterKey = :WWPParameterKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000H6", "SAVEPOINT gxupdate;INSERT INTO WWP_Parameter(WWPParameterKey, WWPParameterCategory, WWPParameterDescription, WWPParameterValue, WWPParameterDisableDelete) VALUES(:WWPParameterKey, :WWPParameterCategory, :WWPParameterDescription, :WWPParameterValue, :WWPParameterDisableDelete);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000H6)
          ,new CursorDef("BC000H7", "SAVEPOINT gxupdate;UPDATE WWP_Parameter SET WWPParameterCategory=:WWPParameterCategory, WWPParameterDescription=:WWPParameterDescription, WWPParameterValue=:WWPParameterValue, WWPParameterDisableDelete=:WWPParameterDisableDelete  WHERE WWPParameterKey = :WWPParameterKey;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000H7)
          ,new CursorDef("BC000H8", "SAVEPOINT gxupdate;DELETE FROM WWP_Parameter  WHERE WWPParameterKey = :WWPParameterKey;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000H8)
          ,new CursorDef("BC000H9", "SELECT TM1.WWPParameterKey, TM1.WWPParameterCategory, TM1.WWPParameterDescription, TM1.WWPParameterValue, TM1.WWPParameterDisableDelete FROM WWP_Parameter TM1 WHERE TM1.WWPParameterKey = ( :WWPParameterKey) ORDER BY TM1.WWPParameterKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H9,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[4])[0] = rslt.getBool(5);
             return;
          case 1 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[4])[0] = rslt.getBool(5);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[4])[0] = rslt.getBool(5);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 7 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[4])[0] = rslt.getBool(5);
             return;
    }
 }

}

}
