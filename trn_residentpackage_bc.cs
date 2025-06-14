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
   public class trn_residentpackage_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_residentpackage_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_residentpackage_bc( IGxContext context )
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
         ReadRow1M96( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1M96( ) ;
         standaloneModal( ) ;
         AddRow1M96( ) ;
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
            E111M2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z527ResidentPackageId = A527ResidentPackageId;
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

      protected void CONFIRM_1M0( )
      {
         BeforeValidate1M96( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1M96( ) ;
            }
            else
            {
               CheckExtendedTable1M96( ) ;
               if ( AnyError == 0 )
               {
                  ZM1M96( 13) ;
               }
               CloseExtendedTableCursors1M96( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121M2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV34Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV35GXV1 = 1;
            while ( AV35GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV35GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "SG_LocationId") == 0 )
               {
                  AV32Insert_SG_LocationId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "SG_OrganisationId") == 0 )
               {
                  AV33Insert_SG_OrganisationId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
               }
               AV35GXV1 = (int)(AV35GXV1+1);
            }
         }
      }

      protected void E111M2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1M96( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z531ResidentPackageName = A531ResidentPackageName;
            Z533ResidentPackageDefault = A533ResidentPackageDefault;
            Z528SG_LocationId = A528SG_LocationId;
            Z529SG_OrganisationId = A529SG_OrganisationId;
         }
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -12 )
         {
            Z527ResidentPackageId = A527ResidentPackageId;
            Z531ResidentPackageName = A531ResidentPackageName;
            Z532ResidentPackageModules = A532ResidentPackageModules;
            Z533ResidentPackageDefault = A533ResidentPackageDefault;
            Z528SG_LocationId = A528SG_LocationId;
            Z529SG_OrganisationId = A529SG_OrganisationId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV34Pgmname = "Trn_ResidentPackage_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A527ResidentPackageId) )
         {
            A527ResidentPackageId = Guid.NewGuid( );
            n527ResidentPackageId = false;
         }
         GXt_guid1 = A528SG_LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid1) ;
         A528SG_LocationId = GXt_guid1;
         GXt_guid1 = A529SG_OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         A529SG_OrganisationId = GXt_guid1;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1M96( )
      {
         /* Using cursor BC001M5 */
         pr_default.execute(3, new Object[] {n527ResidentPackageId, A527ResidentPackageId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound96 = 1;
            A531ResidentPackageName = BC001M5_A531ResidentPackageName[0];
            A532ResidentPackageModules = BC001M5_A532ResidentPackageModules[0];
            A533ResidentPackageDefault = BC001M5_A533ResidentPackageDefault[0];
            A528SG_LocationId = BC001M5_A528SG_LocationId[0];
            A529SG_OrganisationId = BC001M5_A529SG_OrganisationId[0];
            ZM1M96( -12) ;
         }
         pr_default.close(3);
         OnLoadActions1M96( ) ;
      }

      protected void OnLoadActions1M96( )
      {
      }

      protected void CheckExtendedTable1M96( )
      {
         standaloneModal( ) ;
         if ( A533ResidentPackageDefault )
         {
            new prc_defaultresidetpackage(context ).execute(  A527ResidentPackageId, ref  A528SG_LocationId) ;
         }
         /* Using cursor BC001M4 */
         pr_default.execute(2, new Object[] {A528SG_LocationId, A529SG_OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SG_Location", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A531ResidentPackageName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Resident Package Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( StringUtil.Len( A532ResidentPackageModules) <= 2 )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Resident Package Modules", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1M96( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1M96( )
      {
         /* Using cursor BC001M6 */
         pr_default.execute(4, new Object[] {n527ResidentPackageId, A527ResidentPackageId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound96 = 1;
         }
         else
         {
            RcdFound96 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001M3 */
         pr_default.execute(1, new Object[] {n527ResidentPackageId, A527ResidentPackageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1M96( 12) ;
            RcdFound96 = 1;
            A527ResidentPackageId = BC001M3_A527ResidentPackageId[0];
            n527ResidentPackageId = BC001M3_n527ResidentPackageId[0];
            A531ResidentPackageName = BC001M3_A531ResidentPackageName[0];
            A532ResidentPackageModules = BC001M3_A532ResidentPackageModules[0];
            A533ResidentPackageDefault = BC001M3_A533ResidentPackageDefault[0];
            A528SG_LocationId = BC001M3_A528SG_LocationId[0];
            A529SG_OrganisationId = BC001M3_A529SG_OrganisationId[0];
            Z527ResidentPackageId = A527ResidentPackageId;
            sMode96 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1M96( ) ;
            if ( AnyError == 1 )
            {
               RcdFound96 = 0;
               InitializeNonKey1M96( ) ;
            }
            Gx_mode = sMode96;
         }
         else
         {
            RcdFound96 = 0;
            InitializeNonKey1M96( ) ;
            sMode96 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode96;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1M96( ) ;
         if ( RcdFound96 == 0 )
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
         CONFIRM_1M0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1M96( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001M2 */
            pr_default.execute(0, new Object[] {n527ResidentPackageId, A527ResidentPackageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ResidentPackage"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z531ResidentPackageName, BC001M2_A531ResidentPackageName[0]) != 0 ) || ( Z533ResidentPackageDefault != BC001M2_A533ResidentPackageDefault[0] ) || ( Z528SG_LocationId != BC001M2_A528SG_LocationId[0] ) || ( Z529SG_OrganisationId != BC001M2_A529SG_OrganisationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ResidentPackage"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1M96( )
      {
         BeforeValidate1M96( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1M96( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1M96( 0) ;
            CheckOptimisticConcurrency1M96( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1M96( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1M96( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001M7 */
                     pr_default.execute(5, new Object[] {n527ResidentPackageId, A527ResidentPackageId, A531ResidentPackageName, A532ResidentPackageModules, A533ResidentPackageDefault, A528SG_LocationId, A529SG_OrganisationId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentPackage");
                     if ( (pr_default.getStatus(5) == 1) )
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
               Load1M96( ) ;
            }
            EndLevel1M96( ) ;
         }
         CloseExtendedTableCursors1M96( ) ;
      }

      protected void Update1M96( )
      {
         BeforeValidate1M96( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1M96( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1M96( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1M96( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1M96( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001M8 */
                     pr_default.execute(6, new Object[] {A531ResidentPackageName, A532ResidentPackageModules, A533ResidentPackageDefault, A528SG_LocationId, A529SG_OrganisationId, n527ResidentPackageId, A527ResidentPackageId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentPackage");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ResidentPackage"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1M96( ) ;
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
            EndLevel1M96( ) ;
         }
         CloseExtendedTableCursors1M96( ) ;
      }

      protected void DeferredUpdate1M96( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1M96( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1M96( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1M96( ) ;
            AfterConfirm1M96( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1M96( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001M9 */
                  pr_default.execute(7, new Object[] {n527ResidentPackageId, A527ResidentPackageId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentPackage");
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
         sMode96 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1M96( ) ;
         Gx_mode = sMode96;
      }

      protected void OnDeleteControls1M96( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC001M10 */
            pr_default.execute(8, new Object[] {n527ResidentPackageId, A527ResidentPackageId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Resident", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
         }
      }

      protected void EndLevel1M96( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1M96( ) ;
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

      public void ScanKeyStart1M96( )
      {
         /* Scan By routine */
         /* Using cursor BC001M11 */
         pr_default.execute(9, new Object[] {n527ResidentPackageId, A527ResidentPackageId});
         RcdFound96 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound96 = 1;
            A527ResidentPackageId = BC001M11_A527ResidentPackageId[0];
            n527ResidentPackageId = BC001M11_n527ResidentPackageId[0];
            A531ResidentPackageName = BC001M11_A531ResidentPackageName[0];
            A532ResidentPackageModules = BC001M11_A532ResidentPackageModules[0];
            A533ResidentPackageDefault = BC001M11_A533ResidentPackageDefault[0];
            A528SG_LocationId = BC001M11_A528SG_LocationId[0];
            A529SG_OrganisationId = BC001M11_A529SG_OrganisationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1M96( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound96 = 0;
         ScanKeyLoad1M96( ) ;
      }

      protected void ScanKeyLoad1M96( )
      {
         sMode96 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound96 = 1;
            A527ResidentPackageId = BC001M11_A527ResidentPackageId[0];
            n527ResidentPackageId = BC001M11_n527ResidentPackageId[0];
            A531ResidentPackageName = BC001M11_A531ResidentPackageName[0];
            A532ResidentPackageModules = BC001M11_A532ResidentPackageModules[0];
            A533ResidentPackageDefault = BC001M11_A533ResidentPackageDefault[0];
            A528SG_LocationId = BC001M11_A528SG_LocationId[0];
            A529SG_OrganisationId = BC001M11_A529SG_OrganisationId[0];
         }
         Gx_mode = sMode96;
      }

      protected void ScanKeyEnd1M96( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1M96( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1M96( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1M96( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1M96( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1M96( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1M96( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1M96( )
      {
      }

      protected void send_integrity_lvl_hashes1M96( )
      {
      }

      protected void AddRow1M96( )
      {
         VarsToRow96( bcTrn_ResidentPackage) ;
      }

      protected void ReadRow1M96( )
      {
         RowToVars96( bcTrn_ResidentPackage, 1) ;
      }

      protected void InitializeNonKey1M96( )
      {
         A528SG_LocationId = Guid.Empty;
         A529SG_OrganisationId = Guid.Empty;
         A531ResidentPackageName = "";
         A532ResidentPackageModules = "";
         A533ResidentPackageDefault = false;
         Z531ResidentPackageName = "";
         Z533ResidentPackageDefault = false;
         Z528SG_LocationId = Guid.Empty;
         Z529SG_OrganisationId = Guid.Empty;
      }

      protected void InitAll1M96( )
      {
         A527ResidentPackageId = Guid.NewGuid( );
         n527ResidentPackageId = false;
         InitializeNonKey1M96( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A528SG_LocationId = i528SG_LocationId;
         A529SG_OrganisationId = i529SG_OrganisationId;
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

      public void VarsToRow96( SdtTrn_ResidentPackage obj96 )
      {
         obj96.gxTpr_Mode = Gx_mode;
         obj96.gxTpr_Sg_locationid = A528SG_LocationId;
         obj96.gxTpr_Sg_organisationid = A529SG_OrganisationId;
         obj96.gxTpr_Residentpackagename = A531ResidentPackageName;
         obj96.gxTpr_Residentpackagemodules = A532ResidentPackageModules;
         obj96.gxTpr_Residentpackagedefault = A533ResidentPackageDefault;
         obj96.gxTpr_Residentpackageid = A527ResidentPackageId;
         obj96.gxTpr_Residentpackageid_Z = Z527ResidentPackageId;
         obj96.gxTpr_Sg_locationid_Z = Z528SG_LocationId;
         obj96.gxTpr_Sg_organisationid_Z = Z529SG_OrganisationId;
         obj96.gxTpr_Residentpackagename_Z = Z531ResidentPackageName;
         obj96.gxTpr_Residentpackagedefault_Z = Z533ResidentPackageDefault;
         obj96.gxTpr_Residentpackageid_N = (short)(Convert.ToInt16(n527ResidentPackageId));
         obj96.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow96( SdtTrn_ResidentPackage obj96 )
      {
         obj96.gxTpr_Residentpackageid = A527ResidentPackageId;
         return  ;
      }

      public void RowToVars96( SdtTrn_ResidentPackage obj96 ,
                               int forceLoad )
      {
         Gx_mode = obj96.gxTpr_Mode;
         A528SG_LocationId = obj96.gxTpr_Sg_locationid;
         A529SG_OrganisationId = obj96.gxTpr_Sg_organisationid;
         A531ResidentPackageName = obj96.gxTpr_Residentpackagename;
         A532ResidentPackageModules = obj96.gxTpr_Residentpackagemodules;
         A533ResidentPackageDefault = obj96.gxTpr_Residentpackagedefault;
         A527ResidentPackageId = obj96.gxTpr_Residentpackageid;
         n527ResidentPackageId = false;
         Z527ResidentPackageId = obj96.gxTpr_Residentpackageid_Z;
         Z528SG_LocationId = obj96.gxTpr_Sg_locationid_Z;
         Z529SG_OrganisationId = obj96.gxTpr_Sg_organisationid_Z;
         Z531ResidentPackageName = obj96.gxTpr_Residentpackagename_Z;
         Z533ResidentPackageDefault = obj96.gxTpr_Residentpackagedefault_Z;
         n527ResidentPackageId = (bool)(Convert.ToBoolean(obj96.gxTpr_Residentpackageid_N));
         Gx_mode = obj96.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A527ResidentPackageId = (Guid)getParm(obj,0);
         n527ResidentPackageId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1M96( ) ;
         ScanKeyStart1M96( ) ;
         if ( RcdFound96 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z527ResidentPackageId = A527ResidentPackageId;
         }
         ZM1M96( -12) ;
         OnLoadActions1M96( ) ;
         AddRow1M96( ) ;
         ScanKeyEnd1M96( ) ;
         if ( RcdFound96 == 0 )
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
         RowToVars96( bcTrn_ResidentPackage, 0) ;
         ScanKeyStart1M96( ) ;
         if ( RcdFound96 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z527ResidentPackageId = A527ResidentPackageId;
         }
         ZM1M96( -12) ;
         OnLoadActions1M96( ) ;
         AddRow1M96( ) ;
         ScanKeyEnd1M96( ) ;
         if ( RcdFound96 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1M96( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1M96( ) ;
         }
         else
         {
            if ( RcdFound96 == 1 )
            {
               if ( A527ResidentPackageId != Z527ResidentPackageId )
               {
                  A527ResidentPackageId = Z527ResidentPackageId;
                  n527ResidentPackageId = false;
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
                  Update1M96( ) ;
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
                  if ( A527ResidentPackageId != Z527ResidentPackageId )
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
                        Insert1M96( ) ;
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
                        Insert1M96( ) ;
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
         RowToVars96( bcTrn_ResidentPackage, 1) ;
         SaveImpl( ) ;
         VarsToRow96( bcTrn_ResidentPackage) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars96( bcTrn_ResidentPackage, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1M96( ) ;
         AfterTrn( ) ;
         VarsToRow96( bcTrn_ResidentPackage) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow96( bcTrn_ResidentPackage) ;
         }
         else
         {
            SdtTrn_ResidentPackage auxBC = new SdtTrn_ResidentPackage(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A527ResidentPackageId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_ResidentPackage);
               auxBC.Save();
               bcTrn_ResidentPackage.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars96( bcTrn_ResidentPackage, 1) ;
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
         RowToVars96( bcTrn_ResidentPackage, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1M96( ) ;
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
               VarsToRow96( bcTrn_ResidentPackage) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow96( bcTrn_ResidentPackage) ;
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
         RowToVars96( bcTrn_ResidentPackage, 0) ;
         GetKey1M96( ) ;
         if ( RcdFound96 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A527ResidentPackageId != Z527ResidentPackageId )
            {
               A527ResidentPackageId = Z527ResidentPackageId;
               n527ResidentPackageId = false;
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
            if ( A527ResidentPackageId != Z527ResidentPackageId )
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
         context.RollbackDataStores("trn_residentpackage_bc",pr_default);
         VarsToRow96( bcTrn_ResidentPackage) ;
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
         Gx_mode = bcTrn_ResidentPackage.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_ResidentPackage.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_ResidentPackage )
         {
            bcTrn_ResidentPackage = (SdtTrn_ResidentPackage)(sdt);
            if ( StringUtil.StrCmp(bcTrn_ResidentPackage.gxTpr_Mode, "") == 0 )
            {
               bcTrn_ResidentPackage.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow96( bcTrn_ResidentPackage) ;
            }
            else
            {
               RowToVars96( bcTrn_ResidentPackage, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_ResidentPackage.gxTpr_Mode, "") == 0 )
            {
               bcTrn_ResidentPackage.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars96( bcTrn_ResidentPackage, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_ResidentPackage Trn_ResidentPackage_BC
      {
         get {
            return bcTrn_ResidentPackage ;
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
            return "trn_residentpackage_Execute" ;
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
         Z527ResidentPackageId = Guid.Empty;
         A527ResidentPackageId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV34Pgmname = "";
         AV15TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV32Insert_SG_LocationId = Guid.Empty;
         AV33Insert_SG_OrganisationId = Guid.Empty;
         Z531ResidentPackageName = "";
         A531ResidentPackageName = "";
         Z528SG_LocationId = Guid.Empty;
         A528SG_LocationId = Guid.Empty;
         Z529SG_OrganisationId = Guid.Empty;
         A529SG_OrganisationId = Guid.Empty;
         Z532ResidentPackageModules = "";
         A532ResidentPackageModules = "";
         GXt_guid1 = Guid.Empty;
         BC001M5_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         BC001M5_n527ResidentPackageId = new bool[] {false} ;
         BC001M5_A531ResidentPackageName = new string[] {""} ;
         BC001M5_A532ResidentPackageModules = new string[] {""} ;
         BC001M5_A533ResidentPackageDefault = new bool[] {false} ;
         BC001M5_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         BC001M5_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         BC001M4_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         BC001M6_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         BC001M6_n527ResidentPackageId = new bool[] {false} ;
         BC001M3_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         BC001M3_n527ResidentPackageId = new bool[] {false} ;
         BC001M3_A531ResidentPackageName = new string[] {""} ;
         BC001M3_A532ResidentPackageModules = new string[] {""} ;
         BC001M3_A533ResidentPackageDefault = new bool[] {false} ;
         BC001M3_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         BC001M3_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         sMode96 = "";
         BC001M2_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         BC001M2_n527ResidentPackageId = new bool[] {false} ;
         BC001M2_A531ResidentPackageName = new string[] {""} ;
         BC001M2_A532ResidentPackageModules = new string[] {""} ;
         BC001M2_A533ResidentPackageDefault = new bool[] {false} ;
         BC001M2_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         BC001M2_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         BC001M10_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001M10_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001M10_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001M11_A527ResidentPackageId = new Guid[] {Guid.Empty} ;
         BC001M11_n527ResidentPackageId = new bool[] {false} ;
         BC001M11_A531ResidentPackageName = new string[] {""} ;
         BC001M11_A532ResidentPackageModules = new string[] {""} ;
         BC001M11_A533ResidentPackageDefault = new bool[] {false} ;
         BC001M11_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         BC001M11_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         i528SG_LocationId = Guid.Empty;
         i529SG_OrganisationId = Guid.Empty;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_residentpackage_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_residentpackage_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_residentpackage_bc__default(),
            new Object[][] {
                new Object[] {
               BC001M2_A527ResidentPackageId, BC001M2_A531ResidentPackageName, BC001M2_A532ResidentPackageModules, BC001M2_A533ResidentPackageDefault, BC001M2_A528SG_LocationId, BC001M2_A529SG_OrganisationId
               }
               , new Object[] {
               BC001M3_A527ResidentPackageId, BC001M3_A531ResidentPackageName, BC001M3_A532ResidentPackageModules, BC001M3_A533ResidentPackageDefault, BC001M3_A528SG_LocationId, BC001M3_A529SG_OrganisationId
               }
               , new Object[] {
               BC001M4_A528SG_LocationId
               }
               , new Object[] {
               BC001M5_A527ResidentPackageId, BC001M5_A531ResidentPackageName, BC001M5_A532ResidentPackageModules, BC001M5_A533ResidentPackageDefault, BC001M5_A528SG_LocationId, BC001M5_A529SG_OrganisationId
               }
               , new Object[] {
               BC001M6_A527ResidentPackageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001M10_A62ResidentId, BC001M10_A29LocationId, BC001M10_A11OrganisationId
               }
               , new Object[] {
               BC001M11_A527ResidentPackageId, BC001M11_A531ResidentPackageName, BC001M11_A532ResidentPackageModules, BC001M11_A533ResidentPackageDefault, BC001M11_A528SG_LocationId, BC001M11_A529SG_OrganisationId
               }
            }
         );
         Z527ResidentPackageId = Guid.NewGuid( );
         n527ResidentPackageId = false;
         A527ResidentPackageId = Guid.NewGuid( );
         n527ResidentPackageId = false;
         AV34Pgmname = "Trn_ResidentPackage_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121M2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound96 ;
      private int trnEnded ;
      private int AV35GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV34Pgmname ;
      private string sMode96 ;
      private bool returnInSub ;
      private bool Z533ResidentPackageDefault ;
      private bool A533ResidentPackageDefault ;
      private bool n527ResidentPackageId ;
      private string Z532ResidentPackageModules ;
      private string A532ResidentPackageModules ;
      private string Z531ResidentPackageName ;
      private string A531ResidentPackageName ;
      private Guid Z527ResidentPackageId ;
      private Guid A527ResidentPackageId ;
      private Guid AV32Insert_SG_LocationId ;
      private Guid AV33Insert_SG_OrganisationId ;
      private Guid Z528SG_LocationId ;
      private Guid A528SG_LocationId ;
      private Guid Z529SG_OrganisationId ;
      private Guid A529SG_OrganisationId ;
      private Guid GXt_guid1 ;
      private Guid i528SG_LocationId ;
      private Guid i529SG_OrganisationId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001M5_A527ResidentPackageId ;
      private bool[] BC001M5_n527ResidentPackageId ;
      private string[] BC001M5_A531ResidentPackageName ;
      private string[] BC001M5_A532ResidentPackageModules ;
      private bool[] BC001M5_A533ResidentPackageDefault ;
      private Guid[] BC001M5_A528SG_LocationId ;
      private Guid[] BC001M5_A529SG_OrganisationId ;
      private Guid[] BC001M4_A528SG_LocationId ;
      private Guid[] BC001M6_A527ResidentPackageId ;
      private bool[] BC001M6_n527ResidentPackageId ;
      private Guid[] BC001M3_A527ResidentPackageId ;
      private bool[] BC001M3_n527ResidentPackageId ;
      private string[] BC001M3_A531ResidentPackageName ;
      private string[] BC001M3_A532ResidentPackageModules ;
      private bool[] BC001M3_A533ResidentPackageDefault ;
      private Guid[] BC001M3_A528SG_LocationId ;
      private Guid[] BC001M3_A529SG_OrganisationId ;
      private Guid[] BC001M2_A527ResidentPackageId ;
      private bool[] BC001M2_n527ResidentPackageId ;
      private string[] BC001M2_A531ResidentPackageName ;
      private string[] BC001M2_A532ResidentPackageModules ;
      private bool[] BC001M2_A533ResidentPackageDefault ;
      private Guid[] BC001M2_A528SG_LocationId ;
      private Guid[] BC001M2_A529SG_OrganisationId ;
      private Guid[] BC001M10_A62ResidentId ;
      private Guid[] BC001M10_A29LocationId ;
      private Guid[] BC001M10_A11OrganisationId ;
      private Guid[] BC001M11_A527ResidentPackageId ;
      private bool[] BC001M11_n527ResidentPackageId ;
      private string[] BC001M11_A531ResidentPackageName ;
      private string[] BC001M11_A532ResidentPackageModules ;
      private bool[] BC001M11_A533ResidentPackageDefault ;
      private Guid[] BC001M11_A528SG_LocationId ;
      private Guid[] BC001M11_A529SG_OrganisationId ;
      private SdtTrn_ResidentPackage bcTrn_ResidentPackage ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_residentpackage_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_residentpackage_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_residentpackage_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[5])
      ,new UpdateCursor(def[6])
      ,new UpdateCursor(def[7])
      ,new ForEachCursor(def[8])
      ,new ForEachCursor(def[9])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC001M2;
       prmBC001M2 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001M3;
       prmBC001M3 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001M4;
       prmBC001M4 = new Object[] {
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001M5;
       prmBC001M5 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001M6;
       prmBC001M6 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001M7;
       prmBC001M7 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ResidentPackageName",GXType.VarChar,100,0) ,
       new ParDef("ResidentPackageModules",GXType.LongVarChar,2097152,0) ,
       new ParDef("ResidentPackageDefault",GXType.Boolean,4,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001M8;
       prmBC001M8 = new Object[] {
       new ParDef("ResidentPackageName",GXType.VarChar,100,0) ,
       new ParDef("ResidentPackageModules",GXType.LongVarChar,2097152,0) ,
       new ParDef("ResidentPackageDefault",GXType.Boolean,4,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001M9;
       prmBC001M9 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001M10;
       prmBC001M10 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC001M11;
       prmBC001M11 = new Object[] {
       new ParDef("ResidentPackageId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       def= new CursorDef[] {
           new CursorDef("BC001M2", "SELECT ResidentPackageId, ResidentPackageName, ResidentPackageModules, ResidentPackageDefault, SG_LocationId, SG_OrganisationId FROM Trn_ResidentPackage WHERE ResidentPackageId = :ResidentPackageId  FOR UPDATE OF Trn_ResidentPackage",true, GxErrorMask.GX_NOMASK, false, this,prmBC001M2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001M3", "SELECT ResidentPackageId, ResidentPackageName, ResidentPackageModules, ResidentPackageDefault, SG_LocationId, SG_OrganisationId FROM Trn_ResidentPackage WHERE ResidentPackageId = :ResidentPackageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001M3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001M4", "SELECT LocationId AS SG_LocationId FROM Trn_Location WHERE LocationId = :SG_LocationId AND OrganisationId = :SG_OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001M4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001M5", "SELECT TM1.ResidentPackageId, TM1.ResidentPackageName, TM1.ResidentPackageModules, TM1.ResidentPackageDefault, TM1.SG_LocationId AS SG_LocationId, TM1.SG_OrganisationId AS SG_OrganisationId FROM Trn_ResidentPackage TM1 WHERE TM1.ResidentPackageId = :ResidentPackageId ORDER BY TM1.ResidentPackageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001M5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001M6", "SELECT ResidentPackageId FROM Trn_ResidentPackage WHERE ResidentPackageId = :ResidentPackageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001M6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001M7", "SAVEPOINT gxupdate;INSERT INTO Trn_ResidentPackage(ResidentPackageId, ResidentPackageName, ResidentPackageModules, ResidentPackageDefault, SG_LocationId, SG_OrganisationId) VALUES(:ResidentPackageId, :ResidentPackageName, :ResidentPackageModules, :ResidentPackageDefault, :SG_LocationId, :SG_OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001M7)
          ,new CursorDef("BC001M8", "SAVEPOINT gxupdate;UPDATE Trn_ResidentPackage SET ResidentPackageName=:ResidentPackageName, ResidentPackageModules=:ResidentPackageModules, ResidentPackageDefault=:ResidentPackageDefault, SG_LocationId=:SG_LocationId, SG_OrganisationId=:SG_OrganisationId  WHERE ResidentPackageId = :ResidentPackageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001M8)
          ,new CursorDef("BC001M9", "SAVEPOINT gxupdate;DELETE FROM Trn_ResidentPackage  WHERE ResidentPackageId = :ResidentPackageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001M9)
          ,new CursorDef("BC001M10", "SELECT ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ResidentPackageId = :ResidentPackageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001M10,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC001M11", "SELECT TM1.ResidentPackageId, TM1.ResidentPackageName, TM1.ResidentPackageModules, TM1.ResidentPackageDefault, TM1.SG_LocationId AS SG_LocationId, TM1.SG_OrganisationId AS SG_OrganisationId FROM Trn_ResidentPackage TM1 WHERE TM1.ResidentPackageId = :ResidentPackageId ORDER BY TM1.ResidentPackageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001M11,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             ((Guid[]) buf[5])[0] = rslt.getGuid(6);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             ((Guid[]) buf[5])[0] = rslt.getGuid(6);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             ((Guid[]) buf[5])[0] = rslt.getGuid(6);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((Guid[]) buf[4])[0] = rslt.getGuid(5);
             ((Guid[]) buf[5])[0] = rslt.getGuid(6);
             return;
    }
 }

}

}
