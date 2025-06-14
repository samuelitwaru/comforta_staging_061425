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
namespace GeneXus.Programs.wwpbaseobjects.mail {
   public class wwp_mail_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_mail_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_mail_bc( IGxContext context )
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
         ReadRow0Q36( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0Q36( ) ;
         standaloneModal( ) ;
         AddRow0Q36( ) ;
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
               Z185WWPMailId = A185WWPMailId;
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

      protected void CONFIRM_0Q0( )
      {
         BeforeValidate0Q36( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0Q36( ) ;
            }
            else
            {
               CheckExtendedTable0Q36( ) ;
               if ( AnyError == 0 )
               {
                  ZM0Q36( 6) ;
               }
               CloseExtendedTableCursors0Q36( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode36 = Gx_mode;
            CONFIRM_0Q37( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode36;
            }
            /* Restore parent mode. */
            Gx_mode = sMode36;
         }
      }

      protected void CONFIRM_0Q37( )
      {
         nGXsfl_37_idx = 0;
         while ( nGXsfl_37_idx < bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Count )
         {
            ReadRow0Q37( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound37 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_37 != 0 ) )
            {
               GetKey0Q37( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound37 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0Q37( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0Q37( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors0Q37( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound37 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0Q37( ) ;
                        Load0Q37( ) ;
                        BeforeValidate0Q37( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0Q37( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_37 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0Q37( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0Q37( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors0Q37( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow37( ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Item(nGXsfl_37_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ZM0Q36( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z174WWPMailSubject = A174WWPMailSubject;
            Z186WWPMailStatus = A186WWPMailStatus;
            Z196WWPMailCreated = A196WWPMailCreated;
            Z197WWPMailScheduled = A197WWPMailScheduled;
            Z191WWPMailProcessed = A191WWPMailProcessed;
            Z127WWPNotificationId = A127WWPNotificationId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z129WWPNotificationCreated = A129WWPNotificationCreated;
         }
         if ( GX_JID == -5 )
         {
            Z185WWPMailId = A185WWPMailId;
            Z174WWPMailSubject = A174WWPMailSubject;
            Z166WWPMailBody = A166WWPMailBody;
            Z175WWPMailTo = A175WWPMailTo;
            Z188WWPMailCC = A188WWPMailCC;
            Z189WWPMailBCC = A189WWPMailBCC;
            Z176WWPMailSenderAddress = A176WWPMailSenderAddress;
            Z177WWPMailSenderName = A177WWPMailSenderName;
            Z186WWPMailStatus = A186WWPMailStatus;
            Z196WWPMailCreated = A196WWPMailCreated;
            Z197WWPMailScheduled = A197WWPMailScheduled;
            Z191WWPMailProcessed = A191WWPMailProcessed;
            Z192WWPMailDetail = A192WWPMailDetail;
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
         if ( IsIns( )  && (0==A186WWPMailStatus) && ( Gx_BScreen == 0 ) )
         {
            A186WWPMailStatus = 1;
         }
         if ( IsIns( )  && (DateTime.MinValue==A196WWPMailCreated) && ( Gx_BScreen == 0 ) )
         {
            A196WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( IsIns( )  && (DateTime.MinValue==A197WWPMailScheduled) && ( Gx_BScreen == 0 ) )
         {
            A197WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0Q36( )
      {
         /* Using cursor BC000Q7 */
         pr_default.execute(5, new Object[] {A185WWPMailId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound36 = 1;
            A174WWPMailSubject = BC000Q7_A174WWPMailSubject[0];
            A166WWPMailBody = BC000Q7_A166WWPMailBody[0];
            A175WWPMailTo = BC000Q7_A175WWPMailTo[0];
            n175WWPMailTo = BC000Q7_n175WWPMailTo[0];
            A188WWPMailCC = BC000Q7_A188WWPMailCC[0];
            n188WWPMailCC = BC000Q7_n188WWPMailCC[0];
            A189WWPMailBCC = BC000Q7_A189WWPMailBCC[0];
            n189WWPMailBCC = BC000Q7_n189WWPMailBCC[0];
            A176WWPMailSenderAddress = BC000Q7_A176WWPMailSenderAddress[0];
            A177WWPMailSenderName = BC000Q7_A177WWPMailSenderName[0];
            A186WWPMailStatus = BC000Q7_A186WWPMailStatus[0];
            A196WWPMailCreated = BC000Q7_A196WWPMailCreated[0];
            A197WWPMailScheduled = BC000Q7_A197WWPMailScheduled[0];
            A191WWPMailProcessed = BC000Q7_A191WWPMailProcessed[0];
            n191WWPMailProcessed = BC000Q7_n191WWPMailProcessed[0];
            A192WWPMailDetail = BC000Q7_A192WWPMailDetail[0];
            n192WWPMailDetail = BC000Q7_n192WWPMailDetail[0];
            A129WWPNotificationCreated = BC000Q7_A129WWPNotificationCreated[0];
            A127WWPNotificationId = BC000Q7_A127WWPNotificationId[0];
            n127WWPNotificationId = BC000Q7_n127WWPNotificationId[0];
            ZM0Q36( -5) ;
         }
         pr_default.close(5);
         OnLoadActions0Q36( ) ;
      }

      protected void OnLoadActions0Q36( )
      {
      }

      protected void CheckExtendedTable0Q36( )
      {
         standaloneModal( ) ;
         if ( ! ( ( A186WWPMailStatus == 1 ) || ( A186WWPMailStatus == 2 ) || ( A186WWPMailStatus == 3 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Mail Status", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000Q6 */
         pr_default.execute(4, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A127WWPNotificationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Notification", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
            }
         }
         A129WWPNotificationCreated = BC000Q6_A129WWPNotificationCreated[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0Q36( )
      {
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0Q36( )
      {
         /* Using cursor BC000Q8 */
         pr_default.execute(6, new Object[] {A185WWPMailId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound36 = 1;
         }
         else
         {
            RcdFound36 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000Q5 */
         pr_default.execute(3, new Object[] {A185WWPMailId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0Q36( 5) ;
            RcdFound36 = 1;
            A185WWPMailId = BC000Q5_A185WWPMailId[0];
            A174WWPMailSubject = BC000Q5_A174WWPMailSubject[0];
            A166WWPMailBody = BC000Q5_A166WWPMailBody[0];
            A175WWPMailTo = BC000Q5_A175WWPMailTo[0];
            n175WWPMailTo = BC000Q5_n175WWPMailTo[0];
            A188WWPMailCC = BC000Q5_A188WWPMailCC[0];
            n188WWPMailCC = BC000Q5_n188WWPMailCC[0];
            A189WWPMailBCC = BC000Q5_A189WWPMailBCC[0];
            n189WWPMailBCC = BC000Q5_n189WWPMailBCC[0];
            A176WWPMailSenderAddress = BC000Q5_A176WWPMailSenderAddress[0];
            A177WWPMailSenderName = BC000Q5_A177WWPMailSenderName[0];
            A186WWPMailStatus = BC000Q5_A186WWPMailStatus[0];
            A196WWPMailCreated = BC000Q5_A196WWPMailCreated[0];
            A197WWPMailScheduled = BC000Q5_A197WWPMailScheduled[0];
            A191WWPMailProcessed = BC000Q5_A191WWPMailProcessed[0];
            n191WWPMailProcessed = BC000Q5_n191WWPMailProcessed[0];
            A192WWPMailDetail = BC000Q5_A192WWPMailDetail[0];
            n192WWPMailDetail = BC000Q5_n192WWPMailDetail[0];
            A127WWPNotificationId = BC000Q5_A127WWPNotificationId[0];
            n127WWPNotificationId = BC000Q5_n127WWPNotificationId[0];
            Z185WWPMailId = A185WWPMailId;
            sMode36 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0Q36( ) ;
            if ( AnyError == 1 )
            {
               RcdFound36 = 0;
               InitializeNonKey0Q36( ) ;
            }
            Gx_mode = sMode36;
         }
         else
         {
            RcdFound36 = 0;
            InitializeNonKey0Q36( ) ;
            sMode36 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode36;
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Q36( ) ;
         if ( RcdFound36 == 0 )
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
         CONFIRM_0Q0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0Q36( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000Q4 */
            pr_default.execute(2, new Object[] {A185WWPMailId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Mail"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z174WWPMailSubject, BC000Q4_A174WWPMailSubject[0]) != 0 ) || ( Z186WWPMailStatus != BC000Q4_A186WWPMailStatus[0] ) || ( Z196WWPMailCreated != BC000Q4_A196WWPMailCreated[0] ) || ( Z197WWPMailScheduled != BC000Q4_A197WWPMailScheduled[0] ) || ( Z191WWPMailProcessed != BC000Q4_A191WWPMailProcessed[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z127WWPNotificationId != BC000Q4_A127WWPNotificationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Mail"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Q36( )
      {
         BeforeValidate0Q36( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Q36( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Q36( 0) ;
            CheckOptimisticConcurrency0Q36( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Q36( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Q36( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Q9 */
                     pr_default.execute(7, new Object[] {A174WWPMailSubject, A166WWPMailBody, n175WWPMailTo, A175WWPMailTo, n188WWPMailCC, A188WWPMailCC, n189WWPMailBCC, A189WWPMailBCC, A176WWPMailSenderAddress, A177WWPMailSenderName, A186WWPMailStatus, A196WWPMailCreated, A197WWPMailScheduled, n191WWPMailProcessed, A191WWPMailProcessed, n192WWPMailDetail, A192WWPMailDetail, n127WWPNotificationId, A127WWPNotificationId});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000Q10 */
                     pr_default.execute(8);
                     A185WWPMailId = BC000Q10_A185WWPMailId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0Q36( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
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
               Load0Q36( ) ;
            }
            EndLevel0Q36( ) ;
         }
         CloseExtendedTableCursors0Q36( ) ;
      }

      protected void Update0Q36( )
      {
         BeforeValidate0Q36( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Q36( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Q36( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Q36( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Q36( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Q11 */
                     pr_default.execute(9, new Object[] {A174WWPMailSubject, A166WWPMailBody, n175WWPMailTo, A175WWPMailTo, n188WWPMailCC, A188WWPMailCC, n189WWPMailBCC, A189WWPMailBCC, A176WWPMailSenderAddress, A177WWPMailSenderName, A186WWPMailStatus, A196WWPMailCreated, A197WWPMailScheduled, n191WWPMailProcessed, A191WWPMailProcessed, n192WWPMailDetail, A192WWPMailDetail, n127WWPNotificationId, A127WWPNotificationId, A185WWPMailId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Mail"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Q36( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0Q36( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
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
            }
            EndLevel0Q36( ) ;
         }
         CloseExtendedTableCursors0Q36( ) ;
      }

      protected void DeferredUpdate0Q36( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0Q36( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Q36( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Q36( ) ;
            AfterConfirm0Q36( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Q36( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0Q37( ) ;
                  while ( RcdFound37 != 0 )
                  {
                     getByPrimaryKey0Q37( ) ;
                     Delete0Q37( ) ;
                     ScanKeyNext0Q37( ) ;
                  }
                  ScanKeyEnd0Q37( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Q12 */
                     pr_default.execute(10, new Object[] {A185WWPMailId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Mail");
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
         }
         sMode36 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0Q36( ) ;
         Gx_mode = sMode36;
      }

      protected void OnDeleteControls0Q36( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000Q13 */
            pr_default.execute(11, new Object[] {n127WWPNotificationId, A127WWPNotificationId});
            A129WWPNotificationCreated = BC000Q13_A129WWPNotificationCreated[0];
            pr_default.close(11);
         }
      }

      protected void ProcessNestedLevel0Q37( )
      {
         nGXsfl_37_idx = 0;
         while ( nGXsfl_37_idx < bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Count )
         {
            ReadRow0Q37( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound37 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_37 != 0 ) )
            {
               standaloneNotModal0Q37( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0Q37( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0Q37( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0Q37( ) ;
                  }
               }
            }
            KeyVarsToRow37( ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Item(nGXsfl_37_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_37_idx = 0;
            while ( nGXsfl_37_idx < bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Count )
            {
               ReadRow0Q37( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound37 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.RemoveElement(nGXsfl_37_idx);
                  nGXsfl_37_idx = (int)(nGXsfl_37_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0Q37( ) ;
                  VarsToRow37( ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Item(nGXsfl_37_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0Q37( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_37 = 0;
         nIsMod_37 = 0;
      }

      protected void ProcessLevel0Q36( )
      {
         /* Save parent mode. */
         sMode36 = Gx_mode;
         ProcessNestedLevel0Q37( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode36;
         /* ' Update level parameters */
      }

      protected void EndLevel0Q36( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Q36( ) ;
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

      public void ScanKeyStart0Q36( )
      {
         /* Using cursor BC000Q14 */
         pr_default.execute(12, new Object[] {A185WWPMailId});
         RcdFound36 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound36 = 1;
            A185WWPMailId = BC000Q14_A185WWPMailId[0];
            A174WWPMailSubject = BC000Q14_A174WWPMailSubject[0];
            A166WWPMailBody = BC000Q14_A166WWPMailBody[0];
            A175WWPMailTo = BC000Q14_A175WWPMailTo[0];
            n175WWPMailTo = BC000Q14_n175WWPMailTo[0];
            A188WWPMailCC = BC000Q14_A188WWPMailCC[0];
            n188WWPMailCC = BC000Q14_n188WWPMailCC[0];
            A189WWPMailBCC = BC000Q14_A189WWPMailBCC[0];
            n189WWPMailBCC = BC000Q14_n189WWPMailBCC[0];
            A176WWPMailSenderAddress = BC000Q14_A176WWPMailSenderAddress[0];
            A177WWPMailSenderName = BC000Q14_A177WWPMailSenderName[0];
            A186WWPMailStatus = BC000Q14_A186WWPMailStatus[0];
            A196WWPMailCreated = BC000Q14_A196WWPMailCreated[0];
            A197WWPMailScheduled = BC000Q14_A197WWPMailScheduled[0];
            A191WWPMailProcessed = BC000Q14_A191WWPMailProcessed[0];
            n191WWPMailProcessed = BC000Q14_n191WWPMailProcessed[0];
            A192WWPMailDetail = BC000Q14_A192WWPMailDetail[0];
            n192WWPMailDetail = BC000Q14_n192WWPMailDetail[0];
            A129WWPNotificationCreated = BC000Q14_A129WWPNotificationCreated[0];
            A127WWPNotificationId = BC000Q14_A127WWPNotificationId[0];
            n127WWPNotificationId = BC000Q14_n127WWPNotificationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0Q36( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound36 = 0;
         ScanKeyLoad0Q36( ) ;
      }

      protected void ScanKeyLoad0Q36( )
      {
         sMode36 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound36 = 1;
            A185WWPMailId = BC000Q14_A185WWPMailId[0];
            A174WWPMailSubject = BC000Q14_A174WWPMailSubject[0];
            A166WWPMailBody = BC000Q14_A166WWPMailBody[0];
            A175WWPMailTo = BC000Q14_A175WWPMailTo[0];
            n175WWPMailTo = BC000Q14_n175WWPMailTo[0];
            A188WWPMailCC = BC000Q14_A188WWPMailCC[0];
            n188WWPMailCC = BC000Q14_n188WWPMailCC[0];
            A189WWPMailBCC = BC000Q14_A189WWPMailBCC[0];
            n189WWPMailBCC = BC000Q14_n189WWPMailBCC[0];
            A176WWPMailSenderAddress = BC000Q14_A176WWPMailSenderAddress[0];
            A177WWPMailSenderName = BC000Q14_A177WWPMailSenderName[0];
            A186WWPMailStatus = BC000Q14_A186WWPMailStatus[0];
            A196WWPMailCreated = BC000Q14_A196WWPMailCreated[0];
            A197WWPMailScheduled = BC000Q14_A197WWPMailScheduled[0];
            A191WWPMailProcessed = BC000Q14_A191WWPMailProcessed[0];
            n191WWPMailProcessed = BC000Q14_n191WWPMailProcessed[0];
            A192WWPMailDetail = BC000Q14_A192WWPMailDetail[0];
            n192WWPMailDetail = BC000Q14_n192WWPMailDetail[0];
            A129WWPNotificationCreated = BC000Q14_A129WWPNotificationCreated[0];
            A127WWPNotificationId = BC000Q14_A127WWPNotificationId[0];
            n127WWPNotificationId = BC000Q14_n127WWPNotificationId[0];
         }
         Gx_mode = sMode36;
      }

      protected void ScanKeyEnd0Q36( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0Q36( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Q36( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Q36( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Q36( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Q36( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Q36( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Q36( )
      {
      }

      protected void ZM0Q37( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -7 )
         {
            Z185WWPMailId = A185WWPMailId;
            Z198WWPMailAttachmentName = A198WWPMailAttachmentName;
            Z190WWPMailAttachmentFile = A190WWPMailAttachmentFile;
         }
      }

      protected void standaloneNotModal0Q37( )
      {
      }

      protected void standaloneModal0Q37( )
      {
      }

      protected void Load0Q37( )
      {
         /* Using cursor BC000Q15 */
         pr_default.execute(13, new Object[] {A185WWPMailId, A198WWPMailAttachmentName});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound37 = 1;
            A190WWPMailAttachmentFile = BC000Q15_A190WWPMailAttachmentFile[0];
            ZM0Q37( -7) ;
         }
         pr_default.close(13);
         OnLoadActions0Q37( ) ;
      }

      protected void OnLoadActions0Q37( )
      {
      }

      protected void CheckExtendedTable0Q37( )
      {
         Gx_BScreen = 1;
         standaloneModal0Q37( ) ;
         Gx_BScreen = 0;
      }

      protected void CloseExtendedTableCursors0Q37( )
      {
      }

      protected void enableDisable0Q37( )
      {
      }

      protected void GetKey0Q37( )
      {
         /* Using cursor BC000Q16 */
         pr_default.execute(14, new Object[] {A185WWPMailId, A198WWPMailAttachmentName});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound37 = 1;
         }
         else
         {
            RcdFound37 = 0;
         }
         pr_default.close(14);
      }

      protected void getByPrimaryKey0Q37( )
      {
         /* Using cursor BC000Q3 */
         pr_default.execute(1, new Object[] {A185WWPMailId, A198WWPMailAttachmentName});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Q37( 7) ;
            RcdFound37 = 1;
            InitializeNonKey0Q37( ) ;
            A198WWPMailAttachmentName = BC000Q3_A198WWPMailAttachmentName[0];
            A190WWPMailAttachmentFile = BC000Q3_A190WWPMailAttachmentFile[0];
            Z185WWPMailId = A185WWPMailId;
            Z198WWPMailAttachmentName = A198WWPMailAttachmentName;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0Q37( ) ;
            Load0Q37( ) ;
            Gx_mode = sMode37;
         }
         else
         {
            RcdFound37 = 0;
            InitializeNonKey0Q37( ) ;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0Q37( ) ;
            Gx_mode = sMode37;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0Q37( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0Q37( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000Q2 */
            pr_default.execute(0, new Object[] {A185WWPMailId, A198WWPMailAttachmentName});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailAttachments"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_MailAttachments"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Q37( )
      {
         BeforeValidate0Q37( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Q37( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Q37( 0) ;
            CheckOptimisticConcurrency0Q37( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Q37( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Q37( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Q17 */
                     pr_default.execute(15, new Object[] {A185WWPMailId, A198WWPMailAttachmentName, A190WWPMailAttachmentFile});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                     if ( (pr_default.getStatus(15) == 1) )
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
               Load0Q37( ) ;
            }
            EndLevel0Q37( ) ;
         }
         CloseExtendedTableCursors0Q37( ) ;
      }

      protected void Update0Q37( )
      {
         BeforeValidate0Q37( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Q37( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Q37( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Q37( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Q37( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Q18 */
                     pr_default.execute(16, new Object[] {A190WWPMailAttachmentFile, A185WWPMailId, A198WWPMailAttachmentName});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailAttachments"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Q37( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0Q37( ) ;
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
            EndLevel0Q37( ) ;
         }
         CloseExtendedTableCursors0Q37( ) ;
      }

      protected void DeferredUpdate0Q37( )
      {
      }

      protected void Delete0Q37( )
      {
         Gx_mode = "DLT";
         BeforeValidate0Q37( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Q37( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Q37( ) ;
            AfterConfirm0Q37( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Q37( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000Q19 */
                  pr_default.execute(17, new Object[] {A185WWPMailId, A198WWPMailAttachmentName});
                  pr_default.close(17);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode37 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0Q37( ) ;
         Gx_mode = sMode37;
      }

      protected void OnDeleteControls0Q37( )
      {
         standaloneModal0Q37( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0Q37( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0Q37( )
      {
         /* Scan By routine */
         /* Using cursor BC000Q20 */
         pr_default.execute(18, new Object[] {A185WWPMailId});
         RcdFound37 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound37 = 1;
            A198WWPMailAttachmentName = BC000Q20_A198WWPMailAttachmentName[0];
            A190WWPMailAttachmentFile = BC000Q20_A190WWPMailAttachmentFile[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0Q37( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound37 = 0;
         ScanKeyLoad0Q37( ) ;
      }

      protected void ScanKeyLoad0Q37( )
      {
         sMode37 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound37 = 1;
            A198WWPMailAttachmentName = BC000Q20_A198WWPMailAttachmentName[0];
            A190WWPMailAttachmentFile = BC000Q20_A190WWPMailAttachmentFile[0];
         }
         Gx_mode = sMode37;
      }

      protected void ScanKeyEnd0Q37( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0Q37( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Q37( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Q37( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Q37( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Q37( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Q37( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Q37( )
      {
      }

      protected void send_integrity_lvl_hashes0Q37( )
      {
      }

      protected void send_integrity_lvl_hashes0Q36( )
      {
      }

      protected void AddRow0Q36( )
      {
         VarsToRow36( bcwwpbaseobjects_mail_WWP_Mail) ;
      }

      protected void ReadRow0Q36( )
      {
         RowToVars36( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
      }

      protected void AddRow0Q37( )
      {
         GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments obj37;
         obj37 = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments(context);
         VarsToRow37( obj37) ;
         bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Add(obj37, 0);
         obj37.gxTpr_Mode = "UPD";
         obj37.gxTpr_Modified = 0;
      }

      protected void ReadRow0Q37( )
      {
         nGXsfl_37_idx = (int)(nGXsfl_37_idx+1);
         RowToVars37( ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Item(nGXsfl_37_idx)), 1) ;
      }

      protected void InitializeNonKey0Q36( )
      {
         A174WWPMailSubject = "";
         A166WWPMailBody = "";
         A175WWPMailTo = "";
         n175WWPMailTo = false;
         A188WWPMailCC = "";
         n188WWPMailCC = false;
         A189WWPMailBCC = "";
         n189WWPMailBCC = false;
         A176WWPMailSenderAddress = "";
         A177WWPMailSenderName = "";
         A191WWPMailProcessed = (DateTime)(DateTime.MinValue);
         n191WWPMailProcessed = false;
         A192WWPMailDetail = "";
         n192WWPMailDetail = false;
         A127WWPNotificationId = 0;
         n127WWPNotificationId = false;
         A129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A186WWPMailStatus = 1;
         A196WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A197WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z174WWPMailSubject = "";
         Z186WWPMailStatus = 0;
         Z196WWPMailCreated = (DateTime)(DateTime.MinValue);
         Z197WWPMailScheduled = (DateTime)(DateTime.MinValue);
         Z191WWPMailProcessed = (DateTime)(DateTime.MinValue);
         Z127WWPNotificationId = 0;
      }

      protected void InitAll0Q36( )
      {
         A185WWPMailId = 0;
         InitializeNonKey0Q36( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A186WWPMailStatus = i186WWPMailStatus;
         A196WWPMailCreated = i196WWPMailCreated;
         A197WWPMailScheduled = i197WWPMailScheduled;
      }

      protected void InitializeNonKey0Q37( )
      {
         A190WWPMailAttachmentFile = "";
      }

      protected void InitAll0Q37( )
      {
         A198WWPMailAttachmentName = "";
         InitializeNonKey0Q37( ) ;
      }

      protected void StandaloneModalInsert0Q37( )
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

      public void VarsToRow36( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail obj36 )
      {
         obj36.gxTpr_Mode = Gx_mode;
         obj36.gxTpr_Wwpmailsubject = A174WWPMailSubject;
         obj36.gxTpr_Wwpmailbody = A166WWPMailBody;
         obj36.gxTpr_Wwpmailto = A175WWPMailTo;
         obj36.gxTpr_Wwpmailcc = A188WWPMailCC;
         obj36.gxTpr_Wwpmailbcc = A189WWPMailBCC;
         obj36.gxTpr_Wwpmailsenderaddress = A176WWPMailSenderAddress;
         obj36.gxTpr_Wwpmailsendername = A177WWPMailSenderName;
         obj36.gxTpr_Wwpmailprocessed = A191WWPMailProcessed;
         obj36.gxTpr_Wwpmaildetail = A192WWPMailDetail;
         obj36.gxTpr_Wwpnotificationid = A127WWPNotificationId;
         obj36.gxTpr_Wwpnotificationcreated = A129WWPNotificationCreated;
         obj36.gxTpr_Wwpmailstatus = A186WWPMailStatus;
         obj36.gxTpr_Wwpmailcreated = A196WWPMailCreated;
         obj36.gxTpr_Wwpmailscheduled = A197WWPMailScheduled;
         obj36.gxTpr_Wwpmailid = A185WWPMailId;
         obj36.gxTpr_Wwpmailid_Z = Z185WWPMailId;
         obj36.gxTpr_Wwpmailsubject_Z = Z174WWPMailSubject;
         obj36.gxTpr_Wwpmailstatus_Z = Z186WWPMailStatus;
         obj36.gxTpr_Wwpmailcreated_Z = Z196WWPMailCreated;
         obj36.gxTpr_Wwpmailscheduled_Z = Z197WWPMailScheduled;
         obj36.gxTpr_Wwpmailprocessed_Z = Z191WWPMailProcessed;
         obj36.gxTpr_Wwpnotificationid_Z = Z127WWPNotificationId;
         obj36.gxTpr_Wwpnotificationcreated_Z = Z129WWPNotificationCreated;
         obj36.gxTpr_Wwpmailto_N = (short)(Convert.ToInt16(n175WWPMailTo));
         obj36.gxTpr_Wwpmailcc_N = (short)(Convert.ToInt16(n188WWPMailCC));
         obj36.gxTpr_Wwpmailbcc_N = (short)(Convert.ToInt16(n189WWPMailBCC));
         obj36.gxTpr_Wwpmailprocessed_N = (short)(Convert.ToInt16(n191WWPMailProcessed));
         obj36.gxTpr_Wwpmaildetail_N = (short)(Convert.ToInt16(n192WWPMailDetail));
         obj36.gxTpr_Wwpnotificationid_N = (short)(Convert.ToInt16(n127WWPNotificationId));
         obj36.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow36( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail obj36 )
      {
         obj36.gxTpr_Wwpmailid = A185WWPMailId;
         return  ;
      }

      public void RowToVars36( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail obj36 ,
                               int forceLoad )
      {
         Gx_mode = obj36.gxTpr_Mode;
         A174WWPMailSubject = obj36.gxTpr_Wwpmailsubject;
         A166WWPMailBody = obj36.gxTpr_Wwpmailbody;
         A175WWPMailTo = obj36.gxTpr_Wwpmailto;
         n175WWPMailTo = false;
         A188WWPMailCC = obj36.gxTpr_Wwpmailcc;
         n188WWPMailCC = false;
         A189WWPMailBCC = obj36.gxTpr_Wwpmailbcc;
         n189WWPMailBCC = false;
         A176WWPMailSenderAddress = obj36.gxTpr_Wwpmailsenderaddress;
         A177WWPMailSenderName = obj36.gxTpr_Wwpmailsendername;
         A191WWPMailProcessed = obj36.gxTpr_Wwpmailprocessed;
         n191WWPMailProcessed = false;
         A192WWPMailDetail = obj36.gxTpr_Wwpmaildetail;
         n192WWPMailDetail = false;
         A127WWPNotificationId = obj36.gxTpr_Wwpnotificationid;
         n127WWPNotificationId = false;
         A129WWPNotificationCreated = obj36.gxTpr_Wwpnotificationcreated;
         A186WWPMailStatus = obj36.gxTpr_Wwpmailstatus;
         A196WWPMailCreated = obj36.gxTpr_Wwpmailcreated;
         A197WWPMailScheduled = obj36.gxTpr_Wwpmailscheduled;
         A185WWPMailId = obj36.gxTpr_Wwpmailid;
         Z185WWPMailId = obj36.gxTpr_Wwpmailid_Z;
         Z174WWPMailSubject = obj36.gxTpr_Wwpmailsubject_Z;
         Z186WWPMailStatus = obj36.gxTpr_Wwpmailstatus_Z;
         Z196WWPMailCreated = obj36.gxTpr_Wwpmailcreated_Z;
         Z197WWPMailScheduled = obj36.gxTpr_Wwpmailscheduled_Z;
         Z191WWPMailProcessed = obj36.gxTpr_Wwpmailprocessed_Z;
         Z127WWPNotificationId = obj36.gxTpr_Wwpnotificationid_Z;
         Z129WWPNotificationCreated = obj36.gxTpr_Wwpnotificationcreated_Z;
         n175WWPMailTo = (bool)(Convert.ToBoolean(obj36.gxTpr_Wwpmailto_N));
         n188WWPMailCC = (bool)(Convert.ToBoolean(obj36.gxTpr_Wwpmailcc_N));
         n189WWPMailBCC = (bool)(Convert.ToBoolean(obj36.gxTpr_Wwpmailbcc_N));
         n191WWPMailProcessed = (bool)(Convert.ToBoolean(obj36.gxTpr_Wwpmailprocessed_N));
         n192WWPMailDetail = (bool)(Convert.ToBoolean(obj36.gxTpr_Wwpmaildetail_N));
         n127WWPNotificationId = (bool)(Convert.ToBoolean(obj36.gxTpr_Wwpnotificationid_N));
         Gx_mode = obj36.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow37( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments obj37 )
      {
         obj37.gxTpr_Mode = Gx_mode;
         obj37.gxTpr_Wwpmailattachmentfile = A190WWPMailAttachmentFile;
         obj37.gxTpr_Wwpmailattachmentname = A198WWPMailAttachmentName;
         obj37.gxTpr_Wwpmailattachmentname_Z = Z198WWPMailAttachmentName;
         obj37.gxTpr_Modified = nIsMod_37;
         return  ;
      }

      public void KeyVarsToRow37( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments obj37 )
      {
         obj37.gxTpr_Wwpmailattachmentname = A198WWPMailAttachmentName;
         return  ;
      }

      public void RowToVars37( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments obj37 ,
                               int forceLoad )
      {
         Gx_mode = obj37.gxTpr_Mode;
         A190WWPMailAttachmentFile = obj37.gxTpr_Wwpmailattachmentfile;
         A198WWPMailAttachmentName = obj37.gxTpr_Wwpmailattachmentname;
         Z198WWPMailAttachmentName = obj37.gxTpr_Wwpmailattachmentname_Z;
         nIsMod_37 = obj37.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A185WWPMailId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0Q36( ) ;
         ScanKeyStart0Q36( ) ;
         if ( RcdFound36 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z185WWPMailId = A185WWPMailId;
         }
         ZM0Q36( -5) ;
         OnLoadActions0Q36( ) ;
         AddRow0Q36( ) ;
         bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.ClearCollection();
         if ( RcdFound36 == 1 )
         {
            ScanKeyStart0Q37( ) ;
            nGXsfl_37_idx = 1;
            while ( RcdFound37 != 0 )
            {
               Z185WWPMailId = A185WWPMailId;
               Z198WWPMailAttachmentName = A198WWPMailAttachmentName;
               ZM0Q37( -7) ;
               OnLoadActions0Q37( ) ;
               nRcdExists_37 = 1;
               nIsMod_37 = 0;
               AddRow0Q37( ) ;
               nGXsfl_37_idx = (int)(nGXsfl_37_idx+1);
               ScanKeyNext0Q37( ) ;
            }
            ScanKeyEnd0Q37( ) ;
         }
         ScanKeyEnd0Q36( ) ;
         if ( RcdFound36 == 0 )
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
         RowToVars36( bcwwpbaseobjects_mail_WWP_Mail, 0) ;
         ScanKeyStart0Q36( ) ;
         if ( RcdFound36 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z185WWPMailId = A185WWPMailId;
         }
         ZM0Q36( -5) ;
         OnLoadActions0Q36( ) ;
         AddRow0Q36( ) ;
         bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.ClearCollection();
         if ( RcdFound36 == 1 )
         {
            ScanKeyStart0Q37( ) ;
            nGXsfl_37_idx = 1;
            while ( RcdFound37 != 0 )
            {
               Z185WWPMailId = A185WWPMailId;
               Z198WWPMailAttachmentName = A198WWPMailAttachmentName;
               ZM0Q37( -7) ;
               OnLoadActions0Q37( ) ;
               nRcdExists_37 = 1;
               nIsMod_37 = 0;
               AddRow0Q37( ) ;
               nGXsfl_37_idx = (int)(nGXsfl_37_idx+1);
               ScanKeyNext0Q37( ) ;
            }
            ScanKeyEnd0Q37( ) ;
         }
         ScanKeyEnd0Q36( ) ;
         if ( RcdFound36 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0Q36( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0Q36( ) ;
         }
         else
         {
            if ( RcdFound36 == 1 )
            {
               if ( A185WWPMailId != Z185WWPMailId )
               {
                  A185WWPMailId = Z185WWPMailId;
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
                  Update0Q36( ) ;
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
                  if ( A185WWPMailId != Z185WWPMailId )
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
                        Insert0Q36( ) ;
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
                        Insert0Q36( ) ;
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
         RowToVars36( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
         SaveImpl( ) ;
         VarsToRow36( bcwwpbaseobjects_mail_WWP_Mail) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars36( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0Q36( ) ;
         AfterTrn( ) ;
         VarsToRow36( bcwwpbaseobjects_mail_WWP_Mail) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow36( bcwwpbaseobjects_mail_WWP_Mail) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail auxBC = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A185WWPMailId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_mail_WWP_Mail);
               auxBC.Save();
               bcwwpbaseobjects_mail_WWP_Mail.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars36( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
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
         RowToVars36( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0Q36( ) ;
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
               VarsToRow36( bcwwpbaseobjects_mail_WWP_Mail) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow36( bcwwpbaseobjects_mail_WWP_Mail) ;
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
         RowToVars36( bcwwpbaseobjects_mail_WWP_Mail, 0) ;
         GetKey0Q36( ) ;
         if ( RcdFound36 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A185WWPMailId != Z185WWPMailId )
            {
               A185WWPMailId = Z185WWPMailId;
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
            if ( A185WWPMailId != Z185WWPMailId )
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
         context.RollbackDataStores("wwpbaseobjects.mail.wwp_mail_bc",pr_default);
         VarsToRow36( bcwwpbaseobjects_mail_WWP_Mail) ;
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
         Gx_mode = bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_mail_WWP_Mail )
         {
            bcwwpbaseobjects_mail_WWP_Mail = (GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow36( bcwwpbaseobjects_mail_WWP_Mail) ;
            }
            else
            {
               RowToVars36( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars36( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_Mail WWP_Mail_BC
      {
         get {
            return bcwwpbaseobjects_mail_WWP_Mail ;
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
            return "wwpmail_Execute" ;
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
         pr_default.close(3);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode36 = "";
         Z174WWPMailSubject = "";
         A174WWPMailSubject = "";
         Z196WWPMailCreated = (DateTime)(DateTime.MinValue);
         A196WWPMailCreated = (DateTime)(DateTime.MinValue);
         Z197WWPMailScheduled = (DateTime)(DateTime.MinValue);
         A197WWPMailScheduled = (DateTime)(DateTime.MinValue);
         Z191WWPMailProcessed = (DateTime)(DateTime.MinValue);
         A191WWPMailProcessed = (DateTime)(DateTime.MinValue);
         Z129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z166WWPMailBody = "";
         A166WWPMailBody = "";
         Z175WWPMailTo = "";
         A175WWPMailTo = "";
         Z188WWPMailCC = "";
         A188WWPMailCC = "";
         Z189WWPMailBCC = "";
         A189WWPMailBCC = "";
         Z176WWPMailSenderAddress = "";
         A176WWPMailSenderAddress = "";
         Z177WWPMailSenderName = "";
         A177WWPMailSenderName = "";
         Z192WWPMailDetail = "";
         A192WWPMailDetail = "";
         BC000Q7_A185WWPMailId = new long[1] ;
         BC000Q7_A174WWPMailSubject = new string[] {""} ;
         BC000Q7_A166WWPMailBody = new string[] {""} ;
         BC000Q7_A175WWPMailTo = new string[] {""} ;
         BC000Q7_n175WWPMailTo = new bool[] {false} ;
         BC000Q7_A188WWPMailCC = new string[] {""} ;
         BC000Q7_n188WWPMailCC = new bool[] {false} ;
         BC000Q7_A189WWPMailBCC = new string[] {""} ;
         BC000Q7_n189WWPMailBCC = new bool[] {false} ;
         BC000Q7_A176WWPMailSenderAddress = new string[] {""} ;
         BC000Q7_A177WWPMailSenderName = new string[] {""} ;
         BC000Q7_A186WWPMailStatus = new short[1] ;
         BC000Q7_A196WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         BC000Q7_A197WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000Q7_A191WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000Q7_n191WWPMailProcessed = new bool[] {false} ;
         BC000Q7_A192WWPMailDetail = new string[] {""} ;
         BC000Q7_n192WWPMailDetail = new bool[] {false} ;
         BC000Q7_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000Q7_A127WWPNotificationId = new long[1] ;
         BC000Q7_n127WWPNotificationId = new bool[] {false} ;
         BC000Q6_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000Q8_A185WWPMailId = new long[1] ;
         BC000Q5_A185WWPMailId = new long[1] ;
         BC000Q5_A174WWPMailSubject = new string[] {""} ;
         BC000Q5_A166WWPMailBody = new string[] {""} ;
         BC000Q5_A175WWPMailTo = new string[] {""} ;
         BC000Q5_n175WWPMailTo = new bool[] {false} ;
         BC000Q5_A188WWPMailCC = new string[] {""} ;
         BC000Q5_n188WWPMailCC = new bool[] {false} ;
         BC000Q5_A189WWPMailBCC = new string[] {""} ;
         BC000Q5_n189WWPMailBCC = new bool[] {false} ;
         BC000Q5_A176WWPMailSenderAddress = new string[] {""} ;
         BC000Q5_A177WWPMailSenderName = new string[] {""} ;
         BC000Q5_A186WWPMailStatus = new short[1] ;
         BC000Q5_A196WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         BC000Q5_A197WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000Q5_A191WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000Q5_n191WWPMailProcessed = new bool[] {false} ;
         BC000Q5_A192WWPMailDetail = new string[] {""} ;
         BC000Q5_n192WWPMailDetail = new bool[] {false} ;
         BC000Q5_A127WWPNotificationId = new long[1] ;
         BC000Q5_n127WWPNotificationId = new bool[] {false} ;
         BC000Q4_A185WWPMailId = new long[1] ;
         BC000Q4_A174WWPMailSubject = new string[] {""} ;
         BC000Q4_A166WWPMailBody = new string[] {""} ;
         BC000Q4_A175WWPMailTo = new string[] {""} ;
         BC000Q4_n175WWPMailTo = new bool[] {false} ;
         BC000Q4_A188WWPMailCC = new string[] {""} ;
         BC000Q4_n188WWPMailCC = new bool[] {false} ;
         BC000Q4_A189WWPMailBCC = new string[] {""} ;
         BC000Q4_n189WWPMailBCC = new bool[] {false} ;
         BC000Q4_A176WWPMailSenderAddress = new string[] {""} ;
         BC000Q4_A177WWPMailSenderName = new string[] {""} ;
         BC000Q4_A186WWPMailStatus = new short[1] ;
         BC000Q4_A196WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         BC000Q4_A197WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000Q4_A191WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000Q4_n191WWPMailProcessed = new bool[] {false} ;
         BC000Q4_A192WWPMailDetail = new string[] {""} ;
         BC000Q4_n192WWPMailDetail = new bool[] {false} ;
         BC000Q4_A127WWPNotificationId = new long[1] ;
         BC000Q4_n127WWPNotificationId = new bool[] {false} ;
         BC000Q10_A185WWPMailId = new long[1] ;
         BC000Q13_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000Q14_A185WWPMailId = new long[1] ;
         BC000Q14_A174WWPMailSubject = new string[] {""} ;
         BC000Q14_A166WWPMailBody = new string[] {""} ;
         BC000Q14_A175WWPMailTo = new string[] {""} ;
         BC000Q14_n175WWPMailTo = new bool[] {false} ;
         BC000Q14_A188WWPMailCC = new string[] {""} ;
         BC000Q14_n188WWPMailCC = new bool[] {false} ;
         BC000Q14_A189WWPMailBCC = new string[] {""} ;
         BC000Q14_n189WWPMailBCC = new bool[] {false} ;
         BC000Q14_A176WWPMailSenderAddress = new string[] {""} ;
         BC000Q14_A177WWPMailSenderName = new string[] {""} ;
         BC000Q14_A186WWPMailStatus = new short[1] ;
         BC000Q14_A196WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         BC000Q14_A197WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000Q14_A191WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000Q14_n191WWPMailProcessed = new bool[] {false} ;
         BC000Q14_A192WWPMailDetail = new string[] {""} ;
         BC000Q14_n192WWPMailDetail = new bool[] {false} ;
         BC000Q14_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000Q14_A127WWPNotificationId = new long[1] ;
         BC000Q14_n127WWPNotificationId = new bool[] {false} ;
         Z198WWPMailAttachmentName = "";
         A198WWPMailAttachmentName = "";
         Z190WWPMailAttachmentFile = "";
         A190WWPMailAttachmentFile = "";
         BC000Q15_A185WWPMailId = new long[1] ;
         BC000Q15_A198WWPMailAttachmentName = new string[] {""} ;
         BC000Q15_A190WWPMailAttachmentFile = new string[] {""} ;
         BC000Q16_A185WWPMailId = new long[1] ;
         BC000Q16_A198WWPMailAttachmentName = new string[] {""} ;
         BC000Q3_A185WWPMailId = new long[1] ;
         BC000Q3_A198WWPMailAttachmentName = new string[] {""} ;
         BC000Q3_A190WWPMailAttachmentFile = new string[] {""} ;
         sMode37 = "";
         BC000Q2_A185WWPMailId = new long[1] ;
         BC000Q2_A198WWPMailAttachmentName = new string[] {""} ;
         BC000Q2_A190WWPMailAttachmentFile = new string[] {""} ;
         BC000Q20_A185WWPMailId = new long[1] ;
         BC000Q20_A198WWPMailAttachmentName = new string[] {""} ;
         BC000Q20_A190WWPMailAttachmentFile = new string[] {""} ;
         i196WWPMailCreated = (DateTime)(DateTime.MinValue);
         i197WWPMailScheduled = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mail_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mail_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mail_bc__default(),
            new Object[][] {
                new Object[] {
               BC000Q2_A185WWPMailId, BC000Q2_A198WWPMailAttachmentName, BC000Q2_A190WWPMailAttachmentFile
               }
               , new Object[] {
               BC000Q3_A185WWPMailId, BC000Q3_A198WWPMailAttachmentName, BC000Q3_A190WWPMailAttachmentFile
               }
               , new Object[] {
               BC000Q4_A185WWPMailId, BC000Q4_A174WWPMailSubject, BC000Q4_A166WWPMailBody, BC000Q4_A175WWPMailTo, BC000Q4_n175WWPMailTo, BC000Q4_A188WWPMailCC, BC000Q4_n188WWPMailCC, BC000Q4_A189WWPMailBCC, BC000Q4_n189WWPMailBCC, BC000Q4_A176WWPMailSenderAddress,
               BC000Q4_A177WWPMailSenderName, BC000Q4_A186WWPMailStatus, BC000Q4_A196WWPMailCreated, BC000Q4_A197WWPMailScheduled, BC000Q4_A191WWPMailProcessed, BC000Q4_n191WWPMailProcessed, BC000Q4_A192WWPMailDetail, BC000Q4_n192WWPMailDetail, BC000Q4_A127WWPNotificationId, BC000Q4_n127WWPNotificationId
               }
               , new Object[] {
               BC000Q5_A185WWPMailId, BC000Q5_A174WWPMailSubject, BC000Q5_A166WWPMailBody, BC000Q5_A175WWPMailTo, BC000Q5_n175WWPMailTo, BC000Q5_A188WWPMailCC, BC000Q5_n188WWPMailCC, BC000Q5_A189WWPMailBCC, BC000Q5_n189WWPMailBCC, BC000Q5_A176WWPMailSenderAddress,
               BC000Q5_A177WWPMailSenderName, BC000Q5_A186WWPMailStatus, BC000Q5_A196WWPMailCreated, BC000Q5_A197WWPMailScheduled, BC000Q5_A191WWPMailProcessed, BC000Q5_n191WWPMailProcessed, BC000Q5_A192WWPMailDetail, BC000Q5_n192WWPMailDetail, BC000Q5_A127WWPNotificationId, BC000Q5_n127WWPNotificationId
               }
               , new Object[] {
               BC000Q6_A129WWPNotificationCreated
               }
               , new Object[] {
               BC000Q7_A185WWPMailId, BC000Q7_A174WWPMailSubject, BC000Q7_A166WWPMailBody, BC000Q7_A175WWPMailTo, BC000Q7_n175WWPMailTo, BC000Q7_A188WWPMailCC, BC000Q7_n188WWPMailCC, BC000Q7_A189WWPMailBCC, BC000Q7_n189WWPMailBCC, BC000Q7_A176WWPMailSenderAddress,
               BC000Q7_A177WWPMailSenderName, BC000Q7_A186WWPMailStatus, BC000Q7_A196WWPMailCreated, BC000Q7_A197WWPMailScheduled, BC000Q7_A191WWPMailProcessed, BC000Q7_n191WWPMailProcessed, BC000Q7_A192WWPMailDetail, BC000Q7_n192WWPMailDetail, BC000Q7_A129WWPNotificationCreated, BC000Q7_A127WWPNotificationId,
               BC000Q7_n127WWPNotificationId
               }
               , new Object[] {
               BC000Q8_A185WWPMailId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Q10_A185WWPMailId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Q13_A129WWPNotificationCreated
               }
               , new Object[] {
               BC000Q14_A185WWPMailId, BC000Q14_A174WWPMailSubject, BC000Q14_A166WWPMailBody, BC000Q14_A175WWPMailTo, BC000Q14_n175WWPMailTo, BC000Q14_A188WWPMailCC, BC000Q14_n188WWPMailCC, BC000Q14_A189WWPMailBCC, BC000Q14_n189WWPMailBCC, BC000Q14_A176WWPMailSenderAddress,
               BC000Q14_A177WWPMailSenderName, BC000Q14_A186WWPMailStatus, BC000Q14_A196WWPMailCreated, BC000Q14_A197WWPMailScheduled, BC000Q14_A191WWPMailProcessed, BC000Q14_n191WWPMailProcessed, BC000Q14_A192WWPMailDetail, BC000Q14_n192WWPMailDetail, BC000Q14_A129WWPNotificationCreated, BC000Q14_A127WWPNotificationId,
               BC000Q14_n127WWPNotificationId
               }
               , new Object[] {
               BC000Q15_A185WWPMailId, BC000Q15_A198WWPMailAttachmentName, BC000Q15_A190WWPMailAttachmentFile
               }
               , new Object[] {
               BC000Q16_A185WWPMailId, BC000Q16_A198WWPMailAttachmentName
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Q20_A185WWPMailId, BC000Q20_A198WWPMailAttachmentName, BC000Q20_A190WWPMailAttachmentFile
               }
            }
         );
         Z197WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A197WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i197WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z196WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A196WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i196WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z186WWPMailStatus = 1;
         A186WWPMailStatus = 1;
         i186WWPMailStatus = 1;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_37 ;
      private short RcdFound37 ;
      private short Z186WWPMailStatus ;
      private short A186WWPMailStatus ;
      private short Gx_BScreen ;
      private short RcdFound36 ;
      private short nRcdExists_37 ;
      private short Gxremove37 ;
      private short i186WWPMailStatus ;
      private int trnEnded ;
      private int nGXsfl_37_idx=1 ;
      private long Z185WWPMailId ;
      private long A185WWPMailId ;
      private long Z127WWPNotificationId ;
      private long A127WWPNotificationId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode36 ;
      private string sMode37 ;
      private DateTime Z196WWPMailCreated ;
      private DateTime A196WWPMailCreated ;
      private DateTime Z197WWPMailScheduled ;
      private DateTime A197WWPMailScheduled ;
      private DateTime Z191WWPMailProcessed ;
      private DateTime A191WWPMailProcessed ;
      private DateTime Z129WWPNotificationCreated ;
      private DateTime A129WWPNotificationCreated ;
      private DateTime i196WWPMailCreated ;
      private DateTime i197WWPMailScheduled ;
      private bool n175WWPMailTo ;
      private bool n188WWPMailCC ;
      private bool n189WWPMailBCC ;
      private bool n191WWPMailProcessed ;
      private bool n192WWPMailDetail ;
      private bool n127WWPNotificationId ;
      private bool Gx_longc ;
      private string Z166WWPMailBody ;
      private string A166WWPMailBody ;
      private string Z175WWPMailTo ;
      private string A175WWPMailTo ;
      private string Z188WWPMailCC ;
      private string A188WWPMailCC ;
      private string Z189WWPMailBCC ;
      private string A189WWPMailBCC ;
      private string Z176WWPMailSenderAddress ;
      private string A176WWPMailSenderAddress ;
      private string Z177WWPMailSenderName ;
      private string A177WWPMailSenderName ;
      private string Z192WWPMailDetail ;
      private string A192WWPMailDetail ;
      private string Z190WWPMailAttachmentFile ;
      private string A190WWPMailAttachmentFile ;
      private string Z174WWPMailSubject ;
      private string A174WWPMailSubject ;
      private string Z198WWPMailAttachmentName ;
      private string A198WWPMailAttachmentName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail bcwwpbaseobjects_mail_WWP_Mail ;
      private IDataStoreProvider pr_default ;
      private long[] BC000Q7_A185WWPMailId ;
      private string[] BC000Q7_A174WWPMailSubject ;
      private string[] BC000Q7_A166WWPMailBody ;
      private string[] BC000Q7_A175WWPMailTo ;
      private bool[] BC000Q7_n175WWPMailTo ;
      private string[] BC000Q7_A188WWPMailCC ;
      private bool[] BC000Q7_n188WWPMailCC ;
      private string[] BC000Q7_A189WWPMailBCC ;
      private bool[] BC000Q7_n189WWPMailBCC ;
      private string[] BC000Q7_A176WWPMailSenderAddress ;
      private string[] BC000Q7_A177WWPMailSenderName ;
      private short[] BC000Q7_A186WWPMailStatus ;
      private DateTime[] BC000Q7_A196WWPMailCreated ;
      private DateTime[] BC000Q7_A197WWPMailScheduled ;
      private DateTime[] BC000Q7_A191WWPMailProcessed ;
      private bool[] BC000Q7_n191WWPMailProcessed ;
      private string[] BC000Q7_A192WWPMailDetail ;
      private bool[] BC000Q7_n192WWPMailDetail ;
      private DateTime[] BC000Q7_A129WWPNotificationCreated ;
      private long[] BC000Q7_A127WWPNotificationId ;
      private bool[] BC000Q7_n127WWPNotificationId ;
      private DateTime[] BC000Q6_A129WWPNotificationCreated ;
      private long[] BC000Q8_A185WWPMailId ;
      private long[] BC000Q5_A185WWPMailId ;
      private string[] BC000Q5_A174WWPMailSubject ;
      private string[] BC000Q5_A166WWPMailBody ;
      private string[] BC000Q5_A175WWPMailTo ;
      private bool[] BC000Q5_n175WWPMailTo ;
      private string[] BC000Q5_A188WWPMailCC ;
      private bool[] BC000Q5_n188WWPMailCC ;
      private string[] BC000Q5_A189WWPMailBCC ;
      private bool[] BC000Q5_n189WWPMailBCC ;
      private string[] BC000Q5_A176WWPMailSenderAddress ;
      private string[] BC000Q5_A177WWPMailSenderName ;
      private short[] BC000Q5_A186WWPMailStatus ;
      private DateTime[] BC000Q5_A196WWPMailCreated ;
      private DateTime[] BC000Q5_A197WWPMailScheduled ;
      private DateTime[] BC000Q5_A191WWPMailProcessed ;
      private bool[] BC000Q5_n191WWPMailProcessed ;
      private string[] BC000Q5_A192WWPMailDetail ;
      private bool[] BC000Q5_n192WWPMailDetail ;
      private long[] BC000Q5_A127WWPNotificationId ;
      private bool[] BC000Q5_n127WWPNotificationId ;
      private long[] BC000Q4_A185WWPMailId ;
      private string[] BC000Q4_A174WWPMailSubject ;
      private string[] BC000Q4_A166WWPMailBody ;
      private string[] BC000Q4_A175WWPMailTo ;
      private bool[] BC000Q4_n175WWPMailTo ;
      private string[] BC000Q4_A188WWPMailCC ;
      private bool[] BC000Q4_n188WWPMailCC ;
      private string[] BC000Q4_A189WWPMailBCC ;
      private bool[] BC000Q4_n189WWPMailBCC ;
      private string[] BC000Q4_A176WWPMailSenderAddress ;
      private string[] BC000Q4_A177WWPMailSenderName ;
      private short[] BC000Q4_A186WWPMailStatus ;
      private DateTime[] BC000Q4_A196WWPMailCreated ;
      private DateTime[] BC000Q4_A197WWPMailScheduled ;
      private DateTime[] BC000Q4_A191WWPMailProcessed ;
      private bool[] BC000Q4_n191WWPMailProcessed ;
      private string[] BC000Q4_A192WWPMailDetail ;
      private bool[] BC000Q4_n192WWPMailDetail ;
      private long[] BC000Q4_A127WWPNotificationId ;
      private bool[] BC000Q4_n127WWPNotificationId ;
      private long[] BC000Q10_A185WWPMailId ;
      private DateTime[] BC000Q13_A129WWPNotificationCreated ;
      private long[] BC000Q14_A185WWPMailId ;
      private string[] BC000Q14_A174WWPMailSubject ;
      private string[] BC000Q14_A166WWPMailBody ;
      private string[] BC000Q14_A175WWPMailTo ;
      private bool[] BC000Q14_n175WWPMailTo ;
      private string[] BC000Q14_A188WWPMailCC ;
      private bool[] BC000Q14_n188WWPMailCC ;
      private string[] BC000Q14_A189WWPMailBCC ;
      private bool[] BC000Q14_n189WWPMailBCC ;
      private string[] BC000Q14_A176WWPMailSenderAddress ;
      private string[] BC000Q14_A177WWPMailSenderName ;
      private short[] BC000Q14_A186WWPMailStatus ;
      private DateTime[] BC000Q14_A196WWPMailCreated ;
      private DateTime[] BC000Q14_A197WWPMailScheduled ;
      private DateTime[] BC000Q14_A191WWPMailProcessed ;
      private bool[] BC000Q14_n191WWPMailProcessed ;
      private string[] BC000Q14_A192WWPMailDetail ;
      private bool[] BC000Q14_n192WWPMailDetail ;
      private DateTime[] BC000Q14_A129WWPNotificationCreated ;
      private long[] BC000Q14_A127WWPNotificationId ;
      private bool[] BC000Q14_n127WWPNotificationId ;
      private long[] BC000Q15_A185WWPMailId ;
      private string[] BC000Q15_A198WWPMailAttachmentName ;
      private string[] BC000Q15_A190WWPMailAttachmentFile ;
      private long[] BC000Q16_A185WWPMailId ;
      private string[] BC000Q16_A198WWPMailAttachmentName ;
      private long[] BC000Q3_A185WWPMailId ;
      private string[] BC000Q3_A198WWPMailAttachmentName ;
      private string[] BC000Q3_A190WWPMailAttachmentFile ;
      private long[] BC000Q2_A185WWPMailId ;
      private string[] BC000Q2_A198WWPMailAttachmentName ;
      private string[] BC000Q2_A190WWPMailAttachmentFile ;
      private long[] BC000Q20_A185WWPMailId ;
      private string[] BC000Q20_A198WWPMailAttachmentName ;
      private string[] BC000Q20_A190WWPMailAttachmentFile ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_mail_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_mail_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_mail_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[15])
      ,new UpdateCursor(def[16])
      ,new UpdateCursor(def[17])
      ,new ForEachCursor(def[18])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000Q2;
       prmBC000Q2 = new Object[] {
       new ParDef("WWPMailId",GXType.Int64,10,0) ,
       new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
       };
       Object[] prmBC000Q3;
       prmBC000Q3 = new Object[] {
       new ParDef("WWPMailId",GXType.Int64,10,0) ,
       new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
       };
       Object[] prmBC000Q4;
       prmBC000Q4 = new Object[] {
       new ParDef("WWPMailId",GXType.Int64,10,0)
       };
       Object[] prmBC000Q5;
       prmBC000Q5 = new Object[] {
       new ParDef("WWPMailId",GXType.Int64,10,0)
       };
       Object[] prmBC000Q6;
       prmBC000Q6 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmBC000Q7;
       prmBC000Q7 = new Object[] {
       new ParDef("WWPMailId",GXType.Int64,10,0)
       };
       Object[] prmBC000Q8;
       prmBC000Q8 = new Object[] {
       new ParDef("WWPMailId",GXType.Int64,10,0)
       };
       Object[] prmBC000Q9;
       prmBC000Q9 = new Object[] {
       new ParDef("WWPMailSubject",GXType.VarChar,80,0) ,
       new ParDef("WWPMailBody",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPMailTo",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPMailCC",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPMailBCC",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPMailSenderAddress",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPMailSenderName",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPMailStatus",GXType.Int16,4,0) ,
       new ParDef("WWPMailCreated",GXType.DateTime2,10,12) ,
       new ParDef("WWPMailScheduled",GXType.DateTime2,10,12) ,
       new ParDef("WWPMailProcessed",GXType.DateTime2,10,12){Nullable=true} ,
       new ParDef("WWPMailDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmBC000Q10;
       prmBC000Q10 = new Object[] {
       };
       Object[] prmBC000Q11;
       prmBC000Q11 = new Object[] {
       new ParDef("WWPMailSubject",GXType.VarChar,80,0) ,
       new ParDef("WWPMailBody",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPMailTo",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPMailCC",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPMailBCC",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPMailSenderAddress",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPMailSenderName",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPMailStatus",GXType.Int16,4,0) ,
       new ParDef("WWPMailCreated",GXType.DateTime2,10,12) ,
       new ParDef("WWPMailScheduled",GXType.DateTime2,10,12) ,
       new ParDef("WWPMailProcessed",GXType.DateTime2,10,12){Nullable=true} ,
       new ParDef("WWPMailDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true} ,
       new ParDef("WWPMailId",GXType.Int64,10,0)
       };
       Object[] prmBC000Q12;
       prmBC000Q12 = new Object[] {
       new ParDef("WWPMailId",GXType.Int64,10,0)
       };
       Object[] prmBC000Q13;
       prmBC000Q13 = new Object[] {
       new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmBC000Q14;
       prmBC000Q14 = new Object[] {
       new ParDef("WWPMailId",GXType.Int64,10,0)
       };
       Object[] prmBC000Q15;
       prmBC000Q15 = new Object[] {
       new ParDef("WWPMailId",GXType.Int64,10,0) ,
       new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
       };
       Object[] prmBC000Q16;
       prmBC000Q16 = new Object[] {
       new ParDef("WWPMailId",GXType.Int64,10,0) ,
       new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
       };
       Object[] prmBC000Q17;
       prmBC000Q17 = new Object[] {
       new ParDef("WWPMailId",GXType.Int64,10,0) ,
       new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0) ,
       new ParDef("WWPMailAttachmentFile",GXType.LongVarChar,2097152,0)
       };
       Object[] prmBC000Q18;
       prmBC000Q18 = new Object[] {
       new ParDef("WWPMailAttachmentFile",GXType.LongVarChar,2097152,0) ,
       new ParDef("WWPMailId",GXType.Int64,10,0) ,
       new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
       };
       Object[] prmBC000Q19;
       prmBC000Q19 = new Object[] {
       new ParDef("WWPMailId",GXType.Int64,10,0) ,
       new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
       };
       Object[] prmBC000Q20;
       prmBC000Q20 = new Object[] {
       new ParDef("WWPMailId",GXType.Int64,10,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC000Q2", "SELECT WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName  FOR UPDATE OF WWP_MailAttachments",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Q3", "SELECT WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Q4", "SELECT WWPMailId, WWPMailSubject, WWPMailBody, WWPMailTo, WWPMailCC, WWPMailBCC, WWPMailSenderAddress, WWPMailSenderName, WWPMailStatus, WWPMailCreated, WWPMailScheduled, WWPMailProcessed, WWPMailDetail, WWPNotificationId FROM WWP_Mail WHERE WWPMailId = :WWPMailId  FOR UPDATE OF WWP_Mail",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Q5", "SELECT WWPMailId, WWPMailSubject, WWPMailBody, WWPMailTo, WWPMailCC, WWPMailBCC, WWPMailSenderAddress, WWPMailSenderName, WWPMailStatus, WWPMailCreated, WWPMailScheduled, WWPMailProcessed, WWPMailDetail, WWPNotificationId FROM WWP_Mail WHERE WWPMailId = :WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Q6", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Q7", "SELECT TM1.WWPMailId, TM1.WWPMailSubject, TM1.WWPMailBody, TM1.WWPMailTo, TM1.WWPMailCC, TM1.WWPMailBCC, TM1.WWPMailSenderAddress, TM1.WWPMailSenderName, TM1.WWPMailStatus, TM1.WWPMailCreated, TM1.WWPMailScheduled, TM1.WWPMailProcessed, TM1.WWPMailDetail, T2.WWPNotificationCreated, TM1.WWPNotificationId FROM (WWP_Mail TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) WHERE TM1.WWPMailId = :WWPMailId ORDER BY TM1.WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q7,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Q8", "SELECT WWPMailId FROM WWP_Mail WHERE WWPMailId = :WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Q9", "SAVEPOINT gxupdate;INSERT INTO WWP_Mail(WWPMailSubject, WWPMailBody, WWPMailTo, WWPMailCC, WWPMailBCC, WWPMailSenderAddress, WWPMailSenderName, WWPMailStatus, WWPMailCreated, WWPMailScheduled, WWPMailProcessed, WWPMailDetail, WWPNotificationId) VALUES(:WWPMailSubject, :WWPMailBody, :WWPMailTo, :WWPMailCC, :WWPMailBCC, :WWPMailSenderAddress, :WWPMailSenderName, :WWPMailStatus, :WWPMailCreated, :WWPMailScheduled, :WWPMailProcessed, :WWPMailDetail, :WWPNotificationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000Q9)
          ,new CursorDef("BC000Q10", "SELECT currval('WWPMailId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q10,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Q11", "SAVEPOINT gxupdate;UPDATE WWP_Mail SET WWPMailSubject=:WWPMailSubject, WWPMailBody=:WWPMailBody, WWPMailTo=:WWPMailTo, WWPMailCC=:WWPMailCC, WWPMailBCC=:WWPMailBCC, WWPMailSenderAddress=:WWPMailSenderAddress, WWPMailSenderName=:WWPMailSenderName, WWPMailStatus=:WWPMailStatus, WWPMailCreated=:WWPMailCreated, WWPMailScheduled=:WWPMailScheduled, WWPMailProcessed=:WWPMailProcessed, WWPMailDetail=:WWPMailDetail, WWPNotificationId=:WWPNotificationId  WHERE WWPMailId = :WWPMailId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Q11)
          ,new CursorDef("BC000Q12", "SAVEPOINT gxupdate;DELETE FROM WWP_Mail  WHERE WWPMailId = :WWPMailId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Q12)
          ,new CursorDef("BC000Q13", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q13,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Q14", "SELECT TM1.WWPMailId, TM1.WWPMailSubject, TM1.WWPMailBody, TM1.WWPMailTo, TM1.WWPMailCC, TM1.WWPMailBCC, TM1.WWPMailSenderAddress, TM1.WWPMailSenderName, TM1.WWPMailStatus, TM1.WWPMailCreated, TM1.WWPMailScheduled, TM1.WWPMailProcessed, TM1.WWPMailDetail, T2.WWPNotificationCreated, TM1.WWPNotificationId FROM (WWP_Mail TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) WHERE TM1.WWPMailId = :WWPMailId ORDER BY TM1.WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q14,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Q15", "SELECT WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId and WWPMailAttachmentName = ( :WWPMailAttachmentName) ORDER BY WWPMailId, WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q15,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Q16", "SELECT WWPMailId, WWPMailAttachmentName FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q16,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Q17", "SAVEPOINT gxupdate;INSERT INTO WWP_MailAttachments(WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile) VALUES(:WWPMailId, :WWPMailAttachmentName, :WWPMailAttachmentFile);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000Q17)
          ,new CursorDef("BC000Q18", "SAVEPOINT gxupdate;UPDATE WWP_MailAttachments SET WWPMailAttachmentFile=:WWPMailAttachmentFile  WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Q18)
          ,new CursorDef("BC000Q19", "SAVEPOINT gxupdate;DELETE FROM WWP_MailAttachments  WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Q19)
          ,new CursorDef("BC000Q20", "SELECT WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId ORDER BY WWPMailId, WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q20,11, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             return;
          case 1 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             return;
          case 2 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
             ((bool[]) buf[8])[0] = rslt.wasNull(6);
             ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
             ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
             ((short[]) buf[11])[0] = rslt.getShort(9);
             ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
             ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
             ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
             ((bool[]) buf[15])[0] = rslt.wasNull(12);
             ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
             ((bool[]) buf[17])[0] = rslt.wasNull(13);
             ((long[]) buf[18])[0] = rslt.getLong(14);
             ((bool[]) buf[19])[0] = rslt.wasNull(14);
             return;
          case 3 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
             ((bool[]) buf[8])[0] = rslt.wasNull(6);
             ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
             ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
             ((short[]) buf[11])[0] = rslt.getShort(9);
             ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
             ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
             ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
             ((bool[]) buf[15])[0] = rslt.wasNull(12);
             ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
             ((bool[]) buf[17])[0] = rslt.wasNull(13);
             ((long[]) buf[18])[0] = rslt.getLong(14);
             ((bool[]) buf[19])[0] = rslt.wasNull(14);
             return;
          case 4 :
             ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
             return;
          case 5 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
             ((bool[]) buf[8])[0] = rslt.wasNull(6);
             ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
             ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
             ((short[]) buf[11])[0] = rslt.getShort(9);
             ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
             ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
             ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
             ((bool[]) buf[15])[0] = rslt.wasNull(12);
             ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
             ((bool[]) buf[17])[0] = rslt.wasNull(13);
             ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(14, true);
             ((long[]) buf[19])[0] = rslt.getLong(15);
             ((bool[]) buf[20])[0] = rslt.wasNull(15);
             return;
          case 6 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 8 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 11 :
             ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
             return;
          case 12 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
             ((bool[]) buf[8])[0] = rslt.wasNull(6);
             ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
             ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
             ((short[]) buf[11])[0] = rslt.getShort(9);
             ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
             ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
             ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
             ((bool[]) buf[15])[0] = rslt.wasNull(12);
             ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
             ((bool[]) buf[17])[0] = rslt.wasNull(13);
             ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(14, true);
             ((long[]) buf[19])[0] = rslt.getLong(15);
             ((bool[]) buf[20])[0] = rslt.wasNull(15);
             return;
          case 13 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             return;
          case 14 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 18 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             return;
    }
 }

}

}
