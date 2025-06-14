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
   public class trn_theme_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_theme_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_theme_bc( IGxContext context )
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
         ReadRow0Z51( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0Z51( ) ;
         standaloneModal( ) ;
         AddRow0Z51( ) ;
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
            /* Execute user event: After Trn */
            E110Z2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z273Trn_ThemeId = A273Trn_ThemeId;
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

      protected void CONFIRM_0Z0( )
      {
         BeforeValidate0Z51( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0Z51( ) ;
            }
            else
            {
               CheckExtendedTable0Z51( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0Z51( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode51 = Gx_mode;
            CONFIRM_0Z97( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_0Z82( ) ;
               if ( AnyError == 0 )
               {
                  CONFIRM_0Z53( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Restore parent mode. */
                     Gx_mode = sMode51;
                  }
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode51;
         }
      }

      protected void CONFIRM_0Z53( )
      {
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < bcTrn_Theme.gxTpr_Color.Count )
         {
            ReadRow0Z53( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound53 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_53 != 0 ) )
            {
               GetKey0Z53( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound53 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0Z53( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0Z53( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors0Z53( ) ;
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
                  if ( RcdFound53 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0Z53( ) ;
                        Load0Z53( ) ;
                        BeforeValidate0Z53( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0Z53( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_53 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0Z53( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0Z53( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors0Z53( ) ;
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
               VarsToRow53( ((SdtTrn_Theme_Color)bcTrn_Theme.gxTpr_Color.Item(nGXsfl_53_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0Z82( )
      {
         nGXsfl_82_idx = 0;
         while ( nGXsfl_82_idx < bcTrn_Theme.gxTpr_Icon.Count )
         {
            ReadRow0Z82( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound82 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_82 != 0 ) )
            {
               GetKey0Z82( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound82 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0Z82( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0Z82( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors0Z82( ) ;
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
                  if ( RcdFound82 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0Z82( ) ;
                        Load0Z82( ) ;
                        BeforeValidate0Z82( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0Z82( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_82 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0Z82( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0Z82( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors0Z82( ) ;
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
               VarsToRow82( ((SdtTrn_Theme_Icon)bcTrn_Theme.gxTpr_Icon.Item(nGXsfl_82_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0Z97( )
      {
         nGXsfl_97_idx = 0;
         while ( nGXsfl_97_idx < bcTrn_Theme.gxTpr_Ctacolor.Count )
         {
            ReadRow0Z97( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound97 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_97 != 0 ) )
            {
               GetKey0Z97( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound97 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0Z97( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0Z97( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors0Z97( ) ;
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
                  if ( RcdFound97 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0Z97( ) ;
                        Load0Z97( ) ;
                        BeforeValidate0Z97( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0Z97( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_97 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0Z97( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0Z97( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors0Z97( ) ;
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
               VarsToRow97( ((SdtTrn_Theme_CtaColor)bcTrn_Theme.gxTpr_Ctacolor.Item(nGXsfl_97_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E120Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110Z2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0Z51( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z274Trn_ThemeName = A274Trn_ThemeName;
            Z281Trn_ThemeFontFamily = A281Trn_ThemeFontFamily;
            Z405Trn_ThemeFontSize = A405Trn_ThemeFontSize;
            Z576ThemeIsPredefined = A576ThemeIsPredefined;
         }
         if ( GX_JID == -11 )
         {
            Z273Trn_ThemeId = A273Trn_ThemeId;
            Z274Trn_ThemeName = A274Trn_ThemeName;
            Z281Trn_ThemeFontFamily = A281Trn_ThemeFontFamily;
            Z405Trn_ThemeFontSize = A405Trn_ThemeFontSize;
            Z576ThemeIsPredefined = A576ThemeIsPredefined;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A273Trn_ThemeId) )
         {
            A273Trn_ThemeId = Guid.NewGuid( );
            n273Trn_ThemeId = false;
         }
         if ( IsIns( )  && (false==A576ThemeIsPredefined) && ( Gx_BScreen == 0 ) )
         {
            A576ThemeIsPredefined = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0Z51( )
      {
         /* Using cursor BC000Z10 */
         pr_default.execute(8, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound51 = 1;
            A274Trn_ThemeName = BC000Z10_A274Trn_ThemeName[0];
            A281Trn_ThemeFontFamily = BC000Z10_A281Trn_ThemeFontFamily[0];
            A405Trn_ThemeFontSize = BC000Z10_A405Trn_ThemeFontSize[0];
            A576ThemeIsPredefined = BC000Z10_A576ThemeIsPredefined[0];
            ZM0Z51( -11) ;
         }
         pr_default.close(8);
         OnLoadActions0Z51( ) ;
      }

      protected void OnLoadActions0Z51( )
      {
      }

      protected void CheckExtendedTable0Z51( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0Z51( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0Z51( )
      {
         /* Using cursor BC000Z11 */
         pr_default.execute(9, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound51 = 1;
         }
         else
         {
            RcdFound51 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000Z9 */
         pr_default.execute(7, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            ZM0Z51( 11) ;
            RcdFound51 = 1;
            A273Trn_ThemeId = BC000Z9_A273Trn_ThemeId[0];
            n273Trn_ThemeId = BC000Z9_n273Trn_ThemeId[0];
            A274Trn_ThemeName = BC000Z9_A274Trn_ThemeName[0];
            A281Trn_ThemeFontFamily = BC000Z9_A281Trn_ThemeFontFamily[0];
            A405Trn_ThemeFontSize = BC000Z9_A405Trn_ThemeFontSize[0];
            A576ThemeIsPredefined = BC000Z9_A576ThemeIsPredefined[0];
            Z273Trn_ThemeId = A273Trn_ThemeId;
            sMode51 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0Z51( ) ;
            if ( AnyError == 1 )
            {
               RcdFound51 = 0;
               InitializeNonKey0Z51( ) ;
            }
            Gx_mode = sMode51;
         }
         else
         {
            RcdFound51 = 0;
            InitializeNonKey0Z51( ) ;
            sMode51 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode51;
         }
         pr_default.close(7);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Z51( ) ;
         if ( RcdFound51 == 0 )
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
         CONFIRM_0Z0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0Z51( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000Z8 */
            pr_default.execute(6, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
            if ( (pr_default.getStatus(6) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Theme"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(6) == 101) || ( StringUtil.StrCmp(Z274Trn_ThemeName, BC000Z8_A274Trn_ThemeName[0]) != 0 ) || ( StringUtil.StrCmp(Z281Trn_ThemeFontFamily, BC000Z8_A281Trn_ThemeFontFamily[0]) != 0 ) || ( Z405Trn_ThemeFontSize != BC000Z8_A405Trn_ThemeFontSize[0] ) || ( Z576ThemeIsPredefined != BC000Z8_A576ThemeIsPredefined[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Theme"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Z51( )
      {
         BeforeValidate0Z51( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z51( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Z51( 0) ;
            CheckOptimisticConcurrency0Z51( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z51( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Z51( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Z12 */
                     pr_default.execute(10, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A274Trn_ThemeName, A281Trn_ThemeFontFamily, A405Trn_ThemeFontSize, A576ThemeIsPredefined});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Theme");
                     if ( (pr_default.getStatus(10) == 1) )
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
                           ProcessLevel0Z51( ) ;
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
               Load0Z51( ) ;
            }
            EndLevel0Z51( ) ;
         }
         CloseExtendedTableCursors0Z51( ) ;
      }

      protected void Update0Z51( )
      {
         BeforeValidate0Z51( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z51( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z51( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z51( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Z51( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Z13 */
                     pr_default.execute(11, new Object[] {A274Trn_ThemeName, A281Trn_ThemeFontFamily, A405Trn_ThemeFontSize, A576ThemeIsPredefined, n273Trn_ThemeId, A273Trn_ThemeId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Theme");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Theme"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Z51( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0Z51( ) ;
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
            EndLevel0Z51( ) ;
         }
         CloseExtendedTableCursors0Z51( ) ;
      }

      protected void DeferredUpdate0Z51( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0Z51( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z51( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Z51( ) ;
            AfterConfirm0Z51( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Z51( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0Z97( ) ;
                  while ( RcdFound97 != 0 )
                  {
                     getByPrimaryKey0Z97( ) ;
                     Delete0Z97( ) ;
                     ScanKeyNext0Z97( ) ;
                  }
                  ScanKeyEnd0Z97( ) ;
                  ScanKeyStart0Z82( ) ;
                  while ( RcdFound82 != 0 )
                  {
                     getByPrimaryKey0Z82( ) ;
                     Delete0Z82( ) ;
                     ScanKeyNext0Z82( ) ;
                  }
                  ScanKeyEnd0Z82( ) ;
                  ScanKeyStart0Z53( ) ;
                  while ( RcdFound53 != 0 )
                  {
                     getByPrimaryKey0Z53( ) ;
                     Delete0Z53( ) ;
                     ScanKeyNext0Z53( ) ;
                  }
                  ScanKeyEnd0Z53( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Z14 */
                     pr_default.execute(12, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Theme");
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
         sMode51 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0Z51( ) ;
         Gx_mode = sMode51;
      }

      protected void OnDeleteControls0Z51( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000Z15 */
            pr_default.execute(13, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Locations", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor BC000Z16 */
            pr_default.execute(14, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor BC000Z17 */
            pr_default.execute(15, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_OrganisationSetting", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
         }
      }

      protected void ProcessNestedLevel0Z97( )
      {
         nGXsfl_97_idx = 0;
         while ( nGXsfl_97_idx < bcTrn_Theme.gxTpr_Ctacolor.Count )
         {
            ReadRow0Z97( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound97 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_97 != 0 ) )
            {
               standaloneNotModal0Z97( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0Z97( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0Z97( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0Z97( ) ;
                  }
               }
            }
            KeyVarsToRow97( ((SdtTrn_Theme_CtaColor)bcTrn_Theme.gxTpr_Ctacolor.Item(nGXsfl_97_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_97_idx = 0;
            while ( nGXsfl_97_idx < bcTrn_Theme.gxTpr_Ctacolor.Count )
            {
               ReadRow0Z97( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound97 == 0 )
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
                  bcTrn_Theme.gxTpr_Ctacolor.RemoveElement(nGXsfl_97_idx);
                  nGXsfl_97_idx = (int)(nGXsfl_97_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0Z97( ) ;
                  VarsToRow97( ((SdtTrn_Theme_CtaColor)bcTrn_Theme.gxTpr_Ctacolor.Item(nGXsfl_97_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0Z97( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_97 = 0;
         nIsMod_97 = 0;
      }

      protected void ProcessNestedLevel0Z82( )
      {
         nGXsfl_82_idx = 0;
         while ( nGXsfl_82_idx < bcTrn_Theme.gxTpr_Icon.Count )
         {
            ReadRow0Z82( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound82 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_82 != 0 ) )
            {
               standaloneNotModal0Z82( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0Z82( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0Z82( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0Z82( ) ;
                  }
               }
            }
            KeyVarsToRow82( ((SdtTrn_Theme_Icon)bcTrn_Theme.gxTpr_Icon.Item(nGXsfl_82_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_82_idx = 0;
            while ( nGXsfl_82_idx < bcTrn_Theme.gxTpr_Icon.Count )
            {
               ReadRow0Z82( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound82 == 0 )
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
                  bcTrn_Theme.gxTpr_Icon.RemoveElement(nGXsfl_82_idx);
                  nGXsfl_82_idx = (int)(nGXsfl_82_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0Z82( ) ;
                  VarsToRow82( ((SdtTrn_Theme_Icon)bcTrn_Theme.gxTpr_Icon.Item(nGXsfl_82_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0Z82( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_82 = 0;
         nIsMod_82 = 0;
      }

      protected void ProcessNestedLevel0Z53( )
      {
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < bcTrn_Theme.gxTpr_Color.Count )
         {
            ReadRow0Z53( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound53 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_53 != 0 ) )
            {
               standaloneNotModal0Z53( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0Z53( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0Z53( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0Z53( ) ;
                  }
               }
            }
            KeyVarsToRow53( ((SdtTrn_Theme_Color)bcTrn_Theme.gxTpr_Color.Item(nGXsfl_53_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_53_idx = 0;
            while ( nGXsfl_53_idx < bcTrn_Theme.gxTpr_Color.Count )
            {
               ReadRow0Z53( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound53 == 0 )
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
                  bcTrn_Theme.gxTpr_Color.RemoveElement(nGXsfl_53_idx);
                  nGXsfl_53_idx = (int)(nGXsfl_53_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0Z53( ) ;
                  VarsToRow53( ((SdtTrn_Theme_Color)bcTrn_Theme.gxTpr_Color.Item(nGXsfl_53_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0Z53( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_53 = 0;
         nIsMod_53 = 0;
      }

      protected void ProcessLevel0Z51( )
      {
         /* Save parent mode. */
         sMode51 = Gx_mode;
         ProcessNestedLevel0Z97( ) ;
         ProcessNestedLevel0Z82( ) ;
         ProcessNestedLevel0Z53( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode51;
         /* ' Update level parameters */
      }

      protected void EndLevel0Z51( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(6);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Z51( ) ;
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

      public void ScanKeyStart0Z51( )
      {
         /* Scan By routine */
         /* Using cursor BC000Z18 */
         pr_default.execute(16, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
         RcdFound51 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound51 = 1;
            A273Trn_ThemeId = BC000Z18_A273Trn_ThemeId[0];
            n273Trn_ThemeId = BC000Z18_n273Trn_ThemeId[0];
            A274Trn_ThemeName = BC000Z18_A274Trn_ThemeName[0];
            A281Trn_ThemeFontFamily = BC000Z18_A281Trn_ThemeFontFamily[0];
            A405Trn_ThemeFontSize = BC000Z18_A405Trn_ThemeFontSize[0];
            A576ThemeIsPredefined = BC000Z18_A576ThemeIsPredefined[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0Z51( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound51 = 0;
         ScanKeyLoad0Z51( ) ;
      }

      protected void ScanKeyLoad0Z51( )
      {
         sMode51 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound51 = 1;
            A273Trn_ThemeId = BC000Z18_A273Trn_ThemeId[0];
            n273Trn_ThemeId = BC000Z18_n273Trn_ThemeId[0];
            A274Trn_ThemeName = BC000Z18_A274Trn_ThemeName[0];
            A281Trn_ThemeFontFamily = BC000Z18_A281Trn_ThemeFontFamily[0];
            A405Trn_ThemeFontSize = BC000Z18_A405Trn_ThemeFontSize[0];
            A576ThemeIsPredefined = BC000Z18_A576ThemeIsPredefined[0];
         }
         Gx_mode = sMode51;
      }

      protected void ScanKeyEnd0Z51( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm0Z51( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Z51( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Z51( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Z51( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Z51( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Z51( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Z51( )
      {
      }

      protected void ZM0Z97( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z539CtaColorName = A539CtaColorName;
            Z540CtaColorCode = A540CtaColorCode;
         }
         if ( GX_JID == -12 )
         {
            Z273Trn_ThemeId = A273Trn_ThemeId;
            Z538CtaColorId = A538CtaColorId;
            Z539CtaColorName = A539CtaColorName;
            Z540CtaColorCode = A540CtaColorCode;
         }
      }

      protected void standaloneNotModal0Z97( )
      {
      }

      protected void standaloneModal0Z97( )
      {
         if ( IsIns( )  && (Guid.Empty==A538CtaColorId) )
         {
            A538CtaColorId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0Z97( )
      {
         /* Using cursor BC000Z19 */
         pr_default.execute(17, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A538CtaColorId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound97 = 1;
            A539CtaColorName = BC000Z19_A539CtaColorName[0];
            A540CtaColorCode = BC000Z19_A540CtaColorCode[0];
            ZM0Z97( -12) ;
         }
         pr_default.close(17);
         OnLoadActions0Z97( ) ;
      }

      protected void OnLoadActions0Z97( )
      {
      }

      protected void CheckExtendedTable0Z97( )
      {
         Gx_BScreen = 1;
         standaloneModal0Z97( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000Z20 */
         pr_default.execute(18, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A539CtaColorName, A538CtaColorId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Cta Color Name", "")}), 1, "");
            AnyError = 1;
         }
         pr_default.close(18);
      }

      protected void CloseExtendedTableCursors0Z97( )
      {
      }

      protected void enableDisable0Z97( )
      {
      }

      protected void GetKey0Z97( )
      {
         /* Using cursor BC000Z21 */
         pr_default.execute(19, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A538CtaColorId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound97 = 1;
         }
         else
         {
            RcdFound97 = 0;
         }
         pr_default.close(19);
      }

      protected void getByPrimaryKey0Z97( )
      {
         /* Using cursor BC000Z7 */
         pr_default.execute(5, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A538CtaColorId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0Z97( 12) ;
            RcdFound97 = 1;
            InitializeNonKey0Z97( ) ;
            A538CtaColorId = BC000Z7_A538CtaColorId[0];
            A539CtaColorName = BC000Z7_A539CtaColorName[0];
            A540CtaColorCode = BC000Z7_A540CtaColorCode[0];
            Z273Trn_ThemeId = A273Trn_ThemeId;
            Z538CtaColorId = A538CtaColorId;
            sMode97 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0Z97( ) ;
            Load0Z97( ) ;
            Gx_mode = sMode97;
         }
         else
         {
            RcdFound97 = 0;
            InitializeNonKey0Z97( ) ;
            sMode97 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0Z97( ) ;
            Gx_mode = sMode97;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0Z97( ) ;
         }
         pr_default.close(5);
      }

      protected void CheckOptimisticConcurrency0Z97( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000Z6 */
            pr_default.execute(4, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A538CtaColorId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeCtaColor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( StringUtil.StrCmp(Z539CtaColorName, BC000Z6_A539CtaColorName[0]) != 0 ) || ( StringUtil.StrCmp(Z540CtaColorCode, BC000Z6_A540CtaColorCode[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ThemeCtaColor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Z97( )
      {
         BeforeValidate0Z97( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z97( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Z97( 0) ;
            CheckOptimisticConcurrency0Z97( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z97( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Z97( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Z22 */
                     pr_default.execute(20, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A538CtaColorId, A539CtaColorName, A540CtaColorCode});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeCtaColor");
                     if ( (pr_default.getStatus(20) == 1) )
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
               Load0Z97( ) ;
            }
            EndLevel0Z97( ) ;
         }
         CloseExtendedTableCursors0Z97( ) ;
      }

      protected void Update0Z97( )
      {
         BeforeValidate0Z97( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z97( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z97( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z97( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Z97( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Z23 */
                     pr_default.execute(21, new Object[] {A539CtaColorName, A540CtaColorCode, n273Trn_ThemeId, A273Trn_ThemeId, A538CtaColorId});
                     pr_default.close(21);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeCtaColor");
                     if ( (pr_default.getStatus(21) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeCtaColor"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Z97( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0Z97( ) ;
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
            EndLevel0Z97( ) ;
         }
         CloseExtendedTableCursors0Z97( ) ;
      }

      protected void DeferredUpdate0Z97( )
      {
      }

      protected void Delete0Z97( )
      {
         Gx_mode = "DLT";
         BeforeValidate0Z97( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z97( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Z97( ) ;
            AfterConfirm0Z97( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Z97( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000Z24 */
                  pr_default.execute(22, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A538CtaColorId});
                  pr_default.close(22);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeCtaColor");
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
         sMode97 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0Z97( ) ;
         Gx_mode = sMode97;
      }

      protected void OnDeleteControls0Z97( )
      {
         standaloneModal0Z97( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0Z97( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0Z97( )
      {
         /* Scan By routine */
         /* Using cursor BC000Z25 */
         pr_default.execute(23, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
         RcdFound97 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound97 = 1;
            A538CtaColorId = BC000Z25_A538CtaColorId[0];
            A539CtaColorName = BC000Z25_A539CtaColorName[0];
            A540CtaColorCode = BC000Z25_A540CtaColorCode[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0Z97( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound97 = 0;
         ScanKeyLoad0Z97( ) ;
      }

      protected void ScanKeyLoad0Z97( )
      {
         sMode97 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound97 = 1;
            A538CtaColorId = BC000Z25_A538CtaColorId[0];
            A539CtaColorName = BC000Z25_A539CtaColorName[0];
            A540CtaColorCode = BC000Z25_A540CtaColorCode[0];
         }
         Gx_mode = sMode97;
      }

      protected void ScanKeyEnd0Z97( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm0Z97( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Z97( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Z97( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Z97( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Z97( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Z97( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Z97( )
      {
      }

      protected void send_integrity_lvl_hashes0Z97( )
      {
      }

      protected void ZM0Z82( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z443IconCategory = A443IconCategory;
            Z283IconName = A283IconName;
         }
         if ( GX_JID == -14 )
         {
            Z273Trn_ThemeId = A273Trn_ThemeId;
            Z282IconId = A282IconId;
            Z443IconCategory = A443IconCategory;
            Z283IconName = A283IconName;
            Z284IconSVG = A284IconSVG;
         }
      }

      protected void standaloneNotModal0Z82( )
      {
      }

      protected void standaloneModal0Z82( )
      {
         if ( IsIns( )  && (Guid.Empty==A282IconId) )
         {
            A282IconId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0Z82( )
      {
         /* Using cursor BC000Z26 */
         pr_default.execute(24, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A282IconId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound82 = 1;
            A443IconCategory = BC000Z26_A443IconCategory[0];
            A283IconName = BC000Z26_A283IconName[0];
            A284IconSVG = BC000Z26_A284IconSVG[0];
            ZM0Z82( -14) ;
         }
         pr_default.close(24);
         OnLoadActions0Z82( ) ;
      }

      protected void OnLoadActions0Z82( )
      {
      }

      protected void CheckExtendedTable0Z82( )
      {
         Gx_BScreen = 1;
         standaloneModal0Z82( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000Z27 */
         pr_default.execute(25, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A283IconName, A443IconCategory, A282IconId});
         if ( (pr_default.getStatus(25) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Icon Name", "")+","+context.GetMessage( "Icon Category", "")}), 1, "");
            AnyError = 1;
         }
         pr_default.close(25);
         if ( ! ( ( StringUtil.StrCmp(A443IconCategory, "General") == 0 ) || ( StringUtil.StrCmp(A443IconCategory, "Services") == 0 ) || ( StringUtil.StrCmp(A443IconCategory, "Living") == 0 ) || ( StringUtil.StrCmp(A443IconCategory, "Health") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Icon Category", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0Z82( )
      {
      }

      protected void enableDisable0Z82( )
      {
      }

      protected void GetKey0Z82( )
      {
         /* Using cursor BC000Z28 */
         pr_default.execute(26, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A282IconId});
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound82 = 1;
         }
         else
         {
            RcdFound82 = 0;
         }
         pr_default.close(26);
      }

      protected void getByPrimaryKey0Z82( )
      {
         /* Using cursor BC000Z5 */
         pr_default.execute(3, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A282IconId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0Z82( 14) ;
            RcdFound82 = 1;
            InitializeNonKey0Z82( ) ;
            A282IconId = BC000Z5_A282IconId[0];
            A443IconCategory = BC000Z5_A443IconCategory[0];
            A283IconName = BC000Z5_A283IconName[0];
            A284IconSVG = BC000Z5_A284IconSVG[0];
            Z273Trn_ThemeId = A273Trn_ThemeId;
            Z282IconId = A282IconId;
            sMode82 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0Z82( ) ;
            Load0Z82( ) ;
            Gx_mode = sMode82;
         }
         else
         {
            RcdFound82 = 0;
            InitializeNonKey0Z82( ) ;
            sMode82 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0Z82( ) ;
            Gx_mode = sMode82;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0Z82( ) ;
         }
         pr_default.close(3);
      }

      protected void CheckOptimisticConcurrency0Z82( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000Z4 */
            pr_default.execute(2, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A282IconId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeIcon"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z443IconCategory, BC000Z4_A443IconCategory[0]) != 0 ) || ( StringUtil.StrCmp(Z283IconName, BC000Z4_A283IconName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ThemeIcon"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Z82( )
      {
         BeforeValidate0Z82( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z82( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Z82( 0) ;
            CheckOptimisticConcurrency0Z82( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z82( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Z82( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Z29 */
                     pr_default.execute(27, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A282IconId, A443IconCategory, A283IconName, A284IconSVG});
                     pr_default.close(27);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeIcon");
                     if ( (pr_default.getStatus(27) == 1) )
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
               Load0Z82( ) ;
            }
            EndLevel0Z82( ) ;
         }
         CloseExtendedTableCursors0Z82( ) ;
      }

      protected void Update0Z82( )
      {
         BeforeValidate0Z82( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z82( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z82( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z82( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Z82( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Z30 */
                     pr_default.execute(28, new Object[] {A443IconCategory, A283IconName, A284IconSVG, n273Trn_ThemeId, A273Trn_ThemeId, A282IconId});
                     pr_default.close(28);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeIcon");
                     if ( (pr_default.getStatus(28) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeIcon"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Z82( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0Z82( ) ;
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
            EndLevel0Z82( ) ;
         }
         CloseExtendedTableCursors0Z82( ) ;
      }

      protected void DeferredUpdate0Z82( )
      {
      }

      protected void Delete0Z82( )
      {
         Gx_mode = "DLT";
         BeforeValidate0Z82( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z82( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Z82( ) ;
            AfterConfirm0Z82( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Z82( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000Z31 */
                  pr_default.execute(29, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A282IconId});
                  pr_default.close(29);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeIcon");
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
         sMode82 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0Z82( ) ;
         Gx_mode = sMode82;
      }

      protected void OnDeleteControls0Z82( )
      {
         standaloneModal0Z82( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0Z82( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0Z82( )
      {
         /* Scan By routine */
         /* Using cursor BC000Z32 */
         pr_default.execute(30, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
         RcdFound82 = 0;
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound82 = 1;
            A282IconId = BC000Z32_A282IconId[0];
            A443IconCategory = BC000Z32_A443IconCategory[0];
            A283IconName = BC000Z32_A283IconName[0];
            A284IconSVG = BC000Z32_A284IconSVG[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0Z82( )
      {
         /* Scan next routine */
         pr_default.readNext(30);
         RcdFound82 = 0;
         ScanKeyLoad0Z82( ) ;
      }

      protected void ScanKeyLoad0Z82( )
      {
         sMode82 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound82 = 1;
            A282IconId = BC000Z32_A282IconId[0];
            A443IconCategory = BC000Z32_A443IconCategory[0];
            A283IconName = BC000Z32_A283IconName[0];
            A284IconSVG = BC000Z32_A284IconSVG[0];
         }
         Gx_mode = sMode82;
      }

      protected void ScanKeyEnd0Z82( )
      {
         pr_default.close(30);
      }

      protected void AfterConfirm0Z82( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Z82( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Z82( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Z82( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Z82( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Z82( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Z82( )
      {
      }

      protected void send_integrity_lvl_hashes0Z82( )
      {
      }

      protected void ZM0Z53( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z276ColorName = A276ColorName;
            Z277ColorCode = A277ColorCode;
         }
         if ( GX_JID == -16 )
         {
            Z273Trn_ThemeId = A273Trn_ThemeId;
            Z275ColorId = A275ColorId;
            Z276ColorName = A276ColorName;
            Z277ColorCode = A277ColorCode;
         }
      }

      protected void standaloneNotModal0Z53( )
      {
      }

      protected void standaloneModal0Z53( )
      {
         if ( IsIns( )  && (Guid.Empty==A275ColorId) )
         {
            A275ColorId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0Z53( )
      {
         /* Using cursor BC000Z33 */
         pr_default.execute(31, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A275ColorId});
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound53 = 1;
            A276ColorName = BC000Z33_A276ColorName[0];
            A277ColorCode = BC000Z33_A277ColorCode[0];
            ZM0Z53( -16) ;
         }
         pr_default.close(31);
         OnLoadActions0Z53( ) ;
      }

      protected void OnLoadActions0Z53( )
      {
      }

      protected void CheckExtendedTable0Z53( )
      {
         Gx_BScreen = 1;
         standaloneModal0Z53( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000Z34 */
         pr_default.execute(32, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A276ColorName, A275ColorId});
         if ( (pr_default.getStatus(32) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Color Name", "")}), 1, "");
            AnyError = 1;
         }
         pr_default.close(32);
         /* Using cursor BC000Z35 */
         pr_default.execute(33, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A276ColorName, A277ColorCode, A275ColorId});
         if ( (pr_default.getStatus(33) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {context.GetMessage( "Trn_Theme Id", "")+","+context.GetMessage( "Color Name", "")+","+context.GetMessage( "Color Code", "")}), 1, "");
            AnyError = 1;
         }
         pr_default.close(33);
      }

      protected void CloseExtendedTableCursors0Z53( )
      {
      }

      protected void enableDisable0Z53( )
      {
      }

      protected void GetKey0Z53( )
      {
         /* Using cursor BC000Z36 */
         pr_default.execute(34, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A275ColorId});
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound53 = 1;
         }
         else
         {
            RcdFound53 = 0;
         }
         pr_default.close(34);
      }

      protected void getByPrimaryKey0Z53( )
      {
         /* Using cursor BC000Z3 */
         pr_default.execute(1, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A275ColorId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Z53( 16) ;
            RcdFound53 = 1;
            InitializeNonKey0Z53( ) ;
            A275ColorId = BC000Z3_A275ColorId[0];
            A276ColorName = BC000Z3_A276ColorName[0];
            A277ColorCode = BC000Z3_A277ColorCode[0];
            Z273Trn_ThemeId = A273Trn_ThemeId;
            Z275ColorId = A275ColorId;
            sMode53 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0Z53( ) ;
            Load0Z53( ) ;
            Gx_mode = sMode53;
         }
         else
         {
            RcdFound53 = 0;
            InitializeNonKey0Z53( ) ;
            sMode53 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0Z53( ) ;
            Gx_mode = sMode53;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0Z53( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0Z53( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000Z2 */
            pr_default.execute(0, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A275ColorId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeColor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z276ColorName, BC000Z2_A276ColorName[0]) != 0 ) || ( StringUtil.StrCmp(Z277ColorCode, BC000Z2_A277ColorCode[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ThemeColor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Z53( )
      {
         BeforeValidate0Z53( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z53( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Z53( 0) ;
            CheckOptimisticConcurrency0Z53( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z53( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Z53( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Z37 */
                     pr_default.execute(35, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A275ColorId, A276ColorName, A277ColorCode});
                     pr_default.close(35);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
                     if ( (pr_default.getStatus(35) == 1) )
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
               Load0Z53( ) ;
            }
            EndLevel0Z53( ) ;
         }
         CloseExtendedTableCursors0Z53( ) ;
      }

      protected void Update0Z53( )
      {
         BeforeValidate0Z53( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z53( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z53( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z53( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Z53( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Z38 */
                     pr_default.execute(36, new Object[] {A276ColorName, A277ColorCode, n273Trn_ThemeId, A273Trn_ThemeId, A275ColorId});
                     pr_default.close(36);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
                     if ( (pr_default.getStatus(36) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ThemeColor"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Z53( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0Z53( ) ;
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
            EndLevel0Z53( ) ;
         }
         CloseExtendedTableCursors0Z53( ) ;
      }

      protected void DeferredUpdate0Z53( )
      {
      }

      protected void Delete0Z53( )
      {
         Gx_mode = "DLT";
         BeforeValidate0Z53( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z53( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Z53( ) ;
            AfterConfirm0Z53( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Z53( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000Z39 */
                  pr_default.execute(37, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId, A275ColorId});
                  pr_default.close(37);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ThemeColor");
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
         sMode53 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0Z53( ) ;
         Gx_mode = sMode53;
      }

      protected void OnDeleteControls0Z53( )
      {
         standaloneModal0Z53( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0Z53( )
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

      public void ScanKeyStart0Z53( )
      {
         /* Scan By routine */
         /* Using cursor BC000Z40 */
         pr_default.execute(38, new Object[] {n273Trn_ThemeId, A273Trn_ThemeId});
         RcdFound53 = 0;
         if ( (pr_default.getStatus(38) != 101) )
         {
            RcdFound53 = 1;
            A275ColorId = BC000Z40_A275ColorId[0];
            A276ColorName = BC000Z40_A276ColorName[0];
            A277ColorCode = BC000Z40_A277ColorCode[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0Z53( )
      {
         /* Scan next routine */
         pr_default.readNext(38);
         RcdFound53 = 0;
         ScanKeyLoad0Z53( ) ;
      }

      protected void ScanKeyLoad0Z53( )
      {
         sMode53 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(38) != 101) )
         {
            RcdFound53 = 1;
            A275ColorId = BC000Z40_A275ColorId[0];
            A276ColorName = BC000Z40_A276ColorName[0];
            A277ColorCode = BC000Z40_A277ColorCode[0];
         }
         Gx_mode = sMode53;
      }

      protected void ScanKeyEnd0Z53( )
      {
         pr_default.close(38);
      }

      protected void AfterConfirm0Z53( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Z53( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Z53( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Z53( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Z53( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Z53( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Z53( )
      {
      }

      protected void send_integrity_lvl_hashes0Z53( )
      {
      }

      protected void send_integrity_lvl_hashes0Z51( )
      {
      }

      protected void AddRow0Z51( )
      {
         VarsToRow51( bcTrn_Theme) ;
      }

      protected void ReadRow0Z51( )
      {
         RowToVars51( bcTrn_Theme, 1) ;
      }

      protected void AddRow0Z97( )
      {
         SdtTrn_Theme_CtaColor obj97;
         obj97 = new SdtTrn_Theme_CtaColor(context);
         VarsToRow97( obj97) ;
         bcTrn_Theme.gxTpr_Ctacolor.Add(obj97, 0);
         obj97.gxTpr_Mode = "UPD";
         obj97.gxTpr_Modified = 0;
      }

      protected void ReadRow0Z97( )
      {
         nGXsfl_97_idx = (int)(nGXsfl_97_idx+1);
         RowToVars97( ((SdtTrn_Theme_CtaColor)bcTrn_Theme.gxTpr_Ctacolor.Item(nGXsfl_97_idx)), 1) ;
      }

      protected void AddRow0Z82( )
      {
         SdtTrn_Theme_Icon obj82;
         obj82 = new SdtTrn_Theme_Icon(context);
         VarsToRow82( obj82) ;
         bcTrn_Theme.gxTpr_Icon.Add(obj82, 0);
         obj82.gxTpr_Mode = "UPD";
         obj82.gxTpr_Modified = 0;
      }

      protected void ReadRow0Z82( )
      {
         nGXsfl_82_idx = (int)(nGXsfl_82_idx+1);
         RowToVars82( ((SdtTrn_Theme_Icon)bcTrn_Theme.gxTpr_Icon.Item(nGXsfl_82_idx)), 1) ;
      }

      protected void AddRow0Z53( )
      {
         SdtTrn_Theme_Color obj53;
         obj53 = new SdtTrn_Theme_Color(context);
         VarsToRow53( obj53) ;
         bcTrn_Theme.gxTpr_Color.Add(obj53, 0);
         obj53.gxTpr_Mode = "UPD";
         obj53.gxTpr_Modified = 0;
      }

      protected void ReadRow0Z53( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         RowToVars53( ((SdtTrn_Theme_Color)bcTrn_Theme.gxTpr_Color.Item(nGXsfl_53_idx)), 1) ;
      }

      protected void InitializeNonKey0Z51( )
      {
         A274Trn_ThemeName = "";
         A281Trn_ThemeFontFamily = "";
         A405Trn_ThemeFontSize = 0;
         A576ThemeIsPredefined = false;
         Z274Trn_ThemeName = "";
         Z281Trn_ThemeFontFamily = "";
         Z405Trn_ThemeFontSize = 0;
         Z576ThemeIsPredefined = false;
      }

      protected void InitAll0Z51( )
      {
         A273Trn_ThemeId = Guid.NewGuid( );
         n273Trn_ThemeId = false;
         InitializeNonKey0Z51( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A576ThemeIsPredefined = i576ThemeIsPredefined;
      }

      protected void InitializeNonKey0Z97( )
      {
         A539CtaColorName = "";
         A540CtaColorCode = "";
         Z539CtaColorName = "";
         Z540CtaColorCode = "";
      }

      protected void InitAll0Z97( )
      {
         A538CtaColorId = Guid.NewGuid( );
         InitializeNonKey0Z97( ) ;
      }

      protected void StandaloneModalInsert0Z97( )
      {
      }

      protected void InitializeNonKey0Z82( )
      {
         A443IconCategory = "";
         A283IconName = "";
         A284IconSVG = "";
         Z443IconCategory = "";
         Z283IconName = "";
      }

      protected void InitAll0Z82( )
      {
         A282IconId = Guid.NewGuid( );
         InitializeNonKey0Z82( ) ;
      }

      protected void StandaloneModalInsert0Z82( )
      {
      }

      protected void InitializeNonKey0Z53( )
      {
         A276ColorName = "";
         A277ColorCode = "";
         Z276ColorName = "";
         Z277ColorCode = "";
      }

      protected void InitAll0Z53( )
      {
         A275ColorId = Guid.NewGuid( );
         InitializeNonKey0Z53( ) ;
      }

      protected void StandaloneModalInsert0Z53( )
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

      public void VarsToRow51( SdtTrn_Theme obj51 )
      {
         obj51.gxTpr_Mode = Gx_mode;
         obj51.gxTpr_Trn_themename = A274Trn_ThemeName;
         obj51.gxTpr_Trn_themefontfamily = A281Trn_ThemeFontFamily;
         obj51.gxTpr_Trn_themefontsize = A405Trn_ThemeFontSize;
         obj51.gxTpr_Themeispredefined = A576ThemeIsPredefined;
         obj51.gxTpr_Trn_themeid = A273Trn_ThemeId;
         obj51.gxTpr_Trn_themeid_Z = Z273Trn_ThemeId;
         obj51.gxTpr_Trn_themename_Z = Z274Trn_ThemeName;
         obj51.gxTpr_Trn_themefontfamily_Z = Z281Trn_ThemeFontFamily;
         obj51.gxTpr_Trn_themefontsize_Z = Z405Trn_ThemeFontSize;
         obj51.gxTpr_Themeispredefined_Z = Z576ThemeIsPredefined;
         obj51.gxTpr_Trn_themeid_N = (short)(Convert.ToInt16(n273Trn_ThemeId));
         obj51.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow51( SdtTrn_Theme obj51 )
      {
         obj51.gxTpr_Trn_themeid = A273Trn_ThemeId;
         return  ;
      }

      public void RowToVars51( SdtTrn_Theme obj51 ,
                               int forceLoad )
      {
         Gx_mode = obj51.gxTpr_Mode;
         A274Trn_ThemeName = obj51.gxTpr_Trn_themename;
         A281Trn_ThemeFontFamily = obj51.gxTpr_Trn_themefontfamily;
         A405Trn_ThemeFontSize = obj51.gxTpr_Trn_themefontsize;
         A576ThemeIsPredefined = obj51.gxTpr_Themeispredefined;
         A273Trn_ThemeId = obj51.gxTpr_Trn_themeid;
         n273Trn_ThemeId = false;
         Z273Trn_ThemeId = obj51.gxTpr_Trn_themeid_Z;
         Z274Trn_ThemeName = obj51.gxTpr_Trn_themename_Z;
         Z281Trn_ThemeFontFamily = obj51.gxTpr_Trn_themefontfamily_Z;
         Z405Trn_ThemeFontSize = obj51.gxTpr_Trn_themefontsize_Z;
         Z576ThemeIsPredefined = obj51.gxTpr_Themeispredefined_Z;
         n273Trn_ThemeId = (bool)(Convert.ToBoolean(obj51.gxTpr_Trn_themeid_N));
         Gx_mode = obj51.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow97( SdtTrn_Theme_CtaColor obj97 )
      {
         obj97.gxTpr_Mode = Gx_mode;
         obj97.gxTpr_Ctacolorname = A539CtaColorName;
         obj97.gxTpr_Ctacolorcode = A540CtaColorCode;
         obj97.gxTpr_Ctacolorid = A538CtaColorId;
         obj97.gxTpr_Ctacolorid_Z = Z538CtaColorId;
         obj97.gxTpr_Ctacolorname_Z = Z539CtaColorName;
         obj97.gxTpr_Ctacolorcode_Z = Z540CtaColorCode;
         obj97.gxTpr_Modified = nIsMod_97;
         return  ;
      }

      public void KeyVarsToRow97( SdtTrn_Theme_CtaColor obj97 )
      {
         obj97.gxTpr_Ctacolorid = A538CtaColorId;
         return  ;
      }

      public void RowToVars97( SdtTrn_Theme_CtaColor obj97 ,
                               int forceLoad )
      {
         Gx_mode = obj97.gxTpr_Mode;
         A539CtaColorName = obj97.gxTpr_Ctacolorname;
         A540CtaColorCode = obj97.gxTpr_Ctacolorcode;
         A538CtaColorId = obj97.gxTpr_Ctacolorid;
         Z538CtaColorId = obj97.gxTpr_Ctacolorid_Z;
         Z539CtaColorName = obj97.gxTpr_Ctacolorname_Z;
         Z540CtaColorCode = obj97.gxTpr_Ctacolorcode_Z;
         nIsMod_97 = obj97.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow82( SdtTrn_Theme_Icon obj82 )
      {
         obj82.gxTpr_Mode = Gx_mode;
         obj82.gxTpr_Iconcategory = A443IconCategory;
         obj82.gxTpr_Iconname = A283IconName;
         obj82.gxTpr_Iconsvg = A284IconSVG;
         obj82.gxTpr_Iconid = A282IconId;
         obj82.gxTpr_Iconid_Z = Z282IconId;
         obj82.gxTpr_Iconcategory_Z = Z443IconCategory;
         obj82.gxTpr_Iconname_Z = Z283IconName;
         obj82.gxTpr_Modified = nIsMod_82;
         return  ;
      }

      public void KeyVarsToRow82( SdtTrn_Theme_Icon obj82 )
      {
         obj82.gxTpr_Iconid = A282IconId;
         return  ;
      }

      public void RowToVars82( SdtTrn_Theme_Icon obj82 ,
                               int forceLoad )
      {
         Gx_mode = obj82.gxTpr_Mode;
         A443IconCategory = obj82.gxTpr_Iconcategory;
         A283IconName = obj82.gxTpr_Iconname;
         A284IconSVG = obj82.gxTpr_Iconsvg;
         A282IconId = obj82.gxTpr_Iconid;
         Z282IconId = obj82.gxTpr_Iconid_Z;
         Z443IconCategory = obj82.gxTpr_Iconcategory_Z;
         Z283IconName = obj82.gxTpr_Iconname_Z;
         nIsMod_82 = obj82.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow53( SdtTrn_Theme_Color obj53 )
      {
         obj53.gxTpr_Mode = Gx_mode;
         obj53.gxTpr_Colorname = A276ColorName;
         obj53.gxTpr_Colorcode = A277ColorCode;
         obj53.gxTpr_Colorid = A275ColorId;
         obj53.gxTpr_Colorid_Z = Z275ColorId;
         obj53.gxTpr_Colorname_Z = Z276ColorName;
         obj53.gxTpr_Colorcode_Z = Z277ColorCode;
         obj53.gxTpr_Modified = nIsMod_53;
         return  ;
      }

      public void KeyVarsToRow53( SdtTrn_Theme_Color obj53 )
      {
         obj53.gxTpr_Colorid = A275ColorId;
         return  ;
      }

      public void RowToVars53( SdtTrn_Theme_Color obj53 ,
                               int forceLoad )
      {
         Gx_mode = obj53.gxTpr_Mode;
         A276ColorName = obj53.gxTpr_Colorname;
         A277ColorCode = obj53.gxTpr_Colorcode;
         A275ColorId = obj53.gxTpr_Colorid;
         Z275ColorId = obj53.gxTpr_Colorid_Z;
         Z276ColorName = obj53.gxTpr_Colorname_Z;
         Z277ColorCode = obj53.gxTpr_Colorcode_Z;
         nIsMod_53 = obj53.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A273Trn_ThemeId = (Guid)getParm(obj,0);
         n273Trn_ThemeId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0Z51( ) ;
         ScanKeyStart0Z51( ) ;
         if ( RcdFound51 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z273Trn_ThemeId = A273Trn_ThemeId;
         }
         ZM0Z51( -11) ;
         OnLoadActions0Z51( ) ;
         AddRow0Z51( ) ;
         bcTrn_Theme.gxTpr_Ctacolor.ClearCollection();
         if ( RcdFound51 == 1 )
         {
            ScanKeyStart0Z97( ) ;
            nGXsfl_97_idx = 1;
            while ( RcdFound97 != 0 )
            {
               Z273Trn_ThemeId = A273Trn_ThemeId;
               Z538CtaColorId = A538CtaColorId;
               ZM0Z97( -12) ;
               OnLoadActions0Z97( ) ;
               nRcdExists_97 = 1;
               nIsMod_97 = 0;
               AddRow0Z97( ) ;
               nGXsfl_97_idx = (int)(nGXsfl_97_idx+1);
               ScanKeyNext0Z97( ) ;
            }
            ScanKeyEnd0Z97( ) ;
         }
         bcTrn_Theme.gxTpr_Icon.ClearCollection();
         if ( RcdFound51 == 1 )
         {
            ScanKeyStart0Z82( ) ;
            nGXsfl_82_idx = 1;
            while ( RcdFound82 != 0 )
            {
               Z273Trn_ThemeId = A273Trn_ThemeId;
               Z282IconId = A282IconId;
               ZM0Z82( -14) ;
               OnLoadActions0Z82( ) ;
               nRcdExists_82 = 1;
               nIsMod_82 = 0;
               AddRow0Z82( ) ;
               nGXsfl_82_idx = (int)(nGXsfl_82_idx+1);
               ScanKeyNext0Z82( ) ;
            }
            ScanKeyEnd0Z82( ) ;
         }
         bcTrn_Theme.gxTpr_Color.ClearCollection();
         if ( RcdFound51 == 1 )
         {
            ScanKeyStart0Z53( ) ;
            nGXsfl_53_idx = 1;
            while ( RcdFound53 != 0 )
            {
               Z273Trn_ThemeId = A273Trn_ThemeId;
               Z275ColorId = A275ColorId;
               ZM0Z53( -16) ;
               OnLoadActions0Z53( ) ;
               nRcdExists_53 = 1;
               nIsMod_53 = 0;
               AddRow0Z53( ) ;
               nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
               ScanKeyNext0Z53( ) ;
            }
            ScanKeyEnd0Z53( ) ;
         }
         ScanKeyEnd0Z51( ) ;
         if ( RcdFound51 == 0 )
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
         RowToVars51( bcTrn_Theme, 0) ;
         ScanKeyStart0Z51( ) ;
         if ( RcdFound51 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z273Trn_ThemeId = A273Trn_ThemeId;
         }
         ZM0Z51( -11) ;
         OnLoadActions0Z51( ) ;
         AddRow0Z51( ) ;
         bcTrn_Theme.gxTpr_Ctacolor.ClearCollection();
         if ( RcdFound51 == 1 )
         {
            ScanKeyStart0Z97( ) ;
            nGXsfl_97_idx = 1;
            while ( RcdFound97 != 0 )
            {
               Z273Trn_ThemeId = A273Trn_ThemeId;
               Z538CtaColorId = A538CtaColorId;
               ZM0Z97( -12) ;
               OnLoadActions0Z97( ) ;
               nRcdExists_97 = 1;
               nIsMod_97 = 0;
               AddRow0Z97( ) ;
               nGXsfl_97_idx = (int)(nGXsfl_97_idx+1);
               ScanKeyNext0Z97( ) ;
            }
            ScanKeyEnd0Z97( ) ;
         }
         bcTrn_Theme.gxTpr_Icon.ClearCollection();
         if ( RcdFound51 == 1 )
         {
            ScanKeyStart0Z82( ) ;
            nGXsfl_82_idx = 1;
            while ( RcdFound82 != 0 )
            {
               Z273Trn_ThemeId = A273Trn_ThemeId;
               Z282IconId = A282IconId;
               ZM0Z82( -14) ;
               OnLoadActions0Z82( ) ;
               nRcdExists_82 = 1;
               nIsMod_82 = 0;
               AddRow0Z82( ) ;
               nGXsfl_82_idx = (int)(nGXsfl_82_idx+1);
               ScanKeyNext0Z82( ) ;
            }
            ScanKeyEnd0Z82( ) ;
         }
         bcTrn_Theme.gxTpr_Color.ClearCollection();
         if ( RcdFound51 == 1 )
         {
            ScanKeyStart0Z53( ) ;
            nGXsfl_53_idx = 1;
            while ( RcdFound53 != 0 )
            {
               Z273Trn_ThemeId = A273Trn_ThemeId;
               Z275ColorId = A275ColorId;
               ZM0Z53( -16) ;
               OnLoadActions0Z53( ) ;
               nRcdExists_53 = 1;
               nIsMod_53 = 0;
               AddRow0Z53( ) ;
               nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
               ScanKeyNext0Z53( ) ;
            }
            ScanKeyEnd0Z53( ) ;
         }
         ScanKeyEnd0Z51( ) ;
         if ( RcdFound51 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0Z51( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0Z51( ) ;
         }
         else
         {
            if ( RcdFound51 == 1 )
            {
               if ( A273Trn_ThemeId != Z273Trn_ThemeId )
               {
                  A273Trn_ThemeId = Z273Trn_ThemeId;
                  n273Trn_ThemeId = false;
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
                  Update0Z51( ) ;
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
                  if ( A273Trn_ThemeId != Z273Trn_ThemeId )
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
                        Insert0Z51( ) ;
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
                        Insert0Z51( ) ;
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
         RowToVars51( bcTrn_Theme, 1) ;
         SaveImpl( ) ;
         VarsToRow51( bcTrn_Theme) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars51( bcTrn_Theme, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0Z51( ) ;
         AfterTrn( ) ;
         VarsToRow51( bcTrn_Theme) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow51( bcTrn_Theme) ;
         }
         else
         {
            SdtTrn_Theme auxBC = new SdtTrn_Theme(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A273Trn_ThemeId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Theme);
               auxBC.Save();
               bcTrn_Theme.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars51( bcTrn_Theme, 1) ;
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
         RowToVars51( bcTrn_Theme, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0Z51( ) ;
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
               VarsToRow51( bcTrn_Theme) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow51( bcTrn_Theme) ;
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
         RowToVars51( bcTrn_Theme, 0) ;
         GetKey0Z51( ) ;
         if ( RcdFound51 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A273Trn_ThemeId != Z273Trn_ThemeId )
            {
               A273Trn_ThemeId = Z273Trn_ThemeId;
               n273Trn_ThemeId = false;
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
            if ( A273Trn_ThemeId != Z273Trn_ThemeId )
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
         context.RollbackDataStores("trn_theme_bc",pr_default);
         VarsToRow51( bcTrn_Theme) ;
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
         Gx_mode = bcTrn_Theme.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Theme.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Theme )
         {
            bcTrn_Theme = (SdtTrn_Theme)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Theme.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Theme.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow51( bcTrn_Theme) ;
            }
            else
            {
               RowToVars51( bcTrn_Theme, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Theme.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Theme.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars51( bcTrn_Theme, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Theme Trn_Theme_BC
      {
         get {
            return bcTrn_Theme ;
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
            return "trn_theme_Execute" ;
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
         pr_default.close(5);
         pr_default.close(7);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z273Trn_ThemeId = Guid.Empty;
         A273Trn_ThemeId = Guid.Empty;
         sMode51 = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z274Trn_ThemeName = "";
         A274Trn_ThemeName = "";
         Z281Trn_ThemeFontFamily = "";
         A281Trn_ThemeFontFamily = "";
         BC000Z10_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z10_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z10_A274Trn_ThemeName = new string[] {""} ;
         BC000Z10_A281Trn_ThemeFontFamily = new string[] {""} ;
         BC000Z10_A405Trn_ThemeFontSize = new short[1] ;
         BC000Z10_A576ThemeIsPredefined = new bool[] {false} ;
         BC000Z11_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z11_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z9_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z9_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z9_A274Trn_ThemeName = new string[] {""} ;
         BC000Z9_A281Trn_ThemeFontFamily = new string[] {""} ;
         BC000Z9_A405Trn_ThemeFontSize = new short[1] ;
         BC000Z9_A576ThemeIsPredefined = new bool[] {false} ;
         BC000Z8_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z8_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z8_A274Trn_ThemeName = new string[] {""} ;
         BC000Z8_A281Trn_ThemeFontFamily = new string[] {""} ;
         BC000Z8_A405Trn_ThemeFontSize = new short[1] ;
         BC000Z8_A576ThemeIsPredefined = new bool[] {false} ;
         BC000Z15_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000Z15_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000Z16_A523AppVersionId = new Guid[] {Guid.Empty} ;
         BC000Z17_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         BC000Z17_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000Z18_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z18_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z18_A274Trn_ThemeName = new string[] {""} ;
         BC000Z18_A281Trn_ThemeFontFamily = new string[] {""} ;
         BC000Z18_A405Trn_ThemeFontSize = new short[1] ;
         BC000Z18_A576ThemeIsPredefined = new bool[] {false} ;
         Z539CtaColorName = "";
         A539CtaColorName = "";
         Z540CtaColorCode = "";
         A540CtaColorCode = "";
         Z538CtaColorId = Guid.Empty;
         A538CtaColorId = Guid.Empty;
         BC000Z19_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z19_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z19_A538CtaColorId = new Guid[] {Guid.Empty} ;
         BC000Z19_A539CtaColorName = new string[] {""} ;
         BC000Z19_A540CtaColorCode = new string[] {""} ;
         BC000Z20_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z20_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z21_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z21_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z21_A538CtaColorId = new Guid[] {Guid.Empty} ;
         BC000Z7_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z7_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z7_A538CtaColorId = new Guid[] {Guid.Empty} ;
         BC000Z7_A539CtaColorName = new string[] {""} ;
         BC000Z7_A540CtaColorCode = new string[] {""} ;
         sMode97 = "";
         BC000Z6_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z6_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z6_A538CtaColorId = new Guid[] {Guid.Empty} ;
         BC000Z6_A539CtaColorName = new string[] {""} ;
         BC000Z6_A540CtaColorCode = new string[] {""} ;
         BC000Z25_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z25_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z25_A538CtaColorId = new Guid[] {Guid.Empty} ;
         BC000Z25_A539CtaColorName = new string[] {""} ;
         BC000Z25_A540CtaColorCode = new string[] {""} ;
         Z443IconCategory = "";
         A443IconCategory = "";
         Z283IconName = "";
         A283IconName = "";
         Z282IconId = Guid.Empty;
         A282IconId = Guid.Empty;
         Z284IconSVG = "";
         A284IconSVG = "";
         BC000Z26_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z26_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z26_A282IconId = new Guid[] {Guid.Empty} ;
         BC000Z26_A443IconCategory = new string[] {""} ;
         BC000Z26_A283IconName = new string[] {""} ;
         BC000Z26_A284IconSVG = new string[] {""} ;
         BC000Z27_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z27_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z28_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z28_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z28_A282IconId = new Guid[] {Guid.Empty} ;
         BC000Z5_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z5_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z5_A282IconId = new Guid[] {Guid.Empty} ;
         BC000Z5_A443IconCategory = new string[] {""} ;
         BC000Z5_A283IconName = new string[] {""} ;
         BC000Z5_A284IconSVG = new string[] {""} ;
         sMode82 = "";
         BC000Z4_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z4_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z4_A282IconId = new Guid[] {Guid.Empty} ;
         BC000Z4_A443IconCategory = new string[] {""} ;
         BC000Z4_A283IconName = new string[] {""} ;
         BC000Z4_A284IconSVG = new string[] {""} ;
         BC000Z32_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z32_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z32_A282IconId = new Guid[] {Guid.Empty} ;
         BC000Z32_A443IconCategory = new string[] {""} ;
         BC000Z32_A283IconName = new string[] {""} ;
         BC000Z32_A284IconSVG = new string[] {""} ;
         Z276ColorName = "";
         A276ColorName = "";
         Z277ColorCode = "";
         A277ColorCode = "";
         Z275ColorId = Guid.Empty;
         A275ColorId = Guid.Empty;
         BC000Z33_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z33_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z33_A275ColorId = new Guid[] {Guid.Empty} ;
         BC000Z33_A276ColorName = new string[] {""} ;
         BC000Z33_A277ColorCode = new string[] {""} ;
         BC000Z34_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z34_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z35_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z35_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z36_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z36_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z36_A275ColorId = new Guid[] {Guid.Empty} ;
         BC000Z3_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z3_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z3_A275ColorId = new Guid[] {Guid.Empty} ;
         BC000Z3_A276ColorName = new string[] {""} ;
         BC000Z3_A277ColorCode = new string[] {""} ;
         sMode53 = "";
         BC000Z2_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z2_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z2_A275ColorId = new Guid[] {Guid.Empty} ;
         BC000Z2_A276ColorName = new string[] {""} ;
         BC000Z2_A277ColorCode = new string[] {""} ;
         BC000Z40_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         BC000Z40_n273Trn_ThemeId = new bool[] {false} ;
         BC000Z40_A275ColorId = new Guid[] {Guid.Empty} ;
         BC000Z40_A276ColorName = new string[] {""} ;
         BC000Z40_A277ColorCode = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_theme_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_theme_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_theme_bc__default(),
            new Object[][] {
                new Object[] {
               BC000Z2_A273Trn_ThemeId, BC000Z2_A275ColorId, BC000Z2_A276ColorName, BC000Z2_A277ColorCode
               }
               , new Object[] {
               BC000Z3_A273Trn_ThemeId, BC000Z3_A275ColorId, BC000Z3_A276ColorName, BC000Z3_A277ColorCode
               }
               , new Object[] {
               BC000Z4_A273Trn_ThemeId, BC000Z4_A282IconId, BC000Z4_A443IconCategory, BC000Z4_A283IconName, BC000Z4_A284IconSVG
               }
               , new Object[] {
               BC000Z5_A273Trn_ThemeId, BC000Z5_A282IconId, BC000Z5_A443IconCategory, BC000Z5_A283IconName, BC000Z5_A284IconSVG
               }
               , new Object[] {
               BC000Z6_A273Trn_ThemeId, BC000Z6_A538CtaColorId, BC000Z6_A539CtaColorName, BC000Z6_A540CtaColorCode
               }
               , new Object[] {
               BC000Z7_A273Trn_ThemeId, BC000Z7_A538CtaColorId, BC000Z7_A539CtaColorName, BC000Z7_A540CtaColorCode
               }
               , new Object[] {
               BC000Z8_A273Trn_ThemeId, BC000Z8_A274Trn_ThemeName, BC000Z8_A281Trn_ThemeFontFamily, BC000Z8_A405Trn_ThemeFontSize, BC000Z8_A576ThemeIsPredefined
               }
               , new Object[] {
               BC000Z9_A273Trn_ThemeId, BC000Z9_A274Trn_ThemeName, BC000Z9_A281Trn_ThemeFontFamily, BC000Z9_A405Trn_ThemeFontSize, BC000Z9_A576ThemeIsPredefined
               }
               , new Object[] {
               BC000Z10_A273Trn_ThemeId, BC000Z10_A274Trn_ThemeName, BC000Z10_A281Trn_ThemeFontFamily, BC000Z10_A405Trn_ThemeFontSize, BC000Z10_A576ThemeIsPredefined
               }
               , new Object[] {
               BC000Z11_A273Trn_ThemeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Z15_A29LocationId, BC000Z15_A11OrganisationId
               }
               , new Object[] {
               BC000Z16_A523AppVersionId
               }
               , new Object[] {
               BC000Z17_A100OrganisationSettingid, BC000Z17_A11OrganisationId
               }
               , new Object[] {
               BC000Z18_A273Trn_ThemeId, BC000Z18_A274Trn_ThemeName, BC000Z18_A281Trn_ThemeFontFamily, BC000Z18_A405Trn_ThemeFontSize, BC000Z18_A576ThemeIsPredefined
               }
               , new Object[] {
               BC000Z19_A273Trn_ThemeId, BC000Z19_A538CtaColorId, BC000Z19_A539CtaColorName, BC000Z19_A540CtaColorCode
               }
               , new Object[] {
               BC000Z20_A273Trn_ThemeId
               }
               , new Object[] {
               BC000Z21_A273Trn_ThemeId, BC000Z21_A538CtaColorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Z25_A273Trn_ThemeId, BC000Z25_A538CtaColorId, BC000Z25_A539CtaColorName, BC000Z25_A540CtaColorCode
               }
               , new Object[] {
               BC000Z26_A273Trn_ThemeId, BC000Z26_A282IconId, BC000Z26_A443IconCategory, BC000Z26_A283IconName, BC000Z26_A284IconSVG
               }
               , new Object[] {
               BC000Z27_A273Trn_ThemeId
               }
               , new Object[] {
               BC000Z28_A273Trn_ThemeId, BC000Z28_A282IconId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Z32_A273Trn_ThemeId, BC000Z32_A282IconId, BC000Z32_A443IconCategory, BC000Z32_A283IconName, BC000Z32_A284IconSVG
               }
               , new Object[] {
               BC000Z33_A273Trn_ThemeId, BC000Z33_A275ColorId, BC000Z33_A276ColorName, BC000Z33_A277ColorCode
               }
               , new Object[] {
               BC000Z34_A273Trn_ThemeId
               }
               , new Object[] {
               BC000Z35_A273Trn_ThemeId
               }
               , new Object[] {
               BC000Z36_A273Trn_ThemeId, BC000Z36_A275ColorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Z40_A273Trn_ThemeId, BC000Z40_A275ColorId, BC000Z40_A276ColorName, BC000Z40_A277ColorCode
               }
            }
         );
         Z275ColorId = Guid.NewGuid( );
         A275ColorId = Guid.NewGuid( );
         Z282IconId = Guid.NewGuid( );
         A282IconId = Guid.NewGuid( );
         Z538CtaColorId = Guid.NewGuid( );
         A538CtaColorId = Guid.NewGuid( );
         Z273Trn_ThemeId = Guid.NewGuid( );
         n273Trn_ThemeId = false;
         A273Trn_ThemeId = Guid.NewGuid( );
         n273Trn_ThemeId = false;
         Z576ThemeIsPredefined = false;
         A576ThemeIsPredefined = false;
         i576ThemeIsPredefined = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120Z2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short nIsMod_53 ;
      private short RcdFound53 ;
      private short nIsMod_82 ;
      private short RcdFound82 ;
      private short nIsMod_97 ;
      private short RcdFound97 ;
      private short Z405Trn_ThemeFontSize ;
      private short A405Trn_ThemeFontSize ;
      private short Gx_BScreen ;
      private short RcdFound51 ;
      private short nRcdExists_97 ;
      private short nRcdExists_82 ;
      private short nRcdExists_53 ;
      private short Gxremove97 ;
      private short Gxremove82 ;
      private short Gxremove53 ;
      private int trnEnded ;
      private int nGXsfl_53_idx=1 ;
      private int nGXsfl_82_idx=1 ;
      private int nGXsfl_97_idx=1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode51 ;
      private string sMode97 ;
      private string sMode82 ;
      private string sMode53 ;
      private bool returnInSub ;
      private bool Z576ThemeIsPredefined ;
      private bool A576ThemeIsPredefined ;
      private bool n273Trn_ThemeId ;
      private bool i576ThemeIsPredefined ;
      private string Z284IconSVG ;
      private string A284IconSVG ;
      private string Z274Trn_ThemeName ;
      private string A274Trn_ThemeName ;
      private string Z281Trn_ThemeFontFamily ;
      private string A281Trn_ThemeFontFamily ;
      private string Z539CtaColorName ;
      private string A539CtaColorName ;
      private string Z540CtaColorCode ;
      private string A540CtaColorCode ;
      private string Z443IconCategory ;
      private string A443IconCategory ;
      private string Z283IconName ;
      private string A283IconName ;
      private string Z276ColorName ;
      private string A276ColorName ;
      private string Z277ColorCode ;
      private string A277ColorCode ;
      private Guid Z273Trn_ThemeId ;
      private Guid A273Trn_ThemeId ;
      private Guid Z538CtaColorId ;
      private Guid A538CtaColorId ;
      private Guid Z282IconId ;
      private Guid A282IconId ;
      private Guid Z275ColorId ;
      private Guid A275ColorId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtTrn_Theme bcTrn_Theme ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC000Z10_A273Trn_ThemeId ;
      private bool[] BC000Z10_n273Trn_ThemeId ;
      private string[] BC000Z10_A274Trn_ThemeName ;
      private string[] BC000Z10_A281Trn_ThemeFontFamily ;
      private short[] BC000Z10_A405Trn_ThemeFontSize ;
      private bool[] BC000Z10_A576ThemeIsPredefined ;
      private Guid[] BC000Z11_A273Trn_ThemeId ;
      private bool[] BC000Z11_n273Trn_ThemeId ;
      private Guid[] BC000Z9_A273Trn_ThemeId ;
      private bool[] BC000Z9_n273Trn_ThemeId ;
      private string[] BC000Z9_A274Trn_ThemeName ;
      private string[] BC000Z9_A281Trn_ThemeFontFamily ;
      private short[] BC000Z9_A405Trn_ThemeFontSize ;
      private bool[] BC000Z9_A576ThemeIsPredefined ;
      private Guid[] BC000Z8_A273Trn_ThemeId ;
      private bool[] BC000Z8_n273Trn_ThemeId ;
      private string[] BC000Z8_A274Trn_ThemeName ;
      private string[] BC000Z8_A281Trn_ThemeFontFamily ;
      private short[] BC000Z8_A405Trn_ThemeFontSize ;
      private bool[] BC000Z8_A576ThemeIsPredefined ;
      private Guid[] BC000Z15_A29LocationId ;
      private Guid[] BC000Z15_A11OrganisationId ;
      private Guid[] BC000Z16_A523AppVersionId ;
      private Guid[] BC000Z17_A100OrganisationSettingid ;
      private Guid[] BC000Z17_A11OrganisationId ;
      private Guid[] BC000Z18_A273Trn_ThemeId ;
      private bool[] BC000Z18_n273Trn_ThemeId ;
      private string[] BC000Z18_A274Trn_ThemeName ;
      private string[] BC000Z18_A281Trn_ThemeFontFamily ;
      private short[] BC000Z18_A405Trn_ThemeFontSize ;
      private bool[] BC000Z18_A576ThemeIsPredefined ;
      private Guid[] BC000Z19_A273Trn_ThemeId ;
      private bool[] BC000Z19_n273Trn_ThemeId ;
      private Guid[] BC000Z19_A538CtaColorId ;
      private string[] BC000Z19_A539CtaColorName ;
      private string[] BC000Z19_A540CtaColorCode ;
      private Guid[] BC000Z20_A273Trn_ThemeId ;
      private bool[] BC000Z20_n273Trn_ThemeId ;
      private Guid[] BC000Z21_A273Trn_ThemeId ;
      private bool[] BC000Z21_n273Trn_ThemeId ;
      private Guid[] BC000Z21_A538CtaColorId ;
      private Guid[] BC000Z7_A273Trn_ThemeId ;
      private bool[] BC000Z7_n273Trn_ThemeId ;
      private Guid[] BC000Z7_A538CtaColorId ;
      private string[] BC000Z7_A539CtaColorName ;
      private string[] BC000Z7_A540CtaColorCode ;
      private Guid[] BC000Z6_A273Trn_ThemeId ;
      private bool[] BC000Z6_n273Trn_ThemeId ;
      private Guid[] BC000Z6_A538CtaColorId ;
      private string[] BC000Z6_A539CtaColorName ;
      private string[] BC000Z6_A540CtaColorCode ;
      private Guid[] BC000Z25_A273Trn_ThemeId ;
      private bool[] BC000Z25_n273Trn_ThemeId ;
      private Guid[] BC000Z25_A538CtaColorId ;
      private string[] BC000Z25_A539CtaColorName ;
      private string[] BC000Z25_A540CtaColorCode ;
      private Guid[] BC000Z26_A273Trn_ThemeId ;
      private bool[] BC000Z26_n273Trn_ThemeId ;
      private Guid[] BC000Z26_A282IconId ;
      private string[] BC000Z26_A443IconCategory ;
      private string[] BC000Z26_A283IconName ;
      private string[] BC000Z26_A284IconSVG ;
      private Guid[] BC000Z27_A273Trn_ThemeId ;
      private bool[] BC000Z27_n273Trn_ThemeId ;
      private Guid[] BC000Z28_A273Trn_ThemeId ;
      private bool[] BC000Z28_n273Trn_ThemeId ;
      private Guid[] BC000Z28_A282IconId ;
      private Guid[] BC000Z5_A273Trn_ThemeId ;
      private bool[] BC000Z5_n273Trn_ThemeId ;
      private Guid[] BC000Z5_A282IconId ;
      private string[] BC000Z5_A443IconCategory ;
      private string[] BC000Z5_A283IconName ;
      private string[] BC000Z5_A284IconSVG ;
      private Guid[] BC000Z4_A273Trn_ThemeId ;
      private bool[] BC000Z4_n273Trn_ThemeId ;
      private Guid[] BC000Z4_A282IconId ;
      private string[] BC000Z4_A443IconCategory ;
      private string[] BC000Z4_A283IconName ;
      private string[] BC000Z4_A284IconSVG ;
      private Guid[] BC000Z32_A273Trn_ThemeId ;
      private bool[] BC000Z32_n273Trn_ThemeId ;
      private Guid[] BC000Z32_A282IconId ;
      private string[] BC000Z32_A443IconCategory ;
      private string[] BC000Z32_A283IconName ;
      private string[] BC000Z32_A284IconSVG ;
      private Guid[] BC000Z33_A273Trn_ThemeId ;
      private bool[] BC000Z33_n273Trn_ThemeId ;
      private Guid[] BC000Z33_A275ColorId ;
      private string[] BC000Z33_A276ColorName ;
      private string[] BC000Z33_A277ColorCode ;
      private Guid[] BC000Z34_A273Trn_ThemeId ;
      private bool[] BC000Z34_n273Trn_ThemeId ;
      private Guid[] BC000Z35_A273Trn_ThemeId ;
      private bool[] BC000Z35_n273Trn_ThemeId ;
      private Guid[] BC000Z36_A273Trn_ThemeId ;
      private bool[] BC000Z36_n273Trn_ThemeId ;
      private Guid[] BC000Z36_A275ColorId ;
      private Guid[] BC000Z3_A273Trn_ThemeId ;
      private bool[] BC000Z3_n273Trn_ThemeId ;
      private Guid[] BC000Z3_A275ColorId ;
      private string[] BC000Z3_A276ColorName ;
      private string[] BC000Z3_A277ColorCode ;
      private Guid[] BC000Z2_A273Trn_ThemeId ;
      private bool[] BC000Z2_n273Trn_ThemeId ;
      private Guid[] BC000Z2_A275ColorId ;
      private string[] BC000Z2_A276ColorName ;
      private string[] BC000Z2_A277ColorCode ;
      private Guid[] BC000Z40_A273Trn_ThemeId ;
      private bool[] BC000Z40_n273Trn_ThemeId ;
      private Guid[] BC000Z40_A275ColorId ;
      private string[] BC000Z40_A276ColorName ;
      private string[] BC000Z40_A277ColorCode ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_theme_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_theme_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_theme_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[7])
      ,new ForEachCursor(def[8])
      ,new ForEachCursor(def[9])
      ,new UpdateCursor(def[10])
      ,new UpdateCursor(def[11])
      ,new UpdateCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
      ,new ForEachCursor(def[16])
      ,new ForEachCursor(def[17])
      ,new ForEachCursor(def[18])
      ,new ForEachCursor(def[19])
      ,new UpdateCursor(def[20])
      ,new UpdateCursor(def[21])
      ,new UpdateCursor(def[22])
      ,new ForEachCursor(def[23])
      ,new ForEachCursor(def[24])
      ,new ForEachCursor(def[25])
      ,new ForEachCursor(def[26])
      ,new UpdateCursor(def[27])
      ,new UpdateCursor(def[28])
      ,new UpdateCursor(def[29])
      ,new ForEachCursor(def[30])
      ,new ForEachCursor(def[31])
      ,new ForEachCursor(def[32])
      ,new ForEachCursor(def[33])
      ,new ForEachCursor(def[34])
      ,new UpdateCursor(def[35])
      ,new UpdateCursor(def[36])
      ,new UpdateCursor(def[37])
      ,new ForEachCursor(def[38])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000Z2;
       prmBC000Z2 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Z3;
       prmBC000Z3 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Z4;
       prmBC000Z4 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Z5;
       prmBC000Z5 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Z6;
       prmBC000Z6 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Z7;
       prmBC000Z7 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Z8;
       prmBC000Z8 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000Z9;
       prmBC000Z9 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000Z10;
       prmBC000Z10 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000Z11;
       prmBC000Z11 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000Z12;
       prmBC000Z12 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("Trn_ThemeName",GXType.VarChar,100,0) ,
       new ParDef("Trn_ThemeFontFamily",GXType.VarChar,40,0) ,
       new ParDef("Trn_ThemeFontSize",GXType.Int16,4,0) ,
       new ParDef("ThemeIsPredefined",GXType.Boolean,4,0)
       };
       Object[] prmBC000Z13;
       prmBC000Z13 = new Object[] {
       new ParDef("Trn_ThemeName",GXType.VarChar,100,0) ,
       new ParDef("Trn_ThemeFontFamily",GXType.VarChar,40,0) ,
       new ParDef("Trn_ThemeFontSize",GXType.Int16,4,0) ,
       new ParDef("ThemeIsPredefined",GXType.Boolean,4,0) ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000Z14;
       prmBC000Z14 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000Z15;
       prmBC000Z15 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000Z16;
       prmBC000Z16 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000Z17;
       prmBC000Z17 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000Z18;
       prmBC000Z18 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000Z19;
       prmBC000Z19 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Z20;
       prmBC000Z20 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorName",GXType.VarChar,100,0) ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Z21;
       prmBC000Z21 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Z22;
       prmBC000Z22 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CtaColorName",GXType.VarChar,100,0) ,
       new ParDef("CtaColorCode",GXType.VarChar,100,0)
       };
       Object[] prmBC000Z23;
       prmBC000Z23 = new Object[] {
       new ParDef("CtaColorName",GXType.VarChar,100,0) ,
       new ParDef("CtaColorCode",GXType.VarChar,100,0) ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Z24;
       prmBC000Z24 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("CtaColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Z25;
       prmBC000Z25 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000Z26;
       prmBC000Z26 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Z27;
       prmBC000Z27 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconName",GXType.VarChar,100,0) ,
       new ParDef("IconCategory",GXType.VarChar,40,0) ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Z28;
       prmBC000Z28 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Z29;
       prmBC000Z29 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("IconCategory",GXType.VarChar,40,0) ,
       new ParDef("IconName",GXType.VarChar,100,0) ,
       new ParDef("IconSVG",GXType.LongVarChar,2097152,0)
       };
       Object[] prmBC000Z30;
       prmBC000Z30 = new Object[] {
       new ParDef("IconCategory",GXType.VarChar,40,0) ,
       new ParDef("IconName",GXType.VarChar,100,0) ,
       new ParDef("IconSVG",GXType.LongVarChar,2097152,0) ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Z31;
       prmBC000Z31 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("IconId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Z32;
       prmBC000Z32 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000Z33;
       prmBC000Z33 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Z34;
       prmBC000Z34 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Z35;
       prmBC000Z35 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorCode",GXType.VarChar,100,0) ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Z36;
       prmBC000Z36 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Z37;
       prmBC000Z37 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorCode",GXType.VarChar,100,0)
       };
       Object[] prmBC000Z38;
       prmBC000Z38 = new Object[] {
       new ParDef("ColorName",GXType.VarChar,100,0) ,
       new ParDef("ColorCode",GXType.VarChar,100,0) ,
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Z39;
       prmBC000Z39 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ColorId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000Z40;
       prmBC000Z40 = new Object[] {
       new ParDef("Trn_ThemeId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       def= new CursorDef[] {
           new CursorDef("BC000Z2", "SELECT Trn_ThemeId, ColorId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId  FOR UPDATE OF Trn_ThemeColor",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z3", "SELECT Trn_ThemeId, ColorId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z4", "SELECT Trn_ThemeId, IconId, IconCategory, IconName, IconSVG FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId  FOR UPDATE OF Trn_ThemeIcon",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z5", "SELECT Trn_ThemeId, IconId, IconCategory, IconName, IconSVG FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z6", "SELECT Trn_ThemeId, CtaColorId, CtaColorName, CtaColorCode FROM Trn_ThemeCtaColor WHERE Trn_ThemeId = :Trn_ThemeId AND CtaColorId = :CtaColorId  FOR UPDATE OF Trn_ThemeCtaColor",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z7", "SELECT Trn_ThemeId, CtaColorId, CtaColorName, CtaColorCode FROM Trn_ThemeCtaColor WHERE Trn_ThemeId = :Trn_ThemeId AND CtaColorId = :CtaColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z8", "SELECT Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily, Trn_ThemeFontSize, ThemeIsPredefined FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId  FOR UPDATE OF Trn_Theme",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z9", "SELECT Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily, Trn_ThemeFontSize, ThemeIsPredefined FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z10", "SELECT TM1.Trn_ThemeId, TM1.Trn_ThemeName, TM1.Trn_ThemeFontFamily, TM1.Trn_ThemeFontSize, TM1.ThemeIsPredefined FROM Trn_Theme TM1 WHERE TM1.Trn_ThemeId = :Trn_ThemeId ORDER BY TM1.Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z10,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z11", "SELECT Trn_ThemeId FROM Trn_Theme WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z11,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z12", "SAVEPOINT gxupdate;INSERT INTO Trn_Theme(Trn_ThemeId, Trn_ThemeName, Trn_ThemeFontFamily, Trn_ThemeFontSize, ThemeIsPredefined) VALUES(:Trn_ThemeId, :Trn_ThemeName, :Trn_ThemeFontFamily, :Trn_ThemeFontSize, :ThemeIsPredefined);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000Z12)
          ,new CursorDef("BC000Z13", "SAVEPOINT gxupdate;UPDATE Trn_Theme SET Trn_ThemeName=:Trn_ThemeName, Trn_ThemeFontFamily=:Trn_ThemeFontFamily, Trn_ThemeFontSize=:Trn_ThemeFontSize, ThemeIsPredefined=:ThemeIsPredefined  WHERE Trn_ThemeId = :Trn_ThemeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Z13)
          ,new CursorDef("BC000Z14", "SAVEPOINT gxupdate;DELETE FROM Trn_Theme  WHERE Trn_ThemeId = :Trn_ThemeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Z14)
          ,new CursorDef("BC000Z15", "SELECT LocationId, OrganisationId FROM Trn_Location WHERE LocationThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z15,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000Z16", "SELECT AppVersionId FROM Trn_AppVersion WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z16,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000Z17", "SELECT OrganisationSettingid, OrganisationId FROM Trn_OrganisationSetting WHERE Trn_ThemeId = :Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z17,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000Z18", "SELECT TM1.Trn_ThemeId, TM1.Trn_ThemeName, TM1.Trn_ThemeFontFamily, TM1.Trn_ThemeFontSize, TM1.ThemeIsPredefined FROM Trn_Theme TM1 WHERE TM1.Trn_ThemeId = :Trn_ThemeId ORDER BY TM1.Trn_ThemeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z18,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z19", "SELECT Trn_ThemeId, CtaColorId, CtaColorName, CtaColorCode FROM Trn_ThemeCtaColor WHERE Trn_ThemeId = :Trn_ThemeId and CtaColorId = :CtaColorId ORDER BY Trn_ThemeId, CtaColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z19,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z20", "SELECT Trn_ThemeId FROM Trn_ThemeCtaColor WHERE (Trn_ThemeId = :Trn_ThemeId AND CtaColorName = :CtaColorName) AND (Not ( Trn_ThemeId = :Trn_ThemeId and CtaColorId = :CtaColorId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z20,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z21", "SELECT Trn_ThemeId, CtaColorId FROM Trn_ThemeCtaColor WHERE Trn_ThemeId = :Trn_ThemeId AND CtaColorId = :CtaColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z21,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z22", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeCtaColor(Trn_ThemeId, CtaColorId, CtaColorName, CtaColorCode) VALUES(:Trn_ThemeId, :CtaColorId, :CtaColorName, :CtaColorCode);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000Z22)
          ,new CursorDef("BC000Z23", "SAVEPOINT gxupdate;UPDATE Trn_ThemeCtaColor SET CtaColorName=:CtaColorName, CtaColorCode=:CtaColorCode  WHERE Trn_ThemeId = :Trn_ThemeId AND CtaColorId = :CtaColorId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Z23)
          ,new CursorDef("BC000Z24", "SAVEPOINT gxupdate;DELETE FROM Trn_ThemeCtaColor  WHERE Trn_ThemeId = :Trn_ThemeId AND CtaColorId = :CtaColorId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Z24)
          ,new CursorDef("BC000Z25", "SELECT Trn_ThemeId, CtaColorId, CtaColorName, CtaColorCode FROM Trn_ThemeCtaColor WHERE Trn_ThemeId = :Trn_ThemeId ORDER BY Trn_ThemeId, CtaColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z25,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z26", "SELECT Trn_ThemeId, IconId, IconCategory, IconName, IconSVG FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId and IconId = :IconId ORDER BY Trn_ThemeId, IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z26,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z27", "SELECT Trn_ThemeId FROM Trn_ThemeIcon WHERE (Trn_ThemeId = :Trn_ThemeId AND IconName = :IconName AND IconCategory = :IconCategory) AND (Not ( Trn_ThemeId = :Trn_ThemeId and IconId = :IconId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z27,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z28", "SELECT Trn_ThemeId, IconId FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z28,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z29", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeIcon(Trn_ThemeId, IconId, IconCategory, IconName, IconSVG) VALUES(:Trn_ThemeId, :IconId, :IconCategory, :IconName, :IconSVG);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000Z29)
          ,new CursorDef("BC000Z30", "SAVEPOINT gxupdate;UPDATE Trn_ThemeIcon SET IconCategory=:IconCategory, IconName=:IconName, IconSVG=:IconSVG  WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Z30)
          ,new CursorDef("BC000Z31", "SAVEPOINT gxupdate;DELETE FROM Trn_ThemeIcon  WHERE Trn_ThemeId = :Trn_ThemeId AND IconId = :IconId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Z31)
          ,new CursorDef("BC000Z32", "SELECT Trn_ThemeId, IconId, IconCategory, IconName, IconSVG FROM Trn_ThemeIcon WHERE Trn_ThemeId = :Trn_ThemeId ORDER BY Trn_ThemeId, IconId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z32,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z33", "SELECT Trn_ThemeId, ColorId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId and ColorId = :ColorId ORDER BY Trn_ThemeId, ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z33,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z34", "SELECT Trn_ThemeId FROM Trn_ThemeColor WHERE (Trn_ThemeId = :Trn_ThemeId AND ColorName = :ColorName) AND (Not ( Trn_ThemeId = :Trn_ThemeId and ColorId = :ColorId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z34,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z35", "SELECT Trn_ThemeId FROM Trn_ThemeColor WHERE (Trn_ThemeId = :Trn_ThemeId AND ColorName = :ColorName AND ColorCode = :ColorCode) AND (Not ( Trn_ThemeId = :Trn_ThemeId and ColorId = :ColorId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z35,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z36", "SELECT Trn_ThemeId, ColorId FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z36,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000Z37", "SAVEPOINT gxupdate;INSERT INTO Trn_ThemeColor(Trn_ThemeId, ColorId, ColorName, ColorCode) VALUES(:Trn_ThemeId, :ColorId, :ColorName, :ColorCode);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000Z37)
          ,new CursorDef("BC000Z38", "SAVEPOINT gxupdate;UPDATE Trn_ThemeColor SET ColorName=:ColorName, ColorCode=:ColorCode  WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Z38)
          ,new CursorDef("BC000Z39", "SAVEPOINT gxupdate;DELETE FROM Trn_ThemeColor  WHERE Trn_ThemeId = :Trn_ThemeId AND ColorId = :ColorId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Z39)
          ,new CursorDef("BC000Z40", "SELECT Trn_ThemeId, ColorId, ColorName, ColorCode FROM Trn_ThemeColor WHERE Trn_ThemeId = :Trn_ThemeId ORDER BY Trn_ThemeId, ColorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z40,11, GxCacheFrequency.OFF ,true,false )
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
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((bool[]) buf[4])[0] = rslt.getBool(5);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((bool[]) buf[4])[0] = rslt.getBool(5);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((bool[]) buf[4])[0] = rslt.getBool(5);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 13 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 14 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 15 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 16 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             ((bool[]) buf[4])[0] = rslt.getBool(5);
             return;
          case 17 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 18 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 19 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 23 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 24 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             return;
          case 25 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 26 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
    }
    getresults30( cursor, rslt, buf) ;
 }

 public void getresults30( int cursor ,
                           IFieldGetter rslt ,
                           Object[] buf )
 {
    switch ( cursor )
    {
          case 30 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
             return;
          case 31 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 32 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 33 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 34 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 38 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
    }
 }

}

}
