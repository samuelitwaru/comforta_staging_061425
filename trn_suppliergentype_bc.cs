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
   public class trn_suppliergentype_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_suppliergentype_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_suppliergentype_bc( IGxContext context )
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
         ReadRow0X48( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0X48( ) ;
         standaloneModal( ) ;
         AddRow0X48( ) ;
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
            E110X2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z253SupplierGenTypeId = A253SupplierGenTypeId;
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

      protected void CONFIRM_0X0( )
      {
         BeforeValidate0X48( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0X48( ) ;
            }
            else
            {
               CheckExtendedTable0X48( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0X48( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120X2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110X2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0X48( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z254SupplierGenTypeName = A254SupplierGenTypeName;
         }
         if ( GX_JID == -4 )
         {
            Z253SupplierGenTypeId = A253SupplierGenTypeId;
            Z254SupplierGenTypeName = A254SupplierGenTypeName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A253SupplierGenTypeId) )
         {
            A253SupplierGenTypeId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0X48( )
      {
         /* Using cursor BC000X4 */
         pr_default.execute(2, new Object[] {A253SupplierGenTypeId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound48 = 1;
            A254SupplierGenTypeName = BC000X4_A254SupplierGenTypeName[0];
            ZM0X48( -4) ;
         }
         pr_default.close(2);
         OnLoadActions0X48( ) ;
      }

      protected void OnLoadActions0X48( )
      {
      }

      protected void CheckExtendedTable0X48( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A254SupplierGenTypeName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Gen Type Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0X48( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0X48( )
      {
         /* Using cursor BC000X5 */
         pr_default.execute(3, new Object[] {A253SupplierGenTypeId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound48 = 1;
         }
         else
         {
            RcdFound48 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000X3 */
         pr_default.execute(1, new Object[] {A253SupplierGenTypeId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0X48( 4) ;
            RcdFound48 = 1;
            A253SupplierGenTypeId = BC000X3_A253SupplierGenTypeId[0];
            A254SupplierGenTypeName = BC000X3_A254SupplierGenTypeName[0];
            Z253SupplierGenTypeId = A253SupplierGenTypeId;
            sMode48 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0X48( ) ;
            if ( AnyError == 1 )
            {
               RcdFound48 = 0;
               InitializeNonKey0X48( ) ;
            }
            Gx_mode = sMode48;
         }
         else
         {
            RcdFound48 = 0;
            InitializeNonKey0X48( ) ;
            sMode48 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode48;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0X48( ) ;
         if ( RcdFound48 == 0 )
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
         CONFIRM_0X0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0X48( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000X2 */
            pr_default.execute(0, new Object[] {A253SupplierGenTypeId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierGenType"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z254SupplierGenTypeName, BC000X2_A254SupplierGenTypeName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_SupplierGenType"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0X48( )
      {
         BeforeValidate0X48( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X48( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0X48( 0) ;
            CheckOptimisticConcurrency0X48( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X48( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0X48( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000X6 */
                     pr_default.execute(4, new Object[] {A253SupplierGenTypeId, A254SupplierGenTypeName});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGenType");
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
               Load0X48( ) ;
            }
            EndLevel0X48( ) ;
         }
         CloseExtendedTableCursors0X48( ) ;
      }

      protected void Update0X48( )
      {
         BeforeValidate0X48( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X48( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X48( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X48( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0X48( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000X7 */
                     pr_default.execute(5, new Object[] {A254SupplierGenTypeName, A253SupplierGenTypeId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGenType");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierGenType"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0X48( ) ;
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
            EndLevel0X48( ) ;
         }
         CloseExtendedTableCursors0X48( ) ;
      }

      protected void DeferredUpdate0X48( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0X48( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X48( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0X48( ) ;
            AfterConfirm0X48( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0X48( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000X8 */
                  pr_default.execute(6, new Object[] {A253SupplierGenTypeId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierGenType");
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
         sMode48 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0X48( ) ;
         Gx_mode = sMode48;
      }

      protected void OnDeleteControls0X48( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000X9 */
            pr_default.execute(7, new Object[] {A253SupplierGenTypeId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "General Suppliers", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0X48( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0X48( ) ;
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

      public void ScanKeyStart0X48( )
      {
         /* Scan By routine */
         /* Using cursor BC000X10 */
         pr_default.execute(8, new Object[] {A253SupplierGenTypeId});
         RcdFound48 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound48 = 1;
            A253SupplierGenTypeId = BC000X10_A253SupplierGenTypeId[0];
            A254SupplierGenTypeName = BC000X10_A254SupplierGenTypeName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0X48( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound48 = 0;
         ScanKeyLoad0X48( ) ;
      }

      protected void ScanKeyLoad0X48( )
      {
         sMode48 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound48 = 1;
            A253SupplierGenTypeId = BC000X10_A253SupplierGenTypeId[0];
            A254SupplierGenTypeName = BC000X10_A254SupplierGenTypeName[0];
         }
         Gx_mode = sMode48;
      }

      protected void ScanKeyEnd0X48( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0X48( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0X48( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0X48( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0X48( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0X48( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0X48( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0X48( )
      {
      }

      protected void send_integrity_lvl_hashes0X48( )
      {
      }

      protected void AddRow0X48( )
      {
         VarsToRow48( bcTrn_SupplierGenType) ;
      }

      protected void ReadRow0X48( )
      {
         RowToVars48( bcTrn_SupplierGenType, 1) ;
      }

      protected void InitializeNonKey0X48( )
      {
         A254SupplierGenTypeName = "";
         Z254SupplierGenTypeName = "";
      }

      protected void InitAll0X48( )
      {
         A253SupplierGenTypeId = Guid.NewGuid( );
         InitializeNonKey0X48( ) ;
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

      public void VarsToRow48( SdtTrn_SupplierGenType obj48 )
      {
         obj48.gxTpr_Mode = Gx_mode;
         obj48.gxTpr_Suppliergentypename = A254SupplierGenTypeName;
         obj48.gxTpr_Suppliergentypeid = A253SupplierGenTypeId;
         obj48.gxTpr_Suppliergentypeid_Z = Z253SupplierGenTypeId;
         obj48.gxTpr_Suppliergentypename_Z = Z254SupplierGenTypeName;
         obj48.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow48( SdtTrn_SupplierGenType obj48 )
      {
         obj48.gxTpr_Suppliergentypeid = A253SupplierGenTypeId;
         return  ;
      }

      public void RowToVars48( SdtTrn_SupplierGenType obj48 ,
                               int forceLoad )
      {
         Gx_mode = obj48.gxTpr_Mode;
         A254SupplierGenTypeName = obj48.gxTpr_Suppliergentypename;
         A253SupplierGenTypeId = obj48.gxTpr_Suppliergentypeid;
         Z253SupplierGenTypeId = obj48.gxTpr_Suppliergentypeid_Z;
         Z254SupplierGenTypeName = obj48.gxTpr_Suppliergentypename_Z;
         Gx_mode = obj48.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A253SupplierGenTypeId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0X48( ) ;
         ScanKeyStart0X48( ) ;
         if ( RcdFound48 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z253SupplierGenTypeId = A253SupplierGenTypeId;
         }
         ZM0X48( -4) ;
         OnLoadActions0X48( ) ;
         AddRow0X48( ) ;
         ScanKeyEnd0X48( ) ;
         if ( RcdFound48 == 0 )
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
         RowToVars48( bcTrn_SupplierGenType, 0) ;
         ScanKeyStart0X48( ) ;
         if ( RcdFound48 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z253SupplierGenTypeId = A253SupplierGenTypeId;
         }
         ZM0X48( -4) ;
         OnLoadActions0X48( ) ;
         AddRow0X48( ) ;
         ScanKeyEnd0X48( ) ;
         if ( RcdFound48 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0X48( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0X48( ) ;
         }
         else
         {
            if ( RcdFound48 == 1 )
            {
               if ( A253SupplierGenTypeId != Z253SupplierGenTypeId )
               {
                  A253SupplierGenTypeId = Z253SupplierGenTypeId;
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
                  Update0X48( ) ;
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
                  if ( A253SupplierGenTypeId != Z253SupplierGenTypeId )
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
                        Insert0X48( ) ;
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
                        Insert0X48( ) ;
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
         RowToVars48( bcTrn_SupplierGenType, 1) ;
         SaveImpl( ) ;
         VarsToRow48( bcTrn_SupplierGenType) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars48( bcTrn_SupplierGenType, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0X48( ) ;
         AfterTrn( ) ;
         VarsToRow48( bcTrn_SupplierGenType) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow48( bcTrn_SupplierGenType) ;
         }
         else
         {
            SdtTrn_SupplierGenType auxBC = new SdtTrn_SupplierGenType(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A253SupplierGenTypeId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_SupplierGenType);
               auxBC.Save();
               bcTrn_SupplierGenType.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars48( bcTrn_SupplierGenType, 1) ;
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
         RowToVars48( bcTrn_SupplierGenType, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0X48( ) ;
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
               VarsToRow48( bcTrn_SupplierGenType) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow48( bcTrn_SupplierGenType) ;
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
         RowToVars48( bcTrn_SupplierGenType, 0) ;
         GetKey0X48( ) ;
         if ( RcdFound48 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A253SupplierGenTypeId != Z253SupplierGenTypeId )
            {
               A253SupplierGenTypeId = Z253SupplierGenTypeId;
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
            if ( A253SupplierGenTypeId != Z253SupplierGenTypeId )
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
         context.RollbackDataStores("trn_suppliergentype_bc",pr_default);
         VarsToRow48( bcTrn_SupplierGenType) ;
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
         Gx_mode = bcTrn_SupplierGenType.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_SupplierGenType.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_SupplierGenType )
         {
            bcTrn_SupplierGenType = (SdtTrn_SupplierGenType)(sdt);
            if ( StringUtil.StrCmp(bcTrn_SupplierGenType.gxTpr_Mode, "") == 0 )
            {
               bcTrn_SupplierGenType.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow48( bcTrn_SupplierGenType) ;
            }
            else
            {
               RowToVars48( bcTrn_SupplierGenType, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_SupplierGenType.gxTpr_Mode, "") == 0 )
            {
               bcTrn_SupplierGenType.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars48( bcTrn_SupplierGenType, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_SupplierGenType Trn_SupplierGenType_BC
      {
         get {
            return bcTrn_SupplierGenType ;
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
            return "trn_suppliergentype_Execute" ;
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
         Z253SupplierGenTypeId = Guid.Empty;
         A253SupplierGenTypeId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z254SupplierGenTypeName = "";
         A254SupplierGenTypeName = "";
         BC000X4_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         BC000X4_A254SupplierGenTypeName = new string[] {""} ;
         BC000X5_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         BC000X3_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         BC000X3_A254SupplierGenTypeName = new string[] {""} ;
         sMode48 = "";
         BC000X2_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         BC000X2_A254SupplierGenTypeName = new string[] {""} ;
         BC000X9_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC000X10_A253SupplierGenTypeId = new Guid[] {Guid.Empty} ;
         BC000X10_A254SupplierGenTypeName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergentype_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergentype_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_suppliergentype_bc__default(),
            new Object[][] {
                new Object[] {
               BC000X2_A253SupplierGenTypeId, BC000X2_A254SupplierGenTypeName
               }
               , new Object[] {
               BC000X3_A253SupplierGenTypeId, BC000X3_A254SupplierGenTypeName
               }
               , new Object[] {
               BC000X4_A253SupplierGenTypeId, BC000X4_A254SupplierGenTypeName
               }
               , new Object[] {
               BC000X5_A253SupplierGenTypeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000X9_A42SupplierGenId
               }
               , new Object[] {
               BC000X10_A253SupplierGenTypeId, BC000X10_A254SupplierGenTypeName
               }
            }
         );
         Z253SupplierGenTypeId = Guid.NewGuid( );
         A253SupplierGenTypeId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120X2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound48 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode48 ;
      private bool returnInSub ;
      private string Z254SupplierGenTypeName ;
      private string A254SupplierGenTypeName ;
      private Guid Z253SupplierGenTypeId ;
      private Guid A253SupplierGenTypeId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC000X4_A253SupplierGenTypeId ;
      private string[] BC000X4_A254SupplierGenTypeName ;
      private Guid[] BC000X5_A253SupplierGenTypeId ;
      private Guid[] BC000X3_A253SupplierGenTypeId ;
      private string[] BC000X3_A254SupplierGenTypeName ;
      private Guid[] BC000X2_A253SupplierGenTypeId ;
      private string[] BC000X2_A254SupplierGenTypeName ;
      private Guid[] BC000X9_A42SupplierGenId ;
      private Guid[] BC000X10_A253SupplierGenTypeId ;
      private string[] BC000X10_A254SupplierGenTypeName ;
      private SdtTrn_SupplierGenType bcTrn_SupplierGenType ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_suppliergentype_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_suppliergentype_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_suppliergentype_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[8])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000X2;
       prmBC000X2 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000X3;
       prmBC000X3 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000X4;
       prmBC000X4 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000X5;
       prmBC000X5 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000X6;
       prmBC000X6 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierGenTypeName",GXType.VarChar,100,0)
       };
       Object[] prmBC000X7;
       prmBC000X7 = new Object[] {
       new ParDef("SupplierGenTypeName",GXType.VarChar,100,0) ,
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000X8;
       prmBC000X8 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000X9;
       prmBC000X9 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000X10;
       prmBC000X10 = new Object[] {
       new ParDef("SupplierGenTypeId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC000X2", "SELECT SupplierGenTypeId, SupplierGenTypeName FROM Trn_SupplierGenType WHERE SupplierGenTypeId = :SupplierGenTypeId  FOR UPDATE OF Trn_SupplierGenType",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000X3", "SELECT SupplierGenTypeId, SupplierGenTypeName FROM Trn_SupplierGenType WHERE SupplierGenTypeId = :SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000X4", "SELECT TM1.SupplierGenTypeId, TM1.SupplierGenTypeName FROM Trn_SupplierGenType TM1 WHERE TM1.SupplierGenTypeId = :SupplierGenTypeId ORDER BY TM1.SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000X5", "SELECT SupplierGenTypeId FROM Trn_SupplierGenType WHERE SupplierGenTypeId = :SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000X6", "SAVEPOINT gxupdate;INSERT INTO Trn_SupplierGenType(SupplierGenTypeId, SupplierGenTypeName) VALUES(:SupplierGenTypeId, :SupplierGenTypeName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000X6)
          ,new CursorDef("BC000X7", "SAVEPOINT gxupdate;UPDATE Trn_SupplierGenType SET SupplierGenTypeName=:SupplierGenTypeName  WHERE SupplierGenTypeId = :SupplierGenTypeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000X7)
          ,new CursorDef("BC000X8", "SAVEPOINT gxupdate;DELETE FROM Trn_SupplierGenType  WHERE SupplierGenTypeId = :SupplierGenTypeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000X8)
          ,new CursorDef("BC000X9", "SELECT SupplierGenId FROM Trn_SupplierGen WHERE SupplierGenTypeId = :SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000X10", "SELECT TM1.SupplierGenTypeId, TM1.SupplierGenTypeName FROM Trn_SupplierGenType TM1 WHERE TM1.SupplierGenTypeId = :SupplierGenTypeId ORDER BY TM1.SupplierGenTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X10,100, GxCacheFrequency.OFF ,true,false )
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
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
    }
 }

}

}
