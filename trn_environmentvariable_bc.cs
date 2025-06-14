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
   public class trn_environmentvariable_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_environmentvariable_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_environmentvariable_bc( IGxContext context )
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
         ReadRow1W107( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1W107( ) ;
         standaloneModal( ) ;
         AddRow1W107( ) ;
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
            E111W2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z632EnvironmentVariableId = A632EnvironmentVariableId;
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

      protected void CONFIRM_1W0( )
      {
         BeforeValidate1W107( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1W107( ) ;
            }
            else
            {
               CheckExtendedTable1W107( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1W107( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121W2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E111W2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1W107( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z633EnvironmentVariableKey = A633EnvironmentVariableKey;
         }
         if ( GX_JID == -3 )
         {
            Z632EnvironmentVariableId = A632EnvironmentVariableId;
            Z633EnvironmentVariableKey = A633EnvironmentVariableKey;
            Z634EnvironmentVariableValue = A634EnvironmentVariableValue;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A632EnvironmentVariableId) )
         {
            A632EnvironmentVariableId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1W107( )
      {
         /* Using cursor BC001W4 */
         pr_default.execute(2, new Object[] {A632EnvironmentVariableId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound107 = 1;
            A633EnvironmentVariableKey = BC001W4_A633EnvironmentVariableKey[0];
            A634EnvironmentVariableValue = BC001W4_A634EnvironmentVariableValue[0];
            ZM1W107( -3) ;
         }
         pr_default.close(2);
         OnLoadActions1W107( ) ;
      }

      protected void OnLoadActions1W107( )
      {
      }

      protected void CheckExtendedTable1W107( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001W5 */
         pr_default.execute(3, new Object[] {A633EnvironmentVariableKey, A632EnvironmentVariableId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Environment Variable Key", "")}), 1, "");
            AnyError = 1;
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1W107( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1W107( )
      {
         /* Using cursor BC001W6 */
         pr_default.execute(4, new Object[] {A632EnvironmentVariableId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound107 = 1;
         }
         else
         {
            RcdFound107 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001W3 */
         pr_default.execute(1, new Object[] {A632EnvironmentVariableId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1W107( 3) ;
            RcdFound107 = 1;
            A632EnvironmentVariableId = BC001W3_A632EnvironmentVariableId[0];
            A633EnvironmentVariableKey = BC001W3_A633EnvironmentVariableKey[0];
            A634EnvironmentVariableValue = BC001W3_A634EnvironmentVariableValue[0];
            Z632EnvironmentVariableId = A632EnvironmentVariableId;
            sMode107 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1W107( ) ;
            if ( AnyError == 1 )
            {
               RcdFound107 = 0;
               InitializeNonKey1W107( ) ;
            }
            Gx_mode = sMode107;
         }
         else
         {
            RcdFound107 = 0;
            InitializeNonKey1W107( ) ;
            sMode107 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode107;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1W107( ) ;
         if ( RcdFound107 == 0 )
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
         CONFIRM_1W0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1W107( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001W2 */
            pr_default.execute(0, new Object[] {A632EnvironmentVariableId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_EnvironmentVariable"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z633EnvironmentVariableKey, BC001W2_A633EnvironmentVariableKey[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_EnvironmentVariable"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1W107( )
      {
         BeforeValidate1W107( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1W107( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1W107( 0) ;
            CheckOptimisticConcurrency1W107( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1W107( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1W107( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001W7 */
                     pr_default.execute(5, new Object[] {A632EnvironmentVariableId, A633EnvironmentVariableKey, A634EnvironmentVariableValue});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_EnvironmentVariable");
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
               Load1W107( ) ;
            }
            EndLevel1W107( ) ;
         }
         CloseExtendedTableCursors1W107( ) ;
      }

      protected void Update1W107( )
      {
         BeforeValidate1W107( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1W107( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1W107( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1W107( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1W107( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001W8 */
                     pr_default.execute(6, new Object[] {A633EnvironmentVariableKey, A634EnvironmentVariableValue, A632EnvironmentVariableId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_EnvironmentVariable");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_EnvironmentVariable"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1W107( ) ;
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
            EndLevel1W107( ) ;
         }
         CloseExtendedTableCursors1W107( ) ;
      }

      protected void DeferredUpdate1W107( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1W107( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1W107( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1W107( ) ;
            AfterConfirm1W107( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1W107( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001W9 */
                  pr_default.execute(7, new Object[] {A632EnvironmentVariableId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_EnvironmentVariable");
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
         sMode107 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1W107( ) ;
         Gx_mode = sMode107;
      }

      protected void OnDeleteControls1W107( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1W107( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1W107( ) ;
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

      public void ScanKeyStart1W107( )
      {
         /* Scan By routine */
         /* Using cursor BC001W10 */
         pr_default.execute(8, new Object[] {A632EnvironmentVariableId});
         RcdFound107 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound107 = 1;
            A632EnvironmentVariableId = BC001W10_A632EnvironmentVariableId[0];
            A633EnvironmentVariableKey = BC001W10_A633EnvironmentVariableKey[0];
            A634EnvironmentVariableValue = BC001W10_A634EnvironmentVariableValue[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1W107( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound107 = 0;
         ScanKeyLoad1W107( ) ;
      }

      protected void ScanKeyLoad1W107( )
      {
         sMode107 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound107 = 1;
            A632EnvironmentVariableId = BC001W10_A632EnvironmentVariableId[0];
            A633EnvironmentVariableKey = BC001W10_A633EnvironmentVariableKey[0];
            A634EnvironmentVariableValue = BC001W10_A634EnvironmentVariableValue[0];
         }
         Gx_mode = sMode107;
      }

      protected void ScanKeyEnd1W107( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1W107( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1W107( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1W107( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1W107( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1W107( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1W107( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1W107( )
      {
      }

      protected void send_integrity_lvl_hashes1W107( )
      {
      }

      protected void AddRow1W107( )
      {
         VarsToRow107( bcTrn_EnvironmentVariable) ;
      }

      protected void ReadRow1W107( )
      {
         RowToVars107( bcTrn_EnvironmentVariable, 1) ;
      }

      protected void InitializeNonKey1W107( )
      {
         A633EnvironmentVariableKey = "";
         A634EnvironmentVariableValue = "";
         Z633EnvironmentVariableKey = "";
      }

      protected void InitAll1W107( )
      {
         A632EnvironmentVariableId = Guid.NewGuid( );
         InitializeNonKey1W107( ) ;
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

      public void VarsToRow107( SdtTrn_EnvironmentVariable obj107 )
      {
         obj107.gxTpr_Mode = Gx_mode;
         obj107.gxTpr_Environmentvariablekey = A633EnvironmentVariableKey;
         obj107.gxTpr_Environmentvariablevalue = A634EnvironmentVariableValue;
         obj107.gxTpr_Environmentvariableid = A632EnvironmentVariableId;
         obj107.gxTpr_Environmentvariableid_Z = Z632EnvironmentVariableId;
         obj107.gxTpr_Environmentvariablekey_Z = Z633EnvironmentVariableKey;
         obj107.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow107( SdtTrn_EnvironmentVariable obj107 )
      {
         obj107.gxTpr_Environmentvariableid = A632EnvironmentVariableId;
         return  ;
      }

      public void RowToVars107( SdtTrn_EnvironmentVariable obj107 ,
                                int forceLoad )
      {
         Gx_mode = obj107.gxTpr_Mode;
         A633EnvironmentVariableKey = obj107.gxTpr_Environmentvariablekey;
         A634EnvironmentVariableValue = obj107.gxTpr_Environmentvariablevalue;
         A632EnvironmentVariableId = obj107.gxTpr_Environmentvariableid;
         Z632EnvironmentVariableId = obj107.gxTpr_Environmentvariableid_Z;
         Z633EnvironmentVariableKey = obj107.gxTpr_Environmentvariablekey_Z;
         Gx_mode = obj107.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A632EnvironmentVariableId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1W107( ) ;
         ScanKeyStart1W107( ) ;
         if ( RcdFound107 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z632EnvironmentVariableId = A632EnvironmentVariableId;
         }
         ZM1W107( -3) ;
         OnLoadActions1W107( ) ;
         AddRow1W107( ) ;
         ScanKeyEnd1W107( ) ;
         if ( RcdFound107 == 0 )
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
         RowToVars107( bcTrn_EnvironmentVariable, 0) ;
         ScanKeyStart1W107( ) ;
         if ( RcdFound107 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z632EnvironmentVariableId = A632EnvironmentVariableId;
         }
         ZM1W107( -3) ;
         OnLoadActions1W107( ) ;
         AddRow1W107( ) ;
         ScanKeyEnd1W107( ) ;
         if ( RcdFound107 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1W107( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1W107( ) ;
         }
         else
         {
            if ( RcdFound107 == 1 )
            {
               if ( A632EnvironmentVariableId != Z632EnvironmentVariableId )
               {
                  A632EnvironmentVariableId = Z632EnvironmentVariableId;
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
                  Update1W107( ) ;
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
                  if ( A632EnvironmentVariableId != Z632EnvironmentVariableId )
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
                        Insert1W107( ) ;
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
                        Insert1W107( ) ;
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
         RowToVars107( bcTrn_EnvironmentVariable, 1) ;
         SaveImpl( ) ;
         VarsToRow107( bcTrn_EnvironmentVariable) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars107( bcTrn_EnvironmentVariable, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1W107( ) ;
         AfterTrn( ) ;
         VarsToRow107( bcTrn_EnvironmentVariable) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow107( bcTrn_EnvironmentVariable) ;
         }
         else
         {
            SdtTrn_EnvironmentVariable auxBC = new SdtTrn_EnvironmentVariable(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A632EnvironmentVariableId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_EnvironmentVariable);
               auxBC.Save();
               bcTrn_EnvironmentVariable.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars107( bcTrn_EnvironmentVariable, 1) ;
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
         RowToVars107( bcTrn_EnvironmentVariable, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1W107( ) ;
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
               VarsToRow107( bcTrn_EnvironmentVariable) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow107( bcTrn_EnvironmentVariable) ;
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
         RowToVars107( bcTrn_EnvironmentVariable, 0) ;
         GetKey1W107( ) ;
         if ( RcdFound107 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A632EnvironmentVariableId != Z632EnvironmentVariableId )
            {
               A632EnvironmentVariableId = Z632EnvironmentVariableId;
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
            if ( A632EnvironmentVariableId != Z632EnvironmentVariableId )
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
         context.RollbackDataStores("trn_environmentvariable_bc",pr_default);
         VarsToRow107( bcTrn_EnvironmentVariable) ;
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
         Gx_mode = bcTrn_EnvironmentVariable.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_EnvironmentVariable.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_EnvironmentVariable )
         {
            bcTrn_EnvironmentVariable = (SdtTrn_EnvironmentVariable)(sdt);
            if ( StringUtil.StrCmp(bcTrn_EnvironmentVariable.gxTpr_Mode, "") == 0 )
            {
               bcTrn_EnvironmentVariable.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow107( bcTrn_EnvironmentVariable) ;
            }
            else
            {
               RowToVars107( bcTrn_EnvironmentVariable, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_EnvironmentVariable.gxTpr_Mode, "") == 0 )
            {
               bcTrn_EnvironmentVariable.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars107( bcTrn_EnvironmentVariable, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_EnvironmentVariable Trn_EnvironmentVariable_BC
      {
         get {
            return bcTrn_EnvironmentVariable ;
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
            return "trn_environmentvariable_Execute" ;
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
         Z632EnvironmentVariableId = Guid.Empty;
         A632EnvironmentVariableId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11WebSession = context.GetSession();
         Z633EnvironmentVariableKey = "";
         A633EnvironmentVariableKey = "";
         Z634EnvironmentVariableValue = "";
         A634EnvironmentVariableValue = "";
         BC001W4_A632EnvironmentVariableId = new Guid[] {Guid.Empty} ;
         BC001W4_A633EnvironmentVariableKey = new string[] {""} ;
         BC001W4_A634EnvironmentVariableValue = new string[] {""} ;
         BC001W5_A633EnvironmentVariableKey = new string[] {""} ;
         BC001W6_A632EnvironmentVariableId = new Guid[] {Guid.Empty} ;
         BC001W3_A632EnvironmentVariableId = new Guid[] {Guid.Empty} ;
         BC001W3_A633EnvironmentVariableKey = new string[] {""} ;
         BC001W3_A634EnvironmentVariableValue = new string[] {""} ;
         sMode107 = "";
         BC001W2_A632EnvironmentVariableId = new Guid[] {Guid.Empty} ;
         BC001W2_A633EnvironmentVariableKey = new string[] {""} ;
         BC001W2_A634EnvironmentVariableValue = new string[] {""} ;
         BC001W10_A632EnvironmentVariableId = new Guid[] {Guid.Empty} ;
         BC001W10_A633EnvironmentVariableKey = new string[] {""} ;
         BC001W10_A634EnvironmentVariableValue = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_environmentvariable_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_environmentvariable_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_environmentvariable_bc__default(),
            new Object[][] {
                new Object[] {
               BC001W2_A632EnvironmentVariableId, BC001W2_A633EnvironmentVariableKey, BC001W2_A634EnvironmentVariableValue
               }
               , new Object[] {
               BC001W3_A632EnvironmentVariableId, BC001W3_A633EnvironmentVariableKey, BC001W3_A634EnvironmentVariableValue
               }
               , new Object[] {
               BC001W4_A632EnvironmentVariableId, BC001W4_A633EnvironmentVariableKey, BC001W4_A634EnvironmentVariableValue
               }
               , new Object[] {
               BC001W5_A633EnvironmentVariableKey
               }
               , new Object[] {
               BC001W6_A632EnvironmentVariableId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001W10_A632EnvironmentVariableId, BC001W10_A633EnvironmentVariableKey, BC001W10_A634EnvironmentVariableValue
               }
            }
         );
         Z632EnvironmentVariableId = Guid.NewGuid( );
         A632EnvironmentVariableId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121W2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound107 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode107 ;
      private bool returnInSub ;
      private string Z634EnvironmentVariableValue ;
      private string A634EnvironmentVariableValue ;
      private string Z633EnvironmentVariableKey ;
      private string A633EnvironmentVariableKey ;
      private Guid Z632EnvironmentVariableId ;
      private Guid A632EnvironmentVariableId ;
      private IGxSession AV11WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV10TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001W4_A632EnvironmentVariableId ;
      private string[] BC001W4_A633EnvironmentVariableKey ;
      private string[] BC001W4_A634EnvironmentVariableValue ;
      private string[] BC001W5_A633EnvironmentVariableKey ;
      private Guid[] BC001W6_A632EnvironmentVariableId ;
      private Guid[] BC001W3_A632EnvironmentVariableId ;
      private string[] BC001W3_A633EnvironmentVariableKey ;
      private string[] BC001W3_A634EnvironmentVariableValue ;
      private Guid[] BC001W2_A632EnvironmentVariableId ;
      private string[] BC001W2_A633EnvironmentVariableKey ;
      private string[] BC001W2_A634EnvironmentVariableValue ;
      private Guid[] BC001W10_A632EnvironmentVariableId ;
      private string[] BC001W10_A633EnvironmentVariableKey ;
      private string[] BC001W10_A634EnvironmentVariableValue ;
      private SdtTrn_EnvironmentVariable bcTrn_EnvironmentVariable ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_environmentvariable_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_environmentvariable_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_environmentvariable_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC001W2;
       prmBC001W2 = new Object[] {
       new ParDef("EnvironmentVariableId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001W3;
       prmBC001W3 = new Object[] {
       new ParDef("EnvironmentVariableId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001W4;
       prmBC001W4 = new Object[] {
       new ParDef("EnvironmentVariableId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001W5;
       prmBC001W5 = new Object[] {
       new ParDef("EnvironmentVariableKey",GXType.VarChar,400,0) ,
       new ParDef("EnvironmentVariableId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001W6;
       prmBC001W6 = new Object[] {
       new ParDef("EnvironmentVariableId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001W7;
       prmBC001W7 = new Object[] {
       new ParDef("EnvironmentVariableId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("EnvironmentVariableKey",GXType.VarChar,400,0) ,
       new ParDef("EnvironmentVariableValue",GXType.LongVarChar,2097152,0)
       };
       Object[] prmBC001W8;
       prmBC001W8 = new Object[] {
       new ParDef("EnvironmentVariableKey",GXType.VarChar,400,0) ,
       new ParDef("EnvironmentVariableValue",GXType.LongVarChar,2097152,0) ,
       new ParDef("EnvironmentVariableId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001W9;
       prmBC001W9 = new Object[] {
       new ParDef("EnvironmentVariableId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001W10;
       prmBC001W10 = new Object[] {
       new ParDef("EnvironmentVariableId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001W2", "SELECT EnvironmentVariableId, EnvironmentVariableKey, EnvironmentVariableValue FROM Trn_EnvironmentVariable WHERE EnvironmentVariableId = :EnvironmentVariableId  FOR UPDATE OF Trn_EnvironmentVariable",true, GxErrorMask.GX_NOMASK, false, this,prmBC001W2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001W3", "SELECT EnvironmentVariableId, EnvironmentVariableKey, EnvironmentVariableValue FROM Trn_EnvironmentVariable WHERE EnvironmentVariableId = :EnvironmentVariableId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001W3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001W4", "SELECT TM1.EnvironmentVariableId, TM1.EnvironmentVariableKey, TM1.EnvironmentVariableValue FROM Trn_EnvironmentVariable TM1 WHERE TM1.EnvironmentVariableId = :EnvironmentVariableId ORDER BY TM1.EnvironmentVariableId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001W4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001W5", "SELECT EnvironmentVariableKey FROM Trn_EnvironmentVariable WHERE (EnvironmentVariableKey = :EnvironmentVariableKey) AND (Not ( EnvironmentVariableId = :EnvironmentVariableId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001W5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001W6", "SELECT EnvironmentVariableId FROM Trn_EnvironmentVariable WHERE EnvironmentVariableId = :EnvironmentVariableId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001W6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001W7", "SAVEPOINT gxupdate;INSERT INTO Trn_EnvironmentVariable(EnvironmentVariableId, EnvironmentVariableKey, EnvironmentVariableValue) VALUES(:EnvironmentVariableId, :EnvironmentVariableKey, :EnvironmentVariableValue);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001W7)
          ,new CursorDef("BC001W8", "SAVEPOINT gxupdate;UPDATE Trn_EnvironmentVariable SET EnvironmentVariableKey=:EnvironmentVariableKey, EnvironmentVariableValue=:EnvironmentVariableValue  WHERE EnvironmentVariableId = :EnvironmentVariableId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001W8)
          ,new CursorDef("BC001W9", "SAVEPOINT gxupdate;DELETE FROM Trn_EnvironmentVariable  WHERE EnvironmentVariableId = :EnvironmentVariableId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001W9)
          ,new CursorDef("BC001W10", "SELECT TM1.EnvironmentVariableId, TM1.EnvironmentVariableKey, TM1.EnvironmentVariableValue FROM Trn_EnvironmentVariable TM1 WHERE TM1.EnvironmentVariableId = :EnvironmentVariableId ORDER BY TM1.EnvironmentVariableId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001W10,100, GxCacheFrequency.OFF ,true,false )
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
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             return;
    }
 }

}

}
