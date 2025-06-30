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
   public class trn_auditww : GXDataArea
   {
      public trn_auditww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_auditww( IGxContext context )
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
         nRC_GXsfl_35 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_35"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_35_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_35_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_35_idx = GetPar( "sGXsfl_35_idx");
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
         ajax_req_read_hidden_sdt(GetNextPar( ), AV58ColumnsSelector);
         AV63Pgmname = GetPar( "Pgmname");
         AV20TFAuditDate = context.localUtil.ParseDTimeParm( GetPar( "TFAuditDate"));
         AV21TFAuditDate_To = context.localUtil.ParseDTimeParm( GetPar( "TFAuditDate_To"));
         AV35TFAuditAction = GetPar( "TFAuditAction");
         AV36TFAuditAction_Sel = GetPar( "TFAuditAction_Sel");
         AV33TFAuditUserName = GetPar( "TFAuditUserName");
         AV34TFAuditUserName_Sel = GetPar( "TFAuditUserName_Sel");
         AV60TFAuditTableDiaplayName = GetPar( "TFAuditTableDiaplayName");
         AV61TFAuditTableDiaplayName_Sel = GetPar( "TFAuditTableDiaplayName_Sel");
         AV29TFAuditShortDescription = GetPar( "TFAuditShortDescription");
         AV30TFAuditShortDescription_Sel = GetPar( "TFAuditShortDescription_Sel");
         AV46IsAuthorized_Display = StringUtil.StrToBool( GetPar( "IsAuthorized_Display"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV58ColumnsSelector, AV63Pgmname, AV20TFAuditDate, AV21TFAuditDate_To, AV35TFAuditAction, AV36TFAuditAction_Sel, AV33TFAuditUserName, AV34TFAuditUserName_Sel, AV60TFAuditTableDiaplayName, AV61TFAuditTableDiaplayName_Sel, AV29TFAuditShortDescription, AV30TFAuditShortDescription_Sel, AV46IsAuthorized_Display) ;
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
            return "trn_auditww_Execute" ;
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
         PA6Q2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START6Q2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trn_auditww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV63Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV63Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV46IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV46IsAuthorized_Display, context));
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
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_35", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_35), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV17ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV17ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV43GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV37DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV37DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV58ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV58ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_AUDITDATEAUXDATE", context.localUtil.DToC( AV22DDO_AuditDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_AUDITDATEAUXDATETO", context.localUtil.DToC( AV23DDO_AuditDateAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV63Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV63Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFAUDITDATE", context.localUtil.TToC( AV20TFAuditDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFAUDITDATE_TO", context.localUtil.TToC( AV21TFAuditDate_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFAUDITACTION", AV35TFAuditAction);
         GxWebStd.gx_hidden_field( context, "vTFAUDITACTION_SEL", AV36TFAuditAction_Sel);
         GxWebStd.gx_hidden_field( context, "vTFAUDITUSERNAME", AV33TFAuditUserName);
         GxWebStd.gx_hidden_field( context, "vTFAUDITUSERNAME_SEL", AV34TFAuditUserName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFAUDITTABLEDIAPLAYNAME", AV60TFAuditTableDiaplayName);
         GxWebStd.gx_hidden_field( context, "vTFAUDITTABLEDIAPLAYNAME_SEL", AV61TFAuditTableDiaplayName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFAUDITSHORTDESCRIPTION", AV29TFAuditShortDescription);
         GxWebStd.gx_hidden_field( context, "vTFAUDITSHORTDESCRIPTION_SEL", AV30TFAuditShortDescription_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV46IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV46IsAuthorized_Display, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
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
            WE6Q2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT6Q2( ) ;
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
         return formatLink("trn_auditww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trn_AuditWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " Trn_Audit", "") ;
      }

      protected void WB6Q0( )
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
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(35), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_Trn_AuditWW.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_Trn_AuditWW.htm");
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
            StartGridControl35( ) ;
         }
         if ( wbEnd == 35 )
         {
            wbEnd = 0;
            nRC_GXsfl_35 = (int)(nGXsfl_35_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV41GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV42GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV43GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV37DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV37DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV58ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_auditdateauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_auditdateauxdatetext_Internalname, AV24DDO_AuditDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV24DDO_AuditDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_auditdateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Trn_AuditWW.htm");
            /* User Defined Control */
            ucTfauditdate_rangepicker.SetProperty("Start Date", AV22DDO_AuditDateAuxDate);
            ucTfauditdate_rangepicker.SetProperty("End Date", AV23DDO_AuditDateAuxDateTo);
            ucTfauditdate_rangepicker.Render(context, "wwp.daterangepicker", Tfauditdate_rangepicker_Internalname, "TFAUDITDATE_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 35 )
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

      protected void START6Q2( )
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
         Form.Meta.addItem("description", context.GetMessage( " Trn_Audit", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP6Q0( ) ;
      }

      protected void WS6Q2( )
      {
         START6Q2( ) ;
         EVT6Q2( ) ;
      }

      protected void EVT6Q2( )
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
                              E116Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E126Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E136Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E146Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E156Q2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_35_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
                              SubsflControlProps_352( ) ;
                              A372AuditDate = context.localUtil.CToT( cgiGet( edtAuditDate_Internalname), 0);
                              A371AuditId = StringUtil.StrToGuid( cgiGet( edtAuditId_Internalname));
                              A378AuditAction = cgiGet( edtAuditAction_Internalname);
                              A373AuditTableName = cgiGet( edtAuditTableName_Internalname);
                              A374AuditDescription = cgiGet( edtAuditDescription_Internalname);
                              A376GAMUserId = cgiGet( edtGAMUserId_Internalname);
                              A377AuditUserName = cgiGet( edtAuditUserName_Internalname);
                              A491AuditTableDiaplayName = cgiGet( edtAuditTableDiaplayName_Internalname);
                              A375AuditShortDescription = cgiGet( edtAuditShortDescription_Internalname);
                              A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
                              n11OrganisationId = false;
                              AV45Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri("", false, edtavDisplay_Internalname, AV45Display);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E166Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E176Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E186Q2 ();
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE6Q2( )
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

      protected void PA6Q2( )
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
         SubsflControlProps_352( ) ;
         while ( nGXsfl_35_idx <= nRC_GXsfl_35 )
         {
            sendrow_352( ) ;
            nGXsfl_35_idx = ((subGrid_Islastpage==1)&&(nGXsfl_35_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_idx+1);
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV15FilterFullText ,
                                       short AV19ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV58ColumnsSelector ,
                                       string AV63Pgmname ,
                                       DateTime AV20TFAuditDate ,
                                       DateTime AV21TFAuditDate_To ,
                                       string AV35TFAuditAction ,
                                       string AV36TFAuditAction_Sel ,
                                       string AV33TFAuditUserName ,
                                       string AV34TFAuditUserName_Sel ,
                                       string AV60TFAuditTableDiaplayName ,
                                       string AV61TFAuditTableDiaplayName_Sel ,
                                       string AV29TFAuditShortDescription ,
                                       string AV30TFAuditShortDescription_Sel ,
                                       bool AV46IsAuthorized_Display )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF6Q2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
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
         RF6Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV63Pgmname = "Trn_AuditWW";
         edtavDisplay_Enabled = 0;
      }

      protected void RF6Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 35;
         /* Execute user event: Refresh */
         E176Q2 ();
         nGXsfl_35_idx = 1;
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
         bGXsfl_35_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWithSelection WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_352( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV64Trn_auditwwds_2_filterfulltext ,
                                                 AV65Trn_auditwwds_3_tfauditdate ,
                                                 AV66Trn_auditwwds_4_tfauditdate_to ,
                                                 AV68Trn_auditwwds_6_tfauditaction_sel ,
                                                 AV67Trn_auditwwds_5_tfauditaction ,
                                                 AV70Trn_auditwwds_8_tfauditusername_sel ,
                                                 AV69Trn_auditwwds_7_tfauditusername ,
                                                 AV72Trn_auditwwds_10_tfaudittablediaplayname_sel ,
                                                 AV71Trn_auditwwds_9_tfaudittablediaplayname ,
                                                 AV74Trn_auditwwds_12_tfauditshortdescription_sel ,
                                                 AV73Trn_auditwwds_11_tfauditshortdescription ,
                                                 A378AuditAction ,
                                                 A377AuditUserName ,
                                                 A373AuditTableName ,
                                                 A375AuditShortDescription ,
                                                 A372AuditDate ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 A11OrganisationId ,
                                                 AV62Udparg1 } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                 }
            });
            lV64Trn_auditwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Trn_auditwwds_2_filterfulltext), "%", "");
            lV64Trn_auditwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Trn_auditwwds_2_filterfulltext), "%", "");
            lV64Trn_auditwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Trn_auditwwds_2_filterfulltext), "%", "");
            lV64Trn_auditwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Trn_auditwwds_2_filterfulltext), "%", "");
            lV67Trn_auditwwds_5_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV67Trn_auditwwds_5_tfauditaction), "%", "");
            lV69Trn_auditwwds_7_tfauditusername = StringUtil.Concat( StringUtil.RTrim( AV69Trn_auditwwds_7_tfauditusername), "%", "");
            lV71Trn_auditwwds_9_tfaudittablediaplayname = StringUtil.Concat( StringUtil.RTrim( AV71Trn_auditwwds_9_tfaudittablediaplayname), "%", "");
            lV73Trn_auditwwds_11_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV73Trn_auditwwds_11_tfauditshortdescription), "%", "");
            /* Using cursor H006Q2 */
            pr_default.execute(0, new Object[] {AV62Udparg1, lV64Trn_auditwwds_2_filterfulltext, lV64Trn_auditwwds_2_filterfulltext, lV64Trn_auditwwds_2_filterfulltext, lV64Trn_auditwwds_2_filterfulltext, AV65Trn_auditwwds_3_tfauditdate, AV66Trn_auditwwds_4_tfauditdate_to, lV67Trn_auditwwds_5_tfauditaction, AV68Trn_auditwwds_6_tfauditaction_sel, lV69Trn_auditwwds_7_tfauditusername, AV70Trn_auditwwds_8_tfauditusername_sel, lV71Trn_auditwwds_9_tfaudittablediaplayname, AV72Trn_auditwwds_10_tfaudittablediaplayname_sel, lV73Trn_auditwwds_11_tfauditshortdescription, AV74Trn_auditwwds_12_tfauditshortdescription_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_35_idx = 1;
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A11OrganisationId = H006Q2_A11OrganisationId[0];
               n11OrganisationId = H006Q2_n11OrganisationId[0];
               A375AuditShortDescription = H006Q2_A375AuditShortDescription[0];
               A377AuditUserName = H006Q2_A377AuditUserName[0];
               A376GAMUserId = H006Q2_A376GAMUserId[0];
               A374AuditDescription = H006Q2_A374AuditDescription[0];
               A378AuditAction = H006Q2_A378AuditAction[0];
               A371AuditId = H006Q2_A371AuditId[0];
               A372AuditDate = H006Q2_A372AuditDate[0];
               A373AuditTableName = H006Q2_A373AuditTableName[0];
               A491AuditTableDiaplayName = StringUtil.Substring( A373AuditTableName, 5, -1);
               /* Execute user event: Grid.Load */
               E186Q2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 35;
            WB6Q0( ) ;
         }
         bGXsfl_35_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes6Q2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV63Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV63Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DISPLAY", AV46IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV46IsAuthorized_Display, context));
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
         AV64Trn_auditwwds_2_filterfulltext = AV15FilterFullText;
         AV65Trn_auditwwds_3_tfauditdate = AV20TFAuditDate;
         AV66Trn_auditwwds_4_tfauditdate_to = AV21TFAuditDate_To;
         AV67Trn_auditwwds_5_tfauditaction = AV35TFAuditAction;
         AV68Trn_auditwwds_6_tfauditaction_sel = AV36TFAuditAction_Sel;
         AV69Trn_auditwwds_7_tfauditusername = AV33TFAuditUserName;
         AV70Trn_auditwwds_8_tfauditusername_sel = AV34TFAuditUserName_Sel;
         AV71Trn_auditwwds_9_tfaudittablediaplayname = AV60TFAuditTableDiaplayName;
         AV72Trn_auditwwds_10_tfaudittablediaplayname_sel = AV61TFAuditTableDiaplayName_Sel;
         AV73Trn_auditwwds_11_tfauditshortdescription = AV29TFAuditShortDescription;
         AV74Trn_auditwwds_12_tfauditshortdescription_sel = AV30TFAuditShortDescription_Sel;
         AV62Udparg1 = new prc_getuserorganisationid(context).executeUdp( );
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV64Trn_auditwwds_2_filterfulltext ,
                                              AV65Trn_auditwwds_3_tfauditdate ,
                                              AV66Trn_auditwwds_4_tfauditdate_to ,
                                              AV68Trn_auditwwds_6_tfauditaction_sel ,
                                              AV67Trn_auditwwds_5_tfauditaction ,
                                              AV70Trn_auditwwds_8_tfauditusername_sel ,
                                              AV69Trn_auditwwds_7_tfauditusername ,
                                              AV72Trn_auditwwds_10_tfaudittablediaplayname_sel ,
                                              AV71Trn_auditwwds_9_tfaudittablediaplayname ,
                                              AV74Trn_auditwwds_12_tfauditshortdescription_sel ,
                                              AV73Trn_auditwwds_11_tfauditshortdescription ,
                                              A378AuditAction ,
                                              A377AuditUserName ,
                                              A373AuditTableName ,
                                              A375AuditShortDescription ,
                                              A372AuditDate ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              A11OrganisationId ,
                                              AV62Udparg1 } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV64Trn_auditwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Trn_auditwwds_2_filterfulltext), "%", "");
         lV64Trn_auditwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Trn_auditwwds_2_filterfulltext), "%", "");
         lV64Trn_auditwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Trn_auditwwds_2_filterfulltext), "%", "");
         lV64Trn_auditwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Trn_auditwwds_2_filterfulltext), "%", "");
         lV67Trn_auditwwds_5_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV67Trn_auditwwds_5_tfauditaction), "%", "");
         lV69Trn_auditwwds_7_tfauditusername = StringUtil.Concat( StringUtil.RTrim( AV69Trn_auditwwds_7_tfauditusername), "%", "");
         lV71Trn_auditwwds_9_tfaudittablediaplayname = StringUtil.Concat( StringUtil.RTrim( AV71Trn_auditwwds_9_tfaudittablediaplayname), "%", "");
         lV73Trn_auditwwds_11_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV73Trn_auditwwds_11_tfauditshortdescription), "%", "");
         /* Using cursor H006Q3 */
         pr_default.execute(1, new Object[] {AV62Udparg1, AV62Udparg1, AV62Udparg1, AV62Udparg1, AV62Udparg1, AV62Udparg1, AV62Udparg1, AV62Udparg1, AV62Udparg1, AV62Udparg1, AV62Udparg1, lV64Trn_auditwwds_2_filterfulltext, lV64Trn_auditwwds_2_filterfulltext, lV64Trn_auditwwds_2_filterfulltext, lV64Trn_auditwwds_2_filterfulltext, AV65Trn_auditwwds_3_tfauditdate, AV66Trn_auditwwds_4_tfauditdate_to, lV67Trn_auditwwds_5_tfauditaction, AV68Trn_auditwwds_6_tfauditaction_sel, lV69Trn_auditwwds_7_tfauditusername, AV70Trn_auditwwds_8_tfauditusername_sel, lV71Trn_auditwwds_9_tfaudittablediaplayname, AV72Trn_auditwwds_10_tfaudittablediaplayname_sel, lV73Trn_auditwwds_11_tfauditshortdescription, AV74Trn_auditwwds_12_tfauditshortdescription_sel});
         GRID_nRecordCount = H006Q3_AGRID_nRecordCount[0];
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
         AV64Trn_auditwwds_2_filterfulltext = AV15FilterFullText;
         AV65Trn_auditwwds_3_tfauditdate = AV20TFAuditDate;
         AV66Trn_auditwwds_4_tfauditdate_to = AV21TFAuditDate_To;
         AV67Trn_auditwwds_5_tfauditaction = AV35TFAuditAction;
         AV68Trn_auditwwds_6_tfauditaction_sel = AV36TFAuditAction_Sel;
         AV69Trn_auditwwds_7_tfauditusername = AV33TFAuditUserName;
         AV70Trn_auditwwds_8_tfauditusername_sel = AV34TFAuditUserName_Sel;
         AV71Trn_auditwwds_9_tfaudittablediaplayname = AV60TFAuditTableDiaplayName;
         AV72Trn_auditwwds_10_tfaudittablediaplayname_sel = AV61TFAuditTableDiaplayName_Sel;
         AV73Trn_auditwwds_11_tfauditshortdescription = AV29TFAuditShortDescription;
         AV74Trn_auditwwds_12_tfauditshortdescription_sel = AV30TFAuditShortDescription_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV58ColumnsSelector, AV63Pgmname, AV20TFAuditDate, AV21TFAuditDate_To, AV35TFAuditAction, AV36TFAuditAction_Sel, AV33TFAuditUserName, AV34TFAuditUserName_Sel, AV60TFAuditTableDiaplayName, AV61TFAuditTableDiaplayName_Sel, AV29TFAuditShortDescription, AV30TFAuditShortDescription_Sel, AV46IsAuthorized_Display) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV64Trn_auditwwds_2_filterfulltext = AV15FilterFullText;
         AV65Trn_auditwwds_3_tfauditdate = AV20TFAuditDate;
         AV66Trn_auditwwds_4_tfauditdate_to = AV21TFAuditDate_To;
         AV67Trn_auditwwds_5_tfauditaction = AV35TFAuditAction;
         AV68Trn_auditwwds_6_tfauditaction_sel = AV36TFAuditAction_Sel;
         AV69Trn_auditwwds_7_tfauditusername = AV33TFAuditUserName;
         AV70Trn_auditwwds_8_tfauditusername_sel = AV34TFAuditUserName_Sel;
         AV71Trn_auditwwds_9_tfaudittablediaplayname = AV60TFAuditTableDiaplayName;
         AV72Trn_auditwwds_10_tfaudittablediaplayname_sel = AV61TFAuditTableDiaplayName_Sel;
         AV73Trn_auditwwds_11_tfauditshortdescription = AV29TFAuditShortDescription;
         AV74Trn_auditwwds_12_tfauditshortdescription_sel = AV30TFAuditShortDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV58ColumnsSelector, AV63Pgmname, AV20TFAuditDate, AV21TFAuditDate_To, AV35TFAuditAction, AV36TFAuditAction_Sel, AV33TFAuditUserName, AV34TFAuditUserName_Sel, AV60TFAuditTableDiaplayName, AV61TFAuditTableDiaplayName_Sel, AV29TFAuditShortDescription, AV30TFAuditShortDescription_Sel, AV46IsAuthorized_Display) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV64Trn_auditwwds_2_filterfulltext = AV15FilterFullText;
         AV65Trn_auditwwds_3_tfauditdate = AV20TFAuditDate;
         AV66Trn_auditwwds_4_tfauditdate_to = AV21TFAuditDate_To;
         AV67Trn_auditwwds_5_tfauditaction = AV35TFAuditAction;
         AV68Trn_auditwwds_6_tfauditaction_sel = AV36TFAuditAction_Sel;
         AV69Trn_auditwwds_7_tfauditusername = AV33TFAuditUserName;
         AV70Trn_auditwwds_8_tfauditusername_sel = AV34TFAuditUserName_Sel;
         AV71Trn_auditwwds_9_tfaudittablediaplayname = AV60TFAuditTableDiaplayName;
         AV72Trn_auditwwds_10_tfaudittablediaplayname_sel = AV61TFAuditTableDiaplayName_Sel;
         AV73Trn_auditwwds_11_tfauditshortdescription = AV29TFAuditShortDescription;
         AV74Trn_auditwwds_12_tfauditshortdescription_sel = AV30TFAuditShortDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV58ColumnsSelector, AV63Pgmname, AV20TFAuditDate, AV21TFAuditDate_To, AV35TFAuditAction, AV36TFAuditAction_Sel, AV33TFAuditUserName, AV34TFAuditUserName_Sel, AV60TFAuditTableDiaplayName, AV61TFAuditTableDiaplayName_Sel, AV29TFAuditShortDescription, AV30TFAuditShortDescription_Sel, AV46IsAuthorized_Display) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV64Trn_auditwwds_2_filterfulltext = AV15FilterFullText;
         AV65Trn_auditwwds_3_tfauditdate = AV20TFAuditDate;
         AV66Trn_auditwwds_4_tfauditdate_to = AV21TFAuditDate_To;
         AV67Trn_auditwwds_5_tfauditaction = AV35TFAuditAction;
         AV68Trn_auditwwds_6_tfauditaction_sel = AV36TFAuditAction_Sel;
         AV69Trn_auditwwds_7_tfauditusername = AV33TFAuditUserName;
         AV70Trn_auditwwds_8_tfauditusername_sel = AV34TFAuditUserName_Sel;
         AV71Trn_auditwwds_9_tfaudittablediaplayname = AV60TFAuditTableDiaplayName;
         AV72Trn_auditwwds_10_tfaudittablediaplayname_sel = AV61TFAuditTableDiaplayName_Sel;
         AV73Trn_auditwwds_11_tfauditshortdescription = AV29TFAuditShortDescription;
         AV74Trn_auditwwds_12_tfauditshortdescription_sel = AV30TFAuditShortDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV58ColumnsSelector, AV63Pgmname, AV20TFAuditDate, AV21TFAuditDate_To, AV35TFAuditAction, AV36TFAuditAction_Sel, AV33TFAuditUserName, AV34TFAuditUserName_Sel, AV60TFAuditTableDiaplayName, AV61TFAuditTableDiaplayName_Sel, AV29TFAuditShortDescription, AV30TFAuditShortDescription_Sel, AV46IsAuthorized_Display) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV64Trn_auditwwds_2_filterfulltext = AV15FilterFullText;
         AV65Trn_auditwwds_3_tfauditdate = AV20TFAuditDate;
         AV66Trn_auditwwds_4_tfauditdate_to = AV21TFAuditDate_To;
         AV67Trn_auditwwds_5_tfauditaction = AV35TFAuditAction;
         AV68Trn_auditwwds_6_tfauditaction_sel = AV36TFAuditAction_Sel;
         AV69Trn_auditwwds_7_tfauditusername = AV33TFAuditUserName;
         AV70Trn_auditwwds_8_tfauditusername_sel = AV34TFAuditUserName_Sel;
         AV71Trn_auditwwds_9_tfaudittablediaplayname = AV60TFAuditTableDiaplayName;
         AV72Trn_auditwwds_10_tfaudittablediaplayname_sel = AV61TFAuditTableDiaplayName_Sel;
         AV73Trn_auditwwds_11_tfauditshortdescription = AV29TFAuditShortDescription;
         AV74Trn_auditwwds_12_tfauditshortdescription_sel = AV30TFAuditShortDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV19ManageFiltersExecutionStep, AV58ColumnsSelector, AV63Pgmname, AV20TFAuditDate, AV21TFAuditDate_To, AV35TFAuditAction, AV36TFAuditAction_Sel, AV33TFAuditUserName, AV34TFAuditUserName_Sel, AV60TFAuditTableDiaplayName, AV61TFAuditTableDiaplayName_Sel, AV29TFAuditShortDescription, AV30TFAuditShortDescription_Sel, AV46IsAuthorized_Display) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV63Pgmname = "Trn_AuditWW";
         edtavDisplay_Enabled = 0;
         edtAuditDate_Enabled = 0;
         edtAuditId_Enabled = 0;
         edtAuditAction_Enabled = 0;
         edtAuditTableName_Enabled = 0;
         edtAuditDescription_Enabled = 0;
         edtGAMUserId_Enabled = 0;
         edtAuditUserName_Enabled = 0;
         edtAuditTableDiaplayName_Enabled = 0;
         edtAuditShortDescription_Enabled = 0;
         edtOrganisationId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP6Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E166Q2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV17ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV37DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV58ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_35 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_35"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV41GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV42GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV43GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV22DDO_AuditDateAuxDate = context.localUtil.CToD( cgiGet( "vDDO_AUDITDATEAUXDATE"), 0);
            AV23DDO_AuditDateAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_AUDITDATEAUXDATETO"), 0);
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
            /* Read variables values. */
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            AV24DDO_AuditDateAuxDateText = cgiGet( edtavDdo_auditdateauxdatetext_Internalname);
            AssignAttri("", false, "AV24DDO_AuditDateAuxDateText", AV24DDO_AuditDateAuxDateText);
            /* Read subfile selected row values. */
            nGXsfl_35_idx = (int)(Math.Round(context.localUtil.CToN( cgiGet( subGrid_Internalname+"_ROW"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
            if ( nGXsfl_35_idx > 0 )
            {
               A372AuditDate = context.localUtil.CToT( cgiGet( edtAuditDate_Internalname));
               A371AuditId = StringUtil.StrToGuid( cgiGet( edtAuditId_Internalname));
               A378AuditAction = cgiGet( edtAuditAction_Internalname);
               A373AuditTableName = cgiGet( edtAuditTableName_Internalname);
               A374AuditDescription = cgiGet( edtAuditDescription_Internalname);
               A376GAMUserId = cgiGet( edtGAMUserId_Internalname);
               A377AuditUserName = cgiGet( edtAuditUserName_Internalname);
               A491AuditTableDiaplayName = cgiGet( edtAuditTableDiaplayName_Internalname);
               A375AuditShortDescription = cgiGet( edtAuditShortDescription_Internalname);
               A11OrganisationId = StringUtil.StrToGuid( cgiGet( edtOrganisationId_Internalname));
               n11OrganisationId = false;
               AV45Display = cgiGet( edtavDisplay_Internalname);
               AssignAttri("", false, edtavDisplay_Internalname, AV45Display);
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
         E166Q2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E166Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFAUDITDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_auditdateauxdatetext_Internalname});
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
         AV38GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV39GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV38GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = context.GetMessage( " Trn_Audit", "");
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV37DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV37DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E176Q2( )
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
         if ( StringUtil.StrCmp(AV16Session.Get("Trn_AuditWWColumnsSelector"), "") != 0 )
         {
            AV56ColumnsSelectorXML = AV16Session.Get("Trn_AuditWWColumnsSelector");
            AV58ColumnsSelector.FromXml(AV56ColumnsSelectorXML, null, "", "");
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
         edtAuditDate_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV58ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtAuditDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditDate_Visible), 5, 0), !bGXsfl_35_Refreshing);
         edtAuditAction_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV58ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtAuditAction_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditAction_Visible), 5, 0), !bGXsfl_35_Refreshing);
         edtAuditUserName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV58ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtAuditUserName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditUserName_Visible), 5, 0), !bGXsfl_35_Refreshing);
         edtAuditTableDiaplayName_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV58ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtAuditTableDiaplayName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditTableDiaplayName_Visible), 5, 0), !bGXsfl_35_Refreshing);
         edtAuditShortDescription_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV58ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtAuditShortDescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditShortDescription_Visible), 5, 0), !bGXsfl_35_Refreshing);
         AV41GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV41GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV41GridCurrentPage), 10, 0));
         AV42GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV42GridPageCount", StringUtil.LTrimStr( (decimal)(AV42GridPageCount), 10, 0));
         GXt_char2 = AV43GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV63Pgmname, out  GXt_char2) ;
         AV43GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV43GridAppliedFilters", AV43GridAppliedFilters);
         AV64Trn_auditwwds_2_filterfulltext = AV15FilterFullText;
         AV65Trn_auditwwds_3_tfauditdate = AV20TFAuditDate;
         AV66Trn_auditwwds_4_tfauditdate_to = AV21TFAuditDate_To;
         AV67Trn_auditwwds_5_tfauditaction = AV35TFAuditAction;
         AV68Trn_auditwwds_6_tfauditaction_sel = AV36TFAuditAction_Sel;
         AV69Trn_auditwwds_7_tfauditusername = AV33TFAuditUserName;
         AV70Trn_auditwwds_8_tfauditusername_sel = AV34TFAuditUserName_Sel;
         AV71Trn_auditwwds_9_tfaudittablediaplayname = AV60TFAuditTableDiaplayName;
         AV72Trn_auditwwds_10_tfaudittablediaplayname_sel = AV61TFAuditTableDiaplayName_Sel;
         AV73Trn_auditwwds_11_tfauditshortdescription = AV29TFAuditShortDescription;
         AV74Trn_auditwwds_12_tfauditshortdescription_sel = AV30TFAuditShortDescription_Sel;
         AV62Udparg1 = new prc_getuserorganisationid(context).executeUdp( );
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58ColumnsSelector", AV58ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E126Q2( )
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
            AV40PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV40PageToGo) ;
         }
      }

      protected void E136Q2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E146Q2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AuditDate") == 0 )
            {
               AV20TFAuditDate = context.localUtil.CToT( Ddo_grid_Filteredtext_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV20TFAuditDate", context.localUtil.TToC( AV20TFAuditDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV21TFAuditDate_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV21TFAuditDate_To", context.localUtil.TToC( AV21TFAuditDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               if ( ! (DateTime.MinValue==AV21TFAuditDate_To) )
               {
                  AV21TFAuditDate_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV21TFAuditDate_To)), (short)(DateTimeUtil.Month( AV21TFAuditDate_To)), (short)(DateTimeUtil.Day( AV21TFAuditDate_To)), 23, 59, 59);
                  AssignAttri("", false, "AV21TFAuditDate_To", context.localUtil.TToC( AV21TFAuditDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AuditAction") == 0 )
            {
               AV35TFAuditAction = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV35TFAuditAction", AV35TFAuditAction);
               AV36TFAuditAction_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV36TFAuditAction_Sel", AV36TFAuditAction_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AuditUserName") == 0 )
            {
               AV33TFAuditUserName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV33TFAuditUserName", AV33TFAuditUserName);
               AV34TFAuditUserName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV34TFAuditUserName_Sel", AV34TFAuditUserName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AuditTableDiaplayName") == 0 )
            {
               AV60TFAuditTableDiaplayName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV60TFAuditTableDiaplayName", AV60TFAuditTableDiaplayName);
               AV61TFAuditTableDiaplayName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV61TFAuditTableDiaplayName_Sel", AV61TFAuditTableDiaplayName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AuditShortDescription") == 0 )
            {
               AV29TFAuditShortDescription = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV29TFAuditShortDescription", AV29TFAuditShortDescription);
               AV30TFAuditShortDescription_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV30TFAuditShortDescription_Sel", AV30TFAuditShortDescription_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E186Q2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV45Display = "<i class=\"fa fa-search\"></i>";
         AssignAttri("", false, edtavDisplay_Internalname, AV45Display);
         if ( AV46IsAuthorized_Display )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_auditview.aspx"+UrlEncode(A371AuditId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtavDisplay_Link = formatLink("trn_auditview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 35;
         }
         sendrow_352( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_35_Refreshing )
         {
            DoAjaxLoad(35, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E156Q2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV56ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV58ColumnsSelector.FromJSonString(AV56ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "Trn_AuditWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV56ColumnsSelectorXML)) ? "" : AV58ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58ColumnsSelector", AV58ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E116Q2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("Trn_AuditWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV63Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("Trn_AuditWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV19ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV19ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV19ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV18ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "Trn_AuditWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV18ManageFiltersXml = GXt_char2;
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
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV63Pgmname+"GridState",  AV18ManageFiltersXml) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58ColumnsSelector", AV58ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17ManageFiltersData", AV17ManageFiltersData);
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
         AV58ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV58ColumnsSelector,  "AuditDate",  "",  "Date",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV58ColumnsSelector,  "AuditAction",  "",  "Action",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV58ColumnsSelector,  "AuditUserName",  "",  "User Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV58ColumnsSelector,  "AuditTableDiaplayName",  "",  "Table Name",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV58ColumnsSelector,  "AuditShortDescription",  "",  "Description",  true,  "") ;
         GXt_char2 = AV57UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "Trn_AuditWWColumnsSelector", out  GXt_char2) ;
         AV57UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57UserCustomValue)) ) )
         {
            AV59ColumnsSelectorAux.FromXml(AV57UserCustomValue, null, "", "");
            new WorkWithPlus.workwithplus_web.wwp_columnselector_updatecolumns(context ).execute( ref  AV59ColumnsSelectorAux, ref  AV58ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV46IsAuthorized_Display;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "trn_auditview_Execute", out  GXt_boolean3) ;
         AV46IsAuthorized_Display = GXt_boolean3;
         AssignAttri("", false, "AV46IsAuthorized_Display", AV46IsAuthorized_Display);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DISPLAY", GetSecureSignedToken( "", AV46IsAuthorized_Display, context));
         if ( ! ( AV46IsAuthorized_Display ) )
         {
            edtavDisplay_Visible = 0;
            AssignProp("", false, edtavDisplay_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDisplay_Visible), 5, 0), !bGXsfl_35_Refreshing);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV17ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "Trn_AuditWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV17ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV20TFAuditDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV20TFAuditDate", context.localUtil.TToC( AV20TFAuditDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV21TFAuditDate_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV21TFAuditDate_To", context.localUtil.TToC( AV21TFAuditDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV35TFAuditAction = "";
         AssignAttri("", false, "AV35TFAuditAction", AV35TFAuditAction);
         AV36TFAuditAction_Sel = "";
         AssignAttri("", false, "AV36TFAuditAction_Sel", AV36TFAuditAction_Sel);
         AV33TFAuditUserName = "";
         AssignAttri("", false, "AV33TFAuditUserName", AV33TFAuditUserName);
         AV34TFAuditUserName_Sel = "";
         AssignAttri("", false, "AV34TFAuditUserName_Sel", AV34TFAuditUserName_Sel);
         AV60TFAuditTableDiaplayName = "";
         AssignAttri("", false, "AV60TFAuditTableDiaplayName", AV60TFAuditTableDiaplayName);
         AV61TFAuditTableDiaplayName_Sel = "";
         AssignAttri("", false, "AV61TFAuditTableDiaplayName_Sel", AV61TFAuditTableDiaplayName_Sel);
         AV29TFAuditShortDescription = "";
         AssignAttri("", false, "AV29TFAuditShortDescription", AV29TFAuditShortDescription);
         AV30TFAuditShortDescription_Sel = "";
         AssignAttri("", false, "AV30TFAuditShortDescription_Sel", AV30TFAuditShortDescription_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV16Session.Get(AV63Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV63Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV16Session.Get(AV63Pgmname+"GridState"), null, "", "");
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
         AV75GXV1 = 1;
         while ( AV75GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV75GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAUDITDATE") == 0 )
            {
               AV20TFAuditDate = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV20TFAuditDate", context.localUtil.TToC( AV20TFAuditDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV21TFAuditDate_To = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV21TFAuditDate_To", context.localUtil.TToC( AV21TFAuditDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               AV22DDO_AuditDateAuxDate = DateTimeUtil.ResetTime(AV20TFAuditDate);
               AssignAttri("", false, "AV22DDO_AuditDateAuxDate", context.localUtil.Format(AV22DDO_AuditDateAuxDate, "99/99/99"));
               AV23DDO_AuditDateAuxDateTo = DateTimeUtil.ResetTime(AV21TFAuditDate_To);
               AssignAttri("", false, "AV23DDO_AuditDateAuxDateTo", context.localUtil.Format(AV23DDO_AuditDateAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAUDITACTION") == 0 )
            {
               AV35TFAuditAction = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFAuditAction", AV35TFAuditAction);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAUDITACTION_SEL") == 0 )
            {
               AV36TFAuditAction_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFAuditAction_Sel", AV36TFAuditAction_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAUDITUSERNAME") == 0 )
            {
               AV33TFAuditUserName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFAuditUserName", AV33TFAuditUserName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAUDITUSERNAME_SEL") == 0 )
            {
               AV34TFAuditUserName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFAuditUserName_Sel", AV34TFAuditUserName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAUDITTABLEDIAPLAYNAME") == 0 )
            {
               AV60TFAuditTableDiaplayName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV60TFAuditTableDiaplayName", AV60TFAuditTableDiaplayName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAUDITTABLEDIAPLAYNAME_SEL") == 0 )
            {
               AV61TFAuditTableDiaplayName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV61TFAuditTableDiaplayName_Sel", AV61TFAuditTableDiaplayName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAUDITSHORTDESCRIPTION") == 0 )
            {
               AV29TFAuditShortDescription = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFAuditShortDescription", AV29TFAuditShortDescription);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAUDITSHORTDESCRIPTION_SEL") == 0 )
            {
               AV30TFAuditShortDescription_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV30TFAuditShortDescription_Sel", AV30TFAuditShortDescription_Sel);
            }
            AV75GXV1 = (int)(AV75GXV1+1);
         }
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFAuditAction_Sel)),  AV36TFAuditAction_Sel, out  GXt_char2) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFAuditUserName_Sel)),  AV34TFAuditUserName_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV61TFAuditTableDiaplayName_Sel)),  AV61TFAuditTableDiaplayName_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFAuditShortDescription_Sel)),  AV30TFAuditShortDescription_Sel, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFAuditAction)),  AV35TFAuditAction, out  GXt_char7) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFAuditUserName)),  AV33TFAuditUserName, out  GXt_char6) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV60TFAuditTableDiaplayName)),  AV60TFAuditTableDiaplayName, out  GXt_char5) ;
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFAuditShortDescription)),  AV29TFAuditShortDescription, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = ((DateTime.MinValue==AV20TFAuditDate) ? "" : context.localUtil.DToC( AV22DDO_AuditDateAuxDate, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char2;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((DateTime.MinValue==AV21TFAuditDate_To) ? "" : context.localUtil.DToC( AV23DDO_AuditDateAuxDateTo, (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), "/"))+"||||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV16Session.Get(AV63Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFAUDITDATE",  context.GetMessage( "Date", ""),  !((DateTime.MinValue==AV20TFAuditDate)&&(DateTime.MinValue==AV21TFAuditDate_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV20TFAuditDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")),  ((DateTime.MinValue==AV20TFAuditDate) ? "" : StringUtil.Trim( context.localUtil.Format( AV20TFAuditDate, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV21TFAuditDate_To, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")),  ((DateTime.MinValue==AV21TFAuditDate_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV21TFAuditDate_To, "99/99/99 99:99")))) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFAUDITACTION",  context.GetMessage( "Action", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFAuditAction)),  0,  AV35TFAuditAction,  AV35TFAuditAction,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFAuditAction_Sel)),  AV36TFAuditAction_Sel,  AV36TFAuditAction_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFAUDITUSERNAME",  context.GetMessage( "User Name", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFAuditUserName)),  0,  AV33TFAuditUserName,  AV33TFAuditUserName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFAuditUserName_Sel)),  AV34TFAuditUserName_Sel,  AV34TFAuditUserName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFAUDITTABLEDIAPLAYNAME",  context.GetMessage( "Table Name", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV60TFAuditTableDiaplayName)),  0,  AV60TFAuditTableDiaplayName,  AV60TFAuditTableDiaplayName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV61TFAuditTableDiaplayName_Sel)),  AV61TFAuditTableDiaplayName_Sel,  AV61TFAuditTableDiaplayName_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFAUDITSHORTDESCRIPTION",  context.GetMessage( "Description", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFAuditShortDescription)),  0,  AV29TFAuditShortDescription,  AV29TFAuditShortDescription,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFAuditShortDescription_Sel)),  AV30TFAuditShortDescription_Sel,  AV30TFAuditShortDescription_Sel) ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV63Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV63Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Trn_Audit";
         AV16Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
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
         PA6Q2( ) ;
         WS6Q2( ) ;
         WE6Q2( ) ;
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
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256309473787", true, true);
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
         context.AddJavascriptSource("trn_auditww.js", "?20256309473790", false, true);
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

      protected void SubsflControlProps_352( )
      {
         edtAuditDate_Internalname = "AUDITDATE_"+sGXsfl_35_idx;
         edtAuditId_Internalname = "AUDITID_"+sGXsfl_35_idx;
         edtAuditAction_Internalname = "AUDITACTION_"+sGXsfl_35_idx;
         edtAuditTableName_Internalname = "AUDITTABLENAME_"+sGXsfl_35_idx;
         edtAuditDescription_Internalname = "AUDITDESCRIPTION_"+sGXsfl_35_idx;
         edtGAMUserId_Internalname = "GAMUSERID_"+sGXsfl_35_idx;
         edtAuditUserName_Internalname = "AUDITUSERNAME_"+sGXsfl_35_idx;
         edtAuditTableDiaplayName_Internalname = "AUDITTABLEDIAPLAYNAME_"+sGXsfl_35_idx;
         edtAuditShortDescription_Internalname = "AUDITSHORTDESCRIPTION_"+sGXsfl_35_idx;
         edtOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_35_idx;
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_35_idx;
      }

      protected void SubsflControlProps_fel_352( )
      {
         edtAuditDate_Internalname = "AUDITDATE_"+sGXsfl_35_fel_idx;
         edtAuditId_Internalname = "AUDITID_"+sGXsfl_35_fel_idx;
         edtAuditAction_Internalname = "AUDITACTION_"+sGXsfl_35_fel_idx;
         edtAuditTableName_Internalname = "AUDITTABLENAME_"+sGXsfl_35_fel_idx;
         edtAuditDescription_Internalname = "AUDITDESCRIPTION_"+sGXsfl_35_fel_idx;
         edtGAMUserId_Internalname = "GAMUSERID_"+sGXsfl_35_fel_idx;
         edtAuditUserName_Internalname = "AUDITUSERNAME_"+sGXsfl_35_fel_idx;
         edtAuditTableDiaplayName_Internalname = "AUDITTABLEDIAPLAYNAME_"+sGXsfl_35_fel_idx;
         edtAuditShortDescription_Internalname = "AUDITSHORTDESCRIPTION_"+sGXsfl_35_fel_idx;
         edtOrganisationId_Internalname = "ORGANISATIONID_"+sGXsfl_35_fel_idx;
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_35_fel_idx;
      }

      protected void sendrow_352( )
      {
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
         WB6Q0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_35_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_35_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_35_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtAuditDate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditDate_Internalname,context.localUtil.TToC( A372AuditDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A372AuditDate, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtAuditDate_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditId_Internalname,A371AuditId.ToString(),A371AuditId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)35,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtAuditAction_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditAction_Internalname,(string)A378AuditAction,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditAction_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtAuditAction_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditTableName_Internalname,(string)A373AuditTableName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditTableName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditDescription_Internalname,(string)A374AuditDescription,(string)A374AuditDescription,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)35,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtGAMUserId_Internalname,StringUtil.RTrim( A376GAMUserId),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtGAMUserId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMGUID",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtAuditUserName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditUserName_Internalname,(string)A377AuditUserName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditUserName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtAuditUserName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtAuditTableDiaplayName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditTableDiaplayName_Internalname,(string)A491AuditTableDiaplayName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditTableDiaplayName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtAuditTableDiaplayName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtAuditShortDescription_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditShortDescription_Internalname,(string)A375AuditShortDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditShortDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtAuditShortDescription_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)400,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrganisationId_Internalname,A11OrganisationId.ToString(),A11OrganisationId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrganisationId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)35,(short)0,(short)0,(short)0,(bool)true,(string)"Id",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDisplay_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_35_idx + "',35)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV45Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",context.GetMessage( "GXM_display", ""),(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDisplay_Visible,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes6Q2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_35_idx = ((subGrid_Islastpage==1)&&(nGXsfl_35_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_idx+1);
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
         }
         /* End function sendrow_352 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl35( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"35\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtAuditDate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Date", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtAuditAction_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Action", "")) ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtAuditUserName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "User Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtAuditTableDiaplayName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Table Name", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtAuditShortDescription_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Description", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDisplay_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A372AuditDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAuditDate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A371AuditId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A378AuditAction));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAuditAction_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A373AuditTableName));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A374AuditDescription));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A376GAMUserId)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A377AuditUserName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAuditUserName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A491AuditTableDiaplayName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAuditTableDiaplayName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A375AuditShortDescription));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAuditShortDescription_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A11OrganisationId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV45Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Visible), 5, 0, ".", "")));
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
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtAuditDate_Internalname = "AUDITDATE";
         edtAuditId_Internalname = "AUDITID";
         edtAuditAction_Internalname = "AUDITACTION";
         edtAuditTableName_Internalname = "AUDITTABLENAME";
         edtAuditDescription_Internalname = "AUDITDESCRIPTION";
         edtGAMUserId_Internalname = "GAMUSERID";
         edtAuditUserName_Internalname = "AUDITUSERNAME";
         edtAuditTableDiaplayName_Internalname = "AUDITTABLEDIAPLAYNAME";
         edtAuditShortDescription_Internalname = "AUDITSHORTDESCRIPTION";
         edtOrganisationId_Internalname = "ORGANISATIONID";
         edtavDisplay_Internalname = "vDISPLAY";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_auditdateauxdatetext_Internalname = "vDDO_AUDITDATEAUXDATETEXT";
         Tfauditdate_rangepicker_Internalname = "TFAUDITDATE_RANGEPICKER";
         divDdo_auditdateauxdates_Internalname = "DDO_AUDITDATEAUXDATES";
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
         edtavDisplay_Jsonclick = "";
         edtavDisplay_Link = "";
         edtavDisplay_Enabled = 0;
         edtOrganisationId_Jsonclick = "";
         edtAuditShortDescription_Jsonclick = "";
         edtAuditTableDiaplayName_Jsonclick = "";
         edtAuditUserName_Jsonclick = "";
         edtGAMUserId_Jsonclick = "";
         edtAuditDescription_Jsonclick = "";
         edtAuditTableName_Jsonclick = "";
         edtAuditAction_Jsonclick = "";
         edtAuditId_Jsonclick = "";
         edtAuditDate_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWithSelection WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavDisplay_Visible = -1;
         edtAuditShortDescription_Visible = -1;
         edtAuditTableDiaplayName_Visible = -1;
         edtAuditUserName_Visible = -1;
         edtAuditAction_Visible = -1;
         edtAuditDate_Visible = -1;
         edtOrganisationId_Enabled = 0;
         edtAuditShortDescription_Enabled = 0;
         edtAuditTableDiaplayName_Enabled = 0;
         edtAuditUserName_Enabled = 0;
         edtGAMUserId_Enabled = 0;
         edtAuditDescription_Enabled = 0;
         edtAuditTableName_Enabled = 0;
         edtAuditAction_Enabled = 0;
         edtAuditId_Enabled = 0;
         edtAuditDate_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_auditdateauxdatetext_Jsonclick = "";
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Datalistproc = "Trn_AuditWWGetFilterData";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "|T|T|T|T";
         Ddo_grid_Filterisrange = "P||||";
         Ddo_grid_Filtertype = "Date|Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T|T|T||T";
         Ddo_grid_Columnssortvalues = "1|2|3||4";
         Ddo_grid_Columnids = "0:AuditDate|2:AuditAction|6:AuditUserName|7:AuditTableDiaplayName|8:AuditShortDescription";
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
         Form.Caption = context.GetMessage( " Trn_Audit", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV20TFAuditDate","fld":"vTFAUDITDATE","pic":"99/99/99 99:99"},{"av":"AV21TFAuditDate_To","fld":"vTFAUDITDATE_TO","pic":"99/99/99 99:99"},{"av":"AV35TFAuditAction","fld":"vTFAUDITACTION"},{"av":"AV36TFAuditAction_Sel","fld":"vTFAUDITACTION_SEL"},{"av":"AV33TFAuditUserName","fld":"vTFAUDITUSERNAME"},{"av":"AV34TFAuditUserName_Sel","fld":"vTFAUDITUSERNAME_SEL"},{"av":"AV60TFAuditTableDiaplayName","fld":"vTFAUDITTABLEDIAPLAYNAME"},{"av":"AV61TFAuditTableDiaplayName_Sel","fld":"vTFAUDITTABLEDIAPLAYNAME_SEL"},{"av":"AV29TFAuditShortDescription","fld":"vTFAUDITSHORTDESCRIPTION"},{"av":"AV30TFAuditShortDescription_Sel","fld":"vTFAUDITSHORTDESCRIPTION_SEL"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtAuditDate_Visible","ctrl":"AUDITDATE","prop":"Visible"},{"av":"edtAuditAction_Visible","ctrl":"AUDITACTION","prop":"Visible"},{"av":"edtAuditUserName_Visible","ctrl":"AUDITUSERNAME","prop":"Visible"},{"av":"edtAuditTableDiaplayName_Visible","ctrl":"AUDITTABLEDIAPLAYNAME","prop":"Visible"},{"av":"edtAuditShortDescription_Visible","ctrl":"AUDITSHORTDESCRIPTION","prop":"Visible"},{"av":"AV41GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV42GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV43GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"edtavDisplay_Visible","ctrl":"vDISPLAY","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E126Q2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV20TFAuditDate","fld":"vTFAUDITDATE","pic":"99/99/99 99:99"},{"av":"AV21TFAuditDate_To","fld":"vTFAUDITDATE_TO","pic":"99/99/99 99:99"},{"av":"AV35TFAuditAction","fld":"vTFAUDITACTION"},{"av":"AV36TFAuditAction_Sel","fld":"vTFAUDITACTION_SEL"},{"av":"AV33TFAuditUserName","fld":"vTFAUDITUSERNAME"},{"av":"AV34TFAuditUserName_Sel","fld":"vTFAUDITUSERNAME_SEL"},{"av":"AV60TFAuditTableDiaplayName","fld":"vTFAUDITTABLEDIAPLAYNAME"},{"av":"AV61TFAuditTableDiaplayName_Sel","fld":"vTFAUDITTABLEDIAPLAYNAME_SEL"},{"av":"AV29TFAuditShortDescription","fld":"vTFAUDITSHORTDESCRIPTION"},{"av":"AV30TFAuditShortDescription_Sel","fld":"vTFAUDITSHORTDESCRIPTION_SEL"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E136Q2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV20TFAuditDate","fld":"vTFAUDITDATE","pic":"99/99/99 99:99"},{"av":"AV21TFAuditDate_To","fld":"vTFAUDITDATE_TO","pic":"99/99/99 99:99"},{"av":"AV35TFAuditAction","fld":"vTFAUDITACTION"},{"av":"AV36TFAuditAction_Sel","fld":"vTFAUDITACTION_SEL"},{"av":"AV33TFAuditUserName","fld":"vTFAUDITUSERNAME"},{"av":"AV34TFAuditUserName_Sel","fld":"vTFAUDITUSERNAME_SEL"},{"av":"AV60TFAuditTableDiaplayName","fld":"vTFAUDITTABLEDIAPLAYNAME"},{"av":"AV61TFAuditTableDiaplayName_Sel","fld":"vTFAUDITTABLEDIAPLAYNAME_SEL"},{"av":"AV29TFAuditShortDescription","fld":"vTFAUDITSHORTDESCRIPTION"},{"av":"AV30TFAuditShortDescription_Sel","fld":"vTFAUDITSHORTDESCRIPTION_SEL"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E146Q2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV20TFAuditDate","fld":"vTFAUDITDATE","pic":"99/99/99 99:99"},{"av":"AV21TFAuditDate_To","fld":"vTFAUDITDATE_TO","pic":"99/99/99 99:99"},{"av":"AV35TFAuditAction","fld":"vTFAUDITACTION"},{"av":"AV36TFAuditAction_Sel","fld":"vTFAUDITACTION_SEL"},{"av":"AV33TFAuditUserName","fld":"vTFAUDITUSERNAME"},{"av":"AV34TFAuditUserName_Sel","fld":"vTFAUDITUSERNAME_SEL"},{"av":"AV60TFAuditTableDiaplayName","fld":"vTFAUDITTABLEDIAPLAYNAME"},{"av":"AV61TFAuditTableDiaplayName_Sel","fld":"vTFAUDITTABLEDIAPLAYNAME_SEL"},{"av":"AV29TFAuditShortDescription","fld":"vTFAUDITSHORTDESCRIPTION"},{"av":"AV30TFAuditShortDescription_Sel","fld":"vTFAUDITSHORTDESCRIPTION_SEL"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV20TFAuditDate","fld":"vTFAUDITDATE","pic":"99/99/99 99:99"},{"av":"AV21TFAuditDate_To","fld":"vTFAUDITDATE_TO","pic":"99/99/99 99:99"},{"av":"AV35TFAuditAction","fld":"vTFAUDITACTION"},{"av":"AV36TFAuditAction_Sel","fld":"vTFAUDITACTION_SEL"},{"av":"AV33TFAuditUserName","fld":"vTFAUDITUSERNAME"},{"av":"AV34TFAuditUserName_Sel","fld":"vTFAUDITUSERNAME_SEL"},{"av":"AV60TFAuditTableDiaplayName","fld":"vTFAUDITTABLEDIAPLAYNAME"},{"av":"AV61TFAuditTableDiaplayName_Sel","fld":"vTFAUDITTABLEDIAPLAYNAME_SEL"},{"av":"AV29TFAuditShortDescription","fld":"vTFAUDITSHORTDESCRIPTION"},{"av":"AV30TFAuditShortDescription_Sel","fld":"vTFAUDITSHORTDESCRIPTION_SEL"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E186Q2","iparms":[{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"A371AuditId","fld":"AUDITID"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV45Display","fld":"vDISPLAY"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E156Q2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV20TFAuditDate","fld":"vTFAUDITDATE","pic":"99/99/99 99:99"},{"av":"AV21TFAuditDate_To","fld":"vTFAUDITDATE_TO","pic":"99/99/99 99:99"},{"av":"AV35TFAuditAction","fld":"vTFAUDITACTION"},{"av":"AV36TFAuditAction_Sel","fld":"vTFAUDITACTION_SEL"},{"av":"AV33TFAuditUserName","fld":"vTFAUDITUSERNAME"},{"av":"AV34TFAuditUserName_Sel","fld":"vTFAUDITUSERNAME_SEL"},{"av":"AV60TFAuditTableDiaplayName","fld":"vTFAUDITTABLEDIAPLAYNAME"},{"av":"AV61TFAuditTableDiaplayName_Sel","fld":"vTFAUDITTABLEDIAPLAYNAME_SEL"},{"av":"AV29TFAuditShortDescription","fld":"vTFAUDITSHORTDESCRIPTION"},{"av":"AV30TFAuditShortDescription_Sel","fld":"vTFAUDITSHORTDESCRIPTION_SEL"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV58ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtAuditDate_Visible","ctrl":"AUDITDATE","prop":"Visible"},{"av":"edtAuditAction_Visible","ctrl":"AUDITACTION","prop":"Visible"},{"av":"edtAuditUserName_Visible","ctrl":"AUDITUSERNAME","prop":"Visible"},{"av":"edtAuditTableDiaplayName_Visible","ctrl":"AUDITTABLEDIAPLAYNAME","prop":"Visible"},{"av":"edtAuditShortDescription_Visible","ctrl":"AUDITSHORTDESCRIPTION","prop":"Visible"},{"av":"AV41GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV42GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV43GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"edtavDisplay_Visible","ctrl":"vDISPLAY","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV11GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E116Q2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV58ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV20TFAuditDate","fld":"vTFAUDITDATE","pic":"99/99/99 99:99"},{"av":"AV21TFAuditDate_To","fld":"vTFAUDITDATE_TO","pic":"99/99/99 99:99"},{"av":"AV35TFAuditAction","fld":"vTFAUDITACTION"},{"av":"AV36TFAuditAction_Sel","fld":"vTFAUDITACTION_SEL"},{"av":"AV33TFAuditUserName","fld":"vTFAUDITUSERNAME"},{"av":"AV34TFAuditUserName_Sel","fld":"vTFAUDITUSERNAME_SEL"},{"av":"AV60TFAuditTableDiaplayName","fld":"vTFAUDITTABLEDIAPLAYNAME"},{"av":"AV61TFAuditTableDiaplayName_Sel","fld":"vTFAUDITTABLEDIAPLAYNAME_SEL"},{"av":"AV29TFAuditShortDescription","fld":"vTFAUDITSHORTDESCRIPTION"},{"av":"AV30TFAuditShortDescription_Sel","fld":"vTFAUDITSHORTDESCRIPTION_SEL"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV22DDO_AuditDateAuxDate","fld":"vDDO_AUDITDATEAUXDATE"},{"av":"AV23DDO_AuditDateAuxDateTo","fld":"vDDO_AUDITDATEAUXDATETO"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV19ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV11GridState","fld":"vGRIDSTATE"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV20TFAuditDate","fld":"vTFAUDITDATE","pic":"99/99/99 99:99"},{"av":"AV21TFAuditDate_To","fld":"vTFAUDITDATE_TO","pic":"99/99/99 99:99"},{"av":"AV35TFAuditAction","fld":"vTFAUDITACTION"},{"av":"AV36TFAuditAction_Sel","fld":"vTFAUDITACTION_SEL"},{"av":"AV33TFAuditUserName","fld":"vTFAUDITUSERNAME"},{"av":"AV34TFAuditUserName_Sel","fld":"vTFAUDITUSERNAME_SEL"},{"av":"AV60TFAuditTableDiaplayName","fld":"vTFAUDITTABLEDIAPLAYNAME"},{"av":"AV61TFAuditTableDiaplayName_Sel","fld":"vTFAUDITTABLEDIAPLAYNAME_SEL"},{"av":"AV29TFAuditShortDescription","fld":"vTFAUDITSHORTDESCRIPTION"},{"av":"AV30TFAuditShortDescription_Sel","fld":"vTFAUDITSHORTDESCRIPTION_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV22DDO_AuditDateAuxDate","fld":"vDDO_AUDITDATEAUXDATE"},{"av":"AV23DDO_AuditDateAuxDateTo","fld":"vDDO_AUDITDATEAUXDATETO"},{"av":"AV58ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtAuditDate_Visible","ctrl":"AUDITDATE","prop":"Visible"},{"av":"edtAuditAction_Visible","ctrl":"AUDITACTION","prop":"Visible"},{"av":"edtAuditUserName_Visible","ctrl":"AUDITUSERNAME","prop":"Visible"},{"av":"edtAuditTableDiaplayName_Visible","ctrl":"AUDITTABLEDIAPLAYNAME","prop":"Visible"},{"av":"edtAuditShortDescription_Visible","ctrl":"AUDITSHORTDESCRIPTION","prop":"Visible"},{"av":"AV41GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV42GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV43GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV46IsAuthorized_Display","fld":"vISAUTHORIZED_DISPLAY","hsh":true},{"av":"edtavDisplay_Visible","ctrl":"vDISPLAY","prop":"Visible"},{"av":"AV17ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("VALID_AUDITTABLENAME","""{"handler":"Valid_Audittablename","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Display","iparms":[]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV15FilterFullText = "";
         AV58ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV63Pgmname = "";
         AV20TFAuditDate = (DateTime)(DateTime.MinValue);
         AV21TFAuditDate_To = (DateTime)(DateTime.MinValue);
         AV35TFAuditAction = "";
         AV36TFAuditAction_Sel = "";
         AV33TFAuditUserName = "";
         AV34TFAuditUserName_Sel = "";
         AV60TFAuditTableDiaplayName = "";
         AV61TFAuditTableDiaplayName_Sel = "";
         AV29TFAuditShortDescription = "";
         AV30TFAuditShortDescription_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV17ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV43GridAppliedFilters = "";
         AV37DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV22DDO_AuditDateAuxDate = DateTime.MinValue;
         AV23DDO_AuditDateAuxDateTo = DateTime.MinValue;
         AV11GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
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
         bttBtneditcolumns_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV24DDO_AuditDateAuxDateText = "";
         ucTfauditdate_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A372AuditDate = (DateTime)(DateTime.MinValue);
         A371AuditId = Guid.Empty;
         A378AuditAction = "";
         A373AuditTableName = "";
         A374AuditDescription = "";
         A376GAMUserId = "";
         A377AuditUserName = "";
         A491AuditTableDiaplayName = "";
         A375AuditShortDescription = "";
         A11OrganisationId = Guid.Empty;
         AV45Display = "";
         lV64Trn_auditwwds_2_filterfulltext = "";
         lV67Trn_auditwwds_5_tfauditaction = "";
         lV69Trn_auditwwds_7_tfauditusername = "";
         lV71Trn_auditwwds_9_tfaudittablediaplayname = "";
         lV73Trn_auditwwds_11_tfauditshortdescription = "";
         AV64Trn_auditwwds_2_filterfulltext = "";
         AV65Trn_auditwwds_3_tfauditdate = (DateTime)(DateTime.MinValue);
         AV66Trn_auditwwds_4_tfauditdate_to = (DateTime)(DateTime.MinValue);
         AV68Trn_auditwwds_6_tfauditaction_sel = "";
         AV67Trn_auditwwds_5_tfauditaction = "";
         AV70Trn_auditwwds_8_tfauditusername_sel = "";
         AV69Trn_auditwwds_7_tfauditusername = "";
         AV72Trn_auditwwds_10_tfaudittablediaplayname_sel = "";
         AV71Trn_auditwwds_9_tfaudittablediaplayname = "";
         AV74Trn_auditwwds_12_tfauditshortdescription_sel = "";
         AV73Trn_auditwwds_11_tfauditshortdescription = "";
         AV62Udparg1 = Guid.Empty;
         H006Q2_A11OrganisationId = new Guid[] {Guid.Empty} ;
         H006Q2_n11OrganisationId = new bool[] {false} ;
         H006Q2_A375AuditShortDescription = new string[] {""} ;
         H006Q2_A377AuditUserName = new string[] {""} ;
         H006Q2_A376GAMUserId = new string[] {""} ;
         H006Q2_A374AuditDescription = new string[] {""} ;
         H006Q2_A378AuditAction = new string[] {""} ;
         H006Q2_A371AuditId = new Guid[] {Guid.Empty} ;
         H006Q2_A372AuditDate = new DateTime[] {DateTime.MinValue} ;
         H006Q2_A373AuditTableName = new string[] {""} ;
         H006Q3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV38GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV39GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV16Session = context.GetSession();
         AV56ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV18ManageFiltersXml = "";
         AV57UserCustomValue = "";
         AV59ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char2 = "";
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_auditww__default(),
            new Object[][] {
                new Object[] {
               H006Q2_A11OrganisationId, H006Q2_n11OrganisationId, H006Q2_A375AuditShortDescription, H006Q2_A377AuditUserName, H006Q2_A376GAMUserId, H006Q2_A374AuditDescription, H006Q2_A378AuditAction, H006Q2_A371AuditId, H006Q2_A372AuditDate, H006Q2_A373AuditTableName
               }
               , new Object[] {
               H006Q3_AGRID_nRecordCount
               }
            }
         );
         AV63Pgmname = "Trn_AuditWW";
         /* GeneXus formulas. */
         AV63Pgmname = "Trn_AuditWW";
         edtavDisplay_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV19ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
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
      private int nRC_GXsfl_35 ;
      private int nGXsfl_35_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavDisplay_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtAuditDate_Enabled ;
      private int edtAuditId_Enabled ;
      private int edtAuditAction_Enabled ;
      private int edtAuditTableName_Enabled ;
      private int edtAuditDescription_Enabled ;
      private int edtGAMUserId_Enabled ;
      private int edtAuditUserName_Enabled ;
      private int edtAuditTableDiaplayName_Enabled ;
      private int edtAuditShortDescription_Enabled ;
      private int edtOrganisationId_Enabled ;
      private int edtAuditDate_Visible ;
      private int edtAuditAction_Visible ;
      private int edtAuditUserName_Visible ;
      private int edtAuditTableDiaplayName_Visible ;
      private int edtAuditShortDescription_Visible ;
      private int AV40PageToGo ;
      private int edtavDisplay_Visible ;
      private int AV75GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV41GridCurrentPage ;
      private long AV42GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_35_idx="0001" ;
      private string AV63Pgmname ;
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
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
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
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_auditdateauxdates_Internalname ;
      private string edtavDdo_auditdateauxdatetext_Internalname ;
      private string edtavDdo_auditdateauxdatetext_Jsonclick ;
      private string Tfauditdate_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtAuditDate_Internalname ;
      private string edtAuditId_Internalname ;
      private string edtAuditAction_Internalname ;
      private string edtAuditTableName_Internalname ;
      private string edtAuditDescription_Internalname ;
      private string A376GAMUserId ;
      private string edtGAMUserId_Internalname ;
      private string edtAuditUserName_Internalname ;
      private string edtAuditTableDiaplayName_Internalname ;
      private string edtAuditShortDescription_Internalname ;
      private string edtOrganisationId_Internalname ;
      private string AV45Display ;
      private string edtavDisplay_Internalname ;
      private string edtavDisplay_Link ;
      private string GXEncryptionTmp ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char2 ;
      private string sGXsfl_35_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtAuditDate_Jsonclick ;
      private string edtAuditId_Jsonclick ;
      private string edtAuditAction_Jsonclick ;
      private string edtAuditTableName_Jsonclick ;
      private string edtAuditDescription_Jsonclick ;
      private string edtGAMUserId_Jsonclick ;
      private string edtAuditUserName_Jsonclick ;
      private string edtAuditTableDiaplayName_Jsonclick ;
      private string edtAuditShortDescription_Jsonclick ;
      private string edtOrganisationId_Jsonclick ;
      private string edtavDisplay_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV20TFAuditDate ;
      private DateTime AV21TFAuditDate_To ;
      private DateTime A372AuditDate ;
      private DateTime AV65Trn_auditwwds_3_tfauditdate ;
      private DateTime AV66Trn_auditwwds_4_tfauditdate_to ;
      private DateTime AV22DDO_AuditDateAuxDate ;
      private DateTime AV23DDO_AuditDateAuxDateTo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV46IsAuthorized_Display ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n11OrganisationId ;
      private bool bGXsfl_35_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean3 ;
      private string A374AuditDescription ;
      private string AV56ColumnsSelectorXML ;
      private string AV18ManageFiltersXml ;
      private string AV57UserCustomValue ;
      private string AV15FilterFullText ;
      private string AV35TFAuditAction ;
      private string AV36TFAuditAction_Sel ;
      private string AV33TFAuditUserName ;
      private string AV34TFAuditUserName_Sel ;
      private string AV60TFAuditTableDiaplayName ;
      private string AV61TFAuditTableDiaplayName_Sel ;
      private string AV29TFAuditShortDescription ;
      private string AV30TFAuditShortDescription_Sel ;
      private string AV43GridAppliedFilters ;
      private string AV24DDO_AuditDateAuxDateText ;
      private string A378AuditAction ;
      private string A373AuditTableName ;
      private string A377AuditUserName ;
      private string A491AuditTableDiaplayName ;
      private string A375AuditShortDescription ;
      private string lV64Trn_auditwwds_2_filterfulltext ;
      private string lV67Trn_auditwwds_5_tfauditaction ;
      private string lV69Trn_auditwwds_7_tfauditusername ;
      private string lV71Trn_auditwwds_9_tfaudittablediaplayname ;
      private string lV73Trn_auditwwds_11_tfauditshortdescription ;
      private string AV64Trn_auditwwds_2_filterfulltext ;
      private string AV68Trn_auditwwds_6_tfauditaction_sel ;
      private string AV67Trn_auditwwds_5_tfauditaction ;
      private string AV70Trn_auditwwds_8_tfauditusername_sel ;
      private string AV69Trn_auditwwds_7_tfauditusername ;
      private string AV72Trn_auditwwds_10_tfaudittablediaplayname_sel ;
      private string AV71Trn_auditwwds_9_tfaudittablediaplayname ;
      private string AV74Trn_auditwwds_12_tfauditshortdescription_sel ;
      private string AV73Trn_auditwwds_11_tfauditshortdescription ;
      private Guid A371AuditId ;
      private Guid A11OrganisationId ;
      private Guid AV62Udparg1 ;
      private IGxSession AV16Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfauditdate_rangepicker ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV58ColumnsSelector ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV17ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV37DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV11GridState ;
      private IDataStoreProvider pr_default ;
      private Guid[] H006Q2_A11OrganisationId ;
      private bool[] H006Q2_n11OrganisationId ;
      private string[] H006Q2_A375AuditShortDescription ;
      private string[] H006Q2_A377AuditUserName ;
      private string[] H006Q2_A376GAMUserId ;
      private string[] H006Q2_A374AuditDescription ;
      private string[] H006Q2_A378AuditAction ;
      private Guid[] H006Q2_A371AuditId ;
      private DateTime[] H006Q2_A372AuditDate ;
      private string[] H006Q2_A373AuditTableName ;
      private long[] H006Q3_AGRID_nRecordCount ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV38GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV39GAMErrors ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV59ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trn_auditww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H006Q2( IGxContext context ,
                                             string AV64Trn_auditwwds_2_filterfulltext ,
                                             DateTime AV65Trn_auditwwds_3_tfauditdate ,
                                             DateTime AV66Trn_auditwwds_4_tfauditdate_to ,
                                             string AV68Trn_auditwwds_6_tfauditaction_sel ,
                                             string AV67Trn_auditwwds_5_tfauditaction ,
                                             string AV70Trn_auditwwds_8_tfauditusername_sel ,
                                             string AV69Trn_auditwwds_7_tfauditusername ,
                                             string AV72Trn_auditwwds_10_tfaudittablediaplayname_sel ,
                                             string AV71Trn_auditwwds_9_tfaudittablediaplayname ,
                                             string AV74Trn_auditwwds_12_tfauditshortdescription_sel ,
                                             string AV73Trn_auditwwds_11_tfauditshortdescription ,
                                             string A378AuditAction ,
                                             string A377AuditUserName ,
                                             string A373AuditTableName ,
                                             string A375AuditShortDescription ,
                                             DateTime A372AuditDate ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             Guid A11OrganisationId ,
                                             Guid AV62Udparg1 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[18];
         Object[] GXv_Object9 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " OrganisationId, AuditShortDescription, AuditUserName, GAMUserId, AuditDescription, AuditAction, AuditId, AuditDate, AuditTableName";
         sFromString = " FROM Trn_Audit";
         sOrderString = "";
         AddWhere(sWhereString, "(OrganisationId = :AV62Udparg1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_auditwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(AuditAction) like '%' || LOWER(:lV64Trn_auditwwds_2_filterfulltext)) or ( LOWER(AuditUserName) like '%' || LOWER(:lV64Trn_auditwwds_2_filterfulltext)) or ( LOWER(SUBSTR(AuditTableName, 5)) like '%' || LOWER(:lV64Trn_auditwwds_2_filterfulltext)) or ( LOWER(AuditShortDescription) like '%' || LOWER(:lV64Trn_auditwwds_2_filterfulltext)))");
         }
         else
         {
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
            GXv_int8[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV65Trn_auditwwds_3_tfauditdate) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV65Trn_auditwwds_3_tfauditdate)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV66Trn_auditwwds_4_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV66Trn_auditwwds_4_tfauditdate_to)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_auditwwds_6_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_auditwwds_5_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(AuditAction like :lV67Trn_auditwwds_5_tfauditaction)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_auditwwds_6_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV68Trn_auditwwds_6_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditAction = ( :AV68Trn_auditwwds_6_tfauditaction_sel))");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_auditwwds_6_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditAction))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_auditwwds_8_tfauditusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_auditwwds_7_tfauditusername)) ) )
         {
            AddWhere(sWhereString, "(AuditUserName like :lV69Trn_auditwwds_7_tfauditusername)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_auditwwds_8_tfauditusername_sel)) && ! ( StringUtil.StrCmp(AV70Trn_auditwwds_8_tfauditusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditUserName = ( :AV70Trn_auditwwds_8_tfauditusername_sel))");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_auditwwds_8_tfauditusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_auditwwds_10_tfaudittablediaplayname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_auditwwds_9_tfaudittablediaplayname)) ) )
         {
            AddWhere(sWhereString, "(SUBSTR(AuditTableName, 5) like :lV71Trn_auditwwds_9_tfaudittablediaplayname)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_auditwwds_10_tfaudittablediaplayname_sel)) && ! ( StringUtil.StrCmp(AV72Trn_auditwwds_10_tfaudittablediaplayname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SUBSTR(AuditTableName, 5) = ( :AV72Trn_auditwwds_10_tfaudittablediaplayname_sel))");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_auditwwds_10_tfaudittablediaplayname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SUBSTR(AuditTableName, 5)))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_auditwwds_12_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_auditwwds_11_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription like :lV73Trn_auditwwds_11_tfauditshortdescription)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_auditwwds_12_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV74Trn_auditwwds_12_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription = ( :AV74Trn_auditwwds_12_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_auditwwds_12_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditShortDescription))=0))");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY AuditDate, AuditId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY AuditDate DESC, AuditId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY AuditAction, AuditId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY AuditAction DESC, AuditId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY AuditUserName, AuditId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY AuditUserName DESC, AuditId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY AuditShortDescription, AuditId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY AuditShortDescription DESC, AuditId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY AuditId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H006Q3( IGxContext context ,
                                             string AV64Trn_auditwwds_2_filterfulltext ,
                                             DateTime AV65Trn_auditwwds_3_tfauditdate ,
                                             DateTime AV66Trn_auditwwds_4_tfauditdate_to ,
                                             string AV68Trn_auditwwds_6_tfauditaction_sel ,
                                             string AV67Trn_auditwwds_5_tfauditaction ,
                                             string AV70Trn_auditwwds_8_tfauditusername_sel ,
                                             string AV69Trn_auditwwds_7_tfauditusername ,
                                             string AV72Trn_auditwwds_10_tfaudittablediaplayname_sel ,
                                             string AV71Trn_auditwwds_9_tfaudittablediaplayname ,
                                             string AV74Trn_auditwwds_12_tfauditshortdescription_sel ,
                                             string AV73Trn_auditwwds_11_tfauditshortdescription ,
                                             string A378AuditAction ,
                                             string A377AuditUserName ,
                                             string A373AuditTableName ,
                                             string A375AuditShortDescription ,
                                             DateTime A372AuditDate ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             Guid A11OrganisationId ,
                                             Guid AV62Udparg1 )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[25];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM Trn_Audit";
         AddWhere(sWhereString, "(OrganisationId = :AV62Udparg1)");
         AddWhere(sWhereString, "(OrganisationId = :AV62Udparg1)");
         AddWhere(sWhereString, "(OrganisationId = :AV62Udparg1)");
         AddWhere(sWhereString, "(OrganisationId = :AV62Udparg1)");
         AddWhere(sWhereString, "(OrganisationId = :AV62Udparg1)");
         AddWhere(sWhereString, "(OrganisationId = :AV62Udparg1)");
         AddWhere(sWhereString, "(OrganisationId = :AV62Udparg1)");
         AddWhere(sWhereString, "(OrganisationId = :AV62Udparg1)");
         AddWhere(sWhereString, "(OrganisationId = :AV62Udparg1)");
         AddWhere(sWhereString, "(OrganisationId = :AV62Udparg1)");
         AddWhere(sWhereString, "(OrganisationId = :AV62Udparg1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Trn_auditwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(AuditAction) like '%' || LOWER(:lV64Trn_auditwwds_2_filterfulltext)) or ( LOWER(AuditUserName) like '%' || LOWER(:lV64Trn_auditwwds_2_filterfulltext)) or ( LOWER(SUBSTR(AuditTableName, 5)) like '%' || LOWER(:lV64Trn_auditwwds_2_filterfulltext)) or ( LOWER(AuditShortDescription) like '%' || LOWER(:lV64Trn_auditwwds_2_filterfulltext)))");
         }
         else
         {
            GXv_int10[11] = 1;
            GXv_int10[12] = 1;
            GXv_int10[13] = 1;
            GXv_int10[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV65Trn_auditwwds_3_tfauditdate) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV65Trn_auditwwds_3_tfauditdate)");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV66Trn_auditwwds_4_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV66Trn_auditwwds_4_tfauditdate_to)");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_auditwwds_6_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Trn_auditwwds_5_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(AuditAction like :lV67Trn_auditwwds_5_tfauditaction)");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Trn_auditwwds_6_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV68Trn_auditwwds_6_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditAction = ( :AV68Trn_auditwwds_6_tfauditaction_sel))");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( StringUtil.StrCmp(AV68Trn_auditwwds_6_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditAction))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_auditwwds_8_tfauditusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Trn_auditwwds_7_tfauditusername)) ) )
         {
            AddWhere(sWhereString, "(AuditUserName like :lV69Trn_auditwwds_7_tfauditusername)");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Trn_auditwwds_8_tfauditusername_sel)) && ! ( StringUtil.StrCmp(AV70Trn_auditwwds_8_tfauditusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditUserName = ( :AV70Trn_auditwwds_8_tfauditusername_sel))");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( StringUtil.StrCmp(AV70Trn_auditwwds_8_tfauditusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_auditwwds_10_tfaudittablediaplayname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Trn_auditwwds_9_tfaudittablediaplayname)) ) )
         {
            AddWhere(sWhereString, "(SUBSTR(AuditTableName, 5) like :lV71Trn_auditwwds_9_tfaudittablediaplayname)");
         }
         else
         {
            GXv_int10[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Trn_auditwwds_10_tfaudittablediaplayname_sel)) && ! ( StringUtil.StrCmp(AV72Trn_auditwwds_10_tfaudittablediaplayname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SUBSTR(AuditTableName, 5) = ( :AV72Trn_auditwwds_10_tfaudittablediaplayname_sel))");
         }
         else
         {
            GXv_int10[22] = 1;
         }
         if ( StringUtil.StrCmp(AV72Trn_auditwwds_10_tfaudittablediaplayname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SUBSTR(AuditTableName, 5)))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_auditwwds_12_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Trn_auditwwds_11_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription like :lV73Trn_auditwwds_11_tfauditshortdescription)");
         }
         else
         {
            GXv_int10[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Trn_auditwwds_12_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV74Trn_auditwwds_12_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription = ( :AV74Trn_auditwwds_12_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int10[24] = 1;
         }
         if ( StringUtil.StrCmp(AV74Trn_auditwwds_12_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditShortDescription))=0))");
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
                     return conditional_H006Q2(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] , (Guid)dynConstraints[18] , (Guid)dynConstraints[19] );
               case 1 :
                     return conditional_H006Q3(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] , (Guid)dynConstraints[18] , (Guid)dynConstraints[19] );
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
          Object[] prmH006Q2;
          prmH006Q2 = new Object[] {
          new ParDef("AV62Udparg1",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV64Trn_auditwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Trn_auditwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Trn_auditwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Trn_auditwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_auditwwds_3_tfauditdate",GXType.DateTime,8,5) ,
          new ParDef("AV66Trn_auditwwds_4_tfauditdate_to",GXType.DateTime,8,5) ,
          new ParDef("lV67Trn_auditwwds_5_tfauditaction",GXType.VarChar,40,0) ,
          new ParDef("AV68Trn_auditwwds_6_tfauditaction_sel",GXType.VarChar,40,0) ,
          new ParDef("lV69Trn_auditwwds_7_tfauditusername",GXType.VarChar,100,0) ,
          new ParDef("AV70Trn_auditwwds_8_tfauditusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV71Trn_auditwwds_9_tfaudittablediaplayname",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_auditwwds_10_tfaudittablediaplayname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_auditwwds_11_tfauditshortdescription",GXType.VarChar,400,0) ,
          new ParDef("AV74Trn_auditwwds_12_tfauditshortdescription_sel",GXType.VarChar,400,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH006Q3;
          prmH006Q3 = new Object[] {
          new ParDef("AV62Udparg1",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV62Udparg1",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV62Udparg1",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV62Udparg1",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV62Udparg1",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV62Udparg1",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV62Udparg1",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV62Udparg1",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV62Udparg1",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV62Udparg1",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV62Udparg1",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV64Trn_auditwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Trn_auditwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Trn_auditwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Trn_auditwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV65Trn_auditwwds_3_tfauditdate",GXType.DateTime,8,5) ,
          new ParDef("AV66Trn_auditwwds_4_tfauditdate_to",GXType.DateTime,8,5) ,
          new ParDef("lV67Trn_auditwwds_5_tfauditaction",GXType.VarChar,40,0) ,
          new ParDef("AV68Trn_auditwwds_6_tfauditaction_sel",GXType.VarChar,40,0) ,
          new ParDef("lV69Trn_auditwwds_7_tfauditusername",GXType.VarChar,100,0) ,
          new ParDef("AV70Trn_auditwwds_8_tfauditusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV71Trn_auditwwds_9_tfaudittablediaplayname",GXType.VarChar,100,0) ,
          new ParDef("AV72Trn_auditwwds_10_tfaudittablediaplayname_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Trn_auditwwds_11_tfauditshortdescription",GXType.VarChar,400,0) ,
          new ParDef("AV74Trn_auditwwds_12_tfauditshortdescription_sel",GXType.VarChar,400,0)
          };
          def= new CursorDef[] {
              new CursorDef("H006Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006Q2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H006Q3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH006Q3,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 40);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[7])[0] = rslt.getGuid(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
