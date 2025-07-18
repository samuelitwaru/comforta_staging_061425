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
   public class wp_viewlocation : GXDataArea
   {
      public wp_viewlocation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_viewlocation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_LocationId ,
                           Guid aP1_OrganisationId )
      {
         this.AV9LocationId = aP0_LocationId;
         this.AV11OrganisationId = aP1_OrganisationId;
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
            gxfirstwebparm = GetFirstPar( "LocationId");
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
               gxfirstwebparm = GetFirstPar( "LocationId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "LocationId");
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
            return "wp_viewlocation_Execute" ;
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
         PAC02( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTC02( ) ;
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
         context.AddJavascriptSource("UserControls/UC_CustomImageUploadRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_viewlocation.aspx"+UrlEncode(AV9LocationId.ToString()) + "," + UrlEncode(AV11OrganisationId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_viewlocation.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_LOCATIONID", GetSecureSignedToken( "", A29LocationId, context));
         GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONID", GetSecureSignedToken( "", A11OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "vLOCATIONID", AV9LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV9LocationId, context));
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"WP_ViewLocation");
         forbiddenHiddens.Add("LocationId", A29LocationId.ToString());
         forbiddenHiddens.Add("OrganisationId", A11OrganisationId.ToString());
         forbiddenHiddens.Add("LocationDescription", A36LocationDescription);
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wp_viewlocation:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILESTOUPDATE", AV5FilesToUpdate);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILESTOUPDATE", AV5FilesToUpdate);
         }
         GxWebStd.gx_hidden_field( context, "vLOCATIONDESCRIPTIONVAR", AV8LocationDescriptionVar);
         GxWebStd.gx_hidden_field( context, "vLOCATIONID", AV9LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV9LocationId, context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "IMAGEUPLOADUC_Faileduploadmessage", StringUtil.RTrim( Imageuploaduc_Faileduploadmessage));
         GxWebStd.gx_hidden_field( context, "IMAGEUPLOADUC_Maxnumberoffiles", StringUtil.RTrim( Imageuploaduc_Maxnumberoffiles));
         GxWebStd.gx_hidden_field( context, "IMAGEUPLOADUC_Isreadonlymode", StringUtil.RTrim( Imageuploaduc_Isreadonlymode));
         GxWebStd.gx_hidden_field( context, "IMAGEUPLOADUC_Maxfilesize", StringUtil.RTrim( Imageuploaduc_Maxfilesize));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTIONVAR_Enabled", StringUtil.BoolToStr( Locationdescriptionvar_Enabled));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTIONVAR_Width", StringUtil.RTrim( Locationdescriptionvar_Width));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTIONVAR_Height", StringUtil.RTrim( Locationdescriptionvar_Height));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTIONVAR_Skin", StringUtil.RTrim( Locationdescriptionvar_Skin));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTIONVAR_Toolbar", StringUtil.RTrim( Locationdescriptionvar_Toolbar));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTIONVAR_Customtoolbar", StringUtil.RTrim( Locationdescriptionvar_Customtoolbar));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTIONVAR_Customconfiguration", StringUtil.RTrim( Locationdescriptionvar_Customconfiguration));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTIONVAR_Captionclass", StringUtil.RTrim( Locationdescriptionvar_Captionclass));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTIONVAR_Captionstyle", StringUtil.RTrim( Locationdescriptionvar_Captionstyle));
         GxWebStd.gx_hidden_field( context, "LOCATIONDESCRIPTIONVAR_Captionposition", StringUtil.RTrim( Locationdescriptionvar_Captionposition));
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
            WEC02( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTC02( ) ;
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_viewlocation.aspx"+UrlEncode(AV9LocationId.ToString()) + "," + UrlEncode(AV11OrganisationId.ToString());
         return formatLink("wp_viewlocation.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WP_ViewLocation" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "View Location", "") ;
      }

      protected void WBC00( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Location Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_ViewLocation.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLocationName_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtLocationName_Internalname, A31LocationName, StringUtil.RTrim( context.localUtil.Format( A31LocationName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", edtLocationName_Link, "", "", "", edtLocationName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_WP_ViewLocation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLocationEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtLocationEmail_Internalname, A34LocationEmail, StringUtil.RTrim( context.localUtil.Format( A34LocationEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A34LocationEmail, "", "", "", edtLocationEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_WP_ViewLocation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, divUnnamedtable5_Visible, 0, "px", 0, "px", "CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_phone_Internalname, context.GetMessage( "Phone", ""), "", "", lblTransactiondetail_phone_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_ViewLocation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable10_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable11_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLocationphonecode_description_Internalname, context.GetMessage( "Location Phone Code_Description", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocationphonecode_description_Internalname, AV10LocationPhoneCode_Description, StringUtil.RTrim( context.localUtil.Format( AV10LocationPhoneCode_Description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLocationphonecode_description_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLocationphonecode_description_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_ViewLocation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLocationPhoneNumber_Internalname, context.GetMessage( "Location Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtLocationPhoneNumber_Internalname, A356LocationPhoneNumber, StringUtil.RTrim( context.localUtil.Format( A356LocationPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationPhoneNumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationPhoneNumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_ViewLocation.htm");
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
            GxWebStd.gx_div_start( context, divLocationphone_cell_Internalname, 1, 0, "px", 0, "px", divLocationphone_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtLocationPhone_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationPhone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLocationPhone_Internalname, context.GetMessage( "Phone", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A35LocationPhone);
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtLocationPhone_Internalname, StringUtil.RTrim( A35LocationPhone), StringUtil.RTrim( context.localUtil.Format( A35LocationPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtLocationPhone_Jsonclick, 0, "Attribute", "", "", "", "", edtLocationPhone_Visible, edtLocationPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_WP_ViewLocation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblProductserviceimagetext_Internalname, context.GetMessage( "Images", ""), "", "", lblProductserviceimagetext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_ViewLocation.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUcfilecell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucImageuploaduc.SetProperty("FailedUploadMessage", Imageuploaduc_Faileduploadmessage);
            ucImageuploaduc.SetProperty("MaxNumberOfFiles", Imageuploaduc_Maxnumberoffiles);
            ucImageuploaduc.SetProperty("isReadOnlyMode", Imageuploaduc_Isreadonlymode);
            ucImageuploaduc.SetProperty("MaxFileSize", Imageuploaduc_Maxfilesize);
            ucImageuploaduc.SetProperty("FilesToEdit", AV5FilesToUpdate);
            ucImageuploaduc.Render(context, "uc_customimageupload", Imageuploaduc_Internalname, "IMAGEUPLOADUCContainer");
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
            GxWebStd.gx_div_start( context, divUnnamedtable7_Internalname, divUnnamedtable7_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell CKEditor", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Locationdescriptionvar_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, Locationdescriptionvar_Internalname, context.GetMessage( "Description", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* User Defined Control */
            ucLocationdescriptionvar.SetProperty("Width", Locationdescriptionvar_Width);
            ucLocationdescriptionvar.SetProperty("Height", Locationdescriptionvar_Height);
            ucLocationdescriptionvar.SetProperty("Attribute", AV8LocationDescriptionVar);
            ucLocationdescriptionvar.SetProperty("Skin", Locationdescriptionvar_Skin);
            ucLocationdescriptionvar.SetProperty("Toolbar", Locationdescriptionvar_Toolbar);
            ucLocationdescriptionvar.SetProperty("CustomToolbar", Locationdescriptionvar_Customtoolbar);
            ucLocationdescriptionvar.SetProperty("CustomConfiguration", Locationdescriptionvar_Customconfiguration);
            ucLocationdescriptionvar.SetProperty("CaptionClass", Locationdescriptionvar_Captionclass);
            ucLocationdescriptionvar.SetProperty("CaptionStyle", Locationdescriptionvar_Captionstyle);
            ucLocationdescriptionvar.SetProperty("CaptionPosition", Locationdescriptionvar_Captionposition);
            ucLocationdescriptionvar.Render(context, "fckeditor", Locationdescriptionvar_Internalname, "LOCATIONDESCRIPTIONVARContainer");
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
            GxWebStd.gx_div_start( context, divUnnamedtable8_Internalname, divUnnamedtable8_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_textblockdescriptionlabel_Internalname, context.GetMessage( "Description", ""), "", "", lblTransactiondetail_textblockdescriptionlabel_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_ViewLocation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable9_Internalname, 1, 0, "px", 0, "px", "HTMLTextOverfow", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_descriptiontext_Internalname, lblTransactiondetail_descriptiontext_Caption, "", "", lblTransactiondetail_descriptiontext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DynamicFormHTMLEditor", 0, "", 1, 1, 0, 1, "HLP_WP_ViewLocation.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, context.GetMessage( "Address Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_ViewLocation.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationAddressLine1_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLocationAddressLine1_Internalname, context.GetMessage( "Address Line 1", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtLocationAddressLine1_Internalname, A330LocationAddressLine1, StringUtil.RTrim( context.localUtil.Format( A330LocationAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationAddressLine1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationAddressLine1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_ViewLocation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationAddressLine2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLocationAddressLine2_Internalname, context.GetMessage( "Address Line 2", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtLocationAddressLine2_Internalname, A331LocationAddressLine2, StringUtil.RTrim( context.localUtil.Format( A331LocationAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationAddressLine2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationAddressLine2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_ViewLocation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationZipCode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLocationZipCode_Internalname, context.GetMessage( "Zip Code", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtLocationZipCode_Internalname, A329LocationZipCode, StringUtil.RTrim( context.localUtil.Format( A329LocationZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationZipCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationZipCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_ViewLocation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocationCity_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtLocationCity_Internalname, context.GetMessage( "City", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtLocationCity_Internalname, A328LocationCity, StringUtil.RTrim( context.localUtil.Format( A328LocationCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationCity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocationCity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_ViewLocation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLocationcountry_description_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLocationcountry_description_Internalname, context.GetMessage( "Country", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocationcountry_description_Internalname, AV7LocationCountry_Description, StringUtil.RTrim( context.localUtil.Format( AV7LocationCountry_Description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLocationcountry_description_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLocationcountry_description_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_ViewLocation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "Edit", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_ViewLocation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_ViewLocation.htm");
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
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtLocationId_Internalname, A29LocationId.ToString(), A29LocationId.ToString(), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocationId_Jsonclick, 0, "Attribute", "", "", "", "", edtLocationId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_WP_ViewLocation.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtOrganisationId_Internalname, A11OrganisationId.ToString(), A11OrganisationId.ToString(), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrganisationId_Jsonclick, 0, "Attribute", "", "", "", "", edtOrganisationId_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "Id", "", false, "", "HLP_WP_ViewLocation.htm");
            /* Static Bitmap Variable */
            ClassString = "ImageAttribute";
            StyleString = "";
            A494LocationImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000LocationImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage)) ? A40000LocationImage_GXI : context.PathToRelativeUrl( A494LocationImage));
            GxWebStd.gx_bitmap( context, imgLocationImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgLocationImage_Visible, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A494LocationImage_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_WP_ViewLocation.htm");
            /* Multiple line edit */
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtLocationDescription_Internalname, A36LocationDescription, "", "", 0, edtLocationDescription_Visible, 0, 0, 40, "chr", 3, "row", 0, StyleString, ClassString, "", "", "2097152", 1, 0, "", "", -1, true, "LongDescription", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WP_ViewLocation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void STARTC02( )
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
         Form.Meta.addItem("description", context.GetMessage( "View Location", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPC00( ) ;
      }

      protected void WSC02( )
      {
         STARTC02( ) ;
         EVTC02( ) ;
      }

      protected void EVTC02( )
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
                              E11C02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E12C02 ();
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
                                    E13C02 ();
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

      protected void WEC02( )
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

      protected void PAC02( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_viewlocation.aspx")), "wp_viewlocation.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_viewlocation.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "LocationId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV9LocationId = StringUtil.StrToGuid( gxfirstwebparm);
                     AssignAttri("", false, "AV9LocationId", AV9LocationId.ToString());
                     GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV9LocationId, context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV11OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
                        AssignAttri("", false, "AV11OrganisationId", AV11OrganisationId.ToString());
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
               GX_FocusControl = edtavLocationphonecode_description_Internalname;
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
         RFC02( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavLocationphonecode_description_Enabled = 0;
         AssignProp("", false, edtavLocationphonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationphonecode_description_Enabled), 5, 0), true);
         edtavLocationcountry_description_Enabled = 0;
         AssignProp("", false, edtavLocationcountry_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationcountry_description_Enabled), 5, 0), true);
      }

      protected void RFC02( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00C02 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A36LocationDescription = H00C02_A36LocationDescription[0];
               AssignAttri("", false, "A36LocationDescription", A36LocationDescription);
               A40000LocationImage_GXI = H00C02_A40000LocationImage_GXI[0];
               n40000LocationImage_GXI = H00C02_n40000LocationImage_GXI[0];
               AssignProp("", false, imgLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage)) ? A40000LocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A494LocationImage))), true);
               AssignProp("", false, imgLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A494LocationImage), true);
               A11OrganisationId = H00C02_A11OrganisationId[0];
               AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
               GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONID", GetSecureSignedToken( "", A11OrganisationId, context));
               A29LocationId = H00C02_A29LocationId[0];
               AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
               GxWebStd.gx_hidden_field( context, "gxhash_LOCATIONID", GetSecureSignedToken( "", A29LocationId, context));
               A328LocationCity = H00C02_A328LocationCity[0];
               AssignAttri("", false, "A328LocationCity", A328LocationCity);
               A329LocationZipCode = H00C02_A329LocationZipCode[0];
               AssignAttri("", false, "A329LocationZipCode", A329LocationZipCode);
               A331LocationAddressLine2 = H00C02_A331LocationAddressLine2[0];
               AssignAttri("", false, "A331LocationAddressLine2", A331LocationAddressLine2);
               A330LocationAddressLine1 = H00C02_A330LocationAddressLine1[0];
               AssignAttri("", false, "A330LocationAddressLine1", A330LocationAddressLine1);
               A35LocationPhone = H00C02_A35LocationPhone[0];
               AssignAttri("", false, "A35LocationPhone", A35LocationPhone);
               A356LocationPhoneNumber = H00C02_A356LocationPhoneNumber[0];
               AssignAttri("", false, "A356LocationPhoneNumber", A356LocationPhoneNumber);
               A34LocationEmail = H00C02_A34LocationEmail[0];
               AssignAttri("", false, "A34LocationEmail", A34LocationEmail);
               A31LocationName = H00C02_A31LocationName[0];
               AssignAttri("", false, "A31LocationName", A31LocationName);
               A494LocationImage = H00C02_A494LocationImage[0];
               n494LocationImage = H00C02_n494LocationImage[0];
               AssignAttri("", false, "A494LocationImage", A494LocationImage);
               AssignProp("", false, imgLocationImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A494LocationImage)) ? A40000LocationImage_GXI : context.convertURL( context.PathToRelativeUrl( A494LocationImage))), true);
               AssignProp("", false, imgLocationImage_Internalname, "SrcSet", context.GetImageSrcSet( A494LocationImage), true);
               /* Execute user event: Load */
               E12C02 ();
               pr_default.readNext(0);
            }
            pr_default.close(0);
            WBC00( ) ;
         }
      }

      protected void send_integrity_lvl_hashesC02( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_LOCATIONID", GetSecureSignedToken( "", A29LocationId, context));
         GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONID", GetSecureSignedToken( "", A11OrganisationId, context));
      }

      protected void before_start_formulas( )
      {
         edtavLocationphonecode_description_Enabled = 0;
         AssignProp("", false, edtavLocationphonecode_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationphonecode_description_Enabled), 5, 0), true);
         edtavLocationcountry_description_Enabled = 0;
         AssignProp("", false, edtavLocationcountry_description_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavLocationcountry_description_Enabled), 5, 0), true);
         edtLocationName_Enabled = 0;
         AssignProp("", false, edtLocationName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationName_Enabled), 5, 0), true);
         edtLocationEmail_Enabled = 0;
         AssignProp("", false, edtLocationEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationEmail_Enabled), 5, 0), true);
         edtLocationPhoneNumber_Enabled = 0;
         AssignProp("", false, edtLocationPhoneNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationPhoneNumber_Enabled), 5, 0), true);
         edtLocationPhone_Enabled = 0;
         AssignProp("", false, edtLocationPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationPhone_Enabled), 5, 0), true);
         edtLocationAddressLine1_Enabled = 0;
         AssignProp("", false, edtLocationAddressLine1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationAddressLine1_Enabled), 5, 0), true);
         edtLocationAddressLine2_Enabled = 0;
         AssignProp("", false, edtLocationAddressLine2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationAddressLine2_Enabled), 5, 0), true);
         edtLocationZipCode_Enabled = 0;
         AssignProp("", false, edtLocationZipCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationZipCode_Enabled), 5, 0), true);
         edtLocationCity_Enabled = 0;
         AssignProp("", false, edtLocationCity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationCity_Enabled), 5, 0), true);
         edtLocationId_Enabled = 0;
         AssignProp("", false, edtLocationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationId_Enabled), 5, 0), true);
         edtOrganisationId_Enabled = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Enabled), 5, 0), true);
         imgLocationImage_Enabled = 0;
         AssignProp("", false, imgLocationImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgLocationImage_Enabled), 5, 0), true);
         edtLocationDescription_Enabled = 0;
         AssignProp("", false, edtLocationDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocationDescription_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPC00( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11C02 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFILESTOUPDATE"), AV5FilesToUpdate);
            /* Read saved values. */
            AV8LocationDescriptionVar = cgiGet( "vLOCATIONDESCRIPTIONVAR");
            Imageuploaduc_Faileduploadmessage = cgiGet( "IMAGEUPLOADUC_Faileduploadmessage");
            Imageuploaduc_Maxnumberoffiles = cgiGet( "IMAGEUPLOADUC_Maxnumberoffiles");
            Imageuploaduc_Isreadonlymode = cgiGet( "IMAGEUPLOADUC_Isreadonlymode");
            Imageuploaduc_Maxfilesize = cgiGet( "IMAGEUPLOADUC_Maxfilesize");
            Locationdescriptionvar_Enabled = StringUtil.StrToBool( cgiGet( "LOCATIONDESCRIPTIONVAR_Enabled"));
            Locationdescriptionvar_Width = cgiGet( "LOCATIONDESCRIPTIONVAR_Width");
            Locationdescriptionvar_Height = cgiGet( "LOCATIONDESCRIPTIONVAR_Height");
            Locationdescriptionvar_Skin = cgiGet( "LOCATIONDESCRIPTIONVAR_Skin");
            Locationdescriptionvar_Toolbar = cgiGet( "LOCATIONDESCRIPTIONVAR_Toolbar");
            Locationdescriptionvar_Customtoolbar = cgiGet( "LOCATIONDESCRIPTIONVAR_Customtoolbar");
            Locationdescriptionvar_Customconfiguration = cgiGet( "LOCATIONDESCRIPTIONVAR_Customconfiguration");
            Locationdescriptionvar_Captionclass = cgiGet( "LOCATIONDESCRIPTIONVAR_Captionclass");
            Locationdescriptionvar_Captionstyle = cgiGet( "LOCATIONDESCRIPTIONVAR_Captionstyle");
            Locationdescriptionvar_Captionposition = cgiGet( "LOCATIONDESCRIPTIONVAR_Captionposition");
            /* Read variables values. */
            A31LocationName = cgiGet( edtLocationName_Internalname);
            AssignAttri("", false, "A31LocationName", A31LocationName);
            A34LocationEmail = cgiGet( edtLocationEmail_Internalname);
            AssignAttri("", false, "A34LocationEmail", A34LocationEmail);
            AV10LocationPhoneCode_Description = cgiGet( edtavLocationphonecode_description_Internalname);
            AssignAttri("", false, "AV10LocationPhoneCode_Description", AV10LocationPhoneCode_Description);
            A356LocationPhoneNumber = cgiGet( edtLocationPhoneNumber_Internalname);
            AssignAttri("", false, "A356LocationPhoneNumber", A356LocationPhoneNumber);
            A35LocationPhone = cgiGet( edtLocationPhone_Internalname);
            AssignAttri("", false, "A35LocationPhone", A35LocationPhone);
            A330LocationAddressLine1 = cgiGet( edtLocationAddressLine1_Internalname);
            AssignAttri("", false, "A330LocationAddressLine1", A330LocationAddressLine1);
            A331LocationAddressLine2 = cgiGet( edtLocationAddressLine2_Internalname);
            AssignAttri("", false, "A331LocationAddressLine2", A331LocationAddressLine2);
            A329LocationZipCode = cgiGet( edtLocationZipCode_Internalname);
            AssignAttri("", false, "A329LocationZipCode", A329LocationZipCode);
            A328LocationCity = cgiGet( edtLocationCity_Internalname);
            AssignAttri("", false, "A328LocationCity", A328LocationCity);
            AV7LocationCountry_Description = cgiGet( edtavLocationcountry_description_Internalname);
            AssignAttri("", false, "AV7LocationCountry_Description", AV7LocationCountry_Description);
            A29LocationId = StringUtil.StrToGuid( cgiGet( edtLocationId_Internalname));
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            GxWebStd.gx_hidden_field( context, "gxhash_LOCATIONID", GetSecureSignedToken( "", A29LocationId, context));
            A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONID", GetSecureSignedToken( "", A11OrganisationId, context));
            A494LocationImage = cgiGet( imgLocationImage_Internalname);
            n494LocationImage = false;
            AssignAttri("", false, "A494LocationImage", A494LocationImage);
            A36LocationDescription = cgiGet( edtLocationDescription_Internalname);
            AssignAttri("", false, "A36LocationDescription", A36LocationDescription);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"WP_ViewLocation");
            A29LocationId = StringUtil.StrToGuid( cgiGet( edtLocationId_Internalname));
            AssignAttri("", false, "A29LocationId", A29LocationId.ToString());
            GxWebStd.gx_hidden_field( context, "gxhash_LOCATIONID", GetSecureSignedToken( "", A29LocationId, context));
            forbiddenHiddens.Add("LocationId", A29LocationId.ToString());
            A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
            AssignAttri("", false, "A11OrganisationId", A11OrganisationId.ToString());
            GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONID", GetSecureSignedToken( "", A11OrganisationId, context));
            forbiddenHiddens.Add("OrganisationId", A11OrganisationId.ToString());
            A36LocationDescription = cgiGet( edtLocationDescription_Internalname);
            AssignAttri("", false, "A36LocationDescription", A36LocationDescription);
            forbiddenHiddens.Add("LocationDescription", A36LocationDescription);
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("wp_viewlocation:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11C02 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11C02( )
      {
         /* Start Routine */
         returnInSub = false;
         Gx_mode = "DSP";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         GXt_objcol_SdtSDT_FileUploadData1 = AV5FilesToUpdate;
         new prc_getlocationimages(context ).execute(  AV9LocationId, out  GXt_objcol_SdtSDT_FileUploadData1) ;
         AV5FilesToUpdate = GXt_objcol_SdtSDT_FileUploadData1;
         edtLocationId_Visible = 0;
         AssignProp("", false, edtLocationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationId_Visible), 5, 0), true);
         edtOrganisationId_Visible = 0;
         AssignProp("", false, edtOrganisationId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationId_Visible), 5, 0), true);
         imgLocationImage_Visible = 0;
         AssignProp("", false, imgLocationImage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgLocationImage_Visible), 5, 0), true);
         edtLocationDescription_Visible = 0;
         AssignProp("", false, edtLocationDescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationDescription_Visible), 5, 0), true);
      }

      protected void nextLoad( )
      {
      }

      protected void E12C02( )
      {
         /* Load Routine */
         returnInSub = false;
         Gx_mode = "DSP";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         GXt_boolean2 = AV12TempBoolean;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_locationview_Execute", out  GXt_boolean2) ;
         AV12TempBoolean = GXt_boolean2;
         if ( AV12TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_locationview.aspx"+UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtLocationName_Link = formatLink("trn_locationview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp("", false, edtLocationName_Internalname, "Link", edtLocationName_Link, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            edtLocationPhone_Visible = 0;
            AssignProp("", false, edtLocationPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationPhone_Visible), 5, 0), true);
            divLocationphone_cell_Class = "Invisible";
            AssignProp("", false, divLocationphone_cell_Internalname, "Class", divLocationphone_cell_Class, true);
         }
         else
         {
            edtLocationPhone_Visible = 1;
            AssignProp("", false, edtLocationPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLocationPhone_Visible), 5, 0), true);
            divLocationphone_cell_Class = "col-xs-12 DataContentCell";
            AssignProp("", false, divLocationphone_cell_Internalname, "Class", divLocationphone_cell_Class, true);
         }
         divUnnamedtable5_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp("", false, divUnnamedtable5_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable5_Visible), 5, 0), true);
         divUnnamedtable7_Visible = (((StringUtil.StrCmp(Gx_mode, "INS")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0)) ? 1 : 0);
         AssignProp("", false, divUnnamedtable7_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable7_Visible), 5, 0), true);
         divUnnamedtable8_Visible = (((StringUtil.StrCmp(Gx_mode, "DSP")==0)) ? 1 : 0);
         AssignProp("", false, divUnnamedtable8_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable8_Visible), 5, 0), true);
         lblTransactiondetail_descriptiontext_Caption = A36LocationDescription;
         AssignProp("", false, lblTransactiondetail_descriptiontext_Internalname, "Caption", lblTransactiondetail_descriptiontext_Caption, true);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E13C02 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E13C02( )
      {
         /* Enter Routine */
         returnInSub = false;
         CallWebObject(formatLink("trn_location.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(A29LocationId.ToString()),UrlEncode(A11OrganisationId.ToString())}, new string[] {"Mode","LocationId","OrganisationId"}) );
         context.wjLocDisableFrm = 1;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV9LocationId = (Guid)getParm(obj,0);
         AssignAttri("", false, "AV9LocationId", AV9LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV9LocationId, context));
         AV11OrganisationId = (Guid)getParm(obj,1);
         AssignAttri("", false, "AV11OrganisationId", AV11OrganisationId.ToString());
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
         PAC02( ) ;
         WSC02( ) ;
         WEC02( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20257188582571", true, true);
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
         context.AddJavascriptSource("wp_viewlocation.js", "?20257188582571", false, true);
         context.AddJavascriptSource("UserControls/UC_CustomImageUploadRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtLocationName_Internalname = "LOCATIONNAME";
         edtLocationEmail_Internalname = "LOCATIONEMAIL";
         lblTransactiondetail_phone_Internalname = "TRANSACTIONDETAIL_PHONE";
         edtavLocationphonecode_description_Internalname = "vLOCATIONPHONECODE_DESCRIPTION";
         divUnnamedtable11_Internalname = "UNNAMEDTABLE11";
         edtLocationPhoneNumber_Internalname = "LOCATIONPHONENUMBER";
         divUnnamedtable10_Internalname = "UNNAMEDTABLE10";
         divUnnamedtable5_Internalname = "UNNAMEDTABLE5";
         edtLocationPhone_Internalname = "LOCATIONPHONE";
         divLocationphone_cell_Internalname = "LOCATIONPHONE_CELL";
         lblProductserviceimagetext_Internalname = "PRODUCTSERVICEIMAGETEXT";
         Imageuploaduc_Internalname = "IMAGEUPLOADUC";
         divUcfilecell_Internalname = "UCFILECELL";
         divUnnamedtable6_Internalname = "UNNAMEDTABLE6";
         Locationdescriptionvar_Internalname = "LOCATIONDESCRIPTIONVAR";
         divUnnamedtable7_Internalname = "UNNAMEDTABLE7";
         lblTransactiondetail_textblockdescriptionlabel_Internalname = "TRANSACTIONDETAIL_TEXTBLOCKDESCRIPTIONLABEL";
         lblTransactiondetail_descriptiontext_Internalname = "TRANSACTIONDETAIL_DESCRIPTIONTEXT";
         divUnnamedtable9_Internalname = "UNNAMEDTABLE9";
         divUnnamedtable8_Internalname = "UNNAMEDTABLE8";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         grpUnnamedgroup2_Internalname = "UNNAMEDGROUP2";
         edtLocationAddressLine1_Internalname = "LOCATIONADDRESSLINE1";
         edtLocationAddressLine2_Internalname = "LOCATIONADDRESSLINE2";
         edtLocationZipCode_Internalname = "LOCATIONZIPCODE";
         edtLocationCity_Internalname = "LOCATIONCITY";
         edtavLocationcountry_description_Internalname = "vLOCATIONCOUNTRY_DESCRIPTION";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         grpUnnamedgroup4_Internalname = "UNNAMEDGROUP4";
         divTransactiondetail_tableattributes_Internalname = "TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         edtLocationId_Internalname = "LOCATIONID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         imgLocationImage_Internalname = "LOCATIONIMAGE";
         edtLocationDescription_Internalname = "LOCATIONDESCRIPTION";
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
         edtLocationDescription_Enabled = 0;
         imgLocationImage_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtLocationId_Enabled = 0;
         edtLocationDescription_Visible = 1;
         imgLocationImage_Visible = 1;
         edtOrganisationId_Jsonclick = "";
         edtOrganisationId_Visible = 1;
         edtLocationId_Jsonclick = "";
         edtLocationId_Visible = 1;
         edtavLocationcountry_description_Jsonclick = "";
         edtavLocationcountry_description_Enabled = 1;
         edtLocationCity_Jsonclick = "";
         edtLocationCity_Enabled = 0;
         edtLocationZipCode_Jsonclick = "";
         edtLocationZipCode_Enabled = 0;
         edtLocationAddressLine2_Jsonclick = "";
         edtLocationAddressLine2_Enabled = 0;
         edtLocationAddressLine1_Jsonclick = "";
         edtLocationAddressLine1_Enabled = 0;
         lblTransactiondetail_descriptiontext_Caption = "";
         divUnnamedtable8_Visible = 1;
         Locationdescriptionvar_Enabled = Convert.ToBoolean( 1);
         divUnnamedtable7_Visible = 1;
         edtLocationPhone_Jsonclick = "";
         edtLocationPhone_Enabled = 0;
         edtLocationPhone_Visible = 1;
         divLocationphone_cell_Class = "col-xs-12";
         edtLocationPhoneNumber_Jsonclick = "";
         edtLocationPhoneNumber_Enabled = 0;
         edtavLocationphonecode_description_Jsonclick = "";
         edtavLocationphonecode_description_Enabled = 1;
         divUnnamedtable5_Visible = 1;
         edtLocationEmail_Jsonclick = "";
         edtLocationEmail_Enabled = 0;
         edtLocationName_Jsonclick = "";
         edtLocationName_Link = "";
         edtLocationName_Enabled = 0;
         Locationdescriptionvar_Captionposition = "Left";
         Locationdescriptionvar_Captionstyle = "";
         Locationdescriptionvar_Captionclass = "col-sm-4 AttributeLabel";
         Locationdescriptionvar_Customconfiguration = "myconfig.js";
         Locationdescriptionvar_Customtoolbar = "myToolbar";
         Locationdescriptionvar_Toolbar = "Custom";
         Locationdescriptionvar_Skin = "default";
         Locationdescriptionvar_Height = "250";
         Locationdescriptionvar_Width = "100%";
         Imageuploaduc_Maxfilesize = "10";
         Imageuploaduc_Isreadonlymode = "true";
         Imageuploaduc_Maxnumberoffiles = "5";
         Imageuploaduc_Faileduploadmessage = "Upload Failed";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "View Location", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV9LocationId","fld":"vLOCATIONID","hsh":true},{"av":"A29LocationId","fld":"LOCATIONID","hsh":true},{"av":"A11OrganisationId","fld":"ORGANISATIONID","hsh":true},{"av":"A36LocationDescription","fld":"LOCATIONDESCRIPTION"}]}""");
         setEventMetadata("ENTER","""{"handler":"E13C02","iparms":[{"av":"A29LocationId","fld":"LOCATIONID","hsh":true},{"av":"A11OrganisationId","fld":"ORGANISATIONID","hsh":true}]}""");
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
         wcpOAV9LocationId = Guid.Empty;
         wcpOAV11OrganisationId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         forbiddenHiddens = new GXProperties();
         A36LocationDescription = "";
         AV5FilesToUpdate = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version2");
         AV8LocationDescriptionVar = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A31LocationName = "";
         A34LocationEmail = "";
         lblTransactiondetail_phone_Jsonclick = "";
         AV10LocationPhoneCode_Description = "";
         A356LocationPhoneNumber = "";
         gxphoneLink = "";
         A35LocationPhone = "";
         lblProductserviceimagetext_Jsonclick = "";
         ucImageuploaduc = new GXUserControl();
         ucLocationdescriptionvar = new GXUserControl();
         lblTransactiondetail_textblockdescriptionlabel_Jsonclick = "";
         lblTransactiondetail_descriptiontext_Jsonclick = "";
         A330LocationAddressLine1 = "";
         A331LocationAddressLine2 = "";
         A329LocationZipCode = "";
         A328LocationCity = "";
         AV7LocationCountry_Description = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         A494LocationImage = "";
         A40000LocationImage_GXI = "";
         sImgUrl = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H00C02_A36LocationDescription = new string[] {""} ;
         H00C02_A40000LocationImage_GXI = new string[] {""} ;
         H00C02_n40000LocationImage_GXI = new bool[] {false} ;
         H00C02_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00C02_A29LocationId = new Guid[] {Guid.Empty} ;
         H00C02_A328LocationCity = new string[] {""} ;
         H00C02_A329LocationZipCode = new string[] {""} ;
         H00C02_A331LocationAddressLine2 = new string[] {""} ;
         H00C02_A330LocationAddressLine1 = new string[] {""} ;
         H00C02_A35LocationPhone = new string[] {""} ;
         H00C02_A356LocationPhoneNumber = new string[] {""} ;
         H00C02_A34LocationEmail = new string[] {""} ;
         H00C02_A31LocationName = new string[] {""} ;
         H00C02_A494LocationImage = new string[] {""} ;
         H00C02_n494LocationImage = new bool[] {false} ;
         hsh = "";
         Gx_mode = "";
         GXt_objcol_SdtSDT_FileUploadData1 = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version2");
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_viewlocation__default(),
            new Object[][] {
                new Object[] {
               H00C02_A36LocationDescription, H00C02_A40000LocationImage_GXI, H00C02_n40000LocationImage_GXI, H00C02_A11OrganisationId, H00C02_A29LocationId, H00C02_A328LocationCity, H00C02_A329LocationZipCode, H00C02_A331LocationAddressLine2, H00C02_A330LocationAddressLine1, H00C02_A35LocationPhone,
               H00C02_A356LocationPhoneNumber, H00C02_A34LocationEmail, H00C02_A31LocationName, H00C02_A494LocationImage, H00C02_n494LocationImage
               }
            }
         );
         /* GeneXus formulas. */
         edtavLocationphonecode_description_Enabled = 0;
         edtavLocationcountry_description_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtLocationName_Enabled ;
      private int edtLocationEmail_Enabled ;
      private int divUnnamedtable5_Visible ;
      private int edtavLocationphonecode_description_Enabled ;
      private int edtLocationPhoneNumber_Enabled ;
      private int edtLocationPhone_Visible ;
      private int edtLocationPhone_Enabled ;
      private int divUnnamedtable7_Visible ;
      private int divUnnamedtable8_Visible ;
      private int edtLocationAddressLine1_Enabled ;
      private int edtLocationAddressLine2_Enabled ;
      private int edtLocationZipCode_Enabled ;
      private int edtLocationCity_Enabled ;
      private int edtavLocationcountry_description_Enabled ;
      private int edtLocationId_Visible ;
      private int edtOrganisationId_Visible ;
      private int imgLocationImage_Visible ;
      private int edtLocationDescription_Visible ;
      private int edtLocationId_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int imgLocationImage_Enabled ;
      private int edtLocationDescription_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Imageuploaduc_Faileduploadmessage ;
      private string Imageuploaduc_Maxnumberoffiles ;
      private string Imageuploaduc_Isreadonlymode ;
      private string Imageuploaduc_Maxfilesize ;
      private string Locationdescriptionvar_Width ;
      private string Locationdescriptionvar_Height ;
      private string Locationdescriptionvar_Skin ;
      private string Locationdescriptionvar_Toolbar ;
      private string Locationdescriptionvar_Customtoolbar ;
      private string Locationdescriptionvar_Customconfiguration ;
      private string Locationdescriptionvar_Captionclass ;
      private string Locationdescriptionvar_Captionstyle ;
      private string Locationdescriptionvar_Captionposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string grpUnnamedgroup2_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string edtLocationName_Internalname ;
      private string TempTags ;
      private string edtLocationName_Link ;
      private string edtLocationName_Jsonclick ;
      private string edtLocationEmail_Internalname ;
      private string edtLocationEmail_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string lblTransactiondetail_phone_Internalname ;
      private string lblTransactiondetail_phone_Jsonclick ;
      private string divUnnamedtable10_Internalname ;
      private string divUnnamedtable11_Internalname ;
      private string edtavLocationphonecode_description_Internalname ;
      private string edtavLocationphonecode_description_Jsonclick ;
      private string edtLocationPhoneNumber_Internalname ;
      private string edtLocationPhoneNumber_Jsonclick ;
      private string divLocationphone_cell_Internalname ;
      private string divLocationphone_cell_Class ;
      private string edtLocationPhone_Internalname ;
      private string gxphoneLink ;
      private string A35LocationPhone ;
      private string edtLocationPhone_Jsonclick ;
      private string divUnnamedtable6_Internalname ;
      private string lblProductserviceimagetext_Internalname ;
      private string lblProductserviceimagetext_Jsonclick ;
      private string divUcfilecell_Internalname ;
      private string Imageuploaduc_Internalname ;
      private string divUnnamedtable7_Internalname ;
      private string Locationdescriptionvar_Internalname ;
      private string divUnnamedtable8_Internalname ;
      private string lblTransactiondetail_textblockdescriptionlabel_Internalname ;
      private string lblTransactiondetail_textblockdescriptionlabel_Jsonclick ;
      private string divUnnamedtable9_Internalname ;
      private string lblTransactiondetail_descriptiontext_Internalname ;
      private string lblTransactiondetail_descriptiontext_Caption ;
      private string lblTransactiondetail_descriptiontext_Jsonclick ;
      private string grpUnnamedgroup4_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtLocationAddressLine1_Internalname ;
      private string edtLocationAddressLine1_Jsonclick ;
      private string edtLocationAddressLine2_Internalname ;
      private string edtLocationAddressLine2_Jsonclick ;
      private string edtLocationZipCode_Internalname ;
      private string edtLocationZipCode_Jsonclick ;
      private string edtLocationCity_Internalname ;
      private string edtLocationCity_Jsonclick ;
      private string edtavLocationcountry_description_Internalname ;
      private string edtavLocationcountry_description_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtLocationId_Internalname ;
      private string edtLocationId_Jsonclick ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationId_Jsonclick ;
      private string sImgUrl ;
      private string imgLocationImage_Internalname ;
      private string edtLocationDescription_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string hsh ;
      private string Gx_mode ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Locationdescriptionvar_Enabled ;
      private bool wbLoad ;
      private bool A494LocationImage_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n40000LocationImage_GXI ;
      private bool n494LocationImage ;
      private bool returnInSub ;
      private bool AV12TempBoolean ;
      private bool GXt_boolean2 ;
      private string A36LocationDescription ;
      private string AV8LocationDescriptionVar ;
      private string A31LocationName ;
      private string A34LocationEmail ;
      private string AV10LocationPhoneCode_Description ;
      private string A356LocationPhoneNumber ;
      private string A330LocationAddressLine1 ;
      private string A331LocationAddressLine2 ;
      private string A329LocationZipCode ;
      private string A328LocationCity ;
      private string AV7LocationCountry_Description ;
      private string A40000LocationImage_GXI ;
      private string A494LocationImage ;
      private Guid AV9LocationId ;
      private Guid AV11OrganisationId ;
      private Guid wcpOAV9LocationId ;
      private Guid wcpOAV11OrganisationId ;
      private Guid A29LocationId ;
      private Guid A11OrganisationId ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucImageuploaduc ;
      private GXUserControl ucLocationdescriptionvar ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV5FilesToUpdate ;
      private IDataStoreProvider pr_default ;
      private string[] H00C02_A36LocationDescription ;
      private string[] H00C02_A40000LocationImage_GXI ;
      private bool[] H00C02_n40000LocationImage_GXI ;
      private Guid[] H00C02_A11OrganisationId ;
      private Guid[] H00C02_A29LocationId ;
      private string[] H00C02_A328LocationCity ;
      private string[] H00C02_A329LocationZipCode ;
      private string[] H00C02_A331LocationAddressLine2 ;
      private string[] H00C02_A330LocationAddressLine1 ;
      private string[] H00C02_A35LocationPhone ;
      private string[] H00C02_A356LocationPhoneNumber ;
      private string[] H00C02_A34LocationEmail ;
      private string[] H00C02_A31LocationName ;
      private string[] H00C02_A494LocationImage ;
      private bool[] H00C02_n494LocationImage ;
      private GXBaseCollection<SdtSDT_FileUploadData> GXt_objcol_SdtSDT_FileUploadData1 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wp_viewlocation__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00C02;
          prmH00C02 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00C02", "SELECT LocationDescription, LocationImage_GXI, OrganisationId, LocationId, LocationCity, LocationZipCode, LocationAddressLine2, LocationAddressLine1, LocationPhone, LocationPhoneNumber, LocationEmail, LocationName, LocationImage FROM Trn_Location ORDER BY LocationId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00C02,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
                ((bool[]) buf[14])[0] = rslt.wasNull(13);
                return;
       }
    }

 }

}
