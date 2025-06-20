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
   public class wp_manageorganisationprovisioning : GXDataArea
   {
      public wp_manageorganisationprovisioning( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wp_manageorganisationprovisioning( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_OrganisationId )
      {
         this.AV17OrganisationId = aP0_OrganisationId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavOrganisationhasmycare = new GXCheckbox();
         chkavOrganisationhasmyliving = new GXCheckbox();
         chkavOrganisationhasmyservices = new GXCheckbox();
         chkavOrganisationhasownbrand = new GXCheckbox();
         chkavOrganisationhasdynamicforms = new GXCheckbox();
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
            return "wp_manageorganisationprovisioning_Execute" ;
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
         PAA42( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTA42( ) ;
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
         context.AddJavascriptSource("UserControls/UC_FileUploadRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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
         GXEncryptionTmp = "wp_manageorganisationprovisioning.aspx"+UrlEncode(AV17OrganisationId.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_manageorganisationprovisioning.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, "vISNEWSETTING", AV24isNewSetting);
         GxWebStd.gx_hidden_field( context, "gxhash_vISNEWSETTING", GetSecureSignedToken( "", AV24isNewSetting, context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONSETTINGID", AV18OrganisationSettingId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONSETTINGID", GetSecureSignedToken( "", AV18OrganisationSettingId, context));
         GxWebStd.gx_hidden_field( context, "vIMAGEPLACEHOLDER", AV30ImagePlaceholder);
         GxWebStd.gx_hidden_field( context, "gxhash_vIMAGEPLACEHOLDER", GetSecureSignedToken( "", AV30ImagePlaceholder, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSELECTEDBRANDTHEME", AV20SelectedBrandTheme);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSELECTEDBRANDTHEME", AV20SelectedBrandTheme);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSELECTEDCTATHEME", AV23SelectedCtaTheme);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSELECTEDCTATHEME", AV23SelectedCtaTheme);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILEUPLOADEDDATA", AV29FileUploadedData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILEUPLOADEDDATA", AV29FileUploadedData);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISNEWSETTING", AV24isNewSetting);
         GxWebStd.gx_hidden_field( context, "gxhash_vISNEWSETTING", GetSecureSignedToken( "", AV24isNewSetting, context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV17OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "vORGANISATIONSETTINGID", AV18OrganisationSettingId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONSETTINGID", GetSecureSignedToken( "", AV18OrganisationSettingId, context));
         GxWebStd.gx_hidden_field( context, "vBASE64STRING", AV28base64String);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vERRORMESSAGES", AV9ErrorMessages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vERRORMESSAGES", AV9ErrorMessages);
         }
         GxWebStd.gx_hidden_field( context, "vIMAGEPLACEHOLDER", AV30ImagePlaceholder);
         GxWebStd.gx_hidden_field( context, "gxhash_vIMAGEPLACEHOLDER", GetSecureSignedToken( "", AV30ImagePlaceholder, context));
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
         GxWebStd.gx_hidden_field( context, "LOGOUPLOAD_Previewimagelink", StringUtil.RTrim( Logoupload_Previewimagelink));
         GxWebStd.gx_hidden_field( context, "COMFIRMDELETEMODAL_Title", StringUtil.RTrim( Comfirmdeletemodal_Title));
         GxWebStd.gx_hidden_field( context, "COMFIRMDELETEMODAL_Confirmationtext", StringUtil.RTrim( Comfirmdeletemodal_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "COMFIRMDELETEMODAL_Yesbuttoncaption", StringUtil.RTrim( Comfirmdeletemodal_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "COMFIRMDELETEMODAL_Nobuttoncaption", StringUtil.RTrim( Comfirmdeletemodal_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "COMFIRMDELETEMODAL_Bodytype", StringUtil.RTrim( Comfirmdeletemodal_Bodytype));
         GxWebStd.gx_hidden_field( context, "LOGOUPLOAD_Previewimagelink", StringUtil.RTrim( Logoupload_Previewimagelink));
         GxWebStd.gx_hidden_field( context, "LOGOUPLOAD_Previewimagelink", StringUtil.RTrim( Logoupload_Previewimagelink));
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
            WEA42( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTA42( ) ;
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
         GXEncryptionTmp = "wp_manageorganisationprovisioning.aspx"+UrlEncode(AV17OrganisationId.ToString());
         return formatLink("wp_manageorganisationprovisioning.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WP_ManageOrganisationProvisioning" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Organisation Provisioning", "") ;
      }

      protected void WBA40( )
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "License", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_ManageOrganisationProvisioning.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavOrganisationhasmycare_Internalname, context.GetMessage( "Organisation Has My Care", ""), "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOrganisationhasmycare_Internalname, StringUtil.BoolToStr( AV14OrganisationHasMyCare), "", context.GetMessage( "Organisation Has My Care", ""), 1, chkavOrganisationhasmycare.Enabled, "true", context.GetMessage( "My Care", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(23, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,23);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavOrganisationhasmyliving_Internalname, context.GetMessage( "Organisation Has My Living", ""), "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOrganisationhasmyliving_Internalname, StringUtil.BoolToStr( AV15OrganisationHasMyLiving), "", context.GetMessage( "Organisation Has My Living", ""), 1, chkavOrganisationhasmyliving.Enabled, "true", context.GetMessage( "My Living", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(27, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,27);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavOrganisationhasmyservices_Internalname, context.GetMessage( "Organisation Has My Services", ""), "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOrganisationhasmyservices_Internalname, StringUtil.BoolToStr( AV16OrganisationHasMyServices), "", context.GetMessage( "Organisation Has My Services", ""), 1, chkavOrganisationhasmyservices.Enabled, "true", context.GetMessage( "My Services", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(31, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,31);\"");
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
            GxWebStd.gx_label_element( context, chkavOrganisationhasownbrand_Internalname, context.GetMessage( "Organisation Has Own Brand", ""), "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOrganisationhasownbrand_Internalname, StringUtil.BoolToStr( AV32OrganisationHasOwnBrand), "", context.GetMessage( "Organisation Has Own Brand", ""), 1, chkavOrganisationhasownbrand.Enabled, "true", context.GetMessage( "Brand Theme", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(35, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,35);\"");
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
            GxWebStd.gx_label_ctrl( context, lblThemelabel_Internalname, context.GetMessage( "Your Brand Theme", ""), "", "", lblThemelabel_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_ManageOrganisationProvisioning.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucThemeselector.SetProperty("SelectedTheme", AV20SelectedBrandTheme);
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
            GxWebStd.gx_label_ctrl( context, lblCtatheme_Internalname, context.GetMessage( "Call To Action Theme", ""), "", "", lblCtatheme_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_ManageOrganisationProvisioning.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCalltoactionthemeselector.SetProperty("ResultTheme", AV23SelectedCtaTheme);
            ucCalltoactionthemeselector.Render(context, "uc_ctathemeselector", Calltoactionthemeselector_Internalname, "CALLTOACTIONTHEMESELECTORContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFieldavatartable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop10", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblAvatarlabel_Internalname, context.GetMessage( "Application Logo", ""), "", "", lblAvatarlabel_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_ManageOrganisationProvisioning.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucLogoupload.SetProperty("UploadedFile", AV29FileUploadedData);
            ucLogoupload.SetProperty("PreviewImageLink", Logoupload_Previewimagelink);
            ucLogoupload.Render(context, "uc_fileupload", Logoupload_Internalname, "LOGOUPLOADContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_ManageOrganisationProvisioning.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtncancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_ManageOrganisationProvisioning.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucComfirmdeletemodal.SetProperty("Title", Comfirmdeletemodal_Title);
            ucComfirmdeletemodal.SetProperty("ConfirmationText", Comfirmdeletemodal_Confirmationtext);
            ucComfirmdeletemodal.SetProperty("YesButtonCaption", Comfirmdeletemodal_Yesbuttoncaption);
            ucComfirmdeletemodal.SetProperty("NoButtonCaption", Comfirmdeletemodal_Nobuttoncaption);
            ucComfirmdeletemodal.SetProperty("BodyType", Comfirmdeletemodal_Bodytype);
            ucComfirmdeletemodal.Render(context, "dvelop.gxbootstrap.confirmpanel", Comfirmdeletemodal_Internalname, "COMFIRMDELETEMODALContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOrganisationhasdynamicforms_Internalname, StringUtil.BoolToStr( AV13OrganisationHasDynamicForms), "", "", chkavOrganisationhasdynamicforms.Visible, 1, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(76, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,76);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void STARTA42( )
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
         STRUPA40( ) ;
      }

      protected void WSA42( )
      {
         STARTA42( ) ;
         EVTA42( ) ;
      }

      protected void EVTA42( )
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
                           else if ( StringUtil.StrCmp(sEvt, "LOGOUPLOAD.ONUPLOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Logoupload.Onupload */
                              E11A42 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOGOUPLOAD.ONFAILEDUPLOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Logoupload.Onfailedupload */
                              E12A42 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOGOUPLOAD.ONCLICKDELETE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Logoupload.Onclickdelete */
                              E13A42 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E14A42 ();
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
                                    E15A42 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E16A42 ();
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

      protected void WEA42( )
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

      protected void PAA42( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_manageorganisationprovisioning.aspx")), "wp_manageorganisationprovisioning.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_manageorganisationprovisioning.aspx")))) ;
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
                     AV17OrganisationId = StringUtil.StrToGuid( gxfirstwebparm);
                     AssignAttri("", false, "AV17OrganisationId", AV17OrganisationId.ToString());
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
               GX_FocusControl = chkavOrganisationhasmycare_Internalname;
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
         AV14OrganisationHasMyCare = StringUtil.StrToBool( StringUtil.BoolToStr( AV14OrganisationHasMyCare));
         AssignAttri("", false, "AV14OrganisationHasMyCare", AV14OrganisationHasMyCare);
         AV15OrganisationHasMyLiving = StringUtil.StrToBool( StringUtil.BoolToStr( AV15OrganisationHasMyLiving));
         AssignAttri("", false, "AV15OrganisationHasMyLiving", AV15OrganisationHasMyLiving);
         AV16OrganisationHasMyServices = StringUtil.StrToBool( StringUtil.BoolToStr( AV16OrganisationHasMyServices));
         AssignAttri("", false, "AV16OrganisationHasMyServices", AV16OrganisationHasMyServices);
         AV32OrganisationHasOwnBrand = StringUtil.StrToBool( StringUtil.BoolToStr( AV32OrganisationHasOwnBrand));
         AssignAttri("", false, "AV32OrganisationHasOwnBrand", AV32OrganisationHasOwnBrand);
         AV13OrganisationHasDynamicForms = StringUtil.StrToBool( StringUtil.BoolToStr( AV13OrganisationHasDynamicForms));
         AssignAttri("", false, "AV13OrganisationHasDynamicForms", AV13OrganisationHasDynamicForms);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFA42( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFA42( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E16A42 ();
            WBA40( ) ;
         }
      }

      protected void send_integrity_lvl_hashesA42( )
      {
         GxWebStd.gx_boolean_hidden_field( context, "vISNEWSETTING", AV24isNewSetting);
         GxWebStd.gx_hidden_field( context, "gxhash_vISNEWSETTING", GetSecureSignedToken( "", AV24isNewSetting, context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONSETTINGID", AV18OrganisationSettingId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONSETTINGID", GetSecureSignedToken( "", AV18OrganisationSettingId, context));
         GxWebStd.gx_hidden_field( context, "vIMAGEPLACEHOLDER", AV30ImagePlaceholder);
         GxWebStd.gx_hidden_field( context, "gxhash_vIMAGEPLACEHOLDER", GetSecureSignedToken( "", AV30ImagePlaceholder, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUPA40( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E14A42 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vSELECTEDBRANDTHEME"), AV20SelectedBrandTheme);
            ajax_req_read_hidden_sdt(cgiGet( "vSELECTEDCTATHEME"), AV23SelectedCtaTheme);
            ajax_req_read_hidden_sdt(cgiGet( "vFILEUPLOADEDDATA"), AV29FileUploadedData);
            /* Read saved values. */
            AV30ImagePlaceholder = cgiGet( "vIMAGEPLACEHOLDER");
            AV28base64String = cgiGet( "vBASE64STRING");
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
            Logoupload_Previewimagelink = cgiGet( "LOGOUPLOAD_Previewimagelink");
            Comfirmdeletemodal_Title = cgiGet( "COMFIRMDELETEMODAL_Title");
            Comfirmdeletemodal_Confirmationtext = cgiGet( "COMFIRMDELETEMODAL_Confirmationtext");
            Comfirmdeletemodal_Yesbuttoncaption = cgiGet( "COMFIRMDELETEMODAL_Yesbuttoncaption");
            Comfirmdeletemodal_Nobuttoncaption = cgiGet( "COMFIRMDELETEMODAL_Nobuttoncaption");
            Comfirmdeletemodal_Bodytype = cgiGet( "COMFIRMDELETEMODAL_Bodytype");
            Logoupload_Previewimagelink = cgiGet( "LOGOUPLOAD_Previewimagelink");
            /* Read variables values. */
            AV14OrganisationHasMyCare = StringUtil.StrToBool( cgiGet( chkavOrganisationhasmycare_Internalname));
            AssignAttri("", false, "AV14OrganisationHasMyCare", AV14OrganisationHasMyCare);
            AV15OrganisationHasMyLiving = StringUtil.StrToBool( cgiGet( chkavOrganisationhasmyliving_Internalname));
            AssignAttri("", false, "AV15OrganisationHasMyLiving", AV15OrganisationHasMyLiving);
            AV16OrganisationHasMyServices = StringUtil.StrToBool( cgiGet( chkavOrganisationhasmyservices_Internalname));
            AssignAttri("", false, "AV16OrganisationHasMyServices", AV16OrganisationHasMyServices);
            AV32OrganisationHasOwnBrand = StringUtil.StrToBool( cgiGet( chkavOrganisationhasownbrand_Internalname));
            AssignAttri("", false, "AV32OrganisationHasOwnBrand", AV32OrganisationHasOwnBrand);
            AV13OrganisationHasDynamicForms = StringUtil.StrToBool( cgiGet( chkavOrganisationhasdynamicforms_Internalname));
            AssignAttri("", false, "AV13OrganisationHasDynamicForms", AV13OrganisationHasDynamicForms);
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
         E14A42 ();
         if (returnInSub) return;
      }

      protected void E14A42( )
      {
         /* Start Routine */
         returnInSub = false;
         AV30ImagePlaceholder = context.GetMessage( "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAALAAAACUCAMAAAAEVFNMAAAANlBMVEX///+hoaH8/PycnJzJycmzs7OlpaWXl5fX19e6urqrq6vT09Pn5+fCwsK2trb5+fnx8fHd3d33lFFhAAACAElEQVR4nO3Z7XKDIBCFYWAVFFHx/m+2qNEhUSaFtllmep6/CZN3yIr5EAIAAAAAAAAAAAAAAAAAAAAAAP4J3/3E/Png1lA5M3w+2EpdTFLz8V5lqStePBmO4PK3VfXMwUplrmUNVt7nXvKMwUq4Xut2yNtizh32mqQkGvPWMu5wG3ql1GbJWssX7LTcZW0xY/Dy6KUpay3/DucNMecM97Qlk7t9khuWu/OD95QwITfx+k6b261nvXHMjbXt/Rnh7Xrk3Xzi4L41J+4aYVy2I89dnsAdfP+4GGi/HtvLnbvKYOFIpk6QKoO9lYfLbbDGYDXSGSy1fx7jGoO7qFdS/3zZVRIcR3kjYy99dQQv43AcB2pu6Sn45U5YRfASvrwfn4BU89IrpfXx2gqCXXyAdZfeMMbRaVxB8Gy3RtoOMH/JXR+KEisIPmZgfefn6brB+xgflyV/8HJWTUpcB3h/SJ9DwR7s9ZllmuW+dxtjVUewepoBmwqWdC5gDk7MwA1XRXByBq5b/Bhj3uDoY9n74pE/+PG94rs69uDGvK+MracxZ7DL2t8wFFax7vCcPsRSxY1QTMHhC/zcF/wzM3DtcHhlN/X5Rs+3w+HdLSAEU/DUlLIMf3sJS2QKUerHuD81tD8w+fcv8OuK5jcaZAAAAAAAAAAAAAAAAAAAAAAAyPcFE4AcP6bJZ48AAAAASUVORK5CYII=", "");
         AssignAttri("", false, "AV30ImagePlaceholder", AV30ImagePlaceholder);
         GxWebStd.gx_hidden_field( context, "gxhash_vIMAGEPLACEHOLDER", GetSecureSignedToken( "", AV30ImagePlaceholder, context));
         AV33GXLvl5 = 0;
         /* Using cursor H00A42 */
         pr_default.execute(0, new Object[] {AV17OrganisationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A11OrganisationId = H00A42_A11OrganisationId[0];
            A100OrganisationSettingid = H00A42_A100OrganisationSettingid[0];
            A513OrganisationHasDynamicForms = H00A42_A513OrganisationHasDynamicForms[0];
            A510OrganisationHasMyCare = H00A42_A510OrganisationHasMyCare[0];
            A511OrganisationHasMyLiving = H00A42_A511OrganisationHasMyLiving[0];
            A512OrganisationHasMyServices = H00A42_A512OrganisationHasMyServices[0];
            A514OrganisationBrandTheme = H00A42_A514OrganisationBrandTheme[0];
            A537OrganisationHasOwnBrand = H00A42_A537OrganisationHasOwnBrand[0];
            A515OrganisationCtaTheme = H00A42_A515OrganisationCtaTheme[0];
            AV33GXLvl5 = 1;
            AV18OrganisationSettingId = A100OrganisationSettingid;
            AssignAttri("", false, "AV18OrganisationSettingId", AV18OrganisationSettingId.ToString());
            GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONSETTINGID", GetSecureSignedToken( "", AV18OrganisationSettingId, context));
            AV13OrganisationHasDynamicForms = A513OrganisationHasDynamicForms;
            AssignAttri("", false, "AV13OrganisationHasDynamicForms", AV13OrganisationHasDynamicForms);
            AV14OrganisationHasMyCare = A510OrganisationHasMyCare;
            AssignAttri("", false, "AV14OrganisationHasMyCare", AV14OrganisationHasMyCare);
            AV15OrganisationHasMyLiving = A511OrganisationHasMyLiving;
            AssignAttri("", false, "AV15OrganisationHasMyLiving", AV15OrganisationHasMyLiving);
            AV16OrganisationHasMyServices = A512OrganisationHasMyServices;
            AssignAttri("", false, "AV16OrganisationHasMyServices", AV16OrganisationHasMyServices);
            AV11OrganisationBrandTheme = A514OrganisationBrandTheme;
            AV32OrganisationHasOwnBrand = A537OrganisationHasOwnBrand;
            AssignAttri("", false, "AV32OrganisationHasOwnBrand", AV32OrganisationHasOwnBrand);
            AV12OrganisationCtaTheme = A515OrganisationCtaTheme;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV33GXLvl5 == 0 )
         {
            AV24isNewSetting = true;
            AssignAttri("", false, "AV24isNewSetting", AV24isNewSetting);
            GxWebStd.gx_hidden_field( context, "gxhash_vISNEWSETTING", GetSecureSignedToken( "", AV24isNewSetting, context));
         }
         AV27Trn_Organisation.Load(AV17OrganisationId);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27Trn_Organisation.gxTpr_Organisationlogo)) )
         {
            Logoupload_Previewimagelink = AV30ImagePlaceholder;
            ucLogoupload.SendProperty(context, "", false, Logoupload_Internalname, "PreviewImageLink", Logoupload_Previewimagelink);
         }
         else
         {
            Logoupload_Previewimagelink = AV27Trn_Organisation.gxTpr_Organisationlogo_gxi;
            ucLogoupload.SendProperty(context, "", false, Logoupload_Internalname, "PreviewImageLink", Logoupload_Previewimagelink);
         }
         if ( AV5DefaultBrandTheme.FromJSonString(AV11OrganisationBrandTheme, null) )
         {
            Themeselector_Accentcolorvalue = AV5DefaultBrandTheme.gxTpr_Accentcolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "accentColorValue", Themeselector_Accentcolorvalue);
            Themeselector_Backgroundcolorvalue = AV5DefaultBrandTheme.gxTpr_Backgroundcolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "backgroundColorValue", Themeselector_Backgroundcolorvalue);
            Themeselector_Bordercolorvalue = AV5DefaultBrandTheme.gxTpr_Bordercolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "borderColorValue", Themeselector_Bordercolorvalue);
            Themeselector_Buttonbgcolorvalue = AV5DefaultBrandTheme.gxTpr_Buttonbgcolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "buttonBGColorValue", Themeselector_Buttonbgcolorvalue);
            Themeselector_Buttontextcolorvalue = AV5DefaultBrandTheme.gxTpr_Buttontextcolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "buttonTextColorValue", Themeselector_Buttontextcolorvalue);
            Themeselector_Cardbgcolorvalue = AV5DefaultBrandTheme.gxTpr_Cardbgcolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "cardBgColorValue", Themeselector_Cardbgcolorvalue);
            Themeselector_Cardtextcolorvalue = AV5DefaultBrandTheme.gxTpr_Cardtextcolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "cardTextColorValue", Themeselector_Cardtextcolorvalue);
            Themeselector_Primarycolorvalue = AV5DefaultBrandTheme.gxTpr_Primarycolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "primaryColorValue", Themeselector_Primarycolorvalue);
            Themeselector_Secondarycolorvalue = AV5DefaultBrandTheme.gxTpr_Secondarycolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "secondaryColorValue", Themeselector_Secondarycolorvalue);
            Themeselector_Textcolorvalue = AV5DefaultBrandTheme.gxTpr_Textcolorvalue;
            ucThemeselector.SendProperty(context, "", false, Themeselector_Internalname, "textColorValue", Themeselector_Textcolorvalue);
         }
         if ( AV6DefaultCtaTheme.FromJSonString(AV12OrganisationCtaTheme, null) )
         {
            Calltoactionthemeselector_Ctacolor1 = AV6DefaultCtaTheme.gxTpr_Ctacolor1;
            ucCalltoactionthemeselector.SendProperty(context, "", false, Calltoactionthemeselector_Internalname, "ctaColor1", Calltoactionthemeselector_Ctacolor1);
            Calltoactionthemeselector_Ctacolor2 = AV6DefaultCtaTheme.gxTpr_Ctacolor2;
            ucCalltoactionthemeselector.SendProperty(context, "", false, Calltoactionthemeselector_Internalname, "ctaColor2", Calltoactionthemeselector_Ctacolor2);
            Calltoactionthemeselector_Ctacolor3 = AV6DefaultCtaTheme.gxTpr_Ctacolor3;
            ucCalltoactionthemeselector.SendProperty(context, "", false, Calltoactionthemeselector_Internalname, "ctaColor3", Calltoactionthemeselector_Ctacolor3);
            Calltoactionthemeselector_Ctacolor4 = AV6DefaultCtaTheme.gxTpr_Ctacolor4;
            ucCalltoactionthemeselector.SendProperty(context, "", false, Calltoactionthemeselector_Internalname, "ctaColor4", Calltoactionthemeselector_Ctacolor4);
            Calltoactionthemeselector_Ctacolor5 = AV6DefaultCtaTheme.gxTpr_Ctacolor5;
            ucCalltoactionthemeselector.SendProperty(context, "", false, Calltoactionthemeselector_Internalname, "ctaColor5", Calltoactionthemeselector_Ctacolor5);
            Calltoactionthemeselector_Ctacolor6 = AV6DefaultCtaTheme.gxTpr_Ctacolor6;
            ucCalltoactionthemeselector.SendProperty(context, "", false, Calltoactionthemeselector_Internalname, "ctaColor6", Calltoactionthemeselector_Ctacolor6);
         }
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         chkavOrganisationhasdynamicforms.Visible = 0;
         AssignProp("", false, chkavOrganisationhasdynamicforms_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavOrganisationhasdynamicforms.Visible), 5, 0), true);
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         divBrandtable_Visible = (((AV32OrganisationHasOwnBrand)) ? 1 : 0);
         AssignProp("", false, divBrandtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divBrandtable_Visible), 5, 0), true);
         divCtatable_Visible = (((AV32OrganisationHasOwnBrand)) ? 1 : 0);
         AssignProp("", false, divCtatable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCtatable_Visible), 5, 0), true);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E15A42 ();
         if (returnInSub) return;
      }

      protected void E15A42( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( AV24isNewSetting )
         {
            AV21Trn_OrganisationSetting = new SdtTrn_OrganisationSetting(context);
            AV21Trn_OrganisationSetting.gxTpr_Organisationsettingid = Guid.NewGuid( );
            AV21Trn_OrganisationSetting.gxTpr_Organisationid = AV17OrganisationId;
            AV21Trn_OrganisationSetting.gxTpr_Organisationhasmycare = AV14OrganisationHasMyCare;
            AV21Trn_OrganisationSetting.gxTpr_Organisationhasmyliving = AV15OrganisationHasMyLiving;
            AV21Trn_OrganisationSetting.gxTpr_Organisationhasmyservices = AV16OrganisationHasMyServices;
            AV21Trn_OrganisationSetting.gxTpr_Organisationhasdynamicforms = AV13OrganisationHasDynamicForms;
            AV21Trn_OrganisationSetting.gxTpr_Organisationhasownbrand = AV32OrganisationHasOwnBrand;
            AV21Trn_OrganisationSetting.gxTpr_Organisationbrandtheme = AV20SelectedBrandTheme.ToJSonString(false, true);
            AV21Trn_OrganisationSetting.gxTpr_Organisationctatheme = AV23SelectedCtaTheme.ToJSonString(false, true);
            AV21Trn_OrganisationSetting.Insert();
         }
         else
         {
            AV21Trn_OrganisationSetting.Load(AV18OrganisationSettingId, AV17OrganisationId);
            if ( AV21Trn_OrganisationSetting.Success() )
            {
               AV21Trn_OrganisationSetting.gxTpr_Organisationhasmycare = AV14OrganisationHasMyCare;
               AV21Trn_OrganisationSetting.gxTpr_Organisationhasmyliving = AV15OrganisationHasMyLiving;
               AV21Trn_OrganisationSetting.gxTpr_Organisationhasmyservices = AV16OrganisationHasMyServices;
               AV21Trn_OrganisationSetting.gxTpr_Organisationhasdynamicforms = AV13OrganisationHasDynamicForms;
               AV21Trn_OrganisationSetting.gxTpr_Organisationhasownbrand = AV32OrganisationHasOwnBrand;
               if ( AV32OrganisationHasOwnBrand )
               {
                  AV27Trn_Organisation.Load(AV17OrganisationId);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28base64String)) )
                  {
                     AV31OrganisationBlob=context.FileFromBase64( AV28base64String) ;
                     AV27Trn_Organisation.gxTpr_Organisationlogo = AV31OrganisationBlob;
                     AV27Trn_Organisation.gxTpr_Organisationlogo_gxi = GXDbFile.GetUriFromFile( "", "", AV31OrganisationBlob);
                  }
                  else
                  {
                     AV27Trn_Organisation.gxTpr_Organisationlogo = "";
                     AV27Trn_Organisation.gxTpr_Organisationlogo_gxi = "";
                  }
                  AV27Trn_Organisation.Save();
               }
               AV21Trn_OrganisationSetting.gxTpr_Organisationbrandtheme = AV20SelectedBrandTheme.ToJSonString(false, true);
               AV21Trn_OrganisationSetting.gxTpr_Organisationctatheme = AV23SelectedCtaTheme.ToJSonString(false, true);
               AV21Trn_OrganisationSetting.Save();
            }
         }
         if ( AV21Trn_OrganisationSetting.Success() )
         {
            context.CommitDataStores("wp_manageorganisationprovisioning",pr_default);
            GXt_char1 = AV20SelectedBrandTheme.ToJSonString(false, true);
            GXt_char2 = AV23SelectedCtaTheme.ToJSonString(false, true);
            new prc_updateorganisationthemesetting(context ).execute( ref  AV17OrganisationId, ref  GXt_char1, ref  GXt_char2, ref  AV32OrganisationHasOwnBrand) ;
            AssignAttri("", false, "AV17OrganisationId", AV17OrganisationId.ToString());
            AssignAttri("", false, "AV32OrganisationHasOwnBrand", AV32OrganisationHasOwnBrand);
            AV22websession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Provisions updated successfully", ""));
            CallWebObject(formatLink("trn_organisationww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            AV9ErrorMessages = AV21Trn_OrganisationSetting.GetMessages();
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23SelectedCtaTheme", AV23SelectedCtaTheme);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20SelectedBrandTheme", AV20SelectedBrandTheme);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9ErrorMessages", AV9ErrorMessages);
      }

      protected void E11A42( )
      {
         /* Logoupload_Onupload Routine */
         returnInSub = false;
         AV26OrganisationLogo = "";
         AV34Organisationlogo_GXI = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29FileUploadedData.gxTpr_Base64image)) )
         {
            AV28base64String = GxRegex.Split(AV29FileUploadedData.gxTpr_Base64image,",").GetString(2);
            AssignAttri("", false, "AV28base64String", AV28base64String);
         }
         /*  Sending Event outputs  */
      }

      protected void E12A42( )
      {
         /* Logoupload_Onfailedupload Routine */
         returnInSub = false;
         GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "Maximum file size allowed is 2MB.", ""),  "error",  "",  "true",  ""));
      }

      protected void E13A42( )
      {
         /* Logoupload_Onclickdelete Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Logoupload_Previewimagelink, AV30ImagePlaceholder) == 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( AV29FileUploadedData.gxTpr_Base64image)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "No logo to delete", ""),  "info",  "",  "true",  ""));
         }
         else
         {
            this.executeUsercontrolMethod("", false, "COMFIRMDELETEMODALContainer", "Confirm", "", new Object[] {});
         }
      }

      protected void S122( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV35GXV1 = 1;
         while ( AV35GXV1 <= AV9ErrorMessages.Count )
         {
            AV25Message = ((GeneXus.Utils.SdtMessages_Message)AV9ErrorMessages.Item(AV35GXV1));
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error",  AV25Message.gxTpr_Description,  "error",  "",  "true",  ""));
            AV35GXV1 = (int)(AV35GXV1+1);
         }
         AV9ErrorMessages.Clear();
      }

      protected void nextLoad( )
      {
      }

      protected void E16A42( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV17OrganisationId = (Guid)getParm(obj,0);
         AssignAttri("", false, "AV17OrganisationId", AV17OrganisationId.ToString());
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
         PAA42( ) ;
         WSA42( ) ;
         WEA42( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256201251779", true, true);
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
         context.AddJavascriptSource("wp_manageorganisationprovisioning.js", "?20256201251779", false, true);
         context.AddJavascriptSource("UserControls/UC_ThemeSelectorRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UC_CtaThemeSelectorRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UC_FileUploadRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkavOrganisationhasmycare.Name = "vORGANISATIONHASMYCARE";
         chkavOrganisationhasmycare.WebTags = "";
         chkavOrganisationhasmycare.Caption = context.GetMessage( "Organisation Has My Care", "");
         AssignProp("", false, chkavOrganisationhasmycare_Internalname, "TitleCaption", chkavOrganisationhasmycare.Caption, true);
         chkavOrganisationhasmycare.CheckedValue = "false";
         AV14OrganisationHasMyCare = StringUtil.StrToBool( StringUtil.BoolToStr( AV14OrganisationHasMyCare));
         AssignAttri("", false, "AV14OrganisationHasMyCare", AV14OrganisationHasMyCare);
         chkavOrganisationhasmyliving.Name = "vORGANISATIONHASMYLIVING";
         chkavOrganisationhasmyliving.WebTags = "";
         chkavOrganisationhasmyliving.Caption = context.GetMessage( "Organisation Has My Living", "");
         AssignProp("", false, chkavOrganisationhasmyliving_Internalname, "TitleCaption", chkavOrganisationhasmyliving.Caption, true);
         chkavOrganisationhasmyliving.CheckedValue = "false";
         AV15OrganisationHasMyLiving = StringUtil.StrToBool( StringUtil.BoolToStr( AV15OrganisationHasMyLiving));
         AssignAttri("", false, "AV15OrganisationHasMyLiving", AV15OrganisationHasMyLiving);
         chkavOrganisationhasmyservices.Name = "vORGANISATIONHASMYSERVICES";
         chkavOrganisationhasmyservices.WebTags = "";
         chkavOrganisationhasmyservices.Caption = context.GetMessage( "Organisation Has My Services", "");
         AssignProp("", false, chkavOrganisationhasmyservices_Internalname, "TitleCaption", chkavOrganisationhasmyservices.Caption, true);
         chkavOrganisationhasmyservices.CheckedValue = "false";
         AV16OrganisationHasMyServices = StringUtil.StrToBool( StringUtil.BoolToStr( AV16OrganisationHasMyServices));
         AssignAttri("", false, "AV16OrganisationHasMyServices", AV16OrganisationHasMyServices);
         chkavOrganisationhasownbrand.Name = "vORGANISATIONHASOWNBRAND";
         chkavOrganisationhasownbrand.WebTags = "";
         chkavOrganisationhasownbrand.Caption = context.GetMessage( "Organisation Has Own Brand", "");
         AssignProp("", false, chkavOrganisationhasownbrand_Internalname, "TitleCaption", chkavOrganisationhasownbrand.Caption, true);
         chkavOrganisationhasownbrand.CheckedValue = "false";
         AV32OrganisationHasOwnBrand = StringUtil.StrToBool( StringUtil.BoolToStr( AV32OrganisationHasOwnBrand));
         AssignAttri("", false, "AV32OrganisationHasOwnBrand", AV32OrganisationHasOwnBrand);
         chkavOrganisationhasdynamicforms.Name = "vORGANISATIONHASDYNAMICFORMS";
         chkavOrganisationhasdynamicforms.WebTags = "";
         chkavOrganisationhasdynamicforms.Caption = "";
         AssignProp("", false, chkavOrganisationhasdynamicforms_Internalname, "TitleCaption", chkavOrganisationhasdynamicforms.Caption, true);
         chkavOrganisationhasdynamicforms.CheckedValue = "false";
         AV13OrganisationHasDynamicForms = StringUtil.StrToBool( StringUtil.BoolToStr( AV13OrganisationHasDynamicForms));
         AssignAttri("", false, "AV13OrganisationHasDynamicForms", AV13OrganisationHasDynamicForms);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         chkavOrganisationhasmycare_Internalname = "vORGANISATIONHASMYCARE";
         chkavOrganisationhasmyliving_Internalname = "vORGANISATIONHASMYLIVING";
         chkavOrganisationhasmyservices_Internalname = "vORGANISATIONHASMYSERVICES";
         chkavOrganisationhasownbrand_Internalname = "vORGANISATIONHASOWNBRAND";
         divAgreementfields_Internalname = "AGREEMENTFIELDS";
         lblThemelabel_Internalname = "THEMELABEL";
         Themeselector_Internalname = "THEMESELECTOR";
         divBrandtable_Internalname = "BRANDTABLE";
         lblCtatheme_Internalname = "CTATHEME";
         Calltoactionthemeselector_Internalname = "CALLTOACTIONTHEMESELECTOR";
         lblAvatarlabel_Internalname = "AVATARLABEL";
         Logoupload_Internalname = "LOGOUPLOAD";
         divFieldavatartable_Internalname = "FIELDAVATARTABLE";
         divCtatable_Internalname = "CTATABLE";
         divBrandthemetable_Internalname = "BRANDTHEMETABLE";
         divGroupattributes_Internalname = "GROUPATTRIBUTES";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         Comfirmdeletemodal_Internalname = "COMFIRMDELETEMODAL";
         divTablemain_Internalname = "TABLEMAIN";
         chkavOrganisationhasdynamicforms_Internalname = "vORGANISATIONHASDYNAMICFORMS";
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
         chkavOrganisationhasdynamicforms.Caption = "";
         chkavOrganisationhasownbrand.Caption = context.GetMessage( "Organisation Has Own Brand", "");
         chkavOrganisationhasmyservices.Caption = context.GetMessage( "Organisation Has My Services", "");
         chkavOrganisationhasmyliving.Caption = context.GetMessage( "Organisation Has My Living", "");
         chkavOrganisationhasmycare.Caption = context.GetMessage( "Organisation Has My Care", "");
         chkavOrganisationhasdynamicforms.Visible = 1;
         divCtatable_Visible = 1;
         divBrandtable_Visible = 1;
         chkavOrganisationhasownbrand.Enabled = 1;
         chkavOrganisationhasmyservices.Enabled = 1;
         chkavOrganisationhasmyliving.Enabled = 1;
         chkavOrganisationhasmycare.Enabled = 1;
         divLayoutmaintable_Class = "Table TableTransactionTemplate";
         Comfirmdeletemodal_Bodytype = "No";
         Comfirmdeletemodal_Nobuttoncaption = "Cancel";
         Comfirmdeletemodal_Yesbuttoncaption = "Yes";
         Comfirmdeletemodal_Confirmationtext = "Are you sure you want to delete the current logo?";
         Comfirmdeletemodal_Title = context.GetMessage( "Comfirm Delete", "");
         Logoupload_Previewimagelink = "&ImagePalceholder";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV14OrganisationHasMyCare","fld":"vORGANISATIONHASMYCARE"},{"av":"AV15OrganisationHasMyLiving","fld":"vORGANISATIONHASMYLIVING"},{"av":"AV16OrganisationHasMyServices","fld":"vORGANISATIONHASMYSERVICES"},{"av":"AV32OrganisationHasOwnBrand","fld":"vORGANISATIONHASOWNBRAND"},{"av":"AV13OrganisationHasDynamicForms","fld":"vORGANISATIONHASDYNAMICFORMS"},{"av":"AV24isNewSetting","fld":"vISNEWSETTING","hsh":true},{"av":"AV18OrganisationSettingId","fld":"vORGANISATIONSETTINGID","hsh":true},{"av":"AV30ImagePlaceholder","fld":"vIMAGEPLACEHOLDER","hsh":true}]}""");
         setEventMetadata("ENTER","""{"handler":"E15A42","iparms":[{"av":"AV24isNewSetting","fld":"vISNEWSETTING","hsh":true},{"av":"AV17OrganisationId","fld":"vORGANISATIONID"},{"av":"AV14OrganisationHasMyCare","fld":"vORGANISATIONHASMYCARE"},{"av":"AV15OrganisationHasMyLiving","fld":"vORGANISATIONHASMYLIVING"},{"av":"AV16OrganisationHasMyServices","fld":"vORGANISATIONHASMYSERVICES"},{"av":"AV13OrganisationHasDynamicForms","fld":"vORGANISATIONHASDYNAMICFORMS"},{"av":"AV32OrganisationHasOwnBrand","fld":"vORGANISATIONHASOWNBRAND"},{"av":"AV20SelectedBrandTheme","fld":"vSELECTEDBRANDTHEME"},{"av":"AV23SelectedCtaTheme","fld":"vSELECTEDCTATHEME"},{"av":"AV18OrganisationSettingId","fld":"vORGANISATIONSETTINGID","hsh":true},{"av":"AV28base64String","fld":"vBASE64STRING"},{"av":"AV9ErrorMessages","fld":"vERRORMESSAGES"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV32OrganisationHasOwnBrand","fld":"vORGANISATIONHASOWNBRAND"},{"av":"AV23SelectedCtaTheme","fld":"vSELECTEDCTATHEME"},{"av":"AV20SelectedBrandTheme","fld":"vSELECTEDBRANDTHEME"},{"av":"AV17OrganisationId","fld":"vORGANISATIONID"},{"av":"AV9ErrorMessages","fld":"vERRORMESSAGES"}]}""");
         setEventMetadata("LOGOUPLOAD.ONUPLOAD","""{"handler":"E11A42","iparms":[{"av":"AV29FileUploadedData","fld":"vFILEUPLOADEDDATA"}]""");
         setEventMetadata("LOGOUPLOAD.ONUPLOAD",""","oparms":[{"av":"AV28base64String","fld":"vBASE64STRING"}]}""");
         setEventMetadata("LOGOUPLOAD.ONFAILEDUPLOAD","""{"handler":"E12A42","iparms":[]}""");
         setEventMetadata("LOGOUPLOAD.ONCLICKDELETE","""{"handler":"E13A42","iparms":[{"av":"Logoupload_Previewimagelink","ctrl":"LOGOUPLOAD","prop":"PreviewImageLink"},{"av":"AV30ImagePlaceholder","fld":"vIMAGEPLACEHOLDER","hsh":true},{"av":"AV29FileUploadedData","fld":"vFILEUPLOADEDDATA"}]}""");
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
         wcpOAV17OrganisationId = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV18OrganisationSettingId = Guid.Empty;
         AV30ImagePlaceholder = "";
         AV20SelectedBrandTheme = new SdtSDT_BrandThemeColors(context);
         AV23SelectedCtaTheme = new SdtSDT_CtaThemeColors(context);
         AV29FileUploadedData = new SdtSDT_AvatarUpload(context);
         AV28base64String = "";
         AV9ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         lblThemelabel_Jsonclick = "";
         ucThemeselector = new GXUserControl();
         lblCtatheme_Jsonclick = "";
         ucCalltoactionthemeselector = new GXUserControl();
         lblAvatarlabel_Jsonclick = "";
         ucLogoupload = new GXUserControl();
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         ucComfirmdeletemodal = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H00A42_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H00A42_A100OrganisationSettingid = new Guid[] {Guid.Empty} ;
         H00A42_A513OrganisationHasDynamicForms = new bool[] {false} ;
         H00A42_A510OrganisationHasMyCare = new bool[] {false} ;
         H00A42_A511OrganisationHasMyLiving = new bool[] {false} ;
         H00A42_A512OrganisationHasMyServices = new bool[] {false} ;
         H00A42_A514OrganisationBrandTheme = new string[] {""} ;
         H00A42_A537OrganisationHasOwnBrand = new bool[] {false} ;
         H00A42_A515OrganisationCtaTheme = new string[] {""} ;
         A11OrganisationId = Guid.Empty;
         A100OrganisationSettingid = Guid.Empty;
         A514OrganisationBrandTheme = "";
         A515OrganisationCtaTheme = "";
         AV11OrganisationBrandTheme = "";
         AV12OrganisationCtaTheme = "";
         AV27Trn_Organisation = new SdtTrn_Organisation(context);
         AV5DefaultBrandTheme = new SdtSDT_BrandThemeColors(context);
         AV6DefaultCtaTheme = new SdtSDT_CtaThemeColors(context);
         AV21Trn_OrganisationSetting = new SdtTrn_OrganisationSetting(context);
         AV31OrganisationBlob = "";
         GXt_char1 = "";
         GXt_char2 = "";
         AV22websession = context.GetSession();
         AV26OrganisationLogo = "";
         AV34Organisationlogo_GXI = "";
         AV25Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wp_manageorganisationprovisioning__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_manageorganisationprovisioning__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_manageorganisationprovisioning__default(),
            new Object[][] {
                new Object[] {
               H00A42_A11OrganisationId, H00A42_A100OrganisationSettingid, H00A42_A513OrganisationHasDynamicForms, H00A42_A510OrganisationHasMyCare, H00A42_A511OrganisationHasMyLiving, H00A42_A512OrganisationHasMyServices, H00A42_A514OrganisationBrandTheme, H00A42_A537OrganisationHasOwnBrand, H00A42_A515OrganisationCtaTheme
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
      private short AV33GXLvl5 ;
      private short nGXWrapped ;
      private int divBrandtable_Visible ;
      private int divCtatable_Visible ;
      private int AV35GXV1 ;
      private int idxLst ;
      private string Logoupload_Previewimagelink ;
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
      private string Comfirmdeletemodal_Title ;
      private string Comfirmdeletemodal_Confirmationtext ;
      private string Comfirmdeletemodal_Yesbuttoncaption ;
      private string Comfirmdeletemodal_Nobuttoncaption ;
      private string Comfirmdeletemodal_Bodytype ;
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
      private string chkavOrganisationhasmycare_Internalname ;
      private string TempTags ;
      private string chkavOrganisationhasmyliving_Internalname ;
      private string chkavOrganisationhasmyservices_Internalname ;
      private string chkavOrganisationhasownbrand_Internalname ;
      private string divBrandthemetable_Internalname ;
      private string divBrandtable_Internalname ;
      private string lblThemelabel_Internalname ;
      private string lblThemelabel_Jsonclick ;
      private string Themeselector_Internalname ;
      private string divCtatable_Internalname ;
      private string lblCtatheme_Internalname ;
      private string lblCtatheme_Jsonclick ;
      private string Calltoactionthemeselector_Internalname ;
      private string divFieldavatartable_Internalname ;
      private string lblAvatarlabel_Internalname ;
      private string lblAvatarlabel_Jsonclick ;
      private string Logoupload_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string Comfirmdeletemodal_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string chkavOrganisationhasdynamicforms_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string GXt_char1 ;
      private string GXt_char2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV24isNewSetting ;
      private bool wbLoad ;
      private bool AV14OrganisationHasMyCare ;
      private bool AV15OrganisationHasMyLiving ;
      private bool AV16OrganisationHasMyServices ;
      private bool AV32OrganisationHasOwnBrand ;
      private bool AV13OrganisationHasDynamicForms ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool A513OrganisationHasDynamicForms ;
      private bool A510OrganisationHasMyCare ;
      private bool A511OrganisationHasMyLiving ;
      private bool A512OrganisationHasMyServices ;
      private bool A537OrganisationHasOwnBrand ;
      private string AV30ImagePlaceholder ;
      private string AV28base64String ;
      private string A514OrganisationBrandTheme ;
      private string A515OrganisationCtaTheme ;
      private string AV11OrganisationBrandTheme ;
      private string AV12OrganisationCtaTheme ;
      private string AV34Organisationlogo_GXI ;
      private string AV26OrganisationLogo ;
      private Guid AV17OrganisationId ;
      private Guid wcpOAV17OrganisationId ;
      private Guid AV18OrganisationSettingId ;
      private Guid A11OrganisationId ;
      private Guid A100OrganisationSettingid ;
      private string AV31OrganisationBlob ;
      private GXUserControl ucThemeselector ;
      private GXUserControl ucCalltoactionthemeselector ;
      private GXUserControl ucLogoupload ;
      private GXUserControl ucComfirmdeletemodal ;
      private IGxSession AV22websession ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavOrganisationhasmycare ;
      private GXCheckbox chkavOrganisationhasmyliving ;
      private GXCheckbox chkavOrganisationhasmyservices ;
      private GXCheckbox chkavOrganisationhasownbrand ;
      private GXCheckbox chkavOrganisationhasdynamicforms ;
      private SdtSDT_BrandThemeColors AV20SelectedBrandTheme ;
      private SdtSDT_CtaThemeColors AV23SelectedCtaTheme ;
      private SdtSDT_AvatarUpload AV29FileUploadedData ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV9ErrorMessages ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00A42_A11OrganisationId ;
      private Guid[] H00A42_A100OrganisationSettingid ;
      private bool[] H00A42_A513OrganisationHasDynamicForms ;
      private bool[] H00A42_A510OrganisationHasMyCare ;
      private bool[] H00A42_A511OrganisationHasMyLiving ;
      private bool[] H00A42_A512OrganisationHasMyServices ;
      private string[] H00A42_A514OrganisationBrandTheme ;
      private bool[] H00A42_A537OrganisationHasOwnBrand ;
      private string[] H00A42_A515OrganisationCtaTheme ;
      private SdtTrn_Organisation AV27Trn_Organisation ;
      private SdtSDT_BrandThemeColors AV5DefaultBrandTheme ;
      private SdtSDT_CtaThemeColors AV6DefaultCtaTheme ;
      private SdtTrn_OrganisationSetting AV21Trn_OrganisationSetting ;
      private GeneXus.Utils.SdtMessages_Message AV25Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_manageorganisationprovisioning__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_manageorganisationprovisioning__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wp_manageorganisationprovisioning__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmH00A42;
       prmH00A42 = new Object[] {
       new ParDef("AV17OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("H00A42", "SELECT OrganisationId, OrganisationSettingid, OrganisationHasDynamicForms, OrganisationHasMyCare, OrganisationHasMyLiving, OrganisationHasMyServices, OrganisationBrandTheme, OrganisationHasOwnBrand, OrganisationCtaTheme FROM Trn_OrganisationSetting WHERE OrganisationId = :AV17OrganisationId ORDER BY OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A42,100, GxCacheFrequency.OFF ,false,false )
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
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             ((bool[]) buf[4])[0] = rslt.getBool(5);
             ((bool[]) buf[5])[0] = rslt.getBool(6);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((string[]) buf[8])[0] = rslt.getLongVarchar(9);
             return;
    }
 }

}

}
