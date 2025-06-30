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
   public class trn_managerww : GXDataArea
   {
      public trn_managerww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_managerww( IGxContext context )
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
         cmbManagerGender = new GXCombobox();
         chkManagerIsMainManager = new GXCheckbox();
         chkManagerIsActive = new GXCheckbox();
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
         AV61OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
         AV19ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV87ColumnsSelector);
         AV104Pgmname = GetPar( "Pgmname");
         AV15FilterFullText = GetPar( "FilterFullText");
         AV20TFManagerGivenName = GetPar( "TFManagerGivenName");
         AV21TFManagerGivenName_Sel = GetPar( "TFManagerGivenName_Sel");
         AV22TFManagerLastName = GetPar( "TFManagerLastName");
         AV23TFManagerLastName_Sel = GetPar( "TFManagerLastName_Sel");
         AV26TFManagerEmail = GetPar( "TFManagerEmail");
         AV27TFManagerEmail_Sel = GetPar( "TFManagerEmail_Sel");
         AV28TFManagerPhone = GetPar( "TFManagerPhone");
         AV29TFManagerPhone_Sel = GetPar( "TFManagerPhone_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV31TFManagerGender_Sels);
         AV51isMainManager = StringUtil.StrToBool( GetPar( "isMainManager"));
         AV99IsAuthorized_UserActionBlock = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionBlock"));
         AV100IsAuthorized_UserActionUnblock = StringUtil.StrToBool( GetPar( "IsAuthorized_UserActionUnblock"));
         AV43IsAuthorized_Display = StringUtil.StrToBool( GetPar( "IsAuthorized_Display"));
         AV45IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV47IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV41IsAuthorized_ManagerGivenName = StringUtil.StrToBool( GetPar( "IsAuthorized_ManagerGivenName"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV61OrganisationId, AV19ManageFiltersExecutionStep, AV87ColumnsSelector, AV104Pgmname, AV15FilterFullText, AV20TFManagerGivenName, AV21TFManagerGivenName_Sel, AV22TFManagerLastName, AV23TFManagerLastName_Sel, AV26TFManagerEmail, AV27TFManagerEmail_Sel, AV28TFManagerPhone, AV29TFManagerPhone_Sel, AV31TFManagerGender_Sels, AV51isMainManager, AV99IsAuthorized_UserActionBlock, AV100IsAuthorized_UserActionUnblock, AV43IsAuthorized_Display, AV45IsAuthorized_Update, AV47IsAuthorized_Delete, AV41IsAuthorized_ManagerGivenName) ;
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
            return "trn_managerww_Execute" ;
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
         PA3E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3E2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_managerww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV104Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV104Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISMAINMANAGER", AV51isMainManager);
         GxWebStd.gx_hidden_field( context, "gxhash_vISMAINMANAGER", GetSecureSignedToken( "", AV51isMainManager, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONBLOCK", AV99IsAuthorized_UserActionBlock);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONBLOCK", GetSecureSignedToken( "", AV99IsAuthorized_UserActionBlock, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONUNBLOCK", AV100IsAuthorized_UserActionUnblock);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONUNBLOCK", GetSecureSignedToken( "", AV100IsAuthorized_UserActionUnblock, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV43IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV43IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV45IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV45IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV47IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV47IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MANAGERGIVENNAME", AV41IsAuthorized_ManagerGivenName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MANAGERGIVENNAME", GetSecureSignedToken( "", AV41IsAuthorized_ManagerGivenName, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
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
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV40GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV34DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV34DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV87ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV87ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV104Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV104Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFMANAGERGIVENNAME", AV20TFManagerGivenName);
         GxWebStd.gx_hidden_field( context, "vTFMANAGERGIVENNAME_SEL", AV21TFManagerGivenName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFMANAGERLASTNAME", AV22TFManagerLastName);
         GxWebStd.gx_hidden_field( context, "vTFMANAGERLASTNAME_SEL", AV23TFManagerLastName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFMANAGEREMAIL", AV26TFManagerEmail);
         GxWebStd.gx_hidden_field( context, "vTFMANAGEREMAIL_SEL", AV27TFManagerEmail_Sel);
         GxWebStd.gx_hidden_field( context, "vTFMANAGERPHONE", StringUtil.RTrim( AV28TFManagerPhone));
         GxWebStd.gx_hidden_field( context, "vTFMANAGERPHONE_SEL", StringUtil.RTrim( AV29TFManagerPhone_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFMANAGERGENDER_SELS", AV31TFManagerGender_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFMANAGERGENDER_SELS", AV31TFManagerGender_Sels);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISMAINMANAGER", AV51isMainManager);
         GxWebStd.gx_hidden_field( context, "gxhash_vISMAINMANAGER", GetSecureSignedToken( "", AV51isMainManager, context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONBLOCK", AV99IsAuthorized_UserActionBlock);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONBLOCK", GetSecureSignedToken( "", AV99IsAuthorized_UserActionBlock, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONUNBLOCK", AV100IsAuthorized_UserActionUnblock);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONUNBLOCK", GetSecureSignedToken( "", AV100IsAuthorized_UserActionUnblock, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV43IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV43IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV45IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV45IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV47IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV47IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MANAGERGIVENNAME", AV41IsAuthorized_ManagerGivenName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MANAGERGIVENNAME", GetSecureSignedToken( "", AV41IsAuthorized_ManagerGivenName, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_hidden_field( context, "vTFMANAGERGENDER_SELSJSON", AV30TFManagerGender_SelsJson);
         GxWebStd.gx_boolean_hidden_field( context, "vISSENT", AV64isSent);
         GxWebStd.gx_hidden_field( context, "vERRDESCRIPTION", AV97ErrDescription);
         GxWebStd.gx_hidden_field( context, "vMANAGERID_SELECTED", AV57ManagerId_Selected.ToString());
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID_SELECTED", AV58OrganisationId_Selected.ToString());
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV61OrganisationId.ToString());
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Title", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Confirmtype));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Title", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Confirmtype));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Title", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Confirmtype));
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
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Result", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Result));
         GxWebStd.gx_hidden_field( context, "vHTTPREQUEST_Baseurl", StringUtil.RTrim( AV8HTTPRequest.BaseURL));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Result));
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
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_RESENDINVITE_Result", StringUtil.RTrim( Dvelop_confirmpanel_resendinvite_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractionblock_Result));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Result", StringUtil.RTrim( Dvelop_confirmpanel_useractionunblock_Result));
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
            WE3E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3E2( ) ;
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
         return formatLink("trn_managerww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_ManagerWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Managers", "") ;
      }

      protected void WB3E0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsertmanager_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", context.GetMessage( "Insert", ""), bttBtninsertmanager_Jsonclick, 5, context.GetMessage( "Insert", ""), "", StyleString, ClassString, bttBtninsertmanager_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERTMANAGER\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ManagerWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ManagerWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, context.GetMessage( "WWP_Subscriptions_Tooltip", ""), "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_ManagerWW.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_Trn_ManagerWW.htm");
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV38GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV39GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV40GridAppliedFilters);
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
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV34DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV34DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV87ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            wb_table1_64_3E2( true) ;
         }
         else
         {
            wb_table1_64_3E2( false) ;
         }
         return  ;
      }

      protected void wb_table1_64_3E2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table2_69_3E2( true) ;
         }
         else
         {
            wb_table2_69_3E2( false) ;
         }
         return  ;
      }

      protected void wb_table2_69_3E2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table3_74_3E2( true) ;
         }
         else
         {
            wb_table3_74_3E2( false) ;
         }
         return  ;
      }

      protected void wb_table3_74_3E2e( bool wbgen )
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
               GxWebStd.gx_hidden_field( context, "W0081"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0081"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_39_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0081"+"");
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

      protected void START3E2( )
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
         Form.Meta.addItem("description", context.GetMessage( " Managers", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3E0( ) ;
      }

      protected void WS3E2( )
      {
         START3E2( ) ;
         EVT3E2( ) ;
      }

      protected void EVT3E2( )
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
                              E113E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E123E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E133E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddc_subscriptions.Onloadcomponent */
                              E143E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E153E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E163E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_RESENDINVITE.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_resendinvite.Close */
                              E173E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_USERACTIONBLOCK.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_useractionblock.Close */
                              E183E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_useractionunblock.Close */
                              E193E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERTMANAGER'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsertManager' */
                              E203E2 ();
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
                              A21ManagerId = StringUtil.StrToGuid( cgiGet( edtManagerId_Internalname));
                              A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
                              A22ManagerGivenName = cgiGet( edtManagerGivenName_Internalname);
                              A23ManagerLastName = cgiGet( edtManagerLastName_Internalname);
                              A24ManagerInitials = cgiGet( edtManagerInitials_Internalname);
                              A25ManagerEmail = cgiGet( edtManagerEmail_Internalname);
                              A26ManagerPhone = cgiGet( edtManagerPhone_Internalname);
                              A357ManagerPhoneCode = cgiGet( edtManagerPhoneCode_Internalname);
                              A358ManagerPhoneNumber = cgiGet( edtManagerPhoneNumber_Internalname);
                              cmbManagerGender.Name = cmbManagerGender_Internalname;
                              cmbManagerGender.CurrentValue = cgiGet( cmbManagerGender_Internalname);
                              A27ManagerGender = cgiGet( cmbManagerGender_Internalname);
                              A28ManagerGAMGUID = cgiGet( edtManagerGAMGUID_Internalname);
                              A332ManagerIsMainManager = StringUtil.StrToBool( cgiGet( chkManagerIsMainManager_Internalname));
                              A365ManagerIsActive = StringUtil.StrToBool( cgiGet( chkManagerIsActive_Internalname));
                              AV60ManagerIsActive = cgiGet( edtavManagerisactive_Internalname);
                              AssignAttri("", false, edtavManagerisactive_Internalname, AV60ManagerIsActive);
                              cmbavActiongroup.Name = cmbavActiongroup_Internalname;
                              cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
                              AV82ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV82ActionGroup), 4, 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E213E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E223E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E233E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VACTIONGROUP.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E243E2 ();
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
                        if ( nCmpId == 81 )
                        {
                           OldWwpaux_wc = cgiGet( "W0081");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0081", "", sEvt);
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

      protected void WE3E2( )
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

      protected void PA3E2( )
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
                                       Guid AV61OrganisationId ,
                                       short AV19ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV87ColumnsSelector ,
                                       string AV104Pgmname ,
                                       string AV15FilterFullText ,
                                       string AV20TFManagerGivenName ,
                                       string AV21TFManagerGivenName_Sel ,
                                       string AV22TFManagerLastName ,
                                       string AV23TFManagerLastName_Sel ,
                                       string AV26TFManagerEmail ,
                                       string AV27TFManagerEmail_Sel ,
                                       string AV28TFManagerPhone ,
                                       string AV29TFManagerPhone_Sel ,
                                       GxSimpleCollection<string> AV31TFManagerGender_Sels ,
                                       bool AV51isMainManager ,
                                       bool AV99IsAuthorized_UserActionBlock ,
                                       bool AV100IsAuthorized_UserActionUnblock ,
                                       bool AV43IsAuthorized_Display ,
                                       bool AV45IsAuthorized_Update ,
                                       bool AV47IsAuthorized_Delete ,
                                       bool AV41IsAuthorized_ManagerGivenName )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3E2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_MANAGERID", GetSecureSignedToken( "", A21ManagerId, context));
         GxWebStd.gx_hidden_field( context, "MANAGERID", A21ManagerId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONID", GetSecureSignedToken( "", A11OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "ORGANISATIONID", A11OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_MANAGERGAMGUID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A28ManagerGAMGUID, "")), context));
         GxWebStd.gx_hidden_field( context, "MANAGERGAMGUID", A28ManagerGAMGUID);
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
         RF3E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV104Pgmname = "Trn_ManagerWW";
         edtavManagerisactive_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV105Trn_managerwwds_1_filterfulltext = AV15FilterFullText;
         AV106Trn_managerwwds_2_tfmanagergivenname = AV20TFManagerGivenName;
         AV107Trn_managerwwds_3_tfmanagergivenname_sel = AV21TFManagerGivenName_Sel;
         AV108Trn_managerwwds_4_tfmanagerlastname = AV22TFManagerLastName;
         AV109Trn_managerwwds_5_tfmanagerlastname_sel = AV23TFManagerLastName_Sel;
         AV110Trn_managerwwds_6_tfmanageremail = AV26TFManagerEmail;
         AV111Trn_managerwwds_7_tfmanageremail_sel = AV27TFManagerEmail_Sel;
         AV112Trn_managerwwds_8_tfmanagerphone = AV28TFManagerPhone;
         AV113Trn_managerwwds_9_tfmanagerphone_sel = AV29TFManagerPhone_Sel;
         AV114Trn_managerwwds_10_tfmanagergender_sels = AV31TFManagerGender_Sels;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A27ManagerGender ,
                                              AV114Trn_managerwwds_10_tfmanagergender_sels ,
                                              AV107Trn_managerwwds_3_tfmanagergivenname_sel ,
                                              AV106Trn_managerwwds_2_tfmanagergivenname ,
                                              AV109Trn_managerwwds_5_tfmanagerlastname_sel ,
                                              AV108Trn_managerwwds_4_tfmanagerlastname ,
                                              AV111Trn_managerwwds_7_tfmanageremail_sel ,
                                              AV110Trn_managerwwds_6_tfmanageremail ,
                                              AV113Trn_managerwwds_9_tfmanagerphone_sel ,
                                              AV112Trn_managerwwds_8_tfmanagerphone ,
                                              AV114Trn_managerwwds_10_tfmanagergender_sels.Count ,
                                              A22ManagerGivenName ,
                                              A23ManagerLastName ,
                                              A25ManagerEmail ,
                                              A26ManagerPhone ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              AV105Trn_managerwwds_1_filterfulltext ,
                                              A11OrganisationId ,
                                              AV61OrganisationId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV106Trn_managerwwds_2_tfmanagergivenname = StringUtil.Concat( StringUtil.RTrim( AV106Trn_managerwwds_2_tfmanagergivenname), "%", "");
         lV108Trn_managerwwds_4_tfmanagerlastname = StringUtil.Concat( StringUtil.RTrim( AV108Trn_managerwwds_4_tfmanagerlastname), "%", "");
         lV110Trn_managerwwds_6_tfmanageremail = StringUtil.Concat( StringUtil.RTrim( AV110Trn_managerwwds_6_tfmanageremail), "%", "");
         lV112Trn_managerwwds_8_tfmanagerphone = StringUtil.PadR( StringUtil.RTrim( AV112Trn_managerwwds_8_tfmanagerphone), 20, "%");
         /* Using cursor H003E2 */
         pr_default.execute(0, new Object[] {AV61OrganisationId, lV106Trn_managerwwds_2_tfmanagergivenname, AV107Trn_managerwwds_3_tfmanagergivenname_sel, lV108Trn_managerwwds_4_tfmanagerlastname, AV109Trn_managerwwds_5_tfmanagerlastname_sel, lV110Trn_managerwwds_6_tfmanageremail, AV111Trn_managerwwds_7_tfmanageremail_sel, lV112Trn_managerwwds_8_tfmanagerphone, AV113Trn_managerwwds_9_tfmanagerphone_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A365ManagerIsActive = H003E2_A365ManagerIsActive[0];
            A332ManagerIsMainManager = H003E2_A332ManagerIsMainManager[0];
            A28ManagerGAMGUID = H003E2_A28ManagerGAMGUID[0];
            A27ManagerGender = H003E2_A27ManagerGender[0];
            A358ManagerPhoneNumber = H003E2_A358ManagerPhoneNumber[0];
            A357ManagerPhoneCode = H003E2_A357ManagerPhoneCode[0];
            A26ManagerPhone = H003E2_A26ManagerPhone[0];
            A25ManagerEmail = H003E2_A25ManagerEmail[0];
            A24ManagerInitials = H003E2_A24ManagerInitials[0];
            A23ManagerLastName = H003E2_A23ManagerLastName[0];
            A22ManagerGivenName = H003E2_A22ManagerGivenName[0];
            A11OrganisationId = H003E2_A11OrganisationId[0];
            A21ManagerId = H003E2_A21ManagerId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Trn_managerwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A22ManagerGivenName) , StringUtil.PadR( "%" + StringUtil.Lower( AV105Trn_managerwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A23ManagerLastName) , StringUtil.PadR( "%" + StringUtil.Lower( AV105Trn_managerwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A25ManagerEmail) , StringUtil.PadR( "%" + StringUtil.Lower( AV105Trn_managerwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A26ManagerPhone) , StringUtil.PadR( "%" + StringUtil.Lower( AV105Trn_managerwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "male", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV105Trn_managerwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A27ManagerGender, "Male") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "female", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV105Trn_managerwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A27ManagerGender, "Female") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "other", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV105Trn_managerwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A27ManagerGender, "Other") == 0 ) ) ) )
            {
               GRID_nRecordCount = (long)(GRID_nRecordCount+1);
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF3E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 39;
         /* Execute user event: Refresh */
         E223E2 ();
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
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A27ManagerGender ,
                                                 AV114Trn_managerwwds_10_tfmanagergender_sels ,
                                                 AV107Trn_managerwwds_3_tfmanagergivenname_sel ,
                                                 AV106Trn_managerwwds_2_tfmanagergivenname ,
                                                 AV109Trn_managerwwds_5_tfmanagerlastname_sel ,
                                                 AV108Trn_managerwwds_4_tfmanagerlastname ,
                                                 AV111Trn_managerwwds_7_tfmanageremail_sel ,
                                                 AV110Trn_managerwwds_6_tfmanageremail ,
                                                 AV113Trn_managerwwds_9_tfmanagerphone_sel ,
                                                 AV112Trn_managerwwds_8_tfmanagerphone ,
                                                 AV114Trn_managerwwds_10_tfmanagergender_sels.Count ,
                                                 A22ManagerGivenName ,
                                                 A23ManagerLastName ,
                                                 A25ManagerEmail ,
                                                 A26ManagerPhone ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 AV105Trn_managerwwds_1_filterfulltext ,
                                                 A11OrganisationId ,
                                                 AV61OrganisationId } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV106Trn_managerwwds_2_tfmanagergivenname = StringUtil.Concat( StringUtil.RTrim( AV106Trn_managerwwds_2_tfmanagergivenname), "%", "");
            lV108Trn_managerwwds_4_tfmanagerlastname = StringUtil.Concat( StringUtil.RTrim( AV108Trn_managerwwds_4_tfmanagerlastname), "%", "");
            lV110Trn_managerwwds_6_tfmanageremail = StringUtil.Concat( StringUtil.RTrim( AV110Trn_managerwwds_6_tfmanageremail), "%", "");
            lV112Trn_managerwwds_8_tfmanagerphone = StringUtil.PadR( StringUtil.RTrim( AV112Trn_managerwwds_8_tfmanagerphone), 20, "%");
            /* Using cursor H003E3 */
            pr_default.execute(1, new Object[] {AV61OrganisationId, lV106Trn_managerwwds_2_tfmanagergivenname, AV107Trn_managerwwds_3_tfmanagergivenname_sel, lV108Trn_managerwwds_4_tfmanagerlastname, AV109Trn_managerwwds_5_tfmanagerlastname_sel, lV110Trn_managerwwds_6_tfmanageremail, AV111Trn_managerwwds_7_tfmanageremail_sel, lV112Trn_managerwwds_8_tfmanagerphone, AV113Trn_managerwwds_9_tfmanagerphone_sel});
            nGXsfl_39_idx = 1;
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A365ManagerIsActive = H003E3_A365ManagerIsActive[0];
               A332ManagerIsMainManager = H003E3_A332ManagerIsMainManager[0];
               A28ManagerGAMGUID = H003E3_A28ManagerGAMGUID[0];
               A27ManagerGender = H003E3_A27ManagerGender[0];
               A358ManagerPhoneNumber = H003E3_A358ManagerPhoneNumber[0];
               A357ManagerPhoneCode = H003E3_A357ManagerPhoneCode[0];
               A26ManagerPhone = H003E3_A26ManagerPhone[0];
               A25ManagerEmail = H003E3_A25ManagerEmail[0];
               A24ManagerInitials = H003E3_A24ManagerInitials[0];
               A23ManagerLastName = H003E3_A23ManagerLastName[0];
               A22ManagerGivenName = H003E3_A22ManagerGivenName[0];
               A11OrganisationId = H003E3_A11OrganisationId[0];
               A21ManagerId = H003E3_A21ManagerId[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Trn_managerwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A22ManagerGivenName) , StringUtil.PadR( "%" + StringUtil.Lower( AV105Trn_managerwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A23ManagerLastName) , StringUtil.PadR( "%" + StringUtil.Lower( AV105Trn_managerwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A25ManagerEmail) , StringUtil.PadR( "%" + StringUtil.Lower( AV105Trn_managerwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Lower( A26ManagerPhone) , StringUtil.PadR( "%" + StringUtil.Lower( AV105Trn_managerwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "male", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV105Trn_managerwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A27ManagerGender, "Male") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "female", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV105Trn_managerwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A27ManagerGender, "Female") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "other", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV105Trn_managerwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A27ManagerGender, "Other") == 0 ) ) ) )
               {
                  /* Execute user event: Grid.Load */
                  E233E2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 39;
            WB3E0( ) ;
         }
         bGXsfl_39_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3E2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV104Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV104Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISMAINMANAGER", AV51isMainManager);
         GxWebStd.gx_hidden_field( context, "gxhash_vISMAINMANAGER", GetSecureSignedToken( "", AV51isMainManager, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONBLOCK", AV99IsAuthorized_UserActionBlock);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONBLOCK", GetSecureSignedToken( "", AV99IsAuthorized_UserActionBlock, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USERACTIONUNBLOCK", AV100IsAuthorized_UserActionUnblock);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONUNBLOCK", GetSecureSignedToken( "", AV100IsAuthorized_UserActionUnblock, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV43IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV43IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV45IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV45IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV47IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV47IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MANAGERGIVENNAME", AV41IsAuthorized_ManagerGivenName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MANAGERGIVENNAME", GetSecureSignedToken( "", AV41IsAuthorized_ManagerGivenName, context));
         GxWebStd.gx_hidden_field( context, "gxhash_MANAGERID"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, A21ManagerId, context));
         GxWebStd.gx_hidden_field( context, "gxhash_ORGANISATIONID"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, A11OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "gxhash_MANAGERGAMGUID"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, StringUtil.RTrim( context.localUtil.Format( A28ManagerGAMGUID, "")), context));
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
         return (int)(subGridclient_rec_count_fnc()) ;
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
         AV105Trn_managerwwds_1_filterfulltext = AV15FilterFullText;
         AV106Trn_managerwwds_2_tfmanagergivenname = AV20TFManagerGivenName;
         AV107Trn_managerwwds_3_tfmanagergivenname_sel = AV21TFManagerGivenName_Sel;
         AV108Trn_managerwwds_4_tfmanagerlastname = AV22TFManagerLastName;
         AV109Trn_managerwwds_5_tfmanagerlastname_sel = AV23TFManagerLastName_Sel;
         AV110Trn_managerwwds_6_tfmanageremail = AV26TFManagerEmail;
         AV111Trn_managerwwds_7_tfmanageremail_sel = AV27TFManagerEmail_Sel;
         AV112Trn_managerwwds_8_tfmanagerphone = AV28TFManagerPhone;
         AV113Trn_managerwwds_9_tfmanagerphone_sel = AV29TFManagerPhone_Sel;
         AV114Trn_managerwwds_10_tfmanagergender_sels = AV31TFManagerGender_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV61OrganisationId, AV19ManageFiltersExecutionStep, AV87ColumnsSelector, AV104Pgmname, AV15FilterFullText, AV20TFManagerGivenName, AV21TFManagerGivenName_Sel, AV22TFManagerLastName, AV23TFManagerLastName_Sel, AV26TFManagerEmail, AV27TFManagerEmail_Sel, AV28TFManagerPhone, AV29TFManagerPhone_Sel, AV31TFManagerGender_Sels, AV51isMainManager, AV99IsAuthorized_UserActionBlock, AV100IsAuthorized_UserActionUnblock, AV43IsAuthorized_Display, AV45IsAuthorized_Update, AV47IsAuthorized_Delete, AV41IsAuthorized_ManagerGivenName) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV105Trn_managerwwds_1_filterfulltext = AV15FilterFullText;
         AV106Trn_managerwwds_2_tfmanagergivenname = AV20TFManagerGivenName;
         AV107Trn_managerwwds_3_tfmanagergivenname_sel = AV21TFManagerGivenName_Sel;
         AV108Trn_managerwwds_4_tfmanagerlastname = AV22TFManagerLastName;
         AV109Trn_managerwwds_5_tfmanagerlastname_sel = AV23TFManagerLastName_Sel;
         AV110Trn_managerwwds_6_tfmanageremail = AV26TFManagerEmail;
         AV111Trn_managerwwds_7_tfmanageremail_sel = AV27TFManagerEmail_Sel;
         AV112Trn_managerwwds_8_tfmanagerphone = AV28TFManagerPhone;
         AV113Trn_managerwwds_9_tfmanagerphone_sel = AV29TFManagerPhone_Sel;
         AV114Trn_managerwwds_10_tfmanagergender_sels = AV31TFManagerGender_Sels;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV61OrganisationId, AV19ManageFiltersExecutionStep, AV87ColumnsSelector, AV104Pgmname, AV15FilterFullText, AV20TFManagerGivenName, AV21TFManagerGivenName_Sel, AV22TFManagerLastName, AV23TFManagerLastName_Sel, AV26TFManagerEmail, AV27TFManagerEmail_Sel, AV28TFManagerPhone, AV29TFManagerPhone_Sel, AV31TFManagerGender_Sels, AV51isMainManager, AV99IsAuthorized_UserActionBlock, AV100IsAuthorized_UserActionUnblock, AV43IsAuthorized_Display, AV45IsAuthorized_Update, AV47IsAuthorized_Delete, AV41IsAuthorized_ManagerGivenName) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV105Trn_managerwwds_1_filterfulltext = AV15FilterFullText;
         AV106Trn_managerwwds_2_tfmanagergivenname = AV20TFManagerGivenName;
         AV107Trn_managerwwds_3_tfmanagergivenname_sel = AV21TFManagerGivenName_Sel;
         AV108Trn_managerwwds_4_tfmanagerlastname = AV22TFManagerLastName;
         AV109Trn_managerwwds_5_tfmanagerlastname_sel = AV23TFManagerLastName_Sel;
         AV110Trn_managerwwds_6_tfmanageremail = AV26TFManagerEmail;
         AV111Trn_managerwwds_7_tfmanageremail_sel = AV27TFManagerEmail_Sel;
         AV112Trn_managerwwds_8_tfmanagerphone = AV28TFManagerPhone;
         AV113Trn_managerwwds_9_tfmanagerphone_sel = AV29TFManagerPhone_Sel;
         AV114Trn_managerwwds_10_tfmanagergender_sels = AV31TFManagerGender_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV61OrganisationId, AV19ManageFiltersExecutionStep, AV87ColumnsSelector, AV104Pgmname, AV15FilterFullText, AV20TFManagerGivenName, AV21TFManagerGivenName_Sel, AV22TFManagerLastName, AV23TFManagerLastName_Sel, AV26TFManagerEmail, AV27TFManagerEmail_Sel, AV28TFManagerPhone, AV29TFManagerPhone_Sel, AV31TFManagerGender_Sels, AV51isMainManager, AV99IsAuthorized_UserActionBlock, AV100IsAuthorized_UserActionUnblock, AV43IsAuthorized_Display, AV45IsAuthorized_Update, AV47IsAuthorized_Delete, AV41IsAuthorized_ManagerGivenName) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV105Trn_managerwwds_1_filterfulltext = AV15FilterFullText;
         AV106Trn_managerwwds_2_tfmanagergivenname = AV20TFManagerGivenName;
         AV107Trn_managerwwds_3_tfmanagergivenname_sel = AV21TFManagerGivenName_Sel;
         AV108Trn_managerwwds_4_tfmanagerlastname = AV22TFManagerLastName;
         AV109Trn_managerwwds_5_tfmanagerlastname_sel = AV23TFManagerLastName_Sel;
         AV110Trn_managerwwds_6_tfmanageremail = AV26TFManagerEmail;
         AV111Trn_managerwwds_7_tfmanageremail_sel = AV27TFManagerEmail_Sel;
         AV112Trn_managerwwds_8_tfmanagerphone = AV28TFManagerPhone;
         AV113Trn_managerwwds_9_tfmanagerphone_sel = AV29TFManagerPhone_Sel;
         AV114Trn_managerwwds_10_tfmanagergender_sels = AV31TFManagerGender_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV61OrganisationId, AV19ManageFiltersExecutionStep, AV87ColumnsSelector, AV104Pgmname, AV15FilterFullText, AV20TFManagerGivenName, AV21TFManagerGivenName_Sel, AV22TFManagerLastName, AV23TFManagerLastName_Sel, AV26TFManagerEmail, AV27TFManagerEmail_Sel, AV28TFManagerPhone, AV29TFManagerPhone_Sel, AV31TFManagerGender_Sels, AV51isMainManager, AV99IsAuthorized_UserActionBlock, AV100IsAuthorized_UserActionUnblock, AV43IsAuthorized_Display, AV45IsAuthorized_Update, AV47IsAuthorized_Delete, AV41IsAuthorized_ManagerGivenName) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV105Trn_managerwwds_1_filterfulltext = AV15FilterFullText;
         AV106Trn_managerwwds_2_tfmanagergivenname = AV20TFManagerGivenName;
         AV107Trn_managerwwds_3_tfmanagergivenname_sel = AV21TFManagerGivenName_Sel;
         AV108Trn_managerwwds_4_tfmanagerlastname = AV22TFManagerLastName;
         AV109Trn_managerwwds_5_tfmanagerlastname_sel = AV23TFManagerLastName_Sel;
         AV110Trn_managerwwds_6_tfmanageremail = AV26TFManagerEmail;
         AV111Trn_managerwwds_7_tfmanageremail_sel = AV27TFManagerEmail_Sel;
         AV112Trn_managerwwds_8_tfmanagerphone = AV28TFManagerPhone;
         AV113Trn_managerwwds_9_tfmanagerphone_sel = AV29TFManagerPhone_Sel;
         AV114Trn_managerwwds_10_tfmanagergender_sels = AV31TFManagerGender_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV61OrganisationId, AV19ManageFiltersExecutionStep, AV87ColumnsSelector, AV104Pgmname, AV15FilterFullText, AV20TFManagerGivenName, AV21TFManagerGivenName_Sel, AV22TFManagerLastName, AV23TFManagerLastName_Sel, AV26TFManagerEmail, AV27TFManagerEmail_Sel, AV28TFManagerPhone, AV29TFManagerPhone_Sel, AV31TFManagerGender_Sels, AV51isMainManager, AV99IsAuthorized_UserActionBlock, AV100IsAuthorized_UserActionUnblock, AV43IsAuthorized_Display, AV45IsAuthorized_Update, AV47IsAuthorized_Delete, AV41IsAuthorized_ManagerGivenName) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV104Pgmname = "Trn_ManagerWW";
         edtavManagerisactive_Enabled = 0;
         edtManagerId_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtManagerGivenName_Enabled = 0;
         edtManagerLastName_Enabled = 0;
         edtManagerInitials_Enabled = 0;
         edtManagerEmail_Enabled = 0;
         edtManagerPhone_Enabled = 0;
         edtManagerPhoneCode_Enabled = 0;
         edtManagerPhoneNumber_Enabled = 0;
         cmbManagerGender.Enabled = 0;
         edtManagerGAMGUID_Enabled = 0;
         chkManagerIsMainManager.Enabled = 0;
         chkManagerIsActive.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E213E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV17ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV34DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV87ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_39 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_39"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV38GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV39GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV40GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Dvelop_confirmpanel_resendinvite_Title = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Title");
            Dvelop_confirmpanel_resendinvite_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Confirmationtext");
            Dvelop_confirmpanel_resendinvite_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Yesbuttoncaption");
            Dvelop_confirmpanel_resendinvite_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Nobuttoncaption");
            Dvelop_confirmpanel_resendinvite_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Cancelbuttoncaption");
            Dvelop_confirmpanel_resendinvite_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Yesbuttonposition");
            Dvelop_confirmpanel_resendinvite_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Confirmtype");
            Dvelop_confirmpanel_useractionblock_Title = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Title");
            Dvelop_confirmpanel_useractionblock_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Confirmationtext");
            Dvelop_confirmpanel_useractionblock_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Yesbuttoncaption");
            Dvelop_confirmpanel_useractionblock_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Nobuttoncaption");
            Dvelop_confirmpanel_useractionblock_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Cancelbuttoncaption");
            Dvelop_confirmpanel_useractionblock_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Yesbuttonposition");
            Dvelop_confirmpanel_useractionblock_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Confirmtype");
            Dvelop_confirmpanel_useractionunblock_Title = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Title");
            Dvelop_confirmpanel_useractionunblock_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Confirmationtext");
            Dvelop_confirmpanel_useractionunblock_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Yesbuttoncaption");
            Dvelop_confirmpanel_useractionunblock_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Nobuttoncaption");
            Dvelop_confirmpanel_useractionunblock_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Cancelbuttoncaption");
            Dvelop_confirmpanel_useractionunblock_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Yesbuttonposition");
            Dvelop_confirmpanel_useractionunblock_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Confirmtype");
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
            Dvelop_confirmpanel_resendinvite_Result = cgiGet( "DVELOP_CONFIRMPANEL_RESENDINVITE_Result");
            Dvelop_confirmpanel_useractionblock_Result = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONBLOCK_Result");
            Dvelop_confirmpanel_useractionunblock_Result = cgiGet( "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK_Result");
            /* Read variables values. */
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            /* Read subfile selected row values. */
            nGXsfl_39_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            if ( nGXsfl_39_idx > 0 )
            {
               A21ManagerId = StringUtil.StrToGuid( cgiGet( edtManagerId_Internalname));
               A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
               A22ManagerGivenName = cgiGet( edtManagerGivenName_Internalname);
               A23ManagerLastName = cgiGet( edtManagerLastName_Internalname);
               A24ManagerInitials = cgiGet( edtManagerInitials_Internalname);
               A25ManagerEmail = cgiGet( edtManagerEmail_Internalname);
               A26ManagerPhone = cgiGet( edtManagerPhone_Internalname);
               A357ManagerPhoneCode = cgiGet( edtManagerPhoneCode_Internalname);
               A358ManagerPhoneNumber = cgiGet( edtManagerPhoneNumber_Internalname);
               cmbManagerGender.Name = cmbManagerGender_Internalname;
               cmbManagerGender.CurrentValue = cgiGet( cmbManagerGender_Internalname);
               A27ManagerGender = cgiGet( cmbManagerGender_Internalname);
               A28ManagerGAMGUID = cgiGet( edtManagerGAMGUID_Internalname);
               A332ManagerIsMainManager = StringUtil.StrToBool( cgiGet( chkManagerIsMainManager_Internalname));
               A365ManagerIsActive = StringUtil.StrToBool( cgiGet( chkManagerIsActive_Internalname));
               AV60ManagerIsActive = cgiGet( edtavManagerisactive_Internalname);
               AssignAttri("", false, edtavManagerisactive_Internalname, AV60ManagerIsActive);
               cmbavActiongroup.Name = cmbavActiongroup_Internalname;
               cmbavActiongroup.CurrentValue = cgiGet( cmbavActiongroup_Internalname);
               AV82ActionGroup = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActiongroup_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV82ActionGroup), 4, 0));
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
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E213E2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E213E2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV94successmsg = AV95websession.Get(context.GetMessage( "NotificationMessage", ""));
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94successmsg)) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Success",  AV94successmsg,  "success",  "",  "true",  ""));
            AV95websession.Remove(context.GetMessage( "NotificationMessage", ""));
         }
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         GXt_guid1 = AV61OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid1) ;
         AV61OrganisationId = (AV6WWPContext.gxTpr_Isrootadmin ? AV6WWPContext.gxTpr_Organisationid : GXt_guid1);
         AssignAttri("", false, "AV61OrganisationId", AV61OrganisationId.ToString());
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
         GXt_boolean2 = AV41IsAuthorized_ManagerGivenName;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_managerview_Execute", out  GXt_boolean2) ;
         AV41IsAuthorized_ManagerGivenName = GXt_boolean2;
         AssignAttri("", false, "AV41IsAuthorized_ManagerGivenName", AV41IsAuthorized_ManagerGivenName);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MANAGERGIVENNAME", GetSecureSignedToken( "", AV41IsAuthorized_ManagerGivenName, context));
         AV35GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV36GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV35GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = context.GetMessage( " Managers", "");
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 = AV34DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3) ;
         AV34DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         GXt_boolean2 = AV51isMainManager;
         new prc_checkismainmanager(context ).execute( out  GXt_boolean2) ;
         AV51isMainManager = GXt_boolean2;
         AssignAttri("", false, "AV51isMainManager", AV51isMainManager);
         GxWebStd.gx_hidden_field( context, "gxhash_vISMAINMANAGER", GetSecureSignedToken( "", AV51isMainManager, context));
      }

      protected void E223E2( )
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
         if ( StringUtil.StrCmp(AV16Session.Get("Trn_ManagerWWColumnsSelector"), "") != 0 )
         {
            AV85ColumnsSelectorXML = AV16Session.Get("Trn_ManagerWWColumnsSelector");
            AV87ColumnsSelector.FromXml(AV85ColumnsSelectorXML, null, "", "");
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
         edtManagerGivenName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV87ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtManagerGivenName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtManagerGivenName_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtManagerLastName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV87ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtManagerLastName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtManagerLastName_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtManagerEmail_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV87ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtManagerEmail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtManagerEmail_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtManagerPhone_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV87ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtManagerPhone_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtManagerPhone_Visible), 5, 0), !bGXsfl_39_Refreshing);
         cmbManagerGender.Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV87ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbManagerGender_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbManagerGender.Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtavManagerisactive_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV87ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavManagerisactive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavManagerisactive_Visible), 5, 0), !bGXsfl_39_Refreshing);
         AV38GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV38GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV38GridCurrentPage), 10, 0));
         AV39GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV39GridPageCount", StringUtil.LTrimStr( (decimal)(AV39GridPageCount), 10, 0));
         GXt_char4 = AV40GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV104Pgmname, out  GXt_char4) ;
         AV40GridAppliedFilters = GXt_char4;
         AssignAttri("", false, "AV40GridAppliedFilters", AV40GridAppliedFilters);
         edtavManagerisactive_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtavManagerisactive_Internalname, "Columnheaderclass", edtavManagerisactive_Columnheaderclass, !bGXsfl_39_Refreshing);
         AV105Trn_managerwwds_1_filterfulltext = AV15FilterFullText;
         AV106Trn_managerwwds_2_tfmanagergivenname = AV20TFManagerGivenName;
         AV107Trn_managerwwds_3_tfmanagergivenname_sel = AV21TFManagerGivenName_Sel;
         AV108Trn_managerwwds_4_tfmanagerlastname = AV22TFManagerLastName;
         AV109Trn_managerwwds_5_tfmanagerlastname_sel = AV23TFManagerLastName_Sel;
         AV110Trn_managerwwds_6_tfmanageremail = AV26TFManagerEmail;
         AV111Trn_managerwwds_7_tfmanageremail_sel = AV27TFManagerEmail_Sel;
         AV112Trn_managerwwds_8_tfmanagerphone = AV28TFManagerPhone;
         AV113Trn_managerwwds_9_tfmanagerphone_sel = AV29TFManagerPhone_Sel;
         AV114Trn_managerwwds_10_tfmanagergender_sels = AV31TFManagerGender_Sels;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV87ColumnsSelector", AV87ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E123E2( )
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
            AV37PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV37PageToGo) ;
         }
      }

      protected void E133E2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E153E2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ManagerGivenName") == 0 )
            {
               AV20TFManagerGivenName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV20TFManagerGivenName", AV20TFManagerGivenName);
               AV21TFManagerGivenName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV21TFManagerGivenName_Sel", AV21TFManagerGivenName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ManagerLastName") == 0 )
            {
               AV22TFManagerLastName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV22TFManagerLastName", AV22TFManagerLastName);
               AV23TFManagerLastName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV23TFManagerLastName_Sel", AV23TFManagerLastName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ManagerEmail") == 0 )
            {
               AV26TFManagerEmail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV26TFManagerEmail", AV26TFManagerEmail);
               AV27TFManagerEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV27TFManagerEmail_Sel", AV27TFManagerEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ManagerPhone") == 0 )
            {
               AV28TFManagerPhone = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV28TFManagerPhone", AV28TFManagerPhone);
               AV29TFManagerPhone_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV29TFManagerPhone_Sel", AV29TFManagerPhone_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ManagerGender") == 0 )
            {
               AV30TFManagerGender_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV30TFManagerGender_SelsJson", AV30TFManagerGender_SelsJson);
               AV31TFManagerGender_Sels.FromJSonString(AV30TFManagerGender_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV31TFManagerGender_Sels", AV31TFManagerGender_Sels);
      }

      private void E233E2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            GXt_boolean2 = AV89IsGAMActive;
            new prc_checkgamuseractivationstatus(context ).execute(  A28ManagerGAMGUID, out  GXt_boolean2) ;
            AV89IsGAMActive = GXt_boolean2;
            GXt_boolean2 = AV90IsGAMBlocked;
            new prc_checkgamuserblockedstatus(context ).execute(  A28ManagerGAMGUID, out  GXt_boolean2) ;
            AV90IsGAMBlocked = GXt_boolean2;
            cmbavActiongroup.removeAllItems();
            cmbavActiongroup.addItem("0", ";fas fa-bars", 0);
            if ( ! AV89IsGAMActive && ( AV51isMainManager ) )
            {
               cmbavActiongroup.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "Invite", ""), "fas fa-share", "", "", "", "", "", "", ""), 0);
            }
            if ( AV99IsAuthorized_UserActionBlock )
            {
               if ( ( AV89IsGAMActive ) && ! AV90IsGAMBlocked && ( AV51isMainManager ) )
               {
                  cmbavActiongroup.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "Block", ""), "fas fa-lock", "", "", "", "", "", "", ""), 0);
               }
            }
            if ( AV100IsAuthorized_UserActionUnblock )
            {
               if ( ( AV89IsGAMActive ) && ( AV90IsGAMBlocked ) && ( AV51isMainManager ) )
               {
                  cmbavActiongroup.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "Unblock", ""), "fas fa-lock-open", "", "", "", "", "", "", ""), 0);
               }
            }
            if ( AV43IsAuthorized_Display )
            {
               cmbavActiongroup.addItem("4", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            }
            if ( AV45IsAuthorized_Update )
            {
               if ( AV51isMainManager )
               {
                  cmbavActiongroup.addItem("5", StringUtil.Format( "%1;%2", context.GetMessage( "Edit", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
               }
            }
            if ( AV47IsAuthorized_Delete )
            {
               if ( ( AV51isMainManager ) && ( StringUtil.StrCmp(A28ManagerGAMGUID, new prc_getloggedinuserid(context).executeUdp( )) != 0 ) )
               {
                  cmbavActiongroup.addItem("6", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
               }
            }
            if ( cmbavActiongroup.ItemCount == 1 )
            {
               cmbavActiongroup_Class = "Invisible";
            }
            else
            {
               cmbavActiongroup_Class = "ConvertToDDO";
            }
            if ( AV41IsAuthorized_ManagerGivenName )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "trn_managerview.aspx"+UrlEncode(A21ManagerId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
               edtManagerGivenName_Link = formatLink("trn_managerview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            if ( ( AV89IsGAMActive ) && ! AV90IsGAMBlocked )
            {
               edtavManagerisactive_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
            }
            else if ( ( AV89IsGAMActive ) && ( AV90IsGAMBlocked ) )
            {
               edtavManagerisactive_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
            }
            else if ( ! AV89IsGAMActive )
            {
               edtavManagerisactive_Columnclass = "WWColumn WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
            }
            else
            {
               edtavManagerisactive_Columnclass = "WWColumn";
            }
            if ( ( AV89IsGAMActive ) && ! AV90IsGAMBlocked )
            {
               AV60ManagerIsActive = "Active";
               AssignAttri("", false, edtavManagerisactive_Internalname, AV60ManagerIsActive);
            }
            else if ( ( AV89IsGAMActive ) && ( AV90IsGAMBlocked ) )
            {
               AV60ManagerIsActive = "Blocked";
               AssignAttri("", false, edtavManagerisactive_Internalname, AV60ManagerIsActive);
            }
            else if ( ! AV89IsGAMActive )
            {
               AV60ManagerIsActive = "Inactive";
               AssignAttri("", false, edtavManagerisactive_Internalname, AV60ManagerIsActive);
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 39;
            }
            sendrow_392( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_39_Refreshing )
         {
            DoAjaxLoad(39, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV82ActionGroup), 4, 0));
      }

      protected void E163E2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV85ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV87ColumnsSelector.FromJSonString(AV85ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "Trn_ManagerWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV85ColumnsSelectorXML)) ? "" : AV87ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV87ColumnsSelector", AV87ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E113E2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("Trn_ManagerWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV104Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("Trn_ManagerWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char4 = AV18ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "Trn_ManagerWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char4) ;
            AV18ManageFiltersXml = GXt_char4;
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
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV104Pgmname+"GridState",  AV18ManageFiltersXml) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV31TFManagerGender_Sels", AV31TFManagerGender_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV87ColumnsSelector", AV87ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
      }

      protected void E243E2( )
      {
         /* Actiongroup_Click Routine */
         returnInSub = false;
         if ( AV82ActionGroup == 1 )
         {
            /* Execute user subroutine: 'DO RESENDINVITE' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV82ActionGroup == 2 )
         {
            /* Execute user subroutine: 'DO USERACTIONBLOCK' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV82ActionGroup == 3 )
         {
            /* Execute user subroutine: 'DO USERACTIONUNBLOCK' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV82ActionGroup == 4 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV82ActionGroup == 5 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV82ActionGroup == 6 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV82ActionGroup = 0;
         AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV82ActionGroup), 4, 0));
         /*  Sending Event outputs  */
         cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV82ActionGroup), 4, 0));
         AssignProp("", false, cmbavActiongroup_Internalname, "Values", cmbavActiongroup.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV87ColumnsSelector", AV87ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E173E2( )
      {
         /* Dvelop_confirmpanel_resendinvite_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_resendinvite_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION RESENDINVITE' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E183E2( )
      {
         /* Dvelop_confirmpanel_useractionblock_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_useractionblock_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION USERACTIONBLOCK' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV87ColumnsSelector", AV87ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E193E2( )
      {
         /* Dvelop_confirmpanel_useractionunblock_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_useractionunblock_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION USERACTIONUNBLOCK' */
            S282 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV87ColumnsSelector", AV87ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E203E2( )
      {
         /* 'DoInsertManager' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "trn_manager.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(Guid.Empty.ToString()) + "," + UrlEncode(new prc_getuserorganisationid(context).executeUdp( ).ToString());
         CallWebObject(formatLink("trn_manager.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E143E2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0081",(string)"",(string)"Trn_Manager",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0081"+"");
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
         AV87ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV87ColumnsSelector,  "ManagerGivenName",  "",  "First Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV87ColumnsSelector,  "ManagerLastName",  "",  "Last Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV87ColumnsSelector,  "ManagerEmail",  "",  "Email",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV87ColumnsSelector,  "ManagerPhone",  "",  "Phone",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV87ColumnsSelector,  "ManagerGender",  "",  "Gender",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV87ColumnsSelector,  "&ManagerIsActive",  "",  "Account Status",  true,  "") ;
         GXt_char4 = AV86UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "Trn_ManagerWWColumnsSelector", out  GXt_char4) ;
         AV86UserCustomValue = GXt_char4;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV86UserCustomValue)) ) )
         {
            AV88ColumnsSelectorAux.FromXml(AV86UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV88ColumnsSelectorAux, ref  AV87ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean2 = AV99IsAuthorized_UserActionBlock;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_receptionist_Insert", out  GXt_boolean2) ;
         AV99IsAuthorized_UserActionBlock = GXt_boolean2;
         AssignAttri("", false, "AV99IsAuthorized_UserActionBlock", AV99IsAuthorized_UserActionBlock);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONBLOCK", GetSecureSignedToken( "", AV99IsAuthorized_UserActionBlock, context));
         GXt_boolean2 = AV100IsAuthorized_UserActionUnblock;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_receptionist_Insert", out  GXt_boolean2) ;
         AV100IsAuthorized_UserActionUnblock = GXt_boolean2;
         AssignAttri("", false, "AV100IsAuthorized_UserActionUnblock", AV100IsAuthorized_UserActionUnblock);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USERACTIONUNBLOCK", GetSecureSignedToken( "", AV100IsAuthorized_UserActionUnblock, context));
         GXt_boolean2 = AV43IsAuthorized_Display;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_managerview_Execute", out  GXt_boolean2) ;
         AV43IsAuthorized_Display = GXt_boolean2;
         AssignAttri("", false, "AV43IsAuthorized_Display", AV43IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV43IsAuthorized_Display, context));
         GXt_boolean2 = AV45IsAuthorized_Update;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_manager_Update", out  GXt_boolean2) ;
         AV45IsAuthorized_Update = GXt_boolean2;
         AssignAttri("", false, "AV45IsAuthorized_Update", AV45IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV45IsAuthorized_Update, context));
         GXt_boolean2 = AV47IsAuthorized_Delete;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_manager_Delete", out  GXt_boolean2) ;
         AV47IsAuthorized_Delete = GXt_boolean2;
         AssignAttri("", false, "AV47IsAuthorized_Delete", AV47IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV47IsAuthorized_Delete, context));
         GXt_boolean2 = AV83IsAuthorized_InsertManager;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_manager_Insert", out  GXt_boolean2) ;
         AV83IsAuthorized_InsertManager = GXt_boolean2;
         if ( ! ( AV83IsAuthorized_InsertManager && ( ( AV51isMainManager ) ) ) )
         {
            bttBtninsertmanager_Visible = 0;
            AssignProp("", false, bttBtninsertmanager_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsertmanager_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Trn_Manager",  1) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = AV17ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "Trn_ManagerWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5) ;
         AV17ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV20TFManagerGivenName = "";
         AssignAttri("", false, "AV20TFManagerGivenName", AV20TFManagerGivenName);
         AV21TFManagerGivenName_Sel = "";
         AssignAttri("", false, "AV21TFManagerGivenName_Sel", AV21TFManagerGivenName_Sel);
         AV22TFManagerLastName = "";
         AssignAttri("", false, "AV22TFManagerLastName", AV22TFManagerLastName);
         AV23TFManagerLastName_Sel = "";
         AssignAttri("", false, "AV23TFManagerLastName_Sel", AV23TFManagerLastName_Sel);
         AV26TFManagerEmail = "";
         AssignAttri("", false, "AV26TFManagerEmail", AV26TFManagerEmail);
         AV27TFManagerEmail_Sel = "";
         AssignAttri("", false, "AV27TFManagerEmail_Sel", AV27TFManagerEmail_Sel);
         AV28TFManagerPhone = "";
         AssignAttri("", false, "AV28TFManagerPhone", AV28TFManagerPhone);
         AV29TFManagerPhone_Sel = "";
         AssignAttri("", false, "AV29TFManagerPhone_Sel", AV29TFManagerPhone_Sel);
         AV31TFManagerGender_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S202( )
      {
         /* 'DO RESENDINVITE' Routine */
         returnInSub = false;
         AV57ManagerId_Selected = A21ManagerId;
         AssignAttri("", false, "AV57ManagerId_Selected", AV57ManagerId_Selected.ToString());
         AV58OrganisationId_Selected = A11OrganisationId;
         AssignAttri("", false, "AV58OrganisationId_Selected", AV58OrganisationId_Selected.ToString());
         this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_RESENDINVITEContainer", "Confirm", "", new Object[] {});
         AV62ManagerGuid_Selected = A28ManagerGAMGUID;
      }

      protected void S262( )
      {
         /* 'DO ACTION RESENDINVITE' Routine */
         returnInSub = false;
         AV62ManagerGuid_Selected = A28ManagerGAMGUID;
         AV63baseUrl = AV8HTTPRequest.BaseURL;
         AV59GAMUser.load( AV62ManagerGuid_Selected);
         AV93ActivactionKey = AV59GAMUser.getnewactivationkey(out  AV36GAMErrors);
         if ( AV36GAMErrors.Count > 0 )
         {
            AV115GXV1 = 1;
            while ( AV115GXV1 <= AV36GAMErrors.Count )
            {
               AV96GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV36GAMErrors.Item(AV115GXV1));
               GX_msglist.addItem(AV96GAMError.gxTpr_Message);
               AV115GXV1 = (int)(AV115GXV1+1);
            }
         }
         else
         {
            context.CommitDataStores("trn_managerww",pr_default);
            new prc_senduseractivationlink(context).executeSubmit(  AV62ManagerGuid_Selected,  AV93ActivactionKey,  AV63baseUrl, ref  AV64isSent, ref  AV97ErrDescription, ref  AV98GAMErrorCollection) ;
            GX_msglist.addItem(context.GetMessage( "Invitation sent successfully.", ""));
         }
      }

      protected void S212( )
      {
         /* 'DO USERACTIONBLOCK' Routine */
         returnInSub = false;
         if ( AV99IsAuthorized_UserActionBlock )
         {
            AV57ManagerId_Selected = A21ManagerId;
            AssignAttri("", false, "AV57ManagerId_Selected", AV57ManagerId_Selected.ToString());
            AV58OrganisationId_Selected = A11OrganisationId;
            AssignAttri("", false, "AV58OrganisationId_Selected", AV58OrganisationId_Selected.ToString());
            this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_USERACTIONBLOCKContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
         AV62ManagerGuid_Selected = A28ManagerGAMGUID;
      }

      protected void S272( )
      {
         /* 'DO ACTION USERACTIONBLOCK' Routine */
         returnInSub = false;
         AV102Trn_Manager.Load(AV57ManagerId_Selected, AV58OrganisationId_Selected);
         AV102Trn_Manager.gxTpr_Managerisactive = false;
         AV102Trn_Manager.Save();
         if ( AV102Trn_Manager.Success() )
         {
            context.CommitDataStores("trn_managerww",pr_default);
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV61OrganisationId, AV19ManageFiltersExecutionStep, AV87ColumnsSelector, AV104Pgmname, AV15FilterFullText, AV20TFManagerGivenName, AV21TFManagerGivenName_Sel, AV22TFManagerLastName, AV23TFManagerLastName_Sel, AV26TFManagerEmail, AV27TFManagerEmail_Sel, AV28TFManagerPhone, AV29TFManagerPhone_Sel, AV31TFManagerGender_Sels, AV51isMainManager, AV99IsAuthorized_UserActionBlock, AV100IsAuthorized_UserActionUnblock, AV43IsAuthorized_Display, AV45IsAuthorized_Update, AV47IsAuthorized_Delete, AV41IsAuthorized_ManagerGivenName) ;
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Success",  context.GetMessage( "Manager Blocked sucessfully", ""),  "success",  "",  "true",  ""));
         }
         else
         {
            AV69Messages = AV102Trn_Manager.GetMessages();
            AV116GXV2 = 1;
            while ( AV116GXV2 <= AV69Messages.Count )
            {
               AV103MessageItem = ((GeneXus.Utils.SdtMessages_Message)AV69Messages.Item(AV116GXV2));
               GX_msglist.addItem(AV103MessageItem.gxTpr_Description);
               AV116GXV2 = (int)(AV116GXV2+1);
            }
         }
      }

      protected void S222( )
      {
         /* 'DO USERACTIONUNBLOCK' Routine */
         returnInSub = false;
         if ( AV100IsAuthorized_UserActionUnblock )
         {
            AV57ManagerId_Selected = A21ManagerId;
            AssignAttri("", false, "AV57ManagerId_Selected", AV57ManagerId_Selected.ToString());
            AV58OrganisationId_Selected = A11OrganisationId;
            AssignAttri("", false, "AV58OrganisationId_Selected", AV58OrganisationId_Selected.ToString());
            this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCKContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
         AV62ManagerGuid_Selected = A28ManagerGAMGUID;
      }

      protected void S282( )
      {
         /* 'DO ACTION USERACTIONUNBLOCK' Routine */
         returnInSub = false;
         AV102Trn_Manager.Load(AV57ManagerId_Selected, AV58OrganisationId_Selected);
         AV102Trn_Manager.gxTpr_Managerisactive = true;
         AV102Trn_Manager.Save();
         if ( AV102Trn_Manager.Success() )
         {
            context.CommitDataStores("trn_managerww",pr_default);
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV61OrganisationId, AV19ManageFiltersExecutionStep, AV87ColumnsSelector, AV104Pgmname, AV15FilterFullText, AV20TFManagerGivenName, AV21TFManagerGivenName_Sel, AV22TFManagerLastName, AV23TFManagerLastName_Sel, AV26TFManagerEmail, AV27TFManagerEmail_Sel, AV28TFManagerPhone, AV29TFManagerPhone_Sel, AV31TFManagerGender_Sels, AV51isMainManager, AV99IsAuthorized_UserActionBlock, AV100IsAuthorized_UserActionUnblock, AV43IsAuthorized_Display, AV45IsAuthorized_Update, AV47IsAuthorized_Delete, AV41IsAuthorized_ManagerGivenName) ;
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Success",  context.GetMessage( "Manager Unblocked sucessfully", ""),  "success",  "",  "true",  ""));
         }
         else
         {
            AV69Messages = AV102Trn_Manager.GetMessages();
            AV117GXV3 = 1;
            while ( AV117GXV3 <= AV69Messages.Count )
            {
               AV103MessageItem = ((GeneXus.Utils.SdtMessages_Message)AV69Messages.Item(AV117GXV3));
               GX_msglist.addItem(AV103MessageItem.gxTpr_Description);
               AV117GXV3 = (int)(AV117GXV3+1);
            }
         }
      }

      protected void S232( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         if ( AV43IsAuthorized_Display )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_managerview.aspx"+UrlEncode(A21ManagerId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            CallWebObject(formatLink("trn_managerview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S242( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         if ( AV45IsAuthorized_Update )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_manager.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A21ManagerId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString());
            CallWebObject(formatLink("trn_manager.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         /* 'DO DELETE' Routine */
         returnInSub = false;
         if ( AV47IsAuthorized_Delete )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_manager.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A21ManagerId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString());
            CallWebObject(formatLink("trn_manager.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV16Session.Get(AV104Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV104Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV16Session.Get(AV104Pgmname+"GridState"), null, "", "");
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
         AV118GXV4 = 1;
         while ( AV118GXV4 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV118GXV4));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMANAGERGIVENNAME") == 0 )
            {
               AV20TFManagerGivenName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV20TFManagerGivenName", AV20TFManagerGivenName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMANAGERGIVENNAME_SEL") == 0 )
            {
               AV21TFManagerGivenName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV21TFManagerGivenName_Sel", AV21TFManagerGivenName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMANAGERLASTNAME") == 0 )
            {
               AV22TFManagerLastName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV22TFManagerLastName", AV22TFManagerLastName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMANAGERLASTNAME_SEL") == 0 )
            {
               AV23TFManagerLastName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV23TFManagerLastName_Sel", AV23TFManagerLastName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMANAGEREMAIL") == 0 )
            {
               AV26TFManagerEmail = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV26TFManagerEmail", AV26TFManagerEmail);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMANAGEREMAIL_SEL") == 0 )
            {
               AV27TFManagerEmail_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV27TFManagerEmail_Sel", AV27TFManagerEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMANAGERPHONE") == 0 )
            {
               AV28TFManagerPhone = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28TFManagerPhone", AV28TFManagerPhone);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMANAGERPHONE_SEL") == 0 )
            {
               AV29TFManagerPhone_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFManagerPhone_Sel", AV29TFManagerPhone_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMANAGERGENDER_SEL") == 0 )
            {
               AV30TFManagerGender_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV30TFManagerGender_SelsJson", AV30TFManagerGender_SelsJson);
               AV31TFManagerGender_Sels.FromJSonString(AV30TFManagerGender_SelsJson, null);
            }
            AV118GXV4 = (int)(AV118GXV4+1);
         }
         GXt_char4 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV21TFManagerGivenName_Sel)),  AV21TFManagerGivenName_Sel, out  GXt_char4) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV23TFManagerLastName_Sel)),  AV23TFManagerLastName_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFManagerEmail_Sel)),  AV27TFManagerEmail_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFManagerPhone_Sel)),  AV29TFManagerPhone_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  (AV31TFManagerGender_Sels.Count==0),  AV30TFManagerGender_SelsJson, out  GXt_char9) ;
         Ddo_grid_Selectedvalue_set = GXt_char4+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char9 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV20TFManagerGivenName)),  AV20TFManagerGivenName, out  GXt_char9) ;
         GXt_char8 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV22TFManagerLastName)),  AV22TFManagerLastName, out  GXt_char8) ;
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV26TFManagerEmail)),  AV26TFManagerEmail, out  GXt_char7) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFManagerPhone)),  AV28TFManagerPhone, out  GXt_char6) ;
         Ddo_grid_Filteredtext_set = GXt_char9+"|"+GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV16Session.Get(AV104Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFMANAGERGIVENNAME",  context.GetMessage( "First Name", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV20TFManagerGivenName)),  0,  AV20TFManagerGivenName,  AV20TFManagerGivenName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV21TFManagerGivenName_Sel)),  AV21TFManagerGivenName_Sel,  AV21TFManagerGivenName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFMANAGERLASTNAME",  context.GetMessage( "Last Name", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV22TFManagerLastName)),  0,  AV22TFManagerLastName,  AV22TFManagerLastName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFManagerLastName_Sel)),  AV23TFManagerLastName_Sel,  AV23TFManagerLastName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFMANAGEREMAIL",  context.GetMessage( "Email", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV26TFManagerEmail)),  0,  AV26TFManagerEmail,  AV26TFManagerEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFManagerEmail_Sel)),  AV27TFManagerEmail_Sel,  AV27TFManagerEmail_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFMANAGERPHONE",  context.GetMessage( "Phone", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFManagerPhone)),  0,  AV28TFManagerPhone,  AV28TFManagerPhone,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFManagerPhone_Sel)),  AV29TFManagerPhone_Sel,  AV29TFManagerPhone_Sel) ;
         AV49AuxText = ((AV31TFManagerGender_Sels.Count==1) ? "["+((string)AV31TFManagerGender_Sels.Item(1))+"]" : context.GetMessage( "WWP_FilterValueDescription_MultipleValues", ""));
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFMANAGERGENDER_SEL",  context.GetMessage( "Gender", ""),  !(AV31TFManagerGender_Sels.Count==0),  0,  AV31TFManagerGender_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV49AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV49AuxText, "[Male]", context.GetMessage( "Male", "")), "[Female]", context.GetMessage( "Female", "")), "[Other]", context.GetMessage( "Other", ""))),  false,  "",  "") ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV104Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV104Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Trn_Manager";
         AV16Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_74_3E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_useractionunblock_Internalname, tblTabledvelop_confirmpanel_useractionunblock_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_useractionunblock.SetProperty("Title", Dvelop_confirmpanel_useractionunblock_Title);
            ucDvelop_confirmpanel_useractionunblock.SetProperty("ConfirmationText", Dvelop_confirmpanel_useractionunblock_Confirmationtext);
            ucDvelop_confirmpanel_useractionunblock.SetProperty("YesButtonCaption", Dvelop_confirmpanel_useractionunblock_Yesbuttoncaption);
            ucDvelop_confirmpanel_useractionunblock.SetProperty("NoButtonCaption", Dvelop_confirmpanel_useractionunblock_Nobuttoncaption);
            ucDvelop_confirmpanel_useractionunblock.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_useractionunblock_Cancelbuttoncaption);
            ucDvelop_confirmpanel_useractionunblock.SetProperty("YesButtonPosition", Dvelop_confirmpanel_useractionunblock_Yesbuttonposition);
            ucDvelop_confirmpanel_useractionunblock.SetProperty("ConfirmType", Dvelop_confirmpanel_useractionunblock_Confirmtype);
            ucDvelop_confirmpanel_useractionunblock.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_useractionunblock_Internalname, "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCKContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_USERACTIONUNBLOCKContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_74_3E2e( true) ;
         }
         else
         {
            wb_table3_74_3E2e( false) ;
         }
      }

      protected void wb_table2_69_3E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_useractionblock_Internalname, tblTabledvelop_confirmpanel_useractionblock_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_useractionblock.SetProperty("Title", Dvelop_confirmpanel_useractionblock_Title);
            ucDvelop_confirmpanel_useractionblock.SetProperty("ConfirmationText", Dvelop_confirmpanel_useractionblock_Confirmationtext);
            ucDvelop_confirmpanel_useractionblock.SetProperty("YesButtonCaption", Dvelop_confirmpanel_useractionblock_Yesbuttoncaption);
            ucDvelop_confirmpanel_useractionblock.SetProperty("NoButtonCaption", Dvelop_confirmpanel_useractionblock_Nobuttoncaption);
            ucDvelop_confirmpanel_useractionblock.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_useractionblock_Cancelbuttoncaption);
            ucDvelop_confirmpanel_useractionblock.SetProperty("YesButtonPosition", Dvelop_confirmpanel_useractionblock_Yesbuttonposition);
            ucDvelop_confirmpanel_useractionblock.SetProperty("ConfirmType", Dvelop_confirmpanel_useractionblock_Confirmtype);
            ucDvelop_confirmpanel_useractionblock.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_useractionblock_Internalname, "DVELOP_CONFIRMPANEL_USERACTIONBLOCKContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_USERACTIONBLOCKContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_69_3E2e( true) ;
         }
         else
         {
            wb_table2_69_3E2e( false) ;
         }
      }

      protected void wb_table1_64_3E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_resendinvite_Internalname, tblTabledvelop_confirmpanel_resendinvite_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_resendinvite.SetProperty("Title", Dvelop_confirmpanel_resendinvite_Title);
            ucDvelop_confirmpanel_resendinvite.SetProperty("ConfirmationText", Dvelop_confirmpanel_resendinvite_Confirmationtext);
            ucDvelop_confirmpanel_resendinvite.SetProperty("YesButtonCaption", Dvelop_confirmpanel_resendinvite_Yesbuttoncaption);
            ucDvelop_confirmpanel_resendinvite.SetProperty("NoButtonCaption", Dvelop_confirmpanel_resendinvite_Nobuttoncaption);
            ucDvelop_confirmpanel_resendinvite.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_resendinvite_Cancelbuttoncaption);
            ucDvelop_confirmpanel_resendinvite.SetProperty("YesButtonPosition", Dvelop_confirmpanel_resendinvite_Yesbuttonposition);
            ucDvelop_confirmpanel_resendinvite.SetProperty("ConfirmType", Dvelop_confirmpanel_resendinvite_Confirmtype);
            ucDvelop_confirmpanel_resendinvite.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_resendinvite_Internalname, "DVELOP_CONFIRMPANEL_RESENDINVITEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_RESENDINVITEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_64_3E2e( true) ;
         }
         else
         {
            wb_table1_64_3E2e( false) ;
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
         PA3E2( ) ;
         WS3E2( ) ;
         WE3E2( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256309462542", true, true);
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
         context.AddJavascriptSource("trn_managerww.js", "?20256309462545", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_392( )
      {
         edtManagerId_Internalname = "MANAGERID_"+sGXsfl_39_idx;
         edtOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_39_idx;
         edtManagerGivenName_Internalname = "MANAGERGIVENNAME_"+sGXsfl_39_idx;
         edtManagerLastName_Internalname = "MANAGERLASTNAME_"+sGXsfl_39_idx;
         edtManagerInitials_Internalname = "MANAGERINITIALS_"+sGXsfl_39_idx;
         edtManagerEmail_Internalname = "MANAGEREMAIL_"+sGXsfl_39_idx;
         edtManagerPhone_Internalname = "MANAGERPHONE_"+sGXsfl_39_idx;
         edtManagerPhoneCode_Internalname = "MANAGERPHONECODE_"+sGXsfl_39_idx;
         edtManagerPhoneNumber_Internalname = "MANAGERPHONENUMBER_"+sGXsfl_39_idx;
         cmbManagerGender_Internalname = "MANAGERGENDER_"+sGXsfl_39_idx;
         edtManagerGAMGUID_Internalname = "MANAGERGAMGUID_"+sGXsfl_39_idx;
         chkManagerIsMainManager_Internalname = "MANAGERISMAINMANAGER_"+sGXsfl_39_idx;
         chkManagerIsActive_Internalname = "MANAGERISACTIVE_"+sGXsfl_39_idx;
         edtavManagerisactive_Internalname = "vMANAGERISACTIVE_"+sGXsfl_39_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_39_idx;
      }

      protected void SubsflControlProps_fel_392( )
      {
         edtManagerId_Internalname = "MANAGERID_"+sGXsfl_39_fel_idx;
         edtOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_39_fel_idx;
         edtManagerGivenName_Internalname = "MANAGERGIVENNAME_"+sGXsfl_39_fel_idx;
         edtManagerLastName_Internalname = "MANAGERLASTNAME_"+sGXsfl_39_fel_idx;
         edtManagerInitials_Internalname = "MANAGERINITIALS_"+sGXsfl_39_fel_idx;
         edtManagerEmail_Internalname = "MANAGEREMAIL_"+sGXsfl_39_fel_idx;
         edtManagerPhone_Internalname = "MANAGERPHONE_"+sGXsfl_39_fel_idx;
         edtManagerPhoneCode_Internalname = "MANAGERPHONECODE_"+sGXsfl_39_fel_idx;
         edtManagerPhoneNumber_Internalname = "MANAGERPHONENUMBER_"+sGXsfl_39_fel_idx;
         cmbManagerGender_Internalname = "MANAGERGENDER_"+sGXsfl_39_fel_idx;
         edtManagerGAMGUID_Internalname = "MANAGERGAMGUID_"+sGXsfl_39_fel_idx;
         chkManagerIsMainManager_Internalname = "MANAGERISMAINMANAGER_"+sGXsfl_39_fel_idx;
         chkManagerIsActive_Internalname = "MANAGERISACTIVE_"+sGXsfl_39_fel_idx;
         edtavManagerisactive_Internalname = "vMANAGERISACTIVE_"+sGXsfl_39_fel_idx;
         cmbavActiongroup_Internalname = "vACTIONGROUP_"+sGXsfl_39_fel_idx;
      }

      protected void sendrow_392( )
      {
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_392( ) ;
         WB3E0( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtManagerId_Internalname,A21ManagerId.ToString(),A21ManagerId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtManagerId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)39,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationId_Internalname,A11OrganisationId.ToString(),A11OrganisationId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)39,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtManagerGivenName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtManagerGivenName_Internalname,(string)A22ManagerGivenName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtManagerGivenName_Link,(string)"",(string)"",(string)"",(string)edtManagerGivenName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtManagerGivenName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtManagerLastName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtManagerLastName_Internalname,(string)A23ManagerLastName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtManagerLastName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtManagerLastName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtManagerInitials_Internalname,StringUtil.RTrim( A24ManagerInitials),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtManagerInitials_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtManagerEmail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtManagerEmail_Internalname,(string)A25ManagerEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A25ManagerEmail,(string)"",(string)"",(string)"",(string)edtManagerEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtManagerEmail_Visible,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtManagerPhone_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A26ManagerPhone);
            }
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtManagerPhone_Internalname,StringUtil.RTrim( A26ManagerPhone),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtManagerPhone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtManagerPhone_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtManagerPhoneCode_Internalname,(string)A357ManagerPhoneCode,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtManagerPhoneCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtManagerPhoneNumber_Internalname,(string)A358ManagerPhoneNumber,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtManagerPhoneNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbManagerGender.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbManagerGender.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MANAGERGENDER_" + sGXsfl_39_idx;
               cmbManagerGender.Name = GXCCtl;
               cmbManagerGender.WebTags = "";
               cmbManagerGender.addItem("Male", context.GetMessage( "Male", ""), 0);
               cmbManagerGender.addItem("Female", context.GetMessage( "Female", ""), 0);
               cmbManagerGender.addItem("Other", context.GetMessage( "Other", ""), 0);
               if ( cmbManagerGender.ItemCount > 0 )
               {
                  A27ManagerGender = cmbManagerGender.getValidValue(A27ManagerGender);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbManagerGender,(string)cmbManagerGender_Internalname,StringUtil.RTrim( A27ManagerGender),(short)1,(string)cmbManagerGender_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",cmbManagerGender.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbManagerGender.CurrentValue = StringUtil.RTrim( A27ManagerGender);
            AssignProp("", false, cmbManagerGender_Internalname, "Values", (string)(cmbManagerGender.ToJavascriptSource()), !bGXsfl_39_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtManagerGAMGUID_Internalname,(string)A28ManagerGAMGUID,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtManagerGAMGUID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)0,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMUserIdentification",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "MANAGERISMAINMANAGER_" + sGXsfl_39_idx;
            chkManagerIsMainManager.Name = GXCCtl;
            chkManagerIsMainManager.WebTags = "";
            chkManagerIsMainManager.Caption = "";
            AssignProp("", false, chkManagerIsMainManager_Internalname, "TitleCaption", chkManagerIsMainManager.Caption, !bGXsfl_39_Refreshing);
            chkManagerIsMainManager.CheckedValue = "false";
            A332ManagerIsMainManager = StringUtil.StrToBool( StringUtil.BoolToStr( A332ManagerIsMainManager));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkManagerIsMainManager_Internalname,StringUtil.BoolToStr( A332ManagerIsMainManager),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "MANAGERISACTIVE_" + sGXsfl_39_idx;
            chkManagerIsActive.Name = GXCCtl;
            chkManagerIsActive.WebTags = "";
            chkManagerIsActive.Caption = "";
            AssignProp("", false, chkManagerIsActive_Internalname, "TitleCaption", chkManagerIsActive.Caption, !bGXsfl_39_Refreshing);
            chkManagerIsActive.CheckedValue = "false";
            A365ManagerIsActive = StringUtil.StrToBool( StringUtil.BoolToStr( A365ManagerIsActive));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkManagerIsActive_Internalname,StringUtil.BoolToStr( A365ManagerIsActive),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavManagerisactive_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_39_idx + "',39)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavManagerisactive_Internalname,StringUtil.RTrim( AV60ManagerIsActive),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavManagerisactive_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtavManagerisactive_Columnclass,(string)edtavManagerisactive_Columnheaderclass,(int)edtavManagerisactive_Visible,(int)edtavManagerisactive_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_39_idx + "',39)\"";
            if ( ( cmbavActiongroup.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vACTIONGROUP_" + sGXsfl_39_idx;
               cmbavActiongroup.Name = GXCCtl;
               cmbavActiongroup.WebTags = "";
               if ( cmbavActiongroup.ItemCount > 0 )
               {
                  AV82ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV82ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV82ActionGroup), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavActiongroup,(string)cmbavActiongroup_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV82ActionGroup), 4, 0)),(short)1,(string)cmbavActiongroup_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVACTIONGROUP.CLICK."+sGXsfl_39_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavActiongroup_Class,(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"",(string)"",(bool)true,(short)0});
            cmbavActiongroup.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV82ActionGroup), 4, 0));
            AssignProp("", false, cmbavActiongroup_Internalname, "Values", (string)(cmbavActiongroup.ToJavascriptSource()), !bGXsfl_39_Refreshing);
            send_integrity_lvl_hashes3E2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_39_idx = ((subGrid_Islastpage==1)&&(nGXsfl_39_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         /* End function sendrow_392 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "MANAGERGENDER_" + sGXsfl_39_idx;
         cmbManagerGender.Name = GXCCtl;
         cmbManagerGender.WebTags = "";
         cmbManagerGender.addItem("Male", context.GetMessage( "Male", ""), 0);
         cmbManagerGender.addItem("Female", context.GetMessage( "Female", ""), 0);
         cmbManagerGender.addItem("Other", context.GetMessage( "Other", ""), 0);
         if ( cmbManagerGender.ItemCount > 0 )
         {
            A27ManagerGender = cmbManagerGender.getValidValue(A27ManagerGender);
         }
         GXCCtl = "MANAGERISMAINMANAGER_" + sGXsfl_39_idx;
         chkManagerIsMainManager.Name = GXCCtl;
         chkManagerIsMainManager.WebTags = "";
         chkManagerIsMainManager.Caption = "";
         AssignProp("", false, chkManagerIsMainManager_Internalname, "TitleCaption", chkManagerIsMainManager.Caption, !bGXsfl_39_Refreshing);
         chkManagerIsMainManager.CheckedValue = "false";
         A332ManagerIsMainManager = StringUtil.StrToBool( StringUtil.BoolToStr( A332ManagerIsMainManager));
         GXCCtl = "MANAGERISACTIVE_" + sGXsfl_39_idx;
         chkManagerIsActive.Name = GXCCtl;
         chkManagerIsActive.WebTags = "";
         chkManagerIsActive.Caption = "";
         AssignProp("", false, chkManagerIsActive_Internalname, "TitleCaption", chkManagerIsActive.Caption, !bGXsfl_39_Refreshing);
         chkManagerIsActive.CheckedValue = "false";
         A365ManagerIsActive = StringUtil.StrToBool( StringUtil.BoolToStr( A365ManagerIsActive));
         GXCCtl = "vACTIONGROUP_" + sGXsfl_39_idx;
         cmbavActiongroup.Name = GXCCtl;
         cmbavActiongroup.WebTags = "";
         if ( cmbavActiongroup.ItemCount > 0 )
         {
            AV82ActionGroup = (short)(Math.Round(NumberUtil.Val( cmbavActiongroup.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV82ActionGroup), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavActiongroup_Internalname, StringUtil.LTrimStr( (decimal)(AV82ActionGroup), 4, 0));
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtManagerGivenName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "First Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtManagerLastName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Last Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtManagerEmail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Email", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtManagerPhone_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Phone", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbManagerGender.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Gender", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavManagerisactive_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Account Status", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+cmbavActiongroup_Class+"\" "+" style=\""+""+""+"\" "+">") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A21ManagerId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A11OrganisationId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A22ManagerGivenName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtManagerGivenName_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtManagerGivenName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A23ManagerLastName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtManagerLastName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A24ManagerInitials)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A25ManagerEmail));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtManagerEmail_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A26ManagerPhone)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtManagerPhone_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A357ManagerPhoneCode));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A358ManagerPhoneNumber));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A27ManagerGender));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbManagerGender.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A28ManagerGAMGUID));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A332ManagerIsMainManager)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A365ManagerIsActive)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV60ManagerIsActive)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavManagerisactive_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavManagerisactive_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavManagerisactive_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavManagerisactive_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV82ActionGroup), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( cmbavActiongroup_Class));
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
         bttBtninsertmanager_Internalname = "BTNINSERTMANAGER";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         bttBtnsubscriptions_Internalname = "BTNSUBSCRIPTIONS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtManagerId_Internalname = "MANAGERID";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         edtManagerGivenName_Internalname = "MANAGERGIVENNAME";
         edtManagerLastName_Internalname = "MANAGERLASTNAME";
         edtManagerInitials_Internalname = "MANAGERINITIALS";
         edtManagerEmail_Internalname = "MANAGEREMAIL";
         edtManagerPhone_Internalname = "MANAGERPHONE";
         edtManagerPhoneCode_Internalname = "MANAGERPHONECODE";
         edtManagerPhoneNumber_Internalname = "MANAGERPHONENUMBER";
         cmbManagerGender_Internalname = "MANAGERGENDER";
         edtManagerGAMGUID_Internalname = "MANAGERGAMGUID";
         chkManagerIsMainManager_Internalname = "MANAGERISMAINMANAGER";
         chkManagerIsActive_Internalname = "MANAGERISACTIVE";
         edtavManagerisactive_Internalname = "vMANAGERISACTIVE";
         cmbavActiongroup_Internalname = "vACTIONGROUP";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Dvelop_confirmpanel_resendinvite_Internalname = "DVELOP_CONFIRMPANEL_RESENDINVITE";
         tblTabledvelop_confirmpanel_resendinvite_Internalname = "TABLEDVELOP_CONFIRMPANEL_RESENDINVITE";
         Dvelop_confirmpanel_useractionblock_Internalname = "DVELOP_CONFIRMPANEL_USERACTIONBLOCK";
         tblTabledvelop_confirmpanel_useractionblock_Internalname = "TABLEDVELOP_CONFIRMPANEL_USERACTIONBLOCK";
         Dvelop_confirmpanel_useractionunblock_Internalname = "DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK";
         tblTabledvelop_confirmpanel_useractionunblock_Internalname = "TABLEDVELOP_CONFIRMPANEL_USERACTIONUNBLOCK";
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
         cmbavActiongroup_Class = "ConvertToDDO";
         edtavManagerisactive_Jsonclick = "";
         edtavManagerisactive_Columnclass = "WWColumn";
         edtavManagerisactive_Enabled = 1;
         chkManagerIsActive.Caption = "";
         chkManagerIsMainManager.Caption = "";
         edtManagerGAMGUID_Jsonclick = "";
         cmbManagerGender_Jsonclick = "";
         edtManagerPhoneNumber_Jsonclick = "";
         edtManagerPhoneCode_Jsonclick = "";
         edtManagerPhone_Jsonclick = "";
         edtManagerEmail_Jsonclick = "";
         edtManagerInitials_Jsonclick = "";
         edtManagerLastName_Jsonclick = "";
         edtManagerGivenName_Jsonclick = "";
         edtManagerGivenName_Link = "";
         edtOrganisationId_Jsonclick = "";
         edtManagerId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavManagerisactive_Columnheaderclass = "";
         edtavManagerisactive_Visible = -1;
         cmbManagerGender.Visible = -1;
         edtManagerPhone_Visible = -1;
         edtManagerEmail_Visible = -1;
         edtManagerLastName_Visible = -1;
         edtManagerGivenName_Visible = -1;
         chkManagerIsActive.Enabled = 0;
         chkManagerIsMainManager.Enabled = 0;
         edtManagerGAMGUID_Enabled = 0;
         cmbManagerGender.Enabled = 0;
         edtManagerPhoneNumber_Enabled = 0;
         edtManagerPhoneCode_Enabled = 0;
         edtManagerPhone_Enabled = 0;
         edtManagerEmail_Enabled = 0;
         edtManagerInitials_Enabled = 0;
         edtManagerLastName_Enabled = 0;
         edtManagerGivenName_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         edtManagerId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsertmanager_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Dvelop_confirmpanel_useractionunblock_Confirmtype = "1";
         Dvelop_confirmpanel_useractionunblock_Yesbuttonposition = "left";
         Dvelop_confirmpanel_useractionunblock_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_useractionunblock_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_useractionunblock_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_useractionunblock_Confirmationtext = "Are you sure you want to unblock this manager's account?";
         Dvelop_confirmpanel_useractionunblock_Title = context.GetMessage( "Unblock Manager", "");
         Dvelop_confirmpanel_useractionblock_Confirmtype = "1";
         Dvelop_confirmpanel_useractionblock_Yesbuttonposition = "left";
         Dvelop_confirmpanel_useractionblock_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_useractionblock_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_useractionblock_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_useractionblock_Confirmationtext = "Are you sure you want to block this manager's account?";
         Dvelop_confirmpanel_useractionblock_Title = context.GetMessage( "Block Manager Account", "");
         Dvelop_confirmpanel_resendinvite_Confirmtype = "1";
         Dvelop_confirmpanel_resendinvite_Yesbuttonposition = "left";
         Dvelop_confirmpanel_resendinvite_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_resendinvite_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_resendinvite_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_resendinvite_Confirmationtext = "Are you sure you want to re-send an ivititation to this manager?";
         Dvelop_confirmpanel_resendinvite_Title = context.GetMessage( "Re - Send Invitation", "");
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Datalistproc = "Trn_ManagerWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||||Male:Male,Female:Female,Other:Other";
         Ddo_grid_Allowmultipleselection = "||||T";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|Character|";
         Ddo_grid_Includefilter = "T|T|T|T|";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5";
         Ddo_grid_Columnids = "2:ManagerGivenName|3:ManagerLastName|5:ManagerEmail|6:ManagerPhone|9:ManagerGender";
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
         Form.Caption = context.GetMessage( " Managers", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV61OrganisationId","fld":"vORGANISATIONID"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV87ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV104Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFManagerGivenName","fld":"vTFMANAGERGIVENNAME"},{"av":"AV21TFManagerGivenName_Sel","fld":"vTFMANAGERGIVENNAME_SEL"},{"av":"AV22TFManagerLastName","fld":"vTFMANAGERLASTNAME"},{"av":"AV23TFManagerLastName_Sel","fld":"vTFMANAGERLASTNAME_SEL"},{"av":"AV26TFManagerEmail","fld":"vTFMANAGEREMAIL"},{"av":"AV27TFManagerEmail_Sel","fld":"vTFMANAGEREMAIL_SEL"},{"av":"AV28TFManagerPhone","fld":"vTFMANAGERPHONE"},{"av":"AV29TFManagerPhone_Sel","fld":"vTFMANAGERPHONE_SEL"},{"av":"AV31TFManagerGender_Sels","fld":"vTFMANAGERGENDER_SELS"},{"av":"AV51isMainManager","fld":"vISMAINMANAGER","hsh":true},{"av":"AV99IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV100IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_ManagerGivenName","fld":"vISAUTHORIZED_MANAGERGIVENNAME","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV87ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtManagerGivenName_Visible","ctrl":"MANAGERGIVENNAME","prop":"Visible"},{"av":"edtManagerLastName_Visible","ctrl":"MANAGERLASTNAME","prop":"Visible"},{"av":"edtManagerEmail_Visible","ctrl":"MANAGEREMAIL","prop":"Visible"},{"av":"edtManagerPhone_Visible","ctrl":"MANAGERPHONE","prop":"Visible"},{"av":"cmbManagerGender"},{"av":"edtavManagerisactive_Visible","ctrl":"vMANAGERISACTIVE","prop":"Visible"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavManagerisactive_Columnheaderclass","ctrl":"vMANAGERISACTIVE","prop":"Columnheaderclass"},{"av":"AV99IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV100IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"ctrl":"BTNINSERTMANAGER","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E123E2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV61OrganisationId","fld":"vORGANISATIONID"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV87ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV104Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFManagerGivenName","fld":"vTFMANAGERGIVENNAME"},{"av":"AV21TFManagerGivenName_Sel","fld":"vTFMANAGERGIVENNAME_SEL"},{"av":"AV22TFManagerLastName","fld":"vTFMANAGERLASTNAME"},{"av":"AV23TFManagerLastName_Sel","fld":"vTFMANAGERLASTNAME_SEL"},{"av":"AV26TFManagerEmail","fld":"vTFMANAGEREMAIL"},{"av":"AV27TFManagerEmail_Sel","fld":"vTFMANAGEREMAIL_SEL"},{"av":"AV28TFManagerPhone","fld":"vTFMANAGERPHONE"},{"av":"AV29TFManagerPhone_Sel","fld":"vTFMANAGERPHONE_SEL"},{"av":"AV31TFManagerGender_Sels","fld":"vTFMANAGERGENDER_SELS"},{"av":"AV51isMainManager","fld":"vISMAINMANAGER","hsh":true},{"av":"AV99IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV100IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_ManagerGivenName","fld":"vISAUTHORIZED_MANAGERGIVENNAME","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E133E2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV61OrganisationId","fld":"vORGANISATIONID"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV87ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV104Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFManagerGivenName","fld":"vTFMANAGERGIVENNAME"},{"av":"AV21TFManagerGivenName_Sel","fld":"vTFMANAGERGIVENNAME_SEL"},{"av":"AV22TFManagerLastName","fld":"vTFMANAGERLASTNAME"},{"av":"AV23TFManagerLastName_Sel","fld":"vTFMANAGERLASTNAME_SEL"},{"av":"AV26TFManagerEmail","fld":"vTFMANAGEREMAIL"},{"av":"AV27TFManagerEmail_Sel","fld":"vTFMANAGEREMAIL_SEL"},{"av":"AV28TFManagerPhone","fld":"vTFMANAGERPHONE"},{"av":"AV29TFManagerPhone_Sel","fld":"vTFMANAGERPHONE_SEL"},{"av":"AV31TFManagerGender_Sels","fld":"vTFMANAGERGENDER_SELS"},{"av":"AV51isMainManager","fld":"vISMAINMANAGER","hsh":true},{"av":"AV99IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV100IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_ManagerGivenName","fld":"vISAUTHORIZED_MANAGERGIVENNAME","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E153E2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV61OrganisationId","fld":"vORGANISATIONID"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV87ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV104Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFManagerGivenName","fld":"vTFMANAGERGIVENNAME"},{"av":"AV21TFManagerGivenName_Sel","fld":"vTFMANAGERGIVENNAME_SEL"},{"av":"AV22TFManagerLastName","fld":"vTFMANAGERLASTNAME"},{"av":"AV23TFManagerLastName_Sel","fld":"vTFMANAGERLASTNAME_SEL"},{"av":"AV26TFManagerEmail","fld":"vTFMANAGEREMAIL"},{"av":"AV27TFManagerEmail_Sel","fld":"vTFMANAGEREMAIL_SEL"},{"av":"AV28TFManagerPhone","fld":"vTFMANAGERPHONE"},{"av":"AV29TFManagerPhone_Sel","fld":"vTFMANAGERPHONE_SEL"},{"av":"AV31TFManagerGender_Sels","fld":"vTFMANAGERGENDER_SELS"},{"av":"AV51isMainManager","fld":"vISMAINMANAGER","hsh":true},{"av":"AV99IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV100IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_ManagerGivenName","fld":"vISAUTHORIZED_MANAGERGIVENNAME","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV20TFManagerGivenName","fld":"vTFMANAGERGIVENNAME"},{"av":"AV21TFManagerGivenName_Sel","fld":"vTFMANAGERGIVENNAME_SEL"},{"av":"AV22TFManagerLastName","fld":"vTFMANAGERLASTNAME"},{"av":"AV23TFManagerLastName_Sel","fld":"vTFMANAGERLASTNAME_SEL"},{"av":"AV26TFManagerEmail","fld":"vTFMANAGEREMAIL"},{"av":"AV27TFManagerEmail_Sel","fld":"vTFMANAGEREMAIL_SEL"},{"av":"AV28TFManagerPhone","fld":"vTFMANAGERPHONE"},{"av":"AV29TFManagerPhone_Sel","fld":"vTFMANAGERPHONE_SEL"},{"av":"AV30TFManagerGender_SelsJson","fld":"vTFMANAGERGENDER_SELSJSON"},{"av":"AV31TFManagerGender_Sels","fld":"vTFMANAGERGENDER_SELS"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E233E2","iparms":[{"av":"A28ManagerGAMGUID","fld":"MANAGERGAMGUID","hsh":true},{"av":"AV51isMainManager","fld":"vISMAINMANAGER","hsh":true},{"av":"AV99IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV100IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_ManagerGivenName","fld":"vISAUTHORIZED_MANAGERGIVENNAME","hsh":true},{"av":"A21ManagerId","fld":"MANAGERID","hsh":true},{"av":"A11OrganisationId","fld":"ORGANISATIONID","hsh":true}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV82ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"edtManagerGivenName_Link","ctrl":"MANAGERGIVENNAME","prop":"Link"},{"av":"edtavManagerisactive_Columnclass","ctrl":"vMANAGERISACTIVE","prop":"Columnclass"},{"av":"AV60ManagerIsActive","fld":"vMANAGERISACTIVE"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E163E2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV61OrganisationId","fld":"vORGANISATIONID"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV87ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV104Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFManagerGivenName","fld":"vTFMANAGERGIVENNAME"},{"av":"AV21TFManagerGivenName_Sel","fld":"vTFMANAGERGIVENNAME_SEL"},{"av":"AV22TFManagerLastName","fld":"vTFMANAGERLASTNAME"},{"av":"AV23TFManagerLastName_Sel","fld":"vTFMANAGERLASTNAME_SEL"},{"av":"AV26TFManagerEmail","fld":"vTFMANAGEREMAIL"},{"av":"AV27TFManagerEmail_Sel","fld":"vTFMANAGEREMAIL_SEL"},{"av":"AV28TFManagerPhone","fld":"vTFMANAGERPHONE"},{"av":"AV29TFManagerPhone_Sel","fld":"vTFMANAGERPHONE_SEL"},{"av":"AV31TFManagerGender_Sels","fld":"vTFMANAGERGENDER_SELS"},{"av":"AV51isMainManager","fld":"vISMAINMANAGER","hsh":true},{"av":"AV99IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV100IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_ManagerGivenName","fld":"vISAUTHORIZED_MANAGERGIVENNAME","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV87ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtManagerGivenName_Visible","ctrl":"MANAGERGIVENNAME","prop":"Visible"},{"av":"edtManagerLastName_Visible","ctrl":"MANAGERLASTNAME","prop":"Visible"},{"av":"edtManagerEmail_Visible","ctrl":"MANAGEREMAIL","prop":"Visible"},{"av":"edtManagerPhone_Visible","ctrl":"MANAGERPHONE","prop":"Visible"},{"av":"cmbManagerGender"},{"av":"edtavManagerisactive_Visible","ctrl":"vMANAGERISACTIVE","prop":"Visible"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavManagerisactive_Columnheaderclass","ctrl":"vMANAGERISACTIVE","prop":"Columnheaderclass"},{"av":"AV99IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV100IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"ctrl":"BTNINSERTMANAGER","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E113E2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV61OrganisationId","fld":"vORGANISATIONID"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV87ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV104Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFManagerGivenName","fld":"vTFMANAGERGIVENNAME"},{"av":"AV21TFManagerGivenName_Sel","fld":"vTFMANAGERGIVENNAME_SEL"},{"av":"AV22TFManagerLastName","fld":"vTFMANAGERLASTNAME"},{"av":"AV23TFManagerLastName_Sel","fld":"vTFMANAGERLASTNAME_SEL"},{"av":"AV26TFManagerEmail","fld":"vTFMANAGEREMAIL"},{"av":"AV27TFManagerEmail_Sel","fld":"vTFMANAGEREMAIL_SEL"},{"av":"AV28TFManagerPhone","fld":"vTFMANAGERPHONE"},{"av":"AV29TFManagerPhone_Sel","fld":"vTFMANAGERPHONE_SEL"},{"av":"AV31TFManagerGender_Sels","fld":"vTFMANAGERGENDER_SELS"},{"av":"AV51isMainManager","fld":"vISMAINMANAGER","hsh":true},{"av":"AV99IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV100IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_ManagerGivenName","fld":"vISAUTHORIZED_MANAGERGIVENNAME","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV30TFManagerGender_SelsJson","fld":"vTFMANAGERGENDER_SELSJSON"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFManagerGivenName","fld":"vTFMANAGERGIVENNAME"},{"av":"AV21TFManagerGivenName_Sel","fld":"vTFMANAGERGIVENNAME_SEL"},{"av":"AV22TFManagerLastName","fld":"vTFMANAGERLASTNAME"},{"av":"AV23TFManagerLastName_Sel","fld":"vTFMANAGERLASTNAME_SEL"},{"av":"AV26TFManagerEmail","fld":"vTFMANAGEREMAIL"},{"av":"AV27TFManagerEmail_Sel","fld":"vTFMANAGEREMAIL_SEL"},{"av":"AV28TFManagerPhone","fld":"vTFMANAGERPHONE"},{"av":"AV29TFManagerPhone_Sel","fld":"vTFMANAGERPHONE_SEL"},{"av":"AV31TFManagerGender_Sels","fld":"vTFMANAGERGENDER_SELS"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV30TFManagerGender_SelsJson","fld":"vTFMANAGERGENDER_SELSJSON"},{"av":"AV87ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtManagerGivenName_Visible","ctrl":"MANAGERGIVENNAME","prop":"Visible"},{"av":"edtManagerLastName_Visible","ctrl":"MANAGERLASTNAME","prop":"Visible"},{"av":"edtManagerEmail_Visible","ctrl":"MANAGEREMAIL","prop":"Visible"},{"av":"edtManagerPhone_Visible","ctrl":"MANAGERPHONE","prop":"Visible"},{"av":"cmbManagerGender"},{"av":"edtavManagerisactive_Visible","ctrl":"vMANAGERISACTIVE","prop":"Visible"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavManagerisactive_Columnheaderclass","ctrl":"vMANAGERISACTIVE","prop":"Columnheaderclass"},{"av":"AV99IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV100IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"ctrl":"BTNINSERTMANAGER","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VACTIONGROUP.CLICK","""{"handler":"E243E2","iparms":[{"av":"cmbavActiongroup"},{"av":"AV82ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"A21ManagerId","fld":"MANAGERID","hsh":true},{"av":"A11OrganisationId","fld":"ORGANISATIONID","hsh":true},{"av":"A28ManagerGAMGUID","fld":"MANAGERGAMGUID","hsh":true},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV61OrganisationId","fld":"vORGANISATIONID"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV87ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV104Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFManagerGivenName","fld":"vTFMANAGERGIVENNAME"},{"av":"AV21TFManagerGivenName_Sel","fld":"vTFMANAGERGIVENNAME_SEL"},{"av":"AV22TFManagerLastName","fld":"vTFMANAGERLASTNAME"},{"av":"AV23TFManagerLastName_Sel","fld":"vTFMANAGERLASTNAME_SEL"},{"av":"AV26TFManagerEmail","fld":"vTFMANAGEREMAIL"},{"av":"AV27TFManagerEmail_Sel","fld":"vTFMANAGEREMAIL_SEL"},{"av":"AV28TFManagerPhone","fld":"vTFMANAGERPHONE"},{"av":"AV29TFManagerPhone_Sel","fld":"vTFMANAGERPHONE_SEL"},{"av":"AV31TFManagerGender_Sels","fld":"vTFMANAGERGENDER_SELS"},{"av":"AV51isMainManager","fld":"vISMAINMANAGER","hsh":true},{"av":"AV99IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV100IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_ManagerGivenName","fld":"vISAUTHORIZED_MANAGERGIVENNAME","hsh":true}]""");
         setEventMetadata("VACTIONGROUP.CLICK",""","oparms":[{"av":"cmbavActiongroup"},{"av":"AV82ActionGroup","fld":"vACTIONGROUP","pic":"ZZZ9"},{"av":"AV57ManagerId_Selected","fld":"vMANAGERID_SELECTED"},{"av":"AV58OrganisationId_Selected","fld":"vORGANISATIONID_SELECTED"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV87ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtManagerGivenName_Visible","ctrl":"MANAGERGIVENNAME","prop":"Visible"},{"av":"edtManagerLastName_Visible","ctrl":"MANAGERLASTNAME","prop":"Visible"},{"av":"edtManagerEmail_Visible","ctrl":"MANAGEREMAIL","prop":"Visible"},{"av":"edtManagerPhone_Visible","ctrl":"MANAGERPHONE","prop":"Visible"},{"av":"cmbManagerGender"},{"av":"edtavManagerisactive_Visible","ctrl":"vMANAGERISACTIVE","prop":"Visible"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavManagerisactive_Columnheaderclass","ctrl":"vMANAGERISACTIVE","prop":"Columnheaderclass"},{"av":"AV99IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV100IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"ctrl":"BTNINSERTMANAGER","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_RESENDINVITE.CLOSE","""{"handler":"E173E2","iparms":[{"av":"Dvelop_confirmpanel_resendinvite_Result","ctrl":"DVELOP_CONFIRMPANEL_RESENDINVITE","prop":"Result"},{"av":"A28ManagerGAMGUID","fld":"MANAGERGAMGUID","hsh":true},{"av":"AV8HTTPRequest.BaseURL","ctrl":"vHTTPREQUEST","prop":"Baseurl"},{"av":"AV64isSent","fld":"vISSENT"},{"av":"AV97ErrDescription","fld":"vERRDESCRIPTION"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_RESENDINVITE.CLOSE",""","oparms":[{"av":"AV97ErrDescription","fld":"vERRDESCRIPTION"},{"av":"AV64isSent","fld":"vISSENT"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONBLOCK.CLOSE","""{"handler":"E183E2","iparms":[{"av":"Dvelop_confirmpanel_useractionblock_Result","ctrl":"DVELOP_CONFIRMPANEL_USERACTIONBLOCK","prop":"Result"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV61OrganisationId","fld":"vORGANISATIONID"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV87ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV104Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFManagerGivenName","fld":"vTFMANAGERGIVENNAME"},{"av":"AV21TFManagerGivenName_Sel","fld":"vTFMANAGERGIVENNAME_SEL"},{"av":"AV22TFManagerLastName","fld":"vTFMANAGERLASTNAME"},{"av":"AV23TFManagerLastName_Sel","fld":"vTFMANAGERLASTNAME_SEL"},{"av":"AV26TFManagerEmail","fld":"vTFMANAGEREMAIL"},{"av":"AV27TFManagerEmail_Sel","fld":"vTFMANAGEREMAIL_SEL"},{"av":"AV28TFManagerPhone","fld":"vTFMANAGERPHONE"},{"av":"AV29TFManagerPhone_Sel","fld":"vTFMANAGERPHONE_SEL"},{"av":"AV31TFManagerGender_Sels","fld":"vTFMANAGERGENDER_SELS"},{"av":"AV51isMainManager","fld":"vISMAINMANAGER","hsh":true},{"av":"AV99IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV100IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_ManagerGivenName","fld":"vISAUTHORIZED_MANAGERGIVENNAME","hsh":true},{"av":"AV57ManagerId_Selected","fld":"vMANAGERID_SELECTED"},{"av":"AV58OrganisationId_Selected","fld":"vORGANISATIONID_SELECTED"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONBLOCK.CLOSE",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV87ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtManagerGivenName_Visible","ctrl":"MANAGERGIVENNAME","prop":"Visible"},{"av":"edtManagerLastName_Visible","ctrl":"MANAGERLASTNAME","prop":"Visible"},{"av":"edtManagerEmail_Visible","ctrl":"MANAGEREMAIL","prop":"Visible"},{"av":"edtManagerPhone_Visible","ctrl":"MANAGERPHONE","prop":"Visible"},{"av":"cmbManagerGender"},{"av":"edtavManagerisactive_Visible","ctrl":"vMANAGERISACTIVE","prop":"Visible"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavManagerisactive_Columnheaderclass","ctrl":"vMANAGERISACTIVE","prop":"Columnheaderclass"},{"av":"AV99IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV100IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"ctrl":"BTNINSERTMANAGER","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK.CLOSE","""{"handler":"E193E2","iparms":[{"av":"Dvelop_confirmpanel_useractionunblock_Result","ctrl":"DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK","prop":"Result"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV61OrganisationId","fld":"vORGANISATIONID"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV87ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV104Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFManagerGivenName","fld":"vTFMANAGERGIVENNAME"},{"av":"AV21TFManagerGivenName_Sel","fld":"vTFMANAGERGIVENNAME_SEL"},{"av":"AV22TFManagerLastName","fld":"vTFMANAGERLASTNAME"},{"av":"AV23TFManagerLastName_Sel","fld":"vTFMANAGERLASTNAME_SEL"},{"av":"AV26TFManagerEmail","fld":"vTFMANAGEREMAIL"},{"av":"AV27TFManagerEmail_Sel","fld":"vTFMANAGEREMAIL_SEL"},{"av":"AV28TFManagerPhone","fld":"vTFMANAGERPHONE"},{"av":"AV29TFManagerPhone_Sel","fld":"vTFMANAGERPHONE_SEL"},{"av":"AV31TFManagerGender_Sels","fld":"vTFMANAGERGENDER_SELS"},{"av":"AV51isMainManager","fld":"vISMAINMANAGER","hsh":true},{"av":"AV99IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV100IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV41IsAuthorized_ManagerGivenName","fld":"vISAUTHORIZED_MANAGERGIVENNAME","hsh":true},{"av":"AV57ManagerId_Selected","fld":"vMANAGERID_SELECTED"},{"av":"AV58OrganisationId_Selected","fld":"vORGANISATIONID_SELECTED"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_USERACTIONUNBLOCK.CLOSE",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV87ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtManagerGivenName_Visible","ctrl":"MANAGERGIVENNAME","prop":"Visible"},{"av":"edtManagerLastName_Visible","ctrl":"MANAGERLASTNAME","prop":"Visible"},{"av":"edtManagerEmail_Visible","ctrl":"MANAGEREMAIL","prop":"Visible"},{"av":"edtManagerPhone_Visible","ctrl":"MANAGERPHONE","prop":"Visible"},{"av":"cmbManagerGender"},{"av":"edtavManagerisactive_Visible","ctrl":"vMANAGERISACTIVE","prop":"Visible"},{"av":"AV38GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV39GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV40GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"edtavManagerisactive_Columnheaderclass","ctrl":"vMANAGERISACTIVE","prop":"Columnheaderclass"},{"av":"AV99IsAuthorized_UserActionBlock","fld":"vISAUTHORIZED_USERACTIONBLOCK","hsh":true},{"av":"AV100IsAuthorized_UserActionUnblock","fld":"vISAUTHORIZED_USERACTIONUNBLOCK","hsh":true},{"av":"AV43IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV45IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV47IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"ctrl":"BTNINSERTMANAGER","prop":"Visible"},{"ctrl":"BTNSUBSCRIPTIONS","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("'DOINSERTMANAGER'","""{"handler":"E203E2","iparms":[{"av":"A21ManagerId","fld":"MANAGERID","hsh":true}]}""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","""{"handler":"E143E2","iparms":[]""");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("VALID_MANAGERGIVENNAME","""{"handler":"Valid_Managergivenname","iparms":[]}""");
         setEventMetadata("VALID_MANAGERLASTNAME","""{"handler":"Valid_Managerlastname","iparms":[]}""");
         setEventMetadata("VALID_MANAGEREMAIL","""{"handler":"Valid_Manageremail","iparms":[]}""");
         setEventMetadata("VALID_MANAGERPHONE","""{"handler":"Valid_Managerphone","iparms":[]}""");
         setEventMetadata("VALID_MANAGERGENDER","""{"handler":"Valid_Managergender","iparms":[]}""");
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
         Dvelop_confirmpanel_resendinvite_Result = "";
         AV8HTTPRequest = new GxHttpRequest( context);
         Dvelop_confirmpanel_useractionblock_Result = "";
         Dvelop_confirmpanel_useractionunblock_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV61OrganisationId = Guid.Empty;
         AV87ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV104Pgmname = "";
         AV15FilterFullText = "";
         AV20TFManagerGivenName = "";
         AV21TFManagerGivenName_Sel = "";
         AV22TFManagerLastName = "";
         AV23TFManagerLastName_Sel = "";
         AV26TFManagerEmail = "";
         AV27TFManagerEmail_Sel = "";
         AV28TFManagerPhone = "";
         AV29TFManagerPhone_Sel = "";
         AV31TFManagerGender_Sels = new GxSimpleCollection<string>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV17ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV40GridAppliedFilters = "";
         AV34DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV30TFManagerGender_SelsJson = "";
         AV97ErrDescription = "";
         AV57ManagerId_Selected = Guid.Empty;
         AV58OrganisationId_Selected = Guid.Empty;
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
         bttBtninsertmanager_Jsonclick = "";
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
         A21ManagerId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         A22ManagerGivenName = "";
         A23ManagerLastName = "";
         A24ManagerInitials = "";
         A25ManagerEmail = "";
         A26ManagerPhone = "";
         A357ManagerPhoneCode = "";
         A358ManagerPhoneNumber = "";
         A27ManagerGender = "";
         A28ManagerGAMGUID = "";
         AV60ManagerIsActive = "";
         AV105Trn_managerwwds_1_filterfulltext = "";
         AV106Trn_managerwwds_2_tfmanagergivenname = "";
         AV107Trn_managerwwds_3_tfmanagergivenname_sel = "";
         AV108Trn_managerwwds_4_tfmanagerlastname = "";
         AV109Trn_managerwwds_5_tfmanagerlastname_sel = "";
         AV110Trn_managerwwds_6_tfmanageremail = "";
         AV111Trn_managerwwds_7_tfmanageremail_sel = "";
         AV112Trn_managerwwds_8_tfmanagerphone = "";
         AV113Trn_managerwwds_9_tfmanagerphone_sel = "";
         AV114Trn_managerwwds_10_tfmanagergender_sels = new GxSimpleCollection<string>();
         lV106Trn_managerwwds_2_tfmanagergivenname = "";
         lV108Trn_managerwwds_4_tfmanagerlastname = "";
         lV110Trn_managerwwds_6_tfmanageremail = "";
         lV112Trn_managerwwds_8_tfmanagerphone = "";
         H003E2_A365ManagerIsActive = new bool[] {false} ;
         H003E2_A332ManagerIsMainManager = new bool[] {false} ;
         H003E2_A28ManagerGAMGUID = new string[] {""} ;
         H003E2_A27ManagerGender = new string[] {""} ;
         H003E2_A358ManagerPhoneNumber = new string[] {""} ;
         H003E2_A357ManagerPhoneCode = new string[] {""} ;
         H003E2_A26ManagerPhone = new string[] {""} ;
         H003E2_A25ManagerEmail = new string[] {""} ;
         H003E2_A24ManagerInitials = new string[] {""} ;
         H003E2_A23ManagerLastName = new string[] {""} ;
         H003E2_A22ManagerGivenName = new string[] {""} ;
         H003E2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H003E2_A21ManagerId = new Guid[] {Guid.Empty} ;
         H003E3_A365ManagerIsActive = new bool[] {false} ;
         H003E3_A332ManagerIsMainManager = new bool[] {false} ;
         H003E3_A28ManagerGAMGUID = new string[] {""} ;
         H003E3_A27ManagerGender = new string[] {""} ;
         H003E3_A358ManagerPhoneNumber = new string[] {""} ;
         H003E3_A357ManagerPhoneCode = new string[] {""} ;
         H003E3_A26ManagerPhone = new string[] {""} ;
         H003E3_A25ManagerEmail = new string[] {""} ;
         H003E3_A24ManagerInitials = new string[] {""} ;
         H003E3_A23ManagerLastName = new string[] {""} ;
         H003E3_A22ManagerGivenName = new string[] {""} ;
         H003E3_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H003E3_A21ManagerId = new Guid[] {Guid.Empty} ;
         AV94successmsg = "";
         AV95websession = context.GetSession();
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_guid1 = Guid.Empty;
         AV35GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV36GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV16Session = context.GetSession();
         AV85ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV18ManageFiltersXml = "";
         AV86UserCustomValue = "";
         AV88ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV62ManagerGuid_Selected = "";
         AV63baseUrl = "";
         AV59GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV93ActivactionKey = "";
         AV96GAMError = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV98GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV102Trn_Manager = new SdtTrn_Manager(context);
         AV69Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV103MessageItem = new GeneXus.Utils.SdtMessages_Message(context);
         AV12GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char4 = "";
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         AV49AuxText = "";
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         ucDvelop_confirmpanel_useractionunblock = new GXUserControl();
         ucDvelop_confirmpanel_useractionblock = new GXUserControl();
         ucDvelop_confirmpanel_resendinvite = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         gxphoneLink = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_managerww__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_managerww__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_managerww__default(),
            new Object[][] {
                new Object[] {
               H003E2_A365ManagerIsActive, H003E2_A332ManagerIsMainManager, H003E2_A28ManagerGAMGUID, H003E2_A27ManagerGender, H003E2_A358ManagerPhoneNumber, H003E2_A357ManagerPhoneCode, H003E2_A26ManagerPhone, H003E2_A25ManagerEmail, H003E2_A24ManagerInitials, H003E2_A23ManagerLastName,
               H003E2_A22ManagerGivenName, H003E2_A11OrganisationId, H003E2_A21ManagerId
               }
               , new Object[] {
               H003E3_A365ManagerIsActive, H003E3_A332ManagerIsMainManager, H003E3_A28ManagerGAMGUID, H003E3_A27ManagerGender, H003E3_A358ManagerPhoneNumber, H003E3_A357ManagerPhoneCode, H003E3_A26ManagerPhone, H003E3_A25ManagerEmail, H003E3_A24ManagerInitials, H003E3_A23ManagerLastName,
               H003E3_A22ManagerGivenName, H003E3_A11OrganisationId, H003E3_A21ManagerId
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV104Pgmname = "Trn_ManagerWW";
         /* GeneXus formulas. */
         AV104Pgmname = "Trn_ManagerWW";
         edtavManagerisactive_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV19ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV82ActionGroup ;
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
      private int bttBtninsertmanager_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavManagerisactive_Enabled ;
      private int AV114Trn_managerwwds_10_tfmanagergender_sels_Count ;
      private int edtManagerId_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int edtManagerGivenName_Enabled ;
      private int edtManagerLastName_Enabled ;
      private int edtManagerInitials_Enabled ;
      private int edtManagerEmail_Enabled ;
      private int edtManagerPhone_Enabled ;
      private int edtManagerPhoneCode_Enabled ;
      private int edtManagerPhoneNumber_Enabled ;
      private int edtManagerGAMGUID_Enabled ;
      private int edtManagerGivenName_Visible ;
      private int edtManagerLastName_Visible ;
      private int edtManagerEmail_Visible ;
      private int edtManagerPhone_Visible ;
      private int edtavManagerisactive_Visible ;
      private int AV37PageToGo ;
      private int AV115GXV1 ;
      private int AV116GXV2 ;
      private int AV117GXV3 ;
      private int AV118GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV38GridCurrentPage ;
      private long AV39GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Dvelop_confirmpanel_resendinvite_Result ;
      private string Dvelop_confirmpanel_useractionblock_Result ;
      private string Dvelop_confirmpanel_useractionunblock_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_39_idx="0001" ;
      private string AV104Pgmname ;
      private string AV28TFManagerPhone ;
      private string AV29TFManagerPhone_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
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
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Dvelop_confirmpanel_resendinvite_Title ;
      private string Dvelop_confirmpanel_resendinvite_Confirmationtext ;
      private string Dvelop_confirmpanel_resendinvite_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_resendinvite_Nobuttoncaption ;
      private string Dvelop_confirmpanel_resendinvite_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_resendinvite_Yesbuttonposition ;
      private string Dvelop_confirmpanel_resendinvite_Confirmtype ;
      private string Dvelop_confirmpanel_useractionblock_Title ;
      private string Dvelop_confirmpanel_useractionblock_Confirmationtext ;
      private string Dvelop_confirmpanel_useractionblock_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_useractionblock_Nobuttoncaption ;
      private string Dvelop_confirmpanel_useractionblock_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_useractionblock_Yesbuttonposition ;
      private string Dvelop_confirmpanel_useractionblock_Confirmtype ;
      private string Dvelop_confirmpanel_useractionunblock_Title ;
      private string Dvelop_confirmpanel_useractionunblock_Confirmationtext ;
      private string Dvelop_confirmpanel_useractionunblock_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_useractionunblock_Nobuttoncaption ;
      private string Dvelop_confirmpanel_useractionunblock_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_useractionunblock_Yesbuttonposition ;
      private string Dvelop_confirmpanel_useractionunblock_Confirmtype ;
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
      private string bttBtninsertmanager_Internalname ;
      private string bttBtninsertmanager_Jsonclick ;
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
      private string edtManagerId_Internalname ;
      private string edtOrganisationId_Internalname ;
      private string edtManagerGivenName_Internalname ;
      private string edtManagerLastName_Internalname ;
      private string A24ManagerInitials ;
      private string edtManagerInitials_Internalname ;
      private string edtManagerEmail_Internalname ;
      private string A26ManagerPhone ;
      private string edtManagerPhone_Internalname ;
      private string edtManagerPhoneCode_Internalname ;
      private string edtManagerPhoneNumber_Internalname ;
      private string cmbManagerGender_Internalname ;
      private string edtManagerGAMGUID_Internalname ;
      private string chkManagerIsMainManager_Internalname ;
      private string chkManagerIsActive_Internalname ;
      private string AV60ManagerIsActive ;
      private string edtavManagerisactive_Internalname ;
      private string cmbavActiongroup_Internalname ;
      private string AV112Trn_managerwwds_8_tfmanagerphone ;
      private string AV113Trn_managerwwds_9_tfmanagerphone_sel ;
      private string lV112Trn_managerwwds_8_tfmanagerphone ;
      private string edtavManagerisactive_Columnheaderclass ;
      private string cmbavActiongroup_Class ;
      private string edtManagerGivenName_Link ;
      private string GXEncryptionTmp ;
      private string edtavManagerisactive_Columnclass ;
      private string GXt_char4 ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string tblTabledvelop_confirmpanel_useractionunblock_Internalname ;
      private string Dvelop_confirmpanel_useractionunblock_Internalname ;
      private string tblTabledvelop_confirmpanel_useractionblock_Internalname ;
      private string Dvelop_confirmpanel_useractionblock_Internalname ;
      private string tblTabledvelop_confirmpanel_resendinvite_Internalname ;
      private string Dvelop_confirmpanel_resendinvite_Internalname ;
      private string sGXsfl_39_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtManagerId_Jsonclick ;
      private string edtOrganisationId_Jsonclick ;
      private string edtManagerGivenName_Jsonclick ;
      private string edtManagerLastName_Jsonclick ;
      private string edtManagerInitials_Jsonclick ;
      private string edtManagerEmail_Jsonclick ;
      private string gxphoneLink ;
      private string edtManagerPhone_Jsonclick ;
      private string edtManagerPhoneCode_Jsonclick ;
      private string edtManagerPhoneNumber_Jsonclick ;
      private string GXCCtl ;
      private string cmbManagerGender_Jsonclick ;
      private string edtManagerGAMGUID_Jsonclick ;
      private string edtavManagerisactive_Jsonclick ;
      private string cmbavActiongroup_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV51isMainManager ;
      private bool AV99IsAuthorized_UserActionBlock ;
      private bool AV100IsAuthorized_UserActionUnblock ;
      private bool AV43IsAuthorized_Display ;
      private bool AV45IsAuthorized_Update ;
      private bool AV47IsAuthorized_Delete ;
      private bool AV41IsAuthorized_ManagerGivenName ;
      private bool AV64isSent ;
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
      private bool A332ManagerIsMainManager ;
      private bool A365ManagerIsActive ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV89IsGAMActive ;
      private bool AV90IsGAMBlocked ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV83IsAuthorized_InsertManager ;
      private bool GXt_boolean2 ;
      private string AV30TFManagerGender_SelsJson ;
      private string AV85ColumnsSelectorXML ;
      private string AV18ManageFiltersXml ;
      private string AV86UserCustomValue ;
      private string AV93ActivactionKey ;
      private string AV15FilterFullText ;
      private string AV20TFManagerGivenName ;
      private string AV21TFManagerGivenName_Sel ;
      private string AV22TFManagerLastName ;
      private string AV23TFManagerLastName_Sel ;
      private string AV26TFManagerEmail ;
      private string AV27TFManagerEmail_Sel ;
      private string AV40GridAppliedFilters ;
      private string AV97ErrDescription ;
      private string A22ManagerGivenName ;
      private string A23ManagerLastName ;
      private string A25ManagerEmail ;
      private string A357ManagerPhoneCode ;
      private string A358ManagerPhoneNumber ;
      private string A27ManagerGender ;
      private string A28ManagerGAMGUID ;
      private string AV105Trn_managerwwds_1_filterfulltext ;
      private string AV106Trn_managerwwds_2_tfmanagergivenname ;
      private string AV107Trn_managerwwds_3_tfmanagergivenname_sel ;
      private string AV108Trn_managerwwds_4_tfmanagerlastname ;
      private string AV109Trn_managerwwds_5_tfmanagerlastname_sel ;
      private string AV110Trn_managerwwds_6_tfmanageremail ;
      private string AV111Trn_managerwwds_7_tfmanageremail_sel ;
      private string lV106Trn_managerwwds_2_tfmanagergivenname ;
      private string lV108Trn_managerwwds_4_tfmanagerlastname ;
      private string lV110Trn_managerwwds_6_tfmanageremail ;
      private string AV94successmsg ;
      private string AV62ManagerGuid_Selected ;
      private string AV63baseUrl ;
      private string AV49AuxText ;
      private Guid AV61OrganisationId ;
      private Guid AV57ManagerId_Selected ;
      private Guid AV58OrganisationId_Selected ;
      private Guid A21ManagerId ;
      private Guid A11OrganisationId ;
      private Guid GXt_guid1 ;
      private IGxSession AV95websession ;
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
      private GXUserControl ucDvelop_confirmpanel_useractionunblock ;
      private GXUserControl ucDvelop_confirmpanel_useractionblock ;
      private GXUserControl ucDvelop_confirmpanel_resendinvite ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbManagerGender ;
      private GXCheckbox chkManagerIsMainManager ;
      private GXCheckbox chkManagerIsActive ;
      private GXCombobox cmbavActiongroup ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV87ColumnsSelector ;
      private GxSimpleCollection<string> AV31TFManagerGender_Sels ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV17ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV34DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV11GridState ;
      private GxSimpleCollection<string> AV114Trn_managerwwds_10_tfmanagergender_sels ;
      private IDataStoreProvider pr_default ;
      private bool[] H003E2_A365ManagerIsActive ;
      private bool[] H003E2_A332ManagerIsMainManager ;
      private string[] H003E2_A28ManagerGAMGUID ;
      private string[] H003E2_A27ManagerGender ;
      private string[] H003E2_A358ManagerPhoneNumber ;
      private string[] H003E2_A357ManagerPhoneCode ;
      private string[] H003E2_A26ManagerPhone ;
      private string[] H003E2_A25ManagerEmail ;
      private string[] H003E2_A24ManagerInitials ;
      private string[] H003E2_A23ManagerLastName ;
      private string[] H003E2_A22ManagerGivenName ;
      private Guid[] H003E2_A11OrganisationId ;
      private Guid[] H003E2_A21ManagerId ;
      private bool[] H003E3_A365ManagerIsActive ;
      private bool[] H003E3_A332ManagerIsMainManager ;
      private string[] H003E3_A28ManagerGAMGUID ;
      private string[] H003E3_A27ManagerGender ;
      private string[] H003E3_A358ManagerPhoneNumber ;
      private string[] H003E3_A357ManagerPhoneCode ;
      private string[] H003E3_A26ManagerPhone ;
      private string[] H003E3_A25ManagerEmail ;
      private string[] H003E3_A24ManagerInitials ;
      private string[] H003E3_A23ManagerLastName ;
      private string[] H003E3_A22ManagerGivenName ;
      private Guid[] H003E3_A11OrganisationId ;
      private Guid[] H003E3_A21ManagerId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV35GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV36GAMErrors ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons3 ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV88ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item5 ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV59GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV96GAMError ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV98GAMErrorCollection ;
      private SdtTrn_Manager AV102Trn_Manager ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV69Messages ;
      private GeneXus.Utils.SdtMessages_Message AV103MessageItem ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_managerww__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_managerww__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_managerww__default : DataStoreHelperBase, IDataStoreHelper
{
   protected Object[] conditional_H003E2( IGxContext context ,
                                          string A27ManagerGender ,
                                          GxSimpleCollection<string> AV114Trn_managerwwds_10_tfmanagergender_sels ,
                                          string AV107Trn_managerwwds_3_tfmanagergivenname_sel ,
                                          string AV106Trn_managerwwds_2_tfmanagergivenname ,
                                          string AV109Trn_managerwwds_5_tfmanagerlastname_sel ,
                                          string AV108Trn_managerwwds_4_tfmanagerlastname ,
                                          string AV111Trn_managerwwds_7_tfmanageremail_sel ,
                                          string AV110Trn_managerwwds_6_tfmanageremail ,
                                          string AV113Trn_managerwwds_9_tfmanagerphone_sel ,
                                          string AV112Trn_managerwwds_8_tfmanagerphone ,
                                          int AV114Trn_managerwwds_10_tfmanagergender_sels_Count ,
                                          string A22ManagerGivenName ,
                                          string A23ManagerLastName ,
                                          string A25ManagerEmail ,
                                          string A26ManagerPhone ,
                                          short AV13OrderedBy ,
                                          bool AV14OrderedDsc ,
                                          string AV105Trn_managerwwds_1_filterfulltext ,
                                          Guid A11OrganisationId ,
                                          Guid AV61OrganisationId )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int10 = new short[9];
      Object[] GXv_Object11 = new Object[2];
      scmdbuf = "SELECT ManagerIsActive, ManagerIsMainManager, ManagerGAMGUID, ManagerGender, ManagerPhoneNumber, ManagerPhoneCode, ManagerPhone, ManagerEmail, ManagerInitials, ManagerLastName, ManagerGivenName, OrganisationId, ManagerId FROM Trn_Manager";
      AddWhere(sWhereString, "(OrganisationId = :AV61OrganisationId)");
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Trn_managerwwds_3_tfmanagergivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Trn_managerwwds_2_tfmanagergivenname)) ) )
      {
         AddWhere(sWhereString, "(ManagerGivenName like :lV106Trn_managerwwds_2_tfmanagergivenname)");
      }
      else
      {
         GXv_int10[1] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Trn_managerwwds_3_tfmanagergivenname_sel)) && ! ( StringUtil.StrCmp(AV107Trn_managerwwds_3_tfmanagergivenname_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(ManagerGivenName = ( :AV107Trn_managerwwds_3_tfmanagergivenname_sel))");
      }
      else
      {
         GXv_int10[2] = 1;
      }
      if ( StringUtil.StrCmp(AV107Trn_managerwwds_3_tfmanagergivenname_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerGivenName))=0))");
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Trn_managerwwds_5_tfmanagerlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Trn_managerwwds_4_tfmanagerlastname)) ) )
      {
         AddWhere(sWhereString, "(ManagerLastName like :lV108Trn_managerwwds_4_tfmanagerlastname)");
      }
      else
      {
         GXv_int10[3] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Trn_managerwwds_5_tfmanagerlastname_sel)) && ! ( StringUtil.StrCmp(AV109Trn_managerwwds_5_tfmanagerlastname_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(ManagerLastName = ( :AV109Trn_managerwwds_5_tfmanagerlastname_sel))");
      }
      else
      {
         GXv_int10[4] = 1;
      }
      if ( StringUtil.StrCmp(AV109Trn_managerwwds_5_tfmanagerlastname_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerLastName))=0))");
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Trn_managerwwds_7_tfmanageremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Trn_managerwwds_6_tfmanageremail)) ) )
      {
         AddWhere(sWhereString, "(ManagerEmail like :lV110Trn_managerwwds_6_tfmanageremail)");
      }
      else
      {
         GXv_int10[5] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Trn_managerwwds_7_tfmanageremail_sel)) && ! ( StringUtil.StrCmp(AV111Trn_managerwwds_7_tfmanageremail_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(ManagerEmail = ( :AV111Trn_managerwwds_7_tfmanageremail_sel))");
      }
      else
      {
         GXv_int10[6] = 1;
      }
      if ( StringUtil.StrCmp(AV111Trn_managerwwds_7_tfmanageremail_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerEmail))=0))");
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Trn_managerwwds_9_tfmanagerphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Trn_managerwwds_8_tfmanagerphone)) ) )
      {
         AddWhere(sWhereString, "(ManagerPhone like :lV112Trn_managerwwds_8_tfmanagerphone)");
      }
      else
      {
         GXv_int10[7] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Trn_managerwwds_9_tfmanagerphone_sel)) && ! ( StringUtil.StrCmp(AV113Trn_managerwwds_9_tfmanagerphone_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(ManagerPhone = ( :AV113Trn_managerwwds_9_tfmanagerphone_sel))");
      }
      else
      {
         GXv_int10[8] = 1;
      }
      if ( StringUtil.StrCmp(AV113Trn_managerwwds_9_tfmanagerphone_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerPhone))=0))");
      }
      if ( AV114Trn_managerwwds_10_tfmanagergender_sels_Count > 0 )
      {
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV114Trn_managerwwds_10_tfmanagergender_sels, "ManagerGender IN (", ")")+")");
      }
      scmdbuf += sWhereString;
      if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
      {
         scmdbuf += " ORDER BY ManagerGivenName, ManagerId, OrganisationId";
      }
      else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
      {
         scmdbuf += " ORDER BY ManagerGivenName DESC, ManagerId, OrganisationId";
      }
      else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
      {
         scmdbuf += " ORDER BY ManagerLastName, ManagerId, OrganisationId";
      }
      else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
      {
         scmdbuf += " ORDER BY ManagerLastName DESC, ManagerId, OrganisationId";
      }
      else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
      {
         scmdbuf += " ORDER BY ManagerEmail, ManagerId, OrganisationId";
      }
      else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
      {
         scmdbuf += " ORDER BY ManagerEmail DESC, ManagerId, OrganisationId";
      }
      else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
      {
         scmdbuf += " ORDER BY ManagerPhone, ManagerId, OrganisationId";
      }
      else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
      {
         scmdbuf += " ORDER BY ManagerPhone DESC, ManagerId, OrganisationId";
      }
      else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
      {
         scmdbuf += " ORDER BY ManagerGender, ManagerId, OrganisationId";
      }
      else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
      {
         scmdbuf += " ORDER BY ManagerGender DESC, ManagerId, OrganisationId";
      }
      GXv_Object11[0] = scmdbuf;
      GXv_Object11[1] = GXv_int10;
      return GXv_Object11 ;
   }

   protected Object[] conditional_H003E3( IGxContext context ,
                                          string A27ManagerGender ,
                                          GxSimpleCollection<string> AV114Trn_managerwwds_10_tfmanagergender_sels ,
                                          string AV107Trn_managerwwds_3_tfmanagergivenname_sel ,
                                          string AV106Trn_managerwwds_2_tfmanagergivenname ,
                                          string AV109Trn_managerwwds_5_tfmanagerlastname_sel ,
                                          string AV108Trn_managerwwds_4_tfmanagerlastname ,
                                          string AV111Trn_managerwwds_7_tfmanageremail_sel ,
                                          string AV110Trn_managerwwds_6_tfmanageremail ,
                                          string AV113Trn_managerwwds_9_tfmanagerphone_sel ,
                                          string AV112Trn_managerwwds_8_tfmanagerphone ,
                                          int AV114Trn_managerwwds_10_tfmanagergender_sels_Count ,
                                          string A22ManagerGivenName ,
                                          string A23ManagerLastName ,
                                          string A25ManagerEmail ,
                                          string A26ManagerPhone ,
                                          short AV13OrderedBy ,
                                          bool AV14OrderedDsc ,
                                          string AV105Trn_managerwwds_1_filterfulltext ,
                                          Guid A11OrganisationId ,
                                          Guid AV61OrganisationId )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int12 = new short[9];
      Object[] GXv_Object13 = new Object[2];
      scmdbuf = "SELECT ManagerIsActive, ManagerIsMainManager, ManagerGAMGUID, ManagerGender, ManagerPhoneNumber, ManagerPhoneCode, ManagerPhone, ManagerEmail, ManagerInitials, ManagerLastName, ManagerGivenName, OrganisationId, ManagerId FROM Trn_Manager";
      AddWhere(sWhereString, "(OrganisationId = :AV61OrganisationId)");
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Trn_managerwwds_3_tfmanagergivenname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Trn_managerwwds_2_tfmanagergivenname)) ) )
      {
         AddWhere(sWhereString, "(ManagerGivenName like :lV106Trn_managerwwds_2_tfmanagergivenname)");
      }
      else
      {
         GXv_int12[1] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Trn_managerwwds_3_tfmanagergivenname_sel)) && ! ( StringUtil.StrCmp(AV107Trn_managerwwds_3_tfmanagergivenname_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(ManagerGivenName = ( :AV107Trn_managerwwds_3_tfmanagergivenname_sel))");
      }
      else
      {
         GXv_int12[2] = 1;
      }
      if ( StringUtil.StrCmp(AV107Trn_managerwwds_3_tfmanagergivenname_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerGivenName))=0))");
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Trn_managerwwds_5_tfmanagerlastname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Trn_managerwwds_4_tfmanagerlastname)) ) )
      {
         AddWhere(sWhereString, "(ManagerLastName like :lV108Trn_managerwwds_4_tfmanagerlastname)");
      }
      else
      {
         GXv_int12[3] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Trn_managerwwds_5_tfmanagerlastname_sel)) && ! ( StringUtil.StrCmp(AV109Trn_managerwwds_5_tfmanagerlastname_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(ManagerLastName = ( :AV109Trn_managerwwds_5_tfmanagerlastname_sel))");
      }
      else
      {
         GXv_int12[4] = 1;
      }
      if ( StringUtil.StrCmp(AV109Trn_managerwwds_5_tfmanagerlastname_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerLastName))=0))");
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Trn_managerwwds_7_tfmanageremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Trn_managerwwds_6_tfmanageremail)) ) )
      {
         AddWhere(sWhereString, "(ManagerEmail like :lV110Trn_managerwwds_6_tfmanageremail)");
      }
      else
      {
         GXv_int12[5] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Trn_managerwwds_7_tfmanageremail_sel)) && ! ( StringUtil.StrCmp(AV111Trn_managerwwds_7_tfmanageremail_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(ManagerEmail = ( :AV111Trn_managerwwds_7_tfmanageremail_sel))");
      }
      else
      {
         GXv_int12[6] = 1;
      }
      if ( StringUtil.StrCmp(AV111Trn_managerwwds_7_tfmanageremail_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerEmail))=0))");
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Trn_managerwwds_9_tfmanagerphone_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Trn_managerwwds_8_tfmanagerphone)) ) )
      {
         AddWhere(sWhereString, "(ManagerPhone like :lV112Trn_managerwwds_8_tfmanagerphone)");
      }
      else
      {
         GXv_int12[7] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Trn_managerwwds_9_tfmanagerphone_sel)) && ! ( StringUtil.StrCmp(AV113Trn_managerwwds_9_tfmanagerphone_sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(ManagerPhone = ( :AV113Trn_managerwwds_9_tfmanagerphone_sel))");
      }
      else
      {
         GXv_int12[8] = 1;
      }
      if ( StringUtil.StrCmp(AV113Trn_managerwwds_9_tfmanagerphone_sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ManagerPhone))=0))");
      }
      if ( AV114Trn_managerwwds_10_tfmanagergender_sels_Count > 0 )
      {
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV114Trn_managerwwds_10_tfmanagergender_sels, "ManagerGender IN (", ")")+")");
      }
      scmdbuf += sWhereString;
      if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
      {
         scmdbuf += " ORDER BY ManagerGivenName, ManagerId, OrganisationId";
      }
      else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
      {
         scmdbuf += " ORDER BY ManagerGivenName DESC, ManagerId, OrganisationId";
      }
      else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
      {
         scmdbuf += " ORDER BY ManagerLastName, ManagerId, OrganisationId";
      }
      else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
      {
         scmdbuf += " ORDER BY ManagerLastName DESC, ManagerId, OrganisationId";
      }
      else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
      {
         scmdbuf += " ORDER BY ManagerEmail, ManagerId, OrganisationId";
      }
      else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
      {
         scmdbuf += " ORDER BY ManagerEmail DESC, ManagerId, OrganisationId";
      }
      else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
      {
         scmdbuf += " ORDER BY ManagerPhone, ManagerId, OrganisationId";
      }
      else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
      {
         scmdbuf += " ORDER BY ManagerPhone DESC, ManagerId, OrganisationId";
      }
      else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
      {
         scmdbuf += " ORDER BY ManagerGender, ManagerId, OrganisationId";
      }
      else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
      {
         scmdbuf += " ORDER BY ManagerGender DESC, ManagerId, OrganisationId";
      }
      GXv_Object13[0] = scmdbuf;
      GXv_Object13[1] = GXv_int12;
      return GXv_Object13 ;
   }

   public override Object [] getDynamicStatement( int cursor ,
                                                  IGxContext context ,
                                                  Object [] dynConstraints )
   {
      switch ( cursor )
      {
            case 0 :
                  return conditional_H003E2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (Guid)dynConstraints[18] , (Guid)dynConstraints[19] );
            case 1 :
                  return conditional_H003E3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (Guid)dynConstraints[18] , (Guid)dynConstraints[19] );
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
       Object[] prmH003E2;
       prmH003E2 = new Object[] {
       new ParDef("AV61OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("lV106Trn_managerwwds_2_tfmanagergivenname",GXType.VarChar,100,0) ,
       new ParDef("AV107Trn_managerwwds_3_tfmanagergivenname_sel",GXType.VarChar,100,0) ,
       new ParDef("lV108Trn_managerwwds_4_tfmanagerlastname",GXType.VarChar,100,0) ,
       new ParDef("AV109Trn_managerwwds_5_tfmanagerlastname_sel",GXType.VarChar,100,0) ,
       new ParDef("lV110Trn_managerwwds_6_tfmanageremail",GXType.VarChar,100,0) ,
       new ParDef("AV111Trn_managerwwds_7_tfmanageremail_sel",GXType.VarChar,100,0) ,
       new ParDef("lV112Trn_managerwwds_8_tfmanagerphone",GXType.Char,20,0) ,
       new ParDef("AV113Trn_managerwwds_9_tfmanagerphone_sel",GXType.Char,20,0)
       };
       Object[] prmH003E3;
       prmH003E3 = new Object[] {
       new ParDef("AV61OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("lV106Trn_managerwwds_2_tfmanagergivenname",GXType.VarChar,100,0) ,
       new ParDef("AV107Trn_managerwwds_3_tfmanagergivenname_sel",GXType.VarChar,100,0) ,
       new ParDef("lV108Trn_managerwwds_4_tfmanagerlastname",GXType.VarChar,100,0) ,
       new ParDef("AV109Trn_managerwwds_5_tfmanagerlastname_sel",GXType.VarChar,100,0) ,
       new ParDef("lV110Trn_managerwwds_6_tfmanageremail",GXType.VarChar,100,0) ,
       new ParDef("AV111Trn_managerwwds_7_tfmanageremail_sel",GXType.VarChar,100,0) ,
       new ParDef("lV112Trn_managerwwds_8_tfmanagerphone",GXType.Char,20,0) ,
       new ParDef("AV113Trn_managerwwds_9_tfmanagerphone_sel",GXType.Char,20,0)
       };
       def= new CursorDef[] {
           new CursorDef("H003E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003E2,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H003E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003E3,11, GxCacheFrequency.OFF ,true,false )
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
             ((bool[]) buf[0])[0] = rslt.getBool(1);
             ((bool[]) buf[1])[0] = rslt.getBool(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getString(7, 20);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getString(9, 20);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((Guid[]) buf[11])[0] = rslt.getGuid(12);
             ((Guid[]) buf[12])[0] = rslt.getGuid(13);
             return;
          case 1 :
             ((bool[]) buf[0])[0] = rslt.getBool(1);
             ((bool[]) buf[1])[0] = rslt.getBool(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getString(7, 20);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getString(9, 20);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((Guid[]) buf[11])[0] = rslt.getGuid(12);
             ((Guid[]) buf[12])[0] = rslt.getGuid(13);
             return;
    }
 }

}

}
