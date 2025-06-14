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
   public class trn_residenttype_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_residenttype_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_residenttype_bc( IGxContext context )
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
         ReadRow0D22( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0D22( ) ;
         standaloneModal( ) ;
         AddRow0D22( ) ;
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
            E110D2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z96ResidentTypeId = A96ResidentTypeId;
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

      protected void CONFIRM_0D0( )
      {
         BeforeValidate0D22( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0D22( ) ;
            }
            else
            {
               CheckExtendedTable0D22( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0D22( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120D2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110D2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0D22( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z97ResidentTypeName = A97ResidentTypeName;
         }
         if ( GX_JID == -4 )
         {
            Z96ResidentTypeId = A96ResidentTypeId;
            Z97ResidentTypeName = A97ResidentTypeName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A96ResidentTypeId) )
         {
            A96ResidentTypeId = Guid.NewGuid( );
            n96ResidentTypeId = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0D22( )
      {
         /* Using cursor BC000D4 */
         pr_default.execute(2, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound22 = 1;
            A97ResidentTypeName = BC000D4_A97ResidentTypeName[0];
            ZM0D22( -4) ;
         }
         pr_default.close(2);
         OnLoadActions0D22( ) ;
      }

      protected void OnLoadActions0D22( )
      {
      }

      protected void CheckExtendedTable0D22( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A97ResidentTypeName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Resident Type Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0D22( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0D22( )
      {
         /* Using cursor BC000D5 */
         pr_default.execute(3, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound22 = 1;
         }
         else
         {
            RcdFound22 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000D3 */
         pr_default.execute(1, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0D22( 4) ;
            RcdFound22 = 1;
            A96ResidentTypeId = BC000D3_A96ResidentTypeId[0];
            n96ResidentTypeId = BC000D3_n96ResidentTypeId[0];
            A97ResidentTypeName = BC000D3_A97ResidentTypeName[0];
            Z96ResidentTypeId = A96ResidentTypeId;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0D22( ) ;
            if ( AnyError == 1 )
            {
               RcdFound22 = 0;
               InitializeNonKey0D22( ) ;
            }
            Gx_mode = sMode22;
         }
         else
         {
            RcdFound22 = 0;
            InitializeNonKey0D22( ) ;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode22;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0D22( ) ;
         if ( RcdFound22 == 0 )
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
         CONFIRM_0D0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0D22( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000D2 */
            pr_default.execute(0, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ResidentType"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z97ResidentTypeName, BC000D2_A97ResidentTypeName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ResidentType"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D22( )
      {
         BeforeValidate0D22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D22( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D22( 0) ;
            CheckOptimisticConcurrency0D22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D6 */
                     pr_default.execute(4, new Object[] {n96ResidentTypeId, A96ResidentTypeId, A97ResidentTypeName});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentType");
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
               Load0D22( ) ;
            }
            EndLevel0D22( ) ;
         }
         CloseExtendedTableCursors0D22( ) ;
      }

      protected void Update0D22( )
      {
         BeforeValidate0D22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D22( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0D22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D7 */
                     pr_default.execute(5, new Object[] {A97ResidentTypeName, n96ResidentTypeId, A96ResidentTypeId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentType");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ResidentType"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0D22( ) ;
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
            EndLevel0D22( ) ;
         }
         CloseExtendedTableCursors0D22( ) ;
      }

      protected void DeferredUpdate0D22( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0D22( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D22( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D22( ) ;
            AfterConfirm0D22( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D22( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000D8 */
                  pr_default.execute(6, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentType");
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
         sMode22 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0D22( ) ;
         Gx_mode = sMode22;
      }

      protected void OnDeleteControls0D22( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000D9 */
            pr_default.execute(7, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Resident", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0D22( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0D22( ) ;
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

      public void ScanKeyStart0D22( )
      {
         /* Scan By routine */
         /* Using cursor BC000D10 */
         pr_default.execute(8, new Object[] {n96ResidentTypeId, A96ResidentTypeId});
         RcdFound22 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound22 = 1;
            A96ResidentTypeId = BC000D10_A96ResidentTypeId[0];
            n96ResidentTypeId = BC000D10_n96ResidentTypeId[0];
            A97ResidentTypeName = BC000D10_A97ResidentTypeName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0D22( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound22 = 0;
         ScanKeyLoad0D22( ) ;
      }

      protected void ScanKeyLoad0D22( )
      {
         sMode22 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound22 = 1;
            A96ResidentTypeId = BC000D10_A96ResidentTypeId[0];
            n96ResidentTypeId = BC000D10_n96ResidentTypeId[0];
            A97ResidentTypeName = BC000D10_A97ResidentTypeName[0];
         }
         Gx_mode = sMode22;
      }

      protected void ScanKeyEnd0D22( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0D22( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0D22( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D22( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D22( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D22( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D22( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D22( )
      {
      }

      protected void send_integrity_lvl_hashes0D22( )
      {
      }

      protected void AddRow0D22( )
      {
         VarsToRow22( bcTrn_ResidentType) ;
      }

      protected void ReadRow0D22( )
      {
         RowToVars22( bcTrn_ResidentType, 1) ;
      }

      protected void InitializeNonKey0D22( )
      {
         A97ResidentTypeName = "";
         Z97ResidentTypeName = "";
      }

      protected void InitAll0D22( )
      {
         A96ResidentTypeId = Guid.NewGuid( );
         n96ResidentTypeId = false;
         InitializeNonKey0D22( ) ;
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

      public void VarsToRow22( SdtTrn_ResidentType obj22 )
      {
         obj22.gxTpr_Mode = Gx_mode;
         obj22.gxTpr_Residenttypename = A97ResidentTypeName;
         obj22.gxTpr_Residenttypeid = A96ResidentTypeId;
         obj22.gxTpr_Residenttypeid_Z = Z96ResidentTypeId;
         obj22.gxTpr_Residenttypename_Z = Z97ResidentTypeName;
         obj22.gxTpr_Residenttypeid_N = (short)(Convert.ToInt16(n96ResidentTypeId));
         obj22.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow22( SdtTrn_ResidentType obj22 )
      {
         obj22.gxTpr_Residenttypeid = A96ResidentTypeId;
         return  ;
      }

      public void RowToVars22( SdtTrn_ResidentType obj22 ,
                               int forceLoad )
      {
         Gx_mode = obj22.gxTpr_Mode;
         A97ResidentTypeName = obj22.gxTpr_Residenttypename;
         A96ResidentTypeId = obj22.gxTpr_Residenttypeid;
         n96ResidentTypeId = false;
         Z96ResidentTypeId = obj22.gxTpr_Residenttypeid_Z;
         Z97ResidentTypeName = obj22.gxTpr_Residenttypename_Z;
         n96ResidentTypeId = (bool)(Convert.ToBoolean(obj22.gxTpr_Residenttypeid_N));
         Gx_mode = obj22.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A96ResidentTypeId = (Guid)getParm(obj,0);
         n96ResidentTypeId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0D22( ) ;
         ScanKeyStart0D22( ) ;
         if ( RcdFound22 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z96ResidentTypeId = A96ResidentTypeId;
         }
         ZM0D22( -4) ;
         OnLoadActions0D22( ) ;
         AddRow0D22( ) ;
         ScanKeyEnd0D22( ) ;
         if ( RcdFound22 == 0 )
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
         RowToVars22( bcTrn_ResidentType, 0) ;
         ScanKeyStart0D22( ) ;
         if ( RcdFound22 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z96ResidentTypeId = A96ResidentTypeId;
         }
         ZM0D22( -4) ;
         OnLoadActions0D22( ) ;
         AddRow0D22( ) ;
         ScanKeyEnd0D22( ) ;
         if ( RcdFound22 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0D22( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0D22( ) ;
         }
         else
         {
            if ( RcdFound22 == 1 )
            {
               if ( A96ResidentTypeId != Z96ResidentTypeId )
               {
                  A96ResidentTypeId = Z96ResidentTypeId;
                  n96ResidentTypeId = false;
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
                  Update0D22( ) ;
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
                  if ( A96ResidentTypeId != Z96ResidentTypeId )
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
                        Insert0D22( ) ;
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
                        Insert0D22( ) ;
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
         RowToVars22( bcTrn_ResidentType, 1) ;
         SaveImpl( ) ;
         VarsToRow22( bcTrn_ResidentType) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars22( bcTrn_ResidentType, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0D22( ) ;
         AfterTrn( ) ;
         VarsToRow22( bcTrn_ResidentType) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow22( bcTrn_ResidentType) ;
         }
         else
         {
            SdtTrn_ResidentType auxBC = new SdtTrn_ResidentType(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A96ResidentTypeId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_ResidentType);
               auxBC.Save();
               bcTrn_ResidentType.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars22( bcTrn_ResidentType, 1) ;
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
         RowToVars22( bcTrn_ResidentType, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0D22( ) ;
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
               VarsToRow22( bcTrn_ResidentType) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow22( bcTrn_ResidentType) ;
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
         RowToVars22( bcTrn_ResidentType, 0) ;
         GetKey0D22( ) ;
         if ( RcdFound22 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A96ResidentTypeId != Z96ResidentTypeId )
            {
               A96ResidentTypeId = Z96ResidentTypeId;
               n96ResidentTypeId = false;
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
            if ( A96ResidentTypeId != Z96ResidentTypeId )
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
         context.RollbackDataStores("trn_residenttype_bc",pr_default);
         VarsToRow22( bcTrn_ResidentType) ;
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
         Gx_mode = bcTrn_ResidentType.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_ResidentType.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_ResidentType )
         {
            bcTrn_ResidentType = (SdtTrn_ResidentType)(sdt);
            if ( StringUtil.StrCmp(bcTrn_ResidentType.gxTpr_Mode, "") == 0 )
            {
               bcTrn_ResidentType.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow22( bcTrn_ResidentType) ;
            }
            else
            {
               RowToVars22( bcTrn_ResidentType, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_ResidentType.gxTpr_Mode, "") == 0 )
            {
               bcTrn_ResidentType.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars22( bcTrn_ResidentType, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_ResidentType Trn_ResidentType_BC
      {
         get {
            return bcTrn_ResidentType ;
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
            return "trn_residenttype_Execute" ;
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
         Z96ResidentTypeId = Guid.Empty;
         A96ResidentTypeId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z97ResidentTypeName = "";
         A97ResidentTypeName = "";
         BC000D4_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         BC000D4_n96ResidentTypeId = new bool[] {false} ;
         BC000D4_A97ResidentTypeName = new string[] {""} ;
         BC000D5_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         BC000D5_n96ResidentTypeId = new bool[] {false} ;
         BC000D3_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         BC000D3_n96ResidentTypeId = new bool[] {false} ;
         BC000D3_A97ResidentTypeName = new string[] {""} ;
         sMode22 = "";
         BC000D2_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         BC000D2_n96ResidentTypeId = new bool[] {false} ;
         BC000D2_A97ResidentTypeName = new string[] {""} ;
         BC000D9_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC000D9_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000D9_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000D10_A96ResidentTypeId = new Guid[] {Guid.Empty} ;
         BC000D10_n96ResidentTypeId = new bool[] {false} ;
         BC000D10_A97ResidentTypeName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_residenttype_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_residenttype_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_residenttype_bc__default(),
            new Object[][] {
                new Object[] {
               BC000D2_A96ResidentTypeId, BC000D2_A97ResidentTypeName
               }
               , new Object[] {
               BC000D3_A96ResidentTypeId, BC000D3_A97ResidentTypeName
               }
               , new Object[] {
               BC000D4_A96ResidentTypeId, BC000D4_A97ResidentTypeName
               }
               , new Object[] {
               BC000D5_A96ResidentTypeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000D9_A62ResidentId, BC000D9_A29LocationId, BC000D9_A11OrganisationId
               }
               , new Object[] {
               BC000D10_A96ResidentTypeId, BC000D10_A97ResidentTypeName
               }
            }
         );
         Z96ResidentTypeId = Guid.NewGuid( );
         n96ResidentTypeId = false;
         A96ResidentTypeId = Guid.NewGuid( );
         n96ResidentTypeId = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120D2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound22 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode22 ;
      private bool returnInSub ;
      private bool n96ResidentTypeId ;
      private string Z97ResidentTypeName ;
      private string A97ResidentTypeName ;
      private Guid Z96ResidentTypeId ;
      private Guid A96ResidentTypeId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC000D4_A96ResidentTypeId ;
      private bool[] BC000D4_n96ResidentTypeId ;
      private string[] BC000D4_A97ResidentTypeName ;
      private Guid[] BC000D5_A96ResidentTypeId ;
      private bool[] BC000D5_n96ResidentTypeId ;
      private Guid[] BC000D3_A96ResidentTypeId ;
      private bool[] BC000D3_n96ResidentTypeId ;
      private string[] BC000D3_A97ResidentTypeName ;
      private Guid[] BC000D2_A96ResidentTypeId ;
      private bool[] BC000D2_n96ResidentTypeId ;
      private string[] BC000D2_A97ResidentTypeName ;
      private Guid[] BC000D9_A62ResidentId ;
      private Guid[] BC000D9_A29LocationId ;
      private Guid[] BC000D9_A11OrganisationId ;
      private Guid[] BC000D10_A96ResidentTypeId ;
      private bool[] BC000D10_n96ResidentTypeId ;
      private string[] BC000D10_A97ResidentTypeName ;
      private SdtTrn_ResidentType bcTrn_ResidentType ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_residenttype_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_residenttype_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_residenttype_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC000D2;
       prmBC000D2 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000D3;
       prmBC000D3 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000D4;
       prmBC000D4 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000D5;
       prmBC000D5 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000D6;
       prmBC000D6 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ResidentTypeName",GXType.VarChar,100,0)
       };
       Object[] prmBC000D7;
       prmBC000D7 = new Object[] {
       new ParDef("ResidentTypeName",GXType.VarChar,100,0) ,
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000D8;
       prmBC000D8 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000D9;
       prmBC000D9 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000D10;
       prmBC000D10 = new Object[] {
       new ParDef("ResidentTypeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       def= new CursorDef[] {
           new CursorDef("BC000D2", "SELECT ResidentTypeId, ResidentTypeName FROM Trn_ResidentType WHERE ResidentTypeId = :ResidentTypeId  FOR UPDATE OF Trn_ResidentType",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000D3", "SELECT ResidentTypeId, ResidentTypeName FROM Trn_ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000D4", "SELECT TM1.ResidentTypeId, TM1.ResidentTypeName FROM Trn_ResidentType TM1 WHERE TM1.ResidentTypeId = :ResidentTypeId ORDER BY TM1.ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000D5", "SELECT ResidentTypeId FROM Trn_ResidentType WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000D6", "SAVEPOINT gxupdate;INSERT INTO Trn_ResidentType(ResidentTypeId, ResidentTypeName) VALUES(:ResidentTypeId, :ResidentTypeName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000D6)
          ,new CursorDef("BC000D7", "SAVEPOINT gxupdate;UPDATE Trn_ResidentType SET ResidentTypeName=:ResidentTypeName  WHERE ResidentTypeId = :ResidentTypeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000D7)
          ,new CursorDef("BC000D8", "SAVEPOINT gxupdate;DELETE FROM Trn_ResidentType  WHERE ResidentTypeId = :ResidentTypeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000D8)
          ,new CursorDef("BC000D9", "SELECT ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE ResidentTypeId = :ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000D10", "SELECT TM1.ResidentTypeId, TM1.ResidentTypeName FROM Trn_ResidentType TM1 WHERE TM1.ResidentTypeId = :ResidentTypeId ORDER BY TM1.ResidentTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D10,100, GxCacheFrequency.OFF ,true,false )
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
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
    }
 }

}

}
