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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_userextended_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_userextended_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_userextended_bc( IGxContext context )
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
         ReadRow0G26( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0G26( ) ;
         standaloneModal( ) ;
         AddRow0G26( ) ;
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
               Z112WWPUserExtendedId = A112WWPUserExtendedId;
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

      protected void CONFIRM_0G0( )
      {
         BeforeValidate0G26( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0G26( ) ;
            }
            else
            {
               CheckExtendedTable0G26( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0G26( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0G26( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z121WWPUserExtendedName = A121WWPUserExtendedName;
            Z113WWPUserExtendedFullName = A113WWPUserExtendedFullName;
            Z120WWPUserExtendedPhone = A120WWPUserExtendedPhone;
            Z114WWPUserExtendedEmail = A114WWPUserExtendedEmail;
            Z116WWPUserExtendedEmaiNotif = A116WWPUserExtendedEmaiNotif;
            Z117WWPUserExtendedSMSNotif = A117WWPUserExtendedSMSNotif;
            Z118WWPUserExtendedMobileNotif = A118WWPUserExtendedMobileNotif;
            Z119WWPUserExtendedDesktopNotif = A119WWPUserExtendedDesktopNotif;
            Z122WWPUserExtendedDeleted = A122WWPUserExtendedDeleted;
            Z123WWPUserExtendedDeletedIn = A123WWPUserExtendedDeletedIn;
         }
         if ( GX_JID == -2 )
         {
            Z112WWPUserExtendedId = A112WWPUserExtendedId;
            Z115WWPUserExtendedPhoto = A115WWPUserExtendedPhoto;
            Z40000WWPUserExtendedPhoto_GXI = A40000WWPUserExtendedPhoto_GXI;
            Z121WWPUserExtendedName = A121WWPUserExtendedName;
            Z113WWPUserExtendedFullName = A113WWPUserExtendedFullName;
            Z120WWPUserExtendedPhone = A120WWPUserExtendedPhone;
            Z114WWPUserExtendedEmail = A114WWPUserExtendedEmail;
            Z116WWPUserExtendedEmaiNotif = A116WWPUserExtendedEmaiNotif;
            Z117WWPUserExtendedSMSNotif = A117WWPUserExtendedSMSNotif;
            Z118WWPUserExtendedMobileNotif = A118WWPUserExtendedMobileNotif;
            Z119WWPUserExtendedDesktopNotif = A119WWPUserExtendedDesktopNotif;
            Z122WWPUserExtendedDeleted = A122WWPUserExtendedDeleted;
            Z123WWPUserExtendedDeletedIn = A123WWPUserExtendedDeletedIn;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0G26( )
      {
         /* Using cursor BC000G4 */
         pr_default.execute(2, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound26 = 1;
            A40000WWPUserExtendedPhoto_GXI = BC000G4_A40000WWPUserExtendedPhoto_GXI[0];
            A121WWPUserExtendedName = BC000G4_A121WWPUserExtendedName[0];
            A113WWPUserExtendedFullName = BC000G4_A113WWPUserExtendedFullName[0];
            A120WWPUserExtendedPhone = BC000G4_A120WWPUserExtendedPhone[0];
            A114WWPUserExtendedEmail = BC000G4_A114WWPUserExtendedEmail[0];
            A116WWPUserExtendedEmaiNotif = BC000G4_A116WWPUserExtendedEmaiNotif[0];
            A117WWPUserExtendedSMSNotif = BC000G4_A117WWPUserExtendedSMSNotif[0];
            A118WWPUserExtendedMobileNotif = BC000G4_A118WWPUserExtendedMobileNotif[0];
            A119WWPUserExtendedDesktopNotif = BC000G4_A119WWPUserExtendedDesktopNotif[0];
            A122WWPUserExtendedDeleted = BC000G4_A122WWPUserExtendedDeleted[0];
            A123WWPUserExtendedDeletedIn = BC000G4_A123WWPUserExtendedDeletedIn[0];
            n123WWPUserExtendedDeletedIn = BC000G4_n123WWPUserExtendedDeletedIn[0];
            A115WWPUserExtendedPhoto = BC000G4_A115WWPUserExtendedPhoto[0];
            ZM0G26( -2) ;
         }
         pr_default.close(2);
         OnLoadActions0G26( ) ;
      }

      protected void OnLoadActions0G26( )
      {
      }

      protected void CheckExtendedTable0G26( )
      {
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A114WWPUserExtendedEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "User Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0G26( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0G26( )
      {
         /* Using cursor BC000G5 */
         pr_default.execute(3, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound26 = 1;
         }
         else
         {
            RcdFound26 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000G3 */
         pr_default.execute(1, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0G26( 2) ;
            RcdFound26 = 1;
            A112WWPUserExtendedId = BC000G3_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = BC000G3_n112WWPUserExtendedId[0];
            A40000WWPUserExtendedPhoto_GXI = BC000G3_A40000WWPUserExtendedPhoto_GXI[0];
            A121WWPUserExtendedName = BC000G3_A121WWPUserExtendedName[0];
            A113WWPUserExtendedFullName = BC000G3_A113WWPUserExtendedFullName[0];
            A120WWPUserExtendedPhone = BC000G3_A120WWPUserExtendedPhone[0];
            A114WWPUserExtendedEmail = BC000G3_A114WWPUserExtendedEmail[0];
            A116WWPUserExtendedEmaiNotif = BC000G3_A116WWPUserExtendedEmaiNotif[0];
            A117WWPUserExtendedSMSNotif = BC000G3_A117WWPUserExtendedSMSNotif[0];
            A118WWPUserExtendedMobileNotif = BC000G3_A118WWPUserExtendedMobileNotif[0];
            A119WWPUserExtendedDesktopNotif = BC000G3_A119WWPUserExtendedDesktopNotif[0];
            A122WWPUserExtendedDeleted = BC000G3_A122WWPUserExtendedDeleted[0];
            A123WWPUserExtendedDeletedIn = BC000G3_A123WWPUserExtendedDeletedIn[0];
            n123WWPUserExtendedDeletedIn = BC000G3_n123WWPUserExtendedDeletedIn[0];
            A115WWPUserExtendedPhoto = BC000G3_A115WWPUserExtendedPhoto[0];
            Z112WWPUserExtendedId = A112WWPUserExtendedId;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0G26( ) ;
            if ( AnyError == 1 )
            {
               RcdFound26 = 0;
               InitializeNonKey0G26( ) ;
            }
            Gx_mode = sMode26;
         }
         else
         {
            RcdFound26 = 0;
            InitializeNonKey0G26( ) ;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode26;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0G26( ) ;
         if ( RcdFound26 == 0 )
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
         CONFIRM_0G0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0G26( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000G2 */
            pr_default.execute(0, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_UserExtended"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z121WWPUserExtendedName, BC000G2_A121WWPUserExtendedName[0]) != 0 ) || ( StringUtil.StrCmp(Z113WWPUserExtendedFullName, BC000G2_A113WWPUserExtendedFullName[0]) != 0 ) || ( StringUtil.StrCmp(Z120WWPUserExtendedPhone, BC000G2_A120WWPUserExtendedPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z114WWPUserExtendedEmail, BC000G2_A114WWPUserExtendedEmail[0]) != 0 ) || ( Z116WWPUserExtendedEmaiNotif != BC000G2_A116WWPUserExtendedEmaiNotif[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z117WWPUserExtendedSMSNotif != BC000G2_A117WWPUserExtendedSMSNotif[0] ) || ( Z118WWPUserExtendedMobileNotif != BC000G2_A118WWPUserExtendedMobileNotif[0] ) || ( Z119WWPUserExtendedDesktopNotif != BC000G2_A119WWPUserExtendedDesktopNotif[0] ) || ( Z122WWPUserExtendedDeleted != BC000G2_A122WWPUserExtendedDeleted[0] ) || ( Z123WWPUserExtendedDeletedIn != BC000G2_A123WWPUserExtendedDeletedIn[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_UserExtended"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G26( )
      {
         BeforeValidate0G26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G26( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G26( 0) ;
            CheckOptimisticConcurrency0G26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000G6 */
                     pr_default.execute(4, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId, A115WWPUserExtendedPhoto, A40000WWPUserExtendedPhoto_GXI, A121WWPUserExtendedName, A113WWPUserExtendedFullName, A120WWPUserExtendedPhone, A114WWPUserExtendedEmail, A116WWPUserExtendedEmaiNotif, A117WWPUserExtendedSMSNotif, A118WWPUserExtendedMobileNotif, A119WWPUserExtendedDesktopNotif, A122WWPUserExtendedDeleted, n123WWPUserExtendedDeletedIn, A123WWPUserExtendedDeletedIn});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
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
               Load0G26( ) ;
            }
            EndLevel0G26( ) ;
         }
         CloseExtendedTableCursors0G26( ) ;
      }

      protected void Update0G26( )
      {
         BeforeValidate0G26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G26( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0G26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000G7 */
                     pr_default.execute(5, new Object[] {A121WWPUserExtendedName, A113WWPUserExtendedFullName, A120WWPUserExtendedPhone, A114WWPUserExtendedEmail, A116WWPUserExtendedEmaiNotif, A117WWPUserExtendedSMSNotif, A118WWPUserExtendedMobileNotif, A119WWPUserExtendedDesktopNotif, A122WWPUserExtendedDeleted, n123WWPUserExtendedDeletedIn, A123WWPUserExtendedDeletedIn, n112WWPUserExtendedId, A112WWPUserExtendedId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_UserExtended"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0G26( ) ;
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
            EndLevel0G26( ) ;
         }
         CloseExtendedTableCursors0G26( ) ;
      }

      protected void DeferredUpdate0G26( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000G8 */
            pr_default.execute(6, new Object[] {A115WWPUserExtendedPhoto, A40000WWPUserExtendedPhoto_GXI, n112WWPUserExtendedId, A112WWPUserExtendedId});
            pr_default.close(6);
            pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0G26( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G26( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G26( ) ;
            AfterConfirm0G26( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G26( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000G9 */
                  pr_default.execute(7, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
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
         sMode26 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0G26( ) ;
         Gx_mode = sMode26;
      }

      protected void OnDeleteControls0G26( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000G10 */
            pr_default.execute(8, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_DiscussionMessageMention", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC000G11 */
            pr_default.execute(9, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWPForm Instance", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000G12 */
            pr_default.execute(10, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_DiscussionMessage", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC000G13 */
            pr_default.execute(11, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_Notification", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC000G14 */
            pr_default.execute(12, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_WebClient", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC000G15 */
            pr_default.execute(13, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_Subscription", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel0G26( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0G26( ) ;
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

      public void ScanKeyStart0G26( )
      {
         /* Using cursor BC000G16 */
         pr_default.execute(14, new Object[] {n112WWPUserExtendedId, A112WWPUserExtendedId});
         RcdFound26 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound26 = 1;
            A112WWPUserExtendedId = BC000G16_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = BC000G16_n112WWPUserExtendedId[0];
            A40000WWPUserExtendedPhoto_GXI = BC000G16_A40000WWPUserExtendedPhoto_GXI[0];
            A121WWPUserExtendedName = BC000G16_A121WWPUserExtendedName[0];
            A113WWPUserExtendedFullName = BC000G16_A113WWPUserExtendedFullName[0];
            A120WWPUserExtendedPhone = BC000G16_A120WWPUserExtendedPhone[0];
            A114WWPUserExtendedEmail = BC000G16_A114WWPUserExtendedEmail[0];
            A116WWPUserExtendedEmaiNotif = BC000G16_A116WWPUserExtendedEmaiNotif[0];
            A117WWPUserExtendedSMSNotif = BC000G16_A117WWPUserExtendedSMSNotif[0];
            A118WWPUserExtendedMobileNotif = BC000G16_A118WWPUserExtendedMobileNotif[0];
            A119WWPUserExtendedDesktopNotif = BC000G16_A119WWPUserExtendedDesktopNotif[0];
            A122WWPUserExtendedDeleted = BC000G16_A122WWPUserExtendedDeleted[0];
            A123WWPUserExtendedDeletedIn = BC000G16_A123WWPUserExtendedDeletedIn[0];
            n123WWPUserExtendedDeletedIn = BC000G16_n123WWPUserExtendedDeletedIn[0];
            A115WWPUserExtendedPhoto = BC000G16_A115WWPUserExtendedPhoto[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0G26( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound26 = 0;
         ScanKeyLoad0G26( ) ;
      }

      protected void ScanKeyLoad0G26( )
      {
         sMode26 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound26 = 1;
            A112WWPUserExtendedId = BC000G16_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = BC000G16_n112WWPUserExtendedId[0];
            A40000WWPUserExtendedPhoto_GXI = BC000G16_A40000WWPUserExtendedPhoto_GXI[0];
            A121WWPUserExtendedName = BC000G16_A121WWPUserExtendedName[0];
            A113WWPUserExtendedFullName = BC000G16_A113WWPUserExtendedFullName[0];
            A120WWPUserExtendedPhone = BC000G16_A120WWPUserExtendedPhone[0];
            A114WWPUserExtendedEmail = BC000G16_A114WWPUserExtendedEmail[0];
            A116WWPUserExtendedEmaiNotif = BC000G16_A116WWPUserExtendedEmaiNotif[0];
            A117WWPUserExtendedSMSNotif = BC000G16_A117WWPUserExtendedSMSNotif[0];
            A118WWPUserExtendedMobileNotif = BC000G16_A118WWPUserExtendedMobileNotif[0];
            A119WWPUserExtendedDesktopNotif = BC000G16_A119WWPUserExtendedDesktopNotif[0];
            A122WWPUserExtendedDeleted = BC000G16_A122WWPUserExtendedDeleted[0];
            A123WWPUserExtendedDeletedIn = BC000G16_A123WWPUserExtendedDeletedIn[0];
            n123WWPUserExtendedDeletedIn = BC000G16_n123WWPUserExtendedDeletedIn[0];
            A115WWPUserExtendedPhoto = BC000G16_A115WWPUserExtendedPhoto[0];
         }
         Gx_mode = sMode26;
      }

      protected void ScanKeyEnd0G26( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0G26( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0G26( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0G26( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G26( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G26( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G26( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G26( )
      {
      }

      protected void send_integrity_lvl_hashes0G26( )
      {
      }

      protected void AddRow0G26( )
      {
         VarsToRow26( bcwwpbaseobjects_WWP_UserExtended) ;
      }

      protected void ReadRow0G26( )
      {
         RowToVars26( bcwwpbaseobjects_WWP_UserExtended, 1) ;
      }

      protected void InitializeNonKey0G26( )
      {
         A115WWPUserExtendedPhoto = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         A121WWPUserExtendedName = "";
         A113WWPUserExtendedFullName = "";
         A120WWPUserExtendedPhone = "";
         A114WWPUserExtendedEmail = "";
         A116WWPUserExtendedEmaiNotif = false;
         A117WWPUserExtendedSMSNotif = false;
         A118WWPUserExtendedMobileNotif = false;
         A119WWPUserExtendedDesktopNotif = false;
         A122WWPUserExtendedDeleted = false;
         A123WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
         n123WWPUserExtendedDeletedIn = false;
         Z121WWPUserExtendedName = "";
         Z113WWPUserExtendedFullName = "";
         Z120WWPUserExtendedPhone = "";
         Z114WWPUserExtendedEmail = "";
         Z116WWPUserExtendedEmaiNotif = false;
         Z117WWPUserExtendedSMSNotif = false;
         Z118WWPUserExtendedMobileNotif = false;
         Z119WWPUserExtendedDesktopNotif = false;
         Z122WWPUserExtendedDeleted = false;
         Z123WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll0G26( )
      {
         A112WWPUserExtendedId = "";
         n112WWPUserExtendedId = false;
         InitializeNonKey0G26( ) ;
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

      public void VarsToRow26( GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended obj26 )
      {
         obj26.gxTpr_Mode = Gx_mode;
         obj26.gxTpr_Wwpuserextendedphoto = A115WWPUserExtendedPhoto;
         obj26.gxTpr_Wwpuserextendedphoto_gxi = A40000WWPUserExtendedPhoto_GXI;
         obj26.gxTpr_Wwpuserextendedname = A121WWPUserExtendedName;
         obj26.gxTpr_Wwpuserextendedfullname = A113WWPUserExtendedFullName;
         obj26.gxTpr_Wwpuserextendedphone = A120WWPUserExtendedPhone;
         obj26.gxTpr_Wwpuserextendedemail = A114WWPUserExtendedEmail;
         obj26.gxTpr_Wwpuserextendedemainotif = A116WWPUserExtendedEmaiNotif;
         obj26.gxTpr_Wwpuserextendedsmsnotif = A117WWPUserExtendedSMSNotif;
         obj26.gxTpr_Wwpuserextendedmobilenotif = A118WWPUserExtendedMobileNotif;
         obj26.gxTpr_Wwpuserextendeddesktopnotif = A119WWPUserExtendedDesktopNotif;
         obj26.gxTpr_Wwpuserextendeddeleted = A122WWPUserExtendedDeleted;
         obj26.gxTpr_Wwpuserextendeddeletedin = A123WWPUserExtendedDeletedIn;
         obj26.gxTpr_Wwpuserextendedid = A112WWPUserExtendedId;
         obj26.gxTpr_Wwpuserextendedid_Z = Z112WWPUserExtendedId;
         obj26.gxTpr_Wwpuserextendedname_Z = Z121WWPUserExtendedName;
         obj26.gxTpr_Wwpuserextendedfullname_Z = Z113WWPUserExtendedFullName;
         obj26.gxTpr_Wwpuserextendedphone_Z = Z120WWPUserExtendedPhone;
         obj26.gxTpr_Wwpuserextendedemail_Z = Z114WWPUserExtendedEmail;
         obj26.gxTpr_Wwpuserextendedemainotif_Z = Z116WWPUserExtendedEmaiNotif;
         obj26.gxTpr_Wwpuserextendedsmsnotif_Z = Z117WWPUserExtendedSMSNotif;
         obj26.gxTpr_Wwpuserextendedmobilenotif_Z = Z118WWPUserExtendedMobileNotif;
         obj26.gxTpr_Wwpuserextendeddesktopnotif_Z = Z119WWPUserExtendedDesktopNotif;
         obj26.gxTpr_Wwpuserextendeddeleted_Z = Z122WWPUserExtendedDeleted;
         obj26.gxTpr_Wwpuserextendeddeletedin_Z = Z123WWPUserExtendedDeletedIn;
         obj26.gxTpr_Wwpuserextendedphoto_gxi_Z = Z40000WWPUserExtendedPhoto_GXI;
         obj26.gxTpr_Wwpuserextendedid_N = (short)(Convert.ToInt16(n112WWPUserExtendedId));
         obj26.gxTpr_Wwpuserextendeddeletedin_N = (short)(Convert.ToInt16(n123WWPUserExtendedDeletedIn));
         obj26.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow26( GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended obj26 )
      {
         obj26.gxTpr_Wwpuserextendedid = A112WWPUserExtendedId;
         return  ;
      }

      public void RowToVars26( GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended obj26 ,
                               int forceLoad )
      {
         Gx_mode = obj26.gxTpr_Mode;
         A115WWPUserExtendedPhoto = obj26.gxTpr_Wwpuserextendedphoto;
         A40000WWPUserExtendedPhoto_GXI = obj26.gxTpr_Wwpuserextendedphoto_gxi;
         A121WWPUserExtendedName = obj26.gxTpr_Wwpuserextendedname;
         A113WWPUserExtendedFullName = obj26.gxTpr_Wwpuserextendedfullname;
         A120WWPUserExtendedPhone = obj26.gxTpr_Wwpuserextendedphone;
         A114WWPUserExtendedEmail = obj26.gxTpr_Wwpuserextendedemail;
         A116WWPUserExtendedEmaiNotif = obj26.gxTpr_Wwpuserextendedemainotif;
         A117WWPUserExtendedSMSNotif = obj26.gxTpr_Wwpuserextendedsmsnotif;
         A118WWPUserExtendedMobileNotif = obj26.gxTpr_Wwpuserextendedmobilenotif;
         A119WWPUserExtendedDesktopNotif = obj26.gxTpr_Wwpuserextendeddesktopnotif;
         A122WWPUserExtendedDeleted = obj26.gxTpr_Wwpuserextendeddeleted;
         A123WWPUserExtendedDeletedIn = obj26.gxTpr_Wwpuserextendeddeletedin;
         n123WWPUserExtendedDeletedIn = false;
         A112WWPUserExtendedId = obj26.gxTpr_Wwpuserextendedid;
         n112WWPUserExtendedId = false;
         Z112WWPUserExtendedId = obj26.gxTpr_Wwpuserextendedid_Z;
         Z121WWPUserExtendedName = obj26.gxTpr_Wwpuserextendedname_Z;
         Z113WWPUserExtendedFullName = obj26.gxTpr_Wwpuserextendedfullname_Z;
         Z120WWPUserExtendedPhone = obj26.gxTpr_Wwpuserextendedphone_Z;
         Z114WWPUserExtendedEmail = obj26.gxTpr_Wwpuserextendedemail_Z;
         Z116WWPUserExtendedEmaiNotif = obj26.gxTpr_Wwpuserextendedemainotif_Z;
         Z117WWPUserExtendedSMSNotif = obj26.gxTpr_Wwpuserextendedsmsnotif_Z;
         Z118WWPUserExtendedMobileNotif = obj26.gxTpr_Wwpuserextendedmobilenotif_Z;
         Z119WWPUserExtendedDesktopNotif = obj26.gxTpr_Wwpuserextendeddesktopnotif_Z;
         Z122WWPUserExtendedDeleted = obj26.gxTpr_Wwpuserextendeddeleted_Z;
         Z123WWPUserExtendedDeletedIn = obj26.gxTpr_Wwpuserextendeddeletedin_Z;
         Z40000WWPUserExtendedPhoto_GXI = obj26.gxTpr_Wwpuserextendedphoto_gxi_Z;
         n112WWPUserExtendedId = (bool)(Convert.ToBoolean(obj26.gxTpr_Wwpuserextendedid_N));
         n123WWPUserExtendedDeletedIn = (bool)(Convert.ToBoolean(obj26.gxTpr_Wwpuserextendeddeletedin_N));
         Gx_mode = obj26.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A112WWPUserExtendedId = (string)getParm(obj,0);
         n112WWPUserExtendedId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0G26( ) ;
         ScanKeyStart0G26( ) ;
         if ( RcdFound26 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z112WWPUserExtendedId = A112WWPUserExtendedId;
         }
         ZM0G26( -2) ;
         OnLoadActions0G26( ) ;
         AddRow0G26( ) ;
         ScanKeyEnd0G26( ) ;
         if ( RcdFound26 == 0 )
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
         RowToVars26( bcwwpbaseobjects_WWP_UserExtended, 0) ;
         ScanKeyStart0G26( ) ;
         if ( RcdFound26 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z112WWPUserExtendedId = A112WWPUserExtendedId;
         }
         ZM0G26( -2) ;
         OnLoadActions0G26( ) ;
         AddRow0G26( ) ;
         ScanKeyEnd0G26( ) ;
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0G26( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0G26( ) ;
         }
         else
         {
            if ( RcdFound26 == 1 )
            {
               if ( StringUtil.StrCmp(A112WWPUserExtendedId, Z112WWPUserExtendedId) != 0 )
               {
                  A112WWPUserExtendedId = Z112WWPUserExtendedId;
                  n112WWPUserExtendedId = false;
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
                  Update0G26( ) ;
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
                  if ( StringUtil.StrCmp(A112WWPUserExtendedId, Z112WWPUserExtendedId) != 0 )
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
                        Insert0G26( ) ;
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
                        Insert0G26( ) ;
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
         RowToVars26( bcwwpbaseobjects_WWP_UserExtended, 1) ;
         SaveImpl( ) ;
         VarsToRow26( bcwwpbaseobjects_WWP_UserExtended) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars26( bcwwpbaseobjects_WWP_UserExtended, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0G26( ) ;
         AfterTrn( ) ;
         VarsToRow26( bcwwpbaseobjects_WWP_UserExtended) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow26( bcwwpbaseobjects_WWP_UserExtended) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended auxBC = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A112WWPUserExtendedId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_WWP_UserExtended);
               auxBC.Save();
               bcwwpbaseobjects_WWP_UserExtended.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars26( bcwwpbaseobjects_WWP_UserExtended, 1) ;
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
         RowToVars26( bcwwpbaseobjects_WWP_UserExtended, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0G26( ) ;
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
               VarsToRow26( bcwwpbaseobjects_WWP_UserExtended) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow26( bcwwpbaseobjects_WWP_UserExtended) ;
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
         RowToVars26( bcwwpbaseobjects_WWP_UserExtended, 0) ;
         GetKey0G26( ) ;
         if ( RcdFound26 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A112WWPUserExtendedId, Z112WWPUserExtendedId) != 0 )
            {
               A112WWPUserExtendedId = Z112WWPUserExtendedId;
               n112WWPUserExtendedId = false;
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
            if ( StringUtil.StrCmp(A112WWPUserExtendedId, Z112WWPUserExtendedId) != 0 )
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
         context.RollbackDataStores("wwpbaseobjects.wwp_userextended_bc",pr_default);
         VarsToRow26( bcwwpbaseobjects_WWP_UserExtended) ;
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
         Gx_mode = bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_WWP_UserExtended )
         {
            bcwwpbaseobjects_WWP_UserExtended = (GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow26( bcwwpbaseobjects_WWP_UserExtended) ;
            }
            else
            {
               RowToVars26( bcwwpbaseobjects_WWP_UserExtended, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars26( bcwwpbaseobjects_WWP_UserExtended, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_UserExtended WWP_UserExtended_BC
      {
         get {
            return bcwwpbaseobjects_WWP_UserExtended ;
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
            return "wwpuserextended_Execute" ;
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
         Z112WWPUserExtendedId = "";
         A112WWPUserExtendedId = "";
         Z121WWPUserExtendedName = "";
         A121WWPUserExtendedName = "";
         Z113WWPUserExtendedFullName = "";
         A113WWPUserExtendedFullName = "";
         Z120WWPUserExtendedPhone = "";
         A120WWPUserExtendedPhone = "";
         Z114WWPUserExtendedEmail = "";
         A114WWPUserExtendedEmail = "";
         Z123WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
         A123WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
         Z115WWPUserExtendedPhoto = "";
         A115WWPUserExtendedPhoto = "";
         Z40000WWPUserExtendedPhoto_GXI = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         BC000G4_A112WWPUserExtendedId = new string[] {""} ;
         BC000G4_n112WWPUserExtendedId = new bool[] {false} ;
         BC000G4_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC000G4_A121WWPUserExtendedName = new string[] {""} ;
         BC000G4_A113WWPUserExtendedFullName = new string[] {""} ;
         BC000G4_A120WWPUserExtendedPhone = new string[] {""} ;
         BC000G4_A114WWPUserExtendedEmail = new string[] {""} ;
         BC000G4_A116WWPUserExtendedEmaiNotif = new bool[] {false} ;
         BC000G4_A117WWPUserExtendedSMSNotif = new bool[] {false} ;
         BC000G4_A118WWPUserExtendedMobileNotif = new bool[] {false} ;
         BC000G4_A119WWPUserExtendedDesktopNotif = new bool[] {false} ;
         BC000G4_A122WWPUserExtendedDeleted = new bool[] {false} ;
         BC000G4_A123WWPUserExtendedDeletedIn = new DateTime[] {DateTime.MinValue} ;
         BC000G4_n123WWPUserExtendedDeletedIn = new bool[] {false} ;
         BC000G4_A115WWPUserExtendedPhoto = new string[] {""} ;
         BC000G5_A112WWPUserExtendedId = new string[] {""} ;
         BC000G5_n112WWPUserExtendedId = new bool[] {false} ;
         BC000G3_A112WWPUserExtendedId = new string[] {""} ;
         BC000G3_n112WWPUserExtendedId = new bool[] {false} ;
         BC000G3_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC000G3_A121WWPUserExtendedName = new string[] {""} ;
         BC000G3_A113WWPUserExtendedFullName = new string[] {""} ;
         BC000G3_A120WWPUserExtendedPhone = new string[] {""} ;
         BC000G3_A114WWPUserExtendedEmail = new string[] {""} ;
         BC000G3_A116WWPUserExtendedEmaiNotif = new bool[] {false} ;
         BC000G3_A117WWPUserExtendedSMSNotif = new bool[] {false} ;
         BC000G3_A118WWPUserExtendedMobileNotif = new bool[] {false} ;
         BC000G3_A119WWPUserExtendedDesktopNotif = new bool[] {false} ;
         BC000G3_A122WWPUserExtendedDeleted = new bool[] {false} ;
         BC000G3_A123WWPUserExtendedDeletedIn = new DateTime[] {DateTime.MinValue} ;
         BC000G3_n123WWPUserExtendedDeletedIn = new bool[] {false} ;
         BC000G3_A115WWPUserExtendedPhoto = new string[] {""} ;
         sMode26 = "";
         BC000G2_A112WWPUserExtendedId = new string[] {""} ;
         BC000G2_n112WWPUserExtendedId = new bool[] {false} ;
         BC000G2_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC000G2_A121WWPUserExtendedName = new string[] {""} ;
         BC000G2_A113WWPUserExtendedFullName = new string[] {""} ;
         BC000G2_A120WWPUserExtendedPhone = new string[] {""} ;
         BC000G2_A114WWPUserExtendedEmail = new string[] {""} ;
         BC000G2_A116WWPUserExtendedEmaiNotif = new bool[] {false} ;
         BC000G2_A117WWPUserExtendedSMSNotif = new bool[] {false} ;
         BC000G2_A118WWPUserExtendedMobileNotif = new bool[] {false} ;
         BC000G2_A119WWPUserExtendedDesktopNotif = new bool[] {false} ;
         BC000G2_A122WWPUserExtendedDeleted = new bool[] {false} ;
         BC000G2_A123WWPUserExtendedDeletedIn = new DateTime[] {DateTime.MinValue} ;
         BC000G2_n123WWPUserExtendedDeletedIn = new bool[] {false} ;
         BC000G2_A115WWPUserExtendedPhoto = new string[] {""} ;
         BC000G10_A200WWPDiscussionMessageId = new long[1] ;
         BC000G10_A201WWPDiscussionMentionUserId = new string[] {""} ;
         BC000G11_A214WWPFormInstanceId = new int[1] ;
         BC000G12_A200WWPDiscussionMessageId = new long[1] ;
         BC000G13_A127WWPNotificationId = new long[1] ;
         BC000G14_A153WWPWebClientId = new string[] {""} ;
         BC000G15_A130WWPSubscriptionId = new long[1] ;
         BC000G16_A112WWPUserExtendedId = new string[] {""} ;
         BC000G16_n112WWPUserExtendedId = new bool[] {false} ;
         BC000G16_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC000G16_A121WWPUserExtendedName = new string[] {""} ;
         BC000G16_A113WWPUserExtendedFullName = new string[] {""} ;
         BC000G16_A120WWPUserExtendedPhone = new string[] {""} ;
         BC000G16_A114WWPUserExtendedEmail = new string[] {""} ;
         BC000G16_A116WWPUserExtendedEmaiNotif = new bool[] {false} ;
         BC000G16_A117WWPUserExtendedSMSNotif = new bool[] {false} ;
         BC000G16_A118WWPUserExtendedMobileNotif = new bool[] {false} ;
         BC000G16_A119WWPUserExtendedDesktopNotif = new bool[] {false} ;
         BC000G16_A122WWPUserExtendedDeleted = new bool[] {false} ;
         BC000G16_A123WWPUserExtendedDeletedIn = new DateTime[] {DateTime.MinValue} ;
         BC000G16_n123WWPUserExtendedDeletedIn = new bool[] {false} ;
         BC000G16_A115WWPUserExtendedPhoto = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_userextended_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_userextended_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_userextended_bc__default(),
            new Object[][] {
                new Object[] {
               BC000G2_A112WWPUserExtendedId, BC000G2_A40000WWPUserExtendedPhoto_GXI, BC000G2_A121WWPUserExtendedName, BC000G2_A113WWPUserExtendedFullName, BC000G2_A120WWPUserExtendedPhone, BC000G2_A114WWPUserExtendedEmail, BC000G2_A116WWPUserExtendedEmaiNotif, BC000G2_A117WWPUserExtendedSMSNotif, BC000G2_A118WWPUserExtendedMobileNotif, BC000G2_A119WWPUserExtendedDesktopNotif,
               BC000G2_A122WWPUserExtendedDeleted, BC000G2_A123WWPUserExtendedDeletedIn, BC000G2_n123WWPUserExtendedDeletedIn, BC000G2_A115WWPUserExtendedPhoto
               }
               , new Object[] {
               BC000G3_A112WWPUserExtendedId, BC000G3_A40000WWPUserExtendedPhoto_GXI, BC000G3_A121WWPUserExtendedName, BC000G3_A113WWPUserExtendedFullName, BC000G3_A120WWPUserExtendedPhone, BC000G3_A114WWPUserExtendedEmail, BC000G3_A116WWPUserExtendedEmaiNotif, BC000G3_A117WWPUserExtendedSMSNotif, BC000G3_A118WWPUserExtendedMobileNotif, BC000G3_A119WWPUserExtendedDesktopNotif,
               BC000G3_A122WWPUserExtendedDeleted, BC000G3_A123WWPUserExtendedDeletedIn, BC000G3_n123WWPUserExtendedDeletedIn, BC000G3_A115WWPUserExtendedPhoto
               }
               , new Object[] {
               BC000G4_A112WWPUserExtendedId, BC000G4_A40000WWPUserExtendedPhoto_GXI, BC000G4_A121WWPUserExtendedName, BC000G4_A113WWPUserExtendedFullName, BC000G4_A120WWPUserExtendedPhone, BC000G4_A114WWPUserExtendedEmail, BC000G4_A116WWPUserExtendedEmaiNotif, BC000G4_A117WWPUserExtendedSMSNotif, BC000G4_A118WWPUserExtendedMobileNotif, BC000G4_A119WWPUserExtendedDesktopNotif,
               BC000G4_A122WWPUserExtendedDeleted, BC000G4_A123WWPUserExtendedDeletedIn, BC000G4_n123WWPUserExtendedDeletedIn, BC000G4_A115WWPUserExtendedPhoto
               }
               , new Object[] {
               BC000G5_A112WWPUserExtendedId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000G10_A200WWPDiscussionMessageId, BC000G10_A201WWPDiscussionMentionUserId
               }
               , new Object[] {
               BC000G11_A214WWPFormInstanceId
               }
               , new Object[] {
               BC000G12_A200WWPDiscussionMessageId
               }
               , new Object[] {
               BC000G13_A127WWPNotificationId
               }
               , new Object[] {
               BC000G14_A153WWPWebClientId
               }
               , new Object[] {
               BC000G15_A130WWPSubscriptionId
               }
               , new Object[] {
               BC000G16_A112WWPUserExtendedId, BC000G16_A40000WWPUserExtendedPhoto_GXI, BC000G16_A121WWPUserExtendedName, BC000G16_A113WWPUserExtendedFullName, BC000G16_A120WWPUserExtendedPhone, BC000G16_A114WWPUserExtendedEmail, BC000G16_A116WWPUserExtendedEmaiNotif, BC000G16_A117WWPUserExtendedSMSNotif, BC000G16_A118WWPUserExtendedMobileNotif, BC000G16_A119WWPUserExtendedDesktopNotif,
               BC000G16_A122WWPUserExtendedDeleted, BC000G16_A123WWPUserExtendedDeletedIn, BC000G16_n123WWPUserExtendedDeletedIn, BC000G16_A115WWPUserExtendedPhoto
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound26 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z112WWPUserExtendedId ;
      private string A112WWPUserExtendedId ;
      private string Z120WWPUserExtendedPhone ;
      private string A120WWPUserExtendedPhone ;
      private string sMode26 ;
      private DateTime Z123WWPUserExtendedDeletedIn ;
      private DateTime A123WWPUserExtendedDeletedIn ;
      private bool Z116WWPUserExtendedEmaiNotif ;
      private bool A116WWPUserExtendedEmaiNotif ;
      private bool Z117WWPUserExtendedSMSNotif ;
      private bool A117WWPUserExtendedSMSNotif ;
      private bool Z118WWPUserExtendedMobileNotif ;
      private bool A118WWPUserExtendedMobileNotif ;
      private bool Z119WWPUserExtendedDesktopNotif ;
      private bool A119WWPUserExtendedDesktopNotif ;
      private bool Z122WWPUserExtendedDeleted ;
      private bool A122WWPUserExtendedDeleted ;
      private bool n112WWPUserExtendedId ;
      private bool n123WWPUserExtendedDeletedIn ;
      private bool Gx_longc ;
      private string Z121WWPUserExtendedName ;
      private string A121WWPUserExtendedName ;
      private string Z113WWPUserExtendedFullName ;
      private string A113WWPUserExtendedFullName ;
      private string Z114WWPUserExtendedEmail ;
      private string A114WWPUserExtendedEmail ;
      private string Z40000WWPUserExtendedPhoto_GXI ;
      private string A40000WWPUserExtendedPhoto_GXI ;
      private string Z115WWPUserExtendedPhoto ;
      private string A115WWPUserExtendedPhoto ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000G4_A112WWPUserExtendedId ;
      private bool[] BC000G4_n112WWPUserExtendedId ;
      private string[] BC000G4_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC000G4_A121WWPUserExtendedName ;
      private string[] BC000G4_A113WWPUserExtendedFullName ;
      private string[] BC000G4_A120WWPUserExtendedPhone ;
      private string[] BC000G4_A114WWPUserExtendedEmail ;
      private bool[] BC000G4_A116WWPUserExtendedEmaiNotif ;
      private bool[] BC000G4_A117WWPUserExtendedSMSNotif ;
      private bool[] BC000G4_A118WWPUserExtendedMobileNotif ;
      private bool[] BC000G4_A119WWPUserExtendedDesktopNotif ;
      private bool[] BC000G4_A122WWPUserExtendedDeleted ;
      private DateTime[] BC000G4_A123WWPUserExtendedDeletedIn ;
      private bool[] BC000G4_n123WWPUserExtendedDeletedIn ;
      private string[] BC000G4_A115WWPUserExtendedPhoto ;
      private string[] BC000G5_A112WWPUserExtendedId ;
      private bool[] BC000G5_n112WWPUserExtendedId ;
      private string[] BC000G3_A112WWPUserExtendedId ;
      private bool[] BC000G3_n112WWPUserExtendedId ;
      private string[] BC000G3_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC000G3_A121WWPUserExtendedName ;
      private string[] BC000G3_A113WWPUserExtendedFullName ;
      private string[] BC000G3_A120WWPUserExtendedPhone ;
      private string[] BC000G3_A114WWPUserExtendedEmail ;
      private bool[] BC000G3_A116WWPUserExtendedEmaiNotif ;
      private bool[] BC000G3_A117WWPUserExtendedSMSNotif ;
      private bool[] BC000G3_A118WWPUserExtendedMobileNotif ;
      private bool[] BC000G3_A119WWPUserExtendedDesktopNotif ;
      private bool[] BC000G3_A122WWPUserExtendedDeleted ;
      private DateTime[] BC000G3_A123WWPUserExtendedDeletedIn ;
      private bool[] BC000G3_n123WWPUserExtendedDeletedIn ;
      private string[] BC000G3_A115WWPUserExtendedPhoto ;
      private string[] BC000G2_A112WWPUserExtendedId ;
      private bool[] BC000G2_n112WWPUserExtendedId ;
      private string[] BC000G2_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC000G2_A121WWPUserExtendedName ;
      private string[] BC000G2_A113WWPUserExtendedFullName ;
      private string[] BC000G2_A120WWPUserExtendedPhone ;
      private string[] BC000G2_A114WWPUserExtendedEmail ;
      private bool[] BC000G2_A116WWPUserExtendedEmaiNotif ;
      private bool[] BC000G2_A117WWPUserExtendedSMSNotif ;
      private bool[] BC000G2_A118WWPUserExtendedMobileNotif ;
      private bool[] BC000G2_A119WWPUserExtendedDesktopNotif ;
      private bool[] BC000G2_A122WWPUserExtendedDeleted ;
      private DateTime[] BC000G2_A123WWPUserExtendedDeletedIn ;
      private bool[] BC000G2_n123WWPUserExtendedDeletedIn ;
      private string[] BC000G2_A115WWPUserExtendedPhoto ;
      private long[] BC000G10_A200WWPDiscussionMessageId ;
      private string[] BC000G10_A201WWPDiscussionMentionUserId ;
      private int[] BC000G11_A214WWPFormInstanceId ;
      private long[] BC000G12_A200WWPDiscussionMessageId ;
      private long[] BC000G13_A127WWPNotificationId ;
      private string[] BC000G14_A153WWPWebClientId ;
      private long[] BC000G15_A130WWPSubscriptionId ;
      private string[] BC000G16_A112WWPUserExtendedId ;
      private bool[] BC000G16_n112WWPUserExtendedId ;
      private string[] BC000G16_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC000G16_A121WWPUserExtendedName ;
      private string[] BC000G16_A113WWPUserExtendedFullName ;
      private string[] BC000G16_A120WWPUserExtendedPhone ;
      private string[] BC000G16_A114WWPUserExtendedEmail ;
      private bool[] BC000G16_A116WWPUserExtendedEmaiNotif ;
      private bool[] BC000G16_A117WWPUserExtendedSMSNotif ;
      private bool[] BC000G16_A118WWPUserExtendedMobileNotif ;
      private bool[] BC000G16_A119WWPUserExtendedDesktopNotif ;
      private bool[] BC000G16_A122WWPUserExtendedDeleted ;
      private DateTime[] BC000G16_A123WWPUserExtendedDeletedIn ;
      private bool[] BC000G16_n123WWPUserExtendedDeletedIn ;
      private string[] BC000G16_A115WWPUserExtendedPhoto ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended bcwwpbaseobjects_WWP_UserExtended ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_userextended_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_userextended_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_userextended_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[7])
      ,new ForEachCursor(def[8])
      ,new ForEachCursor(def[9])
      ,new ForEachCursor(def[10])
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
       Object[] prmBC000G2;
       prmBC000G2 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmBC000G3;
       prmBC000G3 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmBC000G4;
       prmBC000G4 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmBC000G5;
       prmBC000G5 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmBC000G6;
       prmBC000G6 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
       new ParDef("WWPUserExtendedPhoto",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("WWPUserExtendedPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="WWP_UserExtended", Fld="WWPUserExtendedPhoto"} ,
       new ParDef("WWPUserExtendedName",GXType.VarChar,100,0) ,
       new ParDef("WWPUserExtendedFullName",GXType.VarChar,100,0) ,
       new ParDef("WWPUserExtendedPhone",GXType.Char,20,0) ,
       new ParDef("WWPUserExtendedEmail",GXType.VarChar,100,0) ,
       new ParDef("WWPUserExtendedEmaiNotif",GXType.Boolean,100,0) ,
       new ParDef("WWPUserExtendedSMSNotif",GXType.Boolean,4,0) ,
       new ParDef("WWPUserExtendedMobileNotif",GXType.Boolean,4,0) ,
       new ParDef("WWPUserExtendedDesktopNotif",GXType.Boolean,4,0) ,
       new ParDef("WWPUserExtendedDeleted",GXType.Boolean,4,0) ,
       new ParDef("WWPUserExtendedDeletedIn",GXType.DateTime,8,5){Nullable=true}
       };
       Object[] prmBC000G7;
       prmBC000G7 = new Object[] {
       new ParDef("WWPUserExtendedName",GXType.VarChar,100,0) ,
       new ParDef("WWPUserExtendedFullName",GXType.VarChar,100,0) ,
       new ParDef("WWPUserExtendedPhone",GXType.Char,20,0) ,
       new ParDef("WWPUserExtendedEmail",GXType.VarChar,100,0) ,
       new ParDef("WWPUserExtendedEmaiNotif",GXType.Boolean,100,0) ,
       new ParDef("WWPUserExtendedSMSNotif",GXType.Boolean,4,0) ,
       new ParDef("WWPUserExtendedMobileNotif",GXType.Boolean,4,0) ,
       new ParDef("WWPUserExtendedDesktopNotif",GXType.Boolean,4,0) ,
       new ParDef("WWPUserExtendedDeleted",GXType.Boolean,4,0) ,
       new ParDef("WWPUserExtendedDeletedIn",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmBC000G8;
       prmBC000G8 = new Object[] {
       new ParDef("WWPUserExtendedPhoto",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("WWPUserExtendedPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="WWP_UserExtended", Fld="WWPUserExtendedPhoto"} ,
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmBC000G9;
       prmBC000G9 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmBC000G10;
       prmBC000G10 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmBC000G11;
       prmBC000G11 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmBC000G12;
       prmBC000G12 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmBC000G13;
       prmBC000G13 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmBC000G14;
       prmBC000G14 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmBC000G15;
       prmBC000G15 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       Object[] prmBC000G16;
       prmBC000G16 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
       };
       def= new CursorDef[] {
           new CursorDef("BC000G2", "SELECT WWPUserExtendedId, WWPUserExtendedPhoto_GXI, WWPUserExtendedName, WWPUserExtendedFullName, WWPUserExtendedPhone, WWPUserExtendedEmail, WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted, WWPUserExtendedDeletedIn, WWPUserExtendedPhoto FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId  FOR UPDATE OF WWP_UserExtended",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000G3", "SELECT WWPUserExtendedId, WWPUserExtendedPhoto_GXI, WWPUserExtendedName, WWPUserExtendedFullName, WWPUserExtendedPhone, WWPUserExtendedEmail, WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted, WWPUserExtendedDeletedIn, WWPUserExtendedPhoto FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000G4", "SELECT TM1.WWPUserExtendedId, TM1.WWPUserExtendedPhoto_GXI, TM1.WWPUserExtendedName, TM1.WWPUserExtendedFullName, TM1.WWPUserExtendedPhone, TM1.WWPUserExtendedEmail, TM1.WWPUserExtendedEmaiNotif, TM1.WWPUserExtendedSMSNotif, TM1.WWPUserExtendedMobileNotif, TM1.WWPUserExtendedDesktopNotif, TM1.WWPUserExtendedDeleted, TM1.WWPUserExtendedDeletedIn, TM1.WWPUserExtendedPhoto FROM WWP_UserExtended TM1 WHERE TM1.WWPUserExtendedId = ( :WWPUserExtendedId) ORDER BY TM1.WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000G5", "SELECT WWPUserExtendedId FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000G6", "SAVEPOINT gxupdate;INSERT INTO WWP_UserExtended(WWPUserExtendedId, WWPUserExtendedPhoto, WWPUserExtendedPhoto_GXI, WWPUserExtendedName, WWPUserExtendedFullName, WWPUserExtendedPhone, WWPUserExtendedEmail, WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted, WWPUserExtendedDeletedIn) VALUES(:WWPUserExtendedId, :WWPUserExtendedPhoto, :WWPUserExtendedPhoto_GXI, :WWPUserExtendedName, :WWPUserExtendedFullName, :WWPUserExtendedPhone, :WWPUserExtendedEmail, :WWPUserExtendedEmaiNotif, :WWPUserExtendedSMSNotif, :WWPUserExtendedMobileNotif, :WWPUserExtendedDesktopNotif, :WWPUserExtendedDeleted, :WWPUserExtendedDeletedIn);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000G6)
          ,new CursorDef("BC000G7", "SAVEPOINT gxupdate;UPDATE WWP_UserExtended SET WWPUserExtendedName=:WWPUserExtendedName, WWPUserExtendedFullName=:WWPUserExtendedFullName, WWPUserExtendedPhone=:WWPUserExtendedPhone, WWPUserExtendedEmail=:WWPUserExtendedEmail, WWPUserExtendedEmaiNotif=:WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif=:WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif=:WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif=:WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted=:WWPUserExtendedDeleted, WWPUserExtendedDeletedIn=:WWPUserExtendedDeletedIn  WHERE WWPUserExtendedId = :WWPUserExtendedId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000G7)
          ,new CursorDef("BC000G8", "SAVEPOINT gxupdate;UPDATE WWP_UserExtended SET WWPUserExtendedPhoto=:WWPUserExtendedPhoto, WWPUserExtendedPhoto_GXI=:WWPUserExtendedPhoto_GXI  WHERE WWPUserExtendedId = :WWPUserExtendedId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000G8)
          ,new CursorDef("BC000G9", "SAVEPOINT gxupdate;DELETE FROM WWP_UserExtended  WHERE WWPUserExtendedId = :WWPUserExtendedId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000G9)
          ,new CursorDef("BC000G10", "SELECT WWPDiscussionMessageId, WWPDiscussionMentionUserId FROM WWP_DiscussionMessageMention WHERE WWPDiscussionMentionUserId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G10,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000G11", "SELECT WWPFormInstanceId FROM WWP_FormInstance WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G11,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000G12", "SELECT WWPDiscussionMessageId FROM WWP_DiscussionMessage WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G12,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000G13", "SELECT WWPNotificationId FROM WWP_Notification WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G13,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000G14", "SELECT WWPWebClientId FROM WWP_WebClient WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G14,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000G15", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G15,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000G16", "SELECT TM1.WWPUserExtendedId, TM1.WWPUserExtendedPhoto_GXI, TM1.WWPUserExtendedName, TM1.WWPUserExtendedFullName, TM1.WWPUserExtendedPhone, TM1.WWPUserExtendedEmail, TM1.WWPUserExtendedEmaiNotif, TM1.WWPUserExtendedSMSNotif, TM1.WWPUserExtendedMobileNotif, TM1.WWPUserExtendedDesktopNotif, TM1.WWPUserExtendedDeleted, TM1.WWPUserExtendedDeletedIn, TM1.WWPUserExtendedPhoto FROM WWP_UserExtended TM1 WHERE TM1.WWPUserExtendedId = ( :WWPUserExtendedId) ORDER BY TM1.WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G16,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[0])[0] = rslt.getString(1, 40);
             ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
             return;
          case 1 :
             ((string[]) buf[0])[0] = rslt.getString(1, 40);
             ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getString(1, 40);
             ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getString(1, 40);
             return;
          case 8 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 40);
             return;
          case 9 :
             ((int[]) buf[0])[0] = rslt.getInt(1);
             return;
          case 10 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 11 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 12 :
             ((string[]) buf[0])[0] = rslt.getString(1, 100);
             return;
          case 13 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 14 :
             ((string[]) buf[0])[0] = rslt.getString(1, 40);
             ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 20);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
             return;
    }
 }

}

}
