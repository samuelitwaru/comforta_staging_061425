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
   public class trn_preferredagbsupplier_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_preferredagbsupplier_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_preferredagbsupplier_bc( IGxContext context )
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
         ReadRow1774( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1774( ) ;
         standaloneModal( ) ;
         AddRow1774( ) ;
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
               Z384PreferredAgbSupplierId = A384PreferredAgbSupplierId;
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

      protected void CONFIRM_170( )
      {
         BeforeValidate1774( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1774( ) ;
            }
            else
            {
               CheckExtendedTable1774( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1774( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1774( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z386PreferredAgbOrganisationId = A386PreferredAgbOrganisationId;
            Z381PreferredSupplierAgbId = A381PreferredSupplierAgbId;
         }
         if ( GX_JID == -6 )
         {
            Z384PreferredAgbSupplierId = A384PreferredAgbSupplierId;
            Z386PreferredAgbOrganisationId = A386PreferredAgbOrganisationId;
            Z381PreferredSupplierAgbId = A381PreferredSupplierAgbId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A384PreferredAgbSupplierId) )
         {
            A384PreferredAgbSupplierId = Guid.NewGuid( );
         }
         GXt_guid1 = A386PreferredAgbOrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         A386PreferredAgbOrganisationId = GXt_guid1;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1774( )
      {
         /* Using cursor BC00174 */
         pr_default.execute(2, new Object[] {A384PreferredAgbSupplierId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound74 = 1;
            A386PreferredAgbOrganisationId = BC00174_A386PreferredAgbOrganisationId[0];
            A381PreferredSupplierAgbId = BC00174_A381PreferredSupplierAgbId[0];
            ZM1774( -6) ;
         }
         pr_default.close(2);
         OnLoadActions1774( ) ;
      }

      protected void OnLoadActions1774( )
      {
      }

      protected void CheckExtendedTable1774( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1774( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1774( )
      {
         /* Using cursor BC00175 */
         pr_default.execute(3, new Object[] {A384PreferredAgbSupplierId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound74 = 1;
         }
         else
         {
            RcdFound74 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00173 */
         pr_default.execute(1, new Object[] {A384PreferredAgbSupplierId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1774( 6) ;
            RcdFound74 = 1;
            A384PreferredAgbSupplierId = BC00173_A384PreferredAgbSupplierId[0];
            A386PreferredAgbOrganisationId = BC00173_A386PreferredAgbOrganisationId[0];
            A381PreferredSupplierAgbId = BC00173_A381PreferredSupplierAgbId[0];
            Z384PreferredAgbSupplierId = A384PreferredAgbSupplierId;
            sMode74 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1774( ) ;
            if ( AnyError == 1 )
            {
               RcdFound74 = 0;
               InitializeNonKey1774( ) ;
            }
            Gx_mode = sMode74;
         }
         else
         {
            RcdFound74 = 0;
            InitializeNonKey1774( ) ;
            sMode74 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode74;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1774( ) ;
         if ( RcdFound74 == 0 )
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
         CONFIRM_170( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1774( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00172 */
            pr_default.execute(0, new Object[] {A384PreferredAgbSupplierId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_PreferredAgbSupplier"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z386PreferredAgbOrganisationId != BC00172_A386PreferredAgbOrganisationId[0] ) || ( Z381PreferredSupplierAgbId != BC00172_A381PreferredSupplierAgbId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_PreferredAgbSupplier"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1774( )
      {
         BeforeValidate1774( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1774( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1774( 0) ;
            CheckOptimisticConcurrency1774( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1774( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1774( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00176 */
                     pr_default.execute(4, new Object[] {A384PreferredAgbSupplierId, A386PreferredAgbOrganisationId, A381PreferredSupplierAgbId});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_PreferredAgbSupplier");
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
               Load1774( ) ;
            }
            EndLevel1774( ) ;
         }
         CloseExtendedTableCursors1774( ) ;
      }

      protected void Update1774( )
      {
         BeforeValidate1774( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1774( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1774( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1774( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1774( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00177 */
                     pr_default.execute(5, new Object[] {A386PreferredAgbOrganisationId, A381PreferredSupplierAgbId, A384PreferredAgbSupplierId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_PreferredAgbSupplier");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_PreferredAgbSupplier"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1774( ) ;
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
            EndLevel1774( ) ;
         }
         CloseExtendedTableCursors1774( ) ;
      }

      protected void DeferredUpdate1774( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1774( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1774( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1774( ) ;
            AfterConfirm1774( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1774( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00178 */
                  pr_default.execute(6, new Object[] {A384PreferredAgbSupplierId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_PreferredAgbSupplier");
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
         sMode74 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1774( ) ;
         Gx_mode = sMode74;
      }

      protected void OnDeleteControls1774( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1774( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1774( ) ;
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

      public void ScanKeyStart1774( )
      {
         /* Using cursor BC00179 */
         pr_default.execute(7, new Object[] {A384PreferredAgbSupplierId});
         RcdFound74 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound74 = 1;
            A384PreferredAgbSupplierId = BC00179_A384PreferredAgbSupplierId[0];
            A386PreferredAgbOrganisationId = BC00179_A386PreferredAgbOrganisationId[0];
            A381PreferredSupplierAgbId = BC00179_A381PreferredSupplierAgbId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1774( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound74 = 0;
         ScanKeyLoad1774( ) ;
      }

      protected void ScanKeyLoad1774( )
      {
         sMode74 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound74 = 1;
            A384PreferredAgbSupplierId = BC00179_A384PreferredAgbSupplierId[0];
            A386PreferredAgbOrganisationId = BC00179_A386PreferredAgbOrganisationId[0];
            A381PreferredSupplierAgbId = BC00179_A381PreferredSupplierAgbId[0];
         }
         Gx_mode = sMode74;
      }

      protected void ScanKeyEnd1774( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm1774( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1774( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1774( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1774( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1774( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1774( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1774( )
      {
      }

      protected void send_integrity_lvl_hashes1774( )
      {
      }

      protected void AddRow1774( )
      {
         VarsToRow74( bcTrn_PreferredAgbSupplier) ;
      }

      protected void ReadRow1774( )
      {
         RowToVars74( bcTrn_PreferredAgbSupplier, 1) ;
      }

      protected void InitializeNonKey1774( )
      {
         A386PreferredAgbOrganisationId = Guid.Empty;
         A381PreferredSupplierAgbId = Guid.Empty;
         Z386PreferredAgbOrganisationId = Guid.Empty;
         Z381PreferredSupplierAgbId = Guid.Empty;
      }

      protected void InitAll1774( )
      {
         A384PreferredAgbSupplierId = Guid.NewGuid( );
         InitializeNonKey1774( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A386PreferredAgbOrganisationId = i386PreferredAgbOrganisationId;
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

      public void VarsToRow74( SdtTrn_PreferredAgbSupplier obj74 )
      {
         obj74.gxTpr_Mode = Gx_mode;
         obj74.gxTpr_Preferredagborganisationid = A386PreferredAgbOrganisationId;
         obj74.gxTpr_Preferredsupplieragbid = A381PreferredSupplierAgbId;
         obj74.gxTpr_Preferredagbsupplierid = A384PreferredAgbSupplierId;
         obj74.gxTpr_Preferredagbsupplierid_Z = Z384PreferredAgbSupplierId;
         obj74.gxTpr_Preferredagborganisationid_Z = Z386PreferredAgbOrganisationId;
         obj74.gxTpr_Preferredsupplieragbid_Z = Z381PreferredSupplierAgbId;
         obj74.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow74( SdtTrn_PreferredAgbSupplier obj74 )
      {
         obj74.gxTpr_Preferredagbsupplierid = A384PreferredAgbSupplierId;
         return  ;
      }

      public void RowToVars74( SdtTrn_PreferredAgbSupplier obj74 ,
                               int forceLoad )
      {
         Gx_mode = obj74.gxTpr_Mode;
         A386PreferredAgbOrganisationId = obj74.gxTpr_Preferredagborganisationid;
         A381PreferredSupplierAgbId = obj74.gxTpr_Preferredsupplieragbid;
         A384PreferredAgbSupplierId = obj74.gxTpr_Preferredagbsupplierid;
         Z384PreferredAgbSupplierId = obj74.gxTpr_Preferredagbsupplierid_Z;
         Z386PreferredAgbOrganisationId = obj74.gxTpr_Preferredagborganisationid_Z;
         Z381PreferredSupplierAgbId = obj74.gxTpr_Preferredsupplieragbid_Z;
         Gx_mode = obj74.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A384PreferredAgbSupplierId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1774( ) ;
         ScanKeyStart1774( ) ;
         if ( RcdFound74 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z384PreferredAgbSupplierId = A384PreferredAgbSupplierId;
         }
         ZM1774( -6) ;
         OnLoadActions1774( ) ;
         AddRow1774( ) ;
         ScanKeyEnd1774( ) ;
         if ( RcdFound74 == 0 )
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
         RowToVars74( bcTrn_PreferredAgbSupplier, 0) ;
         ScanKeyStart1774( ) ;
         if ( RcdFound74 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z384PreferredAgbSupplierId = A384PreferredAgbSupplierId;
         }
         ZM1774( -6) ;
         OnLoadActions1774( ) ;
         AddRow1774( ) ;
         ScanKeyEnd1774( ) ;
         if ( RcdFound74 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1774( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1774( ) ;
         }
         else
         {
            if ( RcdFound74 == 1 )
            {
               if ( A384PreferredAgbSupplierId != Z384PreferredAgbSupplierId )
               {
                  A384PreferredAgbSupplierId = Z384PreferredAgbSupplierId;
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
                  Update1774( ) ;
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
                  if ( A384PreferredAgbSupplierId != Z384PreferredAgbSupplierId )
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
                        Insert1774( ) ;
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
                        Insert1774( ) ;
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
         RowToVars74( bcTrn_PreferredAgbSupplier, 1) ;
         SaveImpl( ) ;
         VarsToRow74( bcTrn_PreferredAgbSupplier) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars74( bcTrn_PreferredAgbSupplier, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1774( ) ;
         AfterTrn( ) ;
         VarsToRow74( bcTrn_PreferredAgbSupplier) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow74( bcTrn_PreferredAgbSupplier) ;
         }
         else
         {
            SdtTrn_PreferredAgbSupplier auxBC = new SdtTrn_PreferredAgbSupplier(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A384PreferredAgbSupplierId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_PreferredAgbSupplier);
               auxBC.Save();
               bcTrn_PreferredAgbSupplier.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars74( bcTrn_PreferredAgbSupplier, 1) ;
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
         RowToVars74( bcTrn_PreferredAgbSupplier, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1774( ) ;
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
               VarsToRow74( bcTrn_PreferredAgbSupplier) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow74( bcTrn_PreferredAgbSupplier) ;
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
         RowToVars74( bcTrn_PreferredAgbSupplier, 0) ;
         GetKey1774( ) ;
         if ( RcdFound74 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A384PreferredAgbSupplierId != Z384PreferredAgbSupplierId )
            {
               A384PreferredAgbSupplierId = Z384PreferredAgbSupplierId;
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
            if ( A384PreferredAgbSupplierId != Z384PreferredAgbSupplierId )
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
         context.RollbackDataStores("trn_preferredagbsupplier_bc",pr_default);
         VarsToRow74( bcTrn_PreferredAgbSupplier) ;
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
         Gx_mode = bcTrn_PreferredAgbSupplier.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_PreferredAgbSupplier.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_PreferredAgbSupplier )
         {
            bcTrn_PreferredAgbSupplier = (SdtTrn_PreferredAgbSupplier)(sdt);
            if ( StringUtil.StrCmp(bcTrn_PreferredAgbSupplier.gxTpr_Mode, "") == 0 )
            {
               bcTrn_PreferredAgbSupplier.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow74( bcTrn_PreferredAgbSupplier) ;
            }
            else
            {
               RowToVars74( bcTrn_PreferredAgbSupplier, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_PreferredAgbSupplier.gxTpr_Mode, "") == 0 )
            {
               bcTrn_PreferredAgbSupplier.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars74( bcTrn_PreferredAgbSupplier, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_PreferredAgbSupplier Trn_PreferredAgbSupplier_BC
      {
         get {
            return bcTrn_PreferredAgbSupplier ;
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
            return GAMSecurityLevel.SecurityLow ;
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
         Z384PreferredAgbSupplierId = Guid.Empty;
         A384PreferredAgbSupplierId = Guid.Empty;
         Z386PreferredAgbOrganisationId = Guid.Empty;
         A386PreferredAgbOrganisationId = Guid.Empty;
         Z381PreferredSupplierAgbId = Guid.Empty;
         A381PreferredSupplierAgbId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         BC00174_A384PreferredAgbSupplierId = new Guid[] {Guid.Empty} ;
         BC00174_A386PreferredAgbOrganisationId = new Guid[] {Guid.Empty} ;
         BC00174_A381PreferredSupplierAgbId = new Guid[] {Guid.Empty} ;
         BC00175_A384PreferredAgbSupplierId = new Guid[] {Guid.Empty} ;
         BC00173_A384PreferredAgbSupplierId = new Guid[] {Guid.Empty} ;
         BC00173_A386PreferredAgbOrganisationId = new Guid[] {Guid.Empty} ;
         BC00173_A381PreferredSupplierAgbId = new Guid[] {Guid.Empty} ;
         sMode74 = "";
         BC00172_A384PreferredAgbSupplierId = new Guid[] {Guid.Empty} ;
         BC00172_A386PreferredAgbOrganisationId = new Guid[] {Guid.Empty} ;
         BC00172_A381PreferredSupplierAgbId = new Guid[] {Guid.Empty} ;
         BC00179_A384PreferredAgbSupplierId = new Guid[] {Guid.Empty} ;
         BC00179_A386PreferredAgbOrganisationId = new Guid[] {Guid.Empty} ;
         BC00179_A381PreferredSupplierAgbId = new Guid[] {Guid.Empty} ;
         i386PreferredAgbOrganisationId = Guid.Empty;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_preferredagbsupplier_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_preferredagbsupplier_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_preferredagbsupplier_bc__default(),
            new Object[][] {
                new Object[] {
               BC00172_A384PreferredAgbSupplierId, BC00172_A386PreferredAgbOrganisationId, BC00172_A381PreferredSupplierAgbId
               }
               , new Object[] {
               BC00173_A384PreferredAgbSupplierId, BC00173_A386PreferredAgbOrganisationId, BC00173_A381PreferredSupplierAgbId
               }
               , new Object[] {
               BC00174_A384PreferredAgbSupplierId, BC00174_A386PreferredAgbOrganisationId, BC00174_A381PreferredSupplierAgbId
               }
               , new Object[] {
               BC00175_A384PreferredAgbSupplierId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00179_A384PreferredAgbSupplierId, BC00179_A386PreferredAgbOrganisationId, BC00179_A381PreferredSupplierAgbId
               }
            }
         );
         Z384PreferredAgbSupplierId = Guid.NewGuid( );
         A384PreferredAgbSupplierId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound74 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode74 ;
      private Guid Z384PreferredAgbSupplierId ;
      private Guid A384PreferredAgbSupplierId ;
      private Guid Z386PreferredAgbOrganisationId ;
      private Guid A386PreferredAgbOrganisationId ;
      private Guid Z381PreferredSupplierAgbId ;
      private Guid A381PreferredSupplierAgbId ;
      private Guid GXt_guid1 ;
      private Guid i386PreferredAgbOrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00174_A384PreferredAgbSupplierId ;
      private Guid[] BC00174_A386PreferredAgbOrganisationId ;
      private Guid[] BC00174_A381PreferredSupplierAgbId ;
      private Guid[] BC00175_A384PreferredAgbSupplierId ;
      private Guid[] BC00173_A384PreferredAgbSupplierId ;
      private Guid[] BC00173_A386PreferredAgbOrganisationId ;
      private Guid[] BC00173_A381PreferredSupplierAgbId ;
      private Guid[] BC00172_A384PreferredAgbSupplierId ;
      private Guid[] BC00172_A386PreferredAgbOrganisationId ;
      private Guid[] BC00172_A381PreferredSupplierAgbId ;
      private Guid[] BC00179_A384PreferredAgbSupplierId ;
      private Guid[] BC00179_A386PreferredAgbOrganisationId ;
      private Guid[] BC00179_A381PreferredSupplierAgbId ;
      private SdtTrn_PreferredAgbSupplier bcTrn_PreferredAgbSupplier ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_preferredagbsupplier_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_preferredagbsupplier_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_preferredagbsupplier_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC00172;
       prmBC00172 = new Object[] {
       new ParDef("PreferredAgbSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00173;
       prmBC00173 = new Object[] {
       new ParDef("PreferredAgbSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00174;
       prmBC00174 = new Object[] {
       new ParDef("PreferredAgbSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00175;
       prmBC00175 = new Object[] {
       new ParDef("PreferredAgbSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00176;
       prmBC00176 = new Object[] {
       new ParDef("PreferredAgbSupplierId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PreferredAgbOrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PreferredSupplierAgbId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00177;
       prmBC00177 = new Object[] {
       new ParDef("PreferredAgbOrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PreferredSupplierAgbId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PreferredAgbSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00178;
       prmBC00178 = new Object[] {
       new ParDef("PreferredAgbSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00179;
       prmBC00179 = new Object[] {
       new ParDef("PreferredAgbSupplierId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC00172", "SELECT PreferredAgbSupplierId, PreferredAgbOrganisationId, PreferredSupplierAgbId FROM Trn_PreferredAgbSupplier WHERE PreferredAgbSupplierId = :PreferredAgbSupplierId  FOR UPDATE OF Trn_PreferredAgbSupplier",true, GxErrorMask.GX_NOMASK, false, this,prmBC00172,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00173", "SELECT PreferredAgbSupplierId, PreferredAgbOrganisationId, PreferredSupplierAgbId FROM Trn_PreferredAgbSupplier WHERE PreferredAgbSupplierId = :PreferredAgbSupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00173,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00174", "SELECT TM1.PreferredAgbSupplierId, TM1.PreferredAgbOrganisationId, TM1.PreferredSupplierAgbId FROM Trn_PreferredAgbSupplier TM1 WHERE TM1.PreferredAgbSupplierId = :PreferredAgbSupplierId ORDER BY TM1.PreferredAgbSupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00174,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00175", "SELECT PreferredAgbSupplierId FROM Trn_PreferredAgbSupplier WHERE PreferredAgbSupplierId = :PreferredAgbSupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00175,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00176", "SAVEPOINT gxupdate;INSERT INTO Trn_PreferredAgbSupplier(PreferredAgbSupplierId, PreferredAgbOrganisationId, PreferredSupplierAgbId) VALUES(:PreferredAgbSupplierId, :PreferredAgbOrganisationId, :PreferredSupplierAgbId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00176)
          ,new CursorDef("BC00177", "SAVEPOINT gxupdate;UPDATE Trn_PreferredAgbSupplier SET PreferredAgbOrganisationId=:PreferredAgbOrganisationId, PreferredSupplierAgbId=:PreferredSupplierAgbId  WHERE PreferredAgbSupplierId = :PreferredAgbSupplierId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00177)
          ,new CursorDef("BC00178", "SAVEPOINT gxupdate;DELETE FROM Trn_PreferredAgbSupplier  WHERE PreferredAgbSupplierId = :PreferredAgbSupplierId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00178)
          ,new CursorDef("BC00179", "SELECT TM1.PreferredAgbSupplierId, TM1.PreferredAgbOrganisationId, TM1.PreferredSupplierAgbId FROM Trn_PreferredAgbSupplier TM1 WHERE TM1.PreferredAgbSupplierId = :PreferredAgbSupplierId ORDER BY TM1.PreferredAgbSupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00179,100, GxCacheFrequency.OFF ,true,false )
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
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
    }
 }

}

}
