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
namespace GeneXus.Programs.wwpbaseobjects.sms {
   public class wwp_sms_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_sms_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_sms_bc( IGxContext context )
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
         ReadRow0K30( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0K30( ) ;
         standaloneModal( ) ;
         AddRow0K30( ) ;
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
               Z138WWPSMSId = A138WWPSMSId;
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

      protected void CONFIRM_0K0( )
      {
         BeforeValidate0K30( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0K30( ) ;
            }
            else
            {
               CheckExtendedTable0K30( ) ;
               if ( AnyError == 0 )
               {
                  ZM0K30( 6) ;
               }
               CloseExtendedTableCursors0K30( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0K30( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z139WWPSMSStatus = A139WWPSMSStatus;
            Z145WWPSMSCreated = A145WWPSMSCreated;
            Z146WWPSMSScheduled = A146WWPSMSScheduled;
            Z140WWPSMSProcessed = A140WWPSMSProcessed;
            Z127WWPNotificationId = A127WWPNotificationId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z129WWPNotificationCreated = A129WWPNotificationCreated;
         }
         if ( GX_JID == -5 )
         {
            Z138WWPSMSId = A138WWPSMSId;
            Z142WWPSMSMessage = A142WWPSMSMessage;
            Z143WWPSMSSenderNumber = A143WWPSMSSenderNumber;
            Z144WWPSMSRecipientNumbers = A144WWPSMSRecipientNumbers;
            Z139WWPSMSStatus = A139WWPSMSStatus;
            Z145WWPSMSCreated = A145WWPSMSCreated;
            Z146WWPSMSScheduled = A146WWPSMSScheduled;
            Z140WWPSMSProcessed = A140WWPSMSProcessed;
            Z141WWPSMSDetail = A141WWPSMSDetail;
            Z127WWPNotificationId = A127WWPNotificationId;
            Z129WWPNotificationCreated = A129WWPNotificationCreated;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A139WWPSMSStatus) && ( Gx_BScreen == 0 ) )
         {
            A139WWPSMSStatus = 1;
         }
         if ( IsIns( )  && (DateTime.MinValue==A145WWPSMSCreated) && ( Gx_BScreen == 0 ) )
         {
            A145WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( IsIns( )  && (DateTime.MinValue==A146WWPSMSScheduled) && ( Gx_BScreen == 0 ) )
         {
            A146WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0K30( )
      {
         /* Using cursor BC000K5 */
         pr_default.execute(3, new Object[] {A138WWPSMSId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound30 = 1;
            A142WWPSMSMessage = BC000K5_A142WWPSMSMessage[0];
            A143WWPSMSSenderNumber = BC000K5_A143WWPSMSSenderNumber[0];
            A144WWPSMSRecipientNumbers = BC000K5_A144WWPSMSRecipientNumbers[0];
            A139WWPSMSStatus = BC000K5_A139WWPSMSStatus[0];
            A145WWPSMSCreated = BC000K5_A145WWPSMSCreated[0];
            A146WWPSMSScheduled = BC000K5_A146WWPSMSScheduled[0];
            A140WWPSMSProcessed = BC000K5_A140WWPSMSProcessed[0];
            n140WWPSMSProcessed = BC000K5_n140WWPSMSProcessed[0];
            A141WWPSMSDetail = BC000K5_A141WWPSMSDetail[0];
            n141WWPSMSDetail = BC000K5_n141WWPSMSDetail[0];
            A129WWPNotificationCreated = BC000K5_A129WWPNotificationCreated[0];
            A127WWPNotificationId = BC000K5_A127WWPNotificationId[0];
            n127WWPNotificationId = BC000K5_n127WWPNotificationId[0];
            ZM0K30( -5) ;
         }
         pr_default.close(3);
         OnLoadActions0K30( ) ;
      }

      protected void OnLoadActions0K30( )
      {
      }

      protected void CheckExtendedTable0K30( )
      {
         standaloneModal( ) ;
         if ( ! ( ( A139WWPSMSStatus == 1 ) || ( A139WWPSMSStatus == 2 ) || ( A139WWPSMSStatus == 3 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "SMS Status", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000K4 */
         pr_default.execute(2, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A127WWPNotificationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Notification", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
            }
         }
         A129WWPNotificationCreated = BC000K4_A129WWPNotificationCreated[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0K30( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0K30( )
      {
         /* Using cursor BC000K6 */
         pr_default.execute(4, new Object[] {A138WWPSMSId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound30 = 1;
         }
         else
         {
            RcdFound30 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000K3 */
         pr_default.execute(1, new Object[] {A138WWPSMSId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0K30( 5) ;
            RcdFound30 = 1;
            A138WWPSMSId = BC000K3_A138WWPSMSId[0];
            A142WWPSMSMessage = BC000K3_A142WWPSMSMessage[0];
            A143WWPSMSSenderNumber = BC000K3_A143WWPSMSSenderNumber[0];
            A144WWPSMSRecipientNumbers = BC000K3_A144WWPSMSRecipientNumbers[0];
            A139WWPSMSStatus = BC000K3_A139WWPSMSStatus[0];
            A145WWPSMSCreated = BC000K3_A145WWPSMSCreated[0];
            A146WWPSMSScheduled = BC000K3_A146WWPSMSScheduled[0];
            A140WWPSMSProcessed = BC000K3_A140WWPSMSProcessed[0];
            n140WWPSMSProcessed = BC000K3_n140WWPSMSProcessed[0];
            A141WWPSMSDetail = BC000K3_A141WWPSMSDetail[0];
            n141WWPSMSDetail = BC000K3_n141WWPSMSDetail[0];
            A127WWPNotificationId = BC000K3_A127WWPNotificationId[0];
            n127WWPNotificationId = BC000K3_n127WWPNotificationId[0];
            Z138WWPSMSId = A138WWPSMSId;
            sMode30 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0K30( ) ;
            if ( AnyError == 1 )
            {
               RcdFound30 = 0;
               InitializeNonKey0K30( ) ;
            }
            Gx_mode = sMode30;
         }
         else
         {
            RcdFound30 = 0;
            InitializeNonKey0K30( ) ;
            sMode30 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode30;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0K30( ) ;
         if ( RcdFound30 == 0 )
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
         CONFIRM_0K0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0K30( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000K2 */
            pr_default.execute(0, new Object[] {A138WWPSMSId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_SMS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z139WWPSMSStatus != BC000K2_A139WWPSMSStatus[0] ) || ( Z145WWPSMSCreated != BC000K2_A145WWPSMSCreated[0] ) || ( Z146WWPSMSScheduled != BC000K2_A146WWPSMSScheduled[0] ) || ( Z140WWPSMSProcessed != BC000K2_A140WWPSMSProcessed[0] ) || ( Z127WWPNotificationId != BC000K2_A127WWPNotificationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_SMS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0K30( )
      {
         BeforeValidate0K30( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0K30( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0K30( 0) ;
            CheckOptimisticConcurrency0K30( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0K30( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0K30( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000K7 */
                     pr_default.execute(5, new Object[] {A142WWPSMSMessage, A143WWPSMSSenderNumber, A144WWPSMSRecipientNumbers, A139WWPSMSStatus, A145WWPSMSCreated, A146WWPSMSScheduled, n140WWPSMSProcessed, A140WWPSMSProcessed, n141WWPSMSDetail, A141WWPSMSDetail, n127WWPNotificationId, A127WWPNotificationId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000K8 */
                     pr_default.execute(6);
                     A138WWPSMSId = BC000K8_A138WWPSMSId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
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
               Load0K30( ) ;
            }
            EndLevel0K30( ) ;
         }
         CloseExtendedTableCursors0K30( ) ;
      }

      protected void Update0K30( )
      {
         BeforeValidate0K30( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0K30( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0K30( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0K30( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0K30( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000K9 */
                     pr_default.execute(7, new Object[] {A142WWPSMSMessage, A143WWPSMSSenderNumber, A144WWPSMSRecipientNumbers, A139WWPSMSStatus, A145WWPSMSCreated, A146WWPSMSScheduled, n140WWPSMSProcessed, A140WWPSMSProcessed, n141WWPSMSDetail, A141WWPSMSDetail, n127WWPNotificationId, A127WWPNotificationId, A138WWPSMSId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_SMS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0K30( ) ;
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
            EndLevel0K30( ) ;
         }
         CloseExtendedTableCursors0K30( ) ;
      }

      protected void DeferredUpdate0K30( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0K30( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0K30( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0K30( ) ;
            AfterConfirm0K30( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0K30( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000K10 */
                  pr_default.execute(8, new Object[] {A138WWPSMSId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
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
         sMode30 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0K30( ) ;
         Gx_mode = sMode30;
      }

      protected void OnDeleteControls0K30( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000K11 */
            pr_default.execute(9, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
            A129WWPNotificationCreated = BC000K11_A129WWPNotificationCreated[0];
            pr_default.close(9);
         }
      }

      protected void EndLevel0K30( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0K30( ) ;
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

      public void ScanKeyStart0K30( )
      {
         /* Using cursor BC000K12 */
         pr_default.execute(10, new Object[] {A138WWPSMSId});
         RcdFound30 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound30 = 1;
            A138WWPSMSId = BC000K12_A138WWPSMSId[0];
            A142WWPSMSMessage = BC000K12_A142WWPSMSMessage[0];
            A143WWPSMSSenderNumber = BC000K12_A143WWPSMSSenderNumber[0];
            A144WWPSMSRecipientNumbers = BC000K12_A144WWPSMSRecipientNumbers[0];
            A139WWPSMSStatus = BC000K12_A139WWPSMSStatus[0];
            A145WWPSMSCreated = BC000K12_A145WWPSMSCreated[0];
            A146WWPSMSScheduled = BC000K12_A146WWPSMSScheduled[0];
            A140WWPSMSProcessed = BC000K12_A140WWPSMSProcessed[0];
            n140WWPSMSProcessed = BC000K12_n140WWPSMSProcessed[0];
            A141WWPSMSDetail = BC000K12_A141WWPSMSDetail[0];
            n141WWPSMSDetail = BC000K12_n141WWPSMSDetail[0];
            A129WWPNotificationCreated = BC000K12_A129WWPNotificationCreated[0];
            A127WWPNotificationId = BC000K12_A127WWPNotificationId[0];
            n127WWPNotificationId = BC000K12_n127WWPNotificationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0K30( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound30 = 0;
         ScanKeyLoad0K30( ) ;
      }

      protected void ScanKeyLoad0K30( )
      {
         sMode30 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound30 = 1;
            A138WWPSMSId = BC000K12_A138WWPSMSId[0];
            A142WWPSMSMessage = BC000K12_A142WWPSMSMessage[0];
            A143WWPSMSSenderNumber = BC000K12_A143WWPSMSSenderNumber[0];
            A144WWPSMSRecipientNumbers = BC000K12_A144WWPSMSRecipientNumbers[0];
            A139WWPSMSStatus = BC000K12_A139WWPSMSStatus[0];
            A145WWPSMSCreated = BC000K12_A145WWPSMSCreated[0];
            A146WWPSMSScheduled = BC000K12_A146WWPSMSScheduled[0];
            A140WWPSMSProcessed = BC000K12_A140WWPSMSProcessed[0];
            n140WWPSMSProcessed = BC000K12_n140WWPSMSProcessed[0];
            A141WWPSMSDetail = BC000K12_A141WWPSMSDetail[0];
            n141WWPSMSDetail = BC000K12_n141WWPSMSDetail[0];
            A129WWPNotificationCreated = BC000K12_A129WWPNotificationCreated[0];
            A127WWPNotificationId = BC000K12_A127WWPNotificationId[0];
            n127WWPNotificationId = BC000K12_n127WWPNotificationId[0];
         }
         Gx_mode = sMode30;
      }

      protected void ScanKeyEnd0K30( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0K30( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0K30( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0K30( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0K30( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0K30( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0K30( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0K30( )
      {
      }

      protected void send_integrity_lvl_hashes0K30( )
      {
      }

      protected void AddRow0K30( )
      {
         VarsToRow30( bcwwpbaseobjects_sms_WWP_SMS) ;
      }

      protected void ReadRow0K30( )
      {
         RowToVars30( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
      }

      protected void InitializeNonKey0K30( )
      {
         A142WWPSMSMessage = "";
         A143WWPSMSSenderNumber = "";
         A144WWPSMSRecipientNumbers = "";
         A140WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         n140WWPSMSProcessed = false;
         A141WWPSMSDetail = "";
         n141WWPSMSDetail = false;
         A127WWPNotificationId = 0;
         n127WWPNotificationId = false;
         A129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A139WWPSMSStatus = 1;
         A145WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A146WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z139WWPSMSStatus = 0;
         Z145WWPSMSCreated = (DateTime)(DateTime.MinValue);
         Z146WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         Z140WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         Z127WWPNotificationId = 0;
      }

      protected void InitAll0K30( )
      {
         A138WWPSMSId = 0;
         InitializeNonKey0K30( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A139WWPSMSStatus = i139WWPSMSStatus;
         A145WWPSMSCreated = i145WWPSMSCreated;
         A146WWPSMSScheduled = i146WWPSMSScheduled;
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

      public void VarsToRow30( GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS obj30 )
      {
         obj30.gxTpr_Mode = Gx_mode;
         obj30.gxTpr_Wwpsmsmessage = A142WWPSMSMessage;
         obj30.gxTpr_Wwpsmssendernumber = A143WWPSMSSenderNumber;
         obj30.gxTpr_Wwpsmsrecipientnumbers = A144WWPSMSRecipientNumbers;
         obj30.gxTpr_Wwpsmsprocessed = A140WWPSMSProcessed;
         obj30.gxTpr_Wwpsmsdetail = A141WWPSMSDetail;
         obj30.gxTpr_Wwpnotificationid = A127WWPNotificationId;
         obj30.gxTpr_Wwpnotificationcreated = A129WWPNotificationCreated;
         obj30.gxTpr_Wwpsmsstatus = A139WWPSMSStatus;
         obj30.gxTpr_Wwpsmscreated = A145WWPSMSCreated;
         obj30.gxTpr_Wwpsmsscheduled = A146WWPSMSScheduled;
         obj30.gxTpr_Wwpsmsid = A138WWPSMSId;
         obj30.gxTpr_Wwpsmsid_Z = Z138WWPSMSId;
         obj30.gxTpr_Wwpsmsstatus_Z = Z139WWPSMSStatus;
         obj30.gxTpr_Wwpsmscreated_Z = Z145WWPSMSCreated;
         obj30.gxTpr_Wwpsmsscheduled_Z = Z146WWPSMSScheduled;
         obj30.gxTpr_Wwpsmsprocessed_Z = Z140WWPSMSProcessed;
         obj30.gxTpr_Wwpnotificationid_Z = Z127WWPNotificationId;
         obj30.gxTpr_Wwpnotificationcreated_Z = Z129WWPNotificationCreated;
         obj30.gxTpr_Wwpsmsprocessed_N = (short)(Convert.ToInt16(n140WWPSMSProcessed));
         obj30.gxTpr_Wwpsmsdetail_N = (short)(Convert.ToInt16(n141WWPSMSDetail));
         obj30.gxTpr_Wwpnotificationid_N = (short)(Convert.ToInt16(n127WWPNotificationId));
         obj30.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow30( GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS obj30 )
      {
         obj30.gxTpr_Wwpsmsid = A138WWPSMSId;
         return  ;
      }

      public void RowToVars30( GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS obj30 ,
                               int forceLoad )
      {
         Gx_mode = obj30.gxTpr_Mode;
         A142WWPSMSMessage = obj30.gxTpr_Wwpsmsmessage;
         A143WWPSMSSenderNumber = obj30.gxTpr_Wwpsmssendernumber;
         A144WWPSMSRecipientNumbers = obj30.gxTpr_Wwpsmsrecipientnumbers;
         A140WWPSMSProcessed = obj30.gxTpr_Wwpsmsprocessed;
         n140WWPSMSProcessed = false;
         A141WWPSMSDetail = obj30.gxTpr_Wwpsmsdetail;
         n141WWPSMSDetail = false;
         A127WWPNotificationId = obj30.gxTpr_Wwpnotificationid;
         n127WWPNotificationId = false;
         A129WWPNotificationCreated = obj30.gxTpr_Wwpnotificationcreated;
         A139WWPSMSStatus = obj30.gxTpr_Wwpsmsstatus;
         A145WWPSMSCreated = obj30.gxTpr_Wwpsmscreated;
         A146WWPSMSScheduled = obj30.gxTpr_Wwpsmsscheduled;
         A138WWPSMSId = obj30.gxTpr_Wwpsmsid;
         Z138WWPSMSId = obj30.gxTpr_Wwpsmsid_Z;
         Z139WWPSMSStatus = obj30.gxTpr_Wwpsmsstatus_Z;
         Z145WWPSMSCreated = obj30.gxTpr_Wwpsmscreated_Z;
         Z146WWPSMSScheduled = obj30.gxTpr_Wwpsmsscheduled_Z;
         Z140WWPSMSProcessed = obj30.gxTpr_Wwpsmsprocessed_Z;
         Z127WWPNotificationId = obj30.gxTpr_Wwpnotificationid_Z;
         Z129WWPNotificationCreated = obj30.gxTpr_Wwpnotificationcreated_Z;
         n140WWPSMSProcessed = (bool)(Convert.ToBoolean(obj30.gxTpr_Wwpsmsprocessed_N));
         n141WWPSMSDetail = (bool)(Convert.ToBoolean(obj30.gxTpr_Wwpsmsdetail_N));
         n127WWPNotificationId = (bool)(Convert.ToBoolean(obj30.gxTpr_Wwpnotificationid_N));
         Gx_mode = obj30.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A138WWPSMSId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0K30( ) ;
         ScanKeyStart0K30( ) ;
         if ( RcdFound30 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z138WWPSMSId = A138WWPSMSId;
         }
         ZM0K30( -5) ;
         OnLoadActions0K30( ) ;
         AddRow0K30( ) ;
         ScanKeyEnd0K30( ) ;
         if ( RcdFound30 == 0 )
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
         RowToVars30( bcwwpbaseobjects_sms_WWP_SMS, 0) ;
         ScanKeyStart0K30( ) ;
         if ( RcdFound30 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z138WWPSMSId = A138WWPSMSId;
         }
         ZM0K30( -5) ;
         OnLoadActions0K30( ) ;
         AddRow0K30( ) ;
         ScanKeyEnd0K30( ) ;
         if ( RcdFound30 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0K30( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0K30( ) ;
         }
         else
         {
            if ( RcdFound30 == 1 )
            {
               if ( A138WWPSMSId != Z138WWPSMSId )
               {
                  A138WWPSMSId = Z138WWPSMSId;
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
                  Update0K30( ) ;
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
                  if ( A138WWPSMSId != Z138WWPSMSId )
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
                        Insert0K30( ) ;
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
                        Insert0K30( ) ;
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
         RowToVars30( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
         SaveImpl( ) ;
         VarsToRow30( bcwwpbaseobjects_sms_WWP_SMS) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars30( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0K30( ) ;
         AfterTrn( ) ;
         VarsToRow30( bcwwpbaseobjects_sms_WWP_SMS) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow30( bcwwpbaseobjects_sms_WWP_SMS) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS auxBC = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A138WWPSMSId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_sms_WWP_SMS);
               auxBC.Save();
               bcwwpbaseobjects_sms_WWP_SMS.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars30( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
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
         RowToVars30( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0K30( ) ;
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
               VarsToRow30( bcwwpbaseobjects_sms_WWP_SMS) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow30( bcwwpbaseobjects_sms_WWP_SMS) ;
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
         RowToVars30( bcwwpbaseobjects_sms_WWP_SMS, 0) ;
         GetKey0K30( ) ;
         if ( RcdFound30 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A138WWPSMSId != Z138WWPSMSId )
            {
               A138WWPSMSId = Z138WWPSMSId;
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
            if ( A138WWPSMSId != Z138WWPSMSId )
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
         context.RollbackDataStores("wwpbaseobjects.sms.wwp_sms_bc",pr_default);
         VarsToRow30( bcwwpbaseobjects_sms_WWP_SMS) ;
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
         Gx_mode = bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_sms_WWP_SMS )
         {
            bcwwpbaseobjects_sms_WWP_SMS = (GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow30( bcwwpbaseobjects_sms_WWP_SMS) ;
            }
            else
            {
               RowToVars30( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars30( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_SMS WWP_SMS_BC
      {
         get {
            return bcwwpbaseobjects_sms_WWP_SMS ;
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
            return "sms_Execute" ;
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
         Z145WWPSMSCreated = (DateTime)(DateTime.MinValue);
         A145WWPSMSCreated = (DateTime)(DateTime.MinValue);
         Z146WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         A146WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         Z140WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         A140WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         Z129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z142WWPSMSMessage = "";
         A142WWPSMSMessage = "";
         Z143WWPSMSSenderNumber = "";
         A143WWPSMSSenderNumber = "";
         Z144WWPSMSRecipientNumbers = "";
         A144WWPSMSRecipientNumbers = "";
         Z141WWPSMSDetail = "";
         A141WWPSMSDetail = "";
         BC000K5_A138WWPSMSId = new long[1] ;
         BC000K5_A142WWPSMSMessage = new string[] {""} ;
         BC000K5_A143WWPSMSSenderNumber = new string[] {""} ;
         BC000K5_A144WWPSMSRecipientNumbers = new string[] {""} ;
         BC000K5_A139WWPSMSStatus = new short[1] ;
         BC000K5_A145WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         BC000K5_A146WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000K5_A140WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000K5_n140WWPSMSProcessed = new bool[] {false} ;
         BC000K5_A141WWPSMSDetail = new string[] {""} ;
         BC000K5_n141WWPSMSDetail = new bool[] {false} ;
         BC000K5_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000K5_A127WWPNotificationId = new long[1] ;
         BC000K5_n127WWPNotificationId = new bool[] {false} ;
         BC000K4_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000K6_A138WWPSMSId = new long[1] ;
         BC000K3_A138WWPSMSId = new long[1] ;
         BC000K3_A142WWPSMSMessage = new string[] {""} ;
         BC000K3_A143WWPSMSSenderNumber = new string[] {""} ;
         BC000K3_A144WWPSMSRecipientNumbers = new string[] {""} ;
         BC000K3_A139WWPSMSStatus = new short[1] ;
         BC000K3_A145WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         BC000K3_A146WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000K3_A140WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000K3_n140WWPSMSProcessed = new bool[] {false} ;
         BC000K3_A141WWPSMSDetail = new string[] {""} ;
         BC000K3_n141WWPSMSDetail = new bool[] {false} ;
         BC000K3_A127WWPNotificationId = new long[1] ;
         BC000K3_n127WWPNotificationId = new bool[] {false} ;
         sMode30 = "";
         BC000K2_A138WWPSMSId = new long[1] ;
         BC000K2_A142WWPSMSMessage = new string[] {""} ;
         BC000K2_A143WWPSMSSenderNumber = new string[] {""} ;
         BC000K2_A144WWPSMSRecipientNumbers = new string[] {""} ;
         BC000K2_A139WWPSMSStatus = new short[1] ;
         BC000K2_A145WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         BC000K2_A146WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000K2_A140WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000K2_n140WWPSMSProcessed = new bool[] {false} ;
         BC000K2_A141WWPSMSDetail = new string[] {""} ;
         BC000K2_n141WWPSMSDetail = new bool[] {false} ;
         BC000K2_A127WWPNotificationId = new long[1] ;
         BC000K2_n127WWPNotificationId = new bool[] {false} ;
         BC000K8_A138WWPSMSId = new long[1] ;
         BC000K11_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000K12_A138WWPSMSId = new long[1] ;
         BC000K12_A142WWPSMSMessage = new string[] {""} ;
         BC000K12_A143WWPSMSSenderNumber = new string[] {""} ;
         BC000K12_A144WWPSMSRecipientNumbers = new string[] {""} ;
         BC000K12_A139WWPSMSStatus = new short[1] ;
         BC000K12_A145WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         BC000K12_A146WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000K12_A140WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000K12_n140WWPSMSProcessed = new bool[] {false} ;
         BC000K12_A141WWPSMSDetail = new string[] {""} ;
         BC000K12_n141WWPSMSDetail = new bool[] {false} ;
         BC000K12_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000K12_A127WWPNotificationId = new long[1] ;
         BC000K12_n127WWPNotificationId = new bool[] {false} ;
         i145WWPSMSCreated = (DateTime)(DateTime.MinValue);
         i146WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sms_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sms_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sms_bc__default(),
            new Object[][] {
                new Object[] {
               BC000K2_A138WWPSMSId, BC000K2_A142WWPSMSMessage, BC000K2_A143WWPSMSSenderNumber, BC000K2_A144WWPSMSRecipientNumbers, BC000K2_A139WWPSMSStatus, BC000K2_A145WWPSMSCreated, BC000K2_A146WWPSMSScheduled, BC000K2_A140WWPSMSProcessed, BC000K2_n140WWPSMSProcessed, BC000K2_A141WWPSMSDetail,
               BC000K2_n141WWPSMSDetail, BC000K2_A127WWPNotificationId, BC000K2_n127WWPNotificationId
               }
               , new Object[] {
               BC000K3_A138WWPSMSId, BC000K3_A142WWPSMSMessage, BC000K3_A143WWPSMSSenderNumber, BC000K3_A144WWPSMSRecipientNumbers, BC000K3_A139WWPSMSStatus, BC000K3_A145WWPSMSCreated, BC000K3_A146WWPSMSScheduled, BC000K3_A140WWPSMSProcessed, BC000K3_n140WWPSMSProcessed, BC000K3_A141WWPSMSDetail,
               BC000K3_n141WWPSMSDetail, BC000K3_A127WWPNotificationId, BC000K3_n127WWPNotificationId
               }
               , new Object[] {
               BC000K4_A129WWPNotificationCreated
               }
               , new Object[] {
               BC000K5_A138WWPSMSId, BC000K5_A142WWPSMSMessage, BC000K5_A143WWPSMSSenderNumber, BC000K5_A144WWPSMSRecipientNumbers, BC000K5_A139WWPSMSStatus, BC000K5_A145WWPSMSCreated, BC000K5_A146WWPSMSScheduled, BC000K5_A140WWPSMSProcessed, BC000K5_n140WWPSMSProcessed, BC000K5_A141WWPSMSDetail,
               BC000K5_n141WWPSMSDetail, BC000K5_A129WWPNotificationCreated, BC000K5_A127WWPNotificationId, BC000K5_n127WWPNotificationId
               }
               , new Object[] {
               BC000K6_A138WWPSMSId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000K8_A138WWPSMSId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000K11_A129WWPNotificationCreated
               }
               , new Object[] {
               BC000K12_A138WWPSMSId, BC000K12_A142WWPSMSMessage, BC000K12_A143WWPSMSSenderNumber, BC000K12_A144WWPSMSRecipientNumbers, BC000K12_A139WWPSMSStatus, BC000K12_A145WWPSMSCreated, BC000K12_A146WWPSMSScheduled, BC000K12_A140WWPSMSProcessed, BC000K12_n140WWPSMSProcessed, BC000K12_A141WWPSMSDetail,
               BC000K12_n141WWPSMSDetail, BC000K12_A129WWPNotificationCreated, BC000K12_A127WWPNotificationId, BC000K12_n127WWPNotificationId
               }
            }
         );
         Z146WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A146WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i146WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z145WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A145WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i145WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z139WWPSMSStatus = 1;
         A139WWPSMSStatus = 1;
         i139WWPSMSStatus = 1;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z139WWPSMSStatus ;
      private short A139WWPSMSStatus ;
      private short Gx_BScreen ;
      private short RcdFound30 ;
      private short i139WWPSMSStatus ;
      private int trnEnded ;
      private long Z138WWPSMSId ;
      private long A138WWPSMSId ;
      private long Z127WWPNotificationId ;
      private long A127WWPNotificationId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode30 ;
      private DateTime Z145WWPSMSCreated ;
      private DateTime A145WWPSMSCreated ;
      private DateTime Z146WWPSMSScheduled ;
      private DateTime A146WWPSMSScheduled ;
      private DateTime Z140WWPSMSProcessed ;
      private DateTime A140WWPSMSProcessed ;
      private DateTime Z129WWPNotificationCreated ;
      private DateTime A129WWPNotificationCreated ;
      private DateTime i145WWPSMSCreated ;
      private DateTime i146WWPSMSScheduled ;
      private bool n140WWPSMSProcessed ;
      private bool n141WWPSMSDetail ;
      private bool n127WWPNotificationId ;
      private string Z142WWPSMSMessage ;
      private string A142WWPSMSMessage ;
      private string Z143WWPSMSSenderNumber ;
      private string A143WWPSMSSenderNumber ;
      private string Z144WWPSMSRecipientNumbers ;
      private string A144WWPSMSRecipientNumbers ;
      private string Z141WWPSMSDetail ;
      private string A141WWPSMSDetail ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC000K5_A138WWPSMSId ;
      private string[] BC000K5_A142WWPSMSMessage ;
      private string[] BC000K5_A143WWPSMSSenderNumber ;
      private string[] BC000K5_A144WWPSMSRecipientNumbers ;
      private short[] BC000K5_A139WWPSMSStatus ;
      private DateTime[] BC000K5_A145WWPSMSCreated ;
      private DateTime[] BC000K5_A146WWPSMSScheduled ;
      private DateTime[] BC000K5_A140WWPSMSProcessed ;
      private bool[] BC000K5_n140WWPSMSProcessed ;
      private string[] BC000K5_A141WWPSMSDetail ;
      private bool[] BC000K5_n141WWPSMSDetail ;
      private DateTime[] BC000K5_A129WWPNotificationCreated ;
      private long[] BC000K5_A127WWPNotificationId ;
      private bool[] BC000K5_n127WWPNotificationId ;
      private DateTime[] BC000K4_A129WWPNotificationCreated ;
      private long[] BC000K6_A138WWPSMSId ;
      private long[] BC000K3_A138WWPSMSId ;
      private string[] BC000K3_A142WWPSMSMessage ;
      private string[] BC000K3_A143WWPSMSSenderNumber ;
      private string[] BC000K3_A144WWPSMSRecipientNumbers ;
      private short[] BC000K3_A139WWPSMSStatus ;
      private DateTime[] BC000K3_A145WWPSMSCreated ;
      private DateTime[] BC000K3_A146WWPSMSScheduled ;
      private DateTime[] BC000K3_A140WWPSMSProcessed ;
      private bool[] BC000K3_n140WWPSMSProcessed ;
      private string[] BC000K3_A141WWPSMSDetail ;
      private bool[] BC000K3_n141WWPSMSDetail ;
      private long[] BC000K3_A127WWPNotificationId ;
      private bool[] BC000K3_n127WWPNotificationId ;
      private long[] BC000K2_A138WWPSMSId ;
      private string[] BC000K2_A142WWPSMSMessage ;
      private string[] BC000K2_A143WWPSMSSenderNumber ;
      private string[] BC000K2_A144WWPSMSRecipientNumbers ;
      private short[] BC000K2_A139WWPSMSStatus ;
      private DateTime[] BC000K2_A145WWPSMSCreated ;
      private DateTime[] BC000K2_A146WWPSMSScheduled ;
      private DateTime[] BC000K2_A140WWPSMSProcessed ;
      private bool[] BC000K2_n140WWPSMSProcessed ;
      private string[] BC000K2_A141WWPSMSDetail ;
      private bool[] BC000K2_n141WWPSMSDetail ;
      private long[] BC000K2_A127WWPNotificationId ;
      private bool[] BC000K2_n127WWPNotificationId ;
      private long[] BC000K8_A138WWPSMSId ;
      private DateTime[] BC000K11_A129WWPNotificationCreated ;
      private long[] BC000K12_A138WWPSMSId ;
      private string[] BC000K12_A142WWPSMSMessage ;
      private string[] BC000K12_A143WWPSMSSenderNumber ;
      private string[] BC000K12_A144WWPSMSRecipientNumbers ;
      private short[] BC000K12_A139WWPSMSStatus ;
      private DateTime[] BC000K12_A145WWPSMSCreated ;
      private DateTime[] BC000K12_A146WWPSMSScheduled ;
      private DateTime[] BC000K12_A140WWPSMSProcessed ;
      private bool[] BC000K12_n140WWPSMSProcessed ;
      private string[] BC000K12_A141WWPSMSDetail ;
      private bool[] BC000K12_n141WWPSMSDetail ;
      private DateTime[] BC000K12_A129WWPNotificationCreated ;
      private long[] BC000K12_A127WWPNotificationId ;
      private bool[] BC000K12_n127WWPNotificationId ;
      private GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS bcwwpbaseobjects_sms_WWP_SMS ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_sms_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_sms_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_sms_bc__default : DataStoreHelperBase, IDataStoreHelper
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
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000K2;
       prmBC000K2 = new Object[] {
       new ParDef("WWPSMSId",GXType.Int64,10,0)
       };
       Object[] prmBC000K3;
       prmBC000K3 = new Object[] {
       new ParDef("WWPSMSId",GXType.Int64,10,0)
       };
       Object[] prmBC000K4;
       prmBC000K4 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmBC000K5;
       prmBC000K5 = new Object[] {
       new ParDef("WWPSMSId",GXType.Int64,10,0)
       };
       Object[] prmBC000K6;
       prmBC000K6 = new Object[] {
       new ParDef("WWPSMSId",GXType.Int64,10,0)
       };
       Object[] prmBC000K7;
       prmBC000K7 = new Object[] {
       new ParDef("WWPSMSMessage",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPSMSSenderNumber",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPSMSRecipientNumbers",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPSMSStatus",GXType.Int16,4,0) ,
       new ParDef("WWPSMSCreated",GXType.DateTime2,10,12) ,
       new ParDef("WWPSMSScheduled",GXType.DateTime2,10,12) ,
       new ParDef("WWPSMSProcessed",GXType.DateTime2,10,12){Nullable=true} ,
       new ParDef("WWPSMSDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmBC000K8;
       prmBC000K8 = new Object[] {
       };
       Object[] prmBC000K9;
       prmBC000K9 = new Object[] {
       new ParDef("WWPSMSMessage",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPSMSSenderNumber",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPSMSRecipientNumbers",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPSMSStatus",GXType.Int16,4,0) ,
       new ParDef("WWPSMSCreated",GXType.DateTime2,10,12) ,
       new ParDef("WWPSMSScheduled",GXType.DateTime2,10,12) ,
       new ParDef("WWPSMSProcessed",GXType.DateTime2,10,12){Nullable=true} ,
       new ParDef("WWPSMSDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true} ,
       new ParDef("WWPSMSId",GXType.Int64,10,0)
       };
       Object[] prmBC000K10;
       prmBC000K10 = new Object[] {
       new ParDef("WWPSMSId",GXType.Int64,10,0)
       };
       Object[] prmBC000K11;
       prmBC000K11 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmBC000K12;
       prmBC000K12 = new Object[] {
       new ParDef("WWPSMSId",GXType.Int64,10,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC000K2", "SELECT WWPSMSId, WWPSMSMessage, WWPSMSSenderNumber, WWPSMSRecipientNumbers, WWPSMSStatus, WWPSMSCreated, WWPSMSScheduled, WWPSMSProcessed, WWPSMSDetail, WWPNotificationId FROM WWP_SMS WHERE WWPSMSId = :WWPSMSId  FOR UPDATE OF WWP_SMS",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000K3", "SELECT WWPSMSId, WWPSMSMessage, WWPSMSSenderNumber, WWPSMSRecipientNumbers, WWPSMSStatus, WWPSMSCreated, WWPSMSScheduled, WWPSMSProcessed, WWPSMSDetail, WWPNotificationId FROM WWP_SMS WHERE WWPSMSId = :WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000K4", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000K5", "SELECT TM1.WWPSMSId, TM1.WWPSMSMessage, TM1.WWPSMSSenderNumber, TM1.WWPSMSRecipientNumbers, TM1.WWPSMSStatus, TM1.WWPSMSCreated, TM1.WWPSMSScheduled, TM1.WWPSMSProcessed, TM1.WWPSMSDetail, T2.WWPNotificationCreated, TM1.WWPNotificationId FROM (WWP_SMS TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) WHERE TM1.WWPSMSId = :WWPSMSId ORDER BY TM1.WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000K6", "SELECT WWPSMSId FROM WWP_SMS WHERE WWPSMSId = :WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000K7", "SAVEPOINT gxupdate;INSERT INTO WWP_SMS(WWPSMSMessage, WWPSMSSenderNumber, WWPSMSRecipientNumbers, WWPSMSStatus, WWPSMSCreated, WWPSMSScheduled, WWPSMSProcessed, WWPSMSDetail, WWPNotificationId) VALUES(:WWPSMSMessage, :WWPSMSSenderNumber, :WWPSMSRecipientNumbers, :WWPSMSStatus, :WWPSMSCreated, :WWPSMSScheduled, :WWPSMSProcessed, :WWPSMSDetail, :WWPNotificationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000K7)
          ,new CursorDef("BC000K8", "SELECT currval('WWPSMSId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000K9", "SAVEPOINT gxupdate;UPDATE WWP_SMS SET WWPSMSMessage=:WWPSMSMessage, WWPSMSSenderNumber=:WWPSMSSenderNumber, WWPSMSRecipientNumbers=:WWPSMSRecipientNumbers, WWPSMSStatus=:WWPSMSStatus, WWPSMSCreated=:WWPSMSCreated, WWPSMSScheduled=:WWPSMSScheduled, WWPSMSProcessed=:WWPSMSProcessed, WWPSMSDetail=:WWPSMSDetail, WWPNotificationId=:WWPNotificationId  WHERE WWPSMSId = :WWPSMSId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000K9)
          ,new CursorDef("BC000K10", "SAVEPOINT gxupdate;DELETE FROM WWP_SMS  WHERE WWPSMSId = :WWPSMSId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000K10)
          ,new CursorDef("BC000K11", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K11,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000K12", "SELECT TM1.WWPSMSId, TM1.WWPSMSMessage, TM1.WWPSMSSenderNumber, TM1.WWPSMSRecipientNumbers, TM1.WWPSMSStatus, TM1.WWPSMSCreated, TM1.WWPSMSScheduled, TM1.WWPSMSProcessed, TM1.WWPSMSDetail, T2.WWPNotificationCreated, TM1.WWPNotificationId FROM (WWP_SMS TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) WHERE TM1.WWPSMSId = :WWPSMSId ORDER BY TM1.WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K12,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
             ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
             ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
             ((bool[]) buf[8])[0] = rslt.wasNull(8);
             ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
             ((bool[]) buf[10])[0] = rslt.wasNull(9);
             ((long[]) buf[11])[0] = rslt.getLong(10);
             ((bool[]) buf[12])[0] = rslt.wasNull(10);
             return;
          case 1 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
             ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
             ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
             ((bool[]) buf[8])[0] = rslt.wasNull(8);
             ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
             ((bool[]) buf[10])[0] = rslt.wasNull(9);
             ((long[]) buf[11])[0] = rslt.getLong(10);
             ((bool[]) buf[12])[0] = rslt.wasNull(10);
             return;
          case 2 :
             ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
             return;
          case 3 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
             ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
             ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
             ((bool[]) buf[8])[0] = rslt.wasNull(8);
             ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
             ((bool[]) buf[10])[0] = rslt.wasNull(9);
             ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10, true);
             ((long[]) buf[12])[0] = rslt.getLong(11);
             ((bool[]) buf[13])[0] = rslt.wasNull(11);
             return;
          case 4 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 6 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 9 :
             ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
             return;
          case 10 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
             ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
             ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
             ((bool[]) buf[8])[0] = rslt.wasNull(8);
             ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
             ((bool[]) buf[10])[0] = rslt.wasNull(9);
             ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10, true);
             ((long[]) buf[12])[0] = rslt.getLong(11);
             ((bool[]) buf[13])[0] = rslt.wasNull(11);
             return;
    }
 }

}

}
