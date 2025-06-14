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
   public class trn_device_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_device_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_device_bc( IGxContext context )
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
         ReadRow1367( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1367( ) ;
         standaloneModal( ) ;
         AddRow1367( ) ;
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
               Z333DeviceId = A333DeviceId;
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

      protected void CONFIRM_130( )
      {
         BeforeValidate1367( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1367( ) ;
            }
            else
            {
               CheckExtendedTable1367( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1367( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1367( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z334DeviceType = A334DeviceType;
            Z335DeviceToken = A335DeviceToken;
            Z336DeviceName = A336DeviceName;
            Z337DeviceUserId = A337DeviceUserId;
         }
         if ( GX_JID == -2 )
         {
            Z333DeviceId = A333DeviceId;
            Z334DeviceType = A334DeviceType;
            Z335DeviceToken = A335DeviceToken;
            Z336DeviceName = A336DeviceName;
            Z337DeviceUserId = A337DeviceUserId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1367( )
      {
         /* Using cursor BC00134 */
         pr_default.execute(2, new Object[] {A333DeviceId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound67 = 1;
            A334DeviceType = BC00134_A334DeviceType[0];
            A335DeviceToken = BC00134_A335DeviceToken[0];
            A336DeviceName = BC00134_A336DeviceName[0];
            A337DeviceUserId = BC00134_A337DeviceUserId[0];
            ZM1367( -2) ;
         }
         pr_default.close(2);
         OnLoadActions1367( ) ;
      }

      protected void OnLoadActions1367( )
      {
      }

      protected void CheckExtendedTable1367( )
      {
         standaloneModal( ) ;
         if ( ! ( ( A334DeviceType == 0 ) || ( A334DeviceType == 1 ) || ( A334DeviceType == 2 ) || ( A334DeviceType == 3 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Device Type", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1367( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1367( )
      {
         /* Using cursor BC00135 */
         pr_default.execute(3, new Object[] {A333DeviceId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound67 = 1;
         }
         else
         {
            RcdFound67 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00133 */
         pr_default.execute(1, new Object[] {A333DeviceId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1367( 2) ;
            RcdFound67 = 1;
            A333DeviceId = BC00133_A333DeviceId[0];
            A334DeviceType = BC00133_A334DeviceType[0];
            A335DeviceToken = BC00133_A335DeviceToken[0];
            A336DeviceName = BC00133_A336DeviceName[0];
            A337DeviceUserId = BC00133_A337DeviceUserId[0];
            Z333DeviceId = A333DeviceId;
            sMode67 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1367( ) ;
            if ( AnyError == 1 )
            {
               RcdFound67 = 0;
               InitializeNonKey1367( ) ;
            }
            Gx_mode = sMode67;
         }
         else
         {
            RcdFound67 = 0;
            InitializeNonKey1367( ) ;
            sMode67 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode67;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1367( ) ;
         if ( RcdFound67 == 0 )
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
         CONFIRM_130( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1367( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00132 */
            pr_default.execute(0, new Object[] {A333DeviceId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Device"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z334DeviceType != BC00132_A334DeviceType[0] ) || ( StringUtil.StrCmp(Z335DeviceToken, BC00132_A335DeviceToken[0]) != 0 ) || ( StringUtil.StrCmp(Z336DeviceName, BC00132_A336DeviceName[0]) != 0 ) || ( StringUtil.StrCmp(Z337DeviceUserId, BC00132_A337DeviceUserId[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Device"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1367( )
      {
         BeforeValidate1367( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1367( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1367( 0) ;
            CheckOptimisticConcurrency1367( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1367( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1367( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00136 */
                     pr_default.execute(4, new Object[] {A333DeviceId, A334DeviceType, A335DeviceToken, A336DeviceName, A337DeviceUserId});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Device");
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
               Load1367( ) ;
            }
            EndLevel1367( ) ;
         }
         CloseExtendedTableCursors1367( ) ;
      }

      protected void Update1367( )
      {
         BeforeValidate1367( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1367( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1367( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1367( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1367( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00137 */
                     pr_default.execute(5, new Object[] {A334DeviceType, A335DeviceToken, A336DeviceName, A337DeviceUserId, A333DeviceId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Device");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Device"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1367( ) ;
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
            EndLevel1367( ) ;
         }
         CloseExtendedTableCursors1367( ) ;
      }

      protected void DeferredUpdate1367( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1367( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1367( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1367( ) ;
            AfterConfirm1367( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1367( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00138 */
                  pr_default.execute(6, new Object[] {A333DeviceId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Device");
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
         sMode67 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1367( ) ;
         Gx_mode = sMode67;
      }

      protected void OnDeleteControls1367( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1367( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1367( ) ;
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

      public void ScanKeyStart1367( )
      {
         /* Using cursor BC00139 */
         pr_default.execute(7, new Object[] {A333DeviceId});
         RcdFound67 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound67 = 1;
            A333DeviceId = BC00139_A333DeviceId[0];
            A334DeviceType = BC00139_A334DeviceType[0];
            A335DeviceToken = BC00139_A335DeviceToken[0];
            A336DeviceName = BC00139_A336DeviceName[0];
            A337DeviceUserId = BC00139_A337DeviceUserId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1367( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound67 = 0;
         ScanKeyLoad1367( ) ;
      }

      protected void ScanKeyLoad1367( )
      {
         sMode67 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound67 = 1;
            A333DeviceId = BC00139_A333DeviceId[0];
            A334DeviceType = BC00139_A334DeviceType[0];
            A335DeviceToken = BC00139_A335DeviceToken[0];
            A336DeviceName = BC00139_A336DeviceName[0];
            A337DeviceUserId = BC00139_A337DeviceUserId[0];
         }
         Gx_mode = sMode67;
      }

      protected void ScanKeyEnd1367( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm1367( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1367( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1367( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1367( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1367( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1367( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1367( )
      {
      }

      protected void send_integrity_lvl_hashes1367( )
      {
      }

      protected void AddRow1367( )
      {
         VarsToRow67( bcTrn_Device) ;
      }

      protected void ReadRow1367( )
      {
         RowToVars67( bcTrn_Device, 1) ;
      }

      protected void InitializeNonKey1367( )
      {
         A334DeviceType = 0;
         A335DeviceToken = "";
         A336DeviceName = "";
         A337DeviceUserId = "";
         Z334DeviceType = 0;
         Z335DeviceToken = "";
         Z336DeviceName = "";
         Z337DeviceUserId = "";
      }

      protected void InitAll1367( )
      {
         A333DeviceId = "";
         InitializeNonKey1367( ) ;
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

      public void VarsToRow67( SdtTrn_Device obj67 )
      {
         obj67.gxTpr_Mode = Gx_mode;
         obj67.gxTpr_Devicetype = A334DeviceType;
         obj67.gxTpr_Devicetoken = A335DeviceToken;
         obj67.gxTpr_Devicename = A336DeviceName;
         obj67.gxTpr_Deviceuserid = A337DeviceUserId;
         obj67.gxTpr_Deviceid = A333DeviceId;
         obj67.gxTpr_Deviceid_Z = Z333DeviceId;
         obj67.gxTpr_Devicetype_Z = Z334DeviceType;
         obj67.gxTpr_Devicetoken_Z = Z335DeviceToken;
         obj67.gxTpr_Devicename_Z = Z336DeviceName;
         obj67.gxTpr_Deviceuserid_Z = Z337DeviceUserId;
         obj67.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow67( SdtTrn_Device obj67 )
      {
         obj67.gxTpr_Deviceid = A333DeviceId;
         return  ;
      }

      public void RowToVars67( SdtTrn_Device obj67 ,
                               int forceLoad )
      {
         Gx_mode = obj67.gxTpr_Mode;
         A334DeviceType = obj67.gxTpr_Devicetype;
         A335DeviceToken = obj67.gxTpr_Devicetoken;
         A336DeviceName = obj67.gxTpr_Devicename;
         A337DeviceUserId = obj67.gxTpr_Deviceuserid;
         A333DeviceId = obj67.gxTpr_Deviceid;
         Z333DeviceId = obj67.gxTpr_Deviceid_Z;
         Z334DeviceType = obj67.gxTpr_Devicetype_Z;
         Z335DeviceToken = obj67.gxTpr_Devicetoken_Z;
         Z336DeviceName = obj67.gxTpr_Devicename_Z;
         Z337DeviceUserId = obj67.gxTpr_Deviceuserid_Z;
         Gx_mode = obj67.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A333DeviceId = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1367( ) ;
         ScanKeyStart1367( ) ;
         if ( RcdFound67 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z333DeviceId = A333DeviceId;
         }
         ZM1367( -2) ;
         OnLoadActions1367( ) ;
         AddRow1367( ) ;
         ScanKeyEnd1367( ) ;
         if ( RcdFound67 == 0 )
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
         RowToVars67( bcTrn_Device, 0) ;
         ScanKeyStart1367( ) ;
         if ( RcdFound67 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z333DeviceId = A333DeviceId;
         }
         ZM1367( -2) ;
         OnLoadActions1367( ) ;
         AddRow1367( ) ;
         ScanKeyEnd1367( ) ;
         if ( RcdFound67 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1367( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1367( ) ;
         }
         else
         {
            if ( RcdFound67 == 1 )
            {
               if ( StringUtil.StrCmp(A333DeviceId, Z333DeviceId) != 0 )
               {
                  A333DeviceId = Z333DeviceId;
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
                  Update1367( ) ;
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
                  if ( StringUtil.StrCmp(A333DeviceId, Z333DeviceId) != 0 )
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
                        Insert1367( ) ;
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
                        Insert1367( ) ;
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
         RowToVars67( bcTrn_Device, 1) ;
         SaveImpl( ) ;
         VarsToRow67( bcTrn_Device) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars67( bcTrn_Device, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1367( ) ;
         AfterTrn( ) ;
         VarsToRow67( bcTrn_Device) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow67( bcTrn_Device) ;
         }
         else
         {
            SdtTrn_Device auxBC = new SdtTrn_Device(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A333DeviceId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Device);
               auxBC.Save();
               bcTrn_Device.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars67( bcTrn_Device, 1) ;
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
         RowToVars67( bcTrn_Device, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1367( ) ;
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
               VarsToRow67( bcTrn_Device) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow67( bcTrn_Device) ;
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
         RowToVars67( bcTrn_Device, 0) ;
         GetKey1367( ) ;
         if ( RcdFound67 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A333DeviceId, Z333DeviceId) != 0 )
            {
               A333DeviceId = Z333DeviceId;
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
            if ( StringUtil.StrCmp(A333DeviceId, Z333DeviceId) != 0 )
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
         context.RollbackDataStores("trn_device_bc",pr_default);
         VarsToRow67( bcTrn_Device) ;
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
         Gx_mode = bcTrn_Device.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Device.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Device )
         {
            bcTrn_Device = (SdtTrn_Device)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Device.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Device.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow67( bcTrn_Device) ;
            }
            else
            {
               RowToVars67( bcTrn_Device, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Device.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Device.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars67( bcTrn_Device, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Device Trn_Device_BC
      {
         get {
            return bcTrn_Device ;
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
            return "trn_device_Execute" ;
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
         Z333DeviceId = "";
         A333DeviceId = "";
         Z335DeviceToken = "";
         A335DeviceToken = "";
         Z336DeviceName = "";
         A336DeviceName = "";
         Z337DeviceUserId = "";
         A337DeviceUserId = "";
         BC00134_A333DeviceId = new string[] {""} ;
         BC00134_A334DeviceType = new short[1] ;
         BC00134_A335DeviceToken = new string[] {""} ;
         BC00134_A336DeviceName = new string[] {""} ;
         BC00134_A337DeviceUserId = new string[] {""} ;
         BC00135_A333DeviceId = new string[] {""} ;
         BC00133_A333DeviceId = new string[] {""} ;
         BC00133_A334DeviceType = new short[1] ;
         BC00133_A335DeviceToken = new string[] {""} ;
         BC00133_A336DeviceName = new string[] {""} ;
         BC00133_A337DeviceUserId = new string[] {""} ;
         sMode67 = "";
         BC00132_A333DeviceId = new string[] {""} ;
         BC00132_A334DeviceType = new short[1] ;
         BC00132_A335DeviceToken = new string[] {""} ;
         BC00132_A336DeviceName = new string[] {""} ;
         BC00132_A337DeviceUserId = new string[] {""} ;
         BC00139_A333DeviceId = new string[] {""} ;
         BC00139_A334DeviceType = new short[1] ;
         BC00139_A335DeviceToken = new string[] {""} ;
         BC00139_A336DeviceName = new string[] {""} ;
         BC00139_A337DeviceUserId = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_device_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_device_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_device_bc__default(),
            new Object[][] {
                new Object[] {
               BC00132_A333DeviceId, BC00132_A334DeviceType, BC00132_A335DeviceToken, BC00132_A336DeviceName, BC00132_A337DeviceUserId
               }
               , new Object[] {
               BC00133_A333DeviceId, BC00133_A334DeviceType, BC00133_A335DeviceToken, BC00133_A336DeviceName, BC00133_A337DeviceUserId
               }
               , new Object[] {
               BC00134_A333DeviceId, BC00134_A334DeviceType, BC00134_A335DeviceToken, BC00134_A336DeviceName, BC00134_A337DeviceUserId
               }
               , new Object[] {
               BC00135_A333DeviceId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00139_A333DeviceId, BC00139_A334DeviceType, BC00139_A335DeviceToken, BC00139_A336DeviceName, BC00139_A337DeviceUserId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z334DeviceType ;
      private short A334DeviceType ;
      private short RcdFound67 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z333DeviceId ;
      private string A333DeviceId ;
      private string Z335DeviceToken ;
      private string A335DeviceToken ;
      private string Z336DeviceName ;
      private string A336DeviceName ;
      private string sMode67 ;
      private string Z337DeviceUserId ;
      private string A337DeviceUserId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC00134_A333DeviceId ;
      private short[] BC00134_A334DeviceType ;
      private string[] BC00134_A335DeviceToken ;
      private string[] BC00134_A336DeviceName ;
      private string[] BC00134_A337DeviceUserId ;
      private string[] BC00135_A333DeviceId ;
      private string[] BC00133_A333DeviceId ;
      private short[] BC00133_A334DeviceType ;
      private string[] BC00133_A335DeviceToken ;
      private string[] BC00133_A336DeviceName ;
      private string[] BC00133_A337DeviceUserId ;
      private string[] BC00132_A333DeviceId ;
      private short[] BC00132_A334DeviceType ;
      private string[] BC00132_A335DeviceToken ;
      private string[] BC00132_A336DeviceName ;
      private string[] BC00132_A337DeviceUserId ;
      private string[] BC00139_A333DeviceId ;
      private short[] BC00139_A334DeviceType ;
      private string[] BC00139_A335DeviceToken ;
      private string[] BC00139_A336DeviceName ;
      private string[] BC00139_A337DeviceUserId ;
      private SdtTrn_Device bcTrn_Device ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_device_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_device_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_device_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC00132;
       prmBC00132 = new Object[] {
       new ParDef("DeviceId",GXType.Char,128,0)
       };
       Object[] prmBC00133;
       prmBC00133 = new Object[] {
       new ParDef("DeviceId",GXType.Char,128,0)
       };
       Object[] prmBC00134;
       prmBC00134 = new Object[] {
       new ParDef("DeviceId",GXType.Char,128,0)
       };
       Object[] prmBC00135;
       prmBC00135 = new Object[] {
       new ParDef("DeviceId",GXType.Char,128,0)
       };
       Object[] prmBC00136;
       prmBC00136 = new Object[] {
       new ParDef("DeviceId",GXType.Char,128,0) ,
       new ParDef("DeviceType",GXType.Int16,1,0) ,
       new ParDef("DeviceToken",GXType.Char,1000,0) ,
       new ParDef("DeviceName",GXType.Char,128,0) ,
       new ParDef("DeviceUserId",GXType.VarChar,100,60)
       };
       Object[] prmBC00137;
       prmBC00137 = new Object[] {
       new ParDef("DeviceType",GXType.Int16,1,0) ,
       new ParDef("DeviceToken",GXType.Char,1000,0) ,
       new ParDef("DeviceName",GXType.Char,128,0) ,
       new ParDef("DeviceUserId",GXType.VarChar,100,60) ,
       new ParDef("DeviceId",GXType.Char,128,0)
       };
       Object[] prmBC00138;
       prmBC00138 = new Object[] {
       new ParDef("DeviceId",GXType.Char,128,0)
       };
       Object[] prmBC00139;
       prmBC00139 = new Object[] {
       new ParDef("DeviceId",GXType.Char,128,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC00132", "SELECT DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUserId FROM Trn_Device WHERE DeviceId = :DeviceId  FOR UPDATE OF Trn_Device",true, GxErrorMask.GX_NOMASK, false, this,prmBC00132,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00133", "SELECT DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUserId FROM Trn_Device WHERE DeviceId = :DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00133,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00134", "SELECT TM1.DeviceId, TM1.DeviceType, TM1.DeviceToken, TM1.DeviceName, TM1.DeviceUserId FROM Trn_Device TM1 WHERE TM1.DeviceId = ( :DeviceId) ORDER BY TM1.DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00134,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00135", "SELECT DeviceId FROM Trn_Device WHERE DeviceId = :DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00135,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00136", "SAVEPOINT gxupdate;INSERT INTO Trn_Device(DeviceId, DeviceType, DeviceToken, DeviceName, DeviceUserId) VALUES(:DeviceId, :DeviceType, :DeviceToken, :DeviceName, :DeviceUserId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00136)
          ,new CursorDef("BC00137", "SAVEPOINT gxupdate;UPDATE Trn_Device SET DeviceType=:DeviceType, DeviceToken=:DeviceToken, DeviceName=:DeviceName, DeviceUserId=:DeviceUserId  WHERE DeviceId = :DeviceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00137)
          ,new CursorDef("BC00138", "SAVEPOINT gxupdate;DELETE FROM Trn_Device  WHERE DeviceId = :DeviceId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00138)
          ,new CursorDef("BC00139", "SELECT TM1.DeviceId, TM1.DeviceType, TM1.DeviceToken, TM1.DeviceName, TM1.DeviceUserId FROM Trn_Device TM1 WHERE TM1.DeviceId = ( :DeviceId) ORDER BY TM1.DeviceId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00139,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[0])[0] = rslt.getString(1, 128);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 1000);
             ((string[]) buf[3])[0] = rslt.getString(4, 128);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             return;
          case 1 :
             ((string[]) buf[0])[0] = rslt.getString(1, 128);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 1000);
             ((string[]) buf[3])[0] = rslt.getString(4, 128);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getString(1, 128);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 1000);
             ((string[]) buf[3])[0] = rslt.getString(4, 128);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getString(1, 128);
             return;
          case 7 :
             ((string[]) buf[0])[0] = rslt.getString(1, 128);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 1000);
             ((string[]) buf[3])[0] = rslt.getString(4, 128);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             return;
    }
 }

}

}
