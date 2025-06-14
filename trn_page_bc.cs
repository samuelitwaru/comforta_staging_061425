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
   public class trn_page_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_page_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_page_bc( IGxContext context )
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
         ReadRow1988( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1988( ) ;
         standaloneModal( ) ;
         AddRow1988( ) ;
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
            E11192 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z392Trn_PageId = A392Trn_PageId;
               Z29LocationId = A29LocationId;
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

      protected void CONFIRM_190( )
      {
         BeforeValidate1988( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1988( ) ;
            }
            else
            {
               CheckExtendedTable1988( ) ;
               if ( AnyError == 0 )
               {
                  ZM1988( 20) ;
                  ZM1988( 21) ;
               }
               CloseExtendedTableCursors1988( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12192( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV35Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV36GXV1 = 1;
            while ( AV36GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV36GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "ProductServiceId") == 0 )
               {
                  AV16Insert_ProductServiceId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "OrganisationId") == 0 )
               {
                  AV14Insert_OrganisationId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
               }
               AV36GXV1 = (int)(AV36GXV1+1);
            }
         }
      }

      protected void E11192( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV34AuditingObject,  AV35Pgmname) ;
      }

      protected void ZM1988( short GX_JID )
      {
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            Z397Trn_PageName = A397Trn_PageName;
            Z423PageIsPublished = A423PageIsPublished;
            Z492PageIsPredefined = A492PageIsPredefined;
            Z429PageIsContentPage = A429PageIsContentPage;
            Z502PageIsDynamicForm = A502PageIsDynamicForm;
            Z505PageIsWebLinkPage = A505PageIsWebLinkPage;
            Z11OrganisationId = A11OrganisationId;
            Z58ProductServiceId = A58ProductServiceId;
         }
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 21 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -19 )
         {
            Z392Trn_PageId = A392Trn_PageId;
            Z397Trn_PageName = A397Trn_PageName;
            Z420PageJsonContent = A420PageJsonContent;
            Z421PageGJSHtml = A421PageGJSHtml;
            Z422PageGJSJson = A422PageGJSJson;
            Z423PageIsPublished = A423PageIsPublished;
            Z492PageIsPredefined = A492PageIsPredefined;
            Z429PageIsContentPage = A429PageIsContentPage;
            Z502PageIsDynamicForm = A502PageIsDynamicForm;
            Z505PageIsWebLinkPage = A505PageIsWebLinkPage;
            Z424PageChildren = A424PageChildren;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z58ProductServiceId = A58ProductServiceId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AV35Pgmname = "Trn_Page_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A392Trn_PageId) )
         {
            A392Trn_PageId = Guid.NewGuid( );
         }
         if ( IsIns( )  && (false==A502PageIsDynamicForm) && ( Gx_BScreen == 0 ) )
         {
            A502PageIsDynamicForm = false;
         }
         if ( IsIns( )  && (false==A429PageIsContentPage) && ( Gx_BScreen == 0 ) )
         {
            A429PageIsContentPage = false;
            n429PageIsContentPage = false;
         }
         if ( IsIns( )  && (false==A492PageIsPredefined) && ( Gx_BScreen == 0 ) )
         {
            A492PageIsPredefined = false;
         }
         if ( IsIns( )  && (false==A423PageIsPublished) && ( Gx_BScreen == 0 ) )
         {
            A423PageIsPublished = false;
            n423PageIsPublished = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1988( )
      {
         /* Using cursor BC00196 */
         pr_default.execute(4, new Object[] {A392Trn_PageId, A29LocationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound88 = 1;
            A397Trn_PageName = BC00196_A397Trn_PageName[0];
            A420PageJsonContent = BC00196_A420PageJsonContent[0];
            n420PageJsonContent = BC00196_n420PageJsonContent[0];
            A421PageGJSHtml = BC00196_A421PageGJSHtml[0];
            n421PageGJSHtml = BC00196_n421PageGJSHtml[0];
            A422PageGJSJson = BC00196_A422PageGJSJson[0];
            n422PageGJSJson = BC00196_n422PageGJSJson[0];
            A423PageIsPublished = BC00196_A423PageIsPublished[0];
            n423PageIsPublished = BC00196_n423PageIsPublished[0];
            A492PageIsPredefined = BC00196_A492PageIsPredefined[0];
            A429PageIsContentPage = BC00196_A429PageIsContentPage[0];
            n429PageIsContentPage = BC00196_n429PageIsContentPage[0];
            A502PageIsDynamicForm = BC00196_A502PageIsDynamicForm[0];
            A505PageIsWebLinkPage = BC00196_A505PageIsWebLinkPage[0];
            A424PageChildren = BC00196_A424PageChildren[0];
            n424PageChildren = BC00196_n424PageChildren[0];
            A11OrganisationId = BC00196_A11OrganisationId[0];
            A58ProductServiceId = BC00196_A58ProductServiceId[0];
            n58ProductServiceId = BC00196_n58ProductServiceId[0];
            ZM1988( -19) ;
         }
         pr_default.close(4);
         OnLoadActions1988( ) ;
      }

      protected void OnLoadActions1988( )
      {
         if ( (Guid.Empty==A58ProductServiceId) )
         {
            A58ProductServiceId = Guid.Empty;
            n58ProductServiceId = false;
            n58ProductServiceId = true;
         }
      }

      protected void CheckExtendedTable1988( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A397Trn_PageName)) )
         {
            GX_msglist.addItem(context.GetMessage( "Page name cannot be empty.", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00194 */
         pr_default.execute(2, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
         if ( ( StringUtil.StrCmp(A397Trn_PageName, context.GetMessage( "Home", "")) == 0 ) && new prc_islocationhomepagecreated(context).executeUdp( ) && IsIns( )  )
         {
            GX_msglist.addItem(context.GetMessage( "Reserved page name.", ""), 1, "");
            AnyError = 1;
         }
         if ( (Guid.Empty==A58ProductServiceId) )
         {
            A58ProductServiceId = Guid.Empty;
            n58ProductServiceId = false;
            n58ProductServiceId = true;
         }
         /* Using cursor BC00195 */
         pr_default.execute(3, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A58ProductServiceId) || (Guid.Empty==A29LocationId) || (Guid.Empty==A11OrganisationId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Services", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1988( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1988( )
      {
         /* Using cursor BC00197 */
         pr_default.execute(5, new Object[] {A392Trn_PageId, A29LocationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound88 = 1;
         }
         else
         {
            RcdFound88 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00193 */
         pr_default.execute(1, new Object[] {A392Trn_PageId, A29LocationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1988( 19) ;
            RcdFound88 = 1;
            A392Trn_PageId = BC00193_A392Trn_PageId[0];
            A397Trn_PageName = BC00193_A397Trn_PageName[0];
            A420PageJsonContent = BC00193_A420PageJsonContent[0];
            n420PageJsonContent = BC00193_n420PageJsonContent[0];
            A421PageGJSHtml = BC00193_A421PageGJSHtml[0];
            n421PageGJSHtml = BC00193_n421PageGJSHtml[0];
            A422PageGJSJson = BC00193_A422PageGJSJson[0];
            n422PageGJSJson = BC00193_n422PageGJSJson[0];
            A423PageIsPublished = BC00193_A423PageIsPublished[0];
            n423PageIsPublished = BC00193_n423PageIsPublished[0];
            A492PageIsPredefined = BC00193_A492PageIsPredefined[0];
            A429PageIsContentPage = BC00193_A429PageIsContentPage[0];
            n429PageIsContentPage = BC00193_n429PageIsContentPage[0];
            A502PageIsDynamicForm = BC00193_A502PageIsDynamicForm[0];
            A505PageIsWebLinkPage = BC00193_A505PageIsWebLinkPage[0];
            A424PageChildren = BC00193_A424PageChildren[0];
            n424PageChildren = BC00193_n424PageChildren[0];
            A29LocationId = BC00193_A29LocationId[0];
            A11OrganisationId = BC00193_A11OrganisationId[0];
            A58ProductServiceId = BC00193_A58ProductServiceId[0];
            n58ProductServiceId = BC00193_n58ProductServiceId[0];
            Z392Trn_PageId = A392Trn_PageId;
            Z29LocationId = A29LocationId;
            sMode88 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1988( ) ;
            if ( AnyError == 1 )
            {
               RcdFound88 = 0;
               InitializeNonKey1988( ) ;
            }
            Gx_mode = sMode88;
         }
         else
         {
            RcdFound88 = 0;
            InitializeNonKey1988( ) ;
            sMode88 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode88;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1988( ) ;
         if ( RcdFound88 == 0 )
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
         CONFIRM_190( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1988( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00192 */
            pr_default.execute(0, new Object[] {A392Trn_PageId, A29LocationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Page"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z397Trn_PageName, BC00192_A397Trn_PageName[0]) != 0 ) || ( Z423PageIsPublished != BC00192_A423PageIsPublished[0] ) || ( Z492PageIsPredefined != BC00192_A492PageIsPredefined[0] ) || ( Z429PageIsContentPage != BC00192_A429PageIsContentPage[0] ) || ( Z502PageIsDynamicForm != BC00192_A502PageIsDynamicForm[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z505PageIsWebLinkPage != BC00192_A505PageIsWebLinkPage[0] ) || ( Z11OrganisationId != BC00192_A11OrganisationId[0] ) || ( Z58ProductServiceId != BC00192_A58ProductServiceId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Page"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1988( )
      {
         BeforeValidate1988( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1988( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1988( 0) ;
            CheckOptimisticConcurrency1988( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1988( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1988( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00198 */
                     pr_default.execute(6, new Object[] {A392Trn_PageId, A397Trn_PageName, n420PageJsonContent, A420PageJsonContent, n421PageGJSHtml, A421PageGJSHtml, n422PageGJSJson, A422PageGJSJson, n423PageIsPublished, A423PageIsPublished, A492PageIsPredefined, n429PageIsContentPage, A429PageIsContentPage, A502PageIsDynamicForm, A505PageIsWebLinkPage, n424PageChildren, A424PageChildren, A29LocationId, A11OrganisationId, n58ProductServiceId, A58ProductServiceId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Page");
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
               Load1988( ) ;
            }
            EndLevel1988( ) ;
         }
         CloseExtendedTableCursors1988( ) ;
      }

      protected void Update1988( )
      {
         BeforeValidate1988( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1988( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1988( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1988( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1988( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00199 */
                     pr_default.execute(7, new Object[] {A397Trn_PageName, n420PageJsonContent, A420PageJsonContent, n421PageGJSHtml, A421PageGJSHtml, n422PageGJSJson, A422PageGJSJson, n423PageIsPublished, A423PageIsPublished, A492PageIsPredefined, n429PageIsContentPage, A429PageIsContentPage, A502PageIsDynamicForm, A505PageIsWebLinkPage, n424PageChildren, A424PageChildren, A11OrganisationId, n58ProductServiceId, A58ProductServiceId, A392Trn_PageId, A29LocationId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Page");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Page"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1988( ) ;
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
            EndLevel1988( ) ;
         }
         CloseExtendedTableCursors1988( ) ;
      }

      protected void DeferredUpdate1988( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1988( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1988( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1988( ) ;
            AfterConfirm1988( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1988( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001910 */
                  pr_default.execute(8, new Object[] {A392Trn_PageId, A29LocationId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Page");
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
         sMode88 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1988( ) ;
         Gx_mode = sMode88;
      }

      protected void OnDeleteControls1988( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( ( StringUtil.StrCmp(A397Trn_PageName, context.GetMessage( "Home", "")) == 0 ) && new prc_islocationhomepagecreated(context).executeUdp( ) && IsIns( )  )
            {
               GX_msglist.addItem(context.GetMessage( "Reserved page name.", ""), 1, "");
               AnyError = 1;
            }
         }
      }

      protected void EndLevel1988( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1988( ) ;
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

      public void ScanKeyStart1988( )
      {
         /* Scan By routine */
         /* Using cursor BC001911 */
         pr_default.execute(9, new Object[] {A392Trn_PageId, A29LocationId});
         RcdFound88 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound88 = 1;
            A392Trn_PageId = BC001911_A392Trn_PageId[0];
            A397Trn_PageName = BC001911_A397Trn_PageName[0];
            A420PageJsonContent = BC001911_A420PageJsonContent[0];
            n420PageJsonContent = BC001911_n420PageJsonContent[0];
            A421PageGJSHtml = BC001911_A421PageGJSHtml[0];
            n421PageGJSHtml = BC001911_n421PageGJSHtml[0];
            A422PageGJSJson = BC001911_A422PageGJSJson[0];
            n422PageGJSJson = BC001911_n422PageGJSJson[0];
            A423PageIsPublished = BC001911_A423PageIsPublished[0];
            n423PageIsPublished = BC001911_n423PageIsPublished[0];
            A492PageIsPredefined = BC001911_A492PageIsPredefined[0];
            A429PageIsContentPage = BC001911_A429PageIsContentPage[0];
            n429PageIsContentPage = BC001911_n429PageIsContentPage[0];
            A502PageIsDynamicForm = BC001911_A502PageIsDynamicForm[0];
            A505PageIsWebLinkPage = BC001911_A505PageIsWebLinkPage[0];
            A424PageChildren = BC001911_A424PageChildren[0];
            n424PageChildren = BC001911_n424PageChildren[0];
            A29LocationId = BC001911_A29LocationId[0];
            A11OrganisationId = BC001911_A11OrganisationId[0];
            A58ProductServiceId = BC001911_A58ProductServiceId[0];
            n58ProductServiceId = BC001911_n58ProductServiceId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1988( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound88 = 0;
         ScanKeyLoad1988( ) ;
      }

      protected void ScanKeyLoad1988( )
      {
         sMode88 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound88 = 1;
            A392Trn_PageId = BC001911_A392Trn_PageId[0];
            A397Trn_PageName = BC001911_A397Trn_PageName[0];
            A420PageJsonContent = BC001911_A420PageJsonContent[0];
            n420PageJsonContent = BC001911_n420PageJsonContent[0];
            A421PageGJSHtml = BC001911_A421PageGJSHtml[0];
            n421PageGJSHtml = BC001911_n421PageGJSHtml[0];
            A422PageGJSJson = BC001911_A422PageGJSJson[0];
            n422PageGJSJson = BC001911_n422PageGJSJson[0];
            A423PageIsPublished = BC001911_A423PageIsPublished[0];
            n423PageIsPublished = BC001911_n423PageIsPublished[0];
            A492PageIsPredefined = BC001911_A492PageIsPredefined[0];
            A429PageIsContentPage = BC001911_A429PageIsContentPage[0];
            n429PageIsContentPage = BC001911_n429PageIsContentPage[0];
            A502PageIsDynamicForm = BC001911_A502PageIsDynamicForm[0];
            A505PageIsWebLinkPage = BC001911_A505PageIsWebLinkPage[0];
            A424PageChildren = BC001911_A424PageChildren[0];
            n424PageChildren = BC001911_n424PageChildren[0];
            A29LocationId = BC001911_A29LocationId[0];
            A11OrganisationId = BC001911_A11OrganisationId[0];
            A58ProductServiceId = BC001911_A58ProductServiceId[0];
            n58ProductServiceId = BC001911_n58ProductServiceId[0];
         }
         Gx_mode = sMode88;
      }

      protected void ScanKeyEnd1988( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1988( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1988( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1988( )
      {
         /* Before Update Rules */
         new loadaudittrn_page(context ).execute(  "Y", ref  AV34AuditingObject,  A392Trn_PageId,  A29LocationId,  Gx_mode) ;
      }

      protected void BeforeDelete1988( )
      {
         /* Before Delete Rules */
         new loadaudittrn_page(context ).execute(  "Y", ref  AV34AuditingObject,  A392Trn_PageId,  A29LocationId,  Gx_mode) ;
      }

      protected void BeforeComplete1988( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new loadaudittrn_page(context ).execute(  "N", ref  AV34AuditingObject,  A392Trn_PageId,  A29LocationId,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new loadaudittrn_page(context ).execute(  "N", ref  AV34AuditingObject,  A392Trn_PageId,  A29LocationId,  Gx_mode) ;
         }
      }

      protected void BeforeValidate1988( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1988( )
      {
      }

      protected void send_integrity_lvl_hashes1988( )
      {
      }

      protected void AddRow1988( )
      {
         VarsToRow88( bcTrn_Page) ;
      }

      protected void ReadRow1988( )
      {
         RowToVars88( bcTrn_Page, 1) ;
      }

      protected void InitializeNonKey1988( )
      {
         AV34AuditingObject = new WorkWithPlus.workwithplus_web.SdtAuditingObject(context);
         A397Trn_PageName = "";
         A420PageJsonContent = "";
         n420PageJsonContent = false;
         A421PageGJSHtml = "";
         n421PageGJSHtml = false;
         A422PageGJSJson = "";
         n422PageGJSJson = false;
         A505PageIsWebLinkPage = false;
         A424PageChildren = "";
         n424PageChildren = false;
         A58ProductServiceId = Guid.Empty;
         n58ProductServiceId = false;
         A11OrganisationId = Guid.Empty;
         A423PageIsPublished = false;
         n423PageIsPublished = false;
         A492PageIsPredefined = false;
         A429PageIsContentPage = false;
         n429PageIsContentPage = false;
         A502PageIsDynamicForm = false;
         Z397Trn_PageName = "";
         Z423PageIsPublished = false;
         Z492PageIsPredefined = false;
         Z429PageIsContentPage = false;
         Z502PageIsDynamicForm = false;
         Z505PageIsWebLinkPage = false;
         Z11OrganisationId = Guid.Empty;
         Z58ProductServiceId = Guid.Empty;
      }

      protected void InitAll1988( )
      {
         A392Trn_PageId = Guid.NewGuid( );
         A29LocationId = Guid.Empty;
         InitializeNonKey1988( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A502PageIsDynamicForm = i502PageIsDynamicForm;
         A429PageIsContentPage = i429PageIsContentPage;
         n429PageIsContentPage = false;
         A492PageIsPredefined = i492PageIsPredefined;
         A423PageIsPublished = i423PageIsPublished;
         n423PageIsPublished = false;
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

      public void VarsToRow88( SdtTrn_Page obj88 )
      {
         obj88.gxTpr_Mode = Gx_mode;
         obj88.gxTpr_Trn_pagename = A397Trn_PageName;
         obj88.gxTpr_Pagejsoncontent = A420PageJsonContent;
         obj88.gxTpr_Pagegjshtml = A421PageGJSHtml;
         obj88.gxTpr_Pagegjsjson = A422PageGJSJson;
         obj88.gxTpr_Pageisweblinkpage = A505PageIsWebLinkPage;
         obj88.gxTpr_Pagechildren = A424PageChildren;
         obj88.gxTpr_Productserviceid = A58ProductServiceId;
         obj88.gxTpr_Organisationid = A11OrganisationId;
         obj88.gxTpr_Pageispublished = A423PageIsPublished;
         obj88.gxTpr_Pageispredefined = A492PageIsPredefined;
         obj88.gxTpr_Pageiscontentpage = A429PageIsContentPage;
         obj88.gxTpr_Pageisdynamicform = A502PageIsDynamicForm;
         obj88.gxTpr_Trn_pageid = A392Trn_PageId;
         obj88.gxTpr_Locationid = A29LocationId;
         obj88.gxTpr_Trn_pageid_Z = Z392Trn_PageId;
         obj88.gxTpr_Trn_pagename_Z = Z397Trn_PageName;
         obj88.gxTpr_Locationid_Z = Z29LocationId;
         obj88.gxTpr_Pageispublished_Z = Z423PageIsPublished;
         obj88.gxTpr_Pageispredefined_Z = Z492PageIsPredefined;
         obj88.gxTpr_Pageiscontentpage_Z = Z429PageIsContentPage;
         obj88.gxTpr_Pageisdynamicform_Z = Z502PageIsDynamicForm;
         obj88.gxTpr_Pageisweblinkpage_Z = Z505PageIsWebLinkPage;
         obj88.gxTpr_Productserviceid_Z = Z58ProductServiceId;
         obj88.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj88.gxTpr_Pagejsoncontent_N = (short)(Convert.ToInt16(n420PageJsonContent));
         obj88.gxTpr_Pagegjshtml_N = (short)(Convert.ToInt16(n421PageGJSHtml));
         obj88.gxTpr_Pagegjsjson_N = (short)(Convert.ToInt16(n422PageGJSJson));
         obj88.gxTpr_Pageispublished_N = (short)(Convert.ToInt16(n423PageIsPublished));
         obj88.gxTpr_Pageiscontentpage_N = (short)(Convert.ToInt16(n429PageIsContentPage));
         obj88.gxTpr_Pagechildren_N = (short)(Convert.ToInt16(n424PageChildren));
         obj88.gxTpr_Productserviceid_N = (short)(Convert.ToInt16(n58ProductServiceId));
         obj88.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow88( SdtTrn_Page obj88 )
      {
         obj88.gxTpr_Trn_pageid = A392Trn_PageId;
         obj88.gxTpr_Locationid = A29LocationId;
         return  ;
      }

      public void RowToVars88( SdtTrn_Page obj88 ,
                               int forceLoad )
      {
         Gx_mode = obj88.gxTpr_Mode;
         A397Trn_PageName = obj88.gxTpr_Trn_pagename;
         A420PageJsonContent = obj88.gxTpr_Pagejsoncontent;
         n420PageJsonContent = false;
         A421PageGJSHtml = obj88.gxTpr_Pagegjshtml;
         n421PageGJSHtml = false;
         A422PageGJSJson = obj88.gxTpr_Pagegjsjson;
         n422PageGJSJson = false;
         A505PageIsWebLinkPage = obj88.gxTpr_Pageisweblinkpage;
         A424PageChildren = obj88.gxTpr_Pagechildren;
         n424PageChildren = false;
         A58ProductServiceId = obj88.gxTpr_Productserviceid;
         n58ProductServiceId = false;
         A11OrganisationId = obj88.gxTpr_Organisationid;
         A423PageIsPublished = obj88.gxTpr_Pageispublished;
         n423PageIsPublished = false;
         A492PageIsPredefined = obj88.gxTpr_Pageispredefined;
         A429PageIsContentPage = obj88.gxTpr_Pageiscontentpage;
         n429PageIsContentPage = false;
         A502PageIsDynamicForm = obj88.gxTpr_Pageisdynamicform;
         A392Trn_PageId = obj88.gxTpr_Trn_pageid;
         A29LocationId = obj88.gxTpr_Locationid;
         Z392Trn_PageId = obj88.gxTpr_Trn_pageid_Z;
         Z397Trn_PageName = obj88.gxTpr_Trn_pagename_Z;
         Z29LocationId = obj88.gxTpr_Locationid_Z;
         Z423PageIsPublished = obj88.gxTpr_Pageispublished_Z;
         Z492PageIsPredefined = obj88.gxTpr_Pageispredefined_Z;
         Z429PageIsContentPage = obj88.gxTpr_Pageiscontentpage_Z;
         Z502PageIsDynamicForm = obj88.gxTpr_Pageisdynamicform_Z;
         Z505PageIsWebLinkPage = obj88.gxTpr_Pageisweblinkpage_Z;
         Z58ProductServiceId = obj88.gxTpr_Productserviceid_Z;
         Z11OrganisationId = obj88.gxTpr_Organisationid_Z;
         n420PageJsonContent = (bool)(Convert.ToBoolean(obj88.gxTpr_Pagejsoncontent_N));
         n421PageGJSHtml = (bool)(Convert.ToBoolean(obj88.gxTpr_Pagegjshtml_N));
         n422PageGJSJson = (bool)(Convert.ToBoolean(obj88.gxTpr_Pagegjsjson_N));
         n423PageIsPublished = (bool)(Convert.ToBoolean(obj88.gxTpr_Pageispublished_N));
         n429PageIsContentPage = (bool)(Convert.ToBoolean(obj88.gxTpr_Pageiscontentpage_N));
         n424PageChildren = (bool)(Convert.ToBoolean(obj88.gxTpr_Pagechildren_N));
         n58ProductServiceId = (bool)(Convert.ToBoolean(obj88.gxTpr_Productserviceid_N));
         Gx_mode = obj88.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A392Trn_PageId = (Guid)getParm(obj,0);
         A29LocationId = (Guid)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1988( ) ;
         ScanKeyStart1988( ) ;
         if ( RcdFound88 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z392Trn_PageId = A392Trn_PageId;
            Z29LocationId = A29LocationId;
         }
         ZM1988( -19) ;
         OnLoadActions1988( ) ;
         AddRow1988( ) ;
         ScanKeyEnd1988( ) ;
         if ( RcdFound88 == 0 )
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
         RowToVars88( bcTrn_Page, 0) ;
         ScanKeyStart1988( ) ;
         if ( RcdFound88 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z392Trn_PageId = A392Trn_PageId;
            Z29LocationId = A29LocationId;
         }
         ZM1988( -19) ;
         OnLoadActions1988( ) ;
         AddRow1988( ) ;
         ScanKeyEnd1988( ) ;
         if ( RcdFound88 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1988( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1988( ) ;
         }
         else
         {
            if ( RcdFound88 == 1 )
            {
               if ( ( A392Trn_PageId != Z392Trn_PageId ) || ( A29LocationId != Z29LocationId ) )
               {
                  A392Trn_PageId = Z392Trn_PageId;
                  A29LocationId = Z29LocationId;
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
                  Update1988( ) ;
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
                  if ( ( A392Trn_PageId != Z392Trn_PageId ) || ( A29LocationId != Z29LocationId ) )
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
                        Insert1988( ) ;
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
                        Insert1988( ) ;
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
         RowToVars88( bcTrn_Page, 1) ;
         SaveImpl( ) ;
         VarsToRow88( bcTrn_Page) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars88( bcTrn_Page, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1988( ) ;
         AfterTrn( ) ;
         VarsToRow88( bcTrn_Page) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow88( bcTrn_Page) ;
         }
         else
         {
            SdtTrn_Page auxBC = new SdtTrn_Page(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A392Trn_PageId, A29LocationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Page);
               auxBC.Save();
               bcTrn_Page.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars88( bcTrn_Page, 1) ;
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
         RowToVars88( bcTrn_Page, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1988( ) ;
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
               VarsToRow88( bcTrn_Page) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow88( bcTrn_Page) ;
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
         RowToVars88( bcTrn_Page, 0) ;
         GetKey1988( ) ;
         if ( RcdFound88 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A392Trn_PageId != Z392Trn_PageId ) || ( A29LocationId != Z29LocationId ) )
            {
               A392Trn_PageId = Z392Trn_PageId;
               A29LocationId = Z29LocationId;
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
            if ( ( A392Trn_PageId != Z392Trn_PageId ) || ( A29LocationId != Z29LocationId ) )
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
         context.RollbackDataStores("trn_page_bc",pr_default);
         VarsToRow88( bcTrn_Page) ;
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
         Gx_mode = bcTrn_Page.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Page.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Page )
         {
            bcTrn_Page = (SdtTrn_Page)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Page.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Page.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow88( bcTrn_Page) ;
            }
            else
            {
               RowToVars88( bcTrn_Page, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Page.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Page.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars88( bcTrn_Page, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Page Trn_Page_BC
      {
         get {
            return bcTrn_Page ;
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
            return "trn_page_Execute" ;
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
         Z392Trn_PageId = Guid.Empty;
         A392Trn_PageId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV35Pgmname = "";
         AV15TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV16Insert_ProductServiceId = Guid.Empty;
         AV14Insert_OrganisationId = Guid.Empty;
         AV34AuditingObject = new WorkWithPlus.workwithplus_web.SdtAuditingObject(context);
         Z397Trn_PageName = "";
         A397Trn_PageName = "";
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         Z58ProductServiceId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         Z420PageJsonContent = "";
         A420PageJsonContent = "";
         Z421PageGJSHtml = "";
         A421PageGJSHtml = "";
         Z422PageGJSJson = "";
         A422PageGJSJson = "";
         Z424PageChildren = "";
         A424PageChildren = "";
         BC00196_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         BC00196_A397Trn_PageName = new string[] {""} ;
         BC00196_A420PageJsonContent = new string[] {""} ;
         BC00196_n420PageJsonContent = new bool[] {false} ;
         BC00196_A421PageGJSHtml = new string[] {""} ;
         BC00196_n421PageGJSHtml = new bool[] {false} ;
         BC00196_A422PageGJSJson = new string[] {""} ;
         BC00196_n422PageGJSJson = new bool[] {false} ;
         BC00196_A423PageIsPublished = new bool[] {false} ;
         BC00196_n423PageIsPublished = new bool[] {false} ;
         BC00196_A492PageIsPredefined = new bool[] {false} ;
         BC00196_A429PageIsContentPage = new bool[] {false} ;
         BC00196_n429PageIsContentPage = new bool[] {false} ;
         BC00196_A502PageIsDynamicForm = new bool[] {false} ;
         BC00196_A505PageIsWebLinkPage = new bool[] {false} ;
         BC00196_A424PageChildren = new string[] {""} ;
         BC00196_n424PageChildren = new bool[] {false} ;
         BC00196_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00196_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00196_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC00196_n58ProductServiceId = new bool[] {false} ;
         BC00194_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00195_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC00195_n58ProductServiceId = new bool[] {false} ;
         BC00197_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         BC00197_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00193_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         BC00193_A397Trn_PageName = new string[] {""} ;
         BC00193_A420PageJsonContent = new string[] {""} ;
         BC00193_n420PageJsonContent = new bool[] {false} ;
         BC00193_A421PageGJSHtml = new string[] {""} ;
         BC00193_n421PageGJSHtml = new bool[] {false} ;
         BC00193_A422PageGJSJson = new string[] {""} ;
         BC00193_n422PageGJSJson = new bool[] {false} ;
         BC00193_A423PageIsPublished = new bool[] {false} ;
         BC00193_n423PageIsPublished = new bool[] {false} ;
         BC00193_A492PageIsPredefined = new bool[] {false} ;
         BC00193_A429PageIsContentPage = new bool[] {false} ;
         BC00193_n429PageIsContentPage = new bool[] {false} ;
         BC00193_A502PageIsDynamicForm = new bool[] {false} ;
         BC00193_A505PageIsWebLinkPage = new bool[] {false} ;
         BC00193_A424PageChildren = new string[] {""} ;
         BC00193_n424PageChildren = new bool[] {false} ;
         BC00193_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00193_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00193_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC00193_n58ProductServiceId = new bool[] {false} ;
         sMode88 = "";
         BC00192_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         BC00192_A397Trn_PageName = new string[] {""} ;
         BC00192_A420PageJsonContent = new string[] {""} ;
         BC00192_n420PageJsonContent = new bool[] {false} ;
         BC00192_A421PageGJSHtml = new string[] {""} ;
         BC00192_n421PageGJSHtml = new bool[] {false} ;
         BC00192_A422PageGJSJson = new string[] {""} ;
         BC00192_n422PageGJSJson = new bool[] {false} ;
         BC00192_A423PageIsPublished = new bool[] {false} ;
         BC00192_n423PageIsPublished = new bool[] {false} ;
         BC00192_A492PageIsPredefined = new bool[] {false} ;
         BC00192_A429PageIsContentPage = new bool[] {false} ;
         BC00192_n429PageIsContentPage = new bool[] {false} ;
         BC00192_A502PageIsDynamicForm = new bool[] {false} ;
         BC00192_A505PageIsWebLinkPage = new bool[] {false} ;
         BC00192_A424PageChildren = new string[] {""} ;
         BC00192_n424PageChildren = new bool[] {false} ;
         BC00192_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00192_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00192_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC00192_n58ProductServiceId = new bool[] {false} ;
         BC001911_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         BC001911_A397Trn_PageName = new string[] {""} ;
         BC001911_A420PageJsonContent = new string[] {""} ;
         BC001911_n420PageJsonContent = new bool[] {false} ;
         BC001911_A421PageGJSHtml = new string[] {""} ;
         BC001911_n421PageGJSHtml = new bool[] {false} ;
         BC001911_A422PageGJSJson = new string[] {""} ;
         BC001911_n422PageGJSJson = new bool[] {false} ;
         BC001911_A423PageIsPublished = new bool[] {false} ;
         BC001911_n423PageIsPublished = new bool[] {false} ;
         BC001911_A492PageIsPredefined = new bool[] {false} ;
         BC001911_A429PageIsContentPage = new bool[] {false} ;
         BC001911_n429PageIsContentPage = new bool[] {false} ;
         BC001911_A502PageIsDynamicForm = new bool[] {false} ;
         BC001911_A505PageIsWebLinkPage = new bool[] {false} ;
         BC001911_A424PageChildren = new string[] {""} ;
         BC001911_n424PageChildren = new bool[] {false} ;
         BC001911_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001911_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001911_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC001911_n58ProductServiceId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_page_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_page_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_page_bc__default(),
            new Object[][] {
                new Object[] {
               BC00192_A392Trn_PageId, BC00192_A397Trn_PageName, BC00192_A420PageJsonContent, BC00192_n420PageJsonContent, BC00192_A421PageGJSHtml, BC00192_n421PageGJSHtml, BC00192_A422PageGJSJson, BC00192_n422PageGJSJson, BC00192_A423PageIsPublished, BC00192_n423PageIsPublished,
               BC00192_A492PageIsPredefined, BC00192_A429PageIsContentPage, BC00192_n429PageIsContentPage, BC00192_A502PageIsDynamicForm, BC00192_A505PageIsWebLinkPage, BC00192_A424PageChildren, BC00192_n424PageChildren, BC00192_A29LocationId, BC00192_A11OrganisationId, BC00192_A58ProductServiceId,
               BC00192_n58ProductServiceId
               }
               , new Object[] {
               BC00193_A392Trn_PageId, BC00193_A397Trn_PageName, BC00193_A420PageJsonContent, BC00193_n420PageJsonContent, BC00193_A421PageGJSHtml, BC00193_n421PageGJSHtml, BC00193_A422PageGJSJson, BC00193_n422PageGJSJson, BC00193_A423PageIsPublished, BC00193_n423PageIsPublished,
               BC00193_A492PageIsPredefined, BC00193_A429PageIsContentPage, BC00193_n429PageIsContentPage, BC00193_A502PageIsDynamicForm, BC00193_A505PageIsWebLinkPage, BC00193_A424PageChildren, BC00193_n424PageChildren, BC00193_A29LocationId, BC00193_A11OrganisationId, BC00193_A58ProductServiceId,
               BC00193_n58ProductServiceId
               }
               , new Object[] {
               BC00194_A29LocationId
               }
               , new Object[] {
               BC00195_A58ProductServiceId
               }
               , new Object[] {
               BC00196_A392Trn_PageId, BC00196_A397Trn_PageName, BC00196_A420PageJsonContent, BC00196_n420PageJsonContent, BC00196_A421PageGJSHtml, BC00196_n421PageGJSHtml, BC00196_A422PageGJSJson, BC00196_n422PageGJSJson, BC00196_A423PageIsPublished, BC00196_n423PageIsPublished,
               BC00196_A492PageIsPredefined, BC00196_A429PageIsContentPage, BC00196_n429PageIsContentPage, BC00196_A502PageIsDynamicForm, BC00196_A505PageIsWebLinkPage, BC00196_A424PageChildren, BC00196_n424PageChildren, BC00196_A29LocationId, BC00196_A11OrganisationId, BC00196_A58ProductServiceId,
               BC00196_n58ProductServiceId
               }
               , new Object[] {
               BC00197_A392Trn_PageId, BC00197_A29LocationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001911_A392Trn_PageId, BC001911_A397Trn_PageName, BC001911_A420PageJsonContent, BC001911_n420PageJsonContent, BC001911_A421PageGJSHtml, BC001911_n421PageGJSHtml, BC001911_A422PageGJSJson, BC001911_n422PageGJSJson, BC001911_A423PageIsPublished, BC001911_n423PageIsPublished,
               BC001911_A492PageIsPredefined, BC001911_A429PageIsContentPage, BC001911_n429PageIsContentPage, BC001911_A502PageIsDynamicForm, BC001911_A505PageIsWebLinkPage, BC001911_A424PageChildren, BC001911_n424PageChildren, BC001911_A29LocationId, BC001911_A11OrganisationId, BC001911_A58ProductServiceId,
               BC001911_n58ProductServiceId
               }
            }
         );
         Z502PageIsDynamicForm = false;
         A502PageIsDynamicForm = false;
         i502PageIsDynamicForm = false;
         Z429PageIsContentPage = false;
         n429PageIsContentPage = false;
         A429PageIsContentPage = false;
         n429PageIsContentPage = false;
         i429PageIsContentPage = false;
         n429PageIsContentPage = false;
         Z492PageIsPredefined = false;
         A492PageIsPredefined = false;
         i492PageIsPredefined = false;
         Z423PageIsPublished = false;
         n423PageIsPublished = false;
         A423PageIsPublished = false;
         n423PageIsPublished = false;
         i423PageIsPublished = false;
         n423PageIsPublished = false;
         Z392Trn_PageId = Guid.NewGuid( );
         A392Trn_PageId = Guid.NewGuid( );
         AV35Pgmname = "Trn_Page_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12192 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound88 ;
      private int trnEnded ;
      private int AV36GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV35Pgmname ;
      private string sMode88 ;
      private bool returnInSub ;
      private bool Z423PageIsPublished ;
      private bool A423PageIsPublished ;
      private bool Z492PageIsPredefined ;
      private bool A492PageIsPredefined ;
      private bool Z429PageIsContentPage ;
      private bool A429PageIsContentPage ;
      private bool Z502PageIsDynamicForm ;
      private bool A502PageIsDynamicForm ;
      private bool Z505PageIsWebLinkPage ;
      private bool A505PageIsWebLinkPage ;
      private bool n429PageIsContentPage ;
      private bool n423PageIsPublished ;
      private bool n420PageJsonContent ;
      private bool n421PageGJSHtml ;
      private bool n422PageGJSJson ;
      private bool n424PageChildren ;
      private bool n58ProductServiceId ;
      private bool Gx_longc ;
      private bool i502PageIsDynamicForm ;
      private bool i429PageIsContentPage ;
      private bool i492PageIsPredefined ;
      private bool i423PageIsPublished ;
      private string Z420PageJsonContent ;
      private string A420PageJsonContent ;
      private string Z421PageGJSHtml ;
      private string A421PageGJSHtml ;
      private string Z422PageGJSJson ;
      private string A422PageGJSJson ;
      private string Z424PageChildren ;
      private string A424PageChildren ;
      private string Z397Trn_PageName ;
      private string A397Trn_PageName ;
      private Guid Z392Trn_PageId ;
      private Guid A392Trn_PageId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid AV16Insert_ProductServiceId ;
      private Guid AV14Insert_OrganisationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid Z58ProductServiceId ;
      private Guid A58ProductServiceId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private WorkWithPlus.workwithplus_web.SdtAuditingObject AV34AuditingObject ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00196_A392Trn_PageId ;
      private string[] BC00196_A397Trn_PageName ;
      private string[] BC00196_A420PageJsonContent ;
      private bool[] BC00196_n420PageJsonContent ;
      private string[] BC00196_A421PageGJSHtml ;
      private bool[] BC00196_n421PageGJSHtml ;
      private string[] BC00196_A422PageGJSJson ;
      private bool[] BC00196_n422PageGJSJson ;
      private bool[] BC00196_A423PageIsPublished ;
      private bool[] BC00196_n423PageIsPublished ;
      private bool[] BC00196_A492PageIsPredefined ;
      private bool[] BC00196_A429PageIsContentPage ;
      private bool[] BC00196_n429PageIsContentPage ;
      private bool[] BC00196_A502PageIsDynamicForm ;
      private bool[] BC00196_A505PageIsWebLinkPage ;
      private string[] BC00196_A424PageChildren ;
      private bool[] BC00196_n424PageChildren ;
      private Guid[] BC00196_A29LocationId ;
      private Guid[] BC00196_A11OrganisationId ;
      private Guid[] BC00196_A58ProductServiceId ;
      private bool[] BC00196_n58ProductServiceId ;
      private Guid[] BC00194_A29LocationId ;
      private Guid[] BC00195_A58ProductServiceId ;
      private bool[] BC00195_n58ProductServiceId ;
      private Guid[] BC00197_A392Trn_PageId ;
      private Guid[] BC00197_A29LocationId ;
      private Guid[] BC00193_A392Trn_PageId ;
      private string[] BC00193_A397Trn_PageName ;
      private string[] BC00193_A420PageJsonContent ;
      private bool[] BC00193_n420PageJsonContent ;
      private string[] BC00193_A421PageGJSHtml ;
      private bool[] BC00193_n421PageGJSHtml ;
      private string[] BC00193_A422PageGJSJson ;
      private bool[] BC00193_n422PageGJSJson ;
      private bool[] BC00193_A423PageIsPublished ;
      private bool[] BC00193_n423PageIsPublished ;
      private bool[] BC00193_A492PageIsPredefined ;
      private bool[] BC00193_A429PageIsContentPage ;
      private bool[] BC00193_n429PageIsContentPage ;
      private bool[] BC00193_A502PageIsDynamicForm ;
      private bool[] BC00193_A505PageIsWebLinkPage ;
      private string[] BC00193_A424PageChildren ;
      private bool[] BC00193_n424PageChildren ;
      private Guid[] BC00193_A29LocationId ;
      private Guid[] BC00193_A11OrganisationId ;
      private Guid[] BC00193_A58ProductServiceId ;
      private bool[] BC00193_n58ProductServiceId ;
      private Guid[] BC00192_A392Trn_PageId ;
      private string[] BC00192_A397Trn_PageName ;
      private string[] BC00192_A420PageJsonContent ;
      private bool[] BC00192_n420PageJsonContent ;
      private string[] BC00192_A421PageGJSHtml ;
      private bool[] BC00192_n421PageGJSHtml ;
      private string[] BC00192_A422PageGJSJson ;
      private bool[] BC00192_n422PageGJSJson ;
      private bool[] BC00192_A423PageIsPublished ;
      private bool[] BC00192_n423PageIsPublished ;
      private bool[] BC00192_A492PageIsPredefined ;
      private bool[] BC00192_A429PageIsContentPage ;
      private bool[] BC00192_n429PageIsContentPage ;
      private bool[] BC00192_A502PageIsDynamicForm ;
      private bool[] BC00192_A505PageIsWebLinkPage ;
      private string[] BC00192_A424PageChildren ;
      private bool[] BC00192_n424PageChildren ;
      private Guid[] BC00192_A29LocationId ;
      private Guid[] BC00192_A11OrganisationId ;
      private Guid[] BC00192_A58ProductServiceId ;
      private bool[] BC00192_n58ProductServiceId ;
      private Guid[] BC001911_A392Trn_PageId ;
      private string[] BC001911_A397Trn_PageName ;
      private string[] BC001911_A420PageJsonContent ;
      private bool[] BC001911_n420PageJsonContent ;
      private string[] BC001911_A421PageGJSHtml ;
      private bool[] BC001911_n421PageGJSHtml ;
      private string[] BC001911_A422PageGJSJson ;
      private bool[] BC001911_n422PageGJSJson ;
      private bool[] BC001911_A423PageIsPublished ;
      private bool[] BC001911_n423PageIsPublished ;
      private bool[] BC001911_A492PageIsPredefined ;
      private bool[] BC001911_A429PageIsContentPage ;
      private bool[] BC001911_n429PageIsContentPage ;
      private bool[] BC001911_A502PageIsDynamicForm ;
      private bool[] BC001911_A505PageIsWebLinkPage ;
      private string[] BC001911_A424PageChildren ;
      private bool[] BC001911_n424PageChildren ;
      private Guid[] BC001911_A29LocationId ;
      private Guid[] BC001911_A11OrganisationId ;
      private Guid[] BC001911_A58ProductServiceId ;
      private bool[] BC001911_n58ProductServiceId ;
      private SdtTrn_Page bcTrn_Page ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_page_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_page_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_page_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[8])
      ,new ForEachCursor(def[9])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC00192;
       prmBC00192 = new Object[] {
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00193;
       prmBC00193 = new Object[] {
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00194;
       prmBC00194 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00195;
       prmBC00195 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00196;
       prmBC00196 = new Object[] {
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00197;
       prmBC00197 = new Object[] {
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00198;
       prmBC00198 = new Object[] {
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
       new ParDef("PageJsonContent",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("PageGJSHtml",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("PageGJSJson",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("PageIsPublished",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("PageIsPredefined",GXType.Boolean,4,0) ,
       new ParDef("PageIsContentPage",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("PageIsDynamicForm",GXType.Boolean,4,0) ,
       new ParDef("PageIsWebLinkPage",GXType.Boolean,4,0) ,
       new ParDef("PageChildren",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00199;
       prmBC00199 = new Object[] {
       new ParDef("Trn_PageName",GXType.VarChar,100,0) ,
       new ParDef("PageJsonContent",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("PageGJSHtml",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("PageGJSJson",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("PageIsPublished",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("PageIsPredefined",GXType.Boolean,4,0) ,
       new ParDef("PageIsContentPage",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("PageIsDynamicForm",GXType.Boolean,4,0) ,
       new ParDef("PageIsWebLinkPage",GXType.Boolean,4,0) ,
       new ParDef("PageChildren",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001910;
       prmBC001910 = new Object[] {
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001911;
       prmBC001911 = new Object[] {
       new ParDef("Trn_PageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC00192", "SELECT Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, PageIsPredefined, PageIsContentPage, PageIsDynamicForm, PageIsWebLinkPage, PageChildren, LocationId, OrganisationId, ProductServiceId FROM Trn_Page WHERE Trn_PageId = :Trn_PageId AND LocationId = :LocationId  FOR UPDATE OF Trn_Page",true, GxErrorMask.GX_NOMASK, false, this,prmBC00192,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00193", "SELECT Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, PageIsPredefined, PageIsContentPage, PageIsDynamicForm, PageIsWebLinkPage, PageChildren, LocationId, OrganisationId, ProductServiceId FROM Trn_Page WHERE Trn_PageId = :Trn_PageId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00193,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00194", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00194,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00195", "SELECT ProductServiceId FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00195,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00196", "SELECT TM1.Trn_PageId, TM1.Trn_PageName, TM1.PageJsonContent, TM1.PageGJSHtml, TM1.PageGJSJson, TM1.PageIsPublished, TM1.PageIsPredefined, TM1.PageIsContentPage, TM1.PageIsDynamicForm, TM1.PageIsWebLinkPage, TM1.PageChildren, TM1.LocationId, TM1.OrganisationId, TM1.ProductServiceId FROM Trn_Page TM1 WHERE TM1.Trn_PageId = :Trn_PageId and TM1.LocationId = :LocationId ORDER BY TM1.Trn_PageId, TM1.LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00196,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00197", "SELECT Trn_PageId, LocationId FROM Trn_Page WHERE Trn_PageId = :Trn_PageId AND LocationId = :LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00197,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00198", "SAVEPOINT gxupdate;INSERT INTO Trn_Page(Trn_PageId, Trn_PageName, PageJsonContent, PageGJSHtml, PageGJSJson, PageIsPublished, PageIsPredefined, PageIsContentPage, PageIsDynamicForm, PageIsWebLinkPage, PageChildren, LocationId, OrganisationId, ProductServiceId) VALUES(:Trn_PageId, :Trn_PageName, :PageJsonContent, :PageGJSHtml, :PageGJSJson, :PageIsPublished, :PageIsPredefined, :PageIsContentPage, :PageIsDynamicForm, :PageIsWebLinkPage, :PageChildren, :LocationId, :OrganisationId, :ProductServiceId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00198)
          ,new CursorDef("BC00199", "SAVEPOINT gxupdate;UPDATE Trn_Page SET Trn_PageName=:Trn_PageName, PageJsonContent=:PageJsonContent, PageGJSHtml=:PageGJSHtml, PageGJSJson=:PageGJSJson, PageIsPublished=:PageIsPublished, PageIsPredefined=:PageIsPredefined, PageIsContentPage=:PageIsContentPage, PageIsDynamicForm=:PageIsDynamicForm, PageIsWebLinkPage=:PageIsWebLinkPage, PageChildren=:PageChildren, OrganisationId=:OrganisationId, ProductServiceId=:ProductServiceId  WHERE Trn_PageId = :Trn_PageId AND LocationId = :LocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00199)
          ,new CursorDef("BC001910", "SAVEPOINT gxupdate;DELETE FROM Trn_Page  WHERE Trn_PageId = :Trn_PageId AND LocationId = :LocationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001910)
          ,new CursorDef("BC001911", "SELECT TM1.Trn_PageId, TM1.Trn_PageName, TM1.PageJsonContent, TM1.PageGJSHtml, TM1.PageGJSJson, TM1.PageIsPublished, TM1.PageIsPredefined, TM1.PageIsContentPage, TM1.PageIsDynamicForm, TM1.PageIsWebLinkPage, TM1.PageChildren, TM1.LocationId, TM1.OrganisationId, TM1.ProductServiceId FROM Trn_Page TM1 WHERE TM1.Trn_PageId = :Trn_PageId and TM1.LocationId = :LocationId ORDER BY TM1.Trn_PageId, TM1.LocationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001911,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[5])[0] = rslt.wasNull(4);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[7])[0] = rslt.wasNull(5);
             ((bool[]) buf[8])[0] = rslt.getBool(6);
             ((bool[]) buf[9])[0] = rslt.wasNull(6);
             ((bool[]) buf[10])[0] = rslt.getBool(7);
             ((bool[]) buf[11])[0] = rslt.getBool(8);
             ((bool[]) buf[12])[0] = rslt.wasNull(8);
             ((bool[]) buf[13])[0] = rslt.getBool(9);
             ((bool[]) buf[14])[0] = rslt.getBool(10);
             ((string[]) buf[15])[0] = rslt.getLongVarchar(11);
             ((bool[]) buf[16])[0] = rslt.wasNull(11);
             ((Guid[]) buf[17])[0] = rslt.getGuid(12);
             ((Guid[]) buf[18])[0] = rslt.getGuid(13);
             ((Guid[]) buf[19])[0] = rslt.getGuid(14);
             ((bool[]) buf[20])[0] = rslt.wasNull(14);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[5])[0] = rslt.wasNull(4);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[7])[0] = rslt.wasNull(5);
             ((bool[]) buf[8])[0] = rslt.getBool(6);
             ((bool[]) buf[9])[0] = rslt.wasNull(6);
             ((bool[]) buf[10])[0] = rslt.getBool(7);
             ((bool[]) buf[11])[0] = rslt.getBool(8);
             ((bool[]) buf[12])[0] = rslt.wasNull(8);
             ((bool[]) buf[13])[0] = rslt.getBool(9);
             ((bool[]) buf[14])[0] = rslt.getBool(10);
             ((string[]) buf[15])[0] = rslt.getLongVarchar(11);
             ((bool[]) buf[16])[0] = rslt.wasNull(11);
             ((Guid[]) buf[17])[0] = rslt.getGuid(12);
             ((Guid[]) buf[18])[0] = rslt.getGuid(13);
             ((Guid[]) buf[19])[0] = rslt.getGuid(14);
             ((bool[]) buf[20])[0] = rslt.wasNull(14);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[5])[0] = rslt.wasNull(4);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[7])[0] = rslt.wasNull(5);
             ((bool[]) buf[8])[0] = rslt.getBool(6);
             ((bool[]) buf[9])[0] = rslt.wasNull(6);
             ((bool[]) buf[10])[0] = rslt.getBool(7);
             ((bool[]) buf[11])[0] = rslt.getBool(8);
             ((bool[]) buf[12])[0] = rslt.wasNull(8);
             ((bool[]) buf[13])[0] = rslt.getBool(9);
             ((bool[]) buf[14])[0] = rslt.getBool(10);
             ((string[]) buf[15])[0] = rslt.getLongVarchar(11);
             ((bool[]) buf[16])[0] = rslt.wasNull(11);
             ((Guid[]) buf[17])[0] = rslt.getGuid(12);
             ((Guid[]) buf[18])[0] = rslt.getGuid(13);
             ((Guid[]) buf[19])[0] = rslt.getGuid(14);
             ((bool[]) buf[20])[0] = rslt.wasNull(14);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[5])[0] = rslt.wasNull(4);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(5);
             ((bool[]) buf[7])[0] = rslt.wasNull(5);
             ((bool[]) buf[8])[0] = rslt.getBool(6);
             ((bool[]) buf[9])[0] = rslt.wasNull(6);
             ((bool[]) buf[10])[0] = rslt.getBool(7);
             ((bool[]) buf[11])[0] = rslt.getBool(8);
             ((bool[]) buf[12])[0] = rslt.wasNull(8);
             ((bool[]) buf[13])[0] = rslt.getBool(9);
             ((bool[]) buf[14])[0] = rslt.getBool(10);
             ((string[]) buf[15])[0] = rslt.getLongVarchar(11);
             ((bool[]) buf[16])[0] = rslt.wasNull(11);
             ((Guid[]) buf[17])[0] = rslt.getGuid(12);
             ((Guid[]) buf[18])[0] = rslt.getGuid(13);
             ((Guid[]) buf[19])[0] = rslt.getGuid(14);
             ((bool[]) buf[20])[0] = rslt.wasNull(14);
             return;
    }
 }

}

}
