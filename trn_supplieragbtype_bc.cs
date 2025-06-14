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
   public class trn_supplieragbtype_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_supplieragbtype_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_supplieragbtype_bc( IGxContext context )
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
         ReadRow0W47( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0W47( ) ;
         standaloneModal( ) ;
         AddRow0W47( ) ;
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
            E110W2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z255SupplierAgbTypeId = A255SupplierAgbTypeId;
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

      protected void CONFIRM_0W0( )
      {
         BeforeValidate0W47( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0W47( ) ;
            }
            else
            {
               CheckExtendedTable0W47( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0W47( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120W2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110W2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0W47( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z256SupplierAgbTypeName = A256SupplierAgbTypeName;
         }
         if ( GX_JID == -4 )
         {
            Z255SupplierAgbTypeId = A255SupplierAgbTypeId;
            Z256SupplierAgbTypeName = A256SupplierAgbTypeName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A255SupplierAgbTypeId) )
         {
            A255SupplierAgbTypeId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0W47( )
      {
         /* Using cursor BC000W4 */
         pr_default.execute(2, new Object[] {A255SupplierAgbTypeId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound47 = 1;
            A256SupplierAgbTypeName = BC000W4_A256SupplierAgbTypeName[0];
            ZM0W47( -4) ;
         }
         pr_default.close(2);
         OnLoadActions0W47( ) ;
      }

      protected void OnLoadActions0W47( )
      {
      }

      protected void CheckExtendedTable0W47( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A256SupplierAgbTypeName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Supplier Agb Type Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0W47( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0W47( )
      {
         /* Using cursor BC000W5 */
         pr_default.execute(3, new Object[] {A255SupplierAgbTypeId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound47 = 1;
         }
         else
         {
            RcdFound47 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000W3 */
         pr_default.execute(1, new Object[] {A255SupplierAgbTypeId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0W47( 4) ;
            RcdFound47 = 1;
            A255SupplierAgbTypeId = BC000W3_A255SupplierAgbTypeId[0];
            A256SupplierAgbTypeName = BC000W3_A256SupplierAgbTypeName[0];
            Z255SupplierAgbTypeId = A255SupplierAgbTypeId;
            sMode47 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0W47( ) ;
            if ( AnyError == 1 )
            {
               RcdFound47 = 0;
               InitializeNonKey0W47( ) ;
            }
            Gx_mode = sMode47;
         }
         else
         {
            RcdFound47 = 0;
            InitializeNonKey0W47( ) ;
            sMode47 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode47;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0W47( ) ;
         if ( RcdFound47 == 0 )
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
         CONFIRM_0W0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0W47( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000W2 */
            pr_default.execute(0, new Object[] {A255SupplierAgbTypeId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierAgbType"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z256SupplierAgbTypeName, BC000W2_A256SupplierAgbTypeName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_SupplierAgbType"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0W47( )
      {
         BeforeValidate0W47( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W47( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0W47( 0) ;
            CheckOptimisticConcurrency0W47( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W47( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0W47( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000W6 */
                     pr_default.execute(4, new Object[] {A255SupplierAgbTypeId, A256SupplierAgbTypeName});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierAgbType");
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
               Load0W47( ) ;
            }
            EndLevel0W47( ) ;
         }
         CloseExtendedTableCursors0W47( ) ;
      }

      protected void Update0W47( )
      {
         BeforeValidate0W47( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W47( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W47( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W47( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0W47( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000W7 */
                     pr_default.execute(5, new Object[] {A256SupplierAgbTypeName, A255SupplierAgbTypeId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierAgbType");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_SupplierAgbType"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0W47( ) ;
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
            EndLevel0W47( ) ;
         }
         CloseExtendedTableCursors0W47( ) ;
      }

      protected void DeferredUpdate0W47( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0W47( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W47( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0W47( ) ;
            AfterConfirm0W47( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0W47( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000W8 */
                  pr_default.execute(6, new Object[] {A255SupplierAgbTypeId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_SupplierAgbType");
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
         sMode47 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0W47( ) ;
         Gx_mode = sMode47;
      }

      protected void OnDeleteControls0W47( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000W9 */
            pr_default.execute(7, new Object[] {A255SupplierAgbTypeId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "AGB Suppliers", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0W47( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0W47( ) ;
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

      public void ScanKeyStart0W47( )
      {
         /* Scan By routine */
         /* Using cursor BC000W10 */
         pr_default.execute(8, new Object[] {A255SupplierAgbTypeId});
         RcdFound47 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound47 = 1;
            A255SupplierAgbTypeId = BC000W10_A255SupplierAgbTypeId[0];
            A256SupplierAgbTypeName = BC000W10_A256SupplierAgbTypeName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0W47( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound47 = 0;
         ScanKeyLoad0W47( ) ;
      }

      protected void ScanKeyLoad0W47( )
      {
         sMode47 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound47 = 1;
            A255SupplierAgbTypeId = BC000W10_A255SupplierAgbTypeId[0];
            A256SupplierAgbTypeName = BC000W10_A256SupplierAgbTypeName[0];
         }
         Gx_mode = sMode47;
      }

      protected void ScanKeyEnd0W47( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0W47( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0W47( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0W47( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0W47( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0W47( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0W47( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0W47( )
      {
      }

      protected void send_integrity_lvl_hashes0W47( )
      {
      }

      protected void AddRow0W47( )
      {
         VarsToRow47( bcTrn_SupplierAgbType) ;
      }

      protected void ReadRow0W47( )
      {
         RowToVars47( bcTrn_SupplierAgbType, 1) ;
      }

      protected void InitializeNonKey0W47( )
      {
         A256SupplierAgbTypeName = "";
         Z256SupplierAgbTypeName = "";
      }

      protected void InitAll0W47( )
      {
         A255SupplierAgbTypeId = Guid.NewGuid( );
         InitializeNonKey0W47( ) ;
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

      public void VarsToRow47( SdtTrn_SupplierAgbType obj47 )
      {
         obj47.gxTpr_Mode = Gx_mode;
         obj47.gxTpr_Supplieragbtypename = A256SupplierAgbTypeName;
         obj47.gxTpr_Supplieragbtypeid = A255SupplierAgbTypeId;
         obj47.gxTpr_Supplieragbtypeid_Z = Z255SupplierAgbTypeId;
         obj47.gxTpr_Supplieragbtypename_Z = Z256SupplierAgbTypeName;
         obj47.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow47( SdtTrn_SupplierAgbType obj47 )
      {
         obj47.gxTpr_Supplieragbtypeid = A255SupplierAgbTypeId;
         return  ;
      }

      public void RowToVars47( SdtTrn_SupplierAgbType obj47 ,
                               int forceLoad )
      {
         Gx_mode = obj47.gxTpr_Mode;
         A256SupplierAgbTypeName = obj47.gxTpr_Supplieragbtypename;
         A255SupplierAgbTypeId = obj47.gxTpr_Supplieragbtypeid;
         Z255SupplierAgbTypeId = obj47.gxTpr_Supplieragbtypeid_Z;
         Z256SupplierAgbTypeName = obj47.gxTpr_Supplieragbtypename_Z;
         Gx_mode = obj47.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A255SupplierAgbTypeId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0W47( ) ;
         ScanKeyStart0W47( ) ;
         if ( RcdFound47 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z255SupplierAgbTypeId = A255SupplierAgbTypeId;
         }
         ZM0W47( -4) ;
         OnLoadActions0W47( ) ;
         AddRow0W47( ) ;
         ScanKeyEnd0W47( ) ;
         if ( RcdFound47 == 0 )
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
         RowToVars47( bcTrn_SupplierAgbType, 0) ;
         ScanKeyStart0W47( ) ;
         if ( RcdFound47 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z255SupplierAgbTypeId = A255SupplierAgbTypeId;
         }
         ZM0W47( -4) ;
         OnLoadActions0W47( ) ;
         AddRow0W47( ) ;
         ScanKeyEnd0W47( ) ;
         if ( RcdFound47 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0W47( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0W47( ) ;
         }
         else
         {
            if ( RcdFound47 == 1 )
            {
               if ( A255SupplierAgbTypeId != Z255SupplierAgbTypeId )
               {
                  A255SupplierAgbTypeId = Z255SupplierAgbTypeId;
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
                  Update0W47( ) ;
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
                  if ( A255SupplierAgbTypeId != Z255SupplierAgbTypeId )
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
                        Insert0W47( ) ;
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
                        Insert0W47( ) ;
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
         RowToVars47( bcTrn_SupplierAgbType, 1) ;
         SaveImpl( ) ;
         VarsToRow47( bcTrn_SupplierAgbType) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars47( bcTrn_SupplierAgbType, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0W47( ) ;
         AfterTrn( ) ;
         VarsToRow47( bcTrn_SupplierAgbType) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow47( bcTrn_SupplierAgbType) ;
         }
         else
         {
            SdtTrn_SupplierAgbType auxBC = new SdtTrn_SupplierAgbType(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A255SupplierAgbTypeId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_SupplierAgbType);
               auxBC.Save();
               bcTrn_SupplierAgbType.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars47( bcTrn_SupplierAgbType, 1) ;
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
         RowToVars47( bcTrn_SupplierAgbType, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0W47( ) ;
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
               VarsToRow47( bcTrn_SupplierAgbType) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow47( bcTrn_SupplierAgbType) ;
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
         RowToVars47( bcTrn_SupplierAgbType, 0) ;
         GetKey0W47( ) ;
         if ( RcdFound47 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A255SupplierAgbTypeId != Z255SupplierAgbTypeId )
            {
               A255SupplierAgbTypeId = Z255SupplierAgbTypeId;
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
            if ( A255SupplierAgbTypeId != Z255SupplierAgbTypeId )
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
         context.RollbackDataStores("trn_supplieragbtype_bc",pr_default);
         VarsToRow47( bcTrn_SupplierAgbType) ;
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
         Gx_mode = bcTrn_SupplierAgbType.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_SupplierAgbType.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_SupplierAgbType )
         {
            bcTrn_SupplierAgbType = (SdtTrn_SupplierAgbType)(sdt);
            if ( StringUtil.StrCmp(bcTrn_SupplierAgbType.gxTpr_Mode, "") == 0 )
            {
               bcTrn_SupplierAgbType.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow47( bcTrn_SupplierAgbType) ;
            }
            else
            {
               RowToVars47( bcTrn_SupplierAgbType, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_SupplierAgbType.gxTpr_Mode, "") == 0 )
            {
               bcTrn_SupplierAgbType.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars47( bcTrn_SupplierAgbType, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_SupplierAgbType Trn_SupplierAgbType_BC
      {
         get {
            return bcTrn_SupplierAgbType ;
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
            return "trn_supplieragbtype_Execute" ;
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
         Z255SupplierAgbTypeId = Guid.Empty;
         A255SupplierAgbTypeId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z256SupplierAgbTypeName = "";
         A256SupplierAgbTypeName = "";
         BC000W4_A255SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         BC000W4_A256SupplierAgbTypeName = new string[] {""} ;
         BC000W5_A255SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         BC000W3_A255SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         BC000W3_A256SupplierAgbTypeName = new string[] {""} ;
         sMode47 = "";
         BC000W2_A255SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         BC000W2_A256SupplierAgbTypeName = new string[] {""} ;
         BC000W9_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         BC000W10_A255SupplierAgbTypeId = new Guid[] {Guid.Empty} ;
         BC000W10_A256SupplierAgbTypeName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_supplieragbtype_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_supplieragbtype_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_supplieragbtype_bc__default(),
            new Object[][] {
                new Object[] {
               BC000W2_A255SupplierAgbTypeId, BC000W2_A256SupplierAgbTypeName
               }
               , new Object[] {
               BC000W3_A255SupplierAgbTypeId, BC000W3_A256SupplierAgbTypeName
               }
               , new Object[] {
               BC000W4_A255SupplierAgbTypeId, BC000W4_A256SupplierAgbTypeName
               }
               , new Object[] {
               BC000W5_A255SupplierAgbTypeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000W9_A49SupplierAgbId
               }
               , new Object[] {
               BC000W10_A255SupplierAgbTypeId, BC000W10_A256SupplierAgbTypeName
               }
            }
         );
         Z255SupplierAgbTypeId = Guid.NewGuid( );
         A255SupplierAgbTypeId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120W2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound47 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode47 ;
      private bool returnInSub ;
      private string Z256SupplierAgbTypeName ;
      private string A256SupplierAgbTypeName ;
      private Guid Z255SupplierAgbTypeId ;
      private Guid A255SupplierAgbTypeId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC000W4_A255SupplierAgbTypeId ;
      private string[] BC000W4_A256SupplierAgbTypeName ;
      private Guid[] BC000W5_A255SupplierAgbTypeId ;
      private Guid[] BC000W3_A255SupplierAgbTypeId ;
      private string[] BC000W3_A256SupplierAgbTypeName ;
      private Guid[] BC000W2_A255SupplierAgbTypeId ;
      private string[] BC000W2_A256SupplierAgbTypeName ;
      private Guid[] BC000W9_A49SupplierAgbId ;
      private Guid[] BC000W10_A255SupplierAgbTypeId ;
      private string[] BC000W10_A256SupplierAgbTypeName ;
      private SdtTrn_SupplierAgbType bcTrn_SupplierAgbType ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_supplieragbtype_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_supplieragbtype_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_supplieragbtype_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC000W2;
       prmBC000W2 = new Object[] {
       new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W3;
       prmBC000W3 = new Object[] {
       new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W4;
       prmBC000W4 = new Object[] {
       new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W5;
       prmBC000W5 = new Object[] {
       new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W6;
       prmBC000W6 = new Object[] {
       new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierAgbTypeName",GXType.VarChar,100,0)
       };
       Object[] prmBC000W7;
       prmBC000W7 = new Object[] {
       new ParDef("SupplierAgbTypeName",GXType.VarChar,100,0) ,
       new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W8;
       prmBC000W8 = new Object[] {
       new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W9;
       prmBC000W9 = new Object[] {
       new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000W10;
       prmBC000W10 = new Object[] {
       new ParDef("SupplierAgbTypeId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC000W2", "SELECT SupplierAgbTypeId, SupplierAgbTypeName FROM Trn_SupplierAgbType WHERE SupplierAgbTypeId = :SupplierAgbTypeId  FOR UPDATE OF Trn_SupplierAgbType",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W3", "SELECT SupplierAgbTypeId, SupplierAgbTypeName FROM Trn_SupplierAgbType WHERE SupplierAgbTypeId = :SupplierAgbTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W4", "SELECT TM1.SupplierAgbTypeId, TM1.SupplierAgbTypeName FROM Trn_SupplierAgbType TM1 WHERE TM1.SupplierAgbTypeId = :SupplierAgbTypeId ORDER BY TM1.SupplierAgbTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W5", "SELECT SupplierAgbTypeId FROM Trn_SupplierAgbType WHERE SupplierAgbTypeId = :SupplierAgbTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000W6", "SAVEPOINT gxupdate;INSERT INTO Trn_SupplierAgbType(SupplierAgbTypeId, SupplierAgbTypeName) VALUES(:SupplierAgbTypeId, :SupplierAgbTypeName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000W6)
          ,new CursorDef("BC000W7", "SAVEPOINT gxupdate;UPDATE Trn_SupplierAgbType SET SupplierAgbTypeName=:SupplierAgbTypeName  WHERE SupplierAgbTypeId = :SupplierAgbTypeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000W7)
          ,new CursorDef("BC000W8", "SAVEPOINT gxupdate;DELETE FROM Trn_SupplierAgbType  WHERE SupplierAgbTypeId = :SupplierAgbTypeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000W8)
          ,new CursorDef("BC000W9", "SELECT SupplierAgbId FROM Trn_SupplierAGB WHERE SupplierAgbTypeId = :SupplierAgbTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000W10", "SELECT TM1.SupplierAgbTypeId, TM1.SupplierAgbTypeName FROM Trn_SupplierAgbType TM1 WHERE TM1.SupplierAgbTypeId = :SupplierAgbTypeId ORDER BY TM1.SupplierAgbTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W10,100, GxCacheFrequency.OFF ,true,false )
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
