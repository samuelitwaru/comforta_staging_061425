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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_visualizenotification : GXDataArea
   {
      public wwp_visualizenotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_visualizenotification( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_WWPNotificationId )
      {
         this.AV7WWPNotificationId = aP0_WWPNotificationId;
         ExecuteImpl();
         aP0_WWPNotificationId=this.AV7WWPNotificationId;
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
            gxfirstwebparm = GetFirstPar( "WWPNotificationId");
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
               gxfirstwebparm = GetFirstPar( "WWPNotificationId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "WWPNotificationId");
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
            return "wwpvisualizenotification_Execute" ;
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
         PA1K2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1K2( ) ;
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx"+UrlEncode(StringUtil.LTrimStr(AV7WWPNotificationId,10,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vWWPNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPNotificationId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
            WE1K2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1K2( ) ;
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx"+UrlEncode(StringUtil.LTrimStr(AV7WWPNotificationId,10,0));
         return formatLink("wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Common.WWP_VisualizeNotification" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Visualize one notification", "") ;
      }

      protected void WB1K0( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, divTablemain_Width, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefscard_Internalname, 1, 0, "px", 0, "px", "NotificationCardTable", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPaddingTop5", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNotificationitemicon_Internalname, context.GetMessage( "<i class='fas fa-pencil-alt NotificationFontIconSuccess'></i>", ""), "", "", lblNotificationitemicon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WWPBaseObjects/Notifications/Common/WWP_VisualizeNotification.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtWWPNotificationTitle_Internalname, context.GetMessage( "Notification Title", ""), "gx-form-item SimpleCardAttributeTitleLabel", 0, true, "width: 25%;");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            ClassString = "SimpleCardAttributeTitle";
            StyleString = "";
            ClassString = "SimpleCardAttributeTitle";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtWWPNotificationTitle_Internalname, A182WWPNotificationTitle, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", 0, 1, edtWWPNotificationTitle_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_VisualizeNotification.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginLeft CellPaddingTop5", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtWWPNotificationCreated_Internalname, context.GetMessage( "Notification Created Date", ""), "gx-form-item NotificationItemDatetimeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtWWPNotificationCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtWWPNotificationCreated_Internalname, context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A129WWPNotificationCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',12,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationCreated_Jsonclick, 0, "NotificationItemDatetime", "", "", "", "", 1, edtWWPNotificationCreated_Enabled, 0, "text", "", 27, "chr", 1, "row", 27, 0, 0, 0, 0, -1, 0, true, "WorkWithPlus_Web\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_VisualizeNotification.htm");
            GxWebStd.gx_bitmap( context, edtWWPNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_VisualizeNotification.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginLeft", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMarkasread_Internalname, lblMarkasread_Caption, "", "", lblMarkasread_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOMARKASREAD\\'."+"'", "", "TextBlock", 5, lblMarkasread_Tooltiptext, 1, 1, 0, 1, "HLP_WWPBaseObjects/Notifications/Common/WWP_VisualizeNotification.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtWWPNotificationShortDescriptio_Internalname, context.GetMessage( "Notification Short Description", ""), "col-sm-3 CardNotificationAttributeDescriptionLabel", 0, true, "");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            ClassString = "CardNotificationAttributeDescription";
            StyleString = "";
            ClassString = "CardNotificationAttributeDescription";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtWWPNotificationShortDescriptio_Internalname, A183WWPNotificationShortDescriptio, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", 0, 1, edtWWPNotificationShortDescriptio_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects/Notifications/Common/WWP_VisualizeNotification.htm");
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
         }
         wbLoad = true;
      }

      protected void START1K2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Visualize one notification", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1K0( ) ;
      }

      protected void WS1K2( )
      {
         START1K2( ) ;
         EVT1K2( ) ;
      }

      protected void EVT1K2( )
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
                              E111K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOMARKASREAD'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoMarkAsRead' */
                              E121K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E131K2 ();
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE1K2( )
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

      protected void PA1K2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx")), "wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx")))) ;
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
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "WWPNotificationId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV7WWPNotificationId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV7WWPNotificationId", StringUtil.LTrimStr( (decimal)(AV7WWPNotificationId), 10, 0));
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
         RF1K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF1K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H001K2 */
            pr_default.execute(0, new Object[] {AV7WWPNotificationId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A127WWPNotificationId = H001K2_A127WWPNotificationId[0];
               A187WWPNotificationIsRead = H001K2_A187WWPNotificationIsRead[0];
               A183WWPNotificationShortDescriptio = H001K2_A183WWPNotificationShortDescriptio[0];
               AssignAttri("", false, "A183WWPNotificationShortDescriptio", A183WWPNotificationShortDescriptio);
               A129WWPNotificationCreated = H001K2_A129WWPNotificationCreated[0];
               AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A182WWPNotificationTitle = H001K2_A182WWPNotificationTitle[0];
               AssignAttri("", false, "A182WWPNotificationTitle", A182WWPNotificationTitle);
               /* Execute user event: Load */
               E131K2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB1K0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes1K2( )
      {
      }

      protected void before_start_formulas( )
      {
         edtWWPNotificationTitle_Enabled = 0;
         AssignProp("", false, edtWWPNotificationTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationTitle_Enabled), 5, 0), true);
         edtWWPNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationCreated_Enabled), 5, 0), true);
         edtWWPNotificationShortDescriptio_Enabled = 0;
         AssignProp("", false, edtWWPNotificationShortDescriptio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationShortDescriptio_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E111K2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            A182WWPNotificationTitle = cgiGet( edtWWPNotificationTitle_Internalname);
            AssignAttri("", false, "A182WWPNotificationTitle", A182WWPNotificationTitle);
            A129WWPNotificationCreated = context.localUtil.CToT( cgiGet( edtWWPNotificationCreated_Internalname));
            AssignAttri("", false, "A129WWPNotificationCreated", context.localUtil.TToC( A129WWPNotificationCreated, 10, 12, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A183WWPNotificationShortDescriptio = cgiGet( edtWWPNotificationShortDescriptio_Internalname);
            AssignAttri("", false, "A183WWPNotificationShortDescriptio", A183WWPNotificationShortDescriptio);
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
         E111K2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E111K2( )
      {
         /* Start Routine */
         returnInSub = false;
         divTablemain_Width = 700;
         AssignProp("", false, divTablemain_Internalname, "Width", StringUtil.LTrimStr( (decimal)(divTablemain_Width), 9, 0), true);
         /* Using cursor H001K3 */
         pr_default.execute(1, new Object[] {AV7WWPNotificationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A127WWPNotificationId = H001K3_A127WWPNotificationId[0];
            A112WWPUserExtendedId = H001K3_A112WWPUserExtendedId[0];
            n112WWPUserExtendedId = H001K3_n112WWPUserExtendedId[0];
            A184WWPNotificationLink = H001K3_A184WWPNotificationLink[0];
            A165WWPNotificationMetadata = H001K3_A165WWPNotificationMetadata[0];
            n165WWPNotificationMetadata = H001K3_n165WWPNotificationMetadata[0];
            if ( StringUtil.StrCmp(A112WWPUserExtendedId, new WorkWithPlus.workwithplus_commongam.wwp_getloggeduserid(context).executeUdp( )) != 0 )
            {
               CallWebObject(formatLink("gamexamplenotauthorized.aspx") );
               context.wjLocDisableFrm = 1;
            }
            new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_changenotificationstatus(context ).gxep_setnotificationreadbyid( ref  A127WWPNotificationId) ;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A184WWPNotificationLink)) )
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A165WWPNotificationMetadata)) )
               {
                  AV9WWPNotificationMetadataSDT.FromJSonString(A165WWPNotificationMetadata, null);
                  AV8WebSession.Set(AV9WWPNotificationMetadataSDT.gxTpr_Sessionkey, AV9WWPNotificationMetadataSDT.gxTpr_Sessionvalue);
               }
               CallWebObject(formatLink(A184WWPNotificationLink) );
               context.wjLocDisableFrm = 0;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
      }

      protected void E121K2( )
      {
         /* 'DoMarkAsRead' Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_changenotificationstatus(context ).gxep_setnotificationreadunreadbyid( ref  AV7WWPNotificationId) ;
         context.DoAjaxRefresh();
      }

      protected void nextLoad( )
      {
      }

      protected void E131K2( )
      {
         /* Load Routine */
         returnInSub = false;
         if ( A187WWPNotificationIsRead )
         {
            lblMarkasread_Caption = "<i class=\"fas fa-envelope DiscussionsSendIcon\"></i>";
            AssignProp("", false, lblMarkasread_Internalname, "Caption", lblMarkasread_Caption, true);
            lblMarkasread_Tooltiptext = context.GetMessage( "Mark as unread", "");
            AssignProp("", false, lblMarkasread_Internalname, "Tooltiptext", lblMarkasread_Tooltiptext, true);
         }
         else
         {
            lblMarkasread_Caption = "<i class=\"fas fa-envelope-open DiscussionsSendIcon\"></i>";
            AssignProp("", false, lblMarkasread_Internalname, "Caption", lblMarkasread_Caption, true);
            lblMarkasread_Tooltiptext = context.GetMessage( "Mark as read", "");
            AssignProp("", false, lblMarkasread_Internalname, "Tooltiptext", lblMarkasread_Tooltiptext, true);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7WWPNotificationId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV7WWPNotificationId", StringUtil.LTrimStr( (decimal)(AV7WWPNotificationId), 10, 0));
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
         PA1K2( ) ;
         WS1K2( ) ;
         WE1K2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025614539786", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/notifications/common/wwp_visualizenotification.js", "?2025614539786", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblNotificationitemicon_Internalname = "NOTIFICATIONITEMICON";
         edtWWPNotificationTitle_Internalname = "WWPNOTIFICATIONTITLE";
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED";
         lblMarkasread_Internalname = "MARKASREAD";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         edtWWPNotificationShortDescriptio_Internalname = "WWPNOTIFICATIONSHORTDESCRIPTIO";
         divTablecontent_Internalname = "TABLECONTENT";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTablefscard_Internalname = "TABLEFSCARD";
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
         edtWWPNotificationShortDescriptio_Enabled = 0;
         lblMarkasread_Tooltiptext = "";
         lblMarkasread_Caption = context.GetMessage( "<i class=\"fas fa-envelope-open DiscussionsSendIcon\"></i>", "");
         edtWWPNotificationCreated_Jsonclick = "";
         edtWWPNotificationCreated_Enabled = 0;
         edtWWPNotificationTitle_Enabled = 0;
         divTablemain_Width = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Visualize one notification", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV7WWPNotificationId","fld":"vWWPNOTIFICATIONID","pic":"ZZZZZZZZZ9"}]}""");
         setEventMetadata("'DOMARKASREAD'","""{"handler":"E121K2","iparms":[{"av":"AV7WWPNotificationId","fld":"vWWPNOTIFICATIONID","pic":"ZZZZZZZZZ9"}]}""");
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
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblNotificationitemicon_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         A182WWPNotificationTitle = "";
         A129WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         lblMarkasread_Jsonclick = "";
         A183WWPNotificationShortDescriptio = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H001K2_A127WWPNotificationId = new long[1] ;
         H001K2_A187WWPNotificationIsRead = new bool[] {false} ;
         H001K2_A183WWPNotificationShortDescriptio = new string[] {""} ;
         H001K2_A129WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         H001K2_A182WWPNotificationTitle = new string[] {""} ;
         H001K3_A127WWPNotificationId = new long[1] ;
         H001K3_A112WWPUserExtendedId = new string[] {""} ;
         H001K3_n112WWPUserExtendedId = new bool[] {false} ;
         H001K3_A184WWPNotificationLink = new string[] {""} ;
         H001K3_A165WWPNotificationMetadata = new string[] {""} ;
         H001K3_n165WWPNotificationMetadata = new bool[] {false} ;
         A112WWPUserExtendedId = "";
         A184WWPNotificationLink = "";
         A165WWPNotificationMetadata = "";
         AV9WWPNotificationMetadataSDT = new WorkWithPlus.workwithplus_notificationscommon.SdtWWP_SDTNotificationMetadata(context);
         AV8WebSession = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_visualizenotification__default(),
            new Object[][] {
                new Object[] {
               H001K2_A127WWPNotificationId, H001K2_A187WWPNotificationIsRead, H001K2_A183WWPNotificationShortDescriptio, H001K2_A129WWPNotificationCreated, H001K2_A182WWPNotificationTitle
               }
               , new Object[] {
               H001K3_A127WWPNotificationId, H001K3_A112WWPUserExtendedId, H001K3_n112WWPUserExtendedId, H001K3_A184WWPNotificationLink, H001K3_A165WWPNotificationMetadata, H001K3_n165WWPNotificationMetadata
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
      private int divTablemain_Width ;
      private int edtWWPNotificationTitle_Enabled ;
      private int edtWWPNotificationCreated_Enabled ;
      private int edtWWPNotificationShortDescriptio_Enabled ;
      private int idxLst ;
      private long AV7WWPNotificationId ;
      private long wcpOAV7WWPNotificationId ;
      private long A127WWPNotificationId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTablefscard_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string lblNotificationitemicon_Internalname ;
      private string lblNotificationitemicon_Jsonclick ;
      private string divTablecontent_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string edtWWPNotificationTitle_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string edtWWPNotificationCreated_Internalname ;
      private string edtWWPNotificationCreated_Jsonclick ;
      private string lblMarkasread_Internalname ;
      private string lblMarkasread_Caption ;
      private string lblMarkasread_Jsonclick ;
      private string lblMarkasread_Tooltiptext ;
      private string edtWWPNotificationShortDescriptio_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string A112WWPUserExtendedId ;
      private DateTime A129WWPNotificationCreated ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool A187WWPNotificationIsRead ;
      private bool returnInSub ;
      private bool n112WWPUserExtendedId ;
      private bool n165WWPNotificationMetadata ;
      private string A165WWPNotificationMetadata ;
      private string A182WWPNotificationTitle ;
      private string A183WWPNotificationShortDescriptio ;
      private string A184WWPNotificationLink ;
      private IGxSession AV8WebSession ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP0_WWPNotificationId ;
      private IDataStoreProvider pr_default ;
      private long[] H001K2_A127WWPNotificationId ;
      private bool[] H001K2_A187WWPNotificationIsRead ;
      private string[] H001K2_A183WWPNotificationShortDescriptio ;
      private DateTime[] H001K2_A129WWPNotificationCreated ;
      private string[] H001K2_A182WWPNotificationTitle ;
      private long[] H001K3_A127WWPNotificationId ;
      private string[] H001K3_A112WWPUserExtendedId ;
      private bool[] H001K3_n112WWPUserExtendedId ;
      private string[] H001K3_A184WWPNotificationLink ;
      private string[] H001K3_A165WWPNotificationMetadata ;
      private bool[] H001K3_n165WWPNotificationMetadata ;
      private WorkWithPlus.workwithplus_notificationscommon.SdtWWP_SDTNotificationMetadata AV9WWPNotificationMetadataSDT ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_visualizenotification__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH001K2;
          prmH001K2 = new Object[] {
          new ParDef("AV7WWPNotificationId",GXType.Int64,10,0)
          };
          Object[] prmH001K3;
          prmH001K3 = new Object[] {
          new ParDef("AV7WWPNotificationId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001K2", "SELECT WWPNotificationId, WWPNotificationIsRead, WWPNotificationShortDescriptio, WWPNotificationCreated, WWPNotificationTitle FROM WWP_Notification WHERE WWPNotificationId = :AV7WWPNotificationId ORDER BY WWPNotificationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001K2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H001K3", "SELECT WWPNotificationId, WWPUserExtendedId, WWPNotificationLink, WWPNotificationMetadata FROM WWP_Notification WHERE WWPNotificationId = :AV7WWPNotificationId ORDER BY WWPNotificationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001K3,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
