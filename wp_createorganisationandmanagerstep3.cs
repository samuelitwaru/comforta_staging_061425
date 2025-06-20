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
   public class wp_createorganisationandmanagerstep3 : GXWebComponent
   {
      public wp_createorganisationandmanagerstep3( )
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

      public wp_createorganisationandmanagerstep3( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WebSessionKey ,
                           string aP1_PreviousStep ,
                           bool aP2_GoingBack )
      {
         this.AV54WebSessionKey = aP0_WebSessionKey;
         this.AV47PreviousStep = aP1_PreviousStep;
         this.AV12GoingBack = aP2_GoingBack;
         ExecuteImpl();
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
         chkavOrganisationhasmycare = new GXCheckbox();
         chkavOrganisationhasmyliving = new GXCheckbox();
         chkavOrganisationhasmyservices = new GXCheckbox();
         chkavOrganisationhasownbrand = new GXCheckbox();
         chkavOrganisationhasdynamicforms = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WebSessionKey");
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
                  AV54WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV54WebSessionKey", AV54WebSessionKey);
                  AV47PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV47PreviousStep", AV47PreviousStep);
                  AV12GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV12GoingBack", AV12GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV54WebSessionKey,(string)AV47PreviousStep,(bool)AV12GoingBack});
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
                  gxfirstwebparm = GetFirstPar( "WebSessionKey");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WebSessionKey");
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
            PAA52( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WSA52( ) ;
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
            context.SendWebValue( context.GetMessage( "WP_Create Organisation And Manager Step3", "")) ;
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
         context.AddJavascriptSource("UserControls/UC_ThemeSelectorRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UC_CtaThemeSelectorRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UC_FileUploadRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
            GXEncryptionTmp = "wp_createorganisationandmanagerstep3.aspx"+UrlEncode(StringUtil.RTrim(AV54WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV47PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV12GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_createorganisationandmanagerstep3.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV13HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV13HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vIMAGEPLACEHOLDER", AV68ImagePlaceholder);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vIMAGEPLACEHOLDER", GetSecureSignedToken( sPrefix, AV68ImagePlaceholder, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSELECTEDBRANDTHEME", AV56SelectedBrandTheme);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSELECTEDBRANDTHEME", AV56SelectedBrandTheme);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSELECTEDCTATHEME", AV57SelectedCtaTheme);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSELECTEDCTATHEME", AV57SelectedCtaTheme);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFILEUPLOADEDDATA", AV67FileUploadedData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFILEUPLOADEDDATA", AV67FileUploadedData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV54WebSessionKey", wcpOAV54WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV47PreviousStep", wcpOAV47PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV12GoingBack", wcpOAV12GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV13HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV13HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV54WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"vBASE64STRING", AV66base64String);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA", AV55WizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA", AV55WizardData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vIMAGEFILE", AV14ImageFile);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTRN_MANAGER", AV50Trn_Manager);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTRN_MANAGER", AV50Trn_Manager);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISSUCCESSFUL", AV20isSuccessful);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vERRORMESSAGES", AV8ErrorMessages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vERRORMESSAGES", AV8ErrorMessages);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vIMAGEPLACEHOLDER", AV68ImagePlaceholder);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vIMAGEPLACEHOLDER", GetSecureSignedToken( sPrefix, AV68ImagePlaceholder, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV47PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV12GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"LOGOUPLOAD_Previewimagelink", StringUtil.RTrim( Logoupload_Previewimagelink));
         GxWebStd.gx_hidden_field( context, sPrefix+"LOGOUPLOAD_Previewimagelink", StringUtil.RTrim( Logoupload_Previewimagelink));
      }

      protected void RenderHtmlCloseFormA52( )
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
         return "WP_CreateOrganisationAndManagerStep3" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Create Organisation And Manager Step3", "") ;
      }

      protected void WBA50( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wp_createorganisationandmanagerstep3.aspx");
               context.AddJavascriptSource("UserControls/UC_ThemeSelectorRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/UC_CtaThemeSelectorRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/UC_FileUploadRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, context.GetMessage( "License", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateOrganisationAndManagerStep3.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOrganisationhasmycare_Internalname, StringUtil.BoolToStr( AV37OrganisationHasMyCare), "", context.GetMessage( "Organisation Has My Care", ""), 1, chkavOrganisationhasmycare.Enabled, "true", context.GetMessage( "My Care", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(23, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,23);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOrganisationhasmyliving_Internalname, StringUtil.BoolToStr( AV38OrganisationHasMyLiving), "", context.GetMessage( "Organisation Has My Living", ""), 1, chkavOrganisationhasmyliving.Enabled, "true", context.GetMessage( "My Living", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(27, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,27);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOrganisationhasmyservices_Internalname, StringUtil.BoolToStr( AV39OrganisationHasMyServices), "", context.GetMessage( "Organisation Has My Services", ""), 1, chkavOrganisationhasmyservices.Enabled, "true", context.GetMessage( "My Services", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(31, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,31);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOrganisationhasownbrand_Internalname, StringUtil.BoolToStr( AV63OrganisationHasOwnBrand), "", context.GetMessage( "Organisation Has Own Brand", ""), 1, chkavOrganisationhasownbrand.Enabled, "true", context.GetMessage( "Brand Theme", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(35, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,35);\"");
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
            GxWebStd.gx_label_ctrl( context, lblThemelabel_Internalname, context.GetMessage( "Your Brand Theme", ""), "", "", lblThemelabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateOrganisationAndManagerStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucThemeselector.SetProperty("SelectedTheme", AV56SelectedBrandTheme);
            ucThemeselector.Render(context, "uc_themeselector", Themeselector_Internalname, sPrefix+"THEMESELECTORContainer");
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
            GxWebStd.gx_label_ctrl( context, lblCtatheme_Internalname, context.GetMessage( "Call To Action Theme", ""), "", "", lblCtatheme_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateOrganisationAndManagerStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCalltoactionthemeselector.SetProperty("ctaColor1", Calltoactionthemeselector_Ctacolor1);
            ucCalltoactionthemeselector.SetProperty("ctaColor2", Calltoactionthemeselector_Ctacolor2);
            ucCalltoactionthemeselector.SetProperty("ctaColor3", Calltoactionthemeselector_Ctacolor3);
            ucCalltoactionthemeselector.SetProperty("ctaColor4", Calltoactionthemeselector_Ctacolor4);
            ucCalltoactionthemeselector.SetProperty("ctaColor5", Calltoactionthemeselector_Ctacolor5);
            ucCalltoactionthemeselector.SetProperty("ctaColor6", Calltoactionthemeselector_Ctacolor6);
            ucCalltoactionthemeselector.SetProperty("ResultTheme", AV57SelectedCtaTheme);
            ucCalltoactionthemeselector.Render(context, "uc_ctathemeselector", Calltoactionthemeselector_Internalname, sPrefix+"CALLTOACTIONTHEMESELECTORContainer");
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
            GxWebStd.gx_label_ctrl( context, lblAvatarlabel_Internalname, context.GetMessage( "Application Logo", ""), "", "", lblAvatarlabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateOrganisationAndManagerStep3.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucLogoupload.SetProperty("UploadedFile", AV67FileUploadedData);
            ucLogoupload.SetProperty("PreviewImageLink", Logoupload_Previewimagelink);
            ucLogoupload.Render(context, "uc_fileupload", Logoupload_Internalname, sPrefix+"LOGOUPLOADContainer");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellWizardActions", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardprevious.SetProperty("TooltipText", Btnwizardprevious_Tooltiptext);
            ucBtnwizardprevious.SetProperty("Caption", Btnwizardprevious_Caption);
            ucBtnwizardprevious.SetProperty("Class", Btnwizardprevious_Class);
            ucBtnwizardprevious.Render(context, "wwp_iconbutton", Btnwizardprevious_Internalname, sPrefix+"BTNWIZARDPREVIOUSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardfinish.SetProperty("TooltipText", Btnwizardfinish_Tooltiptext);
            ucBtnwizardfinish.SetProperty("Caption", Btnwizardfinish_Caption);
            ucBtnwizardfinish.SetProperty("Class", Btnwizardfinish_Class);
            ucBtnwizardfinish.Render(context, "wwp_iconbutton", Btnwizardfinish_Internalname, sPrefix+"BTNWIZARDFINISHContainer");
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
            ucComfirmdeletemodal.Render(context, "dvelop.gxbootstrap.confirmpanel", Comfirmdeletemodal_Internalname, sPrefix+"COMFIRMDELETEMODALContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOrganisationhasdynamicforms_Internalname, StringUtil.BoolToStr( AV36OrganisationHasDynamicForms), "", "", chkavOrganisationhasdynamicforms.Visible, 1, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(76, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,76);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void STARTA52( )
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
            Form.Meta.addItem("description", context.GetMessage( "WP_Create Organisation And Manager Step3", ""), 0) ;
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
               STRUPA50( ) ;
            }
         }
      }

      protected void WSA52( )
      {
         STARTA52( ) ;
         EVTA52( ) ;
      }

      protected void EVTA52( )
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
                                 STRUPA50( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "LOGOUPLOAD.ONUPLOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA50( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Logoupload.Onupload */
                                    E11A52 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOGOUPLOAD.ONFAILEDUPLOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA50( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Logoupload.Onfailedupload */
                                    E12A52 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOGOUPLOAD.ONCLICKDELETE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA50( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Logoupload.Onclickdelete */
                                    E13A52 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA50( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E14A52 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA50( ) ;
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
                                          E15A52 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'WIZARDPREVIOUS'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA50( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E16A52 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOWIZARDFINISH'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA50( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoWizardFinish' */
                                    E17A52 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA50( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E18A52 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPA50( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = chkavOrganisationhasmycare_Internalname;
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

      protected void WEA52( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormA52( ) ;
            }
         }
      }

      protected void PAA52( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_createorganisationandmanagerstep3.aspx")), "wp_createorganisationandmanagerstep3.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_createorganisationandmanagerstep3.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "WebSessionKey");
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
               GX_FocusControl = chkavOrganisationhasmycare_Internalname;
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
         AV37OrganisationHasMyCare = StringUtil.StrToBool( StringUtil.BoolToStr( AV37OrganisationHasMyCare));
         AssignAttri(sPrefix, false, "AV37OrganisationHasMyCare", AV37OrganisationHasMyCare);
         AV38OrganisationHasMyLiving = StringUtil.StrToBool( StringUtil.BoolToStr( AV38OrganisationHasMyLiving));
         AssignAttri(sPrefix, false, "AV38OrganisationHasMyLiving", AV38OrganisationHasMyLiving);
         AV39OrganisationHasMyServices = StringUtil.StrToBool( StringUtil.BoolToStr( AV39OrganisationHasMyServices));
         AssignAttri(sPrefix, false, "AV39OrganisationHasMyServices", AV39OrganisationHasMyServices);
         AV63OrganisationHasOwnBrand = StringUtil.StrToBool( StringUtil.BoolToStr( AV63OrganisationHasOwnBrand));
         AssignAttri(sPrefix, false, "AV63OrganisationHasOwnBrand", AV63OrganisationHasOwnBrand);
         AV36OrganisationHasDynamicForms = StringUtil.StrToBool( StringUtil.BoolToStr( AV36OrganisationHasDynamicForms));
         AssignAttri(sPrefix, false, "AV36OrganisationHasDynamicForms", AV36OrganisationHasDynamicForms);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFA52( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFA52( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E18A52 ();
            WBA50( ) ;
         }
      }

      protected void send_integrity_lvl_hashesA52( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV13HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV13HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vIMAGEPLACEHOLDER", AV68ImagePlaceholder);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vIMAGEPLACEHOLDER", GetSecureSignedToken( sPrefix, AV68ImagePlaceholder, context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUPA50( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E14A52 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSELECTEDBRANDTHEME"), AV56SelectedBrandTheme);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSELECTEDCTATHEME"), AV57SelectedCtaTheme);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFILEUPLOADEDDATA"), AV67FileUploadedData);
            /* Read saved values. */
            wcpOAV54WebSessionKey = cgiGet( sPrefix+"wcpOAV54WebSessionKey");
            wcpOAV47PreviousStep = cgiGet( sPrefix+"wcpOAV47PreviousStep");
            wcpOAV12GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV12GoingBack"));
            AV68ImagePlaceholder = cgiGet( sPrefix+"vIMAGEPLACEHOLDER");
            AV66base64String = cgiGet( sPrefix+"vBASE64STRING");
            Logoupload_Previewimagelink = cgiGet( sPrefix+"LOGOUPLOAD_Previewimagelink");
            /* Read variables values. */
            AV37OrganisationHasMyCare = StringUtil.StrToBool( cgiGet( chkavOrganisationhasmycare_Internalname));
            AssignAttri(sPrefix, false, "AV37OrganisationHasMyCare", AV37OrganisationHasMyCare);
            AV38OrganisationHasMyLiving = StringUtil.StrToBool( cgiGet( chkavOrganisationhasmyliving_Internalname));
            AssignAttri(sPrefix, false, "AV38OrganisationHasMyLiving", AV38OrganisationHasMyLiving);
            AV39OrganisationHasMyServices = StringUtil.StrToBool( cgiGet( chkavOrganisationhasmyservices_Internalname));
            AssignAttri(sPrefix, false, "AV39OrganisationHasMyServices", AV39OrganisationHasMyServices);
            AV63OrganisationHasOwnBrand = StringUtil.StrToBool( cgiGet( chkavOrganisationhasownbrand_Internalname));
            AssignAttri(sPrefix, false, "AV63OrganisationHasOwnBrand", AV63OrganisationHasOwnBrand);
            AV36OrganisationHasDynamicForms = StringUtil.StrToBool( cgiGet( chkavOrganisationhasdynamicforms_Internalname));
            AssignAttri(sPrefix, false, "AV36OrganisationHasDynamicForms", AV36OrganisationHasDynamicForms);
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
         E14A52 ();
         if (returnInSub) return;
      }

      protected void E14A52( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         chkavOrganisationhasdynamicforms.Visible = 0;
         AssignProp(sPrefix, false, chkavOrganisationhasdynamicforms_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavOrganisationhasdynamicforms.Visible), 5, 0), true);
         AV68ImagePlaceholder = context.GetMessage( "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAALAAAACUCAMAAAAEVFNMAAAANlBMVEX///+hoaH8/PycnJzJycmzs7OlpaWXl5fX19e6urqrq6vT09Pn5+fCwsK2trb5+fnx8fHd3d33lFFhAAACAElEQVR4nO3Z7XKDIBCFYWAVFFHx/m+2qNEhUSaFtllmep6/CZN3yIr5EAIAAAAAAAAAAAAAAAAAAAAAAP4J3/3E/Png1lA5M3w+2EpdTFLz8V5lqStePBmO4PK3VfXMwUplrmUNVt7nXvKMwUq4Xut2yNtizh32mqQkGvPWMu5wG3ql1GbJWssX7LTcZW0xY/Dy6KUpay3/DucNMecM97Qlk7t9khuWu/OD95QwITfx+k6b261nvXHMjbXt/Rnh7Xrk3Xzi4L41J+4aYVy2I89dnsAdfP+4GGi/HtvLnbvKYOFIpk6QKoO9lYfLbbDGYDXSGSy1fx7jGoO7qFdS/3zZVRIcR3kjYy99dQQv43AcB2pu6Sn45U5YRfASvrwfn4BU89IrpfXx2gqCXXyAdZfeMMbRaVxB8Gy3RtoOMH/JXR+KEisIPmZgfefn6brB+xgflyV/8HJWTUpcB3h/SJ9DwR7s9ZllmuW+dxtjVUewepoBmwqWdC5gDk7MwA1XRXByBq5b/Bhj3uDoY9n74pE/+PG94rs69uDGvK+MracxZ7DL2t8wFFax7vCcPsRSxY1QTMHhC/zcF/wzM3DtcHhlN/X5Rs+3w+HdLSAEU/DUlLIMf3sJS2QKUerHuD81tD8w+fcv8OuK5jcaZAAAAAAAAAAAAAAAAAAAAAAAyPcFE4AcP6bJZ48AAAAASUVORK5CYII=", "");
         AssignAttri(sPrefix, false, "AV68ImagePlaceholder", AV68ImagePlaceholder);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vIMAGEPLACEHOLDER", GetSecureSignedToken( sPrefix, AV68ImagePlaceholder, context));
         Logoupload_Previewimagelink = AV68ImagePlaceholder;
         ucLogoupload.SendProperty(context, sPrefix, false, Logoupload_Internalname, "PreviewImageLink", Logoupload_Previewimagelink);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E15A52 ();
         if (returnInSub) return;
      }

      protected void E15A52( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( ! AV13HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S132 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'FINISHWIZARD' */
            S142 ();
            if (returnInSub) return;
            AV53WebSession.Remove(AV54WebSessionKey);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV55WizardData", AV55WizardData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV8ErrorMessages", AV8ErrorMessages);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV50Trn_Manager", AV50Trn_Manager);
      }

      protected void E16A52( )
      {
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
         S132 ();
         if (returnInSub) return;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_createorganisationandmanager.aspx"+UrlEncode(StringUtil.RTrim("Step3")) + "," + UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wp_createorganisationandmanager.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV55WizardData", AV55WizardData);
      }

      protected void E17A52( )
      {
         /* 'DoWizardFinish' Routine */
         returnInSub = false;
         if ( ! AV13HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S132 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'FINISHWIZARD' */
            S142 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV55WizardData", AV55WizardData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV8ErrorMessages", AV8ErrorMessages);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV50Trn_Manager", AV50Trn_Manager);
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV55WizardData.FromJSonString(AV53WebSession.Get(AV54WebSessionKey), null);
         AV37OrganisationHasMyCare = AV55WizardData.gxTpr_Step3.gxTpr_Organisationhasmycare;
         AssignAttri(sPrefix, false, "AV37OrganisationHasMyCare", AV37OrganisationHasMyCare);
         AV38OrganisationHasMyLiving = AV55WizardData.gxTpr_Step3.gxTpr_Organisationhasmyliving;
         AssignAttri(sPrefix, false, "AV38OrganisationHasMyLiving", AV38OrganisationHasMyLiving);
         AV39OrganisationHasMyServices = AV55WizardData.gxTpr_Step3.gxTpr_Organisationhasmyservices;
         AssignAttri(sPrefix, false, "AV39OrganisationHasMyServices", AV39OrganisationHasMyServices);
         AV36OrganisationHasDynamicForms = AV55WizardData.gxTpr_Step3.gxTpr_Organisationhasdynamicforms;
         AssignAttri(sPrefix, false, "AV36OrganisationHasDynamicForms", AV36OrganisationHasDynamicForms);
         AV63OrganisationHasOwnBrand = AV55WizardData.gxTpr_Step3.gxTpr_Organisationhasownbrand;
         AssignAttri(sPrefix, false, "AV63OrganisationHasOwnBrand", AV63OrganisationHasOwnBrand);
         if ( AV59DefaultBrandTheme.FromJSonString(AV34OrganisationBrandTheme, null) )
         {
            Themeselector_Accentcolorvalue = AV59DefaultBrandTheme.gxTpr_Accentcolorvalue;
            ucThemeselector.SendProperty(context, sPrefix, false, Themeselector_Internalname, "accentColorValue", Themeselector_Accentcolorvalue);
            Themeselector_Backgroundcolorvalue = AV59DefaultBrandTheme.gxTpr_Backgroundcolorvalue;
            ucThemeselector.SendProperty(context, sPrefix, false, Themeselector_Internalname, "backgroundColorValue", Themeselector_Backgroundcolorvalue);
            Themeselector_Bordercolorvalue = AV59DefaultBrandTheme.gxTpr_Bordercolorvalue;
            ucThemeselector.SendProperty(context, sPrefix, false, Themeselector_Internalname, "borderColorValue", Themeselector_Bordercolorvalue);
            Themeselector_Buttonbgcolorvalue = AV59DefaultBrandTheme.gxTpr_Buttonbgcolorvalue;
            ucThemeselector.SendProperty(context, sPrefix, false, Themeselector_Internalname, "buttonBGColorValue", Themeselector_Buttonbgcolorvalue);
            Themeselector_Buttontextcolorvalue = AV59DefaultBrandTheme.gxTpr_Buttontextcolorvalue;
            ucThemeselector.SendProperty(context, sPrefix, false, Themeselector_Internalname, "buttonTextColorValue", Themeselector_Buttontextcolorvalue);
            Themeselector_Cardbgcolorvalue = AV59DefaultBrandTheme.gxTpr_Cardbgcolorvalue;
            ucThemeselector.SendProperty(context, sPrefix, false, Themeselector_Internalname, "cardBgColorValue", Themeselector_Cardbgcolorvalue);
            Themeselector_Cardtextcolorvalue = AV59DefaultBrandTheme.gxTpr_Cardtextcolorvalue;
            ucThemeselector.SendProperty(context, sPrefix, false, Themeselector_Internalname, "cardTextColorValue", Themeselector_Cardtextcolorvalue);
            Themeselector_Primarycolorvalue = AV59DefaultBrandTheme.gxTpr_Primarycolorvalue;
            ucThemeselector.SendProperty(context, sPrefix, false, Themeselector_Internalname, "primaryColorValue", Themeselector_Primarycolorvalue);
            Themeselector_Secondarycolorvalue = AV59DefaultBrandTheme.gxTpr_Secondarycolorvalue;
            ucThemeselector.SendProperty(context, sPrefix, false, Themeselector_Internalname, "secondaryColorValue", Themeselector_Secondarycolorvalue);
            Themeselector_Textcolorvalue = AV59DefaultBrandTheme.gxTpr_Textcolorvalue;
            ucThemeselector.SendProperty(context, sPrefix, false, Themeselector_Internalname, "textColorValue", Themeselector_Textcolorvalue);
         }
         if ( AV60DefaultCtaTheme.FromJSonString(AV58OrganisationCtaTheme, null) )
         {
            Calltoactionthemeselector_Ctacolor1 = AV60DefaultCtaTheme.gxTpr_Ctacolor1;
            ucCalltoactionthemeselector.SendProperty(context, sPrefix, false, Calltoactionthemeselector_Internalname, "ctaColor1", Calltoactionthemeselector_Ctacolor1);
            Calltoactionthemeselector_Ctacolor2 = AV60DefaultCtaTheme.gxTpr_Ctacolor2;
            ucCalltoactionthemeselector.SendProperty(context, sPrefix, false, Calltoactionthemeselector_Internalname, "ctaColor2", Calltoactionthemeselector_Ctacolor2);
            Calltoactionthemeselector_Ctacolor3 = AV60DefaultCtaTheme.gxTpr_Ctacolor3;
            ucCalltoactionthemeselector.SendProperty(context, sPrefix, false, Calltoactionthemeselector_Internalname, "ctaColor3", Calltoactionthemeselector_Ctacolor3);
            Calltoactionthemeselector_Ctacolor4 = AV60DefaultCtaTheme.gxTpr_Ctacolor4;
            ucCalltoactionthemeselector.SendProperty(context, sPrefix, false, Calltoactionthemeselector_Internalname, "ctaColor4", Calltoactionthemeselector_Ctacolor4);
         }
      }

      protected void S132( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV58OrganisationCtaTheme = AV57SelectedCtaTheme.ToJSonString(false, true);
         AssignAttri(sPrefix, false, "AV58OrganisationCtaTheme", AV58OrganisationCtaTheme);
         AV34OrganisationBrandTheme = AV56SelectedBrandTheme.ToJSonString(false, true);
         AssignAttri(sPrefix, false, "AV34OrganisationBrandTheme", AV34OrganisationBrandTheme);
         AV55WizardData.FromJSonString(AV53WebSession.Get(AV54WebSessionKey), null);
         AV55WizardData.gxTpr_Step3.gxTpr_Organisationhasmycare = AV37OrganisationHasMyCare;
         AV55WizardData.gxTpr_Step3.gxTpr_Organisationhasmyliving = AV38OrganisationHasMyLiving;
         AV55WizardData.gxTpr_Step3.gxTpr_Organisationhasmyservices = AV39OrganisationHasMyServices;
         AV55WizardData.gxTpr_Step3.gxTpr_Organisationhasdynamicforms = AV36OrganisationHasDynamicForms;
         AV55WizardData.gxTpr_Step3.gxTpr_Organisationhasownbrand = AV63OrganisationHasOwnBrand;
         AV53WebSession.Set(AV54WebSessionKey, AV55WizardData.ToJSonString(false, true));
      }

      protected void S142( )
      {
         /* 'FINISHWIZARD' Routine */
         returnInSub = false;
         if ( AV63OrganisationHasOwnBrand )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66base64String)) )
            {
               AV14ImageFile=context.FileFromBase64( AV66base64String) ;
            }
            else
            {
               AV14ImageFile = "";
               AssignAttri(sPrefix, false, "AV14ImageFile", AV14ImageFile);
            }
         }
         AV8ErrorMessages.Clear();
         AV51Trn_Organisation = new SdtTrn_Organisation(context);
         AV51Trn_Organisation.gxTpr_Organisationid = AV55WizardData.gxTpr_Step1.gxTpr_Organisationid;
         AV51Trn_Organisation.gxTpr_Organisationname = AV55WizardData.gxTpr_Step1.gxTpr_Organisationname;
         AV51Trn_Organisation.gxTpr_Organisationemail = AV55WizardData.gxTpr_Step1.gxTpr_Organisationemail;
         AV51Trn_Organisation.gxTpr_Organisationkvknumber = AV55WizardData.gxTpr_Step1.gxTpr_Organisationkvknumber;
         AV51Trn_Organisation.gxTpr_Organisationphonecode = AV55WizardData.gxTpr_Step1.gxTpr_Organisationphonecode;
         AV51Trn_Organisation.gxTpr_Organisationphonenumber = AV55WizardData.gxTpr_Step1.gxTpr_Organisationphonenumber;
         AV51Trn_Organisation.gxTpr_Organisationphone = AV55WizardData.gxTpr_Step1.gxTpr_Organisationphone;
         AV51Trn_Organisation.gxTpr_Organisationvatnumber = AV55WizardData.gxTpr_Step1.gxTpr_Organisationvatnumber;
         AV51Trn_Organisation.gxTpr_Organisationtypeid = AV55WizardData.gxTpr_Step1.gxTpr_Organisationtypeid;
         AV51Trn_Organisation.gxTpr_Organisationaddresscity = AV55WizardData.gxTpr_Step1.gxTpr_Organisationaddresscity;
         AV51Trn_Organisation.gxTpr_Organisationaddresszipcode = AV55WizardData.gxTpr_Step1.gxTpr_Organisationaddresszipcode;
         AV51Trn_Organisation.gxTpr_Organisationaddresscountry = AV55WizardData.gxTpr_Step1.gxTpr_Organisationaddresscountry;
         AV51Trn_Organisation.gxTpr_Organisationaddressline1 = AV55WizardData.gxTpr_Step1.gxTpr_Organisationaddressline1;
         AV51Trn_Organisation.gxTpr_Organisationaddressline2 = AV55WizardData.gxTpr_Step1.gxTpr_Organisationaddressline2;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14ImageFile)) && AV63OrganisationHasOwnBrand )
         {
            AV51Trn_Organisation.gxTpr_Organisationlogo = AV14ImageFile;
            AV51Trn_Organisation.gxTpr_Organisationlogo_gxi = GXDbFile.GetUriFromFile( "", "", AV14ImageFile);
         }
         else
         {
            AV51Trn_Organisation.gxTpr_Organisationlogo = "";
            AV51Trn_Organisation.gxTpr_Organisationlogo_gxi = "";
         }
         new GeneXus.Core.genexus.common.SdtLog(context).info(context.GetMessage( "Organisation ID: ", "")+AV51Trn_Organisation.gxTpr_Organisationid.ToString()) ;
         AV5count = 0;
         AV19isOrganisationInserted = AV51Trn_Organisation.Insert();
         if ( AV19isOrganisationInserted )
         {
            AV49SDT_Managers = AV55WizardData.gxTpr_Step2.gxTpr_Sdt_managers;
            AV70GXV1 = 1;
            while ( AV70GXV1 <= AV49SDT_Managers.Count )
            {
               AV48SDT_Manager = ((SdtSDT_Managers_SDT_ManagersItem)AV49SDT_Managers.Item(AV70GXV1));
               AV5count = (short)(AV5count+1);
               AV50Trn_Manager.gxTpr_Managerid = AV48SDT_Manager.gxTpr_Managerid;
               AV50Trn_Manager.gxTpr_Managergivenname = AV48SDT_Manager.gxTpr_Managergivenname;
               AV50Trn_Manager.gxTpr_Managerlastname = AV48SDT_Manager.gxTpr_Managerlastname;
               AV50Trn_Manager.gxTpr_Manageremail = AV48SDT_Manager.gxTpr_Manageremail;
               AV50Trn_Manager.gxTpr_Managerphone = AV48SDT_Manager.gxTpr_Managerphone;
               AV50Trn_Manager.gxTpr_Managerphonecode = AV48SDT_Manager.gxTpr_Managerphonecode;
               AV50Trn_Manager.gxTpr_Managerphonenumber = AV48SDT_Manager.gxTpr_Managerphonenumber;
               AV50Trn_Manager.gxTpr_Organisationid = AV51Trn_Organisation.gxTpr_Organisationid;
               AV50Trn_Manager.gxTpr_Managergender = AV48SDT_Manager.gxTpr_Managergender;
               AV50Trn_Manager.gxTpr_Managergamguid = Guid.NewGuid( ).ToString();
               AV50Trn_Manager.gxTpr_Managerismainmanager = AV48SDT_Manager.gxTpr_Managerismainmanager;
               AV18isManagerInserted = AV50Trn_Manager.Insert();
               if ( ! AV18isManagerInserted )
               {
                  AV72GXV3 = 1;
                  AV71GXV2 = AV50Trn_Manager.GetMessages();
                  while ( AV72GXV3 <= AV71GXV2.Count )
                  {
                     AV7Error = ((GeneXus.Utils.SdtMessages_Message)AV71GXV2.Item(AV72GXV3));
                     AV8ErrorMessages.Add(AV7Error, 0);
                     AV72GXV3 = (int)(AV72GXV3+1);
                  }
               }
               else
               {
                  GXt_char1 = AV50Trn_Manager.gxTpr_Managergamguid;
                  new prc_creategamuseraccountnocommit(context ).execute(  AV50Trn_Manager.gxTpr_Manageremail,  AV50Trn_Manager.gxTpr_Managergivenname,  AV50Trn_Manager.gxTpr_Managerlastname,  "Organisation Manager", ref  GXt_char1, ref  AV9GAMErrorCollection, ref  AV20isSuccessful) ;
                  AV50Trn_Manager.gxTpr_Managergamguid = GXt_char1;
                  AssignAttri(sPrefix, false, "AV20isSuccessful", AV20isSuccessful);
                  AV73GXV4 = 1;
                  while ( AV73GXV4 <= AV9GAMErrorCollection.Count )
                  {
                     AV10GAMErrorItem = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV9GAMErrorCollection.Item(AV73GXV4));
                     AV7Error = new GeneXus.Utils.SdtMessages_Message(context);
                     AV7Error.gxTpr_Id = Guid.NewGuid( ).ToString();
                     AV7Error.gxTpr_Type = 1;
                     AV7Error.gxTpr_Description = AV10GAMErrorItem.gxTpr_Message;
                     AV8ErrorMessages.Add(AV7Error, 0);
                     AV73GXV4 = (int)(AV73GXV4+1);
                  }
               }
               AV70GXV1 = (int)(AV70GXV1+1);
            }
            AV52Trn_OrganisationSetting = new SdtTrn_OrganisationSetting(context);
            AV52Trn_OrganisationSetting.gxTpr_Organisationsettingid = Guid.NewGuid( );
            AV52Trn_OrganisationSetting.gxTpr_Organisationid = AV55WizardData.gxTpr_Step1.gxTpr_Organisationid;
            AV52Trn_OrganisationSetting.gxTpr_Organisationhasmycare = AV37OrganisationHasMyCare;
            AV52Trn_OrganisationSetting.gxTpr_Organisationhasmyliving = AV38OrganisationHasMyLiving;
            AV52Trn_OrganisationSetting.gxTpr_Organisationhasmyservices = AV39OrganisationHasMyServices;
            AV52Trn_OrganisationSetting.gxTpr_Organisationhasdynamicforms = AV36OrganisationHasDynamicForms;
            AV52Trn_OrganisationSetting.gxTpr_Organisationhasownbrand = AV63OrganisationHasOwnBrand;
            if ( AV63OrganisationHasOwnBrand )
            {
               AV52Trn_OrganisationSetting.gxTpr_Organisationbrandtheme = AV56SelectedBrandTheme.ToJSonString(false, true);
               AV52Trn_OrganisationSetting.gxTpr_Organisationctatheme = AV57SelectedCtaTheme.ToJSonString(false, true);
            }
            AV52Trn_OrganisationSetting.Insert();
            if ( ! AV52Trn_OrganisationSetting.Success() )
            {
               AV8ErrorMessages = AV52Trn_OrganisationSetting.GetMessages();
            }
            if ( AV8ErrorMessages.Count > 0 )
            {
               context.RollbackDataStores("wp_createorganisationandmanagerstep3",pr_default);
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S152 ();
               if (returnInSub) return;
            }
            else
            {
               AV49SDT_Managers.Clear();
               context.CommitDataStores("wp_createorganisationandmanagerstep3",pr_default);
               AV53WebSession.Remove(AV54WebSessionKey);
               AV53WebSession.Set(context.GetMessage( "NotificationMessage", ""), context.GetMessage( "Organisation Created successfully", ""));
               CallWebObject(formatLink("trn_organisationww.aspx") );
               context.wjLocDisableFrm = 1;
            }
         }
         else
         {
            AV8ErrorMessages = AV51Trn_Organisation.GetMessages();
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S152 ();
            if (returnInSub) return;
         }
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         divBrandtable_Visible = (((AV63OrganisationHasOwnBrand)) ? 1 : 0);
         AssignProp(sPrefix, false, divBrandtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divBrandtable_Visible), 5, 0), true);
         divCtatable_Visible = (((AV63OrganisationHasOwnBrand)) ? 1 : 0);
         AssignProp(sPrefix, false, divCtatable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCtatable_Visible), 5, 0), true);
      }

      protected void E11A52( )
      {
         /* Logoupload_Onupload Routine */
         returnInSub = false;
         AV64OrganisationLogo = "";
         AV74Organisationlogo_GXI = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67FileUploadedData.gxTpr_Base64image)) )
         {
            AV66base64String = GxRegex.Split(AV67FileUploadedData.gxTpr_Base64image,",").GetString(2);
            AssignAttri(sPrefix, false, "AV66base64String", AV66base64String);
         }
         /*  Sending Event outputs  */
      }

      protected void E12A52( )
      {
         /* Logoupload_Onfailedupload Routine */
         returnInSub = false;
         GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "Maximum file size allowed is 2MB.", ""),  "error",  "",  "true",  ""));
      }

      protected void E13A52( )
      {
         /* Logoupload_Onclickdelete Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Logoupload_Previewimagelink, AV68ImagePlaceholder) == 0 ) && String.IsNullOrEmpty(StringUtil.RTrim( AV67FileUploadedData.gxTpr_Base64image)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  context.GetMessage( "No logo to delete", ""),  "info",  "",  "true",  ""));
         }
         else
         {
            this.executeUsercontrolMethod(sPrefix, false, "COMFIRMDELETEMODALContainer", "Confirm", "", new Object[] {});
         }
      }

      protected void S152( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV75GXV5 = 1;
         while ( AV75GXV5 <= AV8ErrorMessages.Count )
         {
            AV7Error = ((GeneXus.Utils.SdtMessages_Message)AV8ErrorMessages.Item(AV75GXV5));
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error",  AV7Error.gxTpr_Description,  "error",  "",  "true",  ""));
            AV75GXV5 = (int)(AV75GXV5+1);
         }
         AV8ErrorMessages.Clear();
      }

      protected void nextLoad( )
      {
      }

      protected void E18A52( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV54WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV54WebSessionKey", AV54WebSessionKey);
         AV47PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV47PreviousStep", AV47PreviousStep);
         AV12GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV12GoingBack", AV12GoingBack);
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
         PAA52( ) ;
         WSA52( ) ;
         WEA52( ) ;
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
         sCtrlAV54WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV47PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV12GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PAA52( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wp_createorganisationandmanagerstep3", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PAA52( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV54WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV54WebSessionKey", AV54WebSessionKey);
            AV47PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV47PreviousStep", AV47PreviousStep);
            AV12GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV12GoingBack", AV12GoingBack);
         }
         wcpOAV54WebSessionKey = cgiGet( sPrefix+"wcpOAV54WebSessionKey");
         wcpOAV47PreviousStep = cgiGet( sPrefix+"wcpOAV47PreviousStep");
         wcpOAV12GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV12GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV54WebSessionKey, wcpOAV54WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV47PreviousStep, wcpOAV47PreviousStep) != 0 ) || ( AV12GoingBack != wcpOAV12GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV54WebSessionKey = AV54WebSessionKey;
         wcpOAV47PreviousStep = AV47PreviousStep;
         wcpOAV12GoingBack = AV12GoingBack;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV54WebSessionKey = cgiGet( sPrefix+"AV54WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV54WebSessionKey) > 0 )
         {
            AV54WebSessionKey = cgiGet( sCtrlAV54WebSessionKey);
            AssignAttri(sPrefix, false, "AV54WebSessionKey", AV54WebSessionKey);
         }
         else
         {
            AV54WebSessionKey = cgiGet( sPrefix+"AV54WebSessionKey_PARM");
         }
         sCtrlAV47PreviousStep = cgiGet( sPrefix+"AV47PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV47PreviousStep) > 0 )
         {
            AV47PreviousStep = cgiGet( sCtrlAV47PreviousStep);
            AssignAttri(sPrefix, false, "AV47PreviousStep", AV47PreviousStep);
         }
         else
         {
            AV47PreviousStep = cgiGet( sPrefix+"AV47PreviousStep_PARM");
         }
         sCtrlAV12GoingBack = cgiGet( sPrefix+"AV12GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV12GoingBack) > 0 )
         {
            AV12GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV12GoingBack));
            AssignAttri(sPrefix, false, "AV12GoingBack", AV12GoingBack);
         }
         else
         {
            AV12GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV12GoingBack_PARM"));
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
         PAA52( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSA52( ) ;
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
         WSA52( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV54WebSessionKey_PARM", AV54WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV54WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV54WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV54WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV47PreviousStep_PARM", AV47PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV47PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV47PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV47PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV12GoingBack_PARM", StringUtil.BoolToStr( AV12GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV12GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV12GoingBack_CTRL", StringUtil.RTrim( sCtrlAV12GoingBack));
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
         WEA52( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256201722756", true, true);
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
         context.AddJavascriptSource("wp_createorganisationandmanagerstep3.js", "?20256201722757", false, true);
         context.AddJavascriptSource("UserControls/UC_ThemeSelectorRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UC_CtaThemeSelectorRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/UC_FileUploadRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
         AssignProp(sPrefix, false, chkavOrganisationhasmycare_Internalname, "TitleCaption", chkavOrganisationhasmycare.Caption, true);
         chkavOrganisationhasmycare.CheckedValue = "false";
         chkavOrganisationhasmyliving.Name = "vORGANISATIONHASMYLIVING";
         chkavOrganisationhasmyliving.WebTags = "";
         chkavOrganisationhasmyliving.Caption = context.GetMessage( "Organisation Has My Living", "");
         AssignProp(sPrefix, false, chkavOrganisationhasmyliving_Internalname, "TitleCaption", chkavOrganisationhasmyliving.Caption, true);
         chkavOrganisationhasmyliving.CheckedValue = "false";
         chkavOrganisationhasmyservices.Name = "vORGANISATIONHASMYSERVICES";
         chkavOrganisationhasmyservices.WebTags = "";
         chkavOrganisationhasmyservices.Caption = context.GetMessage( "Organisation Has My Services", "");
         AssignProp(sPrefix, false, chkavOrganisationhasmyservices_Internalname, "TitleCaption", chkavOrganisationhasmyservices.Caption, true);
         chkavOrganisationhasmyservices.CheckedValue = "false";
         chkavOrganisationhasownbrand.Name = "vORGANISATIONHASOWNBRAND";
         chkavOrganisationhasownbrand.WebTags = "";
         chkavOrganisationhasownbrand.Caption = context.GetMessage( "Organisation Has Own Brand", "");
         AssignProp(sPrefix, false, chkavOrganisationhasownbrand_Internalname, "TitleCaption", chkavOrganisationhasownbrand.Caption, true);
         chkavOrganisationhasownbrand.CheckedValue = "false";
         chkavOrganisationhasdynamicforms.Name = "vORGANISATIONHASDYNAMICFORMS";
         chkavOrganisationhasdynamicforms.WebTags = "";
         chkavOrganisationhasdynamicforms.Caption = "";
         AssignProp(sPrefix, false, chkavOrganisationhasdynamicforms_Internalname, "TitleCaption", chkavOrganisationhasdynamicforms.Caption, true);
         chkavOrganisationhasdynamicforms.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         chkavOrganisationhasmycare_Internalname = sPrefix+"vORGANISATIONHASMYCARE";
         chkavOrganisationhasmyliving_Internalname = sPrefix+"vORGANISATIONHASMYLIVING";
         chkavOrganisationhasmyservices_Internalname = sPrefix+"vORGANISATIONHASMYSERVICES";
         chkavOrganisationhasownbrand_Internalname = sPrefix+"vORGANISATIONHASOWNBRAND";
         divAgreementfields_Internalname = sPrefix+"AGREEMENTFIELDS";
         lblThemelabel_Internalname = sPrefix+"THEMELABEL";
         Themeselector_Internalname = sPrefix+"THEMESELECTOR";
         divBrandtable_Internalname = sPrefix+"BRANDTABLE";
         lblCtatheme_Internalname = sPrefix+"CTATHEME";
         Calltoactionthemeselector_Internalname = sPrefix+"CALLTOACTIONTHEMESELECTOR";
         lblAvatarlabel_Internalname = sPrefix+"AVATARLABEL";
         Logoupload_Internalname = sPrefix+"LOGOUPLOAD";
         divFieldavatartable_Internalname = sPrefix+"FIELDAVATARTABLE";
         divCtatable_Internalname = sPrefix+"CTATABLE";
         divBrandthemetable_Internalname = sPrefix+"BRANDTHEMETABLE";
         divGroupattributes_Internalname = sPrefix+"GROUPATTRIBUTES";
         grpUnnamedgroup1_Internalname = sPrefix+"UNNAMEDGROUP1";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         Btnwizardfinish_Internalname = sPrefix+"BTNWIZARDFINISH";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         Comfirmdeletemodal_Internalname = sPrefix+"COMFIRMDELETEMODAL";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         chkavOrganisationhasdynamicforms_Internalname = sPrefix+"vORGANISATIONHASDYNAMICFORMS";
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
         chkavOrganisationhasdynamicforms.Caption = "";
         chkavOrganisationhasownbrand.Caption = context.GetMessage( "Organisation Has Own Brand", "");
         chkavOrganisationhasmyservices.Caption = context.GetMessage( "Organisation Has My Services", "");
         chkavOrganisationhasmyliving.Caption = context.GetMessage( "Organisation Has My Living", "");
         chkavOrganisationhasmycare.Caption = context.GetMessage( "Organisation Has My Care", "");
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
         chkavOrganisationhasdynamicforms.Visible = 1;
         Comfirmdeletemodal_Bodytype = "No";
         Comfirmdeletemodal_Nobuttoncaption = "Cancel";
         Comfirmdeletemodal_Yesbuttoncaption = "Yes";
         Comfirmdeletemodal_Confirmationtext = "Are you sure you want to delete the current logo?";
         Comfirmdeletemodal_Title = context.GetMessage( "Comfirm Delete", "");
         Btnwizardfinish_Class = "ButtonMaterial";
         Btnwizardfinish_Caption = context.GetMessage( "Finish", "");
         Btnwizardfinish_Tooltiptext = "";
         Btnwizardprevious_Class = "ButtonMaterialDefault ButtonWizard";
         Btnwizardprevious_Caption = context.GetMessage( "GXM_previous", "");
         Btnwizardprevious_Tooltiptext = "";
         Calltoactionthemeselector_Ctacolor6 = "#B7B7B7";
         Calltoactionthemeselector_Ctacolor5 = "#E9C4AA";
         Calltoactionthemeselector_Ctacolor4 = "#C4A082";
         Calltoactionthemeselector_Ctacolor3 = "#969674";
         Calltoactionthemeselector_Ctacolor2 = "#D4A76A";
         Calltoactionthemeselector_Ctacolor1 = "#2C405A";
         divCtatable_Visible = 1;
         divBrandtable_Visible = 1;
         chkavOrganisationhasownbrand.Enabled = 1;
         chkavOrganisationhasmyservices.Enabled = 1;
         chkavOrganisationhasmyliving.Enabled = 1;
         chkavOrganisationhasmycare.Enabled = 1;
         Logoupload_Previewimagelink = "&ImagePalceholder";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV37OrganisationHasMyCare","fld":"vORGANISATIONHASMYCARE"},{"av":"AV38OrganisationHasMyLiving","fld":"vORGANISATIONHASMYLIVING"},{"av":"AV39OrganisationHasMyServices","fld":"vORGANISATIONHASMYSERVICES"},{"av":"AV63OrganisationHasOwnBrand","fld":"vORGANISATIONHASOWNBRAND"},{"av":"AV36OrganisationHasDynamicForms","fld":"vORGANISATIONHASDYNAMICFORMS"},{"av":"AV13HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV68ImagePlaceholder","fld":"vIMAGEPLACEHOLDER","hsh":true}]}""");
         setEventMetadata("ENTER","""{"handler":"E15A52","iparms":[{"av":"AV13HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV54WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV57SelectedCtaTheme","fld":"vSELECTEDCTATHEME"},{"av":"AV56SelectedBrandTheme","fld":"vSELECTEDBRANDTHEME"},{"av":"AV37OrganisationHasMyCare","fld":"vORGANISATIONHASMYCARE"},{"av":"AV38OrganisationHasMyLiving","fld":"vORGANISATIONHASMYLIVING"},{"av":"AV39OrganisationHasMyServices","fld":"vORGANISATIONHASMYSERVICES"},{"av":"AV36OrganisationHasDynamicForms","fld":"vORGANISATIONHASDYNAMICFORMS"},{"av":"AV63OrganisationHasOwnBrand","fld":"vORGANISATIONHASOWNBRAND"},{"av":"AV66base64String","fld":"vBASE64STRING"},{"av":"AV55WizardData","fld":"vWIZARDDATA"},{"av":"AV14ImageFile","fld":"vIMAGEFILE"},{"av":"AV50Trn_Manager","fld":"vTRN_MANAGER"},{"av":"AV20isSuccessful","fld":"vISSUCCESSFUL"},{"av":"AV8ErrorMessages","fld":"vERRORMESSAGES"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV58OrganisationCtaTheme","fld":"vORGANISATIONCTATHEME"},{"av":"AV34OrganisationBrandTheme","fld":"vORGANISATIONBRANDTHEME"},{"av":"AV55WizardData","fld":"vWIZARDDATA"},{"av":"AV14ImageFile","fld":"vIMAGEFILE"},{"av":"AV8ErrorMessages","fld":"vERRORMESSAGES"},{"av":"AV50Trn_Manager","fld":"vTRN_MANAGER"},{"av":"AV20isSuccessful","fld":"vISSUCCESSFUL"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E16A52","iparms":[{"av":"AV57SelectedCtaTheme","fld":"vSELECTEDCTATHEME"},{"av":"AV56SelectedBrandTheme","fld":"vSELECTEDBRANDTHEME"},{"av":"AV54WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV37OrganisationHasMyCare","fld":"vORGANISATIONHASMYCARE"},{"av":"AV38OrganisationHasMyLiving","fld":"vORGANISATIONHASMYLIVING"},{"av":"AV39OrganisationHasMyServices","fld":"vORGANISATIONHASMYSERVICES"},{"av":"AV36OrganisationHasDynamicForms","fld":"vORGANISATIONHASDYNAMICFORMS"},{"av":"AV63OrganisationHasOwnBrand","fld":"vORGANISATIONHASOWNBRAND"}]""");
         setEventMetadata("'WIZARDPREVIOUS'",""","oparms":[{"av":"AV58OrganisationCtaTheme","fld":"vORGANISATIONCTATHEME"},{"av":"AV34OrganisationBrandTheme","fld":"vORGANISATIONBRANDTHEME"},{"av":"AV55WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("'DOWIZARDFINISH'","""{"handler":"E17A52","iparms":[{"av":"AV13HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV57SelectedCtaTheme","fld":"vSELECTEDCTATHEME"},{"av":"AV56SelectedBrandTheme","fld":"vSELECTEDBRANDTHEME"},{"av":"AV54WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV37OrganisationHasMyCare","fld":"vORGANISATIONHASMYCARE"},{"av":"AV38OrganisationHasMyLiving","fld":"vORGANISATIONHASMYLIVING"},{"av":"AV39OrganisationHasMyServices","fld":"vORGANISATIONHASMYSERVICES"},{"av":"AV36OrganisationHasDynamicForms","fld":"vORGANISATIONHASDYNAMICFORMS"},{"av":"AV63OrganisationHasOwnBrand","fld":"vORGANISATIONHASOWNBRAND"},{"av":"AV66base64String","fld":"vBASE64STRING"},{"av":"AV55WizardData","fld":"vWIZARDDATA"},{"av":"AV14ImageFile","fld":"vIMAGEFILE"},{"av":"AV50Trn_Manager","fld":"vTRN_MANAGER"},{"av":"AV20isSuccessful","fld":"vISSUCCESSFUL"},{"av":"AV8ErrorMessages","fld":"vERRORMESSAGES"}]""");
         setEventMetadata("'DOWIZARDFINISH'",""","oparms":[{"av":"AV58OrganisationCtaTheme","fld":"vORGANISATIONCTATHEME"},{"av":"AV34OrganisationBrandTheme","fld":"vORGANISATIONBRANDTHEME"},{"av":"AV55WizardData","fld":"vWIZARDDATA"},{"av":"AV14ImageFile","fld":"vIMAGEFILE"},{"av":"AV8ErrorMessages","fld":"vERRORMESSAGES"},{"av":"AV50Trn_Manager","fld":"vTRN_MANAGER"},{"av":"AV20isSuccessful","fld":"vISSUCCESSFUL"}]}""");
         setEventMetadata("LOGOUPLOAD.ONUPLOAD","""{"handler":"E11A52","iparms":[{"av":"AV67FileUploadedData","fld":"vFILEUPLOADEDDATA"}]""");
         setEventMetadata("LOGOUPLOAD.ONUPLOAD",""","oparms":[{"av":"AV66base64String","fld":"vBASE64STRING"}]}""");
         setEventMetadata("LOGOUPLOAD.ONFAILEDUPLOAD","""{"handler":"E12A52","iparms":[]}""");
         setEventMetadata("LOGOUPLOAD.ONCLICKDELETE","""{"handler":"E13A52","iparms":[{"av":"Logoupload_Previewimagelink","ctrl":"LOGOUPLOAD","prop":"PreviewImageLink"},{"av":"AV68ImagePlaceholder","fld":"vIMAGEPLACEHOLDER","hsh":true},{"av":"AV67FileUploadedData","fld":"vFILEUPLOADEDDATA"}]}""");
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
         wcpOAV54WebSessionKey = "";
         wcpOAV47PreviousStep = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV68ImagePlaceholder = "";
         AV56SelectedBrandTheme = new SdtSDT_BrandThemeColors(context);
         AV57SelectedCtaTheme = new SdtSDT_CtaThemeColors(context);
         AV67FileUploadedData = new SdtSDT_AvatarUpload(context);
         AV66base64String = "";
         AV55WizardData = new SdtWP_CreateOrganisationAndManagerData(context);
         AV14ImageFile = "";
         AV50Trn_Manager = new SdtTrn_Manager(context);
         AV8ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         lblThemelabel_Jsonclick = "";
         ucThemeselector = new GXUserControl();
         lblCtatheme_Jsonclick = "";
         ucCalltoactionthemeselector = new GXUserControl();
         lblAvatarlabel_Jsonclick = "";
         ucLogoupload = new GXUserControl();
         ucBtnwizardprevious = new GXUserControl();
         ucBtnwizardfinish = new GXUserControl();
         ucComfirmdeletemodal = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV53WebSession = context.GetSession();
         AV34OrganisationBrandTheme = "";
         AV59DefaultBrandTheme = new SdtSDT_BrandThemeColors(context);
         AV58OrganisationCtaTheme = "";
         AV60DefaultCtaTheme = new SdtSDT_CtaThemeColors(context);
         AV51Trn_Organisation = new SdtTrn_Organisation(context);
         AV49SDT_Managers = new GXBaseCollection<SdtSDT_Managers_SDT_ManagersItem>( context, "SDT_ManagersItem", "Comforta_version2");
         AV48SDT_Manager = new SdtSDT_Managers_SDT_ManagersItem(context);
         AV71GXV2 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV7Error = new GeneXus.Utils.SdtMessages_Message(context);
         GXt_char1 = "";
         AV9GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV10GAMErrorItem = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV52Trn_OrganisationSetting = new SdtTrn_OrganisationSetting(context);
         AV64OrganisationLogo = "";
         AV74Organisationlogo_GXI = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV54WebSessionKey = "";
         sCtrlAV47PreviousStep = "";
         sCtrlAV12GoingBack = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wp_createorganisationandmanagerstep3__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wp_createorganisationandmanagerstep3__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_createorganisationandmanagerstep3__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short AV5count ;
      private short nGXWrapped ;
      private int divBrandtable_Visible ;
      private int divCtatable_Visible ;
      private int AV70GXV1 ;
      private int AV72GXV3 ;
      private int AV73GXV4 ;
      private int AV75GXV5 ;
      private int idxLst ;
      private string Logoupload_Previewimagelink ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
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
      private string Calltoactionthemeselector_Ctacolor1 ;
      private string Calltoactionthemeselector_Ctacolor2 ;
      private string Calltoactionthemeselector_Ctacolor3 ;
      private string Calltoactionthemeselector_Ctacolor4 ;
      private string Calltoactionthemeselector_Ctacolor5 ;
      private string Calltoactionthemeselector_Ctacolor6 ;
      private string Calltoactionthemeselector_Internalname ;
      private string divFieldavatartable_Internalname ;
      private string lblAvatarlabel_Internalname ;
      private string lblAvatarlabel_Jsonclick ;
      private string Logoupload_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnwizardprevious_Tooltiptext ;
      private string Btnwizardprevious_Caption ;
      private string Btnwizardprevious_Class ;
      private string Btnwizardprevious_Internalname ;
      private string Btnwizardfinish_Tooltiptext ;
      private string Btnwizardfinish_Caption ;
      private string Btnwizardfinish_Class ;
      private string Btnwizardfinish_Internalname ;
      private string Comfirmdeletemodal_Title ;
      private string Comfirmdeletemodal_Confirmationtext ;
      private string Comfirmdeletemodal_Yesbuttoncaption ;
      private string Comfirmdeletemodal_Nobuttoncaption ;
      private string Comfirmdeletemodal_Bodytype ;
      private string Comfirmdeletemodal_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string chkavOrganisationhasdynamicforms_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
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
      private string GXt_char1 ;
      private string sCtrlAV54WebSessionKey ;
      private string sCtrlAV47PreviousStep ;
      private string sCtrlAV12GoingBack ;
      private bool AV12GoingBack ;
      private bool wcpOAV12GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13HasValidationErrors ;
      private bool AV20isSuccessful ;
      private bool wbLoad ;
      private bool AV37OrganisationHasMyCare ;
      private bool AV38OrganisationHasMyLiving ;
      private bool AV39OrganisationHasMyServices ;
      private bool AV63OrganisationHasOwnBrand ;
      private bool AV36OrganisationHasDynamicForms ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV19isOrganisationInserted ;
      private bool AV18isManagerInserted ;
      private string AV68ImagePlaceholder ;
      private string AV66base64String ;
      private string AV34OrganisationBrandTheme ;
      private string AV58OrganisationCtaTheme ;
      private string AV54WebSessionKey ;
      private string AV47PreviousStep ;
      private string wcpOAV54WebSessionKey ;
      private string wcpOAV47PreviousStep ;
      private string AV74Organisationlogo_GXI ;
      private string AV64OrganisationLogo ;
      private string AV14ImageFile ;
      private GXUserControl ucThemeselector ;
      private GXUserControl ucCalltoactionthemeselector ;
      private GXUserControl ucLogoupload ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucBtnwizardfinish ;
      private GXUserControl ucComfirmdeletemodal ;
      private GXWebForm Form ;
      private IGxSession AV53WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavOrganisationhasmycare ;
      private GXCheckbox chkavOrganisationhasmyliving ;
      private GXCheckbox chkavOrganisationhasmyservices ;
      private GXCheckbox chkavOrganisationhasownbrand ;
      private GXCheckbox chkavOrganisationhasdynamicforms ;
      private SdtSDT_BrandThemeColors AV56SelectedBrandTheme ;
      private SdtSDT_CtaThemeColors AV57SelectedCtaTheme ;
      private SdtSDT_AvatarUpload AV67FileUploadedData ;
      private SdtWP_CreateOrganisationAndManagerData AV55WizardData ;
      private SdtTrn_Manager AV50Trn_Manager ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV8ErrorMessages ;
      private SdtSDT_BrandThemeColors AV59DefaultBrandTheme ;
      private SdtSDT_CtaThemeColors AV60DefaultCtaTheme ;
      private SdtTrn_Organisation AV51Trn_Organisation ;
      private GXBaseCollection<SdtSDT_Managers_SDT_ManagersItem> AV49SDT_Managers ;
      private SdtSDT_Managers_SDT_ManagersItem AV48SDT_Manager ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV71GXV2 ;
      private GeneXus.Utils.SdtMessages_Message AV7Error ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV9GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV10GAMErrorItem ;
      private SdtTrn_OrganisationSetting AV52Trn_OrganisationSetting ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wp_createorganisationandmanagerstep3__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wp_createorganisationandmanagerstep3__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wp_createorganisationandmanagerstep3__default : DataStoreHelperBase, IDataStoreHelper
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
