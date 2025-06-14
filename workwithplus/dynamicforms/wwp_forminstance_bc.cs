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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_forminstance_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_forminstance_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_forminstance_bc( IGxContext context )
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
         ReadRow0U42( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0U42( ) ;
         standaloneModal( ) ;
         AddRow0U42( ) ;
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
            E110U2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z214WWPFormInstanceId = A214WWPFormInstanceId;
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

      protected void CONFIRM_0U0( )
      {
         BeforeValidate0U42( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0U42( ) ;
            }
            else
            {
               CheckExtendedTable0U42( ) ;
               if ( AnyError == 0 )
               {
                  ZM0U42( 5) ;
                  ZM0U42( 6) ;
               }
               CloseExtendedTableCursors0U42( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode42 = Gx_mode;
            CONFIRM_0U43( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode42;
            }
            /* Restore parent mode. */
            Gx_mode = sMode42;
         }
      }

      protected void CONFIRM_0U43( )
      {
         nGXsfl_43_idx = 0;
         while ( nGXsfl_43_idx < bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Element.Count )
         {
            ReadRow0U43( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound43 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_43 != 0 ) )
            {
               GetKey0U43( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound43 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0U43( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0U43( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0U43( 8) ;
                           ZM0U43( 9) ;
                        }
                        CloseExtendedTableCursors0U43( ) ;
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
                  if ( RcdFound43 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0U43( ) ;
                        Load0U43( ) ;
                        BeforeValidate0U43( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0U43( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_43 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0U43( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0U43( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0U43( 8) ;
                                 ZM0U43( 9) ;
                              }
                              CloseExtendedTableCursors0U43( ) ;
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
               VarsToRow43( ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Element.Item(nGXsfl_43_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E120U2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV21Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV22GXV1 = 1;
            while ( AV22GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV22GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "WWPFormId") == 0 )
               {
                  AV11Insert_WWPFormId = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "WWPFormVersionNumber") == 0 )
               {
                  AV12Insert_WWPFormVersionNumber = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "WWPUserExtendedId") == 0 )
               {
                  AV16Insert_WWPUserExtendedId = AV13TrnContextAtt.gxTpr_Attributevalue;
               }
               AV22GXV1 = (int)(AV22GXV1+1);
            }
         }
      }

      protected void E110U2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0U42( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z239WWPFormInstanceDate = A239WWPFormInstanceDate;
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            Z112WWPUserExtendedId = A112WWPUserExtendedId;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z208WWPFormReferenceName = A208WWPFormReferenceName;
            Z209WWPFormTitle = A209WWPFormTitle;
            Z216WWPFormResume = A216WWPFormResume;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z113WWPUserExtendedFullName = A113WWPUserExtendedFullName;
         }
         if ( GX_JID == -4 )
         {
            Z214WWPFormInstanceId = A214WWPFormInstanceId;
            Z239WWPFormInstanceDate = A239WWPFormInstanceDate;
            Z243WWPFormInstanceRecordKey = A243WWPFormInstanceRecordKey;
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            Z112WWPUserExtendedId = A112WWPUserExtendedId;
            Z208WWPFormReferenceName = A208WWPFormReferenceName;
            Z209WWPFormTitle = A209WWPFormTitle;
            Z216WWPFormResume = A216WWPFormResume;
            Z233WWPFormValidations = A233WWPFormValidations;
            Z113WWPUserExtendedFullName = A113WWPUserExtendedFullName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV21Pgmname = "WorkWithPlus.DynamicForms.WWP_FormInstance_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A239WWPFormInstanceDate) && ( Gx_BScreen == 0 ) )
         {
            A239WWPFormInstanceDate = DateTimeUtil.Now( context);
         }
      }

      protected void Load0U42( )
      {
         /* Using cursor BC000U10 */
         pr_default.execute(8, new Object[] {A214WWPFormInstanceId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound42 = 1;
            A239WWPFormInstanceDate = BC000U10_A239WWPFormInstanceDate[0];
            A208WWPFormReferenceName = BC000U10_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC000U10_A209WWPFormTitle[0];
            A113WWPUserExtendedFullName = BC000U10_A113WWPUserExtendedFullName[0];
            A216WWPFormResume = BC000U10_A216WWPFormResume[0];
            A233WWPFormValidations = BC000U10_A233WWPFormValidations[0];
            A243WWPFormInstanceRecordKey = BC000U10_A243WWPFormInstanceRecordKey[0];
            n243WWPFormInstanceRecordKey = BC000U10_n243WWPFormInstanceRecordKey[0];
            A206WWPFormId = BC000U10_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC000U10_A207WWPFormVersionNumber[0];
            A112WWPUserExtendedId = BC000U10_A112WWPUserExtendedId[0];
            ZM0U42( -4) ;
         }
         pr_default.close(8);
         OnLoadActions0U42( ) ;
      }

      protected void OnLoadActions0U42( )
      {
      }

      protected void CheckExtendedTable0U42( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000U8 */
         pr_default.execute(6, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Dynamic Form", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMVERSIONNUMBER");
            AnyError = 1;
         }
         A208WWPFormReferenceName = BC000U8_A208WWPFormReferenceName[0];
         A209WWPFormTitle = BC000U8_A209WWPFormTitle[0];
         A216WWPFormResume = BC000U8_A216WWPFormResume[0];
         A233WWPFormValidations = BC000U8_A233WWPFormValidations[0];
         pr_default.close(6);
         /* Using cursor BC000U9 */
         pr_default.execute(7, new Object[] {A112WWPUserExtendedId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
         }
         A113WWPUserExtendedFullName = BC000U9_A113WWPUserExtendedFullName[0];
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors0U42( )
      {
         pr_default.close(6);
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0U42( )
      {
         /* Using cursor BC000U11 */
         pr_default.execute(9, new Object[] {A214WWPFormInstanceId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound42 = 1;
         }
         else
         {
            RcdFound42 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000U7 */
         pr_default.execute(5, new Object[] {A214WWPFormInstanceId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0U42( 4) ;
            RcdFound42 = 1;
            A214WWPFormInstanceId = BC000U7_A214WWPFormInstanceId[0];
            A239WWPFormInstanceDate = BC000U7_A239WWPFormInstanceDate[0];
            A243WWPFormInstanceRecordKey = BC000U7_A243WWPFormInstanceRecordKey[0];
            n243WWPFormInstanceRecordKey = BC000U7_n243WWPFormInstanceRecordKey[0];
            A206WWPFormId = BC000U7_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC000U7_A207WWPFormVersionNumber[0];
            A112WWPUserExtendedId = BC000U7_A112WWPUserExtendedId[0];
            Z214WWPFormInstanceId = A214WWPFormInstanceId;
            sMode42 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0U42( ) ;
            if ( AnyError == 1 )
            {
               RcdFound42 = 0;
               InitializeNonKey0U42( ) ;
            }
            Gx_mode = sMode42;
         }
         else
         {
            RcdFound42 = 0;
            InitializeNonKey0U42( ) ;
            sMode42 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode42;
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey0U42( ) ;
         if ( RcdFound42 == 0 )
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
         CONFIRM_0U0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0U42( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000U6 */
            pr_default.execute(4, new Object[] {A214WWPFormInstanceId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormInstance"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( Z239WWPFormInstanceDate != BC000U6_A239WWPFormInstanceDate[0] ) || ( Z206WWPFormId != BC000U6_A206WWPFormId[0] ) || ( Z207WWPFormVersionNumber != BC000U6_A207WWPFormVersionNumber[0] ) || ( StringUtil.StrCmp(Z112WWPUserExtendedId, BC000U6_A112WWPUserExtendedId[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_FormInstance"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0U42( )
      {
         BeforeValidate0U42( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U42( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0U42( 0) ;
            CheckOptimisticConcurrency0U42( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U42( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0U42( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000U12 */
                     pr_default.execute(10, new Object[] {A239WWPFormInstanceDate, n243WWPFormInstanceRecordKey, A243WWPFormInstanceRecordKey, A206WWPFormId, A207WWPFormVersionNumber, A112WWPUserExtendedId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000U13 */
                     pr_default.execute(11);
                     A214WWPFormInstanceId = BC000U13_A214WWPFormInstanceId[0];
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstance");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0U42( ) ;
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
               Load0U42( ) ;
            }
            EndLevel0U42( ) ;
         }
         CloseExtendedTableCursors0U42( ) ;
      }

      protected void Update0U42( )
      {
         BeforeValidate0U42( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U42( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U42( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U42( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0U42( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000U14 */
                     pr_default.execute(12, new Object[] {A239WWPFormInstanceDate, n243WWPFormInstanceRecordKey, A243WWPFormInstanceRecordKey, A206WWPFormId, A207WWPFormVersionNumber, A112WWPUserExtendedId, A214WWPFormInstanceId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstance");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormInstance"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0U42( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0U42( ) ;
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
            EndLevel0U42( ) ;
         }
         CloseExtendedTableCursors0U42( ) ;
      }

      protected void DeferredUpdate0U42( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0U42( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U42( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0U42( ) ;
            AfterConfirm0U42( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0U42( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0U43( ) ;
                  while ( RcdFound43 != 0 )
                  {
                     getByPrimaryKey0U43( ) ;
                     Delete0U43( ) ;
                     ScanKeyNext0U43( ) ;
                  }
                  ScanKeyEnd0U43( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000U15 */
                     pr_default.execute(13, new Object[] {A214WWPFormInstanceId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstance");
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
         sMode42 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0U42( ) ;
         Gx_mode = sMode42;
      }

      protected void OnDeleteControls0U42( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000U16 */
            pr_default.execute(14, new Object[] {A206WWPFormId, A207WWPFormVersionNumber});
            A208WWPFormReferenceName = BC000U16_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC000U16_A209WWPFormTitle[0];
            A216WWPFormResume = BC000U16_A216WWPFormResume[0];
            A233WWPFormValidations = BC000U16_A233WWPFormValidations[0];
            pr_default.close(14);
            /* Using cursor BC000U17 */
            pr_default.execute(15, new Object[] {A112WWPUserExtendedId});
            A113WWPUserExtendedFullName = BC000U17_A113WWPUserExtendedFullName[0];
            pr_default.close(15);
         }
      }

      protected void ProcessNestedLevel0U43( )
      {
         nGXsfl_43_idx = 0;
         while ( nGXsfl_43_idx < bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Element.Count )
         {
            ReadRow0U43( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound43 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_43 != 0 ) )
            {
               standaloneNotModal0U43( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0U43( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0U43( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0U43( ) ;
                  }
               }
            }
            KeyVarsToRow43( ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Element.Item(nGXsfl_43_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_43_idx = 0;
            while ( nGXsfl_43_idx < bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Element.Count )
            {
               ReadRow0U43( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound43 == 0 )
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
                  bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Element.RemoveElement(nGXsfl_43_idx);
                  nGXsfl_43_idx = (int)(nGXsfl_43_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0U43( ) ;
                  VarsToRow43( ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Element.Item(nGXsfl_43_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0U43( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_43 = 0;
         nIsMod_43 = 0;
      }

      protected void ProcessLevel0U42( )
      {
         /* Save parent mode. */
         sMode42 = Gx_mode;
         ProcessNestedLevel0U43( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode42;
         /* ' Update level parameters */
      }

      protected void EndLevel0U42( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0U42( ) ;
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

      public void ScanKeyStart0U42( )
      {
         /* Scan By routine */
         /* Using cursor BC000U18 */
         pr_default.execute(16, new Object[] {A214WWPFormInstanceId});
         RcdFound42 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound42 = 1;
            A214WWPFormInstanceId = BC000U18_A214WWPFormInstanceId[0];
            A239WWPFormInstanceDate = BC000U18_A239WWPFormInstanceDate[0];
            A208WWPFormReferenceName = BC000U18_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC000U18_A209WWPFormTitle[0];
            A113WWPUserExtendedFullName = BC000U18_A113WWPUserExtendedFullName[0];
            A216WWPFormResume = BC000U18_A216WWPFormResume[0];
            A233WWPFormValidations = BC000U18_A233WWPFormValidations[0];
            A243WWPFormInstanceRecordKey = BC000U18_A243WWPFormInstanceRecordKey[0];
            n243WWPFormInstanceRecordKey = BC000U18_n243WWPFormInstanceRecordKey[0];
            A206WWPFormId = BC000U18_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC000U18_A207WWPFormVersionNumber[0];
            A112WWPUserExtendedId = BC000U18_A112WWPUserExtendedId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0U42( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound42 = 0;
         ScanKeyLoad0U42( ) ;
      }

      protected void ScanKeyLoad0U42( )
      {
         sMode42 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound42 = 1;
            A214WWPFormInstanceId = BC000U18_A214WWPFormInstanceId[0];
            A239WWPFormInstanceDate = BC000U18_A239WWPFormInstanceDate[0];
            A208WWPFormReferenceName = BC000U18_A208WWPFormReferenceName[0];
            A209WWPFormTitle = BC000U18_A209WWPFormTitle[0];
            A113WWPUserExtendedFullName = BC000U18_A113WWPUserExtendedFullName[0];
            A216WWPFormResume = BC000U18_A216WWPFormResume[0];
            A233WWPFormValidations = BC000U18_A233WWPFormValidations[0];
            A243WWPFormInstanceRecordKey = BC000U18_A243WWPFormInstanceRecordKey[0];
            n243WWPFormInstanceRecordKey = BC000U18_n243WWPFormInstanceRecordKey[0];
            A206WWPFormId = BC000U18_A206WWPFormId[0];
            A207WWPFormVersionNumber = BC000U18_A207WWPFormVersionNumber[0];
            A112WWPUserExtendedId = BC000U18_A112WWPUserExtendedId[0];
         }
         Gx_mode = sMode42;
      }

      protected void ScanKeyEnd0U42( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm0U42( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0U42( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0U42( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0U42( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0U42( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0U42( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0U42( )
      {
      }

      protected void ZM0U43( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z220WWPFormInstanceElemDate = A220WWPFormInstanceElemDate;
            Z227WWPFormInstanceElemDateTime = A227WWPFormInstanceElemDateTime;
            Z222WWPFormInstanceElemNumeric = A222WWPFormInstanceElemNumeric;
            Z226WWPFormInstanceElemBoolean = A226WWPFormInstanceElemBoolean;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z213WWPFormElementReferenceId = A213WWPFormElementReferenceId;
            Z218WWPFormElementDataType = A218WWPFormElementDataType;
            Z217WWPFormElementType = A217WWPFormElementType;
            Z237WWPFormElementCaption = A237WWPFormElementCaption;
            Z211WWPFormElementParentId = A211WWPFormElementParentId;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z230WWPFormElementParentType = A230WWPFormElementParentType;
         }
         if ( GX_JID == -7 )
         {
            Z214WWPFormInstanceId = A214WWPFormInstanceId;
            Z215WWPFormInstanceElementId = A215WWPFormInstanceElementId;
            Z221WWPFormInstanceElemChar = A221WWPFormInstanceElemChar;
            Z220WWPFormInstanceElemDate = A220WWPFormInstanceElemDate;
            Z227WWPFormInstanceElemDateTime = A227WWPFormInstanceElemDateTime;
            Z222WWPFormInstanceElemNumeric = A222WWPFormInstanceElemNumeric;
            Z223WWPFormInstanceElemBlob = A223WWPFormInstanceElemBlob;
            Z226WWPFormInstanceElemBoolean = A226WWPFormInstanceElemBoolean;
            Z224WWPFormInstanceElemBlobFileTyp = A224WWPFormInstanceElemBlobFileTyp;
            Z225WWPFormInstanceElemBlobFileNam = A225WWPFormInstanceElemBlobFileNam;
            Z210WWPFormElementId = A210WWPFormElementId;
            Z206WWPFormId = A206WWPFormId;
            Z207WWPFormVersionNumber = A207WWPFormVersionNumber;
            Z229WWPFormElementTitle = A229WWPFormElementTitle;
            Z213WWPFormElementReferenceId = A213WWPFormElementReferenceId;
            Z218WWPFormElementDataType = A218WWPFormElementDataType;
            Z217WWPFormElementType = A217WWPFormElementType;
            Z236WWPFormElementMetadata = A236WWPFormElementMetadata;
            Z237WWPFormElementCaption = A237WWPFormElementCaption;
            Z211WWPFormElementParentId = A211WWPFormElementParentId;
            Z230WWPFormElementParentType = A230WWPFormElementParentType;
         }
      }

      protected void standaloneNotModal0U43( )
      {
      }

      protected void standaloneModal0U43( )
      {
      }

      protected void Load0U43( )
      {
         /* Using cursor BC000U19 */
         pr_default.execute(17, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A214WWPFormInstanceId, A215WWPFormInstanceElementId, A210WWPFormElementId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound43 = 1;
            A229WWPFormElementTitle = BC000U19_A229WWPFormElementTitle[0];
            A213WWPFormElementReferenceId = BC000U19_A213WWPFormElementReferenceId[0];
            A218WWPFormElementDataType = BC000U19_A218WWPFormElementDataType[0];
            A230WWPFormElementParentType = BC000U19_A230WWPFormElementParentType[0];
            A217WWPFormElementType = BC000U19_A217WWPFormElementType[0];
            A236WWPFormElementMetadata = BC000U19_A236WWPFormElementMetadata[0];
            A237WWPFormElementCaption = BC000U19_A237WWPFormElementCaption[0];
            A221WWPFormInstanceElemChar = BC000U19_A221WWPFormInstanceElemChar[0];
            n221WWPFormInstanceElemChar = BC000U19_n221WWPFormInstanceElemChar[0];
            A220WWPFormInstanceElemDate = BC000U19_A220WWPFormInstanceElemDate[0];
            n220WWPFormInstanceElemDate = BC000U19_n220WWPFormInstanceElemDate[0];
            A227WWPFormInstanceElemDateTime = BC000U19_A227WWPFormInstanceElemDateTime[0];
            n227WWPFormInstanceElemDateTime = BC000U19_n227WWPFormInstanceElemDateTime[0];
            A222WWPFormInstanceElemNumeric = BC000U19_A222WWPFormInstanceElemNumeric[0];
            n222WWPFormInstanceElemNumeric = BC000U19_n222WWPFormInstanceElemNumeric[0];
            A226WWPFormInstanceElemBoolean = BC000U19_A226WWPFormInstanceElemBoolean[0];
            n226WWPFormInstanceElemBoolean = BC000U19_n226WWPFormInstanceElemBoolean[0];
            A224WWPFormInstanceElemBlobFileTyp = BC000U19_A224WWPFormInstanceElemBlobFileTyp[0];
            A223WWPFormInstanceElemBlob_Filetype = A224WWPFormInstanceElemBlobFileTyp;
            A225WWPFormInstanceElemBlobFileNam = BC000U19_A225WWPFormInstanceElemBlobFileNam[0];
            A223WWPFormInstanceElemBlob_Filename = A225WWPFormInstanceElemBlobFileNam;
            A211WWPFormElementParentId = BC000U19_A211WWPFormElementParentId[0];
            n211WWPFormElementParentId = BC000U19_n211WWPFormElementParentId[0];
            A223WWPFormInstanceElemBlob = BC000U19_A223WWPFormInstanceElemBlob[0];
            n223WWPFormInstanceElemBlob = BC000U19_n223WWPFormInstanceElemBlob[0];
            ZM0U43( -7) ;
         }
         pr_default.close(17);
         OnLoadActions0U43( ) ;
      }

      protected void OnLoadActions0U43( )
      {
      }

      protected void CheckExtendedTable0U43( )
      {
         Gx_BScreen = 1;
         standaloneModal0U43( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000U4 */
         pr_default.execute(2, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Element", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMELEMENTID");
            AnyError = 1;
         }
         A229WWPFormElementTitle = BC000U4_A229WWPFormElementTitle[0];
         A213WWPFormElementReferenceId = BC000U4_A213WWPFormElementReferenceId[0];
         A218WWPFormElementDataType = BC000U4_A218WWPFormElementDataType[0];
         A217WWPFormElementType = BC000U4_A217WWPFormElementType[0];
         A236WWPFormElementMetadata = BC000U4_A236WWPFormElementMetadata[0];
         A237WWPFormElementCaption = BC000U4_A237WWPFormElementCaption[0];
         A211WWPFormElementParentId = BC000U4_A211WWPFormElementParentId[0];
         n211WWPFormElementParentId = BC000U4_n211WWPFormElementParentId[0];
         pr_default.close(2);
         /* Using cursor BC000U5 */
         pr_default.execute(3, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, n211WWPFormElementParentId, A211WWPFormElementParentId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A206WWPFormId) || (0==A207WWPFormVersionNumber) || (0==A211WWPFormElementParentId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWPForm Element Parent", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPFORMELEMENTPARENTID");
               AnyError = 1;
            }
         }
         A230WWPFormElementParentType = BC000U5_A230WWPFormElementParentType[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0U43( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable0U43( )
      {
      }

      protected void GetKey0U43( )
      {
         /* Using cursor BC000U20 */
         pr_default.execute(18, new Object[] {A214WWPFormInstanceId, A210WWPFormElementId, A215WWPFormInstanceElementId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound43 = 1;
         }
         else
         {
            RcdFound43 = 0;
         }
         pr_default.close(18);
      }

      protected void getByPrimaryKey0U43( )
      {
         /* Using cursor BC000U3 */
         pr_default.execute(1, new Object[] {A214WWPFormInstanceId, A210WWPFormElementId, A215WWPFormInstanceElementId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0U43( 7) ;
            RcdFound43 = 1;
            InitializeNonKey0U43( ) ;
            A215WWPFormInstanceElementId = BC000U3_A215WWPFormInstanceElementId[0];
            A221WWPFormInstanceElemChar = BC000U3_A221WWPFormInstanceElemChar[0];
            n221WWPFormInstanceElemChar = BC000U3_n221WWPFormInstanceElemChar[0];
            A220WWPFormInstanceElemDate = BC000U3_A220WWPFormInstanceElemDate[0];
            n220WWPFormInstanceElemDate = BC000U3_n220WWPFormInstanceElemDate[0];
            A227WWPFormInstanceElemDateTime = BC000U3_A227WWPFormInstanceElemDateTime[0];
            n227WWPFormInstanceElemDateTime = BC000U3_n227WWPFormInstanceElemDateTime[0];
            A222WWPFormInstanceElemNumeric = BC000U3_A222WWPFormInstanceElemNumeric[0];
            n222WWPFormInstanceElemNumeric = BC000U3_n222WWPFormInstanceElemNumeric[0];
            A226WWPFormInstanceElemBoolean = BC000U3_A226WWPFormInstanceElemBoolean[0];
            n226WWPFormInstanceElemBoolean = BC000U3_n226WWPFormInstanceElemBoolean[0];
            A224WWPFormInstanceElemBlobFileTyp = BC000U3_A224WWPFormInstanceElemBlobFileTyp[0];
            A223WWPFormInstanceElemBlob_Filetype = A224WWPFormInstanceElemBlobFileTyp;
            A225WWPFormInstanceElemBlobFileNam = BC000U3_A225WWPFormInstanceElemBlobFileNam[0];
            A223WWPFormInstanceElemBlob_Filename = A225WWPFormInstanceElemBlobFileNam;
            A210WWPFormElementId = BC000U3_A210WWPFormElementId[0];
            A223WWPFormInstanceElemBlob = BC000U3_A223WWPFormInstanceElemBlob[0];
            n223WWPFormInstanceElemBlob = BC000U3_n223WWPFormInstanceElemBlob[0];
            Z214WWPFormInstanceId = A214WWPFormInstanceId;
            Z210WWPFormElementId = A210WWPFormElementId;
            Z215WWPFormInstanceElementId = A215WWPFormInstanceElementId;
            sMode43 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0U43( ) ;
            Load0U43( ) ;
            Gx_mode = sMode43;
         }
         else
         {
            RcdFound43 = 0;
            InitializeNonKey0U43( ) ;
            sMode43 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0U43( ) ;
            Gx_mode = sMode43;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0U43( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0U43( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000U2 */
            pr_default.execute(0, new Object[] {A214WWPFormInstanceId, A210WWPFormElementId, A215WWPFormInstanceElementId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormInstanceElement"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z220WWPFormInstanceElemDate ) != DateTimeUtil.ResetTime ( BC000U2_A220WWPFormInstanceElemDate[0] ) ) || ( Z227WWPFormInstanceElemDateTime != BC000U2_A227WWPFormInstanceElemDateTime[0] ) || ( Z222WWPFormInstanceElemNumeric != BC000U2_A222WWPFormInstanceElemNumeric[0] ) || ( Z226WWPFormInstanceElemBoolean != BC000U2_A226WWPFormInstanceElemBoolean[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_FormInstanceElement"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0U43( )
      {
         BeforeValidate0U43( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U43( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0U43( 0) ;
            CheckOptimisticConcurrency0U43( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U43( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0U43( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000U21 */
                     pr_default.execute(19, new Object[] {A214WWPFormInstanceId, A215WWPFormInstanceElementId, n221WWPFormInstanceElemChar, A221WWPFormInstanceElemChar, n220WWPFormInstanceElemDate, A220WWPFormInstanceElemDate, n227WWPFormInstanceElemDateTime, A227WWPFormInstanceElemDateTime, n222WWPFormInstanceElemNumeric, A222WWPFormInstanceElemNumeric, n223WWPFormInstanceElemBlob, A223WWPFormInstanceElemBlob, n226WWPFormInstanceElemBoolean, A226WWPFormInstanceElemBoolean, A224WWPFormInstanceElemBlobFileTyp, A225WWPFormInstanceElemBlobFileNam, A210WWPFormElementId});
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstanceElement");
                     if ( (pr_default.getStatus(19) == 1) )
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
               Load0U43( ) ;
            }
            EndLevel0U43( ) ;
         }
         CloseExtendedTableCursors0U43( ) ;
      }

      protected void Update0U43( )
      {
         BeforeValidate0U43( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U43( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U43( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U43( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0U43( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000U22 */
                     pr_default.execute(20, new Object[] {n221WWPFormInstanceElemChar, A221WWPFormInstanceElemChar, n220WWPFormInstanceElemDate, A220WWPFormInstanceElemDate, n227WWPFormInstanceElemDateTime, A227WWPFormInstanceElemDateTime, n222WWPFormInstanceElemNumeric, A222WWPFormInstanceElemNumeric, n226WWPFormInstanceElemBoolean, A226WWPFormInstanceElemBoolean, A224WWPFormInstanceElemBlobFileTyp, A225WWPFormInstanceElemBlobFileNam, A214WWPFormInstanceId, A210WWPFormElementId, A215WWPFormInstanceElementId});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstanceElement");
                     if ( (pr_default.getStatus(20) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_FormInstanceElement"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0U43( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0U43( ) ;
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
            EndLevel0U43( ) ;
         }
         CloseExtendedTableCursors0U43( ) ;
      }

      protected void DeferredUpdate0U43( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000U23 */
            pr_default.execute(21, new Object[] {n223WWPFormInstanceElemBlob, A223WWPFormInstanceElemBlob, A214WWPFormInstanceId, A210WWPFormElementId, A215WWPFormInstanceElementId});
            pr_default.close(21);
            pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstanceElement");
         }
      }

      protected void Delete0U43( )
      {
         Gx_mode = "DLT";
         BeforeValidate0U43( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U43( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0U43( ) ;
            AfterConfirm0U43( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0U43( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000U24 */
                  pr_default.execute(22, new Object[] {A214WWPFormInstanceId, A210WWPFormElementId, A215WWPFormInstanceElementId});
                  pr_default.close(22);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_FormInstanceElement");
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
         sMode43 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0U43( ) ;
         Gx_mode = sMode43;
      }

      protected void OnDeleteControls0U43( )
      {
         standaloneModal0U43( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000U25 */
            pr_default.execute(23, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A210WWPFormElementId});
            A229WWPFormElementTitle = BC000U25_A229WWPFormElementTitle[0];
            A213WWPFormElementReferenceId = BC000U25_A213WWPFormElementReferenceId[0];
            A218WWPFormElementDataType = BC000U25_A218WWPFormElementDataType[0];
            A217WWPFormElementType = BC000U25_A217WWPFormElementType[0];
            A236WWPFormElementMetadata = BC000U25_A236WWPFormElementMetadata[0];
            A237WWPFormElementCaption = BC000U25_A237WWPFormElementCaption[0];
            A211WWPFormElementParentId = BC000U25_A211WWPFormElementParentId[0];
            n211WWPFormElementParentId = BC000U25_n211WWPFormElementParentId[0];
            pr_default.close(23);
            /* Using cursor BC000U26 */
            pr_default.execute(24, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, n211WWPFormElementParentId, A211WWPFormElementParentId});
            A230WWPFormElementParentType = BC000U26_A230WWPFormElementParentType[0];
            pr_default.close(24);
         }
      }

      protected void EndLevel0U43( )
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

      public void ScanKeyStart0U43( )
      {
         /* Scan By routine */
         /* Using cursor BC000U27 */
         pr_default.execute(25, new Object[] {A206WWPFormId, A207WWPFormVersionNumber, A214WWPFormInstanceId});
         RcdFound43 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound43 = 1;
            A215WWPFormInstanceElementId = BC000U27_A215WWPFormInstanceElementId[0];
            A229WWPFormElementTitle = BC000U27_A229WWPFormElementTitle[0];
            A213WWPFormElementReferenceId = BC000U27_A213WWPFormElementReferenceId[0];
            A218WWPFormElementDataType = BC000U27_A218WWPFormElementDataType[0];
            A230WWPFormElementParentType = BC000U27_A230WWPFormElementParentType[0];
            A217WWPFormElementType = BC000U27_A217WWPFormElementType[0];
            A236WWPFormElementMetadata = BC000U27_A236WWPFormElementMetadata[0];
            A237WWPFormElementCaption = BC000U27_A237WWPFormElementCaption[0];
            A221WWPFormInstanceElemChar = BC000U27_A221WWPFormInstanceElemChar[0];
            n221WWPFormInstanceElemChar = BC000U27_n221WWPFormInstanceElemChar[0];
            A220WWPFormInstanceElemDate = BC000U27_A220WWPFormInstanceElemDate[0];
            n220WWPFormInstanceElemDate = BC000U27_n220WWPFormInstanceElemDate[0];
            A227WWPFormInstanceElemDateTime = BC000U27_A227WWPFormInstanceElemDateTime[0];
            n227WWPFormInstanceElemDateTime = BC000U27_n227WWPFormInstanceElemDateTime[0];
            A222WWPFormInstanceElemNumeric = BC000U27_A222WWPFormInstanceElemNumeric[0];
            n222WWPFormInstanceElemNumeric = BC000U27_n222WWPFormInstanceElemNumeric[0];
            A226WWPFormInstanceElemBoolean = BC000U27_A226WWPFormInstanceElemBoolean[0];
            n226WWPFormInstanceElemBoolean = BC000U27_n226WWPFormInstanceElemBoolean[0];
            A224WWPFormInstanceElemBlobFileTyp = BC000U27_A224WWPFormInstanceElemBlobFileTyp[0];
            A223WWPFormInstanceElemBlob_Filetype = A224WWPFormInstanceElemBlobFileTyp;
            A225WWPFormInstanceElemBlobFileNam = BC000U27_A225WWPFormInstanceElemBlobFileNam[0];
            A223WWPFormInstanceElemBlob_Filename = A225WWPFormInstanceElemBlobFileNam;
            A210WWPFormElementId = BC000U27_A210WWPFormElementId[0];
            A211WWPFormElementParentId = BC000U27_A211WWPFormElementParentId[0];
            n211WWPFormElementParentId = BC000U27_n211WWPFormElementParentId[0];
            A223WWPFormInstanceElemBlob = BC000U27_A223WWPFormInstanceElemBlob[0];
            n223WWPFormInstanceElemBlob = BC000U27_n223WWPFormInstanceElemBlob[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0U43( )
      {
         /* Scan next routine */
         pr_default.readNext(25);
         RcdFound43 = 0;
         ScanKeyLoad0U43( ) ;
      }

      protected void ScanKeyLoad0U43( )
      {
         sMode43 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound43 = 1;
            A215WWPFormInstanceElementId = BC000U27_A215WWPFormInstanceElementId[0];
            A229WWPFormElementTitle = BC000U27_A229WWPFormElementTitle[0];
            A213WWPFormElementReferenceId = BC000U27_A213WWPFormElementReferenceId[0];
            A218WWPFormElementDataType = BC000U27_A218WWPFormElementDataType[0];
            A230WWPFormElementParentType = BC000U27_A230WWPFormElementParentType[0];
            A217WWPFormElementType = BC000U27_A217WWPFormElementType[0];
            A236WWPFormElementMetadata = BC000U27_A236WWPFormElementMetadata[0];
            A237WWPFormElementCaption = BC000U27_A237WWPFormElementCaption[0];
            A221WWPFormInstanceElemChar = BC000U27_A221WWPFormInstanceElemChar[0];
            n221WWPFormInstanceElemChar = BC000U27_n221WWPFormInstanceElemChar[0];
            A220WWPFormInstanceElemDate = BC000U27_A220WWPFormInstanceElemDate[0];
            n220WWPFormInstanceElemDate = BC000U27_n220WWPFormInstanceElemDate[0];
            A227WWPFormInstanceElemDateTime = BC000U27_A227WWPFormInstanceElemDateTime[0];
            n227WWPFormInstanceElemDateTime = BC000U27_n227WWPFormInstanceElemDateTime[0];
            A222WWPFormInstanceElemNumeric = BC000U27_A222WWPFormInstanceElemNumeric[0];
            n222WWPFormInstanceElemNumeric = BC000U27_n222WWPFormInstanceElemNumeric[0];
            A226WWPFormInstanceElemBoolean = BC000U27_A226WWPFormInstanceElemBoolean[0];
            n226WWPFormInstanceElemBoolean = BC000U27_n226WWPFormInstanceElemBoolean[0];
            A224WWPFormInstanceElemBlobFileTyp = BC000U27_A224WWPFormInstanceElemBlobFileTyp[0];
            A223WWPFormInstanceElemBlob_Filetype = A224WWPFormInstanceElemBlobFileTyp;
            A225WWPFormInstanceElemBlobFileNam = BC000U27_A225WWPFormInstanceElemBlobFileNam[0];
            A223WWPFormInstanceElemBlob_Filename = A225WWPFormInstanceElemBlobFileNam;
            A210WWPFormElementId = BC000U27_A210WWPFormElementId[0];
            A211WWPFormElementParentId = BC000U27_A211WWPFormElementParentId[0];
            n211WWPFormElementParentId = BC000U27_n211WWPFormElementParentId[0];
            A223WWPFormInstanceElemBlob = BC000U27_A223WWPFormInstanceElemBlob[0];
            n223WWPFormInstanceElemBlob = BC000U27_n223WWPFormInstanceElemBlob[0];
         }
         Gx_mode = sMode43;
      }

      protected void ScanKeyEnd0U43( )
      {
         pr_default.close(25);
      }

      protected void AfterConfirm0U43( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0U43( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0U43( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0U43( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0U43( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0U43( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0U43( )
      {
      }

      protected void send_integrity_lvl_hashes0U43( )
      {
      }

      protected void send_integrity_lvl_hashes0U42( )
      {
      }

      protected void AddRow0U42( )
      {
         VarsToRow42( bcworkwithplus_dynamicforms_WWP_FormInstance) ;
      }

      protected void ReadRow0U42( )
      {
         RowToVars42( bcworkwithplus_dynamicforms_WWP_FormInstance, 1) ;
      }

      protected void AddRow0U43( )
      {
         GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element obj43;
         obj43 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         VarsToRow43( obj43) ;
         bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Element.Add(obj43, 0);
         obj43.gxTpr_Mode = "UPD";
         obj43.gxTpr_Modified = 0;
      }

      protected void ReadRow0U43( )
      {
         nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
         RowToVars43( ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Element.Item(nGXsfl_43_idx)), 1) ;
      }

      protected void InitializeNonKey0U42( )
      {
         A206WWPFormId = 0;
         A208WWPFormReferenceName = "";
         A207WWPFormVersionNumber = 0;
         A209WWPFormTitle = "";
         A112WWPUserExtendedId = "";
         A113WWPUserExtendedFullName = "";
         A216WWPFormResume = 0;
         A233WWPFormValidations = "";
         A243WWPFormInstanceRecordKey = "";
         n243WWPFormInstanceRecordKey = false;
         A239WWPFormInstanceDate = DateTimeUtil.Now( context);
         Z239WWPFormInstanceDate = (DateTime)(DateTime.MinValue);
         Z206WWPFormId = 0;
         Z207WWPFormVersionNumber = 0;
         Z112WWPUserExtendedId = "";
      }

      protected void InitAll0U42( )
      {
         A214WWPFormInstanceId = 0;
         InitializeNonKey0U42( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A239WWPFormInstanceDate = i239WWPFormInstanceDate;
      }

      protected void InitializeNonKey0U43( )
      {
         A229WWPFormElementTitle = "";
         A213WWPFormElementReferenceId = "";
         A218WWPFormElementDataType = 0;
         A211WWPFormElementParentId = 0;
         n211WWPFormElementParentId = false;
         A230WWPFormElementParentType = 0;
         A217WWPFormElementType = 0;
         A236WWPFormElementMetadata = "";
         A237WWPFormElementCaption = 0;
         A221WWPFormInstanceElemChar = "";
         n221WWPFormInstanceElemChar = false;
         A220WWPFormInstanceElemDate = DateTime.MinValue;
         n220WWPFormInstanceElemDate = false;
         A227WWPFormInstanceElemDateTime = (DateTime)(DateTime.MinValue);
         n227WWPFormInstanceElemDateTime = false;
         A222WWPFormInstanceElemNumeric = 0;
         n222WWPFormInstanceElemNumeric = false;
         A223WWPFormInstanceElemBlob = "";
         n223WWPFormInstanceElemBlob = false;
         A226WWPFormInstanceElemBoolean = false;
         n226WWPFormInstanceElemBoolean = false;
         A224WWPFormInstanceElemBlobFileTyp = "";
         A225WWPFormInstanceElemBlobFileNam = "";
         Z220WWPFormInstanceElemDate = DateTime.MinValue;
         Z227WWPFormInstanceElemDateTime = (DateTime)(DateTime.MinValue);
         Z222WWPFormInstanceElemNumeric = 0;
         Z226WWPFormInstanceElemBoolean = false;
      }

      protected void InitAll0U43( )
      {
         A210WWPFormElementId = 0;
         A215WWPFormInstanceElementId = 0;
         InitializeNonKey0U43( ) ;
      }

      protected void StandaloneModalInsert0U43( )
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

      public void VarsToRow42( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance obj42 )
      {
         obj42.gxTpr_Mode = Gx_mode;
         obj42.gxTpr_Wwpformid = A206WWPFormId;
         obj42.gxTpr_Wwpformreferencename = A208WWPFormReferenceName;
         obj42.gxTpr_Wwpformversionnumber = A207WWPFormVersionNumber;
         obj42.gxTpr_Wwpformtitle = A209WWPFormTitle;
         obj42.gxTpr_Wwpuserextendedid = A112WWPUserExtendedId;
         obj42.gxTpr_Wwpuserextendedfullname = A113WWPUserExtendedFullName;
         obj42.gxTpr_Wwpformresume = A216WWPFormResume;
         obj42.gxTpr_Wwpformvalidations = A233WWPFormValidations;
         obj42.gxTpr_Wwpforminstancerecordkey = A243WWPFormInstanceRecordKey;
         obj42.gxTpr_Wwpforminstancedate = A239WWPFormInstanceDate;
         obj42.gxTpr_Wwpforminstanceid = A214WWPFormInstanceId;
         obj42.gxTpr_Wwpforminstanceid_Z = Z214WWPFormInstanceId;
         obj42.gxTpr_Wwpforminstancedate_Z = Z239WWPFormInstanceDate;
         obj42.gxTpr_Wwpformid_Z = Z206WWPFormId;
         obj42.gxTpr_Wwpformreferencename_Z = Z208WWPFormReferenceName;
         obj42.gxTpr_Wwpformversionnumber_Z = Z207WWPFormVersionNumber;
         obj42.gxTpr_Wwpformtitle_Z = Z209WWPFormTitle;
         obj42.gxTpr_Wwpuserextendedid_Z = Z112WWPUserExtendedId;
         obj42.gxTpr_Wwpuserextendedfullname_Z = Z113WWPUserExtendedFullName;
         obj42.gxTpr_Wwpformresume_Z = Z216WWPFormResume;
         obj42.gxTpr_Wwpforminstancerecordkey_N = (short)(Convert.ToInt16(n243WWPFormInstanceRecordKey));
         obj42.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow42( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance obj42 )
      {
         obj42.gxTpr_Wwpforminstanceid = A214WWPFormInstanceId;
         return  ;
      }

      public void RowToVars42( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance obj42 ,
                               int forceLoad )
      {
         Gx_mode = obj42.gxTpr_Mode;
         A206WWPFormId = obj42.gxTpr_Wwpformid;
         A208WWPFormReferenceName = obj42.gxTpr_Wwpformreferencename;
         A207WWPFormVersionNumber = obj42.gxTpr_Wwpformversionnumber;
         A209WWPFormTitle = obj42.gxTpr_Wwpformtitle;
         A112WWPUserExtendedId = obj42.gxTpr_Wwpuserextendedid;
         A113WWPUserExtendedFullName = obj42.gxTpr_Wwpuserextendedfullname;
         A216WWPFormResume = obj42.gxTpr_Wwpformresume;
         A233WWPFormValidations = obj42.gxTpr_Wwpformvalidations;
         A243WWPFormInstanceRecordKey = obj42.gxTpr_Wwpforminstancerecordkey;
         n243WWPFormInstanceRecordKey = false;
         A239WWPFormInstanceDate = obj42.gxTpr_Wwpforminstancedate;
         A214WWPFormInstanceId = obj42.gxTpr_Wwpforminstanceid;
         Z214WWPFormInstanceId = obj42.gxTpr_Wwpforminstanceid_Z;
         Z239WWPFormInstanceDate = obj42.gxTpr_Wwpforminstancedate_Z;
         Z206WWPFormId = obj42.gxTpr_Wwpformid_Z;
         Z208WWPFormReferenceName = obj42.gxTpr_Wwpformreferencename_Z;
         Z207WWPFormVersionNumber = obj42.gxTpr_Wwpformversionnumber_Z;
         Z209WWPFormTitle = obj42.gxTpr_Wwpformtitle_Z;
         Z112WWPUserExtendedId = obj42.gxTpr_Wwpuserextendedid_Z;
         Z113WWPUserExtendedFullName = obj42.gxTpr_Wwpuserextendedfullname_Z;
         Z216WWPFormResume = obj42.gxTpr_Wwpformresume_Z;
         n243WWPFormInstanceRecordKey = (bool)(Convert.ToBoolean(obj42.gxTpr_Wwpforminstancerecordkey_N));
         Gx_mode = obj42.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow43( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element obj43 )
      {
         obj43.gxTpr_Mode = Gx_mode;
         obj43.gxTpr_Wwpformelementtitle = A229WWPFormElementTitle;
         obj43.gxTpr_Wwpformelementreferenceid = A213WWPFormElementReferenceId;
         obj43.gxTpr_Wwpformelementdatatype = A218WWPFormElementDataType;
         obj43.gxTpr_Wwpformelementparentid = A211WWPFormElementParentId;
         obj43.gxTpr_Wwpformelementparenttype = A230WWPFormElementParentType;
         obj43.gxTpr_Wwpformelementtype = A217WWPFormElementType;
         obj43.gxTpr_Wwpformelementmetadata = A236WWPFormElementMetadata;
         obj43.gxTpr_Wwpformelementcaption = A237WWPFormElementCaption;
         obj43.gxTpr_Wwpforminstanceelemchar = A221WWPFormInstanceElemChar;
         obj43.gxTpr_Wwpforminstanceelemdate = A220WWPFormInstanceElemDate;
         obj43.gxTpr_Wwpforminstanceelemdatetime = A227WWPFormInstanceElemDateTime;
         obj43.gxTpr_Wwpforminstanceelemnumeric = A222WWPFormInstanceElemNumeric;
         obj43.gxTpr_Wwpforminstanceelemblob = A223WWPFormInstanceElemBlob;
         obj43.gxTpr_Wwpforminstanceelemboolean = A226WWPFormInstanceElemBoolean;
         obj43.gxTpr_Wwpforminstanceelemblobfiletype = A224WWPFormInstanceElemBlobFileTyp;
         obj43.gxTpr_Wwpforminstanceelemblobfilename = A225WWPFormInstanceElemBlobFileNam;
         obj43.gxTpr_Wwpformelementid = A210WWPFormElementId;
         obj43.gxTpr_Wwpforminstanceelementid = A215WWPFormInstanceElementId;
         obj43.gxTpr_Wwpformelementid_Z = Z210WWPFormElementId;
         obj43.gxTpr_Wwpforminstanceelementid_Z = Z215WWPFormInstanceElementId;
         obj43.gxTpr_Wwpformelementreferenceid_Z = Z213WWPFormElementReferenceId;
         obj43.gxTpr_Wwpformelementdatatype_Z = Z218WWPFormElementDataType;
         obj43.gxTpr_Wwpformelementparentid_Z = Z211WWPFormElementParentId;
         obj43.gxTpr_Wwpformelementparenttype_Z = Z230WWPFormElementParentType;
         obj43.gxTpr_Wwpformelementtype_Z = Z217WWPFormElementType;
         obj43.gxTpr_Wwpformelementcaption_Z = Z237WWPFormElementCaption;
         obj43.gxTpr_Wwpforminstanceelemdate_Z = Z220WWPFormInstanceElemDate;
         obj43.gxTpr_Wwpforminstanceelemdatetime_Z = Z227WWPFormInstanceElemDateTime;
         obj43.gxTpr_Wwpforminstanceelemnumeric_Z = Z222WWPFormInstanceElemNumeric;
         obj43.gxTpr_Wwpforminstanceelemblobfilename_Z = Z225WWPFormInstanceElemBlobFileNam;
         obj43.gxTpr_Wwpforminstanceelemblobfiletype_Z = Z224WWPFormInstanceElemBlobFileTyp;
         obj43.gxTpr_Wwpforminstanceelemboolean_Z = Z226WWPFormInstanceElemBoolean;
         obj43.gxTpr_Wwpformelementparentid_N = (short)(Convert.ToInt16(n211WWPFormElementParentId));
         obj43.gxTpr_Wwpforminstanceelemchar_N = (short)(Convert.ToInt16(n221WWPFormInstanceElemChar));
         obj43.gxTpr_Wwpforminstanceelemdate_N = (short)(Convert.ToInt16(n220WWPFormInstanceElemDate));
         obj43.gxTpr_Wwpforminstanceelemdatetime_N = (short)(Convert.ToInt16(n227WWPFormInstanceElemDateTime));
         obj43.gxTpr_Wwpforminstanceelemnumeric_N = (short)(Convert.ToInt16(n222WWPFormInstanceElemNumeric));
         obj43.gxTpr_Wwpforminstanceelemblob_N = (short)(Convert.ToInt16(n223WWPFormInstanceElemBlob));
         obj43.gxTpr_Wwpforminstanceelemboolean_N = (short)(Convert.ToInt16(n226WWPFormInstanceElemBoolean));
         obj43.gxTpr_Modified = nIsMod_43;
         return  ;
      }

      public void KeyVarsToRow43( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element obj43 )
      {
         obj43.gxTpr_Wwpformelementid = A210WWPFormElementId;
         obj43.gxTpr_Wwpforminstanceelementid = A215WWPFormInstanceElementId;
         return  ;
      }

      public void RowToVars43( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element obj43 ,
                               int forceLoad )
      {
         Gx_mode = obj43.gxTpr_Mode;
         A229WWPFormElementTitle = obj43.gxTpr_Wwpformelementtitle;
         A213WWPFormElementReferenceId = obj43.gxTpr_Wwpformelementreferenceid;
         A218WWPFormElementDataType = obj43.gxTpr_Wwpformelementdatatype;
         A211WWPFormElementParentId = obj43.gxTpr_Wwpformelementparentid;
         n211WWPFormElementParentId = false;
         A230WWPFormElementParentType = obj43.gxTpr_Wwpformelementparenttype;
         A217WWPFormElementType = obj43.gxTpr_Wwpformelementtype;
         A236WWPFormElementMetadata = obj43.gxTpr_Wwpformelementmetadata;
         A237WWPFormElementCaption = obj43.gxTpr_Wwpformelementcaption;
         A221WWPFormInstanceElemChar = obj43.gxTpr_Wwpforminstanceelemchar;
         n221WWPFormInstanceElemChar = false;
         A220WWPFormInstanceElemDate = obj43.gxTpr_Wwpforminstanceelemdate;
         n220WWPFormInstanceElemDate = false;
         A227WWPFormInstanceElemDateTime = obj43.gxTpr_Wwpforminstanceelemdatetime;
         n227WWPFormInstanceElemDateTime = false;
         A222WWPFormInstanceElemNumeric = obj43.gxTpr_Wwpforminstanceelemnumeric;
         n222WWPFormInstanceElemNumeric = false;
         A223WWPFormInstanceElemBlob = obj43.gxTpr_Wwpforminstanceelemblob;
         n223WWPFormInstanceElemBlob = false;
         A226WWPFormInstanceElemBoolean = obj43.gxTpr_Wwpforminstanceelemboolean;
         n226WWPFormInstanceElemBoolean = false;
         A224WWPFormInstanceElemBlobFileTyp = (String.IsNullOrEmpty(StringUtil.RTrim( obj43.gxTpr_Wwpforminstanceelemblobfiletype)) ? FileUtil.GetFileType( A223WWPFormInstanceElemBlob) : obj43.gxTpr_Wwpforminstanceelemblobfiletype);
         A225WWPFormInstanceElemBlobFileNam = (String.IsNullOrEmpty(StringUtil.RTrim( obj43.gxTpr_Wwpforminstanceelemblobfilename)) ? FileUtil.GetFileName( A223WWPFormInstanceElemBlob) : obj43.gxTpr_Wwpforminstanceelemblobfilename);
         A210WWPFormElementId = obj43.gxTpr_Wwpformelementid;
         A215WWPFormInstanceElementId = obj43.gxTpr_Wwpforminstanceelementid;
         Z210WWPFormElementId = obj43.gxTpr_Wwpformelementid_Z;
         Z215WWPFormInstanceElementId = obj43.gxTpr_Wwpforminstanceelementid_Z;
         Z213WWPFormElementReferenceId = obj43.gxTpr_Wwpformelementreferenceid_Z;
         Z218WWPFormElementDataType = obj43.gxTpr_Wwpformelementdatatype_Z;
         Z211WWPFormElementParentId = obj43.gxTpr_Wwpformelementparentid_Z;
         Z230WWPFormElementParentType = obj43.gxTpr_Wwpformelementparenttype_Z;
         Z217WWPFormElementType = obj43.gxTpr_Wwpformelementtype_Z;
         Z237WWPFormElementCaption = obj43.gxTpr_Wwpformelementcaption_Z;
         Z220WWPFormInstanceElemDate = obj43.gxTpr_Wwpforminstanceelemdate_Z;
         Z227WWPFormInstanceElemDateTime = obj43.gxTpr_Wwpforminstanceelemdatetime_Z;
         Z222WWPFormInstanceElemNumeric = obj43.gxTpr_Wwpforminstanceelemnumeric_Z;
         Z225WWPFormInstanceElemBlobFileNam = obj43.gxTpr_Wwpforminstanceelemblobfilename_Z;
         Z224WWPFormInstanceElemBlobFileTyp = obj43.gxTpr_Wwpforminstanceelemblobfiletype_Z;
         Z226WWPFormInstanceElemBoolean = obj43.gxTpr_Wwpforminstanceelemboolean_Z;
         n211WWPFormElementParentId = (bool)(Convert.ToBoolean(obj43.gxTpr_Wwpformelementparentid_N));
         n221WWPFormInstanceElemChar = (bool)(Convert.ToBoolean(obj43.gxTpr_Wwpforminstanceelemchar_N));
         n220WWPFormInstanceElemDate = (bool)(Convert.ToBoolean(obj43.gxTpr_Wwpforminstanceelemdate_N));
         n227WWPFormInstanceElemDateTime = (bool)(Convert.ToBoolean(obj43.gxTpr_Wwpforminstanceelemdatetime_N));
         n222WWPFormInstanceElemNumeric = (bool)(Convert.ToBoolean(obj43.gxTpr_Wwpforminstanceelemnumeric_N));
         n223WWPFormInstanceElemBlob = (bool)(Convert.ToBoolean(obj43.gxTpr_Wwpforminstanceelemblob_N));
         n226WWPFormInstanceElemBoolean = (bool)(Convert.ToBoolean(obj43.gxTpr_Wwpforminstanceelemboolean_N));
         nIsMod_43 = obj43.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A214WWPFormInstanceId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0U42( ) ;
         ScanKeyStart0U42( ) ;
         if ( RcdFound42 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z214WWPFormInstanceId = A214WWPFormInstanceId;
         }
         ZM0U42( -4) ;
         OnLoadActions0U42( ) ;
         AddRow0U42( ) ;
         bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Element.ClearCollection();
         if ( RcdFound42 == 1 )
         {
            ScanKeyStart0U43( ) ;
            nGXsfl_43_idx = 1;
            while ( RcdFound43 != 0 )
            {
               Z214WWPFormInstanceId = A214WWPFormInstanceId;
               Z210WWPFormElementId = A210WWPFormElementId;
               Z215WWPFormInstanceElementId = A215WWPFormInstanceElementId;
               ZM0U43( -7) ;
               OnLoadActions0U43( ) ;
               nRcdExists_43 = 1;
               nIsMod_43 = 0;
               AddRow0U43( ) ;
               nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
               ScanKeyNext0U43( ) ;
            }
            ScanKeyEnd0U43( ) ;
         }
         ScanKeyEnd0U42( ) ;
         if ( RcdFound42 == 0 )
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
         RowToVars42( bcworkwithplus_dynamicforms_WWP_FormInstance, 0) ;
         ScanKeyStart0U42( ) ;
         if ( RcdFound42 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z214WWPFormInstanceId = A214WWPFormInstanceId;
         }
         ZM0U42( -4) ;
         OnLoadActions0U42( ) ;
         AddRow0U42( ) ;
         bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Element.ClearCollection();
         if ( RcdFound42 == 1 )
         {
            ScanKeyStart0U43( ) ;
            nGXsfl_43_idx = 1;
            while ( RcdFound43 != 0 )
            {
               Z214WWPFormInstanceId = A214WWPFormInstanceId;
               Z210WWPFormElementId = A210WWPFormElementId;
               Z215WWPFormInstanceElementId = A215WWPFormInstanceElementId;
               ZM0U43( -7) ;
               OnLoadActions0U43( ) ;
               nRcdExists_43 = 1;
               nIsMod_43 = 0;
               AddRow0U43( ) ;
               nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
               ScanKeyNext0U43( ) ;
            }
            ScanKeyEnd0U43( ) ;
         }
         ScanKeyEnd0U42( ) ;
         if ( RcdFound42 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0U42( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0U42( ) ;
         }
         else
         {
            if ( RcdFound42 == 1 )
            {
               if ( A214WWPFormInstanceId != Z214WWPFormInstanceId )
               {
                  A214WWPFormInstanceId = Z214WWPFormInstanceId;
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
                  Update0U42( ) ;
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
                  if ( A214WWPFormInstanceId != Z214WWPFormInstanceId )
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
                        Insert0U42( ) ;
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
                        Insert0U42( ) ;
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
         RowToVars42( bcworkwithplus_dynamicforms_WWP_FormInstance, 1) ;
         SaveImpl( ) ;
         VarsToRow42( bcworkwithplus_dynamicforms_WWP_FormInstance) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars42( bcworkwithplus_dynamicforms_WWP_FormInstance, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0U42( ) ;
         AfterTrn( ) ;
         VarsToRow42( bcworkwithplus_dynamicforms_WWP_FormInstance) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow42( bcworkwithplus_dynamicforms_WWP_FormInstance) ;
         }
         else
         {
            GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance auxBC = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A214WWPFormInstanceId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcworkwithplus_dynamicforms_WWP_FormInstance);
               auxBC.Save();
               bcworkwithplus_dynamicforms_WWP_FormInstance.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars42( bcworkwithplus_dynamicforms_WWP_FormInstance, 1) ;
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
         RowToVars42( bcworkwithplus_dynamicforms_WWP_FormInstance, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0U42( ) ;
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
               VarsToRow42( bcworkwithplus_dynamicforms_WWP_FormInstance) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow42( bcworkwithplus_dynamicforms_WWP_FormInstance) ;
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
         RowToVars42( bcworkwithplus_dynamicforms_WWP_FormInstance, 0) ;
         GetKey0U42( ) ;
         if ( RcdFound42 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A214WWPFormInstanceId != Z214WWPFormInstanceId )
            {
               A214WWPFormInstanceId = Z214WWPFormInstanceId;
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
            if ( A214WWPFormInstanceId != Z214WWPFormInstanceId )
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
         context.RollbackDataStores("workwithplus.dynamicforms.wwp_forminstance_bc",pr_default);
         VarsToRow42( bcworkwithplus_dynamicforms_WWP_FormInstance) ;
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
         Gx_mode = bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcworkwithplus_dynamicforms_WWP_FormInstance )
         {
            bcworkwithplus_dynamicforms_WWP_FormInstance = (GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance)(sdt);
            if ( StringUtil.StrCmp(bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Mode, "") == 0 )
            {
               bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow42( bcworkwithplus_dynamicforms_WWP_FormInstance) ;
            }
            else
            {
               RowToVars42( bcworkwithplus_dynamicforms_WWP_FormInstance, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Mode, "") == 0 )
            {
               bcworkwithplus_dynamicforms_WWP_FormInstance.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars42( bcworkwithplus_dynamicforms_WWP_FormInstance, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_FormInstance WWP_FormInstance_BC
      {
         get {
            return bcworkwithplus_dynamicforms_WWP_FormInstance ;
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
            return "wwp_forminstance_Execute" ;
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
         pr_default.close(23);
         pr_default.close(24);
         pr_default.close(5);
         pr_default.close(14);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode42 = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV21Pgmname = "";
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV16Insert_WWPUserExtendedId = "";
         Z239WWPFormInstanceDate = (DateTime)(DateTime.MinValue);
         A239WWPFormInstanceDate = (DateTime)(DateTime.MinValue);
         Z112WWPUserExtendedId = "";
         A112WWPUserExtendedId = "";
         Z208WWPFormReferenceName = "";
         A208WWPFormReferenceName = "";
         Z209WWPFormTitle = "";
         A209WWPFormTitle = "";
         Z113WWPUserExtendedFullName = "";
         A113WWPUserExtendedFullName = "";
         Z243WWPFormInstanceRecordKey = "";
         A243WWPFormInstanceRecordKey = "";
         Z233WWPFormValidations = "";
         A233WWPFormValidations = "";
         BC000U10_A214WWPFormInstanceId = new int[1] ;
         BC000U10_A239WWPFormInstanceDate = new DateTime[] {DateTime.MinValue} ;
         BC000U10_A208WWPFormReferenceName = new string[] {""} ;
         BC000U10_A209WWPFormTitle = new string[] {""} ;
         BC000U10_A113WWPUserExtendedFullName = new string[] {""} ;
         BC000U10_A216WWPFormResume = new short[1] ;
         BC000U10_A233WWPFormValidations = new string[] {""} ;
         BC000U10_A243WWPFormInstanceRecordKey = new string[] {""} ;
         BC000U10_n243WWPFormInstanceRecordKey = new bool[] {false} ;
         BC000U10_A206WWPFormId = new short[1] ;
         BC000U10_A207WWPFormVersionNumber = new short[1] ;
         BC000U10_A112WWPUserExtendedId = new string[] {""} ;
         BC000U8_A208WWPFormReferenceName = new string[] {""} ;
         BC000U8_A209WWPFormTitle = new string[] {""} ;
         BC000U8_A216WWPFormResume = new short[1] ;
         BC000U8_A233WWPFormValidations = new string[] {""} ;
         BC000U9_A113WWPUserExtendedFullName = new string[] {""} ;
         BC000U11_A214WWPFormInstanceId = new int[1] ;
         BC000U7_A214WWPFormInstanceId = new int[1] ;
         BC000U7_A239WWPFormInstanceDate = new DateTime[] {DateTime.MinValue} ;
         BC000U7_A243WWPFormInstanceRecordKey = new string[] {""} ;
         BC000U7_n243WWPFormInstanceRecordKey = new bool[] {false} ;
         BC000U7_A206WWPFormId = new short[1] ;
         BC000U7_A207WWPFormVersionNumber = new short[1] ;
         BC000U7_A112WWPUserExtendedId = new string[] {""} ;
         BC000U6_A214WWPFormInstanceId = new int[1] ;
         BC000U6_A239WWPFormInstanceDate = new DateTime[] {DateTime.MinValue} ;
         BC000U6_A243WWPFormInstanceRecordKey = new string[] {""} ;
         BC000U6_n243WWPFormInstanceRecordKey = new bool[] {false} ;
         BC000U6_A206WWPFormId = new short[1] ;
         BC000U6_A207WWPFormVersionNumber = new short[1] ;
         BC000U6_A112WWPUserExtendedId = new string[] {""} ;
         BC000U13_A214WWPFormInstanceId = new int[1] ;
         BC000U16_A208WWPFormReferenceName = new string[] {""} ;
         BC000U16_A209WWPFormTitle = new string[] {""} ;
         BC000U16_A216WWPFormResume = new short[1] ;
         BC000U16_A233WWPFormValidations = new string[] {""} ;
         BC000U17_A113WWPUserExtendedFullName = new string[] {""} ;
         BC000U18_A214WWPFormInstanceId = new int[1] ;
         BC000U18_A239WWPFormInstanceDate = new DateTime[] {DateTime.MinValue} ;
         BC000U18_A208WWPFormReferenceName = new string[] {""} ;
         BC000U18_A209WWPFormTitle = new string[] {""} ;
         BC000U18_A113WWPUserExtendedFullName = new string[] {""} ;
         BC000U18_A216WWPFormResume = new short[1] ;
         BC000U18_A233WWPFormValidations = new string[] {""} ;
         BC000U18_A243WWPFormInstanceRecordKey = new string[] {""} ;
         BC000U18_n243WWPFormInstanceRecordKey = new bool[] {false} ;
         BC000U18_A206WWPFormId = new short[1] ;
         BC000U18_A207WWPFormVersionNumber = new short[1] ;
         BC000U18_A112WWPUserExtendedId = new string[] {""} ;
         Z220WWPFormInstanceElemDate = DateTime.MinValue;
         A220WWPFormInstanceElemDate = DateTime.MinValue;
         Z227WWPFormInstanceElemDateTime = (DateTime)(DateTime.MinValue);
         A227WWPFormInstanceElemDateTime = (DateTime)(DateTime.MinValue);
         Z213WWPFormElementReferenceId = "";
         A213WWPFormElementReferenceId = "";
         Z221WWPFormInstanceElemChar = "";
         A221WWPFormInstanceElemChar = "";
         Z223WWPFormInstanceElemBlob = "";
         A223WWPFormInstanceElemBlob = "";
         Z224WWPFormInstanceElemBlobFileTyp = "";
         A224WWPFormInstanceElemBlobFileTyp = "";
         Z225WWPFormInstanceElemBlobFileNam = "";
         A225WWPFormInstanceElemBlobFileNam = "";
         Z229WWPFormElementTitle = "";
         A229WWPFormElementTitle = "";
         Z236WWPFormElementMetadata = "";
         A236WWPFormElementMetadata = "";
         BC000U19_A206WWPFormId = new short[1] ;
         BC000U19_A207WWPFormVersionNumber = new short[1] ;
         BC000U19_A214WWPFormInstanceId = new int[1] ;
         BC000U19_A215WWPFormInstanceElementId = new short[1] ;
         BC000U19_A229WWPFormElementTitle = new string[] {""} ;
         BC000U19_A213WWPFormElementReferenceId = new string[] {""} ;
         BC000U19_A218WWPFormElementDataType = new short[1] ;
         BC000U19_A230WWPFormElementParentType = new short[1] ;
         BC000U19_A217WWPFormElementType = new short[1] ;
         BC000U19_A236WWPFormElementMetadata = new string[] {""} ;
         BC000U19_A237WWPFormElementCaption = new short[1] ;
         BC000U19_A221WWPFormInstanceElemChar = new string[] {""} ;
         BC000U19_n221WWPFormInstanceElemChar = new bool[] {false} ;
         BC000U19_A220WWPFormInstanceElemDate = new DateTime[] {DateTime.MinValue} ;
         BC000U19_n220WWPFormInstanceElemDate = new bool[] {false} ;
         BC000U19_A227WWPFormInstanceElemDateTime = new DateTime[] {DateTime.MinValue} ;
         BC000U19_n227WWPFormInstanceElemDateTime = new bool[] {false} ;
         BC000U19_A222WWPFormInstanceElemNumeric = new decimal[1] ;
         BC000U19_n222WWPFormInstanceElemNumeric = new bool[] {false} ;
         BC000U19_A226WWPFormInstanceElemBoolean = new bool[] {false} ;
         BC000U19_n226WWPFormInstanceElemBoolean = new bool[] {false} ;
         BC000U19_A224WWPFormInstanceElemBlobFileTyp = new string[] {""} ;
         BC000U19_A225WWPFormInstanceElemBlobFileNam = new string[] {""} ;
         BC000U19_A210WWPFormElementId = new short[1] ;
         BC000U19_A211WWPFormElementParentId = new short[1] ;
         BC000U19_n211WWPFormElementParentId = new bool[] {false} ;
         BC000U19_A223WWPFormInstanceElemBlob = new string[] {""} ;
         BC000U19_n223WWPFormInstanceElemBlob = new bool[] {false} ;
         A223WWPFormInstanceElemBlob_Filetype = "";
         A223WWPFormInstanceElemBlob_Filename = "";
         BC000U4_A206WWPFormId = new short[1] ;
         BC000U4_A207WWPFormVersionNumber = new short[1] ;
         BC000U4_A229WWPFormElementTitle = new string[] {""} ;
         BC000U4_A213WWPFormElementReferenceId = new string[] {""} ;
         BC000U4_A218WWPFormElementDataType = new short[1] ;
         BC000U4_A217WWPFormElementType = new short[1] ;
         BC000U4_A236WWPFormElementMetadata = new string[] {""} ;
         BC000U4_A237WWPFormElementCaption = new short[1] ;
         BC000U4_A211WWPFormElementParentId = new short[1] ;
         BC000U4_n211WWPFormElementParentId = new bool[] {false} ;
         BC000U5_A230WWPFormElementParentType = new short[1] ;
         BC000U20_A214WWPFormInstanceId = new int[1] ;
         BC000U20_A210WWPFormElementId = new short[1] ;
         BC000U20_A215WWPFormInstanceElementId = new short[1] ;
         BC000U3_A214WWPFormInstanceId = new int[1] ;
         BC000U3_A215WWPFormInstanceElementId = new short[1] ;
         BC000U3_A221WWPFormInstanceElemChar = new string[] {""} ;
         BC000U3_n221WWPFormInstanceElemChar = new bool[] {false} ;
         BC000U3_A220WWPFormInstanceElemDate = new DateTime[] {DateTime.MinValue} ;
         BC000U3_n220WWPFormInstanceElemDate = new bool[] {false} ;
         BC000U3_A227WWPFormInstanceElemDateTime = new DateTime[] {DateTime.MinValue} ;
         BC000U3_n227WWPFormInstanceElemDateTime = new bool[] {false} ;
         BC000U3_A222WWPFormInstanceElemNumeric = new decimal[1] ;
         BC000U3_n222WWPFormInstanceElemNumeric = new bool[] {false} ;
         BC000U3_A226WWPFormInstanceElemBoolean = new bool[] {false} ;
         BC000U3_n226WWPFormInstanceElemBoolean = new bool[] {false} ;
         BC000U3_A224WWPFormInstanceElemBlobFileTyp = new string[] {""} ;
         BC000U3_A225WWPFormInstanceElemBlobFileNam = new string[] {""} ;
         BC000U3_A210WWPFormElementId = new short[1] ;
         BC000U3_A223WWPFormInstanceElemBlob = new string[] {""} ;
         BC000U3_n223WWPFormInstanceElemBlob = new bool[] {false} ;
         sMode43 = "";
         BC000U2_A214WWPFormInstanceId = new int[1] ;
         BC000U2_A215WWPFormInstanceElementId = new short[1] ;
         BC000U2_A221WWPFormInstanceElemChar = new string[] {""} ;
         BC000U2_n221WWPFormInstanceElemChar = new bool[] {false} ;
         BC000U2_A220WWPFormInstanceElemDate = new DateTime[] {DateTime.MinValue} ;
         BC000U2_n220WWPFormInstanceElemDate = new bool[] {false} ;
         BC000U2_A227WWPFormInstanceElemDateTime = new DateTime[] {DateTime.MinValue} ;
         BC000U2_n227WWPFormInstanceElemDateTime = new bool[] {false} ;
         BC000U2_A222WWPFormInstanceElemNumeric = new decimal[1] ;
         BC000U2_n222WWPFormInstanceElemNumeric = new bool[] {false} ;
         BC000U2_A226WWPFormInstanceElemBoolean = new bool[] {false} ;
         BC000U2_n226WWPFormInstanceElemBoolean = new bool[] {false} ;
         BC000U2_A224WWPFormInstanceElemBlobFileTyp = new string[] {""} ;
         BC000U2_A225WWPFormInstanceElemBlobFileNam = new string[] {""} ;
         BC000U2_A210WWPFormElementId = new short[1] ;
         BC000U2_A223WWPFormInstanceElemBlob = new string[] {""} ;
         BC000U2_n223WWPFormInstanceElemBlob = new bool[] {false} ;
         BC000U25_A229WWPFormElementTitle = new string[] {""} ;
         BC000U25_A213WWPFormElementReferenceId = new string[] {""} ;
         BC000U25_A218WWPFormElementDataType = new short[1] ;
         BC000U25_A217WWPFormElementType = new short[1] ;
         BC000U25_A236WWPFormElementMetadata = new string[] {""} ;
         BC000U25_A237WWPFormElementCaption = new short[1] ;
         BC000U25_A211WWPFormElementParentId = new short[1] ;
         BC000U25_n211WWPFormElementParentId = new bool[] {false} ;
         BC000U26_A230WWPFormElementParentType = new short[1] ;
         BC000U27_A206WWPFormId = new short[1] ;
         BC000U27_A207WWPFormVersionNumber = new short[1] ;
         BC000U27_A214WWPFormInstanceId = new int[1] ;
         BC000U27_A215WWPFormInstanceElementId = new short[1] ;
         BC000U27_A229WWPFormElementTitle = new string[] {""} ;
         BC000U27_A213WWPFormElementReferenceId = new string[] {""} ;
         BC000U27_A218WWPFormElementDataType = new short[1] ;
         BC000U27_A230WWPFormElementParentType = new short[1] ;
         BC000U27_A217WWPFormElementType = new short[1] ;
         BC000U27_A236WWPFormElementMetadata = new string[] {""} ;
         BC000U27_A237WWPFormElementCaption = new short[1] ;
         BC000U27_A221WWPFormInstanceElemChar = new string[] {""} ;
         BC000U27_n221WWPFormInstanceElemChar = new bool[] {false} ;
         BC000U27_A220WWPFormInstanceElemDate = new DateTime[] {DateTime.MinValue} ;
         BC000U27_n220WWPFormInstanceElemDate = new bool[] {false} ;
         BC000U27_A227WWPFormInstanceElemDateTime = new DateTime[] {DateTime.MinValue} ;
         BC000U27_n227WWPFormInstanceElemDateTime = new bool[] {false} ;
         BC000U27_A222WWPFormInstanceElemNumeric = new decimal[1] ;
         BC000U27_n222WWPFormInstanceElemNumeric = new bool[] {false} ;
         BC000U27_A226WWPFormInstanceElemBoolean = new bool[] {false} ;
         BC000U27_n226WWPFormInstanceElemBoolean = new bool[] {false} ;
         BC000U27_A224WWPFormInstanceElemBlobFileTyp = new string[] {""} ;
         BC000U27_A225WWPFormInstanceElemBlobFileNam = new string[] {""} ;
         BC000U27_A210WWPFormElementId = new short[1] ;
         BC000U27_A211WWPFormElementParentId = new short[1] ;
         BC000U27_n211WWPFormElementParentId = new bool[] {false} ;
         BC000U27_A223WWPFormInstanceElemBlob = new string[] {""} ;
         BC000U27_n223WWPFormInstanceElemBlob = new bool[] {false} ;
         i239WWPFormInstanceDate = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_forminstance_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_forminstance_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_forminstance_bc__default(),
            new Object[][] {
                new Object[] {
               BC000U2_A214WWPFormInstanceId, BC000U2_A215WWPFormInstanceElementId, BC000U2_A221WWPFormInstanceElemChar, BC000U2_n221WWPFormInstanceElemChar, BC000U2_A220WWPFormInstanceElemDate, BC000U2_n220WWPFormInstanceElemDate, BC000U2_A227WWPFormInstanceElemDateTime, BC000U2_n227WWPFormInstanceElemDateTime, BC000U2_A222WWPFormInstanceElemNumeric, BC000U2_n222WWPFormInstanceElemNumeric,
               BC000U2_A226WWPFormInstanceElemBoolean, BC000U2_n226WWPFormInstanceElemBoolean, BC000U2_A224WWPFormInstanceElemBlobFileTyp, BC000U2_A225WWPFormInstanceElemBlobFileNam, BC000U2_A210WWPFormElementId, BC000U2_A223WWPFormInstanceElemBlob, BC000U2_n223WWPFormInstanceElemBlob
               }
               , new Object[] {
               BC000U3_A214WWPFormInstanceId, BC000U3_A215WWPFormInstanceElementId, BC000U3_A221WWPFormInstanceElemChar, BC000U3_n221WWPFormInstanceElemChar, BC000U3_A220WWPFormInstanceElemDate, BC000U3_n220WWPFormInstanceElemDate, BC000U3_A227WWPFormInstanceElemDateTime, BC000U3_n227WWPFormInstanceElemDateTime, BC000U3_A222WWPFormInstanceElemNumeric, BC000U3_n222WWPFormInstanceElemNumeric,
               BC000U3_A226WWPFormInstanceElemBoolean, BC000U3_n226WWPFormInstanceElemBoolean, BC000U3_A224WWPFormInstanceElemBlobFileTyp, BC000U3_A225WWPFormInstanceElemBlobFileNam, BC000U3_A210WWPFormElementId, BC000U3_A223WWPFormInstanceElemBlob, BC000U3_n223WWPFormInstanceElemBlob
               }
               , new Object[] {
               BC000U4_A206WWPFormId, BC000U4_A207WWPFormVersionNumber, BC000U4_A229WWPFormElementTitle, BC000U4_A213WWPFormElementReferenceId, BC000U4_A218WWPFormElementDataType, BC000U4_A217WWPFormElementType, BC000U4_A236WWPFormElementMetadata, BC000U4_A237WWPFormElementCaption, BC000U4_A211WWPFormElementParentId, BC000U4_n211WWPFormElementParentId
               }
               , new Object[] {
               BC000U5_A230WWPFormElementParentType
               }
               , new Object[] {
               BC000U6_A214WWPFormInstanceId, BC000U6_A239WWPFormInstanceDate, BC000U6_A243WWPFormInstanceRecordKey, BC000U6_n243WWPFormInstanceRecordKey, BC000U6_A206WWPFormId, BC000U6_A207WWPFormVersionNumber, BC000U6_A112WWPUserExtendedId
               }
               , new Object[] {
               BC000U7_A214WWPFormInstanceId, BC000U7_A239WWPFormInstanceDate, BC000U7_A243WWPFormInstanceRecordKey, BC000U7_n243WWPFormInstanceRecordKey, BC000U7_A206WWPFormId, BC000U7_A207WWPFormVersionNumber, BC000U7_A112WWPUserExtendedId
               }
               , new Object[] {
               BC000U8_A208WWPFormReferenceName, BC000U8_A209WWPFormTitle, BC000U8_A216WWPFormResume, BC000U8_A233WWPFormValidations
               }
               , new Object[] {
               BC000U9_A113WWPUserExtendedFullName
               }
               , new Object[] {
               BC000U10_A214WWPFormInstanceId, BC000U10_A239WWPFormInstanceDate, BC000U10_A208WWPFormReferenceName, BC000U10_A209WWPFormTitle, BC000U10_A113WWPUserExtendedFullName, BC000U10_A216WWPFormResume, BC000U10_A233WWPFormValidations, BC000U10_A243WWPFormInstanceRecordKey, BC000U10_n243WWPFormInstanceRecordKey, BC000U10_A206WWPFormId,
               BC000U10_A207WWPFormVersionNumber, BC000U10_A112WWPUserExtendedId
               }
               , new Object[] {
               BC000U11_A214WWPFormInstanceId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000U13_A214WWPFormInstanceId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000U16_A208WWPFormReferenceName, BC000U16_A209WWPFormTitle, BC000U16_A216WWPFormResume, BC000U16_A233WWPFormValidations
               }
               , new Object[] {
               BC000U17_A113WWPUserExtendedFullName
               }
               , new Object[] {
               BC000U18_A214WWPFormInstanceId, BC000U18_A239WWPFormInstanceDate, BC000U18_A208WWPFormReferenceName, BC000U18_A209WWPFormTitle, BC000U18_A113WWPUserExtendedFullName, BC000U18_A216WWPFormResume, BC000U18_A233WWPFormValidations, BC000U18_A243WWPFormInstanceRecordKey, BC000U18_n243WWPFormInstanceRecordKey, BC000U18_A206WWPFormId,
               BC000U18_A207WWPFormVersionNumber, BC000U18_A112WWPUserExtendedId
               }
               , new Object[] {
               BC000U19_A206WWPFormId, BC000U19_A207WWPFormVersionNumber, BC000U19_A214WWPFormInstanceId, BC000U19_A215WWPFormInstanceElementId, BC000U19_A229WWPFormElementTitle, BC000U19_A213WWPFormElementReferenceId, BC000U19_A218WWPFormElementDataType, BC000U19_A230WWPFormElementParentType, BC000U19_A217WWPFormElementType, BC000U19_A236WWPFormElementMetadata,
               BC000U19_A237WWPFormElementCaption, BC000U19_A221WWPFormInstanceElemChar, BC000U19_n221WWPFormInstanceElemChar, BC000U19_A220WWPFormInstanceElemDate, BC000U19_n220WWPFormInstanceElemDate, BC000U19_A227WWPFormInstanceElemDateTime, BC000U19_n227WWPFormInstanceElemDateTime, BC000U19_A222WWPFormInstanceElemNumeric, BC000U19_n222WWPFormInstanceElemNumeric, BC000U19_A226WWPFormInstanceElemBoolean,
               BC000U19_n226WWPFormInstanceElemBoolean, BC000U19_A224WWPFormInstanceElemBlobFileTyp, BC000U19_A225WWPFormInstanceElemBlobFileNam, BC000U19_A210WWPFormElementId, BC000U19_A211WWPFormElementParentId, BC000U19_n211WWPFormElementParentId, BC000U19_A223WWPFormInstanceElemBlob, BC000U19_n223WWPFormInstanceElemBlob
               }
               , new Object[] {
               BC000U20_A214WWPFormInstanceId, BC000U20_A210WWPFormElementId, BC000U20_A215WWPFormInstanceElementId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000U25_A229WWPFormElementTitle, BC000U25_A213WWPFormElementReferenceId, BC000U25_A218WWPFormElementDataType, BC000U25_A217WWPFormElementType, BC000U25_A236WWPFormElementMetadata, BC000U25_A237WWPFormElementCaption, BC000U25_A211WWPFormElementParentId, BC000U25_n211WWPFormElementParentId
               }
               , new Object[] {
               BC000U26_A230WWPFormElementParentType
               }
               , new Object[] {
               BC000U27_A206WWPFormId, BC000U27_A207WWPFormVersionNumber, BC000U27_A214WWPFormInstanceId, BC000U27_A215WWPFormInstanceElementId, BC000U27_A229WWPFormElementTitle, BC000U27_A213WWPFormElementReferenceId, BC000U27_A218WWPFormElementDataType, BC000U27_A230WWPFormElementParentType, BC000U27_A217WWPFormElementType, BC000U27_A236WWPFormElementMetadata,
               BC000U27_A237WWPFormElementCaption, BC000U27_A221WWPFormInstanceElemChar, BC000U27_n221WWPFormInstanceElemChar, BC000U27_A220WWPFormInstanceElemDate, BC000U27_n220WWPFormInstanceElemDate, BC000U27_A227WWPFormInstanceElemDateTime, BC000U27_n227WWPFormInstanceElemDateTime, BC000U27_A222WWPFormInstanceElemNumeric, BC000U27_n222WWPFormInstanceElemNumeric, BC000U27_A226WWPFormInstanceElemBoolean,
               BC000U27_n226WWPFormInstanceElemBoolean, BC000U27_A224WWPFormInstanceElemBlobFileTyp, BC000U27_A225WWPFormInstanceElemBlobFileNam, BC000U27_A210WWPFormElementId, BC000U27_A211WWPFormElementParentId, BC000U27_n211WWPFormElementParentId, BC000U27_A223WWPFormInstanceElemBlob, BC000U27_n223WWPFormInstanceElemBlob
               }
            }
         );
         AV21Pgmname = "WorkWithPlus.DynamicForms.WWP_FormInstance_BC";
         Z239WWPFormInstanceDate = DateTimeUtil.Now( context);
         A239WWPFormInstanceDate = DateTimeUtil.Now( context);
         i239WWPFormInstanceDate = DateTimeUtil.Now( context);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120U2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_43 ;
      private short RcdFound43 ;
      private short AV11Insert_WWPFormId ;
      private short AV12Insert_WWPFormVersionNumber ;
      private short Z206WWPFormId ;
      private short A206WWPFormId ;
      private short Z207WWPFormVersionNumber ;
      private short A207WWPFormVersionNumber ;
      private short Z216WWPFormResume ;
      private short A216WWPFormResume ;
      private short Gx_BScreen ;
      private short RcdFound42 ;
      private short nRcdExists_43 ;
      private short Z218WWPFormElementDataType ;
      private short A218WWPFormElementDataType ;
      private short Z217WWPFormElementType ;
      private short A217WWPFormElementType ;
      private short Z237WWPFormElementCaption ;
      private short A237WWPFormElementCaption ;
      private short Z211WWPFormElementParentId ;
      private short A211WWPFormElementParentId ;
      private short Z230WWPFormElementParentType ;
      private short A230WWPFormElementParentType ;
      private short Z215WWPFormInstanceElementId ;
      private short A215WWPFormInstanceElementId ;
      private short Z210WWPFormElementId ;
      private short A210WWPFormElementId ;
      private short Gxremove43 ;
      private int trnEnded ;
      private int Z214WWPFormInstanceId ;
      private int A214WWPFormInstanceId ;
      private int nGXsfl_43_idx=1 ;
      private int AV22GXV1 ;
      private decimal Z222WWPFormInstanceElemNumeric ;
      private decimal A222WWPFormInstanceElemNumeric ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode42 ;
      private string AV21Pgmname ;
      private string AV16Insert_WWPUserExtendedId ;
      private string Z112WWPUserExtendedId ;
      private string A112WWPUserExtendedId ;
      private string A223WWPFormInstanceElemBlob_Filetype ;
      private string A223WWPFormInstanceElemBlob_Filename ;
      private string sMode43 ;
      private DateTime Z239WWPFormInstanceDate ;
      private DateTime A239WWPFormInstanceDate ;
      private DateTime Z227WWPFormInstanceElemDateTime ;
      private DateTime A227WWPFormInstanceElemDateTime ;
      private DateTime i239WWPFormInstanceDate ;
      private DateTime Z220WWPFormInstanceElemDate ;
      private DateTime A220WWPFormInstanceElemDate ;
      private bool returnInSub ;
      private bool n243WWPFormInstanceRecordKey ;
      private bool Z226WWPFormInstanceElemBoolean ;
      private bool A226WWPFormInstanceElemBoolean ;
      private bool n221WWPFormInstanceElemChar ;
      private bool n220WWPFormInstanceElemDate ;
      private bool n227WWPFormInstanceElemDateTime ;
      private bool n222WWPFormInstanceElemNumeric ;
      private bool n226WWPFormInstanceElemBoolean ;
      private bool n211WWPFormElementParentId ;
      private bool n223WWPFormInstanceElemBlob ;
      private string Z243WWPFormInstanceRecordKey ;
      private string A243WWPFormInstanceRecordKey ;
      private string Z233WWPFormValidations ;
      private string A233WWPFormValidations ;
      private string Z221WWPFormInstanceElemChar ;
      private string A221WWPFormInstanceElemChar ;
      private string Z229WWPFormElementTitle ;
      private string A229WWPFormElementTitle ;
      private string Z236WWPFormElementMetadata ;
      private string A236WWPFormElementMetadata ;
      private string Z208WWPFormReferenceName ;
      private string A208WWPFormReferenceName ;
      private string Z209WWPFormTitle ;
      private string A209WWPFormTitle ;
      private string Z113WWPUserExtendedFullName ;
      private string A113WWPUserExtendedFullName ;
      private string Z213WWPFormElementReferenceId ;
      private string A213WWPFormElementReferenceId ;
      private string Z224WWPFormInstanceElemBlobFileTyp ;
      private string A224WWPFormInstanceElemBlobFileTyp ;
      private string Z225WWPFormInstanceElemBlobFileNam ;
      private string A225WWPFormInstanceElemBlobFileNam ;
      private string Z223WWPFormInstanceElemBlob ;
      private string A223WWPFormInstanceElemBlob ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance bcworkwithplus_dynamicforms_WWP_FormInstance ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC000U10_A214WWPFormInstanceId ;
      private DateTime[] BC000U10_A239WWPFormInstanceDate ;
      private string[] BC000U10_A208WWPFormReferenceName ;
      private string[] BC000U10_A209WWPFormTitle ;
      private string[] BC000U10_A113WWPUserExtendedFullName ;
      private short[] BC000U10_A216WWPFormResume ;
      private string[] BC000U10_A233WWPFormValidations ;
      private string[] BC000U10_A243WWPFormInstanceRecordKey ;
      private bool[] BC000U10_n243WWPFormInstanceRecordKey ;
      private short[] BC000U10_A206WWPFormId ;
      private short[] BC000U10_A207WWPFormVersionNumber ;
      private string[] BC000U10_A112WWPUserExtendedId ;
      private string[] BC000U8_A208WWPFormReferenceName ;
      private string[] BC000U8_A209WWPFormTitle ;
      private short[] BC000U8_A216WWPFormResume ;
      private string[] BC000U8_A233WWPFormValidations ;
      private string[] BC000U9_A113WWPUserExtendedFullName ;
      private int[] BC000U11_A214WWPFormInstanceId ;
      private int[] BC000U7_A214WWPFormInstanceId ;
      private DateTime[] BC000U7_A239WWPFormInstanceDate ;
      private string[] BC000U7_A243WWPFormInstanceRecordKey ;
      private bool[] BC000U7_n243WWPFormInstanceRecordKey ;
      private short[] BC000U7_A206WWPFormId ;
      private short[] BC000U7_A207WWPFormVersionNumber ;
      private string[] BC000U7_A112WWPUserExtendedId ;
      private int[] BC000U6_A214WWPFormInstanceId ;
      private DateTime[] BC000U6_A239WWPFormInstanceDate ;
      private string[] BC000U6_A243WWPFormInstanceRecordKey ;
      private bool[] BC000U6_n243WWPFormInstanceRecordKey ;
      private short[] BC000U6_A206WWPFormId ;
      private short[] BC000U6_A207WWPFormVersionNumber ;
      private string[] BC000U6_A112WWPUserExtendedId ;
      private int[] BC000U13_A214WWPFormInstanceId ;
      private string[] BC000U16_A208WWPFormReferenceName ;
      private string[] BC000U16_A209WWPFormTitle ;
      private short[] BC000U16_A216WWPFormResume ;
      private string[] BC000U16_A233WWPFormValidations ;
      private string[] BC000U17_A113WWPUserExtendedFullName ;
      private int[] BC000U18_A214WWPFormInstanceId ;
      private DateTime[] BC000U18_A239WWPFormInstanceDate ;
      private string[] BC000U18_A208WWPFormReferenceName ;
      private string[] BC000U18_A209WWPFormTitle ;
      private string[] BC000U18_A113WWPUserExtendedFullName ;
      private short[] BC000U18_A216WWPFormResume ;
      private string[] BC000U18_A233WWPFormValidations ;
      private string[] BC000U18_A243WWPFormInstanceRecordKey ;
      private bool[] BC000U18_n243WWPFormInstanceRecordKey ;
      private short[] BC000U18_A206WWPFormId ;
      private short[] BC000U18_A207WWPFormVersionNumber ;
      private string[] BC000U18_A112WWPUserExtendedId ;
      private short[] BC000U19_A206WWPFormId ;
      private short[] BC000U19_A207WWPFormVersionNumber ;
      private int[] BC000U19_A214WWPFormInstanceId ;
      private short[] BC000U19_A215WWPFormInstanceElementId ;
      private string[] BC000U19_A229WWPFormElementTitle ;
      private string[] BC000U19_A213WWPFormElementReferenceId ;
      private short[] BC000U19_A218WWPFormElementDataType ;
      private short[] BC000U19_A230WWPFormElementParentType ;
      private short[] BC000U19_A217WWPFormElementType ;
      private string[] BC000U19_A236WWPFormElementMetadata ;
      private short[] BC000U19_A237WWPFormElementCaption ;
      private string[] BC000U19_A221WWPFormInstanceElemChar ;
      private bool[] BC000U19_n221WWPFormInstanceElemChar ;
      private DateTime[] BC000U19_A220WWPFormInstanceElemDate ;
      private bool[] BC000U19_n220WWPFormInstanceElemDate ;
      private DateTime[] BC000U19_A227WWPFormInstanceElemDateTime ;
      private bool[] BC000U19_n227WWPFormInstanceElemDateTime ;
      private decimal[] BC000U19_A222WWPFormInstanceElemNumeric ;
      private bool[] BC000U19_n222WWPFormInstanceElemNumeric ;
      private bool[] BC000U19_A226WWPFormInstanceElemBoolean ;
      private bool[] BC000U19_n226WWPFormInstanceElemBoolean ;
      private string[] BC000U19_A224WWPFormInstanceElemBlobFileTyp ;
      private string[] BC000U19_A225WWPFormInstanceElemBlobFileNam ;
      private short[] BC000U19_A210WWPFormElementId ;
      private short[] BC000U19_A211WWPFormElementParentId ;
      private bool[] BC000U19_n211WWPFormElementParentId ;
      private string[] BC000U19_A223WWPFormInstanceElemBlob ;
      private bool[] BC000U19_n223WWPFormInstanceElemBlob ;
      private short[] BC000U4_A206WWPFormId ;
      private short[] BC000U4_A207WWPFormVersionNumber ;
      private string[] BC000U4_A229WWPFormElementTitle ;
      private string[] BC000U4_A213WWPFormElementReferenceId ;
      private short[] BC000U4_A218WWPFormElementDataType ;
      private short[] BC000U4_A217WWPFormElementType ;
      private string[] BC000U4_A236WWPFormElementMetadata ;
      private short[] BC000U4_A237WWPFormElementCaption ;
      private short[] BC000U4_A211WWPFormElementParentId ;
      private bool[] BC000U4_n211WWPFormElementParentId ;
      private short[] BC000U5_A230WWPFormElementParentType ;
      private int[] BC000U20_A214WWPFormInstanceId ;
      private short[] BC000U20_A210WWPFormElementId ;
      private short[] BC000U20_A215WWPFormInstanceElementId ;
      private int[] BC000U3_A214WWPFormInstanceId ;
      private short[] BC000U3_A215WWPFormInstanceElementId ;
      private string[] BC000U3_A221WWPFormInstanceElemChar ;
      private bool[] BC000U3_n221WWPFormInstanceElemChar ;
      private DateTime[] BC000U3_A220WWPFormInstanceElemDate ;
      private bool[] BC000U3_n220WWPFormInstanceElemDate ;
      private DateTime[] BC000U3_A227WWPFormInstanceElemDateTime ;
      private bool[] BC000U3_n227WWPFormInstanceElemDateTime ;
      private decimal[] BC000U3_A222WWPFormInstanceElemNumeric ;
      private bool[] BC000U3_n222WWPFormInstanceElemNumeric ;
      private bool[] BC000U3_A226WWPFormInstanceElemBoolean ;
      private bool[] BC000U3_n226WWPFormInstanceElemBoolean ;
      private string[] BC000U3_A224WWPFormInstanceElemBlobFileTyp ;
      private string[] BC000U3_A225WWPFormInstanceElemBlobFileNam ;
      private short[] BC000U3_A210WWPFormElementId ;
      private string[] BC000U3_A223WWPFormInstanceElemBlob ;
      private bool[] BC000U3_n223WWPFormInstanceElemBlob ;
      private int[] BC000U2_A214WWPFormInstanceId ;
      private short[] BC000U2_A215WWPFormInstanceElementId ;
      private string[] BC000U2_A221WWPFormInstanceElemChar ;
      private bool[] BC000U2_n221WWPFormInstanceElemChar ;
      private DateTime[] BC000U2_A220WWPFormInstanceElemDate ;
      private bool[] BC000U2_n220WWPFormInstanceElemDate ;
      private DateTime[] BC000U2_A227WWPFormInstanceElemDateTime ;
      private bool[] BC000U2_n227WWPFormInstanceElemDateTime ;
      private decimal[] BC000U2_A222WWPFormInstanceElemNumeric ;
      private bool[] BC000U2_n222WWPFormInstanceElemNumeric ;
      private bool[] BC000U2_A226WWPFormInstanceElemBoolean ;
      private bool[] BC000U2_n226WWPFormInstanceElemBoolean ;
      private string[] BC000U2_A224WWPFormInstanceElemBlobFileTyp ;
      private string[] BC000U2_A225WWPFormInstanceElemBlobFileNam ;
      private short[] BC000U2_A210WWPFormElementId ;
      private string[] BC000U2_A223WWPFormInstanceElemBlob ;
      private bool[] BC000U2_n223WWPFormInstanceElemBlob ;
      private string[] BC000U25_A229WWPFormElementTitle ;
      private string[] BC000U25_A213WWPFormElementReferenceId ;
      private short[] BC000U25_A218WWPFormElementDataType ;
      private short[] BC000U25_A217WWPFormElementType ;
      private string[] BC000U25_A236WWPFormElementMetadata ;
      private short[] BC000U25_A237WWPFormElementCaption ;
      private short[] BC000U25_A211WWPFormElementParentId ;
      private bool[] BC000U25_n211WWPFormElementParentId ;
      private short[] BC000U26_A230WWPFormElementParentType ;
      private short[] BC000U27_A206WWPFormId ;
      private short[] BC000U27_A207WWPFormVersionNumber ;
      private int[] BC000U27_A214WWPFormInstanceId ;
      private short[] BC000U27_A215WWPFormInstanceElementId ;
      private string[] BC000U27_A229WWPFormElementTitle ;
      private string[] BC000U27_A213WWPFormElementReferenceId ;
      private short[] BC000U27_A218WWPFormElementDataType ;
      private short[] BC000U27_A230WWPFormElementParentType ;
      private short[] BC000U27_A217WWPFormElementType ;
      private string[] BC000U27_A236WWPFormElementMetadata ;
      private short[] BC000U27_A237WWPFormElementCaption ;
      private string[] BC000U27_A221WWPFormInstanceElemChar ;
      private bool[] BC000U27_n221WWPFormInstanceElemChar ;
      private DateTime[] BC000U27_A220WWPFormInstanceElemDate ;
      private bool[] BC000U27_n220WWPFormInstanceElemDate ;
      private DateTime[] BC000U27_A227WWPFormInstanceElemDateTime ;
      private bool[] BC000U27_n227WWPFormInstanceElemDateTime ;
      private decimal[] BC000U27_A222WWPFormInstanceElemNumeric ;
      private bool[] BC000U27_n222WWPFormInstanceElemNumeric ;
      private bool[] BC000U27_A226WWPFormInstanceElemBoolean ;
      private bool[] BC000U27_n226WWPFormInstanceElemBoolean ;
      private string[] BC000U27_A224WWPFormInstanceElemBlobFileTyp ;
      private string[] BC000U27_A225WWPFormInstanceElemBlobFileNam ;
      private short[] BC000U27_A210WWPFormElementId ;
      private short[] BC000U27_A211WWPFormElementParentId ;
      private bool[] BC000U27_n211WWPFormElementParentId ;
      private string[] BC000U27_A223WWPFormInstanceElemBlob ;
      private bool[] BC000U27_n223WWPFormInstanceElemBlob ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_forminstance_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_forminstance_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_forminstance_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[7])
      ,new ForEachCursor(def[8])
      ,new ForEachCursor(def[9])
      ,new UpdateCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new UpdateCursor(def[12])
      ,new UpdateCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
      ,new ForEachCursor(def[16])
      ,new ForEachCursor(def[17])
      ,new ForEachCursor(def[18])
      ,new UpdateCursor(def[19])
      ,new UpdateCursor(def[20])
      ,new UpdateCursor(def[21])
      ,new UpdateCursor(def[22])
      ,new ForEachCursor(def[23])
      ,new ForEachCursor(def[24])
      ,new ForEachCursor(def[25])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000U2;
       prmBC000U2 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
       new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
       };
       Object[] prmBC000U3;
       prmBC000U3 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
       new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
       };
       Object[] prmBC000U4;
       prmBC000U4 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmBC000U5;
       prmBC000U5 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmBC000U6;
       prmBC000U6 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
       };
       Object[] prmBC000U7;
       prmBC000U7 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
       };
       Object[] prmBC000U8;
       prmBC000U8 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC000U9;
       prmBC000U9 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0)
       };
       Object[] prmBC000U10;
       prmBC000U10 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
       };
       Object[] prmBC000U11;
       prmBC000U11 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
       };
       Object[] prmBC000U12;
       prmBC000U12 = new Object[] {
       new ParDef("WWPFormInstanceDate",GXType.DateTime,8,5) ,
       new ParDef("WWPFormInstanceRecordKey",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPUserExtendedId",GXType.Char,40,0)
       };
       Object[] prmBC000U13;
       prmBC000U13 = new Object[] {
       };
       Object[] prmBC000U14;
       prmBC000U14 = new Object[] {
       new ParDef("WWPFormInstanceDate",GXType.DateTime,8,5) ,
       new ParDef("WWPFormInstanceRecordKey",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPUserExtendedId",GXType.Char,40,0) ,
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
       };
       Object[] prmBC000U15;
       prmBC000U15 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
       };
       Object[] prmBC000U16;
       prmBC000U16 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0)
       };
       Object[] prmBC000U17;
       prmBC000U17 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0)
       };
       Object[] prmBC000U18;
       prmBC000U18 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
       };
       Object[] prmBC000U19;
       prmBC000U19 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
       new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmBC000U20;
       prmBC000U20 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
       new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
       };
       Object[] prmBC000U21;
       prmBC000U21 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
       new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0) ,
       new ParDef("WWPFormInstanceElemChar",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPFormInstanceElemDate",GXType.Date,8,0){Nullable=true} ,
       new ParDef("WWPFormInstanceElemDateTime",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("WWPFormInstanceElemNumeric",GXType.Number,18,5){Nullable=true} ,
       new ParDef("WWPFormInstanceElemBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
       new ParDef("WWPFormInstanceElemBoolean",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("WWPFormInstanceElemBlobFileTyp",GXType.VarChar,40,0) ,
       new ParDef("WWPFormInstanceElemBlobFileNam",GXType.VarChar,40,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmBC000U22;
       prmBC000U22 = new Object[] {
       new ParDef("WWPFormInstanceElemChar",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPFormInstanceElemDate",GXType.Date,8,0){Nullable=true} ,
       new ParDef("WWPFormInstanceElemDateTime",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("WWPFormInstanceElemNumeric",GXType.Number,18,5){Nullable=true} ,
       new ParDef("WWPFormInstanceElemBoolean",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("WWPFormInstanceElemBlobFileTyp",GXType.VarChar,40,0) ,
       new ParDef("WWPFormInstanceElemBlobFileNam",GXType.VarChar,40,0) ,
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
       new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
       };
       Object[] prmBC000U23;
       prmBC000U23 = new Object[] {
       new ParDef("WWPFormInstanceElemBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
       new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
       };
       Object[] prmBC000U24;
       prmBC000U24 = new Object[] {
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0) ,
       new ParDef("WWPFormInstanceElementId",GXType.Int16,4,0)
       };
       Object[] prmBC000U25;
       prmBC000U25 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementId",GXType.Int16,4,0)
       };
       Object[] prmBC000U26;
       prmBC000U26 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormElementParentId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmBC000U27;
       prmBC000U27 = new Object[] {
       new ParDef("WWPFormId",GXType.Int16,4,0) ,
       new ParDef("WWPFormVersionNumber",GXType.Int16,4,0) ,
       new ParDef("WWPFormInstanceId",GXType.Int32,6,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC000U2", "SELECT WWPFormInstanceId, WWPFormInstanceElementId, WWPFormInstanceElemChar, WWPFormInstanceElemDate, WWPFormInstanceElemDateTime, WWPFormInstanceElemNumeric, WWPFormInstanceElemBoolean, WWPFormInstanceElemBlobFileTyp, WWPFormInstanceElemBlobFileNam, WWPFormElementId, WWPFormInstanceElemBlob FROM WWP_FormInstanceElement WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId  FOR UPDATE OF WWP_FormInstanceElement",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000U3", "SELECT WWPFormInstanceId, WWPFormInstanceElementId, WWPFormInstanceElemChar, WWPFormInstanceElemDate, WWPFormInstanceElemDateTime, WWPFormInstanceElemNumeric, WWPFormInstanceElemBoolean, WWPFormInstanceElemBlobFileTyp, WWPFormInstanceElemBlobFileNam, WWPFormElementId, WWPFormInstanceElemBlob FROM WWP_FormInstanceElement WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000U4", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormElementTitle, WWPFormElementReferenceId, WWPFormElementDataType, WWPFormElementType, WWPFormElementMetadata, WWPFormElementCaption, WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000U5", "SELECT WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000U6", "SELECT WWPFormInstanceId, WWPFormInstanceDate, WWPFormInstanceRecordKey, WWPFormId, WWPFormVersionNumber, WWPUserExtendedId FROM WWP_FormInstance WHERE WWPFormInstanceId = :WWPFormInstanceId  FOR UPDATE OF WWP_FormInstance",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000U7", "SELECT WWPFormInstanceId, WWPFormInstanceDate, WWPFormInstanceRecordKey, WWPFormId, WWPFormVersionNumber, WWPUserExtendedId FROM WWP_FormInstance WHERE WWPFormInstanceId = :WWPFormInstanceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000U8", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormResume, WWPFormValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000U9", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000U10", "SELECT TM1.WWPFormInstanceId, TM1.WWPFormInstanceDate, T2.WWPFormReferenceName, T2.WWPFormTitle, T3.WWPUserExtendedFullName, T2.WWPFormResume, T2.WWPFormValidations, TM1.WWPFormInstanceRecordKey, TM1.WWPFormId, TM1.WWPFormVersionNumber, TM1.WWPUserExtendedId FROM ((WWP_FormInstance TM1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = TM1.WWPFormId AND T2.WWPFormVersionNumber = TM1.WWPFormVersionNumber) INNER JOIN WWP_UserExtended T3 ON T3.WWPUserExtendedId = TM1.WWPUserExtendedId) WHERE TM1.WWPFormInstanceId = :WWPFormInstanceId ORDER BY TM1.WWPFormInstanceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U10,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000U11", "SELECT WWPFormInstanceId FROM WWP_FormInstance WHERE WWPFormInstanceId = :WWPFormInstanceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U11,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000U12", "SAVEPOINT gxupdate;INSERT INTO WWP_FormInstance(WWPFormInstanceDate, WWPFormInstanceRecordKey, WWPFormId, WWPFormVersionNumber, WWPUserExtendedId) VALUES(:WWPFormInstanceDate, :WWPFormInstanceRecordKey, :WWPFormId, :WWPFormVersionNumber, :WWPUserExtendedId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000U12)
          ,new CursorDef("BC000U13", "SELECT currval('WWPFormInstanceId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U13,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000U14", "SAVEPOINT gxupdate;UPDATE WWP_FormInstance SET WWPFormInstanceDate=:WWPFormInstanceDate, WWPFormInstanceRecordKey=:WWPFormInstanceRecordKey, WWPFormId=:WWPFormId, WWPFormVersionNumber=:WWPFormVersionNumber, WWPUserExtendedId=:WWPUserExtendedId  WHERE WWPFormInstanceId = :WWPFormInstanceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000U14)
          ,new CursorDef("BC000U15", "SAVEPOINT gxupdate;DELETE FROM WWP_FormInstance  WHERE WWPFormInstanceId = :WWPFormInstanceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000U15)
          ,new CursorDef("BC000U16", "SELECT WWPFormReferenceName, WWPFormTitle, WWPFormResume, WWPFormValidations FROM WWP_Form WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U16,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000U17", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U17,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000U18", "SELECT TM1.WWPFormInstanceId, TM1.WWPFormInstanceDate, T2.WWPFormReferenceName, T2.WWPFormTitle, T3.WWPUserExtendedFullName, T2.WWPFormResume, T2.WWPFormValidations, TM1.WWPFormInstanceRecordKey, TM1.WWPFormId, TM1.WWPFormVersionNumber, TM1.WWPUserExtendedId FROM ((WWP_FormInstance TM1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = TM1.WWPFormId AND T2.WWPFormVersionNumber = TM1.WWPFormVersionNumber) INNER JOIN WWP_UserExtended T3 ON T3.WWPUserExtendedId = TM1.WWPUserExtendedId) WHERE TM1.WWPFormInstanceId = :WWPFormInstanceId ORDER BY TM1.WWPFormInstanceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U18,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000U19", "SELECT T2.WWPFormId, T2.WWPFormVersionNumber, T1.WWPFormInstanceId, T1.WWPFormInstanceElementId, T2.WWPFormElementTitle, T2.WWPFormElementReferenceId, T2.WWPFormElementDataType, T3.WWPFormElementType AS WWPFormElementParentType, T2.WWPFormElementType, T2.WWPFormElementMetadata, T2.WWPFormElementCaption, T1.WWPFormInstanceElemChar, T1.WWPFormInstanceElemDate, T1.WWPFormInstanceElemDateTime, T1.WWPFormInstanceElemNumeric, T1.WWPFormInstanceElemBoolean, T1.WWPFormInstanceElemBlobFileTyp, T1.WWPFormInstanceElemBlobFileNam, T1.WWPFormElementId, T2.WWPFormElementParentId AS WWPFormElementParentId, T1.WWPFormInstanceElemBlob FROM ((WWP_FormInstanceElement T1 LEFT JOIN WWP_FormElement T2 ON T2.WWPFormId = :WWPFormId AND T2.WWPFormVersionNumber = :WWPFormVersionNumber AND T2.WWPFormElementId = T1.WWPFormElementId) LEFT JOIN WWP_FormElement T3 ON T3.WWPFormId = T2.WWPFormId AND T3.WWPFormVersionNumber = T2.WWPFormVersionNumber AND T3.WWPFormElementId = T2.WWPFormElementParentId) WHERE T1.WWPFormInstanceId = :WWPFormInstanceId and T1.WWPFormInstanceElementId = :WWPFormInstanceElementId and T1.WWPFormElementId = :WWPFormElementId ORDER BY T1.WWPFormInstanceId, T1.WWPFormElementId, T1.WWPFormInstanceElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U19,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000U20", "SELECT WWPFormInstanceId, WWPFormElementId, WWPFormInstanceElementId FROM WWP_FormInstanceElement WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U20,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000U21", "SAVEPOINT gxupdate;INSERT INTO WWP_FormInstanceElement(WWPFormInstanceId, WWPFormInstanceElementId, WWPFormInstanceElemChar, WWPFormInstanceElemDate, WWPFormInstanceElemDateTime, WWPFormInstanceElemNumeric, WWPFormInstanceElemBlob, WWPFormInstanceElemBoolean, WWPFormInstanceElemBlobFileTyp, WWPFormInstanceElemBlobFileNam, WWPFormElementId) VALUES(:WWPFormInstanceId, :WWPFormInstanceElementId, :WWPFormInstanceElemChar, :WWPFormInstanceElemDate, :WWPFormInstanceElemDateTime, :WWPFormInstanceElemNumeric, :WWPFormInstanceElemBlob, :WWPFormInstanceElemBoolean, :WWPFormInstanceElemBlobFileTyp, :WWPFormInstanceElemBlobFileNam, :WWPFormElementId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000U21)
          ,new CursorDef("BC000U22", "SAVEPOINT gxupdate;UPDATE WWP_FormInstanceElement SET WWPFormInstanceElemChar=:WWPFormInstanceElemChar, WWPFormInstanceElemDate=:WWPFormInstanceElemDate, WWPFormInstanceElemDateTime=:WWPFormInstanceElemDateTime, WWPFormInstanceElemNumeric=:WWPFormInstanceElemNumeric, WWPFormInstanceElemBoolean=:WWPFormInstanceElemBoolean, WWPFormInstanceElemBlobFileTyp=:WWPFormInstanceElemBlobFileTyp, WWPFormInstanceElemBlobFileNam=:WWPFormInstanceElemBlobFileNam  WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000U22)
          ,new CursorDef("BC000U23", "SAVEPOINT gxupdate;UPDATE WWP_FormInstanceElement SET WWPFormInstanceElemBlob=:WWPFormInstanceElemBlob  WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000U23)
          ,new CursorDef("BC000U24", "SAVEPOINT gxupdate;DELETE FROM WWP_FormInstanceElement  WHERE WWPFormInstanceId = :WWPFormInstanceId AND WWPFormElementId = :WWPFormElementId AND WWPFormInstanceElementId = :WWPFormInstanceElementId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000U24)
          ,new CursorDef("BC000U25", "SELECT WWPFormElementTitle, WWPFormElementReferenceId, WWPFormElementDataType, WWPFormElementType, WWPFormElementMetadata, WWPFormElementCaption, WWPFormElementParentId FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U25,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000U26", "SELECT WWPFormElementType AS WWPFormElementParentType FROM WWP_FormElement WHERE WWPFormId = :WWPFormId AND WWPFormVersionNumber = :WWPFormVersionNumber AND WWPFormElementId = :WWPFormElementParentId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U26,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000U27", "SELECT T2.WWPFormId, T2.WWPFormVersionNumber, T1.WWPFormInstanceId, T1.WWPFormInstanceElementId, T2.WWPFormElementTitle, T2.WWPFormElementReferenceId, T2.WWPFormElementDataType, T3.WWPFormElementType AS WWPFormElementParentType, T2.WWPFormElementType, T2.WWPFormElementMetadata, T2.WWPFormElementCaption, T1.WWPFormInstanceElemChar, T1.WWPFormInstanceElemDate, T1.WWPFormInstanceElemDateTime, T1.WWPFormInstanceElemNumeric, T1.WWPFormInstanceElemBoolean, T1.WWPFormInstanceElemBlobFileTyp, T1.WWPFormInstanceElemBlobFileNam, T1.WWPFormElementId, T2.WWPFormElementParentId AS WWPFormElementParentId, T1.WWPFormInstanceElemBlob FROM ((WWP_FormInstanceElement T1 LEFT JOIN WWP_FormElement T2 ON T2.WWPFormId = :WWPFormId AND T2.WWPFormVersionNumber = :WWPFormVersionNumber AND T2.WWPFormElementId = T1.WWPFormElementId) LEFT JOIN WWP_FormElement T3 ON T3.WWPFormId = T2.WWPFormId AND T3.WWPFormVersionNumber = T2.WWPFormVersionNumber AND T3.WWPFormElementId = T2.WWPFormElementParentId) WHERE T1.WWPFormInstanceId = :WWPFormInstanceId ORDER BY T1.WWPFormInstanceId, T1.WWPFormElementId, T1.WWPFormInstanceElementId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U27,11, GxCacheFrequency.OFF ,true,false )
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
             ((int[]) buf[0])[0] = rslt.getInt(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
             ((bool[]) buf[5])[0] = rslt.wasNull(4);
             ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(5);
             ((bool[]) buf[7])[0] = rslt.wasNull(5);
             ((decimal[]) buf[8])[0] = rslt.getDecimal(6);
             ((bool[]) buf[9])[0] = rslt.wasNull(6);
             ((bool[]) buf[10])[0] = rslt.getBool(7);
             ((bool[]) buf[11])[0] = rslt.wasNull(7);
             ((string[]) buf[12])[0] = rslt.getVarchar(8);
             ((string[]) buf[13])[0] = rslt.getVarchar(9);
             ((short[]) buf[14])[0] = rslt.getShort(10);
             ((string[]) buf[15])[0] = rslt.getBLOBFile(11, rslt.getVarchar(8), rslt.getVarchar(9));
             ((bool[]) buf[16])[0] = rslt.wasNull(11);
             return;
          case 1 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
             ((bool[]) buf[5])[0] = rslt.wasNull(4);
             ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(5);
             ((bool[]) buf[7])[0] = rslt.wasNull(5);
             ((decimal[]) buf[8])[0] = rslt.getDecimal(6);
             ((bool[]) buf[9])[0] = rslt.wasNull(6);
             ((bool[]) buf[10])[0] = rslt.getBool(7);
             ((bool[]) buf[11])[0] = rslt.wasNull(7);
             ((string[]) buf[12])[0] = rslt.getVarchar(8);
             ((string[]) buf[13])[0] = rslt.getVarchar(9);
             ((short[]) buf[14])[0] = rslt.getShort(10);
             ((string[]) buf[15])[0] = rslt.getBLOBFile(11, rslt.getVarchar(8), rslt.getVarchar(9));
             ((bool[]) buf[16])[0] = rslt.wasNull(11);
             return;
          case 2 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((short[]) buf[7])[0] = rslt.getShort(8);
             ((short[]) buf[8])[0] = rslt.getShort(9);
             ((bool[]) buf[9])[0] = rslt.wasNull(9);
             return;
          case 3 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 4 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((short[]) buf[4])[0] = rslt.getShort(4);
             ((short[]) buf[5])[0] = rslt.getShort(5);
             ((string[]) buf[6])[0] = rslt.getString(6, 40);
             return;
          case 5 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((short[]) buf[4])[0] = rslt.getShort(4);
             ((short[]) buf[5])[0] = rslt.getShort(5);
             ((string[]) buf[6])[0] = rslt.getString(6, 40);
             return;
          case 6 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             return;
          case 7 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 8 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
             ((bool[]) buf[8])[0] = rslt.wasNull(8);
             ((short[]) buf[9])[0] = rslt.getShort(9);
             ((short[]) buf[10])[0] = rslt.getShort(10);
             ((string[]) buf[11])[0] = rslt.getString(11, 40);
             return;
          case 9 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             return;
          case 11 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             return;
          case 14 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             return;
          case 15 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 16 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
             ((bool[]) buf[8])[0] = rslt.wasNull(8);
             ((short[]) buf[9])[0] = rslt.getShort(9);
             ((short[]) buf[10])[0] = rslt.getShort(10);
             ((string[]) buf[11])[0] = rslt.getString(11, 40);
             return;
          case 17 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((int[]) buf[2])[0] = rslt.getInt(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((short[]) buf[6])[0] = rslt.getShort(7);
             ((short[]) buf[7])[0] = rslt.getShort(8);
             ((short[]) buf[8])[0] = rslt.getShort(9);
             ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
             ((short[]) buf[10])[0] = rslt.getShort(11);
             ((string[]) buf[11])[0] = rslt.getLongVarchar(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             ((DateTime[]) buf[13])[0] = rslt.getGXDate(13);
             ((bool[]) buf[14])[0] = rslt.wasNull(13);
             ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(14);
             ((bool[]) buf[16])[0] = rslt.wasNull(14);
             ((decimal[]) buf[17])[0] = rslt.getDecimal(15);
             ((bool[]) buf[18])[0] = rslt.wasNull(15);
             ((bool[]) buf[19])[0] = rslt.getBool(16);
             ((bool[]) buf[20])[0] = rslt.wasNull(16);
             ((string[]) buf[21])[0] = rslt.getVarchar(17);
             ((string[]) buf[22])[0] = rslt.getVarchar(18);
             ((short[]) buf[23])[0] = rslt.getShort(19);
             ((short[]) buf[24])[0] = rslt.getShort(20);
             ((bool[]) buf[25])[0] = rslt.wasNull(20);
             ((string[]) buf[26])[0] = rslt.getBLOBFile(21, rslt.getVarchar(17), rslt.getVarchar(18));
             ((bool[]) buf[27])[0] = rslt.wasNull(21);
             return;
          case 18 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             return;
          case 23 :
             ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((short[]) buf[6])[0] = rslt.getShort(7);
             ((bool[]) buf[7])[0] = rslt.wasNull(7);
             return;
          case 24 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 25 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((int[]) buf[2])[0] = rslt.getInt(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((short[]) buf[6])[0] = rslt.getShort(7);
             ((short[]) buf[7])[0] = rslt.getShort(8);
             ((short[]) buf[8])[0] = rslt.getShort(9);
             ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
             ((short[]) buf[10])[0] = rslt.getShort(11);
             ((string[]) buf[11])[0] = rslt.getLongVarchar(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             ((DateTime[]) buf[13])[0] = rslt.getGXDate(13);
             ((bool[]) buf[14])[0] = rslt.wasNull(13);
             ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(14);
             ((bool[]) buf[16])[0] = rslt.wasNull(14);
             ((decimal[]) buf[17])[0] = rslt.getDecimal(15);
             ((bool[]) buf[18])[0] = rslt.wasNull(15);
             ((bool[]) buf[19])[0] = rslt.getBool(16);
             ((bool[]) buf[20])[0] = rslt.wasNull(16);
             ((string[]) buf[21])[0] = rslt.getVarchar(17);
             ((string[]) buf[22])[0] = rslt.getVarchar(18);
             ((short[]) buf[23])[0] = rslt.getShort(19);
             ((short[]) buf[24])[0] = rslt.getShort(20);
             ((bool[]) buf[25])[0] = rslt.wasNull(20);
             ((string[]) buf[26])[0] = rslt.getBLOBFile(21, rslt.getVarchar(17), rslt.getVarchar(18));
             ((bool[]) buf[27])[0] = rslt.wasNull(21);
             return;
    }
 }

}

}
