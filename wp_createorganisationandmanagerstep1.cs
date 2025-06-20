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
   public class wp_createorganisationandmanagerstep1 : GXWebComponent
   {
      public wp_createorganisationandmanagerstep1( )
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

      public wp_createorganisationandmanagerstep1( IGxContext context )
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
         this.AV6WebSessionKey = aP0_WebSessionKey;
         this.AV8PreviousStep = aP1_PreviousStep;
         this.AV7GoingBack = aP2_GoingBack;
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
                  AV6WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
                  AV8PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
                  AV7GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV6WebSessionKey,(string)AV8PreviousStep,(bool)AV7GoingBack});
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
            PA3Y2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavFilename_Enabled = 0;
               AssignProp(sPrefix, false, edtavFilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFilename_Enabled), 5, 0), true);
               WS3Y2( ) ;
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
            context.SendWebValue( context.GetMessage( "WP_Create Organisation And Manager Step1", "")) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
            GXEncryptionTmp = "wp_createorganisationandmanagerstep1.aspx"+UrlEncode(StringUtil.RTrim(AV6WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV8PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV7GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_createorganisationandmanagerstep1.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vORGANISATIONTYPEID_DATA", AV43OrganisationTypeId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vORGANISATIONTYPEID_DATA", AV43OrganisationTypeId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV29DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV29DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vORGANISATIONPHONECODE_DATA", AV39OrganisationPhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vORGANISATIONPHONECODE_DATA", AV39OrganisationPhoneCode_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vUPLOADEDFILES", AV47UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vUPLOADEDFILES", AV47UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFAILEDFILES", AV48FailedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFAILEDFILES", AV48FailedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vORGANISATIONADDRESSCOUNTRY_DATA", AV28OrganisationAddressCountry_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vORGANISATIONADDRESSCOUNTRY_DATA", AV28OrganisationAddressCountry_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6WebSessionKey", wcpOAV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PreviousStep", wcpOAV8PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV7GoingBack", wcpOAV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV7GoingBack);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV22CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV6WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"ORGANISATIONTYPENAME", A20OrganisationTypeName);
         GxWebStd.gx_hidden_field( context, sPrefix+"ORGANISATIONTYPEID", A19OrganisationTypeId.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV8PreviousStep);
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ORGANISATIONTYPEID_Ddointernalname", StringUtil.RTrim( Combo_organisationtypeid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ORGANISATIONADDRESSCOUNTRY_Ddointernalname", StringUtil.RTrim( Combo_organisationaddresscountry_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ORGANISATIONADDRESSCOUNTRY_Selectedvalue_get", StringUtil.RTrim( Combo_organisationaddresscountry_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ORGANISATIONPHONECODE_Selectedvalue_get", StringUtil.RTrim( Combo_organisationphonecode_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ORGANISATIONTYPEID_Selectedvalue_get", StringUtil.RTrim( Combo_organisationtypeid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ORGANISATIONTYPEID_Selectedtext_get", StringUtil.RTrim( Combo_organisationtypeid_Selectedtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ORGANISATIONTYPEID_Ddointernalname", StringUtil.RTrim( Combo_organisationtypeid_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ORGANISATIONADDRESSCOUNTRY_Ddointernalname", StringUtil.RTrim( Combo_organisationaddresscountry_Ddointernalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ORGANISATIONTYPEID_Selectedvalue_get", StringUtil.RTrim( Combo_organisationtypeid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_ORGANISATIONTYPEID_Selectedtext_get", StringUtil.RTrim( Combo_organisationtypeid_Selectedtext_get));
      }

      protected void RenderHtmlCloseForm3Y2( )
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
         return "WP_CreateOrganisationAndManagerStep1" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Create Organisation And Manager Step1", "") ;
      }

      protected void WB3Y0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wp_createorganisationandmanagerstep1.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Organisation Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOrganisationname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrganisationname_Internalname, context.GetMessage( "Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationname_Internalname, AV16OrganisationName, StringUtil.RTrim( context.localUtil.Format( AV16OrganisationName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOrganisationname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedorganisationtypeid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_organisationtypeid_Internalname, context.GetMessage( "Type", ""), "", "", lblTextblockcombo_organisationtypeid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_organisationtypeid.SetProperty("Caption", Combo_organisationtypeid_Caption);
            ucCombo_organisationtypeid.SetProperty("Cls", Combo_organisationtypeid_Cls);
            ucCombo_organisationtypeid.SetProperty("EmptyItem", Combo_organisationtypeid_Emptyitem);
            ucCombo_organisationtypeid.SetProperty("IncludeAddNewOption", Combo_organisationtypeid_Includeaddnewoption);
            ucCombo_organisationtypeid.SetProperty("DropDownOptionsData", AV43OrganisationTypeId_Data);
            ucCombo_organisationtypeid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_organisationtypeid_Internalname, sPrefix+"COMBO_ORGANISATIONTYPEIDContainer");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOrganisationkvknumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrganisationkvknumber_Internalname, context.GetMessage( "KvK Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationkvknumber_Internalname, AV15OrganisationKvkNumber, StringUtil.RTrim( context.localUtil.Format( AV15OrganisationKvkNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "12345678", edtavOrganisationkvknumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOrganisationkvknumber_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOrganisationvatnumber_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrganisationvatnumber_Internalname, context.GetMessage( "VAT Number", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationvatnumber_Internalname, AV19OrganisationVATNumber, StringUtil.RTrim( context.localUtil.Format( AV19OrganisationVATNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "NL123456789B01", ""), edtavOrganisationvatnumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOrganisationvatnumber_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOrganisationemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrganisationemail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationemail_Internalname, AV13OrganisationEmail, StringUtil.RTrim( context.localUtil.Format( AV13OrganisationEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "johndoe@gmail.com", ""), edtavOrganisationemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOrganisationemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "CellMarginBottom10", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPhonelabel_Internalname, context.GetMessage( "Phone", ""), "", "", lblPhonelabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable7_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable8_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 PhoneLabel ExtendedComboCell", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_organisationphonecode.SetProperty("Caption", Combo_organisationphonecode_Caption);
            ucCombo_organisationphonecode.SetProperty("Cls", Combo_organisationphonecode_Cls);
            ucCombo_organisationphonecode.SetProperty("EmptyItem", Combo_organisationphonecode_Emptyitem);
            ucCombo_organisationphonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV29DDO_TitleSettingsIcons);
            ucCombo_organisationphonecode.SetProperty("DropDownOptionsData", AV39OrganisationPhoneCode_Data);
            ucCombo_organisationphonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_organisationphonecode_Internalname, sPrefix+"COMBO_ORGANISATIONPHONECODEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable9_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrganisationphonenumber_Internalname, context.GetMessage( "Organisation Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationphonenumber_Internalname, AV41OrganisationPhoneNumber, StringUtil.RTrim( context.localUtil.Format( AV41OrganisationPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationphonenumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOrganisationphonenumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, divUnnamedtable6_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUploadlogotext_Internalname, context.GetMessage( "Logo", ""), "", "", lblUploadlogotext_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUcfilecell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-lg-5", "start", "top", "", "", "div");
            wb_table1_75_3Y2( true) ;
         }
         else
         {
            wb_table1_75_3Y2( false) ;
         }
         return  ;
      }

      protected void wb_table1_75_3Y2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, context.GetMessage( "Address Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOrganisationaddressline1_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrganisationaddressline1_Internalname, context.GetMessage( "Address Line 1", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationaddressline1_Internalname, AV34OrganisationAddressLine1, StringUtil.RTrim( context.localUtil.Format( AV34OrganisationAddressLine1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationaddressline1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOrganisationaddressline1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOrganisationaddressline2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrganisationaddressline2_Internalname, context.GetMessage( "Address Line 2", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationaddressline2_Internalname, AV35OrganisationAddressLine2, StringUtil.RTrim( context.localUtil.Format( AV35OrganisationAddressLine2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationaddressline2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOrganisationaddressline2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOrganisationaddresszipcode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrganisationaddresszipcode_Internalname, context.GetMessage( "Zip Code", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationaddresszipcode_Internalname, AV26OrganisationAddressZipCode, StringUtil.RTrim( context.localUtil.Format( AV26OrganisationAddressZipCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "1234 AB", ""), edtavOrganisationaddresszipcode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOrganisationaddresszipcode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavOrganisationaddresscity_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrganisationaddresscity_Internalname, context.GetMessage( "City", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationaddresscity_Internalname, AV23OrganisationAddressCity, StringUtil.RTrim( context.localUtil.Format( AV23OrganisationAddressCity, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationaddresscity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavOrganisationaddresscity_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell ExtendedComboCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedorganisationaddresscountry_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockcombo_organisationaddresscountry_Internalname, context.GetMessage( "Country", ""), "", "", lblTextblockcombo_organisationaddresscountry_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_organisationaddresscountry.SetProperty("Caption", Combo_organisationaddresscountry_Caption);
            ucCombo_organisationaddresscountry.SetProperty("Cls", Combo_organisationaddresscountry_Cls);
            ucCombo_organisationaddresscountry.SetProperty("EmptyItem", Combo_organisationaddresscountry_Emptyitem);
            ucCombo_organisationaddresscountry.SetProperty("DropDownOptionsTitleSettingsIcons", AV29DDO_TitleSettingsIcons);
            ucCombo_organisationaddresscountry.SetProperty("DropDownOptionsData", AV28OrganisationAddressCountry_Data);
            ucCombo_organisationaddresscountry.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_organisationaddresscountry_Internalname, sPrefix+"COMBO_ORGANISATIONADDRESSCOUNTRYContainer");
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
            ucBtnwizardfirstprevious.SetProperty("TooltipText", Btnwizardfirstprevious_Tooltiptext);
            ucBtnwizardfirstprevious.SetProperty("Caption", Btnwizardfirstprevious_Caption);
            ucBtnwizardfirstprevious.SetProperty("Class", Btnwizardfirstprevious_Class);
            ucBtnwizardfirstprevious.Render(context, "wwp_iconbutton", Btnwizardfirstprevious_Internalname, sPrefix+"BTNWIZARDFIRSTPREVIOUSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucBtnwizardnext.SetProperty("TooltipText", Btnwizardnext_Tooltiptext);
            ucBtnwizardnext.SetProperty("Caption", Btnwizardnext_Caption);
            ucBtnwizardnext.SetProperty("Class", Btnwizardnext_Class);
            ucBtnwizardnext.Render(context, "wwp_iconbutton", Btnwizardnext_Internalname, sPrefix+"BTNWIZARDNEXTContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationtypeid_Internalname, AV21OrganisationTypeId.ToString(), AV21OrganisationTypeId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,125);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationtypeid_Jsonclick, 0, "Attribute", "", "", "", "", edtavOrganisationtypeid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationphonecode_Internalname, AV38OrganisationPhoneCode, StringUtil.RTrim( context.localUtil.Format( AV38OrganisationPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationphonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavOrganisationphonecode_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationaddresscountry_Internalname, AV27OrganisationAddressCountry, StringUtil.RTrim( context.localUtil.Format( AV27OrganisationAddressCountry, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,127);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationaddresscountry_Jsonclick, 0, "Attribute", "", "", "", "", edtavOrganisationaddresscountry_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationid_Internalname, AV14OrganisationId.ToString(), AV14OrganisationId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,128);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationid_Jsonclick, 0, "Attribute", "", "", "", "", edtavOrganisationid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrganisationphone_Internalname, StringUtil.RTrim( AV17OrganisationPhone), StringUtil.RTrim( context.localUtil.Format( AV17OrganisationPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrganisationphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavOrganisationphone_Visible, 1, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavOrganisationlogovar_Internalname, AV50OrganisationLogoVar, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,130);\"", 0, edtavOrganisationlogovar_Visible, 1, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START3Y2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WP_Create Organisation And Manager Step1", ""), 0) ;
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
               STRUP3Y0( ) ;
            }
         }
      }

      protected void WS3Y2( )
      {
         START3Y2( ) ;
         EVT3Y2( ) ;
      }

      protected void EVT3Y2( )
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
                                 STRUP3Y0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "COMBO_ORGANISATIONTYPEID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Combo_organisationtypeid.Onoptionclicked */
                                    E113Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E123Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E133Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
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
                                          E143Y2 ();
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
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E153Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VORGANISATIONVATNUMBER.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E163Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VORGANISATIONEMAIL.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E173Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VORGANISATIONKVKNUMBER.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E183Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VORGANISATIONADDRESSZIPCODE.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E193Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VORGANISATIONPHONENUMBER.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E203Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILENAME.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E213Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E223Y2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavOrganisationname_Internalname;
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

      protected void WE3Y2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3Y2( ) ;
            }
         }
      }

      protected void PA3Y2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_createorganisationandmanagerstep1.aspx")), "wp_createorganisationandmanagerstep1.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_createorganisationandmanagerstep1.aspx")))) ;
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
               GX_FocusControl = edtavOrganisationname_Internalname;
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavFilename_Enabled = 0;
         AssignProp(sPrefix, false, edtavFilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFilename_Enabled), 5, 0), true);
      }

      protected void RF3Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E133Y2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E223Y2 ();
            WB3Y0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3Y2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV10HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV10HasValidationErrors, context));
      }

      protected void before_start_formulas( )
      {
         edtavFilename_Enabled = 0;
         AssignProp(sPrefix, false, edtavFilename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFilename_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E123Y2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vORGANISATIONTYPEID_DATA"), AV43OrganisationTypeId_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV29DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vORGANISATIONPHONECODE_DATA"), AV39OrganisationPhoneCode_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vUPLOADEDFILES"), AV47UploadedFiles);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFAILEDFILES"), AV48FailedFiles);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vORGANISATIONADDRESSCOUNTRY_DATA"), AV28OrganisationAddressCountry_Data);
            /* Read saved values. */
            wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
            wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
            wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
            Combo_organisationtypeid_Ddointernalname = cgiGet( sPrefix+"COMBO_ORGANISATIONTYPEID_Ddointernalname");
            Combo_organisationaddresscountry_Ddointernalname = cgiGet( sPrefix+"COMBO_ORGANISATIONADDRESSCOUNTRY_Ddointernalname");
            Combo_organisationtypeid_Selectedvalue_get = cgiGet( sPrefix+"COMBO_ORGANISATIONTYPEID_Selectedvalue_get");
            Combo_organisationtypeid_Selectedtext_get = cgiGet( sPrefix+"COMBO_ORGANISATIONTYPEID_Selectedtext_get");
            /* Read variables values. */
            AV16OrganisationName = cgiGet( edtavOrganisationname_Internalname);
            AssignAttri(sPrefix, false, "AV16OrganisationName", AV16OrganisationName);
            AV15OrganisationKvkNumber = cgiGet( edtavOrganisationkvknumber_Internalname);
            AssignAttri(sPrefix, false, "AV15OrganisationKvkNumber", AV15OrganisationKvkNumber);
            AV19OrganisationVATNumber = cgiGet( edtavOrganisationvatnumber_Internalname);
            AssignAttri(sPrefix, false, "AV19OrganisationVATNumber", AV19OrganisationVATNumber);
            AV13OrganisationEmail = cgiGet( edtavOrganisationemail_Internalname);
            AssignAttri(sPrefix, false, "AV13OrganisationEmail", AV13OrganisationEmail);
            AV41OrganisationPhoneNumber = cgiGet( edtavOrganisationphonenumber_Internalname);
            AssignAttri(sPrefix, false, "AV41OrganisationPhoneNumber", AV41OrganisationPhoneNumber);
            AV46FileName = cgiGet( edtavFilename_Internalname);
            AssignAttri(sPrefix, false, "AV46FileName", AV46FileName);
            AV34OrganisationAddressLine1 = cgiGet( edtavOrganisationaddressline1_Internalname);
            AssignAttri(sPrefix, false, "AV34OrganisationAddressLine1", AV34OrganisationAddressLine1);
            AV35OrganisationAddressLine2 = cgiGet( edtavOrganisationaddressline2_Internalname);
            AssignAttri(sPrefix, false, "AV35OrganisationAddressLine2", AV35OrganisationAddressLine2);
            AV26OrganisationAddressZipCode = cgiGet( edtavOrganisationaddresszipcode_Internalname);
            AssignAttri(sPrefix, false, "AV26OrganisationAddressZipCode", AV26OrganisationAddressZipCode);
            AV23OrganisationAddressCity = cgiGet( edtavOrganisationaddresscity_Internalname);
            AssignAttri(sPrefix, false, "AV23OrganisationAddressCity", AV23OrganisationAddressCity);
            if ( StringUtil.StrCmp(cgiGet( edtavOrganisationtypeid_Internalname), "") == 0 )
            {
               AV21OrganisationTypeId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV21OrganisationTypeId", AV21OrganisationTypeId.ToString());
            }
            else
            {
               try
               {
                  AV21OrganisationTypeId = StringUtil.StrToGuid( cgiGet( edtavOrganisationtypeid_Internalname));
                  AssignAttri(sPrefix, false, "AV21OrganisationTypeId", AV21OrganisationTypeId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vORGANISATIONTYPEID");
                  GX_FocusControl = edtavOrganisationtypeid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV38OrganisationPhoneCode = cgiGet( edtavOrganisationphonecode_Internalname);
            AssignAttri(sPrefix, false, "AV38OrganisationPhoneCode", AV38OrganisationPhoneCode);
            AV27OrganisationAddressCountry = cgiGet( edtavOrganisationaddresscountry_Internalname);
            AssignAttri(sPrefix, false, "AV27OrganisationAddressCountry", AV27OrganisationAddressCountry);
            if ( StringUtil.StrCmp(cgiGet( edtavOrganisationid_Internalname), "") == 0 )
            {
               AV14OrganisationId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV14OrganisationId", AV14OrganisationId.ToString());
            }
            else
            {
               try
               {
                  AV14OrganisationId = StringUtil.StrToGuid( cgiGet( edtavOrganisationid_Internalname));
                  AssignAttri(sPrefix, false, "AV14OrganisationId", AV14OrganisationId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vORGANISATIONID");
                  GX_FocusControl = edtavOrganisationid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV17OrganisationPhone = cgiGet( edtavOrganisationphone_Internalname);
            AssignAttri(sPrefix, false, "AV17OrganisationPhone", AV17OrganisationPhone);
            AV50OrganisationLogoVar = cgiGet( edtavOrganisationlogovar_Internalname);
            AssignAttri(sPrefix, false, "AV50OrganisationLogoVar", AV50OrganisationLogoVar);
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
         E123Y2 ();
         if (returnInSub) return;
      }

      protected void E123Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV29DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV29DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavOrganisationaddresscountry_Visible = 0;
         AssignProp(sPrefix, false, edtavOrganisationaddresscountry_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOrganisationaddresscountry_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_organisationaddresscountry_Htmltemplate = GXt_char2;
         ucCombo_organisationaddresscountry.SendProperty(context, sPrefix, false, Combo_organisationaddresscountry_Internalname, "HTMLTemplate", Combo_organisationaddresscountry_Htmltemplate);
         edtavOrganisationphonecode_Visible = 0;
         AssignProp(sPrefix, false, edtavOrganisationphonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOrganisationphonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_organisationphonecode_Htmltemplate = GXt_char2;
         ucCombo_organisationphonecode.SendProperty(context, sPrefix, false, Combo_organisationphonecode_Internalname, "HTMLTemplate", Combo_organisationphonecode_Htmltemplate);
         edtavOrganisationtypeid_Visible = 0;
         AssignProp(sPrefix, false, edtavOrganisationtypeid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOrganisationtypeid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOORGANISATIONTYPEID' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOORGANISATIONPHONECODE' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADCOMBOORGANISATIONADDRESSCOUNTRY' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S152 ();
         if (returnInSub) return;
         edtavOrganisationid_Visible = 0;
         AssignProp(sPrefix, false, edtavOrganisationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOrganisationid_Visible), 5, 0), true);
         edtavOrganisationphone_Visible = 0;
         AssignProp(sPrefix, false, edtavOrganisationphone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOrganisationphone_Visible), 5, 0), true);
         edtavOrganisationlogovar_Visible = 0;
         AssignProp(sPrefix, false, edtavOrganisationlogovar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOrganisationlogovar_Visible), 5, 0), true);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27OrganisationAddressCountry)) )
         {
            AV36defaultCountry = "Netherlands";
            Combo_organisationaddresscountry_Selectedtext_set = AV36defaultCountry;
            ucCombo_organisationaddresscountry.SendProperty(context, sPrefix, false, Combo_organisationaddresscountry_Internalname, "SelectedText_set", Combo_organisationaddresscountry_Selectedtext_set);
            Combo_organisationaddresscountry_Selectedvalue_set = AV36defaultCountry;
            ucCombo_organisationaddresscountry.SendProperty(context, sPrefix, false, Combo_organisationaddresscountry_Internalname, "SelectedValue_set", Combo_organisationaddresscountry_Selectedvalue_set);
            AV27OrganisationAddressCountry = AV36defaultCountry;
            AssignAttri(sPrefix, false, "AV27OrganisationAddressCountry", AV27OrganisationAddressCountry);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38OrganisationPhoneCode)) )
         {
            AV37defaultCountryPhoneCode = "+31";
            AV38OrganisationPhoneCode = "+31";
            AssignAttri(sPrefix, false, "AV38OrganisationPhoneCode", AV38OrganisationPhoneCode);
            Combo_organisationphonecode_Selectedtext_set = AV37defaultCountryPhoneCode;
            ucCombo_organisationphonecode.SendProperty(context, sPrefix, false, Combo_organisationphonecode_Internalname, "SelectedText_set", Combo_organisationphonecode_Selectedtext_set);
            Combo_organisationphonecode_Selectedvalue_set = AV37defaultCountryPhoneCode;
            ucCombo_organisationphonecode.SendProperty(context, sPrefix, false, Combo_organisationphonecode_Internalname, "SelectedValue_set", Combo_organisationphonecode_Selectedvalue_set);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50OrganisationLogoVar)) )
         {
            lblUseractiondelete_Visible = 0;
            AssignProp(sPrefix, false, lblUseractiondelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblUseractiondelete_Visible), 5, 0), true);
         }
         else
         {
            lblUseractiondelete_Visible = 1;
            AssignProp(sPrefix, false, lblUseractiondelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblUseractiondelete_Visible), 5, 0), true);
            edtavFilename_Visible = 1;
            AssignProp(sPrefix, false, edtavFilename_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFilename_Visible), 5, 0), true);
         }
      }

      protected void E133Y2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         AV7GoingBack = false;
         AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E143Y2 ();
         if (returnInSub) return;
      }

      protected void E143Y2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S172 ();
         if (returnInSub) return;
         if ( AV22CheckRequiredFieldsResult && ! AV10HasValidationErrors )
         {
            /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
            S182 ();
            if (returnInSub) return;
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_createorganisationandmanager.aspx"+UrlEncode(StringUtil.RTrim("Step1")) + "," + UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.BoolToStr(false));
            CallWebObject(formatLink("wp_createorganisationandmanager.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
      }

      protected void E153Y2( )
      {
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         CallWebObject(formatLink("trn_organisationww.aspx") );
         context.wjLocDisableFrm = 1;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E113Y2( )
      {
         /* Combo_organisationtypeid_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Combo_organisationtypeid_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            AV45DefaultOrganisationTypeName = Combo_organisationtypeid_Selectedtext_get;
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_createneworganisationtype.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(AV21OrganisationTypeId.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV45DefaultOrganisationTypeName));
            context.PopUp(formatLink("wp_createneworganisationtype.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_organisationtypeid_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOORGANISATIONTYPEID' */
            S122 ();
            if (returnInSub) return;
            AV30ComboSelectedValue = AV44Session.Get("ORGANISATIONTYPEID");
            AV44Session.Remove("ORGANISATIONTYPEID");
            Combo_organisationtypeid_Selectedvalue_set = AV30ComboSelectedValue;
            ucCombo_organisationtypeid.SendProperty(context, sPrefix, false, Combo_organisationtypeid_Internalname, "SelectedValue_set", Combo_organisationtypeid_Selectedvalue_set);
            AV21OrganisationTypeId = StringUtil.StrToGuid( AV30ComboSelectedValue);
            AssignAttri(sPrefix, false, "AV21OrganisationTypeId", AV21OrganisationTypeId.ToString());
         }
         else
         {
            AV21OrganisationTypeId = StringUtil.StrToGuid( Combo_organisationtypeid_Selectedvalue_get);
            AssignAttri(sPrefix, false, "AV21OrganisationTypeId", AV21OrganisationTypeId.ToString());
            /* Execute user subroutine: 'LOADCOMBOORGANISATIONTYPEID' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV43OrganisationTypeId_Data", AV43OrganisationTypeId_Data);
      }

      protected void S162( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ! AV7GoingBack ) )
         {
            Btnwizardfirstprevious_Visible = false;
            ucBtnwizardfirstprevious.SendProperty(context, sPrefix, false, Btnwizardfirstprevious_Internalname, "Visible", StringUtil.BoolToStr( Btnwizardfirstprevious_Visible));
         }
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV34OrganisationAddressLine1 = AV11WizardData.gxTpr_Step1.gxTpr_Organisationaddressline1;
         AssignAttri(sPrefix, false, "AV34OrganisationAddressLine1", AV34OrganisationAddressLine1);
         AV35OrganisationAddressLine2 = AV11WizardData.gxTpr_Step1.gxTpr_Organisationaddressline2;
         AssignAttri(sPrefix, false, "AV35OrganisationAddressLine2", AV35OrganisationAddressLine2);
         AV26OrganisationAddressZipCode = AV11WizardData.gxTpr_Step1.gxTpr_Organisationaddresszipcode;
         AssignAttri(sPrefix, false, "AV26OrganisationAddressZipCode", AV26OrganisationAddressZipCode);
         AV23OrganisationAddressCity = AV11WizardData.gxTpr_Step1.gxTpr_Organisationaddresscity;
         AssignAttri(sPrefix, false, "AV23OrganisationAddressCity", AV23OrganisationAddressCity);
         AV27OrganisationAddressCountry = AV11WizardData.gxTpr_Step1.gxTpr_Organisationaddresscountry;
         AssignAttri(sPrefix, false, "AV27OrganisationAddressCountry", AV27OrganisationAddressCountry);
         AV14OrganisationId = AV11WizardData.gxTpr_Step1.gxTpr_Organisationid;
         AssignAttri(sPrefix, false, "AV14OrganisationId", AV14OrganisationId.ToString());
         AV16OrganisationName = AV11WizardData.gxTpr_Step1.gxTpr_Organisationname;
         AssignAttri(sPrefix, false, "AV16OrganisationName", AV16OrganisationName);
         AV21OrganisationTypeId = AV11WizardData.gxTpr_Step1.gxTpr_Organisationtypeid;
         AssignAttri(sPrefix, false, "AV21OrganisationTypeId", AV21OrganisationTypeId.ToString());
         AV15OrganisationKvkNumber = AV11WizardData.gxTpr_Step1.gxTpr_Organisationkvknumber;
         AssignAttri(sPrefix, false, "AV15OrganisationKvkNumber", AV15OrganisationKvkNumber);
         AV19OrganisationVATNumber = AV11WizardData.gxTpr_Step1.gxTpr_Organisationvatnumber;
         AssignAttri(sPrefix, false, "AV19OrganisationVATNumber", AV19OrganisationVATNumber);
         AV13OrganisationEmail = AV11WizardData.gxTpr_Step1.gxTpr_Organisationemail;
         AssignAttri(sPrefix, false, "AV13OrganisationEmail", AV13OrganisationEmail);
         AV17OrganisationPhone = AV11WizardData.gxTpr_Step1.gxTpr_Organisationphone;
         AssignAttri(sPrefix, false, "AV17OrganisationPhone", AV17OrganisationPhone);
         AV50OrganisationLogoVar = AV11WizardData.gxTpr_Step1.gxTpr_Organisationlogovar;
         AssignAttri(sPrefix, false, "AV50OrganisationLogoVar", AV50OrganisationLogoVar);
         AV46FileName = AV11WizardData.gxTpr_Step1.gxTpr_Filename;
         AssignAttri(sPrefix, false, "AV46FileName", AV46FileName);
         AV41OrganisationPhoneNumber = AV11WizardData.gxTpr_Step1.gxTpr_Organisationphonenumber;
         AssignAttri(sPrefix, false, "AV41OrganisationPhoneNumber", AV41OrganisationPhoneNumber);
         AV38OrganisationPhoneCode = AV11WizardData.gxTpr_Step1.gxTpr_Organisationphonecode;
         AssignAttri(sPrefix, false, "AV38OrganisationPhoneCode", AV38OrganisationPhoneCode);
      }

      protected void S182( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         if ( AV47UploadedFiles.Count > 0 )
         {
            AV50OrganisationLogoVar = context.FileToBase64( ((SdtFileUploadData)AV47UploadedFiles.Item(1)).gxTpr_File);
            AssignAttri(sPrefix, false, "AV50OrganisationLogoVar", AV50OrganisationLogoVar);
            AV46FileName = ((SdtFileUploadData)AV47UploadedFiles.Item(1)).gxTpr_Fullname;
            AssignAttri(sPrefix, false, "AV46FileName", AV46FileName);
            AV51Filetype = ((SdtFileUploadData)AV47UploadedFiles.Item(1)).gxTpr_Extension;
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50OrganisationLogoVar)) )
            {
               AV50OrganisationLogoVar = "";
               AssignAttri(sPrefix, false, "AV50OrganisationLogoVar", AV50OrganisationLogoVar);
               AV46FileName = "";
               AssignAttri(sPrefix, false, "AV46FileName", AV46FileName);
            }
            else
            {
               AssignAttri(sPrefix, false, "AV50OrganisationLogoVar", AV50OrganisationLogoVar);
               AssignAttri(sPrefix, false, "AV46FileName", AV46FileName);
            }
         }
         AV14OrganisationId = Guid.NewGuid( );
         AssignAttri(sPrefix, false, "AV14OrganisationId", AV14OrganisationId.ToString());
         GXt_char2 = AV17OrganisationPhone;
         new prc_concatenateintlphone(context ).execute(  AV38OrganisationPhoneCode,  AV41OrganisationPhoneNumber, out  GXt_char2) ;
         AV17OrganisationPhone = GXt_char2;
         AssignAttri(sPrefix, false, "AV17OrganisationPhone", AV17OrganisationPhone);
         AV11WizardData.FromJSonString(AV5WebSession.Get(AV6WebSessionKey), null);
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationaddressline1 = AV34OrganisationAddressLine1;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationaddressline2 = AV35OrganisationAddressLine2;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationaddresszipcode = AV26OrganisationAddressZipCode;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationaddresscity = AV23OrganisationAddressCity;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationaddresscountry = AV27OrganisationAddressCountry;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationid = AV14OrganisationId;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationname = AV16OrganisationName;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationtypeid = AV21OrganisationTypeId;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationkvknumber = AV15OrganisationKvkNumber;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationvatnumber = AV19OrganisationVATNumber;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationemail = AV13OrganisationEmail;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationphone = AV17OrganisationPhone;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationlogovar = AV50OrganisationLogoVar;
         AV11WizardData.gxTpr_Step1.gxTpr_Filename = AV46FileName;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationphonenumber = AV41OrganisationPhoneNumber;
         AV11WizardData.gxTpr_Step1.gxTpr_Organisationphonecode = AV38OrganisationPhoneCode;
         AV5WebSession.Set(AV6WebSessionKey, AV11WizardData.ToJSonString(false, true));
      }

      protected void S172( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV22CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16OrganisationName)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavOrganisationname_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( (Guid.Empty==AV21OrganisationTypeId) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Type", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_organisationtypeid_Ddointernalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15OrganisationKvkNumber)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "KvK Number", ""), "", "", "", "", "", "", "", ""),  "error",  edtavOrganisationkvknumber_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19OrganisationVATNumber)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "VAT Number", ""), "", "", "", "", "", "", "", ""),  "error",  edtavOrganisationvatnumber_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13OrganisationEmail)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""),  "error",  edtavOrganisationemail_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV34OrganisationAddressLine1)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Address Line 1", ""), "", "", "", "", "", "", "", ""),  "error",  edtavOrganisationaddressline1_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26OrganisationAddressZipCode)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Zip Code", ""), "", "", "", "", "", "", "", ""),  "error",  edtavOrganisationaddresszipcode_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23OrganisationAddressCity)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "City", ""), "", "", "", "", "", "", "", ""),  "error",  edtavOrganisationaddresscity_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27OrganisationAddressCountry)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Country", ""), "", "", "", "", "", "", "", ""),  "error",  Combo_organisationaddresscountry_Ddointernalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
      }

      protected void S152( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         divUnnamedtable6_Visible = (((1==0)) ? 1 : 0);
         AssignProp(sPrefix, false, divUnnamedtable6_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUnnamedtable6_Visible), 5, 0), true);
      }

      protected void S142( )
      {
         /* 'LOADCOMBOORGANISATIONADDRESSCOUNTRY' Routine */
         returnInSub = false;
         AV53GXV2 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV52GXV1;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV52GXV1 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV53GXV2 <= AV52GXV1.Count )
         {
            AV32OrganisationAddressCountry_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV52GXV1.Item(AV53GXV2));
            AV31Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV31Combo_DataItem.gxTpr_Id = AV32OrganisationAddressCountry_DPItem.gxTpr_Countryname;
            AV33ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV33ComboTitles.Add(AV32OrganisationAddressCountry_DPItem.gxTpr_Countryname, 0);
            AV33ComboTitles.Add(AV32OrganisationAddressCountry_DPItem.gxTpr_Countryflag, 0);
            AV31Combo_DataItem.gxTpr_Title = AV33ComboTitles.ToJSonString(false);
            AV28OrganisationAddressCountry_Data.Add(AV31Combo_DataItem, 0);
            AV53GXV2 = (int)(AV53GXV2+1);
         }
         AV28OrganisationAddressCountry_Data.Sort("Title");
         Combo_organisationaddresscountry_Selectedvalue_set = AV27OrganisationAddressCountry;
         ucCombo_organisationaddresscountry.SendProperty(context, sPrefix, false, Combo_organisationaddresscountry_Internalname, "SelectedValue_set", Combo_organisationaddresscountry_Selectedvalue_set);
      }

      protected void S132( )
      {
         /* 'LOADCOMBOORGANISATIONPHONECODE' Routine */
         returnInSub = false;
         AV55GXV4 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV54GXV3;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV54GXV3 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV55GXV4 <= AV54GXV3.Count )
         {
            AV40OrganisationPhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV54GXV3.Item(AV55GXV4));
            AV31Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV31Combo_DataItem.gxTpr_Id = AV40OrganisationPhoneCode_DPItem.gxTpr_Countrydialcode;
            AV33ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV33ComboTitles.Add(AV40OrganisationPhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV33ComboTitles.Add(AV40OrganisationPhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV31Combo_DataItem.gxTpr_Title = AV33ComboTitles.ToJSonString(false);
            AV39OrganisationPhoneCode_Data.Add(AV31Combo_DataItem, 0);
            AV55GXV4 = (int)(AV55GXV4+1);
         }
         AV39OrganisationPhoneCode_Data.Sort("Title");
         Combo_organisationphonecode_Selectedvalue_set = AV38OrganisationPhoneCode;
         ucCombo_organisationphonecode.SendProperty(context, sPrefix, false, Combo_organisationphonecode_Internalname, "SelectedValue_set", Combo_organisationphonecode_Selectedvalue_set);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOORGANISATIONTYPEID' Routine */
         returnInSub = false;
         AV43OrganisationTypeId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         GXt_boolean4 = false;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "<Check_Is_Authenticated>", out  GXt_boolean4) ;
         Combo_organisationtypeid_Includeaddnewoption = GXt_boolean4;
         ucCombo_organisationtypeid.SendProperty(context, sPrefix, false, Combo_organisationtypeid_Internalname, "IncludeAddNewOption", StringUtil.BoolToStr( Combo_organisationtypeid_Includeaddnewoption));
         /* Using cursor H003Y2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A19OrganisationTypeId = H003Y2_A19OrganisationTypeId[0];
            A20OrganisationTypeName = H003Y2_A20OrganisationTypeName[0];
            AV31Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV31Combo_DataItem.gxTpr_Id = StringUtil.Trim( A19OrganisationTypeId.ToString());
            AV31Combo_DataItem.gxTpr_Title = A20OrganisationTypeName;
            AV43OrganisationTypeId_Data.Add(AV31Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         Combo_organisationtypeid_Selectedvalue_set = ((Guid.Empty==AV21OrganisationTypeId) ? "" : StringUtil.Trim( AV21OrganisationTypeId.ToString()));
         ucCombo_organisationtypeid.SendProperty(context, sPrefix, false, Combo_organisationtypeid_Internalname, "SelectedValue_set", Combo_organisationtypeid_Selectedvalue_set);
      }

      protected void E163Y2( )
      {
         /* Organisationvatnumber_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! GxRegex.IsMatch(AV19OrganisationVATNumber,context.GetMessage( "[A-Za-z]{2}\\d{9}[A-Za-z]\\d{2}", "")) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "VAT is incorrect", ""),  "error",  edtavOrganisationvatnumber_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void E173Y2( )
      {
         /* Organisationemail_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! GxRegex.IsMatch(AV13OrganisationEmail,context.GetMessage( "^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$", "")) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "Email is incorrect", ""),  "error",  edtavOrganisationemail_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void E183Y2( )
      {
         /* Organisationkvknumber_Controlvaluechanged Routine */
         returnInSub = false;
         if ( StringUtil.Len( AV15OrganisationKvkNumber) != 8 )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "KVK is 8 digits long", ""),  "error",  edtavOrganisationkvknumber_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void E193Y2( )
      {
         /* Organisationaddresszipcode_Controlvaluechanged Routine */
         returnInSub = false;
         AV26OrganisationAddressZipCode = StringUtil.Upper( AV26OrganisationAddressZipCode);
         AssignAttri(sPrefix, false, "AV26OrganisationAddressZipCode", AV26OrganisationAddressZipCode);
         if ( ! GxRegex.IsMatch(AV26OrganisationAddressZipCode,context.GetMessage( "^\\d{4}\\s?[A-Z]{2}$", "")) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "Zip Code is incorrect", ""),  "error",  edtavOrganisationaddresszipcode_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void E203Y2( )
      {
         /* Organisationphonenumber_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! GxRegex.IsMatch(AV41OrganisationPhoneNumber,context.GetMessage( "\\b\\d{9}\\b", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV41OrganisationPhoneNumber)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "Phone contains 9 digits", ""),  "error",  edtavOrganisationphonenumber_Internalname,  "true",  ""));
            AV22CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV22CheckRequiredFieldsResult", AV22CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void E213Y2( )
      {
         /* Filename_Controlvaluechanged Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV46FileName)) )
         {
            this.executeUsercontrolMethod(sPrefix, false, "USERCONTROLLOGOContainer", "Clear", "", new Object[] {});
            context.DoAjaxRefreshCmp(sPrefix);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E223Y2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_75_3Y2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedusercontrollogo_Internalname, tblTablemergedusercontrollogo_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* User Defined Control */
            ucUsercontrollogo.SetProperty("AutoUpload", Usercontrollogo_Autoupload);
            ucUsercontrollogo.SetProperty("HideAdditionalButtons", Usercontrollogo_Hideadditionalbuttons);
            ucUsercontrollogo.SetProperty("TooltipText", Usercontrollogo_Tooltiptext);
            ucUsercontrollogo.SetProperty("EnableUploadedFileCanceling", Usercontrollogo_Enableuploadedfilecanceling);
            ucUsercontrollogo.SetProperty("DisableImageResize", Usercontrollogo_Disableimageresize);
            ucUsercontrollogo.SetProperty("MaxFileSize", Usercontrollogo_Maxfilesize);
            ucUsercontrollogo.SetProperty("MaxNumberOfFiles", Usercontrollogo_Maxnumberoffiles);
            ucUsercontrollogo.SetProperty("AutoDisableAddingFiles", Usercontrollogo_Autodisableaddingfiles);
            ucUsercontrollogo.SetProperty("AcceptedFileTypes", Usercontrollogo_Acceptedfiletypes);
            ucUsercontrollogo.SetProperty("UploadedFiles", AV47UploadedFiles);
            ucUsercontrollogo.SetProperty("FailedFiles", AV48FailedFiles);
            ucUsercontrollogo.Render(context, "fileupload", Usercontrollogo_Internalname, sPrefix+"USERCONTROLLOGOContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DataContentCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilename_Internalname, context.GetMessage( "File Name", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilename_Internalname, AV46FileName, StringUtil.RTrim( context.localUtil.Format( AV46FileName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilename_Jsonclick, 0, "Attribute", "", "", "", "", edtavFilename_Visible, edtavFilename_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUseractiondelete_Internalname, context.GetMessage( "<i class=\"fas fa-trash-can\"></i>", ""), "", "", lblUseractiondelete_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e233y1_client"+"'", "", "TextBlock", 7, "", lblUseractiondelete_Visible, 1, 0, 1, "HLP_WP_CreateOrganisationAndManagerStep1.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_75_3Y2e( true) ;
         }
         else
         {
            wb_table1_75_3Y2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
         AV8PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
         AV7GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
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
         PA3Y2( ) ;
         WS3Y2( ) ;
         WE3Y2( ) ;
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
         sCtrlAV6WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV8PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV7GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3Y2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wp_createorganisationandmanagerstep1", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3Y2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
            AV8PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
            AV7GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
         }
         wcpOAV6WebSessionKey = cgiGet( sPrefix+"wcpOAV6WebSessionKey");
         wcpOAV8PreviousStep = cgiGet( sPrefix+"wcpOAV8PreviousStep");
         wcpOAV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV7GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV6WebSessionKey, wcpOAV6WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV8PreviousStep, wcpOAV8PreviousStep) != 0 ) || ( AV7GoingBack != wcpOAV7GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV6WebSessionKey = AV6WebSessionKey;
         wcpOAV8PreviousStep = AV8PreviousStep;
         wcpOAV7GoingBack = AV7GoingBack;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6WebSessionKey = cgiGet( sPrefix+"AV6WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV6WebSessionKey) > 0 )
         {
            AV6WebSessionKey = cgiGet( sCtrlAV6WebSessionKey);
            AssignAttri(sPrefix, false, "AV6WebSessionKey", AV6WebSessionKey);
         }
         else
         {
            AV6WebSessionKey = cgiGet( sPrefix+"AV6WebSessionKey_PARM");
         }
         sCtrlAV8PreviousStep = cgiGet( sPrefix+"AV8PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV8PreviousStep) > 0 )
         {
            AV8PreviousStep = cgiGet( sCtrlAV8PreviousStep);
            AssignAttri(sPrefix, false, "AV8PreviousStep", AV8PreviousStep);
         }
         else
         {
            AV8PreviousStep = cgiGet( sPrefix+"AV8PreviousStep_PARM");
         }
         sCtrlAV7GoingBack = cgiGet( sPrefix+"AV7GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV7GoingBack) > 0 )
         {
            AV7GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV7GoingBack));
            AssignAttri(sPrefix, false, "AV7GoingBack", AV7GoingBack);
         }
         else
         {
            AV7GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV7GoingBack_PARM"));
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
         PA3Y2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3Y2( ) ;
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
         WS3Y2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6WebSessionKey_PARM", AV6WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV6WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8PreviousStep_PARM", AV8PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV8PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7GoingBack_PARM", StringUtil.BoolToStr( AV7GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7GoingBack_CTRL", StringUtil.RTrim( sCtrlAV7GoingBack));
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
         WE3Y2( ) ;
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
         AddStyleSheetFile("FileUpload/fileupload.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025620170729", true, true);
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
         context.AddJavascriptSource("wp_createorganisationandmanagerstep1.js", "?2025620170730", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavOrganisationname_Internalname = sPrefix+"vORGANISATIONNAME";
         lblTextblockcombo_organisationtypeid_Internalname = sPrefix+"TEXTBLOCKCOMBO_ORGANISATIONTYPEID";
         Combo_organisationtypeid_Internalname = sPrefix+"COMBO_ORGANISATIONTYPEID";
         divTablesplittedorganisationtypeid_Internalname = sPrefix+"TABLESPLITTEDORGANISATIONTYPEID";
         edtavOrganisationkvknumber_Internalname = sPrefix+"vORGANISATIONKVKNUMBER";
         edtavOrganisationvatnumber_Internalname = sPrefix+"vORGANISATIONVATNUMBER";
         edtavOrganisationemail_Internalname = sPrefix+"vORGANISATIONEMAIL";
         lblPhonelabel_Internalname = sPrefix+"PHONELABEL";
         Combo_organisationphonecode_Internalname = sPrefix+"COMBO_ORGANISATIONPHONECODE";
         divUnnamedtable8_Internalname = sPrefix+"UNNAMEDTABLE8";
         edtavOrganisationphonenumber_Internalname = sPrefix+"vORGANISATIONPHONENUMBER";
         divUnnamedtable9_Internalname = sPrefix+"UNNAMEDTABLE9";
         divUnnamedtable7_Internalname = sPrefix+"UNNAMEDTABLE7";
         divUnnamedtable5_Internalname = sPrefix+"UNNAMEDTABLE5";
         lblUploadlogotext_Internalname = sPrefix+"UPLOADLOGOTEXT";
         Usercontrollogo_Internalname = sPrefix+"USERCONTROLLOGO";
         edtavFilename_Internalname = sPrefix+"vFILENAME";
         lblUseractiondelete_Internalname = sPrefix+"USERACTIONDELETE";
         tblTablemergedusercontrollogo_Internalname = sPrefix+"TABLEMERGEDUSERCONTROLLOGO";
         divUcfilecell_Internalname = sPrefix+"UCFILECELL";
         divUnnamedtable6_Internalname = sPrefix+"UNNAMEDTABLE6";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         grpUnnamedgroup2_Internalname = sPrefix+"UNNAMEDGROUP2";
         edtavOrganisationaddressline1_Internalname = sPrefix+"vORGANISATIONADDRESSLINE1";
         edtavOrganisationaddressline2_Internalname = sPrefix+"vORGANISATIONADDRESSLINE2";
         edtavOrganisationaddresszipcode_Internalname = sPrefix+"vORGANISATIONADDRESSZIPCODE";
         edtavOrganisationaddresscity_Internalname = sPrefix+"vORGANISATIONADDRESSCITY";
         lblTextblockcombo_organisationaddresscountry_Internalname = sPrefix+"TEXTBLOCKCOMBO_ORGANISATIONADDRESSCOUNTRY";
         Combo_organisationaddresscountry_Internalname = sPrefix+"COMBO_ORGANISATIONADDRESSCOUNTRY";
         divTablesplittedorganisationaddresscountry_Internalname = sPrefix+"TABLESPLITTEDORGANISATIONADDRESSCOUNTRY";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         grpUnnamedgroup4_Internalname = sPrefix+"UNNAMEDGROUP4";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         Btnwizardfirstprevious_Internalname = sPrefix+"BTNWIZARDFIRSTPREVIOUS";
         Btnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavOrganisationtypeid_Internalname = sPrefix+"vORGANISATIONTYPEID";
         edtavOrganisationphonecode_Internalname = sPrefix+"vORGANISATIONPHONECODE";
         edtavOrganisationaddresscountry_Internalname = sPrefix+"vORGANISATIONADDRESSCOUNTRY";
         edtavOrganisationid_Internalname = sPrefix+"vORGANISATIONID";
         edtavOrganisationphone_Internalname = sPrefix+"vORGANISATIONPHONE";
         edtavOrganisationlogovar_Internalname = sPrefix+"vORGANISATIONLOGOVAR";
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
         lblUseractiondelete_Visible = 1;
         edtavFilename_Jsonclick = "";
         edtavFilename_Enabled = 1;
         Usercontrollogo_Acceptedfiletypes = "image";
         Usercontrollogo_Autodisableaddingfiles = Convert.ToBoolean( -1);
         Usercontrollogo_Maxnumberoffiles = 1;
         Usercontrollogo_Maxfilesize = 134217728;
         Usercontrollogo_Disableimageresize = Convert.ToBoolean( 0);
         Usercontrollogo_Enableuploadedfilecanceling = Convert.ToBoolean( -1);
         Usercontrollogo_Tooltiptext = "";
         Usercontrollogo_Hideadditionalbuttons = Convert.ToBoolean( -1);
         Usercontrollogo_Autoupload = Convert.ToBoolean( -1);
         Btnwizardfirstprevious_Visible = Convert.ToBoolean( -1);
         edtavFilename_Visible = 1;
         Combo_organisationphonecode_Htmltemplate = "";
         Combo_organisationaddresscountry_Htmltemplate = "";
         edtavOrganisationlogovar_Visible = 1;
         edtavOrganisationphone_Jsonclick = "";
         edtavOrganisationphone_Visible = 1;
         edtavOrganisationid_Jsonclick = "";
         edtavOrganisationid_Visible = 1;
         edtavOrganisationaddresscountry_Jsonclick = "";
         edtavOrganisationaddresscountry_Visible = 1;
         edtavOrganisationphonecode_Jsonclick = "";
         edtavOrganisationphonecode_Visible = 1;
         edtavOrganisationtypeid_Jsonclick = "";
         edtavOrganisationtypeid_Visible = 1;
         Btnwizardnext_Class = "ButtonMaterial ButtonWizard";
         Btnwizardnext_Caption = context.GetMessage( "GXM_next", "");
         Btnwizardnext_Tooltiptext = "";
         Btnwizardfirstprevious_Class = "ButtonMaterialDefault ButtonWizard";
         Btnwizardfirstprevious_Caption = context.GetMessage( "GX_BtnCancel", "");
         Btnwizardfirstprevious_Tooltiptext = "";
         Combo_organisationaddresscountry_Emptyitem = Convert.ToBoolean( 0);
         Combo_organisationaddresscountry_Cls = "ExtendedCombo Attribute ExtendedComboWithImage";
         Combo_organisationaddresscountry_Caption = "";
         edtavOrganisationaddresscity_Jsonclick = "";
         edtavOrganisationaddresscity_Enabled = 1;
         edtavOrganisationaddresszipcode_Jsonclick = "";
         edtavOrganisationaddresszipcode_Enabled = 1;
         edtavOrganisationaddressline2_Jsonclick = "";
         edtavOrganisationaddressline2_Enabled = 1;
         edtavOrganisationaddressline1_Jsonclick = "";
         edtavOrganisationaddressline1_Enabled = 1;
         divUnnamedtable6_Visible = 1;
         edtavOrganisationphonenumber_Jsonclick = "";
         edtavOrganisationphonenumber_Enabled = 1;
         Combo_organisationphonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_organisationphonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_organisationphonecode_Caption = "";
         edtavOrganisationemail_Jsonclick = "";
         edtavOrganisationemail_Enabled = 1;
         edtavOrganisationvatnumber_Jsonclick = "";
         edtavOrganisationvatnumber_Enabled = 1;
         edtavOrganisationkvknumber_Jsonclick = "";
         edtavOrganisationkvknumber_Enabled = 1;
         Combo_organisationtypeid_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_organisationtypeid_Emptyitem = Convert.ToBoolean( 0);
         Combo_organisationtypeid_Cls = "ExtendedCombo Attribute";
         edtavOrganisationname_Jsonclick = "";
         edtavOrganisationname_Enabled = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"AV7GoingBack","fld":"vGOINGBACK"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV7GoingBack","fld":"vGOINGBACK"},{"av":"Btnwizardfirstprevious_Visible","ctrl":"BTNWIZARDFIRSTPREVIOUS","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E143Y2","iparms":[{"av":"AV22CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV10HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV16OrganisationName","fld":"vORGANISATIONNAME"},{"av":"AV21OrganisationTypeId","fld":"vORGANISATIONTYPEID"},{"av":"Combo_organisationtypeid_Ddointernalname","ctrl":"COMBO_ORGANISATIONTYPEID","prop":"DDOInternalName"},{"av":"AV15OrganisationKvkNumber","fld":"vORGANISATIONKVKNUMBER"},{"av":"AV19OrganisationVATNumber","fld":"vORGANISATIONVATNUMBER"},{"av":"AV13OrganisationEmail","fld":"vORGANISATIONEMAIL"},{"av":"AV34OrganisationAddressLine1","fld":"vORGANISATIONADDRESSLINE1"},{"av":"AV26OrganisationAddressZipCode","fld":"vORGANISATIONADDRESSZIPCODE"},{"av":"AV23OrganisationAddressCity","fld":"vORGANISATIONADDRESSCITY"},{"av":"AV27OrganisationAddressCountry","fld":"vORGANISATIONADDRESSCOUNTRY"},{"av":"Combo_organisationaddresscountry_Ddointernalname","ctrl":"COMBO_ORGANISATIONADDRESSCOUNTRY","prop":"DDOInternalName"},{"av":"AV47UploadedFiles","fld":"vUPLOADEDFILES"},{"av":"AV50OrganisationLogoVar","fld":"vORGANISATIONLOGOVAR"},{"av":"AV46FileName","fld":"vFILENAME"},{"av":"AV38OrganisationPhoneCode","fld":"vORGANISATIONPHONECODE"},{"av":"AV41OrganisationPhoneNumber","fld":"vORGANISATIONPHONENUMBER"},{"av":"AV6WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV35OrganisationAddressLine2","fld":"vORGANISATIONADDRESSLINE2"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV22CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV50OrganisationLogoVar","fld":"vORGANISATIONLOGOVAR"},{"av":"AV46FileName","fld":"vFILENAME"},{"av":"AV14OrganisationId","fld":"vORGANISATIONID"},{"av":"AV17OrganisationPhone","fld":"vORGANISATIONPHONE"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E153Y2","iparms":[]}""");
         setEventMetadata("'DOUSERACTIONDELETE'","""{"handler":"E233Y1","iparms":[]""");
         setEventMetadata("'DOUSERACTIONDELETE'",""","oparms":[{"av":"AV50OrganisationLogoVar","fld":"vORGANISATIONLOGOVAR"},{"av":"AV46FileName","fld":"vFILENAME"},{"av":"lblUseractiondelete_Visible","ctrl":"USERACTIONDELETE","prop":"Visible"}]}""");
         setEventMetadata("COMBO_ORGANISATIONTYPEID.ONOPTIONCLICKED","""{"handler":"E113Y2","iparms":[{"av":"Combo_organisationtypeid_Selectedvalue_get","ctrl":"COMBO_ORGANISATIONTYPEID","prop":"SelectedValue_get"},{"av":"Combo_organisationtypeid_Selectedtext_get","ctrl":"COMBO_ORGANISATIONTYPEID","prop":"SelectedText_get"},{"av":"AV21OrganisationTypeId","fld":"vORGANISATIONTYPEID"},{"av":"A20OrganisationTypeName","fld":"ORGANISATIONTYPENAME"},{"av":"A19OrganisationTypeId","fld":"ORGANISATIONTYPEID"}]""");
         setEventMetadata("COMBO_ORGANISATIONTYPEID.ONOPTIONCLICKED",""","oparms":[{"av":"Combo_organisationtypeid_Selectedvalue_set","ctrl":"COMBO_ORGANISATIONTYPEID","prop":"SelectedValue_set"},{"av":"AV21OrganisationTypeId","fld":"vORGANISATIONTYPEID"},{"av":"AV43OrganisationTypeId_Data","fld":"vORGANISATIONTYPEID_DATA"},{"av":"Combo_organisationtypeid_Includeaddnewoption","ctrl":"COMBO_ORGANISATIONTYPEID","prop":"IncludeAddNewOption"}]}""");
         setEventMetadata("VORGANISATIONVATNUMBER.CONTROLVALUECHANGED","""{"handler":"E163Y2","iparms":[{"av":"AV19OrganisationVATNumber","fld":"vORGANISATIONVATNUMBER"}]""");
         setEventMetadata("VORGANISATIONVATNUMBER.CONTROLVALUECHANGED",""","oparms":[{"av":"AV22CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VORGANISATIONEMAIL.CONTROLVALUECHANGED","""{"handler":"E173Y2","iparms":[{"av":"AV13OrganisationEmail","fld":"vORGANISATIONEMAIL"}]""");
         setEventMetadata("VORGANISATIONEMAIL.CONTROLVALUECHANGED",""","oparms":[{"av":"AV22CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VORGANISATIONKVKNUMBER.CONTROLVALUECHANGED","""{"handler":"E183Y2","iparms":[{"av":"AV15OrganisationKvkNumber","fld":"vORGANISATIONKVKNUMBER"}]""");
         setEventMetadata("VORGANISATIONKVKNUMBER.CONTROLVALUECHANGED",""","oparms":[{"av":"AV22CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VORGANISATIONADDRESSZIPCODE.CONTROLVALUECHANGED","""{"handler":"E193Y2","iparms":[{"av":"AV26OrganisationAddressZipCode","fld":"vORGANISATIONADDRESSZIPCODE"}]""");
         setEventMetadata("VORGANISATIONADDRESSZIPCODE.CONTROLVALUECHANGED",""","oparms":[{"av":"AV26OrganisationAddressZipCode","fld":"vORGANISATIONADDRESSZIPCODE"},{"av":"AV22CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VORGANISATIONPHONENUMBER.CONTROLVALUECHANGED","""{"handler":"E203Y2","iparms":[{"av":"AV41OrganisationPhoneNumber","fld":"vORGANISATIONPHONENUMBER"}]""");
         setEventMetadata("VORGANISATIONPHONENUMBER.CONTROLVALUECHANGED",""","oparms":[{"av":"AV22CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VFILENAME.CONTROLVALUECHANGED","""{"handler":"E213Y2","iparms":[{"av":"AV46FileName","fld":"vFILENAME"}]}""");
         setEventMetadata("VALIDV_ORGANISATIONKVKNUMBER","""{"handler":"Validv_Organisationkvknumber","iparms":[]}""");
         setEventMetadata("VALIDV_ORGANISATIONEMAIL","""{"handler":"Validv_Organisationemail","iparms":[]}""");
         setEventMetadata("VALIDV_ORGANISATIONTYPEID","""{"handler":"Validv_Organisationtypeid","iparms":[]}""");
         setEventMetadata("VALIDV_ORGANISATIONID","""{"handler":"Validv_Organisationid","iparms":[]}""");
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

      public override bool UploadEnabled( )
      {
         return true ;
      }

      public override void initialize( )
      {
         wcpOAV6WebSessionKey = "";
         wcpOAV8PreviousStep = "";
         Combo_organisationtypeid_Ddointernalname = "";
         Combo_organisationaddresscountry_Ddointernalname = "";
         Combo_organisationaddresscountry_Selectedvalue_get = "";
         Combo_organisationphonecode_Selectedvalue_get = "";
         Combo_organisationtypeid_Selectedvalue_get = "";
         Combo_organisationtypeid_Selectedtext_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV43OrganisationTypeId_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV29DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV39OrganisationPhoneCode_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV47UploadedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Comforta_version2");
         AV48FailedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "Comforta_version2");
         AV28OrganisationAddressCountry_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A20OrganisationTypeName = "";
         A19OrganisationTypeId = Guid.Empty;
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV16OrganisationName = "";
         lblTextblockcombo_organisationtypeid_Jsonclick = "";
         ucCombo_organisationtypeid = new GXUserControl();
         Combo_organisationtypeid_Caption = "";
         AV15OrganisationKvkNumber = "";
         AV19OrganisationVATNumber = "";
         AV13OrganisationEmail = "";
         lblPhonelabel_Jsonclick = "";
         ucCombo_organisationphonecode = new GXUserControl();
         AV41OrganisationPhoneNumber = "";
         lblUploadlogotext_Jsonclick = "";
         AV34OrganisationAddressLine1 = "";
         AV35OrganisationAddressLine2 = "";
         AV26OrganisationAddressZipCode = "";
         AV23OrganisationAddressCity = "";
         lblTextblockcombo_organisationaddresscountry_Jsonclick = "";
         ucCombo_organisationaddresscountry = new GXUserControl();
         ucBtnwizardfirstprevious = new GXUserControl();
         ucBtnwizardnext = new GXUserControl();
         AV21OrganisationTypeId = Guid.Empty;
         AV38OrganisationPhoneCode = "";
         AV27OrganisationAddressCountry = "";
         AV14OrganisationId = Guid.Empty;
         AV17OrganisationPhone = "";
         AV50OrganisationLogoVar = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV46FileName = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV36defaultCountry = "";
         Combo_organisationaddresscountry_Selectedtext_set = "";
         Combo_organisationaddresscountry_Selectedvalue_set = "";
         AV37defaultCountryPhoneCode = "";
         Combo_organisationphonecode_Selectedtext_set = "";
         Combo_organisationphonecode_Selectedvalue_set = "";
         AV45DefaultOrganisationTypeName = "";
         AV30ComboSelectedValue = "";
         AV44Session = context.GetSession();
         Combo_organisationtypeid_Selectedvalue_set = "";
         AV11WizardData = new SdtWP_CreateOrganisationAndManagerData(context);
         AV5WebSession = context.GetSession();
         AV51Filetype = "";
         GXt_char2 = "";
         AV52GXV1 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV32OrganisationAddressCountry_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV31Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV33ComboTitles = new GxSimpleCollection<string>();
         AV54GXV3 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV40OrganisationPhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         H003Y2_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         H003Y2_A20OrganisationTypeName = new string[] {""} ;
         sStyleString = "";
         ucUsercontrollogo = new GXUserControl();
         lblUseractiondelete_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6WebSessionKey = "";
         sCtrlAV8PreviousStep = "";
         sCtrlAV7GoingBack = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_createorganisationandmanagerstep1__default(),
            new Object[][] {
                new Object[] {
               H003Y2_A19OrganisationTypeId, H003Y2_A20OrganisationTypeName
               }
            }
         );
         /* GeneXus formulas. */
         edtavFilename_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtavFilename_Enabled ;
      private int edtavOrganisationname_Enabled ;
      private int edtavOrganisationkvknumber_Enabled ;
      private int edtavOrganisationvatnumber_Enabled ;
      private int edtavOrganisationemail_Enabled ;
      private int edtavOrganisationphonenumber_Enabled ;
      private int divUnnamedtable6_Visible ;
      private int edtavOrganisationaddressline1_Enabled ;
      private int edtavOrganisationaddressline2_Enabled ;
      private int edtavOrganisationaddresszipcode_Enabled ;
      private int edtavOrganisationaddresscity_Enabled ;
      private int edtavOrganisationtypeid_Visible ;
      private int edtavOrganisationphonecode_Visible ;
      private int edtavOrganisationaddresscountry_Visible ;
      private int edtavOrganisationid_Visible ;
      private int edtavOrganisationphone_Visible ;
      private int edtavOrganisationlogovar_Visible ;
      private int lblUseractiondelete_Visible ;
      private int edtavFilename_Visible ;
      private int AV53GXV2 ;
      private int AV55GXV4 ;
      private int Usercontrollogo_Maxfilesize ;
      private int Usercontrollogo_Maxnumberoffiles ;
      private int idxLst ;
      private string Combo_organisationtypeid_Ddointernalname ;
      private string Combo_organisationaddresscountry_Ddointernalname ;
      private string Combo_organisationaddresscountry_Selectedvalue_get ;
      private string Combo_organisationphonecode_Selectedvalue_get ;
      private string Combo_organisationtypeid_Selectedvalue_get ;
      private string Combo_organisationtypeid_Selectedtext_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavFilename_Internalname ;
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
      private string divTableattributes_Internalname ;
      private string grpUnnamedgroup2_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string edtavOrganisationname_Internalname ;
      private string TempTags ;
      private string edtavOrganisationname_Jsonclick ;
      private string divTablesplittedorganisationtypeid_Internalname ;
      private string lblTextblockcombo_organisationtypeid_Internalname ;
      private string lblTextblockcombo_organisationtypeid_Jsonclick ;
      private string Combo_organisationtypeid_Caption ;
      private string Combo_organisationtypeid_Cls ;
      private string Combo_organisationtypeid_Internalname ;
      private string edtavOrganisationkvknumber_Internalname ;
      private string edtavOrganisationkvknumber_Jsonclick ;
      private string edtavOrganisationvatnumber_Internalname ;
      private string edtavOrganisationvatnumber_Jsonclick ;
      private string edtavOrganisationemail_Internalname ;
      private string edtavOrganisationemail_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string lblPhonelabel_Internalname ;
      private string lblPhonelabel_Jsonclick ;
      private string divUnnamedtable7_Internalname ;
      private string divUnnamedtable8_Internalname ;
      private string Combo_organisationphonecode_Caption ;
      private string Combo_organisationphonecode_Cls ;
      private string Combo_organisationphonecode_Internalname ;
      private string divUnnamedtable9_Internalname ;
      private string edtavOrganisationphonenumber_Internalname ;
      private string edtavOrganisationphonenumber_Jsonclick ;
      private string divUnnamedtable6_Internalname ;
      private string lblUploadlogotext_Internalname ;
      private string lblUploadlogotext_Jsonclick ;
      private string divUcfilecell_Internalname ;
      private string grpUnnamedgroup4_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtavOrganisationaddressline1_Internalname ;
      private string edtavOrganisationaddressline1_Jsonclick ;
      private string edtavOrganisationaddressline2_Internalname ;
      private string edtavOrganisationaddressline2_Jsonclick ;
      private string edtavOrganisationaddresszipcode_Internalname ;
      private string edtavOrganisationaddresszipcode_Jsonclick ;
      private string edtavOrganisationaddresscity_Internalname ;
      private string edtavOrganisationaddresscity_Jsonclick ;
      private string divTablesplittedorganisationaddresscountry_Internalname ;
      private string lblTextblockcombo_organisationaddresscountry_Internalname ;
      private string lblTextblockcombo_organisationaddresscountry_Jsonclick ;
      private string Combo_organisationaddresscountry_Caption ;
      private string Combo_organisationaddresscountry_Cls ;
      private string Combo_organisationaddresscountry_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnwizardfirstprevious_Tooltiptext ;
      private string Btnwizardfirstprevious_Caption ;
      private string Btnwizardfirstprevious_Class ;
      private string Btnwizardfirstprevious_Internalname ;
      private string Btnwizardnext_Tooltiptext ;
      private string Btnwizardnext_Caption ;
      private string Btnwizardnext_Class ;
      private string Btnwizardnext_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavOrganisationtypeid_Internalname ;
      private string edtavOrganisationtypeid_Jsonclick ;
      private string edtavOrganisationphonecode_Internalname ;
      private string edtavOrganisationphonecode_Jsonclick ;
      private string edtavOrganisationaddresscountry_Internalname ;
      private string edtavOrganisationaddresscountry_Jsonclick ;
      private string edtavOrganisationid_Internalname ;
      private string edtavOrganisationid_Jsonclick ;
      private string edtavOrganisationphone_Internalname ;
      private string AV17OrganisationPhone ;
      private string edtavOrganisationphone_Jsonclick ;
      private string edtavOrganisationlogovar_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string Combo_organisationaddresscountry_Htmltemplate ;
      private string Combo_organisationphonecode_Htmltemplate ;
      private string Combo_organisationaddresscountry_Selectedtext_set ;
      private string Combo_organisationaddresscountry_Selectedvalue_set ;
      private string Combo_organisationphonecode_Selectedtext_set ;
      private string Combo_organisationphonecode_Selectedvalue_set ;
      private string lblUseractiondelete_Internalname ;
      private string Combo_organisationtypeid_Selectedvalue_set ;
      private string AV51Filetype ;
      private string GXt_char2 ;
      private string sStyleString ;
      private string tblTablemergedusercontrollogo_Internalname ;
      private string Usercontrollogo_Tooltiptext ;
      private string Usercontrollogo_Acceptedfiletypes ;
      private string Usercontrollogo_Internalname ;
      private string edtavFilename_Jsonclick ;
      private string lblUseractiondelete_Jsonclick ;
      private string sCtrlAV6WebSessionKey ;
      private string sCtrlAV8PreviousStep ;
      private string sCtrlAV7GoingBack ;
      private bool AV7GoingBack ;
      private bool wcpOAV7GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10HasValidationErrors ;
      private bool AV22CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Combo_organisationtypeid_Emptyitem ;
      private bool Combo_organisationtypeid_Includeaddnewoption ;
      private bool Combo_organisationphonecode_Emptyitem ;
      private bool Combo_organisationaddresscountry_Emptyitem ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool Btnwizardfirstprevious_Visible ;
      private bool GXt_boolean4 ;
      private bool Usercontrollogo_Autoupload ;
      private bool Usercontrollogo_Hideadditionalbuttons ;
      private bool Usercontrollogo_Enableuploadedfilecanceling ;
      private bool Usercontrollogo_Disableimageresize ;
      private bool Usercontrollogo_Autodisableaddingfiles ;
      private string AV50OrganisationLogoVar ;
      private string AV6WebSessionKey ;
      private string AV8PreviousStep ;
      private string wcpOAV6WebSessionKey ;
      private string wcpOAV8PreviousStep ;
      private string A20OrganisationTypeName ;
      private string AV16OrganisationName ;
      private string AV15OrganisationKvkNumber ;
      private string AV19OrganisationVATNumber ;
      private string AV13OrganisationEmail ;
      private string AV41OrganisationPhoneNumber ;
      private string AV34OrganisationAddressLine1 ;
      private string AV35OrganisationAddressLine2 ;
      private string AV26OrganisationAddressZipCode ;
      private string AV23OrganisationAddressCity ;
      private string AV38OrganisationPhoneCode ;
      private string AV27OrganisationAddressCountry ;
      private string AV46FileName ;
      private string AV36defaultCountry ;
      private string AV37defaultCountryPhoneCode ;
      private string AV45DefaultOrganisationTypeName ;
      private string AV30ComboSelectedValue ;
      private Guid A19OrganisationTypeId ;
      private Guid AV21OrganisationTypeId ;
      private Guid AV14OrganisationId ;
      private IGxSession AV44Session ;
      private IGxSession AV5WebSession ;
      private GXUserControl ucCombo_organisationtypeid ;
      private GXUserControl ucCombo_organisationphonecode ;
      private GXUserControl ucCombo_organisationaddresscountry ;
      private GXUserControl ucBtnwizardfirstprevious ;
      private GXUserControl ucBtnwizardnext ;
      private GXUserControl ucUsercontrollogo ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV43OrganisationTypeId_Data ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV29DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV39OrganisationPhoneCode_Data ;
      private GXBaseCollection<SdtFileUploadData> AV47UploadedFiles ;
      private GXBaseCollection<SdtFileUploadData> AV48FailedFiles ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV28OrganisationAddressCountry_Data ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private SdtWP_CreateOrganisationAndManagerData AV11WizardData ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV52GXV1 ;
      private SdtSDT_Country_SDT_CountryItem AV32OrganisationAddressCountry_DPItem ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV31Combo_DataItem ;
      private GxSimpleCollection<string> AV33ComboTitles ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV54GXV3 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem3 ;
      private SdtSDT_Country_SDT_CountryItem AV40OrganisationPhoneCode_DPItem ;
      private IDataStoreProvider pr_default ;
      private Guid[] H003Y2_A19OrganisationTypeId ;
      private string[] H003Y2_A20OrganisationTypeName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wp_createorganisationandmanagerstep1__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH003Y2;
          prmH003Y2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H003Y2", "SELECT OrganisationTypeId, OrganisationTypeName FROM Trn_OrganisationType ORDER BY OrganisationTypeName ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Y2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
