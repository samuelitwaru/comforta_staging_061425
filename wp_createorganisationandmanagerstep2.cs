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
   public class wp_createorganisationandmanagerstep2 : GXWebComponent
   {
      public wp_createorganisationandmanagerstep2( )
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

      public wp_createorganisationandmanagerstep2( IGxContext context )
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
         this.AV31WebSessionKey = aP0_WebSessionKey;
         this.AV24PreviousStep = aP1_PreviousStep;
         this.AV6GoingBack = aP2_GoingBack;
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
         cmbavManagergender = new GXCombobox();
         chkavManagerismainmanager = new GXCheckbox();
         cmbavSdt_managers__managergender = new GXCombobox();
         chkavSdt_managers__managerismainmanager = new GXCheckbox();
         cmbavGridactiongroup = new GXCombobox();
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
                  AV31WebSessionKey = GetPar( "WebSessionKey");
                  AssignAttri(sPrefix, false, "AV31WebSessionKey", AV31WebSessionKey);
                  AV24PreviousStep = GetPar( "PreviousStep");
                  AssignAttri(sPrefix, false, "AV24PreviousStep", AV24PreviousStep);
                  AV6GoingBack = StringUtil.StrToBool( GetPar( "GoingBack"));
                  AssignAttri(sPrefix, false, "AV6GoingBack", AV6GoingBack);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV31WebSessionKey,(string)AV24PreviousStep,(bool)AV6GoingBack});
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridsdt_managerss") == 0 )
               {
                  gxnrGridsdt_managerss_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridsdt_managerss") == 0 )
               {
                  gxgrGridsdt_managerss_refresh_invoke( ) ;
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGridsdt_managerss_newrow_invoke( )
      {
         nRC_GXsfl_77 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_77"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_77_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_77_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_77_idx = GetPar( "sGXsfl_77_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridsdt_managerss_newrow( ) ;
         /* End function gxnrGridsdt_managerss_newrow_invoke */
      }

      protected void gxgrGridsdt_managerss_refresh_invoke( )
      {
         subGridsdt_managerss_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridsdt_managerss_Rows"), "."), 18, MidpointRounding.ToEven));
         AV43ManagerIsMainManager = StringUtil.StrToBool( GetPar( "ManagerIsMainManager"));
         AV7HasValidationErrors = StringUtil.StrToBool( GetPar( "HasValidationErrors"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV43ManagerIsMainManager, AV7HasValidationErrors, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridsdt_managerss_refresh_invoke */
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
            PA3Z2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavSdt_managers__managerid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__managerid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__managerid_Enabled), 5, 0), !bGXsfl_77_Refreshing);
               edtavSdt_managers__organisationid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__organisationid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__organisationid_Enabled), 5, 0), !bGXsfl_77_Refreshing);
               edtavSdt_managers__managergivenname_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__managergivenname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__managergivenname_Enabled), 5, 0), !bGXsfl_77_Refreshing);
               edtavSdt_managers__managerlastname_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__managerlastname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__managerlastname_Enabled), 5, 0), !bGXsfl_77_Refreshing);
               edtavSdt_managers__managerinitials_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__managerinitials_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__managerinitials_Enabled), 5, 0), !bGXsfl_77_Refreshing);
               edtavSdt_managers__manageremail_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__manageremail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__manageremail_Enabled), 5, 0), !bGXsfl_77_Refreshing);
               edtavSdt_managers__managerphone_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__managerphone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__managerphone_Enabled), 5, 0), !bGXsfl_77_Refreshing);
               edtavSdt_managers__managerphonecode_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__managerphonecode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__managerphonecode_Enabled), 5, 0), !bGXsfl_77_Refreshing);
               edtavSdt_managers__managerphonenumber_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__managerphonenumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__managerphonenumber_Enabled), 5, 0), !bGXsfl_77_Refreshing);
               cmbavSdt_managers__managergender.Enabled = 0;
               AssignProp(sPrefix, false, cmbavSdt_managers__managergender_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavSdt_managers__managergender.Enabled), 5, 0), !bGXsfl_77_Refreshing);
               edtavSdt_managers__managergamguid_Enabled = 0;
               AssignProp(sPrefix, false, edtavSdt_managers__managergamguid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdt_managers__managergamguid_Enabled), 5, 0), !bGXsfl_77_Refreshing);
               chkavSdt_managers__managerismainmanager.Enabled = 0;
               AssignProp(sPrefix, false, chkavSdt_managers__managerismainmanager_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavSdt_managers__managerismainmanager.Enabled), 5, 0), !bGXsfl_77_Refreshing);
               WS3Z2( ) ;
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
            context.SendWebValue( context.GetMessage( "WP_Create Organisation And Manager Step2", "")) ;
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
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            GXEncryptionTmp = "wp_createorganisationandmanagerstep2.aspx"+UrlEncode(StringUtil.RTrim(AV31WebSessionKey)) + "," + UrlEncode(StringUtil.RTrim(AV24PreviousStep)) + "," + UrlEncode(StringUtil.BoolToStr(AV6GoingBack));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wp_createorganisationandmanagerstep2.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV7HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV7HasValidationErrors, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"Sdt_managers", AV26SDT_Managers);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"Sdt_managers", AV26SDT_Managers);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_77", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_77), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV47DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV47DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGERPHONECODE_DATA", AV50ManagerPhoneCode_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGERPHONECODE_DATA", AV50ManagerPhoneCode_Data);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV31WebSessionKey", wcpOAV31WebSessionKey);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV24PreviousStep", wcpOAV24PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV6GoingBack", wcpOAV6GoingBack);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSDT_MANAGERS", AV26SDT_Managers);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSDT_MANAGERS", AV26SDT_Managers);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASMAINMANAGER", AV70hasMainManager);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV33CheckRequiredFieldsResult);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV7HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV7HasValidationErrors, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWEBSESSIONKEY", AV31WebSessionKey);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWIZARDDATA", AV32WizardData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWIZARDDATA", AV32WizardData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"MANAGEREMAIL", A25ManagerEmail);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPREVIOUSSTEP", AV24PreviousStep);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vGOINGBACK", AV6GoingBack);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"COMBO_MANAGERPHONECODE_Selectedvalue_get", StringUtil.RTrim( Combo_managerphonecode_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm3Z2( )
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
         return "WP_CreateOrganisationAndManagerStep2" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WP_Create Organisation And Manager Step2", "") ;
      }

      protected void WB3Z0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wp_createorganisationandmanagerstep2.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup4_Internalname, context.GetMessage( "Manager Information", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavManagergivenname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavManagergivenname_Internalname, context.GetMessage( "First Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'" + sGXsfl_77_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagergivenname_Internalname, AV12ManagerGivenName, StringUtil.RTrim( context.localUtil.Format( AV12ManagerGivenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagergivenname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavManagergivenname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavManagerlastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavManagerlastname_Internalname, context.GetMessage( "Last Name", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'" + sGXsfl_77_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagerlastname_Internalname, AV15ManagerLastName, StringUtil.RTrim( context.localUtil.Format( AV15ManagerLastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagerlastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavManagerlastname_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavManagergender_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavManagergender_Internalname, context.GetMessage( "Gender", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'" + sGXsfl_77_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavManagergender, cmbavManagergender_Internalname, StringUtil.RTrim( AV11ManagerGender), 1, cmbavManagergender_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavManagergender.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 0, "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            cmbavManagergender.CurrentValue = StringUtil.RTrim( AV11ManagerGender);
            AssignProp(sPrefix, false, cmbavManagergender_Internalname, "Values", (string)(cmbavManagergender.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavManageremail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavManageremail_Internalname, context.GetMessage( "Email", ""), "col-sm-4 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'" + sGXsfl_77_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManageremail_Internalname, AV9ManagerEmail, StringUtil.RTrim( context.localUtil.Format( AV9ManagerEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "johndoe@gmail.com", ""), edtavManageremail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavManageremail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable7_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 gx-label AttributeLabel control-label", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPhonelabel_Internalname, context.GetMessage( "Phone", ""), "", "", lblPhonelabel_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable8_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable9_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PhoneLabel ExtendedComboCell", "start", "top", "", "", "div");
            /* User Defined Control */
            ucCombo_managerphonecode.SetProperty("Caption", Combo_managerphonecode_Caption);
            ucCombo_managerphonecode.SetProperty("Cls", Combo_managerphonecode_Cls);
            ucCombo_managerphonecode.SetProperty("EmptyItem", Combo_managerphonecode_Emptyitem);
            ucCombo_managerphonecode.SetProperty("DropDownOptionsTitleSettingsIcons", AV47DDO_TitleSettingsIcons);
            ucCombo_managerphonecode.SetProperty("DropDownOptionsData", AV50ManagerPhoneCode_Data);
            ucCombo_managerphonecode.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_managerphonecode_Internalname, sPrefix+"COMBO_MANAGERPHONECODEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable10_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavManagerphonenumber_Internalname, context.GetMessage( "Manager Phone Number", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'" + sPrefix + "',false,'" + sGXsfl_77_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagerphonenumber_Internalname, AV52ManagerPhoneNumber, StringUtil.RTrim( context.localUtil.Format( AV52ManagerPhoneNumber, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagerphonenumber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavManagerphonenumber_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavManagerismainmanager_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavManagerismainmanager_Internalname, context.GetMessage( "Is Main Manager?", ""), "col-sm-4 AttributeCheckBoxLabel BootstrapTooltipRightLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'" + sPrefix + "',false,'" + sGXsfl_77_idx + "',0)\"";
            ClassString = "AttributeCheckBox BootstrapTooltipRight";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavManagerismainmanager_Internalname, StringUtil.BoolToStr( AV43ManagerIsMainManager), chkavManagerismainmanager.TooltipText, context.GetMessage( "Is Main Manager?", ""), 1, chkavManagerismainmanager.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(66, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,66);\"");
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
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 100, "%", 0, "px", "Table", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:100fr;grid-template-rows:auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;align-items:center;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuinsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(77), 2, 0)+","+"null"+");", context.GetMessage( "Save", ""), bttBtnuinsert_Jsonclick, 5, context.GetMessage( "Add new item", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablegrid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            Gridsdt_managerssContainer.SetWrapped(nGXWrapped);
            StartGridControl77( ) ;
         }
         if ( wbEnd == 77 )
         {
            wbEnd = 0;
            nRC_GXsfl_77 = (int)(nGXsfl_77_idx-1);
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Gridsdt_managerssContainer.AddObjectProperty("GRIDSDT_MANAGERSS_nEOF", GRIDSDT_MANAGERSS_nEOF);
               Gridsdt_managerssContainer.AddObjectProperty("GRIDSDT_MANAGERSS_nFirstRecordOnPage", GRIDSDT_MANAGERSS_nFirstRecordOnPage);
               AV73GXV1 = nGXsfl_77_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_managerssContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridsdt_managerss", Gridsdt_managerssContainer, subGridsdt_managerss_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_managerssContainerData", Gridsdt_managerssContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_managerssContainerData"+"V", Gridsdt_managerssContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridsdt_managerssContainerData"+"V"+"\" value='"+Gridsdt_managerssContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'" + sPrefix + "',false,'" + sGXsfl_77_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagerphonecode_Internalname, AV49ManagerPhoneCode, StringUtil.RTrim( context.localUtil.Format( AV49ManagerPhoneCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagerphonecode_Jsonclick, 0, "Attribute", "", "", "", "", edtavManagerphonecode_Visible, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'" + sPrefix + "',false,'" + sGXsfl_77_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagerinitials_Internalname, StringUtil.RTrim( AV14ManagerInitials), StringUtil.RTrim( context.localUtil.Format( AV14ManagerInitials, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagerinitials_Jsonclick, 0, "Attribute", "", "", "", "", edtavManagerinitials_Visible, 1, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'" + sPrefix + "',false,'" + sGXsfl_77_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagerphone_Internalname, StringUtil.RTrim( AV16ManagerPhone), StringUtil.RTrim( context.localUtil.Format( AV16ManagerPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagerphone_Jsonclick, 0, "Attribute", "", "", "", "", edtavManagerphone_Visible, 1, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'" + sPrefix + "',false,'" + sGXsfl_77_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagerid_Internalname, AV13ManagerId.ToString(), AV13ManagerId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagerid_Jsonclick, 0, "Attribute", "", "", "", "", edtavManagerid_Visible, 1, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'" + sPrefix + "',false,'" + sGXsfl_77_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavManagergamguid_Internalname, AV10ManagerGAMGUID, StringUtil.RTrim( context.localUtil.Format( AV10ManagerGAMGUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,105);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavManagergamguid_Jsonclick, 0, "Attribute", "", "", "", "", edtavManagergamguid_Visible, 1, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "", "start", true, "", "HLP_WP_CreateOrganisationAndManagerStep2.htm");
            /* User Defined Control */
            ucGridsdt_managerss_empowerer.Render(context, "wwp.gridempowerer", Gridsdt_managerss_empowerer_Internalname, sPrefix+"GRIDSDT_MANAGERSS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 77 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Gridsdt_managerssContainer.AddObjectProperty("GRIDSDT_MANAGERSS_nEOF", GRIDSDT_MANAGERSS_nEOF);
                  Gridsdt_managerssContainer.AddObjectProperty("GRIDSDT_MANAGERSS_nFirstRecordOnPage", GRIDSDT_MANAGERSS_nFirstRecordOnPage);
                  AV73GXV1 = nGXsfl_77_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_managerssContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridsdt_managerss", Gridsdt_managerssContainer, subGridsdt_managerss_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_managerssContainerData", Gridsdt_managerssContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Gridsdt_managerssContainerData"+"V", Gridsdt_managerssContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Gridsdt_managerssContainerData"+"V"+"\" value='"+Gridsdt_managerssContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3Z2( )
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
            Form.Meta.addItem("description", context.GetMessage( "WP_Create Organisation And Manager Step2", ""), 0) ;
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
               STRUP3Z0( ) ;
            }
         }
      }

      protected void WS3Z2( )
      {
         START3Z2( ) ;
         EVT3Z2( ) ;
      }

      protected void EVT3Z2( )
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
                                 STRUP3Z0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Z0( ) ;
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
                                          E113Z2 ();
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
                                 STRUP3Z0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'WizardPrevious' */
                                    E123Z2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Z0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUInsert' */
                                    E133Z2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VMANAGEREMAIL.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Z0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E143Z2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VMANAGERPHONENUMBER.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Z0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E153Z2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Z0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavSdt_managers__managerid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDSDT_MANAGERSSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Z0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDSDT_MANAGERSSPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridsdt_managerss_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridsdt_managerss_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridsdt_managerss_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridsdt_managerss_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "GRIDSDT_MANAGERSS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "VGRIDACTIONGROUP.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "VGRIDACTIONGROUP.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Z0( ) ;
                              }
                              nGXsfl_77_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
                              SubsflControlProps_772( ) ;
                              AV73GXV1 = (int)(nGXsfl_77_idx+GRIDSDT_MANAGERSS_nFirstRecordOnPage);
                              if ( ( AV26SDT_Managers.Count >= AV73GXV1 ) && ( AV73GXV1 > 0 ) )
                              {
                                 AV26SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1));
                                 cmbavGridactiongroup.Name = cmbavGridactiongroup_Internalname;
                                 cmbavGridactiongroup.CurrentValue = cgiGet( cmbavGridactiongroup_Internalname);
                                 AV71GridActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                                 AssignAttri(sPrefix, false, cmbavGridactiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV71GridActionGroup), 4, 0));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_managers__managerid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E163Z2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDSDT_MANAGERSS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_managers__managerid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Gridsdt_managerss.Load */
                                          E173Z2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONGROUP.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_managers__managerid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E183Z2 ();
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP3Z0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavSdt_managers__managerid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE3Z2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3Z2( ) ;
            }
         }
      }

      protected void PA3Z2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wp_createorganisationandmanagerstep2.aspx")), "wp_createorganisationandmanagerstep2.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wp_createorganisationandmanagerstep2.aspx")))) ;
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
               GX_FocusControl = edtavManagergivenname_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridsdt_managerss_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_772( ) ;
         while ( nGXsfl_77_idx <= nRC_GXsfl_77 )
         {
            sendrow_772( ) ;
            nGXsfl_77_idx = ((subGridsdt_managerss_Islastpage==1)&&(nGXsfl_77_idx+1>subGridsdt_managerss_fnc_Recordsperpage( )) ? 1 : nGXsfl_77_idx+1);
            sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
            SubsflControlProps_772( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridsdt_managerssContainer)) ;
         /* End function gxnrGridsdt_managerss_newrow */
      }

      protected void gxgrGridsdt_managerss_refresh( int subGridsdt_managerss_Rows ,
                                                    bool AV43ManagerIsMainManager ,
                                                    bool AV7HasValidationErrors ,
                                                    string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDSDT_MANAGERSS_nCurrentRecord = 0;
         RF3Z2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGridsdt_managerss_refresh */
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
         if ( cmbavManagergender.ItemCount > 0 )
         {
            AV11ManagerGender = cmbavManagergender.getValidValue(AV11ManagerGender);
            AssignAttri(sPrefix, false, "AV11ManagerGender", AV11ManagerGender);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavManagergender.CurrentValue = StringUtil.RTrim( AV11ManagerGender);
            AssignProp(sPrefix, false, cmbavManagergender_Internalname, "Values", cmbavManagergender.ToJavascriptSource(), true);
         }
         AV43ManagerIsMainManager = StringUtil.StrToBool( StringUtil.BoolToStr( AV43ManagerIsMainManager));
         AssignAttri(sPrefix, false, "AV43ManagerIsMainManager", AV43ManagerIsMainManager);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3Z2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavSdt_managers__managerid_Enabled = 0;
         edtavSdt_managers__organisationid_Enabled = 0;
         edtavSdt_managers__managergivenname_Enabled = 0;
         edtavSdt_managers__managerlastname_Enabled = 0;
         edtavSdt_managers__managerinitials_Enabled = 0;
         edtavSdt_managers__manageremail_Enabled = 0;
         edtavSdt_managers__managerphone_Enabled = 0;
         edtavSdt_managers__managerphonecode_Enabled = 0;
         edtavSdt_managers__managerphonenumber_Enabled = 0;
         cmbavSdt_managers__managergender.Enabled = 0;
         edtavSdt_managers__managergamguid_Enabled = 0;
         chkavSdt_managers__managerismainmanager.Enabled = 0;
      }

      protected void RF3Z2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Gridsdt_managerssContainer.ClearRows();
         }
         wbStart = 77;
         nGXsfl_77_idx = 1;
         sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
         SubsflControlProps_772( ) ;
         bGXsfl_77_Refreshing = true;
         Gridsdt_managerssContainer.AddObjectProperty("GridName", "Gridsdt_managerss");
         Gridsdt_managerssContainer.AddObjectProperty("CmpContext", sPrefix);
         Gridsdt_managerssContainer.AddObjectProperty("InMasterPage", "false");
         Gridsdt_managerssContainer.AddObjectProperty("Class", "WorkWith");
         Gridsdt_managerssContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridsdt_managerssContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridsdt_managerssContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Backcolorstyle), 1, 0, ".", "")));
         Gridsdt_managerssContainer.PageSize = subGridsdt_managerss_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_772( ) ;
            /* Execute user event: Gridsdt_managerss.Load */
            E173Z2 ();
            if ( ( subGridsdt_managerss_Islastpage == 0 ) && ( GRIDSDT_MANAGERSS_nCurrentRecord > 0 ) && ( GRIDSDT_MANAGERSS_nGridOutOfScope == 0 ) && ( nGXsfl_77_idx == 1 ) )
            {
               GRIDSDT_MANAGERSS_nCurrentRecord = 0;
               GRIDSDT_MANAGERSS_nGridOutOfScope = 1;
               subgridsdt_managerss_firstpage( ) ;
               /* Execute user event: Gridsdt_managerss.Load */
               E173Z2 ();
            }
            wbEnd = 77;
            WB3Z0( ) ;
         }
         bGXsfl_77_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3Z2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASVALIDATIONERRORS", AV7HasValidationErrors);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASVALIDATIONERRORS", GetSecureSignedToken( sPrefix, AV7HasValidationErrors, context));
      }

      protected int subGridsdt_managerss_fnc_Pagecount( )
      {
         GRIDSDT_MANAGERSS_nRecordCount = subGridsdt_managerss_fnc_Recordcount( );
         if ( ((int)((GRIDSDT_MANAGERSS_nRecordCount) % (subGridsdt_managerss_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_MANAGERSS_nRecordCount/ (decimal)(subGridsdt_managerss_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_MANAGERSS_nRecordCount/ (decimal)(subGridsdt_managerss_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridsdt_managerss_fnc_Recordcount( )
      {
         return AV26SDT_Managers.Count ;
      }

      protected int subGridsdt_managerss_fnc_Recordsperpage( )
      {
         if ( subGridsdt_managerss_Rows > 0 )
         {
            return subGridsdt_managerss_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridsdt_managerss_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDSDT_MANAGERSS_nFirstRecordOnPage/ (decimal)(subGridsdt_managerss_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridsdt_managerss_firstpage( )
      {
         GRIDSDT_MANAGERSS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV43ManagerIsMainManager, AV7HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdt_managerss_nextpage( )
      {
         GRIDSDT_MANAGERSS_nRecordCount = subGridsdt_managerss_fnc_Recordcount( );
         if ( ( GRIDSDT_MANAGERSS_nRecordCount >= subGridsdt_managerss_fnc_Recordsperpage( ) ) && ( GRIDSDT_MANAGERSS_nEOF == 0 ) )
         {
            GRIDSDT_MANAGERSS_nFirstRecordOnPage = (long)(GRIDSDT_MANAGERSS_nFirstRecordOnPage+subGridsdt_managerss_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nFirstRecordOnPage), 15, 0, ".", "")));
         Gridsdt_managerssContainer.AddObjectProperty("GRIDSDT_MANAGERSS_nFirstRecordOnPage", GRIDSDT_MANAGERSS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV43ManagerIsMainManager, AV7HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDSDT_MANAGERSS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridsdt_managerss_previouspage( )
      {
         if ( GRIDSDT_MANAGERSS_nFirstRecordOnPage >= subGridsdt_managerss_fnc_Recordsperpage( ) )
         {
            GRIDSDT_MANAGERSS_nFirstRecordOnPage = (long)(GRIDSDT_MANAGERSS_nFirstRecordOnPage-subGridsdt_managerss_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV43ManagerIsMainManager, AV7HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridsdt_managerss_lastpage( )
      {
         GRIDSDT_MANAGERSS_nRecordCount = subGridsdt_managerss_fnc_Recordcount( );
         if ( GRIDSDT_MANAGERSS_nRecordCount > subGridsdt_managerss_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDSDT_MANAGERSS_nRecordCount) % (subGridsdt_managerss_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDSDT_MANAGERSS_nFirstRecordOnPage = (long)(GRIDSDT_MANAGERSS_nRecordCount-subGridsdt_managerss_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDSDT_MANAGERSS_nFirstRecordOnPage = (long)(GRIDSDT_MANAGERSS_nRecordCount-((int)((GRIDSDT_MANAGERSS_nRecordCount) % (subGridsdt_managerss_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDSDT_MANAGERSS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV43ManagerIsMainManager, AV7HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridsdt_managerss_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDSDT_MANAGERSS_nFirstRecordOnPage = (long)(subGridsdt_managerss_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDSDT_MANAGERSS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV43ManagerIsMainManager, AV7HasValidationErrors, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtavSdt_managers__managerid_Enabled = 0;
         edtavSdt_managers__organisationid_Enabled = 0;
         edtavSdt_managers__managergivenname_Enabled = 0;
         edtavSdt_managers__managerlastname_Enabled = 0;
         edtavSdt_managers__managerinitials_Enabled = 0;
         edtavSdt_managers__manageremail_Enabled = 0;
         edtavSdt_managers__managerphone_Enabled = 0;
         edtavSdt_managers__managerphonecode_Enabled = 0;
         edtavSdt_managers__managerphonenumber_Enabled = 0;
         cmbavSdt_managers__managergender.Enabled = 0;
         edtavSdt_managers__managergamguid_Enabled = 0;
         chkavSdt_managers__managerismainmanager.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3Z0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E163Z2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"Sdt_managers"), AV26SDT_Managers);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV47DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGERPHONECODE_DATA"), AV50ManagerPhoneCode_Data);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSDT_MANAGERS"), AV26SDT_Managers);
            /* Read saved values. */
            nRC_GXsfl_77 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_77"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            wcpOAV31WebSessionKey = cgiGet( sPrefix+"wcpOAV31WebSessionKey");
            wcpOAV24PreviousStep = cgiGet( sPrefix+"wcpOAV24PreviousStep");
            wcpOAV6GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV6GoingBack"));
            GRIDSDT_MANAGERSS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_MANAGERSS_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRIDSDT_MANAGERSS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_MANAGERSS_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGridsdt_managerss_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDSDT_MANAGERSS_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Rows), 6, 0, ".", "")));
            nRC_GXsfl_77 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_77"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            nGXsfl_77_fel_idx = 0;
            while ( nGXsfl_77_fel_idx < nRC_GXsfl_77 )
            {
               nGXsfl_77_fel_idx = ((subGridsdt_managerss_Islastpage==1)&&(nGXsfl_77_fel_idx+1>subGridsdt_managerss_fnc_Recordsperpage( )) ? 1 : nGXsfl_77_fel_idx+1);
               sGXsfl_77_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_772( ) ;
               AV73GXV1 = (int)(nGXsfl_77_fel_idx+GRIDSDT_MANAGERSS_nFirstRecordOnPage);
               if ( ( AV26SDT_Managers.Count >= AV73GXV1 ) && ( AV73GXV1 > 0 ) )
               {
                  AV26SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1));
                  cmbavGridactiongroup.Name = cmbavGridactiongroup_Internalname;
                  cmbavGridactiongroup.CurrentValue = cgiGet( cmbavGridactiongroup_Internalname);
                  AV71GridActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
               }
            }
            if ( nGXsfl_77_fel_idx == 0 )
            {
               nGXsfl_77_idx = 1;
               sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
               SubsflControlProps_772( ) ;
            }
            nGXsfl_77_fel_idx = 1;
            /* Read variables values. */
            AV12ManagerGivenName = cgiGet( edtavManagergivenname_Internalname);
            AssignAttri(sPrefix, false, "AV12ManagerGivenName", AV12ManagerGivenName);
            AV15ManagerLastName = cgiGet( edtavManagerlastname_Internalname);
            AssignAttri(sPrefix, false, "AV15ManagerLastName", AV15ManagerLastName);
            cmbavManagergender.Name = cmbavManagergender_Internalname;
            cmbavManagergender.CurrentValue = cgiGet( cmbavManagergender_Internalname);
            AV11ManagerGender = cgiGet( cmbavManagergender_Internalname);
            AssignAttri(sPrefix, false, "AV11ManagerGender", AV11ManagerGender);
            AV9ManagerEmail = cgiGet( edtavManageremail_Internalname);
            AssignAttri(sPrefix, false, "AV9ManagerEmail", AV9ManagerEmail);
            AV52ManagerPhoneNumber = cgiGet( edtavManagerphonenumber_Internalname);
            AssignAttri(sPrefix, false, "AV52ManagerPhoneNumber", AV52ManagerPhoneNumber);
            AV43ManagerIsMainManager = StringUtil.StrToBool( cgiGet( chkavManagerismainmanager_Internalname));
            AssignAttri(sPrefix, false, "AV43ManagerIsMainManager", AV43ManagerIsMainManager);
            AV49ManagerPhoneCode = cgiGet( edtavManagerphonecode_Internalname);
            AssignAttri(sPrefix, false, "AV49ManagerPhoneCode", AV49ManagerPhoneCode);
            AV14ManagerInitials = cgiGet( edtavManagerinitials_Internalname);
            AssignAttri(sPrefix, false, "AV14ManagerInitials", AV14ManagerInitials);
            AV16ManagerPhone = cgiGet( edtavManagerphone_Internalname);
            AssignAttri(sPrefix, false, "AV16ManagerPhone", AV16ManagerPhone);
            if ( StringUtil.StrCmp(cgiGet( edtavManagerid_Internalname), "") == 0 )
            {
               AV13ManagerId = Guid.Empty;
               AssignAttri(sPrefix, false, "AV13ManagerId", AV13ManagerId.ToString());
            }
            else
            {
               try
               {
                  AV13ManagerId = StringUtil.StrToGuid( cgiGet( edtavManagerid_Internalname));
                  AssignAttri(sPrefix, false, "AV13ManagerId", AV13ManagerId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vMANAGERID");
                  GX_FocusControl = edtavManagerid_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            AV10ManagerGAMGUID = cgiGet( edtavManagergamguid_Internalname);
            AssignAttri(sPrefix, false, "AV10ManagerGAMGUID", AV10ManagerGAMGUID);
            /* Read subfile selected row values. */
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
         E163Z2 ();
         if (returnInSub) return;
      }

      protected void E163Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( (false==AV32WizardData.gxTpr_Step1.FromJSonString(AV30WebSession.Get(AV31WebSessionKey), null)) )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_createorganisationandmanager.aspx"+UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.RTrim("Step1")) + "," + UrlEncode(StringUtil.BoolToStr(true));
            CallWebObject(formatLink("wp_createorganisationandmanager.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         /* Execute user subroutine: 'LOADVARIABLESFROMWIZARDDATA' */
         S112 ();
         if (returnInSub) return;
         chkavManagerismainmanager.TooltipText = context.GetMessage( "Has permissions to add/edit/delete fellow managers", "");
         AssignProp(sPrefix, false, chkavManagerismainmanager_Internalname, "Tooltiptext", chkavManagerismainmanager.TooltipText, true);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV47DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV47DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtavManagerphonecode_Visible = 0;
         AssignProp(sPrefix, false, edtavManagerphonecode_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavManagerphonecode_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char2) ;
         Combo_managerphonecode_Htmltemplate = GXt_char2;
         ucCombo_managerphonecode.SendProperty(context, sPrefix, false, Combo_managerphonecode_Internalname, "HTMLTemplate", Combo_managerphonecode_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBOMANAGERPHONECODE' */
         S122 ();
         if (returnInSub) return;
         edtavManagerinitials_Visible = 0;
         AssignProp(sPrefix, false, edtavManagerinitials_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavManagerinitials_Visible), 5, 0), true);
         edtavManagerphone_Visible = 0;
         AssignProp(sPrefix, false, edtavManagerphone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavManagerphone_Visible), 5, 0), true);
         edtavManagerid_Visible = 0;
         AssignProp(sPrefix, false, edtavManagerid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavManagerid_Visible), 5, 0), true);
         edtavManagergamguid_Visible = 0;
         AssignProp(sPrefix, false, edtavManagergamguid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavManagergamguid_Visible), 5, 0), true);
         Gridsdt_managerss_empowerer_Gridinternalname = subGridsdt_managerss_Internalname;
         ucGridsdt_managerss_empowerer.SendProperty(context, sPrefix, false, Gridsdt_managerss_empowerer_Internalname, "GridInternalName", Gridsdt_managerss_empowerer_Gridinternalname);
         subGridsdt_managerss_Rows = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Rows), 6, 0, ".", "")));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49ManagerPhoneCode)) )
         {
            AV48defaultCountryPhoneCode = "+31";
            AV49ManagerPhoneCode = "+31";
            AssignAttri(sPrefix, false, "AV49ManagerPhoneCode", AV49ManagerPhoneCode);
            Combo_managerphonecode_Selectedtext_set = AV48defaultCountryPhoneCode;
            ucCombo_managerphonecode.SendProperty(context, sPrefix, false, Combo_managerphonecode_Internalname, "SelectedText_set", Combo_managerphonecode_Selectedtext_set);
            Combo_managerphonecode_Selectedvalue_set = AV48defaultCountryPhoneCode;
            ucCombo_managerphonecode.SendProperty(context, sPrefix, false, Combo_managerphonecode_Internalname, "SelectedValue_set", Combo_managerphonecode_Selectedvalue_set);
         }
         AV53IsEditing = false;
         GX_FocusControl = edtavManagergivenname_Internalname;
         AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         context.DoAjaxSetFocus(GX_FocusControl);
      }

      private void E173Z2( )
      {
         /* Gridsdt_managerss_Load Routine */
         returnInSub = false;
         AV73GXV1 = 1;
         while ( AV73GXV1 <= AV26SDT_Managers.Count )
         {
            AV26SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1));
            cmbavGridactiongroup.removeAllItems();
            cmbavGridactiongroup.addItem("0", ";fas fa-bars", 0);
            cmbavGridactiongroup.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "Edit", ""), "fas fa-pencil", "", "", "", "", "", "", ""), 0);
            cmbavGridactiongroup.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Delete", ""), "fas fa-xmark", "", "", "", "", "", "", ""), 0);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 77;
            }
            if ( ( subGridsdt_managerss_Islastpage == 1 ) || ( subGridsdt_managerss_Rows == 0 ) || ( ( GRIDSDT_MANAGERSS_nCurrentRecord >= GRIDSDT_MANAGERSS_nFirstRecordOnPage ) && ( GRIDSDT_MANAGERSS_nCurrentRecord < GRIDSDT_MANAGERSS_nFirstRecordOnPage + subGridsdt_managerss_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_772( ) ;
            }
            GRIDSDT_MANAGERSS_nEOF = (short)(((GRIDSDT_MANAGERSS_nCurrentRecord<GRIDSDT_MANAGERSS_nFirstRecordOnPage+subGridsdt_managerss_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSDT_MANAGERSS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDSDT_MANAGERSS_nEOF), 1, 0, ".", "")));
            GRIDSDT_MANAGERSS_nCurrentRecord = (long)(GRIDSDT_MANAGERSS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_77_Refreshing )
            {
               DoAjaxLoad(77, Gridsdt_managerssRow);
            }
            AV73GXV1 = (int)(AV73GXV1+1);
         }
         /*  Sending Event outputs  */
         cmbavGridactiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV71GridActionGroup), 4, 0));
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E113Z2 ();
         if (returnInSub) return;
      }

      protected void E113Z2( )
      {
         AV73GXV1 = (int)(nGXsfl_77_idx+GRIDSDT_MANAGERSS_nFirstRecordOnPage);
         if ( ( AV73GXV1 > 0 ) && ( AV26SDT_Managers.Count >= AV73GXV1 ) )
         {
            AV26SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1));
         }
         /* Enter Routine */
         returnInSub = false;
         if ( AV26SDT_Managers.Count > 0 )
         {
            /* Execute user subroutine: 'CHECKHASMAINMANAGER' */
            S132 ();
            if (returnInSub) return;
            if ( ( AV26SDT_Managers.Count > 0 ) && AV70hasMainManager )
            {
               /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
               S142 ();
               if (returnInSub) return;
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wp_createorganisationandmanager.aspx"+UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.RTrim("Step3")) + "," + UrlEncode(StringUtil.BoolToStr(false));
               CallWebObject(formatLink("wp_createorganisationandmanager.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "Add at least 1 main manager", ""));
            }
         }
         else
         {
            /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
            S152 ();
            if (returnInSub) return;
            if ( AV33CheckRequiredFieldsResult && ! AV7HasValidationErrors )
            {
               /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
               S142 ();
               if (returnInSub) return;
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wp_createorganisationandmanager.aspx"+UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.RTrim("Step3")) + "," + UrlEncode(StringUtil.BoolToStr(false));
               CallWebObject(formatLink("wp_createorganisationandmanager.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32WizardData", AV32WizardData);
      }

      protected void E123Z2( )
      {
         AV73GXV1 = (int)(nGXsfl_77_idx+GRIDSDT_MANAGERSS_nFirstRecordOnPage);
         if ( ( AV73GXV1 > 0 ) && ( AV26SDT_Managers.Count >= AV73GXV1 ) )
         {
            AV26SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1));
         }
         /* 'WizardPrevious' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVEVARIABLESTOWIZARDDATA' */
         S142 ();
         if (returnInSub) return;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wp_createorganisationandmanager.aspx"+UrlEncode(StringUtil.RTrim("Step2")) + "," + UrlEncode(StringUtil.RTrim("Step1")) + "," + UrlEncode(StringUtil.BoolToStr(true));
         CallWebObject(formatLink("wp_createorganisationandmanager.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32WizardData", AV32WizardData);
      }

      protected void E183Z2( )
      {
         AV73GXV1 = (int)(nGXsfl_77_idx+GRIDSDT_MANAGERSS_nFirstRecordOnPage);
         if ( ( AV73GXV1 > 0 ) && ( AV26SDT_Managers.Count >= AV73GXV1 ) )
         {
            AV26SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1));
         }
         /* Gridactiongroup_Click Routine */
         returnInSub = false;
         if ( AV71GridActionGroup == 1 )
         {
            /* Execute user subroutine: 'DO UEDIT' */
            S162 ();
            if (returnInSub) return;
         }
         else if ( AV71GridActionGroup == 2 )
         {
            /* Execute user subroutine: 'DO UDELETE' */
            S172 ();
            if (returnInSub) return;
         }
         AV71GridActionGroup = 0;
         AssignAttri(sPrefix, false, cmbavGridactiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV71GridActionGroup), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV71GridActionGroup), 4, 0));
         AssignProp(sPrefix, false, cmbavGridactiongroup_Internalname, "Values", cmbavGridactiongroup.ToJavascriptSource(), true);
         cmbavManagergender.CurrentValue = StringUtil.RTrim( AV11ManagerGender);
         AssignProp(sPrefix, false, cmbavManagergender_Internalname, "Values", cmbavManagergender.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV26SDT_Managers", AV26SDT_Managers);
         nGXsfl_77_bak_idx = nGXsfl_77_idx;
         gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV43ManagerIsMainManager, AV7HasValidationErrors, sPrefix) ;
         nGXsfl_77_idx = nGXsfl_77_bak_idx;
         sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
         SubsflControlProps_772( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32WizardData", AV32WizardData);
      }

      protected void E133Z2( )
      {
         AV73GXV1 = (int)(nGXsfl_77_idx+GRIDSDT_MANAGERSS_nFirstRecordOnPage);
         if ( ( AV73GXV1 > 0 ) && ( AV26SDT_Managers.Count >= AV73GXV1 ) )
         {
            AV26SDT_Managers.CurrentItem = ((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1));
         }
         /* 'DoUInsert' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S152 ();
         if (returnInSub) return;
         if ( AV33CheckRequiredFieldsResult && ! AV7HasValidationErrors )
         {
            AV38isAlreadyAdded = false;
            AV39isAlreadyExistingInGAM = false;
            AV37GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getbylogin("local", AV9ManagerEmail, out  AV36GAMErrors);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37GAMUser.gxTpr_Email)) && ( StringUtil.StrCmp(AV37GAMUser.gxTpr_Email, AV9ManagerEmail) == 0 ) )
            {
               AV39isAlreadyExistingInGAM = true;
            }
            AV86GXV14 = 1;
            while ( AV86GXV14 <= AV26SDT_Managers.Count )
            {
               AV25SDT_Manager = ((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV86GXV14));
               if ( StringUtil.StrCmp(AV25SDT_Manager.gxTpr_Manageremail, AV9ManagerEmail) == 0 )
               {
                  AV38isAlreadyAdded = true;
                  if (true) break;
               }
               AV86GXV14 = (int)(AV86GXV14+1);
            }
            /* Using cursor H003Z2 */
            pr_default.execute(0, new Object[] {AV9ManagerEmail});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A25ManagerEmail = H003Z2_A25ManagerEmail[0];
               AV68isAlreadyRegistered = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV38isAlreadyAdded || AV68isAlreadyRegistered )
            {
               GX_msglist.addItem(context.GetMessage( "This Manager email has already been added.", ""));
               AV26SDT_Managers = AV32WizardData.gxTpr_Step2.gxTpr_Sdt_managers;
               gx_BV77 = true;
            }
            else
            {
               if ( AV39isAlreadyExistingInGAM )
               {
                  GX_msglist.addItem(context.GetMessage( "This email is already used in the system.", ""));
                  AV26SDT_Managers = AV32WizardData.gxTpr_Step2.gxTpr_Sdt_managers;
                  gx_BV77 = true;
               }
               else
               {
                  AV25SDT_Manager = new SdtSDT_Managers_SDT_ManagersItem(context);
                  AV25SDT_Manager.gxTpr_Managerid = Guid.NewGuid( );
                  AV25SDT_Manager.gxTpr_Managergivenname = AV12ManagerGivenName;
                  AV25SDT_Manager.gxTpr_Managerlastname = AV15ManagerLastName;
                  AV25SDT_Manager.gxTpr_Manageremail = AV9ManagerEmail;
                  AV25SDT_Manager.gxTpr_Managergender = AV11ManagerGender;
                  AV25SDT_Manager.gxTpr_Managerphonecode = AV49ManagerPhoneCode;
                  AV25SDT_Manager.gxTpr_Managerphonenumber = AV52ManagerPhoneNumber;
                  GXt_char2 = "";
                  new prc_concatenateintlphone(context ).execute(  AV49ManagerPhoneCode,  AV52ManagerPhoneNumber, out  GXt_char2) ;
                  AV25SDT_Manager.gxTpr_Managerphone = GXt_char2;
                  AV25SDT_Manager.gxTpr_Managerismainmanager = AV43ManagerIsMainManager;
                  AV32WizardData.gxTpr_Step2.gxTpr_Sdt_managers.Add(AV25SDT_Manager, 0);
                  AV26SDT_Managers = AV32WizardData.gxTpr_Step2.gxTpr_Sdt_managers;
                  gx_BV77 = true;
                  /* Execute user subroutine: 'CLEARFORMVALUES' */
                  S182 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32WizardData", AV32WizardData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV26SDT_Managers", AV26SDT_Managers);
         nGXsfl_77_bak_idx = nGXsfl_77_idx;
         gxgrGridsdt_managerss_refresh( subGridsdt_managerss_Rows, AV43ManagerIsMainManager, AV7HasValidationErrors, sPrefix) ;
         nGXsfl_77_idx = nGXsfl_77_bak_idx;
         sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
         SubsflControlProps_772( ) ;
         cmbavManagergender.CurrentValue = StringUtil.RTrim( AV11ManagerGender);
         AssignProp(sPrefix, false, cmbavManagergender_Internalname, "Values", cmbavManagergender.ToJavascriptSource(), true);
      }

      protected void S112( )
      {
         /* 'LOADVARIABLESFROMWIZARDDATA' Routine */
         returnInSub = false;
         AV32WizardData.FromJSonString(AV30WebSession.Get(AV31WebSessionKey), null);
         AV9ManagerEmail = AV32WizardData.gxTpr_Step2.gxTpr_Manageremail;
         AssignAttri(sPrefix, false, "AV9ManagerEmail", AV9ManagerEmail);
         AV14ManagerInitials = AV32WizardData.gxTpr_Step2.gxTpr_Managerinitials;
         AssignAttri(sPrefix, false, "AV14ManagerInitials", AV14ManagerInitials);
         AV16ManagerPhone = AV32WizardData.gxTpr_Step2.gxTpr_Managerphone;
         AssignAttri(sPrefix, false, "AV16ManagerPhone", AV16ManagerPhone);
         AV43ManagerIsMainManager = AV32WizardData.gxTpr_Step2.gxTpr_Managerismainmanager;
         AssignAttri(sPrefix, false, "AV43ManagerIsMainManager", AV43ManagerIsMainManager);
         AV52ManagerPhoneNumber = AV32WizardData.gxTpr_Step2.gxTpr_Managerphonenumber;
         AssignAttri(sPrefix, false, "AV52ManagerPhoneNumber", AV52ManagerPhoneNumber);
         AV49ManagerPhoneCode = AV32WizardData.gxTpr_Step2.gxTpr_Managerphonecode;
         AssignAttri(sPrefix, false, "AV49ManagerPhoneCode", AV49ManagerPhoneCode);
         AV13ManagerId = AV32WizardData.gxTpr_Step2.gxTpr_Managerid;
         AssignAttri(sPrefix, false, "AV13ManagerId", AV13ManagerId.ToString());
         AV10ManagerGAMGUID = AV32WizardData.gxTpr_Step2.gxTpr_Managergamguid;
         AssignAttri(sPrefix, false, "AV10ManagerGAMGUID", AV10ManagerGAMGUID);
         AV12ManagerGivenName = AV32WizardData.gxTpr_Step2.gxTpr_Managergivenname;
         AssignAttri(sPrefix, false, "AV12ManagerGivenName", AV12ManagerGivenName);
         AV15ManagerLastName = AV32WizardData.gxTpr_Step2.gxTpr_Managerlastname;
         AssignAttri(sPrefix, false, "AV15ManagerLastName", AV15ManagerLastName);
         AV11ManagerGender = AV32WizardData.gxTpr_Step2.gxTpr_Managergender;
         AssignAttri(sPrefix, false, "AV11ManagerGender", AV11ManagerGender);
         AV26SDT_Managers = AV32WizardData.gxTpr_Step2.gxTpr_Sdt_managers;
         gx_BV77 = true;
      }

      protected void S142( )
      {
         /* 'SAVEVARIABLESTOWIZARDDATA' Routine */
         returnInSub = false;
         AV32WizardData.FromJSonString(AV30WebSession.Get(AV31WebSessionKey), null);
         AV32WizardData.gxTpr_Step2.gxTpr_Manageremail = AV9ManagerEmail;
         AV32WizardData.gxTpr_Step2.gxTpr_Managerinitials = AV14ManagerInitials;
         AV32WizardData.gxTpr_Step2.gxTpr_Managerphone = AV16ManagerPhone;
         AV32WizardData.gxTpr_Step2.gxTpr_Managerismainmanager = AV43ManagerIsMainManager;
         AV32WizardData.gxTpr_Step2.gxTpr_Managerphonenumber = AV52ManagerPhoneNumber;
         AV32WizardData.gxTpr_Step2.gxTpr_Managerphonecode = AV49ManagerPhoneCode;
         AV32WizardData.gxTpr_Step2.gxTpr_Managerid = AV13ManagerId;
         AV32WizardData.gxTpr_Step2.gxTpr_Managergamguid = AV10ManagerGAMGUID;
         AV32WizardData.gxTpr_Step2.gxTpr_Managergivenname = AV12ManagerGivenName;
         AV32WizardData.gxTpr_Step2.gxTpr_Managerlastname = AV15ManagerLastName;
         AV32WizardData.gxTpr_Step2.gxTpr_Managergender = AV11ManagerGender;
         AV32WizardData.gxTpr_Step2.gxTpr_Sdt_managers = AV26SDT_Managers;
         AV30WebSession.Set(AV31WebSessionKey, AV32WizardData.ToJSonString(false, true));
      }

      protected void S162( )
      {
         /* 'DO UEDIT' Routine */
         returnInSub = false;
         AV12ManagerGivenName = ((SdtSDT_Managers_SDT_ManagersItem)(AV26SDT_Managers.CurrentItem)).gxTpr_Managergivenname;
         AssignAttri(sPrefix, false, "AV12ManagerGivenName", AV12ManagerGivenName);
         AV15ManagerLastName = ((SdtSDT_Managers_SDT_ManagersItem)(AV26SDT_Managers.CurrentItem)).gxTpr_Managerlastname;
         AssignAttri(sPrefix, false, "AV15ManagerLastName", AV15ManagerLastName);
         AV9ManagerEmail = ((SdtSDT_Managers_SDT_ManagersItem)(AV26SDT_Managers.CurrentItem)).gxTpr_Manageremail;
         AssignAttri(sPrefix, false, "AV9ManagerEmail", AV9ManagerEmail);
         AV11ManagerGender = ((SdtSDT_Managers_SDT_ManagersItem)(AV26SDT_Managers.CurrentItem)).gxTpr_Managergender;
         AssignAttri(sPrefix, false, "AV11ManagerGender", AV11ManagerGender);
         AV49ManagerPhoneCode = ((SdtSDT_Managers_SDT_ManagersItem)(AV26SDT_Managers.CurrentItem)).gxTpr_Managerphonecode;
         AssignAttri(sPrefix, false, "AV49ManagerPhoneCode", AV49ManagerPhoneCode);
         AV52ManagerPhoneNumber = ((SdtSDT_Managers_SDT_ManagersItem)(AV26SDT_Managers.CurrentItem)).gxTpr_Managerphonenumber;
         AssignAttri(sPrefix, false, "AV52ManagerPhoneNumber", AV52ManagerPhoneNumber);
         AV43ManagerIsMainManager = ((SdtSDT_Managers_SDT_ManagersItem)(AV26SDT_Managers.CurrentItem)).gxTpr_Managerismainmanager;
         AssignAttri(sPrefix, false, "AV43ManagerIsMainManager", AV43ManagerIsMainManager);
         AV56IndexToEdit = (short)(AV26SDT_Managers.IndexOf(((SdtSDT_Managers_SDT_ManagersItem)(AV26SDT_Managers.CurrentItem))));
         if ( AV56IndexToEdit == AV26SDT_Managers.Count )
         {
            AV26SDT_Managers.RemoveItem(AV56IndexToEdit);
            gx_BV77 = true;
            AV32WizardData.gxTpr_Step2.gxTpr_Sdt_managers = AV26SDT_Managers;
         }
         else
         {
            AV26SDT_Managers.RemoveItem(AV56IndexToEdit);
            gx_BV77 = true;
            AV32WizardData.gxTpr_Step2.gxTpr_Sdt_managers = AV26SDT_Managers;
         }
      }

      protected void S172( )
      {
         /* 'DO UDELETE' Routine */
         returnInSub = false;
         AV57IndexToDelete = (short)(AV26SDT_Managers.IndexOf(((SdtSDT_Managers_SDT_ManagersItem)(AV26SDT_Managers.CurrentItem))));
         AV26SDT_Managers.RemoveItem(AV57IndexToDelete);
         gx_BV77 = true;
         AV32WizardData.gxTpr_Step2.gxTpr_Sdt_managers = AV26SDT_Managers;
      }

      protected void S152( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV33CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV33CheckRequiredFieldsResult", AV33CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12ManagerGivenName)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "First Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavManagergivenname_Internalname,  "true",  ""));
            AV33CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV33CheckRequiredFieldsResult", AV33CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15ManagerLastName)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Last Name", ""), "", "", "", "", "", "", "", ""),  "error",  edtavManagerlastname_Internalname,  "true",  ""));
            AV33CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV33CheckRequiredFieldsResult", AV33CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9ManagerEmail)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""),  "error",  edtavManageremail_Internalname,  "true",  ""));
            AV33CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV33CheckRequiredFieldsResult", AV33CheckRequiredFieldsResult);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9ManagerEmail)) && ! GxRegex.IsMatch(AV9ManagerEmail,context.GetMessage( "^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$", "")) )
         {
            AV33CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV33CheckRequiredFieldsResult", AV33CheckRequiredFieldsResult);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52ManagerPhoneNumber)) && ! GxRegex.IsMatch(AV52ManagerPhoneNumber,context.GetMessage( "\\b\\d{9}\\b", "")) )
         {
            AV33CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV33CheckRequiredFieldsResult", AV33CheckRequiredFieldsResult);
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOMANAGERPHONECODE' Routine */
         returnInSub = false;
         AV89GXV16 = 1;
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = AV88GXV15;
         new dp_country(context ).execute( out  GXt_objcol_SdtSDT_Country_SDT_CountryItem3) ;
         AV88GXV15 = GXt_objcol_SdtSDT_Country_SDT_CountryItem3;
         while ( AV89GXV16 <= AV88GXV15.Count )
         {
            AV51ManagerPhoneCode_DPItem = ((SdtSDT_Country_SDT_CountryItem)AV88GXV15.Item(AV89GXV16));
            AV44Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
            AV44Combo_DataItem.gxTpr_Id = AV51ManagerPhoneCode_DPItem.gxTpr_Countrydialcode;
            AV46ComboTitles = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV46ComboTitles.Add(AV51ManagerPhoneCode_DPItem.gxTpr_Countrydialcode, 0);
            AV46ComboTitles.Add(AV51ManagerPhoneCode_DPItem.gxTpr_Countryflag, 0);
            AV44Combo_DataItem.gxTpr_Title = AV46ComboTitles.ToJSonString(false);
            AV50ManagerPhoneCode_Data.Add(AV44Combo_DataItem, 0);
            AV89GXV16 = (int)(AV89GXV16+1);
         }
         AV50ManagerPhoneCode_Data.Sort("Title");
         Combo_managerphonecode_Selectedvalue_set = AV49ManagerPhoneCode;
         ucCombo_managerphonecode.SendProperty(context, sPrefix, false, Combo_managerphonecode_Internalname, "SelectedValue_set", Combo_managerphonecode_Selectedvalue_set);
      }

      protected void E143Z2( )
      {
         /* Manageremail_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! GxRegex.IsMatch(AV9ManagerEmail,context.GetMessage( "^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$", "")) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "Email is incorrect", ""),  "error",  edtavManageremail_Internalname,  "true",  ""));
            AV33CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV33CheckRequiredFieldsResult", AV33CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void E153Z2( )
      {
         /* Managerphonenumber_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! GxRegex.IsMatch(AV52ManagerPhoneNumber,context.GetMessage( "\\b\\d{9}\\b", "")) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV52ManagerPhoneNumber)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "Phone contains 9 digits", ""),  "error",  edtavManagerphonenumber_Internalname,  "true",  ""));
            AV33CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV33CheckRequiredFieldsResult", AV33CheckRequiredFieldsResult);
         }
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'CHECKHASMAINMANAGER' Routine */
         returnInSub = false;
         AV70hasMainManager = false;
         AssignAttri(sPrefix, false, "AV70hasMainManager", AV70hasMainManager);
         AV90GXV17 = 1;
         while ( AV90GXV17 <= AV26SDT_Managers.Count )
         {
            AV25SDT_Manager = ((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV90GXV17));
            if ( AV25SDT_Manager.gxTpr_Managerismainmanager )
            {
               AV70hasMainManager = true;
               AssignAttri(sPrefix, false, "AV70hasMainManager", AV70hasMainManager);
            }
            AV90GXV17 = (int)(AV90GXV17+1);
         }
      }

      protected void S192( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV91GXV18 = 1;
         while ( AV91GXV18 <= AV35ErrorMessages.Count )
         {
            AV34Error = ((GeneXus.Utils.SdtMessages_Message)AV35ErrorMessages.Item(AV91GXV18));
            GX_msglist.addItem(context.GetMessage( "Error: ", "")+AV34Error.gxTpr_Description);
            AV91GXV18 = (int)(AV91GXV18+1);
         }
         AV35ErrorMessages.Clear();
      }

      protected void S182( )
      {
         /* 'CLEARFORMVALUES' Routine */
         returnInSub = false;
         AV13ManagerId = Guid.Empty;
         AssignAttri(sPrefix, false, "AV13ManagerId", AV13ManagerId.ToString());
         AV10ManagerGAMGUID = "";
         AssignAttri(sPrefix, false, "AV10ManagerGAMGUID", AV10ManagerGAMGUID);
         AV12ManagerGivenName = "";
         AssignAttri(sPrefix, false, "AV12ManagerGivenName", AV12ManagerGivenName);
         AV15ManagerLastName = "";
         AssignAttri(sPrefix, false, "AV15ManagerLastName", AV15ManagerLastName);
         AV9ManagerEmail = "";
         AssignAttri(sPrefix, false, "AV9ManagerEmail", AV9ManagerEmail);
         AV11ManagerGender = "";
         AssignAttri(sPrefix, false, "AV11ManagerGender", AV11ManagerGender);
         AV14ManagerInitials = "";
         AssignAttri(sPrefix, false, "AV14ManagerInitials", AV14ManagerInitials);
         AV16ManagerPhone = "";
         AssignAttri(sPrefix, false, "AV16ManagerPhone", AV16ManagerPhone);
         AV52ManagerPhoneNumber = "";
         AssignAttri(sPrefix, false, "AV52ManagerPhoneNumber", AV52ManagerPhoneNumber);
         AV43ManagerIsMainManager = false;
         AssignAttri(sPrefix, false, "AV43ManagerIsMainManager", AV43ManagerIsMainManager);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV31WebSessionKey = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV31WebSessionKey", AV31WebSessionKey);
         AV24PreviousStep = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV24PreviousStep", AV24PreviousStep);
         AV6GoingBack = (bool)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV6GoingBack", AV6GoingBack);
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
         PA3Z2( ) ;
         WS3Z2( ) ;
         WE3Z2( ) ;
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
         sCtrlAV31WebSessionKey = (string)((string)getParm(obj,0));
         sCtrlAV24PreviousStep = (string)((string)getParm(obj,1));
         sCtrlAV6GoingBack = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3Z2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wp_createorganisationandmanagerstep2", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3Z2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV31WebSessionKey = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV31WebSessionKey", AV31WebSessionKey);
            AV24PreviousStep = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV24PreviousStep", AV24PreviousStep);
            AV6GoingBack = (bool)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV6GoingBack", AV6GoingBack);
         }
         wcpOAV31WebSessionKey = cgiGet( sPrefix+"wcpOAV31WebSessionKey");
         wcpOAV24PreviousStep = cgiGet( sPrefix+"wcpOAV24PreviousStep");
         wcpOAV6GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV6GoingBack"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV31WebSessionKey, wcpOAV31WebSessionKey) != 0 ) || ( StringUtil.StrCmp(AV24PreviousStep, wcpOAV24PreviousStep) != 0 ) || ( AV6GoingBack != wcpOAV6GoingBack ) ) )
         {
            setjustcreated();
         }
         wcpOAV31WebSessionKey = AV31WebSessionKey;
         wcpOAV24PreviousStep = AV24PreviousStep;
         wcpOAV6GoingBack = AV6GoingBack;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV31WebSessionKey = cgiGet( sPrefix+"AV31WebSessionKey_CTRL");
         if ( StringUtil.Len( sCtrlAV31WebSessionKey) > 0 )
         {
            AV31WebSessionKey = cgiGet( sCtrlAV31WebSessionKey);
            AssignAttri(sPrefix, false, "AV31WebSessionKey", AV31WebSessionKey);
         }
         else
         {
            AV31WebSessionKey = cgiGet( sPrefix+"AV31WebSessionKey_PARM");
         }
         sCtrlAV24PreviousStep = cgiGet( sPrefix+"AV24PreviousStep_CTRL");
         if ( StringUtil.Len( sCtrlAV24PreviousStep) > 0 )
         {
            AV24PreviousStep = cgiGet( sCtrlAV24PreviousStep);
            AssignAttri(sPrefix, false, "AV24PreviousStep", AV24PreviousStep);
         }
         else
         {
            AV24PreviousStep = cgiGet( sPrefix+"AV24PreviousStep_PARM");
         }
         sCtrlAV6GoingBack = cgiGet( sPrefix+"AV6GoingBack_CTRL");
         if ( StringUtil.Len( sCtrlAV6GoingBack) > 0 )
         {
            AV6GoingBack = StringUtil.StrToBool( cgiGet( sCtrlAV6GoingBack));
            AssignAttri(sPrefix, false, "AV6GoingBack", AV6GoingBack);
         }
         else
         {
            AV6GoingBack = StringUtil.StrToBool( cgiGet( sPrefix+"AV6GoingBack_PARM"));
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
         PA3Z2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3Z2( ) ;
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
         WS3Z2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV31WebSessionKey_PARM", AV31WebSessionKey);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV31WebSessionKey)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV31WebSessionKey_CTRL", StringUtil.RTrim( sCtrlAV31WebSessionKey));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV24PreviousStep_PARM", AV24PreviousStep);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV24PreviousStep)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV24PreviousStep_CTRL", StringUtil.RTrim( sCtrlAV24PreviousStep));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6GoingBack_PARM", StringUtil.BoolToStr( AV6GoingBack));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6GoingBack)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6GoingBack_CTRL", StringUtil.RTrim( sCtrlAV6GoingBack));
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
         WE3Z2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025630937069", true, true);
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
         context.AddJavascriptSource("wp_createorganisationandmanagerstep2.js", "?2025630937071", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_772( )
      {
         edtavSdt_managers__managerid_Internalname = sPrefix+"SDT_MANAGERS__MANAGERID_"+sGXsfl_77_idx;
         edtavSdt_managers__organisationid_Internalname = sPrefix+"SDT_MANAGERS__ORGANISATIONID_"+sGXsfl_77_idx;
         edtavSdt_managers__managergivenname_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGIVENNAME_"+sGXsfl_77_idx;
         edtavSdt_managers__managerlastname_Internalname = sPrefix+"SDT_MANAGERS__MANAGERLASTNAME_"+sGXsfl_77_idx;
         edtavSdt_managers__managerinitials_Internalname = sPrefix+"SDT_MANAGERS__MANAGERINITIALS_"+sGXsfl_77_idx;
         edtavSdt_managers__manageremail_Internalname = sPrefix+"SDT_MANAGERS__MANAGEREMAIL_"+sGXsfl_77_idx;
         edtavSdt_managers__managerphone_Internalname = sPrefix+"SDT_MANAGERS__MANAGERPHONE_"+sGXsfl_77_idx;
         edtavSdt_managers__managerphonecode_Internalname = sPrefix+"SDT_MANAGERS__MANAGERPHONECODE_"+sGXsfl_77_idx;
         edtavSdt_managers__managerphonenumber_Internalname = sPrefix+"SDT_MANAGERS__MANAGERPHONENUMBER_"+sGXsfl_77_idx;
         cmbavSdt_managers__managergender_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGENDER_"+sGXsfl_77_idx;
         edtavSdt_managers__managergamguid_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGAMGUID_"+sGXsfl_77_idx;
         chkavSdt_managers__managerismainmanager_Internalname = sPrefix+"SDT_MANAGERS__MANAGERISMAINMANAGER_"+sGXsfl_77_idx;
         cmbavGridactiongroup_Internalname = sPrefix+"vGRIDACTIONGROUP_"+sGXsfl_77_idx;
      }

      protected void SubsflControlProps_fel_772( )
      {
         edtavSdt_managers__managerid_Internalname = sPrefix+"SDT_MANAGERS__MANAGERID_"+sGXsfl_77_fel_idx;
         edtavSdt_managers__organisationid_Internalname = sPrefix+"SDT_MANAGERS__ORGANISATIONID_"+sGXsfl_77_fel_idx;
         edtavSdt_managers__managergivenname_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGIVENNAME_"+sGXsfl_77_fel_idx;
         edtavSdt_managers__managerlastname_Internalname = sPrefix+"SDT_MANAGERS__MANAGERLASTNAME_"+sGXsfl_77_fel_idx;
         edtavSdt_managers__managerinitials_Internalname = sPrefix+"SDT_MANAGERS__MANAGERINITIALS_"+sGXsfl_77_fel_idx;
         edtavSdt_managers__manageremail_Internalname = sPrefix+"SDT_MANAGERS__MANAGEREMAIL_"+sGXsfl_77_fel_idx;
         edtavSdt_managers__managerphone_Internalname = sPrefix+"SDT_MANAGERS__MANAGERPHONE_"+sGXsfl_77_fel_idx;
         edtavSdt_managers__managerphonecode_Internalname = sPrefix+"SDT_MANAGERS__MANAGERPHONECODE_"+sGXsfl_77_fel_idx;
         edtavSdt_managers__managerphonenumber_Internalname = sPrefix+"SDT_MANAGERS__MANAGERPHONENUMBER_"+sGXsfl_77_fel_idx;
         cmbavSdt_managers__managergender_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGENDER_"+sGXsfl_77_fel_idx;
         edtavSdt_managers__managergamguid_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGAMGUID_"+sGXsfl_77_fel_idx;
         chkavSdt_managers__managerismainmanager_Internalname = sPrefix+"SDT_MANAGERS__MANAGERISMAINMANAGER_"+sGXsfl_77_fel_idx;
         cmbavGridactiongroup_Internalname = sPrefix+"vGRIDACTIONGROUP_"+sGXsfl_77_fel_idx;
      }

      protected void sendrow_772( )
      {
         sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
         SubsflControlProps_772( ) ;
         WB3Z0( ) ;
         if ( ( subGridsdt_managerss_Rows * 1 == 0 ) || ( nGXsfl_77_idx <= subGridsdt_managerss_fnc_Recordsperpage( ) * 1 ) )
         {
            Gridsdt_managerssRow = GXWebRow.GetNew(context,Gridsdt_managerssContainer);
            if ( subGridsdt_managerss_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridsdt_managerss_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridsdt_managerss_Class, "") != 0 )
               {
                  subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"Odd";
               }
            }
            else if ( subGridsdt_managerss_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridsdt_managerss_Backstyle = 0;
               subGridsdt_managerss_Backcolor = subGridsdt_managerss_Allbackcolor;
               if ( StringUtil.StrCmp(subGridsdt_managerss_Class, "") != 0 )
               {
                  subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"Uniform";
               }
            }
            else if ( subGridsdt_managerss_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridsdt_managerss_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridsdt_managerss_Class, "") != 0 )
               {
                  subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"Odd";
               }
               subGridsdt_managerss_Backcolor = (int)(0x0);
            }
            else if ( subGridsdt_managerss_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridsdt_managerss_Backstyle = 1;
               if ( ((int)((nGXsfl_77_idx) % (2))) == 0 )
               {
                  subGridsdt_managerss_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdt_managerss_Class, "") != 0 )
                  {
                     subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"Even";
                  }
               }
               else
               {
                  subGridsdt_managerss_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridsdt_managerss_Class, "") != 0 )
                  {
                     subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"Odd";
                  }
               }
            }
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_77_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__managerid_Internalname,((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1)).gxTpr_Managerid.ToString(),((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1)).gxTpr_Managerid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__managerid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_managers__managerid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)77,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__organisationid_Internalname,((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1)).gxTpr_Organisationid.ToString(),((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1)).gxTpr_Organisationid.ToString(),""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__organisationid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_managers__organisationid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)77,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'" + sPrefix + "',false,'" + sGXsfl_77_idx + "',77)\"";
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__managergivenname_Internalname,((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1)).gxTpr_Managergivenname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__managergivenname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_managers__managergivenname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'" + sGXsfl_77_idx + "',77)\"";
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__managerlastname_Internalname,((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1)).gxTpr_Managerlastname,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__managerlastname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_managers__managerlastname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__managerinitials_Internalname,StringUtil.RTrim( ((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1)).gxTpr_Managerinitials),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__managerinitials_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_managers__managerinitials_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'" + sPrefix + "',false,'" + sGXsfl_77_idx + "',77)\"";
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__manageremail_Internalname,((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1)).gxTpr_Manageremail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__manageremail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_managers__manageremail_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'" + sGXsfl_77_idx + "',77)\"";
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__managerphone_Internalname,StringUtil.RTrim( ((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1)).gxTpr_Managerphone),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__managerphone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdt_managers__managerphone_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__managerphonecode_Internalname,((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1)).gxTpr_Managerphonecode,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__managerphonecode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_managers__managerphonecode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__managerphonenumber_Internalname,((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1)).gxTpr_Managerphonenumber,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__managerphonenumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_managers__managerphonenumber_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'" + sPrefix + "',false,'" + sGXsfl_77_idx + "',77)\"";
            if ( ( cmbavSdt_managers__managergender.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SDT_MANAGERS__MANAGERGENDER_" + sGXsfl_77_idx;
               cmbavSdt_managers__managergender.Name = GXCCtl;
               cmbavSdt_managers__managergender.WebTags = "";
               cmbavSdt_managers__managergender.addItem("Male", context.GetMessage( "Male", ""), 0);
               cmbavSdt_managers__managergender.addItem("Female", context.GetMessage( "Female", ""), 0);
               cmbavSdt_managers__managergender.addItem("Other", context.GetMessage( "Other", ""), 0);
               if ( cmbavSdt_managers__managergender.ItemCount > 0 )
               {
                  if ( ( AV73GXV1 > 0 ) && ( AV26SDT_Managers.Count >= AV73GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1)).gxTpr_Managergender)) )
                  {
                     ((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1)).gxTpr_Managergender = cmbavSdt_managers__managergender.getValidValue(((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1)).gxTpr_Managergender);
                  }
               }
            }
            /* ComboBox */
            Gridsdt_managerssRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavSdt_managers__managergender,(string)cmbavSdt_managers__managergender_Internalname,StringUtil.RTrim( ((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1)).gxTpr_Managergender),(short)1,(string)cmbavSdt_managers__managergender_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbavSdt_managers__managergender.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"",(string)"",(bool)true,(short)0});
            cmbavSdt_managers__managergender.CurrentValue = StringUtil.RTrim( ((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1)).gxTpr_Managergender);
            AssignProp(sPrefix, false, cmbavSdt_managers__managergender_Internalname, "Values", (string)(cmbavSdt_managers__managergender.ToJavascriptSource()), !bGXsfl_77_Refreshing);
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Gridsdt_managerssRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdt_managers__managergamguid_Internalname,((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1)).gxTpr_Managergamguid,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdt_managers__managergamguid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdt_managers__managergamguid_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)77,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'" + sPrefix + "',false,'" + sGXsfl_77_idx + "',77)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "SDT_MANAGERS__MANAGERISMAINMANAGER_" + sGXsfl_77_idx;
            chkavSdt_managers__managerismainmanager.Name = GXCCtl;
            chkavSdt_managers__managerismainmanager.WebTags = "";
            chkavSdt_managers__managerismainmanager.Caption = "";
            AssignProp(sPrefix, false, chkavSdt_managers__managerismainmanager_Internalname, "TitleCaption", chkavSdt_managers__managerismainmanager.Caption, !bGXsfl_77_Refreshing);
            chkavSdt_managers__managerismainmanager.CheckedValue = "false";
            Gridsdt_managerssRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavSdt_managers__managerismainmanager_Internalname,StringUtil.BoolToStr( ((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1)).gxTpr_Managerismainmanager),(string)"",(string)"",(short)-1,chkavSdt_managers__managerismainmanager.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(89, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,89);\""});
            /* Subfile cell */
            if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'" + sPrefix + "',false,'" + sGXsfl_77_idx + "',77)\"";
            if ( ( cmbavGridactiongroup.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONGROUP_" + sGXsfl_77_idx;
               cmbavGridactiongroup.Name = GXCCtl;
               cmbavGridactiongroup.WebTags = "";
               if ( cmbavGridactiongroup.ItemCount > 0 )
               {
                  if ( ( AV73GXV1 > 0 ) && ( AV26SDT_Managers.Count >= AV73GXV1 ) && (0==AV71GridActionGroup) )
                  {
                     AV71GridActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV71GridActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
                     AssignAttri(sPrefix, false, cmbavGridactiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV71GridActionGroup), 4, 0));
                  }
               }
            }
            /* ComboBox */
            Gridsdt_managerssRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactiongroup,(string)cmbavGridactiongroup_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV71GridActionGroup), 4, 0)),(short)1,(string)cmbavGridactiongroup_Jsonclick,(short)5,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVGRIDACTIONGROUP.CLICK."+sGXsfl_77_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"",(string)"",(bool)true,(short)0});
            cmbavGridactiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV71GridActionGroup), 4, 0));
            AssignProp(sPrefix, false, cmbavGridactiongroup_Internalname, "Values", (string)(cmbavGridactiongroup.ToJavascriptSource()), !bGXsfl_77_Refreshing);
            send_integrity_lvl_hashes3Z2( ) ;
            Gridsdt_managerssContainer.AddRow(Gridsdt_managerssRow);
            nGXsfl_77_idx = ((subGridsdt_managerss_Islastpage==1)&&(nGXsfl_77_idx+1>subGridsdt_managerss_fnc_Recordsperpage( )) ? 1 : nGXsfl_77_idx+1);
            sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
            SubsflControlProps_772( ) ;
         }
         /* End function sendrow_772 */
      }

      protected void init_web_controls( )
      {
         cmbavManagergender.Name = "vMANAGERGENDER";
         cmbavManagergender.WebTags = "";
         cmbavManagergender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbavManagergender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbavManagergender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbavManagergender.ItemCount > 0 )
         {
         }
         chkavManagerismainmanager.Name = "vMANAGERISMAINMANAGER";
         chkavManagerismainmanager.WebTags = "";
         chkavManagerismainmanager.Caption = context.GetMessage( "Is Main Manager?", "");
         AssignProp(sPrefix, false, chkavManagerismainmanager_Internalname, "TitleCaption", chkavManagerismainmanager.Caption, true);
         chkavManagerismainmanager.CheckedValue = "false";
         GXCCtl = "SDT_MANAGERS__MANAGERGENDER_" + sGXsfl_77_idx;
         cmbavSdt_managers__managergender.Name = GXCCtl;
         cmbavSdt_managers__managergender.WebTags = "";
         cmbavSdt_managers__managergender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbavSdt_managers__managergender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbavSdt_managers__managergender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbavSdt_managers__managergender.ItemCount > 0 )
         {
            if ( ( AV73GXV1 > 0 ) && ( AV26SDT_Managers.Count >= AV73GXV1 ) && String.IsNullOrEmpty(StringUtil.RTrim( ((SdtSDT_Managers_SDT_ManagersItem)AV26SDT_Managers.Item(AV73GXV1)).gxTpr_Managergender)) )
            {
            }
         }
         GXCCtl = "SDT_MANAGERS__MANAGERISMAINMANAGER_" + sGXsfl_77_idx;
         chkavSdt_managers__managerismainmanager.Name = GXCCtl;
         chkavSdt_managers__managerismainmanager.WebTags = "";
         chkavSdt_managers__managerismainmanager.Caption = "";
         AssignProp(sPrefix, false, chkavSdt_managers__managerismainmanager_Internalname, "TitleCaption", chkavSdt_managers__managerismainmanager.Caption, !bGXsfl_77_Refreshing);
         chkavSdt_managers__managerismainmanager.CheckedValue = "false";
         GXCCtl = "vGRIDACTIONGROUP_" + sGXsfl_77_idx;
         cmbavGridactiongroup.Name = GXCCtl;
         cmbavGridactiongroup.WebTags = "";
         if ( cmbavGridactiongroup.ItemCount > 0 )
         {
            if ( ( AV73GXV1 > 0 ) && ( AV26SDT_Managers.Count >= AV73GXV1 ) && (0==AV71GridActionGroup) )
            {
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl77( )
      {
         if ( Gridsdt_managerssContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"Gridsdt_managerssContainer"+"DivS\" data-gxgridid=\"77\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridsdt_managerss_Internalname, subGridsdt_managerss_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridsdt_managerss_Backcolorstyle == 0 )
            {
               subGridsdt_managerss_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridsdt_managerss_Class) > 0 )
               {
                  subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"Title";
               }
            }
            else
            {
               subGridsdt_managerss_Titlebackstyle = 1;
               if ( subGridsdt_managerss_Backcolorstyle == 1 )
               {
                  subGridsdt_managerss_Titlebackcolor = subGridsdt_managerss_Allbackcolor;
                  if ( StringUtil.Len( subGridsdt_managerss_Class) > 0 )
                  {
                     subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridsdt_managerss_Class) > 0 )
                  {
                     subGridsdt_managerss_Linesclass = subGridsdt_managerss_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Manager Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Organisation Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "First Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Last Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Initials", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Manager Phone Code", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Manager Phone Number", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Gender", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Manager GAMGUID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Is Main Manager", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Gridsdt_managerssContainer.AddObjectProperty("GridName", "Gridsdt_managerss");
         }
         else
         {
            Gridsdt_managerssContainer.AddObjectProperty("GridName", "Gridsdt_managerss");
            Gridsdt_managerssContainer.AddObjectProperty("Header", subGridsdt_managerss_Header);
            Gridsdt_managerssContainer.AddObjectProperty("Class", "WorkWith");
            Gridsdt_managerssContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Backcolorstyle), 1, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("CmpContext", sPrefix);
            Gridsdt_managerssContainer.AddObjectProperty("InMasterPage", "false");
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__managerid_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__organisationid_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__managergivenname_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__managerlastname_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__managerinitials_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__manageremail_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__managerphone_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__managerphonecode_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__managerphonenumber_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavSdt_managers__managergender.Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdt_managers__managergamguid_Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavSdt_managers__managerismainmanager.Enabled), 5, 0, ".", "")));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            Gridsdt_managerssColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV71GridActionGroup), 4, 0, ".", ""))));
            Gridsdt_managerssContainer.AddColumnProperties(Gridsdt_managerssColumn);
            Gridsdt_managerssContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Selectedindex), 4, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Allowselection), 1, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Selectioncolor), 9, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Allowhovering), 1, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Hoveringcolor), 9, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Allowcollapsing), 1, 0, ".", "")));
            Gridsdt_managerssContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsdt_managerss_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavManagergivenname_Internalname = sPrefix+"vMANAGERGIVENNAME";
         edtavManagerlastname_Internalname = sPrefix+"vMANAGERLASTNAME";
         cmbavManagergender_Internalname = sPrefix+"vMANAGERGENDER";
         divUnnamedtable5_Internalname = sPrefix+"UNNAMEDTABLE5";
         edtavManageremail_Internalname = sPrefix+"vMANAGEREMAIL";
         lblPhonelabel_Internalname = sPrefix+"PHONELABEL";
         Combo_managerphonecode_Internalname = sPrefix+"COMBO_MANAGERPHONECODE";
         divUnnamedtable9_Internalname = sPrefix+"UNNAMEDTABLE9";
         edtavManagerphonenumber_Internalname = sPrefix+"vMANAGERPHONENUMBER";
         divUnnamedtable10_Internalname = sPrefix+"UNNAMEDTABLE10";
         divUnnamedtable8_Internalname = sPrefix+"UNNAMEDTABLE8";
         divUnnamedtable7_Internalname = sPrefix+"UNNAMEDTABLE7";
         chkavManagerismainmanager_Internalname = sPrefix+"vMANAGERISMAINMANAGER";
         divUnnamedtable6_Internalname = sPrefix+"UNNAMEDTABLE6";
         divUnnamedtable3_Internalname = sPrefix+"UNNAMEDTABLE3";
         grpUnnamedgroup4_Internalname = sPrefix+"UNNAMEDGROUP4";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         bttBtnuinsert_Internalname = sPrefix+"BTNUINSERT";
         divUnnamedtable2_Internalname = sPrefix+"UNNAMEDTABLE2";
         edtavSdt_managers__managerid_Internalname = sPrefix+"SDT_MANAGERS__MANAGERID";
         edtavSdt_managers__organisationid_Internalname = sPrefix+"SDT_MANAGERS__ORGANISATIONID";
         edtavSdt_managers__managergivenname_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGIVENNAME";
         edtavSdt_managers__managerlastname_Internalname = sPrefix+"SDT_MANAGERS__MANAGERLASTNAME";
         edtavSdt_managers__managerinitials_Internalname = sPrefix+"SDT_MANAGERS__MANAGERINITIALS";
         edtavSdt_managers__manageremail_Internalname = sPrefix+"SDT_MANAGERS__MANAGEREMAIL";
         edtavSdt_managers__managerphone_Internalname = sPrefix+"SDT_MANAGERS__MANAGERPHONE";
         edtavSdt_managers__managerphonecode_Internalname = sPrefix+"SDT_MANAGERS__MANAGERPHONECODE";
         edtavSdt_managers__managerphonenumber_Internalname = sPrefix+"SDT_MANAGERS__MANAGERPHONENUMBER";
         cmbavSdt_managers__managergender_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGENDER";
         edtavSdt_managers__managergamguid_Internalname = sPrefix+"SDT_MANAGERS__MANAGERGAMGUID";
         chkavSdt_managers__managerismainmanager_Internalname = sPrefix+"SDT_MANAGERS__MANAGERISMAINMANAGER";
         cmbavGridactiongroup_Internalname = sPrefix+"vGRIDACTIONGROUP";
         divTablegrid_Internalname = sPrefix+"TABLEGRID";
         Btnwizardprevious_Internalname = sPrefix+"BTNWIZARDPREVIOUS";
         Btnwizardnext_Internalname = sPrefix+"BTNWIZARDNEXT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtavManagerphonecode_Internalname = sPrefix+"vMANAGERPHONECODE";
         edtavManagerinitials_Internalname = sPrefix+"vMANAGERINITIALS";
         edtavManagerphone_Internalname = sPrefix+"vMANAGERPHONE";
         edtavManagerid_Internalname = sPrefix+"vMANAGERID";
         edtavManagergamguid_Internalname = sPrefix+"vMANAGERGAMGUID";
         Gridsdt_managerss_empowerer_Internalname = sPrefix+"GRIDSDT_MANAGERSS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGridsdt_managerss_Internalname = sPrefix+"GRIDSDT_MANAGERSS";
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
         subGridsdt_managerss_Allowcollapsing = 0;
         subGridsdt_managerss_Allowselection = 0;
         subGridsdt_managerss_Header = "";
         chkavManagerismainmanager.Caption = context.GetMessage( "Is Main Manager?", "");
         cmbavGridactiongroup_Jsonclick = "";
         chkavSdt_managers__managerismainmanager.Caption = "";
         chkavSdt_managers__managerismainmanager.Enabled = 0;
         edtavSdt_managers__managergamguid_Jsonclick = "";
         edtavSdt_managers__managergamguid_Enabled = 0;
         cmbavSdt_managers__managergender_Jsonclick = "";
         cmbavSdt_managers__managergender.Enabled = 0;
         edtavSdt_managers__managerphonenumber_Jsonclick = "";
         edtavSdt_managers__managerphonenumber_Enabled = 0;
         edtavSdt_managers__managerphonecode_Jsonclick = "";
         edtavSdt_managers__managerphonecode_Enabled = 0;
         edtavSdt_managers__managerphone_Jsonclick = "";
         edtavSdt_managers__managerphone_Enabled = 0;
         edtavSdt_managers__manageremail_Jsonclick = "";
         edtavSdt_managers__manageremail_Enabled = 0;
         edtavSdt_managers__managerinitials_Jsonclick = "";
         edtavSdt_managers__managerinitials_Enabled = 0;
         edtavSdt_managers__managerlastname_Jsonclick = "";
         edtavSdt_managers__managerlastname_Enabled = 0;
         edtavSdt_managers__managergivenname_Jsonclick = "";
         edtavSdt_managers__managergivenname_Enabled = 0;
         edtavSdt_managers__organisationid_Jsonclick = "";
         edtavSdt_managers__organisationid_Enabled = 0;
         edtavSdt_managers__managerid_Jsonclick = "";
         edtavSdt_managers__managerid_Enabled = 0;
         subGridsdt_managerss_Class = "WorkWith";
         subGridsdt_managerss_Backcolorstyle = 0;
         Combo_managerphonecode_Htmltemplate = "";
         edtavManagergamguid_Jsonclick = "";
         edtavManagergamguid_Visible = 1;
         edtavManagerid_Jsonclick = "";
         edtavManagerid_Visible = 1;
         edtavManagerphone_Jsonclick = "";
         edtavManagerphone_Visible = 1;
         edtavManagerinitials_Jsonclick = "";
         edtavManagerinitials_Visible = 1;
         edtavManagerphonecode_Jsonclick = "";
         edtavManagerphonecode_Visible = 1;
         Btnwizardnext_Class = "ButtonMaterial ButtonWizard";
         Btnwizardnext_Caption = context.GetMessage( "GXM_next", "");
         Btnwizardnext_Tooltiptext = "";
         Btnwizardprevious_Class = "ButtonMaterialDefault ButtonWizard";
         Btnwizardprevious_Caption = context.GetMessage( "GXM_previous", "");
         Btnwizardprevious_Tooltiptext = "";
         chkavManagerismainmanager.TooltipText = "";
         chkavManagerismainmanager.Enabled = 1;
         edtavManagerphonenumber_Jsonclick = "";
         edtavManagerphonenumber_Enabled = 1;
         Combo_managerphonecode_Emptyitem = Convert.ToBoolean( 0);
         Combo_managerphonecode_Cls = "ExtendedCombo DropDownComponent ExtendedComboWithImage";
         Combo_managerphonecode_Caption = "";
         edtavManageremail_Jsonclick = "";
         edtavManageremail_Enabled = 1;
         cmbavManagergender_Jsonclick = "";
         cmbavManagergender.Enabled = 1;
         edtavManagerlastname_Jsonclick = "";
         edtavManagerlastname_Enabled = 1;
         edtavManagergivenname_Jsonclick = "";
         edtavManagergivenname_Enabled = 1;
         chkavSdt_managers__managerismainmanager.Enabled = -1;
         edtavSdt_managers__managergamguid_Enabled = -1;
         cmbavSdt_managers__managergender.Enabled = -1;
         edtavSdt_managers__managerphonenumber_Enabled = -1;
         edtavSdt_managers__managerphonecode_Enabled = -1;
         edtavSdt_managers__managerphone_Enabled = -1;
         edtavSdt_managers__manageremail_Enabled = -1;
         edtavSdt_managers__managerinitials_Enabled = -1;
         edtavSdt_managers__managerlastname_Enabled = -1;
         edtavSdt_managers__managergivenname_Enabled = -1;
         edtavSdt_managers__organisationid_Enabled = -1;
         edtavSdt_managers__managerid_Enabled = -1;
         subGridsdt_managerss_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"AV26SDT_Managers","fld":"vSDT_MANAGERS","grid":77},{"av":"nGXsfl_77_idx","ctrl":"GRID","prop":"GridCurrRow","grid":77},{"av":"nRC_GXsfl_77","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":77},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV43ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"},{"av":"AV7HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]}""");
         setEventMetadata("GRIDSDT_MANAGERSS.LOAD","""{"handler":"E173Z2","iparms":[]""");
         setEventMetadata("GRIDSDT_MANAGERSS.LOAD",""","oparms":[{"av":"cmbavGridactiongroup"},{"av":"AV71GridActionGroup","fld":"vGRIDACTIONGROUP","pic":"ZZZ9"}]}""");
         setEventMetadata("ENTER","""{"handler":"E113Z2","iparms":[{"av":"AV26SDT_Managers","fld":"vSDT_MANAGERS","grid":77},{"av":"nGXsfl_77_idx","ctrl":"GRID","prop":"GridCurrRow","grid":77},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_77","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":77},{"av":"AV70hasMainManager","fld":"vHASMAINMANAGER"},{"av":"AV33CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV7HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV31WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV9ManagerEmail","fld":"vMANAGEREMAIL"},{"av":"AV14ManagerInitials","fld":"vMANAGERINITIALS"},{"av":"AV16ManagerPhone","fld":"vMANAGERPHONE"},{"av":"AV43ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"},{"av":"AV52ManagerPhoneNumber","fld":"vMANAGERPHONENUMBER"},{"av":"AV49ManagerPhoneCode","fld":"vMANAGERPHONECODE"},{"av":"AV13ManagerId","fld":"vMANAGERID"},{"av":"AV10ManagerGAMGUID","fld":"vMANAGERGAMGUID"},{"av":"AV12ManagerGivenName","fld":"vMANAGERGIVENNAME"},{"av":"AV15ManagerLastName","fld":"vMANAGERLASTNAME"},{"av":"cmbavManagergender"},{"av":"AV11ManagerGender","fld":"vMANAGERGENDER"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV70hasMainManager","fld":"vHASMAINMANAGER"},{"av":"AV32WizardData","fld":"vWIZARDDATA"},{"av":"AV33CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("'WIZARDPREVIOUS'","""{"handler":"E123Z2","iparms":[{"av":"AV31WebSessionKey","fld":"vWEBSESSIONKEY"},{"av":"AV9ManagerEmail","fld":"vMANAGEREMAIL"},{"av":"AV14ManagerInitials","fld":"vMANAGERINITIALS"},{"av":"AV16ManagerPhone","fld":"vMANAGERPHONE"},{"av":"AV43ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"},{"av":"AV52ManagerPhoneNumber","fld":"vMANAGERPHONENUMBER"},{"av":"AV49ManagerPhoneCode","fld":"vMANAGERPHONECODE"},{"av":"AV13ManagerId","fld":"vMANAGERID"},{"av":"AV10ManagerGAMGUID","fld":"vMANAGERGAMGUID"},{"av":"AV12ManagerGivenName","fld":"vMANAGERGIVENNAME"},{"av":"AV15ManagerLastName","fld":"vMANAGERLASTNAME"},{"av":"cmbavManagergender"},{"av":"AV11ManagerGender","fld":"vMANAGERGENDER"},{"av":"AV26SDT_Managers","fld":"vSDT_MANAGERS","grid":77},{"av":"nGXsfl_77_idx","ctrl":"GRID","prop":"GridCurrRow","grid":77},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_77","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":77}]""");
         setEventMetadata("'WIZARDPREVIOUS'",""","oparms":[{"av":"AV32WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("VGRIDACTIONGROUP.CLICK","""{"handler":"E183Z2","iparms":[{"av":"cmbavGridactiongroup"},{"av":"AV71GridActionGroup","fld":"vGRIDACTIONGROUP","pic":"ZZZ9"},{"av":"AV26SDT_Managers","fld":"vSDT_MANAGERS","grid":77},{"av":"nGXsfl_77_idx","ctrl":"GRID","prop":"GridCurrRow","grid":77},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_77","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":77},{"av":"AV32WizardData","fld":"vWIZARDDATA"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"sPrefix"},{"av":"AV43ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"},{"av":"AV7HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true}]""");
         setEventMetadata("VGRIDACTIONGROUP.CLICK",""","oparms":[{"av":"cmbavGridactiongroup"},{"av":"AV71GridActionGroup","fld":"vGRIDACTIONGROUP","pic":"ZZZ9"},{"av":"AV12ManagerGivenName","fld":"vMANAGERGIVENNAME"},{"av":"AV15ManagerLastName","fld":"vMANAGERLASTNAME"},{"av":"AV9ManagerEmail","fld":"vMANAGEREMAIL"},{"av":"cmbavManagergender"},{"av":"AV11ManagerGender","fld":"vMANAGERGENDER"},{"av":"AV49ManagerPhoneCode","fld":"vMANAGERPHONECODE"},{"av":"AV52ManagerPhoneNumber","fld":"vMANAGERPHONENUMBER"},{"av":"AV43ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"},{"av":"AV26SDT_Managers","fld":"vSDT_MANAGERS","grid":77},{"av":"nGXsfl_77_idx","ctrl":"GRID","prop":"GridCurrRow","grid":77},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_77","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":77},{"av":"AV32WizardData","fld":"vWIZARDDATA"}]}""");
         setEventMetadata("'DOUINSERT'","""{"handler":"E133Z2","iparms":[{"av":"AV33CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV7HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"AV9ManagerEmail","fld":"vMANAGEREMAIL"},{"av":"AV26SDT_Managers","fld":"vSDT_MANAGERS","grid":77},{"av":"nGXsfl_77_idx","ctrl":"GRID","prop":"GridCurrRow","grid":77},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_77","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":77},{"av":"A25ManagerEmail","fld":"MANAGEREMAIL"},{"av":"AV32WizardData","fld":"vWIZARDDATA"},{"av":"AV12ManagerGivenName","fld":"vMANAGERGIVENNAME"},{"av":"AV15ManagerLastName","fld":"vMANAGERLASTNAME"},{"av":"cmbavManagergender"},{"av":"AV11ManagerGender","fld":"vMANAGERGENDER"},{"av":"AV49ManagerPhoneCode","fld":"vMANAGERPHONECODE"},{"av":"AV52ManagerPhoneNumber","fld":"vMANAGERPHONENUMBER"},{"av":"AV43ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"sPrefix"}]""");
         setEventMetadata("'DOUINSERT'",""","oparms":[{"av":"AV32WizardData","fld":"vWIZARDDATA"},{"av":"AV26SDT_Managers","fld":"vSDT_MANAGERS","grid":77},{"av":"nGXsfl_77_idx","ctrl":"GRID","prop":"GridCurrRow","grid":77},{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"nRC_GXsfl_77","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":77},{"av":"AV33CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"},{"av":"AV13ManagerId","fld":"vMANAGERID"},{"av":"AV10ManagerGAMGUID","fld":"vMANAGERGAMGUID"},{"av":"AV12ManagerGivenName","fld":"vMANAGERGIVENNAME"},{"av":"AV15ManagerLastName","fld":"vMANAGERLASTNAME"},{"av":"AV9ManagerEmail","fld":"vMANAGEREMAIL"},{"av":"cmbavManagergender"},{"av":"AV11ManagerGender","fld":"vMANAGERGENDER"},{"av":"AV14ManagerInitials","fld":"vMANAGERINITIALS"},{"av":"AV16ManagerPhone","fld":"vMANAGERPHONE"},{"av":"AV52ManagerPhoneNumber","fld":"vMANAGERPHONENUMBER"},{"av":"AV43ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"}]}""");
         setEventMetadata("VMANAGEREMAIL.CONTROLVALUECHANGED","""{"handler":"E143Z2","iparms":[{"av":"AV9ManagerEmail","fld":"vMANAGEREMAIL"}]""");
         setEventMetadata("VMANAGEREMAIL.CONTROLVALUECHANGED",""","oparms":[{"av":"AV33CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("VMANAGERPHONENUMBER.CONTROLVALUECHANGED","""{"handler":"E153Z2","iparms":[{"av":"AV52ManagerPhoneNumber","fld":"vMANAGERPHONENUMBER"}]""");
         setEventMetadata("VMANAGERPHONENUMBER.CONTROLVALUECHANGED",""","oparms":[{"av":"AV33CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT"}]}""");
         setEventMetadata("GRIDSDT_MANAGERSS_FIRSTPAGE","""{"handler":"subgridsdt_managerss_firstpage","iparms":[{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"AV26SDT_Managers","fld":"vSDT_MANAGERS","grid":77},{"av":"nGXsfl_77_idx","ctrl":"GRID","prop":"GridCurrRow","grid":77},{"av":"nRC_GXsfl_77","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":77},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"AV7HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"AV43ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"}]}""");
         setEventMetadata("GRIDSDT_MANAGERSS_PREVPAGE","""{"handler":"subgridsdt_managerss_previouspage","iparms":[{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"AV26SDT_Managers","fld":"vSDT_MANAGERS","grid":77},{"av":"nGXsfl_77_idx","ctrl":"GRID","prop":"GridCurrRow","grid":77},{"av":"nRC_GXsfl_77","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":77},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"AV7HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"AV43ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"}]}""");
         setEventMetadata("GRIDSDT_MANAGERSS_NEXTPAGE","""{"handler":"subgridsdt_managerss_nextpage","iparms":[{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"AV26SDT_Managers","fld":"vSDT_MANAGERS","grid":77},{"av":"nGXsfl_77_idx","ctrl":"GRID","prop":"GridCurrRow","grid":77},{"av":"nRC_GXsfl_77","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":77},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"AV7HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"AV43ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"}]}""");
         setEventMetadata("GRIDSDT_MANAGERSS_LASTPAGE","""{"handler":"subgridsdt_managerss_lastpage","iparms":[{"av":"GRIDSDT_MANAGERSS_nFirstRecordOnPage"},{"av":"GRIDSDT_MANAGERSS_nEOF"},{"av":"AV26SDT_Managers","fld":"vSDT_MANAGERS","grid":77},{"av":"nGXsfl_77_idx","ctrl":"GRID","prop":"GridCurrRow","grid":77},{"av":"nRC_GXsfl_77","ctrl":"GRIDSDT_MANAGERSS","prop":"GridRC","grid":77},{"av":"subGridsdt_managerss_Rows","ctrl":"GRIDSDT_MANAGERSS","prop":"Rows"},{"av":"AV7HasValidationErrors","fld":"vHASVALIDATIONERRORS","hsh":true},{"av":"sPrefix"},{"av":"AV43ManagerIsMainManager","fld":"vMANAGERISMAINMANAGER"}]}""");
         setEventMetadata("VALIDV_MANAGERGENDER","""{"handler":"Validv_Managergender","iparms":[]}""");
         setEventMetadata("VALIDV_MANAGEREMAIL","""{"handler":"Validv_Manageremail","iparms":[]}""");
         setEventMetadata("VALIDV_MANAGERID","""{"handler":"Validv_Managerid","iparms":[]}""");
         setEventMetadata("VALIDV_GXV2","""{"handler":"Validv_Gxv2","iparms":[]}""");
         setEventMetadata("VALIDV_GXV3","""{"handler":"Validv_Gxv3","iparms":[]}""");
         setEventMetadata("VALIDV_GXV7","""{"handler":"Validv_Gxv7","iparms":[]}""");
         setEventMetadata("VALIDV_GXV11","""{"handler":"Validv_Gxv11","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gridactiongroup","iparms":[]}""");
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
         wcpOAV31WebSessionKey = "";
         wcpOAV24PreviousStep = "";
         Combo_managerphonecode_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV43ManagerIsMainManager = false;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV26SDT_Managers = new GXBaseCollection<SdtSDT_Managers_SDT_ManagersItem>( context, "SDT_ManagersItem", "Comforta_version2");
         AV47DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV50ManagerPhoneCode_Data = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV32WizardData = new SdtWP_CreateOrganisationAndManagerData(context);
         A25ManagerEmail = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV12ManagerGivenName = "";
         AV15ManagerLastName = "";
         AV11ManagerGender = "";
         AV9ManagerEmail = "";
         lblPhonelabel_Jsonclick = "";
         ucCombo_managerphonecode = new GXUserControl();
         AV52ManagerPhoneNumber = "";
         bttBtnuinsert_Jsonclick = "";
         Gridsdt_managerssContainer = new GXWebGrid( context);
         sStyleString = "";
         ucBtnwizardprevious = new GXUserControl();
         ucBtnwizardnext = new GXUserControl();
         AV49ManagerPhoneCode = "";
         AV14ManagerInitials = "";
         AV16ManagerPhone = "";
         AV13ManagerId = Guid.Empty;
         AV10ManagerGAMGUID = "";
         ucGridsdt_managerss_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV30WebSession = context.GetSession();
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Gridsdt_managerss_empowerer_Gridinternalname = "";
         AV48defaultCountryPhoneCode = "";
         Combo_managerphonecode_Selectedtext_set = "";
         Combo_managerphonecode_Selectedvalue_set = "";
         Gridsdt_managerssRow = new GXWebRow();
         AV37GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV36GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV25SDT_Manager = new SdtSDT_Managers_SDT_ManagersItem(context);
         H003Z2_A21ManagerId = new Guid[] {Guid.Empty} ;
         H003Z2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H003Z2_A25ManagerEmail = new string[] {""} ;
         GXt_char2 = "";
         AV88GXV15 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         GXt_objcol_SdtSDT_Country_SDT_CountryItem3 = new GXBaseCollection<SdtSDT_Country_SDT_CountryItem>( context, "SDT_CountryItem", "Comforta_version2");
         AV51ManagerPhoneCode_DPItem = new SdtSDT_Country_SDT_CountryItem(context);
         AV44Combo_DataItem = new WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item(context);
         AV46ComboTitles = new GxSimpleCollection<string>();
         AV35ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV34Error = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV31WebSessionKey = "";
         sCtrlAV24PreviousStep = "";
         sCtrlAV6GoingBack = "";
         subGridsdt_managerss_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         Gridsdt_managerssColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wp_createorganisationandmanagerstep2__default(),
            new Object[][] {
                new Object[] {
               H003Z2_A21ManagerId, H003Z2_A11OrganisationId, H003Z2_A25ManagerEmail
               }
            }
         );
         /* GeneXus formulas. */
         edtavSdt_managers__managerid_Enabled = 0;
         edtavSdt_managers__organisationid_Enabled = 0;
         edtavSdt_managers__managergivenname_Enabled = 0;
         edtavSdt_managers__managerlastname_Enabled = 0;
         edtavSdt_managers__managerinitials_Enabled = 0;
         edtavSdt_managers__manageremail_Enabled = 0;
         edtavSdt_managers__managerphone_Enabled = 0;
         edtavSdt_managers__managerphonecode_Enabled = 0;
         edtavSdt_managers__managerphonenumber_Enabled = 0;
         cmbavSdt_managers__managergender.Enabled = 0;
         edtavSdt_managers__managergamguid_Enabled = 0;
         chkavSdt_managers__managerismainmanager.Enabled = 0;
      }

      private short GRIDSDT_MANAGERSS_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV71GridActionGroup ;
      private short nDonePA ;
      private short subGridsdt_managerss_Backcolorstyle ;
      private short AV56IndexToEdit ;
      private short AV57IndexToDelete ;
      private short nGXWrapped ;
      private short subGridsdt_managerss_Backstyle ;
      private short subGridsdt_managerss_Titlebackstyle ;
      private short subGridsdt_managerss_Allowselection ;
      private short subGridsdt_managerss_Allowhovering ;
      private short subGridsdt_managerss_Allowcollapsing ;
      private short subGridsdt_managerss_Collapsed ;
      private int nRC_GXsfl_77 ;
      private int subGridsdt_managerss_Rows ;
      private int nGXsfl_77_idx=1 ;
      private int edtavSdt_managers__managerid_Enabled ;
      private int edtavSdt_managers__organisationid_Enabled ;
      private int edtavSdt_managers__managergivenname_Enabled ;
      private int edtavSdt_managers__managerlastname_Enabled ;
      private int edtavSdt_managers__managerinitials_Enabled ;
      private int edtavSdt_managers__manageremail_Enabled ;
      private int edtavSdt_managers__managerphone_Enabled ;
      private int edtavSdt_managers__managerphonecode_Enabled ;
      private int edtavSdt_managers__managerphonenumber_Enabled ;
      private int edtavSdt_managers__managergamguid_Enabled ;
      private int edtavManagergivenname_Enabled ;
      private int edtavManagerlastname_Enabled ;
      private int edtavManageremail_Enabled ;
      private int edtavManagerphonenumber_Enabled ;
      private int AV73GXV1 ;
      private int edtavManagerphonecode_Visible ;
      private int edtavManagerinitials_Visible ;
      private int edtavManagerphone_Visible ;
      private int edtavManagerid_Visible ;
      private int edtavManagergamguid_Visible ;
      private int subGridsdt_managerss_Islastpage ;
      private int GRIDSDT_MANAGERSS_nGridOutOfScope ;
      private int nGXsfl_77_fel_idx=1 ;
      private int nGXsfl_77_bak_idx=1 ;
      private int AV86GXV14 ;
      private int AV89GXV16 ;
      private int AV90GXV17 ;
      private int AV91GXV18 ;
      private int idxLst ;
      private int subGridsdt_managerss_Backcolor ;
      private int subGridsdt_managerss_Allbackcolor ;
      private int subGridsdt_managerss_Titlebackcolor ;
      private int subGridsdt_managerss_Selectedindex ;
      private int subGridsdt_managerss_Selectioncolor ;
      private int subGridsdt_managerss_Hoveringcolor ;
      private long GRIDSDT_MANAGERSS_nFirstRecordOnPage ;
      private long GRIDSDT_MANAGERSS_nCurrentRecord ;
      private long GRIDSDT_MANAGERSS_nRecordCount ;
      private string Combo_managerphonecode_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_77_idx="0001" ;
      private string edtavSdt_managers__managerid_Internalname ;
      private string edtavSdt_managers__organisationid_Internalname ;
      private string edtavSdt_managers__managergivenname_Internalname ;
      private string edtavSdt_managers__managerlastname_Internalname ;
      private string edtavSdt_managers__managerinitials_Internalname ;
      private string edtavSdt_managers__manageremail_Internalname ;
      private string edtavSdt_managers__managerphone_Internalname ;
      private string edtavSdt_managers__managerphonecode_Internalname ;
      private string edtavSdt_managers__managerphonenumber_Internalname ;
      private string cmbavSdt_managers__managergender_Internalname ;
      private string edtavSdt_managers__managergamguid_Internalname ;
      private string chkavSdt_managers__managerismainmanager_Internalname ;
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
      private string divUnnamedtable1_Internalname ;
      private string grpUnnamedgroup4_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string divUnnamedtable5_Internalname ;
      private string edtavManagergivenname_Internalname ;
      private string TempTags ;
      private string edtavManagergivenname_Jsonclick ;
      private string edtavManagerlastname_Internalname ;
      private string edtavManagerlastname_Jsonclick ;
      private string cmbavManagergender_Internalname ;
      private string cmbavManagergender_Jsonclick ;
      private string divUnnamedtable6_Internalname ;
      private string edtavManageremail_Internalname ;
      private string edtavManageremail_Jsonclick ;
      private string divUnnamedtable7_Internalname ;
      private string lblPhonelabel_Internalname ;
      private string lblPhonelabel_Jsonclick ;
      private string divUnnamedtable8_Internalname ;
      private string divUnnamedtable9_Internalname ;
      private string Combo_managerphonecode_Caption ;
      private string Combo_managerphonecode_Cls ;
      private string Combo_managerphonecode_Internalname ;
      private string divUnnamedtable10_Internalname ;
      private string edtavManagerphonenumber_Internalname ;
      private string edtavManagerphonenumber_Jsonclick ;
      private string chkavManagerismainmanager_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string bttBtnuinsert_Internalname ;
      private string bttBtnuinsert_Jsonclick ;
      private string divTablegrid_Internalname ;
      private string sStyleString ;
      private string subGridsdt_managerss_Internalname ;
      private string divTableactions_Internalname ;
      private string Btnwizardprevious_Tooltiptext ;
      private string Btnwizardprevious_Caption ;
      private string Btnwizardprevious_Class ;
      private string Btnwizardprevious_Internalname ;
      private string Btnwizardnext_Tooltiptext ;
      private string Btnwizardnext_Caption ;
      private string Btnwizardnext_Class ;
      private string Btnwizardnext_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavManagerphonecode_Internalname ;
      private string edtavManagerphonecode_Jsonclick ;
      private string edtavManagerinitials_Internalname ;
      private string AV14ManagerInitials ;
      private string edtavManagerinitials_Jsonclick ;
      private string edtavManagerphone_Internalname ;
      private string AV16ManagerPhone ;
      private string edtavManagerphone_Jsonclick ;
      private string edtavManagerid_Internalname ;
      private string edtavManagerid_Jsonclick ;
      private string edtavManagergamguid_Internalname ;
      private string edtavManagergamguid_Jsonclick ;
      private string Gridsdt_managerss_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactiongroup_Internalname ;
      private string GXDecQS ;
      private string sGXsfl_77_fel_idx="0001" ;
      private string Combo_managerphonecode_Htmltemplate ;
      private string Gridsdt_managerss_empowerer_Gridinternalname ;
      private string Combo_managerphonecode_Selectedtext_set ;
      private string Combo_managerphonecode_Selectedvalue_set ;
      private string GXt_char2 ;
      private string sCtrlAV31WebSessionKey ;
      private string sCtrlAV24PreviousStep ;
      private string sCtrlAV6GoingBack ;
      private string subGridsdt_managerss_Class ;
      private string subGridsdt_managerss_Linesclass ;
      private string ROClassString ;
      private string edtavSdt_managers__managerid_Jsonclick ;
      private string edtavSdt_managers__organisationid_Jsonclick ;
      private string edtavSdt_managers__managergivenname_Jsonclick ;
      private string edtavSdt_managers__managerlastname_Jsonclick ;
      private string edtavSdt_managers__managerinitials_Jsonclick ;
      private string edtavSdt_managers__manageremail_Jsonclick ;
      private string edtavSdt_managers__managerphone_Jsonclick ;
      private string edtavSdt_managers__managerphonecode_Jsonclick ;
      private string edtavSdt_managers__managerphonenumber_Jsonclick ;
      private string GXCCtl ;
      private string cmbavSdt_managers__managergender_Jsonclick ;
      private string edtavSdt_managers__managergamguid_Jsonclick ;
      private string cmbavGridactiongroup_Jsonclick ;
      private string subGridsdt_managerss_Header ;
      private bool AV6GoingBack ;
      private bool wcpOAV6GoingBack ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV43ManagerIsMainManager ;
      private bool AV7HasValidationErrors ;
      private bool bGXsfl_77_Refreshing=false ;
      private bool AV70hasMainManager ;
      private bool AV33CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Combo_managerphonecode_Emptyitem ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV53IsEditing ;
      private bool AV38isAlreadyAdded ;
      private bool AV39isAlreadyExistingInGAM ;
      private bool AV68isAlreadyRegistered ;
      private bool gx_BV77 ;
      private string AV31WebSessionKey ;
      private string AV24PreviousStep ;
      private string wcpOAV31WebSessionKey ;
      private string wcpOAV24PreviousStep ;
      private string A25ManagerEmail ;
      private string AV12ManagerGivenName ;
      private string AV15ManagerLastName ;
      private string AV11ManagerGender ;
      private string AV9ManagerEmail ;
      private string AV52ManagerPhoneNumber ;
      private string AV49ManagerPhoneCode ;
      private string AV10ManagerGAMGUID ;
      private string AV48defaultCountryPhoneCode ;
      private Guid AV13ManagerId ;
      private IGxSession AV30WebSession ;
      private GXWebGrid Gridsdt_managerssContainer ;
      private GXWebRow Gridsdt_managerssRow ;
      private GXWebColumn Gridsdt_managerssColumn ;
      private GXUserControl ucCombo_managerphonecode ;
      private GXUserControl ucBtnwizardprevious ;
      private GXUserControl ucBtnwizardnext ;
      private GXUserControl ucGridsdt_managerss_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavManagergender ;
      private GXCheckbox chkavManagerismainmanager ;
      private GXCombobox cmbavSdt_managers__managergender ;
      private GXCheckbox chkavSdt_managers__managerismainmanager ;
      private GXCombobox cmbavGridactiongroup ;
      private GXBaseCollection<SdtSDT_Managers_SDT_ManagersItem> AV26SDT_Managers ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV47DDO_TitleSettingsIcons ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item> AV50ManagerPhoneCode_Data ;
      private SdtWP_CreateOrganisationAndManagerData AV32WizardData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV37GAMUser ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV36GAMErrors ;
      private SdtSDT_Managers_SDT_ManagersItem AV25SDT_Manager ;
      private IDataStoreProvider pr_default ;
      private Guid[] H003Z2_A21ManagerId ;
      private Guid[] H003Z2_A11OrganisationId ;
      private string[] H003Z2_A25ManagerEmail ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> AV88GXV15 ;
      private GXBaseCollection<SdtSDT_Country_SDT_CountryItem> GXt_objcol_SdtSDT_Country_SDT_CountryItem3 ;
      private SdtSDT_Country_SDT_CountryItem AV51ManagerPhoneCode_DPItem ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTComboData_Item AV44Combo_DataItem ;
      private GxSimpleCollection<string> AV46ComboTitles ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV35ErrorMessages ;
      private GeneXus.Utils.SdtMessages_Message AV34Error ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wp_createorganisationandmanagerstep2__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH003Z2;
          prmH003Z2 = new Object[] {
          new ParDef("AV9ManagerEmail",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003Z2", "SELECT ManagerId, OrganisationId, ManagerEmail FROM Trn_Manager WHERE ManagerEmail = ( :AV9ManagerEmail) ORDER BY ManagerId, OrganisationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Z2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
