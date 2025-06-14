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
   public class trn_serviceimage_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_serviceimage_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_serviceimage_bc( IGxContext context )
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
         ReadRow1T104( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1T104( ) ;
         standaloneModal( ) ;
         AddRow1T104( ) ;
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
               Z608ServiceImageId = A608ServiceImageId;
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

      protected void CONFIRM_1T0( )
      {
         BeforeValidate1T104( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1T104( ) ;
            }
            else
            {
               CheckExtendedTable1T104( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1T104( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1T104( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z609ServiceId = A609ServiceId;
         }
         if ( GX_JID == -4 )
         {
            Z608ServiceImageId = A608ServiceImageId;
            Z609ServiceId = A609ServiceId;
            Z611ServiceImage = A611ServiceImage;
            Z40000ServiceImage_GXI = A40000ServiceImage_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A608ServiceImageId) )
         {
            A608ServiceImageId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1T104( )
      {
         /* Using cursor BC001T4 */
         pr_default.execute(2, new Object[] {A608ServiceImageId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound104 = 1;
            A609ServiceId = BC001T4_A609ServiceId[0];
            A40000ServiceImage_GXI = BC001T4_A40000ServiceImage_GXI[0];
            A611ServiceImage = BC001T4_A611ServiceImage[0];
            ZM1T104( -4) ;
         }
         pr_default.close(2);
         OnLoadActions1T104( ) ;
      }

      protected void OnLoadActions1T104( )
      {
      }

      protected void CheckExtendedTable1T104( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1T104( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1T104( )
      {
         /* Using cursor BC001T5 */
         pr_default.execute(3, new Object[] {A608ServiceImageId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound104 = 1;
         }
         else
         {
            RcdFound104 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001T3 */
         pr_default.execute(1, new Object[] {A608ServiceImageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1T104( 4) ;
            RcdFound104 = 1;
            A608ServiceImageId = BC001T3_A608ServiceImageId[0];
            A609ServiceId = BC001T3_A609ServiceId[0];
            A40000ServiceImage_GXI = BC001T3_A40000ServiceImage_GXI[0];
            A611ServiceImage = BC001T3_A611ServiceImage[0];
            Z608ServiceImageId = A608ServiceImageId;
            sMode104 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1T104( ) ;
            if ( AnyError == 1 )
            {
               RcdFound104 = 0;
               InitializeNonKey1T104( ) ;
            }
            Gx_mode = sMode104;
         }
         else
         {
            RcdFound104 = 0;
            InitializeNonKey1T104( ) ;
            sMode104 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode104;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1T104( ) ;
         if ( RcdFound104 == 0 )
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
         CONFIRM_1T0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1T104( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001T2 */
            pr_default.execute(0, new Object[] {A608ServiceImageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ServiceImage"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z609ServiceId != BC001T2_A609ServiceId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ServiceImage"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1T104( )
      {
         BeforeValidate1T104( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1T104( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1T104( 0) ;
            CheckOptimisticConcurrency1T104( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1T104( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1T104( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001T6 */
                     pr_default.execute(4, new Object[] {A608ServiceImageId, A609ServiceId, A611ServiceImage, A40000ServiceImage_GXI});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ServiceImage");
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
               Load1T104( ) ;
            }
            EndLevel1T104( ) ;
         }
         CloseExtendedTableCursors1T104( ) ;
      }

      protected void Update1T104( )
      {
         BeforeValidate1T104( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1T104( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1T104( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1T104( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1T104( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001T7 */
                     pr_default.execute(5, new Object[] {A609ServiceId, A608ServiceImageId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ServiceImage");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ServiceImage"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1T104( ) ;
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
            EndLevel1T104( ) ;
         }
         CloseExtendedTableCursors1T104( ) ;
      }

      protected void DeferredUpdate1T104( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC001T8 */
            pr_default.execute(6, new Object[] {A611ServiceImage, A40000ServiceImage_GXI, A608ServiceImageId});
            pr_default.close(6);
            pr_default.SmartCacheProvider.SetUpdated("Trn_ServiceImage");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1T104( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1T104( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1T104( ) ;
            AfterConfirm1T104( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1T104( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001T9 */
                  pr_default.execute(7, new Object[] {A608ServiceImageId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ServiceImage");
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
         sMode104 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1T104( ) ;
         Gx_mode = sMode104;
      }

      protected void OnDeleteControls1T104( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1T104( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1T104( ) ;
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

      public void ScanKeyStart1T104( )
      {
         /* Using cursor BC001T10 */
         pr_default.execute(8, new Object[] {A608ServiceImageId});
         RcdFound104 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound104 = 1;
            A608ServiceImageId = BC001T10_A608ServiceImageId[0];
            A609ServiceId = BC001T10_A609ServiceId[0];
            A40000ServiceImage_GXI = BC001T10_A40000ServiceImage_GXI[0];
            A611ServiceImage = BC001T10_A611ServiceImage[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1T104( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound104 = 0;
         ScanKeyLoad1T104( ) ;
      }

      protected void ScanKeyLoad1T104( )
      {
         sMode104 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound104 = 1;
            A608ServiceImageId = BC001T10_A608ServiceImageId[0];
            A609ServiceId = BC001T10_A609ServiceId[0];
            A40000ServiceImage_GXI = BC001T10_A40000ServiceImage_GXI[0];
            A611ServiceImage = BC001T10_A611ServiceImage[0];
         }
         Gx_mode = sMode104;
      }

      protected void ScanKeyEnd1T104( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1T104( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1T104( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1T104( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1T104( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1T104( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1T104( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1T104( )
      {
      }

      protected void send_integrity_lvl_hashes1T104( )
      {
      }

      protected void AddRow1T104( )
      {
         VarsToRow104( bcTrn_ServiceImage) ;
      }

      protected void ReadRow1T104( )
      {
         RowToVars104( bcTrn_ServiceImage, 1) ;
      }

      protected void InitializeNonKey1T104( )
      {
         A609ServiceId = Guid.Empty;
         A611ServiceImage = "";
         A40000ServiceImage_GXI = "";
         Z609ServiceId = Guid.Empty;
      }

      protected void InitAll1T104( )
      {
         A608ServiceImageId = Guid.NewGuid( );
         InitializeNonKey1T104( ) ;
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

      public void VarsToRow104( SdtTrn_ServiceImage obj104 )
      {
         obj104.gxTpr_Mode = Gx_mode;
         obj104.gxTpr_Serviceid = A609ServiceId;
         obj104.gxTpr_Serviceimage = A611ServiceImage;
         obj104.gxTpr_Serviceimage_gxi = A40000ServiceImage_GXI;
         obj104.gxTpr_Serviceimageid = A608ServiceImageId;
         obj104.gxTpr_Serviceimageid_Z = Z608ServiceImageId;
         obj104.gxTpr_Serviceid_Z = Z609ServiceId;
         obj104.gxTpr_Serviceimage_gxi_Z = Z40000ServiceImage_GXI;
         obj104.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow104( SdtTrn_ServiceImage obj104 )
      {
         obj104.gxTpr_Serviceimageid = A608ServiceImageId;
         return  ;
      }

      public void RowToVars104( SdtTrn_ServiceImage obj104 ,
                                int forceLoad )
      {
         Gx_mode = obj104.gxTpr_Mode;
         A609ServiceId = obj104.gxTpr_Serviceid;
         A611ServiceImage = obj104.gxTpr_Serviceimage;
         A40000ServiceImage_GXI = obj104.gxTpr_Serviceimage_gxi;
         A608ServiceImageId = obj104.gxTpr_Serviceimageid;
         Z608ServiceImageId = obj104.gxTpr_Serviceimageid_Z;
         Z609ServiceId = obj104.gxTpr_Serviceid_Z;
         Z40000ServiceImage_GXI = obj104.gxTpr_Serviceimage_gxi_Z;
         Gx_mode = obj104.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A608ServiceImageId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1T104( ) ;
         ScanKeyStart1T104( ) ;
         if ( RcdFound104 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z608ServiceImageId = A608ServiceImageId;
         }
         ZM1T104( -4) ;
         OnLoadActions1T104( ) ;
         AddRow1T104( ) ;
         ScanKeyEnd1T104( ) ;
         if ( RcdFound104 == 0 )
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
         RowToVars104( bcTrn_ServiceImage, 0) ;
         ScanKeyStart1T104( ) ;
         if ( RcdFound104 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z608ServiceImageId = A608ServiceImageId;
         }
         ZM1T104( -4) ;
         OnLoadActions1T104( ) ;
         AddRow1T104( ) ;
         ScanKeyEnd1T104( ) ;
         if ( RcdFound104 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1T104( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1T104( ) ;
         }
         else
         {
            if ( RcdFound104 == 1 )
            {
               if ( A608ServiceImageId != Z608ServiceImageId )
               {
                  A608ServiceImageId = Z608ServiceImageId;
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
                  Update1T104( ) ;
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
                  if ( A608ServiceImageId != Z608ServiceImageId )
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
                        Insert1T104( ) ;
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
                        Insert1T104( ) ;
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
         RowToVars104( bcTrn_ServiceImage, 1) ;
         SaveImpl( ) ;
         VarsToRow104( bcTrn_ServiceImage) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars104( bcTrn_ServiceImage, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1T104( ) ;
         AfterTrn( ) ;
         VarsToRow104( bcTrn_ServiceImage) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow104( bcTrn_ServiceImage) ;
         }
         else
         {
            SdtTrn_ServiceImage auxBC = new SdtTrn_ServiceImage(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A608ServiceImageId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_ServiceImage);
               auxBC.Save();
               bcTrn_ServiceImage.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars104( bcTrn_ServiceImage, 1) ;
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
         RowToVars104( bcTrn_ServiceImage, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1T104( ) ;
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
               VarsToRow104( bcTrn_ServiceImage) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow104( bcTrn_ServiceImage) ;
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
         RowToVars104( bcTrn_ServiceImage, 0) ;
         GetKey1T104( ) ;
         if ( RcdFound104 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A608ServiceImageId != Z608ServiceImageId )
            {
               A608ServiceImageId = Z608ServiceImageId;
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
            if ( A608ServiceImageId != Z608ServiceImageId )
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
         context.RollbackDataStores("trn_serviceimage_bc",pr_default);
         VarsToRow104( bcTrn_ServiceImage) ;
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
         Gx_mode = bcTrn_ServiceImage.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_ServiceImage.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_ServiceImage )
         {
            bcTrn_ServiceImage = (SdtTrn_ServiceImage)(sdt);
            if ( StringUtil.StrCmp(bcTrn_ServiceImage.gxTpr_Mode, "") == 0 )
            {
               bcTrn_ServiceImage.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow104( bcTrn_ServiceImage) ;
            }
            else
            {
               RowToVars104( bcTrn_ServiceImage, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_ServiceImage.gxTpr_Mode, "") == 0 )
            {
               bcTrn_ServiceImage.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars104( bcTrn_ServiceImage, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_ServiceImage Trn_ServiceImage_BC
      {
         get {
            return bcTrn_ServiceImage ;
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
            return "trn_productservice_Execute" ;
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
         Z608ServiceImageId = Guid.Empty;
         A608ServiceImageId = Guid.Empty;
         Z609ServiceId = Guid.Empty;
         A609ServiceId = Guid.Empty;
         Z611ServiceImage = "";
         A611ServiceImage = "";
         Z40000ServiceImage_GXI = "";
         A40000ServiceImage_GXI = "";
         BC001T4_A608ServiceImageId = new Guid[] {Guid.Empty} ;
         BC001T4_A609ServiceId = new Guid[] {Guid.Empty} ;
         BC001T4_A40000ServiceImage_GXI = new string[] {""} ;
         BC001T4_A611ServiceImage = new string[] {""} ;
         BC001T5_A608ServiceImageId = new Guid[] {Guid.Empty} ;
         BC001T3_A608ServiceImageId = new Guid[] {Guid.Empty} ;
         BC001T3_A609ServiceId = new Guid[] {Guid.Empty} ;
         BC001T3_A40000ServiceImage_GXI = new string[] {""} ;
         BC001T3_A611ServiceImage = new string[] {""} ;
         sMode104 = "";
         BC001T2_A608ServiceImageId = new Guid[] {Guid.Empty} ;
         BC001T2_A609ServiceId = new Guid[] {Guid.Empty} ;
         BC001T2_A40000ServiceImage_GXI = new string[] {""} ;
         BC001T2_A611ServiceImage = new string[] {""} ;
         BC001T10_A608ServiceImageId = new Guid[] {Guid.Empty} ;
         BC001T10_A609ServiceId = new Guid[] {Guid.Empty} ;
         BC001T10_A40000ServiceImage_GXI = new string[] {""} ;
         BC001T10_A611ServiceImage = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_serviceimage_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_serviceimage_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_serviceimage_bc__default(),
            new Object[][] {
                new Object[] {
               BC001T2_A608ServiceImageId, BC001T2_A609ServiceId, BC001T2_A40000ServiceImage_GXI, BC001T2_A611ServiceImage
               }
               , new Object[] {
               BC001T3_A608ServiceImageId, BC001T3_A609ServiceId, BC001T3_A40000ServiceImage_GXI, BC001T3_A611ServiceImage
               }
               , new Object[] {
               BC001T4_A608ServiceImageId, BC001T4_A609ServiceId, BC001T4_A40000ServiceImage_GXI, BC001T4_A611ServiceImage
               }
               , new Object[] {
               BC001T5_A608ServiceImageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001T10_A608ServiceImageId, BC001T10_A609ServiceId, BC001T10_A40000ServiceImage_GXI, BC001T10_A611ServiceImage
               }
            }
         );
         Z608ServiceImageId = Guid.NewGuid( );
         A608ServiceImageId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound104 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode104 ;
      private string Z40000ServiceImage_GXI ;
      private string A40000ServiceImage_GXI ;
      private string Z611ServiceImage ;
      private string A611ServiceImage ;
      private Guid Z608ServiceImageId ;
      private Guid A608ServiceImageId ;
      private Guid Z609ServiceId ;
      private Guid A609ServiceId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001T4_A608ServiceImageId ;
      private Guid[] BC001T4_A609ServiceId ;
      private string[] BC001T4_A40000ServiceImage_GXI ;
      private string[] BC001T4_A611ServiceImage ;
      private Guid[] BC001T5_A608ServiceImageId ;
      private Guid[] BC001T3_A608ServiceImageId ;
      private Guid[] BC001T3_A609ServiceId ;
      private string[] BC001T3_A40000ServiceImage_GXI ;
      private string[] BC001T3_A611ServiceImage ;
      private Guid[] BC001T2_A608ServiceImageId ;
      private Guid[] BC001T2_A609ServiceId ;
      private string[] BC001T2_A40000ServiceImage_GXI ;
      private string[] BC001T2_A611ServiceImage ;
      private Guid[] BC001T10_A608ServiceImageId ;
      private Guid[] BC001T10_A609ServiceId ;
      private string[] BC001T10_A40000ServiceImage_GXI ;
      private string[] BC001T10_A611ServiceImage ;
      private SdtTrn_ServiceImage bcTrn_ServiceImage ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_serviceimage_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_serviceimage_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_serviceimage_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[7])
      ,new ForEachCursor(def[8])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC001T2;
       prmBC001T2 = new Object[] {
       new ParDef("ServiceImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001T3;
       prmBC001T3 = new Object[] {
       new ParDef("ServiceImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001T4;
       prmBC001T4 = new Object[] {
       new ParDef("ServiceImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001T5;
       prmBC001T5 = new Object[] {
       new ParDef("ServiceImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001T6;
       prmBC001T6 = new Object[] {
       new ParDef("ServiceImageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ServiceId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ServiceImage",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("ServiceImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=2, Tbl="Trn_ServiceImage", Fld="ServiceImage"}
       };
       Object[] prmBC001T7;
       prmBC001T7 = new Object[] {
       new ParDef("ServiceId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ServiceImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001T8;
       prmBC001T8 = new Object[] {
       new ParDef("ServiceImage",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("ServiceImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Trn_ServiceImage", Fld="ServiceImage"} ,
       new ParDef("ServiceImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001T9;
       prmBC001T9 = new Object[] {
       new ParDef("ServiceImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001T10;
       prmBC001T10 = new Object[] {
       new ParDef("ServiceImageId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001T2", "SELECT ServiceImageId, ServiceId, ServiceImage_GXI, ServiceImage FROM Trn_ServiceImage WHERE ServiceImageId = :ServiceImageId  FOR UPDATE OF Trn_ServiceImage",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001T3", "SELECT ServiceImageId, ServiceId, ServiceImage_GXI, ServiceImage FROM Trn_ServiceImage WHERE ServiceImageId = :ServiceImageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001T4", "SELECT TM1.ServiceImageId, TM1.ServiceId, TM1.ServiceImage_GXI, TM1.ServiceImage FROM Trn_ServiceImage TM1 WHERE TM1.ServiceImageId = :ServiceImageId ORDER BY TM1.ServiceImageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001T5", "SELECT ServiceImageId FROM Trn_ServiceImage WHERE ServiceImageId = :ServiceImageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001T6", "SAVEPOINT gxupdate;INSERT INTO Trn_ServiceImage(ServiceImageId, ServiceId, ServiceImage, ServiceImage_GXI) VALUES(:ServiceImageId, :ServiceId, :ServiceImage, :ServiceImage_GXI);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001T6)
          ,new CursorDef("BC001T7", "SAVEPOINT gxupdate;UPDATE Trn_ServiceImage SET ServiceId=:ServiceId  WHERE ServiceImageId = :ServiceImageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001T7)
          ,new CursorDef("BC001T8", "SAVEPOINT gxupdate;UPDATE Trn_ServiceImage SET ServiceImage=:ServiceImage, ServiceImage_GXI=:ServiceImage_GXI  WHERE ServiceImageId = :ServiceImageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001T8)
          ,new CursorDef("BC001T9", "SAVEPOINT gxupdate;DELETE FROM Trn_ServiceImage  WHERE ServiceImageId = :ServiceImageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001T9)
          ,new CursorDef("BC001T10", "SELECT TM1.ServiceImageId, TM1.ServiceId, TM1.ServiceImage_GXI, TM1.ServiceImage FROM Trn_ServiceImage TM1 WHERE TM1.ServiceImageId = :ServiceImageId ORDER BY TM1.ServiceImageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T10,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
             return;
    }
 }

}

}
