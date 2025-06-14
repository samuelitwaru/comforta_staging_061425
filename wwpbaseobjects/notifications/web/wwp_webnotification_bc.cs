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
   public class wwp_webnotification_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_webnotification_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_webnotification_bc( IGxContext context )
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
         ReadRow0L31( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0L31( ) ;
         standaloneModal( ) ;
         AddRow0L31( ) ;
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
               Z152WWPWebNotificationId = A152WWPWebNotificationId;
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

      protected void CONFIRM_0L0( )
      {
         BeforeValidate0L31( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0L31( ) ;
            }
            else
            {
               CheckExtendedTable0L31( ) ;
               if ( AnyError == 0 )
               {
                  ZM0L31( 6) ;
                  ZM0L31( 7) ;
               }
               CloseExtendedTableCursors0L31( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0L31( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z147WWPWebNotificationTitle = A147WWPWebNotificationTitle;
            Z148WWPWebNotificationText = A148WWPWebNotificationText;
            Z149WWPWebNotificationIcon = A149WWPWebNotificationIcon;
            Z159WWPWebNotificationStatus = A159WWPWebNotificationStatus;
            Z150WWPWebNotificationCreated = A150WWPWebNotificationCreated;
            Z163WWPWebNotificationScheduled = A163WWPWebNotificationScheduled;
            Z160WWPWebNotificationProcessed = A160WWPWebNotificationProcessed;
            Z151WWPWebNotificationRead = A151WWPWebNotificationRead;
            Z162WWPWebNotificationReceived = A162WWPWebNotificationReceived;
            Z127WWPNotificationId = A127WWPNotificationId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z128WWPNotificationDefinitionId = A128WWPNotificationDefinitionId;
            Z129WWPNotificationCreated = A129WWPNotificationCreated;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z164WWPNotificationDefinitionName = A164WWPNotificationDefinitionName;
         }
         if ( GX_JID == -5 )
         {
            Z152WWPWebNotificationId = A152WWPWebNotificationId;
            Z147WWPWebNotificationTitle = A147WWPWebNotificationTitle;
            Z148WWPWebNotificationText = A148WWPWebNotificationText;
            Z149WWPWebNotificationIcon = A149WWPWebNotificationIcon;
            Z158WWPWebNotificationClientId = A158WWPWebNotificationClientId;
            Z159WWPWebNotificationStatus = A159WWPWebNotificationStatus;
            Z150WWPWebNotificationCreated = A150WWPWebNotificationCreated;
            Z163WWPWebNotificationScheduled = A163WWPWebNotificationScheduled;
            Z160WWPWebNotificationProcessed = A160WWPWebNotificationProcessed;
            Z151WWPWebNotificationRead = A151WWPWebNotificationRead;
            Z161WWPWebNotificationDetail = A161WWPWebNotificationDetail;
            Z162WWPWebNotificationReceived = A162WWPWebNotificationReceived;
            Z127WWPNotificationId = A127WWPNotificationId;
            Z128WWPNotificationDefinitionId = A128WWPNotificationDefinitionId;
            Z129WWPNotificationCreated = A129WWPNotificationCreated;
            Z165WWPNotificationMetadata = A165WWPNotificationMetadata;
            Z164WWPNotificationDefinitionName = A164WWPNotificationDefinitionName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A159WWPWebNotificationStatus) && ( Gx_BScreen == 0 ) )
         {
            A159WWPWebNotificationStatus = 1;
         }
         if ( IsIns( )  && (DateTime.MinValue==A150WWPWebNotificationCreated) && ( Gx_BScreen == 0 ) )
         {
            A150WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( IsIns( )  && (DateTime.MinValue==A163WWPWebNotificationScheduled) && ( Gx_BScreen == 0 ) )
         {
            A163WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0L31( )
      {
         /* Using cursor BC000L6 */
         pr_default.execute(4, new Object[] {A152WWPWebNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound31 = 1;
            A128WWPNotificationDefinitionId = BC000L6_A128WWPNotificationDefinitionId[0];
            A147WWPWebNotificationTitle = BC000L6_A147WWPWebNotificationTitle[0];
            A129WWPNotificationCreated = BC000L6_A129WWPNotificationCreated[0];
            A165WWPNotificationMetadata = BC000L6_A165WWPNotificationMetadata[0];
            n165WWPNotificationMetadata = BC000L6_n165WWPNotificationMetadata[0];
            A164WWPNotificationDefinitionName = BC000L6_A164WWPNotificationDefinitionName[0];
            A148WWPWebNotificationText = BC000L6_A148WWPWebNotificationText[0];
            A149WWPWebNotificationIcon = BC000L6_A149WWPWebNotificationIcon[0];
            A158WWPWebNotificationClientId = BC000L6_A158WWPWebNotificationClientId[0];
            A159WWPWebNotificationStatus = BC000L6_A159WWPWebNotificationStatus[0];
            A150WWPWebNotificationCreated = BC000L6_A150WWPWebNotificationCreated[0];
            A163WWPWebNotificationScheduled = BC000L6_A163WWPWebNotificationScheduled[0];
            A160WWPWebNotificationProcessed = BC000L6_A160WWPWebNotificationProcessed[0];
            A151WWPWebNotificationRead = BC000L6_A151WWPWebNotificationRead[0];
            n151WWPWebNotificationRead = BC000L6_n151WWPWebNotificationRead[0];
            A161WWPWebNotificationDetail = BC000L6_A161WWPWebNotificationDetail[0];
            n161WWPWebNotificationDetail = BC000L6_n161WWPWebNotificationDetail[0];
            A162WWPWebNotificationReceived = BC000L6_A162WWPWebNotificationReceived[0];
            n162WWPWebNotificationReceived = BC000L6_n162WWPWebNotificationReceived[0];
            A127WWPNotificationId = BC000L6_A127WWPNotificationId[0];
            n127WWPNotificationId = BC000L6_n127WWPNotificationId[0];
            ZM0L31( -5) ;
         }
         pr_default.close(4);
         OnLoadActions0L31( ) ;
      }

      protected void OnLoadActions0L31( )
      {
      }

      protected void CheckExtendedTable0L31( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000L4 */
         pr_default.execute(2, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A127WWPNotificationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Notification", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
            }
         }
         A128WWPNotificationDefinitionId = BC000L4_A128WWPNotificationDefinitionId[0];
         A129WWPNotificationCreated = BC000L4_A129WWPNotificationCreated[0];
         A165WWPNotificationMetadata = BC000L4_A165WWPNotificationMetadata[0];
         n165WWPNotificationMetadata = BC000L4_n165WWPNotificationMetadata[0];
         pr_default.close(2);
         /* Using cursor BC000L5 */
         pr_default.execute(3, new Object[] {A128WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A128WWPNotificationDefinitionId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
               AnyError = 1;
            }
         }
         A164WWPNotificationDefinitionName = BC000L5_A164WWPNotificationDefinitionName[0];
         pr_default.close(3);
         if ( ! ( ( A159WWPWebNotificationStatus == 1 ) || ( A159WWPWebNotificationStatus == 2 ) || ( A159WWPWebNotificationStatus == 3 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Web Notification Status", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0L31( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0L31( )
      {
         /* Using cursor BC000L7 */
         pr_default.execute(5, new Object[] {A152WWPWebNotificationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound31 = 1;
         }
         else
         {
            RcdFound31 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000L3 */
         pr_default.execute(1, new Object[] {A152WWPWebNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0L31( 5) ;
            RcdFound31 = 1;
            A152WWPWebNotificationId = BC000L3_A152WWPWebNotificationId[0];
            A147WWPWebNotificationTitle = BC000L3_A147WWPWebNotificationTitle[0];
            A148WWPWebNotificationText = BC000L3_A148WWPWebNotificationText[0];
            A149WWPWebNotificationIcon = BC000L3_A149WWPWebNotificationIcon[0];
            A158WWPWebNotificationClientId = BC000L3_A158WWPWebNotificationClientId[0];
            A159WWPWebNotificationStatus = BC000L3_A159WWPWebNotificationStatus[0];
            A150WWPWebNotificationCreated = BC000L3_A150WWPWebNotificationCreated[0];
            A163WWPWebNotificationScheduled = BC000L3_A163WWPWebNotificationScheduled[0];
            A160WWPWebNotificationProcessed = BC000L3_A160WWPWebNotificationProcessed[0];
            A151WWPWebNotificationRead = BC000L3_A151WWPWebNotificationRead[0];
            n151WWPWebNotificationRead = BC000L3_n151WWPWebNotificationRead[0];
            A161WWPWebNotificationDetail = BC000L3_A161WWPWebNotificationDetail[0];
            n161WWPWebNotificationDetail = BC000L3_n161WWPWebNotificationDetail[0];
            A162WWPWebNotificationReceived = BC000L3_A162WWPWebNotificationReceived[0];
            n162WWPWebNotificationReceived = BC000L3_n162WWPWebNotificationReceived[0];
            A127WWPNotificationId = BC000L3_A127WWPNotificationId[0];
            n127WWPNotificationId = BC000L3_n127WWPNotificationId[0];
            Z152WWPWebNotificationId = A152WWPWebNotificationId;
            sMode31 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0L31( ) ;
            if ( AnyError == 1 )
            {
               RcdFound31 = 0;
               InitializeNonKey0L31( ) ;
            }
            Gx_mode = sMode31;
         }
         else
         {
            RcdFound31 = 0;
            InitializeNonKey0L31( ) ;
            sMode31 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode31;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0L31( ) ;
         if ( RcdFound31 == 0 )
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
         CONFIRM_0L0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0L31( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000L2 */
            pr_default.execute(0, new Object[] {A152WWPWebNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebNotification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z147WWPWebNotificationTitle, BC000L2_A147WWPWebNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z148WWPWebNotificationText, BC000L2_A148WWPWebNotificationText[0]) != 0 ) || ( StringUtil.StrCmp(Z149WWPWebNotificationIcon, BC000L2_A149WWPWebNotificationIcon[0]) != 0 ) || ( Z159WWPWebNotificationStatus != BC000L2_A159WWPWebNotificationStatus[0] ) || ( Z150WWPWebNotificationCreated != BC000L2_A150WWPWebNotificationCreated[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z163WWPWebNotificationScheduled != BC000L2_A163WWPWebNotificationScheduled[0] ) || ( Z160WWPWebNotificationProcessed != BC000L2_A160WWPWebNotificationProcessed[0] ) || ( Z151WWPWebNotificationRead != BC000L2_A151WWPWebNotificationRead[0] ) || ( Z162WWPWebNotificationReceived != BC000L2_A162WWPWebNotificationReceived[0] ) || ( Z127WWPNotificationId != BC000L2_A127WWPNotificationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_WebNotification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0L31( )
      {
         BeforeValidate0L31( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L31( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0L31( 0) ;
            CheckOptimisticConcurrency0L31( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L31( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0L31( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000L8 */
                     pr_default.execute(6, new Object[] {A147WWPWebNotificationTitle, A148WWPWebNotificationText, A149WWPWebNotificationIcon, A158WWPWebNotificationClientId, A159WWPWebNotificationStatus, A150WWPWebNotificationCreated, A163WWPWebNotificationScheduled, A160WWPWebNotificationProcessed, n151WWPWebNotificationRead, A151WWPWebNotificationRead, n161WWPWebNotificationDetail, A161WWPWebNotificationDetail, n162WWPWebNotificationReceived, A162WWPWebNotificationReceived, n127WWPNotificationId, A127WWPNotificationId});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000L9 */
                     pr_default.execute(7);
                     A152WWPWebNotificationId = BC000L9_A152WWPWebNotificationId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
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
               Load0L31( ) ;
            }
            EndLevel0L31( ) ;
         }
         CloseExtendedTableCursors0L31( ) ;
      }

      protected void Update0L31( )
      {
         BeforeValidate0L31( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L31( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L31( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L31( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0L31( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000L10 */
                     pr_default.execute(8, new Object[] {A147WWPWebNotificationTitle, A148WWPWebNotificationText, A149WWPWebNotificationIcon, A158WWPWebNotificationClientId, A159WWPWebNotificationStatus, A150WWPWebNotificationCreated, A163WWPWebNotificationScheduled, A160WWPWebNotificationProcessed, n151WWPWebNotificationRead, A151WWPWebNotificationRead, n161WWPWebNotificationDetail, A161WWPWebNotificationDetail, n162WWPWebNotificationReceived, A162WWPWebNotificationReceived, n127WWPNotificationId, A127WWPNotificationId, A152WWPWebNotificationId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebNotification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0L31( ) ;
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
            EndLevel0L31( ) ;
         }
         CloseExtendedTableCursors0L31( ) ;
      }

      protected void DeferredUpdate0L31( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0L31( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L31( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0L31( ) ;
            AfterConfirm0L31( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0L31( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000L11 */
                  pr_default.execute(9, new Object[] {A152WWPWebNotificationId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
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
         sMode31 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0L31( ) ;
         Gx_mode = sMode31;
      }

      protected void OnDeleteControls0L31( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000L12 */
            pr_default.execute(10, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
            A128WWPNotificationDefinitionId = BC000L12_A128WWPNotificationDefinitionId[0];
            A129WWPNotificationCreated = BC000L12_A129WWPNotificationCreated[0];
            A165WWPNotificationMetadata = BC000L12_A165WWPNotificationMetadata[0];
            n165WWPNotificationMetadata = BC000L12_n165WWPNotificationMetadata[0];
            pr_default.close(10);
            /* Using cursor BC000L13 */
            pr_default.execute(11, new Object[] {A128WWPNotificationDefinitionId});
            A164WWPNotificationDefinitionName = BC000L13_A164WWPNotificationDefinitionName[0];
            pr_default.close(11);
         }
      }

      protected void EndLevel0L31( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0L31( ) ;
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

      public void ScanKeyStart0L31( )
      {
         /* Using cursor BC000L14 */
         pr_default.execute(12, new Object[] {A152WWPWebNotificationId});
         RcdFound31 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound31 = 1;
            A128WWPNotificationDefinitionId = BC000L14_A128WWPNotificationDefinitionId[0];
            A152WWPWebNotificationId = BC000L14_A152WWPWebNotificationId[0];
            A147WWPWebNotificationTitle = BC000L14_A147WWPWebNotificationTitle[0];
            A129WWPNotificationCreated = BC000L14_A129WWPNotificationCreated[0];
            A165WWPNotificationMetadata = BC000L14_A165WWPNotificationMetadata[0];
            n165WWPNotificationMetadata = BC000L14_n165WWPNotificationMetadata[0];
            A164WWPNotificationDefinitionName = BC000L14_A164WWPNotificationDefinitionName[0];
            A148WWPWebNotificationText = BC000L14_A148WWPWebNotificationText[0];
            A149WWPWebNotificationIcon = BC000L14_A149WWPWebNotificationIcon[0];
            A158WWPWebNotificationClientId = BC000L14_A158WWPWebNotificationClientId[0];
            A159WWPWebNotificationStatus = BC000L14_A159WWPWebNotificationStatus[0];
            A150WWPWebNotificationCreated = BC000L14_A150WWPWebNotificationCreated[0];
            A163WWPWebNotificationScheduled = BC000L14_A163WWPWebNotificationScheduled[0];
            A160WWPWebNotificationProcessed = BC000L14_A160WWPWebNotificationProcessed[0];
            A151WWPWebNotificationRead = BC000L14_A151WWPWebNotificationRead[0];
            n151WWPWebNotificationRead = BC000L14_n151WWPWebNotificationRead[0];
            A161WWPWebNotificationDetail = BC000L14_A161WWPWebNotificationDetail[0];
            n161WWPWebNotificationDetail = BC000L14_n161WWPWebNotificationDetail[0];
            A162WWPWebNotificationReceived = BC000L14_A162WWPWebNotificationReceived[0];
            n162WWPWebNotificationReceived = BC000L14_n162WWPWebNotificationReceived[0];
            A127WWPNotificationId = BC000L14_A127WWPNotificationId[0];
            n127WWPNotificationId = BC000L14_n127WWPNotificationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0L31( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound31 = 0;
         ScanKeyLoad0L31( ) ;
      }

      protected void ScanKeyLoad0L31( )
      {
         sMode31 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound31 = 1;
            A128WWPNotificationDefinitionId = BC000L14_A128WWPNotificationDefinitionId[0];
            A152WWPWebNotificationId = BC000L14_A152WWPWebNotificationId[0];
            A147WWPWebNotificationTitle = BC000L14_A147WWPWebNotificationTitle[0];
            A129WWPNotificationCreated = BC000L14_A129WWPNotificationCreated[0];
            A165WWPNotificationMetadata = BC000L14_A165WWPNotificationMetadata[0];
            n165WWPNotificationMetadata = BC000L14_n165WWPNotificationMetadata[0];
            A164WWPNotificationDefinitionName = BC000L14_A164WWPNotificationDefinitionName[0];
            A148WWPWebNotificationText = BC000L14_A148WWPWebNotificationText[0];
            A149WWPWebNotificationIcon = BC000L14_A149WWPWebNotificationIcon[0];
            A158WWPWebNotificationClientId = BC000L14_A158WWPWebNotificationClientId[0];
            A159WWPWebNotificationStatus = BC000L14_A159WWPWebNotificationStatus[0];
            A150WWPWebNotificationCreated = BC000L14_A150WWPWebNotificationCreated[0];
            A163WWPWebNotificationScheduled = BC000L14_A163WWPWebNotificationScheduled[0];
            A160WWPWebNotificationProcessed = BC000L14_A160WWPWebNotificationProcessed[0];
            A151WWPWebNotificationRead = BC000L14_A151WWPWebNotificationRead[0];
            n151WWPWebNotificationRead = BC000L14_n151WWPWebNotificationRead[0];
            A161WWPWebNotificationDetail = BC000L14_A161WWPWebNotificationDetail[0];
            n161WWPWebNotificationDetail = BC000L14_n161WWPWebNotificationDetail[0];
            A162WWPWebNotificationReceived = BC000L14_A162WWPWebNotificationReceived[0];
            n162WWPWebNotificationReceived = BC000L14_n162WWPWebNotificationReceived[0];
            A127WWPNotificationId = BC000L14_A127WWPNotificationId[0];
            n127WWPNotificationId = BC000L14_n127WWPNotificationId[0];
         }
         Gx_mode = sMode31;
      }

      protected void ScanKeyEnd0L31( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0L31( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0L31( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0L31( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0L31( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0L31( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0L31( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0L31( )
      {
      }

      protected void send_integrity_lvl_hashes0L31( )
      {
      }

      protected void AddRow0L31( )
      {
         VarsToRow31( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
      }

      protected void ReadRow0L31( )
      {
         RowToVars31( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
      }

      protected void InitializeNonKey0L31( )
      {
         A128WWPNotificationDefinitionId = 0;
         A147WWPWebNotificationTitle = "";
         A127WWPNotificationId = 0;
         n127WWPNotificationId = false;
         A129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A165WWPNotificationMetadata = "";
         n165WWPNotificationMetadata = false;
         A164WWPNotificationDefinitionName = "";
         A148WWPWebNotificationText = "";
         A149WWPWebNotificationIcon = "";
         A158WWPWebNotificationClientId = "";
         A160WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         A151WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         n151WWPWebNotificationRead = false;
         A161WWPWebNotificationDetail = "";
         n161WWPWebNotificationDetail = false;
         A162WWPWebNotificationReceived = false;
         n162WWPWebNotificationReceived = false;
         A159WWPWebNotificationStatus = 1;
         A150WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A163WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z147WWPWebNotificationTitle = "";
         Z148WWPWebNotificationText = "";
         Z149WWPWebNotificationIcon = "";
         Z159WWPWebNotificationStatus = 0;
         Z150WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         Z163WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         Z160WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         Z151WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         Z162WWPWebNotificationReceived = false;
         Z127WWPNotificationId = 0;
      }

      protected void InitAll0L31( )
      {
         A152WWPWebNotificationId = 0;
         InitializeNonKey0L31( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A159WWPWebNotificationStatus = i159WWPWebNotificationStatus;
         A150WWPWebNotificationCreated = i150WWPWebNotificationCreated;
         A163WWPWebNotificationScheduled = i163WWPWebNotificationScheduled;
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

      public void VarsToRow31( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification obj31 )
      {
         obj31.gxTpr_Mode = Gx_mode;
         obj31.gxTpr_Wwpwebnotificationtitle = A147WWPWebNotificationTitle;
         obj31.gxTpr_Wwpnotificationid = A127WWPNotificationId;
         obj31.gxTpr_Wwpnotificationcreated = A129WWPNotificationCreated;
         obj31.gxTpr_Wwpnotificationmetadata = A165WWPNotificationMetadata;
         obj31.gxTpr_Wwpnotificationdefinitionname = A164WWPNotificationDefinitionName;
         obj31.gxTpr_Wwpwebnotificationtext = A148WWPWebNotificationText;
         obj31.gxTpr_Wwpwebnotificationicon = A149WWPWebNotificationIcon;
         obj31.gxTpr_Wwpwebnotificationclientid = A158WWPWebNotificationClientId;
         obj31.gxTpr_Wwpwebnotificationprocessed = A160WWPWebNotificationProcessed;
         obj31.gxTpr_Wwpwebnotificationread = A151WWPWebNotificationRead;
         obj31.gxTpr_Wwpwebnotificationdetail = A161WWPWebNotificationDetail;
         obj31.gxTpr_Wwpwebnotificationreceived = A162WWPWebNotificationReceived;
         obj31.gxTpr_Wwpwebnotificationstatus = A159WWPWebNotificationStatus;
         obj31.gxTpr_Wwpwebnotificationcreated = A150WWPWebNotificationCreated;
         obj31.gxTpr_Wwpwebnotificationscheduled = A163WWPWebNotificationScheduled;
         obj31.gxTpr_Wwpwebnotificationid = A152WWPWebNotificationId;
         obj31.gxTpr_Wwpwebnotificationid_Z = Z152WWPWebNotificationId;
         obj31.gxTpr_Wwpwebnotificationtitle_Z = Z147WWPWebNotificationTitle;
         obj31.gxTpr_Wwpnotificationid_Z = Z127WWPNotificationId;
         obj31.gxTpr_Wwpnotificationcreated_Z = Z129WWPNotificationCreated;
         obj31.gxTpr_Wwpnotificationdefinitionname_Z = Z164WWPNotificationDefinitionName;
         obj31.gxTpr_Wwpwebnotificationtext_Z = Z148WWPWebNotificationText;
         obj31.gxTpr_Wwpwebnotificationicon_Z = Z149WWPWebNotificationIcon;
         obj31.gxTpr_Wwpwebnotificationstatus_Z = Z159WWPWebNotificationStatus;
         obj31.gxTpr_Wwpwebnotificationcreated_Z = Z150WWPWebNotificationCreated;
         obj31.gxTpr_Wwpwebnotificationscheduled_Z = Z163WWPWebNotificationScheduled;
         obj31.gxTpr_Wwpwebnotificationprocessed_Z = Z160WWPWebNotificationProcessed;
         obj31.gxTpr_Wwpwebnotificationread_Z = Z151WWPWebNotificationRead;
         obj31.gxTpr_Wwpwebnotificationreceived_Z = Z162WWPWebNotificationReceived;
         obj31.gxTpr_Wwpnotificationid_N = (short)(Convert.ToInt16(n127WWPNotificationId));
         obj31.gxTpr_Wwpnotificationmetadata_N = (short)(Convert.ToInt16(n165WWPNotificationMetadata));
         obj31.gxTpr_Wwpwebnotificationread_N = (short)(Convert.ToInt16(n151WWPWebNotificationRead));
         obj31.gxTpr_Wwpwebnotificationdetail_N = (short)(Convert.ToInt16(n161WWPWebNotificationDetail));
         obj31.gxTpr_Wwpwebnotificationreceived_N = (short)(Convert.ToInt16(n162WWPWebNotificationReceived));
         obj31.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow31( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification obj31 )
      {
         obj31.gxTpr_Wwpwebnotificationid = A152WWPWebNotificationId;
         return  ;
      }

      public void RowToVars31( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification obj31 ,
                               int forceLoad )
      {
         Gx_mode = obj31.gxTpr_Mode;
         A147WWPWebNotificationTitle = obj31.gxTpr_Wwpwebnotificationtitle;
         A127WWPNotificationId = obj31.gxTpr_Wwpnotificationid;
         n127WWPNotificationId = false;
         A129WWPNotificationCreated = obj31.gxTpr_Wwpnotificationcreated;
         A165WWPNotificationMetadata = obj31.gxTpr_Wwpnotificationmetadata;
         n165WWPNotificationMetadata = false;
         A164WWPNotificationDefinitionName = obj31.gxTpr_Wwpnotificationdefinitionname;
         A148WWPWebNotificationText = obj31.gxTpr_Wwpwebnotificationtext;
         A149WWPWebNotificationIcon = obj31.gxTpr_Wwpwebnotificationicon;
         A158WWPWebNotificationClientId = obj31.gxTpr_Wwpwebnotificationclientid;
         A160WWPWebNotificationProcessed = obj31.gxTpr_Wwpwebnotificationprocessed;
         A151WWPWebNotificationRead = obj31.gxTpr_Wwpwebnotificationread;
         n151WWPWebNotificationRead = false;
         A161WWPWebNotificationDetail = obj31.gxTpr_Wwpwebnotificationdetail;
         n161WWPWebNotificationDetail = false;
         A162WWPWebNotificationReceived = obj31.gxTpr_Wwpwebnotificationreceived;
         n162WWPWebNotificationReceived = false;
         A159WWPWebNotificationStatus = obj31.gxTpr_Wwpwebnotificationstatus;
         A150WWPWebNotificationCreated = obj31.gxTpr_Wwpwebnotificationcreated;
         A163WWPWebNotificationScheduled = obj31.gxTpr_Wwpwebnotificationscheduled;
         A152WWPWebNotificationId = obj31.gxTpr_Wwpwebnotificationid;
         Z152WWPWebNotificationId = obj31.gxTpr_Wwpwebnotificationid_Z;
         Z147WWPWebNotificationTitle = obj31.gxTpr_Wwpwebnotificationtitle_Z;
         Z127WWPNotificationId = obj31.gxTpr_Wwpnotificationid_Z;
         Z129WWPNotificationCreated = obj31.gxTpr_Wwpnotificationcreated_Z;
         Z164WWPNotificationDefinitionName = obj31.gxTpr_Wwpnotificationdefinitionname_Z;
         Z148WWPWebNotificationText = obj31.gxTpr_Wwpwebnotificationtext_Z;
         Z149WWPWebNotificationIcon = obj31.gxTpr_Wwpwebnotificationicon_Z;
         Z159WWPWebNotificationStatus = obj31.gxTpr_Wwpwebnotificationstatus_Z;
         Z150WWPWebNotificationCreated = obj31.gxTpr_Wwpwebnotificationcreated_Z;
         Z163WWPWebNotificationScheduled = obj31.gxTpr_Wwpwebnotificationscheduled_Z;
         Z160WWPWebNotificationProcessed = obj31.gxTpr_Wwpwebnotificationprocessed_Z;
         Z151WWPWebNotificationRead = obj31.gxTpr_Wwpwebnotificationread_Z;
         Z162WWPWebNotificationReceived = obj31.gxTpr_Wwpwebnotificationreceived_Z;
         n127WWPNotificationId = (bool)(Convert.ToBoolean(obj31.gxTpr_Wwpnotificationid_N));
         n165WWPNotificationMetadata = (bool)(Convert.ToBoolean(obj31.gxTpr_Wwpnotificationmetadata_N));
         n151WWPWebNotificationRead = (bool)(Convert.ToBoolean(obj31.gxTpr_Wwpwebnotificationread_N));
         n161WWPWebNotificationDetail = (bool)(Convert.ToBoolean(obj31.gxTpr_Wwpwebnotificationdetail_N));
         n162WWPWebNotificationReceived = (bool)(Convert.ToBoolean(obj31.gxTpr_Wwpwebnotificationreceived_N));
         Gx_mode = obj31.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A152WWPWebNotificationId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0L31( ) ;
         ScanKeyStart0L31( ) ;
         if ( RcdFound31 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z152WWPWebNotificationId = A152WWPWebNotificationId;
         }
         ZM0L31( -5) ;
         OnLoadActions0L31( ) ;
         AddRow0L31( ) ;
         ScanKeyEnd0L31( ) ;
         if ( RcdFound31 == 0 )
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
         RowToVars31( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 0) ;
         ScanKeyStart0L31( ) ;
         if ( RcdFound31 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z152WWPWebNotificationId = A152WWPWebNotificationId;
         }
         ZM0L31( -5) ;
         OnLoadActions0L31( ) ;
         AddRow0L31( ) ;
         ScanKeyEnd0L31( ) ;
         if ( RcdFound31 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0L31( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0L31( ) ;
         }
         else
         {
            if ( RcdFound31 == 1 )
            {
               if ( A152WWPWebNotificationId != Z152WWPWebNotificationId )
               {
                  A152WWPWebNotificationId = Z152WWPWebNotificationId;
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
                  Update0L31( ) ;
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
                  if ( A152WWPWebNotificationId != Z152WWPWebNotificationId )
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
                        Insert0L31( ) ;
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
                        Insert0L31( ) ;
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
         RowToVars31( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
         SaveImpl( ) ;
         VarsToRow31( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars31( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0L31( ) ;
         AfterTrn( ) ;
         VarsToRow31( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow31( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification auxBC = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A152WWPWebNotificationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_notifications_web_WWP_WebNotification);
               auxBC.Save();
               bcwwpbaseobjects_notifications_web_WWP_WebNotification.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars31( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
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
         RowToVars31( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0L31( ) ;
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
               VarsToRow31( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow31( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
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
         RowToVars31( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 0) ;
         GetKey0L31( ) ;
         if ( RcdFound31 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A152WWPWebNotificationId != Z152WWPWebNotificationId )
            {
               A152WWPWebNotificationId = Z152WWPWebNotificationId;
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
            if ( A152WWPWebNotificationId != Z152WWPWebNotificationId )
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
         context.RollbackDataStores("wwpbaseobjects.notifications.web.wwp_webnotification_bc",pr_default);
         VarsToRow31( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
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
         Gx_mode = bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_notifications_web_WWP_WebNotification )
         {
            bcwwpbaseobjects_notifications_web_WWP_WebNotification = (GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow31( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
            }
            else
            {
               RowToVars31( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars31( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_WebNotification WWP_WebNotification_BC
      {
         get {
            return bcwwpbaseobjects_notifications_web_WWP_WebNotification ;
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
            return "webnotification_Execute" ;
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
         pr_default.close(10);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z147WWPWebNotificationTitle = "";
         A147WWPWebNotificationTitle = "";
         Z148WWPWebNotificationText = "";
         A148WWPWebNotificationText = "";
         Z149WWPWebNotificationIcon = "";
         A149WWPWebNotificationIcon = "";
         Z150WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         A150WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         Z163WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         A163WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         Z160WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         A160WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         Z151WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         A151WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         Z129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z164WWPNotificationDefinitionName = "";
         A164WWPNotificationDefinitionName = "";
         Z158WWPWebNotificationClientId = "";
         A158WWPWebNotificationClientId = "";
         Z161WWPWebNotificationDetail = "";
         A161WWPWebNotificationDetail = "";
         Z165WWPNotificationMetadata = "";
         A165WWPNotificationMetadata = "";
         BC000L6_A128WWPNotificationDefinitionId = new long[1] ;
         BC000L6_A152WWPWebNotificationId = new long[1] ;
         BC000L6_A147WWPWebNotificationTitle = new string[] {""} ;
         BC000L6_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000L6_A165WWPNotificationMetadata = new string[] {""} ;
         BC000L6_n165WWPNotificationMetadata = new bool[] {false} ;
         BC000L6_A164WWPNotificationDefinitionName = new string[] {""} ;
         BC000L6_A148WWPWebNotificationText = new string[] {""} ;
         BC000L6_A149WWPWebNotificationIcon = new string[] {""} ;
         BC000L6_A158WWPWebNotificationClientId = new string[] {""} ;
         BC000L6_A159WWPWebNotificationStatus = new short[1] ;
         BC000L6_A150WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000L6_A163WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000L6_A160WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000L6_A151WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         BC000L6_n151WWPWebNotificationRead = new bool[] {false} ;
         BC000L6_A161WWPWebNotificationDetail = new string[] {""} ;
         BC000L6_n161WWPWebNotificationDetail = new bool[] {false} ;
         BC000L6_A162WWPWebNotificationReceived = new bool[] {false} ;
         BC000L6_n162WWPWebNotificationReceived = new bool[] {false} ;
         BC000L6_A127WWPNotificationId = new long[1] ;
         BC000L6_n127WWPNotificationId = new bool[] {false} ;
         BC000L4_A128WWPNotificationDefinitionId = new long[1] ;
         BC000L4_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000L4_A165WWPNotificationMetadata = new string[] {""} ;
         BC000L4_n165WWPNotificationMetadata = new bool[] {false} ;
         BC000L5_A164WWPNotificationDefinitionName = new string[] {""} ;
         BC000L7_A152WWPWebNotificationId = new long[1] ;
         BC000L3_A152WWPWebNotificationId = new long[1] ;
         BC000L3_A147WWPWebNotificationTitle = new string[] {""} ;
         BC000L3_A148WWPWebNotificationText = new string[] {""} ;
         BC000L3_A149WWPWebNotificationIcon = new string[] {""} ;
         BC000L3_A158WWPWebNotificationClientId = new string[] {""} ;
         BC000L3_A159WWPWebNotificationStatus = new short[1] ;
         BC000L3_A150WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000L3_A163WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000L3_A160WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000L3_A151WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         BC000L3_n151WWPWebNotificationRead = new bool[] {false} ;
         BC000L3_A161WWPWebNotificationDetail = new string[] {""} ;
         BC000L3_n161WWPWebNotificationDetail = new bool[] {false} ;
         BC000L3_A162WWPWebNotificationReceived = new bool[] {false} ;
         BC000L3_n162WWPWebNotificationReceived = new bool[] {false} ;
         BC000L3_A127WWPNotificationId = new long[1] ;
         BC000L3_n127WWPNotificationId = new bool[] {false} ;
         sMode31 = "";
         BC000L2_A152WWPWebNotificationId = new long[1] ;
         BC000L2_A147WWPWebNotificationTitle = new string[] {""} ;
         BC000L2_A148WWPWebNotificationText = new string[] {""} ;
         BC000L2_A149WWPWebNotificationIcon = new string[] {""} ;
         BC000L2_A158WWPWebNotificationClientId = new string[] {""} ;
         BC000L2_A159WWPWebNotificationStatus = new short[1] ;
         BC000L2_A150WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000L2_A163WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000L2_A160WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000L2_A151WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         BC000L2_n151WWPWebNotificationRead = new bool[] {false} ;
         BC000L2_A161WWPWebNotificationDetail = new string[] {""} ;
         BC000L2_n161WWPWebNotificationDetail = new bool[] {false} ;
         BC000L2_A162WWPWebNotificationReceived = new bool[] {false} ;
         BC000L2_n162WWPWebNotificationReceived = new bool[] {false} ;
         BC000L2_A127WWPNotificationId = new long[1] ;
         BC000L2_n127WWPNotificationId = new bool[] {false} ;
         BC000L9_A152WWPWebNotificationId = new long[1] ;
         BC000L12_A128WWPNotificationDefinitionId = new long[1] ;
         BC000L12_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000L12_A165WWPNotificationMetadata = new string[] {""} ;
         BC000L12_n165WWPNotificationMetadata = new bool[] {false} ;
         BC000L13_A164WWPNotificationDefinitionName = new string[] {""} ;
         BC000L14_A128WWPNotificationDefinitionId = new long[1] ;
         BC000L14_A152WWPWebNotificationId = new long[1] ;
         BC000L14_A147WWPWebNotificationTitle = new string[] {""} ;
         BC000L14_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000L14_A165WWPNotificationMetadata = new string[] {""} ;
         BC000L14_n165WWPNotificationMetadata = new bool[] {false} ;
         BC000L14_A164WWPNotificationDefinitionName = new string[] {""} ;
         BC000L14_A148WWPWebNotificationText = new string[] {""} ;
         BC000L14_A149WWPWebNotificationIcon = new string[] {""} ;
         BC000L14_A158WWPWebNotificationClientId = new string[] {""} ;
         BC000L14_A159WWPWebNotificationStatus = new short[1] ;
         BC000L14_A150WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000L14_A163WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000L14_A160WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000L14_A151WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         BC000L14_n151WWPWebNotificationRead = new bool[] {false} ;
         BC000L14_A161WWPWebNotificationDetail = new string[] {""} ;
         BC000L14_n161WWPWebNotificationDetail = new bool[] {false} ;
         BC000L14_A162WWPWebNotificationReceived = new bool[] {false} ;
         BC000L14_n162WWPWebNotificationReceived = new bool[] {false} ;
         BC000L14_A127WWPNotificationId = new long[1] ;
         BC000L14_n127WWPNotificationId = new bool[] {false} ;
         i150WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         i163WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification_bc__default(),
            new Object[][] {
                new Object[] {
               BC000L2_A152WWPWebNotificationId, BC000L2_A147WWPWebNotificationTitle, BC000L2_A148WWPWebNotificationText, BC000L2_A149WWPWebNotificationIcon, BC000L2_A158WWPWebNotificationClientId, BC000L2_A159WWPWebNotificationStatus, BC000L2_A150WWPWebNotificationCreated, BC000L2_A163WWPWebNotificationScheduled, BC000L2_A160WWPWebNotificationProcessed, BC000L2_A151WWPWebNotificationRead,
               BC000L2_n151WWPWebNotificationRead, BC000L2_A161WWPWebNotificationDetail, BC000L2_n161WWPWebNotificationDetail, BC000L2_A162WWPWebNotificationReceived, BC000L2_n162WWPWebNotificationReceived, BC000L2_A127WWPNotificationId, BC000L2_n127WWPNotificationId
               }
               , new Object[] {
               BC000L3_A152WWPWebNotificationId, BC000L3_A147WWPWebNotificationTitle, BC000L3_A148WWPWebNotificationText, BC000L3_A149WWPWebNotificationIcon, BC000L3_A158WWPWebNotificationClientId, BC000L3_A159WWPWebNotificationStatus, BC000L3_A150WWPWebNotificationCreated, BC000L3_A163WWPWebNotificationScheduled, BC000L3_A160WWPWebNotificationProcessed, BC000L3_A151WWPWebNotificationRead,
               BC000L3_n151WWPWebNotificationRead, BC000L3_A161WWPWebNotificationDetail, BC000L3_n161WWPWebNotificationDetail, BC000L3_A162WWPWebNotificationReceived, BC000L3_n162WWPWebNotificationReceived, BC000L3_A127WWPNotificationId, BC000L3_n127WWPNotificationId
               }
               , new Object[] {
               BC000L4_A128WWPNotificationDefinitionId, BC000L4_A129WWPNotificationCreated, BC000L4_A165WWPNotificationMetadata, BC000L4_n165WWPNotificationMetadata
               }
               , new Object[] {
               BC000L5_A164WWPNotificationDefinitionName
               }
               , new Object[] {
               BC000L6_A128WWPNotificationDefinitionId, BC000L6_A152WWPWebNotificationId, BC000L6_A147WWPWebNotificationTitle, BC000L6_A129WWPNotificationCreated, BC000L6_A165WWPNotificationMetadata, BC000L6_n165WWPNotificationMetadata, BC000L6_A164WWPNotificationDefinitionName, BC000L6_A148WWPWebNotificationText, BC000L6_A149WWPWebNotificationIcon, BC000L6_A158WWPWebNotificationClientId,
               BC000L6_A159WWPWebNotificationStatus, BC000L6_A150WWPWebNotificationCreated, BC000L6_A163WWPWebNotificationScheduled, BC000L6_A160WWPWebNotificationProcessed, BC000L6_A151WWPWebNotificationRead, BC000L6_n151WWPWebNotificationRead, BC000L6_A161WWPWebNotificationDetail, BC000L6_n161WWPWebNotificationDetail, BC000L6_A162WWPWebNotificationReceived, BC000L6_n162WWPWebNotificationReceived,
               BC000L6_A127WWPNotificationId, BC000L6_n127WWPNotificationId
               }
               , new Object[] {
               BC000L7_A152WWPWebNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000L9_A152WWPWebNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000L12_A128WWPNotificationDefinitionId, BC000L12_A129WWPNotificationCreated, BC000L12_A165WWPNotificationMetadata, BC000L12_n165WWPNotificationMetadata
               }
               , new Object[] {
               BC000L13_A164WWPNotificationDefinitionName
               }
               , new Object[] {
               BC000L14_A128WWPNotificationDefinitionId, BC000L14_A152WWPWebNotificationId, BC000L14_A147WWPWebNotificationTitle, BC000L14_A129WWPNotificationCreated, BC000L14_A165WWPNotificationMetadata, BC000L14_n165WWPNotificationMetadata, BC000L14_A164WWPNotificationDefinitionName, BC000L14_A148WWPWebNotificationText, BC000L14_A149WWPWebNotificationIcon, BC000L14_A158WWPWebNotificationClientId,
               BC000L14_A159WWPWebNotificationStatus, BC000L14_A150WWPWebNotificationCreated, BC000L14_A163WWPWebNotificationScheduled, BC000L14_A160WWPWebNotificationProcessed, BC000L14_A151WWPWebNotificationRead, BC000L14_n151WWPWebNotificationRead, BC000L14_A161WWPWebNotificationDetail, BC000L14_n161WWPWebNotificationDetail, BC000L14_A162WWPWebNotificationReceived, BC000L14_n162WWPWebNotificationReceived,
               BC000L14_A127WWPNotificationId, BC000L14_n127WWPNotificationId
               }
            }
         );
         Z163WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A163WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i163WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z150WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A150WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i150WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z159WWPWebNotificationStatus = 1;
         A159WWPWebNotificationStatus = 1;
         i159WWPWebNotificationStatus = 1;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z159WWPWebNotificationStatus ;
      private short A159WWPWebNotificationStatus ;
      private short Gx_BScreen ;
      private short RcdFound31 ;
      private short i159WWPWebNotificationStatus ;
      private int trnEnded ;
      private long Z152WWPWebNotificationId ;
      private long A152WWPWebNotificationId ;
      private long Z127WWPNotificationId ;
      private long A127WWPNotificationId ;
      private long Z128WWPNotificationDefinitionId ;
      private long A128WWPNotificationDefinitionId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode31 ;
      private DateTime Z150WWPWebNotificationCreated ;
      private DateTime A150WWPWebNotificationCreated ;
      private DateTime Z163WWPWebNotificationScheduled ;
      private DateTime A163WWPWebNotificationScheduled ;
      private DateTime Z160WWPWebNotificationProcessed ;
      private DateTime A160WWPWebNotificationProcessed ;
      private DateTime Z151WWPWebNotificationRead ;
      private DateTime A151WWPWebNotificationRead ;
      private DateTime Z129WWPNotificationCreated ;
      private DateTime A129WWPNotificationCreated ;
      private DateTime i150WWPWebNotificationCreated ;
      private DateTime i163WWPWebNotificationScheduled ;
      private bool Z162WWPWebNotificationReceived ;
      private bool A162WWPWebNotificationReceived ;
      private bool n165WWPNotificationMetadata ;
      private bool n151WWPWebNotificationRead ;
      private bool n161WWPWebNotificationDetail ;
      private bool n162WWPWebNotificationReceived ;
      private bool n127WWPNotificationId ;
      private bool Gx_longc ;
      private string Z158WWPWebNotificationClientId ;
      private string A158WWPWebNotificationClientId ;
      private string Z161WWPWebNotificationDetail ;
      private string A161WWPWebNotificationDetail ;
      private string Z165WWPNotificationMetadata ;
      private string A165WWPNotificationMetadata ;
      private string Z147WWPWebNotificationTitle ;
      private string A147WWPWebNotificationTitle ;
      private string Z148WWPWebNotificationText ;
      private string A148WWPWebNotificationText ;
      private string Z149WWPWebNotificationIcon ;
      private string A149WWPWebNotificationIcon ;
      private string Z164WWPNotificationDefinitionName ;
      private string A164WWPNotificationDefinitionName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC000L6_A128WWPNotificationDefinitionId ;
      private long[] BC000L6_A152WWPWebNotificationId ;
      private string[] BC000L6_A147WWPWebNotificationTitle ;
      private DateTime[] BC000L6_A129WWPNotificationCreated ;
      private string[] BC000L6_A165WWPNotificationMetadata ;
      private bool[] BC000L6_n165WWPNotificationMetadata ;
      private string[] BC000L6_A164WWPNotificationDefinitionName ;
      private string[] BC000L6_A148WWPWebNotificationText ;
      private string[] BC000L6_A149WWPWebNotificationIcon ;
      private string[] BC000L6_A158WWPWebNotificationClientId ;
      private short[] BC000L6_A159WWPWebNotificationStatus ;
      private DateTime[] BC000L6_A150WWPWebNotificationCreated ;
      private DateTime[] BC000L6_A163WWPWebNotificationScheduled ;
      private DateTime[] BC000L6_A160WWPWebNotificationProcessed ;
      private DateTime[] BC000L6_A151WWPWebNotificationRead ;
      private bool[] BC000L6_n151WWPWebNotificationRead ;
      private string[] BC000L6_A161WWPWebNotificationDetail ;
      private bool[] BC000L6_n161WWPWebNotificationDetail ;
      private bool[] BC000L6_A162WWPWebNotificationReceived ;
      private bool[] BC000L6_n162WWPWebNotificationReceived ;
      private long[] BC000L6_A127WWPNotificationId ;
      private bool[] BC000L6_n127WWPNotificationId ;
      private long[] BC000L4_A128WWPNotificationDefinitionId ;
      private DateTime[] BC000L4_A129WWPNotificationCreated ;
      private string[] BC000L4_A165WWPNotificationMetadata ;
      private bool[] BC000L4_n165WWPNotificationMetadata ;
      private string[] BC000L5_A164WWPNotificationDefinitionName ;
      private long[] BC000L7_A152WWPWebNotificationId ;
      private long[] BC000L3_A152WWPWebNotificationId ;
      private string[] BC000L3_A147WWPWebNotificationTitle ;
      private string[] BC000L3_A148WWPWebNotificationText ;
      private string[] BC000L3_A149WWPWebNotificationIcon ;
      private string[] BC000L3_A158WWPWebNotificationClientId ;
      private short[] BC000L3_A159WWPWebNotificationStatus ;
      private DateTime[] BC000L3_A150WWPWebNotificationCreated ;
      private DateTime[] BC000L3_A163WWPWebNotificationScheduled ;
      private DateTime[] BC000L3_A160WWPWebNotificationProcessed ;
      private DateTime[] BC000L3_A151WWPWebNotificationRead ;
      private bool[] BC000L3_n151WWPWebNotificationRead ;
      private string[] BC000L3_A161WWPWebNotificationDetail ;
      private bool[] BC000L3_n161WWPWebNotificationDetail ;
      private bool[] BC000L3_A162WWPWebNotificationReceived ;
      private bool[] BC000L3_n162WWPWebNotificationReceived ;
      private long[] BC000L3_A127WWPNotificationId ;
      private bool[] BC000L3_n127WWPNotificationId ;
      private long[] BC000L2_A152WWPWebNotificationId ;
      private string[] BC000L2_A147WWPWebNotificationTitle ;
      private string[] BC000L2_A148WWPWebNotificationText ;
      private string[] BC000L2_A149WWPWebNotificationIcon ;
      private string[] BC000L2_A158WWPWebNotificationClientId ;
      private short[] BC000L2_A159WWPWebNotificationStatus ;
      private DateTime[] BC000L2_A150WWPWebNotificationCreated ;
      private DateTime[] BC000L2_A163WWPWebNotificationScheduled ;
      private DateTime[] BC000L2_A160WWPWebNotificationProcessed ;
      private DateTime[] BC000L2_A151WWPWebNotificationRead ;
      private bool[] BC000L2_n151WWPWebNotificationRead ;
      private string[] BC000L2_A161WWPWebNotificationDetail ;
      private bool[] BC000L2_n161WWPWebNotificationDetail ;
      private bool[] BC000L2_A162WWPWebNotificationReceived ;
      private bool[] BC000L2_n162WWPWebNotificationReceived ;
      private long[] BC000L2_A127WWPNotificationId ;
      private bool[] BC000L2_n127WWPNotificationId ;
      private long[] BC000L9_A152WWPWebNotificationId ;
      private long[] BC000L12_A128WWPNotificationDefinitionId ;
      private DateTime[] BC000L12_A129WWPNotificationCreated ;
      private string[] BC000L12_A165WWPNotificationMetadata ;
      private bool[] BC000L12_n165WWPNotificationMetadata ;
      private string[] BC000L13_A164WWPNotificationDefinitionName ;
      private long[] BC000L14_A128WWPNotificationDefinitionId ;
      private long[] BC000L14_A152WWPWebNotificationId ;
      private string[] BC000L14_A147WWPWebNotificationTitle ;
      private DateTime[] BC000L14_A129WWPNotificationCreated ;
      private string[] BC000L14_A165WWPNotificationMetadata ;
      private bool[] BC000L14_n165WWPNotificationMetadata ;
      private string[] BC000L14_A164WWPNotificationDefinitionName ;
      private string[] BC000L14_A148WWPWebNotificationText ;
      private string[] BC000L14_A149WWPWebNotificationIcon ;
      private string[] BC000L14_A158WWPWebNotificationClientId ;
      private short[] BC000L14_A159WWPWebNotificationStatus ;
      private DateTime[] BC000L14_A150WWPWebNotificationCreated ;
      private DateTime[] BC000L14_A163WWPWebNotificationScheduled ;
      private DateTime[] BC000L14_A160WWPWebNotificationProcessed ;
      private DateTime[] BC000L14_A151WWPWebNotificationRead ;
      private bool[] BC000L14_n151WWPWebNotificationRead ;
      private string[] BC000L14_A161WWPWebNotificationDetail ;
      private bool[] BC000L14_n161WWPWebNotificationDetail ;
      private bool[] BC000L14_A162WWPWebNotificationReceived ;
      private bool[] BC000L14_n162WWPWebNotificationReceived ;
      private long[] BC000L14_A127WWPNotificationId ;
      private bool[] BC000L14_n127WWPNotificationId ;
      private GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification bcwwpbaseobjects_notifications_web_WWP_WebNotification ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_webnotification_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_webnotification_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_webnotification_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[5])
      ,new UpdateCursor(def[6])
      ,new ForEachCursor(def[7])
      ,new UpdateCursor(def[8])
      ,new UpdateCursor(def[9])
      ,new ForEachCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new ForEachCursor(def[12])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000L2;
       prmBC000L2 = new Object[] {
       new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
       };
       Object[] prmBC000L3;
       prmBC000L3 = new Object[] {
       new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
       };
       Object[] prmBC000L4;
       prmBC000L4 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmBC000L5;
       prmBC000L5 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmBC000L6;
       prmBC000L6 = new Object[] {
       new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
       };
       Object[] prmBC000L7;
       prmBC000L7 = new Object[] {
       new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
       };
       Object[] prmBC000L8;
       prmBC000L8 = new Object[] {
       new ParDef("WWPWebNotificationTitle",GXType.VarChar,40,0) ,
       new ParDef("WWPWebNotificationText",GXType.VarChar,120,0) ,
       new ParDef("WWPWebNotificationIcon",GXType.VarChar,255,0) ,
       new ParDef("WWPWebNotificationClientId",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPWebNotificationStatus",GXType.Int16,4,0) ,
       new ParDef("WWPWebNotificationCreated",GXType.DateTime2,10,12) ,
       new ParDef("WWPWebNotificationScheduled",GXType.DateTime2,10,12) ,
       new ParDef("WWPWebNotificationProcessed",GXType.DateTime2,10,12) ,
       new ParDef("WWPWebNotificationRead",GXType.DateTime2,10,12){Nullable=true} ,
       new ParDef("WWPWebNotificationDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPWebNotificationReceived",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmBC000L9;
       prmBC000L9 = new Object[] {
       };
       Object[] prmBC000L10;
       prmBC000L10 = new Object[] {
       new ParDef("WWPWebNotificationTitle",GXType.VarChar,40,0) ,
       new ParDef("WWPWebNotificationText",GXType.VarChar,120,0) ,
       new ParDef("WWPWebNotificationIcon",GXType.VarChar,255,0) ,
       new ParDef("WWPWebNotificationClientId",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPWebNotificationStatus",GXType.Int16,4,0) ,
       new ParDef("WWPWebNotificationCreated",GXType.DateTime2,10,12) ,
       new ParDef("WWPWebNotificationScheduled",GXType.DateTime2,10,12) ,
       new ParDef("WWPWebNotificationProcessed",GXType.DateTime2,10,12) ,
       new ParDef("WWPWebNotificationRead",GXType.DateTime2,10,12){Nullable=true} ,
       new ParDef("WWPWebNotificationDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPWebNotificationReceived",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true} ,
       new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
       };
       Object[] prmBC000L11;
       prmBC000L11 = new Object[] {
       new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
       };
       Object[] prmBC000L12;
       prmBC000L12 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmBC000L13;
       prmBC000L13 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmBC000L14;
       prmBC000L14 = new Object[] {
       new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC000L2", "SELECT WWPWebNotificationId, WWPWebNotificationTitle, WWPWebNotificationText, WWPWebNotificationIcon, WWPWebNotificationClientId, WWPWebNotificationStatus, WWPWebNotificationCreated, WWPWebNotificationScheduled, WWPWebNotificationProcessed, WWPWebNotificationRead, WWPWebNotificationDetail, WWPWebNotificationReceived, WWPNotificationId FROM WWP_WebNotification WHERE WWPWebNotificationId = :WWPWebNotificationId  FOR UPDATE OF WWP_WebNotification",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000L3", "SELECT WWPWebNotificationId, WWPWebNotificationTitle, WWPWebNotificationText, WWPWebNotificationIcon, WWPWebNotificationClientId, WWPWebNotificationStatus, WWPWebNotificationCreated, WWPWebNotificationScheduled, WWPWebNotificationProcessed, WWPWebNotificationRead, WWPWebNotificationDetail, WWPWebNotificationReceived, WWPNotificationId FROM WWP_WebNotification WHERE WWPWebNotificationId = :WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000L4", "SELECT WWPNotificationDefinitionId, WWPNotificationCreated, WWPNotificationMetadata FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000L5", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000L6", "SELECT T2.WWPNotificationDefinitionId, TM1.WWPWebNotificationId, TM1.WWPWebNotificationTitle, T2.WWPNotificationCreated, T2.WWPNotificationMetadata, T3.WWPNotificationDefinitionName, TM1.WWPWebNotificationText, TM1.WWPWebNotificationIcon, TM1.WWPWebNotificationClientId, TM1.WWPWebNotificationStatus, TM1.WWPWebNotificationCreated, TM1.WWPWebNotificationScheduled, TM1.WWPWebNotificationProcessed, TM1.WWPWebNotificationRead, TM1.WWPWebNotificationDetail, TM1.WWPWebNotificationReceived, TM1.WWPNotificationId FROM ((WWP_WebNotification TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) LEFT JOIN WWP_NotificationDefinition T3 ON T3.WWPNotificationDefinitionId = T2.WWPNotificationDefinitionId) WHERE TM1.WWPWebNotificationId = :WWPWebNotificationId ORDER BY TM1.WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L6,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000L7", "SELECT WWPWebNotificationId FROM WWP_WebNotification WHERE WWPWebNotificationId = :WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000L8", "SAVEPOINT gxupdate;INSERT INTO WWP_WebNotification(WWPWebNotificationTitle, WWPWebNotificationText, WWPWebNotificationIcon, WWPWebNotificationClientId, WWPWebNotificationStatus, WWPWebNotificationCreated, WWPWebNotificationScheduled, WWPWebNotificationProcessed, WWPWebNotificationRead, WWPWebNotificationDetail, WWPWebNotificationReceived, WWPNotificationId) VALUES(:WWPWebNotificationTitle, :WWPWebNotificationText, :WWPWebNotificationIcon, :WWPWebNotificationClientId, :WWPWebNotificationStatus, :WWPWebNotificationCreated, :WWPWebNotificationScheduled, :WWPWebNotificationProcessed, :WWPWebNotificationRead, :WWPWebNotificationDetail, :WWPWebNotificationReceived, :WWPNotificationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000L8)
          ,new CursorDef("BC000L9", "SELECT currval('WWPWebNotificationId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000L10", "SAVEPOINT gxupdate;UPDATE WWP_WebNotification SET WWPWebNotificationTitle=:WWPWebNotificationTitle, WWPWebNotificationText=:WWPWebNotificationText, WWPWebNotificationIcon=:WWPWebNotificationIcon, WWPWebNotificationClientId=:WWPWebNotificationClientId, WWPWebNotificationStatus=:WWPWebNotificationStatus, WWPWebNotificationCreated=:WWPWebNotificationCreated, WWPWebNotificationScheduled=:WWPWebNotificationScheduled, WWPWebNotificationProcessed=:WWPWebNotificationProcessed, WWPWebNotificationRead=:WWPWebNotificationRead, WWPWebNotificationDetail=:WWPWebNotificationDetail, WWPWebNotificationReceived=:WWPWebNotificationReceived, WWPNotificationId=:WWPNotificationId  WHERE WWPWebNotificationId = :WWPWebNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000L10)
          ,new CursorDef("BC000L11", "SAVEPOINT gxupdate;DELETE FROM WWP_WebNotification  WHERE WWPWebNotificationId = :WWPWebNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000L11)
          ,new CursorDef("BC000L12", "SELECT WWPNotificationDefinitionId, WWPNotificationCreated, WWPNotificationMetadata FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L12,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000L13", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L13,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000L14", "SELECT T2.WWPNotificationDefinitionId, TM1.WWPWebNotificationId, TM1.WWPWebNotificationTitle, T2.WWPNotificationCreated, T2.WWPNotificationMetadata, T3.WWPNotificationDefinitionName, TM1.WWPWebNotificationText, TM1.WWPWebNotificationIcon, TM1.WWPWebNotificationClientId, TM1.WWPWebNotificationStatus, TM1.WWPWebNotificationCreated, TM1.WWPWebNotificationScheduled, TM1.WWPWebNotificationProcessed, TM1.WWPWebNotificationRead, TM1.WWPWebNotificationDetail, TM1.WWPWebNotificationReceived, TM1.WWPNotificationId FROM ((WWP_WebNotification TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) LEFT JOIN WWP_NotificationDefinition T3 ON T3.WWPNotificationDefinitionId = T2.WWPNotificationDefinitionId) WHERE TM1.WWPWebNotificationId = :WWPWebNotificationId ORDER BY TM1.WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L14,100, GxCacheFrequency.OFF ,true,false )
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
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
             ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
             ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9, true);
             ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10, true);
             ((bool[]) buf[10])[0] = rslt.wasNull(10);
             ((string[]) buf[11])[0] = rslt.getLongVarchar(11);
             ((bool[]) buf[12])[0] = rslt.wasNull(11);
             ((bool[]) buf[13])[0] = rslt.getBool(12);
             ((bool[]) buf[14])[0] = rslt.wasNull(12);
             ((long[]) buf[15])[0] = rslt.getLong(13);
             ((bool[]) buf[16])[0] = rslt.wasNull(13);
             return;
          case 1 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
             ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
             ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9, true);
             ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10, true);
             ((bool[]) buf[10])[0] = rslt.wasNull(10);
             ((string[]) buf[11])[0] = rslt.getLongVarchar(11);
             ((bool[]) buf[12])[0] = rslt.wasNull(11);
             ((bool[]) buf[13])[0] = rslt.getBool(12);
             ((bool[]) buf[14])[0] = rslt.wasNull(12);
             ((long[]) buf[15])[0] = rslt.getLong(13);
             ((bool[]) buf[16])[0] = rslt.wasNull(13);
             return;
          case 2 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 4 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((long[]) buf[1])[0] = rslt.getLong(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             ((string[]) buf[6])[0] = rslt.getVarchar(6);
             ((string[]) buf[7])[0] = rslt.getVarchar(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
             ((short[]) buf[10])[0] = rslt.getShort(10);
             ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(11, true);
             ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(12, true);
             ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(13, true);
             ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(14, true);
             ((bool[]) buf[15])[0] = rslt.wasNull(14);
             ((string[]) buf[16])[0] = rslt.getLongVarchar(15);
             ((bool[]) buf[17])[0] = rslt.wasNull(15);
             ((bool[]) buf[18])[0] = rslt.getBool(16);
             ((bool[]) buf[19])[0] = rslt.wasNull(16);
             ((long[]) buf[20])[0] = rslt.getLong(17);
             ((bool[]) buf[21])[0] = rslt.wasNull(17);
             return;
          case 5 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 7 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 10 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             return;
          case 11 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 12 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((long[]) buf[1])[0] = rslt.getLong(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             ((string[]) buf[6])[0] = rslt.getVarchar(6);
             ((string[]) buf[7])[0] = rslt.getVarchar(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
             ((short[]) buf[10])[0] = rslt.getShort(10);
             ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(11, true);
             ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(12, true);
             ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(13, true);
             ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(14, true);
             ((bool[]) buf[15])[0] = rslt.wasNull(14);
             ((string[]) buf[16])[0] = rslt.getLongVarchar(15);
             ((bool[]) buf[17])[0] = rslt.wasNull(15);
             ((bool[]) buf[18])[0] = rslt.getBool(16);
             ((bool[]) buf[19])[0] = rslt.wasNull(16);
             ((long[]) buf[20])[0] = rslt.getLong(17);
             ((bool[]) buf[21])[0] = rslt.wasNull(17);
             return;
    }
 }

}

}
