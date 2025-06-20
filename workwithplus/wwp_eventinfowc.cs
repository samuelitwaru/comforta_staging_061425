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
namespace GeneXus.Programs.workwithplus {
   public class wwp_eventinfowc : GXWebComponent
   {
      public wwp_eventinfowc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public wwp_eventinfowc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_Gx_mode ,
                           string aP1_CalendarSDTJson ,
                           ref string aP2_CalendarEventId ,
                           ref string aP3_DisabledDaysJson )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV10CalendarSDTJson = aP1_CalendarSDTJson;
         this.AV8CalendarEventId = aP2_CalendarEventId;
         this.AV15DisabledDaysJson = aP3_DisabledDaysJson;
         ExecuteImpl();
         aP0_Gx_mode=this.Gx_mode;
         aP2_CalendarEventId=this.AV8CalendarEventId;
         aP3_DisabledDaysJson=this.AV15DisabledDaysJson;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbavEventtype = new GXCombobox();
         chkavAllday = new GXCheckbox();
         chkavRecurringevent = new GXCheckbox();
         chkavAddrsvp = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "Mode");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  Gx_mode = GetPar( "Mode");
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  AV10CalendarSDTJson = GetPar( "CalendarSDTJson");
                  AssignAttri(sPrefix, false, "AV10CalendarSDTJson", AV10CalendarSDTJson);
                  AV8CalendarEventId = GetPar( "CalendarEventId");
                  AssignAttri(sPrefix, false, "AV8CalendarEventId", AV8CalendarEventId);
                  AV15DisabledDaysJson = GetPar( "DisabledDaysJson");
                  AssignAttri(sPrefix, false, "AV15DisabledDaysJson", AV15DisabledDaysJson);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(string)AV10CalendarSDTJson,(string)AV8CalendarEventId,(string)AV15DisabledDaysJson});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "Mode");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "Mode");
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA4T2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavFromdatedisplay_Enabled = 0;
               AssignProp(sPrefix, false, edtavFromdatedisplay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFromdatedisplay_Enabled), 5, 0), true);
               edtavTodatedisplay_Enabled = 0;
               AssignProp(sPrefix, false, edtavTodatedisplay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTodatedisplay_Enabled), 5, 0), true);
               edtavDuration_Enabled = 0;
               AssignProp(sPrefix, false, edtavDuration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDuration_Enabled), 5, 0), true);
               WS4T2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( context.GetMessage( "Event", "")) ;
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
         }
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "workwithplus.wwp_eventinfowc.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV10CalendarSDTJson)) + "," + UrlEncode(StringUtil.RTrim(AV8CalendarEventId)) + "," + UrlEncode(StringUtil.RTrim(AV15DisabledDaysJson));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.wwp_eventinfowc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vDURATIONHOURS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31DurationHours), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDURATIONHOURS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV31DurationHours), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDISABLEDDAYS", AV14DisabledDays);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDISABLEDDAYS", AV14DisabledDays);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDISABLEDDAYS", GetSecureSignedToken( sPrefix, AV14DisabledDays, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vERRORMESSAGES", AV6ErrorMessages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vERRORMESSAGES", AV6ErrorMessages);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vERRORMESSAGES", GetSecureSignedToken( sPrefix, AV6ErrorMessages, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vRESIDENTADDRESSGROUP", AV51ResidentAddressGroup);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vRESIDENTADDRESSGROUP", AV51ResidentAddressGroup);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTADDRESSGROUP", GetSecureSignedToken( sPrefix, AV51ResidentAddressGroup, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV10CalendarSDTJson", wcpOAV10CalendarSDTJson);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8CalendarEventId", wcpOAV8CalendarEventId);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV15DisabledDaysJson", wcpOAV15DisabledDaysJson);
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDURATIONHOURS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31DurationHours), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDURATIONHOURS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV31DurationHours), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCALENDAREVENTID", AV8CalendarEventId);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vFIXSTARTDATE", AV27FixStartDate);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vFIXSTARTTIME", AV28FixStartTime);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDISABLEDDAYS", AV14DisabledDays);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDISABLEDDAYS", AV14DisabledDays);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDISABLEDDAYS", GetSecureSignedToken( sPrefix, AV14DisabledDays, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV11CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vERRORMESSAGES", AV6ErrorMessages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vERRORMESSAGES", AV6ErrorMessages);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vERRORMESSAGES", GetSecureSignedToken( sPrefix, AV6ErrorMessages, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vRESIDENTADDRESSGROUP", AV51ResidentAddressGroup);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vRESIDENTADDRESSGROUP", AV51ResidentAddressGroup);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTADDRESSGROUP", GetSecureSignedToken( sPrefix, AV51ResidentAddressGroup, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCALENDARSDTJSON", AV10CalendarSDTJson);
         GxWebStd.gx_hidden_field( context, sPrefix+"vDISABLEDDAYSJSON", AV15DisabledDaysJson);
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UADELETE_Title", StringUtil.RTrim( Dvelop_confirmpanel_uadelete_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UADELETE_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_uadelete_Confirmationtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UADELETE_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_uadelete_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UADELETE_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_uadelete_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UADELETE_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_uadelete_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UADELETE_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_uadelete_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UADELETE_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_uadelete_Confirmtype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UADELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_uadelete_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_UADELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_uadelete_Result));
      }

      protected void RenderHtmlCloseForm4T2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "WorkWithPlus.WWP_EventInfoWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Event", "") ;
      }

      protected void WB4T0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.wwp_eventinfowc.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainCalendar", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFromdatedisplay_cell_Internalname, 1, 0, "px", 0, "px", divFromdatedisplay_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedfromdatedisplay_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockfromdatedisplay_Internalname, lblTextblockfromdatedisplay_Caption, "", "", lblTextblockfromdatedisplay_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            wb_table1_20_4T2( true) ;
         }
         else
         {
            wb_table1_20_4T2( false) ;
         }
         return  ;
      }

      protected void wb_table1_20_4T2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTodatedisplay_cell_Internalname, 1, 0, "px", 0, "px", divTodatedisplay_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedtodatedisplay_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocktodatedisplay_Internalname, context.GetMessage( "WWP_Calendar_To", ""), "", "", lblTextblocktodatedisplay_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            wb_table2_34_4T2( true) ;
         }
         else
         {
            wb_table2_34_4T2( false) ;
         }
         return  ;
      }

      protected void wb_table2_34_4T2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDuration_cell_Internalname, 1, 0, "px", 0, "px", divDuration_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavDuration_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDuration_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDuration_Internalname, context.GetMessage( "WWP_Calendar_DurationEvent", ""), "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavDuration_Internalname, AV29Duration, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", 0, edtavDuration_Visible, edtavDuration_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "400", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTitle_cell_Internalname, 1, 0, "px", 0, "px", divTitle_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavTitle_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavTitle_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitle_Internalname, context.GetMessage( "WWP_Calendar_TitleEvent", ""), "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitle_Internalname, AV18Title, StringUtil.RTrim( context.localUtil.Format( AV18Title, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitle_Jsonclick, 0, "Attribute", "", "", "", "", edtavTitle_Visible, edtavTitle_Enabled, 1, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divEventtype_cell_Internalname, 1, 0, "px", 0, "px", divEventtype_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavEventtype.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavEventtype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavEventtype_Internalname, context.GetMessage( "Type", ""), "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavEventtype, cmbavEventtype_Internalname, StringUtil.RTrim( AV40EventType), 1, cmbavEventtype_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavEventtype.Visible, cmbavEventtype.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "", true, 0, "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            cmbavEventtype.CurrentValue = StringUtil.RTrim( AV40EventType);
            AssignProp(sPrefix, false, cmbavEventtype_Internalname, "Values", (string)(cmbavEventtype.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedcurrentdate_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTextblockcurrentdate_cell_Internalname, 1, 0, "px", 0, "px", divTextblockcurrentdate_cell_Class, "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcurrentdate_Internalname, context.GetMessage( "WWP_Calendar_From", ""), "", "", lblTextblockcurrentdate_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            wb_table3_63_4T2( true) ;
         }
         else
         {
            wb_table3_63_4T2( false) ;
         }
         return  ;
      }

      protected void wb_table3_63_4T2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedenddate_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTextblockenddate_cell_Internalname, 1, 0, "px", 0, "px", divTextblockenddate_cell_Class, "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockenddate_Internalname, context.GetMessage( "WWP_Calendar_To", ""), "", "", lblTextblockenddate_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            wb_table4_78_4T2( true) ;
         }
         else
         {
            wb_table4_78_4T2( false) ;
         }
         return  ;
      }

      protected void wb_table4_78_4T2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedallday_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTextblockallday_cell_Internalname, 1, 0, "px", 0, "px", divTextblockallday_cell_Class, "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockallday_Internalname, " ", "", "", lblTextblockallday_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            wb_table5_93_4T2( true) ;
         }
         else
         {
            wb_table5_93_4T2( false) ;
         }
         return  ;
      }

      protected void wb_table5_93_4T2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtnenter_Visible, bttBtnenter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuacancel_Internalname, "", context.GetMessage( "Cancel", ""), bttBtnuacancel_Jsonclick, 7, context.GetMessage( "Cancel", ""), "", StyleString, ClassString, bttBtnuacancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e114t1_client"+"'", TempTags, "", 2, "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuaupdate_Internalname, "", context.GetMessage( "Update", ""), bttBtnuaupdate_Jsonclick, 5, context.GetMessage( "Update", ""), "", StyleString, ClassString, bttBtnuaupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUAUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuadelete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtnuadelete_Jsonclick, 7, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtnuadelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e124t1_client"+"'", TempTags, "", 2, "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRecurringevent_Internalname, StringUtil.BoolToStr( AV42RecurringEvent), "", "", chkavRecurringevent.Visible, 1, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(114, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,114);\"");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAddressgroup_Internalname, AV44AddressGroup.ToString(), AV44AddressGroup.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAddressgroup_Jsonclick, 0, "Attribute", "", "", "", "", edtavAddressgroup_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAddrsvp_Internalname, StringUtil.BoolToStr( AV41AddRSVP), "", "", chkavAddrsvp.Visible, 1, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(116, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,116);\"");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavRecuringeventtype_Internalname, AV43RecuringEventType, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,117);\"", 0, edtavRecuringeventtype_Visible, 1, 0, 80, "chr", 7, "row", 0, StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            wb_table6_118_4T2( true) ;
         }
         else
         {
            wb_table6_118_4T2( false) ;
         }
         return  ;
      }

      protected void wb_table6_118_4T2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4T2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Crypto.GetSiteKey( );
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
               }
            }
            Form.Meta.addItem("description", context.GetMessage( "Event", ""), 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP4T0( ) ;
            }
         }
      }

      protected void WS4T2( )
      {
         START4T2( ) ;
         EVT4T2( ) ;
      }

      protected void EVT4T2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_UADELETE.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Dvelop_confirmpanel_uadelete.Close */
                                    E134T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E144T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E154T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUAUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUAUpdate' */
                                    E164T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VENDDATE.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E174T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCURRENTDATE.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E184T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E194T2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E204T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VALLDAY.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E214T2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavFromdatedisplay_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
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

      protected void WE4T2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4T2( ) ;
            }
         }
      }

      protected void PA4T2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Crypto.GetSiteKey( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
               {
                  GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.wwp_eventinfowc.aspx")), "workwithplus.wwp_eventinfowc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.wwp_eventinfowc.aspx")))) ;
                  }
                  else
                  {
                     GxWebError = 1;
                     context.HttpContext.Response.StatusCode = 403;
                     context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                     context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                     context.WriteHtmlText( "<p /><hr />") ;
                     GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  }
               }
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "Mode");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
                     }
                     if ( toggleJsOutput )
                     {
                        if ( context.isSpaRequest( ) )
                        {
                           enableJsOutput();
                        }
                     }
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavFromdatedisplay_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         if ( cmbavEventtype.ItemCount > 0 )
         {
            AV40EventType = cmbavEventtype.getValidValue(AV40EventType);
            AssignAttri(sPrefix, false, "AV40EventType", AV40EventType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavEventtype.CurrentValue = StringUtil.RTrim( AV40EventType);
            AssignProp(sPrefix, false, cmbavEventtype_Internalname, "Values", cmbavEventtype.ToJavascriptSource(), true);
         }
         AV7AllDay = StringUtil.StrToBool( StringUtil.BoolToStr( AV7AllDay));
         AssignAttri(sPrefix, false, "AV7AllDay", AV7AllDay);
         AV42RecurringEvent = StringUtil.StrToBool( StringUtil.BoolToStr( AV42RecurringEvent));
         AssignAttri(sPrefix, false, "AV42RecurringEvent", AV42RecurringEvent);
         AV41AddRSVP = StringUtil.StrToBool( StringUtil.BoolToStr( AV41AddRSVP));
         AssignAttri(sPrefix, false, "AV41AddRSVP", AV41AddRSVP);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavFromdatedisplay_Enabled = 0;
         AssignProp(sPrefix, false, edtavFromdatedisplay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFromdatedisplay_Enabled), 5, 0), true);
         edtavTodatedisplay_Enabled = 0;
         AssignProp(sPrefix, false, edtavTodatedisplay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTodatedisplay_Enabled), 5, 0), true);
         edtavDuration_Enabled = 0;
         AssignProp(sPrefix, false, edtavDuration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDuration_Enabled), 5, 0), true);
      }

      protected void RF4T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E154T2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E204T2 ();
            WB4T0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4T2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vDURATIONHOURS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31DurationHours), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDURATIONHOURS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV31DurationHours), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDISABLEDDAYS", AV14DisabledDays);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDISABLEDDAYS", AV14DisabledDays);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDISABLEDDAYS", GetSecureSignedToken( sPrefix, AV14DisabledDays, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vERRORMESSAGES", AV6ErrorMessages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vERRORMESSAGES", AV6ErrorMessages);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vERRORMESSAGES", GetSecureSignedToken( sPrefix, AV6ErrorMessages, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vRESIDENTADDRESSGROUP", AV51ResidentAddressGroup);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vRESIDENTADDRESSGROUP", AV51ResidentAddressGroup);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRESIDENTADDRESSGROUP", GetSecureSignedToken( sPrefix, AV51ResidentAddressGroup, context));
      }

      protected void before_start_formulas( )
      {
         edtavFromdatedisplay_Enabled = 0;
         AssignProp(sPrefix, false, edtavFromdatedisplay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFromdatedisplay_Enabled), 5, 0), true);
         edtavTodatedisplay_Enabled = 0;
         AssignProp(sPrefix, false, edtavTodatedisplay_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTodatedisplay_Enabled), 5, 0), true);
         edtavDuration_Enabled = 0;
         AssignProp(sPrefix, false, edtavDuration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDuration_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E144T2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
            wcpOAV10CalendarSDTJson = cgiGet( sPrefix+"wcpOAV10CalendarSDTJson");
            wcpOAV8CalendarEventId = cgiGet( sPrefix+"wcpOAV8CalendarEventId");
            wcpOAV15DisabledDaysJson = cgiGet( sPrefix+"wcpOAV15DisabledDaysJson");
            AV27FixStartDate = StringUtil.StrToBool( cgiGet( sPrefix+"vFIXSTARTDATE"));
            AV28FixStartTime = StringUtil.StrToBool( cgiGet( sPrefix+"vFIXSTARTTIME"));
            Dvelop_confirmpanel_uadelete_Title = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UADELETE_Title");
            Dvelop_confirmpanel_uadelete_Confirmationtext = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UADELETE_Confirmationtext");
            Dvelop_confirmpanel_uadelete_Yesbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UADELETE_Yesbuttoncaption");
            Dvelop_confirmpanel_uadelete_Nobuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UADELETE_Nobuttoncaption");
            Dvelop_confirmpanel_uadelete_Cancelbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UADELETE_Cancelbuttoncaption");
            Dvelop_confirmpanel_uadelete_Yesbuttonposition = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UADELETE_Yesbuttonposition");
            Dvelop_confirmpanel_uadelete_Confirmtype = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UADELETE_Confirmtype");
            Dvelop_confirmpanel_uadelete_Result = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_UADELETE_Result");
            /* Read variables values. */
            AV23FromDateDisplay = cgiGet( edtavFromdatedisplay_Internalname);
            AssignAttri(sPrefix, false, "AV23FromDateDisplay", AV23FromDateDisplay);
            AV24ToDateDisplay = cgiGet( edtavTodatedisplay_Internalname);
            AssignAttri(sPrefix, false, "AV24ToDateDisplay", AV24ToDateDisplay);
            AV29Duration = cgiGet( edtavDuration_Internalname);
            AssignAttri(sPrefix, false, "AV29Duration", AV29Duration);
            AV18Title = cgiGet( edtavTitle_Internalname);
            AssignAttri(sPrefix, false, "AV18Title", AV18Title);
            cmbavEventtype.CurrentValue = cgiGet( cmbavEventtype_Internalname);
            AV40EventType = cgiGet( cmbavEventtype_Internalname);
            AssignAttri(sPrefix, false, "AV40EventType", AV40EventType);
            if ( context.localUtil.VCDate( cgiGet( edtavCurrentdate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Current Date", "")}), 1, "vCURRENTDATE");
               GX_FocusControl = edtavCurrentdate_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12CurrentDate = DateTime.MinValue;
               AssignAttri(sPrefix, false, "AV12CurrentDate", context.localUtil.Format(AV12CurrentDate, "99/99/99"));
            }
            else
            {
               AV12CurrentDate = context.localUtil.CToD( cgiGet( edtavCurrentdate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV12CurrentDate", context.localUtil.Format(AV12CurrentDate, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavFromtime_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {context.GetMessage( "From Time", "")}), 1, "vFROMTIME");
               GX_FocusControl = edtavFromtime_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17FromTime = (DateTime)(DateTime.MinValue);
               AssignAttri(sPrefix, false, "AV17FromTime", context.localUtil.TToC( AV17FromTime, 0, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               AV17FromTime = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtavFromtime_Internalname)));
               AssignAttri(sPrefix, false, "AV17FromTime", context.localUtil.TToC( AV17FromTime, 0, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavEnddate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "End Date", "")}), 1, "vENDDATE");
               GX_FocusControl = edtavEnddate_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16EndDate = DateTime.MinValue;
               AssignAttri(sPrefix, false, "AV16EndDate", context.localUtil.Format(AV16EndDate, "99/99/99"));
            }
            else
            {
               AV16EndDate = context.localUtil.CToD( cgiGet( edtavEnddate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri(sPrefix, false, "AV16EndDate", context.localUtil.Format(AV16EndDate, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavTotime_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {context.GetMessage( "To Time", "")}), 1, "vTOTIME");
               GX_FocusControl = edtavTotime_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV19ToTime = (DateTime)(DateTime.MinValue);
               AssignAttri(sPrefix, false, "AV19ToTime", context.localUtil.TToC( AV19ToTime, 0, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               AV19ToTime = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtavTotime_Internalname)));
               AssignAttri(sPrefix, false, "AV19ToTime", context.localUtil.TToC( AV19ToTime, 0, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            AV7AllDay = StringUtil.StrToBool( cgiGet( chkavAllday_Internalname));
            AssignAttri(sPrefix, false, "AV7AllDay", AV7AllDay);
            AV42RecurringEvent = StringUtil.StrToBool( cgiGet( chkavRecurringevent_Internalname));
            AssignAttri(sPrefix, false, "AV42RecurringEvent", AV42RecurringEvent);
            if ( StringUtil.StrCmp(cgiGet( edtavAddressgroup_Internalname), "") == 0 )
            {
               AV44AddressGroup = Guid.Empty;
               AssignAttri(sPrefix, false, "AV44AddressGroup", AV44AddressGroup.ToString());
            }
            else
            {
               try
               {
                  AV44AddressGroup = StringUtil.StrToGuid( cgiGet( edtavAddressgroup_Internalname));
                  AssignAttri(sPrefix, false, "AV44AddressGroup", AV44AddressGroup.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vADDRESSGROUP");
                  GX_FocusControl = edtavAddressgroup_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV41AddRSVP = StringUtil.StrToBool( cgiGet( chkavAddrsvp_Internalname));
            AssignAttri(sPrefix, false, "AV41AddRSVP", AV41AddRSVP);
            AV43RecuringEventType = cgiGet( edtavRecuringeventtype_Internalname);
            AssignAttri(sPrefix, false, "AV43RecuringEventType", AV43RecuringEventType);
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
         E144T2 ();
         if (returnInSub) return;
      }

      protected void E144T2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            GXt_SdtWWP_Calendar_Events_Item1 = AV9CalendarSDT;
            new GeneXus.Programs.workwithplus.wwp_calendar_getevent(context ).execute(  AV8CalendarEventId, out  GXt_SdtWWP_Calendar_Events_Item1) ;
            AV9CalendarSDT = GXt_SdtWWP_Calendar_Events_Item1;
            AV18Title = AV9CalendarSDT.gxTpr_Title;
            AssignAttri(sPrefix, false, "AV18Title", AV18Title);
            AV50ResidentsOnEvent = (GxSimpleCollection<Guid>)(new GxSimpleCollection<Guid>());
            /* Using cursor H004T2 */
            pr_default.execute(0, new Object[] {AV8CalendarEventId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A268AgendaCalendarId = H004T2_A268AgendaCalendarId[0];
               A62ResidentId = H004T2_A62ResidentId[0];
               AV50ResidentsOnEvent.Add(A62ResidentId, 0);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV50ResidentsOnEvent.Count > 0 )
            {
               AV51ResidentAddressGroup = AV50ResidentsOnEvent;
            }
            else
            {
               AV51ResidentAddressGroup = (GxSimpleCollection<Guid>)(new GxSimpleCollection<Guid>());
            }
         }
         else
         {
            this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "WCPopup_UpdateTitle", new Object[] {context.GetMessage( "WWP_Calendar_NewEvent", "")}, false);
            AV9CalendarSDT.FromJSonString(AV10CalendarSDTJson, null);
         }
         AV7AllDay = AV9CalendarSDT.gxTpr_Allday;
         AssignAttri(sPrefix, false, "AV7AllDay", AV7AllDay);
         AV12CurrentDate = DateTimeUtil.ResetTime(AV9CalendarSDT.gxTpr_Start);
         AssignAttri(sPrefix, false, "AV12CurrentDate", context.localUtil.Format(AV12CurrentDate, "99/99/99"));
         AV16EndDate = DateTimeUtil.ResetTime(AV9CalendarSDT.gxTpr_End);
         AssignAttri(sPrefix, false, "AV16EndDate", context.localUtil.Format(AV16EndDate, "99/99/99"));
         AV17FromTime = DateTimeUtil.ResetDate(AV9CalendarSDT.gxTpr_Start);
         AssignAttri(sPrefix, false, "AV17FromTime", context.localUtil.TToC( AV17FromTime, 0, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV19ToTime = DateTimeUtil.ResetDate(AV9CalendarSDT.gxTpr_End);
         AssignAttri(sPrefix, false, "AV19ToTime", context.localUtil.TToC( AV19ToTime, 0, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || AV7AllDay )
         {
            if ( (DateTime.MinValue==AV17FromTime) && (DateTime.MinValue==AV19ToTime) )
            {
               AV25CurrentTime = DateTimeUtil.Now( context);
               AV17FromTime = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV25CurrentTime)), (short)(DateTimeUtil.Month( AV25CurrentTime)), (short)(DateTimeUtil.Day( AV25CurrentTime)), (short)(DateTimeUtil.Hour( AV25CurrentTime)+1), 0, 0));
               AssignAttri(sPrefix, false, "AV17FromTime", context.localUtil.TToC( AV17FromTime, 0, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV19ToTime = DateTimeUtil.ResetDate(DateTimeUtil.TAdd( AV17FromTime, 3600*(1)));
               AssignAttri(sPrefix, false, "AV19ToTime", context.localUtil.TToC( AV19ToTime, 0, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "WCPopup_UpdateTitle", new Object[] {(string)AV18Title}, false);
            if ( ! AV7AllDay )
            {
               AV32DurationMinutes = (short)(DateTimeUtil.TDiff( AV9CalendarSDT.gxTpr_End, AV9CalendarSDT.gxTpr_Start)/ (decimal)(60));
               AV31DurationHours = (short)(AV32DurationMinutes/ (decimal)(60));
               AssignAttri(sPrefix, false, "AV31DurationHours", StringUtil.LTrimStr( (decimal)(AV31DurationHours), 4, 0));
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDURATIONHOURS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV31DurationHours), "ZZZ9"), context));
               if ( AV31DurationHours < 24 )
               {
                  if ( ((int)((AV32DurationMinutes) % (60))) == 0 )
                  {
                     AV29Duration = StringUtil.Format( "%1 %2", StringUtil.Str( (decimal)(AV31DurationHours), 4, 0), ((AV31DurationHours==1) ? context.GetMessage( "hour", "") : context.GetMessage( "hours", "")), "", "", "", "", "", "", "");
                     AssignAttri(sPrefix, false, "AV29Duration", AV29Duration);
                  }
                  else
                  {
                     if ( AV31DurationHours > 0 )
                     {
                        AV33Minutes = (short)(AV32DurationMinutes-(AV31DurationHours*60));
                        AV29Duration = StringUtil.Format( context.GetMessage( "%1 %2 and %3 %4", ""), StringUtil.Str( (decimal)(AV31DurationHours), 4, 0), ((AV31DurationHours==1) ? context.GetMessage( "hour", "") : context.GetMessage( "hours", "")), StringUtil.Str( (decimal)(AV33Minutes), 4, 0), ((AV33Minutes==1) ? context.GetMessage( "minute", "") : context.GetMessage( "minutes", "")), "", "", "", "", "");
                        AssignAttri(sPrefix, false, "AV29Duration", AV29Duration);
                     }
                     else
                     {
                        AV29Duration = StringUtil.Format( "%1 %2", StringUtil.Str( (decimal)(AV32DurationMinutes), 4, 0), ((AV32DurationMinutes==1) ? context.GetMessage( "minute", "") : context.GetMessage( "minutes", "")), "", "", "", "", "", "", "");
                        AssignAttri(sPrefix, false, "AV29Duration", AV29Duration);
                     }
                  }
               }
            }
            if ( DateTimeUtil.ResetTime ( AV12CurrentDate ) == DateTimeUtil.ResetTime ( AV16EndDate ) )
            {
               lblTextblockfromdatedisplay_Caption = context.GetMessage( "Date", "");
               AssignProp(sPrefix, false, lblTextblockfromdatedisplay_Internalname, "Caption", lblTextblockfromdatedisplay_Caption, true);
               if ( AV7AllDay )
               {
                  AV23FromDateDisplay = context.localUtil.Format( AV12CurrentDate, "99/99/99");
                  AssignAttri(sPrefix, false, "AV23FromDateDisplay", AV23FromDateDisplay);
               }
               else
               {
                  AV23FromDateDisplay = StringUtil.Format( "%1 %2 - %3", context.localUtil.Format( AV12CurrentDate, "99/99/99"), context.localUtil.Format( AV17FromTime, "99:99"), context.localUtil.Format( AV19ToTime, "99:99"), "", "", "", "", "", "");
                  AssignAttri(sPrefix, false, "AV23FromDateDisplay", AV23FromDateDisplay);
               }
            }
            else
            {
               lblTextblockfromdatedisplay_Caption = context.GetMessage( "From", "");
               AssignProp(sPrefix, false, lblTextblockfromdatedisplay_Internalname, "Caption", lblTextblockfromdatedisplay_Caption, true);
               if ( AV7AllDay )
               {
                  AV23FromDateDisplay = context.localUtil.Format( AV12CurrentDate, "99/99/99");
                  AssignAttri(sPrefix, false, "AV23FromDateDisplay", AV23FromDateDisplay);
                  AV24ToDateDisplay = context.localUtil.Format( AV16EndDate, "99/99/99");
                  AssignAttri(sPrefix, false, "AV24ToDateDisplay", AV24ToDateDisplay);
               }
               else
               {
                  AV23FromDateDisplay = StringUtil.Format( "%1 %2", context.localUtil.Format( AV12CurrentDate, "99/99/99"), context.localUtil.Format( AV17FromTime, "99:99"), "", "", "", "", "", "", "");
                  AssignAttri(sPrefix, false, "AV23FromDateDisplay", AV23FromDateDisplay);
                  AV24ToDateDisplay = StringUtil.Format( "%1 %2", context.localUtil.Format( AV16EndDate, "99/99/99"), context.localUtil.Format( AV19ToTime, "99:99"), "", "", "", "", "", "", "");
                  AssignAttri(sPrefix, false, "AV24ToDateDisplay", AV24ToDateDisplay);
               }
            }
         }
         AV14DisabledDays.FromJSonString(AV15DisabledDaysJson, null);
         /* Execute user subroutine: 'CHECKDISABLEDDAYS' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SHOWHIDERECURRINGTYPES' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S132 ();
         if (returnInSub) return;
         chkavRecurringevent.Visible = 0;
         AssignProp(sPrefix, false, chkavRecurringevent_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRecurringevent.Visible), 5, 0), true);
         edtavAddressgroup_Visible = 0;
         AssignProp(sPrefix, false, edtavAddressgroup_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAddressgroup_Visible), 5, 0), true);
         chkavAddrsvp.Visible = 0;
         AssignProp(sPrefix, false, chkavAddrsvp_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavAddrsvp.Visible), 5, 0), true);
         edtavRecuringeventtype_Visible = 0;
         AssignProp(sPrefix, false, edtavRecuringeventtype_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRecuringeventtype_Visible), 5, 0), true);
      }

      protected void E154T2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            edtavCurrentdate_Enabled = 0;
            AssignProp(sPrefix, false, edtavCurrentdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCurrentdate_Enabled), 5, 0), true);
            edtavEnddate_Enabled = 0;
            AssignProp(sPrefix, false, edtavEnddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnddate_Enabled), 5, 0), true);
            edtavFromtime_Enabled = 0;
            AssignProp(sPrefix, false, edtavFromtime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFromtime_Enabled), 5, 0), true);
            edtavTotime_Enabled = 0;
            AssignProp(sPrefix, false, edtavTotime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotime_Enabled), 5, 0), true);
            edtavTitle_Enabled = 0;
            AssignProp(sPrefix, false, edtavTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTitle_Enabled), 5, 0), true);
            chkavAllday.Visible = 0;
            AssignProp(sPrefix, false, chkavAllday_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavAllday.Visible), 5, 0), true);
         }
         else
         {
            edtavCurrentdate_Enabled = 1;
            AssignProp(sPrefix, false, edtavCurrentdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCurrentdate_Enabled), 5, 0), true);
            edtavEnddate_Enabled = 1;
            AssignProp(sPrefix, false, edtavEnddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEnddate_Enabled), 5, 0), true);
            edtavFromtime_Enabled = 1;
            AssignProp(sPrefix, false, edtavFromtime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFromtime_Enabled), 5, 0), true);
            edtavTotime_Enabled = 1;
            AssignProp(sPrefix, false, edtavTotime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotime_Enabled), 5, 0), true);
            edtavTitle_Enabled = 1;
            AssignProp(sPrefix, false, edtavTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTitle_Enabled), 5, 0), true);
            chkavAllday.Visible = 1;
            AssignProp(sPrefix, false, chkavAllday_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavAllday.Visible), 5, 0), true);
            if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "WCPopup_UpdateTitle", new Object[] {context.GetMessage( "WWP_Calendar_UpdateEvent", "")}, false);
            }
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E164T2( )
      {
         /* 'DoUAUpdate' Routine */
         returnInSub = false;
         Gx_mode = "UPD";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
      }

      protected void E134T2( )
      {
         /* Dvelop_confirmpanel_uadelete_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_uadelete_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION UADELETE' */
            S152 ();
            if (returnInSub) return;
         }
      }

      protected void S142( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) ) )
         {
            bttBtnenter_Visible = 0;
            AssignProp(sPrefix, false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) ) )
         {
            bttBtnuacancel_Visible = 0;
            AssignProp(sPrefix, false, bttBtnuacancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnuacancel_Visible), 5, 0), true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) ) )
         {
            bttBtnuaupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnuaupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnuaupdate_Visible), 5, 0), true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) ) )
         {
            bttBtnuadelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtnuadelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnuadelete_Visible), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            bttBtnenter_Visible = 1;
            AssignProp(sPrefix, false, bttBtnenter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnenter_Visible), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            bttBtnuacancel_Visible = 1;
            AssignProp(sPrefix, false, bttBtnuacancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnuacancel_Visible), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtnuaupdate_Visible = 1;
            AssignProp(sPrefix, false, bttBtnuaupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnuaupdate_Visible), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtnuadelete_Visible = 1;
            AssignProp(sPrefix, false, bttBtnuadelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnuadelete_Visible), 5, 0), true);
         }
      }

      protected void S152( )
      {
         /* 'DO ACTION UADELETE' Routine */
         returnInSub = false;
         new prc_agendareventdelete(context ).execute(  StringUtil.StrToGuid( AV8CalendarEventId)) ;
         CallWebObject(formatLink("wp_calendaragenda.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void S172( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV11CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18Title)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_Calendar_TitleEvent", ""), "", "", "", "", "", "", "", ""),  "error",  edtavTitle_Internalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( (DateTime.MinValue==AV12CurrentDate) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_Calendar_From", ""), "", "", "", "", "", "", "", ""),  "error",  edtavCurrentdate_Internalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
         if ( (DateTime.MinValue==AV16EndDate) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "WWP_Calendar_To", ""), "", "", "", "", "", "", "", ""),  "error",  edtavEnddate_Internalname,  "true",  ""));
            AV11CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV11CheckRequiredFieldsResult", AV11CheckRequiredFieldsResult);
         }
      }

      protected void S132( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) ) )
         {
            edtavFromdatedisplay_Visible = 0;
            AssignProp(sPrefix, false, edtavFromdatedisplay_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFromdatedisplay_Visible), 5, 0), true);
            divFromdatedisplay_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divFromdatedisplay_cell_Internalname, "Class", divFromdatedisplay_cell_Class, true);
         }
         else
         {
            edtavFromdatedisplay_Visible = 1;
            AssignProp(sPrefix, false, edtavFromdatedisplay_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFromdatedisplay_Visible), 5, 0), true);
            divFromdatedisplay_cell_Class = "col-xs-12 DataContentCell";
            AssignProp(sPrefix, false, divFromdatedisplay_cell_Internalname, "Class", divFromdatedisplay_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && ( DateTimeUtil.ResetTime ( AV12CurrentDate ) != DateTimeUtil.ResetTime ( AV16EndDate ) ) ) )
         {
            edtavTodatedisplay_Visible = 0;
            AssignProp(sPrefix, false, edtavTodatedisplay_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTodatedisplay_Visible), 5, 0), true);
            divTodatedisplay_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divTodatedisplay_cell_Internalname, "Class", divTodatedisplay_cell_Class, true);
         }
         else
         {
            edtavTodatedisplay_Visible = 1;
            AssignProp(sPrefix, false, edtavTodatedisplay_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTodatedisplay_Visible), 5, 0), true);
            divTodatedisplay_cell_Class = "col-xs-12 DataContentCell";
            AssignProp(sPrefix, false, divTodatedisplay_cell_Internalname, "Class", divTodatedisplay_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && ! AV7AllDay && ( AV31DurationHours < 24 ) ) )
         {
            edtavDuration_Visible = 0;
            AssignProp(sPrefix, false, edtavDuration_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDuration_Visible), 5, 0), true);
            divDuration_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divDuration_cell_Internalname, "Class", divDuration_cell_Class, true);
         }
         else
         {
            edtavDuration_Visible = 1;
            AssignProp(sPrefix, false, edtavDuration_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDuration_Visible), 5, 0), true);
            divDuration_cell_Class = "col-xs-12 DataContentCell";
            AssignProp(sPrefix, false, divDuration_cell_Internalname, "Class", divDuration_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 ) ) )
         {
            edtavTitle_Visible = 0;
            AssignProp(sPrefix, false, edtavTitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitle_Visible), 5, 0), true);
            divTitle_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divTitle_cell_Internalname, "Class", divTitle_cell_Class, true);
         }
         else
         {
            edtavTitle_Visible = 1;
            AssignProp(sPrefix, false, edtavTitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitle_Visible), 5, 0), true);
            divTitle_cell_Class = "col-xs-12 RequiredDataContentCell";
            AssignProp(sPrefix, false, divTitle_cell_Internalname, "Class", divTitle_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 ) ) )
         {
            cmbavEventtype.Visible = 0;
            AssignProp(sPrefix, false, cmbavEventtype_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavEventtype.Visible), 5, 0), true);
            divEventtype_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divEventtype_cell_Internalname, "Class", divEventtype_cell_Class, true);
         }
         else
         {
            cmbavEventtype.Visible = 1;
            AssignProp(sPrefix, false, cmbavEventtype_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavEventtype.Visible), 5, 0), true);
            divEventtype_cell_Class = "col-xs-12 DataContentCell";
            AssignProp(sPrefix, false, divEventtype_cell_Internalname, "Class", divEventtype_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 ) ) )
         {
            edtavCurrentdate_Visible = 0;
            AssignProp(sPrefix, false, edtavCurrentdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCurrentdate_Visible), 5, 0), true);
            cellCurrentdate_cell_Class = "Invisible";
            AssignProp(sPrefix, false, cellCurrentdate_cell_Internalname, "Class", cellCurrentdate_cell_Class, true);
            divTextblockcurrentdate_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divTextblockcurrentdate_cell_Internalname, "Class", divTextblockcurrentdate_cell_Class, true);
         }
         else
         {
            edtavCurrentdate_Visible = 1;
            AssignProp(sPrefix, false, edtavCurrentdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCurrentdate_Visible), 5, 0), true);
            cellCurrentdate_cell_Class = "MergeDataCell";
            AssignProp(sPrefix, false, cellCurrentdate_cell_Internalname, "Class", cellCurrentdate_cell_Class, true);
            divTextblockcurrentdate_cell_Class = "col-sm-3 MergeLabelCell";
            AssignProp(sPrefix, false, divTextblockcurrentdate_cell_Internalname, "Class", divTextblockcurrentdate_cell_Class, true);
         }
         if ( ! ( ! AV7AllDay && ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 ) ) )
         {
            edtavFromtime_Visible = 0;
            AssignProp(sPrefix, false, edtavFromtime_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFromtime_Visible), 5, 0), true);
            cellFromtime_cell_Class = "Invisible";
            AssignProp(sPrefix, false, cellFromtime_cell_Internalname, "Class", cellFromtime_cell_Class, true);
         }
         else
         {
            edtavFromtime_Visible = 1;
            AssignProp(sPrefix, false, edtavFromtime_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFromtime_Visible), 5, 0), true);
            cellFromtime_cell_Class = "DataContentCell";
            AssignProp(sPrefix, false, cellFromtime_cell_Internalname, "Class", cellFromtime_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 ) ) )
         {
            edtavEnddate_Visible = 0;
            AssignProp(sPrefix, false, edtavEnddate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEnddate_Visible), 5, 0), true);
            cellEnddate_cell_Class = "Invisible";
            AssignProp(sPrefix, false, cellEnddate_cell_Internalname, "Class", cellEnddate_cell_Class, true);
            divTextblockenddate_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divTextblockenddate_cell_Internalname, "Class", divTextblockenddate_cell_Class, true);
         }
         else
         {
            edtavEnddate_Visible = 1;
            AssignProp(sPrefix, false, edtavEnddate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavEnddate_Visible), 5, 0), true);
            cellEnddate_cell_Class = "MergeDataCell";
            AssignProp(sPrefix, false, cellEnddate_cell_Internalname, "Class", cellEnddate_cell_Class, true);
            divTextblockenddate_cell_Class = "col-sm-3 MergeLabelCell";
            AssignProp(sPrefix, false, divTextblockenddate_cell_Internalname, "Class", divTextblockenddate_cell_Class, true);
         }
         if ( ! ( ! AV7AllDay && ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 ) ) )
         {
            edtavTotime_Visible = 0;
            AssignProp(sPrefix, false, edtavTotime_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTotime_Visible), 5, 0), true);
            cellTotime_cell_Class = "Invisible";
            AssignProp(sPrefix, false, cellTotime_cell_Internalname, "Class", cellTotime_cell_Class, true);
         }
         else
         {
            edtavTotime_Visible = 1;
            AssignProp(sPrefix, false, edtavTotime_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTotime_Visible), 5, 0), true);
            cellTotime_cell_Class = "";
            AssignProp(sPrefix, false, cellTotime_cell_Internalname, "Class", cellTotime_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 ) ) )
         {
            chkavAllday.Visible = 0;
            AssignProp(sPrefix, false, chkavAllday_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavAllday.Visible), 5, 0), true);
            cellAllday_cell_Class = "Invisible";
            AssignProp(sPrefix, false, cellAllday_cell_Internalname, "Class", cellAllday_cell_Class, true);
            divTextblockallday_cell_Class = "Invisible";
            AssignProp(sPrefix, false, divTextblockallday_cell_Internalname, "Class", divTextblockallday_cell_Class, true);
         }
         else
         {
            chkavAllday.Visible = 1;
            AssignProp(sPrefix, false, chkavAllday_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavAllday.Visible), 5, 0), true);
            cellAllday_cell_Class = "MergeDataCell";
            AssignProp(sPrefix, false, cellAllday_cell_Internalname, "Class", cellAllday_cell_Class, true);
            divTextblockallday_cell_Class = "col-sm-3 MergeLabelCell";
            AssignProp(sPrefix, false, divTextblockallday_cell_Internalname, "Class", divTextblockallday_cell_Class, true);
         }
         divRecurringtypestable_Visible = (((StringUtil.StrCmp(Gx_mode, "DSP")!=0)&&(AV42RecurringEvent)) ? 1 : 0);
         AssignProp(sPrefix, false, divRecurringtypestable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divRecurringtypestable_Visible), 5, 0), true);
         lblFromdatedisplay_tags_Caption = "";
         AssignProp(sPrefix, false, lblFromdatedisplay_tags_Internalname, "Caption", lblFromdatedisplay_tags_Caption, true);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && ( DateTimeUtil.ResetTime ( AV12CurrentDate ) == DateTimeUtil.ResetTime ( AV16EndDate ) ) && AV7AllDay )
         {
            lblFromdatedisplay_tags_Caption = lblFromdatedisplay_tags_Caption+StringUtil.Format( "<span class='AttributeTagInfo TagAfterText'>%1</span>", context.GetMessage( "WWP_Calendar_AllDayEvent", ""), "", "", "", "", "", "", "", "");
            AssignProp(sPrefix, false, lblFromdatedisplay_tags_Internalname, "Caption", lblFromdatedisplay_tags_Caption, true);
         }
         lblTodatedisplay_tags_Caption = "";
         AssignProp(sPrefix, false, lblTodatedisplay_tags_Internalname, "Caption", lblTodatedisplay_tags_Caption, true);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && ( DateTimeUtil.ResetTime ( AV12CurrentDate ) != DateTimeUtil.ResetTime ( AV16EndDate ) ) && AV7AllDay )
         {
            lblTodatedisplay_tags_Caption = lblTodatedisplay_tags_Caption+StringUtil.Format( "<span class='AttributeTagInfo TagAfterText'>%1</span>", context.GetMessage( "WWP_Calendar_AllDayEvent", ""), "", "", "", "", "", "", "", "");
            AssignProp(sPrefix, false, lblTodatedisplay_tags_Internalname, "Caption", lblTodatedisplay_tags_Caption, true);
         }
      }

      protected void E174T2( )
      {
         /* Enddate_Controlvaluechanged Routine */
         returnInSub = false;
         AV27FixStartDate = true;
         AssignAttri(sPrefix, false, "AV27FixStartDate", AV27FixStartDate);
         /* Execute user subroutine: 'CHECKDATES' */
         S162 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'CHECKDISABLEDDAYS' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E184T2( )
      {
         /* Currentdate_Controlvaluechanged Routine */
         returnInSub = false;
         AV27FixStartDate = false;
         AssignAttri(sPrefix, false, "AV27FixStartDate", AV27FixStartDate);
         /* Execute user subroutine: 'CHECKDATES' */
         S162 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'CHECKDISABLEDDAYS' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E194T2 ();
         if (returnInSub) return;
      }

      protected void E194T2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S172 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'CHECKDATES' */
         S162 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'CHECKRECURRINGEVENT' */
         S182 ();
         if (returnInSub) return;
         if ( AV11CheckRequiredFieldsResult )
         {
            if ( new GeneXus.Programs.workwithplus.wwp_calendar_editevent(context).executeUdp(  Gx_mode,  AV18Title,  AV12CurrentDate,  AV17FromTime,  AV19ToTime,  AV7AllDay,  AV16EndDate,  AV8CalendarEventId,  AV40EventType,  AV42RecurringEvent,  AV43RecuringEventType,  AV41AddRSVP,  AV51ResidentAddressGroup, out  AV6ErrorMessages) )
            {
               this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "WCPopup_Close", new Object[] {(string)"OK"}, false);
            }
            else
            {
               AV54GXV1 = 1;
               while ( AV54GXV1 <= AV6ErrorMessages.Count )
               {
                  AV5Message = ((GeneXus.Utils.SdtMessages_Message)AV6ErrorMessages.Item(AV54GXV1));
                  GX_msglist.addItem(AV5Message.gxTpr_Description);
                  AV54GXV1 = (int)(AV54GXV1+1);
               }
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E214T2( )
      {
         /* Allday_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S182( )
      {
         /* 'CHECKRECURRINGEVENT' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43RecuringEventType)) )
         {
            AV42RecurringEvent = false;
            AssignAttri(sPrefix, false, "AV42RecurringEvent", AV42RecurringEvent);
         }
      }

      protected void S162( )
      {
         /* 'CHECKDATES' Routine */
         returnInSub = false;
         if ( ( DateTimeUtil.ResetTime ( AV12CurrentDate ) > DateTimeUtil.ResetTime ( AV16EndDate ) ) || ( DateTimeUtil.ResetTime ( AV12CurrentDate ) == DateTimeUtil.ResetTime ( AV16EndDate ) ) )
         {
            if ( AV27FixStartDate )
            {
               AV12CurrentDate = AV16EndDate;
               AssignAttri(sPrefix, false, "AV12CurrentDate", context.localUtil.Format(AV12CurrentDate, "99/99/99"));
            }
            else
            {
               AV16EndDate = AV12CurrentDate;
               AssignAttri(sPrefix, false, "AV16EndDate", context.localUtil.Format(AV16EndDate, "99/99/99"));
            }
            if ( AV17FromTime > AV19ToTime )
            {
               if ( AV28FixStartTime )
               {
                  if ( DateTimeUtil.Hour( AV19ToTime) == 0 )
                  {
                     AV12CurrentDate = DateTimeUtil.DAdd( AV12CurrentDate, (-1));
                     AssignAttri(sPrefix, false, "AV12CurrentDate", context.localUtil.Format(AV12CurrentDate, "99/99/99"));
                  }
                  AV17FromTime = DateTimeUtil.ResetDate(DateTimeUtil.TAdd( AV19ToTime, 3600*(-1)));
                  AssignAttri(sPrefix, false, "AV17FromTime", context.localUtil.TToC( AV17FromTime, 0, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               else
               {
                  if ( DateTimeUtil.Hour( AV17FromTime) == 23 )
                  {
                     AV16EndDate = DateTimeUtil.DAdd( AV16EndDate, (1));
                     AssignAttri(sPrefix, false, "AV16EndDate", context.localUtil.Format(AV16EndDate, "99/99/99"));
                  }
                  AV19ToTime = DateTimeUtil.ResetDate(DateTimeUtil.TAdd( AV17FromTime, 3600*(1)));
                  AssignAttri(sPrefix, false, "AV19ToTime", context.localUtil.TToC( AV19ToTime, 0, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
            }
         }
      }

      protected void S112( )
      {
         /* 'CHECKDISABLEDDAYS' Routine */
         returnInSub = false;
         AV26IncludedInADisableDay = false;
         AV55GXV2 = 1;
         while ( AV55GXV2 <= AV14DisabledDays.Count )
         {
            AV13DisabledDay = AV14DisabledDays.GetDatetime(AV55GXV2);
            if ( ( ( DateTimeUtil.ResetTime ( AV12CurrentDate ) >= DateTimeUtil.ResetTime ( AV13DisabledDay ) ) && ( DateTimeUtil.ResetTime ( AV12CurrentDate ) <= DateTimeUtil.ResetTime ( AV13DisabledDay ) ) ) || ( ( DateTimeUtil.ResetTime ( AV16EndDate ) >= DateTimeUtil.ResetTime ( AV13DisabledDay ) ) && ( DateTimeUtil.ResetTime ( AV16EndDate ) <= DateTimeUtil.ResetTime ( AV13DisabledDay ) ) ) || ( ( DateTimeUtil.ResetTime ( AV13DisabledDay ) >= DateTimeUtil.ResetTime ( AV12CurrentDate ) ) && ( DateTimeUtil.ResetTime ( AV13DisabledDay ) <= DateTimeUtil.ResetTime ( AV16EndDate ) ) ) )
            {
               AV26IncludedInADisableDay = true;
               if (true) break;
            }
            AV55GXV2 = (int)(AV55GXV2+1);
         }
         if ( AV26IncludedInADisableDay )
         {
            GX_msglist.addItem(context.GetMessage( "WWP_Calendar_EventInBlockedDate", ""));
            bttBtnenter_Enabled = 0;
            AssignProp(sPrefix, false, bttBtnenter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtnenter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtnenter_Enabled = 1;
            AssignProp(sPrefix, false, bttBtnenter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtnenter_Enabled), 5, 0), true);
         }
         if ( 1 == 0 )
         {
            new GeneXus.Core.genexus.common.SdtLog(context).error("") ;
         }
      }

      protected void S122( )
      {
         /* 'SHOWHIDERECURRINGTYPES' Routine */
         returnInSub = false;
         if ( AV42RecurringEvent )
         {
            divRecurringtypestable_Visible = 1;
            AssignProp(sPrefix, false, divRecurringtypestable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divRecurringtypestable_Visible), 5, 0), true);
         }
         else
         {
            AV43RecuringEventType = "";
            AssignAttri(sPrefix, false, "AV43RecuringEventType", AV43RecuringEventType);
            divRecurringtypestable_Visible = 0;
            AssignProp(sPrefix, false, divRecurringtypestable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divRecurringtypestable_Visible), 5, 0), true);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E204T2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table6_118_4T2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_uadelete_Internalname, tblTabledvelop_confirmpanel_uadelete_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_uadelete.SetProperty("Title", Dvelop_confirmpanel_uadelete_Title);
            ucDvelop_confirmpanel_uadelete.SetProperty("ConfirmationText", Dvelop_confirmpanel_uadelete_Confirmationtext);
            ucDvelop_confirmpanel_uadelete.SetProperty("YesButtonCaption", Dvelop_confirmpanel_uadelete_Yesbuttoncaption);
            ucDvelop_confirmpanel_uadelete.SetProperty("NoButtonCaption", Dvelop_confirmpanel_uadelete_Nobuttoncaption);
            ucDvelop_confirmpanel_uadelete.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_uadelete_Cancelbuttoncaption);
            ucDvelop_confirmpanel_uadelete.SetProperty("YesButtonPosition", Dvelop_confirmpanel_uadelete_Yesbuttonposition);
            ucDvelop_confirmpanel_uadelete.SetProperty("ConfirmType", Dvelop_confirmpanel_uadelete_Confirmtype);
            ucDvelop_confirmpanel_uadelete.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_uadelete_Internalname, sPrefix+"DVELOP_CONFIRMPANEL_UADELETEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVELOP_CONFIRMPANEL_UADELETEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_118_4T2e( true) ;
         }
         else
         {
            wb_table6_118_4T2e( false) ;
         }
      }

      protected void wb_table5_93_4T2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedallday_Internalname, tblTablemergedallday_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellAllday_cell_Internalname+"\"  class='"+cellAllday_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAllday_Internalname, context.GetMessage( "All Day", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAllday_Internalname, StringUtil.BoolToStr( AV7AllDay), "", context.GetMessage( "All Day", ""), chkavAllday.Visible, chkavAllday.Enabled, "true", context.GetMessage( "WWP_Calendar_AllDayEvent", ""), StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,97);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divRecurringtypestable_Internalname, divRecurringtypestable_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_93_4T2e( true) ;
         }
         else
         {
            wb_table5_93_4T2e( false) ;
         }
      }

      protected void wb_table4_78_4T2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedenddate_Internalname, tblTablemergedenddate_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellEnddate_cell_Internalname+"\"  class='"+cellEnddate_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEnddate_Internalname, context.GetMessage( "End Date", ""), "gx-form-item AttributeDateLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavEnddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavEnddate_Internalname, context.localUtil.Format(AV16EndDate, "99/99/99"), context.localUtil.Format( AV16EndDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,82);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEnddate_Jsonclick, 0, "AttributeDate", "", "", "", "", edtavEnddate_Visible, edtavEnddate_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            GxWebStd.gx_bitmap( context, edtavEnddate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavEnddate_Visible==0)||(edtavEnddate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellTotime_cell_Internalname+"\"  class='"+cellTotime_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotime_Internalname, context.GetMessage( "To Time", ""), "gx-form-item AttributeDateTimeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTotime_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTotime_Internalname, context.localUtil.TToC( AV19ToTime, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( AV19ToTime, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,85);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotime_Jsonclick, 0, "AttributeDateTime", "", "", "", "", edtavTotime_Visible, edtavTotime_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Time", "end", false, "", "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            GxWebStd.gx_bitmap( context, edtavTotime_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavTotime_Visible==0)||(edtavTotime_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_78_4T2e( true) ;
         }
         else
         {
            wb_table4_78_4T2e( false) ;
         }
      }

      protected void wb_table3_63_4T2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedcurrentdate_Internalname, tblTablemergedcurrentdate_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellCurrentdate_cell_Internalname+"\"  class='"+cellCurrentdate_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCurrentdate_Internalname, context.GetMessage( "Current Date", ""), "gx-form-item AttributeDateLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCurrentdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCurrentdate_Internalname, context.localUtil.Format(AV12CurrentDate, "99/99/99"), context.localUtil.Format( AV12CurrentDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,67);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCurrentdate_Jsonclick, 0, "AttributeDate", "", "", "", "", edtavCurrentdate_Visible, edtavCurrentdate_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            GxWebStd.gx_bitmap( context, edtavCurrentdate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavCurrentdate_Visible==0)||(edtavCurrentdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFromtime_cell_Internalname+"\"  class='"+cellFromtime_cell_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFromtime_Internalname, context.GetMessage( "From Time", ""), "gx-form-item AttributeDateTimeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFromtime_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFromtime_Internalname, context.localUtil.TToC( AV17FromTime, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( AV17FromTime, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,70);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFromtime_Jsonclick, 0, "AttributeDateTime", "", "", "", "", edtavFromtime_Visible, edtavFromtime_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Time", "end", false, "", "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            GxWebStd.gx_bitmap( context, edtavFromtime_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavFromtime_Visible==0)||(edtavFromtime_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_63_4T2e( true) ;
         }
         else
         {
            wb_table3_63_4T2e( false) ;
         }
      }

      protected void wb_table2_34_4T2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedtodatedisplay_Internalname, tblTablemergedtodatedisplay_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTodatedisplay_Internalname, context.GetMessage( "To Date Display", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavTodatedisplay_Internalname, AV24ToDateDisplay, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", 0, edtavTodatedisplay_Visible, edtavTodatedisplay_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "400", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTodatedisplay_tags_Internalname, lblTodatedisplay_tags_Caption, "", "", lblTodatedisplay_tags_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_34_4T2e( true) ;
         }
         else
         {
            wb_table2_34_4T2e( false) ;
         }
      }

      protected void wb_table1_20_4T2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedfromdatedisplay_Internalname, tblTablemergedfromdatedisplay_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFromdatedisplay_Internalname, context.GetMessage( "From Date Display", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavFromdatedisplay_Internalname, AV23FromDateDisplay, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", 0, edtavFromdatedisplay_Visible, edtavFromdatedisplay_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "400", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFromdatedisplay_tags_Internalname, lblFromdatedisplay_tags_Caption, "", "", lblFromdatedisplay_tags_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WorkWithPlus/WWP_EventInfoWC.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_20_4T2e( true) ;
         }
         else
         {
            wb_table1_20_4T2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         AV10CalendarSDTJson = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV10CalendarSDTJson", AV10CalendarSDTJson);
         AV8CalendarEventId = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV8CalendarEventId", AV8CalendarEventId);
         AV15DisabledDaysJson = (string)getParm(obj,3);
         AssignAttri(sPrefix, false, "AV15DisabledDaysJson", AV15DisabledDaysJson);
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
         PA4T2( ) ;
         WS4T2( ) ;
         WE4T2( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SITE ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV10CalendarSDTJson = (string)((string)getParm(obj,1));
         sCtrlAV8CalendarEventId = (string)((string)getParm(obj,2));
         sCtrlAV15DisabledDaysJson = (string)((string)getParm(obj,3));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA4T2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\wwp_eventinfowc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4T2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV10CalendarSDTJson = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV10CalendarSDTJson", AV10CalendarSDTJson);
            AV8CalendarEventId = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV8CalendarEventId", AV8CalendarEventId);
            AV15DisabledDaysJson = (string)getParm(obj,5);
            AssignAttri(sPrefix, false, "AV15DisabledDaysJson", AV15DisabledDaysJson);
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV10CalendarSDTJson = cgiGet( sPrefix+"wcpOAV10CalendarSDTJson");
         wcpOAV8CalendarEventId = cgiGet( sPrefix+"wcpOAV8CalendarEventId");
         wcpOAV15DisabledDaysJson = cgiGet( sPrefix+"wcpOAV15DisabledDaysJson");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( StringUtil.StrCmp(AV10CalendarSDTJson, wcpOAV10CalendarSDTJson) != 0 ) || ( StringUtil.StrCmp(AV8CalendarEventId, wcpOAV8CalendarEventId) != 0 ) || ( StringUtil.StrCmp(AV15DisabledDaysJson, wcpOAV15DisabledDaysJson) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV10CalendarSDTJson = AV10CalendarSDTJson;
         wcpOAV8CalendarEventId = AV8CalendarEventId;
         wcpOAV15DisabledDaysJson = AV15DisabledDaysJson;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlGx_mode = cgiGet( sPrefix+"Gx_mode_CTRL");
         if ( StringUtil.Len( sCtrlGx_mode) > 0 )
         {
            Gx_mode = cgiGet( sCtrlGx_mode);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = cgiGet( sPrefix+"Gx_mode_PARM");
         }
         sCtrlAV10CalendarSDTJson = cgiGet( sPrefix+"AV10CalendarSDTJson_CTRL");
         if ( StringUtil.Len( sCtrlAV10CalendarSDTJson) > 0 )
         {
            AV10CalendarSDTJson = cgiGet( sCtrlAV10CalendarSDTJson);
            AssignAttri(sPrefix, false, "AV10CalendarSDTJson", AV10CalendarSDTJson);
         }
         else
         {
            AV10CalendarSDTJson = cgiGet( sPrefix+"AV10CalendarSDTJson_PARM");
         }
         sCtrlAV8CalendarEventId = cgiGet( sPrefix+"AV8CalendarEventId_CTRL");
         if ( StringUtil.Len( sCtrlAV8CalendarEventId) > 0 )
         {
            AV8CalendarEventId = cgiGet( sCtrlAV8CalendarEventId);
            AssignAttri(sPrefix, false, "AV8CalendarEventId", AV8CalendarEventId);
         }
         else
         {
            AV8CalendarEventId = cgiGet( sPrefix+"AV8CalendarEventId_PARM");
         }
         sCtrlAV15DisabledDaysJson = cgiGet( sPrefix+"AV15DisabledDaysJson_CTRL");
         if ( StringUtil.Len( sCtrlAV15DisabledDaysJson) > 0 )
         {
            AV15DisabledDaysJson = cgiGet( sCtrlAV15DisabledDaysJson);
            AssignAttri(sPrefix, false, "AV15DisabledDaysJson", AV15DisabledDaysJson);
         }
         else
         {
            AV15DisabledDaysJson = cgiGet( sPrefix+"AV15DisabledDaysJson_PARM");
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA4T2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS4T2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_PARM", StringUtil.RTrim( Gx_mode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlGx_mode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_CTRL", StringUtil.RTrim( sCtrlGx_mode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV10CalendarSDTJson_PARM", AV10CalendarSDTJson);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV10CalendarSDTJson)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV10CalendarSDTJson_CTRL", StringUtil.RTrim( sCtrlAV10CalendarSDTJson));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8CalendarEventId_PARM", AV8CalendarEventId);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8CalendarEventId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8CalendarEventId_CTRL", StringUtil.RTrim( sCtrlAV8CalendarEventId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV15DisabledDaysJson_PARM", AV15DisabledDaysJson);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV15DisabledDaysJson)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV15DisabledDaysJson_CTRL", StringUtil.RTrim( sCtrlAV15DisabledDaysJson));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE4T2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256201224082", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("workwithplus/wwp_eventinfowc.js", "?20256201224083", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavEventtype.Name = "vEVENTTYPE";
         cmbavEventtype.WebTags = "";
         cmbavEventtype.addItem("Event", context.GetMessage( "Event", ""), 0);
         cmbavEventtype.addItem("Activity", context.GetMessage( "Activity", ""), 0);
         if ( cmbavEventtype.ItemCount > 0 )
         {
         }
         chkavAllday.Name = "vALLDAY";
         chkavAllday.WebTags = "";
         chkavAllday.Caption = context.GetMessage( "All Day", "");
         AssignProp(sPrefix, false, chkavAllday_Internalname, "TitleCaption", chkavAllday.Caption, true);
         chkavAllday.CheckedValue = "false";
         chkavRecurringevent.Name = "vRECURRINGEVENT";
         chkavRecurringevent.WebTags = "";
         chkavRecurringevent.Caption = "";
         AssignProp(sPrefix, false, chkavRecurringevent_Internalname, "TitleCaption", chkavRecurringevent.Caption, true);
         chkavRecurringevent.CheckedValue = "false";
         chkavAddrsvp.Name = "vADDRSVP";
         chkavAddrsvp.WebTags = "";
         chkavAddrsvp.Caption = "";
         AssignProp(sPrefix, false, chkavAddrsvp_Internalname, "TitleCaption", chkavAddrsvp.Caption, true);
         chkavAddrsvp.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblockfromdatedisplay_Internalname = sPrefix+"TEXTBLOCKFROMDATEDISPLAY";
         edtavFromdatedisplay_Internalname = sPrefix+"vFROMDATEDISPLAY";
         lblFromdatedisplay_tags_Internalname = sPrefix+"FROMDATEDISPLAY_TAGS";
         tblTablemergedfromdatedisplay_Internalname = sPrefix+"TABLEMERGEDFROMDATEDISPLAY";
         divTablesplittedfromdatedisplay_Internalname = sPrefix+"TABLESPLITTEDFROMDATEDISPLAY";
         divFromdatedisplay_cell_Internalname = sPrefix+"FROMDATEDISPLAY_CELL";
         lblTextblocktodatedisplay_Internalname = sPrefix+"TEXTBLOCKTODATEDISPLAY";
         edtavTodatedisplay_Internalname = sPrefix+"vTODATEDISPLAY";
         lblTodatedisplay_tags_Internalname = sPrefix+"TODATEDISPLAY_TAGS";
         tblTablemergedtodatedisplay_Internalname = sPrefix+"TABLEMERGEDTODATEDISPLAY";
         divTablesplittedtodatedisplay_Internalname = sPrefix+"TABLESPLITTEDTODATEDISPLAY";
         divTodatedisplay_cell_Internalname = sPrefix+"TODATEDISPLAY_CELL";
         edtavDuration_Internalname = sPrefix+"vDURATION";
         divDuration_cell_Internalname = sPrefix+"DURATION_CELL";
         edtavTitle_Internalname = sPrefix+"vTITLE";
         divTitle_cell_Internalname = sPrefix+"TITLE_CELL";
         cmbavEventtype_Internalname = sPrefix+"vEVENTTYPE";
         divEventtype_cell_Internalname = sPrefix+"EVENTTYPE_CELL";
         lblTextblockcurrentdate_Internalname = sPrefix+"TEXTBLOCKCURRENTDATE";
         divTextblockcurrentdate_cell_Internalname = sPrefix+"TEXTBLOCKCURRENTDATE_CELL";
         edtavCurrentdate_Internalname = sPrefix+"vCURRENTDATE";
         cellCurrentdate_cell_Internalname = sPrefix+"CURRENTDATE_CELL";
         edtavFromtime_Internalname = sPrefix+"vFROMTIME";
         cellFromtime_cell_Internalname = sPrefix+"FROMTIME_CELL";
         tblTablemergedcurrentdate_Internalname = sPrefix+"TABLEMERGEDCURRENTDATE";
         divTablesplittedcurrentdate_Internalname = sPrefix+"TABLESPLITTEDCURRENTDATE";
         lblTextblockenddate_Internalname = sPrefix+"TEXTBLOCKENDDATE";
         divTextblockenddate_cell_Internalname = sPrefix+"TEXTBLOCKENDDATE_CELL";
         edtavEnddate_Internalname = sPrefix+"vENDDATE";
         cellEnddate_cell_Internalname = sPrefix+"ENDDATE_CELL";
         edtavTotime_Internalname = sPrefix+"vTOTIME";
         cellTotime_cell_Internalname = sPrefix+"TOTIME_CELL";
         tblTablemergedenddate_Internalname = sPrefix+"TABLEMERGEDENDDATE";
         divTablesplittedenddate_Internalname = sPrefix+"TABLESPLITTEDENDDATE";
         lblTextblockallday_Internalname = sPrefix+"TEXTBLOCKALLDAY";
         divTextblockallday_cell_Internalname = sPrefix+"TEXTBLOCKALLDAY_CELL";
         chkavAllday_Internalname = sPrefix+"vALLDAY";
         cellAllday_cell_Internalname = sPrefix+"ALLDAY_CELL";
         divRecurringtypestable_Internalname = sPrefix+"RECURRINGTYPESTABLE";
         tblTablemergedallday_Internalname = sPrefix+"TABLEMERGEDALLDAY";
         divTablesplittedallday_Internalname = sPrefix+"TABLESPLITTEDALLDAY";
         bttBtnenter_Internalname = sPrefix+"BTNENTER";
         bttBtnuacancel_Internalname = sPrefix+"BTNUACANCEL";
         bttBtnuaupdate_Internalname = sPrefix+"BTNUAUPDATE";
         bttBtnuadelete_Internalname = sPrefix+"BTNUADELETE";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         chkavRecurringevent_Internalname = sPrefix+"vRECURRINGEVENT";
         edtavAddressgroup_Internalname = sPrefix+"vADDRESSGROUP";
         chkavAddrsvp_Internalname = sPrefix+"vADDRSVP";
         edtavRecuringeventtype_Internalname = sPrefix+"vRECURINGEVENTTYPE";
         Dvelop_confirmpanel_uadelete_Internalname = sPrefix+"DVELOP_CONFIRMPANEL_UADELETE";
         tblTabledvelop_confirmpanel_uadelete_Internalname = sPrefix+"TABLEDVELOP_CONFIRMPANEL_UADELETE";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         chkavAddrsvp.Caption = "";
         chkavRecurringevent.Caption = "";
         chkavAllday.Caption = context.GetMessage( "All Day", "");
         edtavFromdatedisplay_Enabled = 1;
         edtavTodatedisplay_Enabled = 1;
         edtavFromtime_Jsonclick = "";
         cellFromtime_cell_Class = "";
         edtavCurrentdate_Jsonclick = "";
         cellCurrentdate_cell_Class = "";
         edtavTotime_Jsonclick = "";
         cellTotime_cell_Class = "";
         edtavEnddate_Jsonclick = "";
         cellEnddate_cell_Class = "";
         divRecurringtypestable_Visible = 1;
         chkavAllday.Enabled = 1;
         cellAllday_cell_Class = "";
         lblTodatedisplay_tags_Caption = "";
         lblFromdatedisplay_tags_Caption = "";
         edtavTotime_Visible = 1;
         edtavEnddate_Visible = 1;
         edtavFromtime_Visible = 1;
         edtavCurrentdate_Visible = 1;
         edtavTodatedisplay_Visible = 1;
         edtavFromdatedisplay_Visible = 1;
         chkavAllday.Visible = 1;
         edtavTotime_Enabled = 1;
         edtavFromtime_Enabled = 1;
         edtavEnddate_Enabled = 1;
         edtavCurrentdate_Enabled = 1;
         edtavRecuringeventtype_Visible = 1;
         chkavAddrsvp.Visible = 1;
         edtavAddressgroup_Jsonclick = "";
         edtavAddressgroup_Visible = 1;
         chkavRecurringevent.Visible = 1;
         bttBtnuadelete_Visible = 1;
         bttBtnuaupdate_Visible = 1;
         bttBtnuacancel_Visible = 1;
         bttBtnenter_Enabled = 1;
         bttBtnenter_Visible = 1;
         divTextblockallday_cell_Class = "col-xs-12 col-sm-3";
         divTextblockenddate_cell_Class = "col-xs-12 col-sm-3";
         divTextblockcurrentdate_cell_Class = "col-xs-12 col-sm-3";
         cmbavEventtype_Jsonclick = "";
         cmbavEventtype.Enabled = 1;
         cmbavEventtype.Visible = 1;
         divEventtype_cell_Class = "col-xs-12";
         edtavTitle_Jsonclick = "";
         edtavTitle_Enabled = 1;
         edtavTitle_Visible = 1;
         divTitle_cell_Class = "col-xs-12";
         edtavDuration_Enabled = 1;
         edtavDuration_Visible = 1;
         divDuration_cell_Class = "col-xs-12";
         divTodatedisplay_cell_Class = "col-xs-12";
         lblTextblockfromdatedisplay_Caption = context.GetMessage( "WWP_Calendar_From", "");
         divFromdatedisplay_cell_Class = "col-xs-12";
         Dvelop_confirmpanel_uadelete_Confirmtype = "1";
         Dvelop_confirmpanel_uadelete_Yesbuttonposition = "left";
         Dvelop_confirmpanel_uadelete_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_uadelete_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_uadelete_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_uadelete_Confirmationtext = "Are you sure you want to delete event?";
         Dvelop_confirmpanel_uadelete_Title = context.GetMessage( "Delete event", "");
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"AV12CurrentDate","fld":"vCURRENTDATE"},{"av":"AV16EndDate","fld":"vENDDATE"},{"av":"AV7AllDay","fld":"vALLDAY"},{"av":"AV42RecurringEvent","fld":"vRECURRINGEVENT"},{"av":"AV41AddRSVP","fld":"vADDRSVP"},{"av":"AV31DurationHours","fld":"vDURATIONHOURS","pic":"ZZZ9","hsh":true},{"av":"AV14DisabledDays","fld":"vDISABLEDDAYS","hsh":true},{"av":"AV6ErrorMessages","fld":"vERRORMESSAGES","hsh":true},{"av":"AV51ResidentAddressGroup","fld":"vRESIDENTADDRESSGROUP","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"edtavCurrentdate_Enabled","ctrl":"vCURRENTDATE","prop":"Enabled"},{"av":"edtavEnddate_Enabled","ctrl":"vENDDATE","prop":"Enabled"},{"av":"edtavFromtime_Enabled","ctrl":"vFROMTIME","prop":"Enabled"},{"av":"edtavTotime_Enabled","ctrl":"vTOTIME","prop":"Enabled"},{"av":"edtavTitle_Enabled","ctrl":"vTITLE","prop":"Enabled"},{"av":"chkavAllday.Visible","ctrl":"vALLDAY","prop":"Visible"},{"av":"edtavFromdatedisplay_Visible","ctrl":"vFROMDATEDISPLAY","prop":"Visible"},{"av":"divFromdatedisplay_cell_Class","ctrl":"FROMDATEDISPLAY_CELL","prop":"Class"},{"av":"edtavTodatedisplay_Visible","ctrl":"vTODATEDISPLAY","prop":"Visible"},{"av":"divTodatedisplay_cell_Class","ctrl":"TODATEDISPLAY_CELL","prop":"Class"},{"av":"edtavDuration_Visible","ctrl":"vDURATION","prop":"Visible"},{"av":"divDuration_cell_Class","ctrl":"DURATION_CELL","prop":"Class"},{"av":"edtavTitle_Visible","ctrl":"vTITLE","prop":"Visible"},{"av":"divTitle_cell_Class","ctrl":"TITLE_CELL","prop":"Class"},{"av":"cmbavEventtype"},{"av":"divEventtype_cell_Class","ctrl":"EVENTTYPE_CELL","prop":"Class"},{"av":"edtavCurrentdate_Visible","ctrl":"vCURRENTDATE","prop":"Visible"},{"av":"cellCurrentdate_cell_Class","ctrl":"CURRENTDATE_CELL","prop":"Class"},{"av":"divTextblockcurrentdate_cell_Class","ctrl":"TEXTBLOCKCURRENTDATE_CELL","prop":"Class"},{"av":"edtavFromtime_Visible","ctrl":"vFROMTIME","prop":"Visible"},{"av":"cellFromtime_cell_Class","ctrl":"FROMTIME_CELL","prop":"Class"},{"av":"edtavEnddate_Visible","ctrl":"vENDDATE","prop":"Visible"},{"av":"cellEnddate_cell_Class","ctrl":"ENDDATE_CELL","prop":"Class"},{"av":"divTextblockenddate_cell_Class","ctrl":"TEXTBLOCKENDDATE_CELL","prop":"Class"},{"av":"edtavTotime_Visible","ctrl":"vTOTIME","prop":"Visible"},{"av":"cellTotime_cell_Class","ctrl":"TOTIME_CELL","prop":"Class"},{"av":"cellAllday_cell_Class","ctrl":"ALLDAY_CELL","prop":"Class"},{"av":"divTextblockallday_cell_Class","ctrl":"TEXTBLOCKALLDAY_CELL","prop":"Class"},{"av":"divRecurringtypestable_Visible","ctrl":"RECURRINGTYPESTABLE","prop":"Visible"},{"av":"lblFromdatedisplay_tags_Caption","ctrl":"FROMDATEDISPLAY_TAGS","prop":"Caption"},{"av":"lblTodatedisplay_tags_Caption","ctrl":"TODATEDISPLAY_TAGS","prop":"Caption"},{"ctrl":"BTNENTER","prop":"Visible"},{"ctrl":"BTNUACANCEL","prop":"Visible"},{"ctrl":"BTNUAUPDATE","prop":"Visible"},{"ctrl":"BTNUADELETE","prop":"Visible"}]}""");
         setEventMetadata("'DOUACANCEL'","""{"handler":"E114T1","iparms":[]}""");
         setEventMetadata("'DOUAUPDATE'","""{"handler":"E164T2","iparms":[]""");
         setEventMetadata("'DOUAUPDATE'",""","oparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]}""");
         setEventMetadata("'DOUADELETE'","""{"handler":"E124T1","iparms":[]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_UADELETE.CLOSE","""{"handler":"E134T2","iparms":[{"av":"Dvelop_confirmpanel_uadelete_Result","ctrl":"DVELOP_CONFIRMPANEL_UADELETE","prop":"Result"},{"av":"AV8CalendarEventId","fld":"vCALENDAREVENTID"}]}""");
         setEventMetadata("VENDDATE.CONTROLVALUECHANGED","""{"handler":"E174T2","iparms":[{"av":"AV12CurrentDate","fld":"vCURRENTDATE"},{"av":"AV16EndDate","fld":"vENDDATE"},{"av":"AV27FixStartDate","fld":"vFIXSTARTDATE"},{"av":"AV17FromTime","fld":"vFROMTIME","pic":"99:99"},{"av":"AV19ToTime","fld":"vTOTIME","pic":"99:99"},{"av":"AV28FixStartTime","fld":"vFIXSTARTTIME"},{"av":"AV14DisabledDays","fld":"vDISABLEDDAYS","hsh":true}]""");
         setEventMetadata("VENDDATE.CONTROLVALUECHANGED",""","oparms":[{"av":"AV27FixStartDate","fld":"vFIXSTARTDATE"},{"av":"AV12CurrentDate","fld":"vCURRENTDATE"},{"av":"AV16EndDate","fld":"vENDDATE"},{"av":"AV17FromTime","fld":"vFROMTIME","pic":"99:99"},{"av":"AV19ToTime","fld":"vTOTIME","pic":"99:99"},{"ctrl":"BTNENTER","prop":"Enabled"}]}""");
         setEventMetadata("VCURRENTDATE.CONTROLVALUECHANGED","""{"handler":"E184T2","iparms":[{"av":"AV12CurrentDate","fld":"vCURRENTDATE"},{"av":"AV16EndDate","fld":"vENDDATE"},{"av":"AV27FixStartDate","fld":"vFIXSTARTDATE"},{"av":"AV17FromTime","fld":"vFROMTIME","pic":"99:99"},{"av":"AV19ToTime","fld":"vTOTIME","pic":"99:99"},{"av":"AV28FixStartTime","fld":"vFIXSTARTTIME"},{"av":"AV14DisabledDays","fld":"vDISABLEDDAYS","hsh":true}]""");
         setEventMetadata("VCURRENTDATE.CONTROLVALUECHANGED",""","oparms":[{"av":"AV27FixStartDate","fld":"vFIXSTARTDATE"},{"av":"AV12CurrentDate","fld":"vCURRENTDATE"},{"av":"AV16EndDate","fld":"vENDDATE"},{"av":"AV17FromTime","fld":"vFROMTIME","pic":"99:99"},{"av":"AV19ToTime","fld":"vTOTIME","pic":"99:99"},{"ctrl":"BTNENTER","prop":"Enabled"}]}""");
         setEventMetadata("ENTER","""{"handler":"E194T2","iparms":[{"av":"AV11CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV6ErrorMessages","fld":"vERRORMESSAGES","hsh":true},{"av":"AV51ResidentAddressGroup","fld":"vRESIDENTADDRESSGROUP","hsh":true},{"av":"AV41AddRSVP","fld":"vADDRSVP"},{"av":"AV43RecuringEventType","fld":"vRECURINGEVENTTYPE"},{"av":"AV42RecurringEvent","fld":"vRECURRINGEVENT"},{"av":"cmbavEventtype"},{"av":"AV40EventType","fld":"vEVENTTYPE"},{"av":"AV8CalendarEventId","fld":"vCALENDAREVENTID"},{"av":"AV16EndDate","fld":"vENDDATE"},{"av":"AV7AllDay","fld":"vALLDAY"},{"av":"AV19ToTime","fld":"vTOTIME","pic":"99:99"},{"av":"AV17FromTime","fld":"vFROMTIME","pic":"99:99"},{"av":"AV12CurrentDate","fld":"vCURRENTDATE"},{"av":"AV18Title","fld":"vTITLE"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"AV27FixStartDate","fld":"vFIXSTARTDATE"},{"av":"AV28FixStartTime","fld":"vFIXSTARTTIME"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV11CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV12CurrentDate","fld":"vCURRENTDATE"},{"av":"AV16EndDate","fld":"vENDDATE"},{"av":"AV17FromTime","fld":"vFROMTIME","pic":"99:99"},{"av":"AV19ToTime","fld":"vTOTIME","pic":"99:99"},{"av":"AV42RecurringEvent","fld":"vRECURRINGEVENT"}]}""");
         setEventMetadata("VALLDAY.CLICK","""{"handler":"E214T2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"AV12CurrentDate","fld":"vCURRENTDATE"},{"av":"AV16EndDate","fld":"vENDDATE"},{"av":"AV7AllDay","fld":"vALLDAY"},{"av":"AV31DurationHours","fld":"vDURATIONHOURS","pic":"ZZZ9","hsh":true},{"av":"AV42RecurringEvent","fld":"vRECURRINGEVENT"}]""");
         setEventMetadata("VALLDAY.CLICK",""","oparms":[{"av":"edtavFromdatedisplay_Visible","ctrl":"vFROMDATEDISPLAY","prop":"Visible"},{"av":"divFromdatedisplay_cell_Class","ctrl":"FROMDATEDISPLAY_CELL","prop":"Class"},{"av":"edtavTodatedisplay_Visible","ctrl":"vTODATEDISPLAY","prop":"Visible"},{"av":"divTodatedisplay_cell_Class","ctrl":"TODATEDISPLAY_CELL","prop":"Class"},{"av":"edtavDuration_Visible","ctrl":"vDURATION","prop":"Visible"},{"av":"divDuration_cell_Class","ctrl":"DURATION_CELL","prop":"Class"},{"av":"edtavTitle_Visible","ctrl":"vTITLE","prop":"Visible"},{"av":"divTitle_cell_Class","ctrl":"TITLE_CELL","prop":"Class"},{"av":"cmbavEventtype"},{"av":"divEventtype_cell_Class","ctrl":"EVENTTYPE_CELL","prop":"Class"},{"av":"edtavCurrentdate_Visible","ctrl":"vCURRENTDATE","prop":"Visible"},{"av":"cellCurrentdate_cell_Class","ctrl":"CURRENTDATE_CELL","prop":"Class"},{"av":"divTextblockcurrentdate_cell_Class","ctrl":"TEXTBLOCKCURRENTDATE_CELL","prop":"Class"},{"av":"edtavFromtime_Visible","ctrl":"vFROMTIME","prop":"Visible"},{"av":"cellFromtime_cell_Class","ctrl":"FROMTIME_CELL","prop":"Class"},{"av":"edtavEnddate_Visible","ctrl":"vENDDATE","prop":"Visible"},{"av":"cellEnddate_cell_Class","ctrl":"ENDDATE_CELL","prop":"Class"},{"av":"divTextblockenddate_cell_Class","ctrl":"TEXTBLOCKENDDATE_CELL","prop":"Class"},{"av":"edtavTotime_Visible","ctrl":"vTOTIME","prop":"Visible"},{"av":"cellTotime_cell_Class","ctrl":"TOTIME_CELL","prop":"Class"},{"av":"chkavAllday.Visible","ctrl":"vALLDAY","prop":"Visible"},{"av":"cellAllday_cell_Class","ctrl":"ALLDAY_CELL","prop":"Class"},{"av":"divTextblockallday_cell_Class","ctrl":"TEXTBLOCKALLDAY_CELL","prop":"Class"},{"av":"divRecurringtypestable_Visible","ctrl":"RECURRINGTYPESTABLE","prop":"Visible"},{"av":"lblFromdatedisplay_tags_Caption","ctrl":"FROMDATEDISPLAY_TAGS","prop":"Caption"},{"av":"lblTodatedisplay_tags_Caption","ctrl":"TODATEDISPLAY_TAGS","prop":"Caption"}]}""");
         setEventMetadata("VALIDV_EVENTTYPE","""{"handler":"Validv_Eventtype","iparms":[]}""");
         setEventMetadata("VALIDV_ADDRESSGROUP","""{"handler":"Validv_Addressgroup","iparms":[]}""");
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
         wcpOGx_mode = "";
         wcpOAV10CalendarSDTJson = "";
         wcpOAV8CalendarEventId = "";
         wcpOAV15DisabledDaysJson = "";
         Dvelop_confirmpanel_uadelete_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV14DisabledDays = new GxSimpleCollection<DateTime>();
         AV6ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV51ResidentAddressGroup = new GxSimpleCollection<Guid>();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         lblTextblockfromdatedisplay_Jsonclick = "";
         lblTextblocktodatedisplay_Jsonclick = "";
         TempTags = "";
         AV29Duration = "";
         AV18Title = "";
         AV40EventType = "";
         lblTextblockcurrentdate_Jsonclick = "";
         lblTextblockenddate_Jsonclick = "";
         lblTextblockallday_Jsonclick = "";
         bttBtnenter_Jsonclick = "";
         bttBtnuacancel_Jsonclick = "";
         bttBtnuaupdate_Jsonclick = "";
         bttBtnuadelete_Jsonclick = "";
         AV44AddressGroup = Guid.Empty;
         AV43RecuringEventType = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV23FromDateDisplay = "";
         AV24ToDateDisplay = "";
         AV12CurrentDate = DateTime.MinValue;
         AV17FromTime = (DateTime)(DateTime.MinValue);
         AV16EndDate = DateTime.MinValue;
         AV19ToTime = (DateTime)(DateTime.MinValue);
         AV9CalendarSDT = new WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item(context);
         GXt_SdtWWP_Calendar_Events_Item1 = new WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item(context);
         AV50ResidentsOnEvent = new GxSimpleCollection<Guid>();
         H004T2_A268AgendaCalendarId = new Guid[] {Guid.Empty} ;
         H004T2_A62ResidentId = new Guid[] {Guid.Empty} ;
         A268AgendaCalendarId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         AV25CurrentTime = (DateTime)(DateTime.MinValue);
         AV5Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV13DisabledDay = DateTime.MinValue;
         sStyleString = "";
         ucDvelop_confirmpanel_uadelete = new GXUserControl();
         lblTodatedisplay_tags_Jsonclick = "";
         lblFromdatedisplay_tags_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlGx_mode = "";
         sCtrlAV10CalendarSDTJson = "";
         sCtrlAV8CalendarEventId = "";
         sCtrlAV15DisabledDaysJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_eventinfowc__default(),
            new Object[][] {
                new Object[] {
               H004T2_A268AgendaCalendarId, H004T2_A62ResidentId
               }
            }
         );
         /* GeneXus formulas. */
         edtavFromdatedisplay_Enabled = 0;
         edtavTodatedisplay_Enabled = 0;
         edtavDuration_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV31DurationHours ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short AV32DurationMinutes ;
      private short AV33Minutes ;
      private short nGXWrapped ;
      private int edtavFromdatedisplay_Enabled ;
      private int edtavTodatedisplay_Enabled ;
      private int edtavDuration_Enabled ;
      private int edtavDuration_Visible ;
      private int edtavTitle_Visible ;
      private int edtavTitle_Enabled ;
      private int bttBtnenter_Visible ;
      private int bttBtnenter_Enabled ;
      private int bttBtnuacancel_Visible ;
      private int bttBtnuaupdate_Visible ;
      private int bttBtnuadelete_Visible ;
      private int edtavAddressgroup_Visible ;
      private int edtavRecuringeventtype_Visible ;
      private int edtavCurrentdate_Enabled ;
      private int edtavEnddate_Enabled ;
      private int edtavFromtime_Enabled ;
      private int edtavTotime_Enabled ;
      private int edtavFromdatedisplay_Visible ;
      private int edtavTodatedisplay_Visible ;
      private int edtavCurrentdate_Visible ;
      private int edtavFromtime_Visible ;
      private int edtavEnddate_Visible ;
      private int edtavTotime_Visible ;
      private int divRecurringtypestable_Visible ;
      private int AV54GXV1 ;
      private int AV55GXV2 ;
      private int idxLst ;
      private string Gx_mode ;
      private string wcpOGx_mode ;
      private string Dvelop_confirmpanel_uadelete_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavFromdatedisplay_Internalname ;
      private string edtavTodatedisplay_Internalname ;
      private string edtavDuration_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Dvelop_confirmpanel_uadelete_Title ;
      private string Dvelop_confirmpanel_uadelete_Confirmationtext ;
      private string Dvelop_confirmpanel_uadelete_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_uadelete_Nobuttoncaption ;
      private string Dvelop_confirmpanel_uadelete_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_uadelete_Yesbuttonposition ;
      private string Dvelop_confirmpanel_uadelete_Confirmtype ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divFromdatedisplay_cell_Internalname ;
      private string divFromdatedisplay_cell_Class ;
      private string divTablesplittedfromdatedisplay_Internalname ;
      private string lblTextblockfromdatedisplay_Internalname ;
      private string lblTextblockfromdatedisplay_Caption ;
      private string lblTextblockfromdatedisplay_Jsonclick ;
      private string divTodatedisplay_cell_Internalname ;
      private string divTodatedisplay_cell_Class ;
      private string divTablesplittedtodatedisplay_Internalname ;
      private string lblTextblocktodatedisplay_Internalname ;
      private string lblTextblocktodatedisplay_Jsonclick ;
      private string divDuration_cell_Internalname ;
      private string divDuration_cell_Class ;
      private string TempTags ;
      private string divTitle_cell_Internalname ;
      private string divTitle_cell_Class ;
      private string edtavTitle_Internalname ;
      private string edtavTitle_Jsonclick ;
      private string divEventtype_cell_Internalname ;
      private string divEventtype_cell_Class ;
      private string cmbavEventtype_Internalname ;
      private string cmbavEventtype_Jsonclick ;
      private string divTablesplittedcurrentdate_Internalname ;
      private string divTextblockcurrentdate_cell_Internalname ;
      private string divTextblockcurrentdate_cell_Class ;
      private string lblTextblockcurrentdate_Internalname ;
      private string lblTextblockcurrentdate_Jsonclick ;
      private string divTablesplittedenddate_Internalname ;
      private string divTextblockenddate_cell_Internalname ;
      private string divTextblockenddate_cell_Class ;
      private string lblTextblockenddate_Internalname ;
      private string lblTextblockenddate_Jsonclick ;
      private string divTablesplittedallday_Internalname ;
      private string divTextblockallday_cell_Internalname ;
      private string divTextblockallday_cell_Class ;
      private string lblTextblockallday_Internalname ;
      private string lblTextblockallday_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtnuacancel_Internalname ;
      private string bttBtnuacancel_Jsonclick ;
      private string bttBtnuaupdate_Internalname ;
      private string bttBtnuaupdate_Jsonclick ;
      private string bttBtnuadelete_Internalname ;
      private string bttBtnuadelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string chkavRecurringevent_Internalname ;
      private string edtavAddressgroup_Internalname ;
      private string edtavAddressgroup_Jsonclick ;
      private string chkavAddrsvp_Internalname ;
      private string edtavRecuringeventtype_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string edtavCurrentdate_Internalname ;
      private string edtavFromtime_Internalname ;
      private string edtavEnddate_Internalname ;
      private string edtavTotime_Internalname ;
      private string chkavAllday_Internalname ;
      private string cellCurrentdate_cell_Class ;
      private string cellCurrentdate_cell_Internalname ;
      private string cellFromtime_cell_Class ;
      private string cellFromtime_cell_Internalname ;
      private string cellEnddate_cell_Class ;
      private string cellEnddate_cell_Internalname ;
      private string cellTotime_cell_Class ;
      private string cellTotime_cell_Internalname ;
      private string cellAllday_cell_Class ;
      private string cellAllday_cell_Internalname ;
      private string divRecurringtypestable_Internalname ;
      private string lblFromdatedisplay_tags_Caption ;
      private string lblFromdatedisplay_tags_Internalname ;
      private string lblTodatedisplay_tags_Caption ;
      private string lblTodatedisplay_tags_Internalname ;
      private string sStyleString ;
      private string tblTabledvelop_confirmpanel_uadelete_Internalname ;
      private string Dvelop_confirmpanel_uadelete_Internalname ;
      private string tblTablemergedallday_Internalname ;
      private string tblTablemergedenddate_Internalname ;
      private string edtavEnddate_Jsonclick ;
      private string edtavTotime_Jsonclick ;
      private string tblTablemergedcurrentdate_Internalname ;
      private string edtavCurrentdate_Jsonclick ;
      private string edtavFromtime_Jsonclick ;
      private string tblTablemergedtodatedisplay_Internalname ;
      private string lblTodatedisplay_tags_Jsonclick ;
      private string tblTablemergedfromdatedisplay_Internalname ;
      private string lblFromdatedisplay_tags_Jsonclick ;
      private string sCtrlGx_mode ;
      private string sCtrlAV10CalendarSDTJson ;
      private string sCtrlAV8CalendarEventId ;
      private string sCtrlAV15DisabledDaysJson ;
      private DateTime AV17FromTime ;
      private DateTime AV19ToTime ;
      private DateTime AV25CurrentTime ;
      private DateTime AV12CurrentDate ;
      private DateTime AV16EndDate ;
      private DateTime AV13DisabledDay ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV27FixStartDate ;
      private bool AV28FixStartTime ;
      private bool AV11CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool AV42RecurringEvent ;
      private bool AV41AddRSVP ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV7AllDay ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV26IncludedInADisableDay ;
      private string AV10CalendarSDTJson ;
      private string AV15DisabledDaysJson ;
      private string wcpOAV10CalendarSDTJson ;
      private string wcpOAV15DisabledDaysJson ;
      private string AV8CalendarEventId ;
      private string wcpOAV8CalendarEventId ;
      private string AV29Duration ;
      private string AV18Title ;
      private string AV40EventType ;
      private string AV43RecuringEventType ;
      private string AV23FromDateDisplay ;
      private string AV24ToDateDisplay ;
      private Guid AV44AddressGroup ;
      private Guid A268AgendaCalendarId ;
      private Guid A62ResidentId ;
      private GXUserControl ucDvelop_confirmpanel_uadelete ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private string aP2_CalendarEventId ;
      private string aP3_DisabledDaysJson ;
      private GXCombobox cmbavEventtype ;
      private GXCheckbox chkavAllday ;
      private GXCheckbox chkavRecurringevent ;
      private GXCheckbox chkavAddrsvp ;
      private GxSimpleCollection<DateTime> AV14DisabledDays ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV6ErrorMessages ;
      private GxSimpleCollection<Guid> AV51ResidentAddressGroup ;
      private WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item AV9CalendarSDT ;
      private WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item GXt_SdtWWP_Calendar_Events_Item1 ;
      private GxSimpleCollection<Guid> AV50ResidentsOnEvent ;
      private IDataStoreProvider pr_default ;
      private Guid[] H004T2_A268AgendaCalendarId ;
      private Guid[] H004T2_A62ResidentId ;
      private GeneXus.Utils.SdtMessages_Message AV5Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_eventinfowc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH004T2;
          prmH004T2 = new Object[] {
          new ParDef("AV8CalendarEventId",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004T2", "SELECT AgendaCalendarId, ResidentId FROM Trn_AgendaEventGroup WHERE AgendaCalendarId = CASE WHEN (:AV8CalendarEventId ~ ('[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}')) THEN RTRIM(:AV8CalendarEventId) ELSE '00000000-0000-0000-0000-000000000000' END ORDER BY AgendaCalendarId, ResidentId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004T2,100, GxCacheFrequency.OFF ,false,false )
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
