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
   public class trn_preferredgensupplier_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_preferredgensupplier_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_preferredgensupplier_bc( IGxContext context )
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
         ReadRow1875( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1875( ) ;
         standaloneModal( ) ;
         AddRow1875( ) ;
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
               Z383PreferredGenSupplierId = A383PreferredGenSupplierId;
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

      protected void CONFIRM_180( )
      {
         BeforeValidate1875( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1875( ) ;
            }
            else
            {
               CheckExtendedTable1875( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1875( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1875( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z382PreferredSupplierGenId = A382PreferredSupplierGenId;
            Z385PreferredGenOrganisationId = A385PreferredGenOrganisationId;
         }
         if ( GX_JID == -7 )
         {
            Z383PreferredGenSupplierId = A383PreferredGenSupplierId;
            Z382PreferredSupplierGenId = A382PreferredSupplierGenId;
            Z385PreferredGenOrganisationId = A385PreferredGenOrganisationId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A382PreferredSupplierGenId) )
         {
            A382PreferredSupplierGenId = Guid.NewGuid( );
         }
         if ( IsIns( )  && (Guid.Empty==A383PreferredGenSupplierId) )
         {
            A383PreferredGenSupplierId = Guid.NewGuid( );
         }
         GXt_guid1 = A385PreferredGenOrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         A385PreferredGenOrganisationId = GXt_guid1;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1875( )
      {
         /* Using cursor BC00184 */
         pr_default.execute(2, new Object[] {A383PreferredGenSupplierId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound75 = 1;
            A382PreferredSupplierGenId = BC00184_A382PreferredSupplierGenId[0];
            A385PreferredGenOrganisationId = BC00184_A385PreferredGenOrganisationId[0];
            ZM1875( -7) ;
         }
         pr_default.close(2);
         OnLoadActions1875( ) ;
      }

      protected void OnLoadActions1875( )
      {
      }

      protected void CheckExtendedTable1875( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1875( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1875( )
      {
         /* Using cursor BC00185 */
         pr_default.execute(3, new Object[] {A383PreferredGenSupplierId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound75 = 1;
         }
         else
         {
            RcdFound75 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00183 */
         pr_default.execute(1, new Object[] {A383PreferredGenSupplierId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1875( 7) ;
            RcdFound75 = 1;
            A383PreferredGenSupplierId = BC00183_A383PreferredGenSupplierId[0];
            A382PreferredSupplierGenId = BC00183_A382PreferredSupplierGenId[0];
            A385PreferredGenOrganisationId = BC00183_A385PreferredGenOrganisationId[0];
            Z383PreferredGenSupplierId = A383PreferredGenSupplierId;
            sMode75 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1875( ) ;
            if ( AnyError == 1 )
            {
               RcdFound75 = 0;
               InitializeNonKey1875( ) ;
            }
            Gx_mode = sMode75;
         }
         else
         {
            RcdFound75 = 0;
            InitializeNonKey1875( ) ;
            sMode75 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode75;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1875( ) ;
         if ( RcdFound75 == 0 )
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
         CONFIRM_180( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1875( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00182 */
            pr_default.execute(0, new Object[] {A383PreferredGenSupplierId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_PreferredGenSupplier"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z382PreferredSupplierGenId != BC00182_A382PreferredSupplierGenId[0] ) || ( Z385PreferredGenOrganisationId != BC00182_A385PreferredGenOrganisationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_PreferredGenSupplier"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1875( )
      {
         BeforeValidate1875( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1875( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1875( 0) ;
            CheckOptimisticConcurrency1875( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1875( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1875( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00186 */
                     pr_default.execute(4, new Object[] {A383PreferredGenSupplierId, A382PreferredSupplierGenId, A385PreferredGenOrganisationId});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_PreferredGenSupplier");
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
               Load1875( ) ;
            }
            EndLevel1875( ) ;
         }
         CloseExtendedTableCursors1875( ) ;
      }

      protected void Update1875( )
      {
         BeforeValidate1875( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1875( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1875( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1875( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1875( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00187 */
                     pr_default.execute(5, new Object[] {A382PreferredSupplierGenId, A385PreferredGenOrganisationId, A383PreferredGenSupplierId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_PreferredGenSupplier");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_PreferredGenSupplier"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1875( ) ;
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
            EndLevel1875( ) ;
         }
         CloseExtendedTableCursors1875( ) ;
      }

      protected void DeferredUpdate1875( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1875( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1875( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1875( ) ;
            AfterConfirm1875( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1875( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00188 */
                  pr_default.execute(6, new Object[] {A383PreferredGenSupplierId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_PreferredGenSupplier");
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
         sMode75 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1875( ) ;
         Gx_mode = sMode75;
      }

      protected void OnDeleteControls1875( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1875( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1875( ) ;
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

      public void ScanKeyStart1875( )
      {
         /* Using cursor BC00189 */
         pr_default.execute(7, new Object[] {A383PreferredGenSupplierId});
         RcdFound75 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound75 = 1;
            A383PreferredGenSupplierId = BC00189_A383PreferredGenSupplierId[0];
            A382PreferredSupplierGenId = BC00189_A382PreferredSupplierGenId[0];
            A385PreferredGenOrganisationId = BC00189_A385PreferredGenOrganisationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1875( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound75 = 0;
         ScanKeyLoad1875( ) ;
      }

      protected void ScanKeyLoad1875( )
      {
         sMode75 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound75 = 1;
            A383PreferredGenSupplierId = BC00189_A383PreferredGenSupplierId[0];
            A382PreferredSupplierGenId = BC00189_A382PreferredSupplierGenId[0];
            A385PreferredGenOrganisationId = BC00189_A385PreferredGenOrganisationId[0];
         }
         Gx_mode = sMode75;
      }

      protected void ScanKeyEnd1875( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm1875( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1875( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1875( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1875( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1875( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1875( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1875( )
      {
      }

      protected void send_integrity_lvl_hashes1875( )
      {
      }

      protected void AddRow1875( )
      {
         VarsToRow75( bcTrn_PreferredGenSupplier) ;
      }

      protected void ReadRow1875( )
      {
         RowToVars75( bcTrn_PreferredGenSupplier, 1) ;
      }

      protected void InitializeNonKey1875( )
      {
         A385PreferredGenOrganisationId = Guid.Empty;
         A382PreferredSupplierGenId = Guid.NewGuid( );
         Z382PreferredSupplierGenId = Guid.Empty;
         Z385PreferredGenOrganisationId = Guid.Empty;
      }

      protected void InitAll1875( )
      {
         A383PreferredGenSupplierId = Guid.NewGuid( );
         InitializeNonKey1875( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A382PreferredSupplierGenId = i382PreferredSupplierGenId;
         A385PreferredGenOrganisationId = i385PreferredGenOrganisationId;
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

      public void VarsToRow75( SdtTrn_PreferredGenSupplier obj75 )
      {
         obj75.gxTpr_Mode = Gx_mode;
         obj75.gxTpr_Preferredgenorganisationid = A385PreferredGenOrganisationId;
         obj75.gxTpr_Preferredsuppliergenid = A382PreferredSupplierGenId;
         obj75.gxTpr_Preferredgensupplierid = A383PreferredGenSupplierId;
         obj75.gxTpr_Preferredgensupplierid_Z = Z383PreferredGenSupplierId;
         obj75.gxTpr_Preferredgenorganisationid_Z = Z385PreferredGenOrganisationId;
         obj75.gxTpr_Preferredsuppliergenid_Z = Z382PreferredSupplierGenId;
         obj75.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow75( SdtTrn_PreferredGenSupplier obj75 )
      {
         obj75.gxTpr_Preferredgensupplierid = A383PreferredGenSupplierId;
         return  ;
      }

      public void RowToVars75( SdtTrn_PreferredGenSupplier obj75 ,
                               int forceLoad )
      {
         Gx_mode = obj75.gxTpr_Mode;
         A385PreferredGenOrganisationId = obj75.gxTpr_Preferredgenorganisationid;
         A382PreferredSupplierGenId = obj75.gxTpr_Preferredsuppliergenid;
         A383PreferredGenSupplierId = obj75.gxTpr_Preferredgensupplierid;
         Z383PreferredGenSupplierId = obj75.gxTpr_Preferredgensupplierid_Z;
         Z385PreferredGenOrganisationId = obj75.gxTpr_Preferredgenorganisationid_Z;
         Z382PreferredSupplierGenId = obj75.gxTpr_Preferredsuppliergenid_Z;
         Gx_mode = obj75.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A383PreferredGenSupplierId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1875( ) ;
         ScanKeyStart1875( ) ;
         if ( RcdFound75 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z383PreferredGenSupplierId = A383PreferredGenSupplierId;
         }
         ZM1875( -7) ;
         OnLoadActions1875( ) ;
         AddRow1875( ) ;
         ScanKeyEnd1875( ) ;
         if ( RcdFound75 == 0 )
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
         RowToVars75( bcTrn_PreferredGenSupplier, 0) ;
         ScanKeyStart1875( ) ;
         if ( RcdFound75 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z383PreferredGenSupplierId = A383PreferredGenSupplierId;
         }
         ZM1875( -7) ;
         OnLoadActions1875( ) ;
         AddRow1875( ) ;
         ScanKeyEnd1875( ) ;
         if ( RcdFound75 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1875( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1875( ) ;
         }
         else
         {
            if ( RcdFound75 == 1 )
            {
               if ( A383PreferredGenSupplierId != Z383PreferredGenSupplierId )
               {
                  A383PreferredGenSupplierId = Z383PreferredGenSupplierId;
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
                  Update1875( ) ;
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
                  if ( A383PreferredGenSupplierId != Z383PreferredGenSupplierId )
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
                        Insert1875( ) ;
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
                        Insert1875( ) ;
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
         RowToVars75( bcTrn_PreferredGenSupplier, 1) ;
         SaveImpl( ) ;
         VarsToRow75( bcTrn_PreferredGenSupplier) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars75( bcTrn_PreferredGenSupplier, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1875( ) ;
         AfterTrn( ) ;
         VarsToRow75( bcTrn_PreferredGenSupplier) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow75( bcTrn_PreferredGenSupplier) ;
         }
         else
         {
            SdtTrn_PreferredGenSupplier auxBC = new SdtTrn_PreferredGenSupplier(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A383PreferredGenSupplierId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_PreferredGenSupplier);
               auxBC.Save();
               bcTrn_PreferredGenSupplier.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars75( bcTrn_PreferredGenSupplier, 1) ;
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
         RowToVars75( bcTrn_PreferredGenSupplier, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1875( ) ;
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
               VarsToRow75( bcTrn_PreferredGenSupplier) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow75( bcTrn_PreferredGenSupplier) ;
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
         RowToVars75( bcTrn_PreferredGenSupplier, 0) ;
         GetKey1875( ) ;
         if ( RcdFound75 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A383PreferredGenSupplierId != Z383PreferredGenSupplierId )
            {
               A383PreferredGenSupplierId = Z383PreferredGenSupplierId;
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
            if ( A383PreferredGenSupplierId != Z383PreferredGenSupplierId )
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
         context.RollbackDataStores("trn_preferredgensupplier_bc",pr_default);
         VarsToRow75( bcTrn_PreferredGenSupplier) ;
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
         Gx_mode = bcTrn_PreferredGenSupplier.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_PreferredGenSupplier.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_PreferredGenSupplier )
         {
            bcTrn_PreferredGenSupplier = (SdtTrn_PreferredGenSupplier)(sdt);
            if ( StringUtil.StrCmp(bcTrn_PreferredGenSupplier.gxTpr_Mode, "") == 0 )
            {
               bcTrn_PreferredGenSupplier.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow75( bcTrn_PreferredGenSupplier) ;
            }
            else
            {
               RowToVars75( bcTrn_PreferredGenSupplier, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_PreferredGenSupplier.gxTpr_Mode, "") == 0 )
            {
               bcTrn_PreferredGenSupplier.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars75( bcTrn_PreferredGenSupplier, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_PreferredGenSupplier Trn_PreferredGenSupplier_BC
      {
         get {
            return bcTrn_PreferredGenSupplier ;
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
            return "trn_preferredgensupplier_Execute" ;
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
         Z383PreferredGenSupplierId = Guid.Empty;
         A383PreferredGenSupplierId = Guid.Empty;
         Z382PreferredSupplierGenId = Guid.Empty;
         A382PreferredSupplierGenId = Guid.Empty;
         Z385PreferredGenOrganisationId = Guid.Empty;
         A385PreferredGenOrganisationId = Guid.Empty;
         GXt_guid1 = Guid.Empty;
         BC00184_A383PreferredGenSupplierId = new Guid[] {Guid.Empty} ;
         BC00184_A382PreferredSupplierGenId = new Guid[] {Guid.Empty} ;
         BC00184_A385PreferredGenOrganisationId = new Guid[] {Guid.Empty} ;
         BC00185_A383PreferredGenSupplierId = new Guid[] {Guid.Empty} ;
         BC00183_A383PreferredGenSupplierId = new Guid[] {Guid.Empty} ;
         BC00183_A382PreferredSupplierGenId = new Guid[] {Guid.Empty} ;
         BC00183_A385PreferredGenOrganisationId = new Guid[] {Guid.Empty} ;
         sMode75 = "";
         BC00182_A383PreferredGenSupplierId = new Guid[] {Guid.Empty} ;
         BC00182_A382PreferredSupplierGenId = new Guid[] {Guid.Empty} ;
         BC00182_A385PreferredGenOrganisationId = new Guid[] {Guid.Empty} ;
         BC00189_A383PreferredGenSupplierId = new Guid[] {Guid.Empty} ;
         BC00189_A382PreferredSupplierGenId = new Guid[] {Guid.Empty} ;
         BC00189_A385PreferredGenOrganisationId = new Guid[] {Guid.Empty} ;
         i382PreferredSupplierGenId = Guid.Empty;
         i385PreferredGenOrganisationId = Guid.Empty;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_preferredgensupplier_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_preferredgensupplier_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_preferredgensupplier_bc__default(),
            new Object[][] {
                new Object[] {
               BC00182_A383PreferredGenSupplierId, BC00182_A382PreferredSupplierGenId, BC00182_A385PreferredGenOrganisationId
               }
               , new Object[] {
               BC00183_A383PreferredGenSupplierId, BC00183_A382PreferredSupplierGenId, BC00183_A385PreferredGenOrganisationId
               }
               , new Object[] {
               BC00184_A383PreferredGenSupplierId, BC00184_A382PreferredSupplierGenId, BC00184_A385PreferredGenOrganisationId
               }
               , new Object[] {
               BC00185_A383PreferredGenSupplierId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00189_A383PreferredGenSupplierId, BC00189_A382PreferredSupplierGenId, BC00189_A385PreferredGenOrganisationId
               }
            }
         );
         Z382PreferredSupplierGenId = Guid.NewGuid( );
         A382PreferredSupplierGenId = Guid.NewGuid( );
         i382PreferredSupplierGenId = Guid.NewGuid( );
         Z383PreferredGenSupplierId = Guid.NewGuid( );
         A383PreferredGenSupplierId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound75 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode75 ;
      private Guid Z383PreferredGenSupplierId ;
      private Guid A383PreferredGenSupplierId ;
      private Guid Z382PreferredSupplierGenId ;
      private Guid A382PreferredSupplierGenId ;
      private Guid Z385PreferredGenOrganisationId ;
      private Guid A385PreferredGenOrganisationId ;
      private Guid GXt_guid1 ;
      private Guid i382PreferredSupplierGenId ;
      private Guid i385PreferredGenOrganisationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00184_A383PreferredGenSupplierId ;
      private Guid[] BC00184_A382PreferredSupplierGenId ;
      private Guid[] BC00184_A385PreferredGenOrganisationId ;
      private Guid[] BC00185_A383PreferredGenSupplierId ;
      private Guid[] BC00183_A383PreferredGenSupplierId ;
      private Guid[] BC00183_A382PreferredSupplierGenId ;
      private Guid[] BC00183_A385PreferredGenOrganisationId ;
      private Guid[] BC00182_A383PreferredGenSupplierId ;
      private Guid[] BC00182_A382PreferredSupplierGenId ;
      private Guid[] BC00182_A385PreferredGenOrganisationId ;
      private Guid[] BC00189_A383PreferredGenSupplierId ;
      private Guid[] BC00189_A382PreferredSupplierGenId ;
      private Guid[] BC00189_A385PreferredGenOrganisationId ;
      private SdtTrn_PreferredGenSupplier bcTrn_PreferredGenSupplier ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_preferredgensupplier_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_preferredgensupplier_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_preferredgensupplier_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC00182;
       prmBC00182 = new Object[] {
       new ParDef("PreferredGenSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00183;
       prmBC00183 = new Object[] {
       new ParDef("PreferredGenSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00184;
       prmBC00184 = new Object[] {
       new ParDef("PreferredGenSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00185;
       prmBC00185 = new Object[] {
       new ParDef("PreferredGenSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00186;
       prmBC00186 = new Object[] {
       new ParDef("PreferredGenSupplierId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PreferredSupplierGenId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PreferredGenOrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00187;
       prmBC00187 = new Object[] {
       new ParDef("PreferredSupplierGenId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PreferredGenOrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("PreferredGenSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00188;
       prmBC00188 = new Object[] {
       new ParDef("PreferredGenSupplierId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00189;
       prmBC00189 = new Object[] {
       new ParDef("PreferredGenSupplierId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC00182", "SELECT PreferredGenSupplierId, PreferredSupplierGenId, PreferredGenOrganisationId FROM Trn_PreferredGenSupplier WHERE PreferredGenSupplierId = :PreferredGenSupplierId  FOR UPDATE OF Trn_PreferredGenSupplier",true, GxErrorMask.GX_NOMASK, false, this,prmBC00182,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00183", "SELECT PreferredGenSupplierId, PreferredSupplierGenId, PreferredGenOrganisationId FROM Trn_PreferredGenSupplier WHERE PreferredGenSupplierId = :PreferredGenSupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00183,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00184", "SELECT TM1.PreferredGenSupplierId, TM1.PreferredSupplierGenId, TM1.PreferredGenOrganisationId FROM Trn_PreferredGenSupplier TM1 WHERE TM1.PreferredGenSupplierId = :PreferredGenSupplierId ORDER BY TM1.PreferredGenSupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00184,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00185", "SELECT PreferredGenSupplierId FROM Trn_PreferredGenSupplier WHERE PreferredGenSupplierId = :PreferredGenSupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00185,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00186", "SAVEPOINT gxupdate;INSERT INTO Trn_PreferredGenSupplier(PreferredGenSupplierId, PreferredSupplierGenId, PreferredGenOrganisationId) VALUES(:PreferredGenSupplierId, :PreferredSupplierGenId, :PreferredGenOrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00186)
          ,new CursorDef("BC00187", "SAVEPOINT gxupdate;UPDATE Trn_PreferredGenSupplier SET PreferredSupplierGenId=:PreferredSupplierGenId, PreferredGenOrganisationId=:PreferredGenOrganisationId  WHERE PreferredGenSupplierId = :PreferredGenSupplierId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00187)
          ,new CursorDef("BC00188", "SAVEPOINT gxupdate;DELETE FROM Trn_PreferredGenSupplier  WHERE PreferredGenSupplierId = :PreferredGenSupplierId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00188)
          ,new CursorDef("BC00189", "SELECT TM1.PreferredGenSupplierId, TM1.PreferredSupplierGenId, TM1.PreferredGenOrganisationId FROM Trn_PreferredGenSupplier TM1 WHERE TM1.PreferredGenSupplierId = :PreferredGenSupplierId ORDER BY TM1.PreferredGenSupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00189,100, GxCacheFrequency.OFF ,true,false )
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
