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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_notification_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_notification_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_notification_bc( IGxContext context )
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
         ReadRow0O34( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0O34( ) ;
         standaloneModal( ) ;
         AddRow0O34( ) ;
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
               Z127WWPNotificationId = A127WWPNotificationId;
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

      protected void CONFIRM_0O0( )
      {
         BeforeValidate0O34( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0O34( ) ;
            }
            else
            {
               CheckExtendedTable0O34( ) ;
               if ( AnyError == 0 )
               {
                  ZM0O34( 5) ;
                  ZM0O34( 6) ;
               }
               CloseExtendedTableCursors0O34( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0O34( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z129WWPNotificationCreated = A129WWPNotificationCreated;
            Z181WWPNotificationIcon = A181WWPNotificationIcon;
            Z182WWPNotificationTitle = A182WWPNotificationTitle;
            Z183WWPNotificationShortDescriptio = A183WWPNotificationShortDescriptio;
            Z184WWPNotificationLink = A184WWPNotificationLink;
            Z187WWPNotificationIsRead = A187WWPNotificationIsRead;
            Z128WWPNotificationDefinitionId = A128WWPNotificationDefinitionId;
            Z112WWPUserExtendedId = A112WWPUserExtendedId;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z164WWPNotificationDefinitionName = A164WWPNotificationDefinitionName;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z113WWPUserExtendedFullName = A113WWPUserExtendedFullName;
         }
         if ( GX_JID == -4 )
         {
            Z127WWPNotificationId = A127WWPNotificationId;
            Z129WWPNotificationCreated = A129WWPNotificationCreated;
            Z181WWPNotificationIcon = A181WWPNotificationIcon;
            Z182WWPNotificationTitle = A182WWPNotificationTitle;
            Z183WWPNotificationShortDescriptio = A183WWPNotificationShortDescriptio;
            Z184WWPNotificationLink = A184WWPNotificationLink;
            Z187WWPNotificationIsRead = A187WWPNotificationIsRead;
            Z165WWPNotificationMetadata = A165WWPNotificationMetadata;
            Z128WWPNotificationDefinitionId = A128WWPNotificationDefinitionId;
            Z112WWPUserExtendedId = A112WWPUserExtendedId;
            Z164WWPNotificationDefinitionName = A164WWPNotificationDefinitionName;
            Z113WWPUserExtendedFullName = A113WWPUserExtendedFullName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A129WWPNotificationCreated) && ( Gx_BScreen == 0 ) )
         {
            A129WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         }
      }

      protected void Load0O34( )
      {
         /* Using cursor BC000O6 */
         pr_default.execute(4, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound34 = 1;
            A164WWPNotificationDefinitionName = BC000O6_A164WWPNotificationDefinitionName[0];
            A129WWPNotificationCreated = BC000O6_A129WWPNotificationCreated[0];
            A181WWPNotificationIcon = BC000O6_A181WWPNotificationIcon[0];
            A182WWPNotificationTitle = BC000O6_A182WWPNotificationTitle[0];
            A183WWPNotificationShortDescriptio = BC000O6_A183WWPNotificationShortDescriptio[0];
            A184WWPNotificationLink = BC000O6_A184WWPNotificationLink[0];
            A187WWPNotificationIsRead = BC000O6_A187WWPNotificationIsRead[0];
            A113WWPUserExtendedFullName = BC000O6_A113WWPUserExtendedFullName[0];
            A165WWPNotificationMetadata = BC000O6_A165WWPNotificationMetadata[0];
            n165WWPNotificationMetadata = BC000O6_n165WWPNotificationMetadata[0];
            A128WWPNotificationDefinitionId = BC000O6_A128WWPNotificationDefinitionId[0];
            A112WWPUserExtendedId = BC000O6_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = BC000O6_n112WWPUserExtendedId[0];
            ZM0O34( -4) ;
         }
         pr_default.close(4);
         OnLoadActions0O34( ) ;
      }

      protected void OnLoadActions0O34( )
      {
      }

      protected void CheckExtendedTable0O34( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000O4 */
         pr_default.execute(2, new Object[] {A128WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
         }
         A164WWPNotificationDefinitionName = BC000O4_A164WWPNotificationDefinitionName[0];
         pr_default.close(2);
         if ( ! ( GxRegex.IsMatch(A184WWPNotificationLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Notification Link", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000O5 */
         pr_default.execute(3, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A112WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
            }
         }
         A113WWPUserExtendedFullName = BC000O5_A113WWPUserExtendedFullName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0O34( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0O34( )
      {
         /* Using cursor BC000O7 */
         pr_default.execute(5, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound34 = 1;
         }
         else
         {
            RcdFound34 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000O3 */
         pr_default.execute(1, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0O34( 4) ;
            RcdFound34 = 1;
            A127WWPNotificationId = BC000O3_A127WWPNotificationId[0];
            n127WWPNotificationId = BC000O3_n127WWPNotificationId[0];
            A129WWPNotificationCreated = BC000O3_A129WWPNotificationCreated[0];
            A181WWPNotificationIcon = BC000O3_A181WWPNotificationIcon[0];
            A182WWPNotificationTitle = BC000O3_A182WWPNotificationTitle[0];
            A183WWPNotificationShortDescriptio = BC000O3_A183WWPNotificationShortDescriptio[0];
            A184WWPNotificationLink = BC000O3_A184WWPNotificationLink[0];
            A187WWPNotificationIsRead = BC000O3_A187WWPNotificationIsRead[0];
            A165WWPNotificationMetadata = BC000O3_A165WWPNotificationMetadata[0];
            n165WWPNotificationMetadata = BC000O3_n165WWPNotificationMetadata[0];
            A128WWPNotificationDefinitionId = BC000O3_A128WWPNotificationDefinitionId[0];
            A112WWPUserExtendedId = BC000O3_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = BC000O3_n112WWPUserExtendedId[0];
            Z127WWPNotificationId = A127WWPNotificationId;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0O34( ) ;
            if ( AnyError == 1 )
            {
               RcdFound34 = 0;
               InitializeNonKey0O34( ) ;
            }
            Gx_mode = sMode34;
         }
         else
         {
            RcdFound34 = 0;
            InitializeNonKey0O34( ) ;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode34;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0O34( ) ;
         if ( RcdFound34 == 0 )
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
         CONFIRM_0O0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0O34( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000O2 */
            pr_default.execute(0, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Notification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z129WWPNotificationCreated != BC000O2_A129WWPNotificationCreated[0] ) || ( StringUtil.StrCmp(Z181WWPNotificationIcon, BC000O2_A181WWPNotificationIcon[0]) != 0 ) || ( StringUtil.StrCmp(Z182WWPNotificationTitle, BC000O2_A182WWPNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z183WWPNotificationShortDescriptio, BC000O2_A183WWPNotificationShortDescriptio[0]) != 0 ) || ( StringUtil.StrCmp(Z184WWPNotificationLink, BC000O2_A184WWPNotificationLink[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z187WWPNotificationIsRead != BC000O2_A187WWPNotificationIsRead[0] ) || ( Z128WWPNotificationDefinitionId != BC000O2_A128WWPNotificationDefinitionId[0] ) || ( StringUtil.StrCmp(Z112WWPUserExtendedId, BC000O2_A112WWPUserExtendedId[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Notification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0O34( )
      {
         BeforeValidate0O34( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0O34( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0O34( 0) ;
            CheckOptimisticConcurrency0O34( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0O34( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0O34( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000O8 */
                     pr_default.execute(6, new Object[] {A129WWPNotificationCreated, A181WWPNotificationIcon, A182WWPNotificationTitle, A183WWPNotificationShortDescriptio, A184WWPNotificationLink, A187WWPNotificationIsRead, n165WWPNotificationMetadata, A165WWPNotificationMetadata, A128WWPNotificationDefinitionId, n112WWPUserExtendedId, A112WWPUserExtendedId});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000O9 */
                     pr_default.execute(7);
                     A127WWPNotificationId = BC000O9_A127WWPNotificationId[0];
                     n127WWPNotificationId = BC000O9_n127WWPNotificationId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
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
               Load0O34( ) ;
            }
            EndLevel0O34( ) ;
         }
         CloseExtendedTableCursors0O34( ) ;
      }

      protected void Update0O34( )
      {
         BeforeValidate0O34( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0O34( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0O34( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0O34( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0O34( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000O10 */
                     pr_default.execute(8, new Object[] {A129WWPNotificationCreated, A181WWPNotificationIcon, A182WWPNotificationTitle, A183WWPNotificationShortDescriptio, A184WWPNotificationLink, A187WWPNotificationIsRead, n165WWPNotificationMetadata, A165WWPNotificationMetadata, A128WWPNotificationDefinitionId, n112WWPUserExtendedId, A112WWPUserExtendedId, n127WWPNotificationId, A127WWPNotificationId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Notification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0O34( ) ;
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
            EndLevel0O34( ) ;
         }
         CloseExtendedTableCursors0O34( ) ;
      }

      protected void DeferredUpdate0O34( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0O34( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0O34( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0O34( ) ;
            AfterConfirm0O34( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0O34( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000O11 */
                  pr_default.execute(9, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
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
         sMode34 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0O34( ) ;
         Gx_mode = sMode34;
      }

      protected void OnDeleteControls0O34( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000O12 */
            pr_default.execute(10, new Object[] {A128WWPNotificationDefinitionId});
            A164WWPNotificationDefinitionName = BC000O12_A164WWPNotificationDefinitionName[0];
            pr_default.close(10);
            /* Using cursor BC000O13 */
            pr_default.execute(11, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
            A113WWPUserExtendedFullName = BC000O13_A113WWPUserExtendedFullName[0];
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000O14 */
            pr_default.execute(12, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_Mail", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC000O15 */
            pr_default.execute(13, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_WebNotification", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor BC000O16 */
            pr_default.execute(14, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_SMS", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel0O34( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0O34( ) ;
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

      public void ScanKeyStart0O34( )
      {
         /* Using cursor BC000O17 */
         pr_default.execute(15, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
         RcdFound34 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound34 = 1;
            A127WWPNotificationId = BC000O17_A127WWPNotificationId[0];
            n127WWPNotificationId = BC000O17_n127WWPNotificationId[0];
            A164WWPNotificationDefinitionName = BC000O17_A164WWPNotificationDefinitionName[0];
            A129WWPNotificationCreated = BC000O17_A129WWPNotificationCreated[0];
            A181WWPNotificationIcon = BC000O17_A181WWPNotificationIcon[0];
            A182WWPNotificationTitle = BC000O17_A182WWPNotificationTitle[0];
            A183WWPNotificationShortDescriptio = BC000O17_A183WWPNotificationShortDescriptio[0];
            A184WWPNotificationLink = BC000O17_A184WWPNotificationLink[0];
            A187WWPNotificationIsRead = BC000O17_A187WWPNotificationIsRead[0];
            A113WWPUserExtendedFullName = BC000O17_A113WWPUserExtendedFullName[0];
            A165WWPNotificationMetadata = BC000O17_A165WWPNotificationMetadata[0];
            n165WWPNotificationMetadata = BC000O17_n165WWPNotificationMetadata[0];
            A128WWPNotificationDefinitionId = BC000O17_A128WWPNotificationDefinitionId[0];
            A112WWPUserExtendedId = BC000O17_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = BC000O17_n112WWPUserExtendedId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0O34( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound34 = 0;
         ScanKeyLoad0O34( ) ;
      }

      protected void ScanKeyLoad0O34( )
      {
         sMode34 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound34 = 1;
            A127WWPNotificationId = BC000O17_A127WWPNotificationId[0];
            n127WWPNotificationId = BC000O17_n127WWPNotificationId[0];
            A164WWPNotificationDefinitionName = BC000O17_A164WWPNotificationDefinitionName[0];
            A129WWPNotificationCreated = BC000O17_A129WWPNotificationCreated[0];
            A181WWPNotificationIcon = BC000O17_A181WWPNotificationIcon[0];
            A182WWPNotificationTitle = BC000O17_A182WWPNotificationTitle[0];
            A183WWPNotificationShortDescriptio = BC000O17_A183WWPNotificationShortDescriptio[0];
            A184WWPNotificationLink = BC000O17_A184WWPNotificationLink[0];
            A187WWPNotificationIsRead = BC000O17_A187WWPNotificationIsRead[0];
            A113WWPUserExtendedFullName = BC000O17_A113WWPUserExtendedFullName[0];
            A165WWPNotificationMetadata = BC000O17_A165WWPNotificationMetadata[0];
            n165WWPNotificationMetadata = BC000O17_n165WWPNotificationMetadata[0];
            A128WWPNotificationDefinitionId = BC000O17_A128WWPNotificationDefinitionId[0];
            A112WWPUserExtendedId = BC000O17_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = BC000O17_n112WWPUserExtendedId[0];
         }
         Gx_mode = sMode34;
      }

      protected void ScanKeyEnd0O34( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0O34( )
      {
         /* After Confirm Rules */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A112WWPUserExtendedId)) )
         {
            A112WWPUserExtendedId = "";
            n112WWPUserExtendedId = false;
            n112WWPUserExtendedId = true;
         }
      }

      protected void BeforeInsert0O34( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0O34( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0O34( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0O34( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0O34( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0O34( )
      {
      }

      protected void send_integrity_lvl_hashes0O34( )
      {
      }

      protected void AddRow0O34( )
      {
         VarsToRow34( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
      }

      protected void ReadRow0O34( )
      {
         RowToVars34( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
      }

      protected void InitializeNonKey0O34( )
      {
         A128WWPNotificationDefinitionId = 0;
         A164WWPNotificationDefinitionName = "";
         A181WWPNotificationIcon = "";
         A182WWPNotificationTitle = "";
         A183WWPNotificationShortDescriptio = "";
         A184WWPNotificationLink = "";
         A187WWPNotificationIsRead = false;
         A112WWPUserExtendedId = "";
         n112WWPUserExtendedId = false;
         A113WWPUserExtendedFullName = "";
         A165WWPNotificationMetadata = "";
         n165WWPNotificationMetadata = false;
         A129WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z181WWPNotificationIcon = "";
         Z182WWPNotificationTitle = "";
         Z183WWPNotificationShortDescriptio = "";
         Z184WWPNotificationLink = "";
         Z187WWPNotificationIsRead = false;
         Z128WWPNotificationDefinitionId = 0;
         Z112WWPUserExtendedId = "";
      }

      protected void InitAll0O34( )
      {
         A127WWPNotificationId = 0;
         n127WWPNotificationId = false;
         InitializeNonKey0O34( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A129WWPNotificationCreated = i129WWPNotificationCreated;
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

      public void VarsToRow34( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification obj34 )
      {
         obj34.gxTpr_Mode = Gx_mode;
         obj34.gxTpr_Wwpnotificationdefinitionid = A128WWPNotificationDefinitionId;
         obj34.gxTpr_Wwpnotificationdefinitionname = A164WWPNotificationDefinitionName;
         obj34.gxTpr_Wwpnotificationicon = A181WWPNotificationIcon;
         obj34.gxTpr_Wwpnotificationtitle = A182WWPNotificationTitle;
         obj34.gxTpr_Wwpnotificationshortdescription = A183WWPNotificationShortDescriptio;
         obj34.gxTpr_Wwpnotificationlink = A184WWPNotificationLink;
         obj34.gxTpr_Wwpnotificationisread = A187WWPNotificationIsRead;
         obj34.gxTpr_Wwpuserextendedid = A112WWPUserExtendedId;
         obj34.gxTpr_Wwpuserextendedfullname = A113WWPUserExtendedFullName;
         obj34.gxTpr_Wwpnotificationmetadata = A165WWPNotificationMetadata;
         obj34.gxTpr_Wwpnotificationcreated = A129WWPNotificationCreated;
         obj34.gxTpr_Wwpnotificationid = A127WWPNotificationId;
         obj34.gxTpr_Wwpnotificationid_Z = Z127WWPNotificationId;
         obj34.gxTpr_Wwpnotificationdefinitionid_Z = Z128WWPNotificationDefinitionId;
         obj34.gxTpr_Wwpnotificationdefinitionname_Z = Z164WWPNotificationDefinitionName;
         obj34.gxTpr_Wwpnotificationcreated_Z = Z129WWPNotificationCreated;
         obj34.gxTpr_Wwpnotificationicon_Z = Z181WWPNotificationIcon;
         obj34.gxTpr_Wwpnotificationtitle_Z = Z182WWPNotificationTitle;
         obj34.gxTpr_Wwpnotificationshortdescription_Z = Z183WWPNotificationShortDescriptio;
         obj34.gxTpr_Wwpnotificationlink_Z = Z184WWPNotificationLink;
         obj34.gxTpr_Wwpnotificationisread_Z = Z187WWPNotificationIsRead;
         obj34.gxTpr_Wwpuserextendedid_Z = Z112WWPUserExtendedId;
         obj34.gxTpr_Wwpuserextendedfullname_Z = Z113WWPUserExtendedFullName;
         obj34.gxTpr_Wwpnotificationid_N = (short)(Convert.ToInt16(n127WWPNotificationId));
         obj34.gxTpr_Wwpuserextendedid_N = (short)(Convert.ToInt16(n112WWPUserExtendedId));
         obj34.gxTpr_Wwpnotificationmetadata_N = (short)(Convert.ToInt16(n165WWPNotificationMetadata));
         obj34.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow34( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification obj34 )
      {
         obj34.gxTpr_Wwpnotificationid = A127WWPNotificationId;
         return  ;
      }

      public void RowToVars34( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification obj34 ,
                               int forceLoad )
      {
         Gx_mode = obj34.gxTpr_Mode;
         A128WWPNotificationDefinitionId = obj34.gxTpr_Wwpnotificationdefinitionid;
         A164WWPNotificationDefinitionName = obj34.gxTpr_Wwpnotificationdefinitionname;
         A181WWPNotificationIcon = obj34.gxTpr_Wwpnotificationicon;
         A182WWPNotificationTitle = obj34.gxTpr_Wwpnotificationtitle;
         A183WWPNotificationShortDescriptio = obj34.gxTpr_Wwpnotificationshortdescription;
         A184WWPNotificationLink = obj34.gxTpr_Wwpnotificationlink;
         A187WWPNotificationIsRead = obj34.gxTpr_Wwpnotificationisread;
         A112WWPUserExtendedId = obj34.gxTpr_Wwpuserextendedid;
         n112WWPUserExtendedId = false;
         A113WWPUserExtendedFullName = obj34.gxTpr_Wwpuserextendedfullname;
         A165WWPNotificationMetadata = obj34.gxTpr_Wwpnotificationmetadata;
         n165WWPNotificationMetadata = false;
         A129WWPNotificationCreated = obj34.gxTpr_Wwpnotificationcreated;
         A127WWPNotificationId = obj34.gxTpr_Wwpnotificationid;
         n127WWPNotificationId = false;
         Z127WWPNotificationId = obj34.gxTpr_Wwpnotificationid_Z;
         Z128WWPNotificationDefinitionId = obj34.gxTpr_Wwpnotificationdefinitionid_Z;
         Z164WWPNotificationDefinitionName = obj34.gxTpr_Wwpnotificationdefinitionname_Z;
         Z129WWPNotificationCreated = obj34.gxTpr_Wwpnotificationcreated_Z;
         Z181WWPNotificationIcon = obj34.gxTpr_Wwpnotificationicon_Z;
         Z182WWPNotificationTitle = obj34.gxTpr_Wwpnotificationtitle_Z;
         Z183WWPNotificationShortDescriptio = obj34.gxTpr_Wwpnotificationshortdescription_Z;
         Z184WWPNotificationLink = obj34.gxTpr_Wwpnotificationlink_Z;
         Z187WWPNotificationIsRead = obj34.gxTpr_Wwpnotificationisread_Z;
         Z112WWPUserExtendedId = obj34.gxTpr_Wwpuserextendedid_Z;
         Z113WWPUserExtendedFullName = obj34.gxTpr_Wwpuserextendedfullname_Z;
         n127WWPNotificationId = (bool)(Convert.ToBoolean(obj34.gxTpr_Wwpnotificationid_N));
         n112WWPUserExtendedId = (bool)(Convert.ToBoolean(obj34.gxTpr_Wwpuserextendedid_N));
         n165WWPNotificationMetadata = (bool)(Convert.ToBoolean(obj34.gxTpr_Wwpnotificationmetadata_N));
         Gx_mode = obj34.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A127WWPNotificationId = (long)getParm(obj,0);
         n127WWPNotificationId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0O34( ) ;
         ScanKeyStart0O34( ) ;
         if ( RcdFound34 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z127WWPNotificationId = A127WWPNotificationId;
         }
         ZM0O34( -4) ;
         OnLoadActions0O34( ) ;
         AddRow0O34( ) ;
         ScanKeyEnd0O34( ) ;
         if ( RcdFound34 == 0 )
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
         RowToVars34( bcwwpbaseobjects_notifications_common_WWP_Notification, 0) ;
         ScanKeyStart0O34( ) ;
         if ( RcdFound34 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z127WWPNotificationId = A127WWPNotificationId;
         }
         ZM0O34( -4) ;
         OnLoadActions0O34( ) ;
         AddRow0O34( ) ;
         ScanKeyEnd0O34( ) ;
         if ( RcdFound34 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0O34( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0O34( ) ;
         }
         else
         {
            if ( RcdFound34 == 1 )
            {
               if ( A127WWPNotificationId != Z127WWPNotificationId )
               {
                  A127WWPNotificationId = Z127WWPNotificationId;
                  n127WWPNotificationId = false;
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
                  Update0O34( ) ;
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
                  if ( A127WWPNotificationId != Z127WWPNotificationId )
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
                        Insert0O34( ) ;
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
                        Insert0O34( ) ;
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
         RowToVars34( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
         SaveImpl( ) ;
         VarsToRow34( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars34( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0O34( ) ;
         AfterTrn( ) ;
         VarsToRow34( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow34( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification auxBC = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A127WWPNotificationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_notifications_common_WWP_Notification);
               auxBC.Save();
               bcwwpbaseobjects_notifications_common_WWP_Notification.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars34( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
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
         RowToVars34( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0O34( ) ;
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
               VarsToRow34( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow34( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
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
         RowToVars34( bcwwpbaseobjects_notifications_common_WWP_Notification, 0) ;
         GetKey0O34( ) ;
         if ( RcdFound34 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A127WWPNotificationId != Z127WWPNotificationId )
            {
               A127WWPNotificationId = Z127WWPNotificationId;
               n127WWPNotificationId = false;
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
            if ( A127WWPNotificationId != Z127WWPNotificationId )
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
         context.RollbackDataStores("wwpbaseobjects.notifications.common.wwp_notification_bc",pr_default);
         VarsToRow34( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
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
         Gx_mode = bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_notifications_common_WWP_Notification )
         {
            bcwwpbaseobjects_notifications_common_WWP_Notification = (GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow34( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
            }
            else
            {
               RowToVars34( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars34( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_Notification WWP_Notification_BC
      {
         get {
            return bcwwpbaseobjects_notifications_common_WWP_Notification ;
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
            return "wwp_notification_Execute" ;
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
         Z129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z181WWPNotificationIcon = "";
         A181WWPNotificationIcon = "";
         Z182WWPNotificationTitle = "";
         A182WWPNotificationTitle = "";
         Z183WWPNotificationShortDescriptio = "";
         A183WWPNotificationShortDescriptio = "";
         Z184WWPNotificationLink = "";
         A184WWPNotificationLink = "";
         Z112WWPUserExtendedId = "";
         A112WWPUserExtendedId = "";
         Z164WWPNotificationDefinitionName = "";
         A164WWPNotificationDefinitionName = "";
         Z113WWPUserExtendedFullName = "";
         A113WWPUserExtendedFullName = "";
         Z165WWPNotificationMetadata = "";
         A165WWPNotificationMetadata = "";
         BC000O6_A127WWPNotificationId = new long[1] ;
         BC000O6_n127WWPNotificationId = new bool[] {false} ;
         BC000O6_A164WWPNotificationDefinitionName = new string[] {""} ;
         BC000O6_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000O6_A181WWPNotificationIcon = new string[] {""} ;
         BC000O6_A182WWPNotificationTitle = new string[] {""} ;
         BC000O6_A183WWPNotificationShortDescriptio = new string[] {""} ;
         BC000O6_A184WWPNotificationLink = new string[] {""} ;
         BC000O6_A187WWPNotificationIsRead = new bool[] {false} ;
         BC000O6_A113WWPUserExtendedFullName = new string[] {""} ;
         BC000O6_A165WWPNotificationMetadata = new string[] {""} ;
         BC000O6_n165WWPNotificationMetadata = new bool[] {false} ;
         BC000O6_A128WWPNotificationDefinitionId = new long[1] ;
         BC000O6_A112WWPUserExtendedId = new string[] {""} ;
         BC000O6_n112WWPUserExtendedId = new bool[] {false} ;
         BC000O4_A164WWPNotificationDefinitionName = new string[] {""} ;
         BC000O5_A113WWPUserExtendedFullName = new string[] {""} ;
         BC000O7_A127WWPNotificationId = new long[1] ;
         BC000O7_n127WWPNotificationId = new bool[] {false} ;
         BC000O3_A127WWPNotificationId = new long[1] ;
         BC000O3_n127WWPNotificationId = new bool[] {false} ;
         BC000O3_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000O3_A181WWPNotificationIcon = new string[] {""} ;
         BC000O3_A182WWPNotificationTitle = new string[] {""} ;
         BC000O3_A183WWPNotificationShortDescriptio = new string[] {""} ;
         BC000O3_A184WWPNotificationLink = new string[] {""} ;
         BC000O3_A187WWPNotificationIsRead = new bool[] {false} ;
         BC000O3_A165WWPNotificationMetadata = new string[] {""} ;
         BC000O3_n165WWPNotificationMetadata = new bool[] {false} ;
         BC000O3_A128WWPNotificationDefinitionId = new long[1] ;
         BC000O3_A112WWPUserExtendedId = new string[] {""} ;
         BC000O3_n112WWPUserExtendedId = new bool[] {false} ;
         sMode34 = "";
         BC000O2_A127WWPNotificationId = new long[1] ;
         BC000O2_n127WWPNotificationId = new bool[] {false} ;
         BC000O2_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000O2_A181WWPNotificationIcon = new string[] {""} ;
         BC000O2_A182WWPNotificationTitle = new string[] {""} ;
         BC000O2_A183WWPNotificationShortDescriptio = new string[] {""} ;
         BC000O2_A184WWPNotificationLink = new string[] {""} ;
         BC000O2_A187WWPNotificationIsRead = new bool[] {false} ;
         BC000O2_A165WWPNotificationMetadata = new string[] {""} ;
         BC000O2_n165WWPNotificationMetadata = new bool[] {false} ;
         BC000O2_A128WWPNotificationDefinitionId = new long[1] ;
         BC000O2_A112WWPUserExtendedId = new string[] {""} ;
         BC000O2_n112WWPUserExtendedId = new bool[] {false} ;
         BC000O9_A127WWPNotificationId = new long[1] ;
         BC000O9_n127WWPNotificationId = new bool[] {false} ;
         BC000O12_A164WWPNotificationDefinitionName = new string[] {""} ;
         BC000O13_A113WWPUserExtendedFullName = new string[] {""} ;
         BC000O14_A185WWPMailId = new long[1] ;
         BC000O15_A152WWPWebNotificationId = new long[1] ;
         BC000O16_A138WWPSMSId = new long[1] ;
         BC000O17_A127WWPNotificationId = new long[1] ;
         BC000O17_n127WWPNotificationId = new bool[] {false} ;
         BC000O17_A164WWPNotificationDefinitionName = new string[] {""} ;
         BC000O17_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000O17_A181WWPNotificationIcon = new string[] {""} ;
         BC000O17_A182WWPNotificationTitle = new string[] {""} ;
         BC000O17_A183WWPNotificationShortDescriptio = new string[] {""} ;
         BC000O17_A184WWPNotificationLink = new string[] {""} ;
         BC000O17_A187WWPNotificationIsRead = new bool[] {false} ;
         BC000O17_A113WWPUserExtendedFullName = new string[] {""} ;
         BC000O17_A165WWPNotificationMetadata = new string[] {""} ;
         BC000O17_n165WWPNotificationMetadata = new bool[] {false} ;
         BC000O17_A128WWPNotificationDefinitionId = new long[1] ;
         BC000O17_A112WWPUserExtendedId = new string[] {""} ;
         BC000O17_n112WWPUserExtendedId = new bool[] {false} ;
         i129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification_bc__default(),
            new Object[][] {
                new Object[] {
               BC000O2_A127WWPNotificationId, BC000O2_A129WWPNotificationCreated, BC000O2_A181WWPNotificationIcon, BC000O2_A182WWPNotificationTitle, BC000O2_A183WWPNotificationShortDescriptio, BC000O2_A184WWPNotificationLink, BC000O2_A187WWPNotificationIsRead, BC000O2_A165WWPNotificationMetadata, BC000O2_n165WWPNotificationMetadata, BC000O2_A128WWPNotificationDefinitionId,
               BC000O2_A112WWPUserExtendedId, BC000O2_n112WWPUserExtendedId
               }
               , new Object[] {
               BC000O3_A127WWPNotificationId, BC000O3_A129WWPNotificationCreated, BC000O3_A181WWPNotificationIcon, BC000O3_A182WWPNotificationTitle, BC000O3_A183WWPNotificationShortDescriptio, BC000O3_A184WWPNotificationLink, BC000O3_A187WWPNotificationIsRead, BC000O3_A165WWPNotificationMetadata, BC000O3_n165WWPNotificationMetadata, BC000O3_A128WWPNotificationDefinitionId,
               BC000O3_A112WWPUserExtendedId, BC000O3_n112WWPUserExtendedId
               }
               , new Object[] {
               BC000O4_A164WWPNotificationDefinitionName
               }
               , new Object[] {
               BC000O5_A113WWPUserExtendedFullName
               }
               , new Object[] {
               BC000O6_A127WWPNotificationId, BC000O6_A164WWPNotificationDefinitionName, BC000O6_A129WWPNotificationCreated, BC000O6_A181WWPNotificationIcon, BC000O6_A182WWPNotificationTitle, BC000O6_A183WWPNotificationShortDescriptio, BC000O6_A184WWPNotificationLink, BC000O6_A187WWPNotificationIsRead, BC000O6_A113WWPUserExtendedFullName, BC000O6_A165WWPNotificationMetadata,
               BC000O6_n165WWPNotificationMetadata, BC000O6_A128WWPNotificationDefinitionId, BC000O6_A112WWPUserExtendedId, BC000O6_n112WWPUserExtendedId
               }
               , new Object[] {
               BC000O7_A127WWPNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000O9_A127WWPNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000O12_A164WWPNotificationDefinitionName
               }
               , new Object[] {
               BC000O13_A113WWPUserExtendedFullName
               }
               , new Object[] {
               BC000O14_A185WWPMailId
               }
               , new Object[] {
               BC000O15_A152WWPWebNotificationId
               }
               , new Object[] {
               BC000O16_A138WWPSMSId
               }
               , new Object[] {
               BC000O17_A127WWPNotificationId, BC000O17_A164WWPNotificationDefinitionName, BC000O17_A129WWPNotificationCreated, BC000O17_A181WWPNotificationIcon, BC000O17_A182WWPNotificationTitle, BC000O17_A183WWPNotificationShortDescriptio, BC000O17_A184WWPNotificationLink, BC000O17_A187WWPNotificationIsRead, BC000O17_A113WWPUserExtendedFullName, BC000O17_A165WWPNotificationMetadata,
               BC000O17_n165WWPNotificationMetadata, BC000O17_A128WWPNotificationDefinitionId, BC000O17_A112WWPUserExtendedId, BC000O17_n112WWPUserExtendedId
               }
            }
         );
         Z129WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A129WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i129WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound34 ;
      private int trnEnded ;
      private long Z127WWPNotificationId ;
      private long A127WWPNotificationId ;
      private long Z128WWPNotificationDefinitionId ;
      private long A128WWPNotificationDefinitionId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z112WWPUserExtendedId ;
      private string A112WWPUserExtendedId ;
      private string sMode34 ;
      private DateTime Z129WWPNotificationCreated ;
      private DateTime A129WWPNotificationCreated ;
      private DateTime i129WWPNotificationCreated ;
      private bool Z187WWPNotificationIsRead ;
      private bool A187WWPNotificationIsRead ;
      private bool n127WWPNotificationId ;
      private bool n165WWPNotificationMetadata ;
      private bool n112WWPUserExtendedId ;
      private bool Gx_longc ;
      private string Z165WWPNotificationMetadata ;
      private string A165WWPNotificationMetadata ;
      private string Z181WWPNotificationIcon ;
      private string A181WWPNotificationIcon ;
      private string Z182WWPNotificationTitle ;
      private string A182WWPNotificationTitle ;
      private string Z183WWPNotificationShortDescriptio ;
      private string A183WWPNotificationShortDescriptio ;
      private string Z184WWPNotificationLink ;
      private string A184WWPNotificationLink ;
      private string Z164WWPNotificationDefinitionName ;
      private string A164WWPNotificationDefinitionName ;
      private string Z113WWPUserExtendedFullName ;
      private string A113WWPUserExtendedFullName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC000O6_A127WWPNotificationId ;
      private bool[] BC000O6_n127WWPNotificationId ;
      private string[] BC000O6_A164WWPNotificationDefinitionName ;
      private DateTime[] BC000O6_A129WWPNotificationCreated ;
      private string[] BC000O6_A181WWPNotificationIcon ;
      private string[] BC000O6_A182WWPNotificationTitle ;
      private string[] BC000O6_A183WWPNotificationShortDescriptio ;
      private string[] BC000O6_A184WWPNotificationLink ;
      private bool[] BC000O6_A187WWPNotificationIsRead ;
      private string[] BC000O6_A113WWPUserExtendedFullName ;
      private string[] BC000O6_A165WWPNotificationMetadata ;
      private bool[] BC000O6_n165WWPNotificationMetadata ;
      private long[] BC000O6_A128WWPNotificationDefinitionId ;
      private string[] BC000O6_A112WWPUserExtendedId ;
      private bool[] BC000O6_n112WWPUserExtendedId ;
      private string[] BC000O4_A164WWPNotificationDefinitionName ;
      private string[] BC000O5_A113WWPUserExtendedFullName ;
      private long[] BC000O7_A127WWPNotificationId ;
      private bool[] BC000O7_n127WWPNotificationId ;
      private long[] BC000O3_A127WWPNotificationId ;
      private bool[] BC000O3_n127WWPNotificationId ;
      private DateTime[] BC000O3_A129WWPNotificationCreated ;
      private string[] BC000O3_A181WWPNotificationIcon ;
      private string[] BC000O3_A182WWPNotificationTitle ;
      private string[] BC000O3_A183WWPNotificationShortDescriptio ;
      private string[] BC000O3_A184WWPNotificationLink ;
      private bool[] BC000O3_A187WWPNotificationIsRead ;
      private string[] BC000O3_A165WWPNotificationMetadata ;
      private bool[] BC000O3_n165WWPNotificationMetadata ;
      private long[] BC000O3_A128WWPNotificationDefinitionId ;
      private string[] BC000O3_A112WWPUserExtendedId ;
      private bool[] BC000O3_n112WWPUserExtendedId ;
      private long[] BC000O2_A127WWPNotificationId ;
      private bool[] BC000O2_n127WWPNotificationId ;
      private DateTime[] BC000O2_A129WWPNotificationCreated ;
      private string[] BC000O2_A181WWPNotificationIcon ;
      private string[] BC000O2_A182WWPNotificationTitle ;
      private string[] BC000O2_A183WWPNotificationShortDescriptio ;
      private string[] BC000O2_A184WWPNotificationLink ;
      private bool[] BC000O2_A187WWPNotificationIsRead ;
      private string[] BC000O2_A165WWPNotificationMetadata ;
      private bool[] BC000O2_n165WWPNotificationMetadata ;
      private long[] BC000O2_A128WWPNotificationDefinitionId ;
      private string[] BC000O2_A112WWPUserExtendedId ;
      private bool[] BC000O2_n112WWPUserExtendedId ;
      private long[] BC000O9_A127WWPNotificationId ;
      private bool[] BC000O9_n127WWPNotificationId ;
      private string[] BC000O12_A164WWPNotificationDefinitionName ;
      private string[] BC000O13_A113WWPUserExtendedFullName ;
      private long[] BC000O14_A185WWPMailId ;
      private long[] BC000O15_A152WWPWebNotificationId ;
      private long[] BC000O16_A138WWPSMSId ;
      private long[] BC000O17_A127WWPNotificationId ;
      private bool[] BC000O17_n127WWPNotificationId ;
      private string[] BC000O17_A164WWPNotificationDefinitionName ;
      private DateTime[] BC000O17_A129WWPNotificationCreated ;
      private string[] BC000O17_A181WWPNotificationIcon ;
      private string[] BC000O17_A182WWPNotificationTitle ;
      private string[] BC000O17_A183WWPNotificationShortDescriptio ;
      private string[] BC000O17_A184WWPNotificationLink ;
      private bool[] BC000O17_A187WWPNotificationIsRead ;
      private string[] BC000O17_A113WWPUserExtendedFullName ;
      private string[] BC000O17_A165WWPNotificationMetadata ;
      private bool[] BC000O17_n165WWPNotificationMetadata ;
      private long[] BC000O17_A128WWPNotificationDefinitionId ;
      private string[] BC000O17_A112WWPUserExtendedId ;
      private bool[] BC000O17_n112WWPUserExtendedId ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification bcwwpbaseobjects_notifications_common_WWP_Notification ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_notification_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_notification_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_notification_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000O2;
       prmBC000O2 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmBC000O3;
       prmBC000O3 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmBC000O4;
       prmBC000O4 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmBC000O5;
       prmBC000O5 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmBC000O6;
       prmBC000O6 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmBC000O7;
       prmBC000O7 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmBC000O8;
       prmBC000O8 = new Object[] {
       new ParDef("WWPNotificationCreated",GXType.DateTime2,10,12) ,
       new ParDef("WWPNotificationIcon",GXType.VarChar,100,0) ,
       new ParDef("WWPNotificationTitle",GXType.VarChar,200,0) ,
       new ParDef("WWPNotificationShortDescriptio",GXType.VarChar,200,0) ,
       new ParDef("WWPNotificationLink",GXType.VarChar,1000,0) ,
       new ParDef("WWPNotificationIsRead",GXType.Boolean,4,0) ,
       new ParDef("WWPNotificationMetadata",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmBC000O9;
       prmBC000O9 = new Object[] {
       };
       Object[] prmBC000O10;
       prmBC000O10 = new Object[] {
       new ParDef("WWPNotificationCreated",GXType.DateTime2,10,12) ,
       new ParDef("WWPNotificationIcon",GXType.VarChar,100,0) ,
       new ParDef("WWPNotificationTitle",GXType.VarChar,200,0) ,
       new ParDef("WWPNotificationShortDescriptio",GXType.VarChar,200,0) ,
       new ParDef("WWPNotificationLink",GXType.VarChar,1000,0) ,
       new ParDef("WWPNotificationIsRead",GXType.Boolean,4,0) ,
       new ParDef("WWPNotificationMetadata",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmBC000O11;
       prmBC000O11 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmBC000O12;
       prmBC000O12 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmBC000O13;
       prmBC000O13 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmBC000O14;
       prmBC000O14 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmBC000O15;
       prmBC000O15 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmBC000O16;
       prmBC000O16 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmBC000O17;
       prmBC000O17 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       def= new CursorDef[] {
           new CursorDef("BC000O2", "SELECT WWPNotificationId, WWPNotificationCreated, WWPNotificationIcon, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationLink, WWPNotificationIsRead, WWPNotificationMetadata, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId  FOR UPDATE OF WWP_Notification",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000O3", "SELECT WWPNotificationId, WWPNotificationCreated, WWPNotificationIcon, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationLink, WWPNotificationIsRead, WWPNotificationMetadata, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000O4", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000O5", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000O6", "SELECT TM1.WWPNotificationId, T2.WWPNotificationDefinitionName, TM1.WWPNotificationCreated, TM1.WWPNotificationIcon, TM1.WWPNotificationTitle, TM1.WWPNotificationShortDescriptio, TM1.WWPNotificationLink, TM1.WWPNotificationIsRead, T3.WWPUserExtendedFullName, TM1.WWPNotificationMetadata, TM1.WWPNotificationDefinitionId, TM1.WWPUserExtendedId FROM ((WWP_Notification TM1 INNER JOIN WWP_NotificationDefinition T2 ON T2.WWPNotificationDefinitionId = TM1.WWPNotificationDefinitionId) LEFT JOIN WWP_UserExtended T3 ON T3.WWPUserExtendedId = TM1.WWPUserExtendedId) WHERE TM1.WWPNotificationId = :WWPNotificationId ORDER BY TM1.WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O6,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000O7", "SELECT WWPNotificationId FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000O8", "SAVEPOINT gxupdate;INSERT INTO WWP_Notification(WWPNotificationCreated, WWPNotificationIcon, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationLink, WWPNotificationIsRead, WWPNotificationMetadata, WWPNotificationDefinitionId, WWPUserExtendedId) VALUES(:WWPNotificationCreated, :WWPNotificationIcon, :WWPNotificationTitle, :WWPNotificationShortDescriptio, :WWPNotificationLink, :WWPNotificationIsRead, :WWPNotificationMetadata, :WWPNotificationDefinitionId, :WWPUserExtendedId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000O8)
          ,new CursorDef("BC000O9", "SELECT currval('WWPNotificationId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000O10", "SAVEPOINT gxupdate;UPDATE WWP_Notification SET WWPNotificationCreated=:WWPNotificationCreated, WWPNotificationIcon=:WWPNotificationIcon, WWPNotificationTitle=:WWPNotificationTitle, WWPNotificationShortDescriptio=:WWPNotificationShortDescriptio, WWPNotificationLink=:WWPNotificationLink, WWPNotificationIsRead=:WWPNotificationIsRead, WWPNotificationMetadata=:WWPNotificationMetadata, WWPNotificationDefinitionId=:WWPNotificationDefinitionId, WWPUserExtendedId=:WWPUserExtendedId  WHERE WWPNotificationId = :WWPNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000O10)
          ,new CursorDef("BC000O11", "SAVEPOINT gxupdate;DELETE FROM WWP_Notification  WHERE WWPNotificationId = :WWPNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000O11)
          ,new CursorDef("BC000O12", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O12,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000O13", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O13,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000O14", "SELECT WWPMailId FROM WWP_Mail WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O14,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000O15", "SELECT WWPWebNotificationId FROM WWP_WebNotification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O15,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000O16", "SELECT WWPSMSId FROM WWP_SMS WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O16,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000O17", "SELECT TM1.WWPNotificationId, T2.WWPNotificationDefinitionName, TM1.WWPNotificationCreated, TM1.WWPNotificationIcon, TM1.WWPNotificationTitle, TM1.WWPNotificationShortDescriptio, TM1.WWPNotificationLink, TM1.WWPNotificationIsRead, T3.WWPUserExtendedFullName, TM1.WWPNotificationMetadata, TM1.WWPNotificationDefinitionId, TM1.WWPUserExtendedId FROM ((WWP_Notification TM1 INNER JOIN WWP_NotificationDefinition T2 ON T2.WWPNotificationDefinitionId = TM1.WWPNotificationDefinitionId) LEFT JOIN WWP_UserExtended T3 ON T3.WWPUserExtendedId = TM1.WWPUserExtendedId) WHERE TM1.WWPNotificationId = :WWPNotificationId ORDER BY TM1.WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000O17,100, GxCacheFrequency.OFF ,true,false )
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
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
             ((bool[]) buf[8])[0] = rslt.wasNull(8);
             ((long[]) buf[9])[0] = rslt.getLong(9);
             ((string[]) buf[10])[0] = rslt.getString(10, 40);
             ((bool[]) buf[11])[0] = rslt.wasNull(10);
             return;
          case 1 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
             ((bool[]) buf[8])[0] = rslt.wasNull(8);
             ((long[]) buf[9])[0] = rslt.getLong(9);
             ((string[]) buf[10])[0] = rslt.getString(10, 40);
             ((bool[]) buf[11])[0] = rslt.wasNull(10);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 4 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
             ((bool[]) buf[10])[0] = rslt.wasNull(10);
             ((long[]) buf[11])[0] = rslt.getLong(11);
             ((string[]) buf[12])[0] = rslt.getString(12, 40);
             ((bool[]) buf[13])[0] = rslt.wasNull(12);
             return;
          case 5 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 7 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 10 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 11 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 12 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 13 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 14 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 15 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
             ((bool[]) buf[10])[0] = rslt.wasNull(10);
             ((long[]) buf[11])[0] = rslt.getLong(11);
             ((string[]) buf[12])[0] = rslt.getString(12, 40);
             ((bool[]) buf[13])[0] = rslt.wasNull(12);
             return;
    }
 }

}

}
