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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_webclient_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_webclient_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_webclient_bc( IGxContext context )
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
         ReadRow0M32( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0M32( ) ;
         standaloneModal( ) ;
         AddRow0M32( ) ;
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
               Z153WWPWebClientId = A153WWPWebClientId;
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

      protected void CONFIRM_0M0( )
      {
         BeforeValidate0M32( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0M32( ) ;
            }
            else
            {
               CheckExtendedTable0M32( ) ;
               if ( AnyError == 0 )
               {
                  ZM0M32( 5) ;
               }
               CloseExtendedTableCursors0M32( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0M32( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z154WWPWebClientBrowserId = A154WWPWebClientBrowserId;
            Z156WWPWebClientFirstRegistered = A156WWPWebClientFirstRegistered;
            Z157WWPWebClientLastRegistered = A157WWPWebClientLastRegistered;
            Z112WWPUserExtendedId = A112WWPUserExtendedId;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -4 )
         {
            Z153WWPWebClientId = A153WWPWebClientId;
            Z154WWPWebClientBrowserId = A154WWPWebClientBrowserId;
            Z155WWPWebClientBrowserVersion = A155WWPWebClientBrowserVersion;
            Z156WWPWebClientFirstRegistered = A156WWPWebClientFirstRegistered;
            Z157WWPWebClientLastRegistered = A157WWPWebClientLastRegistered;
            Z112WWPUserExtendedId = A112WWPUserExtendedId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A156WWPWebClientFirstRegistered) && ( Gx_BScreen == 0 ) )
         {
            A156WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( IsIns( )  && (DateTime.MinValue==A157WWPWebClientLastRegistered) && ( Gx_BScreen == 0 ) )
         {
            A157WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         }
      }

      protected void Load0M32( )
      {
         /* Using cursor BC000M5 */
         pr_default.execute(3, new Object[] {A153WWPWebClientId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound32 = 1;
            A154WWPWebClientBrowserId = BC000M5_A154WWPWebClientBrowserId[0];
            A155WWPWebClientBrowserVersion = BC000M5_A155WWPWebClientBrowserVersion[0];
            A156WWPWebClientFirstRegistered = BC000M5_A156WWPWebClientFirstRegistered[0];
            A157WWPWebClientLastRegistered = BC000M5_A157WWPWebClientLastRegistered[0];
            A112WWPUserExtendedId = BC000M5_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = BC000M5_n112WWPUserExtendedId[0];
            ZM0M32( -4) ;
         }
         pr_default.close(3);
         OnLoadActions0M32( ) ;
      }

      protected void OnLoadActions0M32( )
      {
      }

      protected void CheckExtendedTable0M32( )
      {
         standaloneModal( ) ;
         if ( ! ( ( A154WWPWebClientBrowserId == 0 ) || ( A154WWPWebClientBrowserId == 1 ) || ( A154WWPWebClientBrowserId == 2 ) || ( A154WWPWebClientBrowserId == 3 ) || ( A154WWPWebClientBrowserId == 5 ) || ( A154WWPWebClientBrowserId == 6 ) || ( A154WWPWebClientBrowserId == 7 ) || ( A154WWPWebClientBrowserId == 8 ) || ( A154WWPWebClientBrowserId == 9 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Web Client Browser Id", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000M4 */
         pr_default.execute(2, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A112WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0M32( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0M32( )
      {
         /* Using cursor BC000M6 */
         pr_default.execute(4, new Object[] {A153WWPWebClientId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound32 = 1;
         }
         else
         {
            RcdFound32 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000M3 */
         pr_default.execute(1, new Object[] {A153WWPWebClientId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0M32( 4) ;
            RcdFound32 = 1;
            A153WWPWebClientId = BC000M3_A153WWPWebClientId[0];
            A154WWPWebClientBrowserId = BC000M3_A154WWPWebClientBrowserId[0];
            A155WWPWebClientBrowserVersion = BC000M3_A155WWPWebClientBrowserVersion[0];
            A156WWPWebClientFirstRegistered = BC000M3_A156WWPWebClientFirstRegistered[0];
            A157WWPWebClientLastRegistered = BC000M3_A157WWPWebClientLastRegistered[0];
            A112WWPUserExtendedId = BC000M3_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = BC000M3_n112WWPUserExtendedId[0];
            Z153WWPWebClientId = A153WWPWebClientId;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0M32( ) ;
            if ( AnyError == 1 )
            {
               RcdFound32 = 0;
               InitializeNonKey0M32( ) ;
            }
            Gx_mode = sMode32;
         }
         else
         {
            RcdFound32 = 0;
            InitializeNonKey0M32( ) ;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode32;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0M32( ) ;
         if ( RcdFound32 == 0 )
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
         CONFIRM_0M0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0M32( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000M2 */
            pr_default.execute(0, new Object[] {A153WWPWebClientId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebClient"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z154WWPWebClientBrowserId != BC000M2_A154WWPWebClientBrowserId[0] ) || ( Z156WWPWebClientFirstRegistered != BC000M2_A156WWPWebClientFirstRegistered[0] ) || ( Z157WWPWebClientLastRegistered != BC000M2_A157WWPWebClientLastRegistered[0] ) || ( StringUtil.StrCmp(Z112WWPUserExtendedId, BC000M2_A112WWPUserExtendedId[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_WebClient"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0M32( )
      {
         BeforeValidate0M32( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M32( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0M32( 0) ;
            CheckOptimisticConcurrency0M32( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M32( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0M32( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000M7 */
                     pr_default.execute(5, new Object[] {A153WWPWebClientId, A154WWPWebClientBrowserId, A155WWPWebClientBrowserVersion, A156WWPWebClientFirstRegistered, A157WWPWebClientLastRegistered, n112WWPUserExtendedId, A112WWPUserExtendedId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
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
               Load0M32( ) ;
            }
            EndLevel0M32( ) ;
         }
         CloseExtendedTableCursors0M32( ) ;
      }

      protected void Update0M32( )
      {
         BeforeValidate0M32( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M32( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M32( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M32( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0M32( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000M8 */
                     pr_default.execute(6, new Object[] {A154WWPWebClientBrowserId, A155WWPWebClientBrowserVersion, A156WWPWebClientFirstRegistered, A157WWPWebClientLastRegistered, n112WWPUserExtendedId, A112WWPUserExtendedId, A153WWPWebClientId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebClient"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0M32( ) ;
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
            EndLevel0M32( ) ;
         }
         CloseExtendedTableCursors0M32( ) ;
      }

      protected void DeferredUpdate0M32( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0M32( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M32( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0M32( ) ;
            AfterConfirm0M32( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0M32( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000M9 */
                  pr_default.execute(7, new Object[] {A153WWPWebClientId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
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
         sMode32 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0M32( ) ;
         Gx_mode = sMode32;
      }

      protected void OnDeleteControls0M32( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0M32( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0M32( ) ;
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

      public void ScanKeyStart0M32( )
      {
         /* Using cursor BC000M10 */
         pr_default.execute(8, new Object[] {A153WWPWebClientId});
         RcdFound32 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound32 = 1;
            A153WWPWebClientId = BC000M10_A153WWPWebClientId[0];
            A154WWPWebClientBrowserId = BC000M10_A154WWPWebClientBrowserId[0];
            A155WWPWebClientBrowserVersion = BC000M10_A155WWPWebClientBrowserVersion[0];
            A156WWPWebClientFirstRegistered = BC000M10_A156WWPWebClientFirstRegistered[0];
            A157WWPWebClientLastRegistered = BC000M10_A157WWPWebClientLastRegistered[0];
            A112WWPUserExtendedId = BC000M10_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = BC000M10_n112WWPUserExtendedId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0M32( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound32 = 0;
         ScanKeyLoad0M32( ) ;
      }

      protected void ScanKeyLoad0M32( )
      {
         sMode32 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound32 = 1;
            A153WWPWebClientId = BC000M10_A153WWPWebClientId[0];
            A154WWPWebClientBrowserId = BC000M10_A154WWPWebClientBrowserId[0];
            A155WWPWebClientBrowserVersion = BC000M10_A155WWPWebClientBrowserVersion[0];
            A156WWPWebClientFirstRegistered = BC000M10_A156WWPWebClientFirstRegistered[0];
            A157WWPWebClientLastRegistered = BC000M10_A157WWPWebClientLastRegistered[0];
            A112WWPUserExtendedId = BC000M10_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = BC000M10_n112WWPUserExtendedId[0];
         }
         Gx_mode = sMode32;
      }

      protected void ScanKeyEnd0M32( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0M32( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0M32( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0M32( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0M32( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0M32( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0M32( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0M32( )
      {
      }

      protected void send_integrity_lvl_hashes0M32( )
      {
      }

      protected void AddRow0M32( )
      {
         VarsToRow32( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
      }

      protected void ReadRow0M32( )
      {
         RowToVars32( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
      }

      protected void InitializeNonKey0M32( )
      {
         A154WWPWebClientBrowserId = 0;
         A155WWPWebClientBrowserVersion = "";
         A112WWPUserExtendedId = "";
         n112WWPUserExtendedId = false;
         A156WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         A157WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         Z154WWPWebClientBrowserId = 0;
         Z156WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         Z157WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         Z112WWPUserExtendedId = "";
      }

      protected void InitAll0M32( )
      {
         A153WWPWebClientId = "";
         InitializeNonKey0M32( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A156WWPWebClientFirstRegistered = i156WWPWebClientFirstRegistered;
         A157WWPWebClientLastRegistered = i157WWPWebClientLastRegistered;
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

      public void VarsToRow32( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient obj32 )
      {
         obj32.gxTpr_Mode = Gx_mode;
         obj32.gxTpr_Wwpwebclientbrowserid = A154WWPWebClientBrowserId;
         obj32.gxTpr_Wwpwebclientbrowserversion = A155WWPWebClientBrowserVersion;
         obj32.gxTpr_Wwpuserextendedid = A112WWPUserExtendedId;
         obj32.gxTpr_Wwpwebclientfirstregistered = A156WWPWebClientFirstRegistered;
         obj32.gxTpr_Wwpwebclientlastregistered = A157WWPWebClientLastRegistered;
         obj32.gxTpr_Wwpwebclientid = A153WWPWebClientId;
         obj32.gxTpr_Wwpwebclientid_Z = Z153WWPWebClientId;
         obj32.gxTpr_Wwpwebclientbrowserid_Z = Z154WWPWebClientBrowserId;
         obj32.gxTpr_Wwpwebclientfirstregistered_Z = Z156WWPWebClientFirstRegistered;
         obj32.gxTpr_Wwpwebclientlastregistered_Z = Z157WWPWebClientLastRegistered;
         obj32.gxTpr_Wwpuserextendedid_Z = Z112WWPUserExtendedId;
         obj32.gxTpr_Wwpuserextendedid_N = (short)(Convert.ToInt16(n112WWPUserExtendedId));
         obj32.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow32( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient obj32 )
      {
         obj32.gxTpr_Wwpwebclientid = A153WWPWebClientId;
         return  ;
      }

      public void RowToVars32( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient obj32 ,
                               int forceLoad )
      {
         Gx_mode = obj32.gxTpr_Mode;
         A154WWPWebClientBrowserId = obj32.gxTpr_Wwpwebclientbrowserid;
         A155WWPWebClientBrowserVersion = obj32.gxTpr_Wwpwebclientbrowserversion;
         A112WWPUserExtendedId = obj32.gxTpr_Wwpuserextendedid;
         n112WWPUserExtendedId = false;
         A156WWPWebClientFirstRegistered = obj32.gxTpr_Wwpwebclientfirstregistered;
         A157WWPWebClientLastRegistered = obj32.gxTpr_Wwpwebclientlastregistered;
         A153WWPWebClientId = obj32.gxTpr_Wwpwebclientid;
         Z153WWPWebClientId = obj32.gxTpr_Wwpwebclientid_Z;
         Z154WWPWebClientBrowserId = obj32.gxTpr_Wwpwebclientbrowserid_Z;
         Z156WWPWebClientFirstRegistered = obj32.gxTpr_Wwpwebclientfirstregistered_Z;
         Z157WWPWebClientLastRegistered = obj32.gxTpr_Wwpwebclientlastregistered_Z;
         Z112WWPUserExtendedId = obj32.gxTpr_Wwpuserextendedid_Z;
         n112WWPUserExtendedId = (bool)(Convert.ToBoolean(obj32.gxTpr_Wwpuserextendedid_N));
         Gx_mode = obj32.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A153WWPWebClientId = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0M32( ) ;
         ScanKeyStart0M32( ) ;
         if ( RcdFound32 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z153WWPWebClientId = A153WWPWebClientId;
         }
         ZM0M32( -4) ;
         OnLoadActions0M32( ) ;
         AddRow0M32( ) ;
         ScanKeyEnd0M32( ) ;
         if ( RcdFound32 == 0 )
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
         RowToVars32( bcwwpbaseobjects_notifications_web_WWP_WebClient, 0) ;
         ScanKeyStart0M32( ) ;
         if ( RcdFound32 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z153WWPWebClientId = A153WWPWebClientId;
         }
         ZM0M32( -4) ;
         OnLoadActions0M32( ) ;
         AddRow0M32( ) ;
         ScanKeyEnd0M32( ) ;
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0M32( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0M32( ) ;
         }
         else
         {
            if ( RcdFound32 == 1 )
            {
               if ( StringUtil.StrCmp(A153WWPWebClientId, Z153WWPWebClientId) != 0 )
               {
                  A153WWPWebClientId = Z153WWPWebClientId;
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
                  Update0M32( ) ;
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
                  if ( StringUtil.StrCmp(A153WWPWebClientId, Z153WWPWebClientId) != 0 )
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
                        Insert0M32( ) ;
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
                        Insert0M32( ) ;
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
         RowToVars32( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
         SaveImpl( ) ;
         VarsToRow32( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars32( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0M32( ) ;
         AfterTrn( ) ;
         VarsToRow32( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow32( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient auxBC = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A153WWPWebClientId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_notifications_web_WWP_WebClient);
               auxBC.Save();
               bcwwpbaseobjects_notifications_web_WWP_WebClient.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars32( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
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
         RowToVars32( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0M32( ) ;
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
               VarsToRow32( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow32( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
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
         RowToVars32( bcwwpbaseobjects_notifications_web_WWP_WebClient, 0) ;
         GetKey0M32( ) ;
         if ( RcdFound32 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A153WWPWebClientId, Z153WWPWebClientId) != 0 )
            {
               A153WWPWebClientId = Z153WWPWebClientId;
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
            if ( StringUtil.StrCmp(A153WWPWebClientId, Z153WWPWebClientId) != 0 )
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
         context.RollbackDataStores("wwpbaseobjects.notifications.web.wwp_webclient_bc",pr_default);
         VarsToRow32( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
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
         Gx_mode = bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_notifications_web_WWP_WebClient )
         {
            bcwwpbaseobjects_notifications_web_WWP_WebClient = (GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow32( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
            }
            else
            {
               RowToVars32( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars32( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_WebClient WWP_WebClient_BC
      {
         get {
            return bcwwpbaseobjects_notifications_web_WWP_WebClient ;
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
            return "webclient_Execute" ;
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
         Z153WWPWebClientId = "";
         A153WWPWebClientId = "";
         Z156WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         A156WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         Z157WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         A157WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         Z112WWPUserExtendedId = "";
         A112WWPUserExtendedId = "";
         Z155WWPWebClientBrowserVersion = "";
         A155WWPWebClientBrowserVersion = "";
         BC000M5_A153WWPWebClientId = new string[] {""} ;
         BC000M5_A154WWPWebClientBrowserId = new short[1] ;
         BC000M5_A155WWPWebClientBrowserVersion = new string[] {""} ;
         BC000M5_A156WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000M5_A157WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000M5_A112WWPUserExtendedId = new string[] {""} ;
         BC000M5_n112WWPUserExtendedId = new bool[] {false} ;
         BC000M4_A112WWPUserExtendedId = new string[] {""} ;
         BC000M4_n112WWPUserExtendedId = new bool[] {false} ;
         BC000M6_A153WWPWebClientId = new string[] {""} ;
         BC000M3_A153WWPWebClientId = new string[] {""} ;
         BC000M3_A154WWPWebClientBrowserId = new short[1] ;
         BC000M3_A155WWPWebClientBrowserVersion = new string[] {""} ;
         BC000M3_A156WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000M3_A157WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000M3_A112WWPUserExtendedId = new string[] {""} ;
         BC000M3_n112WWPUserExtendedId = new bool[] {false} ;
         sMode32 = "";
         BC000M2_A153WWPWebClientId = new string[] {""} ;
         BC000M2_A154WWPWebClientBrowserId = new short[1] ;
         BC000M2_A155WWPWebClientBrowserVersion = new string[] {""} ;
         BC000M2_A156WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000M2_A157WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000M2_A112WWPUserExtendedId = new string[] {""} ;
         BC000M2_n112WWPUserExtendedId = new bool[] {false} ;
         BC000M10_A153WWPWebClientId = new string[] {""} ;
         BC000M10_A154WWPWebClientBrowserId = new short[1] ;
         BC000M10_A155WWPWebClientBrowserVersion = new string[] {""} ;
         BC000M10_A156WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000M10_A157WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000M10_A112WWPUserExtendedId = new string[] {""} ;
         BC000M10_n112WWPUserExtendedId = new bool[] {false} ;
         i156WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         i157WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webclient_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webclient_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webclient_bc__default(),
            new Object[][] {
                new Object[] {
               BC000M2_A153WWPWebClientId, BC000M2_A154WWPWebClientBrowserId, BC000M2_A155WWPWebClientBrowserVersion, BC000M2_A156WWPWebClientFirstRegistered, BC000M2_A157WWPWebClientLastRegistered, BC000M2_A112WWPUserExtendedId, BC000M2_n112WWPUserExtendedId
               }
               , new Object[] {
               BC000M3_A153WWPWebClientId, BC000M3_A154WWPWebClientBrowserId, BC000M3_A155WWPWebClientBrowserVersion, BC000M3_A156WWPWebClientFirstRegistered, BC000M3_A157WWPWebClientLastRegistered, BC000M3_A112WWPUserExtendedId, BC000M3_n112WWPUserExtendedId
               }
               , new Object[] {
               BC000M4_A112WWPUserExtendedId
               }
               , new Object[] {
               BC000M5_A153WWPWebClientId, BC000M5_A154WWPWebClientBrowserId, BC000M5_A155WWPWebClientBrowserVersion, BC000M5_A156WWPWebClientFirstRegistered, BC000M5_A157WWPWebClientLastRegistered, BC000M5_A112WWPUserExtendedId, BC000M5_n112WWPUserExtendedId
               }
               , new Object[] {
               BC000M6_A153WWPWebClientId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000M10_A153WWPWebClientId, BC000M10_A154WWPWebClientBrowserId, BC000M10_A155WWPWebClientBrowserVersion, BC000M10_A156WWPWebClientFirstRegistered, BC000M10_A157WWPWebClientLastRegistered, BC000M10_A112WWPUserExtendedId, BC000M10_n112WWPUserExtendedId
               }
            }
         );
         Z157WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         A157WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         i157WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         Z156WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         A156WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         i156WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z154WWPWebClientBrowserId ;
      private short A154WWPWebClientBrowserId ;
      private short Gx_BScreen ;
      private short RcdFound32 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z153WWPWebClientId ;
      private string A153WWPWebClientId ;
      private string Z112WWPUserExtendedId ;
      private string A112WWPUserExtendedId ;
      private string sMode32 ;
      private DateTime Z156WWPWebClientFirstRegistered ;
      private DateTime A156WWPWebClientFirstRegistered ;
      private DateTime Z157WWPWebClientLastRegistered ;
      private DateTime A157WWPWebClientLastRegistered ;
      private DateTime i156WWPWebClientFirstRegistered ;
      private DateTime i157WWPWebClientLastRegistered ;
      private bool n112WWPUserExtendedId ;
      private string Z155WWPWebClientBrowserVersion ;
      private string A155WWPWebClientBrowserVersion ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000M5_A153WWPWebClientId ;
      private short[] BC000M5_A154WWPWebClientBrowserId ;
      private string[] BC000M5_A155WWPWebClientBrowserVersion ;
      private DateTime[] BC000M5_A156WWPWebClientFirstRegistered ;
      private DateTime[] BC000M5_A157WWPWebClientLastRegistered ;
      private string[] BC000M5_A112WWPUserExtendedId ;
      private bool[] BC000M5_n112WWPUserExtendedId ;
      private string[] BC000M4_A112WWPUserExtendedId ;
      private bool[] BC000M4_n112WWPUserExtendedId ;
      private string[] BC000M6_A153WWPWebClientId ;
      private string[] BC000M3_A153WWPWebClientId ;
      private short[] BC000M3_A154WWPWebClientBrowserId ;
      private string[] BC000M3_A155WWPWebClientBrowserVersion ;
      private DateTime[] BC000M3_A156WWPWebClientFirstRegistered ;
      private DateTime[] BC000M3_A157WWPWebClientLastRegistered ;
      private string[] BC000M3_A112WWPUserExtendedId ;
      private bool[] BC000M3_n112WWPUserExtendedId ;
      private string[] BC000M2_A153WWPWebClientId ;
      private short[] BC000M2_A154WWPWebClientBrowserId ;
      private string[] BC000M2_A155WWPWebClientBrowserVersion ;
      private DateTime[] BC000M2_A156WWPWebClientFirstRegistered ;
      private DateTime[] BC000M2_A157WWPWebClientLastRegistered ;
      private string[] BC000M2_A112WWPUserExtendedId ;
      private bool[] BC000M2_n112WWPUserExtendedId ;
      private string[] BC000M10_A153WWPWebClientId ;
      private short[] BC000M10_A154WWPWebClientBrowserId ;
      private string[] BC000M10_A155WWPWebClientBrowserVersion ;
      private DateTime[] BC000M10_A156WWPWebClientFirstRegistered ;
      private DateTime[] BC000M10_A157WWPWebClientLastRegistered ;
      private string[] BC000M10_A112WWPUserExtendedId ;
      private bool[] BC000M10_n112WWPUserExtendedId ;
      private GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient bcwwpbaseobjects_notifications_web_WWP_WebClient ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_webclient_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_webclient_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_webclient_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC000M2;
       prmBC000M2 = new Object[] {
       new ParDef("WWPWebClientId",GXType.Char,100,0)
       };
       Object[] prmBC000M3;
       prmBC000M3 = new Object[] {
       new ParDef("WWPWebClientId",GXType.Char,100,0)
       };
       Object[] prmBC000M4;
       prmBC000M4 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmBC000M5;
       prmBC000M5 = new Object[] {
       new ParDef("WWPWebClientId",GXType.Char,100,0)
       };
       Object[] prmBC000M6;
       prmBC000M6 = new Object[] {
       new ParDef("WWPWebClientId",GXType.Char,100,0)
       };
       Object[] prmBC000M7;
       prmBC000M7 = new Object[] {
       new ParDef("WWPWebClientId",GXType.Char,100,0) ,
       new ParDef("WWPWebClientBrowserId",GXType.Int16,4,0) ,
       new ParDef("WWPWebClientBrowserVersion",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPWebClientFirstRegistered",GXType.DateTime2,10,12) ,
       new ParDef("WWPWebClientLastRegistered",GXType.DateTime2,10,12) ,
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmBC000M8;
       prmBC000M8 = new Object[] {
       new ParDef("WWPWebClientBrowserId",GXType.Int16,4,0) ,
       new ParDef("WWPWebClientBrowserVersion",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPWebClientFirstRegistered",GXType.DateTime2,10,12) ,
       new ParDef("WWPWebClientLastRegistered",GXType.DateTime2,10,12) ,
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
       new ParDef("WWPWebClientId",GXType.Char,100,0)
       };
       Object[] prmBC000M9;
       prmBC000M9 = new Object[] {
       new ParDef("WWPWebClientId",GXType.Char,100,0)
       };
       Object[] prmBC000M10;
       prmBC000M10 = new Object[] {
       new ParDef("WWPWebClientId",GXType.Char,100,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC000M2", "SELECT WWPWebClientId, WWPWebClientBrowserId, WWPWebClientBrowserVersion, WWPWebClientFirstRegistered, WWPWebClientLastRegistered, WWPUserExtendedId FROM WWP_WebClient WHERE WWPWebClientId = :WWPWebClientId  FOR UPDATE OF WWP_WebClient",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000M3", "SELECT WWPWebClientId, WWPWebClientBrowserId, WWPWebClientBrowserVersion, WWPWebClientFirstRegistered, WWPWebClientLastRegistered, WWPUserExtendedId FROM WWP_WebClient WHERE WWPWebClientId = :WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000M4", "SELECT WWPUserExtendedId FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000M5", "SELECT TM1.WWPWebClientId, TM1.WWPWebClientBrowserId, TM1.WWPWebClientBrowserVersion, TM1.WWPWebClientFirstRegistered, TM1.WWPWebClientLastRegistered, TM1.WWPUserExtendedId FROM WWP_WebClient TM1 WHERE TM1.WWPWebClientId = ( :WWPWebClientId) ORDER BY TM1.WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000M6", "SELECT WWPWebClientId FROM WWP_WebClient WHERE WWPWebClientId = :WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000M7", "SAVEPOINT gxupdate;INSERT INTO WWP_WebClient(WWPWebClientId, WWPWebClientBrowserId, WWPWebClientBrowserVersion, WWPWebClientFirstRegistered, WWPWebClientLastRegistered, WWPUserExtendedId) VALUES(:WWPWebClientId, :WWPWebClientBrowserId, :WWPWebClientBrowserVersion, :WWPWebClientFirstRegistered, :WWPWebClientLastRegistered, :WWPUserExtendedId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000M7)
          ,new CursorDef("BC000M8", "SAVEPOINT gxupdate;UPDATE WWP_WebClient SET WWPWebClientBrowserId=:WWPWebClientBrowserId, WWPWebClientBrowserVersion=:WWPWebClientBrowserVersion, WWPWebClientFirstRegistered=:WWPWebClientFirstRegistered, WWPWebClientLastRegistered=:WWPWebClientLastRegistered, WWPUserExtendedId=:WWPUserExtendedId  WHERE WWPWebClientId = :WWPWebClientId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000M8)
          ,new CursorDef("BC000M9", "SAVEPOINT gxupdate;DELETE FROM WWP_WebClient  WHERE WWPWebClientId = :WWPWebClientId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000M9)
          ,new CursorDef("BC000M10", "SELECT TM1.WWPWebClientId, TM1.WWPWebClientBrowserId, TM1.WWPWebClientBrowserVersion, TM1.WWPWebClientFirstRegistered, TM1.WWPWebClientLastRegistered, TM1.WWPUserExtendedId FROM WWP_WebClient TM1 WHERE TM1.WWPWebClientId = ( :WWPWebClientId) ORDER BY TM1.WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M10,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[0])[0] = rslt.getString(1, 100);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
             ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
             ((string[]) buf[5])[0] = rslt.getString(6, 40);
             ((bool[]) buf[6])[0] = rslt.wasNull(6);
             return;
          case 1 :
             ((string[]) buf[0])[0] = rslt.getString(1, 100);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
             ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
             ((string[]) buf[5])[0] = rslt.getString(6, 40);
             ((bool[]) buf[6])[0] = rslt.wasNull(6);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getString(1, 40);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getString(1, 100);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
             ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
             ((string[]) buf[5])[0] = rslt.getString(6, 40);
             ((bool[]) buf[6])[0] = rslt.wasNull(6);
             return;
          case 4 :
             ((string[]) buf[0])[0] = rslt.getString(1, 100);
             return;
          case 8 :
             ((string[]) buf[0])[0] = rslt.getString(1, 100);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
             ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
             ((string[]) buf[5])[0] = rslt.getString(6, 40);
             ((bool[]) buf[6])[0] = rslt.wasNull(6);
             return;
    }
 }

}

}
