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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_formww : GXDataArea
   {
      public wwp_formww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_formww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_WWPFormType ,
                           bool aP1_WWPFormIsForDynamicValidations )
      {
         this.AV44WWPFormType = aP0_WWPFormType;
         this.AV45WWPFormIsForDynamicValidations = aP1_WWPFormIsForDynamicValidations;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavGridactiongroup1 = new GXCombobox();
         cmbWWPFormType = new GXCombobox();
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
         AV17OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV18OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV19FilterFullText = GetPar( "FilterFullText");
         AV44WWPFormType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormType"), "."), 18, MidpointRounding.ToEven));
         AV45WWPFormIsForDynamicValidations = StringUtil.StrToBool( GetPar( "WWPFormIsForDynamicValidations"));
         AV29ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV24ColumnsSelector);
         AV67Pgmname = GetPar( "Pgmname");
         AV59OrganisationId = StringUtil.StrToGuid( GetPar( "OrganisationId"));
         AV35TFWWPFormReferenceName = GetPar( "TFWWPFormReferenceName");
         AV36TFWWPFormReferenceName_Sel = GetPar( "TFWWPFormReferenceName_Sel");
         AV37TFWWPFormTitle = GetPar( "TFWWPFormTitle");
         AV38TFWWPFormTitle_Sel = GetPar( "TFWWPFormTitle_Sel");
         AV61TFWWPFormDate = context.localUtil.ParseDTimeParm( GetPar( "TFWWPFormDate"));
         AV62TFWWPFormDate_To = context.localUtil.ParseDTimeParm( GetPar( "TFWWPFormDate_To"));
         AV51IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV41FilledOutForms = (short)(Math.Round(NumberUtil.Val( GetPar( "FilledOutForms"), "."), 18, MidpointRounding.ToEven));
         AV52IsAuthorized_Display = StringUtil.StrToBool( GetPar( "IsAuthorized_Display"));
         AV54IsAuthorized_FilledOutForms = StringUtil.StrToBool( GetPar( "IsAuthorized_FilledOutForms"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV56GeneralDynamicFormids);
         AV40WWPFormId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormId"), "."), 18, MidpointRounding.ToEven));
         AV58LocationId = StringUtil.StrToGuid( GetPar( "LocationId"));
         AV55IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         cmbWWPFormType.FromJSonString( GetNextPar( ));
         A240WWPFormType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormType"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV19FilterFullText, AV44WWPFormType, AV45WWPFormIsForDynamicValidations, AV29ManageFiltersExecutionStep, AV24ColumnsSelector, AV67Pgmname, AV59OrganisationId, AV35TFWWPFormReferenceName, AV36TFWWPFormReferenceName_Sel, AV37TFWWPFormTitle, AV38TFWWPFormTitle_Sel, AV61TFWWPFormDate, AV62TFWWPFormDate_To, AV51IsAuthorized_Update, AV41FilledOutForms, AV52IsAuthorized_Display, AV54IsAuthorized_FilledOutForms, AV56GeneralDynamicFormids, AV40WWPFormId, AV58LocationId, AV55IsAuthorized_Insert, A240WWPFormType) ;
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
            return "wwp_formww_Execute" ;
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
         PA1W2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1W2( ) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1918140), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 1918140), false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
         GXEncryptionTmp = "workwithplus.dynamicforms.wwp_formww.aspx"+UrlEncode(StringUtil.LTrimStr(AV44WWPFormType,1,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV45WWPFormIsForDynamicValidations));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_formww.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV67Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV67Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV59OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV59OrganisationId, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV51IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV51IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV52IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV52IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_FILLEDOUTFORMS", AV54IsAuthorized_FilledOutForms);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_FILLEDOUTFORMS", GetSecureSignedToken( "", AV54IsAuthorized_FilledOutForms, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGENERALDYNAMICFORMIDS", AV56GeneralDynamicFormids);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGENERALDYNAMICFORMIDS", AV56GeneralDynamicFormids);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vGENERALDYNAMICFORMIDS", GetSecureSignedToken( "", AV56GeneralDynamicFormids, context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV40WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vLOCATIONID", AV58LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV58LocationId, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV55IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV55IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A240WWPFormType), "9"), context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44WWPFormType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV44WWPFormType), "9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vWWPFORMISFORDYNAMICVALIDATIONS", AV45WWPFormIsForDynamicValidations);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMISFORDYNAMICVALIDATIONS", GetSecureSignedToken( "", AV45WWPFormIsForDynamicValidations, context));
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"WWP_FormWW");
         forbiddenHiddens.Add("WWPFormType", context.localUtil.Format( (decimal)(A240WWPFormType), "9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("workwithplus\\dynamicforms\\wwp_formww:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV18OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV19FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_39", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_39), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV27ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV27ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV34GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV30DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV30DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV24ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV24ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_WWPFORMDATEAUXDATE", context.localUtil.DToC( AV63DDO_WWPFormDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_WWPFORMDATEAUXDATETO", context.localUtil.DToC( AV64DDO_WWPFormDateAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV67Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV67Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV59OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV59OrganisationId, context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44WWPFormType), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV44WWPFormType), "9"), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV18OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMREFERENCENAME", AV35TFWWPFormReferenceName);
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMREFERENCENAME_SEL", AV36TFWWPFormReferenceName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMTITLE", AV37TFWWPFormTitle);
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMTITLE_SEL", AV38TFWWPFormTitle_Sel);
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMDATE", context.localUtil.TToC( AV61TFWWPFormDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFWWPFORMDATE_TO", context.localUtil.TToC( AV62TFWWPFormDate_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "vWWPFORMISFORDYNAMICVALIDATIONS", AV45WWPFormIsForDynamicValidations);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMISFORDYNAMICVALIDATIONS", GetSecureSignedToken( "", AV45WWPFormIsForDynamicValidations, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV51IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV51IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV52IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV52IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_FILLEDOUTFORMS", AV54IsAuthorized_FilledOutForms);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_FILLEDOUTFORMS", GetSecureSignedToken( "", AV54IsAuthorized_FilledOutForms, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGENERALDYNAMICFORMIDS", AV56GeneralDynamicFormids);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGENERALDYNAMICFORMIDS", AV56GeneralDynamicFormids);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vGENERALDYNAMICFORMIDS", GetSecureSignedToken( "", AV56GeneralDynamicFormids, context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV40WWPFormId), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV15GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV15GridState);
         }
         GxWebStd.gx_hidden_field( context, "vLOCATIONID", AV58LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV58LocationId, context));
         GxWebStd.gx_hidden_field( context, "vRESULTMSG", AV11ResultMsg);
         GxWebStd.gx_hidden_field( context, "vWWPFORMID_SELECTED", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42WWPFormId_Selected), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV55IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV55IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WWPFORMLATESTVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A219WWPFormLatestVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gamoauthtoken", StringUtil.RTrim( Ddo_grid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
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
         GxWebStd.gx_hidden_field( context, "IMPORTFORM_MODAL_Width", StringUtil.RTrim( Importform_modal_Width));
         GxWebStd.gx_hidden_field( context, "IMPORTFORM_MODAL_Title", StringUtil.RTrim( Importform_modal_Title));
         GxWebStd.gx_hidden_field( context, "IMPORTFORM_MODAL_Confirmtype", StringUtil.RTrim( Importform_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "IMPORTFORM_MODAL_Bodytype", StringUtil.RTrim( Importform_modal_Bodytype));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
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
            WE1W2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1W2( ) ;
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
         GXEncryptionTmp = "workwithplus.dynamicforms.wwp_formww.aspx"+UrlEncode(StringUtil.LTrimStr(AV44WWPFormType,1,0)) + "," + UrlEncode(StringUtil.BoolToStr(AV45WWPFormIsForDynamicValidations));
         return formatLink("workwithplus.dynamicforms.wwp_formww.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WorkWithPlus.DynamicForms.WWP_FormWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_DynamicForms", "") ;
      }

      protected void WB1W0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_FormWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_FormWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnimportform_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", context.GetMessage( "WWP_DF_ImportForm", ""), bttBtnimportform_Jsonclick, 7, context.GetMessage( "WWP_DF_ImportForm", ""), "", StyleString, ClassString, bttBtnimportform_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e111w1_client"+"'", TempTags, "", 2, "HLP_WorkWithPlus/DynamicForms/WWP_FormWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV27ManageFiltersData);
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV19FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV19FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_FormWW.htm");
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV32GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV33GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV34GridAppliedFilters);
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
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV30DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbWWPFormType, cmbWWPFormType_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0)), 1, cmbWWPFormType_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbWWPFormType.Visible, 0, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", "", "", true, 0, "HLP_WorkWithPlus/DynamicForms/WWP_FormWW.htm");
            cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            AssignProp("", false, cmbWWPFormType_Internalname, "Values", (string)(cmbWWPFormType.ToJavascriptSource()), true);
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV30DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV24ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            wb_table1_56_1W2( true) ;
         }
         else
         {
            wb_table1_56_1W2( false) ;
         }
         return  ;
      }

      protected void wb_table1_56_1W2e( bool wbgen )
      {
         if ( wbgen )
         {
            wb_table2_61_1W2( true) ;
         }
         else
         {
            wb_table2_61_1W2( false) ;
         }
         return  ;
      }

      protected void wb_table2_61_1W2e( bool wbgen )
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
               GxWebStd.gx_hidden_field( context, "W0068"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0068"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_39_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0068"+"");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_wwpformdateauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'" + sGXsfl_39_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_wwpformdateauxdatetext_Internalname, AV65DDO_WWPFormDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV65DDO_WWPFormDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_wwpformdateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WorkWithPlus/DynamicForms/WWP_FormWW.htm");
            /* User Defined Control */
            ucTfwwpformdate_rangepicker.SetProperty("Start Date", AV63DDO_WWPFormDateAuxDate);
            ucTfwwpformdate_rangepicker.SetProperty("End Date", AV64DDO_WWPFormDateAuxDateTo);
            ucTfwwpformdate_rangepicker.Render(context, "wwp.daterangepicker", Tfwwpformdate_rangepicker_Internalname, "TFWWPFORMDATE_RANGEPICKERContainer");
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

      protected void START1W2( )
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
         Form.Meta.addItem("description", context.GetMessage( "WWP_DynamicForms", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1W0( ) ;
      }

      protected void WS1W2( )
      {
         START1W2( ) ;
         EVT1W2( ) ;
      }

      protected void EVT1W2( )
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
                              E121W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E131W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E141W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E151W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E161W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_UDELETE.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Dvelop_confirmpanel_udelete.Close */
                              E171W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "IMPORTFORM_MODAL.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Importform_modal.Close */
                              E181W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "IMPORTFORM_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Importform_modal.Onloadcomponent */
                              E191W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E201W2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) )
                           {
                              nGXsfl_39_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
                              SubsflControlProps_392( ) ;
                              A206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A208WWPFormReferenceName = cgiGet( edtWWPFormReferenceName_Internalname);
                              A209WWPFormTitle = cgiGet( edtWWPFormTitle_Internalname);
                              A231WWPFormDate = context.localUtil.CToT( cgiGet( edtWWPFormDate_Internalname), 0);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavFilledoutforms_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFilledoutforms_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vFILLEDOUTFORMS");
                                 GX_FocusControl = edtavFilledoutforms_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV41FilledOutForms = 0;
                                 AssignAttri("", false, edtavFilledoutforms_Internalname, StringUtil.LTrimStr( (decimal)(AV41FilledOutForms), 4, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, context.localUtil.Format( (decimal)(AV41FilledOutForms), "ZZZ9"), context));
                              }
                              else
                              {
                                 AV41FilledOutForms = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavFilledoutforms_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavFilledoutforms_Internalname, StringUtil.LTrimStr( (decimal)(AV41FilledOutForms), 4, 0));
                                 GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, context.localUtil.Format( (decimal)(AV41FilledOutForms), "ZZZ9"), context));
                              }
                              cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                              cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                              AV39GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV39GridActionGroup1), 4, 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E211W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E221W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E231W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONGROUP1.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E241W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV17OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV18OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV19FilterFullText) != 0 )
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
                        if ( nCmpId == 68 )
                        {
                           OldWwpaux_wc = cgiGet( "W0068");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0068", "", sEvt);
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

      protected void WE1W2( )
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

      protected void PA1W2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_formww.aspx")), "workwithplus.dynamicforms.wwp_formww.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_formww.aspx")))) ;
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
                     AV44WWPFormType = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV44WWPFormType", StringUtil.Str( (decimal)(AV44WWPFormType), 1, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV44WWPFormType), "9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV45WWPFormIsForDynamicValidations = StringUtil.StrToBool( GetPar( "WWPFormIsForDynamicValidations"));
                        AssignAttri("", false, "AV45WWPFormIsForDynamicValidations", AV45WWPFormIsForDynamicValidations);
                        GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMISFORDYNAMICVALIDATIONS", GetSecureSignedToken( "", AV45WWPFormIsForDynamicValidations, context));
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
                                       short AV17OrderedBy ,
                                       bool AV18OrderedDsc ,
                                       string AV19FilterFullText ,
                                       short AV44WWPFormType ,
                                       bool AV45WWPFormIsForDynamicValidations ,
                                       short AV29ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV24ColumnsSelector ,
                                       string AV67Pgmname ,
                                       Guid AV59OrganisationId ,
                                       string AV35TFWWPFormReferenceName ,
                                       string AV36TFWWPFormReferenceName_Sel ,
                                       string AV37TFWWPFormTitle ,
                                       string AV38TFWWPFormTitle_Sel ,
                                       DateTime AV61TFWWPFormDate ,
                                       DateTime AV62TFWWPFormDate_To ,
                                       bool AV51IsAuthorized_Update ,
                                       short AV41FilledOutForms ,
                                       bool AV52IsAuthorized_Display ,
                                       bool AV54IsAuthorized_FilledOutForms ,
                                       GxSimpleCollection<short> AV56GeneralDynamicFormids ,
                                       short AV40WWPFormId ,
                                       Guid AV58LocationId ,
                                       bool AV55IsAuthorized_Insert ,
                                       short A240WWPFormType )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF1W2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"WWP_FormWW");
         forbiddenHiddens.Add("WWPFormType", context.localUtil.Format( (decimal)(A240WWPFormType), "9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("workwithplus\\dynamicforms\\wwp_formww:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV41FilledOutForms), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vFILLEDOUTFORMS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41FilledOutForms), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A209WWPFormTitle, "")), context));
         GxWebStd.gx_hidden_field( context, "WWPFORMTITLE", A209WWPFormTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMVERSIONNUMBER", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "WWPFORMVERSIONNUMBER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMREFERENCENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A208WWPFormReferenceName, "")), context));
         GxWebStd.gx_hidden_field( context, "WWPFORMREFERENCENAME", A208WWPFormReferenceName);
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
         if ( cmbWWPFormType.ItemCount > 0 )
         {
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A240WWPFormType), "9"), context));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPFormType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            AssignProp("", false, cmbWWPFormType_Internalname, "Values", cmbWWPFormType.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1W2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV67Pgmname = "WorkWithPlus.DynamicForms.WWP_FormWW";
         edtavFilledoutforms_Enabled = 0;
      }

      protected void RF1W2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 39;
         /* Execute user event: Refresh */
         E221W2 ();
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
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV19FilterFullText ,
                                                 AV36TFWWPFormReferenceName_Sel ,
                                                 AV35TFWWPFormReferenceName ,
                                                 AV38TFWWPFormTitle_Sel ,
                                                 AV37TFWWPFormTitle ,
                                                 AV61TFWWPFormDate ,
                                                 AV62TFWWPFormDate_To ,
                                                 AV44WWPFormType ,
                                                 AV45WWPFormIsForDynamicValidations ,
                                                 A208WWPFormReferenceName ,
                                                 A209WWPFormTitle ,
                                                 A231WWPFormDate ,
                                                 A242WWPFormIsForDynamicValidations ,
                                                 A40000GXC1 ,
                                                 AV17OrderedBy ,
                                                 AV18OrderedDsc ,
                                                 A240WWPFormType ,
                                                 A207WWPFormVersionNumber ,
                                                 A219WWPFormLatestVersionNumber } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV19FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV19FilterFullText), "%", "");
            lV19FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV19FilterFullText), "%", "");
            lV35TFWWPFormReferenceName = StringUtil.Concat( StringUtil.RTrim( AV35TFWWPFormReferenceName), "%", "");
            lV37TFWWPFormTitle = StringUtil.Concat( StringUtil.RTrim( AV37TFWWPFormTitle), "%", "");
            /* Using cursor H001W3 */
            pr_default.execute(0, new Object[] {AV44WWPFormType, lV19FilterFullText, lV19FilterFullText, lV35TFWWPFormReferenceName, AV36TFWWPFormReferenceName_Sel, lV37TFWWPFormTitle, AV38TFWWPFormTitle_Sel, AV61TFWWPFormDate, AV62TFWWPFormDate_To});
            nGXsfl_39_idx = 1;
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A242WWPFormIsForDynamicValidations = H001W3_A242WWPFormIsForDynamicValidations[0];
               A240WWPFormType = H001W3_A240WWPFormType[0];
               AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A240WWPFormType), "9"), context));
               A231WWPFormDate = H001W3_A231WWPFormDate[0];
               A209WWPFormTitle = H001W3_A209WWPFormTitle[0];
               A208WWPFormReferenceName = H001W3_A208WWPFormReferenceName[0];
               A207WWPFormVersionNumber = H001W3_A207WWPFormVersionNumber[0];
               A40000GXC1 = H001W3_A40000GXC1[0];
               n40000GXC1 = H001W3_n40000GXC1[0];
               A206WWPFormId = H001W3_A206WWPFormId[0];
               A40000GXC1 = H001W3_A40000GXC1[0];
               n40000GXC1 = H001W3_n40000GXC1[0];
               GXt_int1 = A219WWPFormLatestVersionNumber;
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getlatestversionofform(context ).execute(  A206WWPFormId, out  GXt_int1) ;
               A219WWPFormLatestVersionNumber = GXt_int1;
               AssignAttri("", false, "A219WWPFormLatestVersionNumber", StringUtil.LTrimStr( (decimal)(A219WWPFormLatestVersionNumber), 4, 0));
               if ( A207WWPFormVersionNumber == A219WWPFormLatestVersionNumber )
               {
                  /* Execute user event: Grid.Load */
                  E231W2 ();
               }
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 39;
            WB1W0( ) ;
         }
         bGXsfl_39_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1W2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV67Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV67Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORGANISATIONID", AV59OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV59OrganisationId, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV51IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV51IsAuthorized_Update, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, context.localUtil.Format( (decimal)(AV41FilledOutForms), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV52IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV52IsAuthorized_Display, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_FILLEDOUTFORMS", AV54IsAuthorized_FilledOutForms);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_FILLEDOUTFORMS", GetSecureSignedToken( "", AV54IsAuthorized_FilledOutForms, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGENERALDYNAMICFORMIDS", AV56GeneralDynamicFormids);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGENERALDYNAMICFORMIDS", AV56GeneralDynamicFormids);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vGENERALDYNAMICFORMIDS", GetSecureSignedToken( "", AV56GeneralDynamicFormids, context));
         GxWebStd.gx_hidden_field( context, "vWWPFORMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV40WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMID"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTITLE"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, StringUtil.RTrim( context.localUtil.Format( A209WWPFormTitle, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMVERSIONNUMBER"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMREFERENCENAME"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, StringUtil.RTrim( context.localUtil.Format( A208WWPFormReferenceName, "")), context));
         GxWebStd.gx_hidden_field( context, "vLOCATIONID", AV58LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV58LocationId, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV55IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV55IsAuthorized_Insert, context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(GRID_nFirstRecordOnPage+1) ;
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
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV19FilterFullText, AV44WWPFormType, AV45WWPFormIsForDynamicValidations, AV29ManageFiltersExecutionStep, AV24ColumnsSelector, AV67Pgmname, AV59OrganisationId, AV35TFWWPFormReferenceName, AV36TFWWPFormReferenceName_Sel, AV37TFWWPFormTitle, AV38TFWWPFormTitle_Sel, AV61TFWWPFormDate, AV62TFWWPFormDate_To, AV51IsAuthorized_Update, AV41FilledOutForms, AV52IsAuthorized_Display, AV54IsAuthorized_FilledOutForms, AV56GeneralDynamicFormids, AV40WWPFormId, AV58LocationId, AV55IsAuthorized_Insert, A240WWPFormType) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV19FilterFullText, AV44WWPFormType, AV45WWPFormIsForDynamicValidations, AV29ManageFiltersExecutionStep, AV24ColumnsSelector, AV67Pgmname, AV59OrganisationId, AV35TFWWPFormReferenceName, AV36TFWWPFormReferenceName_Sel, AV37TFWWPFormTitle, AV38TFWWPFormTitle_Sel, AV61TFWWPFormDate, AV62TFWWPFormDate_To, AV51IsAuthorized_Update, AV41FilledOutForms, AV52IsAuthorized_Display, AV54IsAuthorized_FilledOutForms, AV56GeneralDynamicFormids, AV40WWPFormId, AV58LocationId, AV55IsAuthorized_Insert, A240WWPFormType) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV19FilterFullText, AV44WWPFormType, AV45WWPFormIsForDynamicValidations, AV29ManageFiltersExecutionStep, AV24ColumnsSelector, AV67Pgmname, AV59OrganisationId, AV35TFWWPFormReferenceName, AV36TFWWPFormReferenceName_Sel, AV37TFWWPFormTitle, AV38TFWWPFormTitle_Sel, AV61TFWWPFormDate, AV62TFWWPFormDate_To, AV51IsAuthorized_Update, AV41FilledOutForms, AV52IsAuthorized_Display, AV54IsAuthorized_FilledOutForms, AV56GeneralDynamicFormids, AV40WWPFormId, AV58LocationId, AV55IsAuthorized_Insert, A240WWPFormType) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         subGrid_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV19FilterFullText, AV44WWPFormType, AV45WWPFormIsForDynamicValidations, AV29ManageFiltersExecutionStep, AV24ColumnsSelector, AV67Pgmname, AV59OrganisationId, AV35TFWWPFormReferenceName, AV36TFWWPFormReferenceName_Sel, AV37TFWWPFormTitle, AV38TFWWPFormTitle_Sel, AV61TFWWPFormDate, AV62TFWWPFormDate_To, AV51IsAuthorized_Update, AV41FilledOutForms, AV52IsAuthorized_Display, AV54IsAuthorized_FilledOutForms, AV56GeneralDynamicFormids, AV40WWPFormId, AV58LocationId, AV55IsAuthorized_Insert, A240WWPFormType) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV19FilterFullText, AV44WWPFormType, AV45WWPFormIsForDynamicValidations, AV29ManageFiltersExecutionStep, AV24ColumnsSelector, AV67Pgmname, AV59OrganisationId, AV35TFWWPFormReferenceName, AV36TFWWPFormReferenceName_Sel, AV37TFWWPFormTitle, AV38TFWWPFormTitle_Sel, AV61TFWWPFormDate, AV62TFWWPFormDate_To, AV51IsAuthorized_Update, AV41FilledOutForms, AV52IsAuthorized_Display, AV54IsAuthorized_FilledOutForms, AV56GeneralDynamicFormids, AV40WWPFormId, AV58LocationId, AV55IsAuthorized_Insert, A240WWPFormType) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV67Pgmname = "WorkWithPlus.DynamicForms.WWP_FormWW";
         edtavFilledoutforms_Enabled = 0;
         edtWWPFormId_Enabled = 0;
         edtWWPFormVersionNumber_Enabled = 0;
         edtWWPFormReferenceName_Enabled = 0;
         edtWWPFormTitle_Enabled = 0;
         edtWWPFormDate_Enabled = 0;
         cmbWWPFormType.Enabled = 0;
         AssignProp("", false, cmbWWPFormType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPFormType.Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1W0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E211W2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV27ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV30DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV24ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_39 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_39"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV32GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV33GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV34GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV63DDO_WWPFormDateAuxDate = context.localUtil.CToD( cgiGet( "vDDO_WWPFORMDATEAUXDATE"), 0);
            AV64DDO_WWPFormDateAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_WWPFORMDATEAUXDATETO"), 0);
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
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gamoauthtoken = cgiGet( "DDO_GRID_Gamoauthtoken");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
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
            Importform_modal_Width = cgiGet( "IMPORTFORM_MODAL_Width");
            Importform_modal_Title = cgiGet( "IMPORTFORM_MODAL_Title");
            Importform_modal_Confirmtype = cgiGet( "IMPORTFORM_MODAL_Confirmtype");
            Importform_modal_Bodytype = cgiGet( "IMPORTFORM_MODAL_Bodytype");
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
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvelop_confirmpanel_udelete_Result = cgiGet( "DVELOP_CONFIRMPANEL_UDELETE_Result");
            /* Read variables values. */
            AV19FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV19FilterFullText", AV19FilterFullText);
            cmbWWPFormType.Name = cmbWWPFormType_Internalname;
            cmbWWPFormType.CurrentValue = cgiGet( cmbWWPFormType_Internalname);
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormType_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A240WWPFormType), "9"), context));
            AV65DDO_WWPFormDateAuxDateText = cgiGet( edtavDdo_wwpformdateauxdatetext_Internalname);
            AssignAttri("", false, "AV65DDO_WWPFormDateAuxDateText", AV65DDO_WWPFormDateAuxDateText);
            /* Read subfile selected row values. */
            nGXsfl_39_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            if ( nGXsfl_39_idx > 0 )
            {
               A206WWPFormId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A207WWPFormVersionNumber = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPFormVersionNumber_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A208WWPFormReferenceName = cgiGet( edtWWPFormReferenceName_Internalname);
               A209WWPFormTitle = cgiGet( edtWWPFormTitle_Internalname);
               A231WWPFormDate = context.localUtil.CToT( cgiGet( edtWWPFormDate_Internalname));
               if ( ( ( context.localUtil.CToN( cgiGet( edtavFilledoutforms_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFilledoutforms_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vFILLEDOUTFORMS");
                  GX_FocusControl = edtavFilledoutforms_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  AV41FilledOutForms = 0;
                  AssignAttri("", false, edtavFilledoutforms_Internalname, StringUtil.LTrimStr( (decimal)(AV41FilledOutForms), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, context.localUtil.Format( (decimal)(AV41FilledOutForms), "ZZZ9"), context));
               }
               else
               {
                  AV41FilledOutForms = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavFilledoutforms_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, edtavFilledoutforms_Internalname, StringUtil.LTrimStr( (decimal)(AV41FilledOutForms), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, context.localUtil.Format( (decimal)(AV41FilledOutForms), "ZZZ9"), context));
               }
               cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
               cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
               AV39GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV39GridActionGroup1), 4, 0));
            }
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"WWP_FormWW");
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPFormType_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A240WWPFormType), "9"), context));
            forbiddenHiddens.Add("WWPFormType", context.localUtil.Format( (decimal)(A240WWPFormType), "9"));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("workwithplus\\dynamicforms\\wwp_formww:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV17OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV18OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV19FilterFullText) != 0 )
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
         E211W2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E211W2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_guid2 = AV58LocationId;
         new prc_getuserlocationid(context ).execute( out  GXt_guid2) ;
         AV58LocationId = GXt_guid2;
         AssignAttri("", false, "AV58LocationId", AV58LocationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vLOCATIONID", GetSecureSignedToken( "", AV58LocationId, context));
         GXt_guid2 = AV59OrganisationId;
         new prc_getuserorganisationid(context ).execute( out  GXt_guid2) ;
         AV59OrganisationId = GXt_guid2;
         AssignAttri("", false, "AV59OrganisationId", AV59OrganisationId.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vORGANISATIONID", GetSecureSignedToken( "", AV59OrganisationId, context));
         GXt_objcol_int3 = AV56GeneralDynamicFormids;
         new prc_generaldynamicform(context ).execute( out  GXt_objcol_int3) ;
         AV56GeneralDynamicFormids = GXt_objcol_int3;
         this.executeUsercontrolMethod("", false, "TFWWPFORMDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_wwpformdateauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV13HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV49GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV50GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV49GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = context.GetMessage( "WWP_DynamicForms", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         cmbWWPFormType.Visible = 0;
         AssignProp("", false, cmbWWPFormType_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbWWPFormType.Visible), 5, 0), true);
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
         if ( AV17OrderedBy < 1 )
         {
            AV17OrderedBy = 1;
            AssignAttri("", false, "AV17OrderedBy", StringUtil.LTrimStr( (decimal)(AV17OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4 = AV30DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4) ;
         AV30DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         if ( AV44WWPFormType == 1 )
         {
            if ( AV45WWPFormIsForDynamicValidations )
            {
               Form.Caption = context.GetMessage( "WWP_DynamicValidations", "");
               AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            }
            else
            {
               Form.Caption = context.GetMessage( "WWP_DynamicSections", "");
               AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            }
         }
      }

      protected void E221W2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV12WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV29ManageFiltersExecutionStep == 1 )
         {
            AV29ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV29ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV29ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV29ManageFiltersExecutionStep == 2 )
         {
            AV29ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV29ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV29ManageFiltersExecutionStep), 1, 0));
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
         if ( StringUtil.StrCmp(AV26Session.Get("WorkWithPlus.DynamicForms.WWP_FormWWColumnsSelector"), "") != 0 )
         {
            AV22ColumnsSelectorXML = AV26Session.Get("WorkWithPlus.DynamicForms.WWP_FormWWColumnsSelector");
            AV24ColumnsSelector.FromXml(AV22ColumnsSelectorXML, null, "", "");
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
         edtWWPFormReferenceName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWWPFormReferenceName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormReferenceName_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtWWPFormTitle_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWWPFormTitle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormTitle_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtWWPFormDate_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWWPFormDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPFormDate_Visible), 5, 0), !bGXsfl_39_Refreshing);
         edtavFilledoutforms_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavFilledoutforms_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFilledoutforms_Visible), 5, 0), !bGXsfl_39_Refreshing);
         AV32GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV32GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV32GridCurrentPage), 10, 0));
         AV33GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV33GridPageCount", StringUtil.LTrimStr( (decimal)(AV33GridPageCount), 10, 0));
         GXt_char5 = AV34GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV67Pgmname, out  GXt_char5) ;
         AV34GridAppliedFilters = GXt_char5;
         AssignAttri("", false, "AV34GridAppliedFilters", AV34GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ColumnsSelector", AV24ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ManageFiltersData", AV27ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
      }

      protected void E131W2( )
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
            AV31PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV31PageToGo) ;
         }
      }

      protected void E141W2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E151W2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV17OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17OrderedBy", StringUtil.LTrimStr( (decimal)(AV17OrderedBy), 4, 0));
            AV18OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV18OrderedDsc", AV18OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormReferenceName") == 0 )
            {
               AV35TFWWPFormReferenceName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV35TFWWPFormReferenceName", AV35TFWWPFormReferenceName);
               AV36TFWWPFormReferenceName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV36TFWWPFormReferenceName_Sel", AV36TFWWPFormReferenceName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormTitle") == 0 )
            {
               AV37TFWWPFormTitle = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV37TFWWPFormTitle", AV37TFWWPFormTitle);
               AV38TFWWPFormTitle_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV38TFWWPFormTitle_Sel", AV38TFWWPFormTitle_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPFormDate") == 0 )
            {
               AV61TFWWPFormDate = context.localUtil.CToT( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV61TFWWPFormDate", context.localUtil.TToC( AV61TFWWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV62TFWWPFormDate_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV62TFWWPFormDate_To", context.localUtil.TToC( AV62TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               if ( ! (DateTime.MinValue==AV62TFWWPFormDate_To) )
               {
                  AV62TFWWPFormDate_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV62TFWWPFormDate_To)), (short)(DateTimeUtil.Month( AV62TFWWPFormDate_To)), (short)(DateTimeUtil.Day( AV62TFWWPFormDate_To)), 23, 59, 59);
                  AssignAttri("", false, "AV62TFWWPFormDate_To", context.localUtil.TToC( AV62TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E231W2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         if ( AV44WWPFormType == 0 )
         {
            AV40WWPFormId = A206WWPFormId;
            AssignAttri("", false, "AV40WWPFormId", StringUtil.LTrimStr( (decimal)(AV40WWPFormId), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV40WWPFormId), "ZZZ9"), context));
            /* Execute user subroutine: 'COUNTFILLEDOUTFORMS' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavGridactiongroup1.removeAllItems();
         cmbavGridactiongroup1.addItem("0", ";fas fa-bars", 0);
         if ( AV51IsAuthorized_Update )
         {
            if ( (Guid.Empty==AV59OrganisationId) )
            {
               cmbavGridactiongroup1.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "Edit", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            }
         }
         if ( (Guid.Empty==AV59OrganisationId) && ( AV41FilledOutForms == 0 ) && ( AV44WWPFormType == 0 ) )
         {
            cmbavGridactiongroup1.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fas fa-xmark", "", "", "", "", "", "", ""), 0);
         }
         if ( AV52IsAuthorized_Display )
         {
            cmbavGridactiongroup1.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
         }
         cmbavGridactiongroup1.addItem("4", StringUtil.Format( "%1;%2", context.GetMessage( "WWP_DF_ExportForm", ""), "fas fa-file-export", "", "", "", "", "", "", ""), 0);
         if ( (Guid.Empty==AV59OrganisationId) && ( AV44WWPFormType == 0 ) )
         {
            cmbavGridactiongroup1.addItem("5", StringUtil.Format( "%1;%2", context.GetMessage( "WWP_DF_FillOutAForm", ""), "fas fa-file-circle-plus", "", "", "", "", "", "", ""), 0);
         }
         if ( AV54IsAuthorized_FilledOutForms )
         {
            if ( (Guid.Empty==AV59OrganisationId) && ( AV44WWPFormType == 0 ) && ( AV41FilledOutForms > 0 ) )
            {
               cmbavGridactiongroup1.addItem("6", StringUtil.Format( "%1;%2", context.GetMessage( "WWP_DF_ViewFilledOutForms", ""), "fab fa-wpforms", "", "", "", "", "", "", ""), 0);
            }
         }
         cmbavGridactiongroup1.addItem("7", StringUtil.Format( "%1;%2", context.GetMessage( "WWP_DF_CopyForm", ""), "far fa-clone", "", "", "", "", "", "", ""), 0);
         if ( (AV56GeneralDynamicFormids.IndexOf(A206WWPFormId)>0) )
         {
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 39;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_392( ) ;
            }
            GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_39_Refreshing )
            {
               DoAjaxLoad(39, GridRow);
            }
         }
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV39GridActionGroup1), 4, 0));
      }

      protected void E161W2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV22ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV24ColumnsSelector.FromJSonString(AV22ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "WorkWithPlus.DynamicForms.WWP_FormWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV22ColumnsSelectorXML)) ? "" : AV24ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ColumnsSelector", AV24ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ManageFiltersData", AV27ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
      }

      protected void E121W2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S192 ();
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WorkWithPlus.DynamicForms.WWP_FormWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV67Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV29ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV29ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV29ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WorkWithPlus.DynamicForms.WWP_FormWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV29ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV29ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV29ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char5 = AV28ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "WorkWithPlus.DynamicForms.WWP_FormWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char5) ;
            AV28ManageFiltersXml = GXt_char5;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S192 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV67Pgmname+"GridState",  AV28ManageFiltersXml) ;
               AV15GridState.FromXml(AV28ManageFiltersXml, null, "", "");
               AV17OrderedBy = AV15GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV17OrderedBy", StringUtil.LTrimStr( (decimal)(AV17OrderedBy), 4, 0));
               AV18OrderedDsc = AV15GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV18OrderedDsc", AV18OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S202 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ColumnsSelector", AV24ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ManageFiltersData", AV27ManageFiltersData);
      }

      protected void E241W2( )
      {
         /* Gridactiongroup1_Click Routine */
         returnInSub = false;
         if ( AV39GridActionGroup1 == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV39GridActionGroup1 == 2 )
         {
            /* Execute user subroutine: 'DO UDELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV39GridActionGroup1 == 3 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV39GridActionGroup1 == 4 )
         {
            /* Execute user subroutine: 'DO EXPORTFORM' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV39GridActionGroup1 == 5 )
         {
            /* Execute user subroutine: 'DO FILLOUTAFORM' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV39GridActionGroup1 == 6 )
         {
            /* Execute user subroutine: 'DO FILLEDOUTFORMS' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV39GridActionGroup1 == 7 )
         {
            /* Execute user subroutine: 'DO COPY' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV39GridActionGroup1 = 0;
         AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV39GridActionGroup1), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV39GridActionGroup1), 4, 0));
         AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", cmbavGridactiongroup1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ColumnsSelector", AV24ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ManageFiltersData", AV27ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
      }

      protected void E171W2( )
      {
         /* Dvelop_confirmpanel_udelete_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_udelete_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION UDELETE' */
            S282 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ColumnsSelector", AV24ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ManageFiltersData", AV27ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
      }

      protected void E201W2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV55IsAuthorized_Insert )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_createdynamicform.aspx"+UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.LTrimStr(AV44WWPFormType,1,0));
            CallWebObject(formatLink("workwithplus.dynamicforms.wwp_createdynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ColumnsSelector", AV24ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ManageFiltersData", AV27ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
      }

      protected void E191W2( )
      {
         /* Importform_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.WWP_SelectImportFile")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.wwp_selectimportfile", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.WWP_SelectImportFile";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.WWP_SelectImportFile";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0068",(string)"","WorkWithPlus.DynamicForms.WWP_FormWW",(string)"JSON",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0068"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E181W2( )
      {
         /* Importform_modal_Close Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ColumnsSelector", AV24ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ManageFiltersData", AV27ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GridState", AV15GridState);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV17OrderedBy), 4, 0))+":"+(AV18OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV24ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "WWPFormReferenceName",  "",  "WWP_DF_ReferenceName",  true,  "") ;
         if ( AV44WWPFormType == 0 )
         {
            new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "WWPFormTitle",  "",  "WWP_DF_Title",  true,  "") ;
         }
         else
         {
            new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "",  "",  "",  false,  "") ;
            AV37TFWWPFormTitle = "";
            AssignAttri("", false, "AV37TFWWPFormTitle", AV37TFWWPFormTitle);
            AV38TFWWPFormTitle_Sel = "";
            AssignAttri("", false, "AV38TFWWPFormTitle_Sel", AV38TFWWPFormTitle_Sel);
         }
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "WWPFormDate",  "",  "Date",  true,  "") ;
         if ( (Guid.Empty==AV59OrganisationId) && ( AV44WWPFormType == 0 ) )
         {
            new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "&FilledOutForms",  "",  "WWP_DF_AmountOfFilledOutForms",  true,  "") ;
         }
         else
         {
            new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "",  "",  "",  false,  "") ;
         }
         GXt_char5 = AV23UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "WorkWithPlus.DynamicForms.WWP_FormWWColumnsSelector", out  GXt_char5) ;
         AV23UserCustomValue = GXt_char5;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV23UserCustomValue)) ) )
         {
            AV25ColumnsSelectorAux.FromXml(AV23UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV25ColumnsSelectorAux, ref  AV24ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean6 = AV51IsAuthorized_Update;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wwp_createdynamicform_Execute", out  GXt_boolean6) ;
         AV51IsAuthorized_Update = GXt_boolean6;
         AssignAttri("", false, "AV51IsAuthorized_Update", AV51IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV51IsAuthorized_Update, context));
         GXt_boolean6 = AV52IsAuthorized_Display;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wwp_createdynamicform_Execute", out  GXt_boolean6) ;
         AV52IsAuthorized_Display = GXt_boolean6;
         AssignAttri("", false, "AV52IsAuthorized_Display", AV52IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV52IsAuthorized_Display, context));
         GXt_boolean6 = AV54IsAuthorized_FilledOutForms;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wwp_forminstanceww_Execute", out  GXt_boolean6) ;
         AV54IsAuthorized_FilledOutForms = GXt_boolean6;
         AssignAttri("", false, "AV54IsAuthorized_FilledOutForms", AV54IsAuthorized_FilledOutForms);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_FILLEDOUTFORMS", GetSecureSignedToken( "", AV54IsAuthorized_FilledOutForms, context));
         GXt_boolean6 = AV55IsAuthorized_Insert;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wwp_createdynamicform_Execute", out  GXt_boolean6) ;
         AV55IsAuthorized_Insert = GXt_boolean6;
         AssignAttri("", false, "AV55IsAuthorized_Insert", AV55IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV55IsAuthorized_Insert, context));
         if ( ! ( AV55IsAuthorized_Insert && ( (Guid.Empty==AV59OrganisationId) && ( AV44WWPFormType == 0 ) ) ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         if ( ! ( (Guid.Empty==AV59OrganisationId) ) )
         {
            bttBtnimportform_Visible = 0;
            AssignProp("", false, bttBtnimportform_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnimportform_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item7 = AV27ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "WorkWithPlus.DynamicForms.WWP_FormWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item7) ;
         AV27ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item7;
      }

      protected void S192( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV19FilterFullText = "";
         AssignAttri("", false, "AV19FilterFullText", AV19FilterFullText);
         AV35TFWWPFormReferenceName = "";
         AssignAttri("", false, "AV35TFWWPFormReferenceName", AV35TFWWPFormReferenceName);
         AV36TFWWPFormReferenceName_Sel = "";
         AssignAttri("", false, "AV36TFWWPFormReferenceName_Sel", AV36TFWWPFormReferenceName_Sel);
         AV37TFWWPFormTitle = "";
         AssignAttri("", false, "AV37TFWWPFormTitle", AV37TFWWPFormTitle);
         AV38TFWWPFormTitle_Sel = "";
         AssignAttri("", false, "AV38TFWWPFormTitle_Sel", AV38TFWWPFormTitle_Sel);
         AV61TFWWPFormDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV61TFWWPFormDate", context.localUtil.TToC( AV61TFWWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV62TFWWPFormDate_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV62TFWWPFormDate_To", context.localUtil.TToC( AV62TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S212( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         if ( AV45WWPFormIsForDynamicValidations )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_createdynamicvalidations.aspx"+UrlEncode(StringUtil.LTrimStr(A206WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim("UPD"));
            CallWebObject(formatLink("workwithplus.dynamicforms.wwp_createdynamicvalidations.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            if ( AV51IsAuthorized_Update )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "workwithplus.dynamicforms.wwp_createdynamicform.aspx"+UrlEncode(StringUtil.LTrimStr(A206WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.LTrimStr(A240WWPFormType,1,0));
               CallWebObject(formatLink("workwithplus.dynamicforms.wwp_createdynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
               context.DoAjaxRefresh();
            }
         }
      }

      protected void S222( )
      {
         /* 'DO UDELETE' Routine */
         returnInSub = false;
         Dvelop_confirmpanel_udelete_Confirmationtext = StringUtil.Format( context.GetMessage( "WWP_DF_DeleteFormMessage", ""), A209WWPFormTitle, "", "", "", "", "", "", "", "");
         ucDvelop_confirmpanel_udelete.SendProperty(context, "", false, Dvelop_confirmpanel_udelete_Internalname, "ConfirmationText", Dvelop_confirmpanel_udelete_Confirmationtext);
         AV42WWPFormId_Selected = A206WWPFormId;
         AssignAttri("", false, "AV42WWPFormId_Selected", StringUtil.LTrimStr( (decimal)(AV42WWPFormId_Selected), 4, 0));
         AV43WWPFormVersionNumber_Selected = A207WWPFormVersionNumber;
         this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_UDELETEContainer", "Confirm", "", new Object[] {});
      }

      protected void S282( )
      {
         /* 'DO ACTION UDELETE' Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message8 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>();
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_deleteform(context ).execute(  AV42WWPFormId_Selected,  0, out  GXt_objcol_SdtMessages_Message8) ;
         gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV19FilterFullText, AV44WWPFormType, AV45WWPFormIsForDynamicValidations, AV29ManageFiltersExecutionStep, AV24ColumnsSelector, AV67Pgmname, AV59OrganisationId, AV35TFWWPFormReferenceName, AV36TFWWPFormReferenceName_Sel, AV37TFWWPFormTitle, AV38TFWWPFormTitle_Sel, AV61TFWWPFormDate, AV62TFWWPFormDate_To, AV51IsAuthorized_Update, AV41FilledOutForms, AV52IsAuthorized_Display, AV54IsAuthorized_FilledOutForms, AV56GeneralDynamicFormids, AV40WWPFormId, AV58LocationId, AV55IsAuthorized_Insert, A240WWPFormType) ;
      }

      protected void S232( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         if ( AV52IsAuthorized_Display )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_createdynamicform.aspx"+UrlEncode(StringUtil.LTrimStr(A206WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.LTrimStr(AV44WWPFormType,1,0));
            CallWebObject(formatLink("workwithplus.dynamicforms.wwp_createdynamicform.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         /* 'DO EXPORTFORM' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "workwithplus.dynamicforms.wwp_df_export.aspx"+UrlEncode(StringUtil.LTrimStr(A206WWPFormId,4,0));
         CallWebObject(formatLink("workwithplus.dynamicforms.wwp_df_export.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 2;
      }

      protected void S252( )
      {
         /* 'DO FILLOUTAFORM' Routine */
         returnInSub = false;
         CallWebObject(formatLink("workwithplus.dynamicforms.wwp_dynamicform.aspx", new object[] {UrlEncode(StringUtil.RTrim(A208WWPFormReferenceName)),UrlEncode(StringUtil.LTrimStr(0,1,0)),UrlEncode(StringUtil.RTrim("INS"))}, new string[] {"WWPFormReferenceName","WWPFormInstanceId","WWPDynamicFormMode","isLinkingDiscussion"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S262( )
      {
         /* 'DO FILLEDOUTFORMS' Routine */
         returnInSub = false;
         if ( AV54IsAuthorized_FilledOutForms )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_forminstanceww.aspx"+UrlEncode(StringUtil.LTrimStr(A206WWPFormId,4,0)) + "," + UrlEncode(StringUtil.RTrim(A209WWPFormTitle));
            CallWebObject(formatLink("workwithplus.dynamicforms.wwp_forminstanceww.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem(context.GetMessage( "WWP_ActionNoLongerAvailable", ""));
            context.DoAjaxRefresh();
         }
      }

      protected void S272( )
      {
         /* 'DO COPY' Routine */
         returnInSub = false;
         AV5WWPForm.Load(A206WWPFormId, A207WWPFormVersionNumber);
         AV7CopyNumber = 1;
         AV8WWPFormReferenceName = StringUtil.Format( "%1Copy%2", A208WWPFormReferenceName, StringUtil.Trim( StringUtil.Str( (decimal)(AV7CopyNumber), 4, 0)), "", "", "", "", "", "", "");
         while ( ! new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validateuniquereferencename(context).executeUdp(  0,  AV8WWPFormReferenceName) )
         {
            AV7CopyNumber = (short)(AV7CopyNumber+1);
            AV8WWPFormReferenceName = StringUtil.Format( "%1Copy%2", A208WWPFormReferenceName, StringUtil.Trim( StringUtil.Str( (decimal)(AV7CopyNumber), 4, 0)), "", "", "", "", "", "", "");
         }
         AV9NewWWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         /* Using cursor H001W5 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A207WWPFormVersionNumber = H001W5_A207WWPFormVersionNumber[0];
            A206WWPFormId = H001W5_A206WWPFormId[0];
            A40000GXC1 = H001W5_A40000GXC1[0];
            n40000GXC1 = H001W5_n40000GXC1[0];
            A40000GXC1 = H001W5_A40000GXC1[0];
            n40000GXC1 = H001W5_n40000GXC1[0];
            AV9NewWWPForm.gxTpr_Wwpformid = A206WWPFormId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV9NewWWPForm.gxTpr_Wwpformid = (short)(AV9NewWWPForm.gxTpr_Wwpformid+1);
         AV9NewWWPForm.gxTpr_Wwpformversionnumber = 1;
         AV9NewWWPForm.gxTpr_Wwpformreferencename = AV8WWPFormReferenceName;
         AV9NewWWPForm.gxTpr_Wwpformtitle = AV5WWPForm.gxTpr_Wwpformtitle;
         AV9NewWWPForm.gxTpr_Wwpformdate = DateTimeUtil.Now( context);
         AV9NewWWPForm.gxTpr_Wwpformiswizard = AV5WWPForm.gxTpr_Wwpformiswizard;
         AV9NewWWPForm.gxTpr_Wwpformvalidations = AV5WWPForm.gxTpr_Wwpformvalidations;
         AV9NewWWPForm.gxTpr_Wwpformresume = AV5WWPForm.gxTpr_Wwpformresume;
         AV9NewWWPForm.gxTpr_Wwpformresumemessage = AV5WWPForm.gxTpr_Wwpformresumemessage;
         AV69GXV1 = 1;
         while ( AV69GXV1 <= AV5WWPForm.gxTpr_Element.Count )
         {
            AV6Element = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV5WWPForm.gxTpr_Element.Item(AV69GXV1));
            if ( AV6Element.gxTpr_Wwpformelementparentid >= 0 )
            {
               AV9NewWWPForm.gxTpr_Element.Add(AV6Element, 0);
            }
            AV69GXV1 = (int)(AV69GXV1+1);
         }
         if ( AV9NewWWPForm.Insert() )
         {
            context.CommitDataStores("workwithplus.dynamicforms.wwp_formww",pr_default);
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV19FilterFullText, AV44WWPFormType, AV45WWPFormIsForDynamicValidations, AV29ManageFiltersExecutionStep, AV24ColumnsSelector, AV67Pgmname, AV59OrganisationId, AV35TFWWPFormReferenceName, AV36TFWWPFormReferenceName_Sel, AV37TFWWPFormTitle, AV38TFWWPFormTitle_Sel, AV61TFWWPFormDate, AV62TFWWPFormDate_To, AV51IsAuthorized_Update, AV41FilledOutForms, AV52IsAuthorized_Display, AV54IsAuthorized_FilledOutForms, AV56GeneralDynamicFormids, AV40WWPFormId, AV58LocationId, AV55IsAuthorized_Insert, A240WWPFormType) ;
            if ( ! (Guid.Empty==AV58LocationId) )
            {
               AV60Trn_LocationDynamicForm = new SdtTrn_LocationDynamicForm(context);
               AV60Trn_LocationDynamicForm.gxTpr_Locationdynamicformid = Guid.NewGuid( );
               AV60Trn_LocationDynamicForm.gxTpr_Locationid = AV58LocationId;
               AV60Trn_LocationDynamicForm.gxTpr_Organisationid = AV59OrganisationId;
               AV60Trn_LocationDynamicForm.gxTpr_Wwpformid = AV9NewWWPForm.gxTpr_Wwpformid;
               AV60Trn_LocationDynamicForm.gxTpr_Wwpformversionnumber = AV9NewWWPForm.gxTpr_Wwpformversionnumber;
               if ( AV60Trn_LocationDynamicForm.Insert() )
               {
                  context.CommitDataStores("workwithplus.dynamicforms.wwp_formww",pr_default);
               }
               else
               {
                  AV71GXV3 = 1;
                  AV70GXV2 = AV60Trn_LocationDynamicForm.GetMessages();
                  while ( AV71GXV3 <= AV70GXV2.Count )
                  {
                     AV10Message = ((GeneXus.Utils.SdtMessages_Message)AV70GXV2.Item(AV71GXV3));
                     GX_msglist.addItem(AV10Message.gxTpr_Description);
                     AV71GXV3 = (int)(AV71GXV3+1);
                  }
               }
            }
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  context.GetMessage( "WWP_DF_Copy_SuccessTitle", ""),  context.GetMessage( "WWP_DF_Copy_Success", ""),  "success",  "",  "na",  ""));
            gxgrGrid_refresh( subGrid_Rows, AV17OrderedBy, AV18OrderedDsc, AV19FilterFullText, AV44WWPFormType, AV45WWPFormIsForDynamicValidations, AV29ManageFiltersExecutionStep, AV24ColumnsSelector, AV67Pgmname, AV59OrganisationId, AV35TFWWPFormReferenceName, AV36TFWWPFormReferenceName_Sel, AV37TFWWPFormTitle, AV38TFWWPFormTitle_Sel, AV61TFWWPFormDate, AV62TFWWPFormDate_To, AV51IsAuthorized_Update, AV41FilledOutForms, AV52IsAuthorized_Display, AV54IsAuthorized_FilledOutForms, AV56GeneralDynamicFormids, AV40WWPFormId, AV58LocationId, AV55IsAuthorized_Insert, A240WWPFormType) ;
         }
         else
         {
            AV73GXV5 = 1;
            AV72GXV4 = AV9NewWWPForm.GetMessages();
            while ( AV73GXV5 <= AV72GXV4.Count )
            {
               AV10Message = ((GeneXus.Utils.SdtMessages_Message)AV72GXV4.Item(AV73GXV5));
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11ResultMsg)) )
               {
                  AV11ResultMsg += StringUtil.NewLine( );
                  AssignAttri("", false, "AV11ResultMsg", AV11ResultMsg);
               }
               AV11ResultMsg += AV10Message.gxTpr_Description;
               AssignAttri("", false, "AV11ResultMsg", AV11ResultMsg);
               AV73GXV5 = (int)(AV73GXV5+1);
            }
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  context.GetMessage( "WWP_DF_ErrorCloning", ""),  AV11ResultMsg,  "error",  "",  "false",  ""));
         }
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26Session.Get(AV67Pgmname+"GridState"), "") == 0 )
         {
            AV15GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV67Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV15GridState.FromXml(AV26Session.Get(AV67Pgmname+"GridState"), null, "", "");
         }
         AV17OrderedBy = AV15GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV17OrderedBy", StringUtil.LTrimStr( (decimal)(AV17OrderedBy), 4, 0));
         AV18OrderedDsc = AV15GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV18OrderedDsc", AV18OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV15GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV15GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV15GridState.gxTpr_Currentpage) ;
      }

      protected void S202( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV74GXV6 = 1;
         while ( AV74GXV6 <= AV15GridState.gxTpr_Filtervalues.Count )
         {
            AV16GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV15GridState.gxTpr_Filtervalues.Item(AV74GXV6));
            if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV19FilterFullText", AV19FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME") == 0 )
            {
               AV35TFWWPFormReferenceName = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFWWPFormReferenceName", AV35TFWWPFormReferenceName);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWWPFORMREFERENCENAME_SEL") == 0 )
            {
               AV36TFWWPFormReferenceName_Sel = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFWWPFormReferenceName_Sel", AV36TFWWPFormReferenceName_Sel);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE") == 0 )
            {
               AV37TFWWPFormTitle = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFWWPFormTitle", AV37TFWWPFormTitle);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWWPFORMTITLE_SEL") == 0 )
            {
               AV38TFWWPFormTitle_Sel = AV16GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFWWPFormTitle_Sel", AV38TFWWPFormTitle_Sel);
            }
            else if ( StringUtil.StrCmp(AV16GridStateFilterValue.gxTpr_Name, "TFWWPFORMDATE") == 0 )
            {
               AV61TFWWPFormDate = context.localUtil.CToT( AV16GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV61TFWWPFormDate", context.localUtil.TToC( AV61TFWWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV62TFWWPFormDate_To = context.localUtil.CToT( AV16GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV62TFWWPFormDate_To", context.localUtil.TToC( AV62TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV63DDO_WWPFormDateAuxDate = DateTimeUtil.ResetTime(AV61TFWWPFormDate);
               AssignAttri("", false, "AV63DDO_WWPFormDateAuxDate", context.localUtil.Format(AV63DDO_WWPFormDateAuxDate, "99/99/99"));
               AV64DDO_WWPFormDateAuxDateTo = DateTimeUtil.ResetTime(AV62TFWWPFormDate_To);
               AssignAttri("", false, "AV64DDO_WWPFormDateAuxDateTo", context.localUtil.Format(AV64DDO_WWPFormDateAuxDateTo, "99/99/99"));
            }
            AV74GXV6 = (int)(AV74GXV6+1);
         }
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFWWPFormReferenceName_Sel)),  AV36TFWWPFormReferenceName_Sel, out  GXt_char5) ;
         GXt_char9 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFWWPFormTitle_Sel)),  AV38TFWWPFormTitle_Sel, out  GXt_char9) ;
         Ddo_grid_Selectedvalue_set = GXt_char5+"|"+GXt_char9+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char9 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFWWPFormReferenceName)),  AV35TFWWPFormReferenceName, out  GXt_char9) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFWWPFormTitle)),  AV37TFWWPFormTitle, out  GXt_char5) ;
         Ddo_grid_Filteredtext_set = GXt_char9+"|"+GXt_char5+"|"+((DateTime.MinValue==AV61TFWWPFormDate) ? "" : context.localUtil.DToC( AV63DDO_WWPFormDateAuxDate, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((DateTime.MinValue==AV62TFWWPFormDate_To) ? "" : context.localUtil.DToC( AV64DDO_WWPFormDateAuxDateTo, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV15GridState.FromXml(AV26Session.Get(AV67Pgmname+"GridState"), null, "", "");
         AV15GridState.gxTpr_Orderedby = AV17OrderedBy;
         AV15GridState.gxTpr_Ordereddsc = AV18OrderedDsc;
         AV15GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV15GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)),  0,  AV19FilterFullText,  AV19FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV15GridState,  "TFWWPFORMREFERENCENAME",  context.GetMessage( "WWP_DF_ReferenceName", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFWWPFormReferenceName)),  0,  AV35TFWWPFormReferenceName,  AV35TFWWPFormReferenceName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFWWPFormReferenceName_Sel)),  AV36TFWWPFormReferenceName_Sel,  AV36TFWWPFormReferenceName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV15GridState,  "TFWWPFORMTITLE",  context.GetMessage( "WWP_DF_Title", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFWWPFormTitle)),  0,  AV37TFWWPFormTitle,  AV37TFWWPFormTitle,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFWWPFormTitle_Sel)),  AV38TFWWPFormTitle_Sel,  AV38TFWWPFormTitle_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV15GridState,  "TFWWPFORMDATE",  context.GetMessage( "Date", ""),  !((DateTime.MinValue==AV61TFWWPFormDate)&&(DateTime.MinValue==AV62TFWWPFormDate_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV61TFWWPFormDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")),  ((DateTime.MinValue==AV61TFWWPFormDate) ? "" : StringUtil.Trim( context.localUtil.Format( AV61TFWWPFormDate, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV62TFWWPFormDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")),  ((DateTime.MinValue==AV62TFWWPFormDate_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV62TFWWPFormDate_To, "99/99/99 99:99")))) ;
         if ( ! (0==AV44WWPFormType) )
         {
            AV16GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
            AV16GridStateFilterValue.gxTpr_Name = "PARM_&WWPFORMTYPE";
            AV16GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV44WWPFormType), 1, 0);
            AV15GridState.gxTpr_Filtervalues.Add(AV16GridStateFilterValue, 0);
         }
         if ( ! (false==AV45WWPFormIsForDynamicValidations) )
         {
            AV16GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
            AV16GridStateFilterValue.gxTpr_Name = "PARM_&WWPFORMISFORDYNAMICVALIDATIONS";
            AV16GridStateFilterValue.gxTpr_Value = StringUtil.BoolToStr( AV45WWPFormIsForDynamicValidations);
            AV15GridState.gxTpr_Filtervalues.Add(AV16GridStateFilterValue, 0);
         }
         AV15GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV15GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV67Pgmname+"GridState",  AV15GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV14TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV14TrnContext.gxTpr_Callerobject = AV67Pgmname;
         AV14TrnContext.gxTpr_Callerondelete = true;
         AV14TrnContext.gxTpr_Callerurl = AV13HTTPRequest.ScriptName+"?"+AV13HTTPRequest.QueryString;
         AV14TrnContext.gxTpr_Transactionname = "WorkWithPlus.DynamicForms.WWP_Form";
         AV48TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV48TrnContextAtt.gxTpr_Attributename = "WWPFormType";
         AV48TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV44WWPFormType), 1, 0);
         AV14TrnContext.gxTpr_Attributes.Add(AV48TrnContextAtt, 0);
         AV26Session.Set("TrnContext", AV14TrnContext.ToXml(false, true, "", ""));
      }

      protected void S182( )
      {
         /* 'COUNTFILLEDOUTFORMS' Routine */
         returnInSub = false;
         AV41FilledOutForms = 0;
         AssignAttri("", false, edtavFilledoutforms_Internalname, StringUtil.LTrimStr( (decimal)(AV41FilledOutForms), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, context.localUtil.Format( (decimal)(AV41FilledOutForms), "ZZZ9"), context));
         /* Optimized group. */
         /* Using cursor H001W6 */
         pr_default.execute(2, new Object[] {AV40WWPFormId});
         cV41FilledOutForms = H001W6_AV41FilledOutForms[0];
         AssignAttri("", false, edtavFilledoutforms_Internalname, StringUtil.LTrimStr( (decimal)(cV41FilledOutForms), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, context.localUtil.Format( (decimal)(cV41FilledOutForms), "ZZZ9"), context));
         pr_default.close(2);
         AV41FilledOutForms = (short)(AV41FilledOutForms+cV41FilledOutForms*1);
         AssignAttri("", false, edtavFilledoutforms_Internalname, StringUtil.LTrimStr( (decimal)(AV41FilledOutForms), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vFILLEDOUTFORMS"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, context.localUtil.Format( (decimal)(AV41FilledOutForms), "ZZZ9"), context));
         /* End optimized group. */
      }

      protected void wb_table2_61_1W2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTableimportform_modal_Internalname, tblTableimportform_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucImportform_modal.SetProperty("Width", Importform_modal_Width);
            ucImportform_modal.SetProperty("Title", Importform_modal_Title);
            ucImportform_modal.SetProperty("ConfirmType", Importform_modal_Confirmtype);
            ucImportform_modal.SetProperty("BodyType", Importform_modal_Bodytype);
            ucImportform_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Importform_modal_Internalname, "IMPORTFORM_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"IMPORTFORM_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_61_1W2e( true) ;
         }
         else
         {
            wb_table2_61_1W2e( false) ;
         }
      }

      protected void wb_table1_56_1W2( bool wbgen )
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
            wb_table1_56_1W2e( true) ;
         }
         else
         {
            wb_table1_56_1W2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV44WWPFormType = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV44WWPFormType", StringUtil.Str( (decimal)(AV44WWPFormType), 1, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV44WWPFormType), "9"), context));
         AV45WWPFormIsForDynamicValidations = (bool)getParm(obj,1);
         AssignAttri("", false, "AV45WWPFormIsForDynamicValidations", AV45WWPFormIsForDynamicValidations);
         GxWebStd.gx_hidden_field( context, "gxhash_vWWPFORMISFORDYNAMICVALIDATIONS", GetSecureSignedToken( "", AV45WWPFormIsForDynamicValidations, context));
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
         PA1W2( ) ;
         WS1W2( ) ;
         WE1W2( ) ;
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
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("calendar-system.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256201774739", true, true);
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
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_formww.js", "?20256201774741", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_392( )
      {
         edtWWPFormId_Internalname = "WWPFORMID_"+sGXsfl_39_idx;
         edtWWPFormVersionNumber_Internalname = "WWPFORMVERSIONNUMBER_"+sGXsfl_39_idx;
         edtWWPFormReferenceName_Internalname = "WWPFORMREFERENCENAME_"+sGXsfl_39_idx;
         edtWWPFormTitle_Internalname = "WWPFORMTITLE_"+sGXsfl_39_idx;
         edtWWPFormDate_Internalname = "WWPFORMDATE_"+sGXsfl_39_idx;
         edtavFilledoutforms_Internalname = "vFILLEDOUTFORMS_"+sGXsfl_39_idx;
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_39_idx;
      }

      protected void SubsflControlProps_fel_392( )
      {
         edtWWPFormId_Internalname = "WWPFORMID_"+sGXsfl_39_fel_idx;
         edtWWPFormVersionNumber_Internalname = "WWPFORMVERSIONNUMBER_"+sGXsfl_39_fel_idx;
         edtWWPFormReferenceName_Internalname = "WWPFORMREFERENCENAME_"+sGXsfl_39_fel_idx;
         edtWWPFormTitle_Internalname = "WWPFORMTITLE_"+sGXsfl_39_fel_idx;
         edtWWPFormDate_Internalname = "WWPFORMDATE_"+sGXsfl_39_fel_idx;
         edtavFilledoutforms_Internalname = "vFILLEDOUTFORMS_"+sGXsfl_39_fel_idx;
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_39_fel_idx;
      }

      protected void sendrow_392( )
      {
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_392( ) ;
         WB1W0( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A206WWPFormId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormVersionNumber_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A207WWPFormVersionNumber), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormVersionNumber_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtWWPFormReferenceName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormReferenceName_Internalname,(string)A208WWPFormReferenceName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormReferenceName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWWPFormReferenceName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtWWPFormTitle_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormTitle_Internalname,(string)A209WWPFormTitle,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormTitle_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtWWPFormTitle_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtWWPFormDate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPFormDate_Internalname,context.localUtil.TToC( A231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A231WWPFormDate, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPFormDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtWWPFormDate_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtavFilledoutforms_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_39_idx + "',39)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavFilledoutforms_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41FilledOutForms), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtavFilledoutforms_Enabled!=0) ? context.localUtil.Format( (decimal)(AV41FilledOutForms), "ZZZ9") : context.localUtil.Format( (decimal)(AV41FilledOutForms), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,45);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavFilledoutforms_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavFilledoutforms_Visible,(int)edtavFilledoutforms_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_39_idx + "',39)\"";
            if ( ( cmbavGridactiongroup1.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_39_idx;
               cmbavGridactiongroup1.Name = GXCCtl;
               cmbavGridactiongroup1.WebTags = "";
               if ( cmbavGridactiongroup1.ItemCount > 0 )
               {
                  AV39GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV39GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV39GridActionGroup1), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactiongroup1,(string)cmbavGridactiongroup1_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV39GridActionGroup1), 4, 0)),(short)1,(string)cmbavGridactiongroup1_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONGROUP1.CLICK."+sGXsfl_39_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"",(string)"",(bool)true,(short)0});
            cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV39GridActionGroup1), 4, 0));
            AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", (string)(cmbavGridactiongroup1.ToJavascriptSource()), !bGXsfl_39_Refreshing);
            send_integrity_lvl_hashes1W2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_39_idx = ((subGrid_Islastpage==1)&&(nGXsfl_39_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         /* End function sendrow_392 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_39_idx;
         cmbavGridactiongroup1.Name = GXCCtl;
         cmbavGridactiongroup1.WebTags = "";
         if ( cmbavGridactiongroup1.ItemCount > 0 )
         {
            AV39GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV39GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV39GridActionGroup1), 4, 0));
         }
         cmbWWPFormType.Name = "WWPFORMTYPE";
         cmbWWPFormType.WebTags = "";
         cmbWWPFormType.addItem("0", context.GetMessage( "WWP_DF_Type_DynamicForm", ""), 0);
         cmbWWPFormType.addItem("1", context.GetMessage( "WWP_DF_Type_DynamicSection", ""), 0);
         if ( cmbWWPFormType.ItemCount > 0 )
         {
            A240WWPFormType = (short)(Math.Round(NumberUtil.Val( cmbWWPFormType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A240WWPFormType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A240WWPFormType", StringUtil.Str( (decimal)(A240WWPFormType), 1, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_WWPFORMTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A240WWPFormType), "9"), context));
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWWPFormReferenceName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_DF_ReferenceName", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWWPFormTitle_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_DF_Title", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWWPFormDate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Date", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavFilledoutforms_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_DF_AmountOfFilledOutForms", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A206WWPFormId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A207WWPFormVersionNumber), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A208WWPFormReferenceName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormReferenceName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A209WWPFormTitle));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormTitle_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A231WWPFormDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPFormDate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41FilledOutForms), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavFilledoutforms_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavFilledoutforms_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39GridActionGroup1), 4, 0, ".", ""))));
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
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         bttBtnimportform_Internalname = "BTNIMPORTFORM";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtWWPFormId_Internalname = "WWPFORMID";
         edtWWPFormVersionNumber_Internalname = "WWPFORMVERSIONNUMBER";
         edtWWPFormReferenceName_Internalname = "WWPFORMREFERENCENAME";
         edtWWPFormTitle_Internalname = "WWPFORMTITLE";
         edtWWPFormDate_Internalname = "WWPFORMDATE";
         edtavFilledoutforms_Internalname = "vFILLEDOUTFORMS";
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         cmbWWPFormType_Internalname = "WWPFORMTYPE";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Dvelop_confirmpanel_udelete_Internalname = "DVELOP_CONFIRMPANEL_UDELETE";
         tblTabledvelop_confirmpanel_udelete_Internalname = "TABLEDVELOP_CONFIRMPANEL_UDELETE";
         Importform_modal_Internalname = "IMPORTFORM_MODAL";
         tblTableimportform_modal_Internalname = "TABLEIMPORTFORM_MODAL";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         edtavDdo_wwpformdateauxdatetext_Internalname = "vDDO_WWPFORMDATEAUXDATETEXT";
         Tfwwpformdate_rangepicker_Internalname = "TFWWPFORMDATE_RANGEPICKER";
         divDdo_wwpformdateauxdates_Internalname = "DDO_WWPFORMDATEAUXDATES";
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
         cmbavGridactiongroup1_Jsonclick = "";
         edtavFilledoutforms_Jsonclick = "";
         edtavFilledoutforms_Enabled = 1;
         edtWWPFormDate_Jsonclick = "";
         edtWWPFormTitle_Jsonclick = "";
         edtWWPFormReferenceName_Jsonclick = "";
         edtWWPFormVersionNumber_Jsonclick = "";
         edtWWPFormId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilledoutforms_Visible = -1;
         edtWWPFormDate_Visible = -1;
         edtWWPFormTitle_Visible = -1;
         edtWWPFormReferenceName_Visible = -1;
         cmbWWPFormType.Enabled = 0;
         edtWWPFormDate_Enabled = 0;
         edtWWPFormTitle_Enabled = 0;
         edtWWPFormReferenceName_Enabled = 0;
         edtWWPFormVersionNumber_Enabled = 0;
         edtWWPFormId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_wwpformdateauxdatetext_Jsonclick = "";
         cmbWWPFormType_Jsonclick = "";
         cmbWWPFormType.Visible = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtnimportform_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Importform_modal_Bodytype = "WebComponent";
         Importform_modal_Confirmtype = "";
         Importform_modal_Title = context.GetMessage( "Select file to import", "");
         Importform_modal_Width = "400";
         Dvelop_confirmpanel_udelete_Confirmtype = "1";
         Dvelop_confirmpanel_udelete_Yesbuttonposition = "left";
         Dvelop_confirmpanel_udelete_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_udelete_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_udelete_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_udelete_Confirmationtext = "WWP_DF_DeleteFormMessage";
         Dvelop_confirmpanel_udelete_Title = context.GetMessage( "WWP_DF_DeleteFormTitle", "");
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Datalistproc = "WorkWithPlus.DynamicForms.WWP_FormWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|";
         Ddo_grid_Includedatalist = "T|T|";
         Ddo_grid_Filterisrange = "||P";
         Ddo_grid_Filtertype = "Character|Character|Date";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3";
         Ddo_grid_Columnids = "2:WWPFormReferenceName|3:WWPFormTitle|4:WWPFormDate";
         Ddo_grid_Gridinternalname = "";
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
         Form.Caption = context.GetMessage( "WWP_DynamicForms", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV41FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV44WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV45WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV67Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV59OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV35TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV36TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV51IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV58LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV55IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormReferenceName_Visible","ctrl":"WWPFORMREFERENCENAME","prop":"Visible"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtavFilledoutforms_Visible","ctrl":"vFILLEDOUTFORMS","prop":"Visible"},{"av":"AV32GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV33GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV34GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV51IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV55IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNIMPORTFORM","prop":"Visible"},{"av":"AV27ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV15GridState","fld":"vGRIDSTATE"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E131W2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV44WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV45WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV67Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV59OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV35TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV36TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV51IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV41FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV58LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV55IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E141W2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV44WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV45WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV67Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV59OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV35TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV36TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV51IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV41FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV58LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV55IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E151W2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV44WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV45WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV67Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV59OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV35TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV36TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV51IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV41FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV58LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV55IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV35TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV36TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E231W2","iparms":[{"av":"AV44WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV51IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV59OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV41FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"cmbavGridactiongroup1"},{"av":"AV39GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"},{"av":"AV41FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E161W2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV44WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV45WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV67Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV59OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV35TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV36TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV51IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV41FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV58LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV55IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtWWPFormReferenceName_Visible","ctrl":"WWPFORMREFERENCENAME","prop":"Visible"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtavFilledoutforms_Visible","ctrl":"vFILLEDOUTFORMS","prop":"Visible"},{"av":"AV32GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV33GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV34GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV51IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV55IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNIMPORTFORM","prop":"Visible"},{"av":"AV27ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV15GridState","fld":"vGRIDSTATE"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E121W2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV44WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV45WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV67Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV59OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV35TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV36TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV51IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV41FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV58LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV55IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV15GridState","fld":"vGRIDSTATE"},{"av":"AV63DDO_WWPFormDateAuxDate","fld":"vDDO_WWPFORMDATEAUXDATE"},{"av":"AV64DDO_WWPFormDateAuxDateTo","fld":"vDDO_WWPFORMDATEAUXDATETO"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV15GridState","fld":"vGRIDSTATE"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV35TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV36TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV63DDO_WWPFormDateAuxDate","fld":"vDDO_WWPFORMDATEAUXDATE"},{"av":"AV64DDO_WWPFormDateAuxDateTo","fld":"vDDO_WWPFORMDATEAUXDATETO"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormReferenceName_Visible","ctrl":"WWPFORMREFERENCENAME","prop":"Visible"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtavFilledoutforms_Visible","ctrl":"vFILLEDOUTFORMS","prop":"Visible"},{"av":"AV32GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV33GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV34GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV51IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV55IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNIMPORTFORM","prop":"Visible"},{"av":"AV27ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK","""{"handler":"E241W2","iparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV39GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV44WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV45WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV67Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV59OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV35TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV36TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV51IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV41FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV58LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV55IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true},{"av":"A206WWPFormId","fld":"WWPFORMID","pic":"ZZZ9","hsh":true},{"av":"A209WWPFormTitle","fld":"WWPFORMTITLE","hsh":true},{"av":"A207WWPFormVersionNumber","fld":"WWPFORMVERSIONNUMBER","pic":"ZZZ9","hsh":true},{"av":"A208WWPFormReferenceName","fld":"WWPFORMREFERENCENAME","hsh":true},{"av":"AV11ResultMsg","fld":"vRESULTMSG"}]""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV39GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9"},{"av":"Dvelop_confirmpanel_udelete_Confirmationtext","ctrl":"DVELOP_CONFIRMPANEL_UDELETE","prop":"ConfirmationText"},{"av":"AV42WWPFormId_Selected","fld":"vWWPFORMID_SELECTED","pic":"ZZZ9"},{"av":"AV11ResultMsg","fld":"vRESULTMSG"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormReferenceName_Visible","ctrl":"WWPFORMREFERENCENAME","prop":"Visible"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtavFilledoutforms_Visible","ctrl":"vFILLEDOUTFORMS","prop":"Visible"},{"av":"AV32GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV33GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV34GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV51IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV55IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNIMPORTFORM","prop":"Visible"},{"av":"AV27ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV15GridState","fld":"vGRIDSTATE"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"}]}""");
         setEventMetadata("DVELOP_CONFIRMPANEL_UDELETE.CLOSE","""{"handler":"E171W2","iparms":[{"av":"Dvelop_confirmpanel_udelete_Result","ctrl":"DVELOP_CONFIRMPANEL_UDELETE","prop":"Result"},{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV44WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV45WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV67Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV59OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV35TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV36TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV51IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV41FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV58LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV55IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true},{"av":"AV42WWPFormId_Selected","fld":"vWWPFORMID_SELECTED","pic":"ZZZ9"}]""");
         setEventMetadata("DVELOP_CONFIRMPANEL_UDELETE.CLOSE",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormReferenceName_Visible","ctrl":"WWPFORMREFERENCENAME","prop":"Visible"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtavFilledoutforms_Visible","ctrl":"vFILLEDOUTFORMS","prop":"Visible"},{"av":"AV32GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV33GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV34GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV51IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV55IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNIMPORTFORM","prop":"Visible"},{"av":"AV27ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV15GridState","fld":"vGRIDSTATE"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E201W2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV44WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV45WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV67Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV59OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV35TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV36TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV51IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV41FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV58LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV55IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormReferenceName_Visible","ctrl":"WWPFORMREFERENCENAME","prop":"Visible"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtavFilledoutforms_Visible","ctrl":"vFILLEDOUTFORMS","prop":"Visible"},{"av":"AV32GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV33GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV34GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV51IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV55IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNIMPORTFORM","prop":"Visible"},{"av":"AV27ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV15GridState","fld":"vGRIDSTATE"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"}]}""");
         setEventMetadata("'DOIMPORTFORM'","""{"handler":"E111W1","iparms":[]}""");
         setEventMetadata("IMPORTFORM_MODAL.ONLOADCOMPONENT","""{"handler":"E191W2","iparms":[]""");
         setEventMetadata("IMPORTFORM_MODAL.ONLOADCOMPONENT",""","oparms":[{"ctrl":"WWPAUX_WC"}]}""");
         setEventMetadata("IMPORTFORM_MODAL.CLOSE","""{"handler":"E181W2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV17OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV18OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV44WWPFormType","fld":"vWWPFORMTYPE","pic":"9","hsh":true},{"av":"AV45WWPFormIsForDynamicValidations","fld":"vWWPFORMISFORDYNAMICVALIDATIONS","hsh":true},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV67Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV59OrganisationId","fld":"vORGANISATIONID","hsh":true},{"av":"AV35TFWWPFormReferenceName","fld":"vTFWWPFORMREFERENCENAME"},{"av":"AV36TFWWPFormReferenceName_Sel","fld":"vTFWWPFORMREFERENCENAME_SEL"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"},{"av":"AV61TFWWPFormDate","fld":"vTFWWPFORMDATE","pic":"99/99/99 99:99"},{"av":"AV62TFWWPFormDate_To","fld":"vTFWWPFORMDATE_TO","pic":"99/99/99 99:99"},{"av":"AV51IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV41FilledOutForms","fld":"vFILLEDOUTFORMS","pic":"ZZZ9","hsh":true},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV56GeneralDynamicFormids","fld":"vGENERALDYNAMICFORMIDS","hsh":true},{"av":"AV40WWPFormId","fld":"vWWPFORMID","pic":"ZZZ9","hsh":true},{"av":"AV58LocationId","fld":"vLOCATIONID","hsh":true},{"av":"AV55IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"cmbWWPFormType"},{"av":"A240WWPFormType","fld":"WWPFORMTYPE","pic":"9","hsh":true}]""");
         setEventMetadata("IMPORTFORM_MODAL.CLOSE",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPFormReferenceName_Visible","ctrl":"WWPFORMREFERENCENAME","prop":"Visible"},{"av":"edtWWPFormTitle_Visible","ctrl":"WWPFORMTITLE","prop":"Visible"},{"av":"edtWWPFormDate_Visible","ctrl":"WWPFORMDATE","prop":"Visible"},{"av":"edtavFilledoutforms_Visible","ctrl":"vFILLEDOUTFORMS","prop":"Visible"},{"av":"AV32GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV33GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV34GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV51IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV52IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"AV54IsAuthorized_FilledOutForms","fld":"vISAUTHORIZED_FILLEDOUTFORMS","hsh":true},{"av":"AV55IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"ctrl":"BTNIMPORTFORM","prop":"Visible"},{"av":"AV27ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV15GridState","fld":"vGRIDSTATE"},{"av":"AV37TFWWPFormTitle","fld":"vTFWWPFORMTITLE"},{"av":"AV38TFWWPFormTitle_Sel","fld":"vTFWWPFORMTITLE_SEL"}]}""");
         setEventMetadata("VALID_WWPFORMID","""{"handler":"Valid_Wwpformid","iparms":[]}""");
         setEventMetadata("VALID_WWPFORMVERSIONNUMBER","""{"handler":"Valid_Wwpformversionnumber","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gridactiongroup1","iparms":[]}""");
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
         Ddo_grid_Filteredtextto_get = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Dvelop_confirmpanel_udelete_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV19FilterFullText = "";
         AV24ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV67Pgmname = "";
         AV59OrganisationId = Guid.Empty;
         AV35TFWWPFormReferenceName = "";
         AV36TFWWPFormReferenceName_Sel = "";
         AV37TFWWPFormTitle = "";
         AV38TFWWPFormTitle_Sel = "";
         AV61TFWWPFormDate = (DateTime)(DateTime.MinValue);
         AV62TFWWPFormDate_To = (DateTime)(DateTime.MinValue);
         AV56GeneralDynamicFormids = new GxSimpleCollection<short>();
         AV58LocationId = Guid.Empty;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         forbiddenHiddens = new GXProperties();
         AV27ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV34GridAppliedFilters = "";
         AV30DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV63DDO_WWPFormDateAuxDate = DateTime.MinValue;
         AV64DDO_WWPFormDateAuxDateTo = DateTime.MinValue;
         AV15GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         AV11ResultMsg = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
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
         bttBtninsert_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         bttBtnimportform_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         AV65DDO_WWPFormDateAuxDateText = "";
         ucTfwwpformdate_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A208WWPFormReferenceName = "";
         A209WWPFormTitle = "";
         A231WWPFormDate = (DateTime)(DateTime.MinValue);
         GXDecQS = "";
         lV19FilterFullText = "";
         lV35TFWWPFormReferenceName = "";
         lV37TFWWPFormTitle = "";
         H001W3_A242WWPFormIsForDynamicValidations = new bool[] {false} ;
         H001W3_A240WWPFormType = new short[1] ;
         H001W3_A231WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         H001W3_A209WWPFormTitle = new string[] {""} ;
         H001W3_A208WWPFormReferenceName = new string[] {""} ;
         H001W3_A207WWPFormVersionNumber = new short[1] ;
         H001W3_A40000GXC1 = new int[1] ;
         H001W3_n40000GXC1 = new bool[] {false} ;
         H001W3_A206WWPFormId = new short[1] ;
         hsh = "";
         GXt_guid2 = Guid.Empty;
         GXt_objcol_int3 = new GxSimpleCollection<short>();
         AV13HTTPRequest = new GxHttpRequest( context);
         AV49GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV50GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV12WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV26Session = context.GetSession();
         AV22ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         AV28ManageFiltersXml = "";
         AV23UserCustomValue = "";
         AV25ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item7 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         ucDvelop_confirmpanel_udelete = new GXUserControl();
         GXt_objcol_SdtMessages_Message8 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV5WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         AV8WWPFormReferenceName = "";
         AV9NewWWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         H001W5_A207WWPFormVersionNumber = new short[1] ;
         H001W5_A206WWPFormId = new short[1] ;
         H001W5_A40000GXC1 = new int[1] ;
         H001W5_n40000GXC1 = new bool[] {false} ;
         AV6Element = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV60Trn_LocationDynamicForm = new SdtTrn_LocationDynamicForm(context);
         AV70GXV2 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV10Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV72GXV4 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV16GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char9 = "";
         GXt_char5 = "";
         AV14TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV48TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         H001W6_AV41FilledOutForms = new short[1] ;
         ucImportform_modal = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_formww__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_formww__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_formww__default(),
            new Object[][] {
                new Object[] {
               H001W3_A242WWPFormIsForDynamicValidations, H001W3_A240WWPFormType, H001W3_A231WWPFormDate, H001W3_A209WWPFormTitle, H001W3_A208WWPFormReferenceName, H001W3_A207WWPFormVersionNumber, H001W3_A40000GXC1, H001W3_n40000GXC1, H001W3_A206WWPFormId
               }
               , new Object[] {
               H001W5_A207WWPFormVersionNumber, H001W5_A206WWPFormId, H001W5_A40000GXC1, H001W5_n40000GXC1
               }
               , new Object[] {
               H001W6_AV41FilledOutForms
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV67Pgmname = "WorkWithPlus.DynamicForms.WWP_FormWW";
         /* GeneXus formulas. */
         AV67Pgmname = "WorkWithPlus.DynamicForms.WWP_FormWW";
         edtavFilledoutforms_Enabled = 0;
      }

      private short AV44WWPFormType ;
      private short wcpOAV44WWPFormType ;
      private short GRID_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV17OrderedBy ;
      private short AV29ManageFiltersExecutionStep ;
      private short AV41FilledOutForms ;
      private short AV40WWPFormId ;
      private short A240WWPFormType ;
      private short gxajaxcallmode ;
      private short AV42WWPFormId_Selected ;
      private short A219WWPFormLatestVersionNumber ;
      private short wbEnd ;
      private short wbStart ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private short AV39GridActionGroup1 ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short GXt_int1 ;
      private short AV43WWPFormVersionNumber_Selected ;
      private short AV7CopyNumber ;
      private short cV41FilledOutForms ;
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
      private int bttBtninsert_Visible ;
      private int bttBtnimportform_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavFilledoutforms_Enabled ;
      private int A40000GXC1 ;
      private int edtWWPFormId_Enabled ;
      private int edtWWPFormVersionNumber_Enabled ;
      private int edtWWPFormReferenceName_Enabled ;
      private int edtWWPFormTitle_Enabled ;
      private int edtWWPFormDate_Enabled ;
      private int edtWWPFormReferenceName_Visible ;
      private int edtWWPFormTitle_Visible ;
      private int edtWWPFormDate_Visible ;
      private int edtavFilledoutforms_Visible ;
      private int AV31PageToGo ;
      private int AV69GXV1 ;
      private int AV71GXV3 ;
      private int AV73GXV5 ;
      private int AV74GXV6 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV32GridCurrentPage ;
      private long AV33GridPageCount ;
      private long GRID_nCurrentRecord ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Dvelop_confirmpanel_udelete_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_39_idx="0001" ;
      private string AV67Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
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
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gamoauthtoken ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
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
      private string Importform_modal_Width ;
      private string Importform_modal_Title ;
      private string Importform_modal_Confirmtype ;
      private string Importform_modal_Bodytype ;
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
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string bttBtnimportform_Internalname ;
      private string bttBtnimportform_Jsonclick ;
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
      private string Ddo_grid_Internalname ;
      private string cmbWWPFormType_Internalname ;
      private string cmbWWPFormType_Jsonclick ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string divDdo_wwpformdateauxdates_Internalname ;
      private string edtavDdo_wwpformdateauxdatetext_Internalname ;
      private string edtavDdo_wwpformdateauxdatetext_Jsonclick ;
      private string Tfwwpformdate_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtWWPFormId_Internalname ;
      private string edtWWPFormVersionNumber_Internalname ;
      private string edtWWPFormReferenceName_Internalname ;
      private string edtWWPFormTitle_Internalname ;
      private string edtWWPFormDate_Internalname ;
      private string edtavFilledoutforms_Internalname ;
      private string cmbavGridactiongroup1_Internalname ;
      private string GXDecQS ;
      private string hsh ;
      private string Dvelop_confirmpanel_udelete_Internalname ;
      private string GXt_char9 ;
      private string GXt_char5 ;
      private string tblTableimportform_modal_Internalname ;
      private string Importform_modal_Internalname ;
      private string tblTabledvelop_confirmpanel_udelete_Internalname ;
      private string sGXsfl_39_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtWWPFormId_Jsonclick ;
      private string edtWWPFormVersionNumber_Jsonclick ;
      private string edtWWPFormReferenceName_Jsonclick ;
      private string edtWWPFormTitle_Jsonclick ;
      private string edtWWPFormDate_Jsonclick ;
      private string edtavFilledoutforms_Jsonclick ;
      private string GXCCtl ;
      private string cmbavGridactiongroup1_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV61TFWWPFormDate ;
      private DateTime AV62TFWWPFormDate_To ;
      private DateTime A231WWPFormDate ;
      private DateTime AV63DDO_WWPFormDateAuxDate ;
      private DateTime AV64DDO_WWPFormDateAuxDateTo ;
      private bool AV45WWPFormIsForDynamicValidations ;
      private bool wcpOAV45WWPFormIsForDynamicValidations ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV18OrderedDsc ;
      private bool AV51IsAuthorized_Update ;
      private bool AV52IsAuthorized_Display ;
      private bool AV54IsAuthorized_FilledOutForms ;
      private bool AV55IsAuthorized_Insert ;
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
      private bool A242WWPFormIsForDynamicValidations ;
      private bool n40000GXC1 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean6 ;
      private string AV22ColumnsSelectorXML ;
      private string AV28ManageFiltersXml ;
      private string AV23UserCustomValue ;
      private string AV19FilterFullText ;
      private string AV35TFWWPFormReferenceName ;
      private string AV36TFWWPFormReferenceName_Sel ;
      private string AV37TFWWPFormTitle ;
      private string AV38TFWWPFormTitle_Sel ;
      private string AV34GridAppliedFilters ;
      private string AV11ResultMsg ;
      private string AV65DDO_WWPFormDateAuxDateText ;
      private string A208WWPFormReferenceName ;
      private string A209WWPFormTitle ;
      private string lV19FilterFullText ;
      private string lV35TFWWPFormReferenceName ;
      private string lV37TFWWPFormTitle ;
      private string AV8WWPFormReferenceName ;
      private Guid AV59OrganisationId ;
      private Guid AV58LocationId ;
      private Guid GXt_guid2 ;
      private IGxSession AV26Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfwwpformdate_rangepicker ;
      private GXUserControl ucDvelop_confirmpanel_udelete ;
      private GXUserControl ucImportform_modal ;
      private GxHttpRequest AV13HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridactiongroup1 ;
      private GXCombobox cmbWWPFormType ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV24ColumnsSelector ;
      private GxSimpleCollection<short> AV56GeneralDynamicFormids ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV27ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV30DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV15GridState ;
      private IDataStoreProvider pr_default ;
      private bool[] H001W3_A242WWPFormIsForDynamicValidations ;
      private short[] H001W3_A240WWPFormType ;
      private DateTime[] H001W3_A231WWPFormDate ;
      private string[] H001W3_A209WWPFormTitle ;
      private string[] H001W3_A208WWPFormReferenceName ;
      private short[] H001W3_A207WWPFormVersionNumber ;
      private int[] H001W3_A40000GXC1 ;
      private bool[] H001W3_n40000GXC1 ;
      private short[] H001W3_A206WWPFormId ;
      private GxSimpleCollection<short> GXt_objcol_int3 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV49GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV50GAMErrors ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV12WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV25ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item7 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message8 ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV5WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV9NewWWPForm ;
      private short[] H001W5_A207WWPFormVersionNumber ;
      private short[] H001W5_A206WWPFormId ;
      private int[] H001W5_A40000GXC1 ;
      private bool[] H001W5_n40000GXC1 ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV6Element ;
      private SdtTrn_LocationDynamicForm AV60Trn_LocationDynamicForm ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV70GXV2 ;
      private GeneXus.Utils.SdtMessages_Message AV10Message ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV72GXV4 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV16GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV14TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV48TrnContextAtt ;
      private short[] H001W6_AV41FilledOutForms ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_formww__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_formww__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_formww__default : DataStoreHelperBase, IDataStoreHelper
{
   protected Object[] conditional_H001W3( IGxContext context ,
                                          string AV19FilterFullText ,
                                          string AV36TFWWPFormReferenceName_Sel ,
                                          string AV35TFWWPFormReferenceName ,
                                          string AV38TFWWPFormTitle_Sel ,
                                          string AV37TFWWPFormTitle ,
                                          DateTime AV61TFWWPFormDate ,
                                          DateTime AV62TFWWPFormDate_To ,
                                          short AV44WWPFormType ,
                                          bool AV45WWPFormIsForDynamicValidations ,
                                          string A208WWPFormReferenceName ,
                                          string A209WWPFormTitle ,
                                          DateTime A231WWPFormDate ,
                                          bool A242WWPFormIsForDynamicValidations ,
                                          int A40000GXC1 ,
                                          short AV17OrderedBy ,
                                          bool AV18OrderedDsc ,
                                          short A240WWPFormType ,
                                          short A207WWPFormVersionNumber ,
                                          short A219WWPFormLatestVersionNumber )
   {
      System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
      string scmdbuf;
      short[] GXv_int10 = new short[9];
      Object[] GXv_Object11 = new Object[2];
      scmdbuf = "SELECT T1.WWPFormIsForDynamicValidations, T1.WWPFormType, T1.WWPFormDate, T1.WWPFormTitle, T1.WWPFormReferenceName, T1.WWPFormVersionNumber, COALESCE( T2.GXC1, 0) AS GXC1, T1.WWPFormId FROM (WWP_Form T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, WWPFormId, WWPFormVersionNumber FROM WWP_FormElement WHERE T1.WWPFormId = WWPFormId and T1.WWPFormVersionNumber = WWPFormVersionNumber GROUP BY WWPFormId, WWPFormVersionNumber ) T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber)";
      AddWhere(sWhereString, "(T1.WWPFormType = :AV44WWPFormType)");
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)) )
      {
         AddWhere(sWhereString, "(( LOWER(T1.WWPFormReferenceName) like '%' || LOWER(:lV19FilterFullText)) or ( LOWER(T1.WWPFormTitle) like '%' || LOWER(:lV19FilterFullText)))");
      }
      else
      {
         GXv_int10[1] = 1;
         GXv_int10[2] = 1;
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFWWPFormReferenceName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFWWPFormReferenceName)) ) )
      {
         AddWhere(sWhereString, "(T1.WWPFormReferenceName like :lV35TFWWPFormReferenceName)");
      }
      else
      {
         GXv_int10[3] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFWWPFormReferenceName_Sel)) && ! ( StringUtil.StrCmp(AV36TFWWPFormReferenceName_Sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T1.WWPFormReferenceName = ( :AV36TFWWPFormReferenceName_Sel))");
      }
      else
      {
         GXv_int10[4] = 1;
      }
      if ( StringUtil.StrCmp(AV36TFWWPFormReferenceName_Sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WWPFormReferenceName))=0))");
      }
      if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFWWPFormTitle_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFWWPFormTitle)) ) )
      {
         AddWhere(sWhereString, "(T1.WWPFormTitle like :lV37TFWWPFormTitle)");
      }
      else
      {
         GXv_int10[5] = 1;
      }
      if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFWWPFormTitle_Sel)) && ! ( StringUtil.StrCmp(AV38TFWWPFormTitle_Sel, "<#Empty#>") == 0 ) )
      {
         AddWhere(sWhereString, "(T1.WWPFormTitle = ( :AV38TFWWPFormTitle_Sel))");
      }
      else
      {
         GXv_int10[6] = 1;
      }
      if ( StringUtil.StrCmp(AV38TFWWPFormTitle_Sel, "<#Empty#>") == 0 )
      {
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.WWPFormTitle))=0))");
      }
      if ( ! (DateTime.MinValue==AV61TFWWPFormDate) )
      {
         AddWhere(sWhereString, "(T1.WWPFormDate >= :AV61TFWWPFormDate)");
      }
      else
      {
         GXv_int10[7] = 1;
      }
      if ( ! (DateTime.MinValue==AV62TFWWPFormDate_To) )
      {
         AddWhere(sWhereString, "(T1.WWPFormDate <= :AV62TFWWPFormDate_To)");
      }
      else
      {
         GXv_int10[8] = 1;
      }
      if ( ( AV44WWPFormType == 1 ) && AV45WWPFormIsForDynamicValidations )
      {
         AddWhere(sWhereString, "(T1.WWPFormIsForDynamicValidations)");
      }
      if ( ( AV44WWPFormType == 1 ) && ! AV45WWPFormIsForDynamicValidations )
      {
         AddWhere(sWhereString, "(COALESCE( T2.GXC1, 0) > 0)");
      }
      scmdbuf += sWhereString;
      if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
      {
         scmdbuf += " ORDER BY T1.WWPFormType, T1.WWPFormReferenceName";
      }
      else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
      {
         scmdbuf += " ORDER BY T1.WWPFormType DESC, T1.WWPFormReferenceName DESC";
      }
      else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
      {
         scmdbuf += " ORDER BY T1.WWPFormType, T1.WWPFormTitle";
      }
      else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
      {
         scmdbuf += " ORDER BY T1.WWPFormType DESC, T1.WWPFormTitle DESC";
      }
      else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
      {
         scmdbuf += " ORDER BY T1.WWPFormType, T1.WWPFormDate";
      }
      else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
      {
         scmdbuf += " ORDER BY T1.WWPFormType DESC, T1.WWPFormDate DESC";
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
                  return conditional_H001W3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (bool)dynConstraints[12] , (int)dynConstraints[13] , (short)dynConstraints[14] , (bool)dynConstraints[15] , (short)dynConstraints[16] , (short)dynConstraints[17] , (short)dynConstraints[18] );
      }
      return base.getDynamicStatement(cursor, context, dynConstraints);
   }

   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmH001W5;
       prmH001W5 = new Object[] {
       };
       Object[] prmH001W6;
       prmH001W6 = new Object[] {
       new ParDef("AV40WWPFormId",GXType.Int16,4,0)
       };
       Object[] prmH001W3;
       prmH001W3 = new Object[] {
       new ParDef("AV44WWPFormType",GXType.Int16,1,0) ,
       new ParDef("lV19FilterFullText",GXType.VarChar,100,0) ,
       new ParDef("lV19FilterFullText",GXType.VarChar,100,0) ,
       new ParDef("lV35TFWWPFormReferenceName",GXType.VarChar,100,0) ,
       new ParDef("AV36TFWWPFormReferenceName_Sel",GXType.VarChar,100,0) ,
       new ParDef("lV37TFWWPFormTitle",GXType.VarChar,100,0) ,
       new ParDef("AV38TFWWPFormTitle_Sel",GXType.VarChar,100,0) ,
       new ParDef("AV61TFWWPFormDate",GXType.DateTime,8,5) ,
       new ParDef("AV62TFWWPFormDate_To",GXType.DateTime,8,5)
       };
       def= new CursorDef[] {
           new CursorDef("H001W3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001W3,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("H001W5", "SELECT T1.WWPFormVersionNumber, T1.WWPFormId, COALESCE( T2.GXC1, 0) AS GXC1 FROM (WWP_Form T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS GXC1, WWPFormId, WWPFormVersionNumber FROM WWP_FormElement WHERE T1.WWPFormId = WWPFormId and T1.WWPFormVersionNumber = WWPFormVersionNumber GROUP BY WWPFormId, WWPFormVersionNumber ) T2 ON T2.WWPFormId = T1.WWPFormId AND T2.WWPFormVersionNumber = T1.WWPFormVersionNumber) ORDER BY T1.WWPFormId DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001W5,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("H001W6", "SELECT COUNT(*) FROM WWP_FormInstance WHERE WWPFormId = :AV40WWPFormId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001W6,1, GxCacheFrequency.OFF ,true,false )
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
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((short[]) buf[5])[0] = rslt.getShort(6);
             ((int[]) buf[6])[0] = rslt.getInt(7);
             ((bool[]) buf[7])[0] = rslt.wasNull(7);
             ((short[]) buf[8])[0] = rslt.getShort(8);
             return;
          case 1 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((int[]) buf[2])[0] = rslt.getInt(3);
             ((bool[]) buf[3])[0] = rslt.wasNull(3);
             return;
          case 2 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
    }
 }

}

}
