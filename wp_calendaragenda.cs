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
   public class wp_calendaragenda : GXDataArea
   {
      public wp_calendaragenda( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_calendaragenda( IGxContext context )
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
         cmbavDatetypefilter = new GXCombobox();
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
            return "wp_calendaragenda_Execute" ;
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
         PA4U2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4U2( ) ;
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
         context.AddJavascriptSource("DVelop/Calendar/index.global.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Calendar/WWPCalendarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_calendaragenda.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDISABLEDDAYS", AV21DisabledDays);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDISABLEDDAYS", AV21DisabledDays);
         }
         GxWebStd.gx_hidden_field( context, "vCALENDARCURRENTDATE", context.localUtil.DToC( AV6CalendarCurrentDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vCALENDARLOADFROMDATE", context.localUtil.DToC( AV10CalendarLoadFromDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vCALENDARLOADTODATE", context.localUtil.DToC( AV11CalendarLoadToDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDATERANGEFILTER", context.localUtil.DToC( AV15DateRangeFilter, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDATERANGEFILTER_TO", context.localUtil.DToC( AV17DateRangeFilter_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vCALENDAREVENTID", AV7CalendarEventId);
         GxWebStd.gx_boolean_hidden_field( context, "vFORCELOADDOTS", AV29ForceLoadDots);
         GxWebStd.gx_boolean_hidden_field( context, "vEVENTSLOADED", AV27EventsLoaded);
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "vDATETOSEARCHFROM", context.localUtil.DToC( AV19DateToSearchFrom, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDATESTOSEARCHTO", context.localUtil.DToC( AV18DatesToSearchTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vLOADEDDOTSFROMDATE", context.localUtil.DToC( AV31LoadedDotsFromDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vLOADEDDOTSTODATE", context.localUtil.DToC( AV32LoadedDotsToDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vLOADEDFROMDATE", context.localUtil.DToC( AV33LoadedFromDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vLOADEDTODATE", context.localUtil.DToC( AV34LoadedToDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vCALENDAREVENTSJSON", AV9CalendarEventsJson);
         GxWebStd.gx_hidden_field( context, "vDISABLEDDAYSJSON", AV22DisabledDaysJson);
         GxWebStd.gx_hidden_field( context, "vACTIONSELECTED", AV5ActionSelected);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCALENDAREVENTS", AV8CalendarEvents);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCALENDAREVENTS", AV8CalendarEvents);
         }
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Filtermode", StringUtil.BoolToStr( Calendaruc_Filtermode));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Locale", StringUtil.RTrim( Calendaruc_Locale));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Selectable", StringUtil.BoolToStr( Calendaruc_Selectable));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Initialview", StringUtil.RTrim( Calendaruc_Initialview));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Viewstyle", StringUtil.RTrim( Calendaruc_Viewstyle));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Defaulteventstyle", StringUtil.RTrim( Calendaruc_Defaulteventstyle));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Fixedweekcount", StringUtil.BoolToStr( Calendaruc_Fixedweekcount));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Enabledayheaders", StringUtil.BoolToStr( Calendaruc_Enabledayheaders));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Enableeventshoursperday", StringUtil.BoolToStr( Calendaruc_Enableeventshoursperday));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Displayweeknumbers", StringUtil.BoolToStr( Calendaruc_Displayweeknumbers));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Navlinks", StringUtil.BoolToStr( Calendaruc_Navlinks));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Includeupdateinpopup", StringUtil.BoolToStr( Calendaruc_Includeupdateinpopup));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Includedeleteinpopup", StringUtil.BoolToStr( Calendaruc_Includedeleteinpopup));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Nowindicator", StringUtil.BoolToStr( Calendaruc_Nowindicator));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Todaybuttonposition", StringUtil.RTrim( Calendaruc_Todaybuttonposition));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Previousbuttonposition", StringUtil.RTrim( Calendaruc_Previousbuttonposition));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Nextbuttonposition", StringUtil.RTrim( Calendaruc_Nextbuttonposition));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Titleposition", StringUtil.RTrim( Calendaruc_Titleposition));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Monthbuttonposition", StringUtil.RTrim( Calendaruc_Monthbuttonposition));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Weekbuttonposition", StringUtil.RTrim( Calendaruc_Weekbuttonposition));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Daybuttonposition", StringUtil.RTrim( Calendaruc_Daybuttonposition));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Yearbuttonposition", StringUtil.RTrim( Calendaruc_Yearbuttonposition));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Listbuttonposition", StringUtil.RTrim( Calendaruc_Listbuttonposition));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Todaybuttontext", StringUtil.RTrim( Calendaruc_Todaybuttontext));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Monthbuttontext", StringUtil.RTrim( Calendaruc_Monthbuttontext));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Weekbuttontext", StringUtil.RTrim( Calendaruc_Weekbuttontext));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Daybuttontext", StringUtil.RTrim( Calendaruc_Daybuttontext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNDUMMYDELETE_Title", StringUtil.RTrim( Dvelop_confirmpanel_btndummydelete_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNDUMMYDELETE_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_btndummydelete_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNDUMMYDELETE_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btndummydelete_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNDUMMYDELETE_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btndummydelete_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNDUMMYDELETE_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_btndummydelete_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNDUMMYDELETE_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_btndummydelete_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNDUMMYDELETE_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_btndummydelete_Confirmtype));
         GxWebStd.gx_hidden_field( context, "CREATEEVENT_MODAL_Width", StringUtil.RTrim( Createevent_modal_Width));
         GxWebStd.gx_hidden_field( context, "CREATEEVENT_MODAL_Title", StringUtil.RTrim( Createevent_modal_Title));
         GxWebStd.gx_hidden_field( context, "CREATEEVENT_MODAL_Confirmtype", StringUtil.RTrim( Createevent_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "CREATEEVENT_MODAL_Bodytype", StringUtil.RTrim( Createevent_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Filtermode", StringUtil.BoolToStr( Calendaruc_Filtermode));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNDUMMYDELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_btndummydelete_Result));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Defaulteventstyle", StringUtil.RTrim( Calendaruc_Defaulteventstyle));
         GxWebStd.gx_hidden_field( context, "CREATEEVENT_MODAL_Result", StringUtil.RTrim( Createevent_modal_Result));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Datetimeselected", StringUtil.RTrim( Calendaruc_Datetimeselected));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Itemselected", StringUtil.RTrim( Calendaruc_Itemselected));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Eventactionselected", StringUtil.RTrim( Calendaruc_Eventactionselected));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Filtermode", StringUtil.BoolToStr( Calendaruc_Filtermode));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_BTNDUMMYDELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_btndummydelete_Result));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Filtermode", StringUtil.BoolToStr( Calendaruc_Filtermode));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Defaulteventstyle", StringUtil.RTrim( Calendaruc_Defaulteventstyle));
         GxWebStd.gx_hidden_field( context, "CREATEEVENT_MODAL_Result", StringUtil.RTrim( Createevent_modal_Result));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Datetimeselected", StringUtil.RTrim( Calendaruc_Datetimeselected));
         GxWebStd.gx_hidden_field( context, "CALENDARUC_Itemselected", StringUtil.RTrim( Calendaruc_Itemselected));
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
            WE4U2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4U2( ) ;
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
         return formatLink("wp_calendaragenda.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WP_CalendarAgenda" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Agenda", "") ;
      }

      protected void WB4U0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "TableCalendarContent", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divContent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'',false,'',0)\"";
            ClassString = "CreateEventButton";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncreateevent_Internalname, "", context.GetMessage( "WWP_Calendar_CreateEvent", ""), bttBtncreateevent_Jsonclick, 5, context.GetMessage( "WWP_Calendar_CreateEvent", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOCREATEEVENT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_CalendarAgenda.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginTop30 CalendarFlatDateCell", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDate_Internalname, context.GetMessage( "Date", ""), "gx-form-item AttributeDateLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDate_Internalname, context.localUtil.Format(AV12Date, "99/99/99"), context.localUtil.Format( AV12Date, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDate_Jsonclick, 0, "AttributeDate", "", "", "", "", 1, edtavDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WP_CalendarAgenda.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginTop30 hidden-xs", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblWwp_search_Internalname, context.GetMessage( "WWP_Search", ""), "", "", lblWwp_search_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockTitleWWP", 0, "", 1, 1, 0, 0, "HLP_WP_CalendarAgenda.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginTop10 DataContentCell hidden-xs", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitlefilter_Internalname, context.GetMessage( "Title Filter", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitlefilter_Internalname, AV36TitleFilter, StringUtil.RTrim( context.localUtil.Format( AV36TitleFilter, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Calendar_TitleEvent", ""), edtavTitlefilter_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTitlefilter_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CalendarAgenda.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginTop10 DataContentCell DscTop", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtabledatetypefilter_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockdatetypefilter_Internalname, context.GetMessage( "WWP_Calendar_Date", ""), "", "", lblTextblockdatetypefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CalendarAgenda.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDatetypefilter_Internalname, context.GetMessage( "Date Type Filter", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDatetypefilter, cmbavDatetypefilter_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV20DateTypeFilter), 1, 0)), 1, cmbavDatetypefilter_Jsonclick, 7, "'"+""+"'"+",false,"+"'"+"e114u1_client"+"'", "int", "", 1, cmbavDatetypefilter.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "", true, 0, "HLP_WP_CalendarAgenda.htm");
            cmbavDatetypefilter.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DateTypeFilter), 1, 0));
            AssignProp("", false, cmbavDatetypefilter_Internalname, "Values", (string)(cmbavDatetypefilter.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDaterangefilter_rangetext_cell_Internalname, 1, 0, "px", 0, "px", divDaterangefilter_rangetext_cell_Class, "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDaterangefilter_rangetext_Internalname, context.GetMessage( "Date Range Filter_Range Text", ""), "gx-form-item AttributeDateLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDaterangefilter_rangetext_Internalname, AV16DateRangeFilter_RangeText, StringUtil.RTrim( context.localUtil.Format( AV16DateRangeFilter_RangeText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDaterangefilter_rangetext_Jsonclick, 0, "AttributeDate", "", "", "", "", edtavDaterangefilter_rangetext_Visible, edtavDaterangefilter_rangetext_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CalendarAgenda.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDatefilter_cell_Internalname, 1, 0, "px", 0, "px", divDatefilter_cell_Class, "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDatefilter_Internalname, context.GetMessage( "Date Filter", ""), "gx-form-item AttributeDateLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDatefilter_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDatefilter_Internalname, context.localUtil.Format(AV14DateFilter, "99/99/99"), context.localUtil.Format( AV14DateFilter, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDatefilter_Jsonclick, 0, "AttributeDate", "", "", "", "", edtavDatefilter_Visible, edtavDatefilter_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WP_CalendarAgenda.htm");
            GxWebStd.gx_bitmap( context, edtavDatefilter_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavDatefilter_Visible==0)||(edtavDatefilter_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WP_CalendarAgenda.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPaddingLeft10 CellMarginTop hidden-xs", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuaclear_Internalname, "", context.GetMessage( "WWP_Calendar_Clear", ""), bttBtnuaclear_Jsonclick, 5, context.GetMessage( "WWP_Calendar_Clear", ""), "", StyleString, ClassString, bttBtnuaclear_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUACLEAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_CalendarAgenda.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuasearch_Internalname, "", context.GetMessage( "WWP_Calendar_Search", ""), bttBtnuasearch_Jsonclick, 5, context.GetMessage( "WWP_Calendar_Search", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUASEARCH\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_CalendarAgenda.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CalendarUcComponent", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucCalendaruc.SetProperty("Events", AV25Events);
            ucCalendaruc.SetProperty("DisabledDays", AV21DisabledDays);
            ucCalendaruc.SetProperty("CurrentDate", AV6CalendarCurrentDate);
            ucCalendaruc.SetProperty("FromDate", AV10CalendarLoadFromDate);
            ucCalendaruc.SetProperty("ToDate", AV11CalendarLoadToDate);
            ucCalendaruc.SetProperty("Selectable", Calendaruc_Selectable);
            ucCalendaruc.SetProperty("InitialView", Calendaruc_Initialview);
            ucCalendaruc.SetProperty("ViewStyle", Calendaruc_Viewstyle);
            ucCalendaruc.SetProperty("DefaultEventStyle", Calendaruc_Defaulteventstyle);
            ucCalendaruc.SetProperty("FixedWeekCount", Calendaruc_Fixedweekcount);
            ucCalendaruc.SetProperty("EnableDayHeaders", Calendaruc_Enabledayheaders);
            ucCalendaruc.SetProperty("EnableEventsHoursPerDay", Calendaruc_Enableeventshoursperday);
            ucCalendaruc.SetProperty("DisplayWeekNumbers", Calendaruc_Displayweeknumbers);
            ucCalendaruc.SetProperty("NavLinks", Calendaruc_Navlinks);
            ucCalendaruc.SetProperty("IncludeUpdateInPopup", Calendaruc_Includeupdateinpopup);
            ucCalendaruc.SetProperty("IncludeDeleteInPopup", Calendaruc_Includedeleteinpopup);
            ucCalendaruc.SetProperty("NowIndicator", Calendaruc_Nowindicator);
            ucCalendaruc.SetProperty("TodayButtonPosition", Calendaruc_Todaybuttonposition);
            ucCalendaruc.SetProperty("PreviousButtonPosition", Calendaruc_Previousbuttonposition);
            ucCalendaruc.SetProperty("NextButtonPosition", Calendaruc_Nextbuttonposition);
            ucCalendaruc.SetProperty("TitlePosition", Calendaruc_Titleposition);
            ucCalendaruc.SetProperty("MonthButtonPosition", Calendaruc_Monthbuttonposition);
            ucCalendaruc.SetProperty("WeekButtonPosition", Calendaruc_Weekbuttonposition);
            ucCalendaruc.SetProperty("DayButtonPosition", Calendaruc_Daybuttonposition);
            ucCalendaruc.SetProperty("YearButtonPosition", Calendaruc_Yearbuttonposition);
            ucCalendaruc.SetProperty("ListButtonPosition", Calendaruc_Listbuttonposition);
            ucCalendaruc.SetProperty("TodayButtonText", Calendaruc_Todaybuttontext);
            ucCalendaruc.SetProperty("MonthButtonText", Calendaruc_Monthbuttontext);
            ucCalendaruc.SetProperty("WeekButtonText", Calendaruc_Weekbuttontext);
            ucCalendaruc.SetProperty("DayButtonText", Calendaruc_Daybuttontext);
            ucCalendaruc.Render(context, "dvelop.wwpcalendar", Calendaruc_Internalname, "CALENDARUCContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
            ClassString = "Invisible";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndummydelete_Internalname, "", context.GetMessage( "Dummy Delete Event", ""), bttBtndummydelete_Jsonclick, 7, context.GetMessage( "Dummy Delete Event", ""), "", StyleString, ClassString, bttBtndummydelete_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e124u1_client"+"'", TempTags, "", 2, "HLP_WP_CalendarAgenda.htm");
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
            /* User Defined Control */
            ucDaterangefilter_rangepicker.SetProperty("Start Date", AV15DateRangeFilter);
            ucDaterangefilter_rangepicker.SetProperty("End Date", AV17DateRangeFilter_To);
            ucDaterangefilter_rangepicker.Render(context, "wwp.daterangepicker", Daterangefilter_rangepicker_Internalname, "DATERANGEFILTER_RANGEPICKERContainer");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDate_showingdatesfrom_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDate_showingdatesfrom_Internalname, context.localUtil.Format(AV13Date_ShowingDatesFrom, "99/99/99"), context.localUtil.Format( AV13Date_ShowingDatesFrom, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDate_showingdatesfrom_Jsonclick, 0, "Attribute", "", "", "", "", edtavDate_showingdatesfrom_Visible, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WP_CalendarAgenda.htm");
            GxWebStd.gx_bitmap( context, edtavDate_showingdatesfrom_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavDate_showingdatesfrom_Visible==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WP_CalendarAgenda.htm");
            context.WriteHtmlTextNl( "</div>") ;
            wb_table1_52_4U2( true) ;
         }
         else
         {
            wb_table1_52_4U2( false) ;
         }
         return  ;
      }

      protected void wb_table1_52_4U2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table2_57_4U2( true) ;
         }
         else
         {
            wb_table2_57_4U2( false) ;
         }
         return  ;
      }

      protected void wb_table2_57_4U2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0063"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0063"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0063"+"");
                  }
                  WebComp_Wwpaux_wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
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
         }
         wbLoad = true;
      }

      protected void START4U2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Agenda", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4U0( ) ;
      }

      protected void WS4U2( )
      {
         START4U2( ) ;
         EVT4U2( ) ;
      }

      protected void EVT4U2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "CALENDARUC.EVENTSELECTED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Calendaruc.Eventselected */
                              E134U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "CALENDARUC.EVENTDATEUPDATED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Calendaruc.Eventdateupdated */
                              E144U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "CALENDARUC.DELETEEVENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Calendaruc.Deleteevent */
                              E154U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "CALENDARUC.VISIBLEDATESCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Calendaruc.Visibledateschanged */
                              E164U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_BTNDUMMYDELETE.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_btndummydelete.Close */
                              E174U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "CREATEEVENT_MODAL.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Createevent_modal.Close */
                              E184U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "CREATEEVENT_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Createevent_modal.Onloadcomponent */
                              E194U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E204U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E214U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCREATEEVENT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoCreateEvent' */
                              E224U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUACLEAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUAClear' */
                              E234U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUASEARCH'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUASearch' */
                              E244U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDATE.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E254U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDATE_SHOWINGDATESFROM.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E264U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E274U2 ();
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
                        if ( nCmpId == 63 )
                        {
                           OldWwpaux_wc = cgiGet( "W0063");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0063", "", sEvt);
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

      protected void WE4U2( )
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

      protected void PA4U2( )
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
               GX_FocusControl = edtavDate_Internalname;
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
         if ( cmbavDatetypefilter.ItemCount > 0 )
         {
            AV20DateTypeFilter = (short)(Math.Round(NumberUtil.Val( cmbavDatetypefilter.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV20DateTypeFilter), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV20DateTypeFilter", StringUtil.Str( (decimal)(AV20DateTypeFilter), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDatetypefilter.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DateTypeFilter), 1, 0));
            AssignProp("", false, cmbavDatetypefilter_Internalname, "Values", cmbavDatetypefilter.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4U2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      protected void RF4U2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E214U2 ();
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
            /* Execute user event: Load */
            E274U2 ();
            WB4U0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4U2( )
      {
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4U0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E204U2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vEVENTS"), AV25Events);
            ajax_req_read_hidden_sdt(cgiGet( "vDISABLEDDAYS"), AV21DisabledDays);
            ajax_req_read_hidden_sdt(cgiGet( "vCALENDAREVENTS"), AV8CalendarEvents);
            /* Read saved values. */
            AV6CalendarCurrentDate = context.localUtil.CToD( cgiGet( "vCALENDARCURRENTDATE"), 0);
            AV10CalendarLoadFromDate = context.localUtil.CToD( cgiGet( "vCALENDARLOADFROMDATE"), 0);
            AV11CalendarLoadToDate = context.localUtil.CToD( cgiGet( "vCALENDARLOADTODATE"), 0);
            AV15DateRangeFilter = context.localUtil.CToD( cgiGet( "vDATERANGEFILTER"), 0);
            AV17DateRangeFilter_To = context.localUtil.CToD( cgiGet( "vDATERANGEFILTER_TO"), 0);
            AV7CalendarEventId = cgiGet( "vCALENDAREVENTID");
            AV5ActionSelected = cgiGet( "vACTIONSELECTED");
            Gx_mode = cgiGet( "vMODE");
            AV9CalendarEventsJson = cgiGet( "vCALENDAREVENTSJSON");
            Calendaruc_Filtermode = StringUtil.StrToBool( cgiGet( "CALENDARUC_Filtermode"));
            Calendaruc_Locale = cgiGet( "CALENDARUC_Locale");
            Calendaruc_Selectable = StringUtil.StrToBool( cgiGet( "CALENDARUC_Selectable"));
            Calendaruc_Initialview = cgiGet( "CALENDARUC_Initialview");
            Calendaruc_Viewstyle = cgiGet( "CALENDARUC_Viewstyle");
            Calendaruc_Defaulteventstyle = cgiGet( "CALENDARUC_Defaulteventstyle");
            Calendaruc_Fixedweekcount = StringUtil.StrToBool( cgiGet( "CALENDARUC_Fixedweekcount"));
            Calendaruc_Enabledayheaders = StringUtil.StrToBool( cgiGet( "CALENDARUC_Enabledayheaders"));
            Calendaruc_Enableeventshoursperday = StringUtil.StrToBool( cgiGet( "CALENDARUC_Enableeventshoursperday"));
            Calendaruc_Displayweeknumbers = StringUtil.StrToBool( cgiGet( "CALENDARUC_Displayweeknumbers"));
            Calendaruc_Navlinks = StringUtil.StrToBool( cgiGet( "CALENDARUC_Navlinks"));
            Calendaruc_Includeupdateinpopup = StringUtil.StrToBool( cgiGet( "CALENDARUC_Includeupdateinpopup"));
            Calendaruc_Includedeleteinpopup = StringUtil.StrToBool( cgiGet( "CALENDARUC_Includedeleteinpopup"));
            Calendaruc_Nowindicator = StringUtil.StrToBool( cgiGet( "CALENDARUC_Nowindicator"));
            Calendaruc_Todaybuttonposition = cgiGet( "CALENDARUC_Todaybuttonposition");
            Calendaruc_Previousbuttonposition = cgiGet( "CALENDARUC_Previousbuttonposition");
            Calendaruc_Nextbuttonposition = cgiGet( "CALENDARUC_Nextbuttonposition");
            Calendaruc_Titleposition = cgiGet( "CALENDARUC_Titleposition");
            Calendaruc_Monthbuttonposition = cgiGet( "CALENDARUC_Monthbuttonposition");
            Calendaruc_Weekbuttonposition = cgiGet( "CALENDARUC_Weekbuttonposition");
            Calendaruc_Daybuttonposition = cgiGet( "CALENDARUC_Daybuttonposition");
            Calendaruc_Yearbuttonposition = cgiGet( "CALENDARUC_Yearbuttonposition");
            Calendaruc_Listbuttonposition = cgiGet( "CALENDARUC_Listbuttonposition");
            Calendaruc_Todaybuttontext = cgiGet( "CALENDARUC_Todaybuttontext");
            Calendaruc_Monthbuttontext = cgiGet( "CALENDARUC_Monthbuttontext");
            Calendaruc_Weekbuttontext = cgiGet( "CALENDARUC_Weekbuttontext");
            Calendaruc_Daybuttontext = cgiGet( "CALENDARUC_Daybuttontext");
            Dvelop_confirmpanel_btndummydelete_Title = cgiGet( "DVELOP_CONFIRMPANEL_BTNDUMMYDELETE_Title");
            Dvelop_confirmpanel_btndummydelete_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_BTNDUMMYDELETE_Confirmationtext");
            Dvelop_confirmpanel_btndummydelete_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNDUMMYDELETE_Yesbuttoncaption");
            Dvelop_confirmpanel_btndummydelete_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNDUMMYDELETE_Nobuttoncaption");
            Dvelop_confirmpanel_btndummydelete_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_BTNDUMMYDELETE_Cancelbuttoncaption");
            Dvelop_confirmpanel_btndummydelete_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_BTNDUMMYDELETE_Yesbuttonposition");
            Dvelop_confirmpanel_btndummydelete_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_BTNDUMMYDELETE_Confirmtype");
            Createevent_modal_Width = cgiGet( "CREATEEVENT_MODAL_Width");
            Createevent_modal_Title = cgiGet( "CREATEEVENT_MODAL_Title");
            Createevent_modal_Confirmtype = cgiGet( "CREATEEVENT_MODAL_Confirmtype");
            Createevent_modal_Bodytype = cgiGet( "CREATEEVENT_MODAL_Bodytype");
            Calendaruc_Filtermode = StringUtil.StrToBool( cgiGet( "CALENDARUC_Filtermode"));
            Dvelop_confirmpanel_btndummydelete_Result = cgiGet( "DVELOP_CONFIRMPANEL_BTNDUMMYDELETE_Result");
            Calendaruc_Filtermode = StringUtil.StrToBool( cgiGet( "CALENDARUC_Filtermode"));
            Calendaruc_Defaulteventstyle = cgiGet( "CALENDARUC_Defaulteventstyle");
            Createevent_modal_Result = cgiGet( "CREATEEVENT_MODAL_Result");
            Calendaruc_Datetimeselected = cgiGet( "CALENDARUC_Datetimeselected");
            Calendaruc_Itemselected = cgiGet( "CALENDARUC_Itemselected");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavDate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Date", "")}), 1, "vDATE");
               GX_FocusControl = edtavDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12Date = DateTime.MinValue;
               AssignAttri("", false, "AV12Date", context.localUtil.Format(AV12Date, "99/99/99"));
            }
            else
            {
               AV12Date = context.localUtil.CToD( cgiGet( edtavDate_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV12Date", context.localUtil.Format(AV12Date, "99/99/99"));
            }
            AV36TitleFilter = cgiGet( edtavTitlefilter_Internalname);
            AssignAttri("", false, "AV36TitleFilter", AV36TitleFilter);
            cmbavDatetypefilter.CurrentValue = cgiGet( cmbavDatetypefilter_Internalname);
            AV20DateTypeFilter = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDatetypefilter_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV20DateTypeFilter", StringUtil.Str( (decimal)(AV20DateTypeFilter), 1, 0));
            AV16DateRangeFilter_RangeText = cgiGet( edtavDaterangefilter_rangetext_Internalname);
            AssignAttri("", false, "AV16DateRangeFilter_RangeText", AV16DateRangeFilter_RangeText);
            if ( context.localUtil.VCDate( cgiGet( edtavDatefilter_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Date Filter", "")}), 1, "vDATEFILTER");
               GX_FocusControl = edtavDatefilter_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14DateFilter = DateTime.MinValue;
               AssignAttri("", false, "AV14DateFilter", context.localUtil.Format(AV14DateFilter, "99/99/99"));
            }
            else
            {
               AV14DateFilter = context.localUtil.CToD( cgiGet( edtavDatefilter_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV14DateFilter", context.localUtil.Format(AV14DateFilter, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavDate_showingdatesfrom_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Date_Showing Dates From", "")}), 1, "vDATE_SHOWINGDATESFROM");
               GX_FocusControl = edtavDate_showingdatesfrom_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13Date_ShowingDatesFrom = DateTime.MinValue;
               AssignAttri("", false, "AV13Date_ShowingDatesFrom", context.localUtil.Format(AV13Date_ShowingDatesFrom, "99/99/99"));
            }
            else
            {
               AV13Date_ShowingDatesFrom = context.localUtil.CToD( cgiGet( edtavDate_showingdatesfrom_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV13Date_ShowingDatesFrom", context.localUtil.Format(AV13Date_ShowingDatesFrom, "99/99/99"));
            }
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
         E204U2 ();
         if (returnInSub) return;
      }

      protected void E204U2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV20DateTypeFilter = 3;
         AssignAttri("", false, "AV20DateTypeFilter", StringUtil.Str( (decimal)(AV20DateTypeFilter), 1, 0));
         this.executeUsercontrolMethod("", false, "DATERANGEFILTER_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDaterangefilter_rangetext_Internalname});
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         edtavDate_showingdatesfrom_Visible = 0;
         AssignProp("", false, edtavDate_showingdatesfrom_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDate_showingdatesfrom_Visible), 5, 0), true);
      }

      protected void E214U2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         Calendaruc_Monthbuttontext = context.GetMessage( "Month", "");
         ucCalendaruc.SendProperty(context, "", false, Calendaruc_Internalname, "MonthButtonText", Calendaruc_Monthbuttontext);
         Calendaruc_Weekbuttontext = context.GetMessage( "Week", "");
         ucCalendaruc.SendProperty(context, "", false, Calendaruc_Internalname, "WeekButtonText", Calendaruc_Weekbuttontext);
         Calendaruc_Daybuttontext = context.GetMessage( "Day", "");
         ucCalendaruc.SendProperty(context, "", false, Calendaruc_Internalname, "DayButtonText", Calendaruc_Daybuttontext);
         Calendaruc_Todaybuttontext = context.GetMessage( "Today", "");
         ucCalendaruc.SendProperty(context, "", false, Calendaruc_Internalname, "TodayButtonText", Calendaruc_Todaybuttontext);
         AV38SelectedLanguage = context.GetLanguage( );
         if ( StringUtil.StrCmp(AV38SelectedLanguage, "Dutch") == 0 )
         {
            Calendaruc_Locale = "nl-NL";
            ucCalendaruc.SendProperty(context, "", false, Calendaruc_Internalname, "Locale", Calendaruc_Locale);
         }
         else
         {
            Calendaruc_Locale = "";
            ucCalendaruc.SendProperty(context, "", false, Calendaruc_Internalname, "Locale", Calendaruc_Locale);
         }
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E174U2( )
      {
         /* Dvelop_confirmpanel_btndummydelete_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_btndummydelete_Result, "Yes") == 0 )
         {
            new GeneXus.Programs.workwithplus.wwp_calendar_deleteevent(context ).execute(  AV7CalendarEventId) ;
         }
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_btndummydelete_Result, "Yes") == 0 )
         {
            AV29ForceLoadDots = true;
            AssignAttri("", false, "AV29ForceLoadDots", AV29ForceLoadDots);
            /* Execute user subroutine: 'LOADCALENDAR' */
            S132 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25Events", AV25Events);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21DisabledDays", AV21DisabledDays);
      }

      protected void E224U2( )
      {
         /* 'DoCreateEvent' Routine */
         returnInSub = false;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         AV8CalendarEvents = new WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item(context);
         AV8CalendarEvents.gxTpr_Allday = false;
         GXt_dtime1 = DateTimeUtil.ResetTime( AV12Date ) ;
         AV8CalendarEvents.gxTpr_Start = GXt_dtime1;
         AV8CalendarEvents.gxTpr_Start = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV8CalendarEvents.gxTpr_Start)), (short)(DateTimeUtil.Month( AV8CalendarEvents.gxTpr_Start)), (short)(DateTimeUtil.Day( AV8CalendarEvents.gxTpr_Start)), (short)(DateTimeUtil.Hour( DateTimeUtil.Now( context))+1), 0, 0);
         AV8CalendarEvents.gxTpr_End = DateTimeUtil.TAdd( AV8CalendarEvents.gxTpr_Start, 3600*(1));
         AV9CalendarEventsJson = AV8CalendarEvents.ToJSonString(false, true);
         AssignAttri("", false, "AV9CalendarEventsJson", AV9CalendarEventsJson);
         this.executeUsercontrolMethod("", false, "CREATEEVENT_MODALContainer", "Confirm", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void E194U2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0063",(string)"",(string)Gx_mode,(string)AV9CalendarEventsJson,(string)AV7CalendarEventId,(string)AV22DisabledDaysJson});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0063"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E234U2( )
      {
         /* 'DoUAClear' Routine */
         returnInSub = false;
         Calendaruc_Filtermode = false;
         ucCalendaruc.SendProperty(context, "", false, Calendaruc_Internalname, "FilterMode", StringUtil.BoolToStr( Calendaruc_Filtermode));
         AV12Date = Gx_date;
         AssignAttri("", false, "AV12Date", context.localUtil.Format(AV12Date, "99/99/99"));
         AV20DateTypeFilter = 3;
         AssignAttri("", false, "AV20DateTypeFilter", StringUtil.Str( (decimal)(AV20DateTypeFilter), 1, 0));
         AV15DateRangeFilter = DateTime.MinValue;
         AssignAttri("", false, "AV15DateRangeFilter", context.localUtil.Format(AV15DateRangeFilter, "99/99/99"));
         AV17DateRangeFilter_To = DateTime.MinValue;
         AssignAttri("", false, "AV17DateRangeFilter_To", context.localUtil.Format(AV17DateRangeFilter_To, "99/99/99"));
         AV14DateFilter = DateTime.MinValue;
         AssignAttri("", false, "AV14DateFilter", context.localUtil.Format(AV14DateFilter, "99/99/99"));
         AV36TitleFilter = "";
         AssignAttri("", false, "AV36TitleFilter", AV36TitleFilter);
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S122 ();
         if (returnInSub) return;
         if ( 1 == 0 )
         {
            new GeneXus.Core.genexus.common.SdtLog(context).error("") ;
         }
         this.executeUsercontrolMethod("", false, "CALENDARUCContainer", "MoveCalendarToDate", "", new Object[] {context.localUtil.DToC( Gx_date, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/")});
         AV29ForceLoadDots = true;
         AssignAttri("", false, "AV29ForceLoadDots", AV29ForceLoadDots);
         /* Execute user subroutine: 'LOADCALENDAR' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavDatetypefilter.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DateTypeFilter), 1, 0));
         AssignProp("", false, cmbavDatetypefilter_Internalname, "Values", cmbavDatetypefilter.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25Events", AV25Events);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21DisabledDays", AV21DisabledDays);
      }

      protected void E244U2( )
      {
         /* 'DoUASearch' Routine */
         returnInSub = false;
         Calendaruc_Filtermode = true;
         ucCalendaruc.SendProperty(context, "", false, Calendaruc_Internalname, "FilterMode", StringUtil.BoolToStr( Calendaruc_Filtermode));
         AV29ForceLoadDots = true;
         AssignAttri("", false, "AV29ForceLoadDots", AV29ForceLoadDots);
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCALENDAR' */
         S132 ();
         if (returnInSub) return;
         this.executeUsercontrolMethod("", false, "CALENDARUCContainer", "ChangeCalendarToView", "", new Object[] {context.GetMessage( "listYear", "")});
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25Events", AV25Events);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21DisabledDays", AV21DisabledDays);
      }

      protected void S122( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ( 1 == 0 ) ) )
         {
            bttBtndummydelete_Visible = 0;
            AssignProp("", false, bttBtndummydelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndummydelete_Visible), 5, 0), true);
         }
         if ( ! ( Calendaruc_Filtermode ) )
         {
            bttBtnuaclear_Visible = 0;
            AssignProp("", false, bttBtnuaclear_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnuaclear_Visible), 5, 0), true);
         }
         if ( Calendaruc_Filtermode )
         {
            bttBtnuaclear_Visible = 1;
            AssignProp("", false, bttBtnuaclear_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnuaclear_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( AV20DateTypeFilter == 5 ) ) )
         {
            edtavDaterangefilter_rangetext_Visible = 0;
            AssignProp("", false, edtavDaterangefilter_rangetext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDaterangefilter_rangetext_Visible), 5, 0), true);
            divDaterangefilter_rangetext_cell_Class = "Invisible";
            AssignProp("", false, divDaterangefilter_rangetext_cell_Internalname, "Class", divDaterangefilter_rangetext_cell_Class, true);
         }
         else
         {
            edtavDaterangefilter_rangetext_Visible = 1;
            AssignProp("", false, edtavDaterangefilter_rangetext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDaterangefilter_rangetext_Visible), 5, 0), true);
            divDaterangefilter_rangetext_cell_Class = "CellMarginTop10 DataContentCell";
            AssignProp("", false, divDaterangefilter_rangetext_cell_Internalname, "Class", divDaterangefilter_rangetext_cell_Class, true);
         }
         if ( ! ( ( AV20DateTypeFilter == 4 ) ) )
         {
            edtavDatefilter_Visible = 0;
            AssignProp("", false, edtavDatefilter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDatefilter_Visible), 5, 0), true);
            divDatefilter_cell_Class = "Invisible";
            AssignProp("", false, divDatefilter_cell_Internalname, "Class", divDatefilter_cell_Class, true);
         }
         else
         {
            edtavDatefilter_Visible = 1;
            AssignProp("", false, edtavDatefilter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDatefilter_Visible), 5, 0), true);
            divDatefilter_cell_Class = "CellMarginTop10 DataContentCell";
            AssignProp("", false, divDatefilter_cell_Internalname, "Class", divDatefilter_cell_Class, true);
         }
      }

      protected void E184U2( )
      {
         /* Createevent_modal_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Createevent_modal_Result, "OK") == 0 )
         {
            AV29ForceLoadDots = true;
            AssignAttri("", false, "AV29ForceLoadDots", AV29ForceLoadDots);
            /* Execute user subroutine: 'LOADCALENDAR' */
            S132 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(Createevent_modal_Result, "DELETE") == 0 )
         {
            /* Execute user subroutine: 'DELETEEVENT' */
            S142 ();
            if (returnInSub) return;
         }
         else
         {
            this.executeUsercontrolMethod("", false, "CALENDARUCContainer", "RemoveHighlightDay", "", new Object[] {});
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25Events", AV25Events);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21DisabledDays", AV21DisabledDays);
      }

      protected void E254U2( )
      {
         /* Date_Controlvaluechanged Routine */
         returnInSub = false;
         AV6CalendarCurrentDate = AV12Date;
         AssignAttri("", false, "AV6CalendarCurrentDate", context.localUtil.Format(AV6CalendarCurrentDate, "99/99/99"));
         if ( 1 == 0 )
         {
            new GeneXus.Core.genexus.common.SdtLog(context).error("") ;
         }
         /*  Sending Event outputs  */
      }

      protected void E144U2( )
      {
         /* Calendaruc_Eventdateupdated Routine */
         returnInSub = false;
         AV8CalendarEvents.FromJSonString(Calendaruc_Datetimeselected, null);
         new GeneXus.Programs.workwithplus.wwp_calendar_updateeventdate(context ).execute(  AV8CalendarEvents) ;
         AV29ForceLoadDots = true;
         AssignAttri("", false, "AV29ForceLoadDots", AV29ForceLoadDots);
         /* Execute user subroutine: 'LOADCALENDAR' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25Events", AV25Events);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21DisabledDays", AV21DisabledDays);
      }

      protected void E134U2( )
      {
         /* Calendaruc_Eventselected Routine */
         returnInSub = false;
         AV7CalendarEventId = Calendaruc_Itemselected;
         AssignAttri("", false, "AV7CalendarEventId", AV7CalendarEventId);
         Gx_mode = "DSP";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         GXt_SdtWWP_Calendar_Events_Item2 = AV8CalendarEvents;
         new GeneXus.Programs.workwithplus.wwp_calendar_getevent(context ).execute(  AV7CalendarEventId, out  GXt_SdtWWP_Calendar_Events_Item2) ;
         AV8CalendarEvents = GXt_SdtWWP_Calendar_Events_Item2;
         this.executeUsercontrolMethod("", false, "CREATEEVENT_MODALContainer", "Confirm", "", new Object[] {});
         /*  Sending Event outputs  */
      }

      protected void E154U2( )
      {
         /* Calendaruc_Deleteevent Routine */
         returnInSub = false;
         AV7CalendarEventId = Calendaruc_Itemselected;
         AssignAttri("", false, "AV7CalendarEventId", AV7CalendarEventId);
         /* Execute user subroutine: 'DELETEEVENT' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E164U2( )
      {
         /* Calendaruc_Visibledateschanged Routine */
         returnInSub = false;
         if ( ( DateTimeUtil.ResetTime ( AV10CalendarLoadFromDate ) < DateTimeUtil.ResetTime ( AV33LoadedFromDate ) ) || ( DateTimeUtil.ResetTime ( AV11CalendarLoadToDate ) > DateTimeUtil.ResetTime ( AV34LoadedToDate ) ) )
         {
            /* Execute user subroutine: 'LOADCALENDAR' */
            S132 ();
            if (returnInSub) return;
         }
         AV12Date = AV6CalendarCurrentDate;
         AssignAttri("", false, "AV12Date", context.localUtil.Format(AV12Date, "99/99/99"));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV25Events", AV25Events);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21DisabledDays", AV21DisabledDays);
      }

      protected void E264U2( )
      {
         /* Date_showingdatesfrom_Controlvaluechanged Routine */
         returnInSub = false;
         if ( AV27EventsLoaded )
         {
            /* Execute user subroutine: 'LOAD DOTS' */
            S152 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'DELETEEVENT' Routine */
         returnInSub = false;
         GXt_SdtWWP_Calendar_Events_Item2 = AV8CalendarEvents;
         new GeneXus.Programs.workwithplus.wwp_calendar_getevent(context ).execute(  AV7CalendarEventId, out  GXt_SdtWWP_Calendar_Events_Item2) ;
         AV8CalendarEvents = GXt_SdtWWP_Calendar_Events_Item2;
         AV28EventTitle = AV8CalendarEvents.gxTpr_Title;
         Dvelop_confirmpanel_btndummydelete_Confirmationtext = StringUtil.Format( context.GetMessage( "WWP_Calendar_DeleteEventMessage", ""), AV28EventTitle, "", "", "", "", "", "", "", "");
         ucDvelop_confirmpanel_btndummydelete.SendProperty(context, "", false, Dvelop_confirmpanel_btndummydelete_Internalname, "ConfirmationText", Dvelop_confirmpanel_btndummydelete_Confirmationtext);
         this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_BTNDUMMYDELETEContainer", "Confirm", "", new Object[] {});
      }

      protected void S132( )
      {
         /* 'LOADCALENDAR' Routine */
         returnInSub = false;
         AV29ForceLoadDots = (bool)(AV29ForceLoadDots||(!AV27EventsLoaded));
         AssignAttri("", false, "AV29ForceLoadDots", AV29ForceLoadDots);
         AV27EventsLoaded = true;
         AssignAttri("", false, "AV27EventsLoaded", AV27EventsLoaded);
         AV33LoadedFromDate = AV10CalendarLoadFromDate;
         AssignAttri("", false, "AV33LoadedFromDate", context.localUtil.Format(AV33LoadedFromDate, "99/99/99"));
         AV34LoadedToDate = AV11CalendarLoadToDate;
         AssignAttri("", false, "AV34LoadedToDate", context.localUtil.Format(AV34LoadedToDate, "99/99/99"));
         if ( Calendaruc_Filtermode )
         {
            /* Execute user subroutine: 'FILTEREVENTS' */
            S162 ();
            if (returnInSub) return;
         }
         else
         {
            GXt_objcol_SdtWWP_Calendar_Events_Item3 = AV25Events;
            GXt_dtime1 = DateTimeUtil.ResetTime( AV10CalendarLoadFromDate ) ;
            new GeneXus.Programs.workwithplus.wwp_calendar_getevents(context ).execute(  false,  "",  GXt_dtime1,  AV11CalendarLoadToDate, out  GXt_objcol_SdtWWP_Calendar_Events_Item3) ;
            AV25Events = GXt_objcol_SdtWWP_Calendar_Events_Item3;
         }
         if ( AV29ForceLoadDots )
         {
            AV29ForceLoadDots = false;
            AssignAttri("", false, "AV29ForceLoadDots", AV29ForceLoadDots);
            AV31LoadedDotsFromDate = DateTime.MinValue;
            AssignAttri("", false, "AV31LoadedDotsFromDate", context.localUtil.Format(AV31LoadedDotsFromDate, "99/99/99"));
            AV32LoadedDotsToDate = DateTime.MinValue;
            AssignAttri("", false, "AV32LoadedDotsToDate", context.localUtil.Format(AV32LoadedDotsToDate, "99/99/99"));
            /* Execute user subroutine: 'LOAD DOTS' */
            S152 ();
            if (returnInSub) return;
         }
         GXt_objcol_date4 = AV21DisabledDays;
         new GeneXus.Programs.workwithplus.wwp_calendar_getdisableddays(context ).execute( out  GXt_objcol_date4) ;
         AV21DisabledDays = GXt_objcol_date4;
         AV22DisabledDaysJson = AV21DisabledDays.ToJSonString(false);
         AssignAttri("", false, "AV22DisabledDaysJson", AV22DisabledDaysJson);
      }

      protected void S152( )
      {
         /* 'LOAD DOTS' Routine */
         returnInSub = false;
         AV23DotsFromDate = DateTimeUtil.DAdd( AV13Date_ShowingDatesFrom, (7));
         AV23DotsFromDate = context.localUtil.YMDToD( DateTimeUtil.Year( AV23DotsFromDate), DateTimeUtil.Month( AV23DotsFromDate), 1);
         AV24DotsToDate = DateTimeUtil.AddMth( AV23DotsFromDate, 1);
         AV24DotsToDate = DateTimeUtil.DAdd( AV24DotsToDate, (-1));
         if ( ( DateTimeUtil.ResetTime ( AV23DotsFromDate ) < DateTimeUtil.ResetTime ( AV31LoadedDotsFromDate ) ) || ( DateTimeUtil.ResetTime ( AV24DotsToDate ) > DateTimeUtil.ResetTime ( AV32LoadedDotsToDate ) ) )
         {
            AV31LoadedDotsFromDate = AV23DotsFromDate;
            AssignAttri("", false, "AV31LoadedDotsFromDate", context.localUtil.Format(AV31LoadedDotsFromDate, "99/99/99"));
            AV32LoadedDotsToDate = AV24DotsToDate;
            AssignAttri("", false, "AV32LoadedDotsToDate", context.localUtil.Format(AV32LoadedDotsToDate, "99/99/99"));
            if ( ( DateTimeUtil.ResetTime ( AV23DotsFromDate ) < DateTimeUtil.ResetTime ( AV33LoadedFromDate ) ) || ( DateTimeUtil.ResetTime ( AV24DotsToDate ) > DateTimeUtil.ResetTime ( AV34LoadedToDate ) ) )
            {
               GXt_objcol_SdtWWP_Calendar_Events_Item3 = AV26EventsAux;
               GXt_dtime1 = DateTimeUtil.ResetTime( AV23DotsFromDate ) ;
               new GeneXus.Programs.workwithplus.wwp_calendar_getevents(context ).execute(  false,  "",  GXt_dtime1,  AV24DotsToDate, out  GXt_objcol_SdtWWP_Calendar_Events_Item3) ;
               AV26EventsAux = GXt_objcol_SdtWWP_Calendar_Events_Item3;
               GXt_SdtWWPDateRangePickerOptions5 = AV37WWPDateRangePickerOptions;
               new WorkWithPlus.workwithplus_web.wwp_geteventsforflatdate(context ).execute(  AV26EventsAux,  AV23DotsFromDate,  AV24DotsToDate,  Calendaruc_Defaulteventstyle, out  GXt_SdtWWPDateRangePickerOptions5) ;
               AV37WWPDateRangePickerOptions = GXt_SdtWWPDateRangePickerOptions5;
               AV26EventsAux = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta_version2");
            }
            else
            {
               GXt_SdtWWPDateRangePickerOptions5 = AV37WWPDateRangePickerOptions;
               new WorkWithPlus.workwithplus_web.wwp_geteventsforflatdate(context ).execute(  AV25Events,  AV23DotsFromDate,  AV24DotsToDate,  Calendaruc_Defaulteventstyle, out  GXt_SdtWWPDateRangePickerOptions5) ;
               AV37WWPDateRangePickerOptions = GXt_SdtWWPDateRangePickerOptions5;
            }
            this.executeExternalObjectMethod("", false, "WWPActions", "DateTimePicker_SetOptions", new Object[] {(string)edtavDate_Internalname,AV37WWPDateRangePickerOptions.ToJSonString(false, true)}, false);
         }
      }

      protected void S162( )
      {
         /* 'FILTEREVENTS' Routine */
         returnInSub = false;
         if ( AV20DateTypeFilter == 2 )
         {
            AV19DateToSearchFrom = DateTimeUtil.AddYr( Gx_date, -40);
            AssignAttri("", false, "AV19DateToSearchFrom", context.localUtil.Format(AV19DateToSearchFrom, "99/99/99"));
            AV18DatesToSearchTo = Gx_date;
            AssignAttri("", false, "AV18DatesToSearchTo", context.localUtil.Format(AV18DatesToSearchTo, "99/99/99"));
         }
         else if ( AV20DateTypeFilter == 3 )
         {
            AV19DateToSearchFrom = Gx_date;
            AssignAttri("", false, "AV19DateToSearchFrom", context.localUtil.Format(AV19DateToSearchFrom, "99/99/99"));
            AV18DatesToSearchTo = DateTimeUtil.AddYr( Gx_date, 100);
            AssignAttri("", false, "AV18DatesToSearchTo", context.localUtil.Format(AV18DatesToSearchTo, "99/99/99"));
         }
         else if ( AV20DateTypeFilter == 4 )
         {
            AV19DateToSearchFrom = AV14DateFilter;
            AssignAttri("", false, "AV19DateToSearchFrom", context.localUtil.Format(AV19DateToSearchFrom, "99/99/99"));
            AV18DatesToSearchTo = DateTimeUtil.AddYr( Gx_date, 100);
            AssignAttri("", false, "AV18DatesToSearchTo", context.localUtil.Format(AV18DatesToSearchTo, "99/99/99"));
         }
         else if ( AV20DateTypeFilter == 5 )
         {
            AV19DateToSearchFrom = AV15DateRangeFilter;
            AssignAttri("", false, "AV19DateToSearchFrom", context.localUtil.Format(AV19DateToSearchFrom, "99/99/99"));
            AV18DatesToSearchTo = AV17DateRangeFilter_To;
            AssignAttri("", false, "AV18DatesToSearchTo", context.localUtil.Format(AV18DatesToSearchTo, "99/99/99"));
         }
         else if ( AV20DateTypeFilter == 1 )
         {
            AV19DateToSearchFrom = DateTimeUtil.AddYr( Gx_date, -40);
            AssignAttri("", false, "AV19DateToSearchFrom", context.localUtil.Format(AV19DateToSearchFrom, "99/99/99"));
            AV18DatesToSearchTo = DateTimeUtil.AddYr( Gx_date, 100);
            AssignAttri("", false, "AV18DatesToSearchTo", context.localUtil.Format(AV18DatesToSearchTo, "99/99/99"));
         }
         GXt_objcol_SdtWWP_Calendar_Events_Item3 = AV25Events;
         GXt_dtime1 = DateTimeUtil.ResetTime( AV19DateToSearchFrom ) ;
         new GeneXus.Programs.workwithplus.wwp_calendar_getevents(context ).execute(  true,  AV36TitleFilter,  GXt_dtime1,  AV18DatesToSearchTo, out  GXt_objcol_SdtWWP_Calendar_Events_Item3) ;
         AV25Events = GXt_objcol_SdtWWP_Calendar_Events_Item3;
      }

      protected void nextLoad( )
      {
      }

      protected void E274U2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_57_4U2( bool wbgen )
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
            wb_table2_57_4U2e( true) ;
         }
         else
         {
            wb_table2_57_4U2e( false) ;
         }
      }

      protected void wb_table1_52_4U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_btndummydelete_Internalname, tblTabledvelop_confirmpanel_btndummydelete_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_btndummydelete.SetProperty("Title", Dvelop_confirmpanel_btndummydelete_Title);
            ucDvelop_confirmpanel_btndummydelete.SetProperty("ConfirmationText", Dvelop_confirmpanel_btndummydelete_Confirmationtext);
            ucDvelop_confirmpanel_btndummydelete.SetProperty("YesButtonCaption", Dvelop_confirmpanel_btndummydelete_Yesbuttoncaption);
            ucDvelop_confirmpanel_btndummydelete.SetProperty("NoButtonCaption", Dvelop_confirmpanel_btndummydelete_Nobuttoncaption);
            ucDvelop_confirmpanel_btndummydelete.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_btndummydelete_Cancelbuttoncaption);
            ucDvelop_confirmpanel_btndummydelete.SetProperty("YesButtonPosition", Dvelop_confirmpanel_btndummydelete_Yesbuttonposition);
            ucDvelop_confirmpanel_btndummydelete.SetProperty("ConfirmType", Dvelop_confirmpanel_btndummydelete_Confirmtype);
            ucDvelop_confirmpanel_btndummydelete.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_btndummydelete_Internalname, "DVELOP_CONFIRMPANEL_BTNDUMMYDELETEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_BTNDUMMYDELETEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_52_4U2e( true) ;
         }
         else
         {
            wb_table1_52_4U2e( false) ;
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
         PA4U2( ) ;
         WS4U2( ) ;
         WE4U2( ) ;
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
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256201781649", true, true);
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
         context.AddJavascriptSource("wp_calendaragenda.js", "?20256201781650", false, true);
         context.AddJavascriptSource("DVelop/Calendar/index.global.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Calendar/WWPCalendarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavDatetypefilter.Name = "vDATETYPEFILTER";
         cmbavDatetypefilter.WebTags = "";
         cmbavDatetypefilter.addItem("1", context.GetMessage( "WWP_Calendar_All", ""), 0);
         cmbavDatetypefilter.addItem("2", context.GetMessage( "WWP_Calendar_Past", ""), 0);
         cmbavDatetypefilter.addItem("3", context.GetMessage( "WWP_Calendar_Future", ""), 0);
         cmbavDatetypefilter.addItem("4", context.GetMessage( "WWP_Calendar_FromDate", ""), 0);
         cmbavDatetypefilter.addItem("5", context.GetMessage( "WWP_Calendar_Range", ""), 0);
         if ( cmbavDatetypefilter.ItemCount > 0 )
         {
            AV20DateTypeFilter = (short)(Math.Round(NumberUtil.Val( cmbavDatetypefilter.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV20DateTypeFilter), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV20DateTypeFilter", StringUtil.Str( (decimal)(AV20DateTypeFilter), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtncreateevent_Internalname = "BTNCREATEEVENT";
         edtavDate_Internalname = "vDATE";
         lblWwp_search_Internalname = "WWP_SEARCH";
         edtavTitlefilter_Internalname = "vTITLEFILTER";
         lblTextblockdatetypefilter_Internalname = "TEXTBLOCKDATETYPEFILTER";
         cmbavDatetypefilter_Internalname = "vDATETYPEFILTER";
         divUnnamedtabledatetypefilter_Internalname = "UNNAMEDTABLEDATETYPEFILTER";
         edtavDaterangefilter_rangetext_Internalname = "vDATERANGEFILTER_RANGETEXT";
         divDaterangefilter_rangetext_cell_Internalname = "DATERANGEFILTER_RANGETEXT_CELL";
         edtavDatefilter_Internalname = "vDATEFILTER";
         divDatefilter_cell_Internalname = "DATEFILTER_CELL";
         bttBtnuaclear_Internalname = "BTNUACLEAR";
         bttBtnuasearch_Internalname = "BTNUASEARCH";
         divContent_Internalname = "CONTENT";
         Calendaruc_Internalname = "CALENDARUC";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtndummydelete_Internalname = "BTNDUMMYDELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Daterangefilter_rangepicker_Internalname = "DATERANGEFILTER_RANGEPICKER";
         edtavDate_showingdatesfrom_Internalname = "vDATE_SHOWINGDATESFROM";
         Dvelop_confirmpanel_btndummydelete_Internalname = "DVELOP_CONFIRMPANEL_BTNDUMMYDELETE";
         tblTabledvelop_confirmpanel_btndummydelete_Internalname = "TABLEDVELOP_CONFIRMPANEL_BTNDUMMYDELETE";
         Createevent_modal_Internalname = "CREATEEVENT_MODAL";
         tblTablecreateevent_modal_Internalname = "TABLECREATEEVENT_MODAL";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
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
         edtavDate_showingdatesfrom_Jsonclick = "";
         edtavDate_showingdatesfrom_Visible = 1;
         bttBtndummydelete_Visible = 1;
         bttBtnuaclear_Visible = 1;
         edtavDatefilter_Jsonclick = "";
         edtavDatefilter_Enabled = 1;
         edtavDatefilter_Visible = 1;
         divDatefilter_cell_Class = "";
         edtavDaterangefilter_rangetext_Jsonclick = "";
         edtavDaterangefilter_rangetext_Enabled = 1;
         edtavDaterangefilter_rangetext_Visible = 1;
         divDaterangefilter_rangetext_cell_Class = "";
         cmbavDatetypefilter_Jsonclick = "";
         cmbavDatetypefilter.Enabled = 1;
         edtavTitlefilter_Jsonclick = "";
         edtavTitlefilter_Enabled = 1;
         edtavDate_Jsonclick = "";
         edtavDate_Enabled = 1;
         Createevent_modal_Bodytype = "WebComponent";
         Createevent_modal_Confirmtype = "";
         Createevent_modal_Title = context.GetMessage( "Event", "");
         Createevent_modal_Width = "600";
         Dvelop_confirmpanel_btndummydelete_Confirmtype = "1";
         Dvelop_confirmpanel_btndummydelete_Yesbuttonposition = "left";
         Dvelop_confirmpanel_btndummydelete_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_btndummydelete_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_btndummydelete_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_btndummydelete_Confirmationtext = "WWP_Calendar_DeleteEventMessage";
         Dvelop_confirmpanel_btndummydelete_Title = context.GetMessage( "WWP_Calendar_DeleteEventTitle", "");
         Calendaruc_Daybuttontext = "Day";
         Calendaruc_Weekbuttontext = "Week";
         Calendaruc_Monthbuttontext = "Month";
         Calendaruc_Todaybuttontext = "Today";
         Calendaruc_Listbuttonposition = "None";
         Calendaruc_Yearbuttonposition = "None";
         Calendaruc_Daybuttonposition = "HeaderRight";
         Calendaruc_Weekbuttonposition = "HeaderRight";
         Calendaruc_Monthbuttonposition = "HeaderRight";
         Calendaruc_Titleposition = "HeaderLeft";
         Calendaruc_Nextbuttonposition = "HeaderLeft";
         Calendaruc_Previousbuttonposition = "HeaderLeft";
         Calendaruc_Todaybuttonposition = "HeaderLeft";
         Calendaruc_Nowindicator = Convert.ToBoolean( -1);
         Calendaruc_Includedeleteinpopup = Convert.ToBoolean( 0);
         Calendaruc_Includeupdateinpopup = Convert.ToBoolean( 0);
         Calendaruc_Navlinks = Convert.ToBoolean( -1);
         Calendaruc_Displayweeknumbers = Convert.ToBoolean( 0);
         Calendaruc_Enableeventshoursperday = Convert.ToBoolean( 0);
         Calendaruc_Enabledayheaders = Convert.ToBoolean( -1);
         Calendaruc_Fixedweekcount = Convert.ToBoolean( 0);
         Calendaruc_Defaulteventstyle = "BaseColor";
         Calendaruc_Viewstyle = "Standard";
         Calendaruc_Initialview = "Month";
         Calendaruc_Selectable = Convert.ToBoolean( -1);
         Calendaruc_Locale = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Agenda", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Calendaruc_Filtermode","ctrl":"CALENDARUC","prop":"FilterMode"},{"av":"Gx_date","fld":"vTODAY","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"Calendaruc_Monthbuttontext","ctrl":"CALENDARUC","prop":"MonthButtonText"},{"av":"Calendaruc_Weekbuttontext","ctrl":"CALENDARUC","prop":"WeekButtonText"},{"av":"Calendaruc_Daybuttontext","ctrl":"CALENDARUC","prop":"DayButtonText"},{"av":"Calendaruc_Todaybuttontext","ctrl":"CALENDARUC","prop":"TodayButtonText"},{"av":"Calendaruc_Locale","ctrl":"CALENDARUC","prop":"Locale"},{"ctrl":"BTNDUMMYDELETE","prop":"Visible"},{"ctrl":"BTNUACLEAR","prop":"Visible"}]}""");
         setEventMetadata("'DODUMMYDELETE'","""{"handler":"E124U1","iparms":[]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNDUMMYDELETE.CLOSE","""{"handler":"E174U2","iparms":[{"av":"Dvelop_confirmpanel_btndummydelete_Result","ctrl":"DVELOP_CONFIRMPANEL_BTNDUMMYDELETE","prop":"Result"},{"av":"AV7CalendarEventId","fld":"vCALENDAREVENTID"},{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV10CalendarLoadFromDate","fld":"vCALENDARLOADFROMDATE"},{"av":"AV11CalendarLoadToDate","fld":"vCALENDARLOADTODATE"},{"av":"Calendaruc_Filtermode","ctrl":"CALENDARUC","prop":"FilterMode"},{"av":"cmbavDatetypefilter"},{"av":"AV20DateTypeFilter","fld":"vDATETYPEFILTER","pic":"9"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"AV14DateFilter","fld":"vDATEFILTER"},{"av":"AV15DateRangeFilter","fld":"vDATERANGEFILTER"},{"av":"AV17DateRangeFilter_To","fld":"vDATERANGEFILTER_TO"},{"av":"AV36TitleFilter","fld":"vTITLEFILTER"},{"av":"AV19DateToSearchFrom","fld":"vDATETOSEARCHFROM"},{"av":"AV18DatesToSearchTo","fld":"vDATESTOSEARCHTO"},{"av":"AV13Date_ShowingDatesFrom","fld":"vDATE_SHOWINGDATESFROM"},{"av":"AV31LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV32LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV33LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV34LoadedToDate","fld":"vLOADEDTODATE"},{"av":"Calendaruc_Defaulteventstyle","ctrl":"CALENDARUC","prop":"DefaultEventStyle"},{"av":"AV25Events","fld":"vEVENTS"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_BTNDUMMYDELETE.CLOSE",""","oparms":[{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV33LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV34LoadedToDate","fld":"vLOADEDTODATE"},{"av":"AV25Events","fld":"vEVENTS"},{"av":"AV31LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV32LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV21DisabledDays","fld":"vDISABLEDDAYS"},{"av":"AV22DisabledDaysJson","fld":"vDISABLEDDAYSJSON"},{"av":"AV19DateToSearchFrom","fld":"vDATETOSEARCHFROM"},{"av":"AV18DatesToSearchTo","fld":"vDATESTOSEARCHTO"}]}""");
         setEventMetadata("'DOCREATEEVENT'","""{"handler":"E224U2","iparms":[{"av":"AV12Date","fld":"vDATE"}]""");
         setEventMetadata("'DOCREATEEVENT'",""","oparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"AV9CalendarEventsJson","fld":"vCALENDAREVENTSJSON"}]}""");
         setEventMetadata("CREATEEVENT_MODAL.ONLOADCOMPONENT","""{"handler":"E194U2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"AV9CalendarEventsJson","fld":"vCALENDAREVENTSJSON"},{"av":"AV7CalendarEventId","fld":"vCALENDAREVENTID"},{"av":"AV22DisabledDaysJson","fld":"vDISABLEDDAYSJSON"}]""");
         setEventMetadata("CREATEEVENT_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("'DOUACLEAR'","""{"handler":"E234U2","iparms":[{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"Calendaruc_Filtermode","ctrl":"CALENDARUC","prop":"FilterMode"},{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV10CalendarLoadFromDate","fld":"vCALENDARLOADFROMDATE"},{"av":"AV11CalendarLoadToDate","fld":"vCALENDARLOADTODATE"},{"av":"cmbavDatetypefilter"},{"av":"AV20DateTypeFilter","fld":"vDATETYPEFILTER","pic":"9"},{"av":"AV14DateFilter","fld":"vDATEFILTER"},{"av":"AV15DateRangeFilter","fld":"vDATERANGEFILTER"},{"av":"AV17DateRangeFilter_To","fld":"vDATERANGEFILTER_TO"},{"av":"AV36TitleFilter","fld":"vTITLEFILTER"},{"av":"AV19DateToSearchFrom","fld":"vDATETOSEARCHFROM"},{"av":"AV18DatesToSearchTo","fld":"vDATESTOSEARCHTO"},{"av":"AV13Date_ShowingDatesFrom","fld":"vDATE_SHOWINGDATESFROM"},{"av":"AV31LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV32LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV33LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV34LoadedToDate","fld":"vLOADEDTODATE"},{"av":"Calendaruc_Defaulteventstyle","ctrl":"CALENDARUC","prop":"DefaultEventStyle"},{"av":"AV25Events","fld":"vEVENTS"}]""");
         setEventMetadata("'DOUACLEAR'",""","oparms":[{"av":"Calendaruc_Filtermode","ctrl":"CALENDARUC","prop":"FilterMode"},{"av":"AV12Date","fld":"vDATE"},{"av":"cmbavDatetypefilter"},{"av":"AV20DateTypeFilter","fld":"vDATETYPEFILTER","pic":"9"},{"av":"AV15DateRangeFilter","fld":"vDATERANGEFILTER"},{"av":"AV17DateRangeFilter_To","fld":"vDATERANGEFILTER_TO"},{"av":"AV14DateFilter","fld":"vDATEFILTER"},{"av":"AV36TitleFilter","fld":"vTITLEFILTER"},{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"ctrl":"BTNDUMMYDELETE","prop":"Visible"},{"ctrl":"BTNUACLEAR","prop":"Visible"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV33LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV34LoadedToDate","fld":"vLOADEDTODATE"},{"av":"AV25Events","fld":"vEVENTS"},{"av":"AV31LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV32LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV21DisabledDays","fld":"vDISABLEDDAYS"},{"av":"AV22DisabledDaysJson","fld":"vDISABLEDDAYSJSON"},{"av":"AV19DateToSearchFrom","fld":"vDATETOSEARCHFROM"},{"av":"AV18DatesToSearchTo","fld":"vDATESTOSEARCHTO"}]}""");
         setEventMetadata("'DOUASEARCH'","""{"handler":"E244U2","iparms":[{"av":"Calendaruc_Filtermode","ctrl":"CALENDARUC","prop":"FilterMode"},{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV10CalendarLoadFromDate","fld":"vCALENDARLOADFROMDATE"},{"av":"AV11CalendarLoadToDate","fld":"vCALENDARLOADTODATE"},{"av":"cmbavDatetypefilter"},{"av":"AV20DateTypeFilter","fld":"vDATETYPEFILTER","pic":"9"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"AV14DateFilter","fld":"vDATEFILTER"},{"av":"AV15DateRangeFilter","fld":"vDATERANGEFILTER"},{"av":"AV17DateRangeFilter_To","fld":"vDATERANGEFILTER_TO"},{"av":"AV36TitleFilter","fld":"vTITLEFILTER"},{"av":"AV19DateToSearchFrom","fld":"vDATETOSEARCHFROM"},{"av":"AV18DatesToSearchTo","fld":"vDATESTOSEARCHTO"},{"av":"AV13Date_ShowingDatesFrom","fld":"vDATE_SHOWINGDATESFROM"},{"av":"AV31LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV32LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV33LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV34LoadedToDate","fld":"vLOADEDTODATE"},{"av":"Calendaruc_Defaulteventstyle","ctrl":"CALENDARUC","prop":"DefaultEventStyle"},{"av":"AV25Events","fld":"vEVENTS"}]""");
         setEventMetadata("'DOUASEARCH'",""","oparms":[{"av":"Calendaruc_Filtermode","ctrl":"CALENDARUC","prop":"FilterMode"},{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"ctrl":"BTNDUMMYDELETE","prop":"Visible"},{"ctrl":"BTNUACLEAR","prop":"Visible"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV33LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV34LoadedToDate","fld":"vLOADEDTODATE"},{"av":"AV25Events","fld":"vEVENTS"},{"av":"AV31LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV32LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV21DisabledDays","fld":"vDISABLEDDAYS"},{"av":"AV22DisabledDaysJson","fld":"vDISABLEDDAYSJSON"},{"av":"AV19DateToSearchFrom","fld":"vDATETOSEARCHFROM"},{"av":"AV18DatesToSearchTo","fld":"vDATESTOSEARCHTO"}]}""");
         setEventMetadata("CREATEEVENT_MODAL.CLOSE","""{"handler":"E184U2","iparms":[{"av":"Createevent_modal_Result","ctrl":"CREATEEVENT_MODAL","prop":"Result"},{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV10CalendarLoadFromDate","fld":"vCALENDARLOADFROMDATE"},{"av":"AV11CalendarLoadToDate","fld":"vCALENDARLOADTODATE"},{"av":"Calendaruc_Filtermode","ctrl":"CALENDARUC","prop":"FilterMode"},{"av":"AV7CalendarEventId","fld":"vCALENDAREVENTID"},{"av":"cmbavDatetypefilter"},{"av":"AV20DateTypeFilter","fld":"vDATETYPEFILTER","pic":"9"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"AV14DateFilter","fld":"vDATEFILTER"},{"av":"AV15DateRangeFilter","fld":"vDATERANGEFILTER"},{"av":"AV17DateRangeFilter_To","fld":"vDATERANGEFILTER_TO"},{"av":"AV36TitleFilter","fld":"vTITLEFILTER"},{"av":"AV19DateToSearchFrom","fld":"vDATETOSEARCHFROM"},{"av":"AV18DatesToSearchTo","fld":"vDATESTOSEARCHTO"},{"av":"AV13Date_ShowingDatesFrom","fld":"vDATE_SHOWINGDATESFROM"},{"av":"AV31LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV32LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV33LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV34LoadedToDate","fld":"vLOADEDTODATE"},{"av":"Calendaruc_Defaulteventstyle","ctrl":"CALENDARUC","prop":"DefaultEventStyle"},{"av":"AV25Events","fld":"vEVENTS"}]""");
         setEventMetadata("CREATEEVENT_MODAL.CLOSE",""","oparms":[{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV33LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV34LoadedToDate","fld":"vLOADEDTODATE"},{"av":"AV25Events","fld":"vEVENTS"},{"av":"AV31LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV32LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV21DisabledDays","fld":"vDISABLEDDAYS"},{"av":"AV22DisabledDaysJson","fld":"vDISABLEDDAYSJSON"},{"av":"Dvelop_confirmpanel_btndummydelete_Confirmationtext","ctrl":"DVELOP_CONFIRMPANEL_BTNDUMMYDELETE","prop":"ConfirmationText"},{"av":"AV19DateToSearchFrom","fld":"vDATETOSEARCHFROM"},{"av":"AV18DatesToSearchTo","fld":"vDATESTOSEARCHTO"}]}""");
         setEventMetadata("VDATE.CONTROLVALUECHANGED","""{"handler":"E254U2","iparms":[{"av":"AV12Date","fld":"vDATE"}]""");
         setEventMetadata("VDATE.CONTROLVALUECHANGED",""","oparms":[{"av":"AV6CalendarCurrentDate","fld":"vCALENDARCURRENTDATE"}]}""");
         setEventMetadata("CALENDARUC.EVENTDATEUPDATED","""{"handler":"E144U2","iparms":[{"av":"Calendaruc_Datetimeselected","ctrl":"CALENDARUC","prop":"DateTimeSelected"},{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV10CalendarLoadFromDate","fld":"vCALENDARLOADFROMDATE"},{"av":"AV11CalendarLoadToDate","fld":"vCALENDARLOADTODATE"},{"av":"Calendaruc_Filtermode","ctrl":"CALENDARUC","prop":"FilterMode"},{"av":"cmbavDatetypefilter"},{"av":"AV20DateTypeFilter","fld":"vDATETYPEFILTER","pic":"9"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"AV14DateFilter","fld":"vDATEFILTER"},{"av":"AV15DateRangeFilter","fld":"vDATERANGEFILTER"},{"av":"AV17DateRangeFilter_To","fld":"vDATERANGEFILTER_TO"},{"av":"AV36TitleFilter","fld":"vTITLEFILTER"},{"av":"AV19DateToSearchFrom","fld":"vDATETOSEARCHFROM"},{"av":"AV18DatesToSearchTo","fld":"vDATESTOSEARCHTO"},{"av":"AV13Date_ShowingDatesFrom","fld":"vDATE_SHOWINGDATESFROM"},{"av":"AV31LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV32LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV33LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV34LoadedToDate","fld":"vLOADEDTODATE"},{"av":"Calendaruc_Defaulteventstyle","ctrl":"CALENDARUC","prop":"DefaultEventStyle"},{"av":"AV25Events","fld":"vEVENTS"}]""");
         setEventMetadata("CALENDARUC.EVENTDATEUPDATED",""","oparms":[{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV33LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV34LoadedToDate","fld":"vLOADEDTODATE"},{"av":"AV25Events","fld":"vEVENTS"},{"av":"AV31LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV32LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV21DisabledDays","fld":"vDISABLEDDAYS"},{"av":"AV22DisabledDaysJson","fld":"vDISABLEDDAYSJSON"},{"av":"AV19DateToSearchFrom","fld":"vDATETOSEARCHFROM"},{"av":"AV18DatesToSearchTo","fld":"vDATESTOSEARCHTO"}]}""");
         setEventMetadata("CALENDARUC.EVENTSELECTED","""{"handler":"E134U2","iparms":[{"av":"Calendaruc_Itemselected","ctrl":"CALENDARUC","prop":"ItemSelected"}]""");
         setEventMetadata("CALENDARUC.EVENTSELECTED",""","oparms":[{"av":"AV7CalendarEventId","fld":"vCALENDAREVENTID"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]}""");
         setEventMetadata("CALENDARUC.DELETEEVENT","""{"handler":"E154U2","iparms":[{"av":"Calendaruc_Itemselected","ctrl":"CALENDARUC","prop":"ItemSelected"},{"av":"AV7CalendarEventId","fld":"vCALENDAREVENTID"}]""");
         setEventMetadata("CALENDARUC.DELETEEVENT",""","oparms":[{"av":"AV7CalendarEventId","fld":"vCALENDAREVENTID"},{"av":"Dvelop_confirmpanel_btndummydelete_Confirmationtext","ctrl":"DVELOP_CONFIRMPANEL_BTNDUMMYDELETE","prop":"ConfirmationText"}]}""");
         setEventMetadata("CALENDARUC.VISIBLEDATESCHANGED","""{"handler":"E164U2","iparms":[{"av":"AV10CalendarLoadFromDate","fld":"vCALENDARLOADFROMDATE"},{"av":"AV33LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV11CalendarLoadToDate","fld":"vCALENDARLOADTODATE"},{"av":"AV34LoadedToDate","fld":"vLOADEDTODATE"},{"av":"AV6CalendarCurrentDate","fld":"vCALENDARCURRENTDATE"},{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"Calendaruc_Filtermode","ctrl":"CALENDARUC","prop":"FilterMode"},{"av":"cmbavDatetypefilter"},{"av":"AV20DateTypeFilter","fld":"vDATETYPEFILTER","pic":"9"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"AV14DateFilter","fld":"vDATEFILTER"},{"av":"AV15DateRangeFilter","fld":"vDATERANGEFILTER"},{"av":"AV17DateRangeFilter_To","fld":"vDATERANGEFILTER_TO"},{"av":"AV36TitleFilter","fld":"vTITLEFILTER"},{"av":"AV19DateToSearchFrom","fld":"vDATETOSEARCHFROM"},{"av":"AV18DatesToSearchTo","fld":"vDATESTOSEARCHTO"},{"av":"AV13Date_ShowingDatesFrom","fld":"vDATE_SHOWINGDATESFROM"},{"av":"AV31LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV32LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"Calendaruc_Defaulteventstyle","ctrl":"CALENDARUC","prop":"DefaultEventStyle"},{"av":"AV25Events","fld":"vEVENTS"}]""");
         setEventMetadata("CALENDARUC.VISIBLEDATESCHANGED",""","oparms":[{"av":"AV12Date","fld":"vDATE"},{"av":"AV29ForceLoadDots","fld":"vFORCELOADDOTS"},{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV33LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV34LoadedToDate","fld":"vLOADEDTODATE"},{"av":"AV25Events","fld":"vEVENTS"},{"av":"AV31LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV32LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV21DisabledDays","fld":"vDISABLEDDAYS"},{"av":"AV22DisabledDaysJson","fld":"vDISABLEDDAYSJSON"},{"av":"AV19DateToSearchFrom","fld":"vDATETOSEARCHFROM"},{"av":"AV18DatesToSearchTo","fld":"vDATESTOSEARCHTO"}]}""");
         setEventMetadata("VDATE_SHOWINGDATESFROM.CONTROLVALUECHANGED","""{"handler":"E264U2","iparms":[{"av":"AV27EventsLoaded","fld":"vEVENTSLOADED"},{"av":"AV13Date_ShowingDatesFrom","fld":"vDATE_SHOWINGDATESFROM"},{"av":"AV31LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV32LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"},{"av":"AV33LoadedFromDate","fld":"vLOADEDFROMDATE"},{"av":"AV34LoadedToDate","fld":"vLOADEDTODATE"},{"av":"Calendaruc_Defaulteventstyle","ctrl":"CALENDARUC","prop":"DefaultEventStyle"},{"av":"AV25Events","fld":"vEVENTS"}]""");
         setEventMetadata("VDATE_SHOWINGDATESFROM.CONTROLVALUECHANGED",""","oparms":[{"av":"AV31LoadedDotsFromDate","fld":"vLOADEDDOTSFROMDATE"},{"av":"AV32LoadedDotsToDate","fld":"vLOADEDDOTSTODATE"}]}""");
         setEventMetadata("VDATETYPEFILTER.CLICK","""{"handler":"E114U1","iparms":[{"av":"cmbavDatetypefilter"},{"av":"AV20DateTypeFilter","fld":"vDATETYPEFILTER","pic":"9"}]""");
         setEventMetadata("VDATETYPEFILTER.CLICK",""","oparms":[{"av":"AV14DateFilter","fld":"vDATEFILTER"},{"av":"AV15DateRangeFilter","fld":"vDATERANGEFILTER"},{"av":"AV17DateRangeFilter_To","fld":"vDATERANGEFILTER_TO"},{"av":"edtavDaterangefilter_rangetext_Visible","ctrl":"vDATERANGEFILTER_RANGETEXT","prop":"Visible"},{"av":"divDaterangefilter_rangetext_cell_Class","ctrl":"DATERANGEFILTER_RANGETEXT_CELL","prop":"Class"},{"av":"edtavDatefilter_Visible","ctrl":"vDATEFILTER","prop":"Visible"},{"av":"divDatefilter_cell_Class","ctrl":"DATEFILTER_CELL","prop":"Class"}]}""");
         setEventMetadata("VALIDV_DATETYPEFILTER","""{"handler":"Validv_Datetypefilter","iparms":[]}""");
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
         Dvelop_confirmpanel_btndummydelete_Result = "";
         Createevent_modal_Result = "";
         Calendaruc_Datetimeselected = "";
         Calendaruc_Itemselected = "";
         Calendaruc_Eventactionselected = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gx_date = DateTime.MinValue;
         GXKey = "";
         AV25Events = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta_version2");
         AV21DisabledDays = new GxSimpleCollection<DateTime>();
         AV6CalendarCurrentDate = DateTime.MinValue;
         AV10CalendarLoadFromDate = DateTime.MinValue;
         AV11CalendarLoadToDate = DateTime.MinValue;
         AV15DateRangeFilter = DateTime.MinValue;
         AV17DateRangeFilter_To = DateTime.MinValue;
         AV7CalendarEventId = "";
         AV19DateToSearchFrom = DateTime.MinValue;
         AV18DatesToSearchTo = DateTime.MinValue;
         AV31LoadedDotsFromDate = DateTime.MinValue;
         AV32LoadedDotsToDate = DateTime.MinValue;
         AV33LoadedFromDate = DateTime.MinValue;
         AV34LoadedToDate = DateTime.MinValue;
         Gx_mode = "";
         AV9CalendarEventsJson = "";
         AV22DisabledDaysJson = "";
         AV5ActionSelected = "";
         AV8CalendarEvents = new WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtncreateevent_Jsonclick = "";
         AV12Date = DateTime.MinValue;
         lblWwp_search_Jsonclick = "";
         AV36TitleFilter = "";
         lblTextblockdatetypefilter_Jsonclick = "";
         AV16DateRangeFilter_RangeText = "";
         AV14DateFilter = DateTime.MinValue;
         bttBtnuaclear_Jsonclick = "";
         bttBtnuasearch_Jsonclick = "";
         ucCalendaruc = new GXUserControl();
         bttBtndummydelete_Jsonclick = "";
         ucDaterangefilter_rangepicker = new GXUserControl();
         AV13Date_ShowingDatesFrom = DateTime.MinValue;
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV38SelectedLanguage = "";
         GXt_SdtWWP_Calendar_Events_Item2 = new WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item(context);
         AV28EventTitle = "";
         ucDvelop_confirmpanel_btndummydelete = new GXUserControl();
         GXt_objcol_date4 = new GxSimpleCollection<DateTime>();
         AV23DotsFromDate = DateTime.MinValue;
         AV24DotsToDate = DateTime.MinValue;
         AV26EventsAux = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta_version2");
         AV37WWPDateRangePickerOptions = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions(context);
         GXt_SdtWWPDateRangePickerOptions5 = new WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions(context);
         GXt_objcol_SdtWWP_Calendar_Events_Item3 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item>( context, "Item", "Comforta_version2");
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         sStyleString = "";
         ucCreateevent_modal = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV20DateTypeFilter ;
      private short nCmpId ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtavDate_Enabled ;
      private int edtavTitlefilter_Enabled ;
      private int edtavDaterangefilter_rangetext_Visible ;
      private int edtavDaterangefilter_rangetext_Enabled ;
      private int edtavDatefilter_Visible ;
      private int edtavDatefilter_Enabled ;
      private int bttBtnuaclear_Visible ;
      private int bttBtndummydelete_Visible ;
      private int edtavDate_showingdatesfrom_Visible ;
      private int idxLst ;
      private string Dvelop_confirmpanel_btndummydelete_Result ;
      private string Calendaruc_Defaulteventstyle ;
      private string Createevent_modal_Result ;
      private string Calendaruc_Datetimeselected ;
      private string Calendaruc_Itemselected ;
      private string Calendaruc_Eventactionselected ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Gx_mode ;
      private string Calendaruc_Locale ;
      private string Calendaruc_Initialview ;
      private string Calendaruc_Viewstyle ;
      private string Calendaruc_Todaybuttonposition ;
      private string Calendaruc_Previousbuttonposition ;
      private string Calendaruc_Nextbuttonposition ;
      private string Calendaruc_Titleposition ;
      private string Calendaruc_Monthbuttonposition ;
      private string Calendaruc_Weekbuttonposition ;
      private string Calendaruc_Daybuttonposition ;
      private string Calendaruc_Yearbuttonposition ;
      private string Calendaruc_Listbuttonposition ;
      private string Calendaruc_Todaybuttontext ;
      private string Calendaruc_Monthbuttontext ;
      private string Calendaruc_Weekbuttontext ;
      private string Calendaruc_Daybuttontext ;
      private string Dvelop_confirmpanel_btndummydelete_Title ;
      private string Dvelop_confirmpanel_btndummydelete_Confirmationtext ;
      private string Dvelop_confirmpanel_btndummydelete_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_btndummydelete_Nobuttoncaption ;
      private string Dvelop_confirmpanel_btndummydelete_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_btndummydelete_Yesbuttonposition ;
      private string Dvelop_confirmpanel_btndummydelete_Confirmtype ;
      private string Createevent_modal_Width ;
      private string Createevent_modal_Title ;
      private string Createevent_modal_Confirmtype ;
      private string Createevent_modal_Bodytype ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTablecontent_Internalname ;
      private string divContent_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtncreateevent_Internalname ;
      private string bttBtncreateevent_Jsonclick ;
      private string edtavDate_Internalname ;
      private string edtavDate_Jsonclick ;
      private string lblWwp_search_Internalname ;
      private string lblWwp_search_Jsonclick ;
      private string edtavTitlefilter_Internalname ;
      private string edtavTitlefilter_Jsonclick ;
      private string divUnnamedtabledatetypefilter_Internalname ;
      private string lblTextblockdatetypefilter_Internalname ;
      private string lblTextblockdatetypefilter_Jsonclick ;
      private string cmbavDatetypefilter_Internalname ;
      private string cmbavDatetypefilter_Jsonclick ;
      private string divDaterangefilter_rangetext_cell_Internalname ;
      private string divDaterangefilter_rangetext_cell_Class ;
      private string edtavDaterangefilter_rangetext_Internalname ;
      private string edtavDaterangefilter_rangetext_Jsonclick ;
      private string divDatefilter_cell_Internalname ;
      private string divDatefilter_cell_Class ;
      private string edtavDatefilter_Internalname ;
      private string edtavDatefilter_Jsonclick ;
      private string bttBtnuaclear_Internalname ;
      private string bttBtnuaclear_Jsonclick ;
      private string bttBtnuasearch_Internalname ;
      private string bttBtnuasearch_Jsonclick ;
      private string Calendaruc_Internalname ;
      private string bttBtndummydelete_Internalname ;
      private string bttBtndummydelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Daterangefilter_rangepicker_Internalname ;
      private string edtavDate_showingdatesfrom_Internalname ;
      private string edtavDate_showingdatesfrom_Jsonclick ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string Dvelop_confirmpanel_btndummydelete_Internalname ;
      private string sStyleString ;
      private string tblTablecreateevent_modal_Internalname ;
      private string Createevent_modal_Internalname ;
      private string tblTabledvelop_confirmpanel_btndummydelete_Internalname ;
      private DateTime GXt_dtime1 ;
      private DateTime Gx_date ;
      private DateTime AV6CalendarCurrentDate ;
      private DateTime AV10CalendarLoadFromDate ;
      private DateTime AV11CalendarLoadToDate ;
      private DateTime AV15DateRangeFilter ;
      private DateTime AV17DateRangeFilter_To ;
      private DateTime AV19DateToSearchFrom ;
      private DateTime AV18DatesToSearchTo ;
      private DateTime AV31LoadedDotsFromDate ;
      private DateTime AV32LoadedDotsToDate ;
      private DateTime AV33LoadedFromDate ;
      private DateTime AV34LoadedToDate ;
      private DateTime AV12Date ;
      private DateTime AV14DateFilter ;
      private DateTime AV13Date_ShowingDatesFrom ;
      private DateTime AV23DotsFromDate ;
      private DateTime AV24DotsToDate ;
      private bool Calendaruc_Filtermode ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV29ForceLoadDots ;
      private bool AV27EventsLoaded ;
      private bool Calendaruc_Selectable ;
      private bool Calendaruc_Fixedweekcount ;
      private bool Calendaruc_Enabledayheaders ;
      private bool Calendaruc_Enableeventshoursperday ;
      private bool Calendaruc_Displayweeknumbers ;
      private bool Calendaruc_Navlinks ;
      private bool Calendaruc_Includeupdateinpopup ;
      private bool Calendaruc_Includedeleteinpopup ;
      private bool Calendaruc_Nowindicator ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wwpaux_wc ;
      private string AV9CalendarEventsJson ;
      private string AV22DisabledDaysJson ;
      private string AV7CalendarEventId ;
      private string AV5ActionSelected ;
      private string AV36TitleFilter ;
      private string AV16DateRangeFilter_RangeText ;
      private string AV38SelectedLanguage ;
      private string AV28EventTitle ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXUserControl ucCalendaruc ;
      private GXUserControl ucDaterangefilter_rangepicker ;
      private GXUserControl ucDvelop_confirmpanel_btndummydelete ;
      private GXUserControl ucCreateevent_modal ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDatetypefilter ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item> AV25Events ;
      private GxSimpleCollection<DateTime> AV21DisabledDays ;
      private WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item AV8CalendarEvents ;
      private WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item GXt_SdtWWP_Calendar_Events_Item2 ;
      private GxSimpleCollection<DateTime> GXt_objcol_date4 ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item> AV26EventsAux ;
      private WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions AV37WWPDateRangePickerOptions ;
      private WorkWithPlus.workwithplus_web.SdtWWPDateRangePickerOptions GXt_SdtWWPDateRangePickerOptions5 ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtWWP_Calendar_Events_Item> GXt_objcol_SdtWWP_Calendar_Events_Item3 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
