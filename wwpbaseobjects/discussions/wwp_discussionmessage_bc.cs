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
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   public class wwp_discussionmessage_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_discussionmessage_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_discussionmessage_bc( IGxContext context )
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
         ReadRow0R38( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0R38( ) ;
         standaloneModal( ) ;
         AddRow0R38( ) ;
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
               Z200WWPDiscussionMessageId = A200WWPDiscussionMessageId;
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

      protected void CONFIRM_0R0( )
      {
         BeforeValidate0R38( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0R38( ) ;
            }
            else
            {
               CheckExtendedTable0R38( ) ;
               if ( AnyError == 0 )
               {
                  ZM0R38( 7) ;
                  ZM0R38( 8) ;
                  ZM0R38( 9) ;
               }
               CloseExtendedTableCursors0R38( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0R38( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z203WWPDiscussionMessageDate = A203WWPDiscussionMessageDate;
            Z204WWPDiscussionMessageMessage = A204WWPDiscussionMessageMessage;
            Z205WWPDiscussionMessageEntityReco = A205WWPDiscussionMessageEntityReco;
            Z112WWPUserExtendedId = A112WWPUserExtendedId;
            Z125WWPEntityId = A125WWPEntityId;
            Z199WWPDiscussionMessageThreadId = A199WWPDiscussionMessageThreadId;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z113WWPUserExtendedFullName = A113WWPUserExtendedFullName;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z126WWPEntityName = A126WWPEntityName;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -6 )
         {
            Z200WWPDiscussionMessageId = A200WWPDiscussionMessageId;
            Z203WWPDiscussionMessageDate = A203WWPDiscussionMessageDate;
            Z204WWPDiscussionMessageMessage = A204WWPDiscussionMessageMessage;
            Z205WWPDiscussionMessageEntityReco = A205WWPDiscussionMessageEntityReco;
            Z112WWPUserExtendedId = A112WWPUserExtendedId;
            Z125WWPEntityId = A125WWPEntityId;
            Z199WWPDiscussionMessageThreadId = A199WWPDiscussionMessageThreadId;
            Z115WWPUserExtendedPhoto = A115WWPUserExtendedPhoto;
            Z40000WWPUserExtendedPhoto_GXI = A40000WWPUserExtendedPhoto_GXI;
            Z113WWPUserExtendedFullName = A113WWPUserExtendedFullName;
            Z126WWPEntityName = A126WWPEntityName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         A203WWPDiscussionMessageDate = DateTimeUtil.Now( context);
         GXt_char1 = A112WWPUserExtendedId;
         new uwwp_getloggeduserid(context ).execute( out  GXt_char1) ;
         A112WWPUserExtendedId = GXt_char1;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor BC000R4 */
            pr_default.execute(2, new Object[] {A112WWPUserExtendedId});
            A40000WWPUserExtendedPhoto_GXI = BC000R4_A40000WWPUserExtendedPhoto_GXI[0];
            A113WWPUserExtendedFullName = BC000R4_A113WWPUserExtendedFullName[0];
            A115WWPUserExtendedPhoto = BC000R4_A115WWPUserExtendedPhoto[0];
            pr_default.close(2);
         }
      }

      protected void Load0R38( )
      {
         /* Using cursor BC000R7 */
         pr_default.execute(5, new Object[] {A200WWPDiscussionMessageId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound38 = 1;
            A203WWPDiscussionMessageDate = BC000R7_A203WWPDiscussionMessageDate[0];
            A204WWPDiscussionMessageMessage = BC000R7_A204WWPDiscussionMessageMessage[0];
            A40000WWPUserExtendedPhoto_GXI = BC000R7_A40000WWPUserExtendedPhoto_GXI[0];
            A113WWPUserExtendedFullName = BC000R7_A113WWPUserExtendedFullName[0];
            A126WWPEntityName = BC000R7_A126WWPEntityName[0];
            A205WWPDiscussionMessageEntityReco = BC000R7_A205WWPDiscussionMessageEntityReco[0];
            A112WWPUserExtendedId = BC000R7_A112WWPUserExtendedId[0];
            A125WWPEntityId = BC000R7_A125WWPEntityId[0];
            A199WWPDiscussionMessageThreadId = BC000R7_A199WWPDiscussionMessageThreadId[0];
            n199WWPDiscussionMessageThreadId = BC000R7_n199WWPDiscussionMessageThreadId[0];
            A115WWPUserExtendedPhoto = BC000R7_A115WWPUserExtendedPhoto[0];
            ZM0R38( -6) ;
         }
         pr_default.close(5);
         OnLoadActions0R38( ) ;
      }

      protected void OnLoadActions0R38( )
      {
      }

      protected void CheckExtendedTable0R38( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000R6 */
         pr_default.execute(4, new Object[] {n199WWPDiscussionMessageThreadId, A199WWPDiscussionMessageThreadId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A199WWPDiscussionMessageThreadId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Discussion Message Thread", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGETHREADID");
               AnyError = 1;
            }
         }
         pr_default.close(4);
         /* Using cursor BC000R4 */
         pr_default.execute(2, new Object[] {A112WWPUserExtendedId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_UserExtended", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
         }
         A40000WWPUserExtendedPhoto_GXI = BC000R4_A40000WWPUserExtendedPhoto_GXI[0];
         A113WWPUserExtendedFullName = BC000R4_A113WWPUserExtendedFullName[0];
         A115WWPUserExtendedPhoto = BC000R4_A115WWPUserExtendedPhoto[0];
         pr_default.close(2);
         /* Using cursor BC000R5 */
         pr_default.execute(3, new Object[] {A125WWPEntityId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_Entity", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A126WWPEntityName = BC000R5_A126WWPEntityName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0R38( )
      {
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0R38( )
      {
         /* Using cursor BC000R8 */
         pr_default.execute(6, new Object[] {A200WWPDiscussionMessageId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound38 = 1;
         }
         else
         {
            RcdFound38 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000R3 */
         pr_default.execute(1, new Object[] {A200WWPDiscussionMessageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0R38( 6) ;
            RcdFound38 = 1;
            A200WWPDiscussionMessageId = BC000R3_A200WWPDiscussionMessageId[0];
            A203WWPDiscussionMessageDate = BC000R3_A203WWPDiscussionMessageDate[0];
            A204WWPDiscussionMessageMessage = BC000R3_A204WWPDiscussionMessageMessage[0];
            A205WWPDiscussionMessageEntityReco = BC000R3_A205WWPDiscussionMessageEntityReco[0];
            A112WWPUserExtendedId = BC000R3_A112WWPUserExtendedId[0];
            A125WWPEntityId = BC000R3_A125WWPEntityId[0];
            A199WWPDiscussionMessageThreadId = BC000R3_A199WWPDiscussionMessageThreadId[0];
            n199WWPDiscussionMessageThreadId = BC000R3_n199WWPDiscussionMessageThreadId[0];
            Z200WWPDiscussionMessageId = A200WWPDiscussionMessageId;
            sMode38 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0R38( ) ;
            if ( AnyError == 1 )
            {
               RcdFound38 = 0;
               InitializeNonKey0R38( ) ;
            }
            Gx_mode = sMode38;
         }
         else
         {
            RcdFound38 = 0;
            InitializeNonKey0R38( ) ;
            sMode38 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode38;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0R38( ) ;
         if ( RcdFound38 == 0 )
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
         CONFIRM_0R0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0R38( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000R2 */
            pr_default.execute(0, new Object[] {A200WWPDiscussionMessageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_DiscussionMessage"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z203WWPDiscussionMessageDate != BC000R2_A203WWPDiscussionMessageDate[0] ) || ( StringUtil.StrCmp(Z204WWPDiscussionMessageMessage, BC000R2_A204WWPDiscussionMessageMessage[0]) != 0 ) || ( StringUtil.StrCmp(Z205WWPDiscussionMessageEntityReco, BC000R2_A205WWPDiscussionMessageEntityReco[0]) != 0 ) || ( StringUtil.StrCmp(Z112WWPUserExtendedId, BC000R2_A112WWPUserExtendedId[0]) != 0 ) || ( Z125WWPEntityId != BC000R2_A125WWPEntityId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z199WWPDiscussionMessageThreadId != BC000R2_A199WWPDiscussionMessageThreadId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_DiscussionMessage"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0R38( )
      {
         BeforeValidate0R38( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0R38( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0R38( 0) ;
            CheckOptimisticConcurrency0R38( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0R38( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0R38( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000R9 */
                     pr_default.execute(7, new Object[] {A203WWPDiscussionMessageDate, A204WWPDiscussionMessageMessage, A205WWPDiscussionMessageEntityReco, A112WWPUserExtendedId, A125WWPEntityId, n199WWPDiscussionMessageThreadId, A199WWPDiscussionMessageThreadId});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000R10 */
                     pr_default.execute(8);
                     A200WWPDiscussionMessageId = BC000R10_A200WWPDiscussionMessageId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
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
               Load0R38( ) ;
            }
            EndLevel0R38( ) ;
         }
         CloseExtendedTableCursors0R38( ) ;
      }

      protected void Update0R38( )
      {
         BeforeValidate0R38( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0R38( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0R38( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0R38( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0R38( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000R11 */
                     pr_default.execute(9, new Object[] {A203WWPDiscussionMessageDate, A204WWPDiscussionMessageMessage, A205WWPDiscussionMessageEntityReco, A112WWPUserExtendedId, A125WWPEntityId, n199WWPDiscussionMessageThreadId, A199WWPDiscussionMessageThreadId, A200WWPDiscussionMessageId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_DiscussionMessage"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0R38( ) ;
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
            EndLevel0R38( ) ;
         }
         CloseExtendedTableCursors0R38( ) ;
      }

      protected void DeferredUpdate0R38( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0R38( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0R38( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0R38( ) ;
            AfterConfirm0R38( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0R38( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000R12 */
                  pr_default.execute(10, new Object[] {A200WWPDiscussionMessageId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
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
         sMode38 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0R38( ) ;
         Gx_mode = sMode38;
      }

      protected void OnDeleteControls0R38( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000R13 */
            pr_default.execute(11, new Object[] {A112WWPUserExtendedId});
            A40000WWPUserExtendedPhoto_GXI = BC000R13_A40000WWPUserExtendedPhoto_GXI[0];
            A113WWPUserExtendedFullName = BC000R13_A113WWPUserExtendedFullName[0];
            A115WWPUserExtendedPhoto = BC000R13_A115WWPUserExtendedPhoto[0];
            pr_default.close(11);
            /* Using cursor BC000R14 */
            pr_default.execute(12, new Object[] {A125WWPEntityId});
            A126WWPEntityName = BC000R14_A126WWPEntityName[0];
            pr_default.close(12);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000R15 */
            pr_default.execute(13, new Object[] {A200WWPDiscussionMessageId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_DiscussionMessage", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor BC000R16 */
            pr_default.execute(14, new Object[] {A200WWPDiscussionMessageId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_DiscussionMessageMention", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel0R38( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0R38( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            new prc_addtodiscussiontransalation(context ).execute(  AV8SDT_DiscussionTranslationVar) ;
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

      public void ScanKeyStart0R38( )
      {
         /* Using cursor BC000R17 */
         pr_default.execute(15, new Object[] {A200WWPDiscussionMessageId});
         RcdFound38 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound38 = 1;
            A200WWPDiscussionMessageId = BC000R17_A200WWPDiscussionMessageId[0];
            A203WWPDiscussionMessageDate = BC000R17_A203WWPDiscussionMessageDate[0];
            A204WWPDiscussionMessageMessage = BC000R17_A204WWPDiscussionMessageMessage[0];
            A40000WWPUserExtendedPhoto_GXI = BC000R17_A40000WWPUserExtendedPhoto_GXI[0];
            A113WWPUserExtendedFullName = BC000R17_A113WWPUserExtendedFullName[0];
            A126WWPEntityName = BC000R17_A126WWPEntityName[0];
            A205WWPDiscussionMessageEntityReco = BC000R17_A205WWPDiscussionMessageEntityReco[0];
            A112WWPUserExtendedId = BC000R17_A112WWPUserExtendedId[0];
            A125WWPEntityId = BC000R17_A125WWPEntityId[0];
            A199WWPDiscussionMessageThreadId = BC000R17_A199WWPDiscussionMessageThreadId[0];
            n199WWPDiscussionMessageThreadId = BC000R17_n199WWPDiscussionMessageThreadId[0];
            A115WWPUserExtendedPhoto = BC000R17_A115WWPUserExtendedPhoto[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0R38( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound38 = 0;
         ScanKeyLoad0R38( ) ;
      }

      protected void ScanKeyLoad0R38( )
      {
         sMode38 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound38 = 1;
            A200WWPDiscussionMessageId = BC000R17_A200WWPDiscussionMessageId[0];
            A203WWPDiscussionMessageDate = BC000R17_A203WWPDiscussionMessageDate[0];
            A204WWPDiscussionMessageMessage = BC000R17_A204WWPDiscussionMessageMessage[0];
            A40000WWPUserExtendedPhoto_GXI = BC000R17_A40000WWPUserExtendedPhoto_GXI[0];
            A113WWPUserExtendedFullName = BC000R17_A113WWPUserExtendedFullName[0];
            A126WWPEntityName = BC000R17_A126WWPEntityName[0];
            A205WWPDiscussionMessageEntityReco = BC000R17_A205WWPDiscussionMessageEntityReco[0];
            A112WWPUserExtendedId = BC000R17_A112WWPUserExtendedId[0];
            A125WWPEntityId = BC000R17_A125WWPEntityId[0];
            A199WWPDiscussionMessageThreadId = BC000R17_A199WWPDiscussionMessageThreadId[0];
            n199WWPDiscussionMessageThreadId = BC000R17_n199WWPDiscussionMessageThreadId[0];
            A115WWPUserExtendedPhoto = BC000R17_A115WWPUserExtendedPhoto[0];
         }
         Gx_mode = sMode38;
      }

      protected void ScanKeyEnd0R38( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0R38( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0R38( )
      {
         /* Before Insert Rules */
         if ( (0==A199WWPDiscussionMessageThreadId) )
         {
            A199WWPDiscussionMessageThreadId = 0;
            n199WWPDiscussionMessageThreadId = false;
            n199WWPDiscussionMessageThreadId = true;
         }
      }

      protected void BeforeUpdate0R38( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0R38( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0R38( )
      {
         /* Before Complete Rules */
         GXt_SdtSDT_DiscussionTranslation2 = AV8SDT_DiscussionTranslationVar;
         new prc_adddiscussiontranslationtosdt(context ).execute(  A200WWPDiscussionMessageId, out  GXt_SdtSDT_DiscussionTranslation2) ;
         AV8SDT_DiscussionTranslationVar = GXt_SdtSDT_DiscussionTranslation2;
      }

      protected void BeforeValidate0R38( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0R38( )
      {
      }

      protected void send_integrity_lvl_hashes0R38( )
      {
      }

      protected void AddRow0R38( )
      {
         VarsToRow38( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
      }

      protected void ReadRow0R38( )
      {
         RowToVars38( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
      }

      protected void InitializeNonKey0R38( )
      {
         A203WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         A112WWPUserExtendedId = "";
         AV8SDT_DiscussionTranslationVar = new SdtSDT_DiscussionTranslation(context);
         A199WWPDiscussionMessageThreadId = 0;
         n199WWPDiscussionMessageThreadId = false;
         A204WWPDiscussionMessageMessage = "";
         A115WWPUserExtendedPhoto = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         A113WWPUserExtendedFullName = "";
         A125WWPEntityId = 0;
         A126WWPEntityName = "";
         A205WWPDiscussionMessageEntityReco = "";
         Z203WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         Z204WWPDiscussionMessageMessage = "";
         Z205WWPDiscussionMessageEntityReco = "";
         Z112WWPUserExtendedId = "";
         Z125WWPEntityId = 0;
         Z199WWPDiscussionMessageThreadId = 0;
      }

      protected void InitAll0R38( )
      {
         A200WWPDiscussionMessageId = 0;
         InitializeNonKey0R38( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A203WWPDiscussionMessageDate = i203WWPDiscussionMessageDate;
         A112WWPUserExtendedId = i112WWPUserExtendedId;
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

      public void VarsToRow38( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage obj38 )
      {
         obj38.gxTpr_Mode = Gx_mode;
         obj38.gxTpr_Wwpdiscussionmessagedate = A203WWPDiscussionMessageDate;
         obj38.gxTpr_Wwpuserextendedid = A112WWPUserExtendedId;
         obj38.gxTpr_Wwpdiscussionmessagethreadid = A199WWPDiscussionMessageThreadId;
         obj38.gxTpr_Wwpdiscussionmessagemessage = A204WWPDiscussionMessageMessage;
         obj38.gxTpr_Wwpuserextendedphoto = A115WWPUserExtendedPhoto;
         obj38.gxTpr_Wwpuserextendedphoto_gxi = A40000WWPUserExtendedPhoto_GXI;
         obj38.gxTpr_Wwpuserextendedfullname = A113WWPUserExtendedFullName;
         obj38.gxTpr_Wwpentityid = A125WWPEntityId;
         obj38.gxTpr_Wwpentityname = A126WWPEntityName;
         obj38.gxTpr_Wwpdiscussionmessageentityrecordid = A205WWPDiscussionMessageEntityReco;
         obj38.gxTpr_Wwpdiscussionmessageid = A200WWPDiscussionMessageId;
         obj38.gxTpr_Wwpdiscussionmessageid_Z = Z200WWPDiscussionMessageId;
         obj38.gxTpr_Wwpdiscussionmessagedate_Z = Z203WWPDiscussionMessageDate;
         obj38.gxTpr_Wwpdiscussionmessagethreadid_Z = Z199WWPDiscussionMessageThreadId;
         obj38.gxTpr_Wwpdiscussionmessagemessage_Z = Z204WWPDiscussionMessageMessage;
         obj38.gxTpr_Wwpuserextendedid_Z = Z112WWPUserExtendedId;
         obj38.gxTpr_Wwpuserextendedfullname_Z = Z113WWPUserExtendedFullName;
         obj38.gxTpr_Wwpentityid_Z = Z125WWPEntityId;
         obj38.gxTpr_Wwpentityname_Z = Z126WWPEntityName;
         obj38.gxTpr_Wwpdiscussionmessageentityrecordid_Z = Z205WWPDiscussionMessageEntityReco;
         obj38.gxTpr_Wwpuserextendedphoto_gxi_Z = Z40000WWPUserExtendedPhoto_GXI;
         obj38.gxTpr_Wwpdiscussionmessagethreadid_N = (short)(Convert.ToInt16(n199WWPDiscussionMessageThreadId));
         obj38.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow38( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage obj38 )
      {
         obj38.gxTpr_Wwpdiscussionmessageid = A200WWPDiscussionMessageId;
         return  ;
      }

      public void RowToVars38( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage obj38 ,
                               int forceLoad )
      {
         Gx_mode = obj38.gxTpr_Mode;
         A203WWPDiscussionMessageDate = obj38.gxTpr_Wwpdiscussionmessagedate;
         A112WWPUserExtendedId = obj38.gxTpr_Wwpuserextendedid;
         A199WWPDiscussionMessageThreadId = obj38.gxTpr_Wwpdiscussionmessagethreadid;
         n199WWPDiscussionMessageThreadId = false;
         A204WWPDiscussionMessageMessage = obj38.gxTpr_Wwpdiscussionmessagemessage;
         A115WWPUserExtendedPhoto = obj38.gxTpr_Wwpuserextendedphoto;
         A40000WWPUserExtendedPhoto_GXI = obj38.gxTpr_Wwpuserextendedphoto_gxi;
         A113WWPUserExtendedFullName = obj38.gxTpr_Wwpuserextendedfullname;
         A125WWPEntityId = obj38.gxTpr_Wwpentityid;
         A126WWPEntityName = obj38.gxTpr_Wwpentityname;
         A205WWPDiscussionMessageEntityReco = obj38.gxTpr_Wwpdiscussionmessageentityrecordid;
         A200WWPDiscussionMessageId = obj38.gxTpr_Wwpdiscussionmessageid;
         Z200WWPDiscussionMessageId = obj38.gxTpr_Wwpdiscussionmessageid_Z;
         Z203WWPDiscussionMessageDate = obj38.gxTpr_Wwpdiscussionmessagedate_Z;
         Z199WWPDiscussionMessageThreadId = obj38.gxTpr_Wwpdiscussionmessagethreadid_Z;
         Z204WWPDiscussionMessageMessage = obj38.gxTpr_Wwpdiscussionmessagemessage_Z;
         Z112WWPUserExtendedId = obj38.gxTpr_Wwpuserextendedid_Z;
         Z113WWPUserExtendedFullName = obj38.gxTpr_Wwpuserextendedfullname_Z;
         Z125WWPEntityId = obj38.gxTpr_Wwpentityid_Z;
         Z126WWPEntityName = obj38.gxTpr_Wwpentityname_Z;
         Z205WWPDiscussionMessageEntityReco = obj38.gxTpr_Wwpdiscussionmessageentityrecordid_Z;
         Z40000WWPUserExtendedPhoto_GXI = obj38.gxTpr_Wwpuserextendedphoto_gxi_Z;
         n199WWPDiscussionMessageThreadId = (bool)(Convert.ToBoolean(obj38.gxTpr_Wwpdiscussionmessagethreadid_N));
         Gx_mode = obj38.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A200WWPDiscussionMessageId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0R38( ) ;
         ScanKeyStart0R38( ) ;
         if ( RcdFound38 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z200WWPDiscussionMessageId = A200WWPDiscussionMessageId;
         }
         ZM0R38( -6) ;
         OnLoadActions0R38( ) ;
         AddRow0R38( ) ;
         ScanKeyEnd0R38( ) ;
         if ( RcdFound38 == 0 )
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
         RowToVars38( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 0) ;
         ScanKeyStart0R38( ) ;
         if ( RcdFound38 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z200WWPDiscussionMessageId = A200WWPDiscussionMessageId;
         }
         ZM0R38( -6) ;
         OnLoadActions0R38( ) ;
         AddRow0R38( ) ;
         ScanKeyEnd0R38( ) ;
         if ( RcdFound38 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0R38( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0R38( ) ;
         }
         else
         {
            if ( RcdFound38 == 1 )
            {
               if ( A200WWPDiscussionMessageId != Z200WWPDiscussionMessageId )
               {
                  A200WWPDiscussionMessageId = Z200WWPDiscussionMessageId;
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
                  Update0R38( ) ;
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
                  if ( A200WWPDiscussionMessageId != Z200WWPDiscussionMessageId )
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
                        Insert0R38( ) ;
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
                        Insert0R38( ) ;
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
         RowToVars38( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
         SaveImpl( ) ;
         VarsToRow38( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars38( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0R38( ) ;
         AfterTrn( ) ;
         VarsToRow38( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow38( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage auxBC = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A200WWPDiscussionMessageId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_discussions_WWP_DiscussionMessage);
               auxBC.Save();
               bcwwpbaseobjects_discussions_WWP_DiscussionMessage.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars38( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
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
         RowToVars38( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0R38( ) ;
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
               VarsToRow38( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow38( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
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
         RowToVars38( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 0) ;
         GetKey0R38( ) ;
         if ( RcdFound38 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A200WWPDiscussionMessageId != Z200WWPDiscussionMessageId )
            {
               A200WWPDiscussionMessageId = Z200WWPDiscussionMessageId;
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
            if ( A200WWPDiscussionMessageId != Z200WWPDiscussionMessageId )
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
         context.RollbackDataStores("wwpbaseobjects.discussions.wwp_discussionmessage_bc",pr_default);
         VarsToRow38( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
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
         Gx_mode = bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_discussions_WWP_DiscussionMessage )
         {
            bcwwpbaseobjects_discussions_WWP_DiscussionMessage = (GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow38( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
            }
            else
            {
               RowToVars38( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars38( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_DiscussionMessage WWP_DiscussionMessage_BC
      {
         get {
            return bcwwpbaseobjects_discussions_WWP_DiscussionMessage ;
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
            return "wwpdiscussionmessage_Execute" ;
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z203WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         A203WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         Z204WWPDiscussionMessageMessage = "";
         A204WWPDiscussionMessageMessage = "";
         Z205WWPDiscussionMessageEntityReco = "";
         A205WWPDiscussionMessageEntityReco = "";
         Z112WWPUserExtendedId = "";
         A112WWPUserExtendedId = "";
         Z113WWPUserExtendedFullName = "";
         A113WWPUserExtendedFullName = "";
         Z126WWPEntityName = "";
         A126WWPEntityName = "";
         Z115WWPUserExtendedPhoto = "";
         A115WWPUserExtendedPhoto = "";
         Z40000WWPUserExtendedPhoto_GXI = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         GXt_char1 = "";
         BC000R4_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC000R4_A113WWPUserExtendedFullName = new string[] {""} ;
         BC000R4_A115WWPUserExtendedPhoto = new string[] {""} ;
         BC000R7_A200WWPDiscussionMessageId = new long[1] ;
         BC000R7_A203WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000R7_A204WWPDiscussionMessageMessage = new string[] {""} ;
         BC000R7_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC000R7_A113WWPUserExtendedFullName = new string[] {""} ;
         BC000R7_A126WWPEntityName = new string[] {""} ;
         BC000R7_A205WWPDiscussionMessageEntityReco = new string[] {""} ;
         BC000R7_A112WWPUserExtendedId = new string[] {""} ;
         BC000R7_A125WWPEntityId = new long[1] ;
         BC000R7_A199WWPDiscussionMessageThreadId = new long[1] ;
         BC000R7_n199WWPDiscussionMessageThreadId = new bool[] {false} ;
         BC000R7_A115WWPUserExtendedPhoto = new string[] {""} ;
         BC000R6_A199WWPDiscussionMessageThreadId = new long[1] ;
         BC000R6_n199WWPDiscussionMessageThreadId = new bool[] {false} ;
         BC000R5_A126WWPEntityName = new string[] {""} ;
         BC000R8_A200WWPDiscussionMessageId = new long[1] ;
         BC000R3_A200WWPDiscussionMessageId = new long[1] ;
         BC000R3_A203WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000R3_A204WWPDiscussionMessageMessage = new string[] {""} ;
         BC000R3_A205WWPDiscussionMessageEntityReco = new string[] {""} ;
         BC000R3_A112WWPUserExtendedId = new string[] {""} ;
         BC000R3_A125WWPEntityId = new long[1] ;
         BC000R3_A199WWPDiscussionMessageThreadId = new long[1] ;
         BC000R3_n199WWPDiscussionMessageThreadId = new bool[] {false} ;
         sMode38 = "";
         BC000R2_A200WWPDiscussionMessageId = new long[1] ;
         BC000R2_A203WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000R2_A204WWPDiscussionMessageMessage = new string[] {""} ;
         BC000R2_A205WWPDiscussionMessageEntityReco = new string[] {""} ;
         BC000R2_A112WWPUserExtendedId = new string[] {""} ;
         BC000R2_A125WWPEntityId = new long[1] ;
         BC000R2_A199WWPDiscussionMessageThreadId = new long[1] ;
         BC000R2_n199WWPDiscussionMessageThreadId = new bool[] {false} ;
         BC000R10_A200WWPDiscussionMessageId = new long[1] ;
         BC000R13_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC000R13_A113WWPUserExtendedFullName = new string[] {""} ;
         BC000R13_A115WWPUserExtendedPhoto = new string[] {""} ;
         BC000R14_A126WWPEntityName = new string[] {""} ;
         BC000R15_A199WWPDiscussionMessageThreadId = new long[1] ;
         BC000R15_n199WWPDiscussionMessageThreadId = new bool[] {false} ;
         BC000R16_A200WWPDiscussionMessageId = new long[1] ;
         BC000R16_A201WWPDiscussionMentionUserId = new string[] {""} ;
         AV8SDT_DiscussionTranslationVar = new SdtSDT_DiscussionTranslation(context);
         BC000R17_A200WWPDiscussionMessageId = new long[1] ;
         BC000R17_A203WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000R17_A204WWPDiscussionMessageMessage = new string[] {""} ;
         BC000R17_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC000R17_A113WWPUserExtendedFullName = new string[] {""} ;
         BC000R17_A126WWPEntityName = new string[] {""} ;
         BC000R17_A205WWPDiscussionMessageEntityReco = new string[] {""} ;
         BC000R17_A112WWPUserExtendedId = new string[] {""} ;
         BC000R17_A125WWPEntityId = new long[1] ;
         BC000R17_A199WWPDiscussionMessageThreadId = new long[1] ;
         BC000R17_n199WWPDiscussionMessageThreadId = new bool[] {false} ;
         BC000R17_A115WWPUserExtendedPhoto = new string[] {""} ;
         GXt_SdtSDT_DiscussionTranslation2 = new SdtSDT_DiscussionTranslation(context);
         i203WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         i112WWPUserExtendedId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessage_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessage_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessage_bc__default(),
            new Object[][] {
                new Object[] {
               BC000R2_A200WWPDiscussionMessageId, BC000R2_A203WWPDiscussionMessageDate, BC000R2_A204WWPDiscussionMessageMessage, BC000R2_A205WWPDiscussionMessageEntityReco, BC000R2_A112WWPUserExtendedId, BC000R2_A125WWPEntityId, BC000R2_A199WWPDiscussionMessageThreadId, BC000R2_n199WWPDiscussionMessageThreadId
               }
               , new Object[] {
               BC000R3_A200WWPDiscussionMessageId, BC000R3_A203WWPDiscussionMessageDate, BC000R3_A204WWPDiscussionMessageMessage, BC000R3_A205WWPDiscussionMessageEntityReco, BC000R3_A112WWPUserExtendedId, BC000R3_A125WWPEntityId, BC000R3_A199WWPDiscussionMessageThreadId, BC000R3_n199WWPDiscussionMessageThreadId
               }
               , new Object[] {
               BC000R4_A40000WWPUserExtendedPhoto_GXI, BC000R4_A113WWPUserExtendedFullName, BC000R4_A115WWPUserExtendedPhoto
               }
               , new Object[] {
               BC000R5_A126WWPEntityName
               }
               , new Object[] {
               BC000R6_A199WWPDiscussionMessageThreadId
               }
               , new Object[] {
               BC000R7_A200WWPDiscussionMessageId, BC000R7_A203WWPDiscussionMessageDate, BC000R7_A204WWPDiscussionMessageMessage, BC000R7_A40000WWPUserExtendedPhoto_GXI, BC000R7_A113WWPUserExtendedFullName, BC000R7_A126WWPEntityName, BC000R7_A205WWPDiscussionMessageEntityReco, BC000R7_A112WWPUserExtendedId, BC000R7_A125WWPEntityId, BC000R7_A199WWPDiscussionMessageThreadId,
               BC000R7_n199WWPDiscussionMessageThreadId, BC000R7_A115WWPUserExtendedPhoto
               }
               , new Object[] {
               BC000R8_A200WWPDiscussionMessageId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000R10_A200WWPDiscussionMessageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000R13_A40000WWPUserExtendedPhoto_GXI, BC000R13_A113WWPUserExtendedFullName, BC000R13_A115WWPUserExtendedPhoto
               }
               , new Object[] {
               BC000R14_A126WWPEntityName
               }
               , new Object[] {
               BC000R15_A199WWPDiscussionMessageThreadId
               }
               , new Object[] {
               BC000R16_A200WWPDiscussionMessageId, BC000R16_A201WWPDiscussionMentionUserId
               }
               , new Object[] {
               BC000R17_A200WWPDiscussionMessageId, BC000R17_A203WWPDiscussionMessageDate, BC000R17_A204WWPDiscussionMessageMessage, BC000R17_A40000WWPUserExtendedPhoto_GXI, BC000R17_A113WWPUserExtendedFullName, BC000R17_A126WWPEntityName, BC000R17_A205WWPDiscussionMessageEntityReco, BC000R17_A112WWPUserExtendedId, BC000R17_A125WWPEntityId, BC000R17_A199WWPDiscussionMessageThreadId,
               BC000R17_n199WWPDiscussionMessageThreadId, BC000R17_A115WWPUserExtendedPhoto
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound38 ;
      private int trnEnded ;
      private long Z200WWPDiscussionMessageId ;
      private long A200WWPDiscussionMessageId ;
      private long Z125WWPEntityId ;
      private long A125WWPEntityId ;
      private long Z199WWPDiscussionMessageThreadId ;
      private long A199WWPDiscussionMessageThreadId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z112WWPUserExtendedId ;
      private string A112WWPUserExtendedId ;
      private string GXt_char1 ;
      private string sMode38 ;
      private string i112WWPUserExtendedId ;
      private DateTime Z203WWPDiscussionMessageDate ;
      private DateTime A203WWPDiscussionMessageDate ;
      private DateTime i203WWPDiscussionMessageDate ;
      private bool n199WWPDiscussionMessageThreadId ;
      private bool Gx_longc ;
      private string Z204WWPDiscussionMessageMessage ;
      private string A204WWPDiscussionMessageMessage ;
      private string Z205WWPDiscussionMessageEntityReco ;
      private string A205WWPDiscussionMessageEntityReco ;
      private string Z113WWPUserExtendedFullName ;
      private string A113WWPUserExtendedFullName ;
      private string Z126WWPEntityName ;
      private string A126WWPEntityName ;
      private string Z40000WWPUserExtendedPhoto_GXI ;
      private string A40000WWPUserExtendedPhoto_GXI ;
      private string Z115WWPUserExtendedPhoto ;
      private string A115WWPUserExtendedPhoto ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000R4_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC000R4_A113WWPUserExtendedFullName ;
      private string[] BC000R4_A115WWPUserExtendedPhoto ;
      private long[] BC000R7_A200WWPDiscussionMessageId ;
      private DateTime[] BC000R7_A203WWPDiscussionMessageDate ;
      private string[] BC000R7_A204WWPDiscussionMessageMessage ;
      private string[] BC000R7_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC000R7_A113WWPUserExtendedFullName ;
      private string[] BC000R7_A126WWPEntityName ;
      private string[] BC000R7_A205WWPDiscussionMessageEntityReco ;
      private string[] BC000R7_A112WWPUserExtendedId ;
      private long[] BC000R7_A125WWPEntityId ;
      private long[] BC000R7_A199WWPDiscussionMessageThreadId ;
      private bool[] BC000R7_n199WWPDiscussionMessageThreadId ;
      private string[] BC000R7_A115WWPUserExtendedPhoto ;
      private long[] BC000R6_A199WWPDiscussionMessageThreadId ;
      private bool[] BC000R6_n199WWPDiscussionMessageThreadId ;
      private string[] BC000R5_A126WWPEntityName ;
      private long[] BC000R8_A200WWPDiscussionMessageId ;
      private long[] BC000R3_A200WWPDiscussionMessageId ;
      private DateTime[] BC000R3_A203WWPDiscussionMessageDate ;
      private string[] BC000R3_A204WWPDiscussionMessageMessage ;
      private string[] BC000R3_A205WWPDiscussionMessageEntityReco ;
      private string[] BC000R3_A112WWPUserExtendedId ;
      private long[] BC000R3_A125WWPEntityId ;
      private long[] BC000R3_A199WWPDiscussionMessageThreadId ;
      private bool[] BC000R3_n199WWPDiscussionMessageThreadId ;
      private long[] BC000R2_A200WWPDiscussionMessageId ;
      private DateTime[] BC000R2_A203WWPDiscussionMessageDate ;
      private string[] BC000R2_A204WWPDiscussionMessageMessage ;
      private string[] BC000R2_A205WWPDiscussionMessageEntityReco ;
      private string[] BC000R2_A112WWPUserExtendedId ;
      private long[] BC000R2_A125WWPEntityId ;
      private long[] BC000R2_A199WWPDiscussionMessageThreadId ;
      private bool[] BC000R2_n199WWPDiscussionMessageThreadId ;
      private long[] BC000R10_A200WWPDiscussionMessageId ;
      private string[] BC000R13_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC000R13_A113WWPUserExtendedFullName ;
      private string[] BC000R13_A115WWPUserExtendedPhoto ;
      private string[] BC000R14_A126WWPEntityName ;
      private long[] BC000R15_A199WWPDiscussionMessageThreadId ;
      private bool[] BC000R15_n199WWPDiscussionMessageThreadId ;
      private long[] BC000R16_A200WWPDiscussionMessageId ;
      private string[] BC000R16_A201WWPDiscussionMentionUserId ;
      private SdtSDT_DiscussionTranslation AV8SDT_DiscussionTranslationVar ;
      private long[] BC000R17_A200WWPDiscussionMessageId ;
      private DateTime[] BC000R17_A203WWPDiscussionMessageDate ;
      private string[] BC000R17_A204WWPDiscussionMessageMessage ;
      private string[] BC000R17_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC000R17_A113WWPUserExtendedFullName ;
      private string[] BC000R17_A126WWPEntityName ;
      private string[] BC000R17_A205WWPDiscussionMessageEntityReco ;
      private string[] BC000R17_A112WWPUserExtendedId ;
      private long[] BC000R17_A125WWPEntityId ;
      private long[] BC000R17_A199WWPDiscussionMessageThreadId ;
      private bool[] BC000R17_n199WWPDiscussionMessageThreadId ;
      private string[] BC000R17_A115WWPUserExtendedPhoto ;
      private SdtSDT_DiscussionTranslation GXt_SdtSDT_DiscussionTranslation2 ;
      private GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage bcwwpbaseobjects_discussions_WWP_DiscussionMessage ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_discussionmessage_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_discussionmessage_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_discussionmessage_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[15])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000R2;
       prmBC000R2 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
       };
       Object[] prmBC000R3;
       prmBC000R3 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
       };
       Object[] prmBC000R4;
       prmBC000R4 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0)
       };
       Object[] prmBC000R5;
       prmBC000R5 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmBC000R6;
       prmBC000R6 = new Object[] {
       new ParDef("WWPDiscussionMessageThreadId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmBC000R7;
       prmBC000R7 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
       };
       Object[] prmBC000R8;
       prmBC000R8 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
       };
       Object[] prmBC000R9;
       prmBC000R9 = new Object[] {
       new ParDef("WWPDiscussionMessageDate",GXType.DateTime,8,5) ,
       new ParDef("WWPDiscussionMessageMessage",GXType.VarChar,400,0) ,
       new ParDef("WWPDiscussionMessageEntityReco",GXType.VarChar,100,0) ,
       new ParDef("WWPUserExtendedId",GXType.Char,40,0) ,
       new ParDef("WWPEntityId",GXType.Int64,10,0) ,
       new ParDef("WWPDiscussionMessageThreadId",GXType.Int64,10,0){Nullable=true}
       };
       Object[] prmBC000R10;
       prmBC000R10 = new Object[] {
       };
       Object[] prmBC000R11;
       prmBC000R11 = new Object[] {
       new ParDef("WWPDiscussionMessageDate",GXType.DateTime,8,5) ,
       new ParDef("WWPDiscussionMessageMessage",GXType.VarChar,400,0) ,
       new ParDef("WWPDiscussionMessageEntityReco",GXType.VarChar,100,0) ,
       new ParDef("WWPUserExtendedId",GXType.Char,40,0) ,
       new ParDef("WWPEntityId",GXType.Int64,10,0) ,
       new ParDef("WWPDiscussionMessageThreadId",GXType.Int64,10,0){Nullable=true} ,
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
       };
       Object[] prmBC000R12;
       prmBC000R12 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
       };
       Object[] prmBC000R13;
       prmBC000R13 = new Object[] {
       new ParDef("WWPUserExtendedId",GXType.Char,40,0)
       };
       Object[] prmBC000R14;
       prmBC000R14 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmBC000R15;
       prmBC000R15 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
       };
       Object[] prmBC000R16;
       prmBC000R16 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
       };
       Object[] prmBC000R17;
       prmBC000R17 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC000R2", "SELECT WWPDiscussionMessageId, WWPDiscussionMessageDate, WWPDiscussionMessageMessage, WWPDiscussionMessageEntityReco, WWPUserExtendedId, WWPEntityId, WWPDiscussionMessageThreadId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId  FOR UPDATE OF WWP_DiscussionMessage",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000R3", "SELECT WWPDiscussionMessageId, WWPDiscussionMessageDate, WWPDiscussionMessageMessage, WWPDiscussionMessageEntityReco, WWPUserExtendedId, WWPEntityId, WWPDiscussionMessageThreadId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000R4", "SELECT WWPUserExtendedPhoto_GXI, WWPUserExtendedFullName, WWPUserExtendedPhoto FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000R5", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000R6", "SELECT WWPDiscussionMessageId AS WWPDiscussionMessageThreadId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageThreadId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000R7", "SELECT TM1.WWPDiscussionMessageId, TM1.WWPDiscussionMessageDate, TM1.WWPDiscussionMessageMessage, T2.WWPUserExtendedPhoto_GXI, T2.WWPUserExtendedFullName, T3.WWPEntityName, TM1.WWPDiscussionMessageEntityReco, TM1.WWPUserExtendedId, TM1.WWPEntityId, TM1.WWPDiscussionMessageThreadId AS WWPDiscussionMessageThreadId, T2.WWPUserExtendedPhoto FROM ((WWP_DiscussionMessage TM1 INNER JOIN WWP_UserExtended T2 ON T2.WWPUserExtendedId = TM1.WWPUserExtendedId) INNER JOIN WWP_Entity T3 ON T3.WWPEntityId = TM1.WWPEntityId) WHERE TM1.WWPDiscussionMessageId = :WWPDiscussionMessageId ORDER BY TM1.WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R7,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000R8", "SELECT WWPDiscussionMessageId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000R9", "SAVEPOINT gxupdate;INSERT INTO WWP_DiscussionMessage(WWPDiscussionMessageDate, WWPDiscussionMessageMessage, WWPDiscussionMessageEntityReco, WWPUserExtendedId, WWPEntityId, WWPDiscussionMessageThreadId) VALUES(:WWPDiscussionMessageDate, :WWPDiscussionMessageMessage, :WWPDiscussionMessageEntityReco, :WWPUserExtendedId, :WWPEntityId, :WWPDiscussionMessageThreadId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000R9)
          ,new CursorDef("BC000R10", "SELECT currval('WWPDiscussionMessageId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R10,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000R11", "SAVEPOINT gxupdate;UPDATE WWP_DiscussionMessage SET WWPDiscussionMessageDate=:WWPDiscussionMessageDate, WWPDiscussionMessageMessage=:WWPDiscussionMessageMessage, WWPDiscussionMessageEntityReco=:WWPDiscussionMessageEntityReco, WWPUserExtendedId=:WWPUserExtendedId, WWPEntityId=:WWPEntityId, WWPDiscussionMessageThreadId=:WWPDiscussionMessageThreadId  WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000R11)
          ,new CursorDef("BC000R12", "SAVEPOINT gxupdate;DELETE FROM WWP_DiscussionMessage  WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000R12)
          ,new CursorDef("BC000R13", "SELECT WWPUserExtendedPhoto_GXI, WWPUserExtendedFullName, WWPUserExtendedPhoto FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R13,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000R14", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R14,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000R15", "SELECT WWPDiscussionMessageId AS WWPDiscussionMessageThreadId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageThreadId = :WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R15,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000R16", "SELECT WWPDiscussionMessageId, WWPDiscussionMentionUserId FROM WWP_DiscussionMessageMention WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R16,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000R17", "SELECT TM1.WWPDiscussionMessageId, TM1.WWPDiscussionMessageDate, TM1.WWPDiscussionMessageMessage, T2.WWPUserExtendedPhoto_GXI, T2.WWPUserExtendedFullName, T3.WWPEntityName, TM1.WWPDiscussionMessageEntityReco, TM1.WWPUserExtendedId, TM1.WWPEntityId, TM1.WWPDiscussionMessageThreadId AS WWPDiscussionMessageThreadId, T2.WWPUserExtendedPhoto FROM ((WWP_DiscussionMessage TM1 INNER JOIN WWP_UserExtended T2 ON T2.WWPUserExtendedId = TM1.WWPUserExtendedId) INNER JOIN WWP_Entity T3 ON T3.WWPEntityId = TM1.WWPEntityId) WHERE TM1.WWPDiscussionMessageId = :WWPDiscussionMessageId ORDER BY TM1.WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R17,100, GxCacheFrequency.OFF ,true,false )
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
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 40);
             ((long[]) buf[5])[0] = rslt.getLong(6);
             ((long[]) buf[6])[0] = rslt.getLong(7);
             ((bool[]) buf[7])[0] = rslt.wasNull(7);
             return;
          case 1 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 40);
             ((long[]) buf[5])[0] = rslt.getLong(6);
             ((long[]) buf[6])[0] = rslt.getLong(7);
             ((bool[]) buf[7])[0] = rslt.wasNull(7);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(1));
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 4 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 5 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getString(8, 40);
             ((long[]) buf[8])[0] = rslt.getLong(9);
             ((long[]) buf[9])[0] = rslt.getLong(10);
             ((bool[]) buf[10])[0] = rslt.wasNull(10);
             ((string[]) buf[11])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(4));
             return;
          case 6 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 8 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 11 :
             ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(1));
             return;
          case 12 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 13 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 14 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 40);
             return;
          case 15 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getString(8, 40);
             ((long[]) buf[8])[0] = rslt.getLong(9);
             ((long[]) buf[9])[0] = rslt.getLong(10);
             ((bool[]) buf[10])[0] = rslt.wasNull(10);
             ((string[]) buf[11])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(4));
             return;
    }
 }

}

}
