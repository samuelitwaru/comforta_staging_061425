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
   public class trn_discussiontranslation : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetNextPar( );
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         GXKey = Crypto.GetSiteKey( );
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Trn_Discussion Translation", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTrn_DiscussionTranslationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trn_discussiontranslation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_discussiontranslation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
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
            return "trn_discussiontranslation_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         cleanup();
      }

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Trn_DiscussionTranslation.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTrn_DiscussionTranslationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrn_DiscussionTranslationId_Internalname, context.GetMessage( "Translation Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrn_DiscussionTranslationId_Internalname, A593Trn_DiscussionTranslationId.ToString(), A593Trn_DiscussionTranslationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrn_DiscussionTranslationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrn_DiscussionTranslationId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_Trn_DiscussionTranslation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDiscussionTranslationWWPDiscus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDiscussionTranslationWWPDiscus_Internalname, context.GetMessage( "Message Id", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDiscussionTranslationWWPDiscus_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A594DiscussionTranslationWWPDiscus), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtDiscussionTranslationWWPDiscus_Enabled!=0) ? context.localUtil.Format( (decimal)(A594DiscussionTranslationWWPDiscus), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A594DiscussionTranslationWWPDiscus), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDiscussionTranslationWWPDiscus_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDiscussionTranslationWWPDiscus_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Trn_DiscussionTranslation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDiscussionTranslationEnglish_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDiscussionTranslationEnglish_Internalname, context.GetMessage( "Translation English", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDiscussionTranslationEnglish_Internalname, A595DiscussionTranslationEnglish, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", 0, 1, edtDiscussionTranslationEnglish_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_DiscussionTranslation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDiscussionTranslationDutch_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDiscussionTranslationDutch_Internalname, context.GetMessage( "Translation Dutch", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDiscussionTranslationDutch_Internalname, A596DiscussionTranslationDutch, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", 0, 1, edtDiscussionTranslationDutch_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Trn_DiscussionTranslation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</fieldset>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_DiscussionTranslation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_DiscussionTranslation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_DiscussionTranslation.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E111S2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z593Trn_DiscussionTranslationId = StringUtil.StrToGuid( cgiGet( "Z593Trn_DiscussionTranslationId"));
               Z594DiscussionTranslationWWPDiscus = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z594DiscussionTranslationWWPDiscus"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z595DiscussionTranslationEnglish = cgiGet( "Z595DiscussionTranslationEnglish");
               Z596DiscussionTranslationDutch = cgiGet( "Z596DiscussionTranslationDutch");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               if ( StringUtil.StrCmp(cgiGet( edtTrn_DiscussionTranslationId_Internalname), "") == 0 )
               {
                  A593Trn_DiscussionTranslationId = Guid.Empty;
                  AssignAttri("", false, "A593Trn_DiscussionTranslationId", A593Trn_DiscussionTranslationId.ToString());
               }
               else
               {
                  try
                  {
                     A593Trn_DiscussionTranslationId = StringUtil.StrToGuid( cgiGet( edtTrn_DiscussionTranslationId_Internalname));
                     AssignAttri("", false, "A593Trn_DiscussionTranslationId", A593Trn_DiscussionTranslationId.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "TRN_DISCUSSIONTRANSLATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_DiscussionTranslationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtDiscussionTranslationWWPDiscus_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDiscussionTranslationWWPDiscus_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DISCUSSIONTRANSLATIONWWPDISCUS");
                  AnyError = 1;
                  GX_FocusControl = edtDiscussionTranslationWWPDiscus_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A594DiscussionTranslationWWPDiscus = 0;
                  AssignAttri("", false, "A594DiscussionTranslationWWPDiscus", StringUtil.LTrimStr( (decimal)(A594DiscussionTranslationWWPDiscus), 10, 0));
               }
               else
               {
                  A594DiscussionTranslationWWPDiscus = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDiscussionTranslationWWPDiscus_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A594DiscussionTranslationWWPDiscus", StringUtil.LTrimStr( (decimal)(A594DiscussionTranslationWWPDiscus), 10, 0));
               }
               A595DiscussionTranslationEnglish = cgiGet( edtDiscussionTranslationEnglish_Internalname);
               AssignAttri("", false, "A595DiscussionTranslationEnglish", A595DiscussionTranslationEnglish);
               A596DiscussionTranslationDutch = cgiGet( edtDiscussionTranslationDutch_Internalname);
               AssignAttri("", false, "A596DiscussionTranslationDutch", A596DiscussionTranslationDutch);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A593Trn_DiscussionTranslationId = StringUtil.StrToGuid( GetPar( "Trn_DiscussionTranslationId"));
                  AssignAttri("", false, "A593Trn_DiscussionTranslationId", A593Trn_DiscussionTranslationId.ToString());
                  getEqualNoModal( ) ;
                  if ( IsIns( )  && (Guid.Empty==A593Trn_DiscussionTranslationId) && ( Gx_BScreen == 0 ) )
                  {
                     A593Trn_DiscussionTranslationId = Guid.NewGuid( );
                     AssignAttri("", false, "A593Trn_DiscussionTranslationId", A593Trn_DiscussionTranslationId.ToString());
                  }
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons_dsp( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  getEqualNoModal( ) ;
                  standaloneModal( ) ;
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E111S2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121S2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
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
            E121S2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1S103( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
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

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtntrn_delete_Enabled = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtntrn_enter_Visible = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
         }
         DisableAttributes1S103( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption1S0( )
      {
      }

      protected void E111S2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E121S2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1S103( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z594DiscussionTranslationWWPDiscus = T001S3_A594DiscussionTranslationWWPDiscus[0];
               Z595DiscussionTranslationEnglish = T001S3_A595DiscussionTranslationEnglish[0];
               Z596DiscussionTranslationDutch = T001S3_A596DiscussionTranslationDutch[0];
            }
            else
            {
               Z594DiscussionTranslationWWPDiscus = A594DiscussionTranslationWWPDiscus;
               Z595DiscussionTranslationEnglish = A595DiscussionTranslationEnglish;
               Z596DiscussionTranslationDutch = A596DiscussionTranslationDutch;
            }
         }
         if ( GX_JID == -3 )
         {
            Z593Trn_DiscussionTranslationId = A593Trn_DiscussionTranslationId;
            Z594DiscussionTranslationWWPDiscus = A594DiscussionTranslationWWPDiscus;
            Z595DiscussionTranslationEnglish = A595DiscussionTranslationEnglish;
            Z596DiscussionTranslationDutch = A596DiscussionTranslationDutch;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A593Trn_DiscussionTranslationId) && ( Gx_BScreen == 0 ) )
         {
            A593Trn_DiscussionTranslationId = Guid.NewGuid( );
            AssignAttri("", false, "A593Trn_DiscussionTranslationId", A593Trn_DiscussionTranslationId.ToString());
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtntrn_delete_Enabled = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_delete_Enabled = 1;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1S103( )
      {
         /* Using cursor T001S4 */
         pr_default.execute(2, new Object[] {A593Trn_DiscussionTranslationId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound103 = 1;
            A594DiscussionTranslationWWPDiscus = T001S4_A594DiscussionTranslationWWPDiscus[0];
            AssignAttri("", false, "A594DiscussionTranslationWWPDiscus", StringUtil.LTrimStr( (decimal)(A594DiscussionTranslationWWPDiscus), 10, 0));
            A595DiscussionTranslationEnglish = T001S4_A595DiscussionTranslationEnglish[0];
            AssignAttri("", false, "A595DiscussionTranslationEnglish", A595DiscussionTranslationEnglish);
            A596DiscussionTranslationDutch = T001S4_A596DiscussionTranslationDutch[0];
            AssignAttri("", false, "A596DiscussionTranslationDutch", A596DiscussionTranslationDutch);
            ZM1S103( -3) ;
         }
         pr_default.close(2);
         OnLoadActions1S103( ) ;
      }

      protected void OnLoadActions1S103( )
      {
      }

      protected void CheckExtendedTable1S103( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1S103( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1S103( )
      {
         /* Using cursor T001S5 */
         pr_default.execute(3, new Object[] {A593Trn_DiscussionTranslationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound103 = 1;
         }
         else
         {
            RcdFound103 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001S3 */
         pr_default.execute(1, new Object[] {A593Trn_DiscussionTranslationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1S103( 3) ;
            RcdFound103 = 1;
            A593Trn_DiscussionTranslationId = T001S3_A593Trn_DiscussionTranslationId[0];
            AssignAttri("", false, "A593Trn_DiscussionTranslationId", A593Trn_DiscussionTranslationId.ToString());
            A594DiscussionTranslationWWPDiscus = T001S3_A594DiscussionTranslationWWPDiscus[0];
            AssignAttri("", false, "A594DiscussionTranslationWWPDiscus", StringUtil.LTrimStr( (decimal)(A594DiscussionTranslationWWPDiscus), 10, 0));
            A595DiscussionTranslationEnglish = T001S3_A595DiscussionTranslationEnglish[0];
            AssignAttri("", false, "A595DiscussionTranslationEnglish", A595DiscussionTranslationEnglish);
            A596DiscussionTranslationDutch = T001S3_A596DiscussionTranslationDutch[0];
            AssignAttri("", false, "A596DiscussionTranslationDutch", A596DiscussionTranslationDutch);
            Z593Trn_DiscussionTranslationId = A593Trn_DiscussionTranslationId;
            sMode103 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1S103( ) ;
            if ( AnyError == 1 )
            {
               RcdFound103 = 0;
               InitializeNonKey1S103( ) ;
            }
            Gx_mode = sMode103;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound103 = 0;
            InitializeNonKey1S103( ) ;
            sMode103 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode103;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1S103( ) ;
         if ( RcdFound103 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound103 = 0;
         /* Using cursor T001S6 */
         pr_default.execute(4, new Object[] {A593Trn_DiscussionTranslationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T001S6_A593Trn_DiscussionTranslationId[0], A593Trn_DiscussionTranslationId, 0) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T001S6_A593Trn_DiscussionTranslationId[0], A593Trn_DiscussionTranslationId, 0) > 0 ) ) )
            {
               A593Trn_DiscussionTranslationId = T001S6_A593Trn_DiscussionTranslationId[0];
               AssignAttri("", false, "A593Trn_DiscussionTranslationId", A593Trn_DiscussionTranslationId.ToString());
               RcdFound103 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound103 = 0;
         /* Using cursor T001S7 */
         pr_default.execute(5, new Object[] {A593Trn_DiscussionTranslationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T001S7_A593Trn_DiscussionTranslationId[0], A593Trn_DiscussionTranslationId, 0) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T001S7_A593Trn_DiscussionTranslationId[0], A593Trn_DiscussionTranslationId, 0) < 0 ) ) )
            {
               A593Trn_DiscussionTranslationId = T001S7_A593Trn_DiscussionTranslationId[0];
               AssignAttri("", false, "A593Trn_DiscussionTranslationId", A593Trn_DiscussionTranslationId.ToString());
               RcdFound103 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1S103( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTrn_DiscussionTranslationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1S103( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound103 == 1 )
            {
               if ( A593Trn_DiscussionTranslationId != Z593Trn_DiscussionTranslationId )
               {
                  A593Trn_DiscussionTranslationId = Z593Trn_DiscussionTranslationId;
                  AssignAttri("", false, "A593Trn_DiscussionTranslationId", A593Trn_DiscussionTranslationId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRN_DISCUSSIONTRANSLATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtTrn_DiscussionTranslationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTrn_DiscussionTranslationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1S103( ) ;
                  GX_FocusControl = edtTrn_DiscussionTranslationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A593Trn_DiscussionTranslationId != Z593Trn_DiscussionTranslationId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTrn_DiscussionTranslationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1S103( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRN_DISCUSSIONTRANSLATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtTrn_DiscussionTranslationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTrn_DiscussionTranslationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1S103( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A593Trn_DiscussionTranslationId != Z593Trn_DiscussionTranslationId )
         {
            A593Trn_DiscussionTranslationId = Z593Trn_DiscussionTranslationId;
            AssignAttri("", false, "A593Trn_DiscussionTranslationId", A593Trn_DiscussionTranslationId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRN_DISCUSSIONTRANSLATIONID");
            AnyError = 1;
            GX_FocusControl = edtTrn_DiscussionTranslationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTrn_DiscussionTranslationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound103 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TRN_DISCUSSIONTRANSLATIONID");
            AnyError = 1;
            GX_FocusControl = edtTrn_DiscussionTranslationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtDiscussionTranslationWWPDiscus_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1S103( ) ;
         if ( RcdFound103 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtDiscussionTranslationWWPDiscus_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1S103( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound103 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtDiscussionTranslationWWPDiscus_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound103 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtDiscussionTranslationWWPDiscus_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1S103( ) ;
         if ( RcdFound103 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound103 != 0 )
            {
               ScanNext1S103( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtDiscussionTranslationWWPDiscus_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1S103( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1S103( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001S2 */
            pr_default.execute(0, new Object[] {A593Trn_DiscussionTranslationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_DiscussionTranslation"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z594DiscussionTranslationWWPDiscus != T001S2_A594DiscussionTranslationWWPDiscus[0] ) || ( StringUtil.StrCmp(Z595DiscussionTranslationEnglish, T001S2_A595DiscussionTranslationEnglish[0]) != 0 ) || ( StringUtil.StrCmp(Z596DiscussionTranslationDutch, T001S2_A596DiscussionTranslationDutch[0]) != 0 ) )
            {
               if ( Z594DiscussionTranslationWWPDiscus != T001S2_A594DiscussionTranslationWWPDiscus[0] )
               {
                  GXUtil.WriteLog("trn_discussiontranslation:[seudo value changed for attri]"+"DiscussionTranslationWWPDiscus");
                  GXUtil.WriteLogRaw("Old: ",Z594DiscussionTranslationWWPDiscus);
                  GXUtil.WriteLogRaw("Current: ",T001S2_A594DiscussionTranslationWWPDiscus[0]);
               }
               if ( StringUtil.StrCmp(Z595DiscussionTranslationEnglish, T001S2_A595DiscussionTranslationEnglish[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_discussiontranslation:[seudo value changed for attri]"+"DiscussionTranslationEnglish");
                  GXUtil.WriteLogRaw("Old: ",Z595DiscussionTranslationEnglish);
                  GXUtil.WriteLogRaw("Current: ",T001S2_A595DiscussionTranslationEnglish[0]);
               }
               if ( StringUtil.StrCmp(Z596DiscussionTranslationDutch, T001S2_A596DiscussionTranslationDutch[0]) != 0 )
               {
                  GXUtil.WriteLog("trn_discussiontranslation:[seudo value changed for attri]"+"DiscussionTranslationDutch");
                  GXUtil.WriteLogRaw("Old: ",Z596DiscussionTranslationDutch);
                  GXUtil.WriteLogRaw("Current: ",T001S2_A596DiscussionTranslationDutch[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_DiscussionTranslation"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1S103( )
      {
         if ( ! IsAuthorized("trn_discussiontranslation_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1S103( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1S103( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1S103( 0) ;
            CheckOptimisticConcurrency1S103( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1S103( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1S103( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001S8 */
                     pr_default.execute(6, new Object[] {A593Trn_DiscussionTranslationId, A594DiscussionTranslationWWPDiscus, A595DiscussionTranslationEnglish, A596DiscussionTranslationDutch});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_DiscussionTranslation");
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
                           ResetCaption1S0( ) ;
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
               Load1S103( ) ;
            }
            EndLevel1S103( ) ;
         }
         CloseExtendedTableCursors1S103( ) ;
      }

      protected void Update1S103( )
      {
         if ( ! IsAuthorized("trn_discussiontranslation_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1S103( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1S103( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1S103( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1S103( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1S103( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001S9 */
                     pr_default.execute(7, new Object[] {A594DiscussionTranslationWWPDiscus, A595DiscussionTranslationEnglish, A596DiscussionTranslationDutch, A593Trn_DiscussionTranslationId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_DiscussionTranslation");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_DiscussionTranslation"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1S103( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1S0( ) ;
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
            EndLevel1S103( ) ;
         }
         CloseExtendedTableCursors1S103( ) ;
      }

      protected void DeferredUpdate1S103( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("trn_discussiontranslation_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1S103( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1S103( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1S103( ) ;
            AfterConfirm1S103( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1S103( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001S10 */
                  pr_default.execute(8, new Object[] {A593Trn_DiscussionTranslationId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_DiscussionTranslation");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound103 == 0 )
                        {
                           InitAll1S103( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption1S0( ) ;
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
         sMode103 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1S103( ) ;
         Gx_mode = sMode103;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1S103( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1S103( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1S103( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("trn_discussiontranslation",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1S0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("trn_discussiontranslation",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1S103( )
      {
         /* Scan By routine */
         /* Using cursor T001S11 */
         pr_default.execute(9);
         RcdFound103 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound103 = 1;
            A593Trn_DiscussionTranslationId = T001S11_A593Trn_DiscussionTranslationId[0];
            AssignAttri("", false, "A593Trn_DiscussionTranslationId", A593Trn_DiscussionTranslationId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1S103( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound103 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound103 = 1;
            A593Trn_DiscussionTranslationId = T001S11_A593Trn_DiscussionTranslationId[0];
            AssignAttri("", false, "A593Trn_DiscussionTranslationId", A593Trn_DiscussionTranslationId.ToString());
         }
      }

      protected void ScanEnd1S103( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1S103( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1S103( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1S103( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1S103( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1S103( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1S103( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1S103( )
      {
         edtTrn_DiscussionTranslationId_Enabled = 0;
         AssignProp("", false, edtTrn_DiscussionTranslationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrn_DiscussionTranslationId_Enabled), 5, 0), true);
         edtDiscussionTranslationWWPDiscus_Enabled = 0;
         AssignProp("", false, edtDiscussionTranslationWWPDiscus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDiscussionTranslationWWPDiscus_Enabled), 5, 0), true);
         edtDiscussionTranslationEnglish_Enabled = 0;
         AssignProp("", false, edtDiscussionTranslationEnglish_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDiscussionTranslationEnglish_Enabled), 5, 0), true);
         edtDiscussionTranslationDutch_Enabled = 0;
         AssignProp("", false, edtDiscussionTranslationDutch_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDiscussionTranslationDutch_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1S103( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1S0( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1918140), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_discussiontranslation.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z593Trn_DiscussionTranslationId", Z593Trn_DiscussionTranslationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z594DiscussionTranslationWWPDiscus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z594DiscussionTranslationWWPDiscus), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z595DiscussionTranslationEnglish", Z595DiscussionTranslationEnglish);
         GxWebStd.gx_hidden_field( context, "Z596DiscussionTranslationDutch", Z596DiscussionTranslationDutch);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
         context.WriteHtmlText( "<script type=\"text/javascript\">") ;
         context.WriteHtmlText( "gx.setLanguageCode(\""+context.GetLanguageProperty( "code")+"\");") ;
         if ( ! context.isSpaRequest( ) )
         {
            context.WriteHtmlText( "gx.setDateFormat(\""+context.GetLanguageProperty( "date_fmt")+"\");") ;
            context.WriteHtmlText( "gx.setTimeFormat("+context.GetLanguageProperty( "time_fmt")+");") ;
            context.WriteHtmlText( "gx.setCenturyFirstYear("+40+");") ;
            context.WriteHtmlText( "gx.setDecimalPoint(\""+context.GetLanguageProperty( "decimal_point")+"\");") ;
            context.WriteHtmlText( "gx.setThousandSeparator(\""+context.GetLanguageProperty( "thousand_sep")+"\");") ;
            context.WriteHtmlText( "gx.StorageTimeZone = "+1+";") ;
         }
         context.WriteHtmlText( "</script>") ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("trn_discussiontranslation.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_DiscussionTranslation" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Trn_Discussion Translation", "") ;
      }

      protected void InitializeNonKey1S103( )
      {
         A594DiscussionTranslationWWPDiscus = 0;
         AssignAttri("", false, "A594DiscussionTranslationWWPDiscus", StringUtil.LTrimStr( (decimal)(A594DiscussionTranslationWWPDiscus), 10, 0));
         A595DiscussionTranslationEnglish = "";
         AssignAttri("", false, "A595DiscussionTranslationEnglish", A595DiscussionTranslationEnglish);
         A596DiscussionTranslationDutch = "";
         AssignAttri("", false, "A596DiscussionTranslationDutch", A596DiscussionTranslationDutch);
         Z594DiscussionTranslationWWPDiscus = 0;
         Z595DiscussionTranslationEnglish = "";
         Z596DiscussionTranslationDutch = "";
      }

      protected void InitAll1S103( )
      {
         A593Trn_DiscussionTranslationId = Guid.NewGuid( );
         AssignAttri("", false, "A593Trn_DiscussionTranslationId", A593Trn_DiscussionTranslationId.ToString());
         InitializeNonKey1S103( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256201761235", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("trn_discussiontranslation.js", "?20256201761235", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtTrn_DiscussionTranslationId_Internalname = "TRN_DISCUSSIONTRANSLATIONID";
         edtDiscussionTranslationWWPDiscus_Internalname = "DISCUSSIONTRANSLATIONWWPDISCUS";
         edtDiscussionTranslationEnglish_Internalname = "DISCUSSIONTRANSLATIONENGLISH";
         edtDiscussionTranslationDutch_Internalname = "DISCUSSIONTRANSLATIONDUTCH";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Trn_Discussion Translation", "");
         bttBtntrn_delete_Enabled = 1;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtDiscussionTranslationDutch_Enabled = 1;
         edtDiscussionTranslationEnglish_Enabled = 1;
         edtDiscussionTranslationWWPDiscus_Jsonclick = "";
         edtDiscussionTranslationWWPDiscus_Enabled = 1;
         edtTrn_DiscussionTranslationId_Jsonclick = "";
         edtTrn_DiscussionTranslationId_Enabled = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtDiscussionTranslationWWPDiscus_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
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

      public void Valid_Trn_discussiontranslationid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A594DiscussionTranslationWWPDiscus", StringUtil.LTrim( StringUtil.NToC( (decimal)(A594DiscussionTranslationWWPDiscus), 10, 0, ".", "")));
         AssignAttri("", false, "A595DiscussionTranslationEnglish", A595DiscussionTranslationEnglish);
         AssignAttri("", false, "A596DiscussionTranslationDutch", A596DiscussionTranslationDutch);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z593Trn_DiscussionTranslationId", Z593Trn_DiscussionTranslationId.ToString());
         GxWebStd.gx_hidden_field( context, "Z594DiscussionTranslationWWPDiscus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z594DiscussionTranslationWWPDiscus), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z595DiscussionTranslationEnglish", Z595DiscussionTranslationEnglish);
         GxWebStd.gx_hidden_field( context, "Z596DiscussionTranslationDutch", Z596DiscussionTranslationDutch);
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E121S2","iparms":[]}""");
         setEventMetadata("VALID_TRN_DISCUSSIONTRANSLATIONID","""{"handler":"Valid_Trn_discussiontranslationid","iparms":[{"av":"A593Trn_DiscussionTranslationId","fld":"TRN_DISCUSSIONTRANSLATIONID"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]""");
         setEventMetadata("VALID_TRN_DISCUSSIONTRANSLATIONID",""","oparms":[{"av":"A594DiscussionTranslationWWPDiscus","fld":"DISCUSSIONTRANSLATIONWWPDISCUS","pic":"ZZZZZZZZZ9"},{"av":"A595DiscussionTranslationEnglish","fld":"DISCUSSIONTRANSLATIONENGLISH"},{"av":"A596DiscussionTranslationDutch","fld":"DISCUSSIONTRANSLATIONDUTCH"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z593Trn_DiscussionTranslationId"},{"av":"Z594DiscussionTranslationWWPDiscus"},{"av":"Z595DiscussionTranslationEnglish"},{"av":"Z596DiscussionTranslationDutch"},{"ctrl":"BTNTRN_DELETE","prop":"Enabled"},{"ctrl":"BTNTRN_ENTER","prop":"Enabled"}]}""");
         return  ;
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
         sPrefix = "";
         Z593Trn_DiscussionTranslationId = Guid.Empty;
         Z595DiscussionTranslationEnglish = "";
         Z596DiscussionTranslationDutch = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A593Trn_DiscussionTranslationId = Guid.Empty;
         A595DiscussionTranslationEnglish = "";
         A596DiscussionTranslationDutch = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T001S4_A593Trn_DiscussionTranslationId = new Guid[] {Guid.Empty} ;
         T001S4_A594DiscussionTranslationWWPDiscus = new long[1] ;
         T001S4_A595DiscussionTranslationEnglish = new string[] {""} ;
         T001S4_A596DiscussionTranslationDutch = new string[] {""} ;
         T001S5_A593Trn_DiscussionTranslationId = new Guid[] {Guid.Empty} ;
         T001S3_A593Trn_DiscussionTranslationId = new Guid[] {Guid.Empty} ;
         T001S3_A594DiscussionTranslationWWPDiscus = new long[1] ;
         T001S3_A595DiscussionTranslationEnglish = new string[] {""} ;
         T001S3_A596DiscussionTranslationDutch = new string[] {""} ;
         sMode103 = "";
         T001S6_A593Trn_DiscussionTranslationId = new Guid[] {Guid.Empty} ;
         T001S7_A593Trn_DiscussionTranslationId = new Guid[] {Guid.Empty} ;
         T001S2_A593Trn_DiscussionTranslationId = new Guid[] {Guid.Empty} ;
         T001S2_A594DiscussionTranslationWWPDiscus = new long[1] ;
         T001S2_A595DiscussionTranslationEnglish = new string[] {""} ;
         T001S2_A596DiscussionTranslationDutch = new string[] {""} ;
         T001S11_A593Trn_DiscussionTranslationId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ593Trn_DiscussionTranslationId = Guid.Empty;
         ZZ595DiscussionTranslationEnglish = "";
         ZZ596DiscussionTranslationDutch = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_discussiontranslation__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_discussiontranslation__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_discussiontranslation__default(),
            new Object[][] {
                new Object[] {
               T001S2_A593Trn_DiscussionTranslationId, T001S2_A594DiscussionTranslationWWPDiscus, T001S2_A595DiscussionTranslationEnglish, T001S2_A596DiscussionTranslationDutch
               }
               , new Object[] {
               T001S3_A593Trn_DiscussionTranslationId, T001S3_A594DiscussionTranslationWWPDiscus, T001S3_A595DiscussionTranslationEnglish, T001S3_A596DiscussionTranslationDutch
               }
               , new Object[] {
               T001S4_A593Trn_DiscussionTranslationId, T001S4_A594DiscussionTranslationWWPDiscus, T001S4_A595DiscussionTranslationEnglish, T001S4_A596DiscussionTranslationDutch
               }
               , new Object[] {
               T001S5_A593Trn_DiscussionTranslationId
               }
               , new Object[] {
               T001S6_A593Trn_DiscussionTranslationId
               }
               , new Object[] {
               T001S7_A593Trn_DiscussionTranslationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001S11_A593Trn_DiscussionTranslationId
               }
            }
         );
         Z593Trn_DiscussionTranslationId = Guid.NewGuid( );
         A593Trn_DiscussionTranslationId = Guid.NewGuid( );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound103 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtTrn_DiscussionTranslationId_Enabled ;
      private int edtDiscussionTranslationWWPDiscus_Enabled ;
      private int edtDiscussionTranslationEnglish_Enabled ;
      private int edtDiscussionTranslationDutch_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int idxLst ;
      private long Z594DiscussionTranslationWWPDiscus ;
      private long A594DiscussionTranslationWWPDiscus ;
      private long ZZ594DiscussionTranslationWWPDiscus ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTrn_DiscussionTranslationId_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtTrn_DiscussionTranslationId_Jsonclick ;
      private string edtDiscussionTranslationWWPDiscus_Internalname ;
      private string edtDiscussionTranslationWWPDiscus_Jsonclick ;
      private string edtDiscussionTranslationEnglish_Internalname ;
      private string edtDiscussionTranslationDutch_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode103 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private string Z595DiscussionTranslationEnglish ;
      private string Z596DiscussionTranslationDutch ;
      private string A595DiscussionTranslationEnglish ;
      private string A596DiscussionTranslationDutch ;
      private string ZZ595DiscussionTranslationEnglish ;
      private string ZZ596DiscussionTranslationDutch ;
      private Guid Z593Trn_DiscussionTranslationId ;
      private Guid A593Trn_DiscussionTranslationId ;
      private Guid ZZ593Trn_DiscussionTranslationId ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] T001S4_A593Trn_DiscussionTranslationId ;
      private long[] T001S4_A594DiscussionTranslationWWPDiscus ;
      private string[] T001S4_A595DiscussionTranslationEnglish ;
      private string[] T001S4_A596DiscussionTranslationDutch ;
      private Guid[] T001S5_A593Trn_DiscussionTranslationId ;
      private Guid[] T001S3_A593Trn_DiscussionTranslationId ;
      private long[] T001S3_A594DiscussionTranslationWWPDiscus ;
      private string[] T001S3_A595DiscussionTranslationEnglish ;
      private string[] T001S3_A596DiscussionTranslationDutch ;
      private Guid[] T001S6_A593Trn_DiscussionTranslationId ;
      private Guid[] T001S7_A593Trn_DiscussionTranslationId ;
      private Guid[] T001S2_A593Trn_DiscussionTranslationId ;
      private long[] T001S2_A594DiscussionTranslationWWPDiscus ;
      private string[] T001S2_A595DiscussionTranslationEnglish ;
      private string[] T001S2_A596DiscussionTranslationDutch ;
      private Guid[] T001S11_A593Trn_DiscussionTranslationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_discussiontranslation__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_discussiontranslation__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_discussiontranslation__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmT001S2;
       prmT001S2 = new Object[] {
       new ParDef("Trn_DiscussionTranslationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001S3;
       prmT001S3 = new Object[] {
       new ParDef("Trn_DiscussionTranslationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001S4;
       prmT001S4 = new Object[] {
       new ParDef("Trn_DiscussionTranslationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001S5;
       prmT001S5 = new Object[] {
       new ParDef("Trn_DiscussionTranslationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001S6;
       prmT001S6 = new Object[] {
       new ParDef("Trn_DiscussionTranslationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001S7;
       prmT001S7 = new Object[] {
       new ParDef("Trn_DiscussionTranslationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001S8;
       prmT001S8 = new Object[] {
       new ParDef("Trn_DiscussionTranslationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("DiscussionTranslationWWPDiscus",GXType.Int64,10,0) ,
       new ParDef("DiscussionTranslationEnglish",GXType.VarChar,1000,0) ,
       new ParDef("DiscussionTranslationDutch",GXType.VarChar,1000,0)
       };
       Object[] prmT001S9;
       prmT001S9 = new Object[] {
       new ParDef("DiscussionTranslationWWPDiscus",GXType.Int64,10,0) ,
       new ParDef("DiscussionTranslationEnglish",GXType.VarChar,1000,0) ,
       new ParDef("DiscussionTranslationDutch",GXType.VarChar,1000,0) ,
       new ParDef("Trn_DiscussionTranslationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001S10;
       prmT001S10 = new Object[] {
       new ParDef("Trn_DiscussionTranslationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmT001S11;
       prmT001S11 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T001S2", "SELECT Trn_DiscussionTranslationId, DiscussionTranslationWWPDiscus, DiscussionTranslationEnglish, DiscussionTranslationDutch FROM Trn_DiscussionTranslation WHERE Trn_DiscussionTranslationId = :Trn_DiscussionTranslationId  FOR UPDATE OF Trn_DiscussionTranslation NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001S2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001S3", "SELECT Trn_DiscussionTranslationId, DiscussionTranslationWWPDiscus, DiscussionTranslationEnglish, DiscussionTranslationDutch FROM Trn_DiscussionTranslation WHERE Trn_DiscussionTranslationId = :Trn_DiscussionTranslationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001S3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001S4", "SELECT TM1.Trn_DiscussionTranslationId, TM1.DiscussionTranslationWWPDiscus, TM1.DiscussionTranslationEnglish, TM1.DiscussionTranslationDutch FROM Trn_DiscussionTranslation TM1 WHERE TM1.Trn_DiscussionTranslationId = :Trn_DiscussionTranslationId ORDER BY TM1.Trn_DiscussionTranslationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001S4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001S5", "SELECT Trn_DiscussionTranslationId FROM Trn_DiscussionTranslation WHERE Trn_DiscussionTranslationId = :Trn_DiscussionTranslationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001S5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T001S6", "SELECT Trn_DiscussionTranslationId FROM Trn_DiscussionTranslation WHERE ( Trn_DiscussionTranslationId > :Trn_DiscussionTranslationId) ORDER BY Trn_DiscussionTranslationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001S6,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001S7", "SELECT Trn_DiscussionTranslationId FROM Trn_DiscussionTranslation WHERE ( Trn_DiscussionTranslationId < :Trn_DiscussionTranslationId) ORDER BY Trn_DiscussionTranslationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001S7,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T001S8", "SAVEPOINT gxupdate;INSERT INTO Trn_DiscussionTranslation(Trn_DiscussionTranslationId, DiscussionTranslationWWPDiscus, DiscussionTranslationEnglish, DiscussionTranslationDutch) VALUES(:Trn_DiscussionTranslationId, :DiscussionTranslationWWPDiscus, :DiscussionTranslationEnglish, :DiscussionTranslationDutch);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001S8)
          ,new CursorDef("T001S9", "SAVEPOINT gxupdate;UPDATE Trn_DiscussionTranslation SET DiscussionTranslationWWPDiscus=:DiscussionTranslationWWPDiscus, DiscussionTranslationEnglish=:DiscussionTranslationEnglish, DiscussionTranslationDutch=:DiscussionTranslationDutch  WHERE Trn_DiscussionTranslationId = :Trn_DiscussionTranslationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001S9)
          ,new CursorDef("T001S10", "SAVEPOINT gxupdate;DELETE FROM Trn_DiscussionTranslation  WHERE Trn_DiscussionTranslationId = :Trn_DiscussionTranslationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001S10)
          ,new CursorDef("T001S11", "SELECT Trn_DiscussionTranslationId FROM Trn_DiscussionTranslation ORDER BY Trn_DiscussionTranslationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001S11,100, GxCacheFrequency.OFF ,true,false )
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
             ((long[]) buf[1])[0] = rslt.getLong(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((long[]) buf[1])[0] = rslt.getLong(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((long[]) buf[1])[0] = rslt.getLong(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
