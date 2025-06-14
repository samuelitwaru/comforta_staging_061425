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
   public class trn_memocategory_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_memocategory_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_memocategory_bc( IGxContext context )
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
         ReadRow1N98( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1N98( ) ;
         standaloneModal( ) ;
         AddRow1N98( ) ;
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
            E111N2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z542MemoCategoryId = A542MemoCategoryId;
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

      protected void CONFIRM_1N0( )
      {
         BeforeValidate1N98( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1N98( ) ;
            }
            else
            {
               CheckExtendedTable1N98( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1N98( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121N2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E111N2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1N98( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z543MemoCategoryName = A543MemoCategoryName;
         }
         if ( GX_JID == -3 )
         {
            Z542MemoCategoryId = A542MemoCategoryId;
            Z543MemoCategoryName = A543MemoCategoryName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A542MemoCategoryId) )
         {
            A542MemoCategoryId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1N98( )
      {
         /* Using cursor BC001N4 */
         pr_default.execute(2, new Object[] {A542MemoCategoryId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound98 = 1;
            A543MemoCategoryName = BC001N4_A543MemoCategoryName[0];
            ZM1N98( -3) ;
         }
         pr_default.close(2);
         OnLoadActions1N98( ) ;
      }

      protected void OnLoadActions1N98( )
      {
      }

      protected void CheckExtendedTable1N98( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1N98( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1N98( )
      {
         /* Using cursor BC001N5 */
         pr_default.execute(3, new Object[] {A542MemoCategoryId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound98 = 1;
         }
         else
         {
            RcdFound98 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001N3 */
         pr_default.execute(1, new Object[] {A542MemoCategoryId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1N98( 3) ;
            RcdFound98 = 1;
            A542MemoCategoryId = BC001N3_A542MemoCategoryId[0];
            A543MemoCategoryName = BC001N3_A543MemoCategoryName[0];
            Z542MemoCategoryId = A542MemoCategoryId;
            sMode98 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1N98( ) ;
            if ( AnyError == 1 )
            {
               RcdFound98 = 0;
               InitializeNonKey1N98( ) ;
            }
            Gx_mode = sMode98;
         }
         else
         {
            RcdFound98 = 0;
            InitializeNonKey1N98( ) ;
            sMode98 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode98;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1N98( ) ;
         if ( RcdFound98 == 0 )
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
         CONFIRM_1N0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1N98( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001N2 */
            pr_default.execute(0, new Object[] {A542MemoCategoryId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_MemoCategory"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z543MemoCategoryName, BC001N2_A543MemoCategoryName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_MemoCategory"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1N98( )
      {
         BeforeValidate1N98( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1N98( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1N98( 0) ;
            CheckOptimisticConcurrency1N98( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1N98( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1N98( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001N6 */
                     pr_default.execute(4, new Object[] {A542MemoCategoryId, A543MemoCategoryName});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_MemoCategory");
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
               Load1N98( ) ;
            }
            EndLevel1N98( ) ;
         }
         CloseExtendedTableCursors1N98( ) ;
      }

      protected void Update1N98( )
      {
         BeforeValidate1N98( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1N98( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1N98( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1N98( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1N98( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001N7 */
                     pr_default.execute(5, new Object[] {A543MemoCategoryName, A542MemoCategoryId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_MemoCategory");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_MemoCategory"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1N98( ) ;
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
            EndLevel1N98( ) ;
         }
         CloseExtendedTableCursors1N98( ) ;
      }

      protected void DeferredUpdate1N98( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1N98( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1N98( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1N98( ) ;
            AfterConfirm1N98( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1N98( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001N8 */
                  pr_default.execute(6, new Object[] {A542MemoCategoryId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_MemoCategory");
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
         sMode98 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1N98( ) ;
         Gx_mode = sMode98;
      }

      protected void OnDeleteControls1N98( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1N98( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1N98( ) ;
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

      public void ScanKeyStart1N98( )
      {
         /* Scan By routine */
         /* Using cursor BC001N9 */
         pr_default.execute(7, new Object[] {A542MemoCategoryId});
         RcdFound98 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound98 = 1;
            A542MemoCategoryId = BC001N9_A542MemoCategoryId[0];
            A543MemoCategoryName = BC001N9_A543MemoCategoryName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1N98( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound98 = 0;
         ScanKeyLoad1N98( ) ;
      }

      protected void ScanKeyLoad1N98( )
      {
         sMode98 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound98 = 1;
            A542MemoCategoryId = BC001N9_A542MemoCategoryId[0];
            A543MemoCategoryName = BC001N9_A543MemoCategoryName[0];
         }
         Gx_mode = sMode98;
      }

      protected void ScanKeyEnd1N98( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm1N98( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1N98( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1N98( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1N98( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1N98( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1N98( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1N98( )
      {
      }

      protected void send_integrity_lvl_hashes1N98( )
      {
      }

      protected void AddRow1N98( )
      {
         VarsToRow98( bcTrn_MemoCategory) ;
      }

      protected void ReadRow1N98( )
      {
         RowToVars98( bcTrn_MemoCategory, 1) ;
      }

      protected void InitializeNonKey1N98( )
      {
         A543MemoCategoryName = "";
         Z543MemoCategoryName = "";
      }

      protected void InitAll1N98( )
      {
         A542MemoCategoryId = Guid.NewGuid( );
         InitializeNonKey1N98( ) ;
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

      public void VarsToRow98( SdtTrn_MemoCategory obj98 )
      {
         obj98.gxTpr_Mode = Gx_mode;
         obj98.gxTpr_Memocategoryname = A543MemoCategoryName;
         obj98.gxTpr_Memocategoryid = A542MemoCategoryId;
         obj98.gxTpr_Memocategoryid_Z = Z542MemoCategoryId;
         obj98.gxTpr_Memocategoryname_Z = Z543MemoCategoryName;
         obj98.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow98( SdtTrn_MemoCategory obj98 )
      {
         obj98.gxTpr_Memocategoryid = A542MemoCategoryId;
         return  ;
      }

      public void RowToVars98( SdtTrn_MemoCategory obj98 ,
                               int forceLoad )
      {
         Gx_mode = obj98.gxTpr_Mode;
         A543MemoCategoryName = obj98.gxTpr_Memocategoryname;
         A542MemoCategoryId = obj98.gxTpr_Memocategoryid;
         Z542MemoCategoryId = obj98.gxTpr_Memocategoryid_Z;
         Z543MemoCategoryName = obj98.gxTpr_Memocategoryname_Z;
         Gx_mode = obj98.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A542MemoCategoryId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1N98( ) ;
         ScanKeyStart1N98( ) ;
         if ( RcdFound98 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z542MemoCategoryId = A542MemoCategoryId;
         }
         ZM1N98( -3) ;
         OnLoadActions1N98( ) ;
         AddRow1N98( ) ;
         ScanKeyEnd1N98( ) ;
         if ( RcdFound98 == 0 )
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
         RowToVars98( bcTrn_MemoCategory, 0) ;
         ScanKeyStart1N98( ) ;
         if ( RcdFound98 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z542MemoCategoryId = A542MemoCategoryId;
         }
         ZM1N98( -3) ;
         OnLoadActions1N98( ) ;
         AddRow1N98( ) ;
         ScanKeyEnd1N98( ) ;
         if ( RcdFound98 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1N98( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1N98( ) ;
         }
         else
         {
            if ( RcdFound98 == 1 )
            {
               if ( A542MemoCategoryId != Z542MemoCategoryId )
               {
                  A542MemoCategoryId = Z542MemoCategoryId;
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
                  Update1N98( ) ;
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
                  if ( A542MemoCategoryId != Z542MemoCategoryId )
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
                        Insert1N98( ) ;
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
                        Insert1N98( ) ;
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
         RowToVars98( bcTrn_MemoCategory, 1) ;
         SaveImpl( ) ;
         VarsToRow98( bcTrn_MemoCategory) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars98( bcTrn_MemoCategory, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1N98( ) ;
         AfterTrn( ) ;
         VarsToRow98( bcTrn_MemoCategory) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow98( bcTrn_MemoCategory) ;
         }
         else
         {
            SdtTrn_MemoCategory auxBC = new SdtTrn_MemoCategory(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A542MemoCategoryId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_MemoCategory);
               auxBC.Save();
               bcTrn_MemoCategory.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars98( bcTrn_MemoCategory, 1) ;
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
         RowToVars98( bcTrn_MemoCategory, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1N98( ) ;
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
               VarsToRow98( bcTrn_MemoCategory) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow98( bcTrn_MemoCategory) ;
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
         RowToVars98( bcTrn_MemoCategory, 0) ;
         GetKey1N98( ) ;
         if ( RcdFound98 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A542MemoCategoryId != Z542MemoCategoryId )
            {
               A542MemoCategoryId = Z542MemoCategoryId;
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
            if ( A542MemoCategoryId != Z542MemoCategoryId )
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
         context.RollbackDataStores("trn_memocategory_bc",pr_default);
         VarsToRow98( bcTrn_MemoCategory) ;
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
         Gx_mode = bcTrn_MemoCategory.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_MemoCategory.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_MemoCategory )
         {
            bcTrn_MemoCategory = (SdtTrn_MemoCategory)(sdt);
            if ( StringUtil.StrCmp(bcTrn_MemoCategory.gxTpr_Mode, "") == 0 )
            {
               bcTrn_MemoCategory.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow98( bcTrn_MemoCategory) ;
            }
            else
            {
               RowToVars98( bcTrn_MemoCategory, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_MemoCategory.gxTpr_Mode, "") == 0 )
            {
               bcTrn_MemoCategory.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars98( bcTrn_MemoCategory, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_MemoCategory Trn_MemoCategory_BC
      {
         get {
            return bcTrn_MemoCategory ;
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
            return "trn_memocategory_Execute" ;
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
         Z542MemoCategoryId = Guid.Empty;
         A542MemoCategoryId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z543MemoCategoryName = "";
         A543MemoCategoryName = "";
         BC001N4_A542MemoCategoryId = new Guid[] {Guid.Empty} ;
         BC001N4_A543MemoCategoryName = new string[] {""} ;
         BC001N5_A542MemoCategoryId = new Guid[] {Guid.Empty} ;
         BC001N3_A542MemoCategoryId = new Guid[] {Guid.Empty} ;
         BC001N3_A543MemoCategoryName = new string[] {""} ;
         sMode98 = "";
         BC001N2_A542MemoCategoryId = new Guid[] {Guid.Empty} ;
         BC001N2_A543MemoCategoryName = new string[] {""} ;
         BC001N9_A542MemoCategoryId = new Guid[] {Guid.Empty} ;
         BC001N9_A543MemoCategoryName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_memocategory_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_memocategory_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_memocategory_bc__default(),
            new Object[][] {
                new Object[] {
               BC001N2_A542MemoCategoryId, BC001N2_A543MemoCategoryName
               }
               , new Object[] {
               BC001N3_A542MemoCategoryId, BC001N3_A543MemoCategoryName
               }
               , new Object[] {
               BC001N4_A542MemoCategoryId, BC001N4_A543MemoCategoryName
               }
               , new Object[] {
               BC001N5_A542MemoCategoryId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001N9_A542MemoCategoryId, BC001N9_A543MemoCategoryName
               }
            }
         );
         Z542MemoCategoryId = Guid.NewGuid( );
         A542MemoCategoryId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121N2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound98 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode98 ;
      private bool returnInSub ;
      private string Z543MemoCategoryName ;
      private string A543MemoCategoryName ;
      private Guid Z542MemoCategoryId ;
      private Guid A542MemoCategoryId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001N4_A542MemoCategoryId ;
      private string[] BC001N4_A543MemoCategoryName ;
      private Guid[] BC001N5_A542MemoCategoryId ;
      private Guid[] BC001N3_A542MemoCategoryId ;
      private string[] BC001N3_A543MemoCategoryName ;
      private Guid[] BC001N2_A542MemoCategoryId ;
      private string[] BC001N2_A543MemoCategoryName ;
      private Guid[] BC001N9_A542MemoCategoryId ;
      private string[] BC001N9_A543MemoCategoryName ;
      private SdtTrn_MemoCategory bcTrn_MemoCategory ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_memocategory_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_memocategory_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_memocategory_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC001N2;
       prmBC001N2 = new Object[] {
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001N3;
       prmBC001N3 = new Object[] {
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001N4;
       prmBC001N4 = new Object[] {
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001N5;
       prmBC001N5 = new Object[] {
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001N6;
       prmBC001N6 = new Object[] {
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("MemoCategoryName",GXType.VarChar,100,0)
       };
       Object[] prmBC001N7;
       prmBC001N7 = new Object[] {
       new ParDef("MemoCategoryName",GXType.VarChar,100,0) ,
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001N8;
       prmBC001N8 = new Object[] {
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001N9;
       prmBC001N9 = new Object[] {
       new ParDef("MemoCategoryId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001N2", "SELECT MemoCategoryId, MemoCategoryName FROM Trn_MemoCategory WHERE MemoCategoryId = :MemoCategoryId  FOR UPDATE OF Trn_MemoCategory",true, GxErrorMask.GX_NOMASK, false, this,prmBC001N2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001N3", "SELECT MemoCategoryId, MemoCategoryName FROM Trn_MemoCategory WHERE MemoCategoryId = :MemoCategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001N3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001N4", "SELECT TM1.MemoCategoryId, TM1.MemoCategoryName FROM Trn_MemoCategory TM1 WHERE TM1.MemoCategoryId = :MemoCategoryId ORDER BY TM1.MemoCategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001N4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001N5", "SELECT MemoCategoryId FROM Trn_MemoCategory WHERE MemoCategoryId = :MemoCategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001N5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001N6", "SAVEPOINT gxupdate;INSERT INTO Trn_MemoCategory(MemoCategoryId, MemoCategoryName) VALUES(:MemoCategoryId, :MemoCategoryName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001N6)
          ,new CursorDef("BC001N7", "SAVEPOINT gxupdate;UPDATE Trn_MemoCategory SET MemoCategoryName=:MemoCategoryName  WHERE MemoCategoryId = :MemoCategoryId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001N7)
          ,new CursorDef("BC001N8", "SAVEPOINT gxupdate;DELETE FROM Trn_MemoCategory  WHERE MemoCategoryId = :MemoCategoryId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001N8)
          ,new CursorDef("BC001N9", "SELECT TM1.MemoCategoryId, TM1.MemoCategoryName FROM Trn_MemoCategory TM1 WHERE TM1.MemoCategoryId = :MemoCategoryId ORDER BY TM1.MemoCategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001N9,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
    }
 }

}

}
