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
   public class trn_croppedmedia_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_croppedmedia_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_croppedmedia_bc( IGxContext context )
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
         ReadRow1X108( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1X108( ) ;
         standaloneModal( ) ;
         AddRow1X108( ) ;
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
            E111X2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z644CroppedMediaId = A644CroppedMediaId;
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

      protected void CONFIRM_1X0( )
      {
         BeforeValidate1X108( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1X108( ) ;
            }
            else
            {
               CheckExtendedTable1X108( ) ;
               if ( AnyError == 0 )
               {
                  ZM1X108( 5) ;
               }
               CloseExtendedTableCursors1X108( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121X2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E111X2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1X108( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z645CroppedMediaName = A645CroppedMediaName;
            Z413MediaId = A413MediaId;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -4 )
         {
            Z644CroppedMediaId = A644CroppedMediaId;
            Z645CroppedMediaName = A645CroppedMediaName;
            Z413MediaId = A413MediaId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A644CroppedMediaId) )
         {
            A644CroppedMediaId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1X108( )
      {
         /* Using cursor BC001X5 */
         pr_default.execute(3, new Object[] {A644CroppedMediaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound108 = 1;
            A645CroppedMediaName = BC001X5_A645CroppedMediaName[0];
            A413MediaId = BC001X5_A413MediaId[0];
            ZM1X108( -4) ;
         }
         pr_default.close(3);
         OnLoadActions1X108( ) ;
      }

      protected void OnLoadActions1X108( )
      {
      }

      protected void CheckExtendedTable1X108( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001X4 */
         pr_default.execute(2, new Object[] {A413MediaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Media", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDIAID");
            AnyError = 1;
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1X108( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1X108( )
      {
         /* Using cursor BC001X6 */
         pr_default.execute(4, new Object[] {A644CroppedMediaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound108 = 1;
         }
         else
         {
            RcdFound108 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001X3 */
         pr_default.execute(1, new Object[] {A644CroppedMediaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1X108( 4) ;
            RcdFound108 = 1;
            A644CroppedMediaId = BC001X3_A644CroppedMediaId[0];
            A645CroppedMediaName = BC001X3_A645CroppedMediaName[0];
            A413MediaId = BC001X3_A413MediaId[0];
            Z644CroppedMediaId = A644CroppedMediaId;
            sMode108 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1X108( ) ;
            if ( AnyError == 1 )
            {
               RcdFound108 = 0;
               InitializeNonKey1X108( ) ;
            }
            Gx_mode = sMode108;
         }
         else
         {
            RcdFound108 = 0;
            InitializeNonKey1X108( ) ;
            sMode108 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode108;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1X108( ) ;
         if ( RcdFound108 == 0 )
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
         CONFIRM_1X0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1X108( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001X2 */
            pr_default.execute(0, new Object[] {A644CroppedMediaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_CroppedMedia"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z645CroppedMediaName, BC001X2_A645CroppedMediaName[0]) != 0 ) || ( Z413MediaId != BC001X2_A413MediaId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_CroppedMedia"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1X108( )
      {
         BeforeValidate1X108( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1X108( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1X108( 0) ;
            CheckOptimisticConcurrency1X108( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1X108( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1X108( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001X7 */
                     pr_default.execute(5, new Object[] {A644CroppedMediaId, A645CroppedMediaName, A413MediaId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_CroppedMedia");
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
               Load1X108( ) ;
            }
            EndLevel1X108( ) ;
         }
         CloseExtendedTableCursors1X108( ) ;
      }

      protected void Update1X108( )
      {
         BeforeValidate1X108( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1X108( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1X108( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1X108( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1X108( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001X8 */
                     pr_default.execute(6, new Object[] {A645CroppedMediaName, A413MediaId, A644CroppedMediaId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_CroppedMedia");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_CroppedMedia"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1X108( ) ;
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
            EndLevel1X108( ) ;
         }
         CloseExtendedTableCursors1X108( ) ;
      }

      protected void DeferredUpdate1X108( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1X108( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1X108( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1X108( ) ;
            AfterConfirm1X108( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1X108( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001X9 */
                  pr_default.execute(7, new Object[] {A644CroppedMediaId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_CroppedMedia");
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
         sMode108 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1X108( ) ;
         Gx_mode = sMode108;
      }

      protected void OnDeleteControls1X108( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1X108( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1X108( ) ;
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

      public void ScanKeyStart1X108( )
      {
         /* Scan By routine */
         /* Using cursor BC001X10 */
         pr_default.execute(8, new Object[] {A644CroppedMediaId});
         RcdFound108 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound108 = 1;
            A644CroppedMediaId = BC001X10_A644CroppedMediaId[0];
            A645CroppedMediaName = BC001X10_A645CroppedMediaName[0];
            A413MediaId = BC001X10_A413MediaId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1X108( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound108 = 0;
         ScanKeyLoad1X108( ) ;
      }

      protected void ScanKeyLoad1X108( )
      {
         sMode108 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound108 = 1;
            A644CroppedMediaId = BC001X10_A644CroppedMediaId[0];
            A645CroppedMediaName = BC001X10_A645CroppedMediaName[0];
            A413MediaId = BC001X10_A413MediaId[0];
         }
         Gx_mode = sMode108;
      }

      protected void ScanKeyEnd1X108( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1X108( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1X108( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1X108( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1X108( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1X108( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1X108( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1X108( )
      {
      }

      protected void send_integrity_lvl_hashes1X108( )
      {
      }

      protected void AddRow1X108( )
      {
         VarsToRow108( bcTrn_CroppedMedia) ;
      }

      protected void ReadRow1X108( )
      {
         RowToVars108( bcTrn_CroppedMedia, 1) ;
      }

      protected void InitializeNonKey1X108( )
      {
         A413MediaId = Guid.Empty;
         A645CroppedMediaName = "";
         Z645CroppedMediaName = "";
         Z413MediaId = Guid.Empty;
      }

      protected void InitAll1X108( )
      {
         A644CroppedMediaId = Guid.NewGuid( );
         InitializeNonKey1X108( ) ;
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

      public void VarsToRow108( SdtTrn_CroppedMedia obj108 )
      {
         obj108.gxTpr_Mode = Gx_mode;
         obj108.gxTpr_Mediaid = A413MediaId;
         obj108.gxTpr_Croppedmedianame = A645CroppedMediaName;
         obj108.gxTpr_Croppedmediaid = A644CroppedMediaId;
         obj108.gxTpr_Croppedmediaid_Z = Z644CroppedMediaId;
         obj108.gxTpr_Mediaid_Z = Z413MediaId;
         obj108.gxTpr_Croppedmedianame_Z = Z645CroppedMediaName;
         obj108.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow108( SdtTrn_CroppedMedia obj108 )
      {
         obj108.gxTpr_Croppedmediaid = A644CroppedMediaId;
         return  ;
      }

      public void RowToVars108( SdtTrn_CroppedMedia obj108 ,
                                int forceLoad )
      {
         Gx_mode = obj108.gxTpr_Mode;
         A413MediaId = obj108.gxTpr_Mediaid;
         A645CroppedMediaName = obj108.gxTpr_Croppedmedianame;
         A644CroppedMediaId = obj108.gxTpr_Croppedmediaid;
         Z644CroppedMediaId = obj108.gxTpr_Croppedmediaid_Z;
         Z413MediaId = obj108.gxTpr_Mediaid_Z;
         Z645CroppedMediaName = obj108.gxTpr_Croppedmedianame_Z;
         Gx_mode = obj108.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A644CroppedMediaId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1X108( ) ;
         ScanKeyStart1X108( ) ;
         if ( RcdFound108 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z644CroppedMediaId = A644CroppedMediaId;
         }
         ZM1X108( -4) ;
         OnLoadActions1X108( ) ;
         AddRow1X108( ) ;
         ScanKeyEnd1X108( ) ;
         if ( RcdFound108 == 0 )
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
         RowToVars108( bcTrn_CroppedMedia, 0) ;
         ScanKeyStart1X108( ) ;
         if ( RcdFound108 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z644CroppedMediaId = A644CroppedMediaId;
         }
         ZM1X108( -4) ;
         OnLoadActions1X108( ) ;
         AddRow1X108( ) ;
         ScanKeyEnd1X108( ) ;
         if ( RcdFound108 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1X108( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1X108( ) ;
         }
         else
         {
            if ( RcdFound108 == 1 )
            {
               if ( A644CroppedMediaId != Z644CroppedMediaId )
               {
                  A644CroppedMediaId = Z644CroppedMediaId;
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
                  Update1X108( ) ;
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
                  if ( A644CroppedMediaId != Z644CroppedMediaId )
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
                        Insert1X108( ) ;
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
                        Insert1X108( ) ;
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
         RowToVars108( bcTrn_CroppedMedia, 1) ;
         SaveImpl( ) ;
         VarsToRow108( bcTrn_CroppedMedia) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars108( bcTrn_CroppedMedia, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1X108( ) ;
         AfterTrn( ) ;
         VarsToRow108( bcTrn_CroppedMedia) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow108( bcTrn_CroppedMedia) ;
         }
         else
         {
            SdtTrn_CroppedMedia auxBC = new SdtTrn_CroppedMedia(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A644CroppedMediaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_CroppedMedia);
               auxBC.Save();
               bcTrn_CroppedMedia.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars108( bcTrn_CroppedMedia, 1) ;
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
         RowToVars108( bcTrn_CroppedMedia, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1X108( ) ;
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
               VarsToRow108( bcTrn_CroppedMedia) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow108( bcTrn_CroppedMedia) ;
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
         RowToVars108( bcTrn_CroppedMedia, 0) ;
         GetKey1X108( ) ;
         if ( RcdFound108 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A644CroppedMediaId != Z644CroppedMediaId )
            {
               A644CroppedMediaId = Z644CroppedMediaId;
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
            if ( A644CroppedMediaId != Z644CroppedMediaId )
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
         context.RollbackDataStores("trn_croppedmedia_bc",pr_default);
         VarsToRow108( bcTrn_CroppedMedia) ;
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
         Gx_mode = bcTrn_CroppedMedia.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_CroppedMedia.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_CroppedMedia )
         {
            bcTrn_CroppedMedia = (SdtTrn_CroppedMedia)(sdt);
            if ( StringUtil.StrCmp(bcTrn_CroppedMedia.gxTpr_Mode, "") == 0 )
            {
               bcTrn_CroppedMedia.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow108( bcTrn_CroppedMedia) ;
            }
            else
            {
               RowToVars108( bcTrn_CroppedMedia, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_CroppedMedia.gxTpr_Mode, "") == 0 )
            {
               bcTrn_CroppedMedia.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars108( bcTrn_CroppedMedia, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_CroppedMedia Trn_CroppedMedia_BC
      {
         get {
            return bcTrn_CroppedMedia ;
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
            return "trn_media_Execute" ;
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
         Z644CroppedMediaId = Guid.Empty;
         A644CroppedMediaId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z645CroppedMediaName = "";
         A645CroppedMediaName = "";
         Z413MediaId = Guid.Empty;
         A413MediaId = Guid.Empty;
         BC001X5_A644CroppedMediaId = new Guid[] {Guid.Empty} ;
         BC001X5_A645CroppedMediaName = new string[] {""} ;
         BC001X5_A413MediaId = new Guid[] {Guid.Empty} ;
         BC001X4_A413MediaId = new Guid[] {Guid.Empty} ;
         BC001X6_A644CroppedMediaId = new Guid[] {Guid.Empty} ;
         BC001X3_A644CroppedMediaId = new Guid[] {Guid.Empty} ;
         BC001X3_A645CroppedMediaName = new string[] {""} ;
         BC001X3_A413MediaId = new Guid[] {Guid.Empty} ;
         sMode108 = "";
         BC001X2_A644CroppedMediaId = new Guid[] {Guid.Empty} ;
         BC001X2_A645CroppedMediaName = new string[] {""} ;
         BC001X2_A413MediaId = new Guid[] {Guid.Empty} ;
         BC001X10_A644CroppedMediaId = new Guid[] {Guid.Empty} ;
         BC001X10_A645CroppedMediaName = new string[] {""} ;
         BC001X10_A413MediaId = new Guid[] {Guid.Empty} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_croppedmedia_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_croppedmedia_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_croppedmedia_bc__default(),
            new Object[][] {
                new Object[] {
               BC001X2_A644CroppedMediaId, BC001X2_A645CroppedMediaName, BC001X2_A413MediaId
               }
               , new Object[] {
               BC001X3_A644CroppedMediaId, BC001X3_A645CroppedMediaName, BC001X3_A413MediaId
               }
               , new Object[] {
               BC001X4_A413MediaId
               }
               , new Object[] {
               BC001X5_A644CroppedMediaId, BC001X5_A645CroppedMediaName, BC001X5_A413MediaId
               }
               , new Object[] {
               BC001X6_A644CroppedMediaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001X10_A644CroppedMediaId, BC001X10_A645CroppedMediaName, BC001X10_A413MediaId
               }
            }
         );
         Z644CroppedMediaId = Guid.NewGuid( );
         A644CroppedMediaId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121X2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound108 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode108 ;
      private bool returnInSub ;
      private string Z645CroppedMediaName ;
      private string A645CroppedMediaName ;
      private Guid Z644CroppedMediaId ;
      private Guid A644CroppedMediaId ;
      private Guid Z413MediaId ;
      private Guid A413MediaId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001X5_A644CroppedMediaId ;
      private string[] BC001X5_A645CroppedMediaName ;
      private Guid[] BC001X5_A413MediaId ;
      private Guid[] BC001X4_A413MediaId ;
      private Guid[] BC001X6_A644CroppedMediaId ;
      private Guid[] BC001X3_A644CroppedMediaId ;
      private string[] BC001X3_A645CroppedMediaName ;
      private Guid[] BC001X3_A413MediaId ;
      private Guid[] BC001X2_A644CroppedMediaId ;
      private string[] BC001X2_A645CroppedMediaName ;
      private Guid[] BC001X2_A413MediaId ;
      private Guid[] BC001X10_A644CroppedMediaId ;
      private string[] BC001X10_A645CroppedMediaName ;
      private Guid[] BC001X10_A413MediaId ;
      private SdtTrn_CroppedMedia bcTrn_CroppedMedia ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_croppedmedia_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_croppedmedia_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_croppedmedia_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC001X2;
       prmBC001X2 = new Object[] {
       new ParDef("CroppedMediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001X3;
       prmBC001X3 = new Object[] {
       new ParDef("CroppedMediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001X4;
       prmBC001X4 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001X5;
       prmBC001X5 = new Object[] {
       new ParDef("CroppedMediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001X6;
       prmBC001X6 = new Object[] {
       new ParDef("CroppedMediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001X7;
       prmBC001X7 = new Object[] {
       new ParDef("CroppedMediaId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CroppedMediaName",GXType.VarChar,100,0) ,
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001X8;
       prmBC001X8 = new Object[] {
       new ParDef("CroppedMediaName",GXType.VarChar,100,0) ,
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CroppedMediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001X9;
       prmBC001X9 = new Object[] {
       new ParDef("CroppedMediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001X10;
       prmBC001X10 = new Object[] {
       new ParDef("CroppedMediaId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001X2", "SELECT CroppedMediaId, CroppedMediaName, MediaId FROM Trn_CroppedMedia WHERE CroppedMediaId = :CroppedMediaId  FOR UPDATE OF Trn_CroppedMedia",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001X3", "SELECT CroppedMediaId, CroppedMediaName, MediaId FROM Trn_CroppedMedia WHERE CroppedMediaId = :CroppedMediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001X4", "SELECT MediaId FROM Trn_Media WHERE MediaId = :MediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001X5", "SELECT TM1.CroppedMediaId, TM1.CroppedMediaName, TM1.MediaId FROM Trn_CroppedMedia TM1 WHERE TM1.CroppedMediaId = :CroppedMediaId ORDER BY TM1.CroppedMediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001X6", "SELECT CroppedMediaId FROM Trn_CroppedMedia WHERE CroppedMediaId = :CroppedMediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001X7", "SAVEPOINT gxupdate;INSERT INTO Trn_CroppedMedia(CroppedMediaId, CroppedMediaName, MediaId) VALUES(:CroppedMediaId, :CroppedMediaName, :MediaId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001X7)
          ,new CursorDef("BC001X8", "SAVEPOINT gxupdate;UPDATE Trn_CroppedMedia SET CroppedMediaName=:CroppedMediaName, MediaId=:MediaId  WHERE CroppedMediaId = :CroppedMediaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001X8)
          ,new CursorDef("BC001X9", "SAVEPOINT gxupdate;DELETE FROM Trn_CroppedMedia  WHERE CroppedMediaId = :CroppedMediaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001X9)
          ,new CursorDef("BC001X10", "SELECT TM1.CroppedMediaId, TM1.CroppedMediaName, TM1.MediaId FROM Trn_CroppedMedia TM1 WHERE TM1.CroppedMediaId = :CroppedMediaId ORDER BY TM1.CroppedMediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X10,100, GxCacheFrequency.OFF ,true,false )
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
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
    }
 }

}

}
