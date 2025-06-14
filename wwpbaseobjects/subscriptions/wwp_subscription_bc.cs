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
namespace GeneXus.Programs.wwpbaseobjects.subscriptions {
   public class wwp_subscription_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_subscription_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_subscription_bc( IGxContext context )
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
         ReadRow0J29( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0J29( ) ;
         standaloneModal( ) ;
         AddRow0J29( ) ;
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
               Z130WWPSubscriptionId = A130WWPSubscriptionId;
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

      protected void CONFIRM_0J0( )
      {
         BeforeValidate0J29( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0J29( ) ;
            }
            else
            {
               CheckExtendedTable0J29( ) ;
               if ( AnyError == 0 )
               {
                  ZM0J29( 3) ;
                  ZM0J29( 4) ;
                  ZM0J29( 5) ;
               }
               CloseExtendedTableCursors0J29( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0J29( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z131WWPSubscriptionEntityRecordId = A131WWPSubscriptionEntityRecordId;
            Z133WWPSubscriptionEntityRecordDes = A133WWPSubscriptionEntityRecordDes;
            Z124WWPSubscriptionRoleId = A124WWPSubscriptionRoleId;
            Z132WWPSubscriptionSubscribed = A132WWPSubscriptionSubscribed;
            Z128WWPNotificationDefinitionId = A128WWPNotificationDefinitionId;
            Z112WWPUserExtendedId = A112WWPUserExtendedId;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z125WWPEntityId = A125WWPEntityId;
            Z134WWPNotificationDefinitionDescr = A134WWPNotificationDefinitionDescr;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z113WWPUserExtendedFullName = A113WWPUserExtendedFullName;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z126WWPEntityName = A126WWPEntityName;
         }
         if ( GX_JID == -2 )
         {
            Z130WWPSubscriptionId = A130WWPSubscriptionId;
            Z131WWPSubscriptionEntityRecordId = A131WWPSubscriptionEntityRecordId;
            Z133WWPSubscriptionEntityRecordDes = A133WWPSubscriptionEntityRecordDes;
            Z124WWPSubscriptionRoleId = A124WWPSubscriptionRoleId;
            Z132WWPSubscriptionSubscribed = A132WWPSubscriptionSubscribed;
            Z128WWPNotificationDefinitionId = A128WWPNotificationDefinitionId;
            Z112WWPUserExtendedId = A112WWPUserExtendedId;
            Z125WWPEntityId = A125WWPEntityId;
            Z134WWPNotificationDefinitionDescr = A134WWPNotificationDefinitionDescr;
            Z126WWPEntityName = A126WWPEntityName;
            Z113WWPUserExtendedFullName = A113WWPUserExtendedFullName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0J29( )
      {
         /* Using cursor BC000J7 */
         pr_default.execute(5, new Object[] {A130WWPSubscriptionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound29 = 1;
            A125WWPEntityId = BC000J7_A125WWPEntityId[0];
            A134WWPNotificationDefinitionDescr = BC000J7_A134WWPNotificationDefinitionDescr[0];
            A126WWPEntityName = BC000J7_A126WWPEntityName[0];
            A113WWPUserExtendedFullName = BC000J7_A113WWPUserExtendedFullName[0];
            A131WWPSubscriptionEntityRecordId = BC000J7_A131WWPSubscriptionEntityRecordId[0];
            A133WWPSubscriptionEntityRecordDes = BC000J7_A133WWPSubscriptionEntityRecordDes[0];
            A124WWPSubscriptionRoleId = BC000J7_A124WWPSubscriptionRoleId[0];
            n124WWPSubscriptionRoleId = BC000J7_n124WWPSubscriptionRoleId[0];
            A132WWPSubscriptionSubscribed = BC000J7_A132WWPSubscriptionSubscribed[0];
            A128WWPNotificationDefinitionId = BC000J7_A128WWPNotificationDefinitionId[0];
            A112WWPUserExtendedId = BC000J7_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = BC000J7_n112WWPUserExtendedId[0];
            ZM0J29( -2) ;
         }
         pr_default.close(5);
         OnLoadActions0J29( ) ;
      }

      protected void OnLoadActions0J29( )
      {
      }

      protected void CheckExtendedTable0J29( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000J4 */
         pr_default.execute(2, new Object[] {A128WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_NotificationDefinition", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
         }
         A125WWPEntityId = BC000J4_A125WWPEntityId[0];
         A134WWPNotificationDefinitionDescr = BC000J4_A134WWPNotificationDefinitionDescr[0];
         pr_default.close(2);
         /* Using cursor BC000J6 */
         pr_default.execute(4, new Object[] {A125WWPEntityId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A126WWPEntityName = BC000J6_A126WWPEntityName[0];
         pr_default.close(4);
         /* Using cursor BC000J5 */
         pr_default.execute(3, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A112WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
            }
         }
         A113WWPUserExtendedFullName = BC000J5_A113WWPUserExtendedFullName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0J29( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0J29( )
      {
         /* Using cursor BC000J8 */
         pr_default.execute(6, new Object[] {A130WWPSubscriptionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound29 = 1;
         }
         else
         {
            RcdFound29 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000J3 */
         pr_default.execute(1, new Object[] {A130WWPSubscriptionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0J29( 2) ;
            RcdFound29 = 1;
            A130WWPSubscriptionId = BC000J3_A130WWPSubscriptionId[0];
            A131WWPSubscriptionEntityRecordId = BC000J3_A131WWPSubscriptionEntityRecordId[0];
            A133WWPSubscriptionEntityRecordDes = BC000J3_A133WWPSubscriptionEntityRecordDes[0];
            A124WWPSubscriptionRoleId = BC000J3_A124WWPSubscriptionRoleId[0];
            n124WWPSubscriptionRoleId = BC000J3_n124WWPSubscriptionRoleId[0];
            A132WWPSubscriptionSubscribed = BC000J3_A132WWPSubscriptionSubscribed[0];
            A128WWPNotificationDefinitionId = BC000J3_A128WWPNotificationDefinitionId[0];
            A112WWPUserExtendedId = BC000J3_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = BC000J3_n112WWPUserExtendedId[0];
            Z130WWPSubscriptionId = A130WWPSubscriptionId;
            sMode29 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0J29( ) ;
            if ( AnyError == 1 )
            {
               RcdFound29 = 0;
               InitializeNonKey0J29( ) ;
            }
            Gx_mode = sMode29;
         }
         else
         {
            RcdFound29 = 0;
            InitializeNonKey0J29( ) ;
            sMode29 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode29;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0J29( ) ;
         if ( RcdFound29 == 0 )
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
         CONFIRM_0J0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0J29( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000J2 */
            pr_default.execute(0, new Object[] {A130WWPSubscriptionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Subscription"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z131WWPSubscriptionEntityRecordId, BC000J2_A131WWPSubscriptionEntityRecordId[0]) != 0 ) || ( StringUtil.StrCmp(Z133WWPSubscriptionEntityRecordDes, BC000J2_A133WWPSubscriptionEntityRecordDes[0]) != 0 ) || ( StringUtil.StrCmp(Z124WWPSubscriptionRoleId, BC000J2_A124WWPSubscriptionRoleId[0]) != 0 ) || ( Z132WWPSubscriptionSubscribed != BC000J2_A132WWPSubscriptionSubscribed[0] ) || ( Z128WWPNotificationDefinitionId != BC000J2_A128WWPNotificationDefinitionId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z112WWPUserExtendedId, BC000J2_A112WWPUserExtendedId[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Subscription"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0J29( )
      {
         BeforeValidate0J29( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J29( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0J29( 0) ;
            CheckOptimisticConcurrency0J29( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J29( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0J29( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000J9 */
                     pr_default.execute(7, new Object[] {A131WWPSubscriptionEntityRecordId, A133WWPSubscriptionEntityRecordDes, n124WWPSubscriptionRoleId, A124WWPSubscriptionRoleId, A132WWPSubscriptionSubscribed, A128WWPNotificationDefinitionId, n112WWPUserExtendedId, A112WWPUserExtendedId});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000J10 */
                     pr_default.execute(8);
                     A130WWPSubscriptionId = BC000J10_A130WWPSubscriptionId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
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
               Load0J29( ) ;
            }
            EndLevel0J29( ) ;
         }
         CloseExtendedTableCursors0J29( ) ;
      }

      protected void Update0J29( )
      {
         BeforeValidate0J29( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J29( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J29( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J29( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0J29( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000J11 */
                     pr_default.execute(9, new Object[] {A131WWPSubscriptionEntityRecordId, A133WWPSubscriptionEntityRecordDes, n124WWPSubscriptionRoleId, A124WWPSubscriptionRoleId, A132WWPSubscriptionSubscribed, A128WWPNotificationDefinitionId, n112WWPUserExtendedId, A112WWPUserExtendedId, A130WWPSubscriptionId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Subscription"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0J29( ) ;
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
            EndLevel0J29( ) ;
         }
         CloseExtendedTableCursors0J29( ) ;
      }

      protected void DeferredUpdate0J29( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0J29( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J29( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0J29( ) ;
            AfterConfirm0J29( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0J29( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000J12 */
                  pr_default.execute(10, new Object[] {A130WWPSubscriptionId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
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
         sMode29 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0J29( ) ;
         Gx_mode = sMode29;
      }

      protected void OnDeleteControls0J29( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000J13 */
            pr_default.execute(11, new Object[] {A128WWPNotificationDefinitionId});
            A125WWPEntityId = BC000J13_A125WWPEntityId[0];
            A134WWPNotificationDefinitionDescr = BC000J13_A134WWPNotificationDefinitionDescr[0];
            pr_default.close(11);
            /* Using cursor BC000J14 */
            pr_default.execute(12, new Object[] {A125WWPEntityId});
            A126WWPEntityName = BC000J14_A126WWPEntityName[0];
            pr_default.close(12);
            /* Using cursor BC000J15 */
            pr_default.execute(13, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
            A113WWPUserExtendedFullName = BC000J15_A113WWPUserExtendedFullName[0];
            pr_default.close(13);
         }
      }

      protected void EndLevel0J29( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0J29( ) ;
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

      public void ScanKeyStart0J29( )
      {
         /* Using cursor BC000J16 */
         pr_default.execute(14, new Object[] {A130WWPSubscriptionId});
         RcdFound29 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound29 = 1;
            A125WWPEntityId = BC000J16_A125WWPEntityId[0];
            A130WWPSubscriptionId = BC000J16_A130WWPSubscriptionId[0];
            A134WWPNotificationDefinitionDescr = BC000J16_A134WWPNotificationDefinitionDescr[0];
            A126WWPEntityName = BC000J16_A126WWPEntityName[0];
            A113WWPUserExtendedFullName = BC000J16_A113WWPUserExtendedFullName[0];
            A131WWPSubscriptionEntityRecordId = BC000J16_A131WWPSubscriptionEntityRecordId[0];
            A133WWPSubscriptionEntityRecordDes = BC000J16_A133WWPSubscriptionEntityRecordDes[0];
            A124WWPSubscriptionRoleId = BC000J16_A124WWPSubscriptionRoleId[0];
            n124WWPSubscriptionRoleId = BC000J16_n124WWPSubscriptionRoleId[0];
            A132WWPSubscriptionSubscribed = BC000J16_A132WWPSubscriptionSubscribed[0];
            A128WWPNotificationDefinitionId = BC000J16_A128WWPNotificationDefinitionId[0];
            A112WWPUserExtendedId = BC000J16_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = BC000J16_n112WWPUserExtendedId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0J29( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound29 = 0;
         ScanKeyLoad0J29( ) ;
      }

      protected void ScanKeyLoad0J29( )
      {
         sMode29 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound29 = 1;
            A125WWPEntityId = BC000J16_A125WWPEntityId[0];
            A130WWPSubscriptionId = BC000J16_A130WWPSubscriptionId[0];
            A134WWPNotificationDefinitionDescr = BC000J16_A134WWPNotificationDefinitionDescr[0];
            A126WWPEntityName = BC000J16_A126WWPEntityName[0];
            A113WWPUserExtendedFullName = BC000J16_A113WWPUserExtendedFullName[0];
            A131WWPSubscriptionEntityRecordId = BC000J16_A131WWPSubscriptionEntityRecordId[0];
            A133WWPSubscriptionEntityRecordDes = BC000J16_A133WWPSubscriptionEntityRecordDes[0];
            A124WWPSubscriptionRoleId = BC000J16_A124WWPSubscriptionRoleId[0];
            n124WWPSubscriptionRoleId = BC000J16_n124WWPSubscriptionRoleId[0];
            A132WWPSubscriptionSubscribed = BC000J16_A132WWPSubscriptionSubscribed[0];
            A128WWPNotificationDefinitionId = BC000J16_A128WWPNotificationDefinitionId[0];
            A112WWPUserExtendedId = BC000J16_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = BC000J16_n112WWPUserExtendedId[0];
         }
         Gx_mode = sMode29;
      }

      protected void ScanKeyEnd0J29( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0J29( )
      {
         /* After Confirm Rules */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A112WWPUserExtendedId)) )
         {
            A112WWPUserExtendedId = "";
            n112WWPUserExtendedId = false;
            n112WWPUserExtendedId = true;
         }
      }

      protected void BeforeInsert0J29( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0J29( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0J29( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0J29( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0J29( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0J29( )
      {
      }

      protected void send_integrity_lvl_hashes0J29( )
      {
      }

      protected void AddRow0J29( )
      {
         VarsToRow29( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
      }

      protected void ReadRow0J29( )
      {
         RowToVars29( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
      }

      protected void InitializeNonKey0J29( )
      {
         A125WWPEntityId = 0;
         A128WWPNotificationDefinitionId = 0;
         A134WWPNotificationDefinitionDescr = "";
         A126WWPEntityName = "";
         A112WWPUserExtendedId = "";
         n112WWPUserExtendedId = false;
         A113WWPUserExtendedFullName = "";
         A131WWPSubscriptionEntityRecordId = "";
         A133WWPSubscriptionEntityRecordDes = "";
         A124WWPSubscriptionRoleId = "";
         n124WWPSubscriptionRoleId = false;
         A132WWPSubscriptionSubscribed = false;
         Z131WWPSubscriptionEntityRecordId = "";
         Z133WWPSubscriptionEntityRecordDes = "";
         Z124WWPSubscriptionRoleId = "";
         Z132WWPSubscriptionSubscribed = false;
         Z128WWPNotificationDefinitionId = 0;
         Z112WWPUserExtendedId = "";
      }

      protected void InitAll0J29( )
      {
         A130WWPSubscriptionId = 0;
         InitializeNonKey0J29( ) ;
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

      public void VarsToRow29( GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription obj29 )
      {
         obj29.gxTpr_Mode = Gx_mode;
         obj29.gxTpr_Wwpnotificationdefinitionid = A128WWPNotificationDefinitionId;
         obj29.gxTpr_Wwpnotificationdefinitiondescription = A134WWPNotificationDefinitionDescr;
         obj29.gxTpr_Wwpentityname = A126WWPEntityName;
         obj29.gxTpr_Wwpuserextendedid = A112WWPUserExtendedId;
         obj29.gxTpr_Wwpuserextendedfullname = A113WWPUserExtendedFullName;
         obj29.gxTpr_Wwpsubscriptionentityrecordid = A131WWPSubscriptionEntityRecordId;
         obj29.gxTpr_Wwpsubscriptionentityrecorddescription = A133WWPSubscriptionEntityRecordDes;
         obj29.gxTpr_Wwpsubscriptionroleid = A124WWPSubscriptionRoleId;
         obj29.gxTpr_Wwpsubscriptionsubscribed = A132WWPSubscriptionSubscribed;
         obj29.gxTpr_Wwpsubscriptionid = A130WWPSubscriptionId;
         obj29.gxTpr_Wwpsubscriptionid_Z = Z130WWPSubscriptionId;
         obj29.gxTpr_Wwpnotificationdefinitionid_Z = Z128WWPNotificationDefinitionId;
         obj29.gxTpr_Wwpnotificationdefinitiondescription_Z = Z134WWPNotificationDefinitionDescr;
         obj29.gxTpr_Wwpentityname_Z = Z126WWPEntityName;
         obj29.gxTpr_Wwpuserextendedid_Z = Z112WWPUserExtendedId;
         obj29.gxTpr_Wwpuserextendedfullname_Z = Z113WWPUserExtendedFullName;
         obj29.gxTpr_Wwpsubscriptionentityrecordid_Z = Z131WWPSubscriptionEntityRecordId;
         obj29.gxTpr_Wwpsubscriptionentityrecorddescription_Z = Z133WWPSubscriptionEntityRecordDes;
         obj29.gxTpr_Wwpsubscriptionroleid_Z = Z124WWPSubscriptionRoleId;
         obj29.gxTpr_Wwpsubscriptionsubscribed_Z = Z132WWPSubscriptionSubscribed;
         obj29.gxTpr_Wwpuserextendedid_N = (short)(Convert.ToInt16(n112WWPUserExtendedId));
         obj29.gxTpr_Wwpsubscriptionroleid_N = (short)(Convert.ToInt16(n124WWPSubscriptionRoleId));
         obj29.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow29( GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription obj29 )
      {
         obj29.gxTpr_Wwpsubscriptionid = A130WWPSubscriptionId;
         return  ;
      }

      public void RowToVars29( GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription obj29 ,
                               int forceLoad )
      {
         Gx_mode = obj29.gxTpr_Mode;
         A128WWPNotificationDefinitionId = obj29.gxTpr_Wwpnotificationdefinitionid;
         A134WWPNotificationDefinitionDescr = obj29.gxTpr_Wwpnotificationdefinitiondescription;
         A126WWPEntityName = obj29.gxTpr_Wwpentityname;
         A112WWPUserExtendedId = obj29.gxTpr_Wwpuserextendedid;
         n112WWPUserExtendedId = false;
         A113WWPUserExtendedFullName = obj29.gxTpr_Wwpuserextendedfullname;
         A131WWPSubscriptionEntityRecordId = obj29.gxTpr_Wwpsubscriptionentityrecordid;
         A133WWPSubscriptionEntityRecordDes = obj29.gxTpr_Wwpsubscriptionentityrecorddescription;
         A124WWPSubscriptionRoleId = obj29.gxTpr_Wwpsubscriptionroleid;
         n124WWPSubscriptionRoleId = false;
         A132WWPSubscriptionSubscribed = obj29.gxTpr_Wwpsubscriptionsubscribed;
         A130WWPSubscriptionId = obj29.gxTpr_Wwpsubscriptionid;
         Z130WWPSubscriptionId = obj29.gxTpr_Wwpsubscriptionid_Z;
         Z128WWPNotificationDefinitionId = obj29.gxTpr_Wwpnotificationdefinitionid_Z;
         Z134WWPNotificationDefinitionDescr = obj29.gxTpr_Wwpnotificationdefinitiondescription_Z;
         Z126WWPEntityName = obj29.gxTpr_Wwpentityname_Z;
         Z112WWPUserExtendedId = obj29.gxTpr_Wwpuserextendedid_Z;
         Z113WWPUserExtendedFullName = obj29.gxTpr_Wwpuserextendedfullname_Z;
         Z131WWPSubscriptionEntityRecordId = obj29.gxTpr_Wwpsubscriptionentityrecordid_Z;
         Z133WWPSubscriptionEntityRecordDes = obj29.gxTpr_Wwpsubscriptionentityrecorddescription_Z;
         Z124WWPSubscriptionRoleId = obj29.gxTpr_Wwpsubscriptionroleid_Z;
         Z132WWPSubscriptionSubscribed = obj29.gxTpr_Wwpsubscriptionsubscribed_Z;
         n112WWPUserExtendedId = (bool)(Convert.ToBoolean(obj29.gxTpr_Wwpuserextendedid_N));
         n124WWPSubscriptionRoleId = (bool)(Convert.ToBoolean(obj29.gxTpr_Wwpsubscriptionroleid_N));
         Gx_mode = obj29.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A130WWPSubscriptionId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0J29( ) ;
         ScanKeyStart0J29( ) ;
         if ( RcdFound29 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z130WWPSubscriptionId = A130WWPSubscriptionId;
         }
         ZM0J29( -2) ;
         OnLoadActions0J29( ) ;
         AddRow0J29( ) ;
         ScanKeyEnd0J29( ) ;
         if ( RcdFound29 == 0 )
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
         RowToVars29( bcwwpbaseobjects_subscriptions_WWP_Subscription, 0) ;
         ScanKeyStart0J29( ) ;
         if ( RcdFound29 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z130WWPSubscriptionId = A130WWPSubscriptionId;
         }
         ZM0J29( -2) ;
         OnLoadActions0J29( ) ;
         AddRow0J29( ) ;
         ScanKeyEnd0J29( ) ;
         if ( RcdFound29 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0J29( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0J29( ) ;
         }
         else
         {
            if ( RcdFound29 == 1 )
            {
               if ( A130WWPSubscriptionId != Z130WWPSubscriptionId )
               {
                  A130WWPSubscriptionId = Z130WWPSubscriptionId;
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
                  Update0J29( ) ;
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
                  if ( A130WWPSubscriptionId != Z130WWPSubscriptionId )
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
                        Insert0J29( ) ;
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
                        Insert0J29( ) ;
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
         RowToVars29( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         SaveImpl( ) ;
         VarsToRow29( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars29( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0J29( ) ;
         AfterTrn( ) ;
         VarsToRow29( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow29( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription auxBC = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A130WWPSubscriptionId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_subscriptions_WWP_Subscription);
               auxBC.Save();
               bcwwpbaseobjects_subscriptions_WWP_Subscription.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars29( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
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
         RowToVars29( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0J29( ) ;
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
               VarsToRow29( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow29( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
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
         RowToVars29( bcwwpbaseobjects_subscriptions_WWP_Subscription, 0) ;
         GetKey0J29( ) ;
         if ( RcdFound29 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A130WWPSubscriptionId != Z130WWPSubscriptionId )
            {
               A130WWPSubscriptionId = Z130WWPSubscriptionId;
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
            if ( A130WWPSubscriptionId != Z130WWPSubscriptionId )
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
         context.RollbackDataStores("wwpbaseobjects.subscriptions.wwp_subscription_bc",pr_default);
         VarsToRow29( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
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
         Gx_mode = bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_subscriptions_WWP_Subscription )
         {
            bcwwpbaseobjects_subscriptions_WWP_Subscription = (GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow29( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
            }
            else
            {
               RowToVars29( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars29( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_Subscription WWP_Subscription_BC
      {
         get {
            return bcwwpbaseobjects_subscriptions_WWP_Subscription ;
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
            return "wwpsubscription_Execute" ;
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
         pr_default.close(11);
         pr_default.close(13);
         pr_default.close(12);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z131WWPSubscriptionEntityRecordId = "";
         A131WWPSubscriptionEntityRecordId = "";
         Z133WWPSubscriptionEntityRecordDes = "";
         A133WWPSubscriptionEntityRecordDes = "";
         Z124WWPSubscriptionRoleId = "";
         A124WWPSubscriptionRoleId = "";
         Z112WWPUserExtendedId = "";
         A112WWPUserExtendedId = "";
         Z134WWPNotificationDefinitionDescr = "";
         A134WWPNotificationDefinitionDescr = "";
         Z113WWPUserExtendedFullName = "";
         A113WWPUserExtendedFullName = "";
         Z126WWPEntityName = "";
         A126WWPEntityName = "";
         BC000J7_A125WWPEntityId = new long[1] ;
         BC000J7_A130WWPSubscriptionId = new long[1] ;
         BC000J7_A134WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000J7_A126WWPEntityName = new string[] {""} ;
         BC000J7_A113WWPUserExtendedFullName = new string[] {""} ;
         BC000J7_A131WWPSubscriptionEntityRecordId = new string[] {""} ;
         BC000J7_A133WWPSubscriptionEntityRecordDes = new string[] {""} ;
         BC000J7_A124WWPSubscriptionRoleId = new string[] {""} ;
         BC000J7_n124WWPSubscriptionRoleId = new bool[] {false} ;
         BC000J7_A132WWPSubscriptionSubscribed = new bool[] {false} ;
         BC000J7_A128WWPNotificationDefinitionId = new long[1] ;
         BC000J7_A112WWPUserExtendedId = new string[] {""} ;
         BC000J7_n112WWPUserExtendedId = new bool[] {false} ;
         BC000J4_A125WWPEntityId = new long[1] ;
         BC000J4_A134WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000J6_A126WWPEntityName = new string[] {""} ;
         BC000J5_A113WWPUserExtendedFullName = new string[] {""} ;
         BC000J8_A130WWPSubscriptionId = new long[1] ;
         BC000J3_A130WWPSubscriptionId = new long[1] ;
         BC000J3_A131WWPSubscriptionEntityRecordId = new string[] {""} ;
         BC000J3_A133WWPSubscriptionEntityRecordDes = new string[] {""} ;
         BC000J3_A124WWPSubscriptionRoleId = new string[] {""} ;
         BC000J3_n124WWPSubscriptionRoleId = new bool[] {false} ;
         BC000J3_A132WWPSubscriptionSubscribed = new bool[] {false} ;
         BC000J3_A128WWPNotificationDefinitionId = new long[1] ;
         BC000J3_A112WWPUserExtendedId = new string[] {""} ;
         BC000J3_n112WWPUserExtendedId = new bool[] {false} ;
         sMode29 = "";
         BC000J2_A130WWPSubscriptionId = new long[1] ;
         BC000J2_A131WWPSubscriptionEntityRecordId = new string[] {""} ;
         BC000J2_A133WWPSubscriptionEntityRecordDes = new string[] {""} ;
         BC000J2_A124WWPSubscriptionRoleId = new string[] {""} ;
         BC000J2_n124WWPSubscriptionRoleId = new bool[] {false} ;
         BC000J2_A132WWPSubscriptionSubscribed = new bool[] {false} ;
         BC000J2_A128WWPNotificationDefinitionId = new long[1] ;
         BC000J2_A112WWPUserExtendedId = new string[] {""} ;
         BC000J2_n112WWPUserExtendedId = new bool[] {false} ;
         BC000J10_A130WWPSubscriptionId = new long[1] ;
         BC000J13_A125WWPEntityId = new long[1] ;
         BC000J13_A134WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000J14_A126WWPEntityName = new string[] {""} ;
         BC000J15_A113WWPUserExtendedFullName = new string[] {""} ;
         BC000J16_A125WWPEntityId = new long[1] ;
         BC000J16_A130WWPSubscriptionId = new long[1] ;
         BC000J16_A134WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000J16_A126WWPEntityName = new string[] {""} ;
         BC000J16_A113WWPUserExtendedFullName = new string[] {""} ;
         BC000J16_A131WWPSubscriptionEntityRecordId = new string[] {""} ;
         BC000J16_A133WWPSubscriptionEntityRecordDes = new string[] {""} ;
         BC000J16_A124WWPSubscriptionRoleId = new string[] {""} ;
         BC000J16_n124WWPSubscriptionRoleId = new bool[] {false} ;
         BC000J16_A132WWPSubscriptionSubscribed = new bool[] {false} ;
         BC000J16_A128WWPNotificationDefinitionId = new long[1] ;
         BC000J16_A112WWPUserExtendedId = new string[] {""} ;
         BC000J16_n112WWPUserExtendedId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription_bc__default(),
            new Object[][] {
                new Object[] {
               BC000J2_A130WWPSubscriptionId, BC000J2_A131WWPSubscriptionEntityRecordId, BC000J2_A133WWPSubscriptionEntityRecordDes, BC000J2_A124WWPSubscriptionRoleId, BC000J2_n124WWPSubscriptionRoleId, BC000J2_A132WWPSubscriptionSubscribed, BC000J2_A128WWPNotificationDefinitionId, BC000J2_A112WWPUserExtendedId, BC000J2_n112WWPUserExtendedId
               }
               , new Object[] {
               BC000J3_A130WWPSubscriptionId, BC000J3_A131WWPSubscriptionEntityRecordId, BC000J3_A133WWPSubscriptionEntityRecordDes, BC000J3_A124WWPSubscriptionRoleId, BC000J3_n124WWPSubscriptionRoleId, BC000J3_A132WWPSubscriptionSubscribed, BC000J3_A128WWPNotificationDefinitionId, BC000J3_A112WWPUserExtendedId, BC000J3_n112WWPUserExtendedId
               }
               , new Object[] {
               BC000J4_A125WWPEntityId, BC000J4_A134WWPNotificationDefinitionDescr
               }
               , new Object[] {
               BC000J5_A113WWPUserExtendedFullName
               }
               , new Object[] {
               BC000J6_A126WWPEntityName
               }
               , new Object[] {
               BC000J7_A125WWPEntityId, BC000J7_A130WWPSubscriptionId, BC000J7_A134WWPNotificationDefinitionDescr, BC000J7_A126WWPEntityName, BC000J7_A113WWPUserExtendedFullName, BC000J7_A131WWPSubscriptionEntityRecordId, BC000J7_A133WWPSubscriptionEntityRecordDes, BC000J7_A124WWPSubscriptionRoleId, BC000J7_n124WWPSubscriptionRoleId, BC000J7_A132WWPSubscriptionSubscribed,
               BC000J7_A128WWPNotificationDefinitionId, BC000J7_A112WWPUserExtendedId, BC000J7_n112WWPUserExtendedId
               }
               , new Object[] {
               BC000J8_A130WWPSubscriptionId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000J10_A130WWPSubscriptionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000J13_A125WWPEntityId, BC000J13_A134WWPNotificationDefinitionDescr
               }
               , new Object[] {
               BC000J14_A126WWPEntityName
               }
               , new Object[] {
               BC000J15_A113WWPUserExtendedFullName
               }
               , new Object[] {
               BC000J16_A125WWPEntityId, BC000J16_A130WWPSubscriptionId, BC000J16_A134WWPNotificationDefinitionDescr, BC000J16_A126WWPEntityName, BC000J16_A113WWPUserExtendedFullName, BC000J16_A131WWPSubscriptionEntityRecordId, BC000J16_A133WWPSubscriptionEntityRecordDes, BC000J16_A124WWPSubscriptionRoleId, BC000J16_n124WWPSubscriptionRoleId, BC000J16_A132WWPSubscriptionSubscribed,
               BC000J16_A128WWPNotificationDefinitionId, BC000J16_A112WWPUserExtendedId, BC000J16_n112WWPUserExtendedId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound29 ;
      private int trnEnded ;
      private long Z130WWPSubscriptionId ;
      private long A130WWPSubscriptionId ;
      private long Z128WWPNotificationDefinitionId ;
      private long A128WWPNotificationDefinitionId ;
      private long Z125WWPEntityId ;
      private long A125WWPEntityId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z124WWPSubscriptionRoleId ;
      private string A124WWPSubscriptionRoleId ;
      private string Z112WWPUserExtendedId ;
      private string A112WWPUserExtendedId ;
      private string sMode29 ;
      private bool Z132WWPSubscriptionSubscribed ;
      private bool A132WWPSubscriptionSubscribed ;
      private bool n124WWPSubscriptionRoleId ;
      private bool n112WWPUserExtendedId ;
      private bool Gx_longc ;
      private string Z131WWPSubscriptionEntityRecordId ;
      private string A131WWPSubscriptionEntityRecordId ;
      private string Z133WWPSubscriptionEntityRecordDes ;
      private string A133WWPSubscriptionEntityRecordDes ;
      private string Z134WWPNotificationDefinitionDescr ;
      private string A134WWPNotificationDefinitionDescr ;
      private string Z113WWPUserExtendedFullName ;
      private string A113WWPUserExtendedFullName ;
      private string Z126WWPEntityName ;
      private string A126WWPEntityName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC000J7_A125WWPEntityId ;
      private long[] BC000J7_A130WWPSubscriptionId ;
      private string[] BC000J7_A134WWPNotificationDefinitionDescr ;
      private string[] BC000J7_A126WWPEntityName ;
      private string[] BC000J7_A113WWPUserExtendedFullName ;
      private string[] BC000J7_A131WWPSubscriptionEntityRecordId ;
      private string[] BC000J7_A133WWPSubscriptionEntityRecordDes ;
      private string[] BC000J7_A124WWPSubscriptionRoleId ;
      private bool[] BC000J7_n124WWPSubscriptionRoleId ;
      private bool[] BC000J7_A132WWPSubscriptionSubscribed ;
      private long[] BC000J7_A128WWPNotificationDefinitionId ;
      private string[] BC000J7_A112WWPUserExtendedId ;
      private bool[] BC000J7_n112WWPUserExtendedId ;
      private long[] BC000J4_A125WWPEntityId ;
      private string[] BC000J4_A134WWPNotificationDefinitionDescr ;
      private string[] BC000J6_A126WWPEntityName ;
      private string[] BC000J5_A113WWPUserExtendedFullName ;
      private long[] BC000J8_A130WWPSubscriptionId ;
      private long[] BC000J3_A130WWPSubscriptionId ;
      private string[] BC000J3_A131WWPSubscriptionEntityRecordId ;
      private string[] BC000J3_A133WWPSubscriptionEntityRecordDes ;
      private string[] BC000J3_A124WWPSubscriptionRoleId ;
      private bool[] BC000J3_n124WWPSubscriptionRoleId ;
      private bool[] BC000J3_A132WWPSubscriptionSubscribed ;
      private long[] BC000J3_A128WWPNotificationDefinitionId ;
      private string[] BC000J3_A112WWPUserExtendedId ;
      private bool[] BC000J3_n112WWPUserExtendedId ;
      private long[] BC000J2_A130WWPSubscriptionId ;
      private string[] BC000J2_A131WWPSubscriptionEntityRecordId ;
      private string[] BC000J2_A133WWPSubscriptionEntityRecordDes ;
      private string[] BC000J2_A124WWPSubscriptionRoleId ;
      private bool[] BC000J2_n124WWPSubscriptionRoleId ;
      private bool[] BC000J2_A132WWPSubscriptionSubscribed ;
      private long[] BC000J2_A128WWPNotificationDefinitionId ;
      private string[] BC000J2_A112WWPUserExtendedId ;
      private bool[] BC000J2_n112WWPUserExtendedId ;
      private long[] BC000J10_A130WWPSubscriptionId ;
      private long[] BC000J13_A125WWPEntityId ;
      private string[] BC000J13_A134WWPNotificationDefinitionDescr ;
      private string[] BC000J14_A126WWPEntityName ;
      private string[] BC000J15_A113WWPUserExtendedFullName ;
      private long[] BC000J16_A125WWPEntityId ;
      private long[] BC000J16_A130WWPSubscriptionId ;
      private string[] BC000J16_A134WWPNotificationDefinitionDescr ;
      private string[] BC000J16_A126WWPEntityName ;
      private string[] BC000J16_A113WWPUserExtendedFullName ;
      private string[] BC000J16_A131WWPSubscriptionEntityRecordId ;
      private string[] BC000J16_A133WWPSubscriptionEntityRecordDes ;
      private string[] BC000J16_A124WWPSubscriptionRoleId ;
      private bool[] BC000J16_n124WWPSubscriptionRoleId ;
      private bool[] BC000J16_A132WWPSubscriptionSubscribed ;
      private long[] BC000J16_A128WWPNotificationDefinitionId ;
      private string[] BC000J16_A112WWPUserExtendedId ;
      private bool[] BC000J16_n112WWPUserExtendedId ;
      private GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription bcwwpbaseobjects_subscriptions_WWP_Subscription ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_subscription_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_subscription_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_subscription_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[6])
      ,new UpdateCursor(def[7])
      ,new ForEachCursor(def[8])
      ,new UpdateCursor(def[9])
      ,new UpdateCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000J2;
       prmBC000J2 = new Object[] {
       new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
       };
       Object[] prmBC000J3;
       prmBC000J3 = new Object[] {
       new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
       };
       Object[] prmBC000J4;
       prmBC000J4 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmBC000J5;
       prmBC000J5 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmBC000J6;
       prmBC000J6 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmBC000J7;
       prmBC000J7 = new Object[] {
       new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
       };
       Object[] prmBC000J8;
       prmBC000J8 = new Object[] {
       new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
       };
       Object[] prmBC000J9;
       prmBC000J9 = new Object[] {
       new ParDef("WWPSubscriptionEntityRecordId",GXType.VarChar,2000,0) ,
       new ParDef("WWPSubscriptionEntityRecordDes",GXType.VarChar,200,0) ,
       new ParDef("WWPSubscriptionRoleId",GXType.Char,40,0){Nullable=true} ,
       new ParDef("WWPSubscriptionSubscribed",GXType.Boolean,4,0) ,
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmBC000J10;
       prmBC000J10 = new Object[] {
       };
       Object[] prmBC000J11;
       prmBC000J11 = new Object[] {
       new ParDef("WWPSubscriptionEntityRecordId",GXType.VarChar,2000,0) ,
       new ParDef("WWPSubscriptionEntityRecordDes",GXType.VarChar,200,0) ,
       new ParDef("WWPSubscriptionRoleId",GXType.Char,40,0){Nullable=true} ,
       new ParDef("WWPSubscriptionSubscribed",GXType.Boolean,4,0) ,
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
       new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
       };
       Object[] prmBC000J12;
       prmBC000J12 = new Object[] {
       new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
       };
       Object[] prmBC000J13;
       prmBC000J13 = new Object[] {
       new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
       };
       Object[] prmBC000J14;
       prmBC000J14 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmBC000J15;
       prmBC000J15 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmBC000J16;
       prmBC000J16 = new Object[] {
       new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC000J2", "SELECT WWPSubscriptionId, WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId, WWPSubscriptionSubscribed, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Subscription WHERE WWPSubscriptionId = :WWPSubscriptionId  FOR UPDATE OF WWP_Subscription",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000J3", "SELECT WWPSubscriptionId, WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId, WWPSubscriptionSubscribed, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Subscription WHERE WWPSubscriptionId = :WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000J4", "SELECT WWPEntityId, WWPNotificationDefinitionDescr FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000J5", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000J6", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000J7", "SELECT T2.WWPEntityId, TM1.WWPSubscriptionId, T2.WWPNotificationDefinitionDescr, T3.WWPEntityName, T4.WWPUserExtendedFullName, TM1.WWPSubscriptionEntityRecordId, TM1.WWPSubscriptionEntityRecordDes, TM1.WWPSubscriptionRoleId, TM1.WWPSubscriptionSubscribed, TM1.WWPNotificationDefinitionId, TM1.WWPUserExtendedId FROM (((WWP_Subscription TM1 INNER JOIN WWP_NotificationDefinition T2 ON T2.WWPNotificationDefinitionId = TM1.WWPNotificationDefinitionId) INNER JOIN WWP_Entity T3 ON T3.WWPEntityId = T2.WWPEntityId) LEFT JOIN WWP_UserExtended T4 ON T4.WWPUserExtendedId = TM1.WWPUserExtendedId) WHERE TM1.WWPSubscriptionId = :WWPSubscriptionId ORDER BY TM1.WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J7,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000J8", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE WWPSubscriptionId = :WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000J9", "SAVEPOINT gxupdate;INSERT INTO WWP_Subscription(WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId, WWPSubscriptionSubscribed, WWPNotificationDefinitionId, WWPUserExtendedId) VALUES(:WWPSubscriptionEntityRecordId, :WWPSubscriptionEntityRecordDes, :WWPSubscriptionRoleId, :WWPSubscriptionSubscribed, :WWPNotificationDefinitionId, :WWPUserExtendedId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000J9)
          ,new CursorDef("BC000J10", "SELECT currval('WWPSubscriptionId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J10,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000J11", "SAVEPOINT gxupdate;UPDATE WWP_Subscription SET WWPSubscriptionEntityRecordId=:WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes=:WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId=:WWPSubscriptionRoleId, WWPSubscriptionSubscribed=:WWPSubscriptionSubscribed, WWPNotificationDefinitionId=:WWPNotificationDefinitionId, WWPUserExtendedId=:WWPUserExtendedId  WHERE WWPSubscriptionId = :WWPSubscriptionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000J11)
          ,new CursorDef("BC000J12", "SAVEPOINT gxupdate;DELETE FROM WWP_Subscription  WHERE WWPSubscriptionId = :WWPSubscriptionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000J12)
          ,new CursorDef("BC000J13", "SELECT WWPEntityId, WWPNotificationDefinitionDescr FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J13,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000J14", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J14,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000J15", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J15,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000J16", "SELECT T2.WWPEntityId, TM1.WWPSubscriptionId, T2.WWPNotificationDefinitionDescr, T3.WWPEntityName, T4.WWPUserExtendedFullName, TM1.WWPSubscriptionEntityRecordId, TM1.WWPSubscriptionEntityRecordDes, TM1.WWPSubscriptionRoleId, TM1.WWPSubscriptionSubscribed, TM1.WWPNotificationDefinitionId, TM1.WWPUserExtendedId FROM (((WWP_Subscription TM1 INNER JOIN WWP_NotificationDefinition T2 ON T2.WWPNotificationDefinitionId = TM1.WWPNotificationDefinitionId) INNER JOIN WWP_Entity T3 ON T3.WWPEntityId = T2.WWPEntityId) LEFT JOIN WWP_UserExtended T4 ON T4.WWPUserExtendedId = TM1.WWPUserExtendedId) WHERE TM1.WWPSubscriptionId = :WWPSubscriptionId ORDER BY TM1.WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J16,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[3])[0] = rslt.getString(4, 40);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((bool[]) buf[5])[0] = rslt.getBool(5);
             ((long[]) buf[6])[0] = rslt.getLong(6);
             ((string[]) buf[7])[0] = rslt.getString(7, 40);
             ((bool[]) buf[8])[0] = rslt.wasNull(7);
             return;
          case 1 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getString(4, 40);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((bool[]) buf[5])[0] = rslt.getBool(5);
             ((long[]) buf[6])[0] = rslt.getLong(6);
             ((string[]) buf[7])[0] = rslt.getString(7, 40);
             ((bool[]) buf[8])[0] = rslt.wasNull(7);
             return;
          case 2 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 4 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 5 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((long[]) buf[1])[0] = rslt.getLong(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getString(8, 40);
             ((bool[]) buf[8])[0] = rslt.wasNull(8);
             ((bool[]) buf[9])[0] = rslt.getBool(9);
             ((long[]) buf[10])[0] = rslt.getLong(10);
             ((string[]) buf[11])[0] = rslt.getString(11, 40);
             ((bool[]) buf[12])[0] = rslt.wasNull(11);
             return;
          case 6 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 8 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 11 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 12 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 13 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 14 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((long[]) buf[1])[0] = rslt.getLong(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getString(8, 40);
             ((bool[]) buf[8])[0] = rslt.wasNull(8);
             ((bool[]) buf[9])[0] = rslt.getBool(9);
             ((long[]) buf[10])[0] = rslt.getLong(10);
             ((string[]) buf[11])[0] = rslt.getString(11, 40);
             ((bool[]) buf[12])[0] = rslt.wasNull(11);
             return;
    }
 }

}

}
