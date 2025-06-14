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
namespace GeneXus.Programs.workwithplus {
   public class wwp_parameterww : GXDataArea
   {
      public wwp_parameterww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_parameterww( IGxContext context )
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
         nRC_GXsfl_37 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_37"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_37_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_37_idx = GetPar( "sGXsfl_37_idx");
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
         AV16OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV17OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV19FilterFullText = GetPar( "FilterFullText");
         AV29ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV24ColumnsSelector);
         AV53Pgmname = GetPar( "Pgmname");
         AV30TFWWPParameterKey = GetPar( "TFWWPParameterKey");
         AV31TFWWPParameterKey_Sel = GetPar( "TFWWPParameterKey_Sel");
         AV32TFWWPParameterCategory = GetPar( "TFWWPParameterCategory");
         AV33TFWWPParameterCategory_Sel = GetPar( "TFWWPParameterCategory_Sel");
         AV34TFWWPParameterDescription = GetPar( "TFWWPParameterDescription");
         AV35TFWWPParameterDescription_Sel = GetPar( "TFWWPParameterDescription_Sel");
         AV36TFWWPParameterValueTrimmed = GetPar( "TFWWPParameterValueTrimmed");
         AV37TFWWPParameterValueTrimmed_Sel = GetPar( "TFWWPParameterValueTrimmed_Sel");
         AV50IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV51IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV52IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV19FilterFullText, AV29ManageFiltersExecutionStep, AV24ColumnsSelector, AV53Pgmname, AV30TFWWPParameterKey, AV31TFWWPParameterKey_Sel, AV32TFWWPParameterCategory, AV33TFWWPParameterCategory_Sel, AV34TFWWPParameterDescription, AV35TFWWPParameterDescription_Sel, AV36TFWWPParameterValueTrimmed, AV37TFWWPParameterValueTrimmed_Sel, AV50IsAuthorized_Update, AV51IsAuthorized_Delete, AV52IsAuthorized_Insert) ;
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
            return "wwp_parameterww_Execute" ;
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
         PA1J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1J2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.wwp_parameterww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV53Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV50IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV50IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV51IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV51IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV52IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV52IsAuthorized_Insert, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV17OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV19FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_37", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_37), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV27ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV27ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV8GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV38DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV38DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV24ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV24ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV53Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFWWPPARAMETERKEY", AV30TFWWPParameterKey);
         GxWebStd.gx_hidden_field( context, "vTFWWPPARAMETERKEY_SEL", AV31TFWWPParameterKey_Sel);
         GxWebStd.gx_hidden_field( context, "vTFWWPPARAMETERCATEGORY", AV32TFWWPParameterCategory);
         GxWebStd.gx_hidden_field( context, "vTFWWPPARAMETERCATEGORY_SEL", AV33TFWWPParameterCategory_Sel);
         GxWebStd.gx_hidden_field( context, "vTFWWPPARAMETERDESCRIPTION", AV34TFWWPParameterDescription);
         GxWebStd.gx_hidden_field( context, "vTFWWPPARAMETERDESCRIPTION_SEL", AV35TFWWPParameterDescription_Sel);
         GxWebStd.gx_hidden_field( context, "vTFWWPPARAMETERVALUETRIMMED", AV36TFWWPParameterValueTrimmed);
         GxWebStd.gx_hidden_field( context, "vTFWWPPARAMETERVALUETRIMMED_SEL", AV37TFWWPParameterValueTrimmed_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV17OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV50IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV50IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV51IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV51IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "WWPPARAMETERDISABLEDELETE", A110WWPParameterDisableDelete);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV14GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV14GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV52IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV52IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "WWPPARAMETERVALUE", A107WWPParameterValue);
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
            WE1J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1J2( ) ;
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
         return formatLink("workwithplus.wwp_parameterww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WorkWithPlus.WWP_ParameterWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "WWP_Parameter_Transaction_Description", "") ;
      }

      protected void WB1J0( )
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
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/WWP_ParameterWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/WWP_ParameterWW.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV19FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV19FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WorkWithPlus_Web\\WWPFullTextFilter", "start", true, "", "HLP_WorkWithPlus/WWP_ParameterWW.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl37( ) ;
         }
         if ( wbEnd == 37 )
         {
            wbEnd = 0;
            nRC_GXsfl_37 = (int)(nGXsfl_37_idx-1);
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
            ucGridpaginationbar.SetProperty("AppliedFilters", AV8GridAppliedFilters);
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
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV38DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV38DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV24ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 37 )
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

      protected void START1J2( )
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
         Form.Meta.addItem("description", context.GetMessage( "WWP_Parameter_Transaction_Description", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1J0( ) ;
      }

      protected void WS1J2( )
      {
         START1J2( ) ;
         EVT1J2( ) ;
      }

      protected void EVT1J2( )
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
                              E111J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E121J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E131J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E141J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E151J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E161J2 ();
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
                              nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
                              SubsflControlProps_372( ) ;
                              A106WWPParameterKey = cgiGet( edtWWPParameterKey_Internalname);
                              A108WWPParameterCategory = cgiGet( edtWWPParameterCategory_Internalname);
                              A109WWPParameterDescription = cgiGet( edtWWPParameterDescription_Internalname);
                              A111WWPParameterValueTrimmed = cgiGet( edtWWPParameterValueTrimmed_Internalname);
                              AV45Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV45Update);
                              AV46Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV46Delete);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E171J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E181J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E191J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV16OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV17OrderedDsc )
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE1J2( )
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

      protected void PA1J2( )
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
         SubsflControlProps_372( ) ;
         while ( nGXsfl_37_idx <= nRC_GXsfl_37 )
         {
            sendrow_372( ) ;
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV16OrderedBy ,
                                       bool AV17OrderedDsc ,
                                       string AV19FilterFullText ,
                                       short AV29ManageFiltersExecutionStep ,
                                       WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV24ColumnsSelector ,
                                       string AV53Pgmname ,
                                       string AV30TFWWPParameterKey ,
                                       string AV31TFWWPParameterKey_Sel ,
                                       string AV32TFWWPParameterCategory ,
                                       string AV33TFWWPParameterCategory_Sel ,
                                       string AV34TFWWPParameterDescription ,
                                       string AV35TFWWPParameterDescription_Sel ,
                                       string AV36TFWWPParameterValueTrimmed ,
                                       string AV37TFWWPParameterValueTrimmed_Sel ,
                                       bool AV50IsAuthorized_Update ,
                                       bool AV51IsAuthorized_Delete ,
                                       bool AV52IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF1J2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WWPPARAMETERKEY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A106WWPParameterKey, "")), context));
         GxWebStd.gx_hidden_field( context, "WWPPARAMETERKEY", A106WWPParameterKey);
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
         RF1J2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV53Pgmname = "WorkWithPlus.WWP_ParameterWW";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RF1J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E181J2 ();
         nGXsfl_37_idx = 1;
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         bGXsfl_37_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
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
            SubsflControlProps_372( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV54Workwithplus_wwp_parameterwwds_1_filterfulltext ,
                                                 AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ,
                                                 AV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ,
                                                 AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ,
                                                 AV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ,
                                                 AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ,
                                                 AV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ,
                                                 AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ,
                                                 AV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ,
                                                 A106WWPParameterKey ,
                                                 A108WWPParameterCategory ,
                                                 A109WWPParameterDescription ,
                                                 A107WWPParameterValue ,
                                                 AV16OrderedBy ,
                                                 AV17OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV54Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
            lV54Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
            lV54Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
            lV54Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
            lV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = StringUtil.Concat( StringUtil.RTrim( AV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey), "%", "");
            lV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = StringUtil.Concat( StringUtil.RTrim( AV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory), "%", "");
            lV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = StringUtil.Concat( StringUtil.RTrim( AV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription), "%", "");
            lV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = StringUtil.Concat( StringUtil.RTrim( AV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed), "%", "");
            /* Using cursor H001J2 */
            pr_default.execute(0, new Object[] {lV54Workwithplus_wwp_parameterwwds_1_filterfulltext, lV54Workwithplus_wwp_parameterwwds_1_filterfulltext, lV54Workwithplus_wwp_parameterwwds_1_filterfulltext, lV54Workwithplus_wwp_parameterwwds_1_filterfulltext, lV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey, AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, lV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory, AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, lV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription, AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, lV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed, AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A110WWPParameterDisableDelete = H001J2_A110WWPParameterDisableDelete[0];
               A109WWPParameterDescription = H001J2_A109WWPParameterDescription[0];
               A108WWPParameterCategory = H001J2_A108WWPParameterCategory[0];
               A106WWPParameterKey = H001J2_A106WWPParameterKey[0];
               A107WWPParameterValue = H001J2_A107WWPParameterValue[0];
               if ( StringUtil.Len( A107WWPParameterValue) <= 30 )
               {
                  A111WWPParameterValueTrimmed = A107WWPParameterValue;
               }
               else
               {
                  A111WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A107WWPParameterValue, 1, 27)) + "...";
               }
               /* Execute user event: Grid.Load */
               E191J2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 37;
            WB1J0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1J2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV53Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV50IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV50IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV51IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV51IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV52IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV52IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPPARAMETERKEY"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, StringUtil.RTrim( context.localUtil.Format( A106WWPParameterKey, "")), context));
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
         AV54Workwithplus_wwp_parameterwwds_1_filterfulltext = AV19FilterFullText;
         AV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = AV30TFWWPParameterKey;
         AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = AV31TFWWPParameterKey_Sel;
         AV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = AV32TFWWPParameterCategory;
         AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = AV33TFWWPParameterCategory_Sel;
         AV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = AV34TFWWPParameterDescription;
         AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = AV35TFWWPParameterDescription_Sel;
         AV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = AV36TFWWPParameterValueTrimmed;
         AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = AV37TFWWPParameterValueTrimmed_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV54Workwithplus_wwp_parameterwwds_1_filterfulltext ,
                                              AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ,
                                              AV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ,
                                              AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ,
                                              AV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ,
                                              AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ,
                                              AV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ,
                                              AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ,
                                              AV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ,
                                              A106WWPParameterKey ,
                                              A108WWPParameterCategory ,
                                              A109WWPParameterDescription ,
                                              A107WWPParameterValue ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV54Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV54Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV54Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = StringUtil.Concat( StringUtil.RTrim( AV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey), "%", "");
         lV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = StringUtil.Concat( StringUtil.RTrim( AV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory), "%", "");
         lV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = StringUtil.Concat( StringUtil.RTrim( AV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription), "%", "");
         lV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = StringUtil.Concat( StringUtil.RTrim( AV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed), "%", "");
         /* Using cursor H001J3 */
         pr_default.execute(1, new Object[] {lV54Workwithplus_wwp_parameterwwds_1_filterfulltext, lV54Workwithplus_wwp_parameterwwds_1_filterfulltext, lV54Workwithplus_wwp_parameterwwds_1_filterfulltext, lV54Workwithplus_wwp_parameterwwds_1_filterfulltext, lV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey, AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, lV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory, AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, lV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription, AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, lV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed, AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel});
         GRID_nRecordCount = H001J3_AGRID_nRecordCount[0];
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
         AV54Workwithplus_wwp_parameterwwds_1_filterfulltext = AV19FilterFullText;
         AV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = AV30TFWWPParameterKey;
         AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = AV31TFWWPParameterKey_Sel;
         AV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = AV32TFWWPParameterCategory;
         AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = AV33TFWWPParameterCategory_Sel;
         AV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = AV34TFWWPParameterDescription;
         AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = AV35TFWWPParameterDescription_Sel;
         AV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = AV36TFWWPParameterValueTrimmed;
         AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = AV37TFWWPParameterValueTrimmed_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV19FilterFullText, AV29ManageFiltersExecutionStep, AV24ColumnsSelector, AV53Pgmname, AV30TFWWPParameterKey, AV31TFWWPParameterKey_Sel, AV32TFWWPParameterCategory, AV33TFWWPParameterCategory_Sel, AV34TFWWPParameterDescription, AV35TFWWPParameterDescription_Sel, AV36TFWWPParameterValueTrimmed, AV37TFWWPParameterValueTrimmed_Sel, AV50IsAuthorized_Update, AV51IsAuthorized_Delete, AV52IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV54Workwithplus_wwp_parameterwwds_1_filterfulltext = AV19FilterFullText;
         AV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = AV30TFWWPParameterKey;
         AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = AV31TFWWPParameterKey_Sel;
         AV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = AV32TFWWPParameterCategory;
         AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = AV33TFWWPParameterCategory_Sel;
         AV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = AV34TFWWPParameterDescription;
         AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = AV35TFWWPParameterDescription_Sel;
         AV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = AV36TFWWPParameterValueTrimmed;
         AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = AV37TFWWPParameterValueTrimmed_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV19FilterFullText, AV29ManageFiltersExecutionStep, AV24ColumnsSelector, AV53Pgmname, AV30TFWWPParameterKey, AV31TFWWPParameterKey_Sel, AV32TFWWPParameterCategory, AV33TFWWPParameterCategory_Sel, AV34TFWWPParameterDescription, AV35TFWWPParameterDescription_Sel, AV36TFWWPParameterValueTrimmed, AV37TFWWPParameterValueTrimmed_Sel, AV50IsAuthorized_Update, AV51IsAuthorized_Delete, AV52IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV54Workwithplus_wwp_parameterwwds_1_filterfulltext = AV19FilterFullText;
         AV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = AV30TFWWPParameterKey;
         AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = AV31TFWWPParameterKey_Sel;
         AV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = AV32TFWWPParameterCategory;
         AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = AV33TFWWPParameterCategory_Sel;
         AV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = AV34TFWWPParameterDescription;
         AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = AV35TFWWPParameterDescription_Sel;
         AV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = AV36TFWWPParameterValueTrimmed;
         AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = AV37TFWWPParameterValueTrimmed_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV19FilterFullText, AV29ManageFiltersExecutionStep, AV24ColumnsSelector, AV53Pgmname, AV30TFWWPParameterKey, AV31TFWWPParameterKey_Sel, AV32TFWWPParameterCategory, AV33TFWWPParameterCategory_Sel, AV34TFWWPParameterDescription, AV35TFWWPParameterDescription_Sel, AV36TFWWPParameterValueTrimmed, AV37TFWWPParameterValueTrimmed_Sel, AV50IsAuthorized_Update, AV51IsAuthorized_Delete, AV52IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV54Workwithplus_wwp_parameterwwds_1_filterfulltext = AV19FilterFullText;
         AV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = AV30TFWWPParameterKey;
         AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = AV31TFWWPParameterKey_Sel;
         AV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = AV32TFWWPParameterCategory;
         AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = AV33TFWWPParameterCategory_Sel;
         AV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = AV34TFWWPParameterDescription;
         AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = AV35TFWWPParameterDescription_Sel;
         AV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = AV36TFWWPParameterValueTrimmed;
         AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = AV37TFWWPParameterValueTrimmed_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV19FilterFullText, AV29ManageFiltersExecutionStep, AV24ColumnsSelector, AV53Pgmname, AV30TFWWPParameterKey, AV31TFWWPParameterKey_Sel, AV32TFWWPParameterCategory, AV33TFWWPParameterCategory_Sel, AV34TFWWPParameterDescription, AV35TFWWPParameterDescription_Sel, AV36TFWWPParameterValueTrimmed, AV37TFWWPParameterValueTrimmed_Sel, AV50IsAuthorized_Update, AV51IsAuthorized_Delete, AV52IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV54Workwithplus_wwp_parameterwwds_1_filterfulltext = AV19FilterFullText;
         AV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = AV30TFWWPParameterKey;
         AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = AV31TFWWPParameterKey_Sel;
         AV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = AV32TFWWPParameterCategory;
         AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = AV33TFWWPParameterCategory_Sel;
         AV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = AV34TFWWPParameterDescription;
         AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = AV35TFWWPParameterDescription_Sel;
         AV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = AV36TFWWPParameterValueTrimmed;
         AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = AV37TFWWPParameterValueTrimmed_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV19FilterFullText, AV29ManageFiltersExecutionStep, AV24ColumnsSelector, AV53Pgmname, AV30TFWWPParameterKey, AV31TFWWPParameterKey_Sel, AV32TFWWPParameterCategory, AV33TFWWPParameterCategory_Sel, AV34TFWWPParameterDescription, AV35TFWWPParameterDescription_Sel, AV36TFWWPParameterValueTrimmed, AV37TFWWPParameterValueTrimmed_Sel, AV50IsAuthorized_Update, AV51IsAuthorized_Delete, AV52IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV53Pgmname = "WorkWithPlus.WWP_ParameterWW";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtWWPParameterKey_Enabled = 0;
         edtWWPParameterCategory_Enabled = 0;
         edtWWPParameterDescription_Enabled = 0;
         edtWWPParameterValueTrimmed_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E171J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV27ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV38DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV24ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV40GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV41GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV8GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            /* Read variables values. */
            AV19FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV19FilterFullText", AV19FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV16OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV17OrderedDsc )
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
         E171J2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E171J2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV11HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV48GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV49GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV48GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = context.GetMessage( "WWP_Parameter_Transaction_Description", "");
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
         if ( AV16OrderedBy < 1 )
         {
            AV16OrderedBy = 1;
            AssignAttri("", false, "AV16OrderedBy", StringUtil.LTrimStr( (decimal)(AV16OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV38DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV38DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E181J2( )
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
         if ( StringUtil.StrCmp(AV26Session.Get("WorkWithPlus.WWP_ParameterWWColumnsSelector"), "") != 0 )
         {
            AV22ColumnsSelectorXML = AV26Session.Get("WorkWithPlus.WWP_ParameterWWColumnsSelector");
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
         edtWWPParameterKey_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWWPParameterKey_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPParameterKey_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtWWPParameterCategory_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWWPParameterCategory_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPParameterCategory_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtWWPParameterDescription_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWWPParameterDescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPParameterDescription_Visible), 5, 0), !bGXsfl_37_Refreshing);
         edtWWPParameterValueTrimmed_Visible = (((WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector_Column)AV24ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtWWPParameterValueTrimmed_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtWWPParameterValueTrimmed_Visible), 5, 0), !bGXsfl_37_Refreshing);
         AV40GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV40GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV40GridCurrentPage), 10, 0));
         AV41GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV41GridPageCount", StringUtil.LTrimStr( (decimal)(AV41GridPageCount), 10, 0));
         GXt_char2 = AV8GridAppliedFilters;
         new WorkWithPlus.workwithplus_web.wwp_getappliedfiltersdescription(context ).execute(  AV53Pgmname, out  GXt_char2) ;
         AV8GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV8GridAppliedFilters", AV8GridAppliedFilters);
         AV54Workwithplus_wwp_parameterwwds_1_filterfulltext = AV19FilterFullText;
         AV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = AV30TFWWPParameterKey;
         AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = AV31TFWWPParameterKey_Sel;
         AV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = AV32TFWWPParameterCategory;
         AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = AV33TFWWPParameterCategory_Sel;
         AV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = AV34TFWWPParameterDescription;
         AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = AV35TFWWPParameterDescription_Sel;
         AV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = AV36TFWWPParameterValueTrimmed;
         AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = AV37TFWWPParameterValueTrimmed_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ColumnsSelector", AV24ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ManageFiltersData", AV27ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14GridState", AV14GridState);
      }

      protected void E121J2( )
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

      protected void E131J2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E141J2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV16OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV16OrderedBy", StringUtil.LTrimStr( (decimal)(AV16OrderedBy), 4, 0));
            AV17OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV17OrderedDsc", AV17OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPParameterKey") == 0 )
            {
               AV30TFWWPParameterKey = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV30TFWWPParameterKey", AV30TFWWPParameterKey);
               AV31TFWWPParameterKey_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV31TFWWPParameterKey_Sel", AV31TFWWPParameterKey_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPParameterCategory") == 0 )
            {
               AV32TFWWPParameterCategory = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV32TFWWPParameterCategory", AV32TFWWPParameterCategory);
               AV33TFWWPParameterCategory_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV33TFWWPParameterCategory_Sel", AV33TFWWPParameterCategory_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPParameterDescription") == 0 )
            {
               AV34TFWWPParameterDescription = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV34TFWWPParameterDescription", AV34TFWWPParameterDescription);
               AV35TFWWPParameterDescription_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV35TFWWPParameterDescription_Sel", AV35TFWWPParameterDescription_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPParameterValueTrimmed") == 0 )
            {
               AV36TFWWPParameterValueTrimmed = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV36TFWWPParameterValueTrimmed", AV36TFWWPParameterValueTrimmed);
               AV37TFWWPParameterValueTrimmed_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV37TFWWPParameterValueTrimmed_Sel", AV37TFWWPParameterValueTrimmed_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E191J2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV45Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV45Update);
         if ( AV50IsAuthorized_Update )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "workwithplus.wwp_parameter.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim(A106WWPParameterKey));
            edtavUpdate_Link = formatLink("workwithplus.wwp_parameter.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         AV46Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV46Delete);
         if ( AV51IsAuthorized_Delete )
         {
            if ( ! A110WWPParameterDisableDelete )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "workwithplus.wwp_parameter.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.RTrim(A106WWPParameterKey));
               edtavDelete_Link = formatLink("workwithplus.wwp_parameter.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
               edtavDelete_Class = "Attribute";
            }
            else
            {
               edtavDelete_Link = "";
               edtavDelete_Class = "Invisible";
            }
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 37;
         }
         sendrow_372( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_37_Refreshing )
         {
            DoAjaxLoad(37, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E151J2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV22ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV24ColumnsSelector.FromJSonString(AV22ColumnsSelectorXML, null);
         new WorkWithPlus.workwithplus_web.savecolumnsselectorstate(context ).execute(  "WorkWithPlus.WWP_ParameterWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV22ColumnsSelectorXML)) ? "" : AV24ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ColumnsSelector", AV24ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ManageFiltersData", AV27ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14GridState", AV14GridState);
      }

      protected void E111J2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WorkWithPlus.WWP_ParameterWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV53Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV29ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV29ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV29ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WorkWithPlus.WWP_ParameterWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV29ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV29ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV29ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV28ManageFiltersXml;
            new WorkWithPlus.workwithplus_web.getfilterbyname(context ).execute(  "WorkWithPlus.WWP_ParameterWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV28ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28ManageFiltersXml)) )
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
               new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV53Pgmname+"GridState",  AV28ManageFiltersXml) ;
               AV14GridState.FromXml(AV28ManageFiltersXml, null, "", "");
               AV16OrderedBy = AV14GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV16OrderedBy", StringUtil.LTrimStr( (decimal)(AV16OrderedBy), 4, 0));
               AV17OrderedDsc = AV14GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV17OrderedDsc", AV17OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14GridState", AV14GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ColumnsSelector", AV24ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ManageFiltersData", AV27ManageFiltersData);
      }

      protected void E161J2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV52IsAuthorized_Insert )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "workwithplus.wwp_parameter.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim(""));
            CallWebObject(formatLink("workwithplus.wwp_parameter.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14GridState", AV14GridState);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV16OrderedBy), 4, 0))+":"+(AV17OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV24ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "WWPParameterKey",  "",  "WWP_ParameterKey_Attribute_ContextualTitle",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "WWPParameterCategory",  "",  "WWP_ParameterCategory_Attribute_ContextualTitle",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "WWPParameterDescription",  "",  "WWP_ParameterDescription_Attribute_ContextualTitle",  true,  "") ;
         new WorkWithPlus.workwithplus_web.wwp_columnsselector_add(context ).execute( ref  AV24ColumnsSelector,  "WWPParameterValueTrimmed",  "",  "WWP_ParameterValue_Attribute_ContextualTitle",  true,  "") ;
         GXt_char2 = AV23UserCustomValue;
         new WorkWithPlus.workwithplus_web.loadcolumnsselectorstate(context ).execute(  "WorkWithPlus.WWP_ParameterWWColumnsSelector", out  GXt_char2) ;
         AV23UserCustomValue = GXt_char2;
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
         GXt_boolean3 = AV50IsAuthorized_Update;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wwp_parameter_Update", out  GXt_boolean3) ;
         AV50IsAuthorized_Update = GXt_boolean3;
         AssignAttri("", false, "AV50IsAuthorized_Update", AV50IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV50IsAuthorized_Update, context));
         if ( ! ( AV50IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean3 = AV51IsAuthorized_Delete;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wwp_parameter_Delete", out  GXt_boolean3) ;
         AV51IsAuthorized_Delete = GXt_boolean3;
         AssignAttri("", false, "AV51IsAuthorized_Delete", AV51IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV51IsAuthorized_Delete, context));
         if ( ! ( AV51IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean3 = AV52IsAuthorized_Insert;
         new WorkWithPlus.workwithplus_commongam.secgamisauthbyfunctionalitykey(context ).execute(  "wwp_parameter_Insert", out  GXt_boolean3) ;
         AV52IsAuthorized_Insert = GXt_boolean3;
         AssignAttri("", false, "AV52IsAuthorized_Insert", AV52IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV52IsAuthorized_Insert, context));
         if ( ! ( AV52IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV27ManageFiltersData;
         new WorkWithPlus.workwithplus_web.wwp_managefiltersloadsavedfilters(context ).execute(  "WorkWithPlus.WWP_ParameterWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV27ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV19FilterFullText = "";
         AssignAttri("", false, "AV19FilterFullText", AV19FilterFullText);
         AV30TFWWPParameterKey = "";
         AssignAttri("", false, "AV30TFWWPParameterKey", AV30TFWWPParameterKey);
         AV31TFWWPParameterKey_Sel = "";
         AssignAttri("", false, "AV31TFWWPParameterKey_Sel", AV31TFWWPParameterKey_Sel);
         AV32TFWWPParameterCategory = "";
         AssignAttri("", false, "AV32TFWWPParameterCategory", AV32TFWWPParameterCategory);
         AV33TFWWPParameterCategory_Sel = "";
         AssignAttri("", false, "AV33TFWWPParameterCategory_Sel", AV33TFWWPParameterCategory_Sel);
         AV34TFWWPParameterDescription = "";
         AssignAttri("", false, "AV34TFWWPParameterDescription", AV34TFWWPParameterDescription);
         AV35TFWWPParameterDescription_Sel = "";
         AssignAttri("", false, "AV35TFWWPParameterDescription_Sel", AV35TFWWPParameterDescription_Sel);
         AV36TFWWPParameterValueTrimmed = "";
         AssignAttri("", false, "AV36TFWWPParameterValueTrimmed", AV36TFWWPParameterValueTrimmed);
         AV37TFWWPParameterValueTrimmed_Sel = "";
         AssignAttri("", false, "AV37TFWWPParameterValueTrimmed_Sel", AV37TFWWPParameterValueTrimmed_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26Session.Get(AV53Pgmname+"GridState"), "") == 0 )
         {
            AV14GridState.FromXml(new WorkWithPlus.workwithplus_web.loadgridstate(context).executeUdp(  AV53Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV14GridState.FromXml(AV26Session.Get(AV53Pgmname+"GridState"), null, "", "");
         }
         AV16OrderedBy = AV14GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV16OrderedBy", StringUtil.LTrimStr( (decimal)(AV16OrderedBy), 4, 0));
         AV17OrderedDsc = AV14GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV17OrderedDsc", AV17OrderedDsc);
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV14GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV14GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV14GridState.gxTpr_Currentpage) ;
      }

      protected void S192( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV63GXV1 = 1;
         while ( AV63GXV1 <= AV14GridState.gxTpr_Filtervalues.Count )
         {
            AV15GridStateFilterValue = ((WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue)AV14GridState.gxTpr_Filtervalues.Item(AV63GXV1));
            if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV19FilterFullText", AV19FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERKEY") == 0 )
            {
               AV30TFWWPParameterKey = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV30TFWWPParameterKey", AV30TFWWPParameterKey);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERKEY_SEL") == 0 )
            {
               AV31TFWWPParameterKey_Sel = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFWWPParameterKey_Sel", AV31TFWWPParameterKey_Sel);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERCATEGORY") == 0 )
            {
               AV32TFWWPParameterCategory = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFWWPParameterCategory", AV32TFWWPParameterCategory);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERCATEGORY_SEL") == 0 )
            {
               AV33TFWWPParameterCategory_Sel = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFWWPParameterCategory_Sel", AV33TFWWPParameterCategory_Sel);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERDESCRIPTION") == 0 )
            {
               AV34TFWWPParameterDescription = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFWWPParameterDescription", AV34TFWWPParameterDescription);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERDESCRIPTION_SEL") == 0 )
            {
               AV35TFWWPParameterDescription_Sel = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFWWPParameterDescription_Sel", AV35TFWWPParameterDescription_Sel);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERVALUETRIMMED") == 0 )
            {
               AV36TFWWPParameterValueTrimmed = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFWWPParameterValueTrimmed", AV36TFWWPParameterValueTrimmed);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERVALUETRIMMED_SEL") == 0 )
            {
               AV37TFWWPParameterValueTrimmed_Sel = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFWWPParameterValueTrimmed_Sel", AV37TFWWPParameterValueTrimmed_Sel);
            }
            AV63GXV1 = (int)(AV63GXV1+1);
         }
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFWWPParameterKey_Sel)),  AV31TFWWPParameterKey_Sel, out  GXt_char2) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFWWPParameterCategory_Sel)),  AV33TFWWPParameterCategory_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFWWPParameterDescription_Sel)),  AV35TFWWPParameterDescription_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFWWPParameterValueTrimmed_Sel)),  AV37TFWWPParameterValueTrimmed_Sel, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFWWPParameterKey)),  AV30TFWWPParameterKey, out  GXt_char7) ;
         GXt_char6 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFWWPParameterCategory)),  AV32TFWWPParameterCategory, out  GXt_char6) ;
         GXt_char5 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFWWPParameterDescription)),  AV34TFWWPParameterDescription, out  GXt_char5) ;
         GXt_char2 = "";
         new WorkWithPlus.workwithplus_web.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFWWPParameterValueTrimmed)),  AV36TFWWPParameterValueTrimmed, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char2;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV14GridState.FromXml(AV26Session.Get(AV53Pgmname+"GridState"), null, "", "");
         AV14GridState.gxTpr_Orderedby = AV16OrderedBy;
         AV14GridState.gxTpr_Ordereddsc = AV17OrderedDsc;
         AV14GridState.gxTpr_Filtervalues.Clear();
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalue(context ).execute( ref  AV14GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)),  0,  AV19FilterFullText,  AV19FilterFullText,  false,  "",  "") ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV14GridState,  "TFWWPPARAMETERKEY",  context.GetMessage( "WWP_ParameterKey_Attribute_ContextualTitle", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFWWPParameterKey)),  0,  AV30TFWWPParameterKey,  AV30TFWWPParameterKey,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFWWPParameterKey_Sel)),  AV31TFWWPParameterKey_Sel,  AV31TFWWPParameterKey_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV14GridState,  "TFWWPPARAMETERCATEGORY",  context.GetMessage( "WWP_ParameterCategory_Attribute_ContextualTitle", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFWWPParameterCategory)),  0,  AV32TFWWPParameterCategory,  AV32TFWWPParameterCategory,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFWWPParameterCategory_Sel)),  AV33TFWWPParameterCategory_Sel,  AV33TFWWPParameterCategory_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV14GridState,  "TFWWPPARAMETERDESCRIPTION",  context.GetMessage( "WWP_ParameterDescription_Attribute_ContextualTitle", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFWWPParameterDescription)),  0,  AV34TFWWPParameterDescription,  AV34TFWWPParameterDescription,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFWWPParameterDescription_Sel)),  AV35TFWWPParameterDescription_Sel,  AV35TFWWPParameterDescription_Sel) ;
         new WorkWithPlus.workwithplus_web.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV14GridState,  "TFWWPPARAMETERVALUETRIMMED",  context.GetMessage( "WWP_ParameterValue_Attribute_ContextualTitle", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFWWPParameterValueTrimmed)),  0,  AV36TFWWPParameterValueTrimmed,  AV36TFWWPParameterValueTrimmed,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFWWPParameterValueTrimmed_Sel)),  AV37TFWWPParameterValueTrimmed_Sel,  AV37TFWWPParameterValueTrimmed_Sel) ;
         AV14GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV14GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new WorkWithPlus.workwithplus_web.savegridstate(context ).execute(  AV53Pgmname+"GridState",  AV14GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV12TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12TrnContext.gxTpr_Callerobject = AV53Pgmname;
         AV12TrnContext.gxTpr_Callerondelete = true;
         AV12TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV12TrnContext.gxTpr_Transactionname = "WorkWithPlus.WWP_Parameter";
         AV26Session.Set("TrnContext", AV12TrnContext.ToXml(false, true, "", ""));
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
         PA1J2( ) ;
         WS1J2( ) ;
         WE1J2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025614539473", true, true);
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
         context.AddJavascriptSource("workwithplus/wwp_parameterww.js", "?2025614539477", false, true);
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
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_372( )
      {
         edtWWPParameterKey_Internalname = "WWPPARAMETERKEY_"+sGXsfl_37_idx;
         edtWWPParameterCategory_Internalname = "WWPPARAMETERCATEGORY_"+sGXsfl_37_idx;
         edtWWPParameterDescription_Internalname = "WWPPARAMETERDESCRIPTION_"+sGXsfl_37_idx;
         edtWWPParameterValueTrimmed_Internalname = "WWPPARAMETERVALUETRIMMED_"+sGXsfl_37_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_37_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         edtWWPParameterKey_Internalname = "WWPPARAMETERKEY_"+sGXsfl_37_fel_idx;
         edtWWPParameterCategory_Internalname = "WWPPARAMETERCATEGORY_"+sGXsfl_37_fel_idx;
         edtWWPParameterDescription_Internalname = "WWPPARAMETERDESCRIPTION_"+sGXsfl_37_fel_idx;
         edtWWPParameterValueTrimmed_Internalname = "WWPPARAMETERVALUETRIMMED_"+sGXsfl_37_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_37_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WB1J0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_37_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_37_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_37_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtWWPParameterKey_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPParameterKey_Internalname,(string)A106WWPParameterKey,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPParameterKey_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWWPParameterKey_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtWWPParameterCategory_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPParameterCategory_Internalname,(string)A108WWPParameterCategory,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPParameterCategory_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWWPParameterCategory_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtWWPParameterDescription_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPParameterDescription_Internalname,(string)A109WWPParameterDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPParameterDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWWPParameterDescription_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtWWPParameterValueTrimmed_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPParameterValueTrimmed_Internalname,(string)A111WWPParameterValueTrimmed,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPParameterValueTrimmed_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtWWPParameterValueTrimmed_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV45Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",context.GetMessage( "Edit", ""),(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = edtavDelete_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV46Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",context.GetMessage( "GX_BtnDelete", ""),(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)edtavDelete_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes1J2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         /* End function sendrow_372 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl37( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"37\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWWPParameterKey_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_ParameterKey_Attribute_ContextualTitle", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWWPParameterCategory_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_ParameterCategory_Attribute_ContextualTitle", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWWPParameterDescription_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_ParameterDescription_Attribute_ContextualTitle", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtWWPParameterValueTrimmed_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "WWP_ParameterValue_Attribute_ContextualTitle", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavDelete_Class+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
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
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A106WWPParameterKey));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPParameterKey_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A108WWPParameterCategory));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPParameterCategory_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A109WWPParameterDescription));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPParameterDescription_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A111WWPParameterValueTrimmed));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPParameterValueTrimmed_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV45Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV46Delete)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavDelete_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
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
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtWWPParameterKey_Internalname = "WWPPARAMETERKEY";
         edtWWPParameterCategory_Internalname = "WWPPARAMETERCATEGORY";
         edtWWPParameterDescription_Internalname = "WWPPARAMETERDESCRIPTION";
         edtWWPParameterValueTrimmed_Internalname = "WWPPARAMETERVALUETRIMMED";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
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
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Class = "Attribute";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         edtWWPParameterValueTrimmed_Jsonclick = "";
         edtWWPParameterDescription_Jsonclick = "";
         edtWWPParameterCategory_Jsonclick = "";
         edtWWPParameterKey_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtWWPParameterValueTrimmed_Visible = -1;
         edtWWPParameterDescription_Visible = -1;
         edtWWPParameterCategory_Visible = -1;
         edtWWPParameterKey_Visible = -1;
         edtWWPParameterValueTrimmed_Enabled = 0;
         edtWWPParameterDescription_Enabled = 0;
         edtWWPParameterCategory_Enabled = 0;
         edtWWPParameterKey_Enabled = 0;
         subGrid_Sortable = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Datalistproc = "WorkWithPlus.WWP_ParameterWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T|T|T|";
         Ddo_grid_Columnssortvalues = "1|2|3|";
         Ddo_grid_Columnids = "0:WWPParameterKey|1:WWPParameterCategory|2:WWPParameterDescription|3:WWPParameterValueTrimmed";
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
         Form.Caption = context.GetMessage( "WWP_Parameter_Transaction_Description", "");
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV30TFWWPParameterKey","fld":"vTFWWPPARAMETERKEY"},{"av":"AV31TFWWPParameterKey_Sel","fld":"vTFWWPPARAMETERKEY_SEL"},{"av":"AV32TFWWPParameterCategory","fld":"vTFWWPPARAMETERCATEGORY"},{"av":"AV33TFWWPParameterCategory_Sel","fld":"vTFWWPPARAMETERCATEGORY_SEL"},{"av":"AV34TFWWPParameterDescription","fld":"vTFWWPPARAMETERDESCRIPTION"},{"av":"AV35TFWWPParameterDescription_Sel","fld":"vTFWWPPARAMETERDESCRIPTION_SEL"},{"av":"AV36TFWWPParameterValueTrimmed","fld":"vTFWWPPARAMETERVALUETRIMMED"},{"av":"AV37TFWWPParameterValueTrimmed_Sel","fld":"vTFWWPPARAMETERVALUETRIMMED_SEL"},{"av":"AV50IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV51IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV52IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPParameterKey_Visible","ctrl":"WWPPARAMETERKEY","prop":"Visible"},{"av":"edtWWPParameterCategory_Visible","ctrl":"WWPPARAMETERCATEGORY","prop":"Visible"},{"av":"edtWWPParameterDescription_Visible","ctrl":"WWPPARAMETERDESCRIPTION","prop":"Visible"},{"av":"edtWWPParameterValueTrimmed_Visible","ctrl":"WWPPARAMETERVALUETRIMMED","prop":"Visible"},{"av":"AV40GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV41GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV8GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV50IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV51IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV52IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV27ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV14GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E121J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV30TFWWPParameterKey","fld":"vTFWWPPARAMETERKEY"},{"av":"AV31TFWWPParameterKey_Sel","fld":"vTFWWPPARAMETERKEY_SEL"},{"av":"AV32TFWWPParameterCategory","fld":"vTFWWPPARAMETERCATEGORY"},{"av":"AV33TFWWPParameterCategory_Sel","fld":"vTFWWPPARAMETERCATEGORY_SEL"},{"av":"AV34TFWWPParameterDescription","fld":"vTFWWPPARAMETERDESCRIPTION"},{"av":"AV35TFWWPParameterDescription_Sel","fld":"vTFWWPPARAMETERDESCRIPTION_SEL"},{"av":"AV36TFWWPParameterValueTrimmed","fld":"vTFWWPPARAMETERVALUETRIMMED"},{"av":"AV37TFWWPParameterValueTrimmed_Sel","fld":"vTFWWPPARAMETERVALUETRIMMED_SEL"},{"av":"AV50IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV51IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV52IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E131J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV30TFWWPParameterKey","fld":"vTFWWPPARAMETERKEY"},{"av":"AV31TFWWPParameterKey_Sel","fld":"vTFWWPPARAMETERKEY_SEL"},{"av":"AV32TFWWPParameterCategory","fld":"vTFWWPPARAMETERCATEGORY"},{"av":"AV33TFWWPParameterCategory_Sel","fld":"vTFWWPPARAMETERCATEGORY_SEL"},{"av":"AV34TFWWPParameterDescription","fld":"vTFWWPPARAMETERDESCRIPTION"},{"av":"AV35TFWWPParameterDescription_Sel","fld":"vTFWWPPARAMETERDESCRIPTION_SEL"},{"av":"AV36TFWWPParameterValueTrimmed","fld":"vTFWWPPARAMETERVALUETRIMMED"},{"av":"AV37TFWWPParameterValueTrimmed_Sel","fld":"vTFWWPPARAMETERVALUETRIMMED_SEL"},{"av":"AV50IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV51IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV52IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E141J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV30TFWWPParameterKey","fld":"vTFWWPPARAMETERKEY"},{"av":"AV31TFWWPParameterKey_Sel","fld":"vTFWWPPARAMETERKEY_SEL"},{"av":"AV32TFWWPParameterCategory","fld":"vTFWWPPARAMETERCATEGORY"},{"av":"AV33TFWWPParameterCategory_Sel","fld":"vTFWWPPARAMETERCATEGORY_SEL"},{"av":"AV34TFWWPParameterDescription","fld":"vTFWWPPARAMETERDESCRIPTION"},{"av":"AV35TFWWPParameterDescription_Sel","fld":"vTFWWPPARAMETERDESCRIPTION_SEL"},{"av":"AV36TFWWPParameterValueTrimmed","fld":"vTFWWPPARAMETERVALUETRIMMED"},{"av":"AV37TFWWPParameterValueTrimmed_Sel","fld":"vTFWWPPARAMETERVALUETRIMMED_SEL"},{"av":"AV50IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV51IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV52IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV30TFWWPParameterKey","fld":"vTFWWPPARAMETERKEY"},{"av":"AV31TFWWPParameterKey_Sel","fld":"vTFWWPPARAMETERKEY_SEL"},{"av":"AV32TFWWPParameterCategory","fld":"vTFWWPPARAMETERCATEGORY"},{"av":"AV33TFWWPParameterCategory_Sel","fld":"vTFWWPPARAMETERCATEGORY_SEL"},{"av":"AV34TFWWPParameterDescription","fld":"vTFWWPPARAMETERDESCRIPTION"},{"av":"AV35TFWWPParameterDescription_Sel","fld":"vTFWWPPARAMETERDESCRIPTION_SEL"},{"av":"AV36TFWWPParameterValueTrimmed","fld":"vTFWWPPARAMETERVALUETRIMMED"},{"av":"AV37TFWWPParameterValueTrimmed_Sel","fld":"vTFWWPPARAMETERVALUETRIMMED_SEL"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E191J2","iparms":[{"av":"AV50IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"A106WWPParameterKey","fld":"WWPPARAMETERKEY","hsh":true},{"av":"AV51IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"A110WWPParameterDisableDelete","fld":"WWPPARAMETERDISABLEDELETE"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV45Update","fld":"vUPDATE"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"AV46Delete","fld":"vDELETE"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"},{"av":"edtavDelete_Class","ctrl":"vDELETE","prop":"Class"}]}""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","""{"handler":"E151J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV30TFWWPParameterKey","fld":"vTFWWPPARAMETERKEY"},{"av":"AV31TFWWPParameterKey_Sel","fld":"vTFWWPPARAMETERKEY_SEL"},{"av":"AV32TFWWPParameterCategory","fld":"vTFWWPPARAMETERCATEGORY"},{"av":"AV33TFWWPParameterCategory_Sel","fld":"vTFWWPPARAMETERCATEGORY_SEL"},{"av":"AV34TFWWPParameterDescription","fld":"vTFWWPPARAMETERDESCRIPTION"},{"av":"AV35TFWWPParameterDescription_Sel","fld":"vTFWWPPARAMETERDESCRIPTION_SEL"},{"av":"AV36TFWWPParameterValueTrimmed","fld":"vTFWWPPARAMETERVALUETRIMMED"},{"av":"AV37TFWWPParameterValueTrimmed_Sel","fld":"vTFWWPPARAMETERVALUETRIMMED_SEL"},{"av":"AV50IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV51IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV52IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_gridcolumnsselector_Columnsselectorvalues","ctrl":"DDO_GRIDCOLUMNSSELECTOR","prop":"ColumnsSelectorValues"}]""");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",""","oparms":[{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"edtWWPParameterKey_Visible","ctrl":"WWPPARAMETERKEY","prop":"Visible"},{"av":"edtWWPParameterCategory_Visible","ctrl":"WWPPARAMETERCATEGORY","prop":"Visible"},{"av":"edtWWPParameterDescription_Visible","ctrl":"WWPPARAMETERDESCRIPTION","prop":"Visible"},{"av":"edtWWPParameterValueTrimmed_Visible","ctrl":"WWPPARAMETERVALUETRIMMED","prop":"Visible"},{"av":"AV40GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV41GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV8GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV50IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV51IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV52IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV27ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV14GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E111J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV30TFWWPParameterKey","fld":"vTFWWPPARAMETERKEY"},{"av":"AV31TFWWPParameterKey_Sel","fld":"vTFWWPPARAMETERKEY_SEL"},{"av":"AV32TFWWPParameterCategory","fld":"vTFWWPPARAMETERCATEGORY"},{"av":"AV33TFWWPParameterCategory_Sel","fld":"vTFWWPPARAMETERCATEGORY_SEL"},{"av":"AV34TFWWPParameterDescription","fld":"vTFWWPPARAMETERDESCRIPTION"},{"av":"AV35TFWWPParameterDescription_Sel","fld":"vTFWWPPARAMETERDESCRIPTION_SEL"},{"av":"AV36TFWWPParameterValueTrimmed","fld":"vTFWWPPARAMETERVALUETRIMMED"},{"av":"AV37TFWWPParameterValueTrimmed_Sel","fld":"vTFWWPPARAMETERVALUETRIMMED_SEL"},{"av":"AV50IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV51IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV52IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV14GridState","fld":"vGRIDSTATE"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV14GridState","fld":"vGRIDSTATE"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV30TFWWPParameterKey","fld":"vTFWWPPARAMETERKEY"},{"av":"AV31TFWWPParameterKey_Sel","fld":"vTFWWPPARAMETERKEY_SEL"},{"av":"AV32TFWWPParameterCategory","fld":"vTFWWPPARAMETERCATEGORY"},{"av":"AV33TFWWPParameterCategory_Sel","fld":"vTFWWPPARAMETERCATEGORY_SEL"},{"av":"AV34TFWWPParameterDescription","fld":"vTFWWPPARAMETERDESCRIPTION"},{"av":"AV35TFWWPParameterDescription_Sel","fld":"vTFWWPPARAMETERDESCRIPTION_SEL"},{"av":"AV36TFWWPParameterValueTrimmed","fld":"vTFWWPPARAMETERVALUETRIMMED"},{"av":"AV37TFWWPParameterValueTrimmed_Sel","fld":"vTFWWPPARAMETERVALUETRIMMED_SEL"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPParameterKey_Visible","ctrl":"WWPPARAMETERKEY","prop":"Visible"},{"av":"edtWWPParameterCategory_Visible","ctrl":"WWPPARAMETERCATEGORY","prop":"Visible"},{"av":"edtWWPParameterDescription_Visible","ctrl":"WWPPARAMETERDESCRIPTION","prop":"Visible"},{"av":"edtWWPParameterValueTrimmed_Visible","ctrl":"WWPPARAMETERVALUETRIMMED","prop":"Visible"},{"av":"AV40GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV41GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV8GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV50IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV51IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV52IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV27ManageFiltersData","fld":"vMANAGEFILTERSDATA"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E161J2","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"AV53Pgmname","fld":"vPGMNAME","hsh":true},{"av":"AV30TFWWPParameterKey","fld":"vTFWWPPARAMETERKEY"},{"av":"AV31TFWWPParameterKey_Sel","fld":"vTFWWPPARAMETERKEY_SEL"},{"av":"AV32TFWWPParameterCategory","fld":"vTFWWPPARAMETERCATEGORY"},{"av":"AV33TFWWPParameterCategory_Sel","fld":"vTFWWPPARAMETERCATEGORY_SEL"},{"av":"AV34TFWWPParameterDescription","fld":"vTFWWPPARAMETERDESCRIPTION"},{"av":"AV35TFWWPParameterDescription_Sel","fld":"vTFWWPPARAMETERDESCRIPTION_SEL"},{"av":"AV36TFWWPParameterValueTrimmed","fld":"vTFWWPPARAMETERVALUETRIMMED"},{"av":"AV37TFWWPParameterValueTrimmed_Sel","fld":"vTFWWPPARAMETERVALUETRIMMED_SEL"},{"av":"AV50IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"AV51IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"AV52IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"av":"A106WWPParameterKey","fld":"WWPPARAMETERKEY","hsh":true}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9"},{"av":"AV24ColumnsSelector","fld":"vCOLUMNSSELECTOR"},{"av":"edtWWPParameterKey_Visible","ctrl":"WWPPARAMETERKEY","prop":"Visible"},{"av":"edtWWPParameterCategory_Visible","ctrl":"WWPPARAMETERCATEGORY","prop":"Visible"},{"av":"edtWWPParameterDescription_Visible","ctrl":"WWPPARAMETERDESCRIPTION","prop":"Visible"},{"av":"edtWWPParameterValueTrimmed_Visible","ctrl":"WWPPARAMETERVALUETRIMMED","prop":"Visible"},{"av":"AV40GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9"},{"av":"AV41GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9"},{"av":"AV8GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS"},{"av":"AV50IsAuthorized_Update","fld":"vISAUTHORIZED_UPDATE","hsh":true},{"av":"edtavUpdate_Visible","ctrl":"vUPDATE","prop":"Visible"},{"av":"AV51IsAuthorized_Delete","fld":"vISAUTHORIZED_DELETE","hsh":true},{"av":"edtavDelete_Visible","ctrl":"vDELETE","prop":"Visible"},{"av":"AV52IsAuthorized_Insert","fld":"vISAUTHORIZED_INSERT","hsh":true},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV27ManageFiltersData","fld":"vMANAGEFILTERSDATA"},{"av":"AV14GridState","fld":"vGRIDSTATE"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Delete","iparms":[]}""");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV19FilterFullText = "";
         AV24ColumnsSelector = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         AV53Pgmname = "";
         AV30TFWWPParameterKey = "";
         AV31TFWWPParameterKey_Sel = "";
         AV32TFWWPParameterCategory = "";
         AV33TFWWPParameterCategory_Sel = "";
         AV34TFWWPParameterDescription = "";
         AV35TFWWPParameterDescription_Sel = "";
         AV36TFWWPParameterValueTrimmed = "";
         AV37TFWWPParameterValueTrimmed_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV27ManageFiltersData = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV8GridAppliedFilters = "";
         AV38DDO_TitleSettingsIcons = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV14GridState = new WorkWithPlus.workwithplus_web.SdtWWPGridState(context);
         A107WWPParameterValue = "";
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
         bttBtninsert_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A106WWPParameterKey = "";
         A108WWPParameterCategory = "";
         A109WWPParameterDescription = "";
         A111WWPParameterValueTrimmed = "";
         AV45Update = "";
         AV46Delete = "";
         lV54Workwithplus_wwp_parameterwwds_1_filterfulltext = "";
         lV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = "";
         lV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = "";
         lV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = "";
         lV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = "";
         AV54Workwithplus_wwp_parameterwwds_1_filterfulltext = "";
         AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = "";
         AV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = "";
         AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = "";
         AV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = "";
         AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = "";
         AV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = "";
         AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = "";
         AV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = "";
         H001J2_A110WWPParameterDisableDelete = new bool[] {false} ;
         H001J2_A109WWPParameterDescription = new string[] {""} ;
         H001J2_A108WWPParameterCategory = new string[] {""} ;
         H001J2_A106WWPParameterKey = new string[] {""} ;
         H001J2_A107WWPParameterValue = new string[] {""} ;
         H001J3_AGRID_nRecordCount = new long[1] ;
         AV11HTTPRequest = new GxHttpRequest( context);
         AV48GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV49GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV26Session = context.GetSession();
         AV22ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV28ManageFiltersXml = "";
         AV23UserCustomValue = "";
         AV25ColumnsSelectorAux = new WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV15GridStateFilterValue = new WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue(context);
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char2 = "";
         AV12TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_parameterww__default(),
            new Object[][] {
                new Object[] {
               H001J2_A110WWPParameterDisableDelete, H001J2_A109WWPParameterDescription, H001J2_A108WWPParameterCategory, H001J2_A106WWPParameterKey, H001J2_A107WWPParameterValue
               }
               , new Object[] {
               H001J3_AGRID_nRecordCount
               }
            }
         );
         AV53Pgmname = "WorkWithPlus.WWP_ParameterWW";
         /* GeneXus formulas. */
         AV53Pgmname = "WorkWithPlus.WWP_ParameterWW";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV16OrderedBy ;
      private short AV29ManageFiltersExecutionStep ;
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
      private int nRC_GXsfl_37 ;
      private int nGXsfl_37_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtWWPParameterKey_Enabled ;
      private int edtWWPParameterCategory_Enabled ;
      private int edtWWPParameterDescription_Enabled ;
      private int edtWWPParameterValueTrimmed_Enabled ;
      private int edtWWPParameterKey_Visible ;
      private int edtWWPParameterCategory_Visible ;
      private int edtWWPParameterDescription_Visible ;
      private int edtWWPParameterValueTrimmed_Visible ;
      private int AV39PageToGo ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV63GXV1 ;
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
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_37_idx="0001" ;
      private string AV53Pgmname ;
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
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtWWPParameterKey_Internalname ;
      private string edtWWPParameterCategory_Internalname ;
      private string edtWWPParameterDescription_Internalname ;
      private string edtWWPParameterValueTrimmed_Internalname ;
      private string AV45Update ;
      private string edtavUpdate_Internalname ;
      private string AV46Delete ;
      private string edtavDelete_Internalname ;
      private string edtavUpdate_Link ;
      private string GXEncryptionTmp ;
      private string edtavDelete_Link ;
      private string edtavDelete_Class ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char2 ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtWWPParameterKey_Jsonclick ;
      private string edtWWPParameterCategory_Jsonclick ;
      private string edtWWPParameterDescription_Jsonclick ;
      private string edtWWPParameterValueTrimmed_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV17OrderedDsc ;
      private bool AV50IsAuthorized_Update ;
      private bool AV51IsAuthorized_Delete ;
      private bool AV52IsAuthorized_Insert ;
      private bool A110WWPParameterDisableDelete ;
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
      private bool bGXsfl_37_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean3 ;
      private string A107WWPParameterValue ;
      private string AV22ColumnsSelectorXML ;
      private string AV28ManageFiltersXml ;
      private string AV23UserCustomValue ;
      private string AV19FilterFullText ;
      private string AV30TFWWPParameterKey ;
      private string AV31TFWWPParameterKey_Sel ;
      private string AV32TFWWPParameterCategory ;
      private string AV33TFWWPParameterCategory_Sel ;
      private string AV34TFWWPParameterDescription ;
      private string AV35TFWWPParameterDescription_Sel ;
      private string AV36TFWWPParameterValueTrimmed ;
      private string AV37TFWWPParameterValueTrimmed_Sel ;
      private string AV8GridAppliedFilters ;
      private string A106WWPParameterKey ;
      private string A108WWPParameterCategory ;
      private string A109WWPParameterDescription ;
      private string A111WWPParameterValueTrimmed ;
      private string lV54Workwithplus_wwp_parameterwwds_1_filterfulltext ;
      private string lV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ;
      private string lV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ;
      private string lV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ;
      private string lV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ;
      private string AV54Workwithplus_wwp_parameterwwds_1_filterfulltext ;
      private string AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ;
      private string AV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ;
      private string AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ;
      private string AV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ;
      private string AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ;
      private string AV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ;
      private string AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ;
      private string AV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ;
      private IGxSession AV26Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV11HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV24ColumnsSelector ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> AV27ManageFiltersData ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV38DDO_TitleSettingsIcons ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState AV14GridState ;
      private IDataStoreProvider pr_default ;
      private bool[] H001J2_A110WWPParameterDisableDelete ;
      private string[] H001J2_A109WWPParameterDescription ;
      private string[] H001J2_A108WWPParameterCategory ;
      private string[] H001J2_A106WWPParameterKey ;
      private string[] H001J2_A107WWPParameterValue ;
      private long[] H001J3_AGRID_nRecordCount ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV48GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV49GAMErrors ;
      private WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private WorkWithPlus.workwithplus_web.SdtWWPColumnsSelector AV25ColumnsSelectorAux ;
      private GXBaseCollection<WorkWithPlus.workwithplus_web.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private WorkWithPlus.workwithplus_web.SdtWWPGridState_FilterValue AV15GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV12TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_parameterww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001J2( IGxContext context ,
                                             string AV54Workwithplus_wwp_parameterwwds_1_filterfulltext ,
                                             string AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ,
                                             string AV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ,
                                             string AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ,
                                             string AV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ,
                                             string AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ,
                                             string AV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ,
                                             string AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ,
                                             string AV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ,
                                             string A106WWPParameterKey ,
                                             string A108WWPParameterCategory ,
                                             string A109WWPParameterDescription ,
                                             string A107WWPParameterValue ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[15];
         Object[] GXv_Object9 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " WWPParameterDisableDelete, WWPParameterDescription, WWPParameterCategory, WWPParameterKey, WWPParameterValue";
         sFromString = " FROM WWP_Parameter";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Workwithplus_wwp_parameterwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(WWPParameterKey) like '%' || LOWER(:lV54Workwithplus_wwp_parameterwwds_1_filterfulltext)) or ( LOWER(WWPParameterCategory) like '%' || LOWER(:lV54Workwithplus_wwp_parameterwwds_1_filterfulltext)) or ( LOWER(WWPParameterDescription) like '%' || LOWER(:lV54Workwithplus_wwp_parameterwwds_1_filterfulltext)) or ( LOWER(( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END)) like '%' || LOWER(:lV54Workwithplus_wwp_parameterwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterKey like :lV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel)) && ! ( StringUtil.StrCmp(AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterKey = ( :AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( StringUtil.StrCmp(AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterCategory like :lV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel)) && ! ( StringUtil.StrCmp(AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterCategory = ( :AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel))");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( StringUtil.StrCmp(AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterCategory))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterDescription like :lV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel)) && ! ( StringUtil.StrCmp(AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterDescription = ( :AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_))");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( StringUtil.StrCmp(AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed)) ) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) like :lV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel)) && ! ( StringUtil.StrCmp(AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) = ( :AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( StringUtil.StrCmp(AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END)))=0))");
         }
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            sOrderString += " ORDER BY WWPParameterKey";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            sOrderString += " ORDER BY WWPParameterKey DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            sOrderString += " ORDER BY WWPParameterCategory, WWPParameterKey";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            sOrderString += " ORDER BY WWPParameterCategory DESC, WWPParameterKey";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            sOrderString += " ORDER BY WWPParameterDescription, WWPParameterKey";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            sOrderString += " ORDER BY WWPParameterDescription DESC, WWPParameterKey";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY WWPParameterKey";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H001J3( IGxContext context ,
                                             string AV54Workwithplus_wwp_parameterwwds_1_filterfulltext ,
                                             string AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ,
                                             string AV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ,
                                             string AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ,
                                             string AV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ,
                                             string AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ,
                                             string AV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ,
                                             string AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ,
                                             string AV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ,
                                             string A106WWPParameterKey ,
                                             string A108WWPParameterCategory ,
                                             string A109WWPParameterDescription ,
                                             string A107WWPParameterValue ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[12];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM WWP_Parameter";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Workwithplus_wwp_parameterwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(WWPParameterKey) like '%' || LOWER(:lV54Workwithplus_wwp_parameterwwds_1_filterfulltext)) or ( LOWER(WWPParameterCategory) like '%' || LOWER(:lV54Workwithplus_wwp_parameterwwds_1_filterfulltext)) or ( LOWER(WWPParameterDescription) like '%' || LOWER(:lV54Workwithplus_wwp_parameterwwds_1_filterfulltext)) or ( LOWER(( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END)) like '%' || LOWER(:lV54Workwithplus_wwp_parameterwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int10[0] = 1;
            GXv_int10[1] = 1;
            GXv_int10[2] = 1;
            GXv_int10[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterKey like :lV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey)");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel)) && ! ( StringUtil.StrCmp(AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterKey = ( :AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel))");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( StringUtil.StrCmp(AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterCategory like :lV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory)");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel)) && ! ( StringUtil.StrCmp(AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterCategory = ( :AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel))");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( StringUtil.StrCmp(AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterCategory))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterDescription like :lV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel)) && ! ( StringUtil.StrCmp(AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterDescription = ( :AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_))");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( StringUtil.StrCmp(AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed)) ) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) like :lV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel)) && ! ( StringUtil.StrCmp(AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) = ( :AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed))");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( StringUtil.StrCmp(AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END)))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
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
                     return conditional_H001J2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
               case 1 :
                     return conditional_H001J3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
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
          Object[] prmH001J2;
          prmH001J2 = new Object[] {
          new ParDef("lV54Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey",GXType.VarChar,300,0) ,
          new ParDef("AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel",GXType.VarChar,300,0) ,
          new ParDef("lV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory",GXType.VarChar,200,0) ,
          new ParDef("AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel",GXType.VarChar,200,0) ,
          new ParDef("lV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription",GXType.VarChar,200,0) ,
          new ParDef("AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_",GXType.VarChar,200,0) ,
          new ParDef("lV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed",GXType.VarChar,30,0) ,
          new ParDef("AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed",GXType.VarChar,30,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH001J3;
          prmH001J3 = new Object[] {
          new ParDef("lV54Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey",GXType.VarChar,300,0) ,
          new ParDef("AV56Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel",GXType.VarChar,300,0) ,
          new ParDef("lV57Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory",GXType.VarChar,200,0) ,
          new ParDef("AV58Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel",GXType.VarChar,200,0) ,
          new ParDef("lV59Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription",GXType.VarChar,200,0) ,
          new ParDef("AV60Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_",GXType.VarChar,200,0) ,
          new ParDef("lV61Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed",GXType.VarChar,30,0) ,
          new ParDef("AV62Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed",GXType.VarChar,30,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001J2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001J3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001J3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
