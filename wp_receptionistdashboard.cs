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
   public class wp_receptionistdashboard : GXDataArea
   {
      public wp_receptionistdashboard( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_receptionistdashboard( IGxContext context )
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
         chkavUsdtnotificationsdata__notificationisread = new GXCheckbox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridusdtnotificationsdatas") == 0 )
            {
               gxnrGridusdtnotificationsdatas_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridusdtnotificationsdatas") == 0 )
            {
               gxgrGridusdtnotificationsdatas_refresh_invoke( ) ;
               return  ;
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

      protected void gxnrGridusdtnotificationsdatas_newrow_invoke( )
      {
         nRC_GXsfl_139 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_139"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_139_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_139_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_139_idx = GetPar( "sGXsfl_139_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridusdtnotificationsdatas_newrow( ) ;
         /* End function gxnrGridusdtnotificationsdatas_newrow_invoke */
      }

      protected void gxgrGridusdtnotificationsdatas_refresh_invoke( )
      {
         subGridusdtnotificationsdatas_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridusdtnotificationsdatas_Rows"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV68WWPContext);
         AV29ForceLoadDots = StringUtil.StrToBool( GetPar( "ForceLoadDots"));
         AV27EventsLoaded = StringUtil.StrToBool( GetPar( "EventsLoaded"));
         AV5CalendarLoadFromDate = context.localUtil.ParseDateParm( GetPar( "CalendarLoadFromDate"));
         AV6CalendarLoadToDate = context.localUtil.ParseDateParm( GetPar( "CalendarLoadToDate"));
         AV19Date_ShowingDatesFrom = context.localUtil.ParseDateParm( GetPar( "Date_ShowingDatesFrom"));
         AV10LoadedDotsFromDate = context.localUtil.ParseDateParm( GetPar( "LoadedDotsFromDate"));
         AV11LoadedDotsToDate = context.localUtil.ParseDateParm( GetPar( "LoadedDotsToDate"));
         AV12LoadedFromDate = context.localUtil.ParseDateParm( GetPar( "LoadedFromDate"));
         AV13LoadedToDate = context.localUtil.ParseDateParm( GetPar( "LoadedToDate"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV25Events);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV70USDTNotificationsData);
         AV18Date = context.localUtil.ParseDateParm( GetPar( "Date"));
         AV15CalendarEventId = GetPar( "CalendarEventId");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridusdtnotificationsdatas_refresh( subGridusdtnotificationsdatas_Rows, AV68WWPContext, AV29ForceLoadDots, AV27EventsLoaded, AV5CalendarLoadFromDate, AV6CalendarLoadToDate, AV19Date_ShowingDatesFrom, AV10LoadedDotsFromDate, AV11LoadedDotsToDate, AV12LoadedFromDate, AV13LoadedToDate, AV25Events, AV70USDTNotificationsData, AV18Date, AV15CalendarEventId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridusdtnotificationsdatas_refresh_invoke */
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
            return "wp_receptionistdashboard_Execute" ;
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
         PABI2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTBI2( ) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Calendar/index.global.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Calendar/WWPCalendarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_receptionistdashboard.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vDATE", context.localUtil.DToC( AV18Date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vDATE", GetSecureSignedToken( "", AV18Date, context));
         GxWebStd.gx_hidden_field( context, "vCALENDAREVENTID", AV15CalendarEventId);
         GxWebStd.gx_hidden_field( context, "gxhash_vCALENDAREVENTID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV15CalendarEventId, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV68WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV68WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV68WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vDATE_SHOWINGDATESFROM", context.localUtil.DToC( AV19Date_ShowingDatesFrom, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vDATE_SHOWINGDATESFROM", GetSecureSignedToken( "", AV19Date_ShowingDatesFrom, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Usdtnotificationsdata", AV70USDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Usdtnotificationsdata", AV70USDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_139", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_139), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vEVENTS", AV25Events);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vEVENTS", AV25Events);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDISABLEDDAYS", AV20DisabledDays);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDISABLEDDAYS", AV20DisabledDays);
         }
         GxWebStd.gx_hidden_field( context, "vCALENDARLOADFROMDATE", context.localUtil.DToC( AV5CalendarLoadFromDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vCALENDARLOADTODATE", context.localUtil.DToC( AV6CalendarLoadToDate, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSDTNOTIFICATIONSDATA", AV70USDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSDTNOTIFICATIONSDATA", AV70USDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, "vDATE", context.localUtil.DToC( AV18Date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vDATE", GetSecureSignedToken( "", AV18Date, context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vCALENDAREVENTSJSON", AV17CalendarEventsJson);
         GxWebStd.gx_hidden_field( context, "vCALENDAREVENTID", AV15CalendarEventId);
         GxWebStd.gx_hidden_field( context, "gxhash_vCALENDAREVENTID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV15CalendarEventId, "")), context));
         GxWebStd.gx_hidden_field( context, "vDISABLEDDAYSJSON", AV21DisabledDaysJson);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV68WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV68WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV68WWPContext, context));
         GxWebStd.gx_boolean_hidden_field( context, "vFORCELOADDOTS", AV29ForceLoadDots);
         GxWebStd.gx_boolean_hidden_field( context, "vEVENTSLOADED", AV27EventsLoaded);
         GxWebStd.gx_hidden_field( context, "vDATE_SHOWINGDATESFROM", context.localUtil.DToC( AV19Date_ShowingDatesFrom, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vDATE_SHOWINGDATESFROM", GetSecureSignedToken( "", AV19Date_ShowingDatesFrom, context));
         GxWebStd.gx_hidden_field( context, "vLOADEDDOTSFROMDATE", context.localUtil.DToC( AV10LoadedDotsFromDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vLOADEDDOTSTODATE", context.localUtil.DToC( AV11LoadedDotsToDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vLOADEDFROMDATE", context.localUtil.DToC( AV12LoadedFromDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vLOADEDTODATE", context.localUtil.DToC( AV13LoadedToDate, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNOTIFICATIONINFO", AV74NotificationInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNOTIFICATIONINFO", AV74NotificationInfo);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNOTIFICATIONDEFINITIONIDEMPTYCOLLECTION", AV54NotificationDefinitionIdEmptyCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNOTIFICATIONDEFINITIONIDEMPTYCOLLECTION", AV54NotificationDefinitionIdEmptyCollection);
         }
         GxWebStd.gx_hidden_field( context, "GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDUSDTNOTIFICATIONSDATAS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSDTNOTIFICATIONSDATAS_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRIDUSDTNOTIFICATIONSDATAS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusdtnotificationsdatas_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Width", StringUtil.RTrim( Dvpanel_tablecards_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Autowidth", StringUtil.BoolToStr( Dvpanel_tablecards_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Autoheight", StringUtil.BoolToStr( Dvpanel_tablecards_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Cls", StringUtil.RTrim( Dvpanel_tablecards_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Title", StringUtil.RTrim( Dvpanel_tablecards_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Collapsible", StringUtil.BoolToStr( Dvpanel_tablecards_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Collapsed", StringUtil.BoolToStr( Dvpanel_tablecards_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablecards_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Iconposition", StringUtil.RTrim( Dvpanel_tablecards_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablecards_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Width", StringUtil.RTrim( Dvpanel_tablenotifications_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Autowidth", StringUtil.BoolToStr( Dvpanel_tablenotifications_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Autoheight", StringUtil.BoolToStr( Dvpanel_tablenotifications_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Cls", StringUtil.RTrim( Dvpanel_tablenotifications_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Title", StringUtil.RTrim( Dvpanel_tablenotifications_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Collapsible", StringUtil.BoolToStr( Dvpanel_tablenotifications_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Collapsed", StringUtil.BoolToStr( Dvpanel_tablenotifications_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablenotifications_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Iconposition", StringUtil.RTrim( Dvpanel_tablenotifications_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablenotifications_Autoscroll));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Selectable", StringUtil.BoolToStr( Usercontrol1_Selectable));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Initialview", StringUtil.RTrim( Usercontrol1_Initialview));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Viewstyle", StringUtil.RTrim( Usercontrol1_Viewstyle));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Navlinks", StringUtil.BoolToStr( Usercontrol1_Navlinks));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Todaybuttonposition", StringUtil.RTrim( Usercontrol1_Todaybuttonposition));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Previousbuttonposition", StringUtil.RTrim( Usercontrol1_Previousbuttonposition));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Nextbuttonposition", StringUtil.RTrim( Usercontrol1_Nextbuttonposition));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Monthbuttonposition", StringUtil.RTrim( Usercontrol1_Monthbuttonposition));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Weekbuttonposition", StringUtil.RTrim( Usercontrol1_Weekbuttonposition));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Daybuttonposition", StringUtil.RTrim( Usercontrol1_Daybuttonposition));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Todaybuttontext", StringUtil.RTrim( Usercontrol1_Todaybuttontext));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Daybuttontext", StringUtil.RTrim( Usercontrol1_Daybuttontext));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEAGENDA_Width", StringUtil.RTrim( Dvpanel_tableagenda_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEAGENDA_Autowidth", StringUtil.BoolToStr( Dvpanel_tableagenda_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEAGENDA_Autoheight", StringUtil.BoolToStr( Dvpanel_tableagenda_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEAGENDA_Cls", StringUtil.RTrim( Dvpanel_tableagenda_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEAGENDA_Title", StringUtil.RTrim( Dvpanel_tableagenda_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEAGENDA_Collapsible", StringUtil.BoolToStr( Dvpanel_tableagenda_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEAGENDA_Collapsed", StringUtil.BoolToStr( Dvpanel_tableagenda_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEAGENDA_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableagenda_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEAGENDA_Iconposition", StringUtil.RTrim( Dvpanel_tableagenda_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEAGENDA_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableagenda_Autoscroll));
         GxWebStd.gx_hidden_field( context, "CREATEEVENT_MODAL_Width", StringUtil.RTrim( Createevent_modal_Width));
         GxWebStd.gx_hidden_field( context, "CREATEEVENT_MODAL_Title", StringUtil.RTrim( Createevent_modal_Title));
         GxWebStd.gx_hidden_field( context, "CREATEEVENT_MODAL_Confirmtype", StringUtil.RTrim( Createevent_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "CREATEEVENT_MODAL_Bodytype", StringUtil.RTrim( Createevent_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "SENDMESSAGE_MODAL_Width", StringUtil.RTrim( Sendmessage_modal_Width));
         GxWebStd.gx_hidden_field( context, "SENDMESSAGE_MODAL_Title", StringUtil.RTrim( Sendmessage_modal_Title));
         GxWebStd.gx_hidden_field( context, "SENDMESSAGE_MODAL_Confirmtype", StringUtil.RTrim( Sendmessage_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "SENDMESSAGE_MODAL_Bodytype", StringUtil.RTrim( Sendmessage_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "GRIDUSDTNOTIFICATIONSDATAS_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridusdtnotificationsdatas_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Defaulteventstyle", StringUtil.RTrim( Usercontrol1_Defaulteventstyle));
         GxWebStd.gx_hidden_field( context, "NOTIFICATIONSSUBTITLE_Caption", StringUtil.RTrim( lblNotificationssubtitle_Caption));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Defaulteventstyle", StringUtil.RTrim( Usercontrol1_Defaulteventstyle));
         GxWebStd.gx_hidden_field( context, "USERCONTROL1_Defaulteventstyle", StringUtil.RTrim( Usercontrol1_Defaulteventstyle));
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
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
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
            WEBI2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTBI2( ) ;
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
         return formatLink("wp_receptionistdashboard.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WP_ReceptionistDashboard" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Receptionist Dashboard", "") ;
      }

      protected void WBBI0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableWithSelectableGrid", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablecards.SetProperty("Width", Dvpanel_tablecards_Width);
            ucDvpanel_tablecards.SetProperty("AutoWidth", Dvpanel_tablecards_Autowidth);
            ucDvpanel_tablecards.SetProperty("AutoHeight", Dvpanel_tablecards_Autoheight);
            ucDvpanel_tablecards.SetProperty("Cls", Dvpanel_tablecards_Cls);
            ucDvpanel_tablecards.SetProperty("Title", Dvpanel_tablecards_Title);
            ucDvpanel_tablecards.SetProperty("Collapsible", Dvpanel_tablecards_Collapsible);
            ucDvpanel_tablecards.SetProperty("Collapsed", Dvpanel_tablecards_Collapsed);
            ucDvpanel_tablecards.SetProperty("ShowCollapseIcon", Dvpanel_tablecards_Showcollapseicon);
            ucDvpanel_tablecards.SetProperty("IconPosition", Dvpanel_tablecards_Iconposition);
            ucDvpanel_tablecards.SetProperty("AutoScroll", Dvpanel_tablecards_Autoscroll);
            ucDvpanel_tablecards.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablecards_Internalname, "DVPANEL_TABLECARDSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECARDSContainer"+"TableCards"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecards_Internalname, 1, 0, "px", 0, "px", "PanelCardContainer", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divKpi2_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table1_16_BI2( true) ;
         }
         else
         {
            wb_table1_16_BI2( false) ;
         }
         return  ;
      }

      protected void wb_table1_16_BI2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi2_value_Internalname, context.GetMessage( "KPI2_Value", ""), "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi2_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42KPI2_Value), 15, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi2_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV42KPI2_Value), "ZZZ,ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV42KPI2_Value), "ZZZ,ZZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi2_value_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavKpi2_value_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\KPINumericValue", "end", false, "", "HLP_WP_ReceptionistDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg", "Center", "top", "", "", "div");
            wb_table2_28_BI2( true) ;
         }
         else
         {
            wb_table2_28_BI2( false) ;
         }
         return  ;
      }

      protected void wb_table2_28_BI2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblViewdetailsuppliers_Internalname, context.GetMessage( "View details", ""), lblViewdetailsuppliers_Link, "", lblViewdetailsuppliers_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_ReceptionistDashboard.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divKpi3_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table3_44_BI2( true) ;
         }
         else
         {
            wb_table3_44_BI2( false) ;
         }
         return  ;
      }

      protected void wb_table3_44_BI2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi3_value_Internalname, context.GetMessage( "KPI3_Value", ""), "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi3_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45KPI3_Value), 15, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi3_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV45KPI3_Value), "ZZZ,ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV45KPI3_Value), "ZZZ,ZZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi3_value_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavKpi3_value_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\KPINumericValue", "end", false, "", "HLP_WP_ReceptionistDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg", "Center", "top", "", "", "div");
            wb_table4_56_BI2( true) ;
         }
         else
         {
            wb_table4_56_BI2( false) ;
         }
         return  ;
      }

      protected void wb_table4_56_BI2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblViewdetailsresidents_Internalname, context.GetMessage( "View details", ""), lblViewdetailsresidents_Link, "", lblViewdetailsresidents_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_ReceptionistDashboard.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divKpi4_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table5_72_BI2( true) ;
         }
         else
         {
            wb_table5_72_BI2( false) ;
         }
         return  ;
      }

      protected void wb_table5_72_BI2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi4_value_Internalname, context.GetMessage( "KPI4_Value", ""), "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi4_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48KPI4_Value), 15, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi4_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV48KPI4_Value), "ZZZ,ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV48KPI4_Value), "ZZZ,ZZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi4_value_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavKpi4_value_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\KPINumericValue", "end", false, "", "HLP_WP_ReceptionistDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg", "Center", "top", "", "", "div");
            wb_table6_84_BI2( true) ;
         }
         else
         {
            wb_table6_84_BI2( false) ;
         }
         return  ;
      }

      protected void wb_table6_84_BI2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblViewdetailsapp_Internalname, context.GetMessage( "View details", ""), lblViewdetailsapp_Link, "", lblViewdetailsapp_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_ReceptionistDashboard.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divKpi5_maintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table7_100_BI2( true) ;
         }
         else
         {
            wb_table7_100_BI2( false) ;
         }
         return  ;
      }

      protected void wb_table7_100_BI2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi5_value_Internalname, context.GetMessage( "KPI5_Value", ""), "col-sm-3 DashboardNumberCardNoBorderLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi5_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51KPI5_Value), 15, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi5_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV51KPI5_Value), "ZZZ,ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV51KPI5_Value), "ZZZ,ZZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi5_value_Jsonclick, 0, "DashboardNumberCardNoBorder", "", "", "", "", 1, edtavKpi5_value_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\KPINumericValue", "end", false, "", "HLP_WP_ReceptionistDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg", "Center", "top", "", "", "div");
            wb_table8_112_BI2( true) ;
         }
         else
         {
            wb_table8_112_BI2( false) ;
         }
         return  ;
      }

      protected void wb_table8_112_BI2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblViewdetailsfilledforms_Internalname, context.GetMessage( "View details", ""), lblViewdetailsfilledforms_Link, "", lblViewdetailsfilledforms_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_ReceptionistDashboard.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-5 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablenotifications.SetProperty("Width", Dvpanel_tablenotifications_Width);
            ucDvpanel_tablenotifications.SetProperty("AutoWidth", Dvpanel_tablenotifications_Autowidth);
            ucDvpanel_tablenotifications.SetProperty("AutoHeight", Dvpanel_tablenotifications_Autoheight);
            ucDvpanel_tablenotifications.SetProperty("Cls", Dvpanel_tablenotifications_Cls);
            ucDvpanel_tablenotifications.SetProperty("Title", Dvpanel_tablenotifications_Title);
            ucDvpanel_tablenotifications.SetProperty("Collapsible", Dvpanel_tablenotifications_Collapsible);
            ucDvpanel_tablenotifications.SetProperty("Collapsed", Dvpanel_tablenotifications_Collapsed);
            ucDvpanel_tablenotifications.SetProperty("ShowCollapseIcon", Dvpanel_tablenotifications_Showcollapseicon);
            ucDvpanel_tablenotifications.SetProperty("IconPosition", Dvpanel_tablenotifications_Iconposition);
            ucDvpanel_tablenotifications.SetProperty("AutoScroll", Dvpanel_tablenotifications_Autoscroll);
            ucDvpanel_tablenotifications.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablenotifications_Internalname, "DVPANEL_TABLENOTIFICATIONSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLENOTIFICATIONSContainer"+"TableNotifications"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablenotifications_Internalname, 1, 0, "px", divTablenotifications_Height, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "titleButton", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'',0)\"";
            ClassString = "buttonSmall";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsendmessage_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(139), 3, 0)+","+"null"+");", context.GetMessage( "Send Message", ""), bttBtnsendmessage_Jsonclick, 7, context.GetMessage( "Send Message", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e11bi1_client"+"'", TempTags, "", 2, "HLP_WP_ReceptionistDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 NotificationSubtitleCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNotificationssubtitle_Internalname, lblNotificationssubtitle_Caption, "", "", lblNotificationssubtitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_WP_ReceptionistDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CalendarOverflow GridNoBorderNoHeader CellMarginTop HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridusdtnotificationsdatasContainer.SetWrapped(nGXWrapped);
            StartGridControl139( ) ;
         }
         if ( wbEnd == 139 )
         {
            wbEnd = 0;
            nRC_GXsfl_139 = (int)(nGXsfl_139_idx-1);
            if ( GridusdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridusdtnotificationsdatasContainer.AddObjectProperty("GRIDUSDTNOTIFICATIONSDATAS_nEOF", GRIDUSDTNOTIFICATIONSDATAS_nEOF);
               GridusdtnotificationsdatasContainer.AddObjectProperty("GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage", GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage);
               AV75GXV1 = nGXsfl_139_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridusdtnotificationsdatasContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridusdtnotificationsdatas", GridusdtnotificationsdatasContainer, subGridusdtnotificationsdatas_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridusdtnotificationsdatasContainerData", GridusdtnotificationsdatasContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridusdtnotificationsdatasContainerData"+"V", GridusdtnotificationsdatasContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridusdtnotificationsdatasContainerData"+"V"+"\" value='"+GridusdtnotificationsdatasContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-7 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableagenda.SetProperty("Width", Dvpanel_tableagenda_Width);
            ucDvpanel_tableagenda.SetProperty("AutoWidth", Dvpanel_tableagenda_Autowidth);
            ucDvpanel_tableagenda.SetProperty("AutoHeight", Dvpanel_tableagenda_Autoheight);
            ucDvpanel_tableagenda.SetProperty("Cls", Dvpanel_tableagenda_Cls);
            ucDvpanel_tableagenda.SetProperty("Title", Dvpanel_tableagenda_Title);
            ucDvpanel_tableagenda.SetProperty("Collapsible", Dvpanel_tableagenda_Collapsible);
            ucDvpanel_tableagenda.SetProperty("Collapsed", Dvpanel_tableagenda_Collapsed);
            ucDvpanel_tableagenda.SetProperty("ShowCollapseIcon", Dvpanel_tableagenda_Showcollapseicon);
            ucDvpanel_tableagenda.SetProperty("IconPosition", Dvpanel_tableagenda_Iconposition);
            ucDvpanel_tableagenda.SetProperty("AutoScroll", Dvpanel_tableagenda_Autoscroll);
            ucDvpanel_tableagenda.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableagenda_Internalname, "DVPANEL_TABLEAGENDAContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEAGENDAContainer"+"TableAgenda"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableagenda_Internalname, 1, 0, "px", divTableagenda_Height, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "titleButton", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'',false,'',0)\"";
            ClassString = "buttonSmall";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncreateevent_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(139), 3, 0)+","+"null"+");", context.GetMessage( "WWP_Calendar_CreateEvent", ""), bttBtncreateevent_Jsonclick, 5, context.GetMessage( "WWP_Calendar_CreateEvent", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOCREATEEVENT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_ReceptionistDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "CalenderParent", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CalendarOverflow", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUsercontrol1.SetProperty("Events", AV25Events);
            ucUsercontrol1.SetProperty("DisabledDays", AV20DisabledDays);
            ucUsercontrol1.SetProperty("FromDate", AV5CalendarLoadFromDate);
            ucUsercontrol1.SetProperty("ToDate", AV6CalendarLoadToDate);
            ucUsercontrol1.SetProperty("Selectable", Usercontrol1_Selectable);
            ucUsercontrol1.SetProperty("InitialView", Usercontrol1_Initialview);
            ucUsercontrol1.SetProperty("ViewStyle", Usercontrol1_Viewstyle);
            ucUsercontrol1.SetProperty("NavLinks", Usercontrol1_Navlinks);
            ucUsercontrol1.SetProperty("TodayButtonPosition", Usercontrol1_Todaybuttonposition);
            ucUsercontrol1.SetProperty("PreviousButtonPosition", Usercontrol1_Previousbuttonposition);
            ucUsercontrol1.SetProperty("NextButtonPosition", Usercontrol1_Nextbuttonposition);
            ucUsercontrol1.SetProperty("MonthButtonPosition", Usercontrol1_Monthbuttonposition);
            ucUsercontrol1.SetProperty("WeekButtonPosition", Usercontrol1_Weekbuttonposition);
            ucUsercontrol1.SetProperty("DayButtonPosition", Usercontrol1_Daybuttonposition);
            ucUsercontrol1.SetProperty("TodayButtonText", Usercontrol1_Todaybuttontext);
            ucUsercontrol1.SetProperty("DayButtonText", Usercontrol1_Daybuttontext);
            ucUsercontrol1.Render(context, "dvelop.wwpcalendar", Usercontrol1_Internalname, "USERCONTROL1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
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
            wb_table9_168_BI2( true) ;
         }
         else
         {
            wb_table9_168_BI2( false) ;
         }
         return  ;
      }

      protected void wb_table9_168_BI2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table10_173_BI2( true) ;
         }
         else
         {
            wb_table10_173_BI2( false) ;
         }
         return  ;
      }

      protected void wb_table10_173_BI2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGridusdtnotificationsdatas_empowerer.Render(context, "wwp.gridempowerer", Gridusdtnotificationsdatas_empowerer_Internalname, "GRIDUSDTNOTIFICATIONSDATAS_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0180"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0180"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_139_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0180"+"");
                     }
                     WebComp_Wwpaux_wc.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
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
         }
         if ( wbEnd == 139 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridusdtnotificationsdatasContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridusdtnotificationsdatasContainer.AddObjectProperty("GRIDUSDTNOTIFICATIONSDATAS_nEOF", GRIDUSDTNOTIFICATIONSDATAS_nEOF);
                  GridusdtnotificationsdatasContainer.AddObjectProperty("GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage", GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage);
                  AV75GXV1 = nGXsfl_139_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridusdtnotificationsdatasContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridusdtnotificationsdatas", GridusdtnotificationsdatasContainer, subGridusdtnotificationsdatas_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridusdtnotificationsdatasContainerData", GridusdtnotificationsdatasContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridusdtnotificationsdatasContainerData"+"V", GridusdtnotificationsdatasContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridusdtnotificationsdatasContainerData"+"V"+"\" value='"+GridusdtnotificationsdatasContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void STARTBI2( )
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
         Form.Meta.addItem("description", context.GetMessage( "WP_Receptionist Dashboard", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPBI0( ) ;
      }

      protected void WSBI2( )
      {
         STARTBI2( ) ;
         EVTBI2( ) ;
      }

      protected void EVTBI2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "USERCONTROL1.EVENTSELECTED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Usercontrol1.Eventselected */
                              E12BI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "CREATEEVENT_MODAL.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Createevent_modal.Close */
                              E13BI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "CREATEEVENT_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Createevent_modal.Onloadcomponent */
                              E14BI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SENDMESSAGE_MODAL.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Sendmessage_modal.Close */
                              E15BI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SENDMESSAGE_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Sendmessage_modal.Onloadcomponent */
                              E16BI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCREATEEVENT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoCreateEvent' */
                              E17BI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "TABLENOTIFICATIONS.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Tablenotifications.Click */
                              E18BI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "TABLEAGENDA.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Tableagenda.Click */
                              E19BI2 ();
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
                              E20BI2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDUSDTNOTIFICATIONSDATASPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDUSDTNOTIFICATIONSDATASPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridusdtnotificationsdatas_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridusdtnotificationsdatas_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridusdtnotificationsdatas_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridusdtnotificationsdatas_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 31), "GRIDUSDTNOTIFICATIONSDATAS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "'DOUSERACTION1'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 41), "GRIDUSDTNOTIFICATIONSDATAS.ONLINEACTIVATE") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "ONMESSAGE_GX1") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_139_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
                              SubsflControlProps_1392( ) ;
                              AV75GXV1 = (int)(nGXsfl_139_idx+GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage);
                              if ( ( AV70USDTNotificationsData.Count >= AV75GXV1 ) && ( AV75GXV1 > 0 ) )
                              {
                                 AV70USDTNotificationsData.CurrentItem = ((SdtUSDTNotificationsData_USDTNotificationsDataItem)AV70USDTNotificationsData.Item(AV75GXV1));
                                 AV71NotificationIcon1 = cgiGet( edtavNotificationicon1_Internalname);
                                 AssignAttri("", false, edtavNotificationicon1_Internalname, AV71NotificationIcon1);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E21BI2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDUSDTNOTIFICATIONSDATAS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridusdtnotificationsdatas.Load */
                                    E22BI2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E23BI2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOUSERACTION1'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUserAction1' */
                                    E24BI2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDUSDTNOTIFICATIONSDATAS.ONLINEACTIVATE") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridusdtnotificationsdatas.Onlineactivate */
                                    E25BI2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Onmessage_gx1 */
                                    E20BI2 ();
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
                                    E20BI2 ();
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 180 )
                        {
                           OldWwpaux_wc = cgiGet( "W0180");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0180", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WEBI2( )
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

      protected void PABI2( )
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
               GX_FocusControl = edtavKpi2_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridusdtnotificationsdatas_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1392( ) ;
         while ( nGXsfl_139_idx <= nRC_GXsfl_139 )
         {
            sendrow_1392( ) ;
            nGXsfl_139_idx = ((subGridusdtnotificationsdatas_Islastpage==1)&&(nGXsfl_139_idx+1>subGridusdtnotificationsdatas_fnc_Recordsperpage( )) ? 1 : nGXsfl_139_idx+1);
            sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
            SubsflControlProps_1392( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridusdtnotificationsdatasContainer)) ;
         /* End function gxnrGridusdtnotificationsdatas_newrow */
      }

      protected void gxgrGridusdtnotificationsdatas_refresh( int subGridusdtnotificationsdatas_Rows ,
                                                             GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV68WWPContext ,
                                                             bool AV29ForceLoadDots ,
                                                             bool AV27EventsLoaded ,
                                                             DateTime AV5CalendarLoadFromDate ,
                                                             DateTime AV6CalendarLoadToDate ,
                                                             DateTime AV19Date_ShowingDatesFrom ,
                                                             DateTime AV10LoadedDotsFromDate ,
                                                             DateTime AV11LoadedDotsToDate ,
                                                             DateTime AV12LoadedFromDate ,
                                                             DateTime AV13LoadedToDate ,
                                                             GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item> AV25Events ,
                                                             GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem> AV70USDTNotificationsData ,
                                                             DateTime AV18Date ,
                                                             string AV15CalendarEventId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDUSDTNOTIFICATIONSDATAS_nCurrentRecord = 0;
         RFBI2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridusdtnotificationsdatas_refresh */
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
         RFBI2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavKpi2_value_Enabled = 0;
         AssignProp("", false, edtavKpi2_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi2_value_Enabled), 5, 0), true);
         edtavKpi2_percentagevalue_Enabled = 0;
         AssignProp("", false, edtavKpi2_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi2_percentagevalue_Enabled), 5, 0), true);
         edtavKpi3_value_Enabled = 0;
         AssignProp("", false, edtavKpi3_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi3_value_Enabled), 5, 0), true);
         edtavKpi3_percentagevalue_Enabled = 0;
         AssignProp("", false, edtavKpi3_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi3_percentagevalue_Enabled), 5, 0), true);
         edtavKpi4_value_Enabled = 0;
         AssignProp("", false, edtavKpi4_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi4_value_Enabled), 5, 0), true);
         edtavKpi4_percentagevalue_Enabled = 0;
         AssignProp("", false, edtavKpi4_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi4_percentagevalue_Enabled), 5, 0), true);
         edtavKpi5_value_Enabled = 0;
         AssignProp("", false, edtavKpi5_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi5_value_Enabled), 5, 0), true);
         edtavKpi5_percentagevalue_Enabled = 0;
         AssignProp("", false, edtavKpi5_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi5_percentagevalue_Enabled), 5, 0), true);
         edtavNotificationicon1_Enabled = 0;
         edtavUsdtnotificationsdata__notificationid_Enabled = 0;
         edtavUsdtnotificationsdata__notificationiconclass_Enabled = 0;
         edtavUsdtnotificationsdata__notificationtitle_Enabled = 0;
         edtavUsdtnotificationsdata__notificationdescription_Enabled = 0;
         edtavUsdtnotificationsdata__notificationdatetime_Enabled = 0;
         edtavUsdtnotificationsdata__notificationlink_Enabled = 0;
         edtavUsdtnotificationsdata__notificationdefinitionid_Enabled = 0;
         chkavUsdtnotificationsdata__notificationisread.Enabled = 0;
         edtavUsdtnotificationsdata__notificationmetadata_Enabled = 0;
      }

      protected void RFBI2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridusdtnotificationsdatasContainer.ClearRows();
         }
         wbStart = 139;
         /* Execute user event: Refresh */
         E23BI2 ();
         nGXsfl_139_idx = 1;
         sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
         SubsflControlProps_1392( ) ;
         bGXsfl_139_Refreshing = true;
         GridusdtnotificationsdatasContainer.AddObjectProperty("GridName", "Gridusdtnotificationsdatas");
         GridusdtnotificationsdatasContainer.AddObjectProperty("CmpContext", "");
         GridusdtnotificationsdatasContainer.AddObjectProperty("InMasterPage", "false");
         GridusdtnotificationsdatasContainer.AddObjectProperty("Class", "WorkWithSelection WorkWith");
         GridusdtnotificationsdatasContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridusdtnotificationsdatasContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridusdtnotificationsdatasContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusdtnotificationsdatas_Backcolorstyle), 1, 0, ".", "")));
         GridusdtnotificationsdatasContainer.PageSize = subGridusdtnotificationsdatas_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1392( ) ;
            /* Execute user event: Gridusdtnotificationsdatas.Load */
            E22BI2 ();
            if ( ( subGridusdtnotificationsdatas_Islastpage == 0 ) && ( GRIDUSDTNOTIFICATIONSDATAS_nCurrentRecord > 0 ) && ( GRIDUSDTNOTIFICATIONSDATAS_nGridOutOfScope == 0 ) && ( nGXsfl_139_idx == 1 ) )
            {
               GRIDUSDTNOTIFICATIONSDATAS_nCurrentRecord = 0;
               GRIDUSDTNOTIFICATIONSDATAS_nGridOutOfScope = 1;
               subgridusdtnotificationsdatas_firstpage( ) ;
               /* Execute user event: Gridusdtnotificationsdatas.Load */
               E22BI2 ();
            }
            wbEnd = 139;
            WBBI0( ) ;
         }
         bGXsfl_139_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesBI2( )
      {
         GxWebStd.gx_hidden_field( context, "vDATE", context.localUtil.DToC( AV18Date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vDATE", GetSecureSignedToken( "", AV18Date, context));
         GxWebStd.gx_hidden_field( context, "vCALENDAREVENTID", AV15CalendarEventId);
         GxWebStd.gx_hidden_field( context, "gxhash_vCALENDAREVENTID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV15CalendarEventId, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV68WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV68WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPCONTEXT", GetSecureSignedToken( "", AV68WWPContext, context));
         GxWebStd.gx_hidden_field( context, "vDATE_SHOWINGDATESFROM", context.localUtil.DToC( AV19Date_ShowingDatesFrom, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vDATE_SHOWINGDATESFROM", GetSecureSignedToken( "", AV19Date_ShowingDatesFrom, context));
      }

      protected int subGridusdtnotificationsdatas_fnc_Pagecount( )
      {
         GRIDUSDTNOTIFICATIONSDATAS_nRecordCount = subGridusdtnotificationsdatas_fnc_Recordcount( );
         if ( ((int)((GRIDUSDTNOTIFICATIONSDATAS_nRecordCount) % (subGridusdtnotificationsdatas_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDUSDTNOTIFICATIONSDATAS_nRecordCount/ (decimal)(subGridusdtnotificationsdatas_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDUSDTNOTIFICATIONSDATAS_nRecordCount/ (decimal)(subGridusdtnotificationsdatas_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridusdtnotificationsdatas_fnc_Recordcount( )
      {
         return AV70USDTNotificationsData.Count ;
      }

      protected int subGridusdtnotificationsdatas_fnc_Recordsperpage( )
      {
         if ( subGridusdtnotificationsdatas_Rows > 0 )
         {
            return subGridusdtnotificationsdatas_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridusdtnotificationsdatas_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage/ (decimal)(subGridusdtnotificationsdatas_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridusdtnotificationsdatas_firstpage( )
      {
         GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridusdtnotificationsdatas_refresh( subGridusdtnotificationsdatas_Rows, AV68WWPContext, AV29ForceLoadDots, AV27EventsLoaded, AV5CalendarLoadFromDate, AV6CalendarLoadToDate, AV19Date_ShowingDatesFrom, AV10LoadedDotsFromDate, AV11LoadedDotsToDate, AV12LoadedFromDate, AV13LoadedToDate, AV25Events, AV70USDTNotificationsData, AV18Date, AV15CalendarEventId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridusdtnotificationsdatas_nextpage( )
      {
         GRIDUSDTNOTIFICATIONSDATAS_nRecordCount = subGridusdtnotificationsdatas_fnc_Recordcount( );
         if ( ( GRIDUSDTNOTIFICATIONSDATAS_nRecordCount >= subGridusdtnotificationsdatas_fnc_Recordsperpage( ) ) && ( GRIDUSDTNOTIFICATIONSDATAS_nEOF == 0 ) )
         {
            GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage = (long)(GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage+subGridusdtnotificationsdatas_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage), 15, 0, ".", "")));
         GridusdtnotificationsdatasContainer.AddObjectProperty("GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage", GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridusdtnotificationsdatas_refresh( subGridusdtnotificationsdatas_Rows, AV68WWPContext, AV29ForceLoadDots, AV27EventsLoaded, AV5CalendarLoadFromDate, AV6CalendarLoadToDate, AV19Date_ShowingDatesFrom, AV10LoadedDotsFromDate, AV11LoadedDotsToDate, AV12LoadedFromDate, AV13LoadedToDate, AV25Events, AV70USDTNotificationsData, AV18Date, AV15CalendarEventId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDUSDTNOTIFICATIONSDATAS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridusdtnotificationsdatas_previouspage( )
      {
         if ( GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage >= subGridusdtnotificationsdatas_fnc_Recordsperpage( ) )
         {
            GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage = (long)(GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage-subGridusdtnotificationsdatas_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridusdtnotificationsdatas_refresh( subGridusdtnotificationsdatas_Rows, AV68WWPContext, AV29ForceLoadDots, AV27EventsLoaded, AV5CalendarLoadFromDate, AV6CalendarLoadToDate, AV19Date_ShowingDatesFrom, AV10LoadedDotsFromDate, AV11LoadedDotsToDate, AV12LoadedFromDate, AV13LoadedToDate, AV25Events, AV70USDTNotificationsData, AV18Date, AV15CalendarEventId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridusdtnotificationsdatas_lastpage( )
      {
         GRIDUSDTNOTIFICATIONSDATAS_nRecordCount = subGridusdtnotificationsdatas_fnc_Recordcount( );
         if ( GRIDUSDTNOTIFICATIONSDATAS_nRecordCount > subGridusdtnotificationsdatas_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDUSDTNOTIFICATIONSDATAS_nRecordCount) % (subGridusdtnotificationsdatas_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage = (long)(GRIDUSDTNOTIFICATIONSDATAS_nRecordCount-subGridusdtnotificationsdatas_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage = (long)(GRIDUSDTNOTIFICATIONSDATAS_nRecordCount-((int)((GRIDUSDTNOTIFICATIONSDATAS_nRecordCount) % (subGridusdtnotificationsdatas_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridusdtnotificationsdatas_refresh( subGridusdtnotificationsdatas_Rows, AV68WWPContext, AV29ForceLoadDots, AV27EventsLoaded, AV5CalendarLoadFromDate, AV6CalendarLoadToDate, AV19Date_ShowingDatesFrom, AV10LoadedDotsFromDate, AV11LoadedDotsToDate, AV12LoadedFromDate, AV13LoadedToDate, AV25Events, AV70USDTNotificationsData, AV18Date, AV15CalendarEventId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridusdtnotificationsdatas_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage = (long)(subGridusdtnotificationsdatas_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridusdtnotificationsdatas_refresh( subGridusdtnotificationsdatas_Rows, AV68WWPContext, AV29ForceLoadDots, AV27EventsLoaded, AV5CalendarLoadFromDate, AV6CalendarLoadToDate, AV19Date_ShowingDatesFrom, AV10LoadedDotsFromDate, AV11LoadedDotsToDate, AV12LoadedFromDate, AV13LoadedToDate, AV25Events, AV70USDTNotificationsData, AV18Date, AV15CalendarEventId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavKpi2_value_Enabled = 0;
         AssignProp("", false, edtavKpi2_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi2_value_Enabled), 5, 0), true);
         edtavKpi2_percentagevalue_Enabled = 0;
         AssignProp("", false, edtavKpi2_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi2_percentagevalue_Enabled), 5, 0), true);
         edtavKpi3_value_Enabled = 0;
         AssignProp("", false, edtavKpi3_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi3_value_Enabled), 5, 0), true);
         edtavKpi3_percentagevalue_Enabled = 0;
         AssignProp("", false, edtavKpi3_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi3_percentagevalue_Enabled), 5, 0), true);
         edtavKpi4_value_Enabled = 0;
         AssignProp("", false, edtavKpi4_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi4_value_Enabled), 5, 0), true);
         edtavKpi4_percentagevalue_Enabled = 0;
         AssignProp("", false, edtavKpi4_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi4_percentagevalue_Enabled), 5, 0), true);
         edtavKpi5_value_Enabled = 0;
         AssignProp("", false, edtavKpi5_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi5_value_Enabled), 5, 0), true);
         edtavKpi5_percentagevalue_Enabled = 0;
         AssignProp("", false, edtavKpi5_percentagevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavKpi5_percentagevalue_Enabled), 5, 0), true);
         edtavNotificationicon1_Enabled = 0;
         edtavUsdtnotificationsdata__notificationid_Enabled = 0;
         edtavUsdtnotificationsdata__notificationiconclass_Enabled = 0;
         edtavUsdtnotificationsdata__notificationtitle_Enabled = 0;
         edtavUsdtnotificationsdata__notificationdescription_Enabled = 0;
         edtavUsdtnotificationsdata__notificationdatetime_Enabled = 0;
         edtavUsdtnotificationsdata__notificationlink_Enabled = 0;
         edtavUsdtnotificationsdata__notificationdefinitionid_Enabled = 0;
         chkavUsdtnotificationsdata__notificationisread.Enabled = 0;
         edtavUsdtnotificationsdata__notificationmetadata_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPBI0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E21BI2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Usdtnotificationsdata"), AV70USDTNotificationsData);
            ajax_req_read_hidden_sdt(cgiGet( "vEVENTS"), AV25Events);
            ajax_req_read_hidden_sdt(cgiGet( "vDISABLEDDAYS"), AV20DisabledDays);
            ajax_req_read_hidden_sdt(cgiGet( "vUSDTNOTIFICATIONSDATA"), AV70USDTNotificationsData);
            ajax_req_read_hidden_sdt(cgiGet( "vNOTIFICATIONINFO"), AV74NotificationInfo);
            /* Read saved values. */
            nRC_GXsfl_139 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_139"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV5CalendarLoadFromDate = context.localUtil.CToD( cgiGet( "vCALENDARLOADFROMDATE"), 0);
            AV6CalendarLoadToDate = context.localUtil.CToD( cgiGet( "vCALENDARLOADTODATE"), 0);
            GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDUSDTNOTIFICATIONSDATAS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDUSDTNOTIFICATIONSDATAS_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGridusdtnotificationsdatas_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDUSDTNOTIFICATIONSDATAS_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRIDUSDTNOTIFICATIONSDATAS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusdtnotificationsdatas_Rows), 6, 0, ".", "")));
            Dvpanel_tablecards_Width = cgiGet( "DVPANEL_TABLECARDS_Width");
            Dvpanel_tablecards_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Autowidth"));
            Dvpanel_tablecards_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Autoheight"));
            Dvpanel_tablecards_Cls = cgiGet( "DVPANEL_TABLECARDS_Cls");
            Dvpanel_tablecards_Title = cgiGet( "DVPANEL_TABLECARDS_Title");
            Dvpanel_tablecards_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Collapsible"));
            Dvpanel_tablecards_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Collapsed"));
            Dvpanel_tablecards_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Showcollapseicon"));
            Dvpanel_tablecards_Iconposition = cgiGet( "DVPANEL_TABLECARDS_Iconposition");
            Dvpanel_tablecards_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Autoscroll"));
            Dvpanel_tablenotifications_Width = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Width");
            Dvpanel_tablenotifications_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Autowidth"));
            Dvpanel_tablenotifications_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Autoheight"));
            Dvpanel_tablenotifications_Cls = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Cls");
            Dvpanel_tablenotifications_Title = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Title");
            Dvpanel_tablenotifications_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Collapsible"));
            Dvpanel_tablenotifications_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Collapsed"));
            Dvpanel_tablenotifications_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Showcollapseicon"));
            Dvpanel_tablenotifications_Iconposition = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Iconposition");
            Dvpanel_tablenotifications_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Autoscroll"));
            Usercontrol1_Selectable = StringUtil.StrToBool( cgiGet( "USERCONTROL1_Selectable"));
            Usercontrol1_Initialview = cgiGet( "USERCONTROL1_Initialview");
            Usercontrol1_Viewstyle = cgiGet( "USERCONTROL1_Viewstyle");
            Usercontrol1_Navlinks = StringUtil.StrToBool( cgiGet( "USERCONTROL1_Navlinks"));
            Usercontrol1_Todaybuttonposition = cgiGet( "USERCONTROL1_Todaybuttonposition");
            Usercontrol1_Previousbuttonposition = cgiGet( "USERCONTROL1_Previousbuttonposition");
            Usercontrol1_Nextbuttonposition = cgiGet( "USERCONTROL1_Nextbuttonposition");
            Usercontrol1_Monthbuttonposition = cgiGet( "USERCONTROL1_Monthbuttonposition");
            Usercontrol1_Weekbuttonposition = cgiGet( "USERCONTROL1_Weekbuttonposition");
            Usercontrol1_Daybuttonposition = cgiGet( "USERCONTROL1_Daybuttonposition");
            Usercontrol1_Todaybuttontext = cgiGet( "USERCONTROL1_Todaybuttontext");
            Usercontrol1_Daybuttontext = cgiGet( "USERCONTROL1_Daybuttontext");
            Dvpanel_tableagenda_Width = cgiGet( "DVPANEL_TABLEAGENDA_Width");
            Dvpanel_tableagenda_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEAGENDA_Autowidth"));
            Dvpanel_tableagenda_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEAGENDA_Autoheight"));
            Dvpanel_tableagenda_Cls = cgiGet( "DVPANEL_TABLEAGENDA_Cls");
            Dvpanel_tableagenda_Title = cgiGet( "DVPANEL_TABLEAGENDA_Title");
            Dvpanel_tableagenda_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEAGENDA_Collapsible"));
            Dvpanel_tableagenda_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEAGENDA_Collapsed"));
            Dvpanel_tableagenda_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEAGENDA_Showcollapseicon"));
            Dvpanel_tableagenda_Iconposition = cgiGet( "DVPANEL_TABLEAGENDA_Iconposition");
            Dvpanel_tableagenda_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEAGENDA_Autoscroll"));
            Createevent_modal_Width = cgiGet( "CREATEEVENT_MODAL_Width");
            Createevent_modal_Title = cgiGet( "CREATEEVENT_MODAL_Title");
            Createevent_modal_Confirmtype = cgiGet( "CREATEEVENT_MODAL_Confirmtype");
            Createevent_modal_Bodytype = cgiGet( "CREATEEVENT_MODAL_Bodytype");
            Sendmessage_modal_Width = cgiGet( "SENDMESSAGE_MODAL_Width");
            Sendmessage_modal_Title = cgiGet( "SENDMESSAGE_MODAL_Title");
            Sendmessage_modal_Confirmtype = cgiGet( "SENDMESSAGE_MODAL_Confirmtype");
            Sendmessage_modal_Bodytype = cgiGet( "SENDMESSAGE_MODAL_Bodytype");
            Gridusdtnotificationsdatas_empowerer_Gridinternalname = cgiGet( "GRIDUSDTNOTIFICATIONSDATAS_EMPOWERER_Gridinternalname");
            lblNotificationssubtitle_Caption = cgiGet( "NOTIFICATIONSSUBTITLE_Caption");
            Usercontrol1_Defaulteventstyle = cgiGet( "USERCONTROL1_Defaulteventstyle");
            Usercontrol1_Defaulteventstyle = cgiGet( "USERCONTROL1_Defaulteventstyle");
            nRC_GXsfl_139 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_139"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_139_fel_idx = 0;
            while ( nGXsfl_139_fel_idx < nRC_GXsfl_139 )
            {
               nGXsfl_139_fel_idx = ((subGridusdtnotificationsdatas_Islastpage==1)&&(nGXsfl_139_fel_idx+1>subGridusdtnotificationsdatas_fnc_Recordsperpage( )) ? 1 : nGXsfl_139_fel_idx+1);
               sGXsfl_139_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_1392( ) ;
               AV75GXV1 = (int)(nGXsfl_139_fel_idx+GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage);
               if ( ( AV70USDTNotificationsData.Count >= AV75GXV1 ) && ( AV75GXV1 > 0 ) )
               {
                  AV70USDTNotificationsData.CurrentItem = ((SdtUSDTNotificationsData_USDTNotificationsDataItem)AV70USDTNotificationsData.Item(AV75GXV1));
                  AV71NotificationIcon1 = cgiGet( edtavNotificationicon1_Internalname);
               }
            }
            if ( nGXsfl_139_fel_idx == 0 )
            {
               nGXsfl_139_idx = 1;
               sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
               SubsflControlProps_1392( ) ;
            }
            nGXsfl_139_fel_idx = 1;
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavKpi2_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavKpi2_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vKPI2_VALUE");
               GX_FocusControl = edtavKpi2_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV42KPI2_Value = 0;
               AssignAttri("", false, "AV42KPI2_Value", StringUtil.LTrimStr( (decimal)(AV42KPI2_Value), 12, 0));
            }
            else
            {
               AV42KPI2_Value = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavKpi2_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV42KPI2_Value", StringUtil.LTrimStr( (decimal)(AV42KPI2_Value), 12, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavKpi2_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavKpi2_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 99.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vKPI2_PERCENTAGEVALUE");
               GX_FocusControl = edtavKpi2_percentagevalue_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV41KPI2_PercentageValue = 0;
               AssignAttri("", false, "AV41KPI2_PercentageValue", StringUtil.LTrimStr( AV41KPI2_PercentageValue, 5, 2));
            }
            else
            {
               AV41KPI2_PercentageValue = context.localUtil.CToN( cgiGet( edtavKpi2_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV41KPI2_PercentageValue", StringUtil.LTrimStr( AV41KPI2_PercentageValue, 5, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavKpi3_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavKpi3_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vKPI3_VALUE");
               GX_FocusControl = edtavKpi3_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV45KPI3_Value = 0;
               AssignAttri("", false, "AV45KPI3_Value", StringUtil.LTrimStr( (decimal)(AV45KPI3_Value), 12, 0));
            }
            else
            {
               AV45KPI3_Value = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavKpi3_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45KPI3_Value", StringUtil.LTrimStr( (decimal)(AV45KPI3_Value), 12, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavKpi3_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavKpi3_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 99.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vKPI3_PERCENTAGEVALUE");
               GX_FocusControl = edtavKpi3_percentagevalue_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV44KPI3_PercentageValue = 0;
               AssignAttri("", false, "AV44KPI3_PercentageValue", StringUtil.LTrimStr( AV44KPI3_PercentageValue, 5, 2));
            }
            else
            {
               AV44KPI3_PercentageValue = context.localUtil.CToN( cgiGet( edtavKpi3_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV44KPI3_PercentageValue", StringUtil.LTrimStr( AV44KPI3_PercentageValue, 5, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavKpi4_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavKpi4_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vKPI4_VALUE");
               GX_FocusControl = edtavKpi4_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV48KPI4_Value = 0;
               AssignAttri("", false, "AV48KPI4_Value", StringUtil.LTrimStr( (decimal)(AV48KPI4_Value), 12, 0));
            }
            else
            {
               AV48KPI4_Value = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavKpi4_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV48KPI4_Value", StringUtil.LTrimStr( (decimal)(AV48KPI4_Value), 12, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavKpi4_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavKpi4_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 99.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vKPI4_PERCENTAGEVALUE");
               GX_FocusControl = edtavKpi4_percentagevalue_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV47KPI4_PercentageValue = 0;
               AssignAttri("", false, "AV47KPI4_PercentageValue", StringUtil.LTrimStr( AV47KPI4_PercentageValue, 5, 2));
            }
            else
            {
               AV47KPI4_PercentageValue = context.localUtil.CToN( cgiGet( edtavKpi4_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV47KPI4_PercentageValue", StringUtil.LTrimStr( AV47KPI4_PercentageValue, 5, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavKpi5_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavKpi5_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vKPI5_VALUE");
               GX_FocusControl = edtavKpi5_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV51KPI5_Value = 0;
               AssignAttri("", false, "AV51KPI5_Value", StringUtil.LTrimStr( (decimal)(AV51KPI5_Value), 12, 0));
            }
            else
            {
               AV51KPI5_Value = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavKpi5_value_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV51KPI5_Value", StringUtil.LTrimStr( (decimal)(AV51KPI5_Value), 12, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavKpi5_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavKpi5_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 99.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vKPI5_PERCENTAGEVALUE");
               GX_FocusControl = edtavKpi5_percentagevalue_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV50KPI5_PercentageValue = 0;
               AssignAttri("", false, "AV50KPI5_PercentageValue", StringUtil.LTrimStr( AV50KPI5_PercentageValue, 5, 2));
            }
            else
            {
               AV50KPI5_PercentageValue = context.localUtil.CToN( cgiGet( edtavKpi5_percentagevalue_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV50KPI5_PercentageValue", StringUtil.LTrimStr( AV50KPI5_PercentageValue, 5, 2));
            }
            /* Read subfile selected row values. */
            nGXsfl_139_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGridusdtnotificationsdatas_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
            SubsflControlProps_1392( ) ;
            AV75GXV1 = (int)(nGXsfl_139_idx+GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage);
            if ( nGXsfl_139_idx > 0 )
            {
               AV75GXV1 = (int)(nGXsfl_139_idx+GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage);
               if ( ( AV70USDTNotificationsData.Count >= AV75GXV1 ) && ( AV75GXV1 > 0 ) )
               {
                  AV70USDTNotificationsData.CurrentItem = ((SdtUSDTNotificationsData_USDTNotificationsDataItem)AV70USDTNotificationsData.Item(AV75GXV1));
                  AV71NotificationIcon1 = cgiGet( edtavNotificationicon1_Internalname);
                  AssignAttri("", false, edtavNotificationicon1_Internalname, AV71NotificationIcon1);
               }
               if ( ( AV75GXV1 > 0 ) && ( AV70USDTNotificationsData.Count >= AV75GXV1 ) )
               {
                  AV70USDTNotificationsData.CurrentItem = ((SdtUSDTNotificationsData_USDTNotificationsDataItem)AV70USDTNotificationsData.Item(AV75GXV1));
               }
            }
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E21BI2 ();
         if (returnInSub) return;
      }

      protected void E21BI2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_boolean1 = AV72PackageAvailable;
         new prc_checkresidentpackageavailable(context ).execute( out  GXt_boolean1) ;
         AV72PackageAvailable = GXt_boolean1;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV68WWPContext) ;
         AV53LocationId = AV68WWPContext.gxTpr_Locationid;
         GXt_char2 = AV73ResidentTitle;
         new prc_getorganisationdefinition(context ).execute(  "Residents", out  GXt_char2) ;
         AV73ResidentTitle = GXt_char2;
         lblKpi3_description_Caption = StringUtil.Upper( AV73ResidentTitle);
         AssignProp("", false, lblKpi3_description_Internalname, "Caption", lblKpi3_description_Caption, true);
         lblViewdetailsuppliers_Link = formatLink("wp_organisationgeneralsuppliers.aspx") ;
         AssignProp("", false, lblViewdetailsuppliers_Internalname, "Link", lblViewdetailsuppliers_Link, true);
         lblViewdetailsresidents_Link = formatLink("wp_locationresidents.aspx") ;
         AssignProp("", false, lblViewdetailsresidents_Internalname, "Link", lblViewdetailsresidents_Link, true);
         if ( AV72PackageAvailable )
         {
            lblViewdetailsapp_Link = formatLink("wp_provisionedappdashboard.aspx") ;
            AssignProp("", false, lblViewdetailsapp_Internalname, "Link", lblViewdetailsapp_Link, true);
         }
         lblViewdetailsfilledforms_Link = formatLink("wp_filledforms.aspx") ;
         AssignProp("", false, lblViewdetailsfilledforms_Internalname, "Link", lblViewdetailsfilledforms_Link, true);
         GXt_int3 = (short)(AV42KPI2_Value);
         new prc_countsuppliers(context ).execute( out  GXt_int3) ;
         AV42KPI2_Value = GXt_int3;
         AssignAttri("", false, "AV42KPI2_Value", StringUtil.LTrimStr( (decimal)(AV42KPI2_Value), 12, 0));
         GXt_int3 = (short)(AV45KPI3_Value);
         new prc_countlocationresidents(context ).execute( out  GXt_int3) ;
         AV45KPI3_Value = GXt_int3;
         AssignAttri("", false, "AV45KPI3_Value", StringUtil.LTrimStr( (decimal)(AV45KPI3_Value), 12, 0));
         GXt_int3 = (short)(AV48KPI4_Value);
         new prc_countdevices(context ).execute( out  GXt_int3) ;
         AV48KPI4_Value = GXt_int3;
         AssignAttri("", false, "AV48KPI4_Value", StringUtil.LTrimStr( (decimal)(AV48KPI4_Value), 12, 0));
         GXt_objcol_SdtHomeSampleData_HomeSampleDataItem4 = AV9HomeSampleData;
         new WorkWithPlus.workwithplus_web.gethomesampledata(context ).execute( out  GXt_objcol_SdtHomeSampleData_HomeSampleDataItem4) ;
         AV9HomeSampleData = GXt_objcol_SdtHomeSampleData_HomeSampleDataItem4;
         /* Execute user subroutine: 'GETUNREADNOTIFICATIONS' */
         S112 ();
         if (returnInSub) return;
         GXt_int3 = (short)(AV51KPI5_Value);
         new prc_countlocationfilledforms(context ).execute( out  GXt_int3) ;
         AV51KPI5_Value = GXt_int3;
         AssignAttri("", false, "AV51KPI5_Value", StringUtil.LTrimStr( (decimal)(AV51KPI5_Value), 12, 0));
         AV38KPI1_PercentageValue = (decimal)(18);
         AV41KPI2_PercentageValue = (decimal)(41);
         AssignAttri("", false, "AV41KPI2_PercentageValue", StringUtil.LTrimStr( AV41KPI2_PercentageValue, 5, 2));
         AV44KPI3_PercentageValue = (decimal)(25);
         AssignAttri("", false, "AV44KPI3_PercentageValue", StringUtil.LTrimStr( AV44KPI3_PercentageValue, 5, 2));
         AV47KPI4_PercentageValue = (decimal)(8);
         AssignAttri("", false, "AV47KPI4_PercentageValue", StringUtil.LTrimStr( AV47KPI4_PercentageValue, 5, 2));
         AV50KPI5_PercentageValue = (decimal)(12);
         AssignAttri("", false, "AV50KPI5_PercentageValue", StringUtil.LTrimStr( AV50KPI5_PercentageValue, 5, 2));
         AV37KPI1_IsSuccessfulValue = true;
         AV46KPI4_IsSuccessfulValue = true;
         AV59Progress1_Value = 1568;
         AV58Progress1_TotalValue = 1890;
         AV61Progress2_Value = 421;
         AV60Progress2_TotalValue = 752;
         AV63Progress3_Value = 1669;
         AV62Progress3_TotalValue = 2256;
         AV65Progress4_Value = 1085;
         AV64Progress4_TotalValue = 5423;
         divTableagenda_Height = 360;
         AssignProp("", false, divTableagenda_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divTableagenda_Height), 9, 0), true);
         divTablenotifications_Height = 360;
         AssignProp("", false, divTablenotifications_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divTablenotifications_Height), 9, 0), true);
         Gridusdtnotificationsdatas_empowerer_Gridinternalname = subGridusdtnotificationsdatas_Internalname;
         ucGridusdtnotificationsdatas_empowerer.SendProperty(context, "", false, Gridusdtnotificationsdatas_empowerer_Internalname, "GridInternalName", Gridusdtnotificationsdatas_empowerer_Gridinternalname);
         subGridusdtnotificationsdatas_Rows = 0;
         GxWebStd.gx_hidden_field( context, "GRIDUSDTNOTIFICATIONSDATAS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusdtnotificationsdatas_Rows), 6, 0, ".", "")));
         if ( AV40KPI2_IsSuccessfulValue )
         {
            lblKpi2_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconSuccess", "up", "", "", "", "", "", "", "");
            AssignProp("", false, lblKpi2_moreinfoicon_Internalname, "Caption", lblKpi2_moreinfoicon_Caption, true);
            edtavKpi2_percentagevalue_Class = "DashboardPercentageSuccess";
            AssignProp("", false, edtavKpi2_percentagevalue_Internalname, "Class", edtavKpi2_percentagevalue_Class, true);
         }
         else
         {
            lblKpi2_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconDanger", "down", "", "", "", "", "", "", "");
            AssignProp("", false, lblKpi2_moreinfoicon_Internalname, "Caption", lblKpi2_moreinfoicon_Caption, true);
            edtavKpi2_percentagevalue_Class = "DashboardPercentageDanger";
            AssignProp("", false, edtavKpi2_percentagevalue_Internalname, "Class", edtavKpi2_percentagevalue_Class, true);
         }
         if ( AV43KPI3_IsSuccessfulValue )
         {
            lblKpi3_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconSuccess", "up", "", "", "", "", "", "", "");
            AssignProp("", false, lblKpi3_moreinfoicon_Internalname, "Caption", lblKpi3_moreinfoicon_Caption, true);
            edtavKpi3_percentagevalue_Class = "DashboardPercentageSuccess";
            AssignProp("", false, edtavKpi3_percentagevalue_Internalname, "Class", edtavKpi3_percentagevalue_Class, true);
         }
         else
         {
            lblKpi3_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconDanger", "down", "", "", "", "", "", "", "");
            AssignProp("", false, lblKpi3_moreinfoicon_Internalname, "Caption", lblKpi3_moreinfoicon_Caption, true);
            edtavKpi3_percentagevalue_Class = "DashboardPercentageDanger";
            AssignProp("", false, edtavKpi3_percentagevalue_Internalname, "Class", edtavKpi3_percentagevalue_Class, true);
         }
         if ( AV46KPI4_IsSuccessfulValue )
         {
            lblKpi4_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconSuccess", "up", "", "", "", "", "", "", "");
            AssignProp("", false, lblKpi4_moreinfoicon_Internalname, "Caption", lblKpi4_moreinfoicon_Caption, true);
            edtavKpi4_percentagevalue_Class = "DashboardPercentageSuccess";
            AssignProp("", false, edtavKpi4_percentagevalue_Internalname, "Class", edtavKpi4_percentagevalue_Class, true);
         }
         else
         {
            lblKpi4_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconDanger", "down", "", "", "", "", "", "", "");
            AssignProp("", false, lblKpi4_moreinfoicon_Internalname, "Caption", lblKpi4_moreinfoicon_Caption, true);
            edtavKpi4_percentagevalue_Class = "DashboardPercentageDanger";
            AssignProp("", false, edtavKpi4_percentagevalue_Internalname, "Class", edtavKpi4_percentagevalue_Class, true);
         }
         if ( AV49KPI5_IsSuccessfulValue )
         {
            lblKpi5_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconSuccess", "up", "", "", "", "", "", "", "");
            AssignProp("", false, lblKpi5_moreinfoicon_Internalname, "Caption", lblKpi5_moreinfoicon_Caption, true);
            edtavKpi5_percentagevalue_Class = "DashboardPercentageSuccess";
            AssignProp("", false, edtavKpi5_percentagevalue_Internalname, "Class", edtavKpi5_percentagevalue_Class, true);
         }
         else
         {
            lblKpi5_moreinfoicon_Caption = StringUtil.Format( "<i class='%1 fas fa-caret-%2' style='font-size: 12px'></i>", "FontColorIconDanger", "down", "", "", "", "", "", "", "");
            AssignProp("", false, lblKpi5_moreinfoicon_Internalname, "Caption", lblKpi5_moreinfoicon_Caption, true);
            edtavKpi5_percentagevalue_Class = "DashboardPercentageDanger";
            AssignProp("", false, edtavKpi5_percentagevalue_Internalname, "Class", edtavKpi5_percentagevalue_Class, true);
         }
         /* Execute user subroutine: 'LOADCALENDAR' */
         S122 ();
         if (returnInSub) return;
      }

      private void E22BI2( )
      {
         /* Gridusdtnotificationsdatas_Load Routine */
         returnInSub = false;
         AV75GXV1 = 1;
         while ( AV75GXV1 <= AV70USDTNotificationsData.Count )
         {
            AV70USDTNotificationsData.CurrentItem = ((SdtUSDTNotificationsData_USDTNotificationsDataItem)AV70USDTNotificationsData.Item(AV75GXV1));
            edtavNotificationicon1_Format = 2;
            AV71NotificationIcon1 = StringUtil.Format( "<i class=\"%1 %2\"></i>", ((SdtUSDTNotificationsData_USDTNotificationsDataItem)(AV70USDTNotificationsData.CurrentItem)).gxTpr_Notificationiconclass, "NotificationFontIconGrid", "", "", "", "", "", "", "");
            AssignAttri("", false, edtavNotificationicon1_Internalname, AV71NotificationIcon1);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 139;
            }
            if ( ( subGridusdtnotificationsdatas_Islastpage == 1 ) || ( subGridusdtnotificationsdatas_Rows == 0 ) || ( ( GRIDUSDTNOTIFICATIONSDATAS_nCurrentRecord >= GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage ) && ( GRIDUSDTNOTIFICATIONSDATAS_nCurrentRecord < GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage + subGridusdtnotificationsdatas_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_1392( ) ;
            }
            GRIDUSDTNOTIFICATIONSDATAS_nEOF = (short)(((GRIDUSDTNOTIFICATIONSDATAS_nCurrentRecord<GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage+subGridusdtnotificationsdatas_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDUSDTNOTIFICATIONSDATAS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDUSDTNOTIFICATIONSDATAS_nEOF), 1, 0, ".", "")));
            GRIDUSDTNOTIFICATIONSDATAS_nCurrentRecord = (long)(GRIDUSDTNOTIFICATIONSDATAS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_139_Refreshing )
            {
               DoAjaxLoad(139, GridusdtnotificationsdatasRow);
            }
            AV75GXV1 = (int)(AV75GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      protected void E17BI2( )
      {
         /* 'DoCreateEvent' Routine */
         returnInSub = false;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         AV16CalendarEvents = new WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item(context);
         AV16CalendarEvents.gxTpr_Allday = false;
         GXt_dtime5 = DateTimeUtil.ResetTime( AV18Date ) ;
         AV16CalendarEvents.gxTpr_Start = GXt_dtime5;
         AV16CalendarEvents.gxTpr_Start = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV16CalendarEvents.gxTpr_Start)), (short)(DateTimeUtil.Month( AV16CalendarEvents.gxTpr_Start)), (short)(DateTimeUtil.Day( AV16CalendarEvents.gxTpr_Start)), (short)(DateTimeUtil.Hour( DateTimeUtil.Now( context))+1), 0, 0);
         AV16CalendarEvents.gxTpr_End = DateTimeUtil.TAdd( AV16CalendarEvents.gxTpr_Start, 3600*(1));
         AV17CalendarEventsJson = AV16CalendarEvents.ToJSonString(false, true);
         AssignAttri("", false, "AV17CalendarEventsJson", AV17CalendarEventsJson);
         this.executeUsercontrolMethod("", false, "CREATEEVENT_MODALContainer", "Confirm", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void E14BI2( )
      {
         /* Createevent_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WorkWithPlus.WWP_EventInfoWC")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "workwithplus.wwp_eventinfowc", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WorkWithPlus.WWP_EventInfoWC";
            WebComp_Wwpaux_wc_Component = "WorkWithPlus.WWP_EventInfoWC";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0180",(string)"",(string)Gx_mode,(string)AV17CalendarEventsJson,(string)AV15CalendarEventId,(string)AV21DisabledDaysJson});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0180"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E16BI2( )
      {
         /* Sendmessage_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WC_NotificationPanel")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wc_notificationpanel", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WC_NotificationPanel";
            WebComp_Wwpaux_wc_Component = "WC_NotificationPanel";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0180",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0180"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E15BI2( )
      {
         /* Sendmessage_modal_Close Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25Events", AV25Events);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20DisabledDays", AV20DisabledDays);
      }

      protected void E23BI2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADCALENDAR' */
         S122 ();
         if (returnInSub) return;
         AV53LocationId = AV68WWPContext.gxTpr_Locationid;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25Events", AV25Events);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20DisabledDays", AV20DisabledDays);
      }

      protected void E24BI2( )
      {
         /* 'DoUserAction1' Routine */
         returnInSub = false;
         if ( 1 == 0 )
         {
         }
         else
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wwpaux_wc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WC_NotificationPanel")) != 0 )
            {
               WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wc_notificationpanel", new Object[] {context} );
               WebComp_Wwpaux_wc.ComponentInit();
               WebComp_Wwpaux_wc.Name = "WC_NotificationPanel";
               WebComp_Wwpaux_wc_Component = "WC_NotificationPanel";
            }
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.setjustcreated();
               WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0180",(string)""});
               WebComp_Wwpaux_wc.componentbind(new Object[] {});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0180"+"");
               WebComp_Wwpaux_wc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E13BI2( )
      {
         /* Createevent_modal_Close Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADCALENDAR' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25Events", AV25Events);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20DisabledDays", AV20DisabledDays);
      }

      protected void E12BI2( )
      {
         /* Usercontrol1_Eventselected Routine */
         returnInSub = false;
         CallWebObject(formatLink("wp_calendaragenda.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void E18BI2( )
      {
         /* Tablenotifications_Click Routine */
         returnInSub = false;
         CallWebObject(formatLink("wp_notificationdashboard.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void E19BI2( )
      {
         /* Tableagenda_Click Routine */
         returnInSub = false;
         CallWebObject(formatLink("wp_calendaragenda.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void E25BI2( )
      {
         AV75GXV1 = (int)(nGXsfl_139_idx+GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage);
         if ( ( AV75GXV1 > 0 ) && ( AV70USDTNotificationsData.Count >= AV75GXV1 ) )
         {
            AV70USDTNotificationsData.CurrentItem = ((SdtUSDTNotificationsData_USDTNotificationsDataItem)AV70USDTNotificationsData.Item(AV75GXV1));
         }
         /* Gridusdtnotificationsdatas_Onlineactivate Routine */
         returnInSub = false;
         AV52Link = formatLink(((SdtUSDTNotificationsData_USDTNotificationsDataItem)(AV70USDTNotificationsData.CurrentItem)).gxTpr_Notificationlink) ;
         CallWebObject(formatLink(AV52Link) );
         context.wjLocDisableFrm = 0;
         GXt_int6 = ((SdtUSDTNotificationsData_USDTNotificationsDataItem)(AV70USDTNotificationsData.CurrentItem)).gxTpr_Notificationid;
         new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_changenotificationstatus(context ).gxep_setnotificationreadbyid( ref  GXt_int6) ;
         ((SdtUSDTNotificationsData_USDTNotificationsDataItem)(AV70USDTNotificationsData.CurrentItem)).gxTpr_Notificationid = (int)(GXt_int6);
      }

      protected void E20BI2( )
      {
         AV75GXV1 = (int)(nGXsfl_139_idx+GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage);
         if ( ( AV75GXV1 > 0 ) && ( AV70USDTNotificationsData.Count >= AV75GXV1 ) )
         {
            AV70USDTNotificationsData.CurrentItem = ((SdtUSDTNotificationsData_USDTNotificationsDataItem)AV70USDTNotificationsData.Item(AV75GXV1));
         }
         /* Onmessage_gx1 Routine */
         returnInSub = false;
         if ( StringUtil.Contains( AV74NotificationInfo.gxTpr_Id, "WebNotification") )
         {
            /* Execute user subroutine: 'GETUNREADNOTIFICATIONS' */
            S112 ();
            if (returnInSub) return;
            context.DoAjaxRefresh();
            context.DoAjaxRefreshForm();
         }
         /*  Sending Event outputs  */
         if ( gx_BV139 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV70USDTNotificationsData", AV70USDTNotificationsData);
            nGXsfl_139_bak_idx = nGXsfl_139_idx;
            gxgrGridusdtnotificationsdatas_refresh( subGridusdtnotificationsdatas_Rows, AV68WWPContext, AV29ForceLoadDots, AV27EventsLoaded, AV5CalendarLoadFromDate, AV6CalendarLoadToDate, AV19Date_ShowingDatesFrom, AV10LoadedDotsFromDate, AV11LoadedDotsToDate, AV12LoadedFromDate, AV13LoadedToDate, AV25Events, AV70USDTNotificationsData, AV18Date, AV15CalendarEventId) ;
            nGXsfl_139_idx = nGXsfl_139_bak_idx;
            sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
            SubsflControlProps_1392( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25Events", AV25Events);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20DisabledDays", AV20DisabledDays);
      }

      protected void S112( )
      {
         /* 'GETUNREADNOTIFICATIONS' Routine */
         returnInSub = false;
         GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem7 = AV70USDTNotificationsData;
         new dp_getusernotifications(context ).execute(  "UnRead",  AV54NotificationDefinitionIdEmptyCollection,  "", out  GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem7) ;
         AV70USDTNotificationsData = GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem7;
         gx_BV139 = true;
         if ( AV70USDTNotificationsData.Count == 0 )
         {
            lblNotificationssubtitle_Caption = context.GetMessage( "WWP_Notifications_NoNewNotifications", "");
            AssignProp("", false, lblNotificationssubtitle_Internalname, "Caption", lblNotificationssubtitle_Caption, true);
         }
         else if ( AV70USDTNotificationsData.Count == 1 )
         {
            lblNotificationssubtitle_Caption = context.GetMessage( "WWP_Notifications_OneNewNotification", "");
            AssignProp("", false, lblNotificationssubtitle_Internalname, "Caption", lblNotificationssubtitle_Caption, true);
         }
         else
         {
            lblNotificationssubtitle_Caption = StringUtil.Format( context.GetMessage( "WWP_Notifications_NewNotifications", ""), StringUtil.Trim( StringUtil.Str( (decimal)(AV70USDTNotificationsData.Count), 9, 0)), "", "", "", "", "", "", "", "");
            AssignProp("", false, lblNotificationssubtitle_Internalname, "Caption", lblNotificationssubtitle_Caption, true);
         }
         GXt_int3 = (short)(AV51KPI5_Value);
         new prc_countlocationfilledforms(context ).execute( out  GXt_int3) ;
         AV51KPI5_Value = GXt_int3;
         AssignAttri("", false, "AV51KPI5_Value", StringUtil.LTrimStr( (decimal)(AV51KPI5_Value), 12, 0));
      }

      protected void S122( )
      {
         /* 'LOADCALENDAR' Routine */
         returnInSub = false;
         AV29ForceLoadDots = (bool)(AV29ForceLoadDots||(!AV27EventsLoaded));
         AssignAttri("", false, "AV29ForceLoadDots", AV29ForceLoadDots);
         AV27EventsLoaded = true;
         AssignAttri("", false, "AV27EventsLoaded", AV27EventsLoaded);
         AV12LoadedFromDate = AV5CalendarLoadFromDate;
         AssignAttri("", false, "AV12LoadedFromDate", context.localUtil.Format(AV12LoadedFromDate, "99/99/99"));
         AV13LoadedToDate = AV6CalendarLoadToDate;
         AssignAttri("", false, "AV13LoadedToDate", context.localUtil.Format(AV13LoadedToDate, "99/99/99"));
         GXt_objcol_SdtWWP_Calendar_Events_Item8 = AV25Events;
         GXt_dtime5 = DateTimeUtil.ResetTime( AV5CalendarLoadFromDate ) ;
         new GeneXus.Programs.workwithplus.wwp_calendar_getevents(context ).execute(  false,  "",  GXt_dtime5,  AV6CalendarLoadToDate, out  GXt_objcol_SdtWWP_Calendar_Events_Item8) ;
         AV25Events = GXt_objcol_SdtWWP_Calendar_Events_Item8;
         if ( AV29ForceLoadDots )
         {
            AV29ForceLoadDots = false;
            AssignAttri("", false, "AV29ForceLoadDots", AV29ForceLoadDots);
            AV10LoadedDotsFromDate = DateTime.MinValue;
            AssignAttri("", false, "AV10LoadedDotsFromDate", context.localUtil.Format(AV10LoadedDotsFromDate, "99/99/99"));
            AV11LoadedDotsToDate = DateTime.MinValue;
            AssignAttri("", false, "AV11LoadedDotsToDate", context.localUtil.Format(AV11LoadedDotsToDate, "99/99/99"));
            /* Execute user subroutine: 'LOAD DOTS' */
            S132 ();
            if (returnInSub) return;
         }
         GXt_objcol_date9 = AV20DisabledDays;
         new GeneXus.Programs.workwithplus.wwp_calendar_getdisableddays(context ).execute( out  GXt_objcol_date9) ;
         AV20DisabledDays = GXt_objcol_date9;
         AV21DisabledDaysJson = AV20DisabledDays.ToJSonString(false);
         AssignAttri("", false, "AV21DisabledDaysJson", AV21DisabledDaysJson);
      }

      protected void S132( )
      {
         /* 'LOAD DOTS' Routine */
         returnInSub = false;
         AV7DotsFromDate = DateTimeUtil.DAdd( AV19Date_ShowingDatesFrom, (7));
         AV7DotsFromDate = context.localUtil.YMDToD( DateTimeUtil.Year( AV7DotsFromDate), DateTimeUtil.Month( AV7DotsFromDate), 1);
         AV8DotsToDate = DateTimeUtil.AddMth( AV7DotsFromDate, 1);
         AV8DotsToDate = DateTimeUtil.DAdd( AV8DotsToDate, (-1));
         if ( ( DateTimeUtil.ResetTime ( AV7DotsFromDate ) < DateTimeUtil.ResetTime ( AV10LoadedDotsFromDate ) ) || ( DateTimeUtil.ResetTime ( AV8DotsToDate ) > DateTimeUtil.ResetTime ( AV11LoadedDotsToDate ) ) )
         {
            AV10LoadedDotsFromDate = AV7DotsFromDate;
            AssignAttri("", false, "AV10LoadedDotsFromDate", context.localUtil.Format(AV10LoadedDotsFromDate, "99/99/99"));
            AV11LoadedDotsToDate = AV8DotsToDate;
            AssignAttri("", false, "AV11LoadedDotsToDate", context.localUtil.Format(AV11LoadedDotsToDate, "99/99/99"));
            if ( ( DateTimeUtil.ResetTime ( AV7DotsFromDate ) < DateTimeUtil.ResetTime ( AV12LoadedFromDate ) ) || ( DateTimeUtil.ResetTime ( AV8DotsToDate ) > DateTimeUtil.ResetTime ( AV13LoadedToDate ) ) )
            {
               GXt_objcol_SdtWWP_Calendar_Events_Item8 = AV26EventsAux;
               GXt_dtime5 = DateTimeUtil.ResetTime( AV7DotsFromDate ) ;
               new GeneXus.Programs.workwithplus.wwp_calendar_getevents(context ).execute(  false,  "",  GXt_dtime5,  AV8DotsToDate, out  GXt_objcol_SdtWWP_Calendar_Events_Item8) ;
               AV26EventsAux = GXt_objcol_SdtWWP_Calendar_Events_Item8;
               GXt_SdtWWPDateRangePickerOptions10 = AV14WWPDateRangePickerOptions;
               new WorkWithPlus.workwithplus_web.wwp_geteventsforflatdate(context ).execute(  AV26EventsAux,  AV7DotsFromDate,  AV8DotsToDate,  Usercontrol1_Defaulteventstyle, out  GXt_SdtWWPDateRangePickerOptions10) ;
               AV14WWPDateRangePickerOptions = GXt_SdtWWPDateRangePickerOptions10;
               AV26EventsAux = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta_version2");
            }
            else
            {
               GXt_SdtWWPDateRangePickerOptions10 = AV14WWPDateRangePickerOptions;
               new WorkWithPlus.workwithplus_web.wwp_geteventsforflatdate(context ).execute(  AV25Events,  AV7DotsFromDate,  AV8DotsToDate,  Usercontrol1_Defaulteventstyle, out  GXt_SdtWWPDateRangePickerOptions10) ;
               AV14WWPDateRangePickerOptions = GXt_SdtWWPDateRangePickerOptions10;
            }
         }
      }

      protected void wb_table10_173_BI2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablesendmessage_modal_Internalname, tblTablesendmessage_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucSendmessage_modal.SetProperty("Width", Sendmessage_modal_Width);
            ucSendmessage_modal.SetProperty("Title", Sendmessage_modal_Title);
            ucSendmessage_modal.SetProperty("ConfirmType", Sendmessage_modal_Confirmtype);
            ucSendmessage_modal.SetProperty("BodyType", Sendmessage_modal_Bodytype);
            ucSendmessage_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Sendmessage_modal_Internalname, "SENDMESSAGE_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"SENDMESSAGE_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table10_173_BI2e( true) ;
         }
         else
         {
            wb_table10_173_BI2e( false) ;
         }
      }

      protected void wb_table9_168_BI2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablecreateevent_modal_Internalname, tblTablecreateevent_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucCreateevent_modal.SetProperty("Width", Createevent_modal_Width);
            ucCreateevent_modal.SetProperty("Title", Createevent_modal_Title);
            ucCreateevent_modal.SetProperty("ConfirmType", Createevent_modal_Confirmtype);
            ucCreateevent_modal.SetProperty("BodyType", Createevent_modal_Bodytype);
            ucCreateevent_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Createevent_modal_Internalname, "CREATEEVENT_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"CREATEEVENT_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table9_168_BI2e( true) ;
         }
         else
         {
            wb_table9_168_BI2e( false) ;
         }
      }

      protected void wb_table8_112_BI2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi5_moreinfoicon_Internalname, tblTablemergedkpi5_moreinfoicon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi5_moreinfoicon_Internalname, lblKpi5_moreinfoicon_Caption, "", "", lblKpi5_moreinfoicon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_ReceptionistDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center")+"\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi5_percentagevalue_Internalname, context.GetMessage( "KPI5_Percentage Value", ""), "gx-form-item DashboardPercentageSuccessLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi5_percentagevalue_Internalname, StringUtil.LTrim( StringUtil.NToC( AV50KPI5_PercentageValue, 5, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi5_percentagevalue_Enabled!=0) ? context.localUtil.Format( AV50KPI5_PercentageValue, "Z9%") : context.localUtil.Format( AV50KPI5_PercentageValue, "Z9%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi5_percentagevalue_Jsonclick, 0, edtavKpi5_percentagevalue_Class, "", "", "", "", 1, edtavKpi5_percentagevalue_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWPPercentage", "end", false, "", "HLP_WP_ReceptionistDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi5_moreinfocaption_Internalname, context.GetMessage( "From Last Month", ""), "", "", lblKpi5_moreinfocaption_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_WP_ReceptionistDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table8_112_BI2e( true) ;
         }
         else
         {
            wb_table8_112_BI2e( false) ;
         }
      }

      protected void wb_table7_100_BI2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi5_icon_Internalname, tblTablemergedkpi5_icon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi5_icon_Internalname, context.GetMessage( "<i class='ProgressCardIcon fas fa-file'></i>", ""), "", "", lblKpi5_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_ReceptionistDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi5_description_Internalname, context.GetMessage( "FILLED FORMS", ""), "", "", lblKpi5_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_WP_ReceptionistDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_100_BI2e( true) ;
         }
         else
         {
            wb_table7_100_BI2e( false) ;
         }
      }

      protected void wb_table6_84_BI2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi4_moreinfoicon_Internalname, tblTablemergedkpi4_moreinfoicon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi4_moreinfoicon_Internalname, lblKpi4_moreinfoicon_Caption, "", "", lblKpi4_moreinfoicon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_ReceptionistDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center")+"\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi4_percentagevalue_Internalname, context.GetMessage( "KPI4_Percentage Value", ""), "gx-form-item DashboardPercentageSuccessLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi4_percentagevalue_Internalname, StringUtil.LTrim( StringUtil.NToC( AV47KPI4_PercentageValue, 5, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi4_percentagevalue_Enabled!=0) ? context.localUtil.Format( AV47KPI4_PercentageValue, "Z9%") : context.localUtil.Format( AV47KPI4_PercentageValue, "Z9%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi4_percentagevalue_Jsonclick, 0, edtavKpi4_percentagevalue_Class, "", "", "", "", 1, edtavKpi4_percentagevalue_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWPPercentage", "end", false, "", "HLP_WP_ReceptionistDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi4_moreinfocaption_Internalname, context.GetMessage( "From Last Month", ""), "", "", lblKpi4_moreinfocaption_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_WP_ReceptionistDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_84_BI2e( true) ;
         }
         else
         {
            wb_table6_84_BI2e( false) ;
         }
      }

      protected void wb_table5_72_BI2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi4_icon_Internalname, tblTablemergedkpi4_icon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi4_icon_Internalname, context.GetMessage( "<i class='ProgressCardIcon fas fa-mobile-alt'></i>", ""), "", "", lblKpi4_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_ReceptionistDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi4_description_Internalname, context.GetMessage( "APPS PROVISIONED", ""), "", "", lblKpi4_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_WP_ReceptionistDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_72_BI2e( true) ;
         }
         else
         {
            wb_table5_72_BI2e( false) ;
         }
      }

      protected void wb_table4_56_BI2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi3_moreinfoicon_Internalname, tblTablemergedkpi3_moreinfoicon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi3_moreinfoicon_Internalname, lblKpi3_moreinfoicon_Caption, "", "", lblKpi3_moreinfoicon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_ReceptionistDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center")+"\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi3_percentagevalue_Internalname, context.GetMessage( "KPI3_Percentage Value", ""), "gx-form-item DashboardPercentageSuccessLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi3_percentagevalue_Internalname, StringUtil.LTrim( StringUtil.NToC( AV44KPI3_PercentageValue, 5, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi3_percentagevalue_Enabled!=0) ? context.localUtil.Format( AV44KPI3_PercentageValue, "Z9%") : context.localUtil.Format( AV44KPI3_PercentageValue, "Z9%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi3_percentagevalue_Jsonclick, 0, edtavKpi3_percentagevalue_Class, "", "", "", "", 1, edtavKpi3_percentagevalue_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWPPercentage", "end", false, "", "HLP_WP_ReceptionistDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi3_moreinfocaption_Internalname, context.GetMessage( "From Last Month", ""), "", "", lblKpi3_moreinfocaption_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_WP_ReceptionistDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_56_BI2e( true) ;
         }
         else
         {
            wb_table4_56_BI2e( false) ;
         }
      }

      protected void wb_table3_44_BI2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi3_icon_Internalname, tblTablemergedkpi3_icon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi3_icon_Internalname, context.GetMessage( "<i class='ProgressCardIcon fa fa-users'></i>", ""), "", "", lblKpi3_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_ReceptionistDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi3_description_Internalname, lblKpi3_description_Caption, "", "", lblKpi3_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_WP_ReceptionistDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_44_BI2e( true) ;
         }
         else
         {
            wb_table3_44_BI2e( false) ;
         }
      }

      protected void wb_table2_28_BI2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi2_moreinfoicon_Internalname, tblTablemergedkpi2_moreinfoicon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi2_moreinfoicon_Internalname, lblKpi2_moreinfoicon_Caption, "", "", lblKpi2_moreinfoicon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_ReceptionistDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center")+"\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavKpi2_percentagevalue_Internalname, context.GetMessage( "KPI2_Percentage Value", ""), "gx-form-item DashboardPercentageSuccessLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_139_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavKpi2_percentagevalue_Internalname, StringUtil.LTrim( StringUtil.NToC( AV41KPI2_PercentageValue, 5, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavKpi2_percentagevalue_Enabled!=0) ? context.localUtil.Format( AV41KPI2_PercentageValue, "Z9%") : context.localUtil.Format( AV41KPI2_PercentageValue, "Z9%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavKpi2_percentagevalue_Jsonclick, 0, edtavKpi2_percentagevalue_Class, "", "", "", "", 1, edtavKpi2_percentagevalue_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWPPercentage", "end", false, "", "HLP_WP_ReceptionistDashboard.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi2_moreinfocaption_Internalname, context.GetMessage( "From Last Month", ""), "", "", lblKpi2_moreinfocaption_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_WP_ReceptionistDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_28_BI2e( true) ;
         }
         else
         {
            wb_table2_28_BI2e( false) ;
         }
      }

      protected void wb_table1_16_BI2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedkpi2_icon_Internalname, tblTablemergedkpi2_icon_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi2_icon_Internalname, context.GetMessage( "<i class='ProgressCardIcon fas fa-shipping-fast'></i>", ""), "", "", lblKpi2_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WP_ReceptionistDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblKpi2_description_Internalname, context.GetMessage( "SUPPLIERS", ""), "", "", lblKpi2_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoCard", 0, "", 1, 1, 0, 0, "HLP_WP_ReceptionistDashboard.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_16_BI2e( true) ;
         }
         else
         {
            wb_table1_16_BI2e( false) ;
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
         PABI2( ) ;
         WSBI2( ) ;
         WEBI2( ) ;
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
         AddStyleSheetFile("DVelop/Calendar/FullCalendar.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256201715505", true, true);
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
         context.AddJavascriptSource("wp_receptionistdashboard.js", "?20256201715506", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Calendar/index.global.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Calendar/WWPCalendarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1392( )
      {
         edtavNotificationicon1_Internalname = "vNOTIFICATIONICON1_"+sGXsfl_139_idx;
         edtavUsdtnotificationsdata__notificationid_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONID_"+sGXsfl_139_idx;
         edtavUsdtnotificationsdata__notificationiconclass_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONICONCLASS_"+sGXsfl_139_idx;
         edtavUsdtnotificationsdata__notificationtitle_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONTITLE_"+sGXsfl_139_idx;
         edtavUsdtnotificationsdata__notificationdescription_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONDESCRIPTION_"+sGXsfl_139_idx;
         edtavUsdtnotificationsdata__notificationdatetime_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME_"+sGXsfl_139_idx;
         edtavUsdtnotificationsdata__notificationlink_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONLINK_"+sGXsfl_139_idx;
         edtavUsdtnotificationsdata__notificationdefinitionid_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONDEFINITIONID_"+sGXsfl_139_idx;
         chkavUsdtnotificationsdata__notificationisread_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONISREAD_"+sGXsfl_139_idx;
         edtavUsdtnotificationsdata__notificationmetadata_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONMETADATA_"+sGXsfl_139_idx;
      }

      protected void SubsflControlProps_fel_1392( )
      {
         edtavNotificationicon1_Internalname = "vNOTIFICATIONICON1_"+sGXsfl_139_fel_idx;
         edtavUsdtnotificationsdata__notificationid_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONID_"+sGXsfl_139_fel_idx;
         edtavUsdtnotificationsdata__notificationiconclass_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONICONCLASS_"+sGXsfl_139_fel_idx;
         edtavUsdtnotificationsdata__notificationtitle_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONTITLE_"+sGXsfl_139_fel_idx;
         edtavUsdtnotificationsdata__notificationdescription_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONDESCRIPTION_"+sGXsfl_139_fel_idx;
         edtavUsdtnotificationsdata__notificationdatetime_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME_"+sGXsfl_139_fel_idx;
         edtavUsdtnotificationsdata__notificationlink_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONLINK_"+sGXsfl_139_fel_idx;
         edtavUsdtnotificationsdata__notificationdefinitionid_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONDEFINITIONID_"+sGXsfl_139_fel_idx;
         chkavUsdtnotificationsdata__notificationisread_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONISREAD_"+sGXsfl_139_fel_idx;
         edtavUsdtnotificationsdata__notificationmetadata_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONMETADATA_"+sGXsfl_139_fel_idx;
      }

      protected void sendrow_1392( )
      {
         sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
         SubsflControlProps_1392( ) ;
         WBBI0( ) ;
         if ( ( subGridusdtnotificationsdatas_Rows * 1 == 0 ) || ( nGXsfl_139_idx <= subGridusdtnotificationsdatas_fnc_Recordsperpage( ) * 1 ) )
         {
            GridusdtnotificationsdatasRow = GXWebRow.GetNew(context,GridusdtnotificationsdatasContainer);
            if ( subGridusdtnotificationsdatas_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridusdtnotificationsdatas_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridusdtnotificationsdatas_Class, "") != 0 )
               {
                  subGridusdtnotificationsdatas_Linesclass = subGridusdtnotificationsdatas_Class+"Odd";
               }
            }
            else if ( subGridusdtnotificationsdatas_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridusdtnotificationsdatas_Backstyle = 0;
               subGridusdtnotificationsdatas_Backcolor = subGridusdtnotificationsdatas_Allbackcolor;
               if ( StringUtil.StrCmp(subGridusdtnotificationsdatas_Class, "") != 0 )
               {
                  subGridusdtnotificationsdatas_Linesclass = subGridusdtnotificationsdatas_Class+"Uniform";
               }
            }
            else if ( subGridusdtnotificationsdatas_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridusdtnotificationsdatas_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridusdtnotificationsdatas_Class, "") != 0 )
               {
                  subGridusdtnotificationsdatas_Linesclass = subGridusdtnotificationsdatas_Class+"Odd";
               }
               subGridusdtnotificationsdatas_Backcolor = (int)(0x0);
            }
            else if ( subGridusdtnotificationsdatas_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridusdtnotificationsdatas_Backstyle = 1;
               if ( ((int)((nGXsfl_139_idx) % (2))) == 0 )
               {
                  subGridusdtnotificationsdatas_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridusdtnotificationsdatas_Class, "") != 0 )
                  {
                     subGridusdtnotificationsdatas_Linesclass = subGridusdtnotificationsdatas_Class+"Even";
                  }
               }
               else
               {
                  subGridusdtnotificationsdatas_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridusdtnotificationsdatas_Class, "") != 0 )
                  {
                     subGridusdtnotificationsdatas_Linesclass = subGridusdtnotificationsdatas_Class+"Odd";
                  }
               }
            }
            if ( GridusdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWithSelection WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_139_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridusdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 140,'',false,'" + sGXsfl_139_idx + "',139)\"";
            ROClassString = "Attribute";
            GridusdtnotificationsdatasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationicon1_Internalname,(string)AV71NotificationIcon1,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,140);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNotificationicon1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavNotificationicon1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)edtavNotificationicon1_Format,(short)139,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridusdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridusdtnotificationsdatasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUsdtnotificationsdata__notificationid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtUSDTNotificationsData_USDTNotificationsDataItem)AV70USDTNotificationsData.Item(AV75GXV1)).gxTpr_Notificationid), 5, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavUsdtnotificationsdata__notificationid_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtUSDTNotificationsData_USDTNotificationsDataItem)AV70USDTNotificationsData.Item(AV75GXV1)).gxTpr_Notificationid), "ZZZZ9") : context.localUtil.Format( (decimal)(((SdtUSDTNotificationsData_USDTNotificationsDataItem)AV70USDTNotificationsData.Item(AV75GXV1)).gxTpr_Notificationid), "ZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUsdtnotificationsdata__notificationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavUsdtnotificationsdata__notificationid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridusdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridusdtnotificationsdatasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUsdtnotificationsdata__notificationiconclass_Internalname,((SdtUSDTNotificationsData_USDTNotificationsDataItem)AV70USDTNotificationsData.Item(AV75GXV1)).gxTpr_Notificationiconclass,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUsdtnotificationsdata__notificationiconclass_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavUsdtnotificationsdata__notificationiconclass_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridusdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'',false,'" + sGXsfl_139_idx + "',139)\"";
            ROClassString = "Attribute";
            GridusdtnotificationsdatasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUsdtnotificationsdata__notificationtitle_Internalname,((SdtUSDTNotificationsData_USDTNotificationsDataItem)AV70USDTNotificationsData.Item(AV75GXV1)).gxTpr_Notificationtitle,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,143);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUsdtnotificationsdata__notificationtitle_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavUsdtnotificationsdata__notificationtitle_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridusdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridusdtnotificationsdatasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUsdtnotificationsdata__notificationdescription_Internalname,((SdtUSDTNotificationsData_USDTNotificationsDataItem)AV70USDTNotificationsData.Item(AV75GXV1)).gxTpr_Notificationdescription,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUsdtnotificationsdata__notificationdescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavUsdtnotificationsdata__notificationdescription_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridusdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 145,'',false,'" + sGXsfl_139_idx + "',139)\"";
            ROClassString = "Attribute";
            GridusdtnotificationsdatasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUsdtnotificationsdata__notificationdatetime_Internalname,context.localUtil.TToC( ((SdtUSDTNotificationsData_USDTNotificationsDataItem)AV70USDTNotificationsData.Item(AV75GXV1)).gxTpr_Notificationdatetime, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( ((SdtUSDTNotificationsData_USDTNotificationsDataItem)AV70USDTNotificationsData.Item(AV75GXV1)).gxTpr_Notificationdatetime, "99/99/99 99:99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,145);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUsdtnotificationsdata__notificationdatetime_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavUsdtnotificationsdata__notificationdatetime_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridusdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridusdtnotificationsdatasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUsdtnotificationsdata__notificationlink_Internalname,((SdtUSDTNotificationsData_USDTNotificationsDataItem)AV70USDTNotificationsData.Item(AV75GXV1)).gxTpr_Notificationlink,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUsdtnotificationsdata__notificationlink_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavUsdtnotificationsdata__notificationlink_Enabled,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridusdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridusdtnotificationsdatasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUsdtnotificationsdata__notificationdefinitionid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtUSDTNotificationsData_USDTNotificationsDataItem)AV70USDTNotificationsData.Item(AV75GXV1)).gxTpr_Notificationdefinitionid), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavUsdtnotificationsdata__notificationdefinitionid_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtUSDTNotificationsData_USDTNotificationsDataItem)AV70USDTNotificationsData.Item(AV75GXV1)).gxTpr_Notificationdefinitionid), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(((SdtUSDTNotificationsData_USDTNotificationsDataItem)AV70USDTNotificationsData.Item(AV75GXV1)).gxTpr_Notificationdefinitionid), "ZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUsdtnotificationsdata__notificationdefinitionid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavUsdtnotificationsdata__notificationdefinitionid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridusdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "USDTNOTIFICATIONSDATA__NOTIFICATIONISREAD_" + sGXsfl_139_idx;
            chkavUsdtnotificationsdata__notificationisread.Name = GXCCtl;
            chkavUsdtnotificationsdata__notificationisread.WebTags = "";
            chkavUsdtnotificationsdata__notificationisread.Caption = "";
            AssignProp("", false, chkavUsdtnotificationsdata__notificationisread_Internalname, "TitleCaption", chkavUsdtnotificationsdata__notificationisread.Caption, !bGXsfl_139_Refreshing);
            chkavUsdtnotificationsdata__notificationisread.CheckedValue = "false";
            GridusdtnotificationsdatasRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavUsdtnotificationsdata__notificationisread_Internalname,StringUtil.BoolToStr( ((SdtUSDTNotificationsData_USDTNotificationsDataItem)AV70USDTNotificationsData.Item(AV75GXV1)).gxTpr_Notificationisread),(string)"",(string)"",(short)0,chkavUsdtnotificationsdata__notificationisread.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridusdtnotificationsdatasContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridusdtnotificationsdatasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUsdtnotificationsdata__notificationmetadata_Internalname,((SdtUSDTNotificationsData_USDTNotificationsDataItem)AV70USDTNotificationsData.Item(AV75GXV1)).gxTpr_Notificationmetadata,((SdtUSDTNotificationsData_USDTNotificationsDataItem)AV70USDTNotificationsData.Item(AV75GXV1)).gxTpr_Notificationmetadata,""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavUsdtnotificationsdata__notificationmetadata_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavUsdtnotificationsdata__notificationmetadata_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)139,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            send_integrity_lvl_hashesBI2( ) ;
            GridusdtnotificationsdatasContainer.AddRow(GridusdtnotificationsdatasRow);
            nGXsfl_139_idx = ((subGridusdtnotificationsdatas_Islastpage==1)&&(nGXsfl_139_idx+1>subGridusdtnotificationsdatas_fnc_Recordsperpage( )) ? 1 : nGXsfl_139_idx+1);
            sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
            SubsflControlProps_1392( ) ;
         }
         /* End function sendrow_1392 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "USDTNOTIFICATIONSDATA__NOTIFICATIONISREAD_" + sGXsfl_139_idx;
         chkavUsdtnotificationsdata__notificationisread.Name = GXCCtl;
         chkavUsdtnotificationsdata__notificationisread.WebTags = "";
         chkavUsdtnotificationsdata__notificationisread.Caption = "";
         AssignProp("", false, chkavUsdtnotificationsdata__notificationisread_Internalname, "TitleCaption", chkavUsdtnotificationsdata__notificationisread.Caption, !bGXsfl_139_Refreshing);
         chkavUsdtnotificationsdata__notificationisread.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl139( )
      {
         if ( GridusdtnotificationsdatasContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridusdtnotificationsdatasContainer"+"DivS\" data-gxgridid=\"139\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridusdtnotificationsdatas_Internalname, subGridusdtnotificationsdatas_Internalname, "", "WorkWithSelection WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridusdtnotificationsdatas_Backcolorstyle == 0 )
            {
               subGridusdtnotificationsdatas_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridusdtnotificationsdatas_Class) > 0 )
               {
                  subGridusdtnotificationsdatas_Linesclass = subGridusdtnotificationsdatas_Class+"Title";
               }
            }
            else
            {
               subGridusdtnotificationsdatas_Titlebackstyle = 1;
               if ( subGridusdtnotificationsdatas_Backcolorstyle == 1 )
               {
                  subGridusdtnotificationsdatas_Titlebackcolor = subGridusdtnotificationsdatas_Allbackcolor;
                  if ( StringUtil.Len( subGridusdtnotificationsdatas_Class) > 0 )
                  {
                     subGridusdtnotificationsdatas_Linesclass = subGridusdtnotificationsdatas_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridusdtnotificationsdatas_Class) > 0 )
                  {
                     subGridusdtnotificationsdatas_Linesclass = subGridusdtnotificationsdatas_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notification Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notification Icon Class", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notification Title", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notification Description", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notification Datetime", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notification Link", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notification Definition Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notification Is Read", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notification Metadata", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridusdtnotificationsdatasContainer.AddObjectProperty("GridName", "Gridusdtnotificationsdatas");
         }
         else
         {
            GridusdtnotificationsdatasContainer.AddObjectProperty("GridName", "Gridusdtnotificationsdatas");
            GridusdtnotificationsdatasContainer.AddObjectProperty("Header", subGridusdtnotificationsdatas_Header);
            GridusdtnotificationsdatasContainer.AddObjectProperty("Class", "WorkWithSelection WorkWith");
            GridusdtnotificationsdatasContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridusdtnotificationsdatasContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridusdtnotificationsdatasContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusdtnotificationsdatas_Backcolorstyle), 1, 0, ".", "")));
            GridusdtnotificationsdatasContainer.AddObjectProperty("CmpContext", "");
            GridusdtnotificationsdatasContainer.AddObjectProperty("InMasterPage", "false");
            GridusdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridusdtnotificationsdatasColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV71NotificationIcon1));
            GridusdtnotificationsdatasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNotificationicon1_Enabled), 5, 0, ".", "")));
            GridusdtnotificationsdatasColumn.AddObjectProperty("Format", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNotificationicon1_Format), 4, 0, ".", "")));
            GridusdtnotificationsdatasContainer.AddColumnProperties(GridusdtnotificationsdatasColumn);
            GridusdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridusdtnotificationsdatasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsdtnotificationsdata__notificationid_Enabled), 5, 0, ".", "")));
            GridusdtnotificationsdatasContainer.AddColumnProperties(GridusdtnotificationsdatasColumn);
            GridusdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridusdtnotificationsdatasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsdtnotificationsdata__notificationiconclass_Enabled), 5, 0, ".", "")));
            GridusdtnotificationsdatasContainer.AddColumnProperties(GridusdtnotificationsdatasColumn);
            GridusdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridusdtnotificationsdatasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsdtnotificationsdata__notificationtitle_Enabled), 5, 0, ".", "")));
            GridusdtnotificationsdatasContainer.AddColumnProperties(GridusdtnotificationsdatasColumn);
            GridusdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridusdtnotificationsdatasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsdtnotificationsdata__notificationdescription_Enabled), 5, 0, ".", "")));
            GridusdtnotificationsdatasContainer.AddColumnProperties(GridusdtnotificationsdatasColumn);
            GridusdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridusdtnotificationsdatasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsdtnotificationsdata__notificationdatetime_Enabled), 5, 0, ".", "")));
            GridusdtnotificationsdatasContainer.AddColumnProperties(GridusdtnotificationsdatasColumn);
            GridusdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridusdtnotificationsdatasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsdtnotificationsdata__notificationlink_Enabled), 5, 0, ".", "")));
            GridusdtnotificationsdatasContainer.AddColumnProperties(GridusdtnotificationsdatasColumn);
            GridusdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridusdtnotificationsdatasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsdtnotificationsdata__notificationdefinitionid_Enabled), 5, 0, ".", "")));
            GridusdtnotificationsdatasContainer.AddColumnProperties(GridusdtnotificationsdatasColumn);
            GridusdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridusdtnotificationsdatasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavUsdtnotificationsdata__notificationisread.Enabled), 5, 0, ".", "")));
            GridusdtnotificationsdatasContainer.AddColumnProperties(GridusdtnotificationsdatasColumn);
            GridusdtnotificationsdatasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridusdtnotificationsdatasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsdtnotificationsdata__notificationmetadata_Enabled), 5, 0, ".", "")));
            GridusdtnotificationsdatasContainer.AddColumnProperties(GridusdtnotificationsdatasColumn);
            GridusdtnotificationsdatasContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusdtnotificationsdatas_Selectedindex), 4, 0, ".", "")));
            GridusdtnotificationsdatasContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusdtnotificationsdatas_Allowselection), 1, 0, ".", "")));
            GridusdtnotificationsdatasContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusdtnotificationsdatas_Selectioncolor), 9, 0, ".", "")));
            GridusdtnotificationsdatasContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusdtnotificationsdatas_Allowhovering), 1, 0, ".", "")));
            GridusdtnotificationsdatasContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusdtnotificationsdatas_Hoveringcolor), 9, 0, ".", "")));
            GridusdtnotificationsdatasContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusdtnotificationsdatas_Allowcollapsing), 1, 0, ".", "")));
            GridusdtnotificationsdatasContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridusdtnotificationsdatas_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblKpi2_icon_Internalname = "KPI2_ICON";
         lblKpi2_description_Internalname = "KPI2_DESCRIPTION";
         tblTablemergedkpi2_icon_Internalname = "TABLEMERGEDKPI2_ICON";
         edtavKpi2_value_Internalname = "vKPI2_VALUE";
         lblKpi2_moreinfoicon_Internalname = "KPI2_MOREINFOICON";
         edtavKpi2_percentagevalue_Internalname = "vKPI2_PERCENTAGEVALUE";
         lblKpi2_moreinfocaption_Internalname = "KPI2_MOREINFOCAPTION";
         tblTablemergedkpi2_moreinfoicon_Internalname = "TABLEMERGEDKPI2_MOREINFOICON";
         lblViewdetailsuppliers_Internalname = "VIEWDETAILSUPPLIERS";
         divKpi2_maintable_Internalname = "KPI2_MAINTABLE";
         lblKpi3_icon_Internalname = "KPI3_ICON";
         lblKpi3_description_Internalname = "KPI3_DESCRIPTION";
         tblTablemergedkpi3_icon_Internalname = "TABLEMERGEDKPI3_ICON";
         edtavKpi3_value_Internalname = "vKPI3_VALUE";
         lblKpi3_moreinfoicon_Internalname = "KPI3_MOREINFOICON";
         edtavKpi3_percentagevalue_Internalname = "vKPI3_PERCENTAGEVALUE";
         lblKpi3_moreinfocaption_Internalname = "KPI3_MOREINFOCAPTION";
         tblTablemergedkpi3_moreinfoicon_Internalname = "TABLEMERGEDKPI3_MOREINFOICON";
         lblViewdetailsresidents_Internalname = "VIEWDETAILSRESIDENTS";
         divKpi3_maintable_Internalname = "KPI3_MAINTABLE";
         lblKpi4_icon_Internalname = "KPI4_ICON";
         lblKpi4_description_Internalname = "KPI4_DESCRIPTION";
         tblTablemergedkpi4_icon_Internalname = "TABLEMERGEDKPI4_ICON";
         edtavKpi4_value_Internalname = "vKPI4_VALUE";
         lblKpi4_moreinfoicon_Internalname = "KPI4_MOREINFOICON";
         edtavKpi4_percentagevalue_Internalname = "vKPI4_PERCENTAGEVALUE";
         lblKpi4_moreinfocaption_Internalname = "KPI4_MOREINFOCAPTION";
         tblTablemergedkpi4_moreinfoicon_Internalname = "TABLEMERGEDKPI4_MOREINFOICON";
         lblViewdetailsapp_Internalname = "VIEWDETAILSAPP";
         divKpi4_maintable_Internalname = "KPI4_MAINTABLE";
         lblKpi5_icon_Internalname = "KPI5_ICON";
         lblKpi5_description_Internalname = "KPI5_DESCRIPTION";
         tblTablemergedkpi5_icon_Internalname = "TABLEMERGEDKPI5_ICON";
         edtavKpi5_value_Internalname = "vKPI5_VALUE";
         lblKpi5_moreinfoicon_Internalname = "KPI5_MOREINFOICON";
         edtavKpi5_percentagevalue_Internalname = "vKPI5_PERCENTAGEVALUE";
         lblKpi5_moreinfocaption_Internalname = "KPI5_MOREINFOCAPTION";
         tblTablemergedkpi5_moreinfoicon_Internalname = "TABLEMERGEDKPI5_MOREINFOICON";
         lblViewdetailsfilledforms_Internalname = "VIEWDETAILSFILLEDFORMS";
         divKpi5_maintable_Internalname = "KPI5_MAINTABLE";
         divTablecards_Internalname = "TABLECARDS";
         Dvpanel_tablecards_Internalname = "DVPANEL_TABLECARDS";
         bttBtnsendmessage_Internalname = "BTNSENDMESSAGE";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         lblNotificationssubtitle_Internalname = "NOTIFICATIONSSUBTITLE";
         edtavNotificationicon1_Internalname = "vNOTIFICATIONICON1";
         edtavUsdtnotificationsdata__notificationid_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONID";
         edtavUsdtnotificationsdata__notificationiconclass_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONICONCLASS";
         edtavUsdtnotificationsdata__notificationtitle_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONTITLE";
         edtavUsdtnotificationsdata__notificationdescription_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONDESCRIPTION";
         edtavUsdtnotificationsdata__notificationdatetime_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME";
         edtavUsdtnotificationsdata__notificationlink_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONLINK";
         edtavUsdtnotificationsdata__notificationdefinitionid_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONDEFINITIONID";
         chkavUsdtnotificationsdata__notificationisread_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONISREAD";
         edtavUsdtnotificationsdata__notificationmetadata_Internalname = "USDTNOTIFICATIONSDATA__NOTIFICATIONMETADATA";
         divTablenotifications_Internalname = "TABLENOTIFICATIONS";
         Dvpanel_tablenotifications_Internalname = "DVPANEL_TABLENOTIFICATIONS";
         bttBtncreateevent_Internalname = "BTNCREATEEVENT";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Usercontrol1_Internalname = "USERCONTROL1";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         divTableagenda_Internalname = "TABLEAGENDA";
         Dvpanel_tableagenda_Internalname = "DVPANEL_TABLEAGENDA";
         divTablemain_Internalname = "TABLEMAIN";
         Createevent_modal_Internalname = "CREATEEVENT_MODAL";
         tblTablecreateevent_modal_Internalname = "TABLECREATEEVENT_MODAL";
         Sendmessage_modal_Internalname = "SENDMESSAGE_MODAL";
         tblTablesendmessage_modal_Internalname = "TABLESENDMESSAGE_MODAL";
         Gridusdtnotificationsdatas_empowerer_Internalname = "GRIDUSDTNOTIFICATIONSDATAS_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridusdtnotificationsdatas_Internalname = "GRIDUSDTNOTIFICATIONSDATAS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridusdtnotificationsdatas_Allowcollapsing = 0;
         subGridusdtnotificationsdatas_Allowhovering = -1;
         subGridusdtnotificationsdatas_Allowselection = 1;
         subGridusdtnotificationsdatas_Header = "";
         edtavUsdtnotificationsdata__notificationmetadata_Jsonclick = "";
         edtavUsdtnotificationsdata__notificationmetadata_Enabled = 0;
         chkavUsdtnotificationsdata__notificationisread.Caption = "";
         chkavUsdtnotificationsdata__notificationisread.Enabled = 0;
         edtavUsdtnotificationsdata__notificationdefinitionid_Jsonclick = "";
         edtavUsdtnotificationsdata__notificationdefinitionid_Enabled = 0;
         edtavUsdtnotificationsdata__notificationlink_Jsonclick = "";
         edtavUsdtnotificationsdata__notificationlink_Enabled = 0;
         edtavUsdtnotificationsdata__notificationdatetime_Jsonclick = "";
         edtavUsdtnotificationsdata__notificationdatetime_Enabled = 0;
         edtavUsdtnotificationsdata__notificationdescription_Jsonclick = "";
         edtavUsdtnotificationsdata__notificationdescription_Enabled = 0;
         edtavUsdtnotificationsdata__notificationtitle_Jsonclick = "";
         edtavUsdtnotificationsdata__notificationtitle_Enabled = 0;
         edtavUsdtnotificationsdata__notificationiconclass_Jsonclick = "";
         edtavUsdtnotificationsdata__notificationiconclass_Enabled = 0;
         edtavUsdtnotificationsdata__notificationid_Jsonclick = "";
         edtavUsdtnotificationsdata__notificationid_Enabled = 0;
         edtavNotificationicon1_Jsonclick = "";
         edtavNotificationicon1_Enabled = 0;
         edtavNotificationicon1_Format = 0;
         subGridusdtnotificationsdatas_Class = "WorkWithSelection WorkWith";
         subGridusdtnotificationsdatas_Backcolorstyle = 0;
         edtavKpi2_percentagevalue_Jsonclick = "";
         edtavKpi2_percentagevalue_Enabled = 1;
         edtavKpi3_percentagevalue_Jsonclick = "";
         edtavKpi3_percentagevalue_Enabled = 1;
         edtavKpi4_percentagevalue_Jsonclick = "";
         edtavKpi4_percentagevalue_Enabled = 1;
         edtavKpi5_percentagevalue_Jsonclick = "";
         edtavKpi5_percentagevalue_Enabled = 1;
         edtavKpi5_percentagevalue_Class = "DashboardPercentageSuccess";
         lblKpi5_moreinfoicon_Caption = context.GetMessage( "<i class='FontColorIconSuccess fas fa-caret-up' style='font-size: 12px'></i>", "");
         edtavKpi4_percentagevalue_Class = "DashboardPercentageSuccess";
         lblKpi4_moreinfoicon_Caption = context.GetMessage( "<i class='FontColorIconSuccess fas fa-caret-up' style='font-size: 12px'></i>", "");
         edtavKpi3_percentagevalue_Class = "DashboardPercentageSuccess";
         lblKpi3_moreinfoicon_Caption = context.GetMessage( "<i class='FontColorIconSuccess fas fa-caret-up' style='font-size: 12px'></i>", "");
         edtavKpi2_percentagevalue_Class = "DashboardPercentageSuccess";
         lblKpi2_moreinfoicon_Caption = context.GetMessage( "<i class='FontColorIconSuccess fas fa-caret-up' style='font-size: 12px'></i>", "");
         lblKpi3_description_Caption = context.GetMessage( "RESIDENTS", "");
         edtavUsdtnotificationsdata__notificationmetadata_Enabled = -1;
         chkavUsdtnotificationsdata__notificationisread.Enabled = -1;
         edtavUsdtnotificationsdata__notificationdefinitionid_Enabled = -1;
         edtavUsdtnotificationsdata__notificationlink_Enabled = -1;
         edtavUsdtnotificationsdata__notificationdatetime_Enabled = -1;
         edtavUsdtnotificationsdata__notificationdescription_Enabled = -1;
         edtavUsdtnotificationsdata__notificationtitle_Enabled = -1;
         edtavUsdtnotificationsdata__notificationiconclass_Enabled = -1;
         edtavUsdtnotificationsdata__notificationid_Enabled = -1;
         divTableagenda_Height = 0;
         divTablenotifications_Height = 0;
         lblViewdetailsfilledforms_Link = "";
         edtavKpi5_value_Jsonclick = "";
         edtavKpi5_value_Enabled = 1;
         lblViewdetailsapp_Link = "";
         edtavKpi4_value_Jsonclick = "";
         edtavKpi4_value_Enabled = 1;
         lblViewdetailsresidents_Link = "";
         edtavKpi3_value_Jsonclick = "";
         edtavKpi3_value_Enabled = 1;
         lblViewdetailsuppliers_Link = "";
         edtavKpi2_value_Jsonclick = "";
         edtavKpi2_value_Enabled = 1;
         lblNotificationssubtitle_Caption = context.GetMessage( "WWP_Notifications_NewNotifications", "");
         Usercontrol1_Defaulteventstyle = "Grayscale";
         Sendmessage_modal_Bodytype = "WebComponent";
         Sendmessage_modal_Confirmtype = "";
         Sendmessage_modal_Title = context.GetMessage( "Notification Details", "");
         Sendmessage_modal_Width = "800";
         Createevent_modal_Bodytype = "WebComponent";
         Createevent_modal_Confirmtype = "";
         Createevent_modal_Title = context.GetMessage( "Event", "");
         Createevent_modal_Width = "600";
         Dvpanel_tableagenda_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableagenda_Iconposition = "Right";
         Dvpanel_tableagenda_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableagenda_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableagenda_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableagenda_Title = context.GetMessage( "AGENDA", "");
         Dvpanel_tableagenda_Cls = "PanelWithBorder Panel_BaseColor";
         Dvpanel_tableagenda_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableagenda_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableagenda_Width = "100%";
         Usercontrol1_Daybuttontext = "Day";
         Usercontrol1_Todaybuttontext = "Today";
         Usercontrol1_Daybuttonposition = "None";
         Usercontrol1_Weekbuttonposition = "None";
         Usercontrol1_Monthbuttonposition = "None";
         Usercontrol1_Nextbuttonposition = "None";
         Usercontrol1_Previousbuttonposition = "None";
         Usercontrol1_Todaybuttonposition = "HeaderLeft";
         Usercontrol1_Navlinks = Convert.ToBoolean( -1);
         Usercontrol1_Viewstyle = "Standard";
         Usercontrol1_Initialview = "Day";
         Usercontrol1_Selectable = Convert.ToBoolean( -1);
         Dvpanel_tablenotifications_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Iconposition = "Right";
         Dvpanel_tablenotifications_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Title = context.GetMessage( "NOTIFICATIONS", "");
         Dvpanel_tablenotifications_Cls = "PanelWithBorder Panel_BaseColor";
         Dvpanel_tablenotifications_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablenotifications_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Width = "100%";
         Dvpanel_tablecards_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Iconposition = "Right";
         Dvpanel_tablecards_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tablecards_Title = "";
         Dvpanel_tablecards_Cls = "PanelNoHeader";
         Dvpanel_tablecards_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablecards_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "WP_Receptionist Dashboard", "");
         subGridusdtnotificationsdatas_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage"},{"av":"GRIDUSDTNOTIFICATIONSDATAS_nEOF"},{"av":"subGridusdtnotificationsdatas_Rows","ctrl":"GRIDUSDTNOTIFICATIONSDATAS","prop":"Rows"},{"av":"AV70USDTNotificationsData","fld":"vUSDTNOTIFICATIONSDATA","grid":139},{"av":"nGXsfl_139_idx","ctrl":"GRID","prop":"GridCurrRow","grid":139},{"av":"nRC_GXsfl_139","ctrl":"GRIDUSDTNOTIFICATIONSDATAS","prop":"GridRC","grid":139},{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV5CalendarLoadFromDate","fld":"vCALENDARLOADFROMDATE"},{"av":"AV6CalendarLoadToDate","fld":"vCALENDARLOADTODATE"},{"av":"AV10LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV11LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV12LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV13LoadedToDate","fld":"vLOADEDTODATE"},{"av":"Usercontrol1_Defaulteventstyle","ctrl":"USERCONTROL1","prop":"DefaultEventStyle"},{"av":"AV25Events","fld":"vEVENTS"},{"av":"AV18Date","fld":"vDATE","hsh":true},{"av":"AV15CalendarEventId","fld":"vCALENDAREVENTID","hsh":true},{"av":"AV68WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV19Date_ShowingDatesFrom","fld":"vDATE_SHOWINGDATESFROM","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV12LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV13LoadedToDate","fld":"vLOADEDTODATE"},{"av":"AV25Events","fld":"vEVENTS"},{"av":"AV10LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV11LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV20DisabledDays","fld":"vDISABLEDDAYS"},{"av":"AV21DisabledDaysJson","fld":"vDISABLEDDAYSJSON"}]}""");
         setEventMetadata("GRIDUSDTNOTIFICATIONSDATAS.LOAD","""{"handler":"E22BI2","iparms":[{"av":"AV70USDTNotificationsData","fld":"vUSDTNOTIFICATIONSDATA","grid":139},{"av":"nGXsfl_139_idx","ctrl":"GRID","prop":"GridCurrRow","grid":139},{"av":"GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_139","ctrl":"GRIDUSDTNOTIFICATIONSDATAS","prop":"GridRC","grid":139}]""");
         setEventMetadata("GRIDUSDTNOTIFICATIONSDATAS.LOAD",""","oparms":[{"av":"edtavNotificationicon1_Format","ctrl":"vNOTIFICATIONICON1","prop":"Format"},{"av":"AV71NotificationIcon1","fld":"vNOTIFICATIONICON1"}]}""");
         setEventMetadata("'DOCREATEEVENT'","""{"handler":"E17BI2","iparms":[{"av":"AV18Date","fld":"vDATE","hsh":true}]""");
         setEventMetadata("'DOCREATEEVENT'",""","oparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"AV17CalendarEventsJson","fld":"vCALENDAREVENTSJSON"}]}""");
         setEventMetadata("CREATEEVENT_MODAL.ONLOADCOMPONENT","""{"handler":"E14BI2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"AV17CalendarEventsJson","fld":"vCALENDAREVENTSJSON"},{"av":"AV15CalendarEventId","fld":"vCALENDAREVENTID","hsh":true},{"av":"AV21DisabledDaysJson","fld":"vDISABLEDDAYSJSON"}]""");
         setEventMetadata("CREATEEVENT_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("'DOSENDMESSAGE'","""{"handler":"E11BI1","iparms":[]}""");
         setEventMetadata("SENDMESSAGE_MODAL.ONLOADCOMPONENT","""{"handler":"E16BI2","iparms":[]""");
         setEventMetadata("SENDMESSAGE_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("SENDMESSAGE_MODAL.CLOSE","""{"handler":"E15BI2","iparms":[{"av":"GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage"},{"av":"GRIDUSDTNOTIFICATIONSDATAS_nEOF"},{"av":"subGridusdtnotificationsdatas_Rows","ctrl":"GRIDUSDTNOTIFICATIONSDATAS","prop":"Rows"},{"av":"AV68WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV5CalendarLoadFromDate","fld":"vCALENDARLOADFROMDATE"},{"av":"AV6CalendarLoadToDate","fld":"vCALENDARLOADTODATE"},{"av":"AV19Date_ShowingDatesFrom","fld":"vDATE_SHOWINGDATESFROM","hsh":true},{"av":"AV10LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV11LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV12LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV13LoadedToDate","fld":"vLOADEDTODATE"},{"av":"AV25Events","fld":"vEVENTS"},{"av":"AV70USDTNotificationsData","fld":"vUSDTNOTIFICATIONSDATA","grid":139},{"av":"nGXsfl_139_idx","ctrl":"GRID","prop":"GridCurrRow","grid":139},{"av":"nRC_GXsfl_139","ctrl":"GRIDUSDTNOTIFICATIONSDATAS","prop":"GridRC","grid":139},{"av":"AV18Date","fld":"vDATE","hsh":true},{"av":"AV15CalendarEventId","fld":"vCALENDAREVENTID","hsh":true},{"av":"Usercontrol1_Defaulteventstyle","ctrl":"USERCONTROL1","prop":"DefaultEventStyle"}]""");
         setEventMetadata("SENDMESSAGE_MODAL.CLOSE",""","oparms":[{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV12LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV13LoadedToDate","fld":"vLOADEDTODATE"},{"av":"AV25Events","fld":"vEVENTS"},{"av":"AV10LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV11LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV20DisabledDays","fld":"vDISABLEDDAYS"},{"av":"AV21DisabledDaysJson","fld":"vDISABLEDDAYSJSON"}]}""");
         setEventMetadata("'DOUSERACTION1'","""{"handler":"E24BI2","iparms":[]""");
         setEventMetadata("'DOUSERACTION1'",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("CREATEEVENT_MODAL.CLOSE","""{"handler":"E13BI2","iparms":[{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV5CalendarLoadFromDate","fld":"vCALENDARLOADFROMDATE"},{"av":"AV6CalendarLoadToDate","fld":"vCALENDARLOADTODATE"},{"av":"AV19Date_ShowingDatesFrom","fld":"vDATE_SHOWINGDATESFROM","hsh":true},{"av":"AV10LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV11LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV12LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV13LoadedToDate","fld":"vLOADEDTODATE"},{"av":"Usercontrol1_Defaulteventstyle","ctrl":"USERCONTROL1","prop":"DefaultEventStyle"},{"av":"AV25Events","fld":"vEVENTS"}]""");
         setEventMetadata("CREATEEVENT_MODAL.CLOSE",""","oparms":[{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV12LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV13LoadedToDate","fld":"vLOADEDTODATE"},{"av":"AV25Events","fld":"vEVENTS"},{"av":"AV10LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV11LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV20DisabledDays","fld":"vDISABLEDDAYS"},{"av":"AV21DisabledDaysJson","fld":"vDISABLEDDAYSJSON"}]}""");
         setEventMetadata("USERCONTROL1.EVENTSELECTED","""{"handler":"E12BI2","iparms":[]}""");
         setEventMetadata("TABLENOTIFICATIONS.CLICK","""{"handler":"E18BI2","iparms":[]}""");
         setEventMetadata("TABLEAGENDA.CLICK","""{"handler":"E19BI2","iparms":[]}""");
         setEventMetadata("GRIDUSDTNOTIFICATIONSDATAS.ONLINEACTIVATE","""{"handler":"E25BI2","iparms":[{"av":"AV70USDTNotificationsData","fld":"vUSDTNOTIFICATIONSDATA","grid":139},{"av":"nGXsfl_139_idx","ctrl":"GRID","prop":"GridCurrRow","grid":139},{"av":"GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_139","ctrl":"GRIDUSDTNOTIFICATIONSDATAS","prop":"GridRC","grid":139}]}""");
         setEventMetadata("ONMESSAGE_GX1","""{"handler":"E20BI2","iparms":[{"av":"GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage"},{"av":"GRIDUSDTNOTIFICATIONSDATAS_nEOF"},{"av":"subGridusdtnotificationsdatas_Rows","ctrl":"GRIDUSDTNOTIFICATIONSDATAS","prop":"Rows"},{"av":"AV68WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV5CalendarLoadFromDate","fld":"vCALENDARLOADFROMDATE"},{"av":"AV6CalendarLoadToDate","fld":"vCALENDARLOADTODATE"},{"av":"AV19Date_ShowingDatesFrom","fld":"vDATE_SHOWINGDATESFROM","hsh":true},{"av":"AV10LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV11LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV12LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV13LoadedToDate","fld":"vLOADEDTODATE"},{"av":"AV25Events","fld":"vEVENTS"},{"av":"AV70USDTNotificationsData","fld":"vUSDTNOTIFICATIONSDATA","grid":139},{"av":"nGXsfl_139_idx","ctrl":"GRID","prop":"GridCurrRow","grid":139},{"av":"nRC_GXsfl_139","ctrl":"GRIDUSDTNOTIFICATIONSDATAS","prop":"GridRC","grid":139},{"av":"AV18Date","fld":"vDATE","hsh":true},{"av":"AV15CalendarEventId","fld":"vCALENDAREVENTID","hsh":true},{"av":"AV74NotificationInfo","fld":"vNOTIFICATIONINFO"},{"av":"AV54NotificationDefinitionIdEmptyCollection","fld":"vNOTIFICATIONDEFINITIONIDEMPTYCOLLECTION"},{"av":"Usercontrol1_Defaulteventstyle","ctrl":"USERCONTROL1","prop":"DefaultEventStyle"}]""");
         setEventMetadata("ONMESSAGE_GX1",""","oparms":[{"av":"AV70USDTNotificationsData","fld":"vUSDTNOTIFICATIONSDATA","grid":139},{"av":"nGXsfl_139_idx","ctrl":"GRID","prop":"GridCurrRow","grid":139},{"av":"GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_139","ctrl":"GRIDUSDTNOTIFICATIONSDATAS","prop":"GridRC","grid":139},{"av":"lblNotificationssubtitle_Caption","ctrl":"NOTIFICATIONSSUBTITLE","prop":"Caption"},{"av":"AV51KPI5_Value","fld":"vKPI5_VALUE","pic":"ZZZ,ZZZ,ZZZ,ZZ9"},{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV12LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV13LoadedToDate","fld":"vLOADEDTODATE"},{"av":"AV25Events","fld":"vEVENTS"},{"av":"AV10LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV11LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV20DisabledDays","fld":"vDISABLEDDAYS"},{"av":"AV21DisabledDaysJson","fld":"vDISABLEDDAYSJSON"}]}""");
         setEventMetadata("GRIDUSDTNOTIFICATIONSDATAS_FIRSTPAGE","""{"handler":"subgridusdtnotificationsdatas_firstpage","iparms":[{"av":"GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage"},{"av":"GRIDUSDTNOTIFICATIONSDATAS_nEOF"},{"av":"subGridusdtnotificationsdatas_Rows","ctrl":"GRIDUSDTNOTIFICATIONSDATAS","prop":"Rows"},{"av":"AV70USDTNotificationsData","fld":"vUSDTNOTIFICATIONSDATA","grid":139},{"av":"nGXsfl_139_idx","ctrl":"GRID","prop":"GridCurrRow","grid":139},{"av":"nRC_GXsfl_139","ctrl":"GRIDUSDTNOTIFICATIONSDATAS","prop":"GridRC","grid":139},{"av":"AV18Date","fld":"vDATE","hsh":true},{"av":"AV15CalendarEventId","fld":"vCALENDAREVENTID","hsh":true},{"av":"AV68WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV5CalendarLoadFromDate","fld":"vCALENDARLOADFROMDATE"},{"av":"AV6CalendarLoadToDate","fld":"vCALENDARLOADTODATE"},{"av":"AV19Date_ShowingDatesFrom","fld":"vDATE_SHOWINGDATESFROM","hsh":true},{"av":"AV10LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV11LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV12LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV13LoadedToDate","fld":"vLOADEDTODATE"},{"av":"Usercontrol1_Defaulteventstyle","ctrl":"USERCONTROL1","prop":"DefaultEventStyle"},{"av":"AV25Events","fld":"vEVENTS"}]""");
         setEventMetadata("GRIDUSDTNOTIFICATIONSDATAS_FIRSTPAGE",""","oparms":[{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV12LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV13LoadedToDate","fld":"vLOADEDTODATE"},{"av":"AV25Events","fld":"vEVENTS"},{"av":"AV10LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV11LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV20DisabledDays","fld":"vDISABLEDDAYS"},{"av":"AV21DisabledDaysJson","fld":"vDISABLEDDAYSJSON"}]}""");
         setEventMetadata("GRIDUSDTNOTIFICATIONSDATAS_PREVPAGE","""{"handler":"subgridusdtnotificationsdatas_previouspage","iparms":[{"av":"GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage"},{"av":"GRIDUSDTNOTIFICATIONSDATAS_nEOF"},{"av":"subGridusdtnotificationsdatas_Rows","ctrl":"GRIDUSDTNOTIFICATIONSDATAS","prop":"Rows"},{"av":"AV70USDTNotificationsData","fld":"vUSDTNOTIFICATIONSDATA","grid":139},{"av":"nGXsfl_139_idx","ctrl":"GRID","prop":"GridCurrRow","grid":139},{"av":"nRC_GXsfl_139","ctrl":"GRIDUSDTNOTIFICATIONSDATAS","prop":"GridRC","grid":139},{"av":"AV18Date","fld":"vDATE","hsh":true},{"av":"AV15CalendarEventId","fld":"vCALENDAREVENTID","hsh":true},{"av":"AV68WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV5CalendarLoadFromDate","fld":"vCALENDARLOADFROMDATE"},{"av":"AV6CalendarLoadToDate","fld":"vCALENDARLOADTODATE"},{"av":"AV19Date_ShowingDatesFrom","fld":"vDATE_SHOWINGDATESFROM","hsh":true},{"av":"AV10LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV11LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV12LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV13LoadedToDate","fld":"vLOADEDTODATE"},{"av":"Usercontrol1_Defaulteventstyle","ctrl":"USERCONTROL1","prop":"DefaultEventStyle"},{"av":"AV25Events","fld":"vEVENTS"}]""");
         setEventMetadata("GRIDUSDTNOTIFICATIONSDATAS_PREVPAGE",""","oparms":[{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV12LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV13LoadedToDate","fld":"vLOADEDTODATE"},{"av":"AV25Events","fld":"vEVENTS"},{"av":"AV10LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV11LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV20DisabledDays","fld":"vDISABLEDDAYS"},{"av":"AV21DisabledDaysJson","fld":"vDISABLEDDAYSJSON"}]}""");
         setEventMetadata("GRIDUSDTNOTIFICATIONSDATAS_NEXTPAGE","""{"handler":"subgridusdtnotificationsdatas_nextpage","iparms":[{"av":"GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage"},{"av":"GRIDUSDTNOTIFICATIONSDATAS_nEOF"},{"av":"subGridusdtnotificationsdatas_Rows","ctrl":"GRIDUSDTNOTIFICATIONSDATAS","prop":"Rows"},{"av":"AV70USDTNotificationsData","fld":"vUSDTNOTIFICATIONSDATA","grid":139},{"av":"nGXsfl_139_idx","ctrl":"GRID","prop":"GridCurrRow","grid":139},{"av":"nRC_GXsfl_139","ctrl":"GRIDUSDTNOTIFICATIONSDATAS","prop":"GridRC","grid":139},{"av":"AV18Date","fld":"vDATE","hsh":true},{"av":"AV15CalendarEventId","fld":"vCALENDAREVENTID","hsh":true},{"av":"AV68WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV5CalendarLoadFromDate","fld":"vCALENDARLOADFROMDATE"},{"av":"AV6CalendarLoadToDate","fld":"vCALENDARLOADTODATE"},{"av":"AV19Date_ShowingDatesFrom","fld":"vDATE_SHOWINGDATESFROM","hsh":true},{"av":"AV10LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV11LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV12LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV13LoadedToDate","fld":"vLOADEDTODATE"},{"av":"Usercontrol1_Defaulteventstyle","ctrl":"USERCONTROL1","prop":"DefaultEventStyle"},{"av":"AV25Events","fld":"vEVENTS"}]""");
         setEventMetadata("GRIDUSDTNOTIFICATIONSDATAS_NEXTPAGE",""","oparms":[{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV12LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV13LoadedToDate","fld":"vLOADEDTODATE"},{"av":"AV25Events","fld":"vEVENTS"},{"av":"AV10LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV11LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV20DisabledDays","fld":"vDISABLEDDAYS"},{"av":"AV21DisabledDaysJson","fld":"vDISABLEDDAYSJSON"}]}""");
         setEventMetadata("GRIDUSDTNOTIFICATIONSDATAS_LASTPAGE","""{"handler":"subgridusdtnotificationsdatas_lastpage","iparms":[{"av":"GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage"},{"av":"GRIDUSDTNOTIFICATIONSDATAS_nEOF"},{"av":"subGridusdtnotificationsdatas_Rows","ctrl":"GRIDUSDTNOTIFICATIONSDATAS","prop":"Rows"},{"av":"AV70USDTNotificationsData","fld":"vUSDTNOTIFICATIONSDATA","grid":139},{"av":"nGXsfl_139_idx","ctrl":"GRID","prop":"GridCurrRow","grid":139},{"av":"nRC_GXsfl_139","ctrl":"GRIDUSDTNOTIFICATIONSDATAS","prop":"GridRC","grid":139},{"av":"AV18Date","fld":"vDATE","hsh":true},{"av":"AV15CalendarEventId","fld":"vCALENDAREVENTID","hsh":true},{"av":"AV68WWPContext","fld":"vWWPCONTEXT","hsh":true},{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV5CalendarLoadFromDate","fld":"vCALENDARLOADFROMDATE"},{"av":"AV6CalendarLoadToDate","fld":"vCALENDARLOADTODATE"},{"av":"AV19Date_ShowingDatesFrom","fld":"vDATE_SHOWINGDATESFROM","hsh":true},{"av":"AV10LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV11LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV12LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV13LoadedToDate","fld":"vLOADEDTODATE"},{"av":"Usercontrol1_Defaulteventstyle","ctrl":"USERCONTROL1","prop":"DefaultEventStyle"},{"av":"AV25Events","fld":"vEVENTS"}]""");
         setEventMetadata("GRIDUSDTNOTIFICATIONSDATAS_LASTPAGE",""","oparms":[{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV12LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV13LoadedToDate","fld":"vLOADEDTODATE"},{"av":"AV25Events","fld":"vEVENTS"},{"av":"AV10LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV11LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV20DisabledDays","fld":"vDISABLEDDAYS"},{"av":"AV21DisabledDaysJson","fld":"vDISABLEDDAYSJSON"}]}""");
         setEventMetadata("VALIDV_GXV7","""{"handler":"Validv_Gxv7","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gxv10","iparms":[]}""");
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
         AV68WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV5CalendarLoadFromDate = DateTime.MinValue;
         AV6CalendarLoadToDate = DateTime.MinValue;
         AV19Date_ShowingDatesFrom = DateTime.MinValue;
         AV10LoadedDotsFromDate = DateTime.MinValue;
         AV11LoadedDotsToDate = DateTime.MinValue;
         AV12LoadedFromDate = DateTime.MinValue;
         AV13LoadedToDate = DateTime.MinValue;
         AV25Events = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta_version2");
         AV70USDTNotificationsData = new GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem>( context, "USDTNotificationsDataItem", "Comforta_version2");
         AV18Date = DateTime.MinValue;
         AV15CalendarEventId = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV20DisabledDays = new GxSimpleCollection<DateTime>();
         Gx_mode = "";
         AV17CalendarEventsJson = "";
         AV21DisabledDaysJson = "";
         AV74NotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         AV54NotificationDefinitionIdEmptyCollection = new GxSimpleCollection<long>();
         Gridusdtnotificationsdatas_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_tablecards = new GXUserControl();
         TempTags = "";
         lblViewdetailsuppliers_Jsonclick = "";
         lblViewdetailsresidents_Jsonclick = "";
         lblViewdetailsapp_Jsonclick = "";
         lblViewdetailsfilledforms_Jsonclick = "";
         ucDvpanel_tablenotifications = new GXUserControl();
         ClassString = "";
         StyleString = "";
         bttBtnsendmessage_Jsonclick = "";
         lblNotificationssubtitle_Jsonclick = "";
         GridusdtnotificationsdatasContainer = new GXWebGrid( context);
         sStyleString = "";
         ucDvpanel_tableagenda = new GXUserControl();
         bttBtncreateevent_Jsonclick = "";
         ucUsercontrol1 = new GXUserControl();
         ucGridusdtnotificationsdatas_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV71NotificationIcon1 = "";
         AV53LocationId = Guid.Empty;
         AV73ResidentTitle = "";
         GXt_char2 = "";
         AV9HomeSampleData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtHomeSampleData_HomeSampleDataItem>( context, "HomeSampleDataItem", "Comforta_version2");
         GXt_objcol_SdtHomeSampleData_HomeSampleDataItem4 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtHomeSampleData_HomeSampleDataItem>( context, "HomeSampleDataItem", "Comforta_version2");
         GridusdtnotificationsdatasRow = new GXWebRow();
         AV16CalendarEvents = new WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item(context);
         AV52Link = "";
         GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem7 = new GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem>( context, "USDTNotificationsDataItem", "Comforta_version2");
         GXt_objcol_date9 = new GxSimpleCollection<DateTime>();
         AV7DotsFromDate = DateTime.MinValue;
         AV8DotsToDate = DateTime.MinValue;
         AV26EventsAux = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta_version2");
         GXt_objcol_SdtWWP_Calendar_Events_Item8 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta_version2");
         GXt_dtime5 = (DateTime)(DateTime.MinValue);
         AV14WWPDateRangePickerOptions = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions(context);
         GXt_SdtWWPDateRangePickerOptions10 = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions(context);
         ucSendmessage_modal = new GXUserControl();
         ucCreateevent_modal = new GXUserControl();
         lblKpi5_moreinfoicon_Jsonclick = "";
         lblKpi5_moreinfocaption_Jsonclick = "";
         lblKpi5_icon_Jsonclick = "";
         lblKpi5_description_Jsonclick = "";
         lblKpi4_moreinfoicon_Jsonclick = "";
         lblKpi4_moreinfocaption_Jsonclick = "";
         lblKpi4_icon_Jsonclick = "";
         lblKpi4_description_Jsonclick = "";
         lblKpi3_moreinfoicon_Jsonclick = "";
         lblKpi3_moreinfocaption_Jsonclick = "";
         lblKpi3_icon_Jsonclick = "";
         lblKpi3_description_Jsonclick = "";
         lblKpi2_moreinfoicon_Jsonclick = "";
         lblKpi2_moreinfocaption_Jsonclick = "";
         lblKpi2_icon_Jsonclick = "";
         lblKpi2_description_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridusdtnotificationsdatas_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridusdtnotificationsdatasColumn = new GXWebColumn();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         edtavKpi2_value_Enabled = 0;
         edtavKpi2_percentagevalue_Enabled = 0;
         edtavKpi3_value_Enabled = 0;
         edtavKpi3_percentagevalue_Enabled = 0;
         edtavKpi4_value_Enabled = 0;
         edtavKpi4_percentagevalue_Enabled = 0;
         edtavKpi5_value_Enabled = 0;
         edtavKpi5_percentagevalue_Enabled = 0;
         edtavNotificationicon1_Enabled = 0;
         edtavUsdtnotificationsdata__notificationid_Enabled = 0;
         edtavUsdtnotificationsdata__notificationiconclass_Enabled = 0;
         edtavUsdtnotificationsdata__notificationtitle_Enabled = 0;
         edtavUsdtnotificationsdata__notificationdescription_Enabled = 0;
         edtavUsdtnotificationsdata__notificationdatetime_Enabled = 0;
         edtavUsdtnotificationsdata__notificationlink_Enabled = 0;
         edtavUsdtnotificationsdata__notificationdefinitionid_Enabled = 0;
         chkavUsdtnotificationsdata__notificationisread.Enabled = 0;
         edtavUsdtnotificationsdata__notificationmetadata_Enabled = 0;
      }

      private short GRIDUSDTNOTIFICATIONSDATAS_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGridusdtnotificationsdatas_Backcolorstyle ;
      private short AV59Progress1_Value ;
      private short AV58Progress1_TotalValue ;
      private short AV61Progress2_Value ;
      private short AV60Progress2_TotalValue ;
      private short AV63Progress3_Value ;
      private short AV62Progress3_TotalValue ;
      private short AV65Progress4_Value ;
      private short AV64Progress4_TotalValue ;
      private short edtavNotificationicon1_Format ;
      private short GXt_int3 ;
      private short nGXWrapped ;
      private short subGridusdtnotificationsdatas_Backstyle ;
      private short subGridusdtnotificationsdatas_Titlebackstyle ;
      private short subGridusdtnotificationsdatas_Allowselection ;
      private short subGridusdtnotificationsdatas_Allowhovering ;
      private short subGridusdtnotificationsdatas_Allowcollapsing ;
      private short subGridusdtnotificationsdatas_Collapsed ;
      private int nRC_GXsfl_139 ;
      private int subGridusdtnotificationsdatas_Rows ;
      private int nGXsfl_139_idx=1 ;
      private int edtavKpi2_value_Enabled ;
      private int edtavKpi3_value_Enabled ;
      private int edtavKpi4_value_Enabled ;
      private int edtavKpi5_value_Enabled ;
      private int divTablenotifications_Height ;
      private int AV75GXV1 ;
      private int divTableagenda_Height ;
      private int subGridusdtnotificationsdatas_Islastpage ;
      private int edtavKpi2_percentagevalue_Enabled ;
      private int edtavKpi3_percentagevalue_Enabled ;
      private int edtavKpi4_percentagevalue_Enabled ;
      private int edtavKpi5_percentagevalue_Enabled ;
      private int edtavNotificationicon1_Enabled ;
      private int edtavUsdtnotificationsdata__notificationid_Enabled ;
      private int edtavUsdtnotificationsdata__notificationiconclass_Enabled ;
      private int edtavUsdtnotificationsdata__notificationtitle_Enabled ;
      private int edtavUsdtnotificationsdata__notificationdescription_Enabled ;
      private int edtavUsdtnotificationsdata__notificationdatetime_Enabled ;
      private int edtavUsdtnotificationsdata__notificationlink_Enabled ;
      private int edtavUsdtnotificationsdata__notificationdefinitionid_Enabled ;
      private int edtavUsdtnotificationsdata__notificationmetadata_Enabled ;
      private int GRIDUSDTNOTIFICATIONSDATAS_nGridOutOfScope ;
      private int nGXsfl_139_fel_idx=1 ;
      private int nGXsfl_139_bak_idx=1 ;
      private int idxLst ;
      private int subGridusdtnotificationsdatas_Backcolor ;
      private int subGridusdtnotificationsdatas_Allbackcolor ;
      private int subGridusdtnotificationsdatas_Titlebackcolor ;
      private int subGridusdtnotificationsdatas_Selectedindex ;
      private int subGridusdtnotificationsdatas_Selectioncolor ;
      private int subGridusdtnotificationsdatas_Hoveringcolor ;
      private long GRIDUSDTNOTIFICATIONSDATAS_nFirstRecordOnPage ;
      private long AV42KPI2_Value ;
      private long AV45KPI3_Value ;
      private long AV48KPI4_Value ;
      private long AV51KPI5_Value ;
      private long GRIDUSDTNOTIFICATIONSDATAS_nCurrentRecord ;
      private long GRIDUSDTNOTIFICATIONSDATAS_nRecordCount ;
      private long GXt_int6 ;
      private decimal AV41KPI2_PercentageValue ;
      private decimal AV44KPI3_PercentageValue ;
      private decimal AV47KPI4_PercentageValue ;
      private decimal AV50KPI5_PercentageValue ;
      private decimal AV38KPI1_PercentageValue ;
      private string Usercontrol1_Defaulteventstyle ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_139_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Gx_mode ;
      private string Dvpanel_tablecards_Width ;
      private string Dvpanel_tablecards_Cls ;
      private string Dvpanel_tablecards_Title ;
      private string Dvpanel_tablecards_Iconposition ;
      private string Dvpanel_tablenotifications_Width ;
      private string Dvpanel_tablenotifications_Cls ;
      private string Dvpanel_tablenotifications_Title ;
      private string Dvpanel_tablenotifications_Iconposition ;
      private string Usercontrol1_Initialview ;
      private string Usercontrol1_Viewstyle ;
      private string Usercontrol1_Todaybuttonposition ;
      private string Usercontrol1_Previousbuttonposition ;
      private string Usercontrol1_Nextbuttonposition ;
      private string Usercontrol1_Monthbuttonposition ;
      private string Usercontrol1_Weekbuttonposition ;
      private string Usercontrol1_Daybuttonposition ;
      private string Usercontrol1_Todaybuttontext ;
      private string Usercontrol1_Daybuttontext ;
      private string Dvpanel_tableagenda_Width ;
      private string Dvpanel_tableagenda_Cls ;
      private string Dvpanel_tableagenda_Title ;
      private string Dvpanel_tableagenda_Iconposition ;
      private string Createevent_modal_Width ;
      private string Createevent_modal_Title ;
      private string Createevent_modal_Confirmtype ;
      private string Createevent_modal_Bodytype ;
      private string Sendmessage_modal_Width ;
      private string Sendmessage_modal_Title ;
      private string Sendmessage_modal_Confirmtype ;
      private string Sendmessage_modal_Bodytype ;
      private string Gridusdtnotificationsdatas_empowerer_Gridinternalname ;
      private string lblNotificationssubtitle_Caption ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tablecards_Internalname ;
      private string divTablecards_Internalname ;
      private string divKpi2_maintable_Internalname ;
      private string edtavKpi2_value_Internalname ;
      private string TempTags ;
      private string edtavKpi2_value_Jsonclick ;
      private string lblViewdetailsuppliers_Internalname ;
      private string lblViewdetailsuppliers_Link ;
      private string lblViewdetailsuppliers_Jsonclick ;
      private string divKpi3_maintable_Internalname ;
      private string edtavKpi3_value_Internalname ;
      private string edtavKpi3_value_Jsonclick ;
      private string lblViewdetailsresidents_Internalname ;
      private string lblViewdetailsresidents_Link ;
      private string lblViewdetailsresidents_Jsonclick ;
      private string divKpi4_maintable_Internalname ;
      private string edtavKpi4_value_Internalname ;
      private string edtavKpi4_value_Jsonclick ;
      private string lblViewdetailsapp_Internalname ;
      private string lblViewdetailsapp_Link ;
      private string lblViewdetailsapp_Jsonclick ;
      private string divKpi5_maintable_Internalname ;
      private string edtavKpi5_value_Internalname ;
      private string edtavKpi5_value_Jsonclick ;
      private string lblViewdetailsfilledforms_Internalname ;
      private string lblViewdetailsfilledforms_Link ;
      private string lblViewdetailsfilledforms_Jsonclick ;
      private string Dvpanel_tablenotifications_Internalname ;
      private string divTablenotifications_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnsendmessage_Internalname ;
      private string bttBtnsendmessage_Jsonclick ;
      private string lblNotificationssubtitle_Internalname ;
      private string lblNotificationssubtitle_Jsonclick ;
      private string sStyleString ;
      private string subGridusdtnotificationsdatas_Internalname ;
      private string Dvpanel_tableagenda_Internalname ;
      private string divTableagenda_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string bttBtncreateevent_Internalname ;
      private string bttBtncreateevent_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string Usercontrol1_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Gridusdtnotificationsdatas_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavNotificationicon1_Internalname ;
      private string edtavKpi2_percentagevalue_Internalname ;
      private string edtavKpi3_percentagevalue_Internalname ;
      private string edtavKpi4_percentagevalue_Internalname ;
      private string edtavKpi5_percentagevalue_Internalname ;
      private string sGXsfl_139_fel_idx="0001" ;
      private string GXt_char2 ;
      private string lblKpi3_description_Caption ;
      private string lblKpi3_description_Internalname ;
      private string lblKpi2_moreinfoicon_Caption ;
      private string lblKpi2_moreinfoicon_Internalname ;
      private string edtavKpi2_percentagevalue_Class ;
      private string lblKpi3_moreinfoicon_Caption ;
      private string lblKpi3_moreinfoicon_Internalname ;
      private string edtavKpi3_percentagevalue_Class ;
      private string lblKpi4_moreinfoicon_Caption ;
      private string lblKpi4_moreinfoicon_Internalname ;
      private string edtavKpi4_percentagevalue_Class ;
      private string lblKpi5_moreinfoicon_Caption ;
      private string lblKpi5_moreinfoicon_Internalname ;
      private string edtavKpi5_percentagevalue_Class ;
      private string tblTablesendmessage_modal_Internalname ;
      private string Sendmessage_modal_Internalname ;
      private string tblTablecreateevent_modal_Internalname ;
      private string Createevent_modal_Internalname ;
      private string tblTablemergedkpi5_moreinfoicon_Internalname ;
      private string lblKpi5_moreinfoicon_Jsonclick ;
      private string edtavKpi5_percentagevalue_Jsonclick ;
      private string lblKpi5_moreinfocaption_Internalname ;
      private string lblKpi5_moreinfocaption_Jsonclick ;
      private string tblTablemergedkpi5_icon_Internalname ;
      private string lblKpi5_icon_Internalname ;
      private string lblKpi5_icon_Jsonclick ;
      private string lblKpi5_description_Internalname ;
      private string lblKpi5_description_Jsonclick ;
      private string tblTablemergedkpi4_moreinfoicon_Internalname ;
      private string lblKpi4_moreinfoicon_Jsonclick ;
      private string edtavKpi4_percentagevalue_Jsonclick ;
      private string lblKpi4_moreinfocaption_Internalname ;
      private string lblKpi4_moreinfocaption_Jsonclick ;
      private string tblTablemergedkpi4_icon_Internalname ;
      private string lblKpi4_icon_Internalname ;
      private string lblKpi4_icon_Jsonclick ;
      private string lblKpi4_description_Internalname ;
      private string lblKpi4_description_Jsonclick ;
      private string tblTablemergedkpi3_moreinfoicon_Internalname ;
      private string lblKpi3_moreinfoicon_Jsonclick ;
      private string edtavKpi3_percentagevalue_Jsonclick ;
      private string lblKpi3_moreinfocaption_Internalname ;
      private string lblKpi3_moreinfocaption_Jsonclick ;
      private string tblTablemergedkpi3_icon_Internalname ;
      private string lblKpi3_icon_Internalname ;
      private string lblKpi3_icon_Jsonclick ;
      private string lblKpi3_description_Jsonclick ;
      private string tblTablemergedkpi2_moreinfoicon_Internalname ;
      private string lblKpi2_moreinfoicon_Jsonclick ;
      private string edtavKpi2_percentagevalue_Jsonclick ;
      private string lblKpi2_moreinfocaption_Internalname ;
      private string lblKpi2_moreinfocaption_Jsonclick ;
      private string tblTablemergedkpi2_icon_Internalname ;
      private string lblKpi2_icon_Internalname ;
      private string lblKpi2_icon_Jsonclick ;
      private string lblKpi2_description_Internalname ;
      private string lblKpi2_description_Jsonclick ;
      private string edtavUsdtnotificationsdata__notificationid_Internalname ;
      private string edtavUsdtnotificationsdata__notificationiconclass_Internalname ;
      private string edtavUsdtnotificationsdata__notificationtitle_Internalname ;
      private string edtavUsdtnotificationsdata__notificationdescription_Internalname ;
      private string edtavUsdtnotificationsdata__notificationdatetime_Internalname ;
      private string edtavUsdtnotificationsdata__notificationlink_Internalname ;
      private string edtavUsdtnotificationsdata__notificationdefinitionid_Internalname ;
      private string chkavUsdtnotificationsdata__notificationisread_Internalname ;
      private string edtavUsdtnotificationsdata__notificationmetadata_Internalname ;
      private string subGridusdtnotificationsdatas_Class ;
      private string subGridusdtnotificationsdatas_Linesclass ;
      private string ROClassString ;
      private string edtavNotificationicon1_Jsonclick ;
      private string edtavUsdtnotificationsdata__notificationid_Jsonclick ;
      private string edtavUsdtnotificationsdata__notificationiconclass_Jsonclick ;
      private string edtavUsdtnotificationsdata__notificationtitle_Jsonclick ;
      private string edtavUsdtnotificationsdata__notificationdescription_Jsonclick ;
      private string edtavUsdtnotificationsdata__notificationdatetime_Jsonclick ;
      private string edtavUsdtnotificationsdata__notificationlink_Jsonclick ;
      private string edtavUsdtnotificationsdata__notificationdefinitionid_Jsonclick ;
      private string GXCCtl ;
      private string edtavUsdtnotificationsdata__notificationmetadata_Jsonclick ;
      private string subGridusdtnotificationsdatas_Header ;
      private DateTime GXt_dtime5 ;
      private DateTime AV5CalendarLoadFromDate ;
      private DateTime AV6CalendarLoadToDate ;
      private DateTime AV19Date_ShowingDatesFrom ;
      private DateTime AV10LoadedDotsFromDate ;
      private DateTime AV11LoadedDotsToDate ;
      private DateTime AV12LoadedFromDate ;
      private DateTime AV13LoadedToDate ;
      private DateTime AV18Date ;
      private DateTime AV7DotsFromDate ;
      private DateTime AV8DotsToDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV29ForceLoadDots ;
      private bool AV27EventsLoaded ;
      private bool Dvpanel_tablecards_Autowidth ;
      private bool Dvpanel_tablecards_Autoheight ;
      private bool Dvpanel_tablecards_Collapsible ;
      private bool Dvpanel_tablecards_Collapsed ;
      private bool Dvpanel_tablecards_Showcollapseicon ;
      private bool Dvpanel_tablecards_Autoscroll ;
      private bool Dvpanel_tablenotifications_Autowidth ;
      private bool Dvpanel_tablenotifications_Autoheight ;
      private bool Dvpanel_tablenotifications_Collapsible ;
      private bool Dvpanel_tablenotifications_Collapsed ;
      private bool Dvpanel_tablenotifications_Showcollapseicon ;
      private bool Dvpanel_tablenotifications_Autoscroll ;
      private bool Usercontrol1_Selectable ;
      private bool Usercontrol1_Navlinks ;
      private bool Dvpanel_tableagenda_Autowidth ;
      private bool Dvpanel_tableagenda_Autoheight ;
      private bool Dvpanel_tableagenda_Collapsible ;
      private bool Dvpanel_tableagenda_Collapsed ;
      private bool Dvpanel_tableagenda_Showcollapseicon ;
      private bool Dvpanel_tableagenda_Autoscroll ;
      private bool wbLoad ;
      private bool bGXsfl_139_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV72PackageAvailable ;
      private bool GXt_boolean1 ;
      private bool AV37KPI1_IsSuccessfulValue ;
      private bool AV46KPI4_IsSuccessfulValue ;
      private bool AV40KPI2_IsSuccessfulValue ;
      private bool AV43KPI3_IsSuccessfulValue ;
      private bool AV49KPI5_IsSuccessfulValue ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool gx_refresh_fired ;
      private bool gx_BV139 ;
      private string AV17CalendarEventsJson ;
      private string AV21DisabledDaysJson ;
      private string AV52Link ;
      private string AV15CalendarEventId ;
      private string AV71NotificationIcon1 ;
      private string AV73ResidentTitle ;
      private Guid AV53LocationId ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridusdtnotificationsdatasContainer ;
      private GXWebRow GridusdtnotificationsdatasRow ;
      private GXWebColumn GridusdtnotificationsdatasColumn ;
      private GXUserControl ucDvpanel_tablecards ;
      private GXUserControl ucDvpanel_tablenotifications ;
      private GXUserControl ucDvpanel_tableagenda ;
      private GXUserControl ucUsercontrol1 ;
      private GXUserControl ucGridusdtnotificationsdatas_empowerer ;
      private GXUserControl ucSendmessage_modal ;
      private GXUserControl ucCreateevent_modal ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavUsdtnotificationsdata__notificationisread ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV68WWPContext ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item> AV25Events ;
      private GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem> AV70USDTNotificationsData ;
      private GxSimpleCollection<DateTime> AV20DisabledDays ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV74NotificationInfo ;
      private GxSimpleCollection<long> AV54NotificationDefinitionIdEmptyCollection ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtHomeSampleData_HomeSampleDataItem> AV9HomeSampleData ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtHomeSampleData_HomeSampleDataItem> GXt_objcol_SdtHomeSampleData_HomeSampleDataItem4 ;
      private WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item AV16CalendarEvents ;
      private GXBaseCollection<SdtUSDTNotificationsData_USDTNotificationsDataItem> GXt_objcol_SdtUSDTNotificationsData_USDTNotificationsDataItem7 ;
      private GxSimpleCollection<DateTime> GXt_objcol_date9 ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item> AV26EventsAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item> GXt_objcol_SdtWWP_Calendar_Events_Item8 ;
      private WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions AV14WWPDateRangePickerOptions ;
      private WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions GXt_SdtWWPDateRangePickerOptions10 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
