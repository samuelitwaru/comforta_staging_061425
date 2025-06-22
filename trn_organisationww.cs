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
   public class trn_organisationww : GXDataArea
   {
      public trn_organisationww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_organisationww( IGxContext context )
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
         cmbavActiongroup = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_39 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_39"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_39_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_39_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_39_idx = GetPar( "sGXsfl_39_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV15FilterFullText = GetPar( "FilterFullText");
         AV19ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV77ColumnsSelector);
         AV85Pgmname = GetPar( "Pgmname");
         AV22TFOrganisationName = GetPar( "TFOrganisationName");
         AV23TFOrganisationName_Sel = GetPar( "TFOrganisationName_Sel");
         AV34TFOrganisationTypeName = GetPar( "TFOrganisationTypeName");
         AV35TFOrganisationTypeName_Sel = GetPar( "TFOrganisationTypeName_Sel");
         AV28TFOrganisationEmail = GetPar( "TFOrganisationEmail");
         AV29TFOrganisationEmail_Sel = GetPar( "TFOrganisationEmail_Sel");
         AV30TFOrganisationPhone = GetPar( "TFOrganisationPhone");
         AV31TFOrganisationPhone_Sel = GetPar( "TFOrganisationPhone_Sel");
         AV46IsAuthorized_Display = StringUtil.StrToBool( GetPar( "IsAuthorized_Display"));
         AV48IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV50IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV81IsAuthorized_ManageProvisioning = StringUtil.StrToBool( GetPar( "IsAuthorized_ManageProvisioning"));
         AV52IsAuthorized_OrganisationName = StringUtil.StrToBool( GetPar( "IsAuthorized_OrganisationName"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV6WWPContext);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV77ColumnsSelector, AV85Pgmname, AV22TFOrganisationName, AV23TFOrganisationName_Sel, AV34TFOrganisationTypeName, AV35TFOrganisationTypeName_Sel, AV28TFOrganisationEmail, AV29TFOrganisationEmail_Sel, AV30TFOrganisationPhone, AV31TFOrganisationPhone_Sel, AV46IsAuthorized_Display, AV48IsAuthorized_Update, AV50IsAuthorized_Delete, AV81IsAuthorized_ManageProvisioning, AV52IsAuthorized_OrganisationName, AV6WWPContext) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            return "trn_organisationww_Execute" ;
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
         PA3N2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3N2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_organisationww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV85Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV85Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV46IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV46IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV48IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV48IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV50IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV50IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MANAGEPROVISIONING", AV81IsAuthorized_ManageProvisioning);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MANAGEPROVISIONING", GetSecureSignedToken( "", AV81IsAuthorized_ManageProvisioning, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_ORGANISATIONNAME", AV52IsAuthorized_OrganisationName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ORGANISATIONNAME", GetSecureSignedToken( "", AV52IsAuthorized_OrganisationName, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV15FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_39", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_39), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV17ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV17ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV42GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV36DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV36DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV77ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV77ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV85Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV85Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFORGANISATIONNAME", AV22TFOrganisationName);
         GxWebStd.gx_hidden_field( context, "vTFORGANISATIONNAME_SEL", AV23TFOrganisationName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFORGANISATIONTYPENAME", AV34TFOrganisationTypeName);
         GxWebStd.gx_hidden_field( context, "vTFORGANISATIONTYPENAME_SEL", AV35TFOrganisationTypeName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFORGANISATIONEMAIL", AV28TFOrganisationEmail);
         GxWebStd.gx_hidden_field( context, "vTFORGANISATIONEMAIL_SEL", AV29TFOrganisationEmail_Sel);
         GxWebStd.gx_hidden_field( context, "vTFORGANISATIONPHONE", StringUtil.RTrim( AV30TFOrganisationPhone));
         GxWebStd.gx_hidden_field( context, "vTFORGANISATIONPHONE_SEL", StringUtil.RTrim( AV31TFOrganisationPhone_Sel));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV46IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV46IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV48IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV48IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV50IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV50IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MANAGEPROVISIONING", AV81IsAuthorized_ManageProvisioning);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MANAGEPROVISIONING", GetSecureSignedToken( "", AV81IsAuthorized_ManageProvisioning, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_ORGANISATIONNAME", AV52IsAuthorized_OrganisationName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ORGANISATIONNAME", GetSecureSignedToken( "", AV52IsAuthorized_OrganisationName, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV6WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV6WWPContext);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISSUCCESSFUL", AV83isSuccessful);
         GxWebStd.gx_hidden_field( context, "vMESSAGE", StringUtil.RTrim( AV84Message));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icontype", StringUtil.RTrim( Ddc_subscriptions_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icon", StringUtil.RTrim( Ddc_subscriptions_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Caption", StringUtil.RTrim( Ddc_subscriptions_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Tooltip", StringUtil.RTrim( Ddc_subscriptions_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Cls", StringUtil.RTrim( Ddc_subscriptions_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace", StringUtil.RTrim( Ddc_subscriptions_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gamoauthtoken", StringUtil.RTrim( Ddo_grid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Title", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Confirmtype));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Result));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UDELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_udelete_Result));
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
            WE3N2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3N2( ) ;
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
         return formatLink("trn_organisationww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_OrganisationWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Organisations", "") ;
      }

      protected void WB3N0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableWithSelectableGrid", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsertorganisation_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", context.GetMessage( "Insert", ""), bttBtninsertorganisation_Jsonclick, 5, context.GetMessage( "Insert", ""), "", StyleString, ClassString, bttBtninsertorganisation_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERTORGANISATION\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_OrganisationWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_OrganisationWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_OrganisationWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablerightheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV17ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "TableFilters", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filter Full Text", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_39_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_Trn_OrganisationWW.htm");
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
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders GridHover HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl39( ) ;
         }
         if ( wbEnd == 39 )
         {
            wbEnd = 0;
            nRC_GXsfl_39 = (int)(nGXsfl_39_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV40GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV41GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV42GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
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
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV36DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV36DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV77ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            wb_table1_67_3N2( true) ;
         }
         else
         {
            wb_table1_67_3N2( false) ;
         }
         return  ;
      }

      protected void wb_table1_67_3N2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0074"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0074"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_39_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0074"+"");
                     }
                     WebComp_Wwpaux_wc.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
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
         if ( wbEnd == 39 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3N2( )
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
         Form.Meta.addItem("description", context.GetMessage( " Organisations", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3N0( ) ;
      }

      protected void WS3N2( )
      {
         START3N2( ) ;
         EVT3N2( ) ;
      }

      protected void EVT3N2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_managefilters.Onoptionclicked */
                              E113N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E123N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E133N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E143N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E153N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E163N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_UDELETE.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_udelete.Close */
                              E173N2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERTORGANISATION'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsertOrganisation' */
                              E183N2 ();
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VACTIONGROUP.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VACTIONGROUP.CLICK") == 0 ) )
                           {
                              nGXsfl_39_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
                              SubsflControlProps_392( ) ;
                              A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
                              A13OrganisationName = cgiGet( edtOrganisationName_Internalname);
                              A20OrganisationTypeName = cgiGet( edtOrganisationTypeName_Internalname);
                              A12OrganisationKvkNumber = cgiGet( edtOrganisationKvkNumber_Internalname);
                              A16OrganisationEmail = cgiGet( edtOrganisationEmail_Internalname);
                              A17OrganisationPhone = cgiGet( edtOrganisationPhone_Internalname);
                              A18OrganisationVATNumber = cgiGet( edtOrganisationVATNumber_Internalname);
                              A506OrganisationLogo = cgiGet( edtOrganisationLogo_Internalname);
                              AssignProp("", false, edtOrganisationLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A506OrganisationLogo)) ? A40000OrganisationLogo_GXI : context.convertURL( context.PathToRelativeUrl( A506OrganisationLogo))), !bGXsfl_39_Refreshing);
                              AssignProp("", false, edtOrganisationLogo_Internalname, "SrcSet", context.GetImageSrcSet( A506OrganisationLogo), true);
                              A252OrganisationAddressCity = cgiGet( edtOrganisationAddressCity_Internalname);
                              A251OrganisationAddressZipCode = cgiGet( edtOrganisationAddressZipCode_Internalname);
                              A303OrganisationAddressCountry = cgiGet( edtOrganisationAddressCountry_Internalname);
                              A304OrganisationAddressLine1 = cgiGet( edtOrganisationAddressLine1_Internalname);
                              A305OrganisationAddressLine2 = cgiGet( edtOrganisationAddressLine2_Internalname);
                              AV61Address = cgiGet( edtavAddress_Internalname);
                              AssignAttri("", false, edtavAddress_Internalname, AV61Address);
                              A19OrganisationTypeId = StringUtil.StrToGuid( cgiGet( edtOrganisationTypeId_Internalname));
                              A361OrganisationPhoneCode = cgiGet( edtOrganisationPhoneCode_Internalname);
                              A362OrganisationPhoneNumber = cgiGet( edtOrganisationPhoneNumber_Internalname);
                              cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                              cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                              AV72ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV72ActionGroup), 4, 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E193N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E203N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E213N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VACTIONGROUP.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E223N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV13OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
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
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 74 )
                        {
                           OldWwpaux_wc = cgiGet( "W0074");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0074", "", sEvt);
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

      protected void WE3N2( )
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

      protected void PA3N2( )
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_392( ) ;
         while ( nGXsfl_39_idx <= nRC_GXsfl_39 )
         {
            sendrow_392( ) ;
            nGXsfl_39_idx = ((subGrid_Islastpage==1)&&(nGXsfl_39_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV15FilterFullText ,
                                       short AV19ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV77ColumnsSelector ,
                                       string AV85Pgmname ,
                                       string AV22TFOrganisationName ,
                                       string AV23TFOrganisationName_Sel ,
                                       string AV34TFOrganisationTypeName ,
                                       string AV35TFOrganisationTypeName_Sel ,
                                       string AV28TFOrganisationEmail ,
                                       string AV29TFOrganisationEmail_Sel ,
                                       string AV30TFOrganisationPhone ,
                                       string AV31TFOrganisationPhone_Sel ,
                                       bool AV46IsAuthorized_Display ,
                                       bool AV48IsAuthorized_Update ,
                                       bool AV50IsAuthorized_Delete ,
                                       bool AV81IsAuthorized_ManageProvisioning ,
                                       bool AV52IsAuthorized_OrganisationName ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3N2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONID", GetSecureSignedToken( "", A11OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "ORGANISATIONID", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A13OrganisationName, "")), context));
         GxWebStd.gx_hidden_field( context, "ORGANISATIONNAME", A13OrganisationName);
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
         RF3N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV85Pgmname = "Trn_OrganisationWW";
         edtavAddress_Enabled = 0;
      }

      protected void RF3N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 39;
         /* Execute user event: Refresh */
         E203N2 ();
         nGXsfl_39_idx = 1;
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_392( ) ;
         bGXsfl_39_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
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
            SubsflControlProps_392( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV86Trn_organisationwwds_1_filterfulltext ,
                                                 AV88Trn_organisationwwds_3_tforganisationname_sel ,
                                                 AV87Trn_organisationwwds_2_tforganisationname ,
                                                 AV90Trn_organisationwwds_5_tforganisationtypename_sel ,
                                                 AV89Trn_organisationwwds_4_tforganisationtypename ,
                                                 AV92Trn_organisationwwds_7_tforganisationemail_sel ,
                                                 AV91Trn_organisationwwds_6_tforganisationemail ,
                                                 AV94Trn_organisationwwds_9_tforganisationphone_sel ,
                                                 AV93Trn_organisationwwds_8_tforganisationphone ,
                                                 A13OrganisationName ,
                                                 A20OrganisationTypeName ,
                                                 A16OrganisationEmail ,
                                                 A17OrganisationPhone ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV86Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV86Trn_organisationwwds_1_filterfulltext), "%", "");
            lV86Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV86Trn_organisationwwds_1_filterfulltext), "%", "");
            lV86Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV86Trn_organisationwwds_1_filterfulltext), "%", "");
            lV86Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV86Trn_organisationwwds_1_filterfulltext), "%", "");
            lV87Trn_organisationwwds_2_tforganisationname = StringUtil.Concat( StringUtil.RTrim( AV87Trn_organisationwwds_2_tforganisationname), "%", "");
            lV89Trn_organisationwwds_4_tforganisationtypename = StringUtil.Concat( StringUtil.RTrim( AV89Trn_organisationwwds_4_tforganisationtypename), "%", "");
            lV91Trn_organisationwwds_6_tforganisationemail = StringUtil.Concat( StringUtil.RTrim( AV91Trn_organisationwwds_6_tforganisationemail), "%", "");
            lV93Trn_organisationwwds_8_tforganisationphone = StringUtil.PadR( StringUtil.RTrim( AV93Trn_organisationwwds_8_tforganisationphone), 20, "%");
            /* Using cursor H003N2 */
            pr_default.execute(0, new Object[] {lV86Trn_organisationwwds_1_filterfulltext, lV86Trn_organisationwwds_1_filterfulltext, lV86Trn_organisationwwds_1_filterfulltext, lV86Trn_organisationwwds_1_filterfulltext, lV87Trn_organisationwwds_2_tforganisationname, AV88Trn_organisationwwds_3_tforganisationname_sel, lV89Trn_organisationwwds_4_tforganisationtypename, AV90Trn_organisationwwds_5_tforganisationtypename_sel, lV91Trn_organisationwwds_6_tforganisationemail, AV92Trn_organisationwwds_7_tforganisationemail_sel, lV93Trn_organisationwwds_8_tforganisationphone, AV94Trn_organisationwwds_9_tforganisationphone_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_39_idx = 1;
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A362OrganisationPhoneNumber = H003N2_A362OrganisationPhoneNumber[0];
               A361OrganisationPhoneCode = H003N2_A361OrganisationPhoneCode[0];
               A19OrganisationTypeId = H003N2_A19OrganisationTypeId[0];
               A305OrganisationAddressLine2 = H003N2_A305OrganisationAddressLine2[0];
               A304OrganisationAddressLine1 = H003N2_A304OrganisationAddressLine1[0];
               A303OrganisationAddressCountry = H003N2_A303OrganisationAddressCountry[0];
               A251OrganisationAddressZipCode = H003N2_A251OrganisationAddressZipCode[0];
               A252OrganisationAddressCity = H003N2_A252OrganisationAddressCity[0];
               A40000OrganisationLogo_GXI = H003N2_A40000OrganisationLogo_GXI[0];
               AssignProp("", false, edtOrganisationLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A506OrganisationLogo)) ? A40000OrganisationLogo_GXI : context.convertURL( context.PathToRelativeUrl( A506OrganisationLogo))), !bGXsfl_39_Refreshing);
               AssignProp("", false, edtOrganisationLogo_Internalname, "SrcSet", context.GetImageSrcSet( A506OrganisationLogo), true);
               A18OrganisationVATNumber = H003N2_A18OrganisationVATNumber[0];
               A17OrganisationPhone = H003N2_A17OrganisationPhone[0];
               A16OrganisationEmail = H003N2_A16OrganisationEmail[0];
               A12OrganisationKvkNumber = H003N2_A12OrganisationKvkNumber[0];
               A20OrganisationTypeName = H003N2_A20OrganisationTypeName[0];
               A13OrganisationName = H003N2_A13OrganisationName[0];
               A11OrganisationId = H003N2_A11OrganisationId[0];
               A506OrganisationLogo = H003N2_A506OrganisationLogo[0];
               AssignProp("", false, edtOrganisationLogo_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A506OrganisationLogo)) ? A40000OrganisationLogo_GXI : context.convertURL( context.PathToRelativeUrl( A506OrganisationLogo))), !bGXsfl_39_Refreshing);
               AssignProp("", false, edtOrganisationLogo_Internalname, "SrcSet", context.GetImageSrcSet( A506OrganisationLogo), true);
               A20OrganisationTypeName = H003N2_A20OrganisationTypeName[0];
               /* Execute user event: Grid.Load */
               E213N2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 39;
            WB3N0( ) ;
         }
         bGXsfl_39_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3N2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV85Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV85Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV46IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV46IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV48IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV48IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV50IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV50IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MANAGEPROVISIONING", AV81IsAuthorized_ManageProvisioning);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MANAGEPROVISIONING", GetSecureSignedToken( "", AV81IsAuthorized_ManageProvisioning, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_ORGANISATIONNAME", AV52IsAuthorized_OrganisationName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ORGANISATIONNAME", GetSecureSignedToken( "", AV52IsAuthorized_OrganisationName, context));
         GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONID"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, A11OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONNAME"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, StringUtil.RTrim( context.localUtil.Format( A13OrganisationName, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         AV86Trn_organisationwwds_1_filterfulltext = AV15FilterFullText;
         AV87Trn_organisationwwds_2_tforganisationname = AV22TFOrganisationName;
         AV88Trn_organisationwwds_3_tforganisationname_sel = AV23TFOrganisationName_Sel;
         AV89Trn_organisationwwds_4_tforganisationtypename = AV34TFOrganisationTypeName;
         AV90Trn_organisationwwds_5_tforganisationtypename_sel = AV35TFOrganisationTypeName_Sel;
         AV91Trn_organisationwwds_6_tforganisationemail = AV28TFOrganisationEmail;
         AV92Trn_organisationwwds_7_tforganisationemail_sel = AV29TFOrganisationEmail_Sel;
         AV93Trn_organisationwwds_8_tforganisationphone = AV30TFOrganisationPhone;
         AV94Trn_organisationwwds_9_tforganisationphone_sel = AV31TFOrganisationPhone_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV86Trn_organisationwwds_1_filterfulltext ,
                                              AV88Trn_organisationwwds_3_tforganisationname_sel ,
                                              AV87Trn_organisationwwds_2_tforganisationname ,
                                              AV90Trn_organisationwwds_5_tforganisationtypename_sel ,
                                              AV89Trn_organisationwwds_4_tforganisationtypename ,
                                              AV92Trn_organisationwwds_7_tforganisationemail_sel ,
                                              AV91Trn_organisationwwds_6_tforganisationemail ,
                                              AV94Trn_organisationwwds_9_tforganisationphone_sel ,
                                              AV93Trn_organisationwwds_8_tforganisationphone ,
                                              A13OrganisationName ,
                                              A20OrganisationTypeName ,
                                              A16OrganisationEmail ,
                                              A17OrganisationPhone ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV86Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV86Trn_organisationwwds_1_filterfulltext), "%", "");
         lV86Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV86Trn_organisationwwds_1_filterfulltext), "%", "");
         lV86Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV86Trn_organisationwwds_1_filterfulltext), "%", "");
         lV86Trn_organisationwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV86Trn_organisationwwds_1_filterfulltext), "%", "");
         lV87Trn_organisationwwds_2_tforganisationname = StringUtil.Concat( StringUtil.RTrim( AV87Trn_organisationwwds_2_tforganisationname), "%", "");
         lV89Trn_organisationwwds_4_tforganisationtypename = StringUtil.Concat( StringUtil.RTrim( AV89Trn_organisationwwds_4_tforganisationtypename), "%", "");
         lV91Trn_organisationwwds_6_tforganisationemail = StringUtil.Concat( StringUtil.RTrim( AV91Trn_organisationwwds_6_tforganisationemail), "%", "");
         lV93Trn_organisationwwds_8_tforganisationphone = StringUtil.PadR( StringUtil.RTrim( AV93Trn_organisationwwds_8_tforganisationphone), 20, "%");
         /* Using cursor H003N3 */
         pr_default.execute(1, new Object[] {lV86Trn_organisationwwds_1_filterfulltext, lV86Trn_organisationwwds_1_filterfulltext, lV86Trn_organisationwwds_1_filterfulltext, lV86Trn_organisationwwds_1_filterfulltext, lV87Trn_organisationwwds_2_tforganisationname, AV88Trn_organisationwwds_3_tforganisationname_sel, lV89Trn_organisationwwds_4_tforganisationtypename, AV90Trn_organisationwwds_5_tforganisationtypename_sel, lV91Trn_organisationwwds_6_tforganisationemail, AV92Trn_organisationwwds_7_tforganisationemail_sel, lV93Trn_organisationwwds_8_tforganisationphone, AV94Trn_organisationwwds_9_tforganisationphone_sel});
         GRID_nRecordCount = H003N3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         AV86Trn_organisationwwds_1_filterfulltext = AV15FilterFullText;
         AV87Trn_organisationwwds_2_tforganisationname = AV22TFOrganisationName;
         AV88Trn_organisationwwds_3_tforganisationname_sel = AV23TFOrganisationName_Sel;
         AV89Trn_organisationwwds_4_tforganisationtypename = AV34TFOrganisationTypeName;
         AV90Trn_organisationwwds_5_tforganisationtypename_sel = AV35TFOrganisationTypeName_Sel;
         AV91Trn_organisationwwds_6_tforganisationemail = AV28TFOrganisationEmail;
         AV92Trn_organisationwwds_7_tforganisationemail_sel = AV29TFOrganisationEmail_Sel;
         AV93Trn_organisationwwds_8_tforganisationphone = AV30TFOrganisationPhone;
         AV94Trn_organisationwwds_9_tforganisationphone_sel = AV31TFOrganisationPhone_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV77ColumnsSelector, AV85Pgmname, AV22TFOrganisationName, AV23TFOrganisationName_Sel, AV34TFOrganisationTypeName, AV35TFOrganisationTypeName_Sel, AV28TFOrganisationEmail, AV29TFOrganisationEmail_Sel, AV30TFOrganisationPhone, AV31TFOrganisationPhone_Sel, AV46IsAuthorized_Display, AV48IsAuthorized_Update, AV50IsAuthorized_Delete, AV81IsAuthorized_ManageProvisioning, AV52IsAuthorized_OrganisationName, AV6WWPContext) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV86Trn_organisationwwds_1_filterfulltext = AV15FilterFullText;
         AV87Trn_organisationwwds_2_tforganisationname = AV22TFOrganisationName;
         AV88Trn_organisationwwds_3_tforganisationname_sel = AV23TFOrganisationName_Sel;
         AV89Trn_organisationwwds_4_tforganisationtypename = AV34TFOrganisationTypeName;
         AV90Trn_organisationwwds_5_tforganisationtypename_sel = AV35TFOrganisationTypeName_Sel;
         AV91Trn_organisationwwds_6_tforganisationemail = AV28TFOrganisationEmail;
         AV92Trn_organisationwwds_7_tforganisationemail_sel = AV29TFOrganisationEmail_Sel;
         AV93Trn_organisationwwds_8_tforganisationphone = AV30TFOrganisationPhone;
         AV94Trn_organisationwwds_9_tforganisationphone_sel = AV31TFOrganisationPhone_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV77ColumnsSelector, AV85Pgmname, AV22TFOrganisationName, AV23TFOrganisationName_Sel, AV34TFOrganisationTypeName, AV35TFOrganisationTypeName_Sel, AV28TFOrganisationEmail, AV29TFOrganisationEmail_Sel, AV30TFOrganisationPhone, AV31TFOrganisationPhone_Sel, AV46IsAuthorized_Display, AV48IsAuthorized_Update, AV50IsAuthorized_Delete, AV81IsAuthorized_ManageProvisioning, AV52IsAuthorized_OrganisationName, AV6WWPContext) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV86Trn_organisationwwds_1_filterfulltext = AV15FilterFullText;
         AV87Trn_organisationwwds_2_tforganisationname = AV22TFOrganisationName;
         AV88Trn_organisationwwds_3_tforganisationname_sel = AV23TFOrganisationName_Sel;
         AV89Trn_organisationwwds_4_tforganisationtypename = AV34TFOrganisationTypeName;
         AV90Trn_organisationwwds_5_tforganisationtypename_sel = AV35TFOrganisationTypeName_Sel;
         AV91Trn_organisationwwds_6_tforganisationemail = AV28TFOrganisationEmail;
         AV92Trn_organisationwwds_7_tforganisationemail_sel = AV29TFOrganisationEmail_Sel;
         AV93Trn_organisationwwds_8_tforganisationphone = AV30TFOrganisationPhone;
         AV94Trn_organisationwwds_9_tforganisationphone_sel = AV31TFOrganisationPhone_Sel;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV77ColumnsSelector, AV85Pgmname, AV22TFOrganisationName, AV23TFOrganisationName_Sel, AV34TFOrganisationTypeName, AV35TFOrganisationTypeName_Sel, AV28TFOrganisationEmail, AV29TFOrganisationEmail_Sel, AV30TFOrganisationPhone, AV31TFOrganisationPhone_Sel, AV46IsAuthorized_Display, AV48IsAuthorized_Update, AV50IsAuthorized_Delete, AV81IsAuthorized_ManageProvisioning, AV52IsAuthorized_OrganisationName, AV6WWPContext) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV86Trn_organisationwwds_1_filterfulltext = AV15FilterFullText;
         AV87Trn_organisationwwds_2_tforganisationname = AV22TFOrganisationName;
         AV88Trn_organisationwwds_3_tforganisationname_sel = AV23TFOrganisationName_Sel;
         AV89Trn_organisationwwds_4_tforganisationtypename = AV34TFOrganisationTypeName;
         AV90Trn_organisationwwds_5_tforganisationtypename_sel = AV35TFOrganisationTypeName_Sel;
         AV91Trn_organisationwwds_6_tforganisationemail = AV28TFOrganisationEmail;
         AV92Trn_organisationwwds_7_tforganisationemail_sel = AV29TFOrganisationEmail_Sel;
         AV93Trn_organisationwwds_8_tforganisationphone = AV30TFOrganisationPhone;
         AV94Trn_organisationwwds_9_tforganisationphone_sel = AV31TFOrganisationPhone_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV77ColumnsSelector, AV85Pgmname, AV22TFOrganisationName, AV23TFOrganisationName_Sel, AV34TFOrganisationTypeName, AV35TFOrganisationTypeName_Sel, AV28TFOrganisationEmail, AV29TFOrganisationEmail_Sel, AV30TFOrganisationPhone, AV31TFOrganisationPhone_Sel, AV46IsAuthorized_Display, AV48IsAuthorized_Update, AV50IsAuthorized_Delete, AV81IsAuthorized_ManageProvisioning, AV52IsAuthorized_OrganisationName, AV6WWPContext) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV86Trn_organisationwwds_1_filterfulltext = AV15FilterFullText;
         AV87Trn_organisationwwds_2_tforganisationname = AV22TFOrganisationName;
         AV88Trn_organisationwwds_3_tforganisationname_sel = AV23TFOrganisationName_Sel;
         AV89Trn_organisationwwds_4_tforganisationtypename = AV34TFOrganisationTypeName;
         AV90Trn_organisationwwds_5_tforganisationtypename_sel = AV35TFOrganisationTypeName_Sel;
         AV91Trn_organisationwwds_6_tforganisationemail = AV28TFOrganisationEmail;
         AV92Trn_organisationwwds_7_tforganisationemail_sel = AV29TFOrganisationEmail_Sel;
         AV93Trn_organisationwwds_8_tforganisationphone = AV30TFOrganisationPhone;
         AV94Trn_organisationwwds_9_tforganisationphone_sel = AV31TFOrganisationPhone_Sel;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV77ColumnsSelector, AV85Pgmname, AV22TFOrganisationName, AV23TFOrganisationName_Sel, AV34TFOrganisationTypeName, AV35TFOrganisationTypeName_Sel, AV28TFOrganisationEmail, AV29TFOrganisationEmail_Sel, AV30TFOrganisationPhone, AV31TFOrganisationPhone_Sel, AV46IsAuthorized_Display, AV48IsAuthorized_Update, AV50IsAuthorized_Delete, AV81IsAuthorized_ManageProvisioning, AV52IsAuthorized_OrganisationName, AV6WWPContext) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV85Pgmname = "Trn_OrganisationWW";
         edtavAddress_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtOrganisationName_Enabled = 0;
         edtOrganisationTypeName_Enabled = 0;
         edtOrganisationKvkNumber_Enabled = 0;
         edtOrganisationEmail_Enabled = 0;
         edtOrganisationPhone_Enabled = 0;
         edtOrganisationVATNumber_Enabled = 0;
         edtOrganisationLogo_Enabled = 0;
         edtOrganisationAddressCity_Enabled = 0;
         edtOrganisationAddressZipCode_Enabled = 0;
         edtOrganisationAddressCountry_Enabled = 0;
         edtOrganisationAddressLine1_Enabled = 0;
         edtOrganisationAddressLine2_Enabled = 0;
         edtOrganisationTypeId_Enabled = 0;
         edtOrganisationPhoneCode_Enabled = 0;
         edtOrganisationPhoneNumber_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E193N2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV17ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV36DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV77ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_39 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_39"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV40GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV41GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV42GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddc_subscriptions_Icontype = cgiGet( "DDC_SUBSCRIPTIONS_Icontype");
            Ddc_subscriptions_Icon = cgiGet( "DDC_SUBSCRIPTIONS_Icon");
            Ddc_subscriptions_Caption = cgiGet( "DDC_SUBSCRIPTIONS_Caption");
            Ddc_subscriptions_Tooltip = cgiGet( "DDC_SUBSCRIPTIONS_Tooltip");
            Ddc_subscriptions_Cls = cgiGet( "DDC_SUBSCRIPTIONS_Cls");
            Ddc_subscriptions_Titlecontrolidtoreplace = cgiGet( "DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gamoauthtoken = cgiGet( "DDO_GRID_Gamoauthtoken");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Dvelop_confirmpanel_udelete_Title = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Title");
            Dvelop_confirmpanel_udelete_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Confirmationtext");
            Dvelop_confirmpanel_udelete_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Yesbuttoncaption");
            Dvelop_confirmpanel_udelete_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Nobuttoncaption");
            Dvelop_confirmpanel_udelete_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Cancelbuttoncaption");
            Dvelop_confirmpanel_udelete_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Yesbuttonposition");
            Dvelop_confirmpanel_udelete_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Confirmtype");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvelop_confirmpanel_udelete_Result = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Result");
            /* Read variables values. */
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            /* Read subfile selected row values. */
            nGXsfl_39_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            if ( nGXsfl_39_idx > 0 )
            {
               A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
               A13OrganisationName = cgiGet( edtOrganisationName_Internalname);
               A20OrganisationTypeName = cgiGet( edtOrganisationTypeName_Internalname);
               A12OrganisationKvkNumber = cgiGet( edtOrganisationKvkNumber_Internalname);
               A16OrganisationEmail = cgiGet( edtOrganisationEmail_Internalname);
               A17OrganisationPhone = cgiGet( edtOrganisationPhone_Internalname);
               A18OrganisationVATNumber = cgiGet( edtOrganisationVATNumber_Internalname);
               A506OrganisationLogo = cgiGet( edtOrganisationLogo_Internalname);
               A252OrganisationAddressCity = cgiGet( edtOrganisationAddressCity_Internalname);
               A251OrganisationAddressZipCode = cgiGet( edtOrganisationAddressZipCode_Internalname);
               A303OrganisationAddressCountry = cgiGet( edtOrganisationAddressCountry_Internalname);
               A304OrganisationAddressLine1 = cgiGet( edtOrganisationAddressLine1_Internalname);
               A305OrganisationAddressLine2 = cgiGet( edtOrganisationAddressLine2_Internalname);
               AV61Address = cgiGet( edtavAddress_Internalname);
               AssignAttri("", false, edtavAddress_Internalname, AV61Address);
               A19OrganisationTypeId = StringUtil.StrToGuid( cgiGet( edtOrganisationTypeId_Internalname));
               A361OrganisationPhoneCode = cgiGet( edtOrganisationPhoneCode_Internalname);
               A362OrganisationPhoneNumber = cgiGet( edtOrganisationPhoneNumber_Internalname);
               cmbavActiongroup.Name = cmbavActiongroup_Internalname;
               cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
               AV72ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV72ActionGroup), 4, 0));
            }
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV13OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV14OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
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
         E193N2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E193N2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV79successmsg = AV80websession.Get(context.GetMessage( "NotificationMessage", ""));
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79successmsg)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Success",  AV79successmsg,  "success",  "",  "true",  ""));
            AV80websession.Remove(context.GetMessage( "NotificationMessage", ""));
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         GXt_boolean1 = AV52IsAuthorized_OrganisationName;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_organisationview_Execute", out  GXt_boolean1) ;
         AV52IsAuthorized_OrganisationName = GXt_boolean1;
         AssignAttri("", false, "AV52IsAuthorized_OrganisationName", AV52IsAuthorized_OrganisationName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ORGANISATIONNAME", GetSecureSignedToken( "", AV52IsAuthorized_OrganisationName, context));
         AV37GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV38GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV37GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = context.GetMessage( " Organisations", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV36DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV36DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E203N2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV19ManageFiltersExecutionStep == 1 )
         {
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV19ManageFiltersExecutionStep == 2 )
         {
            AV19ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV16Session.Get("Trn_OrganisationWWColumnsSelector"), "") != 0 )
         {
            AV75ColumnsSelectorXML = AV16Session.Get("Trn_OrganisationWWColumnsSelector");
            AV77ColumnsSelector.FromXml(AV75ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtOrganisationName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV77ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtOrganisationName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationName_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtOrganisationTypeName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV77ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtOrganisationTypeName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationTypeName_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtOrganisationEmail_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV77ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtOrganisationEmail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationEmail_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtOrganisationPhone_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV77ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtOrganisationPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtOrganisationPhone_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtavAddress_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV77ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavAddress_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAddress_Visible), 5, 0), !bGXsfl_39_Refreshing);
         AV40GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV40GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV40GridCurrentPage), 10, 0));
         AV41GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV41GridPageCount", StringUtil.LTrimStr( (decimal)(AV41GridPageCount), 10, 0));
         GXt_char3 = AV42GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV85Pgmname, out  GXt_char3) ;
         AV42GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV42GridAppliedFilters", AV42GridAppliedFilters);
         AV86Trn_organisationwwds_1_filterfulltext = AV15FilterFullText;
         AV87Trn_organisationwwds_2_tforganisationname = AV22TFOrganisationName;
         AV88Trn_organisationwwds_3_tforganisationname_sel = AV23TFOrganisationName_Sel;
         AV89Trn_organisationwwds_4_tforganisationtypename = AV34TFOrganisationTypeName;
         AV90Trn_organisationwwds_5_tforganisationtypename_sel = AV35TFOrganisationTypeName_Sel;
         AV91Trn_organisationwwds_6_tforganisationemail = AV28TFOrganisationEmail;
         AV92Trn_organisationwwds_7_tforganisationemail_sel = AV29TFOrganisationEmail_Sel;
         AV93Trn_organisationwwds_8_tforganisationphone = AV30TFOrganisationPhone;
         AV94Trn_organisationwwds_9_tforganisationphone_sel = AV31TFOrganisationPhone_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV77ColumnsSelector", AV77ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E123N2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV39PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV39PageToGo) ;
         }
      }

      protected void E133N2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E153N2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OrganisationName") == 0 )
            {
               AV22TFOrganisationName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV22TFOrganisationName", AV22TFOrganisationName);
               AV23TFOrganisationName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV23TFOrganisationName_Sel", AV23TFOrganisationName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OrganisationTypeName") == 0 )
            {
               AV34TFOrganisationTypeName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV34TFOrganisationTypeName", AV34TFOrganisationTypeName);
               AV35TFOrganisationTypeName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV35TFOrganisationTypeName_Sel", AV35TFOrganisationTypeName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OrganisationEmail") == 0 )
            {
               AV28TFOrganisationEmail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV28TFOrganisationEmail", AV28TFOrganisationEmail);
               AV29TFOrganisationEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV29TFOrganisationEmail_Sel", AV29TFOrganisationEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "OrganisationPhone") == 0 )
            {
               AV30TFOrganisationPhone = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV30TFOrganisationPhone", AV30TFOrganisationPhone);
               AV31TFOrganisationPhone_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV31TFOrganisationPhone_Sel", AV31TFOrganisationPhone_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E213N2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         GXt_char3 = AV61Address;
         new prc_concatenateaddress(context ).execute(  A303OrganisationAddressCountry,  A252OrganisationAddressCity,  A251OrganisationAddressZipCode,  A304OrganisationAddressLine1,  A305OrganisationAddressLine2, out  GXt_char3) ;
         AV61Address = GXt_char3;
         AssignAttri("", false, edtavAddress_Internalname, AV61Address);
         cmbavActiongroup.removeAllItems();
         cmbavActiongroup.addItem("0", ";fas fa-bars", 0);
         if ( AV46IsAuthorized_Display )
         {
            cmbavActiongroup.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
         }
         if ( AV48IsAuthorized_Update )
         {
            cmbavActiongroup.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Edit", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
         }
         if ( AV50IsAuthorized_Delete )
         {
            if ( false )
            {
               cmbavActiongroup.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
            }
         }
         cmbavActiongroup.addItem("4", StringUtil.Format( "%1;%2", context.GetMessage( "Access", ""), "fas fa-right-to-bracket", "", "", "", "", "", "", ""), 0);
         if ( AV81IsAuthorized_ManageProvisioning )
         {
            cmbavActiongroup.addItem("5", StringUtil.Format( "%1;%2", context.GetMessage( "Manage License", ""), "fas fa-gears", "", "", "", "", "", "", ""), 0);
         }
         cmbavActiongroup.addItem("6", StringUtil.Format( "%1;%2", context.GetMessage( "Delete", ""), "fas fa-x", "", "", "", "", "", "", ""), 0);
         if ( AV52IsAuthorized_OrganisationName )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_organisationview.aspx"+UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtOrganisationName_Link = formatLink("trn_organisationview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         if ( ! AV6WWPContext.gxTpr_Isrootadmin )
         {
            cmbavActiongroup.removeItem(StringUtil.Str( (decimal)(4), 1, 0));
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 39;
         }
         sendrow_392( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_39_Refreshing )
         {
            DoAjaxLoad(39, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72ActionGroup), 4, 0));
      }

      protected void E163N2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV75ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV77ColumnsSelector.FromJSonString(AV75ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "Trn_OrganisationWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV75ColumnsSelectorXML)) ? "" : AV77ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV77ColumnsSelector", AV77ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E113N2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("Trn_OrganisationWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV85Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("Trn_OrganisationWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV18ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "Trn_OrganisationWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV18ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV18ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV85Pgmname+"GridState",  AV18ManageFiltersXml) ;
               AV11GridState.FromXml(AV18ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S192 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV77ColumnsSelector", AV77ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
      }

      protected void E223N2( )
      {
         /* Actiongroup_Click Routine */
         returnInSub = false;
         if ( AV72ActionGroup == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV72ActionGroup == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV72ActionGroup == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV72ActionGroup == 4 )
         {
            /* Execute user subroutine: 'DO UACCESS' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV72ActionGroup == 5 )
         {
            /* Execute user subroutine: 'DO MANAGEPROVISIONING' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV72ActionGroup == 6 )
         {
            /* Execute user subroutine: 'DO UDELETE' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV72ActionGroup = 0;
         AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV72ActionGroup), 4, 0));
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72ActionGroup), 4, 0));
         AssignProp("", false, cmbavActiongroup_Internalname, "Values", cmbavActiongroup.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV77ColumnsSelector", AV77ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E173N2( )
      {
         /* Dvelop_confirmpanel_udelete_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_udelete_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION UDELETE' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6WWPContext", AV6WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV77ColumnsSelector", AV77ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E183N2( )
      {
         /* 'DoInsertOrganisation' Routine */
         returnInSub = false;
         CallWebObject(formatLink("wp_createorganisationandmanager.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void E143N2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0074",(string)"",(string)"Trn_Organisation",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0074"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV77ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV77ColumnsSelector,  "OrganisationName",  "",  "Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV77ColumnsSelector,  "OrganisationTypeName",  "",  "Type",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV77ColumnsSelector,  "OrganisationEmail",  "",  "Email",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV77ColumnsSelector,  "OrganisationPhone",  "",  "Phone",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV77ColumnsSelector,  "&Address",  "",  "Address",  true,  "") ;
         GXt_char3 = AV76UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "Trn_OrganisationWWColumnsSelector", out  GXt_char3) ;
         AV76UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV76UserCustomValue)) ) )
         {
            AV78ColumnsSelectorAux.FromXml(AV76UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV78ColumnsSelectorAux, ref  AV77ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV46IsAuthorized_Display;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_organisationview_Execute", out  GXt_boolean1) ;
         AV46IsAuthorized_Display = GXt_boolean1;
         AssignAttri("", false, "AV46IsAuthorized_Display", AV46IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV46IsAuthorized_Display, context));
         GXt_boolean1 = AV48IsAuthorized_Update;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_organisation_Update", out  GXt_boolean1) ;
         AV48IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV48IsAuthorized_Update", AV48IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV48IsAuthorized_Update, context));
         GXt_boolean1 = AV50IsAuthorized_Delete;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_organisation_Delete", out  GXt_boolean1) ;
         AV50IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV50IsAuthorized_Delete", AV50IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV50IsAuthorized_Delete, context));
         GXt_boolean1 = AV81IsAuthorized_ManageProvisioning;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wp_manageorganisationprovisioning_Execute", out  GXt_boolean1) ;
         AV81IsAuthorized_ManageProvisioning = GXt_boolean1;
         AssignAttri("", false, "AV81IsAuthorized_ManageProvisioning", AV81IsAuthorized_ManageProvisioning);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MANAGEPROVISIONING", GetSecureSignedToken( "", AV81IsAuthorized_ManageProvisioning, context));
         GXt_boolean1 = AV73IsAuthorized_InsertOrganisation;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_organisation_Insert", out  GXt_boolean1) ;
         AV73IsAuthorized_InsertOrganisation = GXt_boolean1;
         if ( ! ( AV73IsAuthorized_InsertOrganisation ) )
         {
            bttBtninsertorganisation_Visible = 0;
            AssignProp("", false, bttBtninsertorganisation_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsertorganisation_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Trn_Organisation",  1) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV17ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "Trn_OrganisationWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV17ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV22TFOrganisationName = "";
         AssignAttri("", false, "AV22TFOrganisationName", AV22TFOrganisationName);
         AV23TFOrganisationName_Sel = "";
         AssignAttri("", false, "AV23TFOrganisationName_Sel", AV23TFOrganisationName_Sel);
         AV34TFOrganisationTypeName = "";
         AssignAttri("", false, "AV34TFOrganisationTypeName", AV34TFOrganisationTypeName);
         AV35TFOrganisationTypeName_Sel = "";
         AssignAttri("", false, "AV35TFOrganisationTypeName_Sel", AV35TFOrganisationTypeName_Sel);
         AV28TFOrganisationEmail = "";
         AssignAttri("", false, "AV28TFOrganisationEmail", AV28TFOrganisationEmail);
         AV29TFOrganisationEmail_Sel = "";
         AssignAttri("", false, "AV29TFOrganisationEmail_Sel", AV29TFOrganisationEmail_Sel);
         AV30TFOrganisationPhone = "";
         AssignAttri("", false, "AV30TFOrganisationPhone", AV30TFOrganisationPhone);
         AV31TFOrganisationPhone_Sel = "";
         AssignAttri("", false, "AV31TFOrganisationPhone_Sel", AV31TFOrganisationPhone_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S202( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         if ( AV46IsAuthorized_Display )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_organisationview.aspx"+UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            CallWebObject(formatLink("trn_organisationview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S212( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         if ( AV48IsAuthorized_Update )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_organisation.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A11OrganisationId.ToString());
            CallWebObject(formatLink("trn_organisation.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S222( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         if ( AV50IsAuthorized_Delete )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_organisation.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A11OrganisationId.ToString());
            CallWebObject(formatLink("trn_organisation.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S232( )
      {
         /* 'DO UACCESS' Routine */
         returnInSub = false;
         AV6WWPContext.gxTpr_Organisationid = A11OrganisationId;
         AV6WWPContext.gxTpr_Organisationname = A13OrganisationName;
         new GeneXus.Programs.wwpbaseobjects.setwwpcontext(context ).execute(  AV6WWPContext) ;
         CallWebObject(formatLink("trn_locationww.aspx") );
         context.wjLocDisableFrm = 1;
      }

      protected void S242( )
      {
         /* 'DO MANAGEPROVISIONING' Routine */
         returnInSub = false;
         if ( AV81IsAuthorized_ManageProvisioning )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wp_manageorganisationprovisioning.aspx"+UrlEncode(A11OrganisationId.ToString());
            CallWebObject(formatLink("wp_manageorganisationprovisioning.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S252( )
      {
         /* 'DO UDELETE' Routine */
         returnInSub = false;
         Dvelop_confirmpanel_udelete_Title = context.GetMessage( "Confirm delete action", "");
         ucDvelop_confirmpanel_udelete.SendProperty(context, "", false, Dvelop_confirmpanel_udelete_Internalname, "Title", Dvelop_confirmpanel_udelete_Title);
         Dvelop_confirmpanel_udelete_Confirmationtext = context.GetMessage( "All associated data will be deleted.", "");
         ucDvelop_confirmpanel_udelete.SendProperty(context, "", false, Dvelop_confirmpanel_udelete_Internalname, "ConfirmationText", Dvelop_confirmpanel_udelete_Confirmationtext);
         AV95Organisationid_selected = A11OrganisationId;
         this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_UDELETEContainer", "Confirm", "", new Object[] {});
      }

      protected void S262( )
      {
         /* 'DO ACTION UDELETE' Routine */
         returnInSub = false;
         new prc_deletecascadeorganisation(context ).execute(  A11OrganisationId, ref  AV83isSuccessful, ref  AV84Message) ;
         AssignAttri("", false, "AV83isSuccessful", AV83isSuccessful);
         AssignAttri("", false, "AV84Message", AV84Message);
         if ( AV83isSuccessful )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Success",  context.GetMessage( "Deleted organisation successfully", ""),  "success",  "",  "true",  ""));
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV77ColumnsSelector, AV85Pgmname, AV22TFOrganisationName, AV23TFOrganisationName_Sel, AV34TFOrganisationTypeName, AV35TFOrganisationTypeName_Sel, AV28TFOrganisationEmail, AV29TFOrganisationEmail_Sel, AV30TFOrganisationPhone, AV31TFOrganisationPhone_Sel, AV46IsAuthorized_Display, AV48IsAuthorized_Update, AV50IsAuthorized_Delete, AV81IsAuthorized_ManageProvisioning, AV52IsAuthorized_OrganisationName, AV6WWPContext) ;
         }
         else
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Failed",  AV84Message,  "error",  "",  "true",  ""));
         }
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV16Session.Get(AV85Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV85Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV16Session.Get(AV85Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S192( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV96GXV1 = 1;
         while ( AV96GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV96GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFORGANISATIONNAME") == 0 )
            {
               AV22TFOrganisationName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV22TFOrganisationName", AV22TFOrganisationName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFORGANISATIONNAME_SEL") == 0 )
            {
               AV23TFOrganisationName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV23TFOrganisationName_Sel", AV23TFOrganisationName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFORGANISATIONTYPENAME") == 0 )
            {
               AV34TFOrganisationTypeName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFOrganisationTypeName", AV34TFOrganisationTypeName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFORGANISATIONTYPENAME_SEL") == 0 )
            {
               AV35TFOrganisationTypeName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFOrganisationTypeName_Sel", AV35TFOrganisationTypeName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFORGANISATIONEMAIL") == 0 )
            {
               AV28TFOrganisationEmail = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28TFOrganisationEmail", AV28TFOrganisationEmail);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFORGANISATIONEMAIL_SEL") == 0 )
            {
               AV29TFOrganisationEmail_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFOrganisationEmail_Sel", AV29TFOrganisationEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFORGANISATIONPHONE") == 0 )
            {
               AV30TFOrganisationPhone = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV30TFOrganisationPhone", AV30TFOrganisationPhone);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFORGANISATIONPHONE_SEL") == 0 )
            {
               AV31TFOrganisationPhone_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFOrganisationPhone_Sel", AV31TFOrganisationPhone_Sel);
            }
            AV96GXV1 = (int)(AV96GXV1+1);
         }
         GXt_char3 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV23TFOrganisationName_Sel)),  AV23TFOrganisationName_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFOrganisationTypeName_Sel)),  AV35TFOrganisationTypeName_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFOrganisationEmail_Sel)),  AV29TFOrganisationEmail_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFOrganisationPhone_Sel)),  AV31TFOrganisationPhone_Sel, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV22TFOrganisationName)),  AV22TFOrganisationName, out  GXt_char7) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFOrganisationTypeName)),  AV34TFOrganisationTypeName, out  GXt_char6) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFOrganisationEmail)),  AV28TFOrganisationEmail, out  GXt_char5) ;
         GXt_char3 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFOrganisationPhone)),  AV30TFOrganisationPhone, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV16Session.Get(AV85Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFORGANISATIONNAME",  context.GetMessage( "Name", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV22TFOrganisationName)),  0,  AV22TFOrganisationName,  AV22TFOrganisationName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFOrganisationName_Sel)),  AV23TFOrganisationName_Sel,  AV23TFOrganisationName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFORGANISATIONTYPENAME",  context.GetMessage( "Type", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFOrganisationTypeName)),  0,  AV34TFOrganisationTypeName,  AV34TFOrganisationTypeName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFOrganisationTypeName_Sel)),  AV35TFOrganisationTypeName_Sel,  AV35TFOrganisationTypeName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFORGANISATIONEMAIL",  context.GetMessage( "Email", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFOrganisationEmail)),  0,  AV28TFOrganisationEmail,  AV28TFOrganisationEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFOrganisationEmail_Sel)),  AV29TFOrganisationEmail_Sel,  AV29TFOrganisationEmail_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFORGANISATIONPHONE",  context.GetMessage( "Phone", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFOrganisationPhone)),  0,  AV30TFOrganisationPhone,  AV30TFOrganisationPhone,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFOrganisationPhone_Sel)),  AV31TFOrganisationPhone_Sel,  AV31TFOrganisationPhone_Sel) ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV85Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV85Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Trn_Organisation";
         AV16Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table1_67_3N2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_udelete_Internalname, tblTabledvelop_confirmpanel_udelete_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_udelete.SetProperty("Title", Dvelop_confirmpanel_udelete_Title);
            ucDvelop_confirmpanel_udelete.SetProperty("ConfirmationText", Dvelop_confirmpanel_udelete_Confirmationtext);
            ucDvelop_confirmpanel_udelete.SetProperty("YesButtonCaption", Dvelop_confirmpanel_udelete_Yesbuttoncaption);
            ucDvelop_confirmpanel_udelete.SetProperty("NoButtonCaption", Dvelop_confirmpanel_udelete_Nobuttoncaption);
            ucDvelop_confirmpanel_udelete.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_udelete_Cancelbuttoncaption);
            ucDvelop_confirmpanel_udelete.SetProperty("YesButtonPosition", Dvelop_confirmpanel_udelete_Yesbuttonposition);
            ucDvelop_confirmpanel_udelete.SetProperty("ConfirmType", Dvelop_confirmpanel_udelete_Confirmtype);
            ucDvelop_confirmpanel_udelete.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_udelete_Internalname, "DVELOP_CONFIRMPANEL_UDELETEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_UDELETEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_67_3N2e( true) ;
         }
         else
         {
            wb_table1_67_3N2e( false) ;
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
         PA3N2( ) ;
         WS3N2( ) ;
         WE3N2( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256226412872", true, true);
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
         context.AddJavascriptSource("trn_organisationww.js", "?20256226412876", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_392( )
      {
         edtOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_39_idx;
         edtOrganisationName_Internalname = "ORGANISATIONNAME_"+sGXsfl_39_idx;
         edtOrganisationTypeName_Internalname = "ORGANISATIONTYPENAME_"+sGXsfl_39_idx;
         edtOrganisationKvkNumber_Internalname = "ORGANISATIONKVKNUMBER_"+sGXsfl_39_idx;
         edtOrganisationEmail_Internalname = "ORGANISATIONEMAIL_"+sGXsfl_39_idx;
         edtOrganisationPhone_Internalname = "ORGANISATIONPHONE_"+sGXsfl_39_idx;
         edtOrganisationVATNumber_Internalname = "ORGANISATIONVATNUMBER_"+sGXsfl_39_idx;
         edtOrganisationLogo_Internalname = "ORGANISATIONLOGO_"+sGXsfl_39_idx;
         edtOrganisationAddressCity_Internalname = "ORGANISATIONADDRESSCITY_"+sGXsfl_39_idx;
         edtOrganisationAddressZipCode_Internalname = "ORGANISATIONADDRESSZIPCODE_"+sGXsfl_39_idx;
         edtOrganisationAddressCountry_Internalname = "ORGANISATIONADDRESSCOUNTRY_"+sGXsfl_39_idx;
         edtOrganisationAddressLine1_Internalname = "ORGANISATIONADDRESSLINE1_"+sGXsfl_39_idx;
         edtOrganisationAddressLine2_Internalname = "ORGANISATIONADDRESSLINE2_"+sGXsfl_39_idx;
         edtavAddress_Internalname = "vADDRESS_"+sGXsfl_39_idx;
         edtOrganisationTypeId_Internalname = "ORGANISATIONTYPEID_"+sGXsfl_39_idx;
         edtOrganisationPhoneCode_Internalname = "ORGANISATIONPHONECODE_"+sGXsfl_39_idx;
         edtOrganisationPhoneNumber_Internalname = "ORGANISATIONPHONENUMBER_"+sGXsfl_39_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_39_idx;
      }

      protected void SubsflControlProps_fel_392( )
      {
         edtOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_39_fel_idx;
         edtOrganisationName_Internalname = "ORGANISATIONNAME_"+sGXsfl_39_fel_idx;
         edtOrganisationTypeName_Internalname = "ORGANISATIONTYPENAME_"+sGXsfl_39_fel_idx;
         edtOrganisationKvkNumber_Internalname = "ORGANISATIONKVKNUMBER_"+sGXsfl_39_fel_idx;
         edtOrganisationEmail_Internalname = "ORGANISATIONEMAIL_"+sGXsfl_39_fel_idx;
         edtOrganisationPhone_Internalname = "ORGANISATIONPHONE_"+sGXsfl_39_fel_idx;
         edtOrganisationVATNumber_Internalname = "ORGANISATIONVATNUMBER_"+sGXsfl_39_fel_idx;
         edtOrganisationLogo_Internalname = "ORGANISATIONLOGO_"+sGXsfl_39_fel_idx;
         edtOrganisationAddressCity_Internalname = "ORGANISATIONADDRESSCITY_"+sGXsfl_39_fel_idx;
         edtOrganisationAddressZipCode_Internalname = "ORGANISATIONADDRESSZIPCODE_"+sGXsfl_39_fel_idx;
         edtOrganisationAddressCountry_Internalname = "ORGANISATIONADDRESSCOUNTRY_"+sGXsfl_39_fel_idx;
         edtOrganisationAddressLine1_Internalname = "ORGANISATIONADDRESSLINE1_"+sGXsfl_39_fel_idx;
         edtOrganisationAddressLine2_Internalname = "ORGANISATIONADDRESSLINE2_"+sGXsfl_39_fel_idx;
         edtavAddress_Internalname = "vADDRESS_"+sGXsfl_39_fel_idx;
         edtOrganisationTypeId_Internalname = "ORGANISATIONTYPEID_"+sGXsfl_39_fel_idx;
         edtOrganisationPhoneCode_Internalname = "ORGANISATIONPHONECODE_"+sGXsfl_39_fel_idx;
         edtOrganisationPhoneNumber_Internalname = "ORGANISATIONPHONENUMBER_"+sGXsfl_39_fel_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_39_fel_idx;
      }

      protected void sendrow_392( )
      {
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_392( ) ;
         WB3N0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_39_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_39_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWithSelection WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_39_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationId_Internalname,A11OrganisationId.ToString(),A11OrganisationId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)39,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtOrganisationName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationName_Internalname,(string)A13OrganisationName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtOrganisationName_Link,(string)"",(string)"",(string)"",(string)edtOrganisationName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtOrganisationName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtOrganisationTypeName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationTypeName_Internalname,(string)A20OrganisationTypeName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationTypeName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtOrganisationTypeName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationKvkNumber_Internalname,(string)A12OrganisationKvkNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationKvkNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"KvkNumber",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtOrganisationEmail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationEmail_Internalname,(string)A16OrganisationEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A16OrganisationEmail,(string)"",(string)"",(string)"",(string)edtOrganisationEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtOrganisationEmail_Visible,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtOrganisationPhone_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A17OrganisationPhone);
            }
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationPhone_Internalname,StringUtil.RTrim( A17OrganisationPhone),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtOrganisationPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtOrganisationPhone_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationVATNumber_Internalname,(string)A18OrganisationVATNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationVATNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"VATNumber",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A506OrganisationLogo_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A506OrganisationLogo))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000OrganisationLogo_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A506OrganisationLogo)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A506OrganisationLogo)) ? A40000OrganisationLogo_GXI : context.PathToRelativeUrl( A506OrganisationLogo));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationLogo_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)0,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A506OrganisationLogo_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationAddressCity_Internalname,(string)A252OrganisationAddressCity,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationAddressCity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationAddressZipCode_Internalname,(string)A251OrganisationAddressZipCode,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationAddressZipCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationAddressCountry_Internalname,(string)A303OrganisationAddressCountry,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationAddressCountry_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationAddressLine1_Internalname,(string)A304OrganisationAddressLine1,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationAddressLine1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationAddressLine2_Internalname,(string)A305OrganisationAddressLine2,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationAddressLine2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavAddress_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_39_idx + "',39)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAddress_Internalname,(string)AV61Address,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( AV61Address),(string)"_blank",(string)"",(string)"",(string)edtavAddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavAddress_Visible,(int)edtavAddress_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationTypeId_Internalname,A19OrganisationTypeId.ToString(),A19OrganisationTypeId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationTypeId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)39,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationPhoneCode_Internalname,(string)A361OrganisationPhoneCode,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationPhoneCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationPhoneNumber_Internalname,(string)A362OrganisationPhoneNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationPhoneNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_39_idx + "',39)\"";
            if ( ( cmbavActiongroup.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vACTIONGROUP_" + sGXsfl_39_idx;
               cmbavActiongroup.Name = GXCCtl;
               cmbavActiongroup.WebTags = "";
               if ( cmbavActiongroup.ItemCount > 0 )
               {
                  AV72ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV72ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV72ActionGroup), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavActiongroup,(string)cmbavActiongroup_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV72ActionGroup), 4, 0)),(short)1,(string)cmbavActiongroup_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVACTIONGROUP.CLICK."+sGXsfl_39_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"",(string)"",(bool)true,(short)0});
            cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV72ActionGroup), 4, 0));
            AssignProp("", false, cmbavActiongroup_Internalname, "Values", (string)(cmbavActiongroup.ToJavascriptSource()), !bGXsfl_39_Refreshing);
            send_integrity_lvl_hashes3N2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_39_idx = ((subGrid_Islastpage==1)&&(nGXsfl_39_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         /* End function sendrow_392 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vACTIONGROUP_" + sGXsfl_39_idx;
         cmbavActiongroup.Name = GXCCtl;
         cmbavActiongroup.WebTags = "";
         if ( cmbavActiongroup.ItemCount > 0 )
         {
            AV72ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV72ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV72ActionGroup), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl39( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"39\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWithSelection WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtOrganisationName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtOrganisationTypeName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Type", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtOrganisationEmail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtOrganisationPhone_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavAddress_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Address", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A11OrganisationId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A13OrganisationName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtOrganisationName_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOrganisationName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A20OrganisationTypeName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOrganisationTypeName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A12OrganisationKvkNumber));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A16OrganisationEmail));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOrganisationEmail_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A17OrganisationPhone)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtOrganisationPhone_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A18OrganisationVATNumber));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( A506OrganisationLogo));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A252OrganisationAddressCity));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A251OrganisationAddressZipCode));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A303OrganisationAddressCountry));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A304OrganisationAddressLine1));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A305OrganisationAddressLine2));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV61Address));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAddress_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAddress_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A19OrganisationTypeId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A361OrganisationPhoneCode));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A362OrganisationPhoneNumber));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV72ActionGroup), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtninsertorganisation_Internalname = "BTNINSERTORGANISATION";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         bttBtnsubscriptions_Internalname = "BTNSUBSCRIPTIONS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         edtOrganisationName_Internalname = "ORGANISATIONNAME";
         edtOrganisationTypeName_Internalname = "ORGANISATIONTYPENAME";
         edtOrganisationKvkNumber_Internalname = "ORGANISATIONKVKNUMBER";
         edtOrganisationEmail_Internalname = "ORGANISATIONEMAIL";
         edtOrganisationPhone_Internalname = "ORGANISATIONPHONE";
         edtOrganisationVATNumber_Internalname = "ORGANISATIONVATNUMBER";
         edtOrganisationLogo_Internalname = "ORGANISATIONLOGO";
         edtOrganisationAddressCity_Internalname = "ORGANISATIONADDRESSCITY";
         edtOrganisationAddressZipCode_Internalname = "ORGANISATIONADDRESSZIPCODE";
         edtOrganisationAddressCountry_Internalname = "ORGANISATIONADDRESSCOUNTRY";
         edtOrganisationAddressLine1_Internalname = "ORGANISATIONADDRESSLINE1";
         edtOrganisationAddressLine2_Internalname = "ORGANISATIONADDRESSLINE2";
         edtavAddress_Internalname = "vADDRESS";
         edtOrganisationTypeId_Internalname = "ORGANISATIONTYPEID";
         edtOrganisationPhoneCode_Internalname = "ORGANISATIONPHONECODE";
         edtOrganisationPhoneNumber_Internalname = "ORGANISATIONPHONENUMBER";
         cmbavActiongroup_Internalname = "vACTIONGROUP";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Dvelop_confirmpanel_udelete_Internalname = "DVELOP_CONFIRMPANEL_UDELETE";
         tblTabledvelop_confirmpanel_udelete_Internalname = "TABLEDVELOP_CONFIRMPANEL_UDELETE";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowhovering = -1;
         subGrid_Allowselection = 1;
         subGrid_Header = "";
         cmbavActiongroup_Jsonclick = "";
         edtOrganisationPhoneNumber_Jsonclick = "";
         edtOrganisationPhoneCode_Jsonclick = "";
         edtOrganisationTypeId_Jsonclick = "";
         edtavAddress_Jsonclick = "";
         edtavAddress_Enabled = 1;
         edtOrganisationAddressLine2_Jsonclick = "";
         edtOrganisationAddressLine1_Jsonclick = "";
         edtOrganisationAddressCountry_Jsonclick = "";
         edtOrganisationAddressZipCode_Jsonclick = "";
         edtOrganisationAddressCity_Jsonclick = "";
         edtOrganisationVATNumber_Jsonclick = "";
         edtOrganisationPhone_Jsonclick = "";
         edtOrganisationEmail_Jsonclick = "";
         edtOrganisationKvkNumber_Jsonclick = "";
         edtOrganisationTypeName_Jsonclick = "";
         edtOrganisationName_Jsonclick = "";
         edtOrganisationName_Link = "";
         edtOrganisationId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavAddress_Visible = -1;
         edtOrganisationPhone_Visible = -1;
         edtOrganisationEmail_Visible = -1;
         edtOrganisationTypeName_Visible = -1;
         edtOrganisationName_Visible = -1;
         edtOrganisationPhoneNumber_Enabled = 0;
         edtOrganisationPhoneCode_Enabled = 0;
         edtOrganisationTypeId_Enabled = 0;
         edtOrganisationAddressLine2_Enabled = 0;
         edtOrganisationAddressLine1_Enabled = 0;
         edtOrganisationAddressCountry_Enabled = 0;
         edtOrganisationAddressZipCode_Enabled = 0;
         edtOrganisationAddressCity_Enabled = 0;
         edtOrganisationLogo_Enabled = 0;
         edtOrganisationVATNumber_Enabled = 0;
         edtOrganisationPhone_Enabled = 0;
         edtOrganisationEmail_Enabled = 0;
         edtOrganisationKvkNumber_Enabled = 0;
         edtOrganisationTypeName_Enabled = 0;
         edtOrganisationName_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsertorganisation_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Dvelop_confirmpanel_udelete_Confirmtype = "1";
         Dvelop_confirmpanel_udelete_Yesbuttonposition = "left";
         Dvelop_confirmpanel_udelete_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_udelete_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_udelete_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_udelete_Confirmationtext = "The following data associated with the organisation will be deleted: Locations, Services, Dynamic Forms, Pages, Agendas, Memos, Receptionists, Residents, Managers, Organisation Settings, Suppliers, Themes";
         Dvelop_confirmpanel_udelete_Title = context.GetMessage( "Confirm delete action", "");
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Datalistproc = "Trn_OrganisationWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4";
         Ddo_grid_Columnids = "1:OrganisationName|2:OrganisationTypeName|4:OrganisationEmail|5:OrganisationPhone";
         Ddo_grid_Gridinternalname = "";
         Ddc_subscriptions_Titlecontrolidtoreplace = "";
         Ddc_subscriptions_Cls = "ColumnsSelector";
         Ddc_subscriptions_Tooltip = "WWP_Subscriptions_Tooltip";
         Ddc_subscriptions_Caption = "";
         Ddc_subscriptions_Icon = "fas fa-rss";
         Ddc_subscriptions_Icontype = "FontIcon";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( " Organisations", "");
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV85Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV22TFOrganisationName","fld":"vTFORGANISATIONNAME"},{"av":"AV23TFOrganisationName_Sel","fld":"vTFORGANISATIONNAME_SEL"},{"av":"AV34TFOrganisationTypeName","fld":"vTFORGANISATIONTYPENAME"},{"av":"AV35TFOrganisationTypeName_Sel","fld":"vTFORGANISATIONTYPENAME_SEL"},{"av":"AV28TFOrganisationEmail","fld":"vTFORGANISATIONEMAIL"},{"av":"AV29TFOrganisationEmail_Sel","fld":"vTFORGANISATIONEMAIL_SEL"},{"av":"AV30TFOrganisationPhone","fld":"vTFORGANISATIONPHONE"},{"av":"AV31TFOrganisationPhone_Sel","fld":"vTFORGANISATIONPHONE_SEL"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV81IsAuthorized_ManageProvisioning","fld":"vISAUTHORIZED_MANAGEPROVISIONING","hsh":true},{"av":"AV52IsAuthorized_OrganisationName","fld":"vISAUTHORIZED_ORGANISATIONNAME","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV6WWPContext","fld":"vWWPCONTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtOrganisationName_Visible","ctrl":"ORGANISATIONNAME","prop":"Visible"},{"av":"edtOrganisationTypeName_Visible","ctrl":"ORGANISATIONTYPENAME","prop":"Visible"},{"av":"edtOrganisationEmail_Visible","ctrl":"ORGANISATIONEMAIL","prop":"Visible"},{"av":"edtOrganisationPhone_Visible","ctrl":"ORGANISATIONPHONE","prop":"Visible"},{"av":"edtavAddress_Visible","ctrl":"vADDRESS","prop":"Visible"},{"av":"AV40GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV41GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV42GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV81IsAuthorized_ManageProvisioning","fld":"vISAUTHORIZED_MANAGEPROVISIONING","hsh":true},{"ctrl":"BTNINSERTORGANISATION","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E123N2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV85Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV22TFOrganisationName","fld":"vTFORGANISATIONNAME"},{"av":"AV23TFOrganisationName_Sel","fld":"vTFORGANISATIONNAME_SEL"},{"av":"AV34TFOrganisationTypeName","fld":"vTFORGANISATIONTYPENAME"},{"av":"AV35TFOrganisationTypeName_Sel","fld":"vTFORGANISATIONTYPENAME_SEL"},{"av":"AV28TFOrganisationEmail","fld":"vTFORGANISATIONEMAIL"},{"av":"AV29TFOrganisationEmail_Sel","fld":"vTFORGANISATIONEMAIL_SEL"},{"av":"AV30TFOrganisationPhone","fld":"vTFORGANISATIONPHONE"},{"av":"AV31TFOrganisationPhone_Sel","fld":"vTFORGANISATIONPHONE_SEL"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV81IsAuthorized_ManageProvisioning","fld":"vISAUTHORIZED_MANAGEPROVISIONING","hsh":true},{"av":"AV52IsAuthorized_OrganisationName","fld":"vISAUTHORIZED_ORGANISATIONNAME","hsh":true},{"av":"AV6WWPContext","fld":"vWWPCONTEXT"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E133N2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV85Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV22TFOrganisationName","fld":"vTFORGANISATIONNAME"},{"av":"AV23TFOrganisationName_Sel","fld":"vTFORGANISATIONNAME_SEL"},{"av":"AV34TFOrganisationTypeName","fld":"vTFORGANISATIONTYPENAME"},{"av":"AV35TFOrganisationTypeName_Sel","fld":"vTFORGANISATIONTYPENAME_SEL"},{"av":"AV28TFOrganisationEmail","fld":"vTFORGANISATIONEMAIL"},{"av":"AV29TFOrganisationEmail_Sel","fld":"vTFORGANISATIONEMAIL_SEL"},{"av":"AV30TFOrganisationPhone","fld":"vTFORGANISATIONPHONE"},{"av":"AV31TFOrganisationPhone_Sel","fld":"vTFORGANISATIONPHONE_SEL"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV81IsAuthorized_ManageProvisioning","fld":"vISAUTHORIZED_MANAGEPROVISIONING","hsh":true},{"av":"AV52IsAuthorized_OrganisationName","fld":"vISAUTHORIZED_ORGANISATIONNAME","hsh":true},{"av":"AV6WWPContext","fld":"vWWPCONTEXT"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E153N2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV85Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV22TFOrganisationName","fld":"vTFORGANISATIONNAME"},{"av":"AV23TFOrganisationName_Sel","fld":"vTFORGANISATIONNAME_SEL"},{"av":"AV34TFOrganisationTypeName","fld":"vTFORGANISATIONTYPENAME"},{"av":"AV35TFOrganisationTypeName_Sel","fld":"vTFORGANISATIONTYPENAME_SEL"},{"av":"AV28TFOrganisationEmail","fld":"vTFORGANISATIONEMAIL"},{"av":"AV29TFOrganisationEmail_Sel","fld":"vTFORGANISATIONEMAIL_SEL"},{"av":"AV30TFOrganisationPhone","fld":"vTFORGANISATIONPHONE"},{"av":"AV31TFOrganisationPhone_Sel","fld":"vTFORGANISATIONPHONE_SEL"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV81IsAuthorized_ManageProvisioning","fld":"vISAUTHORIZED_MANAGEPROVISIONING","hsh":true},{"av":"AV52IsAuthorized_OrganisationName","fld":"vISAUTHORIZED_ORGANISATIONNAME","hsh":true},{"av":"AV6WWPContext","fld":"vWWPCONTEXT"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV22TFOrganisationName","fld":"vTFORGANISATIONNAME"},{"av":"AV23TFOrganisationName_Sel","fld":"vTFORGANISATIONNAME_SEL"},{"av":"AV34TFOrganisationTypeName","fld":"vTFORGANISATIONTYPENAME"},{"av":"AV35TFOrganisationTypeName_Sel","fld":"vTFORGANISATIONTYPENAME_SEL"},{"av":"AV28TFOrganisationEmail","fld":"vTFORGANISATIONEMAIL"},{"av":"AV29TFOrganisationEmail_Sel","fld":"vTFORGANISATIONEMAIL_SEL"},{"av":"AV30TFOrganisationPhone","fld":"vTFORGANISATIONPHONE"},{"av":"AV31TFOrganisationPhone_Sel","fld":"vTFORGANISATIONPHONE_SEL"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E213N2","iparms":[{"av":"A303OrganisationAddressCountry","fld":"ORGANISATIONADDRESSCOUNTRY"},{"av":"A252OrganisationAddressCity","fld":"ORGANISATIONADDRESSCITY"},{"av":"A251OrganisationAddressZipCode","fld":"ORGANISATIONADDRESSZIPCODE"},{"av":"A304OrganisationAddressLine1","fld":"ORGANISATIONADDRESSLINE1"},{"av":"A305OrganisationAddressLine2","fld":"ORGANISATIONADDRESSLINE2"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV81IsAuthorized_ManageProvisioning","fld":"vISAUTHORIZED_MANAGEPROVISIONING","hsh":true},{"av":"AV52IsAuthorized_OrganisationName","fld":"vISAUTHORIZED_ORGANISATIONNAME","hsh":true},{"av":"A11OrganisationId","fld":"ORGANISATIONID","hsh":true},{"av":"AV6WWPContext","fld":"vWWPCONTEXT"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV61Address","fld":"vADDRESS"},{"av":"cmbavActiongroup"},{"av":"AV72ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"edtOrganisationName_Link","ctrl":"ORGANISATIONNAME","prop":"Link"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E163N2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV85Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV22TFOrganisationName","fld":"vTFORGANISATIONNAME"},{"av":"AV23TFOrganisationName_Sel","fld":"vTFORGANISATIONNAME_SEL"},{"av":"AV34TFOrganisationTypeName","fld":"vTFORGANISATIONTYPENAME"},{"av":"AV35TFOrganisationTypeName_Sel","fld":"vTFORGANISATIONTYPENAME_SEL"},{"av":"AV28TFOrganisationEmail","fld":"vTFORGANISATIONEMAIL"},{"av":"AV29TFOrganisationEmail_Sel","fld":"vTFORGANISATIONEMAIL_SEL"},{"av":"AV30TFOrganisationPhone","fld":"vTFORGANISATIONPHONE"},{"av":"AV31TFOrganisationPhone_Sel","fld":"vTFORGANISATIONPHONE_SEL"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV81IsAuthorized_ManageProvisioning","fld":"vISAUTHORIZED_MANAGEPROVISIONING","hsh":true},{"av":"AV52IsAuthorized_OrganisationName","fld":"vISAUTHORIZED_ORGANISATIONNAME","hsh":true},{"av":"AV6WWPContext","fld":"vWWPCONTEXT"},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtOrganisationName_Visible","ctrl":"ORGANISATIONNAME","prop":"Visible"},{"av":"edtOrganisationTypeName_Visible","ctrl":"ORGANISATIONTYPENAME","prop":"Visible"},{"av":"edtOrganisationEmail_Visible","ctrl":"ORGANISATIONEMAIL","prop":"Visible"},{"av":"edtOrganisationPhone_Visible","ctrl":"ORGANISATIONPHONE","prop":"Visible"},{"av":"edtavAddress_Visible","ctrl":"vADDRESS","prop":"Visible"},{"av":"AV40GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV41GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV42GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV81IsAuthorized_ManageProvisioning","fld":"vISAUTHORIZED_MANAGEPROVISIONING","hsh":true},{"ctrl":"BTNINSERTORGANISATION","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E113N2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV85Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV22TFOrganisationName","fld":"vTFORGANISATIONNAME"},{"av":"AV23TFOrganisationName_Sel","fld":"vTFORGANISATIONNAME_SEL"},{"av":"AV34TFOrganisationTypeName","fld":"vTFORGANISATIONTYPENAME"},{"av":"AV35TFOrganisationTypeName_Sel","fld":"vTFORGANISATIONTYPENAME_SEL"},{"av":"AV28TFOrganisationEmail","fld":"vTFORGANISATIONEMAIL"},{"av":"AV29TFOrganisationEmail_Sel","fld":"vTFORGANISATIONEMAIL_SEL"},{"av":"AV30TFOrganisationPhone","fld":"vTFORGANISATIONPHONE"},{"av":"AV31TFOrganisationPhone_Sel","fld":"vTFORGANISATIONPHONE_SEL"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV81IsAuthorized_ManageProvisioning","fld":"vISAUTHORIZED_MANAGEPROVISIONING","hsh":true},{"av":"AV52IsAuthorized_OrganisationName","fld":"vISAUTHORIZED_ORGANISATIONNAME","hsh":true},{"av":"AV6WWPContext","fld":"vWWPCONTEXT"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV22TFOrganisationName","fld":"vTFORGANISATIONNAME"},{"av":"AV23TFOrganisationName_Sel","fld":"vTFORGANISATIONNAME_SEL"},{"av":"AV34TFOrganisationTypeName","fld":"vTFORGANISATIONTYPENAME"},{"av":"AV35TFOrganisationTypeName_Sel","fld":"vTFORGANISATIONTYPENAME_SEL"},{"av":"AV28TFOrganisationEmail","fld":"vTFORGANISATIONEMAIL"},{"av":"AV29TFOrganisationEmail_Sel","fld":"vTFORGANISATIONEMAIL_SEL"},{"av":"AV30TFOrganisationPhone","fld":"vTFORGANISATIONPHONE"},{"av":"AV31TFOrganisationPhone_Sel","fld":"vTFORGANISATIONPHONE_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtOrganisationName_Visible","ctrl":"ORGANISATIONNAME","prop":"Visible"},{"av":"edtOrganisationTypeName_Visible","ctrl":"ORGANISATIONTYPENAME","prop":"Visible"},{"av":"edtOrganisationEmail_Visible","ctrl":"ORGANISATIONEMAIL","prop":"Visible"},{"av":"edtOrganisationPhone_Visible","ctrl":"ORGANISATIONPHONE","prop":"Visible"},{"av":"edtavAddress_Visible","ctrl":"vADDRESS","prop":"Visible"},{"av":"AV40GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV41GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV42GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV81IsAuthorized_ManageProvisioning","fld":"vISAUTHORIZED_MANAGEPROVISIONING","hsh":true},{"ctrl":"BTNINSERTORGANISATION","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VACTIONGROUP.CLICK","""{"handler":"E223N2","iparms":[{"av":"cmbavActiongroup"},{"av":"AV72ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV85Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV22TFOrganisationName","fld":"vTFORGANISATIONNAME"},{"av":"AV23TFOrganisationName_Sel","fld":"vTFORGANISATIONNAME_SEL"},{"av":"AV34TFOrganisationTypeName","fld":"vTFORGANISATIONTYPENAME"},{"av":"AV35TFOrganisationTypeName_Sel","fld":"vTFORGANISATIONTYPENAME_SEL"},{"av":"AV28TFOrganisationEmail","fld":"vTFORGANISATIONEMAIL"},{"av":"AV29TFOrganisationEmail_Sel","fld":"vTFORGANISATIONEMAIL_SEL"},{"av":"AV30TFOrganisationPhone","fld":"vTFORGANISATIONPHONE"},{"av":"AV31TFOrganisationPhone_Sel","fld":"vTFORGANISATIONPHONE_SEL"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV81IsAuthorized_ManageProvisioning","fld":"vISAUTHORIZED_MANAGEPROVISIONING","hsh":true},{"av":"AV52IsAuthorized_OrganisationName","fld":"vISAUTHORIZED_ORGANISATIONNAME","hsh":true},{"av":"AV6WWPContext","fld":"vWWPCONTEXT"},{"av":"A11OrganisationId","fld":"ORGANISATIONID","hsh":true},{"av":"A13OrganisationName","fld":"ORGANISATIONNAME","hsh":true}]""");
         setEventMetadata("VACTIONGROUP.CLICK",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV72ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT"},{"av":"Dvelop_confirmpanel_udelete_Title","ctrl":"DVELOP_CONFIRMPANEL_UDELETE","prop":"Title"},{"av":"Dvelop_confirmpanel_udelete_Confirmationtext","ctrl":"DVELOP_CONFIRMPANEL_UDELETE","prop":"ConfirmationText"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtOrganisationName_Visible","ctrl":"ORGANISATIONNAME","prop":"Visible"},{"av":"edtOrganisationTypeName_Visible","ctrl":"ORGANISATIONTYPENAME","prop":"Visible"},{"av":"edtOrganisationEmail_Visible","ctrl":"ORGANISATIONEMAIL","prop":"Visible"},{"av":"edtOrganisationPhone_Visible","ctrl":"ORGANISATIONPHONE","prop":"Visible"},{"av":"edtavAddress_Visible","ctrl":"vADDRESS","prop":"Visible"},{"av":"AV40GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV41GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV42GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV81IsAuthorized_ManageProvisioning","fld":"vISAUTHORIZED_MANAGEPROVISIONING","hsh":true},{"ctrl":"BTNINSERTORGANISATION","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_UDELETE.CLOSE","""{"handler":"E173N2","iparms":[{"av":"Dvelop_confirmpanel_udelete_Result","ctrl":"DVELOP_CONFIRMPANEL_UDELETE","prop":"Result"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV85Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV22TFOrganisationName","fld":"vTFORGANISATIONNAME"},{"av":"AV23TFOrganisationName_Sel","fld":"vTFORGANISATIONNAME_SEL"},{"av":"AV34TFOrganisationTypeName","fld":"vTFORGANISATIONTYPENAME"},{"av":"AV35TFOrganisationTypeName_Sel","fld":"vTFORGANISATIONTYPENAME_SEL"},{"av":"AV28TFOrganisationEmail","fld":"vTFORGANISATIONEMAIL"},{"av":"AV29TFOrganisationEmail_Sel","fld":"vTFORGANISATIONEMAIL_SEL"},{"av":"AV30TFOrganisationPhone","fld":"vTFORGANISATIONPHONE"},{"av":"AV31TFOrganisationPhone_Sel","fld":"vTFORGANISATIONPHONE_SEL"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV81IsAuthorized_ManageProvisioning","fld":"vISAUTHORIZED_MANAGEPROVISIONING","hsh":true},{"av":"AV52IsAuthorized_OrganisationName","fld":"vISAUTHORIZED_ORGANISATIONNAME","hsh":true},{"av":"AV6WWPContext","fld":"vWWPCONTEXT"},{"av":"A11OrganisationId","fld":"ORGANISATIONID","hsh":true},{"av":"AV83isSuccessful","fld":"vISSUCCESSFUL"},{"av":"AV84Message","fld":"vMESSAGE"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_UDELETE.CLOSE",""","oparms":[{"av":"AV84Message","fld":"vMESSAGE"},{"av":"AV83isSuccessful","fld":"vISSUCCESSFUL"},{"av":"AV6WWPContext","fld":"vWWPCONTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV77ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtOrganisationName_Visible","ctrl":"ORGANISATIONNAME","prop":"Visible"},{"av":"edtOrganisationTypeName_Visible","ctrl":"ORGANISATIONTYPENAME","prop":"Visible"},{"av":"edtOrganisationEmail_Visible","ctrl":"ORGANISATIONEMAIL","prop":"Visible"},{"av":"edtOrganisationPhone_Visible","ctrl":"ORGANISATIONPHONE","prop":"Visible"},{"av":"edtavAddress_Visible","ctrl":"vADDRESS","prop":"Visible"},{"av":"AV40GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV41GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV42GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV48IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV50IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV81IsAuthorized_ManageProvisioning","fld":"vISAUTHORIZED_MANAGEPROVISIONING","hsh":true},{"ctrl":"BTNINSERTORGANISATION","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("'DOINSERTORGANISATION'","""{"handler":"E183N2","iparms":[]}""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","""{"handler":"E143N2","iparms":[]""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("VALID_ORGANISATIONTYPEID","""{"handler":"Valid_Organisationtypeid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Actiongroup","iparms":[]}""");
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
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Dvelop_confirmpanel_udelete_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV15FilterFullText = "";
         AV77ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV85Pgmname = "";
         AV22TFOrganisationName = "";
         AV23TFOrganisationName_Sel = "";
         AV34TFOrganisationTypeName = "";
         AV35TFOrganisationTypeName_Sel = "";
         AV28TFOrganisationEmail = "";
         AV29TFOrganisationEmail_Sel = "";
         AV30TFOrganisationPhone = "";
         AV31TFOrganisationPhone_Sel = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV17ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV42GridAppliedFilters = "";
         AV36DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV84Message = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsertorganisation_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         bttBtnsubscriptions_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A11OrganisationId = Guid.Empty;
         A13OrganisationName = "";
         A20OrganisationTypeName = "";
         A12OrganisationKvkNumber = "";
         A16OrganisationEmail = "";
         A17OrganisationPhone = "";
         A18OrganisationVATNumber = "";
         A506OrganisationLogo = "";
         A40000OrganisationLogo_GXI = "";
         A252OrganisationAddressCity = "";
         A251OrganisationAddressZipCode = "";
         A303OrganisationAddressCountry = "";
         A304OrganisationAddressLine1 = "";
         A305OrganisationAddressLine2 = "";
         AV61Address = "";
         A19OrganisationTypeId = Guid.Empty;
         A361OrganisationPhoneCode = "";
         A362OrganisationPhoneNumber = "";
         lV86Trn_organisationwwds_1_filterfulltext = "";
         lV87Trn_organisationwwds_2_tforganisationname = "";
         lV89Trn_organisationwwds_4_tforganisationtypename = "";
         lV91Trn_organisationwwds_6_tforganisationemail = "";
         lV93Trn_organisationwwds_8_tforganisationphone = "";
         AV86Trn_organisationwwds_1_filterfulltext = "";
         AV88Trn_organisationwwds_3_tforganisationname_sel = "";
         AV87Trn_organisationwwds_2_tforganisationname = "";
         AV90Trn_organisationwwds_5_tforganisationtypename_sel = "";
         AV89Trn_organisationwwds_4_tforganisationtypename = "";
         AV92Trn_organisationwwds_7_tforganisationemail_sel = "";
         AV91Trn_organisationwwds_6_tforganisationemail = "";
         AV94Trn_organisationwwds_9_tforganisationphone_sel = "";
         AV93Trn_organisationwwds_8_tforganisationphone = "";
         H003N2_A362OrganisationPhoneNumber = new string[] {""} ;
         H003N2_A361OrganisationPhoneCode = new string[] {""} ;
         H003N2_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         H003N2_A305OrganisationAddressLine2 = new string[] {""} ;
         H003N2_A304OrganisationAddressLine1 = new string[] {""} ;
         H003N2_A303OrganisationAddressCountry = new string[] {""} ;
         H003N2_A251OrganisationAddressZipCode = new string[] {""} ;
         H003N2_A252OrganisationAddressCity = new string[] {""} ;
         H003N2_A40000OrganisationLogo_GXI = new string[] {""} ;
         H003N2_A18OrganisationVATNumber = new string[] {""} ;
         H003N2_A17OrganisationPhone = new string[] {""} ;
         H003N2_A16OrganisationEmail = new string[] {""} ;
         H003N2_A12OrganisationKvkNumber = new string[] {""} ;
         H003N2_A20OrganisationTypeName = new string[] {""} ;
         H003N2_A13OrganisationName = new string[] {""} ;
         H003N2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H003N2_A506OrganisationLogo = new string[] {""} ;
         H003N3_AGRID_nRecordCount = new long[1] ;
         AV79successmsg = "";
         AV80websession = context.GetSession();
         AV8HTTPRequest = new GxHttpRequest( context);
         AV37GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV38GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV16Session = context.GetSession();
         AV75ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV18ManageFiltersXml = "";
         AV76UserCustomValue = "";
         AV78ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         ucDvelop_confirmpanel_udelete = new GXUserControl();
         AV95Organisationid_selected = Guid.Empty;
         AV12GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char3 = "";
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         gxphoneLink = "";
         sImgUrl = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationww__default(),
            new Object[][] {
                new Object[] {
               H003N2_A362OrganisationPhoneNumber, H003N2_A361OrganisationPhoneCode, H003N2_A19OrganisationTypeId, H003N2_A305OrganisationAddressLine2, H003N2_A304OrganisationAddressLine1, H003N2_A303OrganisationAddressCountry, H003N2_A251OrganisationAddressZipCode, H003N2_A252OrganisationAddressCity, H003N2_A40000OrganisationLogo_GXI, H003N2_A18OrganisationVATNumber,
               H003N2_A17OrganisationPhone, H003N2_A16OrganisationEmail, H003N2_A12OrganisationKvkNumber, H003N2_A20OrganisationTypeName, H003N2_A13OrganisationName, H003N2_A11OrganisationId, H003N2_A506OrganisationLogo
               }
               , new Object[] {
               H003N3_AGRID_nRecordCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV85Pgmname = "Trn_OrganisationWW";
         /* GeneXus formulas. */
         AV85Pgmname = "Trn_OrganisationWW";
         edtavAddress_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV19ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV72ActionGroup ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_39 ;
      private int nGXsfl_39_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsertorganisation_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavAddress_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtOrganisationId_Enabled ;
      private int edtOrganisationName_Enabled ;
      private int edtOrganisationTypeName_Enabled ;
      private int edtOrganisationKvkNumber_Enabled ;
      private int edtOrganisationEmail_Enabled ;
      private int edtOrganisationPhone_Enabled ;
      private int edtOrganisationVATNumber_Enabled ;
      private int edtOrganisationLogo_Enabled ;
      private int edtOrganisationAddressCity_Enabled ;
      private int edtOrganisationAddressZipCode_Enabled ;
      private int edtOrganisationAddressCountry_Enabled ;
      private int edtOrganisationAddressLine1_Enabled ;
      private int edtOrganisationAddressLine2_Enabled ;
      private int edtOrganisationTypeId_Enabled ;
      private int edtOrganisationPhoneCode_Enabled ;
      private int edtOrganisationPhoneNumber_Enabled ;
      private int edtOrganisationName_Visible ;
      private int edtOrganisationTypeName_Visible ;
      private int edtOrganisationEmail_Visible ;
      private int edtOrganisationPhone_Visible ;
      private int edtavAddress_Visible ;
      private int AV39PageToGo ;
      private int AV96GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV40GridCurrentPage ;
      private long AV41GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Dvelop_confirmpanel_udelete_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_39_idx="0001" ;
      private string AV85Pgmname ;
      private string AV30TFOrganisationPhone ;
      private string AV31TFOrganisationPhone_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV84Message ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Ddc_subscriptions_Icontype ;
      private string Ddc_subscriptions_Icon ;
      private string Ddc_subscriptions_Caption ;
      private string Ddc_subscriptions_Tooltip ;
      private string Ddc_subscriptions_Cls ;
      private string Ddc_subscriptions_Titlecontrolidtoreplace ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gamoauthtoken ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Dvelop_confirmpanel_udelete_Title ;
      private string Dvelop_confirmpanel_udelete_Confirmationtext ;
      private string Dvelop_confirmpanel_udelete_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_udelete_Nobuttoncaption ;
      private string Dvelop_confirmpanel_udelete_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_udelete_Yesbuttonposition ;
      private string Dvelop_confirmpanel_udelete_Confirmtype ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsertorganisation_Internalname ;
      private string bttBtninsertorganisation_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string bttBtnsubscriptions_Internalname ;
      private string bttBtnsubscriptions_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddc_subscriptions_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtOrganisationId_Internalname ;
      private string edtOrganisationName_Internalname ;
      private string edtOrganisationTypeName_Internalname ;
      private string edtOrganisationKvkNumber_Internalname ;
      private string edtOrganisationEmail_Internalname ;
      private string A17OrganisationPhone ;
      private string edtOrganisationPhone_Internalname ;
      private string edtOrganisationVATNumber_Internalname ;
      private string edtOrganisationLogo_Internalname ;
      private string edtOrganisationAddressCity_Internalname ;
      private string edtOrganisationAddressZipCode_Internalname ;
      private string edtOrganisationAddressCountry_Internalname ;
      private string edtOrganisationAddressLine1_Internalname ;
      private string edtOrganisationAddressLine2_Internalname ;
      private string edtavAddress_Internalname ;
      private string edtOrganisationTypeId_Internalname ;
      private string edtOrganisationPhoneCode_Internalname ;
      private string edtOrganisationPhoneNumber_Internalname ;
      private string cmbavActiongroup_Internalname ;
      private string lV93Trn_organisationwwds_8_tforganisationphone ;
      private string AV94Trn_organisationwwds_9_tforganisationphone_sel ;
      private string AV93Trn_organisationwwds_8_tforganisationphone ;
      private string edtOrganisationName_Link ;
      private string GXEncryptionTmp ;
      private string Dvelop_confirmpanel_udelete_Internalname ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string tblTabledvelop_confirmpanel_udelete_Internalname ;
      private string sGXsfl_39_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtOrganisationId_Jsonclick ;
      private string edtOrganisationName_Jsonclick ;
      private string edtOrganisationTypeName_Jsonclick ;
      private string edtOrganisationKvkNumber_Jsonclick ;
      private string edtOrganisationEmail_Jsonclick ;
      private string gxphoneLink ;
      private string edtOrganisationPhone_Jsonclick ;
      private string edtOrganisationVATNumber_Jsonclick ;
      private string sImgUrl ;
      private string edtOrganisationAddressCity_Jsonclick ;
      private string edtOrganisationAddressZipCode_Jsonclick ;
      private string edtOrganisationAddressCountry_Jsonclick ;
      private string edtOrganisationAddressLine1_Jsonclick ;
      private string edtOrganisationAddressLine2_Jsonclick ;
      private string edtavAddress_Jsonclick ;
      private string edtOrganisationTypeId_Jsonclick ;
      private string edtOrganisationPhoneCode_Jsonclick ;
      private string edtOrganisationPhoneNumber_Jsonclick ;
      private string GXCCtl ;
      private string cmbavActiongroup_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV46IsAuthorized_Display ;
      private bool AV48IsAuthorized_Update ;
      private bool AV50IsAuthorized_Delete ;
      private bool AV81IsAuthorized_ManageProvisioning ;
      private bool AV52IsAuthorized_OrganisationName ;
      private bool AV83isSuccessful ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_39_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV73IsAuthorized_InsertOrganisation ;
      private bool GXt_boolean1 ;
      private bool A506OrganisationLogo_IsBlob ;
      private string AV75ColumnsSelectorXML ;
      private string AV18ManageFiltersXml ;
      private string AV76UserCustomValue ;
      private string AV15FilterFullText ;
      private string AV22TFOrganisationName ;
      private string AV23TFOrganisationName_Sel ;
      private string AV34TFOrganisationTypeName ;
      private string AV35TFOrganisationTypeName_Sel ;
      private string AV28TFOrganisationEmail ;
      private string AV29TFOrganisationEmail_Sel ;
      private string AV42GridAppliedFilters ;
      private string A13OrganisationName ;
      private string A20OrganisationTypeName ;
      private string A12OrganisationKvkNumber ;
      private string A16OrganisationEmail ;
      private string A18OrganisationVATNumber ;
      private string A40000OrganisationLogo_GXI ;
      private string A252OrganisationAddressCity ;
      private string A251OrganisationAddressZipCode ;
      private string A303OrganisationAddressCountry ;
      private string A304OrganisationAddressLine1 ;
      private string A305OrganisationAddressLine2 ;
      private string AV61Address ;
      private string A361OrganisationPhoneCode ;
      private string A362OrganisationPhoneNumber ;
      private string lV86Trn_organisationwwds_1_filterfulltext ;
      private string lV87Trn_organisationwwds_2_tforganisationname ;
      private string lV89Trn_organisationwwds_4_tforganisationtypename ;
      private string lV91Trn_organisationwwds_6_tforganisationemail ;
      private string AV86Trn_organisationwwds_1_filterfulltext ;
      private string AV88Trn_organisationwwds_3_tforganisationname_sel ;
      private string AV87Trn_organisationwwds_2_tforganisationname ;
      private string AV90Trn_organisationwwds_5_tforganisationtypename_sel ;
      private string AV89Trn_organisationwwds_4_tforganisationtypename ;
      private string AV92Trn_organisationwwds_7_tforganisationemail_sel ;
      private string AV91Trn_organisationwwds_6_tforganisationemail ;
      private string AV79successmsg ;
      private string A506OrganisationLogo ;
      private Guid A11OrganisationId ;
      private Guid A19OrganisationTypeId ;
      private Guid AV95Organisationid_selected ;
      private IGxSession AV80websession ;
      private IGxSession AV16Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDvelop_confirmpanel_udelete ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavActiongroup ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV77ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV17ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV36DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV11GridState ;
      private IDataStoreProvider pr_default ;
      private string[] H003N2_A362OrganisationPhoneNumber ;
      private string[] H003N2_A361OrganisationPhoneCode ;
      private Guid[] H003N2_A19OrganisationTypeId ;
      private string[] H003N2_A305OrganisationAddressLine2 ;
      private string[] H003N2_A304OrganisationAddressLine1 ;
      private string[] H003N2_A303OrganisationAddressCountry ;
      private string[] H003N2_A251OrganisationAddressZipCode ;
      private string[] H003N2_A252OrganisationAddressCity ;
      private string[] H003N2_A40000OrganisationLogo_GXI ;
      private string[] H003N2_A18OrganisationVATNumber ;
      private string[] H003N2_A17OrganisationPhone ;
      private string[] H003N2_A16OrganisationEmail ;
      private string[] H003N2_A12OrganisationKvkNumber ;
      private string[] H003N2_A20OrganisationTypeName ;
      private string[] H003N2_A13OrganisationName ;
      private Guid[] H003N2_A11OrganisationId ;
      private string[] H003N2_A506OrganisationLogo ;
      private long[] H003N3_AGRID_nRecordCount ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV37GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV38GAMErrors ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV78ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_organisationww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H003N2( IGxContext context ,
                                             string AV86Trn_organisationwwds_1_filterfulltext ,
                                             string AV88Trn_organisationwwds_3_tforganisationname_sel ,
                                             string AV87Trn_organisationwwds_2_tforganisationname ,
                                             string AV90Trn_organisationwwds_5_tforganisationtypename_sel ,
                                             string AV89Trn_organisationwwds_4_tforganisationtypename ,
                                             string AV92Trn_organisationwwds_7_tforganisationemail_sel ,
                                             string AV91Trn_organisationwwds_6_tforganisationemail ,
                                             string AV94Trn_organisationwwds_9_tforganisationphone_sel ,
                                             string AV93Trn_organisationwwds_8_tforganisationphone ,
                                             string A13OrganisationName ,
                                             string A20OrganisationTypeName ,
                                             string A16OrganisationEmail ,
                                             string A17OrganisationPhone ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[15];
         Object[] GXv_Object9 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.OrganisationPhoneNumber, T1.OrganisationPhoneCode, T1.OrganisationTypeId, T1.OrganisationAddressLine2, T1.OrganisationAddressLine1, T1.OrganisationAddressCountry, T1.OrganisationAddressZipCode, T1.OrganisationAddressCity, T1.OrganisationLogo_GXI, T1.OrganisationVATNumber, T1.OrganisationPhone, T1.OrganisationEmail, T1.OrganisationKvkNumber, T2.OrganisationTypeName, T1.OrganisationName, T1.OrganisationId, T1.OrganisationLogo";
         sFromString = " FROM (Trn_Organisation T1 INNER JOIN Trn_OrganisationType T2 ON T2.OrganisationTypeId = T1.OrganisationTypeId)";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Trn_organisationwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.OrganisationName) like '%' || LOWER(:lV86Trn_organisationwwds_1_filterfulltext)) or ( LOWER(T2.OrganisationTypeName) like '%' || LOWER(:lV86Trn_organisationwwds_1_filterfulltext)) or ( LOWER(T1.OrganisationEmail) like '%' || LOWER(:lV86Trn_organisationwwds_1_filterfulltext)) or ( LOWER(T1.OrganisationPhone) like '%' || LOWER(:lV86Trn_organisationwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Trn_organisationwwds_3_tforganisationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Trn_organisationwwds_2_tforganisationname)) ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationName like :lV87Trn_organisationwwds_2_tforganisationname)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Trn_organisationwwds_3_tforganisationname_sel)) && ! ( StringUtil.StrCmp(AV88Trn_organisationwwds_3_tforganisationname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationName = ( :AV88Trn_organisationwwds_3_tforganisationname_sel))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( StringUtil.StrCmp(AV88Trn_organisationwwds_3_tforganisationname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.OrganisationName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Trn_organisationwwds_5_tforganisationtypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Trn_organisationwwds_4_tforganisationtypename)) ) )
         {
            AddWhere(sWhereString, "(T2.OrganisationTypeName like :lV89Trn_organisationwwds_4_tforganisationtypename)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Trn_organisationwwds_5_tforganisationtypename_sel)) && ! ( StringUtil.StrCmp(AV90Trn_organisationwwds_5_tforganisationtypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.OrganisationTypeName = ( :AV90Trn_organisationwwds_5_tforganisationtypename_sel))");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( StringUtil.StrCmp(AV90Trn_organisationwwds_5_tforganisationtypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.OrganisationTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Trn_organisationwwds_7_tforganisationemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Trn_organisationwwds_6_tforganisationemail)) ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationEmail like :lV91Trn_organisationwwds_6_tforganisationemail)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Trn_organisationwwds_7_tforganisationemail_sel)) && ! ( StringUtil.StrCmp(AV92Trn_organisationwwds_7_tforganisationemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationEmail = ( :AV92Trn_organisationwwds_7_tforganisationemail_sel))");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( StringUtil.StrCmp(AV92Trn_organisationwwds_7_tforganisationemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.OrganisationEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Trn_organisationwwds_9_tforganisationphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Trn_organisationwwds_8_tforganisationphone)) ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationPhone like :lV93Trn_organisationwwds_8_tforganisationphone)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Trn_organisationwwds_9_tforganisationphone_sel)) && ! ( StringUtil.StrCmp(AV94Trn_organisationwwds_9_tforganisationphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationPhone = ( :AV94Trn_organisationwwds_9_tforganisationphone_sel))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( StringUtil.StrCmp(AV94Trn_organisationwwds_9_tforganisationphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.OrganisationPhone))=0))");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.OrganisationName, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.OrganisationName DESC, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.OrganisationTypeName, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.OrganisationTypeName DESC, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.OrganisationEmail, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.OrganisationEmail DESC, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.OrganisationPhone, T1.OrganisationId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.OrganisationPhone DESC, T1.OrganisationId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.OrganisationId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H003N3( IGxContext context ,
                                             string AV86Trn_organisationwwds_1_filterfulltext ,
                                             string AV88Trn_organisationwwds_3_tforganisationname_sel ,
                                             string AV87Trn_organisationwwds_2_tforganisationname ,
                                             string AV90Trn_organisationwwds_5_tforganisationtypename_sel ,
                                             string AV89Trn_organisationwwds_4_tforganisationtypename ,
                                             string AV92Trn_organisationwwds_7_tforganisationemail_sel ,
                                             string AV91Trn_organisationwwds_6_tforganisationemail ,
                                             string AV94Trn_organisationwwds_9_tforganisationphone_sel ,
                                             string AV93Trn_organisationwwds_8_tforganisationphone ,
                                             string A13OrganisationName ,
                                             string A20OrganisationTypeName ,
                                             string A16OrganisationEmail ,
                                             string A17OrganisationPhone ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[12];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (Trn_Organisation T1 INNER JOIN Trn_OrganisationType T2 ON T2.OrganisationTypeId = T1.OrganisationTypeId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Trn_organisationwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.OrganisationName) like '%' || LOWER(:lV86Trn_organisationwwds_1_filterfulltext)) or ( LOWER(T2.OrganisationTypeName) like '%' || LOWER(:lV86Trn_organisationwwds_1_filterfulltext)) or ( LOWER(T1.OrganisationEmail) like '%' || LOWER(:lV86Trn_organisationwwds_1_filterfulltext)) or ( LOWER(T1.OrganisationPhone) like '%' || LOWER(:lV86Trn_organisationwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int10[0] = 1;
            GXv_int10[1] = 1;
            GXv_int10[2] = 1;
            GXv_int10[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Trn_organisationwwds_3_tforganisationname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Trn_organisationwwds_2_tforganisationname)) ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationName like :lV87Trn_organisationwwds_2_tforganisationname)");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Trn_organisationwwds_3_tforganisationname_sel)) && ! ( StringUtil.StrCmp(AV88Trn_organisationwwds_3_tforganisationname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationName = ( :AV88Trn_organisationwwds_3_tforganisationname_sel))");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( StringUtil.StrCmp(AV88Trn_organisationwwds_3_tforganisationname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.OrganisationName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Trn_organisationwwds_5_tforganisationtypename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Trn_organisationwwds_4_tforganisationtypename)) ) )
         {
            AddWhere(sWhereString, "(T2.OrganisationTypeName like :lV89Trn_organisationwwds_4_tforganisationtypename)");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Trn_organisationwwds_5_tforganisationtypename_sel)) && ! ( StringUtil.StrCmp(AV90Trn_organisationwwds_5_tforganisationtypename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.OrganisationTypeName = ( :AV90Trn_organisationwwds_5_tforganisationtypename_sel))");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( StringUtil.StrCmp(AV90Trn_organisationwwds_5_tforganisationtypename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.OrganisationTypeName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Trn_organisationwwds_7_tforganisationemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Trn_organisationwwds_6_tforganisationemail)) ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationEmail like :lV91Trn_organisationwwds_6_tforganisationemail)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Trn_organisationwwds_7_tforganisationemail_sel)) && ! ( StringUtil.StrCmp(AV92Trn_organisationwwds_7_tforganisationemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationEmail = ( :AV92Trn_organisationwwds_7_tforganisationemail_sel))");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( StringUtil.StrCmp(AV92Trn_organisationwwds_7_tforganisationemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.OrganisationEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Trn_organisationwwds_9_tforganisationphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Trn_organisationwwds_8_tforganisationphone)) ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationPhone like :lV93Trn_organisationwwds_8_tforganisationphone)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Trn_organisationwwds_9_tforganisationphone_sel)) && ! ( StringUtil.StrCmp(AV94Trn_organisationwwds_9_tforganisationphone_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.OrganisationPhone = ( :AV94Trn_organisationwwds_9_tforganisationphone_sel))");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( StringUtil.StrCmp(AV94Trn_organisationwwds_9_tforganisationphone_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.OrganisationPhone))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H003N2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
               case 1 :
                     return conditional_H003N3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH003N2;
          prmH003N2 = new Object[] {
          new ParDef("lV86Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV86Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV86Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV86Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Trn_organisationwwds_2_tforganisationname",GXType.VarChar,100,0) ,
          new ParDef("AV88Trn_organisationwwds_3_tforganisationname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV89Trn_organisationwwds_4_tforganisationtypename",GXType.VarChar,100,0) ,
          new ParDef("AV90Trn_organisationwwds_5_tforganisationtypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV91Trn_organisationwwds_6_tforganisationemail",GXType.VarChar,100,0) ,
          new ParDef("AV92Trn_organisationwwds_7_tforganisationemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV93Trn_organisationwwds_8_tforganisationphone",GXType.Char,20,0) ,
          new ParDef("AV94Trn_organisationwwds_9_tforganisationphone_sel",GXType.Char,20,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH003N3;
          prmH003N3 = new Object[] {
          new ParDef("lV86Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV86Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV86Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV86Trn_organisationwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV87Trn_organisationwwds_2_tforganisationname",GXType.VarChar,100,0) ,
          new ParDef("AV88Trn_organisationwwds_3_tforganisationname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV89Trn_organisationwwds_4_tforganisationtypename",GXType.VarChar,100,0) ,
          new ParDef("AV90Trn_organisationwwds_5_tforganisationtypename_sel",GXType.VarChar,100,0) ,
          new ParDef("lV91Trn_organisationwwds_6_tforganisationemail",GXType.VarChar,100,0) ,
          new ParDef("AV92Trn_organisationwwds_7_tforganisationemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV93Trn_organisationwwds_8_tforganisationphone",GXType.Char,20,0) ,
          new ParDef("AV94Trn_organisationwwds_9_tforganisationphone_sel",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003N2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003N3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003N3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaUri(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 20);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((Guid[]) buf[15])[0] = rslt.getGuid(16);
                ((string[]) buf[16])[0] = rslt.getMultimediaFile(17, rslt.getVarchar(9));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
