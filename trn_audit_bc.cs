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
   public class trn_audit_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_audit_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_audit_bc( IGxContext context )
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
         ReadRow1673( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1673( ) ;
         standaloneModal( ) ;
         AddRow1673( ) ;
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
            E11162 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z371AuditId = A371AuditId;
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

      protected void CONFIRM_160( )
      {
         BeforeValidate1673( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1673( ) ;
            }
            else
            {
               CheckExtendedTable1673( ) ;
               if ( AnyError == 0 )
               {
                  ZM1673( 9) ;
               }
               CloseExtendedTableCursors1673( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12162( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV23Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV24GXV1 = 1;
            while ( AV24GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV24GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "OrganisationId") == 0 )
               {
                  AV13Insert_OrganisationId = StringUtil.StrToGuid( AV14TrnContextAtt.gxTpr_Attributevalue);
               }
               AV24GXV1 = (int)(AV24GXV1+1);
            }
         }
      }

      protected void E11162( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1673( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z372AuditDate = A372AuditDate;
            Z373AuditTableName = A373AuditTableName;
            Z375AuditShortDescription = A375AuditShortDescription;
            Z376GAMUserId = A376GAMUserId;
            Z377AuditUserName = A377AuditUserName;
            Z378AuditAction = A378AuditAction;
            Z11OrganisationId = A11OrganisationId;
            Z491AuditTableDiaplayName = A491AuditTableDiaplayName;
            Z419AuditDisplayDescription = A419AuditDisplayDescription;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z491AuditTableDiaplayName = A491AuditTableDiaplayName;
            Z419AuditDisplayDescription = A419AuditDisplayDescription;
         }
         if ( GX_JID == -8 )
         {
            Z371AuditId = A371AuditId;
            Z372AuditDate = A372AuditDate;
            Z373AuditTableName = A373AuditTableName;
            Z374AuditDescription = A374AuditDescription;
            Z375AuditShortDescription = A375AuditShortDescription;
            Z376GAMUserId = A376GAMUserId;
            Z377AuditUserName = A377AuditUserName;
            Z378AuditAction = A378AuditAction;
            Z11OrganisationId = A11OrganisationId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV23Pgmname = "Trn_Audit_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A371AuditId) )
         {
            A371AuditId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1673( )
      {
         /* Using cursor BC00165 */
         pr_default.execute(3, new Object[] {A371AuditId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound73 = 1;
            A372AuditDate = BC00165_A372AuditDate[0];
            A373AuditTableName = BC00165_A373AuditTableName[0];
            A374AuditDescription = BC00165_A374AuditDescription[0];
            A375AuditShortDescription = BC00165_A375AuditShortDescription[0];
            A376GAMUserId = BC00165_A376GAMUserId[0];
            A377AuditUserName = BC00165_A377AuditUserName[0];
            A378AuditAction = BC00165_A378AuditAction[0];
            A11OrganisationId = BC00165_A11OrganisationId[0];
            n11OrganisationId = BC00165_n11OrganisationId[0];
            ZM1673( -8) ;
         }
         pr_default.close(3);
         OnLoadActions1673( ) ;
      }

      protected void OnLoadActions1673( )
      {
         A491AuditTableDiaplayName = StringUtil.Substring( A373AuditTableName, 5, -1);
         A419AuditDisplayDescription = StringUtil.Substring( A375AuditShortDescription, 161, 240);
      }

      protected void CheckExtendedTable1673( )
      {
         standaloneModal( ) ;
         A491AuditTableDiaplayName = StringUtil.Substring( A373AuditTableName, 5, -1);
         A419AuditDisplayDescription = StringUtil.Substring( A375AuditShortDescription, 161, 240);
         /* Using cursor BC00164 */
         pr_default.execute(2, new Object[] {n11OrganisationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Organisations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1673( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1673( )
      {
         /* Using cursor BC00166 */
         pr_default.execute(4, new Object[] {A371AuditId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound73 = 1;
         }
         else
         {
            RcdFound73 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00163 */
         pr_default.execute(1, new Object[] {A371AuditId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1673( 8) ;
            RcdFound73 = 1;
            A371AuditId = BC00163_A371AuditId[0];
            A372AuditDate = BC00163_A372AuditDate[0];
            A373AuditTableName = BC00163_A373AuditTableName[0];
            A374AuditDescription = BC00163_A374AuditDescription[0];
            A375AuditShortDescription = BC00163_A375AuditShortDescription[0];
            A376GAMUserId = BC00163_A376GAMUserId[0];
            A377AuditUserName = BC00163_A377AuditUserName[0];
            A378AuditAction = BC00163_A378AuditAction[0];
            A11OrganisationId = BC00163_A11OrganisationId[0];
            n11OrganisationId = BC00163_n11OrganisationId[0];
            Z371AuditId = A371AuditId;
            sMode73 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1673( ) ;
            if ( AnyError == 1 )
            {
               RcdFound73 = 0;
               InitializeNonKey1673( ) ;
            }
            Gx_mode = sMode73;
         }
         else
         {
            RcdFound73 = 0;
            InitializeNonKey1673( ) ;
            sMode73 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode73;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1673( ) ;
         if ( RcdFound73 == 0 )
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
         CONFIRM_160( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1673( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00162 */
            pr_default.execute(0, new Object[] {A371AuditId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Audit"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z372AuditDate != BC00162_A372AuditDate[0] ) || ( StringUtil.StrCmp(Z373AuditTableName, BC00162_A373AuditTableName[0]) != 0 ) || ( StringUtil.StrCmp(Z375AuditShortDescription, BC00162_A375AuditShortDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z376GAMUserId, BC00162_A376GAMUserId[0]) != 0 ) || ( StringUtil.StrCmp(Z377AuditUserName, BC00162_A377AuditUserName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z378AuditAction, BC00162_A378AuditAction[0]) != 0 ) || ( Z11OrganisationId != BC00162_A11OrganisationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Audit"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1673( )
      {
         BeforeValidate1673( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1673( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1673( 0) ;
            CheckOptimisticConcurrency1673( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1673( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1673( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00167 */
                     pr_default.execute(5, new Object[] {A371AuditId, A372AuditDate, A373AuditTableName, A374AuditDescription, A375AuditShortDescription, A376GAMUserId, A377AuditUserName, A378AuditAction, n11OrganisationId, A11OrganisationId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Audit");
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
               Load1673( ) ;
            }
            EndLevel1673( ) ;
         }
         CloseExtendedTableCursors1673( ) ;
      }

      protected void Update1673( )
      {
         BeforeValidate1673( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1673( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1673( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1673( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1673( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00168 */
                     pr_default.execute(6, new Object[] {A372AuditDate, A373AuditTableName, A374AuditDescription, A375AuditShortDescription, A376GAMUserId, A377AuditUserName, A378AuditAction, n11OrganisationId, A11OrganisationId, A371AuditId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Audit");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Audit"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1673( ) ;
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
            EndLevel1673( ) ;
         }
         CloseExtendedTableCursors1673( ) ;
      }

      protected void DeferredUpdate1673( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1673( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1673( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1673( ) ;
            AfterConfirm1673( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1673( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00169 */
                  pr_default.execute(7, new Object[] {A371AuditId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Audit");
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
         sMode73 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1673( ) ;
         Gx_mode = sMode73;
      }

      protected void OnDeleteControls1673( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A491AuditTableDiaplayName = StringUtil.Substring( A373AuditTableName, 5, -1);
            A419AuditDisplayDescription = StringUtil.Substring( A375AuditShortDescription, 161, 240);
         }
      }

      protected void EndLevel1673( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1673( ) ;
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

      public void ScanKeyStart1673( )
      {
         /* Scan By routine */
         /* Using cursor BC001610 */
         pr_default.execute(8, new Object[] {A371AuditId});
         RcdFound73 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound73 = 1;
            A371AuditId = BC001610_A371AuditId[0];
            A372AuditDate = BC001610_A372AuditDate[0];
            A373AuditTableName = BC001610_A373AuditTableName[0];
            A374AuditDescription = BC001610_A374AuditDescription[0];
            A375AuditShortDescription = BC001610_A375AuditShortDescription[0];
            A376GAMUserId = BC001610_A376GAMUserId[0];
            A377AuditUserName = BC001610_A377AuditUserName[0];
            A378AuditAction = BC001610_A378AuditAction[0];
            A11OrganisationId = BC001610_A11OrganisationId[0];
            n11OrganisationId = BC001610_n11OrganisationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1673( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound73 = 0;
         ScanKeyLoad1673( ) ;
      }

      protected void ScanKeyLoad1673( )
      {
         sMode73 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound73 = 1;
            A371AuditId = BC001610_A371AuditId[0];
            A372AuditDate = BC001610_A372AuditDate[0];
            A373AuditTableName = BC001610_A373AuditTableName[0];
            A374AuditDescription = BC001610_A374AuditDescription[0];
            A375AuditShortDescription = BC001610_A375AuditShortDescription[0];
            A376GAMUserId = BC001610_A376GAMUserId[0];
            A377AuditUserName = BC001610_A377AuditUserName[0];
            A378AuditAction = BC001610_A378AuditAction[0];
            A11OrganisationId = BC001610_A11OrganisationId[0];
            n11OrganisationId = BC001610_n11OrganisationId[0];
         }
         Gx_mode = sMode73;
      }

      protected void ScanKeyEnd1673( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1673( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1673( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1673( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1673( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1673( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1673( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1673( )
      {
      }

      protected void send_integrity_lvl_hashes1673( )
      {
      }

      protected void AddRow1673( )
      {
         VarsToRow73( bcTrn_Audit) ;
      }

      protected void ReadRow1673( )
      {
         RowToVars73( bcTrn_Audit, 1) ;
      }

      protected void InitializeNonKey1673( )
      {
         A419AuditDisplayDescription = "";
         A491AuditTableDiaplayName = "";
         A372AuditDate = (DateTime)(DateTime.MinValue);
         A373AuditTableName = "";
         A374AuditDescription = "";
         A375AuditShortDescription = "";
         A376GAMUserId = "";
         A377AuditUserName = "";
         A378AuditAction = "";
         A11OrganisationId = Guid.Empty;
         n11OrganisationId = false;
         Z372AuditDate = (DateTime)(DateTime.MinValue);
         Z373AuditTableName = "";
         Z375AuditShortDescription = "";
         Z376GAMUserId = "";
         Z377AuditUserName = "";
         Z378AuditAction = "";
         Z11OrganisationId = Guid.Empty;
      }

      protected void InitAll1673( )
      {
         A371AuditId = Guid.NewGuid( );
         InitializeNonKey1673( ) ;
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

      public void VarsToRow73( SdtTrn_Audit obj73 )
      {
         obj73.gxTpr_Mode = Gx_mode;
         obj73.gxTpr_Auditdisplaydescription = A419AuditDisplayDescription;
         obj73.gxTpr_Audittablediaplayname = A491AuditTableDiaplayName;
         obj73.gxTpr_Auditdate = A372AuditDate;
         obj73.gxTpr_Audittablename = A373AuditTableName;
         obj73.gxTpr_Auditdescription = A374AuditDescription;
         obj73.gxTpr_Auditshortdescription = A375AuditShortDescription;
         obj73.gxTpr_Gamuserid = A376GAMUserId;
         obj73.gxTpr_Auditusername = A377AuditUserName;
         obj73.gxTpr_Auditaction = A378AuditAction;
         obj73.gxTpr_Organisationid = A11OrganisationId;
         obj73.gxTpr_Auditid = A371AuditId;
         obj73.gxTpr_Auditid_Z = Z371AuditId;
         obj73.gxTpr_Auditdate_Z = Z372AuditDate;
         obj73.gxTpr_Audittablename_Z = Z373AuditTableName;
         obj73.gxTpr_Audittablediaplayname_Z = Z491AuditTableDiaplayName;
         obj73.gxTpr_Auditshortdescription_Z = Z375AuditShortDescription;
         obj73.gxTpr_Gamuserid_Z = Z376GAMUserId;
         obj73.gxTpr_Auditusername_Z = Z377AuditUserName;
         obj73.gxTpr_Auditaction_Z = Z378AuditAction;
         obj73.gxTpr_Auditdisplaydescription_Z = Z419AuditDisplayDescription;
         obj73.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj73.gxTpr_Organisationid_N = (short)(Convert.ToInt16(n11OrganisationId));
         obj73.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow73( SdtTrn_Audit obj73 )
      {
         obj73.gxTpr_Auditid = A371AuditId;
         return  ;
      }

      public void RowToVars73( SdtTrn_Audit obj73 ,
                               int forceLoad )
      {
         Gx_mode = obj73.gxTpr_Mode;
         A419AuditDisplayDescription = obj73.gxTpr_Auditdisplaydescription;
         A491AuditTableDiaplayName = obj73.gxTpr_Audittablediaplayname;
         A372AuditDate = obj73.gxTpr_Auditdate;
         A373AuditTableName = obj73.gxTpr_Audittablename;
         A374AuditDescription = obj73.gxTpr_Auditdescription;
         A375AuditShortDescription = obj73.gxTpr_Auditshortdescription;
         A376GAMUserId = obj73.gxTpr_Gamuserid;
         A377AuditUserName = obj73.gxTpr_Auditusername;
         A378AuditAction = obj73.gxTpr_Auditaction;
         A11OrganisationId = obj73.gxTpr_Organisationid;
         n11OrganisationId = false;
         A371AuditId = obj73.gxTpr_Auditid;
         Z371AuditId = obj73.gxTpr_Auditid_Z;
         Z372AuditDate = obj73.gxTpr_Auditdate_Z;
         Z373AuditTableName = obj73.gxTpr_Audittablename_Z;
         Z491AuditTableDiaplayName = obj73.gxTpr_Audittablediaplayname_Z;
         Z375AuditShortDescription = obj73.gxTpr_Auditshortdescription_Z;
         Z376GAMUserId = obj73.gxTpr_Gamuserid_Z;
         Z377AuditUserName = obj73.gxTpr_Auditusername_Z;
         Z378AuditAction = obj73.gxTpr_Auditaction_Z;
         Z419AuditDisplayDescription = obj73.gxTpr_Auditdisplaydescription_Z;
         Z11OrganisationId = obj73.gxTpr_Organisationid_Z;
         n11OrganisationId = (bool)(Convert.ToBoolean(obj73.gxTpr_Organisationid_N));
         Gx_mode = obj73.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A371AuditId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1673( ) ;
         ScanKeyStart1673( ) ;
         if ( RcdFound73 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z371AuditId = A371AuditId;
         }
         ZM1673( -8) ;
         OnLoadActions1673( ) ;
         AddRow1673( ) ;
         ScanKeyEnd1673( ) ;
         if ( RcdFound73 == 0 )
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
         RowToVars73( bcTrn_Audit, 0) ;
         ScanKeyStart1673( ) ;
         if ( RcdFound73 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z371AuditId = A371AuditId;
         }
         ZM1673( -8) ;
         OnLoadActions1673( ) ;
         AddRow1673( ) ;
         ScanKeyEnd1673( ) ;
         if ( RcdFound73 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1673( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1673( ) ;
         }
         else
         {
            if ( RcdFound73 == 1 )
            {
               if ( A371AuditId != Z371AuditId )
               {
                  A371AuditId = Z371AuditId;
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
                  Update1673( ) ;
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
                  if ( A371AuditId != Z371AuditId )
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
                        Insert1673( ) ;
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
                        Insert1673( ) ;
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
         RowToVars73( bcTrn_Audit, 1) ;
         SaveImpl( ) ;
         VarsToRow73( bcTrn_Audit) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars73( bcTrn_Audit, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1673( ) ;
         AfterTrn( ) ;
         VarsToRow73( bcTrn_Audit) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow73( bcTrn_Audit) ;
         }
         else
         {
            SdtTrn_Audit auxBC = new SdtTrn_Audit(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A371AuditId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Audit);
               auxBC.Save();
               bcTrn_Audit.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars73( bcTrn_Audit, 1) ;
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
         RowToVars73( bcTrn_Audit, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1673( ) ;
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
               VarsToRow73( bcTrn_Audit) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow73( bcTrn_Audit) ;
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
         RowToVars73( bcTrn_Audit, 0) ;
         GetKey1673( ) ;
         if ( RcdFound73 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A371AuditId != Z371AuditId )
            {
               A371AuditId = Z371AuditId;
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
            if ( A371AuditId != Z371AuditId )
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
         context.RollbackDataStores("trn_audit_bc",pr_default);
         VarsToRow73( bcTrn_Audit) ;
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
         Gx_mode = bcTrn_Audit.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Audit.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Audit )
         {
            bcTrn_Audit = (SdtTrn_Audit)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Audit.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Audit.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow73( bcTrn_Audit) ;
            }
            else
            {
               RowToVars73( bcTrn_Audit, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Audit.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Audit.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars73( bcTrn_Audit, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Audit Trn_Audit_BC
      {
         get {
            return bcTrn_Audit ;
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
            return "trn_audit_Execute" ;
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
         Z371AuditId = Guid.Empty;
         A371AuditId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV23Pgmname = "";
         AV14TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV13Insert_OrganisationId = Guid.Empty;
         Z372AuditDate = (DateTime)(DateTime.MinValue);
         A372AuditDate = (DateTime)(DateTime.MinValue);
         Z373AuditTableName = "";
         A373AuditTableName = "";
         Z375AuditShortDescription = "";
         A375AuditShortDescription = "";
         Z376GAMUserId = "";
         A376GAMUserId = "";
         Z377AuditUserName = "";
         A377AuditUserName = "";
         Z378AuditAction = "";
         A378AuditAction = "";
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         Z491AuditTableDiaplayName = "";
         A491AuditTableDiaplayName = "";
         Z419AuditDisplayDescription = "";
         A419AuditDisplayDescription = "";
         Z374AuditDescription = "";
         A374AuditDescription = "";
         BC00165_A371AuditId = new Guid[] {Guid.Empty} ;
         BC00165_A372AuditDate = new DateTime[] {DateTime.MinValue} ;
         BC00165_A373AuditTableName = new string[] {""} ;
         BC00165_A374AuditDescription = new string[] {""} ;
         BC00165_A375AuditShortDescription = new string[] {""} ;
         BC00165_A376GAMUserId = new string[] {""} ;
         BC00165_A377AuditUserName = new string[] {""} ;
         BC00165_A378AuditAction = new string[] {""} ;
         BC00165_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00165_n11OrganisationId = new bool[] {false} ;
         BC00164_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00164_n11OrganisationId = new bool[] {false} ;
         BC00166_A371AuditId = new Guid[] {Guid.Empty} ;
         BC00163_A371AuditId = new Guid[] {Guid.Empty} ;
         BC00163_A372AuditDate = new DateTime[] {DateTime.MinValue} ;
         BC00163_A373AuditTableName = new string[] {""} ;
         BC00163_A374AuditDescription = new string[] {""} ;
         BC00163_A375AuditShortDescription = new string[] {""} ;
         BC00163_A376GAMUserId = new string[] {""} ;
         BC00163_A377AuditUserName = new string[] {""} ;
         BC00163_A378AuditAction = new string[] {""} ;
         BC00163_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00163_n11OrganisationId = new bool[] {false} ;
         sMode73 = "";
         BC00162_A371AuditId = new Guid[] {Guid.Empty} ;
         BC00162_A372AuditDate = new DateTime[] {DateTime.MinValue} ;
         BC00162_A373AuditTableName = new string[] {""} ;
         BC00162_A374AuditDescription = new string[] {""} ;
         BC00162_A375AuditShortDescription = new string[] {""} ;
         BC00162_A376GAMUserId = new string[] {""} ;
         BC00162_A377AuditUserName = new string[] {""} ;
         BC00162_A378AuditAction = new string[] {""} ;
         BC00162_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00162_n11OrganisationId = new bool[] {false} ;
         BC001610_A371AuditId = new Guid[] {Guid.Empty} ;
         BC001610_A372AuditDate = new DateTime[] {DateTime.MinValue} ;
         BC001610_A373AuditTableName = new string[] {""} ;
         BC001610_A374AuditDescription = new string[] {""} ;
         BC001610_A375AuditShortDescription = new string[] {""} ;
         BC001610_A376GAMUserId = new string[] {""} ;
         BC001610_A377AuditUserName = new string[] {""} ;
         BC001610_A378AuditAction = new string[] {""} ;
         BC001610_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001610_n11OrganisationId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_audit_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_audit_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_audit_bc__default(),
            new Object[][] {
                new Object[] {
               BC00162_A371AuditId, BC00162_A372AuditDate, BC00162_A373AuditTableName, BC00162_A374AuditDescription, BC00162_A375AuditShortDescription, BC00162_A376GAMUserId, BC00162_A377AuditUserName, BC00162_A378AuditAction, BC00162_A11OrganisationId, BC00162_n11OrganisationId
               }
               , new Object[] {
               BC00163_A371AuditId, BC00163_A372AuditDate, BC00163_A373AuditTableName, BC00163_A374AuditDescription, BC00163_A375AuditShortDescription, BC00163_A376GAMUserId, BC00163_A377AuditUserName, BC00163_A378AuditAction, BC00163_A11OrganisationId, BC00163_n11OrganisationId
               }
               , new Object[] {
               BC00164_A11OrganisationId
               }
               , new Object[] {
               BC00165_A371AuditId, BC00165_A372AuditDate, BC00165_A373AuditTableName, BC00165_A374AuditDescription, BC00165_A375AuditShortDescription, BC00165_A376GAMUserId, BC00165_A377AuditUserName, BC00165_A378AuditAction, BC00165_A11OrganisationId, BC00165_n11OrganisationId
               }
               , new Object[] {
               BC00166_A371AuditId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001610_A371AuditId, BC001610_A372AuditDate, BC001610_A373AuditTableName, BC001610_A374AuditDescription, BC001610_A375AuditShortDescription, BC001610_A376GAMUserId, BC001610_A377AuditUserName, BC001610_A378AuditAction, BC001610_A11OrganisationId, BC001610_n11OrganisationId
               }
            }
         );
         Z371AuditId = Guid.NewGuid( );
         A371AuditId = Guid.NewGuid( );
         AV23Pgmname = "Trn_Audit_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12162 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound73 ;
      private int trnEnded ;
      private int AV24GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV23Pgmname ;
      private string Z376GAMUserId ;
      private string A376GAMUserId ;
      private string sMode73 ;
      private DateTime Z372AuditDate ;
      private DateTime A372AuditDate ;
      private bool returnInSub ;
      private bool n11OrganisationId ;
      private bool Gx_longc ;
      private string Z374AuditDescription ;
      private string A374AuditDescription ;
      private string Z373AuditTableName ;
      private string A373AuditTableName ;
      private string Z375AuditShortDescription ;
      private string A375AuditShortDescription ;
      private string Z377AuditUserName ;
      private string A377AuditUserName ;
      private string Z378AuditAction ;
      private string A378AuditAction ;
      private string Z491AuditTableDiaplayName ;
      private string A491AuditTableDiaplayName ;
      private string Z419AuditDisplayDescription ;
      private string A419AuditDisplayDescription ;
      private Guid Z371AuditId ;
      private Guid A371AuditId ;
      private Guid AV13Insert_OrganisationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00165_A371AuditId ;
      private DateTime[] BC00165_A372AuditDate ;
      private string[] BC00165_A373AuditTableName ;
      private string[] BC00165_A374AuditDescription ;
      private string[] BC00165_A375AuditShortDescription ;
      private string[] BC00165_A376GAMUserId ;
      private string[] BC00165_A377AuditUserName ;
      private string[] BC00165_A378AuditAction ;
      private Guid[] BC00165_A11OrganisationId ;
      private bool[] BC00165_n11OrganisationId ;
      private Guid[] BC00164_A11OrganisationId ;
      private bool[] BC00164_n11OrganisationId ;
      private Guid[] BC00166_A371AuditId ;
      private Guid[] BC00163_A371AuditId ;
      private DateTime[] BC00163_A372AuditDate ;
      private string[] BC00163_A373AuditTableName ;
      private string[] BC00163_A374AuditDescription ;
      private string[] BC00163_A375AuditShortDescription ;
      private string[] BC00163_A376GAMUserId ;
      private string[] BC00163_A377AuditUserName ;
      private string[] BC00163_A378AuditAction ;
      private Guid[] BC00163_A11OrganisationId ;
      private bool[] BC00163_n11OrganisationId ;
      private Guid[] BC00162_A371AuditId ;
      private DateTime[] BC00162_A372AuditDate ;
      private string[] BC00162_A373AuditTableName ;
      private string[] BC00162_A374AuditDescription ;
      private string[] BC00162_A375AuditShortDescription ;
      private string[] BC00162_A376GAMUserId ;
      private string[] BC00162_A377AuditUserName ;
      private string[] BC00162_A378AuditAction ;
      private Guid[] BC00162_A11OrganisationId ;
      private bool[] BC00162_n11OrganisationId ;
      private Guid[] BC001610_A371AuditId ;
      private DateTime[] BC001610_A372AuditDate ;
      private string[] BC001610_A373AuditTableName ;
      private string[] BC001610_A374AuditDescription ;
      private string[] BC001610_A375AuditShortDescription ;
      private string[] BC001610_A376GAMUserId ;
      private string[] BC001610_A377AuditUserName ;
      private string[] BC001610_A378AuditAction ;
      private Guid[] BC001610_A11OrganisationId ;
      private bool[] BC001610_n11OrganisationId ;
      private SdtTrn_Audit bcTrn_Audit ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_audit_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_audit_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_audit_bc__default : DataStoreHelperBase, IDataStoreHelper
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
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC00162;
       prmBC00162 = new Object[] {
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00163;
       prmBC00163 = new Object[] {
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00164;
       prmBC00164 = new Object[] {
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00165;
       prmBC00165 = new Object[] {
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00166;
       prmBC00166 = new Object[] {
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00167;
       prmBC00167 = new Object[] {
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AuditDate",GXType.DateTime,8,5) ,
       new ParDef("AuditTableName",GXType.VarChar,100,0) ,
       new ParDef("AuditDescription",GXType.LongVarChar,2097152,0) ,
       new ParDef("AuditShortDescription",GXType.VarChar,400,0) ,
       new ParDef("GAMUserId",GXType.Char,40,0) ,
       new ParDef("AuditUserName",GXType.VarChar,100,0) ,
       new ParDef("AuditAction",GXType.VarChar,40,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00168;
       prmBC00168 = new Object[] {
       new ParDef("AuditDate",GXType.DateTime,8,5) ,
       new ParDef("AuditTableName",GXType.VarChar,100,0) ,
       new ParDef("AuditDescription",GXType.LongVarChar,2097152,0) ,
       new ParDef("AuditShortDescription",GXType.VarChar,400,0) ,
       new ParDef("GAMUserId",GXType.Char,40,0) ,
       new ParDef("AuditUserName",GXType.VarChar,100,0) ,
       new ParDef("AuditAction",GXType.VarChar,40,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00169;
       prmBC00169 = new Object[] {
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001610;
       prmBC001610 = new Object[] {
       new ParDef("AuditId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC00162", "SELECT AuditId, AuditDate, AuditTableName, AuditDescription, AuditShortDescription, GAMUserId, AuditUserName, AuditAction, OrganisationId FROM Trn_Audit WHERE AuditId = :AuditId  FOR UPDATE OF Trn_Audit",true, GxErrorMask.GX_NOMASK, false, this,prmBC00162,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00163", "SELECT AuditId, AuditDate, AuditTableName, AuditDescription, AuditShortDescription, GAMUserId, AuditUserName, AuditAction, OrganisationId FROM Trn_Audit WHERE AuditId = :AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00163,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00164", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00164,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00165", "SELECT TM1.AuditId, TM1.AuditDate, TM1.AuditTableName, TM1.AuditDescription, TM1.AuditShortDescription, TM1.GAMUserId, TM1.AuditUserName, TM1.AuditAction, TM1.OrganisationId FROM Trn_Audit TM1 WHERE TM1.AuditId = :AuditId ORDER BY TM1.AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00165,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00166", "SELECT AuditId FROM Trn_Audit WHERE AuditId = :AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00166,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00167", "SAVEPOINT gxupdate;INSERT INTO Trn_Audit(AuditId, AuditDate, AuditTableName, AuditDescription, AuditShortDescription, GAMUserId, AuditUserName, AuditAction, OrganisationId) VALUES(:AuditId, :AuditDate, :AuditTableName, :AuditDescription, :AuditShortDescription, :GAMUserId, :AuditUserName, :AuditAction, :OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00167)
          ,new CursorDef("BC00168", "SAVEPOINT gxupdate;UPDATE Trn_Audit SET AuditDate=:AuditDate, AuditTableName=:AuditTableName, AuditDescription=:AuditDescription, AuditShortDescription=:AuditShortDescription, GAMUserId=:GAMUserId, AuditUserName=:AuditUserName, AuditAction=:AuditAction, OrganisationId=:OrganisationId  WHERE AuditId = :AuditId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00168)
          ,new CursorDef("BC00169", "SAVEPOINT gxupdate;DELETE FROM Trn_Audit  WHERE AuditId = :AuditId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00169)
          ,new CursorDef("BC001610", "SELECT TM1.AuditId, TM1.AuditDate, TM1.AuditTableName, TM1.AuditDescription, TM1.AuditShortDescription, TM1.GAMUserId, TM1.AuditUserName, TM1.AuditAction, TM1.OrganisationId FROM Trn_Audit TM1 WHERE TM1.AuditId = :AuditId ORDER BY TM1.AuditId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001610,100, GxCacheFrequency.OFF ,true,false )
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
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 40);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((Guid[]) buf[8])[0] = rslt.getGuid(9);
             ((bool[]) buf[9])[0] = rslt.wasNull(9);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 40);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((Guid[]) buf[8])[0] = rslt.getGuid(9);
             ((bool[]) buf[9])[0] = rslt.wasNull(9);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 40);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((Guid[]) buf[8])[0] = rslt.getGuid(9);
             ((bool[]) buf[9])[0] = rslt.wasNull(9);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 40);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((Guid[]) buf[8])[0] = rslt.getGuid(9);
             ((bool[]) buf[9])[0] = rslt.wasNull(9);
             return;
    }
 }

}

}
