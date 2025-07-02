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
   public class wp_notificationdashboard : GXDataArea
   {
      public wp_notificationdashboard( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_notificationdashboard( IGxContext context )
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
         radavNotificationtypes = new GXRadio();
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
            return "wp_notificationdashboard_Execute" ;
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
         PA7X2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7X2( ) ;
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_notificationdashboard.aspx") +"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMENTIONDEFINITIONS", AV33MentionDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMENTIONDEFINITIONS", AV33MentionDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vMENTIONDEFINITIONS", GetSecureSignedToken( "", AV33MentionDefinitions, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDISCUSSIONDEFINITIONS", AV29DiscussionDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDISCUSSIONDEFINITIONS", AV29DiscussionDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vDISCUSSIONDEFINITIONS", GetSecureSignedToken( "", AV29DiscussionDefinitions, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFORMDEFINITIONS", AV31FormDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFORMDEFINITIONS", AV31FormDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vFORMDEFINITIONS", GetSecureSignedToken( "", AV31FormDefinitions, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGENDADEFINITIONS", AV27AgendaDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGENDADEFINITIONS", AV27AgendaDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vAGENDADEFINITIONS", GetSecureSignedToken( "", AV27AgendaDefinitions, context));
         GxWebStd.gx_hidden_field( context, "vSEARCHKEYVALUE", AV42SearchKeyValue);
         GxWebStd.gx_hidden_field( context, "gxhash_vSEARCHKEYVALUE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV42SearchKeyValue, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMENTIONDEFINITIONS", AV33MentionDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMENTIONDEFINITIONS", AV33MentionDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vMENTIONDEFINITIONS", GetSecureSignedToken( "", AV33MentionDefinitions, context));
         GxWebStd.gx_hidden_field( context, "vCURRENTNOTFICATIONGROUPFILTER", AV28CurrentNotficationGroupFilter);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWP_SDTNOTIFICATIONSDATA", AV25WWP_SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWP_SDTNOTIFICATIONSDATA", AV25WWP_SDTNotificationsData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDISCUSSIONDEFINITIONS", AV29DiscussionDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDISCUSSIONDEFINITIONS", AV29DiscussionDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vDISCUSSIONDEFINITIONS", GetSecureSignedToken( "", AV29DiscussionDefinitions, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFORMDEFINITIONS", AV31FormDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFORMDEFINITIONS", AV31FormDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vFORMDEFINITIONS", GetSecureSignedToken( "", AV31FormDefinitions, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGENDADEFINITIONS", AV27AgendaDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGENDADEFINITIONS", AV27AgendaDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vAGENDADEFINITIONS", GetSecureSignedToken( "", AV27AgendaDefinitions, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNOTIFICATIONDEFINITIONIDEMPTYCOLLECTION", AV35NotificationDefinitionIdEmptyCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNOTIFICATIONDEFINITIONIDEMPTYCOLLECTION", AV35NotificationDefinitionIdEmptyCollection);
         }
         GxWebStd.gx_hidden_field( context, "vSEARCHKEYVALUE", AV42SearchKeyValue);
         GxWebStd.gx_hidden_field( context, "gxhash_vSEARCHKEYVALUE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV42SearchKeyValue, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNOTIFICATIONINFO", AV26NotificationInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNOTIFICATIONINFO", AV26NotificationInfo);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWP_SDTNOTIFICATIONSDATA_UNREAD", AV40WWP_SDTNotificationsData_UnRead);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWP_SDTNOTIFICATIONSDATA_UNREAD", AV40WWP_SDTNotificationsData_UnRead);
         }
         GxWebStd.gx_hidden_field( context, "GROUPEDTABLECONTENT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGroupedtablecontent_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTEREDTABLECONTENT_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divFilteredtablecontent_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NOTIFICATIONMESSAGE_Caption", StringUtil.RTrim( lblNotificationmessage_Caption));
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
         if ( ! ( WebComp_Wcwc_notificationgrouping == null ) )
         {
            WebComp_Wcwc_notificationgrouping.componentjscripts();
         }
         if ( ! ( WebComp_Wcwc_notificationfilteredlist == null ) )
         {
            WebComp_Wcwc_notificationfilteredlist.componentjscripts();
         }
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
            WE7X2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7X2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wp_notificationdashboard.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WP_NotificationDashboard" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Notifications", "") ;
      }

      protected void WB7X0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:stretch;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:flex-start;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Notification Types", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Radio button */
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavNotificationtypes, radavNotificationtypes_Internalname, StringUtil.RTrim( AV37NotificationTypes), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavNotificationtypes_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "HLP_WP_NotificationDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:flex-start;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            ClassString = "BtnInsert";
            StyleString = ((bttBtnfilterbymentions_Backcolor==-1) ? "" : "background-color:"+context.BuildHTMLColor( bttBtnfilterbymentions_Backcolor)+";");
            GxWebStd.gx_button_ctrl( context, bttBtnfilterbymentions_Internalname, "", context.GetMessage( "Mentions", ""), bttBtnfilterbymentions_Jsonclick, 5, context.GetMessage( "Mentions", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOFILTERBYMENTIONS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_NotificationDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            ClassString = "BtnInsert";
            StyleString = ((bttBtnfilterbydiscussions_Backcolor==-1) ? "" : "background-color:"+context.BuildHTMLColor( bttBtnfilterbydiscussions_Backcolor)+";");
            GxWebStd.gx_button_ctrl( context, bttBtnfilterbydiscussions_Internalname, "", context.GetMessage( "Discussions", ""), bttBtnfilterbydiscussions_Jsonclick, 5, context.GetMessage( "Discussions", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOFILTERBYDISCUSSIONS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_NotificationDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            ClassString = "BtnInsert";
            StyleString = ((bttBtnfilterbydynamicforms_Backcolor==-1) ? "" : "background-color:"+context.BuildHTMLColor( bttBtnfilterbydynamicforms_Backcolor)+";");
            GxWebStd.gx_button_ctrl( context, bttBtnfilterbydynamicforms_Internalname, "", bttBtnfilterbydynamicforms_Caption, bttBtnfilterbydynamicforms_Jsonclick, 5, context.GetMessage( "Resident Forms", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOFILTERBYDYNAMICFORMS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_NotificationDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            ClassString = "BtnInsert";
            StyleString = ((bttBtnfilterbyagenda_Backcolor==-1) ? "" : "background-color:"+context.BuildHTMLColor( bttBtnfilterbyagenda_Backcolor)+";");
            GxWebStd.gx_button_ctrl( context, bttBtnfilterbyagenda_Internalname, "", context.GetMessage( "Agenda", ""), bttBtnfilterbyagenda_Jsonclick, 5, context.GetMessage( "Agenda", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOFILTERBYAGENDA\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_NotificationDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            ClassString = "BtnClearActiveFilter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnclearfilters_Internalname, "", context.GetMessage( "Clear Filters", ""), bttBtnclearfilters_Jsonclick, 5, context.GetMessage( "Clear Filters", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOCLEARFILTERS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_NotificationDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:flex-start;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablerightheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;justify-content:flex-end;align-items:flex-start;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSearchkey_Internalname, context.GetMessage( "Search Key", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSearchkey_Internalname, AV41SearchKey, StringUtil.RTrim( context.localUtil.Format( AV41SearchKey, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavSearchkey_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSearchkey_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_NotificationDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedfilterscontainer_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:flex-end;", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 NotificationSubtitleCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNotificationmessage_Internalname, lblNotificationmessage_Caption, "", "", lblNotificationmessage_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_NotificationDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGroupedtablecontent_Internalname, divGroupedtablecontent_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0047"+"", StringUtil.RTrim( WebComp_Wcwc_notificationgrouping_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0047"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwc_notificationgrouping_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwc_notificationgrouping), StringUtil.Lower( WebComp_Wcwc_notificationgrouping_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0047"+"");
                  }
                  WebComp_Wcwc_notificationgrouping.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwc_notificationgrouping), StringUtil.Lower( WebComp_Wcwc_notificationgrouping_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
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
            GxWebStd.gx_div_start( context, divFilteredtablecontent_Internalname, divFilteredtablecontent_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0053"+"", StringUtil.RTrim( WebComp_Wcwc_notificationfilteredlist_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0053"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcwc_notificationfilteredlist_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwc_notificationfilteredlist), StringUtil.Lower( WebComp_Wcwc_notificationfilteredlist_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0053"+"");
                  }
                  WebComp_Wcwc_notificationfilteredlist.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcwc_notificationfilteredlist), StringUtil.Lower( WebComp_Wcwc_notificationfilteredlist_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
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
         }
         wbLoad = true;
      }

      protected void START7X2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Notifications", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7X0( ) ;
      }

      protected void WS7X2( )
      {
         START7X2( ) ;
         EVT7X2( ) ;
      }

      protected void EVT7X2( )
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
                              E117X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFILTERBYMENTIONS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFilterByMentions' */
                              E127X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFILTERBYDISCUSSIONS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFilterByDiscussions' */
                              E137X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFILTERBYDYNAMICFORMS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFilterByDynamicForms' */
                              E147X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFILTERBYAGENDA'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFilterByAgenda' */
                              E157X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCLEARFILTERS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoClearFilters' */
                              E167X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VNOTIFICATIONTYPES.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E177X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Onmessage_gx1 */
                              E187X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSEARCHKEY.CONTROLVALUECHANGING") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E197X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E207X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                                 dynload_actions( ) ;
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Onmessage_gx1 */
                              E187X2 ();
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 47 )
                        {
                           OldWcwc_notificationgrouping = cgiGet( "W0047");
                           if ( ( StringUtil.Len( OldWcwc_notificationgrouping) == 0 ) || ( StringUtil.StrCmp(OldWcwc_notificationgrouping, WebComp_Wcwc_notificationgrouping_Component) != 0 ) )
                           {
                              WebComp_Wcwc_notificationgrouping = getWebComponent(GetType(), "GeneXus.Programs", OldWcwc_notificationgrouping, new Object[] {context} );
                              WebComp_Wcwc_notificationgrouping.ComponentInit();
                              WebComp_Wcwc_notificationgrouping.Name = "OldWcwc_notificationgrouping";
                              WebComp_Wcwc_notificationgrouping_Component = OldWcwc_notificationgrouping;
                           }
                           if ( StringUtil.Len( WebComp_Wcwc_notificationgrouping_Component) != 0 )
                           {
                              WebComp_Wcwc_notificationgrouping.componentprocess("W0047", "", sEvt);
                           }
                           WebComp_Wcwc_notificationgrouping_Component = OldWcwc_notificationgrouping;
                        }
                        else if ( nCmpId == 53 )
                        {
                           OldWcwc_notificationfilteredlist = cgiGet( "W0053");
                           if ( ( StringUtil.Len( OldWcwc_notificationfilteredlist) == 0 ) || ( StringUtil.StrCmp(OldWcwc_notificationfilteredlist, WebComp_Wcwc_notificationfilteredlist_Component) != 0 ) )
                           {
                              WebComp_Wcwc_notificationfilteredlist = getWebComponent(GetType(), "GeneXus.Programs", OldWcwc_notificationfilteredlist, new Object[] {context} );
                              WebComp_Wcwc_notificationfilteredlist.ComponentInit();
                              WebComp_Wcwc_notificationfilteredlist.Name = "OldWcwc_notificationfilteredlist";
                              WebComp_Wcwc_notificationfilteredlist_Component = OldWcwc_notificationfilteredlist;
                           }
                           if ( StringUtil.Len( WebComp_Wcwc_notificationfilteredlist_Component) != 0 )
                           {
                              WebComp_Wcwc_notificationfilteredlist.componentprocess("W0053", "", sEvt);
                           }
                           WebComp_Wcwc_notificationfilteredlist_Component = OldWcwc_notificationfilteredlist;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE7X2( )
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

      protected void PA7X2( )
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
               GX_FocusControl = radavNotificationtypes_Internalname;
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
         AssignAttri("", false, "AV37NotificationTypes", AV37NotificationTypes);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF7X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcwc_notificationgrouping_Component) != 0 )
               {
                  WebComp_Wcwc_notificationgrouping.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcwc_notificationfilteredlist_Component) != 0 )
               {
                  WebComp_Wcwc_notificationfilteredlist.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E207X2 ();
            WB7X0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes7X2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMENTIONDEFINITIONS", AV33MentionDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMENTIONDEFINITIONS", AV33MentionDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vMENTIONDEFINITIONS", GetSecureSignedToken( "", AV33MentionDefinitions, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDISCUSSIONDEFINITIONS", AV29DiscussionDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDISCUSSIONDEFINITIONS", AV29DiscussionDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vDISCUSSIONDEFINITIONS", GetSecureSignedToken( "", AV29DiscussionDefinitions, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFORMDEFINITIONS", AV31FormDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFORMDEFINITIONS", AV31FormDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vFORMDEFINITIONS", GetSecureSignedToken( "", AV31FormDefinitions, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGENDADEFINITIONS", AV27AgendaDefinitions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGENDADEFINITIONS", AV27AgendaDefinitions);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vAGENDADEFINITIONS", GetSecureSignedToken( "", AV27AgendaDefinitions, context));
         GxWebStd.gx_hidden_field( context, "vSEARCHKEYVALUE", AV42SearchKeyValue);
         GxWebStd.gx_hidden_field( context, "gxhash_vSEARCHKEYVALUE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV42SearchKeyValue, "")), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E117X2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vNOTIFICATIONINFO"), AV26NotificationInfo);
            /* Read saved values. */
            divGroupedtablecontent_Visible = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GROUPEDTABLECONTENT_Visible"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            divFilteredtablecontent_Visible = (int)(Math.Round(context.localUtil.CToN( cgiGet( "FILTEREDTABLECONTENT_Visible"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            lblNotificationmessage_Caption = cgiGet( "NOTIFICATIONMESSAGE_Caption");
            /* Read variables values. */
            AV37NotificationTypes = cgiGet( radavNotificationtypes_Internalname);
            AssignAttri("", false, "AV37NotificationTypes", AV37NotificationTypes);
            AV41SearchKey = cgiGet( edtavSearchkey_Internalname);
            AssignAttri("", false, "AV41SearchKey", AV41SearchKey);
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
         E117X2 ();
         if (returnInSub) return;
      }

      protected void E117X2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV38NumberOfUnRead = "-";
         AV37NotificationTypes = "UnRead";
         AssignAttri("", false, "AV37NotificationTypes", AV37NotificationTypes);
         AV28CurrentNotficationGroupFilter = "";
         AssignAttri("", false, "AV28CurrentNotficationGroupFilter", AV28CurrentNotficationGroupFilter);
         new prc_getallnotificationdefinitionids(context ).execute( out  AV27AgendaDefinitions, out  AV31FormDefinitions, out  AV29DiscussionDefinitions, out  AV33MentionDefinitions) ;
         GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1 = AV25WWP_SDTNotificationsData;
         new dp_getusernotifications(context ).execute(  "UnRead",  AV35NotificationDefinitionIdEmptyCollection,  "", out  GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1) ;
         AV25WWP_SDTNotificationsData = GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1;
         /* Execute user subroutine: 'GETNUMBEROFUNREADNOTIFICATIONS' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcwc_notificationfilteredlist = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwc_notificationfilteredlist_Component), StringUtil.Lower( "WC_NotificationFilteredList")) != 0 )
         {
            WebComp_Wcwc_notificationfilteredlist = getWebComponent(GetType(), "GeneXus.Programs", "wc_notificationfilteredlist", new Object[] {context} );
            WebComp_Wcwc_notificationfilteredlist.ComponentInit();
            WebComp_Wcwc_notificationfilteredlist.Name = "WC_NotificationFilteredList";
            WebComp_Wcwc_notificationfilteredlist_Component = "WC_NotificationFilteredList";
         }
         if ( StringUtil.Len( WebComp_Wcwc_notificationfilteredlist_Component) != 0 )
         {
            WebComp_Wcwc_notificationfilteredlist.setjustcreated();
            WebComp_Wcwc_notificationfilteredlist.componentprepare(new Object[] {(string)"W0053",(string)"",(GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem>)AV25WWP_SDTNotificationsData});
            WebComp_Wcwc_notificationfilteredlist.componentbind(new Object[] {(string)""});
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcwc_notificationgrouping = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwc_notificationgrouping_Component), StringUtil.Lower( "WC_NotificationGrouping")) != 0 )
         {
            WebComp_Wcwc_notificationgrouping = getWebComponent(GetType(), "GeneXus.Programs", "wc_notificationgrouping", new Object[] {context} );
            WebComp_Wcwc_notificationgrouping.ComponentInit();
            WebComp_Wcwc_notificationgrouping.Name = "WC_NotificationGrouping";
            WebComp_Wcwc_notificationgrouping_Component = "WC_NotificationGrouping";
         }
         if ( StringUtil.Len( WebComp_Wcwc_notificationgrouping_Component) != 0 )
         {
            WebComp_Wcwc_notificationgrouping.setjustcreated();
            WebComp_Wcwc_notificationgrouping.componentprepare(new Object[] {(string)"W0047",(string)""});
            WebComp_Wcwc_notificationgrouping.componentbind(new Object[] {});
         }
         /* Execute user subroutine: 'SETACTIVEFILTER' */
         S132 ();
         if (returnInSub) return;
         GXt_char2 = AV47ResidentTitle;
         new prc_getorganisationdefinition(context ).execute(  "Resident", out  GXt_char2) ;
         AV47ResidentTitle = GXt_char2;
         bttBtnfilterbydynamicforms_Caption = AV47ResidentTitle+" "+context.GetMessage( "Forms", "");
         AssignProp("", false, bttBtnfilterbydynamicforms_Internalname, "Caption", bttBtnfilterbydynamicforms_Caption, true);
      }

      protected void E127X2( )
      {
         /* 'DoFilterByMentions' Routine */
         returnInSub = false;
         AV37NotificationTypes = "";
         AssignAttri("", false, "AV37NotificationTypes", AV37NotificationTypes);
         AV28CurrentNotficationGroupFilter = "Mentions";
         AssignAttri("", false, "AV28CurrentNotficationGroupFilter", AV28CurrentNotficationGroupFilter);
         /* Execute user subroutine: 'SETACTIVEFILTER' */
         S132 ();
         if (returnInSub) return;
         AV25WWP_SDTNotificationsData = new GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem>( context, "USDTNotificationsDataItem", "Comforta_version2");
         GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1 = AV25WWP_SDTNotificationsData;
         new dp_getusernotifications(context ).execute(  "",  AV33MentionDefinitions,  "", out  GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1) ;
         AV25WWP_SDTNotificationsData = GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1;
         /* Execute user subroutine: 'REFRESHNOTIFICATIONCOMPONENT' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         radavNotificationtypes.CurrentValue = StringUtil.RTrim( AV37NotificationTypes);
         AssignProp("", false, radavNotificationtypes_Internalname, "Values", radavNotificationtypes.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25WWP_SDTNotificationsData", AV25WWP_SDTNotificationsData);
      }

      protected void E137X2( )
      {
         /* 'DoFilterByDiscussions' Routine */
         returnInSub = false;
         AV37NotificationTypes = "";
         AssignAttri("", false, "AV37NotificationTypes", AV37NotificationTypes);
         AV28CurrentNotficationGroupFilter = "Discussions";
         AssignAttri("", false, "AV28CurrentNotficationGroupFilter", AV28CurrentNotficationGroupFilter);
         /* Execute user subroutine: 'SETACTIVEFILTER' */
         S132 ();
         if (returnInSub) return;
         AV25WWP_SDTNotificationsData = new GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem>( context, "USDTNotificationsDataItem", "Comforta_version2");
         GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1 = AV25WWP_SDTNotificationsData;
         new dp_getusernotifications(context ).execute(  "",  AV29DiscussionDefinitions,  "", out  GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1) ;
         AV25WWP_SDTNotificationsData = GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1;
         /* Execute user subroutine: 'REFRESHNOTIFICATIONCOMPONENT' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         radavNotificationtypes.CurrentValue = StringUtil.RTrim( AV37NotificationTypes);
         AssignProp("", false, radavNotificationtypes_Internalname, "Values", radavNotificationtypes.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25WWP_SDTNotificationsData", AV25WWP_SDTNotificationsData);
      }

      protected void E147X2( )
      {
         /* 'DoFilterByDynamicForms' Routine */
         returnInSub = false;
         AV37NotificationTypes = "";
         AssignAttri("", false, "AV37NotificationTypes", AV37NotificationTypes);
         AV28CurrentNotficationGroupFilter = "Forms";
         AssignAttri("", false, "AV28CurrentNotficationGroupFilter", AV28CurrentNotficationGroupFilter);
         /* Execute user subroutine: 'SETACTIVEFILTER' */
         S132 ();
         if (returnInSub) return;
         AV25WWP_SDTNotificationsData = new GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem>( context, "USDTNotificationsDataItem", "Comforta_version2");
         GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1 = AV25WWP_SDTNotificationsData;
         new dp_getusernotifications(context ).execute(  "",  AV31FormDefinitions,  "", out  GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1) ;
         AV25WWP_SDTNotificationsData = GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1;
         /* Execute user subroutine: 'REFRESHNOTIFICATIONCOMPONENT' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         radavNotificationtypes.CurrentValue = StringUtil.RTrim( AV37NotificationTypes);
         AssignProp("", false, radavNotificationtypes_Internalname, "Values", radavNotificationtypes.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25WWP_SDTNotificationsData", AV25WWP_SDTNotificationsData);
      }

      protected void E157X2( )
      {
         /* 'DoFilterByAgenda' Routine */
         returnInSub = false;
         AV37NotificationTypes = "";
         AssignAttri("", false, "AV37NotificationTypes", AV37NotificationTypes);
         AV28CurrentNotficationGroupFilter = "Agenda";
         AssignAttri("", false, "AV28CurrentNotficationGroupFilter", AV28CurrentNotficationGroupFilter);
         /* Execute user subroutine: 'SETACTIVEFILTER' */
         S132 ();
         if (returnInSub) return;
         AV25WWP_SDTNotificationsData = new GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem>( context, "USDTNotificationsDataItem", "Comforta_version2");
         GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1 = AV25WWP_SDTNotificationsData;
         new dp_getusernotifications(context ).execute(  "",  AV27AgendaDefinitions,  "", out  GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1) ;
         AV25WWP_SDTNotificationsData = GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1;
         /* Execute user subroutine: 'REFRESHNOTIFICATIONCOMPONENT' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         radavNotificationtypes.CurrentValue = StringUtil.RTrim( AV37NotificationTypes);
         AssignProp("", false, radavNotificationtypes_Internalname, "Values", radavNotificationtypes.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25WWP_SDTNotificationsData", AV25WWP_SDTNotificationsData);
      }

      protected void E167X2( )
      {
         /* 'DoClearFilters' Routine */
         returnInSub = false;
         AV37NotificationTypes = "UnRead";
         AssignAttri("", false, "AV37NotificationTypes", AV37NotificationTypes);
         AV32isFilterByRead = false;
         AV28CurrentNotficationGroupFilter = "";
         AssignAttri("", false, "AV28CurrentNotficationGroupFilter", AV28CurrentNotficationGroupFilter);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41SearchKey)) )
         {
            AV41SearchKey = "";
            AssignAttri("", false, "AV41SearchKey", AV41SearchKey);
         }
         if ( StringUtil.StrCmp(AV37NotificationTypes, "UnRead") == 0 )
         {
            AV32isFilterByRead = false;
            AV25WWP_SDTNotificationsData = new GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem>( context, "USDTNotificationsDataItem", "Comforta_version2");
            GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1 = AV25WWP_SDTNotificationsData;
            new dp_getusernotifications(context ).execute(  "UnRead",  AV35NotificationDefinitionIdEmptyCollection,  "", out  GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1) ;
            AV25WWP_SDTNotificationsData = GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1;
         }
         /* Execute user subroutine: 'SETACTIVEFILTER' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'REFRESHNOTIFICATIONCOMPONENT' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         radavNotificationtypes.CurrentValue = StringUtil.RTrim( AV37NotificationTypes);
         AssignProp("", false, radavNotificationtypes_Internalname, "Values", radavNotificationtypes.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25WWP_SDTNotificationsData", AV25WWP_SDTNotificationsData);
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         divGroupedtablecontent_Visible = (((StringUtil.StrCmp(AV37NotificationTypes, "All")==0)&&(StringUtil.StrCmp(AV28CurrentNotficationGroupFilter, "")==0)) ? 1 : 0);
         AssignProp("", false, divGroupedtablecontent_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGroupedtablecontent_Visible), 5, 0), true);
         divFilteredtablecontent_Visible = (((StringUtil.StrCmp(AV37NotificationTypes, "All")!=0)||(StringUtil.StrCmp(AV28CurrentNotficationGroupFilter, "")!=0)) ? 1 : 0);
         AssignProp("", false, divFilteredtablecontent_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divFilteredtablecontent_Visible), 5, 0), true);
      }

      protected void E177X2( )
      {
         /* Notificationtypes_Controlvaluechanged Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV37NotificationTypes, "Read") == 0 )
         {
            AV32isFilterByRead = true;
            AV25WWP_SDTNotificationsData = new GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem>( context, "USDTNotificationsDataItem", "Comforta_version2");
            GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1 = AV25WWP_SDTNotificationsData;
            new dp_getusernotifications(context ).execute(  AV37NotificationTypes,  AV35NotificationDefinitionIdEmptyCollection,  "", out  GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1) ;
            AV25WWP_SDTNotificationsData = GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1;
         }
         else if ( StringUtil.StrCmp(AV37NotificationTypes, "UnRead") == 0 )
         {
            AV32isFilterByRead = false;
            AV25WWP_SDTNotificationsData = new GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem>( context, "USDTNotificationsDataItem", "Comforta_version2");
            GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1 = AV25WWP_SDTNotificationsData;
            new dp_getusernotifications(context ).execute(  AV37NotificationTypes,  AV35NotificationDefinitionIdEmptyCollection,  "", out  GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1) ;
            AV25WWP_SDTNotificationsData = GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1;
         }
         else
         {
            AV32isFilterByRead = false;
         }
         AV28CurrentNotficationGroupFilter = "";
         AssignAttri("", false, "AV28CurrentNotficationGroupFilter", AV28CurrentNotficationGroupFilter);
         /* Execute user subroutine: 'SETACTIVEFILTER' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'REFRESHNOTIFICATIONCOMPONENT' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25WWP_SDTNotificationsData", AV25WWP_SDTNotificationsData);
      }

      protected void E187X2( )
      {
         /* Onmessage_gx1 Routine */
         returnInSub = false;
         new prc_logtofile(context ).execute(  context.GetMessage( "Notification *****", "")+AV26NotificationInfo.ToJSonString(false, true)) ;
         if ( StringUtil.Contains( AV26NotificationInfo.gxTpr_Id, "WebNotification") )
         {
            AV25WWP_SDTNotificationsData = new GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem>( context, "USDTNotificationsDataItem", "Comforta_version2");
            /* Execute user subroutine: 'GETNUMBEROFUNREADNOTIFICATIONS' */
            S112 ();
            if (returnInSub) return;
            if ( StringUtil.StrCmp(AV37NotificationTypes, "Read") == 0 )
            {
               AV32isFilterByRead = true;
               GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1 = AV25WWP_SDTNotificationsData;
               new dp_getusernotifications(context ).execute(  "Read",  AV35NotificationDefinitionIdEmptyCollection,  "", out  GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1) ;
               AV25WWP_SDTNotificationsData = GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1;
            }
            else if ( StringUtil.StrCmp(AV37NotificationTypes, "UnRead") == 0 )
            {
               AV32isFilterByRead = false;
               AV25WWP_SDTNotificationsData = AV40WWP_SDTNotificationsData_UnRead;
            }
            else
            {
               AV32isFilterByRead = false;
               context.DoAjaxRefreshCmp("W0047"+"");
            }
            /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
            S122 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'REFRESHNOTIFICATIONCOMPONENT' */
            S142 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25WWP_SDTNotificationsData", AV25WWP_SDTNotificationsData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40WWP_SDTNotificationsData_UnRead", AV40WWP_SDTNotificationsData_UnRead);
      }

      protected void E197X2( )
      {
         /* Searchkey_Controlvaluechanging Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV41SearchKey))) )
         {
            AV37NotificationTypes = "All";
            AssignAttri("", false, "AV37NotificationTypes", AV37NotificationTypes);
            AV28CurrentNotficationGroupFilter = StringUtil.Lower( AV41SearchKey);
            AssignAttri("", false, "AV28CurrentNotficationGroupFilter", AV28CurrentNotficationGroupFilter);
            AV25WWP_SDTNotificationsData = new GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem>( context, "USDTNotificationsDataItem", "Comforta_version2");
            GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1 = AV25WWP_SDTNotificationsData;
            new dp_getusernotifications(context ).execute(  "",  AV35NotificationDefinitionIdEmptyCollection,  AV28CurrentNotficationGroupFilter, out  GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1) ;
            AV25WWP_SDTNotificationsData = GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1;
         }
         else
         {
            AV37NotificationTypes = "All";
            AssignAttri("", false, "AV37NotificationTypes", AV37NotificationTypes);
            AV28CurrentNotficationGroupFilter = "";
            AssignAttri("", false, "AV28CurrentNotficationGroupFilter", AV28CurrentNotficationGroupFilter);
         }
         /* Execute user subroutine: 'REFRESHNOTIFICATIONCOMPONENT' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25WWP_SDTNotificationsData", AV25WWP_SDTNotificationsData);
         radavNotificationtypes.CurrentValue = StringUtil.RTrim( AV37NotificationTypes);
         AssignProp("", false, radavNotificationtypes_Internalname, "Values", radavNotificationtypes.ToJavascriptSource(), true);
      }

      protected void S112( )
      {
         /* 'GETNUMBEROFUNREADNOTIFICATIONS' Routine */
         returnInSub = false;
         GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1 = AV40WWP_SDTNotificationsData_UnRead;
         new dp_getusernotifications(context ).execute(  "UnRead",  AV35NotificationDefinitionIdEmptyCollection,  "", out  GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1) ;
         AV40WWP_SDTNotificationsData_UnRead = GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1;
         AV38NumberOfUnRead = StringUtil.Str( (decimal)(AV40WWP_SDTNotificationsData_UnRead.Count), 9, 0);
         lblNotificationmessage_Caption = context.GetMessage( "YOU HAVE ", "")+AV38NumberOfUnRead+context.GetMessage( " UNREAD MESSAGES", "");
         AssignProp("", false, lblNotificationmessage_Internalname, "Caption", lblNotificationmessage_Caption, true);
      }

      protected void S132( )
      {
         /* 'SETACTIVEFILTER' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28CurrentNotficationGroupFilter, "Mentions") == 0 )
         {
            bttBtnfilterbymentions_Backcolor = GXUtil.RGB( 0, 0, 0);
            AssignProp("", false, bttBtnfilterbymentions_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbymentions_Backcolor), 9, 0), true);
            bttBtnfilterbydiscussions_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbydiscussions_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbydiscussions_Backcolor), 9, 0), true);
            bttBtnfilterbydynamicforms_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbydynamicforms_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbydynamicforms_Backcolor), 9, 0), true);
            bttBtnfilterbyagenda_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbyagenda_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbyagenda_Backcolor), 9, 0), true);
         }
         else if ( StringUtil.StrCmp(AV28CurrentNotficationGroupFilter, "Discussions") == 0 )
         {
            bttBtnfilterbydiscussions_Backcolor = GXUtil.RGB( 0, 0, 0);
            AssignProp("", false, bttBtnfilterbydiscussions_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbydiscussions_Backcolor), 9, 0), true);
            bttBtnfilterbymentions_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbymentions_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbymentions_Backcolor), 9, 0), true);
            bttBtnfilterbydynamicforms_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbydynamicforms_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbydynamicforms_Backcolor), 9, 0), true);
            bttBtnfilterbyagenda_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbyagenda_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbyagenda_Backcolor), 9, 0), true);
         }
         else if ( StringUtil.StrCmp(AV28CurrentNotficationGroupFilter, "Forms") == 0 )
         {
            bttBtnfilterbydynamicforms_Backcolor = GXUtil.RGB( 0, 0, 0);
            AssignProp("", false, bttBtnfilterbydynamicforms_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbydynamicforms_Backcolor), 9, 0), true);
            bttBtnfilterbydiscussions_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbydiscussions_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbydiscussions_Backcolor), 9, 0), true);
            bttBtnfilterbymentions_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbymentions_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbymentions_Backcolor), 9, 0), true);
            bttBtnfilterbyagenda_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbyagenda_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbyagenda_Backcolor), 9, 0), true);
         }
         else if ( StringUtil.StrCmp(AV28CurrentNotficationGroupFilter, "Agenda") == 0 )
         {
            bttBtnfilterbyagenda_Backcolor = GXUtil.RGB( 0, 0, 0);
            AssignProp("", false, bttBtnfilterbyagenda_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbyagenda_Backcolor), 9, 0), true);
            bttBtnfilterbydiscussions_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbydiscussions_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbydiscussions_Backcolor), 9, 0), true);
            bttBtnfilterbymentions_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbymentions_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbymentions_Backcolor), 9, 0), true);
            bttBtnfilterbydynamicforms_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbydynamicforms_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbydynamicforms_Backcolor), 9, 0), true);
         }
         else
         {
            bttBtnfilterbydiscussions_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbydiscussions_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbydiscussions_Backcolor), 9, 0), true);
            bttBtnfilterbymentions_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbymentions_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbymentions_Backcolor), 9, 0), true);
            bttBtnfilterbydynamicforms_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbydynamicforms_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbydynamicforms_Backcolor), 9, 0), true);
            bttBtnfilterbyagenda_Backcolor = GXUtil.RGB( 34, 47, 84);
            AssignProp("", false, bttBtnfilterbyagenda_Internalname, "Backcolor", StringUtil.LTrimStr( (decimal)(bttBtnfilterbyagenda_Backcolor), 9, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'REFRESHNOTIFICATIONCOMPONENT' Routine */
         returnInSub = false;
         AV46DataOfNotifications = (GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem>)(AV25WWP_SDTNotificationsData.Clone());
         if ( ( StringUtil.StrCmp(AV37NotificationTypes, "All") != 0 ) || ( StringUtil.StrCmp(AV28CurrentNotficationGroupFilter, "") != 0 ) )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcwc_notificationfilteredlist = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwc_notificationfilteredlist_Component), StringUtil.Lower( "WC_NotificationFilteredList")) != 0 )
            {
               WebComp_Wcwc_notificationfilteredlist = getWebComponent(GetType(), "GeneXus.Programs", "wc_notificationfilteredlist", new Object[] {context} );
               WebComp_Wcwc_notificationfilteredlist.ComponentInit();
               WebComp_Wcwc_notificationfilteredlist.Name = "WC_NotificationFilteredList";
               WebComp_Wcwc_notificationfilteredlist_Component = "WC_NotificationFilteredList";
            }
            if ( StringUtil.Len( WebComp_Wcwc_notificationfilteredlist_Component) != 0 )
            {
               WebComp_Wcwc_notificationfilteredlist.setjustcreated();
               WebComp_Wcwc_notificationfilteredlist.componentprepare(new Object[] {(string)"W0053",(string)"",(GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem>)AV46DataOfNotifications});
               WebComp_Wcwc_notificationfilteredlist.componentbind(new Object[] {(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcwc_notificationfilteredlist )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0053"+"");
               WebComp_Wcwc_notificationfilteredlist.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E207X2( )
      {
         /* Load Routine */
         returnInSub = false;
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
         PA7X2( ) ;
         WS7X2( ) ;
         WE7X2( ) ;
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
         if ( ! ( WebComp_Wcwc_notificationgrouping == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwc_notificationgrouping_Component) != 0 )
            {
               WebComp_Wcwc_notificationgrouping.componentthemes();
            }
         }
         if ( ! ( WebComp_Wcwc_notificationfilteredlist == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwc_notificationfilteredlist_Component) != 0 )
            {
               WebComp_Wcwc_notificationfilteredlist.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257212564896", true, true);
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
         context.AddJavascriptSource("wp_notificationdashboard.js", "?20257212564896", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         radavNotificationtypes.Name = "vNOTIFICATIONTYPES";
         radavNotificationtypes.WebTags = "";
         radavNotificationtypes.addItem("UnRead", context.GetMessage( "UnRead", ""), 0);
         radavNotificationtypes.addItem("Read", context.GetMessage( "Read", ""), 0);
         radavNotificationtypes.addItem("All", context.GetMessage( "All", ""), 0);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         radavNotificationtypes_Internalname = "vNOTIFICATIONTYPES";
         bttBtnfilterbymentions_Internalname = "BTNFILTERBYMENTIONS";
         bttBtnfilterbydiscussions_Internalname = "BTNFILTERBYDISCUSSIONS";
         bttBtnfilterbydynamicforms_Internalname = "BTNFILTERBYDYNAMICFORMS";
         bttBtnfilterbyagenda_Internalname = "BTNFILTERBYAGENDA";
         bttBtnclearfilters_Internalname = "BTNCLEARFILTERS";
         divTableactions_Internalname = "TABLEACTIONS";
         edtavSearchkey_Internalname = "vSEARCHKEY";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         lblNotificationmessage_Internalname = "NOTIFICATIONMESSAGE";
         divGroupedtablecontent_Internalname = "GROUPEDTABLECONTENT";
         divFilteredtablecontent_Internalname = "FILTEREDTABLECONTENT";
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
         divFilteredtablecontent_Visible = 1;
         divGroupedtablecontent_Visible = 1;
         edtavSearchkey_Jsonclick = "";
         edtavSearchkey_Enabled = 1;
         bttBtnfilterbyagenda_Backcolor = (int)(0xF0F0F0);
         bttBtnfilterbydynamicforms_Backcolor = (int)(0xF0F0F0);
         bttBtnfilterbydynamicforms_Caption = context.GetMessage( "Resident Forms", "");
         bttBtnfilterbydiscussions_Backcolor = (int)(0xF0F0F0);
         bttBtnfilterbymentions_Backcolor = (int)(0xF0F0F0);
         radavNotificationtypes_Jsonclick = "";
         lblNotificationmessage_Caption = context.GetMessage( "YOU HAVE 8 UNREAD NOTIFICATIONS", "");
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Notifications", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"radavNotificationtypes"},{"av":"AV37NotificationTypes","fld":"vNOTIFICATIONTYPES"},{"av":"AV33MentionDefinitions","fld":"vMENTIONDEFINITIONS","hsh":true},{"av":"AV29DiscussionDefinitions","fld":"vDISCUSSIONDEFINITIONS","hsh":true},{"av":"AV31FormDefinitions","fld":"vFORMDEFINITIONS","hsh":true},{"av":"AV27AgendaDefinitions","fld":"vAGENDADEFINITIONS","hsh":true},{"av":"AV42SearchKeyValue","fld":"vSEARCHKEYVALUE","hsh":true}]}""");
         setEventMetadata("'DOFILTERBYMENTIONS'","""{"handler":"E127X2","iparms":[{"av":"AV33MentionDefinitions","fld":"vMENTIONDEFINITIONS","hsh":true},{"av":"AV28CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"av":"AV25WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA"},{"av":"radavNotificationtypes"},{"av":"AV37NotificationTypes","fld":"vNOTIFICATIONTYPES"}]""");
         setEventMetadata("'DOFILTERBYMENTIONS'",""","oparms":[{"av":"radavNotificationtypes"},{"av":"AV37NotificationTypes","fld":"vNOTIFICATIONTYPES"},{"av":"AV28CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"av":"AV25WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA"},{"ctrl":"BTNFILTERBYMENTIONS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYDISCUSSIONS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYDYNAMICFORMS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYAGENDA","prop":"Backcolor"},{"ctrl":"WCWC_NOTIFICATIONFILTEREDLIST"},{"av":"divGroupedtablecontent_Visible","ctrl":"GROUPEDTABLECONTENT","prop":"Visible"},{"av":"divFilteredtablecontent_Visible","ctrl":"FILTEREDTABLECONTENT","prop":"Visible"}]}""");
         setEventMetadata("'DOFILTERBYDISCUSSIONS'","""{"handler":"E137X2","iparms":[{"av":"AV29DiscussionDefinitions","fld":"vDISCUSSIONDEFINITIONS","hsh":true},{"av":"AV28CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"av":"AV25WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA"},{"av":"radavNotificationtypes"},{"av":"AV37NotificationTypes","fld":"vNOTIFICATIONTYPES"}]""");
         setEventMetadata("'DOFILTERBYDISCUSSIONS'",""","oparms":[{"av":"radavNotificationtypes"},{"av":"AV37NotificationTypes","fld":"vNOTIFICATIONTYPES"},{"av":"AV28CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"av":"AV25WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA"},{"ctrl":"BTNFILTERBYMENTIONS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYDISCUSSIONS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYDYNAMICFORMS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYAGENDA","prop":"Backcolor"},{"ctrl":"WCWC_NOTIFICATIONFILTEREDLIST"},{"av":"divGroupedtablecontent_Visible","ctrl":"GROUPEDTABLECONTENT","prop":"Visible"},{"av":"divFilteredtablecontent_Visible","ctrl":"FILTEREDTABLECONTENT","prop":"Visible"}]}""");
         setEventMetadata("'DOFILTERBYDYNAMICFORMS'","""{"handler":"E147X2","iparms":[{"av":"AV31FormDefinitions","fld":"vFORMDEFINITIONS","hsh":true},{"av":"AV28CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"av":"AV25WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA"},{"av":"radavNotificationtypes"},{"av":"AV37NotificationTypes","fld":"vNOTIFICATIONTYPES"}]""");
         setEventMetadata("'DOFILTERBYDYNAMICFORMS'",""","oparms":[{"av":"radavNotificationtypes"},{"av":"AV37NotificationTypes","fld":"vNOTIFICATIONTYPES"},{"av":"AV28CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"av":"AV25WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA"},{"ctrl":"BTNFILTERBYMENTIONS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYDISCUSSIONS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYDYNAMICFORMS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYAGENDA","prop":"Backcolor"},{"ctrl":"WCWC_NOTIFICATIONFILTEREDLIST"},{"av":"divGroupedtablecontent_Visible","ctrl":"GROUPEDTABLECONTENT","prop":"Visible"},{"av":"divFilteredtablecontent_Visible","ctrl":"FILTEREDTABLECONTENT","prop":"Visible"}]}""");
         setEventMetadata("'DOFILTERBYAGENDA'","""{"handler":"E157X2","iparms":[{"av":"AV27AgendaDefinitions","fld":"vAGENDADEFINITIONS","hsh":true},{"av":"AV28CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"av":"AV25WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA"},{"av":"radavNotificationtypes"},{"av":"AV37NotificationTypes","fld":"vNOTIFICATIONTYPES"}]""");
         setEventMetadata("'DOFILTERBYAGENDA'",""","oparms":[{"av":"radavNotificationtypes"},{"av":"AV37NotificationTypes","fld":"vNOTIFICATIONTYPES"},{"av":"AV28CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"av":"AV25WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA"},{"ctrl":"BTNFILTERBYMENTIONS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYDISCUSSIONS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYDYNAMICFORMS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYAGENDA","prop":"Backcolor"},{"ctrl":"WCWC_NOTIFICATIONFILTEREDLIST"},{"av":"divGroupedtablecontent_Visible","ctrl":"GROUPEDTABLECONTENT","prop":"Visible"},{"av":"divFilteredtablecontent_Visible","ctrl":"FILTEREDTABLECONTENT","prop":"Visible"}]}""");
         setEventMetadata("'DOCLEARFILTERS'","""{"handler":"E167X2","iparms":[{"av":"AV41SearchKey","fld":"vSEARCHKEY"},{"av":"AV35NotificationDefinitionIdEmptyCollection","fld":"vNOTIFICATIONDEFINITIONIDEMPTYCOLLECTION"},{"av":"AV28CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"av":"AV25WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA"},{"av":"radavNotificationtypes"},{"av":"AV37NotificationTypes","fld":"vNOTIFICATIONTYPES"}]""");
         setEventMetadata("'DOCLEARFILTERS'",""","oparms":[{"av":"radavNotificationtypes"},{"av":"AV37NotificationTypes","fld":"vNOTIFICATIONTYPES"},{"av":"AV28CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"av":"AV41SearchKey","fld":"vSEARCHKEY"},{"av":"AV25WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA"},{"ctrl":"BTNFILTERBYMENTIONS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYDISCUSSIONS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYDYNAMICFORMS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYAGENDA","prop":"Backcolor"},{"ctrl":"WCWC_NOTIFICATIONFILTEREDLIST"},{"av":"divGroupedtablecontent_Visible","ctrl":"GROUPEDTABLECONTENT","prop":"Visible"},{"av":"divFilteredtablecontent_Visible","ctrl":"FILTEREDTABLECONTENT","prop":"Visible"}]}""");
         setEventMetadata("VNOTIFICATIONTYPES.CONTROLVALUECHANGED","""{"handler":"E177X2","iparms":[{"av":"radavNotificationtypes"},{"av":"AV37NotificationTypes","fld":"vNOTIFICATIONTYPES"},{"av":"AV35NotificationDefinitionIdEmptyCollection","fld":"vNOTIFICATIONDEFINITIONIDEMPTYCOLLECTION"},{"av":"AV28CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"av":"AV25WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA"}]""");
         setEventMetadata("VNOTIFICATIONTYPES.CONTROLVALUECHANGED",""","oparms":[{"av":"AV25WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA"},{"av":"AV28CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"ctrl":"BTNFILTERBYMENTIONS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYDISCUSSIONS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYDYNAMICFORMS","prop":"Backcolor"},{"ctrl":"BTNFILTERBYAGENDA","prop":"Backcolor"},{"ctrl":"WCWC_NOTIFICATIONFILTEREDLIST"},{"av":"divGroupedtablecontent_Visible","ctrl":"GROUPEDTABLECONTENT","prop":"Visible"},{"av":"divFilteredtablecontent_Visible","ctrl":"FILTEREDTABLECONTENT","prop":"Visible"}]}""");
         setEventMetadata("VSEARCHKEY.CONTROLVALUECHANGING","""{"handler":"E197X2","iparms":[{"av":"AV42SearchKeyValue","fld":"vSEARCHKEYVALUE","hsh":true},{"av":"AV41SearchKey","fld":"vSEARCHKEY"},{"av":"AV35NotificationDefinitionIdEmptyCollection","fld":"vNOTIFICATIONDEFINITIONIDEMPTYCOLLECTION"},{"av":"AV25WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA"},{"av":"radavNotificationtypes"},{"av":"AV37NotificationTypes","fld":"vNOTIFICATIONTYPES"},{"av":"AV28CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"}]""");
         setEventMetadata("VSEARCHKEY.CONTROLVALUECHANGING",""","oparms":[{"av":"AV25WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA"},{"av":"radavNotificationtypes"},{"av":"AV37NotificationTypes","fld":"vNOTIFICATIONTYPES"},{"av":"AV28CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"ctrl":"WCWC_NOTIFICATIONFILTEREDLIST"},{"av":"divGroupedtablecontent_Visible","ctrl":"GROUPEDTABLECONTENT","prop":"Visible"},{"av":"divFilteredtablecontent_Visible","ctrl":"FILTEREDTABLECONTENT","prop":"Visible"}]}""");
         setEventMetadata("ONMESSAGE_GX1","""{"handler":"E187X2","iparms":[{"av":"AV26NotificationInfo","fld":"vNOTIFICATIONINFO"},{"av":"radavNotificationtypes"},{"av":"AV37NotificationTypes","fld":"vNOTIFICATIONTYPES"},{"av":"AV35NotificationDefinitionIdEmptyCollection","fld":"vNOTIFICATIONDEFINITIONIDEMPTYCOLLECTION"},{"av":"AV40WWP_SDTNotificationsData_UnRead","fld":"vWWP_SDTNOTIFICATIONSDATA_UNREAD"},{"av":"AV28CurrentNotficationGroupFilter","fld":"vCURRENTNOTFICATIONGROUPFILTER"},{"av":"AV25WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA"}]""");
         setEventMetadata("ONMESSAGE_GX1",""","oparms":[{"av":"AV25WWP_SDTNotificationsData","fld":"vWWP_SDTNOTIFICATIONSDATA"},{"av":"AV40WWP_SDTNotificationsData_UnRead","fld":"vWWP_SDTNOTIFICATIONSDATA_UNREAD"},{"av":"lblNotificationmessage_Caption","ctrl":"NOTIFICATIONMESSAGE","prop":"Caption"},{"av":"divGroupedtablecontent_Visible","ctrl":"GROUPEDTABLECONTENT","prop":"Visible"},{"av":"divFilteredtablecontent_Visible","ctrl":"FILTEREDTABLECONTENT","prop":"Visible"},{"ctrl":"WCWC_NOTIFICATIONFILTEREDLIST"}]}""");
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
         AV33MentionDefinitions = new GxSimpleCollection<long>();
         AV29DiscussionDefinitions = new GxSimpleCollection<long>();
         AV31FormDefinitions = new GxSimpleCollection<long>();
         AV27AgendaDefinitions = new GxSimpleCollection<long>();
         AV42SearchKeyValue = "";
         GXKey = "";
         AV28CurrentNotficationGroupFilter = "";
         AV25WWP_SDTNotificationsData = new GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem>( context, "USDTNotificationsDataItem", "Comforta_version2");
         AV35NotificationDefinitionIdEmptyCollection = new GxSimpleCollection<long>();
         AV26NotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         AV40WWP_SDTNotificationsData_UnRead = new GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem>( context, "USDTNotificationsDataItem", "Comforta_version2");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV37NotificationTypes = "";
         bttBtnfilterbymentions_Jsonclick = "";
         bttBtnfilterbydiscussions_Jsonclick = "";
         bttBtnfilterbydynamicforms_Jsonclick = "";
         bttBtnfilterbyagenda_Jsonclick = "";
         bttBtnclearfilters_Jsonclick = "";
         AV41SearchKey = "";
         lblNotificationmessage_Jsonclick = "";
         WebComp_Wcwc_notificationgrouping_Component = "";
         OldWcwc_notificationgrouping = "";
         WebComp_Wcwc_notificationfilteredlist_Component = "";
         OldWcwc_notificationfilteredlist = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV38NumberOfUnRead = "";
         AV47ResidentTitle = "";
         GXt_char2 = "";
         GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1 = new GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem>( context, "USDTNotificationsDataItem", "Comforta_version2");
         AV46DataOfNotifications = new GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem>( context, "USDTNotificationsDataItem", "Comforta_version2");
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         WebComp_Wcwc_notificationgrouping = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcwc_notificationfilteredlist = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int divGroupedtablecontent_Visible ;
      private int divFilteredtablecontent_Visible ;
      private int bttBtnfilterbymentions_Backcolor ;
      private int bttBtnfilterbydiscussions_Backcolor ;
      private int bttBtnfilterbydynamicforms_Backcolor ;
      private int bttBtnfilterbyagenda_Backcolor ;
      private int edtavSearchkey_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string lblNotificationmessage_Caption ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string TempTags ;
      private string radavNotificationtypes_Internalname ;
      private string radavNotificationtypes_Jsonclick ;
      private string bttBtnfilterbymentions_Internalname ;
      private string bttBtnfilterbymentions_Jsonclick ;
      private string bttBtnfilterbydiscussions_Internalname ;
      private string bttBtnfilterbydiscussions_Jsonclick ;
      private string bttBtnfilterbydynamicforms_Internalname ;
      private string bttBtnfilterbydynamicforms_Caption ;
      private string bttBtnfilterbydynamicforms_Jsonclick ;
      private string bttBtnfilterbyagenda_Internalname ;
      private string bttBtnfilterbyagenda_Jsonclick ;
      private string bttBtnclearfilters_Internalname ;
      private string bttBtnclearfilters_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string edtavSearchkey_Internalname ;
      private string edtavSearchkey_Jsonclick ;
      private string divAdvancedfilterscontainer_Internalname ;
      private string lblNotificationmessage_Internalname ;
      private string lblNotificationmessage_Jsonclick ;
      private string divGroupedtablecontent_Internalname ;
      private string WebComp_Wcwc_notificationgrouping_Component ;
      private string OldWcwc_notificationgrouping ;
      private string divFilteredtablecontent_Internalname ;
      private string WebComp_Wcwc_notificationfilteredlist_Component ;
      private string OldWcwc_notificationfilteredlist ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV38NumberOfUnRead ;
      private string GXt_char2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wcwc_notificationfilteredlist ;
      private bool bDynCreated_Wcwc_notificationgrouping ;
      private bool AV32isFilterByRead ;
      private string AV42SearchKeyValue ;
      private string AV28CurrentNotficationGroupFilter ;
      private string AV37NotificationTypes ;
      private string AV41SearchKey ;
      private string AV47ResidentTitle ;
      private GXWebComponent WebComp_Wcwc_notificationgrouping ;
      private GXWebComponent WebComp_Wcwc_notificationfilteredlist ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXRadio radavNotificationtypes ;
      private GxSimpleCollection<long> AV33MentionDefinitions ;
      private GxSimpleCollection<long> AV29DiscussionDefinitions ;
      private GxSimpleCollection<long> AV31FormDefinitions ;
      private GxSimpleCollection<long> AV27AgendaDefinitions ;
      private GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem> AV25WWP_SDTNotificationsData ;
      private GxSimpleCollection<long> AV35NotificationDefinitionIdEmptyCollection ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV26NotificationInfo ;
      private GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem> AV40WWP_SDTNotificationsData_UnRead ;
      private GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem> GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem1 ;
      private GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem> AV46DataOfNotifications ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
