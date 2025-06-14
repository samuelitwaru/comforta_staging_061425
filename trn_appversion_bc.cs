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
   public class trn_appversion_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_appversion_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_appversion_bc( IGxContext context )
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
         ReadRow1L94( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1L94( ) ;
         standaloneModal( ) ;
         AddRow1L94( ) ;
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
            E111L2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z523AppVersionId = A523AppVersionId;
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

      protected void CONFIRM_1L0( )
      {
         BeforeValidate1L94( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1L94( ) ;
            }
            else
            {
               CheckExtendedTable1L94( ) ;
               if ( AnyError == 0 )
               {
                  ZM1L94( 14) ;
                  ZM1L94( 15) ;
               }
               CloseExtendedTableCursors1L94( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode94 = Gx_mode;
            CONFIRM_1L95( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode94;
            }
            /* Restore parent mode. */
            Gx_mode = sMode94;
         }
      }

      protected void CONFIRM_1L95( )
      {
         nGXsfl_95_idx = 0;
         while ( nGXsfl_95_idx < bcTrn_AppVersion.gxTpr_Page.Count )
         {
            ReadRow1L95( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound95 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_95 != 0 ) )
            {
               GetKey1L95( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound95 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate1L95( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1L95( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors1L95( ) ;
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
                  if ( RcdFound95 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey1L95( ) ;
                        Load1L95( ) ;
                        BeforeValidate1L95( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1L95( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_95 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate1L95( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1L95( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors1L95( ) ;
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
               VarsToRow95( ((SdtTrn_AppVersion_Page)bcTrn_AppVersion.gxTpr_Page.Item(nGXsfl_95_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E121L2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV12TrnContext.gxTpr_Transactionname, AV31Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV32GXV1 = 1;
            while ( AV32GXV1 <= AV12TrnContext.gxTpr_Attributes.Count )
            {
               AV16TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV12TrnContext.gxTpr_Attributes.Item(AV32GXV1));
               if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "LocationId") == 0 )
               {
                  AV14Insert_LocationId = StringUtil.StrToGuid( AV16TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "OrganisationId") == 0 )
               {
                  AV15Insert_OrganisationId = StringUtil.StrToGuid( AV16TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "Trn_ThemeId") == 0 )
               {
                  AV29Insert_Trn_ThemeId = StringUtil.StrToGuid( AV16TrnContextAtt.gxTpr_Attributevalue);
               }
               AV32GXV1 = (int)(AV32GXV1+1);
            }
         }
      }

      protected void E111L2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1L94( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z524AppVersionName = A524AppVersionName;
            Z535IsActive = A535IsActive;
            Z620IsVersionDeleted = A620IsVersionDeleted;
            Z622VersionDeletedAt = A622VersionDeletedAt;
            Z11OrganisationId = A11OrganisationId;
            Z273Trn_ThemeId = A273Trn_ThemeId;
            Z29LocationId = A29LocationId;
         }
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -13 )
         {
            Z523AppVersionId = A523AppVersionId;
            Z524AppVersionName = A524AppVersionName;
            Z535IsActive = A535IsActive;
            Z620IsVersionDeleted = A620IsVersionDeleted;
            Z622VersionDeletedAt = A622VersionDeletedAt;
            Z11OrganisationId = A11OrganisationId;
            Z273Trn_ThemeId = A273Trn_ThemeId;
            Z29LocationId = A29LocationId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV31Pgmname = "Trn_AppVersion_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A523AppVersionId) )
         {
            A523AppVersionId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1L94( )
      {
         /* Using cursor BC001L8 */
         pr_default.execute(6, new Object[] {A523AppVersionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound94 = 1;
            A524AppVersionName = BC001L8_A524AppVersionName[0];
            A535IsActive = BC001L8_A535IsActive[0];
            A620IsVersionDeleted = BC001L8_A620IsVersionDeleted[0];
            A622VersionDeletedAt = BC001L8_A622VersionDeletedAt[0];
            n622VersionDeletedAt = BC001L8_n622VersionDeletedAt[0];
            A11OrganisationId = BC001L8_A11OrganisationId[0];
            n11OrganisationId = BC001L8_n11OrganisationId[0];
            A273Trn_ThemeId = BC001L8_A273Trn_ThemeId[0];
            A29LocationId = BC001L8_A29LocationId[0];
            n29LocationId = BC001L8_n29LocationId[0];
            ZM1L94( -13) ;
         }
         pr_default.close(6);
         OnLoadActions1L94( ) ;
      }

      protected void OnLoadActions1L94( )
      {
         if ( (Guid.Empty==A273Trn_ThemeId) )
         {
            GXt_guid1 = A273Trn_ThemeId;
            new prc_getdefaulttheme(context ).execute( out  GXt_guid1) ;
            A273Trn_ThemeId = GXt_guid1;
         }
      }

      protected void CheckExtendedTable1L94( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001L7 */
         pr_default.execute(5, new Object[] {n29LocationId, A29LocationId, n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (Guid.Empty==A29LocationId) || (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
         }
         pr_default.close(5);
         if ( (Guid.Empty==A273Trn_ThemeId) )
         {
            GXt_guid1 = A273Trn_ThemeId;
            new prc_getdefaulttheme(context ).execute( out  GXt_guid1) ;
            A273Trn_ThemeId = GXt_guid1;
         }
         /* Using cursor BC001L6 */
         pr_default.execute(4, new Object[] {A273Trn_ThemeId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), "", "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TRN_THEMEID");
            AnyError = 1;
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors1L94( )
      {
         pr_default.close(5);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1L94( )
      {
         /* Using cursor BC001L9 */
         pr_default.execute(7, new Object[] {A523AppVersionId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound94 = 1;
         }
         else
         {
            RcdFound94 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001L5 */
         pr_default.execute(3, new Object[] {A523AppVersionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM1L94( 13) ;
            RcdFound94 = 1;
            A523AppVersionId = BC001L5_A523AppVersionId[0];
            A524AppVersionName = BC001L5_A524AppVersionName[0];
            A535IsActive = BC001L5_A535IsActive[0];
            A620IsVersionDeleted = BC001L5_A620IsVersionDeleted[0];
            A622VersionDeletedAt = BC001L5_A622VersionDeletedAt[0];
            n622VersionDeletedAt = BC001L5_n622VersionDeletedAt[0];
            A11OrganisationId = BC001L5_A11OrganisationId[0];
            n11OrganisationId = BC001L5_n11OrganisationId[0];
            A273Trn_ThemeId = BC001L5_A273Trn_ThemeId[0];
            A29LocationId = BC001L5_A29LocationId[0];
            n29LocationId = BC001L5_n29LocationId[0];
            Z523AppVersionId = A523AppVersionId;
            sMode94 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1L94( ) ;
            if ( AnyError == 1 )
            {
               RcdFound94 = 0;
               InitializeNonKey1L94( ) ;
            }
            Gx_mode = sMode94;
         }
         else
         {
            RcdFound94 = 0;
            InitializeNonKey1L94( ) ;
            sMode94 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode94;
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey1L94( ) ;
         if ( RcdFound94 == 0 )
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
         CONFIRM_1L0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1L94( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001L4 */
            pr_default.execute(2, new Object[] {A523AppVersionId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppVersion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z524AppVersionName, BC001L4_A524AppVersionName[0]) != 0 ) || ( Z535IsActive != BC001L4_A535IsActive[0] ) || ( Z620IsVersionDeleted != BC001L4_A620IsVersionDeleted[0] ) || ( Z622VersionDeletedAt != BC001L4_A622VersionDeletedAt[0] ) || ( Z11OrganisationId != BC001L4_A11OrganisationId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z273Trn_ThemeId != BC001L4_A273Trn_ThemeId[0] ) || ( Z29LocationId != BC001L4_A29LocationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_AppVersion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1L94( )
      {
         BeforeValidate1L94( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1L94( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1L94( 0) ;
            CheckOptimisticConcurrency1L94( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1L94( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1L94( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001L10 */
                     pr_default.execute(8, new Object[] {A523AppVersionId, A524AppVersionName, A535IsActive, A620IsVersionDeleted, n622VersionDeletedAt, A622VersionDeletedAt, n11OrganisationId, A11OrganisationId, A273Trn_ThemeId, n29LocationId, A29LocationId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           ProcessLevel1L94( ) ;
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
               Load1L94( ) ;
            }
            EndLevel1L94( ) ;
         }
         CloseExtendedTableCursors1L94( ) ;
      }

      protected void Update1L94( )
      {
         BeforeValidate1L94( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1L94( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1L94( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1L94( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1L94( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001L11 */
                     pr_default.execute(9, new Object[] {A524AppVersionName, A535IsActive, A620IsVersionDeleted, n622VersionDeletedAt, A622VersionDeletedAt, n11OrganisationId, A11OrganisationId, A273Trn_ThemeId, n29LocationId, A29LocationId, A523AppVersionId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppVersion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1L94( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1L94( ) ;
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
            EndLevel1L94( ) ;
         }
         CloseExtendedTableCursors1L94( ) ;
      }

      protected void DeferredUpdate1L94( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1L94( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1L94( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1L94( ) ;
            AfterConfirm1L94( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1L94( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart1L95( ) ;
                  while ( RcdFound95 != 0 )
                  {
                     getByPrimaryKey1L95( ) ;
                     Delete1L95( ) ;
                     ScanKeyNext1L95( ) ;
                  }
                  ScanKeyEnd1L95( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001L12 */
                     pr_default.execute(10, new Object[] {A523AppVersionId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersion");
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
         sMode94 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1L94( ) ;
         Gx_mode = sMode94;
      }

      protected void OnDeleteControls1L94( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC001L13 */
            pr_default.execute(11, new Object[] {A523AppVersionId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Locations", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC001L14 */
            pr_default.execute(12, new Object[] {A523AppVersionId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Locations", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void ProcessNestedLevel1L95( )
      {
         nGXsfl_95_idx = 0;
         while ( nGXsfl_95_idx < bcTrn_AppVersion.gxTpr_Page.Count )
         {
            ReadRow1L95( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound95 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_95 != 0 ) )
            {
               standaloneNotModal1L95( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert1L95( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete1L95( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update1L95( ) ;
                  }
               }
            }
            KeyVarsToRow95( ((SdtTrn_AppVersion_Page)bcTrn_AppVersion.gxTpr_Page.Item(nGXsfl_95_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_95_idx = 0;
            while ( nGXsfl_95_idx < bcTrn_AppVersion.gxTpr_Page.Count )
            {
               ReadRow1L95( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound95 == 0 )
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
                  bcTrn_AppVersion.gxTpr_Page.RemoveElement(nGXsfl_95_idx);
                  nGXsfl_95_idx = (int)(nGXsfl_95_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey1L95( ) ;
                  VarsToRow95( ((SdtTrn_AppVersion_Page)bcTrn_AppVersion.gxTpr_Page.Item(nGXsfl_95_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1L95( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_95 = 0;
         nIsMod_95 = 0;
      }

      protected void ProcessLevel1L94( )
      {
         /* Save parent mode. */
         sMode94 = Gx_mode;
         ProcessNestedLevel1L95( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode94;
         /* ' Update level parameters */
      }

      protected void EndLevel1L94( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1L94( ) ;
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

      public void ScanKeyStart1L94( )
      {
         /* Scan By routine */
         /* Using cursor BC001L15 */
         pr_default.execute(13, new Object[] {A523AppVersionId});
         RcdFound94 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound94 = 1;
            A523AppVersionId = BC001L15_A523AppVersionId[0];
            A524AppVersionName = BC001L15_A524AppVersionName[0];
            A535IsActive = BC001L15_A535IsActive[0];
            A620IsVersionDeleted = BC001L15_A620IsVersionDeleted[0];
            A622VersionDeletedAt = BC001L15_A622VersionDeletedAt[0];
            n622VersionDeletedAt = BC001L15_n622VersionDeletedAt[0];
            A11OrganisationId = BC001L15_A11OrganisationId[0];
            n11OrganisationId = BC001L15_n11OrganisationId[0];
            A273Trn_ThemeId = BC001L15_A273Trn_ThemeId[0];
            A29LocationId = BC001L15_A29LocationId[0];
            n29LocationId = BC001L15_n29LocationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1L94( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound94 = 0;
         ScanKeyLoad1L94( ) ;
      }

      protected void ScanKeyLoad1L94( )
      {
         sMode94 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound94 = 1;
            A523AppVersionId = BC001L15_A523AppVersionId[0];
            A524AppVersionName = BC001L15_A524AppVersionName[0];
            A535IsActive = BC001L15_A535IsActive[0];
            A620IsVersionDeleted = BC001L15_A620IsVersionDeleted[0];
            A622VersionDeletedAt = BC001L15_A622VersionDeletedAt[0];
            n622VersionDeletedAt = BC001L15_n622VersionDeletedAt[0];
            A11OrganisationId = BC001L15_A11OrganisationId[0];
            n11OrganisationId = BC001L15_n11OrganisationId[0];
            A273Trn_ThemeId = BC001L15_A273Trn_ThemeId[0];
            A29LocationId = BC001L15_A29LocationId[0];
            n29LocationId = BC001L15_n29LocationId[0];
         }
         Gx_mode = sMode94;
      }

      protected void ScanKeyEnd1L94( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm1L94( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1L94( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1L94( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1L94( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1L94( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1L94( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1L94( )
      {
      }

      protected void ZM1L95( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z541IsPredefined = A541IsPredefined;
            Z517PageName = A517PageName;
            Z525PageType = A525PageType;
            Z621IsPageDeleted = A621IsPageDeleted;
            Z623PageDeletedAt = A623PageDeletedAt;
         }
         if ( GX_JID == -16 )
         {
            Z523AppVersionId = A523AppVersionId;
            Z516PageId = A516PageId;
            Z541IsPredefined = A541IsPredefined;
            Z517PageName = A517PageName;
            Z518PageStructure = A518PageStructure;
            Z536PagePublishedStructure = A536PagePublishedStructure;
            Z600PageThumbnail = A600PageThumbnail;
            Z40000PageThumbnail_GXI = A40000PageThumbnail_GXI;
            Z525PageType = A525PageType;
            Z621IsPageDeleted = A621IsPageDeleted;
            Z623PageDeletedAt = A623PageDeletedAt;
         }
      }

      protected void standaloneNotModal1L95( )
      {
      }

      protected void standaloneModal1L95( )
      {
         if ( IsIns( )  && (Guid.Empty==A516PageId) )
         {
            A516PageId = Guid.NewGuid( );
         }
         if ( IsIns( )  && (false==A541IsPredefined) && ( Gx_BScreen == 0 ) )
         {
            A541IsPredefined = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1L95( )
      {
         /* Using cursor BC001L16 */
         pr_default.execute(14, new Object[] {A523AppVersionId, A516PageId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound95 = 1;
            A541IsPredefined = BC001L16_A541IsPredefined[0];
            A517PageName = BC001L16_A517PageName[0];
            A518PageStructure = BC001L16_A518PageStructure[0];
            A536PagePublishedStructure = BC001L16_A536PagePublishedStructure[0];
            A40000PageThumbnail_GXI = BC001L16_A40000PageThumbnail_GXI[0];
            n40000PageThumbnail_GXI = BC001L16_n40000PageThumbnail_GXI[0];
            A525PageType = BC001L16_A525PageType[0];
            A621IsPageDeleted = BC001L16_A621IsPageDeleted[0];
            A623PageDeletedAt = BC001L16_A623PageDeletedAt[0];
            n623PageDeletedAt = BC001L16_n623PageDeletedAt[0];
            A600PageThumbnail = BC001L16_A600PageThumbnail[0];
            n600PageThumbnail = BC001L16_n600PageThumbnail[0];
            ZM1L95( -16) ;
         }
         pr_default.close(14);
         OnLoadActions1L95( ) ;
      }

      protected void OnLoadActions1L95( )
      {
      }

      protected void CheckExtendedTable1L95( )
      {
         Gx_BScreen = 1;
         standaloneModal1L95( ) ;
         Gx_BScreen = 0;
         if ( ! ( ( StringUtil.StrCmp(A525PageType, "Menu") == 0 ) || ( StringUtil.StrCmp(A525PageType, "Content") == 0 ) || ( StringUtil.StrCmp(A525PageType, "WebLink") == 0 ) || ( StringUtil.StrCmp(A525PageType, "DynamicForm") == 0 ) || ( StringUtil.StrCmp(A525PageType, "Calendar") == 0 ) || ( StringUtil.StrCmp(A525PageType, "MyActivity") == 0 ) || ( StringUtil.StrCmp(A525PageType, "Map") == 0 ) || ( StringUtil.StrCmp(A525PageType, "Reception") == 0 ) || ( StringUtil.StrCmp(A525PageType, "Location") == 0 ) || ( StringUtil.StrCmp(A525PageType, "MyCare") == 0 ) || ( StringUtil.StrCmp(A525PageType, "MyLiving") == 0 ) || ( StringUtil.StrCmp(A525PageType, "MyService") == 0 ) || ( StringUtil.StrCmp(A525PageType, "Information") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Page Type", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1L95( )
      {
      }

      protected void enableDisable1L95( )
      {
      }

      protected void GetKey1L95( )
      {
         /* Using cursor BC001L17 */
         pr_default.execute(15, new Object[] {A523AppVersionId, A516PageId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound95 = 1;
         }
         else
         {
            RcdFound95 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey1L95( )
      {
         /* Using cursor BC001L3 */
         pr_default.execute(1, new Object[] {A523AppVersionId, A516PageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1L95( 16) ;
            RcdFound95 = 1;
            InitializeNonKey1L95( ) ;
            A516PageId = BC001L3_A516PageId[0];
            A541IsPredefined = BC001L3_A541IsPredefined[0];
            A517PageName = BC001L3_A517PageName[0];
            A518PageStructure = BC001L3_A518PageStructure[0];
            A536PagePublishedStructure = BC001L3_A536PagePublishedStructure[0];
            A40000PageThumbnail_GXI = BC001L3_A40000PageThumbnail_GXI[0];
            n40000PageThumbnail_GXI = BC001L3_n40000PageThumbnail_GXI[0];
            A525PageType = BC001L3_A525PageType[0];
            A621IsPageDeleted = BC001L3_A621IsPageDeleted[0];
            A623PageDeletedAt = BC001L3_A623PageDeletedAt[0];
            n623PageDeletedAt = BC001L3_n623PageDeletedAt[0];
            A600PageThumbnail = BC001L3_A600PageThumbnail[0];
            n600PageThumbnail = BC001L3_n600PageThumbnail[0];
            Z523AppVersionId = A523AppVersionId;
            Z516PageId = A516PageId;
            sMode95 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1L95( ) ;
            Load1L95( ) ;
            Gx_mode = sMode95;
         }
         else
         {
            RcdFound95 = 0;
            InitializeNonKey1L95( ) ;
            sMode95 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1L95( ) ;
            Gx_mode = sMode95;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1L95( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1L95( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001L2 */
            pr_default.execute(0, new Object[] {A523AppVersionId, A516PageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppVersionPage"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z541IsPredefined != BC001L2_A541IsPredefined[0] ) || ( StringUtil.StrCmp(Z517PageName, BC001L2_A517PageName[0]) != 0 ) || ( StringUtil.StrCmp(Z525PageType, BC001L2_A525PageType[0]) != 0 ) || ( Z621IsPageDeleted != BC001L2_A621IsPageDeleted[0] ) || ( Z623PageDeletedAt != BC001L2_A623PageDeletedAt[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_AppVersionPage"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1L95( )
      {
         BeforeValidate1L95( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1L95( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1L95( 0) ;
            CheckOptimisticConcurrency1L95( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1L95( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1L95( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001L18 */
                     pr_default.execute(16, new Object[] {A523AppVersionId, A516PageId, A541IsPredefined, A517PageName, A518PageStructure, A536PagePublishedStructure, n600PageThumbnail, A600PageThumbnail, n40000PageThumbnail_GXI, A40000PageThumbnail_GXI, A525PageType, A621IsPageDeleted, n623PageDeletedAt, A623PageDeletedAt});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
                     if ( (pr_default.getStatus(16) == 1) )
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
               Load1L95( ) ;
            }
            EndLevel1L95( ) ;
         }
         CloseExtendedTableCursors1L95( ) ;
      }

      protected void Update1L95( )
      {
         BeforeValidate1L95( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1L95( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1L95( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1L95( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1L95( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001L19 */
                     pr_default.execute(17, new Object[] {A541IsPredefined, A517PageName, A518PageStructure, A536PagePublishedStructure, A525PageType, A621IsPageDeleted, n623PageDeletedAt, A623PageDeletedAt, A523AppVersionId, A516PageId});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
                     if ( (pr_default.getStatus(17) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppVersionPage"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1L95( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey1L95( ) ;
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
            EndLevel1L95( ) ;
         }
         CloseExtendedTableCursors1L95( ) ;
      }

      protected void DeferredUpdate1L95( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC001L20 */
            pr_default.execute(18, new Object[] {n600PageThumbnail, A600PageThumbnail, n40000PageThumbnail_GXI, A40000PageThumbnail_GXI, A523AppVersionId, A516PageId});
            pr_default.close(18);
            pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
         }
      }

      protected void Delete1L95( )
      {
         Gx_mode = "DLT";
         BeforeValidate1L95( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1L95( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1L95( ) ;
            AfterConfirm1L95( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1L95( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001L21 */
                  pr_default.execute(19, new Object[] {A523AppVersionId, A516PageId});
                  pr_default.close(19);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AppVersionPage");
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
         sMode95 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1L95( ) ;
         Gx_mode = sMode95;
      }

      protected void OnDeleteControls1L95( )
      {
         standaloneModal1L95( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1L95( )
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

      public void ScanKeyStart1L95( )
      {
         /* Scan By routine */
         /* Using cursor BC001L22 */
         pr_default.execute(20, new Object[] {A523AppVersionId});
         RcdFound95 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound95 = 1;
            A516PageId = BC001L22_A516PageId[0];
            A541IsPredefined = BC001L22_A541IsPredefined[0];
            A517PageName = BC001L22_A517PageName[0];
            A518PageStructure = BC001L22_A518PageStructure[0];
            A536PagePublishedStructure = BC001L22_A536PagePublishedStructure[0];
            A40000PageThumbnail_GXI = BC001L22_A40000PageThumbnail_GXI[0];
            n40000PageThumbnail_GXI = BC001L22_n40000PageThumbnail_GXI[0];
            A525PageType = BC001L22_A525PageType[0];
            A621IsPageDeleted = BC001L22_A621IsPageDeleted[0];
            A623PageDeletedAt = BC001L22_A623PageDeletedAt[0];
            n623PageDeletedAt = BC001L22_n623PageDeletedAt[0];
            A600PageThumbnail = BC001L22_A600PageThumbnail[0];
            n600PageThumbnail = BC001L22_n600PageThumbnail[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1L95( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound95 = 0;
         ScanKeyLoad1L95( ) ;
      }

      protected void ScanKeyLoad1L95( )
      {
         sMode95 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound95 = 1;
            A516PageId = BC001L22_A516PageId[0];
            A541IsPredefined = BC001L22_A541IsPredefined[0];
            A517PageName = BC001L22_A517PageName[0];
            A518PageStructure = BC001L22_A518PageStructure[0];
            A536PagePublishedStructure = BC001L22_A536PagePublishedStructure[0];
            A40000PageThumbnail_GXI = BC001L22_A40000PageThumbnail_GXI[0];
            n40000PageThumbnail_GXI = BC001L22_n40000PageThumbnail_GXI[0];
            A525PageType = BC001L22_A525PageType[0];
            A621IsPageDeleted = BC001L22_A621IsPageDeleted[0];
            A623PageDeletedAt = BC001L22_A623PageDeletedAt[0];
            n623PageDeletedAt = BC001L22_n623PageDeletedAt[0];
            A600PageThumbnail = BC001L22_A600PageThumbnail[0];
            n600PageThumbnail = BC001L22_n600PageThumbnail[0];
         }
         Gx_mode = sMode95;
      }

      protected void ScanKeyEnd1L95( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm1L95( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1L95( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1L95( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1L95( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1L95( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1L95( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1L95( )
      {
      }

      protected void send_integrity_lvl_hashes1L95( )
      {
      }

      protected void send_integrity_lvl_hashes1L94( )
      {
      }

      protected void AddRow1L94( )
      {
         VarsToRow94( bcTrn_AppVersion) ;
      }

      protected void ReadRow1L94( )
      {
         RowToVars94( bcTrn_AppVersion, 1) ;
      }

      protected void AddRow1L95( )
      {
         SdtTrn_AppVersion_Page obj95;
         obj95 = new SdtTrn_AppVersion_Page(context);
         VarsToRow95( obj95) ;
         bcTrn_AppVersion.gxTpr_Page.Add(obj95, 0);
         obj95.gxTpr_Mode = "UPD";
         obj95.gxTpr_Modified = 0;
      }

      protected void ReadRow1L95( )
      {
         nGXsfl_95_idx = (int)(nGXsfl_95_idx+1);
         RowToVars95( ((SdtTrn_AppVersion_Page)bcTrn_AppVersion.gxTpr_Page.Item(nGXsfl_95_idx)), 1) ;
      }

      protected void InitializeNonKey1L94( )
      {
         A273Trn_ThemeId = Guid.Empty;
         A524AppVersionName = "";
         A29LocationId = Guid.Empty;
         n29LocationId = false;
         A11OrganisationId = Guid.Empty;
         n11OrganisationId = false;
         A535IsActive = false;
         A620IsVersionDeleted = false;
         A622VersionDeletedAt = (DateTime)(DateTime.MinValue);
         n622VersionDeletedAt = false;
         Z524AppVersionName = "";
         Z535IsActive = false;
         Z620IsVersionDeleted = false;
         Z622VersionDeletedAt = (DateTime)(DateTime.MinValue);
         Z11OrganisationId = Guid.Empty;
         Z273Trn_ThemeId = Guid.Empty;
         Z29LocationId = Guid.Empty;
      }

      protected void InitAll1L94( )
      {
         A523AppVersionId = Guid.NewGuid( );
         InitializeNonKey1L94( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey1L95( )
      {
         A517PageName = "";
         A518PageStructure = "";
         A536PagePublishedStructure = "";
         A600PageThumbnail = "";
         n600PageThumbnail = false;
         A40000PageThumbnail_GXI = "";
         n40000PageThumbnail_GXI = false;
         A525PageType = "";
         A621IsPageDeleted = false;
         A623PageDeletedAt = (DateTime)(DateTime.MinValue);
         n623PageDeletedAt = false;
         A541IsPredefined = false;
         Z541IsPredefined = false;
         Z517PageName = "";
         Z525PageType = "";
         Z621IsPageDeleted = false;
         Z623PageDeletedAt = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll1L95( )
      {
         A516PageId = Guid.NewGuid( );
         InitializeNonKey1L95( ) ;
      }

      protected void StandaloneModalInsert1L95( )
      {
         A541IsPredefined = i541IsPredefined;
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

      public void VarsToRow94( SdtTrn_AppVersion obj94 )
      {
         obj94.gxTpr_Mode = Gx_mode;
         obj94.gxTpr_Trn_themeid = A273Trn_ThemeId;
         obj94.gxTpr_Appversionname = A524AppVersionName;
         obj94.gxTpr_Locationid = A29LocationId;
         obj94.gxTpr_Organisationid = A11OrganisationId;
         obj94.gxTpr_Isactive = A535IsActive;
         obj94.gxTpr_Isversiondeleted = A620IsVersionDeleted;
         obj94.gxTpr_Versiondeletedat = A622VersionDeletedAt;
         obj94.gxTpr_Appversionid = A523AppVersionId;
         obj94.gxTpr_Appversionid_Z = Z523AppVersionId;
         obj94.gxTpr_Appversionname_Z = Z524AppVersionName;
         obj94.gxTpr_Locationid_Z = Z29LocationId;
         obj94.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj94.gxTpr_Isactive_Z = Z535IsActive;
         obj94.gxTpr_Isversiondeleted_Z = Z620IsVersionDeleted;
         obj94.gxTpr_Versiondeletedat_Z = Z622VersionDeletedAt;
         obj94.gxTpr_Trn_themeid_Z = Z273Trn_ThemeId;
         obj94.gxTpr_Locationid_N = (short)(Convert.ToInt16(n29LocationId));
         obj94.gxTpr_Organisationid_N = (short)(Convert.ToInt16(n11OrganisationId));
         obj94.gxTpr_Versiondeletedat_N = (short)(Convert.ToInt16(n622VersionDeletedAt));
         obj94.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow94( SdtTrn_AppVersion obj94 )
      {
         obj94.gxTpr_Appversionid = A523AppVersionId;
         return  ;
      }

      public void RowToVars94( SdtTrn_AppVersion obj94 ,
                               int forceLoad )
      {
         Gx_mode = obj94.gxTpr_Mode;
         A273Trn_ThemeId = obj94.gxTpr_Trn_themeid;
         A524AppVersionName = obj94.gxTpr_Appversionname;
         A29LocationId = obj94.gxTpr_Locationid;
         n29LocationId = false;
         A11OrganisationId = obj94.gxTpr_Organisationid;
         n11OrganisationId = false;
         A535IsActive = obj94.gxTpr_Isactive;
         A620IsVersionDeleted = obj94.gxTpr_Isversiondeleted;
         A622VersionDeletedAt = obj94.gxTpr_Versiondeletedat;
         n622VersionDeletedAt = false;
         A523AppVersionId = obj94.gxTpr_Appversionid;
         Z523AppVersionId = obj94.gxTpr_Appversionid_Z;
         Z524AppVersionName = obj94.gxTpr_Appversionname_Z;
         Z29LocationId = obj94.gxTpr_Locationid_Z;
         Z11OrganisationId = obj94.gxTpr_Organisationid_Z;
         Z535IsActive = obj94.gxTpr_Isactive_Z;
         Z620IsVersionDeleted = obj94.gxTpr_Isversiondeleted_Z;
         Z622VersionDeletedAt = obj94.gxTpr_Versiondeletedat_Z;
         Z273Trn_ThemeId = obj94.gxTpr_Trn_themeid_Z;
         n29LocationId = (bool)(Convert.ToBoolean(obj94.gxTpr_Locationid_N));
         n11OrganisationId = (bool)(Convert.ToBoolean(obj94.gxTpr_Organisationid_N));
         n622VersionDeletedAt = (bool)(Convert.ToBoolean(obj94.gxTpr_Versiondeletedat_N));
         Gx_mode = obj94.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow95( SdtTrn_AppVersion_Page obj95 )
      {
         obj95.gxTpr_Mode = Gx_mode;
         obj95.gxTpr_Pagename = A517PageName;
         obj95.gxTpr_Pagestructure = A518PageStructure;
         obj95.gxTpr_Pagepublishedstructure = A536PagePublishedStructure;
         obj95.gxTpr_Pagethumbnail = A600PageThumbnail;
         obj95.gxTpr_Pagethumbnail_gxi = A40000PageThumbnail_GXI;
         obj95.gxTpr_Pagetype = A525PageType;
         obj95.gxTpr_Ispagedeleted = A621IsPageDeleted;
         obj95.gxTpr_Pagedeletedat = A623PageDeletedAt;
         obj95.gxTpr_Ispredefined = A541IsPredefined;
         obj95.gxTpr_Pageid = A516PageId;
         obj95.gxTpr_Pageid_Z = Z516PageId;
         obj95.gxTpr_Pagename_Z = Z517PageName;
         obj95.gxTpr_Ispredefined_Z = Z541IsPredefined;
         obj95.gxTpr_Pagetype_Z = Z525PageType;
         obj95.gxTpr_Ispagedeleted_Z = Z621IsPageDeleted;
         obj95.gxTpr_Pagedeletedat_Z = Z623PageDeletedAt;
         obj95.gxTpr_Pagethumbnail_gxi_Z = Z40000PageThumbnail_GXI;
         obj95.gxTpr_Pagethumbnail_N = (short)(Convert.ToInt16(n600PageThumbnail));
         obj95.gxTpr_Pagedeletedat_N = (short)(Convert.ToInt16(n623PageDeletedAt));
         obj95.gxTpr_Pagethumbnail_gxi_N = (short)(Convert.ToInt16(n40000PageThumbnail_GXI));
         obj95.gxTpr_Modified = nIsMod_95;
         return  ;
      }

      public void KeyVarsToRow95( SdtTrn_AppVersion_Page obj95 )
      {
         obj95.gxTpr_Pageid = A516PageId;
         return  ;
      }

      public void RowToVars95( SdtTrn_AppVersion_Page obj95 ,
                               int forceLoad )
      {
         Gx_mode = obj95.gxTpr_Mode;
         A517PageName = obj95.gxTpr_Pagename;
         A518PageStructure = obj95.gxTpr_Pagestructure;
         A536PagePublishedStructure = obj95.gxTpr_Pagepublishedstructure;
         A600PageThumbnail = obj95.gxTpr_Pagethumbnail;
         n600PageThumbnail = false;
         A40000PageThumbnail_GXI = obj95.gxTpr_Pagethumbnail_gxi;
         n40000PageThumbnail_GXI = false;
         A525PageType = obj95.gxTpr_Pagetype;
         A621IsPageDeleted = obj95.gxTpr_Ispagedeleted;
         A623PageDeletedAt = obj95.gxTpr_Pagedeletedat;
         n623PageDeletedAt = false;
         A541IsPredefined = obj95.gxTpr_Ispredefined;
         A516PageId = obj95.gxTpr_Pageid;
         Z516PageId = obj95.gxTpr_Pageid_Z;
         Z517PageName = obj95.gxTpr_Pagename_Z;
         Z541IsPredefined = obj95.gxTpr_Ispredefined_Z;
         Z525PageType = obj95.gxTpr_Pagetype_Z;
         Z621IsPageDeleted = obj95.gxTpr_Ispagedeleted_Z;
         Z623PageDeletedAt = obj95.gxTpr_Pagedeletedat_Z;
         Z40000PageThumbnail_GXI = obj95.gxTpr_Pagethumbnail_gxi_Z;
         n600PageThumbnail = (bool)(Convert.ToBoolean(obj95.gxTpr_Pagethumbnail_N));
         n623PageDeletedAt = (bool)(Convert.ToBoolean(obj95.gxTpr_Pagedeletedat_N));
         n40000PageThumbnail_GXI = (bool)(Convert.ToBoolean(obj95.gxTpr_Pagethumbnail_gxi_N));
         nIsMod_95 = obj95.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A523AppVersionId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1L94( ) ;
         ScanKeyStart1L94( ) ;
         if ( RcdFound94 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z523AppVersionId = A523AppVersionId;
         }
         ZM1L94( -13) ;
         OnLoadActions1L94( ) ;
         AddRow1L94( ) ;
         bcTrn_AppVersion.gxTpr_Page.ClearCollection();
         if ( RcdFound94 == 1 )
         {
            ScanKeyStart1L95( ) ;
            nGXsfl_95_idx = 1;
            while ( RcdFound95 != 0 )
            {
               Z523AppVersionId = A523AppVersionId;
               Z516PageId = A516PageId;
               ZM1L95( -16) ;
               OnLoadActions1L95( ) ;
               nRcdExists_95 = 1;
               nIsMod_95 = 0;
               AddRow1L95( ) ;
               nGXsfl_95_idx = (int)(nGXsfl_95_idx+1);
               ScanKeyNext1L95( ) ;
            }
            ScanKeyEnd1L95( ) ;
         }
         ScanKeyEnd1L94( ) ;
         if ( RcdFound94 == 0 )
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
         RowToVars94( bcTrn_AppVersion, 0) ;
         ScanKeyStart1L94( ) ;
         if ( RcdFound94 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z523AppVersionId = A523AppVersionId;
         }
         ZM1L94( -13) ;
         OnLoadActions1L94( ) ;
         AddRow1L94( ) ;
         bcTrn_AppVersion.gxTpr_Page.ClearCollection();
         if ( RcdFound94 == 1 )
         {
            ScanKeyStart1L95( ) ;
            nGXsfl_95_idx = 1;
            while ( RcdFound95 != 0 )
            {
               Z523AppVersionId = A523AppVersionId;
               Z516PageId = A516PageId;
               ZM1L95( -16) ;
               OnLoadActions1L95( ) ;
               nRcdExists_95 = 1;
               nIsMod_95 = 0;
               AddRow1L95( ) ;
               nGXsfl_95_idx = (int)(nGXsfl_95_idx+1);
               ScanKeyNext1L95( ) ;
            }
            ScanKeyEnd1L95( ) ;
         }
         ScanKeyEnd1L94( ) ;
         if ( RcdFound94 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1L94( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1L94( ) ;
         }
         else
         {
            if ( RcdFound94 == 1 )
            {
               if ( A523AppVersionId != Z523AppVersionId )
               {
                  A523AppVersionId = Z523AppVersionId;
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
                  Update1L94( ) ;
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
                  if ( A523AppVersionId != Z523AppVersionId )
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
                        Insert1L94( ) ;
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
                        Insert1L94( ) ;
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
         RowToVars94( bcTrn_AppVersion, 1) ;
         SaveImpl( ) ;
         VarsToRow94( bcTrn_AppVersion) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars94( bcTrn_AppVersion, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1L94( ) ;
         AfterTrn( ) ;
         VarsToRow94( bcTrn_AppVersion) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow94( bcTrn_AppVersion) ;
         }
         else
         {
            SdtTrn_AppVersion auxBC = new SdtTrn_AppVersion(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A523AppVersionId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_AppVersion);
               auxBC.Save();
               bcTrn_AppVersion.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars94( bcTrn_AppVersion, 1) ;
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
         RowToVars94( bcTrn_AppVersion, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1L94( ) ;
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
               VarsToRow94( bcTrn_AppVersion) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow94( bcTrn_AppVersion) ;
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
         RowToVars94( bcTrn_AppVersion, 0) ;
         GetKey1L94( ) ;
         if ( RcdFound94 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A523AppVersionId != Z523AppVersionId )
            {
               A523AppVersionId = Z523AppVersionId;
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
            if ( A523AppVersionId != Z523AppVersionId )
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
         context.RollbackDataStores("trn_appversion_bc",pr_default);
         VarsToRow94( bcTrn_AppVersion) ;
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
         Gx_mode = bcTrn_AppVersion.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_AppVersion.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_AppVersion )
         {
            bcTrn_AppVersion = (SdtTrn_AppVersion)(sdt);
            if ( StringUtil.StrCmp(bcTrn_AppVersion.gxTpr_Mode, "") == 0 )
            {
               bcTrn_AppVersion.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow94( bcTrn_AppVersion) ;
            }
            else
            {
               RowToVars94( bcTrn_AppVersion, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_AppVersion.gxTpr_Mode, "") == 0 )
            {
               bcTrn_AppVersion.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars94( bcTrn_AppVersion, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_AppVersion Trn_AppVersion_BC
      {
         get {
            return bcTrn_AppVersion ;
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
            return "trn_appversion_Execute" ;
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
         pr_default.close(3);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z523AppVersionId = Guid.Empty;
         A523AppVersionId = Guid.Empty;
         sMode94 = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         AV31Pgmname = "";
         AV16TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV14Insert_LocationId = Guid.Empty;
         AV15Insert_OrganisationId = Guid.Empty;
         AV29Insert_Trn_ThemeId = Guid.Empty;
         Z524AppVersionName = "";
         A524AppVersionName = "";
         Z622VersionDeletedAt = (DateTime)(DateTime.MinValue);
         A622VersionDeletedAt = (DateTime)(DateTime.MinValue);
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         Z273Trn_ThemeId = Guid.Empty;
         A273Trn_ThemeId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         BC001L8_A523AppVersionId = new Guid[] {Guid.Empty} ;
         BC001L8_A524AppVersionName = new string[] {""} ;
         BC001L8_A535IsActive = new bool[] {false} ;
         BC001L8_A620IsVersionDeleted = new bool[] {false} ;
         BC001L8_A622VersionDeletedAt = new DateTime[] {DateTime.MinValue} ;
         BC001L8_n622VersionDeletedAt = new bool[] {false} ;
         BC001L8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001L8_n11OrganisationId = new bool[] {false} ;
         BC001L8_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC001L8_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001L8_n29LocationId = new bool[] {false} ;
         BC001L7_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001L7_n29LocationId = new bool[] {false} ;
         GXt_guid1 = Guid.Empty;
         BC001L6_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC001L9_A523AppVersionId = new Guid[] {Guid.Empty} ;
         BC001L5_A523AppVersionId = new Guid[] {Guid.Empty} ;
         BC001L5_A524AppVersionName = new string[] {""} ;
         BC001L5_A535IsActive = new bool[] {false} ;
         BC001L5_A620IsVersionDeleted = new bool[] {false} ;
         BC001L5_A622VersionDeletedAt = new DateTime[] {DateTime.MinValue} ;
         BC001L5_n622VersionDeletedAt = new bool[] {false} ;
         BC001L5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001L5_n11OrganisationId = new bool[] {false} ;
         BC001L5_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC001L5_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001L5_n29LocationId = new bool[] {false} ;
         BC001L4_A523AppVersionId = new Guid[] {Guid.Empty} ;
         BC001L4_A524AppVersionName = new string[] {""} ;
         BC001L4_A535IsActive = new bool[] {false} ;
         BC001L4_A620IsVersionDeleted = new bool[] {false} ;
         BC001L4_A622VersionDeletedAt = new DateTime[] {DateTime.MinValue} ;
         BC001L4_n622VersionDeletedAt = new bool[] {false} ;
         BC001L4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001L4_n11OrganisationId = new bool[] {false} ;
         BC001L4_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC001L4_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001L4_n29LocationId = new bool[] {false} ;
         BC001L13_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001L13_n29LocationId = new bool[] {false} ;
         BC001L13_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001L13_n11OrganisationId = new bool[] {false} ;
         BC001L14_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001L14_n29LocationId = new bool[] {false} ;
         BC001L14_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001L14_n11OrganisationId = new bool[] {false} ;
         BC001L15_A523AppVersionId = new Guid[] {Guid.Empty} ;
         BC001L15_A524AppVersionName = new string[] {""} ;
         BC001L15_A535IsActive = new bool[] {false} ;
         BC001L15_A620IsVersionDeleted = new bool[] {false} ;
         BC001L15_A622VersionDeletedAt = new DateTime[] {DateTime.MinValue} ;
         BC001L15_n622VersionDeletedAt = new bool[] {false} ;
         BC001L15_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001L15_n11OrganisationId = new bool[] {false} ;
         BC001L15_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC001L15_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001L15_n29LocationId = new bool[] {false} ;
         Z517PageName = "";
         A517PageName = "";
         Z525PageType = "";
         A525PageType = "";
         Z623PageDeletedAt = (DateTime)(DateTime.MinValue);
         A623PageDeletedAt = (DateTime)(DateTime.MinValue);
         Z516PageId = Guid.Empty;
         A516PageId = Guid.Empty;
         Z518PageStructure = "";
         A518PageStructure = "";
         Z536PagePublishedStructure = "";
         A536PagePublishedStructure = "";
         Z600PageThumbnail = "";
         A600PageThumbnail = "";
         Z40000PageThumbnail_GXI = "";
         A40000PageThumbnail_GXI = "";
         BC001L16_A523AppVersionId = new Guid[] {Guid.Empty} ;
         BC001L16_A516PageId = new Guid[] {Guid.Empty} ;
         BC001L16_A541IsPredefined = new bool[] {false} ;
         BC001L16_A517PageName = new string[] {""} ;
         BC001L16_A518PageStructure = new string[] {""} ;
         BC001L16_A536PagePublishedStructure = new string[] {""} ;
         BC001L16_A40000PageThumbnail_GXI = new string[] {""} ;
         BC001L16_n40000PageThumbnail_GXI = new bool[] {false} ;
         BC001L16_A525PageType = new string[] {""} ;
         BC001L16_A621IsPageDeleted = new bool[] {false} ;
         BC001L16_A623PageDeletedAt = new DateTime[] {DateTime.MinValue} ;
         BC001L16_n623PageDeletedAt = new bool[] {false} ;
         BC001L16_A600PageThumbnail = new string[] {""} ;
         BC001L16_n600PageThumbnail = new bool[] {false} ;
         BC001L17_A523AppVersionId = new Guid[] {Guid.Empty} ;
         BC001L17_A516PageId = new Guid[] {Guid.Empty} ;
         BC001L3_A523AppVersionId = new Guid[] {Guid.Empty} ;
         BC001L3_A516PageId = new Guid[] {Guid.Empty} ;
         BC001L3_A541IsPredefined = new bool[] {false} ;
         BC001L3_A517PageName = new string[] {""} ;
         BC001L3_A518PageStructure = new string[] {""} ;
         BC001L3_A536PagePublishedStructure = new string[] {""} ;
         BC001L3_A40000PageThumbnail_GXI = new string[] {""} ;
         BC001L3_n40000PageThumbnail_GXI = new bool[] {false} ;
         BC001L3_A525PageType = new string[] {""} ;
         BC001L3_A621IsPageDeleted = new bool[] {false} ;
         BC001L3_A623PageDeletedAt = new DateTime[] {DateTime.MinValue} ;
         BC001L3_n623PageDeletedAt = new bool[] {false} ;
         BC001L3_A600PageThumbnail = new string[] {""} ;
         BC001L3_n600PageThumbnail = new bool[] {false} ;
         sMode95 = "";
         BC001L2_A523AppVersionId = new Guid[] {Guid.Empty} ;
         BC001L2_A516PageId = new Guid[] {Guid.Empty} ;
         BC001L2_A541IsPredefined = new bool[] {false} ;
         BC001L2_A517PageName = new string[] {""} ;
         BC001L2_A518PageStructure = new string[] {""} ;
         BC001L2_A536PagePublishedStructure = new string[] {""} ;
         BC001L2_A40000PageThumbnail_GXI = new string[] {""} ;
         BC001L2_n40000PageThumbnail_GXI = new bool[] {false} ;
         BC001L2_A525PageType = new string[] {""} ;
         BC001L2_A621IsPageDeleted = new bool[] {false} ;
         BC001L2_A623PageDeletedAt = new DateTime[] {DateTime.MinValue} ;
         BC001L2_n623PageDeletedAt = new bool[] {false} ;
         BC001L2_A600PageThumbnail = new string[] {""} ;
         BC001L2_n600PageThumbnail = new bool[] {false} ;
         BC001L22_A523AppVersionId = new Guid[] {Guid.Empty} ;
         BC001L22_A516PageId = new Guid[] {Guid.Empty} ;
         BC001L22_A541IsPredefined = new bool[] {false} ;
         BC001L22_A517PageName = new string[] {""} ;
         BC001L22_A518PageStructure = new string[] {""} ;
         BC001L22_A536PagePublishedStructure = new string[] {""} ;
         BC001L22_A40000PageThumbnail_GXI = new string[] {""} ;
         BC001L22_n40000PageThumbnail_GXI = new bool[] {false} ;
         BC001L22_A525PageType = new string[] {""} ;
         BC001L22_A621IsPageDeleted = new bool[] {false} ;
         BC001L22_A623PageDeletedAt = new DateTime[] {DateTime.MinValue} ;
         BC001L22_n623PageDeletedAt = new bool[] {false} ;
         BC001L22_A600PageThumbnail = new string[] {""} ;
         BC001L22_n600PageThumbnail = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_appversion_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_appversion_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_appversion_bc__default(),
            new Object[][] {
                new Object[] {
               BC001L2_A523AppVersionId, BC001L2_A516PageId, BC001L2_A541IsPredefined, BC001L2_A517PageName, BC001L2_A518PageStructure, BC001L2_A536PagePublishedStructure, BC001L2_A40000PageThumbnail_GXI, BC001L2_n40000PageThumbnail_GXI, BC001L2_A525PageType, BC001L2_A621IsPageDeleted,
               BC001L2_A623PageDeletedAt, BC001L2_n623PageDeletedAt, BC001L2_A600PageThumbnail, BC001L2_n600PageThumbnail
               }
               , new Object[] {
               BC001L3_A523AppVersionId, BC001L3_A516PageId, BC001L3_A541IsPredefined, BC001L3_A517PageName, BC001L3_A518PageStructure, BC001L3_A536PagePublishedStructure, BC001L3_A40000PageThumbnail_GXI, BC001L3_n40000PageThumbnail_GXI, BC001L3_A525PageType, BC001L3_A621IsPageDeleted,
               BC001L3_A623PageDeletedAt, BC001L3_n623PageDeletedAt, BC001L3_A600PageThumbnail, BC001L3_n600PageThumbnail
               }
               , new Object[] {
               BC001L4_A523AppVersionId, BC001L4_A524AppVersionName, BC001L4_A535IsActive, BC001L4_A620IsVersionDeleted, BC001L4_A622VersionDeletedAt, BC001L4_n622VersionDeletedAt, BC001L4_A11OrganisationId, BC001L4_n11OrganisationId, BC001L4_A273Trn_ThemeId, BC001L4_A29LocationId,
               BC001L4_n29LocationId
               }
               , new Object[] {
               BC001L5_A523AppVersionId, BC001L5_A524AppVersionName, BC001L5_A535IsActive, BC001L5_A620IsVersionDeleted, BC001L5_A622VersionDeletedAt, BC001L5_n622VersionDeletedAt, BC001L5_A11OrganisationId, BC001L5_n11OrganisationId, BC001L5_A273Trn_ThemeId, BC001L5_A29LocationId,
               BC001L5_n29LocationId
               }
               , new Object[] {
               BC001L6_A273Trn_ThemeId
               }
               , new Object[] {
               BC001L7_A29LocationId
               }
               , new Object[] {
               BC001L8_A523AppVersionId, BC001L8_A524AppVersionName, BC001L8_A535IsActive, BC001L8_A620IsVersionDeleted, BC001L8_A622VersionDeletedAt, BC001L8_n622VersionDeletedAt, BC001L8_A11OrganisationId, BC001L8_n11OrganisationId, BC001L8_A273Trn_ThemeId, BC001L8_A29LocationId,
               BC001L8_n29LocationId
               }
               , new Object[] {
               BC001L9_A523AppVersionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001L13_A29LocationId, BC001L13_A11OrganisationId
               }
               , new Object[] {
               BC001L14_A29LocationId, BC001L14_A11OrganisationId
               }
               , new Object[] {
               BC001L15_A523AppVersionId, BC001L15_A524AppVersionName, BC001L15_A535IsActive, BC001L15_A620IsVersionDeleted, BC001L15_A622VersionDeletedAt, BC001L15_n622VersionDeletedAt, BC001L15_A11OrganisationId, BC001L15_n11OrganisationId, BC001L15_A273Trn_ThemeId, BC001L15_A29LocationId,
               BC001L15_n29LocationId
               }
               , new Object[] {
               BC001L16_A523AppVersionId, BC001L16_A516PageId, BC001L16_A541IsPredefined, BC001L16_A517PageName, BC001L16_A518PageStructure, BC001L16_A536PagePublishedStructure, BC001L16_A40000PageThumbnail_GXI, BC001L16_n40000PageThumbnail_GXI, BC001L16_A525PageType, BC001L16_A621IsPageDeleted,
               BC001L16_A623PageDeletedAt, BC001L16_n623PageDeletedAt, BC001L16_A600PageThumbnail, BC001L16_n600PageThumbnail
               }
               , new Object[] {
               BC001L17_A523AppVersionId, BC001L17_A516PageId
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
               BC001L22_A523AppVersionId, BC001L22_A516PageId, BC001L22_A541IsPredefined, BC001L22_A517PageName, BC001L22_A518PageStructure, BC001L22_A536PagePublishedStructure, BC001L22_A40000PageThumbnail_GXI, BC001L22_n40000PageThumbnail_GXI, BC001L22_A525PageType, BC001L22_A621IsPageDeleted,
               BC001L22_A623PageDeletedAt, BC001L22_n623PageDeletedAt, BC001L22_A600PageThumbnail, BC001L22_n600PageThumbnail
               }
            }
         );
         Z516PageId = Guid.NewGuid( );
         A516PageId = Guid.NewGuid( );
         Z523AppVersionId = Guid.NewGuid( );
         A523AppVersionId = Guid.NewGuid( );
         AV31Pgmname = "Trn_AppVersion_BC";
         Z541IsPredefined = false;
         A541IsPredefined = false;
         i541IsPredefined = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121L2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_95 ;
      private short RcdFound95 ;
      private short Gx_BScreen ;
      private short RcdFound94 ;
      private short nRcdExists_95 ;
      private short Gxremove95 ;
      private int trnEnded ;
      private int nGXsfl_95_idx=1 ;
      private int AV32GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode94 ;
      private string AV31Pgmname ;
      private string sMode95 ;
      private DateTime Z622VersionDeletedAt ;
      private DateTime A622VersionDeletedAt ;
      private DateTime Z623PageDeletedAt ;
      private DateTime A623PageDeletedAt ;
      private bool returnInSub ;
      private bool Z535IsActive ;
      private bool A535IsActive ;
      private bool Z620IsVersionDeleted ;
      private bool A620IsVersionDeleted ;
      private bool n622VersionDeletedAt ;
      private bool n11OrganisationId ;
      private bool n29LocationId ;
      private bool Gx_longc ;
      private bool Z541IsPredefined ;
      private bool A541IsPredefined ;
      private bool Z621IsPageDeleted ;
      private bool A621IsPageDeleted ;
      private bool n40000PageThumbnail_GXI ;
      private bool n623PageDeletedAt ;
      private bool n600PageThumbnail ;
      private bool i541IsPredefined ;
      private string Z518PageStructure ;
      private string A518PageStructure ;
      private string Z536PagePublishedStructure ;
      private string A536PagePublishedStructure ;
      private string Z524AppVersionName ;
      private string A524AppVersionName ;
      private string Z517PageName ;
      private string A517PageName ;
      private string Z525PageType ;
      private string A525PageType ;
      private string Z40000PageThumbnail_GXI ;
      private string A40000PageThumbnail_GXI ;
      private string Z600PageThumbnail ;
      private string A600PageThumbnail ;
      private Guid Z523AppVersionId ;
      private Guid A523AppVersionId ;
      private Guid AV14Insert_LocationId ;
      private Guid AV15Insert_OrganisationId ;
      private Guid AV29Insert_Trn_ThemeId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid Z273Trn_ThemeId ;
      private Guid A273Trn_ThemeId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid GXt_guid1 ;
      private Guid Z516PageId ;
      private Guid A516PageId ;
      private IGxSession AV13WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_AppVersion bcTrn_AppVersion ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV12TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV16TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001L8_A523AppVersionId ;
      private string[] BC001L8_A524AppVersionName ;
      private bool[] BC001L8_A535IsActive ;
      private bool[] BC001L8_A620IsVersionDeleted ;
      private DateTime[] BC001L8_A622VersionDeletedAt ;
      private bool[] BC001L8_n622VersionDeletedAt ;
      private Guid[] BC001L8_A11OrganisationId ;
      private bool[] BC001L8_n11OrganisationId ;
      private Guid[] BC001L8_A273Trn_ThemeId ;
      private Guid[] BC001L8_A29LocationId ;
      private bool[] BC001L8_n29LocationId ;
      private Guid[] BC001L7_A29LocationId ;
      private bool[] BC001L7_n29LocationId ;
      private Guid[] BC001L6_A273Trn_ThemeId ;
      private Guid[] BC001L9_A523AppVersionId ;
      private Guid[] BC001L5_A523AppVersionId ;
      private string[] BC001L5_A524AppVersionName ;
      private bool[] BC001L5_A535IsActive ;
      private bool[] BC001L5_A620IsVersionDeleted ;
      private DateTime[] BC001L5_A622VersionDeletedAt ;
      private bool[] BC001L5_n622VersionDeletedAt ;
      private Guid[] BC001L5_A11OrganisationId ;
      private bool[] BC001L5_n11OrganisationId ;
      private Guid[] BC001L5_A273Trn_ThemeId ;
      private Guid[] BC001L5_A29LocationId ;
      private bool[] BC001L5_n29LocationId ;
      private Guid[] BC001L4_A523AppVersionId ;
      private string[] BC001L4_A524AppVersionName ;
      private bool[] BC001L4_A535IsActive ;
      private bool[] BC001L4_A620IsVersionDeleted ;
      private DateTime[] BC001L4_A622VersionDeletedAt ;
      private bool[] BC001L4_n622VersionDeletedAt ;
      private Guid[] BC001L4_A11OrganisationId ;
      private bool[] BC001L4_n11OrganisationId ;
      private Guid[] BC001L4_A273Trn_ThemeId ;
      private Guid[] BC001L4_A29LocationId ;
      private bool[] BC001L4_n29LocationId ;
      private Guid[] BC001L13_A29LocationId ;
      private bool[] BC001L13_n29LocationId ;
      private Guid[] BC001L13_A11OrganisationId ;
      private bool[] BC001L13_n11OrganisationId ;
      private Guid[] BC001L14_A29LocationId ;
      private bool[] BC001L14_n29LocationId ;
      private Guid[] BC001L14_A11OrganisationId ;
      private bool[] BC001L14_n11OrganisationId ;
      private Guid[] BC001L15_A523AppVersionId ;
      private string[] BC001L15_A524AppVersionName ;
      private bool[] BC001L15_A535IsActive ;
      private bool[] BC001L15_A620IsVersionDeleted ;
      private DateTime[] BC001L15_A622VersionDeletedAt ;
      private bool[] BC001L15_n622VersionDeletedAt ;
      private Guid[] BC001L15_A11OrganisationId ;
      private bool[] BC001L15_n11OrganisationId ;
      private Guid[] BC001L15_A273Trn_ThemeId ;
      private Guid[] BC001L15_A29LocationId ;
      private bool[] BC001L15_n29LocationId ;
      private Guid[] BC001L16_A523AppVersionId ;
      private Guid[] BC001L16_A516PageId ;
      private bool[] BC001L16_A541IsPredefined ;
      private string[] BC001L16_A517PageName ;
      private string[] BC001L16_A518PageStructure ;
      private string[] BC001L16_A536PagePublishedStructure ;
      private string[] BC001L16_A40000PageThumbnail_GXI ;
      private bool[] BC001L16_n40000PageThumbnail_GXI ;
      private string[] BC001L16_A525PageType ;
      private bool[] BC001L16_A621IsPageDeleted ;
      private DateTime[] BC001L16_A623PageDeletedAt ;
      private bool[] BC001L16_n623PageDeletedAt ;
      private string[] BC001L16_A600PageThumbnail ;
      private bool[] BC001L16_n600PageThumbnail ;
      private Guid[] BC001L17_A523AppVersionId ;
      private Guid[] BC001L17_A516PageId ;
      private Guid[] BC001L3_A523AppVersionId ;
      private Guid[] BC001L3_A516PageId ;
      private bool[] BC001L3_A541IsPredefined ;
      private string[] BC001L3_A517PageName ;
      private string[] BC001L3_A518PageStructure ;
      private string[] BC001L3_A536PagePublishedStructure ;
      private string[] BC001L3_A40000PageThumbnail_GXI ;
      private bool[] BC001L3_n40000PageThumbnail_GXI ;
      private string[] BC001L3_A525PageType ;
      private bool[] BC001L3_A621IsPageDeleted ;
      private DateTime[] BC001L3_A623PageDeletedAt ;
      private bool[] BC001L3_n623PageDeletedAt ;
      private string[] BC001L3_A600PageThumbnail ;
      private bool[] BC001L3_n600PageThumbnail ;
      private Guid[] BC001L2_A523AppVersionId ;
      private Guid[] BC001L2_A516PageId ;
      private bool[] BC001L2_A541IsPredefined ;
      private string[] BC001L2_A517PageName ;
      private string[] BC001L2_A518PageStructure ;
      private string[] BC001L2_A536PagePublishedStructure ;
      private string[] BC001L2_A40000PageThumbnail_GXI ;
      private bool[] BC001L2_n40000PageThumbnail_GXI ;
      private string[] BC001L2_A525PageType ;
      private bool[] BC001L2_A621IsPageDeleted ;
      private DateTime[] BC001L2_A623PageDeletedAt ;
      private bool[] BC001L2_n623PageDeletedAt ;
      private string[] BC001L2_A600PageThumbnail ;
      private bool[] BC001L2_n600PageThumbnail ;
      private Guid[] BC001L22_A523AppVersionId ;
      private Guid[] BC001L22_A516PageId ;
      private bool[] BC001L22_A541IsPredefined ;
      private string[] BC001L22_A517PageName ;
      private string[] BC001L22_A518PageStructure ;
      private string[] BC001L22_A536PagePublishedStructure ;
      private string[] BC001L22_A40000PageThumbnail_GXI ;
      private bool[] BC001L22_n40000PageThumbnail_GXI ;
      private string[] BC001L22_A525PageType ;
      private bool[] BC001L22_A621IsPageDeleted ;
      private DateTime[] BC001L22_A623PageDeletedAt ;
      private bool[] BC001L22_n623PageDeletedAt ;
      private string[] BC001L22_A600PageThumbnail ;
      private bool[] BC001L22_n600PageThumbnail ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_appversion_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_appversion_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_appversion_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[8])
      ,new UpdateCursor(def[9])
      ,new UpdateCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
      ,new UpdateCursor(def[16])
      ,new UpdateCursor(def[17])
      ,new UpdateCursor(def[18])
      ,new UpdateCursor(def[19])
      ,new ForEachCursor(def[20])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC001L2;
       prmBC001L2 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001L3;
       prmBC001L3 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001L4;
       prmBC001L4 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001L5;
       prmBC001L5 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001L6;
       prmBC001L6 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001L7;
       prmBC001L7 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001L8;
       prmBC001L8 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001L9;
       prmBC001L9 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001L10;
       prmBC001L10 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AppVersionName",GXType.VarChar,100,0) ,
       new ParDef("IsActive",GXType.Boolean,4,0) ,
       new ParDef("IsVersionDeleted",GXType.Boolean,4,0) ,
       new ParDef("VersionDeletedAt",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001L11;
       prmBC001L11 = new Object[] {
       new ParDef("AppVersionName",GXType.VarChar,100,0) ,
       new ParDef("IsActive",GXType.Boolean,4,0) ,
       new ParDef("IsVersionDeleted",GXType.Boolean,4,0) ,
       new ParDef("VersionDeletedAt",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001L12;
       prmBC001L12 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001L13;
       prmBC001L13 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001L14;
       prmBC001L14 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001L15;
       prmBC001L15 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001L16;
       prmBC001L16 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001L17;
       prmBC001L17 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001L18;
       prmBC001L18 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("IsPredefined",GXType.Boolean,4,0) ,
       new ParDef("PageName",GXType.VarChar,100,0) ,
       new ParDef("PageStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("PagePublishedStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("PageThumbnail",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("PageThumbnail_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=6, Tbl="Trn_AppVersionPage", Fld="PageThumbnail"} ,
       new ParDef("PageType",GXType.VarChar,40,0) ,
       new ParDef("IsPageDeleted",GXType.Boolean,4,0) ,
       new ParDef("PageDeletedAt",GXType.DateTime,8,5){Nullable=true}
       };
       Object[] prmBC001L19;
       prmBC001L19 = new Object[] {
       new ParDef("IsPredefined",GXType.Boolean,4,0) ,
       new ParDef("PageName",GXType.VarChar,100,0) ,
       new ParDef("PageStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("PagePublishedStructure",GXType.LongVarChar,2097152,0) ,
       new ParDef("PageType",GXType.VarChar,40,0) ,
       new ParDef("IsPageDeleted",GXType.Boolean,4,0) ,
       new ParDef("PageDeletedAt",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001L20;
       prmBC001L20 = new Object[] {
       new ParDef("PageThumbnail",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("PageThumbnail_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Trn_AppVersionPage", Fld="PageThumbnail"} ,
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001L21;
       prmBC001L21 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001L22;
       prmBC001L22 = new Object[] {
       new ParDef("AppVersionId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001L2", "SELECT AppVersionId, PageId, IsPredefined, PageName, PageStructure, PagePublishedStructure, PageThumbnail_GXI, PageType, IsPageDeleted, PageDeletedAt, PageThumbnail FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId AND PageId = :PageId  FOR UPDATE OF Trn_AppVersionPage",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001L3", "SELECT AppVersionId, PageId, IsPredefined, PageName, PageStructure, PagePublishedStructure, PageThumbnail_GXI, PageType, IsPageDeleted, PageDeletedAt, PageThumbnail FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId AND PageId = :PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001L4", "SELECT AppVersionId, AppVersionName, IsActive, IsVersionDeleted, VersionDeletedAt, OrganisationId, Trn_ThemeId, LocationId FROM Trn_AppVersion WHERE AppVersionId = :AppVersionId  FOR UPDATE OF Trn_AppVersion",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001L5", "SELECT AppVersionId, AppVersionName, IsActive, IsVersionDeleted, VersionDeletedAt, OrganisationId, Trn_ThemeId, LocationId FROM Trn_AppVersion WHERE AppVersionId = :AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001L6", "SELECT Trn_ThemeId FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001L7", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001L8", "SELECT TM1.AppVersionId, TM1.AppVersionName, TM1.IsActive, TM1.IsVersionDeleted, TM1.VersionDeletedAt, TM1.OrganisationId, TM1.Trn_ThemeId, TM1.LocationId FROM Trn_AppVersion TM1 WHERE TM1.AppVersionId = :AppVersionId ORDER BY TM1.AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L8,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001L9", "SELECT AppVersionId FROM Trn_AppVersion WHERE AppVersionId = :AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001L10", "SAVEPOINT gxupdate;INSERT INTO Trn_AppVersion(AppVersionId, AppVersionName, IsActive, IsVersionDeleted, VersionDeletedAt, OrganisationId, Trn_ThemeId, LocationId) VALUES(:AppVersionId, :AppVersionName, :IsActive, :IsVersionDeleted, :VersionDeletedAt, :OrganisationId, :Trn_ThemeId, :LocationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001L10)
          ,new CursorDef("BC001L11", "SAVEPOINT gxupdate;UPDATE Trn_AppVersion SET AppVersionName=:AppVersionName, IsActive=:IsActive, IsVersionDeleted=:IsVersionDeleted, VersionDeletedAt=:VersionDeletedAt, OrganisationId=:OrganisationId, Trn_ThemeId=:Trn_ThemeId, LocationId=:LocationId  WHERE AppVersionId = :AppVersionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001L11)
          ,new CursorDef("BC001L12", "SAVEPOINT gxupdate;DELETE FROM Trn_AppVersion  WHERE AppVersionId = :AppVersionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001L12)
          ,new CursorDef("BC001L13", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE PublishedActiveAppVersionId = :AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L13,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC001L14", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE ActiveAppVersionId = :AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L14,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC001L15", "SELECT TM1.AppVersionId, TM1.AppVersionName, TM1.IsActive, TM1.IsVersionDeleted, TM1.VersionDeletedAt, TM1.OrganisationId, TM1.Trn_ThemeId, TM1.LocationId FROM Trn_AppVersion TM1 WHERE TM1.AppVersionId = :AppVersionId ORDER BY TM1.AppVersionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L15,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001L16", "SELECT AppVersionId, PageId, IsPredefined, PageName, PageStructure, PagePublishedStructure, PageThumbnail_GXI, PageType, IsPageDeleted, PageDeletedAt, PageThumbnail FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId and PageId = :PageId ORDER BY AppVersionId, PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L16,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001L17", "SELECT AppVersionId, PageId FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId AND PageId = :PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L17,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001L18", "SAVEPOINT gxupdate;INSERT INTO Trn_AppVersionPage(AppVersionId, PageId, IsPredefined, PageName, PageStructure, PagePublishedStructure, PageThumbnail, PageThumbnail_GXI, PageType, IsPageDeleted, PageDeletedAt) VALUES(:AppVersionId, :PageId, :IsPredefined, :PageName, :PageStructure, :PagePublishedStructure, :PageThumbnail, :PageThumbnail_GXI, :PageType, :IsPageDeleted, :PageDeletedAt);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001L18)
          ,new CursorDef("BC001L19", "SAVEPOINT gxupdate;UPDATE Trn_AppVersionPage SET IsPredefined=:IsPredefined, PageName=:PageName, PageStructure=:PageStructure, PagePublishedStructure=:PagePublishedStructure, PageType=:PageType, IsPageDeleted=:IsPageDeleted, PageDeletedAt=:PageDeletedAt  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001L19)
          ,new CursorDef("BC001L20", "SAVEPOINT gxupdate;UPDATE Trn_AppVersionPage SET PageThumbnail=:PageThumbnail, PageThumbnail_GXI=:PageThumbnail_GXI  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001L20)
          ,new CursorDef("BC001L21", "SAVEPOINT gxupdate;DELETE FROM Trn_AppVersionPage  WHERE AppVersionId = :AppVersionId AND PageId = :PageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001L21)
          ,new CursorDef("BC001L22", "SELECT AppVersionId, PageId, IsPredefined, PageName, PageStructure, PagePublishedStructure, PageThumbnail_GXI, PageType, IsPageDeleted, PageDeletedAt, PageThumbnail FROM Trn_AppVersionPage WHERE AppVersionId = :AppVersionId ORDER BY AppVersionId, PageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L22,11, GxCacheFrequency.OFF ,true,false )
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
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
             ((bool[]) buf[7])[0] = rslt.wasNull(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((bool[]) buf[9])[0] = rslt.getBool(9);
             ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(10);
             ((bool[]) buf[11])[0] = rslt.wasNull(10);
             ((string[]) buf[12])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(7));
             ((bool[]) buf[13])[0] = rslt.wasNull(11);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
             ((bool[]) buf[7])[0] = rslt.wasNull(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((bool[]) buf[9])[0] = rslt.getBool(9);
             ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(10);
             ((bool[]) buf[11])[0] = rslt.wasNull(10);
             ((string[]) buf[12])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(7));
             ((bool[]) buf[13])[0] = rslt.wasNull(11);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             ((Guid[]) buf[6])[0] = rslt.getGuid(6);
             ((bool[]) buf[7])[0] = rslt.wasNull(6);
             ((Guid[]) buf[8])[0] = rslt.getGuid(7);
             ((Guid[]) buf[9])[0] = rslt.getGuid(8);
             ((bool[]) buf[10])[0] = rslt.wasNull(8);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             ((Guid[]) buf[6])[0] = rslt.getGuid(6);
             ((bool[]) buf[7])[0] = rslt.wasNull(6);
             ((Guid[]) buf[8])[0] = rslt.getGuid(7);
             ((Guid[]) buf[9])[0] = rslt.getGuid(8);
             ((bool[]) buf[10])[0] = rslt.wasNull(8);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             ((Guid[]) buf[6])[0] = rslt.getGuid(6);
             ((bool[]) buf[7])[0] = rslt.wasNull(6);
             ((Guid[]) buf[8])[0] = rslt.getGuid(7);
             ((Guid[]) buf[9])[0] = rslt.getGuid(8);
             ((bool[]) buf[10])[0] = rslt.wasNull(8);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 11 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 13 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             ((Guid[]) buf[6])[0] = rslt.getGuid(6);
             ((bool[]) buf[7])[0] = rslt.wasNull(6);
             ((Guid[]) buf[8])[0] = rslt.getGuid(7);
             ((Guid[]) buf[9])[0] = rslt.getGuid(8);
             ((bool[]) buf[10])[0] = rslt.wasNull(8);
             return;
          case 14 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
             ((bool[]) buf[7])[0] = rslt.wasNull(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((bool[]) buf[9])[0] = rslt.getBool(9);
             ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(10);
             ((bool[]) buf[11])[0] = rslt.wasNull(10);
             ((string[]) buf[12])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(7));
             ((bool[]) buf[13])[0] = rslt.wasNull(11);
             return;
          case 15 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 20 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
             ((bool[]) buf[7])[0] = rslt.wasNull(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((bool[]) buf[9])[0] = rslt.getBool(9);
             ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(10);
             ((bool[]) buf[11])[0] = rslt.wasNull(10);
             ((string[]) buf[12])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(7));
             ((bool[]) buf[13])[0] = rslt.wasNull(11);
             return;
    }
 }

}

}
