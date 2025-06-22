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
   public class wp_organisationdefinitions : GXDataArea
   {
      public wp_organisationdefinitions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_organisationdefinitions( IGxContext context )
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

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
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
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
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
            return "wp_organisationdefinitions_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      public override short ExecuteStartEvent( )
      {
         PABR2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTBR2( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_organisationdefinitions.aspx") +"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_ORGANISATIONDEFINITIONS", AV17SDT_OrganisationDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_ORGANISATIONDEFINITIONS", AV17SDT_OrganisationDefinitions);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRN_ORGANISATIONSETTING", AV16Trn_OrganisationSetting);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRN_ORGANISATIONSETTING", AV16Trn_OrganisationSetting);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vERRORMESSAGES", AV18ErrorMessages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vERRORMESSAGES", AV18ErrorMessages);
         }
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Class", StringUtil.RTrim( Gxuitabspanel_tabs_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs_Historymanagement));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WEBR2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTBR2( ) ;
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
         return formatLink("wp_organisationdefinitions.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WP_OrganisationDefinitions" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Organisation Definitions", "") ;
      }

      protected void WBBR0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
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
            /* User Defined Control */
            ucGxuitabspanel_tabs.SetProperty("PageCount", Gxuitabspanel_tabs_Pagecount);
            ucGxuitabspanel_tabs.SetProperty("Class", Gxuitabspanel_tabs_Class);
            ucGxuitabspanel_tabs.SetProperty("HistoryManagement", Gxuitabspanel_tabs_Historymanagement);
            ucGxuitabspanel_tabs.Render(context, "tab", Gxuitabspanel_tabs_Internalname, "GXUITABSPANEL_TABSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDutchtab_title_Internalname, context.GetMessage( "Nederlands", ""), "", "", lblDutchtab_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_OrganisationDefinitions.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "DutchTab") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributesnl_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCustomizetermstablenl_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginBottom20", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblInstructiondutchtextblock_Internalname, lblInstructiondutchtextblock_Caption, "", "", lblInstructiondutchtextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WLGroupTitle", 0, "", 1, 1, 0, 0, "HLP_WP_OrganisationDefinitions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divReceptionisttable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginBottom15", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFlextable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2", "start", "top", "", "", "div");
            wb_table1_35_BR2( true) ;
         }
         else
         {
            wb_table1_35_BR2( false) ;
         }
         return  ;
      }

      protected void wb_table1_35_BR2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSingulardutchtxtlabel_Internalname, lblSingulardutchtxtlabel_Caption, "", "", lblSingulardutchtxtlabel_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_OrganisationDefinitions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 col-sm-6", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPluraldutchtextblock_Internalname, lblPluraldutchtextblock_Caption, "", "", lblPluraldutchtextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_OrganisationDefinitions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginBottom15", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFlextable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblReceptionistnllabel_Internalname, lblReceptionistnllabel_Caption, "", "", lblReceptionistnllabel_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "AttributeWeightBold TextOverflow", 0, "", 1, 1, 0, 0, "HLP_WP_OrganisationDefinitions.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReceptionistsingularnl_Internalname, context.GetMessage( "Receptionist Singular Nl", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReceptionistsingularnl_Internalname, AV37ReceptionistSingularNl, StringUtil.RTrim( context.localUtil.Format( AV37ReceptionistSingularNl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReceptionistsingularnl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavReceptionistsingularnl_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_OrganisationDefinitions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReceptionistpluralnl_Internalname, context.GetMessage( "Receptionist Plural Nl", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReceptionistpluralnl_Internalname, AV38ReceptionistPluralNl, StringUtil.RTrim( context.localUtil.Format( AV38ReceptionistPluralNl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReceptionistpluralnl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavReceptionistpluralnl_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_OrganisationDefinitions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFlextable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblResidentnllabel_Internalname, lblResidentnllabel_Caption, "", "", lblResidentnllabel_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "AttributeWeightBold TextOverflow", 0, "", 1, 1, 0, 0, "HLP_WP_OrganisationDefinitions.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentsingularnl_Internalname, context.GetMessage( "Resident Singular Nl", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentsingularnl_Internalname, AV35ResidentSingularNl, StringUtil.RTrim( context.localUtil.Format( AV35ResidentSingularNl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentsingularnl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentsingularnl_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_OrganisationDefinitions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentpluralnl_Internalname, context.GetMessage( "Resident Plural Nl", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentpluralnl_Internalname, AV36ResidentPluralNl, StringUtil.RTrim( context.localUtil.Format( AV36ResidentPluralNl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentpluralnl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentpluralnl_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_OrganisationDefinitions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblEnglishtab_title_Internalname, context.GetMessage( "English", ""), "", "", lblEnglishtab_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_OrganisationDefinitions.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "EnglishTab") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributeseng_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCustomizetermstableeng_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginBottom20", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblInstructionengtextblock_Internalname, lblInstructionengtextblock_Caption, "", "", lblInstructionengtextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WLGroupTitle", 0, "", 1, 1, 0, 0, "HLP_WP_OrganisationDefinitions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divReceptionisttableeng_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginBottom15", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFlextable1eng_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2", "start", "top", "", "", "div");
            wb_table2_89_BR2( true) ;
         }
         else
         {
            wb_table2_89_BR2( false) ;
         }
         return  ;
      }

      protected void wb_table2_89_BR2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSingulartxtlabel2_Internalname, context.GetMessage( "Singular", ""), "", "", lblSingulartxtlabel2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_OrganisationDefinitions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-5 col-sm-6", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPluraltextblock2_Internalname, context.GetMessage( "Plural", ""), "", "", lblPluraltextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_OrganisationDefinitions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginBottom15", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFlextable2eng_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblReceptionistenglabel_Internalname, context.GetMessage( "Receptionist Name", ""), "", "", lblReceptionistenglabel_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "AttributeWeightBold TextOverflow", 0, "", 1, 1, 0, 0, "HLP_WP_OrganisationDefinitions.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReceptionistsingulareng_Internalname, context.GetMessage( "Receptionist Singular Eng", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReceptionistsingulareng_Internalname, AV33ReceptionistSingularEng, StringUtil.RTrim( context.localUtil.Format( AV33ReceptionistSingularEng, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReceptionistsingulareng_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavReceptionistsingulareng_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_OrganisationDefinitions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavReceptionistpluraleng_Internalname, context.GetMessage( "Receptionist Plural Eng", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavReceptionistpluraleng_Internalname, AV34ReceptionistPluralEng, StringUtil.RTrim( context.localUtil.Format( AV34ReceptionistPluralEng, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavReceptionistpluraleng_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavReceptionistpluraleng_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_OrganisationDefinitions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFlextable3eng_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblResidentenglabel_Internalname, context.GetMessage( "Resident Name", ""), "", "", lblResidentenglabel_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "AttributeWeightBold TextOverflow", 0, "", 1, 1, 0, 0, "HLP_WP_OrganisationDefinitions.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentsingulareng_Internalname, context.GetMessage( "Resident Singular Eng", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentsingulareng_Internalname, AV31ResidentSingularEng, StringUtil.RTrim( context.localUtil.Format( AV31ResidentSingularEng, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,117);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentsingulareng_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentsingulareng_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_OrganisationDefinitions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavResidentpluraleng_Internalname, context.GetMessage( "Resident Plural Eng", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavResidentpluraleng_Internalname, AV32ResidentPluralEng, StringUtil.RTrim( context.localUtil.Format( AV32ResidentPluralEng, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,120);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavResidentpluraleng_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavResidentpluraleng_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_OrganisationDefinitions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_OrganisationDefinitions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_OrganisationDefinitions.htm");
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
         wbLoad = true;
      }

      protected void STARTBR2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Organisation Definitions", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPBR0( ) ;
      }

      protected void WSBR2( )
      {
         STARTBR2( ) ;
         EVTBR2( ) ;
      }

      protected void EVTBR2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E11BR2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E12BR2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E13BR2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
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
      }

      protected void WEBR2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PABR2( )
      {
         if ( nDonePA == 0 )
         {
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavReceptionistsingularnl_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFBR2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFBR2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E13BR2 ();
            WBBR0( ) ;
         }
      }

      protected void send_integrity_lvl_hashesBR2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUPBR0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11BR2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Gxuitabspanel_tabs_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS_Pagecount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gxuitabspanel_tabs_Class = cgiGet( "GXUITABSPANEL_TABS_Class");
            Gxuitabspanel_tabs_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Historymanagement"));
            /* Read variables values. */
            AV37ReceptionistSingularNl = cgiGet( edtavReceptionistsingularnl_Internalname);
            AssignAttri("", false, "AV37ReceptionistSingularNl", AV37ReceptionistSingularNl);
            AV38ReceptionistPluralNl = cgiGet( edtavReceptionistpluralnl_Internalname);
            AssignAttri("", false, "AV38ReceptionistPluralNl", AV38ReceptionistPluralNl);
            AV35ResidentSingularNl = cgiGet( edtavResidentsingularnl_Internalname);
            AssignAttri("", false, "AV35ResidentSingularNl", AV35ResidentSingularNl);
            AV36ResidentPluralNl = cgiGet( edtavResidentpluralnl_Internalname);
            AssignAttri("", false, "AV36ResidentPluralNl", AV36ResidentPluralNl);
            AV33ReceptionistSingularEng = cgiGet( edtavReceptionistsingulareng_Internalname);
            AssignAttri("", false, "AV33ReceptionistSingularEng", AV33ReceptionistSingularEng);
            AV34ReceptionistPluralEng = cgiGet( edtavReceptionistpluraleng_Internalname);
            AssignAttri("", false, "AV34ReceptionistPluralEng", AV34ReceptionistPluralEng);
            AV31ResidentSingularEng = cgiGet( edtavResidentsingulareng_Internalname);
            AssignAttri("", false, "AV31ResidentSingularEng", AV31ResidentSingularEng);
            AV32ResidentPluralEng = cgiGet( edtavResidentpluraleng_Internalname);
            AssignAttri("", false, "AV32ResidentPluralEng", AV32ResidentPluralEng);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11BR2 ();
         if (returnInSub) return;
      }

      protected void E11BR2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV14WWPContext) ;
         AV28language = context.GetLanguage( );
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         if ( (Guid.Empty==AV14WWPContext.gxTpr_Organisationsettingid) )
         {
            /* Using cursor H00BR2 */
            pr_default.execute(0, new Object[] {AV14WWPContext.gxTpr_Organisationid});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A11OrganisationId = H00BR2_A11OrganisationId[0];
               A100OrganisationSettingid = H00BR2_A100OrganisationSettingid[0];
               AV16Trn_OrganisationSetting.Load(A100OrganisationSettingid, A11OrganisationId);
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         else
         {
            AV16Trn_OrganisationSetting.Load(AV14WWPContext.gxTpr_Organisationsettingid, AV14WWPContext.gxTpr_Organisationid);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16Trn_OrganisationSetting.gxTpr_Organisationdefinitions)) )
         {
            /* Execute user subroutine: 'SETDEFAULTDEFINITIONS' */
            S112 ();
            if (returnInSub) return;
         }
         else
         {
            if ( AV17SDT_OrganisationDefinitions.FromJSonString(AV16Trn_OrganisationSetting.gxTpr_Organisationdefinitions, null) )
            {
               AV37ReceptionistSingularNl = AV17SDT_OrganisationDefinitions.gxTpr_Receptionistdefinition.gxTpr_Dutch.gxTpr_Singular;
               AssignAttri("", false, "AV37ReceptionistSingularNl", AV37ReceptionistSingularNl);
               AV38ReceptionistPluralNl = AV17SDT_OrganisationDefinitions.gxTpr_Receptionistdefinition.gxTpr_Dutch.gxTpr_Plural;
               AssignAttri("", false, "AV38ReceptionistPluralNl", AV38ReceptionistPluralNl);
               AV35ResidentSingularNl = AV17SDT_OrganisationDefinitions.gxTpr_Residentdefinition.gxTpr_Dutch.gxTpr_Singular;
               AssignAttri("", false, "AV35ResidentSingularNl", AV35ResidentSingularNl);
               AV36ResidentPluralNl = AV17SDT_OrganisationDefinitions.gxTpr_Residentdefinition.gxTpr_Dutch.gxTpr_Plural;
               AssignAttri("", false, "AV36ResidentPluralNl", AV36ResidentPluralNl);
               AV33ReceptionistSingularEng = AV17SDT_OrganisationDefinitions.gxTpr_Receptionistdefinition.gxTpr_English.gxTpr_Singular;
               AssignAttri("", false, "AV33ReceptionistSingularEng", AV33ReceptionistSingularEng);
               AV34ReceptionistPluralEng = AV17SDT_OrganisationDefinitions.gxTpr_Receptionistdefinition.gxTpr_English.gxTpr_Plural;
               AssignAttri("", false, "AV34ReceptionistPluralEng", AV34ReceptionistPluralEng);
               AV31ResidentSingularEng = AV17SDT_OrganisationDefinitions.gxTpr_Residentdefinition.gxTpr_English.gxTpr_Singular;
               AssignAttri("", false, "AV31ResidentSingularEng", AV31ResidentSingularEng);
               AV32ResidentPluralEng = AV17SDT_OrganisationDefinitions.gxTpr_Residentdefinition.gxTpr_English.gxTpr_Plural;
               AssignAttri("", false, "AV32ResidentPluralEng", AV32ResidentPluralEng);
            }
            else
            {
               /* Execute user subroutine: 'SETDEFAULTDEFINITIONS' */
               S112 ();
               if (returnInSub) return;
            }
         }
         lblInstructionengtextblock_Caption = "Customize the system settings with wording that better fit your organisation's vocabulary.";
         AssignProp("", false, lblInstructionengtextblock_Internalname, "Caption", lblInstructionengtextblock_Caption, true);
         lblInstructiondutchtextblock_Caption = "Pas de systeeminstellingen zodat deze beter past  bij de bedrijfstaal van uw organisatie.";
         AssignProp("", false, lblInstructiondutchtextblock_Internalname, "Caption", lblInstructiondutchtextblock_Caption, true);
         lblReceptionistnllabel_Caption = "Naam Receptionist";
         AssignProp("", false, lblReceptionistnllabel_Internalname, "Caption", lblReceptionistnllabel_Caption, true);
         lblResidentnllabel_Caption = "Naam Bewoner";
         AssignProp("", false, lblResidentnllabel_Internalname, "Caption", lblResidentnllabel_Caption, true);
         lblSingulardutchtxtlabel_Caption = "Enkelvoud";
         AssignProp("", false, lblSingulardutchtxtlabel_Internalname, "Caption", lblSingulardutchtxtlabel_Caption, true);
         lblPluraldutchtextblock_Caption = "Meervoud";
         AssignProp("", false, lblPluraldutchtextblock_Internalname, "Caption", lblPluraldutchtextblock_Caption, true);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E12BR2 ();
         if (returnInSub) return;
      }

      protected void E12BR2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV17SDT_OrganisationDefinitions.gxTpr_Receptionistdefinition.gxTpr_English.gxTpr_Singular = AV33ReceptionistSingularEng;
         AV17SDT_OrganisationDefinitions.gxTpr_Receptionistdefinition.gxTpr_English.gxTpr_Plural = AV34ReceptionistPluralEng;
         AV17SDT_OrganisationDefinitions.gxTpr_Receptionistdefinition.gxTpr_Dutch.gxTpr_Singular = AV37ReceptionistSingularNl;
         AV17SDT_OrganisationDefinitions.gxTpr_Receptionistdefinition.gxTpr_Dutch.gxTpr_Plural = AV38ReceptionistPluralNl;
         AV17SDT_OrganisationDefinitions.gxTpr_Residentdefinition.gxTpr_English.gxTpr_Plural = AV32ResidentPluralEng;
         AV17SDT_OrganisationDefinitions.gxTpr_Residentdefinition.gxTpr_English.gxTpr_Singular = AV31ResidentSingularEng;
         AV17SDT_OrganisationDefinitions.gxTpr_Residentdefinition.gxTpr_Dutch.gxTpr_Singular = AV35ResidentSingularNl;
         AV17SDT_OrganisationDefinitions.gxTpr_Residentdefinition.gxTpr_Dutch.gxTpr_Plural = AV36ResidentPluralNl;
         AV16Trn_OrganisationSetting.gxTpr_Organisationdefinitions = AV17SDT_OrganisationDefinitions.ToJSonString(false, true);
         if ( AV16Trn_OrganisationSetting.Update() )
         {
            context.CommitDataStores("wp_organisationdefinitions",pr_default);
            this.executeExternalObjectMethod("", false, "gx.extensions.web.interop", "runJS", new Object[] {"window.location.reload();"}, false);
         }
         else
         {
            AV18ErrorMessages = AV16Trn_OrganisationSetting.GetMessages();
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17SDT_OrganisationDefinitions", AV17SDT_OrganisationDefinitions);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16Trn_OrganisationSetting", AV16Trn_OrganisationSetting);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18ErrorMessages", AV18ErrorMessages);
      }

      protected void S122( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV40GXV1 = 1;
         while ( AV40GXV1 <= AV18ErrorMessages.Count )
         {
            AV19Message = ((GeneXus.Utils.SdtMessages_Message)AV18ErrorMessages.Item(AV40GXV1));
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error",  AV19Message.gxTpr_Description,  "error",  "",  "true",  ""));
            AV40GXV1 = (int)(AV40GXV1+1);
         }
         AV18ErrorMessages.Clear();
      }

      protected void S112( )
      {
         /* 'SETDEFAULTDEFINITIONS' Routine */
         returnInSub = false;
         AV37ReceptionistSingularNl = "Receptionist";
         AssignAttri("", false, "AV37ReceptionistSingularNl", AV37ReceptionistSingularNl);
         AV38ReceptionistPluralNl = "Receptionisten";
         AssignAttri("", false, "AV38ReceptionistPluralNl", AV38ReceptionistPluralNl);
         AV35ResidentSingularNl = "Bewoner";
         AssignAttri("", false, "AV35ResidentSingularNl", AV35ResidentSingularNl);
         AV36ResidentPluralNl = "Bewoners";
         AssignAttri("", false, "AV36ResidentPluralNl", AV36ResidentPluralNl);
         AV33ReceptionistSingularEng = "Receptionist";
         AssignAttri("", false, "AV33ReceptionistSingularEng", AV33ReceptionistSingularEng);
         AV34ReceptionistPluralEng = "Receptionists";
         AssignAttri("", false, "AV34ReceptionistPluralEng", AV34ReceptionistPluralEng);
         AV31ResidentSingularEng = "Resident";
         AssignAttri("", false, "AV31ResidentSingularEng", AV31ResidentSingularEng);
         AV32ResidentPluralEng = "Residents";
         AssignAttri("", false, "AV32ResidentPluralEng", AV32ResidentPluralEng);
      }

      protected void nextLoad( )
      {
      }

      protected void E13BR2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_89_BR2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable2_Internalname, tblTable2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTermlabel2_Internalname, " ", "", "", lblTermlabel2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_OrganisationDefinitions.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_89_BR2e( true) ;
         }
         else
         {
            wb_table2_89_BR2e( false) ;
         }
      }

      protected void wb_table1_35_BR2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTermlabel_Internalname, " ", "", "", lblTermlabel_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_OrganisationDefinitions.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_35_BR2e( true) ;
         }
         else
         {
            wb_table1_35_BR2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PABR2( ) ;
         WSBR2( ) ;
         WEBR2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256226404732", true, true);
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
         context.AddJavascriptSource("wp_organisationdefinitions.js", "?20256226404732", false, true);
         context.AddJavascriptSource("web-extension/gx-web-extensions.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblDutchtab_title_Internalname = "DUTCHTAB_TITLE";
         lblInstructiondutchtextblock_Internalname = "INSTRUCTIONDUTCHTEXTBLOCK";
         lblTermlabel_Internalname = "TERMLABEL";
         tblTable1_Internalname = "TABLE1";
         lblSingulardutchtxtlabel_Internalname = "SINGULARDUTCHTXTLABEL";
         lblPluraldutchtextblock_Internalname = "PLURALDUTCHTEXTBLOCK";
         divFlextable1_Internalname = "FLEXTABLE1";
         lblReceptionistnllabel_Internalname = "RECEPTIONISTNLLABEL";
         edtavReceptionistsingularnl_Internalname = "vRECEPTIONISTSINGULARNL";
         edtavReceptionistpluralnl_Internalname = "vRECEPTIONISTPLURALNL";
         divFlextable2_Internalname = "FLEXTABLE2";
         lblResidentnllabel_Internalname = "RESIDENTNLLABEL";
         edtavResidentsingularnl_Internalname = "vRESIDENTSINGULARNL";
         edtavResidentpluralnl_Internalname = "vRESIDENTPLURALNL";
         divFlextable3_Internalname = "FLEXTABLE3";
         divReceptionisttable_Internalname = "RECEPTIONISTTABLE";
         divCtable1_Internalname = "CTABLE1";
         divCustomizetermstablenl_Internalname = "CUSTOMIZETERMSTABLENL";
         divTableattributesnl_Internalname = "TABLEATTRIBUTESNL";
         lblEnglishtab_title_Internalname = "ENGLISHTAB_TITLE";
         lblInstructionengtextblock_Internalname = "INSTRUCTIONENGTEXTBLOCK";
         lblTermlabel2_Internalname = "TERMLABEL2";
         tblTable2_Internalname = "TABLE2";
         lblSingulartxtlabel2_Internalname = "SINGULARTXTLABEL2";
         lblPluraltextblock2_Internalname = "PLURALTEXTBLOCK2";
         divFlextable1eng_Internalname = "FLEXTABLE1ENG";
         lblReceptionistenglabel_Internalname = "RECEPTIONISTENGLABEL";
         edtavReceptionistsingulareng_Internalname = "vRECEPTIONISTSINGULARENG";
         edtavReceptionistpluraleng_Internalname = "vRECEPTIONISTPLURALENG";
         divFlextable2eng_Internalname = "FLEXTABLE2ENG";
         lblResidentenglabel_Internalname = "RESIDENTENGLABEL";
         edtavResidentsingulareng_Internalname = "vRESIDENTSINGULARENG";
         edtavResidentpluraleng_Internalname = "vRESIDENTPLURALENG";
         divFlextable3eng_Internalname = "FLEXTABLE3ENG";
         divReceptionisttableeng_Internalname = "RECEPTIONISTTABLEENG";
         divCtable2_Internalname = "CTABLE2";
         divCustomizetermstableeng_Internalname = "CUSTOMIZETERMSTABLEENG";
         divTableattributeseng_Internalname = "TABLEATTRIBUTESENG";
         Gxuitabspanel_tabs_Internalname = "GXUITABSPANEL_TABS";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
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
         edtavResidentpluraleng_Jsonclick = "";
         edtavResidentpluraleng_Enabled = 1;
         edtavResidentsingulareng_Jsonclick = "";
         edtavResidentsingulareng_Enabled = 1;
         edtavReceptionistpluraleng_Jsonclick = "";
         edtavReceptionistpluraleng_Enabled = 1;
         edtavReceptionistsingulareng_Jsonclick = "";
         edtavReceptionistsingulareng_Enabled = 1;
         lblInstructionengtextblock_Caption = context.GetMessage( "Customize Prompts", "");
         edtavResidentpluralnl_Jsonclick = "";
         edtavResidentpluralnl_Enabled = 1;
         edtavResidentsingularnl_Jsonclick = "";
         edtavResidentsingularnl_Enabled = 1;
         lblResidentnllabel_Caption = context.GetMessage( "Resident Name", "");
         edtavReceptionistpluralnl_Jsonclick = "";
         edtavReceptionistpluralnl_Enabled = 1;
         edtavReceptionistsingularnl_Jsonclick = "";
         edtavReceptionistsingularnl_Enabled = 1;
         lblReceptionistnllabel_Caption = context.GetMessage( "Receptionist Name", "");
         lblPluraldutchtextblock_Caption = context.GetMessage( "Plural", "");
         lblSingulardutchtxtlabel_Caption = context.GetMessage( "Singular", "");
         lblInstructiondutchtextblock_Caption = context.GetMessage( "Customize Prompts", "");
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Gxuitabspanel_tabs_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs_Class = "Tab";
         Gxuitabspanel_tabs_Pagecount = 2;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Organisation Definitions", "");
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("ENTER","""{"handler":"E12BR2","iparms":[{"av":"AV33ReceptionistSingularEng","fld":"vRECEPTIONISTSINGULARENG"},{"av":"AV17SDT_OrganisationDefinitions","fld":"vSDT_ORGANISATIONDEFINITIONS"},{"av":"AV34ReceptionistPluralEng","fld":"vRECEPTIONISTPLURALENG"},{"av":"AV37ReceptionistSingularNl","fld":"vRECEPTIONISTSINGULARNL"},{"av":"AV38ReceptionistPluralNl","fld":"vRECEPTIONISTPLURALNL"},{"av":"AV32ResidentPluralEng","fld":"vRESIDENTPLURALENG"},{"av":"AV31ResidentSingularEng","fld":"vRESIDENTSINGULARENG"},{"av":"AV35ResidentSingularNl","fld":"vRESIDENTSINGULARNL"},{"av":"AV36ResidentPluralNl","fld":"vRESIDENTPLURALNL"},{"av":"AV16Trn_OrganisationSetting","fld":"vTRN_ORGANISATIONSETTING"},{"av":"AV18ErrorMessages","fld":"vERRORMESSAGES"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV17SDT_OrganisationDefinitions","fld":"vSDT_ORGANISATIONDEFINITIONS"},{"av":"AV16Trn_OrganisationSetting","fld":"vTRN_ORGANISATIONSETTING"},{"av":"AV18ErrorMessages","fld":"vERRORMESSAGES"}]}""");
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

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV17SDT_OrganisationDefinitions = new SdtSDT_OrganisationDefinitions(context);
         AV16Trn_OrganisationSetting = new SdtTrn_OrganisationSetting(context);
         AV18ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucGxuitabspanel_tabs = new GXUserControl();
         lblDutchtab_title_Jsonclick = "";
         lblInstructiondutchtextblock_Jsonclick = "";
         lblSingulardutchtxtlabel_Jsonclick = "";
         lblPluraldutchtextblock_Jsonclick = "";
         lblReceptionistnllabel_Jsonclick = "";
         TempTags = "";
         AV37ReceptionistSingularNl = "";
         AV38ReceptionistPluralNl = "";
         lblResidentnllabel_Jsonclick = "";
         AV35ResidentSingularNl = "";
         AV36ResidentPluralNl = "";
         lblEnglishtab_title_Jsonclick = "";
         lblInstructionengtextblock_Jsonclick = "";
         lblSingulartxtlabel2_Jsonclick = "";
         lblPluraltextblock2_Jsonclick = "";
         lblReceptionistenglabel_Jsonclick = "";
         AV33ReceptionistSingularEng = "";
         AV34ReceptionistPluralEng = "";
         lblResidentenglabel_Jsonclick = "";
         AV31ResidentSingularEng = "";
         AV32ResidentPluralEng = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV14WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV28language = "";
         H00BR2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00BR2_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         A11OrganisationId = Guid.Empty;
         A100OrganisationSettingid = Guid.Empty;
         AV19Message = new GeneXus.Utils.SdtMessages_Message(context);
         sStyleString = "";
         lblTermlabel2_Jsonclick = "";
         lblTermlabel_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wp_organisationdefinitions__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_organisationdefinitions__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_organisationdefinitions__default(),
            new Object[][] {
                new Object[] {
               H00BR2_A11OrganisationId, H00BR2_A100OrganisationSettingid
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int Gxuitabspanel_tabs_Pagecount ;
      private int edtavReceptionistsingularnl_Enabled ;
      private int edtavReceptionistpluralnl_Enabled ;
      private int edtavResidentsingularnl_Enabled ;
      private int edtavResidentpluralnl_Enabled ;
      private int edtavReceptionistsingulareng_Enabled ;
      private int edtavReceptionistpluraleng_Enabled ;
      private int edtavResidentsingulareng_Enabled ;
      private int edtavResidentpluraleng_Enabled ;
      private int AV40GXV1 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Gxuitabspanel_tabs_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string Gxuitabspanel_tabs_Internalname ;
      private string lblDutchtab_title_Internalname ;
      private string lblDutchtab_title_Jsonclick ;
      private string divTableattributesnl_Internalname ;
      private string divCustomizetermstablenl_Internalname ;
      private string divCtable1_Internalname ;
      private string lblInstructiondutchtextblock_Internalname ;
      private string lblInstructiondutchtextblock_Caption ;
      private string lblInstructiondutchtextblock_Jsonclick ;
      private string divReceptionisttable_Internalname ;
      private string divFlextable1_Internalname ;
      private string lblSingulardutchtxtlabel_Internalname ;
      private string lblSingulardutchtxtlabel_Caption ;
      private string lblSingulardutchtxtlabel_Jsonclick ;
      private string lblPluraldutchtextblock_Internalname ;
      private string lblPluraldutchtextblock_Caption ;
      private string lblPluraldutchtextblock_Jsonclick ;
      private string divFlextable2_Internalname ;
      private string lblReceptionistnllabel_Internalname ;
      private string lblReceptionistnllabel_Caption ;
      private string lblReceptionistnllabel_Jsonclick ;
      private string edtavReceptionistsingularnl_Internalname ;
      private string TempTags ;
      private string edtavReceptionistsingularnl_Jsonclick ;
      private string edtavReceptionistpluralnl_Internalname ;
      private string edtavReceptionistpluralnl_Jsonclick ;
      private string divFlextable3_Internalname ;
      private string lblResidentnllabel_Internalname ;
      private string lblResidentnllabel_Caption ;
      private string lblResidentnllabel_Jsonclick ;
      private string edtavResidentsingularnl_Internalname ;
      private string edtavResidentsingularnl_Jsonclick ;
      private string edtavResidentpluralnl_Internalname ;
      private string edtavResidentpluralnl_Jsonclick ;
      private string lblEnglishtab_title_Internalname ;
      private string lblEnglishtab_title_Jsonclick ;
      private string divTableattributeseng_Internalname ;
      private string divCustomizetermstableeng_Internalname ;
      private string divCtable2_Internalname ;
      private string lblInstructionengtextblock_Internalname ;
      private string lblInstructionengtextblock_Caption ;
      private string lblInstructionengtextblock_Jsonclick ;
      private string divReceptionisttableeng_Internalname ;
      private string divFlextable1eng_Internalname ;
      private string lblSingulartxtlabel2_Internalname ;
      private string lblSingulartxtlabel2_Jsonclick ;
      private string lblPluraltextblock2_Internalname ;
      private string lblPluraltextblock2_Jsonclick ;
      private string divFlextable2eng_Internalname ;
      private string lblReceptionistenglabel_Internalname ;
      private string lblReceptionistenglabel_Jsonclick ;
      private string edtavReceptionistsingulareng_Internalname ;
      private string edtavReceptionistsingulareng_Jsonclick ;
      private string edtavReceptionistpluraleng_Internalname ;
      private string edtavReceptionistpluraleng_Jsonclick ;
      private string divFlextable3eng_Internalname ;
      private string lblResidentenglabel_Internalname ;
      private string lblResidentenglabel_Jsonclick ;
      private string edtavResidentsingulareng_Internalname ;
      private string edtavResidentsingulareng_Jsonclick ;
      private string edtavResidentpluraleng_Internalname ;
      private string edtavResidentpluraleng_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV28language ;
      private string sStyleString ;
      private string tblTable2_Internalname ;
      private string lblTermlabel2_Internalname ;
      private string lblTermlabel2_Jsonclick ;
      private string tblTable1_Internalname ;
      private string lblTermlabel_Internalname ;
      private string lblTermlabel_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Gxuitabspanel_tabs_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV37ReceptionistSingularNl ;
      private string AV38ReceptionistPluralNl ;
      private string AV35ResidentSingularNl ;
      private string AV36ResidentPluralNl ;
      private string AV33ReceptionistSingularEng ;
      private string AV34ReceptionistPluralEng ;
      private string AV31ResidentSingularEng ;
      private string AV32ResidentPluralEng ;
      private Guid A11OrganisationId ;
      private Guid A100OrganisationSettingid ;
      private GXUserControl ucGxuitabspanel_tabs ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_OrganisationDefinitions AV17SDT_OrganisationDefinitions ;
      private SdtTrn_OrganisationSetting AV16Trn_OrganisationSetting ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV18ErrorMessages ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV14WWPContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00BR2_A11OrganisationId ;
      private Guid[] H00BR2_A100OrganisationSettingid ;
      private GeneXus.Utils.SdtMessages_Message AV19Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_organisationdefinitions__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_organisationdefinitions__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wp_organisationdefinitions__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmH00BR2;
       prmH00BR2 = new Object[] {
       new ParDef("AV14WWPC_1Organisationid",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("H00BR2", "SELECT OrganisationId, OrganisationSettingid FROM Trn_OrganisationSetting WHERE OrganisationId = :AV14WWPC_1Organisationid ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00BR2,100, GxCacheFrequency.OFF ,true,false )
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
             return;
    }
 }

}

}
