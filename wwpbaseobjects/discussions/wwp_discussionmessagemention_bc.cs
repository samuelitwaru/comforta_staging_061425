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
   public class wwp_discussionmessagemention_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_discussionmessagemention_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_discussionmessagemention_bc( IGxContext context )
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
         ReadRow0S39( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0S39( ) ;
         standaloneModal( ) ;
         AddRow0S39( ) ;
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
               Z201WWPDiscussionMentionUserId = A201WWPDiscussionMentionUserId;
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

      protected void CONFIRM_0S0( )
      {
         BeforeValidate0S39( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0S39( ) ;
            }
            else
            {
               CheckExtendedTable0S39( ) ;
               if ( AnyError == 0 )
               {
                  ZM0S39( 2) ;
                  ZM0S39( 3) ;
               }
               CloseExtendedTableCursors0S39( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0S39( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z203WWPDiscussionMessageDate = A203WWPDiscussionMessageDate;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z202WWPDiscussionMentionUserName = A202WWPDiscussionMentionUserName;
         }
         if ( GX_JID == -1 )
         {
            Z200WWPDiscussionMessageId = A200WWPDiscussionMessageId;
            Z201WWPDiscussionMentionUserId = A201WWPDiscussionMentionUserId;
            Z203WWPDiscussionMessageDate = A203WWPDiscussionMessageDate;
            Z202WWPDiscussionMentionUserName = A202WWPDiscussionMentionUserName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0S39( )
      {
         /* Using cursor BC000S6 */
         pr_default.execute(4, new Object[] {A200WWPDiscussionMessageId, A201WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound39 = 1;
            A203WWPDiscussionMessageDate = BC000S6_A203WWPDiscussionMessageDate[0];
            A202WWPDiscussionMentionUserName = BC000S6_A202WWPDiscussionMentionUserName[0];
            ZM0S39( -1) ;
         }
         pr_default.close(4);
         OnLoadActions0S39( ) ;
      }

      protected void OnLoadActions0S39( )
      {
      }

      protected void CheckExtendedTable0S39( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000S4 */
         pr_default.execute(2, new Object[] {A200WWPDiscussionMessageId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_DiscussionMessage", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
            AnyError = 1;
         }
         A203WWPDiscussionMessageDate = BC000S4_A203WWPDiscussionMessageDate[0];
         pr_default.close(2);
         /* Using cursor BC000S5 */
         pr_default.execute(3, new Object[] {A201WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Discussion Message Mention User", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMENTIONUSERID");
            AnyError = 1;
         }
         A202WWPDiscussionMentionUserName = BC000S5_A202WWPDiscussionMentionUserName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0S39( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0S39( )
      {
         /* Using cursor BC000S7 */
         pr_default.execute(5, new Object[] {A200WWPDiscussionMessageId, A201WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound39 = 1;
         }
         else
         {
            RcdFound39 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000S3 */
         pr_default.execute(1, new Object[] {A200WWPDiscussionMessageId, A201WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0S39( 1) ;
            RcdFound39 = 1;
            A200WWPDiscussionMessageId = BC000S3_A200WWPDiscussionMessageId[0];
            A201WWPDiscussionMentionUserId = BC000S3_A201WWPDiscussionMentionUserId[0];
            Z200WWPDiscussionMessageId = A200WWPDiscussionMessageId;
            Z201WWPDiscussionMentionUserId = A201WWPDiscussionMentionUserId;
            sMode39 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0S39( ) ;
            if ( AnyError == 1 )
            {
               RcdFound39 = 0;
               InitializeNonKey0S39( ) ;
            }
            Gx_mode = sMode39;
         }
         else
         {
            RcdFound39 = 0;
            InitializeNonKey0S39( ) ;
            sMode39 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode39;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0S39( ) ;
         if ( RcdFound39 == 0 )
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
         CONFIRM_0S0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0S39( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000S2 */
            pr_default.execute(0, new Object[] {A200WWPDiscussionMessageId, A201WWPDiscussionMentionUserId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_DiscussionMessageMention"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_DiscussionMessageMention"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0S39( )
      {
         BeforeValidate0S39( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S39( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0S39( 0) ;
            CheckOptimisticConcurrency0S39( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S39( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0S39( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000S8 */
                     pr_default.execute(6, new Object[] {A200WWPDiscussionMessageId, A201WWPDiscussionMentionUserId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessageMention");
                     if ( (pr_default.getStatus(6) == 1) )
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
               Load0S39( ) ;
            }
            EndLevel0S39( ) ;
         }
         CloseExtendedTableCursors0S39( ) ;
      }

      protected void Update0S39( )
      {
         BeforeValidate0S39( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S39( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S39( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S39( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0S39( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table WWP_DiscussionMessageMention */
                     DeferredUpdate0S39( ) ;
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
            EndLevel0S39( ) ;
         }
         CloseExtendedTableCursors0S39( ) ;
      }

      protected void DeferredUpdate0S39( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0S39( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S39( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0S39( ) ;
            AfterConfirm0S39( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0S39( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000S9 */
                  pr_default.execute(7, new Object[] {A200WWPDiscussionMessageId, A201WWPDiscussionMentionUserId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessageMention");
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
         sMode39 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0S39( ) ;
         Gx_mode = sMode39;
      }

      protected void OnDeleteControls0S39( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000S10 */
            pr_default.execute(8, new Object[] {A200WWPDiscussionMessageId});
            A203WWPDiscussionMessageDate = BC000S10_A203WWPDiscussionMessageDate[0];
            pr_default.close(8);
            /* Using cursor BC000S11 */
            pr_default.execute(9, new Object[] {A201WWPDiscussionMentionUserId});
            A202WWPDiscussionMentionUserName = BC000S11_A202WWPDiscussionMentionUserName[0];
            pr_default.close(9);
         }
      }

      protected void EndLevel0S39( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0S39( ) ;
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

      public void ScanKeyStart0S39( )
      {
         /* Using cursor BC000S12 */
         pr_default.execute(10, new Object[] {A200WWPDiscussionMessageId, A201WWPDiscussionMentionUserId});
         RcdFound39 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound39 = 1;
            A203WWPDiscussionMessageDate = BC000S12_A203WWPDiscussionMessageDate[0];
            A202WWPDiscussionMentionUserName = BC000S12_A202WWPDiscussionMentionUserName[0];
            A200WWPDiscussionMessageId = BC000S12_A200WWPDiscussionMessageId[0];
            A201WWPDiscussionMentionUserId = BC000S12_A201WWPDiscussionMentionUserId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0S39( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound39 = 0;
         ScanKeyLoad0S39( ) ;
      }

      protected void ScanKeyLoad0S39( )
      {
         sMode39 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound39 = 1;
            A203WWPDiscussionMessageDate = BC000S12_A203WWPDiscussionMessageDate[0];
            A202WWPDiscussionMentionUserName = BC000S12_A202WWPDiscussionMentionUserName[0];
            A200WWPDiscussionMessageId = BC000S12_A200WWPDiscussionMessageId[0];
            A201WWPDiscussionMentionUserId = BC000S12_A201WWPDiscussionMentionUserId[0];
         }
         Gx_mode = sMode39;
      }

      protected void ScanKeyEnd0S39( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0S39( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0S39( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0S39( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0S39( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0S39( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0S39( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0S39( )
      {
      }

      protected void send_integrity_lvl_hashes0S39( )
      {
      }

      protected void AddRow0S39( )
      {
         VarsToRow39( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
      }

      protected void ReadRow0S39( )
      {
         RowToVars39( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
      }

      protected void InitializeNonKey0S39( )
      {
         A203WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         A202WWPDiscussionMentionUserName = "";
      }

      protected void InitAll0S39( )
      {
         A200WWPDiscussionMessageId = 0;
         A201WWPDiscussionMentionUserId = "";
         InitializeNonKey0S39( ) ;
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

      public void VarsToRow39( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention obj39 )
      {
         obj39.gxTpr_Mode = Gx_mode;
         obj39.gxTpr_Wwpdiscussionmessagedate = A203WWPDiscussionMessageDate;
         obj39.gxTpr_Wwpdiscussionmentionusername = A202WWPDiscussionMentionUserName;
         obj39.gxTpr_Wwpdiscussionmessageid = A200WWPDiscussionMessageId;
         obj39.gxTpr_Wwpdiscussionmentionuserid = A201WWPDiscussionMentionUserId;
         obj39.gxTpr_Wwpdiscussionmessageid_Z = Z200WWPDiscussionMessageId;
         obj39.gxTpr_Wwpdiscussionmessagedate_Z = Z203WWPDiscussionMessageDate;
         obj39.gxTpr_Wwpdiscussionmentionuserid_Z = Z201WWPDiscussionMentionUserId;
         obj39.gxTpr_Wwpdiscussionmentionusername_Z = Z202WWPDiscussionMentionUserName;
         obj39.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow39( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention obj39 )
      {
         obj39.gxTpr_Wwpdiscussionmessageid = A200WWPDiscussionMessageId;
         obj39.gxTpr_Wwpdiscussionmentionuserid = A201WWPDiscussionMentionUserId;
         return  ;
      }

      public void RowToVars39( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention obj39 ,
                               int forceLoad )
      {
         Gx_mode = obj39.gxTpr_Mode;
         A203WWPDiscussionMessageDate = obj39.gxTpr_Wwpdiscussionmessagedate;
         A202WWPDiscussionMentionUserName = obj39.gxTpr_Wwpdiscussionmentionusername;
         A200WWPDiscussionMessageId = obj39.gxTpr_Wwpdiscussionmessageid;
         A201WWPDiscussionMentionUserId = obj39.gxTpr_Wwpdiscussionmentionuserid;
         Z200WWPDiscussionMessageId = obj39.gxTpr_Wwpdiscussionmessageid_Z;
         Z203WWPDiscussionMessageDate = obj39.gxTpr_Wwpdiscussionmessagedate_Z;
         Z201WWPDiscussionMentionUserId = obj39.gxTpr_Wwpdiscussionmentionuserid_Z;
         Z202WWPDiscussionMentionUserName = obj39.gxTpr_Wwpdiscussionmentionusername_Z;
         Gx_mode = obj39.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A200WWPDiscussionMessageId = (long)getParm(obj,0);
         A201WWPDiscussionMentionUserId = (string)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0S39( ) ;
         ScanKeyStart0S39( ) ;
         if ( RcdFound39 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000S10 */
            pr_default.execute(8, new Object[] {A200WWPDiscussionMessageId});
            if ( (pr_default.getStatus(8) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_DiscussionMessage", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
               AnyError = 1;
            }
            A203WWPDiscussionMessageDate = BC000S10_A203WWPDiscussionMessageDate[0];
            pr_default.close(8);
            /* Using cursor BC000S11 */
            pr_default.execute(9, new Object[] {A201WWPDiscussionMentionUserId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Discussion Message Mention User", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMENTIONUSERID");
               AnyError = 1;
            }
            A202WWPDiscussionMentionUserName = BC000S11_A202WWPDiscussionMentionUserName[0];
            pr_default.close(9);
         }
         else
         {
            Gx_mode = "UPD";
            Z200WWPDiscussionMessageId = A200WWPDiscussionMessageId;
            Z201WWPDiscussionMentionUserId = A201WWPDiscussionMentionUserId;
         }
         ZM0S39( -1) ;
         OnLoadActions0S39( ) ;
         AddRow0S39( ) ;
         ScanKeyEnd0S39( ) ;
         if ( RcdFound39 == 0 )
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
         RowToVars39( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 0) ;
         ScanKeyStart0S39( ) ;
         if ( RcdFound39 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000S10 */
            pr_default.execute(8, new Object[] {A200WWPDiscussionMessageId});
            if ( (pr_default.getStatus(8) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "WWP_DiscussionMessage", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
               AnyError = 1;
            }
            A203WWPDiscussionMessageDate = BC000S10_A203WWPDiscussionMessageDate[0];
            pr_default.close(8);
            /* Using cursor BC000S11 */
            pr_default.execute(9, new Object[] {A201WWPDiscussionMentionUserId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Discussion Message Mention User", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "WWPDISCUSSIONMENTIONUSERID");
               AnyError = 1;
            }
            A202WWPDiscussionMentionUserName = BC000S11_A202WWPDiscussionMentionUserName[0];
            pr_default.close(9);
         }
         else
         {
            Gx_mode = "UPD";
            Z200WWPDiscussionMessageId = A200WWPDiscussionMessageId;
            Z201WWPDiscussionMentionUserId = A201WWPDiscussionMentionUserId;
         }
         ZM0S39( -1) ;
         OnLoadActions0S39( ) ;
         AddRow0S39( ) ;
         ScanKeyEnd0S39( ) ;
         if ( RcdFound39 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0S39( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0S39( ) ;
         }
         else
         {
            if ( RcdFound39 == 1 )
            {
               if ( ( A200WWPDiscussionMessageId != Z200WWPDiscussionMessageId ) || ( StringUtil.StrCmp(A201WWPDiscussionMentionUserId, Z201WWPDiscussionMentionUserId) != 0 ) )
               {
                  A200WWPDiscussionMessageId = Z200WWPDiscussionMessageId;
                  A201WWPDiscussionMentionUserId = Z201WWPDiscussionMentionUserId;
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
                  Update0S39( ) ;
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
                  if ( ( A200WWPDiscussionMessageId != Z200WWPDiscussionMessageId ) || ( StringUtil.StrCmp(A201WWPDiscussionMentionUserId, Z201WWPDiscussionMentionUserId) != 0 ) )
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
                        Insert0S39( ) ;
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
                        Insert0S39( ) ;
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
         RowToVars39( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
         SaveImpl( ) ;
         VarsToRow39( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars39( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0S39( ) ;
         AfterTrn( ) ;
         VarsToRow39( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow39( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention auxBC = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A200WWPDiscussionMessageId, A201WWPDiscussionMentionUserId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention);
               auxBC.Save();
               bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars39( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
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
         RowToVars39( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0S39( ) ;
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
               VarsToRow39( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow39( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
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
         RowToVars39( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 0) ;
         GetKey0S39( ) ;
         if ( RcdFound39 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A200WWPDiscussionMessageId != Z200WWPDiscussionMessageId ) || ( StringUtil.StrCmp(A201WWPDiscussionMentionUserId, Z201WWPDiscussionMentionUserId) != 0 ) )
            {
               A200WWPDiscussionMessageId = Z200WWPDiscussionMessageId;
               A201WWPDiscussionMentionUserId = Z201WWPDiscussionMentionUserId;
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
            if ( ( A200WWPDiscussionMessageId != Z200WWPDiscussionMessageId ) || ( StringUtil.StrCmp(A201WWPDiscussionMentionUserId, Z201WWPDiscussionMentionUserId) != 0 ) )
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
         context.RollbackDataStores("wwpbaseobjects.discussions.wwp_discussionmessagemention_bc",pr_default);
         VarsToRow39( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
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
         Gx_mode = bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention )
         {
            bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention = (GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow39( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
            }
            else
            {
               RowToVars39( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars39( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_DiscussionMessageMention WWP_DiscussionMessageMention_BC
      {
         get {
            return bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention ;
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
            return "wwpdiscussionmessagemention_Execute" ;
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
         pr_default.close(9);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z201WWPDiscussionMentionUserId = "";
         A201WWPDiscussionMentionUserId = "";
         Z203WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         A203WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         Z202WWPDiscussionMentionUserName = "";
         A202WWPDiscussionMentionUserName = "";
         BC000S6_A203WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000S6_A202WWPDiscussionMentionUserName = new string[] {""} ;
         BC000S6_A200WWPDiscussionMessageId = new long[1] ;
         BC000S6_A201WWPDiscussionMentionUserId = new string[] {""} ;
         BC000S4_A203WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000S5_A202WWPDiscussionMentionUserName = new string[] {""} ;
         BC000S7_A200WWPDiscussionMessageId = new long[1] ;
         BC000S7_A201WWPDiscussionMentionUserId = new string[] {""} ;
         BC000S3_A200WWPDiscussionMessageId = new long[1] ;
         BC000S3_A201WWPDiscussionMentionUserId = new string[] {""} ;
         sMode39 = "";
         BC000S2_A200WWPDiscussionMessageId = new long[1] ;
         BC000S2_A201WWPDiscussionMentionUserId = new string[] {""} ;
         BC000S10_A203WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000S11_A202WWPDiscussionMentionUserName = new string[] {""} ;
         BC000S12_A203WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000S12_A202WWPDiscussionMentionUserName = new string[] {""} ;
         BC000S12_A200WWPDiscussionMessageId = new long[1] ;
         BC000S12_A201WWPDiscussionMentionUserId = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessagemention_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessagemention_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessagemention_bc__default(),
            new Object[][] {
                new Object[] {
               BC000S2_A200WWPDiscussionMessageId, BC000S2_A201WWPDiscussionMentionUserId
               }
               , new Object[] {
               BC000S3_A200WWPDiscussionMessageId, BC000S3_A201WWPDiscussionMentionUserId
               }
               , new Object[] {
               BC000S4_A203WWPDiscussionMessageDate
               }
               , new Object[] {
               BC000S5_A202WWPDiscussionMentionUserName
               }
               , new Object[] {
               BC000S6_A203WWPDiscussionMessageDate, BC000S6_A202WWPDiscussionMentionUserName, BC000S6_A200WWPDiscussionMessageId, BC000S6_A201WWPDiscussionMentionUserId
               }
               , new Object[] {
               BC000S7_A200WWPDiscussionMessageId, BC000S7_A201WWPDiscussionMentionUserId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000S10_A203WWPDiscussionMessageDate
               }
               , new Object[] {
               BC000S11_A202WWPDiscussionMentionUserName
               }
               , new Object[] {
               BC000S12_A203WWPDiscussionMessageDate, BC000S12_A202WWPDiscussionMentionUserName, BC000S12_A200WWPDiscussionMessageId, BC000S12_A201WWPDiscussionMentionUserId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound39 ;
      private int trnEnded ;
      private long Z200WWPDiscussionMessageId ;
      private long A200WWPDiscussionMessageId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z201WWPDiscussionMentionUserId ;
      private string A201WWPDiscussionMentionUserId ;
      private string sMode39 ;
      private DateTime Z203WWPDiscussionMessageDate ;
      private DateTime A203WWPDiscussionMessageDate ;
      private string Z202WWPDiscussionMentionUserName ;
      private string A202WWPDiscussionMentionUserName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] BC000S6_A203WWPDiscussionMessageDate ;
      private string[] BC000S6_A202WWPDiscussionMentionUserName ;
      private long[] BC000S6_A200WWPDiscussionMessageId ;
      private string[] BC000S6_A201WWPDiscussionMentionUserId ;
      private DateTime[] BC000S4_A203WWPDiscussionMessageDate ;
      private string[] BC000S5_A202WWPDiscussionMentionUserName ;
      private long[] BC000S7_A200WWPDiscussionMessageId ;
      private string[] BC000S7_A201WWPDiscussionMentionUserId ;
      private long[] BC000S3_A200WWPDiscussionMessageId ;
      private string[] BC000S3_A201WWPDiscussionMentionUserId ;
      private long[] BC000S2_A200WWPDiscussionMessageId ;
      private string[] BC000S2_A201WWPDiscussionMentionUserId ;
      private DateTime[] BC000S10_A203WWPDiscussionMessageDate ;
      private string[] BC000S11_A202WWPDiscussionMentionUserName ;
      private DateTime[] BC000S12_A203WWPDiscussionMessageDate ;
      private string[] BC000S12_A202WWPDiscussionMentionUserName ;
      private long[] BC000S12_A200WWPDiscussionMessageId ;
      private string[] BC000S12_A201WWPDiscussionMentionUserId ;
      private GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_discussionmessagemention_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_discussionmessagemention_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_discussionmessagemention_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[7])
      ,new ForEachCursor(def[8])
      ,new ForEachCursor(def[9])
      ,new ForEachCursor(def[10])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000S2;
       prmBC000S2 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0) ,
       new ParDef("WWPDiscussionMentionUserId",GXType.Char,40,0)
       };
       Object[] prmBC000S3;
       prmBC000S3 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0) ,
       new ParDef("WWPDiscussionMentionUserId",GXType.Char,40,0)
       };
       Object[] prmBC000S4;
       prmBC000S4 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
       };
       Object[] prmBC000S5;
       prmBC000S5 = new Object[] {
       new ParDef("WWPDiscussionMentionUserId",GXType.Char,40,0)
       };
       Object[] prmBC000S6;
       prmBC000S6 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0) ,
       new ParDef("WWPDiscussionMentionUserId",GXType.Char,40,0)
       };
       Object[] prmBC000S7;
       prmBC000S7 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0) ,
       new ParDef("WWPDiscussionMentionUserId",GXType.Char,40,0)
       };
       Object[] prmBC000S8;
       prmBC000S8 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0) ,
       new ParDef("WWPDiscussionMentionUserId",GXType.Char,40,0)
       };
       Object[] prmBC000S9;
       prmBC000S9 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0) ,
       new ParDef("WWPDiscussionMentionUserId",GXType.Char,40,0)
       };
       Object[] prmBC000S10;
       prmBC000S10 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
       };
       Object[] prmBC000S11;
       prmBC000S11 = new Object[] {
       new ParDef("WWPDiscussionMentionUserId",GXType.Char,40,0)
       };
       Object[] prmBC000S12;
       prmBC000S12 = new Object[] {
       new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0) ,
       new ParDef("WWPDiscussionMentionUserId",GXType.Char,40,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC000S2", "SELECT WWPDiscussionMessageId, WWPDiscussionMentionUserId FROM WWP_DiscussionMessageMention WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId AND WWPDiscussionMentionUserId = :WWPDiscussionMentionUserId  FOR UPDATE OF WWP_DiscussionMessageMention",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000S3", "SELECT WWPDiscussionMessageId, WWPDiscussionMentionUserId FROM WWP_DiscussionMessageMention WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId AND WWPDiscussionMentionUserId = :WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000S4", "SELECT WWPDiscussionMessageDate FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000S5", "SELECT WWPUserExtendedFullName AS WWPDiscussionMentionUserName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000S6", "SELECT T2.WWPDiscussionMessageDate, T3.WWPUserExtendedFullName AS WWPDiscussionMentionUserName, TM1.WWPDiscussionMessageId, TM1.WWPDiscussionMentionUserId AS WWPDiscussionMentionUserId FROM ((WWP_DiscussionMessageMention TM1 INNER JOIN WWP_DiscussionMessage T2 ON T2.WWPDiscussionMessageId = TM1.WWPDiscussionMessageId) INNER JOIN WWP_UserExtended T3 ON T3.WWPUserExtendedId = TM1.WWPDiscussionMentionUserId) WHERE TM1.WWPDiscussionMessageId = :WWPDiscussionMessageId and TM1.WWPDiscussionMentionUserId = ( :WWPDiscussionMentionUserId) ORDER BY TM1.WWPDiscussionMessageId, TM1.WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S6,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000S7", "SELECT WWPDiscussionMessageId, WWPDiscussionMentionUserId FROM WWP_DiscussionMessageMention WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId AND WWPDiscussionMentionUserId = :WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000S8", "SAVEPOINT gxupdate;INSERT INTO WWP_DiscussionMessageMention(WWPDiscussionMessageId, WWPDiscussionMentionUserId) VALUES(:WWPDiscussionMessageId, :WWPDiscussionMentionUserId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000S8)
          ,new CursorDef("BC000S9", "SAVEPOINT gxupdate;DELETE FROM WWP_DiscussionMessageMention  WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId AND WWPDiscussionMentionUserId = :WWPDiscussionMentionUserId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000S9)
          ,new CursorDef("BC000S10", "SELECT WWPDiscussionMessageDate FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S10,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000S11", "SELECT WWPUserExtendedFullName AS WWPDiscussionMentionUserName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S11,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000S12", "SELECT T2.WWPDiscussionMessageDate, T3.WWPUserExtendedFullName AS WWPDiscussionMentionUserName, TM1.WWPDiscussionMessageId, TM1.WWPDiscussionMentionUserId AS WWPDiscussionMentionUserId FROM ((WWP_DiscussionMessageMention TM1 INNER JOIN WWP_DiscussionMessage T2 ON T2.WWPDiscussionMessageId = TM1.WWPDiscussionMessageId) INNER JOIN WWP_UserExtended T3 ON T3.WWPUserExtendedId = TM1.WWPDiscussionMentionUserId) WHERE TM1.WWPDiscussionMessageId = :WWPDiscussionMessageId and TM1.WWPDiscussionMentionUserId = ( :WWPDiscussionMentionUserId) ORDER BY TM1.WWPDiscussionMessageId, TM1.WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S12,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[1])[0] = rslt.getString(2, 40);
             return;
          case 1 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 40);
             return;
          case 2 :
             ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 4 :
             ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((long[]) buf[2])[0] = rslt.getLong(3);
             ((string[]) buf[3])[0] = rslt.getString(4, 40);
             return;
          case 5 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 40);
             return;
          case 8 :
             ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
             return;
          case 9 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 10 :
             ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((long[]) buf[2])[0] = rslt.getLong(3);
             ((string[]) buf[3])[0] = rslt.getString(4, 40);
             return;
    }
 }

}

}
