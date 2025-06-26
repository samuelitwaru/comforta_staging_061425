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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wp_applicationdesign : GXDataArea
   {
      public wp_applicationdesign( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_applicationdesign( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_Trn_PageId )
      {
         this.AV14Trn_PageId = aP0_Trn_PageId;
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
            gxfirstwebparm = GetFirstPar( "Trn_PageId");
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
               gxfirstwebparm = GetFirstPar( "Trn_PageId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Trn_PageId");
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
            return "wp_applicationdesign_Execute" ;
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
         PA5C2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5C2( ) ;
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
         context.AddJavascriptSource("UserControls/UC_AppToolBox1Render.js", "", false, true);
         context.AddJavascriptSource("UserControls/UC_PreventAccessModalRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_applicationdesign.aspx"+UrlEncode(AV14Trn_PageId.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_applicationdesign.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_PAGES", AV29SDT_Pages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_PAGES", AV29SDT_Pages);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_PRODUCTSERVICECOLLECTION", AV35SDT_ProductServiceCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_PRODUCTSERVICECOLLECTION", AV35SDT_ProductServiceCollection);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERS", AV59Suppliers);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERS", AV59Suppliers);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDT_DYNAMICFORMSCOLLECTION", AV44SDT_DynamicFormsCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDT_DYNAMICFORMSCOLLECTION", AV44SDT_DynamicFormsCollection);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vBC_TRN_TEMPLATECOLLECTION", AV6BC_Trn_TemplateCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBC_TRN_TEMPLATECOLLECTION", AV6BC_Trn_TemplateCollection);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vBC_TRN_THEMECOLLECTION", AV8BC_Trn_ThemeCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBC_TRN_THEMECOLLECTION", AV8BC_Trn_ThemeCollection);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vBC_TRN_MEDIACOLLECTION", AV19BC_Trn_MediaCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBC_TRN_MEDIACOLLECTION", AV19BC_Trn_MediaCollection);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vBC_TRN_LOCATION", AV42BC_Trn_Location);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBC_TRN_LOCATION", AV42BC_Trn_Location);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCURRENTAPPVERSION", AV57CurrentAppVersion);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCURRENTAPPVERSION", AV57CurrentAppVersion);
         }
         GxWebStd.gx_hidden_field( context, "vTRN_PAGEID", AV14Trn_PageId.ToString());
         GxWebStd.gx_hidden_field( context, "APPTOOLBOX1_Current_language", StringUtil.RTrim( Apptoolbox1_Current_language));
         GxWebStd.gx_hidden_field( context, "APPTOOLBOX1_Locationid", StringUtil.RTrim( Apptoolbox1_Locationid));
         GxWebStd.gx_hidden_field( context, "APPTOOLBOX1_Organisationid", StringUtil.RTrim( Apptoolbox1_Organisationid));
         GxWebStd.gx_hidden_field( context, "APPTOOLBOX1_Locationlogo", StringUtil.RTrim( Apptoolbox1_Locationlogo));
         GxWebStd.gx_hidden_field( context, "APPTOOLBOX1_Locationprofileimage", StringUtil.RTrim( Apptoolbox1_Locationprofileimage));
         GxWebStd.gx_hidden_field( context, "APPTOOLBOX1_Current_theme", StringUtil.RTrim( Apptoolbox1_Current_theme));
         GxWebStd.gx_hidden_field( context, "APPTOOLBOX1_Organisationlogo", StringUtil.RTrim( Apptoolbox1_Organisationlogo));
         GxWebStd.gx_hidden_field( context, "PREVENTACCESSMODAL_Previewlink", StringUtil.RTrim( Preventaccessmodal_Previewlink));
         GxWebStd.gx_hidden_field( context, "PREVENTACCESSMODAL_Visible", StringUtil.BoolToStr( Preventaccessmodal_Visible));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            WE5C2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5C2( ) ;
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
         GXEncryptionTmp = "wp_applicationdesign.aspx"+UrlEncode(AV14Trn_PageId.ToString());
         return formatLink("wp_applicationdesign.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WP_ApplicationDesign" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Application Design", "") ;
      }

      protected void WB5C0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucApptoolbox1.SetProperty("Current_Language", Apptoolbox1_Current_language);
            ucApptoolbox1.SetProperty("SDT_Pages", AV29SDT_Pages);
            ucApptoolbox1.SetProperty("LocationLogo", Apptoolbox1_Locationlogo);
            ucApptoolbox1.SetProperty("LocationProfileImage", Apptoolbox1_Locationprofileimage);
            ucApptoolbox1.SetProperty("SDT_ProductServiceCollection", AV35SDT_ProductServiceCollection);
            ucApptoolbox1.SetProperty("Suppliers", AV59Suppliers);
            ucApptoolbox1.SetProperty("SDT_DynamicFormsCollection", AV44SDT_DynamicFormsCollection);
            ucApptoolbox1.SetProperty("BC_Trn_TemplateCollection", AV6BC_Trn_TemplateCollection);
            ucApptoolbox1.SetProperty("BC_Trn_ThemeCollection", AV8BC_Trn_ThemeCollection);
            ucApptoolbox1.SetProperty("BC_Trn_MediaCollection", AV19BC_Trn_MediaCollection);
            ucApptoolbox1.SetProperty("BC_Trn_Location", AV42BC_Trn_Location);
            ucApptoolbox1.SetProperty("Current_Version", AV57CurrentAppVersion);
            ucApptoolbox1.SetProperty("OrganisationLogo", Apptoolbox1_Organisationlogo);
            ucApptoolbox1.Render(context, "uc_apptoolbox1", Apptoolbox1_Internalname, "APPTOOLBOX1Container");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPreventaccessmodaltable_Internalname, divPreventaccessmodaltable_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucPreventaccessmodal.Render(context, "uc_preventaccessmodal", Preventaccessmodal_Internalname, "PREVENTACCESSMODALContainer");
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

      protected void START5C2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Application Design", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5C0( ) ;
      }

      protected void WS5C2( )
      {
         START5C2( ) ;
         EVT5C2( ) ;
      }

      protected void EVT5C2( )
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
                              E115C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E125C2 ();
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

      protected void WE5C2( )
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

      protected void PA5C2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_applicationdesign.aspx")), "wp_applicationdesign.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_applicationdesign.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "Trn_PageId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV14Trn_PageId = StringUtil.StrToGuid( gxfirstwebparm);
                     AssignAttri("", false, "AV14Trn_PageId", AV14Trn_PageId.ToString());
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
         RF5C2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF5C2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E125C2 ();
            WB5C0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5C2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5C0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E115C2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vSDT_PAGES"), AV29SDT_Pages);
            ajax_req_read_hidden_sdt(cgiGet( "vSDT_PRODUCTSERVICECOLLECTION"), AV35SDT_ProductServiceCollection);
            ajax_req_read_hidden_sdt(cgiGet( "vSUPPLIERS"), AV59Suppliers);
            ajax_req_read_hidden_sdt(cgiGet( "vSDT_DYNAMICFORMSCOLLECTION"), AV44SDT_DynamicFormsCollection);
            ajax_req_read_hidden_sdt(cgiGet( "vBC_TRN_TEMPLATECOLLECTION"), AV6BC_Trn_TemplateCollection);
            ajax_req_read_hidden_sdt(cgiGet( "vBC_TRN_THEMECOLLECTION"), AV8BC_Trn_ThemeCollection);
            ajax_req_read_hidden_sdt(cgiGet( "vBC_TRN_MEDIACOLLECTION"), AV19BC_Trn_MediaCollection);
            ajax_req_read_hidden_sdt(cgiGet( "vBC_TRN_LOCATION"), AV42BC_Trn_Location);
            ajax_req_read_hidden_sdt(cgiGet( "vCURRENTAPPVERSION"), AV57CurrentAppVersion);
            /* Read saved values. */
            Apptoolbox1_Current_language = cgiGet( "APPTOOLBOX1_Current_language");
            Apptoolbox1_Locationid = cgiGet( "APPTOOLBOX1_Locationid");
            Apptoolbox1_Organisationid = cgiGet( "APPTOOLBOX1_Organisationid");
            Apptoolbox1_Locationlogo = cgiGet( "APPTOOLBOX1_Locationlogo");
            Apptoolbox1_Locationprofileimage = cgiGet( "APPTOOLBOX1_Locationprofileimage");
            Apptoolbox1_Current_theme = cgiGet( "APPTOOLBOX1_Current_theme");
            Apptoolbox1_Organisationlogo = cgiGet( "APPTOOLBOX1_Organisationlogo");
            Preventaccessmodal_Previewlink = cgiGet( "PREVENTACCESSMODAL_Previewlink");
            Preventaccessmodal_Visible = StringUtil.StrToBool( cgiGet( "PREVENTACCESSMODAL_Visible"));
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
         E115C2 ();
         if (returnInSub) return;
      }

      protected void E115C2( )
      {
         /* Start Routine */
         returnInSub = false;
         Preventaccessmodal_Visible = false;
         ucPreventaccessmodal.SendProperty(context, "", false, Preventaccessmodal_Internalname, "Visible", StringUtil.BoolToStr( Preventaccessmodal_Visible));
         GXt_boolean1 = AV61IsBusy;
         new prc_isappbuilderbusy(context ).execute( out  GXt_boolean1) ;
         AV61IsBusy = GXt_boolean1;
         AssignAttri("", false, "AV61IsBusy", AV61IsBusy);
         if ( AV61IsBusy )
         {
            AV62ReferrerUrl = AV37HttpRequest.Referrer;
            Preventaccessmodal_Visible = true;
            ucPreventaccessmodal.SendProperty(context, "", false, Preventaccessmodal_Internalname, "Visible", StringUtil.BoolToStr( Preventaccessmodal_Visible));
         }
         else
         {
            new prc_updatetoolboxstatus(context ).execute(  true) ;
            Preventaccessmodal_Visible = false;
            ucPreventaccessmodal.SendProperty(context, "", false, Preventaccessmodal_Internalname, "Visible", StringUtil.BoolToStr( Preventaccessmodal_Visible));
         }
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV60WWPContext) ;
         AV38UserName = AV60WWPContext.gxTpr_Gamusername;
         AV39LocationId = AV60WWPContext.gxTpr_Locationid;
         AssignAttri("", false, "AV39LocationId", AV39LocationId.ToString());
         AV40OrganisationId = AV60WWPContext.gxTpr_Organisationid;
         AssignAttri("", false, "AV40OrganisationId", AV40OrganisationId.ToString());
         if ( (Guid.Empty==AV39LocationId) )
         {
            new prc_logoutuser(context ).execute( ) ;
         }
         new prc_initlocationpagesv2(context ).execute(  AV39LocationId,  AV40OrganisationId) ;
         Apptoolbox1_Locationid = AV39LocationId.ToString();
         ucApptoolbox1.SendProperty(context, "", false, Apptoolbox1_Internalname, "LocationId", Apptoolbox1_Locationid);
         Apptoolbox1_Organisationid = AV40OrganisationId.ToString();
         ucApptoolbox1.SendProperty(context, "", false, Apptoolbox1_Internalname, "OrganisationId", Apptoolbox1_Organisationid);
         AV42BC_Trn_Location.Load(AV39LocationId, AV40OrganisationId);
         Apptoolbox1_Locationlogo = AV42BC_Trn_Location.gxTpr_Toolboxdefaultlogo;
         ucApptoolbox1.SendProperty(context, "", false, Apptoolbox1_Internalname, "LocationLogo", Apptoolbox1_Locationlogo);
         Apptoolbox1_Locationprofileimage = AV42BC_Trn_Location.gxTpr_Toolboxdefaultprofileimage;
         ucApptoolbox1.SendProperty(context, "", false, Apptoolbox1_Internalname, "LocationProfileImage", Apptoolbox1_Locationprofileimage);
         /* Using cursor H005C2 */
         pr_default.execute(0, new Object[] {AV40OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = H005C2_A11OrganisationId[0];
            A40000OrganisationLogo_GXI = H005C2_A40000OrganisationLogo_GXI[0];
            Apptoolbox1_Organisationlogo = A40000OrganisationLogo_GXI;
            ucApptoolbox1.SendProperty(context, "", false, Apptoolbox1_Internalname, "OrganisationLogo", Apptoolbox1_Organisationlogo);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor H005C3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A299Trn_TemplateId = H005C3_A299Trn_TemplateId[0];
            AV5BC_Trn_Template = new SdtTrn_Template(context);
            AV5BC_Trn_Template.Load(A299Trn_TemplateId);
            AV6BC_Trn_TemplateCollection.Add(AV5BC_Trn_Template, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor H005C4 */
         pr_default.execute(2, new Object[] {AV39LocationId, AV40OrganisationId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A11OrganisationId = H005C4_A11OrganisationId[0];
            A29LocationId = H005C4_A29LocationId[0];
            A40001ProductServiceImage_GXI = H005C4_A40001ProductServiceImage_GXI[0];
            A58ProductServiceId = H005C4_A58ProductServiceId[0];
            A59ProductServiceName = H005C4_A59ProductServiceName[0];
            A266ProductServiceTileName = H005C4_A266ProductServiceTileName[0];
            A370ProductServiceClass = H005C4_A370ProductServiceClass[0];
            A61ProductServiceImage = H005C4_A61ProductServiceImage[0];
            AV34SDT_ProductService = new SdtSDT_ProductService(context);
            AV34SDT_ProductService.gxTpr_Productserviceid = A58ProductServiceId;
            AV34SDT_ProductService.gxTpr_Productservicename = A59ProductServiceName;
            AV34SDT_ProductService.gxTpr_Productserviceimage = A61ProductServiceImage;
            AV34SDT_ProductService.gxTpr_Productserviceimage_gxi = A40001ProductServiceImage_GXI;
            AV34SDT_ProductService.gxTpr_Productservicetilename = StringUtil.Trim( A266ProductServiceTileName);
            AV34SDT_ProductService.gxTpr_Productserviceclass = A370ProductServiceClass;
            AV35SDT_ProductServiceCollection.Add(AV34SDT_ProductService, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         /* Using cursor H005C5 */
         pr_default.execute(3, new Object[] {AV39LocationId, AV40OrganisationId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A207WWPFormVersionNumber = H005C5_A207WWPFormVersionNumber[0];
            A11OrganisationId = H005C5_A11OrganisationId[0];
            A29LocationId = H005C5_A29LocationId[0];
            A206WWPFormId = H005C5_A206WWPFormId[0];
            A209WWPFormTitle = H005C5_A209WWPFormTitle[0];
            A208WWPFormReferenceName = H005C5_A208WWPFormReferenceName[0];
            A209WWPFormTitle = H005C5_A209WWPFormTitle[0];
            A208WWPFormReferenceName = H005C5_A208WWPFormReferenceName[0];
            AV43SDT_DynamicForms = new SdtSDT_DynamicForms(context);
            AV43SDT_DynamicForms.gxTpr_Formid = A206WWPFormId;
            AV43SDT_DynamicForms.gxTpr_Pagename = A209WWPFormTitle;
            AV43SDT_DynamicForms.gxTpr_Referencename = A208WWPFormReferenceName;
            GXt_char2 = "";
            GXt_char3 = context.GetMessage( "Form", "");
            new prc_getcalltoactionformurl(context ).execute( ref  GXt_char3, ref  A208WWPFormReferenceName, out  GXt_char2) ;
            AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
            AV43SDT_DynamicForms.gxTpr_Formurl = GXt_char2;
            AV44SDT_DynamicFormsCollection.Add(AV43SDT_DynamicForms, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         /* Using cursor H005C6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A207WWPFormVersionNumber = H005C6_A207WWPFormVersionNumber[0];
            A206WWPFormId = H005C6_A206WWPFormId[0];
            A209WWPFormTitle = H005C6_A209WWPFormTitle[0];
            A208WWPFormReferenceName = H005C6_A208WWPFormReferenceName[0];
            A42SupplierGenId = H005C6_A42SupplierGenId[0];
            A209WWPFormTitle = H005C6_A209WWPFormTitle[0];
            A208WWPFormReferenceName = H005C6_A208WWPFormReferenceName[0];
            AV43SDT_DynamicForms = new SdtSDT_DynamicForms(context);
            AV43SDT_DynamicForms.gxTpr_Formid = A206WWPFormId;
            AV43SDT_DynamicForms.gxTpr_Pagename = A209WWPFormTitle;
            AV43SDT_DynamicForms.gxTpr_Referencename = A208WWPFormReferenceName;
            AV43SDT_DynamicForms.gxTpr_Supplierid = A42SupplierGenId.ToString();
            GXt_char3 = "";
            GXt_char2 = context.GetMessage( "Form", "");
            new prc_getcalltoactionformurl(context ).execute( ref  GXt_char2, ref  A208WWPFormReferenceName, out  GXt_char3) ;
            AssignAttri("", false, "A208WWPFormReferenceName", A208WWPFormReferenceName);
            AV43SDT_DynamicForms.gxTpr_Formurl = GXt_char3;
            AV44SDT_DynamicFormsCollection.Add(AV43SDT_DynamicForms, 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         /* Using cursor H005C7 */
         pr_default.execute(5, new Object[] {AV39LocationId});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A29LocationId = H005C7_A29LocationId[0];
            A413MediaId = H005C7_A413MediaId[0];
            A414MediaName = H005C7_A414MediaName[0];
            AV18BC_Trn_Media = new SdtTrn_Media(context);
            AV18BC_Trn_Media.Load(A413MediaId);
            AV53MediaPath = context.GetMessage( "media/", "") + A414MediaName;
            AV52File = new GxFile(context.GetPhysicalPath());
            AV52File.Source = context.GetMessage( "media/", "")+A414MediaName;
            if ( AV52File.Exists() )
            {
               AV19BC_Trn_MediaCollection.Add(AV18BC_Trn_Media, 0);
            }
            else
            {
               AV18BC_Trn_Media.Delete();
               context.CommitDataStores("wp_applicationdesign",pr_default);
            }
            pr_default.readNext(5);
         }
         pr_default.close(5);
         GXt_objcol_SdtTrn_Theme4 = AV8BC_Trn_ThemeCollection;
         new prc_getorganisationtheme(context ).execute(  AV40OrganisationId,  AV39LocationId, out  GXt_objcol_SdtTrn_Theme4) ;
         AV8BC_Trn_ThemeCollection = GXt_objcol_SdtTrn_Theme4;
         new prc_getappversion(context ).execute( out  AV57CurrentAppVersion, out  AV58SDT_Error,  AV39LocationId) ;
         Apptoolbox1_Current_theme = AV57CurrentAppVersion.gxTpr_Themeid.ToString();
         ucApptoolbox1.SendProperty(context, "", false, Apptoolbox1_Internalname, "Current_Theme", Apptoolbox1_Current_theme);
         /* Using cursor H005C8 */
         pr_default.execute(6, new Object[] {AV39LocationId});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A584ActiveAppVersionId = H005C8_A584ActiveAppVersionId[0];
            n584ActiveAppVersionId = H005C8_n584ActiveAppVersionId[0];
            A598PublishedActiveAppVersionId = H005C8_A598PublishedActiveAppVersionId[0];
            n598PublishedActiveAppVersionId = H005C8_n598PublishedActiveAppVersionId[0];
            A29LocationId = H005C8_A29LocationId[0];
            /* Using cursor H005C9 */
            pr_default.execute(7, new Object[] {n598PublishedActiveAppVersionId, A598PublishedActiveAppVersionId});
            A273Trn_ThemeId = H005C9_A273Trn_ThemeId[0];
            pr_default.close(7);
            /* Using cursor H005C10 */
            pr_default.execute(8, new Object[] {n584ActiveAppVersionId, A584ActiveAppVersionId});
            A273Trn_ThemeId = H005C10_A273Trn_ThemeId[0];
            pr_default.close(8);
            Apptoolbox1_Current_theme = A273Trn_ThemeId.ToString();
            ucApptoolbox1.SendProperty(context, "", false, Apptoolbox1_Internalname, "Current_Theme", Apptoolbox1_Current_theme);
            pr_default.readNext(6);
         }
         pr_default.close(6);
         pr_default.close(8);
         if ( (Guid.Empty==AV57CurrentAppVersion.gxTpr_Themeid) )
         {
            /* Using cursor H005C11 */
            pr_default.execute(9);
            while ( (pr_default.getStatus(9) != 101) )
            {
               A273Trn_ThemeId = H005C11_A273Trn_ThemeId[0];
               Apptoolbox1_Current_theme = A273Trn_ThemeId.ToString();
               ucApptoolbox1.SendProperty(context, "", false, Apptoolbox1_Internalname, "Current_Theme", Apptoolbox1_Current_theme);
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(9);
            }
            pr_default.close(9);
         }
         AV63PreviewLink = AV37HttpRequest.BaseURL + context.GetMessage( "wp_apppreview.aspx?AppVersionId=", "") + AV57CurrentAppVersion.gxTpr_Appversionid.ToString();
         Preventaccessmodal_Previewlink = AV63PreviewLink;
         ucPreventaccessmodal.SendProperty(context, "", false, Preventaccessmodal_Internalname, "PreviewLink", Preventaccessmodal_Previewlink);
         GXt_objcol_SdtTrn_SupplierGen5 = AV59Suppliers;
         new prc_getorganisationsuppliers(context ).execute(  AV40OrganisationId, out  GXt_objcol_SdtTrn_SupplierGen5) ;
         AV59Suppliers = GXt_objcol_SdtTrn_SupplierGen5;
         /* Using cursor H005C12 */
         pr_default.execute(10);
         while ( (pr_default.getStatus(10) != 101) )
         {
            A392Trn_PageId = H005C12_A392Trn_PageId[0];
            A397Trn_PageName = H005C12_A397Trn_PageName[0];
            A424PageChildren = H005C12_A424PageChildren[0];
            n424PageChildren = H005C12_n424PageChildren[0];
            AV30SDT_PageStructure = new SdtSDT_PageStructure(context);
            AV30SDT_PageStructure.gxTpr_Id = A392Trn_PageId;
            AV30SDT_PageStructure.gxTpr_Name = A397Trn_PageName;
            AV30SDT_PageStructure.gxTpr_Children.FromJSonString(A424PageChildren, null);
            AV29SDT_Pages.Add(AV30SDT_PageStructure, 0);
            pr_default.readNext(10);
         }
         pr_default.close(10);
         AV36Current_Language = context.GetLanguage( );
         Apptoolbox1_Current_language = AV36Current_Language;
         ucApptoolbox1.SendProperty(context, "", false, Apptoolbox1_Internalname, "Current_Language", Apptoolbox1_Current_language);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         divPreventaccessmodaltable_Visible = (((AV61IsBusy)) ? 1 : 0);
         AssignProp("", false, divPreventaccessmodaltable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPreventaccessmodaltable_Visible), 5, 0), true);
      }

      protected void nextLoad( )
      {
      }

      protected void E125C2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV14Trn_PageId = (Guid)getParm(obj,0);
         AssignAttri("", false, "AV14Trn_PageId", AV14Trn_PageId.ToString());
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
         PA5C2( ) ;
         WS5C2( ) ;
         WE5C2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256258422666", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("wp_applicationdesign.js", "?20256258422667", false, true);
            context.AddJavascriptSource("UserControls/UC_AppToolBox1Render.js", "", false, true);
            context.AddJavascriptSource("UserControls/UC_PreventAccessModalRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divTablecontent_Internalname = "TABLECONTENT";
         Apptoolbox1_Internalname = "APPTOOLBOX1";
         Preventaccessmodal_Internalname = "PREVENTACCESSMODAL";
         divPreventaccessmodaltable_Internalname = "PREVENTACCESSMODALTABLE";
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
         divPreventaccessmodaltable_Visible = 1;
         Preventaccessmodal_Visible = Convert.ToBoolean( -1);
         Preventaccessmodal_Previewlink = "";
         Apptoolbox1_Organisationlogo = "&OrganisationLogo";
         Apptoolbox1_Current_theme = "";
         Apptoolbox1_Locationprofileimage = "&LocationProfileImage";
         Apptoolbox1_Locationlogo = "&LocationLogo";
         Apptoolbox1_Organisationid = "";
         Apptoolbox1_Locationid = "";
         Apptoolbox1_Current_language = "english";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Application Design", "");
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
         pr_default.close(7);
      }

      public override void initialize( )
      {
         wcpOAV14Trn_PageId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV29SDT_Pages = new GXBaseCollection<SdtSDT_PageStructure>( context, "SDT_PageStructure", "Comforta_version2");
         AV35SDT_ProductServiceCollection = new GXBaseCollection<SdtSDT_ProductService>( context, "SDT_ProductService", "Comforta_version2");
         AV59Suppliers = new GXBCCollection<SdtTrn_SupplierGen>( context, "Trn_SupplierGen", "Comforta_version2");
         AV44SDT_DynamicFormsCollection = new GXBaseCollection<SdtSDT_DynamicForms>( context, "SDT_DynamicForms", "Comforta_version2");
         AV6BC_Trn_TemplateCollection = new GXBCCollection<SdtTrn_Template>( context, "Trn_Template", "Comforta_version2");
         AV8BC_Trn_ThemeCollection = new GXBCCollection<SdtTrn_Theme>( context, "Trn_Theme", "Comforta_version2");
         AV19BC_Trn_MediaCollection = new GXBCCollection<SdtTrn_Media>( context, "Trn_Media", "Comforta_version2");
         AV42BC_Trn_Location = new SdtTrn_Location(context);
         AV57CurrentAppVersion = new SdtSDT_AppVersion(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucApptoolbox1 = new GXUserControl();
         ucPreventaccessmodal = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV62ReferrerUrl = "";
         AV37HttpRequest = new GxHttpRequest( context);
         AV60WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV38UserName = "";
         AV39LocationId = Guid.Empty;
         AV40OrganisationId = Guid.Empty;
         H005C2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H005C2_A40000OrganisationLogo_GXI = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A40000OrganisationLogo_GXI = "";
         H005C3_A299Trn_TemplateId = new Guid[] {Guid.Empty} ;
         A299Trn_TemplateId = Guid.Empty;
         AV5BC_Trn_Template = new SdtTrn_Template(context);
         H005C4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H005C4_A29LocationId = new Guid[] {Guid.Empty} ;
         H005C4_A40001ProductServiceImage_GXI = new string[] {""} ;
         H005C4_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         H005C4_A59ProductServiceName = new string[] {""} ;
         H005C4_A266ProductServiceTileName = new string[] {""} ;
         H005C4_A370ProductServiceClass = new string[] {""} ;
         H005C4_A61ProductServiceImage = new string[] {""} ;
         A29LocationId = Guid.Empty;
         A40001ProductServiceImage_GXI = "";
         A58ProductServiceId = Guid.Empty;
         A59ProductServiceName = "";
         A266ProductServiceTileName = "";
         A370ProductServiceClass = "";
         A61ProductServiceImage = "";
         AV34SDT_ProductService = new SdtSDT_ProductService(context);
         H005C5_A366LocationDynamicFormId = new Guid[] {Guid.Empty} ;
         H005C5_A207WWPFormVersionNumber = new short[1] ;
         H005C5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H005C5_A29LocationId = new Guid[] {Guid.Empty} ;
         H005C5_A206WWPFormId = new short[1] ;
         H005C5_A209WWPFormTitle = new string[] {""} ;
         H005C5_A208WWPFormReferenceName = new string[] {""} ;
         A209WWPFormTitle = "";
         A208WWPFormReferenceName = "";
         AV43SDT_DynamicForms = new SdtSDT_DynamicForms(context);
         H005C6_A616SupplierDynamicFormId = new Guid[] {Guid.Empty} ;
         H005C6_A207WWPFormVersionNumber = new short[1] ;
         H005C6_A206WWPFormId = new short[1] ;
         H005C6_A209WWPFormTitle = new string[] {""} ;
         H005C6_A208WWPFormReferenceName = new string[] {""} ;
         H005C6_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         A42SupplierGenId = Guid.Empty;
         GXt_char3 = "";
         GXt_char2 = "";
         H005C7_A29LocationId = new Guid[] {Guid.Empty} ;
         H005C7_A413MediaId = new Guid[] {Guid.Empty} ;
         H005C7_A414MediaName = new string[] {""} ;
         A413MediaId = Guid.Empty;
         A414MediaName = "";
         AV18BC_Trn_Media = new SdtTrn_Media(context);
         AV53MediaPath = "";
         AV52File = new GxFile(context.GetPhysicalPath());
         GXt_objcol_SdtTrn_Theme4 = new GXBCCollection<SdtTrn_Theme>( context, "Trn_Theme", "Comforta_version2");
         AV58SDT_Error = new SdtSDT_Error(context);
         H005C8_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H005C8_A584ActiveAppVersionId = new Guid[] {Guid.Empty} ;
         H005C8_n584ActiveAppVersionId = new bool[] {false} ;
         H005C8_A598PublishedActiveAppVersionId = new Guid[] {Guid.Empty} ;
         H005C8_n598PublishedActiveAppVersionId = new bool[] {false} ;
         H005C8_A29LocationId = new Guid[] {Guid.Empty} ;
         A584ActiveAppVersionId = Guid.Empty;
         A598PublishedActiveAppVersionId = Guid.Empty;
         H005C9_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         A273Trn_ThemeId = Guid.Empty;
         H005C10_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         H005C11_A273Trn_ThemeId = new Guid[] {Guid.Empty} ;
         AV63PreviewLink = "";
         GXt_objcol_SdtTrn_SupplierGen5 = new GXBCCollection<SdtTrn_SupplierGen>( context, "Trn_SupplierGen", "Comforta_version2");
         H005C12_A29LocationId = new Guid[] {Guid.Empty} ;
         H005C12_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         H005C12_A397Trn_PageName = new string[] {""} ;
         H005C12_A424PageChildren = new string[] {""} ;
         H005C12_n424PageChildren = new bool[] {false} ;
         A392Trn_PageId = Guid.Empty;
         A397Trn_PageName = "";
         A424PageChildren = "";
         AV30SDT_PageStructure = new SdtSDT_PageStructure(context);
         AV36Current_Language = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wp_applicationdesign__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_applicationdesign__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_applicationdesign__default(),
            new Object[][] {
                new Object[] {
               H005C2_A11OrganisationId, H005C2_A40000OrganisationLogo_GXI
               }
               , new Object[] {
               H005C3_A299Trn_TemplateId
               }
               , new Object[] {
               H005C4_A11OrganisationId, H005C4_A29LocationId, H005C4_A40001ProductServiceImage_GXI, H005C4_A58ProductServiceId, H005C4_A59ProductServiceName, H005C4_A266ProductServiceTileName, H005C4_A370ProductServiceClass, H005C4_A61ProductServiceImage
               }
               , new Object[] {
               H005C5_A366LocationDynamicFormId, H005C5_A207WWPFormVersionNumber, H005C5_A11OrganisationId, H005C5_A29LocationId, H005C5_A206WWPFormId, H005C5_A209WWPFormTitle, H005C5_A208WWPFormReferenceName
               }
               , new Object[] {
               H005C6_A616SupplierDynamicFormId, H005C6_A207WWPFormVersionNumber, H005C6_A206WWPFormId, H005C6_A209WWPFormTitle, H005C6_A208WWPFormReferenceName, H005C6_A42SupplierGenId
               }
               , new Object[] {
               H005C7_A29LocationId, H005C7_A413MediaId, H005C7_A414MediaName
               }
               , new Object[] {
               H005C8_A11OrganisationId, H005C8_A584ActiveAppVersionId, H005C8_n584ActiveAppVersionId, H005C8_A598PublishedActiveAppVersionId, H005C8_n598PublishedActiveAppVersionId, H005C8_A29LocationId
               }
               , new Object[] {
               H005C9_A273Trn_ThemeId
               }
               , new Object[] {
               H005C10_A273Trn_ThemeId
               }
               , new Object[] {
               H005C11_A273Trn_ThemeId
               }
               , new Object[] {
               H005C12_A29LocationId, H005C12_A392Trn_PageId, H005C12_A397Trn_PageName, H005C12_A424PageChildren, H005C12_n424PageChildren
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_11 ;
      private short nIsMod_11 ;
      private short nRcdExists_10 ;
      private short nIsMod_10 ;
      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short A207WWPFormVersionNumber ;
      private short A206WWPFormId ;
      private int divPreventaccessmodaltable_Visible ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Apptoolbox1_Current_language ;
      private string Apptoolbox1_Locationid ;
      private string Apptoolbox1_Organisationid ;
      private string Apptoolbox1_Locationlogo ;
      private string Apptoolbox1_Locationprofileimage ;
      private string Apptoolbox1_Current_theme ;
      private string Apptoolbox1_Organisationlogo ;
      private string Preventaccessmodal_Previewlink ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Apptoolbox1_Internalname ;
      private string divPreventaccessmodaltable_Internalname ;
      private string Preventaccessmodal_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string A266ProductServiceTileName ;
      private string GXt_char3 ;
      private string GXt_char2 ;
      private string AV36Current_Language ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Preventaccessmodal_Visible ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV61IsBusy ;
      private bool GXt_boolean1 ;
      private bool n584ActiveAppVersionId ;
      private bool n598PublishedActiveAppVersionId ;
      private bool n424PageChildren ;
      private string A424PageChildren ;
      private string AV62ReferrerUrl ;
      private string AV38UserName ;
      private string A40000OrganisationLogo_GXI ;
      private string A40001ProductServiceImage_GXI ;
      private string A59ProductServiceName ;
      private string A370ProductServiceClass ;
      private string A209WWPFormTitle ;
      private string A208WWPFormReferenceName ;
      private string A414MediaName ;
      private string AV53MediaPath ;
      private string AV63PreviewLink ;
      private string A397Trn_PageName ;
      private string A61ProductServiceImage ;
      private Guid AV14Trn_PageId ;
      private Guid wcpOAV14Trn_PageId ;
      private Guid AV39LocationId ;
      private Guid AV40OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid A299Trn_TemplateId ;
      private Guid A29LocationId ;
      private Guid A58ProductServiceId ;
      private Guid A42SupplierGenId ;
      private Guid A413MediaId ;
      private Guid A584ActiveAppVersionId ;
      private Guid A598PublishedActiveAppVersionId ;
      private Guid A273Trn_ThemeId ;
      private Guid A392Trn_PageId ;
      private GXUserControl ucApptoolbox1 ;
      private GXUserControl ucPreventaccessmodal ;
      private GxHttpRequest AV37HttpRequest ;
      private GxFile AV52File ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_PageStructure> AV29SDT_Pages ;
      private GXBaseCollection<SdtSDT_ProductService> AV35SDT_ProductServiceCollection ;
      private GXBCCollection<SdtTrn_SupplierGen> AV59Suppliers ;
      private GXBaseCollection<SdtSDT_DynamicForms> AV44SDT_DynamicFormsCollection ;
      private GXBCCollection<SdtTrn_Template> AV6BC_Trn_TemplateCollection ;
      private GXBCCollection<SdtTrn_Theme> AV8BC_Trn_ThemeCollection ;
      private GXBCCollection<SdtTrn_Media> AV19BC_Trn_MediaCollection ;
      private SdtTrn_Location AV42BC_Trn_Location ;
      private SdtSDT_AppVersion AV57CurrentAppVersion ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV60WWPContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] H005C2_A11OrganisationId ;
      private string[] H005C2_A40000OrganisationLogo_GXI ;
      private Guid[] H005C3_A299Trn_TemplateId ;
      private SdtTrn_Template AV5BC_Trn_Template ;
      private Guid[] H005C4_A11OrganisationId ;
      private Guid[] H005C4_A29LocationId ;
      private string[] H005C4_A40001ProductServiceImage_GXI ;
      private Guid[] H005C4_A58ProductServiceId ;
      private string[] H005C4_A59ProductServiceName ;
      private string[] H005C4_A266ProductServiceTileName ;
      private string[] H005C4_A370ProductServiceClass ;
      private string[] H005C4_A61ProductServiceImage ;
      private SdtSDT_ProductService AV34SDT_ProductService ;
      private Guid[] H005C5_A366LocationDynamicFormId ;
      private short[] H005C5_A207WWPFormVersionNumber ;
      private Guid[] H005C5_A11OrganisationId ;
      private Guid[] H005C5_A29LocationId ;
      private short[] H005C5_A206WWPFormId ;
      private string[] H005C5_A209WWPFormTitle ;
      private string[] H005C5_A208WWPFormReferenceName ;
      private SdtSDT_DynamicForms AV43SDT_DynamicForms ;
      private Guid[] H005C6_A616SupplierDynamicFormId ;
      private short[] H005C6_A207WWPFormVersionNumber ;
      private short[] H005C6_A206WWPFormId ;
      private string[] H005C6_A209WWPFormTitle ;
      private string[] H005C6_A208WWPFormReferenceName ;
      private Guid[] H005C6_A42SupplierGenId ;
      private Guid[] H005C7_A29LocationId ;
      private Guid[] H005C7_A413MediaId ;
      private string[] H005C7_A414MediaName ;
      private SdtTrn_Media AV18BC_Trn_Media ;
      private GXBCCollection<SdtTrn_Theme> GXt_objcol_SdtTrn_Theme4 ;
      private SdtSDT_Error AV58SDT_Error ;
      private Guid[] H005C8_A11OrganisationId ;
      private Guid[] H005C8_A584ActiveAppVersionId ;
      private bool[] H005C8_n584ActiveAppVersionId ;
      private Guid[] H005C8_A598PublishedActiveAppVersionId ;
      private bool[] H005C8_n598PublishedActiveAppVersionId ;
      private Guid[] H005C8_A29LocationId ;
      private Guid[] H005C9_A273Trn_ThemeId ;
      private Guid[] H005C10_A273Trn_ThemeId ;
      private Guid[] H005C11_A273Trn_ThemeId ;
      private GXBCCollection<SdtTrn_SupplierGen> GXt_objcol_SdtTrn_SupplierGen5 ;
      private Guid[] H005C12_A29LocationId ;
      private Guid[] H005C12_A392Trn_PageId ;
      private string[] H005C12_A397Trn_PageName ;
      private string[] H005C12_A424PageChildren ;
      private bool[] H005C12_n424PageChildren ;
      private SdtSDT_PageStructure AV30SDT_PageStructure ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_applicationdesign__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_applicationdesign__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wp_applicationdesign__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[6])
      ,new ForEachCursor(def[7])
      ,new ForEachCursor(def[8])
      ,new ForEachCursor(def[9])
      ,new ForEachCursor(def[10])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmH005C2;
       prmH005C2 = new Object[] {
       new ParDef("AV40OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH005C3;
       prmH005C3 = new Object[] {
       };
       Object[] prmH005C4;
       prmH005C4 = new Object[] {
       new ParDef("AV39LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV40OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH005C5;
       prmH005C5 = new Object[] {
       new ParDef("AV39LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("AV40OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH005C6;
       prmH005C6 = new Object[] {
       };
       Object[] prmH005C7;
       prmH005C7 = new Object[] {
       new ParDef("AV39LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH005C8;
       prmH005C8 = new Object[] {
       new ParDef("AV39LocationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmH005C9;
       prmH005C9 = new Object[] {
       new ParDef("PublishedActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmH005C10;
       prmH005C10 = new Object[] {
       new ParDef("ActiveAppVersionId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmH005C11;
       prmH005C11 = new Object[] {
       };
       Object[] prmH005C12;
       prmH005C12 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("H005C2", "SELECT OrganisationId, OrganisationLogo_GXI FROM Trn_Organisation WHERE OrganisationId = :AV40OrganisationId ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005C2,1, GxCacheFrequency.OFF ,false,true )
          ,new CursorDef("H005C3", "SELECT Trn_TemplateId FROM Trn_Template ORDER BY Trn_TemplateId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005C3,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H005C4", "SELECT OrganisationId, LocationId, ProductServiceImage_GXI, ProductServiceId, ProductServiceName, ProductServiceTileName, ProductServiceClass, ProductServiceImage FROM Trn_ProductService WHERE LocationId = :AV39LocationId and OrganisationId = :AV40OrganisationId ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005C4,100, GxCacheFrequency.OFF ,false,false )
          ,new CursorDef("H005C5", "SELECT T1.LocationDynamicFormId, T1.WWPFormVersionNumber, T1.OrganisationId, T1.LocationId, T1.WWPFormId, T2.WWPFormTitle, T2.WWPFormReferenceName FROM (Trn_LocationDynamicForm T1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber) WHERE T1.LocationId = :AV39LocationId and T1.OrganisationId = :AV40OrganisationId ORDER BY T1.LocationId, T1.OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005C5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H005C6", "SELECT T1.SupplierDynamicFormId, T1.WWPFormVersionNumber, T1.WWPFormId, T2.WWPFormTitle, T2.WWPFormReferenceName, T1.SupplierGenId FROM (Trn_SupplierDynamicForm T1 INNER JOIN WWP_Form T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber) ORDER BY T1.SupplierDynamicFormId, T1.SupplierGenId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005C6,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H005C7", "SELECT LocationId, MediaId, MediaName FROM Trn_Media WHERE LocationId = :AV39LocationId ORDER BY MediaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005C7,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H005C8", "SELECT OrganisationId, ActiveAppVersionId, PublishedActiveAppVersionId, LocationId FROM Trn_Location WHERE LocationId = :AV39LocationId ORDER BY LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005C8,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H005C9", "SELECT Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :PublishedActiveAppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005C9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H005C10", "SELECT Trn_ThemeId FROM Trn_AppVersion WHERE AppVersionId = :ActiveAppVersionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005C10,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H005C11", "SELECT Trn_ThemeId FROM Trn_Theme ORDER BY Trn_ThemeId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005C11,1, GxCacheFrequency.OFF ,false,true )
          ,new CursorDef("H005C12", "SELECT LocationId, Trn_PageId, Trn_PageName, PageChildren FROM Trn_Page ORDER BY Trn_PageId, LocationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005C12,100, GxCacheFrequency.OFF ,false,false )
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
             ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 20);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((Guid[]) buf[3])[0] = rslt.getGuid(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((Guid[]) buf[5])[0] = rslt.getGuid(6);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.wasNull(2);
             ((Guid[]) buf[3])[0] = rslt.getGuid(3);
             ((bool[]) buf[4])[0] = rslt.wasNull(3);
             ((Guid[]) buf[5])[0] = rslt.getGuid(4);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 10 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             return;
    }
 }

}

}
