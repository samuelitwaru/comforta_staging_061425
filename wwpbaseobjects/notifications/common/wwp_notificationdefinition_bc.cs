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
   public class wwp_notificationdefinition_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_notificationdefinition_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_notificationdefinition_bc( IGxContext context )
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
         ReadRow0N33( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0N33( ) ;
         standaloneModal( ) ;
         AddRow0N33( ) ;
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
               Z128WWPNotificationDefinitionId = A128WWPNotificationDefinitionId;
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

      protected void CONFIRM_0N0( )
      {
         BeforeValidate0N33( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0N33( ) ;
            }
            else
            {
               CheckExtendedTable0N33( ) ;
               if ( AnyError == 0 )
               {
                  ZM0N33( 5) ;
               }
               CloseExtendedTableCursors0N33( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0N33( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z164WWPNotificationDefinitionName = A164WWPNotificationDefinitionName;
            Z135WWPNotificationDefinitionAppli = A135WWPNotificationDefinitionAppli;
            Z136WWPNotificationDefinitionAllow = A136WWPNotificationDefinitionAllow;
            Z134WWPNotificationDefinitionDescr = A134WWPNotificationDefinitionDescr;
            Z167WWPNotificationDefinitionIcon = A167WWPNotificationDefinitionIcon;
            Z168WWPNotificationDefinitionTitle = A168WWPNotificationDefinitionTitle;
            Z169WWPNotificationDefinitionShort = A169WWPNotificationDefinitionShort;
            Z170WWPNotificationDefinitionLongD = A170WWPNotificationDefinitionLongD;
            Z171WWPNotificationDefinitionLink = A171WWPNotificationDefinitionLink;
            Z172WWPNotificationDefinitionSecFu = A172WWPNotificationDefinitionSecFu;
            Z125WWPEntityId = A125WWPEntityId;
            Z173WWPNotificationDefinitionIsAut = A173WWPNotificationDefinitionIsAut;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z126WWPEntityName = A126WWPEntityName;
            Z173WWPNotificationDefinitionIsAut = A173WWPNotificationDefinitionIsAut;
         }
         if ( GX_JID == -4 )
         {
            Z128WWPNotificationDefinitionId = A128WWPNotificationDefinitionId;
            Z164WWPNotificationDefinitionName = A164WWPNotificationDefinitionName;
            Z135WWPNotificationDefinitionAppli = A135WWPNotificationDefinitionAppli;
            Z136WWPNotificationDefinitionAllow = A136WWPNotificationDefinitionAllow;
            Z134WWPNotificationDefinitionDescr = A134WWPNotificationDefinitionDescr;
            Z167WWPNotificationDefinitionIcon = A167WWPNotificationDefinitionIcon;
            Z168WWPNotificationDefinitionTitle = A168WWPNotificationDefinitionTitle;
            Z169WWPNotificationDefinitionShort = A169WWPNotificationDefinitionShort;
            Z170WWPNotificationDefinitionLongD = A170WWPNotificationDefinitionLongD;
            Z171WWPNotificationDefinitionLink = A171WWPNotificationDefinitionLink;
            Z172WWPNotificationDefinitionSecFu = A172WWPNotificationDefinitionSecFu;
            Z125WWPEntityId = A125WWPEntityId;
            Z126WWPEntityName = A126WWPEntityName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0N33( )
      {
         /* Using cursor BC000N5 */
         pr_default.execute(3, new Object[] {A128WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound33 = 1;
            A164WWPNotificationDefinitionName = BC000N5_A164WWPNotificationDefinitionName[0];
            A135WWPNotificationDefinitionAppli = BC000N5_A135WWPNotificationDefinitionAppli[0];
            A136WWPNotificationDefinitionAllow = BC000N5_A136WWPNotificationDefinitionAllow[0];
            A134WWPNotificationDefinitionDescr = BC000N5_A134WWPNotificationDefinitionDescr[0];
            A167WWPNotificationDefinitionIcon = BC000N5_A167WWPNotificationDefinitionIcon[0];
            A168WWPNotificationDefinitionTitle = BC000N5_A168WWPNotificationDefinitionTitle[0];
            A169WWPNotificationDefinitionShort = BC000N5_A169WWPNotificationDefinitionShort[0];
            A170WWPNotificationDefinitionLongD = BC000N5_A170WWPNotificationDefinitionLongD[0];
            A171WWPNotificationDefinitionLink = BC000N5_A171WWPNotificationDefinitionLink[0];
            A126WWPEntityName = BC000N5_A126WWPEntityName[0];
            A172WWPNotificationDefinitionSecFu = BC000N5_A172WWPNotificationDefinitionSecFu[0];
            A125WWPEntityId = BC000N5_A125WWPEntityId[0];
            ZM0N33( -4) ;
         }
         pr_default.close(3);
         OnLoadActions0N33( ) ;
      }

      protected void OnLoadActions0N33( )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A172WWPNotificationDefinitionSecFu)) )
         {
            A173WWPNotificationDefinitionIsAut = true;
         }
         else
         {
            GXt_boolean1 = A173WWPNotificationDefinitionIsAut;
            new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  A172WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
            A173WWPNotificationDefinitionIsAut = GXt_boolean1;
         }
      }

      protected void CheckExtendedTable0N33( )
      {
         standaloneModal( ) ;
         if ( ! ( ( A135WWPNotificationDefinitionAppli == 1 ) || ( A135WWPNotificationDefinitionAppli == 2 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Notification Definition Applies To", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A171WWPNotificationDefinitionLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Notification Definition Default Link", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000N4 */
         pr_default.execute(2, new Object[] {A125WWPEntityId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A126WWPEntityName = BC000N4_A126WWPEntityName[0];
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A172WWPNotificationDefinitionSecFu)) )
         {
            A173WWPNotificationDefinitionIsAut = true;
         }
         else
         {
            GXt_boolean1 = A173WWPNotificationDefinitionIsAut;
            new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  A172WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
            A173WWPNotificationDefinitionIsAut = GXt_boolean1;
         }
      }

      protected void CloseExtendedTableCursors0N33( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0N33( )
      {
         /* Using cursor BC000N6 */
         pr_default.execute(4, new Object[] {A128WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound33 = 1;
         }
         else
         {
            RcdFound33 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000N3 */
         pr_default.execute(1, new Object[] {A128WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0N33( 4) ;
            RcdFound33 = 1;
            A128WWPNotificationDefinitionId = BC000N3_A128WWPNotificationDefinitionId[0];
            A164WWPNotificationDefinitionName = BC000N3_A164WWPNotificationDefinitionName[0];
            A135WWPNotificationDefinitionAppli = BC000N3_A135WWPNotificationDefinitionAppli[0];
            A136WWPNotificationDefinitionAllow = BC000N3_A136WWPNotificationDefinitionAllow[0];
            A134WWPNotificationDefinitionDescr = BC000N3_A134WWPNotificationDefinitionDescr[0];
            A167WWPNotificationDefinitionIcon = BC000N3_A167WWPNotificationDefinitionIcon[0];
            A168WWPNotificationDefinitionTitle = BC000N3_A168WWPNotificationDefinitionTitle[0];
            A169WWPNotificationDefinitionShort = BC000N3_A169WWPNotificationDefinitionShort[0];
            A170WWPNotificationDefinitionLongD = BC000N3_A170WWPNotificationDefinitionLongD[0];
            A171WWPNotificationDefinitionLink = BC000N3_A171WWPNotificationDefinitionLink[0];
            A172WWPNotificationDefinitionSecFu = BC000N3_A172WWPNotificationDefinitionSecFu[0];
            A125WWPEntityId = BC000N3_A125WWPEntityId[0];
            Z128WWPNotificationDefinitionId = A128WWPNotificationDefinitionId;
            sMode33 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0N33( ) ;
            if ( AnyError == 1 )
            {
               RcdFound33 = 0;
               InitializeNonKey0N33( ) ;
            }
            Gx_mode = sMode33;
         }
         else
         {
            RcdFound33 = 0;
            InitializeNonKey0N33( ) ;
            sMode33 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode33;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0N33( ) ;
         if ( RcdFound33 == 0 )
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
         CONFIRM_0N0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0N33( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000N2 */
            pr_default.execute(0, new Object[] {A128WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_NotificationDefinition"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z164WWPNotificationDefinitionName, BC000N2_A164WWPNotificationDefinitionName[0]) != 0 ) || ( Z135WWPNotificationDefinitionAppli != BC000N2_A135WWPNotificationDefinitionAppli[0] ) || ( Z136WWPNotificationDefinitionAllow != BC000N2_A136WWPNotificationDefinitionAllow[0] ) || ( StringUtil.StrCmp(Z134WWPNotificationDefinitionDescr, BC000N2_A134WWPNotificationDefinitionDescr[0]) != 0 ) || ( StringUtil.StrCmp(Z167WWPNotificationDefinitionIcon, BC000N2_A167WWPNotificationDefinitionIcon[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z168WWPNotificationDefinitionTitle, BC000N2_A168WWPNotificationDefinitionTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z169WWPNotificationDefinitionShort, BC000N2_A169WWPNotificationDefinitionShort[0]) != 0 ) || ( StringUtil.StrCmp(Z170WWPNotificationDefinitionLongD, BC000N2_A170WWPNotificationDefinitionLongD[0]) != 0 ) || ( StringUtil.StrCmp(Z171WWPNotificationDefinitionLink, BC000N2_A171WWPNotificationDefinitionLink[0]) != 0 ) || ( StringUtil.StrCmp(Z172WWPNotificationDefinitionSecFu, BC000N2_A172WWPNotificationDefinitionSecFu[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z125WWPEntityId != BC000N2_A125WWPEntityId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_NotificationDefinition"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0N33( )
      {
         BeforeValidate0N33( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N33( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0N33( 0) ;
            CheckOptimisticConcurrency0N33( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N33( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0N33( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000N7 */
                     pr_default.execute(5, new Object[] {A164WWPNotificationDefinitionName, A135WWPNotificationDefinitionAppli, A136WWPNotificationDefinitionAllow, A134WWPNotificationDefinitionDescr, A167WWPNotificationDefinitionIcon, A168WWPNotificationDefinitionTitle, A169WWPNotificationDefinitionShort, A170WWPNotificationDefinitionLongD, A171WWPNotificationDefinitionLink, A172WWPNotificationDefinitionSecFu, A125WWPEntityId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000N8 */
                     pr_default.execute(6);
                     A128WWPNotificationDefinitionId = BC000N8_A128WWPNotificationDefinitionId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
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
               Load0N33( ) ;
            }
            EndLevel0N33( ) ;
         }
         CloseExtendedTableCursors0N33( ) ;
      }

      protected void Update0N33( )
      {
         BeforeValidate0N33( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N33( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N33( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N33( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0N33( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000N9 */
                     pr_default.execute(7, new Object[] {A164WWPNotificationDefinitionName, A135WWPNotificationDefinitionAppli, A136WWPNotificationDefinitionAllow, A134WWPNotificationDefinitionDescr, A167WWPNotificationDefinitionIcon, A168WWPNotificationDefinitionTitle, A169WWPNotificationDefinitionShort, A170WWPNotificationDefinitionLongD, A171WWPNotificationDefinitionLink, A172WWPNotificationDefinitionSecFu, A125WWPEntityId, A128WWPNotificationDefinitionId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_NotificationDefinition"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0N33( ) ;
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
            EndLevel0N33( ) ;
         }
         CloseExtendedTableCursors0N33( ) ;
      }

      protected void DeferredUpdate0N33( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0N33( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N33( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0N33( ) ;
            AfterConfirm0N33( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0N33( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000N10 */
                  pr_default.execute(8, new Object[] {A128WWPNotificationDefinitionId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
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
         sMode33 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0N33( ) ;
         Gx_mode = sMode33;
      }

      protected void OnDeleteControls0N33( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000N11 */
            pr_default.execute(9, new Object[] {A125WWPEntityId});
            A126WWPEntityName = BC000N11_A126WWPEntityName[0];
            pr_default.close(9);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A172WWPNotificationDefinitionSecFu)) )
            {
               A173WWPNotificationDefinitionIsAut = true;
            }
            else
            {
               GXt_boolean1 = A173WWPNotificationDefinitionIsAut;
               new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  A172WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
               A173WWPNotificationDefinitionIsAut = GXt_boolean1;
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000N12 */
            pr_default.execute(10, new Object[] {A128WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_Notification", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC000N13 */
            pr_default.execute(11, new Object[] {A128WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_Subscription", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel0N33( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0N33( ) ;
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

      public void ScanKeyStart0N33( )
      {
         /* Using cursor BC000N14 */
         pr_default.execute(12, new Object[] {A128WWPNotificationDefinitionId});
         RcdFound33 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound33 = 1;
            A128WWPNotificationDefinitionId = BC000N14_A128WWPNotificationDefinitionId[0];
            A164WWPNotificationDefinitionName = BC000N14_A164WWPNotificationDefinitionName[0];
            A135WWPNotificationDefinitionAppli = BC000N14_A135WWPNotificationDefinitionAppli[0];
            A136WWPNotificationDefinitionAllow = BC000N14_A136WWPNotificationDefinitionAllow[0];
            A134WWPNotificationDefinitionDescr = BC000N14_A134WWPNotificationDefinitionDescr[0];
            A167WWPNotificationDefinitionIcon = BC000N14_A167WWPNotificationDefinitionIcon[0];
            A168WWPNotificationDefinitionTitle = BC000N14_A168WWPNotificationDefinitionTitle[0];
            A169WWPNotificationDefinitionShort = BC000N14_A169WWPNotificationDefinitionShort[0];
            A170WWPNotificationDefinitionLongD = BC000N14_A170WWPNotificationDefinitionLongD[0];
            A171WWPNotificationDefinitionLink = BC000N14_A171WWPNotificationDefinitionLink[0];
            A126WWPEntityName = BC000N14_A126WWPEntityName[0];
            A172WWPNotificationDefinitionSecFu = BC000N14_A172WWPNotificationDefinitionSecFu[0];
            A125WWPEntityId = BC000N14_A125WWPEntityId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0N33( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound33 = 0;
         ScanKeyLoad0N33( ) ;
      }

      protected void ScanKeyLoad0N33( )
      {
         sMode33 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound33 = 1;
            A128WWPNotificationDefinitionId = BC000N14_A128WWPNotificationDefinitionId[0];
            A164WWPNotificationDefinitionName = BC000N14_A164WWPNotificationDefinitionName[0];
            A135WWPNotificationDefinitionAppli = BC000N14_A135WWPNotificationDefinitionAppli[0];
            A136WWPNotificationDefinitionAllow = BC000N14_A136WWPNotificationDefinitionAllow[0];
            A134WWPNotificationDefinitionDescr = BC000N14_A134WWPNotificationDefinitionDescr[0];
            A167WWPNotificationDefinitionIcon = BC000N14_A167WWPNotificationDefinitionIcon[0];
            A168WWPNotificationDefinitionTitle = BC000N14_A168WWPNotificationDefinitionTitle[0];
            A169WWPNotificationDefinitionShort = BC000N14_A169WWPNotificationDefinitionShort[0];
            A170WWPNotificationDefinitionLongD = BC000N14_A170WWPNotificationDefinitionLongD[0];
            A171WWPNotificationDefinitionLink = BC000N14_A171WWPNotificationDefinitionLink[0];
            A126WWPEntityName = BC000N14_A126WWPEntityName[0];
            A172WWPNotificationDefinitionSecFu = BC000N14_A172WWPNotificationDefinitionSecFu[0];
            A125WWPEntityId = BC000N14_A125WWPEntityId[0];
         }
         Gx_mode = sMode33;
      }

      protected void ScanKeyEnd0N33( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0N33( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0N33( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0N33( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0N33( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0N33( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0N33( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0N33( )
      {
      }

      protected void send_integrity_lvl_hashes0N33( )
      {
      }

      protected void AddRow0N33( )
      {
         VarsToRow33( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
      }

      protected void ReadRow0N33( )
      {
         RowToVars33( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
      }

      protected void InitializeNonKey0N33( )
      {
         A173WWPNotificationDefinitionIsAut = false;
         A164WWPNotificationDefinitionName = "";
         A135WWPNotificationDefinitionAppli = 0;
         A136WWPNotificationDefinitionAllow = false;
         A134WWPNotificationDefinitionDescr = "";
         A167WWPNotificationDefinitionIcon = "";
         A168WWPNotificationDefinitionTitle = "";
         A169WWPNotificationDefinitionShort = "";
         A170WWPNotificationDefinitionLongD = "";
         A171WWPNotificationDefinitionLink = "";
         A125WWPEntityId = 0;
         A126WWPEntityName = "";
         A172WWPNotificationDefinitionSecFu = "";
         Z164WWPNotificationDefinitionName = "";
         Z135WWPNotificationDefinitionAppli = 0;
         Z136WWPNotificationDefinitionAllow = false;
         Z134WWPNotificationDefinitionDescr = "";
         Z167WWPNotificationDefinitionIcon = "";
         Z168WWPNotificationDefinitionTitle = "";
         Z169WWPNotificationDefinitionShort = "";
         Z170WWPNotificationDefinitionLongD = "";
         Z171WWPNotificationDefinitionLink = "";
         Z172WWPNotificationDefinitionSecFu = "";
         Z125WWPEntityId = 0;
      }

      protected void InitAll0N33( )
      {
         A128WWPNotificationDefinitionId = 0;
         InitializeNonKey0N33( ) ;
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

      public void VarsToRow33( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition obj33 )
      {
         obj33.gxTpr_Mode = Gx_mode;
         obj33.gxTpr_Wwpnotificationdefinitionisauthorized = A173WWPNotificationDefinitionIsAut;
         obj33.gxTpr_Wwpnotificationdefinitionname = A164WWPNotificationDefinitionName;
         obj33.gxTpr_Wwpnotificationdefinitionappliesto = A135WWPNotificationDefinitionAppli;
         obj33.gxTpr_Wwpnotificationdefinitionallowusersubscription = A136WWPNotificationDefinitionAllow;
         obj33.gxTpr_Wwpnotificationdefinitiondescription = A134WWPNotificationDefinitionDescr;
         obj33.gxTpr_Wwpnotificationdefinitionicon = A167WWPNotificationDefinitionIcon;
         obj33.gxTpr_Wwpnotificationdefinitiontitle = A168WWPNotificationDefinitionTitle;
         obj33.gxTpr_Wwpnotificationdefinitionshortdescription = A169WWPNotificationDefinitionShort;
         obj33.gxTpr_Wwpnotificationdefinitionlongdescription = A170WWPNotificationDefinitionLongD;
         obj33.gxTpr_Wwpnotificationdefinitionlink = A171WWPNotificationDefinitionLink;
         obj33.gxTpr_Wwpentityid = A125WWPEntityId;
         obj33.gxTpr_Wwpentityname = A126WWPEntityName;
         obj33.gxTpr_Wwpnotificationdefinitionsecfuncionality = A172WWPNotificationDefinitionSecFu;
         obj33.gxTpr_Wwpnotificationdefinitionid = A128WWPNotificationDefinitionId;
         obj33.gxTpr_Wwpnotificationdefinitionid_Z = Z128WWPNotificationDefinitionId;
         obj33.gxTpr_Wwpnotificationdefinitionname_Z = Z164WWPNotificationDefinitionName;
         obj33.gxTpr_Wwpnotificationdefinitionappliesto_Z = Z135WWPNotificationDefinitionAppli;
         obj33.gxTpr_Wwpnotificationdefinitionallowusersubscription_Z = Z136WWPNotificationDefinitionAllow;
         obj33.gxTpr_Wwpnotificationdefinitiondescription_Z = Z134WWPNotificationDefinitionDescr;
         obj33.gxTpr_Wwpnotificationdefinitionicon_Z = Z167WWPNotificationDefinitionIcon;
         obj33.gxTpr_Wwpnotificationdefinitiontitle_Z = Z168WWPNotificationDefinitionTitle;
         obj33.gxTpr_Wwpnotificationdefinitionshortdescription_Z = Z169WWPNotificationDefinitionShort;
         obj33.gxTpr_Wwpnotificationdefinitionlongdescription_Z = Z170WWPNotificationDefinitionLongD;
         obj33.gxTpr_Wwpnotificationdefinitionlink_Z = Z171WWPNotificationDefinitionLink;
         obj33.gxTpr_Wwpentityid_Z = Z125WWPEntityId;
         obj33.gxTpr_Wwpentityname_Z = Z126WWPEntityName;
         obj33.gxTpr_Wwpnotificationdefinitionsecfuncionality_Z = Z172WWPNotificationDefinitionSecFu;
         obj33.gxTpr_Wwpnotificationdefinitionisauthorized_Z = Z173WWPNotificationDefinitionIsAut;
         obj33.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow33( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition obj33 )
      {
         obj33.gxTpr_Wwpnotificationdefinitionid = A128WWPNotificationDefinitionId;
         return  ;
      }

      public void RowToVars33( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition obj33 ,
                               int forceLoad )
      {
         Gx_mode = obj33.gxTpr_Mode;
         A173WWPNotificationDefinitionIsAut = obj33.gxTpr_Wwpnotificationdefinitionisauthorized;
         A164WWPNotificationDefinitionName = obj33.gxTpr_Wwpnotificationdefinitionname;
         A135WWPNotificationDefinitionAppli = obj33.gxTpr_Wwpnotificationdefinitionappliesto;
         A136WWPNotificationDefinitionAllow = obj33.gxTpr_Wwpnotificationdefinitionallowusersubscription;
         A134WWPNotificationDefinitionDescr = obj33.gxTpr_Wwpnotificationdefinitiondescription;
         A167WWPNotificationDefinitionIcon = obj33.gxTpr_Wwpnotificationdefinitionicon;
         A168WWPNotificationDefinitionTitle = obj33.gxTpr_Wwpnotificationdefinitiontitle;
         A169WWPNotificationDefinitionShort = obj33.gxTpr_Wwpnotificationdefinitionshortdescription;
         A170WWPNotificationDefinitionLongD = obj33.gxTpr_Wwpnotificationdefinitionlongdescription;
         A171WWPNotificationDefinitionLink = obj33.gxTpr_Wwpnotificationdefinitionlink;
         A125WWPEntityId = obj33.gxTpr_Wwpentityid;
         A126WWPEntityName = obj33.gxTpr_Wwpentityname;
         A172WWPNotificationDefinitionSecFu = obj33.gxTpr_Wwpnotificationdefinitionsecfuncionality;
         A128WWPNotificationDefinitionId = obj33.gxTpr_Wwpnotificationdefinitionid;
         Z128WWPNotificationDefinitionId = obj33.gxTpr_Wwpnotificationdefinitionid_Z;
         Z164WWPNotificationDefinitionName = obj33.gxTpr_Wwpnotificationdefinitionname_Z;
         Z135WWPNotificationDefinitionAppli = obj33.gxTpr_Wwpnotificationdefinitionappliesto_Z;
         Z136WWPNotificationDefinitionAllow = obj33.gxTpr_Wwpnotificationdefinitionallowusersubscription_Z;
         Z134WWPNotificationDefinitionDescr = obj33.gxTpr_Wwpnotificationdefinitiondescription_Z;
         Z167WWPNotificationDefinitionIcon = obj33.gxTpr_Wwpnotificationdefinitionicon_Z;
         Z168WWPNotificationDefinitionTitle = obj33.gxTpr_Wwpnotificationdefinitiontitle_Z;
         Z169WWPNotificationDefinitionShort = obj33.gxTpr_Wwpnotificationdefinitionshortdescription_Z;
         Z170WWPNotificationDefinitionLongD = obj33.gxTpr_Wwpnotificationdefinitionlongdescription_Z;
         Z171WWPNotificationDefinitionLink = obj33.gxTpr_Wwpnotificationdefinitionlink_Z;
         Z125WWPEntityId = obj33.gxTpr_Wwpentityid_Z;
         Z126WWPEntityName = obj33.gxTpr_Wwpentityname_Z;
         Z172WWPNotificationDefinitionSecFu = obj33.gxTpr_Wwpnotificationdefinitionsecfuncionality_Z;
         Z173WWPNotificationDefinitionIsAut = obj33.gxTpr_Wwpnotificationdefinitionisauthorized_Z;
         Gx_mode = obj33.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A128WWPNotificationDefinitionId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0N33( ) ;
         ScanKeyStart0N33( ) ;
         if ( RcdFound33 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z128WWPNotificationDefinitionId = A128WWPNotificationDefinitionId;
         }
         ZM0N33( -4) ;
         OnLoadActions0N33( ) ;
         AddRow0N33( ) ;
         ScanKeyEnd0N33( ) ;
         if ( RcdFound33 == 0 )
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
         RowToVars33( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 0) ;
         ScanKeyStart0N33( ) ;
         if ( RcdFound33 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z128WWPNotificationDefinitionId = A128WWPNotificationDefinitionId;
         }
         ZM0N33( -4) ;
         OnLoadActions0N33( ) ;
         AddRow0N33( ) ;
         ScanKeyEnd0N33( ) ;
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0N33( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0N33( ) ;
         }
         else
         {
            if ( RcdFound33 == 1 )
            {
               if ( A128WWPNotificationDefinitionId != Z128WWPNotificationDefinitionId )
               {
                  A128WWPNotificationDefinitionId = Z128WWPNotificationDefinitionId;
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
                  Update0N33( ) ;
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
                  if ( A128WWPNotificationDefinitionId != Z128WWPNotificationDefinitionId )
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
                        Insert0N33( ) ;
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
                        Insert0N33( ) ;
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
         RowToVars33( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
         SaveImpl( ) ;
         VarsToRow33( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars33( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0N33( ) ;
         AfterTrn( ) ;
         VarsToRow33( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow33( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition auxBC = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A128WWPNotificationDefinitionId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition);
               auxBC.Save();
               bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars33( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
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
         RowToVars33( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0N33( ) ;
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
               VarsToRow33( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow33( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
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
         RowToVars33( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 0) ;
         GetKey0N33( ) ;
         if ( RcdFound33 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A128WWPNotificationDefinitionId != Z128WWPNotificationDefinitionId )
            {
               A128WWPNotificationDefinitionId = Z128WWPNotificationDefinitionId;
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
            if ( A128WWPNotificationDefinitionId != Z128WWPNotificationDefinitionId )
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
         context.RollbackDataStores("wwpbaseobjects.notifications.common.wwp_notificationdefinition_bc",pr_default);
         VarsToRow33( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
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
         Gx_mode = bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition )
         {
            bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition = (GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow33( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
            }
            else
            {
               RowToVars33( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars33( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_NotificationDefinition WWP_NotificationDefinition_BC
      {
         get {
            return bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition ;
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
            return "wwpnotificationdefinition_Execute" ;
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
         pr_default.close(9);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z164WWPNotificationDefinitionName = "";
         A164WWPNotificationDefinitionName = "";
         Z134WWPNotificationDefinitionDescr = "";
         A134WWPNotificationDefinitionDescr = "";
         Z167WWPNotificationDefinitionIcon = "";
         A167WWPNotificationDefinitionIcon = "";
         Z168WWPNotificationDefinitionTitle = "";
         A168WWPNotificationDefinitionTitle = "";
         Z169WWPNotificationDefinitionShort = "";
         A169WWPNotificationDefinitionShort = "";
         Z170WWPNotificationDefinitionLongD = "";
         A170WWPNotificationDefinitionLongD = "";
         Z171WWPNotificationDefinitionLink = "";
         A171WWPNotificationDefinitionLink = "";
         Z172WWPNotificationDefinitionSecFu = "";
         A172WWPNotificationDefinitionSecFu = "";
         Z126WWPEntityName = "";
         A126WWPEntityName = "";
         BC000N5_A128WWPNotificationDefinitionId = new long[1] ;
         BC000N5_A164WWPNotificationDefinitionName = new string[] {""} ;
         BC000N5_A135WWPNotificationDefinitionAppli = new short[1] ;
         BC000N5_A136WWPNotificationDefinitionAllow = new bool[] {false} ;
         BC000N5_A134WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000N5_A167WWPNotificationDefinitionIcon = new string[] {""} ;
         BC000N5_A168WWPNotificationDefinitionTitle = new string[] {""} ;
         BC000N5_A169WWPNotificationDefinitionShort = new string[] {""} ;
         BC000N5_A170WWPNotificationDefinitionLongD = new string[] {""} ;
         BC000N5_A171WWPNotificationDefinitionLink = new string[] {""} ;
         BC000N5_A126WWPEntityName = new string[] {""} ;
         BC000N5_A172WWPNotificationDefinitionSecFu = new string[] {""} ;
         BC000N5_A125WWPEntityId = new long[1] ;
         BC000N4_A126WWPEntityName = new string[] {""} ;
         BC000N6_A128WWPNotificationDefinitionId = new long[1] ;
         BC000N3_A128WWPNotificationDefinitionId = new long[1] ;
         BC000N3_A164WWPNotificationDefinitionName = new string[] {""} ;
         BC000N3_A135WWPNotificationDefinitionAppli = new short[1] ;
         BC000N3_A136WWPNotificationDefinitionAllow = new bool[] {false} ;
         BC000N3_A134WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000N3_A167WWPNotificationDefinitionIcon = new string[] {""} ;
         BC000N3_A168WWPNotificationDefinitionTitle = new string[] {""} ;
         BC000N3_A169WWPNotificationDefinitionShort = new string[] {""} ;
         BC000N3_A170WWPNotificationDefinitionLongD = new string[] {""} ;
         BC000N3_A171WWPNotificationDefinitionLink = new string[] {""} ;
         BC000N3_A172WWPNotificationDefinitionSecFu = new string[] {""} ;
         BC000N3_A125WWPEntityId = new long[1] ;
         sMode33 = "";
         BC000N2_A128WWPNotificationDefinitionId = new long[1] ;
         BC000N2_A164WWPNotificationDefinitionName = new string[] {""} ;
         BC000N2_A135WWPNotificationDefinitionAppli = new short[1] ;
         BC000N2_A136WWPNotificationDefinitionAllow = new bool[] {false} ;
         BC000N2_A134WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000N2_A167WWPNotificationDefinitionIcon = new string[] {""} ;
         BC000N2_A168WWPNotificationDefinitionTitle = new string[] {""} ;
         BC000N2_A169WWPNotificationDefinitionShort = new string[] {""} ;
         BC000N2_A170WWPNotificationDefinitionLongD = new string[] {""} ;
         BC000N2_A171WWPNotificationDefinitionLink = new string[] {""} ;
         BC000N2_A172WWPNotificationDefinitionSecFu = new string[] {""} ;
         BC000N2_A125WWPEntityId = new long[1] ;
         BC000N8_A128WWPNotificationDefinitionId = new long[1] ;
         BC000N11_A126WWPEntityName = new string[] {""} ;
         BC000N12_A127WWPNotificationId = new long[1] ;
         BC000N13_A130WWPSubscriptionId = new long[1] ;
         BC000N14_A128WWPNotificationDefinitionId = new long[1] ;
         BC000N14_A164WWPNotificationDefinitionName = new string[] {""} ;
         BC000N14_A135WWPNotificationDefinitionAppli = new short[1] ;
         BC000N14_A136WWPNotificationDefinitionAllow = new bool[] {false} ;
         BC000N14_A134WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000N14_A167WWPNotificationDefinitionIcon = new string[] {""} ;
         BC000N14_A168WWPNotificationDefinitionTitle = new string[] {""} ;
         BC000N14_A169WWPNotificationDefinitionShort = new string[] {""} ;
         BC000N14_A170WWPNotificationDefinitionLongD = new string[] {""} ;
         BC000N14_A171WWPNotificationDefinitionLink = new string[] {""} ;
         BC000N14_A126WWPEntityName = new string[] {""} ;
         BC000N14_A172WWPNotificationDefinitionSecFu = new string[] {""} ;
         BC000N14_A125WWPEntityId = new long[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notificationdefinition_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notificationdefinition_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notificationdefinition_bc__default(),
            new Object[][] {
                new Object[] {
               BC000N2_A128WWPNotificationDefinitionId, BC000N2_A164WWPNotificationDefinitionName, BC000N2_A135WWPNotificationDefinitionAppli, BC000N2_A136WWPNotificationDefinitionAllow, BC000N2_A134WWPNotificationDefinitionDescr, BC000N2_A167WWPNotificationDefinitionIcon, BC000N2_A168WWPNotificationDefinitionTitle, BC000N2_A169WWPNotificationDefinitionShort, BC000N2_A170WWPNotificationDefinitionLongD, BC000N2_A171WWPNotificationDefinitionLink,
               BC000N2_A172WWPNotificationDefinitionSecFu, BC000N2_A125WWPEntityId
               }
               , new Object[] {
               BC000N3_A128WWPNotificationDefinitionId, BC000N3_A164WWPNotificationDefinitionName, BC000N3_A135WWPNotificationDefinitionAppli, BC000N3_A136WWPNotificationDefinitionAllow, BC000N3_A134WWPNotificationDefinitionDescr, BC000N3_A167WWPNotificationDefinitionIcon, BC000N3_A168WWPNotificationDefinitionTitle, BC000N3_A169WWPNotificationDefinitionShort, BC000N3_A170WWPNotificationDefinitionLongD, BC000N3_A171WWPNotificationDefinitionLink,
               BC000N3_A172WWPNotificationDefinitionSecFu, BC000N3_A125WWPEntityId
               }
               , new Object[] {
               BC000N4_A126WWPEntityName
               }
               , new Object[] {
               BC000N5_A128WWPNotificationDefinitionId, BC000N5_A164WWPNotificationDefinitionName, BC000N5_A135WWPNotificationDefinitionAppli, BC000N5_A136WWPNotificationDefinitionAllow, BC000N5_A134WWPNotificationDefinitionDescr, BC000N5_A167WWPNotificationDefinitionIcon, BC000N5_A168WWPNotificationDefinitionTitle, BC000N5_A169WWPNotificationDefinitionShort, BC000N5_A170WWPNotificationDefinitionLongD, BC000N5_A171WWPNotificationDefinitionLink,
               BC000N5_A126WWPEntityName, BC000N5_A172WWPNotificationDefinitionSecFu, BC000N5_A125WWPEntityId
               }
               , new Object[] {
               BC000N6_A128WWPNotificationDefinitionId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000N8_A128WWPNotificationDefinitionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000N11_A126WWPEntityName
               }
               , new Object[] {
               BC000N12_A127WWPNotificationId
               }
               , new Object[] {
               BC000N13_A130WWPSubscriptionId
               }
               , new Object[] {
               BC000N14_A128WWPNotificationDefinitionId, BC000N14_A164WWPNotificationDefinitionName, BC000N14_A135WWPNotificationDefinitionAppli, BC000N14_A136WWPNotificationDefinitionAllow, BC000N14_A134WWPNotificationDefinitionDescr, BC000N14_A167WWPNotificationDefinitionIcon, BC000N14_A168WWPNotificationDefinitionTitle, BC000N14_A169WWPNotificationDefinitionShort, BC000N14_A170WWPNotificationDefinitionLongD, BC000N14_A171WWPNotificationDefinitionLink,
               BC000N14_A126WWPEntityName, BC000N14_A172WWPNotificationDefinitionSecFu, BC000N14_A125WWPEntityId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z135WWPNotificationDefinitionAppli ;
      private short A135WWPNotificationDefinitionAppli ;
      private short RcdFound33 ;
      private int trnEnded ;
      private long Z128WWPNotificationDefinitionId ;
      private long A128WWPNotificationDefinitionId ;
      private long Z125WWPEntityId ;
      private long A125WWPEntityId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode33 ;
      private bool Z136WWPNotificationDefinitionAllow ;
      private bool A136WWPNotificationDefinitionAllow ;
      private bool Z173WWPNotificationDefinitionIsAut ;
      private bool A173WWPNotificationDefinitionIsAut ;
      private bool Gx_longc ;
      private bool GXt_boolean1 ;
      private string Z164WWPNotificationDefinitionName ;
      private string A164WWPNotificationDefinitionName ;
      private string Z134WWPNotificationDefinitionDescr ;
      private string A134WWPNotificationDefinitionDescr ;
      private string Z167WWPNotificationDefinitionIcon ;
      private string A167WWPNotificationDefinitionIcon ;
      private string Z168WWPNotificationDefinitionTitle ;
      private string A168WWPNotificationDefinitionTitle ;
      private string Z169WWPNotificationDefinitionShort ;
      private string A169WWPNotificationDefinitionShort ;
      private string Z170WWPNotificationDefinitionLongD ;
      private string A170WWPNotificationDefinitionLongD ;
      private string Z171WWPNotificationDefinitionLink ;
      private string A171WWPNotificationDefinitionLink ;
      private string Z172WWPNotificationDefinitionSecFu ;
      private string A172WWPNotificationDefinitionSecFu ;
      private string Z126WWPEntityName ;
      private string A126WWPEntityName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC000N5_A128WWPNotificationDefinitionId ;
      private string[] BC000N5_A164WWPNotificationDefinitionName ;
      private short[] BC000N5_A135WWPNotificationDefinitionAppli ;
      private bool[] BC000N5_A136WWPNotificationDefinitionAllow ;
      private string[] BC000N5_A134WWPNotificationDefinitionDescr ;
      private string[] BC000N5_A167WWPNotificationDefinitionIcon ;
      private string[] BC000N5_A168WWPNotificationDefinitionTitle ;
      private string[] BC000N5_A169WWPNotificationDefinitionShort ;
      private string[] BC000N5_A170WWPNotificationDefinitionLongD ;
      private string[] BC000N5_A171WWPNotificationDefinitionLink ;
      private string[] BC000N5_A126WWPEntityName ;
      private string[] BC000N5_A172WWPNotificationDefinitionSecFu ;
      private long[] BC000N5_A125WWPEntityId ;
      private string[] BC000N4_A126WWPEntityName ;
      private long[] BC000N6_A128WWPNotificationDefinitionId ;
      private long[] BC000N3_A128WWPNotificationDefinitionId ;
      private string[] BC000N3_A164WWPNotificationDefinitionName ;
      private short[] BC000N3_A135WWPNotificationDefinitionAppli ;
      private bool[] BC000N3_A136WWPNotificationDefinitionAllow ;
      private string[] BC000N3_A134WWPNotificationDefinitionDescr ;
      private string[] BC000N3_A167WWPNotificationDefinitionIcon ;
      private string[] BC000N3_A168WWPNotificationDefinitionTitle ;
      private string[] BC000N3_A169WWPNotificationDefinitionShort ;
      private string[] BC000N3_A170WWPNotificationDefinitionLongD ;
      private string[] BC000N3_A171WWPNotificationDefinitionLink ;
      private string[] BC000N3_A172WWPNotificationDefinitionSecFu ;
      private long[] BC000N3_A125WWPEntityId ;
      private long[] BC000N2_A128WWPNotificationDefinitionId ;
      private string[] BC000N2_A164WWPNotificationDefinitionName ;
      private short[] BC000N2_A135WWPNotificationDefinitionAppli ;
      private bool[] BC000N2_A136WWPNotificationDefinitionAllow ;
      private string[] BC000N2_A134WWPNotificationDefinitionDescr ;
      private string[] BC000N2_A167WWPNotificationDefinitionIcon ;
      private string[] BC000N2_A168WWPNotificationDefinitionTitle ;
      private string[] BC000N2_A169WWPNotificationDefinitionShort ;
      private string[] BC000N2_A170WWPNotificationDefinitionLongD ;
      private string[] BC000N2_A171WWPNotificationDefinitionLink ;
      private string[] BC000N2_A172WWPNotificationDefinitionSecFu ;
      private long[] BC000N2_A125WWPEntityId ;
      private long[] BC000N8_A128WWPNotificationDefinitionId ;
      private string[] BC000N11_A126WWPEntityName ;
      private long[] BC000N12_A127WWPNotificationId ;
      private long[] BC000N13_A130WWPSubscriptionId ;
      private long[] BC000N14_A128WWPNotificationDefinitionId ;
      private string[] BC000N14_A164WWPNotificationDefinitionName ;
      private short[] BC000N14_A135WWPNotificationDefinitionAppli ;
      private bool[] BC000N14_A136WWPNotificationDefinitionAllow ;
      private string[] BC000N14_A134WWPNotificationDefinitionDescr ;
      private string[] BC000N14_A167WWPNotificationDefinitionIcon ;
      private string[] BC000N14_A168WWPNotificationDefinitionTitle ;
      private string[] BC000N14_A169WWPNotificationDefinitionShort ;
      private string[] BC000N14_A170WWPNotificationDefinitionLongD ;
      private string[] BC000N14_A171WWPNotificationDefinitionLink ;
      private string[] BC000N14_A126WWPEntityName ;
      private string[] BC000N14_A172WWPNotificationDefinitionSecFu ;
      private long[] BC000N14_A125WWPEntityId ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_notificationdefinition_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_notificationdefinition_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_notificationdefinition_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[6])
      ,new UpdateCursor(def[7])
      ,new UpdateCursor(def[8])
      ,new ForEachCursor(def[9])
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
       Object[] prmBC000N2;
       prmBC000N2 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmBC000N3;
       prmBC000N3 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmBC000N4;
       prmBC000N4 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmBC000N5;
       prmBC000N5 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmBC000N6;
       prmBC000N6 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmBC000N7;
       prmBC000N7 = new Object[] {
       new ParDef("WWPNotificationDefinitionName",GXType.VarChar,100,0) ,
       new ParDef("WWPNotificationDefinitionAppli",GXType.Int16,1,0) ,
       new ParDef("WWPNotificationDefinitionAllow",GXType.Boolean,4,0) ,
       new ParDef("WWPNotificationDefinitionDescr",GXType.VarChar,200,0) ,
       new ParDef("WWPNotificationDefinitionIcon",GXType.VarChar,40,0) ,
       new ParDef("WWPNotificationDefinitionTitle",GXType.VarChar,200,0) ,
       new ParDef("WWPNotificationDefinitionShort",GXType.VarChar,200,0) ,
       new ParDef("WWPNotificationDefinitionLongD",GXType.VarChar,1000,0) ,
       new ParDef("WWPNotificationDefinitionLink",GXType.VarChar,1000,0) ,
       new ParDef("WWPNotificationDefinitionSecFu",GXType.VarChar,200,0) ,
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmBC000N8;
       prmBC000N8 = new Object[] {
       };
       Object[] prmBC000N9;
       prmBC000N9 = new Object[] {
       new ParDef("WWPNotificationDefinitionName",GXType.VarChar,100,0) ,
       new ParDef("WWPNotificationDefinitionAppli",GXType.Int16,1,0) ,
       new ParDef("WWPNotificationDefinitionAllow",GXType.Boolean,4,0) ,
       new ParDef("WWPNotificationDefinitionDescr",GXType.VarChar,200,0) ,
       new ParDef("WWPNotificationDefinitionIcon",GXType.VarChar,40,0) ,
       new ParDef("WWPNotificationDefinitionTitle",GXType.VarChar,200,0) ,
       new ParDef("WWPNotificationDefinitionShort",GXType.VarChar,200,0) ,
       new ParDef("WWPNotificationDefinitionLongD",GXType.VarChar,1000,0) ,
       new ParDef("WWPNotificationDefinitionLink",GXType.VarChar,1000,0) ,
       new ParDef("WWPNotificationDefinitionSecFu",GXType.VarChar,200,0) ,
       new ParDef("WWPEntityId",GXType.Int64,10,0) ,
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmBC000N10;
       prmBC000N10 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmBC000N11;
       prmBC000N11 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmBC000N12;
       prmBC000N12 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmBC000N13;
       prmBC000N13 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmBC000N14;
       prmBC000N14 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC000N2", "SELECT WWPNotificationDefinitionId, WWPNotificationDefinitionName, WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow, WWPNotificationDefinitionDescr, WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink, WWPNotificationDefinitionSecFu, WWPEntityId FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId  FOR UPDATE OF WWP_NotificationDefinition",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000N3", "SELECT WWPNotificationDefinitionId, WWPNotificationDefinitionName, WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow, WWPNotificationDefinitionDescr, WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink, WWPNotificationDefinitionSecFu, WWPEntityId FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000N4", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000N5", "SELECT TM1.WWPNotificationDefinitionId, TM1.WWPNotificationDefinitionName, TM1.WWPNotificationDefinitionAppli, TM1.WWPNotificationDefinitionAllow, TM1.WWPNotificationDefinitionDescr, TM1.WWPNotificationDefinitionIcon, TM1.WWPNotificationDefinitionTitle, TM1.WWPNotificationDefinitionShort, TM1.WWPNotificationDefinitionLongD, TM1.WWPNotificationDefinitionLink, T2.WWPEntityName, TM1.WWPNotificationDefinitionSecFu, TM1.WWPEntityId FROM (WWP_NotificationDefinition TM1 INNER JOIN WWP_Entity T2 ON T2.WWPEntityId = TM1.WWPEntityId) WHERE TM1.WWPNotificationDefinitionId = :WWPNotificationDefinitionId ORDER BY TM1.WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000N6", "SELECT WWPNotificationDefinitionId FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000N7", "SAVEPOINT gxupdate;INSERT INTO WWP_NotificationDefinition(WWPNotificationDefinitionName, WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow, WWPNotificationDefinitionDescr, WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink, WWPNotificationDefinitionSecFu, WWPEntityId) VALUES(:WWPNotificationDefinitionName, :WWPNotificationDefinitionAppli, :WWPNotificationDefinitionAllow, :WWPNotificationDefinitionDescr, :WWPNotificationDefinitionIcon, :WWPNotificationDefinitionTitle, :WWPNotificationDefinitionShort, :WWPNotificationDefinitionLongD, :WWPNotificationDefinitionLink, :WWPNotificationDefinitionSecFu, :WWPEntityId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000N7)
          ,new CursorDef("BC000N8", "SELECT currval('WWPNotificationDefinitionId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000N9", "SAVEPOINT gxupdate;UPDATE WWP_NotificationDefinition SET WWPNotificationDefinitionName=:WWPNotificationDefinitionName, WWPNotificationDefinitionAppli=:WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow=:WWPNotificationDefinitionAllow, WWPNotificationDefinitionDescr=:WWPNotificationDefinitionDescr, WWPNotificationDefinitionIcon=:WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle=:WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort=:WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD=:WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink=:WWPNotificationDefinitionLink, WWPNotificationDefinitionSecFu=:WWPNotificationDefinitionSecFu, WWPEntityId=:WWPEntityId  WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000N9)
          ,new CursorDef("BC000N10", "SAVEPOINT gxupdate;DELETE FROM WWP_NotificationDefinition  WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000N10)
          ,new CursorDef("BC000N11", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N11,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000N12", "SELECT WWPNotificationId FROM WWP_Notification WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N12,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000N13", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N13,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000N14", "SELECT TM1.WWPNotificationDefinitionId, TM1.WWPNotificationDefinitionName, TM1.WWPNotificationDefinitionAppli, TM1.WWPNotificationDefinitionAllow, TM1.WWPNotificationDefinitionDescr, TM1.WWPNotificationDefinitionIcon, TM1.WWPNotificationDefinitionTitle, TM1.WWPNotificationDefinitionShort, TM1.WWPNotificationDefinitionLongD, TM1.WWPNotificationDefinitionLink, T2.WWPEntityName, TM1.WWPNotificationDefinitionSecFu, TM1.WWPEntityId FROM (WWP_NotificationDefinition TM1 INNER JOIN WWP_Entity T2 ON T2.WWPEntityId = TM1.WWPEntityId) WHERE TM1.WWPNotificationDefinitionId = :WWPNotificationDefinitionId ORDER BY TM1.WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N14,100, GxCacheFrequency.OFF ,true,false )
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
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((long[]) buf[11])[0] = rslt.getLong(12);
             return;
          case 1 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((long[]) buf[11])[0] = rslt.getLong(12);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 3 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((long[]) buf[12])[0] = rslt.getLong(13);
             return;
          case 4 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 6 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 9 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 10 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 11 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 12 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((long[]) buf[12])[0] = rslt.getLong(13);
             return;
    }
 }

}

}
