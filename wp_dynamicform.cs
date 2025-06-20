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
   public class wp_dynamicform : GXDataArea
   {
      public wp_dynamicform( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_dynamicform( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_WWPFormType ,
                           bool aP1_WWPFormIsForDynamicValidations ,
                           string aP2_TabCode )
      {
         this.AV20WWPFormType = aP0_WWPFormType;
         this.AV21WWPFormIsForDynamicValidations = aP1_WWPFormIsForDynamicValidations;
         this.AV8TabCode = aP2_TabCode;
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
            gxfirstwebparm = GetFirstPar( "WWPFormType");
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
               gxfirstwebparm = GetFirstPar( "WWPFormType");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "WWPFormType");
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
            return "wp_dynamicform_Execute" ;
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
         PAB22( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTB22( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
         GXEncryptionTmp = "wp_dynamicform.aspx"+UrlEncode(StringUtil.LTrimStr(AV20WWPFormType,1,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV21WWPFormIsForDynamicValidations)) + "," + UrlEncode(StringUtil.RTrim(AV8TabCode));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_dynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "WWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMVERSIONNUMBER", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vRECORDDESCRIPTION", AV17RecordDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vRECORDDESCRIPTION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17RecordDescription, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISCUSSIONS", AV19IsAuthorized_Discussions);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISCUSSIONS", GetSecureSignedToken( "", AV19IsAuthorized_Discussions, context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20WWPFormType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV20WWPFormType), "9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vWWPFORMISFORDYNAMICVALIDATIONS", AV21WWPFormIsForDynamicValidations);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMISFORDYNAMICVALIDATIONS", GetSecureSignedToken( "", AV21WWPFormIsForDynamicValidations, context));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV8TabCode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "WWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMVERSIONNUMBER", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vRECORDDESCRIPTION", AV17RecordDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vRECORDDESCRIPTION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17RecordDescription, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISCUSSIONS", AV19IsAuthorized_Discussions);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISCUSSIONS", GetSecureSignedToken( "", AV19IsAuthorized_Discussions, context));
         GxWebStd.gx_hidden_field( context, "WWPFORMTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A240WWPFormType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vWWPFORMISFORDYNAMICVALIDATIONS", AV21WWPFormIsForDynamicValidations);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMISFORDYNAMICVALIDATIONS", GetSecureSignedToken( "", AV21WWPFormIsForDynamicValidations, context));
         GxWebStd.gx_boolean_hidden_field( context, "vLOADALLTABS", AV12LoadAllTabs);
         GxWebStd.gx_hidden_field( context, "vSELECTEDTABCODE", StringUtil.RTrim( AV13SelectedTabCode));
         GxWebStd.gx_hidden_field( context, "vWWPFORMTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20WWPFormType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV20WWPFormType), "9"), context));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV8TabCode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icontype", StringUtil.RTrim( Ddc_subscriptions_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icon", StringUtil.RTrim( Ddc_subscriptions_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Tooltip", StringUtil.RTrim( Ddc_subscriptions_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Cls", StringUtil.RTrim( Ddc_subscriptions_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Visible", StringUtil.BoolToStr( Ddc_subscriptions_Visible));
         GxWebStd.gx_hidden_field( context, "DDC_DISCUSSIONS_Icontype", StringUtil.RTrim( Ddc_discussions_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_DISCUSSIONS_Icon", StringUtil.RTrim( Ddc_discussions_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_DISCUSSIONS_Tooltip", StringUtil.RTrim( Ddc_discussions_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDC_DISCUSSIONS_Cls", StringUtil.RTrim( Ddc_discussions_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_DISCUSSIONS_Visible", StringUtil.BoolToStr( Ddc_discussions_Visible));
         GxWebStd.gx_hidden_field( context, "TABS_Activepagecontrolname", StringUtil.RTrim( Tabs_Activepagecontrolname));
         GxWebStd.gx_hidden_field( context, "TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TABS_Class", StringUtil.RTrim( Tabs_Class));
         GxWebStd.gx_hidden_field( context, "TABS_Historymanagement", StringUtil.BoolToStr( Tabs_Historymanagement));
         GxWebStd.gx_hidden_field( context, "TABS_Activepagecontrolname", StringUtil.RTrim( Tabs_Activepagecontrolname));
         GxWebStd.gx_hidden_field( context, "TABS_Activepagecontrolname", StringUtil.RTrim( Tabs_Activepagecontrolname));
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
         if ( ! ( WebComp_Generaldynamicformwc == null ) )
         {
            WebComp_Generaldynamicformwc.componentjscripts();
         }
         if ( ! ( WebComp_Organisationdynamicformwc == null ) )
         {
            WebComp_Organisationdynamicformwc.componentjscripts();
         }
         if ( ! ( WebComp_Locationdynamicformwc == null ) )
         {
            WebComp_Locationdynamicformwc.componentjscripts();
         }
         if ( ! ( WebComp_Supplierdynamicformwc == null ) )
         {
            WebComp_Supplierdynamicformwc.componentjscripts();
         }
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
            WEB22( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTB22( ) ;
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
         GXEncryptionTmp = "wp_dynamicform.aspx"+UrlEncode(StringUtil.LTrimStr(AV20WWPFormType,1,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV21WWPFormIsForDynamicValidations)) + "," + UrlEncode(StringUtil.RTrim(AV8TabCode));
         return formatLink("wp_dynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WP_DynamicForm" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Dynamic Form", "") ;
      }

      protected void WBB20( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellWWLink", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableviewrightitems_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ViewCellRightItem", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ViewCellRightItem", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdc_discussions.SetProperty("IconType", Ddc_discussions_Icontype);
            ucDdc_discussions.SetProperty("Icon", Ddc_discussions_Icon);
            ucDdc_discussions.SetProperty("Caption", Ddc_discussions_Caption);
            ucDdc_discussions.SetProperty("Tooltip", Ddc_discussions_Tooltip);
            ucDdc_discussions.SetProperty("Cls", Ddc_discussions_Cls);
            ucDdc_discussions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_discussions_Internalname, "DDC_DISCUSSIONSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellViewTabsPosition TabsWithRightActions", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableviewcontainer_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellViewTab", "start", "top", "", "", "div");
            /* User Defined Control */
            ucTabs.SetProperty("PageCount", Tabs_Pagecount);
            ucTabs.SetProperty("Class", Tabs_Class);
            ucTabs.SetProperty("HistoryManagement", Tabs_Historymanagement);
            ucTabs.Render(context, "tab", Tabs_Internalname, "TABSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGeneraldynamicform_title_Internalname, context.GetMessage( "General Dynamic Form", ""), "", "", lblGeneraldynamicform_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_DynamicForm.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "GeneralDynamicForm") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablegeneraldynamicform_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0027"+"", StringUtil.RTrim( WebComp_Generaldynamicformwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0027"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Generaldynamicformwc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldGeneraldynamicformwc), StringUtil.Lower( WebComp_Generaldynamicformwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0027"+"");
                  }
                  WebComp_Generaldynamicformwc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldGeneraldynamicformwc), StringUtil.Lower( WebComp_Generaldynamicformwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblOrganisationdynamicform_title_Internalname, context.GetMessage( "Organisation Dynamic Form", ""), "", "", lblOrganisationdynamicform_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_DynamicForm.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "OrganisationDynamicForm") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableorganisationdynamicform_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0035"+"", StringUtil.RTrim( WebComp_Organisationdynamicformwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0035"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Organisationdynamicformwc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldOrganisationdynamicformwc), StringUtil.Lower( WebComp_Organisationdynamicformwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0035"+"");
                  }
                  WebComp_Organisationdynamicformwc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldOrganisationdynamicformwc), StringUtil.Lower( WebComp_Organisationdynamicformwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLocationdynamicform_title_Internalname, context.GetMessage( "Location Dynamic Form", ""), "", "", lblLocationdynamicform_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_DynamicForm.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "LocationDynamicForm") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablelocationdynamicform_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0043"+"", StringUtil.RTrim( WebComp_Locationdynamicformwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0043"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Locationdynamicformwc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldLocationdynamicformwc), StringUtil.Lower( WebComp_Locationdynamicformwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0043"+"");
                  }
                  WebComp_Locationdynamicformwc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldLocationdynamicformwc), StringUtil.Lower( WebComp_Locationdynamicformwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title4"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSupplierdynamicform_title_Internalname, context.GetMessage( "Supplier Dynamic Form", ""), "", "", lblSupplierdynamicform_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WP_DynamicForm.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "SupplierDynamicForm") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablesupplierdynamicform_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0051"+"", StringUtil.RTrim( WebComp_Supplierdynamicformwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0051"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Supplierdynamicformwc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldSupplierdynamicformwc), StringUtil.Lower( WebComp_Supplierdynamicformwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0051"+"");
                  }
                  WebComp_Supplierdynamicformwc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldSupplierdynamicformwc), StringUtil.Lower( WebComp_Supplierdynamicformwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0056"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0056"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0056"+"");
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

      protected void STARTB22( )
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
         Form.Meta.addItem("description", context.GetMessage( "Dynamic Form", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPB20( ) ;
      }

      protected void WSB22( )
      {
         STARTB22( ) ;
         EVTB22( ) ;
      }

      protected void EVTB22( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E11B22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_DISCUSSIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_discussions.Onloadcomponent */
                              E12B22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "TABS.TABCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Tabs.Tabchanged */
                              E13B22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E14B22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E15B22 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E16B22 ();
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
                        if ( nCmpId == 27 )
                        {
                           OldGeneraldynamicformwc = cgiGet( "W0027");
                           if ( ( StringUtil.Len( OldGeneraldynamicformwc) == 0 ) || ( StringUtil.StrCmp(OldGeneraldynamicformwc, WebComp_Generaldynamicformwc_Component) != 0 ) )
                           {
                              WebComp_Generaldynamicformwc = getWebComponent(GetType(), "GeneXus.Programs", OldGeneraldynamicformwc, new Object[] {context} );
                              WebComp_Generaldynamicformwc.ComponentInit();
                              WebComp_Generaldynamicformwc.Name = "OldGeneraldynamicformwc";
                              WebComp_Generaldynamicformwc_Component = OldGeneraldynamicformwc;
                           }
                           if ( StringUtil.Len( WebComp_Generaldynamicformwc_Component) != 0 )
                           {
                              WebComp_Generaldynamicformwc.componentprocess("W0027", "", sEvt);
                           }
                           WebComp_Generaldynamicformwc_Component = OldGeneraldynamicformwc;
                        }
                        else if ( nCmpId == 35 )
                        {
                           OldOrganisationdynamicformwc = cgiGet( "W0035");
                           if ( ( StringUtil.Len( OldOrganisationdynamicformwc) == 0 ) || ( StringUtil.StrCmp(OldOrganisationdynamicformwc, WebComp_Organisationdynamicformwc_Component) != 0 ) )
                           {
                              WebComp_Organisationdynamicformwc = getWebComponent(GetType(), "GeneXus.Programs", OldOrganisationdynamicformwc, new Object[] {context} );
                              WebComp_Organisationdynamicformwc.ComponentInit();
                              WebComp_Organisationdynamicformwc.Name = "OldOrganisationdynamicformwc";
                              WebComp_Organisationdynamicformwc_Component = OldOrganisationdynamicformwc;
                           }
                           if ( StringUtil.Len( WebComp_Organisationdynamicformwc_Component) != 0 )
                           {
                              WebComp_Organisationdynamicformwc.componentprocess("W0035", "", sEvt);
                           }
                           WebComp_Organisationdynamicformwc_Component = OldOrganisationdynamicformwc;
                        }
                        else if ( nCmpId == 43 )
                        {
                           OldLocationdynamicformwc = cgiGet( "W0043");
                           if ( ( StringUtil.Len( OldLocationdynamicformwc) == 0 ) || ( StringUtil.StrCmp(OldLocationdynamicformwc, WebComp_Locationdynamicformwc_Component) != 0 ) )
                           {
                              WebComp_Locationdynamicformwc = getWebComponent(GetType(), "GeneXus.Programs", OldLocationdynamicformwc, new Object[] {context} );
                              WebComp_Locationdynamicformwc.ComponentInit();
                              WebComp_Locationdynamicformwc.Name = "OldLocationdynamicformwc";
                              WebComp_Locationdynamicformwc_Component = OldLocationdynamicformwc;
                           }
                           if ( StringUtil.Len( WebComp_Locationdynamicformwc_Component) != 0 )
                           {
                              WebComp_Locationdynamicformwc.componentprocess("W0043", "", sEvt);
                           }
                           WebComp_Locationdynamicformwc_Component = OldLocationdynamicformwc;
                        }
                        else if ( nCmpId == 51 )
                        {
                           OldSupplierdynamicformwc = cgiGet( "W0051");
                           if ( ( StringUtil.Len( OldSupplierdynamicformwc) == 0 ) || ( StringUtil.StrCmp(OldSupplierdynamicformwc, WebComp_Supplierdynamicformwc_Component) != 0 ) )
                           {
                              WebComp_Supplierdynamicformwc = getWebComponent(GetType(), "GeneXus.Programs", OldSupplierdynamicformwc, new Object[] {context} );
                              WebComp_Supplierdynamicformwc.ComponentInit();
                              WebComp_Supplierdynamicformwc.Name = "OldSupplierdynamicformwc";
                              WebComp_Supplierdynamicformwc_Component = OldSupplierdynamicformwc;
                           }
                           if ( StringUtil.Len( WebComp_Supplierdynamicformwc_Component) != 0 )
                           {
                              WebComp_Supplierdynamicformwc.componentprocess("W0051", "", sEvt);
                           }
                           WebComp_Supplierdynamicformwc_Component = OldSupplierdynamicformwc;
                        }
                        else if ( nCmpId == 56 )
                        {
                           OldWwpaux_wc = cgiGet( "W0056");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0056", "", sEvt);
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

      protected void WEB22( )
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

      protected void PAB22( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_dynamicform.aspx")), "wp_dynamicform.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_dynamicform.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "WWPFormType");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV20WWPFormType = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV20WWPFormType", StringUtil.Str( (decimal)(AV20WWPFormType), 1, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV20WWPFormType), "9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV21WWPFormIsForDynamicValidations = StringUtil.StrToBool( GetPar( "WWPFormIsForDynamicValidations"));
                        AssignAttri("", false, "AV21WWPFormIsForDynamicValidations", AV21WWPFormIsForDynamicValidations);
                        GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMISFORDYNAMICVALIDATIONS", GetSecureSignedToken( "", AV21WWPFormIsForDynamicValidations, context));
                        AV8TabCode = GetPar( "TabCode");
                        AssignAttri("", false, "AV8TabCode", AV8TabCode);
                        GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
                     }
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
         RFB22( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFB22( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E15B22 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Generaldynamicformwc_Component) != 0 )
               {
                  WebComp_Generaldynamicformwc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Organisationdynamicformwc_Component) != 0 )
               {
                  WebComp_Organisationdynamicformwc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Locationdynamicformwc_Component) != 0 )
               {
                  WebComp_Locationdynamicformwc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Supplierdynamicformwc_Component) != 0 )
               {
                  WebComp_Supplierdynamicformwc.componentstart();
               }
            }
         }
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
            /* Using cursor H00B22 */
            pr_default.execute(0, new Object[] {AV20WWPFormType});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A207WWPFormVersionNumber = H00B22_A207WWPFormVersionNumber[0];
               A206WWPFormId = H00B22_A206WWPFormId[0];
               A240WWPFormType = H00B22_A240WWPFormType[0];
               /* Execute user event: Load */
               E16B22 ();
               pr_default.readNext(0);
            }
            pr_default.close(0);
            WBB20( ) ;
         }
      }

      protected void send_integrity_lvl_hashesB22( )
      {
         GxWebStd.gx_hidden_field( context, "WWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMVERSIONNUMBER", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vRECORDDESCRIPTION", AV17RecordDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vRECORDDESCRIPTION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17RecordDescription, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISCUSSIONS", AV19IsAuthorized_Discussions);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISCUSSIONS", GetSecureSignedToken( "", AV19IsAuthorized_Discussions, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUPB20( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E14B22 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Ddc_subscriptions_Icontype = cgiGet( "DDC_SUBSCRIPTIONS_Icontype");
            Ddc_subscriptions_Icon = cgiGet( "DDC_SUBSCRIPTIONS_Icon");
            Ddc_subscriptions_Tooltip = cgiGet( "DDC_SUBSCRIPTIONS_Tooltip");
            Ddc_subscriptions_Cls = cgiGet( "DDC_SUBSCRIPTIONS_Cls");
            Ddc_subscriptions_Visible = StringUtil.StrToBool( cgiGet( "DDC_SUBSCRIPTIONS_Visible"));
            Ddc_discussions_Icontype = cgiGet( "DDC_DISCUSSIONS_Icontype");
            Ddc_discussions_Icon = cgiGet( "DDC_DISCUSSIONS_Icon");
            Ddc_discussions_Tooltip = cgiGet( "DDC_DISCUSSIONS_Tooltip");
            Ddc_discussions_Cls = cgiGet( "DDC_DISCUSSIONS_Cls");
            Ddc_discussions_Visible = StringUtil.StrToBool( cgiGet( "DDC_DISCUSSIONS_Visible"));
            Tabs_Activepagecontrolname = cgiGet( "TABS_Activepagecontrolname");
            Tabs_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TABS_Pagecount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Tabs_Class = cgiGet( "TABS_Class");
            Tabs_Historymanagement = StringUtil.StrToBool( cgiGet( "TABS_Historymanagement"));
            Tabs_Activepagecontrolname = cgiGet( "TABS_Activepagecontrolname");
            /* Read variables values. */
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
         E14B22 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E14B22( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         AV24GXLvl8 = 0;
         /* Using cursor H00B23 */
         pr_default.execute(1, new Object[] {AV20WWPFormType});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A240WWPFormType = H00B23_A240WWPFormType[0];
            AV24GXLvl8 = 1;
            AV9Exists = true;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( AV24GXLvl8 == 0 )
         {
            Form.Caption = context.GetMessage( "WWP_RecordNotFound", "");
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            AV9Exists = false;
         }
         if ( AV9Exists )
         {
            AV13SelectedTabCode = AV8TabCode;
            AssignAttri("", false, "AV13SelectedTabCode", AV13SelectedTabCode);
            Tabs_Activepagecontrolname = AV13SelectedTabCode;
            ucTabs.SendProperty(context, "", false, Tabs_Internalname, "ActivePageControlName", Tabs_Activepagecontrolname);
            /* Execute user subroutine: 'LOADTABS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV17RecordDescription = Form.Caption;
         AssignAttri("", false, "AV17RecordDescription", AV17RecordDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vRECORDDESCRIPTION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17RecordDescription, "")), context));
         if ( StringUtil.StrCmp(AV18Session.Get("DiscussionThreadIdToOpen"), "") != 0 )
         {
            this.executeUsercontrolMethod("", false, "DDC_DISCUSSIONSContainer", "Open", "", new Object[] {});
         }
         Form.Caption = context.GetMessage( "Dynamic Forms", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8TabCode)) )
         {
            AV13SelectedTabCode = AV8TabCode;
            AssignAttri("", false, "AV13SelectedTabCode", AV13SelectedTabCode);
            AV23successful = AV22WebSession.Get(context.GetMessage( "DynamicFormCreationSuccess", ""));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23successful)) )
            {
               GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Success",  context.GetMessage( "Form created successfully", ""),  "success",  "",  "true",  ""));
               AV22WebSession.Remove(context.GetMessage( "DynamicFormCreationSuccess", ""));
            }
         }
         else
         {
            AV13SelectedTabCode = "GeneralDynamicForm";
            AssignAttri("", false, "AV13SelectedTabCode", AV13SelectedTabCode);
         }
         Tabs_Activepagecontrolname = AV13SelectedTabCode;
         ucTabs.SendProperty(context, "", false, Tabs_Internalname, "ActivePageControlName", Tabs_Activepagecontrolname);
         /* Execute user subroutine: 'LOADTABS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E15B22( )
      {
         /* Refresh Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.wwpbaseobjects.discussions.wwp_hasdiscussionmessages(context).executeUdp(  "WWP_Form",  StringUtil.Trim( StringUtil.Str( (decimal)(A206WWPFormId), 4, 0))+";"+StringUtil.Trim( StringUtil.Str( (decimal)(A207WWPFormVersionNumber), 4, 0))) )
         {
            Ddc_discussions_Icon = context.GetMessage( "far fa-comment", "");
            ucDdc_discussions.SendProperty(context, "", false, Ddc_discussions_Internalname, "Icon", Ddc_discussions_Icon);
         }
         if ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "WWP_Form",  2) )
         {
            Ddc_subscriptions_Visible = true;
            ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "Visible", StringUtil.BoolToStr( Ddc_subscriptions_Visible));
         }
         else
         {
            Ddc_subscriptions_Visible = false;
            ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "Visible", StringUtil.BoolToStr( Ddc_subscriptions_Visible));
         }
         GXt_boolean1 = AV19IsAuthorized_Discussions;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wwpdiscussionswc_Execute", out  GXt_boolean1) ;
         AV19IsAuthorized_Discussions = GXt_boolean1;
         AssignAttri("", false, "AV19IsAuthorized_Discussions", AV19IsAuthorized_Discussions);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISCUSSIONS", GetSecureSignedToken( "", AV19IsAuthorized_Discussions, context));
         if ( AV19IsAuthorized_Discussions )
         {
            Ddc_discussions_Visible = true;
            ucDdc_discussions.SendProperty(context, "", false, Ddc_discussions_Internalname, "Visible", StringUtil.BoolToStr( Ddc_discussions_Visible));
         }
         else
         {
            Ddc_discussions_Visible = false;
            ucDdc_discussions.SendProperty(context, "", false, Ddc_discussions_Internalname, "Visible", StringUtil.BoolToStr( Ddc_discussions_Visible));
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E16B22( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void E11B22( )
      {
         /* Ddc_subscriptions_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.subscriptions.wwp_subscriptionspanel", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0056",(string)"",(string)"WWP_Form",(short)2,StringUtil.Trim( StringUtil.Str( (decimal)(A206WWPFormId), 4, 0))+";"+StringUtil.Trim( StringUtil.Str( (decimal)(A207WWPFormVersionNumber), 4, 0)),(string)AV17RecordDescription});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)""+""+"",(string)"",(string)""+""+""+""+""+""+""+""+"",(string)"",(string)""+""+"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0056"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E12B22( )
      {
         /* Ddc_discussions_Onloadcomponent Routine */
         returnInSub = false;
         if ( AV19IsAuthorized_Discussions )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wwpaux_wc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.Discussions.WWP_DiscussionsWC")) != 0 )
            {
               WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.discussions.wwp_discussionswc", new Object[] {context} );
               WebComp_Wwpaux_wc.ComponentInit();
               WebComp_Wwpaux_wc.Name = "WWPBaseObjects.Discussions.WWP_DiscussionsWC";
               WebComp_Wwpaux_wc_Component = "WWPBaseObjects.Discussions.WWP_DiscussionsWC";
            }
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.setjustcreated();
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wp_dynamicform.aspx"+UrlEncode(StringUtil.LTrimStr(A240WWPFormType,1,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV21WWPFormIsForDynamicValidations)) + "," + UrlEncode(StringUtil.RTrim(""));
               WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0056",(string)"",(string)"WWP_Form",StringUtil.Trim( StringUtil.Str( (decimal)(A206WWPFormId), 4, 0))+";"+StringUtil.Trim( StringUtil.Str( (decimal)(A207WWPFormVersionNumber), 4, 0)),(string)AV17RecordDescription,formatLink("wp_dynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)});
               WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)""+""+"",(string)"",(string)""+""+""+""+""+""+""+""+"",(string)"",(string)""+""+"",(string)"",(string)""+"",(string)"",(string)"",(string)""+""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0056"+"");
               WebComp_Wwpaux_wc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
      }

      protected void E13B22( )
      {
         /* Tabs_Tabchanged Routine */
         returnInSub = false;
         AV13SelectedTabCode = Tabs_Activepagecontrolname;
         AssignAttri("", false, "AV13SelectedTabCode", AV13SelectedTabCode);
         AV12LoadAllTabs = false;
         AssignAttri("", false, "AV12LoadAllTabs", AV12LoadAllTabs);
         /* Execute user subroutine: 'LOADTABS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADTABS' Routine */
         returnInSub = false;
         if ( AV12LoadAllTabs || ( StringUtil.StrCmp(AV13SelectedTabCode, "") == 0 ) || ( StringUtil.StrCmp(AV13SelectedTabCode, "GeneralDynamicForm") == 0 ) )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Generaldynamicformwc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Generaldynamicformwc_Component), StringUtil.Lower( "WP_DynamicFormElementUFormWC")) != 0 )
            {
               WebComp_Generaldynamicformwc = getWebComponent(GetType(), "GeneXus.Programs", "wp_dynamicformelementuformwc", new Object[] {context} );
               WebComp_Generaldynamicformwc.ComponentInit();
               WebComp_Generaldynamicformwc.Name = "WP_DynamicFormElementUFormWC";
               WebComp_Generaldynamicformwc_Component = "WP_DynamicFormElementUFormWC";
            }
            if ( StringUtil.Len( WebComp_Generaldynamicformwc_Component) != 0 )
            {
               WebComp_Generaldynamicformwc.setjustcreated();
               WebComp_Generaldynamicformwc.componentprepare(new Object[] {(string)"W0027",(string)"",(short)AV20WWPFormType,(bool)AV21WWPFormIsForDynamicValidations});
               WebComp_Generaldynamicformwc.componentbind(new Object[] {(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Generaldynamicformwc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0027"+"");
               WebComp_Generaldynamicformwc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         if ( AV12LoadAllTabs || ( StringUtil.StrCmp(AV13SelectedTabCode, "OrganisationDynamicForm") == 0 ) )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Organisationdynamicformwc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Organisationdynamicformwc_Component), StringUtil.Lower( "WP_DynamicFormTrn_OrganisationDynamicFormWC")) != 0 )
            {
               WebComp_Organisationdynamicformwc = getWebComponent(GetType(), "GeneXus.Programs", "wp_dynamicformtrn_organisationdynamicformwc", new Object[] {context} );
               WebComp_Organisationdynamicformwc.ComponentInit();
               WebComp_Organisationdynamicformwc.Name = "WP_DynamicFormTrn_OrganisationDynamicFormWC";
               WebComp_Organisationdynamicformwc_Component = "WP_DynamicFormTrn_OrganisationDynamicFormWC";
            }
            if ( StringUtil.Len( WebComp_Organisationdynamicformwc_Component) != 0 )
            {
               WebComp_Organisationdynamicformwc.setjustcreated();
               WebComp_Organisationdynamicformwc.componentprepare(new Object[] {(string)"W0035",(string)"",(short)AV20WWPFormType,(bool)AV21WWPFormIsForDynamicValidations});
               WebComp_Organisationdynamicformwc.componentbind(new Object[] {(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Organisationdynamicformwc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0035"+"");
               WebComp_Organisationdynamicformwc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         if ( AV12LoadAllTabs || ( StringUtil.StrCmp(AV13SelectedTabCode, "LocationDynamicForm") == 0 ) )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Locationdynamicformwc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Locationdynamicformwc_Component), StringUtil.Lower( "WP_DynamicFormTrn_LocationDynamicFormWC")) != 0 )
            {
               WebComp_Locationdynamicformwc = getWebComponent(GetType(), "GeneXus.Programs", "wp_dynamicformtrn_locationdynamicformwc", new Object[] {context} );
               WebComp_Locationdynamicformwc.ComponentInit();
               WebComp_Locationdynamicformwc.Name = "WP_DynamicFormTrn_LocationDynamicFormWC";
               WebComp_Locationdynamicformwc_Component = "WP_DynamicFormTrn_LocationDynamicFormWC";
            }
            if ( StringUtil.Len( WebComp_Locationdynamicformwc_Component) != 0 )
            {
               WebComp_Locationdynamicformwc.setjustcreated();
               WebComp_Locationdynamicformwc.componentprepare(new Object[] {(string)"W0043",(string)"",(short)AV20WWPFormType,(bool)AV21WWPFormIsForDynamicValidations});
               WebComp_Locationdynamicformwc.componentbind(new Object[] {(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Locationdynamicformwc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0043"+"");
               WebComp_Locationdynamicformwc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         if ( AV12LoadAllTabs || ( StringUtil.StrCmp(AV13SelectedTabCode, "SupplierDynamicForm") == 0 ) )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Supplierdynamicformwc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Supplierdynamicformwc_Component), StringUtil.Lower( "WP_DynamicFormTrn_SupplierDynamicForm")) != 0 )
            {
               WebComp_Supplierdynamicformwc = getWebComponent(GetType(), "GeneXus.Programs", "wp_dynamicformtrn_supplierdynamicform", new Object[] {context} );
               WebComp_Supplierdynamicformwc.ComponentInit();
               WebComp_Supplierdynamicformwc.Name = "WP_DynamicFormTrn_SupplierDynamicForm";
               WebComp_Supplierdynamicformwc_Component = "WP_DynamicFormTrn_SupplierDynamicForm";
            }
            if ( StringUtil.Len( WebComp_Supplierdynamicformwc_Component) != 0 )
            {
               WebComp_Supplierdynamicformwc.setjustcreated();
               WebComp_Supplierdynamicformwc.componentprepare(new Object[] {(string)"W0051",(string)"",(short)AV20WWPFormType,(bool)AV21WWPFormIsForDynamicValidations});
               WebComp_Supplierdynamicformwc.componentbind(new Object[] {(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Supplierdynamicformwc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0051"+"");
               WebComp_Supplierdynamicformwc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV20WWPFormType = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV20WWPFormType", StringUtil.Str( (decimal)(AV20WWPFormType), 1, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV20WWPFormType), "9"), context));
         AV21WWPFormIsForDynamicValidations = (bool)getParm(obj,1);
         AssignAttri("", false, "AV21WWPFormIsForDynamicValidations", AV21WWPFormIsForDynamicValidations);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMISFORDYNAMICVALIDATIONS", GetSecureSignedToken( "", AV21WWPFormIsForDynamicValidations, context));
         AV8TabCode = (string)getParm(obj,2);
         AssignAttri("", false, "AV8TabCode", AV8TabCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
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
         PAB22( ) ;
         WSB22( ) ;
         WEB22( ) ;
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
         if ( ! ( WebComp_Generaldynamicformwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Generaldynamicformwc_Component) != 0 )
            {
               WebComp_Generaldynamicformwc.componentthemes();
            }
         }
         if ( ! ( WebComp_Organisationdynamicformwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Organisationdynamicformwc_Component) != 0 )
            {
               WebComp_Organisationdynamicformwc.componentthemes();
            }
         }
         if ( ! ( WebComp_Locationdynamicformwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Locationdynamicformwc_Component) != 0 )
            {
               WebComp_Locationdynamicformwc.componentthemes();
            }
         }
         if ( ! ( WebComp_Supplierdynamicformwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Supplierdynamicformwc_Component) != 0 )
            {
               WebComp_Supplierdynamicformwc.componentthemes();
            }
         }
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202562017143538", true, true);
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
         context.AddJavascriptSource("wp_dynamicform.js", "?202562017143538", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Ddc_discussions_Internalname = "DDC_DISCUSSIONS";
         divTableviewrightitems_Internalname = "TABLEVIEWRIGHTITEMS";
         lblGeneraldynamicform_title_Internalname = "GENERALDYNAMICFORM_TITLE";
         divUnnamedtablegeneraldynamicform_Internalname = "UNNAMEDTABLEGENERALDYNAMICFORM";
         lblOrganisationdynamicform_title_Internalname = "ORGANISATIONDYNAMICFORM_TITLE";
         divUnnamedtableorganisationdynamicform_Internalname = "UNNAMEDTABLEORGANISATIONDYNAMICFORM";
         lblLocationdynamicform_title_Internalname = "LOCATIONDYNAMICFORM_TITLE";
         divUnnamedtablelocationdynamicform_Internalname = "UNNAMEDTABLELOCATIONDYNAMICFORM";
         lblSupplierdynamicform_title_Internalname = "SUPPLIERDYNAMICFORM_TITLE";
         divUnnamedtablesupplierdynamicform_Internalname = "UNNAMEDTABLESUPPLIERDYNAMICFORM";
         Tabs_Internalname = "TABS";
         divUnnamedtableviewcontainer_Internalname = "UNNAMEDTABLEVIEWCONTAINER";
         divTablemain_Internalname = "TABLEMAIN";
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
         Ddc_discussions_Caption = "";
         Ddc_subscriptions_Caption = "";
         Tabs_Historymanagement = Convert.ToBoolean( -1);
         Tabs_Class = "ViewTab Tab";
         Tabs_Pagecount = 4;
         Ddc_discussions_Visible = Convert.ToBoolean( -1);
         Ddc_discussions_Cls = "DropDownComponent";
         Ddc_discussions_Tooltip = "WWP_Discussions_Tooltip";
         Ddc_discussions_Icon = "far fa-comment-dots";
         Ddc_discussions_Icontype = "FontIcon";
         Ddc_subscriptions_Visible = Convert.ToBoolean( -1);
         Ddc_subscriptions_Cls = "DropDownComponent";
         Ddc_subscriptions_Tooltip = "WWP_Subscriptions_Tooltip";
         Ddc_subscriptions_Icon = "fas fa-rss";
         Ddc_subscriptions_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Dynamic Form", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV17RecordDescription","fld":"vRECORDDESCRIPTION","hsh":true},{"av":"AV19IsAuthorized_Discussions","fld":"vISAUTHORIZED_DISCUSSIONS","hsh":true},{"av":"AV21WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV20WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV8TabCode","fld":"vTABCODE","hsh":true},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9","hsh":true},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"Ddc_discussions_Icon","ctrl":"DDC_DISCUSSIONS","prop":"Icon"},{"av":"Ddc_subscriptions_Visible","ctrl":"DDC_SUBSCRIPTIONS","prop":"Visible"},{"av":"AV19IsAuthorized_Discussions","fld":"vISAUTHORIZED_DISCUSSIONS","hsh":true},{"av":"Ddc_discussions_Visible","ctrl":"DDC_DISCUSSIONS","prop":"Visible"}]}""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","""{"handler":"E11B22","iparms":[{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9","hsh":true},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9","hsh":true},{"av":"AV17RecordDescription","fld":"vRECORDDESCRIPTION","hsh":true}]""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("DDC_DISCUSSIONS.ONLOADCOMPONENT","""{"handler":"E12B22","iparms":[{"av":"AV19IsAuthorized_Discussions","fld":"vISAUTHORIZED_DISCUSSIONS","hsh":true},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9","hsh":true},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9","hsh":true},{"av":"AV17RecordDescription","fld":"vRECORDDESCRIPTION","hsh":true},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9"},{"av":"AV21WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true}]""");
         setEventMetadata("DDC_DISCUSSIONS.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("TABS.TABCHANGED","""{"handler":"E13B22","iparms":[{"av":"Tabs_Activepagecontrolname","ctrl":"TABS","prop":"ActivePageControlName"},{"av":"AV12LoadAllTabs","fld":"vLOADALLTABS"},{"av":"AV13SelectedTabCode","fld":"vSELECTEDTABCODE"},{"av":"AV20WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV21WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true}]""");
         setEventMetadata("TABS.TABCHANGED",""","oparms":[{"av":"AV13SelectedTabCode","fld":"vSELECTEDTABCODE"},{"av":"AV12LoadAllTabs","fld":"vLOADALLTABS"},{"ctrl":"GENERALDYNAMICFORMWC"},{"ctrl":"ORGANISATIONDYNAMICFORMWC"},{"ctrl":"LOCATIONDYNAMICFORMWC"},{"ctrl":"SUPPLIERDYNAMICFORMWC"}]}""");
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
         wcpOAV8TabCode = "";
         Tabs_Activepagecontrolname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV17RecordDescription = "";
         AV13SelectedTabCode = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDdc_subscriptions = new GXUserControl();
         ucDdc_discussions = new GXUserControl();
         ucTabs = new GXUserControl();
         lblGeneraldynamicform_title_Jsonclick = "";
         WebComp_Generaldynamicformwc_Component = "";
         OldGeneraldynamicformwc = "";
         lblOrganisationdynamicform_title_Jsonclick = "";
         WebComp_Organisationdynamicformwc_Component = "";
         OldOrganisationdynamicformwc = "";
         lblLocationdynamicform_title_Jsonclick = "";
         WebComp_Locationdynamicformwc_Component = "";
         OldLocationdynamicformwc = "";
         lblSupplierdynamicform_title_Jsonclick = "";
         WebComp_Supplierdynamicformwc_Component = "";
         OldSupplierdynamicformwc = "";
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H00B22_A207WWPFormVersionNumber = new short[1] ;
         H00B22_A206WWPFormId = new short[1] ;
         H00B22_A240WWPFormType = new short[1] ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H00B23_A206WWPFormId = new short[1] ;
         H00B23_A207WWPFormVersionNumber = new short[1] ;
         H00B23_A240WWPFormType = new short[1] ;
         AV18Session = context.GetSession();
         AV23successful = "";
         AV22WebSession = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_dynamicform__default(),
            new Object[][] {
                new Object[] {
               H00B22_A207WWPFormVersionNumber, H00B22_A206WWPFormId, H00B22_A240WWPFormType
               }
               , new Object[] {
               H00B23_A206WWPFormId, H00B23_A207WWPFormVersionNumber, H00B23_A240WWPFormType
               }
            }
         );
         WebComp_Generaldynamicformwc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Organisationdynamicformwc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Locationdynamicformwc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Supplierdynamicformwc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV20WWPFormType ;
      private short wcpOAV20WWPFormType ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short A240WWPFormType ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV24GXLvl8 ;
      private short nGXWrapped ;
      private int Tabs_Pagecount ;
      private int idxLst ;
      private string AV8TabCode ;
      private string wcpOAV8TabCode ;
      private string Tabs_Activepagecontrolname ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV13SelectedTabCode ;
      private string Ddc_subscriptions_Icontype ;
      private string Ddc_subscriptions_Icon ;
      private string Ddc_subscriptions_Tooltip ;
      private string Ddc_subscriptions_Cls ;
      private string Ddc_discussions_Icontype ;
      private string Ddc_discussions_Icon ;
      private string Ddc_discussions_Tooltip ;
      private string Ddc_discussions_Cls ;
      private string Tabs_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableviewrightitems_Internalname ;
      private string Ddc_subscriptions_Caption ;
      private string Ddc_subscriptions_Internalname ;
      private string Ddc_discussions_Caption ;
      private string Ddc_discussions_Internalname ;
      private string divUnnamedtableviewcontainer_Internalname ;
      private string Tabs_Internalname ;
      private string lblGeneraldynamicform_title_Internalname ;
      private string lblGeneraldynamicform_title_Jsonclick ;
      private string divUnnamedtablegeneraldynamicform_Internalname ;
      private string WebComp_Generaldynamicformwc_Component ;
      private string OldGeneraldynamicformwc ;
      private string lblOrganisationdynamicform_title_Internalname ;
      private string lblOrganisationdynamicform_title_Jsonclick ;
      private string divUnnamedtableorganisationdynamicform_Internalname ;
      private string WebComp_Organisationdynamicformwc_Component ;
      private string OldOrganisationdynamicformwc ;
      private string lblLocationdynamicform_title_Internalname ;
      private string lblLocationdynamicform_title_Jsonclick ;
      private string divUnnamedtablelocationdynamicform_Internalname ;
      private string WebComp_Locationdynamicformwc_Component ;
      private string OldLocationdynamicformwc ;
      private string lblSupplierdynamicform_title_Internalname ;
      private string lblSupplierdynamicform_title_Jsonclick ;
      private string divUnnamedtablesupplierdynamicform_Internalname ;
      private string WebComp_Supplierdynamicformwc_Component ;
      private string OldSupplierdynamicformwc ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string AV23successful ;
      private bool AV21WWPFormIsForDynamicValidations ;
      private bool wcpOAV21WWPFormIsForDynamicValidations ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV19IsAuthorized_Discussions ;
      private bool AV12LoadAllTabs ;
      private bool Ddc_subscriptions_Visible ;
      private bool Ddc_discussions_Visible ;
      private bool Tabs_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV9Exists ;
      private bool GXt_boolean1 ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool bDynCreated_Generaldynamicformwc ;
      private bool bDynCreated_Organisationdynamicformwc ;
      private bool bDynCreated_Locationdynamicformwc ;
      private bool bDynCreated_Supplierdynamicformwc ;
      private string AV17RecordDescription ;
      private IGxSession AV18Session ;
      private IGxSession AV22WebSession ;
      private GXWebComponent WebComp_Generaldynamicformwc ;
      private GXWebComponent WebComp_Organisationdynamicformwc ;
      private GXWebComponent WebComp_Locationdynamicformwc ;
      private GXWebComponent WebComp_Supplierdynamicformwc ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDdc_discussions ;
      private GXUserControl ucTabs ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H00B22_A207WWPFormVersionNumber ;
      private short[] H00B22_A206WWPFormId ;
      private short[] H00B22_A240WWPFormType ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private short[] H00B23_A206WWPFormId ;
      private short[] H00B23_A207WWPFormVersionNumber ;
      private short[] H00B23_A240WWPFormType ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wp_dynamicform__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00B22;
          prmH00B22 = new Object[] {
          new ParDef("AV20WWPFormType",GXType.Int16,1,0)
          };
          Object[] prmH00B23;
          prmH00B23 = new Object[] {
          new ParDef("AV20WWPFormType",GXType.Int16,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00B22", "SELECT WWPFormVersionNumber, WWPFormId, WWPFormType FROM WWP_Form WHERE WWPFormType = :AV20WWPFormType ORDER BY WWPFormId, WWPFormVersionNumber ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00B22,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00B23", "SELECT WWPFormId, WWPFormVersionNumber, WWPFormType FROM WWP_Form WHERE WWPFormType = :AV20WWPFormType ORDER BY WWPFormId, WWPFormVersionNumber ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00B23,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
