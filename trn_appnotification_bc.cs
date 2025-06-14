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
   public class trn_appnotification_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_appnotification_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_appnotification_bc( IGxContext context )
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
         ReadRow1E85( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1E85( ) ;
         standaloneModal( ) ;
         AddRow1E85( ) ;
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
               Z486AppNotificationId = A486AppNotificationId;
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

      protected void CONFIRM_1E0( )
      {
         BeforeValidate1E85( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1E85( ) ;
            }
            else
            {
               CheckExtendedTable1E85( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1E85( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1E85( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z487AppNotificationTitle = A487AppNotificationTitle;
            Z488AppNotificationDescription = A488AppNotificationDescription;
            Z489AppNotificationDate = A489AppNotificationDate;
            Z490AppNotificationTopic = A490AppNotificationTopic;
         }
         if ( GX_JID == -3 )
         {
            Z486AppNotificationId = A486AppNotificationId;
            Z487AppNotificationTitle = A487AppNotificationTitle;
            Z488AppNotificationDescription = A488AppNotificationDescription;
            Z489AppNotificationDate = A489AppNotificationDate;
            Z490AppNotificationTopic = A490AppNotificationTopic;
            Z498AppNotificationMetadata = A498AppNotificationMetadata;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A486AppNotificationId) )
         {
            A486AppNotificationId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1E85( )
      {
         /* Using cursor BC001E4 */
         pr_default.execute(2, new Object[] {A486AppNotificationId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound85 = 1;
            A487AppNotificationTitle = BC001E4_A487AppNotificationTitle[0];
            A488AppNotificationDescription = BC001E4_A488AppNotificationDescription[0];
            A489AppNotificationDate = BC001E4_A489AppNotificationDate[0];
            A490AppNotificationTopic = BC001E4_A490AppNotificationTopic[0];
            A498AppNotificationMetadata = BC001E4_A498AppNotificationMetadata[0];
            n498AppNotificationMetadata = BC001E4_n498AppNotificationMetadata[0];
            ZM1E85( -3) ;
         }
         pr_default.close(2);
         OnLoadActions1E85( ) ;
      }

      protected void OnLoadActions1E85( )
      {
      }

      protected void CheckExtendedTable1E85( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1E85( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1E85( )
      {
         /* Using cursor BC001E5 */
         pr_default.execute(3, new Object[] {A486AppNotificationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound85 = 1;
         }
         else
         {
            RcdFound85 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001E3 */
         pr_default.execute(1, new Object[] {A486AppNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1E85( 3) ;
            RcdFound85 = 1;
            A486AppNotificationId = BC001E3_A486AppNotificationId[0];
            A487AppNotificationTitle = BC001E3_A487AppNotificationTitle[0];
            A488AppNotificationDescription = BC001E3_A488AppNotificationDescription[0];
            A489AppNotificationDate = BC001E3_A489AppNotificationDate[0];
            A490AppNotificationTopic = BC001E3_A490AppNotificationTopic[0];
            A498AppNotificationMetadata = BC001E3_A498AppNotificationMetadata[0];
            n498AppNotificationMetadata = BC001E3_n498AppNotificationMetadata[0];
            Z486AppNotificationId = A486AppNotificationId;
            sMode85 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1E85( ) ;
            if ( AnyError == 1 )
            {
               RcdFound85 = 0;
               InitializeNonKey1E85( ) ;
            }
            Gx_mode = sMode85;
         }
         else
         {
            RcdFound85 = 0;
            InitializeNonKey1E85( ) ;
            sMode85 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode85;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1E85( ) ;
         if ( RcdFound85 == 0 )
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
         CONFIRM_1E0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1E85( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001E2 */
            pr_default.execute(0, new Object[] {A486AppNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppNotification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z487AppNotificationTitle, BC001E2_A487AppNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z488AppNotificationDescription, BC001E2_A488AppNotificationDescription[0]) != 0 ) || ( Z489AppNotificationDate != BC001E2_A489AppNotificationDate[0] ) || ( StringUtil.StrCmp(Z490AppNotificationTopic, BC001E2_A490AppNotificationTopic[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_AppNotification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1E85( )
      {
         BeforeValidate1E85( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1E85( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1E85( 0) ;
            CheckOptimisticConcurrency1E85( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1E85( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1E85( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001E6 */
                     pr_default.execute(4, new Object[] {A486AppNotificationId, A487AppNotificationTitle, A488AppNotificationDescription, A489AppNotificationDate, A490AppNotificationTopic, n498AppNotificationMetadata, A498AppNotificationMetadata});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppNotification");
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
               Load1E85( ) ;
            }
            EndLevel1E85( ) ;
         }
         CloseExtendedTableCursors1E85( ) ;
      }

      protected void Update1E85( )
      {
         BeforeValidate1E85( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1E85( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1E85( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1E85( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1E85( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001E7 */
                     pr_default.execute(5, new Object[] {A487AppNotificationTitle, A488AppNotificationDescription, A489AppNotificationDate, A490AppNotificationTopic, n498AppNotificationMetadata, A498AppNotificationMetadata, A486AppNotificationId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_AppNotification");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_AppNotification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1E85( ) ;
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
            EndLevel1E85( ) ;
         }
         CloseExtendedTableCursors1E85( ) ;
      }

      protected void DeferredUpdate1E85( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1E85( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1E85( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1E85( ) ;
            AfterConfirm1E85( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1E85( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001E8 */
                  pr_default.execute(6, new Object[] {A486AppNotificationId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_AppNotification");
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
         sMode85 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1E85( ) ;
         Gx_mode = sMode85;
      }

      protected void OnDeleteControls1E85( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC001E9 */
            pr_default.execute(7, new Object[] {A486AppNotificationId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Resident Notifications", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel1E85( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1E85( ) ;
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

      public void ScanKeyStart1E85( )
      {
         /* Using cursor BC001E10 */
         pr_default.execute(8, new Object[] {A486AppNotificationId});
         RcdFound85 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound85 = 1;
            A486AppNotificationId = BC001E10_A486AppNotificationId[0];
            A487AppNotificationTitle = BC001E10_A487AppNotificationTitle[0];
            A488AppNotificationDescription = BC001E10_A488AppNotificationDescription[0];
            A489AppNotificationDate = BC001E10_A489AppNotificationDate[0];
            A490AppNotificationTopic = BC001E10_A490AppNotificationTopic[0];
            A498AppNotificationMetadata = BC001E10_A498AppNotificationMetadata[0];
            n498AppNotificationMetadata = BC001E10_n498AppNotificationMetadata[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1E85( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound85 = 0;
         ScanKeyLoad1E85( ) ;
      }

      protected void ScanKeyLoad1E85( )
      {
         sMode85 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound85 = 1;
            A486AppNotificationId = BC001E10_A486AppNotificationId[0];
            A487AppNotificationTitle = BC001E10_A487AppNotificationTitle[0];
            A488AppNotificationDescription = BC001E10_A488AppNotificationDescription[0];
            A489AppNotificationDate = BC001E10_A489AppNotificationDate[0];
            A490AppNotificationTopic = BC001E10_A490AppNotificationTopic[0];
            A498AppNotificationMetadata = BC001E10_A498AppNotificationMetadata[0];
            n498AppNotificationMetadata = BC001E10_n498AppNotificationMetadata[0];
         }
         Gx_mode = sMode85;
      }

      protected void ScanKeyEnd1E85( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1E85( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1E85( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1E85( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1E85( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1E85( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1E85( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1E85( )
      {
      }

      protected void send_integrity_lvl_hashes1E85( )
      {
      }

      protected void AddRow1E85( )
      {
         VarsToRow85( bcTrn_AppNotification) ;
      }

      protected void ReadRow1E85( )
      {
         RowToVars85( bcTrn_AppNotification, 1) ;
      }

      protected void InitializeNonKey1E85( )
      {
         A487AppNotificationTitle = "";
         A488AppNotificationDescription = "";
         A489AppNotificationDate = (DateTime)(DateTime.MinValue);
         A490AppNotificationTopic = "";
         A498AppNotificationMetadata = "";
         n498AppNotificationMetadata = false;
         Z487AppNotificationTitle = "";
         Z488AppNotificationDescription = "";
         Z489AppNotificationDate = (DateTime)(DateTime.MinValue);
         Z490AppNotificationTopic = "";
      }

      protected void InitAll1E85( )
      {
         A486AppNotificationId = Guid.NewGuid( );
         InitializeNonKey1E85( ) ;
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

      public void VarsToRow85( SdtTrn_AppNotification obj85 )
      {
         obj85.gxTpr_Mode = Gx_mode;
         obj85.gxTpr_Appnotificationtitle = A487AppNotificationTitle;
         obj85.gxTpr_Appnotificationdescription = A488AppNotificationDescription;
         obj85.gxTpr_Appnotificationdate = A489AppNotificationDate;
         obj85.gxTpr_Appnotificationtopic = A490AppNotificationTopic;
         obj85.gxTpr_Appnotificationmetadata = A498AppNotificationMetadata;
         obj85.gxTpr_Appnotificationid = A486AppNotificationId;
         obj85.gxTpr_Appnotificationid_Z = Z486AppNotificationId;
         obj85.gxTpr_Appnotificationtitle_Z = Z487AppNotificationTitle;
         obj85.gxTpr_Appnotificationdescription_Z = Z488AppNotificationDescription;
         obj85.gxTpr_Appnotificationdate_Z = Z489AppNotificationDate;
         obj85.gxTpr_Appnotificationtopic_Z = Z490AppNotificationTopic;
         obj85.gxTpr_Appnotificationmetadata_N = (short)(Convert.ToInt16(n498AppNotificationMetadata));
         obj85.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow85( SdtTrn_AppNotification obj85 )
      {
         obj85.gxTpr_Appnotificationid = A486AppNotificationId;
         return  ;
      }

      public void RowToVars85( SdtTrn_AppNotification obj85 ,
                               int forceLoad )
      {
         Gx_mode = obj85.gxTpr_Mode;
         A487AppNotificationTitle = obj85.gxTpr_Appnotificationtitle;
         A488AppNotificationDescription = obj85.gxTpr_Appnotificationdescription;
         A489AppNotificationDate = obj85.gxTpr_Appnotificationdate;
         A490AppNotificationTopic = obj85.gxTpr_Appnotificationtopic;
         A498AppNotificationMetadata = obj85.gxTpr_Appnotificationmetadata;
         n498AppNotificationMetadata = false;
         A486AppNotificationId = obj85.gxTpr_Appnotificationid;
         Z486AppNotificationId = obj85.gxTpr_Appnotificationid_Z;
         Z487AppNotificationTitle = obj85.gxTpr_Appnotificationtitle_Z;
         Z488AppNotificationDescription = obj85.gxTpr_Appnotificationdescription_Z;
         Z489AppNotificationDate = obj85.gxTpr_Appnotificationdate_Z;
         Z490AppNotificationTopic = obj85.gxTpr_Appnotificationtopic_Z;
         n498AppNotificationMetadata = (bool)(Convert.ToBoolean(obj85.gxTpr_Appnotificationmetadata_N));
         Gx_mode = obj85.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A486AppNotificationId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1E85( ) ;
         ScanKeyStart1E85( ) ;
         if ( RcdFound85 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z486AppNotificationId = A486AppNotificationId;
         }
         ZM1E85( -3) ;
         OnLoadActions1E85( ) ;
         AddRow1E85( ) ;
         ScanKeyEnd1E85( ) ;
         if ( RcdFound85 == 0 )
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
         RowToVars85( bcTrn_AppNotification, 0) ;
         ScanKeyStart1E85( ) ;
         if ( RcdFound85 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z486AppNotificationId = A486AppNotificationId;
         }
         ZM1E85( -3) ;
         OnLoadActions1E85( ) ;
         AddRow1E85( ) ;
         ScanKeyEnd1E85( ) ;
         if ( RcdFound85 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1E85( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1E85( ) ;
         }
         else
         {
            if ( RcdFound85 == 1 )
            {
               if ( A486AppNotificationId != Z486AppNotificationId )
               {
                  A486AppNotificationId = Z486AppNotificationId;
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
                  Update1E85( ) ;
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
                  if ( A486AppNotificationId != Z486AppNotificationId )
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
                        Insert1E85( ) ;
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
                        Insert1E85( ) ;
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
         RowToVars85( bcTrn_AppNotification, 1) ;
         SaveImpl( ) ;
         VarsToRow85( bcTrn_AppNotification) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars85( bcTrn_AppNotification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1E85( ) ;
         AfterTrn( ) ;
         VarsToRow85( bcTrn_AppNotification) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow85( bcTrn_AppNotification) ;
         }
         else
         {
            SdtTrn_AppNotification auxBC = new SdtTrn_AppNotification(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A486AppNotificationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_AppNotification);
               auxBC.Save();
               bcTrn_AppNotification.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars85( bcTrn_AppNotification, 1) ;
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
         RowToVars85( bcTrn_AppNotification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1E85( ) ;
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
               VarsToRow85( bcTrn_AppNotification) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow85( bcTrn_AppNotification) ;
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
         RowToVars85( bcTrn_AppNotification, 0) ;
         GetKey1E85( ) ;
         if ( RcdFound85 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A486AppNotificationId != Z486AppNotificationId )
            {
               A486AppNotificationId = Z486AppNotificationId;
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
            if ( A486AppNotificationId != Z486AppNotificationId )
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
         context.RollbackDataStores("trn_appnotification_bc",pr_default);
         VarsToRow85( bcTrn_AppNotification) ;
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
         Gx_mode = bcTrn_AppNotification.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_AppNotification.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_AppNotification )
         {
            bcTrn_AppNotification = (SdtTrn_AppNotification)(sdt);
            if ( StringUtil.StrCmp(bcTrn_AppNotification.gxTpr_Mode, "") == 0 )
            {
               bcTrn_AppNotification.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow85( bcTrn_AppNotification) ;
            }
            else
            {
               RowToVars85( bcTrn_AppNotification, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_AppNotification.gxTpr_Mode, "") == 0 )
            {
               bcTrn_AppNotification.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars85( bcTrn_AppNotification, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_AppNotification Trn_AppNotification_BC
      {
         get {
            return bcTrn_AppNotification ;
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z486AppNotificationId = Guid.Empty;
         A486AppNotificationId = Guid.Empty;
         Z487AppNotificationTitle = "";
         A487AppNotificationTitle = "";
         Z488AppNotificationDescription = "";
         A488AppNotificationDescription = "";
         Z489AppNotificationDate = (DateTime)(DateTime.MinValue);
         A489AppNotificationDate = (DateTime)(DateTime.MinValue);
         Z490AppNotificationTopic = "";
         A490AppNotificationTopic = "";
         Z498AppNotificationMetadata = "";
         A498AppNotificationMetadata = "";
         BC001E4_A486AppNotificationId = new Guid[] {Guid.Empty} ;
         BC001E4_A487AppNotificationTitle = new string[] {""} ;
         BC001E4_A488AppNotificationDescription = new string[] {""} ;
         BC001E4_A489AppNotificationDate = new DateTime[] {DateTime.MinValue} ;
         BC001E4_A490AppNotificationTopic = new string[] {""} ;
         BC001E4_A498AppNotificationMetadata = new string[] {""} ;
         BC001E4_n498AppNotificationMetadata = new bool[] {false} ;
         BC001E5_A486AppNotificationId = new Guid[] {Guid.Empty} ;
         BC001E3_A486AppNotificationId = new Guid[] {Guid.Empty} ;
         BC001E3_A487AppNotificationTitle = new string[] {""} ;
         BC001E3_A488AppNotificationDescription = new string[] {""} ;
         BC001E3_A489AppNotificationDate = new DateTime[] {DateTime.MinValue} ;
         BC001E3_A490AppNotificationTopic = new string[] {""} ;
         BC001E3_A498AppNotificationMetadata = new string[] {""} ;
         BC001E3_n498AppNotificationMetadata = new bool[] {false} ;
         sMode85 = "";
         BC001E2_A486AppNotificationId = new Guid[] {Guid.Empty} ;
         BC001E2_A487AppNotificationTitle = new string[] {""} ;
         BC001E2_A488AppNotificationDescription = new string[] {""} ;
         BC001E2_A489AppNotificationDate = new DateTime[] {DateTime.MinValue} ;
         BC001E2_A490AppNotificationTopic = new string[] {""} ;
         BC001E2_A498AppNotificationMetadata = new string[] {""} ;
         BC001E2_n498AppNotificationMetadata = new bool[] {false} ;
         BC001E9_A485ResidentNotificationId = new Guid[] {Guid.Empty} ;
         BC001E10_A486AppNotificationId = new Guid[] {Guid.Empty} ;
         BC001E10_A487AppNotificationTitle = new string[] {""} ;
         BC001E10_A488AppNotificationDescription = new string[] {""} ;
         BC001E10_A489AppNotificationDate = new DateTime[] {DateTime.MinValue} ;
         BC001E10_A490AppNotificationTopic = new string[] {""} ;
         BC001E10_A498AppNotificationMetadata = new string[] {""} ;
         BC001E10_n498AppNotificationMetadata = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_appnotification_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_appnotification_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_appnotification_bc__default(),
            new Object[][] {
                new Object[] {
               BC001E2_A486AppNotificationId, BC001E2_A487AppNotificationTitle, BC001E2_A488AppNotificationDescription, BC001E2_A489AppNotificationDate, BC001E2_A490AppNotificationTopic, BC001E2_A498AppNotificationMetadata, BC001E2_n498AppNotificationMetadata
               }
               , new Object[] {
               BC001E3_A486AppNotificationId, BC001E3_A487AppNotificationTitle, BC001E3_A488AppNotificationDescription, BC001E3_A489AppNotificationDate, BC001E3_A490AppNotificationTopic, BC001E3_A498AppNotificationMetadata, BC001E3_n498AppNotificationMetadata
               }
               , new Object[] {
               BC001E4_A486AppNotificationId, BC001E4_A487AppNotificationTitle, BC001E4_A488AppNotificationDescription, BC001E4_A489AppNotificationDate, BC001E4_A490AppNotificationTopic, BC001E4_A498AppNotificationMetadata, BC001E4_n498AppNotificationMetadata
               }
               , new Object[] {
               BC001E5_A486AppNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001E9_A485ResidentNotificationId
               }
               , new Object[] {
               BC001E10_A486AppNotificationId, BC001E10_A487AppNotificationTitle, BC001E10_A488AppNotificationDescription, BC001E10_A489AppNotificationDate, BC001E10_A490AppNotificationTopic, BC001E10_A498AppNotificationMetadata, BC001E10_n498AppNotificationMetadata
               }
            }
         );
         Z486AppNotificationId = Guid.NewGuid( );
         A486AppNotificationId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound85 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode85 ;
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
      private Guid Z486AppNotificationId ;
      private Guid A486AppNotificationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001E4_A486AppNotificationId ;
      private string[] BC001E4_A487AppNotificationTitle ;
      private string[] BC001E4_A488AppNotificationDescription ;
      private DateTime[] BC001E4_A489AppNotificationDate ;
      private string[] BC001E4_A490AppNotificationTopic ;
      private string[] BC001E4_A498AppNotificationMetadata ;
      private bool[] BC001E4_n498AppNotificationMetadata ;
      private Guid[] BC001E5_A486AppNotificationId ;
      private Guid[] BC001E3_A486AppNotificationId ;
      private string[] BC001E3_A487AppNotificationTitle ;
      private string[] BC001E3_A488AppNotificationDescription ;
      private DateTime[] BC001E3_A489AppNotificationDate ;
      private string[] BC001E3_A490AppNotificationTopic ;
      private string[] BC001E3_A498AppNotificationMetadata ;
      private bool[] BC001E3_n498AppNotificationMetadata ;
      private Guid[] BC001E2_A486AppNotificationId ;
      private string[] BC001E2_A487AppNotificationTitle ;
      private string[] BC001E2_A488AppNotificationDescription ;
      private DateTime[] BC001E2_A489AppNotificationDate ;
      private string[] BC001E2_A490AppNotificationTopic ;
      private string[] BC001E2_A498AppNotificationMetadata ;
      private bool[] BC001E2_n498AppNotificationMetadata ;
      private Guid[] BC001E9_A485ResidentNotificationId ;
      private Guid[] BC001E10_A486AppNotificationId ;
      private string[] BC001E10_A487AppNotificationTitle ;
      private string[] BC001E10_A488AppNotificationDescription ;
      private DateTime[] BC001E10_A489AppNotificationDate ;
      private string[] BC001E10_A490AppNotificationTopic ;
      private string[] BC001E10_A498AppNotificationMetadata ;
      private bool[] BC001E10_n498AppNotificationMetadata ;
      private SdtTrn_AppNotification bcTrn_AppNotification ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_appnotification_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_appnotification_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_appnotification_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC001E2;
       prmBC001E2 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001E3;
       prmBC001E3 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001E4;
       prmBC001E4 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001E5;
       prmBC001E5 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001E6;
       prmBC001E6 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AppNotificationTitle",GXType.VarChar,100,0) ,
       new ParDef("AppNotificationDescription",GXType.VarChar,200,0) ,
       new ParDef("AppNotificationDate",GXType.DateTime,10,5) ,
       new ParDef("AppNotificationTopic",GXType.VarChar,100,0) ,
       new ParDef("AppNotificationMetadata",GXType.LongVarChar,2097152,0){Nullable=true}
       };
       Object[] prmBC001E7;
       prmBC001E7 = new Object[] {
       new ParDef("AppNotificationTitle",GXType.VarChar,100,0) ,
       new ParDef("AppNotificationDescription",GXType.VarChar,200,0) ,
       new ParDef("AppNotificationDate",GXType.DateTime,10,5) ,
       new ParDef("AppNotificationTopic",GXType.VarChar,100,0) ,
       new ParDef("AppNotificationMetadata",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001E8;
       prmBC001E8 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001E9;
       prmBC001E9 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001E10;
       prmBC001E10 = new Object[] {
       new ParDef("AppNotificationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001E2", "SELECT AppNotificationId, AppNotificationTitle, AppNotificationDescription, AppNotificationDate, AppNotificationTopic, AppNotificationMetadata FROM Trn_AppNotification WHERE AppNotificationId = :AppNotificationId  FOR UPDATE OF Trn_AppNotification",true, GxErrorMask.GX_NOMASK, false, this,prmBC001E2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001E3", "SELECT AppNotificationId, AppNotificationTitle, AppNotificationDescription, AppNotificationDate, AppNotificationTopic, AppNotificationMetadata FROM Trn_AppNotification WHERE AppNotificationId = :AppNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001E3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001E4", "SELECT TM1.AppNotificationId, TM1.AppNotificationTitle, TM1.AppNotificationDescription, TM1.AppNotificationDate, TM1.AppNotificationTopic, TM1.AppNotificationMetadata FROM Trn_AppNotification TM1 WHERE TM1.AppNotificationId = :AppNotificationId ORDER BY TM1.AppNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001E4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001E5", "SELECT AppNotificationId FROM Trn_AppNotification WHERE AppNotificationId = :AppNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001E5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001E6", "SAVEPOINT gxupdate;INSERT INTO Trn_AppNotification(AppNotificationId, AppNotificationTitle, AppNotificationDescription, AppNotificationDate, AppNotificationTopic, AppNotificationMetadata) VALUES(:AppNotificationId, :AppNotificationTitle, :AppNotificationDescription, :AppNotificationDate, :AppNotificationTopic, :AppNotificationMetadata);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001E6)
          ,new CursorDef("BC001E7", "SAVEPOINT gxupdate;UPDATE Trn_AppNotification SET AppNotificationTitle=:AppNotificationTitle, AppNotificationDescription=:AppNotificationDescription, AppNotificationDate=:AppNotificationDate, AppNotificationTopic=:AppNotificationTopic, AppNotificationMetadata=:AppNotificationMetadata  WHERE AppNotificationId = :AppNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001E7)
          ,new CursorDef("BC001E8", "SAVEPOINT gxupdate;DELETE FROM Trn_AppNotification  WHERE AppNotificationId = :AppNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001E8)
          ,new CursorDef("BC001E9", "SELECT ResidentNotificationId FROM Trn_ResidentNotification WHERE AppNotificationId = :AppNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001E9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC001E10", "SELECT TM1.AppNotificationId, TM1.AppNotificationTitle, TM1.AppNotificationDescription, TM1.AppNotificationDate, TM1.AppNotificationTopic, TM1.AppNotificationMetadata FROM Trn_AppNotification TM1 WHERE TM1.AppNotificationId = :AppNotificationId ORDER BY TM1.AppNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001E10,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((bool[]) buf[6])[0] = rslt.wasNull(6);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((bool[]) buf[6])[0] = rslt.wasNull(6);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((bool[]) buf[6])[0] = rslt.wasNull(6);
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
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((bool[]) buf[6])[0] = rslt.wasNull(6);
             return;
    }
 }

}

}
