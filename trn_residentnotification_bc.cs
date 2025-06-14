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
   public class trn_residentnotification_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_residentnotification_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_residentnotification_bc( IGxContext context )
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
         ReadRow1F86( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1F86( ) ;
         standaloneModal( ) ;
         AddRow1F86( ) ;
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
               Z485ResidentNotificationId = A485ResidentNotificationId;
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

      protected void CONFIRM_1F0( )
      {
         BeforeValidate1F86( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1F86( ) ;
            }
            else
            {
               CheckExtendedTable1F86( ) ;
               if ( AnyError == 0 )
               {
                  ZM1F86( 7) ;
               }
               CloseExtendedTableCursors1F86( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1F86( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z62ResidentId = A62ResidentId;
            Z486AppNotificationId = A486AppNotificationId;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z489AppNotificationDate = A489AppNotificationDate;
            Z487AppNotificationTitle = A487AppNotificationTitle;
            Z488AppNotificationDescription = A488AppNotificationDescription;
            Z490AppNotificationTopic = A490AppNotificationTopic;
         }
         if ( GX_JID == -6 )
         {
            Z485ResidentNotificationId = A485ResidentNotificationId;
            Z62ResidentId = A62ResidentId;
            Z486AppNotificationId = A486AppNotificationId;
            Z489AppNotificationDate = A489AppNotificationDate;
            Z487AppNotificationTitle = A487AppNotificationTitle;
            Z488AppNotificationDescription = A488AppNotificationDescription;
            Z490AppNotificationTopic = A490AppNotificationTopic;
            Z498AppNotificationMetadata = A498AppNotificationMetadata;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A62ResidentId) )
         {
            A62ResidentId = Guid.NewGuid( );
         }
         if ( IsIns( )  && (Guid.Empty==A485ResidentNotificationId) )
         {
            A485ResidentNotificationId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1F86( )
      {
         /* Using cursor BC001F5 */
         pr_default.execute(3, new Object[] {A485ResidentNotificationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound86 = 1;
            A62ResidentId = BC001F5_A62ResidentId[0];
            A489AppNotificationDate = BC001F5_A489AppNotificationDate[0];
            A487AppNotificationTitle = BC001F5_A487AppNotificationTitle[0];
            A488AppNotificationDescription = BC001F5_A488AppNotificationDescription[0];
            A490AppNotificationTopic = BC001F5_A490AppNotificationTopic[0];
            A498AppNotificationMetadata = BC001F5_A498AppNotificationMetadata[0];
            n498AppNotificationMetadata = BC001F5_n498AppNotificationMetadata[0];
            A486AppNotificationId = BC001F5_A486AppNotificationId[0];
            ZM1F86( -6) ;
         }
         pr_default.close(3);
         OnLoadActions1F86( ) ;
      }

      protected void OnLoadActions1F86( )
      {
      }

      protected void CheckExtendedTable1F86( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001F4 */
         pr_default.execute(2, new Object[] {A486AppNotificationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "App Notifications", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "APPNOTIFICATIONID");
            AnyError = 1;
         }
         A489AppNotificationDate = BC001F4_A489AppNotificationDate[0];
         A487AppNotificationTitle = BC001F4_A487AppNotificationTitle[0];
         A488AppNotificationDescription = BC001F4_A488AppNotificationDescription[0];
         A490AppNotificationTopic = BC001F4_A490AppNotificationTopic[0];
         A498AppNotificationMetadata = BC001F4_A498AppNotificationMetadata[0];
         n498AppNotificationMetadata = BC001F4_n498AppNotificationMetadata[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1F86( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1F86( )
      {
         /* Using cursor BC001F6 */
         pr_default.execute(4, new Object[] {A485ResidentNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound86 = 1;
         }
         else
         {
            RcdFound86 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001F3 */
         pr_default.execute(1, new Object[] {A485ResidentNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1F86( 6) ;
            RcdFound86 = 1;
            A485ResidentNotificationId = BC001F3_A485ResidentNotificationId[0];
            A62ResidentId = BC001F3_A62ResidentId[0];
            A486AppNotificationId = BC001F3_A486AppNotificationId[0];
            Z485ResidentNotificationId = A485ResidentNotificationId;
            sMode86 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1F86( ) ;
            if ( AnyError == 1 )
            {
               RcdFound86 = 0;
               InitializeNonKey1F86( ) ;
            }
            Gx_mode = sMode86;
         }
         else
         {
            RcdFound86 = 0;
            InitializeNonKey1F86( ) ;
            sMode86 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode86;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1F86( ) ;
         if ( RcdFound86 == 0 )
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
         CONFIRM_1F0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1F86( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001F2 */
            pr_default.execute(0, new Object[] {A485ResidentNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ResidentNotification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z62ResidentId != BC001F2_A62ResidentId[0] ) || ( Z486AppNotificationId != BC001F2_A486AppNotificationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ResidentNotification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1F86( )
      {
         BeforeValidate1F86( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1F86( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1F86( 0) ;
            CheckOptimisticConcurrency1F86( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1F86( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1F86( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001F7 */
                     pr_default.execute(5, new Object[] {A485ResidentNotificationId, A62ResidentId, A486AppNotificationId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentNotification");
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
               Load1F86( ) ;
            }
            EndLevel1F86( ) ;
         }
         CloseExtendedTableCursors1F86( ) ;
      }

      protected void Update1F86( )
      {
         BeforeValidate1F86( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1F86( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1F86( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1F86( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1F86( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001F8 */
                     pr_default.execute(6, new Object[] {A62ResidentId, A486AppNotificationId, A485ResidentNotificationId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentNotification");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ResidentNotification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1F86( ) ;
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
            EndLevel1F86( ) ;
         }
         CloseExtendedTableCursors1F86( ) ;
      }

      protected void DeferredUpdate1F86( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1F86( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1F86( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1F86( ) ;
            AfterConfirm1F86( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1F86( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001F9 */
                  pr_default.execute(7, new Object[] {A485ResidentNotificationId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ResidentNotification");
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
         sMode86 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1F86( ) ;
         Gx_mode = sMode86;
      }

      protected void OnDeleteControls1F86( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001F10 */
            pr_default.execute(8, new Object[] {A486AppNotificationId});
            A489AppNotificationDate = BC001F10_A489AppNotificationDate[0];
            A487AppNotificationTitle = BC001F10_A487AppNotificationTitle[0];
            A488AppNotificationDescription = BC001F10_A488AppNotificationDescription[0];
            A490AppNotificationTopic = BC001F10_A490AppNotificationTopic[0];
            A498AppNotificationMetadata = BC001F10_A498AppNotificationMetadata[0];
            n498AppNotificationMetadata = BC001F10_n498AppNotificationMetadata[0];
            pr_default.close(8);
         }
      }

      protected void EndLevel1F86( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1F86( ) ;
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

      public void ScanKeyStart1F86( )
      {
         /* Using cursor BC001F11 */
         pr_default.execute(9, new Object[] {A485ResidentNotificationId});
         RcdFound86 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound86 = 1;
            A485ResidentNotificationId = BC001F11_A485ResidentNotificationId[0];
            A62ResidentId = BC001F11_A62ResidentId[0];
            A489AppNotificationDate = BC001F11_A489AppNotificationDate[0];
            A487AppNotificationTitle = BC001F11_A487AppNotificationTitle[0];
            A488AppNotificationDescription = BC001F11_A488AppNotificationDescription[0];
            A490AppNotificationTopic = BC001F11_A490AppNotificationTopic[0];
            A498AppNotificationMetadata = BC001F11_A498AppNotificationMetadata[0];
            n498AppNotificationMetadata = BC001F11_n498AppNotificationMetadata[0];
            A486AppNotificationId = BC001F11_A486AppNotificationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1F86( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound86 = 0;
         ScanKeyLoad1F86( ) ;
      }

      protected void ScanKeyLoad1F86( )
      {
         sMode86 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound86 = 1;
            A485ResidentNotificationId = BC001F11_A485ResidentNotificationId[0];
            A62ResidentId = BC001F11_A62ResidentId[0];
            A489AppNotificationDate = BC001F11_A489AppNotificationDate[0];
            A487AppNotificationTitle = BC001F11_A487AppNotificationTitle[0];
            A488AppNotificationDescription = BC001F11_A488AppNotificationDescription[0];
            A490AppNotificationTopic = BC001F11_A490AppNotificationTopic[0];
            A498AppNotificationMetadata = BC001F11_A498AppNotificationMetadata[0];
            n498AppNotificationMetadata = BC001F11_n498AppNotificationMetadata[0];
            A486AppNotificationId = BC001F11_A486AppNotificationId[0];
         }
         Gx_mode = sMode86;
      }

      protected void ScanKeyEnd1F86( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1F86( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1F86( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1F86( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1F86( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1F86( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1F86( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1F86( )
      {
      }

      protected void send_integrity_lvl_hashes1F86( )
      {
      }

      protected void AddRow1F86( )
      {
         VarsToRow86( bcTrn_ResidentNotification) ;
      }

      protected void ReadRow1F86( )
      {
         RowToVars86( bcTrn_ResidentNotification, 1) ;
      }

      protected void InitializeNonKey1F86( )
      {
         A486AppNotificationId = Guid.Empty;
         A489AppNotificationDate = (DateTime)(DateTime.MinValue);
         A487AppNotificationTitle = "";
         A488AppNotificationDescription = "";
         A490AppNotificationTopic = "";
         A498AppNotificationMetadata = "";
         n498AppNotificationMetadata = false;
         A62ResidentId = Guid.NewGuid( );
         Z62ResidentId = Guid.Empty;
         Z486AppNotificationId = Guid.Empty;
      }

      protected void InitAll1F86( )
      {
         A485ResidentNotificationId = Guid.NewGuid( );
         InitializeNonKey1F86( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A62ResidentId = i62ResidentId;
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

      public void VarsToRow86( SdtTrn_ResidentNotification obj86 )
      {
         obj86.gxTpr_Mode = Gx_mode;
         obj86.gxTpr_Appnotificationid = A486AppNotificationId;
         obj86.gxTpr_Appnotificationdate = A489AppNotificationDate;
         obj86.gxTpr_Appnotificationtitle = A487AppNotificationTitle;
         obj86.gxTpr_Appnotificationdescription = A488AppNotificationDescription;
         obj86.gxTpr_Appnotificationtopic = A490AppNotificationTopic;
         obj86.gxTpr_Appnotificationmetadata = A498AppNotificationMetadata;
         obj86.gxTpr_Residentid = A62ResidentId;
         obj86.gxTpr_Residentnotificationid = A485ResidentNotificationId;
         obj86.gxTpr_Residentnotificationid_Z = Z485ResidentNotificationId;
         obj86.gxTpr_Appnotificationid_Z = Z486AppNotificationId;
         obj86.gxTpr_Appnotificationdate_Z = Z489AppNotificationDate;
         obj86.gxTpr_Appnotificationtitle_Z = Z487AppNotificationTitle;
         obj86.gxTpr_Appnotificationdescription_Z = Z488AppNotificationDescription;
         obj86.gxTpr_Appnotificationtopic_Z = Z490AppNotificationTopic;
         obj86.gxTpr_Residentid_Z = Z62ResidentId;
         obj86.gxTpr_Appnotificationmetadata_N = (short)(Convert.ToInt16(n498AppNotificationMetadata));
         obj86.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow86( SdtTrn_ResidentNotification obj86 )
      {
         obj86.gxTpr_Residentnotificationid = A485ResidentNotificationId;
         return  ;
      }

      public void RowToVars86( SdtTrn_ResidentNotification obj86 ,
                               int forceLoad )
      {
         Gx_mode = obj86.gxTpr_Mode;
         A486AppNotificationId = obj86.gxTpr_Appnotificationid;
         A489AppNotificationDate = obj86.gxTpr_Appnotificationdate;
         A487AppNotificationTitle = obj86.gxTpr_Appnotificationtitle;
         A488AppNotificationDescription = obj86.gxTpr_Appnotificationdescription;
         A490AppNotificationTopic = obj86.gxTpr_Appnotificationtopic;
         A498AppNotificationMetadata = obj86.gxTpr_Appnotificationmetadata;
         n498AppNotificationMetadata = false;
         A62ResidentId = obj86.gxTpr_Residentid;
         A485ResidentNotificationId = obj86.gxTpr_Residentnotificationid;
         Z485ResidentNotificationId = obj86.gxTpr_Residentnotificationid_Z;
         Z486AppNotificationId = obj86.gxTpr_Appnotificationid_Z;
         Z489AppNotificationDate = obj86.gxTpr_Appnotificationdate_Z;
         Z487AppNotificationTitle = obj86.gxTpr_Appnotificationtitle_Z;
         Z488AppNotificationDescription = obj86.gxTpr_Appnotificationdescription_Z;
         Z490AppNotificationTopic = obj86.gxTpr_Appnotificationtopic_Z;
         Z62ResidentId = obj86.gxTpr_Residentid_Z;
         n498AppNotificationMetadata = (bool)(Convert.ToBoolean(obj86.gxTpr_Appnotificationmetadata_N));
         Gx_mode = obj86.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A485ResidentNotificationId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1F86( ) ;
         ScanKeyStart1F86( ) ;
         if ( RcdFound86 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z485ResidentNotificationId = A485ResidentNotificationId;
         }
         ZM1F86( -6) ;
         OnLoadActions1F86( ) ;
         AddRow1F86( ) ;
         ScanKeyEnd1F86( ) ;
         if ( RcdFound86 == 0 )
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
         RowToVars86( bcTrn_ResidentNotification, 0) ;
         ScanKeyStart1F86( ) ;
         if ( RcdFound86 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z485ResidentNotificationId = A485ResidentNotificationId;
         }
         ZM1F86( -6) ;
         OnLoadActions1F86( ) ;
         AddRow1F86( ) ;
         ScanKeyEnd1F86( ) ;
         if ( RcdFound86 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1F86( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1F86( ) ;
         }
         else
         {
            if ( RcdFound86 == 1 )
            {
               if ( A485ResidentNotificationId != Z485ResidentNotificationId )
               {
                  A485ResidentNotificationId = Z485ResidentNotificationId;
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
                  Update1F86( ) ;
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
                  if ( A485ResidentNotificationId != Z485ResidentNotificationId )
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
                        Insert1F86( ) ;
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
                        Insert1F86( ) ;
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
         RowToVars86( bcTrn_ResidentNotification, 1) ;
         SaveImpl( ) ;
         VarsToRow86( bcTrn_ResidentNotification) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars86( bcTrn_ResidentNotification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1F86( ) ;
         AfterTrn( ) ;
         VarsToRow86( bcTrn_ResidentNotification) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow86( bcTrn_ResidentNotification) ;
         }
         else
         {
            SdtTrn_ResidentNotification auxBC = new SdtTrn_ResidentNotification(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A485ResidentNotificationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_ResidentNotification);
               auxBC.Save();
               bcTrn_ResidentNotification.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars86( bcTrn_ResidentNotification, 1) ;
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
         RowToVars86( bcTrn_ResidentNotification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1F86( ) ;
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
               VarsToRow86( bcTrn_ResidentNotification) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow86( bcTrn_ResidentNotification) ;
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
         RowToVars86( bcTrn_ResidentNotification, 0) ;
         GetKey1F86( ) ;
         if ( RcdFound86 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A485ResidentNotificationId != Z485ResidentNotificationId )
            {
               A485ResidentNotificationId = Z485ResidentNotificationId;
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
            if ( A485ResidentNotificationId != Z485ResidentNotificationId )
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
         context.RollbackDataStores("trn_residentnotification_bc",pr_default);
         VarsToRow86( bcTrn_ResidentNotification) ;
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
         Gx_mode = bcTrn_ResidentNotification.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_ResidentNotification.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_ResidentNotification )
         {
            bcTrn_ResidentNotification = (SdtTrn_ResidentNotification)(sdt);
            if ( StringUtil.StrCmp(bcTrn_ResidentNotification.gxTpr_Mode, "") == 0 )
            {
               bcTrn_ResidentNotification.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow86( bcTrn_ResidentNotification) ;
            }
            else
            {
               RowToVars86( bcTrn_ResidentNotification, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_ResidentNotification.gxTpr_Mode, "") == 0 )
            {
               bcTrn_ResidentNotification.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars86( bcTrn_ResidentNotification, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_ResidentNotification Trn_ResidentNotification_BC
      {
         get {
            return bcTrn_ResidentNotification ;
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
            return "trn_residentnotification_Execute" ;
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
         pr_default.close(8);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z485ResidentNotificationId = Guid.Empty;
         A485ResidentNotificationId = Guid.Empty;
         Z62ResidentId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         Z486AppNotificationId = Guid.Empty;
         A486AppNotificationId = Guid.Empty;
         Z489AppNotificationDate = (DateTime)(DateTime.MinValue);
         A489AppNotificationDate = (DateTime)(DateTime.MinValue);
         Z487AppNotificationTitle = "";
         A487AppNotificationTitle = "";
         Z488AppNotificationDescription = "";
         A488AppNotificationDescription = "";
         Z490AppNotificationTopic = "";
         A490AppNotificationTopic = "";
         Z498AppNotificationMetadata = "";
         A498AppNotificationMetadata = "";
         BC001F5_A485ResidentNotificationId = new Guid[] {Guid.Empty} ;
         BC001F5_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001F5_A489AppNotificationDate = new DateTime[] {DateTime.MinValue} ;
         BC001F5_A487AppNotificationTitle = new string[] {""} ;
         BC001F5_A488AppNotificationDescription = new string[] {""} ;
         BC001F5_A490AppNotificationTopic = new string[] {""} ;
         BC001F5_A498AppNotificationMetadata = new string[] {""} ;
         BC001F5_n498AppNotificationMetadata = new bool[] {false} ;
         BC001F5_A486AppNotificationId = new Guid[] {Guid.Empty} ;
         BC001F4_A489AppNotificationDate = new DateTime[] {DateTime.MinValue} ;
         BC001F4_A487AppNotificationTitle = new string[] {""} ;
         BC001F4_A488AppNotificationDescription = new string[] {""} ;
         BC001F4_A490AppNotificationTopic = new string[] {""} ;
         BC001F4_A498AppNotificationMetadata = new string[] {""} ;
         BC001F4_n498AppNotificationMetadata = new bool[] {false} ;
         BC001F6_A485ResidentNotificationId = new Guid[] {Guid.Empty} ;
         BC001F3_A485ResidentNotificationId = new Guid[] {Guid.Empty} ;
         BC001F3_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001F3_A486AppNotificationId = new Guid[] {Guid.Empty} ;
         sMode86 = "";
         BC001F2_A485ResidentNotificationId = new Guid[] {Guid.Empty} ;
         BC001F2_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001F2_A486AppNotificationId = new Guid[] {Guid.Empty} ;
         BC001F10_A489AppNotificationDate = new DateTime[] {DateTime.MinValue} ;
         BC001F10_A487AppNotificationTitle = new string[] {""} ;
         BC001F10_A488AppNotificationDescription = new string[] {""} ;
         BC001F10_A490AppNotificationTopic = new string[] {""} ;
         BC001F10_A498AppNotificationMetadata = new string[] {""} ;
         BC001F10_n498AppNotificationMetadata = new bool[] {false} ;
         BC001F11_A485ResidentNotificationId = new Guid[] {Guid.Empty} ;
         BC001F11_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001F11_A489AppNotificationDate = new DateTime[] {DateTime.MinValue} ;
         BC001F11_A487AppNotificationTitle = new string[] {""} ;
         BC001F11_A488AppNotificationDescription = new string[] {""} ;
         BC001F11_A490AppNotificationTopic = new string[] {""} ;
         BC001F11_A498AppNotificationMetadata = new string[] {""} ;
         BC001F11_n498AppNotificationMetadata = new bool[] {false} ;
         BC001F11_A486AppNotificationId = new Guid[] {Guid.Empty} ;
         i62ResidentId = Guid.Empty;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_residentnotification_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_residentnotification_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_residentnotification_bc__default(),
            new Object[][] {
                new Object[] {
               BC001F2_A485ResidentNotificationId, BC001F2_A62ResidentId, BC001F2_A486AppNotificationId
               }
               , new Object[] {
               BC001F3_A485ResidentNotificationId, BC001F3_A62ResidentId, BC001F3_A486AppNotificationId
               }
               , new Object[] {
               BC001F4_A489AppNotificationDate, BC001F4_A487AppNotificationTitle, BC001F4_A488AppNotificationDescription, BC001F4_A490AppNotificationTopic, BC001F4_A498AppNotificationMetadata, BC001F4_n498AppNotificationMetadata
               }
               , new Object[] {
               BC001F5_A485ResidentNotificationId, BC001F5_A62ResidentId, BC001F5_A489AppNotificationDate, BC001F5_A487AppNotificationTitle, BC001F5_A488AppNotificationDescription, BC001F5_A490AppNotificationTopic, BC001F5_A498AppNotificationMetadata, BC001F5_n498AppNotificationMetadata, BC001F5_A486AppNotificationId
               }
               , new Object[] {
               BC001F6_A485ResidentNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001F10_A489AppNotificationDate, BC001F10_A487AppNotificationTitle, BC001F10_A488AppNotificationDescription, BC001F10_A490AppNotificationTopic, BC001F10_A498AppNotificationMetadata, BC001F10_n498AppNotificationMetadata
               }
               , new Object[] {
               BC001F11_A485ResidentNotificationId, BC001F11_A62ResidentId, BC001F11_A489AppNotificationDate, BC001F11_A487AppNotificationTitle, BC001F11_A488AppNotificationDescription, BC001F11_A490AppNotificationTopic, BC001F11_A498AppNotificationMetadata, BC001F11_n498AppNotificationMetadata, BC001F11_A486AppNotificationId
               }
            }
         );
         Z62ResidentId = Guid.NewGuid( );
         A62ResidentId = Guid.NewGuid( );
         i62ResidentId = Guid.NewGuid( );
         Z485ResidentNotificationId = Guid.NewGuid( );
         A485ResidentNotificationId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound86 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode86 ;
      private DateTime Z489AppNotificationDate ;
      private DateTime A489AppNotificationDate ;
      private bool n498AppNotificationMetadata ;
      private string Z498AppNotificationMetadata ;
      private string A498AppNotificationMetadata ;
      private string Z487AppNotificationTitle ;
      private string A487AppNotificationTitle ;
      private string Z488AppNotificationDescription ;
      private string A488AppNotificationDescription ;
      private string Z490AppNotificationTopic ;
      private string A490AppNotificationTopic ;
      private Guid Z485ResidentNotificationId ;
      private Guid A485ResidentNotificationId ;
      private Guid Z62ResidentId ;
      private Guid A62ResidentId ;
      private Guid Z486AppNotificationId ;
      private Guid A486AppNotificationId ;
      private Guid i62ResidentId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001F5_A485ResidentNotificationId ;
      private Guid[] BC001F5_A62ResidentId ;
      private DateTime[] BC001F5_A489AppNotificationDate ;
      private string[] BC001F5_A487AppNotificationTitle ;
      private string[] BC001F5_A488AppNotificationDescription ;
      private string[] BC001F5_A490AppNotificationTopic ;
      private string[] BC001F5_A498AppNotificationMetadata ;
      private bool[] BC001F5_n498AppNotificationMetadata ;
      private Guid[] BC001F5_A486AppNotificationId ;
      private DateTime[] BC001F4_A489AppNotificationDate ;
      private string[] BC001F4_A487AppNotificationTitle ;
      private string[] BC001F4_A488AppNotificationDescription ;
      private string[] BC001F4_A490AppNotificationTopic ;
      private string[] BC001F4_A498AppNotificationMetadata ;
      private bool[] BC001F4_n498AppNotificationMetadata ;
      private Guid[] BC001F6_A485ResidentNotificationId ;
      private Guid[] BC001F3_A485ResidentNotificationId ;
      private Guid[] BC001F3_A62ResidentId ;
      private Guid[] BC001F3_A486AppNotificationId ;
      private Guid[] BC001F2_A485ResidentNotificationId ;
      private Guid[] BC001F2_A62ResidentId ;
      private Guid[] BC001F2_A486AppNotificationId ;
      private DateTime[] BC001F10_A489AppNotificationDate ;
      private string[] BC001F10_A487AppNotificationTitle ;
      private string[] BC001F10_A488AppNotificationDescription ;
      private string[] BC001F10_A490AppNotificationTopic ;
      private string[] BC001F10_A498AppNotificationMetadata ;
      private bool[] BC001F10_n498AppNotificationMetadata ;
      private Guid[] BC001F11_A485ResidentNotificationId ;
      private Guid[] BC001F11_A62ResidentId ;
      private DateTime[] BC001F11_A489AppNotificationDate ;
      private string[] BC001F11_A487AppNotificationTitle ;
      private string[] BC001F11_A488AppNotificationDescription ;
      private string[] BC001F11_A490AppNotificationTopic ;
      private string[] BC001F11_A498AppNotificationMetadata ;
      private bool[] BC001F11_n498AppNotificationMetadata ;
      private Guid[] BC001F11_A486AppNotificationId ;
      private SdtTrn_ResidentNotification bcTrn_ResidentNotification ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_residentnotification_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_residentnotification_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_residentnotification_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[9])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC001F2;
       prmBC001F2 = new Object[] {
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001F3;
       prmBC001F3 = new Object[] {
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001F4;
       prmBC001F4 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001F5;
       prmBC001F5 = new Object[] {
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001F6;
       prmBC001F6 = new Object[] {
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001F7;
       prmBC001F7 = new Object[] {
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001F8;
       prmBC001F8 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001F9;
       prmBC001F9 = new Object[] {
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001F10;
       prmBC001F10 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001F11;
       prmBC001F11 = new Object[] {
       new ParDef("ResidentNotificationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001F2", "SELECT ResidentNotificationId, ResidentId, AppNotificationId FROM Trn_ResidentNotification WHERE ResidentNotificationId = :ResidentNotificationId  FOR UPDATE OF Trn_ResidentNotification",true, GxErrorMask.GX_NOMASK, false, this,prmBC001F2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001F3", "SELECT ResidentNotificationId, ResidentId, AppNotificationId FROM Trn_ResidentNotification WHERE ResidentNotificationId = :ResidentNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001F3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001F4", "SELECT AppNotificationDate, AppNotificationTitle, AppNotificationDescription, AppNotificationTopic, AppNotificationMetadata FROM Trn_AppNotification WHERE AppNotificationId = :AppNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001F4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001F5", "SELECT TM1.ResidentNotificationId, TM1.ResidentId, T2.AppNotificationDate, T2.AppNotificationTitle, T2.AppNotificationDescription, T2.AppNotificationTopic, T2.AppNotificationMetadata, TM1.AppNotificationId FROM (Trn_ResidentNotification TM1 INNER JOIN Trn_AppNotification T2 ON T2.AppNotificationId = TM1.AppNotificationId) WHERE TM1.ResidentNotificationId = :ResidentNotificationId ORDER BY TM1.ResidentNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001F5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001F6", "SELECT ResidentNotificationId FROM Trn_ResidentNotification WHERE ResidentNotificationId = :ResidentNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001F6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001F7", "SAVEPOINT gxupdate;INSERT INTO Trn_ResidentNotification(ResidentNotificationId, ResidentId, AppNotificationId) VALUES(:ResidentNotificationId, :ResidentId, :AppNotificationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001F7)
          ,new CursorDef("BC001F8", "SAVEPOINT gxupdate;UPDATE Trn_ResidentNotification SET ResidentId=:ResidentId, AppNotificationId=:AppNotificationId  WHERE ResidentNotificationId = :ResidentNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001F8)
          ,new CursorDef("BC001F9", "SAVEPOINT gxupdate;DELETE FROM Trn_ResidentNotification  WHERE ResidentNotificationId = :ResidentNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001F9)
          ,new CursorDef("BC001F10", "SELECT AppNotificationDate, AppNotificationTitle, AppNotificationDescription, AppNotificationTopic, AppNotificationMetadata FROM Trn_AppNotification WHERE AppNotificationId = :AppNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001F10,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001F11", "SELECT TM1.ResidentNotificationId, TM1.ResidentId, T2.AppNotificationDate, T2.AppNotificationTitle, T2.AppNotificationDescription, T2.AppNotificationTopic, T2.AppNotificationMetadata, TM1.AppNotificationId FROM (Trn_ResidentNotification TM1 INNER JOIN Trn_AppNotification T2 ON T2.AppNotificationId = TM1.AppNotificationId) WHERE TM1.ResidentNotificationId = :ResidentNotificationId ORDER BY TM1.ResidentNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001F11,100, GxCacheFrequency.OFF ,true,false )
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
             ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((bool[]) buf[7])[0] = rslt.wasNull(7);
             ((Guid[]) buf[8])[0] = rslt.getGuid(8);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((bool[]) buf[7])[0] = rslt.wasNull(7);
             ((Guid[]) buf[8])[0] = rslt.getGuid(8);
             return;
    }
 }

}

}
