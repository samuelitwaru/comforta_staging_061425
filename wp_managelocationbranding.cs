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
   public class wp_managelocationbranding : GXDataArea
   {
      public wp_managelocationbranding( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_managelocationbranding( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_OrganisationId ,
                           Guid aP1_LocationId )
      {
         this.AV24OrganisationId = aP0_OrganisationId;
         this.AV31LocationId = aP1_LocationId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavLocationhasmycare = new GXCheckbox();
         chkavLocationhasmyliving = new GXCheckbox();
         chkavLocationhasmyservices = new GXCheckbox();
         chkavLocationhasownbrand = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "OrganisationId");
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
               gxfirstwebparm = GetFirstPar( "OrganisationId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "OrganisationId");
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
            return "wp_managelocationbranding_Execute" ;
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
         PAAW2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTAW2( ) ;
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
         context.AddJavascriptSource("UserControls/UC_ThemeSelectorRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UC_CtaThemeSelectorRender.js", "", false, true);
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
         GXEncryptionTmp = "wp_managelocationbranding.aspx"+UrlEncode(AV24OrganisationId.ToString()) + "," + UrlEncode(AV31LocationId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_managelocationbranding.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV24OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV24OrganisationId, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSELECTEDBRANDTHEME", AV27SelectedBrandTheme);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSELECTEDBRANDTHEME", AV27SelectedBrandTheme);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSELECTEDCTATHEME", AV28SelectedCtaTheme);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSELECTEDCTATHEME", AV28SelectedCtaTheme);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRN_LOCATION", AV32Trn_Location);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRN_LOCATION", AV32Trn_Location);
         }
         GxWebStd.gx_hidden_field( context, "vLOCATIONID", AV31LocationId.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vERRORMESSAGES", AV10ErrorMessages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vERRORMESSAGES", AV10ErrorMessages);
         }
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV24OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV24OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "THEMESELECTOR_Accentcolorvalue", StringUtil.RTrim( Themeselector_Accentcolorvalue));
         GxWebStd.gx_hidden_field( context, "THEMESELECTOR_Backgroundcolorvalue", StringUtil.RTrim( Themeselector_Backgroundcolorvalue));
         GxWebStd.gx_hidden_field( context, "THEMESELECTOR_Bordercolorvalue", StringUtil.RTrim( Themeselector_Bordercolorvalue));
         GxWebStd.gx_hidden_field( context, "THEMESELECTOR_Buttonbgcolorvalue", StringUtil.RTrim( Themeselector_Buttonbgcolorvalue));
         GxWebStd.gx_hidden_field( context, "THEMESELECTOR_Buttontextcolorvalue", StringUtil.RTrim( Themeselector_Buttontextcolorvalue));
         GxWebStd.gx_hidden_field( context, "THEMESELECTOR_Cardbgcolorvalue", StringUtil.RTrim( Themeselector_Cardbgcolorvalue));
         GxWebStd.gx_hidden_field( context, "THEMESELECTOR_Cardtextcolorvalue", StringUtil.RTrim( Themeselector_Cardtextcolorvalue));
         GxWebStd.gx_hidden_field( context, "THEMESELECTOR_Primarycolorvalue", StringUtil.RTrim( Themeselector_Primarycolorvalue));
         GxWebStd.gx_hidden_field( context, "THEMESELECTOR_Secondarycolorvalue", StringUtil.RTrim( Themeselector_Secondarycolorvalue));
         GxWebStd.gx_hidden_field( context, "THEMESELECTOR_Textcolorvalue", StringUtil.RTrim( Themeselector_Textcolorvalue));
         GxWebStd.gx_hidden_field( context, "CALLTOACTIONTHEMESELECTOR_Ctacolor1", StringUtil.RTrim( Calltoactionthemeselector_Ctacolor1));
         GxWebStd.gx_hidden_field( context, "CALLTOACTIONTHEMESELECTOR_Ctacolor2", StringUtil.RTrim( Calltoactionthemeselector_Ctacolor2));
         GxWebStd.gx_hidden_field( context, "CALLTOACTIONTHEMESELECTOR_Ctacolor3", StringUtil.RTrim( Calltoactionthemeselector_Ctacolor3));
         GxWebStd.gx_hidden_field( context, "CALLTOACTIONTHEMESELECTOR_Ctacolor4", StringUtil.RTrim( Calltoactionthemeselector_Ctacolor4));
         GxWebStd.gx_hidden_field( context, "CALLTOACTIONTHEMESELECTOR_Ctacolor5", StringUtil.RTrim( Calltoactionthemeselector_Ctacolor5));
         GxWebStd.gx_hidden_field( context, "CALLTOACTIONTHEMESELECTOR_Ctacolor6", StringUtil.RTrim( Calltoactionthemeselector_Ctacolor6));
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
            WEAW2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTAW2( ) ;
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
         GXEncryptionTmp = "wp_managelocationbranding.aspx"+UrlEncode(AV24OrganisationId.ToString()) + "," + UrlEncode(AV31LocationId.ToString());
         return formatLink("wp_managelocationbranding.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WP_ManageLocationBranding" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Organisation Provisioning", "") ;
      }

      protected void WBAW0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "Location License", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_ManageLocationBranding.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGroupattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAgreementfields_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavLocationhasmycare_Internalname, context.GetMessage( "Location Has My Care", ""), "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavLocationhasmycare_Internalname, StringUtil.BoolToStr( AV35LocationHasMyCare), "", context.GetMessage( "Location Has My Care", ""), 1, chkavLocationhasmycare.Enabled, "true", context.GetMessage( "My Care", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(23, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,23);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavLocationhasmyliving_Internalname, context.GetMessage( "Location Has My Living", ""), "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavLocationhasmyliving_Internalname, StringUtil.BoolToStr( AV36LocationHasMyLiving), "", context.GetMessage( "Location Has My Living", ""), 1, chkavLocationhasmyliving.Enabled, "true", context.GetMessage( "My Living", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(27, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,27);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavLocationhasmyservices_Internalname, context.GetMessage( "Location Has My Services", ""), "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavLocationhasmyservices_Internalname, StringUtil.BoolToStr( AV37LocationHasMyServices), "", context.GetMessage( "Location Has My Services", ""), 1, chkavLocationhasmyservices.Enabled, "true", context.GetMessage( "My Services", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(31, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,31);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavLocationhasownbrand_Internalname, context.GetMessage( "Location Has Own Brand", ""), "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavLocationhasownbrand_Internalname, StringUtil.BoolToStr( AV38LocationHasOwnBrand), "", context.GetMessage( "Location Has Own Brand", ""), 1, chkavLocationhasownbrand.Enabled, "true", context.GetMessage( "My Location Brand Theme", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(35, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,35);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-7", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divBrandthemetable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divBrandtable_Internalname, divBrandtable_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblThemelabel_Internalname, context.GetMessage( "Location Brand Theme", ""), "", "", lblThemelabel_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_ManageLocationBranding.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucThemeselector.SetProperty("SelectedTheme", AV27SelectedBrandTheme);
            ucThemeselector.Render(context, "uc_themeselector", Themeselector_Internalname, "THEMESELECTORContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCtatable_Internalname, divCtatable_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCtatheme_Internalname, context.GetMessage( "Call To Action Theme", ""), "", "", lblCtatheme_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_ManageLocationBranding.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCalltoactionthemeselector.SetProperty("ResultTheme", AV28SelectedCtaTheme);
            ucCalltoactionthemeselector.Render(context, "uc_ctathemeselector", Calltoactionthemeselector_Internalname, "CALLTOACTIONTHEMESELECTORContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_ManageLocationBranding.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_ManageLocationBranding.htm");
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

      protected void STARTAW2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Organisation Provisioning", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPAW0( ) ;
      }

      protected void WSAW2( )
      {
         STARTAW2( ) ;
         EVTAW2( ) ;
      }

      protected void EVTAW2( )
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
                              E11AW2 ();
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
                                    E12AW2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E13AW2 ();
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

      protected void WEAW2( )
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

      protected void PAAW2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_managelocationbranding.aspx")), "wp_managelocationbranding.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_managelocationbranding.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "OrganisationId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV24OrganisationId = StringUtil.StrToGuid( gxfirstwebparm);
                     AssignAttri("", false, "AV24OrganisationId", AV24OrganisationId.ToString());
                     GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV24OrganisationId, context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV31LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
                        AssignAttri("", false, "AV31LocationId", AV31LocationId.ToString());
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
               GX_FocusControl = chkavLocationhasmycare_Internalname;
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
         AV35LocationHasMyCare = StringUtil.StrToBool( StringUtil.BoolToStr( AV35LocationHasMyCare));
         AssignAttri("", false, "AV35LocationHasMyCare", AV35LocationHasMyCare);
         AV36LocationHasMyLiving = StringUtil.StrToBool( StringUtil.BoolToStr( AV36LocationHasMyLiving));
         AssignAttri("", false, "AV36LocationHasMyLiving", AV36LocationHasMyLiving);
         AV37LocationHasMyServices = StringUtil.StrToBool( StringUtil.BoolToStr( AV37LocationHasMyServices));
         AssignAttri("", false, "AV37LocationHasMyServices", AV37LocationHasMyServices);
         AV38LocationHasOwnBrand = StringUtil.StrToBool( StringUtil.BoolToStr( AV38LocationHasOwnBrand));
         AssignAttri("", false, "AV38LocationHasOwnBrand", AV38LocationHasOwnBrand);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFAW2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFAW2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E13AW2 ();
            WBAW0( ) ;
         }
      }

      protected void send_integrity_lvl_hashesAW2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUPAW0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11AW2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vSELECTEDBRANDTHEME"), AV27SelectedBrandTheme);
            ajax_req_read_hidden_sdt(cgiGet( "vSELECTEDCTATHEME"), AV28SelectedCtaTheme);
            /* Read saved values. */
            Themeselector_Accentcolorvalue = cgiGet( "THEMESELECTOR_Accentcolorvalue");
            Themeselector_Backgroundcolorvalue = cgiGet( "THEMESELECTOR_Backgroundcolorvalue");
            Themeselector_Bordercolorvalue = cgiGet( "THEMESELECTOR_Bordercolorvalue");
            Themeselector_Buttonbgcolorvalue = cgiGet( "THEMESELECTOR_Buttonbgcolorvalue");
            Themeselector_Buttontextcolorvalue = cgiGet( "THEMESELECTOR_Buttontextcolorvalue");
            Themeselector_Cardbgcolorvalue = cgiGet( "THEMESELECTOR_Cardbgcolorvalue");
            Themeselector_Cardtextcolorvalue = cgiGet( "THEMESELECTOR_Cardtextcolorvalue");
            Themeselector_Primarycolorvalue = cgiGet( "THEMESELECTOR_Primarycolorvalue");
            Themeselector_Secondarycolorvalue = cgiGet( "THEMESELECTOR_Secondarycolorvalue");
            Themeselector_Textcolorvalue = cgiGet( "THEMESELECTOR_Textcolorvalue");
            Calltoactionthemeselector_Ctacolor1 = cgiGet( "CALLTOACTIONTHEMESELECTOR_Ctacolor1");
            Calltoactionthemeselector_Ctacolor2 = cgiGet( "CALLTOACTIONTHEMESELECTOR_Ctacolor2");
            Calltoactionthemeselector_Ctacolor3 = cgiGet( "CALLTOACTIONTHEMESELECTOR_Ctacolor3");
            Calltoactionthemeselector_Ctacolor4 = cgiGet( "CALLTOACTIONTHEMESELECTOR_Ctacolor4");
            Calltoactionthemeselector_Ctacolor5 = cgiGet( "CALLTOACTIONTHEMESELECTOR_Ctacolor5");
            Calltoactionthemeselector_Ctacolor6 = cgiGet( "CALLTOACTIONTHEMESELECTOR_Ctacolor6");
            /* Read variables values. */
            AV35LocationHasMyCare = StringUtil.StrToBool( cgiGet( chkavLocationhasmycare_Internalname));
            AssignAttri("", false, "AV35LocationHasMyCare", AV35LocationHasMyCare);
            AV36LocationHasMyLiving = StringUtil.StrToBool( cgiGet( chkavLocationhasmyliving_Internalname));
            AssignAttri("", false, "AV36LocationHasMyLiving", AV36LocationHasMyLiving);
            AV37LocationHasMyServices = StringUtil.StrToBool( cgiGet( chkavLocationhasmyservices_Internalname));
            AssignAttri("", false, "AV37LocationHasMyServices", AV37LocationHasMyServices);
            AV38LocationHasOwnBrand = StringUtil.StrToBool( cgiGet( chkavLocationhasownbrand_Internalname));
            AssignAttri("", false, "AV38LocationHasOwnBrand", AV38LocationHasOwnBrand);
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
         E11AW2 ();
         if (returnInSub) return;
      }

      protected void E11AW2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV32Trn_Location.Load(AV31LocationId, AV24OrganisationId);
         AV35LocationHasMyCare = AV32Trn_Location.gxTpr_Locationhasmycare;
         AssignAttri("", false, "AV35LocationHasMyCare", AV35LocationHasMyCare);
         AV36LocationHasMyLiving = AV32Trn_Location.gxTpr_Locationhasmycare;
         AssignAttri("", false, "AV36LocationHasMyLiving", AV36LocationHasMyLiving);
         AV37LocationHasMyServices = AV32Trn_Location.gxTpr_Locationhasmycare;
         AssignAttri("", false, "AV37LocationHasMyServices", AV37LocationHasMyServices);
         AV38LocationHasOwnBrand = AV32Trn_Location.gxTpr_Locationhasownbrand;
         AssignAttri("", false, "AV38LocationHasOwnBrand", AV38LocationHasOwnBrand);
         if ( AV38LocationHasOwnBrand )
         {
            AV33LocationBrandTheme = AV32Trn_Location.gxTpr_Locationbrandtheme;
            AV34LocationCtaTheme = AV32Trn_Location.gxTpr_Locationctatheme;
            if ( AV6DefaultBrandTheme.FromJSonString(AV33LocationBrandTheme, null) )
            {
            }
            if ( AV7DefaultCtaTheme.FromJSonString(AV34LocationCtaTheme, null) )
            {
            }
            /* Execute user subroutine: 'INITIALIZEUCCOLORS' */
            S112 ();
            if (returnInSub) return;
         }
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         divBrandtable_Visible = (((AV38LocationHasOwnBrand)) ? 1 : 0);
         AssignProp("", false, divBrandtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divBrandtable_Visible), 5, 0), true);
         divCtatable_Visible = (((AV38LocationHasOwnBrand)) ? 1 : 0);
         AssignProp("", false, divCtatable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCtatable_Visible), 5, 0), true);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E12AW2 ();
         if (returnInSub) return;
      }

      protected void E12AW2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV32Trn_Location.gxTpr_Locationbrandtheme = AV27SelectedBrandTheme.ToJSonString(false, true);
         AV32Trn_Location.gxTpr_Locationctatheme = AV28SelectedCtaTheme.ToJSonString(false, true);
         AV32Trn_Location.gxTpr_Locationhasmycare = AV35LocationHasMyCare;
         AV32Trn_Location.gxTpr_Locationhasmyliving = AV36LocationHasMyLiving;
         AV32Trn_Location.gxTpr_Locationhasmyservices = AV37LocationHasMyServices;
         AV32Trn_Location.gxTpr_Locationhasownbrand = AV38LocationHasOwnBrand;
         if ( AV32Trn_Location.Update() )
         {
            context.CommitDataStores("wp_managelocationbranding",pr_default);
            GXt_char1 = AV32Trn_Location.gxTpr_Locationbrandtheme;
            GXt_char2 = AV32Trn_Location.gxTpr_Locationctatheme;
            new prc_updatelocationthemesetting(context ).execute( ref  AV31LocationId, ref  GXt_char1, ref  GXt_char2, ref  AV38LocationHasOwnBrand) ;
            AV32Trn_Location.gxTpr_Locationbrandtheme = GXt_char1;
            AV32Trn_Location.gxTpr_Locationctatheme = GXt_char2;
            AssignAttri("", false, "AV31LocationId", AV31LocationId.ToString());
            AssignAttri("", false, "AV38LocationHasOwnBrand", AV38LocationHasOwnBrand);
            AV30websession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Location license updated successfully", ""));
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            AV10ErrorMessages = AV32Trn_Location.GetMessages();
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S132 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32Trn_Location", AV32Trn_Location);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10ErrorMessages", AV10ErrorMessages);
      }

      protected void S112( )
      {
         /* 'INITIALIZEUCCOLORS' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV6DefaultBrandTheme.gxTpr_Accentcolorvalue)) )
         {
            Themeselector_Accentcolorvalue = AV6DefaultBrandTheme.gxTpr_Accentcolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "accentColorValue", Themeselector_Accentcolorvalue);
            Themeselector_Backgroundcolorvalue = AV6DefaultBrandTheme.gxTpr_Backgroundcolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "backgroundColorValue", Themeselector_Backgroundcolorvalue);
            Themeselector_Bordercolorvalue = AV6DefaultBrandTheme.gxTpr_Bordercolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "borderColorValue", Themeselector_Bordercolorvalue);
            Themeselector_Buttonbgcolorvalue = AV6DefaultBrandTheme.gxTpr_Buttonbgcolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "buttonBGColorValue", Themeselector_Buttonbgcolorvalue);
            Themeselector_Buttontextcolorvalue = AV6DefaultBrandTheme.gxTpr_Buttontextcolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "buttonTextColorValue", Themeselector_Buttontextcolorvalue);
            Themeselector_Cardbgcolorvalue = AV6DefaultBrandTheme.gxTpr_Cardbgcolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "cardBgColorValue", Themeselector_Cardbgcolorvalue);
            Themeselector_Cardtextcolorvalue = AV6DefaultBrandTheme.gxTpr_Cardtextcolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "cardTextColorValue", Themeselector_Cardtextcolorvalue);
            Themeselector_Primarycolorvalue = AV6DefaultBrandTheme.gxTpr_Primarycolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "primaryColorValue", Themeselector_Primarycolorvalue);
            Themeselector_Secondarycolorvalue = AV6DefaultBrandTheme.gxTpr_Secondarycolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "secondaryColorValue", Themeselector_Secondarycolorvalue);
            Themeselector_Textcolorvalue = AV6DefaultBrandTheme.gxTpr_Textcolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "textColorValue", Themeselector_Textcolorvalue);
            Calltoactionthemeselector_Ctacolor1 = AV7DefaultCtaTheme.gxTpr_Ctacolor1;
            ucCalltoactionthemeselector.SendProperty(context, "", false, Calltoactionthemeselector_Internalname, "ctaColor1", Calltoactionthemeselector_Ctacolor1);
            Calltoactionthemeselector_Ctacolor2 = AV7DefaultCtaTheme.gxTpr_Ctacolor2;
            ucCalltoactionthemeselector.SendProperty(context, "", false, Calltoactionthemeselector_Internalname, "ctaColor2", Calltoactionthemeselector_Ctacolor2);
            Calltoactionthemeselector_Ctacolor3 = AV7DefaultCtaTheme.gxTpr_Ctacolor3;
            ucCalltoactionthemeselector.SendProperty(context, "", false, Calltoactionthemeselector_Internalname, "ctaColor3", Calltoactionthemeselector_Ctacolor3);
            Calltoactionthemeselector_Ctacolor4 = AV7DefaultCtaTheme.gxTpr_Ctacolor4;
            ucCalltoactionthemeselector.SendProperty(context, "", false, Calltoactionthemeselector_Internalname, "ctaColor4", Calltoactionthemeselector_Ctacolor4);
            Calltoactionthemeselector_Ctacolor5 = AV7DefaultCtaTheme.gxTpr_Ctacolor5;
            ucCalltoactionthemeselector.SendProperty(context, "", false, Calltoactionthemeselector_Internalname, "ctaColor5", Calltoactionthemeselector_Ctacolor5);
            Calltoactionthemeselector_Ctacolor6 = AV7DefaultCtaTheme.gxTpr_Ctacolor6;
            ucCalltoactionthemeselector.SendProperty(context, "", false, Calltoactionthemeselector_Internalname, "ctaColor6", Calltoactionthemeselector_Ctacolor6);
         }
      }

      protected void S132( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV39GXV1 = 1;
         while ( AV39GXV1 <= AV10ErrorMessages.Count )
         {
            AV15Message = ((GeneXus.Utils.SdtMessages_Message)AV10ErrorMessages.Item(AV39GXV1));
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error",  AV15Message.gxTpr_Description,  "error",  "",  "true",  ""));
            AV39GXV1 = (int)(AV39GXV1+1);
         }
         AV10ErrorMessages.Clear();
      }

      protected void nextLoad( )
      {
      }

      protected void E13AW2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV24OrganisationId = (Guid)getParm(obj,0);
         AssignAttri("", false, "AV24OrganisationId", AV24OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV24OrganisationId, context));
         AV31LocationId = (Guid)getParm(obj,1);
         AssignAttri("", false, "AV31LocationId", AV31LocationId.ToString());
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
         PAAW2( ) ;
         WSAW2( ) ;
         WEAW2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025721312933", true, true);
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
         context.AddJavascriptSource("wp_managelocationbranding.js", "?2025721312934", false, true);
         context.AddJavascriptSource("UserControls/UC_ThemeSelectorRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UC_CtaThemeSelectorRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkavLocationhasmycare.Name = "vLOCATIONHASMYCARE";
         chkavLocationhasmycare.WebTags = "";
         chkavLocationhasmycare.Caption = context.GetMessage( "Location Has My Care", "");
         AssignProp("", false, chkavLocationhasmycare_Internalname, "TitleCaption", chkavLocationhasmycare.Caption, true);
         chkavLocationhasmycare.CheckedValue = "false";
         AV35LocationHasMyCare = StringUtil.StrToBool( StringUtil.BoolToStr( AV35LocationHasMyCare));
         AssignAttri("", false, "AV35LocationHasMyCare", AV35LocationHasMyCare);
         chkavLocationhasmyliving.Name = "vLOCATIONHASMYLIVING";
         chkavLocationhasmyliving.WebTags = "";
         chkavLocationhasmyliving.Caption = context.GetMessage( "Location Has My Living", "");
         AssignProp("", false, chkavLocationhasmyliving_Internalname, "TitleCaption", chkavLocationhasmyliving.Caption, true);
         chkavLocationhasmyliving.CheckedValue = "false";
         AV36LocationHasMyLiving = StringUtil.StrToBool( StringUtil.BoolToStr( AV36LocationHasMyLiving));
         AssignAttri("", false, "AV36LocationHasMyLiving", AV36LocationHasMyLiving);
         chkavLocationhasmyservices.Name = "vLOCATIONHASMYSERVICES";
         chkavLocationhasmyservices.WebTags = "";
         chkavLocationhasmyservices.Caption = context.GetMessage( "Location Has My Services", "");
         AssignProp("", false, chkavLocationhasmyservices_Internalname, "TitleCaption", chkavLocationhasmyservices.Caption, true);
         chkavLocationhasmyservices.CheckedValue = "false";
         AV37LocationHasMyServices = StringUtil.StrToBool( StringUtil.BoolToStr( AV37LocationHasMyServices));
         AssignAttri("", false, "AV37LocationHasMyServices", AV37LocationHasMyServices);
         chkavLocationhasownbrand.Name = "vLOCATIONHASOWNBRAND";
         chkavLocationhasownbrand.WebTags = "";
         chkavLocationhasownbrand.Caption = context.GetMessage( "Location Has Own Brand", "");
         AssignProp("", false, chkavLocationhasownbrand_Internalname, "TitleCaption", chkavLocationhasownbrand.Caption, true);
         chkavLocationhasownbrand.CheckedValue = "false";
         AV38LocationHasOwnBrand = StringUtil.StrToBool( StringUtil.BoolToStr( AV38LocationHasOwnBrand));
         AssignAttri("", false, "AV38LocationHasOwnBrand", AV38LocationHasOwnBrand);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         chkavLocationhasmycare_Internalname = "vLOCATIONHASMYCARE";
         chkavLocationhasmyliving_Internalname = "vLOCATIONHASMYLIVING";
         chkavLocationhasmyservices_Internalname = "vLOCATIONHASMYSERVICES";
         chkavLocationhasownbrand_Internalname = "vLOCATIONHASOWNBRAND";
         divAgreementfields_Internalname = "AGREEMENTFIELDS";
         lblThemelabel_Internalname = "THEMELABEL";
         Themeselector_Internalname = "THEMESELECTOR";
         divBrandtable_Internalname = "BRANDTABLE";
         lblCtatheme_Internalname = "CTATHEME";
         Calltoactionthemeselector_Internalname = "CALLTOACTIONTHEMESELECTOR";
         divCtatable_Internalname = "CTATABLE";
         divBrandthemetable_Internalname = "BRANDTHEMETABLE";
         divGroupattributes_Internalname = "GROUPATTRIBUTES";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
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
         chkavLocationhasownbrand.Caption = context.GetMessage( "Location Has Own Brand", "");
         chkavLocationhasmyservices.Caption = context.GetMessage( "Location Has My Services", "");
         chkavLocationhasmyliving.Caption = context.GetMessage( "Location Has My Living", "");
         chkavLocationhasmycare.Caption = context.GetMessage( "Location Has My Care", "");
         divCtatable_Visible = 1;
         divBrandtable_Visible = 1;
         chkavLocationhasownbrand.Enabled = 1;
         chkavLocationhasmyservices.Enabled = 1;
         chkavLocationhasmyliving.Enabled = 1;
         chkavLocationhasmycare.Enabled = 1;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Calltoactionthemeselector_Ctacolor6 = "#B7B7B7";
         Calltoactionthemeselector_Ctacolor5 = "#E9C4AA";
         Calltoactionthemeselector_Ctacolor4 = "#C4A082";
         Calltoactionthemeselector_Ctacolor3 = "#969674";
         Calltoactionthemeselector_Ctacolor2 = "#D4A76A";
         Calltoactionthemeselector_Ctacolor1 = "#2C405A";
         Themeselector_Textcolorvalue = "#B7B7B7";
         Themeselector_Secondarycolorvalue = "#E9C4AA";
         Themeselector_Primarycolorvalue = "#C4A082";
         Themeselector_Cardtextcolorvalue = "#B2B997";
         Themeselector_Cardbgcolorvalue = "#969674";
         Themeselector_Buttontextcolorvalue = "#D4A76A";
         Themeselector_Buttonbgcolorvalue = "#A48F79";
         Themeselector_Bordercolorvalue = "#666E61";
         Themeselector_Backgroundcolorvalue = "#2C405A";
         Themeselector_Accentcolorvalue = "#393736";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Organisation Provisioning", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV35LocationHasMyCare","fld":"vLOCATIONHASMYCARE"},{"av":"AV36LocationHasMyLiving","fld":"vLOCATIONHASMYLIVING"},{"av":"AV37LocationHasMyServices","fld":"vLOCATIONHASMYSERVICES"},{"av":"AV38LocationHasOwnBrand","fld":"vLOCATIONHASOWNBRAND"},{"av":"AV24OrganisationId","fld":"vORGANISATIONID","hsh":true}]}""");
         setEventMetadata("ENTER","""{"handler":"E12AW2","iparms":[{"av":"AV27SelectedBrandTheme","fld":"vSELECTEDBRANDTHEME"},{"av":"AV32Trn_Location","fld":"vTRN_LOCATION"},{"av":"AV28SelectedCtaTheme","fld":"vSELECTEDCTATHEME"},{"av":"AV35LocationHasMyCare","fld":"vLOCATIONHASMYCARE"},{"av":"AV36LocationHasMyLiving","fld":"vLOCATIONHASMYLIVING"},{"av":"AV37LocationHasMyServices","fld":"vLOCATIONHASMYSERVICES"},{"av":"AV38LocationHasOwnBrand","fld":"vLOCATIONHASOWNBRAND"},{"av":"AV31LocationId","fld":"vLOCATIONID"},{"av":"AV10ErrorMessages","fld":"vERRORMESSAGES"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV32Trn_Location","fld":"vTRN_LOCATION"},{"av":"AV38LocationHasOwnBrand","fld":"vLOCATIONHASOWNBRAND"},{"av":"AV31LocationId","fld":"vLOCATIONID"},{"av":"AV10ErrorMessages","fld":"vERRORMESSAGES"}]}""");
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
         wcpOAV24OrganisationId = Guid.Empty;
         wcpOAV31LocationId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV27SelectedBrandTheme = new SdtSDT_BrandThemeColors(context);
         AV28SelectedCtaTheme = new SdtSDT_CtaThemeColors(context);
         AV32Trn_Location = new SdtTrn_Location(context);
         AV10ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV35LocationHasMyCare = false;
         AV36LocationHasMyLiving = false;
         AV37LocationHasMyServices = false;
         AV38LocationHasOwnBrand = false;
         lblThemelabel_Jsonclick = "";
         ucThemeselector = new GXUserControl();
         lblCtatheme_Jsonclick = "";
         ucCalltoactionthemeselector = new GXUserControl();
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV33LocationBrandTheme = "";
         AV34LocationCtaTheme = "";
         AV6DefaultBrandTheme = new SdtSDT_BrandThemeColors(context);
         AV7DefaultCtaTheme = new SdtSDT_CtaThemeColors(context);
         GXt_char1 = "";
         GXt_char2 = "";
         AV30websession = context.GetSession();
         AV15Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wp_managelocationbranding__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_managelocationbranding__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_managelocationbranding__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int divBrandtable_Visible ;
      private int divCtatable_Visible ;
      private int AV39GXV1 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Themeselector_Accentcolorvalue ;
      private string Themeselector_Backgroundcolorvalue ;
      private string Themeselector_Bordercolorvalue ;
      private string Themeselector_Buttonbgcolorvalue ;
      private string Themeselector_Buttontextcolorvalue ;
      private string Themeselector_Cardbgcolorvalue ;
      private string Themeselector_Cardtextcolorvalue ;
      private string Themeselector_Primarycolorvalue ;
      private string Themeselector_Secondarycolorvalue ;
      private string Themeselector_Textcolorvalue ;
      private string Calltoactionthemeselector_Ctacolor1 ;
      private string Calltoactionthemeselector_Ctacolor2 ;
      private string Calltoactionthemeselector_Ctacolor3 ;
      private string Calltoactionthemeselector_Ctacolor4 ;
      private string Calltoactionthemeselector_Ctacolor5 ;
      private string Calltoactionthemeselector_Ctacolor6 ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTableattributes_Internalname ;
      private string grpUnnamedgroup1_Internalname ;
      private string divGroupattributes_Internalname ;
      private string divAgreementfields_Internalname ;
      private string chkavLocationhasmycare_Internalname ;
      private string TempTags ;
      private string chkavLocationhasmyliving_Internalname ;
      private string chkavLocationhasmyservices_Internalname ;
      private string chkavLocationhasownbrand_Internalname ;
      private string divBrandthemetable_Internalname ;
      private string divBrandtable_Internalname ;
      private string lblThemelabel_Internalname ;
      private string lblThemelabel_Jsonclick ;
      private string Themeselector_Internalname ;
      private string divCtatable_Internalname ;
      private string lblCtatheme_Internalname ;
      private string lblCtatheme_Jsonclick ;
      private string Calltoactionthemeselector_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string GXt_char1 ;
      private string GXt_char2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool AV35LocationHasMyCare ;
      private bool AV36LocationHasMyLiving ;
      private bool AV37LocationHasMyServices ;
      private bool AV38LocationHasOwnBrand ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV33LocationBrandTheme ;
      private string AV34LocationCtaTheme ;
      private Guid AV24OrganisationId ;
      private Guid AV31LocationId ;
      private Guid wcpOAV24OrganisationId ;
      private Guid wcpOAV31LocationId ;
      private GXUserControl ucThemeselector ;
      private GXUserControl ucCalltoactionthemeselector ;
      private IGxSession AV30websession ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavLocationhasmycare ;
      private GXCheckbox chkavLocationhasmyliving ;
      private GXCheckbox chkavLocationhasmyservices ;
      private GXCheckbox chkavLocationhasownbrand ;
      private SdtSDT_BrandThemeColors AV27SelectedBrandTheme ;
      private SdtSDT_CtaThemeColors AV28SelectedCtaTheme ;
      private SdtTrn_Location AV32Trn_Location ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV10ErrorMessages ;
      private SdtSDT_BrandThemeColors AV6DefaultBrandTheme ;
      private SdtSDT_CtaThemeColors AV7DefaultCtaTheme ;
      private IDataStoreProvider pr_default ;
      private GeneXus.Utils.SdtMessages_Message AV15Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_managelocationbranding__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_managelocationbranding__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wp_managelocationbranding__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
