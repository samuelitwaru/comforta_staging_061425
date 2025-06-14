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
   public class trn_template_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_template_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_template_bc( IGxContext context )
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
         ReadRow1258( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1258( ) ;
         standaloneModal( ) ;
         AddRow1258( ) ;
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
            E11122 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z299Trn_TemplateId = A299Trn_TemplateId;
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

      protected void CONFIRM_120( )
      {
         BeforeValidate1258( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1258( ) ;
            }
            else
            {
               CheckExtendedTable1258( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1258( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12122( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11122( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1258( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z300Trn_TemplateName = A300Trn_TemplateName;
            Z301Trn_TemplateMedia = A301Trn_TemplateMedia;
         }
         if ( GX_JID == -3 )
         {
            Z299Trn_TemplateId = A299Trn_TemplateId;
            Z300Trn_TemplateName = A300Trn_TemplateName;
            Z301Trn_TemplateMedia = A301Trn_TemplateMedia;
            Z302Trn_TemplateContent = A302Trn_TemplateContent;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A299Trn_TemplateId) )
         {
            A299Trn_TemplateId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1258( )
      {
         /* Using cursor BC00124 */
         pr_default.execute(2, new Object[] {A299Trn_TemplateId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound58 = 1;
            A300Trn_TemplateName = BC00124_A300Trn_TemplateName[0];
            A301Trn_TemplateMedia = BC00124_A301Trn_TemplateMedia[0];
            A302Trn_TemplateContent = BC00124_A302Trn_TemplateContent[0];
            ZM1258( -3) ;
         }
         pr_default.close(2);
         OnLoadActions1258( ) ;
      }

      protected void OnLoadActions1258( )
      {
      }

      protected void CheckExtendedTable1258( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1258( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1258( )
      {
         /* Using cursor BC00125 */
         pr_default.execute(3, new Object[] {A299Trn_TemplateId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound58 = 1;
         }
         else
         {
            RcdFound58 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00123 */
         pr_default.execute(1, new Object[] {A299Trn_TemplateId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1258( 3) ;
            RcdFound58 = 1;
            A299Trn_TemplateId = BC00123_A299Trn_TemplateId[0];
            A300Trn_TemplateName = BC00123_A300Trn_TemplateName[0];
            A301Trn_TemplateMedia = BC00123_A301Trn_TemplateMedia[0];
            A302Trn_TemplateContent = BC00123_A302Trn_TemplateContent[0];
            Z299Trn_TemplateId = A299Trn_TemplateId;
            sMode58 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1258( ) ;
            if ( AnyError == 1 )
            {
               RcdFound58 = 0;
               InitializeNonKey1258( ) ;
            }
            Gx_mode = sMode58;
         }
         else
         {
            RcdFound58 = 0;
            InitializeNonKey1258( ) ;
            sMode58 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode58;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1258( ) ;
         if ( RcdFound58 == 0 )
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
         CONFIRM_120( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1258( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00122 */
            pr_default.execute(0, new Object[] {A299Trn_TemplateId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Template"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z300Trn_TemplateName, BC00122_A300Trn_TemplateName[0]) != 0 ) || ( StringUtil.StrCmp(Z301Trn_TemplateMedia, BC00122_A301Trn_TemplateMedia[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Template"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1258( )
      {
         BeforeValidate1258( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1258( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1258( 0) ;
            CheckOptimisticConcurrency1258( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1258( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1258( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00126 */
                     pr_default.execute(4, new Object[] {A299Trn_TemplateId, A300Trn_TemplateName, A301Trn_TemplateMedia, A302Trn_TemplateContent});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Template");
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
               Load1258( ) ;
            }
            EndLevel1258( ) ;
         }
         CloseExtendedTableCursors1258( ) ;
      }

      protected void Update1258( )
      {
         BeforeValidate1258( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1258( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1258( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1258( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1258( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00127 */
                     pr_default.execute(5, new Object[] {A300Trn_TemplateName, A301Trn_TemplateMedia, A302Trn_TemplateContent, A299Trn_TemplateId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Template");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Template"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1258( ) ;
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
            EndLevel1258( ) ;
         }
         CloseExtendedTableCursors1258( ) ;
      }

      protected void DeferredUpdate1258( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1258( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1258( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1258( ) ;
            AfterConfirm1258( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1258( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00128 */
                  pr_default.execute(6, new Object[] {A299Trn_TemplateId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Template");
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
         sMode58 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1258( ) ;
         Gx_mode = sMode58;
      }

      protected void OnDeleteControls1258( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1258( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1258( ) ;
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

      public void ScanKeyStart1258( )
      {
         /* Scan By routine */
         /* Using cursor BC00129 */
         pr_default.execute(7, new Object[] {A299Trn_TemplateId});
         RcdFound58 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound58 = 1;
            A299Trn_TemplateId = BC00129_A299Trn_TemplateId[0];
            A300Trn_TemplateName = BC00129_A300Trn_TemplateName[0];
            A301Trn_TemplateMedia = BC00129_A301Trn_TemplateMedia[0];
            A302Trn_TemplateContent = BC00129_A302Trn_TemplateContent[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1258( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound58 = 0;
         ScanKeyLoad1258( ) ;
      }

      protected void ScanKeyLoad1258( )
      {
         sMode58 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound58 = 1;
            A299Trn_TemplateId = BC00129_A299Trn_TemplateId[0];
            A300Trn_TemplateName = BC00129_A300Trn_TemplateName[0];
            A301Trn_TemplateMedia = BC00129_A301Trn_TemplateMedia[0];
            A302Trn_TemplateContent = BC00129_A302Trn_TemplateContent[0];
         }
         Gx_mode = sMode58;
      }

      protected void ScanKeyEnd1258( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm1258( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1258( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1258( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1258( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1258( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1258( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1258( )
      {
      }

      protected void send_integrity_lvl_hashes1258( )
      {
      }

      protected void AddRow1258( )
      {
         VarsToRow58( bcTrn_Template) ;
      }

      protected void ReadRow1258( )
      {
         RowToVars58( bcTrn_Template, 1) ;
      }

      protected void InitializeNonKey1258( )
      {
         A300Trn_TemplateName = "";
         A301Trn_TemplateMedia = "";
         A302Trn_TemplateContent = "";
         Z300Trn_TemplateName = "";
         Z301Trn_TemplateMedia = "";
      }

      protected void InitAll1258( )
      {
         A299Trn_TemplateId = Guid.NewGuid( );
         InitializeNonKey1258( ) ;
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

      public void VarsToRow58( SdtTrn_Template obj58 )
      {
         obj58.gxTpr_Mode = Gx_mode;
         obj58.gxTpr_Trn_templatename = A300Trn_TemplateName;
         obj58.gxTpr_Trn_templatemedia = A301Trn_TemplateMedia;
         obj58.gxTpr_Trn_templatecontent = A302Trn_TemplateContent;
         obj58.gxTpr_Trn_templateid = A299Trn_TemplateId;
         obj58.gxTpr_Trn_templateid_Z = Z299Trn_TemplateId;
         obj58.gxTpr_Trn_templatename_Z = Z300Trn_TemplateName;
         obj58.gxTpr_Trn_templatemedia_Z = Z301Trn_TemplateMedia;
         obj58.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow58( SdtTrn_Template obj58 )
      {
         obj58.gxTpr_Trn_templateid = A299Trn_TemplateId;
         return  ;
      }

      public void RowToVars58( SdtTrn_Template obj58 ,
                               int forceLoad )
      {
         Gx_mode = obj58.gxTpr_Mode;
         A300Trn_TemplateName = obj58.gxTpr_Trn_templatename;
         A301Trn_TemplateMedia = obj58.gxTpr_Trn_templatemedia;
         A302Trn_TemplateContent = obj58.gxTpr_Trn_templatecontent;
         A299Trn_TemplateId = obj58.gxTpr_Trn_templateid;
         Z299Trn_TemplateId = obj58.gxTpr_Trn_templateid_Z;
         Z300Trn_TemplateName = obj58.gxTpr_Trn_templatename_Z;
         Z301Trn_TemplateMedia = obj58.gxTpr_Trn_templatemedia_Z;
         Gx_mode = obj58.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A299Trn_TemplateId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1258( ) ;
         ScanKeyStart1258( ) ;
         if ( RcdFound58 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z299Trn_TemplateId = A299Trn_TemplateId;
         }
         ZM1258( -3) ;
         OnLoadActions1258( ) ;
         AddRow1258( ) ;
         ScanKeyEnd1258( ) ;
         if ( RcdFound58 == 0 )
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
         RowToVars58( bcTrn_Template, 0) ;
         ScanKeyStart1258( ) ;
         if ( RcdFound58 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z299Trn_TemplateId = A299Trn_TemplateId;
         }
         ZM1258( -3) ;
         OnLoadActions1258( ) ;
         AddRow1258( ) ;
         ScanKeyEnd1258( ) ;
         if ( RcdFound58 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1258( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1258( ) ;
         }
         else
         {
            if ( RcdFound58 == 1 )
            {
               if ( A299Trn_TemplateId != Z299Trn_TemplateId )
               {
                  A299Trn_TemplateId = Z299Trn_TemplateId;
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
                  Update1258( ) ;
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
                  if ( A299Trn_TemplateId != Z299Trn_TemplateId )
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
                        Insert1258( ) ;
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
                        Insert1258( ) ;
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
         RowToVars58( bcTrn_Template, 1) ;
         SaveImpl( ) ;
         VarsToRow58( bcTrn_Template) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars58( bcTrn_Template, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1258( ) ;
         AfterTrn( ) ;
         VarsToRow58( bcTrn_Template) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow58( bcTrn_Template) ;
         }
         else
         {
            SdtTrn_Template auxBC = new SdtTrn_Template(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A299Trn_TemplateId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Template);
               auxBC.Save();
               bcTrn_Template.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars58( bcTrn_Template, 1) ;
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
         RowToVars58( bcTrn_Template, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1258( ) ;
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
               VarsToRow58( bcTrn_Template) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow58( bcTrn_Template) ;
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
         RowToVars58( bcTrn_Template, 0) ;
         GetKey1258( ) ;
         if ( RcdFound58 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A299Trn_TemplateId != Z299Trn_TemplateId )
            {
               A299Trn_TemplateId = Z299Trn_TemplateId;
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
            if ( A299Trn_TemplateId != Z299Trn_TemplateId )
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
         context.RollbackDataStores("trn_template_bc",pr_default);
         VarsToRow58( bcTrn_Template) ;
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
         Gx_mode = bcTrn_Template.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Template.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Template )
         {
            bcTrn_Template = (SdtTrn_Template)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Template.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Template.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow58( bcTrn_Template) ;
            }
            else
            {
               RowToVars58( bcTrn_Template, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Template.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Template.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars58( bcTrn_Template, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Template Trn_Template_BC
      {
         get {
            return bcTrn_Template ;
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
            return "trn_template_Execute" ;
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
         Z299Trn_TemplateId = Guid.Empty;
         A299Trn_TemplateId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z300Trn_TemplateName = "";
         A300Trn_TemplateName = "";
         Z301Trn_TemplateMedia = "";
         A301Trn_TemplateMedia = "";
         Z302Trn_TemplateContent = "";
         A302Trn_TemplateContent = "";
         BC00124_A299Trn_TemplateId = new Guid[] {Guid.Empty} ;
         BC00124_A300Trn_TemplateName = new string[] {""} ;
         BC00124_A301Trn_TemplateMedia = new string[] {""} ;
         BC00124_A302Trn_TemplateContent = new string[] {""} ;
         BC00125_A299Trn_TemplateId = new Guid[] {Guid.Empty} ;
         BC00123_A299Trn_TemplateId = new Guid[] {Guid.Empty} ;
         BC00123_A300Trn_TemplateName = new string[] {""} ;
         BC00123_A301Trn_TemplateMedia = new string[] {""} ;
         BC00123_A302Trn_TemplateContent = new string[] {""} ;
         sMode58 = "";
         BC00122_A299Trn_TemplateId = new Guid[] {Guid.Empty} ;
         BC00122_A300Trn_TemplateName = new string[] {""} ;
         BC00122_A301Trn_TemplateMedia = new string[] {""} ;
         BC00122_A302Trn_TemplateContent = new string[] {""} ;
         BC00129_A299Trn_TemplateId = new Guid[] {Guid.Empty} ;
         BC00129_A300Trn_TemplateName = new string[] {""} ;
         BC00129_A301Trn_TemplateMedia = new string[] {""} ;
         BC00129_A302Trn_TemplateContent = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_template_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_template_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_template_bc__default(),
            new Object[][] {
                new Object[] {
               BC00122_A299Trn_TemplateId, BC00122_A300Trn_TemplateName, BC00122_A301Trn_TemplateMedia, BC00122_A302Trn_TemplateContent
               }
               , new Object[] {
               BC00123_A299Trn_TemplateId, BC00123_A300Trn_TemplateName, BC00123_A301Trn_TemplateMedia, BC00123_A302Trn_TemplateContent
               }
               , new Object[] {
               BC00124_A299Trn_TemplateId, BC00124_A300Trn_TemplateName, BC00124_A301Trn_TemplateMedia, BC00124_A302Trn_TemplateContent
               }
               , new Object[] {
               BC00125_A299Trn_TemplateId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00129_A299Trn_TemplateId, BC00129_A300Trn_TemplateName, BC00129_A301Trn_TemplateMedia, BC00129_A302Trn_TemplateContent
               }
            }
         );
         Z299Trn_TemplateId = Guid.NewGuid( );
         A299Trn_TemplateId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12122 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound58 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode58 ;
      private bool returnInSub ;
      private string Z302Trn_TemplateContent ;
      private string A302Trn_TemplateContent ;
      private string Z300Trn_TemplateName ;
      private string A300Trn_TemplateName ;
      private string Z301Trn_TemplateMedia ;
      private string A301Trn_TemplateMedia ;
      private Guid Z299Trn_TemplateId ;
      private Guid A299Trn_TemplateId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00124_A299Trn_TemplateId ;
      private string[] BC00124_A300Trn_TemplateName ;
      private string[] BC00124_A301Trn_TemplateMedia ;
      private string[] BC00124_A302Trn_TemplateContent ;
      private Guid[] BC00125_A299Trn_TemplateId ;
      private Guid[] BC00123_A299Trn_TemplateId ;
      private string[] BC00123_A300Trn_TemplateName ;
      private string[] BC00123_A301Trn_TemplateMedia ;
      private string[] BC00123_A302Trn_TemplateContent ;
      private Guid[] BC00122_A299Trn_TemplateId ;
      private string[] BC00122_A300Trn_TemplateName ;
      private string[] BC00122_A301Trn_TemplateMedia ;
      private string[] BC00122_A302Trn_TemplateContent ;
      private Guid[] BC00129_A299Trn_TemplateId ;
      private string[] BC00129_A300Trn_TemplateName ;
      private string[] BC00129_A301Trn_TemplateMedia ;
      private string[] BC00129_A302Trn_TemplateContent ;
      private SdtTrn_Template bcTrn_Template ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_template_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_template_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_template_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[7])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC00122;
       prmBC00122 = new Object[] {
       new ParDef("Trn_TemplateId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00123;
       prmBC00123 = new Object[] {
       new ParDef("Trn_TemplateId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00124;
       prmBC00124 = new Object[] {
       new ParDef("Trn_TemplateId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00125;
       prmBC00125 = new Object[] {
       new ParDef("Trn_TemplateId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00126;
       prmBC00126 = new Object[] {
       new ParDef("Trn_TemplateId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_TemplateName",GXType.VarChar,100,0) ,
       new ParDef("Trn_TemplateMedia",GXType.VarChar,100,0) ,
       new ParDef("Trn_TemplateContent",GXType.LongVarChar,2097152,0)
       };
       Object[] prmBC00127;
       prmBC00127 = new Object[] {
       new ParDef("Trn_TemplateName",GXType.VarChar,100,0) ,
       new ParDef("Trn_TemplateMedia",GXType.VarChar,100,0) ,
       new ParDef("Trn_TemplateContent",GXType.LongVarChar,2097152,0) ,
       new ParDef("Trn_TemplateId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00128;
       prmBC00128 = new Object[] {
       new ParDef("Trn_TemplateId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00129;
       prmBC00129 = new Object[] {
       new ParDef("Trn_TemplateId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC00122", "SELECT Trn_TemplateId, Trn_TemplateName, Trn_TemplateMedia, Trn_TemplateContent FROM Trn_Template WHERE Trn_TemplateId = :Trn_TemplateId  FOR UPDATE OF Trn_Template",true, GxErrorMask.GX_NOMASK, false, this,prmBC00122,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00123", "SELECT Trn_TemplateId, Trn_TemplateName, Trn_TemplateMedia, Trn_TemplateContent FROM Trn_Template WHERE Trn_TemplateId = :Trn_TemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00123,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00124", "SELECT TM1.Trn_TemplateId, TM1.Trn_TemplateName, TM1.Trn_TemplateMedia, TM1.Trn_TemplateContent FROM Trn_Template TM1 WHERE TM1.Trn_TemplateId = :Trn_TemplateId ORDER BY TM1.Trn_TemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00124,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00125", "SELECT Trn_TemplateId FROM Trn_Template WHERE Trn_TemplateId = :Trn_TemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00125,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00126", "SAVEPOINT gxupdate;INSERT INTO Trn_Template(Trn_TemplateId, Trn_TemplateName, Trn_TemplateMedia, Trn_TemplateContent) VALUES(:Trn_TemplateId, :Trn_TemplateName, :Trn_TemplateMedia, :Trn_TemplateContent);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00126)
          ,new CursorDef("BC00127", "SAVEPOINT gxupdate;UPDATE Trn_Template SET Trn_TemplateName=:Trn_TemplateName, Trn_TemplateMedia=:Trn_TemplateMedia, Trn_TemplateContent=:Trn_TemplateContent  WHERE Trn_TemplateId = :Trn_TemplateId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00127)
          ,new CursorDef("BC00128", "SAVEPOINT gxupdate;DELETE FROM Trn_Template  WHERE Trn_TemplateId = :Trn_TemplateId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00128)
          ,new CursorDef("BC00129", "SELECT TM1.Trn_TemplateId, TM1.Trn_TemplateName, TM1.Trn_TemplateMedia, TM1.Trn_TemplateContent FROM Trn_Template TM1 WHERE TM1.Trn_TemplateId = :Trn_TemplateId ORDER BY TM1.Trn_TemplateId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00129,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             return;
    }
 }

}

}
